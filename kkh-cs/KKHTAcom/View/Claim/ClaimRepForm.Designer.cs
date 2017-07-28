namespace Isid.KKH.Acom.View.Claim
{
    partial class ClaimRepForm
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
            this.btnHlp.Text = "ヘルプ";
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
            this.btnEnd.Text = "戻る";
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
            this.btnRep.Text = "請求明細表";
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
            this.njButton1.Text = "請求データ一覧";
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
            this.Text = "EXCEL帳票作成";
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
