using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Constants;

namespace Isid.KKH.Tkd.View.Detail
{
    public partial class JyutyuRegisterTkd : Isid.KKH.Common.KKHView.Detail.JyutyuRegister
    {
        #region �萔 

        /// <summary>
        /// ����ŗ��}�X�^�擾�L�[�F0003 
        /// </summary>
        private const string MST_TAX = "0003";

        /// <summary>
        /// ����ŗ� 
        /// </summary>
        private const string DEF_TAX = "5.00";

        #endregion �萔

        #region �����o�ϐ�

        private KKHNaviParameter _naviParameter = new KKHNaviParameter();

        #endregion �����o�ϐ�

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        public JyutyuRegisterTkd()
        {
            InitializeComponent();
        }

        #endregion �R���X�g���N�^ 

        #region �I�[�o�[���C�h 

        /// <summary>
        /// �V�K�o�^�O�̃`�F�b�N���� 
        /// </summary>
        /// <returns>�`�F�b�N����(True�FOK�AFalse�FNG)</returns>
        protected override bool CheckBeforeRegisterJyutyu()
        {
            // ���ʃ`�F�b�N 
            if (!base.CheckBeforeRegisterJyutyu())
            {
                return false;
            }

            // ���Ӑ�ʃ`�F�b�N 
            if (!this.CheckBeforeRegisterJyutyuTkd())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// �V�K�o�^API�̎��s�p�����[�^�̕ҏW���s�� 
        /// </summary>
        /// <returns></returns>
        protected override DetailProcessController.RegisterJyutyuDataParam EditRegisterJyutyuDataParam()
        {
            // ���ʋ@�\�œo�^�f�[�^�̏����ݒ���s�� 
            DetailProcessController.RegisterJyutyuDataParam param = base.EditRegisterJyutyuDataParam();

            //****************************************
            // ���Ӑ�ʂ̐ݒ荀�ڂ�ҏW 
            //****************************************
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow row in param.dsDetail.THB1DOWN.Rows)
            {
                // �Ɩ��敪 
                row.hb1GyomKbn = (string)this.cmbGymKbn.SelectedValue;

                // ���� 
                row.hb1KKNameKJ = this.txtKenmei.Text;

                // �������z 
                row.hb1SeiGak = KKHUtility.DecParse(this.txtKngk.Text);

                // ����ŗ� 
                row.hb1SzeiRitu = KKHUtility.DecParse(this.txtTax.Text);
            }
            param.dsDetail.THB1DOWN.AcceptChanges();

            return param;
        }

        #endregion �I�[�o�[���C�h 

        #region �C�x���g 

        /// <summary>
        /// �t�H�[�����[�h�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JyutyuRegisterTkd_Load(object sender, EventArgs e)
        {
            this.InitializeControl();
        }

        /// <summary>
        /// �������zEnter�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKngk_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtKngk.Text.Trim()))
            {
                this.txtKngk.Text = "0";
            }
            this.txtKngk.SelectionStart = 0;
            this.txtKngk.SelectionLength = this.txtKngk.Text.Length;
        }

        /// <summary>
        /// ����ŗ�Enter�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTax_Enter(object sender, EventArgs e)
        {
            this.txtTax.SelectionStart = 0;
            this.txtTax.SelectionLength = this.txtTax.Text.Length;
        }

        /// <summary>
        /// �������zLeave�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKngk_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtKngk.Text.Trim()))
            {
                this.txtKngk.Text = "0";
            }
        }

        /// <summary>
        /// ����ŗ�Leave�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTax_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTax.Text.Trim()))
            {
                this.txtTax.Text = "0.00";
            }
        }

        #endregion �C�x���g 

        #region ���\�b�h 

        /// <summary>
        /// �e�R���g���[���̏����ݒ� 
        /// </summary>
        private void InitializeControl()
        {
            _naviParameter = base.NaviParameterIn;

            this.cmbGymKbn.Text = string.Empty;
            this.txtKenmei.Text = string.Empty;
            this.txtKngk.Text = "0";
            this.txtTax.Text = this.GetTax();
        }

        /// <summary>
        /// ����ŗ����擾���� 
        /// </summary>
        /// <returns>����ŗ�</returns>
        private string GetTax()
        {
            string ret = DEF_TAX;

            MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result;
            MasterMaintenance ds;
            MasterMaintenance.MasterDataVORow[] rows;

            // ���i���擾 
            result = process.FindMasterByCond(_naviParameter.strEsqId,
                                            _naviParameter.strEgcd,
                                            _naviParameter.strTksKgyCd,
                                            _naviParameter.strTksBmnSeqNo,
                                            _naviParameter.strTksTntSeqNo,
                                            MST_TAX,
                                            null);
            ds = result.MasterDataSet;
            rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                // ����From�Ɗ���To���擾 
                //DateTime now = DateTime.Now;
                //DateTime from = KKHUtility.StringCnvDateTime(row.Column1);
                //DateTime to = KKHUtility.StringCnvDateTime(row.Column2);

                //// ���ԓ��̏���ŗ����g�p���� 
                //if (now.CompareTo(from) > 0 && now.CompareTo(to) < 0)
                //{
                //    ret = row.Column3;
                //    break;
                //}

                // ����From�Ɗ���To���擾 
                String yymm = _naviParameter.StrYymm + "01";
                String from = row.Column1;
                String to = row.Column2;

                // ���ԓ��̏���ŗ����g�p���� 
                if (yymm.CompareTo(from) >= 0 && yymm.CompareTo(to) <= 0)
                {
                    ret = row.Column3;
                    break;
                }
            }

            return KKHUtility.DecParse(ret).ToString("0.00");
        }

        /// <summary>
        /// �V�K�o�^�O�̃`�F�b�N���� 
        /// </summary>
        /// <returns>�`�F�b�N����(True�FOK�AFalse�FNG)</returns>
        private bool CheckBeforeRegisterJyutyuTkd()
        {
            // �������z�i�K�{�`�F�b�N�j 
            if (string.IsNullOrEmpty(this.txtKngk.Text.Trim()) ||
                this.txtKngk.Text == "0")
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0053, null, "�V�K�o�^", MessageBoxButtons.OK);
                this.txtKngk.Focus();
                return false;
            }

            // �������z�i���l�`�F�b�N�j 
            if (!KKHUtility.IsNumeric(this.txtKngk.Text.Trim(',')))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0052, null, "�V�K�o�^", MessageBoxButtons.OK);
                this.txtKngk.Focus();
                return false;
            }

            // ����ŗ��i���l�`�F�b�N�j 
            if (!KKHUtility.IsNumeric(this.txtTax.Text.Trim()))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0048, null, "�V�K�o�^", MessageBoxButtons.OK);
                this.txtTax.Focus();
                return false;
            }

            // ����ŗ��i�������`�F�b�N�j 
            double tax = double.Parse(this.txtTax.Text.Trim());
            if (tax < 0 || tax > 999.99)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0048, null, "�V�K�o�^", MessageBoxButtons.OK);
                this.txtTax.Focus();
                return false;
            }

            return true;
        }

        #endregion ���\�b�h 
    }
}
