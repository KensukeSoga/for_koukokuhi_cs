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
using Isid.KKH.Epson.Utility;

namespace Isid.KKH.Epson.View.Mast
{
    /// <summary>
    /// �}�X�^�����e�i���X��ʁi�G�v�\���j
    /// </summary>
    /// <remarks>
    ///   �C���Ǘ�
    ///   <list type="table">
    ///     <listheader>
    ///       <description>���t</description>
    ///       <description>�C����</description>
    ///       <description>���e</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/03/06</description>
    ///       <description>IP Shimizu</description>
    ///       <description>�V�K�쐬</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class frmMastEpson : MastForm, INaviParameter
    {
        #region �����o�ϐ�

        /// <summary>
        /// �}�X�^�����e��ʃi�r�p�����[�^
        /// </summary>
        KKHNaviParameter mstNavPrm = new KKHNaviParameter();

        #endregion �����o�ϐ�

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public frmMastEpson()
        {
            InitializeComponent();
        }

        #endregion �R���X�g���N�^

        #region �C�x���g

        /// <summary>
        /// �}�X�^�����e��ʑJ�ڎ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmMastEpson_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            mstNavPrm = (KKHNaviParameter)arg.NaviParameter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMastEpson_Load(object sender, EventArgs e)
        {
            RowUpBtn.Enabled = true;
            RowUpBtn.Visible = true;
            RowDownBtn.Enabled = true;
            RowDownBtn.Visible = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMasterName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMasterName1.SelectedIndex == cmbMasterName1.Items.Count - 2 || cmbMasterName1.SelectedIndex == cmbMasterName1.Items.Count - 1)
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
        #endregion �C�x���g

        # region ���\�b�h

        /// <summary>
        /// �ʃ`�F�b�N 
        /// </summary>
        /// <returns></returns>
        protected override bool MstChk()
        {
            if (!base.MstChk()) { return false; }

            // ������ʏ��}�X�^�̏ꍇ�̂݃`�F�b�N���s��
            if (String.Equals(mstDtSet.MasterDataSet.MasterKindVO[cmbMasterName1.SelectedIndex].field3, KkhConstEpson.MasterKey.TRISIKI))
            {
                for (int i = 0; i < spdMasMainte_Sheet1.Rows.Count; i++)
                {
                    if (spdMasMainte_Sheet1.Cells[i, 11].Value == null)
                    {
                        continue;
                    }

                    String value1 = spdMasMainte_Sheet1.Cells[i, 11].Value.ToString();

                    for (int j = ( i + 1 ); j < spdMasMainte_Sheet1.Rows.Count; j++)
                    {
                        if (spdMasMainte_Sheet1.Cells[j, 11].Value == null)
                        {
                            continue;
                        }

                        String value2 = spdMasMainte_Sheet1.Cells[j, 11].Value.ToString();

                        if (String.Equals(value1, value2))
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0147, new String[] { value1 }, "�}�X�^�����e�i���X", MessageBoxButtons.OK);

                            return false;
                        }
                    }
                }
            }

            return true;
        }

        # endregion


    }
}

