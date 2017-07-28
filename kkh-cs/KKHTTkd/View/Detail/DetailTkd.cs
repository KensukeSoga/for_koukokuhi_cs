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
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Tkd.Schema;
using Isid.KKH.Tkd.ProcessController.Detail;
using Isid.KKH.Tkd.Utility;
using System.Text.RegularExpressions;
using System.Collections;

namespace Isid.KKH.Tkd.View.Detail
{
    /// <summary>
    /// 広告費明細入力画面（武田薬品） 
    /// </summary>
    public partial class DetailTkd : DetailForm
    {
        #region 定数

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "DtlTkd";

        /// <summary>
        /// 年月列インデックス 
        /// </summary>
        private const int COLIDX_MLIST_NENGETSU = 0;
        /// <summary>
        /// 中分類列インデックス 
        /// </summary>
        private const int COLIDX_MLIST_TYUBUNRUI = 1;
        /// <summary>
        /// 媒体名列インデックス 
        /// </summary>
        private const int COLIDX_MLIST_BAITAINM = 2;
        /// <summary>
        /// 実施No列インデックス 
        /// </summary>
        private const int COLIDX_MLIST_JISHINO = 3;
        /// <summary>
        /// 配分率列インデックス 
        /// </summary>
        private const int COLIDX_MLIST_HAIBUNRITSU = 4;
        /// <summary>
        /// 金額列インデックス 
        /// </summary>
        private const int COLIDX_MLIST_KINGAKU = 5;
        /// <summary>
        /// 商品名列インデックス 
        /// </summary>
        private const int COLIDX_MLIST_SHOHINNM = 6;
        /// <summary>
        /// 管理区分列インデックス 
        /// </summary>
        private const int COLIDX_MLIST_KANRIKBN = 7;
        /// <summary>
        /// 支払いサイト列インデックス 
        /// </summary>
        private const int COLIDX_MLIST_SHIHARAISITE = 8;
        /// <summary>
        /// 摘要列インデックス 
        /// </summary>
        private const int COLIDX_MLIST_TEKIYOU = 9;
        /// <summary>
        /// ステータス列インデックス 
        /// </summary>
        private const int COLIDX_MLIST_STATUS = 10;
        /// <summary>
        /// 区分列インデックス 
        /// </summary>
        private const int COLIDX_MLIST_KBN = 11;
        /// <summary>
        /// 値引率列インデックス 
        /// </summary>
        private const int COLIDX_MLIST_NRITU = 12;
        /// <summary>
        /// 値引額列インデックス 
        /// </summary>
        private const int COLIDX_MLIST_NGAK = 13;
        /// <summary>
        /// 値引後額列インデックス 
        /// </summary>
        private const int COLIDX_MLIST_NKGAK = 14;

        /// <summary>
        /// 媒体マスタ取得キー：0001 
        /// </summary>
        private const string MST_BAITAI = "0001";
        /// <summary>
        /// 商品マスタ取得キー：0002 
        /// </summary>
        private const string MST_SHOHIN = "0002";
        /// <summary>
        /// 中分類マスタ取得キー：0004 
        /// </summary>
        private const string MST_TYUBUNRUI = "0004";
        /// <summary>
        /// 中分類紐付けマスタ取得キー：0005 
        /// </summary>
        private const string MST_TYUBUNRUI_HIMOZUKE = "0005";

        /// <summary>
        /// 管理区分コンボボックスの項目（コード）1：原価 
        /// </summary>
        private const int COMBO_CODE_KBN_GEN = 1;
        /// <summary>
        /// 管理区分コンボボックスの項目（コード）2：フィー 
        /// </summary>
        private const int COMBO_CODE_KBN_FEE = 2;
        /// <summary>
        /// 管理区分コンボボックスの項目（名称）1：原価 
        /// </summary>
        private const string COMBO_NAME_KBN_GEN = "原価";
        /// <summary>
        /// 管理区分コンボボックスの項目（名称）2：フィー 
        /// </summary>
        private const string COMBO_NAME_KBN_FEE = "フィー";
        /// <summary>
        /// 管理区分コンボボックスの項目（インデックス）0：原価 
        /// </summary>
        private const int COMBO_IDX_KBN_GEN = 0;
        /// <summary>
        /// 管理区分コンボボックスの項目（インデックス）1：フィー 
        /// </summary>
        private const int COMBO_IDX_KBN_FEE = 1;

        /// <summary>
        /// ステータスコンボボックスの項目（コード）1：SP 
        /// </summary>
        private const int COMBO_CODE_STS_SP = 1;
        /// <summary>
        /// ステータスコンボボックスの項目（コード）2：MASS 
        /// </summary>
        private const int COMBO_CODE_STS_MASS = 2;
        /// <summary>
        /// ステータスコンボボックスの項目（名称）1：SP 
        /// </summary>
        private const string COMBO_NAME_STS_SP = "SP";
        /// <summary>
        /// ステータスコンボボックスの項目（名称）2：MASS 
        /// </summary>
        private const string COMBO_NAME_STS_MASS = "MASS";
        /// <summary>
        /// ステータスコンボボックスの項目（インデックス）0：SP 
        /// </summary>
        private const int COMBO_IDX_STS_SP = 0;
        /// <summary>
        /// ステータスコンボボックスの項目（インデックス）1：MASS 
        /// </summary>
        private const int COMBO_IDX_STS_MASS = 1;

        /// <summary>
        /// 明細スプレッド＿実施Noの最大値 
        /// </summary>
        private const double MAX_VALUE_JISHINO = 999D;
        /// <summary>
        /// 明細スプレッド＿実施Noの最小値 
        /// </summary>
        private const double MIN_VALUE_JISHINO = 0D;
        /// <summary>
        /// 明細スプレッド＿実施Noのデフォルト値 
        /// </summary>
        private const string DEF_VALUE_JISHINO = "0";

        /// <summary>
        /// 明細スプレッド＿配分率の最大値 
        /// </summary>
        private const double MAX_VALUE_HAIBUNRITSU = 999.99D;
        /// <summary>
        /// 明細スプレッド＿配分率の最小値 
        /// </summary>
        private const double MIN_VALUE_HAIBUNRITSU = -999.99D;
        /// <summary>
        /// 明細スプレッド＿配分率のデフォルト値 
        /// </summary>
        private const string DEF_VALUE_HAIBUNRITSU = "0.00";

        /// <summary>
        /// 明細スプレッド＿金額の最大値 
        /// </summary>
        private const double MAX_VALUE_KINGAKU = 99999999999D;
        /// <summary>
        /// 明細スプレッド＿金額の最小値 
        /// </summary>
        private const double MIN_VALUE_KINGAKU = -99999999999D;
        /// <summary>
        /// 明細スプレッド＿金額のデフォルト値 
        /// </summary>
        private const string DEF_VALUE_KINGAKU = "0";

        /// <summary>
        /// 明細スプレッド＿支払いサイトのデフォルト値 
        /// </summary>
        private const string DEF_VALUE_SHIHARAISITE = "120";

        /// <summary>
        /// 営業所コード：関西 
        /// </summary>
        private const string EGYSHOCD_20 = "20";

        /// <summary>
        /// 処理モード列挙体 
        /// </summary>
        private enum Mode
        {
            /// <summary>
            /// 明細入力:0 
            /// </summary>
            DetailInput = 0,
            /// <summary>
            /// 分割:1 
            /// </summary>
            Divide = 1,
        }

        #endregion 定数

        #region メンバ変数

        /// <summary>
        /// Rgナビパラメータ 
        /// </summary>
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();

        /// <summary>
        /// 中分類マスタ情報（キー） 
        /// </summary>
        private string[] _itemTyubunruiCd = null;

        /// <summary>
        /// 中分類マスタ情報（名称） 
        /// </summary>
        private string[] _itemTyubunruiNm = null;

        /// <summary>
        /// 媒体マスタ情報(全データ) 
        /// ※中分類マスタのコード単位で格納 
        /// </summary>  
        private Dictionary<string, Dictionary<string[], string[]>> _dictBaitai = null;

        /// <summary>
        /// 媒体マスタ情報（キー） 
        /// </summary>
        private string[] _itemBaitaiCd = null;

        /// <summary>
        /// 媒体マスタ情報（名称） 
        /// </summary>
        private string[] _itemBaitaiNm = null;

        /// <summary>
        /// 商品名情報（キー） 
        /// </summary>
        private string[] _itemShohinCd = null;

        /// <summary>
        /// 商品名情報（名称） 
        /// </summary>
        private string[] _itemShohinNm = null;

        /// <summary>
        /// 中分類マスタ情報データセット 
        /// </summary>
        private MasterMaintenance _dsTyubunrui = null;

        /// <summary>
        /// 中分類紐付けマスタ情報データセット 
        /// </summary>
        private MasterMaintenance _dsTyubunruiHimo = null;

        /// <summary>
        /// 文字エンコーディング 
        /// </summary>
        private Encoding _enc = Encoding.GetEncoding("shift-jis");

        /// <summary>
        /// データモデル 
        /// </summary>
        private DefaultSheetDataModel _dataModel;

        /// <summary>
        /// 選択列 
        /// </summary>
        private int _col = 0;

        /// <summary>
        /// 選択行 
        /// </summary>
        private int _row = 0;

        /// <summary>
        /// 実施No
        /// </summary>
        private int jissiNoCnt = 0;

        #endregion メンバ変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public DetailTkd()
        {
            InitializeComponent();
            _dataModel = (DefaultSheetDataModel)_spdKkhDetail_Sheet1.Models.Data;
        }

        #endregion コンストラクタ

        #region オーバーライド

        /// <summary>
        /// スプレッド全体に対する初期表示の設定を行う 
        /// </summary>
        protected override void InitDesignForSpdJyutyuListSpread()
        {
            base.InitDesignForSpdJyutyuListSpread();
        }

