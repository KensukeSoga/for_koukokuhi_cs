using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread.Model;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility;
using System.Collections.Specialized;
using System.Collections;

namespace Isid.KKH.Ash.View.Detail
{
    /// <summary>
    /// 比率入力画面.
    /// </summary>
    public partial class RatioInputAsh : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        #region 定数.
        #endregion 定数.

        #region メンバ変数.
        /// <summary>
        /// 受注データ.
        /// </summary>
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;
        /// <summary>
        /// 入力明細スプレッド.
        /// </summary>
        private FarPoint.Win.Spread.SheetView _spdDetailInput_Sheet1 = null;
        /// <summary>
        /// ナビパラメーター.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// 一括分割フラグ.
        /// </summary>
        private System.Boolean _blnAll = false;
        #endregion メンバ変数.

        #region コンストラクタ.
        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public RatioInputAsh()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ.

        #region イベント.
        #region 画面遷移時に発生.
        /// <summary>
        /// 画面遷移時に発生.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void RatioInputAsh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
                _dataRow = _naviParam.DataRow;
                _spdDetailInput_Sheet1 = _naviParam.SpdDetailInput_Sheet1;
                if (_naviParam.IntValue1 == 1)
                {
                    //一括分割.
                    _blnAll = true;
                }
                else
                {
                    //比率分割.
                    _blnAll = false;
                }
                _naviParam.IntValue1 = 0;
            }
        }
        #endregion 画面遷移時に発生.

        #region フォームロードイベント.
        /// <summary>
        /// フォームロードイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RatioInputAsh_Load(object sender, EventArgs e)
        {
            // 各コントロールの初期化.
            InitializeControl();
        }
        #endregion フォームロードイベント.

        #region OKボタンクリックイベント.
        /// <summary>
        /// OKボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //左辺入力チェック.
            if (decimal.Parse(txtRateLeft.Text.Trim()) <= 0)
            {
                //エラーメッセージを表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0036, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                txtRateLeft.Focus();
                return;
            }

            //右辺入力チェック.
            if (decimal.Parse(txtRateRight.Text.Trim()) <= 0)
            {
                //エラーメッセージを表示.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0022, null, KKHSystemConst.KoteiMongon.ERR_INPUT, MessageBoxButtons.OK);
                txtRateRight.Focus();
                return;
            }

            //明細入力スプレッドのアクティブ行の下に1行追加する.
            CellRange[] cellRanges = _spdDetailInput_Sheet1.GetSelections();
            Hashtable htSelectCell = new Hashtable();
            ArrayList alRow = new ArrayList();

            //一括分割の場合.
            if (_blnAll)
            {
                htSelectCell.Add(0, _spdDetailInput_Sheet1.RowCount);
                alRow.Add(0);
            }
            //比率分割の場合.
            else
            {
                //選択中のセル分ループ処理.
                foreach (CellRange cellRange in cellRanges)
                {
                    htSelectCell.Add(cellRange.Row, cellRange.RowCount);
                    alRow.Add(cellRange.Row);
                }

                //降順に並び替え.
                alRow.Sort();
                alRow.Reverse();
            }

            //行数分ループ処理.
            for (int j = 0; j < alRow.Count; j++)
            {
                //選択されている明細の行数分の処理を繰り返す.
                for (int i = 0; i < KKHUtility.IntParse(htSelectCell[alRow[j]].ToString()); i++)
                {
                    //初期設定.
                    int intRowIndex = KKHUtility.IntParse(alRow[j].ToString()) + i * 2;
                    _spdDetailInput_Sheet1.AddRows(intRowIndex + 1, 1);

                    //データのコピー.
                    DefaultSheetDataModel DataModel = new DefaultSheetDataModel();
                    DataModel = (DefaultSheetDataModel)_spdDetailInput_Sheet1.Models.Data;
                    DataModel.Copy(intRowIndex, 1, intRowIndex + 1, 1, 1, _spdDetailInput_Sheet1.Columns.Count - 1);

                    //明細入力スプレッドのアクティブ行、追加行に比率入力画面の内容を反映する.
                    decimal delRateLeft = decimal.Parse(txtRateLeft.Text.Trim());
                    decimal delRateRight = decimal.Parse(txtRateRight.Text.Trim());
                    decimal delMitumoriGaku = 0;
                    decimal delNebikiRitu = 0;
                    /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
                    decimal delNebikiGaku = 0;
                    decimal delZeiGaku = 0;
                    /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */

                    //見積金額Emptyチェック.
                    if (!string.IsNullOrEmpty(_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_HNMAEGAK].Text))
                    {
                        delMitumoriGaku = decimal.Parse(_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_HNMAEGAK].Value.ToString().Trim());
                    }
                    //値引率Emptyチェック.
                    if (!string.IsNullOrEmpty(_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_HNNERT].Text))
                    {
                        delNebikiRitu = decimal.Parse(_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_HNNERT].Text.Trim());
                    }
                    /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD Start */
                    //値引額Emptyチェック.
                    if (!string.IsNullOrEmpty(_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_NEBIKIGAKU].Text))
                    {
                        delNebikiGaku = decimal.Parse(_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_NEBIKIGAKU].Value.ToString().Trim());
                    }
                    //消費税額Emptyチェック.
                    if (!string.IsNullOrEmpty(_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_ZEIGAKU].Text))
                    {
                        delZeiGaku = decimal.Parse(_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_ZEIGAKU].Value.ToString().Trim());
                    }
                    /* 2016/11/18 アサヒ消費税対応 HLC K.Soga ADD End */

                    /*
                     * 選択レコード.
                     */
                    //見積金額に[アクティブ行の見積金額 * 左辺 / (左辺 + 右辺)]を設定.
                    _spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_HNMAEGAK].Value = delMitumoriGaku * delRateLeft / (delRateLeft + delRateRight);

                    //値引率に「アクティブ行の値引率」を設定.
                    _spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_HNNERT].Value = delNebikiRitu.ToString();

                    /* 2016/11/18 アサヒ消費税対応 HLC K.Soga MOD Start */
                    ////請求金額に[アクティブ行の見積金額 * 左辺 / (左辺 + 右辺) - (アクティブ行の見積金額 * 左辺 / (左辺 + 右辺) * (アクティブ行の値引率 / 100))]を設定.
                    //_spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_SEIGAK].Value = (delMitumoriGaku * delRateLeft / (delRateLeft + delRateRight)) - ((delMitumoriGaku * delRateLeft / (delRateLeft + delRateRight)) * (delNebikiRitu / 100));

                    //値引額に[アクティブ行の値引額 * 左辺 / (左辺 + 右辺)]を設定.
                    _spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_NEBIKIGAKU].Value = delNebikiGaku * delRateLeft / (delRateLeft + delRateRight);

                    //消費税額に[アクティブ行の消費税額 * 左辺 / (左辺 + 右辺)]を設定.
                    _spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_ZEIGAKU].Value = delZeiGaku * delRateLeft / (delRateLeft + delRateRight);

                    //請求金額に[アクティブ行の見積金額 * 左辺 / (左辺 + 右辺) - アクティブ行の値引額)]を設定.
                    _spdDetailInput_Sheet1.Cells[intRowIndex, DetailAsh.COLIDX_MLIST_SEIGAK].Value = (delMitumoriGaku * delRateLeft / (delRateLeft + delRateRight)) - (delNebikiGaku * delRateLeft / (delRateLeft + delRateRight));
                    /* 2016/11/18 アサヒ消費税対応 HLC K.Soga MOD End */

                    /*
                     * 追加レコード.
                     */
                    //見積金額に[アクティブ行の見積金額 * 右辺 / (左辺 + 右辺)]を設定.
                    _spdDetailInput_Sheet1.Cells[intRowIndex + 1, DetailAsh.COLIDX_MLIST_HNMAEGAK].Value = delMitumoriGaku * delRateRight / (delRateLeft + delRateRight);

                    //値引率に[アクティブ行の値引率]を設定.
                    _spdDetailInput_Sheet1.Cells[intRowIndex + 1, DetailAsh.COLIDX_MLIST_HNNERT].Value = delNebikiRitu.ToString();

                    /* 2016/11/18 アサヒ消費税対応 HLC K.Soga MOD Start */
                    ////請求金額に[アクティブ行の見積金額 * 右辺 / (左辺 + 右辺) - (アクティブ行の見積金額 * 右辺 / (左辺 + 右辺) * (アクティブ行の値引率 / 100))]を設定.
                    //_spdDetailInput_Sheet1.Cells[intRowIndex + 1, DetailAsh.COLIDX_MLIST_SEIGAK].Value = (delMitumoriGaku * delRateRight / (delRateLeft + delRateRight)) - ((delMitumoriGaku * delRateRight / (delRateLeft + delRateRight)) * (delNebikiRitu / 100));

                    //値引額に[アクティブ行の値引額 * 右辺 / (左辺 + 右辺)]を設定.
                    _spdDetailInput_Sheet1.Cells[intRowIndex + 1, DetailAsh.COLIDX_MLIST_NEBIKIGAKU].Value = delNebikiGaku * delRateRight / (delRateLeft + delRateRight);

                    //消費税額に[アクティブ行の消費税額 * 右辺 / (左辺 + 右辺)]を設定.
                    _spdDetailInput_Sheet1.Cells[intRowIndex + 1, DetailAsh.COLIDX_MLIST_ZEIGAKU].Value = delZeiGaku * delRateRight / (delRateLeft + delRateRight);

                    //請求金額に[アクティブ行の見積金額 * 右辺 / (左辺 + 右辺) - アクティブ行の値引額)]を設定.
                    _spdDetailInput_Sheet1.Cells[intRowIndex + 1, DetailAsh.COLIDX_MLIST_SEIGAK].Value = (delMitumoriGaku * delRateRight / (delRateLeft + delRateRight)) - (delNebikiGaku * delRateRight / (delRateLeft + delRateRight));
                    /* 2016/11/18 アサヒ消費税対応 HLC K.Soga MOD End */
                }
            }

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

        #region 比率(左)KeyDownイベント.
        /// <summary>
        /// 比率(左)KeyDownイベント.
        /// </summary>
        private void txtRateLeft_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool forward = e.Modifiers != Keys.Shift;
                this.SelectNextControl(this.ActiveControl, forward, true, true, true);
                e.Handled = true;
            }
        }
        #endregion 比率(左)KeyDownイベント.

        #region 比率(右)KeyDownイベント.
        /// <summary>
        /// 比率(右)KeyDownイベント.
        /// </summary>
        private void txtRateRight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool forward = e.Modifiers != Keys.Shift;
                this.SelectNextControl(this.ActiveControl, forward, true, true, true);
                e.Handled = true;
            }
        }
        #endregion 比率(右)KeyDownイベント.
        #endregion イベント.

        #region メソッド.
        #region 各コントロールの初期表示処理.
        /// <summary>
        /// 各コントロールの初期表示処理.
        /// </summary>
        private void InitializeControl()
        {
            //テキストボックス初期化.
            txtRateLeft.Text = "1";
            txtRateRight.Text = "1";
        }
        #endregion 各コントロールの初期表示処理.
        #endregion メソッド.
    }
}