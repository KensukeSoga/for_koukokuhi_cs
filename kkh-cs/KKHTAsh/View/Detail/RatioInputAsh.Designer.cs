namespace Isid.KKH.Ash.View.Detail
{
    partial class RatioInputAsh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RatioInputAsh));
            this.txtRateLeft = new Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox();
            this.txtRateRight = new Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox();
            this.lblRate = new Isid.NJ.View.Widget.NJLabel();
            this.btnOK = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnCancel = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateRight)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRateLeft
            // 
            this.txtRateLeft.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtRateLeft.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRateLeft.DecimalPlaces = 3;
            this.txtRateLeft.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRateLeft.Location = new System.Drawing.Point(21, 12);
            this.txtRateLeft.Mask = "###0.###";
            this.txtRateLeft.Name = "txtRateLeft";
            this.txtRateLeft.SignificantFigure = 7;
            this.txtRateLeft.Size = new System.Drawing.Size(87, 55);
            this.txtRateLeft.TabIndex = 0;
            this.txtRateLeft.Text = "999";
            this.txtRateLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRateLeft_KeyDown);
            // 
            // txtRateRight
            // 
            this.txtRateRight.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtRateRight.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRateRight.DecimalPlaces = 3;
            this.txtRateRight.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRateRight.Location = new System.Drawing.Point(159, 12);
            this.txtRateRight.Mask = "###0.###";
            this.txtRateRight.Name = "txtRateRight";
            this.txtRateRight.SignificantFigure = 7;
            this.txtRateRight.Size = new System.Drawing.Size(87, 55);
            this.txtRateRight.TabIndex = 1;
            this.txtRateRight.Text = "999";
            this.txtRateRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRateRight_KeyDown);
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Font = new System.Drawing.Font("MS UI Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRate.Location = new System.Drawing.Point(123, 18);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(22, 35);
            this.lblRate.TabIndex = 30;
            this.lblRate.Text = ":";
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
            this.btnOK.Location = new System.Drawing.Point(12, 85);
            this.btnOK.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseDownImage")));
            this.btnOK.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseLeaveImage")));
            this.btnOK.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseMoveImage")));
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 22);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(145, 85);
            this.btnCancel.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseDownImage")));
            this.btnCancel.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseLeaveImage")));
            this.btnCancel.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseMoveImage")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 22);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "  キャンセル";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RatioInputAsh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 131);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.txtRateRight);
            this.Controls.Add(this.txtRateLeft);
            this.EnterKeyFocusEnabled = true;
            this.Name = "RatioInputAsh";
            this.Text = "比率入力";
            this.Load += new System.EventHandler(this.RatioInputAsh_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.RatioInputAsh_ProcessAffterNavigating);
            ((System.ComponentModel.ISupportInitialize)(this.txtRateLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox txtRateLeft;
        private Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox txtRateRight;
        protected Isid.NJ.View.Widget.NJLabel lblRate;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnOK;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnCancel;


    }
}