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
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Log;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHView.Common;

using Isid.KKH.Mac.Schema;
using Isid.KKH.Mac.Utility;

namespace Isid.KKH.Mac.View.Detail
{
    public partial class DetailMac : Isid.KKH.Common.KKHView.Detail.DetailForm
    {

        #region 定数.

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "DtlMac";

        //明細(一覧)カラムインデックス TODO 仮決めです。適時変更してください。.
        // 消費税対応 2013/10/21 update HLC H.Watabe start
        /// <summary>
        /// 件名列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KENMEI = 0;
        /// <summary>
        /// 金額インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KINGAKU = 1;
        /// <summary>
        /// 店舗名インデックス.
        /// </summary>
        public const int COLIDX_MLIST_TENPOMEI = 2;
        /// <summary>
        /// 地区本部列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_TIKUHONBU = 3;
        /// <summary>
        /// 単価列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_TANKA = 4;
        /// <summary>
        /// 消費税列インデックス.
        /// </summary>
        public const int COLIDC_MLIST_SHOHIZEIRITU = 5;
        /// <summary>
        /// 数量列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_SURYO = 5;
        public const int COLIDX_MLIST_SURYO = 6;
        /// <summary>
        /// 勘定科目列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_KANJYOKMK = 6;
        public const int COLIDX_MLIST_KANJYOKMK = 7;
        /// <summary>
        /// 店舗コード列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_TENPOCD = 7;
        public const int COLIDX_MLIST_TENPOCD = 8;
        /// <summary>
        /// 地区本部コード列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_TIKUHONBUCD = 8;
        public const int COLIDX_MLIST_TIKUHONBUCD = 9;
        /// <summary>
        /// 得意先担当者コード列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_TOKUISAKITANCD = 9;
        public const int COLIDX_MLIST_TOKUISAKITANCD = 10;
        /// <summary>
        /// 得意先担当者名列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_TOKUISAKITANMEI = 10;
        public const int COLIDX_MLIST_TOKUISAKITANMEI = 11;
        ///// <summary>
        ///// 購入伝票発表日列インデックス.
        ///// </summary>
        //public const int COLIDX_MLIST_KOMYUDENPYO = 11;
        /// <summary>
        /// 請求書発行日列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_SEIKYUSYOHAKKODAY = 11;
        public const int COLIDX_MLIST_SEIKYUSYOHAKKODAY = 12;
        /// <summary>
        /// 店舗区分列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_TENPOKUBUNRETU = 12;
        public const int COLIDX_MLIST_TENPOKUBUNRETU = 13;
        /// <summary>
        /// 請求書発行フラグ列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_SEIKYUSYOFLG = 13;
        public const int COLIDX_MLIST_SEIKYUSYOFLG = 14;
        /// <summary>
        /// 件名１列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_KENMEI1 = 14;
        public const int COLIDX_MLIST_KENMEI1 = 15;
        /// <summary>
        /// 件名２列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_KENMEI2 = 15;
        public const int COLIDX_MLIST_KENMEI2 = 16;
        /// <summary>
        /// 伝票番号列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_DENPYOBANGO = 16;
        public const int COLIDX_MLIST_DENPYOBANGO = 17;
        /// <summary>
        /// 件名変更FLG列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_KENMEICHGFLG = 17;
        public const int COLIDX_MLIST_KENMEICHGFLG = 18;
        /// <summary>
        /// 分割FLG列インデックス.
        /// </summary>
        //public const int COLIDX_MLIST_BUNKATUFLG = 18;
        public const int COLIDX_MLIST_BUNKATUFLG = 19;
        // 消費税対応 2013/10/21 update HLC H.Watabe start.

        #endregion 定数.

        #region メンバ変数.

        KKHNaviParameter _naviParam = new KKHNaviParameter();
        //データテーブル.
        private FindMasterMaintenanceByCondServiceResult plDtTenpoMast;
        private FindMasterMaintenanceByCondServiceResult plDtTenpoPtnMast;
        private FindMasterMaintenanceByCondServiceResult plDtTenpoPtn2Mast;

        #endregion メンバ変数.

        #region コンストラクタ.

        public DetailMac()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ.

        #region オーバーライド.

