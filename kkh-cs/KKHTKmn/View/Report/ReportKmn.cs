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
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using Isid.KKH.Kmn.Schema;
using Isid.KKH.Kmn.Utility;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Kmn.ProcessController.Report;
using Isid.KKH.Kmn.Properties;
using System.Collections;

namespace Isid.KKH.Kmn.View.Report
{
    /// <summary>
    /// 納品書画面.
    /// </summary>
    public partial class ReportKmn : KKHForm
    {
        #region メンバ変数.
        /// <summary>
        /// 呼び出しパラメータ(受取).
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// コピーマクロ削除用string.
        /// </summary>
        private string _strmacrodel;
        /// <summary>
        /// 受注登録内容検索実行時の設定条件を保持.
        /// </summary>
        protected DetailProcessController.FindJyutyuDataByCondParam findJyutyuDataCond = new DetailProcessController.FindJyutyuDataByCondParam();
        /// <summary>
        /// 宛先マスタ_部門コードと宛先名をセットで保持.
        /// </summary>
        private Hashtable htAtesaki = new Hashtable();
        /// <summary>
        // 年月の重複チェックリスト(受注チェック処理にて使用).
        /// </summary>
        private List<string> yymmList = new List<string>();
        /// <summary>
        /// 宛名格納用.
        /// </summary>
        private String AtNm = "";
        /// <summary>
        /// 部門略称格納用.
        /// </summary>
        private String BmNm = "";
        /* 2013/07/18 請求年月表示方法修正対応 HLC H.Watabe ADD Start */
        /// <summary>
        /// 請求年月格納用.
        /// </summary>
        private string YYMM = "";
        /* 2013/07/18 請求年月表示方法修正対応 HLC H.Watabe ADD End */
        /// <summary>
        /// KmnDataset.
        /// </summary>
        private DataSet KmnDS = null;
        #endregion メンバ変数.

        #region 定数.
        /// <summary>
        /// アプリID.
        /// </summary>
        private static readonly string APLID = "Report";
        /// <summary>
        /// 帳票出力_ファイル拡張子.
        /// </summary>
        private const string SFD_EXT = ".xlsx";
        /// <summary>
        /// 帳票出力_ファイル拡張子(マクロあり).
        /// </summary>
        private const string SFD_EXTM = ".xlsm";
        /// <summary>
        /// 帳票出力_起動ディレクトリ.
        /// </summary>
        private const string SFD_INITDIR = @"C:\";
        /// <summary>
        /// 帳票出力_起動ディレクトリ(テンプレート).
        /// </summary>
        private const string SFD_INITDIRTMP = @"C:\Temp\";
        /// <summary>
        /// 帳票出力_フィルタ.
        /// </summary>
        private const string SFD_FILTER = "XLSMファイル(*.xlsm)|*.xlsm";
        /// <summary>
        /// 帳票出力_タイトル.
        /// </summary>
        private const string SFD_TITLE = "保存先のファイルを設定して下さい。";
        /// <summary>
        /// XMLファイル名(データ用).
        /// </summary>
        private const string REP_XML_FILENAME = "Kmn_Data.xml";
        /// <summary>
        /// XMLファイル名(プロパティ用).
        /// </summary>
        private const string REP_XML2_FILENAME = "Kmn_Prop.xml";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private const string REP_TEMPLATE_FILENAME = "Kmn_Template.xlsx";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名(マクロ有り).
        /// </summary>
        private const string REP_TEMPLATE_FILENAMEM = "Kmn_Template.xlsm";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private const string REP_MACRO_FILENAME = "Kmn_Mcr.xlsm";
        /// <summary>
        /// 帳票設定情報取得キー：002.
        /// </summary>
        private const string KV7_SYBT = "002";
        /// <summary>
        /// 帳票設定情報取得キー：003.
        /// </summary>
        private const string KV7_SYBTSUB = "003";
        /// <summary>
        /// 帳票設定情報取得キー：002.
        /// </summary>
        private const string KV7_SYBTSUB_KEY = "002";
        /// <summary>
        /// 帳票パラメータ：保存ファイル名(フルパス).
        /// </summary>
        private const string PARAM_SAVEDIR = "SAVEDIR";
        /// <summary>
        /// 帳票パラメータ：年月.
        /// </summary>
        private const string PARAM_YYYYMM = "YYYYMM";
        /// <summary>
        /// 帳票パラメータ：シート保護用パスワード.
        /// </summary>
        private const string PARAM_PASSWORD = "PASSWORD";
        /// <summary>
        /// 帳票パラメータ：帳票区分.
        /// </summary>
        private const string PARAM_REPORTKBN = "REPORTKBN";
        /// <summary>
        /// 帳票パラメータ：ユーザー名称.
        /// </summary>
        private const string PARAM_USERNAME = "USERNAME";
        /// <summary>
        /// 帳票パラメータ：宛名.
        /// </summary>
        private const string PARAM_ATENA = "ATENA";
        /// <summary>
        /// 帳票パラメータ：登録コード.
        /// </summary>
        private const string PARAM_TOROKCODE = "TOROKCODE";
        /// <summary>
        /// 帳票パラメータ：住所.
        /// </summary>
        private const string PARAM_ADDRESS = "ADDRESS";
        /// <summary>
        /// 帳票パラメータ：納品者.
        /// </summary>
        private const string PARAM_NOHINNAME = "NOHINNAME";
        /// <summary>
        /// 帳票パラメータ：納品日.
        /// </summary>
        private const string PARAM_NOHINDATE = "NOHINDATE";
        /// <summary>
        /// 帳票パラメータ：プリンタ名.
        /// </summary>
        private const string PARAM_PRINTERNM = "PRINTERNM";
        /// <summary>
        /// シート保護用パスワードのデフォルト値.
        /// </summary>
        private const string DEF_PASSWORD = "ks1dms";
        /// <summary>
        /// 宛先マスター取得キー.
        /// </summary>
        public const string C_MST_ATESAKI = "0001";
        /// <summary>
        /// チェックボックス設定値.
        /// </summary>
        private bool _checkBoxValue = true;

