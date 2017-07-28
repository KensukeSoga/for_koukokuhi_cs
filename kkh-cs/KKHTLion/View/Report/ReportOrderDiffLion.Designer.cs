namespace Isid.KKH.Lion.View.Report
{
    partial class ReportOrderDiffLion
    {
        /// <summary>
        /// 必要なデザイナ変数です。.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。.
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

        #region Windows フォーム デザイナで生成されたコード.

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を.
        /// コード エディタで変更しないでください。.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportOrderDiffLion));
            this.txtYm = new Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl();
            this.lblYM = new Isid.NJ.View.Widget.NJLabel();
            this.btnXls = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnRetrun = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.SuspendLayout();
            // 
            // txtYm
            // 
            this.txtYm.DisplayMode = Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.DisplayMode.COMBO;
            this.txtYm.Location = new System.Drawing.Point(100, 30);
            this.txtYm.MinimumSize = new System.Drawing.Size(82, 21);
            this.txtYm.Name = "txtYm";
            this.txtYm.Size = new System.Drawing.Size(82, 21);
            this.txtYm.TabIndex = 2;
            this.txtYm.ValidateDisableOnce = false;
            // 
            // lblYM
            // 
            this.lblYM.AutoSize = true;
            this.lblYM.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYM.Location = new System.Drawing.Point(63, 34);
            this.lblYM.Name = "lblYM";
            this.lblYM.Size = new System.Drawing.Size(29, 12);
            this.lblYM.TabIndex = 41;
            this.lblYM.Text = "年月";
            // 
            // btnXls
            // 
            this.btnXls.BackColor = System.Drawing.Color.Transparent;
            this.btnXls.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXls.FlatAppearance.BorderSize = 0;
            this.btnXls.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnXls.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnXls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXls.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXls.Image = ((System.Drawing.Image)(resources.GetObject("btnXls.Image")));
            this.btnXls.Location = new System.Drawing.Point(200, 30);
            this.btnXls.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseDownImage")));
            this.btnXls.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseLeaveImage")));
            this.btnXls.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseMoveImage")));
            this.btnXls.Name = "btnXls";
            this.btnXls.Size = new System.Drawing.Size(113, 22);
            this.btnXls.TabIndex = 1;
            this.btnXls.Text = "    帳票出力";
            this.btnXls.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXls.UseVisualStyleBackColor = false;
            this.btnXls.Click += new System.EventHandler(this.btnXls_Click);
            // 
            // btnHlp
            // 
            this.btnHlp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHlp.BackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHlp.FlatAppearance.BorderSize = 0;
            this.btnHlp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHlp.Image = ((System.Drawing.Image)(resources.GetObject("btnHlp.Image")));
            this.btnHlp.Location = new System.Drawing.Point(348, -2);
            this.btnHlp.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseDownImage")));
            this.btnHlp.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseLeaveImage")));
            this.btnHlp.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseMoveImage")));
            this.btnHlp.Name = "btnHlp";
            this.btnHlp.Size = new System.Drawing.Size(37, 37);
            this.btnHlp.TabIndex = 3;
            this.btnHlp.TabStop = false;
            this.btnHlp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHlp.UseVisualStyleBackColor = false;
            this.btnHlp.Click += new System.EventHandler(this.btnHlp_Click);
            // 
            // btnRetrun
            // 
            this.btnRetrun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetrun.BackColor = System.Drawing.Color.Transparent;
            this.btnRetrun.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRetrun.FlatAppearance.BorderSize = 0;
            this.btnRetrun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRetrun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRetrun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetrun.Image = ((System.Drawing.Image)(resources.GetObject("btnRetrun.Image")));
            this.btnRetrun.Location = new System.Drawing.Point(391, -2);
            this.btnRetrun.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnRetrun.MouseDownImage")));
            this.btnRetrun.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnRetrun.MouseLeaveImage")));
            this.btnRetrun.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnRetrun.MouseMoveImage")));
            this.btnRetrun.Name = "btnRetrun";
            this.btnRetrun.Size = new System.Drawing.Size(37, 37);
            this.btnRetrun.TabIndex = 4;
            this.btnRetrun.TabStop = false;
            this.btnRetrun.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRetrun.UseVisualStyleBackColor = false;
            this.btnRetrun.Click += new System.EventHandler(this.btnRetrun_Click);
            // 
            // ReportOrderDiffLion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(440, 112);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.btnRetrun);
            this.Controls.Add(this.btnXls);
            this.Controls.Add(this.txtYm);
            this.Controls.Add(this.lblYM);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ReportOrderDiffLion";
            this.Text = "受注比較一覧";
            this.Load += new System.EventHandler(this.ReportOrderDiffLion_Shown);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.ReportOrderDiffLion_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.lblYM, 0);
            this.Controls.SetChildIndex(this.txtYm, 0);
            this.Controls.SetChildIndex(this.btnXls, 0);
            this.Controls.SetChildIndex(this.btnRetrun, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl txtYm;
        private Isid.NJ.View.Widget.NJLabel lblYM;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnXls;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHlp;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnRetrun;

    }
}
