namespace Isid.KKH.Mac.View.Report
{
	partial class ReportMacLicensee
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
			if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportMacLicensee));
            this.njLabel3 = new Isid.NJ.View.Widget.NJLabel();
            this.btnXls = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnSrc = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.njLabel4 = new Isid.NJ.View.Widget.NJLabel();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dgvMain = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.dgvMain_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txtDnpFr = new Isid.NJ.View.Widget.NJMaskedTextBox();
            this.txtDnpTo = new Isid.NJ.View.Widget.NJMaskedTextBox();
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.njButton2 = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.txtYm = new Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl();
            this.lblYyyyMm = new Isid.NJ.View.Widget.NJLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // njLabel3
            // 
            this.njLabel3.AutoSize = true;
            this.njLabel3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel3.Location = new System.Drawing.Point(146, 15);
            this.njLabel3.Name = "njLabel3";
            this.njLabel3.Size = new System.Drawing.Size(53, 12);
            this.njLabel3.TabIndex = 16;
            this.njLabel3.Text = "伝票番号";
            // 
            // btnXls
            // 
            this.btnXls.BackColor = System.Drawing.Color.Transparent;
            this.btnXls.Enabled = false;
            this.btnXls.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnXls.FlatAppearance.BorderSize = 0;
            this.btnXls.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnXls.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnXls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXls.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnXls.Image = ((System.Drawing.Image)(resources.GetObject("btnXls.Image")));
            this.btnXls.Location = new System.Drawing.Point(458, 9);
            this.btnXls.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseDownImage")));
            this.btnXls.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseLeaveImage")));
            this.btnXls.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseMoveImage")));
            this.btnXls.Name = "btnXls";
            this.btnXls.Size = new System.Drawing.Size(113, 22);
            this.btnXls.TabIndex = 4;
            this.btnXls.Text = "    帳票出力";
            this.btnXls.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXls.UseVisualStyleBackColor = false;
            this.btnXls.Click += new System.EventHandler(this.btnXls_Click);
            // 
            // btnSrc
            // 
            this.btnSrc.BackColor = System.Drawing.Color.Transparent;
            this.btnSrc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSrc.FlatAppearance.BorderSize = 0;
            this.btnSrc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSrc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSrc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSrc.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSrc.Image = ((System.Drawing.Image)(resources.GetObject("btnSrc.Image")));
            this.btnSrc.Location = new System.Drawing.Point(339, 9);
            this.btnSrc.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseDownImage")));
            this.btnSrc.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseLeaveImage")));
            this.btnSrc.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseMoveImage")));
            this.btnSrc.Name = "btnSrc";
            this.btnSrc.Size = new System.Drawing.Size(113, 22);
            this.btnSrc.TabIndex = 3;
            this.btnSrc.Text = "検索";
            this.btnSrc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSrc.UseVisualStyleBackColor = false;
            this.btnSrc.Click += new System.EventHandler(this.btnSrc_Click);
            // 
            // njLabel4
            // 
            this.njLabel4.AutoSize = true;
            this.njLabel4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel4.Location = new System.Drawing.Point(259, 15);
            this.njLabel4.Name = "njLabel4";
            this.njLabel4.Size = new System.Drawing.Size(17, 12);
            this.njLabel4.TabIndex = 24;
            this.njLabel4.Text = "～";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.TableName = "Table1";
            // 
            // dgvMain
            // 
            this.dgvMain.AccessibleDescription = "dgvMain, Sheet1, Row 0, Column 0, ";
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.BackColor = System.Drawing.SystemColors.Control;
            this.dgvMain.EnableCustomSorting = false;
            this.dgvMain.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.dgvMain.Location = new System.Drawing.Point(5, 44);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvMain.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.dgvMain_Sheet1});
            this.dgvMain.Size = new System.Drawing.Size(960, 597);
            this.dgvMain.TabIndex = 29;
            this.dgvMain.TabStop = false;
            this.dgvMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // dgvMain_Sheet1
            // 
            this.dgvMain_Sheet1.Reset();
            this.dgvMain_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.dgvMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.dgvMain_Sheet1.ColumnCount = 14;
            this.dgvMain_Sheet1.RowCount = 0;
            this.dgvMain_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "取引先コード";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "ライセンシー社名";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "店舗コード";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "店舗名";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "売上明細No";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "住所";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "件名";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "代表者名";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "数量";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "単価";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "金額";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "伝票番号";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "分割コード";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "住所2";
            this.dgvMain_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.dgvMain_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(0).Label = "取引先コード";
            this.dgvMain_Sheet1.Columns.Get(0).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(0).Width = 90F;
            this.dgvMain_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(1).Label = "ライセンシー社名";
            this.dgvMain_Sheet1.Columns.Get(1).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(1).Width = 160F;
            this.dgvMain_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(2).Label = "店舗コード";
            this.dgvMain_Sheet1.Columns.Get(2).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(2).Width = 80F;
            this.dgvMain_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(3).Label = "店舗名";
            this.dgvMain_Sheet1.Columns.Get(3).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(3).Width = 199F;
            this.dgvMain_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(4).Label = "売上明細No";
            this.dgvMain_Sheet1.Columns.Get(4).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(4).Width = 140F;
            this.dgvMain_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(5).Label = "住所";
            this.dgvMain_Sheet1.Columns.Get(5).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(5).Width = 244F;
            this.dgvMain_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(6).Label = "件名";
            this.dgvMain_Sheet1.Columns.Get(6).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(6).Width = 226F;
            this.dgvMain_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(7).Label = "代表者名";
            this.dgvMain_Sheet1.Columns.Get(7).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(7).Width = 130F;
            this.dgvMain_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.dgvMain_Sheet1.Columns.Get(8).Label = "数量";
            this.dgvMain_Sheet1.Columns.Get(8).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.dgvMain_Sheet1.Columns.Get(9).Label = "単価";
            this.dgvMain_Sheet1.Columns.Get(9).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(9).Width = 120F;
            this.dgvMain_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.dgvMain_Sheet1.Columns.Get(10).Label = "金額";
            this.dgvMain_Sheet1.Columns.Get(10).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(10).Width = 120F;
            this.dgvMain_Sheet1.Columns.Get(11).Label = "伝票番号";
            this.dgvMain_Sheet1.Columns.Get(11).Width = 80F;
            this.dgvMain_Sheet1.DataAutoCellTypes = false;
            this.dgvMain_Sheet1.DataAutoHeadings = false;
            this.dgvMain_Sheet1.DataAutoSizeColumns = false;
            this.dgvMain_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.dgvMain_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.dgvMain_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.dgvMain_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.dgvMain.SetActiveViewport(0, 1, 0);
            // 
            // txtDnpFr
            // 
            this.txtDnpFr.AutoNextFocus = false;
            this.txtDnpFr.AutoSelect = true;
            this.txtDnpFr.AutoSelectByMouse = false;
            this.txtDnpFr.DiseditableBackColor = System.Drawing.Color.White;
            this.txtDnpFr.DiseditableForeColor = System.Drawing.Color.Black;
            this.txtDnpFr.Editable = true;
            this.txtDnpFr.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDnpFr.Location = new System.Drawing.Point(202, 11);
            this.txtDnpFr.Mask = "9999999";
            this.txtDnpFr.Name = "txtDnpFr";
            this.txtDnpFr.NotFocusWhenMouseClick = false;
            this.txtDnpFr.NotTabStopWhenNoEditable = true;
            this.txtDnpFr.Size = new System.Drawing.Size(51, 19);
            this.txtDnpFr.TabIndex = 1;
            this.txtDnpFr.TextChanged += new System.EventHandler(this.txtDnpFr_TextChanged);
            // 
            // txtDnpTo
            // 
            this.txtDnpTo.AutoNextFocus = false;
            this.txtDnpTo.AutoSelect = true;
            this.txtDnpTo.AutoSelectByMouse = false;
            this.txtDnpTo.DiseditableBackColor = System.Drawing.Color.White;
            this.txtDnpTo.DiseditableForeColor = System.Drawing.Color.Black;
            this.txtDnpTo.Editable = true;
            this.txtDnpTo.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDnpTo.Location = new System.Drawing.Point(282, 11);
            this.txtDnpTo.Mask = "9999999";
            this.txtDnpTo.Name = "txtDnpTo";
            this.txtDnpTo.NotFocusWhenMouseClick = false;
            this.txtDnpTo.NotTabStopWhenNoEditable = true;
            this.txtDnpTo.Size = new System.Drawing.Size(51, 19);
            this.txtDnpTo.TabIndex = 2;
            this.txtDnpTo.TextChanged += new System.EventHandler(this.txtDnpTo_TextChanged);
            // 
            // btnHlp
            // 
            this.btnHlp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHlp.BackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHlp.FlatAppearance.BorderSize = 0;
            this.btnHlp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHlp.Image = ((System.Drawing.Image)(resources.GetObject("btnHlp.Image")));
            this.btnHlp.Location = new System.Drawing.Point(885, 1);
            this.btnHlp.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseDownImage")));
            this.btnHlp.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseLeaveImage")));
            this.btnHlp.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseMoveImage")));
            this.btnHlp.Name = "btnHlp";
            this.btnHlp.Size = new System.Drawing.Size(37, 37);
            this.btnHlp.TabIndex = 5;
            this.btnHlp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHlp.UseVisualStyleBackColor = false;
            this.btnHlp.Click += new System.EventHandler(this.btnHlp_Click);
            // 
            // njButton2
            // 
            this.njButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.njButton2.BackColor = System.Drawing.Color.Transparent;
            this.njButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.njButton2.FlatAppearance.BorderSize = 0;
            this.njButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.njButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.njButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.njButton2.Image = ((System.Drawing.Image)(resources.GetObject("njButton2.Image")));
            this.njButton2.Location = new System.Drawing.Point(928, 1);
            this.njButton2.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("njButton2.MouseDownImage")));
            this.njButton2.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("njButton2.MouseLeaveImage")));
            this.njButton2.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("njButton2.MouseMoveImage")));
            this.njButton2.Name = "njButton2";
            this.njButton2.Size = new System.Drawing.Size(37, 37);
            this.njButton2.TabIndex = 6;
            this.njButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njButton2.UseVisualStyleBackColor = false;
            this.njButton2.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // txtYm
            // 
            this.txtYm.DisplayMode = Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.DisplayMode.COMBO;
            this.txtYm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtYm.Location = new System.Drawing.Point(47, 11);
            this.txtYm.MinimumSize = new System.Drawing.Size(82, 21);
            this.txtYm.Name = "txtYm";
            this.txtYm.Size = new System.Drawing.Size(82, 21);
            this.txtYm.TabIndex = 0;
            this.txtYm.ValidateDisableOnce = false;
            this.txtYm.Enter += new System.EventHandler(this.txtYm_Enter);
            // 
            // lblYyyyMm
            // 
            this.lblYyyyMm.AutoSize = true;
            this.lblYyyyMm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblYyyyMm.Location = new System.Drawing.Point(12, 15);
            this.lblYyyyMm.Name = "lblYyyyMm";
            this.lblYyyyMm.Size = new System.Drawing.Size(29, 12);
            this.lblYyyyMm.TabIndex = 32;
            this.lblYyyyMm.Text = "年月";
            // 
            // ReportMacLicensee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 666);
            this.Controls.Add(this.lblYyyyMm);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.njButton2);
            this.Controls.Add(this.txtDnpTo);
            this.Controls.Add(this.txtDnpFr);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.njLabel4);
            this.Controls.Add(this.btnSrc);
            this.Controls.Add(this.btnXls);
            this.Controls.Add(this.njLabel3);
            this.Controls.Add(this.txtYm);
            this.MinimumSize = new System.Drawing.Size(900, 300);
            this.Name = "ReportMacLicensee";
            this.Text = "ライセンシー向け一覧";
            this.Shown += new System.EventHandler(this.ReportMacLicensee_Shown);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.ReportMacLicensee_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.txtYm, 0);
            this.Controls.SetChildIndex(this.njLabel3, 0);
            this.Controls.SetChildIndex(this.btnXls, 0);
            this.Controls.SetChildIndex(this.btnSrc, 0);
            this.Controls.SetChildIndex(this.njLabel4, 0);
            this.Controls.SetChildIndex(this.dgvMain, 0);
            this.Controls.SetChildIndex(this.txtDnpFr, 0);
            this.Controls.SetChildIndex(this.txtDnpTo, 0);
            this.Controls.SetChildIndex(this.njButton2, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.lblYyyyMm, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        protected Isid.NJ.View.Widget.NJLabel njLabel3;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnXls;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnSrc;
        protected Isid.NJ.View.Widget.NJLabel njLabel4;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread dgvMain;
        private FarPoint.Win.Spread.SheetView dgvMain_Sheet1;
        private Isid.NJ.View.Widget.NJMaskedTextBox txtDnpFr;
        private Isid.NJ.View.Widget.NJMaskedTextBox txtDnpTo;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHlp;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton njButton2;
        private Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl txtYm;
        private Isid.NJ.View.Widget.NJLabel lblYyyyMm;
	}

}
