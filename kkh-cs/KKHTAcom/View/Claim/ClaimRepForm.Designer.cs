namespace Isid.KKH.Acom.View.Claim
{
    partial class ClaimRepForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClaimRepForm));
            this.btnHlp = new Isid.NJ.View.Widget.NJButton();
            this.btnEnd = new Isid.NJ.View.Widget.NJButton();
            this.btnRep = new Isid.NJ.View.Widget.NJButton();
            this.njButton1 = new Isid.NJ.View.Widget.NJButton();
            this.SuspendLayout();
            // 
            // btnHlp
            // 
            this.btnHlp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHlp.Image = ((System.Drawing.Image)(resources.GetObject("btnHlp.Image")));
            this.btnHlp.Location = new System.Drawing.Point(200, 12);
            this.btnHlp.Name = "btnHlp";
            this.btnHlp.Size = new System.Drawing.Size(68, 56);
            this.btnHlp.TabIndex = 0;
            this.btnHlp.Text = "�w���v";
            this.btnHlp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHlp.UseVisualStyleBackColor = true;
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEnd.Image")));
            this.btnEnd.Location = new System.Drawing.Point(274, 12);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(68, 56);
            this.btnEnd.TabIndex = 1;
            this.btnEnd.Text = "�߂�";
            this.btnEnd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnd.UseVisualStyleBackColor = true;
            // 
            // btnRep
            // 
            this.btnRep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRep.Enabled = false;
            this.btnRep.Location = new System.Drawing.Point(12, 90);
            this.btnRep.Name = "btnRep";
            this.btnRep.Size = new System.Drawing.Size(330, 56);
            this.btnRep.TabIndex = 2;
            this.btnRep.Text = "�������ו\";
            this.btnRep.UseVisualStyleBackColor = true;
            // 
            // njButton1
            // 
            this.njButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.njButton1.Enabled = false;
            this.njButton1.Location = new System.Drawing.Point(12, 152);
            this.njButton1.Name = "njButton1";
            this.njButton1.Size = new System.Drawing.Size(330, 56);
            this.njButton1.TabIndex = 3;
            this.njButton1.Text = "�����f�[�^�ꗗ";
            this.njButton1.UseVisualStyleBackColor = true;
            // 
            // ClaimRepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.ClientSize = new System.Drawing.Size(354, 248);
            this.Controls.Add(this.njButton1);
            this.Controls.Add(this.btnRep);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.btnEnd);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ClaimRepForm";
            this.Text = "EXCEL���[�쐬";
            this.Load += new System.EventHandler(this.HikForm_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.HikForm_ProcessAffterNavigating);
            this.ResumeLayout(false);

        }

        #endregion

        protected Isid.NJ.View.Widget.NJButton btnHlp;
        protected Isid.NJ.View.Widget.NJButton btnEnd;
        protected Isid.NJ.View.Widget.NJButton btnRep;
        protected Isid.NJ.View.Widget.NJButton njButton1;

    }
}
