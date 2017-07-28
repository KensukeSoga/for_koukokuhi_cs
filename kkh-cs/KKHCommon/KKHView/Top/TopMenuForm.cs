using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.NJSecurity.Core;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Log;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Mast;
using Isid.NJ.View.Base;
using Isid.NJ.View.Navigator;
using System.Drawing.Drawing2D;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;

namespace Isid.KKH.Common.KKHView.Top
{

    /// <summary>
    /// 汎用トップメニュクラス
    /// </summary>
    public partial class TopMenuForm : KKHForm, INaviParameter
    {

        #region "プライベートプロパティ"

        // 呼び出しパラメータ(受取)
        private KKHNaviParameter topNaviParameter;

        #endregion

        #region "パブリックプロパティ"

        /// <summary>
        /// 帳票ボタンvisible
        /// </summary>
        [Category("Kkh")]
        public bool btnAccountVisble
        {
            get { return btnAccount.Visible; }
            set { btnAccount.Visible = value; }
        }

        /// <summary>
        /// 明細ボタンvisible
        /// </summary>
        [Category("Kkh")]
        public bool btnDetailsVisble
        {
            get { return btnDetails.Visible; }
            set { btnDetails.Visible = value; }
        }

        /// <summary>
        /// マスタボタンvisible
        /// </summary>
        [Category("Kkh")]
        public bool btnMasterMaintenanceVisble
        {
            get { return btnMasterMaintenance.Visible; }
            set { btnMasterMaintenance.Visible = value; }
        }

        /// <summary>
        /// お知らせグループvisible
        /// </summary>
        [Category("Kkh")]
        public bool grpInformationVisble
        {
            get { return grpInformation.Visible; }
            set { grpInformation.Visible = value; }
        }

        #endregion

        #region "イベント"

        /// <summary>
        /// 
        /// </summary>
        public TopMenuForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 「マスタメンテナンス」ボタンコントロールがクリックされたときに発生します 
        /// </summary>
        /// <param name="sender">ボタンコントロール</param>
        /// <param name="e">イベントデータ</param>
        private void btnMasterMaintenance_Click(object sender, EventArgs e)
        {
            Navigator.Forward(this, topNaviParameter.strFrmMastNm, topNaviParameter);
        }

        /// <summary>
        /// 「終了」ボタンコントロールがクリックされたときに発生します 
        /// </summary>
        /// <param name="sender">ボタンコントロール</param>
        /// <param name="e">イベントデータ</param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            //// 終了時オペレーションログの出力 
            RegistLogServiceResult logResult = KKHLogUtility.WriteEndingLogToDB(topNaviParameter, "TopMenu", "TopMenuが終了しました。");

            this.Close();
            Environment.Exit(0);
        }

        /// <summary>
        /// 「明細」ボタンコントロール押下時イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetails_Click(object sender, EventArgs e)
        {
            Navigator.Forward(this, topNaviParameter.strFrmDetailNm, topNaviParameter);
        }


        /// <summary>
        /// 「トップメニュ」フォーム呼び出し時イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void TopMenuForm_ProcessAffterNavigating(object sender, NavigationEventArgs arg)
        {

            topNaviParameter = (KKHNaviParameter)arg.NaviParameter;
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(topNaviParameter.strEsqId,
                                                                                            topNaviParameter.strEgcd,
                                                                                            topNaviParameter.strTksKgyCd,
                                                                                            topNaviParameter.strTksBmnSeqNo,
                                                                                            topNaviParameter.strTksTntSeqNo,
                                                                                            "001",
                                                                                            "ED-I0001");

            tslDate.Text = topNaviParameter.strDate;
            tslName.Text = topNaviParameter.strName;
            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                string strInfotxt = string.Empty;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field2.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field2.ToString() + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field3.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field3.ToString() + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field4.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field4.ToString() + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field5.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field5.ToString() + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field6.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field6.ToString() + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field7.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field7.ToString() + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field8.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field8.ToString() + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field9.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field9.ToString() + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field10.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field10.ToString();

                txtInformation.Text = strInfotxt;

            }
            lblTksNm.Text = topNaviParameter.strTksKgyName;

            //画像の初期化 
            btnMasterMaintenance.button.MouseLeaveImage = btnMasterMaintenance.button.MouseDownImage;
            btnAccount.button.MouseLeaveImage = btnAccount.button.MouseDownImage;

