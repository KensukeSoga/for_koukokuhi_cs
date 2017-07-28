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
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Lion.Schema;
using Isid.KKH.Lion.ProcessController.MastGet;
using Isid.KKH.Lion.ProcessController.Detail;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Lion.Utility;

namespace Isid.KKH.Lion.View.Detail
{
    public partial class DetailLion : DetailForm
    {

        #region 定数.

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "DtlLion";

        #endregion 定数.

        #region メンバ変数.
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();
        //明細入力画面用.
        private string pKmkType;//項目パターン.
        private string pBaitaiCd;//媒体CD
        private string pMeiCardNo;//明細データ存在時のカードＮＯ.
        private FindCommonByCondServiceResult plDtMast;//アドレス系システムマスタ用.
        private FindCommonByCondServiceResult plDtMast2;//ファイル系システムマスタ用.
        private Isid.KKH.Lion.Schema.MastLion.TvKeiKinSetDataTable prTvRmast;//TV料金マスタ用.
        private Isid.KKH.Lion.Schema.MastLion.RdKeiKinSetDataTable prRdRmast;//RD料金マスタ用.
        private FindLionMastByCondServiceResult prTvBngmast;//TV番組マスタ用.
        private FindLionMastByCondServiceResult prRdBngmast;//RD番組マスタ用.
        private FindLionMastByCondServiceResult prTvKmast;//TV局マスタ用.
        private FindLionMastByCondServiceResult prRdKmast;//RD局マスタ用.

        KKHLionReadMastDB readMastDB = new KKHLionReadMastDB();//汎用マスタ検索クラス(一度検索したマスタのデータを保持する)

        #endregion メンバ変数.

        #region コンストラクタ.

