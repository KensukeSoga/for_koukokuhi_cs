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
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Acom.Schema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Acom.ProcessController.Detail;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Acom.Utility;
using Isid.KKH.Common;
namespace Isid.KKH.Acom.View.Detail
{
    /// <summary>
    /// アコム明細入力画面.
    /// </summary>
    public partial class DetailInputAcom : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        #region 定数.
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

        #region マスタ.
        /// <summary>
        /// メディコードマスター取得キー：0006.
        /// </summary>
        public const string C_MST_MEDIA_CD = "0006";
        /// <summary>
        /// メディコード確認キー：0001.
        /// </summary>
        public const string C_MST_MEDIA_SYURUI = "0001";
        /* 2015/01/05 アコム消費税対応 HLC fujimoto ADD start */
        /// <summary>
        /// 消費税端数処理キー：0008.
        /// </summary>
        public const string C_MST_TAX_ROUND = "0008";
        /* 2015/01/05 アコム消費税対応 HLC fujimoto ADD end */
        #endregion マスタ.

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

        /// <summary>
        /// 背景色：薄いピンク.
        /// </summary>
        public static readonly Color C_BACK_COLOR_MROSE = Color.MistyRose;

        /// <summary>
        /// 背景色：水色.
        /// </summary>
        public static readonly Color C_BACK_COLOR_PBLUE = Color.PowderBlue;

        /// <summary>
        /// 背景色：灰色.
        /// </summary>
        public static readonly Color C_BACK_COLOR_LGRAY = Color.LightGray;
        #endregion 色.

        #region 送信状況区分.
        /// <summary>
        /// 送信状況区分：予約中.
        /// 編集不可、但し送信取消後編集可.
        /// </summary>
        public const string C_SOSHIN_JOKYO_KBN_YOYAKUCHU = "1";

        /// <summary>
        /// 送信状況区分：送信済.
        /// 編集不可、但し送信取消後編集可.
        /// </summary>
        public const string C_SOSHIN_JOKYO_KBN_SOSHINZUMI = "2";
        #endregion 送信状況区分.

        #region 値引.
        /// <summary>
        /// 値引通常(その他を使用).
        /// </summary>
        public const string C_MEDIACD_NEBIKI_TSUJO = "999000";

        /// <summary>
        /// 値引ラジオ(その他を使用).
        /// </summary>
        public const string C_MEDIACD_NEBIKI_RADIO = "999001";
        #endregion 値引.

        #region 明細初期値.
        /// <summary>
        /// 取引先コード.
        /// </summary>
        public const string C_MEISAI_SHOKICHI_TORI_CD = "6080101";

        /// <summary>
        /// 請求部署.
        /// </summary>
        public const string C_MEISAI_SHOKICHI_SEIKYU_BUSHO = "11328";
        #endregion 明細初期値.

        #region 消費税端数処理区分.
        /* 2015/01/05 アコム消費税対応 HLC fujimoto ADD start */
        /// <summary>
        /// 消費税端数処理：四捨五入.
        /// </summary>
        public const string TAX_ROUND = "01";
        /// <summary>
        /// 消費税端数処理：切り捨て.
        /// </summary>
        public const string TAX_ROUNDDOWN = "02";
        /// <summary>
        /// 消費税端数処理：切り上げ.
        /// </summary>
        public const string TAX_ROUNDUP = "03";
        /* 2015/01/05 アコム消費税対応 HLC fujimoto ADD end */
        #endregion 消費税端数処理区分.

        /// <summary>
        /// 登録終了.
        /// </summary>
        public const string TOUROKUEND = "END";
        #endregion 定数.

        #region メンバ変数.

        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;
        private int _rowDetailIdx = -1;
        private FarPoint.Win.Spread.SheetView _spdKkhDetail_Sheet1 = null;
        private string _mCurrentGyomuKbn = string.Empty;  // 受注一覧の業務区分.
        private string _mGyomKbn = string.Empty;
        //private string _mIro = C_BACK_COLOR_WHITE;

        /// <summary>
        /// メディアコードマスタ情報（キー）.
        /// </summary>
        private string[] _itemMediaiCd = null;
        /// <summary>
        /// メディアコードマスタ情報（名称）.
        /// </summary>
        private string[] _itemMediaMei = null;
        /// <summary>
        /// 電通コード.
        /// </summary>
        private string[] _dntscd = null;
        /// <summary>
        /// メディアコードマスタ情報データセット.
        /// </summary>
        private MasterMaintenance _dsMediaCd = null;
        /// <summary>
        /// 行を追加時のCellType.
        /// </summary>
        private TextCellType _txtType = new TextCellType();
        /// <summary>
        /// 行を追加時のCellType.
        /// </summary>
        private NumberCellType _numType = new NumberCellType();
        /// <summary>
        /// 行を追加時のCellType.
        /// </summary>
        private ComboBoxCellType _cmbType = new ComboBoxCellType();
        /// <summary>
        /// 英数8ケタのセルタイプ.
        /// </summary>
        private TextCellType _text8CellType = new TextCellType();
        /// <summary>
        /// 数字1桁のセルタイプ.
        /// </summary>
        private TextCellType _number1CellType = new TextCellType();
        /// <summary>
        /// 数字2桁のセルタイプ.
        /// </summary>
        private TextCellType _number2CellType = new TextCellType();
        /// <summary>
        /// 数字3桁のセルタイプ.
        /// </summary>
        private TextCellType _number3CellType = new TextCellType();
        /// <summary>
        /// 数字8桁のセルタイプ.
        /// </summary>
        private TextCellType _number8CellType = new TextCellType();

        /// <summary>
        /// 列ロックの状態.
        /// </summary>
        private bool _colmunLockState = true;

        /// <summary>
        /// 
        /// </summary>
        Isid.KKH.Common.KKHSchema.Detail.THB5HIKDataTable TB5hiktable = new Isid.KKH.Common.KKHSchema.Detail.THB5HIKDataTable();

        /// <summary>
        /// 選択列.
        /// </summary>
        private int _col = 0;

        /// <summary>
        /// 選択行.
        /// </summary>
        private int _row = 0;

        /// <summary>
        /// 消費税率.
        /// </summary>
        private Decimal _taxRate = 0.0M;

        /// <summary>
        /// ユーザーによる閉じる要求か（Navigator.Backwardの直前でtrueに設定する事）.
        /// </summary>
        private Boolean _userCloseRequest = false;

        /// <summary>
        /// KkhDateTimePicker用.
        /// </summary>
        private DataTable dt;

        /// <summary>
        /// KkhDateTimePicker用.
        /// </summary>
        private DataSet ds;

        /* 2015/01/05 アコム消費税対応 HLC fujimoto ADD start */
        /// <summary>
        /// 消費税端数処理.
        /// </summary>
        private string _taxRounding;
        /* 2015/01/05 アコム消費税対応 HLC fujimoto ADD end */
        #endregion メンバ変数.

        #region コンストラクタ.
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DetailInputAcom()
        {
            InitializeComponent();

            ds = new DataSet();
            dt = ds.Tables.Add("Table");
            dt.Columns.Add("DateTimeColumn", typeof(DateTime));
            dt.Columns[0].AllowDBNull = true;
            dt.Rows.Add(new object[] { DateTime.Now });
            dt.Rows.Add(new object[] { DBNull.Value });
            dtpShihaBi.DataBindings.Add("Value", ds, "Table.DateTimeColumn");
        }
        #endregion コンストラクタ.

        #region イベント.
        /// <summary>
        /// 戻るボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturn_Click(object sender , EventArgs e)
        {
            // ユーザーによる閉じる要求である.
            _userCloseRequest = true;
            Navigator.Backward(this, null, null, true);
        }

        /// <summary>
        /// 画面遷移するたびに発生.
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

                _dataRow = _naviParam.DataRow;
                _rowDetailIdx = _naviParam.RowDetailIndex;
                _spdKkhDetail_Sheet1 = _naviParam.SpdKkhDetail_Sheet1;
                _mGyomKbn = _naviParam.GyomKbn;

                // テキストボックスに設定する消費税率は受注から取得するように対応.
                _taxRate = _naviParam.DataRow.hb1SzeiRitu;
            }
        }

        /// <summary>
        /// フォームロードイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailAcom_Load(object sender , EventArgs e)
        {
            //デザインモードの場合.
            if (this.DesignMode)
            {
                //処理終了.
                return;
            }

            // 各コントロールの初期化.
            InitializeControl();

            // 各コントロールの編集.
            EditControl();

            //初期データの挿入.
            InsertInitialData();

            //テキストボックスにデータをセット.
            CalcDataSet();
        }

        /// <summary>
        /// 入力不可コントロールでキーボード操作時のイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNGNyuryoku_KeyPress(object sender , KeyPressEventArgs e)
        {
            if (( e.KeyChar < '0' || e.KeyChar > '9' ) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// FormShownイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailAcom_Shown(object sender , EventArgs e)
        {
            //***************************************.
            //Spreadに値を設定.
            //***************************************.
            InitializeDesignForSpdKkhDetail();

            //***************************************.
            //広告費明細の表示・非表示設定.
            //***************************************.
            //業務区分を取得.
            string _gyomKbn = _naviParam.GyomKbn;
            VisibleMeisaiColumns(_gyomKbn);
        }

        /// <summary>
        /// 発注番号取得クリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHachuBango_Click(object sender , EventArgs e)
        {
            //ローディング表示開始.
            base.ShowLoadingDialog();

            //明細行が存在しない場合.
            if (_spdMeiNyuryokAcom_Sheet1.Rows.Count == 0)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                MessageUtility.ShowMessageBox(MessageCode.HB_W0142, null, "発注番号取得エラー", MessageBoxButtons.OK);
                return;
            }

            String[] mediacd = new String[_spdMeiNyuryokAcom_Sheet1.Rows.Count];
            String hatyunum = txtHachuBango.Text.ToUpper();
            String irrowban = txtHachuGyoBango.Text;
            /*=======AplId=======*/
            String aplId = "00";
            /*==================*/

            //*************************
            //発注番号入力チェック.
            //*************************
            if (hatyunum.Length != 8)
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                MessageUtility.ShowMessageBox(MessageCode.HB_W0124, null, "発注番号取得エラー", MessageBoxButtons.OK);
                return;
            }

            if (!string.IsNullOrEmpty(irrowban) && irrowban.Length != 3)
            {
                if (irrowban.Length == 1)
                {
                    irrowban = "00" + irrowban;
                    txtHachuGyoBango.Text = "00" + txtHachuGyoBango.Text;
                }
                else if (irrowban.Length == 2)
                {
                    irrowban = "0" + irrowban;
                    txtHachuGyoBango.Text = "0" + txtHachuGyoBango.Text;
                }
            }

            //****************************
            //メディアコード入力チェック.
            //****************************
            for (int i = 0; i < _spdMeiNyuryokAcom_Sheet1.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_MEDIA_CD].Text))
                {
                    //ローディング表示終了.
                    base.CloseLoadingDialog();
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0125, null, "明細入力", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    mediacd[i] = _spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_MEDIA_CD].Text.Substring(0, 6);
                }
            }

            DetailAcomProcessController detailprocesscontroller = DetailAcomProcessController.GetInstance();
            FindHatyuNumServiceResult result = detailprocesscontroller.FindHatyuNum(_naviParam.strEsqId,
                                                                                    aplId,
                                                                                    _naviParam.strEgcd,
                                                                                    _naviParam.strTksKgyCd,
                                                                                    _naviParam.strTksBmnSeqNo,
                                                                                    _naviParam.strTksTntSeqNo,
                                                                                    hatyunum,
                                                                                    irrowban
                                                                                    );

            //エラーの場合.
            if (result.HasError)
            {
                base.CloseLoadingDialog();
                return;
            }
            Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow[] thb5HikRow;
            if (string.IsNullOrEmpty(irrowban))
            {
                thb5HikRow = (Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow[])result.DetailDataSet.THB5HIK.Select("", "");
            }
            else
            {
                thb5HikRow = (Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow[])result.DetailDataSet.THB5HIK.Select("IrRowban = '" + irrowban + "'");
            }

            if (thb5HikRow.Length == 0)
            {
                base.CloseLoadingDialog();
                MessageUtility.ShowMessageBox(MessageCode.HB_W0139, null, "明細入力", MessageBoxButtons.OK);
                return;
            }

            //メンバ変数で保存.
            TB5hiktable.Clear();
            TB5hiktable.Merge(result.DetailDataSet.THB5HIK);

            //************************************
            //発注番号の妥当性チェック.
            //************************************

            //string iraiYYmm = _spdMeiNyuryokAcom_Sheet1.Cells[0, COLIDX_MLIST_HATSUORKEISAI].Text.ToString().Substring(0, 6);
            string iraiYYmm = _naviParam.StrYymm;
            foreach (Common.KKHSchema.Detail.THB5HIKRow datourow in thb5HikRow)
            {
                if (datourow.IrYymm.Equals(iraiYYmm))
                {
                    break;
                }
                else
                {
                    //ローディング表示終了.
                    base.CloseLoadingDialog();
                    DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0126, null, "明細入力", MessageBoxButtons.YesNo);
                    //請求年月が違う場合、処理続行の確認.
                    if (check == DialogResult.Yes)
                    {
                        //ローディング表示開始.
                        base.ShowLoadingDialog();
                        break;
                    }
                    else
                    {
                        base.CloseLoadingDialog();
                        return;
                    }
                }
            }

            //***********************************************************
            //エラーメッセージを行単位ではなく全体で1回の表示にする.
            //***********************************************************

            string errorMsg = string.Empty; //エラーメッセージ格納.
            int lngErrcnt = 0;

            for (int k = 0; k < _spdMeiNyuryokAcom_Sheet1.Rows.Count; k++)
            {
                // 値引行は処理対象外とする.
                if (!String.Equals(_spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_NEBIKI_GYO_KBN].Text, "0"))
                {
                    continue;
                }

                // 発注行番号が設定されている場合は、選択行のみを処理対象とする.
                if ( !String.IsNullOrEmpty(irrowban) &&  !IsSelectedRow(k, _spdMeiNyuryokAcom_Sheet1))
                {
                    continue;
                }

                String resultMsg = String.Empty;
                bool errorFlg = false;          //エラーかどうかを判断.
                int gaitouindex = 0;            //発注の該当インデックス.

                //新聞.
                if (_mGyomKbn.Equals(C_GYOM_SHINBUN))
                {
                    resultMsg = shinBunCheck(k, irrowban, out errorFlg, out gaitouindex);
                }
                //雑誌.
                else if (_mGyomKbn.Equals(C_GYOM_ZASHI))
                {
                    resultMsg = zashiCheck(k, irrowban, out errorFlg, out gaitouindex);
                }
                //上記以外.
                else
                {
                    resultMsg = sonotaCheck(k, irrowban, out errorFlg, out gaitouindex);
                }

                //エラーがある場合.
                if (errorFlg)
                {
                    if (!String.IsNullOrEmpty(errorMsg))
                    {
                        errorMsg += "\n";
                    }

                    // 既にエラー数が5個以上であればメッセージを省略する.
                    if (lngErrcnt >= 5)
                    {
                        errorMsg += "…他多数あり";
                        break;
                    }

                    errorMsg += resultMsg;
                    lngErrcnt++;
                }
            }

            // エラーが発生している場合.
            if (!String.IsNullOrEmpty(errorMsg))
            {
                //ローディング表示終了.
                base.CloseLoadingDialog();
                MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { errorMsg }, "明細入力", MessageBoxButtons.OK);
                return;
            }

            //*************************************************
            //スプレッドの挿入.
            //*************************************************

            for (int k = 0; k < _spdMeiNyuryokAcom_Sheet1.Rows.Count; k++)
            {
                // 値引行は処理対象外とする.
                if (!String.Equals(_spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_NEBIKI_GYO_KBN].Text, "0"))
                {
                    continue;
                }

                // 発注行番号が設定されている場合は、選択行のみを処理対象とする.
                if (( !String.IsNullOrEmpty(irrowban) ) &&  !IsSelectedRow(k, _spdMeiNyuryokAcom_Sheet1))
                {
                    continue;
                }

                bool errorFlg = false;
                int gaitouindex = 0;

                //新聞.
                if (_mGyomKbn.Equals(C_GYOM_SHINBUN))
                {
                    shinBunCheck(k, irrowban, out errorFlg, out gaitouindex);
                }
                //雑誌.
                else if (_mGyomKbn.Equals(C_GYOM_ZASHI))
                {
                    zashiCheck(k, irrowban, out errorFlg, out gaitouindex);
                }
                //上記以外.
                else
                {
                    sonotaCheck(k, irrowban, out errorFlg, out gaitouindex);
                }

                //依頼番号.
                _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_HACHU_NO].Value = thb5HikRow[gaitouindex].IrBan.ToString();
                //摘要コード.
                _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_TEKIYO_CD].Value = thb5HikRow[gaitouindex].TekiCd.ToString();
                //依頼行番号.
                _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_HACHUGYO_NO].Value = thb5HikRow[gaitouindex].IrRowBan.ToString();
                //媒体コード.
                _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_BAITAI_CD].Value = thb5HikRow[gaitouindex].Sybt.ToString();
                //商品区分.
                _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_SHOHIN_KBN].Value = thb5HikRow[gaitouindex].SyohiKbn.ToString() + thb5HikRow[gaitouindex].SaiKbn.ToString();
                //商品名称.
                string syouhinName = syohinName(thb5HikRow[gaitouindex].SyohiKbn.ToString());
                if (syouhinName.Equals("error"))
                {
                    //ローディング表示終了.
                    base.CloseLoadingDialog();
                    return;
                }
                _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_SHOHIN_KBN_MEI].Value = syouhinName;
                //店番.
                _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_TEN_NO].Value = thb5HikRow[gaitouindex].TenCd.ToString();
                //按分種別.
                _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_ANBUN].Value = thb5HikRow[gaitouindex].AnSyube.ToString();
                //登録年月日.
                _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_TOROKU_DATE].Value = thb5HikRow[gaitouindex].TouDate.ToString();
                //変更年月日.
                _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_HENKO_DATE].Value = thb5HikRow[gaitouindex].HenDate.ToString();
                //取消年月日.
                _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_TORIKESHI_DATE].Value = thb5HikRow[gaitouindex].TorDate.ToString();
                ////掲載単価.
                //if (!string.IsNullOrEmpty(thb5HikRow[gaitouindex].KeisaiTanka.ToString()))
                //{
                //    double tanka = double.Parse(thb5HikRow[gaitouindex].KeisaiTanka.ToString());
                //    _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_KEISAITANKA].Value = Math.Truncate(tanka);
                //}
                _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_KEISAITANKA].Value = Math.Truncate(KKHUtility.DecParse(thb5HikRow[gaitouindex].KeisaiTanka.ToString()));
                //備考1
                _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_BIKO1].Value = thb5HikRow[gaitouindex].Bikou1.ToString();
                //備考2
                _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_BIKO2].Value = thb5HikRow[gaitouindex].Bikou2.ToString();

                switch (thb5HikRow[gaitouindex].Sybt.Trim().ToString())
                {
                    case KkhConstAcom.MediaKindCode.SYBT_SNBN:
                        //掲載場所コード.
                        _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_KEISAIBASHO_CD].Value = thb5HikRow[gaitouindex].PlaceCd.ToString();
                        //種別コード1
                        _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_SHUBETSU1_CD].Value = thb5HikRow[gaitouindex].Sybt1Cd.ToString();
                        //種別コード2
                        _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_SHUBETSU2_CD].Value = thb5HikRow[gaitouindex].Sybt2Cd.ToString();
                        //色刷コード.
                        _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_IROZURI_CD].Value = thb5HikRow[gaitouindex].ColorCd.ToString();
                        //サイズコード.
                        _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_SIZE_CD].Value = thb5HikRow[gaitouindex].SpaceCd.ToString();
                        break;

                    case KkhConstAcom.MediaKindCode.SYBT_ZASI:
                        //色刷コード.
                        _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_IROZURI_CD].Value = thb5HikRow[gaitouindex].ColorCd.ToString();
                        //サイズコード.
                        _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_SIZE_CD].Value = thb5HikRow[gaitouindex].SizeCd.ToString();
                        break;

                    case KkhConstAcom.MediaKindCode.SYBT_DENP:
                        //形態区分コード.
                        _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_KEITAI_KBN_CD].Value = thb5HikRow[gaitouindex].KeitaiCd.ToString();
                        //形態区分名称.
                        _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_KEITAI_KBN_MEI].Value = thb5HikRow[gaitouindex].KeitaiName.ToString();
                        break;

                    case KkhConstAcom.MediaKindCode.SYBT_KOTU:
                        //交通掲載.
                        _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_KOTSU_KEISAI_CD].Value = thb5HikRow[gaitouindex].KotuKeiCd.ToString();
                        //交通回数.
                        _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_KEISAI_KAISU].Value = thb5HikRow[gaitouindex].KeisaiCnt.ToString();
                        //期間.
                        if (( _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_KIKAN].Value == null ) || ( String.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_KIKAN].Value.ToString()) ))
                        {
                            //設定値格納用.
                            String strKikan = null;

                            //依頼月取得.
                            int intMth = KKHUtility.IntParse(thb5HikRow[gaitouindex].IrYymm.ToString().Substring(4, 2));

                            for (int i = 0; i < (thb5HikRow[gaitouindex].Keisai.ToString().Trim().Length / 2); i++)
                            {
                                //掲載日取得.
                                int intKari = KKHUtility.IntParse(thb5HikRow[gaitouindex].Keisai.ToString().Substring(i * 2, 2));

                                if (!String.Equals(intKari.ToString(), "0"))
                                {
                                    if (String.IsNullOrEmpty(strKikan))
                                    {
                                        strKikan = strKikan + intMth.ToString() + "/" + intKari.ToString() + "-" + intMth.ToString() + "/*";
                                    }
                                    else
                                    {
                                        strKikan = strKikan + "," + intMth.ToString() + "/" + intKari.ToString() + "-" + intMth.ToString() + "/*";
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }

                            //値を設定.
                            _spdMeiNyuryokAcom_Sheet1.Cells[k, COLIDX_MLIST_KIKAN].Value = strKikan;
                        }

                        break;
                }
            }

            //ローディング表示終了.
            base.CloseLoadingDialog();
        }

        /// <summary>
        /// 値引ゼロボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMebikiZero_Click(object sender , EventArgs e)
        {
            //行数分処理する.
            for (int row = 0; row < _spdMeiNyuryokAcom_Sheet1.RowCount; row++)
            {
                //ロックがかかってる行の場合.
                if (_spdMeiNyuryokAcom_Sheet1.Rows[row].Locked)
                {
                    //メッセージを出力.
                    if (DialogResult.OK == MessageUtility.ShowMessageBox(MessageCode.HB_W0050
                        , null
                        , "編集警告"
                        , MessageBoxButtons.OKCancel))
                    {
                        //「はい」の場合、処理を抜ける.
                        break;
                    }
                    else
                    {
                        //「いいえ」の場合、処理を中断.
                        return;
                    }
                }
            }

            //行数分処理する.
            for (int row = 0; row < _spdMeiNyuryokAcom_Sheet1.RowCount; row++)
            {
                // 値引行は処理対象外.

                if( _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_NEBIKI_GYO_KBN].Text == "1")
                {
                    continue;
                }

                //行のロックを解除する.
                _spdMeiNyuryokAcom_Sheet1.Rows[row].Locked = false;

                //"0"をセットする.
                _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_NEBIKI_RITSU].Text = "0";   //値引率.
                _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_NEBIKI_GAKU].Text = "0";    //値引額.

                //取料金に金額をセットする.
                _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_TORIRYOKIN].Text
                                            = _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KINGAKU].Text;
            }

            //テキストボックスにデータをセット.
            CalcDataSet();

            //if (_spdMeiNyuryokAcom.ActiveSheet.Protect)
            //{
            //    string message = "請求データ送信済みの行が存在します。編集する場合は注意が必要です。ロックを解除し、値引ゼロ処理を続行しますか？";
            //    if (DialogResult.Yes != MessageBox.Show(message , "編集警告" , MessageBoxButtons.YesNo , MessageBoxIcon.Warning))
            //    {
            //        return;
            //    }

            //}

            //行数分処理する.
            //for (int i = 0 ; i < _spdMeiNyuryokAcom_Sheet1.RowCount ; i++)
            //{
            //    _spdMeiNyuryokAcom_Sheet1.Cells[i , COLIDX_MLIST_NEBIKI_RITSU].Text = "0";   //値引率.
            //    _spdMeiNyuryokAcom_Sheet1.Cells[i , COLIDX_MLIST_NEBIKI_GAKU].Text = "0";    //値引額.
            //}
        }

        /// <summary>
        /// メディアコード一括ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMediaCdIkat_Click(object sender, EventArgs e)
        {
            //行数分処理する.
            for (int row = 0; row < _spdMeiNyuryokAcom_Sheet1.RowCount; row++)
            {
                //ロックがかかっていない行のみ処理する.
                if (!_spdMeiNyuryokAcom_Sheet1.Rows[row].Locked)
                {
                    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_MEDIA_CD].Text = cmbMediaCd.Text;
                }
            }
        }

        /// <summary>
        /// 支払日一括ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShihaBiIkat_Click(object sender, EventArgs e)
        {
            //行数分処理する.
            for (int row = 0; row < _spdMeiNyuryokAcom_Sheet1.RowCount; row++)
            {
                //ロックがかかっていない行のみ処理する.
                if (!_spdMeiNyuryokAcom_Sheet1.Rows[row].Locked)
                {
                    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SHIHARAI_BI].Text = dtpShihaBi.Text;
                }
            }
        }

        /// <summary>
        /// 値引追加ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNebikiTsuika_Click(object sender , EventArgs e)
        {
            string _hachuNoRow1 = string.Empty;     //1行目の発注番号.
            string _seishoNoRow1 = string.Empty;    //1行目の請求書番号.
            string _seishoGyoNo = string.Empty;    //1行目の請求書行番号.
            decimal _dNebikiGaku = 0M;
            int _msCnt = 2;     //メッセージ用カウンター.
            object _shohizeiRitsu = null;   //消費税率.
            object _nebikiRitsu = null;   //値引率.
            int _maxRowIdx = _spdMeiNyuryokAcom_Sheet1.Rows.Count - 1;  //最大インデックス.
            int _maxRowCnt = _spdMeiNyuryokAcom_Sheet1.Rows.Count;      //行数.
            //double trRyokin = 0;
            //double skGokei = 0;

            //明細行が存在しない場合(現行と同一のエラーメッセージ).
            if (_maxRowCnt < 1)
            {
                //メッセージを出力.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0059
                    , null
                    , "1行目-発注番号未入力エラー"
                    , MessageBoxButtons.OK);

                //処理終了.
                return;
            }

            //***********************************.
            //値引行が既に追加されているか確認.
            //***********************************.
            for (int row = 0 ; row < _maxRowCnt ; row++)
            {
                //値引行区分が"1"の行がある場合.
                if (_spdMeiNyuryokAcom_Sheet1.Cells[row , COLIDX_MLIST_NEBIKI_GYO_KBN].Text.Equals("1"))
                {
                    //メッセージを出力.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0024
                        , null
                        , "既存値引行あり"
                        , MessageBoxButtons.OK);

                    //処理終了.
                    return;
                }
            }

            //***********************************.
            //1行目の発注番号が未入力の場合.
            //***********************************.
            if (string.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[0 , COLIDX_MLIST_HACHU_NO].Text))
            {
                //メッセージを出力.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0059
                    , null
                    , "1行目-発注番号未入力エラー"
                    , MessageBoxButtons.OK);

                //処理終了.
                return;
            }
            else
            {
                //1行目の発注番号を保持.
                _hachuNoRow1 = _spdMeiNyuryokAcom_Sheet1.Cells[0 , COLIDX_MLIST_HACHU_NO].Text;
            }

            //***********************************.
            //1行目の請求書番号が未入力の場合.
            //***********************************.
