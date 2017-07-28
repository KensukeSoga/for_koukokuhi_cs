namespace Isid.KKH.Lion.View.Detail
{
    partial class FindLionCodeItr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindLionCodeItr));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.CAN = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.OK = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.kkhSpread1 = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.kkhSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.kkhSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kkhSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // CAN
            // 
            this.CAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CAN.BackColor = System.Drawing.Color.Transparent;
            this.CAN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.CAN.FlatAppearance.BorderSize = 0;
            this.CAN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.CAN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.CAN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CAN.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CAN.Image = ((System.Drawing.Image)(resources.GetObject("CAN.Image")));
            this.CAN.Location = new System.Drawing.Point(661, 541);
            this.CAN.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("CAN.MouseDownImage")));
            this.CAN.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("CAN.MouseLeaveImage")));
            this.CAN.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("CAN.MouseMoveImage")));
            this.CAN.Name = "CAN";
            this.CAN.Size = new System.Drawing.Size(113, 22);
            this.CAN.TabIndex = 0;
            this.CAN.TabStop = false;
            this.CAN.Text = "   キャンセル";
            this.CAN.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.CAN.UseVisualStyleBackColor = false;
            this.CAN.Click += new System.EventHandler(this.CAN_Click);
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.BackColor = System.Drawing.Color.Transparent;
            this.OK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.OK.FlatAppearance.BorderSize = 0;
            this.OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OK.Image = ((System.Drawing.Image)(resources.GetObject("OK.Image")));
            this.OK.Location = new System.Drawing.Point(542, 541);
            this.OK.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("OK.MouseDownImage")));
            this.OK.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("OK.MouseLeaveImage")));
            this.OK.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("OK.MouseMoveImage")));
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(113, 22);
            this.OK.TabIndex = 1;
            this.OK.TabStop = false;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // kkhSpread1
            // 
            this.kkhSpread1.AccessibleDescription = "kkhSpread1, Sheet1";
            this.kkhSpread1.BackColor = System.Drawing.SystemColors.Control;
            this.kkhSpread1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kkhSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.kkhSpread1.Location = new System.Drawing.Point(3, 0);
            this.kkhSpread1.Name = "kkhSpread1";
            this.kkhSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.kkhSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.kkhSpread1_Sheet1});
            this.kkhSpread1.Size = new System.Drawing.Size(771, 535);
            this.kkhSpread1.TabIndex = 2;
            this.kkhSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.kkhSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.kkhSpread1_CellDoubleClick);
            // 
            // kkhSpread1_Sheet1
            // 
            this.kkhSpread1_Sheet1.Reset();
            this.kkhSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.kkhSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.kkhSpread1_Sheet1.ColumnCount = 5;
            this.kkhSpread1_Sheet1.RowCount = 0;
            this.kkhSpread1_Sheet1.RowHeader.ColumnCount = 0;
            this.kkhSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.kkhSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "コード";
            this.kkhSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "名称";
            this.kkhSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "スペースコード";
            this.kkhSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "スペース名";
            this.kkhSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "料金";
            this.kkhSpread1_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kkhSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.kkhSpread1_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.kkhSpread1_Sheet1.Columns.Get(0).Label = "コード";
            this.kkhSpread1_Sheet1.Columns.Get(0).Locked = true;
            this.kkhSpread1_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.kkhSpread1_Sheet1.Columns.Get(0).Width = 75F;
            this.kkhSpread1_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.kkhSpread1_Sheet1.Columns.Get(1).Label = "名称";
            this.kkhSpread1_Sheet1.Columns.Get(1).Locked = true;
            this.kkhSpread1_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.kkhSpread1_Sheet1.Columns.Get(1).Width = 225F;
            this.kkhSpread1_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.kkhSpread1_Sheet1.Columns.Get(2).Label = "スペースコード";
            this.kkhSpread1_Sheet1.Columns.Get(2).Locked = true;
            this.kkhSpread1_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.kkhSpread1_Sheet1.Columns.Get(2).Width = 162F;
            this.kkhSpread1_Sheet1.Columns.Get(3).CellType = textCellType4;
            this.kkhSpread1_Sheet1.Columns.Get(3).Label = "スペース名";
            this.kkhSpread1_Sheet1.Columns.Get(3).Locked = true;
            this.kkhSpread1_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.kkhSpread1_Sheet1.Columns.Get(3).Width = 149F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.MaximumValue = 999999999;
            numberCellType1.MinimumValue = -999999999;
            this.kkhSpread1_Sheet1.Columns.Get(4).CellType = numberCellType1;
            this.kkhSpread1_Sheet1.Columns.Get(4).Label = "料金";
            this.kkhSpread1_Sheet1.Columns.Get(4).Locked = true;
            this.kkhSpread1_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.kkhSpread1_Sheet1.Columns.Get(4).Width = 138F;
            this.kkhSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.kkhSpread1_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kkhSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.kkhSpread1_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.kkhSpread1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.kkhSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kkhSpread1_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.kkhSpread1_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.kkhSpread1.SetActiveViewport(0, 1, 0);
            // 
            // FindLionCodeItr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 575);
            this.Controls.Add(this.kkhSpread1);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.CAN);
            this.Name = "FindLionCodeItr";
            this.Text = "コード一覧";
            this.Load += new System.EventHandler(this.FindLionCodeItr_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.FindLionCodeItr_ProcessAffterNavigating);
            ((System.ComponentModel.ISupportInitialize)(this.kkhSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kkhSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Isid.KKH.Common.KKHView.Common.Control.KkhButton CAN;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton OK;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread kkhSpread1;
        private FarPoint.Win.Spread.SheetView kkhSpread1_Sheet1;
    }
}