        /// <summary>
        /// スプレッドの列に対する初期表示の設定を行う 
        /// </summary>
        /// <param name="col"></param>
        protected override void InitDesignForSpdJyutyuListColumns(Column col)
        {
            base.InitDesignForSpdJyutyuListColumns(col);

            // 消費税率の場合 
            if (col.Index == COLIDX_JLIST_ZEIRITSU)
            {
                NumberCellType cellType = (NumberCellType)col.CellType;
                cellType.DecimalPlaces = 2;
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
                if (col.Index == COLIDX_JLIST_BAITAINM) { col.Visible = false; }                //媒体名(非表示) 
                if (col.Index == COLIDX_JLIST_HIMOKUNM) { col.Visible = true; }                 //費目名 
                if (col.Index == COLIDX_JLIST_KYOKUSHICD) { col.Visible = false; }              //局誌CD(非表示) 
                if (col.Index == COLIDX_JLIST_SEIKINGAKU) { col.Visible = true; }               //請求金額 
                if (col.Index == COLIDX_JLIST_KIKAN) { col.Visible = false; }                   //期間(非表示) 
                if (col.Index == COLIDX_JLIST_DANTANKA) { col.Visible = false; }                //段単価(非表示) 
                if (col.Index == COLIDX_JLIST_DANSU) { col.Visible = false; }                   //段数(非表示) 
                if (col.Index == COLIDX_JLIST_TORIRYOKIN) { col.Visible = true; }               //取料金 
                if (col.Index == COLIDX_JLIST_NEBIKIRITSU) { col.Visible = true; }              //値引率 
                if (col.Index == COLIDX_JLIST_NEBIKIGAKU) { col.Visible = true; }               //値引額 
                if (col.Index == COLIDX_JLIST_ZEIRITSU) { col.Visible = true; }                 //消費税率 
                if (col.Index == COLIDX_JLIST_ZEIGAKU) { col.Visible = true; }                  //消費税額 
                if (col.Index == COLIDX_JLIST_GOUKEIKINGAKU) { col.Visible = false; }           //受注請求金額(非表示) 
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
            _dsDetailTkd.KkhDetail.Clear();

            int rowCnt = 0;
            foreach (Common.KKHSchema.Detail.THB2KMEIRow row in _dsDetail.THB2KMEI.Rows)
            {
                rowCnt = _dsDetailTkd.KkhDetail.Rows.Count;

                DetailDSTkd.KkhDetailRow addrow = _dsDetailTkd.KkhDetail.NewKkhDetailRow();

                addrow.nengetsu = row.hb2Date1;         // 年月 
                addrow.chubunrui = row.hb2Code5;        // 中分類 

                // 媒体名 
                if (!string.IsNullOrEmpty(row.hb2Code5))
                {
                    addrow.baitaiNm = row.hb2Code2;
                }
                else
                {
                    addrow.baitaiNm = string.Empty;
                }

                addrow.jishiNo = row.hb2Kngk1;          // 実施NO 
                addrow.haibunRitsu = row.hb2Ritu1;      // 配分率 
                addrow.kingaku = row.hb2SeiGak;         // 金額 
                addrow.shohinNm = row.hb2Code3;         // 商品名 

                // 管理区分 
                if (!string.IsNullOrEmpty(row.hb2Kbn2))
                {
                    addrow.kanriKbn = row.hb2Kbn2;
                }
                else
                {
                    addrow.kanriKbn = COMBO_CODE_KBN_GEN.ToString();
                }

                addrow.shiharaiSite = row.hb2Code4;     // 支払いサイト 
                addrow.tekiyou = row.hb2Name8;          // 摘要 
                addrow.status = row.hb2Kbn1;            // ステータス 
                addrow.kbn = row.hb2Sonota1;            // 区分 
                addrow.nritu = row.hb2Hnnert;           // 値引率 
                addrow.ngak = row.hb2NebiGak;           // 値引額 
                addrow.nkgak = row.hb2HnmaeGak;         // 値引後額 

                _dsDetailTkd.KkhDetail.AddKkhDetailRow(addrow);
            }

            _dsDetailTkd.KkhDetail.AcceptChanges();

            // 受注登録内容の選択行情報の取得 
            SheetView activeSheet = GetActiveSheetViewBySpdJyutyuList();
            Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(rowIdx);

            //***************************************
            // ボタン類の使用可・不可設定 
            //***************************************
            SetButtonEnable();

            //******************************
            // 差額・計ラベル 
            //******************************
            // 差額計算 
            CalculateSagaku(dataRow);

            //SetDetailDataBaitaiメソッドを実行するために、フォーカスを移動しておく
            //(完全にはずせる方法があればそれで) 
            _spdKkhDetail_Sheet1.SetActiveCell(-1,-1);

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
            InitializeButtonEnable();
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
        /// 受注削除処理実行前チェック 
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
                InitializeButtonEnable();

                //差額・計 
                lblSagakuValue.Text = "0";
                lblGoukeiValue.Text = "0";
            }
        }

        /// <summary>
        /// 年月変更処理実行前チェック 
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
                //受注登録内容検索後の状態にする 
                SetButtonEnable();
            }
            else
            {
                //子ビューにフォーカスがある場合はデータ操作を行うボタンは使用させない 
                InitializeButtonEnable();
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
            KKHLogUtilityTkd.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityTkd.KINO_ID_OPERATION_LOG_UPDCHECK, KKHLogUtilityTkd.DESC_OPERATION_LOG_UPDCHECK);

