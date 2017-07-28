using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Data;
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
using Isid.KKH.Common.KKHProcessController.Report;
using Isid.KKH.Mac.ProcessController.Report;
using Isid.KKH.Mac.Schema;
using Isid.KKH.Mac.Utility;

namespace Isid.KKH.Mac.View.Report
{
    public partial class ReportMacLicensee : KKHForm
    {
        #region 定数.

        /// <summary>
        /// アプリID
        /// </summary>
        private static readonly string APLID = "Licensee";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME ="Mac_Licensee.xlsm";
        /// <summary>
        /// Excel(帳票出力マクロテンプレート)ファイル名.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "Mac_Licensee_Template.xlsx";
        /// <summary>
        /// XMLファイル名1
        /// </summary>
        private static readonly string REP_XML_FILENAME = "Mac_Licensee_Data.xml";
        /// <summary>
        /// XMLファイル名2
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "Mac_Licensee_Prop.xml";

        #endregion 定数.

        #region メンバ変数.

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
        /// ナビパラメーター.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// XML作成用データセット.
        /// </summary>
        private DataSet MacLicenseeDs = new DataSet();
        /// <summary>
        /// コピーマクロ削除用string
        /// </summary>
        private string _strmacrodel;
        /// <summary>
        /// 消費税.
        /// </summary>
        private double _dbSyohizei;

        #endregion メンバ変数.

        #region コンストラクタ.

        public ReportMacLicensee()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ.

        #region イベント.

        /// <summary>
        /// 画面遷移時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportMacLicensee_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
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
        private void ReportMacLicensee_Shown(object sender, EventArgs e)
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            //各コントロール初期化.
            InitializeControl();

            //各コントロールの編集.
            EditControl();

            //****************************
            //消費税取得.
            //****************************
            //消費税取得（マスタから）
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
                                                                                            "005");

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
        /// 検索ボタンClickイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, System.EventArgs e)
        {
            btnXls.Enabled = false;
            GetRecord();
        }

        /// <summary>
        /// Excelボタンクリック時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, System.EventArgs e)
        {
            XlsFileSet();
        }