        /// <summary>
        /// 
        /// </summary>
        public DetailLion()
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
                //2013/03/19 jse okazaki Start
                //if (col.Index == COLIDX_JLIST_TOROKU) { col.Visible = true; }                   //登録.
                //if (col.Index == COLIDX_JLIST_TOGO) { col.Visible = false; }                    //統合.
                //if (col.Index == COLIDX_JLIST_DAIUKE) { col.Visible = true; }                   //代受.
                //if (col.Index == COLIDX_JLIST_SEIKYU) { col.Visible = false; }                  //請求.
                //if (col.Index == COLIDX_JLIST_URIMEINO) { col.Visible = true; }                 //売上明細NO
                //if (col.Index == COLIDX_JLIST_GPYNO) { col.Visible = false; }                   //請求原票NO
                //if (col.Index == COLIDX_JLIST_SEIYYMM) { col.Visible = true; }                  //請求年月.
                //if (col.Index == COLIDX_JLIST_GYOMKBN) { col.Visible = true; }                  //業務区分.
                //if (col.Index == COLIDX_JLIST_KENMEI) { col.Visible = true; }                   //件名.
                //if (col.Index == COLIDX_JLIST_BAITAINM) { col.Visible = false; }                //媒体名.
                //if (col.Index == COLIDX_JLIST_HIMOKUNM) { col.Visible = true; }                 //費目名.
                //if (col.Index == COLIDX_JLIST_KYOKUSHICD) { col.Visible = true; }               //局誌CD
                //if (col.Index == COLIDX_JLIST_SEIKINGAKU) { col.Visible = true; }               //請求金額.
                //if (col.Index == COLIDX_JLIST_KIKAN) { col.Visible = false; }                   //期間.
                //if (col.Index == COLIDX_JLIST_DANTANKA) { col.Visible = false; }                //段単価.
                //if (col.Index == COLIDX_JLIST_DANSU) { col.Visible = false; }                   //段数.
                //if (col.Index == COLIDX_JLIST_TORIRYOKIN) { col.Visible = true; }               //取料金.
                //if (col.Index == COLIDX_JLIST_NEBIKIRITSU) { col.Visible = true; }              //値引率.
                //if (col.Index == COLIDX_JLIST_NEBIKIGAKU) { col.Visible = true; }               //値引額.
                //if (col.Index == COLIDX_JLIST_ZEIRITSU) { col.Visible = true; }                 //消費税率.
                //if (col.Index == COLIDX_JLIST_ZEIGAKU) { col.Visible = true; }                  //消費税額.
                //if (col.Index == COLIDX_JLIST_GOUKEIKINGAKU) { col.Visible = false; }           //受注請求金額.
                //if (col.Index == COLIDX_JLIST_OLDSEIYYMM) { col.Visible = true; }               //変更前請求年月.
                if (col.Index == COLIDX_JLIST_TOROKU) { col.Visible = true; }                       //登録.
                if (col.Index == COLIDX_JLIST_TOGO) { col.Visible = false; }                        //統合.
                if (col.Index == COLIDX_JLIST_DAIUKE) { col.Visible = true; }                       //代受.
                if (col.Index == COLIDX_JLIST_SEIKYU) { col.Visible = false; }                      //請求.
                if (col.Index == COLIDX_JLIST_URIMEINO) { col.Visible = true; col.Width = 120; }    //売上明細NO
                if (col.Index == COLIDX_JLIST_GPYNO) { col.Visible = false; }                       //請求原票NO
                if (col.Index == COLIDX_JLIST_SEIYYMM) { col.Visible = true; col.Width = 56; }      //請求年月.
                if (col.Index == COLIDX_JLIST_GYOMKBN) { col.Visible = false; }                     //業務区分.
                if (col.Index == COLIDX_JLIST_KENMEI) { col.Visible = true; col.Width = 195; }      //件名.
                if (col.Index == COLIDX_JLIST_BAITAINM) { col.Visible = false; }                    //媒体名.
                if (col.Index == COLIDX_JLIST_HIMOKUNM) { col.Visible = true; col.Width = 80; }     //費目名.
                if (col.Index == COLIDX_JLIST_KYOKUSHICD) { col.Visible = true; col.Width = 70; }   //局誌CD
                if (col.Index == COLIDX_JLIST_SEIKINGAKU) { col.Visible = true; col.Width = 85; }   //請求金額.
                if (col.Index == COLIDX_JLIST_KIKAN) { col.Visible = false; }                       //期間.
                if (col.Index == COLIDX_JLIST_DANTANKA) { col.Visible = false; }                    //段単価.
                if (col.Index == COLIDX_JLIST_DANSU) { col.Visible = false; }                       //段数.
                if (col.Index == COLIDX_JLIST_TORIRYOKIN) { col.Visible = true; col.Width = 85; }   //取料金.
                if (col.Index == COLIDX_JLIST_NEBIKIRITSU) { col.Visible = true; col.Width = 45; }  //値引率.
                if (col.Index == COLIDX_JLIST_NEBIKIGAKU) { col.Visible = true; col.Width = 77; }   //値引額.
                if (col.Index == COLIDX_JLIST_ZEIRITSU) { col.Visible = true; col.Width = 56; }     //消費税率.
                if (col.Index == COLIDX_JLIST_ZEIGAKU) { col.Visible = true; col.Width = 77; }      //消費税額.
                if (col.Index == COLIDX_JLIST_GOUKEIKINGAKU) { col.Visible = false; }               //受注請求金額.
                if (col.Index == COLIDX_JLIST_OLDSEIYYMM) { col.Visible = true; col.Width = 56; }   //変更前請求年月.
                if (col.Index == COLIDX_JLIST_TRKTNT) { col.Visible = true; col.Width = 83; }       //登録者.
                if (col.Index == COLIDX_JLIST_UPDTNT) { col.Visible = true; col.Width = 83; }       //更新者.
                //2013/03/19 jse okazaki End
            }
        }

        /// <summary>
        /// 消費税の計算等の得意先個別処理.
        /// </summary>
        /// <param name="dsDetail"></param>
        protected override void UpdateSpdData(Isid.KKH.Common.KKHSchema.Detail dsDetail)
        {
            for (int i = 0; i < dsDetail.JyutyuList.Count; i++)
            {
                Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow row = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)dsDetail.JyutyuList.Rows[i];

                row.zeiGaku = Math.Truncate(row.seiKingaku * ( row.zeiritsu * 0.01M ));
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
            //*******************************************************************
            //広告費明細の初期化.
            //*******************************************************************
            ClearKkhDetail();

            //*******************************************************************
            //広告費明細データの取得.
            //*******************************************************************
            if (GetActiveSheetViewBySpdJyutyuList() != _spdJyutyuList_Sheet1)
            {
                return;
            }

            //◆◆データ取得処理は独自で実装◆◆.
            //Utilityクラスのインスタンス生成.
            KKHLionDetailCreate utl = new KKHLionDetailCreate();
            //*******************************************************************
            //広告費明細データの初期化.
            //*******************************************************************
            _dsDetailLion.KkhCardNo.Clear();
            _dsDetailLion.KkhMeisai.Clear();
            //スプレッド初期化.
            _spdKkhDetail_Sheet1.RowCount = 0;
            //変更中フラグを戻す.
            kkhDetailUpdFlag = false;
            //ボタンの初期化.
            //一括登録ボタン表示.

            //*******************************************************************
            //広告費明細（カードナンバー）データの取得.
            //*******************************************************************
            DetailLionProcessController.FindLionCardNoGetParam param = new DetailLionProcessController.FindLionCardNoGetParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(rowIdx);
            param.egCd = dataRow.hb1EgCd;
            param.tksKgyCd = dataRow.hb1TksKgyCd;
            param.tksBmnSeqNo = dataRow.hb1TksBmnSeqNo;
            param.tksTntSeqNo = dataRow.hb1TksTntSeqNo;
            param.yymm = dataRow.hb1Yymm;
            param.jyutNo = dataRow.hb1JyutNo;
            param.jyMeiNo = dataRow.hb1JyMeiNo;
            param.urMeiNo = dataRow.hb1UrMeiNo;

            DetailLionProcessController processController = DetailLionProcessController.GetInstance();
            FindLionByCondServiceResult result = processController.FindLionCardNoGet(param);

            //エラー.
            if (result.HasError == true)
            {
                //メッセージ出して終了.
                return;
            }

            //カードNOが存在するかどうかチェック.
            string strcardno = "";
            string strbaitaicd = "";
            //存在しない.
            if (result.DetailLionDataSet.KkhCardNo.Count == 0)
            {
                //カードNOが存在しない.
                pMeiCardNo = "";
            }
            //存在する.
            else
            {
                //データセット取り出し.
                DataRow[] foundRows = result.DetailLionDataSet.KkhCardNo.Select();
                foreach (DataRow dr in foundRows)
                {
                    //カードNOセット.
                    strcardno = dr["CODE6"].ToString();
                    //明細入力画面用に保持.
                    pMeiCardNo = strcardno;
                    //媒体区分セット.
                    strbaitaicd = dr["CODE1"].ToString();
                    break;
                }
            }

            //*******************************************************************
            //広告費明細（表示明細）データの取得.
            //*******************************************************************
            DetailLionProcessController.FindDetailDataLionByCondParam paramn = new DetailLionProcessController.FindDetailDataLionByCondParam();
            paramn.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            paramn.egCd = dataRow.hb1EgCd;
            paramn.tksKgyCd = dataRow.hb1TksKgyCd;
            paramn.tksBmnSeqNo = dataRow.hb1TksBmnSeqNo;
            paramn.tksTntSeqNo = dataRow.hb1TksTntSeqNo;
            paramn.yymm = dataRow.hb1Yymm;
            paramn.jyutNo = dataRow.hb1JyutNo;
            paramn.jyMeiNo = dataRow.hb1JyMeiNo;
            paramn.urMeiNo = dataRow.hb1UrMeiNo;
            paramn.code6 = strcardno;
            paramn.code1 = strbaitaicd;

            DetailLionProcessController processControllern = DetailLionProcessController.GetInstance();
            FindLionByCondServiceResult resultn = processController.FindLionDetail(paramn);

            //エラー.
            if (resultn.HasError == true)
            {
                //メッセージ出して終了.
                return;
            }

            //０件or１件～で分岐（媒体、カードNO）.
            ArrayList strCdorKbn = new ArrayList();
            string ptncd = "";
            //明細データが存在しない.
            if (resultn.DetailLionDataSet.KkhMeisai.Count == 0)
            {
                //媒体区分で項目を設定.
                ptncd = utl.CardNoAndBaitaiKbnKmkCheck(KKHLionConst.COLSTR_BTPATARN, dataRow.hb1GyomKbn,dataRow.hb1SeiKbn);
                InitializeDesignForSpdKkhDetail(ptncd, KKHLionConst.BAITAIKBN_TV_SPOT);//スポットは全て０２（テレビ）.
                //ボタン制御.
                btnDetailInput.Enabled = true;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = true;
                EnableChangeForAfterSearch();
                //パターンをINPUT用変数へ.
                //項目タイプ.
                pKmkType = ptncd;
                //媒体CD
                pBaitaiCd = "";
                //★いる？.
                //pBaitaiCd = KKHLionConst.BAITAIKBN_TV_SPOT;

                //差額計算.
                CalculateSagaku(dataRow);
                //取料金合計計算.
                CalculateTriRokin(dataRow);
                //請求金額合計計算.
                CalculateSeikyu(dataRow);
                //電波料合計計算.
                CalculateDenpaRyo(dataRow);
                //本数・秒数をセット.
                SetHonsuByosu(dataRow);

                //終了.
                return;
            }
            //明細データが存在する.
            else
            {
                //カードNOで項目を設定.
                ptncd = utl.CardNoAndBaitaiKbnKmkCheck(KKHLionConst.COLSTR_CDPATARN,strcardno,"");
                InitializeDesignForSpdKkhDetail(ptncd, strbaitaicd);
                //パターンをINPUT用変数へ.
                //項目タイプ.
                pKmkType = ptncd;
                //媒体CD
                pBaitaiCd = strbaitaicd;
            }

            //***************************************
            //表示用広告費明細データの編集・表示.
            //***************************************

            //スプレッド追加用変数.
            int SpdCnt = 0;//シート用.
            int llngCastRow = 0;//地区コードの変わり目用.
            string lstrCastCD = "";//地区コード（OLD)格納用.
            decimal llngCastCost = 0;//合計金額保存用.

            #region //データセットver ////////////////////////////////////////////////////////////////
            ////Isid.KKH.Lion.Schema.DetailDSLion.KkhDetailDataTable datavo = new Isid.KKH.Lion.Schema.DetailDSLion.KkhDetailDataTable();
            //_dsDetailLion.KkhDetail.Clear();
            ////データ件数分ループする.
            //foreach (Isid.KKH.Lion.Schema.DetailDSLion.KkhMeisaiRow row in resultn.DetailLionDataSet.KkhMeisai.Rows)
            //{
            //    //データvoを生成.
            //    //datavo.Rows[SpdCnt]["CARDNO"] = ar[0];
            //    //datavo.AddKkhDetailRow(datavo.NewKkhDetailRow());
            //    DetailDSLion.KkhDetailRow datavo = _dsDetailLion.KkhDetail.NewKkhDetailRow();

            //    datavo.CARDNO = row.CODE6;//カードNO
            //    datavo.SEIKYUNO = row.NAME3;//請求書NO
            //    datavo.YYMM = row.YYMM;//年月.
            //    datavo.DAIRITEN = row.CODE4;//代理店.
            //    datavo.BAITAI = row.CODE1;//媒体区分.
            //    datavo.BANGCD = row.CODE5;//番組CD
            //    datavo.HIMKCD = row.HIMKCD;//費目CD
            //    datavo.BRANDCD = row.CODE3 + " " + row.VAL2;//ブランドCD
            //    datavo.FUKENCD = row.SONOTA2;//府県CD
            //    datavo.KYOKUSICD = row.CODE2;//局誌CD
            //    datavo.STR1 = row.VAL1;//可変（媒体名称、件名称、局誌名称）.
            //    datavo.NETFC = row.SONOTA3;//NET FC
            //    datavo.SPACE = row.NAME2;//スペース.
            //    datavo.INT1 = row.NAME4;//可変（実施料、宣伝費）.
            //    datavo.JISIDENPA = row.KNGK1;//実施電波料.
            //    datavo.NBKRITU = row.HNNERT;//値引率.
            //    datavo.NBKDENPARYO = row.NEBIGAK;//値引電波料.
            //    datavo.NETRYO = row.KNGK2;//ネット料.
            //    datavo.INT2 = row.KNGK3;//可変（制作費、タイアップ製作費）.
            //    datavo.NBKGOKNGK = row.SEIGAK;//値引後額.
            //    datavo.TAXRITU = row.RITU1;//消費税率.
            //    datavo.TAX = row.NAME1;//消費税.
            //    datavo.HONSU = row.SONOTA5;//本数.
            //    datavo.BYOSU = row.SONOTA7;//秒数.
            //    datavo.SOBYOSU = row.SONOTA6;//総秒数.
            //    datavo.HOSOSU = row.SONOTA8;//放送回数.
            //    datavo.KYUSISU = KKHUtility.IntParse(row.SONOTA1);//休止回数.
            //    datavo.ONAIRSU =
            //        KKHUtility.IntParse(row.SONOTA8) - KKHUtility.IntParse(row.SONOTA1);//オンエアー回数.
            //    datavo.KENMEI = row.NAME10;//件名.
            //    datavo.KEISAI = row.NAME5;//掲載.
            //    datavo.ROSEN = row.NAME6;//路線.
            //    datavo.KIKAN = row.NAME7;//期間.
            //    datavo.BIKO = row.NAME8;//備考.
            //    datavo.URIMEI =
            //        (row.JYUTNO) + "-" + (row.JYMEINO) + "-" + (row.URMEINO);//売明NO
            //    datavo.HYOJIJYN = row.SONOTA9;//FD用表示順.
            //    datavo.TIKUGO = row.NAME6;//地区合計.

            //    datavo.KENCHANGE = "";//件名変更フラグ.

            //    ////地区が変わったら地区計を格納(ＴＶスポットのみ)
            //    if (row.CODE1.ToString().Equals(CONSTR_BAITAI_TVSPOT))
            //    {
            //        //地区CDが同一、または初回時.
            //        if (lstrCastCD.Equals(row.VAL3) || SpdCnt == 0)
            //        {
            //            if (llngCastRow == -1)
            //            {
            //                if (SpdCnt == 0)
            //                {
            //                    llngCastRow = 0;
            //                }
            //                else
            //                {
            //                    llngCastRow = SpdCnt - 1;
            //                }
            //            }
            //        }
            //        //地区CDが異なる(データをセットする）.
            //        else
            //        {
            //            //地区合計セット.
            //            datavo.TIKUGO = llngCastCost;
            //            llngCastCost = 0;//初期化.
            //            llngCastRow = -1;
            //        }

            //        //lstrCastCD
            //        lstrCastCD = row.VAL3;
            //        //地区コード.
            //        datavo.TIKUCD = row.VAL3;
            //        //地区計.
            //        llngCastCost = llngCastCost + row.SEIGAK;

            //    }
            //    //シート用カウント＋＋.
            //    _dsDetailLion.KkhDetail.AddKkhDetailRow(datavo);
            //}

            ////(ＴＶスポットのみ)
            //if (llngCastRow != -1)
            //{
            //    DetailDSLion.KkhDetailRow datavo = _dsDetailLion.KkhDetail.NewKkhDetailRow();
            //    //地区合計セット.
            //    datavo.TIKUGO = llngCastCost;
            //    //一括ボタン表示.
            //    btnBulkRegister.Visible = true;
            //    btnBulkRegister.Enabled = true;

            //    _dsDetailLion.KkhDetail.AddKkhDetailRow(datavo);
            //}
            //else
            //{
            //    //一括ボタン非表示.
            //    btnBulkRegister.Visible = false;
            //}

            #endregion //データセットver ////////////////////////////////////////////////////////////////

            //スプレッドのレイアウト描画中止.
            spdKkhDetail.SuspendLayout();

            //行をデータ分作成する add takahashi 03/15
            _spdKkhDetail_Sheet1.RowCount = resultn.DetailLionDataSet.KkhMeisai.Rows.Count;

            //データ件数分ループする.
            foreach (Isid.KKH.Lion.Schema.DetailDSLion.KkhMeisaiRow row in resultn.DetailLionDataSet.KkhMeisai.Rows)
            {
                //※媒体によって８パターン存在する為バインドでなく直接シートに挿入.
                //_spdKkhDetail_Sheet1.AddRows(SpdCnt, 1); //del takahashi 03/15
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_CARDNO].Value = row.CODE6;//カードNO
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_SEIKYUNO].Value = row.NAME3;//請求書NO
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_YYMM].Value = row.YYMM;//年月.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_DAIRITEN].Value = row.CODE4;//代理店.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_BAITAI].Value = row.CODE1;//媒体区分.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_BANGCD].Value = row.CODE5;//番組CD
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_HIMKCD].Value = row.HIMKCD;//費目CD
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_BRANDCD].Value = row.CODE3 + " " + row.VAL2;//ブランドCD
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_FUKENCD].Value = row.SONOTA2;//府県CD
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Value = row.CODE2;//局誌CD
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_STR1].Value = row.VAL1;//可変（媒体名称、件名称、局誌名称）.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_NETFC].Value = row.SONOTA3;//NET FC
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_SPACE].Value = row.NAME2;//スペース.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_INT1].Value = row.NAME4;//可変（実施料、宣伝費）.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_JISIDENPA].Value = row.KNGK1;//実施電波料.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_NBKRITU].Value = row.HNNERT;//値引率.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value = row.NEBIGAK;//値引電波料.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_NETRYO].Value = row.KNGK2;//ネット料.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_INT2].Value = row.KNGK3;//可変（制作費、タイアップ製作費）.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Value = row.SEIGAK;//値引後額.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_TAXRITU].Value = row.RITU1;//消費税率.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_TAX].Value = row.NAME1;//消費税.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_HONSU].Value = row.SONOTA5;//本数.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_BYOSU].Value = row.SONOTA7;//秒数.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_SOBYOSU].Value = row.SONOTA6;//総秒数.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_HOSOSU].Value = row.SONOTA8;//放送回数.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_KYUSISU].Value = KKHUtility.IntParse(row.SONOTA1);//休止回数.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_ONAIRSU].Value =
                    KKHUtility.IntParse(row.SONOTA8) - KKHUtility.IntParse(row.SONOTA1);//オンエアー回数.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_KENMEI].Value = row.NAME10;//件名.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_KEISAI].Value = row.NAME5;//掲載.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_ROSEN].Value = row.NAME6;//路線.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_KIKAN].Value = row.NAME7;//期間.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_BIKO].Value = row.NAME8;//備考.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_URIMEI].Value =
                    (row.JYUTNO) + "-" + (row.JYMEINO) + "-" + (row.URMEINO);//売明NO
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_HYOJIJYN].Value = row.SONOTA9;//FD用表示順.
                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_TIKUGO].Value = row.NAME6;//地区合計.

                _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_KENCHANGE].Value = "";//件名変更フラグ.

                //地区が変わったら地区計を格納(ＴＶスポットのみ)
                if (row.CODE1.ToString().Equals(KKHLionConst.BAITAIKBN_TV_SPOT))
                {
                    //地区計をセット.
                    //地区CDが異なるor最終行.
                    if ((SpdCnt != 0 && !lstrCastCD.Equals(row.VAL3)) || SpdCnt == _spdKkhDetail_Sheet1.RowCount - 1)
                    {
                        //1行目.
                        if (SpdCnt == 0)
                        {
                            llngCastCost = row.SEIGAK;//初期化.
                        }
                        //最終行.
                        else if (SpdCnt == _spdKkhDetail_Sheet1.RowCount - 1)
                        {
                            llngCastCost = llngCastCost + row.SEIGAK;
                        }
                        //地区合計セット.
                        _spdKkhDetail_Sheet1.Cells[llngCastRow, KKHLionConst.COLIDX_MLIST_TIKUGO].Value = llngCastCost;

                        llngCastCost = row.SEIGAK;//初期化.
                        llngCastRow = SpdCnt;     //地区計を表示する行Indexを保持.
                    }
                    else
                    {
                        //地区計.
                        llngCastCost = llngCastCost + row.SEIGAK;
                    }

                    //lstrCastCD
                    lstrCastCD = row.VAL3;
                    //地区コード.
                    _spdKkhDetail_Sheet1.Cells[SpdCnt, KKHLionConst.COLIDX_MLIST_TIKUCD].Value = row.VAL3;

                }
                //シート用カウント＋＋.
                SpdCnt++;
            }

            //レイアウトロジック再開.
            spdKkhDetail.ResumeLayout(true);

            //スプレッド更新.
            _dsDetailLion.KkhDetail.AcceptChanges();

            ////スプレッドデザインの再初期化.
            //InitializeDesignForSpdKkhDetail();
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(0, 0, 1, 1);
            }

            //***************************************
            //ボタン類の使用可・不可設定.
            //***************************************
            btnDetailInput.Enabled = true;
            btnDetailDel.Enabled = true;
            btnDetailRegister.Enabled = true;

            EnableChangeForAfterSearch();

            //******************************
            //差額・計ラベル.
            //******************************
            //差額計算.
            CalculateSagaku(dataRow);
            //取料金合計計算.
            CalculateTriRokin(dataRow);
            //請求金額合計計算.
            CalculateSeikyu(dataRow);
            //電波料合計計算.
            CalculateDenpaRyo(dataRow);
            //本数・秒数をセット.
            SetHonsuByosu(dataRow);
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
            //請求金額合計ラベル.
            lblSeikyuValue.Text = "";
            //秒数ラベル.
            lblByosuValue.Text = "";
            //本数ラベル.
            lblHonsuValue.Text = "";
            //取料金合計ラベル.
            lblToriRyokinValue.Text = "";
            //電波料合計合計ラベル.
            lblDenpaValue.Text = "";

            //***************************************
            //ボタン類の使用可・不可設定.
            //***************************************
            btnDetailInput.Enabled = false;
            btnDetailDel.Enabled = false;
            btnDetailRegister.Enabled = false;
            btnBulkRegister.Visible = false;
            btnBulkRegister.Enabled = false;
            btnSubjectUpdate.Enabled = false;
            btnMergeByJyutyuNo.Enabled = false;
            btnTVTimeMergeByJyutyuNo.Enabled = false;
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
                btnDetailInput.Enabled = false;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = false;
                //btnDivide.Enabled = false;
                btnBulkRegister.Visible = false;
                btnBulkRegister.Enabled = false;
                btnSubjectUpdate.Enabled = false;
                btnMergeByJyutyuNo.Enabled = false;
                btnTVTimeMergeByJyutyuNo.Enabled = false;

                //差額・計.
                lblSagakuValue.Text = "0";
                lblGoukeiValue.Text = "0";
                //請求金額合計ラベル.
                lblSeikyuValue.Text = "0";
                //秒数ラベル.
                lblByosuValue.Text = "";
                //本数ラベル.
                lblHonsuValue.Text = "";
                //取料金合計ラベル.
                lblToriRyokinValue.Text = "0";
                //電波料合計合計ラベル.
                lblDenpaValue.Text = "0";

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
                Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow jyutyuDataRow = getSelectJyutyuData(activeRow);
                //if (CheckBulkRegTarget(jyutyuDataRow) == true)
                //請求区分がスポット、かつテレビ、またはラジオ、または衛星の場合.
                if (jyutyuDataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Spot
                    && (jyutyuDataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio
                    || jyutyuDataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.TVSpot
                    || jyutyuDataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.EiseiM)
                    )
                {
                    btnBulkRegister.Visible = true;
                    btnBulkRegister.Enabled = true;
                }
                //国際かつ、テレビスポットの場合.
                else if (jyutyuDataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.KMas
                    && jyutyuDataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.TVSpot)
                    //|| jyutyuDataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio)
                {
                    btnBulkRegister.Visible = true;
                    btnBulkRegister.Enabled = true;
                }
                else
                {
                    btnBulkRegister.Visible = false;
                    btnBulkRegister.Enabled = false;
                }
                btnSubjectUpdate.Enabled = true;
                btnMergeByJyutyuNo.Enabled = true;
                btnTVTimeMergeByJyutyuNo.Enabled = true;

                //アクティブなのが子ビューの場合は明細関係のボタン使用不可.
            }
            else
            {
                btnBulkRegister.Visible = false;
                btnBulkRegister.Enabled = false;
                btnSubjectUpdate.Enabled = false;
                btnMergeByJyutyuNo.Enabled = false;
                btnTVTimeMergeByJyutyuNo.Enabled = false;
                //アクティブなのが子ビューの場合は明細関係のボタン使用不可.
                btnDetailInput.Enabled = false;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = false;
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
            KKHLogUtilityLion.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_UPDCHECK, KKHLogUtilityLion.DESC_OPERATION_LOG_UPDCHECK);

            return true;
        }

        #endregion オーバーライド.

        #region イベント.

        /// <summary>
        /// 画面遷移するたびに発生します。.
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void DetailLion_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParameter = (KKHNaviParameter)arg.NaviParameter;
            }

            this.ActiveControl = null;

        }

        /// <summary>
        /// フォームロードイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailLion_Shown(object sender, EventArgs e)
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            //取得（アドレス）.
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(
                                                                                            _naviParameter.strEsqId,
                                                                                            _naviParameter.strEgcd,
                                                                                            _naviParameter.strTksKgyCd,
                                                                                            _naviParameter.strTksBmnSeqNo,
                                                                                            _naviParameter.strTksTntSeqNo,
                                                                                            KKHLionConst.C_WRFL_SYBT,
                                                                                            KKHLionConst.C_SMASTA_FLD1);
            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                //リザルトに保持.
                plDtMast = comResult;
            }

            //取得（ファイル）.
            CommonProcessController commonProcessController2 = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult2 = commonProcessController2.FindCommonByCond(
                                                                                            _naviParameter.strEsqId,
                                                                                            _naviParameter.strEgcd,
                                                                                            _naviParameter.strTksKgyCd,
                                                                                            _naviParameter.strTksBmnSeqNo,
                                                                                            _naviParameter.strTksTntSeqNo,
                                                                                            KKHLionConst.C_WRKT_SYBT,
                                                                                            KKHLionConst.C_WRKTF_FLD1);
            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //リザルトに保持.
                plDtMast2 = comResult2;
            }

            //マスタ取得処理/////////////////////////////////////////////////////////////////////////////////////////
            //変数.
            string Address = "";//アドレス(秒数系)
            string AddressMst = "";//アドレス(そのほかマスタ系）.
            string Pass = "";//パスワード.
            string TempAddress = "";//テンプアドレス.
            string TvbFname = "";//テレビ秒数用ファイルネーム.
            string RdbFname = "";//テレビ秒数用ファイルネーム.
            string TvRFname = "";//テレビ系列局金額設定マスタファイル用ファイルネーム.
            string RdRFname = "";//ラジオ系列局金額設定マスタファイル用ネーム.
            string TvBnFname = "";//テレビ番組マスタ用ファイルネーム.
            string RdBnFname = "";//ラジオ番組マスタ用ファイルネーム.
            string TvKFname = "";//テレビ局マスタ用ファイルネーム.
            string RdKFname = "";//ラジオ局マスタ用ファイルネーム.

            //アドレス、パス、添付アドレスを取得設定.
            Address = plDtMast.CommonDataSet.SystemCommon[0].field3.ToString();
            AddressMst = plDtMast.CommonDataSet.SystemCommon[0].field4.ToString();
            Pass = plDtMast.CommonDataSet.SystemCommon[0].field10.ToString();
            TempAddress = plDtMast.CommonDataSet.SystemCommon[0].field2.ToString();
            //ファイル名を取得設定.
            TvbFname = plDtMast2.CommonDataSet.SystemCommon[0].field8.ToString();
            RdbFname = plDtMast2.CommonDataSet.SystemCommon[0].field9.ToString();
            TvBnFname = plDtMast2.CommonDataSet.SystemCommon[0].field2.ToString();
            RdBnFname = plDtMast2.CommonDataSet.SystemCommon[0].field3.ToString();
            TvKFname = plDtMast2.CommonDataSet.SystemCommon[0].field4.ToString();
            RdKFname = plDtMast2.CommonDataSet.SystemCommon[0].field5.ToString();
            TvRFname = plDtMast2.CommonDataSet.SystemCommon[0].field6.ToString();
            RdRFname = plDtMast2.CommonDataSet.SystemCommon[0].field7.ToString();

            //システム管理者の場合はマスタファイルの存在確認不要.
            if (!_naviParameter.strEsqId.Substring(0, 3).Equals("@@@"))
            {
                //マスタファイル存在確認.
                if (!(System.IO.File.Exists(AddressMst + TvBnFname) &&
                    System.IO.File.Exists(AddressMst + RdBnFname) &&
                    System.IO.File.Exists(AddressMst + TvKFname) &&
                    System.IO.File.Exists(AddressMst + RdKFname) &&
                    System.IO.File.Exists(AddressMst + TvRFname) &&
                    System.IO.File.Exists(AddressMst + RdRFname))
                    )
                {
                    //メッセージ表示.
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0009, null, "明細登録", MessageBoxButtons.OK);
                    //ローディング表示終了.
                    base.CloseLoadingDialog();
                    //TOPメニューへ遷移.
                    Navigator.Backward(this, null, _naviParameter, true);

                    return;
                }
            }

            //現在日付時刻セット.
            DateTime dtNow = DateTime.Now;

            //タイムスタンプ用.
            KKHLionTimeStamp tims = new KKHLionTimeStamp();
            //マスタファイルゲット用.
            KKHLionReadMastFile mstf = new KKHLionReadMastFile();

            //TV系列局金額設定マスタデータ取得テスト.
            //ファイル取得、比較.
            if (tims.findMastGet(AddressMst, Pass, TempAddress, TvRFname, KKHLionConst.C_WRFL_TVRMST, _naviParameter))
            { }
            //データテーブルVOにデータ読込開始.
            prTvRmast = mstf.findTvRDataCSVRead(AddressMst + TvRFname, _naviParameter);
            //システム管理者の場合はデータ無しでもＯＫ.
            if (!_naviParameter.strEsqId.Substring(0, 3).Equals("@@@"))
            {
                if (prTvRmast == null)
                {
                    //ローディング表示終了.
                    base.CloseLoadingDialog();
                    //TOPメニューへ遷移.
                    Navigator.Backward(this, null, _naviParameter, true);
                    return;
                }
            }

            //RD系列局金額設定マスタデータ取得テスト.
            //ファイル取得、比較.
            if (tims.findMastGet(AddressMst, Pass, TempAddress, RdRFname, KKHLionConst.C_WRFL_RDRMST, _naviParameter))
            { }
            //データテーブルVOにデータ読込開始.
            prRdRmast = mstf.findRdRDataCSVRead(AddressMst + RdRFname, _naviParameter);
            //システム管理者の場合はデータ無しでもＯＫ.
            if (!_naviParameter.strEsqId.Substring(0, 3).Equals("@@@"))
            {
                if (prRdRmast == null)
                {
                    //ローディング表示終了.
                    base.CloseLoadingDialog();
                    //TOPメニューへ遷移.
                    Navigator.Backward(this, null, _naviParameter, true);
                    return;
                }
            }

            //●↓ここからワークテーブルリフレッシュタイム↓●.

            //システム管理者の場合はワークテーブルの更新を行わない.
            if (!_naviParameter.strEsqId.Substring(0, 3).Equals("@@@"))
            {
                //TV番組マスタデータワークテーブルリフレッシュ処理.
                //ファイル取得、比較.
                //Boolean blok = false;
                if (tims.findMastGet(AddressMst, Pass, TempAddress, TvBnFname, KKHLionConst.C_WRFL_TVBMST, _naviParameter))
                {
                    //ワークテーブルリフレッシュ（TV番組マスタ）.
                    Isid.KKH.Lion.Schema.MastLion.TvBnLionDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.TvBnLionDataTable();
                    Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController masterMaintenanceProcessController = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
                    mstdatavo = mstf.TvBnSetCsvData(AddressMst + TvBnFname, _naviParameter);

                    if (mstdatavo != null)
                    {
                        masterMaintenanceProcessController.RegisterMasterResult(
                                                                          _naviParameter.strEsqId,
                                                                          KKHLionConst.C_TRKPL,
                                                                          _naviParameter.strEgcd,
                                                                          _naviParameter.strTksKgyCd,
                                                                          _naviParameter.strTksBmnSeqNo,
                                                                          _naviParameter.strTksTntSeqNo,
                                                                          "",
                                                                          "",
                                                                          mstdatavo,
                                                                          dtNow);

                        // オペレーションログの出力.
                        KKHLogUtilityLion.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_WKTVB,  KKHLogUtilityLion.DESC_OPERATION_LOG_WKTVB);

                    }
                    else
                    {
                        //ローディング表示終了.
                        base.CloseLoadingDialog();
                        //TOPメニューへ遷移.
                        Navigator.Backward(this, null, _naviParameter, true);
                        return;
                    }
                }

                //ラジオ番組マスタデータワークテーブルリフレッシュ処理.
                //ファイル取得、比較.
                if (tims.findMastGet(AddressMst, Pass, TempAddress, RdBnFname, KKHLionConst.C_WRFL_RDBMST, _naviParameter))
                {
                    //ワークテーブルリフレッシュ（ラジオ番組マスタ)
                    Isid.KKH.Lion.Schema.MastLion.RdBnLionDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.RdBnLionDataTable();
                    Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController masterMaintenanceProcessController = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
                    mstdatavo = mstf.RdBnSetCsvData(AddressMst + RdBnFname, _naviParameter);

                    if (mstdatavo != null)
                    {
                        masterMaintenanceProcessController.RegisterRdMasterResult(
                                                                          _naviParameter.strEsqId,
                                                                          KKHLionConst.C_TRKPL,
                                                                          _naviParameter.strEgcd,
                                                                          _naviParameter.strTksKgyCd,
                                                                          _naviParameter.strTksBmnSeqNo,
                                                                          _naviParameter.strTksTntSeqNo,
                                                                          "",
                                                                          "",
                                                                          mstdatavo,
                                                                          dtNow);

                        // オペレーションログの出力.
                        KKHLogUtilityLion.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_WKRDB, KKHLogUtilityLion.DESC_OPERATION_LOG_WKRDB);

                    }
                    else
                    {
                        //ローディング表示終了.
                        base.CloseLoadingDialog();
                        //TOPメニューへ遷移.
                        Navigator.Backward(this, null, _naviParameter, true);
                        return;
                    }
                }

                //TV局マスタデータワークテーブルリフレッシュ処理.
                //ファイル取得、比較.
                if (tims.findMastGet(AddressMst, Pass, TempAddress, TvKFname, KKHLionConst.C_WRFL_TVKMST, _naviParameter))
                {
                    //ワークテーブルリフレッシュ（TV局マスタ）.
                    Isid.KKH.Lion.Schema.MastLion.TvKLionDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.TvKLionDataTable();
                    Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController masterMaintenanceProcessController = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
                    mstdatavo = mstf.TvKSetCsvData(AddressMst + TvKFname, _naviParameter);

                    if (mstdatavo != null)
                    {
                        masterMaintenanceProcessController.RegisterTvKMasterResult(
                                                                          _naviParameter.strEsqId,
                                                                          KKHLionConst.C_TRKPL,
                                                                          _naviParameter.strEgcd,
                                                                          _naviParameter.strTksKgyCd,
                                                                          _naviParameter.strTksBmnSeqNo,
                                                                          _naviParameter.strTksTntSeqNo,
                                                                          "",
                                                                          "",
                                                                          mstdatavo,
                                                                          dtNow);

                        // オペレーションログの出力.
                        KKHLogUtilityLion.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_WKTVK, KKHLogUtilityLion.DESC_OPERATION_LOG_WKTVK);

                    }
                    else
                    {
                        //ローディング表示終了.
                        base.CloseLoadingDialog();
                        //TOPメニューへ遷移.
                        Navigator.Backward(this, null, _naviParameter, true);
                        return;
                    }
                }

                //ラジオ局マスタデータワークテーブルリフレッシュ処理.
                //ファイル取得、比較.
                if (tims.findMastGet(AddressMst, Pass, TempAddress, RdKFname, KKHLionConst.C_WRFL_RDKMST, _naviParameter))
                {
                    //ワークテーブルリフレッシュ（ラジオ局マスタ）.
                    Isid.KKH.Lion.Schema.MastLion.RdKLionDataTable mstdatavo = new Isid.KKH.Lion.Schema.MastLion.RdKLionDataTable();
                    Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController masterMaintenanceProcessController = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
                    mstdatavo = mstf.RdKSetCsvData(AddressMst + RdKFname, _naviParameter);

                    if (mstdatavo != null)
                    {
                        masterMaintenanceProcessController.RegisterRdKMasterResult(
                                                                          _naviParameter.strEsqId,
                                                                          KKHLionConst.C_TRKPL,
                                                                          _naviParameter.strEgcd,
                                                                          _naviParameter.strTksKgyCd,
                                                                          _naviParameter.strTksBmnSeqNo,
                                                                          _naviParameter.strTksTntSeqNo,
                                                                          "",
                                                                          "",
                                                                          mstdatavo,
                                                                          dtNow);

                        // オペレーションログの出力.
                        KKHLogUtilityLion.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_WKRDK, KKHLogUtilityLion.DESC_OPERATION_LOG_WKRDK);

                    }
                    else
                    {
                        //ローディング表示終了.
                        base.CloseLoadingDialog();
                        //TOPメニューへ遷移.
                        Navigator.Backward(this, null, _naviParameter, true);
                        return;
                    }
                }
            }
            //●↑ここまでワークテーブルリフレッシュタイム↑●.

            //TV番組マスタ取得処理.
            //実行.
            MastLion Tvmstdata = new MastLion();
            Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController mast = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
            ArrayList arytvmast = new ArrayList();

            //検索項目（空白でもOK)
            arytvmast.Add("");//番組CD
            arytvmast.Add("");//番組NM
            arytvmast.Add("");//局誌CD
            arytvmast.Add("");//単価区分.
            arytvmast.Add("");//TYPE2

            //実行.
            FindLionMastByCondServiceResult result = mast.FindTvMast(arytvmast, _naviParameter);

            //データが存在しなければ終了.
            if (result == null)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                //TOPメニューへ遷移.
                Navigator.Backward(this, null, _naviParameter, true);
                return;
            }
            else
            {
                prTvBngmast = result;
            }

            //ラジオ番組マスタ取得処理.
            //実行.
            MastLion Rdmstdata = new MastLion();
            Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController mastrd = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
            ArrayList aryrdmast = new ArrayList();

            //検索項目（空白でもOK)
            aryrdmast.Add("");//番組CD
            aryrdmast.Add("");//番組NM
            aryrdmast.Add("");//局誌CD
            aryrdmast.Add("");//単価区分.
            aryrdmast.Add("");//TYPE2

            //実行.
            FindLionMastByCondServiceResult rdresult = mastrd.FindRdMast(aryrdmast, _naviParameter);

            //データが存在しなければ終了.
            if (rdresult == null)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                //TOPメニューへ遷移.
                Navigator.Backward(this, null, _naviParameter, true);
                return;
            }
            else
            {
                prRdBngmast = rdresult;
            }

            //テレビ局マスタ取得処理.
            //実行.
            MastLion TvKmstdata = new MastLion();
            Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController masttvk = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
            ArrayList arytvkmast = new ArrayList();

            //検索項目（空白でもOK)
            arytvkmast.Add("");//放送局コード.
            arytvkmast.Add("");//記号.
            arytvkmast.Add("");//系列.
            arytvkmast.Add("");//地区.

            //実行.
            FindLionMastByCondServiceResult tvkresult = masttvk.FindTvKMast(arytvkmast, _naviParameter);

            //データが存在しなければ終了.
            if (tvkresult == null)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                //TOPメニューへ遷移.
                Navigator.Backward(this, null, _naviParameter, true);
                return;
            }
            else
            {
                prTvKmast = tvkresult;
            }

            //ラジオ局マスタ取得処理.
            //実行.
            MastLion RdKmstdata = new MastLion();
            Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController mastrdk = Isid.KKH.Lion.ProcessController.MastGet.MasterMaintenanceProcessController.GetInstance();
            ArrayList aryrdkmast = new ArrayList();

            //検索項目（空白でもOK)
            aryrdkmast.Add("");//放送局コード.
            aryrdkmast.Add("");//記号.
            aryrdkmast.Add("");//系列.

            //実行.
            FindLionMastByCondServiceResult rdkresult = mastrdk.FindRdKMast(aryrdkmast, _naviParameter);

            //データが存在しなければ終了.
            if (rdkresult == null)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                //TOPメニューへ遷移.
                Navigator.Backward(this, null, _naviParameter, true);
                return;
            }
            else
            {
                prRdKmast = rdkresult;
            }


            /////////////////////////////////////////////////////////////////////////////////////

            InitializeCommonProperty();
            InitializeDataSourceLion();
            InitializeControlLion();

            // 初期表示を検索ボタン押下後の状態とする.
            // （検索ボタンのクリックイベントを発生させる）.
            btnSch.PerformClick();

            //ローディング表示終了.
            base.CloseLoadingDialog();

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
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
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);
            int rowDetailIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;
            // 明細入力画面表示.
            //KKHNaviを継承したパラメータクラス.
            DetailInputLionNaviParameter naviParam = new DetailInputLionNaviParameter();
            //シート、表示区分等.
            naviParam.DataRow = dataRow;//受注データ.
            naviParam.RowDetailIndex = rowDetailIndex;//受注シート選択row
            naviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1; //明細シート.
            naviParam.pStrTypePtan = pKmkType;//パターン（１～８）.

            //受注データの[業務区分]を取得.
            string gyomKbn = _spdJyutyuList_Sheet1.Cells[_spdJyutyuList_Sheet1.ActiveRowIndex, COLIDX_JLIST_GYOMKBN].Value.ToString();
            //[業務区分]が[テレビスポット]の場合.
            if (gyomKbn.Equals(KKHLionConst.COLSTR_GYOM_SPOT))
            {
                //媒体コードにテレビスポットを設定.
                pBaitaiCd = KKHLionConst.BAITAIKBN_TV_SPOT;
            }
            naviParam.pBaitaiCd = pBaitaiCd;

            //カードＮＯ存在時.
            naviParam.pMeiCardNo = pMeiCardNo;

            //基本情報.
            naviParam.strEsqId = _naviParameter.strEsqId;
            naviParam.strEgcd = _naviParameter.strEgcd;
            naviParam.strTksKgyCd = _naviParameter.strTksKgyCd;
            naviParam.strTksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            naviParam.strTksTntSeqNo = _naviParameter.strTksTntSeqNo;
            naviParam.StrYymm = _naviParameter.StrYymm;
            naviParam.strName = _naviParameter.strName;
            //マスタ渡し.
            //TV
            naviParam.prTvBmast = prTvBngmast;
            naviParam.prTvKmast = prTvKmast;
            naviParam.prTvRmast = prTvRmast;
            //RD
            naviParam.prRdBmast = prRdBngmast;
            naviParam.prRdKmast = prRdKmast;
            naviParam.prRdRmast = prRdRmast;
            //汎用マスタ系.
            naviParam.DtTvHenMast = readMastDB.FindMasterData(_naviParameter.strEsqId,
                                                              _naviParameter.strEgcd,
                                                              _naviParameter.strTksKgyCd,
                                                              _naviParameter.strTksBmnSeqNo,
                                                              _naviParameter.strTksTntSeqNo,
                                                              KKHLionConst.C_MAST_TV_HEN_CD,
                                                              false);
            naviParam.DtRdHenMast = readMastDB.FindMasterData(_naviParameter.strEsqId,
                                                              _naviParameter.strEgcd,
                                                              _naviParameter.strTksKgyCd,
                                                              _naviParameter.strTksBmnSeqNo,
                                                              _naviParameter.strTksTntSeqNo,
                                                              KKHLionConst.C_MAST_RADIO_HEN_CD,
                                                              false);

            //object result = Navigator.ShowModalFormByName(this, "DetailInputLion", naviParam);
            object result = Navigator.ShowModalForm(this, "toDetailInputLion", naviParam);
            if (result == null)
            {
                //コントロールを未選択状態にする.
                this.ActiveControl = null;

                return;
            }
            base.kkhDetailUpdFlag = true; //広告費明細変更フラグを更新.


            //Utilityクラスのインスタンス生成.
            KKHLionDetailCreate utl = new KKHLionDetailCreate();
            string ptncd = "";
            //明細データが存在しない.
            if (_spdKkhDetail_Sheet1.RowCount == 0)
            {
                //媒体区分で項目を設定.
                ptncd = utl.CardNoAndBaitaiKbnKmkCheck(KKHLionConst.COLSTR_BTPATARN, dataRow.hb1GyomKbn,dataRow.hb1SeiKbn);
                InitializeDesignForSpdKkhDetail(ptncd, KKHLionConst.BAITAIKBN_TV_SPOT);//スポットは全て０２（テレビ）.
                //ボタン制御.
                btnDetailInput.Enabled = true;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = true;
                //パターンをINPUT用変数へ.
                //項目タイプ.
                pKmkType = ptncd;
                //媒体CD.
                pBaitaiCd = "";
                //★いる？.
                //pBaitaiCd = KKHLionConst.BAITAIKBN_TV_SPOT;
            }
            //明細データが存在する.
            else
            {
                //カードNOで項目を設定.
                ptncd = utl.CardNoAndBaitaiKbnKmkCheck(KKHLionConst.COLSTR_CDPATARN, _spdKkhDetail_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_CARDNO].Text, _spdKkhDetail_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_SEIKYUNO].Text);

                InitializeDesignForSpdKkhDetail(ptncd, _spdKkhDetail_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_BAITAI].Text);
                //パターンをINPUT用変数へ.
                //項目タイプ.
                pKmkType = ptncd;

                //媒体CD.
                pBaitaiCd = _spdKkhDetail_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_BAITAI].Text;

                //カードNo
                pMeiCardNo = _spdKkhDetail_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_CARDNO].Text;

                // ボタン活性処理.
                btnDetailDel.Enabled = true;
            }

            // 差額計算.
            CalculateSagaku(dataRow);

            //取料金合計を計算.
            CalculateTriRokin(dataRow);

            //請求金額合計計算.
            CalculateSeikyu(dataRow);

            //電波料合計計算.
            CalculateDenpaRyo(dataRow);

            //本数・秒数をセット.
            SetHonsuByosu(dataRow);

            //コントロールを未選択状態にする.
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
            _spdKkhDetail_Sheet1.AddRows(rowDetailIndex, 1);
            // 選択行の内容を追加行に設定.
            for (int i = 0; i < _spdKkhDetail_Sheet1.ColumnCount; i++)
            {
                _spdKkhDetail_Sheet1.Cells[rowDetailIndex, i].Value = _spdKkhDetail_Sheet1.Cells[rowDetailIndex + 1, i].Text;
            }
            _spdKkhDetail_Sheet1.ActiveRowIndex = rowDetailIndex + 1;
            _spdKkhDetail_Sheet1.AddSelection(_spdKkhDetail_Sheet1.ActiveRowIndex, -1, 1, -1);
            // 明細入力画面表示.
            KKHNaviParameter naviParam = new KKHNaviParameter();
            naviParam.DataRow = dataRow;
            naviParam.RowDetailIndex = rowDetailIndex + 1;
            naviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1;
            object result = Navigator.ShowModalFormByName(this, "DetailInputLion", naviParam);
            if (result == null)
            {
                _spdKkhDetail_Sheet1.RemoveRows(rowDetailIndex, 1);
                _spdKkhDetail_Sheet1.ActiveRowIndex = rowDetailIndex;
                _spdKkhDetail_Sheet1.AddSelection(_spdKkhDetail_Sheet1.ActiveRowIndex, -1, 1, -1);
                this.ActiveControl = null;
                return;
            }
            base.kkhDetailUpdFlag = true; //広告費明細変更フラグを更新.

            // 差額計算.
            CalculateSagaku(dataRow);

            //取料金合計を計算.
            CalculateTriRokin(dataRow);

            //請求金額合計計算.
            CalculateSeikyu(dataRow);

            //電波料合計計算.
            CalculateDenpaRyo(dataRow);

            //本数・秒数をセット.
            SetHonsuByosu(dataRow);
        }

        /// <summary>
        /// 受注登録内容(一覧)の選択状態変更後イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdJyutyuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            RegistDetailData();

            //コントロールを未選択状態にする.
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

            btnBulkRegister_Click();

            //コントロールを未選択状態にする.
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
            _dsDetailLion.KkhDetail.AcceptChanges();//行の削除をデータに反映.
            base.kkhDetailUpdFlag = true; //広告費明細変更フラグを更新.

            //***************************************
            //ボタン類の使用可・不可設定.
            //***************************************
            if (_spdKkhDetail_Sheet1.Rows.Count > 0)
            {
                //広告費明細データが既にある場合は分割・削除は可.
                btnDetailDel.Enabled = true;
                //btnDivide.Enabled = true;
            }
            else
            {
                //広告費明細データがない場合は分割・削除は不可.
                btnDetailDel.Enabled = false;
                //btnDivide.Enabled = false;
            }

            //******************************
            //差額・計ラベル.
            //******************************
            //受注登録内容の選択行情報の取得.
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);
            //差額計算.
            CalculateSagaku(dataRow);
            //取料金合計.
            CalculateTriRokin(dataRow);
            //請求金額合計計算.
            CalculateSeikyu(dataRow);
            //電波料合計計算.
            CalculateDenpaRyo(dataRow);
            //本数・秒数をセット.
            SetHonsuByosu(dataRow);

            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(_spdKkhDetail_Sheet1.ActiveRowIndex, -1, 1, -1);
            }

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }

        /// <summary>
        /// 件名変更ボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubjectUpdate_Click(object sender, EventArgs e)
        {
            //明細の編集状況確認.
            if (ConfirmEditStatus() == false)
            {
                return;
            }

            //選択行調査用変数.
            ArrayList selnum = new ArrayList();

            //シートの件数分ループ.
            for (int i = 0; i < _spdJyutyuList_Sheet1.RowCount; i++)
            {
                //行が選択されているか調べる.
                if (_spdJyutyuList_Sheet1.IsSelected(i, 0))
                {
                    selnum.Add(i);
                }
            }

            //明細登録済みの場合.
            //if (_spdKkhDetail_Sheet1.RowCount > 0)
            //{
            //    //変更不可 "明細登録済みなので件名変更できません。"
            //    MessageUtility.ShowMessageBox(MessageCode.HB_E0003, null, "明細登録", MessageBoxButtons.OK);
            //    return;
            //}
            if (_spdJyutyuList_Sheet1.Cells[_spdJyutyuList_Sheet1.ActiveRowIndex, COLIDX_JLIST_TOROKU].Text != "")
            {
                //"明細登録済みなので件名変更できません。"
                MessageUtility.ShowMessageBox(MessageCode.HB_W0141, null, "明細登録", MessageBoxButtons.OK);
                this.ActiveControl = null;
                return;
            }

            //受注データをセット.
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] dataRow
                = new Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[selnum.Count];

            for (int i = 0; i < selnum.Count; i++)
            {
                dataRow[i] = getSelectJyutyuData(int.Parse(selnum[i].ToString()));
            }

            // 件名変更画面表示.
            //パラメータセット.
            DetailUpdateSubjectNaviParameter naviParam = new DetailUpdateSubjectNaviParameter();
            naviParam.strEsqId = _naviParameter.strEsqId;
            naviParam.strEgcd = _naviParameter.strEgcd;
            naviParam.strTksKgyCd = _naviParameter.strTksKgyCd;
            naviParam.strTksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            naviParam.strTksTntSeqNo = _naviParameter.strTksTntSeqNo;
            naviParam.StrYymm = _naviParameter.StrYymm;
            naviParam.strName = _naviParameter.strName;
            naviParam.DataRow = dataRow;
            object result = Navigator.ShowModalForm(this, "toDetailUpdateSubject", naviParam);
            if (result == null)
            {
                this.ActiveControl = null;
                return;
            }

            SearchJyutyuData(true);//受注登録内容再検索・表示.

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }


        /// <summary>
        /// カードNO一覧ボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            object result = Navigator.ShowModalFormByName(this, "FindLionCardNoItr", _naviParameter);
            if (result == null)
            {
                this.ActiveControl = null;
                return;
            }
        }

        /// <summary>
        /// 一括ボタンクリック.
        /// </summary>
        private void btnBulkRegister_Click()
        {
            //**********************************
            //登録対象データ存在チェック(＋抽出).
            //**********************************
            List<Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow> dataRowList = new List<Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow>();
            CellRange[] cellRangeArray = SortCellRangesByRowIdx(_spdJyutyuList_Sheet1.GetSelections());
            foreach (CellRange cellRange in cellRangeArray)
            {
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    //選択されている受注登録内容の行数分の処理を繰り返す.
                    int rowIndex = cellRange.Row + i;
                    Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(rowIndex);
                    if (CheckBulkRegTarget(dataRow))
                    {
                        dataRowList.Add(dataRow);
                    }
                }
            }

            //登録対象データが無い場合.
            if (dataRowList.Count == 0)
            {
                //"該当するデータがありません"
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "一括登録", MessageBoxButtons.OK);
                this.ActiveControl = null;
                //登録対象データが存在しない場合は処理終了.
                return;
            }

            //**********************************
            //子画面呼び出し.
            //**********************************
            DetailLionBulkRegisterNaviParameter naviParameterIn = new DetailLionBulkRegisterNaviParameter(_naviParameter);
            object outParameter = Navigator.ShowModalForm(this, "toDetailLionBulkRegister", naviParameterIn);
            if (outParameter == null || !(outParameter is DetailLionBulkRegisterNaviParameter))
            {
                this.ActiveControl = null;
                return;
            }
            DetailLionBulkRegisterNaviParameter naviParameterOut = (DetailLionBulkRegisterNaviParameter)outParameter;
            if (KKHUtility.IsBlank(naviParameterOut.BrandCd) == true)
            {
                this.ActiveControl = null;
                return;
            }


            //**********************************
            //登録データ編集.
            //**********************************
            //サービスパラメータ用変数.
            List<Isid.KKH.Common.KKHSchema.Detail> dsDetailList = new List<Isid.KKH.Common.KKHSchema.Detail>();
            DateTime maxUpdDate = DateTime.MinValue;

            foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow jyutyuDataRow in dataRowList)
            {
                Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();
                //*********************************************
                //THB1DOWNの更新データ編集.
                //*********************************************
                Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtDown = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();
                Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtDown.NewTHB1DOWNRow();

                //更新条件項目.
                thb1DownRow.hb1EgCd = _naviParameter.strEgcd;                      //営業所（取）コード.
                thb1DownRow.hb1TksKgyCd = _naviParameter.strTksKgyCd;              //得意先企業コード.
                thb1DownRow.hb1TksBmnSeqNo = _naviParameter.strTksBmnSeqNo;        //得意先部門SEQNO
                thb1DownRow.hb1TksTntSeqNo = _naviParameter.strTksTntSeqNo;        //得意先担当SEQNO
                thb1DownRow.hb1Yymm = jyutyuDataRow.hb1Yymm;                       //年月.
                thb1DownRow.hb1TouFlg = jyutyuDataRow.hb1TouFlg;                   //統合フラグ.
                thb1DownRow.hb1JyutNo = jyutyuDataRow.hb1JyutNo;                   //受注No
                thb1DownRow.hb1JyMeiNo = jyutyuDataRow.hb1JyMeiNo;                 //受注明細No
                thb1DownRow.hb1UrMeiNo = jyutyuDataRow.hb1UrMeiNo;                 //売上明細No
                //更新項目.
                thb1DownRow.hb1UpdApl = AplId;                                     //更新プログラム.
                thb1DownRow.hb1UpdTnt = _naviParameter.strEsqId;                   //更新担当者.
                thb1DownRow.hb1MSeiFlg = "0";                                      //未請求フラグ.
                thb1DownRow.hb1MeisaiFlg = "1";                                    //明細フラグ.

                //登録担当者が空かつ更新者が空でない場合.
                if (string.IsNullOrEmpty(jyutyuDataRow.hb1TrkTntNm.Trim()) && !string.IsNullOrEmpty(jyutyuDataRow.hb1KsnTntNm.Trim()))
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
                else if (string.IsNullOrEmpty(jyutyuDataRow.hb1TrkTntNm.Trim()))
                {
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


                dtDown.AddTHB1DOWNRow(thb1DownRow);

                dsDetail.THB1DOWN.Merge(dtDown);

                //*********************************************
                //THB2KMEIの登録データ編集.
                //*********************************************
                Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable dtThb2Kmei = new Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable();
                Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow addRow = dtThb2Kmei.NewTHB2KMEIRow();

                addRow.hb2TimStmp = new DateTime();                                                 //タイムスタンプ.
                addRow.hb2UpdApl = AplId;                                                           //更新プログラム.
                addRow.hb2UpdTnt = _naviParameter.strEsqId;                                         //更新担当者.
                addRow.hb2EgCd = _naviParameter.strEgcd;                                            //営業所コード.
                addRow.hb2TksKgyCd = _naviParameter.strTksKgyCd;                                    //得意先企業コード.
                addRow.hb2TksBmnSeqNo = _naviParameter.strTksBmnSeqNo;                              //得意先部門SEQNO
                addRow.hb2TksTntSeqNo = _naviParameter.strTksTntSeqNo;                              //得意先担当SEQNO
                addRow.hb2Yymm = jyutyuDataRow.hb1Yymm;                                             //年月.
                addRow.hb2JyutNo = jyutyuDataRow.hb1JyutNo;                                         //受注No
                addRow.hb2JyMeiNo = jyutyuDataRow.hb1JyMeiNo;                                       //受注明細No
                addRow.hb2UrMeiNo = jyutyuDataRow.hb1UrMeiNo;                                       //売上明細No
                addRow.hb2HimkCd = jyutyuDataRow.hb1HimkCd.Trim();                                  //費目コード.
                //addRow.hb2Renbn = "001";                                                            //連番 明細登録件数拡張対応.
                addRow.hb2Renbn = "0001";                                                           //連番.
                addRow.hb2DateFrom = " ";                                                           //年月日From
                addRow.hb2DateTo = " ";                                                             //年月日To
                addRow.hb2SeiGak = jyutyuDataRow.hb1SeiGak;                                         //請求金額.
                addRow.hb2Hnnert = jyutyuDataRow.hb1NeviRitu;                                       //変更値引率.
                addRow.hb2HnmaeGak = 0M;                                                            //値引率変更前金額.
                addRow.hb2NebiGak = jyutyuDataRow.hb1NeviGak;                                       //値引額.
                addRow.hb2Date1 = " ";                                                              //日付1
                addRow.hb2Date2 = " ";                                                              //日付2
                addRow.hb2Date3 = " ";                                                              //日付3
                addRow.hb2Date4 = " ";                                                              //日付4
                addRow.hb2Date5 = " ";                                                              //日付5
                addRow.hb2Date6 = " ";                                                              //日付6
                addRow.hb2Kbn1 = " ";                                                               //区分1
                addRow.hb2Kbn2 = " ";                                                               //区分2
                addRow.hb2Kbn3 = " ";                                                               //区分3
                if (jyutyuDataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.TVSpot)
                {
                    addRow.hb2Code1 = KKHLionConst.BAITAIKBN_TV_SPOT;                             //コード1(=媒体区分)
                }
                else if (jyutyuDataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio)
                {
                    addRow.hb2Code1 = KKHLionConst.BAITAIKBN_RD_SPOT;                          //コード1(=媒体区分)
                }
                else
                {
                    addRow.hb2Code1 = " ";                                                          //コード1(=媒体区分)
                }
                addRow.hb2Code2 = GetLionCd(jyutyuDataRow);                                         //コード2(=局誌CDのライオンCD変換後)
                addRow.hb2Code3 = naviParameterOut.BrandCd;                                         //コード3(=ブランドCD)
                addRow.hb2Code4 = "1001";                                                           //コード4(=代理店CD)
                addRow.hb2Code5 = " ";                                                              //コード5(=番組CD)
                addRow.hb2Code6 = "005";                                                            //コード6(=カードNo)
                addRow.hb2Name1 = jyutyuDataRow.hb1SzeiGak.ToString("###0");                        //名称1(漢字)(=消費税額)
                addRow.hb2Name2 = " ";                                                              //名称2(漢字)(=スペースCD)
                addRow.hb2Name3 = " ";                                                              //名称3(漢字)(=請求書番号)
                addRow.hb2Name4 = "0";                                                              //名称4(漢字)(=実施料・宣伝費)
                addRow.hb2Name5 = " ";                                                              //名称5(漢字)(=掲載日・号・・・等)
                addRow.hb2Name6 = " ";                                                              //名称6(漢字)(=路線名)
                addRow.hb2Name7 = jyutyuDataRow.hb1Field4.Trim();                                   //名称7(漢字)(=期間)
                addRow.hb2Name8 = " ";                                                              //名称8(漢字)(=備考)
                addRow.hb2Name9 = " ";                                                              //名称9(漢字)
                addRow.hb2Name10 = jyutyuDataRow.hb1KKNameKJ.Trim();                                //名称10(漢字)(=件名)
                addRow.hb2Name11 = " ";                                                             //名称11(漢字)
                addRow.hb2Name12 = " ";                                                             //名称12(漢字)
                addRow.hb2Name13 = " ";                                                             //名称13(漢字)
                addRow.hb2Name14 = " ";                                                             //名称14(漢字)
                addRow.hb2Name15 = " ";                                                             //名称15(漢字)
                addRow.hb2Name16 = " ";                                                             //名称16(漢字)
                addRow.hb2Name17 = " ";                                                             //名称17(漢字)
                addRow.hb2Name18 = " ";                                                             //名称18(漢字)
                addRow.hb2Name19 = " ";                                                             //名称19(漢字)
                addRow.hb2Name20 = " ";                                                             //名称20(漢字)
                addRow.hb2Name21 = " ";                                                             //名称21(漢字)
                addRow.hb2Name22 = " ";                                                             //名称22(漢字)
                addRow.hb2Name23 = " ";                                                             //名称23(漢字)
                addRow.hb2Name24 = " ";                                                             //名称24(漢字)
                addRow.hb2Name25 = " ";                                                             //名称25(漢字)
                addRow.hb2Name26 = " ";                                                             //名称26(漢字)
                addRow.hb2Name27 = " ";                                                             //名称27(漢字)
                addRow.hb2Name28 = " ";                                                             //名称28(漢字)
                addRow.hb2Name29 = " ";                                                             //名称29(漢字)
                addRow.hb2Name30 = " ";                                                             //名称30(漢字)
                if (jyutyuDataRow.hb1HimkCd == KKHLionConst.C_HIMOKUCD_DENPA)
                {
                    addRow.hb2Kngk1 = jyutyuDataRow.hb1ToriGak;                                     //金額1(=電波料)
                }
                else
                {
                    addRow.hb2Kngk1 = 0M;
                }
                addRow.hb2Kngk2 = 0M;                                                               //金額2(=ネット料)
                if (jyutyuDataRow.hb1HimkCd == KKHLionConst.C_HIMOKUCD_KYOKU_SEISAKU)
                {
                    addRow.hb2Kngk3 = jyutyuDataRow.hb1ToriGak;                                     //金額3(=製作費)
                }
                else
                {
                    addRow.hb2Kngk3 = 0M;
                }
                addRow.hb2Ritu1 = jyutyuDataRow.hb1SzeiRitu;                                        //比率1(=消費税率)
                addRow.hb2Ritu2 = 0M;                                                               //比率2
                addRow.hb2Sonota1 = " ";                                                            //その他1
                addRow.hb2Sonota2 = " ";                                                            //その他2
                addRow.hb2Sonota3 = " ";                                                            //その他3
                addRow.hb2Sonota4 = " ";                                                            //その他4
                addRow.hb2Sonota5 = KKHUtility.IntParse(jyutyuDataRow.hb1Field6).ToString();        //その他5
                addRow.hb2Sonota6 = "0";                                                            //その他6
                addRow.hb2Sonota7 = jyutyuDataRow.hb1Field5.Trim();                                 //その他7(=本数)
                addRow.hb2Sonota8 = jyutyuDataRow.hb1Field6.Trim();                                 //その他8(=総秒数)
                addRow.hb2Sonota9 = "03";                                                           //その他9(=秒数)
                addRow.hb2Sonota10 = " ";                                                           //その他10(=FD用表示順序)
                addRow.hb2BunFlg = " ";                                                             //分割フラグ.
                addRow.hb2MeihnFlg = " ";                                                           //件名変更フラグ.
                addRow.hb2NebhnFlg = " ";                                                           //値引率変更フラグ.

                dtThb2Kmei.AddTHB2KMEIRow(addRow);
                dsDetail.THB2KMEI.Merge(dtThb2Kmei);

                dsDetailList.Add(dsDetail);

                //***************************
                //更新日付最大値の判定.
                //***************************
                //統合されている場合.
                if (jyutyuDataRow.hb1TouFlg == "1")
                {
                    //統合されている受注登録内容のデータから更新日付の最大値を取得する。.
                    Isid.KKH.Common.KKHUtility.KKHGetMaxUpdDateByTogo getMaxUpdDateByTogo = new KKHGetMaxUpdDateByTogo();
                    maxUpdDate = getMaxUpdDateByTogo.GetMaxUpdDateByTogo(
                                _spdJyutyuList_Sheet1,
                                jyutyuDataRow.hb1TimStmp,
                                _dsDetail);
                }
                else
                {
                    if (maxUpdDate == null || maxUpdDate.CompareTo(jyutyuDataRow.hb1TimStmp) < 0)
                    {
                        maxUpdDate = jyutyuDataRow.hb1TimStmp;
                    }
                }
            }

            //**********************************************
            //明細登録API実行.
            //**********************************************
            DetailProcessController.BulkUpdateDetailDataParam param = new DetailProcessController.BulkUpdateDetailDataParam();
            param.esqId = _naviParameter.strEsqId;
            param.dsDetailList = dsDetailList;
            param.maxUpdDate = maxUpdDate;
            DetailProcessController processController = DetailProcessController.GetInstance();
            BulkUpdateDetailDataServiceResult result = processController.BulkUpdateDetailData(param);

            if (result.HasError)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_E0003, null, "明細登録", MessageBoxButtons.OK);
                this.ActiveControl = null;

                return;
            }

            MessageUtility.ShowMessageBox(MessageCode.HB_I0012, null, "明細登録", MessageBoxButtons.OK);

            //受注内容再検索処理.
            base.ReSearchJyutyuData();

            //アクティブ行の設定.
            if (_spdJyutyuList_Sheet1.RowCount >= cellRangeArray[0].Row)
            {
                _spdJyutyuList_Sheet1.SetActiveCell(cellRangeArray[0].Row, 0, true);
                _spdJyutyuList_Sheet1.AddSelection(cellRangeArray[0].Row, -1, 1, -1);
                spdJyutyuList.ShowActiveCell(VerticalPosition.Nearest, HorizontalPosition.Nearest);
            }
            else
            {
                _spdJyutyuList_Sheet1.SetActiveCell(0, 0, true);
                _spdJyutyuList_Sheet1.AddSelection(0, -1, 1, -1);
                spdJyutyuList.ShowActiveCell(VerticalPosition.Nearest, HorizontalPosition.Nearest);
            }

            //******************************
            //広告費明細.
            //******************************
            //現在行の明細レコードを表示する.
            DisplayKkhDetail(_spdJyutyuList_Sheet1.ActiveRowIndex);

        }

        /// <summary>
        /// ヘルプボタンクリック処理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //HlpClick();
            //KKHHelpLion.ShowHelpLion(this, this.Name);
            string tkskgy = _naviParameter.strTksKgyCd + _naviParameter.strTksBmnSeqNo + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行.
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Detail, this, HelpNavigator.KeywordIndex);
        }

        /// <summary>
        /// 明細No統合ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMergeByJyutyuNo_Click(object sender, EventArgs e)
        {
            //*************************
            //広告費明細の編集状況確認.
            //*************************
            if (ConfirmEditStatus() == false)
            {
                this.ActiveControl = null;
                return;
            }

            //実行確認.
            if (DialogResult.OK != MessageUtility.ShowMessageBox(MessageCode.HB_C0019,
                null, "明細No統合", MessageBoxButtons.OKCancel))
            {
                this.ActiveControl = null;
                return;
            }

            btnMergeByJyutyuNo_Click();

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }

        /// <summary>
        /// テレビタイム統合ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTVTimeMergeByJyutyuNo_Click(object sender, EventArgs e)
        {
            //*************************
            //広告費明細の編集状況確認.
            //*************************
            if (ConfirmEditStatus() == false)
            {
                this.ActiveControl = null;
                return;
            }

            //実行確認.
            if (DialogResult.OK != MessageUtility.ShowMessageBox(MessageCode.HB_C0020,
                null, "テレビタイム統合", MessageBoxButtons.OKCancel))
            {
                this.ActiveControl = null;
                return;
            }


            btnTVTimeMergeByJyutyuNo_Click();

            //コントロールを未選択状態にする.
            this.ActiveControl = null;
        }

        #endregion イベント.

        # region メソッド.

        /// <summary>
        /// 差額計算.
        /// </summary>
        private void CalculateSagaku(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            // 料金合計.
            decimal ryoukinGoukei = 0;

            // 明細の件数分、繰り返す.
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                String ryoukinStr = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Text.Trim();
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
        /// 取料金合計を計算.
        /// </summary>
        private void CalculateTriRokin(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            // 取料金合計.
            decimal triRyokin = 0;
            String triryokinStr = "";
            String netryokinStr = "";
            String seisakuStr = "";
            // 明細の件数分、繰り返す.
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                switch (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_CARDNO].Text.Trim())
                {
                    //カードNo.がテレビタイム、ラジオタイム、BS・CS、スポットの場合.
                    case KKHLionConst.COLSTR_CARDNO_TVNET:
                    case KKHLionConst.COLSTR_CARDNO_TVLCL:
                    case KKHLionConst.COLSTR_CARDNO_RDNET:
                    case KKHLionConst.COLSTR_CARDNO_RDLCL:
                    case KKHLionConst.COLSTR_CARDNO_BSCS:
                    case KKHLionConst.COLSTR_CARDNO_SPOT:
                        triryokinStr = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_JISIDENPA].Text.Trim();
                        break;
                    //上記以外の場合.
                    default:
                        triryokinStr = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_INT1].Text.Trim();
                        break;
                }
                switch (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_CARDNO].Text.Trim())
                {
                    //カードNo.がテレビタイム、ラジオタイム、BS・CSの場合.
                    case KKHLionConst.COLSTR_CARDNO_TVNET:
                    case KKHLionConst.COLSTR_CARDNO_TVLCL:
                    case KKHLionConst.COLSTR_CARDNO_RDNET:
                    case KKHLionConst.COLSTR_CARDNO_RDLCL:
                    case KKHLionConst.COLSTR_CARDNO_BSCS:
                        netryokinStr = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_NETRYO].Text.Trim();
                        break;
                    //上記以外の場合.
                    default:
                        break;
                }
                switch (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_CARDNO].Text.Trim())
                {
                    //カードNo.がテレビタイム、ラジオタイム、BS・CS、雑誌の場合.
                    case KKHLionConst.COLSTR_CARDNO_TVNET:
                    case KKHLionConst.COLSTR_CARDNO_TVLCL:
                    case KKHLionConst.COLSTR_CARDNO_RDNET:
                    case KKHLionConst.COLSTR_CARDNO_RDLCL:
                    case KKHLionConst.COLSTR_CARDNO_BSCS:
                    case KKHLionConst.COLSTR_CARDNO_ZASSI:
                        seisakuStr = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_INT2].Text.Trim();
                        break;
                    //上記以外の場合.
                    default:
                        break;
                }
                // 明細の料金が入力されている場合.
                if (KKHUtility.IsNumeric(triryokinStr))
                {
                    // 取料金合計に加算.
                    triRyokin = triRyokin + decimal.Parse(triryokinStr.Trim());
                }
                // 明細の料金が入力されている場合.
                if (KKHUtility.IsNumeric(netryokinStr))
                {
                    // 取料金合計に加算.
                    triRyokin = triRyokin + decimal.Parse(netryokinStr.Trim());
                }
                // 明細の料金が入力されている場合.
                if (KKHUtility.IsNumeric(seisakuStr))
                {
                    // 取料金合計に加算.
                    triRyokin = triRyokin + decimal.Parse(seisakuStr.Trim());
                }
            }
            // 取料金合計.
            lblToriRyokinValue.Text = triRyokin.ToString("###,###,###,##0");
        }

        /// <summary>
        /// 請求金額合計を計算.
        /// </summary>
        private void CalculateSeikyu(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            // 請求金額合計.
            decimal seikyuKingaku = 0;

            // 明細の件数分、繰り返す.
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                String seikyuStr = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Text.Trim();

                // 明細の料金が入力されている場合.
                if (KKHUtility.IsNumeric(seikyuStr))
                {
                    // 料金合計に加算.
                    seikyuKingaku = seikyuKingaku + decimal.Parse(seikyuStr.Trim());
                }
            }
            // 合計.
            lblSeikyuValue.Text = seikyuKingaku.ToString("###,###,###,##0");
        }

        /// <summary>
        /// 電波料を計算.
        /// </summary>
        private void CalculateDenpaRyo(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            // 電波料合計.
            decimal denpaRyo = 0;
            String denpaStr = "";
            // 明細の件数分、繰り返す.
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                switch (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_CARDNO].Text.Trim())
                {
                    //カードNo.がテレビタイム、ラジオタイム、BS・CS、スポットの場合.
                    case KKHLionConst.COLSTR_CARDNO_TVNET:
                    case KKHLionConst.COLSTR_CARDNO_TVLCL:
                    case KKHLionConst.COLSTR_CARDNO_RDNET:
                    case KKHLionConst.COLSTR_CARDNO_RDLCL:
                    case KKHLionConst.COLSTR_CARDNO_BSCS:
                    case KKHLionConst.COLSTR_CARDNO_SPOT:
                        denpaStr = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_JISIDENPA].Text.Trim();
                        break;
                    //上記以外の場合.
                    default:
                        break;
                }
                // 明細の料金が入力されている場合.
                if (KKHUtility.IsNumeric(denpaStr))
                {
                    // 電波料合計に加算.
                    denpaRyo = denpaRyo + decimal.Parse(denpaStr.Trim());
                }
            }
            // 電波料合計.
            lblDenpaValue.Text = denpaRyo.ToString("###,###,###,##0");
        }

        /// <summary>
        /// 本数・秒数をセット.
        /// </summary>
        private void SetHonsuByosu(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            // 本数.
            String honsu = "";
            // 秒数.
            String byosu = "";
            //明細がある場合.
            if ( _spdKkhDetail_Sheet1.RowCount > 0 )
            {
                switch (_spdKkhDetail_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_CARDNO].Text.Trim())
                {
                    //カードNo.がテレビタイム、ラジオタイム、BS・CSの場合.
                    case KKHLionConst.COLSTR_CARDNO_TVNET:
                    case KKHLionConst.COLSTR_CARDNO_TVLCL:
                    case KKHLionConst.COLSTR_CARDNO_RDNET:
                    case KKHLionConst.COLSTR_CARDNO_RDLCL:
                    case KKHLionConst.COLSTR_CARDNO_BSCS:
                        // 明細の1行目の本数、秒数を取得.
                        honsu = _spdKkhDetail_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_HONSU].Text.Trim();
                        byosu = _spdKkhDetail_Sheet1.Cells[0, KKHLionConst.COLIDX_MLIST_BYOSU].Text.Trim();
                        break;
                    // 上記以外の場合.
                    default:
                        break;
                }
            }
            // 本数をセット.
            lblHonsuValue.Text = honsu;
            // 秒数をセット.
            lblByosuValue.Text = byosu;
        }

        /// <summary>
        /// 広告費明細のデータソース更新.
        /// </summary>
        /// <param name="dsDetailLion"></param>
        private void UpdateDataSourceByDetailDataSetLion(DetailDSLion dsDetailLion)
        {
            _dsDetailLion.Clear();
            _dsDetailLion.Merge(_dsDetailLion);
            _dsDetailLion.AcceptChanges();
        }

        /// <summary>
        /// データソースのバインド.
        /// </summary>
        private void InitializeDataSourceLion()
        {

        }

        /// <summary>
        /// 継承元フォームで使用しているプロパティ等の初期値設定.
        /// </summary>
        private void InitializeCommonProperty()
        {
            ////広告費明細データを広告費明細詳細項目テーブル(TGA7MSHO)からを取得するか.
            //ExistsGA7MSHO = false;//取得しない.
        }

        /// <summary>
        /// 各コントロールの初期設定.
        /// </summary>
        private void InitializeControlLion()
        {
            //******************
            //検索条件部.
            //******************
            //件名検索機能を用いる場合(2013/02/01追加 JSE A.Naito)
            lblKenMei.Visible = true;
            txtKenMei.Visible = true;
            lblKikan.Visible = false;
            txtYmdTo.Visible = false;

            //*******************
            //ボタン類.
            //*******************
            btnDetailInput.Enabled = false;
            btnDetailDel.Enabled = false;
            btnDetailRegister.Enabled = false;
            btnBulkRegister.Visible = false;
            btnBulkRegister.Enabled = false;
            btnSubjectUpdate.Enabled = false;
            btnMergeByJyutyuNo.Enabled = false;
            btnTVTimeMergeByJyutyuNo.Enabled = false;
        }

        /// <summary>
        /// 広告費明細スプレッドのデザイン初期化を行う.
        /// </summary>
        /// <param name="kmkptn"></param>
        /// <param name="tvorrd"></param>
        private void InitializeDesignForSpdKkhDetail(string kmkptn,string tvorrd)
        {
            //********************************
            //スプレッド全体の設定.
            //********************************
            _spdKkhDetail_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;//単一選択.
            _spdKkhDetail_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;       //行単位選択.
            _spdKkhDetail_Sheet1.OperationMode = OperationMode.SingleSelect;                        //
            _spdKkhDetail_Sheet1.RowHeaderVisible = true;                                           //行ヘッダ表示.
            _spdKkhDetail_Sheet1.RowHeaderAutoText = HeaderAutoText.Numbers;                        //行ヘッダに行番号を表示.
            _spdKkhDetail_Sheet1.RowHeader.Columns[-1].Width = 50;                                  //行ヘッダのサイズ.

            //基本をセット.
            _spdKkhDetail_Sheet1.ColumnCount = KKHLionConst.COLIDX_MLIST_COUNT;

            //Utilityクラスのインスタンス生成.
            KKHLionDetailCreate utl = new KKHLionDetailCreate();

            //スプレッドのレイアウト描画中止.
            spdKkhDetail.SuspendLayout();

            //スプレッドの項目の設定.
            utl.sheetset("trk", _spdKkhDetail_Sheet1);

            //
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(0, 0, 1, 1);
            }

            //項目設定（上記で取得したパターンで設定する）.
            utl.kmkset(kmkptn, tvorrd, _spdKkhDetail_Sheet1);

            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(0, 0, 1, 1);
            }

            //レイアウトロジック再開.
            spdKkhDetail.ResumeLayout(true);
        }

        /// <summary>
        /// 受注登録内容検索後の各コントロールの活性／非活性設定.
        /// </summary>
        private void EnableChangeForAfterSearch()
        {
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow jyutyuDataRow = getSelectJyutyuData(-1);
            //if (CheckBulkRegTarget(jyutyuDataRow) == true)
            //請求区分がスポット、かつテレビ、またはラジオ、または衛星の場合.
            if (jyutyuDataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Spot
                && (jyutyuDataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio
                || jyutyuDataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.TVSpot
                || jyutyuDataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.EiseiM)
                )
            {
                btnBulkRegister.Visible = true;
                btnBulkRegister.Enabled = true;
            }
            //請求区分が国際、かつ業務区分がテレビスポットの場合.
            else if(jyutyuDataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.KMas
                && jyutyuDataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.TVSpot)
                //&& (jyutyuDataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio
                //|| jyutyuDataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.TVSpot))
            {
                btnBulkRegister.Visible = true;
                btnBulkRegister.Enabled = true;
            }
            else
            {
                btnBulkRegister.Visible = false;
                btnBulkRegister.Enabled = false;
            }
            btnMergeByJyutyuNo.Enabled = true;
            btnTVTimeMergeByJyutyuNo.Enabled = true;
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
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);

            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();

            // 明細登録担当者は更新前に明細がない場合のみ更新.
            if( dataRow.hb2JyutNo == "" )
            {
                thb1DownRow.hb1TrkApl = AplId;
                thb1DownRow.hb1TrkTnt = _naviParameter.strEsqId;
            }

            thb1DownRow.hb1UpdApl = AplId;
            thb1DownRow.hb1UpdTnt = _naviParameter.strEsqId;
            thb1DownRow.hb1EgCd = _naviParameter.strEgcd;
            thb1DownRow.hb1TksKgyCd = _naviParameter.strTksKgyCd;
            thb1DownRow.hb1TksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            thb1DownRow.hb1TksTntSeqNo = _naviParameter.strTksTntSeqNo;
            thb1DownRow.hb1Yymm = dataRow.hb1Yymm;
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


            thb1DownRow.hb1TouFlg = dataRow.hb1TouFlg;

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
                //登録者、更新者が空の場合.
                if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) && string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                    //何もしない.
                }
                //登録者がからで、更新者が入っている場合.
                else if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) && !string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                    //何もしない.
                }
                else
                {
                    //更新者を登録.
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
            }

            dtThb1Down.AddTHB1DOWNRow(thb1DownRow);

            dsDetail.THB1DOWN.Merge(dtThb1Down);

            Isid.KKH.Common.KKHSchema.Detail TouKoudsDetail = new Isid.KKH.Common.KKHSchema.Detail();
            //データが統合されている場合、子の元となったデータに登録担当者、更新者を登録する。.
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
            //受注選択行データ取得.
            int jyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow jyutyuDataRow = getSelectJyutyuData(jyutyuListRowIdx);

            //明細データ取得.
            Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable dtThb2Kmei = new Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable();
            //明細カウント分まわす.
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                object cellValue = null;

                Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow addRow = dtThb2Kmei.NewTHB2KMEIRow();


                //*********************************************
                //THB2KMEIの登録データ編集.
                //*********************************************
                addRow.hb2TimStmp = new DateTime();                                                 //タイムスタンプ.
                addRow.hb2UpdApl = AplId;                                                           //更新プログラム.
                addRow.hb2UpdTnt = _naviParameter.strEsqId;                                         //更新担当者.
                addRow.hb2EgCd = _naviParameter.strEgcd;                                            //営業所コード.
                addRow.hb2TksKgyCd = _naviParameter.strTksKgyCd;                                    //得意先企業コード.
                addRow.hb2TksBmnSeqNo = _naviParameter.strTksBmnSeqNo;                              //得意先部門SEQNO
                addRow.hb2TksTntSeqNo = _naviParameter.strTksTntSeqNo;                              //得意先担当SEQNO
                addRow.hb2Yymm = jyutyuDataRow.hb1Yymm;                                             //年月.
                addRow.hb2JyutNo = jyutyuDataRow.hb1JyutNo;                                         //受注No
                addRow.hb2JyMeiNo = jyutyuDataRow.hb1JyMeiNo;                                       //受注明細No
                addRow.hb2UrMeiNo = jyutyuDataRow.hb1UrMeiNo;                                       //売上明細No
                addRow.hb2HimkCd = jyutyuDataRow.hb1HimkCd.Trim();                                  //費目コード.
                //addRow.hb2Renbn = (i + 1).ToString("000");   明細登録件数拡張対応                 //連番.
                addRow.hb2Renbn = (i + 1).ToString("0000");                                         //連番.
                addRow.hb2DateFrom = " ";                                                           //年月日From
                addRow.hb2DateTo = " ";                                                             //年月日To
                //請求金額.
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Value != null)
                {
                    addRow.hb2SeiGak = decimal.Parse(_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_NBKGOKNGK].Value.ToString());
                }
                else
                {
                    addRow.hb2SeiGak = 0M;
                }
                //変更値引率.
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_NBKRITU].Value != null)
                {
                    addRow.hb2Hnnert = decimal.Parse(_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_NBKRITU].Value.ToString());
                }
                else
                {
                    addRow.hb2Hnnert = 0M;
                }
                addRow.hb2HnmaeGak = 0M;                                                            //値引率変更前金額.
                //値引額.
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value != null)
                {
                    addRow.hb2NebiGak = decimal.Parse(_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_NBKDENPARYO].Value.ToString());
                }
                else
                {
                    addRow.hb2NebiGak = 0M;
                }

                addRow.hb2Date1 = " ";                                                              //日付1
                addRow.hb2Date2 = " ";                                                              //日付2
                addRow.hb2Date3 = " ";                                                              //日付3
                addRow.hb2Date4 = " ";                                                              //日付4
                addRow.hb2Date5 = " ";                                                              //日付5
                addRow.hb2Date6 = " ";                                                              //日付6
                addRow.hb2Kbn1 = " ";                                                               //区分1
                addRow.hb2Kbn2 = " ";                                                               //区分2
                addRow.hb2Kbn3 = " ";                                                               //区分3
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BAITAI].Value != null)
                {
                    addRow.hb2Code1 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BAITAI].Value.ToString();
                }
                else
                {
                    addRow.hb2Code1 = " ";
                }

                //コード2(=局誌CD)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Value != null)
                {
                    addRow.hb2Code2 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_KYOKUSICD].Value.ToString();
                }
                else
                {
                    addRow.hb2Code2 = "";
                }
                //コード3(=ブランドCD)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BRANDCD].Value == null
                    || _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BRANDCD].Value.ToString().Trim() == ""
                    )
                {
                    addRow.hb2Code3 = "";
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BRANDCD].Value.ToString().Length >= 4)
                    {
                        addRow.hb2Code3 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BRANDCD].Value.ToString().Substring(0, 4);
                    }
                    else
                    {
                        addRow.hb2Code3 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BRANDCD].Value.ToString().Substring(0, _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BRANDCD].Value.ToString().Length);
                    }
                }
                //コード4(=代理店CD)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_DAIRITEN].Value != null)
                {
                    addRow.hb2Code4 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_DAIRITEN].Value.ToString();
                }
                else
                {
                    addRow.hb2Code4 = "";
                }
                //コード5(=番組CD)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BANGCD].Value != null)
                {
                    addRow.hb2Code5 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BANGCD].Value.ToString();
                }
                else
                {
                    addRow.hb2Code5 = "";
                }
                //コード6(=カードNo)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_CARDNO].Value != null)
                {
                    addRow.hb2Code6 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_CARDNO].Value.ToString();
                }
                else
                {
                    addRow.hb2Code6 = "";
                }
                //名称1(漢字)(=消費税額)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_TAX].Value != null)
                {
                    addRow.hb2Name1 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_TAX].Value.ToString();
                }
                else
                {
                    addRow.hb2Name1 = "";
                }
                //名称2(漢字)(=スペースCD)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_SPACE].Value != null)
                {
                    addRow.hb2Name2 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_SPACE].Value.ToString();
                }
                else
                {
                    addRow.hb2Name2 = "";
                }
                //名称3(漢字)(=請求書番号)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_SEIKYUNO].Value != null)
                {
                    addRow.hb2Name3 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_SEIKYUNO].Value.ToString();
                }
                else
                {
                    addRow.hb2Name3 = "";
                }
                //名称4(漢字)(=実施料・宣伝費)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_INT1].Value != null)
                {
                    addRow.hb2Name4 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_INT1].Value.ToString();
                }
                else
                {
                    addRow.hb2Name4 = "";
                }
                //名称5(漢字)(=掲載日・号・・・等)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_KEISAI].Value != null)
                {
                    addRow.hb2Name5 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_KEISAI].Value.ToString();
                }
                else
                {
                    addRow.hb2Name5 = "";
                }
                //名称6(漢字)(=路線名)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_ROSEN].Value != null)
                {
                    addRow.hb2Name6 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_ROSEN].Value.ToString();
                }
                else
                {
                    addRow.hb2Name6 = "";
                }
                //名称7(漢字)(=期間)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_KIKAN].Value != null)
                {
                    addRow.hb2Name7 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_KIKAN].Value.ToString();
                }
                else
                {
                    addRow.hb2Name7 = "";
                }
                //名称8(漢字)(=備考)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BIKO].Value != null)
                {
                    addRow.hb2Name8 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BIKO].Value.ToString();
                }
                else
                {
                    addRow.hb2Name8 = "";
                }
                addRow.hb2Name9 = " ";                                                              //名称9(漢字)
                //名称10(漢字)(=件名)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_KENMEI].Value != null)
                {
                    addRow.hb2Name10 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_KENMEI].Value.ToString();
                }
                else
                {
                    addRow.hb2Name10 = "";
                }
                addRow.hb2Name11 = " ";                                                             //名称11(漢字)
                addRow.hb2Name12 = " ";                                                             //名称12(漢字)
                addRow.hb2Name13 = " ";                                                             //名称13(漢字)
                addRow.hb2Name14 = " ";                                                             //名称14(漢字)
                addRow.hb2Name15 = " ";                                                             //名称15(漢字)
                addRow.hb2Name16 = " ";                                                             //名称16(漢字)
                addRow.hb2Name17 = " ";                                                             //名称17(漢字)
                addRow.hb2Name18 = " ";                                                             //名称18(漢字)
                addRow.hb2Name19 = " ";                                                             //名称19(漢字)
                addRow.hb2Name20 = " ";                                                             //名称20(漢字)
                addRow.hb2Name21 = " ";                                                             //名称21(漢字)
                addRow.hb2Name22 = " ";                                                             //名称22(漢字)
                addRow.hb2Name23 = " ";                                                             //名称23(漢字)
                addRow.hb2Name24 = " ";                                                             //名称24(漢字)
                addRow.hb2Name25 = " ";                                                             //名称25(漢字)
                addRow.hb2Name26 = " ";                                                             //名称26(漢字)
                addRow.hb2Name27 = " ";                                                             //名称27(漢字)
                addRow.hb2Name28 = " ";                                                             //名称28(漢字)
                addRow.hb2Name29 = " ";                                                             //名称29(漢字)
                addRow.hb2Name30 = " ";                                                             //名称30(漢字)
                //金額1(=電波料)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_JISIDENPA].Value != null)
                {
                    addRow.hb2Kngk1 = decimal.Parse(_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_JISIDENPA].Value.ToString());
                }
                else
                {
                    addRow.hb2Kngk1 = 0M;
                }
                //金額2(=ネット料)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_NETRYO].Value != null)
                {
                    addRow.hb2Kngk2 = decimal.Parse(_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_NETRYO].Value.ToString());
                }
                else
                {
                    addRow.hb2Kngk2 = 0M;
                }
                //金額3(=製作費)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_INT2].Value != null)
                {
                    addRow.hb2Kngk3 = decimal.Parse(_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_INT2].Value.ToString());
                }
                else
                {
                    addRow.hb2Kngk3 = 0M;
                }
                //比率1(=消費税率)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_TAXRITU].Value != null)
                {
                    addRow.hb2Ritu1 = decimal.Parse(_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_TAXRITU].Value.ToString());
                }
                else
                {
                    addRow.hb2Ritu1 = 0M;
                }
                addRow.hb2Ritu2 = 0M;                                                               //比率2

                //その他1(=休止回数)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_KYUSISU].Value != null)
                {
                    addRow.hb2Sonota1 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_KYUSISU].Value.ToString();
                }
                else
                {
                    addRow.hb2Sonota1 = "";
                }
                //その他2(=府県CD)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_FUKENCD].Value != null)
                {
                    addRow.hb2Sonota2 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_FUKENCD].Value.ToString();
                }
                else
                {
                    addRow.hb2Sonota2 = "";
                }
                //その他3(=NET-FC)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_NETFC].Value != null)
                {
                    addRow.hb2Sonota3 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_NETFC].Value.ToString();
                }
                else
                {
                    addRow.hb2Sonota3 = "";
                }
                addRow.hb2Sonota4 = " ";                                                            //その他4
                //その他5(=本数)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_HONSU].Value != null)
                {
                    addRow.hb2Sonota5 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_HONSU].Value.ToString();
                }
                else
                {
                    addRow.hb2Sonota5 = "";
                }
                //その他6(=総秒数)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_SOBYOSU].Value != null)
                {
                    addRow.hb2Sonota6 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_SOBYOSU].Value.ToString();
                }
                else
                {
                    addRow.hb2Sonota6 = "";
                }
                //その他7(=秒数)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BYOSU].Value != null)
                {
                    addRow.hb2Sonota7 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_BYOSU].Value.ToString();
                }
                else
                {
                    addRow.hb2Sonota7 = "";
                }
                //その他8(=放送回数)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_HOSOSU].Value != null)
                {
                    addRow.hb2Sonota8 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_HOSOSU].Value.ToString();
                }
                else
                {
                    addRow.hb2Sonota8 = "";
                }
                //その他9(=FD用表示順)
                if (_spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_HYOJIJYN].Value != null)
                {
                    addRow.hb2Sonota9 = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_HYOJIJYN].Value.ToString();
                }
                else
                {
                    addRow.hb2Sonota9 = "";
                }
                addRow.hb2Sonota10 = " ";                                                           //その他10(=FD用表示順序)

                //addRow.hb2BunFlg = " ";                                                             //分割フラグ.
                if (_spdKkhDetail_Sheet1.RowCount > 1)
                {
                    addRow.hb2BunFlg = "1";
                }
                else
                {
                    addRow.hb2BunFlg = " ";
                }

                //件名変更フラグ.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, KKHLionConst.COLIDX_MLIST_KENCHANGE].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2MeihnFlg = "1";
                }
                else
                {
                    addRow.hb2MeihnFlg = " ";
                }

                addRow.hb2NebhnFlg = " ";                                                           //値引率変更フラグ.

                dtThb2Kmei.AddTHB2KMEIRow(addRow);
            }
            dsDetail.THB2KMEI.Merge(dtThb2Kmei);

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
                //明細登録"済"を設定.
                listRow.toroku = "済";
                //[登録者]に更新者を設定.
                listRow.trkTnt = _naviParameter.strEsqId;
                //[更新者]を更新者を設定.
                listRow.updTnt = _naviParameter.strEsqId;
            }
            else
            {
                //明細登録"済"を解除.
                listRow.toroku = "";

                //[登録者]を初期化.
                listRow.trkTnt = "";
                //[更新者]を初期化.
                listRow.updTnt = "";
            }

            //******************************************************************************************
            //保持している受注登録内容データを処理後のデータで更新する.
            //******************************************************************************************
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow updRow in result.DsDetail.THB1DOWN.Rows)
            {
                _dsDetail.JyutyuData.UpdateRowDataByTGADOWNRow(updRow);
                _dsDetail.THB1DOWN.UpdateRowData(updRow);
            }
            _dsDetail.JyutyuData.AcceptChanges();
            _dsDetail.THB1DOWN.AcceptChanges();

            //★明細登録後に明細件数を初期化.
            dataRow.detailCnt = 0;

            //現在のアクティブ行インデックスを保持.
            int rowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;
            //再検索.
            //現在位置の取得.
            int _spdJyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            base.SearchJyutyuData();

            //元の位置に戻す.
            _spdJyutyuList_Sheet1.SetActiveCell(_spdJyutyuListRowIdx, 0, true);
            _spdJyutyuList_Sheet1.AddSelection(_spdJyutyuListRowIdx, -1, 1, -1);
            spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

            //親の処理を呼ぶ(親のLeaveCellイベントが発生しないので)
            base.DisplayKkhDetail(_spdJyutyuListRowIdx);
            //子の処理を呼ぶ(親↑が呼んでくれないので)
            DisplayKkhDetail(_spdJyutyuListRowIdx);

            //ローディング表示終了.
            base.CloseLoadingDialog();

            MessageUtility.ShowMessageBox(MessageCode.HB_I0012, null, "明細登録", MessageBoxButtons.OK);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jyutyuDataRow"></param>
        /// <returns></returns>
        private bool CheckBulkRegTarget(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow jyutyuDataRow)
        {
            if (jyutyuDataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Spot
                && (jyutyuDataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio
                    || jyutyuDataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.TVSpot)
                && jyutyuDataRow.detailCnt == 0 //TODO:明細登録後に明細件数を更新していることが前提.
                && jyutyuDataRow.hb1Field1 != ""
                && GetLionCd(jyutyuDataRow) != ""
                )
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// ライオンコード取得(局誌コードの電通→ライオン変換).
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private string GetLionCd(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row)
        {
            Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable dtMaster = new Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable();
            string masterKey = "";   //取得マスタのマスタキー.
            string filter = "";      //抽出条件.
            //業務区分によって使用するマスタ、取得条件を変更する.
            if (row.hb1GyomKbn == KKHSystemConst.GyomKbn.Shinbun)
            {
                masterKey = KKHLionConst.C_MAST_SHINBUN_HEN_CD;
                filter = dtMaster.Column1Column.ColumnName + "='" + row.hb1Field1 + "' AND " + dtMaster.Column2Column.ColumnName + "='" + row.hb1Field4 + "'";
            }
            else if (row.hb1GyomKbn == KKHSystemConst.GyomKbn.Zashi)
            {
                masterKey = KKHLionConst.C_MAST_ZASHI_HEN_CD;
                filter = dtMaster.Column1Column.ColumnName + "='" + row.hb1Field1 + "'";
            }
            else if (row.hb1GyomKbn == KKHSystemConst.GyomKbn.TVTime || row.hb1GyomKbn == KKHSystemConst.GyomKbn.TVSpot)
            {
                masterKey = KKHLionConst.C_MAST_TV_HEN_CD;
                filter = dtMaster.Column1Column.ColumnName + "='" + row.hb1Field1 + "'";
            }
            else if (row.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio)
            {
                masterKey = KKHLionConst.C_MAST_RADIO_HEN_CD;
                filter = dtMaster.Column1Column.ColumnName + "='" + row.hb1Field1 + "'";
            }
            else if (row.hb1GyomKbn == KKHSystemConst.GyomKbn.InteractiveM)
            {
                masterKey = KKHLionConst.C_MAST_SONOTA_HEN_CD;
                filter = dtMaster.Column1Column.ColumnName + "='" + row.hb1Field1 + "'";
            }
            else
            {
            }

            if (masterKey == "")
            {
                return "";
            }

            //マスタデータから取得条件に一致するデータを抽出.
            dtMaster = readMastDB.FindMasterData(_naviParameter.strEsqId,
                                                  _naviParameter.strEgcd,
                                                  _naviParameter.strTksKgyCd,
                                                  _naviParameter.strTksBmnSeqNo,
                                                  _naviParameter.strTksTntSeqNo,
                                                  masterKey,
                                                  false);
            DataRow[] dr = dtMaster.Select(filter);
            if (dr.Length == 0)
            {
                return "";
            }
            Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow mastRow = (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow)dr[0];

            //業務区分によってライオンコードの取得する項目を変更.
            if (row.hb1GyomKbn == KKHSystemConst.GyomKbn.Shinbun)
            {
                return mastRow.Column3;
            }
            else
            {
                return mastRow.Column2;
            }


            //return mastRow.Column2;
        }

        /// <summary>
        /// 明細No統合処理.
        /// </summary>
        private void btnMergeByJyutyuNo_Click()
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


            //選択した受注登録内容のデータを取得.
            int activeRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow selJyutyuDataRow = getSelectJyutyuData(activeRowIdx);

            // フィルタで隠れているレコードが処理対象になっている場合はエラー表示.
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
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0146, null, "明細登録", MessageBoxButtons.OK);
                    return;
                }
            }

            //保持している受注登録内容データから受注No＋受注明細Noが同じデータを取得(選択行のデータ含む)
            string filter = "";
            filter = filter + "     " + _dsDetail.JyutyuData.hb1JyutNoColumn.ColumnName + "='" + selJyutyuDataRow.hb1JyutNo + "'";
            filter = filter + " AND " + _dsDetail.JyutyuData.hb1JyMeiNoColumn.ColumnName + "='" + selJyutyuDataRow.hb1JyMeiNo + "'";
            filter = filter + " AND " + _dsDetail.JyutyuData.hb1TJyutNoColumn.ColumnName + "=''";
            DataRow[] dataRows = _dsDetail.JyutyuData.Select(filter);

            foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in dataRows)
            {
                //***********************************
                //チェック.
                //***********************************
                if (row.hb1TouFlg == "1")
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0015, null, "明細登録", MessageBoxButtons.OK);
                    return;
                }

                //統合元データの編集.
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

                //統合先データの編集.
                if (row.rowNum == selJyutyuDataRow.rowNum)
                {
                    //更新タイムスタンプ.
                    rowTougouSaki.hb1KsnTimStmp = row.hb1KsnTimStmp;
                    //明細更新者.
                    rowTougouSaki.hb1KsnTnt = row.hb1KsnTnt;
                    //明細更新者名.
                    rowTougouSaki.hb1KsnTntNm = row.hb1KsnTntNm;
                    //登録タイムスタンプ.
                    rowTougouSaki.hb1TrkTimStmp = row.hb1TrkTimStmp;
                    //登録者.
                    rowTougouSaki.hb1TrkTnt = row.hb1TrkTnt;
                    //登録者名.
                    rowTougouSaki.hb1TrkTntNm = row.hb1TrkTntNm;
                    //更新プログラム.
                    rowTougouSaki.hb1UpdApl = AplId;
                    //更新担当者.
                    rowTougouSaki.hb1UpdTnt = _naviParameter.strEsqId;
                    //営業所（扱）コード.
                    rowTougouSaki.hb1AtuEgCd = row.hb1EgCd;
                    //営業所（取）コード.
                    rowTougouSaki.hb1EgCd = row.hb1EgCd;
                    //得意先企業コード.
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
                    //費目コード.
                    rowTougouSaki.hb1HimkCd = row.hb1HimkCd;
                    //統合フラグ.
                    rowTougouSaki.hb1TouFlg = "1";
                    //年月.
                    rowTougouSaki.hb1Yymm = row.hb1Yymm;
                    //業務区分.
                    rowTougouSaki.hb1GyomKbn = row.hb1GyomKbn;
                    //マス正味区分.
                    rowTougouSaki.hb1MsKbn = row.hb1MsKbn;
                    //タイムスポット区分.
                    rowTougouSaki.hb1TmspKbn = row.hb1TmspKbn;
                    //国際区分.
                    rowTougouSaki.hb1KokKbn = row.hb1KokKbn;
                    //請求区分.
                    rowTougouSaki.hb1SeiKbn = row.hb1SeiKbn;
                    //商品No
                    rowTougouSaki.hb1SyoNo = row.hb1SyoNo;
                    //件名(漢字)
                    rowTougouSaki.hb1KKNameKJ = row.hb1KKNameKJ;
                    //営業画面タイプ.
                    rowTougouSaki.hb1EgGamenType = row.hb1EgGamenType;
                    //企画・製版区分.
                    rowTougouSaki.hb1KkakShanKbn = row.hb1KkakShanKbn;
                    //取料金.
                    rowTougouSaki.hb1ToriGak = rowTougouSaki.hb1ToriGak + row.hb1ToriGak;
                    //請求単価.
                    rowTougouSaki.hb1SeiTnka = 0.0M;
                    //請求金額.
                    rowTougouSaki.hb1SeiGak = rowTougouSaki.hb1SeiGak + row.hb1SeiGak;
                    //値引率.
                    rowTougouSaki.hb1NeviRitu = row.hb1NeviRitu;
                    //値引額.
                    rowTougouSaki.hb1NeviGak = rowTougouSaki.hb1NeviGak + row.hb1NeviGak;
                    //消費税区分.
                    rowTougouSaki.hb1SzeiKbn = row.hb1SzeiKbn;
                    //消費税率.
                    rowTougouSaki.hb1SzeiRitu = row.hb1SzeiRitu;
                    //消費税額.
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
                    //未請求フラグ.
                    rowTougouSaki.hb1MSeiFlg = " ";
                    //変更前年月.
                    rowTougouSaki.hb1YymmOld = " ";
                    //フィールド１.
                    rowTougouSaki.hb1Field1 = row.hb1Field1;
                    //フィールド２.
                    rowTougouSaki.hb1Field2 = row.hb1Field2;
                    //フィールド３.
                    rowTougouSaki.hb1Field3 = row.hb1Field3;
                    //フィールド４.
                    rowTougouSaki.hb1Field4 = row.hb1Field4;
                    //フィールド５.
                    rowTougouSaki.hb1Field5 = row.hb1Field5;
                    //フィールド６.
                    rowTougouSaki.hb1Field6 = row.hb1Field6;
                    //フィールド７.
                    rowTougouSaki.hb1Field7 = row.hb1Field7;
                    //フィールド８.
                    rowTougouSaki.hb1Field8 = row.hb1Field8;
                    //フィールド９.
                    rowTougouSaki.hb1Field9 = row.hb1Field9;
                    //フィールド１０.
                    rowTougouSaki.hb1Field10 = row.hb1Field10;
                    //フィールド１１.
                    rowTougouSaki.hb1Field11 = row.hb1Field11;
                    //フィールド１２.
                    rowTougouSaki.hb1Field12 = row.hb1Field12;
                }
                else
                {
                    //取料金.
                    rowTougouSaki.hb1ToriGak = rowTougouSaki.hb1ToriGak + row.hb1ToriGak;
                    //請求金額.
                    rowTougouSaki.hb1SeiGak = rowTougouSaki.hb1SeiGak + row.hb1SeiGak;
                    //値引額.
                    rowTougouSaki.hb1NeviGak = rowTougouSaki.hb1NeviGak + row.hb1NeviGak;
                    //消費税額.
                    rowTougouSaki.hb1SzeiGak = rowTougouSaki.hb1SzeiGak + row.hb1SzeiGak;
                }

                //更新日付最大値の判定.
                if (maxUpdDate == null || maxUpdDate.CompareTo(row.hb1TimStmp) < 0)
                {
                    maxUpdDate = row.hb1TimStmp;
                }
            }


            dtTougouSaki.AddTHB1DOWNRow(rowTougouSaki);
            dsTougouSaki.THB1DOWN.Merge(dtTougouSaki);

            dsTougouMoto.THB1DOWN.Merge(dtTougouMoto);

            DetailProcessController.MergeJyutyuDataParam param = new DetailProcessController.MergeJyutyuDataParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.dsTougouSaki = dsTougouSaki;
            param.dsTougouMoto = dsTougouMoto;
            param.maxUpdDate = maxUpdDate;

            DetailProcessController processController = DetailProcessController.GetInstance();
            MergeJyutyuDataServiceResult result = processController.MergeJyutyuData(param);
            if (result.HasError == true)
            {
                //MessageBox.Show("統合に失敗しました。", "明細登録", MessageBoxButtons.OK);//TODO
                MessageUtility.ShowMessageBox(MessageCode.HB_E0006, null, "明細登録", MessageBoxButtons.OK);
                return;
            }

            //*****************************************************
            //再表示処理.
            //*****************************************************
            //this.SuspendLayout();
            spdJyutyuList.SuspendLayout();
            ReSearchJyutyuData();
            if (_spdJyutyuList_Sheet1.RowCount >= activeRowIdx + 1)
            {
                _spdJyutyuList_Sheet1.SetActiveCell(activeRowIdx, 0, true);
                _spdJyutyuList_Sheet1.AddSelection(activeRowIdx, -1, 1, -1);
                spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);
            }

            //******************************
            //広告費明細.
            //******************************
            //現在行の明細レコードを表示する.
            DisplayKkhDetail(_spdJyutyuList_Sheet1.ActiveRowIndex);

            spdJyutyuList.ResumeLayout();

            //Message：統合しました。.
            MessageUtility.ShowMessageBox(MessageCode.HB_I0009, null, "明細登録", MessageBoxButtons.OK);

            return;
        }

        /// <summary>
        /// テレビタイム統合ボタンクリック処理.
        /// </summary>
        private void btnTVTimeMergeByJyutyuNo_Click()
        {
            // フィルタで隠れているレコードが処理対象になっている場合はエラー表示.
            for (int i = 0; i < _spdJyutyuList_Sheet1.Rows.Count; i++)
            {
                // テレビタイム以外は無視する.
                if (!_spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_GYOMKBN].Text.Equals(KKHSystemConst.GyomKbn.TVTime))
                {
                    continue;
                }

                if (_spdJyutyuList_Sheet1.RowFilter.IsRowFilteredOut(i))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0146, null, "明細登録", MessageBoxButtons.OK);
                    return;
                }
            }

            string jyutyuNo = "";
            string JyMeiNo = "";
            bool blnMerge = false;

            //受注データから未統合のテレビタイムのデータを取得.
            string filter = "";
            filter = filter + "     " + _dsDetail.JyutyuData.hb1GyomKbnColumn + "='" + KKHSystemConst.GyomKbn.TVTime + "'";
            filter = filter + " AND " + _dsDetail.JyutyuData.hb1TJyutNoColumn.ColumnName + "=''";
            filter = filter + " AND " + _dsDetail.JyutyuData.hb1TJyMeiNoColumn.ColumnName + "=''";
            filter = filter + " AND " + _dsDetail.JyutyuData.hb1TUrMeiNoColumn.ColumnName + "=''";
            filter = filter + " AND " + _dsDetail.JyutyuData.hb1TouFlgColumn.ColumnName + "<>'1'";

            string sort = "";
            sort = sort + _dsDetail.JyutyuData.hb1JyutNoColumn.ColumnName + ",";
            sort = sort + _dsDetail.JyutyuData.hb1JyMeiNoColumn.ColumnName + ",";
            sort = sort + _dsDetail.JyutyuData.hb1UrMeiNoColumn.ColumnName;

            DataRow[] TVTimedataRows = _dsDetail.JyutyuData.Select(filter, sort);

            if (TVTimedataRows.Length == 0)
            {
                //Message：該当するデータがありません。.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "明細登録", MessageBoxButtons.OK);
                return;
            }

            for (int i = 0; i < TVTimedataRows.Length; i++)
            {
                if (jyutyuNo + JyMeiNo != TVTimedataRows[i].ItemArray[9].ToString() + TVTimedataRows[i].ItemArray[10].ToString())
                {
                    jyutyuNo = TVTimedataRows[i].ItemArray[9].ToString();
                    JyMeiNo = TVTimedataRows[i].ItemArray[10].ToString();

                    //同じ受注Ｎｏ＋受注明細Ｎｏで未統合のデータを抽出.
                    filter = "";
                    filter = filter + "     " + _dsDetail.JyutyuData.hb1JyutNoColumn.ColumnName + "='" + jyutyuNo + "'";
                    filter = filter + " AND " + _dsDetail.JyutyuData.hb1JyMeiNoColumn.ColumnName + "='" + JyMeiNo + "'";
                    filter = filter + " AND " + _dsDetail.JyutyuData.hb1TJyutNoColumn.ColumnName + "=''";
                    filter = filter + " AND " + _dsDetail.JyutyuData.hb1TJyMeiNoColumn.ColumnName + "=''";
                    filter = filter + " AND " + _dsDetail.JyutyuData.hb1TUrMeiNoColumn.ColumnName + "=''";
                    filter = filter + " AND " + _dsDetail.JyutyuData.hb1TouFlgColumn.ColumnName + "<>'1'";

                    sort = "";
                    sort = sort + _dsDetail.JyutyuData.hb1JyutNoColumn.ColumnName + ",";
                    sort = sort + _dsDetail.JyutyuData.hb1JyMeiNoColumn.ColumnName + ",";
                    sort = sort + _dsDetail.JyutyuData.hb1UrMeiNoColumn.ColumnName;

                    DataRow[] dataRows = _dsDetail.JyutyuData.Select(filter, sort);

                    if (dataRows.Length == 0)
                    {
                        break;
                    }

                    if (dataRows.Length > 1)
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

                        int count = 0;

                        foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in dataRows)
                        {
                            //統合元データの編集.
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

                            //統合先データの編集.
                            if (count == 0)
                            {
                                //更新タイムスタンプ.
                                rowTougouSaki.hb1KsnTimStmp = row.hb1KsnTimStmp;
                                //明細更新者.
                                rowTougouSaki.hb1KsnTnt = row.hb1KsnTnt;
                                //明細更新者名.
                                rowTougouSaki.hb1KsnTntNm = row.hb1KsnTntNm;
                                //登録タイムスタンプ.
                                rowTougouSaki.hb1TrkTimStmp = row.hb1TrkTimStmp;
                                //登録者.
                                rowTougouSaki.hb1TrkTnt = row.hb1TrkTnt;
                                //登録者名.
                                rowTougouSaki.hb1TrkTntNm = row.hb1TrkTntNm;
                                //更新プログラム.
                                rowTougouSaki.hb1UpdApl = AplId;
                                //更新担当者.
                                rowTougouSaki.hb1UpdTnt = _naviParameter.strEsqId;
                                //営業所（扱）コード.
                                rowTougouSaki.hb1AtuEgCd = row.hb1EgCd;
                                //営業所（取）コード.
                                rowTougouSaki.hb1EgCd = row.hb1EgCd;
                                //得意先企業コード.
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
                                //費目コード.
                                rowTougouSaki.hb1HimkCd = row.hb1HimkCd;
                                //統合フラグ.
                                rowTougouSaki.hb1TouFlg = "1";
                                //年月.
                                rowTougouSaki.hb1Yymm = row.hb1Yymm;
                                //業務区分.
                                rowTougouSaki.hb1GyomKbn = row.hb1GyomKbn;
                                //マス正味区分.
                                rowTougouSaki.hb1MsKbn = row.hb1MsKbn;
                                //タイムスポット区分.
                                rowTougouSaki.hb1TmspKbn = row.hb1TmspKbn;
                                //国際区分.
                                rowTougouSaki.hb1KokKbn = row.hb1KokKbn;
                                //請求区分.
                                rowTougouSaki.hb1SeiKbn = row.hb1SeiKbn;
                                //商品No
                                rowTougouSaki.hb1SyoNo = row.hb1SyoNo;
                                //件名(漢字)
                                rowTougouSaki.hb1KKNameKJ = row.hb1KKNameKJ;
                                //営業画面タイプ.
                                rowTougouSaki.hb1EgGamenType = row.hb1EgGamenType;
                                //企画・製版区分.
                                rowTougouSaki.hb1KkakShanKbn = row.hb1KkakShanKbn;
                                //取料金.
                                rowTougouSaki.hb1ToriGak = rowTougouSaki.hb1ToriGak + row.hb1ToriGak;
                                //請求単価.
                                rowTougouSaki.hb1SeiTnka = 0.0M;
                                //請求金額.
                                rowTougouSaki.hb1SeiGak = rowTougouSaki.hb1SeiGak + row.hb1SeiGak;
                                //値引率.
                                rowTougouSaki.hb1NeviRitu = row.hb1NeviRitu;
                                //値引額.
                                rowTougouSaki.hb1NeviGak = rowTougouSaki.hb1NeviGak + row.hb1NeviGak;
                                //消費税区分.
                                rowTougouSaki.hb1SzeiKbn = row.hb1SzeiKbn;
                                //消費税率.
                                rowTougouSaki.hb1SzeiRitu = row.hb1SzeiRitu;
                                //消費税額.
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
                                //未請求フラグ.
                                rowTougouSaki.hb1MSeiFlg = " ";
                                //変更前年月.
                                rowTougouSaki.hb1YymmOld = " ";
                                //フィールド１.
                                rowTougouSaki.hb1Field1 = row.hb1Field1;
                                //フィールド２.
                                rowTougouSaki.hb1Field2 = row.hb1Field2;
                                //フィールド３.
                                rowTougouSaki.hb1Field3 = row.hb1Field3;
                                //フィールド４.
                                rowTougouSaki.hb1Field4 = row.hb1Field4;
                                //フィールド５.
                                rowTougouSaki.hb1Field5 = row.hb1Field5;
                                //フィールド６.
                                rowTougouSaki.hb1Field6 = row.hb1Field6;
                                //フィールド７.
                                rowTougouSaki.hb1Field7 = row.hb1Field7;
                                //フィールド８.
                                rowTougouSaki.hb1Field8 = row.hb1Field8;
                                //フィールド９.
                                rowTougouSaki.hb1Field9 = row.hb1Field9;
                                //フィールド１０.
                                rowTougouSaki.hb1Field10 = row.hb1Field10;
                                //フィールド１１.
                                rowTougouSaki.hb1Field11 = row.hb1Field11;
                                //フィールド１２.
                                rowTougouSaki.hb1Field12 = row.hb1Field12;
                            }
                            else
                            {
                                //取料金.
                                rowTougouSaki.hb1ToriGak = rowTougouSaki.hb1ToriGak + row.hb1ToriGak;
                                //請求金額.
                                rowTougouSaki.hb1SeiGak = rowTougouSaki.hb1SeiGak + row.hb1SeiGak;
                                //値引額.
                                rowTougouSaki.hb1NeviGak = rowTougouSaki.hb1NeviGak + row.hb1NeviGak;
                                //消費税額.
                                rowTougouSaki.hb1SzeiGak = rowTougouSaki.hb1SzeiGak + row.hb1SzeiGak;
                            }

                            //更新日付最大値の判定.
                            if (maxUpdDate == null || maxUpdDate.CompareTo(row.hb1TimStmp) < 0)
                            {
                                maxUpdDate = row.hb1TimStmp;
                            }
                            count++;
                        }

                        dtTougouSaki.AddTHB1DOWNRow(rowTougouSaki);
                        dsTougouSaki.THB1DOWN.Merge(dtTougouSaki);
                        dsTougouMoto.THB1DOWN.Merge(dtTougouMoto);

                        DetailProcessController.MergeJyutyuDataParam param = new DetailProcessController.MergeJyutyuDataParam();
                        param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
                        param.dsTougouSaki = dsTougouSaki;
                        param.dsTougouMoto = dsTougouMoto;
                        param.maxUpdDate = maxUpdDate;

                        DetailProcessController processController = DetailProcessController.GetInstance();
                        MergeJyutyuDataServiceResult result = processController.MergeJyutyuData(param);
                        if (result.HasError == true)
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_E0006, null, "明細登録", MessageBoxButtons.OK);
                            return;
                        }

                        blnMerge = true;

                    }
                }
            }

            //*****************************************************
            //再表示処理.
            //*****************************************************
            spdJyutyuList.SuspendLayout();
            ReSearchJyutyuData();

            //******************************
            //広告費明細.
            //******************************
            //現在行の明細レコードを表示する.
            DisplayKkhDetail(_spdJyutyuList_Sheet1.ActiveRowIndex);

            spdJyutyuList.ResumeLayout();

            if (blnMerge == true)
            {
                //Message：統合しました。.
                MessageUtility.ShowMessageBox(MessageCode.HB_I0009, null, "明細登録", MessageBoxButtons.OK);
            }
            else
            {
                //Message：該当するデータがありません。.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "明細登録", MessageBoxButtons.OK);
            }
        }

        # endregion
    }
}

