namespace Isid.KKH.Common.KKHView.Detail
{
    partial class JyutyuMerge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JyutyuMerge));
            this.njLabel1 = new Isid.NJ.View.Widget.NJLabel();
            this.cmbTouData = new Isid.NJ.View.Widget.NJComboBox();
            this.njLabel2 = new Isid.NJ.View.Widget.NJLabel();
            this.njLabel3 = new Isid.NJ.View.Widget.NJLabel();
            this.btnCancel = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnOK = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.SuspendLayout();
            // 
            // njLabel1
            // 
            this.njLabel1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel1.Location = new System.Drawing.Point(12, 13);
            this.njLabel1.Name = "njLabel1";
            this.njLabel1.Size = new System.Drawing.Size(223, 18);
            this.njLabel1.TabIndex = 22;
            this.njLabel1.Text = "�ǂ̌��ɓ������܂����H";
            // 
            // cmbTouData
            // 
            this.cmbTouData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTouData.FormattingEnabled = true;
            this.cmbTouData.Location = new System.Drawing.Point(12, 34);
            this.cmbTouData.Name = "cmbTouData";
            this.cmbTouData.Size = new System.Drawing.Size(454, 26);
            this.cmbTouData.TabIndex = 1;
            // 
            // njLabel2
            // 
            this.njLabel2.ForeColor = System.Drawing.Color.Red;
            this.njLabel2.Location = new System.Drawing.Point(12, 74);
            this.njLabel2.Name = "njLabel2";
            this.njLabel2.Size = new System.Drawing.Size(75, 20);
            this.njLabel2.TabIndex = 21;
            this.njLabel2.Text = "����";
            // 
            // njLabel3
            // 
            this.njLabel3.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel3.Location = new System.Drawing.Point(12, 94);
            this.njLabel3.Name = "njLabel3";
            this.njLabel3.Size = new System.Drawing.Size(454, 61);
            this.njLabel3.TabIndex = 22;
            this.njLabel3.Text = "��������ď����錏���ɑ΂��ē��͂���Ă���L����ׂ͏����܂���������̌����ɂ��ē��͂����L����ׂ͎c��܂��B\r\n�܂��A����������ɓ������������ƍL�����" +
                "�͌��ɖ߂�܂��B";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(353, 158);
            this.btnCancel.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseDownImage")));
            this.btnCancel.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseLeaveImage")));
            this.btnCancel.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseMoveImage")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 22);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "   �L�����Z��";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(234, 158);
            this.btnOK.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseDownImage")));
            this.btnOK.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseLeaveImage")));
            this.btnOK.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseMoveImage")));
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 22);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // JyutyuMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.ClientSize = new System.Drawing.Size(486, 192);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.njLabel3);
            this.Controls.Add(this.njLabel2);
            this.Controls.Add(this.cmbTouData);
            this.Controls.Add(this.njLabel1);
            this.Name = "JyutyuMerge";
            this.Text = "������̑I��";
            this.Shown += new System.EventHandler(this.JyutyuMerge_Shown);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.JyutyuMerge_ProcessAffterNavigating);
            this.ResumeLayout(false);

        }

        #endregion

        private Isid.NJ.View.Widget.NJLabel njLabel1;
        private Isid.NJ.View.Widget.NJComboBox cmbTouData;
        private Isid.NJ.View.Widget.NJLabel njLabel2;
        private Isid.NJ.View.Widget.NJLabel njLabel3;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnCancel;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnOK;
    }
}
