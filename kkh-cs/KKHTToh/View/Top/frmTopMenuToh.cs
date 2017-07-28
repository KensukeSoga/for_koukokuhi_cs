using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Isid.KKH.Toh.View.Detail;
using Isid.KKH.Toh.ProcessController;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Control.MenuButton;
using Isid.KKH.Common.KKHView.Top;
using Isid.NJ.View.Base;
using Isid.KKH.UserManual;
using Isid.KKH.Common.KKHUtility.Constants;
namespace Isid.KKH.Toh.View.Top
{
    /// <summary>
    /// �g�b�v���j���[��ʁitoh)
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
    ///       <description></description>
    ///       <description></description>
    ///       <description>�V�K�쐬</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class frmTopMenuToh : TopMenuForm
    {
        # region �����o�ϐ�

        KKHNaviParameter topNaviParameter = new KKHNaviParameter();

        # endregion �����o�ϐ�

        # region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        public frmTopMenuToh()
        {
            InitializeComponent();
        }

        # endregion �R���X�g���N�^

        # region �C�x���g

        /// <summary>
        /// ���ProcessAffterNavigating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void frmTopMenuToh_ProcessAffterNavigating(object sender, NavigationEventArgs arg)
        {
            topNaviParameter = (KKHNaviParameter)arg.NaviParameter;
        }

        /// <summary>
        /// ���[PopupButtonClick 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void btnAccount_PopupButtonClick(object sender, PopupButtonClickEventArgs value)
        {
            if (value.Value == "1") // ����E�������׈ꗗ
            {
                topNaviParameter.strFrmInputNm = "toReportToh";
            }
            else if (value.Value == "2") // �N���ʔ}�̕ʏW�v
            {
                topNaviParameter.strFrmInputNm = "toReportTohTotal";
            }
            Navigator.Forward(this, topNaviParameter.strFrmInputNm, topNaviParameter);
        }

        /// <summary>
        /// [�}�X�^�[]�{�^��PopupButtonClick�C�x���g  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        private void btnMasterMaintenance_PopupButtonClick(object sender, PopupButtonClickEventArgs value)
        {
            //�{�^����(��ʖ�)���擾 
            topNaviParameter.StrValue1 = value.Value.ToString();
            Navigator.Forward(this, topNaviParameter.strFrmMastNm, topNaviParameter);
        }

        /// <summary>
        /// Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTopMenuToh_Load(object sender, EventArgs e)
        {
            btnMast.Visible = false;
            btnHistoryDownLoad.Visible = false;
        }


        /// <summary>
        /// �}�X�^�[�{�^��Click�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMast_Click(object sender, EventArgs e)
        {
            //�}�X�^�[�����e���X��ʂɑJ�� 
            Navigator.Forward(this, topNaviParameter.strFrmMastNm, topNaviParameter);
        }

        /// <summary>
        /// MouseMove�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseMoveCommon(object sender, MouseEventArgs e)
        {
            base.MouseMoveCommon(sender, e);
        }

        /// <summary>
        /// MouseLeave�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseLeaveCommon(object sender, EventArgs e)
        {
            base.MouseLeaveCommon(sender, e);
        }

        # endregion �C�x���g

    }
}

