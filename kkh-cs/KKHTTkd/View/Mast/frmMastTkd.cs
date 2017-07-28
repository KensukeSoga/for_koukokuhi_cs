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
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;

namespace Isid.KKH.Tkd.View.Mast
{
    public partial class frmMastTkd : MastForm, INaviParameter
    {
        #region �����o�ϐ�
        /// <summary>
        /// �i�r�p�����[�^�[
        /// </summary>
        KKHNaviParameter mstNavPrm = new KKHNaviParameter();
        
        /// <summary>
        /// �����ރR�[�h
        /// </summary>
        string[] buruiCd;

        /// <summary>
        /// �����ޖ�
        /// </summary>
        string[] bunruiNM;

        /// <summary>
        /// 
        /// </summary>
        private const int TYUCOLINDEX = 11;

        /// <summary>
        /// dataModelChange�C�x���g 
        /// </summary>
        DefaultSheetDataModel dataModel;

        #endregion �����o�ϐ�

        #region �R���X�g���N�^

        public frmMastTkd()
        {
            InitializeComponent();
        }

        #endregion �R���X�g���N�^

        #region �C�x���g

        /// <summary>
       /// ��ʑJ�ڂ��邽�тɔ���
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="arg"></param>
        private void frmMastAsh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            mstNavPrm = (KKHNaviParameter)arg.NaviParameter;

        }

