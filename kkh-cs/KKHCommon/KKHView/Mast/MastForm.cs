using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Log;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Mast;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility.Constants;
using System.Collections;
using FarPoint.Win;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using Isid.KKH.Common.KKHUtility.Security;
using drMasterItem = Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterItemVORow;
using dtMasterItem = Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterItemVODataTable;
using drMasterKind = Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterKindVORow;
using dtMasterKind = Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterKindVODataTable;
using drMasterData = Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow;
using dtMasterData = Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable;

namespace Isid.KKH.Common.KKHView.Mast
{
    /// <summary>
    /// マスタメンテナンス画面.
    /// </summary>
    public partial class MastForm : KKHForm
    {
        #region 定数.
        /// <summary>
        /// スプレッドカラム数.
        /// </summary>
        public const int SpColNum = 41;
        /// <summary>
        /// コンボボックス追加項目(マスター定義).
        /// </summary>
        public const string MST_KIND = "マスター定義";
        /// <summary>
        /// マスタ定義種別.
        /// </summary>
        public const string MST_KIND_SYBT = "003";
        /// <summary>
        /// コンボボックス追加項目(マスタアイテム).
        /// </summary>
        public const string MST_ITEM = "マスター項目";
        /// <summary>
        /// 種別(マスター項目：004)
        /// </summary>
        public const string MST_ITME_SYBT = "004";
        /// <summary>
        /// 必要のないカラム.
        /// </summary>
        public const int COLSTRTINDEX = 11;
        /// <summary>
        /// 文字エンコーディング.
        /// </summary>
        private Encoding _enc = Encoding.GetEncoding("shift-jis");
        #endregion 定数.

        #region メンバ変数.
        /// <summary>
        ///マスター情報のパラメータ.
        /// </summary>
        KKHNaviParameter mstNavPrm = new KKHNaviParameter();
        /// <summary>
        /// master項目設定情報保持.
        /// </summary>
        public FindMasterMaintenanceByCondServiceResult mstDtSet = new FindMasterMaintenanceByCondServiceResult();
        /// <summary>
        ///master項目設定情報(武田製薬).
        /// </summary>
        public FindMasterMaintenanceByCondServiceResult mstDtSet1 = new FindMasterMaintenanceByCondServiceResult();
        /// <summary>
        /// マスターキー.
        /// </summary>
        protected string masterkey = string.Empty;
        /// <summary>
        /// フィルタをかける値.
        /// </summary>
        protected string _filterValue = string.Empty;
        /// <summary>
        /// システム管理者かを判断するフラグ(True:システム管理者、False:システム管理者以外).
        /// </summary>
        protected bool SyskanriFlag = true;
        /// <summary>
        /// 更新日時の最大値(初期値: 1000/01/01 01:01:01).
        /// </summary>
        protected DateTime maxupdate = DateTime.Parse("1000/01/01 01:01:01");
        /// <summary>
        /// 編集した後更新したかを判断するフラグ(True:更新していない、False:更新した).
        /// </summary>
        protected bool upchk = false;
        /// <summary>
        /// ソートカラムの取得.
        /// </summary>
        protected String[] SortCol;
        /// <summary>
        /// ホームロードフラグ(true:マスターコンボイベントに通らない false :通る).
        /// </summary>
        private bool cmbMasterName1Flg = false;
        /// <summary>
        /// 前回のソート順のゲージ(0:None 1:Ascending 2:Descending).
        /// </summary>
        private int Sortindicator = 0;
        /// <summary>
        /// 前回の指定さえれたカラム.
        /// </summary>
        private int beforeColumn = 0;
        /// <summary>
        /// マスター名のインデックス.
        /// </summary>
        private int masterNameIndex = 0;
        /// <summary>
        /// フィルタリング項目フラグ.
        /// </summary>
        private bool cmbfilterItemflg = false;
        /// <summary>
        /// フィルタリング項目のインデックス.
        /// </summary>
        private int filterItemIndex = 0;
        /// <summary>
        /// コンボボックス.
        /// </summary>
        private FpCombo Combo;
        /// <summary>
        /// Enterキー.
        /// </summary>
        private bool bEnterKey;
        #endregion メンバ変数.

        #region コンストラクタ.
        /// <summary>
        /// マスターフォーム.
        /// </summary>
        public MastForm()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ.

        #region イベント.
        #region 戻るボタンクリック時.
        /// <summary>
        /// 戻るボタンクリック時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            //更新済かを判定.
            if (upchk)
            {
                //未更新の場合(更新していないので変更がキャンセルされます。よろしいですか).
                DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0032, null, KKHSystemConst.KoteiMongon.MASTERMAINTENANCE, MessageBoxButtons.OKCancel);
                
                //キャンセルボタンが選択された場合.
                if (check == DialogResult.Cancel)
                {
                    return;
                }
            }

