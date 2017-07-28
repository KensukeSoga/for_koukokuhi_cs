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
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Skyp.ProcessController.Detail;
using Isid.KKH.Skyp.Schema;
namespace Isid.KKH.Skyp.View.Detail
{
    /// <summary>
    /// 明細入力画面（スカパー） 
    /// </summary>
    public partial class DetailInputSkyp : Common.KKHView.Common.Form.KKHDialogBase
    {
        #region 定数

        /// <summary>
        /// テンプレートリスト名称：""（空白） 
        /// </summary>
        private const string TEMPLATE_NAME_00 = "";
        /// <summary>
        /// テンプレートリスト名称：新聞 
        /// </summary>
        private const string TEMPLATE_NAME_01 = "新聞";
        /// <summary>
        /// テンプレートリスト名称：スポーツ紙 
        /// </summary>
        private const string TEMPLATE_NAME_02 = "スポーツ紙";
        /// <summary>
        /// テンプレートリスト名称：雑誌 
        /// </summary>
        private const string TEMPLATE_NAME_03 = "雑誌";
        /// <summary>
        /// テンプレートリスト名称：ラジオ 
        /// </summary>
        private const string TEMPLATE_NAME_04 = "ラジオ";
        /// <summary>
        /// テンプレートリスト名称：テレビタイム 
        /// </summary>
        private const string TEMPLATE_NAME_05 = "テレビタイム";
        /// <summary>
        /// テンプレートリスト名称：テレビスポット 
        /// </summary>
        private const string TEMPLATE_NAME_06 = "テレビスポット";
        /// <summary>
        /// テンプレートリスト名称：ＢＳ 
        /// </summary>
        private const string TEMPLATE_NAME_07 = "ＢＳ";
        /// <summary>
        /// テンプレートリスト名称：ＷＥＢ 
        /// </summary>
        private const string TEMPLATE_NAME_08 = "ＷＥＢ";

        /// <summary>
        /// テンプレートリストID：0:""（空白） 
        /// </summary>
        private const string TEMPLATE_ID_00 = "0";
        /// <summary>
        /// テンプレートリストID：1:新聞 
        /// </summary>
        private const string TEMPLATE_ID_01 = "1";
        /// <summary>
        /// テンプレートリストID：2:スポーツ紙 
        /// </summary>
        private const string TEMPLATE_ID_02 = "2";
        /// <summary>
        /// テンプレートリストID：3:雑誌 
        /// </summary>
        private const string TEMPLATE_ID_03 = "3";
        /// <summary>
        /// テンプレートリストID：4:ラジオ 
        /// </summary>
        private const string TEMPLATE_ID_04 = "4";
        /// <summary>
        /// テンプレートリストID：5:テレビタイム 
        /// </summary>
        private const string TEMPLATE_ID_05 = "5";
        /// <summary>
        /// テンプレートリストID：6:テレビスポット 
        /// </summary>
        private const string TEMPLATE_ID_06 = "6";
        /// <summary>
        /// テンプレートリストID：7:ＢＳ 
        /// </summary>
        private const string TEMPLATE_ID_07 = "7";
        /// <summary>
        /// テンプレートリストID：8:ＷＥＢ 
        /// </summary>
        private const string TEMPLATE_ID_08 = "8";

        /// <summary>
        /// 読み取り専用列の背景色 
        /// </summary>
        private static readonly Color COL_BACKCOLOR_LOCKED = Color.FromArgb(192, 192, 192);

        /// <summary>
        /// 分類マスタ取得キー：0001 
        /// </summary>
        private const string MST_BUNRUI = "0001";

        /// <summary>
        /// 明細スプレッド＿金額の最大値 
        /// </summary>
        private const double MAX_VALUE_KINGAK = 999999999999D;
        /// <summary>
        /// 明細スプレッド＿金額の最小値 
        /// </summary>
        private const double MIN_VALUE_KINGAK = -999999999999D;

        /// <summary>
        /// 処理モード列挙体 
        /// </summary>
        private enum Mode
        {
            /// <summary>
            /// 行挿入:0 
            /// </summary>
            Insert = 0,
            /// <summary>
            /// その他:99 
            /// </summary>
            Other = 99,
        }

        #endregion 定数

        #region メンバ変数

        /// <summary>
        /// 明細入力画面（スカパー）パラメータ 
        /// </summary>
        private DetailInputSkypNaviParameter _naviParameter = new DetailInputSkypNaviParameter();

        /// <summary>
        /// 受注ダウンロードデータ 
        /// </summary>
        private Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;

        /// <summary>
        /// 受注ダウンロードデータ（統合済み） 
        /// </summary>
        private Common.KKHSchema.Detail.JyutyuDataRow[] _mergeDataRow = null;

        /// <summary>
        /// 広告費明細データ 
        /// </summary>
        private SheetView _fpSpread1_Sheet1 = null;

        /// <summary>
        /// 機能ID 
        /// </summary>
        private string _aplId = string.Empty;

        /// <summary>
        /// 請求金額（明細入力画面の値） 
        /// </summary>
        private decimal _seigak = 0M;

        /// <summary>
        /// 請求金額合計（親画面（広告費明細入力画面）の値） 
        /// </summary>
        private decimal _seigakSum = 0M;

        /// <summary>
        /// 分類マスタ情報（キー） 
        /// </summary>
        private string[] _itemBunruiCd = null;

        /// <summary>
        /// 分類マスタ情報（名称） 
        /// </summary>
        private string[] _itemBunruiNm = null;

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
        /// ユーザーによる閉じる要求か（Navigator.Backwardの直前でtrueに設定する事）.
        /// </summary>
        private Boolean _userCloseRequest = false;

        private bool msgcheck = false;
        #endregion メンバ変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DetailInputSkyp()
        {
            InitializeComponent();
            _dataModel = (DefaultSheetDataModel)_spdKkhDetail_Sheet1.Models.Data;
        }

        #endregion コンストラクタ

        #region イベント

