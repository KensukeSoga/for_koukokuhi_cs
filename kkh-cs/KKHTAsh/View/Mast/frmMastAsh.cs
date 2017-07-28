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
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Ash.Utility;
using FarPoint.Win.Spread.Model;

namespace Isid.KKH.Ash.View.Mast
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmMastAsh : MastForm, INaviParameter
    {
        # region �����o�ϐ�

        KKHNaviParameter mstNavPrm = new KKHNaviParameter();
        //string[] msg = new string[1];

        /// <summary>
        /// dataModelChange�C�x���g 
        /// </summary>
        DefaultSheetDataModel dataModel;

        # endregion

        # region �R���X�g���N�^

        /// <summary>
        /// 
        /// </summary>
        public frmMastAsh()
        {
            InitializeComponent();
        }
        # endregion

        # region �C�x���g
        /// <summary>
       /// ��ʑJ�ڎ�
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="arg"></param>
        private void frmMastAsh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            mstNavPrm = (KKHNaviParameter)arg.NaviParameter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMastAsh_Load(object sender, EventArgs e)
        {
            RowUpBtn.Enabled = true;
            RowUpBtn.Visible = true;
            RowDownBtn.Enabled = true;
            RowDownBtn.Visible = true;

            //�}�X�^���R���{�{�b�N�X�Ƀ��j���[��ʂŉ������ꂽ�}�X�^�{�^�������Z�b�g 
            cmbMasterName1.Text = mstNavPrm.StrValue1;

            dataModel = (DefaultSheetDataModel)spdMasMainte.ActiveSheet.Models.Data;
            dataModel.Changed += new SheetDataModelEventHandler(this.dataModel_Changed);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMasterName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMasterName1.SelectedIndex == cmbMasterName1.Items.Count - 2 
                || cmbMasterName1.SelectedIndex == cmbMasterName1.Items.Count - 1)
            {
                RowUpBtn.Enabled = false;
                RowUpBtn.Visible = false;
                RowDownBtn.Enabled = false;
                RowDownBtn.Visible = false;
            }
            else
            {
                RowUpBtn.Enabled = true;
                RowUpBtn.Visible = true;
                RowDownBtn.Enabled = true;
                RowDownBtn.Visible = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            //�X�v���b�h��������ɐF��t���邽�� 
            this.CfukuCheck();
        }


        # endregion

        # region ���\�b�h

        /// <summary>
        /// dataModel_Changed(�y�[�X�g�΍�) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataModel_Changed(object sender, SheetDataModelEventArgs e)
        {
            int gyomColIdx = -1; //[�Ɩ��敪]��Index
            int kokuColIdx = -1; //[���ۋ敪]��Index
            int tsColIdx = -1;   //[�^�C���X�|�b�g]��Index

            // �}�̃R�[�h�ϊ��}�X�^�[�̏ꍇ�A�������s��
            if (cmbMasterName1.Text == "�}�̃R�[�h�ϊ��}�X�^�[")
            {
                //[�Ɩ��敪][���ۋ敪][�^�C���X�|�b�g�敪][�R�[�h]���Index���擾���� 
                for (int i = 0; i < spdMasMainte_Sheet1.Columns.Count; i++)
                {
                    if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "�Ɩ��敪")
                    {
                        gyomColIdx = i;
                    }
                    else if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "���ۋ敪")
                    {
                        kokuColIdx = i;
                    }
                    else if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "�^�C���X�|�b�g�敪")
                    {
                        tsColIdx = i;
                    }
                }
                //[�Ɩ��敪]��̏ꍇ�A�������� 
                if (e.Column == gyomColIdx && gyomColIdx > -1)
                {
                    if (kokuColIdx > -1)
                    {
                        //[���ۋ敪]��[����]�ɂ��� 
                        spdMasMainte_Sheet1.Cells[e.Row, kokuColIdx].Value = "����";
                    }

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
        }

        # endregion

        # region �I�[�o�[���C�h

        /// <summary>
        /// CfukuCheck���A�T�q�p�ɏC�� 
        /// </summary>
        /// <returns></returns>
        protected override bool CfukuCheck()
        {
            // �}�̃R�[�h�ϊ��}�X�^�[�̎��̂݃`�F�b�N���s��
            if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3 !=
                KkhConstAsh.MasterKey.BAITAI_HENNKAN)
            {
                //return true;
                return base.CfukuCheck();
            }
            int gyomColIdx = -1; //[�Ɩ��敪]��Index
            int kokuColIdx = -1; //[���ۋ敪]��Index
            int tsColIdx = -1;   //[�^�C���X�|�b�g]��Index
            int cdColIdx = -1;   //[�R�[�h]��Index
            string gyomKbn;  //[�Ɩ��敪]
            string kokuKbn;  //[���ۋ敪]
            string tsKbn;    //[�^�C���X�|�b�g]
            string cd;       //[�R�[�h]
            string[] errRowIdx = new string[spdMasMainte_Sheet1.RowCount];    //�d�������s 
            bool errFlg = false;

            //[�Ɩ��敪][���ۋ敪][�^�C���X�|�b�g�敪][�R�[�h]���Index���擾���� 
            for (int i = 0; i < spdMasMainte_Sheet1.Columns.Count; i++)
            {
                if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "�Ɩ��敪")
                {
                    gyomColIdx = i;
                }
                else if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "���ۋ敪")
                {
                    kokuColIdx = i;
                }
                else if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "�^�C���X�|�b�g�敪")
                {
                    tsColIdx = i;
                }
                else if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "�R�[�h")
                {
                    cdColIdx = i;
                }
            }

            //�w�i�������� 
            //�Ɩ��敪 
            if (gyomColIdx > -1)
            {
                for (int i = 0; i < spdMasMainte_Sheet1.RowCount; i++)
                {
                    spdMasMainte_Sheet1.Cells[i, gyomColIdx].BackColor = Color.White;
                }
            }
            //���ۋ敪 
            if (kokuColIdx > -1)
            {
                for (int i = 0; i < spdMasMainte_Sheet1.RowCount; i++)
                {
                    spdMasMainte_Sheet1.Cells[i, kokuColIdx].BackColor = Color.White;
                }
            }
            //�^�C���X�|�b�g�敪 
            if (tsColIdx > -1)
            {
                for (int i = 0; i < spdMasMainte_Sheet1.RowCount; i++)
                {
                    //��̏ꍇ 
                    if (spdMasMainte_Sheet1.Cells[i, tsColIdx].Text == "")
                    {
                        spdMasMainte_Sheet1.Cells[i, tsColIdx].BackColor = Color.Black;
                    }
                    else
                    {
                        spdMasMainte_Sheet1.Cells[i, tsColIdx].BackColor = Color.White;
                    }

                }
            }
            //�R�[�h 
            if (cdColIdx > -1)
            {
                for (int i = 0; i < spdMasMainte_Sheet1.RowCount; i++)
                {
                    spdMasMainte_Sheet1.Cells[i, cdColIdx].BackColor = Color.White;
                }
            }

            for (int i = 0; i < spdMasMainte_Sheet1.RowCount; i++)
            {
                //�l���擾���� 
                if (gyomColIdx > -1)
                {
                    gyomKbn = spdMasMainte_Sheet1.Cells[i, gyomColIdx].Text;
                }
                else
                {
                    break;
                }

                if (kokuColIdx > -1)
                {
                    kokuKbn = spdMasMainte_Sheet1.Cells[i, kokuColIdx].Text;
                }
                else
                {
                    break;
                }

                if (tsColIdx > -1)
                {
                    tsKbn = spdMasMainte_Sheet1.Cells[i, tsColIdx].Text;
                }
                else
                {
                    break;
                }

                if (cdColIdx > -1)
                {
                    cd = spdMasMainte_Sheet1.Cells[i, cdColIdx].Text;
                }
                else
                {
                    break;
                }


                //gyomKbn = gyomColIdx > -1 ? spdMasMainte_Sheet1.Cells[i, gyomColIdx].Text : "";   //�Ɩ��敪 
                //kokuKbn = kokuColIdx > -1 ? spdMasMainte_Sheet1.Cells[i, kokuColIdx].Text : "";   //���ۋ敪  
                //tsKbn = tsColIdx > -1 ? spdMasMainte_Sheet1.Cells[i, tsColIdx].Text : "";   //�^�C���X�|�b�g�敪  
                //cd = cdColIdx > -1 ? spdMasMainte_Sheet1.Cells[i, cdColIdx].Text : "";  //�R�[�h 

                //����̋Ɩ��敪�𒲂ׂ� 
                for (int j = 0; j < spdMasMainte_Sheet1.RowCount; j++)
                {
                    //���̍s�̏ꍇ 
                    if (i != j)
                    {
                        //[�Ɩ��敪]������̒l�̏ꍇ 
                        if (gyomKbn == spdMasMainte_Sheet1.Cells[j, gyomColIdx].Text)
                        {
                            //[���ۋ敪]������̒l�̏ꍇ 
                            if (kokuKbn == spdMasMainte_Sheet1.Cells[j, kokuColIdx].Text)
                            {
                                //[�^�C���X�|�b�g�敪]������̒l�̏ꍇ 
                                if (tsKbn == spdMasMainte_Sheet1.Cells[j, tsColIdx].Text)
                                {
                                    //[�R�[�h]������̒l�̏ꍇ 
                                    if (cd == spdMasMainte_Sheet1.Cells[j, cdColIdx].Text)
                                    {
                                        //�d�������sIndex���擾���� 
                                        errRowIdx[i] = i.ToString();
                                        errRowIdx[j] = j.ToString();

                                        errFlg = true;

                                    }
                                }
                            }
                        }
                    }
                }

                //�d�����Ă���s������ꍇ 
                if (errFlg)
                {
                    for (int k = 0; k < spdMasMainte_Sheet1.RowCount; k++)
                    {
                        if (!string.IsNullOrEmpty(errRowIdx[k]))
                        {
                            //�d�������s�̎擾 
                            int errRow = KKHUtility.IntParse(errRowIdx[k]);
                            
                            //�d�������s��[�}�̃R�[�h]��ȊO�̔w�i�F��ύX���� 
                            spdMasMainte_Sheet1.Cells[errRow, gyomColIdx].BackColor = Color.LightPink;
                            spdMasMainte_Sheet1.Cells[errRow, kokuColIdx].BackColor = Color.LightPink;
                            spdMasMainte_Sheet1.Cells[errRow, tsColIdx].BackColor = Color.LightPink;
                            spdMasMainte_Sheet1.Cells[errRow, cdColIdx].BackColor = Color.LightPink;

                        }
                    }

                    //�d���������̍s���Z�b�g 
                    string[] msg = new string[1] { (i + 1).ToString() };

                    //�G���[���b�Z�[�W��\������ 
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0154, msg,
                        "�}�X�^�����e�i���X", MessageBoxButtons.OK);
                    return false;

                }
            }

            return true;
            
        }

        /// <summary>
        /// �^�C���X�|�b�g�敪�`�F�b�N  
        /// </summary>
        /// <returns></returns>
        protected override bool MstChk()
        {
            if (!base.MstChk()) { return false; }

            // �}�̃R�[�h�ϊ��}�X�^�[�̎��̂݃`�F�b�N���s��
            if( mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3.Trim() == 
                KkhConstAsh.MasterKey.BAITAI_HENNKAN) 
            {
                int gyomColIdx = -1; //[�Ɩ��敪]��Index
                int kokuColIdx = -1; //[���ۋ敪]��Index
                int tsColIdx = -1;   //[�^�C���X�|�b�g]��Index

                //[�Ɩ��敪][���ۋ敪][�^�C���X�|�b�g�敪]���Index���擾���� 
                for (int i = 0; i < spdMasMainte_Sheet1.Columns.Count; i++)
                {
                    if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "�Ɩ��敪")
                    {
                        gyomColIdx = i;
                    }
                    else if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "���ۋ敪")
                    {
                        kokuColIdx = i;
                    }
                    else if (spdMasMainte_Sheet1.ColumnHeader.Columns[i].Label == "�^�C���X�|�b�g�敪")
                    {
                        tsColIdx = i;
                    }
                }


                for (int i = 0; i < spdMasMainte.Sheets[0].Rows.Count; i++)
                {
                    //���W�I�E�q�����f�B�A�̏ꍇ�̓G���[���b�Z�[�W�i�X�V�s�j 
                    if (spdMasMainte_Sheet1.Cells[i, gyomColIdx].Text.ToString() == "���W�I"
                        || spdMasMainte_Sheet1.Cells[i, gyomColIdx].Text.ToString() == "�q�����f�B�A")
                    {
                        //���ۋ敪�������̏ꍇ 
                        if (spdMasMainte_Sheet1.Cells[i, kokuColIdx].Text.ToString() == "����")
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
            }

            return true;
        }

        /// <summary>
        /// �X�V�{�^���N���b�N�� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnUpd_Click(object sender, EventArgs e)
        {
            dataModel.Changed -= new SheetDataModelEventHandler(this.dataModel_Changed);
            base.btnUpd_Click(sender, e);
            dataModel.Changed += new SheetDataModelEventHandler(this.dataModel_Changed);
        }
        # endregion

    }
}

