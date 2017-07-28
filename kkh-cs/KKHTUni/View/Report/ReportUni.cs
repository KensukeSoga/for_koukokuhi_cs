using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using Isid.KKH.Uni.Utility;
using Isid.NJ.View.Widget;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Uni.ProcessController.Report;
using Isid.KKH.Uni.Properties;
using Isid.KKH.Uni.View.Detail;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;

namespace Isid.KKH.Uni.View.Report
{
    /// <summary>
    /// 帳票出力画面（ユニチャーム） 
    /// </summary>
    public partial class ReportUni : KKHForm
    {
        #region 定数 

        /// <summary>
        /// 請求原票No列インデックス 
        /// </summary>
        private const int COLIDX_GPYNO = 0;
        /// <summary>
        /// 金額列インデックス 
        /// </summary>
        private const int COLIDX_KNGK = 15;
        /// <summary>
        /// 金額（受注ダウンロードデータ）列インデックス 
        /// </summary>
        private const int COLIDX_KNGKJ = 17;

        /// <summary>
        /// 帳票出力＿ファイル拡張子 
        /// </summary>
        private const string SFD_EXT = ".xlsx";
        /// <summary>
        /// 帳票出力＿ファイル拡張子(マクロあり) 
        /// </summary>
        private const string SFD_EXTM = ".xlsm";
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
        private const string SFD_FILTER = "XLSX、XLSMファイル(*.xlsx;*.xlsm)|*.xlsx;*.xlsm";
        /// <summary>
        /// 帳票出力＿タイトル 
        /// </summary>
        private const string SFD_TITLE = "保存先のファイルを設定して下さい。";

        /// <summary>
        /// XMLファイル名（データ用） 
        /// </summary>
        private const string REP_XML_FILENAME = "Uni_Data.xml";
        /// <summary>
        /// XMLファイル名（プロパティ用） 
        /// </summary>
        private const string REP_XML2_FILENAME = "Uni_Prop.xml";

        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名 
        /// </summary>
        private const string REP_TEMPLATE_FILENAME = "Uni_Template.xlsx";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名（マクロ有り） 
        /// </summary>
        private const string REP_TEMPLATE_FILENAMEM = "Uni_Template.xlsm";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名 
        /// </summary>
        private const string REP_MACRO_FILENAME = "Uni_Mcr.xlsm";

        /// <summary>
        /// 帳票設定情報取得キー：002 
        /// </summary>
        private const string KV7_SYBT = "002";
        /// <summary>
        /// 帳票設定情報取得キー：003 
        /// </summary>
        private const string KV7_SYBTSUB = "003";

        /// <summary>
        /// 帳票パラメータ：保存ファイル名（フルパス） 
        /// </summary>
        private const string PARAM_SAVEDIR = "SAVEDIR";
        /// <summary>
        /// 帳票パラメータ：年月 
        /// </summary>
        private const string PARAM_YYYYMM = "YYYYMM";
        /// <summary>
        /// 帳票パラメータ：シート保護用パスワード 
        /// </summary>
        private const string PARAM_PASSWORD = "PASSWORD";
        /// <summary>
        /// 帳票パラメータ：帳票区分 
        /// </summary>
        private const string PARAM_REPORTKBN = "REPORTKBN";
        /// <summary>
        /// 帳票パラメータ：ユーザー名称 
        /// </summary>
        private const string PARAM_USERNAME = "USERNAME";

        /// <summary>
        /// シート保護用パスワードのデフォルト値 
        /// </summary>
        private const string DEF_PASSWORD = "ks1dms";

        /// <summary>
        /// アラート基準：アラート表示用金額(円)  
        /// </summary>
        private const int ALERTAMOUNT = 6;

        #endregion 定数 

        #region メンバ変数 

        /// <summary>
        /// Rgナビパラメータ 
        /// </summary>
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();

        /// <summary>
        /// コピーマクロ削除用 
        /// </summary>
        private string _strmacrodel;

        /// <summary>
        /// アラート対象フラグ（True = アラート対象あり） 
        /// </summary>
        private Boolean _alertFlg;

        /// <summary>
        /// あぷりID
        /// </summary>
        private  string APLID = string.Empty;
        #endregion メンバ変数 

        #region コンストラクタ 

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public ReportUni()
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
        private void ReportUni_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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
        private void ReportUni_Load(object sender, EventArgs e)
        {
            this.InitializeControl();
        }


