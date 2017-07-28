namespace Isid.KKH.Toh.View.Mast
{
    partial class frmMastToh
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
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
