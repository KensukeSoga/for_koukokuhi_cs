namespace Isid.KKH.Ash.View.Detail
{
    partial class DetailSetOthersAsh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailSetOthersAsh));
            this.grpRosenNm = new System.Windows.Forms.GroupBox();
            this.txtRosenNm = new Isid.NJ.View.Widget.NJTextBox();
            this.grpKikan = new System.Windows.Forms.GroupBox();
            this.njLabel1 = new Isid.NJ.View.Widget.NJLabel();
            this.dtpKikanTo = new Isid.NJ.View.Widget.NJDateTimePicker();
            this.dtpKikanFrom = new Isid.NJ.View.Widget.NJDateTimePicker();
            this.btnOK = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnCancel = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.grpRosenNm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRosenNm)).BeginInit();
            this.grpKikan.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRosenNm
            // 
            this.grpRosenNm.Controls.Add(this.txtRosenNm);
            this.grpRosenNm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grpRosenNm.Location = new System.Drawing.Point(10, 72);
            this.grpRosenNm.Name = "grpRosenNm";
            this.grpRosenNm.Size = new System.Drawing.Size(275, 50);
            this.grpRosenNm.TabIndex = 1;
            this.grpRosenNm.TabStop = false;
            this.grpRosenNm.Text = "路線・駅名称";
            // 
            // txtRosenNm
            // 
            this.txtRosenNm.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtRosenNm.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRosenNm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRosenNm.Location = new System.Drawing.Point(8, 18);
            this.txtRosenNm.MaxLength = 40;
            this.txtRosenNm.Name = "txtRosenNm";
            this.txtRosenNm.Size = new System.Drawing.Size(259, 19);
            this.txtRosenNm.TabIndex = 2;
            this.txtRosenNm.Text = "ＷＷＷＷＷＷＷＷＷＷＷＷＷＷＷＷＷＷＷＷ";
            this.txtRosenNm.TextChanged += new System.EventHandler(this.txtRosenNm_TextChanged);
            // 
            // grpKikan
            // 
            this.grpKikan.Controls.Add(this.njLabel1);
            this.grpKikan.Controls.Add(this.dtpKikanTo);
            this.grpKikan.Controls.Add(this.dtpKikanFrom);
            this.grpKikan.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grpKikan.Location = new System.Drawing.Point(10, 10);
            this.grpKikan.Name = "grpKikan";
            this.grpKikan.Size = new System.Drawing.Size(234, 50);
            this.grpKikan.TabIndex = 0;
            this.grpKikan.TabStop = false;
            this.grpKikan.Text = "期間";
            // 
            // njLabel1
            // 
            this.njLabel1.AutoSize = true;
            this.njLabel1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.njLabel1.Location = new System.Drawing.Point(108, 22);
            this.njLabel1.Name = "njLabel1";
            this.njLabel1.Size = new System.Drawing.Size(17, 12);
            this.njLabel1.TabIndex = 25;
            this.njLabel1.Text = "～";
            // 
            // dtpKikanTo
            // 
            this.dtpKikanTo.CustomFormat = "";
            this.dtpKikanTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpKikanTo.Location = new System.Drawing.Point(133, 18);
            this.dtpKikanTo.Name = "dtpKikanTo";
            this.dtpKikanTo.Size = new System.Drawing.Size(93, 19);
            this.dtpKikanTo.TabIndex = 1;
            this.dtpKikanTo.Leave += new System.EventHandler(this.dtpKikanTo_Leave);
            // 
            // dtpKikanFrom
            // 
            this.dtpKikanFrom.CustomFormat = "";
            this.dtpKikanFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpKikanFrom.Location = new System.Drawing.Point(8, 18);
            this.dtpKikanFrom.Name = "dtpKikanFrom";
            this.dtpKikanFrom.Size = new System.Drawing.Size(93, 19);
            this.dtpKikanFrom.TabIndex = 0;
            this.dtpKikanFrom.Leave += new System.EventHandler(this.dtpKikanFrom_Leave);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(54, 135);
            this.btnOK.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseDownImage")));
            this.btnOK.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseLeaveImage")));
            this.btnOK.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseMoveImage")));
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 22);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(173, 135);
            this.btnCancel.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseDownImage")));
            this.btnCancel.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseLeaveImage")));
            this.btnCancel.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseMoveImage")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 22);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "   キャンセル";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DetailSetOthersAsh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 169);
            this.Controls.Add(this.grpRosenNm);
            this.Controls.Add(this.grpKikan);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.EnterKeyFocusEnabled = true;
            this.Name = "DetailSetOthersAsh";
            this.Text = "詳細設定";
            this.Load += new System.EventHandler(this.DetailSetOthersAsh_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.DetailSetOthersAsh_ProcessAffterNavigating);
            this.grpRosenNm.ResumeLayout(false);
            this.grpRosenNm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRosenNm)).EndInit();
            this.grpKikan.ResumeLayout(false);
            this.grpKikan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox grpRosenNm;
        protected System.Windows.Forms.GroupBox grpKikan;
        protected Isid.NJ.View.Widget.NJLabel njLabel1;
        private Isid.NJ.View.Widget.NJDateTimePicker dtpKikanTo;
        private Isid.NJ.View.Widget.NJDateTimePicker dtpKikanFrom;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnOK;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnCancel;
        protected Isid.NJ.View.Widget.NJTextBox txtRosenNm;

    }
}