        /// <summary>
        /// 帳票ラジオボタンCheckedChangedイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoOutPutNm_CheckedChanged(object sender, EventArgs e)
        {
            btnXls.Enabled = false;
            statusStrip1.Items["tslval1"].Text = string.Empty;

            _dsReportUni.ReportData.Clear();
            _dsReportUni.ReportData.AcceptChanges();

            _dsReportUni.ProofData.Clear();
            _dsReportUni.ProofData.AcceptChanges();            
            
            NJRadioButton rdo = (NJRadioButton)sender;

            if (rdo.Checked)
            {
                // 広告費明細表(暫定) 
                if (rdo.Name.Equals(this.rdoOutPutNmA.Name))
                {
                    // 請求原票Noを非表示 
                    _spdReport_Sheet1.Columns[COLIDX_GPYNO].Visible = false;
                    APLID = "RepZan";
                }
                // 広告費明細表(確定) 
                else
                {
                    // 請求原票Noを表示 
                    _spdReport_Sheet1.Columns[COLIDX_GPYNO].Visible = true;
                    APLID = "RepKak";
                }
            }
        }

        /// <summary>
        /// ボタンMouseMoveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            tslCnt.Text = njToolTip1.GetToolTip((Control)sender);
        }

        /// <summary>
        /// ボタンMouseLeaveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MouseLeave(object sender, EventArgs e)
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
            // アラート対象フラグ（対象なしに設定） 
            _alertFlg = false;

            //ローディング表示開始 
            base.ShowLoadingDialog();

