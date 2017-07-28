namespace Isid.KKH.Lion.View.History
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
            this.label1 = new Isid.NJ.View.Widget.NJLabel();
            this.njLabel1 = new Isid.NJ.View.Widget.NJLabel();
            this.btnSrc = new Isid.NJ.View.Widget.NJButton();
            this.txtYyyy = new Isid.NJ.View.Widget.NJNumericUpDown();
            this.txtMm = new Isid.NJ.View.Widget.NJNumericUpDown();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.hisMain = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.hisMain_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.njButton1 = new Isid.NJ.View.Widget.NJButton();
            this.njButton2 = new Isid.NJ.View.Widget.NJButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtYyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hisMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hisMain_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "年";
            // 
            // njLabel1
            // 
            this.njLabel1.AutoSize = true;
            this.njLabel1.Location = new System.Drawing.Point(156, 31);
            this.njLabel1.Name = "njLabel1";
            this.njLabel1.Size = new System.Drawing.Size(17, 12);
            this.njLabel1.TabIndex = 12;
            this.njLabel1.Text = "月";
            // 
            // btnSrc
            // 
            this.btnSrc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSrc.Location = new System.Drawing.Point(179, 12);
            this.btnSrc.Name = "btnSrc";
            this.btnSrc.Size = new System.Drawing.Size(68, 56);
            this.btnSrc.TabIndex = 6;
            this.btnSrc.Text = "表示";
            this.btnSrc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSrc.UseVisualStyleBackColor = true;
            this.btnSrc.Click += new System.EventHandler(this.btnSrc_Click);
            // 
            // txtYyyy
            // 
            this.txtYyyy.Location = new System.Drawing.Point(22, 25);
            this.txtYyyy.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtYyyy.Minimum = new decimal(new int[] {
            1950,
            0,
            0,
            0});
            this.txtYyyy.Name = "txtYyyy";
            this.txtYyyy.Size = new System.Drawing.Size(62, 21);
            this.txtYyyy.TabIndex = 0;
            this.txtYyyy.Value = new decimal(new int[] {
            1950,
            0,
            0,
            0});
            // 
            // txtMm
            // 
            this.txtMm.Location = new System.Drawing.Point(112, 25);
            this.txtMm.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txtMm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtMm.Name = "txtMm";
            this.txtMm.Size = new System.Drawing.Size(41, 21);
            this.txtMm.TabIndex = 1;
            this.txtMm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.TableName = "Table1";
            // 
            // hisMain
            // 
            this.hisMain.AccessibleDescription = "hisMain, Sheet1, Row 0, Column 0, ";
            this.hisMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hisMain.BackColor = System.Drawing.SystemColors.Control;
            this.hisMain.Location = new System.Drawing.Point(12, 77);
            this.hisMain.Name = "hisMain";
            this.hisMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.hisMain.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.hisMain_Sheet1});
            this.hisMain.Size = new System.Drawing.Size(864, 436);
            this.hisMain.TabIndex = 29;
            this.hisMain.UseExcelDump = false;
            // 
            // hisMain_Sheet1
            // 
            this.hisMain_Sheet1.Reset();
            this.hisMain_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.hisMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.hisMain_Sheet1.ColumnCount = 6;
            this.hisMain_Sheet1.RowCount = 0;
            this.hisMain_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "原票出力日時";
            this.hisMain_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "出力区分";
            this.hisMain_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "請求年月";
            this.hisMain_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "業務区分名称";
            this.hisMain_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "担当者コード";
            this.hisMain_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "担当者名称";
            this.hisMain_Sheet1.ColumnHeader.Rows.Get(0).Height = 26F;
            this.hisMain_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.hisMain_Sheet1.Columns.Get(0).Label = "原票出力日時";
            this.hisMain_Sheet1.Columns.Get(0).Locked = true;
            this.hisMain_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.hisMain_Sheet1.Columns.Get(0).Width = 139F;
            this.hisMain_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.hisMain_Sheet1.Columns.Get(1).Label = "出力区分";
            this.hisMain_Sheet1.Columns.Get(1).Locked = true;
            this.hisMain_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.hisMain_Sheet1.Columns.Get(1).Width = 100F;
            this.hisMain_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.hisMain_Sheet1.Columns.Get(2).Label = "請求年月";
            this.hisMain_Sheet1.Columns.Get(2).Locked = true;
            this.hisMain_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.hisMain_Sheet1.Columns.Get(2).Width = 100F;
            this.hisMain_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.hisMain_Sheet1.Columns.Get(3).Label = "業務区分名称";
            this.hisMain_Sheet1.Columns.Get(3).Locked = true;
            this.hisMain_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.hisMain_Sheet1.Columns.Get(3).Width = 199F;
            this.hisMain_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.hisMain_Sheet1.Columns.Get(4).Label = "担当者コード";
            this.hisMain_Sheet1.Columns.Get(4).Locked = true;
            this.hisMain_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.hisMain_Sheet1.Columns.Get(4).Width = 50F;
            this.hisMain_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.hisMain_Sheet1.Columns.Get(5).Label = "担当者名称";
            this.hisMain_Sheet1.Columns.Get(5).Locked = true;
            this.hisMain_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.hisMain_Sheet1.Columns.Get(5).Width = 164F;
            this.hisMain_Sheet1.DataAutoCellTypes = false;
            this.hisMain_Sheet1.DataAutoHeadings = false;
            this.hisMain_Sheet1.DataAutoSizeColumns = false;
            this.hisMain_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.hisMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.hisMain.SetActiveViewport(0, 1, 0);
            // 
            // njButton1
            // 
            this.njButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.njButton1.Location = new System.Drawing.Point(733, 15);
            this.njButton1.Name = "njButton1";
            this.njButton1.Size = new System.Drawing.Size(68, 56);
            this.njButton1.TabIndex = 9;
            this.njButton1.Text = "ヘルプ";
            this.njButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njButton1.UseVisualStyleBackColor = true;
            // 
            // njButton2
            // 
            this.njButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.njButton2.Location = new System.Drawing.Point(806, 15);
            this.njButton2.Name = "njButton2";
            this.njButton2.Size = new System.Drawing.Size(68, 56);
            this.njButton2.TabIndex = 10;
            this.njButton2.Text = "戻る";
            this.njButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njButton2.UseVisualStyleBackColor = true;
            this.njButton2.Click += new System.EventHandler(this.njButton2_Click);
            // 
            // HisDownlodData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 549);
            this.Controls.Add(this.njButton1);
            this.Controls.Add(this.njButton2);
            this.Controls.Add(this.hisMain);
            this.Controls.Add(this.txtMm);
            this.Controls.Add(this.txtYyyy);
            this.Controls.Add(this.btnSrc);
            this.Controls.Add(this.njLabel1);
            this.Controls.Add(this.label1);
            this.Name = "HisDownlodData";
            this.Text = "請求原票取込履歴";
            this.Load += new System.EventHandler(this.HisDownlodData_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.HisDownlodData_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.njLabel1, 0);
            this.Controls.SetChildIndex(this.btnSrc, 0);
            this.Controls.SetChildIndex(this.txtYyyy, 0);
            this.Controls.SetChildIndex(this.txtMm, 0);
            this.Controls.SetChildIndex(this.hisMain, 0);
            this.Controls.SetChildIndex(this.njButton2, 0);
            this.Controls.SetChildIndex(this.njButton1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtYyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hisMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hisMain_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Isid.NJ.View.Widget.NJLabel label1;
        protected Isid.NJ.View.Widget.NJLabel njLabel1;
        protected Isid.NJ.View.Widget.NJButton btnSrc;
        private Isid.NJ.View.Widget.NJNumericUpDown txtYyyy;
        private Isid.NJ.View.Widget.NJNumericUpDown txtMm;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread hisMain;
        private FarPoint.Win.Spread.SheetView hisMain_Sheet1;
        protected Isid.NJ.View.Widget.NJButton njButton1;
        protected Isid.NJ.View.Widget.NJButton njButton2;
 
    }
}
