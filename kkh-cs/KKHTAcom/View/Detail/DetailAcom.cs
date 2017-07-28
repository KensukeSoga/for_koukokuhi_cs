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
using System.Collections;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Acom.Schema;
using Isid.KKH.Acom.Utility;

namespace Isid.KKH.Acom.View.Detail
{
    /// <summary>
    /// アコム明細登録画面.
    /// </summary>
    public partial class DetailAcom : Isid.KKH.Common.KKHView.Detail.DetailForm
    {
        #region 定数.

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "DtlAcom";

        #region 明細(一覧)カラムインデックス.
        /// <summary>
        /// メディアコード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_MEDIA_CD = 0;
        /// <summary>
        /// 発売日or掲載日列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_HATSUORKEISAI = 1;
        /// <summary>
        /// 発注番号列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_HACHU_NO = 2;
        /// <summary>
        /// 発注行番号列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_HACHUGYO_NO = 3;
        /// <summary>
        /// 請求書番号列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SEIKYUSHO_NO = 4;
        /// <summary>
        /// 請求書行番号列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SEIKYUSHOGYO_NO = 5;
        /// <summary>
        /// 旧請求書番号列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KYU_SEIKYUSHO_NO = 6;
        /// <summary>
        /// 消費税率列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SHOHIZEI_RITSU = 7;
        /// <summary>
        /// 消費税額列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SHOHIZEI_GAKU = 8;
        /// <summary>
        /// 金額列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KINGAKU = 9;
        /// <summary>
        /// 掲載単価列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KEISAITANKA = 10;
        /// <summary>
        /// 値引率列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_NEBIKI_RITSU = 11;
        /// <summary>
        /// 値引額列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_NEBIKI_GAKU = 12;
        /// <summary>
        /// 取料金列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_TORIRYOKIN = 13;
        /// <summary>
        /// 取引先コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_TORIHIKISAKI_CD = 14;
        /// <summary>
        /// 請求部署コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SEIKYU_BUSHO = 15;
        /// <summary>
        /// 請求書発行日列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SEIKYUSHO_HAKO_BI = 16;
        /// <summary>
        /// 支払日列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SHIHARAI_BI = 17;
        /// <summary>
        /// CM秒数列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_CM_BYOSU = 18;
        /// <summary>
        /// 内容名称列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_NAIYO_MEI = 19;
        /// <summary>
        /// 番組名列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_BANGUMI_MEI = 20;
        /// <summary>
        /// 期間列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KIKAN = 21;
        /// <summary>
        /// 商品区分列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SHOHIN_KBN = 22;
        /// <summary>
        /// 商品区分名称列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SHOHIN_KBN_MEI = 23;
        /// <summary>
        /// 摘要コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_TEKIYO_CD = 24;
        /// <summary>
        /// 媒体コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_BAITAI_CD = 25;
        /// <summary>
        /// 店番列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_TEN_NO = 26;
        /// <summary>
        /// 掲載場所コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KEISAIBASHO_CD = 27;
        /// <summary>
        /// 種別1コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SHUBETSU1_CD = 28;
        /// <summary>
        /// 種別２コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SHUBETSU2_CD = 29;
        /// <summary>
        /// 色刷コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_IROZURI_CD = 30;
        /// <summary>
        /// サイズコード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SIZE_CD = 31;
        /// <summary>
        /// 形態区分コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KEITAI_KBN_CD = 32;
        /// <summary>
        /// 形態区分名称列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KEITAI_KBN_MEI = 33;
        /// <summary>
        /// 交通掲載コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KOTSU_KEISAI_CD = 34;
        /// <summary>
        /// 掲載回数列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KEISAI_KAISU = 35;
        /// <summary>
        /// 備考1列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_BIKO1 = 36;
        /// <summary>
        /// 備考2列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_BIKO2 = 37;
        /// <summary>
        /// 按分種別列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_ANBUN = 38;
        /// <summary>
        /// 受注内容区分列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_JUCHU_NAIYO_KBN = 39;
        /// <summary>
        /// 登録年月日列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_TOROKU_DATE = 40;
        /// <summary>
        /// 変更年月日列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_HENKO_DATE = 41;
        /// <summary>
        /// 取消年月日列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_TORIKESHI_DATE = 42;
        /// <summary>
        /// 受注No列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_JUCHU_NO = 43;
        /// <summary>
        /// 受注明細No列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_JUCHU_MEISAI_NO = 44;
        /// <summary>
        /// 売上明細No列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_URIAGE_MEISAI_NO = 45;
        /// <summary>
        /// 請求原票No列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SEIKYU_GENPYO_NO = 46;
        /// <summary>
        /// 送信状況区分列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SOSHIN_JOKYO_KBN = 47;
        /// <summary>
        /// 出力日列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SHUTSURYOKU_DATE = 48;
        /// <summary>
        /// 値引行区分列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_NEBIKI_GYO_KBN = 49;
        #endregion 明細(一覧)カラムインデックス.

        #region 業務区分.
        /// <summary>
        /// 新聞.
        /// </summary>
        public const String C_GYOM_SHINBUN = KKHSystemConst.GyomKbn.Shinbun;
        /// <summary>
        /// 雑誌.
        /// </summary>
        public const String C_GYOM_ZASHI = KKHSystemConst.GyomKbn.Zashi;
        /// <summary>
        /// ラジオ.
        /// </summary>
        public const String C_GYOM_RADIO = KKHSystemConst.GyomKbn.Radio;
        /// <summary>
        /// テレビタイム.
        /// </summary>
        public const String C_GYOM_TV_TIME = KKHSystemConst.GyomKbn.TVTime;
        /// <summary>
        /// テレビスポット.
        /// </summary>
        public const String C_GYOM_TV_SPOT = KKHSystemConst.GyomKbn.TVSpot;
        /// <summary>
        /// 衛星メディア.
        /// </summary>
        public const String C_GYOM_EISEI_M = KKHSystemConst.GyomKbn.EiseiM;
        /// <summary>
        /// OOHメディア.
        /// </summary>
        public const String C_GYOM_OOH_M = KKHSystemConst.GyomKbn.OohM;
        /// <summary>
        /// インタラクティブメディア.
        /// </summary>
        public const String C_GYOM_INTE_M = KKHSystemConst.GyomKbn.InteractiveM;
        /// <summary>
        /// その他メディア.
        /// </summary>
        public const String C_GYOM_SONOTA_M = KKHSystemConst.GyomKbn.SonotaM;
        /// <summary>
        /// メディアプランニング.
        /// </summary>
        public const String C_GYOM_M_PLAN = KKHSystemConst.GyomKbn.MPlan;
        /// <summary>
        /// クリエーティブ.
        /// </summary>
        public const String C_GYOM_CREATE = KKHSystemConst.GyomKbn.Creative;
        /// <summary>
        /// マーケティング/プロモーション.
        /// </summary>
        public const String C_GYOM_MARK_PROM = KKHSystemConst.GyomKbn.MarkePromo;
        /// <summary>
        /// スポーツ.
        /// </summary>
        public const String C_GYOM_SPORTS = KKHSystemConst.GyomKbn.Sports;
        /// <summary>
        /// エンタテイメント.
        /// </summary>
        public const String C_GYOM_ENTE = KKHSystemConst.GyomKbn.Entertainment;
        /// <summary>
        /// その他コンテンツ.
        /// </summary>
        public const String C_GYOM_SONOTA = KKHSystemConst.GyomKbn.SonotaC;
        #endregion 業務区分.

        #region 色.
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
        #endregion 色.

        #endregion 定数.

        #region プロパティ.

        private string _Gykbn;
        /// <summary>
        /// 検索条件業務区分.
        /// </summary>
        public string Gykbn
        {
            get { return _Gykbn; }
            set { _Gykbn = value; }
        }

        private string _JyutNo;
        /// <summary>
        /// 検索条件受注No
        /// </summary>
        public string JyutNo
        {
            get { return _JyutNo; }
            set { _JyutNo = value; }
        }

        private string _Tmspkbn;
        /// <summary>
        /// 検索条件タイムスポット区分.
        /// </summary>
        public string Tmspkbn
        {
            get { return _Tmspkbn; }
            set { _Tmspkbn = value; }
        }	

        #endregion プロパティ.

        #region メンバ変数.
        /// <summary>
        /// NaviParameter
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        #endregion メンバ変数.

