using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Kmn.View.Detail;
using Isid.KKH.Kmn.Utility;
using Isid.KKH.Kmn.View;
using System.Collections;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.Model;
using FarPoint.Win.Spread.CellType;

namespace Isid.KKH.Kmn.View.Detail
{
    /// <summary>
    /// 明細入力画面.
    /// </summary>
    public partial class DetailInputKmn : KKHDialogBase
    {
        #region 定数.
        #region 業務区分.
        /// <summary>
        /// 新聞.
        /// </summary>
        public const string C_GYOM_SHINBUN = KKHSystemConst.GyomKbn.Shinbun;
        /// <summary>
        /// 雑誌.
        /// </summary>
        public const string C_GYOM_ZASHI = KKHSystemConst.GyomKbn.Zashi;
        /// <summary>
        /// ラジオ.
        /// </summary>
        public const string C_GYOM_RADIO = KKHSystemConst.GyomKbn.Radio;
        /// <summary>
        /// テレビタイム.
        /// </summary>
        public const string C_GYOM_TVT = KKHSystemConst.GyomKbn.TVTime;
        /// <summary>
        /// テレビスポット.
        /// </summary>
        public const string C_GYOM_TVS = KKHSystemConst.GyomKbn.TVSpot;
        /// <summary>
        /// 衛星メディア.
        /// </summary>
        public const string C_GYOM_EISEIM = KKHSystemConst.GyomKbn.EiseiM;
        /// <summary>
        /// OOHメディア.
        /// </summary>
        public const string C_GYOM_OOHM = KKHSystemConst.GyomKbn.OohM;
        /// <summary>
        /// インタラクティブメディア.
        /// </summary>
        public const string C_GYOM_INTEM = KKHSystemConst.GyomKbn.InteractiveM;
        /// <summary>
        /// その他メディア.
        /// </summary>
        public const string C_GYOM_SONOM = KKHSystemConst.GyomKbn.SonotaM;
        /// <summary>
        /// メディアプランニング.
        /// </summary>
        public const string C_GYOM_MPLAN = KKHSystemConst.GyomKbn.MPlan;
        /// <summary>
        /// クリエーティブ.
        /// </summary>
        public const string C_GYOM_CREAT = KKHSystemConst.GyomKbn.Creative;
        /// <summary>
        /// マーケティング/プロモーション.
        /// </summary>
        public const string C_GYOM_MARPRO = KKHSystemConst.GyomKbn.MarkePromo;
        /// <summary>
        /// スポーツ.
        /// </summary>
        public const string C_GYOM_SPO = KKHSystemConst.GyomKbn.Sports;
        /// <summary>
        /// エンタテイメント.
        /// </summary>
        public const string C_GYOM_ENTE = KKHSystemConst.GyomKbn.Entertainment;
        /// <summary>
        /// その他コンテンツ.
        /// </summary>
        public const string C_GYOM_SONOC = KKHSystemConst.GyomKbn.SonotaC;
        #endregion 業務区分.

        #region 請求区分.
        /// <summary>
        /// 新聞.
        /// </summary>
        public const string C_SEI_SHINBUN = KKHSystemConst.SeiKbn.NewsPaper;
        #endregion 請求区分.

        #region 入力明細スプレッド列インデックス.
        /// <summary>
        ///  品目1.
        /// </summary>
        public const int COLIDX_HINMOKU1 = 0;
        /// <summary>
        ///  品目2.
        /// </summary>
        public const int COLIDX_HINMOKU2 = 1;
        /// <summary>
        ///  品目3.
        /// </summary>
        public const int COLIDX_HINMOKU3 = 2;
        /// <summary>
        ///  部門コード.
        /// </summary>
        public const int COLIDX_BUMONCODE = 3;
        /// <summary>
        ///  請求先部門.
        /// </summary>
        public const int COLIDX_SEIKYUSAKIBUMON = 4;
        /// <summary>
        ///  請求年月.
        /// </summary>
        public const int COLIDX_SEIKYUYYYYMM = 5;
        /// <summary>
        ///  合計金額.
        /// </summary>
        public const int COLIDX_GOUKEIKINGAKU = 6;
        /// <summary>
        ///  内容(明細).
        /// </summary>
        public const int COLIDX_NAIYOU = 7;
        /// <summary>
        ///  費目(明細).
        /// </summary>
        public const int COLIDX_HIMOKU_M = 8;
        /// <summary>
        ///  期間(明細).
        /// </summary>
        public const int COLIDX_KIKAN_M = 9;
        /// <summary>
        ///  金額(明細).
        /// </summary>
        public const int COLIDX_KINGAKU = 10;
        /// <summary>
        ///  消費税額(明細).
        /// </summary>
        public const int COLIDX_SHOHIZEIGAK = 11;
        /// <summary>
        ///  備考(明細).
        /// </summary>
        public const int COLIDX_BIKO = 12;
        #endregion 入力明細スプレッド列インデックス.
        #endregion 定数.