        /// <summary>
        /// 戻るボタンクリック時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, System.EventArgs e)
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtYm_Enter(object sender, EventArgs e)
        {
            //帳票出力を非活性化にする,
            btnXls.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDnpFr_TextChanged(object sender, EventArgs e)
        {
            //帳票出力を非活性化にする,
            btnXls.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDnpTo_TextChanged(object sender, EventArgs e)
        {
            //帳票出力を非活性化にする,
            btnXls.Enabled = false;
        }

        #endregion イベント.

        #region メソッド.

        /// <summary>
        /// 営業日を取得.
        /// </summary>
        /// <returns></returns>
        private string getHostDate()
        {
            string hostDate = "";

            CommonProcessController processController = CommonProcessController.GetInstance();
            hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return hostDate;
        }

        /// <summary>
        /// 各コントロール初期化
        /// </summary>
        private void InitializeControl()
        {
            txtYm.Value = string.Empty;  //年月.
            btnXls.Enabled = false;       //エクセルボタン.
            txtDnpFr.Text = string.Empty; //伝票番号From
            txtDnpTo.Text = string.Empty; //伝票番号To
            statusStrip1.Items["tslval1"].Text = "0" + "件";          //表示件数.
            dgvMain_Sheet1.Columns[12].Visible = false; //分割コードの非表示.
            dgvMain_Sheet1.Columns[13].Visible = false;//住所２の非表示.
        }

        /// <summary>
        /// 各コントロールの編集.
        /// </summary>
        private void EditControl()
        {
            //年月の取得.
            string strDate = getHostDate();
            //ステータスの設定.
            //txtYm.Value = strDate.Substring(0, 6);
            //tslName.Text = KKHSecurityInfo.GetInstance().UserName;
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;
            if (strDate != "")
            {
                strDate = strDate.Trim().Replace("/", "");
                if (strDate.Trim().Length >= 6)
                {
                    txtYm.Value = strDate.Substring(0, 6);
                }
                else
                {
                    txtYm.Value = strDate;
                }

                txtYm.cmbYM_SetDate();
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
            string yearmon = string.Empty;

            //伝票番号From
            string dnpfr = txtDnpFr.Text;

            //伝票番号To
            string dnpTo = txtDnpTo.Text;

            //年月のセット.
            yearmon = txtYm.Value;

            //パラメーターのセット.
            ReportMacProcessController.FindReportMacLicenseeByCondParam param = new ReportMacProcessController.FindReportMacLicenseeByCondParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = yearmon;
            param.denFr = dnpfr;
            param.denTo = dnpTo;

            ReportMacProcessController processController = ReportMacProcessController.GetInstance();
            FindReportMacLicenseeByCondServiceResult result = processController.FindRepMacLicenseeByCond(param);

            //エラーの場合.
            if (result.HasError)
            {
                //選択状態を解除.
                this.ActiveControl = null;

                //ローディング表示終了.
                base.CloseLoadingDialog();

                return;
            }
            //MacLicenseeDs = result.dsRepMacDataSet;
            Isid.KKH.Mac.Schema.RepDsMac.RepLicenseeRow[] datarow = (Isid.KKH.Mac.Schema.RepDsMac.RepLicenseeRow[])result.dsRepMacDataSet.RepLicensee.Select("", "");

            if (datarow.Length == 0)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                MessageUtility.ShowMessageBox(MessageCode.HB_W0030, null, "帳票", MessageBoxButtons.OK);
                //表示件数
                statusStrip1.Items["tslval1"].Text = datarow.Length.ToString() + "件";
                dgvMain_Sheet1.DataSource = null;
                dgvMain_Sheet1.Rows.Count = 0;

                //選択状態を解除.
                this.ActiveControl = null;

                return;
            }

            //dgvMainデータ更新.
            UpdateDgvMainData(datarow);

            // 2014/02/05 add JSE K.Tamura start
            // データソースのせいで、消費税率が表示されてしまうので、非表示にする.
            dgvMain_Sheet1.Columns[14].Visible = false;
            // 2014/02/05 add JSE K.Tamura end

            //表示件数.
            statusStrip1.Items["tslval1"].Text = datarow.Length.ToString() + "件";

            //帳票出力ボタン活性化.
            btnXls.Enabled = true;

            //選択状態を解除.
            this.ActiveControl = null;

            //ローディング表示終了.
            base.CloseLoadingDialog();
        }

        /// <summary>
        /// dgvMainデータ更新.
        /// </summary>
        /// <param name="datarow"></param>
        private void UpdateDgvMainData(Isid.KKH.Mac.Schema.RepDsMac.RepLicenseeRow[] datarow)
        {
           //表示用データテーブル.
           //Isid.KKH.Common.KKHSchema.RepDsMac.dgvLicenseeDataTable  rldt = new Isid.KKH.Common.KKHSchema.RepDsMac.dgvLicenseeDataTable();
            RepDsMac rldt = new RepDsMac();

            foreach (RepDsMac.RepLicenseeRow row in datarow)
            {
                //表示用データRow
                //Isid.KKH.Common.KKHSchema.RepDsMac.dgvLicenseeRow addrow = rldt.NewdgvLicenseeRow();
                RepDsMac.dgvLicenseeRow addrow = rldt.dgvLicensee.NewdgvLicenseeRow();
                //取引先コード.
                addrow.toriCd = row.field12;
                //ライセンシー社名.
                addrow.licenseeSyaName = row.field10;
                //店舗コード.
                addrow.tenCd = row.code1;
                //店舗名.
                addrow.tenName = row.name3;
                //売上明細No.
                addrow.uriMeiNo = row.jyutNo + "-" + row.jymeiNo + "-" + row.urMeiNo;
                //住所.
                addrow.adress = row.field4 + " " + row.field20;
                //addrow.adress = row.field4 + " " + row.field5;
                //住所２.
                addrow.adress2 = row.field6;
                //件名１ + 件名２.
                addrow.kenName = row.name1 + row.name2;
                //件名.
                //addrow.kenName = row.name1;
                //代表者名.
                addrow.representName = row.field11;
                //数量.
                addrow.suRyo = double.Parse(row.kngk2).ToString("###,###,###,##0");
                //addrow.suRyo = row.kngk2;

                //分割ーコードが１の場合.
                if (row.sonota2 == "1")
                {
                    //単価を表示しない.
                    addrow.tanka = "";
                }
                else
                {
                    //100万以上の場合.
                    if (Isid.KKH.Common.KKHUtility.KKHUtility.IntParse(row.kngk1) >= 1000000)
                    {
                        //単価を表示しない.
                        addrow.tanka = "";
                    }
                    else
                    {
                        //単価.
                        addrow.tanka = row.kngk1;
                    }
                }
                //金額(小数第1位で四捨五入).
                addrow.kngk = Math.Round(decimal.Parse(row.seiGak),0,MidpointRounding.AwayFromZero).ToString("###,###,###,##0");
                //addrow.kngk = row.seiGak;
                //伝票番号.
                addrow.denpyoNum = row.sonota1;
                //分割コード.
                addrow.bunCd = row.sonota2;
                //件名２.
                //rldt.AdddgvLicenseeRow(addrow);
                rldt.dgvLicensee.AdddgvLicenseeRow(addrow);

                //消費税対応 2013/10/29 add HLC H.Watabe start
                addrow.Ritu1 = row.Ritu1;
                //消費税対応 2013/10/29 add HLC H.Watabe end
            }

            MacLicenseeDs = rldt;
            dgvMain_Sheet1.DataSource = rldt.dgvLicensee;
        }

        /// <summary>
        /// エクセル出力のファイル設定.
        /// </summary>
        private void XlsFileSet()
        {
            //ファイル保存場所設定クラスのインスタンス化.
            SaveFileDialog sfd = new SaveFileDialog();
            //現在日時.
            DateTime nowdate = DateTime.Now;
            //初期ファイル名.
            sfd.FileName =  pStrRepFilNam + "_" + nowdate.ToString("yyyyMMdd") + ".xlsx";
            //sfd.FileName = nowdate.ToString("yyyyMMdd") + pStrRepFilNam + ".xlsx";
            //初期ファイル保存先.
            sfd.InitialDirectory = pStrRepAdrs;
            //ファイル種類の選択肢を設定.
            sfd.Filter = "XLSXファイル(*.xlsx)|*.xlsx";
            //初期ファイル種類の設定.
            //[すべてのファイル]を設定.
            sfd.FilterIndex = 0;
            //タイトルの設定.
            sfd.Title = "保存先のファイルを設定して下さい。";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする.
            sfd.RestoreDirectory = true;

            //ダイアログを表示し、Okボタンが押下されたら.
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
                    //選択状態を解除.
                    this.ActiveControl = null;

                    //出力先に同名のExcelファイルが開いています。閉じてから再度出力してください。.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "帳票", MessageBoxButtons.OK);
                    return;
                }

                //*************************************
                // 出力実行.
                //*************************************
                this.ExcelOut(sfd.FileName);
            }

            //選択状態を解除.
            this.ActiveControl = null;

            //リソースの解放.
            sfd.Dispose();
        }

