using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using Isid.KKH.Kmn.Utility;
using Isid.NJ.View.Widget;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Kmn.ProcessController.Report;
using Isid.KKH.Kmn.Properties;
using Isid.KKH.Kmn.View.Detail;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;

namespace Isid.KKH.Kmn.View.Report
{
    /// <summary>
    /// 帳票出力画面(公文_請求明細一覧).
    /// </summary>
    public partial class ReportKmnList : KKHForm
    {
        #region 定数.
        /// <summary>
        /// 選択列インデックス.
        /// </summary>
        private const int COLIDX_SNTK = 0;
        /// <summary>
        /// 出力No列インデックス.
        /// </summary>
        private const int COLIDX_SHUTNO = 1;
        /// <summary>
        /// 請求書発行列インデックス.
        /// </summary>
        private const int COLIDX_SEIHAKKO = 2;
        /// <summary>
        /// シークエンスNo列インデックス.
        /// </summary>
        private const int COLIDX_SEQNO = 3;
        /// <summary>
        /// 受注No列インデックス.
        /// </summary>
        private const int COLIDX_JYTNO = 4;
        /// <summary>
        /// 受注明細No列インデックス.
        /// </summary>
        private const int COLIDX_JYMEINO = 5;
        /// <summary>
        /// 売上明細No列インデックス.
        /// </summary>
        private const int COLIDX_URMEINO = 6;
        /// <summary>
        /// 連番列インデックス.
        /// </summary>
        private const int COLIDX_RENBAN = 7;
        /// <summary>
        /// 内容列インデックス.
        /// </summary>
        private const int COLIDX_NAIYO = 8;
        /// <summary>
        /// 費目列インデックス.
        /// </summary>
        private const int COLIDX_HIMOKU = 9;
        /// <summary>
        /// 部門コード列インデックス.
        /// </summary>
        private const int COLIDX_BMNCD = 10;
        /// <summary>
        /// 部門名列インデックス.
        /// </summary>
        private const int COLIDX_BMNNM = 11;
        /// <summary>
        /// 宛先列インデックス.
        /// </summary>
        private const int COLIDX_ATESAKI = 12;
        /// <summary>
        /// 期間列インデックス.
        /// </summary>
        private const int COLIDX_KIKAN = 13;
        /// <summary>
        /// 金額列インデックス.
        /// </summary>
        private const int COLIDX_KNGK = 14;
        /// <summary>
        /// 備考列インデックス.
        /// </summary>
        private const int COLIDX_BIKO = 15;
        /// チェックボックス設定値.
        /// </summary>
        private bool _checkBoxValue = true;
        /// <summary>
        /// 部門コード.
        /// </summary>
        private string BumonCD = "";
        /// <summary>
        /// 保存先用(テンプレート)変数.
        /// </summary>
        private string pStrRepTempAdrs = "";
        /// <summary>
        /// 保存先用変数.
        /// </summary>
        private string pStrRepAdrs = "";
        /// <summary>
        /// 帳票名(保存で使用)用変数.
        /// </summary>
        private string pStrRepFilNam = "請求一覧";
        /// <summary>
        /// 保持用データセット.
        /// </summary>
        private DataSet tohds = null;
        /// <summary>
        /// 検索データ保持用Hashtable.
        /// 再利用するデータ(マスタデータ等)を保持.
        /// マスタデータ.
        /// </summary>
        Hashtable htMasterData = new Hashtable();
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
        private const string SFD_FILTER = "XLSX、XLSMファイル(*.xlsx;*.xlsm)|*.xlsx;*.xlsm";
        /// <summary>
        /// 帳票出力_タイトル.
        /// </summary>
        private const string SFD_TITLE = "保存先のファイルを設定して下さい。";
        /// <summary>
        /// XMLファイル名(データ用).
        /// </summary>
        private const string REP_XML_FILENAME = "KmnList_Data.xml";
        /// <summary>
        /// XMLファイル名(プロパティ用).
        /// </summary>
        private const string REP_XML2_FILENAME = "KmnList_Prop.xml";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private const string REP_TEMPLATE_FILENAME = "KmnList_Template.xlsx";
        /// <summary>
        /// Excel(帳票出力マクロ実装)ファイル名.
        /// </summary>
        private const string REP_MACRO_FILENAME = "KmnList_Mcr.xlsm";
        /// <summary>
        /// 帳票設定情報取得キー：002.
        /// </summary>
        private const string KV7_SYBT = "002";
        /// <summary>
        /// 帳票設定情報取得キー：003.
        /// </summary>
        private const string KV7_SYBTSUB = "003";
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
        /// 帳票パラメータ：ユーザー名称.
        /// </summary>
        private const string PARAM_USERNAME = "USERNAME";
        /// <summary>
        /// 帳票パラメータ：合計金額.
        /// </summary>
        private const string PARAM_GOKEIKNGK = "GOKEIKNGK";
        /// <summary>
        /// 帳票パラメータ：請求先部門.
        /// </summary>
        private const string PARAM_BMN = "BMN";
        /// <summary>
        /// 帳票パラメータ：出力No.
        /// </summary>
        private const string PARAM_SHUTNO = "SHUTNO";
        /* 2015/04/01 公文得意先変更対応 HLC K.Fujisaki ADD Start */
        /// <summary>
        /// 帳票パラメータ：得意先企業名称.
        /// </summary>
        private const string PARAM_TKSKGYNAME = "TKSKGYNAME";
        /* 2015/04/01 公文得意先変更対応 HLC K.Fujisaki ADD End */
        /// <summary>
        /// シート保護用パスワードのデフォルト値.
        /// </summary>
        private const string DEF_PASSWORD = "ks1dms";
        /// <summary>
        /// 出力単位：統合.
        /// </summary>
        private const string OUTPUT_TOU = "統合";
        /// <summary>
        /// 出力単位：明細.
        /// </summary>
        private const string OUTPUT_MEI = "明細";
        #endregion 定数.

