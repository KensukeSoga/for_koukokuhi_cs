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
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using Isid.KKH.Mac.Utility;
using Isid.KKH.Mac.Schema;

namespace Isid.KKH.Mac.View.Report
{
    public partial class ReportMacSchklst : KKHForm
    {
        # region メンバ変数

        /// <summary>
        /// 呼び出しパラメータ(受取)
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();

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
        /// XMLファイル名1.
        /// </summary>
        private static readonly string REP_XML_FILENAME = "Mac_SchklstData.xml";
        /// <summary>
        /// XMLファイル名2.
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "Mac_SchklstProp.xml";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "Mac_SchklstTemplate.xlsx";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME = "Mac_SchklstMcr.xlsm";

        /// <summary>
        /// アプリID
        /// </summary>
        private static readonly string APLID = "Schklst";

        # endregion

        # region コンストラクタ
        
        /// <summary>
        /// 
        /// </summary>
        public ReportMacSchklst()
        {
            InitializeComponent();
        }
        # endregion

        # region イベント

        /// <summary>
        /// 画面が初めて表示されたときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportMacSchklst_Shown(object sender, EventArgs e)
        {
            //ローディング表示開始 
            base.ShowLoadingDialog();

            //初期化 
            initialize();

            //年月取得 
            String strDate = getHostDate();
            //txtYm.Value = strDate.Substring(0, 6);

            //ステータス設定 
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
                                                                                            "002");
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

            //ローディング表示開始 
            base.CloseLoadingDialog();
        }

        /// <summary>
        /// 検索ボタンClick
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
        /// データ検索メソッド 
        /// </summary>
        private void GetRecord()
        {
            //ローディング表示開始 
            base.ShowLoadingDialog();

            //初期化 
            dgvMain_Sheet1.RowCount = 0;

            string strcmbkey = "";

            if (cmbTmp.Text == "全て")
            {
                strcmbkey = "";  
            }
            else
            {
                string[] stArrayData = cmbTmp.Text.ToString().Split(':');
                strcmbkey =  stArrayData[0];                
            }

            //年月 
            string yearmon = txtYm.Value;

            //データ取得実行 
            Isid.KKH.Mac.Schema.RepDsMac jyuListdt = new Isid.KKH.Mac.Schema.RepDsMac();
            Isid.KKH.Mac.ProcessController.Report.ReportMacSchklstProcessController processController = Isid.KKH.Mac.ProcessController.Report.ReportMacSchklstProcessController.GetInstance();
            Isid.KKH.Mac.ProcessController.Report.FindReportMacSchklstByCondServiceResult result = processController.FindRepMacSchklstByCond(
                                                                                      _naviParam.strEsqId,
                                                                                      _naviParam.strEgcd,
                                                                                      _naviParam.strTksKgyCd,
                                                                                      _naviParam.strTksBmnSeqNo,
                                                                                      _naviParam.strTksTntSeqNo,
                                                                                      yearmon,
                                                                                      strcmbkey,
                                                                                      "2"
                                                                                      );
            //エラーの場合 
            if (result.HasError)
            {
                //選択状態を解除 
                this.ActiveControl = null;

                //ローディング表示終了 
                base.CloseLoadingDialog();

                return;
            }

            //取得レコードが無い場合 
            if (result.dsRepMacSchklstDataSet.Tables[1].Rows.Count == 0)
            {
                initialize();
            }

            for (int i = 0; i < result.dsRepMacSchklstDataSet.Tables[1].Rows.Count; i++)
            {

                dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 1);
                dgvMain_Sheet1.Cells[i, 0].Value = result.dsRepMacSchklstDataSet.RepmacSchklst[i].name5.ToString();
                dgvMain_Sheet1.Cells[i, 1].Value = result.dsRepMacSchklstDataSet.RepmacSchklst[i].code2.ToString();
                dgvMain_Sheet1.Cells[i, 2].Value = result.dsRepMacSchklstDataSet.RepmacSchklst[i].name4.ToString();
                dgvMain_Sheet1.Cells[i, 3].Value = result.dsRepMacSchklstDataSet.RepmacSchklst[i].name1.ToString()
                                                    + result.dsRepMacSchklstDataSet.RepmacSchklst[i].name2.ToString();
                dgvMain_Sheet1.Cells[i, 4].Value = result.dsRepMacSchklstDataSet.RepmacSchklst[i].code4.ToString();
                dgvMain_Sheet1.Cells[i, 5].Value = double.Parse(result.dsRepMacSchklstDataSet.RepmacSchklst[i].seiGak.ToString()).ToString("###,###,###,##0");
                dgvMain_Sheet1.Cells[i, 6].Value = "　";
            }

