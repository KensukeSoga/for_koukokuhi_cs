namespace Isid.KKH.Kmn.View.Detail
{
    partial class DetailKmnBulkRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailKmnBulkRegister));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.lblHinmoku = new Isid.NJ.View.Widget.NJLabel();
            this.CmbSeikyusakiBumon = new Isid.KKH.Common.KKHView.Common.Control.KkhComboBox();
            this.njLabel1 = new Isid.NJ.View.Widget.NJLabel();
            this.txtSeikyuYyyymm = new Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl();
            this.btnCancel = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.spdDetailInput = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.spdDetailInput_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this._bsKkhDetail = new System.Windows.Forms.BindingSource(this.components);
            this._dsDetailKmn = new Isid.KKH.Kmn.Schema.DetailDSKmn();
            this.btnMeiToroku = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            ((System.ComponentModel.ISupportInitialize)(this.spdDetailInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDetailInput_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsKkhDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dsDetailKmn)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHinmoku
            // 
            this.lblHinmoku.AutoSize = true;
            this.lblHinmoku.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHinmoku.Location = new System.Drawing.Point(33, 17);
            this.lblHinmoku.Name = "lblHinmoku";
            this.lblHinmoku.Size = new System.Drawing.Size(77, 12);
            this.lblHinmoku.TabIndex = 61;
            this.lblHinmoku.Text = "請求先部門名";
            // 
            // CmbSeikyusakiBumon
            // 
            this.CmbSeikyusakiBumon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSeikyusakiBumon.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSeikyusakiBumon.FormattingEnabled = true;
            this.CmbSeikyusakiBumon.Location = new System.Drawing.Point(116, 14);
            this.CmbSeikyusakiBumon.Name = "CmbSeikyusakiBumon";
            this.CmbSeikyusakiBumon.Size = new System.Drawing.Size(182, 20);
            this.CmbSeikyusakiBumon.TabIndex = 102;
            // 
            // njLabel1
            // 
            this.njLabel1.AutoSize = true;
            this.njLabel1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.njLabel1.Location = new System.Drawing.Point(304, 17);
            this.njLabel1.Name = "njLabel1";
            this.njLabel1.Size = new System.Drawing.Size(53, 12);
            this.njLabel1.TabIndex = 103;
            this.njLabel1.Text = "請求年月";
            // 
            // txtSeikyuYyyymm
            // 
            this.txtSeikyuYyyymm.DisplayMode = Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.DisplayMode.COMBO;
            this.txtSeikyuYyyymm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSeikyuYyyymm.Location = new System.Drawing.Point(363, 14);
            this.txtSeikyuYyyymm.MinimumSize = new System.Drawing.Size(82, 21);
            this.txtSeikyuYyyymm.Name = "txtSeikyuYyyymm";
            this.txtSeikyuYyyymm.Size = new System.Drawing.Size(82, 21);
            this.txtSeikyuYyyymm.TabIndex = 108;
            this.txtSeikyuYyyymm.ValidateDisableOnce = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(844, 419);
            this.btnCancel.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseDownImage")));
            this.btnCancel.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseLeaveImage")));
            this.btnCancel.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseMoveImage")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 22);
            this.btnCancel.TabIndex = 111;
            this.btnCancel.Text = "   キャンセル";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // spdDetailInput
            // 
            this.spdDetailInput.AccessibleDescription = "spdDetailInput, Sheet1, Row 0, Column 0, ";
            this.spdDetailInput.AllowUndo = false;
            this.spdDetailInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spdDetailInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spdDetailInput.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.spdDetailInput.EditModeReplace = true;
            this.spdDetailInput.EnableCustomSorting = false;
            this.spdDetailInput.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.spdDetailInput.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdDetailInput.Location = new System.Drawing.Point(12, 40);
            this.spdDetailInput.Name = "spdDetailInput";
            this.spdDetailInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdDetailInput.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.spdDetailInput.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdDetailInput_Sheet1});
            this.spdDetailInput.Size = new System.Drawing.Size(944, 370);
            this.spdDetailInput.TabIndex = 112;
            this.spdDetailInput.TabStripRatio = 0.50733137829912;
            this.spdDetailInput.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // spdDetailInput_Sheet1
            // 
            this.spdDetailInput_Sheet1.Reset();
            this.spdDetailInput_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDetailInput_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdDetailInput_Sheet1.ColumnCount = 7;
            this.spdDetailInput_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.spdDetailInput_Sheet1.AutoGenerateColumns = false;
            this.spdDetailInput_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "品目1";
            this.spdDetailInput_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "品目2";
            this.spdDetailInput_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "品目3";
            this.spdDetailInput_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "費目";
            this.spdDetailInput_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "期間";
            this.spdDetailInput_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "合計金額";
            this.spdDetailInput_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "消費税合計";
            this.spdDetailInput_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDetailInput_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spdDetailInput_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdDetailInput_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDetailInput_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            textCellType1.MaxLength = 15;
            this.spdDetailInput_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdDetailInput_Sheet1.Columns.Get(0).DataField = "Hinmoku1";
            this.spdDetailInput_Sheet1.Columns.Get(0).Label = "品目1";
            this.spdDetailInput_Sheet1.Columns.Get(0).Width = 150F;
            textCellType2.MaxLength = 15;
            this.spdDetailInput_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.spdDetailInput_Sheet1.Columns.Get(1).DataField = "Hinmoku2";
            this.spdDetailInput_Sheet1.Columns.Get(1).Label = "品目2";
            this.spdDetailInput_Sheet1.Columns.Get(1).Width = 150F;
            textCellType3.MaxLength = 15;
            this.spdDetailInput_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.spdDetailInput_Sheet1.Columns.Get(2).DataField = "Hinmoku3";
            this.spdDetailInput_Sheet1.Columns.Get(2).Label = "品目3";
            this.spdDetailInput_Sheet1.Columns.Get(2).Locked = false;
            this.spdDetailInput_Sheet1.Columns.Get(2).Width = 150F;
            textCellType4.MaxLength = 20;
            this.spdDetailInput_Sheet1.Columns.Get(3).CellType = textCellType4;
            this.spdDetailInput_Sheet1.Columns.Get(3).DataField = "Himoku";
            this.spdDetailInput_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdDetailInput_Sheet1.Columns.Get(3).Label = "費目";
            this.spdDetailInput_Sheet1.Columns.Get(3).Locked = false;
            this.spdDetailInput_Sheet1.Columns.Get(3).Width = 90F;
            textCellType5.MaxLength = 40;
            this.spdDetailInput_Sheet1.Columns.Get(4).CellType = textCellType5;
            this.spdDetailInput_Sheet1.Columns.Get(4).DataField = "Kikan";
            this.spdDetailInput_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdDetailInput_Sheet1.Columns.Get(4).Label = "期間";
            this.spdDetailInput_Sheet1.Columns.Get(4).Width = 150F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.MaximumValue = 9999999999999;
            numberCellType1.MinimumValue = -9999999999999;
            numberCellType1.ShowSeparator = true;
            this.spdDetailInput_Sheet1.Columns.Get(5).CellType = numberCellType1;
            this.spdDetailInput_Sheet1.Columns.Get(5).DataField = "GokeiKingaku";
            this.spdDetailInput_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDetailInput_Sheet1.Columns.Get(5).Label = "合計金額";
            this.spdDetailInput_Sheet1.Columns.Get(5).Width = 100F;
            numberCellType2.DecimalPlaces = 0;
            numberCellType2.MaximumValue = 9999999999;
            numberCellType2.MinimumValue = -9999999999;
            numberCellType2.ShowSeparator = true;
            this.spdDetailInput_Sheet1.Columns.Get(6).CellType = numberCellType2;
            this.spdDetailInput_Sheet1.Columns.Get(6).DataField = "GokeiZeigaku";
            this.spdDetailInput_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDetailInput_Sheet1.Columns.Get(6).Label = "消費税合計";
            this.spdDetailInput_Sheet1.Columns.Get(6).Width = 100F;
            this.spdDetailInput_Sheet1.DataAutoCellTypes = false;
            this.spdDetailInput_Sheet1.DataAutoHeadings = false;
            this.spdDetailInput_Sheet1.DataAutoSizeColumns = false;
            this.spdDetailInput_Sheet1.DataSource = this._bsKkhDetail;
            this.spdDetailInput_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDetailInput_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdDetailInput_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDetailInput_Sheet1.RowHeader.Columns.Get(0).Width = 29F;
            this.spdDetailInput_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spdDetailInput_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdDetailInput_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDetailInput_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDetailInput_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.MultiRange;
            this.spdDetailInput_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spdDetailInput_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdDetailInput_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdDetailInput_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.spdDetailInput.SetActiveViewport(0, 1, 0);
            // 
            // _bsKkhDetail
            // 
            this._bsKkhDetail.DataMember = "KkhDetail";
            this._bsKkhDetail.DataSource = this._dsDetailKmn;
            // 
            // _dsDetailKmn
            // 
            this._dsDetailKmn.DataSetName = "DetailDSKmn";
            this._dsDetailKmn.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnMeiToroku
            // 
            this.btnMeiToroku.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMeiToroku.BackColor = System.Drawing.Color.Transparent;
            this.btnMeiToroku.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMeiToroku.FlatAppearance.BorderSize = 0;
            this.btnMeiToroku.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMeiToroku.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMeiToroku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeiToroku.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMeiToroku.Image = ((System.Drawing.Image)(resources.GetObject("btnMeiToroku.Image")));
            this.btnMeiToroku.Location = new System.Drawing.Point(725, 419);
            this.btnMeiToroku.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnMeiToroku.MouseDownImage")));
            this.btnMeiToroku.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnMeiToroku.MouseLeaveImage")));
            this.btnMeiToroku.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnMeiToroku.MouseMoveImage")));
            this.btnMeiToroku.Name = "btnMeiToroku";
            this.btnMeiToroku.Size = new System.Drawing.Size(113, 22);
            this.btnMeiToroku.TabIndex = 113;
            this.btnMeiToroku.Text = "明細登録";
            this.btnMeiToroku.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMeiToroku.UseVisualStyleBackColor = false;
            this.btnMeiToroku.Click += new System.EventHandler(this.btnMeiToroku_Click);
            // 
            // DetailKmnBulkRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 448);
            this.Controls.Add(this.btnMeiToroku);
            this.Controls.Add(this.spdDetailInput);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtSeikyuYyyymm);
            this.Controls.Add(this.njLabel1);
            this.Controls.Add(this.CmbSeikyusakiBumon);
            this.Controls.Add(this.lblHinmoku);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DetailKmnBulkRegister";
            this.Text = "一括登録";
            this.Load += new System.EventHandler(this.DetailKmnBulkRegister_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.DetailKmnBulkRegister_ProcessAffterNavigating);
            ((System.ComponentModel.ISupportInitialize)(this.spdDetailInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDetailInput_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsKkhDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dsDetailKmn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Isid.NJ.View.Widget.NJLabel lblHinmoku;
        private Isid.KKH.Common.KKHView.Common.Control.KkhComboBox CmbSeikyusakiBumon;
        protected Isid.NJ.View.Widget.NJLabel njLabel1;
        protected Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl txtSeikyuYyyymm;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnCancel;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhSpread spdDetailInput;
        private FarPoint.Win.Spread.SheetView spdDetailInput_Sheet1;
        private System.Windows.Forms.BindingSource _bsKkhDetail;
        private Isid.KKH.Kmn.Schema.DetailDSKmn _dsDetailKmn;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnMeiToroku;
    }
}