        #region 入力明細スプレッド列インデックス.
        /// <summary>
        ///  ピックアップ用のチェックボックス.
        /// </summary>
        public const int COLIDX_CHKBOX = 0;
        /// <summary>
        ///  No.
        /// </summary>
        public const int COLIDX_NO = 1;
        /// <summary>
        ///  出力No.
        /// </summary>
        public const int COLIDX_OUTPUTNO = 2;
        /// <summary>
        ///  年月.
        /// </summary>
        public const int COLIDX_YYYYMM = 3;
        /// <summary>
        ///  受注No.
        /// </summary>
        public const int COLIDX_JYUTNO = 4;
        /// <summary>
        ///  受注明細No.
        /// </summary>
        public const int COLIDX_JYUMEINO = 5;
        /// <summary>
        ///  売上明細No.
        /// </summary>
        public const int COLIDX_URIMEINO = 6;
        /// <summary>
        ///  請求書発行.
        /// </summary>
        public const int COLIDX_SEIHAKKO = 7;
        /// <summary>
        ///  品目1
        /// </summary>
        public const int COLIDX_HINMOKU1 = 8;
        /// <summary>
        ///  品目2
        /// </summary>
        public const int COLIDX_HINMOKU2 = 9;
        /// <summary>
        ///  品目3
        /// </summary>
        public const int COLIDX_HINMOKU3 = 10;
        /// <summary>
        ///  部門コード.
        /// </summary>
        public const int COLIDX_BUMONCD = 11;
        /// <summary>
        ///  部門名.
        /// </summary>
        public const int COLIDX_BUMONNM = 12;
        /// <summary>
        ///  消費税額.
        /// </summary>
        public const int COLIDX_SZEIGAK = 13;
        /// <summary>
        ///  金額.
        /// </summary>
        public const int COLIDX_KINGAK = 14;
        #endregion 入力明細スプレッド列インデックス.
        #endregion 定数.

        #region コンストラクタ.
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ReportKmn()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ.

        #region イベント.
        #region 初期処理.
        /// <summary>
        /// 初期処理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportKmn_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //初期設定.
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
        }
        #endregion 初期処理.

        #region 画面が初めて表示されたときに発生します.
        /// <summary>
        /// 画面が初めて表示されたときに発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportKmn_Shown(object sender, EventArgs e)
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            // 初期表示処理.
            this.InitializeControl();