        /// <summary>
        /// 得意先別に表示対象外列の非表示処理を行う.
        /// </summary>
        protected override void VisibleColumns()
        {
            //親クラスの行っている共通処理を実行.
            base.VisibleColumns();

            foreach (Column col in base._spdJyutyuList_Sheet1.Columns)
            {
                //表示
                if (col.Index == COLIDX_JLIST_TOROKU) { col.Visible = true; }                  //登録.
                if (col.Index == COLIDX_JLIST_TOGO) { col.Visible = false; }                   //統合.
                if (col.Index == COLIDX_JLIST_DAIUKE){ col.Visible = true; }                   //代受.
                if (col.Index == COLIDX_JLIST_SEIKYU) { col.Visible = false; }                 //請求.
                if (col.Index == COLIDX_JLIST_URIMEINO) { col.Visible = true; }                //売上明細NO.
                if (col.Index == COLIDX_JLIST_GPYNO) { col.Visible = false; }                  //請求原票NO.
                if (col.Index == COLIDX_JLIST_SEIYYMM){ col.Visible = true; }                  //請求年月.
                if (col.Index == COLIDX_JLIST_GYOMKBN){ col.Visible = true; }                  //業務区分.
                if (col.Index == COLIDX_JLIST_KENMEI){ col.Visible = true; }                   //件名.
                if (col.Index == COLIDX_JLIST_HIMOKUNM){ col.Visible = true; }                 //費目名.
                if (col.Index == COLIDX_JLIST_SEIKINGAKU){ col.Visible = true; }               //請求金額.
                if (col.Index == COLIDX_JLIST_TORIRYOKIN){ col.Visible = true; }               //取料金.
                if (col.Index == COLIDX_JLIST_NEBIKIRITSU){ col.Visible = true; }              //値引率.
                if (col.Index == COLIDX_JLIST_NEBIKIGAKU){ col.Visible = true; }               //値引額.
                if (col.Index == COLIDX_JLIST_ZEIRITSU){ col.Visible = true; }                 //消費税率.
                if (col.Index == COLIDX_JLIST_ZEIGAKU){ col.Visible = true; }                  //消費税額.
                if (col.Index == COLIDX_JLIST_OLDSEIYYMM){ col.Visible = true; }               //変更前請求年月.

                //非表示.
                if (col.Index == COLIDX_JLIST_BAITAINM) { col.Visible = false; }               //媒体名.
                if (col.Index == COLIDX_JLIST_DANTANKA) { col.Visible = false; }               //段単価.
                if (col.Index == COLIDX_JLIST_DANSU) { col.Visible = false; }                  //段数.
                if (col.Index == COLIDX_JLIST_KYOKUSHICD) { col.Visible = false; }             //局誌CD.
                if (col.Index == COLIDX_JLIST_KIKAN) { col.Visible = false; }                  //期間.                
            }
        }

        /// <summary>
        /// セルの色付け処理を行う.
        /// </summary>
        protected override void ChangeColor()
        {
            string sonota2 = "0";
            for (int i = 0; i < _spdJyutyuList_Sheet1.Rows.Count; i++)
            {
                int rowNum = 0;
                if (!int.TryParse(_spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_ROWNUM].Text, out rowNum))
                {
                    continue;
                }

                Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow1 = _dsDetail.JyutyuData.FindByrowNum(rowNum);
                if (!string.IsNullOrEmpty(dataRow1.hb1TrkTntNm.Trim()))
                {
                    //●明細チェック.
                    DetailProcessController.FindDetailDataByCondParam param = CreateServiceParamForFindDetailDataByCond(i);
                    DetailProcessController processController = DetailProcessController.GetInstance();
                    FindDetailDataByCondServiceResult result = processController.FindDetailDataByCond(param);

                    if (result.HasError == true)
                    {
                        return;
                    }

                    ////明細０の場合.
                    if (result.DetailDataSet.THB2KMEI.Rows.Count == 0)
                    {
                        _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(255, 255, 255);
                    }
                    //明細１の場合.
                    else if (result.DetailDataSet.THB2KMEI.Rows.Count == 1)
                    {
                        foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow row in result.DetailDataSet.THB2KMEI.Rows)
                        {
                            sonota2 = row.hb2Sonota2;
                        }
                        if (sonota2 == "2")
                        {
                            _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(157, 255, 255);
                        }
                        else
                        {
                            _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(255, 157, 157);
                        }
                    }
                    //明細２以上の場合.
                    else
                    {
                        _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(157, 255, 255);
                    }
                }

                //●統合フラグチェック.
                if (dataRow1.hb1TouFlg == "1")
                {
                    //統合フラグ="1"の行は背景色を変更.
                    _spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_TOROKU].Text = "統合";
                }

