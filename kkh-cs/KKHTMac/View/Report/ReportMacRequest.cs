using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Isid.NJSecurity.Core;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using Isid.KKH.Mac.ProcessController.Report;
using Isid.KKH.Mac.Schema;
using Isid.KKH.Mac.Utility;


namespace Isid.KKH.Mac.View.Report
{
    /// <summary>
    /// 帳票出力画面（mac請求書) 
    /// </summary>
    /// <remarks>
    ///   修正管理.
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/01/18</description>
    ///       <description>IP H.shimizu</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class ReportMacRequest : KKHForm
    {

        #region 変数.

        // 呼び出しパラメータ(受取)
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        // 消費税.
        private double _dbSyohizei;
        // コピーマクロ削除用string.
        private string _strmacrodel;

        /// <summary>
        /// XMLファイル名1.
        /// </summary>
        private static readonly string REP_XML_FILENAME = "Mac_Request_Data.xml";
        /// <summary>
        /// XMLファイル名2.
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "Mac_Request_Prop.xml";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "Mac_Request_Template.xlsm";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME = "Mac_Request_Mcr.xlsm";

        /// <summary>
        /// アプリID.
        /// </summary>
        private static readonly string APLID = "Request";

        /// <summary>
        /// 更新用データテーブル（伝票番号更新時使用）.
        /// </summary>
        private RepDsMac.RepmacUpdRequestDataTable updTbl = null;

        /// <summary>
        /// 保存先用(テンプレート)変数.
        /// </summary>
        private string pStrRepTempAdrs = "";
        /// <summary>
        /// 保存先用変数.
        /// </summary>
        private string pStrRepAdrs = "";
        /// <summary>
        /// 帳票名（保存で使用）用変数.
        /// </summary>
        private string pStrRepFilNam = "";
        /// <summary>
        /// REP_KEY_SYBT：004
        /// </summary>
        private const string REP_KEY_SYBT = "004";
        /// <summary>
        /// 勘定科目（消費税）.
        /// </summary>
        private string pStrRepComTaxKamoku = "";
        /// <summary>
        /// 会社名（電通）.
        /// </summary>
        private string pStrRepComNm = "";
        /// <summary>
        /// プリンタ名.
        /// </summary>
        private string pStrRepPrinterNm = "";
        /// <summary>
        /// 出力用データセット.
        /// </summary>
        private DataSet OutRequestDs = null;

        #endregion

        #region プロパティ.

        private string _aplId = "";
        /// <summary>
        /// 機能IDを取得、または設定します.
        /// </summary>
        [Category("KKH_REPORT")]
        [Browsable(true)]
        [Description("機能IDを取得、または設定します")]
        public string AplId
        {
            set { _aplId = value; }
            get { return _aplId; }
        }

        #endregion プロパティ.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ReportMacRequest()
        {
            InitializeComponent();
        }

        #endregion

        #region イベント.

        /// <summary>
        /// 表示ボタン押下時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            //*************************************
            // データ検索.
            //*************************************
            this.GetRecord();
        }

        /// <summary>
        /// 画面遷移時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportToh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //初期設定.
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// 画面が初めて表示されるときに発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportMacRequest_Shown(object sender, EventArgs e)
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            // AplId設定 // TODO.
            this.AplId = "RPT_MACr";

            // 年月取得.
            this.InitializeControl();
            this.EditControl();

