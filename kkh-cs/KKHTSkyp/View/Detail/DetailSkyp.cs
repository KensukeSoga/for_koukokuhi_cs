using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Skyp.Schema;
using Isid.KKH.Skyp.ProcessController.Detail;
using Isid.KKH.Skyp.Utility;

namespace Isid.KKH.Skyp.View.Detail
{
    /// <summary>
    /// 広告費明細入力画面（スカパー） 
    /// </summary>
    public partial class DetailSkyp : DetailForm
    {
        #region 定数 

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "DtlSkyp";
        /// <summary>
        /// 業務区分列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_GYOMUKBN = 0;
        /// <summary>
        /// タイムスポット区分列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_TIMESPOTKBN = 1;
        /// <summary>
        /// 件名列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_KENMEI = 2;
        /// <summary>
        /// 電通・媒体名称列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_DMEISYO = 3;
        /// <summary>
        /// 電通・期間列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_DKIKAN = 4;
        /// <summary>
        /// 電通・内容列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_DNAIYO = 5;
        /// <summary>
        /// 取料金列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_TORIGAK = 6;
        /// <summary>
        /// 値引率列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_NEBIRITU = 7;
        /// <summary>
        /// 値引額列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_NEBIGAK = 8;
        /// <summary>
        /// 請求金額列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_KINGAK = 9;
        /// <summary>
        /// 消費税率列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_SYOHIRITU = 10;
        /// <summary>
        /// 消費税額列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_SYOHI = 11;
        /// <summary>
        /// 媒体区分列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_BAITAIKBN = 12;
        /// <summary>
        /// 媒体名称列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_BAITAIMEI = 13;
        /// <summary>
        /// 項目コード列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_KOMOKUCODE = 14;
        /// <summary>
        /// 項目名称列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_KOMOKUMEI = 15;
        /// <summary>
        /// 並び順（媒体区分）列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_SEQ2 = 16;
        /// <summary>
        /// 並び順列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_SEQ1 = 17;
        /// <summary>
        /// 受注NO列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_JYUTNO = 18;
        /// <summary>
        /// 受注明細NO列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_JYMEINO = 19;
        /// <summary>
        /// 売上明細NO列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_URMEINO = 20;
        /// <summary>
        /// 請求原票NO列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_GPYNO = 21;
        /// <summary>
        /// 媒体区分列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_BAITAIKBN2 = 22;
        /// <summary>
        /// タイムスタンプ列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_TIMESTMP = 23;
        /// <summary>
        /// テンプレートコード列インデックス 
        /// </summary>
        internal const int COLIDX_MLIST_TEMPCODE = 24;

        #endregion 定数

        #region メンバ変数 

        /// <summary>
        /// Rgナビパラメータ 
        /// </summary>
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();

        #endregion メンバ変数 

        #region コンストラクタ 

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public DetailSkyp()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ 

        #region オーバーライド 

        /// <summary>
        /// スプレッド全体に対する初期表示の設定を行う 
        /// </summary>
        protected override void InitDesignForSpdJyutyuListSpread()
        {
            base.InitDesignForSpdJyutyuListSpread();

            // 固定列の設定 
            base._spdJyutyuList_Sheet1.FrozenColumnCount = 6;
        }

        /// <summary>
        /// スプレッドの列に対する初期表示の設定を行う 
        /// </summary>
        /// <param name="col"></param>
        protected override void InitDesignForSpdJyutyuListColumns(Column col)
        {
            base.InitDesignForSpdJyutyuListColumns(col);

            // 値引率の場合 
            if (col.Index == COLIDX_JLIST_NEBIKIRITSU)
            {
                NumberCellType cellType = (NumberCellType)col.CellType;
                cellType.DecimalPlaces = 0;
            }
            // 消費税率の場合 
            else if (col.Index == COLIDX_JLIST_ZEIRITSU)
            {
                NumberCellType cellType = (NumberCellType)col.CellType;
                cellType.DecimalPlaces = 0;
            }
        }

