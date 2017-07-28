using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHView.Common;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
namespace Isid.KKH.Toh.View.Detail
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DetailInputToh : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        #region メンバ変数.

        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;
        private int _rowDetailIndex = -1;
        private FarPoint.Win.Spread.SheetView _spdKkhDetail_Sheet1 = null;
        private String _currentKenNm = "";

        // 東宝アド対応 2015/06/12 add HLC K.Soga start
        /// <summary>
        /// 納品区分種別：006
        /// </summary>
        private const string NOUHINKBN_SYBT = "006";

        /// <summary>
        /// 納品区分（1：映画、2：演劇）：NOUHINKBN
        /// </summary>
        private const string NOUHINKBN_FIELD1 = "NOUHINKBN";
        // 東宝アド対応 2015/06/12 add HLC K.Soga end
        #endregion メンバ変数.

        #region コンストラクタ.

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public DetailInputToh()

        {
            InitializeComponent();
        }

        #endregion コンストラクタ.

        /// <summary>
        /// ＯＫボタンクリックイベント.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            // 掲載日チェック.
            if (this.IsDateTime(txtKeisaiDt.Text.Trim()) == false)
            {
                string[] paramString ={ "掲載日" };
                MessageUtility.ShowMessageBox(MessageCode.HB_W0003, paramString, "掲載日", MessageBoxButtons.OK);

                txtKeisaiDt.Focus();
                return;
            }

            // スペース２チェック処理.
            if (txtSpace2.Text.Trim() != "")
            {
                if (this.IsSpace2Check(txtSpace2.Text.Trim()) == false)
                {
                    // チェックエラー時.
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0014, null, "スペース2", MessageBoxButtons.OK);

                    txtSpace2.Focus();
                    return;
                }
            }

            // 明細がない場合.
            if (_spdKkhDetail_Sheet1.RowCount == 0)
            {
                // １行追加.
                _spdKkhDetail_Sheet1.AddRows(_rowDetailIndex, 1);
                _spdKkhDetail_Sheet1.AddSelection(_rowDetailIndex, -1, 1, -1);
            }
            // 明細スプレッドに入力内容を設定.
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_KENMEI].Value = txtKenNm.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_BAITAINM].Value = txtBaitaiNm.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_BAITAICD].Value = txtBaitaiCd.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_KBN].Value = cmbKbn.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_KEISAIDT].Value = txtKeisaiDt.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_TANKA].Value = txtTanka.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SPACE].Value = txtSpace.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SPACE2].Value = txtSpace2.Text.Trim();
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_RYOUKIN].Value = txtRyoukin.Text.Trim();

            // 消費税対応 2013/10/08 add HLC H.watabe start
            if (txtShohizei.Text.Trim() == string.Empty)
            {
                _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SHOHIZEI].Value = 0;
            }
            else
            {
                _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SHOHIZEI].Value = txtShohizei.Text.Trim();
            }
            // 消費税対応 2013/10/08 add HLC H.watabe end
            
            if (chkWak.Checked)
            {
                _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_WAKFLG].Value = "1";
            }
            else
            {
                _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_WAKFLG].Value = "";
            }
            // 件名が変更されている場合.
            if (_currentKenNm.Equals(txtKenNm.Text.Trim()) == false)
            {
                _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_KENMEICHGFLG].Value = "1";
            }
            _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_NOUHINKBN].Value = txtNouhinKbn.Text.Trim();

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
        /// フォームロードイベント,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailInputToh_Load(object sender, EventArgs e)
        {
            // 各コントロールの初期化,
            InitializeControl();
            // 各コントロールの編集,
            editControl();
        }

        /// <summary>
        /// 各コントロールの初期表示処理,
        /// </summary>
        private void InitializeControl()
        {
            // テキストボックス,
            txtKenNm.Text = "";
            txtBaitaiNm.Text = "";
            txtBaitaiCd.Text = "";
            txtKeisaiDt.Text = "";
            txtTanka.Text = "";
            txtSpace.Text = "";
            txtSpace2.Text = "";
            txtRyoukin.Text = "";
            txtNouhinKbn.Text = "";
            // コンボボックス,
            cmbKbn.Items.Clear();
            cmbKbn.Items.Add("M");
            cmbKbn.Items.Add("E");
            // チェックボックス.
            chkWak.Checked = false;

            // 2014/02/05 add JSE K.Tamura start
            // 各コントロールのタブインデックスを修正したので、初期フォーカスを設定しておく.
            // 初期フォーカス.
            this.ActiveControl = cmbKbn;
            // 2014/02/05 add JSE K.Tamura end
        }

        /// <summary>
        /// 各コントロールの編集処理.
        /// </summary>
        private void editControl()
        {
            // 明細がない場合.
            if (_spdKkhDetail_Sheet1.RowCount == 0)
            {
                //スペース2マスタ検索.
                MasterMaintenanceProcessController mastProcessController = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = mastProcessController.FindMasterByCond(_naviParam.strEsqId,
                                                                                                                        _naviParam.strEgcd,
                                                                                                                        _naviParam.strTksKgyCd,
                                                                                                                        _naviParam.strTksBmnSeqNo,
                                                                                                                        _naviParam.strTksTntSeqNo,
                                                                                                                        "0002",
                                                                                                                        null);
                // 東宝アド対応 2015/06/12 add HLC K.Soga start
                // 汎用システムマスタ検索.
                CommonProcessController commonProcessController = CommonProcessController.GetInstance();
                FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(_naviParam.strEsqId,
                                                                                                                    _naviParam.strEgcd,
                                                                                                                    _naviParam.strTksKgyCd,
                                                                                                                    _naviParam.strTksBmnSeqNo,
                                                                                                                    _naviParam.strTksTntSeqNo,
                                                                                                                    NOUHINKBN_SYBT,
                                                                                                                    NOUHINKBN_FIELD1);
                // 東宝アド対応 2015/06/12 add HLC K.Soga end

                if (result.HasError)
                {
                    throw new Exception();
                    return;
                }

                _currentKenNm = _dataRow.hb1KKNameKJ.ToString().Trim();
                txtKenNm.Text = _dataRow.hb1KKNameKJ.ToString().Trim();
                txtBaitaiNm.Text = _dataRow.hb1Field2.ToString().Trim();
                txtBaitaiCd.Text = _dataRow.hb1Field1.ToString().Trim();

                // 朝刊の場合.
                if ("1".Equals(_dataRow.hb1Field4.ToString().Trim()))
                {
                    cmbKbn.SelectedIndex = 0;
                }
                // 夕刊の場合.
                else
                {
                    cmbKbn.SelectedIndex = 1;
                }
                // 掲載日がない場合.
                if ("".Equals(_dataRow.hb1Field3.ToString().Trim())) {
                    txtKeisaiDt.Text = "";

                }
                // 掲載日がある場合.
                else
                {
                    String keisaiDt = _dataRow.hb1Field3.ToString().Trim();
                    keisaiDt = keisaiDt.Substring(0, 4) + "/" + keisaiDt.Substring(4, 2) + "/" + keisaiDt.Substring(6,2);
                    txtKeisaiDt.Text = keisaiDt;
                }
                txtTanka.Text = _dataRow.hb1SeiTnka.ToString("###,###,###,##0");

                /*
                 * スペース.
                 */
                String space = _dataRow.hb1Field11.ToString().Trim();
                //10桁以上ある場合.
                if (space.Length > 10)
                {
                    //10桁までを取得.
                    space = space.Substring(0, 10);
                }
                // スペースに"D"が含まれている、かつ"X"が含まれていない場合.
                if (space.IndexOf("D") >= 0 && space.IndexOf("X") < 0)
                {
                    // スペースの最後が"D"の場合.
                    if (space.IndexOf("D") == space.Length - 1)
                    {
                        // 最後の"D"を削除.
                        space = space.Substring(0, space.Length - 1);
                    }
                    // 上記以外の場合.
                    else
                    {
                        int index = space.IndexOf("D");
                        // 最初の"D"を"*"に変換.
                        space = space.Substring(0, space.IndexOf("D")) + "*" + space.Substring(space.IndexOf("D") + 1);
                    }
                }

                txtSpace.Text = space;

                /*
                 * スペース２.
                 */
                //スペース２一覧の値を取得する.
                if (result.MasterDataSet.MasterDataVO.Select("Column1 = '" + _dataRow.hb1Field11.Trim() + "'").Length > 0)
                {
                    MasterMaintenance.MasterDataVORow mstRow = (MasterMaintenance.MasterDataVORow)result.MasterDataSet.MasterDataVO.Select("Column1 = '" + _dataRow.hb1Field11.Trim() + "'")[0];
                    txtSpace2.Text = mstRow.Column2.Trim();
                }

                txtRyoukin.Text = _dataRow.hb1SeiGak.ToString("###,###,###,##0");
                // 消費税対応 2013/10/08 add HLC H.Watabe start
                txtShohizei.Text = Math.Truncate(_dataRow.hb1SzeiRitu).ToString();
                // 消費税対応 2013/10/08 add HLC H.Watabe end

                // 東宝アド対応 2015/06/12 mod HLC K.Soga start
                //txtNouhinKbn.Text = "1";

                // 汎用システムマスタに納品区分データが1件以上存在する場合.
                if (comResult.CommonDataSet.SystemCommon.Count != 0)
                {
                    // 納品区分欄に数値を入力(1:映画, 2:演劇).
                    txtNouhinKbn.Text = comResult.CommonDataSet.SystemCommon[0].field2.ToString();
                }
                else
                {
                    // データが一件もない場合、何も表示しない.
                    txtNouhinKbn.Text = string.Empty;
                }
                // 東宝アド対応 2015/06/12 mod HLC K.Soga end

                // 枠フラグ.
                chkWak.Checked = false;
            }
            // 明細がある場合.
            else
            {
                _currentKenNm = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_KENMEI].Text.Trim();
                txtKenNm.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_KENMEI].Text.Trim();
                txtBaitaiNm.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_BAITAINM].Text.Trim();
                txtBaitaiCd.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_BAITAICD].Text.Trim();
                // 夕刊の場合.
                if ("E".Equals(_spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_KBN].Text.Trim()))
                {
                    cmbKbn.SelectedIndex = 1;
                }
                // 朝刊の場合.
                else
                {
                    cmbKbn.SelectedIndex = 0;
                }
                txtKeisaiDt.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_KEISAIDT].Text.Trim();
                txtTanka.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_TANKA].Text.Trim();
                if (_spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SPACE].Text.Trim().Length > 10)
                {
                    txtSpace.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SPACE].Text.Trim().Substring(0, 10);
                }
                else
                {
                    txtSpace.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SPACE].Text.Trim();
                }
                txtSpace2.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SPACE2].Text.Trim();
                txtRyoukin.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_RYOUKIN].Text.Trim();
                // 消費税対応 2013/10/08 add HLC H.Watabe start
                txtShohizei.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_SHOHIZEI].Text.Trim();
                // 消費税対応 2013/10/08 add HLC H.Watabe end
                txtNouhinKbn.Text = _spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_NOUHINKBN].Text.Trim();
                if (_spdKkhDetail_Sheet1.Cells[_rowDetailIndex, DetailToh.COLIDX_MLIST_WAKFLG].Text.Trim().Equals("1"))
                {
                    chkWak.Checked = true;
                }
                else
                {
                    chkWak.Checked = false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailInputToh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;

                _dataRow = _naviParam.DataRow;
                _rowDetailIndex = _naviParam.RowDetailIndex;
                _spdKkhDetail_Sheet1 = _naviParam.SpdKkhDetail_Sheet1;
            }
        }

        #region スペース２変換処理.

        /// <summary>
        /// スペース２変換処理.
        /// 
        /// ①スペースの内容を以下の通り変換.
        /// ・全角⇒半角、大文字⇒小文字に変換.
        /// ・0～9、dx/*.×÷以外の文字・記号を削除.
        /// 
        /// ②*、/ の有無により、以下の通り計算する.
        /// ・*、/ あり.
        ///     ⇒計算パターン：(X * Y / Z).
        /// ・* あり.
        ///     ⇒計算パターン：(X * Y).
        /// ・/ あり.
        ///     ⇒計算パターン：(Y / Z).
        /// ・*、/ なし.
        ///     ⇒計算パターンなし かつ 数値.
        ///         ⇒スペースの内容を返却.
        ///     ⇒数値以外.
        ///         ⇒ブランク.
        /// </summary>
        /// <param name="space">スペース２変換元文字列</param>
        /// <returns>スペース２変換後文字列</returns>
        public String space2ConversionMethod(String space)
        //private String space2ConversionMethod(String space)
        {
            //********************
            // 全角⇒半角変換.
            //********************
            //String space2Conversion = Strings.StrConv(space, Microsoft.VisualBasic.VbStrConv.Narrow, 0);
            String space2Conversion = KKHStrConv.toNarrow(space);

            //********************
            // 大文字⇒小文字変換.
            //********************
            //space2Conversion = Strings.StrConv(space2Conversion, Microsoft.VisualBasic.VbStrConv.Lowercase, 0);
            space2Conversion = KKHStrConv.toLower(space2Conversion);

            //********************
            // 正規表現設定.
            //********************
            String matchPattern = "[^0-9d/*.]";
            String regularExpressionPattern = "[0-9dx/*.×÷]";

            //"[0-9d/*.]"以外の文字がある場合、true
            bool chk = Regex.IsMatch(space2Conversion, matchPattern);

            //"[0-9d/*.]"以外の文字がある場合.
            if (chk)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            MatchCollection mc = Regex.Matches(space2Conversion, regularExpressionPattern);

            // 正規表現で設定した文字のみ取得.
            foreach (Match m in mc)
            {
                sb.Append(m.Value);
            }

            space2Conversion = sb.ToString();

            //********************
            // x× を * に変換.
            //********************
            String multiplicationConversionPattern = "[x×]";
            Regex reg = new Regex(multiplicationConversionPattern);
            space2Conversion = reg.Replace(space2Conversion, "*");

            //********************
            // ÷ を / に変換.
            //********************
            String divisionConversionPattern = "[÷]";
            reg = new Regex(divisionConversionPattern);
            space2Conversion = reg.Replace(space2Conversion, "/");

            //********************************************
            // スペースに"d"が含まれている場合の処理.
            //********************************************
            if (space2Conversion.IndexOf("d") >= 0)
            {
                // スペースに"d"が含まれている場合.
                String etcConversionPattern = "[d]";
                reg = new Regex(etcConversionPattern);

                if (space2Conversion.IndexOf("*") < 0)
                {
                    // スペースに"*"が含まれていない場合.
                    if (space2Conversion.IndexOf("d") == space2Conversion.Length - 1)
                    {
                        // スペースの最後が"d"の場合.
                        // 最後の"d"を削除.
                        space2Conversion = reg.Replace(space2Conversion, "");
                    }
                    else
                    {
                        // 上記以外の場合.
                        space2Conversion = reg.Replace(space2Conversion, "*");
                    }
                }
                else
                {
                    // スペースに"*"が含まれている場合.
                    // "d"を削除.
                    space2Conversion = reg.Replace(space2Conversion, "");
                }
            }

            //********************************
            // 掛け算、割り算記号位置取得.
            //********************************
            int multiplicationIndex = space2Conversion.IndexOf("*");
            int divisionIndex = space2Conversion.IndexOf("/");

            double valueX = 0;                  // 値1
            double valueY = 0;                  // 値2
            double valueZ = 0;                  // 値3
            double calculationResult = 0;       // 計算結果.
            String strCalculationResult = "";   // 計算結果(String)

            //********************
            // 計算処理.
            //********************
            try
            {
                if (multiplicationIndex >= 0)
                {
                    // 掛け算記号あり.
                    valueX = double.Parse(space2Conversion.Substring(0, multiplicationIndex));

                    if (divisionIndex >= 0)
                    {
                        // 割り算記号あり.
                        valueY = double.Parse(space2Conversion.Substring(multiplicationIndex + 1, divisionIndex - multiplicationIndex - 1));
                        valueZ = double.Parse(space2Conversion.Substring(divisionIndex + 1));

                        //==============================
                        // 計算パターン：(X * Y / Z)
                        //==============================
                        calculationResult = valueX * valueY / valueZ;
                        strCalculationResult = calculationResult.ToString();
                    }
                    else
                    {
                        valueY = double.Parse(space2Conversion.Substring(multiplicationIndex + 1));

                        //==============================
                        // 計算パターン：(X * Y)
                        //==============================
                        calculationResult = valueX * valueY;
                        strCalculationResult = calculationResult.ToString();
                    }
                }
                else
                {
                    // 掛け算記号なし.
                    if (divisionIndex >= 0)
                    {
                        // 割り算記号あり.
                        valueY = double.Parse(space2Conversion.Substring(0, divisionIndex));
                        valueZ = double.Parse(space2Conversion.Substring(divisionIndex + 1));

                        //==============================
                        // 計算パターン：(Y / Z)
                        //==============================
                        calculationResult = valueY / valueZ;
                        strCalculationResult = calculationResult.ToString();
                    }
                    else
                    {
                        double parseResult; // 数値チェック用変数.

                        if (double.TryParse(space2Conversion, out parseResult))
                        {
                            //==============================
                            // 計算パターンなし かつ 数値.
                            //==============================
                            strCalculationResult = space2Conversion;
                        }
                        else
                        {
                            //==============================
                            // 数値以外.
                            //==============================
                            strCalculationResult = "";
                        }
                    }
                }
            }
            catch
            {
                // 変換後文字列返却.
                return strCalculationResult = "";
            }
            // 変換後文字列返却.
            return strCalculationResult;
        }

        #endregion スペース２変換処理.

        #region スペース２数値チェック処理.

        /// <summary>
        /// スペース２数値チェック処理.
        /// 
        /// ①以下のチェックを実施.
        /// ・スペース２に入力あり かつ.
        /// 　スペース２が数値.
        /// 　⇒true
        /// ・上記以外.
        /// 　⇒false
        /// </summary>
        /// <param name="space2">スペース２</param>
        /// <returns>チェック結果</returns>
        private bool IsSpace2Check(String space2)
        {
            bool isCheckResult = false;

            if (space2 != "")
            {
                // スペース２がブランク以外.
                double parseResult; // 数値チェック用変数.

                if (double.TryParse(space2, out parseResult))
                {
                    // スペース２が数値.
                    isCheckResult = true;
                }
            }

            return isCheckResult;
        }

        #endregion スペース２変換処理.

        #region 日付チェック処理.

        /// <summary>
        /// パラメータの値が日付かチェックする.
        /// </summary>
        /// <param name="paramString">チェック対象の文字列</param>
        /// <returns>
        /// ture    : 日付.
        /// false   : 日付以外.
        /// </returns>
        private bool IsDateTime(string paramString)
        {
            // 戻り値を初期化.
            bool returnValue = true;

            // パラメータがNullまたは""でない場合.
            if (string.IsNullOrEmpty(paramString) == false)
            {
                // 日付変換し、変換できなければ戻り値にfalseを設定する.
                DateTime parseResult = new DateTime();
                if (DateTime.TryParse(paramString, out parseResult) == false)
                {
                    returnValue = false;
                }
            }

            return returnValue;
        }

        #endregion
    }
}
