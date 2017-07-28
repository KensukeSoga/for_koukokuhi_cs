namespace Isid.KKH.Main.View.Login
{
    partial class LoginCustomerSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginCustomerSelect));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.btnOK = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this._spdLoginCustomerList = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this._spdLoginCustomerList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.lblMsg = new Isid.NJ.View.Widget.NJLabel();
            ((System.ComponentModel.ISupportInitialize)(this._spdLoginCustomerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdLoginCustomerList_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(856, 423);
            this.btnOK.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseDownImage")));
            this.btnOK.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseLeaveImage")));
            this.btnOK.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseMoveImage")));
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 22);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // _spdLoginCustomerList
            // 
            this._spdLoginCustomerList.AccessibleDescription = "_spdLoginCustomerList, Sheet1, Row 0, Column 0, ";
            this._spdLoginCustomerList.BackColor = System.Drawing.Color.Transparent;
            this._spdLoginCustomerList.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this._spdLoginCustomerList.EnableCustomSorting = false;
            this._spdLoginCustomerList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._spdLoginCustomerList.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this._spdLoginCustomerList.Location = new System.Drawing.Point(5, 44);
            this._spdLoginCustomerList.Name = "_spdLoginCustomerList";
            this._spdLoginCustomerList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._spdLoginCustomerList.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this._spdLoginCustomerList.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows;
            this._spdLoginCustomerList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this._spdLoginCustomerList_Sheet1});
            this._spdLoginCustomerList.Size = new System.Drawing.Size(964, 367);
            this._spdLoginCustomerList.TabIndex = 5;
            this._spdLoginCustomerList.TabStripRatio = 0.498117942283563;
            this._spdLoginCustomerList.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // _spdLoginCustomerList_Sheet1
            // 
            this._spdLoginCustomerList_Sheet1.Reset();
            this._spdLoginCustomerList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this._spdLoginCustomerList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this._spdLoginCustomerList_Sheet1.ColumnCount = 6;
            this._spdLoginCustomerList_Sheet1.ColumnHeader.RowCount = 2;
            this._spdLoginCustomerList_Sheet1.RowCount = 0;
            this._spdLoginCustomerList_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this._spdLoginCustomerList_Sheet1.ColumnHeader.AutoFilterIndex = 1;
            this._spdLoginCustomerList_Sheet1.ColumnHeader.AutoSortIndex = 1;
            this._spdLoginCustomerList_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this._spdLoginCustomerList_Sheet1.ColumnHeader.AutoTextIndex = 0;
            this._spdLoginCustomerList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "得意先企業コード";
            this._spdLoginCustomerList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "得意先部門SEQNO";
            this._spdLoginCustomerList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "得意先担当SEQNO";
            this._spdLoginCustomerList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "得意先コード";
            this._spdLoginCustomerList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "得意先名";
            this._spdLoginCustomerList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "担当組織";
            this._spdLoginCustomerList_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdLoginCustomerList_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdLoginCustomerList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this._spdLoginCustomerList_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdLoginCustomerList_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdLoginCustomerList_Sheet1.Columns.Get(0).AllowAutoFilter = true;
            this._spdLoginCustomerList_Sheet1.Columns.Get(0).AllowAutoSort = true;
            this._spdLoginCustomerList_Sheet1.Columns.Get(0).DataField = "uriMeiNo";
            this._spdLoginCustomerList_Sheet1.Columns.Get(0).Label = "得意先企業コード";
            this._spdLoginCustomerList_Sheet1.Columns.Get(0).Width = 150F;
            this._spdLoginCustomerList_Sheet1.Columns.Get(1).AllowAutoFilter = true;
            this._spdLoginCustomerList_Sheet1.Columns.Get(1).AllowAutoSort = true;
            this._spdLoginCustomerList_Sheet1.Columns.Get(1).DataField = "uriMeiNo";
            this._spdLoginCustomerList_Sheet1.Columns.Get(1).Label = "得意先部門SEQNO";
            this._spdLoginCustomerList_Sheet1.Columns.Get(1).Width = 150F;
            this._spdLoginCustomerList_Sheet1.Columns.Get(2).AllowAutoFilter = true;
            this._spdLoginCustomerList_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this._spdLoginCustomerList_Sheet1.Columns.Get(2).DataField = "uriMeiNo";
            this._spdLoginCustomerList_Sheet1.Columns.Get(2).Label = "得意先担当SEQNO";
            this._spdLoginCustomerList_Sheet1.Columns.Get(2).Width = 150F;
            this._spdLoginCustomerList_Sheet1.Columns.Get(3).AllowAutoFilter = true;
            this._spdLoginCustomerList_Sheet1.Columns.Get(3).AllowAutoSort = true;
            this._spdLoginCustomerList_Sheet1.Columns.Get(3).CellType = textCellType1;
            this._spdLoginCustomerList_Sheet1.Columns.Get(3).DataField = "uriMeiNo";
            this._spdLoginCustomerList_Sheet1.Columns.Get(3).Label = "得意先コード";
            this._spdLoginCustomerList_Sheet1.Columns.Get(3).Locked = true;
            this._spdLoginCustomerList_Sheet1.Columns.Get(3).Width = 150F;
            this._spdLoginCustomerList_Sheet1.Columns.Get(4).AllowAutoFilter = true;
            this._spdLoginCustomerList_Sheet1.Columns.Get(4).AllowAutoSort = true;
            this._spdLoginCustomerList_Sheet1.Columns.Get(4).CellType = textCellType2;
            this._spdLoginCustomerList_Sheet1.Columns.Get(4).DataField = "kenmei";
            this._spdLoginCustomerList_Sheet1.Columns.Get(4).Label = "得意先名";
            this._spdLoginCustomerList_Sheet1.Columns.Get(4).Locked = true;
            this._spdLoginCustomerList_Sheet1.Columns.Get(4).Width = 350F;
            this._spdLoginCustomerList_Sheet1.Columns.Get(5).AllowAutoFilter = true;
            this._spdLoginCustomerList_Sheet1.Columns.Get(5).AllowAutoSort = true;
            this._spdLoginCustomerList_Sheet1.Columns.Get(5).CellType = textCellType3;
            this._spdLoginCustomerList_Sheet1.Columns.Get(5).DataField = "baitaiNm";
            this._spdLoginCustomerList_Sheet1.Columns.Get(5).Label = "担当組織";
            this._spdLoginCustomerList_Sheet1.Columns.Get(5).Locked = true;
            this._spdLoginCustomerList_Sheet1.Columns.Get(5).Width = 150F;
            this._spdLoginCustomerList_Sheet1.DataAutoCellTypes = false;
            this._spdLoginCustomerList_Sheet1.DataAutoHeadings = false;
            this._spdLoginCustomerList_Sheet1.DataAutoSizeColumns = false;
            this._spdLoginCustomerList_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdLoginCustomerList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ExtendedSelect;
            this._spdLoginCustomerList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this._spdLoginCustomerList_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdLoginCustomerList_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdLoginCustomerList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this._spdLoginCustomerList_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdLoginCustomerList_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdLoginCustomerList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this._spdLoginCustomerList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this._spdLoginCustomerList_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdLoginCustomerList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this._spdLoginCustomerList_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdLoginCustomerList.SetActiveViewport(0, 1, 0);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMsg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMsg.Location = new System.Drawing.Point(3, 9);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(332, 32);
            this.lblMsg.TabIndex = 7;
            this.lblMsg.Text = "入力した得意先コードに、下記が該当しました。\r\nいずれかを選択してください。";
            // 
            // LoginCustomerSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(974, 457);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this._spdLoginCustomerList);
            this.Controls.Add(this.btnOK);
            this.EnterKeyFocusEnabled = true;
            this.Name = "LoginCustomerSelect";
            this.Text = "得意先選択";
            this.Load += new System.EventHandler(this.LoginCustomerSelect_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.LoginCustomerSelect_ProcessAffterNavigating);
            ((System.ComponentModel.ISupportInitialize)(this._spdLoginCustomerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdLoginCustomerList_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnOK;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread _spdLoginCustomerList;
        private FarPoint.Win.Spread.SheetView _spdLoginCustomerList_Sheet1;
        private Isid.NJ.View.Widget.NJLabel lblMsg;

    }
}