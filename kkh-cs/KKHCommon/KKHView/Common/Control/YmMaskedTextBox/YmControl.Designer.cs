namespace Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox
{
    partial class YmControl
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

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCalendar = new Isid.NJ.View.Widget.NJButton();
            this.txtYM = new Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmMaskedTextBox();
            this.cmbYM = new Isid.KKH.Common.KKHView.Common.Control.KkhComboBox();
            this.SuspendLayout();
            // 
            // btnCalendar
            // 
            this.btnCalendar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCalendar.Location = new System.Drawing.Point(62, 0);
            this.btnCalendar.MaximumSize = new System.Drawing.Size(20, 20);
            this.btnCalendar.MinimumSize = new System.Drawing.Size(20, 20);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Size = new System.Drawing.Size(20, 20);
            this.btnCalendar.TabIndex = 1;
            this.btnCalendar.TabStop = false;
            this.btnCalendar.UseVisualStyleBackColor = true;
            this.btnCalendar.Click += new System.EventHandler(this.btnCalendar_Click);
            // 
            // txtYM
            // 
            this.txtYM.AutoNextFocus = false;
            this.txtYM.AutoSelect = true;
            this.txtYM.AutoSelectByMouse = false;
            this.txtYM.DiseditableBackColor = System.Drawing.Color.White;
            this.txtYM.DiseditableForeColor = System.Drawing.Color.Black;
            this.txtYM.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtYM.Editable = true;
            this.txtYM.Location = new System.Drawing.Point(0, 0);
            this.txtYM.Name = "txtYM";
            this.txtYM.NotFocusWhenMouseClick = false;
            this.txtYM.NotTabStopWhenNoEditable = true;
            this.txtYM.Size = new System.Drawing.Size(62, 19);
            this.txtYM.TabIndex = 0;
            this.txtYM.ValidateDisableOnce = false;
            // 
            // cmbYM
            // 
            this.cmbYM.FormattingEnabled = true;
            this.cmbYM.Location = new System.Drawing.Point(0, 0);
            this.cmbYM.MaxLength = 7;
            this.cmbYM.Name = "cmbYM";
            this.cmbYM.Size = new System.Drawing.Size(82, 20);
            this.cmbYM.TabIndex = 2;
            this.cmbYM.Visible = false;
            this.cmbYM.Validating += new System.ComponentModel.CancelEventHandler(this.cmbYM_Validating);
            this.cmbYM.Leave += new System.EventHandler(this.cmbYM_Leave);
            this.cmbYM.Enter += new System.EventHandler(this.cmbYM_Enter);
            this.cmbYM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbYM_KeyPress);
            this.cmbYM.TextChanged += new System.EventHandler(this.cmbYM_TextChanged);
            // 
            // YmControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnCalendar);
            this.Controls.Add(this.txtYM);
            this.Controls.Add(this.cmbYM);
            this.MinimumSize = new System.Drawing.Size(82, 21);
            this.Name = "YmControl";
            this.Size = new System.Drawing.Size(82, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.NJ.View.Widget.NJButton btnCalendar;
        private KkhComboBox cmbYM;
        private YmMaskedTextBox txtYM;
    }
}
