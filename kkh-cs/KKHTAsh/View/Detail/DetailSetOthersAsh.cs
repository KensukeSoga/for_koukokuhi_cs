using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Ash.Utility;

namespace Isid.KKH.Ash.View.Detail
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DetailSetOthersAsh : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {

        #region メンバ変数
        private Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow _dataRow = null;
        private FarPoint.Win.Spread.SheetView _spdDetailInput_Sheet1 = null;
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        private Encoding _enc = Encoding.GetEncoding("shift-jis");
        #endregion メンバ変数

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public DetailSetOthersAsh()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ

        # region イベント 
        /// <summary>
        /// ＯＫボタンクリックイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //明細件数分、繰り返す 
            for (int i = 0; i < _spdDetailInput_Sheet1.RowCount; i++)
            {
                //期間 
                string kikan = dtpKikanFrom.Value.ToShortDateString().Replace("/", "") +
                                  dtpKikanTo.Value.ToShortDateString().Replace("/", "");
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KEISAIDT].Value = kikan;
                //_spdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KEISAIDT].Value = keisaiDt;
                //媒体コードが交通の場合 
                if (KkhConstAsh.BaitaiCd.KOUTSU.Equals(_naviParam.BaitaiCd) == true)
                {
                    //放送時間、路線名称 
                    _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_HOSOUJIKAN].Value = txtRosenNm.Text.Trim();
                    //_spdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_HOSOUJIKAN].Value = txtRosenNm.Text.Trim();
                }
                else
                {
                    //放送時間、路線名称 
                    _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_HOSOUJIKAN].Value = " ";
                    //_spdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_HOSOUJIKAN].Value = " ";
                }
                //曜日 
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_YOUBI].Value = " ";
                //_spdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_YOUBI].Value = " ";
                //局ネット数 
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KYOKUNETSU].Value = " ";
                //_spdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KYOKUNETSU].Value = " ";
                //キー局 
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KEYKYOKUCD].Value = " ";
                //_spdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KEYKYOKUCD].Value = " ";
                //スペース 
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_SPACE].Value = " ";
                //_spdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_SPACE].Value = " ";
                //朝夕区分 
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_TYOUSEKIKBN].Value = " ";
                //_spdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_TYOUSEKIKBN].Value = " ";
                //掲載版 
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KEISAIBAN].Value = " ";
                //_spdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KEISAIBAN].Value = " ";
                //記雑区分 
                _naviParam.SpdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value = " ";
                //_spdDetailInput_Sheet1.Cells[i, DetailAsh.COLIDX_MLIST_KIZATSUKBN].Value = " ";
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailSetOthersAsh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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
        /// 期間（From）フォーカスアウト 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpKikanFrom_Leave(object sender, EventArgs e)
        {
            //期間（From）＞期間（To）の場合 
            if (dtpKikanFrom.Value > dtpKikanTo.Value)
            {
                // 期間（To）に期間（From）の値を設定 
                dtpKikanTo.Value = dtpKikanFrom.Value;
            }
        }

        /// <summary>
        /// 期間（To）フォーカスアウト 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpKikanTo_Leave(object sender, EventArgs e)
        {
            //期間（From）＞期間（To）の場合 
            if (dtpKikanFrom.Value > dtpKikanTo.Value)
            {
                // 期間（To）に期間（From）の値を設定 
                dtpKikanTo.Value = dtpKikanFrom.Value;
            }
        }

        /// <summary>
        /// 路線・駅名称TextChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRosenNm_TextChanged(object sender, EventArgs e)
        {
            txtRosenNm.Text = KKHUtility.RemoveProhibitionChar(txtRosenNm.Text);
            string str = txtRosenNm.Text;
            int len = txtRosenNm.MaxLength;
            if (_enc.GetByteCount(str) > len)
            {
                str = _enc.GetString(_enc.GetBytes(str), 0, len);
                txtRosenNm.Text = str;
            }
            txtRosenNm.SelectionStart = len;
        }
        # endregion イベント

        # region メソッド 

        /// <summary>
        /// フォームロードイベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailSetOthersAsh_Load(object sender, EventArgs e)
        {
            //各コントロールの初期化 
            InitializeControl();
            //各コントロールの編集 
            editControl();
        }

        /// <summary>
        /// 各コントロールの初期表示処理  
        /// </summary>
        private void InitializeControl()
        {
            //テキストボックス初期化 
            txtRosenNm.Text = "";
        }

        /// <summary>
        /// 各コントロールの編集処理 
        /// </summary>
        private void editControl()
        {
            // 期間（From、To） 
            String strKikan = null;
            strKikan = _spdDetailInput_Sheet1.Cells[0, DetailAsh.COLIDX_MLIST_KEISAIDT].Text.Trim();
            strKikan = strKikan.Replace("年", "").Replace("月", "").Replace("日", "").Replace(" - ", "").Trim();

            if (!String.IsNullOrEmpty(strKikan) && (strKikan.Length == 8 || strKikan.Length == 16))
            {
                String strKikanFrom = strKikan.Substring(0, 8);
                if (KKHUtility.IsDate(strKikanFrom, "yyyyMMdd") == true)
                {
                    dtpKikanFrom.Value = KKHUtility.StringCnvDateTime(strKikanFrom);
                }
                else
                {
                    dtpKikanFrom.Value = KKHUtility.StringCnvDateTime(_dataRow.hb1Yymm.ToString().Trim() + "01");
                }

                String strKikanTo = null;
                if (strKikan.Length == 8)
                {
                    strKikanTo = strKikan.Substring(0, 8);
                }
                else
                {
                    strKikanTo = strKikan.Substring(8, 8);
                }

                if (KKHUtility.IsDate(strKikanTo, "yyyyMMdd") == true)
                {
                    dtpKikanTo.Value = KKHUtility.StringCnvDateTime(strKikanTo);
                }
                else
                {
                    dtpKikanTo.Value = KKHUtility.StringCnvDateTime(_dataRow.hb1Yymm.ToString().Trim() + "01");
                }
            }
            else
            {
                dtpKikanFrom.Value = KKHUtility.StringCnvDateTime(_dataRow.hb1Yymm.ToString().Trim() + "01");
                dtpKikanTo.Value = KKHUtility.StringCnvDateTime(_dataRow.hb1Yymm.ToString().Trim() + "01");
            }

            //媒体コードが交通の場合 
            if (KkhConstAsh.BaitaiCd.KOUTSU.Equals(_naviParam.BaitaiCd) == true)
            {
                //路線・駅名称 
                txtRosenNm.Text = _spdDetailInput_Sheet1.Cells[0, DetailAsh.COLIDX_MLIST_HOSOUJIKAN].Text;
            }
            else
            {
                //路線・駅名称 
                grpRosenNm.Visible = false;
                //フォーム 
                this.Width = 263;
                this.Height = 144;
            }

        }
        # endregion メソッド 



    }
}