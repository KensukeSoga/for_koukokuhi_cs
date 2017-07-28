using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Isid.KKH.Common.KKHView.Common.Dialog.LoadingDialog
{
    public partial class LoadingDialog : System.Windows.Forms.Form
    {
        # region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        public LoadingDialog()
        {
            InitializeComponent();
        }

        # endregion �R���X�g���N�^ 

        # region �C�x���g

        /// <summary>
        /// ���[�h�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadingDialog_Load(object sender, EventArgs e)
        {
            //�t�H�[���̌`��ύX 
            UpdateFormFormat();
        }

        /// <summary>
        /// Activated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadingDialog_Activated(object sender, EventArgs e)
        {
            this.Refresh();
        }


        # endregion �C�x���g

        #region ���J���\�b�h
        private bool _closeFlag = false;

        /// <summary>
        /// 
        /// </summary>
        public bool CloseFlag
        {
            get { return _closeFlag; }
            set { _closeFlag = value; }
        }

        /// <summary>
        /// �摜�\���p�^�[�� 
        /// </summary>
        public void StartPicture()
        {
            this.njProgressBar1.Enabled = false;
            this.njProgressBar1.Visible = false;
            this.njPictureBox1.Enabled = true;
            this.njPictureBox1.Visible = true;
            this.Show();//������\�������� 
            this.Refresh();
            //�Ăяo�����ŏI��������܂Ŗ������[�v 
            while (!_closeFlag)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }

        /// <summary>
        /// �v���O���X�o�[�\���p�^�[�� 
        /// </summary>
        public void StartProgressBar()
        {
            this.njProgressBar1.Enabled = true;
            this.njProgressBar1.Visible = true;
            this.njPictureBox1.Enabled = false;
            this.njPictureBox1.Visible = false;

            this.Enabled = false;
            this.Show();//������\�������� 
            this.Refresh();
            //�Ăяo�����ŏI��������܂Ŗ������[�v 
            while (!_closeFlag)
            {
                njProgressBar1.Maximum = 200000;
                // �v���O���X�o�[�̕\��
                for (int n = 0; n < njProgressBar1.Maximum; n++)
                {
                    njProgressBar1.Value = n;
                }
            }
        }
        #endregion ���J���\�b�h

        #region �p���ۂ�����Ή��֘A
        private int arcWidth = 45;
        /// <summary>
        /// �p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̕��A�l��傫������قǊp�����ۂ��Ȃ�܂��B 
        /// </summary>
        [Browsable(true)]                              //�v���p�e�B�E�B���h�E�\�� 
        [Description("�p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̕��A�l��傫������قǊp�����ۂ��Ȃ�܂��B")]
        [DefaultValue(45)]
        public int ArcWidth
        {
            get { return arcWidth; }
            set { arcWidth = value; }
        }

        private int arcHeight = 45;
        /// <summary>
        /// �p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̍����A�l��傫������قǊp�����ۂ��Ȃ�܂��B 
        /// </summary>
        [Browsable(true)]                              //�v���p�e�B�E�B���h�E�\�� 
        [Description("�p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̍����A�l��傫������قǊp�����ۂ��Ȃ�܂��B")]
        [DefaultValue(45)]
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

        #region �A�N�e�B�u������
        /******************************************************************************
         * ���̉�ʂ��A�N�e�B�u������ƌĂяo�����̉�ʂŕ\���������b�Z�[�W�{�b�N�X�� 
         * ���̉�ʂɉB��Ă��܂��̂ňȉ��̑Ή����s���Ă���  
         * �P�D�����\�����ɃA�N�e�B�u�ɂ��Ȃ�(ShowWithoutActivation���I�[�o�[���C�h) 
         * �Q�D�}�E�X�N���b�N�ɂ��A�N�e�B�u����h�~(WndProc���I�[�o�[���C�h) 
         * �R�D�^�X�N�o�[�ɕ\�����Ȃ�(ShowInTaskbar = false) 
        ******************************************************************************/
        /// <summary>
        /// 
        /// </summary>
        protected override bool ShowWithoutActivation
        {
            get
            {
                //return base.ShowWithoutActivation;
                return true;
            }
        }

        const int WM_MOUSEACTIVATE = 0x0021;
        const int MA_NOACTIVATE = 3;
        const int MA_NOACTIVATEANDEAT = 4;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_MOUSEACTIVATE:
                    //�}�E�X�N���b�N�ŃA�N�e�B�u�ɂ����̂�h�~ 
                    //m.Result = new IntPtr(WA_NOACTIVATE);
                    m.Result = new IntPtr(MA_NOACTIVATEANDEAT);
                    return;
            }
            base.WndProc(ref m);
        }
        #endregion �A�N�e�B�u������
    }
}