        /// <summary>
        /// エクセル出力.
        /// </summary>
        /// <param name="filenm"></param>
        private void ExcelOut(string filenm)
        {
            //作業用フォルダパス.
            string workFolderPath = pStrRepTempAdrs;
            string macrofile = workFolderPath + REP_MACRO_FILENAME;
            string tempfile = workFolderPath + REP_TEMPLATE_FILENAME;
            //テーブル追加用データRow
            DataRow dtRow;
            try
            {
                // Excel開始処理.
                // リソースからExcelファイルを作成(テンプレートとマクロ).
                File.WriteAllBytes(macrofile, Isid.KKH.Mac.Properties.Resources.Mac_Licensee);
                File.WriteAllBytes(tempfile, Isid.KKH.Mac.Properties.Resources.Mac_Licensee_Template);

                if (System.IO.File.Exists(tempfile) == false) { throw new Exception("テンプレートExcelファイルがありません。"); }
                if (System.IO.File.Exists(macrofile) == false) { throw new Exception("マクロExcelファイルがありません。"); }

                //データセットXML出力.
                MacLicenseeDs.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));

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

                //テーブルにデータを追加する.
                dtRow = dtTable.NewRow();

                dtRow["SAVEDIR"] = filenm;
                dtRow["SYOHIZEI"] = _dbSyohizei.ToString();
                dtRow["USERNAME"] = tslName.Text;
                dtRow["SELHDK"] = txtYm.Year + "年" + txtYm.Month + "月";
                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //エクセル起動.
                System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME);

                //削除用に保持（戻るボタン押下時に削除する為）.
                _strmacrodel = workFolderPath + REP_MACRO_FILENAME;

                //ログの出力.
                KKHLogUtilityMac.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityMac.KINO_ID_OPERATION_LOG_Licensee, KKHLogUtilityMac.DESC_OPERATION_LOG_Licensee);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion メソッド
    }
}

