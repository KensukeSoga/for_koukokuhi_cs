namespace Isid.KKH.Lion.View.Mast
{
    partial class frmMastLionZashiRyoSpc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMastLionZashiRyoSpc));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.btnEnd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.kkhSpread1 = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.kkhSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.Help = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.UpDate = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.Delete = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.S_Hyoji = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.label1 = new Isid.NJ.View.Widget.NJLabel();
            this.label2 = new Isid.NJ.View.Widget.NJLabel();
            this.label3 = new Isid.NJ.View.Widget.NJLabel();
            this.label4 = new Isid.NJ.View.Widget.NJLabel();
            this.label5 = new Isid.NJ.View.Widget.NJLabel();
            this.njToolTip1 = new Isid.NJ.View.Widget.NJToolTip();
            ((System.ComponentModel.ISupportInitialize)(this.kkhSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kkhSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
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
            this.btnEnd.Location = new System.Drawing.Point(825, 5);
            this.btnEnd.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseDownImage")));
            this.btnEnd.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseLeaveImage")));
            this.btnEnd.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseMoveImage")));
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(37, 37);
            this.btnEnd.TabIndex = 7;
            this.btnEnd.TabStop = false;
            this.btnEnd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // kkhSpread1
            // 
            this.kkhSpread1.AccessibleDescription = "kkhSpread1, Sheet1, Row 0, Column 0, ";
            this.kkhSpread1.AllowUserFormulas = true;
            this.kkhSpread1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kkhSpread1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kkhSpread1.EnableCustomSorting = false;
            this.kkhSpread1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.kkhSpread1.Location = new System.Drawing.Point(5, 51);
            this.kkhSpread1.Name = "kkhSpread1";
            this.kkhSpread1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.kkhSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.kkhSpread1_Sheet1});
            this.kkhSpread1.Size = new System.Drawing.Size(857, 492);
            this.kkhSpread1.TabIndex = 8;
            this.kkhSpread1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.kkhSpread1.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.kkhSpread1_Change);
            // 
            // kkhSpread1_Sheet1
            // 
            this.kkhSpread1_Sheet1.Reset();
            this.kkhSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.kkhSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.kkhSpread1_Sheet1.ColumnCount = 13;
            this.kkhSpread1_Sheet1.RowCount = 10;
            this.kkhSpread1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.kkhSpread1_Sheet1.Cells.Get(0, 0).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kkhSpread1_Sheet1.Cells.Get(0, 0).Locked = true;
            this.kkhSpread1_Sheet1.Cells.Get(1, 0).Locked = true;
            this.kkhSpread1_Sheet1.Cells.Get(2, 0).Locked = true;
            this.kkhSpread1_Sheet1.Cells.Get(3, 0).Locked = true;
            this.kkhSpread1_Sheet1.Cells.Get(4, 0).Locked = true;
            this.kkhSpread1_Sheet1.Cells.Get(5, 0).Locked = true;
            this.kkhSpread1_Sheet1.Cells.Get(6, 0).Locked = true;
            this.kkhSpread1_Sheet1.Cells.Get(7, 0).Locked = true;
            this.kkhSpread1_Sheet1.Cells.Get(8, 0).Locked = true;
            this.kkhSpread1_Sheet1.Cells.Get(9, 0).Locked = true;
            this.kkhSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "スペース";
            this.kkhSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "選";
            this.kkhSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "実施料";
            this.kkhSpread1_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kkhSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.kkhSpread1_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kkhSpread1_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.kkhSpread1_Sheet1.Columns.Get(0).ForeColor = System.Drawing.SystemColors.ControlText;
            this.kkhSpread1_Sheet1.Columns.Get(0).Label = "スペース";
            this.kkhSpread1_Sheet1.Columns.Get(0).Locked = true;
            this.kkhSpread1_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.kkhSpread1_Sheet1.Columns.Get(0).Width = 130F;
            checkBoxCellType1.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.kkhSpread1_Sheet1.Columns.Get(1).CellType = checkBoxCellType1;
            this.kkhSpread1_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.kkhSpread1_Sheet1.Columns.Get(1).Label = "選";
            this.kkhSpread1_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.kkhSpread1_Sheet1.Columns.Get(1).Width = 31F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.FixedPoint = false;
            numberCellType1.MaximumValue = 9999999;
            numberCellType1.MinimumValue = -9999999;
            numberCellType1.Separator = ",";
            numberCellType1.ShowSeparator = true;
            numberCellType1.SpinDecimalIncrement = 1F;
            this.kkhSpread1_Sheet1.Columns.Get(2).CellType = numberCellType1;
            this.kkhSpread1_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.kkhSpread1_Sheet1.Columns.Get(2).Label = "実施料";
            this.kkhSpread1_Sheet1.Columns.Get(2).NoteIndicatorColor = System.Drawing.Color.Black;
            this.kkhSpread1_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.kkhSpread1_Sheet1.Columns.Get(2).Width = 173F;
            this.kkhSpread1_Sheet1.Columns.Get(3).Visible = false;
            this.kkhSpread1_Sheet1.Columns.Get(4).Visible = false;
            this.kkhSpread1_Sheet1.Columns.Get(5).Visible = false;
            this.kkhSpread1_Sheet1.Columns.Get(6).Visible = false;
            this.kkhSpread1_Sheet1.Columns.Get(7).Visible = false;
            this.kkhSpread1_Sheet1.Columns.Get(8).Visible = false;
            this.kkhSpread1_Sheet1.Columns.Get(9).Visible = false;
            this.kkhSpread1_Sheet1.Columns.Get(10).Visible = false;
            this.kkhSpread1_Sheet1.Columns.Get(11).Visible = false;
            this.kkhSpread1_Sheet1.Columns.Get(12).Visible = false;
            this.kkhSpread1_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.kkhSpread1_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.kkhSpread1_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kkhSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.kkhSpread1_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kkhSpread1_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.kkhSpread1_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.kkhSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // Help
            // 
            this.Help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Help.BackColor = System.Drawing.Color.Transparent;
            this.Help.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Help.FlatAppearance.BorderSize = 0;
            this.Help.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Help.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Help.Image = ((System.Drawing.Image)(resources.GetObject("Help.Image")));
            this.Help.Location = new System.Drawing.Point(782, 5);
            this.Help.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("Help.MouseDownImage")));
            this.Help.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("Help.MouseLeaveImage")));
            this.Help.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("Help.MouseMoveImage")));
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(37, 37);
            this.Help.TabIndex = 9;
            this.Help.TabStop = false;
            this.Help.UseVisualStyleBackColor = false;
            this.Help.Click += new System.EventHandler(this.btnHlp_Click);
            // 
            // UpDate
            // 
            this.UpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpDate.BackColor = System.Drawing.Color.Transparent;
            this.UpDate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.UpDate.FlatAppearance.BorderSize = 0;
            this.UpDate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.UpDate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.UpDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpDate.Image = ((System.Drawing.Image)(resources.GetObject("UpDate.Image")));
            this.UpDate.Location = new System.Drawing.Point(544, 15);
            this.UpDate.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("UpDate.MouseDownImage")));
            this.UpDate.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("UpDate.MouseLeaveImage")));
            this.UpDate.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("UpDate.MouseMoveImage")));
            this.UpDate.Name = "UpDate";
            this.UpDate.Size = new System.Drawing.Size(113, 22);
            this.UpDate.TabIndex = 10;
            this.UpDate.TabStop = false;
            this.UpDate.Text = "更新";
            this.UpDate.UseVisualStyleBackColor = false;
            this.UpDate.Click += new System.EventHandler(this.UpDate_Click);
            // 
            // Delete
            // 
            this.Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete.BackColor = System.Drawing.Color.Transparent;
            this.Delete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Delete.FlatAppearance.BorderSize = 0;
            this.Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Location = new System.Drawing.Point(663, 15);
            this.Delete.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("Delete.MouseDownImage")));
            this.Delete.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("Delete.MouseLeaveImage")));
            this.Delete.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("Delete.MouseMoveImage")));
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(113, 22);
            this.Delete.TabIndex = 11;
            this.Delete.TabStop = false;
            this.Delete.Text = "削除";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // S_Hyoji
            // 
            this.S_Hyoji.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.S_Hyoji.BackColor = System.Drawing.Color.Transparent;
            this.S_Hyoji.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.S_Hyoji.FlatAppearance.BorderSize = 0;
            this.S_Hyoji.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.S_Hyoji.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.S_Hyoji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.S_Hyoji.Image = ((System.Drawing.Image)(resources.GetObject("S_Hyoji.Image")));
            this.S_Hyoji.Location = new System.Drawing.Point(425, 15);
            this.S_Hyoji.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("S_Hyoji.MouseDownImage")));
            this.S_Hyoji.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("S_Hyoji.MouseLeaveImage")));
            this.S_Hyoji.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("S_Hyoji.MouseMoveImage")));
            this.S_Hyoji.Name = "S_Hyoji";
            this.S_Hyoji.Size = new System.Drawing.Size(113, 22);
            this.S_Hyoji.TabIndex = 12;
            this.S_Hyoji.TabStop = false;
            this.S_Hyoji.Text = "再表示";
            this.S_Hyoji.UseVisualStyleBackColor = false;
            this.S_Hyoji.Click += new System.EventHandler(this.S_Hyoji_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "得意先 ：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.CausesValidation = false;
            this.label2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "番組   ：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(90, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "ライオン （株）";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(90, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "@@@";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(127, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "：　AAA";
            // 
            // frmMastLionZashiRyoSpc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 568);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.S_Hyoji);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.UpDate);
            this.Controls.Add(this.kkhSpread1);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.Help);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMastLionZashiRyoSpc";
            this.Text = "系列局金額マスターメンテ";
            this.Load += new System.EventHandler(this.frmMastLionZashiRyoSpc_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.MastLionZashiRyoSpc_ProcessAfterNavigating);
            this.Controls.SetChildIndex(this.Help, 0);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.kkhSpread1, 0);
            this.Controls.SetChildIndex(this.UpDate, 0);
            this.Controls.SetChildIndex(this.Delete, 0);
            this.Controls.SetChildIndex(this.S_Hyoji, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            ((System.ComponentModel.ISupportInitialize)(this.kkhSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kkhSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread kkhSpread1;
        private FarPoint.Win.Spread.SheetView kkhSpread1_Sheet1;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton Help;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton UpDate;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton Delete;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton S_Hyoji;
        private Isid.NJ.View.Widget.NJLabel label1;
        private Isid.NJ.View.Widget.NJLabel label2;
        private Isid.NJ.View.Widget.NJLabel label3;
        private Isid.NJ.View.Widget.NJLabel label4;
        private Isid.NJ.View.Widget.NJLabel label5;
        private Isid.NJ.View.Widget.NJToolTip njToolTip1;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnEnd;

    }
}