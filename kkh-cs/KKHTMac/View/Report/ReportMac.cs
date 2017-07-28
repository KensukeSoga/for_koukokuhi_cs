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
using Isid.KKH.Mac.Schema;
using Isid.KKH.Mac.ProcessController.Report;
using Isid.KKH.Mac.Utility;

namespace Isid.KKH.Mac.View.Report
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ReportMac : KKHForm
    {

        # region メンバ変数

        /// <summary>
        /// 呼び出しパラメータ(受取)
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();

        /// <summary>
        /// 消費税  
        /// </summary>
        private double _dbSyohizei;

        /// <summary>
        /// コピーマクロ削除用string
        /// </summary>
        private string _strmacrodel;

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
        /// 
        /// </summary>
        private DataSet macds = null;

        # endregion

        # region 定数

        /// <summary>
        /// アプリID
        /// </summary>
        private static readonly string APLID = "Report";

        /// <summary>
        /// XMLファイル名1.
        /// </summary>
        private static readonly string REP_XML_FILENAME = "Mac_Data.xml";
        /// <summary>
        /// XMLファイル名2.
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "Mac_Prop.xml";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "Mac_Template.xlsx";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME = "Mac_Mcr.xlsm";

        /// <summary>
        /// REP_KEY_SYBT：001
        /// </summary>
        private const string REP_KEY_SYBT = "001";
        
        # endregion

        # region コンストラクタ
        /// <summary>
        /// 
        /// </summary>
        public ReportMac()
        {
            InitializeComponent();
        }

        # endregion

        # region イベント
        /// <summary>
        /// 初期処理 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportToh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //初期設定 
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// 画面が初めて表示されたときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportMac_Shown(object sender, EventArgs e)
        {
            //ローディング表示開始 
            base.ShowLoadingDialog();

            //年月取得 
            String strDate = getHostDate();
            txtYm.Value = strDate.Substring(0, 6);

            //ステータス設定 
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

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

                //消費税セット 
                _dbSyohizei = double.Parse(comResult.CommonDataSet.SystemCommon[0].field4.ToString());
                //テンプレートアドレス 
                pStrRepTempAdrs = comResult.CommonDataSet.SystemCommon[0].field2.ToString();
            }

            //保存情報＋帳票名 
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
                //保存先セット 
                pStrRepAdrs = comResult2.CommonDataSet.SystemCommon[0].field2.ToString();
                //名称セット 
                pStrRepFilNam = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
            }

            //グリッドの設定 
            statusStrip1.Items["tslval1"].Text = "0件";
            btnXls.Enabled = false;

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


            //ローディング表示終了 
            base.CloseLoadingDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            //SaveFileDialogクラスのインスタンスを作成 
            SaveFileDialog sfd = new SaveFileDialog();
            //日付とか 
            DateTime now = DateTime.Now;
            //はじめのファイル名を指定する 
            sfd.FileName = pStrRepFilNam + "_" + now.ToString("yyyyMMdd") + ".xlsx";
            //sfd.FileName = now.ToString("yyyyMMdd") + pStrRepFilNam + ".xlsx";
            //はじめに表示されるフォルダを指定する 
            sfd.InitialDirectory = pStrRepAdrs;
            //[ファイルの種類]に表示される選択肢を指定する 
            sfd.Filter =
                "XLSXファイル(*.xlsx)|*.xlsx";
            //[ファイルの種類]ではじめに 
            //「すべてのファイル」が選択されているようにする 
            sfd.FilterIndex = 0;
            //タイトルを設定する 
            sfd.Title = "保存先のファイルを設定して下さい。";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする 
            sfd.RestoreDirectory = true;

            //ダイアログを表示する 
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
                    return;
                }

                //*************************************
                // 出力実行.
                //*************************************
                this.ExcelOut(sfd.FileName);
            }


            sfd.Dispose();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {

            if (_strmacrodel != null)
            {
                System.IO.FileInfo cFileInfo = new System.IO.FileInfo(_strmacrodel);

                // マクロファイルの削除（VBA側では削除できない為） 
                // ファイルが存在しているか判断する 
                if (cFileInfo.Exists)
                {
                    // 読み取り専用属性がある場合は、読み取り専用属性を解除する 
                    if ((cFileInfo.Attributes & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly)
                    {
                        cFileInfo.Attributes = System.IO.FileAttributes.Normal;
                    }

                    // ファイルを削除する 
                    cFileInfo.Delete();
                }
            }

            Navigator.Backward(this, null, _naviParam, true);
        }

        /// <summary>
        /// ヘルプボタンクリック処理 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //KKHHelpMac.ShowHelpMac(this, this.Name);
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Report, this, HelpNavigator.KeywordIndex);

            this.ActiveControl = null;

        }

        /// <summary>
        /// 検索ボタン押下時 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            //*************************************
            // レコード取得.
            //*************************************
            this.GetRecord();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void condChg(object sender, EventArgs e)
        {
            //帳票出力を非活性化にする 
            btnXls.Enabled = false;
        }


        # endregion

        # region メソッド
        /// <summary>
        /// 検索メソッド.
        /// </summary>
        private void GetRecord()
        {
            //ローディング表示開始 
            base.ShowLoadingDialog();

            //年月 
            string yearmon = txtYm.Value;

            //伝番FROM
            string strdnpfr = txtDnpFr.Text;

            //伝番TO
            string strdnpto = txtDnpTo.Text;

            //実行 
            RepDsMac jyuListdt = new RepDsMac();
            ReportMacProcessController processController = ReportMacProcessController.GetInstance();
            FindReportMacByCondServiceResult result = processController.FindRepMacByCond(
                                                                                      _naviParam.strEsqId,
                                                                                      _naviParam.strEgcd,
                                                                                      _naviParam.strTksKgyCd,
                                                                                      _naviParam.strTksBmnSeqNo,
                                                                                      _naviParam.strTksTntSeqNo,
                                                                                      yearmon,
                                                                                      strdnpfr,
                                                                                      strdnpto
                                                                                      );


            //データが存在しなければ終了 
            if (result.dsRepMacDataSet.Tables[0].Rows.Count == 0)
            {
                //ローディング表示終了 
                base.CloseLoadingDialog();

                dgvMain_Sheet1.RowCount = 0;
                btnXls.Enabled = false;
                //MessageBox.Show("該当のデータは存在しません。", "帳票", MessageBoxButtons.OK);
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);
                return;
            }

            //データグリッド初期化 
            dgvMain_Sheet1.RowCount = 0;            

            //データグリッドに表示(件数分表示) 
            for (int i = 0; i < result.dsRepMacDataSet.Tables[0].Rows.Count; i++)
            {
                dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 1);
                dgvMain_Sheet1.Cells[i, 0].Value = result.dsRepMacDataSet.Repmac[i].sonota1.ToString();
                dgvMain_Sheet1.Cells[i, 1].Value = result.dsRepMacDataSet.Repmac[i].code1.ToString();
                dgvMain_Sheet1.Cells[i, 2].Value = result.dsRepMacDataSet.Repmac[i].name3.ToString();
                dgvMain_Sheet1.Cells[i, 3].Value = result.dsRepMacDataSet.Repmac[i].jyutNo.ToString() 
                                                    + "-" + result.dsRepMacDataSet.Repmac[i].jyMeiNo.ToString()
                                                    + "-" + result.dsRepMacDataSet.Repmac[i].urMeiNo.ToString();
                dgvMain_Sheet1.Cells[i, 4].Value = result.dsRepMacDataSet.Repmac[i].name1.ToString()        //件名１
                                                    + result.dsRepMacDataSet.Repmac[i].name2.ToString();    //件名２ 
                dgvMain_Sheet1.Cells[i, 5].Value = result.dsRepMacDataSet.Repmac[i].code4.ToString();       
                //数量 
                dgvMain_Sheet1.Cells[i, 6].Value = double.Parse(result.dsRepMacDataSet.Repmac[i].kngk2.ToString()).ToString("###,###,###,##0");
                
                //分割コードが１の場合 
                if (result.dsRepMacDataSet.Repmac[i].sonota2 == "1")
                {
                    //単価を表示しない 
                    dgvMain_Sheet1.Cells[i, 7].Value = "";
                }
                else
                {
                    //単価が100万以上の場合
                    if (double.Parse(result.dsRepMacDataSet.Repmac[i].kngk1.ToString()) >= 1000000)
                    {
                        //単価を表示しない 
                        dgvMain_Sheet1.Cells[i, 7].Value = "";
                    }
                    else
                    {
                        //単価 
                        dgvMain_Sheet1.Cells[i, 7].Value = double.Parse(result.dsRepMacDataSet.Repmac[i].kngk1.ToString()).ToString("###,###,###,##0.##0");
                    }
                }
                //dgvMain_Sheet1.Cells[i, 7].Value = double.Parse(result.dsRepMacDataSet.Repmac[i].kngk1.ToString()).ToString("###,###,###,##0");
                //請求額 
                dgvMain_Sheet1.Cells[i, 8].Value = Math.Floor(decimal.Parse(result.dsRepMacDataSet.Repmac[i].seiGak.ToString())).ToString("###,###,###,##0");
                //dgvMain_Sheet1.Cells[i, 8].Value = double.Parse(result.dsRepMacDataSet.Repmac[i].seiGak.ToString()).ToString("###,###,###,##0");

            }
                     

            macds = result.dsRepMacDataSet;

            btnXls.Enabled = true;

            //件数表示
            statusStrip1.Items["tslval1"].Text = result.dsRepMacDataSet.Tables[0].Rows.Count.ToString() + "件";

            //選択状態を解除 
            this.ActiveControl = null;

            //ローディング表示終了 
            base.CloseLoadingDialog();

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
                File.WriteAllBytes(macroFile, Isid.KKH.Mac.Properties.Resources.Mac_Mcr);
                File.WriteAllBytes(templFile, Isid.KKH.Mac.Properties.Resources.Mac_Template);

                if (System.IO.File.Exists(templFile) == false)
                {
                    throw new Exception("テンプレートExcelファイルがありません。");
                }
                if (System.IO.File.Exists(macroFile) == false)
                {
                    throw new Exception("マクロExcelファイルがありません。");
                }

                // データセットXML出力 
                macds.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));
                
                // パラメータXML作成、出力 
                // 変数の宣言 
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // データセットにテーブルを追加する 
                // PRODUCTSというテーブルを作成します 
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("USERNAME", Type.GetType("System.String"));
                dtTable.Columns.Add("SELHDK", Type.GetType("System.String"));
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                dtTable.Columns.Add("SYOHIZEI", Type.GetType("System.String"));

                //テーブルにデータを追加する
                dtRow = dtTable.NewRow();

                dtRow["SAVEDIR"] = filnm;
                dtRow["SYOHIZEI"] = _dbSyohizei.ToString();
                dtRow["USERNAME"] = tslName.Text;
                dtRow["SELHDK"] = txtYm.Year + "年" + txtYm.Month + "月";
                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));


                //エクセル起動.
                System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME);

                //削除用に保持（戻るボタン押下時に削除する為） 
                _strmacrodel = workFolderPath + REP_MACRO_FILENAME;

                //ログの出力 
                KKHLogUtilityMac.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityMac.KINO_ID_OPERATION_LOG_Report, KKHLogUtilityMac.DESC_OPERATION_LOG_Report);

                //選択状態を解除 
                this.ActiveControl = null;

            }
            catch (Exception ex)
            {
                //選択状態を解除 
                this.ActiveControl = null;

                throw ex;
            }
        }

        /// <summary>
        /// 営業日を取得 
        /// </summary>
        /// <returns></returns>
        private String getHostDate()
        {
            String hostDate = "";

            CommonProcessController processController = CommonProcessController.GetInstance();
            hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return hostDate;
        }

        # endregion

    }
}