        /// <summary>
        /// 得意先別に表示対象外列の非表示処理を行う 
        /// </summary>
        protected override void VisibleColumns()
        {
            //親クラスの行っている共通処理を実行 
            base.VisibleColumns();

            foreach (Column col in base._spdJyutyuList_Sheet1.Columns)
            {
                if (col.Index == COLIDX_JLIST_TOROKU) { col.Visible = true; }                   //登録 
                if (col.Index == COLIDX_JLIST_TOGO) { col.Visible = false; }                    //統合  
                if (col.Index == COLIDX_JLIST_DAIUKE) { col.Visible = true; }                   //代受
                if (col.Index == COLIDX_JLIST_SEIKYU) { col.Visible = false; }                  //請求
                if (col.Index == COLIDX_JLIST_URIMEINO) { col.Visible = true; }                 //売上明細NO
                if (col.Index == COLIDX_JLIST_GPYNO) { col.Visible = false; }                   //請求原票NO  
                if (col.Index == COLIDX_JLIST_SEIYYMM) { col.Visible = true; }                  //請求年月 
                if (col.Index == COLIDX_JLIST_GYOMKBN) { col.Visible = true; }                  //業務区分 
                if (col.Index == COLIDX_JLIST_KENMEI) { col.Visible = true; }                   //件名 
                if (col.Index == COLIDX_JLIST_BAITAINM) { col.Visible = true; }                 //媒体名 
                if (col.Index == COLIDX_JLIST_HIMOKUNM) { col.Visible = true; }                 //費目名 
                if (col.Index == COLIDX_JLIST_KYOKUSHICD) { col.Visible = false; }              //局誌CD(非表示) 
                if (col.Index == COLIDX_JLIST_SEIKINGAKU) { col.Visible = true; }               //請求金額 
                if (col.Index == COLIDX_JLIST_KIKAN) { col.Visible = true; }                    //期間 
                if (col.Index == COLIDX_JLIST_DANTANKA) { col.Visible = false; }                //段単価(非表示) 
                if (col.Index == COLIDX_JLIST_DANSU) { col.Visible = false; }                   //段数(非表示) 
                if (col.Index == COLIDX_JLIST_TORIRYOKIN) { col.Visible = true; }               //取料金 
                if (col.Index == COLIDX_JLIST_NEBIKIRITSU) { col.Visible = true; }              //値引率 
                if (col.Index == COLIDX_JLIST_NEBIKIGAKU) { col.Visible = true; }               //値引額 
                if (col.Index == COLIDX_JLIST_ZEIRITSU) { col.Visible = true; }                 //消費税率 
                if (col.Index == COLIDX_JLIST_ZEIGAKU) { col.Visible = true; }                  //消費税額 
                if (col.Index == COLIDX_JLIST_GOUKEIKINGAKU) { col.Visible = true; }            //受注請求金額 
                if (col.Index == COLIDX_JLIST_OLDSEIYYMM) { col.Visible = true; }               //変更前請求年月 
            }
        }