            //消費税取得（マスタから）.
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.MainType,
                                                                                            "ED-I0001");
            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                //消費税セット.
                _dbSyohizei = double.Parse(comResult.CommonDataSet.SystemCommon[0].field4.ToString());
                //テンプレートアドレス.
                pStrRepTempAdrs = comResult.CommonDataSet.SystemCommon[0].field2.ToString();
                //会社名.
                pStrRepComNm = comResult.CommonDataSet.SystemCommon[0].field5.ToString();
                //勘定科目.
                pStrRepComTaxKamoku = comResult.CommonDataSet.SystemCommon[0].field6.ToString();
                //プリンタ名.
                pStrRepPrinterNm = comResult.CommonDataSet.SystemCommon[0].field7.ToString();
            }

            //保存情報＋帳票名.
            CommonProcessController commonProcessController2 = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult2 = commonProcessController2.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                                            REP_KEY_SYBT);
            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //保存先セット.
                pStrRepAdrs = comResult2.CommonDataSet.SystemCommon[0].field2.ToString();
                //名称セット.
                pStrRepFilNam = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
            }

            //ローディング表示終了.
            base.CloseLoadingDialog();
        }

        /// <summary>
        /// エクセル出力ボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            // エクセル出力.
            this.XlsFileSet();
        }

        /// <summary>
        /// 戻るボタン押下時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (_strmacrodel != null)
            {
                System.IO.FileInfo cFileInfo = new System.IO.FileInfo(_strmacrodel);

                // マクロファイルの削除（VBA側では削除できない為）.
                // ファイルが存在しているか判断する.
                if (cFileInfo.Exists)
                {
                    // 読み取り専用属性がある場合は、読み取り専用属性を解除する.
                    if ((cFileInfo.Attributes & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly)
                    {
                        cFileInfo.Attributes = System.IO.FileAttributes.Normal;
                    }

                    // ファイルを削除する.
                    cFileInfo.Delete();
                }
            }

            Navigator.Backward(this, null, _naviParam, true);
        }

        /// <summary>
        /// 印刷チェック時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbPrint_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton check = (RadioButton)sender;
            if (check.Checked)
            {
                rdbRePrint.Checked = false;
                this.EnableChangeRePrint();
            }
            btnXls.Enabled = false;
        }

        /// <summary>
        /// 再印刷チェック時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbRePrint_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton check = (RadioButton)sender;
            if (check.Checked)
            {
                rdbPrint.Checked = false;
                this.EnableChangeRePrint();
            }
            btnXls.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行.
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Report, this, HelpNavigator.KeywordIndex);
            this.ActiveControl = null;
        }

        /// <summary>
        /// 店舗コードを空の状態でフォーカスアウトすると「0.0」が表示される事の回避.
        /// </summary>
        private void txtTenpoCd_Leave(object sender, EventArgs e)
        {
            if (txtTenpoCd.Text == "0.0")
            {
                txtTenpoCd.Text = System.String.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void condChg(object sender, EventArgs e)
        {
            //帳票出力を非活性化にする.
            btnXls.Enabled = false;
        }

        #endregion

        #region メソッド.

        /// <summary>
        /// 営業日を取得.
        /// </summary>
        /// <returns></returns>
        private String getHostDate()
        {
            String hostDate = "";

            CommonProcessController processController = CommonProcessController.GetInstance();
            hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return hostDate;
        }

        /// <summary>
        /// データ更新.
        /// </summary>
        private void UpdateDgvMainData(RepDsMac.RepmacRequestDataTable resultRequest,
                                        RepDsMac.RepmacGetDenNumDataTable resultSys,
                                        String strYyyyMm)
        {
            // 店舗コード.
            string DenNumCd = string.Empty;

            // 勘定科目.
            string KamokuCd = string.Empty;

            // 更新用Tblインスタンス化.
            updTbl = new RepDsMac.RepmacUpdRequestDataTable();

            // 出力用Dsインスタンス化.
            OutRequestDs = new DataSet();

            RepDsMac edtPurDs = new RepDsMac();
            RepDsMac.outputRequestRow edtPurRow;

            //// 伝票番号の調整.
            //long lngRowNum = 0;

            //for (int i = 0; i < resultPucrhase.Rows.Count; i++)
            foreach (RepDsMac.RepmacRequestRow dr in resultRequest.Rows)
            {
                edtPurRow = edtPurDs.outputRequest.NewoutputRequestRow();
                // 伝票番号.
                edtPurRow.sonota1 = String.Format("{0:0000000}", int.Parse(dr.sonota1.ToString()));
                // 請求金額.
                edtPurRow.seiGak = dr.seiGak;
                // 日付１.
                edtPurRow.Date1 = dr.Date1;
                // 区分１.
                edtPurRow.kbn1 = dr.kbn1;
                // 店舗コード.
                edtPurRow.code1 = dr.code1;
                // 勘定科目.
                edtPurRow.code4 = dr.code4;
                // 件名１.
                edtPurRow.name1 = dr.name1;
                // 件名２.
                edtPurRow.name2 = dr.name2;
                // 店舗名称.
                edtPurRow.name3 = dr.name3;
                // 単価.
                edtPurRow.kngk1 = dr.kngk1;
                // 数量.
                edtPurRow.kngk2 = dr.kngk2;
                // 受注番号.
                edtPurRow.jyutNo = dr.jyutNo;
                // 受注明細番号.
                edtPurRow.jyMeiNo = dr.jyMeiNo;
                // 売上明細番号.
                edtPurRow.urMeiNo = dr.urMeiNo;
                // 連番.
                edtPurRow.renbn = dr.renbn;
                // 社名.
                edtPurRow.syamei = dr.syamei;
                // 住所１.
                edtPurRow.address1 = dr.address1;
                // 住所２.
                edtPurRow.address2 = dr.address2;
                // 郵便番号.
                edtPurRow.yubinNo = dr.yubinNo;
                // 分割フラグ.
                edtPurRow.sonota2 = dr.sonota2;
                // 伝票番号.
                edtPurRow.DenNum = dr.sonota1;
                // 取引先コード.
                edtPurRow.TrhskCd = resultSys[0].TrhskCd;
                // 電話番号.
                edtPurRow.TelNo = resultSys[0].TelNo;
                // 住所.
                edtPurRow.Address = resultSys[0].Address;
                // 伝票調整値.
                edtPurRow.SetDenpyo = resultSys[0].SetDenpyo;
                // ラベル調整値.
                edtPurRow.SetLabel = resultSys[0].SetLabel;
                // 消費税.
                edtPurRow.ComTax = resultSys[0].ComTax;
                // 消費税対応 2013/10/22 add HLC H.Watabe start
                edtPurRow.Ritu1 = dr.Ritu1;
                // 消費税対応 2013/10/22 add HLC H.Watabe end

                edtPurDs.outputRequest.AddoutputRequestRow(edtPurRow);
            }

            //データグリッド初期化.
            dgvMain_Sheet1.RowCount = 0;

            // 店舗コード初期化.
            DenNumCd = string.Empty;

            //データグリッドに表示(件数分表示)
            for (int i = 0; i < edtPurDs.outputRequest.Rows.Count; i++)
            {
                // グリッドに行追加.
                dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 1);

                // 更新用Tbl生成.
                updTbl.AddRepmacUpdRequestRow(strYyyyMm,
                    edtPurDs.outputRequest[i].jyutNo.ToString(),
                    edtPurDs.outputRequest[i].jyMeiNo.ToString(),
                    edtPurDs.outputRequest[i].urMeiNo.ToString(),
                    edtPurDs.outputRequest[i].renbn.ToString());

                // 店舗コード切り替わり時.
                if (!DenNumCd.Equals(edtPurDs.outputRequest[i].sonota1.ToString()))
                {
                    // 伝票番号.
                    dgvMain_Sheet1.Cells[i, 0].Value = edtPurDs.outputRequest[i].sonota1.ToString();
                    DenNumCd = edtPurDs.outputRequest[i].sonota1.ToString();
                }

                // 店舗CD.
                dgvMain_Sheet1.Cells[i, 1].Value = edtPurDs.outputRequest[i].code1.ToString();
                // 店舗名.
                dgvMain_Sheet1.Cells[i, 2].Value = edtPurDs.outputRequest[i].name3.ToString();
                // 売上明細.
                dgvMain_Sheet1.Cells[i, 3].Value = edtPurDs.outputRequest[i].jyutNo.ToString() + "-"
                                                    + edtPurDs.outputRequest[i].jyMeiNo.ToString() + "-"
                                                    + edtPurDs.outputRequest[i].urMeiNo.ToString();

                // 件名.
                dgvMain_Sheet1.Cells[i, 4].Value = edtPurDs.outputRequest[i].name1.ToString() + edtPurDs.outputRequest[i].name2.ToString();

                // 勘定科目.
                dgvMain_Sheet1.Cells[i, 5].Value = edtPurDs.outputRequest[i].code4.ToString();

                // 数量.
                dgvMain_Sheet1.Cells[i, 6].Value
                    = double.Parse(edtPurDs.outputRequest[i].kngk2.ToString()).ToString("###,###,###,##0");

                // 分割フラグを確認.
                if (edtPurDs.outputRequest[i].sonota2 == "1")
                {
                    // 単価.
                    dgvMain_Sheet1.Cells[i, 7].Value
                        = "";
                }
                else
                {
                    // 単価.
                    dgvMain_Sheet1.Cells[i, 7].Value
                        = double.Parse(edtPurDs.outputRequest[i].kngk1.ToString()).ToString("###,###,###,##0");
                }

                // 請求金額.
                dgvMain_Sheet1.Cells[i, 8].Value
                    = double.Parse(edtPurDs.outputRequest[i].seiGak.ToString()).ToString("###,###,###,##0");
            }

            OutRequestDs = edtPurDs;

            //表示件数.
            statusStrip1.Items["tslval1"].Text = edtPurDs.outputRequest.Rows.Count + "件";
        }

        /// <summary>
        /// 画面切替.
        /// </summary>
        private void EnableChangeRePrint()
        {
            if (rdbPrint.Checked)
            {
                //印刷.
                txtYm.Enabled = true;
                //再印刷.
                txtYmRe.Enabled = false;
                txtTenpoCd.Enabled = false;
                txtDnpFr.Enabled = false;
                txtDnpTo.Enabled = false;
            }
            else
            {
                //印刷.
                txtYm.Enabled = false;
                //再印刷.
                txtYmRe.Enabled = true;
                txtTenpoCd.Enabled = true;
                txtDnpFr.Enabled = true;
                txtDnpTo.Enabled = true;
            }
        }

        /// <summary>
        /// データ検索.
        /// </summary>
        private void GetRecord()
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            //年月.
            string strYyyyMm = string.Empty;
            //伝番FROM.
            string strdnpfr = txtDnpFr.Text;
            //伝番TO.
            string strdnpto = txtDnpTo.Text;
            // 再印刷フラグ.
            string reflg = string.Empty;
            // 店舗区分.
            string tenpoKbn = string.Empty;

            ReportMacProcessController processController
                = ReportMacProcessController.GetInstance();
            // パラメータ.
            ReportMacProcessController.FindReportMacGetDenNumByCondParam prmSys
                = new ReportMacProcessController.FindReportMacGetDenNumByCondParam();
            prmSys.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            prmSys.egCd = _naviParam.strEgcd;
            prmSys.tksKgyCd = _naviParam.strTksKgyCd;
            prmSys.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            prmSys.tksTntSeqNo = _naviParam.strTksTntSeqNo;

            FindReportMacGetDenNumByCondServiceResult resultSys
                = processController.FindRepMacGetDenNumByCond(prmSys);

            //エラーの場合.
            if (resultSys.HasError)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();

                //選択状態を解除.
                this.ActiveControl = null;
                return;
            }

            //データが存在しなければ終了.
            if (resultSys.dsRepMacDataSet.RepmacGetDenNum.Rows.Count.Equals(0))
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();

                // 初期化.
                this.Initialize();
                MessageUtility.ShowMessageBox(MessageCode.HB_W0014
                    , new string[] { System.Environment.NewLine }
                    , "帳票"
                    , MessageBoxButtons.OK);

                //選択状態を解除.
                this.ActiveControl = null;

                return;
            }

            this.CheckArguments(out reflg, out  strYyyyMm, out tenpoKbn);

            //実行.
            RepDsMac jyuListdt = new RepDsMac();
            ReportMacProcessController.FindReportMacRequestByCondParam prmReq
                    = new ReportMacProcessController.FindReportMacRequestByCondParam();
            // パラメータ生成.
            prmReq.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            prmReq.egCd = _naviParam.strEgcd;
            prmReq.tksKgyCd = _naviParam.strTksKgyCd;
            prmReq.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            prmReq.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            prmReq.yymm = strYyyyMm;
            prmReq.reflg = reflg;
            prmReq.tenpoKbn = tenpoKbn;
            prmReq.tenpoCd = this.txtTenpoCd.Text;
            prmReq.denFr = strdnpfr;
            prmReq.denTo = strdnpto;

            FindReportMacRequestByCondServiceResult resultRequest
                = processController.FindRepMacRequestByCond(prmReq);

            //エラーの場合.
            if (resultRequest.HasError)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();

                //選択状態を解除.
                this.ActiveControl = null;

                return;
            }

            //データが存在しなければ終了.
            if (resultRequest.dsRepMacDataSet.RepmacRequest.Rows.Count.Equals(0))
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();

                // 初期化.
                this.Initialize();
                //MessageBox.Show("該当のデータは存在しません。"
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);

                //選択状態を解除.
                this.ActiveControl = null;
                return;
            }

            this.UpdateDgvMainData(resultRequest.dsRepMacDataSet.RepmacRequest,
                                    resultSys.dsRepMacDataSet.RepmacGetDenNum,
                                    strYyyyMm);


            // 出力ボタン有効化.
            btnXls.Enabled = true;

            //選択状態を解除.
            this.ActiveControl = null;

            //ローディング表示終了.
            base.CloseLoadingDialog();
        }

        /// <summary>
        /// 各コントロールの編集.
        /// </summary>
        private void EditControl()
        {
            //年月の取得.
            string strDate = getHostDate();
            // 年月.
            //txtYm.Value = strDate.Substring(0, 6);
            // 年月（再印刷）.
            //txtYmRe.Value = strDate.Substring(0, 6);
            // 担当者名.
            //tslName.Text = KKHSecurityInfo.GetInstance().UserName;
            tslName.Text = _naviParam.strName;
            // 営業日.
            tslDate.Text = _naviParam.strDate;

            if (strDate != "")
            {
                strDate = strDate.Trim().Replace("/", "");
                if (strDate.Trim().Length >= 6)
                {
                    txtYm.Value = strDate.Substring(0, 6);
                    txtYmRe.Value = strDate.Substring(0, 6);
                }
                else
                {
                    txtYm.Value = strDate;
                    txtYmRe.Value = strDate;
                }
                txtYm.cmbYM_SetDate();
                txtYmRe.cmbYM_SetDate();
            }
        }

        /// <summary>
        /// 各コントロール初期化.
        /// </summary>
        private void InitializeControl()
        {
            txtYmRe.Value = string.Empty;//年月(再印刷).
            txtYm.Value = string.Empty;  //年月.
            txtDnpFr.Text = string.Empty; //伝票番号From.
            txtDnpTo.Text = string.Empty; //伝票番号To.
            // 初期化.
            this.Initialize();
        }

        /// <summary>
        /// クリアメソッド.
        /// </summary>
        private void Initialize()
        {
            dgvMain_Sheet1.RowCount = 0;
            btnXls.Enabled = false;       //エクセルボタン.
            statusStrip1.Items["tslval1"].Text = "0件";        //表示件数.
        }

        /// <summary>
        /// 画面内パラメータチェック.
        /// </summary>
        private void CheckArguments(out string reflg,
                                    out string strYymm,
                                    out string tenpoKbn)
        {
            //テリトリー.
            tenpoKbn = string.Empty;

            // 年月.
            if (!rdbRePrint.Checked)
            {
                reflg = "0";
                strYymm = txtYm.Value;
            }
            else
            {
                reflg = "1";
                strYymm = txtYmRe.Value;
            }

            // 店舗区分（ライセンシーか否のフラグに使用）.
            if (rdbTenpoKbn1.Checked)
            {
                tenpoKbn = "0";
            }
            if (rdbTenpoKbn2.Checked)
            {
                tenpoKbn = "1";
            }
        }

        /// <summary>
        /// Excel出力メソッド.
        /// </summary>
        /// <param name="filnm">ファイル</param>
        private void ExcelOut(string filnm)
        {
            string workFolderPath = string.Empty;
            string excelFile = string.Empty;
            workFolderPath = pStrRepTempAdrs;
            string macroFile = workFolderPath + REP_MACRO_FILENAME;
            string templFile = workFolderPath + REP_TEMPLATE_FILENAME;
            DataRow dtRow;

            try
            {
                // Excel開始処理.
                // リソースからExcelファイルを作成(テンプレートとマクロ).
                File.WriteAllBytes(macroFile, Isid.KKH.Mac.Properties.Resources.Mac_Request_Mcr);
                File.WriteAllBytes(templFile, Isid.KKH.Mac.Properties.Resources.Mac_Request_Template);

                // テンプレートファイルが存在しない場合.
                if (System.IO.File.Exists(templFile) == false)
                {
                    throw new Exception("テンプレートExcelファイルがありません。");
                }

                // マクロファイルが存在しない場合.
                if (System.IO.File.Exists(macroFile) == false)
                {
                    throw new Exception("マクロExcelファイルがありません。");
                }

                // データセットXML出力.
                OutRequestDs.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));
                // パラメータXML作成、出力.
                // 変数の宣言.
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // データセットにテーブルを追加する.
                // PRODUCTSというテーブルを作成します.
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("USERNAME", Type.GetType("System.String"));
                dtTable.Columns.Add("SELHDK", Type.GetType("System.String"));
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                dtTable.Columns.Add("SYOHIZEI", Type.GetType("System.String"));
                dtTable.Columns.Add("KAMOKUCD", Type.GetType("System.String"));
                dtTable.Columns.Add("COMPANYNM", Type.GetType("System.String"));
                dtTable.Columns.Add("PRINTERNM", Type.GetType("System.String"));

                //テーブルにデータを追加する.
                dtRow = dtTable.NewRow();

                dtRow["SAVEDIR"] = filnm;
                dtRow["SYOHIZEI"] = _dbSyohizei.ToString();
                dtRow["USERNAME"] = tslName.Text;

                // 2014/03/14 JSE K.Tamura mod start.
                // "再印刷の場合、帳票の納品年月の値が、新規印刷の年月になってしまっている"という不具合.
                //dtRow["SELHDK"] = txtYm.Year + "年" + txtYm.Month + "月";

                // "新規印刷"、"再印刷"のどちらのラジオボタンにチェックが付いているかで処理を分岐する.

                // "再印刷"のラジオボタンにチェックが付いている場合.
                if (rdbRePrint.Checked)
                {
                    // "再印刷"年月テキストボックスの値からデータを設定する.
                    dtRow["SELHDK"] = txtYmRe.Year + "年" + txtYmRe.Month + "月";
                }
                // "再印刷"のラジオボタンにチェックが付いていない場合→"新規印刷"のラジオボタンにチェックが付いている場合.
                else
                {
                    // "新規印刷"年月テキストボックスの値からデータを設定する.
                dtRow["SELHDK"] = txtYm.Year + "年" + txtYm.Month + "月";
                }
                // 2014/03/14 JSE K.Tamura mod end.

                dtRow["KAMOKUCD"] = pStrRepComTaxKamoku;
                dtRow["COMPANYNM"] = pStrRepComNm;
                dtRow["PRINTERNM"] = pStrRepPrinterNm;

                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //エクセル起動.
                System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME);

                //削除用に保持（戻るボタン押下時に削除する為）.
                _strmacrodel = workFolderPath + REP_MACRO_FILENAME;

                // ログの出力.
                KKHLogUtilityMac.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityMac.KINO_ID_OPERATION_LOG_Request, KKHLogUtilityMac.DESC_OPERATION_LOG_Request);
            }
            catch (Exception ex)
            {
                //選択状態を解除.
                this.ActiveControl = null;
                throw ex;
            }
        }

        /// <summary>
        /// エクセル出力のファイル設定.
        /// </summary>
        private void XlsFileSet()
        {
            //SaveFileDialogクラスのインスタンスを作成.
            SaveFileDialog sfd = new SaveFileDialog();

            //現在の日付を取得.
            DateTime now = DateTime.Now;

            //はじめのファイル名を指定する.
            // 再印刷ではない時のみ、更新する志の確認を行う.
            // "新規印刷"のラジオボタンにチェックが入っている場合.
            if (rdbPrint.Checked)
            {
                if (MessageUtility.ShowMessageBox(MessageCode.HB_C0001
                    , new string[] { System.Environment.NewLine}
                    , "帳票"
                    , MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    //選択状態を解除.
                    this.ActiveControl = null;

                    return;
                }
            }

            // "再印刷"のラジオボタンにチェックが入っている場合.
            if (rdbRePrint.Checked)
            {
                sfd.FileName = pStrRepFilNam + "_" + now.ToString("yyyyMMdd") + "（再）.xlsm";
            }
            else
            {
                sfd.FileName = pStrRepFilNam + "_" + now.ToString("yyyyMMdd") + ".xlsm";
            }

            //はじめに表示されるフォルダを指定する.
            sfd.InitialDirectory = pStrRepAdrs;

            //[ファイルの種類]に表示される選択肢を指定する.
            sfd.Filter =
                "XLSMファイル(*.xlsm)|*.xlsm";

            //[ファイルの種類]ではじめに.
            //「すべてのファイル」が選択されているようにする.
            sfd.FilterIndex = 0;

            //タイトルを設定する.
            sfd.Title = "保存先のファイルを設定して下さい。";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする.
            sfd.RestoreDirectory = true;

            //ダイアログを表示する.
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //出力先に同名のExcelファイルが開いているかチェック.
                try
                {
                    //同名でファイルを削除する。.
                    File.Delete(sfd.FileName);
                }
                catch (IOException)
                {
                    //出力先に同名のExcelファイルが開いています。閉じてから再度出力してください。.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "帳票", MessageBoxButtons.OK);

                    //選択状態を解除.
                    this.ActiveControl = null;
                    return;
                }

                //*************************************
                // 出力実行.
                //*************************************
                this.ExcelOut(sfd.FileName);

                // 請求書の更新を行う。.
                //if (!rdbRePrint.Checked)
                //{
                    ReportMacProcessController processController
                        = ReportMacProcessController.GetInstance();
                    // パラメータ.
                    ReportMacProcessController.UpdateReportMacReqParam prmUpd
                        = new ReportMacProcessController.UpdateReportMacReqParam();
                    prmUpd.aplId = AplId;
                    prmUpd.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
                    prmUpd.egCd = _naviParam.strEgcd;
                    prmUpd.tksKgyCd = _naviParam.strTksKgyCd;
                    prmUpd.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                    prmUpd.tksTntSeqNo = _naviParam.strTksTntSeqNo;
                    prmUpd.hostDate = getHostDate();
                    prmUpd.DataVO = updTbl;

                    UpdateReportMacReqServiceResult result
                        = processController.UpdateReportMacReq(prmUpd);
                //}
                this.Initialize();
            }

            //選択状態を解除.
            this.ActiveControl = null;
            sfd.Dispose();
        }

        #endregion
    }
}
