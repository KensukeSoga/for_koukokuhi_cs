namespace Isid.KKH.Mac.View.Report
{
    partial class ReportMacPurchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportMacPurchase));
            this.njLabel3 = new Isid.NJ.View.Widget.NJLabel();
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnEnd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnXls = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnSrc = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.njLabel4 = new Isid.NJ.View.Widget.NJLabel();
            this.lblKensu = new Isid.NJ.View.Widget.NJLabel();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dgvMain = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.dgvMain_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txtDnpFr = new Isid.NJ.View.Widget.NJMaskedTextBox();
            this.txtDnpTo = new Isid.NJ.View.Widget.NJMaskedTextBox();
            this.chkNoSplit = new Isid.NJ.View.Widget.NJRadioButton();
            this.chkSplit = new Isid.NJ.View.Widget.NJRadioButton();
            this.grpTerritory = new System.Windows.Forms.GroupBox();
            this.chkOther = new Isid.NJ.View.Widget.NJCheckBox();
            this.chkCenter = new Isid.NJ.View.Widget.NJCheckBox();
            this.chkKansai = new Isid.NJ.View.Widget.NJCheckBox();
            this.chkKanto = new Isid.NJ.View.Widget.NJCheckBox();
            this.grpRePrint = new System.Windows.Forms.GroupBox();
            this.chkRePrint = new Isid.NJ.View.Widget.NJCheckBox();
            this.txtTenpoCd = new Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox();
            this.njLabel7 = new Isid.NJ.View.Widget.NJLabel();
            this.njLabel2 = new Isid.NJ.View.Widget.NJLabel();
            this.txtYmRe = new Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl();
            this.grpSplit = new System.Windows.Forms.GroupBox();
            this.njLabel8 = new Isid.NJ.View.Widget.NJLabel();
            this.txtYm = new Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain_Sheet1)).BeginInit();
            this.grpTerritory.SuspendLayout();
            this.grpRePrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenpoCd)).BeginInit();
            this.grpSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // njLabel3
            // 
            this.njLabel3.AutoSize = true;
            this.njLabel3.Location = new System.Drawing.Point(268, 27);
            this.njLabel3.Name = "njLabel3";
            this.njLabel3.Size = new System.Drawing.Size(53, 12);
            this.njLabel3.TabIndex = 16;
            this.njLabel3.Text = "伝票番号";
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
            this.btnHlp.Location = new System.Drawing.Point(885, 6);
            this.btnHlp.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseDownImage")));
            this.btnHlp.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseLeaveImage")));
            this.btnHlp.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseMoveImage")));
            this.btnHlp.Name = "btnHlp";
            this.btnHlp.Size = new System.Drawing.Size(37, 37);
            this.btnHlp.TabIndex = 7;
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
            this.btnEnd.Location = new System.Drawing.Point(928, 6);
            this.btnEnd.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseDownImage")));
            this.btnEnd.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseLeaveImage")));
            this.btnEnd.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseMoveImage")));
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(37, 37);
            this.btnEnd.TabIndex = 8;
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
            this.btnXls.Image = ((System.Drawing.Image)(resources.GetObject("btnXls.Image")));
            this.btnXls.Location = new System.Drawing.Point(626, 20);
            this.btnXls.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseDownImage")));
            this.btnXls.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseLeaveImage")));
            this.btnXls.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseMoveImage")));
            this.btnXls.Name = "btnXls";
            this.btnXls.Size = new System.Drawing.Size(113, 22);
            this.btnXls.TabIndex = 6;
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
            this.btnSrc.Location = new System.Drawing.Point(507, 20);
            this.btnSrc.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseDownImage")));
            this.btnSrc.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseLeaveImage")));
            this.btnSrc.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseMoveImage")));
            this.btnSrc.Name = "btnSrc";
            this.btnSrc.Size = new System.Drawing.Size(113, 22);
            this.btnSrc.TabIndex = 5;
            this.btnSrc.Text = "検索";
            this.btnSrc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSrc.UseVisualStyleBackColor = false;
            this.btnSrc.Click += new System.EventHandler(this.btnSrc_Click);
            // 
            // njLabel4
            // 
            this.njLabel4.AutoSize = true;
            this.njLabel4.Location = new System.Drawing.Point(380, 28);
            this.njLabel4.Name = "njLabel4";
            this.njLabel4.Size = new System.Drawing.Size(17, 12);
            this.njLabel4.TabIndex = 24;
            this.njLabel4.Text = "～";
            // 
            // lblKensu
            // 
            this.lblKensu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKensu.AutoSize = true;
            this.lblKensu.Location = new System.Drawing.Point(730, 650);
            this.lblKensu.Name = "lblKensu";
            this.lblKensu.Size = new System.Drawing.Size(0, 12);
            this.lblKensu.TabIndex = 28;
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
            this.dgvMain.Location = new System.Drawing.Point(5, 106);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvMain.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.dgvMain_Sheet1});
            this.dgvMain.Size = new System.Drawing.Size(960, 535);
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
            this.dgvMain_Sheet1.ColumnCount = 9;
            this.dgvMain_Sheet1.RowCount = 0;
            this.dgvMain_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin2", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "店舗コード";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "店舗名";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "伝票番号";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "売上明細No";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "件名";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "勘定科目";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "数量";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "単価";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "金額";
            this.dgvMain_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.dgvMain_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(0).Label = "店舗コード";
            this.dgvMain_Sheet1.Columns.Get(0).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(0).Width = 70F;
            this.dgvMain_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(1).Label = "店舗名";
            this.dgvMain_Sheet1.Columns.Get(1).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(1).Width = 208F;
            this.dgvMain_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(2).Label = "伝票番号";
            this.dgvMain_Sheet1.Columns.Get(2).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(2).Width = 70F;
            this.dgvMain_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(3).Label = "売上明細No";
            this.dgvMain_Sheet1.Columns.Get(3).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(3).Width = 120F;
            this.dgvMain_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(4).Label = "件名";
            this.dgvMain_Sheet1.Columns.Get(4).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(4).Width = 208F;
            this.dgvMain_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain_Sheet1.Columns.Get(5).Label = "勘定科目";
            this.dgvMain_Sheet1.Columns.Get(5).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(5).Width = 80F;
            this.dgvMain_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.dgvMain_Sheet1.Columns.Get(6).Label = "数量";
            this.dgvMain_Sheet1.Columns.Get(6).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.dgvMain_Sheet1.Columns.Get(7).Label = "単価";
            this.dgvMain_Sheet1.Columns.Get(7).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(7).Width = 103F;
            this.dgvMain_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.dgvMain_Sheet1.Columns.Get(8).Label = "金額";
            this.dgvMain_Sheet1.Columns.Get(8).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(8).Width = 120F;
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
            this.txtDnpFr.Enabled = false;
            this.txtDnpFr.Location = new System.Drawing.Point(323, 23);
            this.txtDnpFr.Mask = "9999999";
            this.txtDnpFr.Name = "txtDnpFr";
            this.txtDnpFr.NotFocusWhenMouseClick = false;
            this.txtDnpFr.NotTabStopWhenNoEditable = true;
            this.txtDnpFr.Size = new System.Drawing.Size(51, 19);
            this.txtDnpFr.TabIndex = 2;
            this.txtDnpFr.TextChanged += new System.EventHandler(this.condChg);
            // 
            // txtDnpTo
            // 
            this.txtDnpTo.AutoNextFocus = false;
            this.txtDnpTo.AutoSelect = true;
            this.txtDnpTo.AutoSelectByMouse = false;
            this.txtDnpTo.DiseditableBackColor = System.Drawing.Color.White;
            this.txtDnpTo.DiseditableForeColor = System.Drawing.Color.Black;
            this.txtDnpTo.Editable = true;
            this.txtDnpTo.Enabled = false;
            this.txtDnpTo.Location = new System.Drawing.Point(403, 23);
            this.txtDnpTo.Mask = "9999999";
            this.txtDnpTo.Name = "txtDnpTo";
            this.txtDnpTo.NotFocusWhenMouseClick = false;
            this.txtDnpTo.NotTabStopWhenNoEditable = true;
            this.txtDnpTo.Size = new System.Drawing.Size(51, 19);
            this.txtDnpTo.TabIndex = 3;
            this.txtDnpTo.TextChanged += new System.EventHandler(this.condChg);
            // 
            // chkNoSplit
            // 
            this.chkNoSplit.AutoSize = true;
            this.chkNoSplit.Location = new System.Drawing.Point(62, 15);
            this.chkNoSplit.Name = "chkNoSplit";
            this.chkNoSplit.Size = new System.Drawing.Size(35, 16);
            this.chkNoSplit.TabIndex = 1;
            this.chkNoSplit.TabStop = true;
            this.chkNoSplit.Text = "無";
            this.chkNoSplit.UseVisualStyleBackColor = true;
            // 
            // chkSplit
            // 
            this.chkSplit.AutoSize = true;
            this.chkSplit.Checked = true;
            this.chkSplit.Location = new System.Drawing.Point(21, 15);
            this.chkSplit.Name = "chkSplit";
            this.chkSplit.Size = new System.Drawing.Size(35, 16);
            this.chkSplit.TabIndex = 0;
            this.chkSplit.TabStop = true;
            this.chkSplit.Text = "有";
            this.chkSplit.UseVisualStyleBackColor = true;
            // 
            // grpTerritory
            // 
            this.grpTerritory.Controls.Add(this.chkOther);
            this.grpTerritory.Controls.Add(this.chkCenter);
            this.grpTerritory.Controls.Add(this.chkKansai);
            this.grpTerritory.Controls.Add(this.chkKanto);
            this.grpTerritory.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grpTerritory.Location = new System.Drawing.Point(255, 10);
            this.grpTerritory.Name = "grpTerritory";
            this.grpTerritory.Size = new System.Drawing.Size(246, 40);
            this.grpTerritory.TabIndex = 2;
            this.grpTerritory.TabStop = false;
            this.grpTerritory.Text = "テリトリー";
            this.grpTerritory.Enter += new System.EventHandler(this.condChg);
            // 
            // chkOther
            // 
            this.chkOther.AutoSize = true;
            this.chkOther.Location = new System.Drawing.Point(180, 16);
            this.chkOther.Name = "chkOther";
            this.chkOther.Size = new System.Drawing.Size(55, 16);
            this.chkOther.TabIndex = 3;
            this.chkOther.Text = "その他";
            this.chkOther.UseVisualStyleBackColor = true;
            // 
            // chkCenter
            // 
            this.chkCenter.AutoSize = true;
            this.chkCenter.Location = new System.Drawing.Point(69, 16);
            this.chkCenter.Name = "chkCenter";
            this.chkCenter.Size = new System.Drawing.Size(48, 16);
            this.chkCenter.TabIndex = 2;
            this.chkCenter.Text = "中央";
            this.chkCenter.UseVisualStyleBackColor = true;
            // 
            // chkKansai
            // 
            this.chkKansai.AutoSize = true;
            this.chkKansai.Location = new System.Drawing.Point(123, 16);
            this.chkKansai.Name = "chkKansai";
            this.chkKansai.Size = new System.Drawing.Size(48, 16);
            this.chkKansai.TabIndex = 1;
            this.chkKansai.Text = "関西";
            this.chkKansai.UseVisualStyleBackColor = true;
            // 
            // chkKanto
            // 
            this.chkKanto.AutoSize = true;
            this.chkKanto.Location = new System.Drawing.Point(15, 16);
            this.chkKanto.Name = "chkKanto";
            this.chkKanto.Size = new System.Drawing.Size(48, 16);
            this.chkKanto.TabIndex = 0;
            this.chkKanto.Text = "関東";
            this.chkKanto.UseVisualStyleBackColor = true;
            // 
            // grpRePrint
            // 
            this.grpRePrint.Controls.Add(this.chkRePrint);
            this.grpRePrint.Controls.Add(this.txtTenpoCd);
            this.grpRePrint.Controls.Add(this.njLabel7);
            this.grpRePrint.Controls.Add(this.njLabel2);
            this.grpRePrint.Controls.Add(this.txtDnpTo);
            this.grpRePrint.Controls.Add(this.njLabel3);
            this.grpRePrint.Controls.Add(this.txtDnpFr);
            this.grpRePrint.Controls.Add(this.njLabel4);
            this.grpRePrint.Controls.Add(this.txtYmRe);
            this.grpRePrint.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grpRePrint.Location = new System.Drawing.Point(12, 50);
            this.grpRePrint.Name = "grpRePrint";
            this.grpRePrint.Size = new System.Drawing.Size(489, 50);
            this.grpRePrint.TabIndex = 4;
            this.grpRePrint.TabStop = false;
            // 
            // chkRePrint
            // 
            this.chkRePrint.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkRePrint.Location = new System.Drawing.Point(6, -1);
            this.chkRePrint.Name = "chkRePrint";
            this.chkRePrint.Size = new System.Drawing.Size(60, 20);
            this.chkRePrint.TabIndex = 3;
            this.chkRePrint.Text = "再印刷";
            this.chkRePrint.UseVisualStyleBackColor = true;
            this.chkRePrint.CheckedChanged += new System.EventHandler(this.chkRePrint_CheckedChanged);
            // 
            // txtTenpoCd
            // 
            this.txtTenpoCd.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtTenpoCd.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTenpoCd.DecimalPlaces = 0;
            this.txtTenpoCd.Enabled = false;
            this.txtTenpoCd.Location = new System.Drawing.Point(207, 24);
            this.txtTenpoCd.Mask = null;
            this.txtTenpoCd.MaxLength = 6;
            this.txtTenpoCd.Name = "txtTenpoCd";
            this.txtTenpoCd.SignificantFigure = 6;
            this.txtTenpoCd.Size = new System.Drawing.Size(48, 19);
            this.txtTenpoCd.TabIndex = 1;
            this.txtTenpoCd.TextChanged += new System.EventHandler(this.condChg);
            this.txtTenpoCd.Leave += new System.EventHandler(this.txtTenpoCd_Leave);
            // 
            // njLabel7
            // 
            this.njLabel7.AutoSize = true;
            this.njLabel7.Location = new System.Drawing.Point(15, 26);
            this.njLabel7.Name = "njLabel7";
            this.njLabel7.Size = new System.Drawing.Size(29, 12);
            this.njLabel7.TabIndex = 36;
            this.njLabel7.Text = "年月";
            // 
            // njLabel2
            // 
            this.njLabel2.AutoSize = true;
            this.njLabel2.Location = new System.Drawing.Point(145, 28);
            this.njLabel2.Name = "njLabel2";
            this.njLabel2.Size = new System.Drawing.Size(56, 12);
            this.njLabel2.TabIndex = 35;
            this.njLabel2.Text = "店舗コード";
            // 
            // txtYmRe
            // 
            this.txtYmRe.DisplayMode = Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.DisplayMode.COMBO;
            this.txtYmRe.Enabled = false;
            this.txtYmRe.Location = new System.Drawing.Point(50, 23);
            this.txtYmRe.MinimumSize = new System.Drawing.Size(82, 21);
            this.txtYmRe.Name = "txtYmRe";
            this.txtYmRe.Size = new System.Drawing.Size(82, 21);
            this.txtYmRe.TabIndex = 0;
            this.txtYmRe.ValidateDisableOnce = false;
            this.txtYmRe.Enter += new System.EventHandler(this.condChg);
            // 
            // grpSplit
            // 
            this.grpSplit.Controls.Add(this.chkNoSplit);
            this.grpSplit.Controls.Add(this.chkSplit);
            this.grpSplit.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grpSplit.Location = new System.Drawing.Point(136, 10);
            this.grpSplit.Name = "grpSplit";
            this.grpSplit.Size = new System.Drawing.Size(112, 39);
            this.grpSplit.TabIndex = 1;
            this.grpSplit.TabStop = false;
            this.grpSplit.Text = "購入伝票の分割";
            this.grpSplit.Enter += new System.EventHandler(this.condChg);
            // 
            // njLabel8
            // 
            this.njLabel8.AutoSize = true;
            this.njLabel8.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel8.Location = new System.Drawing.Point(12, 15);
            this.njLabel8.Name = "njLabel8";
            this.njLabel8.Size = new System.Drawing.Size(29, 12);
            this.njLabel8.TabIndex = 37;
            this.njLabel8.Text = "年月";
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
            this.txtYm.Enter += new System.EventHandler(this.condChg);
            // 
            // ReportMacPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 666);
            this.Controls.Add(this.njLabel8);
            this.Controls.Add(this.grpRePrint);
            this.Controls.Add(this.grpSplit);
            this.Controls.Add(this.grpTerritory);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.lblKensu);
            this.Controls.Add(this.btnSrc);
            this.Controls.Add(this.btnXls);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.txtYm);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MinimumSize = new System.Drawing.Size(900, 300);
            this.Name = "ReportMacPurchase";
            this.Text = "購入伝票";
            this.Shown += new System.EventHandler(this.ReportMacPurchase_Shown);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.ReportToh_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.txtYm, 0);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.btnXls, 0);
            this.Controls.SetChildIndex(this.btnSrc, 0);
            this.Controls.SetChildIndex(this.lblKensu, 0);
            this.Controls.SetChildIndex(this.dgvMain, 0);
            this.Controls.SetChildIndex(this.grpTerritory, 0);
            this.Controls.SetChildIndex(this.grpSplit, 0);
            this.Controls.SetChildIndex(this.grpRePrint, 0);
            this.Controls.SetChildIndex(this.njLabel8, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain_Sheet1)).EndInit();
            this.grpTerritory.ResumeLayout(false);
            this.grpTerritory.PerformLayout();
            this.grpRePrint.ResumeLayout(false);
            this.grpRePrint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenpoCd)).EndInit();
            this.grpSplit.ResumeLayout(false);
            this.grpSplit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Isid.NJ.View.Widget.NJLabel njLabel3;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHlp;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnEnd;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnXls;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnSrc;
        protected Isid.NJ.View.Widget.NJLabel njLabel4;
        protected Isid.NJ.View.Widget.NJLabel lblKensu;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread dgvMain;
        private FarPoint.Win.Spread.SheetView dgvMain_Sheet1;
        private Isid.NJ.View.Widget.NJMaskedTextBox txtDnpFr;
        private Isid.NJ.View.Widget.NJMaskedTextBox txtDnpTo;
        private Isid.NJ.View.Widget.NJRadioButton chkNoSplit;
        private Isid.NJ.View.Widget.NJRadioButton chkSplit;
        private System.Windows.Forms.GroupBox grpTerritory;
        private Isid.NJ.View.Widget.NJCheckBox chkOther;
        private Isid.NJ.View.Widget.NJCheckBox chkCenter;
        private Isid.NJ.View.Widget.NJCheckBox chkKansai;
        private Isid.NJ.View.Widget.NJCheckBox chkKanto;
        private System.Windows.Forms.GroupBox grpRePrint;
        private System.Windows.Forms.GroupBox grpSplit;
        private Isid.NJ.View.Widget.NJCheckBox chkRePrint;
        protected Isid.NJ.View.Widget.NJLabel njLabel2;
        protected Isid.NJ.View.Widget.NJLabel njLabel7;
        protected Isid.NJ.View.Widget.NJLabel njLabel8;
        private Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl txtYmRe;
        private Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl txtYm;
        private Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox txtTenpoCd;
    }
}