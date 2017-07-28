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

using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Kmn.Schema;
using Isid.KKH.Kmn.Utility;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;

namespace Isid.KKH.Kmn.View.Detail
{
    public partial class DetailKmn : DetailForm
    {
        #region 定数

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "DtlKmn";

        # region 明細(一覧)カラムインデックス
        /// <summary>
        /// 品目１列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_HINMOKU1 = 0;
        /// <summary>
        /// 品目２列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_HINMOKU2 = 1;
        /// <summary>
        /// 品目３列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_HINMOKU3 = 2;
        /// <summary>
        /// 費目列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_HIMOKU = 3;
        /// <summary>
        /// 期間列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_KIKAN = 4;
        /// <summary>
        /// 部門コード列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_BUMONCODE = 5;
        /// <summary>
        /// 請求先部門列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_SEIKYUSAKIBUMON = 6;
        /// <summary>
        /// 請求年月列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_SEIKYUYYYYMM = 7;
        /// <summary>
        /// 合計金額列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_GOUKEIKINGAKU = 8;
        /// <summary>
        /// 合計消費税額列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_GOUKEIZEIGAKU = 9;
        /// <summary>
        /// 内容(明細)列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_NAIYOU = 10;
        /// <summary>
        /// 費目(明細)列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_HIMOKU_M = 11;
        /// <summary>
        /// 期間(明細)列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_KIKAN_M = 12;
        /// <summary>
        /// 金額(明細)列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_KINGAKU = 13;
        /// <summary>
        /// 消費税額(明細)列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_ZEIGAKU = 14;
        /// <summary>
        /// 備考(明細)列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_BIKO = 15;
        # endregion 明細(一覧)カラムインデックス 

        # region 種別コード

        /// <summary>
        ///  種別コード：テレビ番組 
        /// </summary>
        public const String C_CD_TVBAN = KkhConstKmn.ShubetsuCd.C_TV_BANGUMI;
        /// <summary>
        ///  種別コード：テレビ特番
        /// </summary>
        public const String C_CD_TVTOK = KkhConstKmn.ShubetsuCd.C_TV_TOKUBAN;
        /// <summary>
        ///  種別コード：テレビスポット 
        /// </summary>
        public const String C_CD_TVSPOT = KkhConstKmn.ShubetsuCd.C_TV_SPOT;
        /// <summary>
        ///  種別コード：雑誌 
        /// </summary>
        public const String C_CD_ZASHI = KkhConstKmn.ShubetsuCd.C_ZASHI;
        /// <summary>
        ///  種別コード：新聞 
        /// </summary>
        public const String C_CD_SHINBUN = KkhConstKmn.ShubetsuCd.C_SHINBUN;
        /// <summary>
        ///  種別コード：その他 
        /// </summary>
        public const String C_CD_SONOTA = KkhConstKmn.ShubetsuCd.C_SONOTA;
        /// <summary>
        ///  種別コード：制作 
        /// </summary>
        public const String C_CD_SEISAKU = KkhConstKmn.ShubetsuCd.C_SEISAKU;
        # endregion 種別コード
        #region 種別名 

        /// <summary>
        ///  種別名：テレビ番組 
        /// </summary>
        public const string C_MEI_TVBAN = KkhConstKmn.ShubetsuMei.C_TV_BANGUMI;
        /// <summary>
        ///  種別名：テレビ特番 
        /// </summary>
        public const string C_MEI_TVTOK = KkhConstKmn.ShubetsuMei.C_TV_TOKUBAN;
        /// <summary>
        ///  種別名：テレビスポット 
        /// </summary>
        public const string C_MEI_TVSPOT = KkhConstKmn.ShubetsuMei.C_TV_SPOT;
        /// <summary>
        ///  種別名：雑誌 
        /// </summary>
        public const string C_MEI_ZASHI = KkhConstKmn.ShubetsuMei.C_ZASHI;
        /// <summary>
        ///  種別名：新聞 
        /// </summary>
        public const string C_MEI_SHINBUN = KkhConstKmn.ShubetsuMei.C_SHINBUN;
        /// <summary>
        /// 種別名：その他 
        /// </summary>
        public const string C_MEI_SONOTA = KkhConstKmn.ShubetsuMei.C_SONOTA;
        /// <summary>
        ///  種別名：制作 
        /// </summary>
        public const string C_MEI_SEISAKU = KkhConstKmn.ShubetsuMei.C_SEISAKU;
        # endregion 種別名 

        # region 業務区分 
        /// <summary>
        /// 新聞 
        /// </summary>
        public const String C_GYOM_SHINBUN = KKHSystemConst.GyomKbn.Shinbun;
        /// <summary>
        /// 雑誌 
        /// </summary>
        public const String C_GYOM_ZASHI = KKHSystemConst.GyomKbn.Zashi;
        /// <summary>
        /// ラジオ 
        /// </summary>
        public const String C_GYOM_RADIO = KKHSystemConst.GyomKbn.Radio;
        /// <summary>
        /// テレビタイム 
        /// </summary>
        public const String C_GYOM_TVT = KKHSystemConst.GyomKbn.TVTime;
        /// <summary>
        /// テレビスポット 
        /// </summary>
        public const String C_GYOM_TVS = KKHSystemConst.GyomKbn.TVSpot;
        /// <summary>
        /// 衛星メディア 
        /// </summary>
        public const String C_GYOM_EISEIM = KKHSystemConst.GyomKbn.EiseiM;
        /// <summary>
        /// OOHメディア 
        /// </summary>
        public const String C_GYOM_OOHM = KKHSystemConst.GyomKbn.OohM;
        /// <summary>
        /// インタラクティブメディア 
        /// </summary>
        public const String C_GYOM_INTEM = KKHSystemConst.GyomKbn.InteractiveM;
        /// <summary>
        /// その他メディア 
        /// </summary>
        public const String C_GYOM_SONOM = KKHSystemConst.GyomKbn.SonotaM;
        /// <summary>
        /// メディアプランニング 
        /// </summary>
        public const String C_GYOM_MPLAN = KKHSystemConst.GyomKbn.MPlan;
        /// <summary>
        /// クリエーティブ 
        /// </summary>
        public const String C_GYOM_CREAT = KKHSystemConst.GyomKbn.Creative;
        /// <summary>
        /// マーケティング/プロモーション 
        /// </summary>
        public const String C_GYOM_MARPRO = KKHSystemConst.GyomKbn.MarkePromo;
        /// <summary>
        /// スポーツ 
        /// </summary>
        public const String C_GYOM_SPO = KKHSystemConst.GyomKbn.Sports;
        /// <summary>
        /// エンタテイメント 
        /// </summary>
        public const String C_GYOM_ENTE = KKHSystemConst.GyomKbn.Entertainment;
        /// <summary>
        /// その他コンテンツ 
        /// </summary>
        public const String C_GYOM_SONOC = KKHSystemConst.GyomKbn.SonotaC;
        # endregion 業務区分
        # region 色 
        /// <summary>
        /// 背景色：白色.
        /// </summary>
        public static readonly Color C_BACK_COLOR_WHITE = Color.White;
        /// <summary>
        /// 背景色：黄色.
        /// </summary>
        public static readonly Color C_BACK_COLOR_LYELLOW = Color.LightYellow;
        /// <summary>
        /// 背景色：赤色.
        /// </summary>
        public static readonly Color C_BACK_COLOR_LPINK = Color.LightPink;
        # endregion 色 