                //●変更前請求年月チェック.
                if (dataRow1.hb1YymmOld != "")
                {
                    //変更前請求年月が設定されている(年月変更が行われている)場合は請求年月を赤文字にする.
                    _spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_SEIYYMM].ForeColor = Color.Red;
                }
            }

            //親クラスの行っている共通処理を実行.
            base.ChangeColor();
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
            _dsDetailMac.KkhDetail.Clear();
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow row in _dsDetail.THB2KMEI.Rows)
            {
                DetailDSMac.KkhDetailRow addRow = _dsDetailMac.KkhDetail.NewKkhDetailRow();

                //件名.
                addRow.kenmei = row.hb2Name1.Trim() + row.hb2Name2.Trim();
                //金額.
                addRow.kingaku = row.hb2SeiGak;
                //店舗名.
                addRow.tenpomei = row.hb2Name3;
                //地区本部.
                addRow.tikuhonbu = row.hb2Name4;
                //単価.
                addRow.tanka = row.hb2Kngk1;
                // 消費税対応 2013/10/21 HLC H.Watabe start
                //消費税率.
                addRow.shohizeiritu = row.hb2Ritu1;
                // 消費税対応 2013/10/21 HLC H.Watabe end
                //数量.
                addRow.suryo = row.hb2Kngk2;
                //勘定科目.
                addRow.kanjyokmk = row.hb2Code4;
                //店舗コード.
                addRow.tenpocd = row.hb2Code1;
                //地区本部コード.
                addRow.tikuhonbucd = row.hb2Code2;
                //得意先担当者コード.
                addRow.tokuisakitantocd = row.hb2Code3;
                //得意先担当者名.
                addRow.tokusakitantonm = row.hb2Name5;
                //請求書発行日.
                addRow.seikyuhakoday = row.hb2Date2;
                //店舗区分.
                addRow.tenpokbn = row.hb2Kbn1;
                //請求書発行フラグ.
                addRow.seikyusyohako = row.hb2Kbn2;
                //件名１.
                addRow.kenmei1 = row.hb2Name1;
                //件名２.
                addRow.kenmei2 = row.hb2Name2;
                //伝票番号.
                addRow.denpyobango = row.hb2Sonota1;
                //件名チェンジフラグ.
                addRow.kenmeiChgFlg = row.hb2MeihnFlg;
                //分割フラグ.
                addRow.bunkatu = row.hb2Sonota2;

                _dsDetailMac.KkhDetail.AddKkhDetailRow(addRow);
            }

            _dsDetailMac.KkhDetail.AcceptChanges();

            //スプレッドデザインの再初期化.
            InitializeDesignForSpdKkhDetail();

            //受注登録内容の選択行情報の取得.
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(rowIdx)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);

            //***************************************
            //ボタン類の使用可・不可設定.
            //***************************************
            btnDetailInput.Enabled = true;
            btnDetailDel.Enabled = true;
            btnDetailRegister.Enabled = true;
            btnDivide.Enabled = true;
            btnUpdateCheck.Enabled = true;

            //明細データあり.
            if (_dsDetailMac.KkhDetail.Rows.Count > 0)
            {
                //分割データの場合.
                if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    //表示の編集.
                    for (int i = 1; i < _spdKkhDetail_Sheet1.RowCount; i++)
                    {
                        //件名.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI].Value = "";
                        //地区本部.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TIKUHONBU].Value = "";
                        //単価.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TANKA].Value = null;
                        //地区本部コード.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TIKUHONBUCD].Value = "";
                        //得意先担当者コード.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TOKUISAKITANCD].Value = "";
                        //得意先担当者名.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TOKUISAKITANMEI].Value = "";
                        //請求書発行日.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSYOHAKKODAY].Value = "";
                        //請求書発行フラグ.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSYOFLG].Value = "";
                        //件名１.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI1].Value = "";
                        //件名２.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI2].Value = "";
                        //件名変更フラグ.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEICHGFLG].Value = "";

                        //消費税対応 2013/10/21 add HLC H.Watabe start
                        _spdKkhDetail_Sheet1.Cells[i, COLIDC_MLIST_SHOHIZEIRITU].Value = null;
                        //消費税対応 2013/10/21 add HLC H.Watabe end
                    }

                    //明細入力ボタン.
                    btnDetailInput.Enabled = false;
                }
                else
                {
                    btnDetailInput.Enabled = true;
                }
                btnDetailDel.Enabled = true;
                btnDetailRegister.Enabled = true;
                btnDivide.Enabled = true;
            }
            //明細データなし.
            else
            {
                //広告費明細データがない場合は分割・削除は不可.
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = true;
                btnDivide.Enabled = true;
                btnDetailInput.Enabled = true;
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
            //btnBulkRegister.Enabled = false;
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
            //btnBulkRegister.Enabled = true;
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
                //明細関係のボタンは明細検索後の処理に任せる.
            }
            else
            {
                //子ビューにフォーカスがある場合はデータ操作を行うボタンは使用させない.

                //明細関係のボタン使用不可.
                btnDetailInput.Enabled = false;
                btnDivide.Enabled = false;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = false;
            }
        }

        #region 受注削除後の初期化処理.

        /// <summary>
        /// 受注削除後の初期化処理.
        /// </summary>
        protected override void InitAfterDelJyutyu()
        {
            // 現在のアクティブ行インデックスを保持.
            int rowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            // 再検索.
            ReSearchJyutyuData();

            // 受注情報が存在しない場合.
            if (_spdJyutyuList_Sheet1.Rows.Count == 0)
            {
                return;
            }

            // アクティブ行を設定.
            _spdJyutyuList_Sheet1.SetActiveCell(rowIdx, 0, true);
            _spdJyutyuList_Sheet1.AddSelection(rowIdx, 0, 1, 1);
            spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

            // 広告費明細データの検索・表示.
            DisplayKkhDetail(rowIdx);

            // 受注登録内容の選択行情報の取得.
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(rowIdx)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);

            // 差額計算.
            CalculateSagaku(dataRow);

            return;
        }

        #endregion


        protected override void UpdateSpdDataByJyutyuData(Isid.KKH.Common.KKHSchema.Detail dsDetail)
        {
            dsDetail.MacUpdateSpdDataByJyutyuData();
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
            KKHLogUtilityMac.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityMac.KINO_ID_OPERATION_LOG_UpdCheck, KKHLogUtilityMac.DESC_OPERATION_LOG_UpdCheck);

            return true;
        }

        #endregion オーバーライド.

        #region イベント.

        /// <summary>
        /// 画面遷移するたびに発生します。.
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void DetailMac_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// フォームロードイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailMac_Load(object sender, EventArgs e)
        {
            InitializeDataSourceMac();
            InitializeControlMac();
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
            int rowIndex = _spdJyutyuList_Sheet1.ActiveRowIndex;
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(rowIndex)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);
            int rowDetailIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

            // 明細入力画面表示.
            //パラメータセット.
            DetailInputMacNaviParameter naviParam = new DetailInputMacNaviParameter();
            //基本情報.
            naviParam.pEsqId = _naviParam.strEsqId;
            naviParam.pEgcd = _naviParam.strEgcd;
            naviParam.pTksKgyCd = _naviParam.strTksKgyCd;
            naviParam.pTksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            naviParam.pTksTntSeqNo = _naviParam.strTksTntSeqNo;
            //他.
            naviParam.DataRow = dataRow;
            naviParam.RowDetailIndex = rowDetailIndex;
            naviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1;
            naviParam.InpTenpoMastrslt = plDtTenpoMast;

            object result = Navigator.ShowModalForm(this, "toDetailInputMac", naviParam);

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
            int rowIndex = _spdJyutyuList_Sheet1.ActiveRowIndex;
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(rowIndex)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);
            int rowDetailIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

            // 明細入力画面表示.
            DetailDivideMacNaviParameter naviParam = new DetailDivideMacNaviParameter();
            //基本情報.
            naviParam.pEsqId = _naviParam.strEsqId;
            naviParam.pEgcd = _naviParam.strEgcd;
            naviParam.pTksKgyCd = _naviParam.strTksKgyCd;
            naviParam.pTksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            naviParam.pTksTntSeqNo = _naviParam.strTksTntSeqNo;
            //他.
            naviParam.DataRow = dataRow;
            naviParam.RowDetailIndex = rowDetailIndex;
            naviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1;
            naviParam.DivTenpoMastrslt = plDtTenpoMast;
            naviParam.DivTenpoPtnMastrslt = plDtTenpoPtnMast;
            naviParam.DivTenpoPtn2Mastrslt = plDtTenpoPtn2Mast;

            object result = Navigator.ShowModalForm(this, "toDetailDivideMac", naviParam);

            if (result == null)
            {
                //選択状態を解除.
                this.ActiveControl = null;

                return;
            }
            base.kkhDetailUpdFlag = true; //広告費明細変更フラグを更新.

            // 差額計算.
            CalculateSagaku(dataRow);

            // ボタン活性処理.
            if (_spdKkhDetail_Sheet1.RowCount == 0)
            {
                btnDivide.Enabled = false;
                btnDetailDel.Enabled = false;
            }
            else
            {
                btnDivide.Enabled = true;
                btnDetailDel.Enabled = true;
            }

            //分割ボタンは有効.
            btnDivide.Enabled = true;

            //明細入力ボタンは無効.
            btnDetailInput.Enabled = false;

            //選択状態を解除 .
            this.ActiveControl = null;
        }

        /// <summary>
        /// 明細登録ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailRegister_Click(object sender, EventArgs e)
        {
            if (lblSagakuValue.Text.ToString().Trim().Equals("0"))
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
        /// 
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
                //btnDivide.Enabled = false;
                btnDivide.Enabled = true;
                btnDetailInput.Enabled = true;
            }

            //******************************
            //差額・計ラベル.
            //******************************
            //受注登録内容の選択行情報の取得.
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(_spdJyutyuList_Sheet1.ActiveRowIndex)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);
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
        /// マスタデータ保存.
        /// </summary>
        private void DetailMac_Shown(object sender, EventArgs e)
        {
            // ローディング表示開始.
            ShowLoadingDialog();

            {
                //店舗データ読み込み.
                MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = controller.FindMasterByCond
                (
                    _naviParam.strEsqId,
                    _naviParam.strEgcd,
                    _naviParam.strTksKgyCd,
                    _naviParam.strTksBmnSeqNo,
                    _naviParam.strTksTntSeqNo,
                    "0001",
                    null
                );

                //リザルトに保持.
                plDtTenpoMast = result;
            }

            {
                //店舗パターン（親）読み込み.
                MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = controller.FindMasterByCond
                (
                    _naviParam.strEsqId,
                    _naviParam.strEgcd,
                    _naviParam.strTksKgyCd,
                    _naviParam.strTksBmnSeqNo,
                    _naviParam.strTksTntSeqNo,
                    "0004",
                    null
                );

                //リザルトに保持.
                plDtTenpoPtnMast = result;
            }

            {
                //店舗パターン（子）読み込み.
                MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = controller.FindMasterByCond
                (
                    _naviParam.strEsqId,
                    _naviParam.strEgcd,
                    _naviParam.strTksKgyCd,
                    _naviParam.strTksBmnSeqNo,
                    _naviParam.strTksTntSeqNo,
                    "0005",
                    null
                );

                //リザルトに保持.
                plDtTenpoPtn2Mast = result;
            }

            // ローディング表示終了.
            CloseLoadingDialog();
        }

        /// <summary>
        /// ヘルプボタンクリック処理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //KKHHelpMac.ShowHelpMac(this, this.Name);
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行.
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Detail, this, HelpNavigator.KeywordIndex);
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
                String ryoukinStr = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KINGAKU].Text.Trim();

                // 明細の料金が入力されている場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.IsNumeric(ryoukinStr))
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
        /// <param name="dsDetailMac"></param>
        private void UpdateDataSourceByDetailDataSetMac(DetailDSMac dsDetailMac)
        {
            _dsDetailMac.Clear();
            _dsDetailMac.Merge(_dsDetailMac);
            _dsDetailMac.AcceptChanges();
        }

        /// <summary>
        /// データソースのバインド.
        /// </summary>
        private void InitializeDataSourceMac()
        {
            //_bsJyutyuList
            _bsKkhDetail.DataSource = _dsDetailMac;
            _bsKkhDetail.DataMember = _dsDetailMac.KkhDetail.TableName;
        }

        /// <summary>
        /// 各コントロールの初期設定.
        /// </summary>
        private void InitializeControlMac()
        {
            //******************
            //検索条件部.
            //******************
            lblKenMei.Visible = false;
            txtKenMei.Visible = false;
            lblKikan.Visible = false;
            txtYmdTo.Visible = false;

            //*******************
            //ボタン類.
            //*******************
            btnRegJyutyu.Enabled = false;
            btnDetailInput.Enabled = false;
            btnDetailDel.Enabled = false;
            btnDivide.Enabled = false;
            btnDetailRegister.Enabled = false;

            // 新規登録ボタンを非表示.
            btnRegJyutyu.Visible = false;

            // 変更・削除チェックボタンを非表示.
            btnUpdateCheck.Enabled = false;
        }

        /// <summary>
        /// 受注登録内容(一覧)スプレッドの列単位の設定を行う.
        /// </summary>
        protected override void InitDesignForSpdJyutyuListColumns(Column col)
        {
            base.InitDesignForSpdJyutyuListColumns(col);

            if (col.Index == COLIDX_JLIST_TOROKU)
            {
                col.Width = 33;
            }
        }

        /// <summary>
        /// 広告費明細スプレッドのデザイン初期化を行う.
        /// </summary>
        private void InitializeDesignForSpdKkhDetail()
        {
            //********************************
            //スプレッド全体の設定.
            //********************************
            spdKkhDetail.DataSource = _bsKkhDetail;
            _spdKkhDetail_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;//単一選択.
            _spdKkhDetail_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;       //行単位選択.
            _spdKkhDetail_Sheet1.OperationMode = OperationMode.SingleSelect;                        //
            _spdKkhDetail_Sheet1.RowHeaderVisible = true;                                           //行ヘッダ表示.
            _spdKkhDetail_Sheet1.RowHeaderAutoText = HeaderAutoText.Numbers;                        //行ヘッダに行番号を表示.
            _spdKkhDetail_Sheet1.ColumnHeader.Rows[0].Height = 30;

            //********************************
            //列毎の設定.
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
                    col.Width = 180;
                }
                else if (col.Index == COLIDX_MLIST_KINGAKU)
                {
                    col.Width = 100;
                    col.Label = "金額";
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 2;
                    cellType.ShowSeparator = true;
                }
                else if (col.Index == COLIDX_MLIST_TENPOMEI)
                {
                    col.Width = 180;
                    col.Label = "店舗名";
                }
                else if (col.Index == COLIDX_MLIST_TIKUHONBU)
                {
                    col.Width = 100;
                    col.Label = "地区本部";
                }
                else if (col.Index == COLIDX_MLIST_TANKA)
                {
                    col.Width = 100;
                    col.Label = "単価";
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 3;
                    cellType.ShowSeparator = true;
                }
                // 消費税対応 2013/10/21 add HLC H.Watabe start
                else if (col.Index == COLIDC_MLIST_SHOHIZEIRITU)
                {
                    col.Width = 70;
                    col.Label = "消費税率";
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = false;
                }
                // 消費税対応 2013/10/21 add HLC H.Watabe end
                else if (col.Index == COLIDX_MLIST_SURYO)
                {
                    col.Width = 60;
                    col.Label = "数量";
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                }
                else if (col.Index == COLIDX_MLIST_KANJYOKMK)
                {
                    col.Width = 80;
                    col.Label = "勘定科目";
                }
                else if (col.Index == COLIDX_MLIST_TENPOCD)
                {
                    col.Width = 80;
                    col.Label = "店舗コード";
                }
                else if (col.Index == COLIDX_MLIST_TIKUHONBUCD)
                {
                    col.Width = 100;
                    col.Label = "地区本部コード";
                }
                else if (col.Index == COLIDX_MLIST_TOKUISAKITANCD)
                {
                    col.Label = "得意先担当者コード";
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_TOKUISAKITANMEI)
                {
                    col.Label = "得意先担当者名";
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_SEIKYUSYOHAKKODAY)
                {
                    col.Width = 90;
                    col.Label = "請求書発行日";
                }
                else if (col.Index == COLIDX_MLIST_TENPOKUBUNRETU)
                {
                    col.Width = 80;
                    col.Label = "店舗区分";
                }
                else if (col.Index == COLIDX_MLIST_SEIKYUSYOFLG)
                {
                    col.Width = 70;
                    col.Label = "請求書発行フラグ";
                }
                else if (col.Index == COLIDX_MLIST_KENMEI1)
                {
                    col.Width = 150;
                    col.Label = "件名１";
                }
                else if (col.Index == COLIDX_MLIST_KENMEI2)
                {
                    col.Width = 150;
                    col.Label = "件名２";
                }
                else if (col.Index == COLIDX_MLIST_DENPYOBANGO)
                {
                    col.Width = 100;
                    col.Label = "伝票番号";
                }
                else if (col.Index == COLIDX_MLIST_KENMEICHGFLG)
                {
                    col.Width = 70;
                    col.Label = "件名チェンジフラグ";
                }
                else if (col.Index == COLIDX_MLIST_BUNKATUFLG)
                {
                    col.Width = 70;
                    col.Label = "分割フラグ";
                }
            }
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
            DateTime maxUpdDate = new DateTime();
            //DateTime maxUpdDate = new DateTime(2100, 1, 1);//TODO

            //*********************************************
            //THB1DOWNの登録データ編集.
            //*********************************************
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(_spdJyutyuList_Sheet1.ActiveRowIndex)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            //Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);

            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();

            //thb1DownRow.hb1TimStmp = new DateTime();
            thb1DownRow.hb1UpdApl = base.AplId;
            thb1DownRow.hb1UpdTnt = _naviParam.strEsqId;
            thb1DownRow.hb1EgCd = _naviParam.strEgcd;
            thb1DownRow.hb1TksKgyCd = _naviParam.strTksKgyCd;
            thb1DownRow.hb1TksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            thb1DownRow.hb1TksTntSeqNo = _naviParam.strTksTntSeqNo;
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
            //登録者、更新者の登録.
            //***************************************
            thb1DownRow.hb1TrkTnt = string.Empty;
            thb1DownRow.hb1TrkTntNm = string.Empty;
            thb1DownRow.hb1KsnTnt = string.Empty;
            thb1DownRow.hb1KsnTntNm = string.Empty;

            //明細がない場合.
            if (thb1DownRow.hb1MeisaiFlg.Equals("0"))
            {
                //登録者、かつ更新者が空の場合.
                if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim())
                    && string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                    //何もしない.
                }
                //登録者が空で、更新者が入っている場合
                else if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) 
                    && !string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                    //何もしない.
                }
                else
                {
                    //更新者を登録.
                    //更新者.
                    thb1DownRow.hb1KsnTnt = _naviParam.strEsqId.Trim();
                    //更新担当者名.
                    thb1DownRow.hb1KsnTntNm = _naviParam.strName.Trim();
                }
            }
            //明細がある場合.
            else
            {
                //登録者が空の場合.
                if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()))
                {
                    //登録者のみを入れる.
                    //登録者.
                    thb1DownRow.hb1TrkTnt = _naviParam.strEsqId.Trim();
                    //登録者名.
                    thb1DownRow.hb1TrkTntNm = _naviParam.strName.Trim();
                    //更新者.
                    thb1DownRow.hb1KsnTnt = _naviParam.strEsqId.Trim();
                    //更新担当者名.
                    thb1DownRow.hb1KsnTntNm = _naviParam.strName.Trim();
                }else
                {
                    //更新者のみを入れる.
                    //更新者.
                    thb1DownRow.hb1KsnTnt = _naviParam.strEsqId.Trim();
                    //更新担当者名.
                    thb1DownRow.hb1KsnTntNm = _naviParam.strName.Trim();
                }
            }

            dtThb1Down.AddTHB1DOWNRow(thb1DownRow);

            dsDetail.THB1DOWN.Merge(dtThb1Down);

            Isid.KKH.Common.KKHSchema.Detail TouKoudsDetail = new Isid.KKH.Common.KKHSchema.Detail();

            //データが統合されている場合、子の元となったデータに登録担当者、更新者を登録する。.
            if (dataRow.hb1TouFlg.Equals("1"))
            {
                Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow tokoaddrow = TouKoudsDetail.THB1DOWN.NewTHB1DOWNRow();
                tokoaddrow.hb1UpdApl = base.AplId;
                tokoaddrow.hb1UpdTnt = _naviParam.strEsqId;
                tokoaddrow.hb1EgCd = _naviParam.strEgcd;
                tokoaddrow.hb1TksKgyCd = _naviParam.strTksKgyCd;
                tokoaddrow.hb1TksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                tokoaddrow.hb1TksTntSeqNo = _naviParam.strTksTntSeqNo;
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
                addRow.hb2UpdApl = base.AplId;
                addRow.hb2UpdTnt = _naviParam.strEsqId;
                addRow.hb2EgCd = _naviParam.strEgcd;
                addRow.hb2TksKgyCd = _naviParam.strTksKgyCd;
                addRow.hb2TksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                addRow.hb2TksTntSeqNo = _naviParam.strTksTntSeqNo;
                addRow.hb2Yymm = dataRow.hb1Yymm;
                addRow.hb2JyutNo = dataRow.hb1JyutNo;
                addRow.hb2JyMeiNo = dataRow.hb1JyMeiNo;
                addRow.hb2UrMeiNo = dataRow.hb1UrMeiNo;
                addRow.hb2HimkCd = dataRow.hb1HimkCd;
                //addRow.hb2Renbn = (i + 1).ToString("000");　明細登録件数拡張対応.
                addRow.hb2Renbn = (i + 1).ToString("0000");
                addRow.hb2DateFrom = " ";
                addRow.hb2DateTo = " ";
                //マクドナルド用.

                //件名.
                //分割の場合.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_KENMEI].Value != null)
                    {
                        addRow.hb2Name1 = _spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_KENMEI].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Name1 = " ";
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI].Value != null)
                    {
                        addRow.hb2Name1 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Name1 = " ";
                    }
                }

                //金額.
                addRow.hb2SeiGak = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KINGAKU].Value;

                //店舗名.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TENPOMEI].Value != null)
                {
                    addRow.hb2Name3 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TENPOMEI].Value.ToString();
                }
                else
                {
                    addRow.hb2Name3 = " ";
                }

                //地区本部,
                //分割の場合.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_TIKUHONBU].Value != null)
                    {
                        addRow.hb2Name4 = _spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_TIKUHONBU].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Name4 = " ";
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TIKUHONBU].Value != null)
                    {
                        addRow.hb2Name4 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TIKUHONBU].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Name4 = " ";
                    }
                }

                //単価.
                //分割の場合.
                if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_TANKA].Value != null)
                    {
                        addRow.hb2Kngk1 = Isid.KKH.Common.KKHUtility.KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_TANKA].Value.ToString());
                    }
                    else
                    {
                        addRow.hb2Kngk1 = 0M;
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TANKA].Value != null)
                    {
                        addRow.hb2Kngk1 = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TANKA].Value;
                    }
                    else
                    {
                        addRow.hb2Kngk1 = 0M;
                    }
                }

                //数量.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SURYO].Value != null)
                {
                    addRow.hb2Kngk2 = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SURYO].Value;
                }
                else
                {
                    addRow.hb2Kngk2 = 0M;
                }

                //勘定科目.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KANJYOKMK].Value != null)
                {
                    addRow.hb2Code4 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KANJYOKMK].Value.ToString();
                }
                else
                {
                    addRow.hb2Code4 = " ";
                }

                //店舗コード.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TENPOCD].Value != null)
                {
                    addRow.hb2Code1 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TENPOCD].Value.ToString();
                }
                else
                {
                    addRow.hb2Code1 = " ";
                }

                //地区本部コード.
                //分割の場合.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_TIKUHONBUCD].Value != null)
                    {
                        addRow.hb2Code2 = _spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_TIKUHONBUCD].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Code2 = " ";
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TIKUHONBUCD].Value != null)
                    {
                        addRow.hb2Code2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TIKUHONBUCD].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Code2 = " ";
                    }
                }

                //得意先CD,NM
                addRow.hb2Code3 = " ";
                addRow.hb2Name5 = " ";

                //請求書発行日.
                //分割の場合.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_SEIKYUSYOHAKKODAY].Value != null)
                    {
                        addRow.hb2Date2 = _spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_SEIKYUSYOHAKKODAY].Value.ToString().Replace("/", "");
                    }
                    else
                    {
                        addRow.hb2Date2 = " ";
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSYOHAKKODAY].Value != null)
                    {
                        addRow.hb2Date2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSYOHAKKODAY].Value.ToString().Replace("/", "");
                    }
                    else
                    {
                        addRow.hb2Date2 = " ";
                    }
                }

                //店舗区分.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TENPOKUBUNRETU].Value != null)
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TENPOKUBUNRETU].Value.ToString().Equals(""))
                    {
                        addRow.hb2Kbn1 = " ";
                    }
                    else
                    {
                        addRow.hb2Kbn1 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TENPOKUBUNRETU].Value.ToString();
                    }
                }
                else
                {
                    addRow.hb2Kbn1 = " ";
                }

                //請求書発行フラグ.
                //分割の場合.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    //請求書発行フラグ
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_SEIKYUSYOFLG].Value != null)
                    {
                        addRow.hb2Kbn2 = _spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_SEIKYUSYOFLG].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Kbn2 = " ";
                    }
                }
                else
                {
                    //請求書発行フラグ
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSYOFLG].Value != null)
                    {
                        addRow.hb2Kbn2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSYOFLG].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Kbn2 = " ";
                    }
                }

                //請求書発行フラグ.
                //分割の場合.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_SEIKYUSYOFLG].Value != null)
                    {
                        addRow.hb2Kbn2 = _spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_SEIKYUSYOFLG].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Kbn2 = " ";
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSYOFLG].Value != null)
                    {
                        addRow.hb2Kbn2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSYOFLG].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Kbn2 = " ";
                    }
                }

                //件名１.
                //分割の場合.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_KENMEI1].Value != null)
                    {
                        addRow.hb2Name1 = _spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_KENMEI1].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Name1 = " ";
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI1].Value != null)
                    {
                        addRow.hb2Name1 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI1].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Name1 = " ";
                    }
                }

                //件名２.
                //分割の場合.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_KENMEI2].Value != null)
                    {
                        addRow.hb2Name2 = _spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_KENMEI2].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Name2 = " ";
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI2].Value != null)
                    {
                        addRow.hb2Name2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI2].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Name2 = " ";
                    }
                }

                //伝票.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_DENPYOBANGO].Value != null)
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_DENPYOBANGO].Value.ToString().Equals(""))
                    {
                        addRow.hb2Sonota1 = " ";
                    }
                    else
                    {
                        addRow.hb2Sonota1 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_DENPYOBANGO].Value.ToString();
                    }
                }
                else
                {
                    addRow.hb2Sonota1 = " ";
                }

                //消費税対応 2013/10/21 add HLC H.Watabe start 
                //addRow.hb2Ritu1 = Isid.KKH.Common.KKHUtility.KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[i, COLIDC_MLIST_SHOHIZEIRITU].Value.ToString());
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDC_MLIST_SHOHIZEIRITU].Value != null)
                    {
                        addRow.hb2Ritu1 = Isid.KKH.Common.KKHUtility.KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[0, COLIDC_MLIST_SHOHIZEIRITU].Value.ToString());
                    }
                    else
                    {
                        addRow.hb2Ritu1 = 0M;
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDC_MLIST_SHOHIZEIRITU].Value != null)
                    {
                        addRow.hb2Ritu1 = Isid.KKH.Common.KKHUtility.KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[i, COLIDC_MLIST_SHOHIZEIRITU].Value.ToString());
                    }
                    else
                    {

                        addRow.hb2Ritu1 = 0M;
                    }
                }
                //消費税対応 2013/10/21 add HLC H.Watabe end

                addRow.hb2Hnnert = 0M;
                addRow.hb2HnmaeGak = 0M;
                addRow.hb2NebiGak = 0M;
                addRow.hb2Date1 = " ";
                addRow.hb2Date3 = " ";
                addRow.hb2Date4 = " ";
                addRow.hb2Date5 = " ";
                addRow.hb2Date6 = " ";
                addRow.hb2Kbn3 = " ";
                addRow.hb2Code3 = " ";
                addRow.hb2Code5 = " ";
                addRow.hb2Code6 = " ";
                addRow.hb2Name5 = " ";
                addRow.hb2Name6 = " ";
                addRow.hb2Name7 = " ";
                addRow.hb2Name8 = " ";
                addRow.hb2Name9 = " ";
                addRow.hb2Name10 = " ";
                addRow.hb2Kngk3 = 0M;
                //消費税対応 2013/10/21 delete HLC H.Watabe start
                //addRow.hb2Ritu1 = 0M;
                //消費税対応 2013/10/21 delete HLC H.Watabe end
                addRow.hb2Ritu2 = 0M;
                addRow.hb2Sonota2 = " ";
                addRow.hb2Sonota3 = " ";
                addRow.hb2Sonota4 = " ";
                addRow.hb2Sonota5 = " ";
                addRow.hb2Sonota6 = " ";
                addRow.hb2Sonota7 = " ";
                addRow.hb2Sonota8 = " ";
                addRow.hb2Sonota9 = " ";
                addRow.hb2Sonota10 = " ";

                //分割フラグ.
                if (_spdKkhDetail_Sheet1.RowCount >= 2)
                {
                    addRow.hb2BunFlg = "1";
                }
                else
                {
                    addRow.hb2BunFlg = " ";
                }
                //件名フラグ.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEICHGFLG].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2MeihnFlg = "1";
                }
                else
                {
                    addRow.hb2MeihnFlg = " ";
                }
                addRow.hb2NebhnFlg = " ";
                //そのたフラグ(SONOTA2).
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value != null)
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString().Equals(""))
                    {
                        addRow.hb2Sonota2 = " ";
                    }
                    else
                    {
                        addRow.hb2Sonota2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString();
                    }
                }
                else
                {
                    addRow.hb2Sonota2 = " ";
                }

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

            DetailProcessController processController = DetailProcessController.GetInstance();
            //UpdateDisplayDataServiceResult result = processController.UpdateDisplayData(esqId, dsDetail, maxUpdDate);
            DetailProcessController.UpdateDisplayDataParam param = new DetailProcessController.UpdateDisplayDataParam();
            param.esqId = esqId;
            param.dsDetail = dsDetail;
            param.maxUpdDate = maxUpdDate;
            param.TouKoudsDetail = TouKoudsDetail;
            UpdateDisplayDataServiceResult result = processController.UpdateDisplayData(param);

            if (result.HasError)
            {
                if (result.MessageCode == "LOCK-E0001")
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0148, null, "明細登録", MessageBoxButtons.OK);
                }
                //ローディング表示終了.
                base.CloseLoadingDialog();

                return;
            }

            base.kkhDetailUpdFlag = false; //広告費明細変更フラグを更新.
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {

                // 分割フラグの値によって受注一覧の行の色を変更.
                if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    _spdJyutyuList_Sheet1.Rows[_spdJyutyuList_Sheet1.ActiveRowIndex].BackColor = Color.FromArgb(157, 255, 255);
                    //明細入力ボタンを無効にする.
                    btnDetailInput.Enabled = false;
                }
                else
                {
                    _spdJyutyuList_Sheet1.Rows[_spdJyutyuList_Sheet1.ActiveRowIndex].BackColor = Color.FromArgb(255, 157, 157);
                    //明細入力ボタンを有効にする.
                    btnDetailInput.Enabled = true;
                }
            }
            else
            {
                //明細入力ボタンを有効にする.
                btnDetailInput.Enabled = true;

                //分割ボタンを有効にする.
                btnDivide.Enabled = true;

                //削除ボタンを無効にする.
                btnDetailDel.Enabled = false;

                // 受注一覧の行の色を変更.
                _spdJyutyuList_Sheet1.Rows[_spdJyutyuList_Sheet1.ActiveRowIndex].BackColor = Color.FromArgb(255, 255, 255);
            }

            ////現在位置の取得.
            //int _spdJyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            //base.SearchJyutyuData();

            ////元の位置に戻す.
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

            // 完了メッセージ表示.
            MessageUtility.ShowMessageBox(MessageCode.HB_I0012, null, "明細登録", MessageBoxButtons.OK);

        }

        #endregion メソッド.
    }
}