        /// <summary>
        /// セルの色付け処理を行う 
        /// </summary>
        protected override void ChangeColor()
        {
            //親クラスの行っている共通処理を実行 
            base.ChangeColor();

            for (int iRow = 0; iRow < _spdJyutyuList_Sheet1.Rows.Count; iRow++)
            {
                Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(iRow);
                if (dataRow.hb1TouFlg == "1")
                {
                    //統合フラグ="1"の行は背景色を変更 
                    _spdJyutyuList_Sheet1.Rows[iRow].BackColor = Color.FromArgb(255, 255, 208);
                }
                if (dataRow.hb1YymmOld != "")
                {
                    //変更前請求年月が設定されている(年月変更が行われている)場合は請求年月を赤文字にする 
                    _spdJyutyuList_Sheet1.Cells[iRow, COLIDX_JLIST_SEIYYMM].ForeColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// 広告費明細データの検索・表示 
        /// </summary>
        /// <param name="rowIdx"></param>
        protected override void DisplayKkhDetail(int rowIdx)
        {
            //親クラスの行っている共通処理を実行 
            base.DisplayKkhDetail(rowIdx);

            //***************************************
            // 表示用広告費明細データの編集・表示 
            //***************************************
            _dsDetailSkyp.KkhDetail.Clear();
            foreach (Common.KKHSchema.Detail.THB2KMEIRow row in _dsDetail.THB2KMEI.Rows)
            {
                DetailDSSkyp.KkhDetailRow addrow = _dsDetailSkyp.KkhDetail.NewKkhDetailRow();

                addrow.gyomukbn = row.hb2Code2;         // 業務区分 
                addrow.timespotkbn = row.hb2Kbn1;       // タイムスポット区分 
                addrow.kenmei = row.hb2Name11;          // 件名 
                addrow.dmeisyo = row.hb2Name12;         // 電通・媒体名称 
                addrow.dkikan = row.hb2Name1;           // 電通・期間 
                addrow.dnaiyo = row.hb2Name10;          // 電通・内容 
                addrow.torigak = row.hb2Kngk2;          // 取料金 
                addrow.nebiritu = row.hb2Ritu1;         // 値引率 
                addrow.nebigak = row.hb2NebiGak;        // 値引額 
                addrow.kingak = row.hb2SeiGak;          // 請求金額 
                addrow.syohiritu = row.hb2Ritu2;        // 消費税率 
                addrow.syohi = row.hb2Kngk1;            // 消費税額 
                addrow.baitaikbn = row.hb2Name13;       // 媒体区分 
                addrow.baitaimei = row.hb2Name7;        // 媒体名称 
                addrow.komokucode = row.hb2Code1;       // 項目コード 
                addrow.komokumei = row.hb2Name8;        // 項目名称 
                addrow.seq2 = row.hb2Sonota1;           // 並び順（媒体区分） 
                addrow.seq1 = row.hb2Sonota2;           // 並び順 
                addrow.jyutno = row.hb2Name3;           // 受注NO 
                addrow.jymeino = row.hb2Name4;          // 受注明細NO 
                addrow.urmeino = row.hb2Name5;          // 売上明細NO 
                addrow.gpyno = row.hb2Name6;            // 請求原票NO 
                addrow.baitaikbn2 = row.hb2Name13;      // 媒体区分(保存) 
                addrow.timeStmp = row.hb2TimStmp;       // タイムスタンプ 
                addrow.templateCode = row.hb2Code3;     // テンプレートコード 

                _dsDetailSkyp.KkhDetail.AddKkhDetailRow(addrow);
            }
            _dsDetailSkyp.KkhDetail.AcceptChanges();

            _spdKkhDetail_Sheet1.SetActiveCell(0, 0, true);
            _spdKkhDetail_Sheet1.AddSelection(0, -1, 1, -1);

            // 受注登録内容の選択行情報の取得 
            Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(rowIdx);
            //***************************************
            //ボタン類の使用可・不可設定 
            //***************************************
            btnDetailInput.Enabled = true;


            //******************************
            // 差額・計ラベル 
            //******************************
            // 差額計算 
            CalculateSagaku(dataRow);
        }

        /// <summary>
        /// 受注登録内容検索前チェック処理 
        /// </summary>
        /// <returns></returns>
        protected override Boolean CheckBeforeSearch()
        {
            //親クラスの行っている共通処理を実行 
            if (base.CheckBeforeSearch() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 受注登録内容検索前クリア処理 
        /// </summary>
        protected override void InitializeBeforeSearch()
        {
            //親クラスの行っている共通処理を実行 
            base.InitializeBeforeSearch();

            //差額・計ラベル 
            lblGoukeiValue.Text = "";
            lblSagakuValue.Text = "";

            //ボタン 
            InitializeButtonEnable(false);
        }

        /// <summary>
        /// 受注登録内容検索後チェック処理 
        /// </summary>
        /// <returns></returns>
        protected override Boolean CheckAfterSearch()
        {
            // 親クラスの行っている共通処理を実行 
            if (base.CheckAfterSearch() == false)
            {
                return false;
            }
            else
            {
                //ボタン 
                InitializeButtonEnable(true);
                return true;
            }
        }

        /// <summary>
        /// 受注登録内容検索後初期表示処理 
        /// </summary>
        protected override void InitializeAfterSearch()
        {
            // 親クラスの行っている共通処理を実行 
            base.InitializeAfterSearch();

            _naviParameter.StrYymm = FindJyutyuDataCond.yymm;
        }

        /// <summary>
        /// 受注削除実行前チェック処理 
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeDelJyutyu()
        {
            //親クラスの行っている共通処理を実行 
            if (base.CheckBeforeDelJyutyu() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 受注削除後の初期化処理 
        /// </summary>
        protected override void InitAfterDelJyutyu()
        {
            //親クラスの行っている共通処理を実行 
            base.InitAfterDelJyutyu();

            //削除の結果、表示するデータがなくなった場合 
            if (_spdJyutyuList_Sheet1.Rows.Count == 0)
            {
                //ボタン 
                InitializeButtonEnable(false);

                //差額・計 
                lblSagakuValue.Text = "0";
                lblGoukeiValue.Text = "0";
            }
        }

        /// <summary>
        /// 年月変更ダイアログ表示前チェック 
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeYmChange()
        {
            //親クラスの行っている共通処理を実行 
            if (base.CheckBeforeYmChange() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 新規作成ダイアログ表示前チェック 
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeRegJyutyu()
        {
            return base.CheckBeforeRegJyutyu();
        }

        /// <summary>
        /// MouseMoveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseMoveCommon(object sender, MouseEventArgs e)
        {
            base.MouseMoveCommon(sender, e);
        }

        /// <summary>
        /// MouseLeaveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseLeaveCommon(object sender, EventArgs e)
        {
            base.MouseLeaveCommon(sender, e);
        }

        /// <summary>
        /// 受注登録内容(一覧)でフォーカスがあるビューによってコントロールの制御を行う 
        /// </summary>
        /// <param name="activeSheet">アクティブのシート</param>
        /// <param name="activeRow">アクティブ行Index</param>
        protected override void EnableChangeForSelectJyutyuListRow(SheetView activeSheet, int activeRow)
        {
            base.EnableChangeForSelectJyutyuListRow(activeSheet, activeRow);

            //受注登録明細(親)シートがアクティブの場合 
            if (activeSheet == _spdJyutyuList_Sheet1)
            {
                //明細関係のボタンは明細検索後の処理に任せる 
            }
            else
            {
                //子ビューにフォーカスがある場合はデータ操作を行うボタンは使用させない 

                //明細関係のボタン使用不可 
                btnDetailInput.Enabled = false;
            }
        }

        /// <summary>
        ///  受注統合ボタンクリック処理 
        /// </summary>
        protected override void MergeClick()
        {
            //選択行の取得 
            CellRange[] cellRanges = base.SortCellRangesByRowIdx(_spdJyutyuList_Sheet1.GetSelections());
            foreach (CellRange cellRange in cellRanges)
            {
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    int rowIndex = cellRange.Row + i;

                    if (_spdJyutyuList_Sheet1.RowFilter.IsRowFilteredOut(rowIndex))
                    {
                        // フィルタリングで見えなくなっている場合はエラーを表示する.
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0146, null, "明細登録", MessageBoxButtons.OK);
                        return;
                    }

                    if (_spdJyutyuList_Sheet1.Cells[rowIndex, COLIDX_JLIST_TOROKU].Text.Equals("済"))
                    {
                        //すでに明細登録された受注内容があります.
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0152, null, "明細登録", MessageBoxButtons.OK);
                        return;
                    }
                }

            }
            base.MergeClick();
        }

        /// <summary>
        /// 受注チェック 
        /// </summary>
        /// <returns></returns>
        protected override bool UpdateCheckClick()
        {
            if (base.UpdateCheckClick() == false)
            {
                return false;
            }

            // オペレーションログの出力 
            KKHLogUtilitySkyp.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilitySkyp.KINO_ID_OPERATION_LOG_UPDCHECK, KKHLogUtilitySkyp.DESC_OPERATION_LOG_UPDCHECK);

            return true;
        }

        #endregion オーバーライド 

        #region イベント 

        /// <summary>
        /// 画面遷移するたびに発生します。 
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void DetailSkyp_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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
        /// フォームShownイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailSkyp_Shown(object sender, EventArgs e)
        {
            InitializeButtonEnable(false);
            InitializeControlSkyp();
            InitializeDesignForSpdKkhDetail();
        }

        /// <summary>
        /// 並び順ボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrder_Click(object sender, EventArgs e)
        {
            // 並び順データ存在チェック 
            if (!CheckOrderData())
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023
                                ,null
                                , "明細登録"
                                , MessageBoxButtons.OK);

                //選択状態を解除 
                this.ActiveControl = null;

                return;
            }

            DetailOrderSkypNaviParameter naviParam = new DetailOrderSkypNaviParameter();
            naviParam.strEsqId = _naviParameter.strEsqId;
            naviParam.strEgcd = _naviParameter.strEgcd;
            naviParam.strTksKgyCd = _naviParameter.strTksKgyCd;
            naviParam.strTksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            naviParam.strTksTntSeqNo = _naviParameter.strTksTntSeqNo;
            naviParam.StrYymm = _naviParameter.StrYymm;
            naviParam.strName  = _naviParameter.strName;

            object ret = Navigator.ShowModalForm(this, "toDetailOrderSkyp", naviParam);

            if (ret != null)
            {
                // 再検索.
                DisplayUpdate();
            }

            //選択状態を解除 
            this.ActiveControl = null;
        }

        /// <summary>
        /// 明細入力ボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailInput_Click(object sender, EventArgs e)
        {
            // 対象の受注データ、明細データ取得 
            Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);
            // 受注ダウンロードデータ（統合されている受注を含むデータ）取得 
            string filter = "hb1TJyutNo = \'" + dataRow.hb1JyutNo + "\' AND " +
                            "hb1TJyMeiNo = \'" + dataRow.hb1JyMeiNo + "\' AND " +
                            "hb1TUrMeiNo = \'" + dataRow.hb1UrMeiNo + "\'";
            Common.KKHSchema.Detail.JyutyuDataRow[] jyutyuDataRow =
                (Common.KKHSchema.Detail.JyutyuDataRow[])_dsDetail.JyutyuData.Select(filter);

            SheetView activeSheetView = GetActiveSheetViewBySpdJyutyuList();
            int rowIndex = activeSheetView.ActiveRowIndex;

            // 明細入力画面表示 
            DetailInputSkypNaviParameter naviParam = new DetailInputSkypNaviParameter();
            //naviParam = (DetailInputSkypNaviParameter)_naviParameter;
            naviParam.strEsqId = _naviParameter.strEsqId;
            naviParam.strName = _naviParameter.strName;
            naviParam.strEgcd = _naviParameter.strEgcd;
            naviParam.strTksKgyCd = _naviParameter.strTksKgyCd;
            naviParam.strTksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            naviParam.strTksTntSeqNo = _naviParameter.strTksTntSeqNo;
            naviParam.DataRow = dataRow;
            naviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1;
            naviParam.AplId = AplId;
            naviParam.SeigakSum = KKHUtility.DecParse(lblGoukeiValue.Text);

            if (jyutyuDataRow != null)
            {
                if (0 < jyutyuDataRow.Length)
                {
                    // 統合されている受注が存在する場合、 
                    // 受注ダウンロードデータ（統合されている受注を含むデータ）を設定する 
                    naviParam.MergeDataRow = jyutyuDataRow;
                }
                else
                {
                    // 統合されている受注が存在する場合、 
                    // 受注ダウンロードデータ（統合されている受注を含むデータ）はnull 
                    naviParam.MergeDataRow = null;
                }
            }
            else
            {
                // 統合されている受注が存在する場合、 
                // 受注ダウンロードデータ（統合されている受注を含むデータ）はnull 
                naviParam.MergeDataRow = null;
            }

            object ret = Navigator.ShowModalForm(this, "toDetailInputSkyp", naviParam);

            if (ret != null)
            {
                // 再検索.
                DisplayUpdate();
            }

            //選択状態を解除 
            this.ActiveControl = null;

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
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Detail, this, HelpNavigator.KeywordIndex);
        }
        #endregion イベント 

        #region メソッド 

        /// <summary>
        /// 差額計算 
        /// </summary>
        /// <param name="dataRow">受注ダウンロードデータ</param>
        private void CalculateSagaku(Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            // 料金合計 
            decimal ryoukinGoukei = 0;

            // 明細の件数分、繰り返す 
            for (int iRow = 0; iRow < _spdKkhDetail_Sheet1.RowCount; iRow++)
            {
                string ryoukinStr = _spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_KINGAK].Text.Trim();
                // 明細の料金が入力されている場合 
                if (KKHUtility.IsNumeric(ryoukinStr))
                {
                    // 料金合計に加算 
                    ryoukinGoukei = ryoukinGoukei + KKHUtility.DecParse(ryoukinStr.Trim());
                }
            }
            // 差額 
            decimal sagaku = dataRow.hb1SeiGak - ryoukinGoukei;
            lblSagakuValue.Text = sagaku.ToString("###,###,###,##0");
            // 合計 
            lblGoukeiValue.Text = ryoukinGoukei.ToString("###,###,###,##0");
        }