        #region メンバ変数.
        /// <summary>
        /// ナビパラメータ.
        /// </summary>
        private DetailInputKmnNaviParameter _naviParam = new DetailInputKmnNaviParameter();
        /// <summary>
        /// 受注データDataRow.
        /// </summary>
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;
        /// <summary>
        /// 受注データDataTable.
        /// </summary>
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable _dtJyutyuData = null;
        /// <summary>
        /// 明細行Index.
        /// </summary>
        private int _rowDetailIdx = -1;
        /// <summary>
        /// 明細入力一覧シート.
        /// </summary>
        private FarPoint.Win.Spread.SheetView _spdKkhDetail_Sheet1 = null;
        /// <summary>
        /// 受注一覧の業務区分.
        /// </summary>
        private string _mCurrentGyomuKbn = "";
        /// <summary>
        /// 請求区分(受注).
        /// </summary>
        private string _seiKbn = "";
        /// <summary>
        /// 請求先部門.
        /// </summary>
        private string SBumon = string.Empty;
        /// <summary>
        /// 請求先部門の部門コード.
        /// </summary>
        private string BumonCD = string.Empty;
        /// <summary>
        /// 宛先マスタ_比較項目と部門略称をセットで保持.
        /// </summary>
        private Hashtable htAtesaki = new Hashtable();
        #endregion メンバ変数.

        #region コンストラクタ.
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DetailInputKmn()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ.

