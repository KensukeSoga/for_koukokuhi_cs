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
using Isid.KKH.Skyp.Schema;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Skyp.ProcessController.Report;
using Isid.KKH.Skyp.Properties;
using Isid.KKH.Skyp.Utility;

namespace Isid.KKH.Skyp.View.Report
{
    /// <summary>
    /// 帳票出力画面（スカパー）
    /// </summary>
    public partial class ReportSkyp : KKHForm
    {
        #region 定数 

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "RepSkyp";

        /// <summary>
        /// 帳票出力＿ファイル拡張子 
        /// </summary>
        private const string SFD_EXT = ".xls";
        /// <summary>
        /// 帳票出力＿起動ディレクトリ 
        /// </summary>
        private const string SFD_INITDIR = @"C:TMP\";
        /// <summary>
        /// 帳票出力＿起動ディレクトリ(テンプレート）
        /// </summary>
        private const string SFD_INIT_NET_DIR = @"R:\E19-SKYPER\";
        /// <summary>
        /// 帳票出力＿起動ディレクトリ(テンプレート）
        /// </summary>
        private const string SFD_INIT_DIR = @"C:\WORK\";
        /// <summary>
        /// 帳票出力＿起動ディレクトリ(テンプレート）
        /// </summary>
        private const string SFD_INIT_FILENAME = @"納品／請求書";
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
        private const string REP_XML_FILENAME = "Skyp_Data.xml";
        /// <summary>
        /// XMLファイル名（プロパティ用） 
        /// </summary>
        private const string REP_XML2_FILENAME = "Skyp_Prop.xml";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名 
        /// </summary>
        private const string REP_TEMPLATE_FILENAME = "Skyp_Template.xlsx";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名 
        /// </summary>
        private const string REP_MACRO_FILENAME = "Skyp_Mcr.xlsm";

        /// <summary>
        /// 帳票設定情報取得キー：002 
        /// </summary>
        private const string KV7_SYBT = "002";
        /// <summary>
        /// 帳票設定情報取得キー：003 
        /// </summary>
        private const string KV7_SYBTSUB = "003";

        /// <summary>
        /// 保存ファイル名（フルパス） 
        /// </summary>
        private const string PARAM_SAVEDIR = "SAVEDIR";
        /// <summary>
        /// 年月 
        /// </summary>
        private const string PARAM_YYYYMM = "YYYYMM";
        /// <summary>
        /// シート保護用パスワード 
        /// </summary>
        private const string PARAM_PASSWORD = "PASSWORD";
        /// <summary>
        /// 得意先名 
        /// </summary>
        private const string PARAM_TKS_NAME = "TKS_NAME";
        /// <summary>
        /// 取引先名 
        /// </summary>
        private const string PARAM_THS_NAME = "THS_NAME";
        /// <summary>
        /// 取引先コード 
        /// </summary>
        private const string PARAM_THS_CD = "THS_CD";
        /// <summary>
        /// 支払日（期間） 
        /// </summary>
        private const string PARAM_PAYDAY = "PAYDAY";

        /// <summary>
        /// シート保護用パスワードのデフォルト値 
        /// </summary>
        private const string DEF_PASSWORD = "";

        /// <summary>
        /// 支払日（期間：月）のデフォルト値 
        /// </summary>
        private const string DEF_PAYDAY = "3";

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
        /// 保存先用変数（ネットワークドライブ）.
        /// </summary>
        private string pStrRepNetAdrs = "";
        /// <summary>
        /// 保存先用変数.
        /// </summary>
        private string pStrRepAdrs = "";
        /// <summary>
        /// 帳票名（保存で使用）用変数.
        /// </summary>
        private string pStrRepFilNam = "";
        /// <summary>
        /// 保存先用(テンプレート)変数.
        /// </summary>
        private string pStrRepTempAdrs = "";
        /// <summary>
        /// 消費税
        /// </summary>
        private double _dbSyohizei;
        /// <summary>
        /// シート保護用パスワード.
        /// </summary>
        private string sheetPw = "";
        /// <summary>
        /// 得意先名.
        /// </summary>
        private string tkskNm = "";
        /// <summary>
        /// 取引先名.
        /// </summary>
        private string trskNm = "";
        /// <summary>
        /// 取引先コード.
        /// </summary>
        private string trskCd = "";
        /// <summary>
        /// 支払日（期間）.
        /// </summary>
        private string payDay = "";

