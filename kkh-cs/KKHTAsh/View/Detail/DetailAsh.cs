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
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Ash.Schema;
using Isid.KKH.Ash.ProcessController.Detail;
using Isid.KKH.Ash.Utility;
using dsDetail = Isid.KKH.Common.KKHSchema.Detail;
using drJyutyuData = Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow;
using drDetailData = Isid.KKH.Ash.Schema.DetailDSAsh.DetailDataAshRow;
using drKkhDetail = Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailRow;
using dtTHB1DOWN = Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable;
using drTHB1DOWN = Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow;
using dtTHB2KMEI = Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable;
using drTHB2KMEI = Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow;

namespace Isid.KKH.Ash.View.Detail
{
    /// <summary>
    /// 広告費明細登録画面.
    /// </summary>
    public partial class DetailAsh : DetailForm
    {
        #region 定数.
        #region 明細一覧カラムインデックス.
        /// <summary>
        /// 請求書番号列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SEINO = 0;
        /// <summary>
        /// 件名列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KENMEI = 1;
        /// <summary>
        /// 局コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KYOKUCD = 2;
        /// <summary>
        /// 品種コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_HINSYUCD = 3;
        /// <summary>
        /// 費目名称列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_HIMOKUNM = 4;
        /// <summary>
        /// 見積金額列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_HNMAEGAK = 5;
        /// <summary>
        /// 値引率列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_HNNERT = 6;
        /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
        /// <summary>
        /// 値引額列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_NEBIKIGAKU = 7;
        /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
        /// <summary>
        /// 請求金額列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SEIGAK = 8;
        /// <summary>
        /// 消費税率列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_ZEIRITSU = 9;
        /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
        /// <summary>
        /// 消費税額列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_ZEIGAKU = 10;
        /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
        /// <summary>
        /// 期間列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KIKAN = 11;
        /// <summary>
        /// 媒体コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_BAITAICD = 12;
        /// <summary>
        /// 媒体コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_TOKUIBAITAICD = 13;
        /// <summary>
        /// 代理店コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_DAIRITENCD = 14;
        /// <summary>
        /// 番組コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_BANGUMICD = 15;
        /// <summary>
        /// 売上明細NO列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_URIMEINO = 16;
        /// <summary>
        /// 秒数列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_BYOUSU = 17;
        /// <summary>
        /// 本数列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_HONSU = 18;
        /// <summary>
        /// 表示順列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_HYOUJIJYUN = 19;
        /// <summary>
        /// 掲載・発売日列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KEISAIDT = 20;
        /// <summary>
        /// 朝夕区分列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_TYOUSEKIKBN = 21;
        /// <summary>
        /// 記雑区分列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KIZATSUKBN = 22;
        /// <summary>
        /// 掲載版列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KEISAIBAN = 23;
        /// <summary>
        /// 端数処理区分列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_HASUSYORIKBN = 24;
        /// <summary>
        /// 入力比率列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_NYURYOKUHIRITU = 25;
        /// <summary>
        /// スペース列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SPACE = 26;
        /// <summary>
        /// 放送時間列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_HOSOUJIKAN = 27;
        /// <summary>
        /// 曜日列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_YOUBI = 28;
        /// <summary>
        /// 局ネット数列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KYOKUNETSU = 29;
        /// <summary>
        /// キー局コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KEYKYOKUCD = 30;
        /// <summary>
        /// FD明細列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_FDDETAILOUTPUT = 31;
        #endregion 明細(一覧)カラムインデックス.

        /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
        #region 明細一覧カラム名称.
        /// <summary>
        /// 請求書番号.
        /// </summary>
        public const string COL_NAME_SEINO = "請求書番号";
        /// <summary>
        /// 件名.
        /// </summary>
        public const string COL_NAME_KENMEI = "件名";
        /// <summary>
        /// 局コード.
        /// </summary>
        public const string COL_NAME_KYOKUCD = "局コード";
        /// <summary>
        /// 品種コード.
        /// </summary>
        public const string COL_NAME_HINSYUCD = "品種コード";
        /// <summary>
        /// 費目名称.
        /// </summary>
        public const string COL_NAME_HIMOKUNM = "費目名称";
        /// <summary>
        /// 見積金額.
        /// </summary>
        public const string COL_NAME_HNMAEGAK = "見積金額";
        /// <summary>
        /// 値引率.
        /// </summary>
        public const string COL_NAME_HNNERT = "値引率";
        /// <summary>
        /// 値引額.
        /// </summary>
        public const string COL_NAME_NEBIKIGAKU = "値引額";
        /// <summary>
        /// 請求金額.
        /// </summary>
        public const string COL_NAME_SEIGAK = "請求金額";
        /// <summary>
        /// 消費税率.
        /// </summary>
        public const string COL_NAME_ZEIRITSU = "消費税率";
        /// <summary>
        /// 消費税額.
        /// </summary>
        public const string COL_NAME_ZEIGAKU = "消費税額";
        /// <summary>
        /// 期間.
        /// </summary>
        public const string COL_NAME_KIKAN = "期間";
        /// <summary>
        /// 媒体コード.
        /// </summary>
        public const string COL_NAME_BAITAICD = "媒体コード";
        /// <summary>
        /// 得意先媒体コード.
        /// </summary>
        public const string COL_NAME_TOKUIBAITAICD = "媒体コード";
        /// <summary>
        /// 代理店コード.
        /// </summary>
        public const string COL_NAME_DAIRITENCD = "代理店コード";
        /// <summary>
        /// 番組コード.
        /// </summary>
        public const string COL_NAME_BANGUMICD = "番組コード";
        /// <summary>
        /// 売上明細NO.
        /// </summary>
        public const string COL_NAME_URIMEINO = "売上明細No";
        /// <summary>
        /// 掲載日.
        /// </summary>
        public const string COL_NAME_KEISAIDT = "掲載日";
        #endregion 明細一覧カラム名称.
        /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
        #endregion 定数.

        #region メンバ変数.
        /// <summary>
        /// ナビパラメーター.
        /// </summary>
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();
        /// <summary>
        /// ターゲット媒体コード.
        /// </summary>
        private string _targetBaitaiCd = "";
        #endregion メンバ変数.

        #region コンストラクタ.
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DetailAsh()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ.

        #region オーバーライド.
        #region スプレッド全体に対する初期表示の設定を行う.
        /// <summary>
        /// スプレッド全体に対する初期表示の設定を行う.
        /// </summary>
        protected override void InitDesignForSpdJyutyuListSpread()
        {
            //受注登録内容(一覧)スプレッドのスプレッド・シートの設定を行う.
            base.InitDesignForSpdJyutyuListSpread();
        }
        #endregion スプレッド全体に対する初期表示の設定を行う.

        #region スプレッドの列に対する初期表示の設定を行う.
        /// <summary>
        /// スプレッドの列に対する初期表示の設定を行う.
        /// </summary>
        /// <param name="col"></param>
        protected override void InitDesignForSpdJyutyuListColumns(Column col)
        {
            //受注登録内容(一覧)スプレッドの列単位の設定を行う.
            base.InitDesignForSpdJyutyuListColumns(col);
        }
        #endregion スプレッドの列に対する初期表示の設定を行う.

        #region 得意先別に表示対象外列の非表示処理を行う.
        /// <summary>
        /// 得意先別に表示対象外列の非表示処理を行う.
        /// </summary>
        protected override void VisibleColumns()
        {
            //親クラスの行っている共通処理を実行.
            base.VisibleColumns();

            //受注カラム分ループ処理.
            foreach (Column col in base._spdJyutyuList_Sheet1.Columns)
            {
                if (col.Index == COLIDX_JLIST_TOROKU) { col.Visible = true; }           //登録.
                if (col.Index == COLIDX_JLIST_TOGO) { col.Visible = false; }            //統合. 
                if (col.Index == COLIDX_JLIST_DAIUKE){ col.Visible = true; }            //代受.
                if (col.Index == COLIDX_JLIST_SEIKYU) { col.Visible = false; }          //請求.
                if (col.Index == COLIDX_JLIST_URIMEINO) { col.Visible = true; }         //売上明細NO.
                if (col.Index == COLIDX_JLIST_GPYNO) { col.Visible = false; }           //請求原票NO.
                if (col.Index == COLIDX_JLIST_SEIYYMM){ col.Visible = true; }           //請求年月.
                if (col.Index == COLIDX_JLIST_GYOMKBN){ col.Visible = true; }           //業務区分.
                if (col.Index == COLIDX_JLIST_KENMEI){ col.Visible = true; }            //件名.
                if (col.Index == COLIDX_JLIST_BAITAINM) { col.Visible = false; }        //媒体名.
                if (col.Index == COLIDX_JLIST_HIMOKUNM){ col.Visible = true; }          //費目名.
                if (col.Index == COLIDX_JLIST_KYOKUSHICD){ col.Visible = false; }       //局誌CD.
                if (col.Index == COLIDX_JLIST_SEIKINGAKU){ col.Visible = true; }        //請求金額.
                if (col.Index == COLIDX_JLIST_KIKAN){ col.Visible = false; }            //期間.
                if (col.Index == COLIDX_JLIST_DANTANKA) { col.Visible = false; }        //段単価.
                if (col.Index == COLIDX_JLIST_DANSU) { col.Visible = false; }           //段数.
                if (col.Index == COLIDX_JLIST_TORIRYOKIN){ col.Visible = true; }        //取料金.
                if (col.Index == COLIDX_JLIST_NEBIKIRITSU){ col.Visible = true; }       //値引率.
                if (col.Index == COLIDX_JLIST_NEBIKIGAKU){ col.Visible = true; }        //値引額.
                if (col.Index == COLIDX_JLIST_ZEIRITSU){ col.Visible = true; }          //消費税率.
                if (col.Index == COLIDX_JLIST_ZEIGAKU){ col.Visible = true; }           //消費税額.
                if (col.Index == COLIDX_JLIST_GOUKEIKINGAKU){ col.Visible = false; }    //受注請求金額.
                if (col.Index == COLIDX_JLIST_OLDSEIYYMM){ col.Visible = true; }        //変更前請求年月.
            }
        }
        #endregion 得意先別に表示対象外列の非表示処理を行う.

        #region セルの色付け処理を行う.
        /// <summary>
        /// セルの色付け処理を行う.
        /// </summary>
        protected override void ChangeColor()
        {
            //セルの色付け処理.
            base.ChangeColor();

            //受注データ分ループ処理.
            for (int i = 0; i < _spdJyutyuList_Sheet1.Rows.Count; i++)
            {
                //指定した受注登録内容(一覧)の行に紐づく検索受注登録内容データを取得する.
                drJyutyuData dataRow = getSelectJyutyuData(i);

                //統合フラグ="1"の行は背景色を変更.
                if (dataRow.hb1TouFlg == KKHSystemConst.Tougou.TOUGOU_FLG)
                {
                    _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(255, 255, 208);
                }
                //変更前請求年月が設定されている(年月変更が行われている)場合は請求年月を赤文字にする.
                if (dataRow.hb1YymmOld != "")
                {
                    _spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_SEIYYMM].ForeColor = Color.Red;
                }
            }
        }
        #endregion セルの色付け処理を行う.

