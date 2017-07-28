using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHView.Common;

namespace Isid.KKH.Mac.View.Detail
{
    public partial class DetailInputMac : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        #region 定数.

        /// <summary>
        /// 小数点.
        /// </summary>
        private const char DECIMAL_POINT = '.';

        /// <summary>
        /// バックスペース.
        /// </summary>
        private const char BACK_SPACE = '\b';

        #endregion 定数.

        #region メンバ変数.

        private DetailInputMacNaviParameter _naviParam = new DetailInputMacNaviParameter();
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;
        private int _rowDetailIndex = -1;
        private FarPoint.Win.Spread.SheetView _spdKkhDetail_Sheet1 = null;
        private String _currentKenNm = "";

        #endregion メンバ変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DetailInputMac()

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

            // 明細がない場合.
            if (_spdKkhDetail_Sheet1.RowCount == 0)
            {
                // １行追加.
                _spdKkhDetail_Sheet1.AddRows(_rowDetailIndex, 1);
            }

            // 明細スプレッドに入力内容を設定.
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_KENMEI].Value = txtKenNm.Text.Trim() + txtKenNm2.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_KENMEI1].Value = txtKenNm.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_KENMEI2].Value = txtKenNm2.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_KINGAKU].Value = txtRyoukin.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_TENPOCD].Value = txtTenpoCd.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_TIKUHONBUCD].Value = txtTenpoCd.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_TENPOMEI].Value = txtTenpoNm.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_TIKUHONBU].Value = txtTenpoNm.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_KANJYOKMK].Value = txtKanjyo.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_TANKA].Value = txtRyoukin.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_SURYO].Value = "1";
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_TENPOKUBUNRETU].Value = txtTenpokbn.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_BUNKATUFLG].Value = "1";//入力データ

            // 消費税対応 2013/10/21 add HLC H.Watabe start
            if (txtShohizei.Text.Trim().Length != 0)
            {
                _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDC_MLIST_SHOHIZEIRITU].Value = txtShohizei.Text.Trim();
            }
            else
            {
                _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDC_MLIST_SHOHIZEIRITU].Value = 0;
            }
            // 消費税対応 2013/10/21 add HLC H.Watabe end

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
        private void DetailInputMac_Load(object sender, EventArgs e)
        {
            // 各コントロールの初期化.
            InitializeControl();
            // 各コントロールの編集.
            editControl();
        }

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
            // 消費税対応 2013/10/21 add HLC H.Watabe start
            txtShohizei.Text = "";
            // 消費税対応 2013/10/21 add HLC H.Watabe end
        }

        /// <summary>
        /// 各コントロールの編集処理.
        /// </summary>
        private void editControl()
        {
            //期間用変数.
            string strkikan = "";
            // 明細がない場合.
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

                // 消費税対応 2013/10/21 add HLC H.Watabe start
                txtShohizei.Text = Math.Truncate(_dataRow.hb1SzeiRitu).ToString();
                // 消費税対応 2013/10/21 add HLC H.Watabe end

                //空で出力.
                txtTenpoCd.Text = "";
                txtTenpoNm.Text = "";
                txtKanjyo.Text = "";
            }
            // 明細がある場合.
            else
            {
                _currentKenNm = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_KENMEI].Text.Trim();
                txtKenNm.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_KENMEI1].Text.Trim();
                txtKenNm2.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_KENMEI2].Text.Trim();

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
                //txtRyoukin.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_KINGAKU].Text.Trim();
                lblSeteiKin.Text = _dataRow.hb1SeiGak.ToString("###,###,###,##0");

                // 消費税対応 2013/10/21 add HLC H.Watabe start
                // 既に入力された明細の消費税を表示.
                txtShohizei.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDC_MLIST_SHOHIZEIRITU].Text.Trim();
                // 消費税対応 2013/10/21 add HLC H.Watabe end

                //空で出力.
                txtTenpoCd.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_TENPOCD].Text.Trim();
                txtTenpoNm.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_TENPOMEI].Text.Trim();
                txtKanjyo.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailMac.COLIDX_MLIST_KANJYOKMK].Text.Trim();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailInputMac_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is DetailInputMacNaviParameter)
            {
                _naviParam = (DetailInputMacNaviParameter)arg.NaviParameter;

                _dataRow = _naviParam.DataRow;
                _rowDetailIndex = _naviParam.RowDetailIndex;
                _spdKkhDetail_Sheet1 = _naviParam.SpdKkhDetail_Sheet1;
            }
        }

        /// <summary>
        /// 店舗コード一覧　表示.
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
            naviParam.ItrTenpoMastrslt = _naviParam.InpTenpoMastrslt;
            naviParam.AllorFlg = "2";//一部が対象.

            object result = Navigator.ShowModalForm(this, "toDetailTenpoItr", naviParam);
            if (result == null)
            {
                this.ActiveControl = null;
                return;
            }
            //セット.
            if (naviParam.TenpoCd.Equals(""))
            {
            }
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
        private void TextBox_KeyPressNumChk(object sender,System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTenpoCd_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTenpoCd.Text))
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
            if (txtTenpoCd.Text.Substring(0,1) != "9")
            {
                //「店舗コードが間違っています」.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0062, null, "明細入力", MessageBoxButtons.OK);
                txtTenpoNm.Text = "";
                txtTenpoCd.Focus();
                return;
            }

            // 引数のデータセットを検索.
            DataRow[] foundRows = _naviParam.InpTenpoMastrslt.MasterDataSet.MasterDataVO.Select("Column1 = '" + txtTenpoCd.Text + "'");
            foreach (DataRow dr in foundRows)
            {
                txtTenpoNm.Text = dr["Column2"].ToString();
                txtTenpokbn.Text = dr["Column4"].ToString();
                return;
            }

            //無かった場合.
            MessageUtility.ShowMessageBox(MessageCode.HB_W0065, null, "明細入力", MessageBoxButtons.OK);
            txtTenpoNm.Text = "";
            txtTenpoCd.Focus();
            return;
        }

        /// <summary>
        /// 消費税テキストボックスに入力した場合に発生するイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtShohizei_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 数字と小数点とバックスペース以外の時は、イベントをキャンセルする.
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != DECIMAL_POINT && e.KeyChar != BACK_SPACE)
            {
                e.Handled = true;
            }
        }

        #endregion イベント.
    }
}