        /// <summary>
        /// 画面遷移するたびに発生します。 
        /// </summary>
        /// <param name="sender">遷移元フォーム</param>
        /// <param name="arg">イベントデータ</param>
        private void DetailInputSkyp_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is DetailInputSkypNaviParameter)
            {
                _naviParameter = (DetailInputSkypNaviParameter)arg.NaviParameter;
                _dataRow = _naviParameter.DataRow;
                _mergeDataRow = _naviParameter.MergeDataRow;
                _fpSpread1_Sheet1 = _naviParameter.SpdKkhDetail_Sheet1;
                _aplId = _naviParameter.AplId;
                _seigakSum = _naviParameter.SeigakSum;
            }
        }

        /// <summary>
        /// フォームロードイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailInputSkyp_Load(object sender, EventArgs e)
        {
            InitializeControl();
        }

        /// <summary>
        /// フォームShownイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailInputSkyp_Shown(object sender, EventArgs e)
        {
            InitializeDesignForSpdKkhDetail();
            EditControl();
        }

        /// <summary>
        /// 削除ボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            // 選択行の取得 
            CellRange[] cellRanges = _spdKkhDetail_Sheet1.GetSelections();

            if (cellRanges.Length == 0)
            {
                if (0 < _spdKkhDetail_Sheet1.Rows.Count)
                {
                    // 明細(一覧)から先頭行を削除する 
                    _spdKkhDetail_Sheet1.RemoveRows(0, 1);
                }
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

            // 小計（請求金額/値引額/取料金）の計算 
            CalcShokei();

            //選択状態を解除 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 行挿入ボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIns_Click(object sender, EventArgs e)
        {
            if (_spdKkhDetail_Sheet1.Rows.Count == 0)
            {
                // 受注ダウンロードデータを基に、明細データの設定する 
                SetDetailData(new Common.KKHSchema.Detail.JyutyuDataRow[] { _dataRow }, Mode.Insert);
            }
            else
            {
                // アクティブ行のコピーを挿入 
                int row = _spdKkhDetail_Sheet1.ActiveRowIndex;
                _spdKkhDetail_Sheet1.AddRows(row + 1, 1);

                for (int iCol = 0; iCol < _spdKkhDetail_Sheet1.Columns.Count; iCol++)
                {
                    if (iCol == DetailSkyp.COLIDX_MLIST_SEQ1)
                    {
                        decimal val = 0M;
                        object obj = null;
                        for (int iRow = 0; iRow < _spdKkhDetail_Sheet1.Rows.Count; iRow++)
                        {
                            obj = _spdKkhDetail_Sheet1.Cells[iRow, iCol].Value;

                            if (obj == null)
                            {
                                obj = 0;
                            }
                            if (val < KKHUtility.DecParse(obj.ToString()))
                            {
                                val = KKHUtility.DecParse(obj.ToString());
                            }
                        }
                        //_spdKkhDetail_Sheet1.Cells[row + 1, iCol].Value = val + 10;
                        ////1000を未満の場合 
                        //if (val + 10 < 1000)
                        //10000未満の場合 
                        if (val + 10 < 10000)
                        {
                            //10を加算してセット
                            _spdKkhDetail_Sheet1.Cells[row + 1, iCol].Value = val + 10;
                        }
                        //1000を超える場合 
                        else
                        {
                            //空とする 
                            _spdKkhDetail_Sheet1.Cells[row + 1, iCol].Value = "";
                        }
                    }
                    else
                    {
                        _spdKkhDetail_Sheet1.Cells[row + 1, iCol].Value = _spdKkhDetail_Sheet1.Cells[row, iCol].Value;
                    }
                }
            }

            // 小計（請求金額/値引額/取料金）の計算 
            CalcShokei();

            //選択状態を解除 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 登録ボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            // 明細が存在する場合 
            if (0 < _spdKkhDetail_Sheet1.Rows.Count)
            {
                // 明細チェック処理 
                if (!CheckDetailData()) { return; }
            }

            // 確認メッセージ表示 
            DialogResult ret = MessageUtility.ShowMessageBox(MessageCode.HB_C0002
                                                , null
                                                , "明細登録"
                                                , MessageBoxButtons.YesNo);
            if (ret == DialogResult.No) { return; }

            // 明細登録処理 
            UpdateDisplayDataServiceResult result;

            if (RegistDetailData(out result))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_I0001, null, "明細登録", MessageBoxButtons.OK);

                // ユーザーによる閉じる要求である
                _userCloseRequest = true;

                Navigator.Backward(this, result, null, true);
            }

            //選択状態を解除 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 戻るボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            // ユーザーによる閉じる要求である
            _userCloseRequest = true;

            Navigator.Backward(this, null, null, true);
        }

        /// <summary>
        /// 媒体名称一括テキストボックスChangedイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBaitaiNm_TextChanged(object sender, EventArgs e)
        {
            string str = txtBaitaiNm.Text;
            int len = txtBaitaiNm.MaxLength;
            if (_enc.GetByteCount(str) > len)
            {
                str = _enc.GetString(_enc.GetBytes(str), 0, len);
                txtBaitaiNm.Text = str;
            }
        }

        /// <summary>
        /// 媒体名称一括ボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBaitai_Click(object sender, EventArgs e)
        {
            // 媒体名称を一括設定する 
            for (int iRow = 0; iRow < _spdKkhDetail_Sheet1.Rows.Count; iRow++)
            {
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIMEI].Value = txtBaitaiNm.Text;
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
                case DetailSkyp.COLIDX_MLIST_BAITAIKBN:         // 媒体区分 
                case DetailSkyp.COLIDX_MLIST_BAITAIMEI:         // 媒体名称 

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

                case DetailSkyp.COLIDX_MLIST_SEQ1:              // 並び順 

                    // TextCellTypeの場合は最大バイト数の編集処理を行う 
                    if (_spdKkhDetail_Sheet1.Columns[e.Column].CellType is TextCellType)
                    {
                        TextCellType tc = (TextCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;
                        e.EditingControl.Text = e.EditingControl.Text.Trim('.');
                        e.EditingControl.Text = e.EditingControl.Text.Trim('-');
                        //"5-5"のような場合に対応 
                        e.EditingControl.Text = e.EditingControl.Text.Replace(".", "");
                        e.EditingControl.Text = e.EditingControl.Text.Replace("-", "");
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
        }

        /// <summary>
        /// 明細スプレッドのセルにフォーカスを移動するときに発生します 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_EnterCell(object sender, EnterCellEventArgs e)
        {
            _col = e.Column;
            _row = e.Row;

            switch (e.Column)
            {
                case DetailSkyp.COLIDX_MLIST_SEQ1:              // 並び順 
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
            switch (_col)
            {
                case DetailSkyp.COLIDX_MLIST_TORIGAK:           // 取金額 
                case DetailSkyp.COLIDX_MLIST_NEBIRITU:          // 値引率 
                case DetailSkyp.COLIDX_MLIST_KINGAK:            // 売上額（請求金額） 
                case DetailSkyp.COLIDX_MLIST_SYOHIRITU:         // 消費税率 
                case DetailSkyp.COLIDX_MLIST_SYOHI:             // 消費税額 
                case DetailSkyp.COLIDX_MLIST_NEBIGAK:           // 値引額 

                    // 値が空文字、Nullの場合、デフォルト値を設定する 
                    if (_spdKkhDetail_Sheet1.Cells[_row, _col].Value == null ||
                        string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[_row, _col].Text))
                    {
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Value = 0;
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Text = "0";
                    }

                    // 自動計算 
                    CalcAuto(_row, _col);

                    // 小計（請求金額/値引額/取料金）の計算 
                    CalcShokei();
                    break;

                case DetailSkyp.COLIDX_MLIST_KOMOKUCODE:        // 項目コード 
                    _spdKkhDetail_Sheet1.Cells[_row, DetailSkyp.COLIDX_MLIST_KOMOKUMEI].Value =
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Text;
                    if (string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[_row, _col].Text))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0151
                                        , null
                                        , "明細登録(スカパー)"
                                        , MessageBoxButtons.OK
                                        );
                    }
                    break;

                case DetailSkyp.COLIDX_MLIST_KOMOKUMEI:         // 項目名称 
                    _spdKkhDetail_Sheet1.Cells[_row, DetailSkyp.COLIDX_MLIST_KOMOKUCODE].Value =
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Value;
                    break;

                case DetailSkyp.COLIDX_MLIST_SEQ1:              // 並び順 
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
            // 非編集状態でクリップボードから貼り付けした場合 
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
                            s = _enc.GetString(_enc.GetBytes(s), 0, tc.MaxLength);
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
        /// スプレッドチェンジイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_Change(object sender, ChangeEventArgs e)
        {
            //switch (e.Column)
            switch (e.Column)
            {
                case DetailSkyp.COLIDX_MLIST_TORIGAK:           // 取金額 
                case DetailSkyp.COLIDX_MLIST_NEBIRITU:          // 値引率 
                case DetailSkyp.COLIDX_MLIST_KINGAK:            // 売上額（請求金額） 
                case DetailSkyp.COLIDX_MLIST_SYOHIRITU:         // 消費税率 
                case DetailSkyp.COLIDX_MLIST_SYOHI:             // 消費税額 
                case DetailSkyp.COLIDX_MLIST_NEBIGAK:           // 値引額 

                    // 値が空文字、Nullの場合、デフォルト値を設定する 
                    if (_spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Value == null ||
                        string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Text))
                    {
                        _spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Value = 0;
                        _spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Text = "0";
                    }

                    // 自動計算 
                    CalcAuto(e.Row, e.Column);

                    // 小計（請求金額/値引額/取料金）の計算 
                    CalcShokei();
                    break;

                case DetailSkyp.COLIDX_MLIST_KOMOKUCODE:        // 項目コード 
                    _spdKkhDetail_Sheet1.Cells[e.Row, DetailSkyp.COLIDX_MLIST_KOMOKUMEI].Value =
                        _spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Text;
                    if (msgcheck)
                    {
                        if (string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Text))
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0151
                                            , null
                                            , "明細登録(スカパー)"
                                            , MessageBoxButtons.OK
                                            );

                        }
                    }
                    msgcheck = false;
                    break;

                case DetailSkyp.COLIDX_MLIST_KOMOKUMEI:         // 項目名称 
                    _spdKkhDetail_Sheet1.Cells[e.Row, DetailSkyp.COLIDX_MLIST_KOMOKUCODE].Value =
                        _spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Value;
                    break;

                case DetailSkyp.COLIDX_MLIST_SEQ1:              // 並び順 
                    _dataModel.Changed -= new SheetDataModelEventHandler(dataModel_Changed);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// スプレッドキーダウンイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Control)
            {
                //Ctrl+Vが押下された場合、クリップボードの内容を貼り付け
                FpSpread fpSpread = sender as FpSpread;
                CellRange[] range = fpSpread.ActiveSheet.GetSelections();

                // クリップボードの値をセルに当てはめる
                string clipVal = Clipboard.GetText();

                // 選択したセル範囲情報を走査する
                foreach (CellRange rn in range)
                {
                    // 列 
                    int col = rn.Column;
                    // 行 
                    int row = rn.Row;
                    // 選択範囲終了列
                    int colEnd = (rn.Column + rn.ColumnCount - 1);
                    // 選択範囲終了行 
                    int rowEnd = (rn.Row + rn.RowCount - 1);
                    for (int colCnt = col; colCnt <= colEnd; colCnt++)
                    {
                        bool multiCopyFlg = false;
                        // 行分ループ 
                        for (int rowCnt = row; rowCnt < rowEnd + 1; rowCnt++)
                        {
                            multiCopyFlg = isSetContinuePast(this.spdKkhDetail.GetRootWorkbook(), clipVal, rowCnt, colCnt);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailInputSkyp_FormClosing(object sender, FormClosingEventArgs e)
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

        #endregion イベント

        #region メソッド

        /// <summary>
        /// 各コントロールの初期設定 
        /// </summary>
        private void InitializeControl()
        {
            InputMap im = new InputMap();

            // 非編集セルでの[F2]キーを無効 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);

            // 編集中セルでの[F2]キーを無効 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);

            // 非編集セルでの[Enter]キーを「次行へ移動」 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow);

            // 編集中セルでの[Enter]キーを「次行へ移動」 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow);

            // 非編集セルでの[Z]キー+[Control]キーを無効 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.Z, Keys.Control), SpreadActions.None);

            // 編集中セルでの[Z]キー+[Control]キーを無効 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Z, Keys.Control), SpreadActions.None);

            // 各金額テキストボックス 
            txtTorigak.Text = "0";
            txtSyohigak.Text = "0";
            txtNebigak.Text = "0";
            txtSeigak.Text = "0";
            txtSeigakSum.Text = "0";
            txtJyutSeigak.Text = "0";

            // 媒体名称テキストボックス
            txtBaitaiNm.Text = string.Empty;

            // テンプレートコンボボックス 
            Common.KKHSchema.Detail.ComboDataTable dtCombo =
                new Common.KKHSchema.Detail.ComboDataTable();
            dtCombo.AddComboRow(TEMPLATE_NAME_00, TEMPLATE_ID_00);
            dtCombo.AddComboRow(TEMPLATE_NAME_01, TEMPLATE_ID_01);
            dtCombo.AddComboRow(TEMPLATE_NAME_02, TEMPLATE_ID_02);
            dtCombo.AddComboRow(TEMPLATE_NAME_03, TEMPLATE_ID_03);
            dtCombo.AddComboRow(TEMPLATE_NAME_04, TEMPLATE_ID_04);
            dtCombo.AddComboRow(TEMPLATE_NAME_05, TEMPLATE_ID_05);
            dtCombo.AddComboRow(TEMPLATE_NAME_06, TEMPLATE_ID_06);
            dtCombo.AddComboRow(TEMPLATE_NAME_07, TEMPLATE_ID_07);
            dtCombo.AddComboRow(TEMPLATE_NAME_08, TEMPLATE_ID_08);

            cmbTempCode.DisplayMember = dtCombo.textColumn.ColumnName;
            cmbTempCode.ValueMember = dtCombo.valueColumn.ColumnName;
            cmbTempCode.DataSource = dtCombo;

            //マスタ情報を取得する 
            GetMasterData();
        }

        /// <summary>
        /// 各コントロールの編集処理 
        /// </summary>
        private void EditControl()
        {
            // 受注請求金額 
            decimal seigak = _dataRow.hb1SeiGak + _dataRow.hb1SzeiGak;
            txtJyutSeigak.Text = seigak.ToString("###,###,###,##0");

            // 広告費明細画面で選択された内容を表示する 
            if (0 < _fpSpread1_Sheet1.Rows.Count)
            {
                #region 追加・更新・削除

                // テンプレート 
                cmbTempCode.SelectedValue = _fpSpread1_Sheet1.Cells[_fpSpread1_Sheet1.Rows.Count - 1, DetailSkyp.COLIDX_MLIST_TEMPCODE].Value;

                for (int iRow = 0; iRow < _fpSpread1_Sheet1.Rows.Count; iRow++)
                {
                    // 行追加 
                    _spdKkhDetail_Sheet1.AddRows(iRow, 1);

                    // 件数分明細スプレッドに入力内容を設定 
                    // 業務区分 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_GYOMUKBN].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_GYOMUKBN].Value;

                    // タイムスポット 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TIMESPOTKBN].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TIMESPOTKBN].Value;

                    // 件名 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KENMEI].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KENMEI].Value;

                    // 電通・媒体名称 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value;

                    // 電通・期間 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value;

                    // 電通・内容 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value;

                    // 取料金 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TORIGAK].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TORIGAK].Value;

                    // 値引率 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIRITU].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIRITU].Value;

                    // 値引額 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIGAK].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIGAK].Value;

                    // 請求金額 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KINGAK].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KINGAK].Value;

                    // 消費税率 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SYOHIRITU].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SYOHIRITU].Value;

                    // 消費税額 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SYOHI].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SYOHI].Value;

                    // 媒体区分 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIKBN].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIKBN].Value;

                    // 媒体名称 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIMEI].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIMEI].Value;

                    // 項目コード（テキストを設定する） 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KOMOKUCODE].Text =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KOMOKUCODE].Text;

                    // 項目名称（テキストを設定する） 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KOMOKUMEI].Text =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KOMOKUMEI].Text;

                    // 並び順（媒体区分） 
                    decimal seq1 = GetDecimalValue(_fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ1].Value);
                    if (seq1 == 0)
                    {
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ1].Value = string.Empty;
                    }
                    else
                    {
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ1].Value = seq1;
                    }

                    // 並び順 
                    decimal seq2 = GetDecimalValue(_fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ2].Value);
                    if (seq2 == 0)
                    {
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ2].Value = string.Empty;
                    }
                    else
                    {
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ2].Value = seq2;
                    }

                    // 受注NO 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_JYUTNO].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_JYUTNO].Value;

                    // 受注明細NO 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_JYMEINO].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_JYMEINO].Value;

                    // 売上明細NO 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_URMEINO].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_URMEINO].Value;

                    // 請求原票NO 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_GPYNO].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_GPYNO].Value;

                    // 媒体区分 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIKBN2].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIKBN2].Value;

                    // タイムスタンプ 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TIMESTMP].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TIMESTMP].Value;

                    // テンプレートコード 
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TEMPCODE].Value =
                        _fpSpread1_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TEMPCODE].Value;
                }

                #endregion 追加・更新・削除
            }
            else
            {
                #region 新規

                if (!"1".Equals(_dataRow.hb1TouFlg))
                {
                    // テンプレート 
                    cmbTempCode.SelectedValue = SetTempCodeValue(_dataRow.hb1GyomKbn);

                    // 統合処理が存在しない場合 
                    // 受注ダウンロードデータを基に、明細データの設定する 
                    SetDetailData(new Common.KKHSchema.Detail.JyutyuDataRow[] { _dataRow }, Mode.Other);
                }
                else
                {
                    // テンプレート 
                    cmbTempCode.SelectedValue = SetTempCodeValue(_mergeDataRow[0].hb1GyomKbn);

                    // 統合処理が存在する場合 
                    // 受注ダウンロードデータ（統合済み）を基に、明細データの設定する 
                    SetDetailData(_mergeDataRow, Mode.Other);
                }

                #endregion 新規
            }

            // 小計（請求金額/値引額/取料金）の計算 
            CalcShokei();
        }

        /// <summary>
        /// 明細スプレッドのデザイン初期化を行う 
        /// </summary>
        private void InitializeDesignForSpdKkhDetail()
        {
            //********************************
            //スプレッド全体の設定 
            //********************************

            //********************************
            //列毎の設定 ※デザイナから列に対する設定を行うと変更が反映されないことがあるようなので暫定的にここで行う 
            //********************************
            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                //共通設定 
                col.AllowAutoFilter = true;//フィルタ機能を有効 
                col.AllowAutoSort = true;  //ソート機能を有効 

                //列毎に異なる設定 
                if (col.Index == DetailSkyp.COLIDX_MLIST_GYOMUKBN)
                {
                    col.Label = "業務区分";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_TIMESPOTKBN)
                {
                    col.Label = "タイムスポット区分";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_KENMEI)
                {
                    col.Label = "件名";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_DMEISYO)
                {
                    col.Label = "電通・媒体名称";
                    col.Width = 200;
                    col.Locked = true;
                    col.BackColor = COL_BACKCOLOR_LOCKED;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_DKIKAN)
                {
                    col.Label = "電通・期間";
                    col.Width = 120;
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                    col.Locked = true;
                    col.BackColor = COL_BACKCOLOR_LOCKED;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_DNAIYO)
                {
                    col.Label = "電通・内容";
                    col.Width = 150;
                    col.Locked = true;
                    col.BackColor = COL_BACKCOLOR_LOCKED;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_TORIGAK)
                {
                    col.Label = "取料金";
                    col.Width = 100;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAK;
                    cellType.MinimumValue = MIN_VALUE_KINGAK;
                    cellType.NullDisplay = "0";
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_NEBIRITU)
                {
                    col.Label = "値引率";
                    col.Width = 60;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.MaximumValue = 100D;
                    cellType.MinimumValue = -100D;
                    cellType.NullDisplay = "0";
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_NEBIGAK)
                {
                    col.Label = "値引額";
                    col.Width = 100;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAK;
                    cellType.MinimumValue = MIN_VALUE_KINGAK;
                    cellType.NullDisplay = "0";
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_KINGAK)
                {
                    col.Label = "請求金額";
                    col.Width = 120;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAK;
                    cellType.MinimumValue = MIN_VALUE_KINGAK;
                    cellType.NullDisplay = "0";
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_SYOHIRITU)
                {
                    col.Label = "消費税率";
                    col.Width = 65;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.MaximumValue = 100D;
                    cellType.MinimumValue = 0D;
                    cellType.NullDisplay = "0";
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_SYOHI)
                {
                    col.Label = "消費税額";
                    col.Width = 120;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAK;
                    cellType.MinimumValue = MIN_VALUE_KINGAK;
                    cellType.NullDisplay = "0";
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_BAITAIKBN)
                {
                    col.Label = "媒体区分";
                    col.Width = 250;
                    TextCellType cellType = new TextCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    cellType.MaxLength = 60;
                    cellType.CharacterSet = CharacterSet.AllIME;
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_BAITAIMEI)
                {
                    col.Label = "媒体名称";
                    col.Width = 200;
                    TextCellType cellType = new TextCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    cellType.MaxLength = 40;
                    cellType.CharacterSet = CharacterSet.AllIME;
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_KOMOKUCODE)
                {
                    col.Label = "項目コード";
                    col.Width = 80;
                    ComboBoxCellType cellType = new ComboBoxCellType();
                    //cellType.ItemData = _itemBunruiNm;
                    cellType.ItemData = _itemBunruiCd;
                    cellType.Items = _itemBunruiCd;
                    cellType.EditorValue = EditorValue.ItemData;
                    cellType.Editable = true;
                    cellType.AutoSearch = FarPoint.Win.AutoSearch.SingleCharacter;
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_KOMOKUMEI)
                {
                    col.Label = "項目名称";
                    col.Width = 250;
                    ComboBoxCellType cellType = new ComboBoxCellType();
                    cellType.ItemData = _itemBunruiCd;
                    cellType.Items = _itemBunruiNm;
                    cellType.EditorValue = EditorValue.ItemData;
                    cellType.Editable = false;
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_SEQ2)
                {
                    col.Label = "並び順２";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_SEQ1)
                {
                    col.Label = "並び順";
                    col.Width = 60;
                    TextCellType cellType = new TextCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    //cellType.MaxLength = 3;
                    cellType.MaxLength = 4;
                    cellType.CharacterSet = CharacterSet.Numeric;
                    col.CellType = cellType;
                    col.Locked = false;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_JYUTNO)
                {
                    col.Label = "受注NO";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_JYMEINO)
                {
                    col.Label = "受注明細NO";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_URMEINO)
                {
                    col.Label = "売上明細NO";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_GPYNO)
                {
                    col.Label = "請求原票NO";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_BAITAIKBN2)
                {
                    col.Label = "媒体区分";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_TIMESTMP)
                {
                    col.Label = "タイムスタンプ";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == DetailSkyp.COLIDX_MLIST_TEMPCODE)
                {
                    col.Label = "テンプレートコード";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
            }
        }

        /// <summary>
        /// マスタ情報を取得する 
        /// </summary>
        private void GetMasterData()
        {
            MasterMaintenanceProcessController processController =
                MasterMaintenanceProcessController.GetInstance();

            FindMasterMaintenanceByCondServiceResult result;
            MasterMaintenance.MasterDataVORow[] rows;
            string filter;

            // 分類マスタ情報取得 
            result = processController.FindMasterByCond(_naviParameter.strEsqId,
                                                        _naviParameter.strEgcd,
                                                        _naviParameter.strTksKgyCd,
                                                        _naviParameter.strTksBmnSeqNo,
                                                        _naviParameter.strTksTntSeqNo,
                                                        MST_BUNRUI,
                                                        null);

            List<string> lstKeys = new List<string>();
            List<string> lstValues = new List<string>();

            // 広告費明細入力画面で選択された業務区分のリストを先頭に表示させるため、 
            // 広告費明細入力画面で選択された業務区分のデータを取得しリストに保持する。 
            filter = "Column3 = \'" + _dataRow.hb1GyomKbn + "\'";
            rows = (MasterMaintenance.MasterDataVORow[])result.MasterDataSet.MasterDataVO.Select(filter);

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                lstKeys.Add(row.Column1);
                lstValues.Add(row.Column2);
            }

            // 広告費明細入力画面で選択された業務区分以外データを取得しリストに保持する。 
            filter = "Column3 <> \'" + _dataRow.hb1GyomKbn + "\'";
            rows = (MasterMaintenance.MasterDataVORow[])result.MasterDataSet.MasterDataVO.Select(filter);
            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                lstKeys.Add(row.Column1);
                lstValues.Add(row.Column2);
            }

            // リストを配列化し変数に保持する 
            _itemBunruiCd = lstKeys.ToArray();
            _itemBunruiNm = lstValues.ToArray();
        }

        /// <summary>
        /// テンプレートコンボボックスの初期値を設定する 
        /// </summary>
        /// <param name="gyomKbn">業務区分コード</param>
        /// <returns>テンプレートコード</returns>
        private string SetTempCodeValue(string gyomKbn)
        {
            string ret = string.Empty;

            switch (gyomKbn)
            {
                case KKHSystemConst.GyomKbn.Shinbun:        // 新聞 
                    ret = TEMPLATE_ID_01;
                    break;
                case KKHSystemConst.GyomKbn.Zashi:          // 雑誌 
                    ret = TEMPLATE_ID_03;
                    break;
                case KKHSystemConst.GyomKbn.Radio:          // ラジオ 
                    ret = TEMPLATE_ID_04;
                    break;
                case KKHSystemConst.GyomKbn.TVTime:         // テレビタイム 
                    ret = TEMPLATE_ID_05;
                    break;
                case KKHSystemConst.GyomKbn.TVSpot:         // テレビスポット 
                    ret = TEMPLATE_ID_06;
                    break;
                case KKHSystemConst.GyomKbn.EiseiM:         // 衛星メディア（BS） 
                    ret = TEMPLATE_ID_07;
                    break;
                case KKHSystemConst.GyomKbn.InteractiveM:   // インタラクティブメディア （WEB） 
                    ret = TEMPLATE_ID_08;
                    break;
                default:
                    break;
            }

            return ret;
        }

        /// <summary>
        /// 明細データの設定 
        /// </summary>
        /// <param name="dataRow">受注ダウンロードデータ</param>
        /// <param name="mode">処理モード</param>
        private void SetDetailData(Common.KKHSchema.Detail.JyutyuDataRow[] dataRow, Mode mode)
        {
            for (int iRow = 0; iRow < dataRow.Length; iRow++)
            {
                // 行追加 
                _spdKkhDetail_Sheet1.AddRows(iRow, 1);

                // 業務区分 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_GYOMUKBN].Value = dataRow[iRow].hb1GyomKbn.Trim();

                // タイムスポット 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TIMESPOTKBN].Value = dataRow[iRow].hb1TmspKbn.Trim();

                // 件名 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KENMEI].Value = dataRow[iRow].hb1KKNameKJ.Trim();

                // 取料金 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TORIGAK].Value = dataRow[iRow].hb1ToriGak;

                // 値引率 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIRITU].Value = dataRow[iRow].hb1NeviRitu;

                // 値引額 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIGAK].Value = dataRow[iRow].hb1NeviGak;

                // 請求金額 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KINGAK].Value = dataRow[iRow].hb1SeiGak;

                // 消費税率 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SYOHIRITU].Value = dataRow[iRow].hb1SzeiRitu;

                // 消費税額 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SYOHI].Value = dataRow[iRow].hb1SzeiGak;

                // 媒体区分 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIKBN].Value = dataRow[iRow].hb1KKNameKJ;

                // 媒体名称 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIMEI].Value = string.Empty;

                // 項目コード 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KOMOKUCODE].Value = string.Empty;

                // 項目名称 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KOMOKUMEI].Value = string.Empty;

                // 並び順（媒体区分） 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ2].Value = string.Empty;

                // 並び順 
                if (mode == Mode.Insert)
                {
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ1].Value = "10";
                }
                else
                {
                    _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SEQ1].Value = string.Empty;
                }

                // 受注NO 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_JYUTNO].Value = dataRow[iRow].hb1JyutNo.Trim();

                // 受注明細NO 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_JYMEINO].Value = dataRow[iRow].hb1JyMeiNo.Trim();

                // 売上明細NO 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_URMEINO].Value = dataRow[iRow].hb1UrMeiNo.Trim();

                // 請求原票NO 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_GPYNO].Value = dataRow[iRow].hb1GpyNo.Trim();

                // 媒体区分 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIKBN2].Value = dataRow[iRow].hb1KKNameKJ.Trim();

                // タイムスタンプ 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TIMESTMP].Value = string.Empty;

                // テンプレートコード 
                _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TEMPCODE].Value = string.Empty;


                // 請求区分により、電通・媒体名称、期間、内容を設定する 
                switch (dataRow[iRow].hb1SeiKbn)
                {
                    case KKHSystemConst.SeiKbn.NewsPaper:   // 新聞 
                        // 電通・媒体名称 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field2.Trim();

                        // 電通・期間                         
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field3.Trim());

                        // 電通・内容 
                        if (dataRow[iRow].hb1Field4 == "1")
                        {
                            _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value = "朝 " + dataRow[iRow].hb1Field11.Trim();
                        }
                        else if (dataRow[iRow].hb1Field4 == "2")
                        {
                            _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value = "夕 " + dataRow[iRow].hb1Field11.Trim();
                        }
                        else
                        {
                            _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value = dataRow[iRow].hb1Field11.Trim();
                        }
                        break;

                    case KKHSystemConst.SeiKbn.Magazine:    // 雑誌 
                        // 電通・媒体名称 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field2.Trim();

                        // 電通・期間 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field3.Trim());

                        // 電通・内容 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value = dataRow[iRow].hb1Field9.Trim();
                        break;

                    case KKHSystemConst.SeiKbn.Time:        // タイム 
                        // 電通・媒体名称 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field2.Trim();

                        // 電通・期間 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field8.Trim());

                        // 電通・内容 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value =
                            "秒数:" + dataRow[iRow].hb1Field5.Trim() + " 局数：" + dataRow[iRow].hb1Field3.Trim();
                        break;

                    case KKHSystemConst.SeiKbn.Spot:        // スポット 
                        // 電通・媒体名称 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field2.Trim();

                        // 電通・期間 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field4.Trim());

                        // 電通・内容 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value =
                            "秒数:" + dataRow[iRow].hb1Field5.Trim() + " 本数：" + dataRow[iRow].hb1Field6.Trim();
                        break;

                    case KKHSystemConst.SeiKbn.IC:          // IC 
                        // 電通・媒体名称 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field2.Trim();

                        // 電通・期間 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field5.Trim());

                        // 電通・内容 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value = "数量:" + dataRow[iRow].hb1Field6.Trim();
                        break;

                    case KKHSystemConst.SeiKbn.Ooh:         // 交通広告 
                        // 電通・媒体名称 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field2.Trim();

                        // 電通・期間 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field5.Trim());

                        // 電通・内容 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value =
                            "数量:" + dataRow[iRow].hb1Field6.Trim() + " " + dataRow[iRow].hb1Field8.Trim();
                        break;

                    case KKHSystemConst.SeiKbn.Works:       // 諸作業 
                        // 電通・媒体名称 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field4.Trim();

                        // 電通・期間 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field5.Trim());

                        // 電通・内容 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value =
                            "回数:" + dataRow[iRow].hb1Field6.Trim() + " " + dataRow[iRow].hb1Field3.Trim();
                        break;

                    case KKHSystemConst.SeiKbn.KMas:        // 国際マス 
                        // 電通・媒体名称 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field2.Trim();

                        // 電通・期間 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field3.Trim());

                        // 電通・内容 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value = dataRow[iRow].hb1Field11.Trim();
                        break;

                    case KKHSystemConst.SeiKbn.KWorks:      // 国際(諸作業） 
                        // 電通・媒体名称 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DMEISYO].Value = dataRow[iRow].hb1Field3.Trim();

                        // 電通・期間 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DKIKAN].Value = EditFromTo(dataRow[iRow].hb1Field4.Trim());

                        // 電通・内容 
                        _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_DNAIYO].Value = dataRow[iRow].hb1Field12.Trim();
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 日付の編集を行う 
        /// </summary>
        /// <param name="value">編集項目</param>
        /// <returns>編集後の値</returns>
        private string EditFromTo(string value)
        {
            string ret = string.Empty;
            if (value.Length == 8)
            {
                ret = value.Substring(4, 2) + "/" + value.Substring(6, 2);
            }
            else if (value.Length < 16)
            {
                ret = value;
            }
            else
            {
                ret = value.Substring(4, 2) + "/" + value.Substring(6, 2);
                ret += " - " + value.Substring(12, 2) + "/" + value.Substring(14, 2);
            }
            return ret;
        }

        /// <summary>
        /// 小計（請求金額/値引額/取料金）の計算 
        /// </summary>
        private void CalcShokei()
        {
            decimal torigak = 0M;
            decimal nebigak = 0M;
            decimal syohi = 0M;
            decimal kingak = 0M;

            for (int iRow = 0; iRow < _spdKkhDetail_Sheet1.Rows.Count; iRow++)
            {
                // 取料金を加算 
                torigak += KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TORIGAK].Text);

                // 値引額を加算 
                nebigak += KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIGAK].Text);

                // 消費税額を加算 
                syohi += KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_SYOHI].Text);

                // 請求額を加算 
                kingak += KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KINGAK].Text);
            }

            // 請求金額合計 
            txtSeigakSum.Text = kingak.ToString("###,###,###,##0");

            // 値引額合計 
            txtNebigak.Text = nebigak.ToString("###,###,###,##0");

            // 取料金合計 
            txtTorigak.Text = torigak.ToString("###,###,###,##0");

            // 消費税額 
            txtSyohigak.Text = syohi.ToString("###,###,###,##0");

            //ご請求額 
            decimal seigak = kingak + syohi;
            txtSeigak.Text = seigak.ToString("###,###,###,##0");
        }

        /// <summary>
        /// 自動計算 
        /// </summary>
        /// <param name="row">行インデックス</param>
        /// <param name="colmun">列インデックス</param>
        private void CalcAuto(int row, int colmun)
        {
            switch (colmun)
            {
                case DetailSkyp.COLIDX_MLIST_NEBIRITU:  // 値引率 
                case DetailSkyp.COLIDX_MLIST_TORIGAK:   // 取金額 
                    // 値引額を自動計算 
                    CalcAutoNebigak(row, colmun);

                    // 請求金額を自動計算 
                    CalcAutoKingak(row, colmun);

                    // 消費税額を自動計算 
                    CalcAutoSyohi(row, colmun);
                    break;

                case DetailSkyp.COLIDX_MLIST_SYOHIRITU: // 消費税率 
                case DetailSkyp.COLIDX_MLIST_KINGAK:    // 売上額（請求金額） 
                    // 消費税額を自動計算 
                    CalcAutoSyohi(row, colmun);
                    break;

                case DetailSkyp.COLIDX_MLIST_NEBIGAK:   // 売上額 
                    // 請求金額を自動計算 
                    CalcAutoKingak(row, colmun);

                    // 消費税額を自動計算 
                    CalcAutoSyohi(row, colmun);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 値引額を自動計算 
        /// </summary>
        /// <param name="row">行インデックス</param>
        /// <param name="colmun">列インデックス</param>
        private void CalcAutoNebigak(int row, int colmun)
        {
            decimal torigak = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_TORIGAK].Text);
            decimal nebiritu = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_NEBIRITU].Text);
            decimal nebigak = torigak * nebiritu / 100;

            if (nebigak != Math.Truncate(nebigak))
            {
                if (0 < nebigak)
                {
                    // プラスへ切り上げる 
                    nebigak += 1;
                }
                else if (nebigak < 0)
                {
                    // マイナスへ切り上げる 
                    nebigak -= 1;
                }
            }
            else
            {
                // 補正なし 
            }

            _spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_NEBIGAK].Value = Math.Truncate(nebigak);
        }

        /// <summary>
        /// 請求金額を自動計算 
        /// </summary>
        /// <param name="row">行インデックス</param>
        /// <param name="colmun">列インデックス</param>
        private void CalcAutoKingak(int row, int colmun)
        {
            decimal torigak = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_TORIGAK].Text);
            decimal nebigak = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_NEBIGAK].Text);
            decimal kingak = torigak - nebigak;

            _spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_KINGAK].Value = kingak;
        }

        /// <summary>
        /// 消費税額を自動計算 
        /// </summary>
        /// <param name="row">行インデックス</param>
        /// <param name="colmun">列インデックス</param>
        private void CalcAutoSyohi(int row, int colmun)
        {
            decimal kingak = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_KINGAK].Text);
            decimal syohiritu = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_SYOHIRITU].Text);
            decimal syohi = kingak * (syohiritu * 0.01M);

            _spdKkhDetail_Sheet1.Cells[row, DetailSkyp.COLIDX_MLIST_SYOHI].Value = Math.Round(syohi, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// 明細チェック処理 
        /// </summary>
        /// <returns>判定結果</returns>
        private bool CheckDetailData()
        {
            bool sinseiFlg = false;
            bool komokuFlg = false;
            decimal seikyu = 0M;
            decimal nebiki = 0M;
            decimal tori = 0M;
            bool kinChkFlg1 = false;
            bool kinChkFlg2 = false;

            for (int iRow = 0; iRow < _spdKkhDetail_Sheet1.Rows.Count; iRow++)
            {
                // 件名チェック 
                if (!_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KENMEI].Text.Trim().Equals(
                     _spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_BAITAIKBN].Text.Trim()))
                {
                    sinseiFlg = true;
                }

                // 項目コードチェック 
                if (string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KOMOKUCODE].Text.Trim()))
                {
                    komokuFlg = true;
                }

                // 金額の整合性チェック（請求金額） 
                if (KKHUtility.IsNumeric(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KINGAK].Text))
                {
                    seikyu = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_KINGAK].Text.Trim());
                }
                else
                {
                    seikyu = 0M;
                }

                // 金額の整合性チェック（値引額） 
                if (KKHUtility.IsNumeric(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIGAK].Text))
                {
                    nebiki = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_NEBIGAK].Text);
                }
                else
                {
                    nebiki = 0M;
                }

                // 金額の整合性チェック（取料金） 
                if (KKHUtility.IsNumeric(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TORIGAK].Text))
                {
                    tori = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[iRow, DetailSkyp.COLIDX_MLIST_TORIGAK].Text);
                }
                else
                {
                    tori = 0M;
                }

                // 金額整合性チェック１ 
                if (seikyu > 0 && tori == 0)
                {
                    kinChkFlg1 = true;
                }

                // 金額整合性チェック２ 
                if (tori != (seikyu + nebiki))
                {
                    kinChkFlg2 = true;
                }
            }

            DialogResult result;

            bool tempErrFlg = false;
            if (cmbTempCode.SelectedValue == null)
            {
                tempErrFlg = true;
            }
            else
            {
                if (TEMPLATE_ID_00.Equals(cmbTempCode.SelectedValue.ToString()))
                {
                    tempErrFlg = true;
                }
            }
            if (tempErrFlg)
            {
                result = MessageUtility.ShowMessageBox(MessageCode.HB_W0019
                                        , null
                                        , "登録前確認"
                                        , MessageBoxButtons.OKCancel
                                        , MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }

            decimal txtKingak = KKHUtility.DecParse(txtSeigak.Text);
            decimal seigak = _dataRow.hb1SeiGak + _dataRow.hb1SzeiGak;
            if (txtKingak != seigak)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0044
                                , null
                                , "明細登録"
                                , MessageBoxButtons.OK);
                return false;
            }

            if (komokuFlg)
            {
                result = MessageUtility.ShowMessageBox(MessageCode.HB_W0034
                                        , null
                                        , "登録前確認"
                                        , MessageBoxButtons.OKCancel
                                        , MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }

            if (kinChkFlg1)
            {
                result = MessageUtility.ShowMessageBox(MessageCode.HB_W0043
                                        , null
                                        , "登録前確認"
                                        , MessageBoxButtons.OKCancel
                                        , MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }

            if (kinChkFlg2)
            {
                result = MessageUtility.ShowMessageBox(MessageCode.HB_W0042
                                        , null
                                        , "登録前確認"
                                        , MessageBoxButtons.OKCancel
                                        , MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }

            if (sinseiFlg)
            {
                result = MessageUtility.ShowMessageBox(MessageCode.HB_C0004
                                        , null
                                        , "登録前確認"
                                        , MessageBoxButtons.OKCancel
                                        , MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 明細登録処理 
        /// </summary>
        /// <param name="result">表示データ登録サービス結果</param>
        /// <returns>処理結果</returns>
        private bool RegistDetailData(out UpdateDisplayDataServiceResult result)
        {
            //ローディング表示開始 
            base.ShowLoadingDialog();

            //サービスパラメータ用変数 
            Common.KKHSchema.Detail dsDetail = new Common.KKHSchema.Detail();
            Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dataRow;
            string esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            DateTime maxUpdDate = new DateTime();



            //*********************************************
            //THB2KMEIの登録データ編集 
            //*********************************************            
            Common.KKHSchema.Detail.THB2KMEIDataTable dtThb2Kmei = new Common.KKHSchema.Detail.THB2KMEIDataTable();
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                //並び順の取得 
                string _sonota1 = string.Empty;
                DetailSkypProcessController.FindOrderDataByCondParam parameter = new DetailSkypProcessController.FindOrderDataByCondParam();
                parameter.esqId = esqId;
                parameter.egCd = _naviParameter.strEgcd;
                parameter.tksKgyCd = _naviParameter.strTksKgyCd;
                parameter.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
                parameter.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
                parameter.yymm = dataRow.hb1Yymm;
                parameter.baitaikbn = (string)_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_BAITAIKBN].Value;

                DetailSkypProcessController process = DetailSkypProcessController.GetInstance();
                FindOrderByCondServiceResult resultNum = process.FindOrderDataByCond(parameter);

                if (resultNum.HasError)
                {
                    throw new Exception();
                }
                if (resultNum.DetailDataSet.OrderData.Rows.Count == 0)
                {
                    _sonota1 = " ";
                }
                else
                {
                    DetailDSSkyp.OrderDataRow row = (DetailDSSkyp.OrderDataRow)resultNum.DetailDataSet.OrderData.Rows[0];
                    _sonota1 = row.narabiJun.ToString();
                }



                Common.KKHSchema.Detail.THB2KMEIRow addRow = dtThb2Kmei.NewTHB2KMEIRow();

                addRow.hb2TimStmp = new DateTime();
                addRow.hb2UpdApl = _aplId;
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
                //addRow.hb2Renbn = (i + 1).ToString("000");　明細登録件数拡張対応
                addRow.hb2Renbn = (i + 1).ToString("0000");　
                addRow.hb2DateFrom = " ";
                addRow.hb2DateTo = " ";
                addRow.hb2SeiGak = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_KINGAK].Value);
                _seigak += addRow.hb2SeiGak;
                addRow.hb2Hnnert = 0M;
                addRow.hb2HnmaeGak = 0M;
                addRow.hb2NebiGak = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_NEBIGAK].Value);

                addRow.hb2Date1 = " ";
                addRow.hb2Date2 = " ";
                addRow.hb2Date3 = " ";
                addRow.hb2Date4 = " ";
                addRow.hb2Date5 = " ";
                addRow.hb2Date6 = " ";

                addRow.hb2Kbn1 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_TIMESPOTKBN].Value);
                addRow.hb2Kbn2 = " ";
                addRow.hb2Kbn3 = " ";

                //addRow.hb2Code1 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_KOMOKUMEI].Value);
                addRow.hb2Code1 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_KOMOKUCODE].Value);
                addRow.hb2Code2 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_GYOMUKBN].Value);
                addRow.hb2Code3 = GetStringValue2(cmbTempCode.SelectedValue);
                //addRow.hb2Code3 = GetStringValue(cmbTempCode.SelectedValue);
                addRow.hb2Code4 = " ";
                addRow.hb2Code5 = " ";
                addRow.hb2Code6 = " ";

                addRow.hb2Name1 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_DKIKAN].Value);
                addRow.hb2Name2 = " ";
                addRow.hb2Name3 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_JYUTNO].Value);
                addRow.hb2Name4 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_JYMEINO].Value);
                addRow.hb2Name5 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_URMEINO].Value);
                addRow.hb2Name6 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_GPYNO].Value); ;
                addRow.hb2Name7 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_BAITAIMEI].Value);
                //addRow.hb2Name8 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_KOMOKUCODE].Value);
                addRow.hb2Name8 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_KOMOKUMEI].Text);
                addRow.hb2Name9 = " ";
                addRow.hb2Name10 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_DNAIYO].Value);
                addRow.hb2Name11 = (string)_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_KENMEI].Value;
                addRow.hb2Name12 = (string)_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_DMEISYO].Value;
                addRow.hb2Name13 = (string)_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_BAITAIKBN].Value;

                addRow.hb2Kngk1 = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_SYOHI].Value);
                addRow.hb2Kngk2 = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_TORIGAK].Value);
                addRow.hb2Kngk3 = 0M;

                addRow.hb2Ritu1 = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_NEBIRITU].Value);
                addRow.hb2Ritu2 = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_SYOHIRITU].Value);

                decimal seq2 = GetDecimalValue(_sonota1);
                decimal seq1 = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_SEQ1].Value);



                if (seq2 == 0)
                {
                    addRow.hb2Sonota1 = " ";
                }
                else
                {
                    addRow.hb2Sonota1 = seq2.ToString("000");
                }
                if (seq1 == 0)
                {
                    addRow.hb2Sonota2 = " ";
                }
                else
                {
                    //addRow.hb2Sonota2 = seq1.ToString("000");
                    addRow.hb2Sonota2 = seq1.ToString("0000");
                }

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

            //*********************************************
            //THB1DOWNの登録データ編集 
            //*********************************************
            Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Common.KKHSchema.Detail.THB1DOWNDataTable();
            Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();

            thb1DownRow.hb1UpdApl = _aplId;
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

            //金額の差額が生じると登録できないため
            thb1DownRow.hb1MSeiFlg = "0";
            //明細行が存在する場合 
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            //if (_seigak == _seigakSum)
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
                tokoaddrow.hb1UpdApl = _aplId;
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
            if (maxUpdDate == null || maxUpdDate.CompareTo(dataRow.hb1TimStmp) < 0)
            {
                maxUpdDate = dataRow.hb1TimStmp;
            }

            for (int i = 0; i < _fpSpread1_Sheet1.RowCount; i++)
            {
                DateTime dt;
                if (DateTime.TryParse(_fpSpread1_Sheet1.Cells[i, DetailSkyp.COLIDX_MLIST_TIMESTMP].Text, out dt))
                {
                    if (maxUpdDate == null || maxUpdDate.CompareTo(dt) < 0)
                    {
                        maxUpdDate = dt;
                    }
                }
            }

            Common.KKHProcessController.Detail.DetailProcessController processController =
                Common.KKHProcessController.Detail.DetailProcessController.GetInstance();

            DetailProcessController.UpdateDisplayDataParam param = new DetailProcessController.UpdateDisplayDataParam();
            param.esqId = esqId;
            param.dsDetail = dsDetail;
            param.maxUpdDate = maxUpdDate;
            param.TouKoudsDetail = TouKoudsDetail;
            //result = processController.UpdateDisplayData(esqId, dsDetail, maxUpdDate);
            result = processController.UpdateDisplayData(param);

            if (result.HasError)
            {
                if (result.MessageCode == "LOCK-E0001")
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0148, null, "明細登録", MessageBoxButtons.OK);
                }
                else
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0003, null, "明細登録", MessageBoxButtons.OK);
                }

                //ローディング表示終了 
                base.CloseLoadingDialog();
                return false;
            }
            //ローディング表示終了 
            base.CloseLoadingDialog();

            return true;
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
        /// 引数の値を文字列に変換し返却する(テンプレート用) 
        /// </summary>
        /// <param name="obj">変換対象のオブジェクト</param>
        /// <returns>変換後の値</returns>
        private string GetStringValue2(object obj)
        {
            string ret;
            if (obj != null)
            {
                ret = obj.ToString();
            }
            else
            {
                //nullの場合、-1を返す 
                ret = "-1";
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
            //Dictionary<string, string> pastDic = KKHUtility.getPastValueDic(val);
            Dictionary<string, string> pastDic = getPastValueDic(val);

            if (pastDic.Count == 1)
            {
                // 複数コピーでない場合 
                multiCopyFlg = false;
            }

            // コピー分のセル走査
            foreach (string pastKey in pastDic.Keys)
            {
                // キー「列,行」を分割
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
                    msgcheck = true;
                    // セル変更処理実行 
                    spdKkhDetail_Change(this.spdKkhDetail, changeEvent);
                }
                // セルタイプの違い等でのエラー回避用
                catch { }
            }

            return multiCopyFlg;
        }


        /// <summary>
        /// コピー可能列確認 
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

            //非表示列へは貼り付け不可とする
            if (actColumn.Visible.Equals(false))
            {
                return false;
            }

            if (actColumn.CellType is TextCellType ||
                actColumn.CellType is NumberCellType)
            {
                // セルタイプがテキストの場合 
                if (shView.Cells[row, col].Locked)
                {
                    return false;
                }

                return true;
            }
            //項目コードは許可する 
            if (actColumn.Index == DetailSkyp.COLIDX_MLIST_KOMOKUCODE)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// 改行、タブで区切った値を取得 
        /// </summary>
        /// <param name="val"></param>
        /// <returns>pastDic</returns>
        public static Dictionary<string, string> getPastValueDic(string val)
        {
            Dictionary<string, string> pastDic = new Dictionary<string, string>();

            string[] rowPastArr = val.Split('\n');

            for (int rowCnt = 0; rowCnt < rowPastArr.Length; rowCnt++)
            {
                string rowVal = rowPastArr[rowCnt].Replace("\r", string.Empty);

                if (string.IsNullOrEmpty(rowVal))
                {
                    continue;
                }

                string[] colPastArr = rowVal.Split('\t');
                for (int colCnt = 0; colCnt < colPastArr.Length; colCnt++)
                {
                    string key = string.Join(",", new string[] { colCnt.ToString(), rowCnt.ToString() });
                    pastDic.Add(key, colPastArr[colCnt]);
                }
            }

            return pastDic;
        }


        #endregion メソッド

    }
}