namespace Isid.KKH.Toh.View.Mast
{
    partial class frmMastToh
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
            ((System.ComponentModel.ISupportInitialize)(this.spdMasMainte)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // frmMastToh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Name = "frmMastToh";
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.frmMastToh_ProcessAffterNavigating);
            ((System.ComponentModel.ISupportInitialize)(this.spdMasMainte)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
