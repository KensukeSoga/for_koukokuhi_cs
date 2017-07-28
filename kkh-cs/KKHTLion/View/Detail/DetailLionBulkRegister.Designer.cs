namespace Isid.KKH.Lion.View.Detail
{
    partial class DetailLionBulkRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailLionBulkRegister));
            this.cmbBrand = new Isid.KKH.Common.KKHView.Common.Control.KkhComboBox();
            this.btnOK = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnCancel = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.njLabel1 = new Isid.NJ.View.Widget.NJLabel();
            this.SuspendLayout();
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(25, 41);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(443, 20);
            this.cmbBrand.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(236, 80);
            this.btnOK.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseDownImage")));
            this.btnOK.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseLeaveImage")));
            this.btnOK.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseMoveImage")));
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 22);
            this.btnOK.TabIndex = 1;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(355, 80);
            this.btnCancel.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseDownImage")));
            this.btnCancel.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseLeaveImage")));
            this.btnCancel.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseMoveImage")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 22);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "   キャンセル";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // njLabel1
            // 
            this.njLabel1.AutoSize = true;
            this.njLabel1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel1.Location = new System.Drawing.Point(22, 9);
            this.njLabel1.Name = "njLabel1";
            this.njLabel1.Size = new System.Drawing.Size(161, 15);
            this.njLabel1.TabIndex = 3;
            this.njLabel1.Text = "ブランドを指定して下さい。";
            // 
            // DetailLionBulkRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.ClientSize = new System.Drawing.Size(478, 122);
            this.Controls.Add(this.njLabel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cmbBrand);
            this.Name = "DetailLionBulkRegister";
            this.Text = "一括登録";
            this.Load += new System.EventHandler(this.DetailLionBulkRegister_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.DetailBulkRegister_ProcessAffterNavigating);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.KKH.Common.KKHView.Common.Control.KkhComboBox cmbBrand;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnOK;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnCancel;
        private Isid.NJ.View.Widget.NJLabel njLabel1;
    }
}
