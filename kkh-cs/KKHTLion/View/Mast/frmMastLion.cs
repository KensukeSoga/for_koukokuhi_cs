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
using Isid.KKH.Lion.Utility;
using Isid.KKH.Common.KKHUtility.Security;

namespace Isid.KKH.Lion.View.Mast
{
    /// <summary>
    /// ���C�I���}�X�^�Ǘ�.
    /// </summary>
    public partial class frmMastLion : MastForm, INaviParameter
    {

        #region �����o�ϐ�.

        KKHNaviParameter mstNavPrm = new KKHNaviParameter();

        #endregion �����o�ϐ�.

        #region �萔.

        #region �J�����C���f�b�N�X.

        /// <summary>
        /// �R�[�h.
        /// </summary>
        private const int COLIDX_1 = 0;
        /// <summary>
        /// ����.
        /// </summary>
        private const int COLIDX_2 = 1;

        #endregion �J�����C���f�b�N�X.

        /* 2014/07/31 ��r���[�Ή� HLC fujimoto ADD start */
        #region �}�X�^�[�L�[.

        private const string MST_KEY_CATEGORY = "0031";

        #endregion �}�X�^�[�L�[.
        /* 2014/07/31 ��r���[�Ή� HLC fujimoto ADD end */

        #endregion �萔.

        #region �R���X�g���N�^.

        /// <summary>
        /// �R���X�g���N�^.
        /// </summary>
        public frmMastLion()
        {
            InitializeComponent();
        }

        #endregion �R���X�g���N�^.

        #region �C�x���g.

        /// <summary>
        /// �t�H�[��ProcessAffterNavigating�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmMastLion_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is KKHNaviParameter)
            {
                mstNavPrm = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// �t�H�[�����[�h���C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMastLion_Load(object sender, EventArgs e)
        {
            RowUpBtn.Enabled = true;
            RowUpBtn.Visible = true;
            RowDownBtn.Enabled = true;
            RowDownBtn.Visible = true;
            btnKinHen.Visible = false;
        }

        /// <summary>
        /// �}�X�^�[���R���{�{�b�N�X�I�����C�x���g.
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
                btnKinHen.Visible = false; 
            }
            //�G���X�y�[�X�����}�X�^�p�̃{�^����\�� 
            else if (base.mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3 
                == KKHLionConst.C_MAST_ZASSI_CD)
            {
                RowUpBtn.Enabled = true;
                RowUpBtn.Visible = true;
                RowDownBtn.Enabled = true;
                RowDownBtn.Visible = true;
                btnKinHen.Visible = true;
            }
            else
            {
                RowUpBtn.Enabled = true;
                RowUpBtn.Visible = true;
                RowDownBtn.Enabled = true;
                RowDownBtn.Visible = true;
                btnKinHen.Visible = false; 
            }
        }

        /// <summary>
        /// ���z�ҏW(�G��)��ʂ֑J��.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKinHen_Click(object sender, EventArgs e)
        {
            frmMastLionNaviParameter naviParam = new frmMastLionNaviParameter(mstNavPrm);
            int row = spdMasMainte.ActiveSheet.ActiveRowIndex;
            naviParam.Cd = spdMasMainte.ActiveSheet.Cells[row, 11].Text;
            naviParam.Name = spdMasMainte.ActiveSheet.Cells[row, 12].Text;
            naviParam.strName = mstNavPrm.strName;
            naviParam.strDate = mstNavPrm.strDate;
            Navigator.Forward(this, "tofrmMastLionZashiRyoSpc", naviParam);
        }

        /// <summary>
        /// �X�V�{�^���N���b�N�� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnUpd_Click(object sender, EventArgs e)
        {
            if (base.mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3
                == KKHLionConst.C_MAST_SEITIKU_CD)
            {
                MasterMaintenance.MasterDataVODataTable mstDataVo = new MasterMaintenance.MasterDataVODataTable();
                foreach (MasterMaintenance.MasterDataVORow row in (MasterMaintenance.MasterDataVODataTable)spdMasMainte_Sheet1.DataSource)
                {
                    row.Column1 = cmdMasterName2.Text.Substring(0, 2);
                    mstDataVo.ImportRow(row);
                }

                spdMasMainte_Sheet1.DataSource = mstDataVo;
            }

            base.btnUpd_Click(sender, e);
        }

        #endregion �C�x���g.

        #region ���\�b�h.

        /// <summary>
        /// �R���{�{�b�N�X�ݒ�.
        /// </summary>
        /// <param name="row">�}�X�^�[����VODataRow</param>
        /// <param name="cmbtyp">�R���{�{�b�N�X�Z���^�C�v</param>
        /// <param name="ColIndex">��C���f�b�N�X</param>
        /// <param name="RowCount">�s�C���f�b�N�X</param>
        /// <param name="kokuKbnArr">���ۋ敪�p������z��</param>
        protected override void SpreadSettingCombo(MasterMaintenance.MasterItemVORow row,
            FarPoint.Win.Spread.CellType.ComboBoxCellType cmbtyp, int ColIndex, int RowCount, string[] kokuKbnArr)
        {
            /* 2014/07/31 ��r���[�Ή� HLC fujimoto ADD start */
            //0031 �J�e�S���}�X�^�̏ꍇ.
            //��0005 AD�u�����h�}�X�^(�J�e�S��)�Ŏg�p.
            if (row.field19.Equals(MST_KEY_CATEGORY))
            {
                MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = controller.FindMasterByCond
                (
                    KKHSecurityInfo.GetInstance().UserEsqId,
                    mstNavPrm.strEgcd,
                    mstNavPrm.strTksKgyCd,
                    mstNavPrm.strTksBmnSeqNo,
                    mstNavPrm.strTksTntSeqNo,
                    row.field19,
                    null
                );

                if (result.HasError)
                {
                    return;
                }

                MasterMaintenance mstds = result.MasterDataSet;
                MasterMaintenance.MasterDataVORow[] mstrows
                    = (MasterMaintenance.MasterDataVORow[])mstds.MasterDataVO.Select("", "");

                String[] subMasterCd = new String[mstrows.Length];
                String[] subMasterNm = new String[mstrows.Length];

                for (int i = 0; i < mstrows.Length; i++)
                {
                    subMasterCd[i] = mstrows[i].Column1;
                    subMasterNm[i] = mstrows[i].Column2;
                }

                cmbtyp.Items = subMasterNm;
                cmbtyp.ItemData = subMasterCd;
                Boolean flg = false;

                for (int i = 0; i < RowCount; i++)
                {
                    if (spdMasMainte_Sheet1.Cells[i, ColIndex].Value == null)
                    {
                        continue;
                    }

                    //�t���O������.
                    flg = false;

                    for (int j = 0; j < cmbtyp.Items.Length; j++)
                    {
                        if (spdMasMainte_Sheet1.Cells[i, ColIndex].Value.Equals(cmbtyp.Items[j]))
                        {
                            flg = true;
                            break;
                        }
                    }

                    if (flg) 
                    { 
                        continue;
                    }

                    //�t���O������.
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
                }
            }
            else
            {
                base.SpreadSettingCombo(row, cmbtyp, ColIndex, RowCount, kokuKbnArr);
            }
            /* 2014/07/31 ��r���[�Ή� HLC fujimoto ADD end */
        }

        #endregion ���\�b�h.
    }
}

