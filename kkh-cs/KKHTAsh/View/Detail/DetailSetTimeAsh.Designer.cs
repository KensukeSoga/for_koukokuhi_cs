namespace Isid.KKH.Ash.View.Detail
{
    partial class DetailSetTimeAsh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailSetTimeAsh));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpKyokuNetSu = new System.Windows.Forms.GroupBox();
            this.txtKyokuNetSu = new Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox();
            this.grpYoubi = new System.Windows.Forms.GroupBox();
            this.lblYoubi = new Isid.NJ.View.Widget.NJLabel();
            this.btnClear = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.dgbYoubi = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpHosouJikan = new System.Windows.Forms.GroupBox();
            this.dtpHosouJikanTo = new Isid.NJ.View.Widget.NJDateTimePicker();
            this.dtpHosouJikanFrom = new Isid.NJ.View.Widget.NJDateTimePicker();
            this.lblHosouJikan = new Isid.NJ.View.Widget.NJLabel();
            this.grpKikan = new System.Windows.Forms.GroupBox();
            this.lblKikan = new Isid.NJ.View.Widget.NJLabel();
            this.dtpKikanTo = new Isid.NJ.View.Widget.NJDateTimePicker();
            this.dtpKikanFrom = new Isid.NJ.View.Widget.NJDateTimePicker();
            this.btnOK = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnCancel = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.cmbKeyKyokuCd = new Isid.NJ.View.Widget.NJComboBox();
            this.grpKeyKyokuCd = new System.Windows.Forms.GroupBox();
            this.grpKyokuNetSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKyokuNetSu)).BeginInit();
            this.grpYoubi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbYoubi)).BeginInit();
            this.grpHosouJikan.SuspendLayout();
            this.grpKikan.SuspendLayout();
            this.grpKeyKyokuCd.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpKyokuNetSu
            // 
            this.grpKyokuNetSu.Controls.Add(this.txtKyokuNetSu);
            this.grpKyokuNetSu.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grpKyokuNetSu.Location = new System.Drawing.Point(10, 381);
            this.grpKyokuNetSu.Name = "grpKyokuNetSu";
            this.grpKyokuNetSu.Size = new System.Drawing.Size(110, 50);
            this.grpKyokuNetSu.TabIndex = 3;
            this.grpKyokuNetSu.TabStop = false;
            this.grpKyokuNetSu.Text = "局ネット数";
            // 
            // txtKyokuNetSu
            // 
            this.txtKyokuNetSu.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtKyokuNetSu.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtKyokuNetSu.DecimalPlaces = 0;
            this.txtKyokuNetSu.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKyokuNetSu.Location = new System.Drawing.Point(6, 19);
            this.txtKyokuNetSu.Mask = "##0";
            this.txtKyokuNetSu.Name = "txtKyokuNetSu";
            this.txtKyokuNetSu.SignificantFigure = 3;
            this.txtKyokuNetSu.Size = new System.Drawing.Size(92, 19);
            this.txtKyokuNetSu.TabIndex = 0;
            this.txtKyokuNetSu.Text = "999";
            this.txtKyokuNetSu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpYoubi
            // 
            this.grpYoubi.Controls.Add(this.lblYoubi);
            this.grpYoubi.Controls.Add(this.btnClear);
            this.grpYoubi.Controls.Add(this.dgbYoubi);
            this.grpYoubi.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.grpYoubi.Location = new System.Drawing.Point(10, 134);
            this.grpYoubi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpYoubi.Name = "grpYoubi";
            this.grpYoubi.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpYoubi.Size = new System.Drawing.Size(261, 240);
            this.grpYoubi.TabIndex = 2;
            this.grpYoubi.TabStop = false;
            this.grpYoubi.Text = "曜日";
            // 
            // lblYoubi
            // 
            this.lblYoubi.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.lblYoubi.Location = new System.Drawing.Point(34, 18);
            this.lblYoubi.Name = "lblYoubi";
            this.lblYoubi.Size = new System.Drawing.Size(192, 24);
            this.lblYoubi.TabIndex = 4;
            this.lblYoubi.Text = "9999/99";
            this.lblYoubi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Trebuchet MS", 9F);
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(141, 202);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnClear.MouseDownImage")));
            this.btnClear.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnClear.MouseLeaveImage")));
            this.btnClear.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnClear.MouseMoveImage")));
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(113, 22);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgbYoubi
            // 
            this.dgbYoubi.AllowUserToAddRows = false;
            this.dgbYoubi.AllowUserToDeleteRows = false;
            this.dgbYoubi.AllowUserToResizeColumns = false;
            this.dgbYoubi.AllowUserToResizeRows = false;
            this.dgbYoubi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbYoubi.ColumnHeadersVisible = false;
            this.dgbYoubi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgbYoubi.Location = new System.Drawing.Point(6, 44);
            this.dgbYoubi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgbYoubi.Name = "dgbYoubi";
            this.dgbYoubi.ReadOnly = true;
            this.dgbYoubi.RowHeadersVisible = false;
            this.dgbYoubi.RowTemplate.Height = 21;
            this.dgbYoubi.Size = new System.Drawing.Size(248, 150);
            this.dgbYoubi.StandardTab = true;
            this.dgbYoubi.TabIndex = 0;
            this.dgbYoubi.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgbYoubi_CellMouseClick);
            this.dgbYoubi.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgbYoubi_CellMouseDown);
            this.dgbYoubi.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgbYoubi_CellMouseMove);
            this.dgbYoubi.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgbYoubi_CellPainting);
            this.dgbYoubi.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgbYoubi_CellMouseDoubleClick);
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 35;
            // 
            // Column2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 35;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.Width = 35;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 35;
            // 
            // Column5
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column5.HeaderText = "5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.Width = 35;
            // 
            // Column6
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column6.HeaderText = "6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column6.Width = 35;
            // 
            // Column7
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column7.HeaderText = "7";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column7.Width = 35;
            // 
            // grpHosouJikan
            // 
            this.grpHosouJikan.Controls.Add(this.dtpHosouJikanTo);
            this.grpHosouJikan.Controls.Add(this.dtpHosouJikanFrom);
            this.grpHosouJikan.Controls.Add(this.lblHosouJikan);
            this.grpHosouJikan.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grpHosouJikan.Location = new System.Drawing.Point(10, 72);
            this.grpHosouJikan.Name = "grpHosouJikan";
            this.grpHosouJikan.Size = new System.Drawing.Size(234, 50);
            this.grpHosouJikan.TabIndex = 1;
            this.grpHosouJikan.TabStop = false;
            this.grpHosouJikan.Text = "放送時間";
            // 
            // dtpHosouJikanTo
            // 
            this.dtpHosouJikanTo.CustomFormat = "HH:mm";
            this.dtpHosouJikanTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHosouJikanTo.Location = new System.Drawing.Point(133, 18);
            this.dtpHosouJikanTo.Name = "dtpHosouJikanTo";
            this.dtpHosouJikanTo.ShowUpDown = true;
            this.dtpHosouJikanTo.Size = new System.Drawing.Size(93, 19);
            this.dtpHosouJikanTo.TabIndex = 1;
            // 
            // dtpHosouJikanFrom
            // 
            this.dtpHosouJikanFrom.CustomFormat = "HH:mm";
            this.dtpHosouJikanFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHosouJikanFrom.Location = new System.Drawing.Point(9, 18);
            this.dtpHosouJikanFrom.Name = "dtpHosouJikanFrom";
            this.dtpHosouJikanFrom.ShowUpDown = true;
            this.dtpHosouJikanFrom.Size = new System.Drawing.Size(93, 19);
            this.dtpHosouJikanFrom.TabIndex = 0;
            // 
            // lblHosouJikan
            // 
            this.lblHosouJikan.AutoSize = true;
            this.lblHosouJikan.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHosouJikan.Location = new System.Drawing.Point(108, 22);
            this.lblHosouJikan.Name = "lblHosouJikan";
            this.lblHosouJikan.Size = new System.Drawing.Size(17, 12);
            this.lblHosouJikan.TabIndex = 25;
            this.lblHosouJikan.Text = "～";
            // 
            // grpKikan
            // 
            this.grpKikan.Controls.Add(this.lblKikan);
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
            // lblKikan
            // 
            this.lblKikan.AutoSize = true;
            this.lblKikan.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKikan.Location = new System.Drawing.Point(108, 22);
            this.lblKikan.Name = "lblKikan";
            this.lblKikan.Size = new System.Drawing.Size(17, 12);
            this.lblKikan.TabIndex = 25;
            this.lblKikan.Text = "～";
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
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(41, 437);
            this.btnOK.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseDownImage")));
            this.btnOK.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseLeaveImage")));
            this.btnOK.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseMoveImage")));
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 22);
            this.btnOK.TabIndex = 5;
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
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(160, 437);
            this.btnCancel.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseDownImage")));
            this.btnCancel.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseLeaveImage")));
            this.btnCancel.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseMoveImage")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 22);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "   キャンセル";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbKeyKyokuCd
            // 
            this.cmbKeyKyokuCd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKeyKyokuCd.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKeyKyokuCd.FormattingEnabled = true;
            this.cmbKeyKyokuCd.Location = new System.Drawing.Point(6, 19);
            this.cmbKeyKyokuCd.Name = "cmbKeyKyokuCd";
            this.cmbKeyKyokuCd.Size = new System.Drawing.Size(128, 20);
            this.cmbKeyKyokuCd.TabIndex = 0;
            // 
            // grpKeyKyokuCd
            // 
            this.grpKeyKyokuCd.Controls.Add(this.cmbKeyKyokuCd);
            this.grpKeyKyokuCd.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grpKeyKyokuCd.Location = new System.Drawing.Point(128, 381);
            this.grpKeyKyokuCd.Name = "grpKeyKyokuCd";
            this.grpKeyKyokuCd.Size = new System.Drawing.Size(145, 50);
            this.grpKeyKyokuCd.TabIndex = 4;
            this.grpKeyKyokuCd.TabStop = false;
            this.grpKeyKyokuCd.Text = "キー局コード";
            // 
            // DetailSetTimeAsh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 476);
            this.Controls.Add(this.grpKeyKyokuCd);
            this.Controls.Add(this.grpKyokuNetSu);
            this.Controls.Add(this.grpYoubi);
            this.Controls.Add(this.grpHosouJikan);
            this.Controls.Add(this.grpKikan);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.EnterKeyFocusEnabled = true;
            this.Name = "DetailSetTimeAsh";
            this.Text = "詳細設定";
            this.Load += new System.EventHandler(this.DetailSetTimeAsh_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.DetailSetTimeAsh_ProcessAffterNavigating);
            this.grpKyokuNetSu.ResumeLayout(false);
            this.grpKyokuNetSu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKyokuNetSu)).EndInit();
            this.grpYoubi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgbYoubi)).EndInit();
            this.grpHosouJikan.ResumeLayout(false);
            this.grpHosouJikan.PerformLayout();
            this.grpKikan.ResumeLayout(false);
            this.grpKikan.PerformLayout();
            this.grpKeyKyokuCd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox grpKyokuNetSu;
        private Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox txtKyokuNetSu;
        private System.Windows.Forms.GroupBox grpYoubi;
        private Isid.NJ.View.Widget.NJLabel lblYoubi;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnClear;
        private System.Windows.Forms.DataGridView dgbYoubi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        protected System.Windows.Forms.GroupBox grpHosouJikan;
        protected Isid.NJ.View.Widget.NJLabel lblHosouJikan;
        protected System.Windows.Forms.GroupBox grpKikan;
        protected Isid.NJ.View.Widget.NJLabel lblKikan;
        private Isid.NJ.View.Widget.NJDateTimePicker dtpKikanTo;
        private Isid.NJ.View.Widget.NJDateTimePicker dtpKikanFrom;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnOK;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnCancel;
        protected Isid.NJ.View.Widget.NJComboBox cmbKeyKyokuCd;
        protected System.Windows.Forms.GroupBox grpKeyKyokuCd;
        private Isid.NJ.View.Widget.NJDateTimePicker dtpHosouJikanFrom;
        private Isid.NJ.View.Widget.NJDateTimePicker dtpHosouJikanTo;

    }
}