            //選択状態を外す 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 「トップメニュ」フォームロード時イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopMenuForm_Load(object sender, EventArgs e)
        {
            //継承先のフォームデザイナ表示ができるようにデザイナモード時には何もしない 
            if (DesignMode == true) { return; }
            RegistLogServiceResult logResult = KKHLogUtility.WriteStartingLogToDB(topNaviParameter, "TopMenu", "TopMenuが起動しました。");

            //フォームの形を変更 
            UpdateFormFormat();

            //画像の初期化 
            btnMasterMaintenance.button.MouseLeaveImage = btnMasterMaintenance.button.MouseDownImage;
            btnAccount.button.MouseLeaveImage = btnAccount.button.MouseDownImage;

            //ツールチップ登録
            this.njToolTip1.SetToolTip(btnMasterMaintenance.button, btnMasterMaintenance.ToolTipText);
            this.njToolTip1.SetToolTip(btnAccount.button, btnAccount.ToolTipText);

            //イベント登録
            btnMasterMaintenance.button.MouseMove += new MouseEventHandler(this.MouseMoveCommon);
            btnMasterMaintenance.button.MouseLeave += new EventHandler(this.MouseLeaveCommon);
            btnAccount.button.MouseMove += new MouseEventHandler(this.MouseMoveCommon);
            btnAccount.button.MouseLeave += new EventHandler(this.MouseLeaveCommon);

        }

        /// <summary>
        /// 帳票ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccount_Click(object sender, EventArgs e)
        {
            this.Tyouhyouseni();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistoryDownLoad_Click(object sender, EventArgs e)
        {
            topNaviParameter.strFrmInputNm = "toHisDownlodData";

            Navigator.Forward(this, topNaviParameter.strFrmInputNm, topNaviParameter);
        }

        /// <summary>
        /// ヘルプボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = topNaviParameter.strTksKgyCd + topNaviParameter.strTksBmnSeqNo + topNaviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.MainManue, this, HelpNavigator.KeywordIndex);

            this.ActiveControl = null;
        }

        #endregion イベント

        # region メソッド
        /// <summary>
        /// 
        /// </summary>
        protected virtual void Tyouhyouseni()
        {
            Navigator.Forward(this, topNaviParameter.strFrmInputNm, topNaviParameter);
        }


        /// <summary>
        /// MouseMoveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void MouseMoveCommon(object sender, MouseEventArgs e)
        {
            tslCnt.Text = njToolTip1.GetToolTip((Control)sender);
        }

        /// <summary>
        /// MouseLeaveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void MouseLeaveCommon(object sender, EventArgs e)
        {
            tslCnt.Text = "";
        }

        # endregion メソッド

        #region 角を丸くする対応関連
        private int arcWidth = 25;
        /// <summary>
        /// 角の円弧の描画元となる楕円の幅、値を大きくするほど角がより丸くなります。 
        /// </summary>
        [Browsable(true)]                              //プロパティウィンドウ表示 
        [Description("角の円弧の描画元となる楕円の幅、値を大きくするほど角がより丸くなります。")]
        [DefaultValue(25)]
        public int ArcWidth
        {
            get { return arcWidth; }
            set { arcWidth = value; }
        }

        private int arcHeight = 25;
        /// <summary>
        /// 角の円弧の描画元となる楕円の高さ、値を大きくするほど角がより丸くなります。 
        /// </summary>
        [Browsable(true)]                              //プロパティウィンドウ表示 
        [Description("角の円弧の描画元となる楕円の高さ、値を大きくするほど角がより丸くなります。")]
        [DefaultValue(25)]
        public int ArcHeight
        {
            get { return arcHeight; }
            set { arcHeight = value; }
        }

        /// <summary>
        /// フォームの形を変更する 
        /// </summary>
        private void UpdateFormFormat()
        {
            if (arcWidth > 0 && arcHeight > 0)
            {
                using (GraphicsPath gp = new GraphicsPath())
                {
                    Rectangle r = this.ClientRectangle;
                    gp.StartFigure();
                    gp.AddArc(r.Right - arcWidth, r.Top, arcWidth, arcHeight, 270, 90);              // 右上

                    gp.AddArc(r.Right - arcWidth, r.Bottom - arcHeight, arcWidth, arcHeight, 0, 90); // 右下

                    gp.AddArc(r.Left, r.Bottom - arcHeight, arcWidth, arcHeight, 90, 90);            // 左下

                    gp.AddArc(r.Left, r.Top, arcWidth, arcHeight, 180, 90);                          // 左上

                    gp.CloseFigure();

                    //形を変更
                    this.Region = new Region(gp);
                }
            }
        }
        #endregion 角を丸くする対応関連

    }
}