using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;

using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Toh.Schema;
using Isid.KKH.Toh.Utility;


namespace Isid.KKH.Toh.View.Detail
{
    public partial class DetailToh : DetailForm
    {

        #region 定数.

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "DtlToh";
        /// <summary>
        /// 件名列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KENMEI = 0;
        /// <summary>
        /// 媒体名列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_BAITAINM = 1;
        /// <summary>
        /// 料金列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_RYOUKIN = 2;
        // 消費税対応 2013/10/08 update HLC H.Watabe start
        /// <summary>
        /// 消費税率列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SHOHIZEI = 3;
        /// <summary>
        /// スペース列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_SPACE = 3;
        public const int COLIDX_MLIST_SPACE = 4;
        /// <summary>
        /// スペース２列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_SPACE2 = 4;
        public const int COLIDX_MLIST_SPACE2 = 5;
        /// <summary>
        /// 単価列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_TANKA = 5;
        public const int COLIDX_MLIST_TANKA = 6;
        /// <summary>
        /// 区分列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_KBN = 6;
        public const int COLIDX_MLIST_KBN = 7;
        /// <summary>
        /// 掲載日列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_KEISAIDT = 7;
        public const int COLIDX_MLIST_KEISAIDT = 8;
        /// <summary>
        /// 媒体コード列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_BAITAICD = 8;
        public const int COLIDX_MLIST_BAITAICD = 9;
        /// <summary>
        /// 受注NO列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_JYUTNO = 9;
        public const int COLIDX_MLIST_JYUTNO = 10;
        /// <summary>
        /// 受注明細NO列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_JYMEINO = 10;
        public const int COLIDX_MLIST_JYMEINO = 11;
        /// <summary>
        /// 売上明細NO列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_URMEINO = 11;
        public const int COLIDX_MLIST_URMEINO = 12;
        /// <summary>
        /// 件名変更FLG列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_KENMEICHGFLG = 12;
        public const int COLIDX_MLIST_KENMEICHGFLG = 13;
        /// <summary>
        /// 納品区分列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_NOUHINKBN = 13;
        public const int COLIDX_MLIST_NOUHINKBN = 14;
        /// <summary>
        /// 枠フラグインデックス.
        /// </summary>
        //public const int COLIDX_MLIST_WAKFLG = 14;
        public const int COLIDX_MLIST_WAKFLG = 15;
        // 消費税対応 2013/10/08 update HLC H.Watabe end

        #endregion 定数.

        #region メンバ変数.

        private KKHNaviParameter _naviParameter = new KKHNaviParameter();

        #endregion メンバ変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DetailToh()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ.

        #region オーバーライド.

        /// <summary>
        /// スプレッド全体に対する初期表示の設定を行う.
        /// </summary>
        protected override void InitDesignForSpdJyutyuListSpread()
        {
            base.InitDesignForSpdJyutyuListSpread();
        }

        /// <summary>
        /// スプレッドの列に対する初期表示の設定を行う.
        /// </summary>
        /// <param name="col"></param>
        protected override void InitDesignForSpdJyutyuListColumns(Column col)
        {
            base.InitDesignForSpdJyutyuListColumns(col);

        }

        /// <summary>
        /// 得意先別に表示対象外列の非表示処理を行う.
        /// </summary>
        protected override void VisibleColumns()
        {
            //親クラスの行っている共通処理を実行.
            base.VisibleColumns();

            foreach (Column col in base._spdJyutyuList_Sheet1.Columns)
            {
                if (col.Index == COLIDX_JLIST_TOROKU) { col.Visible = true; }                  //登録.
                if (col.Index == COLIDX_JLIST_TOGO) { col.Visible = false; }                   //統合.
                if (col.Index == COLIDX_JLIST_DAIUKE){ col.Visible = true; }                   //代受.
                if (col.Index == COLIDX_JLIST_SEIKYU) { col.Visible = false; }                 //請求.
                if (col.Index == COLIDX_JLIST_URIMEINO) { col.Visible = true; }                //売上明細NO.
                if (col.Index == COLIDX_JLIST_GPYNO) { col.Visible = false; }                  //請求原票NO.
                if (col.Index == COLIDX_JLIST_SEIYYMM){ col.Visible = true; }                  //請求年月.
                if (col.Index == COLIDX_JLIST_GYOMKBN){ col.Visible = true; }                  //業務区分.
                if (col.Index == COLIDX_JLIST_KENMEI){ col.Visible = true; }                   //件名.
                if (col.Index == COLIDX_JLIST_BAITAINM) { col.Visible = true;}                 //媒体名.
                if (col.Index == COLIDX_JLIST_HIMOKUNM){ col.Visible = true; }                 //費目名.
                if (col.Index == COLIDX_JLIST_KYOKUSHICD){ col.Visible = false; }              //局誌CD.
                if (col.Index == COLIDX_JLIST_SEIKINGAKU){ col.Visible = true; }               //請求金額.
                if (col.Index == COLIDX_JLIST_KIKAN){ col.Visible = false; }                   //期間.
                if (col.Index == COLIDX_JLIST_DANTANKA){ col.Visible = true; }                 //段単価.
                if (col.Index == COLIDX_JLIST_DANSU){ col.Visible = true; }                    //段数.
                if (col.Index == COLIDX_JLIST_TORIRYOKIN){ col.Visible = true; }               //取料金.
                if (col.Index == COLIDX_JLIST_NEBIKIRITSU){ col.Visible = true; }              //値引率.
                if (col.Index == COLIDX_JLIST_NEBIKIGAKU){ col.Visible = true; }               //値引額.
                if (col.Index == COLIDX_JLIST_ZEIRITSU){ col.Visible = true; }                 //消費税率.
                if (col.Index == COLIDX_JLIST_ZEIGAKU){ col.Visible = true; }                  //消費税額.
                if (col.Index == COLIDX_JLIST_GOUKEIKINGAKU){ col.Visible = false; }           //受注請求金額.
                if (col.Index == COLIDX_JLIST_OLDSEIYYMM){ col.Visible = true; }               //変更前請求年月.
            }
        }

