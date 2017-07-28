using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Lion.ProcessController.Detail;

namespace Isid.KKH.Lion.View.Detail
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FindLionCodeItr : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        private FindLionCodeItrNaviParameter _naviParameter = new FindLionCodeItrNaviParameter();

        //カラムインデックス const
        /// <summary>
        /// コード 
        /// </summary>
        private const int COLIDX_1 = 0;
        /// <summary>
        /// 名称 
        /// </summary>
        private const int COLIDX_2 = 1;
        /// <summary>
        /// 系列・スペースコード 
        /// </summary>
        private const int COLIDX_3 = 2;
        /// <summary>
        /// スペース名 
        /// </summary>
        private const int COLIDX_4 = 3;
        /// <summary>
        /// 料金
        /// </summary>
        private const int COLIDX_5 = 4;


        #region コンストラクタ
        /// <summary>
        /// 
        /// </summary>
        public FindLionCodeItr()
        {
            InitializeComponent();
        }
        #endregion コンストラクタ

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void FindLionCodeItr_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is FindLionCodeItrNaviParameter)
            {
                _naviParameter = (FindLionCodeItrNaviParameter)arg.NaviParameter;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindLionCodeItr_Load(object sender, EventArgs e)
        {
            DetailLionProcessController.FindLionCodeItrParam param = new DetailLionProcessController.FindLionCodeItrParam();
            param.esqId = _naviParameter.strEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;

            String cdno = _naviParameter.CdNo;
            String btCD = _naviParameter.BtCd;

            //実行 
            DetailLionProcessController processController = DetailLionProcessController.GetInstance();
            FindLionCodeItrServiceResult result = processController.FindLionCodeItrService(cdno, btCD, param);
            this.kkhSpread1_Sheet1.RowCount = result.CILionDataSet.KkhCodeItr.Count;


            if (cdno == "001" || cdno == "002" || cdno == "003" || cdno == "004" || cdno == "005" || cdno == "016")
            {
                for (int i = 0; i < result.CILionDataSet.KkhCodeItr.Count; i++)
                {
                    kkhSpread1_Sheet1.Cells[i, COLIDX_1].Text = String.Format("{0:000}", result.CILionDataSet.KkhCodeItr[i].VAL1);
                    kkhSpread1_Sheet1.Cells[i, COLIDX_2].Text = result.CILionDataSet.KkhCodeItr[i].VAL2;
                    kkhSpread1_Sheet1.Cells[i, COLIDX_3].Text = result.CILionDataSet.KkhCodeItr[i].VAL3;
                    kkhSpread1_Sheet1.ColumnCount = 3;
                    kkhSpread1_Sheet1.SetColumnLabel(0, 2, "系列");
                }
            }
            else if (cdno == "008")
            {
                for (int i = 0; i < result.CILionDataSet.KkhCodeItr.Count; i++)
                {
                    kkhSpread1_Sheet1.Cells[i, COLIDX_1].Text = String.Format("{0:000}", result.CILionDataSet.KkhCodeItr[i].VAL1);
                    kkhSpread1_Sheet1.Cells[i, COLIDX_2].Text = result.CILionDataSet.KkhCodeItr[i].VAL2;
                    kkhSpread1_Sheet1.Cells[i, COLIDX_3].Text = result.CILionDataSet.KkhCodeItr[i].VAL3;
                    kkhSpread1_Sheet1.Cells[i, COLIDX_4].Text = result.CILionDataSet.KkhCodeItr[i].VAL4;
                    kkhSpread1_Sheet1.Cells[i, COLIDX_5].Text = result.CILionDataSet.KkhCodeItr[i].INTVALUE1;
                }
            }
            else
            {
                for (int i = 0; i < result.CILionDataSet.KkhCodeItr.Count; i++)
                {
                    kkhSpread1_Sheet1.Cells[i, COLIDX_1].Text = String.Format("{0:000}", result.CILionDataSet.KkhCodeItr[i].VAL1);
                    //kkhSpread1_Sheet1.Cells[i, COLIDX_1].Text = result.CILionDataSet.KkhCodeItr[i].VAL1;
                    kkhSpread1_Sheet1.Cells[i, COLIDX_2].Text = result.CILionDataSet.KkhCodeItr[i].VAL2;
                    kkhSpread1_Sheet1.ColumnCount = 2;
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
        private void OK_Click(object sender, EventArgs e)
        {
            int i = kkhSpread1_Sheet1.ActiveRowIndex;
            _naviParameter.Cd = kkhSpread1_Sheet1.Cells[i, COLIDX_1].Text;
            _naviParameter.Name = kkhSpread1_Sheet1.Cells[i, COLIDX_2].Text;

            String cdno = _naviParameter.CdNo;
            if (cdno == "001" 
                || cdno == "002" 
                || cdno == "003" 
                || cdno == "004" 
                || cdno == "005" 
                || cdno == "016" )
            {
                _naviParameter.Krt = kkhSpread1_Sheet1.Cells[i, COLIDX_3].Text;
            }
            else if (cdno == "008")
            {
                _naviParameter.SpCd = kkhSpread1_Sheet1.Cells[i, COLIDX_3].Text;
                _naviParameter.SpName = kkhSpread1_Sheet1.Cells[i, COLIDX_4].Text;
                _naviParameter.Ryokin = kkhSpread1_Sheet1.Cells[i, COLIDX_5].Text;
            }
            //else if(cdno == "017")
            //{
            //    _naviParameter.Cd = kkhSpread1_Sheet1.Cells[i, COLIDX_1].Text;
            //    _naviParameter.Name = kkhSpread1_Sheet1.Cells[i, COLIDX_2].Text;
            //}
            //Navigator.Backward(this, _naviParameter, nulls, true);
            Navigator.Backward(this, null, _naviParameter, true);
            this.Close();
        }

        private void CAN_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
            this.Close();
        }

        private void kkhSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            int i = kkhSpread1_Sheet1.ActiveRowIndex;
            _naviParameter.Cd = kkhSpread1_Sheet1.Cells[i, COLIDX_1].Text;
            _naviParameter.Name = kkhSpread1_Sheet1.Cells[i, COLIDX_2].Text;

            String cdno = _naviParameter.CdNo;
            if (cdno == "001"
                || cdno == "002"
                || cdno == "003"
                || cdno == "004"
                || cdno == "005"
                || cdno == "016")
            {
                _naviParameter.Krt = kkhSpread1_Sheet1.Cells[i, COLIDX_3].Text;
            }
            else if (cdno == "008")
            {
                _naviParameter.SpCd = kkhSpread1_Sheet1.Cells[i, COLIDX_3].Text;
                _naviParameter.SpName = kkhSpread1_Sheet1.Cells[i, COLIDX_4].Text;
                _naviParameter.Ryokin = kkhSpread1_Sheet1.Cells[i, COLIDX_5].Text;
            }
            //else if(cdno == "017")
            //{
            //    _naviParameter.Cd = kkhSpread1_Sheet1.Cells[i, COLIDX_1].Text;
            //    _naviParameter.Name = kkhSpread1_Sheet1.Cells[i, COLIDX_2].Text;
            //}
            //Navigator.Backward(this, _naviParameter, nulls, true);
            Navigator.Backward(this, null, _naviParameter, true);
            this.Close();
        }
    }
}