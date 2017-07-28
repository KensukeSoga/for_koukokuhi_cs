namespace Isid.KKH.Toh.View.Report
{
    partial class ReportToh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportToh));
            this.txtKbn = new Isid.NJ.View.Widget.NJTextBox();
            this.njLabel3 = new Isid.NJ.View.Widget.NJLabel();
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnEnd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnXls = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnSrc = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.njLabel4 = new Isid.NJ.View.Widget.NJLabel();
            this.rdoKenmei = new Isid.NJ.View.Widget.NJRadioButton();
            this.rdoBaitai = new Isid.NJ.View.Widget.NJRadioButton();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dgvMain = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.dgvMain_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.dgvMain_Sheet2 = new FarPoint.Win.Spread.SheetView();
            this.dtpYyyyMmDd = new Isid.NJ.View.Widget.NJDateTimePicker();
            this.lblYyyyMm = new Isid.NJ.View.Widget.NJLabel();
            ((System.ComponentModel.ISupportInitialize)(this.txtKbn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain_Sheet2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKbn
            // 
            this.txtKbn.BackColor = System.Drawing.SystemColors.Window;
            this.txtKbn.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtKbn.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtKbn.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtKbn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtKbn.Location = new System.Drawing.Point(252, 8);
            this.txtKbn.MaxLength = 1;
            this.txtKbn.Name = "txtKbn";
            this.txtKbn.Size = new System.Drawing.Size(29, 19);
            this.txtKbn.TabIndex = 3;
            this.txtKbn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKbn.TextChanged += new System.EventHandler(this.condChg);
            // 
            // njLabel3
            // 
            this.njLabel3.AutoSize = true;
            this.njLabel3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel3.Location = new System.Drawing.Point(193, 12);
            this.njLabel3.Name = "njLabel3";
            this.njLabel3.Size = new System.Drawing.Size(53, 12);
            this.njLabel3.TabIndex = 16;
            this.njLabel3.Text = "納品区分";
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
            this.btnHlp.Location = new System.Drawing.Point(800, 6);
            this.btnHlp.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseDownImage")));
            this.btnHlp.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseLeaveImage")));
            this.btnHlp.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseMoveImage")));
            this.btnHlp.Name = "btnHlp";
            this.btnHlp.Size = new System.Drawing.Size(37, 37);
            this.btnHlp.TabIndex = 8;
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
            this.btnEnd.Location = new System.Drawing.Point(843, 6);
            this.btnEnd.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseDownImage")));
            this.btnEnd.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseLeaveImage")));
            this.btnEnd.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseMoveImage")));
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(37, 37);
            this.btnEnd.TabIndex = 9;
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
            this.btnXls.Location = new System.Drawing.Point(414, 14);
            this.btnXls.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseDownImage")));
            this.btnXls.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseLeaveImage")));
            this.btnXls.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseMoveImage")));
            this.btnXls.Name = "btnXls";
            this.btnXls.Size = new System.Drawing.Size(113, 22);
            this.btnXls.TabIndex = 7;
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
            this.btnSrc.Location = new System.Drawing.Point(295, 14);
            this.btnSrc.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseDownImage")));
            this.btnSrc.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseLeaveImage")));
            this.btnSrc.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseMoveImage")));
            this.btnSrc.Name = "btnSrc";
            this.btnSrc.Size = new System.Drawing.Size(113, 22);
            this.btnSrc.TabIndex = 6;
            this.btnSrc.Text = "検索";
            this.btnSrc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSrc.UseVisualStyleBackColor = false;
            this.btnSrc.Click += new System.EventHandler(this.btnSrc_Click);
            // 
            // njLabel4
            // 
            this.njLabel4.AutoSize = true;
            this.njLabel4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel4.Location = new System.Drawing.Point(193, 38);
            this.njLabel4.Name = "njLabel4";
            this.njLabel4.Size = new System.Drawing.Size(93, 12);
            this.njLabel4.TabIndex = 24;
            this.njLabel4.Text = "（1：映画 2：演劇）";
            // 
            // rdoKenmei
            // 
            this.rdoKenmei.AutoSize = true;
            this.rdoKenmei.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoKenmei.Location = new System.Drawing.Point(14, 38);
            this.rdoKenmei.Name = "rdoKenmei";
            this.rdoKenmei.Size = new System.Drawing.Size(59, 16);
            this.rdoKenmei.TabIndex = 4;
            this.rdoKenmei.Text = "件名別";
            this.rdoKenmei.UseVisualStyleBackColor = true;
            this.rdoKenmei.CheckedChanged += new System.EventHandler(this.rdoKenmei_CheckedChanged);
            // 
            // rdoBaitai
            // 
            this.rdoBaitai.AutoSize = true;
            this.rdoBaitai.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rdoBaitai.Location = new System.Drawing.Point(79, 38);
            this.rdoBaitai.Name = "rdoBaitai";
            this.rdoBaitai.Size = new System.Drawing.Size(59, 16);
            this.rdoBaitai.TabIndex = 5;
            this.rdoBaitai.Text = "媒体別";
            this.rdoBaitai.UseVisualStyleBackColor = true;
            this.rdoBaitai.CheckedChanged += new System.EventHandler(this.rdoBaitai_CheckedChanged);
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
            this.dgvMain.AccessibleDescription = "dgvMain, Sheet2, Row 0, Column 0, ";
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain.EnableCustomSorting = false;
            this.dgvMain.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMain.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.dgvMain.Location = new System.Drawing.Point(6, 60);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvMain.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.dgvMain_Sheet1,
            this.dgvMain_Sheet2});
            this.dgvMain.Size = new System.Drawing.Size(879, 581);
            this.dgvMain.TabIndex = 10;
            this.dgvMain.TabStop = false;
            this.dgvMain.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.dgvMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.dgvMain.ActiveSheetIndex = 1;
            // 
            // dgvMain_Sheet1
            // 
            this.dgvMain_Sheet1.Reset();
            this.dgvMain_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.dgvMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.dgvMain_Sheet1.ColumnCount = 7;
            this.dgvMain_Sheet1.RowCount = 0;
            this.dgvMain_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "件名";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "媒体名";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "朝・夕";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "掲載日";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "スペース";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "単価";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "料金";
            this.dgvMain_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.dgvMain_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(0).Label = "件名";
            this.dgvMain_Sheet1.Columns.Get(0).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(0).Width = 400F;
            this.dgvMain_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(1).Label = "媒体名";
            this.dgvMain_Sheet1.Columns.Get(1).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(1).Width = 200F;
            this.dgvMain_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(2).Label = "朝・夕";
            this.dgvMain_Sheet1.Columns.Get(2).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(2).Width = 44F;
            this.dgvMain_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(3).Label = "掲載日";
            this.dgvMain_Sheet1.Columns.Get(3).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(3).Width = 70F;
            this.dgvMain_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(4).Label = "スペース";
            this.dgvMain_Sheet1.Columns.Get(4).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(4).Width = 51F;
            this.dgvMain_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.dgvMain_Sheet1.Columns.Get(5).Label = "単価";
            this.dgvMain_Sheet1.Columns.Get(5).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(5).Width = 90F;
            this.dgvMain_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.dgvMain_Sheet1.Columns.Get(6).Label = "料金";
            this.dgvMain_Sheet1.Columns.Get(6).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(6).Width = 90F;
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
            // dgvMain_Sheet2
            // 
            this.dgvMain_Sheet2.Reset();
            this.dgvMain_Sheet2.SheetName = "Sheet2";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.dgvMain_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.dgvMain_Sheet2.ColumnCount = 7;
            this.dgvMain_Sheet2.RowCount = 0;
            this.dgvMain_Sheet2.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 0).Value = "媒体名";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 1).Value = "件名";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 2).Value = "朝・夕";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 3).Value = "掲載日";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 4).Value = "スペース";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 5).Value = "単価";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 6).Value = "料金";
            this.dgvMain_Sheet2.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet2.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain_Sheet2.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.dgvMain_Sheet2.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet2.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet2.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet2.Columns.Get(0).Label = "媒体名";
            this.dgvMain_Sheet2.Columns.Get(0).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(0).Width = 200F;
            this.dgvMain_Sheet2.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet2.Columns.Get(1).Label = "件名";
            this.dgvMain_Sheet2.Columns.Get(1).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(1).Width = 400F;
            this.dgvMain_Sheet2.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet2.Columns.Get(2).Label = "朝・夕";
            this.dgvMain_Sheet2.Columns.Get(2).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(2).Width = 44F;
            this.dgvMain_Sheet2.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet2.Columns.Get(3).Label = "掲載日";
            this.dgvMain_Sheet2.Columns.Get(3).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(3).Width = 70F;
            this.dgvMain_Sheet2.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet2.Columns.Get(4).Label = "スペース";
            this.dgvMain_Sheet2.Columns.Get(4).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(4).Width = 51F;
            this.dgvMain_Sheet2.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.dgvMain_Sheet2.Columns.Get(5).Label = "単価";
            this.dgvMain_Sheet2.Columns.Get(5).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(5).Width = 90F;
            this.dgvMain_Sheet2.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.dgvMain_Sheet2.Columns.Get(6).Label = "料金";
            this.dgvMain_Sheet2.Columns.Get(6).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(6).Width = 90F;
            this.dgvMain_Sheet2.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet2.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet2.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain_Sheet2.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.dgvMain_Sheet2.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet2.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet2.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain_Sheet2.SheetCornerStyle.Parent = "CornerDefault";
            this.dgvMain_Sheet2.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.dgvMain.SetActiveViewport(1, 1, 0);
            // 
            // dtpYyyyMmDd
            // 
            this.dtpYyyyMmDd.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpYyyyMmDd.Location = new System.Drawing.Point(59, 9);
            this.dtpYyyyMmDd.Name = "dtpYyyyMmDd";
            this.dtpYyyyMmDd.Size = new System.Drawing.Size(115, 19);
            this.dtpYyyyMmDd.TabIndex = 38;
            this.dtpYyyyMmDd.ValueChanged += new System.EventHandler(this.condChg);
            // 
            // lblYyyyMm
            // 
            this.lblYyyyMm.AutoSize = true;
            this.lblYyyyMm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblYyyyMm.Location = new System.Drawing.Point(12, 14);
            this.lblYyyyMm.Name = "lblYyyyMm";
            this.lblYyyyMm.Size = new System.Drawing.Size(41, 12);
            this.lblYyyyMm.TabIndex = 37;
            this.lblYyyyMm.Text = "年月日";
            // 
            // ReportToh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 666);
            this.Controls.Add(this.dtpYyyyMmDd);
            this.Controls.Add(this.lblYyyyMm);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.rdoBaitai);
            this.Controls.Add(this.rdoKenmei);
            this.Controls.Add(this.njLabel4);
            this.Controls.Add(this.btnSrc);
            this.Controls.Add(this.btnXls);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.njLabel3);
            this.Controls.Add(this.txtKbn);
            this.MinimumSize = new System.Drawing.Size(700, 300);
            this.Name = "ReportToh";
            this.Text = "請求明細一覧";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.ReportToh_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.txtKbn, 0);
            this.Controls.SetChildIndex(this.njLabel3, 0);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.btnXls, 0);
            this.Controls.SetChildIndex(this.btnSrc, 0);
            this.Controls.SetChildIndex(this.njLabel4, 0);
            this.Controls.SetChildIndex(this.rdoKenmei, 0);
            this.Controls.SetChildIndex(this.rdoBaitai, 0);
            this.Controls.SetChildIndex(this.dgvMain, 0);
            this.Controls.SetChildIndex(this.lblYyyyMm, 0);
            this.Controls.SetChildIndex(this.dtpYyyyMmDd, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtKbn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain_Sheet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Isid.NJ.View.Widget.NJTextBox txtKbn;
        protected Isid.NJ.View.Widget.NJLabel njLabel3;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHlp;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnEnd;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnXls;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnSrc;
        protected Isid.NJ.View.Widget.NJLabel njLabel4;
        private Isid.NJ.View.Widget.NJRadioButton rdoKenmei;
        private Isid.NJ.View.Widget.NJRadioButton rdoBaitai;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread dgvMain;
        private FarPoint.Win.Spread.SheetView dgvMain_Sheet1;
        private FarPoint.Win.Spread.SheetView dgvMain_Sheet2;
        private Isid.NJ.View.Widget.NJDateTimePicker dtpYyyyMmDd;
        private Isid.NJ.View.Widget.NJLabel lblYyyyMm;
    }
}