        /// <summary>
        /// セルの色付け処理を行う.
        /// </summary>
        protected override void ChangeColor()
        {
            //親クラスの行っている共通処理を実行.
            base.ChangeColor();

            for (int i = 0; i < _spdJyutyuList_Sheet1.Rows.Count; i++)
            {
                Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(i);
                if (dataRow.hb1TouFlg == "1")
                {
                    //統合フラグ="1"の行は背景色を変更.
                    _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(255, 255, 208);
                }
                if (dataRow.hb1YymmOld != "")
                {
                    //変更前請求年月が設定されている(年月変更が行われている)場合は請求年月を赤文字にする.
                    _spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_SEIYYMM].ForeColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// 広告費明細データの検索・表示.
        /// </summary>
        /// <param name="rowIdx"></param>
        protected override void DisplayKkhDetail(int rowIdx)
        {
            //親クラスの行っている共通処理を実行.
            base.DisplayKkhDetail(rowIdx);

            //***************************************
            //表示用広告費明細データの編集・表示.
            //***************************************
            _dsDetailToh.KkhDetail.Clear();
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow row in _dsDetail.THB2KMEI.Rows)
            {
                DetailDSToh.KkhDetailRow addRow = _dsDetailToh.KkhDetail.NewKkhDetailRow();

                addRow.kenmei = row.hb2Name8;
                addRow.baitaiNm = row.hb2Name2;
                addRow.ryoukin = row.hb2SeiGak;
                // 消費税対応 2013/10/08 add HLC H.Watabe start
                addRow.shohizei = row.hb2Ritu1;
                // 消費税対応 2013/10/08 add HLC H.Watabe end
                addRow.space = row.hb2Code1;
                addRow.space2 = row.hb2Name11;
                addRow.tanka = row.hb2Kngk1;
                addRow.kbn = row.hb2Kbn1;
                if (row.hb2Date1.Trim().Length == 8)
                {
                    addRow.keisaiDt = row.hb2Date1.Insert(6, "/").Insert(4, "/");
                }
                else
                {
                    addRow.keisaiDt = row.hb2Date1;
                }
                addRow.baitaiCd = row.hb2Code2;
                addRow.jyutNo = row.hb2JyutNo;
                addRow.jyMeiNo = row.hb2JyMeiNo;
                addRow.urMeiNo = row.hb2UrMeiNo;
                addRow.kenmeiChgFlg = row.hb2MeihnFlg;
                addRow.nouhinKbn = row.hb2Kbn2;
                addRow.wakFlg = row.hb2Name12;

                _dsDetailToh.KkhDetail.AddKkhDetailRow(addRow);
            }
            _dsDetailToh.KkhDetail.AcceptChanges();

            ////スプレッドデザインの再初期化.
            //InitializeDesignForSpdKkhDetail();
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(0, 0, 1, 1);
            }

            //受注登録内容の選択行情報の取得.
            SheetView activeSheet = GetActiveSheetViewBySpdJyutyuList();
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(rowIdx);

            //***************************************
            //ボタン類の使用可・不可設定.
            //***************************************
            if (dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.NewsPaper)
            {
                //請求区分が「新聞」は明細関係のボタン使用可.
                btnDetailInput.Enabled = true;
                btnDetailDel.Enabled = true;
                btnDetailRegister.Enabled = true;
                btnDivide.Enabled = true;
            }
            else
            {
                //請求区分が「新聞」以外は明細関係のボタン使用不可.
                btnDetailInput.Enabled = false;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = false;
                btnDivide.Enabled = false;
            }

            if (_dsDetailToh.KkhDetail.Rows.Count > 0)
            {
                //広告費明細データが既にある場合は分割・削除は可.
                btnDetailDel.Enabled = true;
                btnDivide.Enabled = true;
            }
            else
            {
                //広告費明細データがない場合は分割・削除は不可.
                btnDetailDel.Enabled = false;
                btnDivide.Enabled = false;
            }

            //******************************
            //差額・計ラベル.
            //******************************
            //差額計算.
            CalculateSagaku(dataRow);
        }

