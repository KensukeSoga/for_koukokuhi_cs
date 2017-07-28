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
using Isid.KKH.Mac.ProcessController.Report;
using Isid.KKH.Mac.Schema;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Mac.Utility;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using Isid.KKH.Common.KKHView.Common.Control;

namespace Isid.KKH.Mac.View.Report
{
    /// <summary>
    /// 帳票出力画面（mac購入伝票）.
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
    public partial class ReportMacPurchase : KKHForm
    {

        #region 変数.

        // 呼び出しパラメータ(受取)
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        // 消費税.
        private double _dbSyohizei;
        // コピーマクロ削除用string
        private string _strmacrodel;

        /// <summary>
        /// XMLファイル名1.
        /// </summary>
        private static readonly string REP_XML_FILENAME = "Mac_Purchase_Data.xml";
        /// <summary>
        /// XMLファイル名2.
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "Mac_Purchase_Prop.xml";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "Mac_Purchase_Template.xlsm";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME = "Mac_Purchase_Mcr.xlsm";

        /// <summary>
        /// アプリID
        /// </summary>
        private static readonly string APLID = "Purchase";

        /// <summary>
        /// 更新用データテーブル（伝票番号更新時使用）.
        /// </summary>
        private RepDsMac.RepmacUpdPurchaseDataTable updTbl = null;

        /// <summary>
        /// 出力用データセット.
        /// </summary>
        private DataSet OutPurchaseDs = null;

        /// <summary>
        /// 更新日時の最大値(初期値: 1000/01/01 01:01:01)
        /// </summary>
        DateTime maxupdate = DateTime.Parse("1000/01/01 01:01:01");
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
        /// REP_KEY_SYBT：003
        /// </summary>
        private const string REP_KEY_SYBT = "003";
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

        // 伝票番号(採番値)
        private long lngDenNum = 0;

        // 伝票番号上限値.
        private long lngDenNumMax = 0;

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
        public ReportMacPurchase()
        {
            InitializeComponent();
        }

        #endregion

        #region イベント.

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
        /// 画面が初めて表示されたときに発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportMacPurchase_Shown(object sender, EventArgs e)
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            // AplId設定 // TODO
            this.AplId = "RPT_MACp";

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

            if (!comResult.CommonDataSet.SystemCommon.Count.Equals(0))
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
        /// 表示ボタン押下時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            if (!chkKanto.Checked && !chkKansai.Checked && !chkCenter.Checked && !chkOther.Checked)
            {
                // 初期化.
                this.Initialize();
                MessageUtility.ShowMessageBox(MessageCode.HB_W0018
                    , null
                    , "帳票"
                    , MessageBoxButtons.OK);
                return;
            }
            //*************************************
            // データ検索.
            //*************************************
            this.GetRecord();

            //選択状態を解除.
            this.ActiveControl = null;

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
        /// ヘルプボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //KKHHelpMac.ShowHelpMac(this, this.Name);
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();