        /// <summary>
        /// 広告費明細スプレッドのデザイン初期化を行う 
        /// </summary>
        private void InitializeDesignForSpdKkhDetail()
        {
            //********************************
            //スプレッド全体の設定 
            //********************************

            //********************************
            //列毎の設定 ※デザイナから列に対する設定を行うと変更が反映されないことがあるようなので暫定的にここで行う 
            //********************************
            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                //共通設定 
                col.Locked = true;//セルの編集不可 
                col.AllowAutoFilter = true;//フィルタ機能を有効 
                col.AllowAutoSort = true;  //ソート機能を有効 

                //列毎に異なる設定 
                if (col.Index == COLIDX_MLIST_GYOMUKBN)
                {
                    col.Label = "業務区分";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_TIMESPOTKBN)
                {
                    col.Label = "タイムスポット区分";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_KENMEI)
                {
                    col.Label = "件名";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_DMEISYO)
                {
                    col.Label = "電通・媒体名称";
                    col.Width = 200;
                }
                else if (col.Index == COLIDX_MLIST_DKIKAN)
                {
                    col.Label = "電通・期間";
                    col.Width = 120;
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_DNAIYO)
                {
                    col.Label = "電通・内容";
                    col.Width = 150;
                }
                else if (col.Index == COLIDX_MLIST_TORIGAK)
                {
                    col.Label = "取料金";
                    col.Width = 100;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                else if (col.Index == COLIDX_MLIST_NEBIRITU)
                {
                    col.Label = "値引率";
                    col.Width = 60;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                else if (col.Index == COLIDX_MLIST_NEBIGAK)
                {
                    col.Label = "値引額";
                    col.Width = 100;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                else if (col.Index == COLIDX_MLIST_KINGAK)
                {
                    col.Label = "請求金額";
                    col.Width = 120;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                else if (col.Index == COLIDX_MLIST_SYOHIRITU)
                {
                    col.Label = "消費税率";
                    col.Width = 60;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                else if (col.Index == COLIDX_MLIST_SYOHI)
                {
                    col.Label = "消費税額";
                    col.Width = 120;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                else if (col.Index == COLIDX_MLIST_BAITAIKBN)
                {
                    col.Label = "媒体区分";
                    col.Width = 250;
                }
                else if (col.Index == COLIDX_MLIST_BAITAIMEI)
                {
                    col.Label = "媒体名称";
                    col.Width = 200;
                }
                else if (col.Index == COLIDX_MLIST_KOMOKUCODE)
                {
                    col.Label = "項目コード";
                    col.Width = 80;
                }
                else if (col.Index == COLIDX_MLIST_KOMOKUMEI)
                {
                    col.Label = "項目名称";
                    col.Width = 250;
                }
                else if (col.Index == COLIDX_MLIST_SEQ2)
                {
                    col.Label = "並び順２";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_SEQ1)
                {
                    col.Label = "並び順";
                    col.Width = 60;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    col.CellType = cellType;
                }
                else if (col.Index == COLIDX_MLIST_JYUTNO)
                {
                    col.Label = "受注NO";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_JYMEINO)
                {
                    col.Label = "受注明細NO";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_URMEINO)
                {
                    col.Label = "売上明細NO";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_GPYNO)
                {
                    col.Label = "請求原票NO";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_BAITAIKBN2)
                {
                    col.Label = "媒体区分";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_TIMESTMP)
                {
                    col.Label = "タイムスタンプ";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_TEMPCODE)
                {
                    col.Label = "テンプレートコード";
                    col.Width = 0;
                    col.Visible = false;
                }
            }

            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(0, 0, 1, 1);
            }
        }

        /// <summary>
        /// ボタンの使用可・不可設定の初期化を行う 
        /// </summary>
        /// <param name="flg">True:使用可/false:使用不可</param>
        private void InitializeButtonEnable(bool flg)
        {
            // 並び順ボタン 
            btnOrder.Enabled = flg;

            // 明細入力ボタン 
            btnDetailInput.Enabled = flg;
        }

        /// <summary>
        /// 各コントロールの初期設定 
        /// </summary>
        private void InitializeControlSkyp()
        {
            //******************
            //検索条件部 
            //******************
            lblKenMei.Visible = false;
            txtKenMei.Visible = false;
            lblKikan.Visible = false;
            txtYmdTo.Visible = false;

            //*******************
            //ボタン類 
            //*******************
        }

        /// <summary>
        /// 並び順データ存在チェック 
        /// </summary>
        /// <returns>判定結果</returns>
        private bool CheckOrderData()
        {
            DetailSkypProcessController.FindOrderDataByCondParam param =
                new DetailSkypProcessController.FindOrderDataByCondParam();

            // パラメータ設定 
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = _naviParameter.StrYymm;
            param.baitaikbn = string.Empty;
            // 並び順データ検索 
            DetailSkypProcessController processController = DetailSkypProcessController.GetInstance();
            FindOrderByCondServiceResult result = processController.FindOrderDataByCond(param);

            if (result.HasError == true)
            {
                return false;
            }

            if (result.DetailDataSet.OrderData.Rows.Count == 0)
            {
                return false;
            }

            return true;
        }

        #endregion メソッド 

    }
}