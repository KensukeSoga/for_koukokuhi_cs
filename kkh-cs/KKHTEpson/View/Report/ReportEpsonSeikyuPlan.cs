using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using FarPoint.Win.Spread;

using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Epson.ProcessController.Report;
using Isid.KKH.Epson.Properties;
using Isid.KKH.Epson.Utility;

namespace Isid.KKH.Epson.View.Report
{
    /// <summary>
    /// 請求予定一覧出力画面（エプソン） 
    /// </summary>
    public partial class ReportEpsonSeikyuPlan : KKHForm
    {
        #region 定数 

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "RepSPEps";

        /// <summary>
        /// 帳票出力＿ファイル拡張子 
        /// </summary>
        private const string SFD_EXT = ".xls";
        /// <summary>
        /// 帳票出力＿起動ディレクトリ 
        /// </summary>
        private const string SFD_INITDIR = @"C:\";
        /// <summary>
        /// 帳票出力＿起動ディレクトリ(テンプレート）
        /// </summary>
        private const string SFD_INITDIRTMP = @"C:\Temp\";
        /// <summary>
        /// 帳票出力＿フィルタ 
        /// </summary>
        private const string SFD_FILTER = "XLSファイル(*.xls)|*.xls";
        /// <summary>
        /// 帳票出力＿タイトル 
        /// </summary>
        private const string SFD_TITLE = "保存先のファイルを設定して下さい。";

        /// <summary>
        /// XMLファイル名（データ用） 
        /// </summary>
        private const string REP_XML_FILENAME = "Epson_SeikyuPlan_Data.xml";
        /// <summary>
        /// XMLファイル名（プロパティ用） 
        /// </summary>
        private const string REP_XML2_FILENAME = "Epson_SeikyuPlan_Prop.xml";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名 
        /// </summary>
        private const string REP_TEMPLATE_FILENAME = "Epson_SeikyuPlanTemplate.xlsx";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名 
        /// </summary>
        private const string REP_MACRO_FILENAME = "Epson_SeikyuPlanMcr.xlsm";

        /// <summary>
        /// 帳票設定情報取得キー：保存場所：002 
        /// </summary>
        private const string KV7_SYBT = "002";
        /// <summary>
        /// 帳票設定情報取得キー：保存場所：ED-I0001 
        /// </summary>
        private const string KV7_SYBTFIELD1_ED = "ED-I0001";

        /// <summary>
        /// 帳票設定情報取得キー：出力帳票名：003 
        /// </summary>
        private const string KV7_SYBTSUB = "003";
        /// <summary>
        /// 帳票設定情報取得キー：出力帳票名：002 
        /// </summary>
        private const string KV7_SYBTFIELD1_002= "002";

        #endregion 定数 
      
        #region メンバ変数 

        /// <summary>
        /// ナビパラメータ 
        /// </summary>
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();

        /// <summary>
        /// コピーマクロ削除用 
        /// </summary>
        private string _strmacrodel;

        #endregion メンバ変数 

        #region コンストラクタ 

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public ReportEpsonSeikyuPlan()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ 

        #region イベント 

        /// <summary>
        /// 画面遷移するたびに発生します。 
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void ReportEpsonSeikyuPlan_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParameter = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// フォームロードイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportEpsonSeikyuPlan_Load(object sender, EventArgs e)
        {
            this.InitializeControl();
        }

        /// <summary>
        /// ボタンMouseMoveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_MouseMove(object sender, MouseEventArgs e)
        {
            tslCnt.Text = njToolTip1.GetToolTip((Control)sender);
        }

        /// <summary>
        /// ボタンMouseLeaveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_MouseLeave(object sender, EventArgs e)
        {
            tslCnt.Text = String.Empty;
        }

        /// <summary>
        /// 表示ボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            //ローディング表示開始 
            base.ShowLoadingDialog();
            
            // データ検索 
            if (0 < this.FindReportData())
            {
                btnXls.Enabled = true;
                statusStrip1.Items["tslval1"].Text = _spdReport_Sheet1.Rows.Count.ToString() + "件";
            }
            else
            {
                //ローディング表示終了 
                base.CloseLoadingDialog();

                btnXls.Enabled = false;
                statusStrip1.Items["tslval1"].Text = "0件";
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);
            }

