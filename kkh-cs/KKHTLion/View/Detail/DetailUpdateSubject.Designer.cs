namespace Isid.KKH.Lion.View.Detail
{
    partial class DetailUpdateSubject
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
            if (disposing && ( components != null ))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailUpdateSubject));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.btnCan = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnOk = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.kkhSpread1 = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.kkhSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.kkhSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kkhSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCan
            // 
            this.btnCan.BackColor = System.Drawing.Color.Transparent;
            this.btnCan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCan.FlatAppearance.BorderSize = 0;
            this.btnCan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCan.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCan.Image = ((System.Drawing.Image)(resources.GetObject("btnCan.Image")));
            this.btnCan.Location = new System.Drawing.Point(758, 412);
            this.btnCan.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCan.MouseDownImage")));
            this.btnCan.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnCan.MouseLeaveImage")));
            this.btnCan.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCan.MouseMoveImage")));
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(113, 22);
            this.btnCan.TabIndex = 1;
            this.btnCan.TabStop = false;
            this.btnCan.Text = "   キャンセル";
            this.btnCan.UseVisualStyleBackColor = false;
            this.btnCan.Click += new System.EventHandler(this.btnCan_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(639, 412);
            this.btnOk.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseDownImage")));
            this.btnOk.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseLeaveImage")));
            this.btnOk.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseMoveImage")));
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(113, 22);
            this.btnOk.TabIndex = 2;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // kkhSpread1
            // 
            this.kkhSpread1.AccessibleDescription = "kkhSpread1, Sheet1, Row 0, Column 0, ";
            this.kkhSpread1.BackColor = System.Drawing.SystemColors.Control;
            this.kkhSpread1.EditModeReplace = true;
            this.kkhSpread1.EnableCustomSorting = false;
            this.kkhSpread1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kkhSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.kkhSpread1.Location = new System.Drawing.Point(2, 2);
            this.kkhSpread1.Name = "kkhSpread1";
            this.kkhSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.kkhSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.kkhSpread1_Sheet1});
            this.kkhSpread1.Size = new System.Drawing.Size(869, 404);
            this.kkhSpread1.TabIndex = 3;
            this.kkhSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.kkhSpread1.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.kkhSpread1_Change);
            // 
            // kkhSpread1_Sheet1
            // 
            this.kkhSpread1_Sheet1.Reset();
            this.kkhSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.kkhSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.kkhSpread1_Sheet1.ColumnCount = 7;
            this.kkhSpread1_Sheet1.RowCount = 0;
            this.kkhSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.kkhSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "売上明細No.";
            this.kkhSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "請求年月";
            this.kkhSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "業務区分";
            this.kkhSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "件名";
            this.kkhSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "費目名";
            this.kkhSpread1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "局誌名";
            this.kkhSpread1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "請求金額";
            this.kkhSpread1_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kkhSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.kkhSpread1_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.ColumnHeader.Rows.Get(0).Height = 46F;
            this.kkhSpread1_Sheet1.Columns.Get(0).Label = "売上明細No.";
            this.kkhSpread1_Sheet1.Columns.Get(0).Locked = true;
            this.kkhSpread1_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.kkhSpread1_Sheet1.Columns.Get(0).Width = 139F;
            this.kkhSpread1_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.kkhSpread1_Sheet1.Columns.Get(1).Label = "請求年月";
            this.kkhSpread1_Sheet1.Columns.Get(1).Locked = true;
            this.kkhSpread1_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.kkhSpread1_Sheet1.Columns.Get(1).Width = 65F;
            this.kkhSpread1_Sheet1.Columns.Get(2).CellType = textCellType2;
            this.kkhSpread1_Sheet1.Columns.Get(2).Label = "業務区分";
            this.kkhSpread1_Sheet1.Columns.Get(2).Locked = true;
            this.kkhSpread1_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.kkhSpread1_Sheet1.Columns.Get(2).Width = 59F;
            this.kkhSpread1_Sheet1.Columns.Get(3).CellType = textCellType3;
            this.kkhSpread1_Sheet1.Columns.Get(3).Label = "件名";
            this.kkhSpread1_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.kkhSpread1_Sheet1.Columns.Get(3).Width = 229F;
            this.kkhSpread1_Sheet1.Columns.Get(4).Label = "費目名";
            this.kkhSpread1_Sheet1.Columns.Get(4).Locked = true;
            this.kkhSpread1_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.kkhSpread1_Sheet1.Columns.Get(4).Width = 101F;
            this.kkhSpread1_Sheet1.Columns.Get(5).Label = "局誌名";
            this.kkhSpread1_Sheet1.Columns.Get(5).Locked = true;
            this.kkhSpread1_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.kkhSpread1_Sheet1.Columns.Get(5).Width = 103F;
            this.kkhSpread1_Sheet1.Columns.Get(6).Label = "請求金額";
            this.kkhSpread1_Sheet1.Columns.Get(6).Locked = true;
            this.kkhSpread1_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.kkhSpread1_Sheet1.Columns.Get(6).Width = 117F;
            this.kkhSpread1_Sheet1.LockBackColor = System.Drawing.Color.Silver;
            this.kkhSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.kkhSpread1_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kkhSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.kkhSpread1_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kkhSpread1_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.kkhSpread1_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.kkhSpread1.SetActiveViewport(0, 1, 0);
            // 
            // DetailUpdateSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.ClientSize = new System.Drawing.Size(876, 445);
            this.Controls.Add(this.kkhSpread1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCan);
            this.Name = "DetailUpdateSubject";
            this.Text = "件名変更";
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.DetailTenpoItr_ProcessAffterNavigating);
            ((System.ComponentModel.ISupportInitialize)(this.kkhSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kkhSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnCan;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnOk;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread kkhSpread1;
        private FarPoint.Win.Spread.SheetView kkhSpread1_Sheet1;
    }
}
