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
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Mac.KKHUtility;

namespace Isid.KKH.Mac.View.Detail
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DetailDivideMac : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        #region メンバ変数.

        private DetailDivideMacNaviParameter _naviParam = new DetailDivideMacNaviParameter();
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;
        private int _rowDetailIndex = -1;
        private FarPoint.Win.Spread.SheetView _spdKkhDetail_Sheet1 = null;
        private String _currentKenNm = "";
        private bool stflg = false;

        //カラムインデックス const.
        /// <summary>
        /// 店舗コード.
        /// </summary>
        private const int COLIDX_1 = 0;
        /// <summary>
        /// G.CLOSE年月日.
        /// </summary>
        private const int COLIDX_2 = 1;
        /// <summary>
        /// 店舗名.
        /// </summary>
        private const int COLIDX_3 = 2;
        /// <summary>
        /// 区.
        /// </summary>
        private const int COLIDX_4 = 3;
        /// <summary>
        /// 数量.
        /// </summary>
        private const int COLIDX_5 = 4;
        /// <summary>
        /// 金額.
        /// </summary>
        private const int COLIDX_6 = 5;
        /// <summary>
        /// フラグ.
        /// </summary>
        private const int COLIDX_7 = 6;

        //区分用const.
        /// <summary>
        /// 本部.
        /// </summary>
        private const string COLIDX_HONBU = "本";
        /// <summary>
        /// 直営.
        /// </summary>
        private const string COLIDX_TYOKUEI = "直";
        /// <summary>
        /// ライセンシー.
        /// </summary>
        private const string COLIDX_RAISENC = "ラ";

        //プライベート変数用.
        /// <summary>
        /// 直営用金額.
        /// </summary>
        private decimal _dectyokukin = 0M;
        /// <summary>
        /// 本部金額.
        /// </summary>
        private decimal _dechonbukin = 0M;
        /// <summary>
        /// ライセンシー金額.
        /// </summary>
        private decimal _decraisenckin = 0M;

        #endregion メンバ変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DetailDivideMac()
        {
            InitializeComponent();
        }

        #endregion コンストラクタ.

        #region イベント.

        /// <summary>
        /// OKボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //チェック処理.
            if (txtTenpoCd.Text.Equals(""))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0081, null, "明細入力", MessageBoxButtons.OK);
                txtTenpoCd.Focus();
                return;
            }
            if (txtKenNm.Text.Equals(""))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0081, null, "明細入力", MessageBoxButtons.OK);
                txtKenNm.Focus();
                return;
            }

            int row = 0;
            while (row < fpSpread1_Sheet1.RowCount)
            {
                if ((fpSpread1_Sheet1.Cells[row, COLIDX_1].Text == "") &&
                     (fpSpread1_Sheet1.Cells[row, COLIDX_5].Text.Trim() == ""
                     || fpSpread1_Sheet1.Cells[row, COLIDX_5].Text.Trim() == "0"))
                {
                    fpSpread1_Sheet1.RemoveRows(row, 1);
                }
                else
                {
                    row++;
                }
            }


            for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
            {
                //店舗コードもしくは数量が入っていないデータがあった場合はエラー.
                if ((fpSpread1_Sheet1.Cells[i, COLIDX_1].Text == "") ||
                     (fpSpread1_Sheet1.Cells[i, COLIDX_5].Text.Trim() == "" ||
                      fpSpread1_Sheet1.Cells[i, COLIDX_5].Text.Trim() == "0"))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0063, null, "明細入力", MessageBoxButtons.OK);
                    return;
                }
            }

            //明細削除(全削除）.
            _spdKkhDetail_Sheet1.RowCount = 0;

            //データをセット.
            for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
            {
                //コードがあるもののみ.
                if (fpSpread1_Sheet1.Cells[i, COLIDX_1].Text != "")
                {
                    _spdKkhDetail_Sheet1.AddRows(i, 1);
                    //件数分明細スプレッドに入力内容を設定.
                    _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_KENMEI].Value = txtKenNm.Text.Trim() + txtKenNm2.Text.Trim();
                    _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_KENMEI1].Value = txtKenNm.Text.Trim();
                    _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_KENMEI2].Value = txtKenNm2.Text.Trim();
                    _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_KINGAKU].Value = fpSpread1_Sheet1.Cells[i, COLIDX_6].Value;
                    //_spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_KINGAKU].Value = fpSpread1_Sheet1.Cells[i, COLIDX_5].Value;
                    _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOCD].Value = fpSpread1_Sheet1.Cells[i, COLIDX_1].Value;
                    _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TIKUHONBUCD].Value = txtTenpoCd.Text.ToString();//fpSpread1_Sheet1.Cells[i, COLIDX_1].Value;
                    _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOMEI].Value = fpSpread1_Sheet1.Cells[i, COLIDX_3].Value;
                    //_spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOMEI].Value = fpSpread1_Sheet1.Cells[i, COLIDX_2].Value;
                    _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TIKUHONBU].Value = txtTenpoNm.Text.ToString();//fpSpread1_Sheet1.Cells[i, COLIDX_2].Value;
                    _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_KANJYOKMK].Value = txtKanjyo.Text;
                    _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TANKA].Value = txttanka.Text;
                    _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_SURYO].Value = fpSpread1_Sheet1.Cells[i, COLIDX_5].Value;
                    //_spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_SURYO].Value = fpSpread1_Sheet1.Cells[i, COLIDX_4].Value;
                    _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOKUBUNRETU].Value = txtTenpokbn.Text.Trim();
                    // 消費税対応 2013/10/21 add HLC H.Watabe start
                    _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDC_MLIST_SHOHIZEIRITU].Value = txtShohizei.Text.Trim();
                    // 消費税対応 2013/10/21 add HLC H.Watabe end

                    //店舗区分.
                    //●本.
                    if (fpSpread1_Sheet1.Cells[i, COLIDX_4].Text == COLIDX_HONBU)
                    {
                        _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOKUBUNRETU].Value = "0";
                    }
                    //●直.
                    else if (fpSpread1_Sheet1.Cells[i, COLIDX_4].Text == COLIDX_TYOKUEI)
                    {
                        _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOKUBUNRETU].Value = "1";
                    }
                    //●ラ.
                    else if (fpSpread1_Sheet1.Cells[i, COLIDX_4].Text == COLIDX_RAISENC)
                    {
                        _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOKUBUNRETU].Value = "2";
                    }

                    //分割コード（２）セット.
                    _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_BUNKATUFLG].Value = "2";
                }
            }

            Navigator.Backward(this, _naviParam, null, true);
            this.Close();
        }

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

        /// <summary>
        /// フォームロードイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailDivideMac_Load(object sender, EventArgs e)
        {
            //fpSpread1_Sheet1の設定.
            foreach (Column col in fpSpread1_Sheet1.Columns)
            {
                //共通設定.
                col.Locked = true;//セルの編集不可(一部は下記コードで解除）.
                col.AllowAutoFilter = true;//フィルタ機能を有効.
                col.AllowAutoSort = true;  //ソート機能を有効.

                //列毎に異なる設定.
                if (col.Index == COLIDX_1)
                {
                    col.Locked = false;//セルの編集可.
                }
                //列毎に異なる設定.
                if (col.Index == COLIDX_5)
                {
                    col.Locked = false;//セルの編集可.
                }
                else if (col.Index == COLIDX_6)
                {
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 3;
                    cellType.ShowSeparator = true;
                }
            }

            // 各コントロールの初期化.
            InitializeControl();
            // 各コントロールの編集.
            editControl();

            //グリッドにイベント追加.
            // 編集中セルの Enterキー押下による動作を無効とします。.
            FarPoint.Win.Spread.InputMap inputmap1;
            inputmap1 = fpSpread1.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused);
            inputmap1.Put(new FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.None);
        }

        /// <summary>
        /// 1行削除.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            //1行以上ある場合.
            if (fpSpread1_Sheet1.RowCount > 0)
            {
                fpSpread1_Sheet1.RemoveRows(fpSpread1_Sheet1.ActiveRowIndex, 1);
            }

            //0行の場合.
            if (fpSpread1_Sheet1.RowCount == 0)
            {
                //行を追加.
                fpSpread1_Sheet1.AddRows(0, 1000);
            }

            //再計算.
            bunkatudatakeisan();
        }

        /// <summary>
        /// 10行追加.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn10Add_Click(object sender, EventArgs e)
        {
            fpSpread1_Sheet1.AddRows(fpSpread1_Sheet1.RowCount, 10);
        }

        /// <summary>
        /// マスタ呼び出し.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_CellDoubleClick(object sender, CellClickEventArgs e)
        {
            if (e.RowHeader == true)
            {
                // 明細入力画面表示.
                DetailTenpoItrNaviParameter naviParam = new DetailTenpoItrNaviParameter();
                naviParam.EsqId = _naviParam.pEsqId;
                naviParam.Egcd = _naviParam.pEgcd;
                naviParam.TksKgyCd = _naviParam.pTksKgyCd;
                naviParam.TksBmnSeqNo = _naviParam.pTksBmnSeqNo;
                naviParam.TksTntSeqNo = _naviParam.pTksTntSeqNo;
                naviParam.ItrTenpoMastrslt = _naviParam.DivTenpoMastrslt;
                naviParam.AllorFlg = "1";//全てが対象.

                object result = Navigator.ShowModalForm(this, "toDetailTenpoItr", naviParam);
                if (result == null || naviParam.TenpoCd.Equals(""))
                {
                    return;
                }

                //セット.
                //店舗コード.
                fpSpread1_Sheet1.Cells[e.Row, COLIDX_1].Text = naviParam.TenpoCd;
                //店舗名.
                fpSpread1_Sheet1.Cells[e.Row, COLIDX_3].Text = naviParam.TenpoNm;
                //区分.
                //●本.
                if (naviParam.TenpoKbn.Equals("0"))
                {
                    fpSpread1_Sheet1.Cells[e.Row, COLIDX_4].Text = COLIDX_HONBU;
                }
                //●直.
                else if (naviParam.TenpoKbn.Equals("1"))
                {
                    fpSpread1_Sheet1.Cells[e.Row, COLIDX_4].Text = COLIDX_TYOKUEI;
                }
                //●ラ.
                else if (naviParam.TenpoKbn.Equals("2"))
                {
                    fpSpread1_Sheet1.Cells[e.Row, COLIDX_4].Text = COLIDX_RAISENC;
                }

                MasterMaintenance.MasterDataVORow row = (MasterMaintenance.MasterDataVORow)_naviParam.DivTenpoMastrslt.MasterDataSet.MasterDataVO.Select("Column1 = '" + naviParam.TenpoCd.Trim() + "'")[0];
                if (row != null)
                {
                    //G.CLOSE
                    fpSpread1_Sheet1.Cells[e.Row, COLIDX_2].Text = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime2(row.Column17).ToString("yyy/M/d");
                }
            }
        }


        /// <summary>
        ///  再計算（数量）+ 店舗コード検索、セット.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_EditChange(object sender, EditorNotifyEventArgs e)
        {
            if (e.Column == COLIDX_1)
            {
                bunkatudatakeisan();
            }
        }

        /// <summary>
        ///  再計算（単価）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txttanka_Leave(object sender, EventArgs e)
        {
            //グリッドの値計算.
            //nullチェック.
            for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
            {
                if (fpSpread1_Sheet1.Cells[i, COLIDX_5].Value != null)
                {
                    string strdec = "";
                    decimal decgki = 0M;
                    decimal dectnk = 0M;
                    decimal decsry = 0M;
                    //単価.
                    strdec = txttanka.Text.ToString().Replace(",", "");
                    dectnk = Convert.ToDecimal(strdec);
                    //数量.
                    strdec = fpSpread1_Sheet1.Cells[i, COLIDX_5].Value.ToString().Replace(",", "");
                    decsry = Convert.ToDecimal(strdec);
                    //計算、表示.
                    decgki = dectnk * decsry;
                    fpSpread1_Sheet1.Cells[i, COLIDX_6].Value = decgki;//decgki.ToString();
                }
            }

            //再計算（単価）.
            bunkatudatakeisan();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_EditModeOff(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailDivideMac_Shown(object sender, EventArgs e)
        {
            //コンボボックスのデータソース設定.
            cmbPtn.DataSource = _naviParam.DivTenpoPtnMastrslt.MasterDataSet.MasterDataVO.Select("");

            //表示される値はDataTableのColumn2.
            cmbPtn.DisplayMember = "Column2";

            //対応する値はDataTableのColumn1.
            cmbPtn.ValueMember = "Column1";

            stflg = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPtn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stflg && cmbPtn.SelectedIndex != -1)
            {
                // 登録内容確認.
                if (MessageUtility.ShowMessageBox(MessageCode.HB_C0011,
                    new string[] { cmbPtn.Text.ToString(), Environment.NewLine }, "明細登録"
                    , MessageBoxButtons.OKCancel, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    bool setflg = false;
                    int blankIdx = 0;

                    for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
                    {
                        //空白行のインデックスを取得する.
                        if (fpSpread1_Sheet1.Cells[i, COLIDX_2].Text.Trim() == "")
                        {
                            blankIdx = i;
                            break;
                        }
                    }

                    for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
                    {
                        //親マスタに紐づく子マスタを取得.
                        DataRow[] foundRows = _naviParam.DivTenpoPtn2Mastrslt.MasterDataSet.MasterDataVO.Select("Column3 = '" + cmbPtn.SelectedValue + "'");

                        if (blankIdx >= 0)
                        {
                            i = blankIdx;
                        }
                        else
                        {
                            i = fpSpread1_Sheet1.RowCount;
                        }

                        //店舗がない場合.
                        if (foundRows.Length == 0)
                        {
                            return;
                        }

                        //店舗分行追加.
                        fpSpread1_Sheet1.Rows.Add(i, foundRows.Length);

                        foreach (DataRow dr in foundRows)
                        {

                            //店舗マスタにデータが存在するか判断(dr2,foundRows2).
                            DataRow[] foundRows2 = _naviParam.DivTenpoMastrslt.MasterDataSet.MasterDataVO.Select("Column1 = '" + dr["Column2"].ToString() + "'");
                            //G.CLOSE年月日初期化.
                            string closeDate = KKHMacConst.C_CLOSE_DATE;
                            foreach (DataRow dr2 in foundRows2)
                            {
                                //fpSpread1_Sheet1.Cells[i, COLIDX_1].Value= dr["Column2"].ToString();
                                //fpSpread1_Sheet1.Cells[i, COLIDX_2].Value = dr2["Column2"].ToString();
                                //fpSpread1_Sheet1.Cells[i, COLIDX_4].Value = dr["Column5"].ToString();
                                fpSpread1_Sheet1.Cells[i, COLIDX_1].Text = dr["Column2"].ToString();
                                closeDate = dr2["Column17"].ToString();
                                fpSpread1_Sheet1.Cells[i, COLIDX_2].Text =
                                    Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime2(closeDate).ToString("yyy/M/d");
                                fpSpread1_Sheet1.Cells[i, COLIDX_3].Text = dr2["Column2"].ToString();
                                fpSpread1_Sheet1.Cells[i, COLIDX_5].Text = dr["Column5"].ToString();
                                //●本,
                                if (dr2["Column4"].ToString().Equals("0"))
                                {
                                    fpSpread1_Sheet1.Cells[i, COLIDX_4].Text = COLIDX_HONBU;
                                    //fpSpread1_Sheet1.Cells[i, COLIDX_4].Text = COLIDX_HONBU;
                                }
                                //●直,
                                else if (dr2["Column4"].ToString().Equals("1"))
                                {
                                    fpSpread1_Sheet1.Cells[i, COLIDX_4].Text = COLIDX_TYOKUEI;
                                    //fpSpread1_Sheet1.Cells[i, COLIDX_4].Text = COLIDX_HONBU;
                                }
                                //●ラ,
                                else if (dr2["Column4"].ToString().Equals("2"))
                                {
                                    fpSpread1_Sheet1.Cells[i, COLIDX_4].Text = COLIDX_RAISENC;
                                    //fpSpread1_Sheet1.Cells[i, COLIDX_4].Text = COLIDX_HONBU;
                                }

                                i++;
                                break;
                            }
                        }
                        //分割計算.
                        bunkatudatakeisan();

                        setflg = true;

                        if (setflg)
                        {
                            break;
                        }

                    }
                }

            }

            cmbPtn.SelectedIndex = -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //F1キーが押されたか調べる.
                if (e.KeyData == Keys.Enter)
                {
                    //店舗コード、もしくは数量がアクティブの場合のみ処理する.
                    if (fpSpread1_Sheet1.ActiveColumnIndex == COLIDX_1 || fpSpread1_Sheet1.ActiveColumnIndex == COLIDX_5)
                    {
                        //店舗コード取得処.
                        if (CheckValue())
                        {
                            return;
                        }
                        fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex + 1, fpSpread1_Sheet1.ActiveColumnIndex);
                    }
                }
            }
            catch
            {
                if (fpSpread1_Sheet1.ActiveColumnIndex == COLIDX_1)
                {
                    fpSpread1_Sheet1.SetActiveCell(0, COLIDX_5);
                }
                else
                {
                    txtKenNm.Focus();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTenpoCd_Leave(object sender, EventArgs e)
        {
            // 店舗コードが入力されていない場合.
            if (string.IsNullOrEmpty(this.txtTenpoCd.Text) == true)
            {
                return;
            }

            //キャンセルボタンの場合.
            if (this.ActiveControl.Name == "btnCancel")
            {
                //当処理を行わない.
                return;
            }

            //先頭の文字が9では無い場合.
            if (txtTenpoCd.Text.Substring(0, 1) != "9")
            {
                //「店舗コードが間違っています」.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0062, null, "明細入力", MessageBoxButtons.OK);
                txtTenpoNm.Text = "";
                txtTenpoCd.Focus();
                return;
            }

            // 引数のデータセットを検索.
            DataRow[] foundRows = _naviParam.DivTenpoMastrslt.MasterDataSet.MasterDataVO.Select("Column1 = '" + txtTenpoCd.Text + "'");
            foreach (DataRow dr in foundRows)
            {
                txtTenpoNm.Text = dr["Column2"].ToString();
                return;
            }

            //無かった場合.
            MessageUtility.ShowMessageBox(MessageCode.HB_W0065, null, "明細入力", MessageBoxButtons.OK);
            txtTenpoNm.Text = "";
            txtTenpoCd.Focus();
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPressNumChk(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_EditModeOn(object sender, EventArgs e)
        {
            // 編集モードONの時、KeyDownイベントを取得する.
            fpSpread1.EditingControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fpSpread1_KeyDown);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_LeaveCell(object sender, LeaveCellEventArgs e)
        {
            //店舗コード取得処.
            e.Cancel = CheckValue();
        }

        /// <summary>
        /// ナビゲータ受取.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailDivideMac_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is DetailDivideMacNaviParameter)
            {
                _naviParam = (DetailDivideMacNaviParameter)arg.NaviParameter;

                _dataRow = _naviParam.DataRow;
                _rowDetailIndex = _naviParam.RowDetailIndex;
                _spdKkhDetail_Sheet1 = _naviParam.SpdKkhDetail_Sheet1;

            }
        }

        /// <summary>
        /// 店舗コード一覧表示.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTenpo_Click(object sender, EventArgs e)
        {
            // 明細入力画面表示.
            DetailTenpoItrNaviParameter naviParam = new DetailTenpoItrNaviParameter();
            naviParam.EsqId = _naviParam.pEsqId;
            naviParam.Egcd = _naviParam.pEgcd;
            naviParam.TksKgyCd = _naviParam.pTksKgyCd;
            naviParam.TksBmnSeqNo = _naviParam.pTksBmnSeqNo;
            naviParam.TksTntSeqNo = _naviParam.pTksTntSeqNo;
            naviParam.ItrTenpoMastrslt = _naviParam.DivTenpoMastrslt;
            naviParam.AllorFlg = "2";//一部が対象.

            object result = Navigator.ShowModalForm(this, "toDetailTenpoItr", naviParam);
            if (result == null)
            {
                this.ActiveControl = null;
                return;
            }
            //セット.
            if (naviParam.TenpoCd.Equals(""))
            { }
            else
            {
                txtTenpoCd.Text = naviParam.TenpoCd;
                txtTenpoNm.Text = naviParam.TenpoNm;
                txtTenpokbn.Text = naviParam.TenpoKbn;
                txtKanjyo.Text = naviParam.KanjyoKmk;
            }

            this.ActiveControl = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_Validating(object sender, CancelEventArgs e)
        {
            //キャンセルボタンの場合.
            if (this.ActiveControl.Name == "btnCancel")
            {
                //当処理を行わない.
                return;
            }
            
            //店舗コード取得処理.
            e.Cancel = CheckValue();
        }

        # endregion イベント.

        # region メソッド.

        /// <summary>
        /// 各コントロールの初期表示処理.
        /// </summary>
        private void InitializeControl()
        {
            // テキストボックス.
            txtKenNm.Text = "";
            txtKenNm2.Text = "";
            txtKikanHImoku.Text = "";
            txtRyoukin.Text = "";
            txtTenpoCd.Text = "";
            txtTenpoNm.Text = "";
            txtKanjyo.Text = "";
            txtTokuicd.Text = "";
            txtTokuiNm.Text = "";
        }

        /// <summary>
        /// 各コントロールの編集処理.
        /// </summary>
        private void editControl()
        {
            //期間用変数.
            string strkikan = "";

            // 明細がない場合(パターン１).
            if (_spdKkhDetail_Sheet1.RowCount == 0)
            {
                //受注データを表示.
                _currentKenNm = _dataRow.hb1KKNameKJ.ToString().Trim();
                if (_dataRow.hb1KKNameKJ.ToString().Trim().Length > 15)
                {
                    txtKenNm.Text = _dataRow.hb1KKNameKJ.ToString().Trim().Substring(0, 15);
                    txtKenNm2.Text = _dataRow.hb1KKNameKJ.ToString().Trim().Substring(0 + 15, _dataRow.hb1KKNameKJ.ToString().Trim().Length - 15);
                }
                else
                {
                    txtKenNm.Text = _dataRow.hb1KKNameKJ.ToString().Trim();
                    txtKenNm2.Text = "";
                }

                // 区分によってフィールど変更.
                if ("11".Equals(_dataRow.hb1SeiKbn.ToString().Trim()))
                {
                    strkikan = _dataRow.hb1Field12.ToString().Trim();
                }
                if ("21".Equals(_dataRow.hb1SeiKbn.ToString().Trim()))
                {
                    strkikan = _dataRow.hb1Field10.ToString().Trim();
                }
                if ("31".Equals(_dataRow.hb1SeiKbn.ToString().Trim()))
                {
                    strkikan = _dataRow.hb1Field3.ToString().Trim();
                }
                if ("32".Equals(_dataRow.hb1SeiKbn.ToString().Trim()) || "42".Equals(_dataRow.hb1SeiKbn.ToString().Trim()))
                {
                    strkikan = _dataRow.hb1Field4.ToString().Trim();
                }
                if ("41".Equals(_dataRow.hb1SeiKbn.ToString().Trim()))
                {
                    strkikan = _dataRow.hb1Field8.ToString().Trim();
                }
                if ("81".Equals(_dataRow.hb1SeiKbn.ToString().Trim())
                    || "61".Equals(_dataRow.hb1SeiKbn.ToString().Trim())
                    || "71".Equals(_dataRow.hb1SeiKbn.ToString().Trim())
                    || "81".Equals(_dataRow.hb1SeiKbn.ToString().Trim())
                    )
                {
                    strkikan = _dataRow.hb1Field5.ToString().Trim();
                }

                txtKikanHImoku.Text = strkikan.Substring(0, 4) + "/"
                                    + strkikan.Substring(4, 2) + "/"
                                    + strkikan.Substring(6, 2) + " - "
                                    + strkikan.Substring(0 + 8, 4) + "/"
                                    + strkikan.Substring(4 + 8, 2) + "/"
                                    + strkikan.Substring(6 + 8, 2) + "　"
                                    + _dataRow.hb1HimkNmKJ.ToString().Trim();
                txtRyoukin.Text = _dataRow.hb1SeiGak.ToString("###,###,###,##0");
                lblSeteiKin.Text = _dataRow.hb1SeiGak.ToString("###,###,###,##0");

                //空で出力.
                txtTenpoCd.Text = "";
                txtTenpoNm.Text = "";
                txtKanjyo.Text = "";

                //データ無しの場合の金額類.
                txttanka.Text = "0";
                txtZandaka.Text = _dataRow.hb1SeiGak.ToString("###,###,###,##0");
                txtTyokuei.Text = "0";
                txtRaicenc.Text = "0";
                // 消費税対応 2013/10/21 add HLC H.Watabe start
                txtShohizei.Text = Math.Truncate(_dataRow.hb1SzeiRitu).ToString();
                // 消費税対応 2013/10/21 add HLC H.Watabe end

            }
            // 明細がある場合（パターン２、パターン３）.
            else
            {
                txtKenNm.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_KENMEI1].Text.Trim();
                txtKenNm2.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_KENMEI2].Text.Trim();

                //_currentKenNm = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_KENMEI].Text.Trim();
                //if (_currentKenNm.Length > 15)
                //{
                //    txtKenNm.Text = _currentKenNm.Substring(0, 15);
                //    txtKenNm2.Text = _currentKenNm.Substring(15, _currentKenNm.Length - 15);
                //}
                //else
                //{
                //    txtKenNm.Text = _currentKenNm;
                //    //txtKenNm.Text = _dataRow.hb1KKNameKJ.ToString().Trim();
                //    txtKenNm2.Text = "";
                //}
                // 区分によってフィールド変更.
                if ("11".Equals(_dataRow.hb1SeiKbn.ToString().Trim()))
                {
                    strkikan = _dataRow.hb1Field12.ToString().Trim();
                }
                if ("21".Equals(_dataRow.hb1SeiKbn.ToString().Trim()))
                {
                    strkikan = _dataRow.hb1Field10.ToString().Trim();
                }
                if ("31".Equals(_dataRow.hb1SeiKbn.ToString().Trim()))
                {
                    strkikan = _dataRow.hb1Field3.ToString().Trim();
                }
                if ("32".Equals(_dataRow.hb1SeiKbn.ToString().Trim())
                    || "42".Equals(_dataRow.hb1SeiKbn.ToString().Trim()))
                {
                    strkikan = _dataRow.hb1Field4.ToString().Trim();
                }
                if ("41".Equals(_dataRow.hb1SeiKbn.ToString().Trim()))
                {
                    strkikan = _dataRow.hb1Field8.ToString().Trim();
                }
                if ("81".Equals(_dataRow.hb1SeiKbn.ToString().Trim())
                    || "61".Equals(_dataRow.hb1SeiKbn.ToString().Trim())
                    || "71".Equals(_dataRow.hb1SeiKbn.ToString().Trim())
                    || "81".Equals(_dataRow.hb1SeiKbn.ToString().Trim())
                    )
                {
                    strkikan = _dataRow.hb1Field5.ToString().Trim();
                }

                txtKikanHImoku.Text = strkikan.Substring(0, 4) + "/"
                                    + strkikan.Substring(4, 2) + "/"
                                    + strkikan.Substring(6, 2) + " - "
                                    + strkikan.Substring(0 + 8, 4) + "/"
                                    + strkikan.Substring(4 + 8, 2) + "/"
                                    + strkikan.Substring(6 + 8, 2) + "　"
                                    + _dataRow.hb1HimkNmKJ.ToString().Trim();
                txtRyoukin.Text = _dataRow.hb1SeiGak.ToString("###,###,###,##0");
                lblSeteiKin.Text = _dataRow.hb1SeiGak.ToString("###,###,###,##0");

                //空で出力.
                txtTenpoCd.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_TIKUHONBUCD].Text.Trim();
                txtTenpoNm.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_TIKUHONBU].Text.Trim();
                txtKanjyo.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_KANJYOKMK].Text.Trim();
                // 消費税対応 2013/10/21 add HLC H.Watabe start
                //txtShohizei.Text = Math.Truncate(_dataRow.hb1SzeiRitu).ToString();
                txtShohizei.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDC_MLIST_SHOHIZEIRITU].Text.Trim();
                // 消費税対応 2013/10/21 add HLC H.Watabe end

                //2013/05/13 hlc sonobe 明細1000桁登録対応　add start
                if (_spdKkhDetail_Sheet1.RowCount > 1000)
                {
                    fpSpread1_Sheet1.RowCount = _spdKkhDetail_Sheet1.RowCount;
                }
                //2013/05/13 hlc sonobe 明細1000桁登録対応　add end

                //ここから分割データか、分割データでないかで分岐.
                for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
                {
                    //分割「なし」データ.
                    if (_spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_BUNKATUFLG].Text.ToString() == "1")
                    {
                        //データ無しの場合の金額類.
                        txttanka.Text = _dataRow.hb1SeiGak.ToString("###,###,###,##0");
                        txtZandaka.Text = "0";
                        txtTyokuei.Text = "0";
                        txtRaicenc.Text = "0";

                        //データ無しの場合の金額類.
                        //店舗コード.
                        fpSpread1_Sheet1.Cells[i, COLIDX_1].Text = _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOCD].Text.Trim();
                        //G.CLOSE年月日.
                        fpSpread1_Sheet1.Cells[i, COLIDX_2].Text = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime2(KKHMacConst.C_CLOSE_DATE).ToString("yyy/M/d");
                        //店舗名.
                        fpSpread1_Sheet1.Cells[i, COLIDX_3].Text = _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOMEI].Text.Trim();
                        //区分.
                        //●直営.
                        if (_spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOKUBUNRETU].Text.Trim() == ""
                            || _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOKUBUNRETU].Text.Trim() == "0")
                        {
                            fpSpread1_Sheet1.Cells[i, COLIDX_4].Text = "本";
                            //fpSpread1_Sheet1.Cells[i, COLIDX_3].Text = "本";
                        }
                        //●直営.
                        else if (_spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOKUBUNRETU].Text.Trim() == "1")
                        {
                            fpSpread1_Sheet1.Cells[i, COLIDX_4].Text = "直";
                            //fpSpread1_Sheet1.Cells[i, COLIDX_3].Text = "直";
                        }
                        //●ラ.
                        else if (_spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOKUBUNRETU].Text.Trim() == "2")
                        {
                            fpSpread1_Sheet1.Cells[i, COLIDX_4].Text = "ラ";
                            //fpSpread1_Sheet1.Cells[i, COLIDX_3].Text = "ラ";
                        }

                        //数量.
                        fpSpread1_Sheet1.Cells[i, COLIDX_5].Text = "1";
                        //fpSpread1_Sheet1.Cells[i, COLIDX_4].Text = "1";
                        //金額.
                        fpSpread1_Sheet1.Cells[i, COLIDX_6].Text = txttanka.Text;

                    }
                    //分割「あり」データ.
                    else
                    {
                        //単価セット（他でやりたい）.
                        txttanka.Text = _spdKkhDetail_Sheet1.Cells[0, DetailMac.COLIDX_MLIST_TANKA].Text.Trim();
                        //店舗コード.
                        fpSpread1_Sheet1.Cells[i, COLIDX_1].Text = _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOCD].Text.Trim();
                        //G.CLOSE年月日.
                        fpSpread1_Sheet1.Cells[i, COLIDX_2].Text = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime2(KKHMacConst.C_CLOSE_DATE).ToString("yyy/M/d");
                        //店舗名.
                        fpSpread1_Sheet1.Cells[i, COLIDX_3].Text = _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOMEI].Text.Trim();
                        //区分.
                        //●直営.
                        if (_spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOKUBUNRETU].Text.Trim() == ""
                            || _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOKUBUNRETU].Text.Trim() == "0")
                        {
                            fpSpread1_Sheet1.Cells[i, COLIDX_4].Text = "本";
                        }
                        //●直営.
                        else if (_spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOKUBUNRETU].Text.Trim() == "1")
                        {
                            fpSpread1_Sheet1.Cells[i, COLIDX_4].Text = "直";
                        }
                        //●ラ.
                        else if (_spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_TENPOKUBUNRETU].Text.Trim() == "2")
                        {
                            fpSpread1_Sheet1.Cells[i, COLIDX_4].Text = "ラ";
                        }

                        //数量.
                        fpSpread1_Sheet1.Cells[i, COLIDX_5].Text = _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_SURYO].Text.Trim();
                        //金額.
                        fpSpread1_Sheet1.Cells[i, COLIDX_6].Text = _spdKkhDetail_Sheet1.Cells[i, DetailMac.COLIDX_MLIST_KINGAKU].Text.Trim();
                    }
                }

                //計算.
                bunkatudatakeisan();
            }
        }

        /// <summary>
        /// 分割データ計算.
        /// </summary>
        private void bunkatudatakeisan()
        {
            string strdec = "";
            //初期化.
            _dechonbukin = 0M;
            _dectyokukin = 0M;
            _decraisenckin = 0M;

            //グリッドの値計算.
            //nullチェック.
            for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
            {
                if (fpSpread1_Sheet1.Cells[i, COLIDX_5].Value != null)
                {
                    string strdecs = "";
                    decimal decgki = 0M;
                    decimal dectnk = 0M;
                    decimal decsry = 0M;
                    //単価.
                    strdecs = txttanka.Text.ToString().Replace(",", "");
                    dectnk = Convert.ToDecimal(strdecs);
                    //数量.
                    strdecs = fpSpread1_Sheet1.Cells[i, COLIDX_5].Value.ToString().Replace(",", "");
                    decsry = Convert.ToDecimal(strdecs);
                    //計算、表示.
                    decgki = dectnk * decsry;
                    fpSpread1_Sheet1.Cells[i, COLIDX_6].Value = decgki;//.ToString();
                }
            }

            for (int i = 0; i < fpSpread1_Sheet1.RowCount; i++)
            {
                //●本.
                if (fpSpread1_Sheet1.Cells[i, COLIDX_4].Text == COLIDX_HONBU)
                {
                    if (fpSpread1_Sheet1.Cells[i, COLIDX_6].Value != null)
                    {
                        strdec = fpSpread1_Sheet1.Cells[i, COLIDX_6].Value.ToString();
                        _dechonbukin += Convert.ToDecimal(strdec);
                    }
                }
                //●直.
                else if (fpSpread1_Sheet1.Cells[i, COLIDX_4].Text == COLIDX_TYOKUEI)
                {
                    if (fpSpread1_Sheet1.Cells[i, COLIDX_6].Value != null)
                    {
                        strdec = fpSpread1_Sheet1.Cells[i, COLIDX_6].Value.ToString();
                        _dectyokukin += Convert.ToDecimal(strdec);
                    }

                }
                //●ラ.
                else if (fpSpread1_Sheet1.Cells[i, COLIDX_4].Text == COLIDX_RAISENC)
                {
                    if (fpSpread1_Sheet1.Cells[i, COLIDX_6].Value != null)
                    {
                        strdec = fpSpread1_Sheet1.Cells[i, COLIDX_6].Value.ToString();
                        _decraisenckin += Convert.ToDecimal(strdec);
                    }
                }
            }

            //計算、及び出力.
            decimal deczandaka = 0M;
            decimal decgoukei = 0M;
            //残高計算.
            deczandaka = _dataRow.hb1SeiGak - (_dechonbukin + _dectyokukin + _decraisenckin);
            txtZandaka.Text = deczandaka.ToString("###,###,###,##0");
            //金額合計.
            decgoukei = (_dechonbukin + _dectyokukin + _decraisenckin);
            txtRyoukin.Text = decgoukei.ToString("###,###,###,##0");
            //直営.
            txtTyokuei.Text = _dectyokukin.ToString("###,###,###,##0");
            //ライセンシー.
            txtRaicenc.Text = _decraisenckin.ToString("###,###,###,##0");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Boolean CheckValue()
        {

            if (fpSpread1_Sheet1.ActiveColumnIndex == COLIDX_1)
            {
                //空だったら終わり.
                if (fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, fpSpread1_Sheet1.ActiveColumnIndex].Text.ToString().Equals(""))
                {
                    return false;
                }

                // データテーブル用.
                string strtnpnm = "";
                string strtnpkbn = "";
                //G.CLOSE年月日初期化.
                string closeDate = KKHMacConst.C_CLOSE_DATE;
                // 引数のデータセットを検索.
                DataRow[] foundRows = _naviParam.DivTenpoMastrslt.MasterDataSet.MasterDataVO.Select("Column1 = '" + fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, fpSpread1_Sheet1.ActiveColumnIndex].Text + "'");
                foreach (DataRow dr in foundRows)
                {
                    strtnpnm = dr["Column2"].ToString();
                    strtnpkbn = dr["Column4"].ToString();
                    closeDate = dr["Column17"].ToString();
                    break;
                }

                if (strtnpnm != null)
                {
                    if (strtnpnm.Equals(""))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0065, null, "明細入力", MessageBoxButtons.OK);
                        fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, fpSpread1_Sheet1.ActiveColumnIndex);
                        // セルの編集を開始します.
                        fpSpread1.StartCellEditing(null, false);
                        return true;
                    }
                    else
                    {
                        //G.CLOSE年月日.
                        fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, COLIDX_2].Text
                            = Isid.KKH.Common.KKHUtility.KKHUtility.StringCnvDateTime2(closeDate).ToString("yyy/M/d");
                        //店舗名.
                        fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, COLIDX_3].Text = strtnpnm;
                        //区分.
                        //●本.
                        if (strtnpkbn.Equals("0"))
                        {
                            fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, COLIDX_4].Text = COLIDX_HONBU;
                        }
                        //●直.
                        else if (strtnpkbn.Equals("1"))
                        {
                            fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, COLIDX_4].Text = COLIDX_TYOKUEI;
                        }
                        //●ラ.
                        else if (strtnpkbn.Equals("2"))
                        {
                            fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, COLIDX_4].Text = COLIDX_RAISENC;
                        }
                    }
                }
                else
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0065, null, "明細入力", MessageBoxButtons.OK);
                    fpSpread1_Sheet1.SetActiveCell(fpSpread1_Sheet1.ActiveRowIndex, fpSpread1_Sheet1.ActiveColumnIndex);
                    return true;
                }

                //再計算.
                bunkatudatakeisan();
            }
            //数量＊単価計算.
            if (fpSpread1_Sheet1.ActiveColumnIndex == COLIDX_5)
            {
                // 店舗コードが入力されていない場合、計算を行わない。.
                if (string.IsNullOrEmpty(fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, COLIDX_1].Text) == false)
                {
                    // 数量が入力されていない場合、"0"を設定.
                    if (string.IsNullOrEmpty(fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, COLIDX_5].Text) == true)
                    {
                        fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, COLIDX_6].Text = "0";
                    }

                    string strdec = "";
                    decimal decgki = 0M;
                    decimal dectnk = 0M;
                    decimal decsry = 0M;
                    //単価.
                    strdec = txttanka.Text.ToString().Replace(",", "");
                    dectnk = Convert.ToDecimal(strdec);
                    //数量.
                    if (fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, COLIDX_5].Value == null || string.IsNullOrEmpty(fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, COLIDX_5].Value.ToString()))
                    {
                        strdec = 0.ToString();
                        fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, COLIDX_5].Value = 0M;
                    }
                    else
                    {
                        strdec = fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, COLIDX_5].Value.ToString().Replace(",", "");
                    }
                    decsry = Convert.ToDecimal(strdec);
                    //計算、表示.
                    decgki = dectnk * decsry;
                    fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.ActiveRowIndex, COLIDX_6].Value = decgki;//.ToString();

                    bunkatudatakeisan();
                }
            }

            return false;
        }

        # endregion メソッド.
    }
}