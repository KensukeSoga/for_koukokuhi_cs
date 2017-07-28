namespace Isid.KKH.Main.View.Login
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.txtTan = new Isid.NJ.View.Widget.NJTextBox();
            this.txtPass = new Isid.NJ.View.Widget.NJTextBox();
            this.txtTkicd = new Isid.NJ.View.Widget.NJTextBox();
            this.lblTitleTan = new Isid.NJ.View.Widget.NJLabel();
            this.lblTitleTkicd = new Isid.NJ.View.Widget.NJLabel();
            this.lblTitleTkinm = new Isid.NJ.View.Widget.NJLabel();
            this.lblTitlePass = new Isid.NJ.View.Widget.NJLabel();
            this.btnOk = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnCan = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this._dsLogin = new System.Data.DataSet();
            this.lblTkinm = new Isid.NJ.View.Widget.NJLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtTan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTkicd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dsLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTan
            // 
            this.txtTan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTan.BeforeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTan.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTan.Enabled = false;
            this.txtTan.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTan.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtTan.Location = new System.Drawing.Point(156, 16);
            this.txtTan.MaxLength = 5;
            this.txtTan.Name = "txtTan";
            this.txtTan.Size = new System.Drawing.Size(91, 23);
            this.txtTan.TabIndex = 1;
            this.txtTan.TextChanged += new System.EventHandler(this.txtTan_TextChanged);
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPass.BeforeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPass.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPass.Enabled = false;
            this.txtPass.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPass.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtPass.Location = new System.Drawing.Point(156, 50);
            this.txtPass.MaxLength = 4;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(91, 23);
            this.txtPass.TabIndex = 2;
            // 
            // txtTkicd
            // 
            this.txtTkicd.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtTkicd.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTkicd.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTkicd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtTkicd.Location = new System.Drawing.Point(156, 83);
            this.txtTkicd.MaxLength = 8;
            this.txtTkicd.Name = "txtTkicd";
            this.txtTkicd.Size = new System.Drawing.Size(109, 23);
            this.txtTkicd.TabIndex = 3;
            this.txtTkicd.TextChanged += new System.EventHandler(this.txtTkicd_TextChanged);
            // 
            // lblTitleTan
            // 
            this.lblTitleTan.AutoSize = true;
            this.lblTitleTan.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitleTan.Location = new System.Drawing.Point(14, 19);
            this.lblTitleTan.Name = "lblTitleTan";
            this.lblTitleTan.Size = new System.Drawing.Size(92, 16);
            this.lblTitleTan.TabIndex = 3;
            this.lblTitleTan.Text = "担当者コード";
            // 
            // lblTitleTkicd
            // 
            this.lblTitleTkicd.AutoSize = true;
            this.lblTitleTkicd.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitleTkicd.Location = new System.Drawing.Point(14, 86);
            this.lblTitleTkicd.Name = "lblTitleTkicd";
            this.lblTitleTkicd.Size = new System.Drawing.Size(92, 16);
            this.lblTitleTkicd.TabIndex = 4;
            this.lblTitleTkicd.Text = "得意先コード";
            // 
            // lblTitleTkinm
            // 
            this.lblTitleTkinm.AutoSize = true;
            this.lblTitleTkinm.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitleTkinm.Location = new System.Drawing.Point(14, 118);
            this.lblTitleTkinm.Name = "lblTitleTkinm";
            this.lblTitleTkinm.Size = new System.Drawing.Size(72, 16);
            this.lblTitleTkinm.TabIndex = 5;
            this.lblTitleTkinm.Text = "得意先名";
            // 
            // lblTitlePass
            // 
            this.lblTitlePass.AutoSize = true;
            this.lblTitlePass.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitlePass.Location = new System.Drawing.Point(14, 53);
            this.lblTitlePass.Name = "lblTitlePass";
            this.lblTitlePass.Size = new System.Drawing.Size(70, 16);
            this.lblTitlePass.TabIndex = 6;
            this.lblTitlePass.Text = "パスワード";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(126, 177);
            this.btnOk.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseDownImage")));
            this.btnOk.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseLeaveImage")));
            this.btnOk.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseMoveImage")));
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(113, 22);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCan
            // 
            this.btnCan.BackColor = System.Drawing.Color.Transparent;
            this.btnCan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCan.FlatAppearance.BorderSize = 0;
            this.btnCan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCan.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCan.Image = ((System.Drawing.Image)(resources.GetObject("btnCan.Image")));
            this.btnCan.Location = new System.Drawing.Point(245, 178);
            this.btnCan.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCan.MouseDownImage")));
            this.btnCan.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnCan.MouseLeaveImage")));
            this.btnCan.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCan.MouseMoveImage")));
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(113, 22);
            this.btnCan.TabIndex = 5;
            this.btnCan.Text = "   キャンセル";
            this.btnCan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCan.UseVisualStyleBackColor = false;
            this.btnCan.Click += new System.EventHandler(this.btnCan_Click);
            // 
            // _dsLogin
            // 
            this._dsLogin.DataSetName = "Login";
            // 
            // lblTkinm
            // 
            this.lblTkinm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTkinm.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTkinm.Location = new System.Drawing.Point(156, 115);
            this.lblTkinm.Name = "lblTkinm";
            this.lblTkinm.Size = new System.Drawing.Size(202, 38);
            this.lblTkinm.TabIndex = 11;
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(385, 215);
            this.Controls.Add(this.lblTkinm);
            this.Controls.Add(this.btnCan);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblTitlePass);
            this.Controls.Add(this.lblTitleTkinm);
            this.Controls.Add(this.lblTitleTkicd);
            this.Controls.Add(this.lblTitleTan);
            this.Controls.Add(this.txtTkicd);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtTan);
            this.EnterKeyFocusEnabled = true;
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoginForm";
            this.Text = "ログイン";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTkicd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dsLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.NJ.View.Widget.NJTextBox txtTan;
        private Isid.NJ.View.Widget.NJTextBox txtPass;
        private Isid.NJ.View.Widget.NJTextBox txtTkicd;
        private Isid.NJ.View.Widget.NJLabel lblTitleTan;
        private Isid.NJ.View.Widget.NJLabel lblTitleTkicd;
        private Isid.NJ.View.Widget.NJLabel lblTitleTkinm;
        private Isid.NJ.View.Widget.NJLabel lblTitlePass;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnOk;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnCan;
        private System.Data.DataSet _dsLogin;
        private Isid.NJ.View.Widget.NJLabel lblTkinm;
    }
}