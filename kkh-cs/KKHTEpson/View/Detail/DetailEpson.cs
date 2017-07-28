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
using Isid.KKH.Epson.Schema;
using Isid.KKH.Epson.ProcessController.Detail;
using Isid.KKH.Epson.Utility;
using drMasterData = Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow;

namespace Isid.KKH.Epson.View.Detail
{
    /// <summary>
    /// 明細登録画面(エプソン).
    /// </summary>
    public partial class DetailEpson : DetailForm
    {
        #region 定数.
        /* 2017/04/18 エプソン仕入先変更対応 ITCOM A.Nakamura ADD Start */
        #region 固定文言.
        /// <summary>
        /// 起票部門コード(DataField).
        /// </summary>
        public const string DFKIHYOUBMNCD = "kihyouBmnCd";
        /// <summary>
        /// 起票部門CD(label).
        /// </summary>
        public const string LKIHYOUBMNCD = "起票部門CD";
        /// <summary>
        /// 原価センタ(DataField).
        /// </summary>
        public const string DFGENKACENTER = "genkaCenter";
        /// <summary>
        /// 原価センタ(label).
        /// </summary>
        public const string LGENKACENTER = "原価センタ";
        /// <summary>
        /// 空の文字列.
        /// </summary>
        public const string BLANK = "";
        #endregion 固定文言.
        /* 2017/04/18 エプソン仕入先変更対応 ITCOM A.Nakamura ADD End */
        #region 明細一覧カラムインデックス.
        /// <summary>
        /// 請求書対象外列フラグインデックス.
        /// </summary>
        public const int COLIDX_MLIST_SEIFLG = 0;
        /// <summary>
        /// 請求書番号列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SEINO = 1;
        /// <summary>
        /// 売上明細NO列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_URIMEINO = 2;
        /// <summary>
        /// 広告件名列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KOUKOKUKENMEI = 3;
        /// <summary>
        /// 取引担当者コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_TRITNTCD = 4;
        /// <summary>
        /// 件名列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KENMEI = 5;
        /// <summary>
        /// 請求件名列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SEI_KENMEI = 6;
        /// <summary>
        /// 取引識別名列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_TRISIKIKEYCD = 7;
        /* 2017/04/14 エプソン仕入先変更対応 A.Nakamura ADD Start */ 
        /// <summary>
        /// 起票部門CD列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KIHYOUBMNCD = 8;
        /// <summary>
        /// 原価センタ列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_GENKACENTER = 9;
        /* 2017/04/14 エプソン仕入先変更対応 A.Nakamura ADD End */
        /// 事前金額列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_BFKNGK = 10;
        /// <summary>
        /// 事後金額列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_AFKNGK = 11;
        /// <summary>
        /// 業務区分列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_GYMKBN = 12;
        /// <summary>
        /// 請求区分列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SEIKBN = 13;
        /// <summary>
        /// 取引担当者名称列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_TRITNTNM = 14;
        /// <summary>
        /// 取引識別情報コード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_TRISIKICD = 15;
        /// <summary>
        /// 取引識別情報キーコード列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_TRISIKINM = 16;
        /// <summary>
        /// 指図NO列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SSNO = 17;
        /// <summary>
        /// セグメントNO列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SEGNO = 18;
        /// <summary>
        /// ソートキー列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SORT_KEY = 19;
        /// <summary>
        /// 金額(税込み)列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_SEI_KINGAKU = 20;
        /// <summary>
        /// 消費税列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_ZEI_GAKU = 21;
        /// <summary>
        /// 税抜き金額列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_ZEI_NKINGAKU = 22;
        /// <summary>
        /// 計上日列インデックス.
        /// </summary>
        public const int COLIDX_MLIST_KEIZYOUBI = 23;
        #endregion 明細一覧カラムインデックス.

        #region 受注一覧ヘッダカラムインデックス.
        /// <summary>
        /// 反映.
        /// </summary>
        public const int COLIDX_SHLIST_HANNEI = 0;
        /// <summary>
        /// 請求番号.
        /// </summary>
        public const int COLIDX_SHLIST_SEIKYUNO = 1;
        /// <summary>
        /// 件名.
        /// </summary>
        public const int COLIDX_SHLIST_KENMEI = 2;
        /// <summary>
        /// 請求金額(税込み)合計.
        /// </summary>
        public const int COLIDX_SHLIST_SEIKINGAKUGK = 3;
        /// <summary>
        /// 消費税額合計.
        /// </summary>
        public const int COLIDX_SHLIST_ZEIGAKUGK = 4;
        /// <summary>
        /// 請求金額(税抜き)合計.
        /// </summary>
        public const int COLIDX_SHLIST_ZEINKINGAKUGK = 5;
        /// <summary>
        /// 計上日.
        /// </summary>
        public const int COLIDX_SHLIST_KEIYYMM = 6;
        /// <summary>
        /// 請求ステータス.
        /// </summary>
        public const int COLIDX_SHLIST_SEISTATUS = 7;
        #endregion 受注一覧ヘッダカラムインデックス.

        #region 受注一覧カラムインデックス.
        /// <summary>
        /// 反映.
        /// </summary>
        public const int COLIDX_SCLIST_HANNEI = 0;
        /// <summary>
        /// 請求番号.
        /// </summary>
        public const int COLIDX_SCLIST_SEIKYUNO = 1;
        /// <summary>
        /// 請求明細番号.
        /// </summary>
        public const int COLIDX_SCLIST_SEIKYUMEINO = 2;
        /// <summary>
        /// 売上明細番号.
        /// </summary>
        public const int COLIDX_SCLIST_URIMEINO = 3;
        /// <summary>
        /// 件名.
        /// </summary>
        public const int COLIDX_SCLIST_KENMEI = 4;
        /// <summary>
        /// 請求金額(税込み)合計.
        /// </summary>
        public const int COLIDX_SCLIST_SEIKINGAKUGK = 5;
        /// <summary>
        /// 消費税額合計.
        /// </summary>
        public const int COLIDX_SCLIST_ZEIGAKUGK = 6;
        /// <summary>
        /// 請求金額(税抜き)合計.
        /// </summary>
        public const int COLIDX_SCLIST_ZEINKINGAKUGK = 7;
        /////<summary>
        /// 請求金額(税込み).
        /// </summary>
        public const int COLIDX_SCLIST_SEIKINGAKU = 8;
        /// <summary>
        /// 消費税額.
        /// </summary>
        public const int COLIDX_SCLIST_ZEIGAKU = 9;
        /// <summary>
        /// 請求金額(税抜き).
        /// </summary>
        public const int COLIDX_SCLIST_ZEINKINGAKU = 10;
        /// <summary>
        /// 計上日.
        /// </summary>
        public const int COLIDX_SCLIST_KEIYYMM = 11;
        /// <summary>
        /// 請求ステータス.
        /// </summary>
        public const int COLIDX_SCLIST_SEISTATUS = 12;
        #endregion 受注一覧カラムインデックス.

        #region 金額値.
        /// <summary>
        /// 明細スプレッド_金額の最大値.
        /// </summary>
        private const double MAX_VALUE_KINGAKU = 99999999999D;
        /// <summary>
        /// 明細スプレッド_金額の最小値.
        /// </summary>
        private const double MIN_VALUE_KINGAKU = -99999999999D;
        /// <summary>
        /// 明細スプレッド_金額のデフォルト値.
        /// </summary>
        private const string DEF_VALUE_KINGAKU = "0";
        #endregion 金額値.
        #endregion 定数.

        #region メンバ変数.
        /// <summary>
        /// 画面呼出引数.
        /// </summary>
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();
        /// <summary>
        /// 取引識別情報コンボボックスキー.
        /// </summary>
        private string[] _triSikiKey = null;
        /// <summary>
        /// 取引識別情報コンボボックス値.
        /// </summary>
        private string[] _triSikiValue = null;
        /// <summary>
        /// 取引担当者コンボボックス情報キー.
        /// </summary>
        private string[] _triTntKey = null;
        /// <summary>
        /// 取引担当者コンボボックス情報値.
        /// </summary>
        private string[] _triTntValue = null;
        /* 2017/04/14 エプソン仕入先変更対応 ITCOM A.Nakamura ADD Start */ 
        /// <summary>
        /// 起票部門CDコンボボックス情報キー.
        /// </summary>
        private string[] _kihyouBmnCdKey = null;
        /// <summary>
        /// 起票部門CDコンボボックス情報値.
        /// </summary>
        private string[] _kihyouBmnCdValue = null;
         /// <summary>
        /// 原価センタコンボボックス情報キー.
        /// </summary>
        private string[] _genkaCenterKey = null;
        /// <summary>
        /// 原価センタコンボボックス情報値.
        /// </summary>
        private string[] _genkaCenterValue = null;
        /* 2017/04/14 エプソン仕入先変更対応 ITCOM A.Nakamura ADD End */
        /// <summary>
        /// マスタユーティリティ.
        /// </summary>
        KkhMasterUtilityEpson _master;
        /// <summary>
        /// 文字エンコーディング.
        /// </summary>
        private Encoding _enc = Encoding.GetEncoding("shift-jis");
        /// <summary>
        /// 変更前のタブインデックス.
        /// </summary>
        private int _previousTabIndex = 0;
        /// <summary>
        /// タブ変更時の検索無効化ステータス.
        /// </summary>
        private Boolean _notSearchState = false;
        /// <summary>
        /// 請求回収データ検索実行時の設定条件を保持.
        /// </summary>
        private DetailEpsonProcessController.FindSeikyuKaisyuDataByCondParam findSeikyuKaisyuDataCond = new DetailEpsonProcessController.FindSeikyuKaisyuDataByCondParam();
        /// <summary>
        // 取消の請求回収データの請求番号格納用.
        /// </summary>
        private List<string> seiNoList = new List<string>();
        #endregion メンバ変数.

        #region コンストラクタ.
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DetailEpson()
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
            //受注登録内容(一覧)スプレッドのスプレッド、シートの設定を行う.
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

            //受注一覧カラム数分ループ処理.
            foreach (Column col in base._spdJyutyuList_Sheet1.Columns)
            {
                if (col.Index == COLIDX_JLIST_TOROKU        ) { col.Visible = true;  }  //登録.
                if (col.Index == COLIDX_JLIST_TOGO          ) { col.Visible = false; }  //統合.  
                if (col.Index == COLIDX_JLIST_DAIUKE        ) { col.Visible = true;  }  //代受.
                if (col.Index == COLIDX_JLIST_SEIKYU        ) { col.Visible = false; }  //請求.
                if (col.Index == COLIDX_JLIST_URIMEINO      ) { col.Visible = true;  }  //売上明細NO.
                if (col.Index == COLIDX_JLIST_GPYNO         ) { col.Visible = false; }  //請求原票NO.
                if (col.Index == COLIDX_JLIST_SEIYYMM       ) { col.Visible = true;  }  //請求年月.
                if (col.Index == COLIDX_JLIST_GYOMKBN       ) { col.Visible = true;  }  //業務区分.
                if (col.Index == COLIDX_JLIST_KENMEI        ) { col.Visible = true;  }  //件名.
                if (col.Index == COLIDX_JLIST_BAITAINM      ) { col.Visible = false; }  //媒体名.
                if (col.Index == COLIDX_JLIST_HIMOKUNM      ) { col.Visible = true;  }  //費目名.
                if (col.Index == COLIDX_JLIST_KYOKUSHICD    ) { col.Visible = false; }  //局誌CD.
                if (col.Index == COLIDX_JLIST_SEIKINGAKU    ) { col.Visible = true;  }  //請求金額.
                if (col.Index == COLIDX_JLIST_KIKAN         ) { col.Visible = false; }  //期間.
                if (col.Index == COLIDX_JLIST_DANTANKA      ) { col.Visible = false; }  //段単価.
                if (col.Index == COLIDX_JLIST_DANSU         ) { col.Visible = false; }  //段数.
                if (col.Index == COLIDX_JLIST_TORIRYOKIN    ) { col.Visible = true;  }  //取料金.
                if (col.Index == COLIDX_JLIST_NEBIKIRITSU   ) { col.Visible = true;  }  //値引率.
                if (col.Index == COLIDX_JLIST_NEBIKIGAKU    ) { col.Visible = true;  }  //値引額.
                if (col.Index == COLIDX_JLIST_ZEIRITSU      ) { col.Visible = true;  }  //消費税率.
                if (col.Index == COLIDX_JLIST_ZEIGAKU       ) { col.Visible = true;  }  //消費税額.
                if (col.Index == COLIDX_JLIST_GOUKEIKINGAKU ) { col.Visible = false; }  //受注請求金額.
                if (col.Index == COLIDX_JLIST_OLDSEIYYMM    ) { col.Visible = true;  }  //変更前請求年月.
            }
        }
        #endregion 得意先別に表示対象外列の非表示処理を行う.

        #region セルの色付け処理を行う.
        /// <summary>
        /// セルの色付け処理を行う.
        /// </summary>
        protected override void ChangeColor()
        {
            //親クラスの行っている共通処理を実行.
            base.ChangeColor();

            //受注データ件数分ループ処理.
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
        #endregion セルの色付け処理を行う.

        #region 広告費明細データの検索・表示.
        /// <summary>
        /// 広告費明細データの検索・表示. 
        /// </summary>
        /// <param name="rowIdx"></param>
        protected override void DisplayKkhDetail(int rowIdx)
        {
        }
        #endregion 広告費明細データの検索・表示.

        #region 受注登録内容(一覧)スプレッドのセル移動.
        /// <summary>
        /// 受注登録内容(一覧)スプレッドのセル移動.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void _spdJyutyuList_LeaveCell(object sender, LeaveCellEventArgs e)
        {
        }
        #endregion 受注登録内容(一覧)スプレッドのセル移動.

        #region 受注登録内容検索前チェック処理.
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
        #endregion 受注登録内容検索前チェック処理.

        #region 受注登録内容検索前クリア処理.
        /// <summary>
        /// 受注登録内容検索前クリア処理.
        /// </summary>
        protected override void InitializeBeforeSearch()
        {
            // 親の処理でタブが変更されるため明細変更フラグをクリア.
            kkhDetailUpdFlag = false;

            // タブが「一覧」に変更されるため、その際の検索処理を無効化.
            _notSearchState = true;

            //親クラスの行っている共通処理を実行. 
            base.InitializeBeforeSearch();

            // タブ変更時の検索を有効化.
            _notSearchState = false;

            //差額・計ラベル.
            lblJyutyuDownValue.Text = "";
            lblJyutyuDownValue2.Text = "";
            lblJyutyuMeisaiValue.Text = "";
            lblSeikyuDownValue.Text = "";
            lblSeikyuDownValue2.Text = "";
            lblSeikyuMeisaiValue.Text = "";

            //***************************************
            //ボタン類の使用可・不可設定. 
            //***************************************
            btnRegister.Enabled = false;
            btnRegBulk.Enabled = false;
            btnReqBind.Enabled = false;
            btnBulkMerge.Enabled = false;
            btnMerge.Enabled = false;
            btnMergeCancel.Enabled = false;
            btnDetailInput.Enabled = false;
            btnDetailDel.Enabled = false;
            btnDetailRegister.Enabled = false;
        }
        #endregion 受注登録内容検索前クリア処理.

        #region 受注登録内容検索後チェック処理.
        /// <summary>
        /// 受注登録内容検索後チェック処理.
        /// </summary>
        /// <returns></returns>
        protected override Boolean CheckAfterSearch()
        {
            return true;
        }
        #endregion 受注登録内容検索後チェック処理.

        #region 受注登録内容検索後初期表示処理.
        /// <summary>
        /// 受注登録内容検索後初期表示処理.
        /// </summary>
        protected override void InitializeAfterSearch()
        {
            //親クラスの行っている共通処理を実行.
            base.InitializeAfterSearch();
        }
        #endregion 受注登録内容検索後初期表示処理.

        #region 受注削除処理実行前チェック.
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
        #endregion 受注削除処理実行前チェック.

        #region 受注削除後の初期化処理.
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
                //ボタンの使用不可 
                btnDetailInput.Enabled = false;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = false;

                //合計.
                lblJyutyuMeisaiValue.Text = "0";
                lblJyutyuDownValue.Text = "0";
                lblSeikyuMeisaiValue.Text = "0";

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
            if (base.CheckBeforeYmChange() == false)
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
            base.MouseMoveCommon(sender, e);
        }
        #endregion MouseMoveイベント.

        #region MouseLeaveイベント.
        /// <summary>
        /// MouseLeaveイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseLeaveCommon(object sender, EventArgs e)
        {
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
            base.EnableChangeForSelectJyutyuListRow(activeSheet, activeRow);

            //受注登録明細(親)シート以外がアクティブの場合. 
            if (activeSheet != _spdJyutyuList_Sheet1)
            {
                //明細関係のボタン使用不可 
                btnDetailInput.Enabled = false;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = false;
            }
        }
        #endregion 受注登録内容(一覧)でフォーカスがあるビューによってコントロールの制御を行う.

        #region 受注登録内容検索・表示処理.
        /// <summary>
        /// 受注登録内容検索・表示処理.
        /// </summary>
        /// <param name="reLoadFlag">再検索フラグ(True：再検索、False：通常検索)</param>
        protected override Boolean SearchJyutyuData(bool reLoadFlag)
        {
            // 継承元で処理を中断した場合は同様に中断する.
            if (base.SearchJyutyuData(reLoadFlag))
            {
                return true;
            }

            // エプソンは全受注の明細を常に表示するため明細の検索を実行.
            this.DisplayDetail();

            return false;
        }
        #endregion 受注登録内容検索・表示処理.

        #region 変更・削除チェック.
        /// <summary>
        /// 変更・削除チェック.
        /// </summary>
        protected override Boolean CheckUpdate()
        {
            // 継承元で処理を中断した場合は同様に中断する.
            if (base.CheckUpdate())
            {
                return true;
            }

            // エプソンは全受注の明細を常に表示するため明細の検索を実行.
            this.DisplayDetail();

            return false;
        }
        #endregion 変更・削除チェック.

