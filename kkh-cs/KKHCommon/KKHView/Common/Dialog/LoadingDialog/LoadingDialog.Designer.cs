namespace Isid.KKH.Common.KKHView.Common.Dialog.LoadingDialog
{
    partial class LoadingDialog
    {
        /// <summary>
        /// �K�v�ȃf�U�C�i�ϐ��ł��B
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// �g�p���̃��\�[�X�����ׂăN���[���A�b�v���܂��B
        /// </summary>
        /// <param name="disposing">�}�l�[�W ���\�[�X���j�������ꍇ true�A�j������Ȃ��ꍇ�� false �ł��B</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h

        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingDialog));
            this.njPictureBox1 = new Isid.NJ.View.Widget.NJPictureBox();
            this.njProgressBar1 = new Isid.NJ.View.Widget.NJProgressBar();
            this.njLabel1 = new Isid.NJ.View.Widget.NJLabel();
            ( (System.ComponentModel.ISupportInitialize)( this.njPictureBox1 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // njPictureBox1
            // 
            this.njPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.njPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.njPictureBox1.Image = ( (System.Drawing.Image)( resources.GetObject("njPictureBox1.Image") ) );
            this.njPictureBox1.Location = new System.Drawing.Point(268, 102);
            this.njPictureBox1.Name = "njPictureBox1";
            this.njPictureBox1.Size = new System.Drawing.Size(52, 52);
            this.njPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.njPictureBox1.TabIndex = 0;
            this.njPictureBox1.TabStop = false;
            // 
            // njProgressBar1
            // 
            this.njProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.njProgressBar1.Location = new System.Drawing.Point(183, 120);
            this.njProgressBar1.Name = "njProgressBar1";
            this.njProgressBar1.Size = new System.Drawing.Size(222, 23);
            this.njProgressBar1.TabIndex = 1;
            // 
            // njLabel1
            // 
            this.njLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.njLabel1.BackColor = System.Drawing.Color.Transparent;
            this.njLabel1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.njLabel1.Location = new System.Drawing.Point(0, 170);
            this.njLabel1.Name = "njLabel1";
            this.njLabel1.Size = new System.Drawing.Size(589, 25);
            this.njLabel1.TabIndex = 2;
            this.njLabel1.Text = "���s���D�D�D";
            this.njLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadingDialog
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(589, 263);
            this.Controls.Add(this.njLabel1);
            this.Controls.Add(this.njPictureBox1);
            this.Controls.Add(this.njProgressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingDialog";
            this.Opacity = 0.8;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Blue;
            this.Load += new System.EventHandler(this.LoadingDialog_Load);
            this.Activated += new System.EventHandler(this.LoadingDialog_Activated);
            ( (System.ComponentModel.ISupportInitialize)( this.njPictureBox1 ) ).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Isid.NJ.View.Widget.NJPictureBox njPictureBox1;
        private Isid.NJ.View.Widget.NJProgressBar njProgressBar1;
        private Isid.NJ.View.Widget.NJLabel njLabel1;
    }
}
