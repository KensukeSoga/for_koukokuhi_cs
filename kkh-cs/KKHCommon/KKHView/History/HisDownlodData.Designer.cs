namespace Isid.KKH.Common.KKHView.History
{
    partial class HisDownlodData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HisDownlodData));
            this.btnSrc = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.hisMain = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.hisMain_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.bs_Report = new System.Windows.Forms.BindingSource(this.components);
            this.ds = new Isid.KKH.Common.KKHSchema.HisDs();
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnRtn = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.njToolTip1 = new Isid.NJ.View.Widget.NJToolTip();
            this.lblYyyyMm = new Isid.NJ.View.Widget.NJLabel();
            this.orgYyyyMm = new Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl();
            ((System.ComponentModel.ISupportInitialize)(this.hisMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hisMain_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_Report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
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
            this.btnSrc.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSrc.Image = ((System.Drawing.Image)(resources.GetObject("btnSrc.Image")));
            this.btnSrc.Location = new System.Drawing.Point(136, 8);
            this.btnSrc.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseDownImage")));
            this.btnSrc.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseLeaveImage")));
            this.btnSrc.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseMoveImage")));
            this.btnSrc.Name = "btnSrc";
            this.btnSrc.Size = new System.Drawing.Size(113, 22);
            this.btnSrc.TabIndex = 6;
            this.btnSrc.TabStop = false;
            this.btnSrc.Text = "検索";
            this.btnSrc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnSrc, "指定した年月のデータを検索します");
            this.btnSrc.UseVisualStyleBackColor = false;
            this.btnSrc.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnSrc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnSrc.Click += new System.EventHandler(this.btnSrc_Click);
            // 
            // hisMain
            // 
            this.hisMain.AccessibleDescription = "hisMain, Sheet1, Row 0, Column 0, ";
            this.hisMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hisMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.hisMain.EnableCustomSorting = false;
            this.hisMain.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.hisMain.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.hisMain.Location = new System.Drawing.Point(5, 44);
            this.hisMain.Name = "hisMain";
            this.hisMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.hisMain.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.hisMain_Sheet1});
            this.hisMain.Size = new System.Drawing.Size(798, 480);
            this.hisMain.TabIndex = 29;
            this.hisMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // hisMain_Sheet1
            // 
            this.hisMain_Sheet1.Reset();
            this.hisMain_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.hisMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.hisMain_Sheet1.ColumnCount = 6;
            this.hisMain_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.hisMain_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "原票出力日時";
            this.hisMain_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "出力区分";
            this.hisMain_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "請求年月";
            this.hisMain_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "業務区分名称";
            this.hisMain_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "担当者コード";
            this.hisMain_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "担当者名称";
            this.hisMain_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.hisMain_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.hisMain_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.hisMain_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.hisMain_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.hisMain_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.hisMain_Sheet1.Columns.Get(0).DataField = "GpsyuTimStmp";
            this.hisMain_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.hisMain_Sheet1.Columns.Get(0).Label = "原票出力日時";
            this.hisMain_Sheet1.Columns.Get(0).Locked = true;
            this.hisMain_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.hisMain_Sheet1.Columns.Get(0).Width = 139F;
            this.hisMain_Sheet1.Columns.Get(1).DataField = "SyuKbn";
            this.hisMain_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.hisMain_Sheet1.Columns.Get(1).Label = "出力区分";
            this.hisMain_Sheet1.Columns.Get(1).Locked = true;
            this.hisMain_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.hisMain_Sheet1.Columns.Get(1).Width = 100F;
            this.hisMain_Sheet1.Columns.Get(2).DataField = "Yymm";
            this.hisMain_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.hisMain_Sheet1.Columns.Get(2).Label = "請求年月";
            this.hisMain_Sheet1.Columns.Get(2).Locked = true;
            this.hisMain_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.hisMain_Sheet1.Columns.Get(2).Width = 100F;
            this.hisMain_Sheet1.Columns.Get(3).DataField = "GyomKbn";
            this.hisMain_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.hisMain_Sheet1.Columns.Get(3).Label = "業務区分名称";
            this.hisMain_Sheet1.Columns.Get(3).Locked = true;
            this.hisMain_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.hisMain_Sheet1.Columns.Get(3).Width = 199F;
            this.hisMain_Sheet1.Columns.Get(4).DataField = "TntCd";
            this.hisMain_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.hisMain_Sheet1.Columns.Get(4).Label = "担当者コード";
            this.hisMain_Sheet1.Columns.Get(4).Locked = true;
            this.hisMain_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.hisMain_Sheet1.Columns.Get(4).Width = 50F;
            this.hisMain_Sheet1.Columns.Get(5).DataField = "TntNm";
            this.hisMain_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.hisMain_Sheet1.Columns.Get(5).Label = "担当者名称";
            this.hisMain_Sheet1.Columns.Get(5).Locked = true;
            this.hisMain_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.hisMain_Sheet1.Columns.Get(5).Width = 150F;
            this.hisMain_Sheet1.DataAutoCellTypes = false;
            this.hisMain_Sheet1.DataAutoHeadings = false;
            this.hisMain_Sheet1.DataAutoSizeColumns = false;
            this.hisMain_Sheet1.DataSource = this.bs_Report;
            this.hisMain_Sheet1.FrozenColumnCount = 3;
            this.hisMain_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.hisMain_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.hisMain_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.hisMain_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.hisMain_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.hisMain_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.hisMain_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.hisMain_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.hisMain_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.hisMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.hisMain.SetViewportLeftColumn(0, 0, 3);
            this.hisMain.SetActiveViewport(0, 1, -1);
            // 
            // bs_Report
            // 
            this.bs_Report.DataMember = "jyutyuDownLoad";
            this.bs_Report.DataSource = this.ds;
            // 
            // ds
            // 
            this.ds.DataSetName = "HisDs";
            this.ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.btnHlp.Location = new System.Drawing.Point(726, 1);
            this.btnHlp.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseDownImage")));
            this.btnHlp.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseLeaveImage")));
            this.btnHlp.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseMoveImage")));
            this.btnHlp.Name = "btnHlp";
            this.btnHlp.Size = new System.Drawing.Size(37, 37);
            this.btnHlp.TabIndex = 9;
            this.btnHlp.TabStop = false;
            this.btnHlp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnHlp, "ヘルプを表示します");
            this.btnHlp.UseVisualStyleBackColor = false;
            this.btnHlp.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnHlp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnHlp.Click += new System.EventHandler(this.btnHlp_Click);
            // 
            // btnRtn
            // 
            this.btnRtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRtn.BackColor = System.Drawing.Color.Transparent;
            this.btnRtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRtn.FlatAppearance.BorderSize = 0;
            this.btnRtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRtn.Image = ((System.Drawing.Image)(resources.GetObject("btnRtn.Image")));
            this.btnRtn.Location = new System.Drawing.Point(769, 1);
            this.btnRtn.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnRtn.MouseDownImage")));
            this.btnRtn.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnRtn.MouseLeaveImage")));
            this.btnRtn.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnRtn.MouseMoveImage")));
            this.btnRtn.Name = "btnRtn";
            this.btnRtn.Size = new System.Drawing.Size(37, 37);
            this.btnRtn.TabIndex = 10;
            this.btnRtn.TabStop = false;
            this.btnRtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnRtn, "メニューに戻ります");
            this.btnRtn.UseVisualStyleBackColor = false;
            this.btnRtn.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnRtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnRtn.Click += new System.EventHandler(this.btnRtn_Click);
            // 
            // lblYyyyMm
            // 
            this.lblYyyyMm.AutoSize = true;
            this.lblYyyyMm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblYyyyMm.Location = new System.Drawing.Point(3, 14);
            this.lblYyyyMm.Name = "lblYyyyMm";
            this.lblYyyyMm.Size = new System.Drawing.Size(29, 12);
            this.lblYyyyMm.TabIndex = 31;
            this.lblYyyyMm.Text = "年月";
            // 
            // orgYyyyMm
            // 
            this.orgYyyyMm.DisplayMode = Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.DisplayMode.COMBO;
            this.orgYyyyMm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.orgYyyyMm.Location = new System.Drawing.Point(38, 9);
            this.orgYyyyMm.MinimumSize = new System.Drawing.Size(82, 21);
            this.orgYyyyMm.Name = "orgYyyyMm";
            this.orgYyyyMm.Size = new System.Drawing.Size(82, 21);
            this.orgYyyyMm.TabIndex = 32;
            this.orgYyyyMm.ValidateDisableOnce = false;
            // 
            // HisDownlodData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 549);
            this.Controls.Add(this.orgYyyyMm);
            this.Controls.Add(this.lblYyyyMm);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.btnRtn);
            this.Controls.Add(this.hisMain);
            this.Controls.Add(this.btnSrc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 300);
            this.Name = "HisDownlodData";
            this.Text = "請求原票取込履歴";
            this.Load += new System.EventHandler(this.HisDownlodData_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.HisDownlodData_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.btnSrc, 0);
            this.Controls.SetChildIndex(this.hisMain, 0);
            this.Controls.SetChildIndex(this.btnRtn, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.lblYyyyMm, 0);
            this.Controls.SetChildIndex(this.orgYyyyMm, 0);
            ((System.ComponentModel.ISupportInitialize)(this.hisMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hisMain_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_Report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnSrc;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread hisMain;
        private FarPoint.Win.Spread.SheetView hisMain_Sheet1;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHlp;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnRtn;
        private Isid.NJ.View.Widget.NJToolTip njToolTip1;
        private Isid.NJ.View.Widget.NJLabel lblYyyyMm;
        protected Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl orgYyyyMm;
        private Isid.KKH.Common.KKHSchema.HisDs ds;
        private System.Windows.Forms.BindingSource bs_Report;
 
    }
}
