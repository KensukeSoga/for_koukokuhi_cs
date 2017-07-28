using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Mast;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility;
using Isid.NJ.View.Navigator;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using Isid.KKH.Common.KKHUtility.Constants;

namespace Isid.KKH.Uni.View.Mast
{
    public partial class frmMastUni : MastForm, INaviParameter
    {
        # region �����o�ϐ�
        
        /// <summary>
        /// 
        /// </summary>
        KKHNaviParameter mstNavPrm = new KKHNaviParameter();
        
        # endregion

        # region �R���X�g���N�^

        public frmMastUni()
        {
            InitializeComponent();
        }
        
        # endregion

        #region �I�[�o�[���C�h

        /// <summary>
        /// �}�X�^�R���{�N���b�N���I�[�o�[���C�h 
        /// </summary>
        protected override void MastCmbClick()
        {
            base.MastCmbClick();

            //�e���r�^�C���@���z�ԑg�����}�X�^�̏ꍇ 
            if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3 == "0001")
            {
                for (int i = 0; i < spdMasMainte_Sheet1.Columns.Count; i++)
                {
                    // ���z���ڂ�3����؂�ɂ��� 
                    NumberCellType cellType = (NumberCellType)spdMasMainte_Sheet1.Columns[12].CellType;
                    cellType.ShowSeparator = true;

                    // ���z���ڂ�3����؂�ɂ��� 
                    NumberCellType cellType2 = (NumberCellType)spdMasMainte_Sheet1.Columns[13].CellType;
                    cellType2.ShowSeparator = true;

                }
            }
            
        }
        #endregion �I�[�o�[���C�h

        # region �C�x���g 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmMastUni_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            mstNavPrm = (KKHNaviParameter)arg.NaviParameter;
        }

        /// <summary>
        /// �`�F���W�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdMasMainte_Change(object sender, ChangeEventArgs e)
        {
            if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].sybt.Equals(MST_KIND_SYBT) 
                || mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].sybt.Equals(MST_ITME_SYBT))
            { 
                return;
            }

            //�\�����̏ꍇ�擪��0��t����
            if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3 == "0001")
            {
                foreach (MasterMaintenance.MasterItemVORow row in mstDtSet.MasterDataSet.MasterItemVO.Select("", ""))
                {
                    if (row.field3.Equals("�\����"))
                    {
                        if (row.field2.Equals(e.Column.ToString()))
                        {
                            if (spdMasMainte.Sheets[0].Cells[e.Row, e.Column].Text.Length == 1)
                            {
                                spdMasMainte.Sheets[0].Cells[e.Row, e.Column].Text = "0" + spdMasMainte.Sheets[0].Cells[e.Row, e.Column].Text;
                            }
                            return;
                        }
                    }
                }
            }

            //[�l����P��]���v�Z���� 
            CalcNbkgTnk();
        }

        # endregion

        # region ���\�b�h

        /// <summary>
        /// [�l����P��]���v�Z���� 
        /// </summary>
        private void CalcNbkgTnk()
        {
            int nbkgMonColIdx = -1;
            int nbkgTnkColIdx = -1;

            //[�l���㌎�z]���Index���擾���� 
            for (int i = 0; i < spdMasMainte_Sheet1.ColumnCount; i++)
            {
                if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "�l���㌎�z")
                {
                    nbkgMonColIdx = i;
                }
                else if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "�l����P��")
                {
                    nbkgTnkColIdx = i;
                }
            }

            //[�l���㌎�z]��̏ꍇ�A[�l����P��]���v�Z���� 
            if (spdMasMainte_Sheet1.ActiveColumnIndex == nbkgMonColIdx)
            {
                if (!string.IsNullOrEmpty(spdMasMainte_Sheet1.ActiveCell.Text))
                {
                    decimal nbkgMonAmt = KKHUtility.DecParse(spdMasMainte_Sheet1.ActiveCell.Text);
                    decimal nbkgTnkAmt = decimal.Truncate(decimal.Truncate((nbkgMonAmt * 3M) / 13M) * 0.97M);
                    spdMasMainte_Sheet1.Cells[spdMasMainte_Sheet1.ActiveRowIndex, nbkgTnkColIdx].Text = nbkgTnkAmt.ToString();
                }
            }
        }

        # endregion

    }
}

