using System;
using System.Windows.Forms;

using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;

namespace Isid.KKH.Acom.View.Claim
{
    /// <summary>
    /// �����f�[�^���[�o�� 
    /// </summary>
    public partial class ClaimRepForm : KKHDialogBase
    {
        #region �萔 

        #endregion �萔 

        #region �\���� 

        #endregion �\���� 

        #region �����o�ϐ� 

        /// <summary>
        /// Rg�i�r�p�����[�^ 
        /// </summary>
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();

        #endregion �����o�ϐ�

        #region �R���X�g���N�^ 

        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        public ClaimRepForm()
        {
            InitializeComponent();
        }

        #endregion �R���X�g���N�^ 

        #region �C�x���g 

        /// <summary>
        /// ��ʑJ�ڂ��邽�тɔ������܂��B 
        /// </summary>
        /// <param name="sender">�J�ڌ��t�H�[��</param>
        /// <param name="arg">�C�x���g�f�[�^</param>
        private void HikForm_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParameter = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// �t�H�[��Load�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HikForm_Load(object sender, EventArgs e)
        {
            this.InitializeControl();
        }

        #endregion �C�x���g 

        #region ���\�b�h 

        /// <summary>
        /// �e�R���g���[���̏����ݒ� 
        /// </summary>
        private void InitializeControl()
        {
            string yyyymm = _naviParameter.strDate.Replace("/", string.Empty);

        }
       
        #endregion ���\�b�h 
    }
}