            // データ検索 
            if (0 < this.FindReportData())
            {

                // データが存在した場合、背景色の変更処理を行う 
                for (int iRow = 0; iRow < _spdReport_Sheet1.Rows.Count; iRow++)
                {
                    decimal kngk = KKHUtility.DecParse(_spdReport_Sheet1.Cells[iRow, COLIDX_KNGK].Value.ToString());
                    decimal kngkJ = KKHUtility.DecParse(_spdReport_Sheet1.Cells[iRow, COLIDX_KNGKJ].Value.ToString());
                    decimal sagaku = Math.Abs(kngk - kngkJ);

                    if (sagaku == 0)
                    {
                        // 差額なしの場合 
                        _spdReport_Sheet1.Rows[iRow].BackColor = DetailUni.C_BACK_COLOR_WHITE;
                    }
                    else
                    {
                        if (sagaku >= ALERTAMOUNT)
                        {
                            // 差額がアラート金額を超える場合（セルを赤色にする） 
                            _spdReport_Sheet1.Rows[iRow].BackColor = DetailUni.C_BACK_COLOR_LPINK;

                            // 広告費明細表(確定)が選択されている場合 
                            if (rdoOutPutNmB.Checked)
                            {
                                // アラート対象フラグ（対象ありに設定） 
                                _alertFlg = true;
                            }
                        }
                        else
                        {
                            // 差額がアラート金額以内の場合（セルを黄色にする） 
                            _spdReport_Sheet1.Rows[iRow].BackColor = DetailUni.C_BACK_COLOR_LYELLOW;
                        }
                    }
                }

                btnXls.Enabled = true;
                statusStrip1.Items["tslval1"].Text = _spdReport_Sheet1.Rows.Count.ToString() + "件";

            }
            else
            {
                //ローディング表示終了 
                base.CloseLoadingDialog();

                btnXls.Enabled = false;
                statusStrip1.Items["tslval1"].Text = "0件";
                //MessageBox.Show("該当のデータは存在しません。", "帳票", MessageBoxButtons.OK);
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);
            }

            //選択状態を解除 
            this.ActiveControl = null;

            //ローディング表示終了 
            base.CloseLoadingDialog();

        }

        /// <summary>
        /// 帳票出力ボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            // アラート対象フラグが対象ありの場合は終了 
            if (_alertFlg)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0051
                               , null
                               , "帳票"
                               , MessageBoxButtons.OK);

                //選択状態を解除 
                this.ActiveControl = null;

                return;
            }

            // 帳票設定情報取得 (テンプレート保存場所、パスワード等） 
            Common.KKHSchema.Common.SystemCommonRow repInfo = this.GetReportInfo(KV7_SYBT);
            // 帳票設定情報取得（ファイル初期保存場所） 
            Common.KKHSchema.Common.SystemCommonRow repInfoSub = this.GetReportInfo(KV7_SYBTSUB);

            // SaveFileDialogクラスのインスタンスを作成 
            SaveFileDialog sfd = new SaveFileDialog();

            // はじめのファイル名を指定する 
            if (this.rdoOutPutNmA.Checked)
            {
                if (cmbBusho.Text.Trim() == "")
                {
                    sfd.FileName = repInfoSub.field3 + DateTime.Now.ToString("yyyyMMdd") + SFD_EXT;
                }
                else
                {
                    sfd.FileName = repInfoSub.field3 + "_" + cmbBusho.Text.ToString()
                                                + "_" + DateTime.Now.ToString("yyyyMMdd") + SFD_EXT;
                }
            }
            else
            {
                if (cmbBusho.Text.Trim() == "")
                {
                    sfd.FileName = repInfoSub.field4 + DateTime.Now.ToString("yyyyMMdd") + SFD_EXTM;
                }
                else
                {
                    sfd.FileName = repInfoSub.field4 + "_" + cmbBusho.Text.ToString()
                                                + "_" + DateTime.Now.ToString("yyyyMMdd") + SFD_EXTM;
                }
            }

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
        /// ヘルプボタンクリック処理 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = _naviParameter.strTksKgyCd + _naviParameter.strTksBmnSeqNo + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Report, this, HelpNavigator.KeywordIndex);
            this.ActiveControl = null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void condChg(object sender, EventArgs e)
        {
            //[帳票出力]ボタンを非活性とする 
            btnXls.Enabled = false;
        }

        /// <summary>
        /// 部署コンボボックスのチェンジイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBushoChg(object sender, EventArgs e)
        {
            //[帳票出力]ボタンを非活性とする 
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
            //txtYm.Value = yyyymm.Substring(0, 6);

            // 帳票区分ラジオボタン 
            rdoOutPutNmA.Checked = true;

            // ステータス設定 
            tslName.Text = _naviParameter.strName;
            tslDate.Text = _naviParameter.strDate;

            if (yyyymm != "")
            {
                yyyymm = yyyymm.Trim().Replace("/", "");
                if (yyyymm.Trim().Length >= 6)
                {
                    txtYm.Value = yyyymm.Substring(0, 6);
                }
                else
                {
                    txtYm.Value = yyyymm;
                }
                txtYm.cmbYM_SetDate();
            }

            //***********************************.
            //部署名をコンボボックスにセットする.
            //***********************************.
            SetBushoCmb();
        }

        /// <summary>
        /// 部署名をコンボボックスにセットする.
        /// </summary>
        private void SetBushoCmb()
        {
            MasterMaintenanceProcessController process =
                MasterMaintenanceProcessController.GetInstance();

            FindMasterMaintenanceByCondServiceResult result;

            // 部署名 
            cmbBusho.Items.Clear();
            result = process.FindMasterByCond(_naviParameter.strEsqId,
                                            _naviParameter.strEgcd,
                                            _naviParameter.strTksKgyCd,
                                            _naviParameter.strTksBmnSeqNo,
                                            _naviParameter.strTksTntSeqNo,
                                             DetailUni.C_MST_BUSHO,
                                            null);

            MasterMaintenance.MasterDataVODataTable dtBusho =
                new MasterMaintenance.MasterDataVODataTable();
            MasterMaintenance.MasterDataVORow voRow2 = dtBusho.NewMasterDataVORow();
            dtBusho.AddMasterDataVORow(voRow2);//空行を追加 
            if (result.MasterDataSet.MasterDataVO != null)
            {
                dtBusho.Merge(result.MasterDataSet.MasterDataVO);
            }

            dtBusho.AcceptChanges();

            //コンボボックスのDataSourceにDataTableを割り当てる.
            this.cmbBusho.DataSource = dtBusho;

            //表示される値はDataTableのColumn1列(番組名).
            this.cmbBusho.DisplayMember = dtBusho.Column1Column.ColumnName;
        }

        /// <summary>
        /// データ検索メソッド 
        /// </summary>
        /// <returns>検索結果件数</returns> 
        private int FindReportData()
        {
            ReportUniProcessController.FindReportUniByCondParam param =
                new ReportUniProcessController.FindReportUniByCondParam();

            // パラメータ設定 
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            // 年月 
            param.yymm = txtYm.Value;
            // 部署 
            param.busho = cmbBusho.Text.ToString();

            // 帳票（ユニチャーム_広告費明細表(暫定／確定)）データ検索 
            ReportUniProcessController processController = ReportUniProcessController.GetInstance();
            FindReportUniByCondServiceResult result = processController.FindReportUniByCond(param);

            if (result.HasError == true)
            {
                return 0;
            }

            _dsReportUni.ReportData.Clear();
            _dsReportUni.ReportData.Merge(result.ReportDataSet.ReportData);
            _dsReportUni.ReportData.AcceptChanges();

            _dsReportUni.ProofData.Clear();
            _dsReportUni.ProofData.Merge(result.ReportDataSet.ProofData);
            _dsReportUni.ProofData.AcceptChanges();

            if (result.ReportDataSet.ReportData.Rows.Count == 0)
            {
                // データが存在しない場合は0を返す 
                return 0;
            }

            return result.ReportDataSet.ReportData.Rows.Count;
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
            string templFile = string.Empty;
            string reportKbn = string.Empty;
            DataRow dtRow;

            try
            {
                // Excel開始処理 
                if (this.rdoOutPutNmA.Checked)
                {
                    // リソースからExcelファイルを作成(テンプレート) 
                    reportKbn = "0";
                    templFile = workFolderPath + REP_TEMPLATE_FILENAME;
                    File.WriteAllBytes(templFile, Resources.Uni_Template);
                }
                else
                {
                    // リソースからExcelファイルを作成(テンプレート) 
                    reportKbn = "1";
                    templFile = workFolderPath + REP_TEMPLATE_FILENAMEM;
                    File.WriteAllBytes(templFile, Resources.Uni_TemplateM);
                }

                // リソースからExcelファイルを作成(マクロ) 
                File.WriteAllBytes(macroFile, Resources.Uni_Mcr);
                if (File.Exists(templFile) == false)
                {
                    throw new Exception("テンプレートExcelファイルがありません。");
                }
                if (File.Exists(macroFile) == false)
                {
                    throw new Exception("マクロExcelファイルがありません。");
                }

                // データセットXML出力 
                _dsReportUni.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));

                // パラメータXML作成、出力 
                // 変数の宣言 
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // データセットにテーブルを追加する 
                // PRODUCTSというテーブルを作成します 
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add(PARAM_SAVEDIR, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_YYYYMM, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_PASSWORD, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_USERNAME, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_REPORTKBN, Type.GetType("System.String"));

                //テーブルにデータを追加する 
                dtRow = dtTable.NewRow();

                dtRow[PARAM_SAVEDIR] = filnm;               // 保存ファイル名（フルパス） 
                dtRow[PARAM_YYYYMM] =  txtYm.Value;              // 年月 
                dtRow[PARAM_PASSWORD] = repInfo.field3;     // シート保護用パスワード 
                dtRow[PARAM_USERNAME] = tslName;            // ユーザー名称 
                //dtRow[PARAM_USERNAME] = repInfo.field7;     // ユーザー名称 
                dtRow[PARAM_REPORTKBN] = reportKbn;         // 帳票区分 

                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //エクセル起動 
                System.Diagnostics.Process.Start("excel", macroFile);

                //削除用に保持（戻るボタン押下時に削除する為） 
                _strmacrodel = macroFile;


                // オペレーションログの出力 
                if (rdoOutPutNmA.Checked)
                {
                    //暫定 
                    KKHLogUtilityUni.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityUni.KINO_ID_OPERATION_LOG_ReportZAN, KKHLogUtilityUni.DESC_OPERATION_LOG_ReportZAN);
                }
                else
                {
                    //確定 
                    KKHLogUtilityUni.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityUni.KINO_ID_OPERATION_LOG_ReportKAK, KKHLogUtilityUni.DESC_OPERATION_LOG_ReportKAK);
                }
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
        private Common.KKHSchema.Common.SystemCommonRow GetReportInfo(string sybt)
        {
            string strsybt = sybt;//種別:"002"or"003"
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
                                                                string.Empty);

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

                if (sybt.Equals(KV7_SYBT))
                {
                    // 以下、空文字以外をデフォルト値として設定 
                    ret.field2 = SFD_INITDIRTMP;    // 保存先パス(テンプレート） 
                    ret.field3 = DEF_PASSWORD;      // シート保護用パスワード 
                }
                else
                {
                    // 以下、空文字以外をデフォルト値として設定 
                    ret.field2 = SFD_INITDIR;       // 保存先パス（エクセルファイル）
                }
            }

            return ret;
        }


        #endregion メソッド 
    }
}