        /// <summary>
        /// �V�K�{�^���N���b�N(�ꎞ�Ή�)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCrt_Click(object sender, EventArgs e)
        {
            //TODO
            if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field2.Equals("203"))
            {
                //�V�K�ǉ������s�B
                int Acrow = spdMasMainte_Sheet1.ActiveRowIndex;
                //���ݑI������Ă���t�B���^�[�̃C���f�b�N�X
                int SelectFileterRow = cmdMasterName2.SelectedIndex;
                ComboBoxCellType cm 
                    = new ComboBoxCellType((ComboBoxCellType)spdMasMainte_Sheet1.Columns[TYUCOLINDEX].CellType);
                //string tex = cm.Items[SelectFileterRow].ToString();
                spdMasMainte_Sheet1.Cells[Acrow, TYUCOLINDEX].Text = cm.Items[SelectFileterRow].ToString();
            }
        }

        /// <summary>
        /// Load�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMastTkd_Load(object sender, EventArgs e)
        {
            dataModel = (DefaultSheetDataModel)spdMasMainte.ActiveSheet.Models.Data;
            dataModel.Changed += new SheetDataModelEventHandler(this.dataModel_Changed);
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

        #endregion �C�x���g

        #region ���\�b�h

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="cmbtyp"></param>
        /// <param name="ColIndex"></param>
        /// <param name="RowCount"></param>
        /// <param name="kokuKbnArr"></param>
        protected override void SpreadSettingCombo(MasterMaintenance.MasterItemVORow row, 
            FarPoint.Win.Spread.CellType.ComboBoxCellType cmbtyp, int ColIndex, int RowCount, string[] kokuKbnArr)
        {
            if (row.field19.Equals("0004"))
            {
                MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = controller.FindMasterByCond
                (
                    KKHSecurityInfo.GetInstance().UserEsqId,
                    mstNavPrm.strEgcd,
                    mstNavPrm.strTksKgyCd,
                    mstNavPrm.strTksBmnSeqNo,
                    mstNavPrm.strTksTntSeqNo,
                    "0004",
                    null
                );

                if (result.HasError)
                {
                    return;
                }

                MasterMaintenance mstds = result.MasterDataSet;
                MasterMaintenance.MasterDataVORow[] mstrows
                    = (MasterMaintenance.MasterDataVORow[])mstds.MasterDataVO.Select("", "");

                String[] tybunruiCd = new String[mstrows.Length];
                String[] tybunruiNM = new String[mstrows.Length];

                for (int i = 0; i < mstrows.Length; i++)
                {
                    tybunruiNM[i] = mstrows[i].Column2;
                    tybunruiCd[i] = mstrows[i].Column1;
                }

                bunruiNM = tybunruiNM;
                buruiCd = tybunruiCd;
                cmbtyp.Items = tybunruiNM;
                cmbtyp.ItemData = tybunruiCd;

                for (int i = 0; i < RowCount; i++)
                {
                    if (spdMasMainte_Sheet1.Cells[i, ColIndex].Value == null)
                    {
                        //���ꂢ��H 
                        //spdMasMainte_Sheet1.Cells[i, ColIndex].Value = "�V��";
                        continue;
                    }
                    Boolean flg = false;

                    for (int j = 0; j < cmbtyp.Items.Length; j++)
                    {
                        if (spdMasMainte_Sheet1.Cells[i, ColIndex].Value.Equals(cmbtyp.Items[j]))
                        {
                            flg = true;
                            break;
                        }
                    }

                    if (flg) { continue; }

                    flg = false;
                    for (int j = 0; j < cmbtyp.ItemData.Length; j++)
                    {
                        if (spdMasMainte_Sheet1.Cells[i, ColIndex].Value.Equals(cmbtyp.ItemData[j]))
                        {
                            spdMasMainte_Sheet1.Cells[i, ColIndex].Value = cmbtyp.Items[j];
                            flg = true;
                            break;
                        }
                    }

                    //���ꂢ��H 
                    //if (!flg) { spdMasMainte_Sheet1.Cells[i, ColIndex].Value = "�V��"; }
                }
            }
            else
            {
                base.SpreadSettingCombo(row, cmbtyp, ColIndex, RowCount, kokuKbnArr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="Count"></param>
        protected override void MstDataUpdateCombo(MasterMaintenance.MasterItemVORow row, int Count)
        {
            if (row.field19.Equals("0004"))
            {
                for (int i = 0; i < Count; i++)
                {
                    if (spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2)].Value == null)
                    {
                        continue;
                    }

                    for (int j = 0; j < buruiCd.Length; j++)
                    {
                        if (spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2)].Value.Equals(bunruiNM[j]))
                        {
                            spdMasMainte_Sheet1.Cells[i, int.Parse(row.field2)].Value = buruiCd[j];
                            break;
                        }
                    }
                }
            }
            else
            {
                base.MstDataUpdateCombo(row, Count);
            }
        }

        /// <summary>
        /// ���̓`�F�b�N
        /// </summary>
        /// <returns></returns>
        protected override bool MstChk()
        {
            if (!base.MstChk()) { return false; }

            // ����Ń}�X�^�[�̎��̂݃`�F�b�N���s��
            if( String.Equals(mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3, "0003") )
            {
                for (int i = 0; i < spdMasMainte_Sheet1.Rows.Count; i++)
                {
                    if ((spdMasMainte_Sheet1.Cells[i, 11].Text.Length != 8)
                        || (!KKHUtility.IsDate(spdMasMainte_Sheet1.Cells[i, 11].Text, "yyyyMMdd")))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0039, null, "�}�X�^�����e�i���X",
                            MessageBoxButtons.OK);
                        return false;
                    }

                    if ((spdMasMainte_Sheet1.Cells[i, 12].Text.Length != 8)
                        || (!KKHUtility.IsDate(spdMasMainte_Sheet1.Cells[i, 12].Text, "yyyyMMdd")))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0039, null, "�}�X�^�����e�i���X",
                            MessageBoxButtons.OK);
                        return false;
                    }


                    //�J�n���t���I�����t�̏ꍇ�A�G���[�Ƃ��� 
                    if (KKHUtility.StringCnvDateTime(spdMasMainte_Sheet1.Cells[i, 11].Text).CompareTo(KKHUtility.StringCnvDateTime(spdMasMainte_Sheet1.Cells[i, 12].Text)) == 1)
                    {
                        //�G���[ 
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0156, null, "�}�X�^�����e�i���X",
                            MessageBoxButtons.OK);
                        return false;
                    }
                }

            }

            // �����ޕR�t���}�X�^�[�̎��̂݃`�F�b�N���s��
            if (mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3.Trim() == "0005")
            {
                //[�Ɩ��敪]��Index
                int gyomColIdx = -1;
                //[�^�C���X�|�b�g]��Index
                int tsColIdx = -1;

                //[�Ɩ��敪][�^�C���X�|�b�g�敪]���Index���擾���� 
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
        /// dataModel_Changed(�y�[�X�g�΍�) 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataModel_Changed(object sender, SheetDataModelEventArgs e)
        {
            int gyomColIdx = -1; //[�Ɩ��敪]��Index
            int kokuColIdx = -1; //[���ۋ敪]��Index
            int tsColIdx = -1;   //[�^�C���X�|�b�g]��Index

            // �����ޕR�t���}�X�^�[�̏ꍇ�A�������s��
            if (cmbMasterName1.Text == "�����ޕR�t���}�X�^�[")
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

        #endregion ���\�b�h
    }
}