        #endregion メンバ変数 

        #region コンストラクタ 

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public ReportSkyp()
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
        private void ReportSkyp_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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
        /// 画面表示時 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportSkyp_Shown(object sender, EventArgs e)
        {
            //ローディング表示開始 
            base.ShowLoadingDialog();

            this.InitializeControl();

            //帳票情報の初期値セット 
            GetReportDataInit();

            //ローディング表示終了 
            base.CloseLoadingDialog();
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
                //MessageBox.Show("該当のデータは存在しません。", "帳票", MessageBoxButtons.OK);
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
            //Common.KKHSchema.Common.SystemCommonRow repInfo = this.GetReportInfo(KV7_SYBT);
            // 帳票設定情報取得（ファイル初期保存場所）
            //Common.KKHSchema.Common.SystemCommonRow repInfoSub = this.GetReportInfo(KV7_SYBTSUB);

            // SaveFileDialogクラスのインスタンスを作成 
            SaveFileDialog sfd = new SaveFileDialog();

            DateTime now = DateTime.Now;

            // はじめのファイル名を指定する 
            //sfd.FileName = DateTime.Now.ToString("yyyyMMdd") + repInfoSub.field3 + SFD_EXT;
            //sfd.FileName = "納品／請求書-" + saveSrcYm + SFD_EXT;
            sfd.FileName = pStrRepFilNam + "-" + txtYm.Value + SFD_EXT;
            // はじめに表示されるフォルダを指定する 
            //sfd.InitialDirectory = pStrRepAdrs;
            //sfd.InitialDirectory = repInfoSub.field2;

            {
                // 出力先パスの設定
                //（ネットワークドライブに保存、パスが開けない場合はローカルに保存）

                String path = pStrRepNetAdrs;

                if (!Directory.Exists(path))
                {
                    path = pStrRepAdrs;
                }

                sfd.InitialDirectory = path;
            }

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
                catch(IOException)
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
                this.ExcelOut(sfd.FileName);
                //this.ExcelOut(sfd.FileName, repInfo);
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
            string tkskgy = _naviParameter.strTksKgyCd + _naviParameter.strTksBmnSeqNo + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.ReportSkp, this, HelpNavigator.KeywordIndex);

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
        private void condChg(object sender, EventArgs e)
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

        }