//          if (string.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[0 , COLIDX_MLIST_SEIKYUSHO_NO].Text))
//          {
//              //メッセージを出力.
//              MessageUtility.ShowMessageBox(MessageCode.HB_W0058
//                  , null
//                  , "1行目-請求書番号未入力エラー"
//                  , MessageBoxButtons.OK);
//
//              //処理終了.
//              return;
//          }
//          else
//          {
//              //1行目の請求書番号を保持.
//              _seishoNoRow1 = _spdMeiNyuryokAcom_Sheet1.Cells[0 , COLIDX_MLIST_SEIKYUSHO_NO].Text;
//          }
            //1行目の請求書番号を保持.
            _seishoNoRow1 = _spdMeiNyuryokAcom_Sheet1.Cells[0 , COLIDX_MLIST_SEIKYUSHO_NO].Text;

            //***********************************.
            //1行目の値引額を取得する.
            //***********************************.
            //値引額が未入力ではない場合.
            if (!string.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[0 , COLIDX_MLIST_NEBIKI_GAKU].Text))
            {
                //1行目の値引額を保持.
                _dNebikiGaku = decimal.Parse(_spdMeiNyuryokAcom_Sheet1.Cells[0 , COLIDX_MLIST_NEBIKI_GAKU].Text.ToString());
            }

            ////***********************************.
            ////1行目の請求書行番号が未入力か.
            ////***********************************.
            //if (string.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[0 , COLIDX_MLIST_SEIKYUSHOGYO_NO].Text))
            //{
            //    //メッセージを出力.
            //    string message = "値引追加は全行に一意の請求書行番号を設定する必要があります。";
            //    MessageBox.Show(message
            //        , "1行目-請求書行番号未入力エラー"
            //        , MessageBoxButtons.OK
            //        , MessageBoxIcon.Error);

            //    //処理終了.
            //    return;
            //}
            //else
            //{
            //    //1行目の請求書行番号を保持.
            //    _seishoGyoNo = _spdMeiNyuryokAcom_Sheet1.Cells[0 , COLIDX_MLIST_SEIKYUSHOGYO_NO].Text;
            //}

            //1行目の請求書行番号を保持.
            _seishoGyoNo = _spdMeiNyuryokAcom_Sheet1.Cells[0 , COLIDX_MLIST_SEIKYUSHOGYO_NO].Text;

            //値引額は明細単位で算出したものを加算する.

            //*************************************************************************.
            //2行目以降、発注番号、請求書番号、請求書行番号が1行目と同一かを確認.
            //*************************************************************************.
            for (int row = 1 ; row < _maxRowCnt ; row++)
            {
                //*************************.
                //発注番号が未入力の場合.
                //*************************.
                //if (string.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[row , COLIDX_MLIST_HACHU_NO].Text))
                //{
                //    _msCnt = row + 1;
                //    //メッセージを出力.
                //    string message = "値引追加は全行に一意の発注番号を設定する必要があります。";
                //    MessageBox.Show(message
                //        , _msCnt.ToString() + "行目-発注番号未入力エラー"
                //        , MessageBoxButtons.OK
                //        , MessageBoxIcon.Error);

                //    //処理終了.
                //    return;
                //}

                //*****************************************************.
                //発注番号が一意(1行目と同一)ではない場合.
                //*****************************************************.
                if (!_spdMeiNyuryokAcom_Sheet1.Cells[row , COLIDX_MLIST_HACHU_NO].Text.Equals(_hachuNoRow1))
                {
                    _msCnt = row + 1;
                    //メッセージを出力.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0059
                        , null
                        , _msCnt + "行目-発注番号一意エラー"
                        , MessageBoxButtons.OK);

                    //処理終了.
                    return;
                }

                //*********************************************.
                //請求書番号が一意(1行目と同一)ではない場合.
                //*********************************************.
                if (!_spdMeiNyuryokAcom_Sheet1.Cells[row , COLIDX_MLIST_SEIKYUSHO_NO].Text.Equals(_seishoNoRow1))
                {
                    _msCnt = row + 1;
                    //メッセージを出力.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0058
                        , null
                        , _msCnt + "行目-請求書番号一意エラー"
                        , MessageBoxButtons.OK);

                    //処理終了.
                    return;
                }

                //**************************************.
                //保持している請求書行番号がある場合.
                //**************************************.
                if (_seishoGyoNo.Length == 0)
                {
                    //請求書行番号が未入力ではない場合.
                    if (!string.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SEIKYUSHOGYO_NO].Text.ToString()))
                    {
                        //現在行の請求書行番号を保持する.
                        _seishoGyoNo = _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SEIKYUSHOGYO_NO].Text;
                    }
                }
                else
                {
                    //請求書行番号が未入力ではない場合.
                    if (!string.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SEIKYUSHOGYO_NO].Text.ToString()))
                    {
                        //現在行の請求書行番号が保持している請求書行番号より大きい場合.
                        if (decimal.Parse(_seishoGyoNo) <
                            decimal.Parse(_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SEIKYUSHOGYO_NO].Text.ToString()))
                        {
                            //現在行の請求書行番号を保持する.
                            _seishoGyoNo = _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SEIKYUSHOGYO_NO].Text;
                        }
                    }
                }

                //*******************.
                //値引額を加算する.
                //*******************.
                //値引額が未入力ではない場合.
                if (!string.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[row , COLIDX_MLIST_NEBIKI_GAKU].Text))
                {
                    _dNebikiGaku += decimal.Parse(_spdMeiNyuryokAcom_Sheet1.Cells[row , COLIDX_MLIST_NEBIKI_GAKU].Text.ToString());
                }
            }

            //*********************.
            //消費税率を取得する.
            //*********************.
            //消費税率が未入力ではない場合.
            if (!string.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_SHOHIZEI_RITSU].Text))
            {
                _shohizeiRitsu = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_SHOHIZEI_RITSU].Text;
            }
            else
            {
                _shohizeiRitsu = 0;
            }

            //*********************.
            //値引率を取得する.
            //*********************.
            //値引率が未入力ではない場合.
            if (!string.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_NEBIKI_RITSU].Text))
            {
                _nebikiRitsu = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_NEBIKI_RITSU].Text;
            }
            else
            {
                _nebikiRitsu = 0;
            }

            //メッセージを出力.
            if (DialogResult.Cancel == MessageUtility.ShowMessageBox(MessageCode.HB_C0010
                , new string[] { _shohizeiRitsu.ToString() , _nebikiRitsu.ToString()}
                , "編集警告"
                , MessageBoxButtons.OKCancel))
            {
                //「いいえ」の場合、処理を中断.
                return;
            }

            //*********************.
            //CellTypeの設定.
            //*********************.
            AddSheetRow(_maxRowIdx + 1);

            ////*********************.
            ////値引行を追加する.
            ////*********************.
            //_spdKkhDetail_Sheet1.Rows.Add(_maxRowIdx + 1 , 1);

            ////*********************.
            ////CellTypeの設定.
            ////*********************.
            ////Text.
            //_spdKkhDetail_Sheet1.Rows[_maxRowIdx + 1].CellType = new TextCellType();

            ////Number.
            //_numType.DecimalPlaces = 0;
            //_numType.ShowSeparator = true;

            ////Combo.
            //_cmbType.ItemData = _itemMediaiCd;
            //_cmbType.Items = _itemMediaMei;
            //_cmbType.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
            //_cmbType.Editable = false;

            //*********************.
            //各項目を設定.
            //*********************.
            #region 項目設定.
            //メディアコード.
            //Comboにする.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_MEDIA_CD].Locked = false;
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_MEDIA_CD].HorizontalAlignment = CellHorizontalAlignment.Left;

            //業務区分を取得.
            string _gyomKbn = _naviParam.GyomKbn;
            if (_gyomKbn.Equals(C_GYOM_RADIO))
            {
                _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_MEDIA_CD].Value = C_MEDIACD_NEBIKI_RADIO;
            }
            else
            {
                _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_MEDIA_CD].Value = C_MEDIACD_NEBIKI_TSUJO;
            }
            //発注番号.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_HACHU_NO].Text = _hachuNoRow1;
            //発注行番号.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_HACHUGYO_NO].Text = "000";
            //取引先コード.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_TORIHIKISAKI_CD].Text
                = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_TORIHIKISAKI_CD].Text;
            //請求部署コード.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_SEIKYU_BUSHO].Text
                = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_SEIKYU_BUSHO].Text;
            //請求書発行日.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_SEIKYUSHO_HAKO_BI].Text
                = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_SEIKYUSHO_HAKO_BI].Text;
            //請求書番号.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_SEIKYUSHO_NO].Text = _seishoNoRow1;
            //請求書行番号.
            if(!String.IsNullOrEmpty(_seishoGyoNo))
            {
                _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1, COLIDX_MLIST_SEIKYUSHOGYO_NO].Text = String.Format("{0:000}", KKHUtility.IntParse(_seishoGyoNo) + 1);
            }
            //支払日.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_SHIHARAI_BI].Text
                = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_SHIHARAI_BI].Text;
            //商品区分.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_SHOHIN_KBN].Text
                = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_SHOHIN_KBN].Text;
            //商品区分名称.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_SHOHIN_KBN_MEI].Text
                = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_SHOHIN_KBN_MEI].Text;
            //摘要コード.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_TEKIYO_CD].Text
                = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_TEKIYO_CD].Text;
            //媒体コード.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_BAITAI_CD].Text
                = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_BAITAI_CD].Text;
            //店番.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_TEN_NO].Text
                = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_TEN_NO].Text;
            //値引額を取得.
            decimal _dNebiki = 0.0M;
            decimal _dValue = 0.0M;
            //金額.
            //_dNebiki = decimal.Parse(_spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_NEBIKI_GAKU].Text.ToString());
            _dNebiki = _dNebikiGaku;
            _dValue = _dNebiki * -1;
//          FarPoint.Win.Spread.CellType.TextCellType tAlphaNumeric = new FarPoint.Win.Spread.CellType.TextCellType();
//          tAlphaNumeric.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.AlphaNumeric;
//          _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1, COLIDX_MLIST_KINGAKU].CellType = tAlphaNumeric;
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1, COLIDX_MLIST_KINGAKU].Text = _dValue.ToString("###,###,###,##0");
            //消費税額を算出.
            decimal _dShohiZeiGaku = _dNebiki * decimal.Parse(_shohizeiRitsu.ToString()) / 100;
            if (_dShohiZeiGaku > 0)
            {
                _dShohiZeiGaku = Decimal.Floor( _dShohiZeiGaku + 0.5M );
            }
            else if (_dShohiZeiGaku < 0)
            {
                _dShohiZeiGaku = Decimal.Floor( _dShohiZeiGaku - 0.5M );
            }
            //消費税額.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_SHOHIZEI_GAKU].Text  = _dShohiZeiGaku.ToString();
            //按分種別.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_ANBUN].Text
                = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_ANBUN].Text;
            //登録年月日.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_TOROKU_DATE].Text
                = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_TOROKU_DATE].Text;
            //変更年月日.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_HENKO_DATE].Text
                = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_HENKO_DATE].Text;
            //取消年月日.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_TORIKESHI_DATE].Text
                = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_TORIKESHI_DATE].Text;
            //消費税率.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_SHOHIZEI_RITSU].Text = _shohizeiRitsu.ToString();
            //値引率.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_NEBIKI_RITSU].Text = "0";
            //値引額.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_NEBIKI_GAKU].Text = "0";
            //取料金.
