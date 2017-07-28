namespace Isid.KKH.Tkd.View.Detail
{
    partial class JyutyuRegisterTkd
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
            this.txtKngk = new Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox();
            this.txtTax = new Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox();
            this.njLabel5 = new Isid.NJ.View.Widget.NJLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtKenmei)).BeginInit();
            this.pnlKKSKbn.SuspendLayout();
            this.pnlTmSp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKngk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTax)).BeginInit();
            this.SuspendLayout();
            // 
            // njLabel1
            // 
            this.njLabel1.Size = new System.Drawing.Size(376, 24);
            this.njLabel1.Text = "業務区分、件名、請求金額、消費税率を決めてください";
            // 
            // njLabel2
            // 
            this.njLabel2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel2.Location = new System.Drawing.Point(36, 44);
            this.njLabel2.TabIndex = 1;
            // 
            // njLabel3
            // 
            this.njLabel3.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel3.Location = new System.Drawing.Point(35, 112);
            this.njLabel3.TabIndex = 7;
            this.njLabel3.Text = "請求金額";
            // 
            // cmbGymKbn
            // 
            this.cmbGymKbn.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbGymKbn.Location = new System.Drawing.Point(121, 41);
            this.cmbGymKbn.Size = new System.Drawing.Size(297, 23);
            // 
            // txtKenmei
            // 
            this.txtKenmei.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtKenmei.Location = new System.Drawing.Point(121, 75);
            this.txtKenmei.TabIndex = 6;
            // 
            // pnlKKSKbn
            // 
            this.pnlKKSKbn.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlKKSKbn.Location = new System.Drawing.Point(442, 16);
            // 
            // pnlTmSp
            // 
            this.pnlTmSp.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pnlTmSp.Location = new System.Drawing.Point(520, 16);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Location = new System.Drawing.Point(481, 140);
            this.btnCancel.TabIndex = 13;
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOK.Location = new System.Drawing.Point(362, 140);
            this.btnOK.TabIndex = 12;
            // 
            // txtYymm
            // 
            this.txtYymm.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtYymm.Location = new System.Drawing.Point(249, 139);
            this.txtYymm.TabIndex = 11;
            // 
            // njLabel4
            // 
            this.njLabel4.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel4.Location = new System.Drawing.Point(36, 78);
            this.njLabel4.TabIndex = 5;
            this.njLabel4.Text = "件名";
            this.njLabel4.Visible = true;
            // 
            // txtKngk
            // 
            this.txtKngk.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtKngk.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtKngk.DecimalPlaces = 0;
            this.txtKngk.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtKngk.Location = new System.Drawing.Point(121, 109);
            this.txtKngk.Mask = "###,###,###,##0";
            this.txtKngk.MaxLength = 11;
            this.txtKngk.Name = "txtKngk";
            this.txtKngk.SignificantFigure = 12;
            this.txtKngk.Size = new System.Drawing.Size(118, 22);
            this.txtKngk.TabIndex = 8;
            this.txtKngk.Text = "999,999,999,999";
            this.txtKngk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKngk.Leave += new System.EventHandler(this.txtKngk_Leave);
            this.txtKngk.Enter += new System.EventHandler(this.txtKngk_Enter);
            // 
            // txtTax
            // 
            this.txtTax.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtTax.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTax.DecimalPlaces = 2;
            this.txtTax.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTax.Location = new System.Drawing.Point(121, 139);
            this.txtTax.Mask = "##0.00";
            this.txtTax.MaxLength = 6;
            this.txtTax.Name = "txtTax";
            this.txtTax.SignificantFigure = 12;
            this.txtTax.Size = new System.Drawing.Size(118, 22);
            this.txtTax.TabIndex = 10;
            this.txtTax.Text = "999.99";
            this.txtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTax.Leave += new System.EventHandler(this.txtTax_Leave);
            this.txtTax.Enter += new System.EventHandler(this.txtTax_Enter);
            // 
            // njLabel5
            // 
            this.njLabel5.AutoSize = true;
            this.njLabel5.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel5.Location = new System.Drawing.Point(35, 142);
            this.njLabel5.Name = "njLabel5";
            this.njLabel5.Size = new System.Drawing.Size(67, 15);
            this.njLabel5.TabIndex = 9;
            this.njLabel5.Text = "消費税率";
            // 
            // JyutyuRegisterTkd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.ClientSize = new System.Drawing.Size(606, 174);
            this.Controls.Add(this.njLabel5);
            this.Controls.Add(this.txtTax);
            this.Controls.Add(this.txtKngk);
            this.Name = "JyutyuRegisterTkd";
            this.Load += new System.EventHandler(this.JyutyuRegisterTkd_Load);
            this.Controls.SetChildIndex(this.njLabel4, 0);
            this.Controls.SetChildIndex(this.txtYymm, 0);
            this.Controls.SetChildIndex(this.njLabel1, 0);
            this.Controls.SetChildIndex(this.njLabel2, 0);
            this.Controls.SetChildIndex(this.njLabel3, 0);
            this.Controls.SetChildIndex(this.cmbGymKbn, 0);
            this.Controls.SetChildIndex(this.txtKenmei, 0);
            this.Controls.SetChildIndex(this.pnlKKSKbn, 0);
            this.Controls.SetChildIndex(this.pnlTmSp, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.txtKngk, 0);
            this.Controls.SetChildIndex(this.txtTax, 0);
            this.Controls.SetChildIndex(this.njLabel5, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtKenmei)).EndInit();
            this.pnlKKSKbn.ResumeLayout(false);
            this.pnlKKSKbn.PerformLayout();
            this.pnlTmSp.ResumeLayout(false);
            this.pnlTmSp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKngk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox txtKngk;
        private Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox txtTax;
        protected Isid.NJ.View.Widget.NJLabel njLabel5;
    }
}