        /// <summary>
        /// データ検索・表示メソッド 
        /// </summary>
        /// <returns>検索結果件数</returns> 
        private int FindReportData()
        {
            ReportSkypProcessController.FindReportSkypByCondParam param =
                new ReportSkypProcessController.FindReportSkypByCondParam();

            // パラメータ設定 
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;            
            // 年月 
            param.yymm = txtYm.Value;

            // 帳票（スカパー_納品／請求書）データ検索 
            ReportSkypProcessController processController = ReportSkypProcessController.GetInstance();
            FindReportSkypByCondServiceResult result = processController.FindReportSkypByCond(param);

            if (result.HasError == true)
            {
                return 0;
            }
            _dsReportSkyp.ReportData.Clear();
            _dsReportSkyp.ReportData.Merge(result.ReportDataSet.ReportData);
            _dsReportSkyp.ReportData.AcceptChanges();

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
        private void ExcelOut(string filnm)
        //private void ExcelOut(string filnm, Common.KKHSchema.Common.SystemCommonRow repInfo)
        {
            string workFolderPath = pStrRepTempAdrs; //repInfo.field2;
            string excelFile = string.Empty;            
            string macroFile = workFolderPath + REP_MACRO_FILENAME;
            string templFile = workFolderPath + REP_TEMPLATE_FILENAME;
            DataRow dtRow;

            try
            {
                // Excel開始処理 
                // リソースからExcelファイルを作成(テンプレートとマクロ) 
                File.WriteAllBytes(templFile, Resources.Skyp_Template); 
                File.WriteAllBytes(macroFile, Resources.Skyp_Mcr);                

                if (File.Exists(templFile) == false)
                {
                    throw new Exception("テンプレートExcelファイルがありません。");
                }
                if (File.Exists(macroFile) == false)
                {
                    throw new Exception("マクロExcelファイルがありません。");
                }

                // データセットXML出力 
                _dsReportSkyp.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));

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
                dtTable.Columns.Add(PARAM_TKS_NAME, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_THS_NAME, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_THS_CD, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_PAYDAY, Type.GetType("System.String"));

                //テーブルにデータを追加する 
                dtRow = dtTable.NewRow();

                dtRow[PARAM_SAVEDIR] = filnm;               // 保存ファイル名（フルパス） 
                dtRow[PARAM_YYYYMM] = txtYm.Year + txtYm.Month;
                dtRow[PARAM_PASSWORD] = sheetPw;    // シート保護用パスワード 
                dtRow[PARAM_TKS_NAME] = tkskNm;     // 得意先名 
                dtRow[PARAM_THS_NAME] = trskNm;     // 取引先名 
                dtRow[PARAM_THS_CD] = trskCd;       // 取引先コード 
                dtRow[PARAM_PAYDAY] = payDay;       // 支払日（期間） 

                //dtRow[PARAM_YYYYMM] = _yyyyMM;              // 年月 
                //dtRow[PARAM_PASSWORD] = repInfo.field3;    // シート保護用パスワード 
                //dtRow[PARAM_TKS_NAME] = repInfo.field8;     // 得意先名 
                //dtRow[PARAM_THS_NAME] = repInfo.field5;     // 取引先名 
                //dtRow[PARAM_THS_CD] = repInfo.field6;       // 取引先コード 
                //dtRow[PARAM_PAYDAY] = repInfo.field7;       // 支払日（期間） 
                
                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //エクセル起動 
                System.Diagnostics.Process.Start("excel", macroFile);

                //削除用に保持（戻るボタン押下時に削除する為） 
                _strmacrodel = macroFile;

                // オペレーションログの出力.
                KKHLogUtilitySkyp.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilitySkyp.KINO_ID_OPERATION_LOG_REPORT, KKHLogUtilitySkyp.DESC_OPERATION_LOG_REPORT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///// <summary>
        ///// 帳票出力設定情報取得メソッド 
        ///// </summary>
        ///// <returns>帳票出力設定情報</returns>
        //private Common.KKHSchema.Common.SystemCommonRow GetReportInfo(string sybt)
        //{
        //    string strsybt = sybt;//種別:"002"or"003"
        //    Common.KKHSchema.Common.SystemCommonRow ret;
        //    CommonProcessController commonProcessController = CommonProcessController.GetInstance();
        //    FindCommonByCondServiceResult comResult;
        //
        //    // 帳票設定情報取得 
        //    comResult = commonProcessController.FindCommonByCond(_naviParameter.strEsqId,
        //                                                        _naviParameter.strEgcd,
        //                                                        _naviParameter.strTksKgyCd,
        //                                                        _naviParameter.strTksBmnSeqNo,
        //                                                        _naviParameter.strTksTntSeqNo,
        //                                                        strsybt,
        //                                                        string.Empty);
        //
        //    if (comResult.CommonDataSet.SystemCommon.Count != 0)
        //    {
        //        ret = comResult.CommonDataSet.SystemCommon[0];
        //    }
        //    else
        //    {
        //        // 取得できなかった場合はデフォルト値を設定 
        //        Common.KKHSchema.Common.SystemCommonDataTable dt =
        //            new Common.KKHSchema.Common.SystemCommonDataTable();
        //        ret = (Common.KKHSchema.Common.SystemCommonRow)dt.NewRow();
        //
        //        for (int i = 0; i < dt.Columns.Count; i++)
        //        {
        //            ret[i] = string.Empty;
        //        }
        //
        //        if (sybt.Equals(KV7_SYBT))
        //        {
        //            // 以下、空文字以外をデフォルト値として設定 
        //            ret.field2 = SFD_INITDIRTMP;       // 保存先パス(テンプレート） 
        //            ret.field3 = DEF_PASSWORD;      // シート保護用パスワード 
        //            ret.field7 = DEF_PAYDAY;        // 支払日（期間） 
        //        }
        //        else
        //        {
        //            // 以下、空文字以外をデフォルト値として設定 
        //            ret.field2 = SFD_INITDIR;       // 保存先パス（エクセルファイル）
        //        }
        //    }
        //
        //    return ret;
        //}

        /// <summary>
        /// 帳票初期設定値を取得 
        /// </summary>
        private void GetReportDataInit()
        {
            //ローディング表示  
            base.ShowLoadingDialog();

            {
                CommonProcessController controller = CommonProcessController.GetInstance();

                FindCommonByCondServiceResult result = controller.FindCommonByCond(
                                                                                _naviParameter.strEsqId,
                                                                                _naviParameter.strEgcd,
                                                                                _naviParameter.strTksKgyCd,
                                                                                _naviParameter.strTksBmnSeqNo,
                                                                                _naviParameter.strTksTntSeqNo,
                                                                                Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.MainType,
                                                                                "ED-I0001");

                if (result.CommonDataSet.SystemCommon.Count != 0)
                {
                    //消費税セット
                    _dbSyohizei = double.Parse(result.CommonDataSet.SystemCommon[0].field4.ToString());
                    //テンプレートアドレス
                    pStrRepTempAdrs = result.CommonDataSet.SystemCommon[0].field2.ToString();
                    // シート保護用パスワード 
                    sheetPw = result.CommonDataSet.SystemCommon[0].field3.ToString();
                    // 取引先名 
                    trskNm = result.CommonDataSet.SystemCommon[0].field5.ToString();
                    // 取引先コード 
                    trskCd = result.CommonDataSet.SystemCommon[0].field6.ToString();
                    // 支払日（期間）
                    payDay = result.CommonDataSet.SystemCommon[0].field7.ToString();
                    // 得意先名 
                    tkskNm = result.CommonDataSet.SystemCommon[0].field8.ToString();
                }
            }

            {
                //保存情報＋帳票名
                CommonProcessController controller = CommonProcessController.GetInstance();

                FindCommonByCondServiceResult result = controller.FindCommonByCond(
                                                                                _naviParameter.strEsqId,
                                                                                _naviParameter.strEgcd,
                                                                                _naviParameter.strTksKgyCd,
                                                                                _naviParameter.strTksBmnSeqNo,
                                                                                _naviParameter.strTksTntSeqNo,
                                                                                Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                                "001");

                if (result.CommonDataSet.SystemCommon.Count != 0)
                {
                    //保存先（ネットワークドライブ）セット
                    pStrRepNetAdrs = result.CommonDataSet.SystemCommon[0].field2.ToString();
                    //保存先セット
                    pStrRepAdrs = result.CommonDataSet.SystemCommon[0].field3.ToString();
                    //名称セット
                    pStrRepFilNam = result.CommonDataSet.SystemCommon[0].field4.ToString();
                }
                else
                {
                    //保存先（ネットワークドライブ）セット
                    pStrRepNetAdrs = SFD_INIT_NET_DIR;
                    //保存先セット
                    pStrRepAdrs = SFD_INIT_DIR;
                    //名称セット
                    pStrRepFilNam = SFD_INIT_FILENAME;
                }
            }

            //ローディング非表示 
            base.CloseLoadingDialog();
        }

        #endregion メソッド 

    }
}