        #region 広告費明細データの検索・表示.
        /// <summary>
        /// 広告費明細データの検索・表示.
        /// </summary>
        /// <param name="rowIdx"></param>
        protected override void DisplayKkhDetail(int rowIdx)
        {
            //広告費明細の初期化.
            _dsDetailAsh.DetailDataAsh.Clear();

            //変更中フラグを戻す.
            kkhDetailUpdFlag = false;

            //広告費明細データの取得.
            DetailAshProcessController.FindDetailDataAshByCondParam param = new DetailAshProcessController.FindDetailDataAshByCondParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;

            //指定した受注登録内容一覧の行に紐づく検索受注登録内容データを取得する.
            drJyutyuData dataRow = getSelectJyutyuData(rowIdx);

            //受注登録内容一覧のアクティブなシートを取得する.
            SheetView activeSheet = GetActiveSheetViewBySpdJyutyuList();

            //活性化しているシートが受注登録一覧の場合.
            if (activeSheet == _spdJyutyuList_Sheet1)
            {
                //営業所(取)コード.
                param.egCd = dataRow.hb1EgCd;
                //得意先企業コード.
                param.tksKgyCd = dataRow.hb1TksKgyCd;
                //得意先部門SEQNO.
                param.tksBmnSeqNo = dataRow.hb1TksBmnSeqNo;
                //得意先担当SEQNO.
                param.tksTntSeqNo = dataRow.hb1TksTntSeqNo;
                //年月.
                param.yymm = dataRow.hb1Yymm;
                //受注No.
                param.jyutNo = dataRow.hb1JyutNo;
                //受注明細No.
                param.jyMeiNo = dataRow.hb1JyMeiNo;
                //売上明細No.
                param.urMeiNo = dataRow.hb1UrMeiNo;
                //業務区分.
                param.gyomKbn = dataRow.hb1GyomKbn;
                //タイムスポット区分.
                param.tmSpKbn = dataRow.hb1TmspKbn;
                //国際区分.
                param.kokKbn = dataRow.hb1KokKbn;
                //請求区分.
                param.seiKbn = dataRow.hb1SeiKbn;

                //広告費明細データの検索.
                DetailAshProcessController processController = DetailAshProcessController.GetInstance();
                FindDetailDataAshByCondServiceResult result = processController.FindDetailDataAshByCond(param);
                //エラーの場合、何もしない.
                if (result.HasError == true)
                {
                    return;
                }

                //広告費明細データセット.
                _dsDetailAsh.DetailDataAsh.Merge(result.DetailAshDataSet.DetailDataAsh);
                _dsDetailAsh.DetailDataAsh.AcceptChanges();
                _targetBaitaiCd = result.TargetBaitaiCd;
            }

            //表示用広告費明細データの編集・表示.
            _dsDetailAsh.KkhDetail.Clear();
            /* 2015/03/09 アサヒ対応 JSE K.Miyanoue ADD Start */
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParameter.strEsqId, _naviParameter.strEgcd, _naviParameter.strTksKgyCd, _naviParameter.strTksBmnSeqNo, _naviParameter.strTksTntSeqNo);
            /* 2015/03/09 アサヒ対応 JSE K.Miyanoue ADD End */

            //広告費明細データ件数分、ループ処理.
            foreach (drDetailData row in _dsDetailAsh.DetailDataAsh.Rows)
            {
                //初期設定.
                drKkhDetail addRow = _dsDetailAsh.KkhDetail.NewKkhDetailRow();

                //請求番号.
                addRow.seiNo = row.hb2Name4;
                /* 2013/01/17 JSE M.Naito MOD Start */
                //addRow.kenmei = row.hb2Name8;
                //件名.
                addRow.kenmei = row.hb2Name10;
                /* 2013/01/17 JSE M.Naito MOD End */
                //媒体コードが[雑誌]の場合.
                if (_targetBaitaiCd == KkhConstAsh.BaitaiCd.ZASHI)
                {
                    //局コード.
                    addRow.kyokuCd = row.hb2Code2 + KKHSystemConst.Kigou.SPACE + row.kyokuField2 + KKHSystemConst.Kigou.SPACE + row.hb2Code6;
                }
                //媒体コードが[テレビタイム、テレビスポット、ラジオタイム、ラジオスポット、テレビネットスポット]の場合.
                else if (_targetBaitaiCd == KkhConstAsh.BaitaiCd.TV_TIME
                    || _targetBaitaiCd == KkhConstAsh.BaitaiCd.TV_SPOT
                    || _targetBaitaiCd == KkhConstAsh.BaitaiCd.RADIO_TIME
                    || _targetBaitaiCd == KkhConstAsh.BaitaiCd.RADIO_SPOT
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD Start */
                    || _targetBaitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD End */
                {
                    //局コード.
                    addRow.kyokuCd = row.hb2Code2 + KKHSystemConst.Kigou.SPACE + row.kyokuField4 + KKHSystemConst.Kigou.SPACE + row.kyokuField2;
                }
                else
                {
                    //局コード.
                    addRow.kyokuCd = row.hb2Code2 + KKHSystemConst.Kigou.SPACE + row.kyokuField2;
                }
                //品種コード.
                addRow.hinsyuCd = row.hb2Code3 + KKHSystemConst.Kigou.SPACE + row.shouhinField2;//T
                //費目名称.
                addRow.himokuNm = row.hb2Name2;
                //値引率変更前金額.
                addRow.hnmaeGak = row.hb2HnmaeGak;
                //値引率.
                addRow.hnNeRt = row.hb2Hnnert;
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
                //値引額.
                addRow.nebikiGaku = row.hb2NebiGak;
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
                //請求金額.
                addRow.seiGak = row.hb2SeiGak;
                //消費税率.
                addRow.zeiRitsu = row.hb2Ritu1;
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
                //消費税額.
                addRow.zeiGaku = row.hb2Kngk1;
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
                //期間.
                if (string.IsNullOrEmpty(row.hb2Name11)) 
                {
                    addRow.kikan = String.Empty;
                }
                else
                {
                    addRow.kikan = row.hb2Name11.ToString();
                }
                //媒体コード.
                addRow.baitaiCd = row.hb2Code1;
                //代理店コード.
                addRow.dairitenCd = row.hb2Code4;
                //番組コード.
                addRow.bangumiCd = row.hb2Code5;
                //売上明細No.
                addRow.uriMeiNo = row.hb2Name3;
                //秒数.
                addRow.byouSuu = row.hb2Sonota1;
                //本数.
                addRow.honSuu = row.hb2Sonota2;
                //表示順.
                addRow.hyouziJun = String.Empty;
                /* 2013/04/08 HLC T.Sonobe MOD Start */
                //addRow.keisaiHatsubaiBi = FormatPeriod(row.hb2Name5);
                //掲載発売日.
                //媒体コードが雑誌、新聞の場合.
                if (_targetBaitaiCd == KkhConstAsh.BaitaiCd.ZASHI || _targetBaitaiCd == KkhConstAsh.BaitaiCd.SHINBUN)
                {
                    addRow.keisaiHatsubaiBi = FormatPeriod(row.hb2Name5);
                }
                else
                {
                    addRow.keisaiHatsubaiBi = row.hb2Name5;
                }
                /* 2013/04/08 HLC T.Sonobe MOD End */
                //朝夕区分.
                addRow.asaYuuKbn = row.hb2Sonota3;
                //記雑区分.
                addRow.kizatsuKbn = row.hb2Sonota5;
                //掲載番号.
                addRow.keisaiBan = row.hb2Sonota6;
                //端数処理区分.
                addRow.hasuuSyoriKbn = row.hb2Kbn1;
                //入力比率.
                addRow.nyuuryokuHiritsu = row.hb2Ritu2.ToString();
                //スペース.
                addRow.space = row.hb2Name1;
                //放送時間.
                addRow.housouZikan = row.hb2Name6;
                //曜日.
                addRow.youbi = row.hb2Name9;
                //局ネット数.
                addRow.kyokuNetSuu = row.hb2Sonota7;
                //キー局コード.
                addRow.keyKyokuCd = row.hb2Sonota8;
                //FD明細.
                addRow.fd = row.hb2Sonota9;

                /* 2015/03/09 アサヒ対応 JSE K.Miyanoue ADD Start */
                //媒体コードを変換する.
                AshBaitaiUtility.BaitaiResult res = ashBaitaiUtility.ConvertOldCdToNewCd(addRow.baitaiCd);
                addRow.tokuiBaitaiCd = res.baitaiCd;
                /* 2015/03/09 アサヒ対応 JSE K.Miyanoue ADD End */
                _dsDetailAsh.KkhDetail.AddKkhDetailRow(addRow);
            }
            _dsDetailAsh.KkhDetail.AcceptChanges();

            //広告費明細データが1件以上存在する場合.
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                //選択範囲の設定.
                _spdKkhDetail_Sheet1.AddSelection(0, 0, 1, 1);
            }

            /*
             * ボタン類の使用可・不可設定.
             */
            //明細入力.
            btnDetailInput.Enabled = true;
            //明細登録.
            btnDetailRegister.Enabled = true;

            //広告費明細データが1件以上存在する場合、分割・削除は可.
            if (_dsDetailAsh.KkhDetail.Rows.Count > 0)
            {
                btnDetailDel.Enabled = true;
            }
            //広告費明細データが1件も存在しない場合、分割・削除は不可.
            else
            {
                btnDetailDel.Enabled = false;
            }

