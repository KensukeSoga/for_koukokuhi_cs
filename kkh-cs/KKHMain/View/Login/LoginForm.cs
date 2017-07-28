using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.NJSecurity.Core;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHView.Top;
using Isid.NJ.View.Navigator;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.NJSecurity.Connection.WebService.Proxy.Stateful;
using Isid.KKH.Main.ProcessController.Login;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Main.ProcessController.Login.Parser;
using Isid.KKH.Main.Utility;
using System.Drawing.Drawing2D;

namespace Isid.KKH.Main.View.Login
{
    /// <summary>
    /// ログイン面面.
    /// </summary>
    public partial class LoginForm : KKHDialogBase, INaviParameter
    {
        #region 定数.
        #region 固定文言.
        /// <summary>
        /// ログイン.
        /// </summary>
        private const string LOGIN = "ログイン";
        /// <summary>
        /// 管理者ユーザー.
        /// </summary>
        private const string ADMIN_TANTOU = "@@@";
        #endregion 固定文言.
        #endregion 定数.

        #region メンバー変数.
        /// <summary>
        /// 初期ログイン情報.
        /// </summary>
        private loginInitInfoResult _loginInitInfoResult = null;
        /// <summary>
        /// ログイン情報.
        /// </summary>
        private LoginServiceResult _loginServiceResult = null;
        /// <summary>
        /// ログイン得意先情報.
        /// </summary>
        private Isid.KKH.Main.Schema.Login.LoginCustomerDataRow _loginCustomerDataRow = null;
        /// <summary>
        /// 画面読込時発生します.
        /// </summary>
        private KKHNaviParameter inNaviParameter = new KKHNaviParameter();
        #endregion メンバー変数.

        #region コンストラクタ.
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ.