        #region コンストラクタ.
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DetailAcom()
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
                if (col.Index == COLIDX_JLIST_TOROKU) { col.Visible = true; }                   //登録.
                if (col.Index == COLIDX_JLIST_TOGO) { col.Visible = false; }                    //統合.
                if (col.Index == COLIDX_JLIST_DAIUKE) { col.Visible = true; }                   //代受.
                if (col.Index == COLIDX_JLIST_SEIKYU) { col.Visible = false; }                  //請求.
                if (col.Index == COLIDX_JLIST_URIMEINO) { col.Visible = true; }                 //売上明細NO
                if (col.Index == COLIDX_JLIST_GPYNO) { col.Visible = false; }                   //請求原票NO
                if (col.Index == COLIDX_JLIST_SEIYYMM) { col.Visible = true; }                  //請求年月.
                if (col.Index == COLIDX_JLIST_GYOMKBN) { col.Visible = true; }                  //業務区分.
                if (col.Index == COLIDX_JLIST_KENMEI) { col.Visible = true; }                   //件名.
                if (col.Index == COLIDX_JLIST_BAITAINM) { col.Visible = true; }                 //媒体名.
                if (col.Index == COLIDX_JLIST_HIMOKUNM) { col.Visible = true; }                 //費目名.
                if (col.Index == COLIDX_JLIST_KYOKUSHICD) { col.Visible = false; }              //局誌CD
                if (col.Index == COLIDX_JLIST_SEIKINGAKU) { col.Visible = true; }               //請求金額.
                if (col.Index == COLIDX_JLIST_KIKAN) { col.Visible = true; }                    //期間.
                if (col.Index == COLIDX_JLIST_DANTANKA) { col.Visible = false; }                //段単価.
                if (col.Index == COLIDX_JLIST_DANSU) { col.Visible = false; }                   //段数.
                if (col.Index == COLIDX_JLIST_TORIRYOKIN) { col.Visible = true; }               //取料金.
                if (col.Index == COLIDX_JLIST_NEBIKIRITSU) { col.Visible = true; }              //値引率.
                if (col.Index == COLIDX_JLIST_NEBIKIGAKU) { col.Visible = true; }               //値引額.
                if (col.Index == COLIDX_JLIST_ZEIRITSU) { col.Visible = true; }                 //消費税率.
                if (col.Index == COLIDX_JLIST_ZEIGAKU) { col.Visible = true; }                  //消費税額.
                if (col.Index == COLIDX_JLIST_GOUKEIKINGAKU) { col.Visible = false; }           //受注請求金額.
                if (col.Index == COLIDX_JLIST_OLDSEIYYMM) { col.Visible = true; }               //変更前請求年月.
            }
        }

        /// <summary>
        /// セルの色付け処理を行う.
        /// </summary>
        protected override void ChangeColor()
        {
            //親クラスの行っている共通処理を実行.
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
                    //統合フラグ="1"の行は背景色を変更.
                    _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(255 , 255 , 208);
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
            // 保留中は明細をクリアして処理終了.

            if (DetailSearchSuspendState)
            {
                _dsDetailAcom.KkhDetail.Clear();
                return;
            }

            //親クラスの行っている共通処理を実行.
            base.DisplayKkhDetail(rowIdx);

            //***************************************.
            //表示用広告費明細データの編集・表示.
            //***************************************.
            //広告費明細のデータセットを初期化.
            _dsDetailAcom.KkhDetail.Clear();
            //string filter = String.Empty;
            //Isid.KKH.Common.KKHSchema.Detail.TGA7MSHORow[] row7 = null;
            string kenmei = string.Empty;
            string dmeisyo = string.Empty;
            string baitaikbn = string.Empty;

            //アクティブシートを取得.
            SheetView activeSheet = base.spdJyutyuList.GetRootWorkbook().GetActiveWorkbook().GetSheetView();

            // 対象の受注データ、明細データ取得.
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(rowIdx)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);

            //int cnt = 0;
            //受注登録内容の件数分まわす.
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow row in _dsDetail.THB2KMEI.Rows)
            {

                //// TGA7MSHOの検索.
                //filter = "ga7JyutNo = \'" + row.hb2JyutNo + "\' AND " +
                //         "ga7JyMeiNo = \'" + row.hb2JyMeiNo + "\' AND " +
                //         "ga7UrMeiNo = \'" + row.hb2UrMeiNo + "\' AND " +
                //         "ga7HimkCd = \'" + row.hb2HimkCd + "\' AND " +
                //         "ga7Renbn = \'" + row.hb2Renbn + "\'";
                //row7 = (Isid.KKH.Common.KKHSchema.Detail.TGA7MSHORow[])_dsDetail.TGA7MSHO.Select(filter);

                DetailDSAcom.KkhDetailRow addRow = _dsDetailAcom.KkhDetail.NewKkhDetailRow();
                addRow.mediaCd = row.hb2Code2;                   //メディアコード.
                if (row.hb2Sonota9.Length == 8)
                {
//                  addRow.hatsuBaiBiorKeisaiBi = row.hb2Sonota9.Insert(6 , "/").Insert(4 , "/");          //発売日or掲載日.
                    addRow.hatsuBaiBiorKeisaiBi = row.hb2Sonota9;
                }
                else if (row.hb2Date1.Length == 0)
                {
                    addRow.hatsuBaiBiorKeisaiBi = string.Empty;
                }
                else
                {
                    addRow.hatsuBaiBiorKeisaiBi = row.hb2Sonota9;
                }
                //addRow.hatsuBaiBiorKeisaiBi = row.hb2Sonota9;   //発売日or掲載日.
                addRow.hachuNo = row.hb2Code3;                  //発注番号.
                addRow.hachuGyoNo = row.hb2Code4;               //発注行番号.
                addRow.seikyuShoNo = row.hb2Sonota1;            //請求書番号.
                addRow.seikyuShoGyoNo = row.hb2Sonota2;         //請求書行番号.
                addRow.kyuSeikyuShoNo = row.hb2Sonota10;        //旧請求書番号.
                addRow.shohiZeiRitsu = row.hb2Ritu1;            //消費税率.
                addRow.shohizeiGaku = row.hb2Kngk1;             //消費税額.
                addRow.kingaku = row.hb2SeiGak;                 //金額.
                if (string.IsNullOrEmpty(row.hb2Sonota7))
                {
                    addRow.keisaiTanka = 0;                  //掲載単価.
                    //row.hb2Sonota7 = "0";
                }
                else
                {
                    addRow.keisaiTanka = decimal.Parse(row.hb2Sonota7);            //掲載単価.
                }
                addRow.nebikiRitsu = row.hb2Hnnert;             //値引率.
                addRow.nebikiGaku = row.hb2NebiGak;             //値引額.
                addRow.toriRyokin = row.hb2Kngk2;               //取料金.
                addRow.torihikisakiCd = row.hb2Sonota5;         //取引先コード.
                addRow.seikyuBushoCd = row.hb2Code5;            //請求部署コード.
                if (row.hb2Date1.Length == 8)
                {
                    addRow.seikyuShoHakoBi = row.hb2Date1.Insert(6 , "/").Insert(4 , "/");          //請求書発行日.
                }
                else if (row.hb2Date1.Length == 0)
                {
                    addRow.seikyuShoHakoBi = string.Empty;
                }
                else
                {
                    addRow.seikyuShoHakoBi = row.hb2Date1;
                }

                //addRow.seikyuShoHakoBi = row.hb2Date1;          //請求書発行日.
                //addRow.shiharaiBi = row.hb2Date2;               //支払日.
                if (row.hb2Date2.Length == 8)
                {
                    addRow.shiharaiBi = row.hb2Date2.Insert(6 , "/").Insert(4 , "/");          //支払日.
                }
                else if (row.hb2Date2.Length == 0)
                {
                    addRow.shiharaiBi = string.Empty;
                }
                else
                {
                    addRow.shiharaiBi = row.hb2Date2;                   //支払日.
                }

                //addRow.cmByosu = row.hb2Name13;      //CM秒数名.
                //addRow.naiyoMei = row.hb2Name14;     //内容名称.
                //addRow.bangumiMei = row.hb2Name15;    //番組名.
                //addRow.kikan = row.hb2Name14;        //期間.

                addRow.shohinKbn = row.hb2Sonota3;                      //商品区分.
                addRow.shohinKbnMei = row.hb2Name1;                     //商品区分名称.
                addRow.tekiyoCd = row.hb2Code6;                         //摘要コード.
                addRow.baitaiCd = row.hb2Code1;                         //媒体コード.
                addRow.tenNo = row.hb2Sonota4;                          //店番.

                //addRow.keisaiBashoCd = _dsDetail.TGA7MSHO[cnt].hb2Name11; //掲載場所コード.
                //addRow.shubetsu1Cd = _dsDetail.TGA7MSHO[cnt].hb2Name12;   //種別１コード.
                //addRow.shubetsu2Cd = _dsDetail.TGA7MSHO[cnt].hb2Name13;   //種別２コード.
                //addRow.iroZuriCd = _dsDetail.TGA7MSHO[cnt].hb2Name14;     //色刷コード.
                //addRow.sizeCd = _dsDetail.TGA7MSHO[cnt].hb2Name15;        //サイズコード.
                //addRow.keitaiKbnCd = _dsDetail.TGA7MSHO[cnt].hb2Name11;  //形態区分コード.
                //addRow.keitaiKbnMei = _dsDetail.TGA7MSHO[cnt].hb2Name12;  //形態区分名称.
                //addRow.kotsuKeisaiCd = _dsDetail.TGA7MSHO[cnt].hb2Name11;  //交通掲載コード.
                //addRow.keisaiKaisu = _dsDetail.TGA7MSHO[cnt].hb2Name15;    //掲載回数.
                //addRow.biko1 = _dsDetail.TGA7MSHO[cnt].hb2Name16;    //備考１.
                //addRow.biko2 = _dsDetail.TGA7MSHO[cnt].hb2Name17;    //備考２.

                //addRow.keisaiBashoCd = row.hb2Name11; //掲載場所コード.
                //addRow.shubetsu1Cd = row.hb2Name12;   //種別１コード.
                //addRow.shubetsu2Cd = row.hb2Name13;   //種別２コード.
                //addRow.iroZuriCd = row.hb2Name14;     //色刷コード.
                //addRow.sizeCd = row.hb2Name15;        //サイズコード.
                //addRow.keitaiKbnCd = row.hb2Name11;  //形態区分コード.
                //addRow.keitaiKbnMei = row.hb2Name12;  //形態区分名称.
                //addRow.kotsuKeisaiCd = row.hb2Name11;  //交通掲載コード.
                //addRow.keisaiKaisu = row.hb2Name15;    //掲載回数.

                // 新聞.
                if (checkSNBN(dataRow.hb1GyomKbn))
                {
                    // 掲載場所コード.
                    addRow.keisaiBashoCd = row.hb2Name11;
                    // 種別１コード.
                    addRow.shubetsu1Cd = row.hb2Name12;
                    // 種別２コード.
                    addRow.shubetsu2Cd = row.hb2Name13;
                    // 色刷コード.
                    addRow.iroZuriCd = row.hb2Name14;
                    // サイズコード.
                    addRow.sizeCd = row.hb2Name15;
                    // 備考１.
                    addRow.biko1 = row.hb2Name16;
                    // 備考２.
                    addRow.biko2 = row.hb2Name17;
                }
                // 雑誌.
                else if (checkZASI(dataRow.hb1GyomKbn))
                {
                    // 色刷コード.
                    addRow.iroZuriCd = row.hb2Name11;
                    // サイズコード.
                    addRow.sizeCd = row.hb2Name12;
                    // 備考１.
                    addRow.biko1 = row.hb2Name13;
                    // 備考２.
                    addRow.biko2 = row.hb2Name14;
                }
                // 電波.
                else if (checkDENP(dataRow.hb1GyomKbn))
                {
                    // 形態区分コード.
                    addRow.keitaiKbnCd = row.hb2Name11;
                    // 形態区分名称.
                    addRow.keitaiKbnMei = row.hb2Name12;
                    // CM秒数.
                    addRow.cmByosu = row.hb2Name13;
                    // 内容名称.
                    addRow.naiyoMei = row.hb2Name14;
                    // 番組名.
                    addRow.bangumiMei = row.hb2Name15;
                    // 備考１.
                    addRow.biko1 = row.hb2Name16;
                    // 備考２.
                    addRow.biko2 = row.hb2Name17;
                }
                // 交通.
                else
                {
                    // 交通掲載コード.
                    addRow.kotsuKeisaiCd = row.hb2Name11;
                    // 備考１.
                    addRow.biko1 = row.hb2Name12;
                    // 備考２.
                    addRow.biko2 = row.hb2Name13;
                    // 期間.
                    addRow.kikan = row.hb2Name14;
                    // 掲載回数.
                    addRow.keisaiKaisu = row.hb2Name15;
                }

                //addRow.biko1 = row.hb2Name16;    //備考１.
                //addRow.biko2 = row.hb2Name17;    //備考２.

                addRow.anbunShubetsu = row.hb2MeihnFlg;             //按分種別.
                addRow.juchuNaiyoKbn = row.hb2Sonota6;              //受注内容区分.

                //addRow.torokuDate = row.hb2Date3;                   //登録年月日.
                if (row.hb2Date3.Length == 8)
                {
                    //addRow.torokuDate = row.hb2Date3.Insert(6 , "/").Insert(4 , "/");          //登録年月日.
                    addRow.torokuDate = row.hb2Date3;
                }
                else if (row.hb2Date3.Length == 0)
                {
                    addRow.torokuDate = string.Empty;
                }
                else
                {
                    addRow.torokuDate = row.hb2Date3;               //登録年月日.
                }
                //addRow.henkoDate = row.hb2Date4;                    //変更年月日.
                if (row.hb2Date4.Length == 8)
                {
                    //addRow.henkoDate = row.hb2Date4.Insert(6 , "/").Insert(4 , "/");           //変更年月日.
                    addRow.henkoDate = row.hb2Date4;
                }
                else if (row.hb2Date4.Length == 0)
                {
                    addRow.henkoDate = string.Empty;
                }
                else
                {
                    addRow.henkoDate = row.hb2Date4;                //変更年月日.
                }

                //addRow.torikeshiDate = row.hb2Date5;                //取消年月日.
                if (row.hb2Date5.Length == 8)
                {
                    //addRow.torikeshiDate = row.hb2Date5.Insert(6 , "/").Insert(4 , "/");             //取消年月日.
                    addRow.torikeshiDate = row.hb2Date5;
                }
                else if (row.hb2Date5.Length == 0)
                {
                    addRow.torikeshiDate = string.Empty;
                }
                else
                {
                    addRow.torikeshiDate = row.hb2Date5;                 //取消年月日.
                }
                addRow.juchuNo = row.hb2Name3;          //受注No.
                addRow.juchuMeisaiNo = row.hb2Name4;    //受注明細No.
                addRow.uriageMeisaiNo = row.hb2Name5;   //売上明細No.
                addRow.seikyuGenpyoNo = row.hb2Name6;    //請求原票No.
                addRow.soshinJokyoKbn = row.hb2Kbn1;    //送信状況区分.
                addRow.shutsuryokuDate = row.hb2Name7;  //出力日時;
                addRow.nebikiGyoKbn = row.hb2Kbn2;      //値引行区分;

                _dsDetailAcom.KkhDetail.AddKkhDetailRow(addRow);

                //
                //cnt++;
            }
            _dsDetailAcom.KkhDetail.AcceptChanges();

            //スプレッドデザインの再初期化.
            //InitializeDesignForSpdKkhDetail();

            //***************************************
            //広告費明細の表示・非表示設定.
            //***************************************
            //業務区分を取得.
            string _gyomKbn = dataRow.hb1GyomKbn;
            VisibleMeisaiColumns(_gyomKbn);

            //***************************************
            //ボタン類の使用可・不可設定.
            //***************************************
            //受注親シートがアクティブの場合.
            if (activeSheet == _spdJyutyuList_Sheet1)
            {
                btnMeiNyuryoku.Enabled = true;      //明細入力.
                btnMeiToroku.Enabled = true; //明細登録.
                //明細行が無い場合、削除ボタンを非活性にする.
                if (_spdKkhDetail_Sheet1.RowCount > 0)
                {
                    btnMeiSakujo.Enabled = true;
                }
                else
                {
                    btnMeiSakujo.Enabled = false;
                }
            }
            else
            {
                //親シートを検索.
                base.DisplayKkhDetail(spdJyutyuList.Sheets[0].ActiveRowIndex);

                //明細シートのデータを非表示.
                for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
                {
                    _spdKkhDetail_Sheet1.Rows[i].Visible = false;
                }
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
            if (!base.CheckBeforeSearch())
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
            InitializeButton();
        }

        /// <summary>
        /// 受注登録内容検索後チェック処理.
        /// </summary>
        /// <returns></returns>
        protected override Boolean CheckAfterSearch()
        {
            //親クラスの行っている共通処理を実行.
            if (!base.CheckAfterSearch())
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
            //値引率、消費税率の小数点を切り捨て.
            //***************************************
            NumberCellType cellnum = new NumberCellType((NumberCellType)base._spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_ZEIRITSU].CellType);
            cellnum.DecimalPlaces = 0;
            base._spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_NEBIKIRITSU].CellType = cellnum;
            base._spdJyutyuList_Sheet1.Columns[COLIDX_JLIST_ZEIRITSU].CellType = cellnum;

            //***************************************
            //ボタン類の使用可・不可設定.
            //***************************************
            //InitializeButton();
            SetButtonState();
        }

        /// <summary>
        /// ボタンの使用可否設定.
        /// </summary>
        protected void SetButtonState()
        {
            // 広告費明細データがある場合.
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                btnMeiNyuryoku.Enabled = true;
                btnMeiSakujo.Enabled = true;
                btnMeiToroku.Enabled = true;
            }
            //広告費明細データがない場合.
            else
            {
                btnMeiNyuryoku.Enabled = true;
                btnMeiSakujo.Enabled = false;
                btnMeiToroku.Enabled = true;
            }
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
                btnSelectMerge.Enabled = true;
                btnJuchuTogo.Enabled = true;
                //明細関係のボタンは明細検索後の処理に任せる.
            }
            else
            {
                //子ビューにフォーカスがある場合はデータ操作を行うボタンは使用させない.
                btnSelectMerge.Enabled = false;
                btnJuchuTogo.Enabled = false;

                btnMeiNyuryoku.Enabled = false;
                btnMeiSakujo.Enabled = false;
                btnMeiToroku.Enabled = false;
            }
        }

        /// <summary>
        /// 期間をyyyyMMddへ変更.
        /// </summary>
        /// <param name="dsDetail"></param>
        protected override void UpdateSpdData(Isid.KKH.Common.KKHSchema.Detail dsDetail)
        {
            for (int i = 0; i < dsDetail.JyutyuList.Count; i++)
            {
                Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow row = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)dsDetail.JyutyuList.Rows[i];
                Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow datarow = dsDetail.JyutyuData.FindByrowNum(row.rowNo);


                if (datarow.hb1TJyutNo.Trim().Length == 0)
                {

                    if (datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.NewsPaper
                            || datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.Magazine
                            || datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.KMas
                            )
                    {
                        row.kikan = FormatPeriodForYYYYMMDD(datarow.hb1Field3);

                    }
                    else if (datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.Time)
                    {
                        row.kikan = FormatPeriodForYYYYMMDD(datarow.hb1Field8);
                    }
                    else if (datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.Spot)
                    {
                        row.kikan = FormatPeriodForYYYYMMDD(datarow.hb1Field4);
                    }
                    else if (datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.Ooh
                             || datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.IC
                             || datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.Works
                             )
                    {
                        row.kikan = FormatPeriodForYYYYMMDD(datarow.hb1Field5);
                    }
                    else if (datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.KWorks)
                    {
                        row.kikan = FormatPeriodForYYYYMMDD(datarow.hb1Field4);
                    }


                }
                else
                {
                    if (datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.NewsPaper
                        || datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.Magazine
                        || datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.KMas
                        )
                    {
                        row.kikan = FormatPeriodForYYYYMMDD(datarow.hb1Field3);
                    }
                    else if (datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.Time)
                    {
                        row.kikan = FormatPeriodForYYYYMMDD(datarow.hb1Field8);
                    }
                    else if (datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.Spot)
                    {
                        row.kikan = FormatPeriodForYYYYMMDD(datarow.hb1Field4);
                    }
                    else if (datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.Ooh
                             || datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.IC
                             || datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.Works
                              )
                    {
                        row.kikan = FormatPeriodForYYYYMMDD(datarow.hb1Field5);
                    }
                    else if (datarow.hb1SeiKbn == KKHSystemConst.SeiKbn.KWorks)
                    {
                        row.kikan = FormatPeriodForYYYYMMDD(datarow.hb1Field4);
                    }

                }
            }
        }

        /// <summary>
        /// 統合取消.
        /// </summary>
        protected override void MergeCancelClick()
        {
            base.MergeCancelClick();
            //btnSelectMerge.Enabled = true;
            //btnJuchuTogo.Enabled = true;
        }

        /// <summary>
        /// 受注チェック.
        /// </summary>
        /// <returns></returns>
        protected override bool UpdateCheckClick()
        {
            if (!base.UpdateCheckClick())
            {
                return false;
            }

            // オペレーションログの出力.
            KKHLogUtilityAcom.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityAcom.KINO_ID_OPERATION_LOG_UPDCHECK, KKHLogUtilityAcom.DESC_OPERATION_LOG_UPDCHECK);
            return true;
        }
        #endregion オーバーライド.

        #region イベント.
        /// <summary>
        /// 画面遷移するたびに発生します.
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void DetailAcom_ProcessAffterNavigating(object sender , Isid.NJ.View.Base.NavigationEventArgs arg)
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
        /// フォームロードイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailAcom_Load(object sender , EventArgs e)
        {
            InitializeCommonProperty();
            InitializeDataSourceAcom();
            InitializeControlAcom();
        }

        /// <summary>
        /// FormShownイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailAcom_Shown(object sender , EventArgs e)
        {
            InitializeDesignForSpdKkhDetail();
        }

        /// <summary>
        /// 明細入力ボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMeiNyuryoku_Click(object sender , EventArgs e)
        {
            // 対象の受注データ、明細データ取得.
            int rowIndex = _spdJyutyuList_Sheet1.ActiveRowIndex;
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(rowIndex)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);
            int rowDetailIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;
            // 明細入力画面表示.
            KKHNaviParameter naviParam = new KKHNaviParameter();
            // 明細入力画面表示.
            //DetailInputAcomNaviParameter naviParam = new DetailInputAcomNaviParameter();
            naviParam.DataRow = dataRow;
            naviParam.RowDetailIndex = rowDetailIndex;
            naviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1;
            naviParam.strEsqId = _naviParam.strEsqId;
            naviParam.strEgcd = _naviParam.strEgcd;
            naviParam.strTksKgyCd = _naviParam.strTksKgyCd;
            naviParam.strTksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            naviParam.strTksTntSeqNo = _naviParam.strTksTntSeqNo;
            naviParam.GyomKbn = dataRow.hb1GyomKbn;
            naviParam.StrYymm = dataRow.hb1Yymm;
            naviParam.MergeDataRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[])_dsDetail.JyutyuData.Select( "hb1TJyutNo = '" + dataRow.hb1JyutNo + "' and hb1TJyMeiNo = '" + dataRow.hb1JyMeiNo + "' and hb1TUrMeiNo = '" + dataRow.hb1UrMeiNo + "'" );

            //明細入力画面に遷移.
            object result = Navigator.ShowModalForm(this , "toDetailInputAcom" , naviParam);
            //object result = Navigator.ShowModalFormByName(this, "DetailTenpoItr", naviParam);

            if (result == null)
            {
                this.ActiveControl = null;
                return;
            }
            base.kkhDetailUpdFlag = true; //広告費明細変更フラグを更新.

            //明細スプレッドを取得.
            _spdKkhDetail_Sheet1 = naviParam.SpdKkhDetail_Sheet1;
            //種別名を取得.

            //種別コードを取得.
            //string _shubetsuCd = _spdKkhDetail_Sheet1.Cells[rowDetailIndex , DetailAcom.COLIDX_MLIST_SHUBETSU].Value.ToString();
            //明細表示項目列.
            //VisibleMeisaiColumns(_shubetsuCd);
            // 差額計算.
            CalculateSagaku(dataRow);
            // ボタン活性処理.
            //btnDivide.Enabled = true;
            //btnMeiSakujo.Enabled = true;

            SetButtonState();

            this.ActiveControl = null;
        }

        /// <summary>
        /// 明細登録ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMeiToroku_Click(object sender , EventArgs e)
        {
            // チェック処理.
            //if (!ChkRegistDetailData())
            //{
            //    return;
            //}

            //string message = "";
            decimal sagaku = 0M;

            if (!decimal.TryParse(lblSagakuValue.Text , out sagaku) || sagaku == 0M)
            {
                if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_C0002,
                    null, "明細登録", MessageBoxButtons.YesNo))
                {
                    return;
                }
            }
            else
            {
                if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_W0089,
                    null, "明細登録", MessageBoxButtons.YesNo))
                {
                    return;
                }
            }

            // 明細登録処理.
            RegistDetailData();

            //選択状態を解除.
            this.ActiveControl = null;
        }

        /// <summary>
        /// 削除ボタンイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMeiSakujo_Click(object sender , EventArgs e)
        {
            //選択行の取得.
            //CellRange[] cellRanges = _spdKkhDetail_Sheet1.GetSelections();

            //int delCnt = 0;
            ////削除した行を明細(一覧)から削除.
            //foreach (CellRange cellRange in cellRanges)
            //{
            //    //選択されている明細内容の行数分の処理を繰り返す.
            //    _spdKkhDetail_Sheet1.RemoveRows(cellRange.Row - delCnt , cellRange.RowCount);
            //    delCnt = delCnt + cellRange.RowCount;
            //}

            int rowIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

            _spdKkhDetail_Sheet1.RemoveRows(rowIndex , 1);
            base.kkhDetailUpdFlag = true; //広告費明細変更フラグを更新.

            //***************************************
            //ボタン類の使用可・不可設定.
            //***************************************
            if (_spdKkhDetail_Sheet1.Rows.Count > 0)
            {
                //広告費明細データが既にある場合は削除は可.
                btnMeiSakujo.Enabled = true;
                //明細登録は可.
                btnMeiToroku.Enabled = true;
            }
            else
            {
                //広告費明細データがない場合は削除は不可.
                btnMeiSakujo.Enabled = false;
                //明細入力は可.
                btnMeiNyuryoku.Enabled = true;
                //明細登録は可.
                btnMeiToroku.Enabled = true;
            }

            // 対象の受注データ、明細データ取得.
            int row = _spdJyutyuList_Sheet1.ActiveRowIndex;

            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(row)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);

            // 差額計算.
            CalculateSagaku(dataRow);

            // 広告費明細変更フラグを更新.
            base.kkhDetailUpdFlag = true;
        }

        /// <summary>
        /// 受注NO統合ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJuchuTogo_Click(object sender, EventArgs e)
        {
            //実行確認.
            if (DialogResult.OK != MessageUtility.ShowMessageBox(MessageCode.HB_C0025,
                null, "受注No統合", MessageBoxButtons.OKCancel))
            {
                this.ActiveControl = null;
                return;
            }

            //明細変更確認.
            if (base.kkhDetailUpdFlag)
            {
                DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0071,
                null, "明細登録", MessageBoxButtons.YesNo);
                if (check == DialogResult.No)
                {
                    this.ActiveControl = null;
                    return;
                }
            }

            //受注No統合処理.
            JuchuNoTogo();

            this.ActiveControl = null;
        }

        /// <summary>
        /// 検索ボタン押下時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSch_Click(object sender, EventArgs e)
        {
            if (spdJyutyuList.Sheets[0].Rows.Count != 0)
            {
                btnSelectMerge.Enabled = true;
                btnJuchuTogo.Enabled = true;
            }
            else
            {
                btnSelectMerge.Enabled = false;
                btnJuchuTogo.Enabled = false;
            }

            //検索条件.
            Gykbn = cmbGymKbn.SelectedValue.ToString();
            //受注No
            JyutNo = txtJyuNo.Text;

            //タイムスポット区分.
            if (rdoTime.Visible)
            {
                //タイムの場合.
                if (rdoTime.Checked)
                {
                    Tmspkbn = "1";
                }
                //スポットの場合.
                else
                {
                    Tmspkbn = "2";
                }
            }
            else
            {
                Tmspkbn = string.Empty;
            }
        }

        /// <summary>
        /// 選択統合_Clickイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMerge_Click(object sender, EventArgs e)
        {
            //実行確認.
            if (DialogResult.OK != MessageUtility.ShowMessageBox(MessageCode.HB_C0023,
                null, "選択統合", MessageBoxButtons.OKCancel))
            {
                this.ActiveControl = null;
                return;
            }

            base.MergeClick();

            this.ActiveControl = null;
        }

        ///// <summary>
        ///// 明細スプレッドセルクリック時.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void spdKkhDetail_CellClick(object sender, CellClickEventArgs e)
        //{
        //    btnMeiSakujo.Enabled = true;
        //}

        /// <summary>
        /// ヘルプボタンクリック処理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
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
        private void CalculateSagaku(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            // 料金合計.
            decimal ryoukinGoukei = 0;

            // 明細の件数分、繰り返す.
            for (int i = 0 ; i < _spdKkhDetail_Sheet1.RowCount ; i++)
            {
                string ryoukinStr = _spdKkhDetail_Sheet1.Cells[i , COLIDX_MLIST_KINGAKU].Text.Trim();
                // 明細の料金が入力されている場合.
                if (KKHUtility.IsNumeric(ryoukinStr))
                {
                    string _nebikiGyo = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NEBIKI_GYO_KBN].Text.Trim();
                    if (_nebikiGyo.Equals("0"))
                    {
                        // 料金合計に加算.
                        ryoukinGoukei = ryoukinGoukei + decimal.Parse(ryoukinStr.Trim());
                    }
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
        /// <param name="dsDetailAcom"></param>
        private void UpdateDataSourceByDetailDataSetAcom(DetailDSAcom dsDetailAcom)
        {
            _dsDetailAcom.Clear();
            _dsDetailAcom.Merge(_dsDetailAcom);
            _dsDetailAcom.AcceptChanges();
        }

        /// <summary>
        /// データソースのバインド.
        /// </summary>
        private void InitializeDataSourceAcom()
        {
            //_bsJyutyuList
            _bsKkhDetail.DataSource = _dsDetailAcom;
            _bsKkhDetail.DataMember = _dsDetailAcom.KkhDetail.TableName;
            //_bsKkhDetail.DataMember = _dsDetailAcom.KkhDetailZashi.TableName;
        }

        /// <summary>
        /// 継承元フォームで使用しているプロパティ等の初期値設定.
        /// </summary>
        private void InitializeCommonProperty()
        {
            //広告費明細データを広告費明細詳細項目テーブル(TGA7MSHO)からを取得するか.
            //ExistsGA7MSHO = true;//取得する.
        }

        /// <summary>
        /// 各コントロールの初期設定.
        /// </summary>
        private void InitializeControlAcom()
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
            InitializeButton();
        }

        /// <summary>
        /// 受注登録内容(一覧)スプレッドの列単位の設定を行う.
        /// </summary>
        protected override void InitDesignForSpdJyutyuListColumns(Column col)
        {
            base.InitDesignForSpdJyutyuListColumns(col);

            if (col.Index == COLIDX_JLIST_KIKAN)
            {
                col.Width = 140;
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
            _spdKkhDetail_Sheet1.OperationMode = OperationMode.SingleSelect;                        //単一行選択.
            _spdKkhDetail_Sheet1.RowHeaderVisible = true;                                           //行ヘッダ表示.
            _spdKkhDetail_Sheet1.RowHeaderAutoText = HeaderAutoText.Numbers;                        //行ヘッダに行番号を表示.
            spdKkhDetail.ActiveSheet.ColumnHeader.Rows[0].Height = 30;

            ////********************************
            ////受注登録内容の選択行情報の取得.
            ////********************************
            //int rowIndex = _spdJyutyuList_Sheet1.ActiveRowIndex;
            //DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(rowIndex)];
            //Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            //Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);
            //string _gyomKbn = dataRow.hb1GyomKbn;
            //********************************
            //列毎の設定.
            //********************************
            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                //共通設定.
                col.Locked = true;          //セルの編集不可.
                col.AllowAutoFilter = true; //フィルタ機能を有効.
                col.AllowAutoSort = true;   //ソート機能を有効.

                if (col.Index == COLIDX_MLIST_MEDIA_CD)
                {
                    col.Label = "メディアコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 100;
                }
                else if (col.Index == COLIDX_MLIST_HATSUORKEISAI)
                {
                    col.Label = "発売日 or 掲載日";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 110;
                }
                else if (col.Index == COLIDX_MLIST_HACHU_NO)
                {
                    col.Label = "発注番号";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 80;
                }
                else if (col.Index == COLIDX_MLIST_HACHUGYO_NO)
                {
                    col.Label = "発注行番号";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 100;
                }
                else if (col.Index == COLIDX_MLIST_SEIKYUSHO_NO)
                {
                    col.Label = "請求書番号";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_SEIKYUSHOGYO_NO)
                {
                    col.Label = "請求書\n行番号";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 80;
                }
                else if (col.Index == COLIDX_MLIST_KYU_SEIKYUSHO_NO)
                {
                    col.Label = "旧請求書番号";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 100;
                }
                else if (col.Index == COLIDX_MLIST_SHOHIZEI_RITSU)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.ShowSeparator = true;

                    col.Label = "消費税率";
                    col.CellType = type;
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                    col.Width = 70;
                }
                else if (col.Index == COLIDX_MLIST_SHOHIZEI_GAKU)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.ShowSeparator = true;

                    col.Label = "消費税額";
                    col.CellType = type;
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_KINGAKU)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.ShowSeparator = true;

                    col.Label = "金額";
                    col.CellType = type;
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_KEISAITANKA)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.ShowSeparator = true;

                    col.Label = "掲載単価";
                    col.CellType = type;
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_NEBIKI_RITSU)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.ShowSeparator = true;

                    col.Label = "値引率";
                    col.CellType = type;
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                    col.Width = 70;
                }
                else if (col.Index == COLIDX_MLIST_NEBIKI_GAKU)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.ShowSeparator = true;

                    col.Label = "値引額";
                    col.CellType = type;
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_TORIRYOKIN)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.ShowSeparator = true;
                    type.MaximumValue = 99999999999;

                    col.Label = "取料金";
                    col.CellType = type;
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_TORIHIKISAKI_CD)
                {
                    col.Label = "取引先\nコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_SEIKYU_BUSHO)
                {
                    col.Label = "請求部署\nコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_SEIKYUSHO_HAKO_BI)
                {
                    col.Label = "請求書\n発行日";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_SHIHARAI_BI)     //支払日.
                {
                    col.Label = "支払日";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_SHOHIN_KBN)      //商品区分.
                {
                    col.Label = "商品区分";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_CM_BYOSU)     //CM秒数.
                {
                    col.Label = "CM秒数";
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_NAIYO_MEI)     //内容名称.
                {
                    col.Label = "内容名称";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_BANGUMI_MEI)     //番組名.
                {
                    col.Label = "番組名";
                    col.HorizontalAlignment = CellHorizontalAlignment.Left;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_KIKAN)     //期間.
                {
                    col.Label = "期間";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_SHOHIN_KBN_MEI)  //商品区分名称.
                {
                    col.Label = "商品区分\n名称";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_TEKIYO_CD)   //摘要コード.
                {
                    col.Label = "摘要\nコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_BAITAI_CD)   //媒体コード.
                {
                    col.Label = "媒体\nコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_TEN_NO)      //店番.
                {
                    col.Label = "店番";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_KEISAIBASHO_CD)      //掲載場所コード.
                {
                    col.Label = "掲載場所\nコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_SHUBETSU1_CD)    //種別１コード.
                {
                    col.Label = "種別1\nコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_SHUBETSU2_CD)    //種別２コード.

                {
                    col.Label = "種別2\nコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_IROZURI_CD)  //色刷コード.
                {
                    col.Label = "色刷\nコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_SIZE_CD) //サイズコード.
                {
                    col.Label = "サイズ\nコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_KEITAI_KBN_CD) //形態区分コード.
                {
                    col.Label = "形態区分コード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_KEITAI_KBN_MEI) //形態区分名称コード.
                {
                    col.Label = "形態区分名称";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_KOTSU_KEISAI_CD) //交通掲載コード.
                {
                    col.Label = "交通掲載コード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_KEISAI_KAISU) //掲載回数コード.
                {
                    col.Label = "掲載回数コード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_BIKO1)
                {
                    col.Label = "備考1";
                    col.HorizontalAlignment = CellHorizontalAlignment.Left;
                    col.Width = 120;
                }
                else if (col.Index == COLIDX_MLIST_BIKO2)
                {
                    col.Label = "備考2";
                    col.HorizontalAlignment = CellHorizontalAlignment.Left;
                    col.Width = 120;
                }
                else if (col.Index == COLIDX_MLIST_ANBUN)
                {
                    col.Label = "按分種別";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_JUCHU_NAIYO_KBN)   //受注内容区分.
                {
                    col.Label = "受注内容区分";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_TOROKU_DATE)
                {
                    col.Label = "登録年月日";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_HENKO_DATE)
                {
                    col.Label = "変更年月日";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_TORIKESHI_DATE)
                {
                    col.Label = "取消年月日";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_JUCHU_NO)
                {
                    col.Label = "受注No";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_JUCHU_MEISAI_NO)
                {
                    col.Label = "受注明細No";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_URIAGE_MEISAI_NO)
                {
                    col.Label = "売上明細No";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_SEIKYU_GENPYO_NO)
                {
                    col.Label = " 請求原票No";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_SOSHIN_JOKYO_KBN)
                {
                    col.Label = "送信状況区分";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_SHUTSURYOKU_DATE)
                {
                    col.Label = "出力日";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_NEBIKI_GYO_KBN)
                {
                    col.Label = "値引行区分";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                    col.Visible = false;
                }
                else
                {
                    _spdKkhDetail_Sheet1.RemoveColumns(col.Index, 1);
                }
            }
        }

        /// <summary>
        /// ボタンの初期化.
        /// </summary>
        private void InitializeButton()
        {
            //***************************************
            //ボタン類の使用可・不可設定.
            //***************************************
//          this.btnDelJyutyu.Enabled = true;       //受注削除.
            this.btnMerge.Visible = false;          //受注統合.
            this.btnSelectMerge.Visible = true;     //選択統合.
            this.btnMergeCancel.Visible = true;     //統合取消.
//          this.btnRegJyutyu.Enabled = true;       //受注新規.
            this.btnSelectMerge.Enabled = false;    //選択統合.
            this.btnJuchuTogo.Enabled = false;      //受注No統合.
            this.btnMeiNyuryoku.Enabled = false;    //明細入力.
            this.btnMeiToroku.Enabled = false;      //明細登録.
            this.btnMeiSakujo.Enabled = false;      //明細削除.
        }

        /// <summary>
        /// 種別ごとに表示対象外列の非表示処理を行う.
        /// </summary>
        protected void VisibleMeisaiColumns(string gyomKbn)
        {
            #region 業務区分で列の表示を制御.

            //業務区分で列の表示を制御する.
            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                if (col.Index == COLIDX_MLIST_MEDIA_CD) { col.Visible = true; }             //メディアコード.
                if (col.Index == COLIDX_MLIST_HATSUORKEISAI)                                //発売日or掲載日.
                {
                    // 新聞と雑誌は表示.
                    if (checkSNBN(gyomKbn) || checkZASI(gyomKbn))
                    {
                        col.Visible = true;
                    }
                    else
                    {
                        col.Visible = false;
                    }
                }
                if (col.Index == COLIDX_MLIST_HACHU_NO) { col.Visible = true; }             //発注番号.
                if (col.Index == COLIDX_MLIST_HACHUGYO_NO) { col.Visible = true; }          //発注行番号.
                if (col.Index == COLIDX_MLIST_SEIKYUSHO_NO) { col.Visible = true; }         //請求書番号.
                if (col.Index == COLIDX_MLIST_SEIKYUSHOGYO_NO) { col.Visible = true; }      //請求書行番号.
                if (col.Index == COLIDX_MLIST_KYU_SEIKYUSHO_NO) { col.Visible = true; }     //単価.
                if (col.Index == COLIDX_MLIST_SHOHIZEI_RITSU) { col.Visible = true; }       //消費税率.
                if (col.Index == COLIDX_MLIST_SHOHIZEI_GAKU) { col.Visible = true; }        //消費税額.
                if (col.Index == COLIDX_MLIST_KINGAKU) { col.Visible = true; }              //金額.
                if (col.Index == COLIDX_MLIST_KEISAITANKA)                                  //掲載単価.
                {
                    // 電波は表示しない.
                    if (checkDENP(gyomKbn))
                    {
                        col.Visible = false;
                    }
                    else
                    {
                        col.Visible = true;
                    }
                }
                if (col.Index == COLIDX_MLIST_NEBIKI_RITSU) { col.Visible = true; }         //値引率.
                if (col.Index == COLIDX_MLIST_NEBIKI_GAKU) { col.Visible = true; }          //値引額.
                if (col.Index == COLIDX_MLIST_TORIRYOKIN) { col.Visible = true; }           //取料金.
                if (col.Index == COLIDX_MLIST_TORIHIKISAKI_CD) { col.Visible = true; }      //取引先コード.
                if (col.Index == COLIDX_MLIST_SEIKYU_BUSHO) { col.Visible = true; }         //請求部署.
                if (col.Index == COLIDX_MLIST_SEIKYUSHO_HAKO_BI) { col.Visible = true; }    //請求書発行日.
                if (col.Index == COLIDX_MLIST_SHIHARAI_BI) { col.Visible = true; }          //支払日.
                if (col.Index == COLIDX_MLIST_CM_BYOSU)     //CM秒数.
                {
                    // 電波のみ表示.
                    if (checkDENP(gyomKbn))
                    {
                        col.Visible = true;
                    }
                    else
                    {
                        col.Visible = false;
                    }
                }
                if (col.Index == COLIDX_MLIST_NAIYO_MEI)    //内容名称.
                {
                    // 電波のみ表示.
                    if (checkDENP(gyomKbn))
                    {
                        col.Visible = true;
                    }
                    else
                    {
                        col.Visible = false;
                    }
                }
                if (col.Index == COLIDX_MLIST_BANGUMI_MEI)  //番組名.
                {
                    // 電波のみ表示.
                    if (checkDENP(gyomKbn))
                    {
                        col.Visible = true;
                    }
                    else
                    {
                        col.Visible = false;
                    }
                }
                if (col.Index == COLIDX_MLIST_KIKAN)        //期間.
                {
                    // 新聞・雑誌・電波は表示しない.
                    if (checkSNBN(gyomKbn) || checkZASI(gyomKbn) || checkDENP(gyomKbn))
                    {
                        col.Visible = false;
                    }
                    else
                    {
                        col.Visible = true;
                    }
                }
                if (col.Index == COLIDX_MLIST_SHOHIN_KBN) { col.Visible = true; }       //商品区分.
                if (col.Index == COLIDX_MLIST_SHOHIN_KBN_MEI) { col.Visible = true; }   //商品区分名称.
                if (col.Index == COLIDX_MLIST_TEKIYO_CD) { col.Visible = true; }        //摘要コード.
                if (col.Index == COLIDX_MLIST_BAITAI_CD) { col.Visible = true; }        //媒体コード.
                if (col.Index == COLIDX_MLIST_TEN_NO) { col.Visible = true; }           //店番.
                if (col.Index == COLIDX_MLIST_KEISAIBASHO_CD)   //掲載場所コード.
                {
                    // 新聞のみ表示.
                    if (checkSNBN(gyomKbn))
                    {
                        col.Visible = true;
                    }
                    else
                    {
                        col.Visible = false;
                    }
                }
                if (col.Index == COLIDX_MLIST_SHUBETSU1_CD)     //種別１コード.
                {
                    // 新聞のみ表示.
                    if (checkSNBN(gyomKbn))
                    {
                        col.Visible = true;
                    }
                    else
                    {
                        col.Visible = false;
                    }
                }
                if (col.Index == COLIDX_MLIST_SHUBETSU2_CD)     //種別２コード.
                {
                    // 新聞のみ表示.
                    if (checkSNBN(gyomKbn))
                    {
                        col.Visible = true;
                    }
                    else
                    {
                        col.Visible = false;
                    }
                }
                if (col.Index == COLIDX_MLIST_IROZURI_CD)       //色刷コード.
                {
                    // 新聞と雑誌は表示.
                    if (checkSNBN(gyomKbn) || checkZASI(gyomKbn))
                    {
                        col.Visible = true;
                    }
                    else
                    {
                        col.Visible = false;
                    }
                }
                if (col.Index == COLIDX_MLIST_SIZE_CD)          //サイズコード.
                {
                    // 新聞と雑誌は表示.
                    if (checkSNBN(gyomKbn) || checkZASI(gyomKbn))
                    {
                        col.Visible = true;
                    }
                    else
                    {
                        col.Visible = false;
                    }
                }
                if (col.Index == COLIDX_MLIST_KEITAI_KBN_CD)    //形態区分コード.
                {
                    // 電波のみ表示.
                    if (checkDENP(gyomKbn))
                    {
                        col.Visible = true;
                    }
                    else
                    {
                        col.Visible = false;
                    }
                }
                if (col.Index == COLIDX_MLIST_KEITAI_KBN_MEI)   //形態区分名称.
                {
                    // 電波のみ表示.
                    if (checkDENP(gyomKbn))
                    {
                        col.Visible = true;
                    }
                    else
                    {
                        col.Visible = false;
                    }
                }
                if (col.Index == COLIDX_MLIST_KOTSU_KEISAI_CD)  //交通掲載コード.
                {
                    // 新聞・雑誌・電波は表示しない.
                    if (checkSNBN(gyomKbn) || checkZASI(gyomKbn) || checkDENP(gyomKbn))
                    {
                        col.Visible = false;
                    }
                    else
                    {
                        col.Visible = true;
                    }
                }
                if (col.Index == COLIDX_MLIST_KEISAI_KAISU)
                {
                    // 新聞・雑誌・電波は表示しない.
                    if (checkSNBN(gyomKbn) || checkZASI(gyomKbn) || checkDENP(gyomKbn))
                    {
                        col.Visible = false;
                    }
                    else
                    {
                        col.Visible = true;
                    }
                }
                if (col.Index == COLIDX_MLIST_BIKO1) { col.Visible = true; }                //備考１.
                if (col.Index == COLIDX_MLIST_BIKO2) { col.Visible = true; }                //備考２.
                if (col.Index == COLIDX_MLIST_ANBUN) { col.Visible = true; }                //按分種別.
                if (col.Index == COLIDX_MLIST_JUCHU_NAIYO_KBN) { col.Visible = false; }     //受注内容区分.
                if (col.Index == COLIDX_MLIST_TOROKU_DATE) { col.Visible = true; }          //登録年月日.
                if (col.Index == COLIDX_MLIST_HENKO_DATE) { col.Visible = true; }           //変更年月日.
                if (col.Index == COLIDX_MLIST_TORIKESHI_DATE) { col.Visible = true; }       //取消年月日.
                //★暫定的に表示↓.
                //if (col.Index == COLIDX_MLIST_JUCHU_NO) { col.Visible = false; }            //受注No
                //if (col.Index == COLIDX_MLIST_JUCHU_MEISAI_NO) { col.Visible = false; }     //受注明細No
                //if (col.Index == COLIDX_MLIST_URIAGE_MEISAI_NO) { col.Visible = false; }    //売上明細No
                //if (col.Index == COLIDX_MLIST_SEIKYU_GENPYO_NO) { col.Visible = false; }    //請求原票No
                //if (col.Index == COLIDX_MLIST_SOSHIN_JOKYO_KBN) { col.Visible = false; }    //送信状況区分.
                //if (col.Index == COLIDX_MLIST_SHUTSURYOKU_DATE) { col.Visible = false; }    //出力日.
                //if (col.Index == COLIDX_MLIST_NEBIKI_GYO_KBN) { col.Visible = false; }      //値引行区分.
                if (col.Index == COLIDX_MLIST_JUCHU_NO) { col.Visible = false; }             //受注No.
                if (col.Index == COLIDX_MLIST_JUCHU_MEISAI_NO) { col.Visible = false; }      //受注明細No.
                if (col.Index == COLIDX_MLIST_URIAGE_MEISAI_NO) { col.Visible = false; }     //売上明細No.
                if (col.Index == COLIDX_MLIST_SEIKYU_GENPYO_NO) { col.Visible = false; }     //請求原票No.
                if (col.Index == COLIDX_MLIST_SOSHIN_JOKYO_KBN) { col.Visible = false; }     //送信状況区分.
                if (col.Index == COLIDX_MLIST_SHUTSURYOKU_DATE) { col.Visible = false; }     //出力日.
                if (col.Index == COLIDX_MLIST_NEBIKI_GYO_KBN) { col.Visible = false; }       //値引行区分.
                //★暫定的に表示↑.
            }

            #endregion 種別コードで列の表示を制御.
        }

        /// <summary>
        /// 明細登録処理.
        /// </summary>
        private void RegistDetailData()
        {
            // ダイアログの表示.
            base.ShowLoadingDialog();

            //サービスパラメータ用変数.
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();
            string esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            DateTime maxUpdDate = new DateTime();
            //if (_spdKkhDetail_Sheet1.RowCount == 0) { return; }

            //*********************************************
            //THB1DOWNの登録データ編集.
            //*********************************************
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(_spdJyutyuList_Sheet1.ActiveRowIndex)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);

            String hb1JyutNo = dataRow.hb1JyutNo;
            String hb1JyMeiNo = dataRow.hb1JyMeiNo;
            String hb1UrMeiNo = dataRow.hb1UrMeiNo;

            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();

            //thb1DownRow.hb1TimStmp = new DateTime();
            thb1DownRow.hb1UpdApl = AplId;
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
                    thb1DownRow.hb1KsnTnt = _naviParam.strEsqId.Trim();
                    //更新担当者名.
                    thb1DownRow.hb1KsnTntNm = _naviParam.strName.Trim();
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
                    thb1DownRow.hb1TrkTnt = _naviParam.strEsqId.Trim();
                    //登録者名.
                    thb1DownRow.hb1TrkTntNm = _naviParam.strName.Trim();
                    //更新者.
                    thb1DownRow.hb1KsnTnt = _naviParam.strEsqId.Trim();
                    //更新担当者名.
                    thb1DownRow.hb1KsnTntNm = _naviParam.strName.Trim();
                }
                //登録者が空の場合.
                else if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()))
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
                }
                else
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
            //データが統合されている場合、子の元となったデータに登録担当者、更新者を登録する.

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
                //AplId = "001";
                Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow addRow = dtThb2Kmei.NewTHB2KMEIRow();

                addRow.hb2TimStmp = new DateTime();
                addRow.hb2UpdApl = AplId;
                addRow.hb2UpdTnt = _naviParam.strEsqId;
                addRow.hb2EgCd = _naviParam.strEgcd;
                addRow.hb2TksKgyCd = _naviParam.strTksKgyCd;
                addRow.hb2TksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                addRow.hb2TksTntSeqNo = _naviParam.strTksTntSeqNo;
                addRow.hb2Yymm = dataRow.hb1Yymm;
                addRow.hb2JyutNo = dataRow.hb1JyutNo;
                addRow.hb2JyMeiNo = dataRow.hb1JyMeiNo;
                addRow.hb2UrMeiNo = dataRow.hb1UrMeiNo;
                // TODO：費目コードは空？.
                //addRow.hb2HimkCd = dataRow.hb1HimkCd;
                addRow.hb2HimkCd = dataRow.hb1HimkCd;
                //addRow.hb2HimkCd = "   ";
                //addRow.hb2Renbn = (i + 1).ToString("000");  明細登録件数拡張.
                addRow.hb2Renbn = (i + 1).ToString("0000");
                addRow.hb2DateFrom = " ";
                addRow.hb2DateTo = " ";
                addRow.hb2SeiGak = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KINGAKU].Value;
                addRow.hb2Hnnert = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NEBIKI_RITSU].Value;
                //addRow.hb2HnmaeGak = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KINGAKU].Value;
                addRow.hb2HnmaeGak = 0M;
                addRow.hb2NebiGak = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NEBIKI_GAKU].Value;

                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSHO_HAKO_BI].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Date1 = cellValue.ToString().Replace("/", string.Empty);
                }
                else
                {
                    addRow.hb2Date1 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHIHARAI_BI].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Date2 = cellValue.ToString().Replace("/", string.Empty);
                }
                else
                {
                    addRow.hb2Date2 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TOROKU_DATE].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Date3 = cellValue.ToString().Replace("/", string.Empty);
                }
                else
                {
                    addRow.hb2Date3 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HENKO_DATE].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Date4 = cellValue.ToString().Replace("/", string.Empty);
                }
                else
                {
                    addRow.hb2Date4 = " ";
                }

                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSHO_HAKO_BI].Value)) { addRow.hb2Date1 = " "; }
                //else { addRow.hb2Date1 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSHO_HAKO_BI].Value.ToString().Replace("/", string.Empty); }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHIHARAI_BI].Value)) { addRow.hb2Date2 = " "; }
                //else { addRow.hb2Date2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHIHARAI_BI].Value.ToString().Replace("/", string.Empty); }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TOROKU_DATE].Value)) { addRow.hb2Date3 = " "; }
                //else { addRow.hb2Date3 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TOROKU_DATE].Value.ToString().Replace("/", string.Empty); }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HENKO_DATE].Value)) { addRow.hb2Date4 = " "; }
                //else { addRow.hb2Date4 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HENKO_DATE].Value.ToString().Replace("/", string.Empty); }
                addRow.hb2Date5 = " ";
                addRow.hb2Date6 = " ";

                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SOSHIN_JOKYO_KBN].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Kbn1 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Kbn1 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NEBIKI_GYO_KBN].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Kbn2 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Kbn2 = " ";
                }

                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SOSHIN_JOKYO_KBN].Value)) { addRow.hb2Kbn1 = " "; }
                //else { addRow.hb2Kbn1 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SOSHIN_JOKYO_KBN].Value.ToString(); }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NEBIKI_GYO_KBN].Value)) { addRow.hb2Kbn2 = " "; }
                //else { addRow.hb2Kbn2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NEBIKI_GYO_KBN].Value.ToString(); }

                addRow.hb2Kbn3 = " ";

                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAI_CD].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Code1 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Code1 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_MEDIA_CD].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Code2 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Code2 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HACHU_NO].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Code3 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Code3 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HACHUGYO_NO].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Code4 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Code4 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYU_BUSHO].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Code5 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Code5 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TEKIYO_CD].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Code6 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Code6 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHOHIN_KBN_MEI].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name1 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name1 = " ";
                }

                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAI_CD].Value)) { addRow.hb2Code1 = " "; }
                //else{addRow.hb2Code1 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAI_CD].Value.ToString();}
                //if(string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_MEDIA_CD].Value)){addRow.hb2Code2 = " ";}
                //else{addRow.hb2Code2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_MEDIA_CD].Value.ToString();}
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HACHU_NO].Value)) { addRow.hb2Code3 = " "; }
                //else { addRow.hb2Code3 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HACHU_NO].Value.ToString(); }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HACHUGYO_NO].Value)) { addRow.hb2Code4 = " "; }
                //else { addRow.hb2Code4 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HACHUGYO_NO].Value.ToString(); }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYU_BUSHO].Value)) { addRow.hb2Code5 = " "; }
                //else { addRow.hb2Code5 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYU_BUSHO].Value.ToString(); }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TEKIYO_CD].Value)) { addRow.hb2Code6 = " "; }
                //else { addRow.hb2Code6 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TEKIYO_CD].Value.ToString(); }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHOHIN_KBN_MEI].Value)) { addRow.hb2Name1 = " "; }
                //else { addRow.hb2Name1 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHOHIN_KBN_MEI].Value.ToString(); }
                addRow.hb2Name2 = "（株）電通";

                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_JUCHU_NO].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name3 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name3 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_JUCHU_MEISAI_NO].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name4 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name4 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_URIAGE_MEISAI_NO].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name5 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name5 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYU_GENPYO_NO].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name6 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name6 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHUTSURYOKU_DATE].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name7 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name7 = " ";
                }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_JUCHU_NO].Value)) { addRow.hb2Name3 = " "; }
                //else { addRow.hb2Name3 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_JUCHU_NO].Value.ToString(); }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_JUCHU_MEISAI_NO].Value)) { addRow.hb2Name4 = " "; }
                //else { addRow.hb2Name4 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_JUCHU_MEISAI_NO].Value.ToString(); }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_URIAGE_MEISAI_NO].Value)) { addRow.hb2Name5 = " "; }
                //else { addRow.hb2Name5 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_URIAGE_MEISAI_NO].Value.ToString(); }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYU_GENPYO_NO].Value)) { addRow.hb2Name6 = " "; }
                //else { addRow.hb2Name6 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYU_GENPYO_NO].Value.ToString(); }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHUTSURYOKU_DATE].Value)) { addRow.hb2Name7 = " "; }
                //else { addRow.hb2Name7 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHUTSURYOKU_DATE].Value.ToString(); }

                addRow.hb2Name8 = " ";
                addRow.hb2Name9 = " ";
                addRow.hb2Name10 = " ";

                // 新聞.
                if (checkSNBN(listRow.gyomKbn))
                {
                    // 掲載場所コード.
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEISAIBASHO_CD].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name11 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name11 = "";
                    }

                    // 種別１コード.
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHUBETSU1_CD].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name12 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name12 = "";
                    }

                    // 種別２コード.
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHUBETSU2_CD].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name13 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name13 = "";
                    }

                    // 色刷コード.
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_IROZURI_CD].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name14 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name14 = "";
                    }

                    // サイズコード.
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SIZE_CD].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name15 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name15 = "";
                    }

                    // 備考1
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BIKO1].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name16 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name16 = "";
                    }

                    // 備考2
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BIKO2].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name17 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name17 = "";
                    }
                }
                // 雑誌.
                else if (checkZASI(listRow.gyomKbn))
                {
                    // 色刷コード.
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_IROZURI_CD].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name11 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name11 = "";
                    }

                    // サイズコード.
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SIZE_CD].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name12 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name12 = "";
                    }

                    // 備考1
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BIKO1].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name13 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name13 = "";
                    }

                    // 備考2
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BIKO2].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name14 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name14 = "";
                    }

                    addRow.hb2Name15 = "";

                    addRow.hb2Name16 = "";

                    addRow.hb2Name17 = "";
                }
                // 電波.
                else if (checkDENP(listRow.gyomKbn))
                {
                    // 形態区分コード.
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEITAI_KBN_CD].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name11 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name11 = "";
                    }

                    // 形態区分名称.
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEITAI_KBN_MEI].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name12 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name12 = "";
                    }

                    // CM秒数.
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_CM_BYOSU].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name13 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name13 = "";
                    }

                    // 内容名称.
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NAIYO_MEI].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name14 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name14 = "";
                    }

                    // 番組名.
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BANGUMI_MEI].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name15 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name15 = "";
                    }

                    // 備考1
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BIKO1].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name16 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name16 = "";
                    }

                    // 備考2
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BIKO2].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name17 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name17 = "";
                    }
                }
                // 交通.
                else
                {
                    // 交通掲載コード.
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KOTSU_KEISAI_CD].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name11 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name11 = "";
                    }

                    // 備考1
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BIKO1].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name12 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name12 = "";
                    }

                    // 備考2
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BIKO2].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name13 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name13 = "";
                    }

                    // 期間.
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KIKAN].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name14 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name14 = "";
                    }

                    // 掲載回数.
                    cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEISAI_KAISU].Value;
                    if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                    {
                        addRow.hb2Name15 = cellValue.ToString();
                    }
                    else
                    {
                        addRow.hb2Name15 = "";
                    }

                    addRow.hb2Name16 = "";

                    addRow.hb2Name17 = "";
                }

                //// 備考1
                //cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BIKO1].Value;
                //if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                //{
                //    addRow.hb2Name16 = cellValue.ToString();
                //}
                //else
                //{
                //    addRow.hb2Name16 = " ";
                //}

                //// 備考2
                //cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BIKO2].Value;
                //if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                //{
                //    addRow.hb2Name17 = cellValue.ToString();
                //}
                //else
                //{
                //    addRow.hb2Name17 = " ";
                //}

                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHOHIZEI_GAKU].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Kngk1 = (Decimal)cellValue;
                }
                else
                {
                    addRow.hb2Kngk1 = 0M;
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TORIRYOKIN].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Kngk2 = (Decimal)cellValue;
                }
                else
                {
                    addRow.hb2Kngk2 = 0M;
                }

                //addRow.hb2Kngk1 = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHOHIZEI_GAKU].Value;

                //addRow.hb2Kngk2 = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KINGAKU].Value;
                addRow.hb2Kngk3 = 0;

                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHOHIZEI_RITSU].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Ritu1 = (Decimal)cellValue;
                }
                else
                {
                    addRow.hb2Ritu1 = 0M;
                }


                //addRow.hb2Ritu1 = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHOHIZEI_RITSU].Value;
                addRow.hb2Ritu2 = 0;


                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSHO_NO].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota1 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Sonota1 = " ";
                }

                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSHOGYO_NO].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota2 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Sonota2 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHOHIN_KBN].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota3 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Sonota3 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TEN_NO].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota4 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Sonota4 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TORIHIKISAKI_CD].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota5 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Sonota5 = " ";
                }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSHO_NO].Value)) { addRow.hb2Sonota1 = " "; }
                //else { addRow.hb2Sonota1 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSHO_NO].Value.ToString(); }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSHOGYO_NO].Value)) { addRow.hb2Sonota2 = " "; }
                //else { addRow.hb2Sonota2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSHOGYO_NO].Value.ToString(); }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHOHIN_KBN].Value)) { addRow.hb2Sonota3 = " "; }
                //else { addRow.hb2Sonota3 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHOHIN_KBN].Value.ToString(); }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TEN_NO].Value)) { addRow.hb2Sonota4 = " "; }
                //else { addRow.hb2Sonota4 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TEN_NO].Value.ToString(); }
                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TORIHIKISAKI_CD].Value)) { addRow.hb2Sonota5 = " "; }
                //else { addRow.hb2Sonota5 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TORIHIKISAKI_CD].Value.ToString(); }

                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_JUCHU_NAIYO_KBN].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota6 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Sonota6 = " ";
                }

                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEISAITANKA].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota7 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Sonota7 = " ";
                }

                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEISAITANKA].Text)) { addRow.hb2Sonota7 = " "; }
                //else { addRow.hb2Sonota7 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEISAITANKA].Value.ToString(); }
                addRow.hb2Sonota8 = " ";

                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HATSUORKEISAI].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    //                  addRow.hb2Sonota9 = cellValue.ToString().Replace("/", "");
                    addRow.hb2Sonota9 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Sonota9 = " ";
                }

                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HATSUORKEISAI].Value)) { addRow.hb2Sonota9 = " "; }
                //else { addRow.hb2Sonota9 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HATSUORKEISAI].Value.ToString(); }

                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KYU_SEIKYUSHO_NO].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota10 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Sonota10 = " ";
                }

                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KYU_SEIKYUSHO_NO].Value)) { addRow.hb2Sonota10 = " "; }
                //else { addRow.hb2Sonota10 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KYU_SEIKYUSHO_NO].Value.ToString(); }

                if (_spdKkhDetail_Sheet1.RowCount >= 2)
                {
                    addRow.hb2BunFlg = "1";
                }
                else
                {
                    addRow.hb2BunFlg = " ";
                }

                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_ANBUN].Value;
                if (Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2MeihnFlg = cellValue.ToString();
                }
                else
                {
                    addRow.hb2MeihnFlg = " ";
                }

                //if (string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_ANBUN].Value)) { addRow.hb2MeihnFlg = " "; }
                //else { addRow.hb2MeihnFlg = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_ANBUN].Value.ToString(); }
                //addRow.hb2MeihnFlg = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_ANBUN].Value.ToString();
                addRow.hb2NebhnFlg = " ";

                dtThb2Kmei.AddTHB2KMEIRow(addRow);
            }
            dsDetail.THB2KMEI.Merge(dtThb2Kmei);
            {
                //更新日付最大値の判定.
                //統合されている場合.
                if (dataRow.hb1TouFlg == "1")
                {
                    //統合されている受注登録内容のデータから更新日付の最大値を取得.
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

                // 明細.
                String filter = "hb2JyutNo  = '" + hb1JyutNo + "' and " +
                                "hb2JyMeiNo = '" + hb1JyMeiNo + "' and " +
                                "hb2UrMeiNo = '" + hb1UrMeiNo + "'";

                Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow[] rows = (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow[])_dsDetail.THB2KMEI.Select(filter, "");

                foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow row in rows)
                {
                    if (maxUpdDate == null || maxUpdDate.CompareTo(row.hb2TimStmp) < 0)
                    {
                        maxUpdDate = row.hb2TimStmp;
                    }
                }
            }

            DetailProcessController controller = DetailProcessController.GetInstance();
            //UpdateDisplayDataServiceResult result = controller.UpdateDisplayData(esqId, dsDetail, maxUpdDate);
            DetailProcessController.UpdateDisplayDataParam param = new DetailProcessController.UpdateDisplayDataParam();
            param.esqId = esqId;
            param.dsDetail = dsDetail;
            param.maxUpdDate = maxUpdDate;
            param.TouKoudsDetail = TouKoudsDetail;
            UpdateDisplayDataServiceResult result = controller.UpdateDisplayData(param);

            if (result.HasError)
            {
                if (result.MessageCode == "LOCK-E0001")
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0148, null, "明細登録", MessageBoxButtons.OK);
                }
                else
                {
                    base.CloseLoadingDialog();
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0003, null, "明細登録", MessageBoxButtons.OK);
                }
                return;
            }

            // 広告費明細変更フラグを更新.
            base.kkhDetailUpdFlag = false;

            DisplayUpdate();

            base.CloseLoadingDialog();

            MessageUtility.ShowMessageBox(MessageCode.HB_I0012, null, "明細登録", MessageBoxButtons.OK);
        }

        /// <summary>
        /// 種別が新聞であるか.
        /// </summary>
        /// <param name="gyomKbn"></param>
        /// <returns></returns>
        private bool checkSNBN(String gyomKbn)
        {
            return gyomKbn.Equals(C_GYOM_SHINBUN);
        }

        /// <summary>
        /// 種別が雑誌であるか.
        /// </summary>
        /// <param name="gyomKbn"></param>
        /// <returns></returns>
        private bool checkZASI(String gyomKbn)
        {
            return gyomKbn.Equals(C_GYOM_ZASHI);
        }

        /// <summary>
        /// 種別が電波であるか.
        /// </summary>
        /// <param name="gyomKbn"></param>
        /// <returns></returns>
        private bool checkDENP(String gyomKbn)
        {
            return (
                gyomKbn.Equals(C_GYOM_RADIO) ||
                gyomKbn.Equals(C_GYOM_TV_TIME) ||
                gyomKbn.Equals(C_GYOM_TV_SPOT) ||
                gyomKbn.Equals(C_GYOM_EISEI_M)
            );
        }

        /// <summary>
        /// 種別が交通であるか.
        /// </summary>
        /// <param name="gyomKbn"></param>
        /// <returns></returns>
        private bool checkKOTU(String gyomKbn)
        {
            return (
                ( !checkSNBN(gyomKbn)  && !checkZASI(gyomKbn) && !checkDENP(gyomKbn))
            );
        }

        /// <summary>
        /// yyyyMMdd
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string FormatPeriodForYYYYMMDD(string str)
        {
            string ret = "";
            if (str.Length >= 16)
            {
                ret = str.Substring(0, 4) + "/" + str.Substring(4, 2) + "/" + str.Substring(6, 2) + " - " + str.Substring(8, 4) + "/" + str.Substring(12, 2) + "/" + str.Substring(14, 2);
            }
            else if (str.Length == 8)
            {
                ret = str.Substring(0, 4) + "/" +  str.Substring(4, 2) + "/" + str.Substring(6, 2);
            }
            else
            {
                return str;
            }

            return ret;
        }

        /// <summary>
        /// 受注No統合を行うメソッド.
        /// </summary>
        private void JuchuNoTogo()
        {
            /*======AplId======*/
            //String aplId = "00";
            /*=================*/
            int activerow = _spdJyutyuList_Sheet1.ActiveRow.Index;
            String Keyjyutno = _spdJyutyuList_Sheet1.Cells[activerow, COLIDX_JLIST_URIMEINO].Text.Substring(0, 10);
            String Keyjyumei = _spdJyutyuList_Sheet1.Cells[activerow, COLIDX_JLIST_URIMEINO].Text.Substring(11, 3);
            String Keyurimei = _spdJyutyuList_Sheet1.Cells[activerow, COLIDX_JLIST_URIMEINO].Text.Substring(15, 3);
            //親クラスの行っている共通処理を実行.(検索)
            // base.SearchJyutyuData();

            //同じ受注Noが統合されているかをチェックする.
            for (int i = 0; i < _spdJyutyuList_Sheet1.RowCount; i++)
            {
                //受注Noが同じ場合.
                if (Keyjyutno.Equals(_spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_URIMEINO].Text.Substring(0, 10)))
                {
                    if (_spdJyutyuList_Sheet1.RowFilter.IsRowFilteredOut(i))
                    {
                        // フィルタリングで見えなくなっている場合はエラーを表示する.
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0146, null, "明細登録", MessageBoxButtons.OK);
                        return;
                    }

                    //統合されている.
                    if (_spdJyutyuList_Sheet1.Rows[i].BackColor.Equals(Color.FromArgb(255, 255, 208)))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0015, null, "明細登録", MessageBoxButtons.OK);
                        return;
                    }
                }
            }

            DetailProcessController.UpTjyutnoDataParam upParam = new DetailProcessController.UpTjyutnoDataParam();
            //Update用パラメーターのセット.
            upParam.esqId = _naviParam.strEsqId;
            upParam.aplId = AplId;
            upParam.tksKgyCd = _naviParam.strTksKgyCd;
            upParam.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            upParam.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            //upParam.yymm = naviParam.StrYymm;
            upParam.yymm = base.spdJyutyuList.Sheets[0].Cells[0, COLIDX_JLIST_SEIYYMM].Text;
            upParam.jyutNo = Keyjyutno;
            upParam.GyoumKbn = Gykbn;
            upParam.Tmspkbn = Tmspkbn;
            upParam.jyMeiNo = Keyjyumei;
            upParam.urMeiNo = Keyurimei;

            DetailProcessController processController = DetailProcessController.GetInstance();

            //DetailProcessController.InTjyutnoDataParam param = new DetailProcessController.InTjyutnoDataParam();

            //Insert用パラメーターのセット.
            jyutNoTouInsVO vo = new jyutNoTouInsVO();
            vo._esqId = _naviParam.strEsqId;
            vo._aplId = AplId;
            vo._egCd = _naviParam.strEgcd;
            vo._tksKgyCd = _naviParam.strTksKgyCd;
            vo._tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            vo._tksTntSeqNo = _naviParam.strTksTntSeqNo;
            vo._YYMM = upParam.yymm;
            vo._keyJyutno = Keyjyutno;
            vo._keyJyMeiNo = Keyjyumei;
            vo._keyUriMeiNo = Keyurimei;

            //受注内容検索.
            FindJyutyuDataByCondServiceResult result = processController.FindJyutyuDataByCond(FindJyutyuDataCond);
            //選択されている受注内容.
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow[] dsDetail = (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow[])result.DetailDataSet.THB1DOWN.Select("hb1JyutNo = '" + Keyjyutno + "' AND hb1JyMeiNo = '" + Keyjyumei + "' AND hb1UrMeiNo = '" + Keyurimei + "'");

            if (dsDetail.Length != 1) { return;}

            //同じ受注Noのデータ.
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow[] dsDetails = (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow[])result.DetailDataSet.THB1DOWN.Select("hb1JyutNo = '" + Keyjyutno + "'");

            //請求金額、取り料金,消費税金額の合計値を取得.
            decimal Seigak = 0;  //請求金額.
            decimal ToriRyoukin = 0; //取り料金.
            decimal Syouhizeigak = 0;//消費税.
            decimal Nebiritu = 0;   //値引額.
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow Srow in dsDetails)
            {
                Seigak = Seigak + Srow.hb1SeiGak;
                ToriRyoukin = ToriRyoukin + Srow.hb1ToriGak;
                Syouhizeigak = Syouhizeigak + Srow.hb1SzeiGak;
                Nebiritu = Nebiritu + Srow.hb1NeviGak;
            }

            foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow row in dsDetail)
            {
                if (!String.IsNullOrEmpty(row.hb1HimkCd))
                {
                    vo._himkCd = row.hb1HimkCd.ToString();
                }
                else
                {
                    vo._himkCd = " ";
                }

                vo._gyomKbn = row.hb1GyomKbn.ToString();

                if (!String.IsNullOrEmpty(row.hb1MsKbn))
                {
                    vo._msKbn = row.hb1MsKbn.ToString();
                }
                else
                {
                    vo._msKbn = " ";
                }

                if (!String.IsNullOrEmpty(row.hb1TmspKbn))
                {
                    vo._tmsKbn = row.hb1TmspKbn.ToString();
                }
                else
                {
                    vo._tmsKbn = " ";
                }

                if (!String.IsNullOrEmpty(row.hb1KokKbn))
                {
                    vo._kokKbn = row.hb1KokKbn.ToString();
                }
                else
                {
                    vo._kokKbn = " ";
                }

                if (!String.IsNullOrEmpty(row.hb1SeiKbn))
                {
                    vo._seiKbn = row.hb1SeiKbn.ToString();
                }
                else
                {
                    vo._seiKbn = " ";
                }

                if (!String.IsNullOrEmpty(row.hb1SyoNo))
                {
                    vo._syoNo = row.hb1SyoNo.ToString();
                }
                else
                {
                    vo._syoNo = " ";
                }

                if (!String.IsNullOrEmpty(row.hb1KKNameKJ))
                {
                    vo._kknameKj = row.hb1KKNameKJ.ToString();
                }
                else
                {
                    vo._kknameKj = " ";
                }

                if (!String.IsNullOrEmpty(row.hb1EgGamenType))
                {
                    vo._egGamenType = row.hb1EgGamenType.ToString();
                }
                else
                {
                    vo._egGamenType = " ";
                }

                if (!String.IsNullOrEmpty(row.hb1KkakShanKbn))
                {
                    vo._kkakShanKbn = row.hb1KkakShanKbn.ToString();
                }
                else
                {
                    vo._kkakShanKbn = " ";
                }

                vo._toriRyouKin = ToriRyoukin.ToString();
                vo._seikyuKin = Seigak.ToString();
                vo._nebikiRitu = row.hb1NeviRitu.ToString();
                vo._nebikiGaku = Nebiritu.ToString();

                if (!String.IsNullOrEmpty(row.hb1SzeiKbn))
                {
                    vo._szeiKbn = row.hb1SzeiKbn.ToString();
                }
                else
                {
                    vo._szeiKbn = " ";
                }

                vo._szeiRitu = row.hb1SzeiRitu.ToString();
                vo._szeiGaku = Syouhizeigak.ToString();

                if (!String.IsNullOrEmpty(row.hb1HimkNmKJ))
                {
                    vo._himkNmkj = row.hb1HimkNmKJ.ToString();
                }
                else
                {
                    vo._himkNmkj = " ";
                }

                vo._field1 = row.hb1Field1.ToString();
                vo._field2 = row.hb1Field2.ToString();
                vo._field3 = row.hb1Field3.ToString();
                vo._field4 = row.hb1Field4.ToString();
                vo._field5 = row.hb1Field5.ToString();
                vo._field6 = row.hb1Field6.ToString();
                vo._field7 = row.hb1Field7.ToString();
                vo._field8 = row.hb1Field8.ToString();
                vo._field9 = row.hb1Field9.ToString();
                vo._field10 = row.hb1Field10.ToString();
                vo._field11 = row.hb1Field11.ToString();
                vo._field12 = row.hb1Field12.ToString();

                if (!row.Ishb1FileTimStmpNull())
                {
                    vo._fileTimStmp = row.hb1FileTimStmp;
                }
                else
                {
                    vo._fileTimStmp = "";
                }

                if (!row.Ishb1MeiTimStmpNull())
                {
                    vo._meiTimStmp = row.hb1MeiTimStmp;
                }
                else
                {
                    vo._meiTimStmp = "";
                }

                if (!String.IsNullOrEmpty(row.hb1JyutDelFlg))
                {
                    vo._jyutDelFlg = row.hb1JyutDelFlg.ToString();
                }
                else
                {
                    vo._jyutDelFlg = " ";
                }
            }

            //受注内容Update
            JyutNoTouUpdateServiceResult upresult = processController.UpdateJyutNoTou(upParam);
            if (upresult.HasError)
            {
                //throw new Exception();
                MessageUtility.ShowMessageBox(MessageCode.HB_E0006, null, "明細登録", MessageBoxButtons.OK);
                return;
            }

            //受注内容統合登録.
            JyutNoTouInsServiceResult InsResult = processController.InsjyutNoTou(vo);
            if (InsResult.HasError)
            {
                //throw new Exception();
                MessageUtility.ShowMessageBox(MessageCode.HB_E0006, null, "明細登録", MessageBoxButtons.OK);
                return;
            }

            //親クラスの行っている共通処理を実行.(検索)
            base.SearchJyutyuData();
            base.kkhDetailUpdFlag = false;

            MessageUtility.ShowMessageBox(MessageCode.HB_I0009, null, "明細登録", MessageBoxButtons.OK);
        }
        #endregion メソッド.
    }
}