using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.NJSecurity.Core;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Log;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Mast;
using Isid.NJ.View.Base;
using Isid.NJ.View.Navigator;
using System.Drawing.Drawing2D;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;

namespace Isid.KKH.Common.KKHView.Top
{

    /// <summary>
    /// �ėp�g�b�v���j���N���X
    /// </summary>
    public partial class TopMenuForm : KKHForm, INaviParameter
    {

        #region "�v���C�x�[�g�v���p�e�B"

        // �Ăяo���p�����[�^(���)
        private KKHNaviParameter topNaviParameter;

        #endregion

        #region "�p�u���b�N�v���p�e�B"

        /// <summary>
        /// ���[�{�^��visible
        /// </summary>
        [Category("Kkh")]
        public bool btnAccountVisble
        {
            get { return btnAccount.Visible; }
            set { btnAccount.Visible = value; }
        }

        /// <summary>
        /// ���׃{�^��visible
        /// </summary>
        [Category("Kkh")]
        public bool btnDetailsVisble
        {
            get { return btnDetails.Visible; }
            set { btnDetails.Visible = value; }
        }

        /// <summary>
        /// �}�X�^�{�^��visible
        /// </summary>
        [Category("Kkh")]
        public bool btnMasterMaintenanceVisble
        {
            get { return btnMasterMaintenance.Visible; }
            set { btnMasterMaintenance.Visible = value; }
        }

        /// <summary>
        /// ���m�点�O���[�vvisible
        /// </summary>
        [Category("Kkh")]
        public bool grpInformationVisble
        {
            get { return grpInformation.Visible; }
            set { grpInformation.Visible = value; }
        }

        #endregion

        #region "�C�x���g"

        /// <summary>
        /// 
        /// </summary>
        public TopMenuForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �u�}�X�^�����e�i���X�v�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂� 
        /// </summary>
        /// <param name="sender">�{�^���R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        private void btnMasterMaintenance_Click(object sender, EventArgs e)
        {
            Navigator.Forward(this, topNaviParameter.strFrmMastNm, topNaviParameter);
        }

        /// <summary>
        /// �u�I���v�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂� 
        /// </summary>
        /// <param name="sender">�{�^���R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            //// �I�����I�y���[�V�������O�̏o�� 
            RegistLogServiceResult logResult = KKHLogUtility.WriteEndingLogToDB(topNaviParameter, "TopMenu", "TopMenu���I�����܂����B");