            //実行.
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Report, this, HelpNavigator.KeywordIndex);
            this.ActiveControl = null;
        }

        /// <summary>
        /// 再印刷チェック時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkRePrint_CheckedChanged(object sender, EventArgs e)
        {
            this.EnableChangeRePrint(chkRePrint.Checked);
            btnXls.Enabled = false;
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
        private void UpdateDgvMainData(RepDsMac.RepmacPurchaseDataTable resultPucrhase,
                                        RepDsMac.RepmacGetDenNumDataTable resultSys,
                                        String strYyyyMm)
        {
            // 店舗コード.
            string TenpoCd = string.Empty;

            // 勘定科目.
            string KamokuCd = string.Empty;

            // 更新用Tblインスタンス化.
            updTbl = new RepDsMac.RepmacUpdPurchaseDataTable();

            // 出力用Dsインスタンス化.
            OutPurchaseDs = new DataSet();

            RepDsMac edtPurDs = new RepDsMac();
            RepDsMac.outputPurchaseRow edtPurRow;

            // 伝票番号の調整.
            long lngRowNum = 0;

            //for (int i = 0; i < resultPucrhase.Rows.Count; i++)
            foreach (RepDsMac.RepmacPurchaseRow dr in resultPucrhase.Rows)
            {
                edtPurRow = edtPurDs.outputPurchase.NewoutputPurchaseRow();
                if (!chkRePrint.Checked) // 再印刷以外.
                {
                    // 行番号インクリメント.
                    lngRowNum = lngRowNum + 1;

                    // 店舗コード変更時.
                    if (!TenpoCd.Equals(dr.code1.ToString()))
                    {
                        // 伝票番号インクリメント.
                        lngDenNum++;

                        // 行番号初期化.
                        lngRowNum = 1;
                        TenpoCd = dr.code1.ToString();
                        KamokuCd = dr.code4.ToString();
                    }
                    else
                    {
                        // 勘定科目変更時.
                        if (!KamokuCd.Equals(dr.code4.ToString()))
                        {
                            // 伝票番号インクリメント.
                            lngDenNum++;

                            // 行番号初期化.
                            lngRowNum = 1;
                            TenpoCd = dr.code1.ToString();
                            KamokuCd = dr.code4.ToString();
                        }
                        else
                        {
                            // 5行以上.
                            if (lngRowNum > 4)
                            {
                                // 伝票番号インクリメント.
                                lngDenNum++;

                                // 行番号初期化.
                                lngRowNum = 1;
                                TenpoCd = dr.code1.ToString();
                                KamokuCd = dr.code4.ToString();
                            }
                            else
                            {
                                // 明細行フラグが"分割".
                                if (dr.splitflg.ToString().Equals("0"))
                                {
                                    // 伝票番号インクリメント,
                                    lngDenNum++;

                                    // 行番号初期化,
                                    lngRowNum = 1;
                                    TenpoCd = dr.code1.ToString();
                                    KamokuCd = dr.code4.ToString();
                                }
                            }
                        }
                    }

                    // 伝票番号を上限値と比較する。,
                    if (lngDenNum > lngDenNumMax)
                    {
                        lngDenNum = lngDenNum - 1;
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0064
                        , new string[] { System.Environment.NewLine, System.Environment.NewLine }
                        , "帳票"
                        , MessageBoxButtons.OK);
                        break;
                    }
                    edtPurRow.sonota1 = String.Format("{0:0000000}", int.Parse(lngDenNum.ToString()));
                }
                else
                {
                    // 伝票番号,
                    edtPurRow.sonota1 = dr.sonota1;
                }

                // 伝票番号.
                //edtPurRow.sonota1 = dr.sonota1;
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
                // 明細行フラグ.
                edtPurRow.sonota2 = dr.sonota2;
                // 明細行フラグ.
                edtPurRow.splitflg = dr.splitflg;
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
                //消費税対応 2013/10/21 add HLC H.Watabe start
                edtPurRow.Ritu1 = dr.Ritu1;
                //消費税対応 2013/10/21 add HLC H.Watabe end

                edtPurDs.outputPurchase.AddoutputPurchaseRow(edtPurRow);
            }

            //データグリッド初期化.
            dgvMain_Sheet1.RowCount = 0;

            // 店舗コード初期化.
            TenpoCd = string.Empty;

            // 更新用Tbl生成.
            for (int i = 0; i < edtPurDs.outputPurchase.Rows.Count; i++)
            {
                // 更新用Tbl生成.
                updTbl.AddRepmacUpdPurchaseRow(strYyyyMm,
                    edtPurDs.outputPurchase[i].jyutNo.ToString(),
                    edtPurDs.outputPurchase[i].jyMeiNo.ToString(),
                    edtPurDs.outputPurchase[i].urMeiNo.ToString(),
                    edtPurDs.outputPurchase[i].renbn.ToString(),
                    edtPurDs.outputPurchase[i].sonota1.ToString(),
                    edtPurDs.outputPurchase[i].kbn1.ToString());
            }

            //ライセンシーを削除.
            for (int i = 0; i < edtPurDs.outputPurchase.Count; i++)
            {
                //店舗区分がライセンシーの場合.
                if (edtPurDs.outputPurchase[i].kbn1 == "2")
                {
                    //削除する.
                    edtPurDs.outputPurchase[i].Delete();
                    //行数が減るためカウントを加算しない.
                    i--;
                }
            }

            //削除を確定する.
            edtPurDs.outputPurchase.AcceptChanges();

            //データグリッドに表示(件数分表示).
            for (int i = 0; i < edtPurDs.outputPurchase.Rows.Count; i++)
            {
                // グリッドに行追加.
                dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 1);

                // 店舗コード切り替わり時.
                if (!TenpoCd.Equals(edtPurDs.outputPurchase[i].code1.ToString()))
                {
                    dgvMain_Sheet1.Cells[i, 0].Value = edtPurDs.outputPurchase[i].code1.ToString();
                    dgvMain_Sheet1.Cells[i, 1].Value = edtPurDs.outputPurchase[i].name3.ToString();
                    TenpoCd = edtPurDs.outputPurchase[i].code1.ToString();
                }

                // 伝票番号.
                dgvMain_Sheet1.Cells[i, 2].Value = edtPurDs.outputPurchase[i].sonota1.ToString();

                // 売上明細.
                dgvMain_Sheet1.Cells[i, 3].Value = edtPurDs.outputPurchase[i].jyutNo.ToString() + "-"
                                                    + edtPurDs.outputPurchase[i].jyMeiNo.ToString() + "-"
                                                    + edtPurDs.outputPurchase[i].urMeiNo.ToString();

                // 件名.
                dgvMain_Sheet1.Cells[i, 4].Value = edtPurDs.outputPurchase[i].name1.ToString()
                                                    + edtPurDs.outputPurchase[i].name2.ToString();
                //// 社名.
                //dgvMain_Sheet1.Cells[i, 4].Value = edtPurDs.outputPurchase[i].name1.ToString() + '　' + edtPurDs.outputPurchase[i].name2.ToString();

                // 勘定科目.
                dgvMain_Sheet1.Cells[i, 5].Value = edtPurDs.outputPurchase[i].code4.ToString();

                // 数量.
                dgvMain_Sheet1.Cells[i, 6].Value
                    = double.Parse(edtPurDs.outputPurchase[i].kngk2.ToString()).ToString("###,###,###,##0");

                // 分割フラグを確認.
                if (edtPurDs.outputPurchase[i].sonota2 == "1")
                {
                    // 単価.
                    dgvMain_Sheet1.Cells[i, 7].Value = "";
                }
                else
                {
                    // 単価.
                    dgvMain_Sheet1.Cells[i, 7].Value
                        = double.Parse(edtPurDs.outputPurchase[i].kngk1.ToString()).ToString("###,###,###,##0.##0");
                }

                // 請求金額.
                dgvMain_Sheet1.Cells[i, 8].Value
                    = Math.Floor(Isid.KKH.Common.KKHUtility.KKHUtility.DecParse(edtPurDs.outputPurchase[i].seiGak.ToString())).ToString("###,###,###,##0");
                //dgvMain_Sheet1.Cells[i, 8].Value
                //    = double.Parse(edtPurDs.outputPurchase[i].seiGak.ToString()).ToString("###,###,###,##0");

            }
            maxupdate = DateTime.Now;

            OutPurchaseDs = edtPurDs;
            //表示件数.
            statusStrip1.Items["tslval1"].Text = edtPurDs.outputPurchase.Rows.Count + "件";
        }

        /// <summary>
        /// 再印刷時の画面切替.
        /// </summary>
        /// <param name="enable"></param>
        private void EnableChangeRePrint(bool enable)
        {
            //grpRePrint.Enabled = enable;
            this.txtYmRe.Enabled = enable;
            this.txtTenpoCd.Enabled = enable;
            this.txtDnpFr.Enabled = enable;
            this.txtDnpTo.Enabled = enable;
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
            // 明細行フラグ.
            string splitflg = string.Empty;
            // 再印刷フラグ.
            string reflg = string.Empty;
            // テリトリー.
            string territory = string.Empty;

            // 伝票番号.
            lngDenNum = 0;
            // 伝票上限値.
            lngDenNumMax = 0;

            ReportMacProcessController processController = ReportMacProcessController.GetInstance();
            // パラメータ.
            ReportMacProcessController.FindReportMacGetDenNumByCondParam prmSys
                = new ReportMacProcessController.FindReportMacGetDenNumByCondParam();
            prmSys.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            prmSys.egCd = _naviParam.strEgcd;
            prmSys.tksKgyCd = _naviParam.strTksKgyCd;
            prmSys.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            prmSys.tksTntSeqNo = _naviParam.strTksTntSeqNo;

            FindReportMacGetDenNumByCondServiceResult resultSys = processController.FindRepMacGetDenNumByCond(prmSys);

            //エラーの場合.
            if (resultSys.HasError)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();

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
                return;
            }

            // 伝票番号取得（採番）.
            if (long.TryParse(resultSys.dsRepMacDataSet.RepmacGetDenNum[0].DenNum.ToString(), out lngDenNum))
            { lngDenNum = lngDenNum - 1; }
            else
            { lngDenNum = 0; }

            // 伝票上限値取得.
            if (!long.TryParse(resultSys.dsRepMacDataSet.RepmacGetDenNum[0].DenNumMax.ToString(), out lngDenNumMax))
            { lngDenNumMax = 9999999; }

            this.CheckArguments(out reflg, out  strYyyyMm, out territory, out splitflg);

            //実行.
            RepDsMac jyuListdt = new RepDsMac();
            ReportMacProcessController.FindReportMacPurchaseByCondParam prmPur
                    = new ReportMacProcessController.FindReportMacPurchaseByCondParam();
            // パラメータ生成.
            prmPur.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            prmPur.egCd = _naviParam.strEgcd;
            prmPur.tksKgyCd = _naviParam.strTksKgyCd;
            prmPur.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            prmPur.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            prmPur.yymm = strYyyyMm;
            prmPur.splitflg = splitflg;
            prmPur.reflg = reflg;
            prmPur.territory = territory;
            prmPur.tenpoCd = this.txtTenpoCd.Text;
            prmPur.denFr = strdnpfr;
            prmPur.denTo = strdnpto;

            FindReportMacPurchaseByCondServiceResult resultPucrhase = processController.FindRepMacPurchaseByCond(prmPur);

            //エラーの場合.
            if (resultPucrhase.HasError)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();

                return;
            }

            //データが存在しなければ終了.
            if (resultPucrhase.dsRepMacDataSet.RepmacPurchase.Rows.Count.Equals(0))
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();

                // 初期化.
                this.Initialize();
                //MessageBox.Show("該当のデータは存在しません。"
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);
                return;
            }

            this.UpdateDgvMainData(resultPucrhase.dsRepMacDataSet.RepmacPurchase,
                                    resultSys.dsRepMacDataSet.RepmacGetDenNum,
                                    strYyyyMm);


            // 出力ボタン有効化.
            //btnXls.Enabled = true;
            if (dgvMain_Sheet1.RowCount > 0)
            {
                btnXls.Enabled = true;
            }
            else
            {
                btnXls.Enabled = false;
            }

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
            // 担当者名.
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
            maxupdate = DateTime.Parse("1000/01/01 01:01:01");
            btnXls.Enabled = false;       //エクセルボタン.
            statusStrip1.Items["tslval1"].Text = "0件";        //表示件数.
        }

        /// <summary>
        /// 画面内パラメータチェック.
        /// </summary>
        private void CheckArguments(out string reflg,
                                    out string strYymm,
                                    out string territory,
                                    out string splitflg)
        {

            //テリトリー.
            territory = string.Empty;
            //明細行フラグ.
            splitflg = string.Empty;

            // 年月.
            if (!chkRePrint.Checked)
            {
                reflg = "0";
                strYymm = txtYm.Value;
            }
            else
            {
                reflg = "1";
                strYymm = txtYmRe.Value;
            }

            // 明細行フラグ（明細テーブルでの実値を格納）.
            if (chkSplit.Checked)
            {
                splitflg = "2";
            }
            if (chkNoSplit.Checked)
            {
                splitflg = "1";
            }

            // テリトリー（実値を格納）.
            if (chkKanto.Checked)
            {
                territory = "'1'";
            }
            if (chkKansai.Checked)
            {
                if (!string.IsNullOrEmpty(territory))
                {
                    territory = territory + ",";
                }
                territory = territory + "'2'";
            }
            if (chkCenter.Checked)
            {
                if (!string.IsNullOrEmpty(territory))
                {
                    territory = territory + ",";
                }
                territory = territory + "'3'";
            }
            if (chkOther.Checked)
            {
                if (!string.IsNullOrEmpty(territory))
                {
                    territory = territory + ",";
                }
                territory = territory + "'4'";
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
                File.WriteAllBytes(macroFile, Isid.KKH.Mac.Properties.Resources.Mac_Purchase_Mcr);
                File.WriteAllBytes(templFile, Isid.KKH.Mac.Properties.Resources.Mac_Purchase_Template);

                if (System.IO.File.Exists(templFile) == false)
                {
                    throw new Exception("テンプレートExcelファイルがありません。");
                }
                if (System.IO.File.Exists(macroFile) == false)
                {
                    throw new Exception("マクロExcelファイルがありません。");
                }

                // データセットXML出力.
                OutPurchaseDs.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));

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
                dtRow["SELHDK"] = txtYm.Year + "年" + txtYm.Month + "月";
                dtRow["KAMOKUCD"] = pStrRepComTaxKamoku;
                dtRow["COMPANYNM"] = pStrRepComNm;
                dtRow["PRINTERNM"] = pStrRepPrinterNm;
                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //エクセル起動.
                System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME);

                //削除用に保持（戻るボタン押下時に削除する為）.
                _strmacrodel = workFolderPath + REP_MACRO_FILENAME;

                //ログの出力.
                KKHLogUtilityMac.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityMac.KINO_ID_OPERATION_LOG_Purchase, KKHLogUtilityMac.DESC_OPERATION_LOG_Purchase);
            }
            catch (Exception ex)
            {
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
            //日付とか.
            DateTime now = DateTime.Now;
            //はじめのファイル名を指定する.
            if (dgvMain_Sheet1.RowCount > 0)
            {
                // 再印刷ではない時のみ、更新する意思の確認を行う.
                if (!chkRePrint.Checked)
                {
                    if (MessageUtility.ShowMessageBox(MessageCode.HB_C0001
                        , new string[] { System.Environment.NewLine }
                    , "帳票"
                        , MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        //選択状態を解除.
                        this.ActiveControl = null;
                        return;
                    }
                }

                if (chkRePrint.Checked)
                {
                    sfd.FileName = pStrRepFilNam + "_" + now.ToString("yyyyMMdd") + "（再）.xlsm";
                    //sfd.FileName = now.ToString("yyyyMMdd") + pStrRepFilNam + "（再）.xlsm";
                }
                else
                {
                    sfd.FileName = pStrRepFilNam + "_" + now.ToString("yyyyMMdd") + ".xlsm";
                    //sfd.FileName = now.ToString("yyyyMMdd") + pStrRepFilNam + ".xlsx";
                    //sfd.FileName = now.ToString("yyyyMMdd") + pStrRepFilNam + ".xlsm";
                }

                //はじめに表示されるフォルダを指定する.
                sfd.InitialDirectory = pStrRepAdrs;
                //[ファイルの種類]に表示される選択肢を指定する.
                //sfd.Filter =
                //    "XLSXファイル(*.xlsx)|*.xlsx";
                sfd.Filter = "XLSMファイル(*.xlsm)|*.xlsm";
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

                    if (dgvMain_Sheet1.RowCount > 0)
                    {

                        //*************************************.
                        // 出力実行.
                        //*************************************.
                        this.ExcelOut(sfd.FileName);
                    }

                    // 再印刷ではない時、採番の更新を行う。.
                    if (!chkRePrint.Checked)
                    {
                        ReportMacProcessController processController
                            = ReportMacProcessController.GetInstance();
                        // パラメータ.
                        ReportMacProcessController.UpdateReportMacPurParam prmUpd
                            = new ReportMacProcessController.UpdateReportMacPurParam();
                        prmUpd.aplId = AplId;
                        prmUpd.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
                        prmUpd.egCd = _naviParam.strEgcd;
                        prmUpd.tksKgyCd = _naviParam.strTksKgyCd;
                        prmUpd.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                        prmUpd.tksTntSeqNo = _naviParam.strTksTntSeqNo;
                        prmUpd.DenNum = String.Format("{0:0000000}", int.Parse((lngDenNum + 1).ToString()));
                        prmUpd.hostDate = getHostDate();
                        prmUpd.DataVO = updTbl;
                        prmUpd.maxUpDate = maxupdate;

                        UpdateReportMacPurServiceResult result
                            = processController.UpdateReportMacPur(prmUpd);
                    }

                    if (dgvMain_Sheet1.RowCount == 0)
                    {

                        MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);
                        this.Initialize();

                        //選択状態を解除.
                        this.ActiveControl = null;
                        return;
                    }

                    this.Initialize();
                }
            }

            //選択状態を解除.
            this.ActiveControl = null;

            sfd.Dispose();
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

        #endregion
    }
}