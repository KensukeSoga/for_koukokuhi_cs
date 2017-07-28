namespace Isid.KKH.Epson.View.Report
{
    partial class ReportEpsonSeikyuPlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportEpsonSeikyuPlan));
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.txtYm = new Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl();
            this.btnSrc = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnXls = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnEnd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.njLabel1 = new Isid.NJ.View.Widget.NJLabel();
            this.njToolTip1 = new Isid.NJ.View.Widget.NJToolTip();
            this.spdReport = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this._spdReport_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this._bsReport = new System.Windows.Forms.BindingSource(this.components);
            this._dsReport = new Isid.KKH.Epson.Schema.RepDsEpson();
            ((System.ComponentModel.ISupportInitialize)(this.spdReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdReport_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dsReport)).BeginInit();
            this.SuspendLayout();
            // 
            // txtYm
            // 
            this.txtYm.DisplayMode = Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.DisplayMode.COMBO;
            this.txtYm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYm.Location = new System.Drawing.Point(47, 11);
            this.txtYm.MinimumSize = new System.Drawing.Size(82, 21);
            this.txtYm.Name = "txtYm";
            this.txtYm.Size = new System.Drawing.Size(82, 21);
            this.txtYm.TabIndex = 1;
            this.txtYm.ValidateDisableOnce = false;
            this.txtYm.Enter += new System.EventHandler(this.txtYm_Enter);
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
            this.btnSrc.Location = new System.Drawing.Point(135, 10);
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
            this.btnSrc.MouseLeave += new System.EventHandler(this.btnSrc_MouseLeave);
            this.btnSrc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSrc_MouseMove);
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
            this.btnXls.Location = new System.Drawing.Point(254, 10);
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
            this.btnXls.MouseLeave += new System.EventHandler(this.btnSrc_MouseLeave);
            this.btnXls.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSrc_MouseMove);
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
            this.btnHlp.Location = new System.Drawing.Point(884, 6);
            this.btnHlp.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseDownImage")));
            this.btnHlp.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseLeaveImage")));
            this.btnHlp.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseMoveImage")));
            this.btnHlp.Name = "btnHlp";
            this.btnHlp.Size = new System.Drawing.Size(37, 37);
            this.btnHlp.TabIndex = 4;
            this.btnHlp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnHlp, "ヘルプを表示します");
            this.btnHlp.UseVisualStyleBackColor = false;
            this.btnHlp.MouseLeave += new System.EventHandler(this.btnSrc_MouseLeave);
            this.btnHlp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSrc_MouseMove);
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
            this.btnEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEnd.Image")));
            this.btnEnd.Location = new System.Drawing.Point(927, 6);
            this.btnEnd.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseDownImage")));
            this.btnEnd.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseLeaveImage")));
            this.btnEnd.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseMoveImage")));
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(37, 37);
            this.btnEnd.TabIndex = 5;
            this.btnEnd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnEnd, "帳票出力を終わってメニューに戻ります");
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.MouseLeave += new System.EventHandler(this.btnSrc_MouseLeave);
            this.btnEnd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSrc_MouseMove);
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // njLabel1
            // 
            this.njLabel1.AutoSize = true;
            this.njLabel1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.njLabel1.Location = new System.Drawing.Point(12, 15);
            this.njLabel1.Name = "njLabel1";
            this.njLabel1.Size = new System.Drawing.Size(29, 12);
            this.njLabel1.TabIndex = 0;
            this.njLabel1.Text = "年月";
            // 
            // spdReport
            // 
            this.spdReport.AccessibleDescription = "spdReport, Sheet1";
            this.spdReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spdReport.BackColor = System.Drawing.SystemColors.Control;
            this.spdReport.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.spdReport.EditModeReplace = true;
            this.spdReport.EnableCustomSorting = false;
            this.spdReport.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdReport.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdReport.Location = new System.Drawing.Point(6, 49);
            this.spdReport.Name = "spdReport";
            this.spdReport.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdReport.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.spdReport.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this._spdReport_Sheet1});
            this.spdReport.Size = new System.Drawing.Size(958, 592);
            this.spdReport.TabIndex = 11;
            this.spdReport.TabStop = false;
            this.spdReport.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // _spdReport_Sheet1
            // 
            this._spdReport_Sheet1.Reset();
            this._spdReport_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this._spdReport_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this._spdReport_Sheet1.ColumnCount = 6;
            this._spdReport_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this._spdReport_Sheet1.ColumnHeader.AutoTextIndex = 0;
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "広告件名";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "ご担当";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "件名";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "取引識別コード";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "事前";
            this._spdReport_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "事後";
            this._spdReport_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdReport_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdReport_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this._spdReport_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdReport_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdReport_Sheet1.Columns.Get(0).DataField = "name8";
            this._spdReport_Sheet1.Columns.Get(0).Label = "広告件名";
            this._spdReport_Sheet1.Columns.Get(0).Locked = true;
            this._spdReport_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(0).Width = 222F;
            this._spdReport_Sheet1.Columns.Get(1).DataField = "name3";
            this._spdReport_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(1).Label = "ご担当";
            this._spdReport_Sheet1.Columns.Get(1).Locked = true;
            this._spdReport_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(1).Width = 91F;
            this._spdReport_Sheet1.Columns.Get(2).DataField = "name10";
            this._spdReport_Sheet1.Columns.Get(2).Label = "件名";
            this._spdReport_Sheet1.Columns.Get(2).Locked = true;
            this._spdReport_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(2).Width = 225F;
            this._spdReport_Sheet1.Columns.Get(3).DataField = "code4";
            this._spdReport_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this._spdReport_Sheet1.Columns.Get(3).Label = "取引識別コード";
            this._spdReport_Sheet1.Columns.Get(3).Locked = true;
            this._spdReport_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(3).Width = 112F;
            numberCellType3.DecimalPlaces = 0;
            numberCellType3.FixedPoint = false;
            numberCellType3.MaximumValue = 99999999999999;
            numberCellType3.Separator = ",";
            numberCellType3.ShowSeparator = true;
            this._spdReport_Sheet1.Columns.Get(4).CellType = numberCellType3;
            this._spdReport_Sheet1.Columns.Get(4).DataField = "kngk2";
            this._spdReport_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this._spdReport_Sheet1.Columns.Get(4).Label = "事前";
            this._spdReport_Sheet1.Columns.Get(4).Locked = true;
            this._spdReport_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(4).Width = 113F;
            numberCellType4.DecimalPlaces = 0;
            numberCellType4.FixedPoint = false;
            numberCellType4.MaximumValue = 99999999999999;
            numberCellType4.Separator = ",";
            numberCellType4.ShowSeparator = true;
            this._spdReport_Sheet1.Columns.Get(5).CellType = numberCellType4;
            this._spdReport_Sheet1.Columns.Get(5).DataField = "seigak";
            this._spdReport_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this._spdReport_Sheet1.Columns.Get(5).Label = "事後";
            this._spdReport_Sheet1.Columns.Get(5).Locked = true;
            this._spdReport_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdReport_Sheet1.Columns.Get(5).Width = 113F;
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
            this._bsReport.DataMember = "ReportSeikyuPlan";
            this._bsReport.DataSource = this._dsReport;
            // 
            // _dsReport
            // 
            this._dsReport.DataSetName = "RepDsEpson";
            this._dsReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReportEpsonSeikyuPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(972, 666);
            this.Controls.Add(this.spdReport);
            this.Controls.Add(this.njLabel1);
            this.Controls.Add(this.btnSrc);
            this.Controls.Add(this.btnXls);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.txtYm);
            this.MinimumSize = new System.Drawing.Size(900, 300);
            this.Name = "ReportEpsonSeikyuPlan";
            this.Text = "請求予定一覧出力";
            this.Load += new System.EventHandler(this.ReportEpsonSeikyuPlan_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.ReportEpsonSeikyuPlan_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.txtYm, 0);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.btnXls, 0);
            this.Controls.SetChildIndex(this.btnSrc, 0);
            this.Controls.SetChildIndex(this.njLabel1, 0);
            this.Controls.SetChildIndex(this.spdReport, 0);
            ((System.ComponentModel.ISupportInitialize)(this.spdReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdReport_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dsReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl txtYm;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnSrc;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnXls;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHlp;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnEnd;
        private Isid.NJ.View.Widget.NJLabel njLabel1;
        private Isid.NJ.View.Widget.NJToolTip njToolTip1;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread spdReport;
        private FarPoint.Win.Spread.SheetView _spdReport_Sheet1;
        private System.Windows.Forms.BindingSource _bsReport;
        private Isid.KKH.Epson.Schema.RepDsEpson _dsReport;
    }
}
