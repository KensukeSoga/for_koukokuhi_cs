namespace Isid.KKH.Skyp.View.Detail
{
    partial class DetailOrderSkyp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailOrderSkyp));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.btnReg = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnEnd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.spdOrder = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this._spdOrder_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this._bsOrder = new System.Windows.Forms.BindingSource(this.components);
            this._dsDetailSkyp = new Isid.KKH.Skyp.Schema.DetailDSSkyp();
            ((System.ComponentModel.ISupportInitialize)(this.spdOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdOrder_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dsDetailSkyp)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReg
            // 
            this.btnReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReg.BackColor = System.Drawing.Color.Transparent;
            this.btnReg.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReg.FlatAppearance.BorderSize = 0;
            this.btnReg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReg.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReg.Image = ((System.Drawing.Image)(resources.GetObject("btnReg.Image")));
            this.btnReg.Location = new System.Drawing.Point(742, 634);
            this.btnReg.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnReg.MouseDownImage")));
            this.btnReg.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnReg.MouseLeaveImage")));
            this.btnReg.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnReg.MouseMoveImage")));
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(113, 22);
            this.btnReg.TabIndex = 1;
            this.btnReg.Text = "登録";
            this.btnReg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReg.UseVisualStyleBackColor = false;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnd.BackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEnd.FlatAppearance.BorderSize = 0;
            this.btnEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnd.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEnd.Image")));
            this.btnEnd.Location = new System.Drawing.Point(861, 634);
            this.btnEnd.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseDownImage")));
            this.btnEnd.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseLeaveImage")));
            this.btnEnd.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseMoveImage")));
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(113, 22);
            this.btnEnd.TabIndex = 2;
            this.btnEnd.Text = "   キャンセル";
            this.btnEnd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // spdOrder
            // 
            this.spdOrder.AccessibleDescription = "spdOrder, Sheet1, Row 0, Column 0, ";
            this.spdOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spdOrder.BackColor = System.Drawing.SystemColors.Control;
            this.spdOrder.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.spdOrder.EditModeReplace = true;
            this.spdOrder.EnableCustomSorting = false;
            this.spdOrder.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdOrder.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdOrder.Location = new System.Drawing.Point(5, 12);
            this.spdOrder.Name = "spdOrder";
            this.spdOrder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdOrder.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.spdOrder.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this._spdOrder_Sheet1});
            this.spdOrder.Size = new System.Drawing.Size(969, 616);
            this.spdOrder.TabIndex = 0;
            this.spdOrder.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdOrder.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdKkhDetail_EditChange);
            // 
            // _spdOrder_Sheet1
            // 
            this._spdOrder_Sheet1.Reset();
            this._spdOrder_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this._spdOrder_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this._spdOrder_Sheet1.ColumnCount = 7;
            this._spdOrder_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this._spdOrder_Sheet1.ColumnHeader.AutoTextIndex = 0;
            this._spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "媒体区分";
            this._spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "媒体名称";
            this._spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "発行期間";
            this._spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "金額";
            this._spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "消費税額";
            this._spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "請求金額";
            this._spdOrder_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "並び順";
            this._spdOrder_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdOrder_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdOrder_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this._spdOrder_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdOrder_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdOrder_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.Silver;
            this._spdOrder_Sheet1.Columns.Get(0).CellType = textCellType1;
            this._spdOrder_Sheet1.Columns.Get(0).DataField = "baitaiKbn";
            this._spdOrder_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this._spdOrder_Sheet1.Columns.Get(0).Label = "媒体区分";
            this._spdOrder_Sheet1.Columns.Get(0).Locked = true;
            this._spdOrder_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdOrder_Sheet1.Columns.Get(0).Width = 280F;
            this._spdOrder_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.Silver;
            this._spdOrder_Sheet1.Columns.Get(1).CellType = textCellType2;
            this._spdOrder_Sheet1.Columns.Get(1).DataField = "baitaiMeisyo";
            this._spdOrder_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this._spdOrder_Sheet1.Columns.Get(1).Label = "媒体名称";
            this._spdOrder_Sheet1.Columns.Get(1).Locked = true;
            this._spdOrder_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdOrder_Sheet1.Columns.Get(1).Width = 240F;
            this._spdOrder_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.Silver;
            this._spdOrder_Sheet1.Columns.Get(2).CellType = textCellType3;
            this._spdOrder_Sheet1.Columns.Get(2).DataField = "hakkoKikan";
            this._spdOrder_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this._spdOrder_Sheet1.Columns.Get(2).Label = "発行期間";
            this._spdOrder_Sheet1.Columns.Get(2).Locked = true;
            this._spdOrder_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdOrder_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.Silver;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.ShowSeparator = true;
            this._spdOrder_Sheet1.Columns.Get(3).CellType = numberCellType1;
            this._spdOrder_Sheet1.Columns.Get(3).DataField = "Kingaku";
            this._spdOrder_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this._spdOrder_Sheet1.Columns.Get(3).Label = "金額";
            this._spdOrder_Sheet1.Columns.Get(3).Locked = true;
            this._spdOrder_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdOrder_Sheet1.Columns.Get(3).Width = 100F;
            this._spdOrder_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.Silver;
            numberCellType2.DecimalPlaces = 0;
            numberCellType2.ShowSeparator = true;
            this._spdOrder_Sheet1.Columns.Get(4).CellType = numberCellType2;
            this._spdOrder_Sheet1.Columns.Get(4).DataField = "syohizeiGaku";
            this._spdOrder_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this._spdOrder_Sheet1.Columns.Get(4).Label = "消費税額";
            this._spdOrder_Sheet1.Columns.Get(4).Locked = true;
            this._spdOrder_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdOrder_Sheet1.Columns.Get(4).Width = 100F;
            this._spdOrder_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.Silver;
            numberCellType3.DecimalPlaces = 0;
            numberCellType3.ShowSeparator = true;
            this._spdOrder_Sheet1.Columns.Get(5).CellType = numberCellType3;
            this._spdOrder_Sheet1.Columns.Get(5).DataField = "seikyuKingaku";
            this._spdOrder_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this._spdOrder_Sheet1.Columns.Get(5).Label = "請求金額";
            this._spdOrder_Sheet1.Columns.Get(5).Locked = true;
            this._spdOrder_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdOrder_Sheet1.Columns.Get(5).Width = 100F;
            textCellType4.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
            textCellType4.MaxLength = 3;
            this._spdOrder_Sheet1.Columns.Get(6).CellType = textCellType4;
            this._spdOrder_Sheet1.Columns.Get(6).DataField = "narabiJun";
            this._spdOrder_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this._spdOrder_Sheet1.Columns.Get(6).Label = "並び順";
            this._spdOrder_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdOrder_Sheet1.Columns.Get(6).Width = 50F;
            this._spdOrder_Sheet1.DataAutoCellTypes = false;
            this._spdOrder_Sheet1.DataAutoHeadings = false;
            this._spdOrder_Sheet1.DataAutoSizeColumns = false;
            this._spdOrder_Sheet1.DataSource = this._bsOrder;
            this._spdOrder_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdOrder_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this._spdOrder_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdOrder_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdOrder_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this._spdOrder_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdOrder_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdOrder_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdOrder_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this._spdOrder_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdOrder_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.spdOrder.SetActiveViewport(0, 1, 0);
            // 
            // _bsOrder
            // 
            this._bsOrder.DataMember = "OrderData";
            this._bsOrder.DataSource = this._dsDetailSkyp;
            // 
            // _dsDetailSkyp
            // 
            this._dsDetailSkyp.DataSetName = "DetailDSSkyp";
            this._dsDetailSkyp.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DetailOrderSkyp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.ClientSize = new System.Drawing.Size(983, 668);
            this.ControlBox = true;
            this.Controls.Add(this.spdOrder);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.btnEnd);
            this.MaximizeBox = true;
            this.Name = "DetailOrderSkyp";
            this.Text = "並び順";
            this.Load += new System.EventHandler(this.DetailOrderSkyp_Load);
            this.Shown += new System.EventHandler(this.DetailOrderSkyp_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DetailOrderSkyp_FormClosing);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.DetailOrderSkyp_ProcessAffterNavigating);
            ((System.ComponentModel.ISupportInitialize)(this.spdOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdOrder_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dsDetailSkyp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnReg;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnEnd;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread spdOrder;
        private FarPoint.Win.Spread.SheetView _spdOrder_Sheet1;
        private System.Windows.Forms.BindingSource _bsOrder;
        private Isid.KKH.Skyp.Schema.DetailDSSkyp _dsDetailSkyp;
    }
}