            //メニュー画面に戻る.
            Navigator.Backward(this, mstNavPrm.strFrmTopMenuNM, mstNavPrm, true);
        }
        #endregion 戻るボタンクリック時.

        #region 画面遷移するたびに発生します.
        /// <summary>
        /// 画面遷移するたびに発生します.
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void MastForm_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {   
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                mstNavPrm = (KKHNaviParameter)arg.NaviParameter;
            }
            
            mstNavPrm.AplId = "00";
        }
        #endregion 画面遷移するたびに発生します.

        #region フォームロード時.
        /// <summary>
        /// フォームロード時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MastForm_Shown(object sender, EventArgs e)
        {
            //RowUp、Downは対象媒体のみ表示.
            RowUpBtn.Enabled = false;
            RowUpBtn.Visible = false;
            RowDownBtn.Enabled = false;
            RowDownBtn.Visible = false;

            //デザインモードの場合、何もしない.
            if (this.DesignMode)
            {
                return;
            }

            //コンボボックスのイベントハンドラを破棄.
            cmbMasterName1.SelectedIndexChanged -= new System.EventHandler(cmbMasterName1_SelectedIndexChanged);

            //ホームロード.
            homeLoad();

            if (!string.IsNullOrEmpty(mstNavPrm.StrValue1))
            {
                //マスター名コンボボックスにメニュー画面で押下されたマスターボタン名をセット.
                CombSetFromMenue();
            }

            //マスターコンボクリック.
            MastCmbClick();
            
            //コンボボックスのイベントハンドラを復元.
            cmbMasterName1.SelectedIndexChanged += new System.EventHandler(cmbMasterName1_SelectedIndexChanged);
            masterNameIndex = cmbMasterName1.SelectedIndex;
        }
        #endregion フォームロード時.

        #region マスター項目クリック時.
        /// <summary>
        /// マスター項目クリック時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMasterName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ホームロードフラグでマスターコンボイベントが発生しない場合.
            if (!cmbMasterName1Flg)
            {
                //マスターコンボクリック.
                MastCmbClick();
            }
            else
            {
                cmbMasterName1Flg = false;
            }

            masterNameIndex = cmbMasterName1.SelectedIndex;
        }
        #endregion マスター項目クリック時.

        #region フィルタ項目クリック時.
        /// <summary>
        /// フィルタ項目クリック時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdMasterName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //未更新の場合.
            if (upchk)
            {
                DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0032, null, KKHSystemConst.KoteiMongon.MASTERMAINTENANCE, MessageBoxButtons.OKCancel);
                
                //キャンセルボタンが選択された場合.
                if (check == DialogResult.Cancel)
                {
                    cmbMasterName1Flg = true;
                    cmbMasterName1.SelectedIndex = masterNameIndex;
                    return;
                }
            }

            //ローディング表示開始.
            base.ShowLoadingDialog();

            //フィルタリング項目の上2桁を取得する.
            if (!string.IsNullOrEmpty(cmdMasterName2.SelectedItem.ToString()))
            {
                _filterValue = cmdMasterName2.SelectedItem.ToString().Substring(0, 2);
                mstNavPrm.strFilterValue = _filterValue;
            }

            MasterMaintenanceProcessController masterMaintenanceProcessController = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult　result = masterMaintenanceProcessController.FindMasterByCond(mstNavPrm.strEsqId,
                                                                                                                    mstNavPrm.strEgcd,
                                                                                                                    mstNavPrm.strTksKgyCd,
                                                                                                                    mstNavPrm.strTksBmnSeqNo,
                                                                                                                    mstNavPrm.strTksTntSeqNo,
                                                                                                                    mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3,
                                                                                                                    mstNavPrm.strFilterValue);
            //エラーの場合.
            if (result.HasError)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();

                return;
            }

            spdMasMainte.SuspendLayout();
            spdMasMainte.DataSource = result.MasterDataSet.MasterDataVO;
            spdMasMainte.ResumeLayout();

            tslCnt.Text = spdMasMainte.Sheets[0].Rows.Count.ToString() + "件";
            
            //背景色の設定.
            BackColorSyokika();
            
            //スプレッドの設定.
            SpreadSetting();

            upchk = false;
            
            //ローディング表示終了.
            base.CloseLoadingDialog();
        }
        #endregion フィルタ項目クリック時.

        #region 新規ボタンクリック時.
        /// <summary>
        /// 新規ボタンクリック時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCrt_Click(object sender, EventArgs e)
        {
            //マスター定義が選択された場合.
            if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].sybt.Equals(MST_KIND_SYBT))
            {
                dtMasterKind mstKindVo = new dtMasterKind();
                mstKindVo = (dtMasterKind)spdMasMainte_Sheet1.DataSource;

                drMasterKind kindrow = mstKindVo.NewMasterKindVORow();
                kindrow.trkTimStmp = "1000/01/01 01:01:01";
                kindrow.updTimStmp = "1000/01/01 01:01:01";
                kindrow.egCd = mstNavPrm.strEgcd;
                kindrow.tksKgyCd = mstNavPrm.strTksKgyCd;
                kindrow.tksBmnSeqNo = mstNavPrm.strTksBmnSeqNo;
                kindrow.tksTntSeqNo = mstNavPrm.strTksTntSeqNo;
                kindrow.sybt = "001";

                mstKindVo.Rows.InsertAt(kindrow,spdMasMainte_Sheet1.ActiveRowIndex);
                spdMasMainte_Sheet1.DataSource = mstKindVo;               
            }
            //マスター項目ボタンの場合が選択された場合.
            else if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].sybt.Equals(MST_ITME_SYBT))
            {
                dtMasterItem mstItemVo = new dtMasterItem();
                mstItemVo = (dtMasterItem)spdMasMainte_Sheet1.DataSource;

                drMasterItem itemrow = mstItemVo.NewMasterItemVORow();
                itemrow.trkTimStmp = "1000/01/01 01:01:01";
                itemrow.updTimStmp = "1000/01/01 01:01:01";
                itemrow.egCd = mstNavPrm.strEgcd;
                itemrow.tksKgyCd = mstNavPrm.strTksKgyCd;
                itemrow.tksBmnSeqNo = mstNavPrm.strTksBmnSeqNo;
                itemrow.tksTntSeqNo = mstNavPrm.strTksTntSeqNo;
                itemrow.sybt = "002";

                mstItemVo.Rows.InsertAt(itemrow, spdMasMainte_Sheet1.ActiveRowIndex);
                spdMasMainte_Sheet1.DataSource = mstItemVo;
            }
            else
            {
                dtMasterData mstDataVo = new dtMasterData();
                mstDataVo = (dtMasterData)spdMasMainte_Sheet1.DataSource;

                //新しいデータRowの生成.
                drMasterData row = mstDataVo.NewMasterDataVORow();
                mstDataVo.Rows.InsertAt(rowSet(row), spdMasMainte_Sheet1.ActiveRowIndex);
                spdMasMainte_Sheet1.DataSource = mstDataVo;
            }

            spdMasMainte_Sheet1.ActiveRowIndex = spdMasMainte_Sheet1.ActiveRowIndex - 1;

            tslCnt.Text = spdMasMainte_Sheet1.Rows.Count.ToString() + "件";
            upchk = true;

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }
        #endregion 新規ボタンクリック時.

        #region 削除ボタンクリック.
        /// <summary>
        /// 削除ボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            //一覧の行数が0件の場合.
            if (spdMasMainte_Sheet1.RowCount == 0)
            {
                return; 
            }

            //削除確認メッセージを表示.
            if (MessageUtility.ShowMessageBox(MessageCode.HB_W0091, null, KKHSystemConst.KoteiMongon.MASTERMAINTENANCE, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                this.ActiveControl = null;
                return;
            }

            //マスター定義が選択されている場合.
            if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].sybt.Equals(MST_KIND_SYBT))
            {
                spdMasMainte_Sheet1.Rows.Remove(spdMasMainte_Sheet1.ActiveRowIndex, 1);
                ((dtMasterKind)spdMasMainte_Sheet1.DataSource).AcceptChanges();
            }
            //マスター項目ボタンが選択されている場合.
            else if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].sybt.Equals(MST_ITME_SYBT))
            {
                spdMasMainte_Sheet1.Rows.Remove(spdMasMainte_Sheet1.ActiveRowIndex, 1);
                ((dtMasterItem)spdMasMainte_Sheet1.DataSource).AcceptChanges();
            }
            else
            {
                spdMasMainte_Sheet1.Rows.Remove(spdMasMainte_Sheet1.ActiveRowIndex, 1);
                ((dtMasterData)spdMasMainte_Sheet1.DataSource).AcceptChanges();

                //スプレッドの設定.
                SpreadSetting();
            }

            tslCnt.Text = spdMasMainte_Sheet1.Rows.Count.ToString() + "件";
            upchk = true;

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }
        #endregion 削除ボタンクリック.

        #region 再表示ボタンクリック時.
        /// <summary>
        /// 再表示ボタンクリック時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRev_Click(object sender, EventArgs e)
        {
            //データ再表示.
            reDisplay();

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }
        #endregion 再表示ボタンクリック時.

        #region 更新ボタンクリック時.
        /// <summary>
        /// 更新ボタンクリック時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void btnUpd_Click(object sender, EventArgs e)
        {
            //登録上限数の確認.
            if (!string.IsNullOrEmpty(mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field11))
            {
                if (spdMasMainte_Sheet1.Rows.Count > int.Parse(mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field11.Trim()))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0149, new string[] { mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field11 }, KKHSystemConst.KoteiMongon.MASTERMAINTENANCE, MessageBoxButtons.OK);
                    return;
                }
            }

            //変更点が無い場合.
            if (!upchk) 
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0086, null, KKHSystemConst.KoteiMongon.MASTERMAINTENANCE, MessageBoxButtons.OK);
                return;
            }
            
            //更新の確認.
            DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_C0005, null, KKHSystemConst.KoteiMongon.MASTERMAINTENANCE, MessageBoxButtons.YesNo);
            if (check == DialogResult.No)
            {
                return;
            }

            //マスター定義、マスターアイテムが選択されている場合.
            if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].sybt.Equals(MST_KIND_SYBT) || mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].sybt.Equals(MST_ITME_SYBT))
            {
                //マスター定義、アイテムの更新.
                MstKindItemUpdate();
            }
            else
            {
                //マスターデータ更新.
                MstDataUpdate();
            }

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }
        #endregion 更新ボタンクリック時.

        #region セル内容変更時.
        /// <summary>
        /// セル内容変更時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdMasMainte_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            //エディットチェンジ.
            EditChange(e);
        }
        #endregion セル内容変更時.

        #region RowUpボタンクリック.
        /// <summary>
        /// RowUpボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RowUpBtn_Click(object sender, EventArgs e)
        {
            //マスタメンテナンス一覧が1件も存在しない場合.
            if (spdMasMainte_Sheet1.Rows.Count == 0)
            {
                return;
            }

            //選択されている行.
            int ActiverowIndex = spdMasMainte_Sheet1.ActiveRowIndex;
            
            //選択行が存在しない場合.
            if (ActiverowIndex == 0)
            {
                return;
            }

            spdMasMainte_Sheet1.SwapRange(ActiverowIndex, 0, ActiverowIndex - 1, 0, 1, SpColNum, false);
            spdMasMainte_Sheet1.ActiveRowIndex = ActiverowIndex - 1;

            //スクロールバーの制御.
            spdMasMainte.ShowActiveCell(VerticalPosition.Nearest, HorizontalPosition.Nearest);
        }
        #endregion RowUpボタンクリック.

        #region RowDownボタンクリック.
        /// <summary>
        /// RowDownボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RowDownBtn_Click(object sender, EventArgs e)
        {
            if (spdMasMainte_Sheet1.Rows.Count == 0)
            {
                return;
            }

            //選択行の取得.
            int ActiverowIndex = spdMasMainte_Sheet1.ActiveRowIndex;
            
            //選択行が存在しない場合.
            if (ActiverowIndex == spdMasMainte_Sheet1.Rows.Count -1)
            {
                return;
            }

            spdMasMainte_Sheet1.SwapRange(ActiverowIndex, 0, ActiverowIndex + 1, 0, 1, SpColNum, false);
            spdMasMainte_Sheet1.ActiveRowIndex = ActiverowIndex + 1;

            //スクロールバーの制御.
            spdMasMainte.ShowActiveCell(VerticalPosition.Nearest, HorizontalPosition.Nearest);
        }
        #endregion RowDownボタンクリック.

        #region Item用コンボボックスチェンジイベント.
        /// <summary>
        /// Item用コンボボックスチェンジイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Itemcmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //フィルタリング項目フラグがTrueの場合.
            if (cmbfilterItemflg)
            {
                cmbfilterItemflg = false;
                return;
            }

            //未更新の場合.
            if (upchk)
            {
                DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0032, null, KKHSystemConst.KoteiMongon.MASTERMAINTENANCE, MessageBoxButtons.OKCancel);

                //キャンセルボタンを選択した場合.
                if (check == DialogResult.Cancel)
                {
                    cmbfilterItemflg = true;
                    Itemcmb.SelectedIndex = filterItemIndex;
                    return;
                }
            }

            MasterMaintenanceProcessController.FindMastItemVOParam param = new MasterMaintenanceProcessController.FindMastItemVOParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = mstNavPrm.strEgcd;
            param.tksKgyCd = mstNavPrm.strTksKgyCd;
            param.tksBmnSeqNo = mstNavPrm.strTksBmnSeqNo;
            param.tksTntSeqNo = mstNavPrm.strTksTntSeqNo;
            param.Sybt = "002";
            param.filterValue = Itemcmb.SelectedItem.ToString().Substring(0,4);

            MasterMaintenanceProcessController processcontroller = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result = processcontroller.FindMastItemVO(param);

            //エラーの場合.
            if (result.HasError)
            {
                return;
            }
            spdMasMainte_Sheet1.DataAutoSizeColumns = true;
            spdMasMainte_Sheet1.DataSource = result.MasterDataSet.MasterItemVO;
            spdMasMainte_Sheet1.DataAutoSizeColumns = false;
            BackColorSyokika();
            itemSetSpred();
            tslCnt.Text = result.MasterDataSet.MasterItemVO.Rows.Count.ToString() + "件";
            upchk = false;

            filterItemIndex = Itemcmb.SelectedIndex;
        }
        #endregion Item用コンボボックスチェンジイベント.

        #region オートソートカラムクリック時.
        /// <summary>
        /// オートソートカラムクリック時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdMasMainte_AutoSortingColumn(object sender, AutoSortingColumnEventArgs e)
        {
            //初期設定.
            e.Cancel = true;
            SortInfo[] sortinfo = new SortInfo[1];
            sortinfo[0] = new SortInfo(e.Column, e.Ascending);
            spdMasMainte_Sheet1.SortRange(0, 0, spdMasMainte_Sheet1.Rows.Count, spdMasMainte_Sheet1.Columns.Count, true, sortinfo);

            //ソートインジゲータの設定.
            if (beforeColumn == e.Column)
            {
                if (Sortindicator == 0)
                {
                    spdMasMainte_Sheet1.Columns[e.Column].SortIndicator = SortIndicator.Ascending;
                    Sortindicator = 1;
                }
                else if (Sortindicator == 1)
                {
                    spdMasMainte_Sheet1.Columns[e.Column].SortIndicator = SortIndicator.Descending;
                    Sortindicator = 2;
                }
                else if (Sortindicator == 2)
                {
                    spdMasMainte_Sheet1.Columns[e.Column].SortIndicator = SortIndicator.Ascending;
                    Sortindicator = 1;
                }
            }
            else
            {
                spdMasMainte_Sheet1.Columns[beforeColumn].SortIndicator = SortIndicator.None;
                spdMasMainte_Sheet1.Columns[e.Column].SortIndicator = SortIndicator.Ascending;
                Sortindicator = 1;
            }

            beforeColumn = e.Column;
        }
        #endregion オートソートカラムクリック時.

        #region Comboイベントマッピング処理.
        /// <summary>
        /// Comboイベントマッピング処理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdMasMainte_EditModeOn(object sender, System.EventArgs e)
        {
            //セル型がコンボボックス型の場合は、EditingControlをComboにマッピングする.
            int irow = spdMasMainte.ActiveSheet.ActiveRowIndex;
            int icol = spdMasMainte.ActiveSheet.ActiveColumnIndex;

            if (spdMasMainte.ActiveSheet.GetCellType(irow, icol) is ComboBoxCellType)
            {
                Combo = (FpCombo)spdMasMainte.EditingControl;

                //Comboのイベントをマッピングする.
                Combo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Combo_KeyDown);
                Combo.DropDown += new FarPoint.Win.DropDownEventHandler(this.Combo_DropDown);
            }
        }
        #endregion Comboイベントマッピング処理.

        #region Enterキー押下時にフラグを立てる.
        /// <summary>
        /// Enterキー押下時にフラグを立てる.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Combo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //Enterキーが押された場合にフラグを立てる.
            bEnterKey = (e.KeyCode == Keys.Enter);
        }
        #endregion Enterキー押下時にフラグを立てる.

        #region フラグが立っている場合は、DropDown処理をキャンセルする.
        /// <summary>
        /// フラグが立っている場合は、DropDown処理をキャンセルする.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Combo_DropDown(object sender, FarPoint.Win.DropDownEventArgs e)
        {
            //フラグが立っている場合は、DropDown処理をキャンセルする.
            e.Cancel = bEnterKey;
            bEnterKey = false;
        }
        #endregion フラグが立っている場合は、DropDown処理をキャンセルする.

        #region マスタメンテナンス一覧の編集後処理.
        /// <summary>
        /// マスタメンテナンス一覧の編集後処理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdMasMainte_EditModeOff(object sender, System.EventArgs e)
        {
            Combo.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.Combo_KeyDown);
            Combo.DropDown -= new FarPoint.Win.DropDownEventHandler(this.Combo_DropDown);
        }
        #endregion マスタメンテナンス一覧の編集後処理.

        #region セル型がコンボボックス型の場合は、EditingControlをComboにマッピングする.
        /// <summary>
        /// セル型がコンボボックス型の場合は、EditingControlをComboにマッピングする.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdMasMainte_KeyPress(object sender, KeyPressEventArgs e)
        {
            //セル型がコンボボックス型の場合は、EditingControlをComboにマッピングする.
            int irow = spdMasMainte.ActiveSheet.ActiveRowIndex;
            int icol = spdMasMainte.ActiveSheet.ActiveColumnIndex;
        }
        #endregion セル型がコンボボックス型の場合は、EditingControlをComboにマッピングする.

        #region スプレッドキー押下時.
        /// <summary>
        /// スプレッドキー押下時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdMasMainte_KeyDown(object sender, KeyEventArgs e)
        {
            //ペーストOrカットが行われたときに変更フラグを立てる.
            if ((e.Control && e.KeyCode == Keys.V) || (e.Control && e.KeyCode == Keys.X))
            {
                upchk = true;
            }
        }
        #endregion スプレッドキー押下時.

        #region スプレッドでチェックボックス押下時イベント.
        /// <summary>
        /// スプレッドでチェックボックス押下時イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdMasMainte_Change(object sender, ChangeEventArgs e)
        {
            //チェックボックス変更処理.
            CheckBoxEditChange(e);
        }
        #endregion スプレッドでチェックボックス押下時イベント.

        #region ヘルプボタン押下.
        /// <summary>
        /// ヘルプボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = mstNavPrm.strTksKgyCd + mstNavPrm.strTksBmnSeqNo + mstNavPrm.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();

            //実行.
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.MasterMaintenance, this, HelpNavigator.KeywordIndex);

            this.ActiveControl = null;
        }
        #endregion ヘルプボタン押下.

        #region チェックボックス変更処理.
        /// <summary>
        /// チェックボックス変更処理.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void CheckBoxEditChange(FarPoint.Win.Spread.ChangeEventArgs e)
        {
            upchk = true;
        }
        #endregion チェックボックス変更処理.
        #endregion イベント.

        #region メソッド.
        #region 必須項目入力チェック.
        /// <summary>
        /// 必須項目入力チェック.
        /// </summary>
        /// <returns></returns>
        //protected bool NrChk(ref string col)
        protected virtual bool NrChk(ref string col)
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

            return true;
        }
        #endregion 必須項目入力チェック.

        #region マスター名コンボボックスにメニュー画面で押下されたマスターボタン名をセット.
        /// <summary>
        /// マスター名コンボボックスにメニュー画面で押下されたマスターボタン名をセット.
        /// </summary>
        protected virtual void CombSetFromMenue()
        {
            //マスター名コンボボックスにメニュー画面で押下されたマスターボタン名をセット.
            cmbMasterName1.Text = mstNavPrm.StrValue1;
        }
        #endregion マスター名コンボボックスにメニュー画面で押下されたマスターボタン名をセット.

        #region スプレッドの設定.
        /// <summary>
        /// スプレッドの設定.
        /// </summary>
        protected virtual void SpreadSetting()
        {
            //コントロール変更に対する更新の保留.
            spdMasMainte.SuspendLayout();

            //カラススタートインデックス.
            int ColIndex = 11;
            //行カウント.
            int RowCount = spdMasMainte_Sheet1.Rows.Count;
            //国際区分用の配列.
            string[] kokuKbnArr = new string[RowCount];

            //スプレッド初期化.
            for (int j = 0; j < SpColNum; j++)
            {
                spdMasMainte.Sheets[0].Columns[j].Visible = false;
                spdMasMainte.Sheets[0].Columns[j].Label = null;
                spdMasMainte.Sheets[0].Columns[j].BackColor = Color.White;
            }

            drMasterItem[] resultrow = (drMasterItem[])mstDtSet.MasterDataSet.MasterItemVO.Select("field1 = '" + mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3 + "'");

            //マスタ項目件数分ループ処理.
            foreach (drMasterItem row in resultrow)
            {
                //列名.
                spdMasMainte_Sheet1.Columns[ColIndex].Label = row.field3;
                //表示.
                spdMasMainte_Sheet1.Columns[ColIndex].Visible = true;
                /* 2017/04/14 エプソン仕入先情報変更対応 HLC K.Soga MOD Start */
                //列幅.
                //spdMasMainte_Sheet1.Columns[ColIndex].Width = float.Parse(row.field9);
                //列幅が空の場合.
                if (String.IsNullOrEmpty(row.field9))
                {
                    //列幅にデフォルト値[80]を設定.
                    spdMasMainte_Sheet1.Columns[ColIndex].Width = 80;
                }
                //列幅が空でない場合.
                else
                {
                    //取得した列幅を設定.
                    spdMasMainte_Sheet1.Columns[ColIndex].Width = float.Parse(row.field9);
                }
                /* 2017/04/14 エプソン仕入先情報変更対応 HLC K.Soga MOD End */

                //セルの状態をクリア.
                for (int i = 0; i < RowCount; i++)
                {
                    spdMasMainte_Sheet1.Cells[i, ColIndex].BackColor = Color.White;
                    spdMasMainte_Sheet1.Cells[i, ColIndex].Locked = false;
                    spdMasMainte_Sheet1.Cells[i, ColIndex].CanFocus = true;
                }

                /*
                /セル内の文字位置.
                */
                //垂直方向.
                spdMasMainte_Sheet1.Columns[ColIndex].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                //水平方向.
                switch (row.field11)
                {
                    case "0"://右寄せ.
                        spdMasMainte_Sheet1.Columns[ColIndex].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                        break;
                    case "1"://左寄せ.
                        spdMasMainte_Sheet1.Columns[ColIndex].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                        break;
                    case "2"://中央寄せ.
                        spdMasMainte_Sheet1.Columns[ColIndex].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        break;
                    default://未設定.
                        spdMasMainte_Sheet1.Columns[ColIndex].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
                        break;
                }

                /*
                /セルType.
                */
                switch (row.field5)
                {
                    //テキストタイプ.
                    case "0":
                        FarPoint.Win.Spread.CellType.TextCellType txtyp = new FarPoint.Win.Spread.CellType.TextCellType();
                        spdMasMainte_Sheet1.Columns[ColIndex].CellType = txtyp;

                        if (!string.IsNullOrEmpty(row.field6))
                        {
                            //最大文字数.
                            txtyp.MaxLength = int.Parse(row.field6);
                        }
                        
                        //半角.
                        if (!string.IsNullOrEmpty(row.field15))
                        {
                            switch (row.field15)
                            {
                                case "1"://英数字のみ.
                                    txtyp.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Ascii;
                                    break;
                                case "2"://数字のみ.
                                    txtyp.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
                                    break;
                            }
                        }
                        break;

                    //数値タイプ.
                    case "1":
                        FarPoint.Win.Spread.CellType.NumberCellType numtyp = new FarPoint.Win.Spread.CellType.NumberCellType();
                        spdMasMainte_Sheet1.Columns[ColIndex].CellType = numtyp;

                        //小数点以下桁数.
                        if (!String.IsNullOrEmpty(row.intValue3))
                        {
                            numtyp.DecimalPlaces = Decimal.ToInt32(Isid.KKH.Common.KKHUtility.KKHUtility.DecParse(row.intValue3));
                        }

                        //カンマ区切り表示フラグ.
                        if (!String.IsNullOrEmpty(row.intValue4))
                        {
                            int state = Decimal.ToInt32(Isid.KKH.Common.KKHUtility.KKHUtility.DecParse(row.intValue4));

                            if (state == 0)
                            {
                                numtyp.ShowSeparator = true;
                            }
                            else if (state == 1)
                            {
                                numtyp.ShowSeparator = false;
                            }
                        }

                        //最大値、最小値の設定.
                        if (!string.IsNullOrEmpty(row.field13))
                        {
                            numtyp.MaximumValue = Isid.KKH.Common.KKHUtility.KKHUtility.DouParse(row.field13);
                        }
                        if (!string.IsNullOrEmpty(row.field14))
                        {
                            numtyp.MinimumValue = Isid.KKH.Common.KKHUtility.KKHUtility.DouParse(row.field14);
                        }
                        break;

                    //コンボタイプ.
                    case "2":
                        FarPoint.Win.Spread.CellType.ComboBoxCellType cmbtyp = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                        cmbtyp.Items = row.field20.Split(',');
                        cmbtyp.ItemData = row.field19.Split(',');
                        string[] nykfk = row.field18.Split(',');
                        bool flg = false;

                        //コンボボックスの値設定.
                        SpreadSettingCombo(row, cmbtyp, ColIndex, RowCount, kokuKbnArr);

                        //入力不可対象をロックする. 
                        if (row.field12.Equals("1"))
                        {
                            //レコードレベルでカラムを入力不可にする.
                            for (int j = 0; j < RowCount; j++)
                            {
                                spdMasMainte_Sheet1.Cells[j, ColIndex].BackColor = Color.Black;
                                spdMasMainte_Sheet1.Cells[j, ColIndex].Locked = true;
                                spdMasMainte_Sheet1.Cells[j, ColIndex].CanFocus = false;
                            }

                            //入力不可対象外を使用可能にする.
                            for (int n = 0; n < nykfk.Length; n++)
                            {
                                for (int j = 0; j < RowCount; j++)
                                {
                                    if (spdMasMainte_Sheet1.Cells[j, (int)Math.Truncate(double.Parse(row.intValue1))].Value.Equals(nykfk[n]))
                                    {
                                        spdMasMainte_Sheet1.Cells[j, ColIndex].BackColor = Color.White;
                                        spdMasMainte_Sheet1.Cells[j, ColIndex].Locked = false;
                                        //フォーカス可.
                                        spdMasMainte_Sheet1.Cells[j, ColIndex].CanFocus = true;
                                    }
                                }
                            }
                        }

                        //[国際区分]列の場合.
                        if (spdMasMainte_Sheet1.ColumnHeader.Columns[ColIndex].Label == "国際区分")
                        {
                            for (int k = 0; k < RowCount; k++)
                            {
                                //[国際区分]列の値が[国際]の場合.
                                if (spdMasMainte_Sheet1.Cells[k, ColIndex].Value.Equals("国際"))
                                {
                                    kokuKbnArr[k] = "国際";
                                }
                                else
                                {
                                    kokuKbnArr[k] = "";
                                }
                            }
                        }

                        //国際区分用配列に値が存在する場合.
                        if (kokuKbnArr.Length > 0)
                        {
                            //処理対象が[タイムスポット区分]の場合.
                            if (spdMasMainte_Sheet1.ColumnHeader.Columns[ColIndex].Label == "タイムスポット区分")
                            {
                                for (int k = 0; k < RowCount; k++)
                                {
                                    if (!string.IsNullOrEmpty(kokuKbnArr[k]))
                                    {
                                        //[国際区分]列の値が[国際]の場合.
                                        if (kokuKbnArr[k] == "国際")
                                        {
                                            //編集不可.
                                            spdMasMainte_Sheet1.Cells[k, ColIndex].BackColor = Color.Black;
                                            spdMasMainte_Sheet1.Cells[k, ColIndex].Locked = true;
                                            spdMasMainte_Sheet1.Cells[k, ColIndex].CanFocus = false;
                                        }
                                    }
                                }
                            }
                        }                

                        //typeの変換.
                        spdMasMainte_Sheet1.Columns[ColIndex].CellType = cmbtyp;
                        //選択行のみコンボボックスを表示.
                        spdMasMainte.ButtonDrawMode = ButtonDrawModes.CurrentRow;
                        break;

                    //チェックボックスタイプ.
                    case "3":
                        FarPoint.Win.Spread.CellType.CheckBoxCellType chktyp 
                            = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                        spdMasMainte_Sheet1.Columns[ColIndex].CellType = chktyp;                        
                        
                        for (int j = 0; j < RowCount; j++)
                        {
                            if (spdMasMainte_Sheet1.Cells[j, ColIndex].Value.Equals("true"))
                            {
                                spdMasMainte_Sheet1.Cells[j, ColIndex].Value = true;
                            }
                            else if (spdMasMainte_Sheet1.Cells[j, ColIndex].Value.Equals("false"))
                            {
                                spdMasMainte_Sheet1.Cells[j, ColIndex].Value = false;
                            }
                        }
                        break;

                    //日付タイプ.
                    case "4":
                        FarPoint.Win.Spread.CellType.DateTimeCellType datetyp 
                            = new FarPoint.Win.Spread.CellType.DateTimeCellType();

                        for (int j = 0; j < RowCount; j++)
                        {
                            //文字列からDateTime型へ変換(YYYY/MM/DD形式).
                            spdMasMainte_Sheet1.Cells[j, int.Parse(row.field2)].Value 
                                = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime(spdMasMainte.Sheets[0].Cells[j, int.Parse(row.field2)].Text);
                            spdMasMainte_Sheet1.Columns[ColIndex].CellType = datetyp;
                        }
                        break;
                }
                
                //表示非表示の切り替え.
                double enableFlg = Math.Truncate(double.Parse(row.intValue2));
                switch (enableFlg.ToString())
                {
                    case "0":
                        spdMasMainte_Sheet1.Columns[ColIndex].Visible = false;
                        break;
                    case "1":
                        spdMasMainte_Sheet1.Columns[ColIndex].Visible = true;
                        break;
                    default:
                        spdMasMainte_Sheet1.Columns[ColIndex].Visible = false;
                        break;
                }
                ColIndex++;
            }

            //コントロール変更に対する更新の保留解除.
            spdMasMainte.ResumeLayout();
        }
        #endregion スプレッドの設定.

        #region 0埋め処理.
        /// <summary>
        /// 0埋め処理.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="cmbtyp"></param>
        /// <param name="ColIndex"></param>
        /// <param name="RowCount"></param>
        /// <param name="kokuKbnArr"></param>
        protected virtual void SpreadSettingCombo(MasterMaintenance.MasterItemVORow row, FarPoint.Win.Spread.CellType.ComboBoxCellType cmbtyp, int ColIndex, int RowCount, string[] kokuKbnArr)
        {
            for (int i = 0; i < RowCount; i++)
            {
                {
                    if (spdMasMainte_Sheet1.Cells[i, ColIndex].Value == null)
                    {
                        spdMasMainte_Sheet1.Cells[i, ColIndex].Value = '0';
                        continue;
                    }
                }

                {
                    Boolean flg = false;

                    for (int j = 0; j < cmbtyp.Items.Length; j++)
                    {
                        if (spdMasMainte_Sheet1.Cells[i, ColIndex].Value.Equals(cmbtyp.Items[j]))
                        {
                            flg = true;
                            break;
                        }
                    }

                    if (flg) { continue; }
                }

                {
                    Boolean flg = false;

                    for (int j = 0; j < cmbtyp.ItemData.Length; j++)
                    {
                        if (spdMasMainte_Sheet1.Cells[i, ColIndex].Value.Equals(cmbtyp.ItemData[j]))
                        {
                            spdMasMainte_Sheet1.Cells[i, ColIndex].Value = cmbtyp.Items[j];
                            flg = true;
                            break;
                        }
                    }

                    if (!flg) { spdMasMainte_Sheet1.Cells[i, ColIndex].Value = '0'; }
                }
            }
        }
        #endregion 0埋め処理.

        #region 更新日時の最大値を取得.
        /// <summary>
        /// 更新日時の最大値を取得.
        /// </summary>
        /// <param name="result"></param>
        protected void updateMaxfind(FindMasterMaintenanceByCondServiceResult result)
        {
            //マスタデータが0件の場合.
            if (result.MasterDataSet.MasterDataVO.Rows.Count == 0)
            {
                //初期値の設定.
                maxupdate = DateTime.Parse("1000/01/01 01:01:01");
            }

            //マスタデータ件数分ループ処理.
            for (int i = 0; i < result.MasterDataSet.MasterDataVO.Rows.Count; i++)
            {
                if (maxupdate == DateTime.Parse("1000/01/01 01:01:01"))
                {
                    maxupdate = result.MasterDataSet.MasterDataVO[i].updTimStmp;
                }

                if (DateTime.Compare(result.MasterDataSet.MasterDataVO[i].updTimStmp, maxupdate) > 0)
                {
                    maxupdate = result.MasterDataSet.MasterDataVO[i].updTimStmp;
                }
            }
        }
        #endregion 更新日時の最大値を取得.

        #region Kind用更新日時最大値取得.
        /// <summary>
        /// Kind用更新日時最大値取得.
        /// </summary>
        /// <param name="kindVo"></param>
        private void KindUpdateMaxfind(MasterMaintenance.MasterKindVODataTable kindVo)
        {
            if (kindVo.Rows.Count == 0)
            {
                maxupdate = DateTime.Parse("1000/01/01 01:01:01");
            }
            for (int i = 0; i < kindVo.Rows.Count; i++)
            {
                if (maxupdate == DateTime.Parse("1000/01/01 01:01:01"))
                {
                    maxupdate = DateTime.Parse(kindVo[i].updTimStmp);
                }

                if (DateTime.Compare(DateTime.Parse(kindVo[i].updTimStmp), maxupdate) > 0)
                {
                    maxupdate = DateTime.Parse(kindVo[i].updTimStmp);
                }
            }
        }
        #endregion Kind用更新日時最大値取得.

        #region Item用更新日時最大値取得.
        /// <summary>
        /// Item用更新日時最大値取得.
        /// </summary>
        /// <param name="itemVo"></param>
        private void ItemUpdateMaxfind(MasterMaintenance.MasterItemVODataTable itemVo)
        {
            if (itemVo.Rows.Count == 0)
            {
                maxupdate = DateTime.Parse("1000/01/01 01:01:01");
            }
            for (int i = 0; i < itemVo.Rows.Count; i++)
            {
                if (maxupdate == DateTime.Parse("1000/01/01 01:01:01"))
                {
                    maxupdate = DateTime.Parse(itemVo[i].updTimStmp);
                }

                if (DateTime.Compare(DateTime.Parse(itemVo[i].updTimStmp), maxupdate) > 0)
                {
                    maxupdate = DateTime.Parse(itemVo[i].updTimStmp);
                }
            }
        }
        #endregion Item用更新日時最大値取得.

        #region データ再表示.
        /// <summary>
        /// データ再表示.
        /// </summary>
        protected virtual void reDisplay()
        {
            //未更新の場合.
            if (upchk)
            {   
                //更新破棄の確認.
                DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0032, null, KKHSystemConst.KoteiMongon.MASTERMAINTENANCE, MessageBoxButtons.OKCancel);
                
                //キャンセルボタンを選択した場合.
                if (check == DialogResult.Cancel)
                {
                    return;
                }
            }

            //インスタンスの生成.
            MasterMaintenanceProcessController masterMaintenanceProcessController = MasterMaintenanceProcessController.GetInstance();

            //ローディング表示開始.
            base.ShowLoadingDialog();

            //マスター定義を選択している場合.
            if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].sybt.Equals(MST_KIND_SYBT))
            {
                //Kindを取ってくる.
                FindMasterMaintenanceByCondServiceResult kindResult = masterMaintenanceProcessController.FindMasterDefineByCond(mstNavPrm.strEsqId,
                                                                                                                            mstNavPrm.strEgcd,
                                                                                                                            mstNavPrm.strTksKgyCd,
                                                                                                                            mstNavPrm.strTksBmnSeqNo,
                                                                                                                            mstNavPrm.strTksTntSeqNo);
                //エラーだったら.
                if (kindResult.HasError)
                {
                    //ローディング表示終了.
                    base.CloseLoadingDialog();

                    return;
                }

                spdMasMainte_Sheet1.DataSource = kindResult.MasterDataSet.MasterKindVO;

                //KIND用スプレッドの設定.
                kindSetSpred();

                cmdMasterName2.Visible = false;
                Itemcmb.Visible = false;

                //ローディング表示終了.
                base.CloseLoadingDialog();

            }  
            //マスター項目ボタンを選択している場合.
            else if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].sybt.Equals(MST_ITME_SYBT))
            {
                //itemを取ってくる.
                FindMasterMaintenanceByCondServiceResult itemResult = masterMaintenanceProcessController.FindMasterDefineByCond(mstNavPrm.strEsqId,
                                                                                                                           mstNavPrm.strEgcd,
                                                                                                                           mstNavPrm.strTksKgyCd,
                                                                                                                           mstNavPrm.strTksBmnSeqNo,
                                                                                                                           mstNavPrm.strTksTntSeqNo);
                //エラーの場合.
                if (itemResult.HasError)
                {
                    //ローディング表示終了.
                    base.CloseLoadingDialog();
                    return;
                }

                cmdMasterName2.Visible = false;
                drMasterKind[] kindrow = (drMasterKind[])itemResult.MasterDataSet.MasterKindVO.Select("", "");
                drMasterItem[] itemrow = (drMasterItem[])itemResult.MasterDataSet.MasterItemVO.Select("", "");

                int count = 0;
                string beforeCd = string.Empty;
                Itemcmb.Items.Clear();

                //フィルタリングリストの生成.
                foreach (drMasterItem row in itemrow)
                {
                    if (count == 0)
                    {
                        beforeCd = row.field1;
                        count++;
                    }

                    if (!beforeCd.Equals(row.field1))
                    {
                        Itemcmb.Items.Add(beforeCd);
                        beforeCd = row.field1;
                    }
                }

                if (!string.IsNullOrEmpty(beforeCd))
                {
                    Itemcmb.Items.Add(beforeCd);
                }

                //マスター名も入れる.
                foreach (drMasterKind addrow in kindrow)
                {
                    for (int cmbcount = 0; cmbcount < Itemcmb.Items.Count; cmbcount++)
                    {
                        if (Itemcmb.Items[cmbcount].ToString().Equals(addrow.field3))
                        {
                            Itemcmb.Items[cmbcount] = Itemcmb.Items[cmbcount].ToString() + " " + addrow.field1;
                        }
                    }
                }

                Itemcmb.Visible = true;
                upchk = false;

                //To ItemcmbSelectedindexイベントへ.
                Itemcmb.SelectedIndex = 0;

                //ローディング表示終了.
                base.CloseLoadingDialog();
            }
            else
            {
                FindMasterMaintenanceByCondServiceResult result = masterMaintenanceProcessController.FindMasterByCond(mstNavPrm.strEsqId,
                                                                                mstNavPrm.strEgcd,
                                                                                mstNavPrm.strTksKgyCd,
                                                                                mstNavPrm.strTksBmnSeqNo,
                                                                                mstNavPrm.strTksTntSeqNo,
                                                                                mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3,
                                                                                mstNavPrm.strFilterValue);
                //エラーの場合.
                if (result.HasError)
                {
                    //ローディング表示終了.
                    base.CloseLoadingDialog();
                    return;
                }

                spdMasMainte.SuspendLayout();
                spdMasMainte.DataSource = result.MasterDataSet.MasterDataVO;
                spdMasMainte.ResumeLayout();

                //スプレッドの設定.
                SpreadSetting();
            }
            tslCnt.Text = spdMasMainte_Sheet1.Rows.Count.ToString() + "件";
            upchk = false;
            
            //ローディング表示終了.
            base.CloseLoadingDialog();
        }
        #endregion データ再表示.

        #region ホームロード時.
        /// <summary>
        /// ホームロード時.
        /// </summary>
        protected virtual void homeLoad()
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            MasterMaintenanceProcessController masterMaintenanceProcessController = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result = masterMaintenanceProcessController.FindMasterDefineByCond(mstNavPrm.strEsqId,
                                                                                                                        mstNavPrm.strEgcd,
                                                                                                                        mstNavPrm.strTksKgyCd,
                                                                                                                        mstNavPrm.strTksBmnSeqNo,
                                                                                                                        mstNavPrm.strTksTntSeqNo);
            mstDtSet = result;
            drMasterKind[] delrow = (drMasterKind[])mstDtSet.MasterDataSet.MasterKindVO.Select("", "");

            //システム管理者対象のマスターを削除.
            if (!mstNavPrm.StrSystemAdministerFlg.Equals("1"))
            {
                //取得したマスタ件数分ループ処理.
                foreach (drMasterKind row in delrow)
                {
                    if (row.field6.Equals("1"))
                    {
                        mstDtSet.MasterDataSet.MasterKindVO.RemoveMasterKindVORow(row); 
                    }
                }
            }

            //コンボボックスの設定.
            SetAComb();

            drMasterKind[] kindrow = (drMasterKind[])mstDtSet.MasterDataSet.MasterKindVO.Select("", "");
           
            //システム管理者でない場合は非表示項目を削除する.
            if (!mstNavPrm.StrSystemAdministerFlg.Equals("1"))
            {
                foreach (drMasterKind row in kindrow)
                {
                    if (row.sybt.Equals(MST_KIND_SYBT) || row.sybt.Equals(MST_ITME_SYBT))
                    {
                        row.Delete();
                    }
                }
            }

            this.Text = mstNavPrm.strTksKgyName.ToString() + KKHSystemConst.KoteiMongon.MASTERMAINTENANCE;
            tslName.Text = mstNavPrm.strName;
            tslDate.Text = mstNavPrm.strDate;
            
            //画面最大化.
            this.WindowState = FormWindowState.Maximized;

            base.CloseLoadingDialog();
        }
        #endregion ホームロード時.

        #region xsdと名前を合わせるメソッド.
        /// <summary>
        /// xsdと名前を合わせるメソッド.
        /// </summary>
        /// <param name="name">DBの名前</param>
        /// <returns>xsdの名前</returns>
        private String getColumName(String name)
        {
            switch (name)
            {
                case "FIELD1":
                    name = "Column1";
                    break;
                case "FIELD2":
                    name = "Column2";
                    break;
                case "FIELD3":
                    name = "Column3";
                    break;
                case "FIELD4":
                    name = "Column4";
                    break;
                case "FIELD5":
                    name = "Column5";
                    break;
                case "FIELD6":
                    name = "Column6";
                    break;
                case "FIELD7":
                    name = "Column7";
                    break;
                case "FIELD8":
                    name = "Column8";
                    break;
                case "FIELD9":
                    name = "Column9";
                    break;
                case "FIELD10":
                    name = "Column10";
                    break;
                case "FIELD11":
                    name = "Column11";
                    break;
                case "FIELD12":
                    name = "Column12";
                    break;
                case "FIELD13":
                    name = "Column13";
                    break;
                case "FIELD14":
                    name = "Column14";
                    break;
                case "FIELD15":
                    name = "Column15";
                    break;
                case "FIELD16":
                    name = "Column16";
                    break;
                case "FIELD17":
                    name = "Column17";
                    break;
                case "FIELD18":
                    name = "Column18";
                    break;
                case "FIELD19":
                    name = "Column19";
                    break;
                case "FIELD20":
                    name = "Column20";
                    break;
                case "INTVALUE1":
                    name = "Column21";
                    break;
                case "INTVALUE2":
                    name = "Column22";
                    break;
                case "INTVALUE3":
                    name = "Column23";
                    break;
                case "INTVALUE4":
                    name = "Column24";
                    break;
                case "INTVALUE5":
                    name = "Column25";
                    break;
                case "INTVALUE6":
                    name = "Column26";
                    break;
                case "INTVALUE7":
                    name = "Column27";
                    break;
                case "INTVALUE8":
                    name = "Column28";
                    break;
                case "INTVALUE9":
                    name = "Column29";
                    break;
                case "INTVALUE10":
                    name = "Column30";
                    break;
            }

            return name;
        }
        #endregion xsdと名前を合わせるメソッド.

        #region ソートナンバーの取得.
        /// <summary>
        /// ソートナンバーの取得.
        /// </summary>
        /// <returns></returns>
        private int getSortIndex()
        {
            foreach (MasterMaintenance.MasterKindVORow dr in mstDtSet.MasterDataSet.MasterKindVO.Select(
                "field3 = " + mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3))
            {
                //ソートカラムの検索.
                SortCol = dr.field4.Split(',');
            }
            
            String sortname = string.Empty;

            //ソートカラムが２件以上の場合.
            if (SortCol.Length > 1) { sortname = getColumName(SortCol[1]); }
            else{ sortname = getColumName(SortCol[0]); }
            
            int sortnum = 0;
            foreach (Column col in spdMasMainte.Sheets[0].Columns)
            {
                if (sortname.Equals(col.DataField))
                { 
                    break;
                }
                sortnum++;
            }

            return sortnum;
        }
        #endregion ソートナンバーの取得.

        #region 重複チェック.
        /// <summary>
        /// 重複チェック.
        /// </summary>
        /// <returns>w</returns>
        protected virtual bool CfukuCheck()
        {
            //重複チェックリスト.
            ArrayList keylist = new ArrayList();
            foreach (drMasterItem dr1 in mstDtSet.MasterDataSet.MasterItemVO.Select("field1 = " + mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3))
            {
                if (dr1.field10.Equals("1"))
                {
                    //重複不可対象の列順を格納.
                    keylist.Add(dr1.field2);
                }
            }

            //重複チェック1つの場合.
            if (keylist.Count == 1)
            {
                //比較キー. 
                String key = null;
                //比較先キー.
                String key2 = null;

                for (int k = 0; k < spdMasMainte.Sheets[0].Rows.Count; k++)
                {
                    for (int j = 0; j < keylist.Count; j++)
                    {
                        //比較元の設定.
                        key =  spdMasMainte.Sheets[0].Cells[k, int.Parse(keylist[j].ToString())].Text;
                    }

                    for (int h = k + 1; h < spdMasMainte.Sheets[0].Rows.Count; h++)
                    {
                        for (int j = 0; j < keylist.Count; j++)
                        {
                            //比較先の設定.
                            key2 = key2 + spdMasMainte.Sheets[0].Cells[h, int.Parse(keylist[j].ToString())].Text;
                        }
                        if (key.Equals(key2))
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0008, null, "エラー", MessageBoxButtons.OK);

                            return false;
                        }
                        else
                        {
                            key2 = null;
                        }
                    }
                }
            }
            //重複チェック　2つ以上の場合.
            else if (keylist.Count > 1)
            {
                //比較キー.
                string Mkey = string.Empty;
                //比較先キー.
                string Skey = string.Empty;
                for (int i = 0; i < spdMasMainte_Sheet1.Rows.Count; i++)
                {
                    for (int l = 0; l < keylist.Count; l++)
                    {
                        //比較元の設定.
                        Mkey = Mkey + spdMasMainte_Sheet1.Cells[i, int.Parse(keylist[l].ToString())].Text; 
                    }

                    for (int h = i + 1; h < spdMasMainte_Sheet1.Rows.Count; h++)
                    {
                        for (int j = 0; j < keylist.Count; j++)
                        {
                            //比較先の設定.
                            Skey = Skey + spdMasMainte_Sheet1.Cells[h, int.Parse(keylist[j].ToString())].Text;
                        }
                        if (Mkey.Equals(Skey))
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0008, null, "エラー", MessageBoxButtons.OK);
                            return false;
                        }
                        else
                        {
                            Skey = string.Empty;
                        }
                    }
                }
            }

            return true;
        }
        #endregion 重複チェック.

        #region 最大最低入力文字チェック.
        /// <summary>
        /// 最大最低入力文字チェック.
        /// </summary>
        /// <returns></returns>
        protected bool MaxMinInputCheck()
        {
            //スプレッド最終行を取得.
            int Count = spdMasMainte_Sheet1.Rows.Count;

            //選択中のマスタメンテコンボボックス名で抽出.
            drMasterItem[] itemrow = (drMasterItem[])mstDtSet.MasterDataSet.MasterItemVO.Select("field1 = '" + mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3 + "'");

            //取得したマスタメンテナンス件数分ループ処理.
            foreach (drMasterItem row in itemrow)
            {
                /*
                 * 最大文字数.
                */
                //最大文字数が空でない場合.
                if (!string.IsNullOrEmpty(row.field6))
                {
                    //カラム数分ループ処理.
                    for (int j = 0; j < Count; j++)
                    {
                        //対象の値を取得.
                        string rowField2 = spdMasMainte_Sheet1.Cells[j, int.Parse(row.field2)].Text;
                        
                        //数値型の場合.
                        if (row.field5.Equals(KKHSystemConst.SUTI))
                        {
                            //3桁区切りを除く.
                            rowField2 = rowField2.Replace(",", "");
                        }

                        //最大文字数を超過した場合.
                        if (rowField2.Length > long.Parse(row.field6))
                        {
                            //ローディング表示終了.  
                            base.CloseLoadingDialog();
                            int jnum = j + 1;
                            string[] comment1 = new string[] { row.field3, jnum.ToString(), row.field6 };
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0092, comment1, "マスターメンテナンス", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }

                //最低文字数.
                if (!string.IsNullOrEmpty(row.field7))
                {
                    //カラム数分ループ処理.
                    for (int i = 0; i < Count; i++)
                    {
                        //対象の値を取得.
                        string rowField2 = spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2)].Text;

                        //数値型の場合.
                        if (row.field5.Equals(KKHSystemConst.SUTI))
                        {
                            //3桁区切りを除く.
                            rowField2 = rowField2.Replace(",", "");
                        }

                        /* 2017/04/17 エプソン仕入先情報変更対応 HLC K.Soga ADD Start */
                        //必須項目が空の場合.
                        if (string.IsNullOrEmpty(row.field8))
                        {
                            row.field8 = KKHSystemConst.ZERO;
                        }
                        //対象の項目が空で必須項目でない場合は、チェック対象外とする.
                        if (rowField2.Length == 0 && row.field8.Equals(KKHSystemConst.ZERO))
                        {
                            continue;
                        }
                        /* 2017/04/17 エプソン仕入先情報変更対応 HLC K.Soga ADD End */

                        //最小文字数未満の場合.
                        if (rowField2.Length < long.Parse(row.field7))
                        {
                            //ローディング表示終了.
                            base.CloseLoadingDialog();
                            int inum = i + 1;
                            string[] comment2 = new string[] {row.field3, inum.ToString(), row.field7};
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0093, comment2, KKHSystemConst.KoteiMongon.MASTERMAINTENANCE, MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }
            }

            return true;
        }
        #endregion 最大最低入力文字チェック.

        #region マスターコンボクリック.
        /// <summary>
        /// マスターコンボクリック.
        /// </summary>
        protected virtual void MastCmbClick()
        {
            //未更新の場合.
            if (upchk)
            {
                DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0032, null, KKHSystemConst.ZERO, MessageBoxButtons.OKCancel);

                //キャンセルボタン押下時の場合.
                if (check == DialogResult.Cancel)
                {
                    cmbMasterName1Flg = true;
                    cmbMasterName1.SelectedIndex = masterNameIndex;
                    return;
                }
            }

            //ローディング表示開始.
            base.ShowLoadingDialog();

            //インスタンスの取得.
            MasterMaintenanceProcessController masterMaintenanceProcessController = MasterMaintenanceProcessController.GetInstance();
           
            //マスター定義ボタンの場合.
            if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].sybt.Equals(MST_KIND_SYBT))
            {

                //KINDを取得する.
                FindMasterMaintenanceByCondServiceResult kindResult = masterMaintenanceProcessController.FindMasterDefineByCond(mstNavPrm.strEsqId,
                                                                                                                            mstNavPrm.strEgcd,
                                                                                                                            mstNavPrm.strTksKgyCd,
                                                                                                                            mstNavPrm.strTksBmnSeqNo,
                                                                                                                            mstNavPrm.strTksTntSeqNo);

                //エラーの場合.
                if (kindResult.HasError)
                {
                    //ローディング表示終了.
                    base.CloseLoadingDialog();
                    return;
                }

                spdMasMainte_Sheet1.DataAutoSizeColumns = true;
                spdMasMainte_Sheet1.DataSource = kindResult.MasterDataSet.MasterKindVO;
                spdMasMainte_Sheet1.DataAutoSizeColumns = false;

                //背景の初期化.
                BackColorSyokika();

                //KIND用スプレッドの設定.
                kindSetSpred();

                cmdMasterName2.Visible = false;
                Itemcmb.Visible = false;
                label1.Visible = false;

                tslCnt.Text = kindResult.MasterDataSet.MasterKindVO.Rows.Count.ToString() + "件"; 
            }
            //マスター項目ボタンの場合.
            else if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].sybt.Equals(MST_ITME_SYBT))
            {
                //ITEMを取得する.
                FindMasterMaintenanceByCondServiceResult itemResult = masterMaintenanceProcessController.FindMasterDefineByCond(mstNavPrm.strEsqId,
                                                                                                                           mstNavPrm.strEgcd,
                                                                                                                           mstNavPrm.strTksKgyCd,
                                                                                                                           mstNavPrm.strTksBmnSeqNo,
                                                                                                                           mstNavPrm.strTksTntSeqNo);
                //エラーの場合.
                if (itemResult.HasError)
                {
                    //ローディング表示終了.
                    base.CloseLoadingDialog();
                    return;
                }
                cmdMasterName2.Visible = false;

                MasterMaintenance.MasterItemVORow[] itemrow = (MasterMaintenance.MasterItemVORow[])itemResult.MasterDataSet.MasterItemVO.Select("", "");
                MasterMaintenance.MasterKindVORow[] kindrow = (MasterMaintenance.MasterKindVORow[])itemResult.MasterDataSet.MasterKindVO.Select("", "");
                
                //前媒体コード.
                string beforeCd = string.Empty;
                Itemcmb.Items.Clear();

                //マスタ種類件数分ループ処理.
                foreach (MasterMaintenance.MasterKindVORow row in kindrow)
                {
                    Itemcmb.Items.Add(row.field3 + " " + row.field1);
                }

                Itemcmb.Visible = true;
                label1.Visible = true;
                upchk = false;
                Itemcmb.SelectedIndex = 0;
            }
            //マスター名の場合.
            else
            {
                //DATAを取ってくる.
                masterMaintenanceProcessController = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = masterMaintenanceProcessController.FindMasterByCond(mstNavPrm.strEsqId,
                                                                                                                        mstNavPrm.strEgcd,
                                                                                                                        mstNavPrm.strTksKgyCd,
                                                                                                                        mstNavPrm.strTksBmnSeqNo,
                                                                                                                        mstNavPrm.strTksTntSeqNo,
                                                                                                                        mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3,
                                                                                                                        null);
                //エラーの場合.
                if (result.HasError)
                {
                    //ローディング表示終了.
                    base.CloseLoadingDialog();
                    return;
                }

                spdMasMainte.SuspendLayout();
                spdMasMainte.DataSource = result.MasterDataSet.MasterDataVO;
                spdMasMainte.ResumeLayout();
                spdMasMainte_Sheet1.ColumnHeader.Rows[0].Height = 30;

                tslCnt.Text = spdMasMainte.Sheets[0].Rows.Count.ToString() + "件";

                //更新日時MAX値の取得.
                updateMaxfind(result);

                //マスターキーのセット.
                mstNavPrm.strMasterKey = mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3;

                //フィルタリング項目表示・非表示.
                if (string.IsNullOrEmpty(mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field10.ToString()))
                {
                    //非表示.
                    cmdMasterName2.Visible = false;
                    label1.Visible = false;
                    Itemcmb.Visible = false;
                    BackColorSyokika();

                    //スプレッドの設定.
                    SpreadSetting();
                }
                else
                {
                    //表示.
                    cmdMasterName2.Visible = true;
                    label1.Visible = true;
                    upchk = false;
                    Itemcmb.Visible = false;
                    
                    string masterkey = mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field10;
                    FindMasterMaintenanceByCondServiceResult filterResult = masterMaintenanceProcessController.FindMasterByCond(mstNavPrm.strEsqId,
                                                                                                                       mstNavPrm.strEgcd,
                                                                                                                       mstNavPrm.strTksKgyCd,
                                                                                                                       mstNavPrm.strTksBmnSeqNo,
                                                                                                                       mstNavPrm.strTksTntSeqNo,
                                                                                                                       masterkey,
                                                                                                                       null);

                    if (filterResult.HasError)
                    {
                        //ローディング表示終了.
                        base.CloseLoadingDialog();
                        return;
                    }

                    MasterMaintenance.MasterDataVORow[] filterRow = (MasterMaintenance.MasterDataVORow[])filterResult.MasterDataSet.MasterDataVO.Select("", "");

                    cmdMasterName2.Items.Clear();

                    //フィルタリング用コンボボックスの作成.
                    foreach (MasterMaintenance.MasterDataVORow row in filterRow)
                    {
                        cmdMasterName2.Items.Add(row.Column1 + " " + row.Column2);
                    }

                    //To フィルタリング項目がある場合イベントへ.
                    if (cmdMasterName2.Items.Count != 0)
                    {
                        cmdMasterName2.SelectedIndex = 0;
                    }
                }
            }

            upchk = false;

            //ローディング表示終了.
            base.CloseLoadingDialog();
        }
        #endregion マスターコンボクリック.

        #region 挿入行の設定.
        /// <summary>
        /// 挿入行の設定.
        /// </summary>
        /// <param name="addrow"></param>
        /// <returns></returns>
        private MasterMaintenance.MasterDataVORow rowSet(MasterMaintenance.MasterDataVORow addrow)
        {
            //選択されたマスターのマスターキー.
            string masterkey = mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3;

            MasterMaintenance.MasterItemVORow[] itemRow = (MasterMaintenance.MasterItemVORow[])mstDtSet.MasterDataSet.MasterItemVO.Select("field1 = '" + masterkey + "'");

            foreach (MasterMaintenance.MasterItemVORow row in itemRow)
            {
                if (!string.IsNullOrEmpty(row.field16))
                {
                    addrow[int.Parse(row.field2)] = row.field16;
                }
            }

            addrow.trkTimStmp = DateTime.Parse("1000/01/01 01:01:01");
            addrow.updTimStmp = DateTime.Parse("1000/01/01 01:01:01");

            return addrow;
        }
        #endregion 挿入行の設定.

        #region Cmb1の設定.
        /// <summary>
        /// Cmb1の設定.
        /// </summary>
        private void SetAComb()
        {            
            //KINDのコンボを追加.
            drMasterKind kindAddrow = mstDtSet.MasterDataSet.MasterKindVO.NewMasterKindVORow();
            kindAddrow.tksKgyCd = mstNavPrm.strTksKgyCd;
            kindAddrow.tksBmnSeqNo = mstNavPrm.strTksBmnSeqNo;
            kindAddrow.tksTntSeqNo = mstNavPrm.strTksTntSeqNo;
            kindAddrow.sybt = MST_KIND_SYBT;
            kindAddrow.field1 = MST_KIND;
            kindAddrow.field2 = string.Empty;
            mstDtSet.MasterDataSet.MasterKindVO.AddMasterKindVORow(kindAddrow);

            //ITEMのコンボを追加.
            drMasterKind ItemAddrow = mstDtSet.MasterDataSet.MasterKindVO.NewMasterKindVORow();
            ItemAddrow.tksKgyCd = mstNavPrm.strTksKgyCd;
            ItemAddrow.tksBmnSeqNo = mstNavPrm.strTksBmnSeqNo;
            ItemAddrow.tksTntSeqNo = mstNavPrm.strTksTntSeqNo;
            ItemAddrow.sybt = MST_ITME_SYBT;
            ItemAddrow.field1 = MST_ITEM;
            ItemAddrow.field2 = string.Empty;
            mstDtSet.MasterDataSet.MasterKindVO.AddMasterKindVORow(ItemAddrow);

            //マスター項目コンボボックスの作成.
            cmbMasterName1.DataSource = mstDtSet.MasterDataSet.MasterKindVO;
            cmbMasterName1.DisplayMember = KKHSystemConst.Field.FIELD_1;
        }
        #endregion Cmb1の設定.

        #region KIND用スプレッドの設定.
        /// <summary>
        /// KIND用スプレッドの設定.
        /// </summary>
        private void kindSetSpred()
        {
            //スプレッドカラム数分ループ処理.
            for (int i = 0; i < SpColNum; i++)
            {
                spdMasMainte_Sheet1.Columns[i].Visible = false;
                spdMasMainte_Sheet1.Columns[i].VerticalAlignment = CellVerticalAlignment.Center;
            }

            spdMasMainte_Sheet1.Columns[11].Label = "マスター名";
            spdMasMainte_Sheet1.Columns[12].Label = "種別";
            spdMasMainte_Sheet1.Columns[13].Label = "マスターキー";
            spdMasMainte_Sheet1.Columns[14].Label = "ソートカラム";
            spdMasMainte_Sheet1.Columns[15].Label = "第２フィルタ名";
            spdMasMainte_Sheet1.Columns[16].Label = "システム管理者フラグ";
            spdMasMainte_Sheet1.Columns[20].Label = "第２フィルタリスト";
            spdMasMainte_Sheet1.Columns[21].Label = "登録上限数";

            spdMasMainte_Sheet1.Columns[11].Visible = true;
            spdMasMainte_Sheet1.Columns[12].Visible = true;
            spdMasMainte_Sheet1.Columns[13].Visible = true;
            spdMasMainte_Sheet1.Columns[14].Visible = true;
            spdMasMainte_Sheet1.Columns[15].Visible = true;
            spdMasMainte_Sheet1.Columns[16].Visible = true;
            spdMasMainte_Sheet1.Columns[20].Visible = true;
            spdMasMainte_Sheet1.Columns[21].Visible = true;

            spdMasMainte_Sheet1.Columns[11].Width = 140;
            spdMasMainte_Sheet1.Columns[12].Width = 140;
            spdMasMainte_Sheet1.Columns[13].Width = 140;
            spdMasMainte_Sheet1.Columns[14].Width = 140;
            spdMasMainte_Sheet1.Columns[15].Width = 140;
            spdMasMainte_Sheet1.Columns[16].Width = 140;
            spdMasMainte_Sheet1.Columns[20].Width = 140;
            spdMasMainte_Sheet1.Columns[21].Width = 140;

            spdMasMainte_Sheet1.Columns[11].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[12].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[13].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[14].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[15].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[16].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[20].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[21].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
        }
        #endregion KIND用スプレッドの設定.

        #region ITEM用スプレッドの設定.
        /// <summary>
        /// ITEM用スプレッドの設定.
        /// </summary>
        private void itemSetSpred()
        {
            for (int i = 0; i < SpColNum; i++)
            {
                spdMasMainte_Sheet1.Columns[i].Visible = false;
                spdMasMainte_Sheet1.Columns[i].VerticalAlignment = CellVerticalAlignment.Center;
            }

            spdMasMainte_Sheet1.Columns[11].Label = "マスターキー";
            spdMasMainte_Sheet1.Columns[12].Label = "列順";
            spdMasMainte_Sheet1.Columns[13].Label = "列名";
            spdMasMainte_Sheet1.Columns[14].Label = "カラム名";
            spdMasMainte_Sheet1.Columns[15].Label = "型（テキスト:0/数値:1/コンボ:2/check:3/日付:4/ラジオ:5）";
            spdMasMainte_Sheet1.Columns[16].Label = "最大文字数";
            spdMasMainte_Sheet1.Columns[17].Label = "最小文字数";
            spdMasMainte_Sheet1.Columns[18].Label = "必須:1";
            spdMasMainte_Sheet1.Columns[19].Label = "列幅";
            spdMasMainte_Sheet1.Columns[20].Label = "キー:1";
            spdMasMainte_Sheet1.Columns[21].Label = "右寄せ:0/左寄せ:1/中央:2";
            spdMasMainte_Sheet1.Columns[22].Label = "入力不可";
            spdMasMainte_Sheet1.Columns[23].Label = "最大数";
            spdMasMainte_Sheet1.Columns[24].Label = "最小数";
            spdMasMainte_Sheet1.Columns[25].Label = "半角";
            spdMasMainte_Sheet1.Columns[26].Label = "デフォルト値";
            spdMasMainte_Sheet1.Columns[28].Label = "入力不可対象";
            spdMasMainte_Sheet1.Columns[29].Label = "コンボボックスキー";
            spdMasMainte_Sheet1.Columns[30].Label = "コンボボックス項目";
            spdMasMainte_Sheet1.Columns[32].Label = "表示非表示フラグ(非表示:0/表示:1)";
            spdMasMainte_Sheet1.Columns[33].Label = "小数点以下桁数";
            spdMasMainte_Sheet1.Columns[34].Label = "カンマ非表示フラグ(表示:0/非表示:1)"; //互換性の為（デフォルトが表示だった）.

            spdMasMainte_Sheet1.Columns[11].Visible = true;
            spdMasMainte_Sheet1.Columns[12].Visible = true;
            spdMasMainte_Sheet1.Columns[13].Visible = true;
            spdMasMainte_Sheet1.Columns[14].Visible = true;
            spdMasMainte_Sheet1.Columns[15].Visible = true;
            spdMasMainte_Sheet1.Columns[16].Visible = true;
            spdMasMainte_Sheet1.Columns[17].Visible = true;
            spdMasMainte_Sheet1.Columns[18].Visible = true;
            spdMasMainte_Sheet1.Columns[19].Visible = true;
            spdMasMainte_Sheet1.Columns[20].Visible = true;
            spdMasMainte_Sheet1.Columns[21].Visible = true;
            spdMasMainte_Sheet1.Columns[22].Visible = true;
            spdMasMainte_Sheet1.Columns[23].Visible = true;
            spdMasMainte_Sheet1.Columns[24].Visible = true;
            spdMasMainte_Sheet1.Columns[25].Visible = true;
            spdMasMainte_Sheet1.Columns[26].Visible = true;
            spdMasMainte_Sheet1.Columns[28].Visible = true;
            spdMasMainte_Sheet1.Columns[29].Visible = true;
            spdMasMainte_Sheet1.Columns[30].Visible = true;
            spdMasMainte_Sheet1.Columns[32].Visible = true;
            spdMasMainte_Sheet1.Columns[33].Visible = true;
            spdMasMainte_Sheet1.Columns[34].Visible = true;

            spdMasMainte_Sheet1.Columns[11].Width = 140;
            spdMasMainte_Sheet1.Columns[12].Width = 140;
            spdMasMainte_Sheet1.Columns[13].Width = 140;
            spdMasMainte_Sheet1.Columns[14].Width = 140;
            spdMasMainte_Sheet1.Columns[15].Width = 285;
            spdMasMainte_Sheet1.Columns[16].Width = 140;
            spdMasMainte_Sheet1.Columns[17].Width = 140;
            spdMasMainte_Sheet1.Columns[18].Width = 140;
            spdMasMainte_Sheet1.Columns[19].Width = 140;
            spdMasMainte_Sheet1.Columns[20].Width = 140;
            spdMasMainte_Sheet1.Columns[21].Width = 140;
            spdMasMainte_Sheet1.Columns[22].Width = 140;
            spdMasMainte_Sheet1.Columns[23].Width = 140;
            spdMasMainte_Sheet1.Columns[24].Width = 140;
            spdMasMainte_Sheet1.Columns[25].Width = 140;
            spdMasMainte_Sheet1.Columns[26].Width = 140;
            spdMasMainte_Sheet1.Columns[28].Width = 140;
            spdMasMainte_Sheet1.Columns[29].Width = 140;
            spdMasMainte_Sheet1.Columns[30].Width = 140;
            spdMasMainte_Sheet1.Columns[32].Width = 140;
            spdMasMainte_Sheet1.Columns[33].Width = 140;
            spdMasMainte_Sheet1.Columns[34].Width = 140;

            spdMasMainte_Sheet1.Columns[11].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[12].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[13].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[14].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[15].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[16].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[17].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[18].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[19].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[20].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[21].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[22].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[23].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[24].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[25].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[26].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[28].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[29].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[30].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[32].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[33].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            spdMasMainte_Sheet1.Columns[34].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;

            //表示非表示フラグは数値型.
            {
                FarPoint.Win.Spread.CellType.NumberCellType numtyp = new FarPoint.Win.Spread.CellType.NumberCellType();
                numtyp.DecimalPlaces = 0;
                spdMasMainte_Sheet1.Columns[32].CellType = numtyp;
            }

            {
                FarPoint.Win.Spread.CellType.NumberCellType numtyp = new FarPoint.Win.Spread.CellType.NumberCellType();
                numtyp.DecimalPlaces = 0;
                numtyp.MaximumValue = 99;
                numtyp.MinimumValue = 0;
                spdMasMainte_Sheet1.Columns[33].CellType = numtyp;
            }

            {
                FarPoint.Win.Spread.CellType.NumberCellType numtyp = new FarPoint.Win.Spread.CellType.NumberCellType();
                numtyp.DecimalPlaces = 0;
                numtyp.MaximumValue = 1;
                numtyp.MinimumValue = 0;
                spdMasMainte_Sheet1.Columns[34].CellType = numtyp;
            }
        }
        #endregion ITEM用スプレッドの設定.

        #region コンボボックス非表示.
        /// <summary>
        /// コンボボックス非表示.
        /// </summary>
        private void HyojiClear()
        {
            cmbMasterName1.Visible = false;
            cmdMasterName2.Visible = false;
            Itemcmb.Visible = false;
        }
        #endregion コンボボックス非表示.

        #region マスターデータ更新.
        /// <summary>
        /// マスターデータ更新.
        /// </summary>
        protected virtual void MstDataUpdate()
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            /*
             * 入力規制チェック.
             */
            //エラーカラム.
            string col = string.Empty;

            //必須項目のチェック.
            if (!NrChk(ref col))
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                col = col + "未入力の行があります";
                MessageUtility.ShowMessageBox(MessageCode.HB_E0013, new string[]{col},"エラー", MessageBoxButtons.OK);
                return;
            }

            //重複チェック.
            if (!CfukuCheck()) 
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                return;
            }

            //最低最大文字数チェック.
            if (!MaxMinInputCheck())
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                return;
            }

            if (!MstChk())
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                return;
            }

            drMasterItem[] itemrow = (drMasterItem[])mstDtSet.MasterDataSet.MasterItemVO.Select("field1 = '" + mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3 + "'");

            //各チェックが終了したので変更フラグをfalseにする.
            upchk = false;

            try
            {
                /*
                 * 値をDBの持ち方に戻す.
                 */
                //スプレッド最大行.
                int Count = spdMasMainte_Sheet1.Rows.Count;
                foreach (drMasterItem row in itemrow)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        //入力データが無い場合、デフォルト値を入れる。デフォルトが無い場合は0を入れる.
                        Object value = spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2)].Value;

                        if ((value == null) || string.IsNullOrEmpty(value.ToString()))
                        {
                            if (!string.IsNullOrEmpty(row.field16.Trim()))
                            {
                                spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2)].Text = row.field16.Trim();
                            }
                            else
                            {
                                if (row.field4.Trim().StartsWith("INTVALUE"))
                                {
                                    spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2)].Text = "0";
                                }
                                else
                                {
                                    spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2)].Text = "";
                                }
                            }
                        }
                    }

                    switch (row.field5)
                    {
                        //コンボボックス.
                        case "2":
                            MstDataUpdateCombo(row, Count);
                            break;

                        //チェックボックス.
                        case "3":
                            for (int k = 0; k < Count; k++)
                            {
                                FarPoint.Win.Spread.CellType.TextCellType txtyp = new FarPoint.Win.Spread.CellType.TextCellType();
                                spdMasMainte_Sheet1.Columns[int.Parse(row.field2)].CellType = txtyp;

                                if (spdMasMainte_Sheet1.Cells[k, int.Parse(row.field2)].Value == null)
                                {
                                    spdMasMainte_Sheet1.Cells[k, int.Parse(row.field2)].Value = "false";
                                }

                                if (spdMasMainte_Sheet1.Cells[k, int.Parse(row.field2)].Value.Equals(true))
                                {
                                    spdMasMainte_Sheet1.Cells[k, int.Parse(row.field2)].Value = "true";
                                }

                                else if (spdMasMainte_Sheet1.Cells[k, int.Parse(row.field2)].Value.Equals(false))
                                {
                                    spdMasMainte_Sheet1.Cells[k, int.Parse(row.field2)].Value = "false";
                                }
                            }

                            break;
                    }
                }

                //テキスト型に変換.
                for (int i = 0; i < SpColNum; i++)
                {
                    FarPoint.Win.Spread.CellType.TextCellType txtyp = new FarPoint.Win.Spread.CellType.TextCellType();
                    spdMasMainte.Sheets[0].Columns[i].CellType = txtyp;
                }

                MasterMaintenanceProcessController masterMaintenanceProcessController1 = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result1 = masterMaintenanceProcessController1.FindMasterByCond(mstNavPrm.strEsqId,
                                                                                                                        mstNavPrm.strEgcd,
                                                                                                                        mstNavPrm.strTksKgyCd,
                                                                                                                        mstNavPrm.strTksBmnSeqNo,
                                                                                                                        mstNavPrm.strTksTntSeqNo,
                                                                                                                        mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3,
                                                                                                                        mstNavPrm.strFilterValue);

                //更新日時MAX値の取得.
                updateMaxfind(result1);
                dtMasterData mstdatavo = new dtMasterData();
                mstdatavo = (dtMasterData)spdMasMainte.DataSource;
                RegisterMasterServiceResult result = masterMaintenanceProcessController1.RegisterMasterResult(mstNavPrm.strEsqId,
                                                                                                              mstNavPrm.AplId,
                                                                                                              mstNavPrm.strEgcd,
                                                                                                              mstNavPrm.strTksKgyCd,
                                                                                                              mstNavPrm.strTksBmnSeqNo,
                                                                                                              mstNavPrm.strTksTntSeqNo,
                                                                                                              mstNavPrm.strMasterKey,
                                                                                                              mstNavPrm.strFilterValue,
                                                                                                              mstdatavo,
                                                                                                              maxupdate);
                //エラーの場合.
                if (result.HasError)
                {
                    //ローディング表示終了.
                    base.CloseLoadingDialog();
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //画面表示.
            reDisplay();

            //ローディング表示終了.
            base.CloseLoadingDialog();

            //登録完了の表示.
            MessageUtility.ShowMessageBox(MessageCode.HB_I0001, null, "完了", MessageBoxButtons.OK);
        }
        #endregion マスターデータ更新.

        #region コンボボックス変更.
        /// <summary>
        /// コンボボックス変更.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="Count"></param>
        protected virtual void MstDataUpdateCombo(MasterMaintenance.MasterItemVORow row, int Count)
        {
            string[] cmbitm = row.field20.Split(',');
            string[] cmbkey = row.field19.Split(',');

            for (int h = 0; h < Count; h++)
            {
                {
                    if (spdMasMainte_Sheet1.Cells[h, int.Parse(row.field2)].Value == null)
                    {
                        continue;
                    }
                }

                {
                    for (int k = 0; k < cmbkey.Length; k++)
                    {
                        if (spdMasMainte_Sheet1.Cells[h, int.Parse(row.field2)].Value.Equals(cmbitm[k]))
                        {
                            spdMasMainte_Sheet1.Cells[h, int.Parse(row.field2)].Value = cmbkey[k];
                            break;
                        }
                    }
                }
            }
        }
        #endregion コンボボックス変更.

        #region マスタチェック.
        /// <summary>
        /// マスタチェック.
        /// </summary>
        /// <returns></returns>
        protected virtual bool MstChk()
        {
            return true;
        }
        #endregion マスタチェック.

        #region マスター定義更新.
        /// <summary>
        /// マスター定義更新.
        /// </summary>
        protected virtual void MstKindItemUpdate()
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            //種別.
            string sybt = string.Empty;
            MasterMaintenanceProcessController masterMaintenanceProcessController = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult kinditemResult = masterMaintenanceProcessController.FindMasterDefineByCond(mstNavPrm.strEsqId,
                                                                            mstNavPrm.strEgcd,
                                                                            mstNavPrm.strTksKgyCd,
                                                                            mstNavPrm.strTksBmnSeqNo,
                                                                            mstNavPrm.strTksTntSeqNo);
            //エラーの場合.
            if (kinditemResult.HasError)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                return;
            }

            mstNavPrm.strMasterKey = "define";
            mstNavPrm.strFilterValue = string.Empty;

            //マスターアイテムを選択している場合.
            if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].sybt.Equals(MST_ITME_SYBT))
            {
                mstNavPrm.strFilterValue = Itemcmb.SelectedItem.ToString().Substring(0, 4);
                ItemUpdateMaxfind(kinditemResult.MasterDataSet.MasterItemVO);
                sybt = "002";
            }
            else
            {
                KindUpdateMaxfind(kinditemResult.MasterDataSet.MasterKindVO);
                sybt = "001";
            }

            dtMasterData mstdatavo = new dtMasterData();

            //型変換、マスター定義またはマスター項目のデータをMasterDataVODataTable型へ変換する.
            mstdatavo = TypeChange();
            
            //インサート用パラメータの作成.
            MasterMaintenanceProcessController.RegisterKindItemMasterResultParam param = new MasterMaintenanceProcessController.RegisterKindItemMasterResultParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = mstNavPrm.strEgcd;
            param.tksKgyCd = mstNavPrm.strTksKgyCd;
            param.tksBmnSeqNo = mstNavPrm.strTksBmnSeqNo;
            param.tksTntSeqNo = mstNavPrm.strTksTntSeqNo;
            param.Sybt = sybt;
            param.masterkey = mstNavPrm.strMasterKey;
            param.filterValue = mstNavPrm.strFilterValue;
            param.maxupdate = maxupdate;
            param.masterdatavo = mstdatavo;
            param.AplId = "001";

            //実行.
            RegisterMasterServiceResult result = masterMaintenanceProcessController.RegisterKindItemMasterResult(param);
            
            //エラーの場合.
            if (result.HasError)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                return;
            }

            upchk = false;

            //ローディング表示終了.
            base.CloseLoadingDialog();

            //フィルタリング項目コンボボックスの行インデックスを保持.
            int selectedItemValue = this.Itemcmb.SelectedIndex;

            //再表示.
            reDisplay();

            //フィルタリング項目コンボボックスの行インデックスを反映.
            this.Itemcmb.SelectedIndex = selectedItemValue;

            //完了メッセージ表示.
            MessageUtility.ShowMessageBox(MessageCode.HB_I0001, null, "完了", MessageBoxButtons.OK);
        }
        #endregion マスター定義更新.

        #region 型変換.
        /// <summary>
        /// 型変換：マスター定義またはマスター項目のデータをMasterDataVODataTable型へ変換する.
        /// </summary>
        /// <returns>MasterDataVODataTable</returns>
        private MasterMaintenance.MasterDataVODataTable TypeChange()
        {
            //戻り値用DataTableのインスタンス生成.
            MasterMaintenance.MasterDataVODataTable mstDataVo = new MasterMaintenance.MasterDataVODataTable();

            //マスター名コンボボックスで「マスター項目」が選択されている場合.
            if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].sybt == MST_ITME_SYBT)
            {
                //一覧からマスター項目のDataTableを取得.
                MasterMaintenance.MasterItemVODataTable itemDataTable = new MasterMaintenance.MasterItemVODataTable();
                itemDataTable = (MasterMaintenance.MasterItemVODataTable)spdMasMainte_Sheet1.DataSource;

                //マスター項目の行数分繰り返す.
                foreach (MasterMaintenance.MasterItemVORow itemRow in itemDataTable.Rows)
                {
                    //新規行.
                    MasterMaintenance.MasterDataVORow addItemRow = mstDataVo.NewMasterDataVORow();

                    #region 新規行にマスター項目の値を設定.

                    //登録タイムスタンプがNullでない場合.
                    if (itemRow.IstrkTimStmpNull() == false)
                    {
                        //登録タイムスタンプがDateTime型に変換可能である場合.
                        DateTime parseTrkTimStmp = new DateTime();
                        if (DateTime.TryParse(itemRow.trkTimStmp, out parseTrkTimStmp) == true)
                        {
                            addItemRow.trkTimStmp = parseTrkTimStmp;
                        }
                    }

                    addItemRow.trkPl = itemRow.IstrkPlNull() ? string.Empty : itemRow.trkPl;
                    addItemRow.trkTnt = itemRow.IstrkTntNull() ? string.Empty : itemRow.trkTnt;

                    //更新タイムスタンプがNullでない場合.
                    if (itemRow.IsupdTimStmpNull() == false)
                    {
                        //更新タイムスタンプがDateTime型に変換可能である場合.

                        DateTime parseUpdTimStmp = new DateTime();
                        if (DateTime.TryParse(itemRow.updTimStmp, out parseUpdTimStmp) == true)
                        {
                            addItemRow.updTimStmp = parseUpdTimStmp;
                        }
                    }

                    addItemRow.updaPl = itemRow.IsupdaPlNull() ? string.Empty : itemRow.updaPl;
                    addItemRow.updTnt = itemRow.IsupdTntNull() ? string.Empty : itemRow.updTnt;
                    addItemRow.egCd = itemRow.IsegCdNull() ? string.Empty : itemRow.egCd;
                    addItemRow.tksKgyCd = itemRow.IstksKgyCdNull() ? string.Empty : itemRow.tksKgyCd;
                    addItemRow.tksBmnSeqNo = itemRow.IstksBmnSeqNoNull() ? string.Empty : itemRow.tksBmnSeqNo;
                    addItemRow.tksTntSeqNo = itemRow.IstksTntSeqNoNull() ? string.Empty : itemRow.tksTntSeqNo;
                    addItemRow.sybt = string.IsNullOrEmpty(itemRow.sybt) ? string.Empty : itemRow.sybt;

                    addItemRow.Column1 = itemRow.Isfield1Null() ? string.Empty : itemRow.field1;
                    addItemRow.Column2 = itemRow.Isfield2Null() ? string.Empty : itemRow.field2;
                    addItemRow.Column3 = itemRow.Isfield3Null() ? string.Empty : itemRow.field3;
                    addItemRow.Column4 = itemRow.Isfield4Null() ? string.Empty : itemRow.field4;
                    addItemRow.Column5 = itemRow.Isfield5Null() ? string.Empty : itemRow.field5;
                    addItemRow.Column6 = itemRow.Isfield6Null() ? string.Empty : itemRow.field6;
                    addItemRow.Column7 = itemRow.Isfield7Null() ? string.Empty : itemRow.field7;
                    addItemRow.Column8 = itemRow.Isfield8Null() ? string.Empty : itemRow.field8;
                    addItemRow.Column9 = itemRow.Isfield9Null() ? string.Empty : itemRow.field9;
                    addItemRow.Column10 = itemRow.Isfield10Null() ? string.Empty : itemRow.field10;
                    addItemRow.Column11 = itemRow.Isfield11Null() ? string.Empty : itemRow.field11;
                    addItemRow.Column12 = itemRow.Isfield12Null() ? string.Empty : itemRow.field12;
                    addItemRow.Column13 = itemRow.Isfield13Null() ? string.Empty : itemRow.field13;
                    addItemRow.Column14 = itemRow.Isfield14Null() ? string.Empty : itemRow.field14;
                    addItemRow.Column15 = itemRow.Isfield15Null() ? string.Empty : itemRow.field15;
                    addItemRow.Column16 = itemRow.Isfield16Null() ? string.Empty : itemRow.field16;
                    addItemRow.Column17 = itemRow.Isfield17Null() ? string.Empty : itemRow.field17;
                    addItemRow.Column18 = itemRow.Isfield18Null() ? string.Empty : itemRow.field18;
                    addItemRow.Column19 = itemRow.Isfield19Null() ? string.Empty : itemRow.field19;
                    addItemRow.Column20 = itemRow.Isfield20Null() ? string.Empty : itemRow.field20;
                    addItemRow.Column21 = itemRow.IsintValue1Null() ? string.Empty : itemRow.intValue1;
                    addItemRow.Column22 = itemRow.IsintValue2Null() ? string.Empty : itemRow.intValue2;
                    addItemRow.Column23 = itemRow.IsintValue3Null() ? string.Empty : itemRow.intValue3;
                    addItemRow.Column24 = itemRow.IsintValue4Null() ? string.Empty : itemRow.intValue4;
                    addItemRow.Column25 = itemRow.IsintValue5Null() ? string.Empty : itemRow.intValue5;
                    addItemRow.Column26 = itemRow.IsintValue6Null() ? string.Empty : itemRow.intValue6;
                    addItemRow.Column27 = itemRow.IsintValue7Null() ? string.Empty : itemRow.intValue7;
                    addItemRow.Column28 = itemRow.IsintValue8Null() ? string.Empty : itemRow.intValue8;
                    addItemRow.Column29 = itemRow.IsintValue9Null() ? string.Empty : itemRow.intValue9;
                    addItemRow.Column30 = itemRow.IsintValue10Null() ? string.Empty : itemRow.intValue10;

                    #endregion

                    //戻り値用DataTableへ行を追加.
                    mstDataVo.AddMasterDataVORow(addItemRow);
                }
            }
            else
            {
                //マスター名コンボボックスで「マスター定義」が選択されている場合.
                //一覧からマスター定義のDataTableを取得.
                MasterMaintenance.MasterKindVODataTable kindDataTable = new MasterMaintenance.MasterKindVODataTable();
                kindDataTable = (MasterMaintenance.MasterKindVODataTable)spdMasMainte_Sheet1.DataSource;

                //マスター定義の行数分繰り返す.
                foreach (MasterMaintenance.MasterKindVORow kindRow in kindDataTable.Rows)
                {
                    //新規行.
                    MasterMaintenance.MasterDataVORow addKindRow = mstDataVo.NewMasterDataVORow();

                    #region 新規行にマスター定義の値を設定.

                    //登録タイムスタンプがNullでない場合.
                    if (kindRow.IstrkTimStmpNull() == false)
                    {
                        //登録タイムスタンプがDateTime型に変換可能である場合.
                        DateTime parseTrkTimStmp = new DateTime();
                        if (DateTime.TryParse(kindRow.trkTimStmp, out parseTrkTimStmp) == true)
                        {
                            addKindRow.trkTimStmp = parseTrkTimStmp;
                        }
                    }

                    addKindRow.trkPl = kindRow.IstrkPlNull() ? string.Empty : kindRow.trkPl;
                    addKindRow.trkTnt = kindRow.IstrkTntNull() ? string.Empty : kindRow.trkTnt;

                    //更新タイムスタンプがNullでない場合.
                    if (kindRow.IsupdTimStmpNull() == false)
                    {
                        //更新タイムスタンプがDateTime型に変換可能である場合.
                        DateTime parseUpdTimStmp = new DateTime();
                        if (DateTime.TryParse(kindRow.updTimStmp, out parseUpdTimStmp) == true)
                        {
                            addKindRow.updTimStmp = parseUpdTimStmp;
                        }
                    }

                    addKindRow.updaPl = kindRow.IsupdaPlNull() ? string.Empty : kindRow.updaPl;
                    addKindRow.updTnt = kindRow.IsupdTntNull() ? string.Empty : kindRow.updTnt;
                    addKindRow.egCd = kindRow.IsegCdNull() ? string.Empty : kindRow.egCd;
                    addKindRow.tksKgyCd = kindRow.IstksKgyCdNull() ? string.Empty : kindRow.tksKgyCd;
                    addKindRow.tksBmnSeqNo = kindRow.IstksBmnSeqNoNull() ? string.Empty : kindRow.tksBmnSeqNo;
                    addKindRow.tksTntSeqNo = kindRow.IstksTntSeqNoNull() ? string.Empty : kindRow.tksTntSeqNo;
                    addKindRow.sybt = string.IsNullOrEmpty(kindRow.sybt) ? string.Empty : kindRow.sybt;
                    addKindRow.Column1 = kindRow.Isfield1Null() ? string.Empty : kindRow.field1;
                    addKindRow.Column2 = kindRow.Isfield2Null() ? string.Empty : kindRow.field2;
                    addKindRow.Column3 = kindRow.Isfield3Null() ? string.Empty : kindRow.field3;
                    addKindRow.Column4 = kindRow.Isfield4Null() ? string.Empty : kindRow.field4;
                    addKindRow.Column5 = kindRow.Isfield5Null() ? string.Empty : kindRow.field5;
                    addKindRow.Column6 = kindRow.Isfield6Null() ? string.Empty : kindRow.field6;
                    addKindRow.Column7 = kindRow.Isfield7Null() ? string.Empty : kindRow.field7;
                    addKindRow.Column8 = kindRow.Isfield8Null() ? string.Empty : kindRow.field8;
                    addKindRow.Column9 = kindRow.Isfield9Null() ? string.Empty : kindRow.field9;
                    addKindRow.Column10 = kindRow.Isfield10Null() ? string.Empty : kindRow.field10;
                    addKindRow.Column11 = kindRow.Isfield11Null() ? string.Empty : kindRow.field11;
                    addKindRow.Column12 = kindRow.Isfield12Null() ? string.Empty : kindRow.field12;
                    addKindRow.Column13 = kindRow.Isfield13Null() ? string.Empty : kindRow.field13;
                    addKindRow.Column14 = kindRow.Isfield14Null() ? string.Empty : kindRow.field14;
                    addKindRow.Column15 = kindRow.Isfield15Null() ? string.Empty : kindRow.field15;
                    addKindRow.Column16 = kindRow.Isfield16Null() ? string.Empty : kindRow.field16;
                    addKindRow.Column17 = kindRow.Isfield17Null() ? string.Empty : kindRow.field17;
                    addKindRow.Column18 = kindRow.Isfield18Null() ? string.Empty : kindRow.field18;
                    addKindRow.Column19 = kindRow.Isfield19Null() ? string.Empty : kindRow.field19;
                    addKindRow.Column20 = kindRow.Isfield20Null() ? string.Empty : kindRow.field20;
                    addKindRow.Column21 = kindRow.IsintValue1Null() ? string.Empty : kindRow.intValue1;
                    addKindRow.Column22 = kindRow.IsintValue2Null() ? string.Empty : kindRow.intValue2;
                    addKindRow.Column23 = kindRow.IsintValue3Null() ? string.Empty : kindRow.intValue3;
                    addKindRow.Column24 = kindRow.IsintValue4Null() ? string.Empty : kindRow.intValue4;
                    addKindRow.Column25 = kindRow.IsintValue5Null() ? string.Empty : kindRow.intValue5;
                    addKindRow.Column26 = kindRow.IsintValue6Null() ? string.Empty : kindRow.intValue6;
                    addKindRow.Column27 = kindRow.IsintValue7Null() ? string.Empty : kindRow.intValue7;
                    addKindRow.Column28 = kindRow.IsintValue8Null() ? string.Empty : kindRow.intValue8;
                    addKindRow.Column29 = kindRow.IsintValue9Null() ? string.Empty : kindRow.intValue9;
                    addKindRow.Column30 = kindRow.IsintValue10Null() ? string.Empty : kindRow.intValue10;

                    #endregion

                    //戻り値用DataTableへ行を追加.
                    mstDataVo.AddMasterDataVORow(addKindRow);
                }

            }

            return mstDataVo;
        }
        #endregion 型変換.

        #region 背景の初期化.
        /// <summary>
        /// 背景の初期化.
        /// </summary>
        private void BackColorSyokika()
        {
            //コントロール変更に対する更新の保留.
            spdMasMainte.SuspendLayout();

            //Row最大行.
            int rowCount = spdMasMainte_Sheet1.Rows.Count;

            //スプレッドのカラム数分ループ処理.
            for (int i = 0; i < SpColNum; i++)
            {
                //一覧行数分ループ処理.
                for (int rowIndex = 0; rowIndex < spdMasMainte_Sheet1.Rows.Count; rowIndex++)
                {
                    //背景色が[白]以外の場合.
                    if (spdMasMainte_Sheet1.Cells[rowIndex, i].BackColor != Color.White)
                    {
                        //背景色を[白]に設定する.
                        spdMasMainte_Sheet1.Cells[rowIndex, i].BackColor = Color.White;
                    }
                }

                spdMasMainte_Sheet1.Columns[i].Locked = false;
            }

            //コントロール変更に対する更新の保留解除.
            spdMasMainte.ResumeLayout();
        }
        #endregion 背景の初期化.

        #region エディットチェンジ.
        /// <summary>
        /// エディットチェンジ.
        /// </summary>
        protected virtual void EditChange(EditorNotifyEventArgs e)
        {
            //初期設定.
            upchk = true;

            //テキストタイプの場合.
            if (spdMasMainte_Sheet1.Columns[e.Column].CellType is TextCellType)
            {
                TextCellType tc = (TextCellType)spdMasMainte_Sheet1.Columns[e.Column].CellType;
                string s = e.EditingControl.Text;
                if (_enc.GetByteCount(s) > tc.MaxLength)
                {
                    e.EditingControl.Text = _enc.GetString(_enc.GetBytes(s), 0, tc.MaxLength);
                    ((GeneralEditor)e.EditingControl).SelectionStart = e.EditingControl.Text.Length;
                }
            }

            //コンボボックスの場合.
            if (spdMasMainte_Sheet1.Columns[e.Column].CellType is ComboBoxCellType)
            {
                drMasterItem[] itemrow = (drMasterItem[])mstDtSet.MasterDataSet.MasterItemVO.Select("field1 = " + mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3 + " AND " + "INTVALUE1 NOT IN (0) ");

                foreach (drMasterItem row in itemrow)
                {
                    //編集されているコンボボックスが、表示非表示元対象の場合.
                    if (spdMasMainte_Sheet1.ColumnHeader.Columns[e.Column].Label.Equals("業務区分") || spdMasMainte_Sheet1.ColumnHeader.Columns[e.Column].Label.Equals("国際区分"))
                    {
                        //[業務区分]列Index.
                        int gyomColIdx = -1;
                        //[国際区分]列Index.
                        int kokuColIdx = -1;

                        //クリックした列が[業務区分]の場合.
                        if (spdMasMainte_Sheet1.ColumnHeader.Columns[e.Column].Label.Equals("業務区分"))
                        {
                            //[業務区分]列Indexを取得.
                            gyomColIdx = spdMasMainte_Sheet1.Columns[e.Column].Index;
                            //[国際区分]の列Indexを取得.
                            kokuColIdx = spdMasMainte_Sheet1.Columns[e.Column].Index + 1;
                        }
                        //クリックした列が[国際区分]の場合.
                        else if (spdMasMainte_Sheet1.ColumnHeader.Columns[e.Column].Label.Equals("国際区分"))
                        {
                            //[業務区分]列Indexを取得.
                            gyomColIdx = spdMasMainte_Sheet1.Columns[e.Column].Index - 1;
                            //[国際区分]の列Indexを取得.
                            kokuColIdx = spdMasMainte_Sheet1.Columns[e.Column].Index;
                        }

                        //変更元の値（ラジオか衛星メディア）.
                        string[] MotValue = row.field18.Split(',');

                        //[業務区分][国際区分]列を変更した場合.
                        if (gyomColIdx > -1 || kokuColIdx > -1)
                        {
                            //編集不可.
                            spdMasMainte_Sheet1.Cells[e.Row, int.Parse(row.field2)].Locked = true;
                            //背景色を黒.
                            spdMasMainte_Sheet1.Cells[e.Row, int.Parse(row.field2)].BackColor = Color.Black;
                            //フォーカス不可.
                            spdMasMainte_Sheet1.Cells[e.Row, int.Parse(row.field2)].CanFocus = false;
                            //項目を空を選択. 
                            spdMasMainte_Sheet1.Cells[e.Row, int.Parse(row.field2)].Value = string.Empty;

                            for (int i = 0; i < MotValue.Length; i++)
                            {
                                //[ラジオ]か[衛星メディア]を選択した場合.
                                if (spdMasMainte_Sheet1.Cells[e.Row, gyomColIdx].Value.Equals(MotValue[i]))
                                {
                                    //[国際区分]列がある場合.
                                    if (spdMasMainte_Sheet1.ColumnHeader.Columns[kokuColIdx].Label.Equals("国際区分"))
                                    {
                                        //[タイムスポット区分]が[国内]の場合.
                                        if (spdMasMainte_Sheet1.Cells[e.Row, kokuColIdx].Value.Equals("国内"))
                                        {
                                            //タイムスポット区分初期化.
                                            //編集可.
                                            spdMasMainte_Sheet1.Cells[e.Row, int.Parse(row.field2)].Locked = false;
                                            //背景色を白.
                                            spdMasMainte_Sheet1.Cells[e.Row, int.Parse(row.field2)].BackColor = Color.White;
                                            //フォーカス可.
                                            spdMasMainte_Sheet1.Cells[e.Row, int.Parse(row.field2)].CanFocus = true;
                                        }
                                    }
                                    //[国際区分]列が無い場合.
                                    else
                                    {
                                        //タイムスポット区分初期化.
                                        //編集可.
                                        spdMasMainte_Sheet1.Cells[e.Row, int.Parse(row.field2)].Locked = false;
                                        //背景色を白.
                                        spdMasMainte_Sheet1.Cells[e.Row, int.Parse(row.field2)].BackColor = Color.White;
                                        //フォーカス可.
                                        spdMasMainte_Sheet1.Cells[e.Row, int.Parse(row.field2)].CanFocus = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion エディットチェンジ.
        #endregion メソッド.
    }
}