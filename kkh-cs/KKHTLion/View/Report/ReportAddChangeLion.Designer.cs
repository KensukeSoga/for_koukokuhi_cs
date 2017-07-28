namespace Isid.KKH.Lion.View.Report
{
    partial class ReportAddChangeLion
    {
        /// <summary>
        /// 必要なデザイナ変数です。.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。.
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

        #region Windows フォーム デザイナで生成されたコード.

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を.
        /// コード エディタで変更しないでください。.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportAddChangeLion));
            this.btnSrc = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnXls = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnRetrun = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.sprMain = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.spsAD1Seisaku = new FarPoint.Win.Spread.SheetView();
            this.spsAD2Seisaku = new FarPoint.Win.Spread.SheetView();
            this.spsAD1Baitai = new FarPoint.Win.Spread.SheetView();
            this.spsAD2Baitai = new FarPoint.Win.Spread.SheetView();
            this.cboReport = new Isid.KKH.Common.KKHView.Common.Control.KkhComboBox();
            this.njToolTip1 = new Isid.NJ.View.Widget.NJToolTip();
            this.lblYM = new Isid.NJ.View.Widget.NJLabel();
            this.sprRrkTimStmp = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.spsRrkTimStmp = new FarPoint.Win.Spread.SheetView();
            this.lblOutput = new Isid.NJ.View.Widget.NJLabel();
            this.txtYm = new Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl();
            ((System.ComponentModel.ISupportInitialize)(this.sprMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spsAD1Seisaku)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spsAD2Seisaku)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spsAD1Baitai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spsAD2Baitai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sprRrkTimStmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spsRrkTimStmp)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSrc
            // 
            this.btnSrc.BackColor = System.Drawing.Color.Transparent;
            this.btnSrc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSrc.FlatAppearance.BorderSize = 0;
            this.btnSrc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSrc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSrc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSrc.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSrc.Image = ((System.Drawing.Image)(resources.GetObject("btnSrc.Image")));
            this.btnSrc.Location = new System.Drawing.Point(420, 11);
            this.btnSrc.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseDownImage")));
            this.btnSrc.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseLeaveImage")));
            this.btnSrc.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseMoveImage")));
            this.btnSrc.Name = "btnSrc";
            this.btnSrc.Size = new System.Drawing.Size(113, 22);
            this.btnSrc.TabIndex = 17;
            this.btnSrc.TabStop = false;
            this.btnSrc.Text = "検索";
            this.btnSrc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSrc.UseVisualStyleBackColor = false;
            this.btnSrc.Click += new System.EventHandler(this.btnSrc_Click);
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
            this.btnXls.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXls.Image = ((System.Drawing.Image)(resources.GetObject("btnXls.Image")));
            this.btnXls.Location = new System.Drawing.Point(549, 11);
            this.btnXls.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseDownImage")));
            this.btnXls.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseLeaveImage")));
            this.btnXls.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseMoveImage")));
            this.btnXls.Name = "btnXls";
            this.btnXls.Size = new System.Drawing.Size(113, 22);
            this.btnXls.TabIndex = 18;
            this.btnXls.TabStop = false;
            this.btnXls.Text = "    帳票出力";
            this.btnXls.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXls.UseVisualStyleBackColor = false;
            this.btnXls.Click += new System.EventHandler(this.btnXls_Click);
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
            this.btnHlp.TabIndex = 19;
            this.btnHlp.TabStop = false;
            this.btnHlp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHlp.UseVisualStyleBackColor = false;
            this.btnHlp.Click += new System.EventHandler(this.btnHlp_Click);
            // 
            // btnRetrun
            // 
            this.btnRetrun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetrun.BackColor = System.Drawing.Color.Transparent;
            this.btnRetrun.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRetrun.FlatAppearance.BorderSize = 0;
            this.btnRetrun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRetrun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRetrun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetrun.Image = ((System.Drawing.Image)(resources.GetObject("btnRetrun.Image")));
            this.btnRetrun.Location = new System.Drawing.Point(923, 1);
            this.btnRetrun.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnRetrun.MouseDownImage")));
            this.btnRetrun.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnRetrun.MouseLeaveImage")));
            this.btnRetrun.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnRetrun.MouseMoveImage")));
            this.btnRetrun.Name = "btnRetrun";
            this.btnRetrun.Size = new System.Drawing.Size(37, 37);
            this.btnRetrun.TabIndex = 20;
            this.btnRetrun.TabStop = false;
            this.btnRetrun.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRetrun.UseVisualStyleBackColor = false;
            this.btnRetrun.Click += new System.EventHandler(this.btnRetrun_Click);
            // 
            // sprMain
            // 
            this.sprMain.AccessibleDescription = "sprMain, AD2媒体";
            this.sprMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sprMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sprMain.EnableCustomSorting = false;
            this.sprMain.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sprMain.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.sprMain.Location = new System.Drawing.Point(8, 150);
            this.sprMain.Name = "sprMain";
            this.sprMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sprMain.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spsAD1Seisaku,
            this.spsAD2Seisaku,
            this.spsAD1Baitai,
            this.spsAD2Baitai});
            this.sprMain.Size = new System.Drawing.Size(954, 487);
            this.sprMain.TabIndex = 21;
            this.sprMain.TabStripRatio = 0.852307692307692;
            this.sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.sprMain.SheetTabClick += new FarPoint.Win.Spread.SheetTabClickEventHandler(this.sprMain_SheetTabClick);
            // 
            // spsAD1Seisaku
            // 
            this.spsAD1Seisaku.Reset();
            this.spsAD1Seisaku.SheetName = "AD1制作";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spsAD1Seisaku.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spsAD1Seisaku.ColumnCount = 9;
            this.spsAD1Seisaku.RowCount = 0;
            this.spsAD1Seisaku.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.spsAD1Seisaku.ColumnHeader.Cells.Get(0, 0).Value = "変更区分";
            this.spsAD1Seisaku.ColumnHeader.Cells.Get(0, 1).Value = "売上明細NO";
            this.spsAD1Seisaku.ColumnHeader.Cells.Get(0, 2).Value = "媒体区分";
            this.spsAD1Seisaku.ColumnHeader.Cells.Get(0, 3).Value = "媒体名称";
            this.spsAD1Seisaku.ColumnHeader.Cells.Get(0, 4).Value = "ブランドコード";
            this.spsAD1Seisaku.ColumnHeader.Cells.Get(0, 5).Value = "ブランド名称";
            this.spsAD1Seisaku.ColumnHeader.Cells.Get(0, 6).Value = "件名";
            this.spsAD1Seisaku.ColumnHeader.Cells.Get(0, 7).Value = "請求金額";
            this.spsAD1Seisaku.ColumnHeader.Cells.Get(0, 8).Value = "消費税額";
            this.spsAD1Seisaku.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD1Seisaku.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsAD1Seisaku.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spsAD1Seisaku.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD1Seisaku.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD1Seisaku.ColumnHeader.Rows.Get(0).Height = 36F;
            this.spsAD1Seisaku.Columns.Get(0).AllowAutoFilter = true;
            this.spsAD1Seisaku.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD1Seisaku.Columns.Get(0).Label = "変更区分";
            this.spsAD1Seisaku.Columns.Get(0).Locked = true;
            this.spsAD1Seisaku.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Seisaku.Columns.Get(1).Label = "売上明細NO";
            this.spsAD1Seisaku.Columns.Get(1).Locked = true;
            this.spsAD1Seisaku.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Seisaku.Columns.Get(1).Width = 120F;
            this.spsAD1Seisaku.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD1Seisaku.Columns.Get(2).Label = "媒体区分";
            this.spsAD1Seisaku.Columns.Get(2).Locked = true;
            this.spsAD1Seisaku.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Seisaku.Columns.Get(2).Width = 40F;
            this.spsAD1Seisaku.Columns.Get(3).AllowAutoFilter = true;
            this.spsAD1Seisaku.Columns.Get(3).Label = "媒体名称";
            this.spsAD1Seisaku.Columns.Get(3).Locked = true;
            this.spsAD1Seisaku.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Seisaku.Columns.Get(3).Width = 200F;
            this.spsAD1Seisaku.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD1Seisaku.Columns.Get(4).Label = "ブランドコード";
            this.spsAD1Seisaku.Columns.Get(4).Locked = true;
            this.spsAD1Seisaku.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Seisaku.Columns.Get(4).Width = 45F;
            this.spsAD1Seisaku.Columns.Get(5).AllowAutoFilter = true;
            this.spsAD1Seisaku.Columns.Get(5).Label = "ブランド名称";
            this.spsAD1Seisaku.Columns.Get(5).Locked = true;
            this.spsAD1Seisaku.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Seisaku.Columns.Get(5).Width = 200F;
            this.spsAD1Seisaku.Columns.Get(6).Label = "件名";
            this.spsAD1Seisaku.Columns.Get(6).Locked = true;
            this.spsAD1Seisaku.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Seisaku.Columns.Get(6).Width = 200F;
            this.spsAD1Seisaku.Columns.Get(7).Label = "請求金額";
            this.spsAD1Seisaku.Columns.Get(7).Locked = true;
            this.spsAD1Seisaku.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Seisaku.Columns.Get(7).Width = 100F;
            this.spsAD1Seisaku.Columns.Get(8).Label = "消費税額";
            this.spsAD1Seisaku.Columns.Get(8).Locked = true;
            this.spsAD1Seisaku.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Seisaku.Columns.Get(8).Width = 100F;
            this.spsAD1Seisaku.RowHeader.Columns.Default.Resizable = true;
            this.spsAD1Seisaku.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD1Seisaku.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsAD1Seisaku.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spsAD1Seisaku.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD1Seisaku.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD1Seisaku.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsAD1Seisaku.SheetCornerStyle.Parent = "CornerDefault";
            this.spsAD1Seisaku.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD1Seisaku.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.sprMain.SetActiveViewport(0, 1, 0);
            // 
            // spsAD2Seisaku
            // 
            this.spsAD2Seisaku.Reset();
            this.spsAD2Seisaku.SheetName = "AD2制作";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spsAD2Seisaku.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spsAD2Seisaku.ColumnCount = 9;
            this.spsAD2Seisaku.RowCount = 0;
            this.spsAD2Seisaku.ActiveColumnIndex = 5;
            this.spsAD2Seisaku.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.spsAD2Seisaku.ColumnHeader.Cells.Get(0, 0).Value = "変更区分";
            this.spsAD2Seisaku.ColumnHeader.Cells.Get(0, 1).Value = "売上明細NO";
            this.spsAD2Seisaku.ColumnHeader.Cells.Get(0, 2).Value = "媒体区分";
            this.spsAD2Seisaku.ColumnHeader.Cells.Get(0, 3).Value = "媒体名称";
            this.spsAD2Seisaku.ColumnHeader.Cells.Get(0, 4).Value = "ブランドコード";
            this.spsAD2Seisaku.ColumnHeader.Cells.Get(0, 5).Value = "ブランド名称";
            this.spsAD2Seisaku.ColumnHeader.Cells.Get(0, 6).Value = "件名";
            this.spsAD2Seisaku.ColumnHeader.Cells.Get(0, 7).Value = "請求金額";
            this.spsAD2Seisaku.ColumnHeader.Cells.Get(0, 8).Value = "消費税額";
            this.spsAD2Seisaku.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD2Seisaku.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsAD2Seisaku.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spsAD2Seisaku.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD2Seisaku.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD2Seisaku.ColumnHeader.Rows.Get(0).Height = 36F;
            this.spsAD2Seisaku.Columns.Get(0).AllowAutoFilter = true;
            this.spsAD2Seisaku.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD2Seisaku.Columns.Get(0).Label = "変更区分";
            this.spsAD2Seisaku.Columns.Get(0).Locked = true;
            this.spsAD2Seisaku.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Seisaku.Columns.Get(1).Label = "売上明細NO";
            this.spsAD2Seisaku.Columns.Get(1).Locked = true;
            this.spsAD2Seisaku.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Seisaku.Columns.Get(1).Width = 120F;
            this.spsAD2Seisaku.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD2Seisaku.Columns.Get(2).Label = "媒体区分";
            this.spsAD2Seisaku.Columns.Get(2).Locked = true;
            this.spsAD2Seisaku.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Seisaku.Columns.Get(2).Width = 40F;
            this.spsAD2Seisaku.Columns.Get(3).AllowAutoFilter = true;
            this.spsAD2Seisaku.Columns.Get(3).Label = "媒体名称";
            this.spsAD2Seisaku.Columns.Get(3).Locked = true;
            this.spsAD2Seisaku.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Seisaku.Columns.Get(3).Width = 200F;
            this.spsAD2Seisaku.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD2Seisaku.Columns.Get(4).Label = "ブランドコード";
            this.spsAD2Seisaku.Columns.Get(4).Locked = true;
            this.spsAD2Seisaku.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Seisaku.Columns.Get(4).Width = 45F;
            this.spsAD2Seisaku.Columns.Get(5).AllowAutoFilter = true;
            this.spsAD2Seisaku.Columns.Get(5).Label = "ブランド名称";
            this.spsAD2Seisaku.Columns.Get(5).Locked = true;
            this.spsAD2Seisaku.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Seisaku.Columns.Get(5).Width = 200F;
            this.spsAD2Seisaku.Columns.Get(6).Label = "件名";
            this.spsAD2Seisaku.Columns.Get(6).Locked = true;
            this.spsAD2Seisaku.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Seisaku.Columns.Get(6).Width = 200F;
            this.spsAD2Seisaku.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spsAD2Seisaku.Columns.Get(7).Label = "請求金額";
            this.spsAD2Seisaku.Columns.Get(7).Locked = true;
            this.spsAD2Seisaku.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Seisaku.Columns.Get(7).Width = 100F;
            this.spsAD2Seisaku.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spsAD2Seisaku.Columns.Get(8).Label = "消費税額";
            this.spsAD2Seisaku.Columns.Get(8).Locked = true;
            this.spsAD2Seisaku.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Seisaku.Columns.Get(8).Width = 100F;
            this.spsAD2Seisaku.RowHeader.Columns.Default.Resizable = true;
            this.spsAD2Seisaku.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD2Seisaku.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsAD2Seisaku.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spsAD2Seisaku.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD2Seisaku.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD2Seisaku.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsAD2Seisaku.SheetCornerStyle.Parent = "CornerDefault";
            this.spsAD2Seisaku.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD2Seisaku.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.sprMain.SetActiveViewport(1, 1, 0);
            // 
            // spsAD1Baitai
            // 
            this.spsAD1Baitai.Reset();
            this.spsAD1Baitai.SheetName = "AD1媒体";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spsAD1Baitai.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spsAD1Baitai.ColumnCount = 15;
            this.spsAD1Baitai.RowCount = 0;
            this.spsAD1Baitai.ActiveColumnIndex = 3;
            this.spsAD1Baitai.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.spsAD1Baitai.ColumnHeader.Cells.Get(0, 0).Value = "変更区分";
            this.spsAD1Baitai.ColumnHeader.Cells.Get(0, 1).Value = "売上明細NO";
            this.spsAD1Baitai.ColumnHeader.Cells.Get(0, 2).Value = "媒体区分";
            this.spsAD1Baitai.ColumnHeader.Cells.Get(0, 3).Value = "媒体名称";
            this.spsAD1Baitai.ColumnHeader.Cells.Get(0, 4).Value = "件名";
            this.spsAD1Baitai.ColumnHeader.Cells.Get(0, 5).Value = "請求金額";
            this.spsAD1Baitai.ColumnHeader.Cells.Get(0, 6).Value = "局誌コード";
            this.spsAD1Baitai.ColumnHeader.Cells.Get(0, 7).Value = "局コード";
            this.spsAD1Baitai.ColumnHeader.Cells.Get(0, 8).Value = "局誌名称";
            this.spsAD1Baitai.ColumnHeader.Cells.Get(0, 9).Value = "CM秒数";
            this.spsAD1Baitai.ColumnHeader.Cells.Get(0, 10).Value = "CM本数";
            this.spsAD1Baitai.ColumnHeader.Cells.Get(0, 11).Value = "CM総秒数";
            this.spsAD1Baitai.ColumnHeader.Cells.Get(0, 12).Value = "スペース";
            this.spsAD1Baitai.ColumnHeader.Cells.Get(0, 13).Value = "掲載日・号・等";
            this.spsAD1Baitai.ColumnHeader.Cells.Get(0, 14).Value = "期間";
            this.spsAD1Baitai.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD1Baitai.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsAD1Baitai.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spsAD1Baitai.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD1Baitai.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD1Baitai.ColumnHeader.Rows.Get(0).Height = 36F;
            this.spsAD1Baitai.Columns.Get(0).AllowAutoFilter = true;
            this.spsAD1Baitai.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(0).Label = "変更区分";
            this.spsAD1Baitai.Columns.Get(0).Locked = true;
            this.spsAD1Baitai.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spsAD1Baitai.Columns.Get(1).Label = "売上明細NO";
            this.spsAD1Baitai.Columns.Get(1).Locked = true;
            this.spsAD1Baitai.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(1).Width = 160F;
            this.spsAD1Baitai.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(2).Label = "媒体区分";
            this.spsAD1Baitai.Columns.Get(2).Locked = true;
            this.spsAD1Baitai.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(2).Width = 40F;
            this.spsAD1Baitai.Columns.Get(3).AllowAutoFilter = true;
            this.spsAD1Baitai.Columns.Get(3).Label = "媒体名称";
            this.spsAD1Baitai.Columns.Get(3).Locked = true;
            this.spsAD1Baitai.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(3).Width = 120F;
            this.spsAD1Baitai.Columns.Get(4).Label = "件名";
            this.spsAD1Baitai.Columns.Get(4).Locked = true;
            this.spsAD1Baitai.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(4).Width = 240F;
            this.spsAD1Baitai.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spsAD1Baitai.Columns.Get(5).Label = "請求金額";
            this.spsAD1Baitai.Columns.Get(5).Locked = true;
            this.spsAD1Baitai.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(5).Width = 100F;
            this.spsAD1Baitai.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(6).Label = "局誌コード";
            this.spsAD1Baitai.Columns.Get(6).Locked = true;
            this.spsAD1Baitai.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(6).Width = 40F;
            this.spsAD1Baitai.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(7).Label = "局コード";
            this.spsAD1Baitai.Columns.Get(7).Locked = true;
            this.spsAD1Baitai.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(7).Width = 40F;
            this.spsAD1Baitai.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spsAD1Baitai.Columns.Get(8).Label = "局誌名称";
            this.spsAD1Baitai.Columns.Get(8).Locked = true;
            this.spsAD1Baitai.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(8).Width = 100F;
            this.spsAD1Baitai.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spsAD1Baitai.Columns.Get(9).Label = "CM秒数";
            this.spsAD1Baitai.Columns.Get(9).Locked = true;
            this.spsAD1Baitai.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spsAD1Baitai.Columns.Get(10).Label = "CM本数";
            this.spsAD1Baitai.Columns.Get(10).Locked = true;
            this.spsAD1Baitai.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spsAD1Baitai.Columns.Get(11).Label = "CM総秒数";
            this.spsAD1Baitai.Columns.Get(11).Locked = true;
            this.spsAD1Baitai.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(12).Label = "スペース";
            this.spsAD1Baitai.Columns.Get(12).Locked = true;
            this.spsAD1Baitai.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(13).Label = "掲載日・号・等";
            this.spsAD1Baitai.Columns.Get(13).Locked = true;
            this.spsAD1Baitai.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(13).Width = 80F;
            this.spsAD1Baitai.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(14).Label = "期間";
            this.spsAD1Baitai.Columns.Get(14).Locked = true;
            this.spsAD1Baitai.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD1Baitai.Columns.Get(14).Width = 160F;
            this.spsAD1Baitai.RowHeader.Columns.Default.Resizable = true;
            this.spsAD1Baitai.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD1Baitai.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsAD1Baitai.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spsAD1Baitai.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD1Baitai.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD1Baitai.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsAD1Baitai.SheetCornerStyle.Parent = "CornerDefault";
            this.spsAD1Baitai.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD1Baitai.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.sprMain.SetActiveViewport(2, 1, 0);
            // 
            // spsAD2Baitai
            // 
            this.spsAD2Baitai.Reset();
            this.spsAD2Baitai.SheetName = "AD2媒体";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spsAD2Baitai.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spsAD2Baitai.ColumnCount = 15;
            this.spsAD2Baitai.RowCount = 0;
            this.spsAD2Baitai.ActiveColumnIndex = 4;
            this.spsAD2Baitai.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.spsAD2Baitai.ColumnHeader.Cells.Get(0, 0).Value = "変更区分";
            this.spsAD2Baitai.ColumnHeader.Cells.Get(0, 1).Value = "売上明細NO";
            this.spsAD2Baitai.ColumnHeader.Cells.Get(0, 2).Value = "媒体区分";
            this.spsAD2Baitai.ColumnHeader.Cells.Get(0, 3).Value = "媒体名称";
            this.spsAD2Baitai.ColumnHeader.Cells.Get(0, 4).Value = "件名";
            this.spsAD2Baitai.ColumnHeader.Cells.Get(0, 5).Value = "請求金額";
            this.spsAD2Baitai.ColumnHeader.Cells.Get(0, 6).Value = "局誌コード";
            this.spsAD2Baitai.ColumnHeader.Cells.Get(0, 7).Value = "局コード";
            this.spsAD2Baitai.ColumnHeader.Cells.Get(0, 8).Value = "局誌名称";
            this.spsAD2Baitai.ColumnHeader.Cells.Get(0, 9).Value = "CM秒数";
            this.spsAD2Baitai.ColumnHeader.Cells.Get(0, 10).Value = "CM本数";
            this.spsAD2Baitai.ColumnHeader.Cells.Get(0, 11).Value = "CM総秒数";
            this.spsAD2Baitai.ColumnHeader.Cells.Get(0, 12).Value = "スペース";
            this.spsAD2Baitai.ColumnHeader.Cells.Get(0, 13).Value = "掲載日・号・等";
            this.spsAD2Baitai.ColumnHeader.Cells.Get(0, 14).Value = "期間";
            this.spsAD2Baitai.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD2Baitai.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsAD2Baitai.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spsAD2Baitai.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD2Baitai.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD2Baitai.ColumnHeader.Rows.Get(0).Height = 36F;
            this.spsAD2Baitai.Columns.Get(0).AllowAutoFilter = true;
            this.spsAD2Baitai.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(0).Label = "変更区分";
            this.spsAD2Baitai.Columns.Get(0).Locked = true;
            this.spsAD2Baitai.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spsAD2Baitai.Columns.Get(1).Label = "売上明細NO";
            this.spsAD2Baitai.Columns.Get(1).Locked = true;
            this.spsAD2Baitai.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(1).Width = 160F;
            this.spsAD2Baitai.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(2).Label = "媒体区分";
            this.spsAD2Baitai.Columns.Get(2).Locked = true;
            this.spsAD2Baitai.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(2).Width = 40F;
            this.spsAD2Baitai.Columns.Get(3).AllowAutoFilter = true;
            this.spsAD2Baitai.Columns.Get(3).Label = "媒体名称";
            this.spsAD2Baitai.Columns.Get(3).Locked = true;
            this.spsAD2Baitai.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(3).Width = 120F;
            this.spsAD2Baitai.Columns.Get(4).Label = "件名";
            this.spsAD2Baitai.Columns.Get(4).Locked = true;
            this.spsAD2Baitai.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(4).Width = 240F;
            this.spsAD2Baitai.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spsAD2Baitai.Columns.Get(5).Label = "請求金額";
            this.spsAD2Baitai.Columns.Get(5).Locked = true;
            this.spsAD2Baitai.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(5).Width = 100F;
            this.spsAD2Baitai.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(6).Label = "局誌コード";
            this.spsAD2Baitai.Columns.Get(6).Locked = true;
            this.spsAD2Baitai.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(6).Width = 40F;
            this.spsAD2Baitai.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(7).Label = "局コード";
            this.spsAD2Baitai.Columns.Get(7).Locked = true;
            this.spsAD2Baitai.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(7).Width = 40F;
            this.spsAD2Baitai.Columns.Get(8).Label = "局誌名称";
            this.spsAD2Baitai.Columns.Get(8).Locked = true;
            this.spsAD2Baitai.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(8).Width = 100F;
            this.spsAD2Baitai.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spsAD2Baitai.Columns.Get(9).Label = "CM秒数";
            this.spsAD2Baitai.Columns.Get(9).Locked = true;
            this.spsAD2Baitai.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spsAD2Baitai.Columns.Get(10).Label = "CM本数";
            this.spsAD2Baitai.Columns.Get(10).Locked = true;
            this.spsAD2Baitai.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spsAD2Baitai.Columns.Get(11).Label = "CM総秒数";
            this.spsAD2Baitai.Columns.Get(11).Locked = true;
            this.spsAD2Baitai.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(12).Label = "スペース";
            this.spsAD2Baitai.Columns.Get(12).Locked = true;
            this.spsAD2Baitai.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(13).Label = "掲載日・号・等";
            this.spsAD2Baitai.Columns.Get(13).Locked = true;
            this.spsAD2Baitai.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(13).Width = 80F;
            this.spsAD2Baitai.Columns.Get(14).Label = "期間";
            this.spsAD2Baitai.Columns.Get(14).Locked = true;
            this.spsAD2Baitai.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsAD2Baitai.Columns.Get(14).Width = 160F;
            this.spsAD2Baitai.RowHeader.Columns.Default.Resizable = true;
            this.spsAD2Baitai.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD2Baitai.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsAD2Baitai.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spsAD2Baitai.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD2Baitai.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD2Baitai.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsAD2Baitai.SheetCornerStyle.Parent = "CornerDefault";
            this.spsAD2Baitai.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsAD2Baitai.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.sprMain.SetActiveViewport(3, 1, 0);
            // 
            // cboReport
            // 
            this.cboReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReport.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReport.FormattingEnabled = true;
            this.cboReport.Items.AddRange(new object[] {
            "１次制作室リスト",
            "２次制作室リスト",
            "追加変更リスト"});
            this.cboReport.Location = new System.Drawing.Point(229, 12);
            this.cboReport.Name = "cboReport";
            this.cboReport.Size = new System.Drawing.Size(176, 20);
            this.cboReport.TabIndex = 22;
            this.cboReport.SelectedIndexChanged += new System.EventHandler(this.cboReport_SelectedIndexChanged);
            this.cboReport.SelectedValueChanged += new System.EventHandler(this.condChg);
            // 
            // lblYM
            // 
            this.lblYM.AutoSize = true;
            this.lblYM.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYM.Location = new System.Drawing.Point(12, 17);
            this.lblYM.Name = "lblYM";
            this.lblYM.Size = new System.Drawing.Size(29, 12);
            this.lblYM.TabIndex = 29;
            this.lblYM.Text = "年月";
            // 
            // sprRrkTimStmp
            // 
            this.sprRrkTimStmp.AccessibleDescription = "sprRrkTimStmp, Sheet1, Row 0, Column 0, ";
            this.sprRrkTimStmp.BackColor = System.Drawing.Color.Transparent;
            this.sprRrkTimStmp.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.sprRrkTimStmp.EnableCustomSorting = false;
            this.sprRrkTimStmp.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sprRrkTimStmp.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.sprRrkTimStmp.Location = new System.Drawing.Point(8, 40);
            this.sprRrkTimStmp.Name = "sprRrkTimStmp";
            this.sprRrkTimStmp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sprRrkTimStmp.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.sprRrkTimStmp.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows;
            this.sprRrkTimStmp.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spsRrkTimStmp});
            this.sprRrkTimStmp.Size = new System.Drawing.Size(400, 100);
            this.sprRrkTimStmp.TabIndex = 38;
            this.sprRrkTimStmp.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.sprRrkTimStmp.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.sprRrkTimStmp_CellClick);
            // 
            // spsRrkTimStmp
            // 
            this.spsRrkTimStmp.Reset();
            this.spsRrkTimStmp.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spsRrkTimStmp.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spsRrkTimStmp.ColumnCount = 1;
            this.spsRrkTimStmp.RowCount = 0;
            this.spsRrkTimStmp.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin1", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.spsRrkTimStmp.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spsRrkTimStmp.ColumnHeader.AutoTextIndex = 0;
            this.spsRrkTimStmp.ColumnHeader.Cells.Get(0, 0).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsRrkTimStmp.ColumnHeader.Cells.Get(0, 0).Value = "履歴保存日時";
            this.spsRrkTimStmp.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsRrkTimStmp.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsRrkTimStmp.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spsRrkTimStmp.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsRrkTimStmp.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsRrkTimStmp.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spsRrkTimStmp.Columns.Get(0).Label = "履歴保存日時";
            this.spsRrkTimStmp.Columns.Get(0).Locked = true;
            this.spsRrkTimStmp.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsRrkTimStmp.Columns.Get(0).Width = 120F;
            this.spsRrkTimStmp.DataAutoCellTypes = false;
            this.spsRrkTimStmp.DataAutoHeadings = false;
            this.spsRrkTimStmp.DataAutoSizeColumns = false;
            this.spsRrkTimStmp.OperationMode = FarPoint.Win.Spread.OperationMode.ExtendedSelect;
            this.spsRrkTimStmp.RowHeader.Columns.Default.Resizable = true;
            this.spsRrkTimStmp.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsRrkTimStmp.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsRrkTimStmp.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spsRrkTimStmp.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsRrkTimStmp.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsRrkTimStmp.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spsRrkTimStmp.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spsRrkTimStmp.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsRrkTimStmp.SheetCornerStyle.Parent = "CornerDefault";
            this.spsRrkTimStmp.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsRrkTimStmp.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.sprRrkTimStmp.SetActiveViewport(0, 1, 0);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.Location = new System.Drawing.Point(161, 16);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(53, 12);
            this.lblOutput.TabIndex = 25;
            this.lblOutput.Text = "出力帳票";
            // 
            // txtYm
            // 
            this.txtYm.DisplayMode = Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.DisplayMode.COMBO;
            this.txtYm.Location = new System.Drawing.Point(47, 12);
            this.txtYm.MinimumSize = new System.Drawing.Size(82, 21);
            this.txtYm.Name = "txtYm";
            this.txtYm.Size = new System.Drawing.Size(82, 21);
            this.txtYm.TabIndex = 40;
            this.txtYm.ValidateDisableOnce = false;
            this.txtYm.Leave += new System.EventHandler(this.txtYm_Leave);
            // 
            // ReportAddChangeLion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 666);
            this.Controls.Add(this.txtYm);
            this.Controls.Add(this.lblYM);
            this.Controls.Add(this.sprRrkTimStmp);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.sprMain);
            this.Controls.Add(this.cboReport);
            this.Controls.Add(this.btnSrc);
            this.Controls.Add(this.btnXls);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.btnRetrun);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 300);
            this.Name = "ReportAddChangeLion";
            this.Text = "制作室リスト・追加変更リスト";
            this.Shown += new System.EventHandler(this.ReportAddChgLion_Shown);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.ReportAddChgLion_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.btnRetrun, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.btnXls, 0);
            this.Controls.SetChildIndex(this.btnSrc, 0);
            this.Controls.SetChildIndex(this.cboReport, 0);
            this.Controls.SetChildIndex(this.sprMain, 0);
            this.Controls.SetChildIndex(this.lblOutput, 0);
            this.Controls.SetChildIndex(this.sprRrkTimStmp, 0);
            this.Controls.SetChildIndex(this.lblYM, 0);
            this.Controls.SetChildIndex(this.txtYm, 0);
            ((System.ComponentModel.ISupportInitialize)(this.sprMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spsAD1Seisaku)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spsAD2Seisaku)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spsAD1Baitai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spsAD2Baitai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sprRrkTimStmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spsRrkTimStmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread sprMain;
        private FarPoint.Win.Spread.SheetView spsAD1Seisaku;
        private Isid.KKH.Common.KKHView.Common.Control.KkhComboBox cboReport;
        private FarPoint.Win.Spread.SheetView spsAD2Seisaku;
        private FarPoint.Win.Spread.SheetView spsAD1Baitai;
        private Isid.NJ.View.Widget.NJToolTip njToolTip1;
        private Isid.NJ.View.Widget.NJLabel lblYM;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnSrc;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnXls;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHlp;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnRetrun;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread sprRrkTimStmp;
        private FarPoint.Win.Spread.SheetView spsRrkTimStmp;
        private Isid.NJ.View.Widget.NJLabel lblOutput;
        protected Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl txtYm;
        private FarPoint.Win.Spread.SheetView spsAD2Baitai;


    }
}