        # region 記号
        /// <summary>
        /// スラッシュ（/） 
        /// </summary>
        public const string C_SLASH = "/";

        /// <summary>
        /// ハイフン（-） 
        /// </summary>
        public const string C_HYPHEN = "-";
        # endregion 記号

        /// <summary>
        /// 宛先マスター取得キー
        /// </summary>
        public const string C_MST_ATESAKI = "0001";

        #endregion 定数

        #region メンバ変数

        /// <summary>
        /// 
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();

        #endregion メンバ変数

        #region コンストラクタ
        public DetailKmn()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ

        #region オーバーライド 

        /// <summary>
        /// 得意先別に表示対象外列の非表示処理を行う 
        /// </summary>
        protected override void VisibleColumns()
        {
            //親クラスの行っている共通処理を実行. 
            base.VisibleColumns();
             
            foreach (Column col in base._spdJyutyuList_Sheet1.Columns)
            {
                if (col.Index == COLIDX_JLIST_TOROKU) { col.Visible = true; }                   //登録 
                if (col.Index == COLIDX_JLIST_TOGO) { col.Visible = false; }                    //統合  
                if (col.Index == COLIDX_JLIST_DAIUKE) { col.Visible = true; }                   //代受
                if (col.Index == COLIDX_JLIST_SEIKYU) { col.Visible = true; }                   //請求
                if (col.Index == COLIDX_JLIST_URIMEINO) { col.Visible = true; }                 //売上明細NO
                if (col.Index == COLIDX_JLIST_GPYNO) { col.Visible = true; }                    //請求原票NO 
                if (col.Index == COLIDX_JLIST_SEIYYMM) { col.Visible = true; }                  //請求年月 
                if (col.Index == COLIDX_JLIST_GYOMKBN) { col.Visible = true; }                  //業務区分 
                if (col.Index == COLIDX_JLIST_KENMEI) { col.Visible = true; }                   //件名 
                if (col.Index == COLIDX_JLIST_BAITAINM) { col.Visible = false; }                //媒体名 
                if (col.Index == COLIDX_JLIST_HIMOKUNM) { col.Visible = true; }                 //費目名 
                if (col.Index == COLIDX_JLIST_KYOKUSHICD) { col.Visible = false; }              //局誌CD 
                if (col.Index == COLIDX_JLIST_SEIKINGAKU) { col.Visible = true; }               //請求金額 
                if (col.Index == COLIDX_JLIST_KIKAN) { col.Visible = false; }                   //期間 
                if (col.Index == COLIDX_JLIST_DANTANKA) { col.Visible = false; }                //段単価 
                if (col.Index == COLIDX_JLIST_DANSU) { col.Visible = false; }                   //段数 
                if (col.Index == COLIDX_JLIST_TORIRYOKIN) { col.Visible = true; }               //取料金 
                if (col.Index == COLIDX_JLIST_NEBIKIRITSU) { col.Visible = false; }             //値引率 
                if (col.Index == COLIDX_JLIST_NEBIKIGAKU) { col.Visible = true; }               //値引額 
                if (col.Index == COLIDX_JLIST_ZEIRITSU) { col.Visible = false; }                //消費税率 
                if (col.Index == COLIDX_JLIST_ZEIGAKU) { col.Visible = true; }                  //消費税額 
                if (col.Index == COLIDX_JLIST_GOUKEIKINGAKU) { col.Visible = false; }           //受注請求金額 
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

            for (int i = 0 ; i < _spdJyutyuList_Sheet1.Rows.Count ; i++)
            {
                int rowNum = 0;
                if (!int.TryParse(_spdJyutyuList_Sheet1.Cells[i , COLIDX_JLIST_ROWNUM].Text , out rowNum))
                {
                    continue;
                }
                Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(rowNum);
                if (dataRow.hb1TouFlg == "1")
                {
                    //統合フラグ="1"の行は背景色を変更 
                    _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(255, 255, 208);
                }
                if (dataRow.hb1YymmOld != "")
                {
                    //変更前請求年月が設定されている(年月変更が行われている)場合は請求年月を赤文字にする 
                    _spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_SEIYYMM].ForeColor = Color.Red;
                }
                //受変列が"消"の場合は、グレーアウトする.
                if (_spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_JHENKOU].Text.Equals("消"))
                {
                    // 業務会計側で受注削除されている場合は背景色を変更 
                    _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(165, 165, 165);
                }
            }
        }

        /// <summary>
        /// 広告費明細データの検索・表示 
        /// </summary>
        /// <param name="rowIdx"></param>
        protected override void DisplayKkhDetail(int rowIdx)
        {
            //親クラスの行っている共通処理を実行. 
            base.DisplayKkhDetail(rowIdx);

            //***************************************
            //表示用広告費明細データの編集・表示 
            //***************************************
            //広告費明細のデータセットを初期化.
            _dsDetailKmn.KkhDetail.Clear();

            //受注登録内容の選択行情報の取得 
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(rowIdx)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);

