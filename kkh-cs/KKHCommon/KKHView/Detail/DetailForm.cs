using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using Isid.NJSecurity.Core;

using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHView.Common.Control;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using Isid.KKH.Common.KKHServiceProxy;

namespace Isid.KKH.Common.KKHView.Detail
{
    /// <summary>
    /// 広告費明細入力画面 
    /// </summary>
    public partial class DetailForm : KKHForm
    {
        #region 構造体
        #endregion 構造体
        #region メンバ変数
        /// <summary>
        /// 広告費明細入力パラメータクラス 
        /// (引き渡された値をそのまま保持し、原則使用しない) 
        /// </summary>
        private KKHNaviParameter _naviParameterIn;

        /// <summary>
        /// 広告費明細入力パラメータクラス 
        /// </summary>
        private KKHNaviParameter _naviParameter;

        /// <summary>
        /// 受注登録内容検索実行時の設定条件を保持 
        /// </summary>
        protected DetailProcessController.FindJyutyuDataByCondParam findJyutyuDataCond = new DetailProcessController.FindJyutyuDataByCondParam();

        /// <summary>
        /// 検索時の年月を保持 
        /// </summary>
        private string saveSrcYm;

        /// <summary>
        /// 検索時の終了年月を保持 
        /// </summary>
        private string saveSrcYmTo;

        #region フラグ関係
        /// <summary>
        /// 広告費明細の編集中かを判定するフラグ(True：編集中、False：未編集) 
        /// </summary>
        protected bool kkhDetailUpdFlag = false;

        /// <summary>
        /// 広告費明細検索を行うイベントを管理するフラグ 
        /// (1:SelectionChangedイベント、2:EnterCellイベント)
        /// </summary>
        private string kkhDetailSearchEvent = string.Empty;
        /// <summary>
        /// アクティブなスプレッドビューが変更されたかを判別するフラグ 
        /// </summary>
        private bool actSpdViewChangeFlag = false;

        /// <summary>
        /// 広告費明細検索保留ステータス
        /// </summary>
        private Boolean detailSearchSuspendState = false;

        /// <summary>
        /// ステータスの取得のみ許可
        /// </summary>
        protected Boolean DetailSearchSuspendState
        {
            get { return detailSearchSuspendState; }
        }

        /// <summary>
        /// 編集内容破棄ステータス
        /// </summary>
        private Boolean confirmEditState = false;

        /// <summary>
        /// ステータスの取得のみ許可
        /// </summary>
        protected Boolean ConfirmEditState
        {
            get { return confirmEditState; }
        }

        #endregion フラグ関係
        #endregion メンバ変数

        #region プロパティ

        /// <summary>
        /// 受注登録内容検索時の条件を取得します。 
        /// </summary>
        public DetailProcessController.FindJyutyuDataByCondParam FindJyutyuDataCond
        {
            get { return findJyutyuDataCond; }
        }

        private string _aplId = "";
        /// <summary>
        /// 機能IDを取得、または設定します 
        /// </summary>
        [Category("KKH_DETAIL")]
        [Browsable(true)]
        [Description("機能IDを取得、または設定します")]
        public string AplId
        {
            set { _aplId = value; }
            get { return _aplId; }
        }

        /// <summary>
        /// 受注登録内容スプレッドを取得します。 
        /// </summary>
        public KkhSpread spdJyutyuList
        {
            //set { _spdJyutyuList = value; }
            get { return _spdJyutyuList; }
        }

        /// <summary>
        /// 受注登録内容スプレッドシートを取得します。 
        /// </summary>
        public SheetView _spdJyutyuList_Sheet1
        {
            //set { __spdJyutyuList_Sheet1 = value; }
            get { return __spdJyutyuList_Sheet1; }
        }

        /// <summary>
        /// 受注登録内容検索時の年月を取得します。 
        /// </summary>
        public string SaveSrcYymm
        {
            set { saveSrcYm = value; }
            get { return saveSrcYm; }
        }

        /// <summary>
        /// 受注登録内容検索時の終了年月を取得します。 
        /// </summary>
        public string SaveSrcYymmTo
        {
            set { saveSrcYmTo = value; }
            get { return saveSrcYmTo; }
        }
        #endregion プロパティ

        #region 定数

        #region 受注登録内容(一覧)カラムインデックス
        /// <summary>
        /// 受変列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_JHENKOU = 0;                   //受注変更 
        /// <summary>
        /// 登録列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_TOROKU = 1;                    //登録  
        /// <summary>
        /// 統合列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_TOGO = 2;                      //統合 
        /// <summary>
        /// 代受列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_DAIUKE = 3;                    //代受 
        /// <summary>
        /// 請求列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_SEIKYU = 4;                    //請求 
        /// <summary>
        /// 売上明細NO列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_URIMEINO = 5;                  //売上明細NO 
        /// <summary>
        /// 請求原票NO列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_GPYNO = 6;                  　 //請求原票NO 
        /// <summary>
        /// 請求年月列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_SEIYYMM = 7;                   //請求年月 
        /// <summary>
        /// 業務区分列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_GYOMKBN = 8;                   //業務区分 
        /// <summary>
        /// 件名列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_KENMEI = 9;                    //件名 
        /// <summary>
        /// 費目名列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_HIMOKUNM = 10;                 //費目名 
        /// <summary>
        /// 媒体名列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_BAITAINM = 11;                 //媒体名 
        /// <summary>
        /// 局誌CD列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_KYOKUSHICD = 12;               //局誌CD 
        /// <summary>
        /// 請求金額列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_SEIKINGAKU = 13;               //請求金額 
        /// <summary>
        /// 期間列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_KIKAN = 14;                    //期間 
        /// <summary>
        /// 段単価列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_DANTANKA = 15;                 //段単価 
        /// <summary>
        /// 段数列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_DANSU = 16;                    //段数 
        /// <summary>
        /// 取料金列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_TORIRYOKIN = 17;               //取料金 
        /// <summary>
        /// 値引率列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_NEBIKIRITSU = 18;              //値引率 
        /// <summary>
        /// 値引額列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_NEBIKIGAKU = 19;               //値引額 
        /// <summary>
        /// 消費税率列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_ZEIRITSU = 20;                 //消費税率 
        /// <summary>
        /// 消費税額列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_ZEIGAKU = 21;                  //消費税額 
        /// <summary>
        /// 受注請求金額列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_GOUKEIKINGAKU = 22;            //受注請求金額 
        /// <summary>
        /// 変更前請求年月列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_OLDSEIYYMM = 23;               //変更前請求年月 
        /// <summary>
        /// 登録者列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_TRKTNT = 24;                   //登録者 
        /// <summary>
        /// 更新者列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_UPDTNT = 25;                   //更新者  
        /// <summary>
        /// 行番号列インデックス 
        /// </summary>
        protected const int COLIDX_JLIST_ROWNUM = 26;                   //行番号 
        #endregion 受注登録内容(一覧)カラムインデックス


        #region 受注履歴カラムインデックス
        /// <summary>
        /// 明細作成有無列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_DTLTOROKU = 0;                 //明細作成有無 
        /// <summary>
        /// ダウンロードタイミング列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_DOWNDATETIME = 1;              //登録 
        /// <summary>
        /// 売上明細NO列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_URIMEINO = 2;                  //売上明細NO 
        /// <summary>
        /// 請求年月列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_SEIYYMM = 3;                   //請求年月 
        /// <summary>
        /// 業務区分列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_GYOMKBN = 4;                   //業務区分 
        /// <summary>
        /// 件名列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_KENMEI = 5;                    //件名 
        /// <summary>
        /// 媒体名列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_BAITAINM = 6;                  //媒体名 
        /// <summary>
        /// 費目名列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_HIMOKUNM = 7;                  //費目名 
        /// <summary>
        /// 局誌CD列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_KYOKUSHICD = 8;                //局誌CD 
        /// <summary>
        /// 請求金額列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_SEIKINGAKU = 9;                //請求金額 
        /// <summary>
        /// 期間列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_KIKAN = 10;                    //期間 
        /// <summary>
        /// 段単価列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_DANTANKA = 11;                 //段単価 
        /// <summary>
        /// 段数列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_DANSU = 12;                    //段数 
        /// <summary>
        /// 取料金列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_TORIRYOKIN = 13;               //取料金 
        /// <summary>
        /// 値引率列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_NEBIKIRITSU = 14;              //値引率 
        /// <summary>
        /// 値引額列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_NEBIKIGAKU = 15;               //値引額 
        /// <summary>
        /// 消費税率列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_ZEIRITSU = 16;                 //消費税率 
        /// <summary>
        /// 消費税額列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_ZEIGAKU = 17;                  //消費税額 
        /// <summary>
        /// 受注請求金額列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_GOUKEIKINGAKU = 18;            //受注請求金額 
        /// <summary>
        /// 変更前請求年月列インデックス 
        /// </summary>
        protected const int COLIDX_JRIREKI_OLDSEIYYMM = 19;               //変更前請求年月 
        #endregion 受注履歴カラムインデックス

        #endregion 定数

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public DetailForm()
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
        private void DetailForm_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParameterIn = (KKHNaviParameter)arg.NaviParameter;