        #region イベント.
        #region 画面読込み時イベント.
        /// <summary>
        /// 画面読込み時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            //初期設定.
            LoginProcessController.GetLoginInitInfoParam param = new LoginProcessController.GetLoginInitInfoParam();
            // ESQID.
            KKHSecurityInfo kKHSecurityInfo = KKHSecurityInfo.GetInstance();
            param.esqId = kKHSecurityInfo.UserEsqId;
            //運用No.
            ISecurityInfo iSecurityInfo = kKHSecurityInfo.SecurityInfo;
            IUserInfo iUserInfo = iSecurityInfo.GetUserInfo();
            IUserProfile iUserProfile = iUserInfo.UserProfile;
            param.operationNo = iUserProfile.OrganizationCode;
            //ログイン初期情報取得.
            LoginProcessController processController = LoginProcessController.GetInstance();
            loginInitInfoResult result = processController.GetLoginInitInfo(param);
            //エラーの場合.
            if (result.errorInfo != null && result.errorInfo.error)
            {
                MessageUtility.ShowMessageBox(result.errorInfo.errorCode, null, LOGIN, MessageBoxButtons.OK);
                this.Close();
                return;
            }
            //業務会計が停止中の場合.
            if (result.accountOperationStatus == false)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0097, null, LOGIN, MessageBoxButtons.OK);
            }
            _loginInitInfoResult = result;

            //管理者のESQIDの場合.
            if (kKHSecurityInfo.NotSecurityRoleFlag == true)
            {
                txtTan.Text = iUserInfo.TantoCode;
                txtTan.Enabled = true;
                txtTan.BackColor = Color.FromKnownColor(KnownColor.Window);
                txtTan.SelectAll();
                txtTan.Focus();
                txtPass.Enabled = true;
                txtPass.BackColor = Color.FromKnownColor(KnownColor.Window);
                txtTkicd.Text = "";
            }
            //その他のESQIDの場合.
            else
            {
                txtTan.Text = iUserInfo.TantoCode;
                txtTkicd.Focus();
            }

            //フォームの形を変更.
            UpdateFormFormat();
        }
        #endregion 画面読込み時イベント.

        #region OKボタンクリックイベント.
        /// <summary>
        /// OKボタンクリックイベント.
        /// </summary>
        /// <param name="sender">ボタンコントロール</param>
        /// <param name="e">イベントデータ</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            //入力チェック.
            if (!chekInputItem())
            {
                return;
            }

            //ログイン処理.
            if (!login())
            {
                return;
            }

            //メニュー画面表示.
            displayMenu();
        }
        #endregion OKボタンクリックイベント.

        #region CANCELボタンクリックイベント.
        /// <summary>
        /// CANCELボタンクリックイベント.
        /// </summary>
        /// <param name="sender">ボタンコントロール</param>
        /// <param name="e">イベントデータ</param>
        private void btnCan_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion CANCELボタンクリックイベント.

        #region 担当者コード変更時イベント.
        /// <summary>
        /// 担当者コード変更時イベント.
        /// </summary>
        /// <param name="sender">ボタンコントロール</param>
        /// <param name="e">イベントデータ</param>
        private void txtTan_TextChanged(object sender, EventArgs e)
        {
            txtTan.Text = KKHUtility.RemoveProhibitionChar(txtTan.Text);
            int len = txtTan.MaxLength;
            txtTan.SelectionStart = len;
        }
        #endregion 担当者コード変更時イベント.

        #region 得意先コード変更時イベント.
        /// <summary>
        /// 得意先コード変更時イベント.
        /// </summary>
        /// <param name="sender">ボタンコントロール</param>
        /// <param name="e">イベントデータ</param>
        private void txtTkicd_TextChanged(object sender, EventArgs e)
        {
            //初期設定.
            txtTkicd.Text = KKHUtility.RemoveProhibitionChar(txtTkicd.Text);
            int len = txtTkicd.MaxLength;
            txtTkicd.SelectionStart = len;

            //得意先コードが[@@@@@@@@]の場合.
            if (txtTkicd.Text == "@@@@@@@@")
            {
                txtTan.Enabled = true;
                txtTan.BackColor = Color.FromKnownColor(KnownColor.Window);
                txtTan.SelectAll();
                txtTan.Focus();
                txtPass.Enabled = true;
                txtPass.BackColor = Color.FromKnownColor(KnownColor.Window);
                txtTkicd.Text = "";
            }

            //得意先コードが8桁の場合.
            if (txtTkicd.Text.Length == 8)
            {
                LoginProcessController.GetCustomerInfoParam param = new LoginProcessController.GetCustomerInfoParam();
                KKHSecurityInfo kKHSecurityInfo = KKHSecurityInfo.GetInstance();
                param.esqId = kKHSecurityInfo.UserEsqId;
                param.customerCode = txtTkicd.Text;
                //得意先情報取得.
                LoginProcessController processController = LoginProcessController.GetInstance();
                customerInfoResult result = processController.GetCustomerInfo(param);

                //エラーの場合.
                if (result.errorInfo != null && result.errorInfo.error)
                {
                    MessageUtility.ShowMessageBox(result.errorInfo.errorCode, null, LOGIN, MessageBoxButtons.OK);
                    txtTkicd.SelectAll();
                    lblTkinm.Text = "";
                }
                //エラーでない場合.
                else
                {
                    lblTkinm.Text = result.customerName;
                }
            }
            else
            {
                lblTkinm.Text = "";
            }
        }
        #endregion 得意先コード変更時イベント.
        #endregion イベント

        #region メソッド.
        #region 入力項目チェック.
        /// <summary>
        /// 入力項目チェック.
        /// </summary>
        private bool chekInputItem()
        {
            //担当者コードが未入力の場合.
            if (string.IsNullOrEmpty(txtTan.Text))
            {
                //警告メッセージを表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0098, null, LOGIN, MessageBoxButtons.OK);
                txtTan.Focus();
                return false;
            }
            //得意先名称が表示されていない場合.
            if (string.IsNullOrEmpty(lblTkinm.Text))
            {
                //警告メッセージを表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0099, null, LOGIN, MessageBoxButtons.OK);
                txtTkicd.SelectAll();
                txtTkicd.Focus();
                return false;
            }

            return true;
        }
        #endregion 入力項目チェック.

        #region ログイン処理.
        /// <summary>
        /// ログイン処理.
        /// </summary>
        private bool login()
        {
            //初期設定.
            LoginProcessController.LoginParam loginParam = new LoginProcessController.LoginParam();
            KKHSecurityInfo kKHSecurityInfo = KKHSecurityInfo.GetInstance();
            loginParam.esqId = kKHSecurityInfo.UserEsqId;
            ISecurityInfo iSecurityInfo = kKHSecurityInfo.SecurityInfo;
            IUserInfo iUserInfo = iSecurityInfo.GetUserInfo();
            IUserProfile iUserProfile = iUserInfo.UserProfile;
            loginParam.operationNo = iUserProfile.OrganizationCode;
            loginParam.userId = txtTan.Text;
            loginParam.password = txtPass.Text;
            loginParam.customerCode = txtTkicd.Text;

            //スーパーユーザー、特別ログインユーザーの場合.
            if (txtTan.Enabled)
            {
                loginParam.normalUserFlag = KkhConstMain.Flag.OFF;
            }
            //通常ユーザーの場合.
            else
            {
                loginParam.normalUserFlag = KkhConstMain.Flag.ON;
            }
            loginParam.relativeAuthority = kKHSecurityInfo.RelativeAuthority;
            loginParam.organizationCode = _loginInitInfoResult.organizationCode;
            loginParam.eigyoBi = _loginInitInfoResult.eigyoBi;

            //ログイン処理.
            LoginProcessController processController = LoginProcessController.GetInstance();
            _loginServiceResult = processController.Login(loginParam);

            //エラーの場合.
            if (_loginServiceResult.HasError)
            {
                //警告メッセージを表示.
                MessageUtility.ShowMessageBox(_loginServiceResult.MessageCode, null, LOGIN, MessageBoxButtons.OK);

                //メッセージレベルがエラー以外の場合.
                if (_loginServiceResult.MessageCode.Substring(3, 1) != KKHSystemConst.MessageLevel.Error)
                {
                    txtTkicd.SelectAll();
                    txtTkicd.Focus();
                }

                return false;
            }

            //ユーザータイプの設定.
            inNaviParameter.StrSystemAdministerFlg = _loginServiceResult.SystemAdministerFlg;

            //得意先が1件の場合.
            if (_loginServiceResult.LoginCustomerDataSet.LoginCustomerData.Count == 1)
            {
                _loginCustomerDataRow = _loginServiceResult.LoginCustomerDataSet.LoginCustomerData[0];
            }
            //得意先が複数件の場合.
            else
            {
                //初期設定.
                LoginNaviParameter naviParam = new LoginNaviParameter();
                naviParam.strEsqId = kKHSecurityInfo.UserEsqId;
                naviParam.strEgcd = _loginServiceResult.EgCd;
                naviParam.loginCustomerDataDataTable = _loginServiceResult.LoginCustomerDataSet.LoginCustomerData;

                //得意先選択画面表示.
                object customerSelectResult = Navigator.ShowModalFormByName(this, "LoginCustomerSelect", naviParam);
                _loginCustomerDataRow = _loginServiceResult.LoginCustomerDataSet.LoginCustomerData[0];
                LoginProcessController.GetOpenCustomerInfoParam openCustomerInfoParam = new LoginProcessController.GetOpenCustomerInfoParam();
                openCustomerInfoParam.esqId = kKHSecurityInfo.UserEsqId;
                openCustomerInfoParam.egCd = _loginServiceResult.EgCd;
                int rowIndex = naviParam.loginCustomerDataIndex;
                _loginCustomerDataRow = _loginServiceResult.LoginCustomerDataSet.LoginCustomerData[rowIndex];
                openCustomerInfoParam.tksKgyCd = _loginCustomerDataRow.tksKgyCd;
                openCustomerInfoParam.tksBmnSeqNo = _loginCustomerDataRow.tksBmnSeqNo;
                openCustomerInfoParam.tksTntSeqNo = _loginCustomerDataRow.tksTntSeqNo;

                //開放得意先情報取得.
                openCustomerInfoResult result = processController.GetOpenCustomerInfo(openCustomerInfoParam);

                //エラーの場合.
                if (result.errorInfo != null && result.errorInfo.error)
                {
                    MessageUtility.ShowMessageBox(result.errorInfo.errorCode, null, LOGIN, MessageBoxButtons.OK);
                    txtTkicd.SelectAll();
                    txtTkicd.Focus();
                    return false;
                }
            }

            //開放確認.
            KKHNaviParameter release_naviParam = new KKHNaviParameter();
            release_naviParam.strEsqId = kKHSecurityInfo.UserEsqId;
            release_naviParam.strEgcd = _loginServiceResult.EgCd;
            release_naviParam.strTksKgyCd = _loginCustomerDataRow.tksKgyCd; 
            release_naviParam.strTksBmnSeqNo = _loginCustomerDataRow.tksBmnSeqNo ;
            release_naviParam.strTksTntSeqNo = _loginCustomerDataRow.tksTntSeqNo;

            //取得.
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(
                                                                                            release_naviParam.strEsqId,
                                                                                            release_naviParam.strEgcd,
                                                                                            release_naviParam.strTksKgyCd,
                                                                                            release_naviParam.strTksBmnSeqNo,
                                                                                            release_naviParam.strTksTntSeqNo,
                                                                                            KkhConstMain.RELEASE_SYBT,
                                                                                            KkhConstMain.TF_FLD1);
            
            // データが存在する場合はメッセージ表示.
            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                //警告メッセージを表示.
                MessageBox.Show(comResult.CommonDataSet.SystemCommon[0].field2.ToString(), LOGIN, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //管理者ユーザーは操作可能.
                if (!txtTan.Text.Substring(0, 3).Equals(ADMIN_TANTOU))
                {
                    txtTkicd.SelectAll();
                    txtTkicd.Focus();
                    return false; 
                }
            }

            return true;
        }
        #endregion ログイン処理.

        #region メニュー画面表示.
        /// <summary>
        /// メニュー画面表示.
        /// </summary>
        private void displayMenu()
        {
            //初期設定.
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            inNaviParameter.Function = Function.TOP;
            KKHSecurityInfo kKHSecurityInfo = KKHSecurityInfo.GetInstance();

            //スーパーユーザー、特別ログインユーザーの場合.
            if (txtTan.Enabled)
            {
                inNaviParameter.strEsqId = txtTan.Text;
                inNaviParameter.strName = _loginServiceResult.UserName;
            }
            //通常ユーザーの場合.
            else
            {
                inNaviParameter.strEsqId = kKHSecurityInfo.UserEsqId;
                inNaviParameter.strName = KKHSecurityInfo.GetInstance().UserName;
            }

            /* 2016/05/31 JSE K.Takahasi ADD Start */
            //データ取得(開放確認).
            string workFolderPath = string.Empty;
            CommonProcessController controller = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult result = controller.FindCommonByCond(
                                                                            inNaviParameter.strEsqId,
                                                                            _loginServiceResult.EgCd,
                                                                            _loginCustomerDataRow.tksKgyCd,
                                                                            _loginCustomerDataRow.tksBmnSeqNo,
                                                                            _loginCustomerDataRow.tksTntSeqNo,
                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.MainType,
                                                                            "ED-I0001");
            //0件の場合.
            if (result.CommonDataSet.SystemCommon.Count != 0)
            {
                //テンプレート出力パス.
                workFolderPath = result.CommonDataSet.SystemCommon[0].field2.ToString();
            }
            //フォルダが存在しない場合、指定されたフォルダを作成する.
            KKHUtility.SafeCreateDirectory(workFolderPath);
            /* 2016/05/31 JSE K.Takahasi ADD End */

            inNaviParameter.strEgcd = _loginServiceResult.EgCd;
            inNaviParameter.strTksKgyCd = _loginCustomerDataRow.tksKgyCd;
            inNaviParameter.strTksBmnSeqNo = _loginCustomerDataRow.tksBmnSeqNo;
            inNaviParameter.strTksTntSeqNo = _loginCustomerDataRow.tksTntSeqNo;
            inNaviParameter.strDate = KKHUtility.StringCnvDateTime(_loginInitInfoResult.eigyoBi).ToString("yyyy/MM/dd");
            inNaviParameter.strTksKgyName = _loginCustomerDataRow.dispTksName;

            switch (_loginCustomerDataRow.tksKgyCd + _loginCustomerDataRow.tksBmnSeqNo + _loginCustomerDataRow.tksTntSeqNo)
            {
                //アコム.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Acom:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuAcom";
                    inNaviParameter.strFrmMastNm = "tofrmMastAcom";
                    inNaviParameter.strFrmInputNm = "toReportAcom";
                    inNaviParameter.strFrmDetailNm = "toDetailAcom";
                    break;
                //アサヒ飲料.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Ash:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuAsh";
                    inNaviParameter.strFrmMastNm = "tofrmMastAsh";
                    inNaviParameter.strFrmInputNm = "";
                    inNaviParameter.strFrmDetailNm = "toDetailAsh";
                    break;
                //アサヒビール.
                case KKHSystemConst.TksKgyCode.TksKgyCode_AshBear:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuAsh";
                    inNaviParameter.strFrmMastNm = "tofrmMastAsh";
                    inNaviParameter.strFrmInputNm = "";
                    inNaviParameter.strFrmDetailNm = "toDetailAsh";
                    break;
                //スカパー.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Skyp:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuSkyp";
                    inNaviParameter.strFrmMastNm = "tofrmMastSkyp";
                    inNaviParameter.strFrmInputNm = "toReportSkyp";
                    inNaviParameter.strFrmDetailNm = "toDetailSkyp";
                    break;
                //ユニチャーム.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Uni:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuUni";
                    inNaviParameter.strFrmMastNm = "tofrmMastUni";
                    inNaviParameter.strFrmInputNm = "toReportUni";
                    inNaviParameter.strFrmDetailNm = "toDetailUni";
                    break;
                //ライオン.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Lion:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuLion";
                    inNaviParameter.strFrmMastNm = "tofrmMastLion";
                    inNaviParameter.strFrmInputNm = "toReportLion";
                    inNaviParameter.strFrmDetailNm = "toDetailLion";
                    break;
                //武田薬品.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Tkd:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuTkd";
                    inNaviParameter.strFrmMastNm = "tofrmMastTkd";
                    inNaviParameter.strFrmInputNm = "toReportTkd";
                    inNaviParameter.strFrmDetailNm = "toDetailTkd";
                    break;
                //マクドナルド.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Mac:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuMac";
                    inNaviParameter.strFrmMastNm = "tofrmMastMac";
                    inNaviParameter.strFrmInputNm = "toReportMac";
                    inNaviParameter.strFrmDetailNm = "toDetailMac";
                    break;
                //東宝、東宝アド.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Toh:
                /* 2015/06/11 東宝アド追加対応 HLC K.Soga ADD Start */
                case KKHSystemConst.TksKgyCode.TksKgyCode_TohAd:
                /* 2015/06/11 東宝アド追加対応 HLC K.Soga ADD End */
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuToh";
                    inNaviParameter.strFrmMastNm = "tofrmMastToh";
                    inNaviParameter.strFrmInputNm = "toReportToh";
                    inNaviParameter.strFrmDetailNm = "toDetailToh";
                    break;
                //EPSON.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Epson:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuEpson";
                    inNaviParameter.strFrmMastNm = "tofrmMastEpson";
                    inNaviParameter.strFrmInputNm = "";
                    inNaviParameter.strFrmDetailNm = "toDetailEpson";
                    break;
                //公文.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Kmn:
                /* 2015/04/01 公文得意先変更対応 HLC K.Fujisaki ADD Start */
                case KKHSystemConst.TksKgyCode.TksKgyCode_Kmn_2015:
                /* 2015/04/01 公文得意先変更対応 HLC K.Fujisaki ADD End */
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuKmn";
                    inNaviParameter.strFrmMastNm = "tofrmMastKmn";
                    inNaviParameter.strFrmInputNm = "toReportKmn";
                    inNaviParameter.strFrmDetailNm = "toDetailKmn";
                    break;
                //対象外の得意先.
                default:
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0108, null, LOGIN, MessageBoxButtons.OK);
                    txtTkicd.SelectAll();
                    txtTkicd.Focus();
                    return;
            }

            Navigator.Forward(this, inNaviParameter.strFrmTopMenuNM, inNaviParameter);
        }
        #endregion メニュー画面表示.

        #region 角を丸くする対応関連
        #region 角の円弧の描画元となる楕円の幅、値を大きくするほど角がより丸くなります.
        private int arcWidth = 25;
        /// <summary>
        /// 角の円弧の描画元となる楕円の幅、値を大きくするほど角がより丸くなります.
        /// </summary>
        //プロパティウィンドウ表示.
        [Browsable(true)]                              
        [Description("角の円弧の描画元となる楕円の幅、値を大きくするほど角がより丸くなります。")]
        [DefaultValue(25)]
        public int ArcWidth
        {
            get { return arcWidth; }
            set { arcWidth = value; }
        }
        #endregion 角の円弧の描画元となる楕円の幅、値を大きくするほど角がより丸くなります.

        #region 角の円弧の描画元となる楕円の高さ、値を大きくするほど角がより丸くなります.
        private int arcHeight = 25;
        /// <summary>
        /// 角の円弧の描画元となる楕円の高さ、値を大きくするほど角がより丸くなります.
        /// </summary>
        //プロパティウィンドウ表示.
        [Browsable(true)]
        [Description("角の円弧の描画元となる楕円の高さ、値を大きくするほど角がより丸くなります。")]
        [DefaultValue(25)]
        public int ArcHeight
        {
            get { return arcHeight; }
            set { arcHeight = value; }
        }
        #endregion 角の円弧の描画元となる楕円の高さ、値を大きくするほど角がより丸くなります.

        #region フォームの形を変更する.
        /// <summary>
        /// フォームの形を変更する.
        /// </summary>
        private void UpdateFormFormat()
        {
            if (arcWidth > 0 && arcHeight > 0)
            {
                using (GraphicsPath gp = new GraphicsPath())
                {
                    Rectangle r = this.ClientRectangle;
                    gp.StartFigure();
                    //右上.
                    gp.AddArc(r.Right - arcWidth, r.Top, arcWidth, arcHeight, 270, 90);
                    //右下.
                    gp.AddArc(r.Right - arcWidth, r.Bottom - arcHeight, arcWidth, arcHeight, 0, 90);
                    //左下.
                    gp.AddArc(r.Left, r.Bottom - arcHeight, arcWidth, arcHeight, 90, 90);
                    //左上.
                    gp.AddArc(r.Left, r.Top, arcWidth, arcHeight, 180, 90);
                    gp.CloseFigure();

                    //形を変更.
                    this.Region = new Region(gp);
                }
            }
        }
        #endregion フォームの形を変更する.
        #endregion 角を丸くする対応関連.
        #endregion メソッド.
    }
}