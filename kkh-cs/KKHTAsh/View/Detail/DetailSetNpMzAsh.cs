using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FarPoint.Win.Spread.Model;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Ash.Utility;

namespace Isid.KKH.Ash.View.Detail
{
    public partial class DetailSetNpMzAsh : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        #region メンバ変数.
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;
        private FarPoint.Win.Spread.SheetView _spdDetailInput_Sheet1 = null;
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        private Encoding _enc = Encoding.GetEncoding("shift-jis");
        #endregion メンバ変数.

        #region コンストラクタ.
        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public DetailSetNpMzAsh()

        {
            InitializeComponent();
        }
        #endregion コンストラクタ.

        # region イベント.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailSetNpMzAsh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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
            }
        }

        /// <summary>
        /// ＯＫボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //複数選択している場合 
            if (isMultiDataSelection() == true)
            {
                CellRange[] cellRangeArray = _spdDetailInput_Sheet1.GetSelections();
                //選択されている行の件数分、繰り返す 
                foreach (CellRange cellRange in cellRangeArray)
                {
                    for (int i = cellRange.Row; i < cellRange.Row + cellRange.RowCount; i++)
                    {
                        //明細入力スプレッド設定 
                        setDetailInputSpd(i);
                    }
                }
            }
            //複数選択していない場合 
            else
            {
                //明細件数分、繰り返す.
                for (int i = 0; i < _spdDetailInput_Sheet1.RowCount; i++)
                {
                    //明細入力スプレッド設定 
                    setDetailInputSpd(i);
                }
            }

            Navigator.Backward(this, _naviParam, null, true);
            this.Close();
        }

        /// <summary>
        /// キャンセルボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
            this.Close();
        }

        /// <summary>
        /// フォームロードイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailSetNpMzAsh_Load(object sender, EventArgs e)
        {
            // 各コントロールの初期化 
            InitializeControl();
            // 各コントロールの編集 
            editControl();
        }

        # endregion イベント 

        # region メソッド 

        /// <summary>
        /// 各コントロールの初期表示処理 
        /// </summary>
        private void InitializeControl()
        {
            //テキストボックス初期化 
            txtSpace.Text = "";
            //*********************************
            //朝夕区分コンボボックス 
            //*********************************
            List<AshComboBoxItem> items;
            items = new List<AshComboBoxItem>();
            items.Add(new AshComboBoxItem(KkhConstAsh.TyouSekiKbn.MORNING, KkhConstAsh.TyouSekiNm.MORNING));
            items.Add(new AshComboBoxItem(KkhConstAsh.TyouSekiKbn.EVENING, KkhConstAsh.TyouSekiNm.EVENING));
            cmbTyouSekiKbn.Items.Clear();
            cmbTyouSekiKbn.DisplayMember = "NAME";
            cmbTyouSekiKbn.ValueMember = "CODE";
            cmbTyouSekiKbn.DataSource = items;

            //*********************************
            //記雑区分コンボボックス 
            //*********************************
            CommonProcessController processController = CommonProcessController.GetInstance();
            FindCommonCodeMasterByCondServiceResult resultKizatsuKbn = processController.FindCommonCodeMasterByCond(_naviParam.strEsqId, "WC", _naviParam.strDate);
            Isid.KKH.Common.KKHSchema.Common.RcmnMeu29CCDataTable dsKizatsuKbn = new Isid.KKH.Common.KKHSchema.Common.RcmnMeu29CCDataTable();
            dsKizatsuKbn.Merge(resultKizatsuKbn.CommonDataSet.RcmnMeu29CC);
            dsKizatsuKbn.AcceptChanges();
            cmbKizatsuKbn.DisplayMember = dsKizatsuKbn.naiyJColumn.ColumnName;
            cmbKizatsuKbn.ValueMember = dsKizatsuKbn.kyCdColumn.ColumnName;
            cmbKizatsuKbn.DataSource = dsKizatsuKbn;

            //*********************************
            //掲載版、掲載号コンボボックス 
            //*********************************
            FindCommonCodeMasterByCondServiceResult resultKeisaiBan = processController.FindCommonCodeMasterByCond(_naviParam.strEsqId, "WB", _naviParam.strDate);
            Isid.KKH.Common.KKHSchema.Common.RcmnMeu29CCDataTable dsKeisaiBan = new Isid.KKH.Common.KKHSchema.Common.RcmnMeu29CCDataTable();
            dsKeisaiBan.Merge(resultKeisaiBan.CommonDataSet.RcmnMeu29CC);
            dsKeisaiBan.AcceptChanges();
            cmbKeisaiBan.DisplayMember = dsKeisaiBan.naiyJColumn.ColumnName;
            cmbKeisaiBan.ValueMember = dsKeisaiBan.kyCdColumn.ColumnName;
            cmbKeisaiBan.DataSource = dsKeisaiBan;

        }

        /// <summary>
        /// 各コントロールの編集処理 
        /// </summary>
        private void editControl()
        {
            // 明細入力スプレッドの対象行Index取得 
            int rowIndex = getSubjectRowIndex();

            // 掲載日　発売日 
            String strKeisaiDt = null;
            //2013/04/08 hlc sonobe Start
            //strKeisaiDt = _spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KEISAIDT].Text.Trim();
            string _keisaiBi = _spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KEISAIDT].Text.Trim();
            _keisaiBi = _keisaiBi.Replace("年", "");
            _keisaiBi = _keisaiBi.Replace("月", "");
            _keisaiBi = _keisaiBi.Replace("日", "");
            strKeisaiDt = _keisaiBi;
            //2013/04/08 hlc sonobe End
            if (!String.IsNullOrEmpty(strKeisaiDt) && strKeisaiDt.Length == 8)
            {
                if (KKHUtility.IsDate(strKeisaiDt, "yyyyMMdd") == true)
                {
                    dtpKeisaiDt.Value = KKHUtility.StringCnvDateTime(strKeisaiDt);
                }
                else
                {
                    dtpKeisaiDt.Value = KKHUtility.StringCnvDateTime(_dataRow.hb1Yymm.ToString().Trim() + "01");
                }
            }
            else
            {
                dtpKeisaiDt.Value = KKHUtility.StringCnvDateTime(_dataRow.hb1Yymm.ToString().Trim() + "01");
            }
            //スペース 
            txtSpace.Text = _spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_SPACE].Text.Trim();
            //媒体コードが"130"（新聞）の場合 
            if (KkhConstAsh.BaitaiCd.SHINBUN.Equals(_naviParam.BaitaiCd))
            {
                //朝夕区分 
                if (KKHUtility.ToString(_spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_TYOUSEKIKBN].Value).Trim().Equals("") == false)
                {
                    if (_spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_TYOUSEKIKBN].Value.ToString() == KkhConstAsh.TyouSekiKbn.MORNING)
                    {
                        cmbTyouSekiKbn.Text = "朝";
                    }
                    else if (_spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_TYOUSEKIKBN].Value.ToString() == KkhConstAsh.TyouSekiKbn.EVENING)
                    {
                        cmbTyouSekiKbn.Text = "夕";
                    }
                }
                else
                {
                    cmbTyouSekiKbn.SelectedIndex = 0;
                }
                //掲載版、掲載号 
                if (KKHUtility.ToString(_spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KEISAIBAN].Value).Trim().Equals("") == false)
                {
                    if (_spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KEISAIBAN].Value.ToString() == KkhConstAsh.KeisaiKbn.KEIKBN_ZENBAN)
                    {
                        cmbKeisaiBan.Text = "全版通し";
                    }
                    else if (_spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KEISAIBAN].Value.ToString() == KkhConstAsh.KeisaiKbn.KEIKBN_TOUGOU)
                    {
                        cmbKeisaiBan.Text = "統合版";
                    }
                    else if (_spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KEISAIBAN].Value.ToString() == KkhConstAsh.KeisaiKbn.KEIKBN_TOUGOUNUKI)
                    {
                        cmbKeisaiBan.Text = "統合抜き";
                    }
                    else if (_spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KEISAIBAN].Value.ToString() == KkhConstAsh.KeisaiKbn.KEIKBN_YUKAN)
                    {
                        cmbKeisaiBan.Text = "夕刊＋統合版";
                    }
                    else if (_spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KEISAIBAN].Value.ToString() == KkhConstAsh.KeisaiKbn.KEIKBN_TIIKIKOUKOKU)
                    {
                        cmbKeisaiBan.Text = "地域広告";
                    }
                }
                else
                {
                    cmbKeisaiBan.SelectedIndex = 0;
                }
                //記雑区分 
                if (KKHUtility.ToString(_spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value).Trim().Equals("") == false)
                {
                    if (_spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value.ToString() == KKHSystemConst.KizatsuKbn.KIZKN_KIJISITA)
                    {
                        cmbKizatsuKbn.Text = "記事下";
                    }
                    else if (_spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value.ToString() == KKHSystemConst.KizatsuKbn.KIZKN_KIJINAKA)
                    {
                        cmbKizatsuKbn.Text = "記事中";
                    }
                    else if (_spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value.ToString() == KKHSystemConst.KizatsuKbn.KIZKN_TOSYUTU)
                    {
                        cmbKizatsuKbn.Text = "突　出";
                    }
                    else if (_spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value.ToString() == KKHSystemConst.KizatsuKbn.KIZKN_DAIJI)
                    {
                        cmbKizatsuKbn.Text = "題　字";
                    }
                    else if (_spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value.ToString() == KKHSystemConst.KizatsuKbn.KIZKN_HASAKOMI)
                    {
                        cmbKizatsuKbn.Text = "挟　込";
                    }
                    else if (_spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value.ToString() == KKHSystemConst.KizatsuKbn.KIZKN_TOKUSYU)
                    {
                        cmbKizatsuKbn.Text = "特殊雑報";
                    }
                    else if (_spdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value.ToString() == KKHSystemConst.KizatsuKbn.KIZKN_ANNAI)
                    {
                        cmbKizatsuKbn.Text = "案　内";
                    }
                }
                else
                {
                    cmbKizatsuKbn.SelectedIndex = 0;
                }
            }
            else
            {
                //朝夕区分 
                grpTyouSekiKbn.Visible = false;
                //掲載版、掲載号 
                grpKeisaiBan.Visible = false;
                //記雑区分 
                grpKizatsuKbn.Visible = false;
                //フォームの高さ 
                this.Height = 144;
            }
        }


        /// <summary>
        /// スペースのTextChangedイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSpace_TextChanged(object sender, EventArgs e)
        {
            txtSpace.Text = KKHUtility.RemoveProhibitionChar(txtSpace.Text);
            string str = txtSpace.Text;
            int len = txtSpace.MaxLength;
            if (_enc.GetByteCount(str) > len)
            {
                str = _enc.GetString(_enc.GetBytes(str), 0, len);
                txtSpace.Text = str;
            }
            txtSpace.SelectionStart = len;
        }

        /// <summary>
        /// 明細入力設定 
        /// </summary>
        /// <param name="rowIndex"></param>
        private void setDetailInputSpd(int rowIndex)
        {
            // 掲載日 
            string keisaiDt = dtpKeisaiDt.Value.ToShortDateString().Replace("/", "");
            _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KEISAIDT].Value = keisaiDt;
            //放送時間、路線名称 
            _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_HOSOUJIKAN].Value = " ";
            //曜日 
            _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_YOUBI].Value = " ";
            //局ネット数 
            _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KYOKUNETSU].Value = " ";
            //キー局 
            _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KEYKYOKUCD].Value = " ";
            //スペース 
            //全角ありの場合 
            if (StringChecker.ZenkakuCheck(txtSpace.Text) == true)
            {
                _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_SPACE].Value = " ";
            }
            //全角なしの場合 
            else
            {
                _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_SPACE].Value = txtSpace.Text;
            }
            //媒体コードが"130"（新聞）の場合 
            if (KkhConstAsh.BaitaiCd.SHINBUN.Equals(_naviParam.BaitaiCd) == true)
            {
                //朝夕区分 
                if (cmbTyouSekiKbn.SelectedValue.ToString() != "")
                {
                    if (cmbTyouSekiKbn.SelectedValue.ToString() == KkhConstAsh.TyouSekiKbn.MORNING)
                    {
                        _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_TYOUSEKIKBN].Value = KkhConstAsh.TyouSekiKbn.MORNING;
                    }
                    else if (cmbTyouSekiKbn.SelectedValue.ToString() == KkhConstAsh.TyouSekiKbn.EVENING)
                    {
                        _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_TYOUSEKIKBN].Value = KkhConstAsh.TyouSekiKbn.EVENING;
                    }
                }
                else if (cmbTyouSekiKbn.SelectedValue.ToString() == "")
                {
                    _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_TYOUSEKIKBN].Value = " ";
                }

                //掲載版 
                if (cmbKeisaiBan.SelectedValue.ToString() != "")
                {
                    if (cmbKeisaiBan.SelectedValue.ToString() == KkhConstAsh.KeisaiKbn.KEIKBN_ZENBAN)
                    {
                        _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KEISAIBAN].Value = KkhConstAsh.KeisaiKbn.KEIKBN_ZENBAN;
                    }
                    else if (cmbKeisaiBan.SelectedValue.ToString() == KkhConstAsh.KeisaiKbn.KEIKBN_TOUGOU)
                    {
                        _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KEISAIBAN].Value = KkhConstAsh.KeisaiKbn.KEIKBN_TOUGOU;
                    }
                    else if (cmbKeisaiBan.SelectedValue.ToString() == KkhConstAsh.KeisaiKbn.KEIKBN_TOUGOUNUKI)
                    {
                        _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KEISAIBAN].Value = KkhConstAsh.KeisaiKbn.KEIKBN_TOUGOUNUKI;
                    }
                    else if (cmbKeisaiBan.SelectedValue.ToString() == KkhConstAsh.KeisaiKbn.KEIKBN_YUKAN)
                    {
                        _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KEISAIBAN].Value = KkhConstAsh.KeisaiKbn.KEIKBN_YUKAN;
                    }
                    else if (cmbKeisaiBan.SelectedValue.ToString() == KkhConstAsh.KeisaiKbn.KEIKBN_TIIKIKOUKOKU)
                    {
                        _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KEISAIBAN].Value = KkhConstAsh.KeisaiKbn.KEIKBN_TIIKIKOUKOKU;
                    }
                }
                else if (cmbKeisaiBan.SelectedValue.ToString() == "")
                {
                    _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KEISAIBAN].Value = " ";
                }

                //記雑区分 
                if (cmbKizatsuKbn.SelectedValue.ToString() != "")
                {
                    if (cmbKizatsuKbn.SelectedValue.ToString() == KKHSystemConst.KizatsuKbn.KIZKN_KIJISITA)
                    {
                        _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value = KKHSystemConst.KizatsuKbn.KIZKN_KIJISITA;
                    }
                    else if (cmbKizatsuKbn.SelectedValue.ToString() == KKHSystemConst.KizatsuKbn.KIZKN_KIJINAKA)
                    {
                        _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value = KKHSystemConst.KizatsuKbn.KIZKN_KIJINAKA;
                    }
                    else if (cmbKizatsuKbn.SelectedValue.ToString() == KKHSystemConst.KizatsuKbn.KIZKN_TOSYUTU)
                    {
                        _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value = KKHSystemConst.KizatsuKbn.KIZKN_TOSYUTU;
                    }
                    else if (cmbKizatsuKbn.SelectedValue.ToString() == KKHSystemConst.KizatsuKbn.KIZKN_DAIJI)
                    {
                        _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value = KKHSystemConst.KizatsuKbn.KIZKN_DAIJI;
                    }
                    else if (cmbKizatsuKbn.SelectedValue.ToString() == KKHSystemConst.KizatsuKbn.KIZKN_HASAKOMI)
                    {
                        _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value = KKHSystemConst.KizatsuKbn.KIZKN_HASAKOMI;
                    }
                    else if (cmbKizatsuKbn.SelectedValue.ToString() == KKHSystemConst.KizatsuKbn.KIZKN_TOKUSYU)
                    {
                        _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value = KKHSystemConst.KizatsuKbn.KIZKN_TOKUSYU;
                    }
                    else if (cmbKizatsuKbn.SelectedValue.ToString() == KKHSystemConst.KizatsuKbn.KIZKN_ANNAI)
                    {
                        _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value = KKHSystemConst.KizatsuKbn.KIZKN_ANNAI;
                    }
                }
                else if (cmbKizatsuKbn.SelectedValue.ToString() == "")
                {
                    _naviParam.SpdDetailInput_Sheet1.Cells[rowIndex, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value = " ";
                }
            }
        }

        /// <summary>
        /// 対象行Indexの取得 
        /// </summary>
        private int getSubjectRowIndex()
        {
            // 選択されている行を取得 
            CellRange[] cellRangeArray = _spdDetailInput_Sheet1.GetSelections();

            if (cellRangeArray.Length > 0)
            {
                int rowCount = 0;
                int columnCount = 0;
                // 選択されている行の件数分、繰り返す 
                foreach (CellRange cellRange in cellRangeArray)
                {
                    rowCount = rowCount + cellRange.RowCount;
                    columnCount = columnCount + cellRange.ColumnCount;
                }
                // 複数選択している場合 
                if (columnCount > 1 || rowCount > 1)
                {
                    // 選択行の先頭 
                    return cellRangeArray[0].Row;
                }
            }
            // 全体の先頭 
            return 0;
        }

        /// <summary>
        /// 複数データ選択の判定 
        /// </summary>
        private bool isMultiDataSelection()
        {
            // 選択されている行を取得 
            CellRange[] cellRangeArray = _spdDetailInput_Sheet1.GetSelections();

            if (cellRangeArray.Length > 0)
            {
                int rowCount = 0;
                int columnCount = 0;
                // 選択されている行の件数分、繰り返す 
                foreach (CellRange cellRange in cellRangeArray)
                {
                    rowCount = rowCount + cellRange.RowCount;
                    columnCount = columnCount + cellRange.ColumnCount;
                }
                // 複数選択している場合 
                if (columnCount > 1 || rowCount > 1)
                {
                    return true;
                }
            }
            return false;
        }

        # endregion メソッド 
    }
}