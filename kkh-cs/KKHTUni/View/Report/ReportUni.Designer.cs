namespace Isid.KKH.Uni.View.Report
{
    partial class ReportUni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportUni));
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType9 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType10 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.btnSrc = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnXls = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnEnd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.spdReport = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this._spdReport_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this._bsReport = new System.Windows.Forms.BindingSource(this.components);
            this._dsReportUni = new Isid.KKH.Uni.Schema.RepDsUni();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoOutPutNmB = new Isid.NJ.View.Widget.NJRadioButton();
            this.rdoOutPutNmA = new Isid.NJ.View.Widget.NJRadioButton();
            this.njToolTip1 = new Isid.NJ.View.Widget.NJToolTip();
            this.txtYm = new Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl();
            this.lblYyyyMm = new Isid.NJ.View.Widget.NJLabel();
            this.cmbBusho = new System.Windows.Forms.ComboBox();
            this.ｌｂｌBusho = new Isid.NJ.View.Widget.NJLabel();
            ((System.ComponentModel.ISupportInitialize)(this.spdReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdReport_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dsReportUni)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.btnSrc.Location = new System.Drawing.Point(481, 18);
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
            this.btnXls.Location = new System.Drawing.Point(600, 18);
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
            this.spdReport.Location = new System.Drawing.Point(5, 57);
            this.spdReport.Name = "spdReport";
            this.spdReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdReport.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this._spdReport_Sheet1});
            this.spdReport.Size = new System.Drawing.Size(960, 584);
            this.spdReport.TabIndex = 6;
            this.spdReport.TabStop = false;
            this.spdReport.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // _spdReport_Sheet1
            // 
            this._spdReport_Sheet1.Reset();
            this._spdReport_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this._spdReport_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this._spdReport_Sheet1.ColumnCount = 20;
            this._spdReport_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this._spdReport_Sheet1.ColumnHeader.AutoTextIndex = 0;
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "請求原票No";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "請求原票行No";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "受注No";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "業務区分";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "業務区分名";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "請求区分";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "種別コード";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "種別";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "件名";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "費目";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "内容";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "内容１";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "内容２";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "内容３";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "内容４";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "金額";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "消費税額";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "金額_受注ダウンロードデータ";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "消費税額_受注ダウンロードデータ";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "部署";
            this._spdReport_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdReport_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdReport_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this._spdReport_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdReport_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdReport_Sheet1.Columns.Get(0).DataField = "gpyNo";
            this._spdReport_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this._spdReport_Sheet1.Columns.Get(0).Label = "請求原票No";
            this._spdReport_Sheet1.Columns.Get(0).Locked = true;
            this._spdReport_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(0).Width = 100F;
            this._spdReport_Sheet1.Columns.Get(1).DataField = "mGpyNo";
            this._spdReport_Sheet1.Columns.Get(1).Label = "請求原票行No";
            this._spdReport_Sheet1.Columns.Get(1).Locked = true;
            this._spdReport_Sheet1.Columns.Get(1).Visible = false;
            this._spdReport_Sheet1.Columns.Get(2).DataField = "jutyuNo";
            this._spdReport_Sheet1.Columns.Get(2).Label = "受注No";
            this._spdReport_Sheet1.Columns.Get(2).Locked = true;
            this._spdReport_Sheet1.Columns.Get(2).Visible = false;
            this._spdReport_Sheet1.Columns.Get(3).DataField = "gyomkbn";
            this._spdReport_Sheet1.Columns.Get(3).Label = "業務区分";
            this._spdReport_Sheet1.Columns.Get(3).Locked = true;
            this._spdReport_Sheet1.Columns.Get(3).Visible = false;
            this._spdReport_Sheet1.Columns.Get(4).DataField = "gyomkbnNm";
            this._spdReport_Sheet1.Columns.Get(4).Label = "業務区分名";
            this._spdReport_Sheet1.Columns.Get(4).Locked = true;
            this._spdReport_Sheet1.Columns.Get(4).Visible = false;
            this._spdReport_Sheet1.Columns.Get(5).DataField = "seikbn";
            this._spdReport_Sheet1.Columns.Get(5).Label = "請求区分";
            this._spdReport_Sheet1.Columns.Get(5).Locked = true;
            this._spdReport_Sheet1.Columns.Get(5).Visible = false;
            this._spdReport_Sheet1.Columns.Get(6).DataField = "shubetsuCd";
            this._spdReport_Sheet1.Columns.Get(6).Label = "種別コード";
            this._spdReport_Sheet1.Columns.Get(6).Locked = true;
            this._spdReport_Sheet1.Columns.Get(6).Visible = false;
            this._spdReport_Sheet1.Columns.Get(7).DataField = "shubetsuNm";
            this._spdReport_Sheet1.Columns.Get(7).Label = "種別";
            this._spdReport_Sheet1.Columns.Get(7).Locked = true;
            this._spdReport_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(7).Width = 80F;
            this._spdReport_Sheet1.Columns.Get(8).DataField = "kenmei";
            this._spdReport_Sheet1.Columns.Get(8).Label = "件名";
            this._spdReport_Sheet1.Columns.Get(8).Locked = true;
            this._spdReport_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(8).Width = 200F;
            this._spdReport_Sheet1.Columns.Get(9).DataField = "himoku";
            this._spdReport_Sheet1.Columns.Get(9).Label = "費目";
            this._spdReport_Sheet1.Columns.Get(9).Locked = true;
            this._spdReport_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(10).DataField = "contents";
            this._spdReport_Sheet1.Columns.Get(10).Label = "内容";
            this._spdReport_Sheet1.Columns.Get(10).Locked = true;
            this._spdReport_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(10).Width = 500F;
            this._spdReport_Sheet1.Columns.Get(11).DataField = "contents1";
            this._spdReport_Sheet1.Columns.Get(11).Label = "内容１";
            this._spdReport_Sheet1.Columns.Get(11).Locked = true;
            this._spdReport_Sheet1.Columns.Get(11).Visible = false;
            this._spdReport_Sheet1.Columns.Get(12).DataField = "contents2";
            this._spdReport_Sheet1.Columns.Get(12).Label = "内容２";
            this._spdReport_Sheet1.Columns.Get(12).Locked = true;
            this._spdReport_Sheet1.Columns.Get(12).Visible = false;
            this._spdReport_Sheet1.Columns.Get(13).DataField = "contents3";
            this._spdReport_Sheet1.Columns.Get(13).Label = "内容３";
            this._spdReport_Sheet1.Columns.Get(13).Locked = true;
            this._spdReport_Sheet1.Columns.Get(13).Visible = false;
            this._spdReport_Sheet1.Columns.Get(14).DataField = "contents4";
            this._spdReport_Sheet1.Columns.Get(14).Label = "内容４";
            this._spdReport_Sheet1.Columns.Get(14).Locked = true;
            this._spdReport_Sheet1.Columns.Get(14).Visible = false;
            numberCellType9.DecimalPlaces = 0;
            numberCellType9.ShowSeparator = true;
            this._spdReport_Sheet1.Columns.Get(15).CellType = numberCellType9;
            this._spdReport_Sheet1.Columns.Get(15).DataField = "kngk";
            this._spdReport_Sheet1.Columns.Get(15).Label = "金額";
            this._spdReport_Sheet1.Columns.Get(15).Locked = true;
            this._spdReport_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(15).Width = 100F;
            numberCellType10.DecimalPlaces = 0;
            numberCellType10.ShowSeparator = true;
            this._spdReport_Sheet1.Columns.Get(16).CellType = numberCellType10;
            this._spdReport_Sheet1.Columns.Get(16).DataField = "tax";
            this._spdReport_Sheet1.Columns.Get(16).Label = "消費税額";
            this._spdReport_Sheet1.Columns.Get(16).Locked = true;
            this._spdReport_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(16).Width = 100F;
            this._spdReport_Sheet1.Columns.Get(17).DataField = "kngkJ";
            this._spdReport_Sheet1.Columns.Get(17).Label = "金額_受注ダウンロードデータ";
            this._spdReport_Sheet1.Columns.Get(17).Locked = true;
            this._spdReport_Sheet1.Columns.Get(17).Visible = false;
            this._spdReport_Sheet1.Columns.Get(18).DataField = "taxJ";
            this._spdReport_Sheet1.Columns.Get(18).Label = "消費税額_受注ダウンロードデータ";
            this._spdReport_Sheet1.Columns.Get(18).Locked = true;
            this._spdReport_Sheet1.Columns.Get(18).Visible = false;
            this._spdReport_Sheet1.Columns.Get(19).CellType = textCellType5;
            this._spdReport_Sheet1.Columns.Get(19).DataField = "busho";
            this._spdReport_Sheet1.Columns.Get(19).Label = "部署";
            this._spdReport_Sheet1.Columns.Get(19).Width = 200F;
            this._spdReport_Sheet1.DataAutoCellTypes = false;
            this._spdReport_Sheet1.DataAutoSizeColumns = false;
            this._spdReport_Sheet1.DataSource = this._bsReport;
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
            this.spdReport.SetActiveViewport(0, 1, 0);
            // 
            // _bsReport
            // 
            this._bsReport.DataMember = "ReportData";
            this._bsReport.DataSource = this._dsReportUni;
            // 
            // _dsReportUni
            // 
            this._dsReportUni.DataSetName = "RepDsUni";
            this._dsReportUni.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoOutPutNmB);
            this.groupBox1.Controls.Add(this.rdoOutPutNmA);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(159, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 40);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "帳票（広告費明細表）";
            // 
            // rdoOutPutNmB
            // 
            this.rdoOutPutNmB.AutoSize = true;
            this.rdoOutPutNmB.Location = new System.Drawing.Point(59, 18);
            this.rdoOutPutNmB.Name = "rdoOutPutNmB";
            this.rdoOutPutNmB.Size = new System.Drawing.Size(47, 16);
            this.rdoOutPutNmB.TabIndex = 1;
            this.rdoOutPutNmB.TabStop = true;
            this.rdoOutPutNmB.Text = "確定";
            this.rdoOutPutNmB.UseVisualStyleBackColor = true;
            this.rdoOutPutNmB.CheckedChanged += new System.EventHandler(this.rdoOutPutNm_CheckedChanged);
            // 
            // rdoOutPutNmA
            // 
            this.rdoOutPutNmA.AutoSize = true;
            this.rdoOutPutNmA.Location = new System.Drawing.Point(6, 18);
            this.rdoOutPutNmA.Name = "rdoOutPutNmA";
            this.rdoOutPutNmA.Size = new System.Drawing.Size(47, 16);
            this.rdoOutPutNmA.TabIndex = 0;
            this.rdoOutPutNmA.TabStop = true;
            this.rdoOutPutNmA.Text = "暫定";
            this.rdoOutPutNmA.UseVisualStyleBackColor = true;
            this.rdoOutPutNmA.CheckedChanged += new System.EventHandler(this.rdoOutPutNm_CheckedChanged);
            // 
            // txtYm
            // 
            this.txtYm.DisplayMode = Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.DisplayMode.COMBO;
            this.txtYm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtYm.Location = new System.Drawing.Point(56, 19);
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
            this.lblYyyyMm.Size = new System.Drawing.Size(29, 12);
            this.lblYyyyMm.TabIndex = 31;
            this.lblYyyyMm.Text = "年月";
            // 
            // cmbBusho
            // 
            this.cmbBusho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusho.FormattingEnabled = true;
            this.cmbBusho.Location = new System.Drawing.Point(341, 19);
            this.cmbBusho.MinimumSize = new System.Drawing.Size(121, 0);
            this.cmbBusho.Name = "cmbBusho";
            this.cmbBusho.Size = new System.Drawing.Size(121, 20);
            this.cmbBusho.TabIndex = 32;
            this.cmbBusho.Enter += new System.EventHandler(this.cmbBushoChg);
            // 
            // ｌｂｌBusho
            // 
            this.ｌｂｌBusho.AutoSize = true;
            this.ｌｂｌBusho.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ｌｂｌBusho.Location = new System.Drawing.Point(306, 24);
            this.ｌｂｌBusho.Name = "ｌｂｌBusho";
            this.ｌｂｌBusho.Size = new System.Drawing.Size(29, 12);
            this.ｌｂｌBusho.TabIndex = 33;
            this.ｌｂｌBusho.Text = "部署";
            // 
            // ReportUni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 666);
            this.Controls.Add(this.ｌｂｌBusho);
            this.Controls.Add(this.cmbBusho);
            this.Controls.Add(this.lblYyyyMm);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSrc);
            this.Controls.Add(this.btnXls);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.spdReport);
            this.Controls.Add(this.txtYm);
            this.MinimumSize = new System.Drawing.Size(900, 300);
            this.Name = "ReportUni";
            this.Text = "広告費明細表（暫定・確定）";
            this.Load += new System.EventHandler(this.ReportUni_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.ReportUni_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.txtYm, 0);
            this.Controls.SetChildIndex(this.spdReport, 0);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.btnXls, 0);
            this.Controls.SetChildIndex(this.btnSrc, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblYyyyMm, 0);
            this.Controls.SetChildIndex(this.cmbBusho, 0);
            this.Controls.SetChildIndex(this.ｌｂｌBusho, 0);
            ((System.ComponentModel.ISupportInitialize)(this.spdReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdReport_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dsReportUni)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        protected Isid.NJ.View.Widget.NJRadioButton rdoOutPutNmA;
        protected Isid.NJ.View.Widget.NJRadioButton rdoOutPutNmB;
        private System.Windows.Forms.BindingSource _bsReport;
        private Isid.KKH.Uni.Schema.RepDsUni _dsReportUni;
        protected Isid.NJ.View.Widget.NJToolTip njToolTip1;
        private Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl txtYm;
        private Isid.NJ.View.Widget.NJLabel lblYyyyMm;
        private System.Windows.Forms.ComboBox cmbBusho;
        private Isid.NJ.View.Widget.NJLabel ｌｂｌBusho;
    }
}