//          _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1, COLIDX_MLIST_TORIRYOKIN].CellType = tAlphaNumeric;
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1, COLIDX_MLIST_TORIRYOKIN].Text = _dValue.ToString("###,###,###,##0");
            //受注No.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_JUCHU_NO].Text
                = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_JUCHU_NO].Text;
            //受注明細No.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_JUCHU_MEISAI_NO].Text
                = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_JUCHU_MEISAI_NO].Text;
            //売上明細No.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_URIAGE_MEISAI_NO].Text
                = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_URIAGE_MEISAI_NO].Text;
            //受注内容区分.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_JUCHU_NAIYO_KBN].Text
                = _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx , COLIDX_MLIST_JUCHU_NAIYO_KBN].Text;
            //値引行区分.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1 , COLIDX_MLIST_NEBIKI_GYO_KBN].Text = "1";
            #endregion 項目設定.

            //テキストボックスにデータをセット.
            CalcDataSet();

            //値引率、値引額のロック.
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1, COLIDX_MLIST_NEBIKI_RITSU].Locked = true;
            _spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1, COLIDX_MLIST_NEBIKI_GAKU].Locked = true;

            //Spreadの背景色設定.
            SetMeisaiBackColor();

            ////値引率、値引額の色を付ける.
            //_spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1, COLIDX_MLIST_NEBIKI_RITSU].BackColor = Color.LightGray;
            //_spdMeiNyuryokAcom_Sheet1.Cells[_maxRowIdx + 1, COLIDX_MLIST_NEBIKI_GAKU].BackColor = Color.LightGray;
        }

        /// <summary>
        /// 削除ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSakujo_Click(object sender , EventArgs e)
        {
            {
                //最大行数の取得.
                int _maxRowCnt = _spdMeiNyuryokAcom_Sheet1.Rows.Count;

                //最大行数が0の場合.
                if (_maxRowCnt == 0)
                {
                    //処理しない.
                    return;
                }

                //現在行の位置を取得.
                int _rowIdx = _spdMeiNyuryokAcom_Sheet1.ActiveRowIndex;
                //金額に値引額が入っている行の削除の場合、金額テキストボックスに0をセット.
                String hugo = _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_KINGAKU].Text.Substring(0, 1);
                if (hugo == "-")
                {
                    txtNebikiGaku.Text = "0";
                }
                //行を削除.
                _spdMeiNyuryokAcom_Sheet1.RemoveRows(_rowIdx, 1);
            }

            //テキストボックスにデータをセット.
            CalcDataSet();

            {
                //最大行数の取得.
                int _maxRowCnt = _spdMeiNyuryokAcom_Sheet1.Rows.Count;

                //最大行数が0の場合.
                if (_maxRowCnt == 0)
                {
                    //削除後に0件になった場合は処理しない.
                    return;
                }

                //現在行の位置を取得.
                int _rowIdx = _spdMeiNyuryokAcom_Sheet1.ActiveRowIndex;

                //削除ボタンの制御.
                CtrlSakujoBtn(_rowIdx);

                //発注番号取得ボタンの制御.
                CtrlHachuBangoBtn(_rowIdx);
            }

            //_spdKkhDetail_Sheet1.RemoveRows(_rowIdx, 1);

            //InitializeDesignForSpdKkhDetail();

            ////データソースを再読み込み.
            //_spdKkhDetail_Sheet1.Rows.Clear();

            //_bsKkhDetail.DataSource = _spdKkhDetail_Sheet1.DataSource;

            //_bsKkhDetail.RemoveAt(_rowIdx);

            //_dsDetailAcom.KkhDetail.Rows[_rowIdx].Delete();

            ////最大行インデックスを修正.
            //_maxRowIdx--;

            ////最大行数を修正;
            //_maxRowCnt--;
        }

        /// <summary>
        /// 行挿入ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGyoSonyu_Click(object sender , EventArgs e)
        {
            if( _spdMeiNyuryokAcom_Sheet1.RowCount == 0 )
            {

                //初期化処理2.
                InsertInitialData2();
            }
            else
            {
                // 明細行がある場合は現在選択しているセルのデータをコピーして作成.
                //現在行の位置を取得.
                int _rowIdx = _spdMeiNyuryokAcom_Sheet1.ActiveRowIndex;

                //*********************.
                //CellTypeの設定.
                //*********************.
                AddSheetRow(_rowIdx + 1);

                //*********************.
                //各項目を設定.
                //*********************.
                #region 項目設定.

                //メディアコード.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx + 1, COLIDX_MLIST_MEDIA_CD].Text
                   = _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text;
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx + 1, COLIDX_MLIST_MEDIA_CD].Locked = false;
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx + 1, COLIDX_MLIST_MEDIA_CD].HorizontalAlignment = CellHorizontalAlignment.Left;

                //取引先コード.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx + 1, COLIDX_MLIST_TORIHIKISAKI_CD].Text
                    = _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_TORIHIKISAKI_CD].Text;
                //請求部署コード.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx + 1, COLIDX_MLIST_SEIKYU_BUSHO].Text
                    = _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SEIKYU_BUSHO].Text;
                //請求書発行日.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx + 1, COLIDX_MLIST_SEIKYUSHO_HAKO_BI].Text
                    = _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SEIKYUSHO_HAKO_BI].Text;

                ////請求書番号.
                //_spdKkhDetail_Sheet1.Cells[_rowIdx + 1 , COLIDX_MLIST_SEIKYUSHO_NO].Text = _seishoNoRow1;

                ////取引先コード.
                //_spdKkhDetail_Sheet1.Cells[_rowIdx, COLIDX_MLIST_TORIHIKISAKI_CD].Value = dataRow.;

                //支払日.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx + 1, COLIDX_MLIST_SHIHARAI_BI].Text
                    = _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SHIHARAI_BI].Text;
                //商品区分.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx + 1, COLIDX_MLIST_SHOHIN_KBN].Text
                    = _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SHOHIN_KBN].Text;
                //商品区分名称.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx + 1, COLIDX_MLIST_SHOHIN_KBN_MEI].Text
                    = _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SHOHIN_KBN_MEI].Text;

                ////摘要コード.
                //_spdKkhDetail_Sheet1.Cells[_rowIdx + 1 , COLIDX_MLIST_TEKIYO_CD].Text
                //    = _spdKkhDetail_Sheet1.Cells[_rowIdx , COLIDX_MLIST_TEKIYO_CD].Text;

                //媒体コード.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx + 1, COLIDX_MLIST_BAITAI_CD].Text
                    = _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Text;
                //店番.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx + 1, COLIDX_MLIST_TEN_NO].Text
                    = _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_TEN_NO].Text;

                //金額系列に値を初期化する.
                SetMeisaiKngkkei(_rowIdx);

                ////値引額を取得.
                //decimal _dNebiki = 0.0M;
                //decimal _dValue = 0.0M;
                //金額.
                //_dNebiki = decimal.Parse(_spdKkhDetail_Sheet1.Cells[_rowIdx , COLIDX_MLIST_NEBIKI_GAKU].Text.ToString());
                //_dValue = _dNebiki * -1;
                //_spdKkhDetail_Sheet1.Cells[_rowIdx + 1 , COLIDX_MLIST_KINGAKU].CellType = _numType;
                //_spdKkhDetail_Sheet1.Cells[_rowIdx + 1 , COLIDX_MLIST_KINGAKU].Text = _dValue.ToString();
                ////消費税額を算出.
                //decimal _dShohiZeiGaku = _dNebiki * decimal.Parse(_shohizeiRitsu.ToString()) / 100;
                //if (_dShohiZeiGaku > 0)
                //{
                //    _dShohiZeiGaku = _dShohiZeiGaku + decimal.Parse("0.5");
                //}
                //else if (_dShohiZeiGaku < 0)
                //{
                //    _dShohiZeiGaku = _dShohiZeiGaku + decimal.Parse("0.5");
                //}
                //消費税額.
                //_spdKkhDetail_Sheet1.Cells[_rowIdx + 1, COLIDX_MLIST_SHOHIZEI_GAKU].CellType = _numType;
                //_spdKkhDetail_Sheet1.Cells[_rowIdx + 1 , COLIDX_MLIST_SHOHIZEI_GAKU].Text = _dShohiZeiGaku.ToString();
                ////按分種別.
                //_spdKkhDetail_Sheet1.Cells[_rowIdx + 1 , COLIDX_MLIST_ANBUN].Text
                //    = _spdKkhDetail_Sheet1.Cells[_rowIdx , COLIDX_MLIST_ANBUN].Text;
                ////登録年月日.
                //_spdKkhDetail_Sheet1.Cells[_rowIdx + 1 , COLIDX_MLIST_TOROKU_DATE].Text
                //    = _spdKkhDetail_Sheet1.Cells[_rowIdx , COLIDX_MLIST_TOROKU_DATE].Text;
                ////変更年月日.
                //_spdKkhDetail_Sheet1.Cells[_rowIdx + 1 , COLIDX_MLIST_HENKO_DATE].Text
                //    = _spdKkhDetail_Sheet1.Cells[_rowIdx , COLIDX_MLIST_HENKO_DATE].Text;
                ////取消年月日.
                //_spdKkhDetail_Sheet1.Cells[_rowIdx + 1 , COLIDX_MLIST_TORIKESHI_DATE].Text
                //    = _spdKkhDetail_Sheet1.Cells[_rowIdx , COLIDX_MLIST_TORIKESHI_DATE].Text;
                //消費税率.
                //_spdKkhDetail_Sheet1.Cells[_rowIdx + 1 , COLIDX_MLIST_SHOHIZEI_RITSU].Text = _shohizeiRitsu.ToString();
                //値引率.
                //値引額.
                //_spdKkhDetail_Sheet1.Cells[_rowIdx + 1 , COLIDX_MLIST_NEBIKI_GAKU].CellType = _numType;
                //取料金.
                //_spdKkhDetail_Sheet1.Cells[_rowIdx + 1 , COLIDX_MLIST_TORIRYOKIN].CellType = _numType;
                //_spdKkhDetail_Sheet1.Cells[_rowIdx + 1, COLIDX_MLIST_TORIRYOKIN].Text = _dValue.ToString();

                //受注No.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx + 1, COLIDX_MLIST_JUCHU_NO].Text
                    = _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NO].Text;
                //受注明細No.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx + 1, COLIDX_MLIST_JUCHU_MEISAI_NO].Text
                    = _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_MEISAI_NO].Text;
                //売上明細No.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx + 1, COLIDX_MLIST_URIAGE_MEISAI_NO].Text
                    = _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_URIAGE_MEISAI_NO].Text;
                //受注内容区分.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx + 1 , COLIDX_MLIST_JUCHU_NAIYO_KBN].Text
                    = _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx , COLIDX_MLIST_JUCHU_NAIYO_KBN].Text;
                //値引行区分.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx + 1, COLIDX_MLIST_NEBIKI_GYO_KBN].Text = "0";

                #endregion 項目設定.
            }

            //テキストボックスにデータをセット.
            CalcDataSet();

            //Spreadの背景色設定.
            SetMeisaiBackColor();
        }

        /// <summary>
        /// 登録ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToroku_Click(object sender , EventArgs e)
        {
            string comment = registrationCheck();

            if (!string.IsNullOrEmpty(comment))
            {
                if (comment.Equals(TOUROKUEND))
                {
                    return;
                }
                else
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_I0013, new string[] { comment } , "明細登録", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                RegistrationMeisaiValue();

                // ユーザーによる閉じる要求である.
                _userCloseRequest = true;
                Navigator.Backward(this, _naviParam, null, true);
            }
        }

        /// <summary>
        /// スプレッドシートでCellClickイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _spdMeiNyuryokAcom_CellClick(object sender , CellClickEventArgs e)
        {
            // ソート用ヘッダをクリックした場合は処理を抜ける.
            if( e.ColumnHeader )
            {
                return;
            }

            //現在行の位置を取得.
            int rowIdx = e.Row;
            //現在列の位置を取得.
            int colIdx = e.Column;

            //削除ボタンの制御.
            CtrlSakujoBtn(rowIdx);

            //発注番号取得ボタンの制御.
            CtrlHachuBangoBtn(rowIdx);

            //行にロックがかかっている場合.
            if (_spdMeiNyuryokAcom_Sheet1.Rows[rowIdx].Locked)
            {
                //送信状況区分を取得.
                string _soshinKbn = _spdMeiNyuryokAcom_Sheet1.Cells[rowIdx, COLIDX_MLIST_SOSHIN_JOKYO_KBN].Text;

                //「予約中」の場合.
                if (_soshinKbn.Equals("1"))
                {
                    //メッセージを出力.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0012
                        , null
                        , "編集警告"
                        , MessageBoxButtons.OK);

                    //処理終了.
                    return;
                }
                //「送信済」の場合.
                else if (_soshinKbn.Equals("2"))
                {
                    //メッセージを出力.
                    if (DialogResult.OK == MessageUtility.ShowMessageBox(MessageCode.HB_W0011
                        , null
                        , "編集警告"
                        , MessageBoxButtons.OKCancel))
                    {
                        //「はい」の場合、ロックを解除する.
                        _spdMeiNyuryokAcom_Sheet1.Rows[rowIdx].Locked = false;
                    }
                    else
                    {
                        //「いいえ」の場合、処理を中断.
                        return;
                    }
                }
            }

            //発注番号列、発注行番号列の場合.
            //列にロックがかかっている場合.
            if (IsColumnLockTarget(colIdx))
            {
                if (_colmunLockState)
                {
                    //メッセージを出力.
                    if (DialogResult.OK == MessageUtility.ShowMessageBox(MessageCode.HB_W0013
                        , null
                        , "編集警告"
                        , MessageBoxButtons.OKCancel))
                    {
                        // 列ロックを解除する.
                        _colmunLockState = false;

                        // 列ロックの制御.
                        CtrlColumnLock();
                    }
                    else
                    {
                        //「いいえ」の場合、処理を中断.
                        return;
                    }
                }
            }

            //Spreadの背景色設定.
            SetMeisaiBackColor();

            //削除ボタンの制御.
            CtrlSakujoBtn(rowIdx);

            //発注番号取得ボタンの制御.
            CtrlHachuBangoBtn(rowIdx);
        }

        /// <summary>
        /// セル編集開始時のイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _spdMeiNyuryokAcom_EnterCell(object sender, EnterCellEventArgs e)
        {
            _col = e.Column;
            _row = e.Row;
        }

        /// <summary>
        /// セル編集開始時のイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _spdMeiNyuryokAcom_EditModeOn(object sender, EventArgs e)
        {
            _col = _spdMeiNyuryokAcom_Sheet1.ActiveColumn.Index;
            _row = _spdMeiNyuryokAcom_Sheet1.ActiveRow.Index;

            // キー入力制限の設定.
            InputControlOn(_col);
        }

        /// <summary>
        /// セル編集終了時のイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _spdMeiNyuryokAcom_EditModeOff(object sender, EventArgs e)
        {
            // キー入力制限の解除.
            InputControlOff(_col);

            switch (_col)
            {
                case COLIDX_MLIST_TORIRYOKIN:       // 取金額.
                case COLIDX_MLIST_NEBIKI_RITSU:     // 値引率.
                case COLIDX_MLIST_KINGAKU:          // 売上額（請求金額）.
                case COLIDX_MLIST_SHOHIZEI_RITSU:   // 消費税率.
                case COLIDX_MLIST_SHOHIZEI_GAKU:    // 消費税額.
                case COLIDX_MLIST_NEBIKI_GAKU:      // 値引額.

                    // 値が空文字、Nullの場合、デフォルト値を設定する.
                    if (_spdMeiNyuryokAcom_Sheet1.Cells[_row, _col].Value == null || string.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[_row, _col].Text))
                    {
                        _spdMeiNyuryokAcom_Sheet1.Cells[_row, _col].Value = 0;
                        _spdMeiNyuryokAcom_Sheet1.Cells[_row, _col].Text = "0";
                    }

                    // 自動計算.
                    CalcAuto(_row, _col);

                    break;

                // 発注行番号.
                case COLIDX_MLIST_HACHUGYO_NO:
                    if (!String.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[_row, COLIDX_MLIST_HACHUGYO_NO].Text))
                    {
                        _spdMeiNyuryokAcom_Sheet1.Cells[_row, COLIDX_MLIST_HACHUGYO_NO].Text = String.Format("{0:000}", KKHUtility.IntParse(_spdMeiNyuryokAcom_Sheet1.Cells[_row, COLIDX_MLIST_HACHUGYO_NO].Text));
                    }
                    break;

                // 請求書行番号.
                case COLIDX_MLIST_SEIKYUSHOGYO_NO:
                    if (!String.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[_row, COLIDX_MLIST_SEIKYUSHOGYO_NO].Text))
                    {
                        _spdMeiNyuryokAcom_Sheet1.Cells[_row, COLIDX_MLIST_SEIKYUSHOGYO_NO].Text = String.Format("{0:000}", KKHUtility.IntParse(_spdMeiNyuryokAcom_Sheet1.Cells[_row, COLIDX_MLIST_SEIKYUSHOGYO_NO].Text));
                    }
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// スプレッド内容変更時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _spdMeiNyuryokAcom_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            switch (e.Column)
            {
                case COLIDX_MLIST_TORIRYOKIN:       // 取金額.
                case COLIDX_MLIST_NEBIKI_RITSU:     // 値引率.
                case COLIDX_MLIST_KINGAKU:          // 売上額（請求金額）.

                case COLIDX_MLIST_SHOHIZEI_RITSU:   // 消費税率.
                case COLIDX_MLIST_SHOHIZEI_GAKU:    // 消費税額.
                case COLIDX_MLIST_NEBIKI_GAKU:      // 値引額.

                    // 値が空文字、Nullの場合、デフォルト値を設定する.
                    if (_spdMeiNyuryokAcom_Sheet1.Cells[e.Row, e.Column].Value == null || string.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[e.Row, e.Column].Text))
                    {
                        _spdMeiNyuryokAcom_Sheet1.Cells[e.Row, e.Column].Value = 0;
                        _spdMeiNyuryokAcom_Sheet1.Cells[e.Row, e.Column].Text = "0";
                    }


                    // 自動計算.
                    CalcAuto(e.Row, e.Column);

                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// スプレッドKeyDown時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _spdMeiNyuryokAcom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Control)
            {
                //Ctrl+Vが押下された場合、クリップボードの内容を貼り付け.
                FpSpread fpSpread = sender as FpSpread;
                CellRange[] range = fpSpread.ActiveSheet.GetSelections();

                // クリップボードの値をセルに当てはめる.
                string clipVal = Clipboard.GetText();

                // 選択したセル範囲情報を走査する.
                foreach (CellRange rn in range)
                {
                    // 列.
                    int col = rn.Column;
                    // 行.
                    int row = rn.Row;
                    // 選択範囲終了列.
                    int colEnd = (rn.Column + rn.ColumnCount - 1);
                    // 選択範囲終了行.
                    int rowEnd = (rn.Row + rn.RowCount - 1);
                    for (int colCnt = col; colCnt <= colEnd; colCnt++)
                    {
                        bool multiCopyFlg = false;
                        // 行分ループ.
                        for (int rowCnt = row; rowCnt < rowEnd + 1; rowCnt++)
                        {
                            multiCopyFlg = isSetContinuePast(this._spdMeiNyuryokAcom.GetRootWorkbook(), clipVal, rowCnt, colCnt);

                            if (multiCopyFlg)
                            {
                                // 複数コピーの為、貼り付け終了.
                                break;
                            }
                        }
                        if (multiCopyFlg)
                        {
                            // 複数コピーの為、貼り付け終了.
                            break;
                        }
                    }
                }
            }
            //テキストボックスにデータをセット.
            CalcDataSet();
        }

        /// <summary>
        /// スプレッドエディットチェーンジ！！！！.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _spdMeiNyuryokAcom_EditChange(object sender, EditorNotifyEventArgs e)
        {
            SheetView sheet = e.View.GetSheetView();
            Cell cell = sheet.Cells[e.Row,e.Column];
            object cellType = cell.CellType;

            if (cellType is TextCellType)
            {
                TextCellType textCellType = (TextCellType)cellType;
                e.EditingControl.Text = KKHUtility.GetByteString(e.EditingControl.Text, textCellType.MaxLength);
                ((GeneralEditor)e.EditingControl).SelectionStart = e.EditingControl.Text.Length;
            }
        }

        /// <summary>
        /// フォームを閉じる直前に呼び出されるイベント（登録・キャンセル・×ボタン等から呼び出される）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailInputAcom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_userCloseRequest)
            {
                // 閉じるボタンによる要求なのでキャンセルする.
                e.Cancel = true;

                // 閉じる要求フラグを設定.
                _userCloseRequest = true;

                // 改めてフレームワークによる閉じる要求を出す.
                Navigator.Backward(this, null, null, true);
            }
        }
        #endregion イベント.

        #region メソッド.
        /// <summary>
        /// 各コントロールの初期表示処理.
        /// </summary>
        private void InitializeControl()
        {
            // テキストボックス↓.
            txtJuchuKenNm.Text = string.Empty;      //受注登録件名.
            dtpShihaBi.Value = null;                //支払日.
            //dtpShihaBi.Text = string.Empty;       //支払日.
            txtToriRyokin.Text = "0";               //取料金小計.
            txtNebikiGaku.Text = "0";               //値引額.
            txtSeiKinGokei.Text = "0";              //請求金額合計.
            txtShohZeigaku.Text = "0";              //消費税額.
            txtSeiGak.Text = "0";                   //ご請求額.
            txtHachuBango.Text = string.Empty;      //発注番号.
            txtHachuGyoBango.Text = string.Empty;   //発注行番号.

            //***********************************.
            //メディアコードをコンボボックスにセットする.
            //***********************************.
            SetMediaCdMeiCmb();

            /* 2015/01/05 アコム消費税対応 HLC fujimoto ADD start */
            //消費税端数処理区分取得.
            _taxRounding = GetTaxRounding();
            /* 2015/01/05 アコム消費税対応 HLC fujimoto ADD end */

            // セルタイプの設定.
            //Number.
            _numType.DecimalPlaces = 0;
            _numType.ShowSeparator = true;
            //_numType.MaximumValue = 99999999999;

            //Combo.
            _cmbType.ItemData = _itemMediaiCd;
            _cmbType.Items = _itemMediaMei;
            _cmbType.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
            _cmbType.Editable = false;

            //Text8
            _text8CellType.MaxLength = 8;
            _text8CellType.CharacterSet = CharacterSet.AlphaNumeric;

            //Number1
            _number1CellType.MaxLength = 1;
            _number1CellType.CharacterSet = CharacterSet.Numeric;

            //Number2
            _number2CellType.MaxLength = 2;
            _number2CellType.CharacterSet = CharacterSet.Numeric;

            //Number3
            _number3CellType.MaxLength = 3;
            _number3CellType.CharacterSet = CharacterSet.Numeric;

            //Number8
            _number8CellType.MaxLength = 8;
            _number8CellType.CharacterSet = CharacterSet.Numeric;

            // 列ロックを有効にする.
            _colmunLockState = true;

            // 列ロックの制御.
            CtrlColumnLock();
        }

        /// <summary>
        /// 各コントロールの編集処理.
        /// </summary>
        private void EditControl()
        {
            //*********************************************
            //コントロールに値を設定.
            //*********************************************
            // 明細がない場合.
            if (_spdKkhDetail_Sheet1.RowCount == 0)
            {
                //受注登録件名.
                txtJuchuKenNm.Text = _dataRow.hb1KKNameKJ.ToString().Trim();
            }
            else
            {
                //受注登録件名.
                txtJuchuKenNm.Text = _dataRow.hb1KKNameKJ.ToString().Trim();

                //メディアコード.
                //for (int i = 0 ; i < _itemMediaiCd.Length ; i++)
                //{
                //object _mediaCdMei = _itemMediaiCd[i] + " " + _itemMediaMei[i];
                //cmbMediaCd.Items.Add(_mediaCdMei);
                //}
                cmbMediaCd.DataSource = _itemMediaMei;

                //取料金小計.
                decimal _dToriRyo = _dataRow.hb1ToriGak;
                txtToriRyokin.Text = _dToriRyo.ToString("###,###,###,##0");
                //txtToriRyokin.Text = _dataRow.hb1ToriGak.ToString().Trim();

                //値引額.
                decimal _dNebikiGak = _dataRow.hb1NeviGak;
                if (_dNebikiGak == 0)
                {
                    txtNebikiGaku.Text = _dNebikiGak.ToString("###,###,###,##0");
                }
                else
                {
                    txtNebikiGaku.Text = "-" + _dNebikiGak.ToString("###,###,###,##0");
                }
                //txtNebikiGaku.Text = _dataRow.hb1NeviGak.ToString().Trim();

                //請求金額合計.
                decimal _dSeiKinGokei = _dToriRyo - _dNebikiGak;
                txtSeiKinGokei.Text = _dSeiKinGokei.ToString("###,###,###,##0");

                //消費税額.
                decimal _dShohZeiGak = _dataRow.hb1SzeiGak;
                txtShohZeigaku.Text = _dShohZeiGak.ToString("###,###,###,##0");

                //ご請求額.
                decimal _dSeiGak = _dSeiKinGokei + _dShohZeiGak;
                txtSeiGak.Text = _dSeiGak.ToString("###,###,###,##0");

                // 明細データの設定.
                SetMeisaiValue();

                // 明細行の行ロックを設定.
                SetMeisaiLock();

                // 削除ボタン制御.
                CtrlSakujoBtn(0);

                // 発注番号取得ボタンの制御.
                CtrlHachuBangoBtn(0);
            }

            //cmbMediaCd.ItemData = _itemMediaiCd;
            //_cmbType.Items = _itemMediaMei;
            //_cmbType.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
            //_cmbType.Editable = false;
            //cmbMediaCd. = _itemMediaiCd;
            //cmbMediaCd.Items = _itemMediaMei;
            //cmbMediaCd.Items.AddRange((string[])_itemMediaMei);

            //*********************************************.
            //送信状況区分よりロック処理.
            //*********************************************.
            //ChkSeikyuDataSoshin();
        }

        /// <summary>
        /// 初期データの挿入.
        /// </summary>
        private void InsertInitialData()
        {
            Common.KKHSchema.Detail.JyutyuDataRow dataRow = _naviParam.DataRow;
            if (_spdKkhDetail_Sheet1.Rows.Count != 0)
            {
                //*********************.
                //画面の設定.
                //*********************.

                ////消費税.
                //decimal syouhizei = 0;

                ////値引額.
                //decimal nebikigaku = 0;

                //for (int j = 0; j < _spdKkhDetail_Sheet1.Rows.Count; j++)
                //{
                //    if (!string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[j, COLIDX_MLIST_SHOHIZEI_GAKU].Text) && !string.IsNullOrEmpty((string)_spdKkhDetail_Sheet1.Cells[j, COLIDX_MLIST_NEBIKI_GAKU].Text))
                //    {
                //        syouhizei = syouhizei + (decimal)_spdKkhDetail_Sheet1.Cells[j, COLIDX_MLIST_SHOHIZEI_GAKU].Value;
                //        nebikigaku = nebikigaku + (decimal)_spdKkhDetail_Sheet1.Cells[j, COLIDX_MLIST_NEBIKI_GAKU].Value;
                //    }
                //}

                ////取料金小計.
                //txtToriRyokin.Text = String.Format("{0:#,0}", dataRow.hb1SeiGak);

                ////値引額.
                //txtNebikiGaku.Text = String.Format("{0:#,0}", nebikigaku * -1);

                ////請求金額合計.
                //decimal seigou = (decimal)dataRow.hb1SeiGak - nebikigaku;
                //txtSeiKinGokei.Text = String.Format("{0:#,0}", seigou);

                ////消費税額.
                //txtShohZeigaku.Text = String.Format("{0:#,0}", syouhizei);

                ////請求額.
                //decimal seikyuu = seigou + syouhizei;
                //txtSeiGak.Text = String.Format("{0:#,0}", seikyuu);

                return;
            }

            //統合済みデータでない場合.
            if( dataRow.hb1TouFlg != "1" )
            {
                //媒体名.
                string BaitaiNm = string.Empty;

                //現在行の位置を取得.
                int _rowIdx = _spdMeiNyuryokAcom_Sheet1.ActiveRowIndex;

                //*********************.
                //CellTypeの設定.
                //*********************.
                AddSheetRow(_rowIdx);

                //int count = 0;
                //foreach (string dntscd in _dntscd)
                //{
                //    if(string.IsNullOrEmpty(dntscd)){}
                //    else if (dntscd.Equals(dataRow.hb1Field1))
                //    {
                //        BaitaiNm = _itemMediaMei[count];
                //        break;
                //    }
                //    count++;
                //}

                if (dataRow.hb1GyomKbn != C_GYOM_OOH_M)
                {
                    //メディアコード.
                    BaitaiNm = GetBaitaiNm(dataRow.hb1Field1);

                    //新規登録対応.
                    if (( BaitaiNm == "" ) && ( dataRow.hb1Field1.Trim() != "" ))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { dataRow.hb1Field1.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    //メディアコード.
                    BaitaiNm = GetBaitaiNm(dataRow.hb1Field7);

                    //新規登録対応.
                    if (( BaitaiNm == "" ) && ( dataRow.hb1Field7.Trim() != "" ))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { dataRow.hb1Field7.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                    }
                }

                //*********************.
                //スプレッドの設定.
                //*********************.
                //メディアコード.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].CellType = _cmbType;
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = BaitaiNm;
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Locked = false;
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].HorizontalAlignment = CellHorizontalAlignment.Left;

                //発注番号,請求書行番号.
                TextCellType textType = new TextCellType();
                textType.MaxLength = 8;
                _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_HACHU_NO].CellType = textType;
                _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_SEIKYUSHO_NO].CellType = textType;
                textType = new TextCellType();
                textType.MaxLength = 3;
                _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_HACHUGYO_NO].CellType = textType;
                _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_SEIKYUSHOGYO_NO].CellType = textType;

                //売上明細No
                textType = new TextCellType();
                textType.MaxLength = 10;
                _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_JUCHU_NO].CellType = textType;
                textType = new TextCellType();
                textType.MaxLength = 3;
                _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_JUCHU_MEISAI_NO].CellType = textType;
                _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_URIAGE_MEISAI_NO].CellType = textType;

                //発売日or掲載日.
                if (checkSNBN(dataRow.hb1GyomKbn) || checkZASI(dataRow.hb1GyomKbn))
                {
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_HATSUORKEISAI].Text = dataRow.hb1Field3.ToString();
                }

                //消費税率.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SHOHIZEI_RITSU].Value = (decimal)dataRow.hb1SzeiRitu;

                /* 2015/01/27 アコム消費税対応 HLC fujimoto MOD start */
                //消費税額.
                //_spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SHOHIZEI_GAKU].Value = (decimal)dataRow.hb1SzeiGak;
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SHOHIZEI_GAKU].Value = AutoCalcTaxInitialize((decimal)dataRow.hb1SeiGak, (decimal)dataRow.hb1SzeiRitu);
                /* 2015/01/27 アコム消費税対応 HLC fujimoto MOD end */

                //金額.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_KINGAKU].Value = (decimal)dataRow.hb1SeiGak;

                //値引率.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_NEBIKI_RITSU].Value = dataRow.hb1NeviRitu;

                //値引額.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_NEBIKI_GAKU].Value = (decimal)dataRow.hb1NeviGak;

                //取り料金.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_TORIRYOKIN].Value = (decimal)dataRow.hb1ToriGak;

                //取引先コード.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_TORIHIKISAKI_CD].Value = "6080101";           //初期値.

                //請求部署コード.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SEIKYU_BUSHO].Value = "11328";                //初期値.

                string baicd = string.Empty;
                switch (dataRow.hb1GyomKbn)
                {
                    case C_GYOM_SHINBUN:
                        baicd = "21";
                        break;

                    case C_GYOM_ZASHI:
                        baicd = "22";
                        break;

                    case C_GYOM_RADIO:
                    case C_GYOM_TV_TIME:
                    case C_GYOM_TV_SPOT:
                    case C_GYOM_EISEI_M:
                        baicd = "11";
                        break;

                    case C_GYOM_INTE_M:
                    case C_GYOM_OOH_M:
                    case C_GYOM_SONOTA_M:
                    case C_GYOM_M_PLAN:
                    case C_GYOM_CREATE:
                    case C_GYOM_MARK_PROM:
                    case C_GYOM_SPORTS:
                    case C_GYOM_ENTE:
                    case C_GYOM_SONOTA:
                        baicd = "31";
                        break;
                }

                //媒体コード.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = baicd;

                //受注No
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NO].Value = dataRow.hb1JyutNo;

                //受注明細No
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_MEISAI_NO].Value = dataRow.hb1JyMeiNo;

                //売上明細No
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_URIAGE_MEISAI_NO].Value = dataRow.hb1UrMeiNo;

                //請求原票Noをセット.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SEIKYU_GENPYO_NO].Value = dataRow.hb1GpyNo;

                //値引行区分.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_NEBIKI_GYO_KBN].Text = "0";

                //請求書発行日.
                string yy = dataRow.hb1Yymm.Substring(0, 4);
                string mm = dataRow.hb1Yymm.Substring(4, 2);
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SEIKYUSHO_HAKO_BI].Value = yy + "/" + mm + "/25";

                //支払日.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SHIHARAI_BI].Value = MonthEnd(yy, mm);

                //受注内容区分.
                string JKbn = string.Empty;
                switch (_dataRow.hb1GyomKbn)
                {
                    case C_GYOM_SHINBUN:
                        JKbn = "01";
                        break;
                    case C_GYOM_ZASHI:
                        JKbn = "02";
                        break;
                    case C_GYOM_RADIO:
                        //タイムの場合.
                        if (_dataRow.hb1TmspKbn.Trim().Equals("1"))
                        {
                            JKbn = "03";
                        }
                        else if (_dataRow.hb1TmspKbn.Trim().Equals("2"))
                        {
                            JKbn = "04";
                        }
                        break;
                    case C_GYOM_TV_TIME:
                        JKbn = "05";
                        break;
                    case C_GYOM_EISEI_M:
                        if (_dataRow.hb1TmspKbn.Trim().Equals("1"))
                        {
                            JKbn = "06";
                        }
                        else if (_dataRow.hb1TmspKbn.Trim().Equals("2"))
                        {
                            JKbn = "08";
                        }
                        break;
                    case C_GYOM_TV_SPOT:
                        JKbn = "07";
                        break;
                    case C_GYOM_INTE_M:
                        JKbn = "09";
                        break;
                    case C_GYOM_OOH_M:
                        JKbn = "10";
                        break;
                    case C_GYOM_SONOTA_M:
                        JKbn = "11";
                        break;
                    case C_GYOM_M_PLAN:
                        JKbn = "12";
                        break;
                    case C_GYOM_CREATE:
                        JKbn = "13";
                        break;
                    case C_GYOM_MARK_PROM:
                        JKbn = "14";
                        break;
                    case C_GYOM_SPORTS:
                        JKbn = "15";
                        break;
                    case C_GYOM_ENTE:
                        JKbn = "16";
                        break;
                    case C_GYOM_SONOTA:
                        JKbn = "17";
                        break;
                }

                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NAIYO_KBN].Value = JKbn;

                if (checkDENP(dataRow.hb1GyomKbn))
                {
                    //CM秒数1
                    if (KKHUtility.IsNumeric(dataRow.hb1Field5))
                    {
                        dataRow.hb1Field5 = KKHUtility.DecParse(dataRow.hb1Field5).ToString();
                    }

                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_CM_BYOSU].Value = KKHStrConv.toWide(dataRow.hb1Field5);
                }
            }
            //統合済みデータの場合.
            else
            {
                //選択された受注NO、受注明細NO、売上明細NOが同じﾃﾞｰﾀを構造体にセット.
                foreach (Common.KKHSchema.Detail.JyutyuDataRow mergedDataRow in _naviParam.MergeDataRow)
                {
                    int _rowIdx = _spdMeiNyuryokAcom_Sheet1.Rows.Count;

                    AddSheetRow(_rowIdx);

                    //統合データの場合親データを元に場合分け.
                    //新聞、新聞企画.
                    if (dataRow.hb1GyomKbn == C_GYOM_SHINBUN)
                    {
                        //受注内容区分(企画ものはむりやり変える)
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NAIYO_KBN].Value = GetKbn(dataRow.hb1GyomKbn, dataRow.hb1TmspKbn);

                        if (CheckTougouData(dataRow, mergedDataRow))
                        {
                            //メディアコード.
                            String HYJ = GetBaitaiNm(mergedDataRow.hb1Field1);

                            //新規登録対応.
                            if (mergedDataRow.hb1Field1.Trim() != "")
                            {
                                if (HYJ == "")
                                {
                                    MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { mergedDataRow.hb1Field1.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                                else
                                {
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                            }

                            //掲載日.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_HATSUORKEISAI].Text = mergedDataRow.hb1Field3.ToString();
                        }
                        else
                        {
                            //メディアコード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = "";

                            //掲載日.
                            //vaSpread1.SetText KKHATUBAI, i, CVar("")
                        }

                        //商品区分.
                        //vaSpread1.SetText KKSYOKBN, i, " "

                        //商品区分名称.
                        //vaSpread1.SetText KKSYOKBNNAME, i, " "

                        //店番.
                        //vaSpread1.SetText KKMISEBAN, i, " "

                        //媒体コード.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_SNBN;
                    }
                    //雑誌、雑誌企画.
                    else if (dataRow.hb1GyomKbn == C_GYOM_ZASHI)
                    {
                        //区分.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NAIYO_KBN].Value = GetKbn(dataRow.hb1GyomKbn, dataRow.hb1TmspKbn);

                        if (CheckTougouData(dataRow, mergedDataRow))
                        {
                            //メディアコード.
                            String HYJ = GetBaitaiNm(mergedDataRow.hb1Field1);

                            //新規登録対応.
                            if (mergedDataRow.hb1Field1.Trim() != "")
                            {
                                if (HYJ == "")
                                {
                                    MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { mergedDataRow.hb1Field1.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                                else
                                {
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                            }

                            //発売日.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_HATSUORKEISAI].Text = mergedDataRow.hb1Field3.ToString();
                        }
                        else
                        {
                            //メディアコード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = "";

                            //発売日.
                            //vaSpread1.SetText KKHATUBAI, i, CVar("")
                        }

                        //媒体コード.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_ZASI;

                        //商品区分.
                        //vaSpread1.SetText KKSYOKBN, i, " "

                        //商品区分名称.
                        //vaSpread1.SetText KKSYOKBNNAME, i, " "

                        //店番.
                        //vaSpread1.SetText KKMISEBAN, i, " "
                    }
                    //ラジオ.
                    else if (dataRow.hb1GyomKbn == C_GYOM_RADIO)
                    {
                        //区分.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NAIYO_KBN].Value = GetKbn(dataRow.hb1GyomKbn, dataRow.hb1TmspKbn);

                        if (CheckTougouData(dataRow, mergedDataRow))
                        {
                            //メディアコード.
                            String HYJ = GetBaitaiNm(mergedDataRow.hb1Field1);

                            //新規登録対応.
                            if (mergedDataRow.hb1Field1.Trim() != "")
                            {
                                if (HYJ == "")
                                {
                                    MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { mergedDataRow.hb1Field1.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                                else
                                {
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                            }
                        }
                        else
                        {
                            //メディアコード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = "";
                        }

                        //媒体コード.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_DENP;

                        //商品区分.
                        //vaSpread1.SetText KKSYOKBN, i, " "

                        //商品区分名称.
                        //vaSpread1.SetText KKSYOKBNNAME, i, " "

                        //店番.
                        //vaSpread1.SetText KKMISEBAN, i, " "

                        //CM秒数1
                        if (KKHUtility.IsNumeric(mergedDataRow.hb1Field5))
                        {
                            mergedDataRow.hb1Field5 = KKHUtility.DecParse(mergedDataRow.hb1Field5).ToString();
                        }

                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_CM_BYOSU].Value = KKHStrConv.toWide(mergedDataRow.hb1Field5);
                    }
                    //TVタイム.
                    else if (dataRow.hb1GyomKbn == C_GYOM_TV_TIME)
                    {
                        //受注内容区分(企画ものはむりやり変える)
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NAIYO_KBN].Value = GetKbn(dataRow.hb1GyomKbn, dataRow.hb1TmspKbn);

                        if (CheckTougouData(dataRow, mergedDataRow))
                        {
                            //メディアコード.
                            String HYJ = GetBaitaiNm(mergedDataRow.hb1Field1);

                            //新規登録対応.
                            if (mergedDataRow.hb1Field1.Trim() != "")
                            {
                                if (HYJ == "")
                                {
                                    MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { mergedDataRow.hb1Field1.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                                else
                                {
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                            }
                        }
                        else
                        {
                            //メディアコード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = "";
                        }

                        //媒体コード.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_DENP;

                        //商品区分.
                        //vaSpread1.SetText KKSYOKBN, i, " "

                        //商品区分名称.
                        //vaSpread1.SetText KKSYOKBNNAME, i, " "

                        //店番.
                        //vaSpread1.SetText KKMISEBAN, i, " "

                        //CM秒数1
                        if (KKHUtility.IsNumeric(mergedDataRow.hb1Field5))
                        {
                            mergedDataRow.hb1Field5 = KKHUtility.DecParse(mergedDataRow.hb1Field5).ToString();
                        }

                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_CM_BYOSU].Value = KKHStrConv.toWide(mergedDataRow.hb1Field5);
                    }
                    //TVスポット.
                    else if (dataRow.hb1GyomKbn == C_GYOM_TV_SPOT)
                    {
                        //受注内容区分(企画ものはむりやり変える)
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NAIYO_KBN].Value = GetKbn(dataRow.hb1GyomKbn, dataRow.hb1TmspKbn);

                        if (CheckTougouData(dataRow, mergedDataRow))
                        {
                            //メディアコード.
                            String HYJ = GetBaitaiNm(mergedDataRow.hb1Field1);

                            //新規登録対応.
                            if (mergedDataRow.hb1Field1.Trim() != "")
                            {
                                if (HYJ == "")
                                {
                                    MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { mergedDataRow.hb1Field1.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                                else
                                {
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                            }
                        }
                        else
                        {
                            //メディアコード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = "";
                        }

                        //媒体コード.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_DENP;

                        //商品区分.
                        //vaSpread1.SetText KKSYOKBN, i, " "

                        //商品区分名称.
                        //vaSpread1.SetText KKSYOKBNNAME, i, " "

                        //店番.
                        //vaSpread1.SetText KKMISEBAN, i, " "

                        //CM秒数1
                        if (KKHUtility.IsNumeric(mergedDataRow.hb1Field5))
                        {
                            mergedDataRow.hb1Field5 = KKHUtility.DecParse(mergedDataRow.hb1Field5).ToString();
                        }

                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_CM_BYOSU].Value = KKHStrConv.toWide(mergedDataRow.hb1Field5);
                    }
                    //交通.
                    else if (dataRow.hb1GyomKbn == C_GYOM_OOH_M)
                    {
                        //区分.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NAIYO_KBN].Value = GetKbn(dataRow.hb1GyomKbn, dataRow.hb1TmspKbn);

                        if (CheckTougouData(dataRow, mergedDataRow))
                        {
                            //メディアコード.
                            String HYJ = GetBaitaiNm(mergedDataRow.hb1Field7);

                            if (mergedDataRow.hb1Field7.Trim() != "")
                            {
                                if (HYJ == "")
                                {
                                    MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { mergedDataRow.hb1Field7.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                                else
                                {
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                            }
                        }
                        else
                        {
                            //メディアコード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = "";
                        }

                        if (dataRow.hb1GyomKbn == C_GYOM_EISEI_M)
                        {
                            //媒体コード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_DENP;

                            //商品区分.
                            //vaSpread1.SetText KKSYOKBN, i, " "

                            //商品区分名称.
                            //vaSpread1.SetText KKSYOKBNNAME, i, " "

                            //店番.
                            //vaSpread1.SetText KKMISEBAN, i, " "

                            //CM秒数1
                            if (KKHUtility.IsNumeric(mergedDataRow.hb1Field5))
                            {
                                mergedDataRow.hb1Field5 = KKHUtility.DecParse(mergedDataRow.hb1Field5).ToString();
                            }

                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_CM_BYOSU].Value = KKHStrConv.toWide(mergedDataRow.hb1Field5);
                        }
                        else
                        {
                            //媒体コード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_KOTU;

                            //商品区分.
                            //vaSpread1.SetText KKSYOKBN, i, " "

                            //商品区分名称.
                            //vaSpread1.SetText KKSYOKBNNAME, i, " "

                            //店番.
                            //vaSpread1.SetText KKMISEBAN, i, " "
                        }
                    }
                    //交通広告.
                    else
                    {
                        //区分.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NAIYO_KBN].Value = GetKbn(dataRow.hb1GyomKbn, dataRow.hb1TmspKbn);

                        if (CheckTougouData(dataRow, mergedDataRow))
                        {
                            //メディアコード.
                            String HYJ = GetBaitaiNm(mergedDataRow.hb1Field1);

                            if (( HYJ == "" ) && ( mergedDataRow.hb1Field1.Trim() != "" ))
                            {
                                MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { mergedDataRow.hb1Field1.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                            }
                            else
                            {
                                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                            }
                        }
                        else
                        {
                            //メディアコード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = "";
                        }

                        if (dataRow.hb1GyomKbn == C_GYOM_EISEI_M)
                        {
                            //媒体コード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_DENP;

                            //商品区分.
                            //vaSpread1.SetText KKSYOKBN, i, " "

                            //商品区分名称.
                            //vaSpread1.SetText KKSYOKBNNAME, i, " "

                            //店番.
                            //vaSpread1.SetText KKMISEBAN, i, " "

                            //CM秒数1
                            if (KKHUtility.IsNumeric(mergedDataRow.hb1Field5))
                            {
                                mergedDataRow.hb1Field5 = KKHUtility.DecParse(mergedDataRow.hb1Field5).ToString();
                            }

                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_CM_BYOSU].Value = KKHStrConv.toWide(mergedDataRow.hb1Field5);
                        }
                        else
                        {
                            //媒体コード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_KOTU;

                            //商品区分.
                            //vaSpread1.SetText KKSYOKBN, i, " "

                            //商品区分名称.
                            //vaSpread1.SetText KKSYOKBNNAME, i, " "

                            //店番.
                            //vaSpread1.SetText KKMISEBAN, i, " "
                        }
                    }

                    string yy = dataRow.hb1Yymm.Substring(0, 4);
                    string mm = dataRow.hb1Yymm.Substring(4, 2);

                    //請求年月.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SEIKYUSHO_HAKO_BI].Value = yy + "/" + mm + "/25";

                    //支払日.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SHIHARAI_BI].Value = MonthEnd(yy, mm);

                    //消費税率.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SHOHIZEI_RITSU].Value = (decimal)mergedDataRow.hb1SzeiRitu;

                    /* 2015/01/30 アコム消費税対応 soga MOD start */
                    //消費税額.
                    //_spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SHOHIZEI_GAKU].Value = (decimal)mergedDataRow.hb1SzeiGak;
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SHOHIZEI_GAKU].Value = AutoCalcTaxInitialize((decimal)mergedDataRow.hb1SeiGak, (decimal)dataRow.hb1SzeiRitu);
                    /* 2015/01/30 アコム消費税対応 soga MOD end */

                    //金額.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_KINGAKU].Value = (decimal)mergedDataRow.hb1SeiGak;

                    //値引率.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_NEBIKI_RITSU].Value = mergedDataRow.hb1NeviRitu;

                    //値引額.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_NEBIKI_GAKU].Value = (decimal)mergedDataRow.hb1NeviGak;

                    //取料金.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_TORIRYOKIN].Value = (decimal)mergedDataRow.hb1ToriGak;

                    //受注Noをセット.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NO].Value = mergedDataRow.hb1JyutNo;

                    //受注明細Noをセット.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_MEISAI_NO].Value = mergedDataRow.hb1JyMeiNo;

                    //売上明細Noをセット.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_URIAGE_MEISAI_NO].Value = mergedDataRow.hb1UrMeiNo;

                    //請求原票Noをセット.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SEIKYU_GENPYO_NO].Value = mergedDataRow.hb1GpyNo;

                    //取引先コード.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_TORIHIKISAKI_CD].Value = C_MEISAI_SHOKICHI_TORI_CD;

                    //請求部署コード.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SEIKYU_BUSHO].Value = C_MEISAI_SHOKICHI_SEIKYU_BUSHO;

                    //値引行区分を設定.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_NEBIKI_GYO_KBN].Text = "0";
                }
            }

            //*********************.
            //画面の設定.
            //*********************.

            //取り料金.
            txtToriRyokin.Text = String.Format("{0:#,0}", dataRow.hb1SeiGak);

            //値引額.
            txtNebikiGaku.Text = String.Format("{0:#,0}", dataRow.hb1NeviGak);

            //請求金額合計.
            txtSeiKinGokei.Text = String.Format("{0:#,0}", dataRow.hb1SeiGak);

            //消費税額.
            txtShohZeigaku.Text = String.Format("{0:#,0}", dataRow.hb1SzeiGak);

            //請求額.
            decimal gaku = dataRow.hb1SeiGak + dataRow.hb1SzeiGak;
            txtSeiGak.Text = String.Format("{0:#,0}", gaku);

            //削除ボタン制御.
            CtrlSakujoBtn(0);

            //発注番号取得ボタンの制御.
            CtrlHachuBangoBtn(0);
        }

        /// <summary>
        /// 初期データの挿入.
        /// </summary>
        private void InsertInitialData2()
        {
            Common.KKHSchema.Detail.JyutyuDataRow dataRow = _naviParam.DataRow;

            //統合済みデータでない場合.
            if (dataRow.hb1TouFlg != "1")
            {
                //媒体名.
                string BaitaiNm = string.Empty;
                int _rowIdx = 0;

                //*********************.
                //CellTypeの設定.
                //*********************.
                AddSheetRow(_rowIdx);

                //int count = 0;
                //foreach (string dntscd in _dntscd)
                //{
                //    if(string.IsNullOrEmpty(dntscd)){}
                //    else if (dntscd.Equals(dataRow.hb1Field1))
                //    {
                //        BaitaiNm = _itemMediaMei[count];
                //        break;
                //    }
                //    count++;
                //}

                if (dataRow.hb1GyomKbn != C_GYOM_OOH_M)
                {
                    //メディアコード.
                    BaitaiNm = GetBaitaiNm(dataRow.hb1Field1);

                    //新規登録対応.
                    if ((BaitaiNm == "") && (dataRow.hb1Field1.Trim() != ""))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { dataRow.hb1Field1.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    //メディアコード.
                    BaitaiNm = GetBaitaiNm(dataRow.hb1Field7);

                    //新規登録対応.
                    if ((BaitaiNm == "") && (dataRow.hb1Field7.Trim() != ""))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { dataRow.hb1Field7.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                    }
                }

                //*********************.
                //スプレッドの設定.
                //*********************.
                //メディアコード.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].CellType = _cmbType;
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = BaitaiNm;
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Locked = false;
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].HorizontalAlignment = CellHorizontalAlignment.Left;

                //発注番号,請求書行番号.
                TextCellType textType = new TextCellType();
                textType.MaxLength = 8;
                _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_HACHU_NO].CellType = textType;
                _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_SEIKYUSHO_NO].CellType = textType;
                textType = new TextCellType();
                textType.MaxLength = 3;
                _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_HACHUGYO_NO].CellType = textType;
                _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_SEIKYUSHOGYO_NO].CellType = textType;

                //売上明細No
                textType = new TextCellType();
                textType.MaxLength = 10;
                _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_JUCHU_NO].CellType = textType;
                textType = new TextCellType();
                textType.MaxLength = 3;
                _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_JUCHU_MEISAI_NO].CellType = textType;
                _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_URIAGE_MEISAI_NO].CellType = textType;

                //発売日or掲載日.
                if (checkSNBN(dataRow.hb1GyomKbn) || checkZASI(dataRow.hb1GyomKbn))
                {
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_HATSUORKEISAI].Text = dataRow.hb1Field3.ToString();
                }

                //消費税率.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SHOHIZEI_RITSU].Value = (decimal)dataRow.hb1SzeiRitu;

                //消費税額.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SHOHIZEI_GAKU].Value = (decimal)dataRow.hb1SzeiGak;

                //金額.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_KINGAKU].Value = (decimal)dataRow.hb1SeiGak;

                //値引率.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_NEBIKI_RITSU].Value = dataRow.hb1NeviRitu;

                //値引額.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_NEBIKI_GAKU].Value = (decimal)dataRow.hb1NeviGak;

                //取り料金.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_TORIRYOKIN].Value = (decimal)dataRow.hb1ToriGak;

                //取引先コード.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_TORIHIKISAKI_CD].Value = "6080101";           //初期値.

                //請求部署コード.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SEIKYU_BUSHO].Value = "11328";                //初期値.

                string baicd = string.Empty;
                switch (dataRow.hb1GyomKbn)
                {
                    case C_GYOM_SHINBUN:
                        baicd = "21";
                        break;

                    case C_GYOM_ZASHI:
                        baicd = "22";
                        break;

                    case C_GYOM_RADIO:
                    case C_GYOM_TV_TIME:
                    case C_GYOM_TV_SPOT:
                    case C_GYOM_EISEI_M:
                        baicd = "11";
                        break;

                    case C_GYOM_INTE_M:
                    case C_GYOM_OOH_M:
                    case C_GYOM_SONOTA_M:
                    case C_GYOM_M_PLAN:
                    case C_GYOM_CREATE:
                    case C_GYOM_MARK_PROM:
                    case C_GYOM_SPORTS:
                    case C_GYOM_ENTE:
                    case C_GYOM_SONOTA:
                        baicd = "31";
                        break;
                }

                //媒体コード.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = baicd;

                //受注No
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NO].Value = dataRow.hb1JyutNo;

                //受注明細No
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_MEISAI_NO].Value = dataRow.hb1JyMeiNo;

                //売上明細No.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_URIAGE_MEISAI_NO].Value = dataRow.hb1UrMeiNo;

                //請求原票Noをセット.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SEIKYU_GENPYO_NO].Value = dataRow.hb1GpyNo;

                //値引行区分.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_NEBIKI_GYO_KBN].Text = "0";

                //請求書発行日.
                string yy = dataRow.hb1Yymm.Substring(0, 4);
                string mm = dataRow.hb1Yymm.Substring(4, 2);
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SEIKYUSHO_HAKO_BI].Value = yy + "/" + mm + "/25";

                //支払日.
                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SHIHARAI_BI].Value = MonthEnd(yy, mm);

                //受注内容区分.
                string JKbn = string.Empty;
                switch (_dataRow.hb1GyomKbn)
                {
                    case C_GYOM_SHINBUN:
                        JKbn = "01";
                        break;
                    case C_GYOM_ZASHI:
                        JKbn = "02";
                        break;
                    case C_GYOM_RADIO:
                        //タイムの場合.
                        if (_dataRow.hb1TmspKbn.Trim().Equals("1"))
                        {
                            JKbn = "03";
                        }
                        else if (_dataRow.hb1TmspKbn.Trim().Equals("2"))
                        {
                            JKbn = "04";
                        }
                        break;
                    case C_GYOM_TV_TIME:
                        JKbn = "05";
                        break;
                    case C_GYOM_EISEI_M:
                        if (_dataRow.hb1TmspKbn.Trim().Equals("1"))
                        {
                            JKbn = "06";
                        }
                        else if (_dataRow.hb1TmspKbn.Trim().Equals("2"))
                        {
                            JKbn = "08";
                        }
                        break;
                    case C_GYOM_TV_SPOT:
                        JKbn = "07";
                        break;
                    case C_GYOM_INTE_M:
                        JKbn = "09";
                        break;
                    case C_GYOM_OOH_M:
                        JKbn = "10";
                        break;
                    case C_GYOM_SONOTA_M:
                        JKbn = "11";
                        break;
                    case C_GYOM_M_PLAN:
                        JKbn = "12";
                        break;
                    case C_GYOM_CREATE:
                        JKbn = "13";
                        break;
                    case C_GYOM_MARK_PROM:
                        JKbn = "14";
                        break;
                    case C_GYOM_SPORTS:
                        JKbn = "15";
                        break;
                    case C_GYOM_ENTE:
                        JKbn = "16";
                        break;
                    case C_GYOM_SONOTA:
                        JKbn = "17";
                        break;
                }

                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NAIYO_KBN].Value = JKbn;

                if (checkDENP(dataRow.hb1GyomKbn))
                {
                    //CM秒数1
                    if (KKHUtility.IsNumeric(dataRow.hb1Field5))
                    {
                        dataRow.hb1Field5 = KKHUtility.DecParse(dataRow.hb1Field5).ToString();
                    }

                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_CM_BYOSU].Value = KKHStrConv.toWide(dataRow.hb1Field5);
                }
            }
            //統合済みデータの場合.
            else
            {
                //選択された受注NO、受注明細NO、売上明細NOが同じデータを構造体にセット.
                foreach (Common.KKHSchema.Detail.JyutyuDataRow mergedDataRow in _naviParam.MergeDataRow)
                {
                    int _rowIdx = _spdMeiNyuryokAcom_Sheet1.Rows.Count;

                    AddSheetRow(_rowIdx);

                    //統合データの場合親データを元に場合分け.
                    //新聞、新聞企画.
                    if (dataRow.hb1GyomKbn == C_GYOM_SHINBUN)
                    {
                        //受注内容区分(企画ものはむりやり変える)
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NAIYO_KBN].Value = GetKbn(dataRow.hb1GyomKbn, dataRow.hb1TmspKbn);

                        if (CheckTougouData(dataRow, mergedDataRow))
                        {
                            //メディアコード.
                            String HYJ = GetBaitaiNm(mergedDataRow.hb1Field1);

                            //新規登録対応.
                            if (mergedDataRow.hb1Field1.Trim() != "")
                            {
                                if (HYJ == "")
                                {
                                    MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { mergedDataRow.hb1Field1.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                                else
                                {
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                            }

                            //掲載日.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_HATSUORKEISAI].Text = mergedDataRow.hb1Field3.ToString();
                        }
                        else
                        {
                            //メディアコード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = "";

                            //掲載日.
                            //vaSpread1.SetText KKHATUBAI, i, CVar("")
                        }

                        //商品区分.
                        //vaSpread1.SetText KKSYOKBN, i, " "

                        //商品区分名称.
                        //vaSpread1.SetText KKSYOKBNNAME, i, " "

                        //店番.
                        //vaSpread1.SetText KKMISEBAN, i, " "

                        //媒体コード.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_SNBN;
                    }
                    //雑誌、雑誌企画.
                    else if (dataRow.hb1GyomKbn == C_GYOM_ZASHI)
                    {
                        //区分.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NAIYO_KBN].Value = GetKbn(dataRow.hb1GyomKbn, dataRow.hb1TmspKbn);

                        if (CheckTougouData(dataRow, mergedDataRow))
                        {
                            //メディアコード.
                            String HYJ = GetBaitaiNm(mergedDataRow.hb1Field1);

                            //新規登録対応.
                            if (mergedDataRow.hb1Field1.Trim() != "")
                            {
                                if (HYJ == "")
                                {
                                    MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { mergedDataRow.hb1Field1.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                                else
                                {
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                            }

                            //発売日.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_HATSUORKEISAI].Text = mergedDataRow.hb1Field3.ToString();
                        }
                        else
                        {
                            //メディアコード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = "";

                            //発売日.
                            //vaSpread1.SetText KKHATUBAI, i, CVar("")
                        }

                        //媒体コード.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_ZASI;

                        //商品区分.
                        //vaSpread1.SetText KKSYOKBN, i, " "

                        //商品区分名称.
                        //vaSpread1.SetText KKSYOKBNNAME, i, " "

                        //店番.
                        //vaSpread1.SetText KKMISEBAN, i, " "
                    }
                    //ラジオ.
                    else if (dataRow.hb1GyomKbn == C_GYOM_RADIO)
                    {
                        //区分.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NAIYO_KBN].Value = GetKbn(dataRow.hb1GyomKbn, dataRow.hb1TmspKbn);

                        if (CheckTougouData(dataRow, mergedDataRow))
                        {
                            //メディアコード.
                            String HYJ = GetBaitaiNm(mergedDataRow.hb1Field1);

                            //新規登録対応.
                            if (mergedDataRow.hb1Field1.Trim() != "")
                            {
                                if (HYJ == "")
                                {
                                    MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { mergedDataRow.hb1Field1.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                                else
                                {
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                            }
                        }
                        else
                        {
                            //メディアコード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = "";
                        }

                        //媒体コード.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_DENP;

                        //商品区分.
                        //vaSpread1.SetText KKSYOKBN, i, " "

                        //商品区分名称.
                        //vaSpread1.SetText KKSYOKBNNAME, i, " "

                        //店番.
                        //vaSpread1.SetText KKMISEBAN, i, " "

                        //CM秒数1
                        if (KKHUtility.IsNumeric(mergedDataRow.hb1Field5))
                        {
                            mergedDataRow.hb1Field5 = KKHUtility.DecParse(mergedDataRow.hb1Field5).ToString();
                        }

                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_CM_BYOSU].Value = KKHStrConv.toWide(mergedDataRow.hb1Field5);
                    }
                    //TVタイム.
                    else if (dataRow.hb1GyomKbn == C_GYOM_TV_TIME)
                    {
                        //受注内容区分(企画ものはむりやり変える)
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NAIYO_KBN].Value = GetKbn(dataRow.hb1GyomKbn, dataRow.hb1TmspKbn);

                        if (CheckTougouData(dataRow, mergedDataRow))
                        {
                            //メディアコード.
                            String HYJ = GetBaitaiNm(mergedDataRow.hb1Field1);

                            //新規登録対応.
                            if (mergedDataRow.hb1Field1.Trim() != "")
                            {
                                if (HYJ == "")
                                {
                                    MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { mergedDataRow.hb1Field1.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                                else
                                {
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                            }
                        }
                        else
                        {
                            //メディアコード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = "";
                        }

                        //媒体コード.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_DENP;

                        //商品区分.
                        //vaSpread1.SetText KKSYOKBN, i, " "

                        //商品区分名称.
                        //vaSpread1.SetText KKSYOKBNNAME, i, " "

                        //店番.
                        //vaSpread1.SetText KKMISEBAN, i, " "

                        //CM秒数1
                        if (KKHUtility.IsNumeric(mergedDataRow.hb1Field5))
                        {
                            mergedDataRow.hb1Field5 = KKHUtility.DecParse(mergedDataRow.hb1Field5).ToString();
                        }

                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_CM_BYOSU].Value = KKHStrConv.toWide(mergedDataRow.hb1Field5);
                    }
                    //TVスポット.
                    else if (dataRow.hb1GyomKbn == C_GYOM_TV_SPOT)
                    {
                        //受注内容区分(企画ものはむりやり変える)
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NAIYO_KBN].Value = GetKbn(dataRow.hb1GyomKbn, dataRow.hb1TmspKbn);

                        if (CheckTougouData(dataRow, mergedDataRow))
                        {
                            //メディアコード.
                            String HYJ = GetBaitaiNm(mergedDataRow.hb1Field1);

                            //新規登録対応.
                            if (mergedDataRow.hb1Field1.Trim() != "")
                            {
                                if (HYJ == "")
                                {
                                    MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { mergedDataRow.hb1Field1.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                                else
                                {
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                            }
                        }
                        else
                        {
                            //メディアコード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = "";
                        }

                        //媒体コード.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_DENP;

                        //商品区分.
                        //vaSpread1.SetText KKSYOKBN, i, " "

                        //商品区分名称.
                        //vaSpread1.SetText KKSYOKBNNAME, i, " "

                        //店番.
                        //vaSpread1.SetText KKMISEBAN, i, " "

                        //CM秒数1
                        if (KKHUtility.IsNumeric(mergedDataRow.hb1Field5))
                        {
                            mergedDataRow.hb1Field5 = KKHUtility.DecParse(mergedDataRow.hb1Field5).ToString();
                        }

                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_CM_BYOSU].Value = KKHStrConv.toWide(mergedDataRow.hb1Field5);
                    }
                    //交通.
                    else if (dataRow.hb1GyomKbn == C_GYOM_OOH_M)
                    {
                        //区分.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NAIYO_KBN].Value = GetKbn(dataRow.hb1GyomKbn, dataRow.hb1TmspKbn);

                        if (CheckTougouData(dataRow, mergedDataRow))
                        {
                            //メディアコード.
                            String HYJ = GetBaitaiNm(mergedDataRow.hb1Field7);

                            if (mergedDataRow.hb1Field7.Trim() != "")
                            {
                                if (HYJ == "")
                                {
                                    MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { mergedDataRow.hb1Field7.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                                else
                                {
                                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                                }
                            }
                        }
                        else
                        {
                            //メディアコード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = "";
                        }

                        if (dataRow.hb1GyomKbn == C_GYOM_EISEI_M)
                        {
                            //媒体コード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_DENP;

                            //商品区分.
                            //vaSpread1.SetText KKSYOKBN, i, " "

                            //商品区分名称.
                            //vaSpread1.SetText KKSYOKBNNAME, i, " "

                            //店番.
                            //vaSpread1.SetText KKMISEBAN, i, " "

                            //CM秒数1
                            if (KKHUtility.IsNumeric(mergedDataRow.hb1Field5))
                            {
                                mergedDataRow.hb1Field5 = KKHUtility.DecParse(mergedDataRow.hb1Field5).ToString();
                            }

                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_CM_BYOSU].Value = KKHStrConv.toWide(mergedDataRow.hb1Field5);
                        }
                        else
                        {
                            //媒体コード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_KOTU;

                            //商品区分.
                            //vaSpread1.SetText KKSYOKBN, i, " "

                            //商品区分名称.
                            //vaSpread1.SetText KKSYOKBNNAME, i, " "

                            //店番.
                            //vaSpread1.SetText KKMISEBAN, i, " "
                        }
                    }
                    //交通広告.
                    else
                    {
                        //区分.
                        _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NAIYO_KBN].Value = GetKbn(dataRow.hb1GyomKbn, dataRow.hb1TmspKbn);

                        if (CheckTougouData(dataRow, mergedDataRow))
                        {
                            //メディアコード.
                            String HYJ = GetBaitaiNm(mergedDataRow.hb1Field1);

                            if ((HYJ == "") && (mergedDataRow.hb1Field1.Trim() != ""))
                            {
                                MessageUtility.ShowMessageBox(MessageCode.HB_W0140, new string[] { mergedDataRow.hb1Field1.Trim(), GetBaitaiSybt(dataRow.hb1GyomKbn) }, "メディア変換エラー", MessageBoxButtons.OK);
                                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                            }
                            else
                            {
                                _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = HYJ;
                            }
                        }
                        else
                        {
                            //メディアコード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_MEDIA_CD].Text = "";
                        }

                        if (dataRow.hb1GyomKbn == C_GYOM_EISEI_M)
                        {
                            //媒体コード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_DENP;

                            //商品区分.
                            //vaSpread1.SetText KKSYOKBN, i, " "

                            //商品区分名称.
                            //vaSpread1.SetText KKSYOKBNNAME, i, " "

                            //店番.
                            //vaSpread1.SetText KKMISEBAN, i, " "

                            //CM秒数1
                            if (KKHUtility.IsNumeric(mergedDataRow.hb1Field5))
                            {
                                mergedDataRow.hb1Field5 = KKHUtility.DecParse(mergedDataRow.hb1Field5).ToString();
                            }

                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_CM_BYOSU].Value = KKHStrConv.toWide(mergedDataRow.hb1Field5);
                        }
                        else
                        {
                            //媒体コード.
                            _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_BAITAI_CD].Value = KkhConstAcom.MediaKindCode.SYBT_KOTU;

                            //商品区分.
                            //vaSpread1.SetText KKSYOKBN, i, " "

                            //商品区分名称.
                            //vaSpread1.SetText KKSYOKBNNAME, i, " "

                            //店番.
                            //vaSpread1.SetText KKMISEBAN, i, " "
                        }
                    }

                    string yy = dataRow.hb1Yymm.Substring(0, 4);
                    string mm = dataRow.hb1Yymm.Substring(4, 2);

                    //請求年月.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SEIKYUSHO_HAKO_BI].Value = yy + "/" + mm + "/25";

                    //支払日.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SHIHARAI_BI].Value = MonthEnd(yy, mm);

                    //消費税率.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SHOHIZEI_RITSU].Value = (decimal)mergedDataRow.hb1SzeiRitu;

                    //消費税額.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SHOHIZEI_GAKU].Value = (decimal)mergedDataRow.hb1SzeiGak;

                    //金額.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_KINGAKU].Value = (decimal)mergedDataRow.hb1SeiGak;

                    //値引率.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_NEBIKI_RITSU].Value = mergedDataRow.hb1NeviRitu;

                    //値引額.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_NEBIKI_GAKU].Value = (decimal)mergedDataRow.hb1NeviGak;

                    //取料金.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_TORIRYOKIN].Value = (decimal)mergedDataRow.hb1ToriGak;

                    //受注Noをセット.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_NO].Value = mergedDataRow.hb1JyutNo;

                    //受注明細Noをセット.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_JUCHU_MEISAI_NO].Value = mergedDataRow.hb1JyMeiNo;

                    //売上明細Noをセット.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_URIAGE_MEISAI_NO].Value = mergedDataRow.hb1UrMeiNo;

                    //請求原票Noをセット.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SEIKYU_GENPYO_NO].Value = mergedDataRow.hb1GpyNo;

                    //取引先コード.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_TORIHIKISAKI_CD].Value = C_MEISAI_SHOKICHI_TORI_CD;

                    //請求部署コード.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_SEIKYU_BUSHO].Value = C_MEISAI_SHOKICHI_SEIKYU_BUSHO;

                    //値引行区分を設定.
                    _spdMeiNyuryokAcom_Sheet1.Cells[_rowIdx, COLIDX_MLIST_NEBIKI_GYO_KBN].Text = "0";
                }
            }

            //*********************.
            //画面の設定.
            //*********************.

            //取り料金.
            txtToriRyokin.Text = String.Format("{0:#,0}", dataRow.hb1SeiGak);

            //値引額.
            txtNebikiGaku.Text = String.Format("{0:#,0}", dataRow.hb1NeviGak);

            //請求金額合計.
            txtSeiKinGokei.Text = String.Format("{0:#,0}", dataRow.hb1SeiGak);

            //消費税額.
            txtShohZeigaku.Text = String.Format("{0:#,0}", dataRow.hb1SzeiGak);

            //請求額.
            decimal gaku = dataRow.hb1SeiGak + dataRow.hb1SzeiGak;
            txtSeiGak.Text = String.Format("{0:#,0}", gaku);

            //削除ボタン制御.
            CtrlSakujoBtn(0);

            //発注番号取得ボタンの制御.
            CtrlHachuBangoBtn(0);
        }

        /// <summary>
        /// チェック.
        /// </summary>
        /// <param name="HedderData"></param>
        /// <param name="MeisaiData"></param>
        /// <returns></returns>
        private Boolean CheckTougouData(Common.KKHSchema.Detail.JyutyuDataRow HedderData, Common.KKHSchema.Detail.JyutyuDataRow MeisaiData)
        {
            Boolean retval;

            if
            (
                ( HedderData.hb1SeiKbn.Trim()  == MeisaiData.hb1SeiKbn.Trim()  ) &&
                ( HedderData.hb1GyomKbn.Trim() == MeisaiData.hb1GyomKbn.Trim() ) &&
                ( HedderData.hb1KokKbn.Trim()  == MeisaiData.hb1KokKbn.Trim()  )
            )
            {
                retval = true;
            }
            else
            {
                retval = false;
            }

            return retval;
        }

        /// <summary>
        /// 受注内容区分の割り出し.
        /// </summary>
        /// <param name="GyomKbn"></param>
        /// <param name="TmspKbn"></param>
        private String GetKbn( String GyomKbn, String TmspKbn )
        {
            //受注内容区分.
            string JKbn = string.Empty;

            switch (GyomKbn)
            {
                case C_GYOM_SHINBUN:
                    JKbn = "01";
                    break;
                case C_GYOM_ZASHI:
                    JKbn = "02";
                    break;
                case C_GYOM_RADIO:
                    if (TmspKbn.Trim().Equals("1"))
                    {
                        JKbn = "03";
                    }
                    else if (TmspKbn.Trim().Equals("2"))
                    {
                        JKbn = "04";
                    }
                    break;
                case C_GYOM_TV_TIME:
                    JKbn = "05";
                    break;
                case C_GYOM_EISEI_M:
                    if (TmspKbn.Trim().Equals("1"))
                    {
                        JKbn = "06";
                    }
                    else if (TmspKbn.Trim().Equals("2"))
                    {
                        JKbn = "08";
                    }
                    break;
                case C_GYOM_TV_SPOT:
                    JKbn = "07";
                    break;
                case C_GYOM_INTE_M:
                    JKbn = "09";
                    break;
                case C_GYOM_OOH_M:
                    JKbn = "10";
                    break;
                case C_GYOM_SONOTA_M:
                    JKbn = "11";
                    break;
                case C_GYOM_M_PLAN:
                    JKbn = "12";
                    break;
                case C_GYOM_CREATE:
                    JKbn = "13";
                    break;
                case C_GYOM_MARK_PROM:
                    JKbn = "14";
                    break;
                case C_GYOM_SPORTS:
                    JKbn = "15";
                    break;
                case C_GYOM_ENTE:
                    JKbn = "16";
                    break;
                case C_GYOM_SONOTA:
                    JKbn = "17";
                    break;
            }

            return JKbn;
        }

        /// <summary>
        /// メディアコードの割り出し.
        /// </summary>
        /// <param name="Field1"></param>
        /// <returns></returns>
        private String GetBaitaiNm( String Field1 )
        {
            string BaitaiNm = string.Empty;
            int count = 0;
            foreach (string dntscd in _dntscd)
            {
                if(string.IsNullOrEmpty(dntscd)){}
                else if (dntscd.Equals(Field1))
                {
                    BaitaiNm = _itemMediaMei[count];
                    break;
                }
                count++;
            }

            return BaitaiNm;
        }

        /// <summary>
        /// 媒体種別の割り出し.
        /// </summary>
        /// <param name="GyomKbn"></param>
        /// <returns></returns>
        private String GetBaitaiSybt( String GyomKbn )
        {
            String bs;

            switch (GyomKbn)
            {
            //新聞.
            case C_GYOM_SHINBUN:
                bs = "02";
                break;
            //雑誌.
            case C_GYOM_ZASHI:
                bs = "03";
                break;
            //テレビ.
            case C_GYOM_TV_TIME:
            case C_GYOM_TV_SPOT:
                bs = "04";
                break;
            //ラジオ.
            case C_GYOM_RADIO:
                bs = "05";
                break;
            case C_GYOM_EISEI_M:
                bs = "07";
                break;
            //その他.
            default:
                bs = "06";
                break;
            }

            return bs;
        }

        /// <summary>
        /// 明細データをセット.
        /// </summary>
        private void SetMeisaiValue()
        {
            for (int row = 0; row < _spdKkhDetail_Sheet1.RowCount; row++)
            {
                AddSheetRow(row);

                for (int col = 0; col < _spdKkhDetail_Sheet1.ColumnCount; col++)
                {
                    _spdMeiNyuryokAcom_Sheet1.Cells[row, col].Value = _spdKkhDetail_Sheet1.Cells[row, col].Value;
                }
            }

            //foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow row in _spdKkhDetail_Sheet1.Rows)
            //{
            //     DetailDSAcom.KkhDetailRow addRow = _dsDetailAcom.KkhDetail.NewKkhDetailRow();
            //    addRow.mediaCd = row.medihb2
            //}
        }

        /// <summary>
        /// 明細行の金額系に値を初期化する,
        /// </summary>
        /// <param name="pRowIdx"></param>
        private void SetMeisaiKngkkei(int pRowIdx)
        {
            int rowIdx = 0;
            //RowIndexが1以上、または明細行が1行以上ある場合(明細行がある場合),
            if (pRowIdx > 0 || _spdMeiNyuryokAcom_Sheet1.RowCount > 1)
            {
                rowIdx = pRowIdx + 1;
            }

            //金額.
            _spdMeiNyuryokAcom_Sheet1.Cells[rowIdx, COLIDX_MLIST_KINGAKU].Text = "0";
            _spdMeiNyuryokAcom_Sheet1.Cells[rowIdx, COLIDX_MLIST_KINGAKU].Value = 0;
            //消費税額.
            _spdMeiNyuryokAcom_Sheet1.Cells[rowIdx, COLIDX_MLIST_SHOHIZEI_GAKU].Text = "0";
            _spdMeiNyuryokAcom_Sheet1.Cells[rowIdx, COLIDX_MLIST_SHOHIZEI_GAKU].Value = 0;
            //消費税率.
            _spdMeiNyuryokAcom_Sheet1.Cells[rowIdx, COLIDX_MLIST_SHOHIZEI_RITSU].Text = "0";
            _spdMeiNyuryokAcom_Sheet1.Cells[rowIdx, COLIDX_MLIST_SHOHIZEI_RITSU].Value = 0;
            //値引率.
            _spdMeiNyuryokAcom_Sheet1.Cells[rowIdx, COLIDX_MLIST_NEBIKI_RITSU].Text = "0";
            _spdMeiNyuryokAcom_Sheet1.Cells[rowIdx, COLIDX_MLIST_NEBIKI_RITSU].Value = 0;
            //値引額.
            _spdMeiNyuryokAcom_Sheet1.Cells[rowIdx, COLIDX_MLIST_NEBIKI_GAKU].Text = "0";
            _spdMeiNyuryokAcom_Sheet1.Cells[rowIdx, COLIDX_MLIST_NEBIKI_GAKU].Value = 0;
            //取料金.
            _spdMeiNyuryokAcom_Sheet1.Cells[rowIdx, COLIDX_MLIST_TORIRYOKIN].Text = "0";
            _spdMeiNyuryokAcom_Sheet1.Cells[rowIdx, COLIDX_MLIST_TORIRYOKIN].Value = 0;

        }

        /// <summary>
        /// 明細データのロック設定,
        /// </summary>
        private void SetMeisaiLock()
        {
            for (int row = 0; row < _spdMeiNyuryokAcom_Sheet1.RowCount; row++)
            {
                //送信状況区分.
                string _soshinKbn = _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SOSHIN_JOKYO_KBN].Text;

                //予約中、送信済みの場合.
                if (_soshinKbn.Equals(C_SOSHIN_JOKYO_KBN_YOYAKUCHU) || _soshinKbn.Equals(C_SOSHIN_JOKYO_KBN_SOSHINZUMI))
                {
                    //編集不可。予約中：送信取消後編集可、送信：解除可能.
                    _spdMeiNyuryokAcom_Sheet1.Rows[row].Locked = true;
                }
                else
                {
                    //編集可.
                    _spdMeiNyuryokAcom_Sheet1.Rows[row].Locked = false;
                }
            }
        }

        /// <summary>
        /// 明細背景の色設定,
        /// </summary>
        private void SetMeisaiBackColor()
        {
            for (int row = 0; row < _spdMeiNyuryokAcom_Sheet1.RowCount; row++)
            {
                //送信状況区分.
                string _soshinKbn = _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SOSHIN_JOKYO_KBN].Text;

                Color _iro = C_BACK_COLOR_WHITE;

                //予約中の場合.
                if (_soshinKbn.Equals(C_SOSHIN_JOKYO_KBN_YOYAKUCHU))
                {
                    _iro = C_BACK_COLOR_PBLUE;
                }
                //送信済みの場合.
                else if (_soshinKbn.Equals(C_SOSHIN_JOKYO_KBN_SOSHINZUMI))
                {
                    _iro = C_BACK_COLOR_MROSE;
                }
                else
                {
                    _iro = C_BACK_COLOR_WHITE;
                }

                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_MEDIA_CD].BackColor = _iro;
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_HATSUORKEISAI].BackColor = _iro;
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SEIKYUSHO_NO].BackColor = _iro;       // 請求書番号.
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SEIKYUSHOGYO_NO].BackColor = _iro;    // 請求書行番号.
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KYU_SEIKYUSHO_NO].BackColor = _iro;
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SHOHIZEI_RITSU].BackColor = _iro;
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SHOHIZEI_GAKU].BackColor = _iro;
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KINGAKU].BackColor = _iro;
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_NEBIKI_RITSU].BackColor = _iro;
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_NEBIKI_GAKU].BackColor = _iro;
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_TORIRYOKIN].BackColor = _iro;         // 取料金.
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_TORIHIKISAKI_CD].BackColor = _iro;    // 取引先コード.
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SEIKYU_BUSHO].BackColor = _iro;
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SEIKYUSHO_HAKO_BI].BackColor = _iro;
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SHIHARAI_BI].BackColor = _iro;
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_CM_BYOSU].BackColor = _iro;
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_NAIYO_MEI].BackColor = _iro;
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_BANGUMI_MEI].BackColor = _iro;
                //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KIKAN].BackColor = _iro;

                for (int i = 0; i < _spdMeiNyuryokAcom_Sheet1.ColumnCount; i++)
                {
                    _spdMeiNyuryokAcom_Sheet1.Cells[row, i].BackColor = _iro;
                }

                //発注番号列、発注行番号列がロックされている場合.


                if ( _colmunLockState)
                {
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_HACHU_NO].BackColor = C_BACK_COLOR_LGRAY;        // 発注番号.
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_HACHUGYO_NO].BackColor = C_BACK_COLOR_LGRAY;     // 発注行番号.
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KEISAITANKA].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SHOHIN_KBN].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SHOHIN_KBN_MEI].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_TEKIYO_CD].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_BAITAI_CD].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_TEN_NO].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KEITAI_KBN_CD].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KEITAI_KBN_MEI].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KEISAIBASHO_CD].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KEISAI_KAISU].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KEISAIBASHO_CD].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SHUBETSU1_CD].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SHUBETSU2_CD].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_IROZURI_CD].BackColor = C_BACK_COLOR_LGRAY;      // 色刷コード.
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SIZE_CD].BackColor = C_BACK_COLOR_LGRAY;         // サイズコード.
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_BIKO1].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_BIKO2].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_ANBUN].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_TOROKU_DATE].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_HENKO_DATE].BackColor = C_BACK_COLOR_LGRAY;
                    //_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_TORIKESHI_DATE].BackColor = C_BACK_COLOR_LGRAY;

                    for( int i = 0; i < _spdMeiNyuryokAcom_Sheet1.ColumnCount; i++ )
                    {
                        if (IsColumnLockTarget(i))
                        {
                            _spdMeiNyuryokAcom_Sheet1.Cells[row, i].BackColor = C_BACK_COLOR_LGRAY;
                        }
                    }
                }
                //else
                //{
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_HACHU_NO].BackColor = _iro;           // 発注番号.
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_HACHUGYO_NO].BackColor = _iro;        // 発注行番号.
                //    //_spdMeiNyuryokAcom_Sheet1.Cells[row , COLIDX_MLIST_SEIKYUSHO_NO].BackColor = _iro;    // 請求書番号.
                //    //_spdMeiNyuryokAcom_Sheet1.Cells[row , COLIDX_MLIST_SEIKYUSHOGYO_NO].BackColor = _iro; // 請求書行番号.
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KEISAITANKA].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SHOHIN_KBN].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SHOHIN_KBN_MEI].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_TEKIYO_CD].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_BAITAI_CD].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_TEN_NO].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KEITAI_KBN_CD].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KEITAI_KBN_MEI].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KEISAIBASHO_CD].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KEISAI_KAISU].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KEISAIBASHO_CD].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SHUBETSU1_CD].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SHUBETSU2_CD].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_IROZURI_CD].BackColor = _iro;         // 色刷コード.
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SIZE_CD].BackColor = _iro;            // サイズコード.
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_BIKO1].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_BIKO2].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_ANBUN].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_TOROKU_DATE].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_HENKO_DATE].BackColor = _iro;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_TORIKESHI_DATE].BackColor = _iro;
                //}

                //値引追加の行の色を付ける.
                //if(_spdMeiNyuryokAcom_Sheet1.Cells[row , COLIDX_MLIST_NEBIKI_GYO_KBN].Text.Equals("1"))
                //{
                //    //値引率、値引額の色を付ける.
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_NEBIKI_RITSU].BackColor = Color.LightGray;
                //    _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_NEBIKI_GAKU].BackColor = Color.LightGray;
                //}
            }
        }

        /// <summary>
        /// 明細データを登録.
        /// </summary>
        private void RegistrationMeisaiValue()
        {
            _spdKkhDetail_Sheet1.Rows.Count = 0;

            for (int row = 0; row < _spdMeiNyuryokAcom_Sheet1.RowCount; row++)
            {
                _spdKkhDetail_Sheet1.Rows.Add(row, 1);

                for (int col = 0; col < _spdMeiNyuryokAcom_Sheet1.ColumnCount; col++)
                {
                    _spdKkhDetail_Sheet1.Cells[row, col].Value = _spdMeiNyuryokAcom_Sheet1.Cells[row, col].Value;
                }
            }
        }

        /// <summary>
        /// 広告費明細スプレッドのデザイン初期化を行う.
        /// </summary>
        private void InitializeDesignForSpdKkhDetail()
        {
            //********************************.
            //スプレッド全体の設定 .
            //********************************.
            //_spdKkhDetail.DataSource = _bsKkhDetail;
            //_spdKkhDetail_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;//単一選択.
            //_spdKkhDetail_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;       //行単位選択.
            //_spdKkhDetail_Sheet1.OperationMode = OperationMode.SingleSelect;                        //
            //_spdKkhDetail_Sheet1.RowHeaderVisible = true;                                           //行ヘッダ表示.
            //_spdKkhDetail_Sheet1.RowHeaderAutoText = HeaderAutoText.Numbers;                        //行ヘッダに行番号を表示.

            //明細登録画面のデータソースを明細入力画面にセット.
//          _bsKkhDetail.DataSource = _spdOutputSheet.DataSource;

            //スプレッドシートの設定.
            _spdMeiNyuryokAcom_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Range;
            _spdMeiNyuryokAcom_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Cell;
            //_spdMeiNyuryokAcom_Sheet1.OperationMode = OperationMode.RowMode;
            //_spdMeiNyuryokAcom_Sheet1.OperationMode = OperationMode.SingleSelect;
            _spdMeiNyuryokAcom_Sheet1.RowHeaderVisible = true;
            _spdMeiNyuryokAcom_Sheet1.RowHeaderAutoText = HeaderAutoText.Numbers;
            _spdMeiNyuryokAcom.ActiveSheet.ColumnHeader.Rows[0].Height = 30;
            //Color _iro = C_BACK_COLOR_WHITE;

            //********************************.
            //列毎の設定.
            //********************************.
            #region 列毎の設定.
            foreach (Column col in _spdMeiNyuryokAcom_Sheet1.Columns)
            {
                //共通設定.
                col.AllowAutoFilter = true;//フィルタ機能を有効.
                col.AllowAutoSort = true;  //ソート機能を有効.
                _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(1 , col.Index).Value = string.Empty;

                if (col.Index == COLIDX_MLIST_MEDIA_CD)
                {
                    //string[] _arrMediaCdMei = null;
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData = _itemMediaiCd;
                    type.Items = _itemMediaMei;
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;

                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "メディアコード";

                    //col.Label = "メディアコード";
                    col.CellType = type;
                    col.HorizontalAlignment = CellHorizontalAlignment.Left;
                    col.Width = 180;
                }
                else if (col.Index == COLIDX_MLIST_HATSUORKEISAI)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "発売日 or 掲載日";

                    //col.Label = "発売日 or 掲載日";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 110;
                }
                else if (col.Index == COLIDX_MLIST_HACHU_NO)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "発注番号";

                    //col.Label = "発注番号";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 80;
                    TextCellType cellType = new TextCellType();
                    cellType.CharacterSet = CharacterSet.AlphaNumeric;

                }
                else if (col.Index == COLIDX_MLIST_HACHUGYO_NO)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "発注行番号";

                    //col.Label = "発注行番号";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 100;
                    TextCellType cellType = new TextCellType();
                    cellType.CharacterSet = CharacterSet.AlphaNumeric;
                }
                else if (col.Index == COLIDX_MLIST_SEIKYUSHO_NO)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "請求書番号";

                    //col.Label = "請求書番号";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_SEIKYUSHOGYO_NO)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "請求書\n行番号";

                    //col.Label = "請求書\n行番号";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 80;
                }
                else if (col.Index == COLIDX_MLIST_KYU_SEIKYUSHO_NO)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "旧請求書番号";

                    //col.Label = "旧請求書\n番号";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 80;
                }
                else if (col.Index == COLIDX_MLIST_SHOHIZEI_RITSU)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.ShowSeparator = true;

                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "消費税率";

                    //col.Label = "消費税率";
                    col.CellType = type;
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                    col.Width = 70;
                }
                else if (col.Index == COLIDX_MLIST_SHOHIZEI_GAKU)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.ShowSeparator = true;

                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "消費税額";

                    //col.Label = "消費税額";
                    col.CellType = type;
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_KINGAKU)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.ShowSeparator = true;

                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "金額";

                    col.CellType = type;
                    //col.Label = "金額";
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_KEISAITANKA)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.ShowSeparator = true;

                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "掲載単価";

                    //col.Label = "掲載単価";
                    col.CellType = type;
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_NEBIKI_RITSU)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.ShowSeparator = true;

                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "値引率";

                    //col.Label = "値引率";
                    col.CellType = type;
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                    col.Width = 70;
                }
                else if (col.Index == COLIDX_MLIST_NEBIKI_GAKU)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.ShowSeparator = true;

                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "値引額";

                    //col.Label = "値引額";
                    col.CellType = type;
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_TORIRYOKIN)
                {
                    NumberCellType ntype = new NumberCellType();
                    ntype.DecimalPlaces = 0;
                    ntype.ShowSeparator = true;
                    //ntype.MaximumValue = 99999999999;
                    //ntype.MinimumValue = 0;
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "取料金";

                    //col.Label = "取料金";
                    col.CellType = ntype;
                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                    col.Width = 90;
                    //_spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_TORIRYOKIN].CellType = type;

                }
                else if (col.Index == COLIDX_MLIST_TORIHIKISAKI_CD)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "取引先\nコード";

                    //col.Label = "取引先\nコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_SEIKYU_BUSHO)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "請求部署\nコード";

                    //col.Label = "請求部署\nコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_SEIKYUSHO_HAKO_BI)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "請求書\n発行日";

                    //col.Label = "請求書\n発行日";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_SHIHARAI_BI)     //支払日.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "支払日";

                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_CM_BYOSU)     //CM秒数.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "CM秒数";

                    col.HorizontalAlignment = CellHorizontalAlignment.Right;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_NAIYO_MEI)     //内容名称.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "内容名称";

                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_BANGUMI_MEI)     //番組名.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "番組名";

                    col.HorizontalAlignment = CellHorizontalAlignment.Left;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_KIKAN)     //期間.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "期間";

                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_SHOHIN_KBN)      //商品区分.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "商品区分";

                    //col.Label = "商品区分";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_SHOHIN_KBN_MEI)  //商品区分名称.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "商品区分\n名称";

                    // col.Label = "商品区分\n名称";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_TEKIYO_CD)   //摘要コード.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "摘要\nコード";

                    //col.Label = "摘要\nコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_BAITAI_CD)   //媒体コード.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "媒体\nコード";

                    //col.Label = "媒体\nコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_TEN_NO)      //店番.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "店番";

                    //col.Label = "店番";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_KEISAIBASHO_CD)      //掲載場所コード.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "掲載場所\nコード";

                    //col.Label = "掲載場所\nコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_SHUBETSU1_CD)    //種別１コード.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "種別1\nコード";

                    // col.Label = "種別１\nコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_SHUBETSU2_CD)    //種別２コード.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "種別2\nコード";

                    //col.Label = "種別\n２コード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_IROZURI_CD)  //色刷コード.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "色刷\nコード";

                    // col.Label = "色刷\nコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_SIZE_CD) //サイズコード.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "サイズ\nコード";

                    //col.Label = "サイズ\nコード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_KEITAI_KBN_CD) //形態区分コード.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "形態区分コード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_KEITAI_KBN_MEI) //形態区分名称コード.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "形態区分名称";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_KOTSU_KEISAI_CD) //交通掲載コード.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "交通掲載コード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_KEISAI_KAISU) //掲載回数コード.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "掲載回数コード";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_BIKO1)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "備考1";

                    // col.Label = "備考１";
                    col.HorizontalAlignment = CellHorizontalAlignment.Left;
                    col.Width = 120;
                }
                else if (col.Index == COLIDX_MLIST_BIKO2)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "備考2";

                    // col.Label = "備考２";
                    col.HorizontalAlignment = CellHorizontalAlignment.Left;
                    col.Width = 120;
                }
                else if (col.Index == COLIDX_MLIST_ANBUN)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "按分種別";

                    // col.Label = "按分種別";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_JUCHU_NAIYO_KBN)   //受注内容区分.
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "受注内容区分";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_TOROKU_DATE)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "登録年月日";

                    // col.Label = "登録年月日";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_HENKO_DATE)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "変更年月日";

                    //  col.Label = "変更年月日";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_TORIKESHI_DATE)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "取消年月日";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_JUCHU_NO)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "受注No";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_JUCHU_MEISAI_NO)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "受注明細No";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_URIAGE_MEISAI_NO)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "売上明細No";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_SEIKYU_GENPYO_NO)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = " 請求原票No";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_SOSHIN_JOKYO_KBN)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "送信状況区分";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_SHUTSURYOKU_DATE)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "出力日";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else if (col.Index == COLIDX_MLIST_NEBIKI_GYO_KBN)
                {
                    _spdMeiNyuryokAcom_Sheet1.ColumnHeader.Cells.Get(0 , col.Index).Value = "値引行区分";
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Width = 90;
                }
                else
                {
                    _spdMeiNyuryokAcom_Sheet1.RemoveColumns(col.Index , 1);
                }
            }
            #endregion 列毎の設定.

            ////********************************.
            ////送信状況区分によるロック.
            ////********************************.
            //#region 送信状況区分によるロック.

            //for (int row = 0 ; row < _spdMeiNyuryokAcom_Sheet1.RowCount ; row++)
            //{
            //    //送信状況区分.
            //    string _soshinKbn = _spdMeiNyuryokAcom_Sheet1.Cells[row , COLIDX_MLIST_SOSHIN_JOKYO_KBN].Text;
            //    Color _iro = C_BACK_COLOR_WHITE;

            //    //予約中、送信済みの場合.
            //    if (_soshinKbn.Equals(C_SOSHIN_JOKYO_KBN_YOYAKUCHU)
            //        || _soshinKbn.Equals(C_SOSHIN_JOKYO_KBN_SOSHINZUMI))
            //    {
            //        //編集不可。予約中：送信取消後編集可、送信：解除可能.
            //        _spdMeiNyuryokAcom_Sheet1.Rows[row].Locked = true;
            //        _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_HACHU_NO].Locked = true;
            //        _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_HACHUGYO_NO].Locked = true;
            //        //_iro = C_BACK_COLOR_PBLUE;
            //        //_spdMeiNyuryokAcom_Sheet1.Cells[row , COLIDX_MLIST_MEDIA_CD].BackColor = C_BACK_COLOR_PBLUE;
            //    }
            //    ////送信済みの場合.
            //    //else if (_soshinKbn.Equals(C_SOSHIN_JOKYO_KBN_SOSHINZUMI))
            //    //{
            //    //    //編集不可、但し解除可能.
            //    //    _spdMeiNyuryokAcom_Sheet1.Rows[row].Locked = true;
            //    //    _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_HACHU_NO].Locked = true;
            //    //    _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_HACHUGYO_NO].Locked = true;
            //    //    //_iro = C_BACK_COLOR_MROSE;
            //    //    //_spdMeiNyuryokAcom_Sheet1.Cells[row , COLIDX_MLIST_MEDIA_CD].BackColor = C_BACK_COLOR_MROSE;

            //    //}
            //    else
            //    {
            //        //編集可.
            //        _spdMeiNyuryokAcom_Sheet1.Rows[row].Locked = false;
            //        _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_HACHU_NO].Locked = false;
            //        _spdMeiNyuryokAcom_Sheet1.Columns[COLIDX_MLIST_HACHUGYO_NO].Locked = false;
            //        //_iro = C_BACK_COLOR_WHITE;
            //    }
            //}

            //#endregion 送信状況区分によるロック.

            //********************************.
            //送信状況区分による色設定.
            //********************************.
            SetMeisaiBackColor();
        }

        /// <summary>
        /// 種別ごとに表示対象外列の非表示処理を行う.
        /// </summary>
        protected void VisibleMeisaiColumns(string gyomKbn)
        {
            //業務区分で列の表示を制御する.
            foreach (Column col in _spdMeiNyuryokAcom_Sheet1.Columns)
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
                if (col.Index == COLIDX_MLIST_JUCHU_NO) { col.Visible = false; }             //受注No.
                if (col.Index == COLIDX_MLIST_JUCHU_MEISAI_NO) { col.Visible = false; }      //受注明細No.
                if (col.Index == COLIDX_MLIST_URIAGE_MEISAI_NO) { col.Visible = false; }     //売上明細No.
                if (col.Index == COLIDX_MLIST_SEIKYU_GENPYO_NO) { col.Visible = false; }     //請求原票No.
                if (col.Index == COLIDX_MLIST_SOSHIN_JOKYO_KBN) { col.Visible = false; }     //送信状況区分.
                if (col.Index == COLIDX_MLIST_SHUTSURYOKU_DATE) { col.Visible = false; }     //出力日.
                if (col.Index == COLIDX_MLIST_NEBIKI_GYO_KBN) { col.Visible = false; }       //値引行区分.
            }
        }

        /// <summary>
        /// メディコード名称をコンボボックスにセットする.
        /// </summary>
        private void SetMediaCdMeiCmb()
        {
            MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result;
            //MasterMaintenance ds;
            MasterMaintenance.MasterDataVORow[] rows;

            List<string> lstKeys;
            List<string> lstValues;
            List<string> dtscd;
            // メディアコードマスタ取得.
            cmbMediaCd.Items.Clear();

            result = process.FindMasterByCond(_naviParam.strEsqId ,
                                            _naviParam.strEgcd ,
                                            _naviParam.strTksKgyCd ,
                                            _naviParam.strTksBmnSeqNo ,
                                            _naviParam.strTksTntSeqNo ,
                                             DetailInputAcom.C_MST_MEDIA_CD ,
                                            null);
            if (result.HasError)
            {
                return;
            }

            _dsMediaCd = result.MasterDataSet;

            //新聞.
            if (_mGyomKbn.Equals(C_GYOM_SHINBUN))
            {
                rows = (MasterMaintenance.MasterDataVORow[])_dsMediaCd.MasterDataVO.Select("Column1 = '" + KkhConstAcom.SyuBetuID.ID_SHINBUN + "'" );
            }
            //雑誌.
            else if (_mGyomKbn.Equals(C_GYOM_ZASHI))
            {
                rows = (MasterMaintenance.MasterDataVORow[])_dsMediaCd.MasterDataVO.Select("Column1 = '" + KkhConstAcom.SyuBetuID.ID_ZASHI + "'");
            }
            //テレビ.
            else if (_mGyomKbn.Equals(C_GYOM_TV_TIME) || _mGyomKbn.Equals(C_GYOM_TV_SPOT))
            {
                rows = (MasterMaintenance.MasterDataVORow[])_dsMediaCd.MasterDataVO.Select("Column1 = '" + KkhConstAcom.SyuBetuID.ID_TV + "'");
            }
            //ラジオ.
            else if (_mGyomKbn.Equals(C_GYOM_RADIO))
            {
                rows = (MasterMaintenance.MasterDataVORow[])_dsMediaCd.MasterDataVO.Select("Column1 = '" + KkhConstAcom.SyuBetuID.ID_RADIO + "'");
            }
//          //交通.
//          else if (_mGyomKbn.Equals(C_GYOM_OOH_M))
//          {
//              rows = (MasterMaintenance.MasterDataVORow[])_dsMediaCd.MasterDataVO.Select("Column1 = '" + KkhConstAcom.SyuBetuID.ID_OOH + "'");
//          }
            //CS/BS
            else if (_mGyomKbn.Equals(C_GYOM_EISEI_M))
            {
                rows = (MasterMaintenance.MasterDataVORow[])_dsMediaCd.MasterDataVO.Select("Column1 = '" + KkhConstAcom.SyuBetuID.ID_EISEI + "'");
            }
            //上記以外.
            else
            {
//              rows = (MasterMaintenance.MasterDataVORow[])_dsMediaCd.MasterDataVO.Select("", "");
                rows = (MasterMaintenance.MasterDataVORow[])_dsMediaCd.MasterDataVO.Select("Column1 = '" + KkhConstAcom.SyuBetuID.ID_OOH + "'");
            }
            lstKeys = new List<string>();
            lstValues = new List<string>();
            dtscd = new List<string>();
            lstKeys.Add(string.Empty);
            lstValues.Add(string.Empty);
            dtscd.Add(string.Empty);
            //_dictBaitai = new Dictionary<string , Dictionary<string[] , string[]>>();

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                //lstKeys.Add(row.Column2);
                lstKeys.Add(row.Column2);
                lstValues.Add(row.Column2 + " " + row.Column3);
                dtscd.Add(row.Column4);
                //_dictBaitai.Add(row.Column1 , null);
            }

            // メディアコードマスタ情報設定.
            _itemMediaiCd = lstKeys.ToArray();
            _itemMediaMei = lstValues.ToArray();
            _dntscd = dtscd.ToArray();
            cmbMediaCd.Items.AddRange(lstValues.ToArray());
            //MasterMaintenance.MasterDataVODataTable dtBanRyo =
            //    new MasterMaintenance.MasterDataVODataTable();
            //MasterMaintenance.MasterDataVORow voRow = dtBanRyo.NewMasterDataVORow();
            ////空行を追加.
            //dtBanRyo.AddMasterDataVORow(voRow);
            //dtBanRyo.Merge(result.MasterDataSet.MasterDataVO);
            //dtBanRyo.AcceptChanges();

            ////コンボボックスのDataSourceにDataTableを割り当てる.
            //this.cmbMediaCd.DataSource = dtBanRyo;
            ////表示される値はDataTableのColumn1列().
            //this.cmbMediaCd.DisplayMember = dtBanRyo.Column2Column.ColumnName + " " + dtBanRyo.Column3Column.ColumnName;
            ////.
            //this.cmbMediaCd.ValueMember = dtBanRyo.Column3Column.ColumnName;
        }

        /* 2015/01/05 アコム消費税対応 HLC fujimoto ADD start */
        /// <summary>
        /// 消費税端数処理マスター取得.
        /// </summary>
        /// <returns>消費税端数処理区分</returns>
        private string GetTaxRounding()
        {
            string strTaxRounding = "";

            MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result = process.FindMasterByCond(_naviParam.strEsqId,
                                                                                        _naviParam.strEgcd,
                                                                                        _naviParam.strTksKgyCd,
                                                                                        _naviParam.strTksBmnSeqNo,
                                                                                        _naviParam.strTksTntSeqNo,
                                                                                        DetailInputAcom.C_MST_TAX_ROUND,
                                                                                        null);

            if (!result.HasError)
            {
                MasterMaintenance.MasterDataVORow[] rows = (MasterMaintenance.MasterDataVORow[])result.MasterDataSet.MasterDataVO.Select();
                strTaxRounding = rows[0]["Column2"].ToString();
            }

            return strTaxRounding;
        }
        /* 2015/01/05 アコム消費税対応 HLC fujimoto ADD end */

        /// <summary>
        /// 請求データ送信済みチェック.
        /// </summary>
        /// <returns>送信済み：false</returns>
        private void ChkSeikyuDataSoshin(string soshinJokyo)
        {
            switch (soshinJokyo)
            {
                case C_SOSHIN_JOKYO_KBN_YOYAKUCHU:
                    break;
            }
        }

        /// <summary>
        /// 列ロックの対象かを返す.
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        private bool IsColumnLockTarget( int column )
        {
            return (
                ( column == COLIDX_MLIST_HACHU_NO        ) ||
                ( column == COLIDX_MLIST_HACHUGYO_NO     ) ||
                ( column == COLIDX_MLIST_KEISAITANKA     ) ||
                ( column == COLIDX_MLIST_SHOHIN_KBN      ) ||
                ( column == COLIDX_MLIST_SHOHIN_KBN_MEI  ) ||
                ( column == COLIDX_MLIST_TEKIYO_CD       ) ||
                ( column == COLIDX_MLIST_BAITAI_CD       ) ||
                ( column == COLIDX_MLIST_TEN_NO          ) ||
                ( column == COLIDX_MLIST_KEITAI_KBN_CD   ) ||
                ( column == COLIDX_MLIST_KEITAI_KBN_MEI  ) ||
                ( column == COLIDX_MLIST_KEISAIBASHO_CD  ) ||
                ( column == COLIDX_MLIST_KEISAI_KAISU    ) ||
                ( column == COLIDX_MLIST_KEISAIBASHO_CD  ) ||
                ( column == COLIDX_MLIST_SHUBETSU1_CD    ) ||
                ( column == COLIDX_MLIST_SHUBETSU2_CD    ) ||
                ( column == COLIDX_MLIST_IROZURI_CD      ) ||
                ( column == COLIDX_MLIST_SIZE_CD         ) ||
                ( column == COLIDX_MLIST_BIKO1           ) ||
                ( column == COLIDX_MLIST_BIKO2           ) ||
                ( column == COLIDX_MLIST_ANBUN           ) ||
                ( column == COLIDX_MLIST_TOROKU_DATE     ) ||
                ( column == COLIDX_MLIST_HENKO_DATE      ) ||
                ( column == COLIDX_MLIST_TORIKESHI_DATE  ) ||
                ( column == COLIDX_MLIST_KOTSU_KEISAI_CD )
            );
        }

        /// <summary>
        /// 列ロックの制御.
        /// </summary>
        private void CtrlColumnLock()
        {
            if (_colmunLockState)
            {
                // 列ロック対象行のロック.
                for( int i = 0; i < _spdMeiNyuryokAcom_Sheet1.ColumnCount; i++ )
                {
                    if( IsColumnLockTarget( i ) )
                    {
                        _spdMeiNyuryokAcom_Sheet1.Columns[ i ].Locked = true;
                    }
                }
            }
            else
            {
                // 列ロック対象行のロック解除.
                for( int i = 0; i < _spdMeiNyuryokAcom_Sheet1.ColumnCount; i++ )
                {
                    if( IsColumnLockTarget( i ) )
                    {
                        _spdMeiNyuryokAcom_Sheet1.Columns[ i ].Locked = false;
                    }
                }
            }
        }

        /// <summary>
        /// 削除ボタンの制御.
        /// </summary>
        /// <param name="rowIndex"></param>
        private void CtrlSakujoBtn( int rowIndex )
        {
            //行にロックがかかっている場合.
            if (_spdMeiNyuryokAcom_Sheet1.Rows[rowIndex].Locked)
            {
                //削除ボタン押下不可.
                btnSakujo.Enabled = false;
            }
            else
            {
                //削除ボタン押下可.
                btnSakujo.Enabled = true;
            }
        }

        /// <summary>
        /// 発注番号取得ボタンの制御.
        /// </summary>
        /// <param name="rowIndex"></param>
        private void CtrlHachuBangoBtn( int rowIndex )
        {
            //行にロックがかかっている場合.
            if (_spdMeiNyuryokAcom_Sheet1.Rows[rowIndex].Locked)
            {
                //削除ボタン押下不可.
                btnHachuBango.Enabled = false;
            }
            else
            {
                //削除ボタン押下可.
                btnHachuBango.Enabled = true;
            }
        }

        /// <summary>
        /// 明細シートに行を追加する.
        /// </summary>
        /// <param name="_pRowIdx"></param>
        private void AddSheetRow(int _pRowIdx)
        {
            //*********************.
            //行を追加.
            //*********************.
            _spdMeiNyuryokAcom_Sheet1.AddRows(_pRowIdx, 1);

            //*********************.
            //CellTypeの設定.
            //*********************.
            //Text.
            _spdMeiNyuryokAcom_Sheet1.Rows[_pRowIdx].CellType = _txtType;

            //Number.
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_SHOHIZEI_RITSU].CellType = NewNumCelltype(99);
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_SHOHIZEI_GAKU].CellType = NewNumCelltype(999999999999, -999999999999);
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_KINGAKU].CellType = NewNumCelltype(999999999999, -999999999999);
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_KEISAITANKA].CellType = NewNumCelltype(99999999, -99999999);
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_NEBIKI_RITSU].CellType = NewNumCelltype(99, -99);
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_NEBIKI_GAKU].CellType = NewNumCelltype(999999999999, -999999999999);
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_TORIRYOKIN].CellType = NewNumCelltype(99999999999, -99999999999);

            //Combo.
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_MEDIA_CD].CellType = _cmbType;

            //Text8
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_HATSUORKEISAI].CellType = _text8CellType;
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_HACHU_NO].CellType = _text8CellType;

            //Number1
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_ANBUN].CellType = _number1CellType;

            //Number3
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_HACHUGYO_NO].CellType = _number3CellType;
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_SEIKYUSHOGYO_NO].CellType = _number3CellType;

            //Number8
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_SEIKYUSHO_NO].CellType = _number8CellType;
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_KYU_SEIKYUSHO_NO].CellType = _number8CellType;

            //txet
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_SHOHIN_KBN].CellType = NewTxtCelltype(5, CharacterSet.Ascii);
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_TEKIYO_CD].CellType = NewTxtCelltype(5, CharacterSet.Ascii);
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_BAITAI_CD].CellType = NewTxtCelltype(2, CharacterSet.Ascii);
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_TEN_NO].CellType = NewTxtCelltype(5, CharacterSet.Ascii);
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_KEISAIBASHO_CD].CellType = NewTxtCelltype(2, CharacterSet.Numeric);
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_SHUBETSU1_CD].CellType = NewTxtCelltype(2, CharacterSet.Numeric);
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_SHUBETSU2_CD].CellType = NewTxtCelltype(2, CharacterSet.Numeric);
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_IROZURI_CD].CellType = NewTxtCelltype(2, CharacterSet.Numeric);
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_SIZE_CD].CellType = NewTxtCelltype(2, CharacterSet.Numeric);
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_TOROKU_DATE].CellType = NewTxtCelltype(8, CharacterSet.Numeric);
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_HENKO_DATE].CellType = NewTxtCelltype(8, CharacterSet.Numeric);
            _spdMeiNyuryokAcom_Sheet1.Cells[_pRowIdx, COLIDX_MLIST_TORIKESHI_DATE].CellType = NewTxtCelltype(8, CharacterSet.Numeric);
        }

        /// <summary>
        /// 月末日取得.
        /// </summary>
        /// <param name="yy"></param>
        /// <param name="mm"></param>
        /// <returns></returns>
        private string MonthEnd(string yy, string mm)
        {
            string day = string.Empty;
            int _yy;
            int _mm;
            if (mm.Equals("12"))
            {
                _yy = int.Parse(yy) + 1;
                yy = _yy.ToString();
                mm = "01";
            }
            else
            {
                _mm = int.Parse(mm) + 1;
                mm = _mm.ToString();
                if (mm.Length == 1) { mm = "0" + mm; }
            }

            switch (mm)
            {
                case "01":
                case "03":
                case "05":
                case "07":
                case "08":
                case "10":
                case "12":
                    day = "31";
                    break;
                case "04":
                case "06":
                case "09":
                case "11":
                    day = "30";
                    break;
                case "02":
                    //閏年の場合.
                    if (int.Parse(yy) % 4 == 0) { day = "29"; }
                    else { day = "28"; }
                    break;
            }

            return yy + "/" + mm + "/" + day;
        }

        /// <summary>
        /// 登録チェック.
        /// </summary>
        private string registrationCheck()
        {
            //スプレッド行数.
            int sprgyou = 1;
            //発注番号チェックエラーカウント.
            int hatyuerrorcnt = 0;
            //発注番号チェック用コメント.
            string hatyucomment = string.Empty;

            for (int sprRow = 0; sprRow < _spdMeiNyuryokAcom_Sheet1.Rows.Count; sprRow++)
            {
                //****************************************
                //発注番号チェック.
                //****************************************

                //発注番号.
                string HatyuBan = _spdMeiNyuryokAcom_Sheet1.Cells[sprRow, COLIDX_MLIST_HACHU_NO].Text;

                //Nullチェック.
                if (string.IsNullOrEmpty(HatyuBan))
                {
                    if (hatyuerrorcnt < 5)
                    {
                        hatyucomment = hatyucomment + "\n[" + sprgyou.ToString() + "行目] 発注番号が未入力";
                    }

                    hatyuerrorcnt++;
                }
                else if (HatyuBan.Length != 8)
                {
                    return "発注番号は８桁で入力して下さい";
                }

                //****************************************
                //発注行番号チェック.
                //****************************************
                //発注行番号.
                string HatyuRowBan = _spdMeiNyuryokAcom_Sheet1.Cells[sprRow, COLIDX_MLIST_HACHUGYO_NO].Text;
                //発注番号チェック用コメント.
                string hatyuRowcomment = string.Empty;
                //Nullチェック.
                if (string.IsNullOrEmpty(HatyuRowBan))
                {
                    if (hatyuerrorcnt < 5)
                    {
                        hatyucomment = hatyucomment + "\n[" + sprgyou.ToString() + "行目] 発注行番号が未入力";
                    }

                    hatyuerrorcnt++;
                }
                //桁数チェック.
                else if (HatyuRowBan.Length != 3)
                {
                    //if (hatyuerrorcnt < 5)
                    //{
                    //    hatyucomment = hatyucomment + "\n[" + sprgyou.ToString() + "行目] 発注行番号は3桁で入力して下さい";
                    //}
                    //
                    //hatyuerrorcnt++;

                    return "発注行番号は3桁で入力して下さい";
                }

                //if (hatyuerrorcnt > 5)
                //{
                //    hatyuerrorcnt++;
                //}

                //*****************************************
                //メディアコードチェック.
                //*****************************************
                if (string.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[sprRow, COLIDX_MLIST_MEDIA_CD].Text))
                {
                    return "[" + sprgyou.ToString() + "行目]メディアコードを選択してください。";
                }

                //*****************************************
                //請求書番号・請求書行番号チェック.
                //*****************************************

                //請求書番号.
                string SeikyuBan = _spdMeiNyuryokAcom_Sheet1.Cells[sprRow, COLIDX_MLIST_SEIKYUSHO_NO].Text;
                //請求書行番号.
                string SeikyuRowBan = _spdMeiNyuryokAcom_Sheet1.Cells[sprRow, COLIDX_MLIST_SEIKYUSHOGYO_NO].Text;
                //掲載日.
                string KeisaiBi = _spdMeiNyuryokAcom_Sheet1.Cells[sprRow, COLIDX_MLIST_HATSUORKEISAI].Text;

                //請求書番号または請求書行番号いずれかがあるか確認.
                if (SeikyuBan.Length > 0 || SeikyuRowBan.Length > 0)
                {
                    //請求書番号または請求書行番号いずれかがないか確認.
                    if (SeikyuBan.Length == 0 || SeikyuRowBan.Length == 0)
                    {
                        return "請求書番号と請求書行番号は両方入力して下さい";
                    }
                    //請求書番号あり、8桁以外か確認.
                    if (SeikyuBan.Length != 8)
                    {
                        return "請求書番号は８桁で入力して下さい";
                    }
                    //重複チェック.
                    for (int i = sprRow + 1; i < _spdMeiNyuryokAcom_Sheet1.Rows.Count; i++)
                    {
                        //重複調査行の請求書番号.
                        string ChkSeikyuBan = _spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSHO_NO].Text;
                        //重複調査行の請求書行番号.
                        string ChkSeikyuRowBan = _spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSHOGYO_NO].Text;
                        //重複調査行の発注番号.
                        string ChkHatyuBan = _spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_HACHU_NO].Text;
                        //重複調査行の発注行番号.
                        string ChkHatyuRowBan = _spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_HACHUGYO_NO].Text;
                        //重複調査行の掲載日.
                        string ChkKeisaiBi = _spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_HATSUORKEISAI].Text;

                        //請求書番号の重複がスプレッドにあるか確認.
                        if (SeikyuBan.Equals(ChkSeikyuBan))
                        {
                            if (!HatyuBan.Equals(ChkHatyuBan))
                            {
                                i = i + 1;
                                return "異なる発注番号に同じ請求書番号が設定されています。" + sprgyou.ToString() + "行目 と" + i + "行目";
                            }
                        }
                        //請求書番号・請求書行番号の重複がスプレッドにあるか確認.
                        if (SeikyuBan.Equals(ChkSeikyuBan) && SeikyuRowBan.Equals(ChkSeikyuRowBan))
                        {
                            //発注番号・発注行番号が相違しているか確認.
                            if (!HatyuBan.Equals(ChkHatyuBan) || !HatyuRowBan.Equals(ChkHatyuRowBan))
                            {
                                i = i + 1;
                                return "異なる発注番号・発注行番号に同じ請求書番号・請求書行番号が設定されています" + sprgyou.ToString() + "行目 と" + i + "行目";
                            }
                        }
                        //発注番号・発注行番号・請求書番号が同一か確認.
                        if (HatyuBan.Equals(ChkHatyuBan) && HatyuRowBan.Equals(ChkHatyuRowBan) && SeikyuBan.Equals(ChkSeikyuBan))
                        {
                            //請求書行番号が相違しているか確認.
                            if (!SeikyuRowBan.Equals(ChkSeikyuRowBan))
                            {

                                i = i + 1;
                                return "同じ発注番号・発注行番号に同じ請求書番号を設定した場合、請求書行番号も同じでなければいけません" + sprgyou.ToString() + "行目 と" + i + "行目";
                            }
                        }
                        //発注番号・発注行番号・請求書番号・請求書行番号が同一か確認.
                        if (HatyuBan.Equals(ChkHatyuBan) && HatyuRowBan.Equals(ChkHatyuRowBan) && SeikyuBan.Equals(ChkSeikyuBan) && SeikyuRowBan.Equals(ChkSeikyuRowBan))
                        {
                            //掲載日入力があり、掲載日が重複しているか確認.
                            if (KeisaiBi.Length > 0 && KeisaiBi.Equals(ChkKeisaiBi))
                            {
                                i = i + 1;
                                return "同じ発注番号・発注行番号・請求書番号・請求書行番号を設定した掲載日が重複して設定されています" + sprgyou.ToString() + "行目 と" + i + "行目";
                            }
                        }
                    }
                }

                //*****************************************
                //金額の整合性チェック.
                //*****************************************

                //請求金額.
                double SeikyuKingaku = 0;
                if (KKHUtility.IsNumeric(_spdMeiNyuryokAcom_Sheet1.Cells[sprRow, COLIDX_MLIST_KINGAKU].Text))
                {
                    SeikyuKingaku = Math.Truncate(double.Parse(_spdMeiNyuryokAcom_Sheet1.Cells[sprRow, COLIDX_MLIST_KINGAKU].Text));
                }

                //値引額.
                double Nebikigaku = 0;
                if (KKHUtility.IsNumeric(_spdMeiNyuryokAcom_Sheet1.Cells[sprRow, COLIDX_MLIST_NEBIKI_GAKU].Text))
                {
                    Nebikigaku = Math.Truncate(double.Parse(_spdMeiNyuryokAcom_Sheet1.Cells[sprRow, COLIDX_MLIST_NEBIKI_GAKU].Text));
                }

                //取料金.
                double ToriRyokin = 0;
                if (KKHUtility.IsNumeric(_spdMeiNyuryokAcom_Sheet1.Cells[sprRow, COLIDX_MLIST_TORIRYOKIN].Text))
                {
                    ToriRyokin = Math.Truncate(double.Parse(_spdMeiNyuryokAcom_Sheet1.Cells[sprRow, COLIDX_MLIST_TORIRYOKIN].Text));
                }

                //金額整合性チェック１.
                if (SeikyuKingaku > 0 && ToriRyokin == 0)
                {
                    return "取料金が未入力のデータが存在します";
                }
                //金額の整合性チェック２.
                double keisan = SeikyuKingaku + Nebikigaku;
                if (ToriRyokin != keisan)
                {
                    return "取料金＝請求額＋値引額になっていないデータが存在します";
                }

                //*****************************************
                //期間入力チェック.
                //*****************************************

                //期間.
                string kikan = _spdMeiNyuryokAcom_Sheet1.Cells[sprRow, COLIDX_MLIST_KIKAN].Text;
                if (kikan.IndexOf("*") != -1)
                {
                    //return "[" + sprgyou.ToString() + "行目] 「期間」に * 入力あり";
                    if (hatyuerrorcnt < 5)
                    {
                        hatyucomment = hatyucomment + "\n[" + sprgyou.ToString() + "行目] ｢期間｣に'*'入力あり";
                    }

                    hatyuerrorcnt++;
                }

                sprgyou++;
            }

            //if (!string.IsNullOrEmpty(hatyucomment))
            //{
            //    if (hatyuerrorcnt >= 5)
            //    {
            //        hatyucomment = hatyucomment + "\r\n ・・・他多数あり";
            //    }
            //    hatyucomment = hatyucomment + "\r\n 登録を続行しますか?";
            //    DialogResult hatyudialog = MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { hatyucomment }, "明細登録", MessageBoxButtons.YesNo);
            //    if (hatyudialog == DialogResult.No)
            //    {
            //        return TOUROKUEND;
            //    }
            //}
            
            //*********************************************************************
            //同じ発注番号・発注行番号のデータが5つ以上ある場合はエラー.
            //*********************************************************************
            string kazuCheck = HatyuSuCheck();
            if (!string.IsNullOrEmpty(kazuCheck))
            {
                return kazuCheck;
            }

            //*********************************************************************
            //1発注番号に対する発注行番号が一覧に全て設定されているかを比較する.
            //*********************************************************************

            //メッセージボックスの表示の形式.
            bool YesOrNoFlg = false;
            string itiiCheck = HatyuBanOnlyCheck(out YesOrNoFlg);
            if (!string.IsNullOrEmpty(itiiCheck))
            {
                if (!YesOrNoFlg)
                {
                    return itiiCheck;
                }
                else
                {
                    DialogResult dialogcheck = MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { itiiCheck }, "明細登録", MessageBoxButtons.YesNo);
                    if (dialogcheck == DialogResult.No)
                    {
                        return TOUROKUEND;
                    }
                }
            }

            //*********************************************************************
            //発注データの掲載回数が一覧の掲載日の数と一致するか確認する.
            //*********************************************************************

            //新聞または雑誌の場合のみ実行.
            if (_mGyomKbn.Equals(C_GYOM_SHINBUN) || _mGyomKbn.Equals(C_GYOM_ZASHI))
            {
                string keisaikaisuChek = KeisaiKaisuCheck();
                if (!string.IsNullOrEmpty(keisaikaisuChek))
                {
                    return keisaikaisuChek;
                }
            }

            //*********************************************************************
            //スプレッドとテーブルの比較方法を変更する.
            //*********************************************************************
            string tblhikaku = ComparisonSprToTbl();
            if (!string.IsNullOrEmpty(tblhikaku))
            {
                return tblhikaku;
            }

            if (!string.IsNullOrEmpty(hatyucomment))
            {
                hatyucomment = "登録内容に警告が発生しています\n" + hatyucomment + "\n";
                if (hatyuerrorcnt > 5)
                {
                    hatyucomment = hatyucomment + "・・・他多数あり\n\n";
                }
                else
                {
                    hatyucomment = hatyucomment + "\n\n";
                }
                hatyucomment = hatyucomment + "登録を続行しますか？";
                DialogResult hatyudialog = MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { hatyucomment }, "明細登録", MessageBoxButtons.YesNo);
                if (hatyudialog == DialogResult.No)
                {
                    return TOUROKUEND;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 発注番号取得のチェック(新聞)
        /// </summary>
        /// <param name="rownum"></param>
        /// <param name="irrowban"></param>
        /// <param name="errorflg"></param>
        /// <param name="gaitouindex"></param>
        /// <returns></returns>
        private string shinBunCheck(int rownum, string irrowban,out bool errorflg,out int gaitouindex)
        {
            //エラーメッセージ用.
            string errormsg = string.Empty;
            //ヒット数.
            int hit = 0;
            errorflg = false;
            gaitouindex = 0;
            if (!string.IsNullOrEmpty(irrowban))
            {
                errormsg = " 発注行番号：" + irrowban;
                foreach (Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow row in (Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow[])TB5hiktable.Select("", ""))
                {
                    //メディアコードと行番号が一致するか確認.
                    if (row.MediaCd.Equals(_spdMeiNyuryokAcom_Sheet1.Cells[rownum,COLIDX_MLIST_MEDIA_CD].Text.ToString().Substring(0,6)) && row.IrRowBan.Equals(irrowban))
                    {
                        hit++;
                    }
                }
            }
            else
            {
                //掲載日.
                string keisaibi = _spdMeiNyuryokAcom_Sheet1.Cells[rownum, COLIDX_MLIST_HATSUORKEISAI].Text.ToString();

                //掲載日が8桁か確認.
                if (keisaibi.Length != 8)
                {
                    rownum = rownum + 1;
                    errormsg = errormsg + "[" + rownum + "行目] 掲載日は８桁でセットしてください";
                    errorflg = true;
                    return errormsg;
                }

                //掲載日が数値かどうかの確認.
                if (!KKHUtility.IsNumeric(keisaibi))
                {
                    rownum = rownum + 1;
                    errormsg = errormsg + "[" + rownum + "行目] 掲載日は数字８桁でセットしてください";
                    errorflg = true;
                    return errormsg;
                }

                errormsg = errormsg + "掲載日：" + keisaibi;
                int gaitoucheck = 0;
                 foreach (Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow keisairow in (Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow[])TB5hiktable.Select("", ""))
                {
                    if (keisairow.MediaCd.Trim().Equals(_spdMeiNyuryokAcom_Sheet1.Cells[rownum, COLIDX_MLIST_MEDIA_CD].Text.ToString().Substring(0, 6))&&
                        keisairow.IrYymm.Trim().Equals(keisaibi.Substring(0,6)) &&
                        keisairow.Keisai.Trim().Substring(int.Parse(keisaibi.Substring(6, 2)) - 1, 1).Equals("1"))
                    {
                        hit++;
                        gaitouindex = gaitoucheck;
                    }
                    gaitoucheck++;
                }
            }

            switch (hit)
            {
                case 0:
                    errorflg = true;
//                  return "発注データが存在しません。";
                    return "[" + ( rownum + 1 ) + "行目] メディアコード：" +
                            _spdMeiNyuryokAcom_Sheet1.Cells[rownum, COLIDX_MLIST_MEDIA_CD].Value + errormsg +
                            "の発注データが存在しません。発注データを取得できませんでした。";
                case 1:
                    errorflg = false;
                    return errormsg;
                default:
                    errorflg = true;
//                  return "発注データが2件以上あります。";
                    return "[" + ( rownum + 1 ) + "行目] メディアコード：" +
                            _spdMeiNyuryokAcom_Sheet1.Cells[rownum, COLIDX_MLIST_MEDIA_CD].Value + errormsg +
                            "の発注データが複数存在します。発注データを取得できませんでした。";
            }
        }

        /// <summary>
        /// 発注番号取得のチェック(雑誌)
        /// </summary>
        /// <param name="rownum"></param>
        /// <param name="irrowban"></param>
        /// <param name="errorflg"></param>
        /// <param name="gaitouindex"></param>
        /// <returns></returns>
        private string zashiCheck(int rownum, string irrowban, out bool errorflg, out int gaitouindex)
        {
            //エラーメッセージ用.
            string errormsg = string.Empty;
            //ヒット数.
            int hit = 0;
            errorflg = false;
            gaitouindex = 0;
            if (!string.IsNullOrEmpty(irrowban))
            {
                errormsg = " 発注行番号：" + irrowban;
                foreach (Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow row in (Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow[])TB5hiktable.Select("", ""))
                {
                    //メディアコードと行番号が一致するか確認.
                    if (row.MediaCd.Equals(_spdMeiNyuryokAcom_Sheet1.Cells[rownum, COLIDX_MLIST_MEDIA_CD].Text.ToString().Substring(0, 6)) && row.IrRowBan.Equals(irrowban))
                    {
                        hit++;
                    }
                }
            }
            else
            {
                //発売日.
                string hatubaibi = _spdMeiNyuryokAcom_Sheet1.Cells[rownum, COLIDX_MLIST_HATSUORKEISAI].Text.ToString();

                //発売日が8桁か確認.
                if (hatubaibi.Length != 8)
                {
                    rownum = rownum + 1;
                    errormsg = errormsg + "[" + rownum + "行目] 発売日は８桁でセットしてください";
                    errorflg = true;
                    return errormsg;
                }
                //発売日が数値かどうかの確認.
                if (!KKHUtility.IsNumeric(hatubaibi))
                {
                    rownum = rownum + 1;
                    errormsg = errormsg + "[" + rownum + "行目] 発売日は数字８桁でセットしてください";
                    errorflg = true;
                    return errormsg;
                }

                errormsg = errormsg + "発売日：" + hatubaibi;
                int gaitoucheck = 0;
                foreach (Common.KKHSchema.Detail.THB5HIKRow hatubairow in (Common.KKHSchema.Detail.THB5HIKRow[])TB5hiktable.Select("", ""))
                {
                    if
                    (
                        (
                            hatubairow.MediaCd.Trim().Equals(_spdMeiNyuryokAcom_Sheet1.Cells[rownum, COLIDX_MLIST_MEDIA_CD].Text.Substring(0, 6))
                        ) &&
                        (
                            hatubairow.Keisai1.Trim().Equals(hatubaibi) ||
                            hatubairow.Keisai2.Trim().Equals(hatubaibi) ||
                            hatubairow.Keisai3.Trim().Equals(hatubaibi) ||
                            hatubairow.Keisai4.Trim().Equals(hatubaibi) ||
                            hatubairow.Keisai5.Trim().Equals(hatubaibi)
                        )
                    )
                    {
                        hit++;
                        gaitouindex = gaitoucheck;
                    }
                    gaitoucheck++;
                }

            }
            string Media = _spdMeiNyuryokAcom_Sheet1.Cells[rownum, COLIDX_MLIST_MEDIA_CD].Text.Substring(0, 6);
            switch (hit)
            {
                case 0:
                    errorflg = true;
//                  int calc = rownum + 1;
//                  return "[" + calc.ToString() + "行目] メディアコード：" + Media + " " + errormsg + "の発注データが存在しません。発注データを取得できませんでした。";
                    return "[" + ( rownum + 1 ) + "行目] メディアコード：" +
                            _spdMeiNyuryokAcom_Sheet1.Cells[rownum, COLIDX_MLIST_MEDIA_CD].Value + errormsg +
                            "の発注データが存在しません。発注データを取得できませんでした。";
                case 1:
                    errorflg = false;
                    return errormsg;
                default:
                    errorflg = true;
//                  return "発注データが存在しません。";
                    return "[" + ( rownum + 1 ) + "行目] メディアコード：" +
                            _spdMeiNyuryokAcom_Sheet1.Cells[rownum, COLIDX_MLIST_MEDIA_CD].Value + errormsg +
                            "の発注データが複数存在します。発注データを取得できませんでした。";
            }
        }

        /// <summary>
        /// 発注番号取得のチェック(その他)
        /// </summary>
        /// <param name="rownum"></param>
        /// <param name="irrowban"></param>
        /// <param name="errorflg"></param>
        /// <param name="gaitouindex"></param>
        /// <returns></returns>
        private string sonotaCheck(int rownum, string irrowban, out bool errorflg, out int gaitouindex)
        {
            //エラーメッセージ用.
            string errormsg = string.Empty;
            //ヒット数.
            int hit = 0;
            errorflg = false;
            gaitouindex = 0;
            if (!string.IsNullOrEmpty(irrowban))
            {
                errormsg = " 発注行番号：" + irrowban;
                foreach (Common.KKHSchema.Detail.THB5HIKRow row in (Common.KKHSchema.Detail.THB5HIKRow[])TB5hiktable.Select("", ""))
                {
                    //メディアコードと行番号が一致するか確認.
                    if (row.MediaCd.Equals(_spdMeiNyuryokAcom_Sheet1.Cells[rownum, COLIDX_MLIST_MEDIA_CD].Text.ToString().Substring(0, 6)) && row.IrRowBan.Equals(irrowban))
                    {
                        hit++;
                    }
                }
            }
            else
            {
                int gaitoucheck = 0;
                foreach (Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow sonotarow in (Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow[])TB5hiktable.Select("", ""))
                {
                    if (sonotarow.MediaCd.Equals(_spdMeiNyuryokAcom_Sheet1.Cells[rownum, COLIDX_MLIST_MEDIA_CD].Text.ToString().Substring(0, 6)))
                    {
                        hit++;
                        gaitouindex = gaitoucheck;
                    }
                    gaitoucheck++;
                }
            }

            switch (hit)
            {
                case 0:
                    errorflg = true;
//                  return "[" + rownum + "行目] メディアコード：" + _spdMeiNyuryokAcom_Sheet1.Cells[rownum, COLIDX_MLIST_MEDIA_CD].Text + "の発注データが存在しません。発注データを取得できませんでした。";
                    return "[" + ( rownum + 1 ) + "行目] メディアコード：" +
                            _spdMeiNyuryokAcom_Sheet1.Cells[rownum, COLIDX_MLIST_MEDIA_CD].Value + errormsg +
                            "の発注データが存在しません。発注データを取得できませんでした。";
                case 1:
                    errorflg = false;
                    return errormsg;
                default:
                    errorflg = true;
//                  return "[" + rownum + "行目] メディアコード：" + _spdMeiNyuryokAcom_Sheet1.Cells[rownum, COLIDX_MLIST_MEDIA_CD].Text + "の発注データが複数存在します";
                    return "[" + ( rownum + 1 ) + "行目] メディアコード：" +
                            _spdMeiNyuryokAcom_Sheet1.Cells[rownum, COLIDX_MLIST_MEDIA_CD].Value + errormsg +
                            "の発注データが複数存在します。発注データを取得できませんでした。";
            }
        }

        /// <summary>
        /// 商品名称取得.
        /// </summary>
        /// <param name="kbn"></param>
        /// <returns></returns>
        private string syohinName(string kbn)
        {
            DetailAcomProcessController detailprocesscontroller = DetailAcomProcessController.GetInstance();
            DetailAcomProcessController.FindDetailDataByCondParam param = new DetailAcomProcessController.FindDetailDataByCondParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.SyouhinKbn = kbn;

            return  detailprocesscontroller.SyouhinName(param);
        }

        /// <summary>
        /// 発注番号、発注行番号の数チェック.
        /// </summary>
        /// <returns></returns>
        private string HatyuSuCheck()
        {
            for (int i = 0; i < _spdMeiNyuryokAcom_Sheet1.Rows.Count; i++)
            {
                //重複データカウント.
                int DataCount = 0;
                //発注番号.
                string HatyuBan = _spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_HACHU_NO].Text;
                //発注行番号.
                string HatyuRowBan = _spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_HACHUGYO_NO].Text;
                //媒体コード.
                string BaitaiCd = _spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_BAITAI_CD].Text;
                //メディアコード.
                string MedaiCd = _spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_MEDIA_CD].Text.ToString().Substring(0, 6);

                //電波以外は対象外.
                if (!BaitaiCd.Equals("11"))
                {
                    return string.Empty;    //正常終了.
                }

                for (int j = 0; j < _spdMeiNyuryokAcom_Sheet1.Rows.Count; j++)
                {
                    //発注番号.
                    string ChkHatyuBan = _spdMeiNyuryokAcom_Sheet1.Cells[j, COLIDX_MLIST_HACHU_NO].Text;
                    //発注行番号.
                    string ChkHatyuRowBan = _spdMeiNyuryokAcom_Sheet1.Cells[j, COLIDX_MLIST_HACHUGYO_NO].Text;
                    //媒体コード.
                    string ChkBaitaiCd = _spdMeiNyuryokAcom_Sheet1.Cells[j, COLIDX_MLIST_BAITAI_CD].Text;
                    //メディアコード.
                    string ChkMedaiCd = _spdMeiNyuryokAcom_Sheet1.Cells[j, COLIDX_MLIST_MEDIA_CD].Text.ToString().Substring(0, 6);

                    if (HatyuBan.Equals(ChkHatyuBan) && HatyuRowBan.Equals(ChkHatyuRowBan) && BaitaiCd.Equals(ChkBaitaiCd) && MedaiCd.Equals(ChkMedaiCd))
                    {
                        DataCount++;
                        if (DataCount > 4)
                        {
                            return "同じ発注番号と発注行番号で5つ以上登録されているメディアコードがあります。4つ以内で登録して下さい。\r\n メディアコード：" + _spdMeiNyuryokAcom_Sheet1.Cells[j, COLIDX_MLIST_MEDIA_CD].Text;
                        }
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 発注番号の一意チェック.
        /// </summary>
        /// <param name="YesOrNoFlg"></param>
        /// <returns></returns>
        private string HatyuBanOnlyCheck(out bool YesOrNoFlg)
        {
            //発注番号.
            string ChkHatyuBan = string.Empty;
            YesOrNoFlg = false;
            for (int i = 0; i < _spdMeiNyuryokAcom_Sheet1.Rows.Count; i++)
            {
                //チェック用発注番号を保持していないか確認.
                if (string.IsNullOrEmpty(ChkHatyuBan))
                {
                    //チェック用発注番号を保持.
                    ChkHatyuBan = _spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_HACHU_NO].Text;
                }
                else
                {
                    //異なる発注番号を取得した場合.
                    if (!ChkHatyuBan.Equals(_spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_HACHU_NO].Text))
                    {
                        YesOrNoFlg = false;
                        return "発注番号は一意でなければいけません";
                    }
                }
            }

            //発注番号が一つも設定されていないか確認.
            if (string.IsNullOrEmpty(ChkHatyuBan))
            {
                return string.Empty;
            }
            DetailAcomProcessController detailprocesscontroller = DetailAcomProcessController.GetInstance();
            DetailAcomProcessController.FindDetailDataByCondParam param = new DetailAcomProcessController.FindDetailDataByCondParam();

            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.IrBan = ChkHatyuBan;
            Acom.ProcessController.Detail.FindDetailDataByCondServiceResult result = detailprocesscontroller.FindHatyuConfirm(param);
            if (result.HasError)
            {
                return "発注番号検索エラー";
            }

            Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow[] thb5HikRow = (Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow[])result.DetailDataSet.THB5HIK.Select("", "");

            //該当するものを削除.
            for (int j = 0; j < _spdMeiNyuryokAcom_Sheet1.Rows.Count; j++)
            {
                foreach (Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow row in (Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow[])result.DetailDataSet.THB5HIK.Select("", ""))
                {
                    if (_spdMeiNyuryokAcom_Sheet1.Cells[j, COLIDX_MLIST_HACHUGYO_NO].Text.Equals(row.IrRowBan.Trim()))
                    {
                        result.DetailDataSet.THB5HIK.RemoveTHB5HIKRow(row);
                        break;
                    }
                }
            }

            //全て記載済み.
            if (result.DetailDataSet.THB5HIK.Count == 0)
            {
                return string.Empty;
            }


            List<string> disList = new List<string>();

            //登録されていない内容が10個以上の場合.
            if (result.DetailDataSet.THB5HIK.Count > 10)
            {
                //登録されていない内容を表示.
                foreach (Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow disrow in (Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow[])result.DetailDataSet.THB5HIK.Select("", ""))
                {
                    disList.Add("メディア名[" + disrow.MediaName + "] 行番号[" + disrow.IrRowBan + "]");
                    if (disList.Count == 10)
                    {
                        disList.Add("…他多数あり");
                        break;
                    }
                }
            }
            //登録されていない内容が10個以下かつ0以上の場合.
            else if (result.DetailDataSet.THB5HIK.Count < 10 && result.DetailDataSet.THB5HIK.Count > 0)
            {
                foreach (Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow disrow in (Isid.KKH.Common.KKHSchema.Detail.THB5HIKRow[])result.DetailDataSet.THB5HIK.Select("", ""))
                {
                    disList.Add("メディア名[" + disrow.MediaName + "] 行番号[" + disrow.IrRowBan + "]");
                }
            }

            //コメント表示用.
            string comment = "同一発注番号の発注データのうち、下記が一覧にセットされていません。\n";
            foreach (string come in disList)
            {
                comment = comment + "\n" + come;
            }

            comment = comment + "\n\n登録を続行しますか？";

            YesOrNoFlg = true;
            return comment;
        }

        /// <summary>
        /// 掲載回数チェック.
        /// </summary>
        /// <returns></returns>
        private string KeisaiKaisuCheck()
        {
            //コメント.
            string comment = string.Empty;
            //発注番号.
            string hatyuBan = "";

            if (_spdMeiNyuryokAcom_Sheet1.RowCount > 0)
            {
                hatyuBan = _spdMeiNyuryokAcom_Sheet1.Cells[0, COLIDX_MLIST_HACHU_NO].Text;
            }
            //string hatyuBan = _spdMeiNyuryokAcom_Sheet1.Cells[0, COLIDX_MLIST_HACHU_NO].Text;

            //発売日Or掲載日Nullチェック ※値引行の時はチェックを迂回.
            for (int i = 0; i < _spdMeiNyuryokAcom_Sheet1.Rows.Count; i++)
            {
                if ((_spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_NEBIKI_GYO_KBN].Text.Equals("0")) &&
                   (string.IsNullOrEmpty(_spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_HATSUORKEISAI].Text)))

                {
                    int gyo = 0;
                    gyo = i + 1;
                    comment = comment + " " + gyo + "行目";
                }
            }
            if (!string.IsNullOrEmpty(comment))
            {
                comment = comment + " は「発売日or掲載日」が未入力です。処理を続行しますか？";
                DialogResult dialogcheck = MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { comment }, "明細登録", MessageBoxButtons.YesNo);
                if (dialogcheck == DialogResult.No)
                {
                    return TOUROKUEND;
                }
            }

            if (string.IsNullOrEmpty(hatyuBan))
            {
                return string.Empty; ;
            }

            DetailAcomProcessController detailprocesscontroller = DetailAcomProcessController.GetInstance();
            FindHatyuNumServiceResult result = detailprocesscontroller.FindHatyuNum(_naviParam.strEsqId,
                                                                                    "00",
                                                                                    _naviParam.strEgcd,
                                                                                    _naviParam.strTksKgyCd,
                                                                                    _naviParam.strTksBmnSeqNo,
                                                                                    _naviParam.strTksTntSeqNo,
                                                                                    hatyuBan,
                                                                                    string.Empty
                                                                                    );
            //エラーの場合.
            if (result.HasError)
            {
                return result.MessageCode;
            }

            Common.KKHSchema.Detail.THB5HIKRow[] thb5HikRow = (Common.KKHSchema.Detail.THB5HIKRow[])result.DetailDataSet.THB5HIK.Select("", "");

            //掲載回数カウント.
            long keisaiCnt = 0;
            String KeisaiCntRow = "";
            String keisaiCntSt = "";

            //コメント.
            string comment2 = string.Empty;
            int cnt = 0;

            //掲載回数チェック.
            foreach (Common.KKHSchema.Detail.THB5HIKRow row in thb5HikRow)
            {
                keisaiCnt = 0;
                for (int j = 0; j < _spdMeiNyuryokAcom_Sheet1.Rows.Count; j++)
                {
                    if (_spdMeiNyuryokAcom_Sheet1.Cells[j, COLIDX_MLIST_HACHUGYO_NO].Text.Equals(row.IrRowBan.Trim()))
                    {
                        keisaiCnt = keisaiCnt + 1;
                    }
                }
                if (row.KeisaiCnt.Trim().Length == 1)
                {
                    KeisaiCntRow = "0" + row.KeisaiCnt.Trim();
                }
                else
                {
                    KeisaiCntRow = row.KeisaiCnt.Trim();
                }
                if (keisaiCnt.ToString().Length == 1)
                {
                    keisaiCntSt = "0" + keisaiCnt.ToString();
                }
                else
                {
                    keisaiCntSt = keisaiCnt.ToString();
                }
                if (!KeisaiCntRow.Equals(keisaiCntSt) && keisaiCnt > 0)
                {
                    comment2 = comment2 + "\r\n" + "メディア名[" + row.MediaName.Trim() + "] 発注行番号[" + row.IrRowBan.Trim() + "] \r\n 一覧:" + keisaiCntSt + "回 発注データ:" + KeisaiCntRow + "回  ";
                    cnt++;
                    if (cnt == 10)
                    {
                        comment2 = comment2 + "\r\n ・・・他多数あり";
                        break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(comment2))
            {
                comment2 = "下記は一覧と発注データで掲載回数が不一致です \r\n " + comment2;
                comment2 = comment2 + "\r\n 登録を続行しますか?";
                DialogResult dialogcheck2 = MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { comment2 }, "明細登録", MessageBoxButtons.YesNo);
                if (dialogcheck2 == DialogResult.No)
                {
                    return TOUROKUEND;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// スプレッドとテーブルの比較.
        /// </summary>
        /// <returns></returns>
        private string ComparisonSprToTbl()
        {
            //受注データRow
            Common.KKHSchema.Detail.JyutyuDataRow DowndataRow = _naviParam.DataRow;

            //明細データの取得.
            DetailAcomProcessController detailprocesscontroller = DetailAcomProcessController.GetInstance();
            DetailAcomProcessController.FindDetailDataByCondParam param = new DetailAcomProcessController.FindDetailDataByCondParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = _naviParam.StrYymm;
            param.jyutNo = string.Empty;
            param.jyMeiNo = string.Empty;
            param.urMeiNo = string.Empty;
            Acom.ProcessController.Detail.FindDetailDataByCondServiceResult result = detailprocesscontroller.FindMeisaiDataByCond(param);
            if (result.HasError)
            {
                return "検索エラー";
            }
            if (result.DetailDataSet.THB2KMEI.Rows.Count == 0)
            {
                return string.Empty;
            }

            Common.KKHSchema.Detail.THB2KMEIRow[] thb2kmei = (Common.KKHSchema.Detail.THB2KMEIRow[])result.DetailDataSet.THB2KMEI.Select("","");

            //キープNo
            string keepNo = string.Empty;
            //キープ行No
            string keepRowNo = string.Empty;
            //キープ　発注番号、発注行番号、請求書番号.
            string Keephatandsei = string.Empty;
            //キープ　発注番号、発注行番号、請求書番号,請求書行番号.
            string Keephatseiall = string.Empty;

            for (int i = 0; i < _spdMeiNyuryokAcom_Sheet1.Rows.Count; i++)
            {
                //発注番号.
                string hatyuBan = _spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_HACHU_NO].Text;
                //発注行番号.
                string hatyuRowBan = _spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_HACHUGYO_NO].Text;
                //請求書番号.
                string SeikyuBan = _spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSHO_NO].Text;
                //請求書行番号.
                string SeikyuRowBan = _spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSHOGYO_NO].Text;
                //掲載日.
                string Keisaibi = _spdMeiNyuryokAcom_Sheet1.Cells[i, COLIDX_MLIST_HATSUORKEISAI].Text;

                //請求書番号または請求書行番号いずれかがあるか確認.
                if (!string.IsNullOrEmpty(SeikyuBan) || !string.IsNullOrEmpty(SeikyuRowBan))
                {
                    foreach (Common.KKHSchema.Detail.THB2KMEIRow meirow in thb2kmei)
                    {
                        if (!hatyuBan.Equals(meirow.hb2Code3.Trim()) && SeikyuBan.Equals(meirow.hb2Sonota1))
                        {
                            if (!meirow.hb2JyutNo.Trim().Equals(DowndataRow.hb1JyutNo.Trim()) || !meirow.hb2JyMeiNo.Trim().Equals(DowndataRow.hb1JyMeiNo.Trim())
                                || !meirow.hb2UrMeiNo.Trim().Equals(DowndataRow.hb1UrMeiNo.Trim()))
                            {
                                if (keepNo.IndexOf(meirow.hb2Code3.Trim()) == -1)
                                {
                                    string comment = "異なる発注番号に同じ請求書番号が採番済みです。\r\n 請求書番号[" + SeikyuBan + "] \r\n 登録済み発注番号[" + meirow.hb2Code3.Trim() + "] \r\n 今回設定した発注番号[" + hatyuBan + "] \r\n 登録を実行しますか？";
                                    DialogResult dialogcheck = MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { comment }, "明細登録", MessageBoxButtons.YesNo);
                                    if (dialogcheck == DialogResult.No)
                                    {
                                        return TOUROKUEND;
                                    }
                                    else
                                    {
                                        keepNo = keepNo + "," + meirow.hb2Code3.Trim();
                                    }
                                }
                            }
                        }
                        //発注番号・発注行番号がテーブルとスプレッドで相違するか確認.
                        if (!meirow.hb2Code3.Trim().Equals(hatyuBan) || !meirow.hb2Code4.Trim().Equals(hatyuRowBan))
                        {
                            if(meirow.hb2Sonota1.Trim().Equals(SeikyuBan) && meirow.hb2Sonota2.Trim().Equals(SeikyuRowBan))
                            {
                                if (!meirow.hb2JyutNo.Trim().Equals(DowndataRow.hb1JyutNo.Trim()) || !meirow.hb2JyMeiNo.Trim().Equals(DowndataRow.hb1JyMeiNo.Trim())
                                    || !meirow.hb2UrMeiNo.Trim().Equals(DowndataRow.hb1UrMeiNo.Trim()))
                                {
                                    if (keepRowNo.IndexOf(meirow.hb2Code3.Trim() + meirow.hb2Code4.Trim()) == -1)
                                    {
                                        string commnt2 = "異なる発注番号・発注行番号に同じ請求書番号・請求書行番号が採番済みです。\r\n " +
                                                          "請求書番号[" + SeikyuBan + "]・請求書行番号[" + SeikyuRowBan + "] \r\n " +
                                                          "登録済み発注番号[" + meirow.hb2Code3.Trim() + "]・発注行番号[" + meirow.hb2Code4.Trim() + "] \r\n " +
                                                          "今回設定した発注番号[" + hatyuBan + "]・発注行番号[" + hatyuRowBan + "] \r\n " +
                                                          "登録を続行しますか？";
                                        DialogResult dialogcheck2 = MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { commnt2 }, "明細登録", MessageBoxButtons.YesNo);
                                        if (dialogcheck2 == DialogResult.No)
                                        {
                                            return TOUROKUEND;
                                        }
                                        else
                                        {
                                            keepRowNo = keepRowNo + "," + meirow.hb2Code3.Trim() + meirow.hb2Code4.Trim();
                                        }
                                    }
                                }
                            }
                        }
                        //請求書行番号がテーブルとスプレッドで相違するか確認.
                        if (!meirow.hb2Sonota2.Trim().Equals(SeikyuRowBan))
                        {
                            if (meirow.hb2Code3.Trim().Equals(hatyuBan) && meirow.hb2Code4.Trim().Equals(hatyuRowBan) && meirow.hb2Sonota1.Trim().Equals(SeikyuBan))
                            {
                                if (!meirow.hb2JyutNo.Trim().Equals(DowndataRow.hb1JyutNo.Trim()) || !meirow.hb2JyMeiNo.Trim().Equals(DowndataRow.hb1JyMeiNo.Trim())
                                    || !meirow.hb2UrMeiNo.Trim().Equals(DowndataRow.hb1UrMeiNo.Trim()))
                                {
                                    if (Keephatandsei.IndexOf(meirow.hb2Code3.Trim() + meirow.hb2Code4.Trim() + SeikyuBan) == -1)
                                    {
                                        string commnet3 = "同じ発注番号・発注行番号・請求書番号に対する、異なる請求書行番号が採番済みです。\r\n " +
                                                          "発注番号[" + hatyuBan + "]・発注行番号[" + hatyuRowBan + "]・請求書番号[" + SeikyuBan + "] \r\n " +
                                                          "登録済み請求書行番号[" + meirow.hb2Sonota2.Trim() + "] \r\n " +
                                                          "今回設定した請求書行番号[" + SeikyuRowBan + "] \r\n " +
                                                          "登録を続行しますか？";
                                        DialogResult dialogcheck3 = MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { commnet3 }, "明細登録", MessageBoxButtons.YesNo);
                                        if (dialogcheck3 == DialogResult.No)
                                        {
                                            return TOUROKUEND;
                                        }
                                        else
                                        {
                                            Keephatandsei = Keephatandsei + "," + meirow.hb2Code3.Trim() + meirow.hb2Code4.Trim() + SeikyuBan;
                                        }
                                    }
                                }
                            }
                        }

                        //掲載日入力があるか確認.
                        if (!string.IsNullOrEmpty(Keisaibi))
                        {
                            if (meirow.hb2Sonota9.Trim().Equals(Keisaibi))
                            {
                                if (meirow.hb2Sonota2.Trim().Equals(SeikyuRowBan) && meirow.hb2Code3.Trim().Equals(hatyuBan) && meirow.hb2Code4.Trim().Equals(hatyuRowBan)
                                    && meirow.hb2Sonota1.Trim().Equals(SeikyuBan))
                                {
                                    if (!meirow.hb2JyutNo.Trim().Equals(DowndataRow.hb1JyutNo.Trim()) || !meirow.hb2JyMeiNo.Trim().Equals(DowndataRow.hb1JyMeiNo.Trim())
                                        || !meirow.hb2UrMeiNo.Trim().Equals(DowndataRow.hb1UrMeiNo.Trim()))
                                    {
                                        if (Keephatseiall.IndexOf(meirow.hb2Code3.Trim() + meirow.hb2Code4.Trim() + SeikyuBan + meirow.hb2Sonota2.Trim()) == -1)
                                        {
                                            string commnet4 = "同じ発注番号・発注行番号・請求書番号・請求書行番号に対する、同一掲載日が登録済みです。 \r\n " +
                                                              "発注番号[" + hatyuBan + "]・発注行番号[" + hatyuRowBan + "]・請求書番号[" + SeikyuBan + "]・請求書行番号[" + SeikyuRowBan + "] \r\n " +
                                                              "登録済み掲載日[" + meirow.hb2Sonota9.Trim() + "] \r\n " +
                                                              "今回設定した掲載日[" + Keisaibi + "] \r\n " +
                                                              "登録を続行しますか？";
                                            DialogResult dialogcheck4 = MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { commnet4 }, "明細登録", MessageBoxButtons.YesNo);
                                            if (dialogcheck4 == DialogResult.No)
                                            {
                                                return TOUROKUEND;
                                            }
                                            else
                                            {
                                                Keephatseiall = Keephatseiall + "," + meirow.hb2Code3.Trim() + meirow.hb2Code4.Trim() + SeikyuBan + meirow.hb2Sonota9.Trim();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return string.Empty;

        }

        /// <summary>
        /// ペースト処理.
        /// </summary>
        /// <param name="spView"></param>
        /// <param name="val"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>
        /// true = 貼り付け継続.
        /// false = 貼り付け終了.
        /// </returns>
        private bool isSetContinuePast(FarPoint.Win.Spread.SpreadView spView, string val, int row, int col)
        {
            SheetView shView = spView.GetSheetView(); ;

            bool multiCopyFlg = true;
            // コピー例外発生をTry～Catchで吸収する.

            // キー=「列,行」値=「貼り付け値」.
            Dictionary<string, string> pastDic = KKHUtility.getPastValueDic(val);

            if (pastDic.Count == 1)
            {
                // 複数コピーでない場合.
                multiCopyFlg = false;
            }

            // コピー分のセル走査.
            foreach (string pastKey in pastDic.Keys)
            {
                // キー「列,行」を分割.
                string[] keySplitArr = pastKey.Split(KKHSystemConst.SPLIT_VAL.ToCharArray());

                // 列.
                int addCol = int.Parse(keySplitArr[0]);
                // 行.
                int addRow = int.Parse(keySplitArr[1]);
                try
                {
                    // ペースト対象列.
                    int colNum = col + addCol;
                    // ペースト対象行.
                    int rowNum = row + addRow;

                    // コピー可能な列か確認する.
                    if (!isCopyOKColumn(shView, colNum, rowNum))
                    {
                        continue;
                    }

                    // ペースト.
                    shView.Cells[rowNum, colNum].Text = pastDic[pastKey];

                    // コピー後のカラム変更による検証処理.
                    ChangeEventArgs changeEvent = new ChangeEventArgs(spView, rowNum, colNum);

                    // セル変更処理実行.
                    _spdMeiNyuryokAcom_Change(this._spdMeiNyuryokAcom, changeEvent);
                }
                // セルタイプの違い等でのエラー回避用.
                catch { }
            }

            return multiCopyFlg;
        }

        /// <summary>
        /// コピー可能列確認.
        /// </summary>
        /// <param name="shView"></param>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool isCopyOKColumn(SheetView shView, int col, int row)
        {
            Column actColumn = shView.Columns[col];
            if (actColumn.Locked)
            {
                // ロックされている場合.
                return false;
            }

            //非表示列へは貼り付け不可とする.
            if (actColumn.Visible.Equals(false))
            {
                return false;
            }

            if (actColumn.CellType is TextCellType ||
                actColumn.CellType is NumberCellType)
            {
                // セルタイプがテキストの場合.
                if (shView.Cells[row, col].Locked)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// 自動計算.
        /// </summary>
        /// <param name="row">行インデックス</param>
        /// <param name="colmun">列インデックス</param>
        private void CalcAuto(int row, int colmun)
        {
            switch (colmun)
            {
                case COLIDX_MLIST_NEBIKI_RITSU:     // 値引率.
                case COLIDX_MLIST_TORIRYOKIN:       // 取金額.
                    // 値引額を自動計算.
                    CalcAutoNebigak(row, colmun);

                    // 請求金額を自動計算.
                    CalcAutoKingak(row, colmun);

                    // 消費税額を自動計算.
                    CalcAutoSyohi(row, colmun);

                    //テキストボックスにデータをセット.
                    CalcDataSet();
                    break;

                case COLIDX_MLIST_SHOHIZEI_RITSU:   // 消費税率.
                case COLIDX_MLIST_KINGAKU:          // 売上額（請求金額）.
                    // 消費税額を自動計算.
                    CalcAutoSyohi(row, colmun);
                    break;

                case COLIDX_MLIST_NEBIKI_GAKU:      // 売上額.
                    // 請求金額を自動計算.
                    CalcAutoKingak(row, colmun);

                    // 消費税額を自動計算.
                    CalcAutoSyohi(row, colmun);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 値引額を自動計算.
        /// </summary>
        /// <param name="row">行インデックス</param>
        /// <param name="colmun">列インデックス</param>
        private void CalcAutoNebigak(int row, int colmun)
        {
            decimal torigak = KKHUtility.DecParse(_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_TORIRYOKIN].Text);
            decimal nebiritu = KKHUtility.DecParse(_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_NEBIKI_RITSU].Text);
            decimal nebigak = torigak * nebiritu / 100;

            if (nebigak != Math.Truncate(nebigak))
            {
                if (0 < nebigak)
                {
                    // プラスへ切り上げる.
                    nebigak += 1;
                }
                else if (nebigak < 0)
                {
                    // マイナスへ切り上げる.
                    nebigak -= 1;
                }
            }
            else
            {
                // 補正なし.
            }

            _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_NEBIKI_GAKU].Value = Math.Truncate(nebigak);
        }

        /// <summary>
        /// 請求金額を自動計算.
        /// </summary>
        /// <param name="row">行インデックス</param>
        /// <param name="colmun">列インデックス</param>
        private void CalcAutoKingak(int row, int colmun)
        {
            decimal torigak = KKHUtility.DecParse(_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_TORIRYOKIN].Text);
            decimal nebigak = KKHUtility.DecParse(_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_NEBIKI_GAKU].Text);
            decimal kingak = torigak - nebigak;

            _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KINGAKU].Value = kingak;
        }

        /// <summary>
        /// ナンバーセルタイプを新規作成.
        /// </summary>
        /// <param name="MaximumValue"></param>
        /// <returns></returns>
        private NumberCellType NewNumCelltype(double MaximumValue)
        {
            NumberCellType NumCelltype = new NumberCellType();
            NumCelltype.DecimalPlaces = 0;
            NumCelltype.ShowSeparator = true;
            NumCelltype.MaximumValue = MaximumValue;
            NumCelltype.MinimumValue = 0;

            return NumCelltype;
        }

        /// <summary>
        /// ナンバーセルタイプを新規作成.
        /// </summary>
        /// <param name="MaximumValue"></param>
        /// <param name="MinimumValue"></param>
        /// <returns></returns>
        private NumberCellType NewNumCelltype(double MaximumValue, double MinimumValue)
        {
            NumberCellType NumCelltype = new NumberCellType();
            NumCelltype.DecimalPlaces = 0;
            NumCelltype.ShowSeparator = true;
            NumCelltype.MaximumValue = MaximumValue;
            NumCelltype.MinimumValue = MinimumValue;

            return NumCelltype;
        }

        /// <summary>
        /// テキストセルタイプを新規作成.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        private TextCellType NewTxtCelltype(int length, CharacterSet charset)
        {
            TextCellType txtcelltype = new TextCellType();
            txtcelltype.MaxLength = length;
            txtcelltype.CharacterSet = charset;
            return txtcelltype;
        }

        /// <summary>
        /// テキストボックスに値をセット.
        /// </summary>
        private void CalcDataSet()
        {
            double trRyokin = 0;    //取料金.
            double nbGaku = 0;      //値引額.

            //行数分処理する.
            for (int Row = 0; Row < _spdMeiNyuryokAcom_Sheet1.RowCount; Row++)
            {
                //値引行区分を確認.
                if (_spdMeiNyuryokAcom_Sheet1.Cells[Row, COLIDX_MLIST_NEBIKI_GYO_KBN].Text.ToString() == "1")
                {
                    //取料金を値引額として加算.

                    nbGaku += KKHUtility.DouParse(_spdMeiNyuryokAcom_Sheet1.Cells[Row, COLIDX_MLIST_TORIRYOKIN].Text.ToString());
                }
                else
                {
                    //取料金を加算.
                    trRyokin += KKHUtility.DouParse(_spdMeiNyuryokAcom_Sheet1.Cells[Row, COLIDX_MLIST_TORIRYOKIN].Text.ToString());
                }
            }
            //請求金額合計を表示.
            double skGaku = trRyokin + nbGaku;
            txtSeiKinGokei.Text = skGaku.ToString("###,###,###,##0");
            //値引額合計を表示.
            txtNebikiGaku.Text = nbGaku.ToString("###,###,###,##0");
            //取料金合計を表示.
            txtToriRyokin.Text = trRyokin.ToString("###,###,###,##0");
            //請求金額が正の時.
            double szGaku = 0;

            /* 2015/01/26 アコム消費税対応 HLC fujimoto MOD start */
            //if (skGaku * Decimal.ToDouble(_taxRate / 100.0M) > 0)
            //{
            //    //消費税の端数は切り上げる.
            //    szGaku = Math.Floor(skGaku * Decimal.ToDouble(_taxRate / 100.0M) + 0.5);
            //}
            //else if (skGaku * Decimal.ToDouble(_taxRate / 100.0M) < 0)
            //{
            //    szGaku = Math.Ceiling(skGaku * Decimal.ToDouble(_taxRate / 100.0M) - 0.5);
            //}
            //else
            //{
            //    szGaku = skGaku * Decimal.ToDouble(_taxRate / 100.0M);
            //}

            szGaku = skGaku * decimal.ToDouble(_taxRate * 0.01M);

            //消費税端数処理区分により分岐.
            
            switch (_taxRounding)
            {
                case TAX_ROUND:
                    szGaku = Math.Round(szGaku, MidpointRounding.AwayFromZero);
                    break;

                case TAX_ROUNDDOWN:
                    szGaku = Math.Floor(szGaku);
                    break;

                case TAX_ROUNDUP:
                    szGaku = Math.Ceiling(szGaku);
                    break;

                default:
                    break;
            }
            /* 2015/01/26  アコム消費税対応 HLC fujimoto MOD start */

            txtShohZeigaku.Text = szGaku.ToString("###,###,###,##0");
            //ご請求額を表示.
            double gskGaku = skGaku + szGaku;
            txtSeiGak.Text = gskGaku.ToString("###,###,###,##0");
        }

        /// <summary>
        /// 消費税額を自動計算.
        /// </summary>
        /// <param name="row">行インデックス</param>
        /// <param name="colmun">列インデックス</param>
        private void CalcAutoSyohi(int row, int colmun)
        {
            decimal kingak = KKHUtility.DecParse(_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_KINGAKU].Text);
            decimal syohiritu = KKHUtility.DecParse(_spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SHOHIZEI_RITSU].Text);
            decimal syohi = kingak * (syohiritu * 0.01M);

            //if (syohi > 0)
            //{
            //    syohi = Decimal.Floor( syohi + 0.5M );
            //}
            //else if (syohi < 0)
            //{
            //    syohi = Decimal.Floor( syohi - 0.5M );
            //}

            /* 2015/01/05 アコム消費税対応 HLC fujimoto MOD start */
            //syohi = Decimal.Truncate(syohi);

            //消費税端数処理区分により分岐.
            switch (_taxRounding)
            {
                case TAX_ROUND:
                    syohi = Math.Round(syohi, MidpointRounding.AwayFromZero);
                    break;

                case TAX_ROUNDDOWN:
                    syohi = Math.Floor(syohi);
                    break;

                case TAX_ROUNDUP:
                    syohi = Math.Ceiling(syohi);
                    break;

                default:
                    break;
            }
            /* 2015/01/05 アコム消費税対応 HLC fujimoto MOD end */

            _spdMeiNyuryokAcom_Sheet1.Cells[row, COLIDX_MLIST_SHOHIZEI_GAKU].Value = syohi;
        }

        /* 2015/01/27 アコム消費税対応　HLC fujimoto ADD start */
        #region 初期表示時消費税額自動計算.
        /// <summary>
        /// 初期表示時消費税額自動計算.
        /// </summary>
        /// <param name="decInvAmount">請求金額</param>
        /// <param name="decTaxRate">消費税率</param>
        /// <returns>消費税額</returns>
        private decimal AutoCalcTaxInitialize(decimal decInvAmount, decimal decTaxRate)
        {
            //消費税額.
            decimal decTaxAmount = decInvAmount * decTaxRate * 0.01M;

            //消費税端数処理区分により分岐.
            switch (_taxRounding)
            {
                case TAX_ROUND:
                    decTaxAmount = Math.Round(decTaxAmount, MidpointRounding.AwayFromZero);
                    break;

                case TAX_ROUNDDOWN:
                    decTaxAmount = Math.Floor(decTaxAmount);
                    break;

                case TAX_ROUNDUP:
                    decTaxAmount = Math.Ceiling(decTaxAmount);
                    break;

                default:
                    break;
            }

            return decTaxAmount;
        }
        #endregion 初期表示時消費税額自動計算.
        /* 2015/01/27 アコム消費税対応　HLC fujimoto ADD end */

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
                (!checkSNBN(gyomKbn)) && (!checkZASI(gyomKbn)) && (!checkDENP(gyomKbn))
            );
        }

        /// <summary>
        /// 行が選択されているかを返す.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private Boolean IsSelectedRow(int index, FarPoint.Win.Spread.SheetView sheet)
        {
            Boolean retval = false;

            foreach (CellRange range in sheet.GetSelections())
            {
                // ヘッダが選択されている場合は全行を選択と判定する.

                if ((range.Row != -1) && (range.RowCount != -1))
                {
                    // 選択範囲に行が該当しない場合は次の選択範囲へ.
                    if ((index < range.Row) || (index >= (range.Row + range.RowCount)))
                    {
                        continue;
                    }
                }

                retval = true;
                break;
            }

            return retval;
        }

        /// <summary>
        /// 入力制御を有効にする.
        /// </summary>
        /// <param name="index"></param>
        private void InputControlOn(int index)
        {
            if (IsInputControlNumberOnly(index))
            {
                _spdMeiNyuryokAcom.EditingControl.KeyPress += new KeyPressEventHandler(KkhInputControlAcom.KeyPress_InputControlNumberOnly);
            }
            else if (IsInputControlAlphaAndNumberOnly(index))
            {
                _spdMeiNyuryokAcom.EditingControl.KeyPress += new KeyPressEventHandler(KkhInputControlAcom.KeyPress_InputControlAlphaAndNumberOnly);
            }
        }

        /// <summary>
        /// 入力制御を無効にする.
        /// </summary>
        /// <param name="index"></param>
        private void InputControlOff(int index)
        {
            if (IsInputControlNumberOnly(index))
            {
                _spdMeiNyuryokAcom.EditingControl.KeyPress -= new KeyPressEventHandler(KkhInputControlAcom.KeyPress_InputControlNumberOnly);
            }
            else if (IsInputControlAlphaAndNumberOnly(index))
            {
                _spdMeiNyuryokAcom.EditingControl.KeyPress -= new KeyPressEventHandler(KkhInputControlAcom.KeyPress_InputControlAlphaAndNumberOnly);
            }
        }

        /// <summary>
        /// キー入力制限（数字のみ）の対象かを返す.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean IsInputControlNumberOnly(int index)
        {
            return (
                (index == COLIDX_MLIST_HACHUGYO_NO) ||
                (index == COLIDX_MLIST_SEIKYUSHO_NO) ||
                (index == COLIDX_MLIST_SEIKYUSHOGYO_NO) ||
                (index == COLIDX_MLIST_ANBUN)
            );
        }

        /// <summary>
        /// キー入力制限（英字と数字のみ）の対象かを返す.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean IsInputControlAlphaAndNumberOnly(int index)
        {
            return (
                (index == COLIDX_MLIST_HATSUORKEISAI) ||
                (index == COLIDX_MLIST_HACHU_NO)
            );
        }

        #endregion メソッド.
    }

}