            this.Close();
            Environment.Exit(0);
        }

        /// <summary>
        /// �u���ׁv�{�^���R���g���[���������C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetails_Click(object sender, EventArgs e)
        {
            Navigator.Forward(this, topNaviParameter.strFrmDetailNm, topNaviParameter);
        }


        /// <summary>
        /// �u�g�b�v���j���v�t�H�[���Ăяo�����C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void TopMenuForm_ProcessAffterNavigating(object sender, NavigationEventArgs arg)
        {

            topNaviParameter = (KKHNaviParameter)arg.NaviParameter;
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(topNaviParameter.strEsqId,
                                                                                            topNaviParameter.strEgcd,
                                                                                            topNaviParameter.strTksKgyCd,
                                                                                            topNaviParameter.strTksBmnSeqNo,
                                                                                            topNaviParameter.strTksTntSeqNo,
                                                                                            "001",
                                                                                            "ED-I0001");

            tslDate.Text = topNaviParameter.strDate;
            tslName.Text = topNaviParameter.strName;
            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                string strInfotxt = string.Empty;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field2.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field2.ToString() + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field3.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field3.ToString() + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field4.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field4.ToString() + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field5.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field5.ToString() + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field6.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field6.ToString() + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field7.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field7.ToString() + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field8.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field8.ToString() + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field9.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field9.ToString() + System.Environment.NewLine;
                if (!string.IsNullOrEmpty(comResult.CommonDataSet.SystemCommon[0].field10.ToString())) strInfotxt += comResult.CommonDataSet.SystemCommon[0].field10.ToString();

                txtInformation.Text = strInfotxt;

            }
            lblTksNm.Text = topNaviParameter.strTksKgyName;

            //�摜�̏����� 
            btnMasterMaintenance.button.MouseLeaveImage = btnMasterMaintenance.button.MouseDownImage;
            btnAccount.button.MouseLeaveImage = btnAccount.button.MouseDownImage;

            //�I����Ԃ��O�� 
            this.ActiveControl = null;

        }

        /// <summary>
        /// �u�g�b�v���j���v�t�H�[�����[�h���C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopMenuForm_Load(object sender, EventArgs e)
        {
            //�p����̃t�H�[���f�U�C�i�\�����ł���悤�Ƀf�U�C�i���[�h���ɂ͉������Ȃ� 
            if (DesignMode == true) { return; }
            RegistLogServiceResult logResult = KKHLogUtility.WriteStartingLogToDB(topNaviParameter, "TopMenu", "TopMenu���N�����܂����B");

            //�t�H�[���̌`��ύX 
            UpdateFormFormat();

            //�摜�̏����� 
            btnMasterMaintenance.button.MouseLeaveImage = btnMasterMaintenance.button.MouseDownImage;
            btnAccount.button.MouseLeaveImage = btnAccount.button.MouseDownImage;

            //�c�[���`�b�v�o�^
            this.njToolTip1.SetToolTip(btnMasterMaintenance.button, btnMasterMaintenance.ToolTipText);
            this.njToolTip1.SetToolTip(btnAccount.button, btnAccount.ToolTipText);

            //�C�x���g�o�^
            btnMasterMaintenance.button.MouseMove += new MouseEventHandler(this.MouseMoveCommon);
            btnMasterMaintenance.button.MouseLeave += new EventHandler(this.MouseLeaveCommon);
            btnAccount.button.MouseMove += new MouseEventHandler(this.MouseMoveCommon);
            btnAccount.button.MouseLeave += new EventHandler(this.MouseLeaveCommon);

        }

        /// <summary>
        /// ���[�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccount_Click(object sender, EventArgs e)
        {
            this.Tyouhyouseni();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistoryDownLoad_Click(object sender, EventArgs e)
        {
            topNaviParameter.strFrmInputNm = "toHisDownlodData";

            Navigator.Forward(this, topNaviParameter.strFrmInputNm, topNaviParameter);
        }

        /// <summary>
        /// �w���v�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = topNaviParameter.strTksKgyCd + topNaviParameter.strTksBmnSeqNo + topNaviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //���s 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.MainManue, this, HelpNavigator.KeywordIndex);

            this.ActiveControl = null;
        }

        #endregion �C�x���g

        # region ���\�b�h
        /// <summary>
        /// 
        /// </summary>
        protected virtual void Tyouhyouseni()
        {
            Navigator.Forward(this, topNaviParameter.strFrmInputNm, topNaviParameter);
        }


        /// <summary>
        /// MouseMove�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void MouseMoveCommon(object sender, MouseEventArgs e)
        {
            tslCnt.Text = njToolTip1.GetToolTip((Control)sender);
        }

        /// <summary>
        /// MouseLeave�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void MouseLeaveCommon(object sender, EventArgs e)
        {
            tslCnt.Text = "";
        }

        # endregion ���\�b�h

        #region �p���ۂ�����Ή��֘A
        private int arcWidth = 25;
        /// <summary>
        /// �p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̕��A�l��傫������قǊp�����ۂ��Ȃ�܂��B 
        /// </summary>
        [Browsable(true)]                              //�v���p�e�B�E�B���h�E�\�� 
        [Description("�p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̕��A�l��傫������قǊp�����ۂ��Ȃ�܂��B")]
        [DefaultValue(25)]
        public int ArcWidth
        {
            get { return arcWidth; }
            set { arcWidth = value; }
        }

        private int arcHeight = 25;
        /// <summary>
        /// �p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̍����A�l��傫������قǊp�����ۂ��Ȃ�܂��B 
        /// </summary>
        [Browsable(true)]                              //�v���p�e�B�E�B���h�E�\�� 
        [Description("�p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̍����A�l��傫������قǊp�����ۂ��Ȃ�܂��B")]
        [DefaultValue(25)]
        public int ArcHeight
        {
            get { return arcHeight; }
            set { arcHeight = value; }
        }

        /// <summary>
        /// �t�H�[���̌`��ύX���� 
        /// </summary>
        private void UpdateFormFormat()
        {
            if (arcWidth > 0 && arcHeight > 0)
            {
                using (GraphicsPath gp = new GraphicsPath())
                {
                    Rectangle r = this.ClientRectangle;
                    gp.StartFigure();
                    gp.AddArc(r.Right - arcWidth, r.Top, arcWidth, arcHeight, 270, 90);              // �E��

                    gp.AddArc(r.Right - arcWidth, r.Bottom - arcHeight, arcWidth, arcHeight, 0, 90); // �E��

                    gp.AddArc(r.Left, r.Bottom - arcHeight, arcWidth, arcHeight, 90, 90);            // ����

                    gp.AddArc(r.Left, r.Top, arcWidth, arcHeight, 180, 90);                          // ����

                    gp.CloseFigure();

                    //�`��ύX
                    this.Region = new Region(gp);
                }
            }
        }
        #endregion �p���ۂ�����Ή��֘A

    }
}