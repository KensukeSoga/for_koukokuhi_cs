using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;
using Isid.NJ.View.Navigator;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Mast;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;

using Isid.KKH.Mac.KKHUtility;
using Isid.KKH.Mac.Utility;
using Isid.KKH.Mac.Schema;
using System.Collections;
namespace Isid.KKH.Mac.View.Mast
{
    /// <summary>
    /// マスターメンテナンス画面（mac） 
    /// </summary>
    /// <remarks>
    ///   修正管理 
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
    public partial class frmMastMac : MastForm, INaviParameter
    {
        #region "メンバ定数"
                
        /// <summary>
        /// アプリID 
        /// ※取込処理と手動更新処理の判断で使用
        /// </summary>
        private const string C_APL_ID = "00";

        /// <summary>
        /// アプリ名称 
        /// </summary>
        private const string C_APL_NM = "マスターメンテナンス";
        
        /// <summary>
        /// 取込対象ファイル名（デフォルト） 
        /// </summary>
        private const string C_DEFAULT_FILE_NM = "店舗データ.xls";

        //private const string C_DEFAULT_FILE_NM = "店舗データ.xlsx";
        
        /// <summary>
        /// 取込対象ファイルフィルタ 
        /// </summary>
        private const string C_FILE_FILTER = "Excel ブック (*.xls)|*.xls|Excel ブック (*.xlsx)|*.xlsx|Excel ブック (*.xlsm)|*.xlsm|すべてのファイル(*.*)|*.*";

        /// <summary>
        /// ダイアログタイトル（ファイル取込） 
        /// </summary>
        private const string C_INPUT_TITLE_NM = "取込対象を選択してください";

        /// <summary>
        /// パターンアクティブ行
        /// </summary>
        private int activeRow = 0;

        /// <summary>
        /// パターンアクティブ列
        /// </summary>
        private int activeCol = 0;

        /// <summary>
        /// パターン編集中フラグ(編集中:True未編集:false)
        /// </summary>
        private bool PtnReNameFlg = false;

        /// <summary>
        /// タブページ制御 
        /// </summary>
        private KKHTabPageManager _tabPageManager = null;

        /// <summary>
        /// 店舗パターンマスター最大行数
        /// </summary>
        private const int C_MAXROW_TENPO_PATTERN_MASTER = 999;

        /// <summary>
        /// フィルター列番号
        /// </summary>
        private const int C_FILTER_COLINDEX = 14;

        #endregion

        #region "メンバ変数"

        /// <summary>
        /// ナビパラメータ 
        /// </summary>
        KKHNaviParameter mstNavPrm = new KKHNaviParameter();

        /// <summary>
        /// 編集中店舗マスター行
        /// </summary>
        MasterMaintenance.MasterDataVORow rowTenpoMaster = null;

        /// <summary>
        /// 店舗コード変更モード
        /// </summary>
        private bool IsChangeCodeMode = false;

        /// <summary>
        /// 変更前店舗コード 
        /// </summary>
        private string beforeTenpoCd = string.Empty;

        /// <summary>
        /// 変更前削除ボタン使用可否
        /// </summary>
        private bool beforeDeleteButtonEnabled = false;

        /// <summary>
        /// 店舗マスター
        /// </summary>
        MasterMaintenance.MasterDataVODataTable TenpoMasterVODataTable = new MasterMaintenance.MasterDataVODataTable();

        /// <summary>
        /// ダイアログ用ナビパラメータのインスタンス生成
        /// </summary>
         MastNarrowDownNaviParameter DialogParameter = new MastNarrowDownNaviParameter();

        /// <summary>
        /// 変更前店舗パターン名称
        /// </summary>
        private string beforeTenpoPatternName = string.Empty;

        /// <summary>
        /// 初期処理フラグ  
        /// </summary>
        private bool initFlg = false;

        #endregion

        #region "コンストラクタ"

        /// <summary>
        /// 初期イベント 
        /// </summary>
        public frmMastMac()
        {
            InitializeComponent();
            tbcMasterMainte.Visible = false;
            Cursor.Current = Cursors.WaitCursor;
        }
        
        #endregion

        #region "オーバーライド"

        /// <summary>
        /// スプレッド再描画 
        /// </summary>
        protected override void reDisplay()
            {
                // 店舗コードをemptyに 
                txtTenpoCd.Text = string.Empty;

                // フィルターをnullに 
                mstNavPrm.strFilterValue = null;

                int selectItemValue = 0;
                if (Itemcmb.Visible == true)
                {
                    selectItemValue = Itemcmb.SelectedIndex;
                }

                // 親フォームの再描画を呼び出す 
                base.reDisplay();

                if (Itemcmb.Visible == true)
                {
                    Itemcmb.SelectedIndex = selectItemValue;
                }

                MasterMaintenance.MasterKindVORow rw = null;
                int Count = 0;
                for (int i = 0; i < base.mstDtSet.MasterDataSet.MasterKindVO.Rows.Count; i++)
                {
                    if (base.mstDtSet.MasterDataSet.MasterKindVO[i].field1.Equals(KKHMacConst.C_MAST_TENPO_PTN_NM))
                    {
                        rw = base.mstDtSet.MasterDataSet.MasterKindVO[i];
                        Count++;
                    }
                }
                if (Count == 2)
                {
                    base.mstDtSet.MasterDataSet.MasterKindVO.RemoveMasterKindVORow(rw);
                }

                // マスター名(コンボボックス)で「店舗パターンマスター」が選択されている場合
                if (cmbMasterName1.Text == KKHMacConst.C_MAST_TENPO_PTN_NM && upchk == false)
                {
                    //ローディング表示開始 
                    base.ShowLoadingDialog();

                    // 店舗パターンマスター初期表示
                    this.InitTenpoPatternMaster();

                    //ローディング表示終了   
                    base.CloseLoadingDialog();
                }
            }

        /// <summary>
        /// マスター名コンボボックスにメニュー画面で押下されたマスターボタン名をセット 
        /// </summary>
        protected override void CombSetFromMenue()
        {
        }

        #endregion

        #region "イベント"

        #region 画面初期表示時

        /// <summary>
        /// 画面初期表示  
        /// </summary>
        private void frmMastMac_Shown(object sender, EventArgs e)
        {
            // カーソル設定
            Cursor.Current = Cursors.Default;

            // TabオブジェクトのSizeModeを設定 
            tbcMasterMainte.SizeMode = TabSizeMode.Fixed;

            // TabオブジェクトのSizeを設定 
            tbcMasterMainte.ItemSize = new Size(290, 20);

            // 入力項目初期化
            this.InitInputItemTenpoMaster_FirstTab(true);

            MasterMaintenance.MasterKindVORow rw = null;
            int Count = 0;
            for (int i = 0; i < base.mstDtSet.MasterDataSet.MasterKindVO.Rows.Count; i++)
            {
                // 「店舗パターンマスター」をカウント
                if (base.mstDtSet.MasterDataSet.MasterKindVO[i].field1.Equals(KKHMacConst.C_MAST_TENPO_PTN_NM))
                {
                    rw = base.mstDtSet.MasterDataSet.MasterKindVO[i];
                    Count++;
                }
            }

            // 「店舗パターンマスター」が重複している場合、重複行を削除する。
            if (Count == 2)
            {
                base.mstDtSet.MasterDataSet.MasterKindVO.RemoveMasterKindVORow(rw);
            }


            //マスター名コンボボックスにメニュー画面で押下されたマスターボタン名をセット 
            cmbMasterName1.Text = mstNavPrm.StrValue1;
            MastCmbClick();

            //メニュー画面で押下されたマスターボタン名が[マスター店舗(単一検索)]の場合 
            if (mstNavPrm.StrValue1 == "店舗マスター(単一検索)")
            {
                // 店舗マスター(単一検索)タブを選択
                tbcMasterMainte.SelectedIndex = 0;

                SelectedTempMstSnglSrchTab();

            }
            else
            {
                // 店舗マスター(一覧)タブを選択
                tbcMasterMainte.SelectedIndex = 1;

                SelectedTempMstListTab();

                MastCmbClick();
                //mstCmbChange();
            }

            // 変数初期化
            beforeTenpoCd = string.Empty;
            beforeDeleteButtonEnabled = false;
            IsChangeCodeMode = false;

            // Tabオブジェクトを表示 
            tbcMasterMainte.Visible = true;

        }

        #endregion

        #region 画面遷移時イベント

        /// <summary>
        /// 画面遷移時イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmMastMac_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            // TabPageManagerオブジェクトの存在確認 
            if (_tabPageManager == null)
            {
                //Tab PageManagerオブジェクトの作成 
                _tabPageManager = new KKHTabPageManager(tbcMasterMainte);
            }

            // NaviParameterの存在確認 
            if (arg.NaviParameter == null)
            {
                // Spread再描画 
                //this.reDisplay();
                return;
            }
            else
            {
                // NabiParameter取得
                mstNavPrm = (KKHNaviParameter)arg.NaviParameter;
                if (mstNavPrm.StrValue1 == "店舗マスター(単一検索)")
                {
                    // 店舗マスター(単一検索)タブを選択
                    tbcMasterMainte.SelectedIndex = 0;
                    this.Show();
                    if (mstNavPrm.DataTable1 != null)
                    {
                        AfterSelectTenpoRrk(mstNavPrm.DataTable1);
                    }
                }
                else if(mstNavPrm.StrValue1 == "店舗マスタ(一覧)")
                {
                    // 店舗マスター(一覧)タブを選択
                    tbcMasterMainte.SelectedIndex = 1;
                    this.Show();
                }
            }
        }

        #endregion

        #region 選択タブ変更

        /// <summary>
        /// 選択タブ変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbcMasterMainte_SelectedIndexChanged(object sender, EventArgs e)
        {
            // タブが2つ表示されていない場合、処理終了
            if (tbcMasterMainte.TabPages.Count != 2)
            {
                return;
            }

            // 店舗マスター(単一検索)タブ選択した場合 
            if (tbcMasterMainte.SelectedIndex == 0)
            {
                SelectedTempMstSnglSrchTab();
            }
            // 店舗マスター(一覧表示)タブ選択した場合 
            else
            {
                SelectedTempMstListTab();
            }
        }

        #endregion 

        #region 店舗コード入力

        /// <summary>
        /// 店舗コード入力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTenpoCd_TextChanged(object sender, EventArgs e)
        {
            // 店舗コード更新モードの場合、処理終了
            if (IsChangeCodeMode == true)
            {
                return;
            }

            if (txtTenpoCd.TextLength == txtTenpoCd.MaxLength)
            {
                mstNavPrm.strFilterValue = txtTenpoCd.Text;

                // 店舗マスター取得（単一）
                MasterMaintenanceProcessController processController = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = processController.FindMasterByCond(mstNavPrm.strEsqId,
                                                                                                     mstNavPrm.strEgcd,
                                                                                                     mstNavPrm.strTksKgyCd,
                                                                                                     mstNavPrm.strTksBmnSeqNo,
                                                                                                     mstNavPrm.strTksTntSeqNo,
                                                                                                     KKHMacConst.C_MAST_TENPO_CD,
                                                                                                     txtTenpoCd.Text);

                // 該当データが存在しない場合
                if (result.MasterDataSet.MasterDataVO.Rows.Count == 0)
                {
                    // 検索後表示設定（デフォルト値）
                    this.AfterSearchTenpoMaster();

                    return;
                }

                // 該当データ取得
                rowTenpoMaster = (MasterMaintenance.MasterDataVORow)result.MasterDataSet.MasterDataVO.Rows[0];

                // 検索後表示設定（データあり）
                this.AfterSearchTenpoMaster(rowTenpoMaster);
            }
            else
            {
                // コード変換ボタン使用不可
                btnChgCode.Enabled = false;

                // 削除ボタン使用不可
                btnClr.Enabled = false;

                // 入力項目初期化 
                this.InitInputItemTenpoMaster_FirstTab(false);
            }
        }

        #endregion

        #region マスター名コンボボックス選択行変更
        
        /// <summary>
        /// マスター名コンボボックス選択行変更 
        /// </summary>
        protected override void MastCmbClick()
        //private void mstCmbChange()
        {
            // マスター名コンボボックスに選択項目が設定されていない場合、処理終了
            if (cmbMasterName1.Items.Count == 0) { return; }

            // マスター名コンボボックスから選択行の情報が存在しない場合
            if (cmbMasterName1.SelectedItem == null) { return; }

            //マスター名コンボボックスの選択項目を取得する 
            //beforeMsterNm = cmbMasterName1.Text;
            if (initFlg)
            {
                base.MastCmbClick();
            }
            else
            {
                initFlg = true;
            }

            if (upchk)
            {
                return;
            }

            // マスターコンボボックスで選択された情報を取得
            DataRowView dataRowViewMasterName = (DataRowView)cmbMasterName1.SelectedItem;
            MasterMaintenance.MasterKindVORow rowMasterNamse 
                = (MasterMaintenance.MasterKindVORow)dataRowViewMasterName.Row;

            // 選択されているマスター名毎に以降の処理を行う
            switch (rowMasterNamse.field1)
            {
                // 店舗マスター 
                case KKHMacConst.C_MAST_TENPO_NM:

                    // ボタン設定
                    this.SetButtonPropertyTenpoMaster_SecondTab();

                    // 店舗パターンマスター用グループボックスを非表示
                    grbTenpoPtn.Visible = false;

                    // 店舗マスター(単一検索)タブを表示
                    _tabPageManager.ChangeTabPageVisible(0, true);

                    // 店舗マスター(一覧表示)タブを選択
                    tbcMasterMainte.SelectedIndex = 1;

                    // 一覧の表示設定
                    SpreadSetting(spdTenpoMas, KKHMacConst.C_MAST_TENPO_CD);

                    break;

                // 店舗パターンマスター 
                case KKHMacConst.C_MAST_TENPO_PTN_NM:

                    // ローディング表示開始
                    base.ShowLoadingDialog();

                    // ボタン設定
                    this.SetButtonPropertySelectTenpoPatternMaster();

                    // 初期処理
                    this.InitTenpoPatternMaster();

                    // 店舗マスター(単一検索)タブを非表示
                    _tabPageManager.ChangeTabPageVisible(0, false);

                    // 変更フラグOFF
                    //base.upchk = false;

                    // 店舗パターンマスター用グループボックスを表示
                    grbTenpoPtn.Visible = true;

                    //セレクトイベント
                    this.ChangeFilterValue();                  

                    // ローディング表示終了
                    base.CloseLoadingDialog();

                    break;

                // その他マスター 
                default:

                    // ボタン設定
                    this.SetButtonPropertySelectOtherMaster();

                    // 店舗パターンマスター用グループボックスを非表示
                    grbTenpoPtn.Visible = false;

                    // 店舗マスター(単一検索)タブを非表示
                    _tabPageManager.ChangeTabPageVisible(0, false);

                    break;
            }
        }

        #endregion

        #region コード変換ボタンクリック

        /// <summary>
        /// コード変換ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChgCode_Click(object sender, EventArgs e)
        {
            // 店舗コード変換モードに設定されている場合
            if (IsChangeCodeMode == true)
            {
                // 店舗コードを元に戻す
                txtTenpoCd.Text = beforeTenpoCd;

                // 削除ボタンの使用可否を戻す
                btnClr.Enabled = beforeDeleteButtonEnabled;

                // コード変換後表示設定（解除）
                this.AfterCodeChange(true);
            }
            else
            {
                // 店舗コードをメモリ上に保持
                beforeTenpoCd = txtTenpoCd.Text;

                // 削除ボタンの使用可否をメモリ上に保持
                beforeDeleteButtonEnabled = btnClr.Enabled;

                // 削除ボタンを使用不可
                btnClr.Enabled = false;

                // コード変換後表示設定（設定）
                this.AfterCodeChange(false);
            }

            this.ActiveControl = null;

        }

        #endregion

        #region 新規ボタンクリック（店舗マスター(単一検索)タブ）

        /// <summary>
        /// 新規ボタンクリック（店舗マスター(単一検索)タブ）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            // ボタン設定
            this.SetButtonPropertyTenpoMaster_FirstTab();

            // 入力項目初期化
            this.InitInputItemTenpoMaster_FirstTab(true);