            //業務区分が[新聞][雑誌]の場合.
            if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Shinbun || dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Zashi)
            {
                //[期間]を非表示.
                _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KIKAN].Visible = false;
                //[掲載日]を表示.
                _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KEISAIDT].Visible = true;
                //業務区分が[新聞]の場合.
                if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Shinbun)
                {
                    //新聞発売日.
                    _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KEISAIDT].Label = KKHSystemConst.KoteiMongon.KEISAI_DATE_SHINBUN;
                }
                else
                {
                    //雑誌掲載日.
                    _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KEISAIDT].Label = KKHSystemConst.KoteiMongon.KEISAI_DATE_ZASSI;
                }
            }
            else
            {
                //[期間]を表示.
                _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KIKAN].Visible = true;
                //[掲載日]を非表示.
                _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KEISAIDT].Visible = false;
            }

            //差額計算 
            CalculateSagaku(dataRow);
        }
        #endregion 広告費明細データの検索・表示.

        #region 受注登録内容検索前チェック処理.
        /// <summary>
        /// 受注登録内容検索前チェック処理.
        /// </summary>
        /// <returns></returns>
        protected override Boolean CheckBeforeSearch()
        {
            //受注登録内容検索前チェック処理.
            if (base.CheckBeforeSearch() == false)
            {
                return false;
            }

            return true;
        }
        #endregion 受注登録内容検索前チェック処理.

        #region 受注登録内容検索前クリア処理.
        /// <summary>
        /// 受注登録内容検索前クリア処理.
        /// </summary>
        protected override void InitializeBeforeSearch()
        {
            //受注登録内容検索前クリア処理.
            base.InitializeBeforeSearch();

            /*
             * ラベル初期化.
             */
            //計.
            lblGoukeiValue.Text = String.Empty;
            //差額.
            lblSagakuValue.Text = String.Empty;
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
            //消費税差額.
            lblZeiSagakuValue.Text = String.Empty;
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */

            /*
             * ボタン類の使用可・不可設定.
             */
            //一括統合.
            btnBulkMerge.Enabled = false;
            //明細入力.
            btnDetailInput.Enabled = false;
            //明細削除.
            btnDetailDel.Enabled = false;
            //明細登録.
            btnDetailRegister.Enabled = false;
            //選択統合.
            btnMergeAsh.Enabled = false;
        }
        #endregion 受注登録内容検索前クリア処理.

        #region 受注登録内容検索後チェック処理.
        /// <summary>
        /// 受注登録内容検索後チェック処理 
        /// </summary>
        /// <returns></returns>
        protected override Boolean CheckAfterSearch()
        {
            //受注登録内容検索後チェック処理.
            if (!base.CheckAfterSearch())
            {
                return false;
            }

            return true;
        }
        #endregion 受注登録内容検索後チェック処理.

        #region 受注登録内容検索後初期表示処理.
        /// <summary>
        /// 受注登録内容検索後初期表示処理.
        /// </summary>
        protected override void InitializeAfterSearch()
        {
            //受注登録内容検索後初期表示処理.
            base.InitializeAfterSearch();

            //ボタン類の使用可・不可設定.
            EnableChangeForAfterSearch();
        }
        #endregion 受注登録内容検索後初期表示処理.

        #region 受注削除処理実行前チェック.
        /// <summary>
        /// 受注削除処理実行前チェック.
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeDelJyutyu()
        {
            //受注削除実行前のチェック処理.
            if (!base.CheckBeforeDelJyutyu())
            {
                return false;
            }

            return true;
        }
        #endregion 受注削除処理実行前チェック.

        #region 受注削除後の初期化処理.
        /// <summary>
        /// 受注削除後の初期化処理.
        /// </summary>
        protected override void InitAfterDelJyutyu()
        {
            //受注削除後の初期化処理.
            base.InitAfterDelJyutyu();

            //削除後、表示するデータが1件も存在しない場合.
            if (_spdJyutyuList_Sheet1.Rows.Count == 0)
            {
                /*
                 * ボタン類の使用可・不可設定.
                 */
                //一括統合.
                btnBulkMerge.Enabled = false;
                //明細入力.
                btnDetailInput.Enabled = false;
                //明細削除.
                btnDetailDel.Enabled = false;
                //明細登録.
                btnDetailRegister.Enabled = false;
                //選択統合.
                btnMergeAsh.Enabled = false;
                return;
            }
        }
        #endregion 受注削除後の初期化処理.

        #region 年月変更処理実行前チェック.
        /// <summary>
        /// 年月変更処理実行前チェック.
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeYmChange()
        {
            //年月変更ダイアログ表示前チェック.
            if (!base.CheckBeforeYmChange())
            {
                return false;
            }

            return true;
        }
        #endregion 年月変更処理実行前チェック.

        #region 新規作成ダイアログ表示前チェック.
        /// <summary>
        /// 新規作成ダイアログ表示前チェック.
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeRegJyutyu()
        {
            //新規作成ダイアログ表示前チェック.
            return base.CheckBeforeRegJyutyu();
        }
        #endregion 新規作成ダイアログ表示前チェック.

        #region MouseMoveイベント.
        /// <summary>
        /// MouseMoveイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseMoveCommon(object sender, MouseEventArgs e)
        {
            //MouseMoveイベント.
            base.MouseMoveCommon(sender, e);
        }
        #endregion MouseMoveイベント.

        #region MouseLeaveイベント.
        /// <summary>
        /// MouseLeaveイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseLeaveCommon(object sender, EventArgs e)
        {
            //MouseLeaveイベント.
            base.MouseLeaveCommon(sender, e);
        }
        #endregion MouseLeaveイベント.

        #region 受注登録内容(一覧)でフォーカスがあるビューによってコントロールの制御を行う.
        /// <summary>
        /// 受注登録内容(一覧)でフォーカスがあるビューによってコントロールの制御を行う.
        /// </summary>
        /// <param name="activeSheet">アクティブのシート</param>
        /// <param name="activeRow">アクティブ行Index</param>
        protected override void EnableChangeForSelectJyutyuListRow(SheetView activeSheet, int activeRow)
        {
            //受注登録内容(一覧)の選択範囲変更後の各コントロールの活性／非活性設定.
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
                btnBulkMerge.Enabled = false;

                //明細関係のボタン使用不可.
                btnDetailInput.Enabled = false;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = false;
                btnMergeAsh.Enabled = false;
            }
        }
        #endregion 受注登録内容(一覧)でフォーカスがあるビューによってコントロールの制御を行う.

        #region 受注統合API実行パラメータ編集.
        /// <summary>
        /// 受注統合API実行パラメータ編集.
        /// </summary>
        /// <param name="dtJyutyuData"></param>
        /// <param name="tousakiRownum"></param>
        /// <returns></returns>
        protected override DetailProcessController.MergeJyutyuDataParam CreateServiceParamForMergeJyutyuData(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable dtJyutyuData, int tousakiRownum)
        {
            //親のメソッドを実行して共通部分のパラメータを設定する.
            DetailProcessController.MergeJyutyuDataParam param = base.CreateServiceParamForMergeJyutyuData(dtJyutyuData, tousakiRownum);

            //期間の編集.
            drJyutyuData touSakiRow = dtJyutyuData.FindByrowNum(tousakiRownum);
            string kikanFrom = string.Empty;
            string kikanTo = string.Empty;

            //業務区分がテレビスポット、またはラジオ、スポットの場合.
            if (touSakiRow.hb1GyomKbn == KKHSystemConst.GyomKbn.TVSpot || (touSakiRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio && touSakiRow.hb1TmspKbn == KKHSystemConst.TimeSpotKbn.Spot))
            {
                if (touSakiRow.hb1Field4.Length >= 16)
                {
                    kikanFrom = touSakiRow.hb1Field4.Substring(0, 8);
                    kikanTo = touSakiRow.hb1Field4.Substring(8, 8);

                    foreach (drJyutyuData row in dtJyutyuData.Rows)
                    {
                        if (row.hb1Field4.Length >= 16)
                        {
                            string hikakuKikanFrom = row.hb1Field4.Substring(0, 8);
                            string hikakuKikanTo = row.hb1Field4.Substring(8, 8);
                            if (DateTime.Parse(kikanTo.Insert(6, "/").Insert(4, "/")).AddDays(1).CompareTo(DateTime.Parse(hikakuKikanFrom.Insert(6, "/").Insert(4, "/"))) == 0)
                            {
                                kikanTo = hikakuKikanFrom;
                            }
                            else if (DateTime.Parse(kikanFrom.Insert(6, "/").Insert(4, "/")).AddDays(-1).CompareTo(DateTime.Parse(hikakuKikanTo.Insert(6, "/").Insert(4, "/"))) == 0)
                            {
                                kikanFrom = hikakuKikanTo;
                            }
                        }
                    }
                }
            }
            if (kikanFrom.Length > 0 && kikanTo.Length > 0)
            {
                param.dsTougouSaki.THB1DOWN[0].hb1Field4 = kikanFrom + kikanTo;
            }

            return param;
        }
        #endregion 受注統合API実行パラメータ編集.

        #region 受注統合APIの実行.
        /// <summary>
        /// 受注統合APIの実行.
        /// </summary>
        /// <param name="dtJyutyuData">統合対象となる受注データ(JyutyuData)</param>
        /// <param name="tousakiRownum">統合先となる受注データ(JyutyuData)のRowNum</param>
        /// <returns></returns>
        private bool MergeData(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable dtJyutyuData, int tousakiRownum)
        {
            //初期設定.
            DetailProcessController.MergeJyutyuDataParam param = CreateServiceParamForMergeJyutyuData(dtJyutyuData, tousakiRownum);
            DetailAshProcessController.MergeDataParam pParam;
            pParam.esqId = param.esqId;
            pParam.dsTougouMoto = param.dsTougouMoto;
            pParam.dsTougouSaki = param.dsTougouSaki;
            pParam.maxUpdDate = param.maxUpdDate;
            pParam.baitaiCd = GetBaitaiCdByJyutyuData();            

            DetailAshProcessController processController = DetailAshProcessController.GetInstance();
            MergeDataServiceResult result = processController.MergeData(pParam);
            if (result.HasError)
            {
                if (MessageCode.HB_E0020.Equals(result.MessageCode))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0020, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                }
                else
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0006, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                }
                return false;
            }

            return true;
        }
        #endregion 受注統合APIの実行.

        #region 受注チェック.
        /// <summary>
        /// 受注チェック.
        /// </summary>
        /// <returns></returns>
        protected override bool UpdateCheckClick()
        {
            //受注チェック.
            if (!base.UpdateCheckClick())
            {
                return false;
            }

            // オペレーションログの出力.
            KKHLogUtilityAsh.WriteOperationLogToDB(_naviParameter, KKHSystemConst.ApplicationID.APLID_DTL_ASH, KKHLogUtilityAsh.KINO_ID_OPERATION_LOG_UpdCheck, KKHLogUtilityAsh.DESC_OPERATION_LOG_UpdCheck);

            return true;
        }
        #endregion 受注チェック.
        #endregion オーバーライド.

        #region イベント.
        #region 画面遷移するたびに発生します.
        /// <summary>
        /// 画面遷移するたびに発生します.
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void DetailAsh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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
        private void DetailAsh_Shown(object sender, EventArgs e)
        {
            //各コントロールの初期設定.
            InitializeControlAsh();

            //広告費明細スプレッドのデザイン初期化を行う.
            InitializeDesignForSpdKkhDetail();
        }
        #endregion フォームロードイベント.

        #region 明細入力ボタンクリック.
        /// <summary>
        /// 明細入力ボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailInput_Click(object sender, EventArgs e)
        {
            //対象の受注データ、明細データ取得.
            drJyutyuData dataRow = getSelectJyutyuData(-1);
            int rowDetailIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

            //明細入力画面表示.
            KKHNaviParameter naviParam = _naviParameter;
            naviParam.DataRow = dataRow;
            naviParam.DataTable2 = _dsDetail.JyutyuData;
            naviParam.StrValue1 = GetBaitaiCdByJyutyuData();
            naviParam.DataTable1 = _dsDetailAsh.KkhDetail;
            naviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1;
            object result = Navigator.ShowModalForm(this, "toDetailInputAsh", naviParam);
            if (result == null)
            {
                this.ActiveControl = null;
                return;
            }
            //広告費明細変更フラグを更新.
            base.kkhDetailUpdFlag = true; 
            KKHNaviParameter naviParamOut = (KKHNaviParameter)result;
            Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailDataTable dtKkhDetailNew = (Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailDataTable)naviParamOut.DataTable1;
            _dsDetailAsh.KkhDetail.Clear();
            _dsDetailAsh.KkhDetail.Merge(dtKkhDetailNew);

            //差額計算.
            CalculateSagaku(dataRow);
            //ボタン活性処理.
            if (_dsDetailAsh.KkhDetail.Rows.Count > 0)
            {
                btnDetailDel.Enabled = true;
            }
            else
            {
                btnDetailDel.Enabled = false;
            }
            this.ActiveControl = null;
        }
        #endregion 明細入力ボタンクリック.

        #region 明細登録ボタンクリックイベント.
        /// <summary>
        /// 明細登録ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailRegister_Click(object sender, EventArgs e)
        {
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga MOD Start */
            //decimal sagaku = 0M;
            //if (decimal.TryParse(lblSagakuValue.Text, out sagaku) == false || sagaku == 0M)
            //{
            //    if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_C0002, null, "明細登録", MessageBoxButtons.YesNo))
            //    {
            //        this.ActiveControl = null;
            //        return;
            //    }
            //}
            //else
            //{
            //    if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_W0089, null, "明細登録", MessageBoxButtons.YesNo))
            //    {
            //        this.ActiveControl = null;
            //        return;
            //    }
            //}
            //RegistDetailData();
            //ActiveControl = null;

            /*
             * 明細登録確認処理.
             */
            //登録確認メッセージで［はい］を選択した場合.
            if (RegistSagakuCheck())
            {
                //明細登録処理.
                RegistDetailData();
            }
            //登録確認メッセージで［いいえ］を選択した場合、何もしない.
            else
            {
                return;
            }
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga MOD End */
        }
        #endregion 明細登録ボタンクリックイベント.

        #region 一括統合ボタンクリックイベント.
        /// <summary>
        /// 一括統合ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBulkMerge_Click(object sender, EventArgs e)
        {
            //一括統合処理.
            BulkMergeClick();
            this.ActiveControl = null;
        }
        #endregion 一括統合ボタンクリックイベント.

        #region 明細削除ボタンクリック.
        /// <summary>
        /// 明細削除ボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailDel_Click(object sender, EventArgs e)
        {
            //確認メッセージ.
            if (MessageUtility.ShowMessageBox(MessageCode.HB_C0009, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.YesNo) != DialogResult.Yes) 
            {
                return;
            }                  

            int rowIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

            _spdKkhDetail_Sheet1.RemoveRows(rowIndex, 1);

            //行の削除をデータに反映.
            _dsDetailAsh.KkhDetail.AcceptChanges();

            //広告費明細変更フラグを更新.
            base.kkhDetailUpdFlag = true;

            /*
             * ボタン類の使用可・不可設定 
            */
            //広告費明細データが既にある場合は削除は可.
            if (_spdKkhDetail_Sheet1.Rows.Count > 0)
            {
                btnDetailDel.Enabled = true;
            }
            //広告費明細データがない場合は削除は不可.
            else
            {
                btnDetailDel.Enabled = false;
            }

            /*
             * 差額・計ラベル.
            */
            //受注登録内容の選択行情報の取得.
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);

            //差額計算.
            CalculateSagaku(dataRow);

            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(_spdKkhDetail_Sheet1.ActiveRowIndex, -1, 1, -1);
            }

            this.ActiveControl = null;
        }
        #endregion 明細削除ボタンクリック.

        #region 選択統合ボタンクリックイベント.
        /// <summary>
        /// 選択統合ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMergeAsh_Click(object sender, EventArgs e)
        {
            //選択統合処理.
            MergeClick();
            this.ActiveControl = null;
        }
        #endregion 選択統合ボタンクリックイベント.

        #region 一括統合処理.
        /// <summary>
        /// 一括統合処理.
        /// </summary>
        private void BulkMergeClick()
        {
            /*
             * 処理実行前チェック・対象データ取得.
             * 広告費明細の編集状況確認.
            */
            if (ConfirmEditStatus() == false)
            {
                this.ActiveControl = null;
                return;
            }

            dsDetail dsDetail = new dsDetail();
            //アクティブ行の取得.
            int activeRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            //指定した受注登録内容(一覧)の行に紐づく検索受注登録内容データを取得する.
            drJyutyuData activeRow = getSelectJyutyuData(activeRowIdx);
            {
                //フィルタで隠れているレコードが処理対象になっている場合はエラー表示.
                String jyutnoKey = _spdJyutyuList_Sheet1.Cells[activeRowIdx, COLIDX_JLIST_URIMEINO].Text.Substring(0, 10);

                for (int i = 0; i < _spdJyutyuList_Sheet1.Rows.Count; i++)
                {
                    String jyutno = _spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_URIMEINO].Text.Substring(0, 10);

                    if (!jyutnoKey.Equals(jyutno))
                    {
                        continue;
                    }

                    if (_spdJyutyuList_Sheet1.RowFilter.IsRowFilteredOut(i))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0146, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                        return;
                    }
                }
            }

            //統合対象行データの取得.
            string filterEx = dsDetail.THB1DOWN.hb1JyutNoColumn.ColumnName + "='" + activeRow.hb1JyutNo + "'";
            filterEx = filterEx + " AND " + dsDetail.THB1DOWN.hb1TJyutNoColumn.ColumnName + "=''";
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] targetRows = (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[])_dsDetail.JyutyuData.Select(filterEx);

            foreach (drJyutyuData targetRow in targetRows)
            {
                //選択されている受注登録内容の行数分の処理を繰り返す.
                if (targetRow.hb1TouFlg == "1")
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0015, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                    return;
                }

                drJyutyuData addRow = dsDetail.JyutyuData.NewJyutyuDataRow();
                addRow.ItemArray = (object[])targetRow.ItemArray;
                dsDetail.JyutyuData.AddJyutyuDataRow(addRow);
            }

            //統合処理実行.
            if (!MergeJyutyuData(dsDetail.JyutyuData, activeRow.rowNum))
            {
                this.ActiveControl = null;
                return;
            }

            /*
             * 再検索・表示 
            */
            //実行結果が正常な場合、受注統合処理後の再表示処理を行う.
            ReSearchJyutyuData();
            if (_spdJyutyuList_Sheet1.RowCount >= activeRowIdx + 1)
            {
                _spdJyutyuList_Sheet1.SetActiveCell(activeRowIdx, 0, true);
                _spdJyutyuList_Sheet1.AddSelection(activeRowIdx, -1, 1, -1);
                spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);
            }

            //選択行を明細に表示する.
            DisplayKkhDetail(_spdJyutyuList_Sheet1.ActiveRowIndex);
            MessageUtility.ShowMessageBox(MessageCode.HB_I0009, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
            this.ActiveControl = null;
        }
        #endregion 一括統合処理.

        #region 選択統合処理.
        /// <summary>
        /// 選択統合処理.
        /// </summary>
        private void MergeClick()
        {
            /*
             * 統合先選択ダイアログ表示前チェック・対象データ取得.
             * 広告費明細の編集状況確認 
            */
            if (ConfirmEditStatus() == false)
            {
                this.ActiveControl = null;
                return;
            }

            dsDetail dsDetail = new dsDetail();

            //選択行の取得.
            CellRange[] cellRanges = SortCellRangesByRowIdx(_spdJyutyuList_Sheet1.GetSelections());

            if (cellRanges.Length < 1 || (cellRanges.Length == 1 && cellRanges[0].RowCount < 2))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0084, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                this.ActiveControl = null;
                return;
            }
            foreach (CellRange cellRange in cellRanges)
            {
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    //選択されている受注登録内容の行数分の処理を繰り返す.
                    int rowIndex = cellRange.Row + i;

                    //フィルタリングで見えなくなっている場合はエラーを表示する.
                    if (_spdJyutyuList_Sheet1.RowFilter.IsRowFilteredOut(rowIndex))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0146, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                        return;
                    }

                    drJyutyuData dataRow = getSelectJyutyuData(rowIndex);
                    if (dataRow.hb1TouFlg == "1")
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0015, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                        return;
                    }

                    drJyutyuData addRow = dsDetail.JyutyuData.NewJyutyuDataRow();
                    addRow.ItemArray = (object[])dataRow.ItemArray;
                    dsDetail.JyutyuData.AddJyutyuDataRow(addRow);
                }
            }

            /*
             * 統合先選択画面の表示 
            */
            _naviParameter.DsDetail = dsDetail;
            _naviParameter.AplId = AplId;
            object obj = Navigator.ShowModalForm(this, "toJyutyuMerge", _naviParameter);

            if (obj == null)
            {
                this.ActiveControl = null;
                return;
            }

            //統合処理実行 
            KKHNaviParameter naviParameterOut = (KKHNaviParameter)obj;
            if (MergeData(dsDetail.JyutyuData, naviParameterOut.IntValue1) == false)
            {
                this.ActiveControl = null;
                return;
            }

            /*
             * 再検索・表示 
            */
            //実行結果が正常な場合、受注統合処理後の再表示処理を行う.
            ReSearchJyutyuData();

            if (_spdJyutyuList_Sheet1.RowCount >= cellRanges[0].Row + 1)
            {
                _spdJyutyuList_Sheet1.SetActiveCell(cellRanges[0].Row, 0, true);
                _spdJyutyuList_Sheet1.AddSelection(cellRanges[0].Row, -1, 1, -1);
                spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);
            }

            /*
             * 広告費明細 
            */
            //選択行を明細に表示する.
            DisplayKkhDetail(_spdJyutyuList_Sheet1.ActiveRowIndex);
            MessageUtility.ShowMessageBox(MessageCode.HB_I0009, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
            this.ActiveControl = null;
        }
        #endregion 選択統合処理.
        #endregion イベント.

        #region メソッド.
        #region 差額計算.
        /// <summary>
        /// 差額計算.
        /// </summary>
        private void CalculateSagaku(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            //初期設定.
            decimal delRyoukinGoukei = 0M;
            decimal delSagaku = 0M;
            String strRyoukin = String.Empty;
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
            decimal delZeiGoukei = 0M;
            decimal delZeiSagaku = 0M;
            String strZei = string.Empty;
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */

            //明細の件数分ループ処理.
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                //明細の料金を取得.
                strRyoukin = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIGAK].Text.Trim();

                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
                //明細の消費税を取得.
                strZei = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_ZEIGAKU].Text.Trim();
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */

                //明細の料金が入力されている場合、料金合計に加算.
                if (KKHUtility.IsNumeric(strRyoukin))
                {
                    delRyoukinGoukei = delRyoukinGoukei + decimal.Parse(strRyoukin);
                }

                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
                //明細の消費税が入力されている場合、消費税合計に加算.
                if (KKHUtility.IsNumeric(strZei))
                {
                    delZeiGoukei = delZeiGoukei + decimal.Parse(strZei);
                }
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
            }

            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
            //消費税.
            delZeiSagaku = dataRow.hb1SzeiGak - delZeiGoukei;
            lblZeiSagakuValue.Text = delZeiSagaku.ToString(KKHSystemConst.Format.GAKU_FORMAT);
            /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */

            //差額.
            delSagaku = dataRow.hb1SeiGak - delRyoukinGoukei;
            lblSagakuValue.Text = delSagaku.ToString(KKHSystemConst.Format.GAKU_FORMAT);

            //合計.
            lblGoukeiValue.Text = delRyoukinGoukei.ToString(KKHSystemConst.Format.GAKU_FORMAT);
        }
        #endregion 差額計算.

        #region 広告費明細のデータソース更新.
        /// <summary>
        /// 広告費明細のデータソース更新.
        /// </summary>
        /// <param name="dsDetailAsh"></param>
        private void UpdateDataSourceByDetailDataSetAsh(DetailDSAsh dsDetailAsh)
        {
            //広告費明細のデータソース更新.
            _dsDetailAsh.Clear();
            _dsDetailAsh.Merge(_dsDetailAsh);
            _dsDetailAsh.AcceptChanges();
        }
        #endregion 広告費明細のデータソース更新.

        #region 各コントロールの初期設定.
        /// <summary>
        /// 各コントロールの初期設定.
        /// </summary>
        private void InitializeControlAsh()
        {
            //検索条件部.
            lblKenMei.Visible = false;
            txtKenMei.Visible = false;
            lblKikan.Visible = false;
            txtYmdTo.Visible = false;

            //ボタン類.
            btnBulkMerge.Enabled = false;
            btnDetailInput.Enabled = false;
            btnDetailDel.Enabled = false;
            btnDetailRegister.Enabled = false;
            btnMergeAsh.Enabled = false;
        }
        #endregion 各コントロールの初期設定.

        #region 広告費明細スプレッドのデザイン初期化を行う.
        /// <summary>
        /// 広告費明細スプレッドのデザイン初期化を行う.
        /// </summary>
        private void InitializeDesignForSpdKkhDetail()
        {
            //列毎の設定.
            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                //セルの編集不可.
                col.Locked = true;

                //フィルタ機能を有効.
                col.AllowAutoFilter = true;

                //ソート機能を有効.
                col.AllowAutoSort = true;

                //請求書番号.
                if (col.Index == COLIDX_MLIST_SEINO)
                {
                    col.Label = COL_NAME_SEINO;
                    col.Width = 100;
                }
                //件名.
                else if (col.Index == COLIDX_MLIST_KENMEI)
                {
                    col.Label = COL_NAME_KENMEI;
                    col.Width = 200;
                }
                //局コード.
                else if (col.Index == COLIDX_MLIST_KYOKUCD)
                {
                    col.Label = COL_NAME_KYOKUCD;
                    col.Width = 150;
                }
                //品種コード.
                else if (col.Index == COLIDX_MLIST_HINSYUCD)
                {
                    col.Label = COL_NAME_HINSYUCD;
                    col.Width = 100;
                }
                //費目名称.
                else if (col.Index == COLIDX_MLIST_HIMOKUNM)
                {
                    col.Label = COL_NAME_HIMOKUNM;
                    col.Width = 80;
                }
                //見積金額.
                else if (col.Index == COLIDX_MLIST_HNMAEGAK)
                {
                    col.Label = COL_NAME_HNMAEGAK;
                    col.Width = 150;

                    //セルの書式設定.
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                //値引率.
                else if (col.Index == COLIDX_MLIST_HNNERT)
                {
                    col.Label = COL_NAME_HNNERT;
                    col.Width = 80;

                    //セルの書式設定.
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 1;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
                //値引額.
                else if (col.Index == COLIDX_MLIST_NEBIKIGAKU)
                {
                    col.Label = COL_NAME_NEBIKIGAKU;
                    col.Width = 150;

                    //セルの書式設定.
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
                //請求金額.
                else if (col.Index == COLIDX_MLIST_SEIGAK)
                {
                    col.Label = COL_NAME_SEIGAK;
                    col.Width = 150;

                    //セルの書式設定.
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                //消費税率.
                else if (col.Index == COLIDX_MLIST_ZEIRITSU)
                {
                    col.Label = COL_NAME_ZEIRITSU;
                    col.Width = 80;

                    //セルの書式設定.
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 1;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
                //消費税額.
                else if (col.Index == COLIDX_MLIST_ZEIGAKU)
                {
                    col.Label = COL_NAME_ZEIGAKU;
                    col.Width = 150;

                    //セルの書式設定.
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
                //期間.
                else if (col.Index == COLIDX_MLIST_KIKAN)
                {
                    col.Label = COL_NAME_KIKAN;
                    col.Width = 220;
                }
                /* 2015/03/11 アサヒ対応 Miyanoue ADD Start */
                //媒体コード.
                else if (col.Index == COLIDX_MLIST_BAITAICD)
                {
                    col.Label = COL_NAME_BAITAICD;
                    col.Width = 0;
                }
                //得意先媒体コード.
                else if (col.Index == COLIDX_MLIST_TOKUIBAITAICD)
                {
                    col.Label = COL_NAME_TOKUIBAITAICD;
                    col.Width = 100;
                }
                /* 2015/03/11 アサヒ対応 Miyanoue ADD End */
                //代理店コード.
                else if (col.Index == COLIDX_MLIST_DAIRITENCD)
                {
                    col.Label = COL_NAME_DAIRITENCD;
                    col.Width = 100;
                }
                //番組コード.
                else if (col.Index == COLIDX_MLIST_BANGUMICD)
                {
                    col.Label = COL_NAME_BANGUMICD;
                    col.Width = 100;
                }
                //売上明細NO.
                else if (col.Index == COLIDX_MLIST_URIMEINO)
                {
                    col.Label = COL_NAME_URIMEINO;
                    col.Width = 130;
                }
                //掲載日.
                else if (col.Index == COLIDX_MLIST_KEISAIDT)
                {
                    col.Label = COL_NAME_KEISAIDT;
                    col.Width = 150;
                }
                else
                {
                    col.Visible = false;
                }
            }

            //明細データが1件以上、存在する場合.
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                //選択範囲の設定.
                _spdKkhDetail_Sheet1.AddSelection(0, 0, 1, 1);
            }
        }
        #endregion 広告費明細スプレッドのデザイン初期化を行う.

        #region 受注登録内容検索後の各コントロールの活性/非活性設定.
        /// <summary>
        /// 受注登録内容検索後の各コントロールの活性/非活性設定 
        /// </summary>
        private void EnableChangeForAfterSearch()
        {
            //一括統合.
            btnBulkMerge.Enabled = true;

            //選択統合.
            btnMergeAsh.Enabled = true;
        }
        #endregion 受注登録内容検索後の各コントロールの活性/非活性設定.

        #region 明細登録処理.
        /// <summary>
        /// 明細登録処理.
        /// </summary>
        private void RegistDetailData()
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            //サービスパラメータ用変数.
            dsDetail dsDetail = new dsDetail();
            dsDetail TouKoudsDetail = new dsDetail();
            string esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            DateTime maxUpdDate = new DateTime();
            int activeRow = (int)base._spdJyutyuList_Sheet1.ActiveRowIndex;

            //受注登録データ編集.
            drJyutyuData dataRow = getSelectJyutyuData(-1);
            dtTHB1DOWN dtThb1Down = new dtTHB1DOWN();
            drTHB1DOWN thb1DownRow = dtThb1Down.NewTHB1DOWNRow();
            //更新プログラム.
            thb1DownRow.hb1UpdApl = AplId;
            //更新担当者.
            thb1DownRow.hb1UpdTnt = _naviParameter.strEsqId;
            //営業所(取)コード.
            thb1DownRow.hb1EgCd = dataRow.hb1EgCd;
            //得意先企業コード.
            thb1DownRow.hb1TksKgyCd = dataRow.hb1TksKgyCd;
            //得意先部門SEQNO.
            thb1DownRow.hb1TksBmnSeqNo = dataRow.hb1TksBmnSeqNo;
            //得意先担当SEQNO.
            thb1DownRow.hb1TksTntSeqNo = dataRow.hb1TksTntSeqNo;
            //年月.
            thb1DownRow.hb1Yymm = dataRow.hb1Yymm;
            //統合フラグ.
            thb1DownRow.hb1TouFlg = dataRow.hb1TouFlg;
            //受注No.
            thb1DownRow.hb1JyutNo = dataRow.hb1JyutNo;
            //受注明細No.
            thb1DownRow.hb1JyMeiNo = dataRow.hb1JyMeiNo;
            //売上明細No.
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
            //登録者、更新者の登録.
            thb1DownRow.hb1TrkTnt = string.Empty;
            thb1DownRow.hb1TrkTntNm = string.Empty;
            thb1DownRow.hb1KsnTnt = string.Empty;
            thb1DownRow.hb1KsnTntNm = string.Empty;

            //明細がない場合.
            if (thb1DownRow.hb1MeisaiFlg.Equals("0"))
            {
                //登録者、更新者が存在しない場合、何もしない.
                if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) && string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                }
                //登録者が空で、更新者が存在する場合、何もしない.
                else if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) && !string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                }else
                {
                    /*
                     * 更新者を登録.
                     */
                    //更新者.
                    thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                    //更新担当者名.
                    thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                }
            }
            //明細がある場合.
            else
            {
                //登録担当者が空かつ更新者が空でない場合.
                if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) && !string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                    /*
                     * 登録者、更新者両方入れる.
                     */
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
                    /*
                     * 登録者のみを入れる.
                     */
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
                    /*
                     * 更新者のみを入れる.
                     */
                    //更新者.
                    thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                    //更新担当者名.
                    thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                }
            }

            //データが統合されている場合、子の元となったデータに登録担当者、更新者を登録する.
            if (dataRow.hb1TouFlg.Equals("1"))
            {
                drTHB1DOWN tokoaddrow = TouKoudsDetail.THB1DOWN.NewTHB1DOWNRow();
                //更新プログラム.
                tokoaddrow.hb1UpdApl = base.AplId;
                //更新担当者.
                tokoaddrow.hb1UpdTnt = _naviParameter.strEsqId;
                //営業所（取）コード.
                tokoaddrow.hb1EgCd = _naviParameter.strEgcd;
                //得意先企業コード.
                tokoaddrow.hb1TksKgyCd = _naviParameter.strTksKgyCd;
                //得意先部門SEQNO.
                tokoaddrow.hb1TksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
                //得意先担当SEQNO.
                tokoaddrow.hb1TksTntSeqNo = _naviParameter.strTksTntSeqNo;
                //年月.
                tokoaddrow.hb1Yymm = dataRow.hb1Yymm;
                //統合フラグ.
                tokoaddrow.hb1TouFlg = dataRow.hb1TouFlg;
                //受注No.
                tokoaddrow.hb1JyutNo = dataRow.hb1JyutNo;
                //受注明細No.
                tokoaddrow.hb1JyMeiNo = dataRow.hb1JyMeiNo;
                //売上明細No.
                tokoaddrow.hb1UrMeiNo = dataRow.hb1UrMeiNo;
                //未請求フラグ.
                tokoaddrow.hb1MeisaiFlg = thb1DownRow.hb1MeisaiFlg;

                //登録担当者名が存在しない場合.
                if (!string.IsNullOrEmpty(thb1DownRow.hb1TrkTntNm))
                {
                    //登録担当者ID.
                    tokoaddrow.hb1TrkTnt = thb1DownRow.hb1TrkTnt;
                    //登録担当者名.
                    tokoaddrow.hb1TrkTntNm = thb1DownRow.hb1TrkTntNm;
                }
                //登録担当者名が存在する場合.
                else
                {
                    //登録担当者ID.
                    tokoaddrow.hb1TrkTnt = null;
                    //登録担当者名.
                    tokoaddrow.hb1TrkTntNm = null;
                }

                //明細更新者名が存在する場合.
                if (!string.IsNullOrEmpty(thb1DownRow.hb1KsnTntNm))
                {
                    //明細更新者ID.
                    tokoaddrow.hb1KsnTnt = thb1DownRow.hb1KsnTnt;
                    //明細更新者名.
                    tokoaddrow.hb1KsnTntNm = thb1DownRow.hb1KsnTntNm;
                }
                //明細更新者名が存在しない場合.
                else
                {
                    //明細更新者ID.
                    tokoaddrow.hb1KsnTnt = null;
                    //明細更新者名.
                    tokoaddrow.hb1KsnTntNm = null;
                }

                TouKoudsDetail.THB1DOWN.AddTHB1DOWNRow(tokoaddrow);
            }
            dtThb1Down.AddTHB1DOWNRow(thb1DownRow);
            dsDetail.THB1DOWN.Merge(dtThb1Down);

            //広告費明細登録データ編集.
            dtTHB2KMEI dtThb2Kmei = new dtTHB2KMEI();

            //明細件数分ループ処理.
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                //初期設定.
                object cellValue = null;
                object ksaibi = null;
                object kikan = null;

                //媒体コード.
                object baiCd = KKHUtility.ToString(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value);

                //広告費明細データ設定.
                drTHB2KMEI addRow = dtThb2Kmei.NewTHB2KMEIRow();
                //タイムスタンプ.
                addRow.hb2TimStmp = new DateTime();
                //更新プログラム.
                addRow.hb2UpdApl = AplId;
                //更新担当者.
                addRow.hb2UpdTnt = _naviParameter.strEsqId;
                //営業所コード.
                addRow.hb2EgCd = dataRow.hb1EgCd;
                //得意先企業コード.
                addRow.hb2TksKgyCd = dataRow.hb1TksKgyCd;
                //得意先部門SEQNO.
                addRow.hb2TksBmnSeqNo = dataRow.hb1TksBmnSeqNo;
                //得意先担当SEQNO.
                addRow.hb2TksTntSeqNo = dataRow.hb1TksTntSeqNo;
                //年月.
                addRow.hb2Yymm = dataRow.hb1Yymm;
                //受注No.
                addRow.hb2JyutNo = dataRow.hb1JyutNo;
                //受注明細No.
                addRow.hb2JyMeiNo = dataRow.hb1JyMeiNo;
                //売上明細No.
                addRow.hb2UrMeiNo = dataRow.hb1UrMeiNo;
                //費目コード.
                addRow.hb2HimkCd = dataRow.hb1HimkCd;
                /* 2013/05/09 HLC T.Sonobe MOD Start */
                //連番が999を超えた場合、処理を中止する.
                //if (i + 1 > 999)
                //{
                //    //ローディング表示終了 
                //    base.CloseLoadingDialog();
                //    //エラーメッセージを出力 
                //    MessageUtility.ShowMessageBox(MessageCode.HB_W0155, 
                //        null, "明細登録エラー", MessageBoxButtons.OK);
                //    return;
                //}
                //addRow.hb2Renbn = (i + 1).ToString("000");

                //連番が9999を超えた場合、処理を中止する.
                if (i + 1 > 9999)
                {
                    //ローディング表示終了.
                    base.CloseLoadingDialog();

                    //エラーメッセージを出力.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0155, null, KKHSystemConst.KoteiMongon.ERR_DETAIL_REGIST, MessageBoxButtons.OK);
                    return;
                }
                //連番.
                addRow.hb2Renbn = (i + 1).ToString("0000");
                /* 2013/05/09 HLC T.Sonobe MOD End */
                //年月日From.
                addRow.hb2DateFrom = KKHSystemConst.Kigou.SPACE;
                //年月日To.
                addRow.hb2DateTo = KKHSystemConst.Kigou.SPACE;
                //請求額.
                addRow.hb2SeiGak = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIGAK].Value;
                //見積率.
                addRow.hb2Hnnert = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HNNERT].Value;
                //見積額.
                addRow.hb2HnmaeGak = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HNMAEGAK].Value;
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga MOD Start */
                //値引額.
                //addRow.hb2NebiGak = 0M;
                addRow.hb2NebiGak = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NEBIKIGAKU].Value;
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga MOD End */
                addRow.hb2Date1 = KKHSystemConst.Kigou.SPACE;
                addRow.hb2Date2 = KKHSystemConst.Kigou.SPACE;
                addRow.hb2Date3 = KKHSystemConst.Kigou.SPACE;
                addRow.hb2Date4 = KKHSystemConst.Kigou.SPACE;
                addRow.hb2Date5 = KKHSystemConst.Kigou.SPACE;
                addRow.hb2Date6 = KKHSystemConst.Kigou.SPACE;
                //端数処理区分.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HASUSYORIKBN].Value;
                //端数処理区分が存在している、または[0]以外の場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "" && Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "0")
                {
                    addRow.hb2Kbn1 = cellValue.ToString();
                }
                //端数処理区分が存在しない、または[0]の場合.
                else
                {
                    addRow.hb2Kbn1 = KKHSystemConst.Kigou.SPACE;
                }
                //区分2.
                addRow.hb2Kbn2 = KKHSystemConst.Kigou.SPACE;
                //区分3.
                addRow.hb2Kbn3 = KKHSystemConst.Kigou.SPACE;
                //媒体コード.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value;
                //媒体コードが存在する場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Code1 = cellValue.ToString();
                }
                //媒体コードが存在しない場合.
                else
                {
                    addRow.hb2Code1 = KKHSystemConst.Kigou.SPACE;
                }
                //局コード.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KYOKUCD].Value;
                //局コードが存在する場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Code2 = cellValue.ToString().Split(' ')[0];
                }
                //局コードが存在しない場合.
                else
                {
                    addRow.hb2Code2 = KKHSystemConst.Kigou.SPACE;
                }
                //品種コード.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HINSYUCD].Value;
                //品種コードが存在する場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Code3 = cellValue.ToString().Split(' ')[0];
                }
                //品種コードが存在しない場合.
                else
                {
                    addRow.hb2Code3 = KKHSystemConst.Kigou.SPACE;
                }
                //代理店コード.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_DAIRITENCD].Value;
                //代理店コードが存在する場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Code4 = cellValue.ToString();
                }
                //代理店コードが存在しない場合.
                else
                {
                    addRow.hb2Code4 = KKHSystemConst.Kigou.SPACE;
                }
                //番組コード.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BANGUMICD].Value;
                //番組コードが存在する場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Code5 = cellValue.ToString();
                }
                //番組コードが存在しない場合.
                else
                {
                    addRow.hb2Code5 = KKHSystemConst.Kigou.SPACE;
                }
                //雑誌コード.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KYOKUCD].Value;
                //雑誌コードが存在する場合.
                if (KKHUtility.ToString(cellValue).Trim() != "")
                {
                    //初期設定.
                    addRow.hb2Code6 = KKHSystemConst.Kigou.SPACE;
                    
                    //4回ループ処理.
                    for (int j = 4; j > 0; j--)
                    {
                        //初期設定.
                        string zashiCd = cellValue.ToString();
                        
                        //雑誌コード文字列の長さがループ回数以上の場合.
                        if (zashiCd.Length >= j)
                        {
                            //雑誌コードを先頭からｊ文字取得.
                            zashiCd = zashiCd.Substring(zashiCd.Length - j, j).Trim();

                            //数値変換が可能の場合.
                            if (KKHUtility.IsNumeric(zashiCd))
                            {
                                addRow.hb2Code6 = zashiCd;
                                break;
                            }
                        }
                    }
                }
                //雑誌コードが存在しない場合.
                else
                {
                    addRow.hb2Code6 =  KKHSystemConst.Kigou.SPACE;
                }
                //スペース.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value;
                //スペースが新聞、または雑誌の場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.SHINBUN || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.ZASHI)
                {
                    //初期設定.
                    object cellValue2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SPACE].Value;

                    //スペースが存在する場合.
                    if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue2).Trim() != "")
                    {
                        addRow.hb2Name1 = cellValue2.ToString();
                    }
                    //スペースが存在しない場合.
                    else
                    {
                        addRow.hb2Name1 =  KKHSystemConst.Kigou.SPACE;
                    }
                }
                //スペースが新聞、雑誌以外の場合.
                else
                {
                    addRow.hb2Name1 =  KKHSystemConst.Kigou.SPACE;
                }
                //費目名.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HIMOKUNM].Value;
                //費目名が存在する場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name2 = cellValue.ToString();
                }
                //費目名が存在しない場合.
                else
                {
                    addRow.hb2Name2 =  KKHSystemConst.Kigou.SPACE;
                }
                //売上明細No.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_URIMEINO].Value;
                //売上明細Noが存在する場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name3 = cellValue.ToString();
                }
                //売上明細Noが存在しない場合.
                else
                {
                    addRow.hb2Name3 =  KKHSystemConst.Kigou.SPACE;
                }
                //請求書番号.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEINO].Value;
                //請求書番号が存在する場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name4 = cellValue.ToString();
                }
                //請求書番号が存在しない場合.
                else
                {
                    addRow.hb2Name4 =  KKHSystemConst.Kigou.SPACE;
                }
                /*
                 * 掲載日.
                 */
                //媒体コードが新聞、または雑誌の場合.
                if (baiCd.ToString() == KkhConstAsh.BaitaiCd.SHINBUN || baiCd.ToString() == KkhConstAsh.BaitaiCd.ZASHI)
                {
                    //初期設定.
                    ksaibi = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEISAIDT].Value;

                    //掲載・発売日が存在する場合.
                    if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(ksaibi) != "")
                    {
                        string _keisaiBi = ksaibi.ToString();
                        _keisaiBi = _keisaiBi.Replace(KKHSystemConst.Date.YEAR, "");
                        _keisaiBi = _keisaiBi.Replace(KKHSystemConst.Date.MONTH, "");
                        _keisaiBi = _keisaiBi.Replace(KKHSystemConst.Date.DAY, "");
                        addRow.hb2Name5 = _keisaiBi;
                    }
                    //掲載・発売日が存在しない場合.
                    else
                    {
                        addRow.hb2Name5 =  KKHSystemConst.Kigou.SPACE;
                    }
                }
                //放送時間.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value;
                //媒体コードがTVタイム、ラジオタイム、交通、メディアフィー、ブランド管理フィーテレビネットスポットの場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.TV_TIME
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.RADIO_TIME
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.KOUTSU
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.MEDIA_FEE
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.BRAND_FEE
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD Start */
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD End */
                {
                    //初期設定.
                    object cellValue2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HOSOUJIKAN].Value;

                    //放送時間が存在する場合.
                    if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue2).Trim() != "")
                    {
                        addRow.hb2Name6 = cellValue2.ToString();
                    }
                    //放送時間が存在しない場合.
                    else
                    {
                        addRow.hb2Name6 =  KKHSystemConst.Kigou.SPACE;
                    }
                }
                //媒体コードがTVタイム、ラジオタイム、交通、メディアフィー、ブランド管理フィーテレビネットスポット以外の場合.
                else
                {
                    addRow.hb2Name6 =  KKHSystemConst.Kigou.SPACE;
                }
                //名称7.
                addRow.hb2Name7 =  KKHSystemConst.Kigou.SPACE;
                //件名.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI].Value;
                //件名が存在する場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    /* 2013/01/17 JSE M.Naito MOD Start */
                    //addRow.hb2Name8 = cellValue.ToString();
                    addRow.hb2Name10 = cellValue.ToString();
                    /* 2013/01/17 JSE M.Naito MOD End */
                }
                //件名が存在しない場合.
                else
                {
                    /* 2013/01/17 JSE M.Naito MOD Start */
                    //addRow.hb2Name8 = " ";
                    addRow.hb2Name10 = " ";
                    /* 2013/01/17 JSE M.Naito MOD End */
                }
                //曜日.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value;
                //媒体コードがテレビタイム、ラジオタイム、テレビネットスポットの場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.TV_TIME
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.RADIO_TIME
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD Start */
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD End */
                {
                    //初期設定.
                    object cellValue2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_YOUBI].Value;

                    //曜日が存在する場合.
                    if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue2).Trim() != "")
                    {
                        addRow.hb2Name9 = cellValue2.ToString();
                    }
                    //曜日が存在しない場合.
                    else
                    {
                        addRow.hb2Name9 =  KKHSystemConst.Kigou.SPACE;
                    }
                }
                //媒体コードがテレビタイム、ラジオタイム、テレビネットスポット以外の場合.
                else
                {
                    addRow.hb2Name9 =  KKHSystemConst.Kigou.SPACE;
                }
                /* 2013/01/17 JSE M.Naito MOD Start */
                //addRow.hb2Name10 = " ";
                addRow.hb2Name8 =  KKHSystemConst.Kigou.SPACE;
                /* 2013/01/17 JSE M.Naito MOD End */

                //期間 
                //媒体コードが新聞、雑誌の場合.
                if (baiCd.ToString() != KkhConstAsh.BaitaiCd.SHINBUN && baiCd.ToString() != KkhConstAsh.BaitaiCd.ZASHI)
                {
                    //初期設定.
                    kikan = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KIKAN].Value;

                    //期間が存在する場合.
                    if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(kikan) != "")
                    {
                        addRow.hb2Name11 = kikan.ToString();

                        //掲載日.
                        string _kikan = kikan.ToString();
                        _kikan = _kikan.Replace(KKHSystemConst.Date.YEAR, "");
                        _kikan = _kikan.Replace(KKHSystemConst.Date.MONTH, "");
                        _kikan = _kikan.Replace(KKHSystemConst.Date.DAY, "");
                        _kikan = _kikan.Replace(KKHSystemConst.Kigou.HYPHEN, "");
                        addRow.hb2Name5 = _kikan;
                    }
                    //期間が存在しない場合.
                    else
                    {
                        addRow.hb2Name11 =  KKHSystemConst.Kigou.SPACE;
                        //[掲載日]も空白に設定.
                        addRow.hb2Name5 =  KKHSystemConst.Kigou.SPACE;
                    }
                }
                addRow.hb2Name12 = "";
                addRow.hb2Name13 = "";
                addRow.hb2Name14 = "";
                addRow.hb2Name15 = "";
                addRow.hb2Name16 = "";
                addRow.hb2Name17 = "";
                addRow.hb2Name18 = "";
                addRow.hb2Name19 = "";
                addRow.hb2Name20 = "";
                addRow.hb2Name21 = "";
                addRow.hb2Name22 = "";
                addRow.hb2Name23 = "";
                addRow.hb2Name24 = "";
                addRow.hb2Name25 = "";
                addRow.hb2Name26 = "";
                addRow.hb2Name27 = "";
                addRow.hb2Name28 = "";
                addRow.hb2Name29 = "";
                addRow.hb2Name30 = "";
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga MOD Start */
                //消費税額.
                //addRow.hb2Kngk1 = 0M;
                addRow.hb2Kngk1 = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_ZEIGAKU].Value;
                /* 2016/11/18 アサヒ消費税対応 HLC K.Soga MOD End */
                addRow.hb2Kngk2 = 0M;
                addRow.hb2Kngk3 = 0M;
                //消費税率.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_ZEIRITSU].Value;
                addRow.hb2Ritu1 = KKHUtility.DecParse(cellValue.ToString());
                //入力比率.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NYURYOKUHIRITU].Value;
                addRow.hb2Ritu2 = KKHUtility.DecParse(KKHUtility.ToString(cellValue));
                //秒数.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BYOUSU].Value;
                //秒数が存在する場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota1 = cellValue.ToString();
                }
                //秒数が存在しない場合.
                else
                {
                    addRow.hb2Sonota1 =  KKHSystemConst.Kigou.SPACE;
                }
                //本数.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HONSU].Value;
                //本数が存在する場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota2 = cellValue.ToString();
                }
                //本数が存在しない場合.
                else
                {
                    addRow.hb2Sonota2 =  KKHSystemConst.Kigou.SPACE;
                }
                //朝夕区分.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TYOUSEKIKBN].Text;
                //朝夕区分が存在する場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota3 = cellValue.ToString();
                }
                //朝夕区分が存在しない場合.
                else
                {
                    addRow.hb2Sonota3 =  KKHSystemConst.Kigou.SPACE;
                }
                addRow.hb2Sonota4 =  KKHSystemConst.Kigou.SPACE;
                //記雑区分.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KIZATSUKBN].Value;
                //記雑区分が存在する場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota5 = cellValue.ToString();                   
                }
                //記雑区分が存在しない場合.
                else
                {
                    addRow.hb2Sonota5 =  KKHSystemConst.Kigou.SPACE;
                }
                //掲載区分.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEISAIBAN].Value;
                //掲載区分が存在する場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota6 = cellValue.ToString();
                }
                //掲載区分が存在しない場合.
                else
                {
                    addRow.hb2Sonota6 = " ";
                }
                //局・ネット数.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value;
                //媒体コードがテレビタイム、ラジオタイム、メディアフィー、ブランドフィー、テレビネットスポットの場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.TV_TIME
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.RADIO_TIME
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.MEDIA_FEE
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.BRAND_FEE
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD Start */
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD End */
                {
                    //初期設定.
                    object cellValue2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KYOKUNETSU].Value;

                    //局ネットが存在する場合.
                    if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue2).Trim() != "")
                    {
                        addRow.hb2Sonota7 = cellValue2.ToString();
                    }
                    //局ネットが存在しない場合.
                    else
                    {
                        addRow.hb2Sonota7 =  KKHSystemConst.Kigou.SPACE;
                    }
                }
                //媒体コードがテレビタイム、ラジオタイム、メディアフィー、ブランドフィー、テレビネットスポット以外の場合.
                else
                {
                    addRow.hb2Sonota7 =  KKHSystemConst.Kigou.SPACE;
                }
                //キー局コード.
                //媒体コードがテレビタイム、ラジオタイム、テレビネットスポットの場合.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.TV_TIME
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.RADIO_TIME
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD Start */
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                    /* 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD End */
                {
                    //初期設定.
                    object cellValue2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEYKYOKUCD].Value;

                    //キー局コードが存在する場合.
                    if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue2).Trim() != "")
                    {
                        addRow.hb2Sonota8 = cellValue2.ToString();
                    }
                    //キー局コードが存在しない場合.
                    else
                    {
                        addRow.hb2Sonota8 =  KKHSystemConst.Kigou.SPACE;
                    }
                }
                //媒体コードがテレビタイム、ラジオタイム、テレビネットスポット以外の場合.
                else
                {
                    addRow.hb2Sonota8 =  KKHSystemConst.Kigou.SPACE;
                }
                //FD明細.
                addRow.hb2Sonota9 =  KKHSystemConst.Kigou.SPACE;
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_FDDETAILOUTPUT].Value;
                //FD明細が存在する場合.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota9 = cellValue.ToString();
                }
                //FD明細が存在しない場合.
                else
                {
                    addRow.hb2Sonota9 =  KKHSystemConst.Kigou.SPACE;
                }
                //分割フラグ.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value;
                addRow.hb2Sonota10 = CnvBaitaiCdToSortNo(cellValue.ToString());
                //明細が2件以上存在する場合.
                if (_spdKkhDetail_Sheet1.RowCount >= 2)
                {
                    addRow.hb2BunFlg = "1";
                }
                //明細が1件未満の場合.
                else
                {
                    addRow.hb2BunFlg =  KKHSystemConst.Kigou.SPACE;
                }
                addRow.hb2MeihnFlg =  KKHSystemConst.Kigou.SPACE;
                addRow.hb2NebhnFlg =  KKHSystemConst.Kigou.SPACE;

                dtThb2Kmei.AddTHB2KMEIRow(addRow);
            }
            dsDetail.THB2KMEI.Merge(dtThb2Kmei);

            /*
             * 更新日付最大値の判定.
             */
            //統合されている場合.
            if (dataRow.hb1TouFlg == "1")
            {
                //統合されている受注登録内容のデータから更新日付の最大値を取得する.
                Isid.KKH.Common.KKHUtility.KKHGetMaxUpdDateByTogo getMaxUpdDateByTogo = new KKHGetMaxUpdDateByTogo();
                maxUpdDate = getMaxUpdDateByTogo.GetMaxUpdDateByTogo(_spdJyutyuList_Sheet1, dataRow.hb1TimStmp, _dsDetail);
            }
            //統合されていない場合.
            else
            {
                //最大更新日時が存在しない場合.
                if (maxUpdDate == null || maxUpdDate.CompareTo(dataRow.hb1TimStmp) < 0)
                {
                    maxUpdDate = dataRow.hb1TimStmp;
                }
            }

            //明細件数分ループ処理.
            foreach (drDetailData detailDataAshRow in _dsDetailAsh.DetailDataAsh.Rows)
            {
                //最大更新日時が存在しない場合.
                if (maxUpdDate == null || maxUpdDate.CompareTo(detailDataAshRow.hb2TimStmp) < 0)
                {
                    maxUpdDate = detailDataAshRow.hb2TimStmp;
                }
            }

            //登録処理.
            DetailProcessController processController = DetailProcessController.GetInstance();
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
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0148, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                }
                else
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0003, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                }
                return;
            }

            //広告費明細変更フラグを更新.
            base.kkhDetailUpdFlag = false; 
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                //明細登録"済"を設定.
                _spdJyutyuList_Sheet1.Cells[_spdJyutyuList_Sheet1.ActiveRowIndex, COLIDX_JLIST_TOROKU].Value = "済";
            }
            else
            {
                //明細登録"済"を解除.
                _spdJyutyuList_Sheet1.Cells[_spdJyutyuList_Sheet1.ActiveRowIndex, COLIDX_JLIST_TOROKU].Value = "";
            }

            //保持している受注登録内容データを処理後のデータで更新する.
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow updRow in result.DsDetail.THB1DOWN.Rows)
            {
                _dsDetail.JyutyuData.UpdateRowDataByTGADOWNRow(updRow);
                _dsDetail.THB1DOWN.UpdateRowData(updRow);
            }
            _dsDetail.JyutyuData.AcceptChanges();
            _dsDetail.THB1DOWN.AcceptChanges();
            DisplayKkhDetail(_spdJyutyuList_Sheet1.ActiveRowIndex);

            //データ再検索.
            SearchJyutyuData(true);
            if (_spdJyutyuList_Sheet1.RowCount != 0)
            {
                //元の位置に戻す.
                _spdJyutyuList_Sheet1.SetActiveCell(activeRow, 0, true);
                _spdJyutyuList_Sheet1.AddSelection(activeRow, -1, 1, -1);
                spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);
                //親の処理を呼ぶ(親のLeaveCellイベントが発生しないので).
                base.DisplayKkhDetail(activeRow);
                //子の処理を呼ぶ(親↑が呼んでくれないので).
                DisplayKkhDetail(activeRow);
            }

            //ローディング表示終了.
            base.CloseLoadingDialog();
            MessageUtility.ShowMessageBox(MessageCode.HB_I0012, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
        }
        #endregion 明細登録処理.

        #region 媒体コードからソート番号を決定する.
        /// <summary>
        /// 媒体コードからソート番号を決定する.
        /// </summary>
        /// <param name="baitaiCd"></param>
        /// <returns></returns>
        private string CnvBaitaiCdToSortNo(string baitaiCd)
        {
            string sortNo = "";
            if (baitaiCd == KkhConstAsh.BaitaiCd.TV_TIME) { sortNo = "01"; }
            // 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD Start.
            // TV_TIMEの次に表示のため015とする.
            else if (baitaiCd == KkhConstAsh.BaitaiCd.TV_SPOT) { sortNo = "015"; }
            // 2015/06/08 アサヒ対応 HLC K.Fujisaki ADD End.
            else if (baitaiCd == KkhConstAsh.BaitaiCd.TV_SPOT) { sortNo = "02"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.RADIO_TIME) { sortNo = "03"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.RADIO_SPOT) { sortNo = "04"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.SHINBUN) { sortNo = "05"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.ZASHI) { sortNo = "06"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.KOUTSU) { sortNo = "07"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.SEISAKU) { sortNo = "08"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.NEW_MEDIA) { sortNo = "09"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.INTERNET) { sortNo = "10"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.BS) { sortNo = "11"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.CS) { sortNo = "12"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.OKUGAI) { sortNo = "13"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.EVENT) { sortNo = "14"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.TYOUSA) { sortNo = "15"; }
            /* 2013/02/22 hlc PR媒体追加対応 HLC T.Sonobe MOD Start */
            //else if (baitaiCd == KkhConstAsh.BaitaiCd.SONOTA) { sortNo = "16"; }
            //else if (baitaiCd == KkhConstAsh.BaitaiCd.MEDIA_FEE) { sortNo = "17"; }
            //else if (baitaiCd == KkhConstAsh.BaitaiCd.BRAND_FEE) { sortNo = "18"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.PR) { sortNo = "16"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.SONOTA) { sortNo = "17"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.MEDIA_FEE) { sortNo = "18"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.BRAND_FEE) { sortNo = "19"; }
            /* 2013/02/22 hlc PR媒体追加対応 HLC T.Sonobe MOD End */
            else { sortNo = "99"; }
            return sortNo;
        }
        #endregion 媒体コードからソート番号を決定する.

        #region [期間]を表示用のフォーマットに変換します.
        /// <summary>
        /// [期間]を表示用のフォーマットに変換します.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string FormatPeriod(string str)
        {
            string ret = string.Empty;
            if (str.Length >= 16)
            {
                ret = str.Substring(0, 4) + "年" + str.Substring(4, 2) + "月" + str.Substring(6, 2) + "日" + " - " + str.Substring(8, 4) + "年" + str.Substring(12, 2) + "月" + str.Substring(14, 2) + "日";
            }
            else if (str.Length == 8)
            {
                ret = str.Substring(0, 4) + "年" + str.Substring(4, 2) + "月" + str.Substring(6, 2) + "日";
            }
            else
            {
                return str;
            }

            return ret;
        }
        #endregion [期間]を表示用のフォーマットに変換します.

        #region 対象媒体コード決定処理.
        /// <summary>
        /// 対象媒体コード決定処理.
        /// </summary>
        /// <returns></returns>
        private string GetBaitaiCdByJyutyuData()
        {
            string targetBaitaiCd = string.Empty;

            //受注ダウンロードデータ、マスタデータから対象媒体コードを決定する.
            drJyutyuData dataRow = getSelectJyutyuData(-1);

            //仮媒体コードの取得.
            string kariBaitaiCd = string.Empty;
            if (dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Works)
            {
                kariBaitaiCd = string.Empty;
            }
            else if (dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.KWorks)
            {
                kariBaitaiCd = dataRow.hb1Field2;
            }
            else
            {
                kariBaitaiCd = dataRow.hb1Field1;
            }

            //媒体コード変換マスタのレコードを取得.
            MasterMaintenance.MasterDataVODataTable dtBaitaiCnvMaster = FindMasterData(KkhConstAsh.MasterKey.BAITAI_HENNKAN);

            //媒体コード変換マスタのレコード分処理.
            foreach (MasterMaintenance.MasterDataVORow row in dtBaitaiCnvMaster.Rows)
            {
                //媒体と国際区分の判定.
                if (dataRow.hb1GyomKbn == row.Column1 && dataRow.hb1KokKbn == row.Column2)
                {
                    //業務区分がラジオ、衛星メディアの場合.
                    if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio || dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.EiseiM)
                    {
                        if (dataRow.hb1TmspKbn == row.Column3 || row.Column2 == "1")
                        {
                            if (row.Column4 == "")
                            {
                                targetBaitaiCd = row.Column5;
                            }
                            if (kariBaitaiCd == row.Column4)
                            {
                                targetBaitaiCd = row.Column5;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (row.Column4 == "")
                        {
                            targetBaitaiCd = row.Column5;
                        }
                        if (kariBaitaiCd == row.Column4)
                        {
                            targetBaitaiCd = row.Column5;
                            break;
                        }
                    }
                }
            }

            //媒体が設定されなかった場合.
            if (targetBaitaiCd == "")
            {
                //その他.
                targetBaitaiCd = "190";
            }

            return targetBaitaiCd;
        }
        #endregion 対象媒体コード決定処理.

        #region マスタデータ管理.
        /*
         * 検索データ保持用Hashtable.
         * 再利用するデータ(マスタデータ等)を保持.
        */
        //マスタデータ.
        Hashtable htMasterData = new Hashtable();

        #region 汎用マスタの検索を行う(一度取得したデータは保持され、検索済みのマスタデータは保持したデータを返却する.).
        /// <summary>
        /// 汎用マスタの検索を行う.
        /// 一度取得したデータは保持され、検索済みのマスタデータは保持したデータを返却する.
        /// </summary>
        /// <param name="masterKey">取得するマスタのマスタキー</param>
        /// <returns></returns>
        private Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable FindMasterData(string masterKey)
        {
            return FindMasterData(masterKey, false);
        }
        #endregion 汎用マスタの検索を行う.

        #region 汎用マスタの検索を行う.
        /// <summary>
        /// 汎用マスタの検索を行う.
        /// </summary>
        /// <param name="masterKey">取得するマスタのマスタキー</param>
        /// <param name="reLoad">True:常にDB検索を行う、False:検索済みのマスタは保持しているデータを使用する</param>
        /// <returns></returns>
        private Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable FindMasterData(string masterKey, bool reLoad)
        {
            Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable rv;

            if (htMasterData[masterKey] == null || reLoad == true)
            {

                MasterMaintenanceProcessController proccessController = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = proccessController.FindMasterByCond(
                                                                        _naviParameter.strEsqId
                                                                        , _naviParameter.strEgcd
                                                                        , _naviParameter.strTksKgyCd
                                                                        , _naviParameter.strTksBmnSeqNo
                                                                        , _naviParameter.strTksTntSeqNo
                                                                        , masterKey
                                                                        , ""
                                                                    );
                rv = result.MasterDataSet.MasterDataVO;
                htMasterData[masterKey] = result.MasterDataSet.MasterDataVO;
            }
            else
            {
                rv = (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable)htMasterData[masterKey];
            }

            return rv;
        }
        #endregion 汎用マスタの検索を行う.
        #endregion マスタデータ管理.

        /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
        #region 明細登録確認処理.
        /// <summary>
        /// 明細登録確認処理.
        /// </summary>
        /// <returns></returns>
        private bool RegistSagakuCheck()
        {
            //初期設定.
            decimal delSagaku = 0M;
            decimal delZeiSagaku = 0M;
            Boolean flg = false;

            //画面で表示されている消費税差額が[0]以外の場合.
            if (!decimal.TryParse(lblZeiSagakuValue.Text, out delZeiSagaku) || delZeiSagaku != 0M)
            {
                //確認メッセージで[はい]を選択した場合.
                if (DialogResult.Yes == MessageUtility.ShowMessageBox(MessageCode.HB_W0166, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.YesNo))
                {
                    flg = true;
                }
                //確認メッセージで[いいえ]を選択した場合.
                else
                {
                    return flg;
                }
            }

            //画面で表示されている差額が[0]以外の場合.
            if (!decimal.TryParse(lblSagakuValue.Text, out delSagaku) || delSagaku != 0M)
            {
                //確認メッセージで[はい]を選択した場合.
                if (DialogResult.Yes == MessageUtility.ShowMessageBox(MessageCode.HB_W0089, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.YesNo))
                {
                    flg = true;
                }
                //確認メッセージで[いいえ]を選択した場合.
                else
                {
                    return flg = false;
                }
            }

            //画面で表示されている消費税差額、差額が[0]の場合.
            if (!decimal.TryParse(lblSagakuValue.Text, out delSagaku) || (delZeiSagaku == 0M && delSagaku == 0M))
            {
                //画面で表示されている差額が[0]の場合.
                if (DialogResult.Yes == MessageUtility.ShowMessageBox(MessageCode.HB_C0002, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.YesNo))
                {
                    flg = true;
                }
            }

            return flg;
        }
        #endregion 明細登録確認処理.
        /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */
        #endregion メソッド.
    }
}