        /// <summary>
        /// 受注登録内容検索前チェック処理.
        /// </summary>
        /// <returns></returns>
        protected override Boolean CheckBeforeSearch()
        {
            //親クラスの行っている共通処理を実行.
            if (base.CheckBeforeSearch() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 受注登録内容検索前クリア処理.
        /// </summary>
        protected override void InitializeBeforeSearch()
        {
            //親クラスの行っている共通処理を実行.
            base.InitializeBeforeSearch();

            //差額・計ラベル.
            lblGoukeiValue.Text = "";
            lblSagakuValue.Text = "";

            //***************************************
            //ボタン類の使用可・不可設定.
            //***************************************
            btnBulkRegister.Enabled = false;
            btnDetailInput.Enabled = false;
            btnDivide.Enabled = false;
            btnDetailDel.Enabled = false;
            btnDetailRegister.Enabled = false;
        }

        /// <summary>
        /// 受注登録内容検索後チェック処理.
        /// </summary>
        /// <returns></returns>
        protected override Boolean CheckAfterSearch()
        {
            //親クラスの行っている共通処理を実行.
            if (base.CheckAfterSearch() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 受注登録内容検索後初期表示処理.
        /// </summary>
        protected override void InitializeAfterSearch()
        {
            //親クラスの行っている共通処理を実行.
            base.InitializeAfterSearch();

            //***************************************
            //ボタン類の使用可・不可設定.
            //***************************************
            EnableChangeForAfterSearch();
        }

        /// <summary>
        /// 受注削除処理実行前チェック.
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeDelJyutyu()
        {
            if (base.CheckBeforeDelJyutyu() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 受注削除後の初期化処理.
        /// </summary>
        protected override void InitAfterDelJyutyu()
        {
            //親クラスの行っている共通処理を実行.
            base.InitAfterDelJyutyu();

            //削除の結果、表示するデータがなくなった場合.
            if (_spdJyutyuList_Sheet1.Rows.Count == 0)
            {
                //ボタンの使用不可.
                btnBulkRegister.Enabled = false;
                btnDetailInput.Enabled = false;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = false;
                btnDivide.Enabled = false;
                btnUpdateCheck.Enabled = false;
                //差額・計.
                lblSagakuValue.Text = "";
                lblGoukeiValue.Text = "";

                return;
            }
        }

        /// <summary>
        /// 年月変更処理実行前チェック.
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeYmChange()
        {
            if (base.CheckBeforeYmChange() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 新規作成ダイアログ表示前チェック.
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeRegJyutyu()
        {
            return base.CheckBeforeRegJyutyu();
        }

        /// <summary>
        /// MouseMoveイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseMoveCommon(object sender, MouseEventArgs e)
        {
            base.MouseMoveCommon(sender, e);
        }

        /// <summary>
        /// MouseLeaveイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseLeaveCommon(object sender, EventArgs e)
        {
            base.MouseLeaveCommon(sender, e);
        }

        /// <summary>
        /// 受注登録内容(一覧)でフォーカスがあるビューによってコントロールの制御を行う.
        /// </summary>
        /// <param name="activeSheet">アクティブのシート</param>
        /// <param name="activeRow">アクティブ行Index</param>
        protected override void EnableChangeForSelectJyutyuListRow(SheetView activeSheet, int activeRow)
        {
            base.EnableChangeForSelectJyutyuListRow(activeSheet, activeRow);

            //受注登録明細(親)シートがアクティブの場合.
            if (activeSheet == _spdJyutyuList_Sheet1)
            {
                //受注登録内容検索後の状態にする.
                EnableChangeForAfterSearch();
            }
            else
            {
                //子ビューにフォーカスがある場合はデータ操作を行うボタンは使用させない.
                btnBulkRegister.Enabled = false;
                //アクティブなのが子ビューの場合は明細関係のボタン使用不可.
                btnDetailInput.Enabled = false;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = false;
                btnDivide.Enabled = false;
                btnUpdateCheck.Enabled = false;
            }
        }

        /// <summary>
        /// 受注スプレッドタブを変更イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void tabHed_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.tabHed_SelectedIndexChanged(sender, e);

            //[詳細／履歴]タブが選択された場合.
            if (tabHed.SelectedIndex == 1)
            {
                ////[明細作成]を非表示とする.
                //_spdJyutyuRireki_Sheet1.Columns[COLIDX_JRIREKI_DTLTOROKU].Visible = false;

                //受注履歴スプレッドの件数分処理する.
                int rowCnt = _spdJyutyuRireki_Sheet1.RowCount - 1;
                if (rowCnt > -1)
                {
                    for (int i = rowCnt; i > -1; i--)
                    {
                        //[明細作成]が○以外の場合.
                        if (!_spdJyutyuRireki_Sheet1.Cells[i, COLIDX_JRIREKI_DTLTOROKU].Value.Equals("○"))
                        {
                            //行を削除する.
                            _spdJyutyuRireki_Sheet1.Rows[i].Remove();
                        }
                    }
                }
                //[明細作成]を非表示とする.
                _spdJyutyuRireki_Sheet1.Columns[COLIDX_JRIREKI_DTLTOROKU].Visible = false;
            }

        }

        /// <summary>
        /// 受注チェック.
        /// </summary>
        /// <returns></returns>
        protected override bool UpdateCheckClick()
        {
            if (base.UpdateCheckClick() == false)
            {
                return false;
            }

            // オペレーションログの出力.
            KKHLogUtilityToh.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityToh.KINO_ID_OPERATION_LOG_UpdCheck, KKHLogUtilityToh.DESC_OPERATION_LOG_UpdCheck);

            return true;
        }

        #endregion オーバーライド.

        #region イベント.

        /// <summary>
        /// 画面遷移するたびに発生します。.
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void DetailToh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParameter = (KKHNaviParameter)arg.NaviParameter;
            }

            //選択状態を解除.
            this.ActiveControl = null;
        }

        /// <summary>
        /// フォームロードイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailToh_Shown(object sender, EventArgs e)
        {
            InitializeControlToh();
            InitializeDesignForSpdKkhDetail();
        }

        /// <summary>
        /// 明細入力ボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailInput_Click(object sender, EventArgs e)
        {
            // 対象の受注データ、明細データ取得.
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);
            int rowDetailIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;
            // 明細入力画面表示.
            KKHNaviParameter naviParam = new KKHNaviParameter();
            naviParam = _naviParameter;
            naviParam.DataRow = dataRow;
            naviParam.RowDetailIndex = rowDetailIndex;
            naviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1;
            object result = Navigator.ShowModalForm(this, "toDetailInputToh", naviParam);
            if (result == null)
            {
                this.ActiveControl = null;
                return;
            }
            base.kkhDetailUpdFlag = true; //広告費明細変更フラグを更新.

            // 差額計算.
            CalculateSagaku(dataRow);
            // ボタン活性処理.
            btnDivide.Enabled = true;
            btnDetailDel.Enabled = true;
            this.ActiveControl = null;
        }

        /// <summary>
        /// 分割ボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDivide_Click(object sender, EventArgs e)
        {
            // 対象の受注データ、明細データ取得.
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);
            int rowDetailIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

            // 行の追加（選択行の上に追加）.
            _spdKkhDetail_Sheet1.AddRows(rowDetailIndex,1);

            // 選択行の内容を追加行に設定.
            for (int i = 0; i < _spdKkhDetail_Sheet1.ColumnCount; i++)
            {
                _spdKkhDetail_Sheet1.Cells[rowDetailIndex, i].Value = _spdKkhDetail_Sheet1.Cells[rowDetailIndex +1, i].Text;
            }
            _spdKkhDetail_Sheet1.ActiveRowIndex = rowDetailIndex + 1;
            _spdKkhDetail_Sheet1.AddSelection(_spdKkhDetail_Sheet1.ActiveRowIndex, -1, 1, -1);

            // 明細入力画面表示.
            KKHNaviParameter naviParam = new KKHNaviParameter();
            naviParam.DataRow = dataRow;
            naviParam.RowDetailIndex = rowDetailIndex + 1;
            naviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1;
            object result = Navigator.ShowModalForm(this, "toDetailInputToh", naviParam);

            if (result == null)
            {
                _spdKkhDetail_Sheet1.RemoveRows(rowDetailIndex, 1);
                _spdKkhDetail_Sheet1.ActiveRowIndex = rowDetailIndex;
                _spdKkhDetail_Sheet1.AddSelection(_spdKkhDetail_Sheet1.ActiveRowIndex, -1, 1, -1);

                //選択状態を解除.
                this.ActiveControl = null;

                return;
            }
            base.kkhDetailUpdFlag = true; //広告費明細変更フラグを更新.

            // 差額計算.
            CalculateSagaku(dataRow);

            //選択状態を解除.
            this.ActiveControl = null;
        }

        /// <summary>
        /// 明細登録ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailRegister_Click(object sender, EventArgs e)
        {
            //string message = "";
            decimal sagaku = 0M;

            if (decimal.TryParse(lblSagakuValue.Text, out sagaku) == false || sagaku == 0M)
            {
                if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_C0002, null, "明細登録", MessageBoxButtons.YesNo))
                {
                    //選択状態を解除.
                    this.ActiveControl = null;
                    return;
                }
            }
            else
            {
                if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_W0089, null, "明細登録", MessageBoxButtons.YesNo))
                {
                    //選択状態を解除.
                    this.ActiveControl = null;
                    return;
                }
            }

            RegistDetailData();