        #region イベント.
        #region 画面遷移イベント.
        /// <summary>
        /// 画面遷移イベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailInputKmn_ProcessAffterNavigating(object sender , Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //ナビパラが空の場合.
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is DetailInputKmnNaviParameter)
            {
                _naviParam = (DetailInputKmnNaviParameter)arg.NaviParameter;
                _dataRow = _naviParam.DataRowKmn;
                _dtJyutyuData = (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable)_naviParam.DataTable2;
                _rowDetailIdx = _naviParam.RowDetailIndexKmn;
                _spdKkhDetail_Sheet1 = _naviParam.SpdKkhDetailKmn_Sheet1;
            }
        }
        #endregion 画面遷移イベント.

        #region フォームLoadイベント.
        /// <summary>
        /// フォームLoadイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailInputUi_Load(object sender , EventArgs e)
        {
            // 各コントロールの初期化.
            InitializeControl();

            // 各コントロールの編集.
            EditControl();
        }
        #endregion フォームLoadイベント.

        #region OKボタンクリックイベント.
        /// <summary>
        /// OKボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender , EventArgs e)
        {
            // 各項目の入力値チェック.
            if (CheckBtnOK() == false)
            {
                return;
            }

            Isid.KKH.Kmn.Schema.DetailDSKmn.KkhDetailDataTable dtDetail = new Isid.KKH.Kmn.Schema.DetailDSKmn.KkhDetailDataTable();
            
            // 明細入力画面の内容を親画面に返却.
            for (int i = 0; i < spdDetailInput_Sheet1.RowCount; i++)
            {
                Isid.KKH.Kmn.Schema.DetailDSKmn.KkhDetailRow addRow = dtDetail.NewKkhDetailRow();

                addRow.Hinmoku1 = txtHinmoku1.Text;
                addRow.Hinmoku2 = txtHinmoku2.Text;
                addRow.Hinmoku3 = txtHinmoku3.Text;
                addRow.BumonCd = BumonCD;
                addRow.SeikyuSakiBumon = CmbSeikyusakiBumon.Text.ToString();
                addRow.SeikyuYyyymm = txtSeikyuYyyymm.Text.ToString().Replace("/","");
                addRow.GokeiKingaku = txtGoukeiKingaku.Text.ToString();
                addRow.GokeiZeigaku = txtShohiZeigaku.Text.ToString();
                addRow.Naiyou = spdDetailInput_Sheet1.Cells[i, COLIDX_NAIYOU].Value.ToString();
                // 費目.
                addRow.Himoku1 = txtHimoku.Text;

                // 期間(何もも入力されていない場合は空でセット).
                if (txtKikan.Text == "")
                {
                    addRow.Kikan1 = string.Empty;
                }
                else
                {
                    addRow.Kikan1 = txtKikan.Text;
                }

                // 費目(明細).
                addRow.Himoku = spdDetailInput_Sheet1.Cells[i, COLIDX_HIMOKU_M].Value.ToString();

                // 期間(明細)(何も入力されていない場合は空でセット).
                if (spdDetailInput_Sheet1.Cells[i, COLIDX_KIKAN_M].Text.Trim() == "")
                {
                    addRow.Kikan = string.Empty;
                }
                else
                {
                    addRow.Kikan = spdDetailInput_Sheet1.Cells[i, COLIDX_KIKAN_M].Value.ToString();
                }
                addRow.Zeigaku = spdDetailInput_Sheet1.Cells[i, COLIDX_SHOHIZEIGAK].Value.ToString();
                addRow.Kingaku = spdDetailInput_Sheet1.Cells[i, COLIDX_KINGAKU].Value.ToString();
                
                // 備考(何も入力されていない場合は空でセット).
                if (spdDetailInput_Sheet1.Cells[i, COLIDX_BIKO].Text.Trim() == "")
                {
                    addRow.Biko = string.Empty;
                }
                else
                {
                    addRow.Biko = spdDetailInput_Sheet1.Cells[i, COLIDX_BIKO].Value.ToString();
                }

                dtDetail.AddKkhDetailRow(addRow);
            }

            _naviParam.DataTable1 = dtDetail;

            //画面遷移.
            Navigator.Backward(this, _naviParam, null, true);
            this.Close();
        }
        #endregion OKボタンクリックイベント.

        #region キャンセルボタンクリックイベント.
        /// <summary>
        /// キャンセルボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
            this.Close();
        }
        #endregion キャンセルボタンクリックイベント.

        #region 行挿入ボタンクリックイベント.
        /// <summary>
        /// 行挿入ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRowInsert_Click(object sender, EventArgs e)
        {
            if (spdDetailInput_Sheet1.RowCount > 0)
            {
                int rowDetailIndex = spdDetailInput_Sheet1.ActiveRowIndex;
                spdDetailInput_Sheet1.AddRows(rowDetailIndex, 1);
                for (int i = 0; i < spdDetailInput_Sheet1.ColumnCount; i++)
                {
                    spdDetailInput_Sheet1.Cells[rowDetailIndex, i].Value = spdDetailInput_Sheet1.Cells[rowDetailIndex + 1, i].Value;
                }
            }
            else
            {
                //何もしない(旧システムでは空行を追加するが、明細登録画面への反映はしていない).
                spdDetailInput_Sheet1.AddRows(0, 1);
            }

            // 合計消費税額の再計算.
            SetShohiZeigaku();

            // 合計金額の再計算.
            SetGoukeikingaku();
        }
        #endregion 行挿入ボタンクリックイベント.

        #region 行削除ボタンクリックイベント.
        /// <summary>
        /// 行削除ボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRowDelete_Click(object sender, EventArgs e)
        {
            //明細がない場合.
            if (spdDetailInput_Sheet1.RowCount == 0)
            {
                return;
            }

            if (MessageUtility.ShowMessageBox(MessageCode.HB_C0009, null, "明細登録", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            int rowIndex = spdDetailInput_Sheet1.ActiveRowIndex;
            spdDetailInput_Sheet1.RemoveRows(rowIndex, 1);
            _dsDetailKmn.KkhDetail.AcceptChanges();

            // 合計消費税額の再計算.
            SetShohiZeigaku();

            // 合計金額の再計算.
            SetGoukeikingaku();
        }
        #endregion 行削除ボタンクリックイベント.

        #region 編集モードが終了するときに発生します.
        /// <summary>
        /// 編集モードが終了するときに発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdDetailInput_EditModeOff(object sender, EventArgs e)
        {
            //金額.
            if (spdDetailInput_Sheet1.ActiveColumnIndex == COLIDX_KINGAKU)
            {
                //合計金額の再計算.
                SetGoukeikingaku();
            }

            //消費税額.
            if (spdDetailInput_Sheet1.ActiveColumnIndex == COLIDX_SHOHIZEIGAK)
            {
                // 合計消費税額の再計算.
                SetShohiZeigaku();
            }
        }
        #endregion 編集モードが終了するときに発生します.

        #region キーが押下されたときに発生します.
        /// <summary>
        /// キーが押下されたときに発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdDetailInput_KeyDown(object sender, KeyEventArgs e)
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
                            multiCopyFlg = isSetContinuePast(this.spdDetailInput.GetRootWorkbook(), clipVal, rowCnt, colCnt);

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
        }
        #endregion キーが押下されたときに発生します.

        #region 請求先部門コンボボックスを変更するときに発生します.
        /// <summary>
        /// 請求先部門コンボボックスを変更するときに発生します.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbSeikyusakiBumon_SelectedValueChanged(object sender, EventArgs e)
        {
            BumonCD = "";

            //選択されていればSelectedValueに入っている.
            if (CmbSeikyusakiBumon.SelectedIndex != -1)
            {
                //部門コードを取得.
                BumonCD = CmbSeikyusakiBumon.SelectedValue.ToString();
            }
        }
        #endregion 請求先部門コンボボックスを変更するときに発生します.
        #endregion イベント.

        #region メソッド.
        #region 各コントロールの初期表示処理.
        /// <summary>
        /// 各コントロールの初期表示処理.
        /// </summary>
        private void InitializeControl()
        {
            // テキストボックス.
            txtHinmoku1.Text = string.Empty;
            txtHinmoku2.Text = string.Empty;
            txtHinmoku3.Text = string.Empty;
            txtGoukeiKingaku.Text = string.Empty;

            //請求先部門コンボボックスにセットする.
            SetSeikyusakiBumonCmb();
        }
        #endregion 各コントロールの初期表示処理.

        #region 各コントロールの編集処理.
        /// <summary>
        /// 各コントロールの編集処理. 
        /// </summary>
        private void EditControl()
        {
            KKHKmnDetailDisp detailDisp = new KKHKmnDetailDisp();

            //業務区分.
            _mCurrentGyomuKbn = _dataRow.hb1GyomKbn.ToString().Trim();
            /* 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito DEL Start */
            //請求区分.
            //_seiKbn = _dataRow.hb1SeiKbn.ToString().Trim();
            /* 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito DEL End */

            //業務区分ごとに表示列の制御.
            VisibleSpdDetailInputColumns(_mCurrentGyomuKbn);

            // 明細がない場合.
            if (_spdKkhDetail_Sheet1.RowCount == 0)
            {
                // 受注統合されている場合は統合元データで明細を作成する.
                Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] dataRows = new Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] { };
                if (_dataRow.hb1TouFlg == "1")
                {
                    //統合済みデータの場合は統合前データを基にして明細を作成する .
                    string filterEx = _dtJyutyuData.hb1EgCdColumn.ColumnName + "='" + _dataRow.hb1EgCd + "'";
                    filterEx = filterEx + " AND " + _dtJyutyuData.hb1TksKgyCdColumn.ColumnName + "='" + _dataRow.hb1TksKgyCd + "'";
                    filterEx = filterEx + " AND " + _dtJyutyuData.hb1TksBmnSeqNoColumn.ColumnName + "='" + _dataRow.hb1TksBmnSeqNo + "'";
                    filterEx = filterEx + " AND " + _dtJyutyuData.hb1TksTntSeqNoColumn.ColumnName + "='" + _dataRow.hb1TksTntSeqNo + "'";
                    filterEx = filterEx + " AND " + _dtJyutyuData.hb1TJyutNoColumn.ColumnName + "='" + _dataRow.hb1JyutNo + "'";
                    filterEx = filterEx + " AND " + _dtJyutyuData.hb1TJyMeiNoColumn.ColumnName + "='" + _dataRow.hb1JyMeiNo + "'";
                    filterEx = filterEx + " AND " + _dtJyutyuData.hb1TUrMeiNoColumn.ColumnName + "='" + _dataRow.hb1UrMeiNo + "'";
                    filterEx = filterEx + " AND " + _dtJyutyuData.hb1TouFlgColumn.ColumnName + "=''";
                    dataRows = (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[])_dtJyutyuData.Select(filterEx);
                }
                else
                {
                    //未統合データの場合は選択データを基にして明細を作成する.
                    dataRows = new Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] { _dataRow };
                }

                // 明細入力画面の上部(伝票帳票に必要な情報)をコントロールに値セット.
                // 業務区分ごとに受注データを取得.
                string[] hinmokuArray = detailDisp.SetJuchuValue_himoku(_mCurrentGyomuKbn, dataRows, _dataRow);

                // 品目名1.
                txtHinmoku1.Text = KKHUtility.GetByteString(KKHUtility.ToString(hinmokuArray[0]), 30);
                // 品目名2.
                txtHinmoku2.Text = KKHUtility.GetByteString(KKHUtility.ToString(hinmokuArray[1]), 30);
                // 品目名3.
                txtHinmoku3.Text = KKHUtility.GetByteString(KKHUtility.ToString(hinmokuArray[2]), 30);

                /* 2013/04/23 費目の取得元変更 JSE M.Naito MOD Start */
                //foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in dataRows)
                //{
                // 費目.
                //txtHimoku.Text = row.hb1HimkNmKJ;
                txtHimoku.Text = _dataRow.hb1HimkNmKJ;
                /* 2013/04/23 費目の取得元変更 JSE M.Naito MOD End */

                // 請求区分ごとに期間をセット.
                //String kikan = SetKikanValue(_seiKbn, _dataRow);
                //if (kikan != "")
                //{
                //    if (kikan.Length == 16)
                //    {
                        /* 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito MOD Start */
                        // 期間をセット.
                        txtKikan.Text = detailDisp.GetKikanFromTo(dataRows);

                        //// Fromの中から暫定Min値を取得.
                        //int minFrom_tmp = int.Parse(kikan.Substring(0, 8));
                        //// Toの中から暫定Max値を取得.
                        //int maxTo_tmp = int.Parse(kikan.Substring(8, 8));
                        //// min値取得.
                        //if (minFrom.Equals(""))
                        //{
                        //    minFrom = minFrom_tmp.ToString();
                        //}
                        //else
                        //{
                        //    // Min値判定　暫定Min値の方が小さい場合.
                        //    if (int.Parse(minFrom) > minFrom_tmp)
                        //    {
                        //        // Min値交代.
                        //        minFrom = minFrom_tmp.ToString() ;
                        //    }
                        //}
                        //// max値取得.
                        //if (maxTo.Equals(""))
                        //{
                        //    maxTo = maxTo_tmp.ToString();
                        //}
                        //else
                        //{
                        //    // Max値判定　暫定Max値の方が大きい場合.
                        //    if (int.Parse(maxTo) < maxTo_tmp)
                        //    {
                        //        // Max値交代.
                        //        maxTo = maxTo_tmp.ToString();
                        //    }
                        //}
                        //string strFrom = kikan.Substring(0, 4) + "/" + kikan.Substring(4, 2) + "/" + kikan.Substring(6, 2);
                        //string strTo = kikan.Substring(8, 4) + "/" + kikan.Substring(12, 2) + "/" + kikan.Substring(14, 2);
                        //txtKikan.Text = strFrom + "-" + strTo;
                //    }
                //}
                //// 期間の値が取得できている場合.
                //if (!minFrom.Equals("") && !maxTo.Equals(""))
                //{
                //    // 形式変更.
                //    string strFrom = minFrom.Substring(0, 4) + "/" + minFrom.Substring(4, 2) + "/" + minFrom.Substring(6, 2);
                //    string strTo = maxTo.Substring(0, 4) + "/" + maxTo.Substring(4, 2) + "/" + maxTo.Substring(6, 2);
                //    // 期間をセット.
                //    txtKikan.Text = strFrom + "-" + strTo;
                //}
                /* 2013/04/23 期間のFromToをMin値～Max値に変更対応 JSE M.Naito MOD End */

                // デフォルトで表示する請求先部門をマスタデータから取得する.
                // 請求部門.
                CmbSeikyusakiBumon.Text = SetBumonValue();

                //請求年月.
                txtSeikyuYyyymm.Value = _dataRow.hb1Yymm.ToString();
                txtSeikyuYyyymm.cmbYM_SetDate();

                // 合計金額.
                txtGoukeiKingaku.Text = _dataRow.hb1SeiGak.ToString("###,###,###,##0");

                // 合計消費税額.
                txtShohiZeigaku.Text = _dataRow.hb1SzeiGak.ToString("###,###,###,##0");

                // 明細入力画面の下部(請求一覧帳票に必要な情報)をスプレッドに値セット.
                Isid.KKH.Kmn.Schema.DetailDSKmn.KkhDetailDataTable dtDetail = new Isid.KKH.Kmn.Schema.DetailDSKmn.KkhDetailDataTable();
                Isid.KKH.Kmn.Schema.DetailDSKmn.KkhDetailRow addRow = dtDetail.NewKkhDetailRow();
                // 受注データをデフォルト表示する.
                foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow row in dataRows)
                {
                    // 統合データの場合.
                    if (_dataRow.hb1TouFlg == "1")
                    {
                        // 業務区分ごとに内容に設定する受注データを取得する.
                        addRow.Naiyou = detailDisp.SetJuchuValue_naiyo(_mCurrentGyomuKbn, row);
                    }
                    else
                    {
                        // 統合データ以外の場合は品目を連結した文字列を設定する.
                        addRow.Naiyou = hinmokuArray[0] + " " + hinmokuArray[1] + " " + hinmokuArray[2];
                    }
                    // 費目.
                    addRow.Himoku = row.hb1HimkNmKJ;

                    // 請求区分ごとに期間をセット.
                    String kikan = detailDisp.SetKikanValue(row.hb1SeiKbn.ToString().Trim(), row);
                    if (kikan != "")
                    {
                        if (kikan.Length == 16)
                        {
                            string strFrom = kikan.Substring(0, 4) + "/" + kikan.Substring(4, 2) + "/" + kikan.Substring(6, 2);
                            string strTo = kikan.Substring(8, 4) + "/" + kikan.Substring(12, 2) + "/" + kikan.Substring(14, 2);
                            addRow.Kikan = strFrom + "-" + strTo;
                        }
                    }

                    decimal temp = Math.Floor(row.hb1SzeiRitu);

                    // 金額.
                    addRow.Kingaku = row.hb1SeiGak.ToString("###,###,###,##0");

                    // 消費税額.
                    addRow.Zeigaku = row.hb1SzeiGak.ToString("###,###,###,##0");

                    // 備考.
                    addRow.Biko = "";
                    dtDetail.AddKkhDetailRow(addRow);
                    addRow = dtDetail.NewKkhDetailRow();
                }

                _dsDetailKmn.KkhDetail.Clear();
                _dsDetailKmn.KkhDetail.Merge(dtDetail);
                _dsDetailKmn.KkhDetail.AcceptChanges();
            }
            // 明細がある場合.
            else
            {
                Isid.KKH.Kmn.Schema.DetailDSKmn.KkhDetailDataTable dtDetail = new Isid.KKH.Kmn.Schema.DetailDSKmn.KkhDetailDataTable();

                Isid.KKH.Kmn.Schema.DetailDSKmn.KkhDetailRow addRow = dtDetail.NewKkhDetailRow();

                // 明細の件数分繰り返す.
                for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
                {
                    // 初期化.
                    addRow = dtDetail.NewKkhDetailRow();

                    // 品目名1.
                    txtHinmoku1.Text = _spdKkhDetail_Sheet1.Cells[i, DetailKmn.COLIDX_MLIST_HINMOKU1].Text.Trim();
                    // 品目名2.
                    txtHinmoku2.Text = _spdKkhDetail_Sheet1.Cells[i, DetailKmn.COLIDX_MLIST_HINMOKU2].Text.Trim();
                    // 品目名3.
                    txtHinmoku3.Text = _spdKkhDetail_Sheet1.Cells[i, DetailKmn.COLIDX_MLIST_HINMOKU3].Text.Trim();
                    // 費目.
                    txtHimoku.Text = _spdKkhDetail_Sheet1.Cells[i, DetailKmn.COLIDX_MLIST_HIMOKU].Text.Trim();
                    // 期間.
                    txtKikan.Text = _spdKkhDetail_Sheet1.Cells[i, DetailKmn.COLIDX_MLIST_KIKAN].Text.Trim();
                    // 部門コード.
                    BumonCD = _spdKkhDetail_Sheet1.Cells[i, DetailKmn.COLIDX_MLIST_BUMONCODE].Text.Trim();
                    // 請求部門.
                    CmbSeikyusakiBumon.Text = _spdKkhDetail_Sheet1.Cells[i, DetailKmn.COLIDX_MLIST_SEIKYUSAKIBUMON].Text.Trim();
                    // 請求年月.
                    txtSeikyuYyyymm.Value = _spdKkhDetail_Sheet1.Cells[i, DetailKmn.COLIDX_MLIST_SEIKYUYYYYMM].Text.Trim();
                    txtSeikyuYyyymm.cmbYM_SetDate();

                    // 合計金額.
                    txtGoukeiKingaku.Text = _spdKkhDetail_Sheet1.Cells[i, DetailKmn.COLIDX_MLIST_GOUKEIKINGAKU].Text.Trim();
                    // 合計消費税額.
                    txtShohiZeigaku.Text = _spdKkhDetail_Sheet1.Cells[i, DetailKmn.COLIDX_MLIST_GOUKEIZEIGAKU].Text.Trim();
                    // 内容.
                    addRow.Naiyou = _spdKkhDetail_Sheet1.Cells[i, DetailKmn.COLIDX_MLIST_NAIYOU].Text.Trim();
                    // 費目.
                    addRow.Himoku = _spdKkhDetail_Sheet1.Cells[i, DetailKmn.COLIDX_MLIST_HIMOKU_M].Text.Trim();
                    // 期間.
                    addRow.Kikan = _spdKkhDetail_Sheet1.Cells[i, DetailKmn.COLIDX_MLIST_KIKAN_M].Text.Trim();
                    // 金額.
                    addRow.Kingaku = _spdKkhDetail_Sheet1.Cells[i, DetailKmn.COLIDX_MLIST_KINGAKU].Text.Trim();
                    // 消費税額.
                    addRow.Zeigaku = _spdKkhDetail_Sheet1.Cells[i, DetailKmn.COLIDX_MLIST_ZEIGAKU].Text.Trim();
                    // 備考.
                    addRow.Biko = _spdKkhDetail_Sheet1.Cells[i, DetailKmn.COLIDX_MLIST_BIKO].Text.Trim();

                    dtDetail.AddKkhDetailRow(addRow);
                }

                _dsDetailKmn.KkhDetail.Clear();
                _dsDetailKmn.KkhDetail.Merge(dtDetail);
                _dsDetailKmn.KkhDetail.AcceptChanges();
            }
        }
        #endregion 各コントロールの編集処理.

        #region 合計消費税額の再計算.
        /// <summary>
        /// 合計消費税額の再計算.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetShohiZeigaku()
        {
            // 変数初期化.
            decimal G_Zeigaku = 0;
            decimal Zeigaku = 0;

            // 合計消費税額txtboxを再計算.
            // 明細の消費税額をすべて足して合計消費税額txtboxへセット.
            for (int i = 0; i < spdDetailInput_Sheet1.RowCount; i++)
            {
                // 金額.
                if (spdDetailInput_Sheet1.Cells[i, COLIDX_SHOHIZEIGAK].Text.Trim() == "")
                {
                    decimal Zeigaku_tmp = 0;

                    // 消費税額になにも入力されていなかったら0をセット.
                    Zeigaku = Zeigaku_tmp;
                }
                else
                {
                    // １行ずつ消費税額を取得.
                    Zeigaku = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[i, COLIDX_SHOHIZEIGAK].Value.ToString());
                }

                // 消費税額を足しこむ.
                G_Zeigaku = G_Zeigaku + Zeigaku;
            }

            // 合計消費税額txtboxにセット.
            txtShohiZeigaku.Text = G_Zeigaku.ToString("###,###,###,##0");
        }
        #endregion 合計消費税額の再計算.

        #region 合計金額の再計算.
        /// <summary>
        /// 合計金額の再計算.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetGoukeikingaku()
        {
            // 変数初期化.
            decimal G_kingaku = 0;
            decimal kingaku = 0;

            // 合計金額txtboxを再計算.
            // 明細の金額をすべて足して合計金額txtboxへセット.
            for (int i = 0; i < spdDetailInput_Sheet1.RowCount; i++)
            {
                // 金額.
                if (spdDetailInput_Sheet1.Cells[i, COLIDX_KINGAKU].Text.Trim() == "")
                {
                    decimal kingaku_tmp = 0;

                    // 金額になにも入力されていなかったら0をセット.
                    kingaku = kingaku_tmp;
                }
                else
                {
                    // １行ずつ金額を取得.
                    kingaku = KKHUtility.DecParse(spdDetailInput_Sheet1.Cells[i, COLIDX_KINGAKU].Value.ToString());
                }

                // 金額を足しこむ.
                G_kingaku = G_kingaku + kingaku;
            }

            // 合計金額txtboxにセット.
            txtGoukeiKingaku.Text = G_kingaku.ToString("###,###,###,##0");
        }
        #endregion 合計金額の再計算.

        #region 請求先部門をコンボボックスにセットする.
        /// <summary>
        /// 請求先部門をコンボボックスにセットする.
        /// </summary>
        private void SetSeikyusakiBumonCmb()
        {
            MasterMaintenanceProcessController process =
                MasterMaintenanceProcessController.GetInstance();

            FindMasterMaintenanceByCondServiceResult result;

            // 請求先部門.
            result = process.FindMasterByCond(_naviParam.EsqId,
                                            _naviParam.Egcd,
                                            _naviParam.TksKgyCd,
                                            _naviParam.TksBmnSeqNo,
                                            _naviParam.TksTntSeqNo,
                                             DetailKmn.C_MST_ATESAKI,
                                            null);

            MasterMaintenance.MasterDataVODataTable dtAtesaki =
                new MasterMaintenance.MasterDataVODataTable();
            MasterMaintenance.MasterDataVORow voRow2 = dtAtesaki.NewMasterDataVORow();
            //空行を追加.
            dtAtesaki.AddMasterDataVORow(voRow2);
            if (result.MasterDataSet.MasterDataVO != null)
            {
                dtAtesaki.Merge(result.MasterDataSet.MasterDataVO);

                htAtesaki = new Hashtable();

                // 比較項目と部門略称をセットで保持.
                foreach (MasterMaintenance.MasterDataVORow row in result.MasterDataSet.MasterDataVO)
                {
                    htAtesaki.Add(row.Column4, row.Column2);
                }
            }

            dtAtesaki.AcceptChanges();


            /* 2013/04/23 部署名の重複表示排除対応 JSE M.Naito ADD Start */
            MasterMaintenance.MasterDataVODataTable dtAtesaki_new = new MasterMaintenance.MasterDataVODataTable();

            foreach (MasterMaintenance.MasterDataVORow row1 in result.MasterDataSet.MasterDataVO)
            {
                // 新規行作成.
                MasterMaintenance.MasterDataVORow newrow = (MasterMaintenance.MasterDataVORow)dtAtesaki_new.NewRow();

                if (dtAtesaki_new.Count > 0)
                {
                    // 部門略称と宛先が一致するデータをDataTableから取得.

                    DataRow[] dt = dtAtesaki_new.Select(dtAtesaki_new.Column2Column.ColumnName + "='" + row1.Column2 + "' AND " + dtAtesaki_new.Column3Column.ColumnName + "='" + row1.Column3 + "'");

                    // DataTableに同じ部門略称が存在しない場合.
                    if (dt.Length == 0)
                    {
                        // 部門略称を取得.
                        newrow.Column2 = row1.Column2;
                        // コードを取得.
                        newrow.Column1 = row1.Column1;
                        // 宛先を取得.
                        newrow.Column3 = row1.Column3;

                        // DataTableに追加.
                        dtAtesaki_new.AddMasterDataVORow(newrow);
                    }
                }
                else
                {
                    // 部門略称を取得.
                    newrow.Column2 = row1.Column2;
                    // コードを取得.
                    newrow.Column1 = row1.Column1;
                    // 宛先を取得.
                    newrow.Column3 = row1.Column3;
                    // 空行を追加.
                    MasterMaintenance.MasterDataVORow voRow2_new = dtAtesaki_new.NewMasterDataVORow();
                    dtAtesaki_new.AddMasterDataVORow(voRow2_new);

                    // DataTableに追加.
                    dtAtesaki_new.AddMasterDataVORow(newrow);
                }
            }

            dtAtesaki_new.AcceptChanges();

            //コンボボックスのDataSourceにDataTableを割り当てる.
            this.CmbSeikyusakiBumon.DataSource = dtAtesaki_new;

            //表示される値はDataTableのColumn2列.
            this.CmbSeikyusakiBumon.DisplayMember = dtAtesaki_new.Column2Column.ColumnName;
            //表示と対応するコード値はDataTableのColumn1列.
            this.CmbSeikyusakiBumon.ValueMember = dtAtesaki_new.Column1Column.ColumnName;

            ////コンボボックスのDataSourceにDataTableを割り当てる.
            //this.CmbSeikyusakiBumon.DataSource = dtAtesaki;
            ////表示される値はDataTableのColumn2列.
            //this.CmbSeikyusakiBumon.DisplayMember = dtAtesaki.Column2Column.ColumnName;
            ////表示と対応するコード値はDataTableのColumn1列.
            //this.CmbSeikyusakiBumon.ValueMember = dtAtesaki.Column1Column.ColumnName;
            /* 2013/04/23 部署名の重複表示排除対応 JSE M.Naito MOD End */
        }
        #endregion 請求先部門をコンボボックスにセットする.

        #region デフォルトで表示する請求先部門を取得する.
        /// <summary>
        /// デフォルトで表示する請求先部門を取得する.
        /// </summary>
        /// <returns></returns>
        private string SetBumonValue()
        {
            // 変数初期化.
            string result = string.Empty;
            string kenNm = string.Empty;

            // 件名から【xxx】を抜き出すため存在チェック.
            if (_dataRow.hb1KKNameKJ.IndexOf('【') >= 0 && _dataRow.hb1KKNameKJ.IndexOf('】') >= 0)
            {
                // それぞれの文字位置を取得.
                int tmp_start = _dataRow.hb1KKNameKJ.IndexOf('【');
                int tmp_end = _dataRow.hb1KKNameKJ.IndexOf('】');
                if (tmp_start < tmp_end)
                {
                    // 抜き出す文字数.
                    int moji = tmp_end - tmp_start;
                    // 抜き出す.
                    kenNm = _dataRow.hb1KKNameKJ.Substring(tmp_start, moji + 1);

                    // 宛先マスタの比較項目に一致するかチェック.
                    if (htAtesaki.ContainsKey(kenNm))
                    {
                        // 一致した請求先部門を取得.
                        result = (string)htAtesaki[kenNm];
                    }
                }
            }
            
            return result;
        }
        #endregion デフォルトで表示する請求先部門を取得する.

        #region 業務区分ごとにスプレッドの列表示設定.
        /// <summary>
        /// 業務区分ごとにスプレッドの列表示設定.
        /// </summary>
        /// <param name="GyomKbn"></param>
        private void VisibleSpdDetailInputColumns(string GyomKbn)
        {
            switch (GyomKbn)
            {
                // 新聞.
                case C_GYOM_SHINBUN:

                    spdDetailInput_Sheet1.Columns[COLIDX_NAIYOU].Visible = true;
                    spdDetailInput_Sheet1.Columns[COLIDX_HIMOKU_M].Visible = true;
                    spdDetailInput_Sheet1.Columns[COLIDX_KIKAN_M].Visible = true;
                    spdDetailInput_Sheet1.Columns[COLIDX_KINGAKU].Visible = true;
                    break;

                default:
                    spdDetailInput_Sheet1.Columns[COLIDX_NAIYOU].Visible = true;
                    spdDetailInput_Sheet1.Columns[COLIDX_HIMOKU_M].Visible = true;
                    spdDetailInput_Sheet1.Columns[COLIDX_KIKAN_M].Visible = true;
                    spdDetailInput_Sheet1.Columns[COLIDX_KINGAKU].Visible = true;
                    break;
            }
        }
        #endregion 業務区分ごとにスプレッドの列表示設定.

        #region OKボタンクリック時の入力チェック.
        /// <summary>
        /// OKボタンクリック時の入力チェック.
        /// </summary>
        /// <returns></returns>
        private bool CheckBtnOK()
        {
            for (int i = 0; i < spdDetailInput_Sheet1.RowCount; i++)
            {
                // チェック対象の値格納用変数.
                string chkVal = "";
                // エラーメッセージ文字列格納用変数.
                string errMsg = "期間：YYYY/MM/DD-YYYY/MM/DD形式で入力されていません。";

                if (CheckBaitaiData(i) == false)
                {
                    return false;
                }

                //金額.
                if (spdDetailInput_Sheet1.Columns[COLIDX_KINGAKU].Visible == true)
                {
                    chkVal = spdDetailInput_Sheet1.Cells[i, COLIDX_KINGAKU].Text.Replace(",", "");

                    if (chkVal != "" && (KKHUtility.GetByteCount(chkVal) > 13 || KKHUtility.IsNumeric(chkVal) == false))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0003, new string[] { "金額" }, "入力エラー", MessageBoxButtons.OK);
                        return false;
                    }
                }

                // 期間(明細).
                if (spdDetailInput_Sheet1.Columns[COLIDX_KIKAN_M].Visible == true)
                {
                    chkVal = spdDetailInput_Sheet1.Cells[i, COLIDX_KIKAN_M].Text;

                    // ハイフンの存在チェック.
                    if (chkVal.IndexOf("-") >= 0)
                    {
                        // 存在する.
                        // ハイフン前後の文字列を取得.
                        int hai = chkVal.IndexOf("-");
                        string maestr = chkVal.Substring(0, hai);
                        string atostr = chkVal.Substring(hai + 1);

                        // 両方の文字列が日付に変換できるかチェック.
                        if (!KKHUtility.IsDate(maestr, "yyyy/MM/dd") || !KKHUtility.IsDate(atostr, "yyyy/MM/dd"))
                        {
                            // 変換できない.
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { errMsg }, "入力エラー", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                    else
                    {
                        // 存在しない.
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { errMsg }, "入力エラー", MessageBoxButtons.OK);
                        return false;
                    }
                }

                // 期間.
                if (txtKikan.Visible == true)
                {
                    chkVal = txtKikan.Text;

                    // ハイフンの存在チェック.
                    if (chkVal.IndexOf("-") >= 0)
                    {
                        // 存在する.
                        // ハイフン前後の文字列を取得.
                        int hai = chkVal.IndexOf("-");
                        string maestr = chkVal.Substring(0, hai);
                        string atostr = chkVal.Substring(hai + 1);

                        // 両方の文字列が日付に変換できるかチェック.
                        if (!KKHUtility.IsDate(maestr, "yyyy/MM/dd") || !KKHUtility.IsDate(atostr, "yyyy/MM/dd"))
                        {
                            // 変換できない.
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { errMsg }, "入力エラー", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                    else
                    {
                        // 存在しない.
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new string[] { errMsg }, "入力エラー", MessageBoxButtons.OK);
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion OKボタンクリック時の入力チェック.

        #region 詳細情報項目が設定されているかをチェック.
        /// <summary>
        /// 詳細情報項目が設定されているかをチェック.
        /// </summary>
        /// <param name="rowIdx"></param>
        /// <returns></returns>
        private bool CheckBaitaiData(int rowIdx)
        {
            // 品目1.
            if (txtHinmoku1.Text.Trim() == "")
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] {"品目１"}, "必須入力エラー", MessageBoxButtons.OK);
                return false;
            }

            // 請求年月.
            if (txtSeikyuYyyymm.Text.Trim() == "")
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] { "請求年月" }, "必須入力エラー", MessageBoxButtons.OK);
                return false;
            }

            // 内容.
            if (spdDetailInput_Sheet1.Cells[rowIdx, COLIDX_NAIYOU].Text.Trim() == "")
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] { "内容" }, "必須入力エラー", MessageBoxButtons.OK);
                return false;
            }

            // 費目.
            if (txtHimoku.Text.Trim() == "")
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] { "費目" }, "必須入力エラー", MessageBoxButtons.OK);
                return false;
            }

            // 費目(明細).
            if (spdDetailInput_Sheet1.Cells[rowIdx, COLIDX_HIMOKU_M].Text.Trim() == "")
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] { "費目" }, "必須入力エラー", MessageBoxButtons.OK);
                return false;
            }

            // 金額.
            if (spdDetailInput_Sheet1.Cells[rowIdx, COLIDX_KINGAKU].Text.Trim() == "")
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] { "金額" }, "必須入力エラー", MessageBoxButtons.OK);
                return false;
            }

            // 消費税額.
            if (spdDetailInput_Sheet1.Cells[rowIdx, COLIDX_SHOHIZEIGAK].Text.Trim() == "")
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0117, new string[] { "消費税額" }, "必須入力エラー", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
        #endregion 詳細情報項目が設定されているかをチェック.

        #region ペースト処理.
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
            // キー=「列, 行」値 = 貼り付け値.
            Dictionary<string, string> pastDic = KKHUtility.getPastValueDic(val);

            if (pastDic.Count == 1)
            {
                // 複数コピーでない場合.
                multiCopyFlg = false;
            }

            // コピー分のセル走査.
            foreach (string pastKey in pastDic.Keys)
            {
                // キー「列, 行」を分割.
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
                    spdDetailInput_Change(this.spdDetailInput, changeEvent);
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
                // ロックされている場合.
                return false;
            }

            //非表示列へは貼り付け不可とする.
            if (actColumn.Visible.Equals(false))
            {
                return false;
            }

            if (actColumn.CellType is TextCellType || actColumn.CellType is NumberCellType)
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
        #endregion コピー可能列確認.

        #region スプレッド内容変更時.
        /// <summary>
        /// スプレッド内容変更時.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdDetailInput_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            // 消費税額合計の再計算.
            SetShohiZeigaku();

            // 合計金額の再計算.
            SetGoukeikingaku();
        }
        #endregion スプレッド内容変更時.
        #endregion メソッド.
    }
}