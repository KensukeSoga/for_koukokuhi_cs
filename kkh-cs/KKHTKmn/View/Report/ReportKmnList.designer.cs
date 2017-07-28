namespace Isid.KKH.Kmn.View.Report
{
    partial class ReportKmnList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportKmnList));
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.btnSrc = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnXls = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnEnd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.spdReport = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this._spdReport_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this._bsRepKmnList = new System.Windows.Forms.BindingSource(this.components);
            this.repDSKmn = new Isid.KKH.Kmn.Schema.RepDSKmn();
            this.njToolTip1 = new Isid.NJ.View.Widget.NJToolTip();
            this.txtYm = new Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl();
            this.lblYyyyMm = new Isid.NJ.View.Widget.NJLabel();
            this.cmbBusho = new System.Windows.Forms.ComboBox();
            this.lblBumon = new Isid.NJ.View.Widget.NJLabel();
            this.ckbFin = new System.Windows.Forms.CheckBox();
            this.lblOutput = new Isid.NJ.View.Widget.NJLabel();
            this.cmbOutTanni = new Isid.KKH.Common.KKHView.Common.Control.KkhComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.spdReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdReport_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsRepKmnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDSKmn)).BeginInit();
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
            this.btnSrc.Location = new System.Drawing.Point(600, 17);
            this.btnSrc.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseDownImage")));
            this.btnSrc.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseLeaveImage")));
            this.btnSrc.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseMoveImage")));
            this.btnSrc.Name = "btnSrc";
            this.btnSrc.Size = new System.Drawing.Size(113, 22);
            this.btnSrc.TabIndex = 2;
            this.btnSrc.Text = "検索";
            this.btnSrc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnSrc, "指定された年月のデータを表示します");
            this.btnSrc.UseVisualStyleBackColor = false;
            this.btnSrc.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnSrc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
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
            this.btnXls.Location = new System.Drawing.Point(719, 17);
            this.btnXls.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseDownImage")));
            this.btnXls.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseLeaveImage")));
            this.btnXls.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseMoveImage")));
            this.btnXls.Name = "btnXls";
            this.btnXls.Size = new System.Drawing.Size(113, 22);
            this.btnXls.TabIndex = 3;
            this.btnXls.Text = "    帳票出力";
            this.btnXls.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnXls, "表示されている内容をExcel形式で出力します");
            this.btnXls.UseVisualStyleBackColor = false;
            this.btnXls.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnXls.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
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
            this.btnHlp.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHlp.Image = ((System.Drawing.Image)(resources.GetObject("btnHlp.Image")));
            this.btnHlp.Location = new System.Drawing.Point(885, 6);
            this.btnHlp.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseDownImage")));
            this.btnHlp.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseLeaveImage")));
            this.btnHlp.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseMoveImage")));
            this.btnHlp.Name = "btnHlp";
            this.btnHlp.Size = new System.Drawing.Size(37, 37);
            this.btnHlp.TabIndex = 4;
            this.btnHlp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnHlp, "ヘルプを表示します");
            this.btnHlp.UseVisualStyleBackColor = false;
            this.btnHlp.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnHlp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
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
            this.btnEnd.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEnd.Image")));
            this.btnEnd.Location = new System.Drawing.Point(928, 6);
            this.btnEnd.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseDownImage")));
            this.btnEnd.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseLeaveImage")));
            this.btnEnd.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseMoveImage")));
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(37, 37);
            this.btnEnd.TabIndex = 5;
            this.btnEnd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnEnd, "帳票出力を終わってメニューに戻ります");
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnEnd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_MouseMove);
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // spdReport
            // 
            this.spdReport.AccessibleDescription = "spdReport, Sheet1";
            this.spdReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spdReport.BackColor = System.Drawing.SystemColors.Control;
            this.spdReport.EditModeReplace = true;
            this.spdReport.EnableCustomSorting = false;
            this.spdReport.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.spdReport.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdReport.Location = new System.Drawing.Point(0, 57);
            this.spdReport.Name = "spdReport";
            this.spdReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdReport.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this._spdReport_Sheet1});
            this.spdReport.Size = new System.Drawing.Size(960, 584);
            this.spdReport.TabIndex = 6;
            this.spdReport.TabStop = false;
            this.spdReport.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdReport.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdReport_ButtonClicked);
            this.spdReport.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdReport_CellDoubleClick);
            // 
            // _spdReport_Sheet1
            // 
            this._spdReport_Sheet1.Reset();
            this._spdReport_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this._spdReport_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this._spdReport_Sheet1.ColumnCount = 16;
            this._spdReport_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this._spdReport_Sheet1.AutoGenerateColumns = false;
            this._spdReport_Sheet1.ColumnHeader.AutoTextIndex = 0;
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "選択";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "出力No";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "請求書発行";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "シークエンスNo";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "受注No";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "受注明細No";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "売上明細No";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "連番";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "内容";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "費目";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "部門コード";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "部門名";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "宛先";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "期間";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "金額";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "備考";
            this._spdReport_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdReport_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdReport_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this._spdReport_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdReport_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdReport_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this._spdReport_Sheet1.Columns.Get(0).DataField = "chkBox";
            this._spdReport_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(0).Label = "選択";
            this._spdReport_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(0).Width = 42F;
            this._spdReport_Sheet1.Columns.Get(1).DataField = "shutNo";
            this._spdReport_Sheet1.Columns.Get(1).Label = "出力No";
            this._spdReport_Sheet1.Columns.Get(1).Locked = true;
            this._spdReport_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(1).Width = 72F;
            textCellType1.ReadOnly = true;
            this._spdReport_Sheet1.Columns.Get(2).CellType = textCellType1;
            this._spdReport_Sheet1.Columns.Get(2).DataField = "seiZumi";
            this._spdReport_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(2).Label = "請求書発行";
            this._spdReport_Sheet1.Columns.Get(2).Width = 78F;
            this._spdReport_Sheet1.Columns.Get(3).DataField = "seqNo";
            this._spdReport_Sheet1.Columns.Get(3).Label = "シークエンスNo";
            this._spdReport_Sheet1.Columns.Get(3).Locked = true;
            this._spdReport_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(4).DataField = "jyutNo";
            this._spdReport_Sheet1.Columns.Get(4).Label = "受注No";
            this._spdReport_Sheet1.Columns.Get(4).Locked = true;
            this._spdReport_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(4).Width = 107F;
            this._spdReport_Sheet1.Columns.Get(5).DataField = "jyMeiNo";
            this._spdReport_Sheet1.Columns.Get(5).Label = "受注明細No";
            this._spdReport_Sheet1.Columns.Get(5).Locked = true;
            this._spdReport_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(6).DataField = "urMeiNo";
            this._spdReport_Sheet1.Columns.Get(6).Label = "売上明細No";
            this._spdReport_Sheet1.Columns.Get(6).Locked = true;
            this._spdReport_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(7).DataField = "renBan";
            this._spdReport_Sheet1.Columns.Get(7).Label = "連番";
            this._spdReport_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(8).DataField = "naiyo";
            this._spdReport_Sheet1.Columns.Get(8).Label = "内容";
            this._spdReport_Sheet1.Columns.Get(8).Locked = true;
            this._spdReport_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(8).Width = 262F;
            this._spdReport_Sheet1.Columns.Get(9).DataField = "himoku";
            this._spdReport_Sheet1.Columns.Get(9).Label = "費目";
            this._spdReport_Sheet1.Columns.Get(9).Locked = true;
            this._spdReport_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(9).Width = 61F;
            this._spdReport_Sheet1.Columns.Get(10).DataField = "bumonCd";
            this._spdReport_Sheet1.Columns.Get(10).Label = "部門コード";
            this._spdReport_Sheet1.Columns.Get(10).Locked = true;
            this._spdReport_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(10).Width = 89F;
            this._spdReport_Sheet1.Columns.Get(11).DataField = "bumonNm";
            this._spdReport_Sheet1.Columns.Get(11).Label = "部門名";
            this._spdReport_Sheet1.Columns.Get(11).Locked = true;
            this._spdReport_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(11).Width = 92F;
            this._spdReport_Sheet1.Columns.Get(12).DataField = "atesaki";
            this._spdReport_Sheet1.Columns.Get(12).Label = "宛先";
            this._spdReport_Sheet1.Columns.Get(12).Locked = true;
            this._spdReport_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(12).Width = 151F;
            this._spdReport_Sheet1.Columns.Get(13).DataField = "kikan";
            this._spdReport_Sheet1.Columns.Get(13).Label = "期間";
            this._spdReport_Sheet1.Columns.Get(13).Locked = true;
            this._spdReport_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(13).Width = 148F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.MaximumValue = 9999999999999.99;
            numberCellType1.MinimumValue = -9999999999999.99;
            numberCellType1.ShowSeparator = true;
            this._spdReport_Sheet1.Columns.Get(14).CellType = numberCellType1;
            this._spdReport_Sheet1.Columns.Get(14).DataField = "kingaku";
            this._spdReport_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this._spdReport_Sheet1.Columns.Get(14).Label = "金額";
            this._spdReport_Sheet1.Columns.Get(14).Locked = true;
            this._spdReport_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(14).Width = 97F;
            this._spdReport_Sheet1.Columns.Get(15).DataField = "biko";
            this._spdReport_Sheet1.Columns.Get(15).Label = "備考";
            this._spdReport_Sheet1.Columns.Get(15).Locked = true;
            this._spdReport_Sheet1.Columns.Get(15).Width = 124F;
            this._spdReport_Sheet1.DataAutoCellTypes = false;
            this._spdReport_Sheet1.DataAutoSizeColumns = false;
            this._spdReport_Sheet1.DataSource = this._bsRepKmnList;
            this._spdReport_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this._spdReport_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdReport_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdReport_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this._spdReport_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdReport_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdReport_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdReport_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this._spdReport_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdReport_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.spdReport.SetViewportLeftColumn(0, 0, 3);
            this.spdReport.SetActiveViewport(0, 1, 0);
            // 
            // _bsRepKmnList
            // 
            this._bsRepKmnList.DataMember = "RepKmnList";
            this._bsRepKmnList.DataSource = this.repDSKmn;
            // 
            // repDSKmn
            // 
            this.repDSKmn.DataSetName = "RepDSKmn";
            this.repDSKmn.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtYm
            // 
            this.txtYm.DisplayMode = Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.DisplayMode.COMBO;
            this.txtYm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtYm.Location = new System.Drawing.Point(71, 19);
            this.txtYm.MinimumSize = new System.Drawing.Size(82, 21);
            this.txtYm.Name = "txtYm";
            this.txtYm.Size = new System.Drawing.Size(82, 21);
            this.txtYm.TabIndex = 0;
            this.txtYm.ValidateDisableOnce = false;
            this.txtYm.Enter += new System.EventHandler(this.condChg);
            // 
            // lblYyyyMm
            // 
            this.lblYyyyMm.AutoSize = true;
            this.lblYyyyMm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblYyyyMm.Location = new System.Drawing.Point(12, 24);
            this.lblYyyyMm.Name = "lblYyyyMm";
            this.lblYyyyMm.Size = new System.Drawing.Size(53, 12);
            this.lblYyyyMm.TabIndex = 31;
            this.lblYyyyMm.Text = "請求年月";
            // 
            // cmbBusho
            // 
            this.cmbBusho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusho.FormattingEnabled = true;
            this.cmbBusho.Location = new System.Drawing.Point(232, 18);
            this.cmbBusho.MinimumSize = new System.Drawing.Size(121, 0);
            this.cmbBusho.Name = "cmbBusho";
            this.cmbBusho.Size = new System.Drawing.Size(121, 20);
            this.cmbBusho.TabIndex = 32;
            this.cmbBusho.SelectedIndexChanged += new System.EventHandler(this.cmbBusho_SelectedIndexChanged);
            this.cmbBusho.Enter += new System.EventHandler(this.cmbBushoChg);
            // 
            // lblBumon
            // 
            this.lblBumon.AutoSize = true;
            this.lblBumon.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblBumon.Location = new System.Drawing.Point(163, 24);
            this.lblBumon.Name = "lblBumon";
            this.lblBumon.Size = new System.Drawing.Size(65, 12);
            this.lblBumon.TabIndex = 33;
            this.lblBumon.Text = "請求先部門";
            // 
            // ckbFin
            // 
            this.ckbFin.AutoSize = true;
            this.ckbFin.Location = new System.Drawing.Point(524, 22);
            this.ckbFin.Name = "ckbFin";
            this.ckbFin.Size = new System.Drawing.Size(60, 16);
            this.ckbFin.TabIndex = 34;
            this.ckbFin.Text = "最終版";
            this.ckbFin.UseVisualStyleBackColor = true;
            this.ckbFin.Enter += new System.EventHandler(this.ckbFinChg);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblOutput.Location = new System.Drawing.Point(362, 24);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(53, 12);
            this.lblOutput.TabIndex = 36;
            this.lblOutput.Text = "出力単位";
            // 
            // cmbOutTanni
            // 
            this.cmbOutTanni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutTanni.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOutTanni.FormattingEnabled = true;
            this.cmbOutTanni.Location = new System.Drawing.Point(421, 18);
            this.cmbOutTanni.Name = "cmbOutTanni";
            this.cmbOutTanni.Size = new System.Drawing.Size(78, 20);
            this.cmbOutTanni.TabIndex = 37;
            this.cmbOutTanni.SelectedIndexChanged += new System.EventHandler(this.cmbOutTanni_SelectedIndexChanged);
            this.cmbOutTanni.Enter += new System.EventHandler(this.cmbOutTanniChg);
            // 
            // ReportKmnList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 666);
            this.Controls.Add(this.cmbOutTanni);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.ckbFin);
            this.Controls.Add(this.lblBumon);
            this.Controls.Add(this.cmbBusho);
            this.Controls.Add(this.lblYyyyMm);
            this.Controls.Add(this.btnSrc);
            this.Controls.Add(this.btnXls);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.spdReport);
            this.Controls.Add(this.txtYm);
            this.MinimumSize = new System.Drawing.Size(900, 300);
            this.Name = "ReportKmnList";
            this.Text = "請求明細一覧";
            this.Load += new System.EventHandler(this.ReportKmn_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.ReportKmn_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.txtYm, 0);
            this.Controls.SetChildIndex(this.spdReport, 0);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.btnXls, 0);
            this.Controls.SetChildIndex(this.btnSrc, 0);
            this.Controls.SetChildIndex(this.lblYyyyMm, 0);
            this.Controls.SetChildIndex(this.cmbBusho, 0);
            this.Controls.SetChildIndex(this.lblBumon, 0);
            this.Controls.SetChildIndex(this.ckbFin, 0);
            this.Controls.SetChildIndex(this.lblOutput, 0);
            this.Controls.SetChildIndex(this.cmbOutTanni, 0);
            ((System.ComponentModel.ISupportInitialize)(this.spdReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdReport_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsRepKmnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDSKmn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnSrc;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnXls;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHlp;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnEnd;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread spdReport;
        private FarPoint.Win.Spread.SheetView _spdReport_Sheet1;
        protected Isid.NJ.View.Widget.NJToolTip njToolTip1;
        private Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl txtYm;
        private Isid.NJ.View.Widget.NJLabel lblYyyyMm;
        private System.Windows.Forms.ComboBox cmbBusho;
        private Isid.NJ.View.Widget.NJLabel lblBumon;
        private System.Windows.Forms.BindingSource _bsRepKmnList;
        private Isid.KKH.Kmn.Schema.RepDSKmn repDSKmn;
        private System.Windows.Forms.CheckBox ckbFin;
        private Isid.NJ.View.Widget.NJLabel lblOutput;
        private Isid.KKH.Common.KKHView.Common.Control.KkhComboBox cmbOutTanni;
    }
}