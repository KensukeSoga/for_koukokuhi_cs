namespace Isid.KKH.Common.KKHView.Report
{
    partial class RptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptForm));
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.閉じるToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.bｔｎSearch = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.txbDay = new System.Windows.Forms.TextBox();
            this.lblDay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(34, 52);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(70, 21);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(133, 54);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(49, 21);
            this.numericUpDown2.TabIndex = 2;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(110, 61);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(17, 12);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "年";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(188, 61);
            this.lblMonth.MaximumSize = new System.Drawing.Size(12, 0);
            this.lblMonth.MinimumSize = new System.Drawing.Size(1, 0);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(12, 12);
            this.lblMonth.TabIndex = 5;
            this.lblMonth.Text = "月";
            // 
            // btnHelp
            // 
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Location = new System.Drawing.Point(681, 36);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(68, 56);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "ヘルプ";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(755, 36);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(68, 56);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "戻る";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(842, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.閉じるToolStripMenuItem});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.ファイルFToolStripMenuItem.Text = "ファイル(F)";
            // 
            // 閉じるToolStripMenuItem
            // 
            this.閉じるToolStripMenuItem.Name = "閉じるToolStripMenuItem";
            this.閉じるToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.閉じるToolStripMenuItem.Text = "閉じる";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 505);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(842, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(681, 17);
            this.toolStripStatusLabel3.Text = "　　　　       　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　" +
                "　　　　　　　";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel2.Text = "件";
            // 
            // fpSpread1
            // 
            this.fpSpread1.AccessibleDescription = "";
            this.fpSpread1.Location = new System.Drawing.Point(5, 170);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(818, 321);
            this.fpSpread1.TabIndex = 12;
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(607, 36);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(68, 56);
            this.btnPrint.TabIndex = 27;
            this.btnPrint.Text = "印刷";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.UseWaitCursor = true;
            // 
            // bｔｎSearch
            // 
            this.bｔｎSearch.Image = ((System.Drawing.Image)(resources.GetObject("bｔｎSearch.Image")));
            this.bｔｎSearch.Location = new System.Drawing.Point(459, 36);
            this.bｔｎSearch.Name = "bｔｎSearch";
            this.bｔｎSearch.Size = new System.Drawing.Size(68, 56);
            this.bｔｎSearch.TabIndex = 28;
            this.bｔｎSearch.Text = "検索";
            this.bｔｎSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bｔｎSearch.UseVisualStyleBackColor = true;
            // 
            // btnExcel
            // 
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.Location = new System.Drawing.Point(533, 36);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(68, 56);
            this.btnExcel.TabIndex = 29;
            this.btnExcel.Text = "Excel";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // txbDay
            // 
            this.txbDay.Location = new System.Drawing.Point(215, 54);
            this.txbDay.Name = "txbDay";
            this.txbDay.Size = new System.Drawing.Size(37, 21);
            this.txbDay.TabIndex = 30;
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(258, 63);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(17, 12);
            this.lblDay.TabIndex = 31;
            this.lblDay.Text = "日";
            // 
            // RptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 527);
            this.Controls.Add(this.txbDay);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.bｔｎSearch);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.fpSpread1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Name = "RptForm";
            this.Text = "帳票出力";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 閉じるToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button bｔｎSearch;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TextBox txbDay;
        private System.Windows.Forms.Label lblDay;
    }
}