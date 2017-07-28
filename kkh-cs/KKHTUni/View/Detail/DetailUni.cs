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
using Isid.KKH.Uni.Schema;
using Isid.KKH.Uni.Utility;

namespace Isid.KKH.Uni.View.Detail
{
    public partial class DetailUni : DetailForm
    {
        #region 定数

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "DtlUni";

        # region 明細(一覧)カラムインデックス 
        /// <summary>
        /// 請求原票行番号列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_SEIKYUGENPYO = 0;
        /// <summary>
        /// 種別列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_SHUBETSU = 1;
        /// <summary>
        /// 件名列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_KENMEI = 2;
        /// <summary>
        /// 費目名列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_HIMOKUMEI = 3;
        /// <summary>
        /// 番組名列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_BANGUMIMEI = 4;
        /// <summary>
        /// 放送月列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_HOSOTSUKI = 5;
        /// <summary>
        /// 媒体名列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_BAITAIMEI = 6;
        /// <summary>
        /// 制作内容列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_SEISAKUNAIYO = 7;
        /// <summary>
        /// 掲載日列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_KEISAIBI = 8;
        /// <summary>
        /// 放送回数列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_HOSOKAISU = 9;
        /// <summary>
        /// 単価列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_TANKA = 10;

        /// <summary>
        /// 掲載号列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_KEISAIGO = 11;
        /// <summary>
        /// スペース列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_SUPESU = 12;
        /// <summary>
        /// 請求金額列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_SEIKYUKINGAKU = 13;
        /// <summary>
        /// 消費税額列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_SHOHIZEIGAKU = 14;
        /// <summary>
        /// ソート番号列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_SOTOBANGO = 15;
        /// <summary>
        /// 部署列インデックス 
        /// </summary>
        public const int COLIDX_MLIST_BUSHO = 16;
        # endregion 明細(一覧)カラムインデックス 

        # region 種別コード
        /// <summary>
        ///  種別コード：テレビ番組 
        /// </summary>
        public const String C_CD_TVBAN = KkhConstUni.ShubetsuCd.C_TV_BANGUMI;
        /// <summary>
        ///  種別コード：テレビ特番
        /// </summary>
        public const String C_CD_TVTOK = KkhConstUni.ShubetsuCd.C_TV_TOKUBAN;
        /// <summary>
        ///  種別コード：テレビスポット 
        /// </summary>
        public const String C_CD_TVSPOT = KkhConstUni.ShubetsuCd.C_TV_SPOT;
        /// <summary>
        ///  種別コード：雑誌 
        /// </summary>
        public const String C_CD_ZASHI = KkhConstUni.ShubetsuCd.C_ZASHI;
        /// <summary>
        ///  種別コード：新聞 
        /// </summary>
        public const String C_CD_SHINBUN = KkhConstUni.ShubetsuCd.C_SHINBUN;
        /// <summary>
        ///  種別コード：その他 
        /// </summary>
        public const String C_CD_SONOTA = KkhConstUni.ShubetsuCd.C_SONOTA;
        /// <summary>
        ///  種別コード：制作 
        /// </summary>
        public const String C_CD_SEISAKU = KkhConstUni.ShubetsuCd.C_SEISAKU;
        # endregion 種別コード
        #region 種別名 

        /// <summary>
        ///  種別名：テレビ番組 
        /// </summary>
        public const string C_MEI_TVBAN = KkhConstUni.ShubetsuMei.C_TV_BANGUMI;
        /// <summary>
        ///  種別名：テレビ特番 
        /// </summary>
        public const string C_MEI_TVTOK = KkhConstUni.ShubetsuMei.C_TV_TOKUBAN;
        /// <summary>
        ///  種別名：テレビスポット 
        /// </summary>
        public const string C_MEI_TVSPOT = KkhConstUni.ShubetsuMei.C_TV_SPOT;
        /// <summary>
        ///  種別名：雑誌 
        /// </summary>
        public const string C_MEI_ZASHI = KkhConstUni.ShubetsuMei.C_ZASHI;
        /// <summary>
        ///  種別名：新聞 
        /// </summary>
        public const string C_MEI_SHINBUN = KkhConstUni.ShubetsuMei.C_SHINBUN;
        /// <summary>
        /// 種別名：その他 
        /// </summary>
        public const string C_MEI_SONOTA = KkhConstUni.ShubetsuMei.C_SONOTA;
        /// <summary>
        ///  種別名：制作 
        /// </summary>
        public const string C_MEI_SEISAKU = KkhConstUni.ShubetsuMei.C_SEISAKU;
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
        /// 月額番組料金マスター取得キー：0001 
        /// </summary>
        public const string C_MST_BANGUMIRYOKIN = "0001";

        /// <summary>
        /// 部署マスター取得キー：0002 
        /// </summary>
        public const string C_MST_BUSHO = "0002";

        #endregion 定数

        #region メンバ変数

        /// <summary>
        /// 
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();

        #endregion メンバ変数

