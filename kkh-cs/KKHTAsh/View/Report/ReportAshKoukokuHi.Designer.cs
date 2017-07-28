namespace Isid.KKH.Ash.View.Report
{
    partial class ReportAshKoukokuHi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportAshKoukokuHi));
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnEnd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnXls = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnSrc = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.lblKensu = new Isid.NJ.View.Widget.NJLabel();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.koukokuMain = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.koukokuMain_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.mediaCmb = new Isid.NJ.View.Widget.NJComboBox();
            this.njLabel2 = new Isid.NJ.View.Widget.NJLabel();
            this.lblYyyyMm = new Isid.NJ.View.Widget.NJLabel();
            this.dtpYyyyMmDd = new Isid.NJ.View.Widget.NJDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.koukokuMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.koukokuMain_Sheet1)).BeginInit();
            this.SuspendLayout();
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
            this.btnHlp.Location = new System.Drawing.Point(880, 1);
            this.btnHlp.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseDownImage")));
            this.btnHlp.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseLeaveImage")));
            this.btnHlp.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseMoveImage")));
            this.btnHlp.Name = "btnHlp";
            this.btnHlp.Size = new System.Drawing.Size(37, 37);
            this.btnHlp.TabIndex = 6;
            this.btnHlp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHlp.UseVisualStyleBackColor = false;
            this.btnHlp.Click += new System.EventHandler(this.btnHlp_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnd.BackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEnd.FlatAppearance.BorderSize = 0;
            this.btnEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEnd.Image")));
            this.btnEnd.Location = new System.Drawing.Point(923, 1);
            this.btnEnd.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseDownImage")));
            this.btnEnd.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseLeaveImage")));
            this.btnEnd.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseMoveImage")));
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(37, 37);
            this.btnEnd.TabIndex = 7;
            this.btnEnd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
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
            this.btnXls.Location = new System.Drawing.Point(549, 10);
            this.btnXls.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseDownImage")));
            this.btnXls.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseLeaveImage")));
            this.btnXls.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseMoveImage")));
            this.btnXls.Name = "btnXls";
            this.btnXls.Size = new System.Drawing.Size(113, 22);
            this.btnXls.TabIndex = 5;
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
            this.btnSrc.Location = new System.Drawing.Point(180, 8);
            this.btnSrc.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseDownImage")));
            this.btnSrc.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseLeaveImage")));
            this.btnSrc.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseMoveImage")));
            this.btnSrc.Name = "btnSrc";
            this.btnSrc.Size = new System.Drawing.Size(113, 22);
            this.btnSrc.TabIndex = 4;
            this.btnSrc.Text = "検索";
            this.btnSrc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSrc.UseVisualStyleBackColor = false;
            this.btnSrc.Click += new System.EventHandler(this.btnSrc_Click);
            // 
            // lblKensu
            // 
            this.lblKensu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKensu.AutoSize = true;
            this.lblKensu.Location = new System.Drawing.Point(732, 652);
            this.lblKensu.Name = "lblKensu";
            this.lblKensu.Size = new System.Drawing.Size(23, 12);
            this.lblKensu.TabIndex = 28;
            this.lblKensu.Text = "0件";
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
            // koukokuMain
            // 
            this.koukokuMain.AccessibleDescription = "koukokuMain, Sheet1";
            this.koukokuMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.koukokuMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.koukokuMain.EnableCustomSorting = false;
            this.koukokuMain.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.koukokuMain.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.koukokuMain.Location = new System.Drawing.Point(5, 44);
            this.koukokuMain.Name = "koukokuMain";
            this.koukokuMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.koukokuMain.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.koukokuMain_Sheet1});
            this.koukokuMain.Size = new System.Drawing.Size(963, 599);
            this.koukokuMain.TabIndex = 8;
            this.koukokuMain.TabStop = false;
            this.koukokuMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // koukokuMain_Sheet1
            // 
            this.koukokuMain_Sheet1.Reset();
            this.koukokuMain_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.koukokuMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.koukokuMain_Sheet1.ColumnCount = 16;
            this.koukokuMain_Sheet1.RowCount = 0;
            this.koukokuMain_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.koukokuMain_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "No,";
            this.koukokuMain_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "請求書番号";
            this.koukokuMain_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "旧媒体";
            this.koukokuMain_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "媒体";
            this.koukokuMain_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "旧媒体コード";
            this.koukokuMain_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "媒体コード";
            this.koukokuMain_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "金額";
            this.koukokuMain_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "局";
            this.koukokuMain_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "局コード";
            this.koukokuMain_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "品種";
            this.koukokuMain_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "品種コード";
            this.koukokuMain_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "代理店";
            this.koukokuMain_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "代理店コード";
            this.koukokuMain_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "番組";
            this.koukokuMain_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "番組コード";
            this.koukokuMain_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "件名";
            this.koukokuMain_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.koukokuMain_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.koukokuMain_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.koukokuMain_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.koukokuMain_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.koukokuMain_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.koukokuMain_Sheet1.Columns.Get(0).Label = "No,";
            this.koukokuMain_Sheet1.Columns.Get(0).Locked = true;
            this.koukokuMain_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(0).Width = 40F;
            this.koukokuMain_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.koukokuMain_Sheet1.Columns.Get(1).Label = "請求書番号";
            this.koukokuMain_Sheet1.Columns.Get(1).Locked = true;
            this.koukokuMain_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(1).Width = 190F;
            this.koukokuMain_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.koukokuMain_Sheet1.Columns.Get(2).Label = "旧媒体";
            this.koukokuMain_Sheet1.Columns.Get(2).Locked = true;
            this.koukokuMain_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(2).Visible = false;
            this.koukokuMain_Sheet1.Columns.Get(2).Width = 180F;
            this.koukokuMain_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.koukokuMain_Sheet1.Columns.Get(3).Label = "媒体";
            this.koukokuMain_Sheet1.Columns.Get(3).Locked = true;
            this.koukokuMain_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(3).Width = 180F;
            this.koukokuMain_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(4).Label = "旧媒体コード";
            this.koukokuMain_Sheet1.Columns.Get(4).Locked = true;
            this.koukokuMain_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(4).Visible = false;
            this.koukokuMain_Sheet1.Columns.Get(4).Width = 68F;
            this.koukokuMain_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(5).Label = "媒体コード";
            this.koukokuMain_Sheet1.Columns.Get(5).Locked = true;
            this.koukokuMain_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(5).Width = 68F;
            this.koukokuMain_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.koukokuMain_Sheet1.Columns.Get(6).Label = "金額";
            this.koukokuMain_Sheet1.Columns.Get(6).Locked = true;
            this.koukokuMain_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(6).Width = 120F;
            this.koukokuMain_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.koukokuMain_Sheet1.Columns.Get(7).Label = "局";
            this.koukokuMain_Sheet1.Columns.Get(7).Locked = true;
            this.koukokuMain_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(7).Width = 150F;
            this.koukokuMain_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(8).Label = "局コード";
            this.koukokuMain_Sheet1.Columns.Get(8).Locked = true;
            this.koukokuMain_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(8).Width = 62F;
            this.koukokuMain_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.koukokuMain_Sheet1.Columns.Get(9).Label = "品種";
            this.koukokuMain_Sheet1.Columns.Get(9).Locked = true;
            this.koukokuMain_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(9).Width = 150F;
            this.koukokuMain_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(10).Label = "品種コード";
            this.koukokuMain_Sheet1.Columns.Get(10).Locked = true;
            this.koukokuMain_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(10).Width = 74F;
            this.koukokuMain_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(11).Label = "代理店";
            this.koukokuMain_Sheet1.Columns.Get(11).Locked = true;
            this.koukokuMain_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(11).Width = 85F;
            this.koukokuMain_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(12).Label = "代理店コード";
            this.koukokuMain_Sheet1.Columns.Get(12).Locked = true;
            this.koukokuMain_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(12).Width = 80F;
            this.koukokuMain_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.koukokuMain_Sheet1.Columns.Get(13).Label = "番組";
            this.koukokuMain_Sheet1.Columns.Get(13).Locked = true;
            this.koukokuMain_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(13).Width = 150F;
            this.koukokuMain_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(14).Label = "番組コード";
            this.koukokuMain_Sheet1.Columns.Get(14).Locked = true;
            this.koukokuMain_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(14).Width = 66F;
            this.koukokuMain_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.koukokuMain_Sheet1.Columns.Get(15).Label = "件名";
            this.koukokuMain_Sheet1.Columns.Get(15).Locked = true;
            this.koukokuMain_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.koukokuMain_Sheet1.Columns.Get(15).Width = 450F;
            this.koukokuMain_Sheet1.DataAutoCellTypes = false;
            this.koukokuMain_Sheet1.DataAutoHeadings = false;
            this.koukokuMain_Sheet1.DataAutoSizeColumns = false;
            this.koukokuMain_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.koukokuMain_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.koukokuMain_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.koukokuMain_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.koukokuMain_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.koukokuMain_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.koukokuMain_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.koukokuMain_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.koukokuMain_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.koukokuMain_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.koukokuMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.koukokuMain.SetActiveViewport(0, 1, 0);
            // 
            // mediaCmb
            // 
            this.mediaCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mediaCmb.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.mediaCmb.FormattingEnabled = true;
            this.mediaCmb.Location = new System.Drawing.Point(382, 12);
            this.mediaCmb.Name = "mediaCmb";
            this.mediaCmb.Size = new System.Drawing.Size(150, 20);
            this.mediaCmb.TabIndex = 3;
            // 
            // njLabel2
            // 
            this.njLabel2.AutoSize = true;
            this.njLabel2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel2.Location = new System.Drawing.Point(323, 15);
            this.njLabel2.Name = "njLabel2";
            this.njLabel2.Size = new System.Drawing.Size(53, 12);
            this.njLabel2.TabIndex = 31;
            this.njLabel2.Text = "出力媒体";
            // 
            // lblYyyyMm
            // 
            this.lblYyyyMm.AutoSize = true;
            this.lblYyyyMm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblYyyyMm.Location = new System.Drawing.Point(7, 14);
            this.lblYyyyMm.Name = "lblYyyyMm";
            this.lblYyyyMm.Size = new System.Drawing.Size(41, 12);
            this.lblYyyyMm.TabIndex = 34;
            this.lblYyyyMm.Text = "年月日";
            // 
            // dtpYyyyMmDd
            // 
            this.dtpYyyyMmDd.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpYyyyMmDd.Location = new System.Drawing.Point(59, 11);
            this.dtpYyyyMmDd.Name = "dtpYyyyMmDd";
            this.dtpYyyyMmDd.Size = new System.Drawing.Size(115, 19);
            this.dtpYyyyMmDd.TabIndex = 35;
            this.dtpYyyyMmDd.ValueChanged += new System.EventHandler(this.dtpYyyyMmDd_ValueChanged);
            // 
            // ReportAshKoukokuHi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 668);
            this.Controls.Add(this.dtpYyyyMmDd);
            this.Controls.Add(this.lblYyyyMm);
            this.Controls.Add(this.njLabel2);
            this.Controls.Add(this.mediaCmb);
            this.Controls.Add(this.koukokuMain);
            this.Controls.Add(this.lblKensu);
            this.Controls.Add(this.btnSrc);
            this.Controls.Add(this.btnXls);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.btnEnd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 300);
            this.Name = "ReportAshKoukokuHi";
            this.Text = "広告費明細書";
            this.Shown += new System.EventHandler(this.ReportAshKoukokuHi_Shown);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.ReportAshKoukokuHi_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.btnXls, 0);
            this.Controls.SetChildIndex(this.btnSrc, 0);
            this.Controls.SetChildIndex(this.lblKensu, 0);
            this.Controls.SetChildIndex(this.koukokuMain, 0);
            this.Controls.SetChildIndex(this.mediaCmb, 0);
            this.Controls.SetChildIndex(this.njLabel2, 0);
            this.Controls.SetChildIndex(this.lblYyyyMm, 0);
            this.Controls.SetChildIndex(this.dtpYyyyMmDd, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.koukokuMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.koukokuMain_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHlp;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnEnd;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnXls;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnSrc;
        protected Isid.NJ.View.Widget.NJLabel lblKensu;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread koukokuMain;
        private FarPoint.Win.Spread.SheetView koukokuMain_Sheet1;
        private Isid.NJ.View.Widget.NJComboBox mediaCmb;
        private Isid.NJ.View.Widget.NJLabel njLabel2;
        private Isid.NJ.View.Widget.NJLabel lblYyyyMm;
        private Isid.NJ.View.Widget.NJDateTimePicker dtpYyyyMmDd;
    }
}
