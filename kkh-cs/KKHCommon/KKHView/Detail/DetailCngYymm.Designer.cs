namespace Isid.KKH.Common.KKHView.Detail
{
    partial class DetailCngYymm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailCngYymm));
            this.njLabel1 = new Isid.NJ.View.Widget.NJLabel();
            this.njLabel2 = new Isid.NJ.View.Widget.NJLabel();
            this.BtnCancel = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnOK = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.txtYymm = new Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl();
            this.SuspendLayout();
            // 
            // njLabel1
            // 
            this.njLabel1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel1.Location = new System.Drawing.Point(25, 22);
            this.njLabel1.Name = "njLabel1";
            this.njLabel1.Size = new System.Drawing.Size(245, 23);
            this.njLabel1.TabIndex = 0;
            this.njLabel1.Text = "変更後の請求年月を指定してください。";
            // 
            // njLabel2
            // 
            this.njLabel2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel2.Location = new System.Drawing.Point(25, 62);
            this.njLabel2.Name = "njLabel2";
            this.njLabel2.Size = new System.Drawing.Size(43, 21);
            this.njLabel2.TabIndex = 1;
            this.njLabel2.Text = "年月";
            this.njLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnCancel.FlatAppearance.BorderSize = 0;
            this.BtnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancel.Image")));
            this.BtnCancel.Location = new System.Drawing.Point(162, 101);
            this.BtnCancel.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("BtnCancel.MouseDownImage")));
            this.BtnCancel.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("BtnCancel.MouseLeaveImage")));
            this.BtnCancel.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("BtnCancel.MouseMoveImage")));
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(113, 22);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "   キャンセル";
            this.BtnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
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
            this.btnOK.Location = new System.Drawing.Point(43, 101);
            this.btnOK.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseDownImage")));
            this.btnOK.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseLeaveImage")));
            this.btnOK.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseMoveImage")));
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 22);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtYymm
            // 
            this.txtYymm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtYymm.Location = new System.Drawing.Point(74, 62);
            this.txtYymm.MinimumSize = new System.Drawing.Size(82, 20);
            this.txtYymm.Name = "txtYymm";
            this.txtYymm.Size = new System.Drawing.Size(82, 21);
            this.txtYymm.TabIndex = 1;
            this.txtYymm.ValidateDisableOnce = false;
            this.txtYymm.Leave += new System.EventHandler(this.txtYymm_Leave);
            // 
            // DetailCngYymm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(282, 139);
            this.Controls.Add(this.txtYymm);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.njLabel2);
            this.Controls.Add(this.njLabel1);
            this.Name = "DetailCngYymm";
            this.Text = "請求年月変更";
            this.Shown += new System.EventHandler(this.DetailCngYymm_Shown);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.DetailCngYymm_ProcessAffterNavigating);
            this.ResumeLayout(false);

        }

        #endregion

        private Isid.NJ.View.Widget.NJLabel njLabel1;
        private Isid.NJ.View.Widget.NJLabel njLabel2;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton BtnCancel;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnOK;
        private Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl txtYymm;
    }
}
