namespace Isid.KKH.Lion.View.Report
{
    partial class ReportInvoicePlanLion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportInvoicePlanLion));
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.btnSrc = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnRetrun = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.sprMain = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.spsMain = new FarPoint.Win.Spread.SheetView();
            this.njToolTip1 = new Isid.NJ.View.Widget.NJToolTip();
            this.lblYM = new Isid.NJ.View.Widget.NJLabel();
            this.lblDiv = new Isid.NJ.View.Widget.NJLabel();
            this.txtYm = new Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl();
            this.cmbDiv = new Isid.NJ.View.Widget.NJComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.sprMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spsMain)).BeginInit();
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
            this.sprMain.AccessibleDescription = "sprMain, メイン";
            this.sprMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sprMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sprMain.EnableCustomSorting = false;
            this.sprMain.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sprMain.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.sprMain.Location = new System.Drawing.Point(8, 44);
            this.sprMain.Name = "sprMain";
            this.sprMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sprMain.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spsMain});
            this.sprMain.Size = new System.Drawing.Size(954, 597);
            this.sprMain.TabIndex = 21;
            this.sprMain.TabStripRatio = 0.913919413919414;
            this.sprMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // spsMain
            // 
            this.spsMain.Reset();
            this.spsMain.SheetName = "メイン";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spsMain.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spsMain.ColumnCount = 6;
            this.spsMain.RowCount = 0;
            this.spsMain.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.spsMain.ColumnHeader.Cells.Get(0, 0).Value = "ブランドコード";
            this.spsMain.ColumnHeader.Cells.Get(0, 1).Value = "ブランド名称";
            this.spsMain.ColumnHeader.Cells.Get(0, 2).Value = "項目";
            this.spsMain.ColumnHeader.Cells.Get(0, 3).Value = "請求金額";
            this.spsMain.ColumnHeader.Cells.Get(0, 4).Value = "媒体区分";
            this.spsMain.ColumnHeader.Cells.Get(0, 5).Value = "媒体名称";
            this.spsMain.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsMain.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsMain.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spsMain.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsMain.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsMain.ColumnHeader.Rows.Get(0).Height = 36F;
            this.spsMain.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsMain.Columns.Get(0).Label = "ブランドコード";
            this.spsMain.Columns.Get(0).Locked = true;
            this.spsMain.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsMain.Columns.Get(0).Width = 45F;
            this.spsMain.Columns.Get(1).Label = "ブランド名称";
            this.spsMain.Columns.Get(1).Locked = true;
            this.spsMain.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsMain.Columns.Get(1).Width = 100F;
            this.spsMain.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spsMain.Columns.Get(2).Label = "項目";
            this.spsMain.Columns.Get(2).Locked = true;
            this.spsMain.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsMain.Columns.Get(2).Width = 300F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.FixedPoint = false;
            numberCellType1.MaximumValue = 9999999999999;
            numberCellType1.MinimumValue = -9999999999999;
            numberCellType1.Separator = ",";
            numberCellType1.ShowSeparator = true;
            this.spsMain.Columns.Get(3).CellType = numberCellType1;
            this.spsMain.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spsMain.Columns.Get(3).Label = "請求金額";
            this.spsMain.Columns.Get(3).Locked = true;
            this.spsMain.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsMain.Columns.Get(3).Width = 100F;
            this.spsMain.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spsMain.Columns.Get(4).Label = "媒体区分";
            this.spsMain.Columns.Get(4).Locked = true;
            this.spsMain.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsMain.Columns.Get(4).Width = 40F;
            this.spsMain.Columns.Get(5).Label = "媒体名称";
            this.spsMain.Columns.Get(5).Locked = true;
            this.spsMain.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spsMain.Columns.Get(5).Width = 100F;
            this.spsMain.RowHeader.Columns.Default.Resizable = true;
            this.spsMain.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsMain.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsMain.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spsMain.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsMain.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsMain.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spsMain.SheetCornerStyle.Parent = "CornerDefault";
            this.spsMain.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spsMain.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.sprMain.SetActiveViewport(0, 1, 0);
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
            // lblDiv
            // 
            this.lblDiv.AutoSize = true;
            this.lblDiv.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiv.Location = new System.Drawing.Point(161, 16);
            this.lblDiv.Name = "lblDiv";
            this.lblDiv.Size = new System.Drawing.Size(41, 12);
            this.lblDiv.TabIndex = 25;
            this.lblDiv.Text = "事業部";
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
            // cmbDiv
            // 
            this.cmbDiv.BackColor = System.Drawing.SystemColors.Window;
            this.cmbDiv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiv.FormattingEnabled = true;
            this.cmbDiv.Location = new System.Drawing.Point(229, 12);
            this.cmbDiv.Name = "cmbDiv";
            this.cmbDiv.Size = new System.Drawing.Size(176, 20);
            this.cmbDiv.TabIndex = 41;
            this.cmbDiv.SelectedIndexChanged += new System.EventHandler(this.cmbDiv_SelectedIndexChanged);
            // 
            // ReportInvoicePlanLion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 666);
            this.Controls.Add(this.cmbDiv);
            this.Controls.Add(this.txtYm);
            this.Controls.Add(this.lblYM);
            this.Controls.Add(this.lblDiv);
            this.Controls.Add(this.sprMain);
            this.Controls.Add(this.btnSrc);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.btnRetrun);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 300);
            this.Name = "ReportInvoicePlanLion";
            this.Text = "制作費請求予定表";
            this.Shown += new System.EventHandler(this.ReportAddChgLion_Shown);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.ReportAddChgLion_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.btnRetrun, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.btnSrc, 0);
            this.Controls.SetChildIndex(this.sprMain, 0);
            this.Controls.SetChildIndex(this.lblDiv, 0);
            this.Controls.SetChildIndex(this.lblYM, 0);
            this.Controls.SetChildIndex(this.txtYm, 0);
            this.Controls.SetChildIndex(this.cmbDiv, 0);
            ((System.ComponentModel.ISupportInitialize)(this.sprMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spsMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread sprMain;
        private FarPoint.Win.Spread.SheetView spsMain;
        private Isid.NJ.View.Widget.NJToolTip njToolTip1;
        private Isid.NJ.View.Widget.NJLabel lblYM;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnSrc;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHlp;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnRetrun;
        private Isid.NJ.View.Widget.NJLabel lblDiv;
        protected Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl txtYm;
        protected Isid.NJ.View.Widget.NJComboBox cmbDiv;


    }
}