        #region メンバ変数.
        /// <summary>
        /// Rgナビパラメータ.
        /// </summary>
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();
        /// <summary>
        /// コピーマクロ削除用.
        /// </summary>
        private string _strmacrodel;

        #region 操作ログ出力用定数.
        /// <summary>
        /// アプリID.
        /// </summary>
        private const String APLID = "Report";
        #endregion 操作ログ出力用定数.
        #endregion メンバ変数.

        #region コンストラクタ.
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public ReportKmnList()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ.

        #region イベント.
        #region 画面遷移するたびに発生します.
        /// <summary>
        /// 画面遷移するたびに発生します.
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void ReportKmn_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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
        #endregion 画面遷移するたびに発生します.

        #region フォームロードイベント.
        /// <summary>
        /// フォームロードイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportKmn_Load(object sender, EventArgs e)
        {
            this.InitializeControl();
        }
        #endregion フォームロードイベント.

        #region ボタンMouseMoveイベント.
        /// <summary>
        /// ボタンMouseMoveイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            tslCnt.Text = njToolTip1.GetToolTip((Control)sender);
        }
        #endregion ボタンMouseMoveイベント.

        #region ボタンMouseLeaveイベント.
        /// <summary>
        /// ボタンMouseLeaveイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            tslCnt.Text = String.Empty;
        }
        #endregion ボタンMouseLeaveイベント.

        #region 表示ボタンクリックイベント.
        /// <summary>
        /// 表示ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            // データ検索.
            if (0 < this.FindReportData())
            {
                decimal kngk = 0;

                // データが存在した場合、金額の合計を計算する.
                for (int iRow = 0; iRow < _spdReport_Sheet1.Rows.Count; iRow++)
                {
                    _spdReport_Sheet1.Cells[iRow, COLIDX_ATESAKI].Value = GetAtesaki(_spdReport_Sheet1.Cells[iRow, COLIDX_BMNCD].Text.ToString());
                    kngk += KKHUtility.DecParse(_spdReport_Sheet1.Cells[iRow, COLIDX_KNGK].Text.ToString());
                }

                //出力件数を表示.
                statusStrip1.Items["tslval1"].Text = _spdReport_Sheet1.Rows.Count.ToString() + "件";

                //合計金額を表示.
                _spdReport_Sheet1.AddRows(_spdReport_Sheet1.Rows.Count , 1);
                _spdReport_Sheet1.Cells[_spdReport_Sheet1.Rows.Count - 1 , COLIDX_KIKAN].Value = "合計金額";
                _spdReport_Sheet1.Cells[_spdReport_Sheet1.Rows.Count - 1, COLIDX_KNGK].Value = KKHUtility.DecParse(kngk.ToString());
                _spdReport_Sheet1.Cells[_spdReport_Sheet1.Rows.Count - 1, COLIDX_SNTK].CellType = new TextCellType();
                _spdReport_Sheet1.Cells[_spdReport_Sheet1.Rows.Count - 1, COLIDX_SNTK].Locked = true;

                //帳票出力ボタンを使用可に変更.
                btnXls.Enabled = true;
            }
            else
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();

                btnXls.Enabled = false;
                statusStrip1.Items["tslval1"].Text = "0件";
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "帳票", MessageBoxButtons.OK);
            }

            //選択状態を解除.
            this.ActiveControl = null;

            //ローディング表示終了.
            base.CloseLoadingDialog();
        }
        #endregion 表示ボタンクリックイベント.

        #region 帳票出力ボタンクリックイベント.
        /// <summary>
        /// 帳票出力ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            bool flgChk = false;

            for (int iRow = 0; iRow < _spdReport_Sheet1.Rows.Count - 1; iRow++)
            {
                if (_spdReport_Sheet1.Cells[iRow, COLIDX_SNTK].Text == "True")
                {
                    flgChk = true;
                }
            }
            if (flgChk == false)
            {
                //出力対象データを選択してください.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0160, null, "請求明細一覧", MessageBoxButtons.OK);

                //選択状態を解除.
                this.ActiveControl = null;
                return;
            }
             
            /* 2013/04/19 HLC T.Sonobe ADD Start */
            if (ckbFin.Checked == false && cmbOutTanni.SelectedIndex == 0)
            {
                //「最終版」にチェック確認.
                DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0095,
                                                               new string[] { "「最終版」にチェックがついていませんが出力してもよろしいでしょうか。"
                                                                               + "\r\n" + "※出力Ｎｏが採番されません" }
                                                               , "請求明細一覧", MessageBoxButtons.YesNo);
                if (check != DialogResult.Yes)
                {
                    return;
                }
            }
            /* 2013/04/19 HLC T.Sonobe ADD End */

            // 帳票設定情報取得(テンプレート保存場所、パスワード等). 
            Common.KKHSchema.Common.SystemCommonRow repInfo = this.GetReportInfo(KV7_SYBT);
            // 帳票設定情報取得(ファイル初期保存場所).
            Common.KKHSchema.Common.SystemCommonRow repInfoSub = this.GetReportInfo(KV7_SYBTSUB);

            // SaveFileDialogクラスのインスタンスを作成.
            SaveFileDialog sfd = new SaveFileDialog();

            /* 2013/04/19 ファイル名最終版追加 HLC T.Sonobe MOD Start */
            //if (cmbBusho.Text.Trim() == "")
            //{
            //    sfd.FileName = repInfoSub.field3 + "_" + txtYm.Value + SFD_EXT;
            //}
            //else
            //{
            //    sfd.FileName = repInfoSub.field3 + "_" + cmbBusho.Text.ToString()
            //                                + "_" + txtYm.Value + SFD_EXT;
            //}
            if (ckbFin.Checked == false)
            {
                if (cmbBusho.Text.Trim() == "")
                {
                    sfd.FileName = repInfoSub.field3 + "_" + txtYm.Value + SFD_EXT;
                }
                else
                {
                    sfd.FileName = repInfoSub.field3 + "_" + cmbBusho.Text.ToString()
                                                + "_" + txtYm.Value + SFD_EXT;
                }
            }
            else
            {
                if (cmbBusho.Text.Trim() == "")
                {
                    sfd.FileName = repInfoSub.field3 + "_" + txtYm.Value + repInfoSub.field4 + SFD_EXT;
                }
                else
                {
                    sfd.FileName = repInfoSub.field3 + "_" + cmbBusho.Text.ToString()
                                                + "_" + txtYm.Value + repInfoSub.field4 + SFD_EXT;
                }
            }
            /* 2013/04/19 ファイル名最終版追加 HLC T.Sonobe MOD End */

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

        #region 戻るボタンクリックイベント.
        /// <summary>
        /// 戻るボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (_strmacrodel != null)
            {
                FileInfo cFileInfo = new FileInfo(_strmacrodel);

                // マクロファイルの削除(VBA側では削除できない為).
                // ファイルが存在しているか判断する.
                if (cFileInfo.Exists)
                {
                    // 読み取り専用属性がある場合は、読み取り専用属性を解除する.
                    if ((cFileInfo.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        cFileInfo.Attributes = FileAttributes.Normal;
                    }

                    // ファイルを削除する.
                    cFileInfo.Delete();
                }
            }

            Navigator.Backward(this, null, _naviParameter, true);
        }
        #endregion 戻るボタンクリックイベント.

        #region ヘルプボタンクリック処理.
        /// <summary>
        /// ヘルプボタンクリック処理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = _naviParameter.strTksKgyCd + _naviParameter.strTksBmnSeqNo + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();

            //実行.
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Report, this, HelpNavigator.KeywordIndex);
            this.ActiveControl = null;
        }
        #endregion ヘルプボタンクリック処理.

        #region 年月コンボボックスのチェンジイベント.
        /// <summary>
        /// 年月コンボボックスのチェンジイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void condChg(object sender, EventArgs e)
        {
            //[帳票出力]ボタンを非活性とする.
            btnXls.Enabled = false;
        }
        #endregion 年月コンボボックスのチェンジイベント.

        #region 部署コンボボックスのチェンジイベント.
        /// <summary>
        /// 部署コンボボックスのチェンジイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBushoChg(object sender, EventArgs e)
        {
            //[帳票出力]ボタンを非活性とする.
            btnXls.Enabled = false;
        }
        #endregion 部署コンボボックスのチェンジイベント.

        #region 出力単位コンボボックスのチェンジイベント.
        /// <summary>
        /// 出力単位コンボボックスのチェンジイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbOutTanniChg(object sender, EventArgs e)
        {
            //[帳票出力]ボタンを非活性とする.
            btnXls.Enabled = false;
        }
        #endregion 出力単位コンボボックスのチェンジイベント.

        #region 最終版チェックボックスのチェンジイベント.
        /// <summary>
        /// 最終版チェックボックスのチェンジイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbFinChg(object sender, EventArgs e)
        {
        }
        #endregion 最終版チェックボックスのチェンジイベント.

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
                if (e.Column == COLIDX_SNTK)
                {
                    //データ件数分、繰り返す.
                    for (int row = 0; row < _spdReport_Sheet1.RowCount - 1; row++)
                    {
                        //チェックボックスの設定.
                        _spdReport_Sheet1.Cells[row, e.Column].Value = _checkBoxValue;
                    }

                    //次回用にチェックボックスの値を更新.
                    _checkBoxValue = !_checkBoxValue;
                }
            }
        }
        #endregion スプレッドダブルクリックイベント.

        #region スプレッドボタンクリックイベント.
        /// <summary>
        /// スプレッドボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdReport_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            //選択列の場合.
            if (e.Column == COLIDX_SNTK)
            {
                //データ件数分、繰り返す.
                for (int row = 0; row < _spdReport_Sheet1.RowCount - 1; row++)
                {
                    if (_spdReport_Sheet1.Cells[e.Row, COLIDX_JYTNO].Text == _spdReport_Sheet1.Cells[row, COLIDX_JYTNO].Text)
                    {
                        if (_spdReport_Sheet1.Cells[e.Row, COLIDX_JYMEINO].Text == _spdReport_Sheet1.Cells[row, COLIDX_JYMEINO].Text)
                        {
                            if (_spdReport_Sheet1.Cells[e.Row, COLIDX_URMEINO].Text == _spdReport_Sheet1.Cells[row, COLIDX_URMEINO].Text)
                            {
                                _spdReport_Sheet1.Cells[row, COLIDX_SNTK].Text = _spdReport_Sheet1.Cells[e.Row, COLIDX_SNTK].Text;
                            }
                        }
                    }
                
                }
            }
        }
        #endregion スプレッドボタンクリックイベント.
        #endregion イベント.

        #region メソッド.
        #region 各コントロールの初期設定.
        /// <summary>
        /// 各コントロールの初期設定.
        /// </summary>
        private void InitializeControl()
        {
            string yyyymm = _naviParameter.strDate.Replace("/", string.Empty);

            // ステータス設定.
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

            //スプレッド各項目の初期設定.
            //シークエンスNo(出力No下4桁).
            _spdReport_Sheet1.SetColumnVisible(COLIDX_SEQNO, false);
            //受注No.
            _spdReport_Sheet1.SetColumnVisible(COLIDX_JYTNO, false);
            //受注明細No.
            _spdReport_Sheet1.SetColumnVisible(COLIDX_JYMEINO, false);
            //売上明細No.
            _spdReport_Sheet1.SetColumnVisible(COLIDX_URMEINO, false);
            //連番.
            _spdReport_Sheet1.SetColumnVisible(COLIDX_RENBAN, false);
            //番組コード.
            _spdReport_Sheet1.SetColumnVisible(COLIDX_BMNCD, false);
            //宛先.
            _spdReport_Sheet1.SetColumnVisible(COLIDX_ATESAKI, false);

            //部署名をコンボボックスにセットする.
            SetBumonCmb();

            //出力単位をコンボボックスにセットする.
            SetOutPutCmb();
        }
        #endregion 各コントロールの初期設定.

        #region 部署名をコンボボックスにセットする.
        /// <summary>
        /// 部署名をコンボボックスにセットする.
        /// </summary>
        private void SetBumonCmb()
        {
            MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();

            FindMasterMaintenanceByCondServiceResult result;

            // 部門名.
            cmbBusho.Items.Clear();
            result = process.FindMasterByCond(_naviParameter.strEsqId,
                                            _naviParameter.strEgcd,
                                            _naviParameter.strTksKgyCd,
                                            _naviParameter.strTksBmnSeqNo,
                                            _naviParameter.strTksTntSeqNo,
                                             KkhConstKmn.MasterKey.C_MST_BUMON,
                                            null);

            MasterMaintenance.MasterDataVODataTable dtBumon = new MasterMaintenance.MasterDataVODataTable();
            MasterMaintenance.MasterDataVORow voRow2 = dtBumon.NewMasterDataVORow();
            
            //空行を追加 
            dtBumon.AddMasterDataVORow(voRow2);
            if (result.MasterDataSet.MasterDataVO != null)
            {
                dtBumon.Merge(result.MasterDataSet.MasterDataVO);
            }

            dtBumon.AcceptChanges();

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
            this.cmbBusho.DataSource = dtAtesaki_new;

            //表示される値はDataTableのColumn2列.
            this.cmbBusho.DisplayMember = dtAtesaki_new.Column2Column.ColumnName;
            //表示と対応するコード値はDataTableのColumn1列.
            this.cmbBusho.ValueMember = dtAtesaki_new.Column1Column.ColumnName;


            ////コンボボックスのDataSourceにDataTableを割り当てる.
            //this.cmbBusho.DataSource = dtBumon;
            ////表示される値はDataTableのColumn2列(部門名).
            //this.cmbBusho.DisplayMember = dtBumon.Column2Column.ColumnName;
            ////表示と対応するコード値はDataTableのColumn1列(部門コード).
            //this.cmbBusho.ValueMember = dtBumon.Column1Column.ColumnName;
            /* 2013/04/23 部署名の重複表示排除対応 JSE M.Naito MOD End */

            htMasterData[KkhConstKmn.MasterKey.C_MST_BUMON] = result.MasterDataSet.MasterDataVO;
        }
        #endregion 部署名をコンボボックスにセットする.

        #region 出力単位をコンボボックスにセットする.
        /// <summary>
        /// 出力単位をコンボボックスにセットする.
        /// </summary>
        private void SetOutPutCmb()
        {
            //値の設定.
            this.cmbOutTanni.Items.Add(OUTPUT_TOU);
            this.cmbOutTanni.Items.Add(OUTPUT_MEI);

            // デフォルト表示を「統合」設定.
            this.cmbOutTanni.SelectedIndex = 0;

        }
        #endregion 出力単位をコンボボックスにセットする.

        #region 宛先を取得する.
        /// <summary>
        /// 宛先を取得する.
        /// </summary>
        private String GetAtesaki(String bushoCd)
        {
            Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable rv;
            rv = (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable)htMasterData[KkhConstKmn.MasterKey.C_MST_BUMON];

            for (int i = 0; i < rv.Rows.Count; i++)
            {
                //部署コードが一致したら、宛先を返す.
                if (rv[i].Column1 == bushoCd)
                {
                    return rv[i].Column3;
                }
            }
            return String.Empty;
        }
        #endregion 宛先を取得する.

        #region 部署コンボボックスを変更するときに発生します.
        /// <summary>
        /// 部署コンボボックスを変更するときに発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBusho_SelectedIndexChanged(object sender, EventArgs e)
        {
            BumonCD = "";

            //選択されていればSelectedValueに入っている.
            if (cmbBusho.SelectedIndex != 0)
            {
                //部門コードを取得.
                BumonCD = cmbBusho.SelectedValue.ToString();
            }
        }
        #endregion 部署コンボボックスを変更するときに発生します.

        #region 出力単位コンボボックスを変更するときに発生します.
        /// <summary>
        /// 出力単位コンボボックスを変更するときに発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbOutTanni_SelectedIndexChanged(object sender, EventArgs e)
        {

            // 統合が選択された場合.
            if (cmbOutTanni.SelectedIndex == 0)
            {
                // 最終版チェックボックス活性化.
                ckbFin.Enabled = true;
            }
            // 明細が選択された場合.
            else if (cmbOutTanni.SelectedIndex == 1)
            {
                // チェックOFF.
                ckbFin.Checked = false;
                // 最終版チェックボックス非活性化.
                ckbFin.Enabled = false;
            }
        }
        #endregion 出力単位コンボボックスを変更するときに発生します.

        #region データ検索メソッド.
        /// <summary>
        /// データ検索メソッド.
        /// </summary>
        /// <returns>検索結果件数</returns> 
        private int FindReportData()
        {
            ReportKmnListProcessController.FindReportKmnListByCondParam param = new ReportKmnListProcessController.FindReportKmnListByCondParam();

            // パラメータ設定.
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            // 年月.
            param.yymm = txtYm.Value;
            // 部門コード.
            param.bumonCd = BumonCD;
            // 出力単位.
            param.output = cmbOutTanni.Text;

            // 帳票(公文_請求一覧)データ検索.
            ReportKmnListProcessController processController = ReportKmnListProcessController.GetInstance();
            FindReportKmnListByCondServiceResult result = processController.FindReportKmnByCond(param);

            if (result.HasError == true)
            {
                return 0;
            }

            repDSKmn.RepKmnList.Clear();
            repDSKmn.RepKmnList.Merge(result.ReportDataSet.RepKmnList);
            repDSKmn.RepKmnList.AcceptChanges();

            if (result.ReportDataSet.RepKmnList.Rows.Count == 0)
            {
                // データが存在しない場合は0を返す.
                return 0;
            }

            return result.ReportDataSet.RepKmnList.Rows.Count;
        }
        #endregion データ検索メソッド.

        #region シーケンスNo最大値取得メソッド.
        /// <summary>
        /// シーケンスNo最大値取得メソッド.
        /// </summary>
        /// <returns>シーケンスNo最大値</returns> 
        private String FindMaxSeqNoData()
        {
            ReportKmnListProcessController.FindReportKmnListByCondParam param = new ReportKmnListProcessController.FindReportKmnListByCondParam();

            // パラメータ設定.
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            
            // 請求年月.
            param.yymm = txtYm.Value;

            // シーケンスNo最大値検索.
            ReportKmnListProcessController processController = ReportKmnListProcessController.GetInstance();
            FindReportKmnListByCondServiceResult result = processController.FindMaxSeqNoByCond(param);

            if (result.HasError == true)
            {
                return " ";
            }

            repDSKmn.MaxSeqNo.Clear();
            repDSKmn.MaxSeqNo.Merge(result.ReportDataSet.MaxSeqNo);
            repDSKmn.MaxSeqNo.AcceptChanges();

            if (result.ReportDataSet.MaxSeqNo[0].seqNo == "")
            {
                return " ";
            }

            return result.ReportDataSet.MaxSeqNo[0].seqNo.ToString();
        }
        #endregion シーケンスNo最大値取得メソッド.

        #region 出力No、シーケンスNo、宛先登録メソッド.
        /// <summary>
        /// 出力No、シーケンスNo、宛先登録メソッド.
        /// </summary>
        private void SetSeqNo(string ateName)
        {
            //サービスパラメータ用変数.
            Isid.KKH.Kmn.Schema.RepDSKmn dsRepKmn = new Isid.KKH.Kmn.Schema.RepDSKmn();

            //登録データセット.
            Isid.KKH.Kmn.Schema.RepDSKmn.RepKmnListDataTable dtRepKmnList = new Isid.KKH.Kmn.Schema.RepDSKmn.RepKmnListDataTable();
            for (int i = 0; i < _spdReport_Sheet1.RowCount - 1; i++)
            {
                if (_spdReport_Sheet1.Cells[i, COLIDX_SNTK].Text == "True")
                {
                    Isid.KKH.Kmn.Schema.RepDSKmn.RepKmnListRow addRow = dtRepKmnList.NewRepKmnListRow();

                    addRow.jyutNo = _spdReport_Sheet1.Cells[i, COLIDX_JYTNO].Value.ToString();
                    addRow.jyMeiNo = _spdReport_Sheet1.Cells[i, COLIDX_JYMEINO].Value.ToString();
                    addRow.urMeiNo = _spdReport_Sheet1.Cells[i, COLIDX_URMEINO].Value.ToString();
                    addRow.renBan = _spdReport_Sheet1.Cells[i, COLIDX_RENBAN].Value.ToString();
                    addRow.shutNo = _spdReport_Sheet1.Cells[i, COLIDX_SHUTNO].Value.ToString();
                    addRow.seqNo = _spdReport_Sheet1.Cells[i, COLIDX_SEQNO].Value.ToString();
                    addRow.atesaki = ateName;

                    dtRepKmnList.AddRepKmnListRow(addRow);
                }
            }
            dsRepKmn.RepKmnList.Merge(dtRepKmnList);

            ReportKmnListProcessController.UpdateSeqNoByCondParam param =
                                                         new ReportKmnListProcessController.UpdateSeqNoByCondParam();
            // パラメータ設定.
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = txtYm.Value;

            // シーケンスNo登録・更新.
            ReportKmnListProcessController processController = ReportKmnListProcessController.GetInstance();
            UpdateSeqNoByCondServiceResult result = processController.UpdateSeqNoByCond(param, dsRepKmn);
        }
        #endregion 出力No、シーケンスNo、宛先登録メソッド.

        #region Excel出力メソッド.
        /// <summary>
        /// Excel出力メソッド.
        /// </summary>
        /// <param name="filnm">ファイル</param>
        /// <param name="repInfo">帳票出力設定情報</param>
        private void ExcelOut(string filnm, Common.KKHSchema.Common.SystemCommonRow repInfo)
        {
            string workFolderPath = repInfo.field2;
            string excelFile = string.Empty;
            string macroFile = workFolderPath + REP_MACRO_FILENAME;
            string templFile = workFolderPath + REP_TEMPLATE_FILENAME;
            string reportKbn = string.Empty;

            //シーケンスNo最大値.
            string maxSeqNo;
            //出力No.
            string shutNo = null;
            //シーケンスNo.
            string seqNo = "0001";
            DataRow dtRow;
            decimal goKei = 0;

            //宛先格納用.
            string ateName = "";

            try
            {
                File.WriteAllBytes(templFile, Resources.KmnList_Template);

                // リソースからExcelファイルを作成(マクロ).
                File.WriteAllBytes(macroFile, Resources.KmnList_Mcr);
                if (File.Exists(templFile) == false)
                {
                    throw new Exception("テンプレートExcelファイルがありません。");
                }
                if (File.Exists(macroFile) == false)
                {
                    throw new Exception("マクロExcelファイルがありません。");
                }

                // 宛先を取得.
                ateName = GetAtesaki(BumonCD);

                if (ckbFin.Checked == true)
                {
                    //シーケンスNo最大値を取得.
                    maxSeqNo = FindMaxSeqNoData();
                    //出力Noを採番.
                    if (maxSeqNo == " ")
                    {
                        shutNo = txtYm.Value + seqNo;
                    }
                    else
                    {
                        decimal newSeqNo = KKHUtility.DecParse(maxSeqNo) + 1;
                        seqNo = newSeqNo.ToString("0000");
                        shutNo = txtYm.Value + seqNo;
                    }

                    for (int iRow = 0; iRow < _spdReport_Sheet1.Rows.Count - 1; iRow++)
                    {
                        if (_spdReport_Sheet1.Cells[iRow, COLIDX_SNTK].Text == "True")
                        {
                            //出力Noをセット.
                            _spdReport_Sheet1.Cells[iRow, COLIDX_SHUTNO].Value = shutNo;
                            //シーケンスNoをセット.
                            _spdReport_Sheet1.Cells[iRow, COLIDX_SEQNO].Value = seqNo;
                            //合計金額を計算.
                            goKei += KKHUtility.DecParse(_spdReport_Sheet1.Cells[iRow, COLIDX_KNGK].Text.ToString());
                        }
                        else
                        {
                            _spdReport_Sheet1.Cells[iRow, COLIDX_SNTK].Value = "false";
                        }
                    }

                    //合計金額をセット.
                    _spdReport_Sheet1.Cells[_spdReport_Sheet1.Rows.Count - 1, COLIDX_KNGK].Value = KKHUtility.DecParse(goKei.ToString());

                    //出力No、シーケンスNo、宛先の登録.
                    SetSeqNo(ateName);
                }
                else
                {
                    for (int iRow = 0; iRow < _spdReport_Sheet1.Rows.Count - 1; iRow++)
                    {
                        if (_spdReport_Sheet1.Cells[iRow, COLIDX_SNTK].Text == "True")
                        {
                            goKei += KKHUtility.DecParse(_spdReport_Sheet1.Cells[iRow, COLIDX_KNGK].Text.ToString());
                        }
                        else if (_spdReport_Sheet1.Cells[iRow, COLIDX_SNTK].Value == null)
                        {
                            _spdReport_Sheet1.Cells[iRow, COLIDX_SNTK].Value = "false";
                        }
                    }

                    //合計金額をセット.
                    _spdReport_Sheet1.Cells[_spdReport_Sheet1.Rows.Count - 1, COLIDX_KNGK].Value = KKHUtility.DecParse(goKei.ToString());
                }

                // データセットXML出力.
                repDSKmn.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));

                // パラメータXML作成、出力.
                // 変数の宣言 
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // データセットにテーブルを追加する.
                // PRODUCTSというテーブルを作成します.
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add(PARAM_SAVEDIR, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_YYYYMM, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_PASSWORD, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_USERNAME, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_GOKEIKNGK, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_BMN, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_SHUTNO, Type.GetType("System.String"));
                /* 2015/04/01 公文得意先変更対応 HLC K.Fujisaki ADD Start */
                dtTable.Columns.Add(PARAM_TKSKGYNAME, Type.GetType("System.String"));
                /* 2015/04/01 公文得意先変更対応 HLC K.Fujisaki ADD End */

                //テーブルにデータを追加する.
                dtRow = dtTable.NewRow();

                dtRow[PARAM_SAVEDIR] = filnm;               // 保存ファイル名(フルパス).
                dtRow[PARAM_YYYYMM] = txtYm.Value;          // 年月.
                dtRow[PARAM_PASSWORD] = repInfo.field3;     // シート保護用パスワード.
                dtRow[PARAM_USERNAME] = tslName;            // ユーザー名称.
                //合計金額.
                dtRow[PARAM_GOKEIKNGK] = _spdReport_Sheet1.Cells[_spdReport_Sheet1.RowCount - 1, COLIDX_KNGK].Value.ToString().Trim();

                if (cmbBusho.Text == null)
                {
                    dtRow[PARAM_BMN] = " ";
                }
                else
                {
                    // 宛先.
                    dtRow[PARAM_BMN] = ateName;
                }
                if (shutNo == null)
                {
                    dtRow[PARAM_SHUTNO] = " ";
                }
                else
                {
                    // 出力No.
                    dtRow[PARAM_SHUTNO] = shutNo;
                }

                /* 2015/04/01 公文得意先変更対応 HLC K.Fujisaki ADD Start */
                // 得意先企業名称.
                dtRow[PARAM_TKSKGYNAME] = _naviParameter.strTksKgyName;
                /* 2015/04/01 公文得意先変更対応 HLC K.Fujisaki ADD End */

                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //エクセル起動.
                System.Diagnostics.Process.Start("excel", macroFile);

                //合計金額の選択列をText型になおす.
                _spdReport_Sheet1.Cells[_spdReport_Sheet1.Rows.Count - 1, COLIDX_SNTK].CellType = new TextCellType();
                _spdReport_Sheet1.Cells[_spdReport_Sheet1.Rows.Count - 1, COLIDX_SNTK].Locked = true;

                //削除用に保持(戻るボタン押下時に削除する為).
                _strmacrodel = macroFile;

                // オペレーションログの出力.
                KKHLogUtilityKmn.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityKmn.KINO_ID_OPERATION_LOG_ReportSEI, KKHLogUtilityKmn.DESC_OPERATION_LOG_ReportSEI);
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
        private Common.KKHSchema.Common.SystemCommonRow GetReportInfo(string sybt)
        {
            //種別:"002"or"003".
            string strsybt = sybt;
            Common.KKHSchema.Common.SystemCommonRow ret;
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult;

            // 帳票設定情報取得. 
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
                // 取得できなかった場合はデフォルト値を設定.
                Common.KKHSchema.Common.SystemCommonDataTable dt =
                    new Common.KKHSchema.Common.SystemCommonDataTable();
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
                    ret.field2 = SFD_INITDIR;       // 保存先パス(エクセルファイル).

                }
            }
            return ret;
        }
        #endregion 帳票出力設定情報取得メソッド.
        #endregion メソッド.
    }
}