                _naviParameter = new KKHNaviParameter();
                _naviParameter.strEsqId = _naviParameterIn.strEsqId;
                _naviParameter.strEgcd = _naviParameterIn.strEgcd;
                _naviParameter.strTksKgyCd = _naviParameterIn.strTksKgyCd;
                _naviParameter.strTksBmnSeqNo = _naviParameterIn.strTksBmnSeqNo;
                _naviParameter.strTksTntSeqNo = _naviParameterIn.strTksTntSeqNo;
                _naviParameter.strTksKgyName = _naviParameterIn.strTksKgyName;
                _naviParameter.strDate = _naviParameterIn.strDate;
                _naviParameter.strName = _naviParameterIn.strName;
            }
        }

        /// <summary>
        /// フォームが初めて表示されるたびに発生します。 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailForm_Shown(object sender, EventArgs e)
        {
            //継承先のフォームデザイナ表示ができるようにデザイナモード時には何もしない 
            if (DesignMode == true) { return; }

            InitializeDataSource(); //データソースのバインド処理 
            InitializeControl();
            InitializeDesignForSpdJyutyuList();
        }

        /// <summary>
        /// 国際区分(国内)チェックボックスのチェックON/OFF変更 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkJpn_CheckedChanged(object sender, EventArgs e)
        {
            ChangeVisibleSearchCond();
        }

        /// <summary>
        /// 業務区分コンボボックス選択イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGymKbn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeVisibleSearchCond();
        }

        /// <summary>
        /// 受注NoのKeyPressイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtJyuNoo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //入力禁止文字の判定 
            if (e.KeyChar.Equals('\''))
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// 検索ボタンクリック 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSch_Click(object sender, EventArgs e)
        {
            //if (_naviParameter.strTksKgyCd == "400702")
            //{
            //    base.ShowLoadingDialog2();
            //    SearchJyutyuData();
            //    //System.Threading.Thread.Sleep(10000);
            //    base.CloseLoadingDialog2();
            //}
            //else
            //{
            //    base.ShowLoadingDialog();
            //    SearchJyutyuData();
            //    //System.Threading.Thread.Sleep(10000);
            //    base.CloseLoadingDialog();
            //}
            base.ShowLoadingDialog();

            //親シートを活性化する 
            SetActiveParentWorkBook();

            //年月を保持する 
            SaveSrcYymm = txtYmd.Value;

            if (txtYmdTo.Visible)
            {
                //終了年月を保持する 
                SaveSrcYymmTo = txtYmdTo.Value;
            }

            SearchJyutyuData();

            //コントロールの指定を無くす 
            this.ActiveControl = null;

            base.CloseLoadingDialog();
        }

        /// <summary>
        /// 受注登録内容タブ変更中イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabHed_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                if (_spdJyutyuList_Sheet1.Rows.Count <= 0)
                {
                    //表示データがない場合はタブページ変更をキャンセル 
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 受注登録内容タブ変更後イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void tabHed_SelectedIndexChanged(object sender, EventArgs e)
        {
            //詳細タブが選択された場合 
            if (tabHed.SelectedIndex == 1)
            {
                SheetView activeSheetView = GetActiveSheetViewBySpdJyutyuList();
                int rowIndex = activeSheetView.ActiveRowIndex;
                int rowNo = (int)activeSheetView.Cells[rowIndex, COLIDX_JLIST_ROWNUM].Value;
                KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(rowNo);

                InitializeDesignForSpdJyutyuDetail(dataRow.hb1SeiKbn);
                if (dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.NewsPaper)
                {
                    lblSeiKbnNm.Text = "新聞データ";
                }
                else if (dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Magazine)
                {
                    lblSeiKbnNm.Text = "雑誌データ";
                }
                else if (dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Time)
                {
                    lblSeiKbnNm.Text = "タイムデータ";
                }
                else if (dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Spot)
                {
                    lblSeiKbnNm.Text = "スポットデータ";
                }
                else if (dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Works)
                {
                    lblSeiKbnNm.Text = "諸作業データ";
                }
                else if (dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Ooh)
                {
                    lblSeiKbnNm.Text = "交通広告データ";
                }
                else if (dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.KMas)
                {
                    lblSeiKbnNm.Text = "国際/マスデータ";
                }
                else if (dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.KWorks)
                {
                    lblSeiKbnNm.Text = "国際/諸作業データ";
                }
                else if (dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.IC)
                {
                    lblSeiKbnNm.Text = "IC(インタラクティブメディア)";
                }
                UpdateSpdJyutyuDetail(rowNo);

                //件数表示を非表示にする 
                lblJyutyuListCnt.Visible = false;

                //********************************************
                //履歴一覧表示 
                //********************************************

                //列表示の制御を行う 
                VisibleColumnsForJyutyuRireki();

                //SheetView activeSheetView = GetActiveSheetViewBySpdJyutyuList();
                //int rowIndex = activeSheetView.ActiveRowIndex;
                //int rowNo = (int)activeSheetView.Cells[rowIndex, COLIDX_JLIST_ROWNUM].Value;
                //KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(rowNo);

                DetailProcessController.FindJyutyuRirekiDataByCondParam param = new DetailProcessController.FindJyutyuRirekiDataByCondParam();
                param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
                param.egCd = dataRow.hb1EgCd;
                param.tksKgyCd = dataRow.hb1TksKgyCd;
                param.tksBmnSeqNo = dataRow.hb1TksBmnSeqNo;
                param.tksTntSeqNo = dataRow.hb1TksTntSeqNo;
                param.yymm = dataRow.hb1Yymm;
                param.jyutNo = dataRow.hb1JyutNo;
                param.jyMeiNo = dataRow.hb1JyMeiNo;
                param.urMeiNo = dataRow.hb1UrMeiNo;

                DetailProcessController processController = DetailProcessController.GetInstance();
                FindJyutyuRirekiDataByCondServiceResult result = processController.FindJyutyuRirekiDataByCond(param);

                //受注ダウンロード履歴のソートインジケータ初期化 
                _spdJyutyuRireki_Sheet1.Models.ResetViewRowIndexes();

                foreach( FarPoint.Win.Spread.Column column in _spdJyutyuRireki_Sheet1.Columns )
                {
                    column.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
                }

                _dsDetail.THB8DOWNR.Clear();
                _dsDetail.THB8DOWNR.Merge(result.DetailDataSet.THB8DOWNR);

                _dsDetail.UpdateJyutyuRirekiByDOWNR();

                //件数表示を非表示にする  
                lblJyutyuListCnt.Visible = false;
            }
            else
            {
                //件数表示を表示にする  
                lblJyutyuListCnt.Visible = true;
            }
        }

        /// <summary>
        /// 受注登録内容(一覧)スプレッドの選択範囲変更中イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _spdJyutyuList_SelectionChanging(object sender, SelectionChangingEventArgs e)
        {
            // 明細入力チェック 
            if (IsInputDetail(e.Range.RowCount) == true)
            {
                // イベントをキャンセル 
                e.Cancel = true;
            }
            else
            {
                // 広告費明細フラグに"1"を設定 
                kkhDetailSearchEvent = "1";
            }
        }

        /// <summary>
        /// 受注登録内容(一覧)スプレッドの選択範囲変更後イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdJyutyuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_spdJyutyuList_Sheet1.RowCount > 0 && kkhDetailSearchEvent == "1")
            {
                kkhDetailSearchEvent = string.Empty;
                SheetView activeSheet = GetActiveSheetViewBySpdJyutyuList();

                int rowIdx = SetRowIndex(activeSheet, activeSheet.ActiveRowIndex);

                DisplayKkhDetail(rowIdx);
                //DisplayKkhDetail(activeSheet.ActiveRowIndex);
                //移動後のシートによってボタン等のEnableを変更 
                EnableChangeForSelectJyutyuListRow(activeSheet, rowIdx);
                //EnableChangeForSelectJyutyuListRow(activeSheet, activeSheet.ActiveRowIndex);
            }
        }

        /// <summary>
        /// 受注登録内容(一覧)スプレッドのセル移動時イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdJyutyuList_LeaveCell(object sender, LeaveCellEventArgs e)
        {
            _spdJyutyuList_LeaveCell(sender,e);
        }

        /// <summary>
        /// 受注登録内容(一覧)スプレッドのオートフィルター操作後イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdJyutyuList_AutoFilteredColumn(object sender, AutoFilteredColumnEventArgs e)
        {
            //********************************
            //カーソル初期位置の設定 
            //********************************
            int initActiveRowIdx = 0;
            int[] inRowsIdxs = e.Sheet.RowFilter.GetIntersectedFilteredInRows();
            if (inRowsIdxs != null)
            {
                initActiveRowIdx = inRowsIdxs[0];
            }
            e.Sheet.SetActiveCell(initActiveRowIdx, 0, true);
            e.Sheet.AddSelection(initActiveRowIdx, -1, 1, -1);
            //******************************
            //広告費明細 
            //******************************
            DisplayKkhDetail(e.Sheet.ActiveRowIndex);
            //ボタン等の切り換え 
            EnableChangeForSelectJyutyuListRow(e.Sheet, e.Sheet.ActiveRowIndex);
        }

        //bool sortResetFlag = false;
        
        /// <summary>
        /// 受注登録内容(一覧)スプレッドのオートソート操作後イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdJyutyuList_AutoSortedColumn(object sender, AutoSortedColumnEventArgs e)
        {
            //********************************
            //カーソル初期位置の設定 
            //********************************
            if (_spdJyutyuList_Sheet1.RowCount > 0)
            {
                _spdJyutyuList_Sheet1.SetActiveCell(0, 0, true);
                _spdJyutyuList_Sheet1.AddSelection(0, -1, 1, -1);
                //******************************
                //広告費明細 
                //******************************
                DisplayKkhDetail(e.Sheet.ActiveRowIndex);
                //ボタン等の切り換え 
                EnableChangeForSelectJyutyuListRow(e.Sheet, e.Sheet.ActiveRowIndex);
            }
        }

        /// <summary>
        /// 受注登録内容(一覧)スプレッドのセルクリックイベント  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdJyutyuList_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.ColumnHeader == true)
            {
                e.Cancel = true;
                return;
            }

        }

        /// <summary>
        /// 受注登録内容(一覧)スプレッドのセルダブルクリックイベント  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdJyutyuList_DoubleClick(object sender, CellClickEventArgs e)
        {
            if (e.ColumnHeader == true)
            {
                e.Cancel = true;
                return;
            }
        }

        /// <summary>
        /// 戻るボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            //*************************
            //広告費明細の編集状況確認 
            //*************************
            if (ConfirmEditStatus() == false)
            {
                return;
            }
            Navigator.Backward(this, null, _naviParameterIn, true);
        }

        /// <summary>
        /// 受注削除ボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelJyutyu_Click(object sender, EventArgs e)
        {

            DelJyutyuClick();

            //コントロールを未選択状態にする 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 年月変更ボタンクリック 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYmChange_Click(object sender, EventArgs e)
        {
            ChangeYmClick();

            //コントロールを未選択状態にする 
            this.ActiveControl = null;
        }

        /// <summary>
        /// 新規作成ボタンクリック 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegJyutyu_Click(object sender, EventArgs e)
        {
            //実行確認 
            if (DialogResult.OK != MessageUtility.ShowMessageBox(MessageCode.HB_C0018,
                null, "新規作成", MessageBoxButtons.OKCancel))
            {
                return;
            }

            RegJyutyuClick();

            //コントロールを未選択状態にする 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 受注統合ボタンクリック 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMerge_Click(object sender, EventArgs e)
        {
            //実行確認 
            if (DialogResult.OK != MessageUtility.ShowMessageBox(MessageCode.HB_C0022,
                null, "受注統合", MessageBoxButtons.OKCancel))
            {
                return;
            }

            MergeClick();

            //コントロールを未選択状態にする 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 統合解除ボタンクリック 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMergeCancel_Click(object sender, EventArgs e)
        {
            MergeCancelClick();

            //コントロールを未選択状態にする 
            this.ActiveControl = null;

        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdJyutyuList_ActiveSpreadViewChanged(object sender, EventArgs e)
        {
            //スプレッドシート変更フラグ 
            actSpdViewChangeFlag = true;

            //現在行の取得 
            int rowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;
            _spdJyutyuList_ActiveSpreadViewChanged(rowIdx);
        }
        
        /// <summary>
        /// ヘルプボタンクリック 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = _naviParameter.strTksKgyCd + _naviParameter.strTksBmnSeqNo + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Detail, this, HelpNavigator.KeywordIndex);

            this.ActiveControl = null;

        }

        /// <summary>
        /// 受注チェックボタンクリック 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateCheck_Click(object sender, EventArgs e)
        {
            ////*************************
            ////広告費明細の編集状況確認 
            ////*************************
            //if (!ConfirmEditStatus())
            //{
            //    this.ActiveControl = null;

            //    return;
            //}

            ////実行確認 
            //if (DialogResult.OK != MessageUtility.ShowMessageBox(MessageCode.HB_C0016, 
            //    null, "受注チェック", MessageBoxButtons.OKCancel))
            //{
            //    this.ActiveControl = null;

            //    return;
            //}

            //base.ShowLoadingDialog();

            //// 業務会計稼働状況チェック
            //bool accountOperationStatus = CheckAccountOperationStatus();
            
            //// 業務会計が稼働中の場合 
            //if (accountOperationStatus)
            //{
            //    // 受注チェック 
            //    CheckUpdate();
            //}

            ////コントロールを未選択状態にする 
            //this.ActiveControl = null;

            //base.CloseLoadingDialog();

            //受注チェック
            UpdateCheckClick();

            //コントロールを未選択状態にする 
            this.ActiveControl = null;
        }

        #endregion イベント
        #region 処理別

        #region 初期表示・設定
        /// <summary>
        /// 受注登録内容(一覧)スプレッドのスプレッド・シートの設定を行う
        /// </summary>
        protected virtual void InitDesignForSpdJyutyuListSpread()
        {
            ////※デザイナでの変更が子フォームのデザイナに反映されないことが多いのでここで設定する。 
            //_spdJyutyuList_Sheet1.RowHeaderVisible = true;
            //_spdJyutyuList_Sheet1.RowHeaderAutoText = HeaderAutoText.Blank;
        }

        /// <summary>
        /// 受注登録内容(一覧)スプレッドの列単位の設定を行う 
        /// </summary>
        protected virtual void InitDesignForSpdJyutyuListColumns(Column col)
        {

            //共通設定 
            //col.Locked = true;

            //列毎に異なる設定 
            if (col.Index == COLIDX_JLIST_TOROKU)
            {
            }
            else if (col.Index == COLIDX_JLIST_TOGO)
            {
            }
            else if (col.Index == COLIDX_JLIST_DAIUKE)
            {
            }
            else if (col.Index == COLIDX_JLIST_SEIKYU)
            {
            }
            else if (col.Index == COLIDX_JLIST_URIMEINO)
            {
            }
            else if (col.Index == COLIDX_JLIST_GPYNO)
            {
            }
            else if (col.Index == COLIDX_JLIST_SEIYYMM)
            {
            }
            else if (col.Index == COLIDX_JLIST_GYOMKBN)
            {
            }
            else if (col.Index == COLIDX_JLIST_KENMEI)
            {
            }
            else if (col.Index == COLIDX_JLIST_BAITAINM)
            {
            }
            else if (col.Index == COLIDX_JLIST_HIMOKUNM)
            {
            }
            else if (col.Index == COLIDX_JLIST_KYOKUSHICD)
            {
            }
            else if (col.Index == COLIDX_JLIST_SEIKINGAKU)
            {
            }
            else if (col.Index == COLIDX_JLIST_KIKAN)
            {
            }
            else if (col.Index == COLIDX_JLIST_DANTANKA)
            {
            }
            else if (col.Index == COLIDX_JLIST_DANSU)
            {
            }
            else if (col.Index == COLIDX_JLIST_TORIRYOKIN)
            {
            }
            else if (col.Index == COLIDX_JLIST_NEBIKIRITSU)
            {
            }
            else if (col.Index == COLIDX_JLIST_NEBIKIGAKU)
            {
            }
            else if (col.Index == COLIDX_JLIST_ZEIRITSU)
            {
            }
            else if (col.Index == COLIDX_JLIST_ZEIGAKU)
            {
            }
            else if (col.Index == COLIDX_JLIST_GOUKEIKINGAKU)
            {
            }
            else if (col.Index == COLIDX_JLIST_OLDSEIYYMM)
            {
            }
            else
            {
                //その他の列 
            }
        }

        /// <summary>
        /// 得意先別に表示対象外列の非表示処理を行う 
        /// (共通機能：なし) 
        /// </summary>
        protected virtual void VisibleColumns()
        {
        }

        /// <summary>
        /// データソースのバインド 
        /// </summary>
        private void InitializeDataSource()
        {
        }

        /// <summary>
        /// 各コントロールの初期表示処理 
        /// </summary>
        private void InitializeControl()
        {
            //検索条件部------------------------------------------------------------------------------------------------------------------------------------------------
            //*********************************
            //年月 
            //*********************************
            String hostDate = "";
            if (_naviParameter.strDate == null)
            {
                hostDate = getHostDate();
            }
            else
            {
                hostDate = _naviParameter.strDate;
            }
            if (hostDate != "")
            {
                hostDate = hostDate.Trim().Replace("/", "");
                if (hostDate.Trim().Length >= 6)
                {
                    txtYmd.Value = hostDate.Substring(0, 6);
                    txtYmdTo.Value = hostDate.Substring(0, 6);
                }
                else
                {
                    txtYmd.Value = hostDate;
                    txtYmdTo.Value = hostDate;
                }
                txtYmd.cmbYM_SetDate();
                txtYmdTo.cmbYM_SetDate();
            }


            //*********************************
            //国際区分 
            //*********************************
            chkJpn.Checked = true;//国内→チェックON
            chkKgi.Checked = true;//国際→チェックON

            //*********************************
            //業務区分コンボボックス 
            //*********************************
            CommonProcessController processController = CommonProcessController.GetInstance();
            FindCommonCodeMasterByCondServiceResult result = processController.FindCommonCodeMasterByCond(KKHSecurityInfo.GetInstance().UserEsqId, "87", hostDate);

            KKHSchema.Common.RcmnMeu29CCDataTable dsGyomKbn = new KKHSchema.Common.RcmnMeu29CCDataTable();
            KKHSchema.Common.RcmnMeu29CCRow addRow = dsGyomKbn.NewRcmnMeu29CCRow();
            dsGyomKbn.AddRcmnMeu29CCRow(addRow);//空行を追加 
            dsGyomKbn.Merge(result.CommonDataSet.RcmnMeu29CC);
            dsGyomKbn.AcceptChanges();

            cmbGymKbn.DisplayMember = dsGyomKbn.naiyJColumn.ColumnName;
            cmbGymKbn.ValueMember = dsGyomKbn.kyCdColumn.ColumnName;
            cmbGymKbn.DataSource = dsGyomKbn;

            //*********************************
            //受注No 
            //*********************************
            txtJyuNo.Text = string.Empty;

            //*********************************
            //件名 
            //*********************************
            txtKenMei.Text = string.Empty;

            //2013/3/16 jse okazaki 公文対応　Start
            SetLocation();
            //2013/3/16 jse okazaki 公文対応　End

            //受注登録内容------------------------------------------------------------------------------------------------------------------------------------------------

            //広告費明細--------------------------------------------------------------------------------------------------------------------------------------------------

            //ステータスバー----------------------------------------------------------------------------------------------------------------------------------------------
            tslName.Text = _naviParameter.strName;
            tslDate.Text = _naviParameter.strDate;

            //コントロールの活性・非活性 
            InitializeControlEnabled();

            //★これしかない？ 
            this.Controls.SetChildIndex(lblMask, 1);

        }

        /// <summary>
        /// 各コントロールの活性状態の初期設定 
        /// </summary>
        private void InitializeControlEnabled()
        {
            //ボタンの使用不可 
            btnYmChange.Enabled = false;
            btnDelJyutyu.Enabled = false;
            btnMerge.Enabled = false;
            btnMergeCancel.Enabled = false;
            btnRegJyutyu.Enabled = false;
            btnUpdateCheck.Enabled = false;
        }

        /// <summary>
        /// 受注登録内容(一覧)スプレッドのデザイン初期化 
        /// </summary>
        private void InitializeDesignForSpdJyutyuList()
        {
            //********************************
            //スプレッド全体の設定 
            //********************************
            InitDesignForSpdJyutyuListSpread();

            //********************************
            //列毎の設定 
            //********************************
            foreach (Column col in _spdJyutyuList_Sheet1.Columns)
            {
                InitDesignForSpdJyutyuListColumns(col);
            }

            //********************************
            //列の表示・非表示設定 
            //********************************
            VisibleColumns();

            //********************************
            //カーソル初期位置の設定 
            //********************************
            _spdJyutyuList_Sheet1.ActiveColumnIndex = -1;
            _spdJyutyuList_Sheet1.ActiveRowIndex = -1;
            if (_spdJyutyuList_Sheet1.RowCount > 0)
            {
                _spdJyutyuList_Sheet1.ActiveColumnIndex = 0;
                _spdJyutyuList_Sheet1.ActiveRowIndex = 0;
                _spdJyutyuList_Sheet1.AddSelection(0, 0, 1, 1);
                spdJyutyuList.ShowActiveCell(VerticalPosition.Top, HorizontalPosition.Left);
            }
        }

        /// <summary>
        /// 受注登録内容(一覧)スプレッドの子ビューのデザイン初期化 
        /// </summary>
        private void InitDesignForSpdJyutyuListChild()
        {
            FarPoint.Win.Spread.SheetView s;
            for (int i = 0; i <= _spdJyutyuList_Sheet1.RowCount - 1; i++)
            {
                //各親行に関連する子ビューを取得します 
                s = _spdJyutyuList_Sheet1.GetChildView(i, 0);
                if (s.RowCount == 0)
                {
                    //子ビュー上の行数が０の場合は展開不可とします 
                    _spdJyutyuList_Sheet1.SetRowExpandable(i, false);

                }
                else
                {
                    s.SheetName = "JyutyuListChild";
                    s.SelectionPolicy = SelectionPolicy.Single;
                    s.SelectionUnit = SelectionUnit.Row;
                    s.OperationMode = OperationMode.SingleSelect;
                    s.RowHeaderAutoText = HeaderAutoText.Blank;
                    s.ColumnHeader.Rows[0].Height = _spdJyutyuList_Sheet1.ColumnHeader.Rows[0].Height;
                    s.DataAutoSizeColumns = _spdJyutyuList_Sheet1.DataAutoSizeColumns;
                    s.DataAutoCellTypes = _spdJyutyuList_Sheet1.DataAutoCellTypes;
                    s.ActiveSkin = _spdJyutyuDetail_Sheet1.ActiveSkin;
                    s.DefaultStyle.BackColor = _spdJyutyuDetail_Sheet1.DefaultStyle.BackColor;
                    //********************************
                    //列毎の設定 
                    //********************************
                    foreach (Column col in s.Columns)
                    {
                        //列毎に異なる設定 
                        if (col.Index < _spdJyutyuList_Sheet1.Columns.Count)
                        {
                            col.Locked = _spdJyutyuList_Sheet1.Columns[col.Index].Locked;
                            col.Label = _spdJyutyuList_Sheet1.Columns[col.Index].Label;
                            col.Width = _spdJyutyuList_Sheet1.Columns[col.Index].Width;
                            col.Visible = _spdJyutyuList_Sheet1.Columns[col.Index].Visible;
                            col.CellType = _spdJyutyuList_Sheet1.Columns[col.Index].CellType;
                            col.HorizontalAlignment = _spdJyutyuList_Sheet1.Columns[col.Index].HorizontalAlignment;
                            col.VerticalAlignment = _spdJyutyuList_Sheet1.Columns[col.Index].VerticalAlignment;
                            col.DataField = _spdJyutyuList_Sheet1.Columns[col.Index].DataField;
                        }
                        else
                        {
                            //その他の列 
                            col.Visible = false;
                        }
                    }
                 
                }
                
            }
        }

        /// <summary>
        /// 受注登録内容(詳細)スプレッドのデザイン初期化 
        /// </summary>
        private void InitializeDesignForSpdJyutyuDetail(string seiKbn)
        {
            //********************************
            //スプレッド全体の設定 
            //********************************

            //********************************
            //列毎の設定 
            //********************************
            //foreach (Column col in _spdJyutyuDetail_Sheet1.Columns)
            //{
            //}

            //********************************
            //行毎の設定 
            //********************************
            if (seiKbn == KKHSystemConst.SeiKbn.NewsPaper)
            {
                //新聞データ 
                _spdJyutyuDetail_Sheet1.Rows.Count = 9;
                _spdJyutyuDetail_Sheet1.Rows[0].Label = "媒体コード";
                _spdJyutyuDetail_Sheet1.Rows[1].Label = "媒体名";
                _spdJyutyuDetail_Sheet1.Rows[2].Label = "掲載日";
                _spdJyutyuDetail_Sheet1.Rows[3].Label = "朝夕区分";
                _spdJyutyuDetail_Sheet1.Rows[4].Label = "掲載版";
                _spdJyutyuDetail_Sheet1.Rows[5].Label = "記雑区分";
                _spdJyutyuDetail_Sheet1.Rows[6].Label = "掲載面";
                _spdJyutyuDetail_Sheet1.Rows[7].Label = "スペース";
                _spdJyutyuDetail_Sheet1.Rows[8].Label = "掲載期間";
            }
            else if (seiKbn == KKHSystemConst.SeiKbn.Magazine)
            {
                //雑誌データ 
                _spdJyutyuDetail_Sheet1.Rows.Count = 8;
                _spdJyutyuDetail_Sheet1.Rows[0].Label = "媒体コード";
                _spdJyutyuDetail_Sheet1.Rows[1].Label = "媒体名";
                _spdJyutyuDetail_Sheet1.Rows[2].Label = "発売日";
                _spdJyutyuDetail_Sheet1.Rows[3].Label = "掲載号";
                _spdJyutyuDetail_Sheet1.Rows[4].Label = "掲載種別";
                _spdJyutyuDetail_Sheet1.Rows[5].Label = "掲載条件";
                _spdJyutyuDetail_Sheet1.Rows[6].Label = "スペース";
                _spdJyutyuDetail_Sheet1.Rows[7].Label = "掲載期間";

            }
            else if (seiKbn == KKHSystemConst.SeiKbn.Time)
            {
                //タイムデータ 
                _spdJyutyuDetail_Sheet1.Rows.Count = 8;
                _spdJyutyuDetail_Sheet1.Rows[0].Label = "放送局コード";
                _spdJyutyuDetail_Sheet1.Rows[1].Label = "放送局名";
                _spdJyutyuDetail_Sheet1.Rows[2].Label = "ネット局数";
                _spdJyutyuDetail_Sheet1.Rows[3].Label = "放送時間";
                _spdJyutyuDetail_Sheet1.Rows[4].Label = "秒数";
                _spdJyutyuDetail_Sheet1.Rows[5].Label = "回数";
                _spdJyutyuDetail_Sheet1.Rows[6].Label = "放送日";
                _spdJyutyuDetail_Sheet1.Rows[7].Label = "放送期間";
            }
            else if (seiKbn == KKHSystemConst.SeiKbn.Spot)
            {
                //スポットデータ 
                _spdJyutyuDetail_Sheet1.Rows.Count = 6;
                _spdJyutyuDetail_Sheet1.Rows[0].Label = "放送局コード";
                _spdJyutyuDetail_Sheet1.Rows[1].Label = "放送局名";
                _spdJyutyuDetail_Sheet1.Rows[2].Label = "ネット局数";
                _spdJyutyuDetail_Sheet1.Rows[3].Label = "放送期間";
                _spdJyutyuDetail_Sheet1.Rows[4].Label = "秒数";
                _spdJyutyuDetail_Sheet1.Rows[5].Label = "本数";
            }
            else if (seiKbn == KKHSystemConst.SeiKbn.Works)
            {
                //諸作業データ 
                _spdJyutyuDetail_Sheet1.Rows.Count = 4;
                _spdJyutyuDetail_Sheet1.Rows[0].Label = "費目補足";
                _spdJyutyuDetail_Sheet1.Rows[1].Label = "補足内容(正味)";
                _spdJyutyuDetail_Sheet1.Rows[2].Label = "納品日期間";
                _spdJyutyuDetail_Sheet1.Rows[3].Label = "回数数量";
            }
            else if (seiKbn == KKHSystemConst.SeiKbn.Ooh)
            {
                //交通広告データ 
                _spdJyutyuDetail_Sheet1.Rows.Count = 8;
                _spdJyutyuDetail_Sheet1.Rows[0].Label = "路線コード";
                _spdJyutyuDetail_Sheet1.Rows[1].Label = "路線名";
                _spdJyutyuDetail_Sheet1.Rows[2].Label = "種別コード";
                _spdJyutyuDetail_Sheet1.Rows[3].Label = "種別名";
                _spdJyutyuDetail_Sheet1.Rows[4].Label = "費目補足";
                _spdJyutyuDetail_Sheet1.Rows[5].Label = "補足内容(正味)";
                _spdJyutyuDetail_Sheet1.Rows[6].Label = "掲載期間";
                _spdJyutyuDetail_Sheet1.Rows[7].Label = "数量";
            }
            else if (seiKbn == KKHSystemConst.SeiKbn.KMas)
            {
                //国際/マスデータ 
                _spdJyutyuDetail_Sheet1.Rows.Count = 11;
                _spdJyutyuDetail_Sheet1.Rows[0].Label = "媒体コード";
                _spdJyutyuDetail_Sheet1.Rows[1].Label = "媒体名 (漢)";
                _spdJyutyuDetail_Sheet1.Rows[2].Label = "掲載期間";
                _spdJyutyuDetail_Sheet1.Rows[3].Label = "費目補足";
                _spdJyutyuDetail_Sheet1.Rows[4].Label = "国コード";
                _spdJyutyuDetail_Sheet1.Rows[5].Label = "国名";
                _spdJyutyuDetail_Sheet1.Rows[6].Label = "通貨コード";
                _spdJyutyuDetail_Sheet1.Rows[7].Label = "外貨建取料金";
                _spdJyutyuDetail_Sheet1.Rows[8].Label = "換算日";
                _spdJyutyuDetail_Sheet1.Rows[9].Label = "換算レート";
                _spdJyutyuDetail_Sheet1.Rows[10].Label = "補足内容(国際)";
            }
            else if (seiKbn == KKHSystemConst.SeiKbn.KWorks)
            {
                //国際/諸作業データ 
                _spdJyutyuDetail_Sheet1.Rows.Count = 12;
                _spdJyutyuDetail_Sheet1.Rows[0].Label = "費目補足";
                _spdJyutyuDetail_Sheet1.Rows[1].Label = "媒体コード";
                _spdJyutyuDetail_Sheet1.Rows[2].Label = "媒体名";
                _spdJyutyuDetail_Sheet1.Rows[3].Label = "作業期間";
                _spdJyutyuDetail_Sheet1.Rows[4].Label = "数量";
                _spdJyutyuDetail_Sheet1.Rows[5].Label = "国コード";
                _spdJyutyuDetail_Sheet1.Rows[6].Label = "国名";
                _spdJyutyuDetail_Sheet1.Rows[7].Label = "通貨コード";
                _spdJyutyuDetail_Sheet1.Rows[8].Label = "外貨建料金";
                _spdJyutyuDetail_Sheet1.Rows[9].Label = "換算日";
                _spdJyutyuDetail_Sheet1.Rows[10].Label = "換算レート";
                _spdJyutyuDetail_Sheet1.Rows[11].Label = "補足内容(国際)";
            }
            else if (seiKbn == KKHSystemConst.SeiKbn.IC)
            {
                //IC(インタラクティブメディア) 
                _spdJyutyuDetail_Sheet1.Rows.Count = 6;
                _spdJyutyuDetail_Sheet1.Rows[0].Label = "種別コード";
                _spdJyutyuDetail_Sheet1.Rows[1].Label = "種別名";
                _spdJyutyuDetail_Sheet1.Rows[2].Label = "費目補足";
                _spdJyutyuDetail_Sheet1.Rows[3].Label = "補足内容(正味)";
                _spdJyutyuDetail_Sheet1.Rows[4].Label = "掲載期間";
                _spdJyutyuDetail_Sheet1.Rows[5].Label = "数量";
            }


            //********************************
            //セル毎の設定 
            //********************************
        }
        #endregion 初期表示・設定
        #region 受注登録内容検索条件変更
        /// <summary>
        /// 検索条件部コントロールの表示／非表示変更 
        /// </summary>
        private void ChangeVisibleSearchCond()
        {
            if ((KKHUtility.KKHUtility.ToString(cmbGymKbn.SelectedValue) == KKHSystemConst.GyomKbn.Radio
                || KKHUtility.KKHUtility.ToString(cmbGymKbn.SelectedValue) == KKHSystemConst.GyomKbn.EiseiM
                ) && chkJpn.Checked == true)
            {
                pnlTmSp.Visible = true;
            }
            else
            {
                pnlTmSp.Visible = false;
            }
        }
        #endregion 受注登録内容検索条件変更

        #region 受注登録内容検索

        /// <summary>
        /// 受注登録内容(一覧)スプレッドのセル移動 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void _spdJyutyuList_LeaveCell(object sender, LeaveCellEventArgs e)
        {
            //行の移動か階層の移動が発生しているか判定 
            if (e.Row == e.NewRow && actSpdViewChangeFlag == false)
            {
                //e.Cancel = true;
                return;
            }
            else
            {
                //**********************************************
                //セル移動前のチェック 
                //**********************************************
                if (ConfirmEditStatus() == false)
                {
                    e.Cancel = true;
                    actSpdViewChangeFlag = false;
                    return;
                }

                //**********************************************
                //広告費明細スプレッドの表示 
                //**********************************************
                if (e.NewRow < 0 || e.NewColumn < 0)//スプレッドの不具合(BugID 7957)対策 
                {
                    //キーボード操作による移動では移動後のIndexが正常に取得できない為、明細検索はSelectionChangedで行う 
                    kkhDetailSearchEvent = "1";
                }
                else
                {
                    SheetView activeSheet = GetActiveSheetViewBySpdJyutyuList();
                    int rowIdx = SetRowIndex(activeSheet, e.NewRow);
                    DisplayKkhDetail(rowIdx);
                    //DisplayKkhDetail(e.NewRow);
                    //移動後のシートによってボタン等のEnableを変更 
                    EnableChangeForSelectJyutyuListRow(activeSheet, rowIdx);
                    //EnableChangeForSelectJyutyuListRow(activeSheet, e.NewRow);
                }

                actSpdViewChangeFlag = false;
                return;
            }
        }

        /// <summary>
        /// 受注登録内容(一覧)スプレッドのセル移動 
        /// </summary>
        /// <param name="rowIdx"></param>
        protected virtual void _spdJyutyuList_ActiveSpreadViewChanged(int rowIdx)
        {
            SheetView activeSheet = GetActiveSheetViewBySpdJyutyuList();
            
            //アクティブシートが受注登録一覧(親)ではない場合は親シートの行インデックスに置き換え
            rowIdx = SetRowIndex(activeSheet, rowIdx);

            //明細データ表示 
            DisplayKkhDetail(rowIdx);
            
            //移動後のシートによってボタン等のEnableを変更 
            EnableChangeForSelectJyutyuListRow(activeSheet, 0);

            actSpdViewChangeFlag = false;
            return;
        }


        /// <summary>
        /// 受注登録内容の検索・表示を行う 
        /// </summary>
        protected void SearchJyutyuData()
        {
            SearchJyutyuData(false);
        }

        /// <summary>
        /// 受注登録内容の再検索・表示を行う(検索条件は前回検索時の条件) 
        /// </summary>
        protected void ReSearchJyutyuData()
        {
            SearchJyutyuData(true);
        }

        /// <summary>
        /// 受注登録内容検索・表示処理 
        /// </summary>
        /// <param name="reLoadFlag">再検索フラグ(True：再検索、False：通常検索)</param>
        protected virtual Boolean SearchJyutyuData(bool reLoadFlag)
        {
            //再検索の場合は検索条件の入力チェック・パラメータの作成等は行わない 
            if (reLoadFlag == false)
            {
                //********************
                //検索前チェック処理 
                //********************
                if (CheckBeforeSearch() == false)
                {
                    return true;
                }
            }

            //********************
            //検索前クリア処理 
            //********************
            InitializeBeforeSearch();

            //*************************************
            //受注登録内容検索 
            //*************************************
            //検索時の年月をセット 
            txtYmd.Value = SaveSrcYymm;

            if (txtYmdTo.Visible)
            {
                //検索時の終了年月をセット 
                txtYmdTo.Value = SaveSrcYymmTo;
            }

            //再検索の場合は検索条件の入力チェック・パラメータの作成等は行わない 
            if (reLoadFlag == false)
            {
                findJyutyuDataCond = CreateServiceParamForFindJyutyuDataByCond();
                findJyutyuDataCond.updateCheckFlag = false;
            }

            DetailProcessController processController = DetailProcessController.GetInstance();
            FindJyutyuDataByCondServiceResult result = processController.FindJyutyuDataByCond(findJyutyuDataCond);

            if (result.HasError == true)
            {
                return true;
            }
            

            KKHSchema.Detail dsDetail = result.DetailDataSet;

            UpdateSpdDataByJyutyuData(dsDetail);
            
            UpdateSpdData(dsDetail);

            //データソース更新 
            UpdateDataSourceByDetail(dsDetail);

            // 変更があった場合に子ビューを展開する
            //ExpandChildView(_spdJyutyuList_Sheet1);

            //********************
            //検索後チェック処理 
            //********************
            if (CheckAfterSearch() == false)
            {
                return true;
            }

            //********************
            //検索後初期表示処理 
            //********************
            InitializeAfterSearch();

            //2013/03/06 jse okazaki 公文対応　Start
            // 統合の場合、親の「請求」列に処理を行う
            DeleteParentSeikyu(_spdJyutyuList_Sheet1);
            //2013/03/06 jse okazaki 公文対応　End

            // 変更があった場合に子ビューを展開する
            ExpandChildView(_spdJyutyuList_Sheet1);

            return false;
        }

        /// <summary>
        /// 「消」「仮」「変」の付いたレコードがある子ビューを展開する
        /// </summary>
        /// <param name="parentSheet"></param>
        protected void ExpandChildView(FarPoint.Win.Spread.SheetView parentSheet)
        {
            for (int i = 0; i < parentSheet.Rows.Count; i++)
            {
                FarPoint.Win.Spread.SheetView childSheet = parentSheet.GetChildView(i, 0);

                for (int j = 0; j < childSheet.Rows.Count; j++)
                {
                    if (String.IsNullOrEmpty(childSheet.Cells[j, COLIDX_JLIST_JHENKOU].Text))
                    {
                        continue;
                    }

                    parentSheet.ExpandRow(i, true);

                    break;
                }
            }
        }

        //2013/03/06 jse okazaki 公文対応　Start
        /// <summary>
        /// 子ビューの請求に「済」の付いていないレコードがある場合、親の「済」を消す
        /// </summary>
        /// <param name="parentSheet"></param>
        protected void DeleteParentSeikyu(FarPoint.Win.Spread.SheetView parentSheet)
        {
            for (int i = 0; i < parentSheet.Rows.Count; i++)
            {
                if (String.IsNullOrEmpty(parentSheet.Cells[i, COLIDX_JLIST_SEIKYU].Text))
                {
                    continue;
                }

                FarPoint.Win.Spread.SheetView childSheet = parentSheet.GetChildView(i, 0);

                for (int j = 0; j < childSheet.Rows.Count; j++)
                {
                    if (String.IsNullOrEmpty(childSheet.Cells[j, COLIDX_JLIST_SEIKYU].Text))
                    {
                        parentSheet.Cells[i, COLIDX_JLIST_SEIKYU].Text = String.Empty;
                        break;
                    }
                }
            }
        }
        //2013/03/06 jse okazaki 公文対応　End

        /// <summary>
        /// 期間の変更
        /// </summary>
        /// <param name="dsDetail"></param>
        protected virtual void UpdateSpdData(KKHSchema.Detail dsDetail)
        {
        }

        /// <summary>
        /// JyutyuDataに保持しているデータからJyutyuListを更新します 
        /// </summary>
        protected virtual void UpdateSpdDataByJyutyuData(KKHSchema.Detail dsDetail)
        {
            dsDetail.UpdateSpdDataByJyutyuData();
        }

        /// <summary>
        /// 受注登録内容検索前チェック処理 
        /// (共通機能：なし) 
        /// </summary>
        /// <returns></returns>
        protected virtual Boolean CheckBeforeSearch()
        {
            //*************************
            //広告費明細の編集状況確認 
            //*************************
            if (ConfirmEditStatus() == false)
            {
                return false;
            }

            //********************
            //年月入力チェック 
            //********************
            //必須チェック 
            if (txtYmd.Value.Equals(""))
            {
                //エラーメッセージ(対象年月は必ず入力してください。)を表示 
                //MessageBox.Show("対象年月は必ず入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);//TODO
                base.CloseLoadingDialog();//仮 
                MessageUtility.ShowMessageBox(MessageCode.HB_W0056, null, "入力エラー", MessageBoxButtons.OK);
                txtYmd.Focus();
                return false;
            }
            //必須チェック
            if (txtYmdTo.Visible)
            {
                if (txtYmdTo.Value.Equals(""))
                {
                    //エラーメッセージ(対象年月は必ず入力してください。)を表示 
                    //MessageBox.Show("対象年月は必ず入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);//TODO
                    base.CloseLoadingDialog();//仮 
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0056, null, "入力エラー", MessageBoxButtons.OK);
                    txtYmdTo.Focus();
                    return false;
                }
                if (KKHUtility.KKHUtility.IntParse(txtYmd.Value) > KKHUtility.KKHUtility.IntParse(txtYmdTo.Value))
                {
                    //エラーメッセージ(終了日が開始日より前の日付になっています。)を表示 
                    base.CloseLoadingDialog(); //仮 
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0159, null, "入力エラー", MessageBoxButtons.OK);
                    txtYmdTo.Focus();
                    return false;
                }
            }
            //********************
            //国際区分入力チェック 
            //********************
            if (chkJpn.Checked == false && chkKgi.Checked == false)
            {
                //エラーメッセージ(国内、国際のどちらかを必ず選択して下さい。)を表示 
                //MessageBox.Show("国内、国際のどちらかを必ず選択して下さい。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);//TODO
                base.CloseLoadingDialog();//仮 
                MessageUtility.ShowMessageBox(MessageCode.HB_W0035, null, "入力エラー", MessageBoxButtons.OK);
                chkJpn.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 受注登録内容検索前クリア処理 
        /// </summary>
        protected virtual void InitializeBeforeSearch()
        {
            tabHed.SelectedIndex = 0;//選択タブは"一覧" 
            _spdJyutyuList_Sheet1.RowCount = 0;
            _spdJyutyuDetail_Sheet1.RowCount = 0;
            _spdKkhDetail_Sheet1.RowCount = 0;

            //件数更新 
            lblJyutyuListCnt.Text = "0件";

            // 受注リストのソートインジケータ初期化 
            _spdJyutyuList_Sheet1.Models.ResetViewRowIndexes();

            foreach( FarPoint.Win.Spread.Column column in _spdJyutyuList_Sheet1.Columns )
            {
                column.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            }

            //ボタンの初期化 
            InitializeControlEnabled();
        }

        /// <summary>
        /// 受注登録内容検索API実行パラメータ生成 
        /// </summary>
        /// <returns></returns>
        protected virtual DetailProcessController.FindJyutyuDataByCondParam CreateServiceParamForFindJyutyuDataByCond()
        {
            DetailProcessController.FindJyutyuDataByCondParam param = new DetailProcessController.FindJyutyuDataByCondParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = txtYmd.Value;
            if (txtYmdTo.Visible == false)
            {
                param.yymmto = "";
            }
            else
            {
                param.yymmto = txtYmdTo.Value;
            }
            param.kokKbn = "";
            if (chkJpn.Checked == chkKgi.Checked)
            {
                param.kokKbn = "";
            }
            else if (chkJpn.Checked == true)
            {
                param.kokKbn = "0";
            }
            else if (chkKgi.Checked == true)
            {
                param.kokKbn = "1";
            }
            param.tmspKbn = "";
            if (pnlTmSp.Visible == false)
            {
                param.tmspKbn = "";
            }
            else if (rdoTime.Checked == true)
            {
                param.tmspKbn = "1";
            }
            else if (rdoSpot.Checked == true)
            {
                param.tmspKbn = "2";
            }
            param.gyomKbn = KKHUtility.KKHUtility.ToString(cmbGymKbn.SelectedValue);
            param.jyutNo = txtJyuNo.Text;
            param.orderKbn = "";
            if (pnlOrder.Visible == false)
            {
                param.orderKbn = "";
            }
            else if (rdoBaitai.Checked == true)
            {
                param.orderKbn = "1";
            }
            else if (rdoKenmei.Checked == true)
            {
                param.orderKbn = "0";
            }
            if (txtKenMei.Visible == false)
            {
                param.kkNameKj = "";
            }
            //件名検索機能追加対応(2013/02/01追加 JSE A.Naito).
            else if (txtKenMei.Visible == true)
            {
                if (txtKenMei.Text.Contains("'"))
                {
                    //件名テキストボックスにシングルクォーテーション(')があった場合、('')に置換する 
                    param.kkNameKj = txtKenMei.Text.Replace("'", "''");
                }
                else
                {
                    param.kkNameKj = txtKenMei.Text;
                }
            }

            return param;
        }

        /// <summary>
        /// 受注登録内容検索後チェック処理 
        /// </summary>
        /// <returns></returns>
        protected virtual Boolean CheckAfterSearch()
        {
            //********************
            //取得件数チェック 
            //********************
            if (_dsDetail.JyutyuList.Count == 0)
            {
                //該当するデータがありません。 
                base.CloseLoadingDialog();//仮 
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "入力エラー", MessageBoxButtons.OK);
                txtYmd.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 受注登録内容検索後初期表示処理 
        /// </summary>
        protected virtual void InitializeAfterSearch()
        {
            //******************************
            //受注登録内容(一覧) 
            //******************************
            //スプレッドデザイン初期化 
            InitializeDesignForSpdJyutyuList();

            //スプレッド(子ビュー)デザイン初期化 
            InitDesignForSpdJyutyuListChild();

            //列・セルの色付け処理 
            ChangeColor();

            //件数更新 
            lblJyutyuListCnt.Text = _dsDetail.JyutyuList.Count.ToString("#,0") + "件";

            //******************************
            //広告費明細 
            //******************************
            DisplayKkhDetail(_spdJyutyuList_Sheet1.ActiveRowIndex);

            //******************************
            //ボタン類 
            //******************************
            EnableChangeForSelectJyutyuListRow(_spdJyutyuList_Sheet1, _spdJyutyuList_Sheet1.ActiveRowIndex);
        }

        /// <summary>
        /// 受注登録内容検索後の各コントロールの活性／非活性設定 
        /// </summary>
        private void EnableChangeForAfterSearch()
        {
            btnYmChange.Enabled = true;
            btnDelJyutyu.Enabled = true;
            btnMerge.Enabled = true;
            btnMergeCancel.Enabled = true;
            btnRegJyutyu.Enabled = true;
            btnUpdateCheck.Enabled = true;
        }

        /// <summary>
        /// セルの色付け処理を行う 
        /// </summary>
        protected virtual void ChangeColor()
        {
            for (int i = 0; i < _spdJyutyuList_Sheet1.Rows.Count; i++)
            {
                if (_spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_JHENKOU].Value == "消") 
                {
                    // 業務会計側で受注削除されている場合は背景色を変更 
                    _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(165, 165, 165);
                }

                FarPoint.Win.Spread.SheetView s;
                //各親行に関連する子ビューを取得します 
                s = _spdJyutyuList_Sheet1.GetChildView(i, 0);
                for (int j = 0; j < s.Rows.Count; j++ )
                {
                    if (s.Cells[j, COLIDX_JLIST_JHENKOU].Value == "消")
                    {
                        // 業務会計側で受注削除されている場合は背景色を変更 
                        s.Rows[j].BackColor = Color.FromArgb(165, 165, 165);
                    }
                }
            }
        }
        #endregion 受注登録内容検索
        
        #region 受注登録内容(詳細)
        /// <summary>
        /// 受注登録内容(詳細)を編集します。 
        /// </summary>
        /// <param name="rowNo"></param>
        private void UpdateSpdJyutyuDetail(int rowNo)
        {
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDetailRow jyutyuDetailRow = _dsDetail.JyutyuDetail.FindByrowNo(rowNo);
            for (int i = 0; i < _spdJyutyuDetail_Sheet1.Rows.Count; i++)
            {
                _spdJyutyuDetail_Sheet1.Cells[i, 0].Value = jyutyuDetailRow["Field" + (i + 1).ToString()];
            }
            
        }
        #endregion 受注登録内容(詳細)

        #region 受注登録内容(履歴)
        /// <summary>
        /// 受注登録内容(履歴)
        /// </summary>
        protected virtual void VisibleColumnsForJyutyuRireki()
        {
            foreach (Column col in _spdJyutyuRireki_Sheet1.Columns)
            {
                if (col.Index == COLIDX_JRIREKI_DTLTOROKU) { col.Visible = true; }
                else if (col.Index == COLIDX_JRIREKI_DOWNDATETIME) { col.Visible = true; }
                else if (col.Index == COLIDX_JRIREKI_URIMEINO) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_URIMEINO].Visible; }
                else if (col.Index == COLIDX_JRIREKI_SEIYYMM) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_SEIYYMM].Visible; }
                else if (col.Index == COLIDX_JRIREKI_GYOMKBN) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_GYOMKBN].Visible; }
                else if (col.Index == COLIDX_JRIREKI_KENMEI) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_KENMEI].Visible; }
                else if (col.Index == COLIDX_JRIREKI_BAITAINM) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_BAITAINM].Visible; }
                else if (col.Index == COLIDX_JRIREKI_HIMOKUNM) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_HIMOKUNM].Visible; }
                else if (col.Index == COLIDX_JRIREKI_KYOKUSHICD) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_KYOKUSHICD].Visible; }
                else if (col.Index == COLIDX_JRIREKI_SEIKINGAKU) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_SEIKINGAKU].Visible; }
                else if (col.Index == COLIDX_JRIREKI_KIKAN) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_KIKAN].Visible; }
                else if (col.Index == COLIDX_JRIREKI_DANTANKA) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_DANTANKA].Visible; }
                else if (col.Index == COLIDX_JRIREKI_DANSU) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_DANSU].Visible; }
                else if (col.Index == COLIDX_JRIREKI_TORIRYOKIN) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_TORIRYOKIN].Visible; }
                else if (col.Index == COLIDX_JRIREKI_NEBIKIRITSU) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_NEBIKIRITSU].Visible; }
                else if (col.Index == COLIDX_JRIREKI_NEBIKIGAKU) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_NEBIKIGAKU].Visible; }
                else if (col.Index == COLIDX_JRIREKI_ZEIRITSU) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_ZEIRITSU].Visible; }
                else if (col.Index == COLIDX_JRIREKI_ZEIGAKU) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_ZEIGAKU].Visible; }
                else if (col.Index == COLIDX_JRIREKI_GOUKEIKINGAKU) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_GOUKEIKINGAKU].Visible; }
                else if (col.Index == COLIDX_JRIREKI_OLDSEIYYMM) { col.Visible = _spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_OLDSEIYYMM].Visible; }
                else { col.Visible = false; }
            }
        }
        #endregion 受注登録内容(履歴)

        #region 広告費明細検索

        /// <summary>
        /// 広告費明細スプレッドにデータを表示する 
        /// (共通機能：広告費明細データを取得し、「_dsDetail.THB2KMEI」に格納する) 
        /// </summary>
        /// <param name="rowIdx">受注登録内容の選択行Index</param>
        protected virtual void DisplayKkhDetail(int rowIdx)
        {
            //*******************************************************************
            //広告費明細の初期化 
            //*******************************************************************
            ClearKkhDetail();

            //*******************************************************************
            //広告費明細データの取得 
            //*******************************************************************
            DetailProcessController.FindDetailDataByCondParam param = CreateServiceParamForFindDetailDataByCond(rowIdx);

            DetailProcessController processController = DetailProcessController.GetInstance();
            FindDetailDataByCondServiceResult result = processController.FindDetailDataByCond(param);

            if (result.HasError == true)
            {
                return;
            }

            // 受注明細のソートインジケータ初期化 
            _spdKkhDetail_Sheet1.Models.ResetViewRowIndexes();

            foreach( FarPoint.Win.Spread.Column column in _spdKkhDetail_Sheet1.Columns )
            {
                column.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            }

            _dsDetail.THB2KMEI.Merge(result.DetailDataSet.THB2KMEI);
            _dsDetail.THB2KMEI.AcceptChanges();

            //********************************************************************
            //表示用データの編集 
            //********************************************************************
            //得意先別に実装 
        }

        /// <summary>
        /// 広告費明細スプレッドの表示、および保持しているデータをクリアする 
        /// </summary>
        protected virtual void ClearKkhDetail()
        {
            //データをクリア 
            _dsDetail.THB2KMEI.Clear();
            //変更中フラグを戻す 
            kkhDetailUpdFlag = false;
        }

        /// <summary>
        /// 広告費明細検索API実行パラメータ生成 
        /// </summary>
        /// <param name="rowIdx"></param>
        /// <returns></returns>
        protected virtual DetailProcessController.FindDetailDataByCondParam CreateServiceParamForFindDetailDataByCond(int rowIdx)
        {
            DetailProcessController.FindDetailDataByCondParam param = new DetailProcessController.FindDetailDataByCondParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;

            KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(rowIdx);
            param.yymm = dataRow.hb1Yymm;
            param.jyutNo = dataRow.hb1JyutNo;
            param.jyMeiNo = dataRow.hb1JyMeiNo;
            param.urMeiNo = dataRow.hb1UrMeiNo;

            return param;
        }
        #endregion 広告費明細検索

        #region 受注削除
        /// <summary>
        /// 受注削除処理 
        /// </summary>
        protected virtual void DelJyutyuClick()
        {
            //処理前チェック処理 
            if (CheckBeforeDelJyutyu() == false)
            {
                return;
            }

            //実行確認 
            if (DialogResult.OK != MessageUtility.ShowMessageBox(MessageCode.HB_C0008, null, "受注削除", MessageBoxButtons.OKCancel))
            {
                return;
            }
            //受注削除処理実行 
            if (deleteJyutyu() == false)
            {
                //MessageBox.Show("受注削除が失敗しました。", "受注削除", MessageBoxButtons.OK, MessageBoxIcon.Error);//TODO
                MessageUtility.ShowMessageBox(MessageCode.HB_E0004, null, "受注削除", MessageBoxButtons.OK);
                return;
            }

            //受注削除処理後 
            InitAfterDelJyutyu();

            //完了メッセージ 
            if (_spdJyutyuList_Sheet1.RowCount != 0)
            {
                //MessageBox.Show("処理が終了しました。", "受注削除", MessageBoxButtons.OK);
                MessageUtility.ShowMessageBox(MessageCode.HB_I0007, null, "受注削除", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 受注削除実行前のチェック処理 
        /// </summary>
        /// <returns>チェック結果(True：OK、False：NG)</returns>
        protected virtual bool CheckBeforeDelJyutyu()
        {
            //*************************
            //広告費明細の編集状況確認 
            //*************************
            if (ConfirmEditStatus() == false)
            {
                return false;
            }

            if (_spdJyutyuList_Sheet1.SelectionCount == 0)
            {
                //MessageBox.Show("受注内容が選択されていません。", "明細登録", MessageBoxButtons.OK);
                MessageUtility.ShowMessageBox(MessageCode.HB_I0012, null, "明細登録", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 受注削除処理を実行する 
        /// </summary>
        /// <returns>実行結果(True：正常終了、False：エラー)</returns>
        protected virtual bool deleteJyutyu()
        {
            //選択行の取得 
            CellRange[] cellRanges = SortCellRangesByRowIdx(_spdJyutyuList_Sheet1.GetSelections());
            DetailProcessController.DeleteJyutyuDataParam param = CreateServiceParamForDeleteJyutyuData(cellRanges);

            DetailProcessController processController = DetailProcessController.GetInstance();
            DeleteJyutyuDataServiceResult result = processController.DeleteJyutyuData(param);

            if (result.HasError == true)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 広告費明細検索API実行パラメータ生成 
        /// </summary>
        /// <param name="cellRanges"></param>
        /// <returns></returns>
        protected virtual DetailProcessController.DeleteJyutyuDataParam CreateServiceParamForDeleteJyutyuData(CellRange[] cellRanges)
        {
            DateTime maxUpdDate = new DateTime();
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();

            foreach (CellRange cellRange in cellRanges)
            {
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    //選択されている受注登録内容の行数分の処理を繰り返す 
                    int rowIndex = cellRange.Row + i;

                    if (_spdJyutyuList_Sheet1.RowFilter.IsRowFilteredOut(rowIndex))
                    {
                        // フィルタリングで見えなくなっている行は処理対象外とする.
                        continue;
                    }

                    KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(rowIndex);

                    Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();

                    thb1DownRow.hb1EgCd = dataRow.hb1EgCd;
                    thb1DownRow.hb1TksKgyCd = dataRow.hb1TksKgyCd;
                    thb1DownRow.hb1TksBmnSeqNo = dataRow.hb1TksBmnSeqNo;
                    thb1DownRow.hb1TksTntSeqNo = dataRow.hb1TksTntSeqNo;
                    thb1DownRow.hb1Yymm = dataRow.hb1Yymm;
                    thb1DownRow.hb1TouFlg = dataRow.hb1TouFlg;
                    thb1DownRow.hb1JyutNo = dataRow.hb1JyutNo;
                    thb1DownRow.hb1JyMeiNo = dataRow.hb1JyMeiNo;
                    thb1DownRow.hb1UrMeiNo = dataRow.hb1UrMeiNo;

                    dtThb1Down.AddTHB1DOWNRow(thb1DownRow);

                    //更新日付最大値の判定 
                    if (maxUpdDate == null || maxUpdDate.CompareTo(dataRow.hb1TimStmp) < 0)
                    {
                        maxUpdDate = dataRow.hb1TimStmp;
                    }
                }
            }

            dsDetail.THB1DOWN.Merge(dtThb1Down);
            
            DetailProcessController.DeleteJyutyuDataParam param = new DetailProcessController.DeleteJyutyuDataParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.dsDetail = dsDetail;
            param.maxUpdDate = maxUpdDate;

            return param;
        }

        /// <summary>
        /// 受注削除後の初期化処理 
        /// </summary>
        protected virtual void InitAfterDelJyutyu()
        {
            //現在のアクティブ行インデックスを保持 
            //int rowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;
            //再検索 
            ReSearchJyutyuData();

            if (_spdJyutyuList_Sheet1.Rows.Count == 0)
            {
                return;
            }

            _spdJyutyuList_Sheet1.SetActiveCell(0, 0, true);
            _spdJyutyuList_Sheet1.AddSelection(0, 0, 1, 1);
            spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

            return;
        }
        #endregion 受注削除

        #region 年月変更
        /// <summary>
        /// 年月変更処理 
        /// </summary>
        protected virtual void ChangeYmClick()
        {
            //************************************************
            //年月変更ダイアログ表示前チェック 
            //************************************************
            if (CheckBeforeYmChange() == false)
            {
                return;
            }

            //************************************************
            //年月変更ダイアログ表示 
            //************************************************
            CellRange[] cellRanges = SortCellRangesByRowIdx(_spdJyutyuList_Sheet1.GetSelections());
            KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(cellRanges[0].Row);

            DetailCngYymmNaviParameter chgYymmParam = new DetailCngYymmNaviParameter();
            chgYymmParam.StrYymm = dataRow.hb1Yymm;
            chgYymmParam.AplId = AplId;
            chgYymmParam.Mode = GetCngYYmmMode();

            object retObj = Navigator.ShowModalForm(this, "toDetailCngYymm", chgYymmParam);

            if (retObj == null)
            {
                //キャンセルの場合は返り値がNull 
                return;
            }
            KKHNaviParameter naviParam = (KKHNaviParameter)retObj;
            if (dataRow.hb1Yymm == naviParam.StrYymm)
            {
                //変更がない場合は終了 
                return;
            }

            //************************************************
            //年月変更API実行 
            //************************************************
            DateTime maxUpdDate = new DateTime();
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();
            foreach (CellRange cellRange in cellRanges)
            {
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    int rowIndex = cellRange.Row + i;
                    dataRow = null;
                    dataRow = getSelectJyutyuData(rowIndex);

                    Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();
                    thb1DownRow.hb1UpdTnt = KKHSecurityInfo.GetInstance().UserEsqId;
                    thb1DownRow.hb1UpdApl = AplId;
                    thb1DownRow.hb1EgCd = dataRow.hb1EgCd;
                    thb1DownRow.hb1TksKgyCd = dataRow.hb1TksKgyCd;
                    thb1DownRow.hb1TksBmnSeqNo = dataRow.hb1TksBmnSeqNo;
                    thb1DownRow.hb1TksTntSeqNo = dataRow.hb1TksTntSeqNo;
                    thb1DownRow.hb1Yymm = dataRow.hb1Yymm;
                    thb1DownRow.hb1JyutNo = dataRow.hb1JyutNo;
                    thb1DownRow.hb1JyMeiNo = dataRow.hb1JyMeiNo;
                    thb1DownRow.hb1UrMeiNo = dataRow.hb1UrMeiNo;
                    thb1DownRow.hb1TouFlg = ConvertDBSpace(dataRow.hb1TouFlg);

                    thb1DownRow.hb1YymmOld = dataRow.hb1YymmOld;

                    dtThb1Down.AddTHB1DOWNRow(thb1DownRow);

                    //更新日付最大値の判定 
                    if (maxUpdDate == null || maxUpdDate.CompareTo(dataRow.hb1TimStmp) < 0)
                    {
                        maxUpdDate = dataRow.hb1TimStmp;
                    }
                }
            }

            dsDetail.THB1DOWN.Merge(dtThb1Down);


            DetailProcessController.ChangeSeikyuYymmParam param = new DetailProcessController.ChangeSeikyuYymmParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.dsDetail = dsDetail;
            param.yymmNew = naviParam.StrYymm;
            param.maxUpdDate = maxUpdDate;

            DetailProcessController processController = DetailProcessController.GetInstance();
            ChangeSeikyuYymmServiceResult result = processController.ChangeSeikyuYymm(param);
            string[] comment = new string[]{result.MessageCode};
            if (result.HasError == true)
            {
                if (result.MessageCode == "UNIQUE-E0001")
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0024, null, "明細登録", MessageBoxButtons.OK);
                }
                else
                {
                    //MessageBox.Show("請求年月の変更が失敗しました。" + result.MessageCode, "明細登録", MessageBoxButtons.OK, MessageBoxIcon.Error);//TODO
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0011, comment, "明細登録", MessageBoxButtons.OK);
                }
                return;
            }

            //完了メッセージ 
            //MessageBox.Show("請求年月の変更が完了しました。", "明細登録", MessageBoxButtons.OK);
            MessageUtility.ShowMessageBox(MessageCode.HB_I0008, null, "明細登録", MessageBoxButtons.OK);

            //再検索処理 
            ReSearchJyutyuData();
        }

        /// <summary>
        /// 年月変更ダイアログ表示前チェック 
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckBeforeYmChange()
        {
            //*************************
            //広告費明細の編集状況確認 
            //*************************
            if (ConfirmEditStatus() == false)
            {
                return false;
            }

            CellRange[] cellRanges = SortCellRangesByRowIdx(_spdJyutyuList_Sheet1.GetSelections());
            if (cellRanges.Length == 0)
            {
                //MessageBox.Show("受注内容が選択されていません。", "明細登録", MessageBoxButtons.OK);
                MessageUtility.ShowMessageBox(MessageCode.HB_W0045, null, "明細登録", MessageBoxButtons.OK);
                return false;
            }
            foreach (CellRange cellRange in cellRanges)
            {
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    int rowIndex = cellRange.Row + i;
                    KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(rowIndex);

                    if (dataRow.hb1TouFlg == "1")
                    {
                        //MessageBox.Show("統合された受注内容が選択されています。", "明細登録", MessageBoxButtons.OK);
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0066, null, "明細登録", MessageBoxButtons.OK);
                        return false;
                    }

                    if (_spdJyutyuList_Sheet1.Cells[rowIndex, COLIDX_JLIST_TOROKU].Text != "")
                    {
                        //MessageBox.Show("明細登録済みの受注内容が選択されています。", "明細登録", MessageBoxButtons.OK);
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0090, null, "明細登録", MessageBoxButtons.OK);
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion 年月変更

        #region 新規作成
        /// <summary>
        /// 新規作成ボタンクリック処理 
        /// </summary>
        protected virtual void RegJyutyuClick()
        {
            if (CheckBeforeRegJyutyu() == false)
            {
                return;
            }

            //_naviParameter.StrYymm = findJyutyuDataCond.yymm;
            if (txtYmdTo.Visible)
            {
                _naviParameter.StrYymm = findJyutyuDataCond.yymmto;
            }
            else
            {
                _naviParameter.StrYymm = findJyutyuDataCond.yymm;
            }

            _naviParameter.AplId = AplId;   //プログラムID
            _naviParameter.GyomKbn = _spdJyutyuList_Sheet1.Cells[_spdJyutyuList_Sheet1.ActiveRowIndex,COLIDX_JLIST_GYOMKBN].Value.ToString(); //業務区分           
            object ret = Navigator.ShowModalForm(this, "toJyutyuRegister", _naviParameter);
            if (ret == null)
            {
                return;
            }
            SearchJyutyuData(true);//受注登録内容再検索・表示 
        }

        /// <summary>
        /// 新規作成ダイアログ表示前チェック 
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckBeforeRegJyutyu()
        {
            //*************************
            //広告費明細の編集状況確認 
            //*************************
            if (ConfirmEditStatus() == false)
            {
                return false;
            }

            return true;
        }
        #endregion 新規作成

        #region 受注統合
        /// <summary>
        /// 受注統合ボタンクリック処理 
        /// </summary>
        protected virtual void MergeClick()
        {

            //***********************************************************
            //統合先選択ダイアログ表示前チェック・対象データ取得 
            //***********************************************************
            //*************************
            //広告費明細の編集状況確認 
            //*************************
            if (ConfirmEditStatus() == false)
            {
                return;
            }

            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();
            //選択行の取得 
            CellRange[] cellRanges = SortCellRangesByRowIdx(_spdJyutyuList_Sheet1.GetSelections());

            if (cellRanges.Length < 1 || (cellRanges.Length == 1 && cellRanges[0].RowCount < 2))
            {
               // MessageBox.Show("複数の行を選択してください。", "明細登録", MessageBoxButtons.OK);//TODO
                MessageUtility.ShowMessageBox(MessageCode.HB_W0084, null, "明細登録", MessageBoxButtons.OK);
                return;
            }

            foreach (CellRange cellRange in cellRanges)
            {
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    //選択されている受注登録内容の行数分の処理を繰り返す 
                    int rowIndex = cellRange.Row + i;

                    if (_spdJyutyuList_Sheet1.RowFilter.IsRowFilteredOut(rowIndex))
                    {
                        // フィルタリングで見えなくなっている場合はエラーを表示する.
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0146, null, "明細登録", MessageBoxButtons.OK);
                        return;
                    }

                    KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(rowIndex);
                    if (dataRow.hb1TouFlg == "1")
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0015, null, "明細登録", MessageBoxButtons.OK);
                        return;
                    }

                    //2013/03/16 jse okazaki 公文対応　Start
                    // 2015/04/01 公文得意先変更対応 Fujisaki Cng Start 
                    //if ((dataRow.hb1TksKgyCd + dataRow.hb1TksBmnSeqNo + dataRow.hb1TksTntSeqNo) == KKHSystemConst.TksKgyCode.TksKgyCode_Kmn)
                    if ((dataRow.hb1TksKgyCd + dataRow.hb1TksBmnSeqNo + dataRow.hb1TksTntSeqNo) == KKHSystemConst.TksKgyCode.TksKgyCode_Kmn ||
                        (dataRow.hb1TksKgyCd + dataRow.hb1TksBmnSeqNo + dataRow.hb1TksTntSeqNo) == KKHSystemConst.TksKgyCode.TksKgyCode_Kmn_2015)
                    // 2015/04/01 公文得意先変更対応 Fujisaki Cng End 
                    {
                        if (_spdJyutyuList_Sheet1.Cells[rowIndex, COLIDX_JLIST_TOROKU].Text != "")
                        {
                            //明細登録済の場合、統合不可
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0090, null, "明細登録", MessageBoxButtons.OK);
                            return;
                        }
                    }
                    //2013/03/16 jse okazaki 公文対応　End

                    KKHSchema.Detail.JyutyuDataRow addRow = dsDetail.JyutyuData.NewJyutyuDataRow();
                    //addRow.ItemArray = (object[])dataRow.ItemArray.Clone();
                    addRow.ItemArray = (object[])dataRow.ItemArray;

                    dsDetail.JyutyuData.AddJyutyuDataRow(addRow);
                }
            }

            //*************************
            //統合先選択画面の表示 
            //*************************
            _naviParameter.DsDetail = dsDetail;
            _naviParameter.AplId = AplId;
            object obj = Navigator.ShowModalForm(this, "toJyutyuMerge", _naviParameter);

            if (obj == null)
            {
                return;
            }


            //2013/03/16 jse okazaki 公文対応　Start
            ////*************************************
            ////統合処理実行 
            ////*************************************
            //KKHNaviParameter naviParameterOut = (KKHNaviParameter)obj;
            //if (MergeJyutyuData(dsDetail.JyutyuData, naviParameterOut.IntValue1) == false)
            //{
            //    return;
            //}

            //統合画面からの値を設定
            KKHNaviParameter naviParameterOut = (KKHNaviParameter)obj;

            // 2015/04/01 公文得意先変更対応 Fujisaki Cng Start 
            // if ((_naviParameterIn.strTksKgyCd + _naviParameterIn.strTksBmnSeqNo + _naviParameterIn.strTksTntSeqNo) == KKHSystemConst.TksKgyCode.TksKgyCode_Kmn)
            if ((_naviParameterIn.strTksKgyCd + _naviParameterIn.strTksBmnSeqNo + _naviParameterIn.strTksTntSeqNo) == KKHSystemConst.TksKgyCode.TksKgyCode_Kmn ||
                (_naviParameterIn.strTksKgyCd + _naviParameterIn.strTksBmnSeqNo + _naviParameterIn.strTksTntSeqNo) == KKHSystemConst.TksKgyCode.TksKgyCode_Kmn_2015)
            // 2015/04/01 公文得意先変更対応 Fujisaki Cng End 
            {
                String togosakiYymm = String.Empty;
                String togosakiKey = String.Empty;
                KKHNaviParameter naviParameterYymm = (KKHNaviParameter)obj;

                foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in dsDetail.JyutyuData.Rows)
                {
                    //統合先データの請求年月を取得 
                    if (row.rowNum == naviParameterYymm.IntValue1)
                    {
                        togosakiYymm = row.hb1Yymm;
                        togosakiKey = row.hb1JyutNo + row.hb1JyMeiNo + row.hb1UrMeiNo + row.hb1Yymm;
                    }
                }
                foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in dsDetail.JyutyuData.Rows)
                {
                    if (!row.hb1Yymm.Equals(togosakiYymm))
                    {
                        //統合先データと統合元の年月が異なる場合は請求年月を変更 
                        //************************************************
                        //年月変更API実行 
                        //************************************************
                        DateTime maxUpdDateYymm = new DateTime();
                        Isid.KKH.Common.KKHSchema.Detail dsDetailYymm = new Isid.KKH.Common.KKHSchema.Detail();
                        Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();
                        Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();

                        thb1DownRow.hb1UpdTnt = KKHSecurityInfo.GetInstance().UserEsqId;
                        thb1DownRow.hb1UpdApl = AplId;
                        thb1DownRow.hb1EgCd = row.hb1EgCd;
                        thb1DownRow.hb1TksKgyCd = row.hb1TksKgyCd;
                        thb1DownRow.hb1TksBmnSeqNo = row.hb1TksBmnSeqNo;
                        thb1DownRow.hb1TksTntSeqNo = row.hb1TksTntSeqNo;
                        thb1DownRow.hb1Yymm = row.hb1Yymm;
                        thb1DownRow.hb1JyutNo = row.hb1JyutNo;
                        thb1DownRow.hb1JyMeiNo = row.hb1JyMeiNo;
                        thb1DownRow.hb1UrMeiNo = row.hb1UrMeiNo;
                        thb1DownRow.hb1TouFlg = ConvertDBSpace(row.hb1TouFlg);

                        thb1DownRow.hb1YymmOld = row.hb1YymmOld;

                        dtThb1Down.AddTHB1DOWNRow(thb1DownRow);

                        //更新日付最大値の判定 
                        if (maxUpdDateYymm == null || maxUpdDateYymm.CompareTo(row.hb1TimStmp) < 0)
                        {
                            maxUpdDateYymm = row.hb1TimStmp;
                        }

                        dsDetailYymm.THB1DOWN.Merge(dtThb1Down);


                        DetailProcessController.ChangeSeikyuYymmParam paramYymm = new DetailProcessController.ChangeSeikyuYymmParam();
                        paramYymm.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
                        paramYymm.dsDetail = dsDetailYymm;
                        paramYymm.yymmNew = togosakiYymm;
                        paramYymm.maxUpdDate = maxUpdDateYymm;

                        DetailProcessController processControllerYymm = DetailProcessController.GetInstance();
                        ChangeSeikyuYymmServiceResult resultYymm = processControllerYymm.ChangeSeikyuYymm(paramYymm);
                        string[] comment = new string[] { resultYymm.MessageCode };
                        if (resultYymm.HasError == true)
                        {
                            if (resultYymm.MessageCode == "UNIQUE-E0001")
                            {
                                MessageUtility.ShowMessageBox(MessageCode.HB_E0024, null, "明細登録", MessageBoxButtons.OK);
                            }
                            else
                            {
                                MessageUtility.ShowMessageBox(MessageCode.HB_E0011, comment, "明細登録", MessageBoxButtons.OK);
                            }
                            return;
                        }
                    }
                    ReSearchJyutyuData();
                }

                //初期化
                dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

                foreach (CellRange cellRange in cellRanges)
                {
                    for (int i = 0; i < cellRange.RowCount; i++)
                    {
                        //選択されている受注登録内容の行数分の処理を繰り返す 
                        int rowIndex = cellRange.Row + i;
                        KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(rowIndex);
                        KKHSchema.Detail.JyutyuDataRow addRow = dsDetail.JyutyuData.NewJyutyuDataRow();
                        addRow.ItemArray = (object[])dataRow.ItemArray;

                        dsDetail.JyutyuData.AddJyutyuDataRow(addRow);
                        if (addRow.hb1JyutNo + addRow.hb1JyMeiNo + addRow.hb1UrMeiNo + addRow.hb1Yymm == togosakiKey)
                        {
                            naviParameterOut.IntValue1 = addRow.rowNum;
                        }
                    }
                }
            }

            //*************************************
            //統合処理実行 
            //*************************************
            if (MergeJyutyuData(dsDetail.JyutyuData, naviParameterOut.IntValue1) == false)
            {
                return;
            }

            //2013/03/16 jse okazaki 公文対応　End


            //*************************************
            //再検索・表示 
            //*************************************
            //実行結果が正常な場合、受注統合処理後の再表示処理を行う 
            ReSearchJyutyuData();
            if (_spdJyutyuList_Sheet1.RowCount >= cellRanges[0].Row + 1)
            {
                _spdJyutyuList_Sheet1.SetActiveCell(cellRanges[0].Row, 0, true);
                _spdJyutyuList_Sheet1.AddSelection(cellRanges[0].Row, -1, 1, -1);
                spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);
            }

            //******************************
            //広告費明細 
            //******************************
            //現在行の明細レコードを表示する
            DisplayKkhDetail(_spdJyutyuList_Sheet1.ActiveRowIndex);

            //MessageBox.Show("統合しました。", "明細登録", MessageBoxButtons.OK);//TODO
            MessageUtility.ShowMessageBox(MessageCode.HB_I0009, null, "明細登録", MessageBoxButtons.OK);
        }

        /// <summary>
        /// 受注統合API実行パラメータ生成 
        /// </summary>
        /// <param name="dtJyutyuData"></param>
        /// <param name="tousakiRownum"></param>
        /// <returns></returns>
        protected virtual DetailProcessController.MergeJyutyuDataParam CreateServiceParamForMergeJyutyuData(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable dtJyutyuData, int tousakiRownum)
        {
            //サービスパラメータ(統合元データリスト) 
            Isid.KKH.Common.KKHSchema.Detail dsTougouMoto = new Isid.KKH.Common.KKHSchema.Detail();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtTougouMoto = dsTougouMoto.THB1DOWN;
            //サービスパラメータ(統合先データ) 
            Isid.KKH.Common.KKHSchema.Detail dsTougouSaki = new Isid.KKH.Common.KKHSchema.Detail();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtTougouSaki = dsTougouSaki.THB1DOWN;
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow rowTougouSaki = dtTougouSaki.NewTHB1DOWNRow(true);
            //サービスパラメータ(更新日付最大値－排他チェック用) 
            DateTime maxUpdDate = new DateTime();

            foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in dtJyutyuData.Rows)
            {
                //統合元データの編集 
                Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow rowTougouMoto = dtTougouMoto.NewTHB1DOWNRow();
                rowTougouMoto.hb1UpdTnt = _naviParameter.strEsqId;
                rowTougouMoto.hb1UpdApl = AplId;
                rowTougouMoto.hb1EgCd = row.hb1EgCd;
                rowTougouMoto.hb1TksKgyCd = row.hb1TksKgyCd;
                rowTougouMoto.hb1TksBmnSeqNo = row.hb1TksBmnSeqNo;
                rowTougouMoto.hb1TksTntSeqNo = row.hb1TksTntSeqNo;
                rowTougouMoto.hb1Yymm = row.hb1Yymm;
                rowTougouMoto.hb1JyutNo = row.hb1JyutNo;
                rowTougouMoto.hb1JyMeiNo = row.hb1JyMeiNo;
                rowTougouMoto.hb1UrMeiNo = row.hb1UrMeiNo;
                rowTougouMoto.hb1TouFlg = row.hb1TouFlg.PadRight(1, ' ');

                dtTougouMoto.AddTHB1DOWNRow(rowTougouMoto);

                //統合先データの編集 
                if (row.rowNum == tousakiRownum)
                {
                    //row.hb1TimStmp = new DateTime();
                    //更新タイムスタンプ 
                    rowTougouSaki.hb1KsnTimStmp = row.hb1KsnTimStmp;
                    //明細更新者 
                    rowTougouSaki.hb1KsnTnt = row.hb1KsnTnt;
                    //明細更新者名
                    rowTougouSaki.hb1KsnTntNm = row.hb1KsnTntNm;
                    //登録タイムスタンプ 
                    rowTougouSaki.hb1TrkTimStmp = row.hb1TrkTimStmp;
                    //登録者 
                    rowTougouSaki.hb1TrkTnt = row.hb1TrkTnt;
                    //登録者名
                    rowTougouSaki.hb1TrkTntNm = row.hb1TrkTntNm;
                    //更新プログラム 
                    rowTougouSaki.hb1UpdApl = AplId;
                    //更新担当者 
                    rowTougouSaki.hb1UpdTnt = _naviParameter.strEsqId;
                    //営業所（扱）コード 
                    rowTougouSaki.hb1AtuEgCd = row.hb1EgCd;
                    //営業所（取）コード 
                    rowTougouSaki.hb1EgCd = row.hb1EgCd;
                    //得意先企業コード 
                    rowTougouSaki.hb1TksKgyCd = row.hb1TksKgyCd;
                    //得意先部門SEQNO 
                    rowTougouSaki.hb1TksBmnSeqNo = row.hb1TksBmnSeqNo;
                    //得意先担当SEQNO 
                    rowTougouSaki.hb1TksTntSeqNo = row.hb1TksTntSeqNo;
                    //受注No 
                    rowTougouSaki.hb1JyutNo = row.hb1JyutNo;
                    //受注明細No 
                    rowTougouSaki.hb1JyMeiNo = row.hb1JyMeiNo;
                    //売上明細No 
                    rowTougouSaki.hb1UrMeiNo = row.hb1UrMeiNo;
                    //請求原票No 
                    rowTougouSaki.hb1GpyNo = " ";
                    //ページNo 
                    rowTougouSaki.hb1GpyoPag = " ";
                    //請求No 
                    rowTougouSaki.hb1SeiNo = " ";
                    //費目コード 
                    rowTougouSaki.hb1HimkCd = row.hb1HimkCd;
                    //統合フラグ 
                    rowTougouSaki.hb1TouFlg = "1";
                    //年月 
                    rowTougouSaki.hb1Yymm = row.hb1Yymm;
                    //業務区分 
                    rowTougouSaki.hb1GyomKbn = row.hb1GyomKbn;
                    //マス正味区分 
                    rowTougouSaki.hb1MsKbn = row.hb1MsKbn;
                    //タイムスポット区分 
                    rowTougouSaki.hb1TmspKbn = row.hb1TmspKbn;
                    //国際区分 
                    rowTougouSaki.hb1KokKbn = row.hb1KokKbn;
                    //請求区分 
                    rowTougouSaki.hb1SeiKbn = row.hb1SeiKbn;
                    //商品No 
                    rowTougouSaki.hb1SyoNo = row.hb1SyoNo;
                    //件名(漢字) 
                    rowTougouSaki.hb1KKNameKJ = row.hb1KKNameKJ;
                    //営業画面タイプ 
                    rowTougouSaki.hb1EgGamenType = row.hb1EgGamenType;
                    //企画・製版区分
                    rowTougouSaki.hb1KkakShanKbn = row.hb1KkakShanKbn;
                    //取料金 
                    rowTougouSaki.hb1ToriGak = rowTougouSaki.hb1ToriGak + row.hb1ToriGak;
                    //請求単価 
                    rowTougouSaki.hb1SeiTnka = 0.0M;
                    //請求金額 
                    rowTougouSaki.hb1SeiGak = rowTougouSaki.hb1SeiGak + row.hb1SeiGak;
                    //値引率 
                    rowTougouSaki.hb1NeviRitu = row.hb1NeviRitu;
                    //値引額 
                    rowTougouSaki.hb1NeviGak = rowTougouSaki.hb1NeviGak + row.hb1NeviGak;
                    //消費税区分 
                    rowTougouSaki.hb1SzeiKbn = row.hb1SzeiKbn;
                    //消費税率 
                    rowTougouSaki.hb1SzeiRitu = row.hb1SzeiRitu;
                    //消費税額 
                    rowTougouSaki.hb1SzeiGak = rowTougouSaki.hb1SzeiGak + row.hb1SzeiGak;
                    //費目名(漢字) 
                    rowTougouSaki.hb1HimkNmKJ = row.hb1HimkNmKJ;
                    //費目名(カナ) 
                    rowTougouSaki.hb1HimkNmKN = " ";
                    //統合先受注No 
                    rowTougouSaki.hb1TJyutNo = " ";
                    //統合先受注明細No 
                    rowTougouSaki.hb1TJyMeiNo = " ";
                    //統合先売上明細No 
                    rowTougouSaki.hb1TUrMeiNo = " ";
                    //未請求フラグ 
                    rowTougouSaki.hb1MSeiFlg = " ";
                    //変更前年月 
                    rowTougouSaki.hb1YymmOld = " ";

                    if ((rowTougouSaki.hb1TksKgyCd + rowTougouSaki.hb1TksBmnSeqNo + rowTougouSaki.hb1TksTntSeqNo) == KKHSystemConst.TksKgyCode.TksKgyCode_Epson)
                    {
                        //フィールド１ 
                        rowTougouSaki.hb1Field1 = " ";
                        //フィールド２ 
                        rowTougouSaki.hb1Field2 = " ";
                        //フィールド３ 
                        rowTougouSaki.hb1Field3 = " ";
                        //フィールド４ 
                        rowTougouSaki.hb1Field4 = " ";
                        //フィールド５ 
                        rowTougouSaki.hb1Field5 = " ";
                        //フィールド６ 
                        rowTougouSaki.hb1Field6 = " ";
                        //フィールド７ 
                        rowTougouSaki.hb1Field7 = " ";
                        //フィールド８ 
                        rowTougouSaki.hb1Field8 = " ";
                        //フィールド９ 
                        rowTougouSaki.hb1Field9 = " ";
                        //フィールド１０ 
                        rowTougouSaki.hb1Field10 = " ";
                        //フィールド１１ 
                        rowTougouSaki.hb1Field11 = " ";
                        //フィールド１２ 
                        rowTougouSaki.hb1Field12 = " ";                        
                    }
                    else
                    {
                        //フィールド１ 
                        rowTougouSaki.hb1Field1 = row.hb1Field1;
                        //フィールド２ 
                        rowTougouSaki.hb1Field2 = row.hb1Field2;
                        //フィールド３ 
                        rowTougouSaki.hb1Field3 = row.hb1Field3;
                        //フィールド４ 
                        rowTougouSaki.hb1Field4 = row.hb1Field4;
                        //フィールド５ 
                        rowTougouSaki.hb1Field5 = row.hb1Field5;
                        //フィールド６ 
                        rowTougouSaki.hb1Field6 = row.hb1Field6;
                        //フィールド７ 
                        rowTougouSaki.hb1Field7 = row.hb1Field7;
                        //フィールド８ 
                        rowTougouSaki.hb1Field8 = row.hb1Field8;
                        //フィールド９ 
                        rowTougouSaki.hb1Field9 = row.hb1Field9;
                        //フィールド１０ 
                        rowTougouSaki.hb1Field10 = row.hb1Field10;
                        //フィールド１１ 
                        rowTougouSaki.hb1Field11 = row.hb1Field11;
                        //フィールド１２ 
                        rowTougouSaki.hb1Field12 = row.hb1Field12;
                    }
                }
                else
                {
                    //取料金 
                    rowTougouSaki.hb1ToriGak = rowTougouSaki.hb1ToriGak + row.hb1ToriGak;
                    //請求金額 
                    rowTougouSaki.hb1SeiGak = rowTougouSaki.hb1SeiGak + row.hb1SeiGak;
                    //値引額 
                    rowTougouSaki.hb1NeviGak = rowTougouSaki.hb1NeviGak + row.hb1NeviGak;
                    //消費税額 
                    rowTougouSaki.hb1SzeiGak = rowTougouSaki.hb1SzeiGak + row.hb1SzeiGak;
                }


                //更新日付最大値の判定 
                if (maxUpdDate == null || maxUpdDate.CompareTo(row.hb1TimStmp) < 0)
                {
                    maxUpdDate = row.hb1TimStmp;
                }
            }

            dtTougouSaki.AddTHB1DOWNRow(rowTougouSaki);
            dsTougouSaki.THB1DOWN.Merge(dtTougouSaki);

            dsTougouMoto.THB1DOWN.Merge(dtTougouMoto);

            //戻り値に値をセット 
            DetailProcessController.MergeJyutyuDataParam param = new DetailProcessController.MergeJyutyuDataParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.dsTougouSaki = dsTougouSaki;
            param.dsTougouMoto = dsTougouMoto;
            param.maxUpdDate = maxUpdDate;

            return param;
        }

        /// <summary>
        /// 受注統合APIの実行 
        /// </summary>
        /// <param name="dtJyutyuData">統合対象となる受注データ(JyutyuData)</param>
        /// <param name="tousakiRownum">統合先となる受注データ(JyutyuData)のRowNum</param>
        /// <returns></returns>
        protected bool MergeJyutyuData(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable dtJyutyuData, int tousakiRownum)
        {

            DetailProcessController.MergeJyutyuDataParam param = CreateServiceParamForMergeJyutyuData(dtJyutyuData, tousakiRownum);
            DetailProcessController processController = DetailProcessController.GetInstance();
            MergeJyutyuDataServiceResult result = processController.MergeJyutyuData(param);
            if (result.HasError == true)
            {
                //MessageBox.Show("統合に失敗しました。", "明細登録", MessageBoxButtons.OK);//TODO
                MessageUtility.ShowMessageBox(MessageCode.HB_E0006, null, "明細登録", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
        #endregion 受注統合
        #region 統合取消
        /// <summary>
        /// 統合解除ボタンクリック処理 
        /// </summary>
        protected virtual void MergeCancelClick()
        {

            //*************************
            //広告費明細の編集状況確認 
            //*************************
            if (ConfirmEditStatus() == false)
            {
                return;
            }


            //int rowIndex = _spdJyutyuList_Sheet1.ActiveRowIndex;
            int rowIndex = GetActiveSheetViewBySpdJyutyuList().ActiveRowIndex;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row = getSelectJyutyuData(rowIndex);

            if (row.hb1TouFlg != "1")
            {
                //MessageBox.Show("統合された受注内容ではありません。", "明細登録", MessageBoxButtons.OK);//TODO
                MessageUtility.ShowMessageBox(MessageCode.HB_W0067, null, "明細登録", MessageBoxButtons.OK);
                return;
            }

            //実行確認 
            if (DialogResult.OK != MessageUtility.ShowMessageBox(MessageCode.HB_C0017,
                null, "統合取消", MessageBoxButtons.OKCancel))
            {
                return;
            }

            DetailProcessController.MergeCancelJyutyuDataParam param = new DetailProcessController.MergeCancelJyutyuDataParam();

            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            Isid.KKH.Common.KKHSchema.Detail dsTougouSaki = new Isid.KKH.Common.KKHSchema.Detail();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow addRow = dsTougouSaki.THB1DOWN.NewTHB1DOWNRow();
            addRow.hb1UpdApl = AplId;
            addRow.hb1UpdTnt = _naviParameter.strEsqId;
            addRow.hb1EgCd = row.hb1EgCd;
            addRow.hb1TksKgyCd = row.hb1TksKgyCd;
            addRow.hb1TksBmnSeqNo = row.hb1TksBmnSeqNo;
            addRow.hb1TksTntSeqNo = row.hb1TksTntSeqNo;
            addRow.hb1Yymm = row.hb1Yymm;
            addRow.hb1JyutNo = row.hb1JyutNo;
            addRow.hb1JyMeiNo = row.hb1JyMeiNo;
            addRow.hb1UrMeiNo = row.hb1UrMeiNo;
            addRow.hb1TouFlg = row.hb1TouFlg.PadRight(1, ' ');
            dsTougouSaki.THB1DOWN.AddTHB1DOWNRow(addRow);
            param.dsTougouSaki = dsTougouSaki;
            param.maxUpdDate = row.hb1TimStmp;

            DetailProcessController processController = DetailProcessController.GetInstance();
            MergeCancelJyutyuDataServiceResult result = processController.MergeCancelJyutyuData(param);

            if (result.HasError == true)
            {
                //MessageBox.Show("統合の解除に失敗しました。", "明細登録", MessageBoxButtons.OK);//TODO
                MessageUtility.ShowMessageBox(MessageCode.HB_E0007, null, "明細登録", MessageBoxButtons.OK);
                return;
            }

            //再表示 
            ReSearchJyutyuData();
            if (_spdJyutyuList_Sheet1.RowCount >= rowIndex + 1)
            {
                _spdJyutyuList_Sheet1.SetActiveCell(rowIndex, 0, true);
                _spdJyutyuList_Sheet1.AddSelection(rowIndex, -1, 1, -1);
                spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);
            }
            //MessageBox.Show("統合を解除しました。", "明細登録", MessageBoxButtons.OK);//TODO

            //******************************
            //広告費明細 
            //******************************
            //現在行の明細レコードを表示する 
            DisplayKkhDetail(_spdJyutyuList_Sheet1.ActiveRowIndex);

            MessageUtility.ShowMessageBox(MessageCode.HB_I0010, null, "明細登録", MessageBoxButtons.OK);

            //コントロールを未選択状態にする 
            this.ActiveControl = null;

        }
        #endregion 統合取消

        #region 受注チェック
        /// <summary>
        /// 受注チェック 
        /// </summary>
        protected virtual Boolean UpdateCheckClick()
        {
            //*************************
            //広告費明細の編集状況確認 
            //*************************
            if (!ConfirmEditStatus())
            {
                this.ActiveControl = null;

                return false;
            }

            //実行確認 
            if (DialogResult.OK != MessageUtility.ShowMessageBox(MessageCode.HB_C0016,
                null, "受注チェック", MessageBoxButtons.OKCancel))
            {
                this.ActiveControl = null;

                return false;
            }

            base.ShowLoadingDialog();

            // 業務会計稼働状況チェック
            bool accountOperationStatus = CheckAccountOperationStatus();

            // 業務会計が稼働中の場合 
            if (accountOperationStatus)
            {
                // 受注チェック 
                CheckUpdate();
            }

            //コントロールを未選択状態にする 
            this.ActiveControl = null;

            base.CloseLoadingDialog();

            return true;
        }
         #endregion 受注チェック

        #region 変更・削除チェック
        /// <summary>
        /// 変更・削除チェック
        /// </summary>
        protected virtual Boolean CheckUpdate()
        {
            //********************
            //検索前クリア処理 
            //********************
            InitializeBeforeSearch();

            //*************************************
            //受注登録内容検索 
            //*************************************
            DetailProcessController processController = DetailProcessController.GetInstance();
            //変更削除チェックフラグをTrue 
            findJyutyuDataCond.updateCheckFlag = true;
            FindJyutyuDataByCondServiceResult result = processController.FindJyutyuDataByCond(findJyutyuDataCond);

            //変更削除チェックフラグを元に戻す 
            findJyutyuDataCond.updateCheckFlag = false;

            if (result.HasError == true)
            {
                return true;
            }
            KKHSchema.Detail dsDetail = result.DetailDataSet;
            UpdateSpdDataByJyutyuData(dsDetail);
            //dsDetail.UpdateSpdDataByJyutyuData();
            UpdateSpdData(dsDetail);

            //データソース更新 
            UpdateDataSourceByDetail(dsDetail);

            // 変更があった場合に子ビューを展開する
            //ExpandChildView(_spdJyutyuList_Sheet1);

            //********************
            //検索後チェック処理 
            //********************
            if (CheckAfterSearch() == false)
            {
                return true;
            }

            //********************
            //検索後初期表示処理 
            //********************
            InitializeAfterSearch();

            //2013/03/06 jse okazaki 公文対応　Start
            // 統合の場合、親の「請求」列に処理を行う
            DeleteParentSeikyu(_spdJyutyuList_Sheet1);
            //2013/03/06 jse okazaki 公文対応　End

            // 変更があった場合に子ビューを展開する
            ExpandChildView(_spdJyutyuList_Sheet1);

            return false;
        }

        #endregion 変更・削除チェック

        #region 受注登録内容スプレッド操作

        /// <summary>
        /// 受注登録内容(一覧)の選択範囲変更後の各コントロールの活性／非活性設定 
        /// </summary>
        /// <param name="activeSheet">アクティブのシート</param>
        /// <param name="activeRow">アクティブ行Index</param>
        protected virtual void EnableChangeForSelectJyutyuListRow(SheetView activeSheet, int activeRow)
        {
            //受注登録明細(親)シートがアクティブの場合 
            if (activeSheet == _spdJyutyuList_Sheet1)
            {
                //受注登録内容検索後の状態にする 
                EnableChangeForAfterSearch();
            }
            //子ビューがアクティブの場合  
            else
            {
                //子ビューにフォーカスがある場合はデータ操作を行うボタンは使用させない 
                btnYmChange.Enabled = false;
                btnDelJyutyu.Enabled = false;
                btnMerge.Enabled = false;
                btnMergeCancel.Enabled = false;
                btnRegJyutyu.Enabled = false;
                btnUpdateCheck.Enabled = false;
            }
        }

        /// <summary>
        /// 親シートを活性化する 
        /// </summary>
        private void SetActiveParentWorkBook()
        {
            FarPoint.Win.Spread.SpreadView ParentView;
            FarPoint.Win.Spread.SheetView ChildSheetView;

            //(1)アクティブな子シートビューを取得します 
            ChildSheetView = spdJyutyuList.GetRootWorkbook().GetActiveWorkbook().GetSheetView();

            //(2)親ワークブックを取得します 
            ParentView = spdJyutyuList.GetRootWorkbook().GetSpreadView(spdJyutyuList.Sheets[0], 0, 0);

            //(3)親ワークブックをアクティブにします 
            spdJyutyuList.GetRootWorkbook().SetActiveWorkbook(ParentView);

            //(4)親ワークブック上のセルをアクティブにします 
            ChildSheetView.ClearSelection();
            //spdJyutyuList.Sheets[0].SetActiveCell(ParentView.ParentRowIndex, 0);
            spdJyutyuList.Sheets[0].AddSelection(spdJyutyuList.Sheets[0].ActiveRowIndex, -1, 1, -1);
            spdJyutyuList.Invalidate();
        }
        #endregion 受注登録内容スプレッド操作
        #region 全般
        /// <summary>
        /// MouseMoveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void MouseMoveCommon(object sender, MouseEventArgs e)
        {
            tslCnt.Text = njToolTip1.GetToolTip((Control)sender);
        }

        /// <summary>
        /// MouseLeaveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void MouseLeaveCommon(object sender, EventArgs e)
        {
            tslCnt.Text = "";
        }

        /// <summary>
        /// 指定した受注登録内容(一覧)の行に紐づく検索受注登録内容データを取得する 
        /// </summary>
        /// <param name="rowIndex">受注登録内容(一覧)の行インデックス</param>
        /// <returns></returns>
        protected KKHSchema.Detail.JyutyuDataRow getSelectJyutyuData(int rowIndex)
        {
            SheetView activeSheet = GetActiveSheetViewBySpdJyutyuList();
            if (rowIndex < 0)
            {
                rowIndex = activeSheet.ActiveRowIndex;
            }

            //アクティブシートが受注登録一覧(親)ではない場合は親シートの行インデックスに置き換える 
            rowIndex = SetRowIndex(activeSheet, rowIndex);

            return _dsDetail.JyutyuData.FindByrowNum((int)_spdJyutyuList_Sheet1.Cells[rowIndex, COLIDX_JLIST_ROWNUM].Value);
        }

        /// <summary>
        /// 明細の編集中かを確認し、編集中の場合は編集を破棄していいか確認するメッセージを表示する 
        /// </summary>
        /// <returns>確認結果(True：未編集orメッセージではいを選択、False：編集中かつメッセージでいいえを選択)</returns>
        protected bool ConfirmEditStatus()
        {
            // 編集内容破棄ステータスをクリア
            confirmEditState = false;

            if (kkhDetailUpdFlag)
            {
                //string msgText = "入力した明細が登録されていません。\n内容を破棄して続けますか？";
                if (MessageUtility.ShowMessageBox(MessageCode.HB_W0070, 
                    null, "明細登録", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return false;
                }
            }

            // 編集内容破棄ステータスを更新
            confirmEditState = true;

            return true;
        }

        /// <summary>
        /// 受注登録内容(一覧)のアクティブなシートを取得します 
        /// </summary>
        /// <returns></returns>
        protected SheetView GetActiveSheetViewBySpdJyutyuList()
        {
            return spdJyutyuList.GetRootWorkbook().GetActiveWorkbook().GetSheetView();
            //return _spdJyutyuList_Sheet1;
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

        /// <summary>
        /// 選択している受注登録内容のデータから更新日付の最大値を取得する。 
        /// </summary>
        /// <returns></returns>
        private DateTime GetMaxUpdDateBySelection()
        {
            DateTime maxUpdDate = new DateTime();
            //選択行の取得 
            CellRange[] cellRanges = SortCellRangesByRowIdx(_spdJyutyuList_Sheet1.GetSelections());
            foreach (CellRange cellRange in cellRanges)
            {
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    //選択されている受注登録内容の行数分の処理を繰り返す 
                    int rowIndex = cellRange.Row + i;
                    KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(rowIndex);

                    if (maxUpdDate == null || maxUpdDate.CompareTo(dataRow.hb1TimStmp) < 0)
                    {
                        maxUpdDate = dataRow.hb1TimStmp;
                    }
                }
            }
            return maxUpdDate;
        }

        /// <summary>
        /// 受注登録内容のActiveな行のデータから更新日付の最大値を取得する。 
        /// </summary>
        /// <returns></returns>
        private DateTime GetMaxUpdDateByActive()
        {
            DateTime maxUpdDate = new DateTime();

            KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(_spdJyutyuList_Sheet1.ActiveRowIndex);
            maxUpdDate = dataRow.hb1TimStmp;

            return maxUpdDate;
        }

        /// <summary>
        /// 業務会計稼働状況チェック 
        /// </summary>
        /// <returns></returns>
        private bool CheckAccountOperationStatus()
        {
            CommonProcessController processController = CommonProcessController.GetInstance();
            accountOperationStatusResult result = processController.CheckAccountOperationStatus(KKHSecurityInfo.GetInstance().UserEsqId);

            // エラーの場合 
            if (result.errorInfo != null && result.errorInfo.error)
            {
                MessageUtility.ShowMessageBox(result.errorInfo.errorCode, null, "明細登録", MessageBoxButtons.OK);
                this.Close();
                return false;
            }
            // 業務会計が停止中の場合 
            if (result.accountOperationStatus == false)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0097, null, "明細登録", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        /// <summary>
        /// データソースを更新します。 
        /// </summary>
        /// <param name="dsDetail">広告費明細入力データセット</param>
        private void UpdateDataSourceByDetail(Isid.KKH.Common.KKHSchema.Detail dsDetail)
        {
            _dsDetail.Clear();
            _dsDetail.Merge(dsDetail);
            _dsDetail.AcceptChanges();
        }
        #endregion 全般

        #endregion 処理別

        #region 共通化検討
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string ConvertDBSpace(string str)
        {
            if (str != null && str == "")
            {
                return " ";
            }
            return str;
        }

        /// <summary>
        /// CellRange配列をRowの値でソートします 
        /// </summary>
        /// <param name="cellRanges"></param>
        /// <returns></returns>
        protected CellRange[] SortCellRangesByRowIdx(CellRange[] cellRanges)
        {
            Array.Sort(cellRanges, CompareByRowIndex);
            //Array.Sort(cellRanges, delegate(CellRange x, CellRange y) { return x.Row.CompareTo(y.Row); });
            return cellRanges;
        }

        private static int CompareByRowIndex(CellRange x, CellRange y)
        {
            return x.Row - y.Row;
        }

        #endregion 共通化検討
        # region メソッド

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtJyuNo_TextChanged(object sender, EventArgs e)
        {
            txtJyuNo.Text = RemoveWrapChar(txtJyuNo.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldStr"></param>
        /// <returns></returns>
        private string RemoveWrapChar(string oldStr)
        {
            string newStr = oldStr;

            string[] wrappChar = new string[]{"'"};
            foreach (string repStr in wrappChar)
            {
                newStr = newStr.Replace(repStr, "");
            }

            return newStr;
        }

        /// <summary>
        /// 明細入力済かチェックする 
        /// </summary>
        /// <param name="rowCount">選択行数</param>
        /// <returns>
        /// true    : 明細入力済 
        /// false   : 明細未入力 
        /// </returns>
        protected virtual bool IsInputDetail(int rowCount)
        {
            if (rowCount > 1 && kkhDetailUpdFlag)
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// 活性化しているシートが受注登録一覧(親)ではない場合、受注登録一覧(親)の行インデックスに置き換える 
        /// </summary>
        /// <param name="pSheet"></param>
        /// <param name="pRowIdx"></param>
        /// <returns></returns>
        private int SetRowIndex(SheetView pSheet, int pRowIdx) 
        {
            int rowIdx = pRowIdx;

            //活性化しているシートが受注登録一覧(親)ではない場合 
            if (pSheet != _spdJyutyuList_Sheet1)
            {
                //受注登録一覧(親)の行インデックスに置き換える 
                rowIdx = pSheet.ParentRowIndex;
            }

            return rowIdx;
        }

        #region 広告費明細検索保留対応関連

        /// <summary>
        /// 明細検索ステータスをクリアする 
        /// </summary>
        protected void DetailSearchStateClear()
        {
            // 検索保留ステータス 
            detailSearchSuspendState = false;
        }

        /// <summary>
        /// 明細検索を保留する 
        /// </summary>
        protected void DetailSearchSuspend()
        {
            detailSearchSuspendState = true;
        }

        /// <summary>
        /// 明細検索の保留を解除する 
        /// </summary>
        protected void DetailSearchResume()
        {
            if (detailSearchSuspendState)
            {
                detailSearchSuspendState = false;
            }
        }

        /// <summary>
        /// 明細検索を実行する 
        /// </summary>
        /// <param name="state">強制実行ステータス</param>
        /// <param name="rowIndex">表示し直す行</param>
        protected void DetailSearchExecute(Boolean state, int rowIndex)
        {
            if (!detailSearchSuspendState || state)
            {
                kkhDetailSearchEvent = string.Empty;

                detailSearchSuspendState = true;

                _spdJyutyuList_Sheet1.SetActiveCell(rowIndex, 0, true);

                _spdJyutyuList_Sheet1.AddSelection(rowIndex, -1, 1, -1);

                spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

                detailSearchSuspendState = false;

                DisplayKkhDetail(rowIndex);

                EnableChangeForSelectJyutyuListRow(GetActiveSheetViewBySpdJyutyuList(), rowIndex);
            }
        }

        /// <summary>
        /// 画面を更新する（受注リストに変更がない場合） 
        /// </summary>
        /// <param name="paramKey"></param>
        protected void DisplayUpdate()
        {
            String key = String.Empty;

            if (_spdJyutyuList_Sheet1.Rows.Count > 0)
            {
                key = _spdJyutyuList_Sheet1.Cells[_spdJyutyuList_Sheet1.ActiveRowIndex, COLIDX_JLIST_URIMEINO].Text.Trim();
            }

            DisplayUpdate(key);
        }

        /// <summary>
        /// 画面を更新する（受注NO指定）

        /// </summary>
        /// <param name="paramKey"></param>
        protected void DisplayUpdate(String paramKey)
        {
            DetailSearchStateClear();
            DetailSearchSuspend();
            ReSearchJyutyuData();
            DetailSearchResume();

            Boolean state = false;
            int index = 0;

            if (!String.IsNullOrEmpty(paramKey))
            {
                // カーソル位置の復元（ソートに対応するために全検索する） 
                for (int i = 0; i < _spdJyutyuList_Sheet1.Rows.Count; i++)
                {
                    String key = _spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_URIMEINO].Text.Trim();
                    if (!String.Equals(key, paramKey))
                    {
                        // 次の行を検索
                        continue;
                    }
                    state = true;
                    index = i;
                    break;
                }
            }

            // 明細検索
            if (state)
            {
                // キーが見つかった場合 
                DetailSearchExecute(false, index);
            }
            else if (_spdJyutyuList_Sheet1.Rows.Count > 0)
            {
                // キーが見つからなかった場合（受注削除や選択統合） 
                DetailSearchExecute(false, 0);
            }
        }

        #endregion

        /// <summary>
        /// 年月変更タイプの設定 
        /// </summary>
        /// <returns></returns>
        protected virtual int GetCngYYmmMode()
        {
            return 0;
        }

        /// <summary>
        /// 検索機能（追加分）を用いる場合のLocationの設定  
        /// </summary>
        /// (2013/02/01 追加 JSE A.Naito) 
        /// <returns></returns>
        private void SetLocation()
        {
            if (txtYmdTo.Visible && !txtKenMei.Visible)
            {
                //期間検索機能を用いる場合、検索条件コントロールのサイズ、位置を変更する。 
                //******************
                //検索条件部 
                //******************
                groupBox1.Size = new Size(886, 75);

                txtYmd.Location = new Point(55, 17);
                lblKikan.Location = new Point(140, 21);
                txtYmdTo.Location = new Point(160, 17);

                label3.Location = new Point(260, 21);
                label4.Location = new Point(260, 47);
                cmbGymKbn.Location = new Point(315, 17);
                txtJyuNo.Location = new Point(315, 42);

                pnlTmSp.Location = new Point(518, 15);
                pnlOrder.Location = new Point(518, 45);

                lblKenMei.Location = new Point(611, 47);
                txtKenMei.Size = new Size(65, 19);
                txtKenMei.Location = new Point(643, 43);

                //*******************
                //ボタン類
                //*******************
                btnSch.Location = new Point(595, 15);
                btnUpdateCheck.Location = new Point(734, 23);
            }
            else if(!txtYmdTo.Visible && txtKenMei.Visible)
            {
                //件名検索機能を用いる場合、検索条件コントロールのサイズ、位置を変更する。 
                //******************
                //検索条件部 
                //******************
                groupBox1.Size = new Size(836, 75);

                txtYmd.Location = new Point(76, 17);
                lblKikan.Location = new Point(50, 21);
                txtYmdTo.Location = new Point(363, 42);

                label3.Location = new Point(190, 21);
                label4.Location = new Point(190, 47);
                cmbGymKbn.Location = new Point(255, 17);
                txtJyuNo.Location = new Point(255, 42);

                pnlTmSp.Location = new Point(458, 15);
                pnlOrder.Location = new Point(458, 45); 
                
                lblKenMei.Location = new Point(599, 21);
                txtKenMei.Size = new Size(187, 19);
                txtKenMei.Location = new Point(634, 18);

                //*******************
                //ボタン類
                //*******************
                btnSch.Location = new Point(708, 42);
                btnUpdateCheck.Location = new Point(847, 23);
            }
            else if (txtYmdTo.Visible && txtKenMei.Visible)
            {
                //期間検索機能と件名検索機能を用いる場合、検索条件コントロールのサイズ、位置を変更する。 
                //******************
                //検索条件部 
                //******************
                groupBox1.Size = new Size(886, 75);

                txtYmd.Location = new Point(55, 17);
                lblKikan.Location = new Point(140, 21);
                txtYmdTo.Location = new Point(160, 17);

                label3.Location = new Point(260, 21);
                label4.Location = new Point(260, 47);
                cmbGymKbn.Location = new Point(315, 17);
                txtJyuNo.Location = new Point(315, 42);

                pnlTmSp.Location = new Point(518, 15);
                pnlOrder.Location = new Point(518, 45);

                lblKenMei.Location = new Point(649, 21);
                txtKenMei.Size = new Size(187, 19);
                txtKenMei.Location = new Point(684, 18);

                //*******************
                //ボタン類
                //*******************
                btnSch.Location = new Point(758, 42);
                btnUpdateCheck.Location = new Point(897, 23);
            }
            else
            {
                //******************
                //検索条件部 
                //******************
                groupBox1.Size = new Size(715, 75);

                txtYmd.Location = new Point(76, 17);
                lblKikan.Location = new Point(50, 21);
                txtYmdTo.Location = new Point(363, 42);

                label3.Location = new Point(190, 21);
                label4.Location = new Point(190, 47);
                cmbGymKbn.Location = new Point(255, 17);
                txtJyuNo.Location = new Point(255, 42);

                pnlTmSp.Location = new Point(458, 15);
                pnlOrder.Location = new Point(458, 45);

                lblKenMei.Location = new Point(611, 47);
                txtKenMei.Size = new Size(65, 19);
                txtKenMei.Location = new Point(643, 43);

                //*******************
                //ボタン類
                //*******************
                btnSch.Location = new Point(595, 15);
                btnUpdateCheck.Location = new Point(734, 23);
            }
        }

        # endregion メソッド 

    }
}