            string JGyomuKbn = string.Empty;
            // 業務区分
            JGyomuKbn = dataRow.hb1GyomKbn.ToString().Trim();

            //明細登録内容の件数分まわす.
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow row in _dsDetail.THB2KMEI.Rows)
            {
                DetailDSKmn.KkhDetailRow addRow = _dsDetailKmn.KkhDetail.NewKkhDetailRow();
                addRow.Hinmoku1 = row.hb2Name8;                                  //品目１ 

                addRow.Hinmoku2 = row.hb2Name3;                                  //品目２ 

                addRow.Hinmoku3 = row.hb2Name4;                                  //品目３ 

                addRow.Himoku1 = row.hb2Name9;                                   //費目

                addRow.Kikan1 = row.hb2Name10;                                   //期間

                addRow.BumonCd = row.hb2Code1;                                   //部門コード 

                addRow.SeikyuSakiBumon = row.hb2Name5;                           //請求先部門 

                addRow.SeikyuYyyymm  = row.hb2Name6;                             //請求年月 

                addRow.GokeiKingaku = row.hb2SeiGak.ToString("###,###,###,##0"); //合計金額 

                addRow.GokeiZeigaku = row.hb2Kngk3.ToString("###,###,###,##0");  //合計消費税額 

                addRow.Naiyou = row.hb2Name11 + row.hb2Name12 + row.hb2Name13 + row.hb2Name14; //内容                                     //内容

                addRow.Himoku = row.hb2Name1;                                    //費目 

                addRow.Kingaku = row.hb2Kngk1.ToString("###,###,###,##0");       //金額                                     //内容

                addRow.Zeigaku = row.hb2Kngk2.ToString("###,###,###,##0");       //消費税 

                addRow.Biko = row.hb2Name15;                                     //備考 

                //掲載期間.
                if (!String.IsNullOrEmpty(row.hb2Name2.ToString()))
                {
                    if (row.hb2Name2.Length == 16)
                    {
                        string strFrom = row.hb2Name2.Substring(0, 4) + "/" + row.hb2Name2.Substring(4, 2) + "/" + row.hb2Name2.Substring(6, 2);
                        string strTo = row.hb2Name2.Substring(8, 4) + "/" + row.hb2Name2.Substring(12, 2) + "/" + row.hb2Name2.Substring(14, 2);

                        addRow.Kikan = strFrom + "～" + strTo;
                    }
                    else
                    {
                        addRow.Kikan = row.hb2Name2;
                    }
                }

                _dsDetailKmn.KkhDetail.AddKkhDetailRow(addRow);
            }

            _dsDetailKmn.KkhDetail.AcceptChanges();

            //***************************************
            //広告費明細列の表示・非表示設定 
            //***************************************
            VisibleMeisaiColumns(JGyomuKbn);

            //***************************************
            //ボタン類の使用可・不可設定 
            //***************************************
            btnMeiNyuryoku.Enabled = true;
            //明細行が無い場合 
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                btnMeiSakujo.Enabled = true;
            }
            else
            {
                btnMeiSakujo.Enabled = false;
            }
            btnMeiToroku.Enabled = true;

            //2013/07/11 Add HLC H.Watabe -- 公文一括登録対応 
            btnBulkRegister.Enabled = true;

            //******************************
            //差額・計ラベル 
            //******************************
            //差額計算 
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

            //***************************************
            //ボタン類の使用可・不可設定 
            //***************************************
            this.btnMeiNyuryoku.Enabled = false;    //明細入力.
            this.btnMeiToroku.Enabled = false;      //明細登録.
            this.btnMeiSakujo.Enabled = false;      //明細削除.

            //2013/07/11 Add HLC H.Watabe -- 公文一括登録対応 
            this.btnBulkRegister.Enabled = false;
        }

        /// <summary>
        /// 受注登録内容検索後チェック処理 
        /// </summary>
        /// <returns></returns>
        protected override Boolean CheckAfterSearch()
        {
            //親クラスの行っている共通処理を実行 
            if (base.CheckAfterSearch() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 受注登録内容検索後初期表示処理 
        /// </summary>
        protected override void InitializeAfterSearch()
        {
            //親クラスの行っている共通処理を実行 
            base.InitializeAfterSearch();

            //***************************************
            //ボタン類の使用可・不可設定 
            //***************************************
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
                //受注登録内容検索後の状態にする 
            }
            else
            {
                //子ビューにフォーカスがある場合はデータ操作を行うボタンは使用させない 
                btnMeiNyuryoku.Enabled = false;
                btnMeiSakujo.Enabled = false;
                btnMeiToroku.Enabled = false;

                //2013/07/11 Add HLC H.Watabe -- 公文一括登録対応 
                btnBulkRegister.Enabled = false;
            }
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
            KKHLogUtilityKmn.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityKmn.KINO_ID_OPERATION_LOG_UpdCheck, KKHLogUtilityKmn.DESC_OPERATION_LOG_UpdCheck);

            return true;
        }

        #endregion オーバーライド 

        # region イベント 
        /// <summary>
        /// 画面遷移するたびに発生します。  
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void DetailKmn_ProcessAffterNavigating(object sender , Isid.NJ.View.Base.NavigationEventArgs arg)
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
        /// フォームロードイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailKmn_Load(object sender , EventArgs e)
        {
            InitializeDataSourceKmn();
            InitializeControlKmn();
            InitializeDesignForSpdKkhDetail();
            // 2013/04/23 件名のオートコンプリート対応 JSE M.Naito start
            InitializeKenmeiKmn();
            // 2013/04/23 件名のオートコンプリート対応 JSE M.Naito end
        }

        /// <summary>
        /// 明細入力ボタンクリック 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMeiNyuryoku_Click(object sender , EventArgs e)
        {
            // 対象の受注データ、明細データ取得 
            int rowIndex = _spdJyutyuList_Sheet1.ActiveRowIndex;
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(rowIndex)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);
            int rowDetailIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;
            // 明細入力画面表示 
            //KKHNaviParameter naviParam = new KKHNaviParameter();

            // 明細入力画面表示 
            DetailInputKmnNaviParameter naviParam = new DetailInputKmnNaviParameter();
            naviParam.DataRowKmn = dataRow;
            naviParam.DataTable2 = _dsDetail.JyutyuData;
            naviParam.RowDetailIndexKmn = rowDetailIndex;
            naviParam.SpdKkhDetailKmn_Sheet1 = _spdKkhDetail_Sheet1;
            naviParam.EsqId = _naviParam.strEsqId;
            naviParam.Egcd = _naviParam.strEgcd;
            naviParam.TksKgyCd = _naviParam.strTksKgyCd;
            naviParam.TksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            naviParam.TksTntSeqNo = _naviParam.strTksTntSeqNo;
            //naviParam.DateKmn = _mHosoBi;   //放送日.

            //明細入力画面に遷移.
            object result = Navigator.ShowModalForm(this, "toDetailInputKmn", naviParam);

            if (result == null)
            {
                this.ActiveControl = null;
                return;
            }
            base.kkhDetailUpdFlag = true; //広告費明細変更フラグを更新 

            KKHNaviParameter naviParamOut = (KKHNaviParameter)result;
            Isid.KKH.Kmn.Schema.DetailDSKmn.KkhDetailDataTable dtKkhDetailNew = (Isid.KKH.Kmn.Schema.DetailDSKmn.KkhDetailDataTable)naviParamOut.DataTable1;
            _dsDetailKmn.KkhDetail.Clear();
            _dsDetailKmn.KkhDetail.Merge(dtKkhDetailNew);

            string JGyomuKbn = string.Empty;

            // 業務区分
            JGyomuKbn = dataRow.hb1GyomKbn.ToString().Trim();

            //明細表示項目列.
            VisibleMeisaiColumns(JGyomuKbn);

            // 差額計算 
            CalculateSagaku(dataRow);
            // ボタン活性処理 

            //btnDivide.Enabled = true;
            btnMeiSakujo.Enabled = true;

            this.ActiveControl = null;
        }

        /// <summary>
        /// 明細登録ボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMeiToroku_Click(object sender , EventArgs e)
        {
            decimal sagaku = 0M;

            if (decimal.TryParse(lblSagakuValue.Text , out sagaku) == false 
                || sagaku == 0M)
            {
                if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_C0002, null, "明細登録", MessageBoxButtons.YesNo))
                {
                    this.ActiveControl = null;
                    return;
                }
            }
            else
            {
                if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_W0089, null, "明細登録", MessageBoxButtons.YesNo))
                {
                    this.ActiveControl = null;
                    return;
                }
            }

            // 明細登録処理 
            RegistDetailData();

            //選択状態を解除 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 削除ボタンイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMeiSakujo_Click(object sender , EventArgs e)
        {
            int rowIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

            _spdKkhDetail_Sheet1.RemoveRows(rowIndex , 1);
            base.kkhDetailUpdFlag = true; //広告費明細変更フラグを更新

            //***************************************
            //ボタン類の使用可・不可設定 
            //***************************************
            if (_spdKkhDetail_Sheet1.Rows.Count > 0)
            {
                //広告費明細データが既にある場合は削除は可 
                btnMeiSakujo.Enabled = true;
                //明細登録は可 
                btnMeiToroku.Enabled = true;
            }
            else
            {
                //広告費明細データがない場合は削除は不可 
                btnMeiSakujo.Enabled = false;
                //明細入力は可 
                btnMeiNyuryoku.Enabled = true;
                //明細登録は可 
                btnMeiToroku.Enabled = true;
            }

            //合計消費税額の算出 
            CalculateGokeiZei();

            //合計金額の算出 
            CalculateGokei();

            // 対象の受注データ、明細データ取得 
            int row = _spdJyutyuList_Sheet1.ActiveRowIndex;

            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(row)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);

            // 差額計算 
            CalculateSagaku(dataRow);

            // 広告費明細変更フラグを更新 
            base.kkhDetailUpdFlag = true;

            this.ActiveControl = null;

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
        /// ヘルプボタンクリック処理 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Detail, this, HelpNavigator.KeywordIndex);
        }

        /// <summary>
        /// 一括登録ボタンクリック 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBulkRegister_Click(object sender, EventArgs e)
        {

            //**********************************
            //登録対象データ存在チェック(＋抽出) 
            //**********************************
            List<Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow> dataRowList = new List<Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow>();
            CellRange[] cellRangeArray = SortCellRangesByRowIdx(_spdJyutyuList_Sheet1.GetSelections());
            foreach (CellRange cellRange in cellRangeArray)
            {
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    //選択されている受注登録内容の行数分の処理を繰り返す 
                    int rowIndex = cellRange.Row + i;
                    DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(rowIndex)];
                    Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
                    //登録されていない&統合されていない場合のみ追加 
                    if (!listRow.togo.Equals(KkhConstKmn.TogoKbn.INTEGRATE) && !listRow.toroku.Equals(KkhConstKmn.TorokuKbn.REGISTERED))
                    {
                        Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(rowIndex);
                        dataRowList.Add(dataRow);
                    }
                }
            }

            //登録対象データが無い場合 
            if (dataRowList.Count == 0)
            {
                //"該当するデータがありません" 
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "一括登録", MessageBoxButtons.OK);
                this.ActiveControl = null;
                //登録対象データが存在しない場合は処理終了 
                return;
            }

            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable dt = new Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable();
            foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow rows in dataRowList)
            {
                dt.ImportRow(rows);
            }

            //// 明細入力画面表示 
            DetailKmnBulkRegisterNaviparameter naviParam = new DetailKmnBulkRegisterNaviparameter();
            naviParam.DataRowKmn = dataRowList;
            naviParam.EsqId = _naviParam.strEsqId;
            naviParam.Name = _naviParam.strName;
            naviParam.Egcd = _naviParam.strEgcd;
            naviParam.TksKgyCd = _naviParam.strTksKgyCd;
            naviParam.TksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            naviParam.TksTntSeqNo = _naviParam.strTksTntSeqNo;

            //明細入力画面に遷移.
            object retVal = Navigator.ShowModalForm(this, "toDetailKmnBulkRegister", naviParam);

            if (retVal != null || (retVal is DetailKmnBulkRegisterNaviparameter))
            {
                //ローディング表示開始 
                base.ShowLoadingDialog();

                DetailKmnBulkRegisterNaviparameter param = (DetailKmnBulkRegisterNaviparameter)retVal;

                //登録処理を実行する 
                DetailProcessController processController = DetailProcessController.GetInstance();
                DetailProcessController.BulkUpdateDetailDataParam registParam = new DetailProcessController.BulkUpdateDetailDataParam();
                registParam.esqId = param.strEsqId;
                registParam.dsDetailList = param.DsDetailList;
                registParam.maxUpdDate = param.LastUpdate;
                //UpdateDisplayDataServiceResult result = processController.UpdateDisplayData(param.EsqId, param.RetuenDs, param.LastUpdate);
                BulkUpdateDetailDataServiceResult result = processController.BulkUpdateDetailData(registParam);

                // オペレーションログの出力 
                KKHLogUtilityKmn.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityKmn.KINO_ID_OPERATION_LOG_BulkRegister, KKHLogUtilityKmn.DESC_OPERATION_LOG_BulkRegister);

                if (result.HasError)
                {
                    if (result.MessageCode == "LOCK-E0001")
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0148, null, "明細登録", MessageBoxButtons.OK);
                    }

                    //ローディング表示終了 
                    base.CloseLoadingDialog();

                    return;
                }

                //現在位置の取得 
                int _spdJyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

                base.SearchJyutyuData();

                //指定行を元の位置に戻す 
                _spdJyutyuList_Sheet1.SetActiveCell(_spdJyutyuListRowIdx, 0, true);
                _spdJyutyuList_Sheet1.AddSelection(_spdJyutyuListRowIdx, -1, 1, -1);
                spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

                //親の処理を呼ぶ(親のLeaveCellイベントが発生しないので) 
                base.DisplayKkhDetail(_spdJyutyuListRowIdx);
                //子の処理を呼ぶ(親↑が呼んでくれないので) 
                DisplayKkhDetail(_spdJyutyuListRowIdx);

                DisplayUpdate();

                //ローディング表示終了
                base.CloseLoadingDialog();

                //登録完了のメッセージ 
                MessageUtility.ShowMessageBox(MessageCode.HB_I0012, null, "明細登録", MessageBoxButtons.OK);
            }
        }

        # endregion イベント
        # region メソッド

        /// <summary>
        /// 差額計算 
        /// </summary>
        private void CalculateSagaku(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            // 料金合計 
            decimal ryoukinGoukei = 0;

            // 明細の件数分、繰り返す 
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                string ryoukinStr = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KINGAKU].Text.Trim();
                // 明細の料金が入力されている場合 
                if (KKHUtility.IsNumeric(ryoukinStr))
                {
                    // 料金合計に加算 
                    ryoukinGoukei = ryoukinGoukei + decimal.Parse(ryoukinStr.Trim());
                }
            }
            // 差額 
            decimal sagaku = dataRow.hb1SeiGak - ryoukinGoukei;
            lblSagakuValue.Text = sagaku.ToString("###,###,###,##0");
            // 合計 
            lblGoukeiValue.Text = ryoukinGoukei.ToString("###,###,###,##0");
        }

        /// <summary>
        /// 明細スプレッド合計消費税額計算 
        /// </summary>
        private void CalculateGokeiZei()
        {
            Decimal kingakuGokeiZei = 0;

            // 合計消費税額の計算(明細の件数分、繰り返す) 
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                kingakuGokeiZei += KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_ZEIGAKU].Value.ToString());
            }

            // 合計消費税額のセット(明細の件数分、繰り返す) 
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_GOUKEIZEIGAKU].Value = kingakuGokeiZei;
            }
        }

        /// <summary>
        /// 明細スプレッド合計金額計算 
        /// </summary>
        private void CalculateGokei()
        {
            Decimal kingakuGokei = 0;

            // 合計金額の計算(明細の件数分、繰り返す) 
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                kingakuGokei += KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KINGAKU].Value.ToString());
            }

            // 合計金額のセット(明細の件数分、繰り返す) 
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_GOUKEIKINGAKU].Value = kingakuGokei;
            }
        }

        /// <summary>
        /// 広告費明細のデータソース更新 
        /// </summary>
        /// <param name="dsDetailKmn"></param>
        private void UpdateDataSourceByDetailDataSetKmn(DetailDSKmn dsDetailKmn)
        {
            _dsDetailKmn.Clear();
            _dsDetailKmn.Merge(_dsDetailKmn);
            _dsDetailKmn.AcceptChanges();
        }

        /// <summary>
        /// データソースのバインド 
        /// </summary>
        private void InitializeDataSourceKmn()
        {
            _bsKkhDetail.DataSource = _dsDetailKmn;
            _bsKkhDetail.DataMember = _dsDetailKmn.KkhDetail.TableName;
        }

        /// <summary>
        /// 各コントロールの初期設定 
        /// </summary>
        private void ControlKmn()
        {
            //*******************
            //ボタン類 
            //*******************
            InitializeControlKmn();
        }

        /// <summary>
        /// 広告費明細スプレッドのデザイン初期化を行う 
        /// </summary>
        private void InitializeDesignForSpdKkhDetail()
        {
            //********************************
            //スプレッド全体の設定 
            //********************************
            spdKkhDetail.DataSource = _bsKkhDetail;
            _spdKkhDetail_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;//単一選択 
            _spdKkhDetail_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;       //行単位選択 
            _spdKkhDetail_Sheet1.OperationMode = OperationMode.SingleSelect;                        // 
            _spdKkhDetail_Sheet1.RowHeaderVisible = true;                                           //行ヘッダ表示 
            _spdKkhDetail_Sheet1.RowHeaderAutoText = HeaderAutoText.Numbers;                        //行ヘッダに行番号を表示

            //********************************
            //列毎の設定 
            //********************************
            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                //共通設定 
                col.Locked = true;//セルの編集不可 
                col.AllowAutoFilter = true;//フィルタ機能を有効 
                col.AllowAutoSort = true;  //ソート機能を有効 


                //列毎に異なる設定 
                if (col.Index == COLIDX_MLIST_HINMOKU1)
                {
                    col.Label = "品目１";
                    col.Width = 150;
                }
                else if (col.Index == COLIDX_MLIST_HINMOKU2)
                {
                    col.Label = "品目２";
                    col.Width = 150;
                }
                else if (col.Index == COLIDX_MLIST_HINMOKU3)
                {
                    col.Label = "品目３";
                    col.Width = 150;
                }
                else if (col.Index == COLIDX_MLIST_HIMOKU)
                {
                    col.Label = "費目";
                    col.Width = 80;
                }
                else if (col.Index == COLIDX_MLIST_KIKAN)
                {
                    col.Label = "期間";
                    col.Width = 150;
                }
                else if (col.Index == COLIDX_MLIST_BUMONCODE)
                {
                    col.Label = "部門コード";
                    col.Width = 60;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_SEIKYUSAKIBUMON)
                {
                    col.Label = "請求先部門";
                    col.Width = 80;
                }
                else if (col.Index == COLIDX_MLIST_SEIKYUYYYYMM)
                {
                    col.Label = "請求年月";
                    col.Width = 80;
                }
                else if (col.Index == COLIDX_MLIST_GOUKEIKINGAKU)
                {
                    col.Label = "合計金額";
                    col.Width = 100;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                    col.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right; 
                }
                else if (col.Index == COLIDX_MLIST_GOUKEIZEIGAKU)
                {
                    col.Label = "消費税合計";
                    col.Width = 100;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                    col.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right; 
                }
                else if (col.Index == COLIDX_MLIST_NAIYOU)
                {
                    col.Label = "内容（明細）";
                    col.Width = 200;
                    //col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_HIMOKU_M)
                {
                    col.Label = "費目（明細）";
                    col.Width = 80;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_KIKAN_M)
                {
                    col.Label = "期間（明細）";
                    col.Width = 150;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_KINGAKU)
                {
                    col.Label = "金額（明細）";
                    col.Width = 100;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                    col.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                    //col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_ZEIGAKU)
                {
                    col.Label = "消費税額（明細）";
                    col.Width = 100;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                    col.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                    //col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_BIKO)
                {
                    col.Label = "備考（明細）";
                    col.Width = 150;
                    col.Visible = false;
                }
            }
        }

        /// <summary>
        /// 各コントロールの初期設定 
        /// </summary>
        private void InitializeControlKmn()
        {
            //******************
            //検索条件部 
            //******************
            lblKenMei.Visible = true;
            txtKenMei.Visible = true;
            lblKikan.Visible = true;
            txtYmdTo.Visible = true;

            //*******************
            //ボタン類
            //*******************
            this.btnDelJyutyu.Enabled = true;
            this.btnRegJyutyu.Enabled = true;       //受注新規.
            this.btnMeiNyuryoku.Enabled = false;    //明細入力.
            this.btnMeiToroku.Enabled = false;      //明細登録.
            this.btnMeiSakujo.Enabled = false;      //明細削除.

            this.btnMerge.Visible = true;           //受注統合.
            this.btnMergeCancel.Visible = true;    　//統合取消.

            //2013/07/11 Add HLC H.Watabe -- 公文一括登録対応 
            this.btnBulkRegister.Enabled = false;

        }

        // 2013/04/23 件名のオートコンプリート対応 JSE M.Naito Add
        /// <summary>
        /// 件名の初期設定 
        /// </summary>
        private void InitializeKenmeiKmn()
        {
            // オートコンプリートのモード指定
            txtKenMei.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            // ソース元はカスタムにする
            txtKenMei.AutoCompleteSource = AutoCompleteSource.CustomSource;
            
            // オートコンプリート候補となる文字列を宛先マスタの比較項目から取得
            AutoCompleteStringCollection autoCompList = new AutoCompleteStringCollection();
            autoCompList = (AutoCompleteStringCollection)GetHikakuKokokuValue();
            
            // オートコンプリート候補となる文字列をセット
            txtKenMei.AutoCompleteCustomSource = autoCompList;
        }

        // 2013/04/23 件名のオートコンプリート対応 JSE M.Naito Add
        /// <summary>
        /// 比較項目を取得する
        /// </summary>
        private AutoCompleteStringCollection GetHikakuKokokuValue()
        {
            // 戻り値のリスト
            AutoCompleteStringCollection resList = new AutoCompleteStringCollection();

            MasterMaintenanceProcessController process =
                MasterMaintenanceProcessController.GetInstance();

            FindMasterMaintenanceByCondServiceResult result;

            // 比較項目 
            result = process.FindMasterByCond(_naviParam.strEsqId,
                                            _naviParam.strEgcd,
                                            _naviParam.strTksKgyCd,
                                            _naviParam.strTksBmnSeqNo,
                                            _naviParam.strTksTntSeqNo,
                                             DetailKmn.C_MST_ATESAKI,
                                            null);

            if (result.MasterDataSet.MasterDataVO != null)
            {
                // 比較項目をリストへ格納
                foreach (MasterMaintenance.MasterDataVORow row in result.MasterDataSet.MasterDataVO)
                {
                    string str = row.Column4;
                    // 【】をはずす
                    str = str.Replace("【", "");
                    str = str.Replace("】", "");
                    resList.Add(str);
                }
            }

            return resList;
        }

        /// <summary>
        /// 表示列の表示処理を行う. 
        /// </summary>
        protected void VisibleMeisaiColumns(string GyomKbn)
        {
            //共通 幅を変更 
            //品目１ 
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_HINMOKU1].Width = 150;
            //品目２ 
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_HINMOKU2].Width = 150;
            //品目３ 
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_HINMOKU3].Width = 150;
            //費目 
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_HIMOKU].Width = 80;
            //期間
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KIKAN].Width = 150;
            //部門コード 
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_BUMONCODE].Width = 80;
            //TODO:テスト時コメントアウト 
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_BUMONCODE].Visible = false;
            //請求先部門 
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_SEIKYUSAKIBUMON].Width = 80;
            //請求年月
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_SEIKYUYYYYMM].Width = 80;
            //合計金額 
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_GOUKEIKINGAKU].Width = 100;
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_GOUKEIKINGAKU].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            //合計消費税額 
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_GOUKEIZEIGAKU].Width = 100;
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_GOUKEIZEIGAKU].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            //内容 
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_NAIYOU].Width = 200;
            //費目 
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_HIMOKU_M].Width = 80;
            //金額 
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KINGAKU].Width = 100;
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KINGAKU].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            //消費税額 
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_ZEIGAKU].Width = 100;
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_ZEIGAKU].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            //期間
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KIKAN_M].Width = 150;
            //備考
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_BIKO].Width = 150;
        }

        /// <summary>
        /// 明細登録処理 
        /// </summary>
        private void RegistDetailData()
        {
            //ローディング表示開始 
            base.ShowLoadingDialog();

            //サービスパラメータ用変数 
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();
            string esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            DateTime maxUpdDate = new DateTime();

            //*********************************************
            //THB1DOWNの登録データ編集 
            //*********************************************
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(_spdJyutyuList_Sheet1.ActiveRowIndex)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);

            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();

            //thb1DownRow.hb1TimStmp = new DateTime(); 
            thb1DownRow.hb1UpdApl = "DtlKmn";//TODO 
            thb1DownRow.hb1UpdTnt = _naviParam.strEsqId;
            thb1DownRow.hb1EgCd = _naviParam.strEgcd;
            thb1DownRow.hb1TksKgyCd = _naviParam.strTksKgyCd;
            thb1DownRow.hb1TksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            thb1DownRow.hb1TksTntSeqNo = _naviParam.strTksTntSeqNo;
            thb1DownRow.hb1Yymm = dataRow.hb1Yymm;
            thb1DownRow.hb1JyutNo = dataRow.hb1JyutNo;
            thb1DownRow.hb1JyMeiNo = dataRow.hb1JyMeiNo;
            thb1DownRow.hb1UrMeiNo = dataRow.hb1UrMeiNo;
            //未請求フラグ 
            if (Isid.KKH.Common.KKHUtility.KKHUtility.DecParse(lblSagakuValue.Text) == 0)
            {
                thb1DownRow.hb1MSeiFlg = "0";
            }
            else
            {
                thb1DownRow.hb1MSeiFlg = "1";
            }

            //明細行が存在する場合 
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
                    thb1DownRow.hb1KsnTnt = _naviParam.strEsqId.Trim();
                    //更新担当者名 
                    thb1DownRow.hb1KsnTntNm = _naviParam.strName.Trim();
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
                    thb1DownRow.hb1TrkTnt = _naviParam.strEsqId.Trim();
                    //登録者名 
                    thb1DownRow.hb1TrkTntNm = _naviParam.strName.Trim();
                    //更新者 
                    thb1DownRow.hb1KsnTnt = _naviParam.strEsqId.Trim();
                    //更新担当者名 
                    thb1DownRow.hb1KsnTntNm = _naviParam.strName.Trim();
                }
                //登録者が空の場合 
                else if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()))
                {
                    //登録者のみを入れる 
                    //登録者 
                    thb1DownRow.hb1TrkTnt = _naviParam.strEsqId.Trim();
                    //登録者名
                    thb1DownRow.hb1TrkTntNm = _naviParam.strName.Trim();
                    //更新者のみを入れる 
                    //更新者 
                    thb1DownRow.hb1KsnTnt = _naviParam.strEsqId.Trim();
                    //更新担当者名
                    thb1DownRow.hb1KsnTntNm = _naviParam.strName.Trim();
                }
                else
                {
                    //更新者のみを入れる 
                    //更新者 
                    thb1DownRow.hb1KsnTnt = _naviParam.strEsqId.Trim();
                    //更新担当者名 
                    thb1DownRow.hb1KsnTntNm = _naviParam.strName.Trim();
                }
            }


            thb1DownRow.hb1TouFlg = dataRow.hb1TouFlg;
            //thb1DownRow.hb1TouFlg = "0";
            dtThb1Down.AddTHB1DOWNRow(thb1DownRow);

            dsDetail.THB1DOWN.Merge(dtThb1Down);

            //*********************************************
            //THB2KMEIの登録データ編集 
            //*********************************************
            int jyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;
            Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable dtThb2Kmei = new Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable();
            for (int i = 0 ; i < _spdKkhDetail_Sheet1.RowCount ; i++)
            {
                object cellValue = null;

                Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow addRow = dtThb2Kmei.NewTHB2KMEIRow();

                addRow.hb2TimStmp = new DateTime();
                addRow.hb2UpdApl = "DtlKmn";//TODO
                addRow.hb2UpdTnt = _naviParam.strEsqId;
                addRow.hb2EgCd = _naviParam.strEgcd;
                addRow.hb2TksKgyCd = _naviParam.strTksKgyCd;
                addRow.hb2TksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                addRow.hb2TksTntSeqNo = _naviParam.strTksTntSeqNo;
                addRow.hb2Yymm = dataRow.hb1Yymm;
                addRow.hb2JyutNo = dataRow.hb1JyutNo;
                addRow.hb2JyMeiNo = dataRow.hb1JyMeiNo;
                addRow.hb2UrMeiNo = dataRow.hb1UrMeiNo;
                // TODO：費目コードは必要？ 
                addRow.hb2HimkCd = dataRow.hb1HimkCd;
                //addRow.hb2HimkCd = "   ";
                //addRow.hb2Renbn = (i + 1).ToString("000");  明細登録件数拡張対応
                addRow.hb2Renbn = (i + 1).ToString("0000");
                addRow.hb2DateFrom = " ";
                addRow.hb2DateTo = " ";
                //合計金額.
                //addRow.hb2SeiGak = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_GOUKEIKINGAKU].Value;
                addRow.hb2SeiGak = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_GOUKEIKINGAKU].Value.ToString());
                addRow.hb2Hnnert = 0M;
                addRow.hb2HnmaeGak = 0M;
                addRow.hb2NebiGak = 0M;
                addRow.hb2Date1 = " ";
                addRow.hb2Date2 = " ";
                addRow.hb2Date3 = " ";
                addRow.hb2Date4 = " ";
                addRow.hb2Date5 = " ";
                addRow.hb2Date6 = " ";

                addRow.hb2Kbn1 = " ";
                addRow.hb2Kbn2 = " ";
                addRow.hb2Kbn3 = " ";

                //部門コード. 
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUMONCODE].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Code1 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Code1 = " ";
                }
                addRow.hb2Code2 = " ";
                addRow.hb2Code3 = " ";
                addRow.hb2Code4 = " ";
                addRow.hb2Code5 = " ";
                addRow.hb2Code6 = " ";

                //費目名.
                addRow.hb2Name1 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HIMOKU_M].Value.ToString();
                //期間.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KIKAN_M].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Name2 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name2 = " ";
                }
                //品名２.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HINMOKU2].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Name3 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name3 = " ";
                }
                //品名３.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HINMOKU3].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Name4 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name4 = " ";
                }
                //請求先部門.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSAKIBUMON].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Name5 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name5 = " ";
                }
                //請求年月
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUYYYYMM].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Name6 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name6 = " ";
                }
                addRow.hb2Name7 = " ";
                //品名１.
                addRow.hb2Name8 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HINMOKU1].Value.ToString();
                //addRow.hb2Name9 = " ";
                //addRow.hb2Name10 = " ";
                //費目名.
                addRow.hb2Name9 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HIMOKU].Value.ToString();
                //期間.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KIKAN].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Name10 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name10 = " ";
                }

                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NAIYOU].Text.Length >= 50)
                {
                    //内容(1) 
                    addRow.hb2Name11 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NAIYOU].Value.ToString().Substring(0, 50);
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NAIYOU].Text.Length >= 100)
                    {
                        //内容(2) 
                        addRow.hb2Name12 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NAIYOU].Value.ToString().Substring(50, 50);
                        if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NAIYOU].Text.Length >= 150)
                        {
                            //内容(3) 
                            addRow.hb2Name13 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NAIYOU].Value.ToString().Substring(100, 50);
                            //内容(4)
                            addRow.hb2Name14 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NAIYOU].Value.ToString().Substring(150);
                        }
                        else
                        {
                            //内容(3) 
                            addRow.hb2Name13 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NAIYOU].Value.ToString().Substring(100);
                            //内容(4)
                            addRow.hb2Name14 = " ";
                        }

                    }
                    else
                    {
                        //内容(2) 
                        addRow.hb2Name12 = addRow.hb2Name12 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NAIYOU].Value.ToString().Substring(50);
                        //内容(3) 
                        addRow.hb2Name13 = " ";
                        //内容(4)
                        addRow.hb2Name14 = " ";
                    }
                }
                else
                {
                    //内容(1) 
                    addRow.hb2Name11 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NAIYOU].Value.ToString();
                    //内容(2) 
                    addRow.hb2Name12 = " ";
                    //内容(3) 
                    addRow.hb2Name13 = " ";
                    //内容(4)
                    addRow.hb2Name14 = " ";
                }
                //備考 
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BIKO].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Name15 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name15 = " ";
                }

                //金額.
                //addRow.hb2Kngk1 = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KINGAKU].Value;
                addRow.hb2Kngk1 = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KINGAKU].Value.ToString());
                //消費税額.
                addRow.hb2Kngk2 = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_ZEIGAKU].Value.ToString());
                //合計消費税額.
                addRow.hb2Kngk3 = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_GOUKEIZEIGAKU].Value.ToString());

                addRow.hb2Ritu1 = 0M;
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
                addRow.hb2MeihnFlg = " ";
                addRow.hb2NebhnFlg = " ";

                dtThb2Kmei.AddTHB2KMEIRow(addRow);
            }
            dsDetail.THB2KMEI.Merge(dtThb2Kmei);
            //dsDetail.AcceptChanges();

            //更新日付最大値の判定             
            //統合されている場合 
            if (dataRow.hb1TouFlg == "1")
            {
                //統合されている受注登録内容のデータから更新日付の最大値を取得する。 
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
            UpdateDisplayDataServiceResult result = processController.UpdateDisplayData(esqId , dsDetail , maxUpdDate);

            if (result.HasError)
            {
                if (result.MessageCode == "LOCK-E0001")
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0148, null, "明細登録", MessageBoxButtons.OK);
                }

                //ローディング表示終了 
                base.CloseLoadingDialog();

                return;
            }

            base.kkhDetailUpdFlag = false; //広告費明細変更フラグを更新 
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                //明細登録"済"を設定 
                //listRow.toroku = "済";
                listRow.toroku = KkhConstKmn.TorokuKbn.REGISTERED;
            }
            else
            {
                //明細登録"済"を解除 
                //listRow.toroku = "";
                listRow.toroku = KkhConstKmn.TorokuKbn.YET;
            }


            //現在位置の取得 
            int _spdJyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            base.SearchJyutyuData();

            //指定行を元の位置に戻す 
            _spdJyutyuList_Sheet1.SetActiveCell(_spdJyutyuListRowIdx, 0, true);
            _spdJyutyuList_Sheet1.AddSelection(_spdJyutyuListRowIdx, -1, 1, -1);
            spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

            //親の処理を呼ぶ(親のLeaveCellイベントが発生しないので) 
            base.DisplayKkhDetail(_spdJyutyuListRowIdx);
            //子の処理を呼ぶ(親↑が呼んでくれないので) 
            DisplayKkhDetail(_spdJyutyuListRowIdx);

            DisplayUpdate();

            //ローディング表示終了 
            base.CloseLoadingDialog();

            //MessageBox.Show("広告費明細の登録が完了しました。" , "明細登録" , MessageBoxButtons.OK);
            MessageUtility.ShowMessageBox(MessageCode.HB_I0012, null, "明細登録", MessageBoxButtons.OK);
        }


        /// <summary>
        /// 新規作成ダイアログ表示前チェック 
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeRegJyutyu()
        {
            return base.CheckBeforeRegJyutyu();
        }

        # endregion メソッド

    }
}