        #region コンストラクタ
        public DetailUni()
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
                if (col.Index == COLIDX_JLIST_TOGO) { col.Visible = true; }                     //統合  
                if (col.Index == COLIDX_JLIST_DAIUKE) { col.Visible = true; }                   //代受
                if (col.Index == COLIDX_JLIST_SEIKYU) { col.Visible = false; }                  //請求
                if (col.Index == COLIDX_JLIST_URIMEINO) { col.Visible = true; }                 //売上明細NO 
                if (col.Index == COLIDX_JLIST_GPYNO) { col.Visible = false; }                   //請求原票NO 
                if (col.Index == COLIDX_JLIST_SEIYYMM) { col.Visible = true; }                  //請求年月 
                if (col.Index == COLIDX_JLIST_GYOMKBN) { col.Visible = true; }                  //業務区分 
                if (col.Index == COLIDX_JLIST_KENMEI) { col.Visible = true; }                   //件名 
                if (col.Index == COLIDX_JLIST_BAITAINM) { col.Visible = false; }                 //媒体名 
                if (col.Index == COLIDX_JLIST_HIMOKUNM) { col.Visible = true; }                 //費目名 
                if (col.Index == COLIDX_JLIST_KYOKUSHICD) { col.Visible = false; }              //局誌CD 
                if (col.Index == COLIDX_JLIST_SEIKINGAKU) { col.Visible = true; }               //請求金額 
                if (col.Index == COLIDX_JLIST_KIKAN) { col.Visible = false; }                   //期間 
                if (col.Index == COLIDX_JLIST_DANTANKA) { col.Visible = false; }                 //段単価 
                if (col.Index == COLIDX_JLIST_DANSU) { col.Visible = false; }                    //段数 
                if (col.Index == COLIDX_JLIST_TORIRYOKIN) { col.Visible = false; }               //取料金 
                if (col.Index == COLIDX_JLIST_NEBIKIRITSU) { col.Visible = true; }              //値引率 
                if (col.Index == COLIDX_JLIST_NEBIKIGAKU) { col.Visible = true; }               //値引額 
                if (col.Index == COLIDX_JLIST_ZEIRITSU) { col.Visible = true; }                 //消費税率 
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
                //if (dataRow.hb1TouFlg == "1")
                //{
                //    //統合フラグ="1"の行は背景色を変更 
                //    _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(255 , 255 , 208);
                //}
                if (dataRow.hb1YymmOld != "")
                {
                    //変更前請求年月が設定されている(年月変更が行われている)場合は請求年月を赤文字にする 
                    _spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_SEIYYMM].ForeColor = Color.Red;
                }

                //明細がある場合請求金額を比較し、受注の請求金額と差がある場合には背景色の変更を行う.
                if(_spdJyutyuList_Sheet1.Cells[i , COLIDX_JLIST_TOROKU].Text.Equals("済"))
                {
                    //受注の請求金額.
                    decimal _dJuChSeigak = dataRow.hb1SeiGak;
                    decimal _dMeiSeigak = dataRow.hb2SeiGak;
                    //decimal _dSagaku = _dMeiSeigak - _dJuChSeigak;
                    decimal _dSagaku = Math.Abs(_dMeiSeigak - _dJuChSeigak);

                    if (_dSagaku == 0)
                    {
                        _spdJyutyuList_Sheet1.Rows[i].BackColor = C_BACK_COLOR_WHITE;
                        //受変列が"消"の場合は、グレーアウトする.
                        if (_spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_JHENKOU].Text.Equals("消"))
                        {
                            // 業務会計側で受注削除されている場合は背景色を変更 
                            _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(165, 165, 165);
                        }
                    }
                    else if (_dSagaku < KkhConstUni.ALERTAMOUNT)
                    {
                        _spdJyutyuList_Sheet1.Rows[i].BackColor = C_BACK_COLOR_LYELLOW;
                    }
                    else
                    {
                        _spdJyutyuList_Sheet1.Rows[i].BackColor = C_BACK_COLOR_LPINK;
                    }
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
            _dsDetailUni.KkhDetail.Clear();