            //ローディング表示終了.
            base.CloseLoadingDialog();
        }
        #endregion 画面が初めて表示されたときに発生します.

        #region スプレッドダブルクリックイベント.
        /// <summary>
        /// スプレッドダブルクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdReport_CellDoubleClick(object sender, CellClickEventArgs e)
        {
            //ヘッダーの場合.
            if (e.ColumnHeader == true)
            {
                //選択列の場合.
                if (e.Column == COLIDX_CHKBOX)
                {
                    //データ件数分、繰り返す.
                    for (int row = 0; row < dgvMain_Sheet1.RowCount - 1; row++)
                    {
                        // NOの値が入っている行のみ対象.
                        if (dgvMain_Sheet1.Cells[row, COLIDX_NO].Text.Trim() != "")
                        {
                            //チェックボックスの設定.
                            dgvMain_Sheet1.Cells[row, e.Column].Value = _checkBoxValue;
                        }
                    }

                    //次回用にチェックボックスの値を更新.
                    _checkBoxValue = !_checkBoxValue;
                }
            }
        }
        #endregion スプレッドダブルクリックイベント.

        #region 帳票出力ボタンクリックイベント.
        /// <summary>
        /// 帳票出力ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            // 帳票設定情報取得 (テンプレート保存場所、パスワード等).
            Common.KKHSchema.Common.SystemCommonRow repInfo = this.GetReportInfo(KV7_SYBT, "");

            // 帳票設定情報取得(ファイル初期保存場所).
            Common.KKHSchema.Common.SystemCommonRow repInfoSub = this.GetReportInfo(KV7_SYBTSUB, KV7_SYBTSUB_KEY);

            // チェック用変数.
            bool chkflg = false;

            // 選択チェックボックスにチェックがされていないデータの値にブランクを設定.
            for (int i = 0; dgvMain_Sheet1.RowCount > i; i++)
            {
                // セルタイプがチェックボックスのみ対象.
                if (dgvMain_Sheet1.Cells[i, COLIDX_CHKBOX].Value == null)
                {
                    // ブランク設定.
                    dgvMain_Sheet1.Cells[i, COLIDX_CHKBOX].Value = " ";
                }
                else
                {
                    if (dgvMain_Sheet1.Cells[i, COLIDX_CHKBOX].Value.ToString() == "True")
                    {
                        // チェックフラグON.
                        chkflg = true;
                    }
                    else
                    {
                        // ブランク設定.
                        dgvMain_Sheet1.Cells[i, COLIDX_CHKBOX].Value = " ";
                    }
                }
            }

            // 選択チェックボックスが一つもチェックされていない場合は出力しない.
            if (!chkflg)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0160, null, "帳票", MessageBoxButtons.OK);
                return;
            }

            // SaveFileDialogクラスのインスタンスを作成.
            SaveFileDialog sfd = new SaveFileDialog();

            // ファイル名の設定.
            // 出力Noが設定されていない場合.
            if (txtOutPutNo.Text.Trim() == "")
            {
                // 部署が指定されていない場合.
                if (cmbBumon.Text.Trim() == "")
                {
                    // 年月txtの値を使用.
                    sfd.FileName = repInfoSub.field3 + "_" + txtYm.Value + SFD_EXTM;
                }
                // 部署が指定されている場合.
                else
                {
                    // 年月txtの値と部署cmbの値を使用.
                    sfd.FileName = repInfoSub.field3 + "_" + cmbBumon.Text + "_" + txtYm.Value + SFD_EXTM;
                }
            }
            // 出力Noが設定されている場合.
            else
            {
                // 出力Noの値を使用.
                if (txtOutPutNo.Text.Trim().Length >= 6)
                {
                    sfd.FileName = repInfoSub.field3 + "_" + BmNm + "_" + txtOutPutNo.Text.Trim().Substring(0, 6) + SFD_EXTM;
                }
                else
                {
                    sfd.FileName = repInfoSub.field3 + "_" + BmNm + "_" + txtOutPutNo.Text.Trim() + SFD_EXTM;
                }
            }

            // はじめに表示されるフォルダを指定する.
            sfd.InitialDirectory = repInfoSub.field2;

            // [ファイルの種類]に表示される選択肢を指定する.
            sfd.Filter = SFD_FILTER;

            // [ファイルの種類]ではじめに「すべてのファイル」が選択されているようにする.
            sfd.FilterIndex = 0;

            // タイトルを設定する.
            sfd.Title = SFD_TITLE;

            // ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする.
            sfd.RestoreDirectory = true;

            // ダイアログを表示する.
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //出力先に同名のExcelファイルが開いているかチェック.
                try
                {
                    //同名でファイルを削除する.
                    File.Delete(sfd.FileName);
                }
                catch (IOException)
                {
                    //出力先に同名のExcelファイルが開いています。閉じてから再度出力してください.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "帳票", MessageBoxButtons.OK);

                    //選択状態を解除.
                    this.ActiveControl = null;

                    return;
                }

                // 出力実行.
                this.ExcelOut(sfd.FileName, repInfo);
            }

            //選択状態を解除.
            this.ActiveControl = null;
            sfd.Dispose();
        }
        #endregion 帳票出力ボタンクリックイベント.

        #region 矢印ボタンを押したときに発生します.
        /// <summary>
        /// 矢印ボタンを押したときに発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {

            if (_strmacrodel != null)
            {
                System.IO.FileInfo cFileInfo = new System.IO.FileInfo(_strmacrodel);

                // マクロファイルの削除(VBA側では削除できない為).
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
        #endregion 矢印ボタンを押したときに発生します.

        #region ヘルプボタンを押したときに発生します.
        /// <summary>
        /// ヘルプボタンを押したときに発生します.
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
        #endregion ヘルプボタンを押したときに発生します.

        #region 検索ボタンを押したときに発生します.
        /// <summary>
        /// 検索ボタンを押したときに発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            // レコード取得.
            this.GetRecord();
        }
        #endregion 検索ボタンを押したときに発生します.

        #region 年月コンボボックスを変更するときに発生します.
        /// <summary>
        /// 年月コンボボックスを変更するときに発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void condChg_yyyymm(object sender, EventArgs e)
        {
            //帳票出力を非活性化にする.
            btnXls.Enabled = false;

            //受注チェックを非活性化にする.
            btnUpdateCheck.Enabled = false;
        }
        #endregion 年月コンボボックスを変更するときに発生します.

        #region 請求先部門コンボボックスを変更するときに発生します.
        /// <summary>
        /// 請求先部門コンボボックスを変更するときに発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void condChg(object sender, EventArgs e)
        {
            //帳票出力を非活性化にする.
            btnXls.Enabled = false;

            //受注チェックを非活性化にする.
            btnUpdateCheck.Enabled = false;
        }
        #endregion 請求先部門コンボボックスを変更するときに発生します.

        #region 出力Noを入力するときに発生します.
        /// <summary>
        /// 出力Noを入力するときに発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOutPutNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //数値、バックスペースのみ入力可能.
            /* 2013/04/19 コピーペーストも可能 HLC T.Sonobe DEL Start */
            //if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            //{
            //    e.Handled = true;
            //}
            /* 2013/04/19 コピーペーストも可能 HLC T.Sonobe DEL End */

            //帳票出力を非活性化にする.
            btnXls.Enabled = false;

            //受注チェックを非活性化にする.
            btnUpdateCheck.Enabled = false;
        }
        #endregion 出力Noを入力するときに発生します.

        #region 受注チェックボタンを押したときに発生します.
        /// <summary>
        /// 受注チェックボタンを押したときに発生します.
        /// </summary>
        /// <returns></returns>
        private void UpdateCheckClick(object sender, EventArgs e)
        {
            //実行確認.
            if (DialogResult.OK != MessageUtility.ShowMessageBox(MessageCode.HB_C0016, null, "受注チェック", MessageBoxButtons.OKCancel))
            {
                this.ActiveControl = null;
                return;
            }

            // 業務会計稼働状況チェック.
            bool accountOperationStatus = CheckAccountOperationStatus();

            // 業務会計が稼働中の場合.
            if (accountOperationStatus)
            {
                // 検索結果まとめ用初期化.
                Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable JData = new Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable();

                // 年月リストに格納されている分繰り返す.
                for (int i = 0; yymmList.Count > i; i++)
                {
                    //受注登録内容検索. 
                    DetailProcessController.FindJyutyuDataByCondParam findJyutyuDataCond = new DetailProcessController.FindJyutyuDataByCondParam();

                    // 検索条件の設定.
                    findJyutyuDataCond.esqId = _naviParam.strEsqId;
                    findJyutyuDataCond.egCd = _naviParam.strEgcd;
                    findJyutyuDataCond.tksKgyCd = _naviParam.strTksKgyCd;
                    findJyutyuDataCond.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                    findJyutyuDataCond.tksTntSeqNo = _naviParam.strTksTntSeqNo;
                    findJyutyuDataCond.yymm = yymmList[i];
                    findJyutyuDataCond.kokKbn = "";
                    findJyutyuDataCond.tmspKbn = "";
                    findJyutyuDataCond.gyomKbn = "";
                    findJyutyuDataCond.jyutNo = "";
                    findJyutyuDataCond.orderKbn = "";
                    findJyutyuDataCond.jyutNo = "";
                    findJyutyuDataCond.updateCheckFlag = true;
                    findJyutyuDataCond.kkNameKj = "";

                    // 受注データ検索実行.
                    DetailProcessController processController = DetailProcessController.GetInstance();
                    FindJyutyuDataByCondServiceResult result = processController.FindJyutyuDataByCond(findJyutyuDataCond);

                    if (result.HasError == true)
                    {
                        // 初期表示に戻す.
                        this.InitializeControl();
                        repDSKmn.RepKmnMeisai.Clear();

                        //コントロールを未選択状態にする.
                        this.ActiveControl = null;

                        base.CloseLoadingDialog();

                        // オペレーションログの出力.
                        KKHLogUtilityKmn.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityKmn.KINO_ID_OPERATION_LOG_UpdCheck, KKHLogUtilityKmn.DESC_OPERATION_LOG_UpdCheck);

                        return;
                    }

                    // 検索結果をひとまとめにする.
                    //JData.Merge(result.DetailDataSet.JyutyuData);
                    //JData.AcceptChanges();
                    //ds.JyutyuData.Merge(result.DetailDataSet.JyutyuData,true);
                    //ds.JyutyuData.AcceptChanges();
                    //if (result.DetailDataSet.JyutyuData.Count > 0)
                    //{
                    //    foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in result.DetailDataSet.JyutyuData)
                    //    {
                    //        //JData.AddJyutyuDataRow(row);
                    //        JData.ImportRow(row);
                    //    }
                    //}
                    //検索結果から明細データの背景色を変更.
                    jyutyuDataCheck(result.DetailDataSet.JyutyuData);
                }
            }

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
            base.CloseLoadingDialog();

            // オペレーションログの出力.
            KKHLogUtilityKmn.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityKmn.KINO_ID_OPERATION_LOG_UpdCheck, KKHLogUtilityKmn.DESC_OPERATION_LOG_UpdCheck);
        }
        #endregion 受注チェックボタンを押したときに発生します.
        #endregion イベント.

        #region メソッド.
        #region 初期表示処理.
        /// <summary>
        /// 初期表示処理. 
        /// </summary>
        /// <returns></returns>
        private void InitializeControl()
        {
            //年月取得.
            string yyyymm = _naviParam.strDate.Replace("/", string.Empty);
            // ステータス設定.
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            // 受注チェックボタンを非活性化.
            btnUpdateCheck.Enabled = false;

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

            //グリッドの設定.
            statusStrip1.Items["tslval1"].Text = "0件";
            btnXls.Enabled = false;

            //部署名をコンボボックスにセットする.
            SetBushoCmb();
        }
        #endregion 初期表示処理.

        #region 請求先コンボボックスへセット.
        /// <summary>
        /// 請求先コンボボックスへセット.
        /// </summary>
        /// <returns></returns>
        private void SetBushoCmb()
        {
            //宛先マスタから請求先部門を取得.
            MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result = process.FindMasterByCond(
                                                                                  _naviParam.strEsqId,
                                                                                  _naviParam.strEgcd,
                                                                                  _naviParam.strTksKgyCd,
                                                                                  _naviParam.strTksBmnSeqNo,
                                                                                  _naviParam.strTksTntSeqNo,
                                                                                  C_MST_ATESAKI,
                                                                                  null);

            MasterMaintenance.MasterDataVODataTable dtAtesaki = new MasterMaintenance.MasterDataVODataTable();
            MasterMaintenance.MasterDataVORow voRow2 = dtAtesaki.NewMasterDataVORow();

            //空行を追加.
            dtAtesaki.AddMasterDataVORow(voRow2);
            if (result.MasterDataSet.MasterDataVO != null)
            {
                dtAtesaki.Merge(result.MasterDataSet.MasterDataVO);
                
                //部門コードと宛名をセットで保持.
                foreach (MasterMaintenance.MasterDataVORow row in result.MasterDataSet.MasterDataVO)
                {
                    htAtesaki.Add(row.Column1, row.Column3);
                }
            }

            dtAtesaki.AcceptChanges();

            /* 2013/04/23 部署名の重複表示排除対応 JSE M.Naito MOD Start */
            MasterMaintenance.MasterDataVODataTable dtAtesaki_new = new MasterMaintenance.MasterDataVODataTable();

            foreach (MasterMaintenance.MasterDataVORow row1 in result.MasterDataSet.MasterDataVO)
            {
                // 新規行作成.
                MasterMaintenance.MasterDataVORow newrow = (MasterMaintenance.MasterDataVORow)dtAtesaki_new.NewRow();
                // 
                if (dtAtesaki_new.Count > 0)
                {
                    // 部門略称と宛先が一致するデータをDataTableから取得.
                    DataRow[] dt = dtAtesaki_new.Select(dtAtesaki_new.Column2Column.ColumnName + "='" + row1.Column2 + "' AND " + dtAtesaki_new.Column3Column.ColumnName + "='" + row1.Column3 + "'");

                    // DataTableに同じ部門略称が存在しない場合.
                    if (dt.Length == 0)
                    {
                        // 部門略称を取得.
                        newrow.Column2 = row1.Column2;
                        // コードを取得.
                        newrow.Column1 = row1.Column1;
                        // 宛先を取得.
                        newrow.Column3 = row1.Column3;

                        // DataTableに追加.
                        dtAtesaki_new.AddMasterDataVORow(newrow);
                    }
                }
                else
                {
                    // 部門略称を取得.
                    newrow.Column2 = row1.Column2;
                    // コードを取得.
                    newrow.Column1 = row1.Column1;
                    // 宛先を取得.
                    newrow.Column3 = row1.Column3;

                    // 空行を追加.
                    MasterMaintenance.MasterDataVORow voRow2_new = dtAtesaki_new.NewMasterDataVORow();
                    dtAtesaki_new.AddMasterDataVORow(voRow2_new);

                    // DataTableに追加.
                    dtAtesaki_new.AddMasterDataVORow(newrow);
                }
            }

            dtAtesaki_new.AcceptChanges();

            //コンボボックスのDataSourceにDataTableを割り当てる.
            this.cmbBumon.DataSource = dtAtesaki_new;

            //表示される値はDataTableのColumn2列.
            this.cmbBumon.DisplayMember = dtAtesaki_new.Column2Column.ColumnName;
            //表示と対応するコード値はDataTableのColumn1列.
            this.cmbBumon.ValueMember = dtAtesaki_new.Column1Column.ColumnName;


            ////コンボボックスのDataSourceにDataTableを割り当てる.
            //this.cmbBumon.DataSource = dtAtesaki;
            ////表示される値はDataTableのColumn2列.
            //this.cmbBumon.DisplayMember = dtAtesaki.Column2Column.ColumnName;
            ////表示と対応するコード値はDataTableのColumn1列.
            //this.cmbBumon.ValueMember = dtAtesaki.Column1Column.ColumnName;
            /* 2013/04/23 部署名の重複表示排除対応 JSE M.Naito End */
        }
        #endregion 請求先コンボボックスへセット.

        #region 業務会計稼働状況チェック.
        /// <summary>
        /// 業務会計稼働状況チェック.
        /// </summary>
        /// <returns></returns>
        private bool CheckAccountOperationStatus()
        {
            CommonProcessController processController = CommonProcessController.GetInstance();
            accountOperationStatusResult result = processController.CheckAccountOperationStatus(KKHSecurityInfo.GetInstance().UserEsqId);

            // エラーの場合.
            if (result.errorInfo != null && result.errorInfo.error)
            {
                MessageUtility.ShowMessageBox(result.errorInfo.errorCode, null, "明細登録", MessageBoxButtons.OK);
                this.Close();
                return false;
            }

            // 業務会計が停止中の場合.
            if (result.accountOperationStatus == false)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0097, null, "明細登録", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
        #endregion 業務会計稼働状況チェック.

        #region 受注データのチェックメソッド.
        /// <summary>
        /// 受注データのチェックメソッド.
        /// </summary>
        private void jyutyuDataCheck(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable jyutyuDataDataTable)
        {
            // 受注データが変更／削除されている場合、スプレッドの背景色を変更する.
            foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in jyutyuDataDataTable.Rows)
            {
                // 削除されている場合.
                if (row.jyutDelFlg == "1" || row.stpKbn == "1")
                {
                    String str = row.hb1JyutNo.Substring(5, 2);
                    bool flag = true;
                    foreach (char c in str)
                    {
                        //数字以外の文字が含まれているか調べる.

                        if (c < '0' || '9' < c)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        // 受注No,統合フラグ,統合先受注Noで該当の明細データを検索、背景色変更.
                        spreadBackColerChange(row.hb1JyutNo, row.hb1TouFlg, row.hb1TJyutNo);
                    }
                }
                // 変更されている場合.
                else if (row.seikJtai == "0" && row.seiSagSts == "0" && row.stpKbn == "0")
                {
                    // 受注No,統合フラグ,統合先受注Noで該当の明細データを検索、背景色変更.
                    spreadBackColerChange(row.hb1JyutNo, row.hb1TouFlg, row.hb1TJyutNo);
                }
                else if (row.rMeiTimStmp != "")
                {
                    // 受注No,統合フラグ,統合先受注Noで該当の明細データを検索、背景色変更.
                    spreadBackColerChange(row.hb1JyutNo, row.hb1TouFlg, row.hb1TJyutNo);
                }
            }
        }
        #endregion 受注データのチェックメソッド.

        #region スプレッド背景色変更メソッド.
        /// <summary>
        /// スプレッド背景色変更メソッド.
        /// </summary>
        private void spreadBackColerChange(string J_JyutNo, string J_TouFlg, string J_TJyutNo)
        {
            // 明細側の変数の初期化.
            // 受注No.
            string M_JyutNo = "";

            // 明細データの中から受注No, 受注明細No, 売上明細Noが一致するデータを検索.
            for (int i = 0; i < dgvMain_Sheet1.RowCount; i++)
            {
                // スプレッドの中から小計行は除く.
                if (dgvMain_Sheet1.Cells[i, COLIDX_JYUTNO].Value != null)
                {
                    // 明細側の情報取得.
                    // 受注No.
                    M_JyutNo = dgvMain_Sheet1.Cells[i, COLIDX_JYUTNO].Value.ToString();

                    // 統合親データの場合.
                    if (J_TouFlg == "1")
                    {
                    }
                    // 統合親データ以外の場合.
                    else
                    {
                        // 統合子データの場合.
                        if (J_TJyutNo != "")
                        {
                            // 受注Noが一致する場合、背景色の変更.
                            if (M_JyutNo == J_TJyutNo)
                            {
                                // スプレッドの背景色変更.
                                dgvMain_Sheet1.Rows[i].BackColor = Color.Pink;
                            }
                        }
                        // 未統合データの場合.
                        else
                        {
                            // 受注Noが一致する場合、背景色の変更.
                            if (M_JyutNo == J_JyutNo)
                            {
                                // スプレッドの背景色変更.
                                dgvMain_Sheet1.Rows[i].BackColor = Color.Pink;
                            }
                        }
                    }
                }
            }
        }
        #endregion スプレッド背景色変更メソッド.

        #region 検索メソッド.
        /// <summary>
        /// 検索メソッド.
        /// </summary>
        private void GetRecord()
        {
            ////ローディング表示開始.
            base.ShowLoadingDialog();

            ReportKmnProcessController.FindReportKmnByCondParam param = new ReportKmnProcessController.FindReportKmnByCondParam();

            // パラメータ設定.
            param.esqId = _naviParam.strEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            // 年月.
            param.yymm = txtYm.Value;
            // 請求先部門.
            param.bumonCd = cmbBumon.SelectedValue.ToString();
            // 出力No.
            param.outputNo = txtOutPutNo.Text.Trim();

            //実行.
            ReportKmnProcessController processController = ReportKmnProcessController.GetInstance();
            FindReportKmnByCondServiceResult result = processController.FindReportKmnByCond(param);

            repDSKmn.RepKmnMeisai.Clear();

            ////データが存在しなければ終了.
            if (result.ReportDataSet.RepKmnMeisai.Rows.Count == 0)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();

                dgvMain_Sheet1.RowCount = 0;
                btnXls.Enabled = false;
                btnUpdateCheck.Enabled = false;
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);
                return;
            }

            //データグリッド初期化.
            dgvMain_Sheet1.RowCount = 0;
            // 宛名、請求年月格納用変数初期化.
            AtNm = "";
            /* 2013/07/18 請求年月表示方法修正対応 HLC H.Watabe ADD Start */
            YYMM = "";
            /* 2013/07/18 請求年月表示方法修正対応 HLC H.Watabe ADD End */

            // No表示用.
            int No = 1;
            // 表示行用.
            int row = 0;
            // 5行カウント用.
            int rowCount = 0;
            // ステータスバー表示件数用.
            int stsBarRow = 0;
            // 小計計算用.
            decimal S_kingaku = 0;
            // 合計計算用.
            decimal G_kingaku = 0;
            // 受注Noの重複チェック用.
            List<string> jyuChk = new List<string>();
            // 受注明細Noの重複チェック用.
            List<string> jyumChk = new List<string>();
            // 売上明細Noの重複チェック用.
            List<string> urimChk = new List<string>();

            // セルタイプ変更用.
            FarPoint.Win.Spread.CellType.TextCellType txtType = new FarPoint.Win.Spread.CellType.TextCellType();
            txtType.ReadOnly = true;
            FarPoint.Win.Spread.CellType.CheckBoxCellType chkType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();

            // データグリッドに表示(件数分表示).
            for (int i = 0; i < result.ReportDataSet.RepKmnMeisai.Rows.Count; i++)
            {
                // 受注No、受注明細No、売上明細Noの重複チェック.
                if (jyuChk.Contains(result.ReportDataSet.RepKmnMeisai[i].jyutyuNo + result.ReportDataSet.RepKmnMeisai[i].jyuMeiNo + result.ReportDataSet.RepKmnMeisai[i].uriMeiNo))
                {
                    // すでに出力した受注データの場合は出力処理スキップ.
                    continue;
                }
                else
                {
                    // 1行追加.
                    dgvMain_Sheet1.Rows.Add(dgvMain_Sheet1.RowCount, 1);

                    // 一時的にセルタイプをテキストに変更したのを元のチェックボックスに戻す.
                    dgvMain_Sheet1.Cells[row, COLIDX_CHKBOX].CellType = chkType;

                    // 出力Noで検索している場合はチェックボックスをデフォルトでONにする.
                    if (txtOutPutNo.Text.Trim() != "")
                    {
                        dgvMain_Sheet1.Cells[row, COLIDX_CHKBOX].Value = true;
                    }

                    // 年月の重複チェック.
                    if (!yymmList.Contains(result.ReportDataSet.RepKmnMeisai[i].yyyymm))
                    {
                        // リストに格納されていない年月の場合、リストに追加.
                        yymmList.Add(result.ReportDataSet.RepKmnMeisai[i].yyyymm);
                    }
                    
                    dgvMain_Sheet1.Cells[row, COLIDX_NO].Value = No;
                    dgvMain_Sheet1.Cells[row, COLIDX_YYYYMM].Value = result.ReportDataSet.RepKmnMeisai[i].yyyymm;
                    dgvMain_Sheet1.Cells[row, COLIDX_JYUTNO].Value = result.ReportDataSet.RepKmnMeisai[i].jyutyuNo;
                    dgvMain_Sheet1.Cells[row, COLIDX_JYUMEINO].Value = result.ReportDataSet.RepKmnMeisai[i].jyuMeiNo;
                    dgvMain_Sheet1.Cells[row, COLIDX_URIMEINO].Value = result.ReportDataSet.RepKmnMeisai[i].uriMeiNo;
                    dgvMain_Sheet1.Cells[row, COLIDX_OUTPUTNO].Value = result.ReportDataSet.RepKmnMeisai[i].outputNo;
                    dgvMain_Sheet1.Cells[row, COLIDX_SEIHAKKO].Value = result.ReportDataSet.RepKmnMeisai[i].seiZumi;
                    dgvMain_Sheet1.Cells[row, COLIDX_HINMOKU1].Value = result.ReportDataSet.RepKmnMeisai[i].hinmoku1;
                    dgvMain_Sheet1.Cells[row, COLIDX_HINMOKU2].Value = result.ReportDataSet.RepKmnMeisai[i].hinmoku2;
                    dgvMain_Sheet1.Cells[row, COLIDX_HINMOKU3].Value = result.ReportDataSet.RepKmnMeisai[i].hinmoku3;
                    dgvMain_Sheet1.Cells[row, COLIDX_BUMONCD].Value = result.ReportDataSet.RepKmnMeisai[i].bumonCd;
                    dgvMain_Sheet1.Cells[row, COLIDX_BUMONNM].Value = result.ReportDataSet.RepKmnMeisai[i].bumonNm;
                    dgvMain_Sheet1.Cells[row, COLIDX_SZEIGAK].Value = result.ReportDataSet.RepKmnMeisai[i].sZeiGak;

                    // 出力Noが指定されている時だけ宛名と請求月をDBから取得.
                    if (txtOutPutNo.Text.Trim().Length > 0)
                    {
                        // 部門略称.
                        if (result.ReportDataSet.RepKmnMeisai[i].bumonCd !="") 
                        {
                            AtNm = (string)htAtesaki[result.ReportDataSet.RepKmnMeisai[i].bumonCd];
                            BmNm = result.ReportDataSet.RepKmnMeisai[i].bumonNm;
                            
                        }
                        /* 2013/07/18 請求年月表示方法修正対応 HLC H.Watabe ADD Start */
                        //請求年月.
                        if (!result.ReportDataSet.RepKmnMeisai[i].seikyuYm.Equals(string.Empty))
                        {
                            YYMM = result.ReportDataSet.RepKmnMeisai[i].seikyuYm;
                        }
                        /* 2013/07/18 請求年月表示方法修正対応 HLC H.Watabe ADD End */
                            
                    }
                    // 消費税額を取得.
                    decimal zei = KKHUtility.DecParse(dgvMain_Sheet1.Cells[row, COLIDX_SZEIGAK].Value.ToString());

                    // 金額を取得.
                    decimal kingaku_tmp = KKHUtility.DecParse(result.ReportDataSet.RepKmnMeisai[i].kingaku);
                    
                    // 税込金額を設定する.
                    dgvMain_Sheet1.Cells[row, COLIDX_KINGAK].Value = zei + kingaku_tmp;

                    // １行ずつ金額を取得.
                    decimal kingaku = KKHUtility.DecParse(dgvMain_Sheet1.Cells[row, COLIDX_KINGAK].Value.ToString());

                    // 小計を足しこむ.
                    S_kingaku = S_kingaku + kingaku;

                    //売上明細Noをチェック用リストに格納.
                    jyuChk.Add(dgvMain_Sheet1.Cells[row, COLIDX_JYUTNO].Value.ToString() +
                               dgvMain_Sheet1.Cells[row, COLIDX_JYUMEINO].Value.ToString() +
                               dgvMain_Sheet1.Cells[row, COLIDX_URIMEINO].Value.ToString());

                    // 表示行用カウントアップ.
                    row++;

                    // 5行カウント用カウントアップ.
                    rowCount++;

                    // ステータスバー表示件数用カウントアップ.
                    stsBarRow++;

                    // 5行表示したら小計行を追加.
                    if (rowCount == 5)
                    {
                        // 1行追加.
                        dgvMain_Sheet1.AddRows(dgvMain_Sheet1.RowCount, 1);
                        // 小計表示.
                        dgvMain_Sheet1.Cells[row, COLIDX_BUMONNM].Value = "小計";
                        dgvMain_Sheet1.Cells[row, COLIDX_KINGAK].Value = S_kingaku;

                        // チェックボックスは表示しないため一時的にセルタイプをテキストに変更.
                        dgvMain_Sheet1.Cells[row, COLIDX_CHKBOX].CellType = txtType;

                        // 合計計算.
                        G_kingaku = G_kingaku + S_kingaku;

                        // No表示用ウントアップ.
                        No++;
                        // 表示行用カウントアップ.
                        row++;
                        // 5行カウント用初期化.
                        rowCount = 0;
                        // 小計計算用初期化.
                        S_kingaku = 0;
                    }
                }
            }

            // 5行に満たなかった場合の小計行を追加.
            if (rowCount > 0)
            {
                // 1行追加.
                dgvMain_Sheet1.AddRows(dgvMain_Sheet1.RowCount, 1);
                // 追加行位置.
                int S_addrow = dgvMain_Sheet1.RowCount - 1;
                // 小計表示.
                dgvMain_Sheet1.Cells[S_addrow, COLIDX_BUMONNM].Value = "小計";
                dgvMain_Sheet1.Cells[S_addrow, COLIDX_KINGAK].Value = S_kingaku;

                // チェックボックスは表示しないため一時的にセルタイプをテキストに変更.
                dgvMain_Sheet1.Cells[S_addrow, COLIDX_CHKBOX].CellType = txtType;

                // 合計計算.
                G_kingaku = G_kingaku + S_kingaku;
                // 5行カウント用初期化.
                rowCount = 0;
                // 小計計算用初期化.
                S_kingaku = 0;
            }

            // 合計行を追加.
            dgvMain_Sheet1.AddRows(dgvMain_Sheet1.RowCount, 1);
            // 追加行位置.
            int G_addrow = dgvMain_Sheet1.RowCount - 1;

            // 合計表示.
            dgvMain_Sheet1.Cells[G_addrow, COLIDX_BUMONNM].Value = "合計";
            dgvMain_Sheet1.Cells[G_addrow, COLIDX_KINGAK].Value = G_kingaku;

            // チェックボックスは表示しないため一時的にセルタイプをテキストに変更.
            dgvMain_Sheet1.Cells[G_addrow, COLIDX_CHKBOX].CellType = txtType;

            // 帳票出力ボタンを活性化.
            btnXls.Enabled = true;
            // 受注チェックボタンを活性化.
            btnUpdateCheck.Enabled = true;

            //件数表示.
            statusStrip1.Items["tslval1"].Text = stsBarRow + "件";

            //選択状態を解除.
            this.ActiveControl = null;

            //ローディング表示終了.
            base.CloseLoadingDialog();
        }
        #endregion 検索メソッド.

        #region Excel出力メソッド.
        /// <summary>
        /// Excel出力メソッド.
        /// </summary>
        /// <param name="filnm">ファイル</param>
        /// <param name="repInfo">帳票出力設定情報</param>
        private void ExcelOut(string filnm, Common.KKHSchema.Common.SystemCommonRow repInfo)
        {
            // 帳票出力用変数.
            string workFolderPath = repInfo.field2;
            string excelFile = string.Empty;
            string macroFile = workFolderPath + REP_MACRO_FILENAME;
            string templFile = string.Empty;
            string reportKbn = string.Empty;
            string atenaName = string.Empty;
            /* 2013/07/18 請求年月表示方法修正対応 HLC H.Watabe ADD Start */
            string seikyuYm = string.Empty;
            /* 2013/07/18 請求年月表示方法修正対応 HLC H.Watabe ADD End */
            string nohinbi = string.Empty;
            DataRow dtRow;
            // チェック用変数.
            bool chkflg = false;

            try
            {
                // 出力Noが指定されている時だけ宛名と請求年月をDBから取得した値を設定.
                if (txtOutPutNo.Text.Trim().Length > 0)
                {
                    atenaName = AtNm;
                    /* 2013/07/18 請求年月表示方法修正対応 HLC H.Watabe ADD Start */
                    seikyuYm = YYMM;
                    /* 2013/07/18 請求年月表示方法修正対応 HLC H.Watabe ADD End */
                }
                else
                {
                    // 選択されている請求先部門の宛名を取得.

                    string bumonCD = cmbBumon.SelectedValue.ToString();
                    if (bumonCD == "")
                    {
                        atenaName = " ";
                    }
                    else
                    {
                        atenaName = (string)htAtesaki[bumonCD];
                    }
                    /* 2013/07/18 請求年月表示方法修正対応 HLC H.Watabe ADD Start */
                    seikyuYm = txtYm.Value.ToString();
                    /* 2013/07/18 請求年月表示方法修正対応 HLC H.Watabe ADD End */
                }

                // 請求年月の月末日を取得.
                /* 2013/07/18 請求年月表示方法修正対応 HLC H.Watabe MOD Start */
                //int i_year = KKHUtility.IntParse(txtYm.Value.Substring(0, 4));
                //int i_month = KKHUtility.IntParse(txtYm.Value.Substring(4, 2));
                int i_year = KKHUtility.IntParse(seikyuYm.Substring(0, 4));
                int i_month = KKHUtility.IntParse(seikyuYm.Substring(4, 2));
                /* 2013/07/18 請求年月表示方法修正対応 HLC H.Watabe MOD End */
                int i_day = DateTime.DaysInMonth(i_year, i_month);
                // 形式変更.
                nohinbi = i_year.ToString() + "/" + i_month.ToString() + "/" + i_day.ToString();

                // Excel開始処理.
                templFile = workFolderPath + REP_TEMPLATE_FILENAMEM;
                File.WriteAllBytes(templFile, Resources.Kmn_Template);

                // リソースからExcelファイルを作成(マクロ).
                File.WriteAllBytes(macroFile, Resources.Kmn_Mcr);
                if (File.Exists(templFile) == false)
                {
                    throw new Exception("テンプレートExcelファイルがありません。");
                }
                if (File.Exists(macroFile) == false)
                {
                    throw new Exception("マクロExcelファイルがありません。");
                }

                // データセットXML出力.
                // XMLにはすべてのデータを出力するが伝票に出力するのはチェックが入っているデータのみ(マクロ側で制御).
                repDSKmn.RepKmnMeisai.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));

                // パラメータXML作成、出力.
                // 変数の宣言.
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // データセットにテーブルを追加する.
                // PRODUCTSというテーブルを作成します.
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add(PARAM_SAVEDIR, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_YYYYMM, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_PASSWORD, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_USERNAME, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_ATENA, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_NOHINNAME, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_TOROKCODE, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_ADDRESS, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_NOHINDATE, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_PRINTERNM, Type.GetType("System.String"));

                //テーブルにデータを追加する.
                dtRow = dtTable.NewRow();
                dtRow[PARAM_SAVEDIR] = filnm;               // 保存ファイル名(フルパス).
                dtRow[PARAM_YYYYMM] = txtYm.Value;          // 年月.
                dtRow[PARAM_PASSWORD] = repInfo.field3;     // シート保護用パスワード.
                dtRow[PARAM_USERNAME] = tslName;            // ユーザー名称.
                dtRow[PARAM_ATENA] = atenaName;             // 宛名.
                dtRow[PARAM_NOHINNAME] = repInfo.field5;    // 納品者.
                dtRow[PARAM_TOROKCODE] = repInfo.field9;    // 登録コード.
                dtRow[PARAM_ADDRESS] = repInfo.field10;     // 住所.
                dtRow[PARAM_NOHINDATE] = nohinbi;           // 納品日.
                dtRow[PARAM_PRINTERNM] = repInfo.field7;    // プリンタ名.

                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //エクセル起動.
                System.Diagnostics.Process.Start("excel", macroFile);

                //削除用に保持(戻るボタン押下時に削除する為).
                _strmacrodel = macroFile;

                // オペレーションログの出力.
                KKHLogUtilityKmn.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityKmn.KINO_ID_OPERATION_LOG_ReportDEN, KKHLogUtilityKmn.DESC_OPERATION_LOG_ReportDEN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Excel出力メソッド.

        #region 帳票出力設定情報取得メソッド.
        /// <summary>
        /// 帳票出力設定情報取得メソッド.
        /// </summary>
        /// <returns>帳票出力設定情報</returns>
        private Common.KKHSchema.Common.SystemCommonRow GetReportInfo(string sybt, string key)
        {
            //種別:"002"or"003".
            string strsybt = sybt; 
            string strkey = string.Empty;

            if (!key.Equals(""))
            {
                strkey = key;
            }
            Common.KKHSchema.Common.SystemCommonRow ret;
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult;

            // 帳票設定情報取得.
            comResult = commonProcessController.FindCommonByCond(_naviParam.strEsqId,
                                                                _naviParam.strEgcd,
                                                                _naviParam.strTksKgyCd,
                                                                _naviParam.strTksBmnSeqNo,
                                                                _naviParam.strTksTntSeqNo,
                                                                strsybt,
                                                                strkey);

            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                ret = comResult.CommonDataSet.SystemCommon[0];
            }
            else
            {
                // 取得できなかった場合はデフォルト値を設定.
                Common.KKHSchema.Common.SystemCommonDataTable dt = new Common.KKHSchema.Common.SystemCommonDataTable();
                ret = (Common.KKHSchema.Common.SystemCommonRow)dt.NewRow();

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ret[i] = string.Empty;
                }

                if (sybt.Equals(KV7_SYBT))
                {
                    // 以下、空文字以外をデフォルト値として設定.
                    ret.field2 = SFD_INITDIRTMP;    // 保存先パス(テンプレート).
                    ret.field3 = DEF_PASSWORD;      // シート保護用パスワード.
                }
                else
                {
                    // 以下、空文字以外をデフォルト値として設定.
                    ret.field2 = SFD_INITDIR;       // 保存先パス(エクセルファイル)
                }
            }

            return ret;
        }
        #endregion 帳票出力設定情報取得メソッド.

        #region 営業日を取得.
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
        #endregion 営業日を取得.
        #endregion メソッド.
    }
}