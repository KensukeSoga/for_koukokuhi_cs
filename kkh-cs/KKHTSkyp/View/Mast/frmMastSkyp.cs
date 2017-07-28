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
using Isid.NJ.View.Navigator;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Constants;
using FarPoint.Win.Spread.Model;

namespace Isid.KKH.Skyp.View.Mast
{
    public partial class frmMastSkyp : MastForm, INaviParameter
    {
        #region �����o�ϐ�

        /// <summary>
        /// �i�r�p�����[�^�[
        /// </summary>
        KKHNaviParameter mstNavPrm = new KKHNaviParameter();

        /// <summary>
        /// dataModelChange�C�x���g 
        /// </summary>
        DefaultSheetDataModel dataModel;

        # endregion

        #region �R���X�g���N�^

        public frmMastSkyp()
        {
            InitializeComponent();
        }

        # endregion

        # region �C�x���g

        /// <summary>
        /// �t�H�[����ʕ\������ 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmMastSkyp_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            mstNavPrm = (KKHNaviParameter)arg.NaviParameter;
        }

        /// <summary>
        /// �^�C���X�|�b�g�敪�`�F�b�N  
        /// </summary>
        /// <returns></returns>
        protected override bool MstChk()
        {
            if (!base.MstChk()) { return false; }

            // ���ރ}�X�^�[�̎��̂݃`�F�b�N���s��
            if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3.Trim() == "0001")
            {
                //[�Ɩ��敪]��Index
                int gyomColIdx = -1;
                //[�^�C���X�|�b�g]��Index
                int tsColIdx = -1;

                //[�Ɩ��敪][�^�C���X�|�b�g�敪]���Index���擾���� 
                for (int i = 0; i < spdMasMainte_Sheet1.Columns.Count; i++)
                {
                    if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label =="�Ɩ��敪")
                    {
                        gyomColIdx = i;
                    }
                    else if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "�^�C���X�|�b�g�敪")
                    {
                        tsColIdx = i;
                    }
                }

                for (int i = 0; i < spdMasMainte_Sheet1.Rows.Count; i++)
                {

                    //���W�I�E�q�����f�B�A�̏ꍇ�̓G���[���b�Z�[�W�i�X�V�s�j 
                    if (spdMasMainte_Sheet1.Cells[i, gyomColIdx].Text.ToString() == "���W�I"
                        || spdMasMainte_Sheet1.Cells[i, gyomColIdx].Text.ToString() == "�q�����f�B�A")
                    {
                            //�^�C���X�|�b�g�敪����̏ꍇ 
                        if (spdMasMainte_Sheet1.Cells[i, tsColIdx].Text.ToString() == "")
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0136, null,
                                "�}�X�^�����e�i���X", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMastSkyp_Load(object sender, EventArgs e)
        {
            dataModel = (DefaultSheetDataModel)spdMasMainte.ActiveSheet.Models.Data;
            dataModel.Changed += new SheetDataModelEventHandler(this.dataModel_Changed);
        }

        /// <summary>
        /// �X�V�{�^������ 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnUpd_Click(object sender, EventArgs e)
        {
            dataModel.Changed -= new SheetDataModelEventHandler(this.dataModel_Changed);
            base.btnUpd_Click(sender, e);
            dataModel.Changed += new SheetDataModelEventHandler(this.dataModel_Changed);
        }

        # endregion �C�x���g 
 
        # region ���\�b�h

        /// <summary>
        /// dataModel_Changed(�y�[�X�g�΍�) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataModel_Changed(object sender, SheetDataModelEventArgs e)
        {
            int gyomColIdx = -1; //[�Ɩ��敪]��Index
            int tsColIdx = -1;   //[�^�C���X�|�b�g]��Index

            //[�Ɩ��敪][���ۋ敪][�^�C���X�|�b�g�敪][�R�[�h]���Index���擾���� 
            for (int i = 0; i < spdMasMainte_Sheet1.Columns.Count; i++)
            {
                if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "�Ɩ��敪")
                {
                    gyomColIdx = i;
                }
                else if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "�^�C���X�|�b�g�敪")
                {
                    tsColIdx = i;
                }
            }
            //[�Ɩ��敪]��̏ꍇ�A�������� 
            if (e.Column == gyomColIdx && gyomColIdx > -1)
            {
                //�Ɩ��敪�����W�I�A�܂��͉q�����f�B�A�̏ꍇ 
                if (spdMasMainte_Sheet1.Cells[e.Row, gyomColIdx].Text.ToString() == "���W�I"
                    || spdMasMainte_Sheet1.Cells[e.Row, gyomColIdx].Text.ToString() == "�q�����f�B�A")
                {
                    if (tsColIdx > -1)
                    {
                        //�^�C���X�|�b�g�敪������ 
                        //�ҏW��  
                        spdMasMainte_Sheet1.Cells[e.Row, tsColIdx].Locked = false;
                        //�w�i�F�� 
                        spdMasMainte_Sheet1.Cells[e.Row, tsColIdx].BackColor = Color.White;
                        //�t�H�[�J�X�� 
                        spdMasMainte_Sheet1.Cells[e.Row, tsColIdx].CanFocus = true;
                        //�l����ɂ���  
                        spdMasMainte_Sheet1.Cells[e.Row, tsColIdx].Value = "";
                    }
                }
                else
                {
                    if (tsColIdx > -1)
                    {
                        //�^�C���X�|�b�g�敪������ 
                        //�ҏW��  
                        spdMasMainte_Sheet1.Cells[e.Row, tsColIdx].Locked = true;
                        //�w�i�F�� 
                        spdMasMainte_Sheet1.Cells[e.Row, tsColIdx].BackColor = Color.Black;
                        //�t�H�[�J�X�� 
                        spdMasMainte_Sheet1.Cells[e.Row, tsColIdx].CanFocus = false;
                        //�l����ɂ���  
                        spdMasMainte_Sheet1.Cells[e.Row, tsColIdx].Value = "";
                    }
                }
            }
        }

        # endregion ���\�b�h 



    }
}

