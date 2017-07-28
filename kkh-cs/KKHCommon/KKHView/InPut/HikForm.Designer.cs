namespace Isid.KKH.Common.KKHView.InPut
{
    partial class HikForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HikForm));
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnHlp = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.閉じるToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSybtName = new System.Windows.Forms.Label();
            this.spdHikList = new FarPoint.Win.Spread.FpSpread();
            this.spdHikTrkmList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cbxSybtName = new Isid.Rg.View.Common.Control.RgComboBox();
            this.btnRead = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnSearch = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnExcelOut = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.tbxYyMm = new Isid.NJ.View.Widget.NJTextBox();
            this.rbnSaiSin = new Isid.NJ.View.Widget.NJRadioButton();
            this.rbnRireki = new Isid.NJ.View.Widget.NJRadioButton();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHikList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHikTrkmList_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxYyMm)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEnd.Image")));
            this.btnEnd.Location = new System.Drawing.Point(521, 30);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(68, 56);
            this.btnEnd.TabIndex = 11;
            this.btnEnd.Text = "戻る";
            this.btnEnd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnHlp
            // 
            this.btnHlp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHlp.Image = ((System.Drawing.Image)(resources.GetObject("btnHlp.Image")));
            this.btnHlp.Location = new System.Drawing.Point(452, 30);
            this.btnHlp.Name = "btnHlp";
            this.btnHlp.Size = new System.Drawing.Size(68, 56);
            this.btnHlp.TabIndex = 10;
            this.btnHlp.Text = "ヘルプ";
            this.btnHlp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHlp.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 465);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(592, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(560, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "　　　　　";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel2.Text = "件";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(592, 24);
            this.menuStrip1.TabIndex = 13;
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
            // lblSybtName
            // 
            this.lblSybtName.AutoSize = true;
            this.lblSybtName.Location = new System.Drawing.Point(11, 121);
            this.lblSybtName.Name = "lblSybtName";
            this.lblSybtName.Size = new System.Drawing.Size(53, 12);
            this.lblSybtName.TabIndex = 18;
            this.lblSybtName.Text = "媒体種別";
            // 
            // spdHikList
            // 
            this.spdHikList.AccessibleDescription = "spdHikList, Sheet1";
            this.spdHikList.BackColor = System.Drawing.SystemColors.Control;
            this.spdHikList.Location = new System.Drawing.Point(12, 144);
            this.spdHikList.Name = "spdHikList";
            this.spdHikList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdHikList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHikTrkmList_Sheet1});
            this.spdHikList.Size = new System.Drawing.Size(568, 308);
            this.spdHikList.TabIndex = 26;
            // 
            // spdHikTrkmList_Sheet1
            // 
            this.spdHikTrkmList_Sheet1.Reset();
            this.spdHikTrkmList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHikTrkmList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdHikTrkmList_Sheet1.ColumnCount = 55;
            this.spdHikTrkmList_Sheet1.RowCount = 0;
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "更新区分";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "履歴管理番号";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "依頼年月";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "発注番号";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "行番号";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "メディアコード";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "メディア名";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "サイズコード";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "サイズ";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "掲載日1";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "掲載日2";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "掲載日3";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "掲載日4";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "掲載日5";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "形態区分コード";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "形態区分名";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "依頼月1";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "放送料1";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "依頼月2";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "放送料2";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "依頼月3";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "放送料3";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "依頼月4";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "放送料4";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "依頼月5";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "放送料5";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "依頼月6";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "放送料6";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "交通掲載コード";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "交通掲載名";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "掲載日";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "掲載料";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "掲載単価";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "掲載回数";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "商品区分";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "細目区分";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "摘要コード";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "売上予定年月";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "担当者名";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "担当者勤務部署名";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "按分種別";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "備考1";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "備考2";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "色刷コード";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "デザイン変更回数";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "印刷代";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "差替作業料";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "デザイン料";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 48).Value = "刷下代";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 49).Value = "製版代";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "登録年月日";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "変更年月日";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 52).Value = "取消年月日";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 53).Value = "最新フラグ";
            this.spdHikTrkmList_Sheet1.ColumnHeader.Cells.Get(0, 54).Value = "更新区分名";
            this.spdHikTrkmList_Sheet1.Columns.Get(1).Label = "履歴管理番号";
            this.spdHikTrkmList_Sheet1.Columns.Get(1).Width = 79F;
            this.spdHikTrkmList_Sheet1.Columns.Get(2).Label = "依頼年月";
            this.spdHikTrkmList_Sheet1.Columns.Get(2).Width = 59F;
            this.spdHikTrkmList_Sheet1.Columns.Get(3).Label = "発注番号";
            this.spdHikTrkmList_Sheet1.Columns.Get(3).Width = 57F;
            this.spdHikTrkmList_Sheet1.Columns.Get(4).Label = "行番号";
            this.spdHikTrkmList_Sheet1.Columns.Get(4).Width = 52F;
            this.spdHikTrkmList_Sheet1.Columns.Get(5).Label = "メディアコード";
            this.spdHikTrkmList_Sheet1.Columns.Get(5).Width = 79F;
            this.spdHikTrkmList_Sheet1.Columns.Get(6).Label = "メディア名";
            this.spdHikTrkmList_Sheet1.Columns.Get(6).Width = 157F;
            this.spdHikTrkmList_Sheet1.Columns.Get(7).Label = "サイズコード";
            this.spdHikTrkmList_Sheet1.Columns.Get(7).Width = 43F;
            this.spdHikTrkmList_Sheet1.Columns.Get(8).Label = "サイズ";
            this.spdHikTrkmList_Sheet1.Columns.Get(8).Width = 58F;
            this.spdHikTrkmList_Sheet1.Columns.Get(9).Label = "掲載日1";
            this.spdHikTrkmList_Sheet1.Columns.Get(9).Width = 55F;
            this.spdHikTrkmList_Sheet1.Columns.Get(17).Label = "放送料1";
            this.spdHikTrkmList_Sheet1.Columns.Get(17).Locked = false;
            this.spdHikTrkmList_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHikTrkmList_Sheet1.Columns.Get(26).Label = "依頼月6";
            this.spdHikTrkmList_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHikTrkmList_Sheet1.Columns.Get(29).Label = "交通掲載名";
            this.spdHikTrkmList_Sheet1.Columns.Get(46).Label = "差替作業料";
            this.spdHikTrkmList_Sheet1.Columns.Get(46).Locked = false;
            this.spdHikTrkmList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ExtendedSelect;
            this.spdHikTrkmList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHikTrkmList_Sheet1.RowHeader.Columns.Get(0).Width = 22F;
            this.spdHikTrkmList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.MultiRange;
            this.spdHikTrkmList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdHikTrkmList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.spdHikList.SetViewportLeftColumn(0, 0, 42);
            this.spdHikList.SetActiveViewport(0, 1, 0);
            // 
            // cbxSybtName
            // 
            this.cbxSybtName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSybtName.FormattingEnabled = true;
            this.cbxSybtName.Location = new System.Drawing.Point(70, 118);
            this.cbxSybtName.Name = "cbxSybtName";
            this.cbxSybtName.Size = new System.Drawing.Size(64, 20);
            this.cbxSybtName.TabIndex = 27;
            this.cbxSybtName.SelectionChangeCommitted += new System.EventHandler(this.cbxBaiName_SelectionChangeCommitted);
            // 
            // btnRead
            // 
            this.btnRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRead.Location = new System.Drawing.Point(266, 30);
            this.btnRead.MouseDownImage = null;
            this.btnRead.MouseLeaveImage = null;
            this.btnRead.MouseMoveImage = null;
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(87, 56);
            this.btnRead.TabIndex = 30;
            this.btnRead.Text = "読込ファイル一覧";
            this.btnRead.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(536, 116);
            this.btnSearch.MouseDownImage = null;
            this.btnSearch.MouseLeaveImage = null;
            this.btnSearch.MouseMoveImage = null;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(44, 23);
            this.btnSearch.TabIndex = 31;
            this.btnSearch.Text = "表示";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExcelOut
            // 
            this.btnExcelOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcelOut.Location = new System.Drawing.Point(359, 30);
            this.btnExcelOut.MouseDownImage = null;
            this.btnExcelOut.MouseLeaveImage = null;
            this.btnExcelOut.MouseMoveImage = null;
            this.btnExcelOut.Name = "btnExcelOut";
            this.btnExcelOut.Size = new System.Drawing.Size(87, 56);
            this.btnExcelOut.TabIndex = 32;
            this.btnExcelOut.Text = "帳票作成";
            this.btnExcelOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcelOut.UseVisualStyleBackColor = true;
            this.btnExcelOut.Click += new System.EventHandler(this.btnExcelOut_Click);
            // 
            // tbxYyMm
            // 
            this.tbxYyMm.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.tbxYyMm.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.tbxYyMm.Location = new System.Drawing.Point(476, 116);
            this.tbxYyMm.MaxLength = 6;
            this.tbxYyMm.Name = "tbxYyMm";
            this.tbxYyMm.Size = new System.Drawing.Size(54, 21);
            this.tbxYyMm.TabIndex = 34;
            // 
            // rbnSaiSin
            // 
            this.rbnSaiSin.AutoSize = true;
            this.rbnSaiSin.Checked = true;
            this.rbnSaiSin.Location = new System.Drawing.Point(200, 118);
            this.rbnSaiSin.Name = "rbnSaiSin";
            this.rbnSaiSin.Size = new System.Drawing.Size(47, 16);
            this.rbnSaiSin.TabIndex = 35;
            this.rbnSaiSin.TabStop = true;
            this.rbnSaiSin.Text = "最新";
            this.rbnSaiSin.UseVisualStyleBackColor = true;
            this.rbnSaiSin.CheckedChanged += new System.EventHandler(this.rbnSaiSin_CheckedChanged);
            // 
            // rbnRireki
            // 
            this.rbnRireki.AutoSize = true;
            this.rbnRireki.Location = new System.Drawing.Point(307, 118);
            this.rbnRireki.Name = "rbnRireki";
            this.rbnRireki.Size = new System.Drawing.Size(47, 16);
            this.rbnRireki.TabIndex = 36;
            this.rbnRireki.Text = "履歴";
            this.rbnRireki.UseVisualStyleBackColor = true;
            this.rbnRireki.CheckedChanged += new System.EventHandler(this.rbnRireki_CheckedChanged);
            // 
            // HikForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 487);
            this.Controls.Add(this.rbnRireki);
            this.Controls.Add(this.rbnSaiSin);
            this.Controls.Add(this.tbxYyMm);
            this.Controls.Add(this.btnExcelOut);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.cbxSybtName);
            this.Controls.Add(this.spdHikList);
            this.Controls.Add(this.lblSybtName);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnHlp);
            this.Name = "HikForm";
            this.Text = "HikForm";
            this.Shown += new System.EventHandler(this.HikForm_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHikList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHikTrkmList_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxYyMm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnHlp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 閉じるToolStripMenuItem;
        private System.Windows.Forms.Label lblSybtName;
        private FarPoint.Win.Spread.FpSpread spdHikList;
        private FarPoint.Win.Spread.SheetView spdHikTrkmList_Sheet1;
        private Isid.Rg.View.Common.Control.RgComboBox cbxSybtName;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnRead;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnSearch;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnExcelOut;
        private Isid.NJ.View.Widget.NJTextBox tbxYyMm;
        private Isid.NJ.View.Widget.NJRadioButton rbnSaiSin;
        private Isid.NJ.View.Widget.NJRadioButton rbnRireki;

    }
}