namespace Isid.KKH.Common.KKHView.Top
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
            this.txtTan = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtTkicd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTkinm = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCan = new System.Windows.Forms.Button();
            this._dsLogin = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this._dsLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTan
            // 
            this.txtTan.Location = new System.Drawing.Point(104, 18);
            this.txtTan.Name = "txtTan";
            this.txtTan.Size = new System.Drawing.Size(80, 21);
            this.txtTan.TabIndex = 0;
            this.txtTan.Text = "12345";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(104, 56);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(80, 21);
            this.txtPass.TabIndex = 1;
            this.txtPass.Text = "pass";
            // 
            // txtTkicd
            // 
            this.txtTkicd.Location = new System.Drawing.Point(104, 92);
            this.txtTkicd.MaxLength = 10;
            this.txtTkicd.Name = "txtTkicd";
            this.txtTkicd.Size = new System.Drawing.Size(96, 21);
            this.txtTkicd.TabIndex = 2;
            this.txtTkicd.Text = "0088260101";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "担当者コード";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "得意先コード";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "得意先名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "パスワード";
            // 
            // txtTkinm
            // 
            this.txtTkinm.Location = new System.Drawing.Point(104, 126);
            this.txtTkinm.Name = "txtTkinm";
            this.txtTkinm.Size = new System.Drawing.Size(161, 21);
            this.txtTkinm.TabIndex = 7;
            this.txtTkinm.Text = "アコム";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(81, 177);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(78, 30);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCan
            // 
            this.btnCan.Location = new System.Drawing.Point(187, 177);
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(78, 30);
            this.btnCan.TabIndex = 9;
            this.btnCan.Text = "CANCEL";
            this.btnCan.UseVisualStyleBackColor = true;
            this.btnCan.Click += new System.EventHandler(this.btnCan_Click);
            // 
            // _dsLogin
            // 
            this._dsLogin.DataSetName = "Login";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 238);
            this.Controls.Add(this.btnCan);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtTkinm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTkicd);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtTan);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoginForm";
            this.Text = "ログイン";
            ((System.ComponentModel.ISupportInitialize)(this._dsLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTan;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtTkicd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTkinm;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCan;
        private System.Data.DataSet _dsLogin;
    }
}