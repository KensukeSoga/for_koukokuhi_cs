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
    /// <summary>
    /// 
    /// </summary>
    public partial class LoadingDialog2 : System.Windows.Forms.Form
    {
        /// <summary>
        /// 
        /// </summary>
        public LoadingDialog2()
        {
            InitializeComponent();

            _opacity = 0.5;
        }

        //�Ăяo������ʂ̉摜��ێ� 
        private Bitmap _bmp;
        //�Ăяo������� 
        private System.Windows.Forms.Form _parentForm;

        /// <summary>
        /// 
        /// </summary>
        public System.Windows.Forms.Form ParentForm
        {
            get { return _parentForm; }
            set
            {
                _parentForm = value;

                if (_parentForm != null)
                {
                    //�Ăяo������ʂ̉摜��ێ����� 
                    _bmp = new Bitmap(_parentForm.Width, _parentForm.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    //_bmp = new Bitmap(_parentForm.Width, _parentForm.Height);
                    _parentForm.DrawToBitmap(_bmp, new Rectangle(0, 0, this.Width, this.Height));
                }
                else
                {
                    _bmp = null;
                }
            }
        }

        double _opacity = 1.00;
        //
        // �T�v:
        //     �t�H�[���̕s�����x���擾�܂��͐ݒ肵�܂��B
        //
        // �߂�l:
        //     �t�H�[���̕s�����x�B����l�� 1.00 �ł��B

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(1)]
        [TypeConverter(typeof(OpacityConverter))]
        public new double Opacity 
        {
            get { return _opacity; }
            set { _opacity = value; }
        }

        #region �A�N�e�B�u������
        ///******************************************************************************
        // * ���̉�ʂ��A�N�e�B�u������ƌĂяo�����̉�ʂŕ\���������b�Z�[�W�{�b�N�X�� 
        // * ���̉�ʂɉB��Ă��܂��̂ňȉ��̑Ή����s���Ă���  
        // * �P�D�����\�����ɃA�N�e�B�u�ɂ��Ȃ�(ShowWithoutActivation���I�[�o�[���C�h) 
        // * �Q�D�}�E�X�N���b�N�ɂ��A�N�e�B�u����h�~(WndProc���I�[�o�[���C�h) 
        // * �R�D�^�X�N�o�[�ɕ\�����Ȃ�(ShowInTaskbar = false) 
        //******************************************************************************/

        //protected override bool ShowWithoutActivation
        //{
        //    get
        //    {
        //        //return base.ShowWithoutActivation;
        //        return true;
        //    }
        //}

        //const int WM_MOUSEACTIVATE = 0x0021;
        //const int MA_NOACTIVATE = 3;
        //const int MA_NOACTIVATEANDEAT = 4;

        //protected override void WndProc(ref Message m)
        //{
        //    switch (m.Msg)
        //    {
        //        case WM_MOUSEACTIVATE:
        //            //�}�E�X�N���b�N�ŃA�N�e�B�u�ɂ����̂�h�~ 
        //            //m.Result = new IntPtr(WA_NOACTIVATE);
        //            m.Result = new IntPtr(MA_NOACTIVATEANDEAT);
        //            return;
        //    }
        //    base.WndProc(ref m);
        //}
        #endregion �A�N�e�B�u������

        #region ���J���\�b�h
        private bool _closeFlag = false;

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
            //this.Refresh();
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
        private int arcWidth = 0;
        /// <summary>
        /// �p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̕��A�l��傫������قǊp�����ۂ��Ȃ�܂��B 
        /// </summary>
        [Browsable(true)]                              //�v���p�e�B�E�B���h�E�\�� 
        [Description("�p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̕��A�l��傫������قǊp�����ۂ��Ȃ�܂��B")]
        [DefaultValue(0)]
        public int ArcWidth
        {
            get { return arcWidth; }
            set { arcWidth = value; }
        }

        private int arcHeight = 0;
        /// <summary>
        /// �p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̍����A�l��傫������قǊp�����ۂ��Ȃ�܂��B 
        /// </summary>
        [Browsable(true)]                              //�v���p�e�B�E�B���h�E�\�� 
        [Description("�p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̍����A�l��傫������قǊp�����ۂ��Ȃ�܂��B")]
        [DefaultValue(0)]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (_parentForm != null)
            {
                //�Ăяo������ʂ̉摜��w�i�Ƃ��ĕ`�� 
                e.Graphics.DrawImage(_bmp, this.ClientRectangle, new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height), GraphicsUnit.Pixel);

                //Rectangle r = this.ClientRectangle;
                //using (SolidBrush sb = new SolidBrush(Color.FromArgb(decimal.ToInt32((decimal)Math.Floor(255 * this.Opacity)), this.BackColor)))
                ////using (SolidBrush sb = new SolidBrush(Color.FromArgb(decimal.ToInt32((decimal)Math.Floor(200M)), this.BackColor)))
                //{
                //    e.Graphics.FillRectangle(sb, r);
                //}
            }
            else
            {
                base.OnPaintBackground(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadingDialog_Load(object sender, EventArgs e)
        {
            //�t�H�[���̌`��ύX 
            UpdateFormFormat();
            //�O�ʕ\�� 
            this.BringToFront();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadingDialog_Activated(object sender, EventArgs e)
        {
            //this.Refresh();
        }


    }
}