            //選択状態を解除 
            this.ActiveControl = null;

            //ローディング表示終了 
            base.CloseLoadingDialog();

        }

        /// <summary>
        /// Excelボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            // 帳票設定情報取得 (テンプレート保存場所、パスワード等）
            Common.KKHSchema.Common.SystemCommonRow repInfo = this.GetReportInfo(KV7_SYBT, KV7_SYBTFIELD1_ED);
            // 帳票設定情報取得（ファイル初期保存場所）
            Common.KKHSchema.Common.SystemCommonRow repInfoSub = this.GetReportInfo(KV7_SYBTSUB, KV7_SYBTFIELD1_002);

            // SaveFileDialogクラスのインスタンスを作成 
            SaveFileDialog sfd = new SaveFileDialog();

            // はじめのファイル名を指定する 
            sfd.FileName = repInfoSub.field3 + DateTime.Now.ToString("yyyyMMdd") + SFD_EXT;

            // はじめに表示されるフォルダを指定する 
            sfd.InitialDirectory = repInfoSub.field2;

            // [ファイルの種類]に表示される選択肢を指定する 
            sfd.Filter = SFD_FILTER;

            // [ファイルの種類]ではじめに 
            // 「すべてのファイル」が選択されているようにする 
            sfd.FilterIndex = 0;

            // タイトルを設定する 
            sfd.Title = SFD_TITLE;

            // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする 
            sfd.RestoreDirectory = true;

            // ダイアログを表示する 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //出力先に同名のExcelファイルが開いているかチェック 
                try
                {
                    //同名でファイルを削除する。 
                    File.Delete(sfd.FileName);
                }
                catch (IOException)
                {
                    //出力先に同名のExcelファイルが開いています。閉じてから再度出力してください。 
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "帳票", MessageBoxButtons.OK);

                    //選択状態を解除 
                    this.ActiveControl = null;

                    return;
                }

                //*************************************
                // 出力実行 
                //*************************************
                this.ExcelOut(sfd.FileName, repInfo);
            }

            //選択状態を解除 
            this.ActiveControl = null;

            sfd.Dispose();
        }

        /// <summary>
        /// ヘルプボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //得意先コード 
            string tkskgy = _naviParameter.strTksKgyCd + _naviParameter.strTksBmnSeqNo + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Report, this, HelpNavigator.KeywordIndex);
            this.ActiveControl = null;
        }

        /// <summary>
        /// 戻るボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (_strmacrodel != null)
            {
                FileInfo cFileInfo = new FileInfo(_strmacrodel);

                // マクロファイルの削除（VBA側では削除できない為） 
                // ファイルが存在しているか判断する 
                if (cFileInfo.Exists)
                {
                    // 読み取り専用属性がある場合は、読み取り専用属性を解除する 
                    if ((cFileInfo.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        cFileInfo.Attributes = FileAttributes.Normal;
                    }

                    // ファイルを削除する 
                    cFileInfo.Delete();
                }
            }

            Navigator.Backward(this, null, _naviParameter, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtYm_Enter(object sender, EventArgs e)
        {
            btnXls.Enabled = false;
        }
        #endregion イベント 

        #region メソッド 

        /// <summary>
        /// 各コントロールの初期設定 
        /// </summary>
        private void InitializeControl()
        {
            string yyyymm = _naviParameter.strDate.Replace("/", string.Empty);

            // 年月テキストボックス 
            txtYm.Value = yyyymm.Substring(0, 6);
            txtYm.cmbYM_SetDate();

            // ステータス設定 
            tslName.Text = _naviParameter.strName;
            tslDate.Text = _naviParameter.strDate;
        }

        /// <summary>
        /// データ検索・表示メソッド 
        /// </summary>
        /// <returns>検索結果件数</returns> 
        private int FindReportData()
        {
            ReportEpsonProcessController.FindReportEpsonSeikyuPlanByCondParam param =
                new ReportEpsonProcessController.FindReportEpsonSeikyuPlanByCondParam();

            // パラメータ設定 
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = txtYm.Value;

            // 帳票（エプソン_請求予定一覧）データ検索 
            ReportEpsonProcessController processController = ReportEpsonProcessController.GetInstance();
            FindReportEpsonSeikyuPlanByCondServiceResult result = processController.FindReportEpsonSeikyuPlanByCond(param);

            if (result.HasError == true)
            {
                return 0;
            }

            _dsReport.ReportSeikyuPlan.Clear();
            _dsReport.ReportSeikyuPlan.Merge(result.ReportDataSet.ReportSeikyuPlan);
            _dsReport.ReportSeikyuPlan.AcceptChanges();

            if (result.ReportDataSet.ReportSeikyuPlan.Rows.Count == 0)
            {
                // データが存在しない場合は0を返す 
                return 0;
            }

            return result.ReportDataSet.ReportSeikyuPlan.Rows.Count;
        }

        /// <summary>
        /// Excel出力メソッド 
        /// </summary>
        /// <param name="filnm">ファイル</param>
        /// <param name="repInfo">帳票出力設定情報</param>
        private void ExcelOut(string filnm, Common.KKHSchema.Common.SystemCommonRow repInfo)
        {
            string workFolderPath = repInfo.field2;
            string excelFile = string.Empty;
            string macroFile = workFolderPath + REP_MACRO_FILENAME;
            string templFile = workFolderPath + REP_TEMPLATE_FILENAME;
            DataRow dtRow;

            try
            {
                // Excel開始処理 
                // リソースからExcelファイルを作成(テンプレートとマクロ) 
                File.WriteAllBytes(templFile, Resources.Epson_SeikyuPlanTemplate);
                File.WriteAllBytes(macroFile, Resources.Epson_SeikyuPlanMcr);

                if (File.Exists(templFile) == false)
                {
                    throw new Exception("テンプレートExcelファイルがありません。");
                }
                if (File.Exists(macroFile) == false)
                {
                    throw new Exception("マクロExcelファイルがありません。");
                }

                // データセットXML出力 
                _dsReport.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));

                // パラメータXML作成、出力 
                // 変数の宣言
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // データセットにテーブルを追加する 
                // PRODUCTSというテーブルを作成します 
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                dtTable.Columns.Add("YYYYMM", Type.GetType("System.String"));

                //テーブルにデータを追加する 
                dtRow = dtTable.NewRow();

                dtRow["SAVEDIR"] = filnm;       // 保存ファイル名（フルパス） 
                dtRow["YYYYMM"] = txtYm.Value;      // 年月 

                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //エクセル起動 
                System.Diagnostics.Process.Start("excel", macroFile);

                //削除用に保持（戻るボタン押下時に削除する為） 
                _strmacrodel = macroFile;

                // オペレーションログの出力.
                KKHLogUtilityEpson.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityEpson.KINO_ID_OPERATION_LOG_REPORT_SEIKYU_PLAN, KKHLogUtilityEpson.DESC_OPERATION_LOG_REPORT_SEIKYU_PLAN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 帳票出力設定情報取得メソッド 
        /// </summary>
        /// <returns>帳票出力設定情報</returns>
        private Common.KKHSchema.Common.SystemCommonRow GetReportInfo(string sybt, string field1)
        {
            string strsybt = sybt;//種別:"002"or"003"
            string strfield1 = field1;//種別:"ED-I0001"or"002"
            Common.KKHSchema.Common.SystemCommonRow ret;
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult;

            // 帳票設定情報取得 
            comResult = commonProcessController.FindCommonByCond(_naviParameter.strEsqId,
                                                                _naviParameter.strEgcd,
                                                                _naviParameter.strTksKgyCd,
                                                                _naviParameter.strTksBmnSeqNo,
                                                                _naviParameter.strTksTntSeqNo,
                                                                strsybt,
                                                                strfield1);

            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                ret = comResult.CommonDataSet.SystemCommon[0];
            }
            else
            {
                // 取得できなかった場合はデフォルト値を設定 
                Common.KKHSchema.Common.SystemCommonDataTable dt =
                    new Common.KKHSchema.Common.SystemCommonDataTable();
                ret = (Common.KKHSchema.Common.SystemCommonRow)dt.NewRow();

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ret[i] = string.Empty;
                }
            }

            return ret;
        }

        #endregion メソッド 

    }
}