            if (result.dsRepMacSchklstDataSet.Tables[1].Rows.Count >= 1)
            {
                btnXls.Enabled = true;
            }
            //件数表示 
            statusStrip1.Items["tslval1"].Text = result.dsRepMacSchklstDataSet.Tables[1].Rows.Count.ToString() + "件";
            
            //保持 
            macds = result.dsRepMacSchklstDataSet;

            //ローディング表示終了 
            base.CloseLoadingDialog();

            //選択状態を解除 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtYm_TxtYmValidated(object sender, EventArgs e)
        {
            SetCmbTmpItr();
        }

        /// <summary>
        /// 初期処理 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportToh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            //初期設定 
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }

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
            sfd.Filter = "XLSXファイル(*.xlsx)|*.xlsx";
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

            this.ActiveControl = null;

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
        /// 
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtYm_Leave(object sender, EventArgs e)
        {
            SetCmbTmpItr();
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


        /// <summary>
        /// 店舗一覧コンボボックスの設定 
        /// </summary>
        private void SetCmbTmpItr() 
        {
            //年月 
            string yearmon = txtYm.Value;
            string strtmp = cmbTmp.Text.ToString();

            //実行 
            Isid.KKH.Mac.Schema.RepDsMac jyuListdt = new Isid.KKH.Mac.Schema.RepDsMac();
            Isid.KKH.Mac.ProcessController.Report.ReportMacSchklstProcessController processController = Isid.KKH.Mac.ProcessController.Report.ReportMacSchklstProcessController.GetInstance();
            Isid.KKH.Mac.ProcessController.Report.FindReportMacSchklstByCondServiceResult result = processController.FindRepMacSchklstByCond(
                                                                                      _naviParam.strEsqId,
                                                                                      _naviParam.strEgcd,
                                                                                      _naviParam.strTksKgyCd,
                                                                                      _naviParam.strTksBmnSeqNo,
                                                                                      _naviParam.strTksTntSeqNo,
                                                                                      yearmon,
                                                                                      strtmp,
                                                                                      "1"
                                                                                      );


            //データグリッド初期化 
            //dgvMain_Sheet1.RowCount = 0;

            //コンボボックス初期化 
            cmbTmp.Items.Clear();

            //コンボボックス設定 
            //cmbTmp.Items.Add("全て");

            if (result.dsRepMacSchklstDataSet.Tables[1].Rows.Count > 0)
            {
                //コンボボックス設定 
                cmbTmp.Items.Add("全て");

                for (int i = 0; i < result.dsRepMacSchklstDataSet.Tables[1].Rows.Count; i++)
                {
                    cmbTmp.Items.Add(result.dsRepMacSchklstDataSet.Tables[1].Rows[i]["code2"].ToString()
                        + ":" + result.dsRepMacSchklstDataSet.Tables[1].Rows[i]["name1"].ToString());
                }

                cmbTmp.Enabled = true;
                cmbTmp.SelectedIndex = 0; //全てを選択 
                btnSrc.Enabled = true;
            }
            else
            {
                initialize();
                btnSrc.Enabled = false;
                //btnXls.Enabled = false;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void initialize()
        {
            //初期化 
            btnSrc.Enabled = true;
            btnXls.Enabled = false;
            cmbTmp.Items.Clear();
            statusStrip1.Items["tslval1"].Text = "0件";
            dgvMain_Sheet1.RowCount = 0;
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
                File.WriteAllBytes(macroFile, Isid.KKH.Mac.Properties.Resources.Mac_SchklstMcr);
                File.WriteAllBytes(templFile, Isid.KKH.Mac.Properties.Resources.Mac_SchklstTemplate);

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

                //テーブルにデータを追加する 
                dtRow = dtTable.NewRow();

                dtRow["SAVEDIR"] = filnm;
                dtRow["USERNAME"] = tslName.Text;
                dtRow["SELHDK"] = txtYm.Year + "年" + txtYm.Month + "月";
                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //エクセル起動.
                System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME);

                //削除用に保持（戻るボタン押下時に削除する為） 
                _strmacrodel = workFolderPath + REP_MACRO_FILENAME;

                //ログの出力 
                KKHLogUtilityMac.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityMac.KINO_ID_OPERATION_LOG_Schklst, KKHLogUtilityMac.DESC_OPERATION_LOG_Schklst);

            }
            catch (Exception ex)
            {
                //選択状態を解除 
                this.ActiveControl = null;

                throw ex;
            }
        }

        # endregion
    }
}