namespace Isid.KKH.Toh.View.Top
{
    partial class frmTopMenuToh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTopMenuToh));
            this.btnMast = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.grpInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDetails
            // 
            this.btnDetails.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDetails.FlatAppearance.BorderSize = 0;
            this.btnDetails.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDetails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.njToolTip1.SetToolTip(this.btnDetails, "���׉�ʂ�\�����܂�");
            // 
            // btnAccount
            // 
            this.btnAccount.ButtonCount = 2;
            this.btnAccount.ButtonValue = new string[] {
        "1",
        "2"};
            this.btnAccount.ChildButtonText = new string[] {
        "�������׈ꗗ",
        "�N���ʔ}�̕ʏW�v"};
            this.btnAccount.ColumnCount = 3;
            this.njToolTip1.SetToolTip(this.btnAccount, "���[��ʂ�\�����܂�");
            this.btnAccount.PopupButtonClick += new Isid.KKH.Common.KKHView.Common.Control.MenuButton.PopupButtonClickEventHandler(this.btnAccount_PopupButtonClick);
            // 
            // grpInformation
            // 
            this.grpInformation.Location = new System.Drawing.Point(13, 486);
            this.grpInformation.Size = new System.Drawing.Size(579, 188);
            // 
            // txtInformation
            // 
            this.txtInformation.Location = new System.Drawing.Point(12, 18);
            this.txtInformation.Size = new System.Drawing.Size(555, 162);
            // 
            // btnHistoryDownLoad
            // 
            this.btnHistoryDownLoad.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHistoryDownLoad.FlatAppearance.BorderSize = 0;
            this.btnHistoryDownLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHistoryDownLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHistoryDownLoad.Location = new System.Drawing.Point(22, 226);
            this.njToolTip1.SetToolTip(this.btnHistoryDownLoad, "�������[�捞������ʂ�\�����܂�");
            // 
            // btnHlp
            // 
            this.btnHlp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHlp.FlatAppearance.BorderSize = 0;
            this.btnHlp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.njToolTip1.SetToolTip(this.btnHlp, "�w���v��\�����܂�");
            // 
            // btnEnd
            // 
            this.btnEnd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEnd.FlatAppearance.BorderSize = 0;
            this.btnEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.njToolTip1.SetToolTip(this.btnEnd, "�L����׃V�X�e�����I�����܂�");
            // 
            // btnMasterMaintenance
            // 
            this.btnMasterMaintenance.ButtonCount = 2;
            this.btnMasterMaintenance.ButtonValue = new string[] {
        "�X�y�[�X2�ꗗ",
        "�}�̃R�[�h�T�}��"};
            this.btnMasterMaintenance.ChildButtonText = new string[] {
        "�X�y�[�X2�ꗗ",
        "�}�̃R�[�h�T�}��"};
            this.btnMasterMaintenance.ColumnCount = 2;
            this.njToolTip1.SetToolTip(this.btnMasterMaintenance, "�}�X�^�����e�i���X��ʂ�\�����܂�");
            this.btnMasterMaintenance.PopupButtonClick += new Isid.KKH.Common.KKHView.Common.Control.MenuButton.PopupButtonClickEventHandler(this.btnMasterMaintenance_PopupButtonClick);
            // 
            // btnMast
            // 
            this.btnMast.BackColor = System.Drawing.Color.Transparent;
            this.btnMast.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMast.FlatAppearance.BorderSize = 0;
            this.btnMast.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMast.Image = ((System.Drawing.Image)(resources.GetObject("btnMast.Image")));
            this.btnMast.Location = new System.Drawing.Point(400, 205);
            this.btnMast.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnMast.MouseDownImage")));
            this.btnMast.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnMast.MouseLeaveImage")));
            this.btnMast.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnMast.MouseMoveImage")));
            this.btnMast.Name = "btnMast";
            this.btnMast.Size = new System.Drawing.Size(182, 52);
            this.btnMast.TabIndex = 49;
            this.btnMast.TabStop = false;
            this.btnMast.Text = "  �}�X�^�[";
            this.njToolTip1.SetToolTip(this.btnMast, "�}�X�^�[��ʂ�\�����܂�");
            this.btnMast.UseVisualStyleBackColor = false;
            this.btnMast.Visible = false;
            this.btnMast.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnMast.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnMast.Click += new System.EventHandler(this.btnMast_Click);
            // 
            // frmTopMenuToh
            // 
            this.btnAccountVisble = true;
            this.btnDetailsVisble = true;
            this.btnMasterMaintenanceVisble = true;
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.Controls.Add(this.btnMast);
            this.grpInformationVisble = true;
            this.Name = "frmTopMenuToh";
            this.Load += new System.EventHandler(this.frmTopMenuToh_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.frmTopMenuToh_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.btnDetails, 0);
            this.Controls.SetChildIndex(this.btnAccount, 0);
            this.Controls.SetChildIndex(this.grpInformation, 0);
            this.Controls.SetChildIndex(this.btnHistoryDownLoad, 0);
            this.Controls.SetChildIndex(this.btnMasterMaintenance, 0);
            this.Controls.SetChildIndex(this.btnMast, 0);
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnMast;




    }
}
