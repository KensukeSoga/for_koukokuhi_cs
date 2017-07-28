using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Log;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Mast;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Lion.ProcessController.Detail;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Lion.Utility;

namespace Isid.KKH.Lion.View.Detail
{
    public partial class DetailUpdateSubject : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        #region 定数 

        /// <summary>
        /// アプリID
        /// </summary>
        private const String APLID = "UpdSub";

        //カラムインデックス const

        /// <summary>
        /// 売上明細No.
        /// </summary>
        private const int COLIDX_1 = 0;

        /// <summary>
        /// 請求年月 
        /// </summary>
        private const int COLIDX_2 = 1;

        /// <summary>
        /// 業務区分 
        /// </summary>
        private const int COLIDX_3 = 2;

        /// <summary>
        /// 件名 
        /// </summary>
        private const int COLIDX_4 = 3;

        /// <summary>
        /// 費目名 
        /// </summary>
        private const int COLIDX_5 = 4;

        /// <summary>
        /// 局誌名 
        /// </summary>
        private const int COLIDX_6 = 5;

        /// <summary>
        /// 請求金額 
        /// </summary>
        private const int COLIDX_7 = 6;

        /// <summary>
        /// 通常時のセル色
        /// </summary>
        private static readonly Color CELL_COLOR_NORMAL = Color.FromArgb( 255, 255, 255, 255 );

        /// <summary>
        /// 入力エラー時のセル色
        /// </summary>
        private static readonly Color CELL_COLOR_ERROR = Color.FromArgb( 255, 255, 160, 160 );

        #endregion 定数 

        #region メンバ変数

        private DetailUpdateSubjectNaviParameter _naviParam = new DetailUpdateSubjectNaviParameter();

        #endregion メンバ変数

        # region コンストラクタ 

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public DetailUpdateSubject()
        {
            InitializeComponent();
        }

        # endregion コンストラクタ 

        # region イベント

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void DetailTenpoItr_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is DetailUpdateSubjectNaviParameter)
            {
                _naviParam = (DetailUpdateSubjectNaviParameter)arg.NaviParameter;
                this.kkhSpread1_Sheet1.RowCount = _naviParam.DataRow.Length;
                for (int i = 0; i < _naviParam.DataRow.Length ; i++)
                {
                    kkhSpread1_Sheet1.Cells[i, COLIDX_1].Text = _naviParam.DataRow[i].hb1JyutNo + "-"
                                     + _naviParam.DataRow[i].hb1JyMeiNo + "-" + _naviParam.DataRow[i].hb1UrMeiNo;
                    kkhSpread1_Sheet1.Cells[i, COLIDX_2].Text = _naviParam.DataRow[i].hb1Yymm;
                    kkhSpread1_Sheet1.Cells[i, COLIDX_3].Text = _naviParam.DataRow[i].hb1GyomKbn;
                    kkhSpread1_Sheet1.Cells[i, COLIDX_4].Text = _naviParam.DataRow[i].hb1KKNameKJ;
                    kkhSpread1_Sheet1.Cells[i, COLIDX_5].Text = _naviParam.DataRow[i].hb1HimkNmKJ;
                    kkhSpread1_Sheet1.Cells[i, COLIDX_6].Text = _naviParam.DataRow[i].hb1Field2;
                    kkhSpread1_Sheet1.Cells[i, COLIDX_7].Text = _naviParam.DataRow[i].hb1SeiGak.ToString();
                }
            }

            //コントロールを未選択状態にする 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCan_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if( CheckBeforeUpdateSubject())
            {
                this.ActiveControl = null;
                return;
            }

            // 件名変更確認 
            if (MessageUtility.ShowMessageBox(MessageCode.HB_C0015,
                null,
                "件名変更",
                MessageBoxButtons.YesNo) == DialogResult.No)
            {
                this.ActiveControl = null;
                return;
            }

            DetailLionProcessController detailprocesscontroller = DetailLionProcessController.GetInstance();

            for (int i = 0; i < _naviParam.DataRow.Length; i++)
            {
                if (kkhSpread1_Sheet1.Cells[i, COLIDX_4].Text != _naviParam.DataRow[i].hb1KKNameKJ)
                {
                    _naviParam.DataRow[i].hb1KKNameKJ = kkhSpread1_Sheet1.Cells[i, COLIDX_4].Text;
                }
            }
            UpdateSubjectDataServiceResult result = detailprocesscontroller.UpdateSubjectData(_naviParam.DataRow);

            // オペレーションログの出力 
            KKHLogUtilityLion.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityLion.KINO_ID_OPERATION_LOG_UPDSUBJECT, KKHLogUtilityLion.DESC_OPERATION_LOG_UPDSUBJECT);

            Navigator.Backward(this, result, null, true);
        }

        /// <summary>
        /// スプレッド内容変更時 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kkhSpread1_Change(object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            switch (e.Column)
            {
                case 3:       //件名                     
                    if (!string.IsNullOrEmpty(kkhSpread1_Sheet1.Cells[e.Row, e.Column].Text))
                    {
                        //60byteまで入力可
                        System.Text.Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");
                        FarPoint.Win.Spread.CellType.TextCellType tCell = (FarPoint.Win.Spread.CellType.TextCellType)kkhSpread1_Sheet1.GetCellType(e.Row, e.Column);
                        string s = kkhSpread1_Sheet1.GetValue(e.Row, e.Column).ToString();
                        if (enc.GetByteCount(s) > 60)
                        {
                            char[] chrs = enc.GetChars(enc.GetBytes(s), 0, 60);
                            s = enc.GetString(enc.GetBytes(chrs));
                            kkhSpread1_Sheet1.SetValue(e.Row, e.Column, s);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        # endregion イベント 

        # region メソッド 

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckBeforeUpdateSubject()
        {
            // セル色の初期化
            for (int i = 0; i < _naviParam.DataRow.Length; i++)
            {
                kkhSpread1_Sheet1.Cells[i, COLIDX_4].BackColor = CELL_COLOR_NORMAL;
            }

            for (int i = 0; i < _naviParam.DataRow.Length; i++)
            {
                if (kkhSpread1_Sheet1.Cells[i, COLIDX_4].Text != _naviParam.DataRow[i].hb1KKNameKJ)
                {
                    if (kkhSpread1_Sheet1.Cells[i, COLIDX_4].Text.IndexOf("'") != -1)
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0123, null, "件名変更", MessageBoxButtons.OK);

                        kkhSpread1_Sheet1.SetActiveCell(i, COLIDX_4);

                        kkhSpread1_Sheet1.ActiveCell.BackColor = CELL_COLOR_ERROR;

                        return true;
                    }

                    if (String.Equals(kkhSpread1_Sheet1.Cells[i, COLIDX_4].Text, ""))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0029, null, "件名変更", MessageBoxButtons.OK);

                        kkhSpread1_Sheet1.SetActiveCell(i, COLIDX_4);

                        kkhSpread1_Sheet1.ActiveCell.BackColor = CELL_COLOR_ERROR;

                        return true;
                    }
                }
            }

            return false;
        }

        # endregion メソッド 
    }
}
