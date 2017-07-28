using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Lion.Utility;

namespace Isid.KKH.Lion.View.Detail
{
    /// <summary>
    /// �ꊇ�o�^�_�C�A���O�iLION�j
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
    ///       <description>2012/02/20</description>
    ///       <description></description>
    ///       <description>�V�K�쐬</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class DetailLionBulkRegister : Isid.KKH.Common.KKHView.Common.Form.KKHDialogBase
    {
        private DetailLionBulkRegisterNaviParameter _naviParameter;

        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        public DetailLionBulkRegister()
        {
            InitializeComponent();
        }


        private void DetailBulkRegister_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter != null)
            {
                if (arg.NaviParameter is DetailLionBulkRegisterNaviParameter)
                {
                    _naviParameter = (DetailLionBulkRegisterNaviParameter)arg.NaviParameter;
                }
            }
        }

        private void DetailLionBulkRegister_Load(object sender, EventArgs e)
        {
            //�u�����h�̐ݒ� 
            MasterMaintenanceProcessController proccessController = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result = proccessController.FindMasterByCond(
                                                                    _naviParameter.strEsqId
                                                                    , _naviParameter.strEgcd
                                                                    , _naviParameter.strTksKgyCd
                                                                    , _naviParameter.strTksBmnSeqNo
                                                                    , _naviParameter.strTksTntSeqNo
                                                                    , KKHLionConst.C_MAST_BRAND_CD
                                                                    , ""
                                                                );
            MasterMaintenance.MasterDataVODataTable dtBrandMstData = result.MasterDataSet.MasterDataVO;

            //DataSource�pDataTable�̍쐬 
            DataTable dtBrandComboData = new DataTable("BrandCombo");
            dtBrandComboData.Columns.Add("name", typeof(String));
            dtBrandComboData.Columns.Add("value", typeof(String));
            //DataSource�pDataTable�Ƀf�[�^���Z�b�g 
            dtBrandComboData.Rows.Add(dtBrandComboData.NewRow());//��s���ŏ��ɒǉ� 
            foreach (MasterMaintenance.MasterDataVORow row in result.MasterDataSet.MasterDataVO.Rows)
            {
                dtBrandComboData.Rows.Add(row.Column1 + " " + row.Column2, row.Column1);
            }

            //�f�[�^�\�[�X�ɐݒ� 
            cmbBrand.DisplayMember = "name";
            cmbBrand.ValueMember = "value";
            cmbBrand.DataSource = dtBrandComboData;

            //�R���g���[���𖢑I����Ԃɂ��� 
            this.ActiveControl = null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            DetailLionBulkRegisterNaviParameter naviParameterOut = new DetailLionBulkRegisterNaviParameter();
            if (cmbBrand.SelectedValue == null || cmbBrand.SelectedValue == DBNull.Value)
            {
                Navigator.Backward(this, null, null, true);
            }
            else
            {
                naviParameterOut.BrandCd = (string)cmbBrand.SelectedValue;
                Navigator.Backward(this, naviParameterOut, null, true);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Navigator.Backward(this, null, null, true);
        }

    }
}