            return true;
        }

        #endregion オーバーライド

        #region イベント

        /// <summary>
        /// 画面遷移するたびに発生します。 
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void DetailTkd_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParameter = (KKHNaviParameter)arg.NaviParameter;
            }

            //選択状態を解除 
            this.ActiveControl = null;

        }

        /// <summary>
        /// フォームロードイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailTkd_Load(object sender, EventArgs e)
        {
            InitializeControl();
        }

        /// <summary>
        /// フォームShownイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailTkd_Shown(object sender, EventArgs e)
        {
            InitializeDesignForSpdKkhDetail();
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

            // 明細にデータをセットする 
            SetDetailData(dataRow, _spdKkhDetail_Sheet1.ActiveRowIndex, Mode.DetailInput);

            // 広告費明細変更フラグを更新 
            base.kkhDetailUpdFlag = true;

            //******************************
            // 差額・計ラベル 
            //******************************
            // 差額計算 
            CalculateSagaku(dataRow);

            //***************************************
            // ボタン類の使用可・不可設定 
            //***************************************
            SetButtonEnable();
        }

        /// <summary>
        /// 分割ボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDivide_Click(object sender, EventArgs e)
        {
            // 対象の受注データ、明細データ取得 
            Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);

            // 明細にデータをセットする 
            SetDetailData(dataRow, _spdKkhDetail_Sheet1.RowCount, Mode.Divide);

            // 広告費明細変更フラグを更新 
            base.kkhDetailUpdFlag = true;

            //******************************
            // 差額・計ラベル 
            //******************************
            // 差額計算 
            CalculateSagaku(dataRow);

            //選択状態を解除 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 明細削除ボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailDel_Click(object sender, EventArgs e)
        {
            // 選択行の取得 
            CellRange[] cellRanges = _spdKkhDetail_Sheet1.GetSelections();

            if (cellRanges.Length == 0)
            {
                // 明細(一覧)から先頭行を削除する
                _spdKkhDetail_Sheet1.RemoveRows(0, 1);
            }
            else
            {
                int delCnt = 0;
                // 削除した行を明細(一覧)から削除 
                foreach (CellRange cellRange in cellRanges)
                {
                    //選択されている明細内容の行数分の処理を繰り返す 
                    _spdKkhDetail_Sheet1.RemoveRows(cellRange.Row - delCnt, cellRange.RowCount);
                    delCnt = delCnt + cellRange.RowCount;
                }
            }

            //***************************************
            // ボタン類の使用可・不可設定 
            //***************************************
            SetButtonEnable();

            // 対象の受注データ、明細データ取得 
            Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);

            //******************************
            // 差額・計ラベル 
            //******************************
            // 差額計算 
            CalculateSagaku(dataRow);

            // 広告費明細変更フラグを更新 
            base.kkhDetailUpdFlag = true;

            //選択状態を解除 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 明細登録ボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailRegister_Click(object sender, EventArgs e)
        {
            // チェック処理 
            if (!CheckDetailData())
            {
                //選択状態を解除 
                this.ActiveControl = null;

                return;
            }

            decimal sagaku = 0M;

            if (decimal.TryParse(lblSagakuValue.Text, out sagaku) == false || sagaku == 0M)
            {
                if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_C0002, null, 
                    "明細登録", MessageBoxButtons.YesNo))
                {
                    //選択状態を解除 
                    this.ActiveControl = null;

                    return;
                }
            }
            else
            {
                if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_W0089, null, 
                    "明細登録", MessageBoxButtons.YesNo))
                {
                    //選択状態を解除 
                    this.ActiveControl = null;

                    return;
                }
            }

            //登録済みかサーバーでチェック 
            if (!CheckJissiNoComp())
            {
                if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_W0041, null, 
                    "明細登録", MessageBoxButtons.YesNo))
                {
                    //選択状態を解除 
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
        /// 実施NO自動付与ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoNo_Click(object sender, EventArgs e)
        {
            // 検索条件が設定されている場合は処理を終了する 
            if (!string.IsNullOrEmpty(FindJyutyuDataCond.gyomKbn) ||
                !string.IsNullOrEmpty(FindJyutyuDataCond.jyutNo) ||
                !string.IsNullOrEmpty(FindJyutyuDataCond.kokKbn) ||
                !string.IsNullOrEmpty(FindJyutyuDataCond.tmspKbn))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0046,
                                null,
                                "エラー",
                                MessageBoxButtons.OK);

                //選択状態を解除 
                this.ActiveControl = null;

                return;
            }

            //編集中の場合 
            if (base.kkhDetailUpdFlag == true)
            {
                DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0087,
                                    null,
                                    "エラー",
                                    MessageBoxButtons.YesNo);
                //付与をキャンセル
                if (check == DialogResult.No)
                {
                    //選択状態を解除 
                    this.ActiveControl = null;

                    return;
                }
            }

            //確認メッセージ 
            if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_C0024, null,
            "実施No付与", MessageBoxButtons.YesNo))
            {
                //選択状態を解除 
                this.ActiveControl = null;

                return;
            }

            base.ShowLoadingDialog();

            //THB2KMEIの取得 
            KKH.Common.KKHSchema.Detail jyuListdt = new Common.KKHSchema.Detail();
            DetailTkdProcessController processController = DetailTkdProcessController.GetInstance();

            //クリエーティブ以外 
            FindJyutyuDataByCondServiceResult resultThb2 = processController.FindThb2Kmei(
                                                                                      _naviParameter.strEsqId,
                                                                                      "00",
                                                                                      _naviParameter.strEgcd,
                                                                                      _naviParameter.strTksKgyCd,
                                                                                      _naviParameter.strTksBmnSeqNo,
                                                                                      _naviParameter.strTksTntSeqNo,
                                                                                      _naviParameter.StrYymm,
                                                                                      "0");
            //FindJyutyuDataByCondServiceResult resultThb2 = processController.FindThb2Kmei(
                                                                                      //_naviParameter.strEsqId,
                                                                                      //"00",
                                                                                      //_naviParameter.strEgcd,
                                                                                      //_naviParameter.strTksKgyCd,
                                                                                      //_naviParameter.strTksBmnSeqNo,
                                                                                      //_naviParameter.strTksTntSeqNo,
                                                                                      //_naviParameter.StrYymm);


            if (resultThb2.HasError)
            {
                base.CloseLoadingDialog();

                DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_E0025,
                                   null,
                                   "エラー",
                                   MessageBoxButtons.OK);

                //選択状態を解除 
                this.ActiveControl = null;

                return;
            }


            //実施Noを初期化 
            jissiNoCnt = 0;

            //業務区分がクリエーティブ以外の件数が0件以上の場合 
            if (resultThb2.DetailDataSet.THB2KMEI.Rows.Count > 0)
            {
                jyuListdt.Clear();
                jyuListdt.THB2KMEI.Merge(resultThb2.DetailDataSet.THB2KMEI);
                jyuListdt.THB2KMEI.AcceptChanges();

                //配分率チェック 
                string urimeino = "";
                string kenNm = "";
                string msgCd = "";
                if (HaibunCheck(jyuListdt, out urimeino, out kenNm, out msgCd))
                //if (HaibunCheck(jyuListdt, out urimeino) == true)
                {
                    base.CloseLoadingDialog();

                    DialogResult check = MessageUtility.ShowMessageBox(msgCd,
                                       new string[] { urimeino, kenNm },
                                       "エラー",
                                       MessageBoxButtons.OK);
                    //DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0073,
                    //                   new string[] { urimeino },
                    //                   "エラー",
                    //                   MessageBoxButtons.OK);
                    //選択状態を解除 
                    this.ActiveControl = null;

                    return;
                }

                //[管理区分]チェック 
                if (ChkKnrKbn(jyuListdt))
                {

                    DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0138,
                                        null,
                                       "ワーニング",
                                       MessageBoxButtons.YesNo);
                    //Noの場合 
                    if (check.Equals(DialogResult.No))
                    {
                        base.CloseLoadingDialog();

                        //選択状態を解除 
                        this.ActiveControl = null;

                        return;
                    }
                }

                //実施No付与 
                SetJissiNo(jyuListdt, false);
            }

            //THB2KMEIの取得 
            KKH.Common.KKHSchema.Detail jyuListdtCreative = new Common.KKHSchema.Detail();
            //クリエーティブ 
            FindJyutyuDataByCondServiceResult resultThb2Creative = processController.FindThb2Kmei(
                                                                                      _naviParameter.strEsqId,
                                                                                      "00",
                                                                                      _naviParameter.strEgcd,
                                                                                      _naviParameter.strTksKgyCd,
                                                                                      _naviParameter.strTksBmnSeqNo,
                                                                                      _naviParameter.strTksTntSeqNo,
                                                                                      _naviParameter.StrYymm,
                                                                                      "1");

            if (resultThb2Creative.HasError)
            {
                base.CloseLoadingDialog();

                DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_E0025,
                                   null,
                                   "エラー",
                                   MessageBoxButtons.OK);

                //選択状態を解除 
                this.ActiveControl = null;

                return;

            }

            //業務区分がクリエーティブ以外の件数が0件以上の場合 
            if (resultThb2Creative.DetailDataSet.THB2KMEI.Rows.Count > 0)
            {

                jyuListdtCreative.Clear();
                jyuListdtCreative.THB2KMEI.Merge(resultThb2Creative.DetailDataSet.THB2KMEI);
                jyuListdtCreative.THB2KMEI.AcceptChanges();

                //配分率チェック 
                string urimeino = "";
                string kenNm = "";
                string msgCd = "";
                if (HaibunCheck(jyuListdtCreative, out urimeino, out kenNm, out msgCd))
                {
                    base.CloseLoadingDialog();

                    DialogResult check = MessageUtility.ShowMessageBox(msgCd,
                                       new string[] { urimeino, kenNm },
                                       "エラー",
                                       MessageBoxButtons.OK);
                    //選択状態を解除 
                    this.ActiveControl = null;

                    return;
                }

                //[管理区分]チェック 
                if (ChkKnrKbn(jyuListdtCreative))
                {
                    DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0138,
                                        null,
                                       "ワーニング",
                                       MessageBoxButtons.YesNo);
                    //Noの場合 
                    if (check.Equals(DialogResult.No))
                    {
                        base.CloseLoadingDialog();

                        //選択状態を解除 
                        this.ActiveControl = null;

                        return;
                    }
                }

                //実施Noを付与(クリエーティブ) 
                SetJissiNo(jyuListdtCreative, true);
            }

            // オペレーションログの出力 
            KKHLogUtilityTkd.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityTkd.KINO_ID_OPERATION_LOG_AUTONO, KKHLogUtilityTkd.DESC_OPERATION_LOG_AUTONO);

            //未編集に設定
            base.kkhDetailUpdFlag = false;

            //現在位置の取得 
            int _spdJyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            //親の受注データ取得処理 
            base.SearchJyutyuData();

            //元の位置に戻す 
            _spdJyutyuList_Sheet1.SetActiveCell(_spdJyutyuListRowIdx, 0, true);
            _spdJyutyuList_Sheet1.AddSelection(_spdJyutyuListRowIdx, -1, 1, -1);
            spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

            //親の処理を呼ぶ(親のLeaveCellイベントが発生しないので) 
            base.DisplayKkhDetail(_spdJyutyuListRowIdx);
            //子の処理を呼ぶ(親↑が呼んでくれないので) 
            DisplayKkhDetail(_spdJyutyuListRowIdx);

            //受注内容検索
            //base.SearchJyutyuData();
            DisplayKkhDetail(_spdJyutyuList_Sheet1.ActiveRowIndex);

            base.CloseLoadingDialog();

            MessageUtility.ShowMessageBox(MessageCode.HB_I0004, null, "完了", MessageBoxButtons.OK);

            //選択状態を解除 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 実施NO自動UP/DOWNクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoUpDown_Click(object sender, EventArgs e)
        {
            // 検索条件が設定されている場合は処理を終了する 
            if (!string.IsNullOrEmpty(FindJyutyuDataCond.gyomKbn) ||
                !string.IsNullOrEmpty(FindJyutyuDataCond.jyutNo) ||
                !string.IsNullOrEmpty(FindJyutyuDataCond.kokKbn) ||
                !string.IsNullOrEmpty(FindJyutyuDataCond.tmspKbn))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0046,
                                null,
                                "エラー",
                                MessageBoxButtons.OK);
                //選択状態を解除 
                this.ActiveControl = null;

                return;
            }

            if (base.kkhDetailUpdFlag == true)
            {
                //編集中の場合 
                DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0134,
                                    null,
                                    "エラー",
                                    MessageBoxButtons.YesNo);

                if (check == DialogResult.No)
                {
                    //選択状態を解除 
                    this.ActiveControl = null;

                    //付与をキャンセル 
                    return;
                }
            }

            //DatailAutoUpDownへ 
            DatailAutoUpDownNaviParameter naviParam = new DatailAutoUpDownNaviParameter();
            naviParam.strEsqId = _naviParameter.strEsqId;
            naviParam.strEgcd = _naviParameter.strEgcd;
            naviParam.strTksKgyCd = _naviParameter.strTksKgyCd;
            naviParam.strTksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            naviParam.strTksTntSeqNo = _naviParameter.strTksTntSeqNo;
            naviParam.StrYymm = _naviParameter.StrYymm;
            naviParam.strName = _naviParameter.strName;

            object ret = Navigator.ShowModalForm(this, "toDatailAutoUpDown", naviParam);
            if (ret != null)
            {

                base.ShowLoadingDialog();

                //未編集に設定
                base.kkhDetailUpdFlag = false;

                //受注内容検索 
                //base.SearchJyutyuData();
                this.Refresh();

                //現在位置の取得 
                int _spdJyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

                base.SearchJyutyuData();

                //元の位置に戻す 
                _spdJyutyuList_Sheet1.SetActiveCell(_spdJyutyuListRowIdx, 0, true);
                _spdJyutyuList_Sheet1.AddSelection(_spdJyutyuListRowIdx, -1, 1, -1);
                spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

                //親の処理を呼ぶ(親のLeaveCellイベントが発生しないので) 
                base.DisplayKkhDetail(_spdJyutyuListRowIdx);
                //子の処理を呼ぶ(親↑が呼んでくれないので) 
                DisplayKkhDetail(_spdJyutyuListRowIdx);

                //ローディング表示終了 
                base.CloseLoadingDialog();

                MessageUtility.ShowMessageBox(MessageCode.HB_I0004, null, "完了", MessageBoxButtons.OK);
            }

            //選択状態を解除 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 明細スプレッド内のセルでテキストを変更するときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_EditChange(object sender, EditorNotifyEventArgs e)
        {
            switch (e.Column)
            {
                case COLIDX_MLIST_TYUBUNRUI:    // 中分類 
                    SetDetailDataBaitai(e.Row, true);
                    break;

                case COLIDX_MLIST_KANRIKBN:     // 管理区分 
                    SetDetailDataJissiNo(e.Row);
                    break;

                case COLIDX_MLIST_STATUS:       // ステータス 
                    SetDetailDataKbn(e.Row);
                    break;

                case COLIDX_MLIST_TEKIYOU:      // 摘要 
                    // TextCellTypeの場合は最大バイト数の編集処理を行う 
                    if (_spdKkhDetail_Sheet1.Columns[e.Column].CellType is TextCellType)
                    {
                        TextCellType tc = (TextCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;
                        string s = e.EditingControl.Text;
                        if (_enc.GetByteCount(s) > tc.MaxLength)
                        {
                            e.EditingControl.Text = _enc.GetString(_enc.GetBytes(s), 0, tc.MaxLength);
                            ((GeneralEditor)e.EditingControl).SelectionStart = e.EditingControl.Text.Length;
                        }
                    }
                    break;

                default:
                    break;
            }

            // 広告費明細変更フラグを更新 
            base.kkhDetailUpdFlag = true;
        }

        /// <summary>
        /// 明細スプレッド内のセルでフォーカスを移動するときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_EnterCell(object sender, EnterCellEventArgs e)
        {
            _col = e.Column;
            _row = e.Row;

            switch (e.Column)
            {
                case COLIDX_MLIST_BAITAINM:     // 媒体名 
                    SetDetailDataBaitai(e.Row, false);
                    break;

                case COLIDX_MLIST_TEKIYOU:      // 摘要 
                    _dataModel.Changed += new SheetDataModelEventHandler(dataModel_Changed);
                    break;

                default:
                    break;
            }

        }

        /// <summary>
        /// 明細スプレッドの編集モードが終了するときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_EditModeOff(object sender, EventArgs e)
        {
            _col = _spdKkhDetail_Sheet1.ActiveColumnIndex;
            _row = _spdKkhDetail_Sheet1.ActiveRowIndex;

            Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);

            switch (_col)
            {
                case COLIDX_MLIST_JISHINO:      // 実施No 

                    // 値が空文字、Nullの場合、デフォルト値を設定する 
                    if (_spdKkhDetail_Sheet1.Cells[_row, _col].Value == null ||
                        string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[_row, _col].Text))
                    {
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Value = DEF_VALUE_JISHINO;
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Text = DEF_VALUE_JISHINO.ToString();
                    }
                    break;

                case COLIDX_MLIST_HAIBUNRITSU:  // 配分率 

                    // 値が空文字、Nullの場合、デフォルト値を設定する 
                    if (_spdKkhDetail_Sheet1.Cells[_row, _col].Value == null ||
                        string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[_row, _col].Text))
                    {
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Value = DEF_VALUE_HAIBUNRITSU;
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Text = DEF_VALUE_HAIBUNRITSU.ToString();
                    }

                    // 値引後額再計算 
                    CalculateNebikiSogak(dataRow);

                    // 差額計算 
                    CalculateSagaku(dataRow);
                    break;

                case COLIDX_MLIST_KINGAKU:      // 金額 

                    // 値が空文字、Nullの場合、デフォルト値を設定する 
                    if (_spdKkhDetail_Sheet1.Cells[_row, _col].Value == null ||
                        string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[_row, _col].Text))
                    {
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Value = DEF_VALUE_KINGAKU;
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Text = DEF_VALUE_KINGAKU.ToString();
                    }

                    // 値引後額再計算 
                    CalculateNebikiSogak(dataRow);

                    // 差額計算 
                    CalculateSagaku(dataRow);
                    break;

                case COLIDX_MLIST_TEKIYOU:      // 摘要 
                    _dataModel.Changed -= new SheetDataModelEventHandler(dataModel_Changed);
                    break;

                default:
                    break;
            }

        }

        /// <summary>
        /// データモデルChangedイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataModel_Changed(object sender, SheetDataModelEventArgs e)
        {
            //非編集状態でクリップボードから貼り付けした場合 
            if (e.Type == SheetDataModelEventType.CellsUpdated)
            {
                try
                {
                    // TextCellTypeの場合のみ処理を行う 
                    if (_spdKkhDetail_Sheet1.Columns[e.Column].CellType is TextCellType)
                    {
                        TextCellType tc = (TextCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;
                        string s = _dataModel.GetValue(e.Row, e.Column).ToString();
                        if (_enc.GetByteCount(s) > tc.MaxLength)
                        {
                            s = KKHUtility.GetByteString(s, tc.MaxLength);
                            _dataModel.SetValue(e.Row, e.Column, s);
                        }
                    }
                }
                catch
                {
                    // 何もしない 
                }
            }
        }


        /// <summary>
        /// ヘルプボタンクリック処理 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //HlpClick();
            //得意先コード 
            string tkskgy = _naviParameter.strTksKgyCd
                + _naviParameter.strTksBmnSeqNo
                + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();

            //実行 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Detail, this, HelpNavigator.KeywordIndex);
        }

        #endregion イベント

        #region メソッド

        /// <summary>
        /// 差額計算 
        /// </summary>
        /// <param name="dataRow">受注データ</param>
        private void CalculateSagaku(Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            // 料金合計 
            decimal ryoukinGoukei = 0;

            // 明細の件数分、繰り返す 
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                String ryoukinStr = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KINGAKU].Text.Trim();
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
        /// 値引後額の再計算 
        /// </summary>
        /// <param name="dataRow">受注データ</param>
        private void CalculateNebikiSogak(Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            // 値引後額再計算（請求金額 - 値引額） 
            decimal sogak = dataRow.hb1SeiGak;
            decimal nebikiGak = (decimal)_spdKkhDetail_Sheet1.Cells[_row, COLIDX_MLIST_NGAK].Value;
            decimal nebikiSogak = sogak - nebikiGak;
            _spdKkhDetail_Sheet1.Cells[_row, COLIDX_MLIST_NKGAK].Value = nebikiSogak;
        }

        /// <summary>
        /// 各コントロールの初期設定 
        /// </summary>
        private void InitializeControl()
        {
            //******************
            //検索条件部 
            //******************
            lblKenMei.Visible = false;
            txtKenMei.Visible = false;
            lblKikan.Visible = false;
            txtYmdTo.Visible = false;


            //ボタン 
            InitializeButtonEnable();

            //マスタ情報を取得する 
            GetMasterData();

            //スプレッドの入力マップ設定 
            InputMap im = new InputMap();

            //非編集セルでの[F2]キーを無効 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);

            //編集中セルでの[F2]キーを無効 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);

            //非編集セルでの[Enter]キーを「次行へ移動」 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow);

            //編集中セルでの[Enter]キーを「次行へ移動」 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow);

            // 非編集セルでの[Z]キー+[Control]キーを無効 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.Z, Keys.Control), SpreadActions.None);

            // 編集中セルでの[Z]キー+[Control]キーを無効 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Z, Keys.Control), SpreadActions.None);
        }

        /// <summary>
        /// 各ボタンを非活性にする 
        /// </summary>
        private void InitializeButtonEnable()
        {
            btnDetailInput.Enabled = false;
            btnDivide.Enabled = false;
            btnDetailDel.Enabled = false;
            btnDetailRegister.Enabled = false;
            btnAutoNo.Enabled = false;
            btnAutoUpDown.Enabled = false;
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
            //列毎の設定 
            //********************************
            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                //共通設定 
                col.AllowAutoFilter = true;//フィルタ機能を有効 
                col.AllowAutoSort = true;  //ソート機能を有効

                //列毎に異なる設定 
                if (col.Index == COLIDX_MLIST_NENGETSU)
                {
                    TextCellType type = new TextCellType();
                    type.ReadOnly = true;
                    type.Static = true;

                    col.Label = "年月";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 60;
                }
                else if (col.Index == COLIDX_MLIST_TYUBUNRUI)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData = _itemTyubunruiCd;
                    type.Items = _itemTyubunruiNm;
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;

                    col.Label = "中分類";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 200;
                }
                else if (col.Index == COLIDX_MLIST_BAITAINM)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData = _itemBaitaiCd;
                    type.Items = _itemBaitaiNm;
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;

                    col.Label = "媒体名";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 200;
                }
                else if (col.Index == COLIDX_MLIST_JISHINO)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.MaximumValue = MAX_VALUE_JISHINO;
                    type.MinimumValue = MIN_VALUE_JISHINO;
                    type.NullDisplay = DEF_VALUE_JISHINO;
                    type.ShowSeparator = false;

                    col.Label = "実施No";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 100;
                }
                else if (col.Index == COLIDX_MLIST_HAIBUNRITSU)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 2;
                    type.MaximumValue = MAX_VALUE_HAIBUNRITSU;
                    type.MinimumValue = MIN_VALUE_HAIBUNRITSU;
                    type.NullDisplay = DEF_VALUE_HAIBUNRITSU;
                    type.ShowSeparator = false;

                    col.Label = "配分率";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 60;
                }
                else if (col.Index == COLIDX_MLIST_KINGAKU)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.MaximumValue = MAX_VALUE_KINGAKU;
                    type.MinimumValue = MIN_VALUE_KINGAKU;
                    type.NullDisplay = DEF_VALUE_KINGAKU;
                    type.ShowSeparator = true;

                    col.Label = "金額";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 100;
                }
                else if (col.Index == COLIDX_MLIST_SHOHINNM)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData = _itemShohinCd;
                    type.Items = _itemShohinNm;
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;

                    col.Label = "商品名";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 200;
                }
                else if (col.Index == COLIDX_MLIST_KANRIKBN)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData = new string[] { COMBO_CODE_KBN_GEN.ToString()
                                                 , COMBO_CODE_KBN_FEE.ToString() };
                    type.Items = new string[] { COMBO_NAME_KBN_GEN
                                              , COMBO_NAME_KBN_FEE };
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;

                    col.Label = "管理区分";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 60;
                }
                else if (col.Index == COLIDX_MLIST_SHIHARAISITE)
                {
                    TextCellType type = new TextCellType();
                    type.ReadOnly = false;
                    type.Static = false;
                    type.MaxLength = 3;
                    type.CharacterSet = CharacterSet.AlphaNumeric;

                    col.Label = "支払サイト";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 70;
                }
                else if (col.Index == COLIDX_MLIST_TEKIYOU)
                {
                    TextCellType type = new TextCellType();
                    type.ReadOnly = false;
                    type.Static = false;
                    type.MaxLength = 60;
                    type.CharacterSet = CharacterSet.AllIME;

                    col.Label = "摘要";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 400;
                }
                else if (col.Index == COLIDX_MLIST_STATUS)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData = new string[] { COMBO_CODE_STS_SP.ToString() 
                                                 , COMBO_CODE_STS_MASS.ToString() };
                    type.Items = new string[] { COMBO_NAME_STS_SP
                                              , COMBO_NAME_STS_MASS };
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;

                    col.Label = "ステータス";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 70;
                }
                else if (col.Index == COLIDX_MLIST_KBN)
                {
                    TextCellType type = new TextCellType();
                    type.ReadOnly = false;
                    type.Static = false;
                    type.MaxLength = 3;
                    type.CharacterSet = CharacterSet.AlphaNumeric;

                    col.Label = "区分";
                    col.CellType = type;
                    col.Locked = true;
                    col.Width = 60;
                }
                else if (col.Index == COLIDX_MLIST_NRITU)
                {
                    col.Label = "値引率";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == COLIDX_MLIST_NGAK)
                {
                    col.Label = "値引額";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == COLIDX_MLIST_NKGAK)
                {
                    col.Label = "値引後額";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
            }
        }

        /// <summary>
        /// 各ボタンの使用可・不可設定を制御する 
        /// </summary>
        private void SetButtonEnable()
        {
            // 広告費明細データがある場合 
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                // 分割・明細削除・明細登録は可 
                btnDivide.Enabled = true;
                btnDetailDel.Enabled = true;
                btnDetailRegister.Enabled = true;

                // 明細入力は不可 
                btnDetailInput.Enabled = false;
            }
            //広告費明細データがない場合 
            else
            {
                // 分割・明細削除は不可 
                btnDivide.Enabled = false;
                btnDetailDel.Enabled = false;

                // 明細入力・明細登録は可 
                btnDetailInput.Enabled = true;
                btnDetailRegister.Enabled = true;
            }

            bool torokuFlg = false;
            for (int iRow = 0; iRow < _spdJyutyuList_Sheet1.Rows.Count; iRow++)
            {
                // 明細登録済の受注データが存在する場合 
                if (_spdJyutyuList_Sheet1.Cells[iRow, COLIDX_JLIST_TOROKU].Text != "")
                {
                    torokuFlg = true;
                    break;
                }
            }

            // 実施No自動付与、実施NoUP/DOWNボタンを使用可にする 
            if (torokuFlg)
            {
                btnAutoNo.Enabled = true;
                btnAutoUpDown.Enabled = true;
            }
            else
            {
                btnAutoNo.Enabled = false;
                btnAutoUpDown.Enabled = false;
            }
        }

        /// <summary>
        /// マスタ情報を取得する 
        /// </summary>
        private void GetMasterData()
        {
            MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result;
            MasterMaintenance ds;
            MasterMaintenance.MasterDataVORow[] rows;

            List<string> lstKeys;
            List<string> lstValues;

            #region 中分類コンボボックスの値取得.

            // 中分類マスタ情報取得.
            result = process.FindMasterByCond(_naviParameter.strEsqId,
                                            _naviParameter.strEgcd,
                                            _naviParameter.strTksKgyCd,
                                            _naviParameter.strTksBmnSeqNo,
                                            _naviParameter.strTksTntSeqNo,
                                            MST_TYUBUNRUI,
                                            null);
            _dsTyubunrui = result.MasterDataSet;
            rows = (MasterMaintenance.MasterDataVORow[])_dsTyubunrui.MasterDataVO.Select();

            lstKeys = new List<string>();
            lstValues = new List<string>();
            lstKeys.Add(string.Empty);
            lstValues.Add(string.Empty);

            _dictBaitai = new Dictionary<string, Dictionary<string[], string[]>>();

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                lstKeys.Add(row.Column1);
                lstValues.Add(row.Column2);

                _dictBaitai.Add(row.Column1, null);
            }

            // 中分類マスタ情報設定.
            _itemTyubunruiCd = lstKeys.ToArray();
            _itemTyubunruiNm = lstValues.ToArray();

            #endregion 中分類コンボボックスの値取得.

            #region 媒体名コンボボックスの値取得.

            // 媒体名取得.
            result = process.FindMasterByCond(_naviParameter.strEsqId,
                                            _naviParameter.strEgcd,
                                            _naviParameter.strTksKgyCd,
                                            _naviParameter.strTksBmnSeqNo,
                                            _naviParameter.strTksTntSeqNo,
                                            MST_BAITAI,
                                            null);
            ds = result.MasterDataSet;
            rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();

            if (0 < rows.Length)
            {
                List<string> lstKeysAll;
                List<string> lstValuesAll;
                Dictionary<string[], string[]> dict;

                lstKeys = new List<string>();
                lstValues = new List<string>();
                lstKeysAll = new List<string>();
                lstValuesAll = new List<string>();

                string key = rows[0].Column1;

                foreach (MasterMaintenance.MasterDataVORow row in rows)
                {
                    if (!key.Equals(row.Column1))
                    {
                        dict = new Dictionary<string[], string[]>();
                        dict.Add(lstKeys.ToArray(), lstValues.ToArray());

                        _dictBaitai[key] = dict;

                        lstKeys = new List<string>();
                        lstValues = new List<string>();
                    }

                    lstKeys.Add(row.Column2);
                    lstValues.Add(row.Column3);
                    lstKeysAll.Add(row.Column2);
                    lstValuesAll.Add(row.Column3);

                    key = row.Column1;
                }

                dict = new Dictionary<string[], string[]>();
                dict.Add(lstKeys.ToArray(), lstValues.ToArray());

                // 媒体名情報を中分類マスタのコード単位で格納.
                _dictBaitai[key] = dict;

                // 媒体名情報設定.
                _itemBaitaiCd = lstKeysAll.ToArray();
                _itemBaitaiNm = lstValuesAll.ToArray();
            }

            #endregion 媒体名コンボボックスの値取得.

            #region 商品名コンボボックスの値取得.

            // 商品名取得.
            result = process.FindMasterByCond(_naviParameter.strEsqId,
                                            _naviParameter.strEgcd,
                                            _naviParameter.strTksKgyCd,
                                            _naviParameter.strTksBmnSeqNo,
                                            _naviParameter.strTksTntSeqNo,
                                            MST_SHOHIN,
                                            null);
            ds = result.MasterDataSet;
            rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();

            lstKeys = new List<string>();
            lstValues = new List<string>();

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                lstKeys.Add(row.Column1);
                lstValues.Add(row.Column2);
            }

            // 商品名情報設定.
            _itemShohinCd = lstKeys.ToArray();
            _itemShohinNm = lstValues.ToArray();

            #endregion 商品名コンボボックスの値取得.

            #region 中分類紐付けマスタ情報取得.

            // 中分類紐付けマスタ情報取得.
            result = process.FindMasterByCond(_naviParameter.strEsqId,
                                            _naviParameter.strEgcd,
                                            _naviParameter.strTksKgyCd,
                                            _naviParameter.strTksBmnSeqNo,
                                            _naviParameter.strTksTntSeqNo,
                                            MST_TYUBUNRUI_HIMOZUKE,
                                            null);

            _dsTyubunruiHimo = result.MasterDataSet;

            #endregion 中分類紐付けマスタ情報取得.
        }

        /// <summary>
        /// 明細スプレッドの媒体名コンボボックスに値を設定する 
        /// </summary>
        /// <param name="row">行インデックス</param>
        /// <param name="defaultFlg">初期値フラグ</param>
        private void SetDetailDataBaitai(int row, bool defaultFlg)
        {
            bool existsFlg = true;

            // 中分類がNull、空文字以外の場合 
            if (_spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_TYUBUNRUI].Value != null &&
                !string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_TYUBUNRUI].Text))
            {
                string key = _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_TYUBUNRUI].Value.ToString();

                // 選択されたキー（中分類）が存在する、かつキーの値を取得できた場合 
                if (_dictBaitai.ContainsKey(key) && _dictBaitai[key] != null)
                {
                    string[] keys;
                    string[] values;

                    // 選択された中分類に合致する媒体名を取得し 
                    // スプレッドのコンボボックスに値を設定する 
                    foreach (KeyValuePair<string[], string[]> kvp in _dictBaitai[key])
                    {
                        keys = kvp.Key;
                        values = kvp.Value;

                        object beforeValue = _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].Value;
                        string beforeText = _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].Text;

                        ComboBoxCellType comboType = new ComboBoxCellType();
                        comboType.ItemData = keys;
                        comboType.Items = values;
                        comboType.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                        comboType.Editable = false;

                        _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].CellType = comboType;

                        // 初期値フラグがtrueの場合、先頭項目を表示する
                        if (defaultFlg)
                        {
                            _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].Value = keys[0].ToString();
                            _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].Text = values[0].ToString();
                        }
                        else
                        {
                            _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].Value = beforeValue;
                            _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].Text = beforeText;
                        }
                        break;
                    }
                }
                else
                {
                    existsFlg = false;
                }
            }
            else
            {
                existsFlg = false;
            }

            if (!existsFlg)
            {
                ComboBoxCellType comboType = new ComboBoxCellType();
                comboType.ItemData = new string[] { string.Empty };
                comboType.Items = new string[] { string.Empty };
                comboType.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                comboType.Editable = false;

                _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].CellType = comboType;
                _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].Value = string.Empty;
                _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].Text = string.Empty;
            }
        }

        /// <summary>
        /// 明細スプレッドの実施Noに値を設定する 
        /// </summary>
        /// <param name="row">行インデックス</param>
        private void SetDetailDataJissiNo(int row)
        {
            // 選択値がフィーの場合 
            if (COMBO_NAME_KBN_FEE.Equals(_spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_KANRIKBN].Text))
            {
                // 実施Noに0を設定する 
                _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_JISHINO].Value = 0;
            }
        }

        /// <summary>
        /// 明細スプレッドの区分に値を設定する 
        /// </summary>
        /// <param name="row">行インデックス</param>
        private void SetDetailDataKbn(int row)
        {
            if (_spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_STATUS].Value != null &&
                !string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_STATUS].Text))
            {
                // 選択値がSPの場合 
                if (COMBO_CODE_STS_SP.ToString().Equals(_spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_STATUS].Value.ToString()))
                {
                    // 区分をロックを解除する 
                    _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_KBN].Locked = false;
                }
                // 選択値がMASSの場合 
                else if (COMBO_CODE_STS_MASS.ToString().Equals(_spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_STATUS].Value.ToString()))
                {
                    // 区分をロックする 
                    _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_KBN].Locked = true;
                    _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_KBN].Value = null;
                    _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_KBN].Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// 明細データ設定処理 
        /// </summary>
        /// <param name="dataRow">受注データ</param>
        /// <param name="rowIndex">明細行インデックス</param>
        /// <param name="mode">処理モード</param>
        private void SetDetailData(Common.KKHSchema.Detail.JyutyuDataRow dataRow
                                , int rowIndex
                                , Mode mode)
        {
            // １行追加 
            _spdKkhDetail_Sheet1.AddRows(rowIndex, 1);
            _spdKkhDetail_Sheet1.AddSelection(rowIndex, -1, 1, -1);

            // フィルターの作成 
            string filter = "Column2 = \'" + dataRow["hb1GyomKbn"] + "\'";
            if (!string.IsNullOrEmpty(dataRow["hb1TmspKbn"].ToString()))
            {
                // 業務区分がラジオ、衛星メディアの場合 
                if (KKHSystemConst.GyomKbn.Radio == dataRow.hb1GyomKbn ||
                    KKHSystemConst.GyomKbn.EiseiM == dataRow.hb1GyomKbn)
                //if (KKHSystemConst.GyomKbn.Radio.Equals(cmbGymKbn.SelectedValue) ||
                //    KKHSystemConst.GyomKbn.EiseiM.Equals(cmbGymKbn.SelectedValue))
                {
                    filter += " AND Column3 = \'" + dataRow["hb1TmspKbn"] + "\'";
                }
            }

            // 中分類紐付けマスタ情報より、選択された受注データに合致する中分類を取得 
            MasterMaintenance.MasterDataVORow[] rows;
            rows = (MasterMaintenance.MasterDataVORow[])_dsTyubunruiHimo.MasterDataVO.Select(filter);

            string tyubunrui = string.Empty;
            string[] baitai = new string[] { string.Empty };

            if (0 < rows.Length)
            {
                StringBuilder sb = new StringBuilder();
                foreach (MasterMaintenance.MasterDataVORow row in rows)
                {
                    sb.Append("\'" + row.Column1 + "\',");
                }

                // 中分類マスタ情報から中分類コードを取得 
                filter = " Column1 IN (" + sb.ToString().TrimEnd(new char[] { ',' }) + ")";
                rows = (MasterMaintenance.MasterDataVORow[])_dsTyubunrui.MasterDataVO.Select(filter);

                foreach (MasterMaintenance.MasterDataVORow row in rows)
                {
                    tyubunrui = row.Column1;
                    break;
                }

                if (_dictBaitai.ContainsKey(tyubunrui))
                {
                    foreach (KeyValuePair<string[], string[]> kvp in _dictBaitai[tyubunrui])
                    {
                        baitai = kvp.Key;
                        break;
                    }
                }
            }

            // 処理モードにより分岐 
            // 明細入力の場合 
            if (mode == Mode.DetailInput)
            {
                decimal kingaku = decimal.Parse(dataRow["hb1SeiGak"].ToString());

                // 明細スプレッドに値を設定 
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_NENGETSU].Value = dataRow.hb1Yymm;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_TYUBUNRUI].Value = tyubunrui;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_BAITAINM].Value = baitai[0];
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_JISHINO].Value = GetMaxJissiNo();
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_HAIBUNRITSU].Value = 100.ToString("##0.00");
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_KINGAKU].Value = kingaku.ToString("###,###,###,##0");
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_SHOHINNM].Value = _itemShohinCd[0];
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_KANRIKBN].Value = COMBO_CODE_KBN_GEN;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_SHIHARAISITE].Value = DEF_VALUE_SHIHARAISITE;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_TEKIYOU].Value = string.Empty;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_STATUS].Value = COMBO_CODE_STS_MASS;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_KBN].Value = string.Empty;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_NRITU].Value = 0;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_NGAK].Value = 0;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_NKGAK].Value = dataRow.hb1SeiGak;
            }
            // 分割の場合 
            else if (mode == Mode.Divide)
            {
                int activeRowIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

                // 明細スプレッドに値を設定 
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_NENGETSU].Value = dataRow.hb1Yymm;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_TYUBUNRUI].Value = tyubunrui;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_BAITAINM].Value = baitai[0];
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_JISHINO].Value = GetMaxJissiNo();
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_HAIBUNRITSU].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_HAIBUNRITSU].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_KINGAKU].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_KINGAKU].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_SHOHINNM].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_SHOHINNM].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_KANRIKBN].Value = COMBO_CODE_KBN_GEN;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_SHIHARAISITE].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_SHIHARAISITE].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_TEKIYOU].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_TEKIYOU].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_STATUS].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_STATUS].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_KBN].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_KBN].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_NRITU].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_NRITU].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_NGAK].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_NGAK].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_NKGAK].Value = dataRow.hb1SeiGak;

                SetDetailDataKbn(rowIndex);
            }

            // 先頭列にフォーカス移動 
            _spdKkhDetail_Sheet1.SetActiveCell(rowIndex, COLIDX_MLIST_NENGETSU);
            spdKkhDetail.ShowCell(0, 0, rowIndex, COLIDX_MLIST_NENGETSU, VerticalPosition.Nearest, HorizontalPosition.Nearest);
            _spdKkhDetail_Sheet1.ClearSelection();
            spdKkhDetail.Focus();
        }

        /// <summary>
        /// 明細チェック処理 
        /// </summary>
        /// <returns>判定結果</returns>
        private bool CheckDetailData()
        {
            for (int iRow = 0; iRow < _spdKkhDetail_Sheet1.RowCount; iRow++)
            {
                // 中分類 
                if (_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_TYUBUNRUI].Value == null ||
                    string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_TYUBUNRUI].Text))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0060, null, "明細登録", MessageBoxButtons.OK);

                    _spdKkhDetail_Sheet1.SetActiveCell(iRow, COLIDX_MLIST_TYUBUNRUI);
                    spdKkhDetail.ShowCell(0, 0, iRow, COLIDX_MLIST_TYUBUNRUI, VerticalPosition.Nearest, HorizontalPosition.Nearest);
                    spdKkhDetail.Focus();
                    return false;
                }

                // 媒体 
                if (_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_BAITAINM].Value == null ||
                    string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_BAITAINM].Text))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0077, null, "明細登録", MessageBoxButtons.OK);
                    _spdKkhDetail_Sheet1.SetActiveCell(iRow, COLIDX_MLIST_BAITAINM);
                    spdKkhDetail.ShowCell(0, 0, iRow, COLIDX_MLIST_BAITAINM, VerticalPosition.Nearest, HorizontalPosition.Nearest);
                    spdKkhDetail.Focus();
                    return false;
                }

                // 配分率（値が空でない場合のみ） 
                if (_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_HAIBUNRITSU].Value != null &&
                    !string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_HAIBUNRITSU].Text))
                {
                    string ritsuStr = _spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_HAIBUNRITSU].Value.ToString();

                    if (KKHUtility.IsNumeric(ritsuStr))
                    {
                        double ritsu = double.Parse(ritsuStr.Trim());

                        if (ritsu > MAX_VALUE_HAIBUNRITSU || ritsu < MIN_VALUE_HAIBUNRITSU)
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0075, null, "明細登録", MessageBoxButtons.OK);
                            _spdKkhDetail_Sheet1.SetActiveCell(iRow, COLIDX_MLIST_HAIBUNRITSU);
                            spdKkhDetail.ShowCell(0, 0, iRow, COLIDX_MLIST_HAIBUNRITSU, VerticalPosition.Nearest, HorizontalPosition.Nearest);
                            spdKkhDetail.Focus();
                            return false;
                        }
                    }
                }

                // 金額（値が空でない場合のみ）
                if (_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_KINGAKU].Value != null &&
                    !string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_KINGAKU].Text))
                {
                    string kingkStr = _spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_KINGAKU].Value.ToString();

                    if (KKHUtility.IsNumeric(kingkStr))
                    {
                        double kingk = double.Parse(kingkStr.Trim());

                        if (kingk > MAX_VALUE_KINGAKU || kingk < MIN_VALUE_KINGAKU)
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0027, null, "明細登録", MessageBoxButtons.OK);
                            _spdKkhDetail_Sheet1.SetActiveCell(iRow, COLIDX_MLIST_KINGAKU);
                            spdKkhDetail.ShowCell(0, 0, iRow, COLIDX_MLIST_KINGAKU, VerticalPosition.Nearest, HorizontalPosition.Nearest);
                            spdKkhDetail.Focus();
                            return false;
                        }
                    }
                }
            }

            // 実施No 
            // 同一チェックを行う 
            string baitaiCd = string.Empty;
            string jishiNo = string.Empty;
            decimal jisNo = 0;
            for (int iRow = 0; iRow < _spdKkhDetail_Sheet1.RowCount; iRow++)
            {
                baitaiCd = _spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_BAITAINM].Value.ToString().Trim();
                jisNo = decimal.Parse(_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_JISHINO].Value.ToString().Trim());
                //jishiNo = _spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_JISHINO].Value.ToString().Trim();
                //整数値のみ取得 
                jishiNo = jisNo.ToString("#");

                for (int iRow2 = 0; iRow2 < _spdKkhDetail_Sheet1.RowCount; iRow2++)
                {
                    // 同一の行データを比較しないようにチェック 
                    if (iRow != iRow2)
                    {
                        // 媒体コードを比較 
                        if (!baitaiCd.Equals(_spdKkhDetail_Sheet1.Cells[iRow2, COLIDX_MLIST_BAITAINM].Value.ToString().Trim()))
                        {
                            // 実施Noを比較 
                            if (jishiNo.Equals(_spdKkhDetail_Sheet1.Cells[iRow2, COLIDX_MLIST_JISHINO].Value.ToString().Trim()))
                            {
                                // メッセージ表示 
                                MessageUtility.ShowMessageBox(MessageCode.HB_W0055, null, "明細登録", MessageBoxButtons.OK);
                                _spdKkhDetail_Sheet1.SetActiveCell(iRow2, COLIDX_MLIST_JISHINO);
                                spdKkhDetail.ShowCell(0, 0, iRow, COLIDX_MLIST_JISHINO, VerticalPosition.Nearest, HorizontalPosition.Nearest);
                                spdKkhDetail.Focus();
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 明細登録処理 
        /// </summary>
        private void RegistDetailData()
        {
            //ローディング表示開始 
            base.ShowLoadingDialog();

            //サービスパラメータ用変数 
            Common.KKHSchema.Detail dsDetail = new Common.KKHSchema.Detail();
            string esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            DateTime maxUpdDate = new DateTime();

            Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);

            //*********************************************
            //THB2KMEIの登録データ編集 
            //*********************************************
            int jyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;
            Common.KKHSchema.Detail.THB2KMEIDataTable dtThb2Kmei = new Common.KKHSchema.Detail.THB2KMEIDataTable();
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                Common.KKHSchema.Detail.THB2KMEIRow addRow = dtThb2Kmei.NewTHB2KMEIRow();

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
                //addRow.hb2HimkCd = " ";
                //addRow.hb2Renbn = (i + 1).ToString("000"); 明細登録件数拡張対応
                addRow.hb2Renbn = (i + 1).ToString("0000");
                addRow.hb2DateFrom = " ";
                addRow.hb2DateTo = " ";
                addRow.hb2SeiGak = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KINGAKU].Value);
                addRow.hb2Hnnert = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NRITU].Value);
                addRow.hb2HnmaeGak = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NKGAK].Value);
                addRow.hb2NebiGak = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NGAK].Value);

                addRow.hb2Date1 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NENGETSU].Value);
                addRow.hb2Date2 = " ";
                addRow.hb2Date3 = " ";
                addRow.hb2Date4 = " ";
                addRow.hb2Date5 = " ";
                addRow.hb2Date6 = " ";

                addRow.hb2Kbn1 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_STATUS].Value);
                addRow.hb2Kbn2 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KANRIKBN].Value);
                addRow.hb2Kbn3 = " ";

                if (EGYSHOCD_20.Equals(_naviParameter.strEgcd))
                {
                    addRow.hb2Code1 = "101";
                }
                else
                {
                    addRow.hb2Code1 = "100";
                }
                addRow.hb2Code2 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAINM].Value);
                addRow.hb2Code3 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHOHINNM].Value);
                addRow.hb2Code4 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHIHARAISITE].Value);
                addRow.hb2Code5 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TYUBUNRUI].Value);
                addRow.hb2Code6 = " ";

                addRow.hb2Name1 = " ";
                addRow.hb2Name2 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHOHINNM].Text);
                addRow.hb2Name3 = " ";
                addRow.hb2Name4 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TYUBUNRUI].Text);
                addRow.hb2Name5 = " ";
                addRow.hb2Name6 = " ";
                addRow.hb2Name7 = " ";
                addRow.hb2Name8 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TEKIYOU].Value);
                addRow.hb2Name9 = " ";
                addRow.hb2Name10 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAINM].Text);

                addRow.hb2Kngk1 = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_JISHINO].Value);
                addRow.hb2Kngk2 = 0M;
                addRow.hb2Kngk3 = 0M;

                addRow.hb2Ritu1 = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HAIBUNRITSU].Value);
                addRow.hb2Ritu2 = 0M;

                addRow.hb2Sonota1 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KBN].Value);
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

            //*********************************************
            //THB1DOWNの登録データ編集 
            //*********************************************
            Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Common.KKHSchema.Detail.THB1DOWNDataTable();
            Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();

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

            foreach (Common.KKHSchema.Detail.THB2KMEIRow thb2KmeiRow in _dsDetail.THB2KMEI.Rows)
            {
                if (maxUpdDate == null || maxUpdDate.CompareTo(thb2KmeiRow.hb2TimStmp) < 0)
                {
                    maxUpdDate = thb2KmeiRow.hb2TimStmp;
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

            //エラーの場合 
            if (result.HasError)
            {
                //ローディング表示終了 
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

            base.kkhDetailUpdFlag = false; //広告費明細変更フラグを更新 
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                //明細登録"済"を設定 
                _spdJyutyuList_Sheet1.Cells[_spdJyutyuList_Sheet1.ActiveRowIndex, COLIDX_JLIST_TOROKU].Value = "済";
            }
            else
            {
                //明細登録"済"を解除 
                _spdJyutyuList_Sheet1.Cells[_spdJyutyuList_Sheet1.ActiveRowIndex, COLIDX_JLIST_TOROKU].Value = "";
            }

            //******************************************************************************************
            //保持している受注登録内容データを処理後のデータで更新する 
            //******************************************************************************************
            //foreach (Common.KKHSchema.Detail.THB1DOWNRow updRow in result.DsDetail.THB1DOWN.Rows)
            //{
            //    _dsDetail.JyutyuData.UpdateRowDataByTGADOWNRow(updRow);
            //    _dsDetail.THB1DOWN.UpdateRowData(updRow);
            //}
            //_dsDetail.THB2KMEI.Clear();
            //_dsDetail.THB2KMEI.Merge(result.DsDetail.THB2KMEI);
            //_dsDetail.AcceptChanges();


            ////現在位置の取得 
            //int _spdJyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            //base.SearchJyutyuData();

            ////元の位置に戻す 
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

            //MessageBox.Show("広告費明細の登録が完了しました。", "明細登録", MessageBoxButtons.OK);
            MessageUtility.ShowMessageBox(MessageCode.HB_I0012, null, "明細登録", MessageBoxButtons.OK);
            btnAutoNo.Enabled = true;
            btnAutoUpDown.Enabled = true;
        }

        /// <summary>
        /// 引数の値を文字列に変換し返却する 
        /// </summary>
        /// <param name="obj">変換対象のオブジェクト</param>
        /// <returns>変換後の値</returns>
        private string GetStringValue(object obj)
        {
            string ret;
            if (!string.IsNullOrEmpty(KKHUtility.ToString(obj)))
            {
                ret = obj.ToString();
            }
            else
            {
                ret = " ";
            }
            return ret;
        }

        /// <summary>
        /// 引数の値を数値に変換し返却する 
        /// </summary>
        /// <param name="obj">変換対象のオブジェクト</param>
        /// <returns>変換後の値</returns>
        private decimal GetDecimalValue(object obj)
        {
            decimal ret;
            if (!string.IsNullOrEmpty(KKHUtility.ToString(obj)))
            {
                ret = KKHUtility.DecParse(obj.ToString());
            }
            else
            {
                ret = 0M;
            }
            return ret;
        }

        /// <summary>
        /// 実施Noの最大値取得 
        /// </summary>
        /// <returns>実施Noの最大値</returns>
        private decimal GetMaxJissiNo()
        {
            //*******************************************************************
            // 実施Noの最大値取得 
            //*******************************************************************
            DetailTkdProcessController.FindMaxJissiNoByCondParam param =
                new DetailTkdProcessController.FindMaxJissiNoByCondParam();

            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = txtYmd.Text.Replace("/", "");

            string messageCode;
            string[] note;

            DetailTkdProcessController processController = DetailTkdProcessController.GetInstance();
            decimal result = processController.FindMaxJissiNoByCond(param, out messageCode, out note);

            return result += 1;
        }


        /// <summary>
        /// 実施Noの整合性チェックSV 
        /// </summary>
        /// <returns>True:未使用/False:使用済</returns>
        private bool CheckJissiNoComp()
        {
            //*******************************************************************
            // 使用済実施Noの件数取得 
            //*******************************************************************
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(_spdJyutyuList_Sheet1.ActiveRowIndex)];
            Common.KKHSchema.Detail.JyutyuListRow listRow = (Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);

            // 実施Noの生成 
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                sb.Append("\'" + _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_JISHINO].Value.ToString() + "\', ");
            }
            string jissiNo = sb.ToString().TrimEnd(new char[] { ',', ' ' });

            // パラメータセット 
            DetailTkdProcessController.FindJissiNoCntByCondParam param =
                new DetailTkdProcessController.FindJissiNoCntByCondParam();

            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = txtYmd.Text.Replace("/", "");
            param.jyutNo = dataRow.hb1JyutNo;
            param.jyMeiNo = dataRow.hb1JyMeiNo;
            param.urMeiNo = dataRow.hb1UrMeiNo;
            param.jissiNo = jissiNo;

            string messageCode;
            string[] note;

            DetailTkdProcessController processController = DetailTkdProcessController.GetInstance();
            decimal result = processController.FindJissiNoCntByCond(param, out messageCode, out note);

            if (0 < result)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 実施No付与ボタン押下時の配分率チェック 
        /// </summary>
        /// <param name="jyuListdt">明細データ</param>
        /// <param name="urimeino">売上明細No</param>
        /// <param name="kenNm">件名</param>
        /// <param name="msgCd">メッセージコード</param>
        /// <returns>判定結果</returns>
        private bool HaibunCheck(Common.KKHSchema.Detail jyuListdt, 
            out string urimeino, out string kenNm, out string msgCd)
        {
            //結果 true:エラー
            bool result = false;
            urimeino = string.Empty;
            kenNm = "";
            msgCd = "";
            int j = 0;
            string code = null;
            //string urimeino = String.Empty;
            double haibunSum = 0;
            double kngk1;
            string sort = "hb2JyutNo, hb2JyMeiNo, hb2UrMeiNo, hb2Code2, hb2Ritu1";
            foreach (KKH.Common.KKHSchema.Detail.THB2KMEIRow row in jyuListdt.THB2KMEI.Select(string.Empty, sort))
            {
                //1回目のループ 
                if (j == 0)
                {
                    urimeino = row.hb2JyutNo + "-" + row.hb2JyMeiNo + "-" + row.hb2UrMeiNo;
                    code = row.hb2Code2;
                    haibunSum = (double)row.hb2Ritu1;
                    //j++;
                    kngk1 = (double)row.hb2Kngk1;
                }
                //2回目以降のループ 
                else
                {
                    //売上明細Noが同じ 
                    if (urimeino.Equals(row.hb2JyutNo + "-" + row.hb2JyMeiNo + "-" + row.hb2UrMeiNo))
                    {
                        //媒体コードが同じ 
                        if (code.Equals(row.hb2Code2))
                        {
                            //今回の配分率が100%の場合 
                            if (row.hb2Ritu1 == 100)
                            {
                                //配分率合計が100%ではない場合error
                                if (haibunSum != 100)
                                {
                                    msgCd = MessageCode.HB_W0073;
                                    kenNm = GetKenNm(urimeino);
                                    return result = true;
                                }
                                haibunSum = (double)row.hb2Ritu1;
                            }
                            //今回の配分率が100%ではない場合 
                            //配分率を足していく 
                            else
                            {
                                haibunSum += (double)row.hb2Ritu1;
                            }
                        }
                        //媒体コードが違う場合 
                        else
                        {
                            //配分率の合計が100%ではない場合error 
                            if (haibunSum != 100)
                            {
                                msgCd = MessageCode.HB_W0153;
                                kenNm = GetKenNm(urimeino);
                                return result = true;
                            }
                            //新しい配分率を入れる。 
                            code = row.hb2Code2;
                            haibunSum = (double)row.hb2Ritu1;
                        }
                    }
                    //売上明細Noが違う場合 
                    else
                    {
                        //配分率の合計が100%ではない場合error 
                        if (haibunSum != 100)
                        {
                            msgCd = MessageCode.HB_W0153;
                            kenNm = GetKenNm(urimeino);
                            return result = true;
                        }
                        urimeino = row.hb2JyutNo + "-" + row.hb2JyMeiNo + "-" + row.hb2UrMeiNo;
                        code = row.hb2Code2;
                        haibunSum = (double)row.hb2Ritu1;
                    }
                }

                //最終のデータのときに配分率の合計が100%でない場合 
                if (j == jyuListdt.THB2KMEI.Count - 1)
                {
                    //配分率の合計が100%ではない場合error 
                    if (haibunSum != 100)
                    {
                        msgCd = MessageCode.HB_W0153;
                        kenNm = GetKenNm(urimeino);
                        return result = true;
                    }
                }

                j++;
            }

            return result;
        }

        /// <summary>
        /// 実施No付与ボタン押下時の[管理区分]チェック 
        /// </summary>
        /// <param name="jyuListdt">明細データ</param>
        /// <returns>[フィー]:true</returns>
        private bool ChkKnrKbn(Common.KKHSchema.Detail jyuListdt)
        {
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            { 
                //[管理区分]を取得 
                string knrKbn = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KANRIKBN].Value.ToString();

                //[フィー]の場合 
                if (knrKbn.Equals("2"))
                { 
                    //[実施No]を取得 
                    string jisiNo = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_JISHINO].Value.ToString();
                    
                    //実施Noが0以外ならワーニングを出力 
                    if (!jisiNo.Equals("0"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 実施Noの採番を行う 
        /// </summary>
        /// <param name="jyuListdt">明細データ</param>
        /// <returns>実施No配列</returns>
        private string[] CreateJissiNo(Common.KKHSchema.Detail jyuListdt)
        {
            string[] result = new string[jyuListdt.THB2KMEI.Count];
            int count1 = 0;
            int count2 = 0;
            //int jissiNoCnt = 0;

            foreach (KKH.Common.KKHSchema.Detail.THB2KMEIRow row in jyuListdt.THB2KMEI)
            {
                if (result[count1] == null)
                {
                    //if (row.hb2Ritu1 != 100)
                    {// 配分率１００でない場合 

                        //配分率100の場合  
                        if (row.hb2Ritu1 == 100)
                        {
                            // 実施Noカウントアップ 
                            jissiNoCnt++;

                            // 実施Noを設定 
                            result[count1] = jissiNoCnt.ToString();
                        }
                        // 配分率が100未満の場合 
                        else if (row.hb2Ritu1 < 100)
                        {
                            // 実施Noカウントアップ 
                            jissiNoCnt++;

                            count2 = count1;
                            // 同一売上明細No、同一媒体、配分率が100未満の明細のみ取得 
                            string filter = "hb2JyutNo = \'" + row.hb2JyutNo + "\' "
                                          + "AND hb2JyMeiNo = \'" + row.hb2JyMeiNo + "\' "
                                          + "AND hb2UrMeiNo = \'" + row.hb2UrMeiNo + "\' "
                                          + "AND hb2Code2 = \'" + row.hb2Code2 + "\' "
                                          + "AND hb2Ritu1 < 100";
                            foreach (KKH.Common.KKHSchema.Detail.THB2KMEIRow row2 in jyuListdt.THB2KMEI.Select(filter))
                            {
                                // 実施Noを設定 
                                result[count2] = jissiNoCnt.ToString();
                                count2++;
                            }
                        }
                    }
                }
                count1++;
            }

            return result;
        }

        /// <summary>
        /// 実施Noの採番を行う(クリエーティブ) 
        /// </summary>
        /// <param name="jyuListdt">明細データ</param>
        /// <param name="jyutNo">受注No</param>
        /// <param name="jyMeiNo">受注明細No</param>
        /// <param name="urMeiNo">売上明細No</param>
        /// <param name="haibun">配分率</param>
        /// <param name="renban">連番</param>
        /// <param name="baitaiCd">媒体コード</param>
        /// <returns>実施No配列</returns>
        private string[] CreateJissiNoCreative(Common.KKHSchema.Detail jyuListdt,
            out String[] jyutNo, 
            out String[] jyMeiNo, 
            out String[] urMeiNo, 
            out String[] haibun, 
            out String[] renban, 
            out String[] baitaiCd)
        {
            //実施No
            string[] result = new string[jyuListdt.THB2KMEI.Count];
            //受注No 
            jyutNo = new String[jyuListdt.THB2KMEI.Rows.Count];
            //受注明細No 
            jyMeiNo = new String[jyuListdt.THB2KMEI.Rows.Count];
            //売上明細No 
            urMeiNo = new String[jyuListdt.THB2KMEI.Rows.Count];
            //配分率 
            haibun = new String[jyuListdt.THB2KMEI.Rows.Count];
            //連番 
            renban = new String[jyuListdt.THB2KMEI.Rows.Count];
            //媒体コード 
            baitaiCd = new String[jyuListdt.THB2KMEI.Rows.Count];
            int count1 = 0;
            int count2 = 0;
            ArrayList list = new ArrayList();
            ArrayList list2 = new ArrayList();

            //明細の件数分処理する 
            foreach (KKH.Common.KKHSchema.Detail.THB2KMEIRow row in jyuListdt.THB2KMEI)
            {
                //登録済みの売上明細Noがある場合 
                if (list.Count > 0)
                {
                    //同一の売上明細Noは処理しない 
                    if (list.Contains(row.hb2JyutNo + row.hb2JyMeiNo + row.hb2UrMeiNo))
                    {
                        continue;
                    }
                }
                // 同一売上明細Noを取得 
                string filter = @"hb2JyutNo = '" + row.hb2JyutNo + "' "
                              + @"AND hb2JyMeiNo = '" + row.hb2JyMeiNo + "' "
                              + @"AND hb2UrMeiNo = '" + row.hb2UrMeiNo + "' ";

                string sort =  "hb2JyutNo, "
                              + "hb2JyMeiNo, "
                              + "hb2UrMeiNo, "
                              + "hb2Code3";

                //売上明細Noで並び変える 
                foreach (KKH.Common.KKHSchema.Detail.THB2KMEIRow row2 in jyuListdt.THB2KMEI.Select(filter, sort))
                {
                    //同一の売上明細No連番は処理しない 
                    if (list2.Count > 0)
                    {
                        if (list2.Contains(row2.hb2JyutNo + row2.hb2JyMeiNo + row2.hb2UrMeiNo + row2.hb2Renbn))
                        {
                            continue;
                        }
                    }

                    // 実施Noカウントアップ 
                    jissiNoCnt++;

                    //配分率100の場合  
                    if (row2.hb2Ritu1 == 100)
                    {
                        // 実施Noを設定 
                        result[count1] = jissiNoCnt.ToString();
                        //受注No
                        jyutNo[count1] = row2.hb2JyutNo;
                        //受注明細No 
                        jyMeiNo[count1] = row2.hb2JyMeiNo;
                        //売上明細No 
                        urMeiNo[count1] = row2.hb2UrMeiNo;
                        //配分率 
                        haibun[count1] = row2.hb2Ritu1.ToString();
                        //連番 
                        renban[count1] = row2.hb2Renbn;
                        //媒体コード 
                        baitaiCd[count1] = row2.hb2Code2;
                        //売上明細No連番を登録する 
                        list2.Add(row2.hb2JyutNo + row2.hb2JyMeiNo + row2.hb2UrMeiNo + row2.hb2Renbn);
                        count1++;
                    }
                    // 配分率が100未満の場合 
                    else if (row2.hb2Ritu1 < 100)
                    {
                        count2 = count1;
                        // 同一売上明細No、同一媒体、配分率が100未満の明細のみ取得 
                        string filter2 = "hb2JyutNo = \'" + row2.hb2JyutNo + "\' "
                                      + "AND hb2JyMeiNo = \'" + row2.hb2JyMeiNo + "\' "
                                      + "AND hb2UrMeiNo = \'" + row2.hb2UrMeiNo + "\' "
                                      + "AND hb2Code2 = \'" + row2.hb2Code2 + "\' "
                                      + "AND hb2Ritu1 < 100";
                        foreach (KKH.Common.KKHSchema.Detail.THB2KMEIRow row3 in jyuListdt.THB2KMEI.Select(filter2))
                        {
                            // 実施Noを設定 
                            result[count2] = jissiNoCnt.ToString();
                            //受注No
                            jyutNo[count2] = row3.hb2JyutNo;
                            //受注明細No 
                            jyMeiNo[count2] = row3.hb2JyMeiNo;
                            //売上明細No 
                            urMeiNo[count2] = row3.hb2UrMeiNo;
                            //配分率 
                            haibun[count2] = row3.hb2Ritu1.ToString();
                            //連番 
                            renban[count2] = row3.hb2Renbn;
                            //媒体コード 
                            baitaiCd[count2] = row3.hb2Code2;
                            count2++;
                            //売上明細No連番を登録する 
                            list2.Add(row3.hb2JyutNo + row3.hb2JyMeiNo + row3.hb2UrMeiNo + row3.hb2Renbn);
                        }
                        count1 = count2;
                    }
                }
                //売上明細Noを登録する 
                list.Add(row.hb2JyutNo + row.hb2JyMeiNo + row.hb2UrMeiNo);
            }

            return result;
        }

        /// <summary>
        /// 実施Noを更新する 
        /// </summary>
        /// <param name="jyuListdt">受注データ</param>
        /// <param name="creativeFlg">クリエーティブフラグ</param>
        private void SetJissiNo(KKH.Common.KKHSchema.Detail jyuListdt , bool creativeFlg)
        {
            //受注No 
            String[] jyutNo = new String[jyuListdt.THB2KMEI.Rows.Count];
            //受注明細No 
            String[] jyMeiNo = new String[jyuListdt.THB2KMEI.Rows.Count];
            //売上明細No 
            String[] urMeiNo = new String[jyuListdt.THB2KMEI.Rows.Count];
            //配分率 
            String[] haibun = new String[jyuListdt.THB2KMEI.Rows.Count];
            //連番 
            String[] renban = new String[jyuListdt.THB2KMEI.Rows.Count];
            //媒体コード 
            String[] baitaiCd = new String[jyuListdt.THB2KMEI.Rows.Count];
            //実施No 
            String[] jissiNo = new String[jyuListdt.THB2KMEI.Rows.Count];
            
            //業務区分がクリエーティブの場合 
            if (creativeFlg)
            {
                jissiNo = CreateJissiNoCreative(jyuListdt,
                    out jyutNo, out jyMeiNo, out urMeiNo, out haibun, out renban, out baitaiCd);
            }
            //業務区分がクリエーティブ以外の場合 
            else
            {
                jissiNo = CreateJissiNo(jyuListdt);
                int i = 0;
                foreach (KKH.Common.KKHSchema.Detail.THB2KMEIRow row in jyuListdt.THB2KMEI)
                {
                    //受注Noを入れる。 
                    jyutNo[i] = row.hb2JyutNo;
                    jyMeiNo[i] = row.hb2JyMeiNo;
                    urMeiNo[i] = row.hb2UrMeiNo;
                    haibun[i] = row.hb2Ritu1.ToString();
                    renban[i] = row.hb2Renbn;
                    baitaiCd[i] = row.hb2Code2;
                    i++;
                }
            }

            //実施No付与の実行 
            DetailTkdProcessController processController = DetailTkdProcessController.GetInstance();
            UpdateJissiNoFuyoServiceResult resultUp = processController.UpdateJissiNo(
                                                                                        _naviParameter.strEsqId,
                                                                                        "00",
                                                                                         _naviParameter.strEgcd,
                                                                                         _naviParameter.strTksKgyCd,
                                                                                         _naviParameter.strTksBmnSeqNo,
                                                                                         _naviParameter.strTksTntSeqNo,
                                                                                         _naviParameter.StrYymm,
                                                                                         jyutNo,
                                                                                         jyMeiNo,
                                                                                         urMeiNo,
                                                                                         haibun,
                                                                                         renban,
                                                                                         "0",
                                                                                         baitaiCd,
                                                                                         jissiNo);
        }

        /// <summary>
        /// 売上明細Noよりスプレッドの件名を取得する(他にいい方法がありそう) 
        /// </summary>
        /// <param name="urimeino"></param>
        /// <returns></returns>
        private string GetKenNm(string urimeino)
        {
            int uriCol = 0;
            int kenCol = 0;
            string kenNm = "";

            //[売上明細No]の列Indexを取得 
            for (int i = 0; i < _spdJyutyuList_Sheet1.ColumnCount; i++)
            {
                if (_spdJyutyuList_Sheet1.ColumnHeader.Columns[i].Label == "売上明細NO")
                {
                    uriCol = i;
                    break;
                }
            }

            //[件名]の列Indexを取得 
            for (int i = 0; i < _spdJyutyuList_Sheet1.ColumnCount; i++)
            {
                if (_spdJyutyuList_Sheet1.ColumnHeader.Columns[i].Label == "件名")
                {
                    kenCol = i;
                    break;
                }
            }

            //件名を取得 
            for (int i = 0; i < _spdJyutyuList_Sheet1.RowCount; i++)
            {
                if (_spdJyutyuList_Sheet1.Cells[i, uriCol].Text == urimeino)
                {
                    kenNm = _spdJyutyuList_Sheet1.Cells[i, kenCol].Text;
                }
            }

            return kenNm;
        }

        #endregion メソッド
    }
}