            this.ActiveControl = null;

        }

        #endregion

        #region 更新ボタンクリック（店舗マスター(単一検索)タブ）

        /// <summary>
        /// 更新ボタンクリック（店舗マスター(単一検索)タブ）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpd2_Click(object sender, EventArgs e)
        {
            // 入力チェック
            if (this.InputCheck() == false)
            {
                this.ActiveControl = null;

                return;
            }

            // 登録確認メッセージ表示
            if (MessageUtility.ShowMessageBox(MessageCode.HB_C0002, null, C_APL_NM, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                this.ActiveControl = null;

                return;
            }

            // テリトリーの値取得
            string strTrritory = string.Empty;
            if (rdbTerritory1.Checked)
            {
                strTrritory = KKHMacConst.C_TERRITORY_CD1;
            }
            if (rdbTerritory2.Checked)
            {
                strTrritory = KKHMacConst.C_TERRITORY_CD2;
            }
            if (rdbTerritory3.Checked)
            {
                strTrritory = KKHMacConst.C_TERRITORY_CD3;
            }
            if (rdbTerritory4.Checked)
            {
                strTrritory = KKHMacConst.C_TERRITORY_CD4;
            }

            // 店舗区分の値取得
            string strTenpo = string.Empty;
            if (rdbTenpo1.Checked)
            {
                strTenpo = KKHMacConst.C_TENPO_KBN_CD1;
            }
            if (rdbTenpo2.Checked)
            {
                strTenpo = KKHMacConst.C_TENPO_KBN_CD2;
            }
            if (rdbTenpo3.Checked)
            {
                strTenpo = KKHMacConst.C_TENPO_KBN_CD3;
            }
            if (rdbTenpo4.Checked)
            {
                strTenpo = KKHMacConst.C_TENPO_KBN_CD4;
            }

            // 明細行フラグの値取得
            string strSplit = string.Empty;
            if (rdbSplitFlg1.Checked)
            {
                strSplit = KKHMacConst.C_SPLIT_FLG_CD1;
            }
            if (rdbSplitFlg2.Checked)
            {
                strSplit = KKHMacConst.C_SPLIT_FLG_CD2;
            }

            // DBアクセス用Controllerのインスタンス取得
            MasterMaintenanceProcessController processController = MasterMaintenanceProcessController.GetInstance();
        
            // 店舗コード更新モードの場合 
            if (IsChangeCodeMode == true)
            {
                // 店舗マスターから店舗コードに該当するレコードを取得する
                FindMasterMaintenanceByCondServiceResult selectResult = processController.FindMasterByCond(mstNavPrm.strEsqId,
                                                                                                           mstNavPrm.strEgcd,
                                                                                                           mstNavPrm.strTksKgyCd,
                                                                                                           mstNavPrm.strTksBmnSeqNo,
                                                                                                           mstNavPrm.strTksTntSeqNo,
                                                                                                           KKHMacConst.C_MAST_TENPO_CD,
                                                                                                           txtTenpoCd.Text);
                
                // 店舗コードに該当するレコードが存在しない場合 
                if (selectResult.MasterDataSet.MasterDataVO.Rows.Count > 0)
                {
                    // メッセージ表示
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0025, null, C_APL_NM, MessageBoxButtons.OK);
                    this.ActiveControl = null;

                    return;
                }
            }

            // 更新用DataTableのインスタンス生成
            MasterMaintenance.MasterDataVODataTable tenpoMasterDataTable = new MasterMaintenance.MasterDataVODataTable();

            // 更新用DataRow生成
            MasterMaintenance.MasterDataVORow updateRow = tenpoMasterDataTable.NewMasterDataVORow();

            // 画面項目を更新用DataRowに設定
            updateRow.Column1 = txtTenpoCd.Text;
            updateRow.Column2 = txtTenpoNm.Text;
            updateRow.Column3 = strTrritory;
            updateRow.Column4 = strTenpo;
            updateRow.Column5 = txtKamoku.Text;
            updateRow.Column6 = txtYubinNo.Text;
            updateRow.Column7 = txtAddress1.Text;
            updateRow.Column8 = txtAddress2.Text;
            updateRow.Column9 = txtTelNo.Text;
            updateRow.Column10 = strSplit;
            updateRow.Column11 = txtCompanyNm.Text;
            updateRow.Column12 = txtName.Text;
            updateRow.Column13 = txtTorihikisakiCd.Text;
            updateRow.Column15 = SGOpen.Text.Trim();
            updateRow.Column16 = GOpen.Text.Trim();
            updateRow.Column17 = GClose.Text.Trim();

            // 編集中店舗マスター行のタイムススタンプが存在する場合
            DateTime updateDateTime = new DateTime();
            if (rowTenpoMaster.IsupdTimStmpNull() == false)
            {
                // 編集中店舗マスター行を更新用DataRowに設定
                updateRow.trkTimStmp = rowTenpoMaster.trkTimStmp;
                updateRow.trkPl = rowTenpoMaster.trkPl;
                updateRow.trkTnt = rowTenpoMaster.trkTnt;
                updateRow.updTimStmp = rowTenpoMaster.updTimStmp;
                updateRow.updaPl = rowTenpoMaster.updaPl;
                updateRow.updTnt = rowTenpoMaster.updTnt;
                updateRow.tksKgyCd = rowTenpoMaster.tksKgyCd;
                updateRow.tksBmnSeqNo = rowTenpoMaster.tksBmnSeqNo;
                updateRow.tksTntSeqNo = rowTenpoMaster.tksTntSeqNo;
                updateRow.sybt = rowTenpoMaster.sybt;

                // タイムスタンプを設定
                updateDateTime = rowTenpoMaster.updTimStmp;
            }
              
            // 更新用DataTableにDataRowを追加
            tenpoMasterDataTable.AddMasterDataVORow(updateRow);

            //ローディング表示開始 
            base.ShowLoadingDialog();

            // 更新処理
            RegisterMasterServiceResult result = processController.RegisterMasterResult(mstNavPrm.strEsqId,
                                                                                        C_APL_ID,
                                                                                        mstNavPrm.strEgcd,
                                                                                        mstNavPrm.strTksKgyCd,
                                                                                        mstNavPrm.strTksBmnSeqNo,
                                                                                        mstNavPrm.strTksTntSeqNo,
                                                                                        mstNavPrm.strMasterKey,
                                                                                        mstNavPrm.strFilterValue,
                                                                                        tenpoMasterDataTable,
                                                                                        updateDateTime);

            //ローディング表示終了   
            base.CloseLoadingDialog();

            // 画面を再表示
            this.reDisplay();

            // ボタン設定
            this.SetButtonPropertyTenpoMaster_FirstTab();

            // 入力項目初期化
            this.InitInputItemTenpoMaster_FirstTab(true);

            // メッセージ表示
            MessageUtility.ShowMessageBox(MessageCode.HB_I0002, null, C_APL_NM, MessageBoxButtons.OK);

            this.ActiveControl = null;

        }

        #endregion

        #region 削除ボタン押クリック（店舗マスター(単一検索)タブ）

        /// <summary>
        /// 削除ボタン押クリック（店舗マスター(単一検索)タブ）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClr_Click(object sender, EventArgs e)
        {
            // 削除確認メッセージ表示
            if (MessageUtility.ShowMessageBox(MessageCode.HB_C0006, null, C_APL_NM, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                this.ActiveControl = null;

                return;
            }

            // DBアクセス用Controllerのインスタンス取得
            MasterMaintenanceProcessController processController = MasterMaintenanceProcessController.GetInstance();

            // 削除処理
            RegisterMasterServiceResult result = processController.RegisterMasterResult(mstNavPrm.strEsqId,
                                                                                        C_APL_ID,
                                                                                        mstNavPrm.strEgcd,
                                                                                        mstNavPrm.strTksKgyCd,
                                                                                        mstNavPrm.strTksBmnSeqNo,
                                                                                        mstNavPrm.strTksTntSeqNo,
                                                                                        mstNavPrm.strMasterKey,
                                                                                        mstNavPrm.strFilterValue,
                                                                                        new MasterMaintenance.MasterDataVODataTable(),
                                                                                        rowTenpoMaster.updTimStmp);

            // 画面を再表示
            this.reDisplay();

            // ボタン設定
            this.SetButtonPropertyTenpoMaster_FirstTab();

            // 入力項目初期化
            this.InitInputItemTenpoMaster_FirstTab(true);

            // 削除完了メッセージ表示
            MessageUtility.ShowMessageBox(MessageCode.HB_I0003, null, C_APL_NM, MessageBoxButtons.OK);

            this.ActiveControl = null;

        }

        #endregion

        /// <summary>
        /// 店舗マスター履歴画面遷移 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTnpRrkS_Click(object sender, EventArgs e)
        {
            // 店舗コードが空の場合は何もしない
            if (this.txtTenpoCd.Text.Equals(String.Empty))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0128, null, C_APL_NM, MessageBoxButtons.OK);
                    return;
            }

            // パラメータセット 
            KKHNaviParameter naviParam = new KKHNaviParameter();
            naviParam = mstNavPrm;

            naviParam.StrValue1 = txtTenpoCd.Text;
            naviParam.DataTable1 = null;

            // 店舗履歴画面に遷移
            object result = Navigator.Forward(this, "tofrmMastTnpRrk", naviParam);
            this.Hide();
            
            if (result == null)
            {
                // データが存在しなかったら処理を抜ける。 
                return;
            }

            // コントロールを未選択状態にする 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 店舗マスター履歴画面遷移 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTnpRrkA_Click(object sender, EventArgs e)
        {
            //パラメータセット 
            KKHNaviParameter naviParam = new KKHNaviParameter();
            naviParam = mstNavPrm;

            naviParam.StrValue1 = "";
            naviParam.DataTable1 = null;

            // 一覧履歴画面に遷移
            object result = Navigator.Forward(this, "tofrmMastTnpRrkAll", naviParam);
            this.Hide();
            if (result == null)
            {
                // データが存在しなかったら処理を抜ける。 
                return;
            }

            //コントロールを未選択状態にする 
            this.ActiveControl = null;

        }

        #region 取込ボタンクリック

        /// <summary>
        /// ファイル取込ボタン押下 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInputData_Click(object sender, EventArgs e)
        {
            // ファイル取込確認メッセージ 
            if (MessageUtility.ShowMessageBox(MessageCode.HB_C0003, null, C_APL_NM, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_I0005, null, C_APL_NM, MessageBoxButtons.OK);

                this.ActiveControl = null;

                return;
            }

            // Excelオブジェクト生成 
            Excel.Application oXls =　new Excel.Application();

            // Workbookオブジェクト生成 
            Excel.Workbook oWBook = null;
            oXls.DisplayAlerts = false;
            
            try
            {
                // 取込対象ファイル定義クラス 
                KKHMacInputDataDefi inputDefi = KKHMacInputDataDefi.GetInstance();

                // ファイル取込ダイアログ生成 
                OpenFileDialog ofd = new OpenFileDialog();

                // デフォルトファイル名 
                ofd.FileName = C_DEFAULT_FILE_NM;

                // 対象ディレクトリパス 
                ofd.InitialDirectory = @inputDefi.InputDataWorkFolderPath;

                // 対象ファイルフィルタ 
                ofd.Filter = C_FILE_FILTER;
                ofd.FilterIndex = 1;

                // タイトル 
                ofd.Title = C_INPUT_TITLE_NM;
                ofd.RestoreDirectory = true;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;

                // ファイル取込ダイアログ表示 
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Excelウィンドウ表示否 
                    oXls.Visible = false;
                    // Excelファイルオープン 
                    oWBook = (Excel.Workbook)(oXls.Workbooks.Open(
                      ofd.FileName,  // オープンするExcelファイル名 
                      Type.Missing, // （省略可能）UpdateLinks (0 / 1 / 2 / 3) 
                      Type.Missing, // （省略可能）ReadOnly (True / False ) 
                      Type.Missing, // （省略可能）Format 
                        // 1:タブ / 2:カンマ (,) / 3:スペース / 4:セミコロン (;)
                        // 5:なし / 6:引数 Delimiterで指定された文字
                      Type.Missing, // （省略可能）Password 
                      Type.Missing, // （省略可能）WriteResPassword 
                      Type.Missing, // （省略可能）IgnoreReadOnlyRecommended 
                      Type.Missing, // （省略可能）Origin 
                      Type.Missing, // （省略可能）Delimiter 
                      Type.Missing, // （省略可能）Editable 
                      Type.Missing, // （省略可能）Notify 
                      Type.Missing, // （省略可能）Converter 
                      Type.Missing, // （省略可能）AddToMru 
                      Type.Missing, // （省略可能）Local 
                      Type.Missing  // （省略可能）CorruptLoad 
                    ));


                    // ワークシート名
                    //string sheetName = "Sheet1";
                    // Worksheetオブジェクト取得 
                    int trgShtIndex = 0;
                    trgShtIndex = getSheetIndex(inputDefi, oWBook.Sheets);
                    if (trgShtIndex.Equals(0))
                    {
                        // workbookオブジェクトを閉じる 
                        oWBook.Close(Type.Missing, Type.Missing, Type.Missing);
                        // Excel開放 
                        oXls.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(oWBook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(oXls);
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0083,
                         null,
                         C_APL_NM,
                         MessageBoxButtons.OK);

                        this.ActiveControl = null;

                        return;
                    }
                    Cursor.Current = Cursors.WaitCursor;

                    Excel.Worksheet oSheet;
                    oSheet = (Excel.Worksheet)oWBook.Sheets[trgShtIndex];

                    // マスターメンテナンスプロセスコントローラ生成 
                    MasterMaintenanceProcessController masterMaintenanceProcessController
                        = MasterMaintenanceProcessController.GetInstance();
                    // apiからの返却値(マスターメンテナンス) 
                    FindMasterMaintenanceByCondServiceResult result
                        = masterMaintenanceProcessController.FindMasterByCond(mstNavPrm.strEsqId,
                                                                        mstNavPrm.strEgcd,
                                                                        mstNavPrm.strTksKgyCd,
                                                                        mstNavPrm.strTksBmnSeqNo,
                                                                        mstNavPrm.strTksTntSeqNo,
                                                                        KKHMacConst.C_MAST_TENPO_CD,
                                                                        null);

                    // マスター保持データテーブル 
                    MasterMaintenance.MasterDataVODataTable mstDataTbl
                        = (MasterMaintenance.MasterDataVODataTable)result.MasterDataSet.MasterDataVO;

                    // チェック結果保持データテーブル 
                    MasterMaintenance.MasterDataVODataTable chkDataTbl
                        = new MasterMaintenance.MasterDataVODataTable();

                    // チェック結果保持データテーブル(色) 
                    MasterMaintenance.MasterDataVODataTable colDataTbl
                        = new MasterMaintenance.MasterDataVODataTable();

                    // Excelチェック対象検出
                    int intRow = 1; // RowIndex 
                    int intClm = 1; // ColumnIndex 
                    int intTenpoCd = 0,        // 店舗CD Index格納 
                        intTenpoNm = 0,        // 店舗名 Index格納 
                        intTerritory = 0,      // テリトリ Index格納 
                        intTenpoKbn = 0,       // 店舗区分 Index格納 
                        intKamokuCd = 0,       // 勘定科目 Index格納 
                        intYubinNo = 0,        // 郵便番号 Index格納 
                        intTodofukenNm = 0,      // 都道府県 Index格納 
                        intAddress1 = 0,       // 住所１ Index格納 
                        intAddress2 = 0,       // 住所２ Index格納 
                        intTelNo = 0,          // 電話番号 Index格納 
                        intSplitFlg = 0,       // 明細行フラグ Index格納 
                        intCompanyNm = 0,      // ライセンシー社名 Index格納 
                        intName = 0,           // 代表者名 Index格納 
                        intTorihikisakiCd = 0, // 取引先コード Index格納 
                        //intCloseDate = 0,      // 終了日 Index格納   
                        intShokiGOpenNgp = 0,  // 初期G.OPEN年月日Index格納  
                        intGOpenNgp = 0,       // G.OPEN年月日Index格納  
                        intGCloseNgp = 0;      // G.CLOSE年月日Index格納  

                    //ローディング表示開始  
                    base.ShowLoadingDialog();

                    # region エクセル取込 列

                    // 取り込んだExcelのColumnがemptyになるまで 
                    while (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString() != string.Empty)
                    {
                        // Column名「店舗コード」が存在すれば、当該ファイルよりindexを取得 
                        if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strTenpoCd))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intTenpoCd = intClm;
                        }
                        // Column名「店舗名」が存在すれば、当該ファイルよりindexを取得 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strTenpoNm))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intTenpoNm = intClm;
                        }
                        // Column名「テリトリ」が存在すれば、当該ファイルよりindexを取得 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strTerritory))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intTerritory = intClm;
                        }
                        // Column名「店舗区分」が存在すれば、当該ファイルよりindexを取得 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strTenpoKbn))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intTenpoKbn = intClm;
                        }
                        // Column名「勘定科目」が存在すれば、当該ファイルよりindexを取得 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strKamokuCd))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intKamokuCd = intClm;
                        }
                        // Column名「郵便番号」が存在すれば、当該ファイルよりindexを取得 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strYubinNo))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intYubinNo = intClm;
                        }
                        // Column名「都道府県」が存在すれば、当該ファイルよりindexを取得 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strTodofukenNm))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intTodofukenNm = intClm;
                        }
                        // Column名「住所１」が存在すれば、当該ファイルよりindexを取得 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strAddress1))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intAddress1 = intClm;
                        }
                        // Column名「住所２」が存在すれば、当該ファイルよりindexを取得 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strAddress2))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intAddress2 = intClm;
                        }
                        // Column名「電話番号」が存在すれば、当該ファイルよりindexを取得 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strTelNo))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intTelNo = intClm;
                        }
                        // Column名「明細行フラグ」が存在すれば、当該ファイルよりindexを取得 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strSplitFlg))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intSplitFlg = intClm;
                        }
                        // Column名「ライセンシー社名」が存在すれば、当該ファイルよりindexを取得 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strCompanyNm))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intCompanyNm = intClm;
                        }
                        // Column名「代表者名」が存在すれば、当該ファイルよりindexを取得 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strName))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intName = intClm;
                        }
                        // Column名「取引先コード」が存在すれば、当該ファイルよりindexを取得 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.strTorihikisakiCd))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intTorihikisakiCd = intClm;
                        }
                        // Column名「初期G.OPEN年月日」が存在すれば、当該ファイルよりindexを取得 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.shokiGOpenNgp))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intShokiGOpenNgp = intClm;
                        }
                        // Column名「G.OPEN年月日」が存在すれば、当該ファイルよりindexを取得 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.gOpenNgp))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intGOpenNgp = intClm;
                        }
                        // Column名「G.CLOSE年月日」が存在すれば、当該ファイルよりindexを取得 
                        else if (((Excel.Range)oSheet.Cells[intRow, intClm]).Text.ToString().Equals(inputDefi.gCloseNgp))
                        {
                            ((Excel.Range)oSheet.Cells[intRow, intClm]).Columns.AutoFit();
                            intGCloseNgp = intClm;
                        }
                        // ColumnIndexのインクリメント 
                        intClm++;
                    }

                    # endregion エクセル取込 列

                    // ExcelRowIndex を初期化 
                    intRow = 2;

                    // CheckTbl用RowIndex 
                    int intInsTblRow = 0;

                    # region エクセル取込 行

                    // Excel 店舗Cd Rowがemptyになるまで。 
                    while (((Excel.Range)oSheet.Cells[intRow, intTenpoCd]).Text.ToString() != string.Empty)
                    {

                        bool blnEnableFalse = false;
                        // チェック結果格納変数(string)
                        string strTenpoCd = string.Empty,       // 店舗コード 格納用
                            strTenpoNm = string.Empty,          // 店舗名称 格納用
                            strTerritory = string.Empty,        // テリトリ 格納用
                            strTenpoKbn = string.Empty,         // 店舗区分 格納用
                            strKamokuCd = string.Empty,         // 勘定科目 格納用
                            strYubinNo = string.Empty,          // 郵便番号 格納用
                            strTodofukenNm = string.Empty,        // 都道府県 格納用 
                            strAddress1 = string.Empty,         // 住所１ 格納用
                            strAddress2 = string.Empty,         // 住所２ 格納用
                            strTelNo = string.Empty,            // 電話番号 格納用
                            strSplitFlg = string.Empty,         // 明細行フラグ 格納用
                            strCompanyNm = string.Empty,        // ライセンシー社名 格納用
                            strName = string.Empty,             // 代表者名 格納用
                            strTorihikisakiCd = string.Empty,   // 取引先コード 格納用
                            //strCloseDate = string.Empty,        // 終了日 格納用
                            strShokiGOpenNgp = "",              // 初期G.OPEN年月日 
                            strGOpenNgp = "",                   // G.OPEN年月日 
                            strGCloseNgp = "";                  // G.CLOSE年月日 

                        // 当該ファイルに「店舗コード」存在する時
                        if (intTenpoCd != 0)
                        {
                            strTenpoCd = String.Format("{0:000000}", int.Parse(((Excel.Range)oSheet.Cells[intRow, intTenpoCd]).Text.ToString().Trim()));
                        }
                        // 当該ファイルに「店舗名称」存在する時
                        if (intTenpoNm != 0)
                        {
                            strTenpoNm = ((Excel.Range)oSheet.Cells[intRow, intTenpoNm]).Text.ToString().Trim();
                        }
                        // 当該ファイルに「テリトリー」存在する時
                        if (intTerritory != 0)
                        {
                            // 名称から区分に変換
                            switch (((Excel.Range)oSheet.Cells[intRow, intTerritory]).Text.ToString().Trim())
                            {
                                // 関東
                                case KKHMacConst.C_TERRITORY_NM1:
                                    strTerritory = KKHMacConst.C_TERRITORY_CD1;
                                    break;
                                // 関西
                                case KKHMacConst.C_TERRITORY_NM2:
                                    strTerritory = KKHMacConst.C_TERRITORY_CD2;
                                    break;
                                // 中央
                                case KKHMacConst.C_TERRITORY_NM3:
                                    strTerritory = KKHMacConst.C_TERRITORY_CD3;
                                    break;
                                // その他
                                case KKHMacConst.C_TERRITORY_NM4:
                                    strTerritory = KKHMacConst.C_TERRITORY_CD4;
                                    break;
                            }
                        }
                        // 当該ファイルに「店舗区分」存在する時
                        if (intTenpoKbn != 0)
                        {
                            // 名称から区分に変換
                            switch (((Excel.Range)oSheet.Cells[intRow, intTenpoKbn]).Text.ToString().Trim())
                            {
                                // *****************************************************************
                                //             入力ファイルのデータ次第で...できれば統一したい 
                                // *****************************************************************
                                // 地区本部 
                                case "地区本部":
                                    strTenpoKbn = KKHMacConst.C_TENPO_KBN_CD1;
                                    break;
                                // MC直営 
                                case "直営":
                                    strTenpoKbn = KKHMacConst.C_TENPO_KBN_CD2;
                                    break;
                                // ライセンシー 
                                case "ＦＣ":
                                    strTenpoKbn = KKHMacConst.C_TENPO_KBN_CD3;
                                    break;
                                // その他
                                case "その他":
                                    strTenpoKbn = KKHMacConst.C_TENPO_KBN_CD4;
                                    break;
                            }
                        }
                        // 当該ファイルに「勘定科目」存在する時 
                        if (intKamokuCd != 0)
                        {
                            strKamokuCd = ((Excel.Range)oSheet.Cells[intRow, intKamokuCd]).Text.ToString().Trim();
                        }
                        // 当該ファイルに「郵便番号」存在する時 
                        if (intYubinNo != 0)
                        {
                            strYubinNo = ((Excel.Range)oSheet.Cells[intRow, intYubinNo]).Text.ToString().Trim();
                        }
                        // 当該ファイルに「都道府県」存在する時 
                        if (intTodofukenNm != 0)
                        {
                            strTodofukenNm = ((Excel.Range)oSheet.Cells[intRow, intTodofukenNm]).Text.ToString().Trim();
                        }
                        // 当該ファイルに「住所１」存在する時 
                        if (intAddress1 != 0)
                        {
                            strAddress1 = ((Excel.Range)oSheet.Cells[intRow, intAddress1]).Text.ToString().Trim();
                        }
                        // 当該ファイルに「住所２」存在する時 
                        if (intAddress2 != 0)
                        {
                            strAddress2 = ((Excel.Range)oSheet.Cells[intRow, intAddress2]).Text.ToString().Trim();
                        }
                        // 当該ファイルに「電話番号」存在する時 
                        if (intTelNo != 0)
                        {
                            strTelNo = ((Excel.Range)oSheet.Cells[intRow, intTelNo]).Text.ToString().Trim();
                        }
                        // 当該ファイルに「明細行フラグ」存在する時 
                        if (intSplitFlg != 0)
                        {
                            // 名称を区分に変換 
                            switch (((Excel.Range)oSheet.Cells[intRow, intSplitFlg]).Text.ToString().Trim())
                            {
                                // 分割 
                                case KKHMacConst.C_SPLIT_FLG_NM1:
                                    strSplitFlg = KKHMacConst.C_SPLIT_FLG_CD1;
                                    break;
                                // 非分割 
                                case KKHMacConst.C_SPLIT_FLG_NM2:
                                    strSplitFlg = KKHMacConst.C_SPLIT_FLG_CD2;
                                    break;
                            }
                        }
                        else
                        {
                            // 存在しない時は固定で”分割しない = 1”を設定する 
                            strSplitFlg = KKHMacConst.C_SPLIT_FLG_CD2;
                        }
                        // 当該ファイルに「ライセンシー社名」存在する時 
                        if (intCompanyNm != 0)
                        {
                            strCompanyNm = ((Excel.Range)oSheet.Cells[intRow, intCompanyNm]).Text.ToString().Trim();
                        }
                        // 当該ファイルに「代表者名」存在する時 
                        if (intName != 0)
                        {
                            strName = ((Excel.Range)oSheet.Cells[intRow, intName]).Text.ToString().Trim();
                        }
                        // 当該ファイルに「取引先コード」存在する時 
                        if (intTorihikisakiCd != 0)
                        {
                            strTorihikisakiCd = ((Excel.Range)oSheet.Cells[intRow, intTorihikisakiCd]).Text.ToString().Trim();
                        }
                        // 当該ファイルに「初期G.OPEN年月日」が存在する時 
                        if (intShokiGOpenNgp != 0)
                        {
                            strShokiGOpenNgp = ((Excel.Range)oSheet.Cells[intRow, intShokiGOpenNgp]).Text.ToString().Trim();
                        }
                        // 当該ファイルに「G.OPEN年月日」が存在する時 
                        if (intGOpenNgp != 0)
                        {
                            strGOpenNgp = ((Excel.Range)oSheet.Cells[intRow, intGOpenNgp]).Text.ToString().Trim();
                        }
                        // 当該ファイルに「G.CLOSE年月日」が存在する時 
                        if (intGCloseNgp != 0)
                        {
                            strGCloseNgp = ((Excel.Range)oSheet.Cells[intRow, intGCloseNgp]).Text.ToString().Trim();
                            if (strGCloseNgp.Equals(String.Empty))
                            {
                                base.CloseLoadingDialog();
                                MessageUtility.ShowMessageBox(MessageCode.HB_W0157, new string[] { "G.CLOSE年月日" }, "エラー", MessageBoxButtons.OK);
                                // *** Excel オブジェクト解放 ***
                                // workbookオブジェクトを閉じる
                                oWBook.Close(Type.Missing, Type.Missing, Type.Missing);
                                // Excel開放 
                                oXls.Quit();
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(oWBook);
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(oXls);

                                return; 
                            }
                        }

                        // 有効期限判定 
                        //if (DateTime.Compare(DateTime.Parse(strGCloseNgp),
                        if (DateTime.Compare(Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime2(strGCloseNgp),
                            Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(tslDate.Text)) < 0)
                        {
                            blnEnableFalse = true;
                        }
                        // DB保持の値からExcelの店舗コードにて絞り込む 
                        MasterMaintenance.MasterDataVORow[] mstDataRow = (MasterMaintenance.MasterDataVORow[])mstDataTbl.Select("Column1 = '" + strTenpoCd + "'");

                        // 該当データ無 
                        // ###############################################################
                        // #                         新規データ                          #
                        // ###############################################################
                        if (mstDataRow.Length.Equals(0))
                        {
                            // 有効期限判定（切れていたら取込対象外） 
                            if (!blnEnableFalse)
                            {
                                // 行追加 
                                chkDataTbl.AddMasterDataVORow(chkDataTbl.NewMasterDataVORow());
                                // 行追加 
                                colDataTbl.AddMasterDataVORow(colDataTbl.NewMasterDataVORow());
                                // ステータス"新規" 
                                chkDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_NEW;
                                colDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_NEW;

                                // 店舗コード 
                                chkDataTbl[intInsTblRow].Column1 = strTenpoCd;
                                // 店舗名 
                                chkDataTbl[intInsTblRow].Column2 = strTenpoNm;
                                // テリトリ 
                                chkDataTbl[intInsTblRow].Column3 = strTerritory;
                                // 店舗区分 
                                chkDataTbl[intInsTblRow].Column4 = strTenpoKbn;
                                // 勘定科目 
                                chkDataTbl[intInsTblRow].Column5 = strKamokuCd;
                                // 郵便番号 
                                if (strYubinNo.Length != 0)
                                {
                                    //7桁未満の場合 
                                    if (strYubinNo.Length < 7)
                                    {
                                        //頭に0を埋める 
                                        strYubinNo = strYubinNo.PadLeft(7, '0');
                                    }

                                    //"-"を挿入 
                                    strYubinNo = strYubinNo.Substring(0, 3) + "-" + strYubinNo.Substring(3, 4);
                                    //chkDataTbl[intInsTblRow].Column6 = strYubinNo.Substring(0, 3) + "-" + strYubinNo.Substring(3, 4);
                                }

                                chkDataTbl[intInsTblRow].Column6 = strYubinNo;

                                // 都道府県  
                                chkDataTbl[intInsTblRow].Column19 = strTodofukenNm;
                                //都道府県が住所１に含まれている場合 
                                if (Regex.IsMatch(strAddress1, "^" + strTodofukenNm + "$"))
                                {
                                    // 住所１ 
                                    chkDataTbl[intInsTblRow].Column7 = strAddress1;
                                }
                                else
                                {
                                    // 住所１ 
                                    chkDataTbl[intInsTblRow].Column7 = strTodofukenNm + strAddress1;
                                }
                                // 住所１ 
                                //chkDataTbl[intInsTblRow].Column7 = strAddress1;
                                // 住所２ 
                                chkDataTbl[intInsTblRow].Column8 = strAddress2;
                                // 電話番号 
                                chkDataTbl[intInsTblRow].Column9 = strTelNo;
                                // 明細行フラグ 
                                chkDataTbl[intInsTblRow].Column10 = strSplitFlg;
                                // ライセンシー社名 
                                chkDataTbl[intInsTblRow].Column11 = strCompanyNm;
                                // 代表者名 
                                chkDataTbl[intInsTblRow].Column12 = strName;
                                // 取引先コード 
                                chkDataTbl[intInsTblRow].Column13 = strTorihikisakiCd;
                                // 初期G.OPEN年月日 
                                chkDataTbl[intInsTblRow].Column16 = strShokiGOpenNgp;
                                // G.OPEN年月日 
                                chkDataTbl[intInsTblRow].Column17 = strGOpenNgp;
                                // G.CLOSE年月日 
                                chkDataTbl[intInsTblRow].Column18 = strGCloseNgp;

                                // 店舗コード 
                                colDataTbl[intInsTblRow].Column1 = KKHMacConst.C_CHECK_FALSE;
                                // 店舗名 
                                colDataTbl[intInsTblRow].Column2 = KKHMacConst.C_CHECK_FALSE;
                                // テリトリ 
                                colDataTbl[intInsTblRow].Column3 = KKHMacConst.C_CHECK_FALSE;
                                // 店舗区分 
                                colDataTbl[intInsTblRow].Column4 = KKHMacConst.C_CHECK_FALSE;
                                // 勘定科目 
                                colDataTbl[intInsTblRow].Column5 = KKHMacConst.C_CHECK_FALSE;
                                // 郵便番号 
                                colDataTbl[intInsTblRow].Column6 = KKHMacConst.C_CHECK_FALSE;
                                // 住所１ 
                                colDataTbl[intInsTblRow].Column7 = KKHMacConst.C_CHECK_FALSE;
                                // 住所２ 
                                colDataTbl[intInsTblRow].Column8 = KKHMacConst.C_CHECK_FALSE;
                                // 電話番号 
                                colDataTbl[intInsTblRow].Column9 = KKHMacConst.C_CHECK_FALSE;
                                // 明細行フラグ 
                                colDataTbl[intInsTblRow].Column10 = KKHMacConst.C_CHECK_FALSE;
                                // ライセンシー社名 
                                colDataTbl[intInsTblRow].Column11 = KKHMacConst.C_CHECK_FALSE;
                                // 代表者名 
                                colDataTbl[intInsTblRow].Column12 = KKHMacConst.C_CHECK_FALSE;
                                // 取引先コード 
                                colDataTbl[intInsTblRow].Column13 = KKHMacConst.C_CHECK_FALSE;
                                // 店舗コード（キー） 
                                colDataTbl[intInsTblRow].Column15 = strTenpoCd;
                                // 初期G.OPEN年月日 
                                colDataTbl[intInsTblRow].Column16 = KKHMacConst.C_CHECK_FALSE;
                                // G.OPEN年月日 
                                colDataTbl[intInsTblRow].Column17 = KKHMacConst.C_CHECK_FALSE;
                                // G.CLOSE年月日 
                                colDataTbl[intInsTblRow].Column18 = KKHMacConst.C_CHECK_FALSE;
                                // インクリメント 
                                intInsTblRow++;
                            }
                        }
                        // 該当データ有 
                        else
                        {

                            bool blnTenpoCd = false,         // 店舗コード 格納用 
                                blnTenpoNm = false,          // 店舗名称 格納用 
                                blnTerritory = false,        // テリトリ 格納用 
                                blnTenpoKbn = false,         // 店舗区分 格納用 
                                blnKamokuCd = false,         // 勘定科目 格納用 
                                blnYubinNo = false,          // 郵便番号 格納用 
                                blnAddress1 = false,         // 住所１ 格納用 
                                blnAddress2 = false,         // 住所２ 格納用 
                                blnTelNo = false,            // 電話番号 格納用 
                                blnSplitFlg = false,         // 明細行フラグ 格納用 
                                blnCompanyNm = false,        // ライセンシー社名 格納用 
                                blnName = false,             // 代表者名 格納用 
                                blnTorihikisakiCd = false,   // 取引先コード 格納用 
                                blnShokiGOpenNgp = false,    // 初期G.OPEN年月日 
                                blnGOpenNgp = false,         // G.OPEN年月日 
                                blnGCloseNgp = false;        // G.CLOSE年月日 
                            // Column名「店舗コード」が存在する場合 
                            if (intTenpoCd != 0)
                            {
                                // 既存レコードの値と、Excelの値を比較する 
                                if (mstDataRow[0].Column1.ToString() != strTenpoCd)
                                {
                                    // チェックフラグを"true" 
                                    blnTenpoCd = true;
                                }
                            }
                            // 存在しない場合、既存レコードの値を設定 
                            else
                            {
                                strTenpoCd = mstDataRow[0].Column1.ToString();
                            }
                            // Column名「店舗名」が存在する場合 
                            if (intTenpoNm != 0)
                            {
                                // 既存レコードの値と、Excelの値を比較する 
                                if (mstDataRow[0].Column2.ToString() != strTenpoNm)
                                {
                                    // チェックフラグを"true" 
                                    blnTenpoNm = true;
                                }
                            }
                            // 存在しない場合、既存レコードの値を設定 
                            else
                            {
                                strTenpoNm = mstDataRow[0].Column2.ToString();
                            }
                            // Column名「テリトリ」が存在する場合 
                            if (intTerritory != 0)
                            {
                                // 既存レコードの値と、Excelの値を比較する 
                                if (mstDataRow[0].Column3.ToString() != strTerritory)
                                {
                                    // チェックフラグを"true" 
                                    blnTerritory = true;
                                }
                            }
                            // 存在しない場合、既存レコードの値を設定 
                            else
                            {
                                strTerritory = mstDataRow[0].Column3.ToString();
                            }
                            // Column名「店舗区分」が存在する場合 
                            if (intTenpoKbn != 0)
                            {
                                // 既存レコードの値と、Excelの値を比較する 
                                if (mstDataRow[0].Column4.ToString() != strTenpoKbn)
                                {
                                    // チェックフラグを"true" 
                                    blnTenpoKbn = true;
                                }
                            }
                            // 存在しない場合、既存レコードの値を設定 
                            else
                            {
                                strTenpoKbn = mstDataRow[0].Column4.ToString();
                            }
                            // Column名「勘定科目」が存在する場合
                            if (intKamokuCd != 0)
                            {
                                // 既存レコードの値と、Excelの値を比較する 
                                if (mstDataRow[0].Column5.ToString() != strKamokuCd)
                                {
                                    // チェックフラグを"true" 
                                    blnKamokuCd = true;
                                }
                            }
                            // 存在しない場合、既存レコードの値を設定 
                            else
                            {
                                strKamokuCd = mstDataRow[0].Column5.ToString();
                            }
                            // Column名「郵便番号」が存在する場合 
                            if (intYubinNo != 0)
                            {
                                //7桁未満の場合 
                                if (strYubinNo.Length < 7)
                                {
                                    //頭に0を埋める 
                                    strYubinNo = strYubinNo.PadLeft(7, '0');
                                }

                                //"-"を挿入 
                                strYubinNo = strYubinNo.Substring(0, 3) + "-" + strYubinNo.Substring(3, 4);

                                // 既存レコードの値と、Excelの値を比較する 
                                if (mstDataRow[0].Column6.ToString() != strYubinNo)
                                {
                                    // チェックフラグを"true"
                                    blnYubinNo = true;
                                }
                            }
                            // 存在しない場合、既存レコードの値を設定 
                            else
                            {
                                strYubinNo = mstDataRow[0].Column6.ToString();
                            }


                            // Column名「住所１」が存在する場合 
                            if (intAddress1 != 0)
                            {
                                // 既存レコードの値と、Excelの値を比較する
                                //if (mstDataRow[0].Column7.ToString() != strAddress1)
                                if (mstDataRow[0].Column7.ToString() != strTodofukenNm + strAddress1)
                                {
                                    // チェックフラグを"true"
                                    blnAddress1 = true;
                                }
                            }
                            // 存在しない場合、既存レコードの値を設定
                            else
                            {
                                strAddress1 = mstDataRow[0].Column7.ToString();
                            }

                            // Column名「住所２」が存在する場合
                            if (intAddress2 != 0)
                            {
                                // 既存レコードの値と、Excelの値を比較する
                                if (mstDataRow[0].Column8.ToString() != strAddress2)
                                {
                                    // チェックフラグを"true"
                                    blnAddress2 = true;
                                }
                            }
                            // 存在しない場合、既存レコードの値を設定
                            else
                            {
                                strAddress2 = mstDataRow[0].Column8.ToString();
                            }
                            // Column名「電話番号」が存在する場合
                            if (intTelNo != 0)
                            {
                                // 既存レコードの値と、Excelの値を比較する
                                if (mstDataRow[0].Column9.ToString() != strTelNo)
                                {
                                    // チェックフラグを"true"
                                    blnTelNo = true;
                                }
                            }
                            // 存在しない場合、既存レコードの値を設定
                            else
                            {
                                strTelNo = mstDataRow[0].Column9.ToString();
                            }
                            // Column名「明細行フラグ」が存在する場合
                            if (intSplitFlg != 0)
                            {
                                // 既存レコードの値と、Excelの値を比較する
                                if (mstDataRow[0].Column10.ToString() != strSplitFlg)
                                {
                                    // チェックフラグを"true"
                                    blnSplitFlg = true;
                                }
                            }
                            // 存在しない場合、既存レコードの値を設定
                            else
                            {
                                strSplitFlg = mstDataRow[0].Column10.ToString();
                            }
                            // Column名「ライセンシー社名」が存在する場合
                            if (intCompanyNm != 0)
                            {
                                // 既存レコードの値と、Excelの値を比較する
                                if (mstDataRow[0].Column11.ToString().Replace("\n", "") != strCompanyNm)
                                {
                                    // チェックフラグを"true"
                                    blnCompanyNm = true;
                                }
                            }
                            // 存在しない場合、既存レコードの値を設定
                            else
                            {
                                strCompanyNm = mstDataRow[0].Column11.ToString();
                            }
                            // Column名「代表者名」が存在する場合
                            if (intName != 0)
                            {
                                // 既存レコードの値と、Excelの値を比較する
                                if (mstDataRow[0].Column12.ToString().Replace("\n", "") != strName)
                                {
                                    // チェックフラグを"true"
                                    blnName = true;
                                }
                            }
                            // 存在しない場合、既存レコードの値を設定
                            else
                            {
                                strName = mstDataRow[0].Column12.ToString();
                            }
                            // Column名「取引先コード」が存在する場合
                            if (intTorihikisakiCd != 0)
                            {
                                // 既存レコードの値と、Excelの値を比較する
                                if (mstDataRow[0].Column13.ToString() != strTorihikisakiCd)
                                {
                                    // チェックフラグを"true"
                                    blnTorihikisakiCd = true;
                                }
                            }
                            // 存在しない場合、既存レコードの値を設定
                            else
                            {
                                strTorihikisakiCd = mstDataRow[0].Column13.ToString();
                            }

                            // Column名「初期G.OPEN年月日」が存在する場合
                            if (intShokiGOpenNgp != 0)
                            {
                                // 既存レコードの値と、Excelの値を比較する 
                                if (Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime2(mstDataRow[0].Column15.ToString()).ToString("yyyy/M/d")
                                    != strShokiGOpenNgp)
                                //if (mstDataRow[0].Column16.ToString() != strGOpenNgp)
                                {
                                    // チェックフラグを"true"
                                    blnShokiGOpenNgp = true;
                                }
                            }
                            // 存在しない場合、既存レコードの値を設定
                            else
                            {
                                strShokiGOpenNgp = mstDataRow[0].Column15.ToString();
                            }

                            // Column名「G.OPEN年月日」が存在する場合
                            if (intGOpenNgp != 0)
                            {
                                // 既存レコードの値と、Excelの値を比較する
                                if (Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime2(mstDataRow[0].Column16.ToString()).ToString("yyyy/M/d")
                                    != strGOpenNgp)
                                //if (mstDataRow[0].Column16.ToString() != strGOpenNgp)
                                {
                                    // チェックフラグを"true"
                                    blnGOpenNgp = true;
                                }
                            }
                            // 存在しない場合、既存レコードの値を設定
                            else
                            {
                                strGOpenNgp = mstDataRow[0].Column16.ToString();
                            }

                            // Column名「G.CLOSE年月日」が存在する場合
                            if (intGCloseNgp != 0)
                            {
                                // 既存レコードの値と、Excelの値を比較する 
                                if (Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime2(mstDataRow[0].Column17.ToString()).ToString("yyyy/M/d")
                                    != strGCloseNgp)
                                //if (mstDataRow[0].Column17.ToString() != strGCloseNgp)
                                {
                                    // チェックフラグを"true"
                                    blnGCloseNgp = true;
                                }
                            }
                            // 存在しない場合、既存レコードの値を設定
                            else
                            {
                                strGCloseNgp = mstDataRow[0].Column17.ToString();
                            }


                            // Column名「都道府県」が存在する場合 
                            if (intTodofukenNm != 0)
                            {
                                // 既存レコードの値と、Excelの値を比較する
                                //if (mstDataRow[0].Column19.ToString() != strTodofukenNm)
                                //{
                                //    // チェックフラグを"true"
                                //    blnTodofukenNm = true;
                                //}
                            }
                            // 存在しない場合、既存レコードの値を設定
                            else
                            {
                                strTodofukenNm = mstDataRow[0].Column19.ToString();
                            }
                            # region 変更データチェック

                            // ###############################################################
                            // #                         変更データ                          #
                            // ###############################################################
                            // チェックフラグが"true = 変更有"
                            if ((blnTenpoCd) ||
                                (blnTenpoNm) ||
                                (blnTerritory) ||
                                (blnTenpoKbn) ||
                                (blnKamokuCd) ||
                                (blnYubinNo) ||
                                (blnAddress1) ||
                                (blnAddress2) ||
                                (blnTelNo) ||
                                (blnSplitFlg) ||
                                (blnCompanyNm) ||
                                (blnName) ||
                                (blnTorihikisakiCd) ||
                                (blnTenpoNm) ||
                                (blnShokiGOpenNgp) ||
                                (blnGOpenNgp) ||
                                (blnGCloseNgp))
                            {
                                // 差分あり
                                // 行追加
                                chkDataTbl.AddMasterDataVORow(chkDataTbl.NewMasterDataVORow());
                                // 行追加
                                colDataTbl.AddMasterDataVORow(colDataTbl.NewMasterDataVORow());

                                // 有効期限判定
                                if (!blnEnableFalse)
                                {
                                    // 期限が切れていない、ステータス"変更"
                                    chkDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_EDIT;
                                    colDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_EDIT;
                                }
                                else
                                {
                                    // 期限切れ、ステータス"削除"
                                    chkDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_DEL;
                                    colDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_DEL;
                                }
                                // *** データ ***
                                // 店舗コード
                                chkDataTbl[intInsTblRow].Column1 = strTenpoCd;
                                // 店舗名
                                chkDataTbl[intInsTblRow].Column2 = strTenpoNm;
                                // テリトリ
                                chkDataTbl[intInsTblRow].Column3 = strTerritory;
                                // 店舗区分
                                chkDataTbl[intInsTblRow].Column4 = strTenpoKbn;
                                // 勘定科目
                                chkDataTbl[intInsTblRow].Column5 = strKamokuCd;
                                // 郵便番号
                                chkDataTbl[intInsTblRow].Column6 = strYubinNo;
                                //都道府県が住所１に含まれている場合 
                                if (Regex.IsMatch(strAddress1, "^" + strTodofukenNm + "$"))
                                {
                                    // 住所１ 
                                    chkDataTbl[intInsTblRow].Column7 = strAddress1;
                                }
                                else
                                {
                                    // 住所１ 
                                    chkDataTbl[intInsTblRow].Column7 = strTodofukenNm + strAddress1;
                                }
                                // 住所１ 
                                //chkDataTbl[intInsTblRow].Column7 = strAddress1;
                                // 住所２ 
                                chkDataTbl[intInsTblRow].Column8 = strAddress2;
                                // 電話番号
                                chkDataTbl[intInsTblRow].Column9 = strTelNo;
                                // 明細行フラグ
                                chkDataTbl[intInsTblRow].Column10 = strSplitFlg;
                                // ライセンシー社名
                                chkDataTbl[intInsTblRow].Column11 = strCompanyNm;
                                // 代表者名
                                chkDataTbl[intInsTblRow].Column12 = strName;
                                // 取引先コード
                                chkDataTbl[intInsTblRow].Column13 = strTorihikisakiCd;
                                // 初期G.OPEN年月日 
                                chkDataTbl[intInsTblRow].Column16 = strShokiGOpenNgp;
                                // G.OPEN年月日 
                                chkDataTbl[intInsTblRow].Column17 = strGOpenNgp;
                                // G.CLOSE年月日 
                                chkDataTbl[intInsTblRow].Column18 = strGCloseNgp;

                                // *** 色 ***
                                // 店舗コード
                                if (blnTenpoCd)
                                {
                                    colDataTbl[intInsTblRow].Column1 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column1 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // 店舗名
                                if (blnTenpoNm)
                                {
                                    colDataTbl[intInsTblRow].Column2 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column2 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // テリトリ
                                if (blnTerritory)
                                {
                                    colDataTbl[intInsTblRow].Column3 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column3 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // 店舗区分
                                if (blnTenpoKbn)
                                {
                                    colDataTbl[intInsTblRow].Column4 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column4 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // 勘定科目
                                if (blnKamokuCd)
                                {
                                    colDataTbl[intInsTblRow].Column5 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column5 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // 郵便番号
                                if (blnYubinNo)
                                {
                                    colDataTbl[intInsTblRow].Column6 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column6 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // 住所１
                                if (blnAddress1)
                                {
                                    colDataTbl[intInsTblRow].Column7 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column7 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // 住所２
                                if (blnAddress2)
                                {
                                    colDataTbl[intInsTblRow].Column8 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column8 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // 電話番号
                                if (blnTelNo)
                                {
                                    colDataTbl[intInsTblRow].Column9 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column9 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // 明細行フラグ
                                if (blnSplitFlg)
                                {
                                    colDataTbl[intInsTblRow].Column10 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column10 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // ライセンシー社名
                                if (blnCompanyNm)
                                {
                                    colDataTbl[intInsTblRow].Column11 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column11 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // 代表者名
                                if (blnName)
                                {
                                    colDataTbl[intInsTblRow].Column12 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column12 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // 取引先コード
                                if (blnTorihikisakiCd)
                                {
                                    colDataTbl[intInsTblRow].Column13 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column13 = KKHMacConst.C_CHECK_FALSE;
                                }

                                // 店舗コード（キー）
                                colDataTbl[intInsTblRow].Column15 = strTenpoCd;

                                // 初期G.OPEN年月日 
                                if (blnShokiGOpenNgp)
                                {
                                    colDataTbl[intInsTblRow].Column16 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column16 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // G.OPEN年月日 
                                if (blnGOpenNgp)
                                {
                                    colDataTbl[intInsTblRow].Column17 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column17 = KKHMacConst.C_CHECK_FALSE;
                                }
                                // G.CLOSE年月日 
                                if (blnGCloseNgp)
                                {
                                    colDataTbl[intInsTblRow].Column18 = KKHMacConst.C_CHECK_TRUE;
                                }
                                else
                                {
                                    colDataTbl[intInsTblRow].Column18 = KKHMacConst.C_CHECK_FALSE;
                                }

                                // インクリメント
                                intInsTblRow++;
                            }
                            // ###############################################################
                            // #                       差分無しデータ                        #
                            // ###############################################################
                            else
                            {
                                // 行追加
                                chkDataTbl.AddMasterDataVORow(chkDataTbl.NewMasterDataVORow());
                                // 行追加
                                colDataTbl.AddMasterDataVORow(colDataTbl.NewMasterDataVORow());
                                // 有効期限判定（切れていたら取込対象外）
                                if (!blnEnableFalse)
                                {
                                    // 有効期限が切れていない、ステータス"差分なし"
                                    chkDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_NONE;
                                    colDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_NONE;
                                }
                                else
                                {
                                    // 期限切れ、ステータス"削除"
                                    chkDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_DEL;
                                    colDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_DEL;
                                }
                                // *** データ ***
                                // 店舗コード
                                chkDataTbl[intInsTblRow].Column1 = strTenpoCd;
                                // 店舗名
                                chkDataTbl[intInsTblRow].Column2 = strTenpoNm;
                                // テリトリ
                                chkDataTbl[intInsTblRow].Column3 = strTerritory;
                                // 店舗区分
                                chkDataTbl[intInsTblRow].Column4 = strTenpoKbn;
                                // 勘定科目
                                chkDataTbl[intInsTblRow].Column5 = strKamokuCd;
                                // 郵便番号
                                chkDataTbl[intInsTblRow].Column6 = strYubinNo;
                                //都道府県が住所１に含まれている場合 
                                if (Regex.IsMatch(strAddress1, "^" + strTodofukenNm + "$"))
                                {
                                    // 住所１ 
                                    chkDataTbl[intInsTblRow].Column7 = strAddress1;
                                }
                                else
                                {
                                    // 住所１ 
                                    chkDataTbl[intInsTblRow].Column7 = strTodofukenNm + strAddress1;
                                }
                                // 住所１
                                //chkDataTbl[intInsTblRow].Column7 = strAddress1;
                                // 住所２
                                chkDataTbl[intInsTblRow].Column8 = strAddress2;
                                // 電話番号
                                chkDataTbl[intInsTblRow].Column9 = strTelNo;
                                // 明細行フラグ
                                chkDataTbl[intInsTblRow].Column10 = strSplitFlg;
                                // ライセンシー社名
                                chkDataTbl[intInsTblRow].Column11 = strCompanyNm;
                                // 代表者名
                                chkDataTbl[intInsTblRow].Column12 = strName;
                                // 取引先コード
                                chkDataTbl[intInsTblRow].Column13 = strTorihikisakiCd;
                                // 初期G.OPEN年月日 
                                chkDataTbl[intInsTblRow].Column16 = strShokiGOpenNgp;
                                // G.OPEN年月日 
                                chkDataTbl[intInsTblRow].Column17 = strGOpenNgp;
                                // G.CLOSE年月日 
                                chkDataTbl[intInsTblRow].Column18 = strGCloseNgp;

                                // *** 色 ***
                                // 店舗コード
                                colDataTbl[intInsTblRow].Column1 = KKHMacConst.C_CHECK_FALSE;
                                // 店舗名
                                colDataTbl[intInsTblRow].Column2 = KKHMacConst.C_CHECK_FALSE;
                                // テリトリ
                                colDataTbl[intInsTblRow].Column3 = KKHMacConst.C_CHECK_FALSE;
                                // 店舗区分
                                colDataTbl[intInsTblRow].Column4 = KKHMacConst.C_CHECK_FALSE;
                                // 勘定科目
                                colDataTbl[intInsTblRow].Column5 = KKHMacConst.C_CHECK_FALSE;
                                // 郵便番号
                                colDataTbl[intInsTblRow].Column6 = KKHMacConst.C_CHECK_FALSE;
                                // 住所１
                                colDataTbl[intInsTblRow].Column7 = KKHMacConst.C_CHECK_FALSE;
                                // 住所２
                                colDataTbl[intInsTblRow].Column8 = KKHMacConst.C_CHECK_FALSE;
                                // 電話番号
                                colDataTbl[intInsTblRow].Column9 = KKHMacConst.C_CHECK_FALSE;
                                // 明細行フラグ
                                colDataTbl[intInsTblRow].Column10 = KKHMacConst.C_CHECK_FALSE;
                                // ライセンシー社名
                                colDataTbl[intInsTblRow].Column11 = KKHMacConst.C_CHECK_FALSE;
                                // 代表者名
                                colDataTbl[intInsTblRow].Column12 = KKHMacConst.C_CHECK_FALSE;
                                // 取引先コード
                                colDataTbl[intInsTblRow].Column13 = KKHMacConst.C_CHECK_FALSE;
                                // 店舗コード（キー）
                                colDataTbl[intInsTblRow].Column15 = strTenpoCd;

                                // 初期G.OPEN年月日 
                                colDataTbl[intInsTblRow].Column16 = KKHMacConst.C_CHECK_FALSE;
                                // G.OPEN年月日 
                                colDataTbl[intInsTblRow].Column17 = KKHMacConst.C_CHECK_FALSE;
                                // G.CLOSE年月日 
                                colDataTbl[intInsTblRow].Column18 = KKHMacConst.C_CHECK_FALSE;

                                // インクリメント
                                intInsTblRow++;
                            }

                            # endregion 変更データチェック

                        }
                        // Excel Row インクリメント
                        intRow++;
                    }

                    # endregion エクセル取込 行

                    // *** Excel オブジェクト解放 ***
                    // workbookオブジェクトを閉じる
                    oWBook.Close(Type.Missing, Type.Missing, Type.Missing);

                    // Excel開放 
                    oXls.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oWBook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oXls);


                    # region 削除データ

                    // ###############################################################
                    // #                         削除データ                          #
                    // ###############################################################
                    // 既存データより削除データ確認 
                    foreach (MasterMaintenance.MasterDataVORow dtRow in mstDataTbl.Rows)
                    {
                        //頭が"9"の場合、処理しない 
                        if(dtRow.Column1.StartsWith("9"))
                        {
                            continue;
                        }

                        // Excelより生成したdTblから店舗コードにて絞り込む 
                        MasterMaintenance.MasterDataVORow[] mstDataRow = (MasterMaintenance.MasterDataVORow[])chkDataTbl.Select("Column1 = '" + dtRow.Column1 + "'");

                        // 該当レコードが無い場合、削除レコードと見なし積立を行う
                        if (mstDataRow.Length.Equals(0))
                        {
                            // 削除行追加
                            chkDataTbl.AddMasterDataVORow(chkDataTbl.NewMasterDataVORow());
                            // ステータス
                            chkDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_DEL;
                            // 店舗コード
                            chkDataTbl[intInsTblRow].Column1 = dtRow.Column1;
                            // 店舗名
                            chkDataTbl[intInsTblRow].Column2 = dtRow.Column2;
                            // テリトリ
                            chkDataTbl[intInsTblRow].Column3 = dtRow.Column3;
                            // 店舗区分
                            chkDataTbl[intInsTblRow].Column4 = dtRow.Column4;
                            // 勘定科目
                            chkDataTbl[intInsTblRow].Column5 = dtRow.Column5;
                            // 郵便番号
                            chkDataTbl[intInsTblRow].Column6 = dtRow.Column6;
                            ////都道府県が住所１に含まれている場合 
                            //if (Regex.IsMatch(strAddress1, "^" + strTodofukenNm + "$"))
                            //{
                            //    // 住所１ 
                            //    chkDataTbl[intInsTblRow].Column7 = strAddress1;
                            //}
                            //else
                            //{
                            //    // 住所１ 
                            //    chkDataTbl[intInsTblRow].Column7 = strTodofukenNm + strAddress1;
                            //}
                            // 住所１
                            chkDataTbl[intInsTblRow].Column7 = dtRow.Column7;
                            // 住所２
                            chkDataTbl[intInsTblRow].Column8 = dtRow.Column8;
                            // 電話番号
                            chkDataTbl[intInsTblRow].Column9 = dtRow.Column9;
                            // 明細行フラグ
                            chkDataTbl[intInsTblRow].Column10 = dtRow.Column10;
                            // ライセンシー社名
                            chkDataTbl[intInsTblRow].Column11 = dtRow.Column11;
                            // 代表者名
                            chkDataTbl[intInsTblRow].Column12 = dtRow.Column12;
                            // 取引先コード
                            chkDataTbl[intInsTblRow].Column13 = dtRow.Column13;
                            // 初期G.OPEN年月日 
                            chkDataTbl[intInsTblRow].Column16 = dtRow.Column16;
                            // G.OPEN年月日 
                            chkDataTbl[intInsTblRow].Column17 = dtRow.Column17;
                            // G.CLOSE年月日 
                            chkDataTbl[intInsTblRow].Column18 = dtRow.Column18;

                            // **********************************************************************
                            // ************************* 暫定版色対応 *******************************
                            // **********************************************************************
                            // 新規データ行追加
                            colDataTbl.AddMasterDataVORow(colDataTbl.NewMasterDataVORow());
                            // ステータス"削除"
                            colDataTbl[intInsTblRow].Column14 = KKHMacConst.C_INPUT_STAT_DEL;
                            // 店舗コード
                            colDataTbl[intInsTblRow].Column1 = KKHMacConst.C_CHECK_FALSE;
                            // 店舗名
                            colDataTbl[intInsTblRow].Column2 = KKHMacConst.C_CHECK_FALSE;
                            // テリトリ
                            colDataTbl[intInsTblRow].Column3 = KKHMacConst.C_CHECK_FALSE;
                            // 店舗区分
                            colDataTbl[intInsTblRow].Column4 = KKHMacConst.C_CHECK_FALSE;
                            // 勘定科目
                            colDataTbl[intInsTblRow].Column5 = KKHMacConst.C_CHECK_FALSE;
                            // 郵便番号
                            colDataTbl[intInsTblRow].Column6 = KKHMacConst.C_CHECK_FALSE;
                            // 住所１
                            colDataTbl[intInsTblRow].Column7 = KKHMacConst.C_CHECK_FALSE;
                            // 住所２
                            colDataTbl[intInsTblRow].Column8 = KKHMacConst.C_CHECK_FALSE;
                            // 電話番号
                            colDataTbl[intInsTblRow].Column9 = KKHMacConst.C_CHECK_FALSE;
                            // 明細行フラグ
                            colDataTbl[intInsTblRow].Column10 = KKHMacConst.C_CHECK_FALSE;
                            // ライセンシー社名
                            colDataTbl[intInsTblRow].Column11 = KKHMacConst.C_CHECK_FALSE;
                            // 代表者名
                            colDataTbl[intInsTblRow].Column12 = KKHMacConst.C_CHECK_FALSE;
                            // 取引先コード
                            colDataTbl[intInsTblRow].Column13 = KKHMacConst.C_CHECK_FALSE;
                            // 店舗コード（キー）
                            colDataTbl[intInsTblRow].Column15 = dtRow.Column1;
                            // 初期G.OPEN年月日 
                            chkDataTbl[intInsTblRow].Column16 = KKHMacConst.C_CHECK_FALSE;
                            // G.OPEN年月日 
                            chkDataTbl[intInsTblRow].Column17 = KKHMacConst.C_CHECK_FALSE;
                            // G.CLOSE年月日 
                            chkDataTbl[intInsTblRow].Column18 = KKHMacConst.C_CHECK_FALSE;

                            // **********************************************************************
                            // **********************************************************************

                            // インクリメント
                            intInsTblRow++;
                        }
                    }

                    # endregion 削除データ


                    //ローディング表示終了 
                    base.CloseLoadingDialog();

                    bool notChgFlg = false;
                    foreach (MasterMaintenance.MasterDataVORow row in chkDataTbl.Rows)
                    {
                        if (row.Column14 != KKHMacConst.C_INPUT_STAT_NONE)
                        {
                            notChgFlg = true;
                            break;
                        }
                    }

                    if (!notChgFlg)
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0023,
                        null,
                        C_APL_NM,
                        MessageBoxButtons.OK);

                        this.ActiveControl = null;

                        return;
                    }
                    // チェック一覧画面遷移用パラメータ生成
                    MastInputNaviParameter mstInNavi = new MastInputNaviParameter();
                    // 得意先企業コード
                    mstInNavi.strTksKgyCd = mstNavPrm.strTksKgyCd;
                    // 得意先部門コード
                    mstInNavi.strTksBmnSeqNo = mstNavPrm.strTksBmnSeqNo;
                    // 得意先担当者コード
                    mstInNavi.strTksTntSeqNo = mstNavPrm.strTksTntSeqNo;
                    // EsqId
                    mstInNavi.strEsqId = mstNavPrm.strEsqId;
                    // Egcd
                    mstInNavi.strEgcd = mstNavPrm.strEgcd;
                    // 日付
                    mstInNavi.strDate = mstNavPrm.strDate;
                    // 担当者名
                    mstInNavi.strName = mstNavPrm.strName;
                    // 積立Dtbl
                    mstInNavi.dsMerge = chkDataTbl;
                    // 積立（色）Dtbl
                    mstInNavi.dsMergeColor = colDataTbl;
                    // 得意先企業名称
                    mstInNavi.strTksKgyName = mstNavPrm.strTksKgyName;
                    // マスターキー
                    mstInNavi.strMasterKey = KKHMacConst.C_MAST_TENPO_CD;
                    // チェック一覧画面表示
                    Navigator.ShowModalForm(this, "tofrmMastMergeMac", mstInNavi);

                    this.ActiveControl = null;
                }
                else
                {
                    this.ActiveControl = null;

                    return;
                }
            }
            catch (COMException ComEx)
            {

                //ローディング表示終了 
                base.CloseLoadingDialog();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oWBook);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(oXls);

                MessageUtility.ShowMessageBox(MessageCode.HB_W0020
                                ,new string[]{System.Environment.NewLine, System.Environment.NewLine + ComEx.InnerException}
                                , C_APL_NM
                                ,MessageBoxButtons.OK);

                this.ActiveControl = null;

                return;
            }
            catch (Exception ex)
            {
                //ローディング表示終了 
                base.CloseLoadingDialog();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oWBook);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(oXls);

                MessageUtility.ShowMessageBox(MessageCode.HB_E0002,
                    new string[] { System.Environment.NewLine, System.Environment.NewLine + ex.InnerException },
                    C_APL_NM,
                    MessageBoxButtons.OK);

                this.ActiveControl = null;

                return;
            }
        }

        #endregion

        #region 追加ボタンクリック(店舗パターン)

        /// <summary>
        /// 追加ボタンクリック(店舗パターン)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPtnAdd_Click(object sender, EventArgs e)
        {
            // パターンコード
            int ptnCd = 0;

            // 名称未設定の行数
            int UntitledCnt = 1;

            // スプレッドからパターン情報を取得
            MasterMaintenance.MasterDataVODataTable ptnDt = (MasterMaintenance.MasterDataVODataTable)spdPtn.DataSource;

            // パターンの行数チェック
            if (ptnDt.Rows.Count >= C_MAXROW_TENPO_PATTERN_MASTER)
            {
                MessageBox.Show("パターンは最大999件までしか登録できません","警告",MessageBoxButtons.OK);
                this.ActiveControl = null;
                return;
            }

            foreach (MasterMaintenance.MasterDataVORow dr in ptnDt.Rows)
            {
                // 名称未設定の行数をカウント
                if (dr.Column2.Contains(KKHMacConst.C_DEFAULT_PTN_NM))
                {
                    UntitledCnt++;
                }

                // パターンコードの最大値を取得
                if (ptnCd < int.Parse(dr.Column1))
                {
                   ptnCd = int.Parse(dr.Column1);
                }
            }

            // パターンコードが最大行数まで採番されている場合
            if (ptnCd == C_MAXROW_TENPO_PATTERN_MASTER)
            {
                // 空いているパターンコードを取得
                ptnCd = GetPatternCode(ptnDt);
            }
            else
            {
                // パターンコードをインクリメント
                ptnCd = ptnCd + 1;
            }

            // パターン情報へ新規行を追加
            ptnDt.AddMasterDataVORow(DateTime.Now,
                C_APL_ID,
                mstNavPrm.strEsqId,
                DateTime.Now,
                C_APL_ID,
                mstNavPrm.strEsqId,
                mstNavPrm.strEgcd,
                mstNavPrm.strTksKgyCd,
                mstNavPrm.strTksBmnSeqNo,
                mstNavPrm.strTksTntSeqNo,
                "103",
                ptnCd.ToString("000"),
                KKHMacConst.C_DEFAULT_PTN_NM + UntitledCnt,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null);

            // パターン情報をスプレッドに設定
            spdPtn.DataSource = ptnDt;

            // 更新フラグON
            base.upchk = true;

            this.ActiveControl = null;

        }

        #endregion

        #region 削除ボタンクリック(店舗パターン)

        /// <summary>
        /// 削除ボタンクリック(店舗パターン)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPtnDel_Click(object sender, EventArgs e)
        {
            // 店舗パターン一覧に行が存在しない場合、処理終了
            if (spdPtn_Sheet1.Rows.Count == 0)
            {
                this.ActiveControl = null;

                return;
            }

            // スプレッドから店舗パターンマスターを取得
            MasterMaintenance.MasterDataVODataTable ptnDt = (MasterMaintenance.MasterDataVODataTable)spdPtn.DataSource;
            
            // パターンコード取得
            string patternCode = ptnDt.Rows[spdPtn_Sheet1.ActiveRowIndex][11].ToString();

            // 店舗パターンマスターからアクティブ行を削除
            ptnDt.Rows.RemoveAt(spdPtn.Sheets[0].ActiveRowIndex);

            // 店舗パターンマスターをスプレッドに設定
            spdPtn.DataSource = ptnDt;

            for (int rowIndex = spdTenpoPtn_Sheet1.Rows.Count - 1; rowIndex >= 0; rowIndex--)
            {
                if (spdTenpoPtn_Sheet1.Cells[rowIndex, 14].Value.ToString() == patternCode)
                {
                    spdTenpoPtn_Sheet1.Rows.Remove(rowIndex, 1);
                }
            }

            // 更新フラグON
            base.upchk = true;

            this.ActiveControl = null;
        }

        #endregion

        #region 変更ボタンクリック(店舗パターン)

        /// <summary>
        /// 変更ボタンクリック(店舗パターン)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPtnEdt_Click(object sender, EventArgs e)
        {
            // 店舗パターン一覧に行が存在しない場合、処理終了
            if (spdPtn_Sheet1.Rows.Count == 0)
            {
                return;
            }

            // アクティブセルの情報を取得
            activeRow = spdPtn_Sheet1.ActiveRowIndex;
            activeCol = spdPtn_Sheet1.ActiveColumnIndex;

            // 店舗パターン名称をメモリ上に保持
            beforeTenpoPatternName = spdPtn_Sheet1.ActiveCell.Text;

            // セルを編集可能にする
            spdPtn_Sheet1.ActiveCell.Locked = false;
            spdPtn.EditModeReplace = true;
            spdPtn.StartCellEditing(e, false);

            // 編集フラグをtrueに設定
            PtnReNameFlg = true;

            // 更新フラグON
            base.upchk = true;

            this.ActiveControl = null;

        }

        #endregion

        #region セル移動(店舗パターン)

        /// <summary>
        /// セル移動イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdPtn_LeaveCell(object sender, FarPoint.Win.Spread.LeaveCellEventArgs e)
        {
            // 編集中の場合、セルを編集不可に設定する。
            if (PtnReNameFlg)
            {
                // 空欄の場合
                if (string.IsNullOrEmpty(spdPtn_Sheet1.Cells[activeRow, activeCol].Text.Trim()) == true)
                {
                    // 店舗パターン名称を戻す
                    spdPtn_Sheet1.Cells[activeRow, activeCol].Text = beforeTenpoPatternName;
                }

                spdPtn_Sheet1.Cells[activeRow, activeCol].Locked = true;
                PtnReNameFlg = false;
            }
        }

        #endregion

        #region 選択行変更(店舗パターン)

        /// <summary>
        /// 選択行変更(店舗パターン)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdPtn_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            if (spdTenpoPtn_Sheet1.Rows.Count == 0)
            {
                return;
            }

            this.ChangeFilterValue();
        }

        #endregion

        #region ▼ボタンクリック(店舗パターン情報追加)

        /// <summary>
        /// ▼ボタンクリック(店舗パターン情報追加)
        /// ：店舗マスター一覧で選択した内容で店舗パターン情報を追加する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            // 店舗パターン一覧からパターンコードを取得
            string patternCode = spdPtn_Sheet1.Cells[spdPtn_Sheet1.ActiveRowIndex, 11].Value.ToString();

            // 店舗パターン情報マスター取得
            MasterMaintenance.MasterDataVODataTable tmpPtnDt = (MasterMaintenance.MasterDataVODataTable)spdTenpoPtn.DataSource;

            // 店舗マスターの行数分繰り返す
            for (int i = 0; i < spdTenpoMas_Sheet1.Rows.Count; i++)
            {
                // 店舗マスター一覧で行にチェックが入っている場合
                if (spdTenpoMas_Sheet1.Cells[i, 0].Value.Equals(true))
                {
                    // 店舗マスター一覧から店舗コード、店舗名を取得
                    string tenpoCode = spdTenpoMas_Sheet1.Cells[i, 12].Value.ToString();
                    string tenpoName = spdTenpoMas_Sheet1.Cells[i, 13].Value.ToString();

                    // 店舗パターン情報マスターに追加対象の店舗コードが存在しない場合
                    if (tmpPtnDt.Select("Column2 = '" + tenpoCode + "' And Column3 = '" + patternCode + "'").Length == 0)
                    {
                        // 店舗パターン情報マスターに追加
                        tmpPtnDt.AddMasterDataVORow(
                            DateTime.Now,
                            C_APL_ID,
                            mstNavPrm.strEsqId,
                            DateTime.Now,
                            C_APL_ID,
                            mstNavPrm.strEsqId,
                            mstNavPrm.strEgcd,
                            mstNavPrm.strTksKgyCd,
                            mstNavPrm.strTksBmnSeqNo,
                            mstNavPrm.strTksTntSeqNo,
                            "105",
                            patternCode + tenpoCode,
                            tenpoCode,
                            patternCode,
                            tenpoName,
                            "0",
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            "True");

                        // 更新フラグON
                        base.upchk = true;
                    }
                }

                // 店舗マスターのチェックを外す
                spdTenpoMas_Sheet1.Cells[i, KKHMacConst.C_INDEX_INPUTDATA_CHECKBOX].Value = false;
            }

            // 一覧に店舗パターン情報マスターを設定
            spdTenpoPtn.DataSource = tmpPtnDt;

            this.ChangeFilterValue();

            this.ActiveControl = null;
        }

        #endregion

        #region 店舗絞込ボタンクリック

        /// <summary>
        /// 店舗絞込ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNarrow_Click(object sender, EventArgs e)
        {
            // 店舗マスターにレコードが存在しない場合、処理終了
            if (TenpoMasterVODataTable.Rows.Count == 0)
            {
                this.ActiveControl = null;

                return;
            }

            // ダイアログ表示
            object result = Navigator.ShowModalForm(this, "tofrmMastMacNarrowDown", DialogParameter);

            // 戻り値がナビパラメータの場合
            if (result is MastNarrowDownNaviParameter)
            {
                // パラメータ取得
                DialogParameter = (MastNarrowDownNaviParameter)result;
            }
            else
            {
                this.ActiveControl = null;
                // 処理終了
                return;
            }

            // 絞り込み条件用StringBuilderのインスタンス生成
            StringBuilder selectCondition = new StringBuilder();

            #region 店舗コード条件を追加

            // 絞り込み条件に店舗コード条件を追加
            switch (DialogParameter.tenCdCmb)
            {
                case 0:
                    break;
                case 1:
                    // 完全一致
                    selectCondition.Append("Column1 = '" + DialogParameter.tenCd + "'");
                    break;
                case 2:
                    // 以上
                    selectCondition.Append("Column1 >= '" + DialogParameter.tenCd + "'");
                    break;
                case 3:
                    // 以下
                    selectCondition.Append("Column1 <= '" + DialogParameter.tenCd + "'");
                    break;
                case 4:
                    // ～
                    selectCondition.Append("Column1 >= '" + DialogParameter.tenCd + "' AND Column1 <= '" + DialogParameter.tenCd2 + "'");
                    break;
            }

            #endregion

            #region テリトリー条件を追加

            // テリトリー用StringBuilderのインスタンス生成
            StringBuilder territoryCondition = new StringBuilder();

            // 関東が選択されている場合
            if (DialogParameter.terKanto)
            {
                territoryCondition.Append("'1',");
                territoryCondition.Append("'関東',");
            }

            // 関西が選択されている場合
            if (DialogParameter.terKansai)
            {
                territoryCondition.Append("'2',");
                territoryCondition.Append("'関西',");
            }

            // 中央が選択されている場合
            if (DialogParameter.terTyuou)
            {
                territoryCondition.Append("'3',");
                territoryCondition.Append("'中央',");
            }

            // その他が選択されている場合
            if (DialogParameter.terSonota)
            {
                territoryCondition.Append("'4',");
                territoryCondition.Append("'その他',");
            }

            // 他の絞り込み条件が既に追加されている場合
            if (selectCondition.Length != 0)
            {
                selectCondition.Append(" And ");
            }

            // 絞り込み条件にテリトリー条件を追加
            selectCondition.Append("Column3 IN (" + territoryCondition.ToString(0, territoryCondition.Length - 1) + ")");

            #endregion

            #region 店舗区分条件を追加

            // 店舗区分用StringBuilderのインスタンス生成
            StringBuilder tenpoKbnCondition = new StringBuilder();

            // 地区本部が選択されている場合
            if (DialogParameter.kbnTikuhonbu)
            {
                tenpoKbnCondition.Append("'0',");
                tenpoKbnCondition.Append("'地区本部',");
            }

            // MC直営店が選択されている場合
            if (DialogParameter.kbnMc)
            {
                tenpoKbnCondition.Append("'1',");
                tenpoKbnCondition.Append("'MC直営店',");
            }

            // ライセンシーが選択されている場合
            if (DialogParameter.kbnLicensee)
            {
                tenpoKbnCondition.Append("'2',");
                tenpoKbnCondition.Append("'ライセンシー',");
            }

            // その他が選択されている場合
            if (DialogParameter.kbnSonota)
            {
                tenpoKbnCondition.Append("'3',");
                tenpoKbnCondition.Append("'その他',");
            }

            // 他の絞り込み条件が既に追加されている場合
            if (selectCondition.Length != 0)
            {
                selectCondition.Append(" And ");
            }

            // 絞り込み条件に店舗区分条件を追加
            selectCondition.Append("Column4 IN (" + tenpoKbnCondition.ToString(0, tenpoKbnCondition.Length - 1) + ")");

            #endregion

            #region 店舗名条件を追加

            // 店舗名が存在する場合
            if (string.IsNullOrEmpty(DialogParameter.tenName) == false)
            {
                // 他の絞り込み条件が既に追加されている場合
                if (selectCondition.Length != 0)
                {
                    selectCondition.Append(" And ");
                }

                // 絞り込み条件に店舗区分条件を追加
                selectCondition.Append("Column2 like '%" + DialogParameter.tenName + "%'");
            }

            #endregion

            // 店舗マスター用DataTableのインスタンス生成
            MasterMaintenance.MasterDataVODataTable tenpoMasterDataTable = new MasterMaintenance.MasterDataVODataTable();

            // 店舗マスター用DataTableに絞り込んだレコードを追加
            foreach (MasterMaintenance.MasterDataVORow arow in TenpoMasterVODataTable.Select(selectCondition.ToString()))
            {
                tenpoMasterDataTable.ImportRow(arow);
            }

            // 一覧に店舗マスターを設定
            spdTenpoMas.DataSource = tenpoMasterDataTable;

            // 一覧の表示設定
            SpreadSetting(spdTenpoMas, KKHMacConst.C_MAST_TENPO_CD);
            
            // 絞込解除ボタンを表示
            btnLeave.Visible = true;

            this.ActiveControl = null;

        }

        #endregion

        #region 絞込解除ボタンクリック

        /// <summary>
        /// 絞込解除ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void btnLeave_Click(object sender, EventArgs e)
        {
            // 一覧に店舗マスターを設定
            spdTenpoMas.DataSource = TenpoMasterVODataTable;

            // 一覧の表示設定
            SpreadSetting(spdTenpoMas, KKHMacConst.C_MAST_TENPO_CD);

            // 絞込解除ボタンを非表示
            btnLeave.Visible = false;

            this.ActiveControl = null;

        }

        #endregion

        #region 更新ボタンクリック(店舗パターンマスター)

        /// <summary>
        /// 更新ボタンクリック(店舗パターンマスター)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateTenpoPattern_Click(object sender, EventArgs e)
        {
            // 確認メッセージ表示 
            DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_C0005, null, "マスターメンテナンス", MessageBoxButtons.YesNo);
            if (check == DialogResult.No)
            {
                this.ActiveControl = null;

                return;
            }

            //マスターデータ更新 
            this.UpdateMasterTables();
            
            //更新済みフラグ
            base.upchk = false;

            this.ActiveControl = null;

        }

        #endregion

        #endregion

        #region "メソッド"

        #region ボタン設定(店舗マスター(単一検索)タブ)

        /// <summary>
        /// ボタン設定(店舗マスター(単一検索)タブ)
        /// ：店舗マスター(単一検索)タブ選択時のボタン設定を行う。
        /// </summary>
        private void SetButtonPropertyTenpoMaster_FirstTab()
        {
            // 取込ボタンを非表示
            btnInputData.Visible = false;

            // 再表示ボタンを非表示
            btnRev.Visible = false;

            // 新規ボタン(継承)を非表示
            btnCrt.Visible = false;

            // 新規ボタン(店舗マスター(単一検索)タブ)を表示・使用可
            btnNew.Visible = true;
            btnNew.Enabled = true;

            // 削除ボタン(継承)を非表示
            btnDel.Visible = false;

            // 削除ボタン(店舗マスター(単一検索)タブ)を表示・使用不可
            btnClr.Visible = true;
            btnClr.Enabled = false;

            // 更新ボタン(継承)を非表示 
            btnUpd.Visible = false;

            // 更新ボタン(店舗マスター(単一検索)タブ)を表示・使用可
            btnUpd2.Visible = true;
            btnUpd2.Enabled = true;

            // 更新ボタン(店舗パターンマスター)を非表示
            btnUpdateTenpoPattern.Visible = false;

            // コード変換ボタンを使用不可
            btnChgCode.Enabled = false;

            // 2012/02/01 add start H.Okazaki
            // 履歴ボタン(店舗マスター(単一検索)タブ)を表示・使用可
            btnTnpRrkS.Visible = true;
            btnTnpRrkS.Enabled = true;

            // 履歴ボタン(店舗マスター(一覧検索)タブ)を非表示
            btnTnpRrkA.Visible = false;
            // 2012/02/01 add end H.Okazaki

        }

        #endregion

        #region ボタン設定(店舗マスター(一覧表示)タブ)

        /// <summary>
        /// ボタン設定(店舗マスター(一覧表示)タブ)
        /// ：店舗マスター(一覧表示)タブ選択時のボタン設定を行う。
        /// </summary>
        private void SetButtonPropertyTenpoMaster_SecondTab()
        {
            // 取込ボタンを表示
            btnInputData.Visible = true;
            btnInputData.Enabled = true;

            // 再表示ボタンを表示
            btnRev.Visible = true;
            btnRev.Enabled = true;

            // 新規ボタン(継承)を表示
            btnCrt.Visible = true;
            btnCrt.Enabled = true;

            // 新規ボタン(店舗マスター(単一検索)タブ)を非表示
            btnNew.Visible = false;

            // 削除ボタン(継承)を表示
            btnDel.Visible = true;
            btnDel.Enabled = true;

            // 削除ボタン(店舗マスター(単一検索)タブ)を非表示
            btnClr.Visible = false;

            // 更新ボタン(継承)を表示 
            btnUpd.Visible = true;
            btnUpd.Enabled = true;

            // 更新ボタン(店舗マスター(単一検索)タブ)を非表示
            btnUpd2.Visible = false;

            // 更新ボタン(店舗パターンマスター)を非表示
            btnUpdateTenpoPattern.Visible = false;

            // 2012/02/01 add start H.Okazaki
            // 履歴ボタン(店舗マスター(単一検索)タブ)を非表示
            btnTnpRrkS.Visible = false;

            // 履歴ボタン(店舗マスター(一覧検索)タブ)を表示・使用可
            btnTnpRrkA.Visible = true;
            btnTnpRrkA.Enabled = true;
            // 2012/02/01 add end H.Okazaki
        }

        #endregion

        #region ボタン設定(店舗パターンマスター選択)

        /// <summary>
        /// ボタン設定(店舗パターンマスター選択)
        /// ：マスター名コンボボックスで店舗パターンマスターを選択した時のボタン設定を行う。
        /// </summary>
        private void SetButtonPropertySelectTenpoPatternMaster()
        {
            // 取込ボタンを非表示
            btnInputData.Visible = false;

            // 再表示ボタンを表示
            btnRev.Visible = true;

            // 新規ボタン(継承)を表示・使用不可
            btnCrt.Visible = true;
            btnCrt.Enabled = false;

            // 新規ボタン(店舗マスター(単一検索)タブ)を非表示 
            btnNew.Visible = false;

            // 削除ボタン(継承)を表示・使用不可 
            btnDel.Visible = true;
            btnDel.Enabled = false;

            // 削除ボタン(店舗マスター(単一検索)タブ)を非表示 
            btnClr.Visible = false;

            // 更新ボタン(継承)を非表示 
            btnUpd.Visible = false;

            // 更新ボタン(店舗マスター(単一検索)タブ)を非表示 
            btnUpd2.Visible = false;

            // 更新ボタン(店舗パターンマスター)を表示
            btnUpdateTenpoPattern.Visible = true;

            // 2012/02/01 add start H.Okazaki
            // 履歴ボタン(店舗マスター(単一検索)タブ)を非表示
            btnTnpRrkS.Visible = false;

            // 履歴ボタン(店舗マスター(一覧検索)タブ)を非表示
            btnTnpRrkA.Visible = false;
            // 2012/02/01 add end H.Okazaki
        }

        #endregion

        #region ボタン設定(その他マスター選択)

        /// <summary>
        /// ボタン設定(その他マスター選択)
        /// ：マスター名コンボボックスで店舗マスター・店舗パターンマスター以外を選択した時のボタン設定を行う。
        /// </summary>
        private void SetButtonPropertySelectOtherMaster()
        {
            // 取込ボタンを非表示
            btnInputData.Visible = false;

            // 再表示ボタンを表示
            btnRev.Visible = true;

            // 新規ボタン(継承)を表示・使用可
            btnCrt.Visible = true;
            btnCrt.Enabled = true;

            // 新規ボタン(店舗マスター(単一検索)タブ)を非表示
            btnNew.Visible = false;

            // 削除ボタン(継承)を表示・使用可
            btnDel.Visible = true;
            btnDel.Enabled = true;

            // 削除ボタン(店舗マスター(単一検索)タブ)を非表示
            btnClr.Visible = false;

            // 更新ボタン(継承)を表示 
            btnUpd.Visible = true;

            // 更新ボタン(店舗マスター(単一検索)タブ)を非表示
            btnUpd2.Visible = false;

            // 更新ボタン(店舗パターンマスター)を非表示
            btnUpdateTenpoPattern.Visible = false;

            // 2012/02/01 add start H.Okazaki
            // 履歴ボタン(店舗マスター(単一検索)タブ)を非表示
            btnTnpRrkS.Visible = false;

            // 履歴ボタン(店舗マスター(一覧検索)タブ)を非表示
            btnTnpRrkA.Visible = false;
            // 2012/02/01 add end H.Okazaki

        }

        #endregion

        #region 入力項目初期化(店舗マスター(単一検索)タブ)

        /// <summary>
        /// 入力項目初期化(店舗マスター(単一検索)タブ)
        /// ：店舗マスター(単一検索)タブの入力項目を初期化する。
        /// </summary>
        /// <param name="isInitTenpoCode">店舗コードを初期化するか判別するフラグ</param>
        private void InitInputItemTenpoMaster_FirstTab(bool isInitTenpoCode)
        {
            // コード変換モードの場合
            if (IsChangeCodeMode == true)
            {
                // コード変換後表示設定（解除）
                this.AfterCodeChange(true);
            }

            // 店舗コード
            if (isInitTenpoCode == true)
            {
                txtTenpoCd.Text = string.Empty;
            }

            // 店舗名 
            txtTenpoNm.Text = string.Empty;

            // 電話番号 
            txtTelNo.Text = string.Empty;

            // 郵便番号 
            txtYubinNo.Text = string.Empty;

            // 住所１ 
            txtAddress1.Text = string.Empty;

            // 住所２ 
            txtAddress2.Text = string.Empty;

            // 勘定科目 
            txtKamoku.Text = string.Empty;

            // 初期G.OPEN年月日
            SGOpen.Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(mstNavPrm.strDate);
            SGOpen.Value = null;

            // G.OPEN年月日
            GOpen.Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(mstNavPrm.strDate);
            GOpen.Value = null;

            // G.CLOSE年月日
            GClose.Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(mstNavPrm.strDate);
            GClose.Value = null;

            // ライセンシー社名 
            txtCompanyNm.Text = string.Empty;

            // 代表者名 
            txtName.Text = string.Empty;

            // 取引先コード 
            txtTorihikisakiCd.Text = string.Empty;

            // テリトリー 
            rdbTerritory1.Checked = false;
            rdbTerritory2.Checked = false;
            rdbTerritory3.Checked = false;
            rdbTerritory4.Checked = false;

            // 店舗区分 
            rdbTenpo1.Checked = false;
            rdbTenpo2.Checked = false;
            rdbTenpo3.Checked = false;
            rdbTenpo4.Checked = false;

            // 明細行フラグ 
            rdbSplitFlg1.Checked = false;
            rdbSplitFlg2.Checked = false;

            // 編集中店舗マスター行初期化
            MasterMaintenance.MasterDataVODataTable tenpoMasterDataTable = new MasterMaintenance.MasterDataVODataTable();
            rowTenpoMaster = tenpoMasterDataTable.NewMasterDataVORow();

            // 変更前店舗コード
            beforeTenpoCd = string.Empty;

            // 変更前削除ボタン使用可否
            beforeDeleteButtonEnabled = false;

        }

        #endregion

        #region 店舗マスター検索後表示設定（デフォルト値）

        /// <summary>
        /// 店舗マスター検索後表示設定（デフォルト値）
        /// ：店舗マスター単一検索後の表示設定を行う。
        /// </summary>
        private void AfterSearchTenpoMaster()
        {
            // 店舗名 
            txtTenpoNm.Text = string.Empty;

            // 電話番号 
            txtTelNo.Text = string.Empty;

            // 郵便番号 
            txtYubinNo.Text = string.Empty;

            // 住所１ 
            txtAddress1.Text = string.Empty;

            // 住所２ 
            txtAddress2.Text = string.Empty;

            // 勘定科目 
            txtKamoku.Text = string.Empty;

            // ライセンシー社名 
            txtCompanyNm.Text = string.Empty;

            // 代表者名 
            txtName.Text = string.Empty;

            // 取引先コード 
            txtTorihikisakiCd.Text = string.Empty;

            // テリトリー（”関東”選択状態） 
            rdbTerritory1.Checked = true;

            // 店舗区分（”MC直営店”選択状態）
            rdbTenpo2.Checked = true;

            // 明細行フラグ（”非分割”選択状態） 
            rdbSplitFlg2.Checked = true;

            // 初期G.OPEN年月日
            SGOpen.Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(mstNavPrm.strDate);
            SGOpen.Value = null;

            // G.OPEN年月日
            GOpen.Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(mstNavPrm.strDate);
            GOpen.Value = null;

            // G.CLOSE年月日
            GClose.Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(mstNavPrm.strDate);
            GClose.Value = null;

            // コード変換ボタン使用不可 
            btnChgCode.Enabled = false;

            // 削除ボタン使用不可
            btnClr.Enabled = false;
        }

        #endregion

        #region 店舗マスター検索後表示設定（該当データあり）

        /// <summary>
        /// 店舗マスター検索後表示設定（該当データあり）
        /// ：店舗マスター単一検索後の表示設定を行う。
        /// </summary>
        /// <param name="rowData">店舗マスターのレコード</param>
        private void AfterSearchTenpoMaster(MasterMaintenance.MasterDataVORow rowData)
        {
            // 店舗名 
            txtTenpoNm.Text = rowData.Column2;

            // 電話番号 
            txtTelNo.Text = rowData.Column9;

            // 郵便番号 
            txtYubinNo.Text = rowData.Column6;

            // 住所１ 
            txtAddress1.Text = rowData.Column7;

            // 住所２ 
            txtAddress2.Text = rowData.Column8;

            // 勘定科目 
            txtKamoku.Text = rowData.Column5;

            // ライセンシー社名 
            txtCompanyNm.Text = rowData.Column11;

            // 代表者名 
            txtName.Text = rowData.Column12;

            // 取引先コード 
            txtTorihikisakiCd.Text = rowData.Column13;

            // 初期G.OPEN年月日
            if (rowData.Column15.Trim() != "")
            {
                SGOpen.Value = System.DateTime.Now;
                SGOpen.Text = rowData.Column15;
            }

            // G.OPEN年月日
            if (rowData.Column16.Trim() != "")
            {
                GOpen.Value = System.DateTime.Now;
                GOpen.Text = rowData.Column16;
            }

            // G.CLOSE年月日
            if (rowData.Column17.Trim() != "")
            {
                GClose.Value = System.DateTime.Now;
                GClose.Text = rowData.Column17;
            }
            // テリトリー 
            switch (rowData.Column3)
            {
                // 関東
                case KKHMacConst.C_TERRITORY_CD1:
                    rdbTerritory1.Checked = true;
                    break;
                // 関西
                case KKHMacConst.C_TERRITORY_CD2:
                    rdbTerritory2.Checked = true;
                    break;
                // 中央
                case KKHMacConst.C_TERRITORY_CD3:
                    rdbTerritory3.Checked = true;
                    break;
                // その他
                case KKHMacConst.C_TERRITORY_CD4:
                    rdbTerritory4.Checked = true;
                    break;
            }

            // 店舗区分 
            switch (rowData.Column4)
            {
                // 地区本部
                case KKHMacConst.C_TENPO_KBN_CD1:
                    rdbTenpo1.Checked = true;
                    break;
                // MC直営店
                case KKHMacConst.C_TENPO_KBN_CD2:
                    rdbTenpo2.Checked = true;
                    break;
                // ライセンシー
                case KKHMacConst.C_TENPO_KBN_CD3:
                    rdbTenpo3.Checked = true;
                    break;
                // その他
                case KKHMacConst.C_TENPO_KBN_CD4:
                    rdbTenpo4.Checked = true;
                    break;
            }

            // 明細行フラグ 
            switch (rowData.Column10)
            {
                // 分割する
                case KKHMacConst.C_SPLIT_FLG_CD1:
                    rdbSplitFlg1.Checked = true;
                    break;
                // 分割しない
                case KKHMacConst.C_SPLIT_FLG_CD2:
                    rdbSplitFlg2.Checked = true;
                    break;
            }

            // コード変換ボタン使用可 
            btnChgCode.Enabled = true;

            // 削除ボタン使用可
            btnClr.Enabled = true;
        }

        #endregion

        #region 店舗マスター検索後表示設定（該当データあり）

        /// <summary>
        /// 店舗履歴選択後表示設定
        /// ：店舗履歴選択後の表示設定を行う。
        /// </summary>
        /// <param name="rowData">店舗マスターのレコード</param>
        private void AfterSelectTenpoRrk(DataTable dt)
        {
            MastDSMac.DisplayTenpoRrkRow rowData = (MastDSMac.DisplayTenpoRrkRow)dt.Rows[0];

            // 店舗コードのTextChangedイベントを無効にする
            txtTenpoCd.TextChanged -= new System.EventHandler(this.txtTenpoCd_TextChanged);

            // 店舗コード
            txtTenpoCd.Text = rowData.tenpoCd;

            // 店舗名 
            txtTenpoNm.Text = rowData.tenpoNm;

            // 電話番号 
            txtTelNo.Text = rowData.telNo;

            // 郵便番号 
            txtYubinNo.Text = rowData.yubinNo;

            // 住所１ 
            txtAddress1.Text = rowData.address1;

            // 住所２ 
            txtAddress2.Text = rowData.address2;

            // 勘定科目 
            txtKamoku.Text = rowData.kamoku;

            // ライセンシー社名 
            txtCompanyNm.Text = rowData.companyNm;

            // 代表者名 
            txtName.Text = rowData.name;

            // 取引先コード 
            txtTorihikisakiCd.Text = rowData.torihikiCd;

            // 初期G.OPEN年月日
            if (rowData.sGOpen.Trim() != "")
            {
                SGOpen.Value = System.DateTime.Now;
                SGOpen.Text = rowData.sGOpen;
            }

            // G.OPEN年月日
            if (rowData.gOpen.Trim() != "")
            {
                GOpen.Value = System.DateTime.Now;
                GOpen.Text = rowData.gOpen;
            }

            // G.CLOSE年月日
            if (rowData.gClose.Trim() != "")
            {
                GClose.Value = System.DateTime.Now;
                GClose.Text = rowData.gClose;
            }
            // テリトリー 
            switch (rowData.territory)
            {
                // 関東
                case KKHMacConst.C_TERRITORY_CD1:
                    rdbTerritory1.Checked = true;
                    break;
                // 関西
                case KKHMacConst.C_TERRITORY_CD2:
                    rdbTerritory2.Checked = true;
                    break;
                // 中央
                case KKHMacConst.C_TERRITORY_CD3:
                    rdbTerritory3.Checked = true;
                    break;
                // その他
                case KKHMacConst.C_TERRITORY_CD4:
                    rdbTerritory4.Checked = true;
                    break;
            }

            // 店舗区分 
            switch (rowData.tenpoKbn)
            {
                // 地区本部
                case KKHMacConst.C_TENPO_KBN_CD1:
                    rdbTenpo1.Checked = true;
                    break;
                // MC直営店
                case KKHMacConst.C_TENPO_KBN_CD2:
                    rdbTenpo2.Checked = true;
                    break;
                // ライセンシー
                case KKHMacConst.C_TENPO_KBN_CD3:
                    rdbTenpo3.Checked = true;
                    break;
                // その他
                case KKHMacConst.C_TENPO_KBN_CD4:
                    rdbTenpo4.Checked = true;
                    break;
            }

            // 明細行フラグ 
            switch (rowData.splitFlg)
            {
                // 分割する
                case KKHMacConst.C_SPLIT_FLG_CD1:
                    rdbSplitFlg1.Checked = true;
                    break;
                // 分割しない
                case KKHMacConst.C_SPLIT_FLG_CD2:
                    rdbSplitFlg2.Checked = true;
                    break;
            }

            // コード変換ボタン使用可 
            btnChgCode.Enabled = true;

            // 削除ボタン使用可
            btnClr.Enabled = true;

            // 店舗コードのTextChangedイベントを有効にする
            txtTenpoCd.TextChanged += new System.EventHandler(this.txtTenpoCd_TextChanged);

        #endregion
        }

        #region コード変換ボタンクリック後表示設定

        /// <summary>
        /// コード変換ボタンクリック後表示設定
        /// ：コード変換ボタンがクリックされた後の表示設定を行う。
        /// </summary>
        /// <param name="enabledValue">画面項目へ設定する値</param>
        private void AfterCodeChange(bool enabledValue)
        {
            // 画面項目への設定値がtrueの場合
            if (enabledValue == true)
            {
                // 店舗コードの背景色を白に設定
                txtTenpoCd.BackColor = Color.White;

                // 店舗コード変更モードを解除 
                IsChangeCodeMode = false;
            }
            else
            {
                // 店舗コードの背景色を赤に設定
                txtTenpoCd.BackColor = Color.Red;

                // 店舗コード変更モードへ設定
                IsChangeCodeMode = true;
            }

            // 店舗名 
            lblTenpoNm.Enabled = enabledValue;
            txtTenpoNm.Enabled = enabledValue;

            // 電話番号 
            lblTelNo.Enabled = enabledValue;
            txtTelNo.Enabled = enabledValue;

            // 郵便番号 
            lblYubinNo.Enabled = enabledValue;
            txtYubinNo.Enabled = enabledValue;

            // 住所１ 
            lblAddress1.Enabled = enabledValue;
            txtAddress1.Enabled = enabledValue;

            // 住所２ 
            lblAddress2.Enabled = enabledValue;
            txtAddress2.Enabled = enabledValue;

            // 勘定科目 
            lblKamoku.Enabled = enabledValue;
            txtKamoku.Enabled = enabledValue;

            // ライセンシー 
            grbLisence.Enabled = enabledValue;

            // テリトリー 
            grbTerritory.Enabled = enabledValue;

            // 初期G.OPEN年月日
            SGOpen.Enabled = enabledValue;

            // G.OPEN年月日
            GOpen.Enabled = enabledValue;

            // G.CLOSE年月日
            GClose.Enabled = enabledValue;

            // 店舗区分 
            grbTenpo.Enabled = enabledValue;

            // 明細行フラグ 
            grbSplit.Enabled = enabledValue;

            // 単一新規ボタン 
            btnNew.Enabled = enabledValue;
        }

        #endregion

        #region 入力チェック（更新ボタンクリック時）

        /// <summary>
        /// 入力チェック
        /// </summary>
        /// <returns>
        /// true    : 入力チェックOK
        /// false   : 入力チェックNG
        /// </returns>
        private bool InputCheck()
        {
            // 店舗コード変換モードでない場合
            if (IsChangeCodeMode == false)
            {
                // 店舗コード、店舗名の必須チェック
                if ((string.IsNullOrEmpty(txtTenpoCd.Text)) || (string.IsNullOrEmpty(txtTenpoNm.Text)))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0009, null, C_APL_NM, MessageBoxButtons.OK);
                    return false;
                }
            }

            // 店舗コードが６桁未満の場合
            if (txtTenpoCd.TextLength < 6)
            {
                // エラーメッセージを表示
                MessageUtility.ShowMessageBox(MessageCode.HB_W0010, null, C_APL_NM, MessageBoxButtons.OK);
                return false;
            }

            // G.CLOSE年月日が未入力の場合
            if (GClose.Value　== null)
            {
                // エラーメッセージを表示
                MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] { "G.CLOSE年月日" }, C_APL_NM, MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        #endregion

        #region 対象シート検索

        /// <summary>
        /// 対象シート検索 
        /// </summary>
        /// <param name="inputDefi"></param>
        /// <param name="shs"></param>
        /// <returns></returns>
        private int getSheetIndex(KKHMacInputDataDefi inputDefi, Excel.Sheets shs)
        {
            int i = 0;
            foreach (Excel.Worksheet sh in shs)
            {
                // シートのセル(1,1)に"店舗No"の記載があるか否か 
                if (((Excel.Range)sh.Cells[1, 1]).Text.ToString().Equals(inputDefi.strTenpoCd))
                {
                    // sheetオブジェクト解放 
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(shs);
                    // 記載がある場合、当該シートのindexを返却する。 
                    return i + 1;

                }
                i += 1;
            }
            // sheetオブジェクト解放 
            System.Runtime.InteropServices.Marshal.ReleaseComObject(shs);
            // 対象シートが見つからない場合、0を返却 
            return 0;
        }

        #endregion

        #region スプレッドの設定

        /// <summary>
        /// スプレッドの設定 
        /// </summary>
        private void SpreadSetting(FarPoint.Win.Spread.FpSpread trgSpread, string trgMasterKey)
        {
            //カラススタートインデックス 
            int ColIndex = 11;
            //行カウント 
            int RowCount = trgSpread.Sheets[0].Rows.Count;
            //スプレッド初期化 
            for (int j = 0; j < SpColNum; j++)
            {
                trgSpread.Sheets[0].Columns[j].Visible = false;
                trgSpread.Sheets[0].Columns[j].Label = null;
                trgSpread.Sheets[0].Columns[j].BackColor = Color.White;
            }

            MasterMaintenance.MasterItemVORow[] resultrow = (MasterMaintenance.MasterItemVORow[])mstDtSet.MasterDataSet.MasterItemVO.Select("field1 = '" + trgMasterKey + "'");
            foreach (MasterMaintenance.MasterItemVORow row in resultrow)
            {
                //列名 
                trgSpread.Sheets[0].Columns[ColIndex].Label = row.field3;
                //表示 
                trgSpread.Sheets[0].Columns[ColIndex].Visible = true;
                //列幅 
                trgSpread.Sheets[0].Columns[ColIndex].Width = float.Parse(row.field9);

                //******************
                //セル内の文字位置 
                //******************
                //垂直方向 
                trgSpread.Sheets[0].Columns[ColIndex].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                //水平方向 
                switch (row.field11)
                {
                    case "0"://右寄せ 
                        trgSpread.Sheets[0].Columns[ColIndex].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                        break;
                    case "1"://左寄せ 
                        trgSpread.Sheets[0].Columns[ColIndex].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                        break;
                    case "2"://中央寄せ 
                        trgSpread.Sheets[0].Columns[ColIndex].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        break;
                }

                //*************
                //セルType 
                //*************
                switch (row.field5)
                {
                    //**********************
                    //     テキストタイプ 
                    //**********************
                    case "0":
                        FarPoint.Win.Spread.CellType.TextCellType txtyp = new FarPoint.Win.Spread.CellType.TextCellType();
                        trgSpread.Sheets[0].Columns[ColIndex].CellType = txtyp;
                        //最大文字数 
                        if (!string.IsNullOrEmpty(row.field6))
                        {
                            txtyp.MaxLength = Isid.KKH.Common.KKHUtility.KKHUtility.IntParse(row.field6);
                        }
                        //txtyp.MaxLength = int.Parse(row.field6);

                        //半角 
                        if (!string.IsNullOrEmpty(row.field15))
                        {
                            switch (row.field15)
                            {
                                case "1"://英数字のみ 
                                    txtyp.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Ascii;
                                    break;
                                case "2"://数字のみ 
                                    txtyp.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
                                    break;
                            }
                        }
                        break;

                    //**********************
                    //     数値タイプ 
                    //********************** 
                    case "1":
                        FarPoint.Win.Spread.CellType.NumberCellType numtyp = new FarPoint.Win.Spread.CellType.NumberCellType();
                        trgSpread.Sheets[0].Columns[ColIndex].CellType = numtyp;

                        numtyp.DecimalPlaces = 0;

                        //最大値、最小値の設定 
                        if (!string.IsNullOrEmpty(row.field13))
                        {
                            numtyp.MaximumValue = long.Parse(row.field13);
                        }
                        if (!string.IsNullOrEmpty(row.field14))
                        {
                            numtyp.MinimumValue = long.Parse(row.field14);
                        }
                        break;

                    //**********************
                    //     コンボタイプ 
                    //********************** 
                    case "2":
                        FarPoint.Win.Spread.CellType.ComboBoxCellType cmbtyp = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                        cmbtyp.Items = row.field20.Split(',');
                        cmbtyp.ItemData = row.field19.Split(',');
                        string[] nykfk = row.field18.Split(',');
                        bool flg = false;

                        for (int i = 0; i < RowCount; i++)
                        {
                            flg = false;
                            for (int k = 0; k < cmbtyp.Items.Length; k++)
                            {
                                //名称の場合 
                                if (trgSpread.Sheets[0].Cells[i, ColIndex].Value.ToString() == cmbtyp.Items[k])
                                {
                                    //コードに変換する 
                                    trgSpread.Sheets[0].Cells[i, ColIndex].Value = cmbtyp.ItemData[k];
                                }
                            }
                            for (int k = 0; k < cmbtyp.ItemData.Length; k++)
                            {
                                if (trgSpread.Sheets[0].Cells[i, ColIndex].Value.Equals(cmbtyp.ItemData[k]))
                                {
                                    trgSpread.Sheets[0].Cells[i, ColIndex].Text = cmbtyp.Items[k];
                                    //trgSpread.Sheets[0].Cells[i, ColIndex].Value = cmbtyp.Items[k];
                                    flg = true;
                                }
                            }

                            if (!flg) { trgSpread.Sheets[0].Cells[i, ColIndex].Value = '0'; }
                        }

                        //入力不可対象をロックする 
                        if (row.field12.Equals("1"))
                        {
                            trgSpread.Sheets[0].Columns[ColIndex].BackColor = Color.Black;
                            trgSpread.Sheets[0].Columns[ColIndex].Locked = true;

                            //入力不可対象外を使用可能にする 
                            for (int n = 0; n < nykfk.Length; n++)
                            {
                                for (int j = 0; j < RowCount; j++)
                                {
                                    if (trgSpread.Sheets[0].Cells[j, (int)Math.Truncate(double.Parse(row.intValue1))].Value.Equals(nykfk[n]))
                                    {
                                        trgSpread.Sheets[0].Cells[j, ColIndex].BackColor = Color.White;
                                        trgSpread.Sheets[0].Cells[j, ColIndex].Locked = false;
                                    }
                                }
                            }

                        }

                        //店舗マスター情報のところはコンボボックスにタイプにしない 
                        if (!trgSpread.Name.Trim().Equals("spdTenpoMas"))
                        {
                            //typeの変換 
                            trgSpread.Sheets[0].Columns[ColIndex].CellType = cmbtyp;
                        }
                        break;

                    //**************************
                    //  チェックボックスタイプ 
                    //**************************
                    case "3":
                        FarPoint.Win.Spread.CellType.CheckBoxCellType chktyp = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                        trgSpread.Sheets[0].Columns[ColIndex].CellType = chktyp;


                        for (int j = 0; j < RowCount; j++)
                        {
                            if (trgSpread.Sheets[0].Cells[j, ColIndex].Value.Equals("true"))
                            {
                                trgSpread.Sheets[0].Cells[j, ColIndex].Value = true;
                            }
                            else if (trgSpread.Sheets[0].Cells[j, ColIndex].Value.Equals("false"))
                            {
                                trgSpread.Sheets[0].Cells[j, ColIndex].Value = false;
                            }
                        }
                        break;

                    //**************************
                    //       日付タイプ  
                    //**************************
                    case "4":
                        FarPoint.Win.Spread.CellType.DateTimeCellType datetyp = new FarPoint.Win.Spread.CellType.DateTimeCellType();

                        for (int j = 0; j < RowCount; j++)
                        {
                            //文字列からDateTime型へ変換(YYYY/MM/DD形式)  
                            trgSpread.Sheets[0].Cells[j, int.Parse(row.field2)].Value
                                = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(trgSpread.Sheets[0].Cells[j, int.Parse(row.field2)].Text);
                            //trgSpread.Sheets[0].Cells[j, int.Parse(row.field2)].Value = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(spdMasMainte.Sheets[0].Cells[j, int.Parse(row.field2)].Text);
                            trgSpread.Sheets[0].Columns[ColIndex].CellType = datetyp;
                        }
                        break;
                }

                //表示非表示の切り替え 
                double enableFlg = Math.Truncate(double.Parse(row.intValue2));
                switch (enableFlg.ToString())
                {
                    case "0":
                        trgSpread.Sheets[0].Columns[ColIndex].Visible = false;
                        break;
                    case "1":
                        trgSpread.Sheets[0].Columns[ColIndex].Visible = true;
                        break;
                    default:
                        trgSpread.Sheets[0].Columns[ColIndex].Visible = false;
                        break;
                }
                if (KKHMacConst.C_MAST_TENPO_CD.Equals(trgMasterKey))
                {
                    trgSpread.Sheets[0].Columns[ColIndex].Locked = true;
                }
                if (KKHMacConst.C_MAST_TENPO_PTN_CD.Equals(trgMasterKey))
                {
                    trgSpread.Sheets[0].Columns[ColIndex].Locked = true;
                }
                if (KKHMacConst.C_MAST_TENPO_PTN_DT_CD.Equals(trgMasterKey))
                {
                    if (row.field3.Equals("数量"))
                    {
                        trgSpread.Sheets[0].Columns[ColIndex].Locked = false;
                    }
                    else
                    {
                        trgSpread.Sheets[0].Columns[ColIndex].Locked = true;
                    }
                }
                ColIndex++;
            }

            if (KKHMacConst.C_MAST_TENPO_CD.Equals(trgMasterKey))
            {
                trgSpread.Sheets[0].Columns.Add(0, 1);
                trgSpread.Sheets[0].Columns[0].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                trgSpread.Sheets[0].Columns[0].Label = " ";
                trgSpread.Sheets[0].Columns[0].Width = 20;
                trgSpread.Sheets[0].Columns[0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                for (int x = 0; x < trgSpread.Sheets[0].Rows.Count; x++)
                {
                    trgSpread.Sheets[0].Cells[x, 0].Value = false;
                }
            }

            // 店舗パターン情報マスターの場合
            if (KKHMacConst.C_MAST_TENPO_PTN_DT_CD.Equals(trgMasterKey))
            {
                // 最終列がColumn30の場合
                if (trgSpread.Sheets[0].Columns[40].Label == "Column30")
                {
                    // チェックボックスとして表示する為、列の先頭に移動
                    trgSpread.Sheets[0].MoveColumn(40, 0, false);

                    // セルタイプをチェックボックスに変更
                    trgSpread.Sheets[0].Columns[0].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();

                    // ヘッダーラベルを変更（Column30 → " "）
                    trgSpread.Sheets[0].Columns[0].Label = " ";

                    // セルの幅設定
                    trgSpread.Sheets[0].Columns[0].Width = 20;

                    // 表示位置設定
                    trgSpread.Sheets[0].Columns[0].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

                    // セルを表示
                    trgSpread.Sheets[0].Columns[0].Visible = true;

                    // 店舗パターン情報マスターのフィルター列設定
                    trgSpread.Sheets[0].Columns[C_FILTER_COLINDEX].AllowAutoFilter = true;
                }
            }
        }

        #endregion

        #region パターンコード取得処理

        /// <summary>
        /// パターンコード取得処理
        /// ：店舗パターンで空いているパターンコードを取得する
        /// </summary>
        /// <param name="patternData">店舗パターン情報</param>
        /// <returns></returns>
        private int GetPatternCode(MasterMaintenance.MasterDataVODataTable patternData)
        {
            int rowCounter = 1;         // 行カウンター
            int returnValue = 0;        // 戻り値

            foreach (MasterMaintenance.MasterDataVORow patternDataRow in patternData.Rows)
            {
                // 行カウンターよりパターンコードの方が大きい場合
                if (rowCounter < int.Parse(patternDataRow.Column1))
                {
                    // 戻り値に行カウンターの値を設定
                    returnValue = rowCounter;
                    break;
                }
                rowCounter++;
            }

            return returnValue;
        }

        #endregion

        #region 店舗パターンマスター初期表示

        /// <summary>
        /// 店舗パターンマスター初期表示
        /// </summary>
        private void InitTenpoPatternMaster()
        {
            // DBアクセス用Controllerのインスタンス取得
            MasterMaintenanceProcessController masterMaintenanceProcessController = MasterMaintenanceProcessController.GetInstance();

            #region 店舗パターン情報一覧の初期化

            // 先頭列がチェックボックス（Column30）の場合
            if (spdTenpoPtn_Sheet1.Columns[0].Label == " ")
            {
                // フィルターリセット
                spdTenpoPtn_Sheet1.AutoFilterReset(C_FILTER_COLINDEX);

                // オートフィルター解除
                spdTenpoPtn_Sheet1.Columns[C_FILTER_COLINDEX].AllowAutoFilter = false;

                // ヘッダー名変更（" " → Column30）
                spdTenpoPtn_Sheet1.Columns[0].Label = "Column30";

                // 最終列へ移動
                spdTenpoPtn_Sheet1.MoveColumn(0, 40, false);
            }

            #endregion

            #region 店舗マスター取得・一覧表示

            // 店舗マスター取得
            FindMasterMaintenanceByCondServiceResult result = masterMaintenanceProcessController.FindMasterByCond(mstNavPrm.strEsqId,
                                                                                                                  mstNavPrm.strEgcd,
                                                                                                                  mstNavPrm.strTksKgyCd,
                                                                                                                  mstNavPrm.strTksBmnSeqNo,
                                                                                                                  mstNavPrm.strTksTntSeqNo,
                                                                                                                  KKHMacConst.C_MAST_TENPO_CD,
                                                                                                                  null);
            // 一覧に店舗マスターを設定
            spdTenpoMas.DataSource = result.MasterDataSet.MasterDataVO;

            // メンバ変数に格納
            TenpoMasterVODataTable.Clear();
            foreach (MasterMaintenance.MasterDataVORow addRow in result.MasterDataSet.MasterDataVO.Rows)
            {
                TenpoMasterVODataTable.ImportRow(addRow);
            }

            // 一覧の表示設定
            SpreadSetting(spdTenpoMas, KKHMacConst.C_MAST_TENPO_CD);

            #endregion

            #region 店舗パターン情報マスター取得・一覧表示

            // 店舗パターン情報マスター取得
            result = masterMaintenanceProcessController.FindMasterByCond(mstNavPrm.strEsqId,
                                                                         mstNavPrm.strEgcd,
                                                                         mstNavPrm.strTksKgyCd,
                                                                         mstNavPrm.strTksBmnSeqNo,
                                                                         mstNavPrm.strTksTntSeqNo,
                                                                         KKHMacConst.C_MAST_TENPO_PTN_DT_CD,
                                                                         null);

            // 店舗パターン情報一覧設定用DataTableのインスタンス生成
            MasterMaintenance.MasterDataVODataTable TenpoPatternInfoVODataTable = new MasterMaintenance.MasterDataVODataTable();

            // 店舗マスターから店舗名称を取得、一覧設定用DataTableへ格納する
            foreach (MasterMaintenance.MasterDataVORow row in result.MasterDataSet.MasterDataVO.Rows)
            {
                // 店舗パターン情報マスターの店舗コードに該当するレコードを店舗マスターから取得
                MasterMaintenance.MasterDataVORow[] TenpoMasterVORows = (MasterMaintenance.MasterDataVORow[])(TenpoMasterVODataTable.Select("Column1 = '" + row.Column2 + "'"));

                // 店舗名称、行チェック値設定
                string tenpoName = string.Empty;
                bool checkRow = false;
                if (TenpoMasterVORows.Length > 0)
                {
                    tenpoName = TenpoMasterVORows[0].Column2;
                    checkRow = true;
                }

                // 一覧設定用DataTableへ格納する
                // ※ ここでColumn30に行チェック値を設定するが、表示用として利用するだけ。DB更新時にはNullで更新する。
                TenpoPatternInfoVODataTable.AddMasterDataVORow(row.trkTimStmp,
                                                               row.trkPl,
                                                               row.trkTnt,
                                                               row.updTimStmp,
                                                               row.updaPl,
                                                               row.updTnt,
                                                               row.egCd,
                                                               row.tksKgyCd,
                                                               row.tksBmnSeqNo,
                                                               row.tksTntSeqNo,
                                                               row.sybt,
                                                               row.Column1,
                                                               row.Column2,
                                                               row.Column3,
                                                               tenpoName,
                                                               row.Column5,
                                                               row.Column6,
                                                               row.Column7,
                                                               row.Column8,
                                                               row.Column9,
                                                               row.Column10,
                                                               row.Column11,
                                                               row.Column12,
                                                               row.Column13,
                                                               row.Column14,
                                                               row.Column15,
                                                               row.Column16,
                                                               row.Column17,
                                                               row.Column18,
                                                               row.Column19,
                                                               row.Column20,
                                                               row.Column21,
                                                               row.Column22,
                                                               row.Column23,
                                                               row.Column24,
                                                               row.Column25,
                                                               row.Column26,
                                                               row.Column27,
                                                               row.Column28,
                                                               row.Column29,
                                                               checkRow.ToString());
            }

            // 一覧に店舗パターン情報マスターを設定
            spdTenpoPtn.DataSource = TenpoPatternInfoVODataTable;

            // 一覧の表示設定
            SpreadSetting(spdTenpoPtn, KKHMacConst.C_MAST_TENPO_PTN_DT_CD);

            #endregion

            #region 店舗パターンマスター取得・一覧表示

            // 店舗パターンマスター取得
            result = masterMaintenanceProcessController.FindMasterByCond(mstNavPrm.strEsqId,
                                                                         mstNavPrm.strEgcd,
                                                                         mstNavPrm.strTksKgyCd,
                                                                         mstNavPrm.strTksBmnSeqNo,
                                                                         mstNavPrm.strTksTntSeqNo,
                                                                         KKHMacConst.C_MAST_TENPO_PTN_CD,
                                                                         null);
            // 一覧に店舗パターンマスターを設定
            spdPtn.DataSource = result.MasterDataSet.MasterDataVO;

            // 一覧の表示設定
            SpreadSetting(spdPtn, KKHMacConst.C_MAST_TENPO_PTN_CD);

            // タイムスタンプ取得
            base.updateMaxfind(result);

            #endregion

            // 店舗パターン一覧に行あれば、先頭行のパターン名をアクティブにする
            if (spdPtn_Sheet1.Rows.Count > 0)
            {
                spdPtn_Sheet1.SetActiveCell(0, 12);
            }

            // 店舗パターン情報一覧に行がない場合、処理終了
            if (spdTenpoPtn_Sheet1.Rows.Count == 0)
            {
                return;
            }

            // フィルター値設定
            if (spdTenpoPtn_Sheet1.Columns[C_FILTER_COLINDEX].AllowAutoFilter == true)
            {
                this.ChangeFilterValue();
            }
        }

        #endregion

        #region フィルター値設定

        /// <summary>
        /// 店舗パターン情報マスターにフィルター値を設定する
        /// </summary>
        private void ChangeFilterValue()
        {
            // 店舗パターンマスターのアクティブ行を取得
            MasterMaintenance.MasterDataVODataTable tenpoPatternVODataTable = (MasterMaintenance.MasterDataVODataTable)spdPtn.DataSource;
            MasterMaintenance.MasterDataVORow tenpoPatternActiveRow = (MasterMaintenance.MasterDataVORow)tenpoPatternVODataTable.Rows[spdPtn_Sheet1.ActiveRowIndex];

            if (this.IsFilterItem(tenpoPatternActiveRow.Column1) == false)
            {
                for (int rowIndex = 0; rowIndex < spdTenpoPtn_Sheet1.Rows.Count; rowIndex++)
                {
                    spdTenpoPtn_Sheet1.SetRowHeight(rowIndex, 0);
                }
            }
            else
            {
                for (int rowIndex = 0; rowIndex < spdTenpoPtn_Sheet1.Rows.Count; rowIndex++)
                {
                    spdTenpoPtn_Sheet1.SetRowHeight(rowIndex, 20);
                }

            }

            try
            {
                // 店舗パターン情報マスターのフィルターに店舗パターンマスターのパターンコードを設定
                spdTenpoPtn_Sheet1.AutoFilterColumn(C_FILTER_COLINDEX, tenpoPatternActiveRow.Column1, 0);

            }
            catch //(NullReferenceException ex)
            {
                return;
            }
        }

        #endregion

        #region マスターデータ更新

        /// <summary>
        /// マスターデータ更新 
        /// </summary>
        private void UpdateMasterTables()
        {
            //ローディング表示開始 
            base.ShowLoadingDialog();

            // 更新対象の店舗パターンマスターを一覧から取得
            MasterMaintenance.MasterDataVODataTable patternMasterTable = (MasterMaintenance.MasterDataVODataTable)spdPtn_Sheet1.DataSource;

            // 一覧から店舗パターン情報マスター取得
            MasterMaintenance.MasterDataVODataTable spreadPatternInfoTable = (MasterMaintenance.MasterDataVODataTable)spdTenpoPtn_Sheet1.DataSource;

            // 更新対象の店舗パターン情報マスターを格納するDataTableのインスタンス生成
            MasterMaintenance.MasterDataVODataTable patternInfoTable = new MasterMaintenance.MasterDataVODataTable();

            // 一覧の行数分繰り返す
            foreach (MasterMaintenance.MasterDataVORow dataRow in spreadPatternInfoTable.Rows)
            {
                // 一覧でチェックされている場合
                if (dataRow.Column30 == "True")
                {
                    // 更新対象としてDataTableに追加
                    MasterMaintenance.MasterDataVORow addRow = patternInfoTable.NewMasterDataVORow();

                    addRow.trkTimStmp = dataRow.trkTimStmp;
                    addRow.trkPl = dataRow.trkPl;
                    addRow.trkTnt = dataRow.trkTnt;
                    addRow.updTimStmp = dataRow.updTimStmp;
                    addRow.updaPl = dataRow.updaPl;
                    addRow.updTnt = dataRow.updTnt;
                    addRow.egCd = dataRow.egCd;
                    addRow.tksKgyCd = dataRow.tksKgyCd;
                    addRow.tksBmnSeqNo = dataRow.tksBmnSeqNo;
                    addRow.tksTntSeqNo = dataRow.tksTntSeqNo;
                    addRow.sybt = dataRow.sybt;
                    addRow.Column1 = dataRow.Column1;
                    addRow.Column2 = dataRow.Column2;
                    addRow.Column3 = dataRow.Column3;
                    addRow.Column4 = string.Empty;
                    addRow.Column5 = dataRow.Column5;
                    addRow.Column6 = null;
                    addRow.Column7 = null;
                    addRow.Column8 = null;
                    addRow.Column9 = null;
                    addRow.Column10 = null;
                    addRow.Column11 = null;
                    addRow.Column12 = null;
                    addRow.Column13 = null;
                    addRow.Column14 = null;
                    addRow.Column15 = null;
                    addRow.Column16 = null;
                    addRow.Column17 = null;
                    addRow.Column18 = null;
                    addRow.Column19 = null;
                    addRow.Column20 = null;
                    addRow.Column21 = null;
                    addRow.Column22 = null;
                    addRow.Column23 = null;
                    addRow.Column24 = null;
                    addRow.Column25 = null;
                    addRow.Column26 = null;
                    addRow.Column27 = null;
                    addRow.Column28 = null;
                    addRow.Column29 = null;
                    addRow.Column30 = null;

                    patternInfoTable.AddMasterDataVORow(addRow);
                }
            }

            // 必須チェック
            if (this.CheckDataPattern(patternMasterTable) == false)
            {
                //ローディング表示終了   
                base.CloseLoadingDialog();
                MessageUtility.ShowMessageBox(MessageCode.HB_W0081, null, "エラー", MessageBoxButtons.OK);
                return;
            }
            if (this.CheckDataPatternInfo(patternInfoTable) == false)
            {
                //ローディング表示終了   
                base.CloseLoadingDialog();
                MessageUtility.ShowMessageBox(MessageCode.HB_W0081, null, "エラー", MessageBoxButtons.OK);
                return;
            }


            // DBアクセス用Controllerのインスタンス取得
            MasterMaintenanceProcessController processController = MasterMaintenanceProcessController.GetInstance();

            // 更新処理
            RegisterMasterServiceResult result = processController.RegisterMasterTablesResult(mstNavPrm.strEsqId,
                                                                                                          mstNavPrm.AplId,
                                                                                                          mstNavPrm.strEgcd,
                                                                                                          mstNavPrm.strTksKgyCd,
                                                                                                          mstNavPrm.strTksBmnSeqNo,
                                                                                                          mstNavPrm.strTksTntSeqNo,
                                                                                                          mstNavPrm.strMasterKey,
                                                                                                          KKHMacConst.C_MAST_TENPO_PTN_DT_CD,
                                                                                                          mstNavPrm.strFilterValue,
                                                                                                          patternMasterTable,
                                                                                                          patternInfoTable,
                                                                                                          maxupdate);

            // 更新処理でエラーが発生した場合
            if (result.HasError)
            {
                //ローディング表示終了   
                base.CloseLoadingDialog();

                String[] message = result.Note;
                MessageUtility.ShowMessageBox(MessageCode.HB_W0095, message, "更新", MessageBoxButtons.OK);

                return;
            }

            // 店舗マスター初期処理（再読み込み）
            this.InitTenpoPatternMaster();

            //ローディング表示終了   
            base.CloseLoadingDialog();

            // 完了メッセージ表示
            MessageUtility.ShowMessageBox(MessageCode.HB_I0001, null, "完了", MessageBoxButtons.OK);
        }

        #endregion

        #region フィルター項目チェック

        /// <summary>
        /// フィルター項目チェック
        /// ：パラメータが一覧のフィルター項目か確認する
        /// </summary>
        /// <param name="filterString">対象文字列</param>
        /// <returns>
        /// true    : フィルター項目
        /// false   : フィルター項目でない
        /// </returns>
        private bool IsFilterItem(string filterString)
        {
            ArrayList filter = spdTenpoPtn_Sheet1.GetDropDownFilterItems(C_FILTER_COLINDEX);

            if (filter == null)
            {
                return false;
            }

            foreach (string filterItem in spdTenpoPtn_Sheet1.GetDropDownFilterItems(C_FILTER_COLINDEX))
            {
                if (filterItem == filterString)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region 必須チェック

        /// <summary>
        /// 必須チェック(店舗パターンマスター)
        /// </summary>
        /// <param name="dataTable">店舗パターンマスター</param>
        /// <returns>
        /// true    : チェックOK
        /// false   : チェックNG
        /// </returns>
        private bool CheckDataPattern(MasterMaintenance.MasterDataVODataTable dataTable)
        {
            // 行数分繰り返す
            foreach (MasterMaintenance.MasterDataVORow dataRow in dataTable.Rows)
            {
                // Column1(パターンコード)
                if (string.IsNullOrEmpty(dataRow.Column1) == true)
                {
                    return false;
                }
                // Column2(パターン名)
                if (string.IsNullOrEmpty(dataRow.Column2) == true)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 必須チェック(店舗パターン情報マスター)
        /// </summary>
        /// <param name="dataTable">店舗パターン情報マスター</param>
        /// <returns>
        /// true    : チェックOK
        /// false   : チェックNG
        /// </returns>
        private bool CheckDataPatternInfo(MasterMaintenance.MasterDataVODataTable dataTable)
        {
            // 行数分繰り返す
            foreach (MasterMaintenance.MasterDataVORow dataRow in dataTable.Rows)
            {
                // Column1(店舗パターンコード)
                if (string.IsNullOrEmpty(dataRow.Column1) == true)
                {
                    return false;
                }
                // Column2(店舗コード)
                if (string.IsNullOrEmpty(dataRow.Column2) == true)
                {
                    return false;
                }
                // Column3(パターンコード)
                if (string.IsNullOrEmpty(dataRow.Column3) == true)
                {
                    return false;
                }
                // Column5(数量)
                if (string.IsNullOrEmpty(dataRow.Column5) == true)
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// 必須項目入力チェック 
        /// </summary>
        /// <returns></returns>
        protected override bool NrChk(ref string col)
        {           
            // タブが2つ表示されていない場合、処理終了
            if (tbcMasterMainte.TabPages.Count != 2)
            {
                MasterMaintenance.MasterItemVORow[] itemrow = (MasterMaintenance.MasterItemVORow[])mstDtSet.MasterDataSet.MasterItemVO.Select("field1 = '" + mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3 + "'");
                foreach (MasterMaintenance.MasterItemVORow row in itemrow)
                {
                    if (row.field8.Equals("1"))
                    {
                        for (int i = 0; i < spdMasMainte_Sheet1.Rows.Count; i++)
                        {
                            if (string.IsNullOrEmpty(spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2)].Text))
                            {
                                col = row.field3.Trim();
                                return false;
                            }


                        }
                    }
                }
            }
            else
            {
                // 店舗マスター(単一検索) 
                if (tbcMasterMainte.SelectedIndex == 0)
                {
                }
                // 店舗マスター(一覧表示)
                else
                {
                    MasterMaintenance.MasterItemVORow[] itemrow = (MasterMaintenance.MasterItemVORow[])mstDtSet.MasterDataSet.MasterItemVO.Select("field1 = '" + mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3 + "'");
                    foreach (MasterMaintenance.MasterItemVORow row in itemrow)
                    {
                        if (row.field8.Equals("1"))
                        {
                            if (int.Parse(row.field2) < 26)
                            {
                                //初期G.OPEN年月日までの列はfield2の列を参照
                                for (int i = 0; i < spdMasMainte_Sheet1.Rows.Count; i++)
                                {
                                    if (string.IsNullOrEmpty(spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2)].Text))
                                    {
                                        col = row.field3.Trim();
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                //初期G.OPEN年月日以降の列はfield2+1の列を参照
                                for (int i = 0; i < spdMasMainte_Sheet1.Rows.Count; i++)
                                {
                                    if (string.IsNullOrEmpty(spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2) - 1].Text))
                                    {
                                        col = row.field3.Trim();
                                        return false;
                                    }
                                }
                            }

                        }
                    }
                }
            }

            //upchk = false;
            return true;

        }
        #endregion

        /// <summary>
        /// 店舗マスター(単一検索)タブを選択した場合の処理 
        /// </summary>
        public void SelectedTempMstSnglSrchTab()
        {
            // ボタン設定
            this.SetButtonPropertyTenpoMaster_FirstTab();

            // 入力項目初期化
            this.InitInputItemTenpoMaster_FirstTab(true);

            // マスター名コンボボックスを非表示
            cmbMasterName1.Visible = false;

            // マスター名ラベルを非表示
            label2.Visible = false;

            // 変数初期化
            beforeTenpoCd = string.Empty;
            beforeDeleteButtonEnabled = false;
            IsChangeCodeMode = false;
        }

        /// <summary>
        /// 店舗マスター(一覧)タブを選択した場合の処理 
        /// </summary>
        public void SelectedTempMstListTab()
        {
            // ボタン設定
            this.SetButtonPropertyTenpoMaster_SecondTab();

            // マスター名コンボボックスを表示
            cmbMasterName1.Visible = true;

            // マスター名ラベルを表示
            label2.Visible = true;

            // 店舗パターンマスター用グループボックスを非表示
            grbTenpoPtn.Visible = false;

            // api絞込Filterにnullを設定
            mstNavPrm.strFilterValue = null;
        }

        #endregion
    }
}

