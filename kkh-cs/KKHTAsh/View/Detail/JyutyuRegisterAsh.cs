using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Constants;

namespace Isid.KKH.Ash.View.Detail
{
    public partial class JyutyuRegisterAsh : Isid.KKH.Common.KKHView.Detail.JyutyuRegister
    {
       
        /// <summary>
        /// 
        /// </summary>
        public JyutyuRegisterAsh()
        {
            InitializeComponent();
        }

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

            return true;
        }


        /// <summary>
        /// �V�K�o�^API�̎��s�p�����[�^�̕ҏW���s�� 
        /// </summary>
        /// <returns></returns>
        protected override DetailProcessController.RegisterJyutyuDataParam EditRegisterJyutyuDataParam()
        {
            //���ʋ@�\�œo�^�f�[�^�̏����ݒ���s�� 
            DetailProcessController.RegisterJyutyuDataParam param = base.EditRegisterJyutyuDataParam();

            //****************************************
            //���Ӑ�ʂ̐ݒ荀�ڂ�ҏW 
            //****************************************
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow row in param.dsDetail.THB1DOWN.Rows)
            {
                //�X�V�v���O���� 
                row.hb1UpdApl = "DtlAsh";
            }
            param.dsDetail.THB1DOWN.AcceptChanges();

            return param;
        }
    }
}