        #region 受注統合ボタンクリック処理.
        /// <summary>
        ///  受注統合ボタンクリック処理.
        /// </summary>
        protected override void MergeClick()
        {
            //選択行の取得 .
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
        #endregion 受注統合ボタンクリック処理.

        #region 受注チェック.
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

            // オペレーションログの出力 
            KKHLogUtilityEpson.WriteOperationLogToDB(_naviParameter, KKHSystemConst.ApplicationID.APLID_DTL_EPSON, KKHLogUtilityEpson.KINO_ID_OPERATION_LOG_UPDCHECK, KKHLogUtilityEpson.DESC_OPERATION_LOG_UPDCHECK);

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
        private void DetailEpson_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            // ナビパラ受取.
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
        private void DetailEpson_Shown(object sender, EventArgs e)
        {
            ShowLoadingDialog();

            InitializeCommonProperty();
            InitializeDataSourceEpson();
            InitializeControlEpson();
            InitializeDesignForSpdKkhDetail();

            _previousTabIndex = tabHed.SelectedIndex;

            CloseLoadingDialog();
        }
        #endregion フォームロードイベント.

        #region 検索ボタン押下.
        /// <summary>
        /// 検索ボタン押下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSch_Click(object sender, EventArgs e)
        {
            if (ConfirmEditState)
            {
                // 請求回収データの検索.
                SearchSeikyuKaisyuData();

                // 選択状態を解除 
                this.ActiveControl = null;

                // ボタンの有効無効を変更.
                SetButtonEnable();

                // データをクリアしたため明細変更フラグをオフにする.
                kkhDetailUpdFlag = false;

                // エラーチェック.
                if (( _dsDetail.JyutyuList.Count == 0 ) && ( _dsSeikyuEpson.SeikyuHeader.Count == 0 ))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "入力エラー", MessageBoxButtons.OK);
                    txtYmd.Focus();
                    return;
                }

                if (_dsSeikyuEpson.SeikyuHeader.Rows.Count != 0)
                {
                    // タブ変更時の検索を無効化.
                    _notSearchState = true;

                    // 請求回収データがある場合は自動でそちらを開く.
                    tabHed.SelectedIndex = 2;

                    // 請求回収の明細の方も色変更.
                    for (int i = 0; i < _spdKkhDetail_Sheet1.Rows.Count; i++)
                    {
                        // 取消になっている請求回収データの明細の場合は背景色変更.
                        if (seiNoList.Contains(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEINO].Text))
                        {
                            // 請求ステータスが3(取消)の明細の場合は背景色を変更. 
                            _spdKkhDetail_Sheet1.Rows[i].BackColor = Color.FromArgb(165, 165, 165);
                        }
                    }

                    // タブ変更時の検索を有効化.
                    _notSearchState = false;
                }
            }
        }
        #endregion 検索ボタン押下.

        #region 個別登録.
        /// <summary>
        /// 個別登録.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            String mode = String.Empty;

            if (isActivatedJyutyuList())
            {
                // 広告費用明細.
                if (!SetDetailData(_spdJyutyuList_Sheet1.ActiveRowIndex))
                {
                    // メッセージボックス.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0090, null, "明細登録", MessageBoxButtons.OK);
                }
            }
            else if (isActivatedSeikyuList())
            {
                if (!SetSeikyuDetailData(_spdSeikyuList_Sheet1.ActiveRowIndex, out mode))
                {
                    if(mode.Equals("FIN"))
                    {
                        // メッセージボックス.
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new String[] { "同じ請求書番号を持つ明細が既に存在しています。" }, "明細登録", MessageBoxButtons.OK);
                    }
                    else if (mode.Equals("DEL"))
                    {
                        // メッセージボックス.
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new String[] { "取消された請求回収データです。" }, "明細登録", MessageBoxButtons.OK);
                    }
                }
            }

            // ボタンの有効無効を変更.
            SetButtonEnable();

            //選択状態を解除. 
            this.ActiveControl = null;
        }
        #endregion 個別登録.

        #region 一括登録ボタンクリック.
        /// <summary>
        /// 一括登録ボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBulkRegister_Click(object sender, EventArgs e)
        {
            int detailAdditionCount = 0;

            for (int i = 0; i < _spdJyutyuList_Sheet1.RowCount; i++)
            {
                if (SetDetailData(i))
                {
                    // 明細追加件数をカウントアップ.
                    detailAdditionCount++;
                }
            }

            if (detailAdditionCount == 0)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "明細登録", MessageBoxButtons.OK);

                //選択状態を解除. 
                this.ActiveControl = null;

                return;
            }

            //******************************
            // 合計ラベル. 
            //******************************
            CalculateGoukei();

            //***************************************
            // ボタン類の使用可・不可設定. 
            //***************************************
            SetButtonEnable();

            //選択状態を解除. 
            this.ActiveControl = null;
        }
        #endregion 一括登録ボタンクリック.

        #region 請求回収データ反映処理.
        /// <summary>
        /// 請求回収データ反映処理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReqBind_Click(object sender, EventArgs e)
        {
            int detailAdditionCount = 0;
            String mode = String.Empty;

            for (int i = 0; i < _spdSeikyuList_Sheet1.RowCount; i++)
            {
                if (SetSeikyuDetailData(i,out mode))
                {
                    // 明細追加件数をカウントアップ.
                    detailAdditionCount++;
                }
            }

            if (detailAdditionCount == 0)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "明細登録", MessageBoxButtons.OK);

                //選択状態を解除. 
                this.ActiveControl = null;

                return;
            }

            //******************************
            // 合計ラベル. 
            //******************************
            CalculateGoukei();

            //***************************************
            // ボタン類の使用可・不可設定 .
            //***************************************
            SetButtonEnable();

            //選択状態を解除. 
            this.ActiveControl = null;
        }
        #endregion 請求回収データ反映処理.

        #region 一括統合ボタンクリック.
        /// <summary>
        /// 一括統合ボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBulkMerge_Click(object sender, EventArgs e)
        {
            //***********************************************************
            //処理実行前チェック・対象データ取得 .
            //***********************************************************
            //*************************
            //広告費明細の編集状況確認. 
            //*************************
            if (ConfirmEditStatus() == false)
            {

                //選択状態を解除. 
                this.ActiveControl = null;

                return;
            }

            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();
            List<Isid.KKH.Common.KKHProcessController.Detail.DetailProcessController.MergeJyutyuDataParam> mergeJyutyuDataParamList
                = new List<Isid.KKH.Common.KKHProcessController.Detail.DetailProcessController.MergeJyutyuDataParam>();

            //アクティブ行の取得. 
            int activeRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            DataTable dtJyutNo = _dsDetail.JyutyuData.DefaultView.ToTable(true, dsDetail.THB1DOWN.hb1JyutNoColumn.ColumnName);
            for (int i = 0; i < dtJyutNo.Rows.Count; i++)
            {
                //統合対象行データの取得. 
                string filterEx = dsDetail.THB1DOWN.hb1JyutNoColumn.ColumnName + "='" + dtJyutNo.Rows[i].ItemArray[0].ToString() + "'";
                filterEx = filterEx + " AND " + dsDetail.THB1DOWN.hb1TJyutNoColumn.ColumnName + "=''";
                string sortKey = dsDetail.THB1DOWN.hb1JyutNoColumn.ColumnName + "," + dsDetail.THB1DOWN.hb1JyMeiNoColumn.ColumnName + "," + dsDetail.THB1DOWN.hb1UrMeiNoColumn.ColumnName;
                Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] targetRows = (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[])_dsDetail.JyutyuData.Select(filterEx, sortKey);

                Isid.KKH.Common.KKHSchema.Detail targetDsDetail = new Isid.KKH.Common.KKHSchema.Detail();
                Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable targetDt = targetDsDetail.JyutyuData;

                foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow targetRow in targetRows)
                {
                    targetDt.ImportRow(targetRow);

                    //選択されている受注登録内容の行数分の処理を繰り返す. 
                    if (targetRow.hb1TouFlg == "1")
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0015, null, "明細登録", MessageBoxButtons.OK);

                        //選択状態を解除. 
                        this.ActiveControl = null;

                        return;
                    }

                    Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow addRow = dsDetail.JyutyuData.NewJyutyuDataRow();
                    addRow.ItemArray = (object[])targetRow.ItemArray;

                    dsDetail.JyutyuData.AddJyutyuDataRow(addRow);
                }
                //受注統合データの追加.
                AddJyutyuDataMergeVO(mergeJyutyuDataParamList, targetDt, targetRows[0].rowNum);
            }

            //***********************************************************
            //統合処理実行.
            //***********************************************************
            if (MergeBulkJyutyuDataEpson(mergeJyutyuDataParamList) == false)
            {
                //選択状態を解除. 
                this.ActiveControl = null;

                return;
            }

            //*************************************
            //再検索・表示.
            //*************************************
            //実行結果が正常な場合、受注統合処理後の再表示処理を行う. 
            ReSearchJyutyuData();
            if (_spdJyutyuList_Sheet1.RowCount >= activeRowIdx + 1)
            {
                _spdJyutyuList_Sheet1.SetActiveCell(activeRowIdx, 0, true);
                _spdJyutyuList_Sheet1.AddSelection(activeRowIdx, -1, 1, -1);
            }

            MessageUtility.ShowMessageBox(MessageCode.HB_I0009, null, "明細登録", MessageBoxButtons.OK);

            //選択状態を解除 
            this.ActiveControl = null;

        }
        #endregion 一括統合ボタンクリック.

        #region 受注統合データの追加.
        /// <summary>
        /// 受注統合データの追加.
        /// </summary>
        /// <param name="dtJyutyuData">統合対象となる受注データ(JyutyuData)</param>
        /// <param name="tousakiRownum">統合先となる受注データ(JyutyuData)のRowNum</param>
        /// <returns></returns>
        protected void AddJyutyuDataMergeVO(List<Isid.KKH.Common.KKHProcessController.Detail.DetailProcessController.MergeJyutyuDataParam> mergeJyutyuDataParamList,Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable dtJyutyuData, int tousakiRownum)
        {
            DetailProcessController.MergeJyutyuDataParam param = CreateServiceParamForMergeJyutyuData(dtJyutyuData, tousakiRownum);
            mergeJyutyuDataParamList.Add(param);
        }
        #endregion 受注統合データの追加.

        #region 一括統合APIの実行.
        /// <summary>
        /// 一括統合APIの実行.
        /// </summary>
        /// <param name="mergeJyutyuDataParamList">受注統合パラメータリスト</param>
        /// <returns></returns>
        protected bool MergeBulkJyutyuDataEpson(List<Isid.KKH.Common.KKHProcessController.Detail.DetailProcessController.MergeJyutyuDataParam> mergeJyutyuDataParamList)
        {
            DetailEpsonProcessController.MergeBulkJyutyuDataEpsonParam param = new Isid.KKH.Epson.ProcessController.Detail.DetailEpsonProcessController.MergeBulkJyutyuDataEpsonParam();
            param.mergeJyutyuDataParamList = mergeJyutyuDataParamList;
            DetailEpsonProcessController processController = DetailEpsonProcessController.GetInstance();
            MergeBulkJyutyuDataEpsonServiceResult result = processController.MergeBulkJyutyuDataEpson(param);
            if (result.HasError == true)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_E0006, null, "明細登録", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
        #endregion 一括統合APIの実行.

        #region 明細入力ボタンクリック.
        /// <summary>
        /// 明細入力ボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailInput_Click(object sender, EventArgs e)
        {
            // 明細入力画面表示 
            //パラメータセット.
            DetailInputEpsonNaviParameter naviParam = new DetailInputEpsonNaviParameter();

            //基本情報.
            naviParam.AplId = _naviParameter.AplId;
            naviParam.strEsqId = _naviParameter.strEsqId;
            naviParam.strEgcd = _naviParameter.strEgcd;
            naviParam.strTksKgyCd = _naviParameter.strTksKgyCd;
            naviParam.strTksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            naviParam.strTksTntSeqNo = _naviParameter.strTksTntSeqNo;

            if(isActivatedJyutyuList())
            {
                naviParam.Kbn = "1";
            }
            else if(isActivatedSeikyuList())
            {
                naviParam.Kbn = "2";
            }
            naviParam.RowDetailIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

            //naviParam.RowDetailIndex = rowDetailIndex;
            naviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1;

            object result = Navigator.ShowModalForm(this, "toDetailInputEpson", naviParam);
            if (result == null)
            {
                this.ActiveControl = null;
                return;
            }
            base.kkhDetailUpdFlag = true; //広告費明細変更フラグを更新 

            DetailInputEpsonNaviParameter naviParamOut = (DetailInputEpsonNaviParameter)result;
            _spdKkhDetail_Sheet1 = naviParamOut.SpdKkhDetail_Sheet1;

            // 合計計算 
            CalculateGoukei();
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
            //登録確認ダイアログで[いいえ]を選択した場合.
            if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_C0002, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.YesNo))
            {
                //選択状態を解除.
                this.ActiveControl = null;
                return;
            }

            //請求回収用明細の場合のみチェックする.
            if (isActivatedSeikyuList())
            {
                /* 2015/04/06 エプソン件名拡張対応 HLC K.Fujisaki ADD Start */
                {
                    //件名の桁数チェック.
                    if (!CheckByteLength(COLIDX_MLIST_SEI_KENMEI))
                    {
                        return;
                    }
                }
                /* 2015/04/06 エプソン件名拡張対応 HLC K.Fujisaki ADD End */
                {
                    //計上日警告フォーマットチェック.
                    Boolean state = false;

                    //明細件数分ループ処理を行う.
                    for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
                    {
                        //計上日の取得.
                        String keizyoBi = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEIZYOUBI].Text;

                        //計上日が空でない場合.
                        if (String.IsNullOrEmpty(keizyoBi))
                        {
                            //警告を出力するため、別途チェック.
                            continue;
                        }

                        //計上日の形式変換.
                        if (KKHUtility.IsDate(keizyoBi, KKHSystemConst.Format.YEAR_MONTH_DAY_FORMAT))
                        {
                            //正しい形であれば問題なし.
                            continue;
                        }

                        //年月形式じゃないのでエラー.
                        state = true;
                        break;
                    }

                    //計上日警告フォーマットチェックで問題ありの場合.
                    if (state)
                    {
                        //警告メッセージを出力.
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0169, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                        return;
                    }
                }
                {
                    //取引識別警告.
                    Boolean state = false;

                    //明細件数分ループ処理.
                    for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
                    {
                        /* 2017/04/24 エプソン仕入先情報変更対応 HLC K.Soga MOD Start */
                        ////取引識別キーコードの取得.
                        //String strTriSikiKeyCd = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TRISIKIKEYCD].Text;
                        //if (!String.IsNullOrEmpty(strTriSikiKeyCd))
                        //{
                        //    //問題なし.
                        //    continue;
                        //}

                        //取引識別キーコード、起票部門CD、および原価センタが空でない場合.
                        if (!String.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TRISIKIKEYCD].Text)
                            && !String.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KIHYOUBMNCD].Text) 
                            && !String.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_GENKACENTER].Text))
                        {
                            //問題なし.
                            continue;
                        }
                        /* 2017/04/24 エプソン仕入先情報変更対応 HLC K.Soga MOD End */

                        //空の場合はまとめて警告を表示する.
                        state = true;
                    }

                    //取引識別キーコード、起票部門CD、または原価センタが空の場合.
                    if (state)
                    {
                        /* 2017/04/24 エプソン仕入先情報変更対応 HLC K.Soga MOD Start */
                        //DialogResult result = MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new String[] { "取引識別情報が入力されていません。\nこのまま登録を行いますか？" }, "明細登録", MessageBoxButtons.YesNo);
                        //警告メッセージを出力.
                        DialogResult result = MessageUtility.ShowMessageBox(MessageCode.HB_W0170, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.YesNo);
                        /* 2017/04/24 エプソン仕入先情報変更対応 HLC K.Soga MOD End */

                        //警告メッセージで[いいえ]を選択した場合.
                        if (result == DialogResult.No)
                        {
                            //処理中止.
                            return;
                        }
                    }
                }

                {
                    //計上日警告.
                    Boolean state = false;

                    //明細件数分ループ処理.
                    for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
                    {
                        //計上日を取得.
                        String keizyoBi = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEIZYOUBI].Text;

                        //計上日が空でない場合.
                        if (!String.IsNullOrEmpty(keizyoBi))
                        {
                            //問題なし.
                            continue;
                        }

                        //空の場合はまとめて警告を表示する.
                        state = true;
                    }

                    //計上日警告に問題ありの場合.
                    if (state)
                    {
                        //警告メッセージを出力.
                        DialogResult result = MessageUtility.ShowMessageBox(MessageCode.HB_W0171, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.YesNo);

                        //警告メッセージで[いいえ]を選択した場合.
                        if (result == DialogResult.No)
                        {
                            //処理中止.
                            return;
                        }
                    }
                }
            }
            /* 2015/04/06 エプソン件名拡張対応 HLC K.Fujisaki ADD Start */
            // 受注リストの場合のみチェックする 
            else if (isActivatedJyutyuList())
            {
                // 件名の桁数チェック.
                if (!CheckByteLength(COLIDX_MLIST_SEI_KENMEI))
                {
                    return;
                }
            }
            /* 2015/04/06 エプソン件名拡張対応 HLC K.Fujisaki ADD End */

            //明細登録処理.
            RegistDetailData();

            //選択状態を解除 
            this.ActiveControl = null;
        }
        #endregion 明細登録ボタンクリックイベント.

        #region 明細削除ボタンクリック.
        /// <summary>
        /// 明細削除ボタンクリック.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailDel_Click(object sender, EventArgs e)
        {
            if (MessageUtility.ShowMessageBox(MessageCode.HB_C0009, null, "明細登録", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                //選択状態を解除 
                this.ActiveControl = null;

                return;
            }

            //フィルタによって表示されていない行が存在する場合は削除不可.
            ArrayList filteroutlist = _spdKkhDetail_Sheet1.RowFilter.GetFilteredOutRowList();

            if (!filteroutlist.Count.Equals(0))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0158, null, "明細登録", MessageBoxButtons.OK);
                return;
            }
          

            ArrayList rowNum = new ArrayList();

            //選択行の取得 
            CellRange[] cellRanges = SortCellRangesByRowIdx(_spdKkhDetail_Sheet1.GetSelections());
            foreach (CellRange cellRange in cellRanges)
            {
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    //選択されている明細の行数分の処理を繰り返す 
                    int rowIndex = cellRange.Row + i;

                    //行のArraylistに設定.
                    if (isActivatedJyutyuList())
                    {
                        rowNum.Add(_spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_URIMEINO].Text);
                    }
                    else if (isActivatedSeikyuList())
                    {
                        rowNum.Add(_spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_SEINO].Text);
                    }
                }
            }
            
            //行の削除をデータに反映.
            if (isActivatedJyutyuList())
            {
                for (int i = 0; i < rowNum.Count; i++)
                {
                    DetailDSEpson.KkhDetailRow[] rows = (DetailDSEpson.KkhDetailRow[])_dsDetailEpson.KkhDetail.Select("uriMeiNo = '" + rowNum[i].ToString() + "'", "");

                    if (rows.Length != 0)
                    {
                        _dsDetailEpson.KkhDetail.RemoveKkhDetailRow(rows[0]);
                        _dsDetailEpson.KkhDetail.AcceptChanges();

                        _bsKkhDetail.DataSource = _dsDetailEpson;
                        _bsKkhDetail.DataMember = _dsDetailEpson.KkhDetail.TableName;
                        _bsKkhDetail.EndEdit();

                        _dsDetailEpson.KkhDetail.AcceptChanges();
                    }
                }
            }
            else if (isActivatedSeikyuList())
            {
                for (int i = 0; i < rowNum.Count; i++)
                {
                    DetailDSEpson.KkhDetailRow[] rows = (DetailDSEpson.KkhDetailRow[])_dsSeikyuDetailEpson.KkhDetail.Select("seiNo = '" + rowNum[i].ToString() + "'", "");

                    if (rows.Length != 0)
                    {
                        _dsSeikyuDetailEpson.KkhDetail.RemoveKkhDetailRow(rows[0]);
                        _dsSeikyuDetailEpson.KkhDetail.AcceptChanges();

                        _bsKkhDetail.DataSource = _dsSeikyuDetailEpson;
                        _bsKkhDetail.DataMember = _dsSeikyuDetailEpson.KkhDetail.TableName;
                        _bsKkhDetail.EndEdit();

                        _dsSeikyuDetailEpson.KkhDetail.AcceptChanges();
                    }
                }
            }


            // ボタンの有効無効を更新.
            SetButtonEnable();

            //広告費明細変更フラグを更新.
            base.kkhDetailUpdFlag = true;

            //******************************
            //差額・計ラベル 
            //******************************

            //合計計算 
            CalculateGoukei();

            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(_spdKkhDetail_Sheet1.ActiveRowIndex, -1, 1, -1);
            }

            //選択状態を解除 
            this.ActiveControl = null;
        }
        #endregion 明細削除ボタンクリック.

        #region 明細スプレッド内のセルでテキストを変更するときに発生します.
        /// <summary>
        /// 明細スプレッド内のセルでテキストを変更するときに発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_EditChange(object sender, EditorNotifyEventArgs e)
        {
            FarPoint.Win.FpCombo editCombo = new FarPoint.Win.FpCombo();

            ComboBoxCellType celltype = new ComboBoxCellType();

            switch (e.Column)
            {
                // 広告件名.
                case COLIDX_MLIST_KOUKOKUKENMEI:
                case COLIDX_MLIST_KENMEI:
                case COLIDX_MLIST_SEI_KENMEI:
                    // TextCellTypeの場合は最大バイト数の編集処理を行う 
                    if (_spdKkhDetail_Sheet1.Columns[e.Column].CellType is TextCellType)
                    {
                        TextCellType tc = (TextCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;
                        string s = e.EditingControl.Text;
                        if (_enc.GetByteCount(s) > tc.MaxLength)
                        {
                            e.EditingControl.Text = _enc.GetString(_enc.GetBytes(s), 0, tc.MaxLength);
                            ( (GeneralEditor)e.EditingControl ).SelectionStart = e.EditingControl.Text.Length;
                        }
                    }
                    break;

                // 取引識別名称（キーコード）.
                case COLIDX_MLIST_TRISIKIKEYCD:

                    editCombo = (FarPoint.Win.FpCombo)e.EditingControl;

                    celltype = (ComboBoxCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;

                    {
                        if (editCombo.SelectedIndex >= 0)
                        {
                            String key = celltype.ItemData[editCombo.SelectedIndex].ToString();

                            KkhMasterUtilityEpson.TRISIKI_DATA t = _master.GetTRISIKI(key);

                            if (t != null)
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKICD].Text  = t.code;
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKINM].Text  = t.name;
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SSNO     ].Text  = t.ssNo;
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEGNO    ].Text  = t.segNo;
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SORT_KEY ].Text  = t.sortKey;
                            }
                            else
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKICD].Text  = "";
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKINM].Text  = "";
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SSNO     ].Text  = "";
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEGNO    ].Text  = "";
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SORT_KEY ].Text  = "";
                            }
                        }
                        else
                        {
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKICD].Text  = "";
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKINM].Text  = "";
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SSNO     ].Text  = "";
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEGNO    ].Text  = "";
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SORT_KEY ].Text  = "";
                        }
                    }

                    break;

                // 取引担当者名称（キーコード）.
                case COLIDX_MLIST_TRITNTCD:

                    editCombo = (FarPoint.Win.FpCombo)e.EditingControl;

                    celltype = (ComboBoxCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;

                    {
                        if (editCombo.SelectedIndex >= 0)
                        {
                            String key = celltype.ItemData[editCombo.SelectedIndex].ToString();

                            KkhMasterUtilityEpson.TRITNT_DATA t = _master.GetTRITNT(key);

                            if (t != null)
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRITNTNM].Text = t.name;
                            }
                            else
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRITNTNM].Text = "";
                            }
                        }
                        else
                        {
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRITNTNM].Text = "";
                        }
                    }

                    break;

                case COLIDX_MLIST_SEI_KINGAKU:
                case COLIDX_MLIST_ZEI_GAKU:
                    {
                        Decimal seiKingaku = 0M;

                        Decimal zeiGaku = 0M;

                        // 金額（税込み）.
                        if (!String.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEI_KINGAKU].Text))
                        {
                            seiKingaku = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEI_KINGAKU].Text);
                        }

                        // 消費税.
                        if (!String.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_ZEI_GAKU].Text))
                        {
                            zeiGaku = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_ZEI_GAKU].Text);
                        }

                        // 金額（税込み）.
                        _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_ZEI_NKINGAKU].Text = ( seiKingaku - zeiGaku ).ToString("###,###,###,##0");
                    }

                    break;

                default:
                    if (_spdKkhDetail_Sheet1.Columns[e.Column].CellType is TextCellType)
                    {
                        TextCellType tc = (TextCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;
                        string s = e.EditingControl.Text;
                        if (_enc.GetByteCount(s) > tc.MaxLength)
                        {
                            e.EditingControl.Text = _enc.GetString(_enc.GetBytes(s), 0, tc.MaxLength);
                            ( (GeneralEditor)e.EditingControl ).SelectionStart = e.EditingControl.Text.Length;
                        }
                    }
                    break;
            }

            // 広告費明細変更フラグを更新 
            base.kkhDetailUpdFlag = true;
        }
        #endregion 明細スプレッド内のセルでテキストを変更するときに発生します.

        #region 明細スプレッドのキーダウンイベント.
        /// <summary>
        /// 明細スプレッドのキーダウンイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_KeyDown(object sender, KeyEventArgs e)
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
                    // 列 
                    int col = rn.Column;
                    // 行 
                    int row = rn.Row;
                    // 選択範囲終了列.
                    int colEnd = ( rn.Column + rn.ColumnCount - 1 );
                    // 選択範囲終了行 
                    int rowEnd = ( rn.Row + rn.RowCount - 1 );
                    for (int colCnt = col; colCnt <= colEnd; colCnt++)
                    {
                        bool multiCopyFlg = false;
                        // 行分ループ 
                        for (int rowCnt = row; rowCnt < rowEnd + 1; rowCnt++)
                        {
                            multiCopyFlg = isSetContinuePast(spdKkhDetail.GetRootWorkbook(), clipVal, rowCnt, colCnt);

                            if (multiCopyFlg)
                            {
                                // 複数コピーの為、貼り付け終了 
                                break;
                            }
                        }
                        if (multiCopyFlg)
                        {
                            // 複数コピーの為、貼り付け終了 
                            break;
                        }
                    }
                }
            }
        }
        #endregion 明細スプレッドのキーダウンイベント.

        #region ペースト処理.
        /// <summary>
        /// ペースト処理 
        /// </summary>
        /// <param name="spView"></param>
        /// <param name="val"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>
        /// true = 貼り付け継続 
        /// false = 貼り付け終了 
        /// </returns>
        private bool isSetContinuePast(FarPoint.Win.Spread.SpreadView spView, string val, int row, int col)
        {
            SheetView shView = spView.GetSheetView(); ;

            bool multiCopyFlg = true;
            // コピー例外発生をTry～Catchで吸収する 

            // キー=「列,行」値=「貼り付け値」 
            Dictionary<string, string> pastDic = KKHUtility.getPastValueDic(val);

            if (pastDic.Count == 1)
            {
                // 複数コピーでない場合 
                multiCopyFlg = false;
            }

            // コピー分のセル走査.
            foreach (string pastKey in pastDic.Keys)
            {
                // キー「列,行」を分割.
                string[] keySplitArr = pastKey.Split(KKHSystemConst.SPLIT_VAL.ToCharArray());

                // 列 
                int addCol = int.Parse(keySplitArr[0]);
                // 行 
                int addRow = int.Parse(keySplitArr[1]);
                try
                {
                    // ペースト対象列 
                    int colNum = col + addCol;
                    // ペースト対象行 
                    int rowNum = row + addRow;

                    // コピー可能な列か確認する 
                    if (!isCopyOKColumn(shView, colNum, rowNum))
                    {
                        continue;
                    }

                    // ペースト 
                    shView.Cells[rowNum, colNum].Text = pastDic[pastKey];

                    // コピー後のカラム変更による検証処理 
                    ChangeEventArgs changeEvent = new ChangeEventArgs(spView, rowNum, colNum);

                    // セル変更処理実行 
                    spdKkhDetail_Change(spdKkhDetail, changeEvent);
                }
                // セルタイプの違い等でのエラー回避用.
                catch { }
            }

            return multiCopyFlg;
        }
        #endregion ペースト処理.

        #region コピー可能列確認.
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
                // ロックされている場合 
                return false;
            }

            //非表示列へは貼り付け不可とする.
            if (actColumn.Visible.Equals(false))
            {
                return false;
            }

            if (actColumn.CellType is TextCellType     ||
                actColumn.CellType is NumberCellType   ||
                actColumn.CellType is ComboBoxCellType )
            {
                // セルタイプがテキストの場合 
                if (shView.Cells[row, col].Locked)
                {
                    return false;
                }

                return true;
            }

            return false;
        }
        #endregion コピー可能列確認.

        #region スプレッドチェンジ.
        /// <summary>
        /// スプレッドチェンジ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_Change(object sender, ChangeEventArgs e)
        {
            switch (e.Column)
            {
                // 広告件名.
                case COLIDX_MLIST_KOUKOKUKENMEI:
                case COLIDX_MLIST_KENMEI:
                case COLIDX_MLIST_SEI_KENMEI:
                    {
                        // TextCellTypeの場合は最大バイト数の編集処理を行う 
                        if (_spdKkhDetail_Sheet1.Columns[e.Column].CellType is TextCellType)
                        {
                            TextCellType tc = (TextCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;

                            string s = _spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Text;

                            if (_enc.GetByteCount(s) > tc.MaxLength)
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Text = _enc.GetString(_enc.GetBytes(s), 0, tc.MaxLength);
                            }
                        }
                    }

                    break;

                // 取引識別名称（キーコード）.
                case COLIDX_MLIST_TRISIKIKEYCD:
                    {
                        if (_spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Value != null)
                        {
                            String key = _spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Value.ToString();

                            KkhMasterUtilityEpson.TRISIKI_DATA t = _master.GetTRISIKI(key);

                            if (t != null)
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKICD].Text = t.code;
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKINM].Text = t.name;
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SSNO     ].Text = t.ssNo;
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEGNO    ].Text = t.segNo;
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SORT_KEY ].Text = t.sortKey;
                            }
                            else
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKICD].Text = "";
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKINM].Text = "";
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SSNO     ].Text = "";
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEGNO    ].Text = "";
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SORT_KEY ].Text = "";
                            }
                        }
                        else
                        {
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKICD].Text = "";
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKINM].Text = "";
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SSNO     ].Text = "";
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEGNO    ].Text = "";
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SORT_KEY ].Text = "";
                        }
                    }

                    break;

                // 取引担当者名称（キーコード）.
                case COLIDX_MLIST_TRITNTCD:
                    {
                        if (_spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Value != null)
                        {
                            String key = _spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Value.ToString();

                            KkhMasterUtilityEpson.TRITNT_DATA t = _master.GetTRITNT(key);

                            if (t != null)
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRITNTNM].Text = t.name;
                            }
                            else
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRITNTNM].Text = "";
                            }
                        }
                        else
                        {
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRITNTNM].Text = "";
                        }
                    }

                    break;

                case COLIDX_MLIST_SEI_KINGAKU:
                case COLIDX_MLIST_ZEI_GAKU:
                    {
                        Decimal seiKingaku = 0M;

                        Decimal zeiGaku = 0M;

                        // 金額（税込み）.
                        if (!String.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEI_KINGAKU].Text))
                        {
                            seiKingaku = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEI_KINGAKU].Text);
                        }

                        // 消費税.
                        if (!String.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_ZEI_GAKU].Text))
                        {
                            zeiGaku = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_ZEI_GAKU].Text);
                        }

                        // 金額（税込み）.
                        _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_ZEI_NKINGAKU].Text = ( seiKingaku - zeiGaku ).ToString("###,###,###,##0");
                    }

                    break;
            }

            CalculateGoukei();

            // 広告費明細変更フラグを更新 
            base.kkhDetailUpdFlag = true;
        }
        #endregion スプレッドチェンジ.

        #region タブインデックスチェンジ.
        /// <summary>
        /// タブインデックスチェンジ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabHed_SelectedIndexChangedEpson(object sender, EventArgs e)
        {
            if (isActivatedJyutyuList() && ( ( _previousTabIndex == 0 ) || ( _previousTabIndex == 1 ) ))
            {
                _previousTabIndex = tabHed.SelectedIndex;

                return;
            }

            // 明細カラムの表示切替.
            if (isActivatedJyutyuList() )
            {
                ControlDetailSpreadColmunVisible();
            }
            else if (isActivatedSeikyuList())
            {
                ControlSeikyuDetailSpreadColmunVisible();
            }

            if (_notSearchState == false)
            {
                // 明細の再取得.
                if (( _dsDetail.JyutyuList.Rows.Count != 0 ) || ( _dsSeikyuEpson.SeikyuHeader.Rows.Count != 0 ))
                {
                    ShowLoadingDialog();

                    DisplayDetail();

                    CloseLoadingDialog();
                }
            }
            else
            {
                // スプレッドにタブに対応した明細データを設定する.
                if (isActivatedJyutyuList())
                {
                    _bsKkhDetail.DataSource = _dsDetailEpson;
                    _bsKkhDetail.DataMember = _dsDetailEpson.KkhDetail.TableName;
                    _bsKkhDetail.EndEdit();

                    _dsDetailEpson.AcceptChanges();
                }
                else if (isActivatedSeikyuList())
                {
                    _bsKkhDetail.DataSource = _dsSeikyuDetailEpson;
                    _bsKkhDetail.DataMember = _dsSeikyuDetailEpson.KkhDetail.TableName;
                    _bsKkhDetail.EndEdit();

                    _dsSeikyuDetailEpson.AcceptChanges();
                }
            }

            // 受注リスト.
            if (isActivatedJyutyuList())
            {
                // 件数の表示.
                lblJyutyuListCnt.Text = _bsJyutyuList.Count + "件";

                lblJyutyuDown.Visible = true;
                lblJyutyuDownValue.Visible = true;

                lblJyutyuDown2.Visible = true;
                lblJyutyuDownValue2.Visible = true;

                lblJyutyuMeisai.Visible = true;
                lblJyutyuMeisaiValue.Visible = true;

                lblSeikyuDown.Visible = false;
                lblSeikyuDownValue.Visible = false;

                lblSeikyuDown2.Visible = false;
                lblSeikyuDownValue2.Visible = false;

                lblSeikyuMeisai.Visible = false;
                lblSeikyuMeisaiValue.Visible = false;
            }
            // 請求回収.
            else if (isActivatedSeikyuList())
            {
                // 件数の表示.
                lblJyutyuListCnt.Visible = true;
                lblJyutyuListCnt.Text = _bsSeikyuList.Count + "件";

                lblSeikyuDown.Visible = true;
                lblSeikyuDownValue.Visible = true;

                lblSeikyuDown2.Visible = true;
                lblSeikyuDownValue2.Visible = true;

                lblSeikyuMeisai.Visible = true;
                lblSeikyuMeisaiValue.Visible = true;

                lblJyutyuDown.Visible = false;
                lblJyutyuDownValue.Visible = false;

                lblJyutyuDown2.Visible = false;
                lblJyutyuDownValue2.Visible = false;

                lblJyutyuMeisai.Visible = false;
                lblJyutyuMeisaiValue.Visible = false;
            }

            // ボタン制御.
            SetButtonEnable();

            // インデックスの保存.
            _previousTabIndex = tabHed.SelectedIndex;

            // データをクリアしたため明細変更フラグをオフにする.
            kkhDetailUpdFlag = false;
        }
        #endregion タブインデックスチェンジ.

        #region タブが変更されようとしている.
        /// <summary>
        /// タブが変更されようとしている.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabHed_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // 受注タブと請求回収タブを入れ替える時.
            if (!( isActivatedJyutyuList() && ( ( _previousTabIndex == 0 ) || ( _previousTabIndex == 1 ) ) ))
            {
                if (ConfirmEditStatus() == false)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
        #endregion タブが変更されようとしている.

        #region ヘルプボタン押下.
        /// <summary>
        /// ヘルプボタン押下 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //得意先コード 
            string tkskgy = _naviParameter.strTksKgyCd + _naviParameter.strTksBmnSeqNo + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //実行 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Detail, this, HelpNavigator.KeywordIndex);
            //HlpClick();
            this.ActiveControl = null;
        }
        #endregion ヘルプボタン押下.
        #endregion イベント.

        #region メソッド.
        #region 明細データ表示.
        /// <summary>
        /// 明細データ表示.
        /// </summary>
        private void DisplayDetail()
        {
            //データ取得処理は独自で実装.
            ////親クラスの行っている共通処理を実行 
            //base.DisplayKkhDetail(rowIdx);

            //広告費明細の初期化 
            _dsDetailEpson.DetailDataEpson.Clear();

            //変更中フラグを戻す 
            kkhDetailUpdFlag = false;

            {
                // 広告費用明細の検索.
                DetailDSEpson dt = new DetailDSEpson();

                SearchDetailEpson(dt, "1");

                _dsDetailEpson.Clear();
                _dsDetailEpson.Merge(dt);
                _dsDetailEpson.AcceptChanges();
            }

            {
                // 請求回収用明細の検索.
                DetailDSEpson dt = new DetailDSEpson();

                SearchDetailEpson(dt, "2");

                _dsSeikyuDetailEpson.Clear();
                _dsSeikyuDetailEpson.Merge(dt);
                _dsSeikyuDetailEpson.AcceptChanges();
            }

            if (isActivatedJyutyuList())
            {
                _bsKkhDetail.DataSource = _dsDetailEpson;
                _bsKkhDetail.DataMember = _dsDetailEpson.KkhDetail.TableName;
                _bsKkhDetail.EndEdit();

                _dsDetailEpson.AcceptChanges();
            }
            else if (isActivatedSeikyuList())
            {
                _bsKkhDetail.DataSource = _dsSeikyuDetailEpson;
                _bsKkhDetail.DataMember = _dsSeikyuDetailEpson.KkhDetail.TableName;
                _bsKkhDetail.EndEdit();

                _dsSeikyuDetailEpson.AcceptChanges();
            }

            //***************************************
            //ボタン類の使用可・不可設定 
            //***************************************
            SetButtonEnable();

            //******************************
            //合計ラベル 
            //******************************
            CalculateGoukei();

            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(0, 0, 1, 1);
            }
        }
        #endregion 明細データ表示.

        #region 明細データの検索.
        /// <summary>
        /// 明細データの検索.
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="kbn"></param>
        private void SearchDetailEpson(DetailDSEpson ds, String kbn)
        {
            DetailEpsonProcessController.FindDetailDataEpsonByCondParam param = new DetailEpsonProcessController.FindDetailDataEpsonByCondParam();

            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = txtYmd.Value;
            param.kbn = kbn;

            DetailEpsonProcessController controller = DetailEpsonProcessController.GetInstance();

            FindDetailDataEpsonByCondServiceResult result = controller.FindDetailDataEpsonByCond(param);

            if (result.HasError == true)
            {
                return;
            }

            ds.DetailDataEpson.Clear();
            ds.DetailDataEpson.Merge(result.DetailEpsonDataSet.DetailDataEpson);
            ds.DetailDataEpson.AcceptChanges();

            // スプレッド表示用データの設定.
            ds.KkhDetail.Clear();

            foreach (Isid.KKH.Epson.Schema.DetailDSEpson.DetailDataEpsonRow row in ds.DetailDataEpson.Rows)
            {
                Isid.KKH.Epson.Schema.DetailDSEpson.KkhDetailRow addRow = ds.KkhDetail.NewKkhDetailRow();

                // 広告費用明細.
                if (String.Equals(kbn, "1"))
                {
                    if (row.hb2Kbn1 == "1")
                    {
                        addRow.seiFlg = "True";
                    }
                    else
                    {
                        addRow.seiFlg = "False";
                    }

                    if (row.hb2Sonota1.Length == 12)
                    {
                        addRow.seiNo = row.hb2Sonota1.Substring(0, 8) + "-" + row.hb2Sonota1.Substring(8, 4);
                    }
                    else
                    {
                        addRow.seiNo = row.hb2Sonota1;
                    }

                    addRow.uriMeiNo         = row.hb2JyutNo + "-" + row.hb2JyMeiNo + "-" + row.hb2UrMeiNo;
                    // 2015/04/06 エプソン件名拡張対応 Fujisaki Cng Start 
                    //addRow.koukokuKenmei    = row.hb2Name8;
                    addRow.koukokuKenmei = row.hb2Name11;
                    // 2015/04/06 エプソン件名拡張対応 Fujisaki Cng End 
                    addRow.kenmei           = row.hb2Name10;
                    addRow.seiKenmei        = String.Empty;
                    addRow.triTntCd         = row.hb2Code3;
                    addRow.triSikiKeyCd     = row.hb2Code5;
                    addRow.baitaiCd = row.hb2Code1;
                    addRow.seiKbn = row.hb2Code2;
                    addRow.triTntNm         = row.hb2Name3;
                    addRow.triSikiCd        = row.hb2Code4;
                    addRow.triSikiNm        = row.hb2Name4;
                    addRow.ssNo             = row.hb2Name5;
                    addRow.segNo            = row.hb2Name6;
                    addRow.sortKey          = row.hb2Name7;
                    addRow.afKngk           = row.hb2SeiGak;
                    addRow.bfKngk           = row.hb2Kngk2;
                    addRow.seiKingaku       = 0M;
                    addRow.zeiGaku          = row.hb2Kngk1;
                    addRow.zeiNKingaku      = 0M;

                    if (row.hb2Date1.Length == 8)
                    {
                        addRow.keizyoBi = row.hb2Date1.Substring(0, 4) + "/" + row.hb2Date1.Substring(4, 2) + "/" + row.hb2Date1.Substring(6, 2);
                    }
                    else
                    {
                        addRow.keizyoBi = row.hb2Date1;
                    }
                }
                // 請求回収用明細.
                else if (String.Equals(kbn, "2"))
                {
                    if (row.hb2Kbn1 == "1")
                    {
                        addRow.seiFlg = "True";
                    }
                    else
                    {
                        addRow.seiFlg = "False";
                    }

                    if (row.hb2Sonota1.Length == 12)
                    {
                        addRow.seiNo = row.hb2Sonota1.Substring(0, 8) + "-" + row.hb2Sonota1.Substring(8, 4);
                    }
                    else
                    {
                        addRow.seiNo = row.hb2Sonota1;
                    }

                    addRow.uriMeiNo         = row.hb2JyutNo + "-" + row.hb2JyMeiNo + "-" + row.hb2UrMeiNo;
                    addRow.koukokuKenmei    = String.Empty;
                    addRow.kenmei           = String.Empty;
                    // 2015/04/06 エプソン件名拡張対応 Fujisaki Cng Start 
                    //addRow.seiKenmei        = row.hb2Name8;
                    addRow.seiKenmei = row.hb2Name11;
                    // 2015/04/06 エプソン件名拡張対応 Fujisaki Cng End 
                    addRow.triTntCd         = row.hb2Code3;
                    addRow.triSikiKeyCd     = row.hb2Code5;
                    /* 2017/04/04 エプソン仕入先変更対応 ITCOM A.Nakamura  ADD Start */
                    addRow.kihyouBmnCd      = row.hb2Sonota2;
                    addRow.genkaCenter      = row.hb2Sonota3;
                    /* 2017/04/04 エプソン仕入先変更対応 ITCOM A.Nakamura  ADD End */
                    addRow.afKngk           = 0M;
                    addRow.bfKngk           = 0M;
                    addRow.baitaiCd = row.hb2Code1;
                    addRow.seiKbn = row.hb2Code2;
                    addRow.triTntNm = row.hb2Name3;
                    addRow.triSikiCd        = row.hb2Code4;
                    addRow.triSikiNm        = row.hb2Name4;
                    addRow.ssNo             = row.hb2Name5;
                    addRow.segNo            = row.hb2Name6;
                    addRow.sortKey          = row.hb2Name7;
                    addRow.seiKingaku       = row.hb2SeiGak + row.hb2Kngk1;
                    addRow.zeiGaku          = row.hb2Kngk1;
                    addRow.zeiNKingaku      = row.hb2SeiGak;

                    if (row.hb2Date1.Length == 8)
                    {
                        addRow.keizyoBi = row.hb2Date1.Substring(0, 4) + "/" + row.hb2Date1.Substring(4, 2) + "/" + row.hb2Date1.Substring(6, 2);
                    }
                    else
                    {
                        addRow.keizyoBi = row.hb2Date1;
                    }
                }

                ds.KkhDetail.AddKkhDetailRow(addRow);
            }

            ds.KkhDetail.AcceptChanges();

            ds.AcceptChanges();
        }
        #endregion 明細データの検索.

        #region 合計計算.
        /// <summary>
        /// 合計計算.
        /// </summary>
        private void CalculateGoukei()
        {
            // 料金合計 
            Decimal jyutyuDownGoukei = 0;
            Decimal jyutyuDownGoukei2 = 0;
            Decimal jyutyuMeisaiGoukei = 0;
            Decimal seikyuDownGoukei = 0;
            Decimal seikyuDownGoukei2 = 0;
            Decimal seikyuMeisaiGoukei = 0;

            // 受注データの件数分、繰り返す.
            for (int i = 0; i < _spdJyutyuList_Sheet1.RowCount; i++)
            {
                String ryoukinStr = _spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_SEIKINGAKU].Text.Trim();

                // 料金が入力されている場合 
                if (KKHUtility.IsNumeric(ryoukinStr))
                {
                    // 料金合計に加算 
                    jyutyuDownGoukei = jyutyuDownGoukei + KKHUtility.DecParse(ryoukinStr.Trim());
                }
            }

            // 受注データの件数分、繰り返す.
            for (int i = 0; i < _spdJyutyuList_Sheet1.RowCount; i++)
            {
                if (String.IsNullOrEmpty(_spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_TOROKU].Text.Trim()))
                {
                    continue;
                }

                String ryoukinStr = _spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_SEIKINGAKU].Text.Trim();

                // 料金が入力されている場合 
                if (KKHUtility.IsNumeric(ryoukinStr))
                {
                    // 料金合計に加算 
                    jyutyuDownGoukei2 = jyutyuDownGoukei2 + KKHUtility.DecParse(ryoukinStr.Trim());
                }
            }

            // 受注明細データの件数分、繰り返す 
            foreach (DetailDSEpson.KkhDetailRow row in _dsDetailEpson.KkhDetail.Rows)
            {
                // 料金合計に加算 
                jyutyuMeisaiGoukei = jyutyuMeisaiGoukei + row.afKngk;
            }

            // 請求データの件数分、繰り返す.
            for (int i = 0; i < _spdSeikyuList_Sheet1.RowCount; i++)
            {
                String ryoukinStr = _spdSeikyuList_Sheet1.Cells[i, COLIDX_SHLIST_ZEINKINGAKUGK].Text.Trim();

                // 料金が入力されている場合 
                if (KKHUtility.IsNumeric(ryoukinStr))
                {
                    // 料金合計に加算 
                    seikyuDownGoukei = seikyuDownGoukei + KKHUtility.DecParse(ryoukinStr.Trim());
                }
            }

            // 請求データの件数分、繰り返す.
            for (int i = 0; i < _spdSeikyuList_Sheet1.RowCount; i++)
            {
                if (String.IsNullOrEmpty(_spdSeikyuList_Sheet1.Cells[i, COLIDX_SHLIST_HANNEI].Text.Trim()))
                {
                    continue;
                }

                String ryoukinStr = _spdSeikyuList_Sheet1.Cells[i, COLIDX_SHLIST_ZEINKINGAKUGK].Text.Trim();

                // 料金が入力されている場合 
                if (KKHUtility.IsNumeric(ryoukinStr))
                {
                    // 料金合計に加算 
                    seikyuDownGoukei2 = seikyuDownGoukei2 + KKHUtility.DecParse(ryoukinStr.Trim());
                }
            }

            // 請求明細データの件数分、繰り返す.
            foreach (DetailDSEpson.KkhDetailRow row in _dsSeikyuDetailEpson.KkhDetail.Rows)
            {
                // 料金合計に加算 
                seikyuMeisaiGoukei = seikyuMeisaiGoukei + row.zeiNKingaku;
            }

            // 受注合計.
            lblJyutyuDownValue.Text = jyutyuDownGoukei.ToString("###,###,###,##0");

            // 受注合計（登録済）.
            lblJyutyuDownValue2.Text = jyutyuDownGoukei2.ToString("###,###,###,##0");

            // 受注明細合計.
            lblJyutyuMeisaiValue.Text = jyutyuMeisaiGoukei.ToString("###,###,###,##0");

            // 請求合計.
            lblSeikyuDownValue.Text = seikyuDownGoukei.ToString("###,###,###,##0");

            // 請求合計（登録済）.
            lblSeikyuDownValue2.Text = seikyuDownGoukei2.ToString("###,###,###,##0");

            // 請求明細合計 
            lblSeikyuMeisaiValue.Text = seikyuMeisaiGoukei.ToString("###,###,###,##0");
        }
        #endregion 合計計算.

        #region 広告費明細のデータソース更新.
        /// <summary>
        /// 広告費明細のデータソース更新.
        /// </summary>
        /// <param name="dsDetailEpson"></param>
        private void UpdateDataSourceByDetailDataSetEpson(DetailDSEpson dsDetailEpson)
        {
            _dsDetailEpson.Clear();
            _dsDetailEpson.Merge(_dsDetailEpson);
            _dsDetailEpson.AcceptChanges();
        }
        #endregion 広告費明細のデータソース更新.

        #region データソースのバインド.
        /// <summary>
        /// データソースのバインド 
        /// </summary>
        private void InitializeDataSourceEpson()
        {
            //_bsJyutyuList
            _bsKkhDetail.DataSource = _dsDetailEpson;
            _bsKkhDetail.DataMember = _dsDetailEpson.KkhDetail.TableName;
            _bsKkhDetail.EndEdit();
        }
        #endregion データソースのバインド.

        #region 継承元フォームで使用しているプロパティ等の初期値設定.
        /// <summary>
        /// 継承元フォームで使用しているプロパティ等の初期値設定.
        /// </summary>
        private void InitializeCommonProperty()
        {
        }
        #endregion 継承元フォームで使用しているプロパティ等の初期値設定.

        #region 各コントロールの初期設定.
        /// <summary>
        /// 各コントロールの初期設定.
        /// </summary>
        private void InitializeControlEpson()
        {
            //********************
            //マスタ情報を取得する 
            //********************
            GetMasterData();

            _master = new KkhMasterUtilityEpson();

            _master.GetMasterData(_naviParameter);

            //******************
            //検索条件部 
            //******************
            lblKenMei.Visible = false;
            txtKenMei.Visible = false;
            lblKikan.Visible = false;
            txtYmdTo.Visible = false;

            //*******************
            //ボタン類.
            //*******************
            btnRegister.Enabled = false;
            btnRegBulk.Enabled = false;
            btnReqBind.Enabled = false;
            btnBulkMerge.Enabled = false;
            btnMerge.Enabled = false;
            btnMergeCancel.Enabled = false;
            btnDetailInput.Enabled = false;
            btnDetailDel.Enabled = false;
            btnDetailRegister.Enabled = false;
        }
        #endregion 各コントロールの初期設定.

        #region 広告費明細スプレッドのデザイン初期化を行う.
        /// <summary>
        /// 広告費明細スプレッドのデザイン初期化を行う.
        /// </summary>
        private void InitializeDesignForSpdKkhDetail()
        {
            //********************************
            //列毎の設定 ※デザイナから列に対する設定を行うと変更が反映されないことがあるようなので暫定的にここで行う 
            //********************************

            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                //共通設定 
                col.AllowAutoFilter = true;//フィルタ機能を有効 
                col.AllowAutoSort = true;  //ソート機能を有効 

                //列毎に異なる設定 
                if (col.Index == COLIDX_MLIST_SEIFLG)
                {
                    CheckBoxCellType cellType = new CheckBoxCellType();

                    //

                    col.CellType            = cellType;
                    col.DataField           = "seiFlg";
                    col.Label               = "請求対象外";
                    col.Width               = 80;
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_SEINO)
                {
                    TextCellType cellType = new TextCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    cellType.MaxLength = 15;
                    cellType.CharacterSet = CharacterSet.AlphaNumeric;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "seiNo";
                    col.Label       = "請求書番号";
                    col.Locked      = true;
                    col.Width       = 120;
                }
                else if (col.Index == COLIDX_MLIST_URIMEINO)
                {
                    TextCellType cellType = new TextCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    cellType.MaxLength = 18;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "uriMeiNo";
                    col.Label       = "売上明細ＮＯ";
                    col.Locked      = true;
                    col.Width       = 130;
                }
                else if (col.Index == COLIDX_MLIST_KOUKOKUKENMEI)
                {
                    TextCellType cellType = new TextCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    cellType.MaxLength = 60;
                    cellType.CharacterSet = CharacterSet.AllIME;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "koukokuKenmei";
                    col.Label       = "広告件名";
                    col.Width       = 200;
                }
                else if (col.Index == COLIDX_MLIST_TRITNTCD)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData = _triTntKey;
                    type.Items = _triTntValue;
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;

                    //

                    col.CellType    = type;
                    col.DataField   = "triTntCd";
                    col.Label       = "ご担当";
                    col.Width       = 80;
                }
                else if (col.Index == COLIDX_MLIST_KENMEI)
                {
                    TextCellType cellType = new TextCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    cellType.MaxLength = 120;
                    cellType.CharacterSet = CharacterSet.AllIME;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "kenmei";
                    col.Label       = "件名";
                    col.Width       = 200;
                }
                else if (col.Index == COLIDX_MLIST_SEI_KENMEI)
                {
                    TextCellType cellType = new TextCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    cellType.MaxLength = 120;
                    cellType.CharacterSet = CharacterSet.AllIME;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "seiKenmei";
                    col.Label       = "請求件名";
                    col.Width       = 300;
                }
                else if (col.Index == COLIDX_MLIST_TRISIKIKEYCD)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData = _triSikiKey;
                    type.Items = _triSikiValue;
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;

                    //

                    col.CellType    = type;
                    col.DataField   = "triSikiKeyCd";
                    col.Label       = "取引識別名";
                    col.Width       = 200;
                }
                /* 2017/04/14 エプソン仕入先変更対応　ITCOM A.Nakamura ADD Start */
                 else if (col.Index == COLIDX_MLIST_KIHYOUBMNCD)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData = _kihyouBmnCdKey;
                    type.Items = _kihyouBmnCdValue;
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;

                    //

                    col.CellType    = type;
                    col.DataField   = DFKIHYOUBMNCD;
                    col.Label       = LKIHYOUBMNCD;
                    col.Width       = 100;
                }
                 else if (col.Index == COLIDX_MLIST_GENKACENTER)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData         = _genkaCenterKey;
                    type.Items            = _genkaCenterValue;
                    type.EditorValue      = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable         = false;

                    //

                    col.CellType    = type;
                    col.DataField   = DFGENKACENTER;
                    col.Label       = LGENKACENTER;
                    col.Width       = 100;
                }
                /* 2017/04/14 エプソン仕入先変更対応　ITCOM A.Nakamura  ADD End */
                else if (col.Index == COLIDX_MLIST_GYMKBN)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "baitaiCd";
                    col.Label       = "業務区分";
                    col.Locked      = true;
                }
                else if (col.Index == COLIDX_MLIST_SEIKBN)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "seiKbn";
                    col.Label       = "請求区分";
                    col.Locked      = true;
                }
                else if (col.Index == COLIDX_MLIST_TRITNTNM)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "triTntNm";
                    col.Label       = "取引担当者名";
                    col.Locked      = true;
                }
                else if (col.Index == COLIDX_MLIST_TRISIKICD)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "triSikiCd";
                    col.Label       = "取引識別コード";
                    col.Locked      = true;
                }
                else if (col.Index == COLIDX_MLIST_TRISIKINM)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "triSikiNm";
                    col.Label       = "取引識別名";
                    col.Locked      = true;
                }
                else if (col.Index == COLIDX_MLIST_SEGNO)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "ssNo";
                    col.Label       = "指図ＮＯ";
                    col.Locked      = true;
                }
                /* 2017/04/04 エプソン仕入先変更対応　ITCOM A.Nakamura  ADD Start */
                else if (col.Index == COLIDX_MLIST_KIHYOUBMNCD)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType = cellType;
                    col.DataField = DFKIHYOUBMNCD;
                    col.Label = LKIHYOUBMNCD;
                    col.Locked = true;
                    col.Width = 100;
                }
                else if (col.Index == COLIDX_MLIST_GENKACENTER)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType = cellType;
                    col.DataField = DFGENKACENTER;
                    col.Label = LGENKACENTER;
                    col.Locked = true;
                    col.Width = 100;
                }
                /* 2017/04/04 エプソン仕入先変更対応　ITCOM A.Nakamura  ADD End */
                else if (col.Index == COLIDX_MLIST_SSNO)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "segNo";
                    col.Label       = "セグメントＮＯ";
                    col.Locked      = true;
                }
                else if (col.Index == COLIDX_MLIST_SORT_KEY)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "sortKey";
                    col.Label       = "ソートキー";
                    col.Locked      = true;
                }
                else if (col.Index == COLIDX_MLIST_BFKNGK)
                {
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAKU;
                    cellType.MinimumValue = MIN_VALUE_KINGAKU;
                    cellType.NullDisplay = DEF_VALUE_KINGAKU;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "bfKngk";
                    col.Label       = "事前金額";
                    col.Width       = 100;
                }
                else if (col.Index == COLIDX_MLIST_AFKNGK)
                {
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAKU;
                    cellType.MinimumValue = MIN_VALUE_KINGAKU;
                    cellType.NullDisplay = DEF_VALUE_KINGAKU;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "afKngk";
                    col.Label       = "事後金額";
                    col.Width       = 100;
                }
                else if (col.Index == COLIDX_MLIST_SEI_KINGAKU)
                {
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAKU;
                    cellType.MinimumValue = MIN_VALUE_KINGAKU;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "seiKingaku";
                    col.Label       = "金額（税込み）";
                    col.Width       = 120;
                }
                else if (col.Index == COLIDX_MLIST_ZEI_GAKU)
                {
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAKU;
                    cellType.MinimumValue = MIN_VALUE_KINGAKU;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "zeiGaku";
                    col.Label       = "税額";
                    col.Width       = 120;
                }
                else if (col.Index == COLIDX_MLIST_ZEI_NKINGAKU)
                {
                    NumberCellType cellType = new NumberCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAKU;
                    cellType.MinimumValue = MIN_VALUE_KINGAKU;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "zeiNKingaku";
                    col.Label       = "税抜き金額";
                    col.Locked      = true;
                    col.Width       = 120;
                }
                else if( col.Index ==COLIDX_MLIST_KEIZYOUBI)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "keizyoBi";
                    col.Label       = "計上日";
                    col.Width       = 120;
                }
            }

            if (isActivatedJyutyuList())
            {
                ControlDetailSpreadColmunVisible();
            }
            else if (isActivatedSeikyuList())
            {
                ControlSeikyuDetailSpreadColmunVisible();
            }

            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(0, 0, 1, 1);
            }
        }
        #endregion 広告費明細スプレッドのデザイン初期化を行う.

        #region 広告費用明細のカラム表示切替.
        /// <summary>
        /// 広告費用明細のカラム表示切替.
        /// </summary>
        private void ControlDetailSpreadColmunVisible()
        {
            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                if (col.Index == COLIDX_MLIST_SEIFLG        ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_SEINO         ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_URIMEINO      ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_KOUKOKUKENMEI ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_TRITNTCD      ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_KENMEI        ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_SEI_KENMEI    ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_TRISIKIKEYCD  ) { col.Visible = true;  }
                /* 2017/04/14 エプソン仕入先変更対応　ITCOM A.Nakamura  ADD Start */
                if (col.Index == COLIDX_MLIST_KIHYOUBMNCD   ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_GENKACENTER   ) { col.Visible = false; }
                /* 2017/04/14 エプソン仕入先変更対応　ITCOM A.Nakamura  ADD End */
                if (col.Index == COLIDX_MLIST_BFKNGK        ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_AFKNGK        ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_GYMKBN        ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SEIKBN        ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_TRITNTNM      ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_TRISIKICD     ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_TRISIKINM     ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SSNO          ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SEGNO         ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SORT_KEY      ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SEI_KINGAKU   ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_ZEI_GAKU      ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_ZEI_NKINGAKU  ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_KEIZYOUBI     ) { col.Visible = false; }
            }
        }
        #endregion 広告費用明細のカラム表示切替.

        #region 請求回収用明細のカラム表示切替.
        /// <summary>
        /// 請求回収用明細のカラム表示切替.
        /// </summary>
        private void ControlSeikyuDetailSpreadColmunVisible()
        {
            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                if (col.Index == COLIDX_MLIST_SEIFLG        ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_SEINO         ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_URIMEINO      ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_KOUKOKUKENMEI ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_TRITNTCD      ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_KENMEI        ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SEI_KENMEI    ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_TRISIKIKEYCD  ) { col.Visible = true;  }
                /* 2017/04/14 エプソン仕入先変更対応　ITCOM A.Nakamura  ADD Start */
                if (col.Index == COLIDX_MLIST_KIHYOUBMNCD   ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_GENKACENTER   ) { col.Visible = true;  }
                /* 2017/04/14 エプソン仕入先変更対応　ITCOM A.Nakamura  ADD End */
                if (col.Index == COLIDX_MLIST_BFKNGK        ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_AFKNGK        ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_GYMKBN        ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SEIKBN        ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_TRITNTNM      ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_TRISIKICD     ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_TRISIKINM     ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SSNO          ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SEGNO         ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SORT_KEY      ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SEI_KINGAKU   ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_ZEI_GAKU      ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_ZEI_NKINGAKU  ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_KEIZYOUBI     ) { col.Visible = true;  }
            }
        }
        #endregion 請求回収用明細のカラム表示切替.

        #region 明細登録処理.
        /// <summary>
        /// 明細登録処理.
        /// </summary>
        private void RegistDetailData()
        {
            // ダイアログの表示.
            base.ShowLoadingDialog();

            // 更新用データセット.
            List<Isid.KKH.Common.KKHSchema.Detail> dsDetailList = new List<Isid.KKH.Common.KKHSchema.Detail>();

            // 年月.
            String Yymm = txtYmd.Value;

            // 最大更新時間.
            DateTime maxUpdDate = DateTime.MinValue;

            // 受注リスト検索用.
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable jyutyuList = new Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable();

            // 受注データ更新用ワーク.
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtTHB1DOWNWork = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();

            // 明細データ更新用ワーク.
            Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable dtTHB2KMEIWork = new Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable();

            {
                // 受注リスト検索用 
                for (int i = 0; i < _spdJyutyuList_Sheet1.RowCount; i++)
                {
                    Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow jyutyuRow = getSelectJyutyuData(i);

                    jyutyuList.ImportRow(jyutyuRow);
                }
            }

            {
                // 受注データ更新 
                for (int i = 0; i < _spdJyutyuList_Sheet1.RowCount; i++)
                {
                    Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow jyutyuRow = getSelectJyutyuData(i);

                    Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow addRow = dtTHB1DOWNWork.NewTHB1DOWNRow();

                    //更新条件項目 
                    addRow.hb1EgCd          = _naviParameter.strEgcd;        //営業所（取）コード 
                    addRow.hb1TksKgyCd      = _naviParameter.strTksKgyCd;    //得意先企業コード 
                    addRow.hb1TksBmnSeqNo   = _naviParameter.strTksBmnSeqNo; //得意先部門SEQNO 
                    addRow.hb1TksTntSeqNo   = _naviParameter.strTksTntSeqNo; //得意先担当SEQNO
                    addRow.hb1Yymm          = Yymm;                          //年月 
                    addRow.hb1JyutNo        = jyutyuRow.hb1JyutNo;           //受注No 
                    addRow.hb1JyMeiNo       = jyutyuRow.hb1JyMeiNo;          //受注明細No 
                    addRow.hb1UrMeiNo       = jyutyuRow.hb1UrMeiNo;          //売上明細No 
                    addRow.hb1TouFlg        = jyutyuRow.hb1TouFlg;
                    addRow.hb1UpdApl        = AplId;                         //更新プログラム 
                    addRow.hb1UpdTnt        = _naviParameter.strEsqId;       //更新担当者.

                    dtTHB1DOWNWork.AddTHB1DOWNRow(addRow);
                }
            }

            {
                // 広告費用明細更新 
                for (int i = 0; i < _dsDetailEpson.KkhDetail.Rows.Count; i++)
                {
                    DetailDSEpson.KkhDetailRow tempRow = _dsDetailEpson.KkhDetail.NewKkhDetailRow();

                    DBNullToEmptyOrZero(tempRow, (DetailDSEpson.KkhDetailRow)_dsDetailEpson.KkhDetail.Rows[i]);

                    String JyutNo = String.Empty;
                    String JyMeiNo = String.Empty;
                    String UrMeiNo = String.Empty;

                    {
                        // キーの分解 
                        string[] keys = new string[] { "0", "0", "0" };

                        keys = tempRow.uriMeiNo.Split('-');

                        // 受注番号 
                        JyutNo = keys[0];

                        // 受注明細番号 
                        JyMeiNo = keys[1];

                        // 売上明細番号 
                        UrMeiNo = keys[2];
                    }

                    Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] jyutyuRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[])jyutyuList.Select("hb1JyutNo = '" + JyutNo + "' and hb1JyMeiNo = '" + JyMeiNo + "' and hb1UrMeiNo = '" + UrMeiNo + "'");

                    Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow addRow = dtTHB2KMEIWork.NewTHB2KMEIRow();

                    addRow.hb2TimStmp       = new DateTime();                   //タイムスタンプ 
                    addRow.hb2UpdApl        = AplId;                            //更新プログラム 
                    addRow.hb2UpdTnt        = _naviParameter.strEsqId;          //更新担当者 
                    addRow.hb2EgCd          = _naviParameter.strEgcd;           //営業所コード 
                    addRow.hb2TksKgyCd      = _naviParameter.strTksKgyCd;       //得意先企業コード 
                    addRow.hb2TksBmnSeqNo   = _naviParameter.strTksBmnSeqNo;    //得意先部門SEQNO 
                    addRow.hb2TksTntSeqNo   = _naviParameter.strTksTntSeqNo;    //得意先担当SEQNO 
                    addRow.hb2Yymm          = Yymm;                             //年月 
                    addRow.hb2JyutNo        = jyutyuRow[0].hb1JyutNo;           //受注No 
                    addRow.hb2JyMeiNo       = jyutyuRow[0].hb1JyMeiNo;          //受注明細No 
                    addRow.hb2UrMeiNo       = jyutyuRow[0].hb1UrMeiNo;          //売上明細No 
                    addRow.hb2HimkCd        = jyutyuRow[0].hb1HimkCd;           //費目コード 
                    //addRow.hb2Renbn         = "001";                            //連番 明細登録件数拡張対応.
                    addRow.hb2Renbn = "0001";                                   //連番.
                    addRow.hb2DateFrom      = " ";                              //年月日From 
                    addRow.hb2DateTo        = " ";                              //年月日To 
                    addRow.hb2SeiGak        = (Decimal)tempRow.afKngk;          //請求金額(=事後金額) 
                    addRow.hb2Hnnert        = 0M;                               //変更値引率 
                    addRow.hb2HnmaeGak      = 0M;                               //値引率変更前金額 
                    addRow.hb2NebiGak       = 0M;                               //値引額 

                    //日付1(計上日)
                    if (string.IsNullOrEmpty(tempRow.keizyoBi))
                    {
                        addRow.hb2Date1 = " ";
                    }
                    else
                    {
                        // /を削除する.
                        addRow.hb2Date1 = tempRow.keizyoBi.Replace("/", "");
                    }

                    addRow.hb2Date2 = " ";  //日付2 
                    addRow.hb2Date3 = " ";  //日付3 
                    addRow.hb2Date4 = " ";  //日付4 
                    addRow.hb2Date5 = " ";  //日付5 
                    addRow.hb2Date6 = " ";  //日付6 

                    //区分1(=請求対象外フラグ)
                    if (bool.Parse(tempRow.seiFlg))
                    {
                        addRow.hb2Kbn1 = "1";
                    }
                    else
                    {
                        addRow.hb2Kbn1 = "0";
                    }

                    addRow.hb2Kbn2 = " ";   //区分2 
                    addRow.hb2Kbn3 = " ";   //区分3 

                    //コード1(=業務区分) 
                    if (string.IsNullOrEmpty(tempRow.baitaiCd))
                    {
                        addRow.hb2Code1 = " ";
                    }
                    else
                    {
                        addRow.hb2Code1 = tempRow.baitaiCd;
                    }

                    //コード2(=請求区分) 
                    if (string.IsNullOrEmpty(tempRow.seiKbn))
                    {
                        addRow.hb2Code2 = " ";
                    }
                    else
                    {
                        addRow.hb2Code2 = tempRow.seiKbn;
                    }

                    //コード3(=取引担当者コード) 
                    if (string.IsNullOrEmpty(tempRow.triTntCd))
                    {
                        addRow.hb2Code3 = " ";
                    }
                    else
                    {
                        addRow.hb2Code3 = tempRow.triTntCd;
                    }

                    //コード4(=取引識別コード) 
                    if (string.IsNullOrEmpty(tempRow.triSikiCd))
                    {
                        addRow.hb2Code4 = " ";
                    }
                    else
                    {
                        addRow.hb2Code4 = tempRow.triSikiCd;
                    }

                    //コード5（=取引識別キーコード）.
                    if (string.IsNullOrEmpty(tempRow.triSikiKeyCd))
                    {
                        addRow.hb2Code5 = " ";
                    }
                    else
                    {
                        addRow.hb2Code5 = tempRow.triSikiKeyCd;
                    }

                    addRow.hb2Code6 = " ";  //コード6
                    addRow.hb2Name1 = " ";  //名称1(漢字)
                    addRow.hb2Name2 = " ";  //名称2(漢字) 

                    //名称3(漢字)(=取引担当者名称) 
                    if (string.IsNullOrEmpty(tempRow.triTntNm))
                    {
                        addRow.hb2Name3 = " ";
                    }
                    else
                    {
                        addRow.hb2Name3 = tempRow.triTntNm;
                    }

                    //名称4(漢字)(=取引識別名称) 
                    if (string.IsNullOrEmpty(tempRow.triSikiNm.Trim()))
                    {
                        addRow.hb2Name4 = " ";
                    }
                    else
                    {
                        addRow.hb2Name4 = tempRow.triSikiNm;
                    }

                    //名称5(漢字)(=指図ＮＯ)  
                    if (string.IsNullOrEmpty(tempRow.ssNo))
                    {
                        addRow.hb2Name5 = " ";
                    }
                    else
                    {
                        addRow.hb2Name5 = tempRow.ssNo;
                    }

                    //名称6(漢字)(=セグメントＮＯ) 
                    if (string.IsNullOrEmpty(tempRow.segNo))
                    {
                        addRow.hb2Name6 = " ";
                    }
                    else
                    {
                        addRow.hb2Name6 = tempRow.segNo;
                    }

                    //名称7(漢字)(=ソートキー) 
                    if (string.IsNullOrEmpty(tempRow.sortKey))
                    {
                        addRow.hb2Name7 = " ";
                    }
                    else
                    {
                        addRow.hb2Name7 = tempRow.sortKey;
                    }

                    // 2015/04/06 エプソン件名拡張対応 Fujisaki Cng Start 
                    //名称8(漢字)(=広告件名)
                    //if (string.IsNullOrEmpty(tempRow.koukokuKenmei))
                    //{
                    //    addRow.hb2Name8 = " ";
                    //}
                    //else
                    //{
                    //    addRow.hb2Name8 = tempRow.koukokuKenmei;
                    //}
                    if (string.IsNullOrEmpty(tempRow.koukokuKenmei))
                    {
                        addRow.hb2Name11 = " ";
                    }
                    else
                    {
                        addRow.hb2Name11 = tempRow.koukokuKenmei;
                    }
                    // 2015/04/06 エプソン件名拡張対応 Fujisaki Cng End 

                    //名称9(漢字) 
                    addRow.hb2Name9 = " ";

                    //名称10(漢字)(=件名)
                    if (string.IsNullOrEmpty(tempRow.kenmei))
                    {
                        addRow.hb2Name10 = " ";
                    }
                    else
                    {
                        addRow.hb2Name10 = tempRow.kenmei;
                    }

                    // 未使用項目.
                    // 2015/04/06 エプソン件名拡張対応 Fujisaki Cng Start 
                    //addRow.hb2Name11 = " "; //名称11(漢字) 
                    addRow.hb2Name8 = " "; //名称8(漢字) 
                    // 2015/04/06 エプソン件名拡張対応 Fujisaki Cng End 
                    addRow.hb2Name12 = " "; //名称12(漢字) 
                    addRow.hb2Name13 = " "; //名称13(漢字) 
                    addRow.hb2Name14 = " "; //名称14(漢字) 
                    addRow.hb2Name15 = " "; //名称15(漢字) 
                    addRow.hb2Name16 = " "; //名称16(漢字) 
                    addRow.hb2Name17 = " "; //名称17(漢字) 
                    addRow.hb2Name18 = " "; //名称18(漢字) 
                    addRow.hb2Name19 = " "; //名称19(漢字) 
                    addRow.hb2Name20 = " "; //名称20(漢字) 

                    //名称21(漢字) 
                    addRow.hb2Name21 = "1";

                    addRow.hb2Name22 = " "; //名称22(漢字) 
                    addRow.hb2Name23 = " "; //名称23(漢字) 
                    addRow.hb2Name24 = " "; //名称24(漢字) 
                    addRow.hb2Name25 = " "; //名称25(漢字) 
                    addRow.hb2Name26 = " "; //名称26(漢字) 
                    addRow.hb2Name27 = " "; //名称27(漢字) 
                    addRow.hb2Name28 = " "; //名称28(漢字) 
                    addRow.hb2Name29 = " "; //名称29(漢字) 
                    addRow.hb2Name30 = " "; //名称30(漢字) 

                    //金額1(消費税) 
                    addRow.hb2Kngk1 = (Decimal)tempRow.zeiGaku;

                    //金額2(事前金額) 
                    addRow.hb2Kngk2 = (Decimal)tempRow.bfKngk;

                    //金額3
                    addRow.hb2Kngk3 = 0M;

                    //比率1 
                    addRow.hb2Ritu1 = 0M;

                    //比率2 
                    addRow.hb2Ritu2 = 0M;

                    //その他1(請求番号)
                    if (string.IsNullOrEmpty(tempRow.seiNo))
                    {
                        addRow.hb2Sonota1 = " ";
                    }
                    else
                    {
                        // ハイフンを削除する.
                        addRow.hb2Sonota1 = tempRow.seiNo.Replace("-", "");
                    }
                    /* 2017/04/14 エプソン仕入先変更対応 ITCOM A.Nakamura  MOD Start */
                    //その他2(起票部門CD)
                    //addRow.hb2Sonota2   = " ";  //その他2 
                    if (string.IsNullOrEmpty(tempRow.kihyouBmnCd))
                    {
                        addRow.hb2Sonota2 = BLANK;
                    }
                    else
                    {
                        addRow.hb2Sonota2 = tempRow.kihyouBmnCd;
                    }

                    //その他3(原価センタ)
                    //addRow.hb2Sonota3   = " ";  //その他3
                    if (string.IsNullOrEmpty(tempRow.genkaCenter))
                    {
                        addRow.hb2Sonota3 = BLANK;
                    }
                    else
                    {
                        addRow.hb2Sonota3 = tempRow.genkaCenter;
                    }
                    /* 2017/04/14 エプソン仕入先変更対応 ITCOM A.Nakamura  MOD End */
                    addRow.hb2Sonota4   = " ";  //その他4 
                    addRow.hb2Sonota5   = " ";  //その他5 
                    addRow.hb2Sonota6   = " ";  //その他6 
                    addRow.hb2Sonota7   = " ";  //その他7
                    addRow.hb2Sonota8   = " ";  //その他8 
                    addRow.hb2Sonota9   = " ";  //その他9
                    addRow.hb2Sonota10  = " ";  //その他10
                    addRow.hb2BunFlg    = " ";  //分割フラグ 
                    addRow.hb2MeihnFlg  = " ";  //件名変更フラグ 
                    addRow.hb2NebhnFlg  = " ";  //値引率変更フラグ 

                    dtTHB2KMEIWork.AddTHB2KMEIRow(addRow);
                }
            }

            {
                // 請求回収用明細更新 
                for (int i = 0; i < _dsSeikyuDetailEpson.KkhDetail.Rows.Count; i++)
                {
                    DetailDSEpson.KkhDetailRow tempRow = _dsSeikyuDetailEpson.KkhDetail.NewKkhDetailRow();

                    DBNullToEmptyOrZero(tempRow, (DetailDSEpson.KkhDetailRow)_dsSeikyuDetailEpson.KkhDetail.Rows[i]);

                    String JyutNo = String.Empty;
                    String JyMeiNo = String.Empty;
                    String UrMeiNo = String.Empty;

                    {
                        // キーの分解 
                        string[] keys = new string[] { "0", "0", "0" };

                        keys = tempRow.uriMeiNo.Split('-');

                        // 受注番号 
                        JyutNo = keys[0];

                        // 受注明細番号 
                        JyMeiNo = keys[1];

                        // 売上明細番号 
                        UrMeiNo = keys[2];
                    }

                    Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] jyutyuRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[])jyutyuList.Select("hb1JyutNo = '" + JyutNo + "' and hb1JyMeiNo = '" + JyMeiNo + "' and hb1UrMeiNo = '" + UrMeiNo + "'");

                    Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow addRow = dtTHB2KMEIWork.NewTHB2KMEIRow();

                    addRow.hb2TimStmp       = new DateTime();                   //タイムスタンプ 
                    addRow.hb2UpdApl        = AplId;                            //更新プログラム 
                    addRow.hb2UpdTnt        = _naviParameter.strEsqId;          //更新担当者 
                    addRow.hb2EgCd          = _naviParameter.strEgcd;           //営業所コード 
                    addRow.hb2TksKgyCd      = _naviParameter.strTksKgyCd;       //得意先企業コード 
                    addRow.hb2TksBmnSeqNo   = _naviParameter.strTksBmnSeqNo;    //得意先部門SEQNO 
                    addRow.hb2TksTntSeqNo   = _naviParameter.strTksTntSeqNo;    //得意先担当SEQNO 
                    addRow.hb2Yymm          = Yymm;                             //年月 
                    addRow.hb2JyutNo        = JyutNo;                           //受注No 
                    addRow.hb2JyMeiNo       = JyMeiNo;                          //受注明細No 
                    addRow.hb2UrMeiNo       = UrMeiNo;                          //売上明細No 
                    addRow.hb2HimkCd        = " ";                              //費目コード 
                    //addRow.hb2Renbn = "002";                                    //連番 明細登録件数拡張対応.
                    addRow.hb2Renbn = "0002";                                   //連番.
                    addRow.hb2DateFrom      = " ";                              //年月日From 
                    addRow.hb2DateTo        = " ";                              //年月日To 
                    addRow.hb2SeiGak        = (Decimal)tempRow.zeiNKingaku;     //請求金額(税抜き金額)
                    addRow.hb2Hnnert        = 0M;                               //変更値引率.
                    addRow.hb2HnmaeGak      = 0M;                               //値引率変更前金額 
                    addRow.hb2NebiGak       = 0M;                               //値引額 

                    //日付1(計上日)
                    if (string.IsNullOrEmpty(tempRow.keizyoBi))
                    {
                        addRow.hb2Date1 = " ";
                    }
                    else
                    {
                        // /を削除する.
                        addRow.hb2Date1 = tempRow.keizyoBi.Replace("/", "");
                    }

                    addRow.hb2Date2 = " ";  //日付2 
                    addRow.hb2Date3 = " ";  //日付3 
                    addRow.hb2Date4 = " ";  //日付4 
                    addRow.hb2Date5 = " ";  //日付5 
                    addRow.hb2Date6 = " ";  //日付6 

                    //区分1(=請求対象外フラグ)
                    if (bool.Parse(tempRow.seiFlg))
                    {
                        addRow.hb2Kbn1 = "1";
                    }
                    else
                    {
                        addRow.hb2Kbn1 = "0";
                    }

                    addRow.hb2Kbn2 = " ";   //区分2 
                    addRow.hb2Kbn3 = " ";   //区分3 

                    //コード1(=業務区分) 
                    if (string.IsNullOrEmpty(tempRow.baitaiCd))
                    {
                        addRow.hb2Code1 = " ";
                    }
                    else
                    {
                        addRow.hb2Code1 = tempRow.baitaiCd;
                    }

                    //コード2(=請求区分) 
                    if (string.IsNullOrEmpty(tempRow.seiKbn))
                    {
                        addRow.hb2Code2 = " ";
                    }
                    else
                    {
                        addRow.hb2Code2 = tempRow.seiKbn;
                    }

                    //コード3(=取引担当者コード) 
                    if (string.IsNullOrEmpty(tempRow.triTntCd))
                    {
                        addRow.hb2Code3 = " ";
                    }
                    else
                    {
                        addRow.hb2Code3 = tempRow.triTntCd;
                    }

                    //コード4(=取引識別コード) 
                    if (string.IsNullOrEmpty(tempRow.triSikiCd))
                    {
                        addRow.hb2Code4 = " ";
                    }
                    else
                    {
                        addRow.hb2Code4 = tempRow.triSikiCd;
                    }

                    //コード5（=取引識別キーコード）.
                    if (string.IsNullOrEmpty(tempRow.triSikiKeyCd))
                    {
                        addRow.hb2Code5 = " ";
                    }
                    else
                    {
                        addRow.hb2Code5 = tempRow.triSikiKeyCd;
                    }

                    addRow.hb2Code6 = " ";  //コード6
                    addRow.hb2Name1 = " ";  //名称1(漢字)
                    addRow.hb2Name2 = " ";  //名称2(漢字) 

                    //名称3(漢字)(=取引担当者名称) 
                    if (string.IsNullOrEmpty(tempRow.triTntNm))
                    {
                        addRow.hb2Name3 = " ";
                    }
                    else
                    {
                        addRow.hb2Name3 = tempRow.triTntNm;
                    }

                    //名称4(漢字)(=取引識別名称) 
                    if (string.IsNullOrEmpty(tempRow.triSikiNm.Trim()))
                    {
                        addRow.hb2Name4 = " ";
                    }
                    else
                    {
                        addRow.hb2Name4 = tempRow.triSikiNm;
                    }

                    //名称5(漢字)(=指図ＮＯ)  
                    if (string.IsNullOrEmpty(tempRow.ssNo))
                    {
                        addRow.hb2Name5 = " ";
                    }
                    else
                    {
                        addRow.hb2Name5 = tempRow.ssNo;
                    }

                    //名称6(漢字)(=セグメントＮＯ) 
                    if (string.IsNullOrEmpty(tempRow.segNo))
                    {
                        addRow.hb2Name6 = " ";
                    }
                    else
                    {
                        addRow.hb2Name6 = tempRow.segNo;
                    }

                    //名称7(漢字)(=ソートキー) 
                    if (string.IsNullOrEmpty(tempRow.sortKey))
                    {
                        addRow.hb2Name7 = " ";
                    }
                    else
                    {
                        addRow.hb2Name7 = tempRow.sortKey;
                    }

                    // 2015/04/06 エプソン件名拡張対応 Fujisaki Cng Start 
                    //名称8(漢字)(=請求件名)
                    //if (string.IsNullOrEmpty(tempRow.seiKenmei))
                    //{
                    //    addRow.hb2Name8 = " ";
                    //}
                    //else
                    //{
                    //    addRow.hb2Name8 = tempRow.seiKenmei;
                    //}
                    if (string.IsNullOrEmpty(tempRow.seiKenmei))
                    {
                        addRow.hb2Name11 = " ";
                    }
                    else
                    {
                        addRow.hb2Name11 = tempRow.seiKenmei;
                    }
                    // 2015/04/06 エプソン件名拡張対応 Fujisaki Cng End 

                    // 未使用項目.
                    addRow.hb2Name9  = " "; //名称9 (漢字) 
                    addRow.hb2Name10 = " "; //名称10(漢字)
                    // 2015/04/06 エプソン件名拡張対応 Fujisaki Cng Start 
                    //addRow.hb2Name11 = " "; //名称11(漢字) 
                    addRow.hb2Name8 = " "; //名称8(漢字) 
                    // 2015/04/06 エプソン件名拡張対応 Fujisaki Cng End 
                    addRow.hb2Name12 = " "; //名称12(漢字) 
                    addRow.hb2Name13 = " "; //名称13(漢字) 
                    addRow.hb2Name14 = " "; //名称14(漢字) 
                    addRow.hb2Name15 = " "; //名称15(漢字) 
                    addRow.hb2Name16 = " "; //名称16(漢字) 
                    addRow.hb2Name17 = " "; //名称17(漢字) 
                    addRow.hb2Name18 = " "; //名称18(漢字) 
                    addRow.hb2Name19 = " "; //名称19(漢字) 
                    addRow.hb2Name20 = " "; //名称20(漢字) 

                    //名称21(漢字) 
                    addRow.hb2Name21 = "2";

                    addRow.hb2Name22 = " "; //名称22(漢字) 
                    addRow.hb2Name23 = " "; //名称23(漢字) 
                    addRow.hb2Name24 = " "; //名称24(漢字) 
                    addRow.hb2Name25 = " "; //名称25(漢字) 
                    addRow.hb2Name26 = " "; //名称26(漢字) 
                    addRow.hb2Name27 = " "; //名称27(漢字) 
                    addRow.hb2Name28 = " "; //名称28(漢字) 
                    addRow.hb2Name29 = " "; //名称29(漢字) 
                    addRow.hb2Name30 = " "; //名称30(漢字) 

                    //金額1(消費税) 
                    addRow.hb2Kngk1 = (Decimal)tempRow.zeiGaku;

                    //金額2
                    addRow.hb2Kngk2 = 0M;

                    //金額3
                    addRow.hb2Kngk3 = 0M;

                    //比率1 
                    addRow.hb2Ritu1 = 0M;

                    //比率2 
                    addRow.hb2Ritu2 = 0M;

                    //その他1(請求番号)
                    if (string.IsNullOrEmpty(tempRow.seiNo))
                    {
                        addRow.hb2Sonota1 = " ";
                    }
                    else
                    {
                        // ハイフンを削除する.
                        addRow.hb2Sonota1 = tempRow.seiNo.Replace("-", "");
                    }

                    /* 2017/04/14 エプソン仕入先変更対応 ITCOM A.Nakamura MOD Start */
                    //請求回収一覧への表示.
                    //その他2(起票部門CD)
                    //addRow.hb2Sonota2   = " ";  //その他2 
                    if (string.IsNullOrEmpty(tempRow.kihyouBmnCd))
                    {
                        addRow.hb2Sonota2 = BLANK;
                    }
                    else
                    {
                        addRow.hb2Sonota2 = tempRow.kihyouBmnCd;
                    }

                    //その他3(原価センタ)
                    //addRow.hb2Sonota3   = " ";  //その他3 
                    if (string.IsNullOrEmpty(tempRow.genkaCenter))
                    {
                        addRow.hb2Sonota3 = BLANK;
                    }
                    else
                    {
                        addRow.hb2Sonota3 = tempRow.genkaCenter;
                    }
                    /* 2017/04/14 エプソン仕入先変更対応 ITCOM A.Nakamura MOD End */

                    addRow.hb2Sonota4   = " ";  //その他4 
                    addRow.hb2Sonota5   = " ";  //その他5 
                    addRow.hb2Sonota6   = " ";  //その他6 
                    addRow.hb2Sonota7   = " ";  //その他7
                    addRow.hb2Sonota8   = " ";  //その他8 
                    addRow.hb2Sonota9   = " ";  //その他9
                    addRow.hb2Sonota10  = " ";  //その他10 
                    addRow.hb2BunFlg    = " ";  //分割フラグ 
                    addRow.hb2MeihnFlg  = " ";  //件名変更フラグ 
                    addRow.hb2NebhnFlg  = " ";  //値引率変更フラグ 

                    dtTHB2KMEIWork.AddTHB2KMEIRow(addRow);
                }
            }

            {
                // 未請求フラグと明細フラグを算出する.
                foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow in dtTHB1DOWNWork.Rows)
                {
                    Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow jyutyuRow = ((Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[])jyutyuList.Select("hb1JyutNo = '" + thb1DownRow.hb1JyutNo + "' and hb1JyMeiNo = '" + thb1DownRow.hb1JyMeiNo + "' and hb1UrMeiNo = '" + thb1DownRow.hb1UrMeiNo + "'"))[0];

                    Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow[] thb2KmeiRows = (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow[])dtTHB2KMEIWork.Select("hb2Name21 = '1' and hb2JyutNo = '" + thb1DownRow.hb1JyutNo + "' and hb2JyMeiNo = '" + thb1DownRow.hb1JyMeiNo + "' and hb2UrMeiNo = '" + thb1DownRow.hb1UrMeiNo + "'", "");
                    {
                        // 未請求フラグの算出.
                        Decimal seiGak = 0M;

                        foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow thb2KmeiRow in thb2KmeiRows)
                        {
                            seiGak += thb2KmeiRow.hb2SeiGak;
                        }

                        if (jyutyuRow.hb1SeiGak == seiGak)
                        {
                            thb1DownRow.hb1MSeiFlg = "0";
                        }
                        else
                        {
                            thb1DownRow.hb1MSeiFlg = "1";
                        }
                    }

                    {
                        // 明細フラグの算出.
                        if (thb2KmeiRows.Length == 0)
                        {
                            thb1DownRow.hb1MeisaiFlg = "0";
                        }
                        else
                        {
                            thb1DownRow.hb1MeisaiFlg = "1";
                        }
                    }

                    //
                    //明細がない場合.
                    if (thb1DownRow.hb1MeisaiFlg.Equals("0"))
                    {
                        //登録者、更新者が空の場合.
                        if (string.IsNullOrEmpty(jyutyuRow.hb1TrkTntNm.Trim()) && string.IsNullOrEmpty(jyutyuRow.hb1KsnTntNm.Trim()))
                        {
                        }
                        //登録者がからで、更新者が入っている場合.
                        else if (string.IsNullOrEmpty(jyutyuRow.hb1TrkTntNm.Trim()) && !string.IsNullOrEmpty(jyutyuRow.hb1KsnTntNm.Trim()))
                        {
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
                    //明細がある場合 
                    else
                    {
                        //登録担当者が空かつ更新者が空でない場合 
                        if (string.IsNullOrEmpty(jyutyuRow.hb1TrkTntNm.Trim()) && !string.IsNullOrEmpty(jyutyuRow.hb1KsnTntNm.Trim()))
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
                        else if (string.IsNullOrEmpty(jyutyuRow.hb1TrkTntNm.Trim()))
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
                            //登録者 
                            thb1DownRow.hb1TrkTnt = _naviParameter.strEsqId.Trim();
                            //登録者名 
                            thb1DownRow.hb1TrkTntNm = _naviParameter.strName.Trim();

                            //更新者のみを入れる.
                            //更新者.
                            thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                            //更新担当者名.
                            thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                        }
                    }
                }
            }

            {
                // 更新用のデータセットを作成する 
                String MeisaiSybtKey = null;
                String JyutNoKey = null;
                String JyMeiNoKey = null;
                String UrMeiNoKey = null;
                String SeikyuNoKey = null;

                foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow thb2KmeiRow in dtTHB2KMEIWork.Select("", "hb2Name21, hb2JyutNo, hb2JyMeiNo, hb2UrMeiNo, hb2Renbn, hb2Sonota1"))
                {
                    String MeisaiSybt = thb2KmeiRow.hb2Name21;

                    if (String.Equals(MeisaiSybt, "1"))
                    {
                        // 広告費用明細.
                        String JyutNo = thb2KmeiRow.hb2JyutNo;

                        String JyMeiNo = thb2KmeiRow.hb2JyMeiNo;

                        String UrMeiNo = thb2KmeiRow.hb2UrMeiNo;

                        if
                        (
                            ( String.Equals(MeisaiSybt, MeisaiSybtKey) ) &&
                            ( String.Equals(JyutNo, JyutNoKey) ) &&
                            ( String.Equals(JyMeiNo, JyMeiNoKey) ) &&
                            ( String.Equals(UrMeiNo, UrMeiNoKey) )
                        )
                        {
                            // 受注番号毎にまとめて処理するためキーが同じ場合は次のレコードへ.
                            continue;
                        }

                        // 更新用データセット.
                        Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

                        {
                            // 受注データの作成.
                            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable thb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();

                            foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow in dtTHB1DOWNWork.Select("hb1JyutNo = '" + JyutNo + "' and hb1JyMeiNo = '" + JyMeiNo + "' and hb1UrMeiNo = '" + UrMeiNo + "'", ""))
                            {
                                thb1Down.ImportRow(thb1DownRow);
                            }

                            dsDetail.THB1DOWN.Merge(thb1Down);
                        }

                        {
                            // 明細データの作成.
                            Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable thb2Kmei = new Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable();

                            foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow thb2KmeiRow2 in dtTHB2KMEIWork.Select("hb2Name21 = '1' and hb2JyutNo = '" + JyutNo + "' and hb2JyMeiNo = '" + JyMeiNo + "' and hb2UrMeiNo = '" + UrMeiNo + "'", "hb2JyutNo, hb2JyMeiNo, hb2UrMeiNo, hb2Renbn"))
                            {
                                thb2Kmei.ImportRow(thb2KmeiRow2);
                            }

                            dsDetail.THB2KMEI.Merge(thb2Kmei);
                        }

                        // リストに追加.
                        dsDetailList.Add(dsDetail);

                        // キーを更新.
                        MeisaiSybtKey = MeisaiSybt;
                        JyutNoKey = JyutNo;
                        JyMeiNoKey = JyMeiNo;
                        UrMeiNoKey = UrMeiNo;
                        SeikyuNoKey = null;
                    }
                    else if (String.Equals(MeisaiSybt, "2"))
                    {
                        // 請求回収用明細 
                        String SeikyuNo = thb2KmeiRow.hb2Sonota1;

                        if
                        (
                            ( String.Equals(MeisaiSybt, MeisaiSybtKey) ) &&
                            ( String.Equals(SeikyuNo, SeikyuNoKey) )
                        )
                        {
                            // 受注番号毎にまとめて処理するためキーが同じ場合は次のレコードへ.
                            continue;
                        }

                        // 更新用データセット.
                        Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

                        {
                            // 明細データの作成.
                            Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable thb2Kmei = new Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable();

                            foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow thb2KmeiRow2 in dtTHB2KMEIWork.Select("hb2Name21 = '2' and hb2Sonota1 = '" + SeikyuNo + "'", "hb2Sonota1"))
                            {
                                thb2Kmei.ImportRow(thb2KmeiRow2);
                            }

                            dsDetail.THB2KMEI.Merge(thb2Kmei);
                        }

                        // リストに追加.
                        dsDetailList.Add(dsDetail);

                        // キーを更新.
                        MeisaiSybtKey = MeisaiSybt;
                        JyutNoKey = null;
                        JyMeiNoKey = null;
                        UrMeiNoKey = null;
                        SeikyuNoKey = SeikyuNo;
                    }
                }
            }

            {
                // 最大更新時間の設定 
                // エプソンは全受注・全明細を一括で更新する仕様のため独自実装とする 
                // 全受注 
                foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow row in _dsDetail.THB1DOWN.Rows)
                {
                    if (maxUpdDate == null || maxUpdDate.CompareTo(row.hb1TimStmp) < 0)
                    {
                        maxUpdDate = row.hb1TimStmp;
                    }
                }

                // 広告費用明細.
                foreach (DetailDSEpson.DetailDataEpsonRow row in _dsDetailEpson.DetailDataEpson.Rows)
                {
                    if (maxUpdDate == null || maxUpdDate.CompareTo(row.hb2TimStmp) < 0)
                    {
                        maxUpdDate = row.hb2TimStmp;
                    }
                }

                // 請求回収用明細.
                foreach (DetailDSEpson.DetailDataEpsonRow row in _dsSeikyuDetailEpson.DetailDataEpson.Rows)
                {
                    if (maxUpdDate == null || maxUpdDate.CompareTo(row.hb2TimStmp) < 0)
                    {
                        maxUpdDate = row.hb2TimStmp;
                    }
                }
            }

            //**********************************************
            //明細登録API実行 
            //**********************************************
            {
                DetailEpsonProcessController.BulkUpdateDetailDataEpsonParam param = new DetailEpsonProcessController.BulkUpdateDetailDataEpsonParam();
                param.egCd = _naviParameter.strEgcd;
                param.esqId = _naviParameter.strEsqId;
                param.tksKgyCd = _naviParameter.strTksKgyCd;
                param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
                param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
                param.yymm = Yymm;
                param.dsDetailList = dsDetailList;
                param.maxUpdDate = maxUpdDate;
                param.TourokuList = new Isid.KKH.Common.KKHSchema.Detail();
                param.TourokuList.THB1DOWN.Merge(dtTHB1DOWNWork);
                if (dsDetailList.Count == 0)
                {
                    //param.inputFlg = "0";
                }
                else
                {
                    param.inputFlg = "1";
                }

                DetailEpsonProcessController controller = DetailEpsonProcessController.GetInstance();

                BulkUpdateDetailDataEpsonServiceResult result = controller.BulkUpdateDetailDataEpson(param);

                if (result.HasError)
                {
                    base.CloseLoadingDialog();

                    if (result.MessageCode == "LOCK-E0001")
                    {
                        //排他エラー 
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0148, null, "明細登録", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_E0003, null, "明細登録", MessageBoxButtons.OK);
                    }

                    return;
                }
            }

            _spdJyutyuList_Sheet1.SetActiveCell(0, 0, true);
            _spdJyutyuList_Sheet1.AddSelection(0, -1, 1, -1);
            spdJyutyuList.ShowActiveCell(VerticalPosition.Nearest, HorizontalPosition.Nearest);
            {
                Boolean state = isActivatedSeikyuList();

                // 受注データの検索.
                ReSearchJyutyuData();

                // 請求回収データの検索.
                SearchSeikyuKaisyuData();

                // 選択状態を解除 
                this.ActiveControl = null;

                // ボタンの有効無効を変更.
                SetButtonEnable();

                // データをクリアしたため明細変更フラグをオフにする.
                kkhDetailUpdFlag = false;

                // エラーチェック.
                if (( _dsDetail.JyutyuList.Count == 0 ) && ( _dsSeikyuEpson.SeikyuHeader.Count == 0 ))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "入力エラー", MessageBoxButtons.OK);
                    txtYmd.Focus();
                    return;
                }

                if (state)
                {
                    // タブ変更時の検索を無効化.
                    _notSearchState = true;

                    // 請求回収データがある場合は自動でそちらを開く.
                    tabHed.SelectedIndex = 2;

                    // タブ変更時の検索を有効化.
                    _notSearchState = false;
                }
            }

            base.CloseLoadingDialog();
            MessageUtility.ShowMessageBox(MessageCode.HB_I0012, null, "明細登録", MessageBoxButtons.OK);
        }
        #endregion 明細登録処理.

        #region 「期間」を表示用のフォーマットに変換します.
        /// <summary>
        /// 「期間」を表示用のフォーマットに変換します.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string FormatPeriod(string str)
        {
            string ret = "";

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
        #endregion 「期間」を表示用のフォーマットに変換します.

        #region マスタ情報を取得する.
        /// <summary>
        /// マスタ情報を取得する.
        /// </summary>
        private void GetMasterData()
        {
            #region 取引識別情報の取得.
            {
                // 取引識別情報マスタ情報取得.
                MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = process.FindMasterByCond
                (
                    _naviParameter.strEsqId,
                    _naviParameter.strEgcd,
                    _naviParameter.strTksKgyCd,
                    _naviParameter.strTksBmnSeqNo,
                    _naviParameter.strTksTntSeqNo,
                    KkhConstEpson.MasterKey.TRISIKI,
                    null
                );

                MasterMaintenance ds = result.MasterDataSet;
                MasterMaintenance.MasterDataVORow[] rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();

                List<string> lstKeys = new List<string>();
                List<string> lstValues = new List<string>();
                // 空を選択できるようにする.
                lstKeys.Add(String.Empty);
                lstValues.Add(String.Empty);

                foreach (MasterMaintenance.MasterDataVORow row in rows)
                {
                    lstKeys.Add(row.Column1);
                    lstValues.Add(row.Column2 + " " + row.Column3);
                }

                _triSikiKey = lstKeys.ToArray();
                _triSikiValue = lstValues.ToArray();
            }
            #endregion 取引識別情報の取得.

            #region 取引担当者情報の取得.
            {
                // 取引担当者マスタ情報取得.
                MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = process.FindMasterByCond
                (
                    _naviParameter.strEsqId,
                    _naviParameter.strEgcd,
                    _naviParameter.strTksKgyCd,
                    _naviParameter.strTksBmnSeqNo,
                    _naviParameter.strTksTntSeqNo,
                    KkhConstEpson.MasterKey.TRITNT,
                    null
                );

                MasterMaintenance ds = result.MasterDataSet;
                MasterMaintenance.MasterDataVORow[] rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();

                List<string> lstKeys = new List<string>();
                List<string> lstValues = new List<string>();
                // 空を選択できるようにする 
                lstKeys.Add(String.Empty);
                lstValues.Add(String.Empty);

                foreach (MasterMaintenance.MasterDataVORow row in rows)
                {
                    lstKeys.Add(row.Column1);

                    lstValues.Add(row.Column2);
                }

                _triTntKey = lstKeys.ToArray();
                _triTntValue = lstValues.ToArray();
            }
            #endregion 取引担当者情報の取得.

            /* 2017/04/17 エプソン仕入先変更対応 ITCOM A.Nakamura ADD Start */
            #region 起票部門コード情報の取得.
            {
                // 起票部門コードマスタ情報取得.
                MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = process.FindMasterByCond
                (
                    _naviParameter.strEsqId,
                    _naviParameter.strEgcd,
                    _naviParameter.strTksKgyCd,
                    _naviParameter.strTksBmnSeqNo,
                    _naviParameter.strTksTntSeqNo,
                    KkhConstEpson.MasterKey.MST_KIHYOUBMNCD,
                    null
                );

                MasterMaintenance ds = result.MasterDataSet;
                drMasterData[] rows = (drMasterData[])ds.MasterDataVO.Select();

                List<string> lstKeys = new List<string>();
                List<string> lstValues = new List<string>();
                // 空を選択できるようにする 
                lstKeys.Add(String.Empty);
                lstValues.Add(String.Empty);

                foreach (drMasterData row in rows)
                {
                    lstKeys.Add(row.Column2);

                    lstValues.Add(row.Column2);
                }

                _kihyouBmnCdKey = lstKeys.ToArray();
                _kihyouBmnCdValue = lstValues.ToArray();
            }
            #endregion 起票部門コード情報の取得.

            #region 原価センタ情報の取得.
            {
                // 原価センタマスタ情報取得.
                MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = process.FindMasterByCond
                (
                    _naviParameter.strEsqId,
                    _naviParameter.strEgcd,
                    _naviParameter.strTksKgyCd,
                    _naviParameter.strTksBmnSeqNo,
                    _naviParameter.strTksTntSeqNo,
                    KkhConstEpson.MasterKey.MST_GENKACENTER,
                    null
                );

                MasterMaintenance ds = result.MasterDataSet;
                drMasterData[] rows = (drMasterData[])ds.MasterDataVO.Select();

                List<string> lstKeys = new List<string>();
                List<string> lstValues = new List<string>();
                // 空を選択できるようにする 
                lstKeys.Add(String.Empty);
                lstValues.Add(String.Empty);

                foreach (drMasterData row in rows)
                {
                    lstKeys.Add(row.Column2);

                    lstValues.Add(row.Column2);
                }

                _genkaCenterKey = lstKeys.ToArray();
                _genkaCenterValue = lstValues.ToArray();
            }
            #endregion 原価センタ情報の取得.
            /* 2017/04/17 エプソン仕入先変更対応 ITCOM A.Nakamura ADD End */
        }
        #endregion マスタ情報を取得する.
        
        #region マスタデータ管理.
        #region マスタデータ.
        //***************************************************
        //検索データ保持用Hashtable 
        //　再利用するデータ(マスタデータ等)を保持 
        //***************************************************
        //マスタデータ 
        Hashtable htMasterData = new Hashtable();
        #endregion マスタデータ.

        #region 汎用マスタの検索を行う.
        /// <summary>
        /// 汎用マスタの検索を行う 
        /// 一度取得したデータは保持され、検索済みのマスタデータは保持したデータを返却する 
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
                MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = controller.FindMasterByCond
                (
                    _naviParameter.strEsqId,
                    _naviParameter.strEgcd,
                    _naviParameter.strTksKgyCd,
                    _naviParameter.strTksBmnSeqNo,
                    _naviParameter.strTksTntSeqNo,
                    masterKey,
                    ""
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

        #region 広告費用明細登録.
        /// <summary>
        /// 広告費用明細登録.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean SetDetailData(int index)
        {
            Boolean retval = false;
            Boolean state = false;
            Common.KKHSchema.Detail.JyutyuDataRow jyutyuRow = getSelectJyutyuData(index);
            String meisaiNoKey = jyutyuRow.hb1JyutNo + "-" + jyutyuRow.hb1JyMeiNo + "-" + jyutyuRow.hb1UrMeiNo;

            foreach (DetailDSEpson.KkhDetailRow detailRow in _dsDetailEpson.KkhDetail.Rows)
            {
                if (!String.Equals(detailRow.uriMeiNo.Trim(), meisaiNoKey))
                {
                    continue;
                }

                // 既に明細が登録されている.
                state = true;

                // 検索を終了.
                break;
            }

            // 登録済みの明細がみつからなった場合は登録を行う.
            if (state == false)
            {
                // 明細にデータをセットする 
                SetDetailDataSub(jyutyuRow);

                retval = true;
            }

            return retval;
        }
        #endregion 広告費用明細登録.

        #region 請求回収用明細登録.
        /// <summary>
        /// 請求回収用明細登録.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean SetSeikyuDetailData(int index, out String errtype)
        {
            // 戻り変数初期化.
            // 既登録明細:FIN
            // 取消請求データ:DEL
            errtype = String.Empty;

            Boolean retval = false;
            Boolean state = false;
            String seikyuNoKey = null;
            SeikyuDsEpson.SeikyuListDataTable dtSeikyuList = new SeikyuDsEpson.SeikyuListDataTable();

            // 請求書番号を割り出し.
            SeikyuDsEpson.SeikyuHeaderRow seikyuHeaderRow = getSelectSeikyuHeaderData(index);
            seikyuNoKey = seikyuHeaderRow.seikyuNo.Trim();

            // 取消されている請求データは対象外.
            if (seikyuHeaderRow.seiStatus.Equals("3"))
            {
                errtype = "DEL";
                return retval;
            }
            
            // 請求書番号に紐付く請求リストを割り出し.
            SeikyuDsEpson.SeikyuListRow[] seikyuListRows = (SeikyuDsEpson.SeikyuListRow[])_dsSeikyuEpson.SeikyuList.Select("seikyuNo = '" + seikyuNoKey + "'", "seikyuNo, seikyuMeiNo");

            foreach (SeikyuDsEpson.SeikyuListRow seikyuListRow in seikyuListRows)
            {
                dtSeikyuList.ImportRow(seikyuListRow);
            }

            foreach (DetailDSEpson.KkhDetailRow detailRow in _dsSeikyuDetailEpson.KkhDetail.Rows)
            {
                if (!String.Equals(detailRow.seiNo.Trim(), seikyuNoKey))
                {
                    continue;
                }

                // 既に明細が登録されている.
                state = true;
                errtype = "FIN";

                // 検索を終了.
                break;
            }

            // 登録済みの明細がみつからなった場合は登録を行う.
            if (state == false)
            {
                // 請求ヘッダを取得.
                SeikyuDsEpson.THB14SKDOWNRow[] thb14SkdownRows = (SeikyuDsEpson.THB14SKDOWNRow[])_dsSeikyuEpson.THB14SKDOWN.Select("hb14SeiNo = '" + seikyuNoKey.Replace("-", "") + "'", "hb14SeiNo, hb14SeiMeiNo");

                SeikyuDsEpson.THB14SKDOWNRow thb14SkdownRow = thb14SkdownRows[0];

                // 広告費用明細格納用.
                DetailDSEpson.KkhDetailDataTable dtDetail = new DetailDSEpson.KkhDetailDataTable();

                foreach (SeikyuDsEpson.SeikyuListRow seikyuListRow in dtSeikyuList.Rows)
                {
                    String meisaiNoKey = seikyuListRow.uriMeiNo;

                    foreach (DetailDSEpson.KkhDetailRow detailRow in _dsDetailEpson.KkhDetail.Rows)
                    {
                        // キーが違う場合は処理対象外.
                        if (!String.Equals(detailRow.uriMeiNo.Trim(), meisaiNoKey))
                        {
                            continue;
                        }

                        // レコードを処理対象に追加.
                        dtDetail.ImportRow(detailRow);
                    }
                }

                // 明細にデータをセットする 
                SetSeikyuDetailDataSub(thb14SkdownRow, dtDetail);
                retval = true;
            }

            return retval;
        }
        #endregion 請求回収用明細登録.

        #region 明細データ設定処理.
        /// <summary>
        /// 明細データ設定処理.
        /// </summary>
        /// <param name="jyutyuRow"></param>
        private void SetDetailDataSub(Common.KKHSchema.Detail.JyutyuDataRow jyutyuRow)
        {
            // 広告費明細変更フラグを更新 
            base.kkhDetailUpdFlag = true;

            // 広告費用明細.
            DetailDSEpson.KkhDetailRow row = _dsDetailEpson.KkhDetail.NewKkhDetailRow();

            // 明細スプレッドに値を設定 

            //請求対象外フラグ.
            row.seiFlg = false.ToString();

            //請求番号.
            row.seiNo = "";

            //売上明細ＮＯ.
            row.uriMeiNo = jyutyuRow.hb1JyutNo + "-" + jyutyuRow.hb1JyMeiNo + "-" + jyutyuRow.hb1UrMeiNo;

            //広告件名.
            row.koukokuKenmei = jyutyuRow.hb1KKNameKJ;

            // 取引担当者コード.
            row.triTntCd = "";

            //件名(請求区分にて分岐)
            if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.NewsPaper)
            {
                //新聞データ 
                string MEKbn = string.Empty;

                if (jyutyuRow.hb1Field4.Trim().Equals("1"))
                {
                    MEKbn = "朝刊";
                }
                else if (jyutyuRow.hb1Field4.Trim().Equals("2"))
                {
                    MEKbn = "夕刊";
                }

                row.kenmei = jyutyuRow.hb1Field2 + " " + MEKbn + " " + jyutyuRow.hb1Field11;
            }
            else if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Magazine)
            {
                //雑誌データ 
                row.kenmei = jyutyuRow.hb1Field2 + " " + jyutyuRow.hb1Field3;
            }
            else if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Time)
            {
                //タイムデータ 
                row.kenmei = jyutyuRow.hb1Field2 + " " + jyutyuRow.hb1Field3;
            }
            else if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Spot)
            {
                //スポットデータ 
                row.kenmei = jyutyuRow.hb1Field2 + " " + jyutyuRow.hb1Field3;
            }
            else if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Works)
            {
                //諸作業データ  
                String hosoku;

                if (!String.IsNullOrEmpty(jyutyuRow.hb1Field4))
                {
                    // 補足内容（正味）を使う.
                    hosoku = jyutyuRow.hb1Field4;
                }
                else if (!String.IsNullOrEmpty(jyutyuRow.hb1Field3))
                {
                    // 費目補足を使う.
                    hosoku = jyutyuRow.hb1Field3;
                }
                else
                {
                    // 空文字にする.
                    hosoku = String.Empty;
                }

                row.kenmei = hosoku;
            }
            else if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Ooh)
            {
                //交通広告データ 
                row.kenmei = jyutyuRow.hb1Field4;
            }
            else if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.KMas)
            {
                //国際/マスデータ 
                row.kenmei = jyutyuRow.hb1Field11;
            }
            else if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.KWorks)
            {
                //国際/諸作業データ 
                row.kenmei = jyutyuRow.hb1Field12;
            }
            else if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.IC)
            {
                //IC(インタラクティブメディア) 
                row.kenmei = jyutyuRow.hb1Field2 + " " + jyutyuRow.hb1Field4;
            }
            else
            {
                //上記以外はデフォルト空表記.
                row.kenmei = "";
            }

            // 取引識別名称.
            row.triSikiKeyCd = "";

            /* 2017/04/17 エプソン仕入先変更対応 ITCOM A.Nakamura ADD Start */
            // 起票部門CD.
            row.kihyouBmnCd = BLANK;

            // 原価センタ.
            row.genkaCenter = BLANK;
            /* 2017/04/17 エプソン仕入先変更対応 ITCOM A.Nakamura ADD End */

            // 事前金額.
            row.bfKngk = jyutyuRow.hb1SeiGak;

            // 事後金額.
            row.afKngk = 0M;

            // 業務区分.
            row.baitaiCd = jyutyuRow.hb1GyomKbn;

            // 請求区分.
            row.seiKbn = jyutyuRow.hb1SeiKbn;

            // 取引担当者名.
            row.triTntNm = "";

            // 取引識別コード.
            row.triSikiCd = "";

            // 取引識別名称.
            row.triSikiNm = "";

            // 指図ＮＯ.
            row.ssNo = "";

            // セグメントＮＯ.
            row.segNo = "";

            // ソートキー.
            row.sortKey = "";

            // 金額（税込み）.
            row.seiKingaku = 0M;

            // 消費税.
            row.zeiGaku = jyutyuRow.hb1SzeiGak;

            // 税抜き金額.
            row.zeiNKingaku = 0M;

            // 計上日.
            row.keizyoBi = "";

            // レコードを追加.
            _dsDetailEpson.KkhDetail.AddKkhDetailRow(row);
        }
        #endregion 明細データ設定処理.

        #region 請求回収用明細データ設定処理.
        /// <summary>
        /// 請求回収用明細データ設定処理.
        /// </summary>
        /// <param name="thb14SkdownRow"></param>
        /// <param name="dt"></param>
        private void SetSeikyuDetailDataSub(SeikyuDsEpson.THB14SKDOWNRow thb14SkdownRow, DetailDSEpson.KkhDetailDataTable dt)
        {
            // 広告費明細変更フラグを更新 
            base.kkhDetailUpdFlag = true;

            // 請求回収用明細.
            DetailDSEpson.KkhDetailRow row = _dsSeikyuDetailEpson.KkhDetail.NewKkhDetailRow();

            // 明細スプレッドに値を設定.

            // 請求対象外フラグ.
            row.seiFlg = false.ToString();

            // 請求番号.
            if (thb14SkdownRow.hb14SeiNo.Length == 12)
            {
                row.seiNo = thb14SkdownRow.hb14SeiNo.Substring(0, 8) + "-" + thb14SkdownRow.hb14SeiNo.Substring(8, 4);
            }
            else
            {
                row.seiNo = thb14SkdownRow.hb14SeiNo;
            }

            // 売上明細ＮＯ.
            row.uriMeiNo = thb14SkdownRow.hb14JyutNo + "-" + thb14SkdownRow.hb14JyMeiNo + "-" + thb14SkdownRow.hb14UrMeiNo;

            // 広告件名.
            row.koukokuKenmei = thb14SkdownRow.hb14KouNameUp;

            // 取引担当者コード.
            row.triTntCd = "";

            // 件名.
            row.kenmei = "";

            // 請求件名.
            row.seiKenmei = thb14SkdownRow.hb14KouNameUp + thb14SkdownRow.hb14KouNameDown;

            // 取引識別名称.
            row.triSikiKeyCd = "";

            /* 2017/04/17 エプソン仕入先変更対応 ITCOM A.Nakamura ADD Start */
            // 起票部門CD.
            row.kihyouBmnCd = BLANK;

            // 原価センタ.
            row.genkaCenter = BLANK;
            /* 2017/04/17 エプソン仕入先変更対応 ITCOM A.Nakamura ADD End */

            // 事前金額.
            row.bfKngk = 0M;

            // 事後金額.
            row.afKngk = 0M;

            // 業務区分.
            row.baitaiCd = "";

            // 請求区分.
            row.seiKbn = "";

            // 取引担当者名.
            row.triTntNm = "";

            // 取引識別コード.
            row.triSikiCd = "";

            // 取引識別名称.
            row.triSikiNm = "";

            // 指図ＮＯ.
            row.ssNo = "";

            // セグメントＮＯ.
            row.segNo = "";

            // ソートキー.
            row.sortKey = "";

            // 金額（税込み）.
            row.seiKingaku = thb14SkdownRow.hb14SeigakGk;

            // 消費税.
            row.zeiGaku = thb14SkdownRow.hb14SzeigakGk;

            // 税抜き金額.
            row.zeiNKingaku = thb14SkdownRow.hb14TorigakGk - thb14SkdownRow.hb14NebigakGk;

            // 計上日.
            if (thb14SkdownRow.hb14SeiHakDate.Length == 8)
            {
                row.keizyoBi = thb14SkdownRow.hb14SeiHakDate.Substring(0, 4) + "/" + thb14SkdownRow.hb14SeiHakDate.Substring(4, 2) + "/" + thb14SkdownRow.hb14SeiHakDate.Substring(6, 2);
            }
            else
            {
                row.keizyoBi = thb14SkdownRow.hb14SeiHakDate;
            }

            // 広告費用明細の金額を合算して算出.
            foreach (DetailDSEpson.KkhDetailRow detailRow in dt.Rows)
            {
                DetailDSEpson.KkhDetailRow tempRow = _dsSeikyuDetailEpson.KkhDetail.NewKkhDetailRow();

                DBNullToEmptyOrZero(tempRow, detailRow);

                if (( String.IsNullOrEmpty(row.triTntCd) ) && ( !String.IsNullOrEmpty(tempRow.triTntCd) ))
                {
                    // 取引担当者コード.
                    row.triTntCd = tempRow.triTntCd;

                    // 取引担当者名.
                    row.triTntNm = tempRow.triTntNm;
                }

                if (( String.IsNullOrEmpty(row.triSikiKeyCd) ) && ( !String.IsNullOrEmpty(tempRow.triSikiKeyCd) ))
                {
                    // 取引識別名称（キーコード）.
                    row.triSikiKeyCd = tempRow.triSikiKeyCd;

                    // 取引識別コード.
                    row.triSikiCd = tempRow.triSikiCd;

                    // 取引識別名称.
                    row.triSikiNm = tempRow.triSikiNm;

                    // 指図ＮＯ.
                    row.ssNo = tempRow.ssNo;

                    // セグメントＮＯ.
                    row.segNo = tempRow.segNo;

                    // ソートキー.
                    row.sortKey = tempRow.sortKey;
                }
            }

            // レコードを追加.
            _dsSeikyuDetailEpson.KkhDetail.AddKkhDetailRow(row);
        }
        #endregion 請求回収用明細データ設定処理.

        #region 各ボタンの使用可・不可設定を制御する.
        /// <summary>
        /// 各ボタンの使用可・不可設定を制御する.
        /// </summary>
        private void SetButtonEnable()
        {
            // 処理対象が広告費側データの場合.
            if (isActivatedJyutyuList())
            {
                if (_dsDetail.JyutyuList.Rows.Count != 0)
                {
                    btnYmChange.Enabled = true;
                    btnRegJyutyu.Enabled = true;
                    btnDelJyutyu.Enabled = true;
                    btnUpdateCheck.Enabled = true;
                    btnRegister.Enabled = true;
                    btnRegBulk.Enabled = true;
                    btnReqBind.Enabled = false;
                    btnDetailRegister.Enabled = true;
                    btnMerge.Enabled = true;
                    btnMergeCancel.Enabled = true; 
                }
                else
                {
                    btnYmChange.Enabled = false;
                    btnRegJyutyu.Enabled = false;
                    btnDelJyutyu.Enabled = false;
                    btnUpdateCheck.Enabled = false;
                    btnRegister.Enabled = false;
                    btnRegBulk.Enabled = false;
                    btnReqBind.Enabled = false;
                    btnDetailRegister.Enabled = false;
                    btnMerge.Enabled = false;
                    btnMergeCancel.Enabled = false; 
                }
            }
            // 処理対象が請求回収側データの場合.
            else if (isActivatedSeikyuList())
            {
                if (_dsSeikyuEpson.SeikyuHeader.Rows.Count != 0)
                {
                    btnYmChange.Enabled = false;
                    btnRegJyutyu.Enabled = false;
                    btnDelJyutyu.Enabled = false;
                    btnUpdateCheck.Enabled = false;
                    btnRegister.Enabled = true;
                    btnRegBulk.Enabled = false;
                    btnReqBind.Enabled = true;
                    btnDetailRegister.Enabled = true;
                    btnMerge.Enabled = false;
                    btnMergeCancel.Enabled = false;
                }
                else
                {
                    btnYmChange.Enabled = false;
                    btnRegJyutyu.Enabled = false;
                    btnDelJyutyu.Enabled = false;
                    btnUpdateCheck.Enabled = false;
                    btnRegister.Enabled = false;
                    btnRegBulk.Enabled = false;
                    btnReqBind.Enabled = false;
                    btnDetailRegister.Enabled = false;
                    btnMerge.Enabled = false;
                    btnMergeCancel.Enabled = false;
                }
            }

            // 広告費明細データがある場合 
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                btnDetailInput.Enabled = true;
                btnDetailDel.Enabled = true;
            }
            //広告費明細データがない場合 
            else
            {
                btnDetailInput.Enabled = false;
                btnDetailDel.Enabled = false;
            }
        }
        #endregion 各ボタンの使用可・不可設定を制御する.

        #region データソースを更新します.
        /// <summary>
        /// データソースを更新します.
        /// </summary>
        /// <param name="dsDetail">広告費明細入力データセット</param>
        private void UpdateDataSourceByDetail(Isid.KKH.Common.KKHSchema.Detail dsDetail)
        {
            _dsDetail.Clear();
            _dsDetail.Merge(dsDetail);
            _dsDetail.AcceptChanges();
        }
        #endregion データソースを更新します.

        #region 請求回収データ検索・表示処理.
        /// <summary>
        /// 請求回収データ検索・表示処理.
        /// </summary>
        ///// <param name="reLoadFlag">再検索フラグ(True：再検索、False：通常検索)</param>
        protected void SearchSeikyuKaisyuData()
        {
            //検索条件の取得.
            findSeikyuKaisyuDataCond = CreateServiceParamForFindSeikyuKaisyuDataByCond();

            DetailEpsonProcessController controller = DetailEpsonProcessController.GetInstance();
            findSeikyuKaisyuDataCond.updateCheckFlag = false;
            FindSeikyuDataEpsonByCondServiceResult result = controller.FindSeikyuKaisyuDataByCond(findSeikyuKaisyuDataCond);
            Isid.KKH.Epson.Schema.SeikyuDsEpson dsSeikyu = result.SeikyuEpsonDataSet;
            dsSeikyu.UpdateSpdDataBySeikyuData();

            {
                // 請求リストをヘッダ毎にまとめる 
                String seikyuNoKey = null;
                SeikyuDsEpson ds = new SeikyuDsEpson();
                SeikyuDsEpson.SeikyuHeaderRow seikyuHeaderRow = null;

                foreach (SeikyuDsEpson.SeikyuListRow seikyuListRow in dsSeikyu.SeikyuList)
                {
                    if (String.Equals(seikyuListRow.seikyuNo, seikyuNoKey))
                    {
                        continue;
                    }

                    if (seikyuNoKey != null)
                    {
                        ds.SeikyuHeader.AddSeikyuHeaderRow(seikyuHeaderRow);
                    }

                    // 新規レコードの作成.
                    seikyuHeaderRow = ds.SeikyuHeader.NewSeikyuHeaderRow();

                    // 請求書番号.
                    seikyuHeaderRow.seikyuNo = seikyuListRow.seikyuNo;

                    // 件名.
                    seikyuHeaderRow.kenmei = seikyuListRow.kenmei;

                    // 金額（税込み）.
                    seikyuHeaderRow.seiKingakuGk = seikyuListRow.seiKingakuGk;

                    // 消費税額.
                    seikyuHeaderRow.zeiGakuGk = seikyuListRow.zeiGakuGk;

                    // 金額（税抜き）.
                    seikyuHeaderRow.zeiNKingakuGk = seikyuListRow.zeiNKingakuGk;

                    // 計上日.
                    seikyuHeaderRow.keiYymm = seikyuListRow.keiYymm;

                    // 請求ステータス.
                    seikyuHeaderRow.seiStatus = seikyuListRow.seiStatus;

                    // キーの更新.
                    seikyuNoKey = seikyuListRow.seikyuNo;

                    // 反映マーク.
                    {
                        if( _dsSeikyuDetailEpson.KkhDetail.Select("seiNo = '" + seikyuListRow.seikyuNo + "'", "").Length != 0 )
                        {
                            seikyuHeaderRow.hannei = "済";
                        }
                        else
                        {
                            seikyuHeaderRow.hannei = "";
                        }
                    }
                }

                if (seikyuNoKey != null)
                {
                    ds.SeikyuHeader.AddSeikyuHeaderRow(seikyuHeaderRow);
                }

                dsSeikyu.SeikyuHeader.Merge(ds.SeikyuHeader);
            }

            //データソース更新 .
            UpdateDataSourceBySeikyuDataSetEpson(dsSeikyu);

            //ソートインジケータのリセット.
            ResetSortIndicator(_spdSeikyuList_Sheet1);

            InitDesignForSpdSeikyuListChild();

            // リスト初期化.
            seiNoList = new List<string>();

            // 色変更.
            for (int i = 0; i < _spdSeikyuList_Sheet1.Rows.Count; i++)
            {
                if (_spdSeikyuList_Sheet1.Cells[i, 7].Text.Equals("3"))
                {
                    // 請求ステータスが3(取消)の場合は背景色を変更 .
                    _spdSeikyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(165, 165, 165);
                    // 請求書番号をリストに追加.
                    seiNoList.Add(_spdSeikyuList_Sheet1.Cells[i, COLIDX_SHLIST_SEIKYUNO].Text);
                }

                FarPoint.Win.Spread.SheetView s;
                //各親行に関連する子ビューを取得します .
                s = _spdSeikyuList_Sheet1.GetChildView(i, 0);
                for (int j = 0; j < s.Rows.Count; j++)
                {
                    if (s.Cells[j, 12].Text.Equals("3"))
                    {
                        // 請求ステータスが3(取消)の場合は背景色を変更 .
                        s.Rows[j].BackColor = Color.FromArgb(165, 165, 165);
                        // 請求書番号をリストに追加.
                        seiNoList.Add(_spdSeikyuList_Sheet1.Cells[i, COLIDX_SHLIST_SEIKYUNO].Text);
                    }
                }
            }
        }
        #endregion 請求回収データ検索・表示処理.

        #region 請求リスト子ビューのスプレッド情報.
        /// <summary>
        /// 請求リスト子ビューのスプレッド情報.
        /// </summary>
        private void InitDesignForSpdSeikyuListChild()
        {
            for (int i = 0; i < _spdSeikyuList_Sheet1.RowCount; i++)
            {
                FarPoint.Win.Spread.SheetView sheet = _spdSeikyuList_Sheet1.GetChildView(i, 0);

                sheet.DataAutoSizeColumns = _spdSeikyuList_Sheet1.DataAutoSizeColumns;
                sheet.DataAutoCellTypes = _spdSeikyuList_Sheet1.DataAutoCellTypes;
                sheet.ActiveSkin = _spdSeikyuList_Sheet1.ActiveSkin;

                sheet.ColumnHeader.Rows[0].Height = 30F;

                sheet.Columns[COLIDX_SCLIST_HANNEI].DataField = "hannei";
                sheet.Columns[COLIDX_SCLIST_HANNEI].Label = "反映";
                sheet.Columns[COLIDX_SCLIST_HANNEI].Width = 20F;
                sheet.Columns[COLIDX_SCLIST_HANNEI].Locked = true;
                sheet.Columns[COLIDX_SCLIST_HANNEI].Visible = false;
                sheet.Columns[COLIDX_SCLIST_HANNEI].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                sheet.Columns[COLIDX_SCLIST_HANNEI].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_SEIKYUNO].DataField = "seikyuNo";
                sheet.Columns[COLIDX_SCLIST_SEIKYUNO].Label = "請求書番号";
                sheet.Columns[COLIDX_SCLIST_SEIKYUNO].Locked = true;
                sheet.Columns[COLIDX_SCLIST_SEIKYUNO].Visible = false;
                sheet.Columns[COLIDX_SCLIST_SEIKYUNO].Width = 120F;
                sheet.Columns[COLIDX_SCLIST_SEIKYUNO].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_SEIKYUMEINO].DataField = "seikyuMeiNo";
                sheet.Columns[COLIDX_SCLIST_SEIKYUMEINO].Label = "請求書\n明細番号";
                sheet.Columns[COLIDX_SCLIST_SEIKYUMEINO].Locked = true;
                sheet.Columns[COLIDX_SCLIST_SEIKYUMEINO].Width = 90F;
                sheet.Columns[COLIDX_SCLIST_SEIKYUMEINO].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_URIMEINO].DataField = "uriMeiNo";
                sheet.Columns[COLIDX_SCLIST_URIMEINO].Label = "売上明細NO";
                sheet.Columns[COLIDX_SCLIST_URIMEINO].Locked = true;
                sheet.Columns[COLIDX_SCLIST_URIMEINO].Width = 150F;
                sheet.Columns[COLIDX_SCLIST_URIMEINO].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_KENMEI].DataField = "kenmei";
                sheet.Columns[COLIDX_SCLIST_KENMEI].Label = "件名";
                sheet.Columns[COLIDX_SCLIST_KENMEI].Locked = true;
                sheet.Columns[COLIDX_SCLIST_KENMEI].Visible = false;
                sheet.Columns[COLIDX_SCLIST_KENMEI].Width = 200F;
                sheet.Columns[COLIDX_SCLIST_KENMEI].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_SEIKINGAKUGK].DataField = "seiKingakuGk";
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKUGK].Label = "金額合計（税込み）";
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKUGK].Locked = true;
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKUGK].Visible = false;
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKUGK].Width = 120F;
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKUGK].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_ZEIGAKUGK].DataField = "zeiGakuGk";
                sheet.Columns[COLIDX_SCLIST_ZEIGAKUGK].Label = "税額合計";
                sheet.Columns[COLIDX_SCLIST_ZEIGAKUGK].Locked = true;
                sheet.Columns[COLIDX_SCLIST_ZEIGAKUGK].Visible = false;
                sheet.Columns[COLIDX_SCLIST_ZEIGAKUGK].Width = 100F;
                sheet.Columns[COLIDX_SCLIST_ZEIGAKUGK].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKUGK].DataField = "zeiNKingakuGk";
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKUGK].Label = "税抜き金額合計";
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKUGK].Locked = true;
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKUGK].Visible = false;
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKUGK].Width = 100F;
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKUGK].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_SEIKINGAKU].DataField = "seiKingaku";
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKU].Label = "金額（税込み）";
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKU].Locked = true;
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKU].Width = 100F;
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKU].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_ZEIGAKU].DataField = "zeiGaku";
                sheet.Columns[COLIDX_SCLIST_ZEIGAKU].Label = "税額";
                sheet.Columns[COLIDX_SCLIST_ZEIGAKU].Locked = true;
                sheet.Columns[COLIDX_SCLIST_ZEIGAKU].Width = 100F;
                sheet.Columns[COLIDX_SCLIST_ZEIGAKU].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKU].DataField = "zeiNKingaku";
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKU].Label = "税抜き金額";
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKU].Locked = true;
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKU].Width = 100F;
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKU].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_KEIYYMM].DataField = "keiYymm";
                sheet.Columns[COLIDX_SCLIST_KEIYYMM].Label = "計上日";
                sheet.Columns[COLIDX_SCLIST_KEIYYMM].Locked = true;
                sheet.Columns[COLIDX_SCLIST_KEIYYMM].Width = 100F;
                sheet.Columns[COLIDX_SCLIST_KEIYYMM].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_SEISTATUS].DataField = "seistatus";
                sheet.Columns[COLIDX_SCLIST_SEISTATUS].Label = "請求ステータス";
                sheet.Columns[COLIDX_SCLIST_SEISTATUS].Locked = true;
                sheet.Columns[COLIDX_SCLIST_SEISTATUS].Visible = false;
                sheet.Columns[COLIDX_SCLIST_SEISTATUS].Width = 100F;
                sheet.Columns[COLIDX_SCLIST_SEISTATUS].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                foreach( FarPoint.Win.Spread.Row row in sheet.Rows )
                {
                    FarPoint.Win.Spread.CellType.NumberCellType cellTypeNumber = new FarPoint.Win.Spread.CellType.NumberCellType();

                    cellTypeNumber.DecimalPlaces = 0;
                    cellTypeNumber.Separator = ",";
                    cellTypeNumber.ShowSeparator = true;

                    sheet.Cells[ row.Index, COLIDX_SCLIST_SEIKINGAKUGK ].CellType = cellTypeNumber;
                    sheet.Cells[ row.Index, COLIDX_SCLIST_ZEIGAKUGK    ].CellType = cellTypeNumber;
                    sheet.Cells[ row.Index, COLIDX_SCLIST_ZEINKINGAKUGK].CellType = cellTypeNumber;
                    sheet.Cells[ row.Index, COLIDX_SCLIST_SEIKINGAKU   ].CellType = cellTypeNumber;
                    sheet.Cells[ row.Index, COLIDX_SCLIST_ZEIGAKU      ].CellType = cellTypeNumber;
                    sheet.Cells[ row.Index, COLIDX_SCLIST_ZEINKINGAKUGK].CellType = cellTypeNumber;
                }
            }
        }
        #endregion 請求リスト子ビューのスプレッド情報.

        #region 請求回収データ検索API実行パラメータ生成.
        /// <summary>
        /// 請求回収データ検索API実行パラメータ生成.
        /// </summary>
        /// <returns></returns>
        protected virtual DetailEpsonProcessController.FindSeikyuKaisyuDataByCondParam CreateServiceParamForFindSeikyuKaisyuDataByCond()
        {
            DetailEpsonProcessController.FindSeikyuKaisyuDataByCondParam param = new DetailEpsonProcessController.FindSeikyuKaisyuDataByCondParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = txtYmd.Value;

            return param;
        }
        #endregion 請求回収データ検索API実行パラメータ生成.

        #region 請求回収のデータソース更新.
        /// <summary>
        /// 請求回収のデータソース更新.
        /// </summary>
        /// <param name="dsDetailEpson"></param>
        private void UpdateDataSourceBySeikyuDataSetEpson(SeikyuDsEpson dsSeikyuEpson)
        {
            _dsSeikyuEpson.Clear();
            _dsSeikyuEpson.Merge(dsSeikyuEpson);
            _dsSeikyuEpson.AcceptChanges();
        }
        #endregion 請求回収のデータソース更新.

        #region 指定した受注登録内容(一覧)の行に紐づく検索受注登録内容データを取得する.
        /// <summary>
        /// 指定した受注登録内容(一覧)の行に紐づく検索受注登録内容データを取得する.
        /// </summary>
        /// <param name="rowIndex">受注登録内容(一覧)の行インデックス</param>
        /// <returns></returns>
        protected SeikyuDsEpson.SeikyuHeaderRow getSelectSeikyuHeaderData(int rowIndex)
        {
            if (rowIndex < 0)
            {
                rowIndex = _spdSeikyuList_Sheet1.ActiveRowIndex;
            }

            String seikyuNo = _spdSeikyuList_Sheet1.Cells[rowIndex, COLIDX_SHLIST_SEIKYUNO].Text;

            return (SeikyuDsEpson.SeikyuHeaderRow)( _dsSeikyuEpson.SeikyuHeader.Select("seikyuNo = '" + seikyuNo + "'")[0] );
        }
        #endregion 指定した受注登録内容(一覧)の行に紐づく検索受注登録内容データを取得する.

        #region 受注リストがアクティブかを返す.
        /// <summary>
        /// 受注リストがアクティブかを返す.
        /// </summary>
        /// <returns></returns>
        private Boolean isActivatedJyutyuList()
        {
            return
            (
                ( tabHed.SelectedIndex == 0 ) ||
                ( tabHed.SelectedIndex == 1 )
            );
        }
        #endregion 受注リストがアクティブかを返す.

        #region 請求回収リストがアクティブかを返す.
        /// <summary>
        /// 請求回収リストがアクティブかを返す.
        /// </summary>
        /// <returns></returns>
        private Boolean isActivatedSeikyuList()
        {
            return
            (
                ( tabHed.SelectedIndex == 2 )
            );
        }
        #endregion 請求回収リストがアクティブかを返す.

        #region データ行内のDBNullを空文字か0に変換する.
        /// <summary>
        /// データ行内のDBNullを空文字か0に変換する.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        private void DBNullToEmptyOrZero(DetailDSEpson.KkhDetailRow to, DetailDSEpson.KkhDetailRow from)
        {
            object[] values = new object[from.ItemArray.Length];

            for (int i = 0; i < from.ItemArray.Length; i++)
            {
                if (from.ItemArray[i] == DBNull.Value)
                {
                    if (from.Table.Columns[i].DataType.FullName == typeof(String).FullName)
                    {
                        values[i] = String.Empty;
                    }
                    else if (from.Table.Columns[i].DataType.FullName == typeof(Decimal).FullName)
                    {
                        values[i] = 0M;
                    }
                }
                else
                {
                    values[i] = from.ItemArray[i];
                }
            }

            to.ItemArray = values;
        }
        #endregion データ行内のDBNullを空文字か0に変換する.

        #region ソートインジケータのリセット.
        /// <summary>
        /// ソートインジケータのリセット.
        /// </summary>
        /// <param name="view"></param>
        private void ResetSortIndicator(SheetView view)
        {
            view.Models.ResetViewRowIndexes();

            foreach (FarPoint.Win.Spread.Column column in view.Columns)
            {
                column.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            }
        }
        #endregion ソートインジケータのリセット.

        /* 2015/04/06 エプソン件名拡張対応 HLC K.Fujisaki ADD Start */
        #region 桁数チェック(バイト).
        /// <summary>
        /// 桁数チェック(バイト).
        /// </summary>
        /// <param name="colIdx">カラム(件名)</param>
        /// <returns>true:正常　false:エラー</returns>
        private bool CheckByteLength(int colIdx)
        {
            //初期設定.
            string errMsg = string.Empty;
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            //シートの行数分ループ.
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                String checkData = _spdKkhDetail_Sheet1.Cells[i, colIdx].Text;

                //件名チェック(100バイト以下なら問題無し).
                if (sjisEnc.GetByteCount(checkData) > 100)
                {
                    int rowCount = i + 1;

                    //エラーメッセージを表示して、falseを返す.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new String[] { errMsg }, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                    return false;
                }
            }

            //正常終了時はtrueを返す.
            return true;
        }
        #endregion 桁数チェック(バイト).
        /* 2015/04/06 エプソン件名拡張対応 HLC K.Fujisaki ADD End */
        #endregion メソッド.
    }
}