namespace Isid.KKH.Common.KKHView.Detail
{
    partial class JyutyuRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JyutyuRegister));
            this.njLabel1 = new Isid.NJ.View.Widget.NJLabel();
            this.njLabel2 = new Isid.NJ.View.Widget.NJLabel();
            this.njLabel3 = new Isid.NJ.View.Widget.NJLabel();
            this.cmbGymKbn = new Isid.KKH.Common.KKHView.Common.Control.KkhComboBox();
            this.txtKenmei = new Isid.NJ.View.Widget.NJTextBox();
            this.pnlKKSKbn = new Isid.KKH.Common.KKHView.Common.Control.KkhPanel();
            this.rdoKgi = new Isid.NJ.View.Widget.NJRadioButton();
            this.rdoJpn = new Isid.NJ.View.Widget.NJRadioButton();
            this.pnlTmSp = new Isid.KKH.Common.KKHView.Common.Control.KkhPanel();
            this.rdoSpot = new Isid.NJ.View.Widget.NJRadioButton();
            this.rdoTime = new Isid.NJ.View.Widget.NJRadioButton();
            this.btnCancel = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnOK = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.njLabel4 = new Isid.NJ.View.Widget.NJLabel();
            this.txtYymm = new Isid.NJ.View.Widget.NJMaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtKenmei)).BeginInit();
            this.pnlKKSKbn.SuspendLayout();
            this.pnlTmSp.SuspendLayout();
            this.SuspendLayout();
            // 
            // njLabel1
            // 
            this.njLabel1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel1.Location = new System.Drawing.Point(12, 9);
            this.njLabel1.Name = "njLabel1";
            this.njLabel1.Size = new System.Drawing.Size(218, 24);
            this.njLabel1.TabIndex = 0;
            this.njLabel1.Text = "業務区分と件名を決めてください";
            // 
            // njLabel2
            // 
            this.njLabel2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.njLabel2.Location = new System.Drawing.Point(12, 54);
            this.njLabel2.Name = "njLabel2";
            this.njLabel2.Size = new System.Drawing.Size(79, 22);
            this.njLabel2.TabIndex = 9;
            this.njLabel2.Text = "業務区分";
            // 
            // njLabel3
            // 
            this.njLabel3.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.njLabel3.Location = new System.Drawing.Point(12, 93);
            this.njLabel3.Name = "njLabel3";
            this.njLabel3.Size = new System.Drawing.Size(79, 21);
            this.njLabel3.TabIndex = 10;
            this.njLabel3.Text = "件名";
            // 
            // cmbGymKbn
            // 
            this.cmbGymKbn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGymKbn.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGymKbn.FormattingEnabled = true;
            this.cmbGymKbn.Location = new System.Drawing.Point(97, 50);
            this.cmbGymKbn.Name = "cmbGymKbn";
            this.cmbGymKbn.Size = new System.Drawing.Size(260, 23);
            this.cmbGymKbn.TabIndex = 0;
            this.cmbGymKbn.SelectedIndexChanged += new System.EventHandler(this.cmbGymKbn_SelectedIndexChanged);
            // 
            // txtKenmei
            // 
            this.txtKenmei.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtKenmei.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtKenmei.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKenmei.Location = new System.Drawing.Point(97, 93);
            this.txtKenmei.MaxLength = 60;
            this.txtKenmei.Name = "txtKenmei";
            this.txtKenmei.Size = new System.Drawing.Size(430, 22);
            this.txtKenmei.TabIndex = 5;
            this.txtKenmei.TextChanged += new System.EventHandler(this.txtKenmei_TextChanged);
            this.txtKenmei.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKenmei_KeyPress);
            // 
            // pnlKKSKbn
            // 
            this.pnlKKSKbn.Controls.Add(this.rdoKgi);
            this.pnlKKSKbn.Controls.Add(this.rdoJpn);
            this.pnlKKSKbn.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlKKSKbn.Location = new System.Drawing.Point(373, 23);
            this.pnlKKSKbn.Name = "pnlKKSKbn";
            this.pnlKKSKbn.Size = new System.Drawing.Size(72, 53);
            this.pnlKKSKbn.TabIndex = 3;
            // 
            // rdoKgi
            // 
            this.rdoKgi.AutoSize = true;
            this.rdoKgi.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoKgi.Location = new System.Drawing.Point(4, 32);
            this.rdoKgi.Name = "rdoKgi";
            this.rdoKgi.Size = new System.Drawing.Size(55, 19);
            this.rdoKgi.TabIndex = 2;
            this.rdoKgi.Text = "国際";
            this.rdoKgi.UseVisualStyleBackColor = true;
            // 
            // rdoJpn
            // 
            this.rdoJpn.AutoSize = true;
            this.rdoJpn.Checked = true;
            this.rdoJpn.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoJpn.Location = new System.Drawing.Point(4, 4);
            this.rdoJpn.Name = "rdoJpn";
            this.rdoJpn.Size = new System.Drawing.Size(55, 19);
            this.rdoJpn.TabIndex = 1;
            this.rdoJpn.TabStop = true;
            this.rdoJpn.Text = "国内";
            this.rdoJpn.UseVisualStyleBackColor = true;
            this.rdoJpn.CheckedChanged += new System.EventHandler(this.rdoJpn_CheckedChanged);
            // 
            // pnlTmSp
            // 
            this.pnlTmSp.Controls.Add(this.rdoSpot);
            this.pnlTmSp.Controls.Add(this.rdoTime);
            this.pnlTmSp.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTmSp.Location = new System.Drawing.Point(452, 23);
            this.pnlTmSp.Name = "pnlTmSp";
            this.pnlTmSp.Size = new System.Drawing.Size(74, 53);
            this.pnlTmSp.TabIndex = 4;
            // 
            // rdoSpot
            // 
            this.rdoSpot.AutoSize = true;
            this.rdoSpot.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSpot.Location = new System.Drawing.Point(4, 32);
            this.rdoSpot.Name = "rdoSpot";
            this.rdoSpot.Size = new System.Drawing.Size(68, 19);
            this.rdoSpot.TabIndex = 4;
            this.rdoSpot.Text = "スポット";
            this.rdoSpot.UseVisualStyleBackColor = true;
            // 
            // rdoTime
            // 
            this.rdoTime.AutoSize = true;
            this.rdoTime.Checked = true;
            this.rdoTime.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTime.Location = new System.Drawing.Point(4, 4);
            this.rdoTime.Name = "rdoTime";
            this.rdoTime.Size = new System.Drawing.Size(58, 19);
            this.rdoTime.TabIndex = 3;
            this.rdoTime.TabStop = true;
            this.rdoTime.Text = "タイム";
            this.rdoTime.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(414, 133);
            this.btnCancel.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseDownImage")));
            this.btnCancel.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseLeaveImage")));
            this.btnCancel.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseMoveImage")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 22);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "   キャンセル";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(288, 134);
            this.btnOK.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseDownImage")));
            this.btnOK.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseLeaveImage")));
            this.btnOK.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseMoveImage")));
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 22);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // njLabel4
            // 
            this.njLabel4.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.njLabel4.Location = new System.Drawing.Point(12, 134);
            this.njLabel4.Name = "njLabel4";
            this.njLabel4.Size = new System.Drawing.Size(79, 21);
            this.njLabel4.TabIndex = 8;
            this.njLabel4.Text = "年月";
            this.njLabel4.Visible = false;
            // 
            // txtYymm
            // 
            this.txtYymm.AutoNextFocus = false;
            this.txtYymm.AutoSelect = true;
            this.txtYymm.AutoSelectByMouse = false;
            this.txtYymm.DiseditableBackColor = System.Drawing.Color.White;
            this.txtYymm.DiseditableForeColor = System.Drawing.Color.Black;
            this.txtYymm.Editable = true;
            this.txtYymm.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYymm.Location = new System.Drawing.Point(97, 134);
            this.txtYymm.Mask = "0000/00";
            this.txtYymm.Name = "txtYymm";
            this.txtYymm.NotFocusWhenMouseClick = false;
            this.txtYymm.NotTabStopWhenNoEditable = true;
            this.txtYymm.Size = new System.Drawing.Size(100, 22);
            this.txtYymm.TabIndex = 6;
            this.txtYymm.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtYymm.Visible = false;
            // 
            // JyutyuRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.ClientSize = new System.Drawing.Size(536, 168);
            this.Controls.Add(this.txtYymm);
            this.Controls.Add(this.njLabel4);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlTmSp);
            this.Controls.Add(this.pnlKKSKbn);
            this.Controls.Add(this.txtKenmei);
            this.Controls.Add(this.cmbGymKbn);
            this.Controls.Add(this.njLabel3);
            this.Controls.Add(this.njLabel2);
            this.Controls.Add(this.njLabel1);
            this.Name = "JyutyuRegister";
            this.Text = "新規作成";
            this.Shown += new System.EventHandler(this.JyutyuRegister_Shown);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.JyutyuRegister_ProcessAffterNavigating);
            ((System.ComponentModel.ISupportInitialize)(this.txtKenmei)).EndInit();
            this.pnlKKSKbn.ResumeLayout(false);
            this.pnlKKSKbn.PerformLayout();
            this.pnlTmSp.ResumeLayout(false);
            this.pnlTmSp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Isid.NJ.View.Widget.NJLabel njLabel1;
        protected Isid.NJ.View.Widget.NJLabel njLabel2;
        protected Isid.NJ.View.Widget.NJLabel njLabel3;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhComboBox cmbGymKbn;
        protected Isid.NJ.View.Widget.NJTextBox txtKenmei;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhPanel pnlKKSKbn;
        protected Isid.NJ.View.Widget.NJRadioButton rdoKgi;
        protected Isid.NJ.View.Widget.NJRadioButton rdoJpn;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhPanel pnlTmSp;
        protected Isid.NJ.View.Widget.NJRadioButton rdoSpot;
        protected Isid.NJ.View.Widget.NJRadioButton rdoTime;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnCancel;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnOK;
        protected Isid.NJ.View.Widget.NJMaskedTextBox txtYymm;
        protected Isid.NJ.View.Widget.NJLabel njLabel4;

    }
}