            //受注登録内容の選択行情報の取得 
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(rowIdx)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);


                string _shubetsuCd = string.Empty; //種別コード 

                //明細が未登録、または種別が未設定の場合、業務区より判断する 
                switch (dataRow.hb1GyomKbn)
                {
                    case C_GYOM_SHINBUN:
                        _shubetsuCd = C_CD_SHINBUN;
                        break;
                    case C_GYOM_ZASHI:
                        _shubetsuCd = C_CD_ZASHI;
                        break;
                    case C_GYOM_CREAT:
                        _shubetsuCd = C_CD_SEISAKU;
                        break;
                    case C_GYOM_TVT:
                        _shubetsuCd = C_CD_TVBAN;
                        break;
                    case C_GYOM_TVS:
                        _shubetsuCd = C_CD_TVSPOT;
                        break;
                    default:
                        _shubetsuCd = C_CD_SONOTA;
                        break;
                }
            
            //受注登録内容の件数分まわす.
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow row in _dsDetail.THB2KMEI.Rows)
            {
                DetailDSUni.KkhDetailRow addRow = _dsDetailUni.KkhDetail.NewKkhDetailRow();
                string _seigen = dataRow.hb1GpyNo.Trim(); //請求原票番号.
                if (!string.IsNullOrEmpty(_seigen))
                {
                    if (_seigen.Length == 10)
                    {
                        //string _hb1GpyNo = dataRow.hb1GpyNo.Trim();
                        _seigen = _seigen.Substring(0, 6) + C_HYPHEN + _seigen.Substring(6, 4);

                        //明細データの請求原票番号に値がある場合 
                        //string _sonota2 = row.hb2Sonota2.Trim();

                        if (!string.IsNullOrEmpty(row.hb2Sonota2.Trim()))
                        {
                            _seigen += C_HYPHEN + row.hb2Sonota2.Trim();
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(row.hb2Sonota2.Trim()))
                    {
                        _seigen = row.hb2Sonota2.Trim();
                    }
                }

                
                addRow.seikyuGenpyoBango = _seigen;             //請求原票番号.
                addRow.kenMei = row.hb2Name9;                   //件名.
                addRow.himokuMei = row.hb2Name1;                //費目名.
                _shubetsuCd = row.hb2Code1;                     //種別コード.
                addRow.shubetsu = GetShubetsuMei(_shubetsuCd);  //種別名.
                addRow.hosoTsuki = row.hb2Sonota5;              //放送月.
                addRow.baitaiMei = row.hb2Name2;                //媒体名.
                addRow.seisakuNaiyo = row.hb2Name4;             //制作内容.
                //addRow.keisaiBi = row.hb2Name3;               //掲載日.
                addRow.hosoKaisu = row.hb2Sonota4;              //放送回数.
                addRow.tanka = row.hb2Kngk1;                    //単価
                addRow.bangumiMei = row.hb2Name5;               //番組名.
                addRow.keisaiGo = row.hb2Name6;                 //掲載号.
                addRow.supesu = row.hb2Name7;                   //スペース.
                addRow.seikyuKinGaku = row.hb2SeiGak;           //請求金額.
                addRow.shohizeiGaku = row.hb2Kngk2;             //消費税額
                addRow.busho = row.hb2Name11;                   //部署

                string _sotoBango = row.hb2Sonota3;
                int result = 0;
                if (int.TryParse(_sotoBango , out result))
                {
                    addRow.sotoBango = result.ToString();
                }

                //放送月 
                if (_shubetsuCd == C_CD_TVBAN || _shubetsuCd == C_CD_TVTOK)
                {
                    //放送月.
                    if (!string.IsNullOrEmpty(row.hb2Sonota5))
                    {
                        addRow.hosoTsuki = row.hb2Sonota5.Insert(4 , C_SLASH);
                    }
                }

                # region 掲載日
                switch (_shubetsuCd)
                {
                    //TV番組 
                    case C_CD_TVBAN:
                    //TV特番 
                    case C_CD_TVTOK:
                        addRow.keisaiBi = KkhUniStrConv.GetHosoBi(row.hb2Name3);   //放送日.
                        break;
                    //TVSPOT 
                    case C_CD_TVSPOT:
                    //その他 
                    case C_CD_SONOTA:
                        if (row.hb2Name3.Trim().Length == 16)       //放送期間.
                        {
                            addRow.keisaiBi = row.hb2Name3.Insert(14 , C_SLASH).Insert(12 , C_SLASH).Insert(8 , C_HYPHEN).Insert(6 , C_SLASH).Insert(4 , C_SLASH);
                        }
                        else
                        {
                            addRow.keisaiBi = row.hb2Name3;
                        }
                        break;
                    //雑誌 
                    case C_CD_ZASHI:
                    //新聞 
                    case C_CD_SHINBUN:
                        if (row.hb2Name3.Trim().Length == 8)        //発売日.
                        {
                            addRow.keisaiBi = row.hb2Name3.Insert(6 , C_SLASH).Insert(4 , C_SLASH);
                        }
                        else
                        {
                            addRow.keisaiBi = row.hb2Name3;
                        }
                        break;
                    //制作 
                    case C_CD_SEISAKU:
                        addRow.keisaiBi = row.hb2Name3;
                    //納品日.
                        break;
                }
                # endregion 掲載日

                _dsDetailUni.KkhDetail.AddKkhDetailRow(addRow);
            }
            _dsDetailUni.KkhDetail.AcceptChanges();

            //***************************************
            //広告費明細の表示・非表示設定 
            //***************************************
            VisibleMeisaiColumns(_shubetsuCd);

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
            //InitializeButton();
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
            //InitializeButton();

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
            KKHLogUtilityUni.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityUni.KINO_ID_OPERATION_LOG_UpdCheck, KKHLogUtilityUni.DESC_OPERATION_LOG_UpdCheck);

            return true;
        }

        #endregion オーバーライド 

        # region イベント 
        /// <summary>
        /// 画面遷移するたびに発生します。  
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void DetailUni_ProcessAffterNavigating(object sender , Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
                //_dataRow = _naviParam.DataRow;
                //_rowDetailIdx = _naviParam.RowDetailIndex;
                //_spdKkhDetail_Sheet1 = _naviParam.SpdKkhDetail_Sheet1;
                //_mHosoBi = _naviParam.strDate2;
            }
        }

        /// <summary>
        /// フォームロードイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailUni_Load(object sender , EventArgs e)
        {
            InitializeDataSourceUni();
            InitializeControlUni();
            InitializeDesignForSpdKkhDetail();
        }

        /// <summary>
        /// FormShownイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailUni_Shown(object sender , EventArgs e)
        {
            //InitializeDesignForSpdKkhDetail();
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
            DetailInputUniNaviParameter naviParam = new DetailInputUniNaviParameter();
            naviParam.DataRowUni = dataRow;
            naviParam.RowDetailIndexUni = rowDetailIndex;
            naviParam.SpdKkhDetailUni_Sheet1 = _spdKkhDetail_Sheet1;
            naviParam.EsqId = _naviParam.strEsqId;
            naviParam.Egcd = _naviParam.strEgcd;
            naviParam.TksKgyCd = _naviParam.strTksKgyCd;
            naviParam.TksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            naviParam.TksTntSeqNo = _naviParam.strTksTntSeqNo;
            //naviParam.DateUni = _mHosoBi;   //放送日.

            //明細入力画面に遷移.
            object result = Navigator.ShowModalForm(this, "toDetailInputUni", naviParam);

            if (result == null)
            {
                this.ActiveControl = null;
                return;
            }
            base.kkhDetailUpdFlag = true; //広告費明細変更フラグを更新 

            //明細スプレッドを取得.
            _spdKkhDetail_Sheet1 = naviParam.SpdKkhDetailUni_Sheet1;
            //種別名を取得.
            string _shubetsuMei = _spdKkhDetail_Sheet1.Cells[rowDetailIndex , DetailUni.COLIDX_MLIST_SHUBETSU].Value.ToString();
            //種別コードを取得.
            string _shubetsuCd = GetShubetsuCd(_shubetsuMei);
            
            //明細表示項目列.
            VisibleMeisaiColumns(_shubetsuCd);
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
            for (int i = 0 ; i < _spdKkhDetail_Sheet1.RowCount ; i++)
            {
                string ryoukinStr = _spdKkhDetail_Sheet1.Cells[i , COLIDX_MLIST_SEIKYUKINGAKU].Text.Trim();
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
        /// 広告費明細のデータソース更新 
        /// </summary>
        /// <param name="dsDetailToh"></param>
        private void UpdateDataSourceByDetailDataSetUni(DetailDSUni dsDetailUni)
        {
            _dsDetailUni.Clear();
            _dsDetailUni.Merge(_dsDetailUni);
            _dsDetailUni.AcceptChanges();
        }

        /// <summary>
        /// データソースのバインド 
        /// </summary>
        private void InitializeDataSourceUni()
        {
            _bsKkhDetail.DataSource = _dsDetailUni;
            _bsKkhDetail.DataMember = _dsDetailUni.KkhDetail.TableName;
        }

        /// <summary>
        /// 各コントロールの初期設定 
        /// </summary>
        private void InitializeControlUni()
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
            InitializeButton();
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
                if (col.Index == COLIDX_MLIST_SEIKYUGENPYO)
                {
                    col.Label = "請求原票番号";
                }
                else if (col.Index == COLIDX_MLIST_SHUBETSU)
                {
                    col.Label = "種別";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 80;
                }
                else if (col.Index == COLIDX_MLIST_KENMEI)
                {
                    col.Label = "件名";
                }
                else if (col.Index == COLIDX_MLIST_HIMOKUMEI)
                {
                    col.Label = "費目名";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_HOSOTSUKI)
                {
                    col.Label = "放送月";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_BAITAIMEI)
                {
                    col.Label = "媒体名";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_SEISAKUNAIYO)
                {
                    col.Label = "制作内容";
                }
                else if (col.Index == COLIDX_MLIST_KEISAIBI)
                {
                    col.Label = "掲載日";
                }

                else if (col.Index == COLIDX_MLIST_HOSOKAISU)
                {
                    col.Label = "放送回数";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_TANKA)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.ShowSeparator = true;

                    col.Label = "単価";
                    col.CellType = type;
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                }
                else if (col.Index == COLIDX_MLIST_BANGUMIMEI)
                {
                    col.Label = "番組名";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_KEISAIGO)
                {
                    col.Label = "掲載号";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_SUPESU)
                {
                    col.Label = "スペース";
                }
                else if (col.Index == COLIDX_MLIST_SEIKYUKINGAKU)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.ShowSeparator = true;

                    col.Label = "請求金額";
                    col.CellType = type;
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                }
                else if (col.Index == COLIDX_MLIST_SHOHIZEIGAKU)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.ShowSeparator = true;

                    col.Label = "消費税額";
                    col.CellType = type;
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                }
                else if (col.Index == COLIDX_MLIST_SOTOBANGO)
                {
                    col.Label = "ソート番号";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_BUSHO)
                {
                    col.Label = "部署";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
            }
        }

        /// <summary>
        /// ボタンの初期化 
        /// </summary>
        private void InitializeButton()
        {
            //***************************************
            //ボタン類の使用可・不可設定 
            //***************************************
            this.btnDelJyutyu.Enabled = true;
            this.btnRegJyutyu.Enabled = true;       //受注新規.
            this.btnMeiNyuryoku.Enabled = false;    //明細入力.
            this.btnMeiToroku.Enabled = false;      //明細登録.
            this.btnMeiSakujo.Enabled = false;      //明細削除.

            this.btnMerge.Visible = true;           //受注統合.
            this.btnMergeCancel.Visible = true;    　//統合取消.
            //this.btnUpdateCheck.Visible = false;    //変更削除チェック 
        }

        /// <summary>
        /// 種別コードより種別コード名称をセットする 
        /// </summary>
        /// <param name="shubetsu">種別コード</param>
        /// <returns>種別コード名称</returns>
        private string GetShubetsuMei(string shubetsu)
        {
            switch (shubetsu)
            {
                case C_CD_TVBAN:
                    shubetsu = C_MEI_TVBAN;
                    break;
                case C_CD_TVTOK:
                    shubetsu = C_MEI_TVTOK;
                    break;
                case C_CD_TVSPOT:
                    shubetsu = C_MEI_TVSPOT;
                    break;
                case C_CD_ZASHI:
                    shubetsu = C_MEI_ZASHI;
                    break;
                case C_CD_SHINBUN:
                    shubetsu = C_MEI_SHINBUN;
                    break;
                case C_CD_SONOTA:
                    shubetsu = C_MEI_SONOTA;
                    break;
                case C_CD_SEISAKU:
                    shubetsu = C_MEI_SEISAKU;
                    break;
                default:
                    shubetsu = "";
                    break;
            }
            return shubetsu;
        }

        /// <summary>
        /// 種別ごとに表示対象外列の非表示処理を行う 
        /// </summary>
        protected void VisibleMeisaiColumns(string shubetsuCd)
        {

             foreach (Column col in _spdKkhDetail_Sheet1.Columns)
             {
                 switch(col.Index)
                 {
                     case COLIDX_MLIST_SEIKYUGENPYO:
                     case COLIDX_MLIST_SHUBETSU:
                     case COLIDX_MLIST_KENMEI:
                     case COLIDX_MLIST_HIMOKUMEI:
                     case COLIDX_MLIST_SEIKYUKINGAKU:
                     case COLIDX_MLIST_SHOHIZEIGAKU:
                     case COLIDX_MLIST_BUSHO:
                     case COLIDX_MLIST_SOTOBANGO:
                         col.Visible = true;
                         break;
                     default:
                         col.Visible = false;
                         break;
                 }
             
             }


            # region 種別コードで列の表示を制御
            //種別コードで列の表示を制御する 
            switch (shubetsuCd)
            {
                //TV番組.
                # region TV番組 
                case C_CD_TVBAN:
                    foreach (Column col in _spdKkhDetail_Sheet1.Columns)
                    {
                        if (col.Index == COLIDX_MLIST_HOSOTSUKI)                                       //放送月 
                        { 
                            col.Visible = true;
                            col.Width = 80;
                            col.Label = "放送月";
                        }
                        else if (col.Index == COLIDX_MLIST_KEISAIBI)                                     //掲載日 
                        {
                            col.Visible = true;
                            col.Width = 160;
                            col.Label = "放送日";
                            col.HorizontalAlignment = CellHorizontalAlignment.Left;
                        }
                        else if (col.Index == COLIDX_MLIST_HOSOKAISU)                                    //放送回数 
                        { 
                            col.Visible = true;
                            col.Width = 70;
                            col.Label = "放送回数";
                            col.HorizontalAlignment = CellHorizontalAlignment.Center;
                        }
                        else if (col.Index == COLIDX_MLIST_TANKA)
                        {
                            col.Visible = true;
                            col.Width = 100;
                            NumberCellType cellType = (NumberCellType)col.CellType;
                            cellType.DecimalPlaces = 0;
                            cellType.ShowSeparator = true;
                        }                                                   //単価 
                        else if (col.Index == COLIDX_MLIST_BANGUMIMEI) 
                        { 
                            col.Visible = true; 
                            col.Width = 150;
                        }            //番組名
                    }

                    break;
                #endregion TV番組 

                # region TV特番 
                //TV特番.
                case C_CD_TVTOK:
                    foreach (Column col in _spdKkhDetail_Sheet1.Columns)
                    {
                        if (col.Index == COLIDX_MLIST_HOSOTSUKI) 
                        { 
                            col.Visible = true; 
                            col.Width = 80;
                        }             //放送月 
                        if (col.Index == COLIDX_MLIST_KEISAIBI)                                         //掲載日 
                        {
                            col.Visible = true;
                            col.Width = 160;
                            col.Label = "放送日";
                            col.HorizontalAlignment = CellHorizontalAlignment.Left;
                        }
                        if (col.Index == COLIDX_MLIST_HOSOKAISU) 
                        { 
                            col.Visible = true; 
                            col.Width = 80;
                        }             //放送回数 
                        if (col.Index == COLIDX_MLIST_TANKA) 
                        {
                            col.Visible = true; 
                            col.Width = 100;
                            NumberCellType cellType = (NumberCellType)col.CellType;
                            cellType.DecimalPlaces = 0;
                            cellType.ShowSeparator = true;
                        }                                                                           //単価 
                        if (col.Index == COLIDX_MLIST_BANGUMIMEI) 
                        { 
                            col.Visible = true; 
                            col.Width = 150;
                        }            //番組名 
                    }
                    break;

                # endregion TV特番

                # region TVSPOT
                //TVSPOT.
                case C_CD_TVSPOT:
                    foreach (Column col in _spdKkhDetail_Sheet1.Columns)
                    {
                        if (col.Index == COLIDX_MLIST_BAITAIMEI)                                      //媒体名 
                        { 
                            col.Visible = true;
                            col.Width = 150;
                            col.Label = "放送局名";
                        }            
                        else if (col.Index == COLIDX_MLIST_HOSOKAISU)                               //放送回数 
                        {
                            col.Visible = true;
                            col.Width = 80;
                            col.Label = "局数";
                            col.HorizontalAlignment = CellHorizontalAlignment.Center;
                        }
                        else if (col.Index == COLIDX_MLIST_KEISAIBI)                                     //掲載日 
                        {
                            col.Visible = true;
                            col.Width = 150;
                            col.Label = "放送期間";
                            col.HorizontalAlignment = CellHorizontalAlignment.Left;
                        }
                    }

                    //列を入れ替える 
                    _spdKkhDetail_Sheet1.MoveColumn(COLIDX_MLIST_HOSOKAISU, COLIDX_MLIST_KEISAIBI, true);

                    //[局数]の列幅を変更 
                    _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KEISAIBI].Width = 80;

                    break;
                # endregion TVSPOT 

                # region 雑誌 
                //雑誌.
                case C_CD_ZASHI:
                    foreach (Column col in _spdKkhDetail_Sheet1.Columns)
                    {
                        if (col.Index == COLIDX_MLIST_BAITAIMEI)                                        //媒体名 
                        { 
                            col.Visible = true;
                            col.Width = 150;
                            col.Label = "媒体名";
                        }
                        else if (col.Index == COLIDX_MLIST_KEISAIBI)                                     //掲載日 
                        {
                            col.Visible = true;
                            col.Width = 80;
                            col.Label = "発売日";
                            col.HorizontalAlignment = CellHorizontalAlignment.Center;
                        }
                        else if (col.Index == COLIDX_MLIST_KEISAIGO) 
                        { 
                            col.Visible = true;
                            col.Width = 80;
                        }             //掲載号 
                        else if (col.Index == COLIDX_MLIST_SUPESU) 
                        { 
                            col.Visible = true; 
                            col.Width = 120; 
                        }                //スペース 
                    }
                    break;

                # endregion 雑誌 

                #region 新聞 

                //新聞.
                case C_CD_SHINBUN:
                    foreach (Column col in _spdKkhDetail_Sheet1.Columns)
                    {
                        if (col.Index == COLIDX_MLIST_BAITAIMEI)                                        //媒体名
                        {
                            col.Visible = true;
                            col.Width = 150;
                            col.Label = "媒体名";
                        }
                        if (col.Index == COLIDX_MLIST_KEISAIBI)                                     //掲載日
                        {
                            col.Visible = true;
                            col.Width = 80;
                            col.Label = "掲載日";
                            col.HorizontalAlignment = CellHorizontalAlignment.Center;                           
                        }
                        if (col.Index == COLIDX_MLIST_SUPESU) 
                        { 
                            col.Visible = true;
                            col.Width = 120;
                        }                //スペース
                    }
                    break;

                # endregion 新聞 

                # region 制作 
                //制作.
                case C_CD_SEISAKU:
                    foreach (Column col in _spdKkhDetail_Sheet1.Columns)
                    {
                        if (col.Index == COLIDX_MLIST_SEISAKUNAIYO) 
                        {
                            col.Visible = true;
                            col.Width = 160;
                        }         //制作内容 
                        else if (col.Index == COLIDX_MLIST_KEISAIBI)                                     //掲載日 
                        {
                            col.Visible = true;
                            col.Label = "納品日";
                            col.Width = 80;
                            col.HorizontalAlignment = CellHorizontalAlignment.Center;
                        }
                        else if (col.Index == COLIDX_MLIST_HOSOKAISU)                                     //放送回数
                        { 
                            col.Visible = true;
                            col.Label = "回数数量";
                            col.Width = 80;
                            col.HorizontalAlignment = CellHorizontalAlignment.Center;
                        }
                        else if (col.Index == COLIDX_MLIST_TANKA)
                        {
                            col.Visible = true;
                            col.Width = 100;
                            NumberCellType cellType = (NumberCellType)col.CellType;
                            cellType.DecimalPlaces = 0;
                            cellType.ShowSeparator = true; 
                        }                                                                           //単価
                    }
                    break;

                # endregion 制作 

                # region その他 
                //その他.
                case C_CD_SONOTA:
                    foreach (Column col in _spdKkhDetail_Sheet1.Columns)
                    {
                        if (col.Index == COLIDX_MLIST_BAITAIMEI)                                        //媒体名 
                        {
                            col.Visible = true;
                            col.Width = 150;
                            col.Label = "媒体名";
                        }  
                        else if (col.Index == COLIDX_MLIST_KEISAIBI)                                     //掲載日
                        {
                            col.Visible = true;
                            col.Width = 180;
                            col.Label = "期間";
                            col.HorizontalAlignment = CellHorizontalAlignment.Left;
                        }
                   }
                    break;
                # endregion その他 
            }

            # endregion 種別コードで列の表示を制御


            //共通 幅を変更 
            //請求原票番号  
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_SEIKYUGENPYO].Width = 100;
            //種別 
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_SHUBETSU].Width = 80;
            //件名  
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KENMEI].Width = 180;
            //費目  
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_HIMOKUMEI].Width = 80;
            //請求金額 
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_SEIKYUKINGAKU].Width = 100;
             NumberCellType seikyuCellType = (NumberCellType)_spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_SEIKYUKINGAKU].CellType;
             seikyuCellType.DecimalPlaces = 0;
             seikyuCellType.ShowSeparator = true;
           
            //消費税額 
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_SHOHIZEIGAKU].Width = 100;
            NumberCellType shohizeiCellType = (NumberCellType)_spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_SHOHIZEIGAKU].CellType;
            shohizeiCellType.DecimalPlaces = 0;
            shohizeiCellType.ShowSeparator = true;

            //ソート番号  
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_SOTOBANGO].Width = 80;
            //部署 
            _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_BUSHO].Width = 140;
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
            //DateTime maxUpdDate = new DateTime(2100 , 1 , 1);//TODO 

            //*********************************************
            //THB1DOWNの登録データ編集 
            //*********************************************
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(_spdJyutyuList_Sheet1.ActiveRowIndex)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);

            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();

            //thb1DownRow.hb1TimStmp = new DateTime(); 
            thb1DownRow.hb1UpdApl = "DtlUni";//TODO 
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


            thb1DownRow.hb1TouFlg = "0";
            dtThb1Down.AddTHB1DOWNRow(thb1DownRow);

            dsDetail.THB1DOWN.Merge(dtThb1Down);

            //*********************************************
            //THB2KMEIの登録データ編集 
            //*********************************************
            int jyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;
            Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable dtThb2Kmei = new Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable();
            for (int i = 0 ; i < _spdKkhDetail_Sheet1.RowCount ; i++)
            {
                //種別名より種別コードを取得.
                string _shubetsuMei = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHUBETSU].Value.ToString();

                //object cellValue = null;

                Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow addRow = dtThb2Kmei.NewTHB2KMEIRow();

                addRow.hb2TimStmp = new DateTime();
                addRow.hb2UpdApl = "DtlUni";//TODO
                addRow.hb2UpdTnt = _naviParam.strEsqId;
                addRow.hb2EgCd = _naviParam.strEgcd;
                addRow.hb2TksKgyCd = _naviParam.strTksKgyCd;
                addRow.hb2TksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                addRow.hb2TksTntSeqNo = _naviParam.strTksTntSeqNo;
                addRow.hb2Yymm = dataRow.hb1Yymm;
                addRow.hb2JyutNo = dataRow.hb1JyutNo;
                addRow.hb2JyMeiNo = dataRow.hb1JyMeiNo;
                addRow.hb2UrMeiNo = dataRow.hb1UrMeiNo;
                // TODO：費目コードは空？ 
                addRow.hb2HimkCd = dataRow.hb1HimkCd;
                //addRow.hb2HimkCd = "   ";
                //addRow.hb2Renbn = (i + 1).ToString("000"); 明細登録件数拡張対応
                addRow.hb2Renbn = (i + 1).ToString("0000");
                addRow.hb2DateFrom = " ";
                addRow.hb2DateTo = " ";
                addRow.hb2SeiGak = (Decimal)_spdKkhDetail_Sheet1.Cells[i , COLIDX_MLIST_SEIKYUKINGAKU].Value;
                //部署
                addRow.hb2Name11 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUSHO].Value.ToString();

                //変更前値引率
                if
                (
                    ( _shubetsuMei == C_MEI_TVBAN ) |
                    ( _shubetsuMei == C_MEI_TVTOK )
                )
                {
                    //少数第５位を四捨五入(現行と合わせるため)
                    Decimal Nebiki = dataRow.hb1NeviRitu * 10000;
                    Decimal dValue = System.Math.Floor(Nebiki + 0.5m) / 10000;
                    addRow.hb2Hnnert = dValue;
                }
                else
                {
                    addRow.hb2Hnnert = 0M;
                }

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

                addRow.hb2Code1 = GetShubetsuCd(_shubetsuMei);
                //★保留 番組名コード. 
                addRow.hb2Code2 = " ";
                addRow.hb2Code3 = " ";
                addRow.hb2Code4 = " ";
                addRow.hb2Code5 = " ";
                addRow.hb2Code6 = " ";
                //費目名.
                addRow.hb2Name1 = _spdKkhDetail_Sheet1.Cells[i , COLIDX_MLIST_HIMOKUMEI].Value.ToString();
                //媒体名・放送局名
                //「新聞」「雑誌」「TVSPOT」「その他」 
                if (_shubetsuMei == C_MEI_ZASHI
                    || _shubetsuMei == C_MEI_SHINBUN
                    || _shubetsuMei == C_MEI_TVSPOT
                    || _shubetsuMei == C_MEI_SONOTA)
                {
                    addRow.hb2Name2 = _spdKkhDetail_Sheet1.Cells[i , COLIDX_MLIST_BAITAIMEI].Value.ToString();
                }
                else
                {
                    addRow.hb2Name2 = " ";
                }
                //掲載日.
                //「TV番組」「TV特番」.
                if (_shubetsuMei == C_MEI_TVBAN
                    || _shubetsuMei == C_MEI_TVTOK)
                {
                    addRow.hb2Name3 = KkhUniStrConv.GetHosoBiArray( _spdKkhDetail_Sheet1.Cells[i , COLIDX_MLIST_KEISAIBI].Value.ToString() );
                }
                //「TV SPOT」.
                else if (_shubetsuMei == C_MEI_TVSPOT)
                {
                    string _keisaiBi = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HOSOKAISU].Value.ToString();
                    _keisaiBi = _keisaiBi.Replace(C_SLASH, "");
                    _keisaiBi = _keisaiBi.Replace(C_HYPHEN, "");
                    addRow.hb2Name3 = _keisaiBi;
                }
                //「制作」.
                else if (_shubetsuMei == C_MEI_SEISAKU)
                {
                    addRow.hb2Name3 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEISAIBI].Value.ToString();
                }
                else
                {
                    string _keisaiBi = _spdKkhDetail_Sheet1.Cells[i , COLIDX_MLIST_KEISAIBI].Value.ToString();
                    _keisaiBi = _keisaiBi.Replace(C_SLASH, "");
                    _keisaiBi = _keisaiBi.Replace(C_HYPHEN, "");
                    addRow.hb2Name3 = _keisaiBi;
                }
                //制作内容.
                if (_shubetsuMei == C_MEI_SEISAKU)
                {
                    addRow.hb2Name4 = _spdKkhDetail_Sheet1.Cells[i , COLIDX_MLIST_SEISAKUNAIYO].Value.ToString();
                }
                else
                {
                    addRow.hb2Name4 = " ";
                }
                //番組名.
                if (_shubetsuMei == C_MEI_TVBAN
                    || _shubetsuMei == C_MEI_TVTOK)
                {
                    addRow.hb2Name5 = _spdKkhDetail_Sheet1.Cells[i , COLIDX_MLIST_BANGUMIMEI].Value.ToString();
                }
                else
                {
                    addRow.hb2Name5 = " ";
                }
                //掲載号.
                if (_shubetsuMei == C_MEI_ZASHI)
                {
                    addRow.hb2Name6 = _spdKkhDetail_Sheet1.Cells[i , COLIDX_MLIST_KEISAIGO].Value.ToString();
                }
                else
                {
                    addRow.hb2Name6 = " ";
                }
                //スペース.
                if(_shubetsuMei == C_MEI_ZASHI
                    || _shubetsuMei == C_MEI_SHINBUN)
                {
                    addRow.hb2Name7 = _spdKkhDetail_Sheet1.Cells[i , COLIDX_MLIST_SUPESU].Value.ToString();
                }
                else
                {
                    addRow.hb2Name7 = " ";
                }  
                addRow.hb2Name8 = " ";
                addRow.hb2Name9 = _spdKkhDetail_Sheet1.Cells[i , COLIDX_MLIST_KENMEI].Value.ToString();
                addRow.hb2Name10 = " ";
                //単価.
                if (_shubetsuMei == C_MEI_TVBAN
                    || _shubetsuMei == C_MEI_TVTOK
                    || _shubetsuMei == C_MEI_SEISAKU)
                {
                    addRow.hb2Kngk1 = (Decimal)_spdKkhDetail_Sheet1.Cells[i , COLIDX_MLIST_TANKA].Value;
                }
                else
                {
                    addRow.hb2Kngk1 = 0M;
                }
                //消費税額.
                addRow.hb2Kngk2 = (Decimal)_spdKkhDetail_Sheet1.Cells[i , COLIDX_MLIST_SHOHIZEIGAKU].Value;
                addRow.hb2Kngk3 = 0M;

                addRow.hb2Ritu1 = 0M;
                addRow.hb2Ritu2 = 0M;

                addRow.hb2Sonota1 = "0";
                //請求原票番号.
                string _seigen = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUGENPYO].Value.ToString();
                if (_seigen.Replace(C_HYPHEN, "").Length > 0)
                { 
                    //ハイフンを取り除く 
                    _seigen = _seigen.Replace(C_HYPHEN, "");

                    if (_seigen.Length > 10)
                    {
                        addRow.hb2Sonota2 = _seigen.Substring(10, 1);
                    }
                    else if (_seigen.Length == 1)
                    {
                        addRow.hb2Sonota2 = _seigen.Substring(0, 1);
                    }
                    else
                    {
                        addRow.hb2Sonota2 = " ";
                    }
                }
                else
                {
                    addRow.hb2Sonota2 = " ";
                }
                
                //ソート番号.
                int _sotoBango = int.Parse(_spdKkhDetail_Sheet1.Cells[i , COLIDX_MLIST_SOTOBANGO].Value.ToString());
                addRow.hb2Sonota3 = _sotoBango.ToString("000");
                //放送回数.
                //「TV番組」「TV特番」「制作」.
                if (_shubetsuMei == C_MEI_TVBAN
                     || _shubetsuMei == C_MEI_TVTOK
                     || _shubetsuMei == C_MEI_SEISAKU)
                {
                    addRow.hb2Sonota4 = _spdKkhDetail_Sheet1.Cells[i , COLIDX_MLIST_HOSOKAISU].Value.ToString();
                }
                //「TVSPOT」.
                else if (_shubetsuMei == C_MEI_TVSPOT)
                {
                    addRow.hb2Sonota4 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEISAIBI].Value.ToString();
                }
                else
                {
                    addRow.hb2Sonota4 = " ";
                }
                //放送月.
                //「TV番組」「TV特番」.
                if (_shubetsuMei == C_MEI_TVBAN
                     || _shubetsuMei == C_MEI_TVTOK)
                {
                    addRow.hb2Sonota5 = _spdKkhDetail_Sheet1.Cells[i , COLIDX_MLIST_HOSOTSUKI].Value.ToString().Replace( C_SLASH, "" );
                }
                else
                {
                    addRow.hb2Sonota5 = " ";
                }

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
                listRow.toroku = KkhConstUni.TorokuKbn.REGISTERED;
            }
            else
            {
                //明細登録"済"を解除 
                //listRow.toroku = "";
                listRow.toroku = KkhConstUni.TorokuKbn.YET;
            }


            ////現在位置の取得 
            //int _spdJyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            //base.SearchJyutyuData();

            ////指定行を元の位置に戻す 
            //_spdJyutyuList_Sheet1.SetActiveCell(_spdJyutyuListRowIdx, 0, true);
            //_spdJyutyuList_Sheet1.AddSelection(_spdJyutyuListRowIdx, -1, 1, -1);
            //spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

            ////親の処理を呼ぶ(親のLeaveCellイベントが発生しないので) 
            //base.DisplayKkhDetail(_spdJyutyuListRowIdx);
            ////子の処理を呼ぶ(親↑が呼んでくれないので) 
            //DisplayKkhDetail(_spdJyutyuListRowIdx);

            DisplayUpdate();

            //ローディング表示終了 
            base.CloseLoadingDialog();

            //MessageBox.Show("広告費明細の登録が完了しました。" , "明細登録" , MessageBoxButtons.OK);
            MessageUtility.ShowMessageBox(MessageCode.HB_I0012, null, "明細登録", MessageBoxButtons.OK);
        }

        /// <summary>
        /// 種別名より種別コードをセットする.
        /// </summary>
        /// <param name="shubetsuMei">種別名</param>
        /// <returns>種別コード</returns>
        private string GetShubetsuCd(string shubetsuMei)
        {
            string rtn = string.Empty;
            switch (shubetsuMei)
            {
                case C_MEI_TVBAN:
                    rtn = C_CD_TVBAN;
                    break;
                case C_MEI_TVTOK:
                    rtn = C_CD_TVTOK;
                    break;
                case C_MEI_TVSPOT:
                    rtn = C_CD_TVSPOT;
                    break;
                case C_MEI_ZASHI:
                    rtn = C_CD_ZASHI;
                    break;
                case C_MEI_SHINBUN:
                    rtn = C_CD_SHINBUN;
                    break;
                case C_MEI_SONOTA:
                    rtn = C_CD_SONOTA;
                    break;
                case C_MEI_SEISAKU:
                    rtn = C_CD_SEISAKU;
                    break;
                default:
                    rtn = string.Empty;
                    break;
            }
            return rtn;
        }

        # endregion メソッド

    }
}