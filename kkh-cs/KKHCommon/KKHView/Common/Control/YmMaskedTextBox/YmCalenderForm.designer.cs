namespace Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox
{
    internal partial class YmCalenderForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitleBack = new Isid.NJ.View.Widget.NJLabel();
            this.btnPre = new Isid.NJ.View.Widget.NJButton();
            this.btnNext = new Isid.NJ.View.Widget.NJButton();
            this.lblYYYY = new Isid.NJ.View.Widget.NJLabel();
            this.panel1 = new Isid.KKH.Common.KKHView.Common.Control.KkhPanel();
            this.dgvMM = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMM)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitleBack
            // 
            this.lblTitleBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTitleBack.Location = new System.Drawing.Point(0, 1);
            this.lblTitleBack.Name = "lblTitleBack";
            this.lblTitleBack.Size = new System.Drawing.Size(137, 27);
            this.lblTitleBack.TabIndex = 1;
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(2, 5);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(29, 19);
            this.btnPre.TabIndex = 2;
            this.btnPre.Text = "<";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(105, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(29, 19);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblYYYY
            // 
            this.lblYYYY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblYYYY.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblYYYY.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblYYYY.Location = new System.Drawing.Point(51, 6);
            this.lblYYYY.Name = "lblYYYY";
            this.lblYYYY.Size = new System.Drawing.Size(35, 19);
            this.lblYYYY.TabIndex = 4;
            this.lblYYYY.Text = "2012";
            this.lblYYYY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dgvMM);
            this.panel1.Controls.Add(this.lblYYYY);
            this.panel1.Controls.Add(this.btnPre);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.lblTitleBack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 140);
            this.panel1.TabIndex = 5;
            // 
            // dgvMM
            // 
            this.dgvMM.AllowUserToAddRows = false;
            this.dgvMM.AllowUserToDeleteRows = false;
            this.dgvMM.AllowUserToResizeColumns = false;
            this.dgvMM.AllowUserToResizeRows = false;
            this.dgvMM.BackgroundColor = System.Drawing.Color.White;
            this.dgvMM.ColumnHeadersVisible = false;
            this.dgvMM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvMM.Location = new System.Drawing.Point(0, 28);
            this.dgvMM.MultiSelect = false;
            this.dgvMM.Name = "dgvMM";
            this.dgvMM.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvMM.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMM.RowTemplate.Height = 29;
            this.dgvMM.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMM.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvMM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMM.Size = new System.Drawing.Size(138, 112);
            this.dgvMM.TabIndex = 5;
            this.dgvMM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMM_CellClick);
            this.dgvMM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvMM_KeyDown);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 45;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 45;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 45;
            // 
            // YmCalenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(138, 140);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(138, 140);
            this.MinimumSize = new System.Drawing.Size(138, 140);
            this.Name = "YmCalenderForm";
            this.Text = "PopUpWindow";
            this.Load += new System.EventHandler(this.PopUpWindow_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Isid.NJ.View.Widget.NJLabel lblTitleBack;
        private Isid.NJ.View.Widget.NJButton btnPre;
        private Isid.NJ.View.Widget.NJButton btnNext;
        private Isid.NJ.View.Widget.NJLabel lblYYYY;
        private Isid.KKH.Common.KKHView.Common.Control.KkhPanel panel1;
        private System.Windows.Forms.DataGridView dgvMM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;

    }
}