            //選択状態を解除.
            this.ActiveControl = null;
        }

        /// <summary>
        /// 一括ボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBulkRegister_Click(object sender, EventArgs e)
        {
            //実行確認.
            if (DialogResult.OK != MessageUtility.ShowMessageBox(MessageCode.HB_C0021,
                null, "一括登録", MessageBoxButtons.OKCancel))
            {
                this.ActiveControl = null;
                return;
            }

            // 共通項目の設定.
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();
            String esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            String aplId = "DtlToh";//TODO
            String egCd = _naviParameter.strEgcd;
            String tksKgyCd = _naviParameter.strTksKgyCd;
            String tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            String tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            Isid.KKH.Common.KKHSchema.Detail TouKoudsDetail = new Isid.KKH.Common.KKHSchema.Detail();

            // 選択されている行を取得.
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();
            CellRange[] cellRangeArray = _spdJyutyuList_Sheet1.GetSelections();

            // 対象件数.
            int subjectCount = 0;
            // 対象スプレッドのINDEXリスト.
            ArrayList subjectIndexList = new ArrayList();

            // 選択されている行の件数分、繰り返す.
            foreach (CellRange cellRange in cellRangeArray)
            {
                for (int rowIndex = cellRange.Row; rowIndex < cellRange.Row + cellRange.RowCount; rowIndex++)
                {
                    // 対象行のデータを取得.
                    Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(rowIndex);
                    Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();
                    Isid.KKH.Toh.View.Detail.DetailInputToh detailInputToh = new DetailInputToh();
                    Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow TouKoudsDetailaddrow = TouKoudsDetail.THB1DOWN.NewTHB1DOWNRow();

                    // 請求区分が「新聞」以外の場合、次の行へ.
                    if (dataRow.hb1SeiKbn != KKHSystemConst.SeiKbn.NewsPaper)
                    {
                        continue;
                    }

                    // 明細未登録かつ、媒体コードがある場合.
                    if (string.IsNullOrEmpty(_spdJyutyuList_Sheet1.Cells[rowIndex, COLIDX_JLIST_TOROKU].Value.ToString().Trim())
                        && !string.IsNullOrEmpty(dataRow.hb1Field1.ToString().Trim()))
                    {
                        //THB1DOWNの登録データ編集.
                        thb1DownRow.hb1TimStmp = dataRow.hb1TimStmp;
                        thb1DownRow.hb1UpdApl = dataRow.hb1UpdApl;
                        thb1DownRow.hb1UpdTnt = dataRow.hb1UpdTnt;
                        thb1DownRow.hb1AtuEgCd = dataRow.hb1AtuEgCd;
                        thb1DownRow.hb1EgCd = dataRow.hb1EgCd;
                        thb1DownRow.hb1TksKgyCd = dataRow.hb1TksKgyCd;
                        thb1DownRow.hb1TksBmnSeqNo = dataRow.hb1TksBmnSeqNo;
                        thb1DownRow.hb1TksTntSeqNo = dataRow.hb1TksTntSeqNo;
                        thb1DownRow.hb1JyutNo = dataRow.hb1JyutNo;
                        thb1DownRow.hb1JyMeiNo = dataRow.hb1JyMeiNo;
                        thb1DownRow.hb1UrMeiNo = dataRow.hb1UrMeiNo;
                        thb1DownRow.hb1GpyNo = dataRow.hb1GpyNo;
                        thb1DownRow.hb1GpyoPag = dataRow.hb1GpyoPag;
                        thb1DownRow.hb1SeiNo = dataRow.hb1SeiNo;
                        thb1DownRow.hb1HimkCd = dataRow.hb1HimkCd;
                        thb1DownRow.hb1TouFlg = dataRow.hb1TouFlg;
                        thb1DownRow.hb1Yymm = dataRow.hb1Yymm;
                        thb1DownRow.hb1GyomKbn = dataRow.hb1GyomKbn;
                        thb1DownRow.hb1MsKbn = dataRow.hb1MsKbn;
                        thb1DownRow.hb1TmspKbn = dataRow.hb1TmspKbn;
                        thb1DownRow.hb1KokKbn = dataRow.hb1KokKbn;
                        thb1DownRow.hb1SeiKbn = dataRow.hb1SeiKbn;
                        thb1DownRow.hb1SyoNo = dataRow.hb1SyoNo;
                        thb1DownRow.hb1KKNameKJ = dataRow.hb1KKNameKJ;
                        thb1DownRow.hb1EgGamenType = dataRow.hb1EgGamenType;
                        thb1DownRow.hb1KkakShanKbn = dataRow.hb1KkakShanKbn;
                        thb1DownRow.hb1ToriGak = dataRow.hb1ToriGak;
                        thb1DownRow.hb1SeiTnka = dataRow.hb1SeiTnka;
                        thb1DownRow.hb1SeiGak = dataRow.hb1SeiGak;
                        thb1DownRow.hb1NeviRitu = dataRow.hb1NeviRitu;
                        thb1DownRow.hb1NeviGak = dataRow.hb1NeviGak;
                        thb1DownRow.hb1SzeiKbn = dataRow.hb1SzeiKbn;
                        thb1DownRow.hb1SzeiRitu = dataRow.hb1SzeiRitu;
                        thb1DownRow.hb1SzeiGak = dataRow.hb1SzeiGak;
                        thb1DownRow.hb1HimkNmKJ = dataRow.hb1HimkNmKJ;
                        thb1DownRow.hb1HimkNmKN = dataRow.hb1HimkNmKN;
                        thb1DownRow.hb1TJyutNo = dataRow.hb1TJyutNo;
                        thb1DownRow.hb1TJyMeiNo = dataRow.hb1TJyMeiNo;
                        thb1DownRow.hb1TUrMeiNo = dataRow.hb1TUrMeiNo;
                        thb1DownRow.hb1MSeiFlg = dataRow.hb1MSeiFlg;
                        thb1DownRow.hb1YymmOld = dataRow.hb1YymmOld;
                        thb1DownRow.hb1Field1 = dataRow.hb1Field1;
                        thb1DownRow.hb1Field2 = dataRow.hb1Field2;
                        thb1DownRow.hb1Field3 = dataRow.hb1Field3;
                        thb1DownRow.hb1Field4 = dataRow.hb1Field4;
                        thb1DownRow.hb1Field5 = dataRow.hb1Field5;
                        thb1DownRow.hb1Field6 = dataRow.hb1Field6;
                        thb1DownRow.hb1Field7 = dataRow.hb1Field7;
                        thb1DownRow.hb1Field8 = dataRow.hb1Field8;
                        thb1DownRow.hb1Field9 = dataRow.hb1Field9;
                        thb1DownRow.hb1Field10 = dataRow.hb1Field10;
                        thb1DownRow.hb1Field11 = dataRow.hb1Field11;
                        thb1DownRow.hb1Field12 = dataRow.hb1Field12;

                        //明細を作成するので"1"を設定.
                        thb1DownRow.hb1MeisaiFlg = "1";

                        //登録担当者が空かつ更新者が空でない場合.
                        if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim())
                            && !string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                        {
                            //登録者、更新者両方入れる.
                            //登録者.
                            thb1DownRow.hb1TrkTnt = _naviParameter.strEsqId.Trim();
                            //登録者名.
                            thb1DownRow.hb1TrkTntNm = _naviParameter.strName.Trim();
                            //更新者.
                            thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                            //更新担当者名.
                            thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                        }
                        //登録者が空の場合.
                        else if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()))
                        {
                            //登録者のみを入れる.
                            //登録者.
                            thb1DownRow.hb1TrkTnt = _naviParameter.strEsqId.Trim();
                            //登録者名.
                            thb1DownRow.hb1TrkTntNm = _naviParameter.strName.Trim();
                            //更新者.
                            thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                            //更新担当者名.
                            thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                        }
                        else
                        {
                            //更新者のみを入れる.
                            //更新者.
                            thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                            //更新担当者名.
                            thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                        }

                        //スペース２.
                        thb1DownRow.space2 = detailInputToh.space2ConversionMethod(dataRow.hb1Field11);

                        dtThb1Down.AddTHB1DOWNRow(thb1DownRow);
                        subjectCount++;
                        subjectIndexList.Add(rowIndex);

                        //データが統合されている場合、子の元となったデータに登録担当者、更新者を登録する。.
                        if (dataRow.hb1TouFlg.Equals("1"))
                        {
                            TouKoudsDetailaddrow.hb1UpdApl = base.AplId;
                            TouKoudsDetailaddrow.hb1UpdTnt = _naviParameter.strEsqId;
                            TouKoudsDetailaddrow.hb1EgCd = _naviParameter.strEgcd;
                            TouKoudsDetailaddrow.hb1TksKgyCd = _naviParameter.strTksKgyCd;
                            TouKoudsDetailaddrow.hb1TksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
                            TouKoudsDetailaddrow.hb1TksTntSeqNo = _naviParameter.strTksTntSeqNo;
                            TouKoudsDetailaddrow.hb1Yymm = dataRow.hb1Yymm;
                            TouKoudsDetailaddrow.hb1TouFlg = dataRow.hb1TouFlg;
                            TouKoudsDetailaddrow.hb1JyutNo = dataRow.hb1JyutNo;
                            TouKoudsDetailaddrow.hb1JyMeiNo = dataRow.hb1JyMeiNo;
                            TouKoudsDetailaddrow.hb1UrMeiNo = dataRow.hb1UrMeiNo;
                            TouKoudsDetailaddrow.hb1MeisaiFlg = "1";
                            if (!string.IsNullOrEmpty(thb1DownRow.hb1TrkTntNm))
                            {
                                TouKoudsDetailaddrow.hb1TrkTnt = thb1DownRow.hb1TrkTnt;
                                TouKoudsDetailaddrow.hb1TrkTntNm = thb1DownRow.hb1TrkTntNm;
                            }
                            else
                            {
                                TouKoudsDetailaddrow.hb1TrkTnt = null;
                                TouKoudsDetailaddrow.hb1TrkTntNm = null;
                            }
                            if (!string.IsNullOrEmpty(thb1DownRow.hb1KsnTntNm))
                            {
                                TouKoudsDetailaddrow.hb1KsnTnt = thb1DownRow.hb1KsnTnt;
                                TouKoudsDetailaddrow.hb1KsnTntNm = thb1DownRow.hb1KsnTntNm;
                            }
                            else
                            {
                                TouKoudsDetailaddrow.hb1KsnTnt = null;
                                TouKoudsDetailaddrow.hb1KsnTntNm = null;
                            }
                            TouKoudsDetail.THB1DOWN.AddTHB1DOWNRow(TouKoudsDetailaddrow);
                        }
                    }
                }
            }

            // 対象データが存在しない場合.
            if (subjectCount == 0)
            {
                //選択状態を解除.
                this.ActiveControl = null;
                return;
            }

            dsDetail.THB1DOWN.Merge(dtThb1Down);

            // 一括登録サービス.
            DetailProcessController processController = DetailProcessController.GetInstance();
            RegisterBulkDataServiceResult result = processController.RegisterBulkData(
                esqId, aplId, egCd, tksKgyCd, tksBmnSeqNo, tksTntSeqNo, dsDetail, TouKoudsDetail);

            // エラーの場合.
            if (result.HasError)
            {
                String[] message = result.Note;
                //MessageBox.Show(message[0], "明細登録", MessageBoxButtons.OK); //TODO
                MessageUtility.ShowMessageBox(MessageCode.HB_W0148, message, "明細登録", MessageBoxButtons.OK);
                //MessageUtility.ShowMessageBox(MessageCode.HB_W0095, message, "明細登録", MessageBoxButtons.OK);

                //選択状態を解除.
                this.ActiveControl = null;
                return;
            }

            foreach (Object obj in subjectIndexList)
            {
                DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow((int)obj)];
                Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
                listRow.toroku = "済";
            }

            //MessageBox.Show("登録を完了しました。", "明細登録", MessageBoxButtons.OK);
            MessageUtility.ShowMessageBox(MessageCode.HB_I0001, null, "明細登録", MessageBoxButtons.OK);

            //現在位置の取得.
            int _spdJyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            //受注内容再検索処理.
            base.ReSearchJyutyuData();

            //指定行を元の位置に戻す.
            _spdJyutyuList_Sheet1.SetActiveCell(_spdJyutyuListRowIdx, 0, true);
            _spdJyutyuList_Sheet1.AddSelection(_spdJyutyuListRowIdx, -1, 1, -1);
            spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

            //親の処理を呼ぶ(親のLeaveCellイベントが発生しないので).
            base.DisplayKkhDetail(_spdJyutyuListRowIdx);
            //子の処理を呼ぶ(親↑が呼んでくれないので).
            DisplayKkhDetail(_spdJyutyuListRowIdx);

            //選択状態を解除.
            this.ActiveControl = null;
        }

        /// <summary>
        /// 明細削除ボタン押下時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailDel_Click(object sender, EventArgs e)
        {
            int rowIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

            _spdKkhDetail_Sheet1.RemoveRows(rowIndex, 1);
            base.kkhDetailUpdFlag = true; //広告費明細変更フラグを更新.

            //***************************************
            //ボタン類の使用可・不可設定.
            //***************************************
            if (_spdKkhDetail_Sheet1.Rows.Count > 0)
            {
                //広告費明細データが既にある場合は分割・削除は可.
                btnDetailDel.Enabled = true;
                btnDivide.Enabled = true;
            }
            else
            {
                //広告費明細データがない場合は分割・削除は不可.
                btnDetailDel.Enabled = false;
                btnDivide.Enabled = false;
            }

            //******************************
            //差額・計ラベル.
            //******************************
            //受注登録内容の選択行情報の取得.
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);
            //差額計算.
            CalculateSagaku(dataRow);

            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(_spdKkhDetail_Sheet1.ActiveRowIndex, -1, 1, -1);
            }

            //選択状態を解除.
            this.ActiveControl = null;
        }

        /// <summary>
        /// ヘルプボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //得意先コード.
            string tkskgy = _naviParameter.strTksKgyCd + _naviParameter.strTksBmnSeqNo + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行.
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Detail, this, HelpNavigator.KeywordIndex);
            //HlpClick();
            this.ActiveControl = null;
        }

        #endregion イベント.

        #region メソッド.

        /// <summary>
        /// 差額計算.
        /// </summary>
        /// <param name="dataRow"></param>
        private void CalculateSagaku(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            // 料金合計.
            decimal ryoukinGoukei = 0;

            // 明細の件数分、繰り返す.
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                String ryoukinStr = _spdKkhDetail_Sheet1.Cells[i, 2].Text.Trim();
                // 明細の料金が入力されている場合.
                if (KKHUtility.IsNumeric(ryoukinStr))
                {
                    // 料金合計に加算.
                    ryoukinGoukei = ryoukinGoukei + decimal.Parse(ryoukinStr.Trim());
                }
            }
            // 差額.
            decimal sagaku = dataRow.hb1SeiGak - ryoukinGoukei;
            lblSagakuValue.Text = sagaku.ToString("###,###,###,##0");
            // 合計.
            lblGoukeiValue.Text = ryoukinGoukei.ToString("###,###,###,##0");
        }

        /// <summary>
        /// 広告費明細のデータソース更新.
        /// </summary>
        /// <param name="dsDetailToh"></param>
        private void UpdateDataSourceByDetailDataSetToh(DetailDSToh dsDetailToh)
        {
            _dsDetailToh.Clear();
            _dsDetailToh.Merge(_dsDetailToh);
            _dsDetailToh.AcceptChanges();
        }

        /// <summary>
        /// 各コントロールの初期設定.
        /// </summary>
        private void InitializeControlToh()
        {
            //******************
            //検索条件部.
            //******************
            lblKenMei.Visible = false;
            txtKenMei.Visible = false;
            lblKikan.Visible = false;
            txtYmdTo.Visible = false;

            //列の順番を変更する.
            //[媒体名]と[費目名]を入れ替える.
            _spdJyutyuList_Sheet1.MoveColumn(COLIDX_JLIST_BAITAINM, COLIDX_JLIST_HIMOKUNM, true);

            //*******************
            //ボタン類.
            // 変更・削除チェックボタンを非表示.
            //*******************
            btnBulkRegister.Enabled = false;
            btnDetailInput.Enabled = false;
            btnDetailDel.Enabled = false;
            btnDivide.Enabled = false;
            btnDetailRegister.Enabled = false;
        }

        /// <summary>
        /// 広告費明細スプレッドのデザイン初期化を行う.
        /// </summary>
        private void InitializeDesignForSpdKkhDetail()
        {
            //********************************
            //スプレッド全体の設定.
            //********************************
            _spdKkhDetail_Sheet1.ColumnHeader.Rows[0].Height = 30;

            //********************************
            //列毎の設定 ※デザイナから列に対する設定を行うと変更が反映されないことがあるようなので暫定的にここで行う.
            //********************************
            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                //共通設定.
                col.Locked = true;//セルの編集不可.
                col.AllowAutoFilter = true;//フィルタ機能を有効.
                col.AllowAutoSort = true;  //ソート機能を有効.

                //列毎に異なる設定.
                if (col.Index == COLIDX_MLIST_KENMEI)
                {
                    col.Label = "件名";
                    col.Width = 200;
                }
                else if (col.Index == COLIDX_MLIST_BAITAINM)
                {
                    col.Label = "媒体名";
                    col.Width = 150;
                }
                else if (col.Index == COLIDX_MLIST_RYOUKIN)
                {
                    col.Label = "料金";
                    //col.Width = 100;
                    col.Width = 90;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                // 消費税対応 2013/10/08 add HLC H.Watabe start
                else if (col.Index == COLIDX_MLIST_SHOHIZEI)
                {
                    col.Label = "消費税率";
                    col.Width = 70;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = false;
                    col.CellType = cellType;
                }
                // 消費税対応 2013/10/08 add HLC H.Watabe end
                else if (col.Index == COLIDX_MLIST_SPACE)
                {
                    col.Label = "スペース";
                    col.Width = 70;
                }
                else if (col.Index == COLIDX_MLIST_SPACE2)
                {
                    col.Label = "スペース2";
                    col.Width = 70;
                }
                else if (col.Index == COLIDX_MLIST_TANKA)
                {
                    col.Label = "単価";
                    //col.Width = 100;
                    col.Width = 90;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                else if (col.Index == COLIDX_MLIST_KBN)
                {
                    col.Label = "区分";
                    //col.Width = 50;
                    col.Width = 40;
                }
                else if (col.Index == COLIDX_MLIST_KEISAIDT)
                {
                    col.Label = "掲載日";
                    col.Width = 80;
                }
                else if (col.Index == COLIDX_MLIST_BAITAICD)
                {
                    col.Label = "媒体コード";
                    col.Width = 80;
                }
                else if (col.Index == COLIDX_MLIST_JYUTNO)
                {
                    col.Label = "受注NO";
                    col.Width = 80;
                }
                else if (col.Index == COLIDX_MLIST_JYMEINO)
                {
                    col.Label = "受注明細NO";
                    col.Width = 60;
                }
                else if (col.Index == COLIDX_MLIST_URMEINO)
                {
                    col.Label = "売上明細NO";
                    col.Width = 60;
                }
                else if (col.Index == COLIDX_MLIST_KENMEICHGFLG)
                {
                    col.Label = "件名変更FLG";
                    col.Width = 60;
                }
                else if (col.Index == COLIDX_MLIST_NOUHINKBN)
                {
                    col.Label = "納品区分";
                    col.Width = 40;
                }
                else if (col.Index == COLIDX_MLIST_WAKFLG)
                {
                    col.Label = "枠FLG";
                    col.Width = 30;
                }
            }

            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(0, 0, 1, 1);
            }
        }

        /// <summary>
        /// 受注登録内容検索後の各コントロールの活性／非活性設定.
        /// </summary>
        private void EnableChangeForAfterSearch()
        {
            btnBulkRegister.Enabled = true;
        }

        /// <summary>
        /// 明細登録処理.
        /// </summary>
        private void RegistDetailData()
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            //サービスパラメータ用変数.
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();
            string esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            //DateTime maxUpdDate = new DateTime(2100,1,1);
            DateTime maxUpdDate = new DateTime();

            //*********************************************
            //THB1DOWNの登録データ編集.
            //*********************************************
            //DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(_spdJyutyuList_Sheet1.ActiveRowIndex)];
            //Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            //Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);

            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();

            //thb1DownRow.hb1TimStmp = new DateTime();
            thb1DownRow.hb1UpdApl = AplId;
            thb1DownRow.hb1UpdTnt = _naviParameter.strEsqId;
            thb1DownRow.hb1EgCd = _naviParameter.strEgcd;
            thb1DownRow.hb1TksKgyCd = _naviParameter.strTksKgyCd;
            thb1DownRow.hb1TksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            thb1DownRow.hb1TksTntSeqNo = _naviParameter.strTksTntSeqNo;
            thb1DownRow.hb1Yymm = dataRow.hb1Yymm;
            thb1DownRow.hb1TouFlg = dataRow.hb1TouFlg;
            thb1DownRow.hb1JyutNo = dataRow.hb1JyutNo;
            thb1DownRow.hb1JyMeiNo = dataRow.hb1JyMeiNo;
            thb1DownRow.hb1UrMeiNo = dataRow.hb1UrMeiNo;

            //未請求フラグ.
            if (Isid.KKH.Common.KKHUtility.KKHUtility.DecParse(lblSagakuValue.Text) == 0)
            {
                thb1DownRow.hb1MSeiFlg = "0";
            }
            else
            {
                thb1DownRow.hb1MSeiFlg = "1";
            }

            //明細行が存在する場合.
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                thb1DownRow.hb1MeisaiFlg = "1";
            }
            else
            {
                thb1DownRow.hb1MeisaiFlg = "0";
            }
            //***************************************
            //登録者、更新者の登録
            //***************************************
            thb1DownRow.hb1TrkTnt = string.Empty;
            thb1DownRow.hb1TrkTntNm = string.Empty;
            thb1DownRow.hb1KsnTnt = string.Empty;
            thb1DownRow.hb1KsnTntNm = string.Empty;
            //明細がない場合
            if (thb1DownRow.hb1MeisaiFlg.Equals("0"))
            {
                //登録者、更新者が空の場合
                if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) && string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                    //何もしない
                }
                //登録者がからで、更新者が入っている場合
                else if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) && !string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                    //何もしない
                }
                else
                {
                    //更新者を登録
                    //更新者
                    thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                    //更新担当者名
                    thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                }
            }
            //明細がある場合
            else
            {
                //登録担当者が空かつ更新者が空でない場合
                if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) && !string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                    //登録者、更新者両方入れる
                    //登録者
                    thb1DownRow.hb1TrkTnt = _naviParameter.strEsqId.Trim();
                    //登録者名
                    thb1DownRow.hb1TrkTntNm = _naviParameter.strName.Trim();
                    //更新者
                    thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                    //更新担当者名
                    thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                }
                //登録者が空の場合
                else if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()))
                {
                    //登録者のみを入れる
                    //登録者
                    thb1DownRow.hb1TrkTnt = _naviParameter.strEsqId.Trim();
                    //登録者名
                    thb1DownRow.hb1TrkTntNm = _naviParameter.strName.Trim();
                    //更新者
                    thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                    //更新担当者名
                    thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                }
                else
                {
                    //更新者のみを入れる
                    //更新者
                    thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                    //更新担当者名
                    thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                }
            }

            dtThb1Down.AddTHB1DOWNRow(thb1DownRow);

            dsDetail.THB1DOWN.Merge(dtThb1Down);

            Isid.KKH.Common.KKHSchema.Detail TouKoudsDetail = new Isid.KKH.Common.KKHSchema.Detail();
            //データが統合されている場合、子の元となったデータに登録担当者、更新者を登録する。
            if (dataRow.hb1TouFlg.Equals("1"))
            {
                Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow tokoaddrow = TouKoudsDetail.THB1DOWN.NewTHB1DOWNRow();
                tokoaddrow.hb1UpdApl = base.AplId;
                tokoaddrow.hb1UpdTnt = _naviParameter.strEsqId;
                tokoaddrow.hb1EgCd = _naviParameter.strEgcd;
                tokoaddrow.hb1TksKgyCd = _naviParameter.strTksKgyCd;
                tokoaddrow.hb1TksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
                tokoaddrow.hb1TksTntSeqNo = _naviParameter.strTksTntSeqNo;
                tokoaddrow.hb1Yymm = dataRow.hb1Yymm;
                tokoaddrow.hb1TouFlg = dataRow.hb1TouFlg;
                tokoaddrow.hb1JyutNo = dataRow.hb1JyutNo;
                tokoaddrow.hb1JyMeiNo = dataRow.hb1JyMeiNo;
                tokoaddrow.hb1UrMeiNo = dataRow.hb1UrMeiNo;
                tokoaddrow.hb1MeisaiFlg = thb1DownRow.hb1MeisaiFlg;
                if (!string.IsNullOrEmpty(thb1DownRow.hb1TrkTntNm))
                {
                    tokoaddrow.hb1TrkTnt = thb1DownRow.hb1TrkTnt;
                    tokoaddrow.hb1TrkTntNm = thb1DownRow.hb1TrkTntNm;
                }
                else
                {
                    tokoaddrow.hb1TrkTnt = null;
                    tokoaddrow.hb1TrkTntNm = null;
                }
                if (!string.IsNullOrEmpty(thb1DownRow.hb1KsnTntNm))
                {
                    tokoaddrow.hb1KsnTnt = thb1DownRow.hb1KsnTnt;
                    tokoaddrow.hb1KsnTntNm = thb1DownRow.hb1KsnTntNm;
                }
                else
                {
                    tokoaddrow.hb1KsnTnt = null;
                    tokoaddrow.hb1KsnTntNm = null;
                }
                TouKoudsDetail.THB1DOWN.AddTHB1DOWNRow(tokoaddrow);
            }

            //*********************************************
            //THB2KMEIの登録データ編集.
            //*********************************************
            int jyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;
            Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable dtThb2Kmei = new Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable();
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                object cellValue = null;

                Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow addRow = dtThb2Kmei.NewTHB2KMEIRow();

                addRow.hb2TimStmp = new DateTime();
                addRow.hb2UpdApl = AplId;
                addRow.hb2UpdTnt = _naviParameter.strEsqId;
                addRow.hb2EgCd = _naviParameter.strEgcd;
                addRow.hb2TksKgyCd = _naviParameter.strTksKgyCd;
                addRow.hb2TksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
                addRow.hb2TksTntSeqNo = _naviParameter.strTksTntSeqNo;
                addRow.hb2Yymm = dataRow.hb1Yymm;
                addRow.hb2JyutNo = dataRow.hb1JyutNo;
                addRow.hb2JyMeiNo = dataRow.hb1JyMeiNo;
                addRow.hb2UrMeiNo = dataRow.hb1UrMeiNo;
                addRow.hb2HimkCd = dataRow.hb1HimkCd;
                //addRow.hb2Renbn = (i + 1).ToString("000"); 明細登録件数拡張対応.
                addRow.hb2Renbn = (i + 1).ToString("0000");
                addRow.hb2DateFrom = " ";
                addRow.hb2DateTo = " ";
                addRow.hb2SeiGak = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_RYOUKIN].Value;
                addRow.hb2Hnnert = 0M;
                addRow.hb2HnmaeGak = 0M;
                addRow.hb2NebiGak = 0M;
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEISAIDT].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Date1 = cellValue.ToString().Replace("/", "");
                }
                else
                {
                    addRow.hb2Date1 = " ";
                }
                addRow.hb2Date2 = " ";
                addRow.hb2Date3 = " ";
                addRow.hb2Date4 = " ";
                addRow.hb2Date5 = " ";
                addRow.hb2Date6 = " ";
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KBN].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Kbn1 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Kbn1 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NOUHINKBN].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Kbn2 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Kbn2 = " ";
                }
                addRow.hb2Kbn3 = " ";
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SPACE].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Code1 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Code1 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Code2 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Code2 = " ";
                }
                addRow.hb2Code3 = " ";
                addRow.hb2Code4 = " ";
                addRow.hb2Code5 = " ";
                addRow.hb2Code6 = " ";
                addRow.hb2Name1 = " ";
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAINM].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name2 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name2 = " ";
                }
                addRow.hb2Name3 = " ";
                addRow.hb2Name4 = " ";
                addRow.hb2Name5 = " ";
                addRow.hb2Name6 = " ";
                addRow.hb2Name7 = " ";
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name8 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name8 = " ";
                }
                addRow.hb2Name9 = " ";
                addRow.hb2Name10 = " ";
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SPACE2].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name11 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name11 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_WAKFLG].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name12 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name12 = " ";
                }

                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TANKA].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Kngk1 = (Decimal)cellValue;
                }
                else
                {
                    addRow.hb2Kngk1 = 0M;
                }
                addRow.hb2Kngk2 = 0M;
                addRow.hb2Kngk3 = 0M;
                // 消費税対応 2013/10/08 update HLC H.Watabe start
                addRow.hb2Ritu1 = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHOHIZEI].Value;
                //addRow.hb2Ritu1 = 0M;
                // 消費税対応 2013/10/08 update HLC H.Watabe end
                addRow.hb2Ritu2 = 0M;
                addRow.hb2Sonota1 = " ";
                addRow.hb2Sonota2 = " ";
                addRow.hb2Sonota3 = " ";
                addRow.hb2Sonota4 = " ";
                addRow.hb2Sonota5 = " ";
                addRow.hb2Sonota6 = " ";
                addRow.hb2Sonota7 = " ";
                addRow.hb2Sonota8 = " ";
                addRow.hb2Sonota9 = " ";
                addRow.hb2Sonota10 = " ";
                if (_spdKkhDetail_Sheet1.RowCount >= 2)
                {
                    addRow.hb2BunFlg = "1";
                }
                else
                {
                    addRow.hb2BunFlg = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEICHGFLG].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2MeihnFlg = cellValue.ToString();
                }
                else
                {
                    addRow.hb2MeihnFlg = " ";
                }
                addRow.hb2NebhnFlg = " ";

                dtThb2Kmei.AddTHB2KMEIRow(addRow);
            }
            dsDetail.THB2KMEI.Merge(dtThb2Kmei);
            //dsDetail.AcceptChanges();

            //更新日付最大値の判定.
            //統合されている場合.
            if (dataRow.hb1TouFlg == "1")
            {
                //統合されている受注登録内容のデータから更新日付の最大値を取得する。.
                Isid.KKH.Common.KKHUtility.KKHGetMaxUpdDateByTogo getMaxUpdDateByTogo = new KKHGetMaxUpdDateByTogo();
                maxUpdDate = getMaxUpdDateByTogo.GetMaxUpdDateByTogo(
                            _spdJyutyuList_Sheet1,
                            dataRow.hb1TimStmp,
                            _dsDetail);
            }
            else
            {
                if (maxUpdDate == null || maxUpdDate.CompareTo(dataRow.hb1TimStmp) < 0)
                {
                    maxUpdDate = dataRow.hb1TimStmp;
                }
            }

            foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow thb2KmeiRow in _dsDetail.THB2KMEI.Rows)
            {
                if (maxUpdDate == null || maxUpdDate.CompareTo(thb2KmeiRow.hb2TimStmp) < 0)
                {
                    maxUpdDate = thb2KmeiRow.hb2TimStmp;
                }
            }
            //foreach (Isid.KKH.Common.KKHSchema.Detail.TGA7MSHORow tga7MshoRow in _dsDetail.TGA7MSHO.Rows)
            //{
            //    if (maxUpdDate == null || maxUpdDate.CompareTo(tga7MshoRow.ga7TimStmp) < 0)
            //    {
            //        maxUpdDate = tga7MshoRow.ga7TimStmp;
            //    }
            //}

            DetailProcessController processController = DetailProcessController.GetInstance();
            //UpdateDisplayDataServiceResult result = processController.UpdateDisplayData(esqId, dsDetail, maxUpdDate);
            DetailProcessController.UpdateDisplayDataParam param = new DetailProcessController.UpdateDisplayDataParam();
            param.esqId = esqId;
            param.dsDetail = dsDetail;
            param.maxUpdDate = maxUpdDate;
            param.TouKoudsDetail = TouKoudsDetail;
            UpdateDisplayDataServiceResult result = processController.UpdateDisplayData(param);

            //エラーの場合.
            if (result.HasError)
            {

                //ローディング表示終了.
                base.CloseLoadingDialog();

                if (result.MessageCode == "LOCK-E0001")
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0148, null, "明細登録", MessageBoxButtons.OK);
                }
                else
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0003, null, "明細登録", MessageBoxButtons.OK);
                }
                return;
            }

            base.kkhDetailUpdFlag = false; //広告費明細変更フラグを更新.
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                //明細登録"済"を設定.
                //listRow.toroku = "済";
                _spdJyutyuList_Sheet1.Cells[_spdJyutyuList_Sheet1.ActiveRowIndex, COLIDX_JLIST_TOROKU].Value = "済";
            }
            else
            {
                //明細登録"済"を解除.
                //listRow.toroku = "";
                _spdJyutyuList_Sheet1.Cells[_spdJyutyuList_Sheet1.ActiveRowIndex, COLIDX_JLIST_TOROKU].Value = "";
            }

            //TODO
            //******************************************************************************************
            //保持している受注登録内容データを処理後のデータで更新する.
            //******************************************************************************************
            //foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow updRow in result.DsDetail.THB1DOWN.Rows)
            //{
            //    _dsDetail.JyutyuData.UpdateRowDataByTGADOWNRow(updRow);
            //    _dsDetail.THB1DOWN.UpdateRowData(updRow);
            //}
            //_dsDetail.JyutyuData.AcceptChanges();
            //_dsDetail.THB1DOWN.AcceptChanges();
            //_dsDetail.THB2KMEI.Clear();
            //_dsDetail.THB2KMEI.Merge(result.DsDetail.THB2KMEI);
            //_dsDetail.THB2KMEI.AcceptChanges();
            ////現在位置の取得.
            //int _spdJyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            //base.SearchJyutyuData();

            ////指定行を元の位置に戻す.
            //_spdJyutyuList_Sheet1.SetActiveCell(_spdJyutyuListRowIdx, 0, true);
            //_spdJyutyuList_Sheet1.AddSelection(_spdJyutyuListRowIdx, -1, 1, -1);
            //spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

            ////親の処理を呼ぶ(親のLeaveCellイベントが発生しないので).
            //base.DisplayKkhDetail(_spdJyutyuListRowIdx);
            ////子の処理を呼ぶ(親↑が呼んでくれないので).
            //DisplayKkhDetail(_spdJyutyuListRowIdx);

            DisplayUpdate();

            //ローディング表示終了.
            base.CloseLoadingDialog();

            //MessageBox.Show("広告費明細の登録が完了しました。", "明細登録", MessageBoxButtons.OK);
            MessageUtility.ShowMessageBox(MessageCode.HB_I0012, null, "明細登録", MessageBoxButtons.OK);
        }

        /// <summary>
        /// 統合されている受注登録内容のデータから更新日付の最大値を取得する。.
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="parentMaxUpdDate"></param>
        /// <returns></returns>
        private DateTime GetMaxUpdDateByTogo(int rowIndex, DateTime parentMaxUpdDate)
        {
            DateTime maxUpdDate = new DateTime();

            FarPoint.Win.Spread.SheetView childSheet = _spdJyutyuList_Sheet1.GetChildView(rowIndex, 0);

            for (int i = 0; i < childSheet.Rows.Count; i++)
            {
                Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow childRow = _dsDetail.JyutyuData.FindByrowNum((int)childSheet.Cells[i, COLIDX_JLIST_ROWNUM].Value);

                //子タイムスタンプが親より大きい場合.
                if (parentMaxUpdDate < childRow.hb1TimStmp)
                {
                    //子タイムスタンプが変数より大きい場合.
                    if (maxUpdDate < childRow.hb1TimStmp)
                    {
                        maxUpdDate = childRow.hb1TimStmp;
                    }
                }
            }

            return maxUpdDate;
        }

        #endregion メソッド.
    }
}
