namespace Isid.KKH.Mac.View.Mast
{
    partial class frmMastTnpRrk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMastTnpRrk));
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnEnd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.lblKensu = new Isid.NJ.View.Widget.NJLabel();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.medMain = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.medMain_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnUpd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medMain_Sheet1)).BeginInit();
            this.SuspendLayout();
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
            this.btnHlp.Location = new System.Drawing.Point(890, 1);
            this.btnHlp.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseDownImage")));
            this.btnHlp.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseLeaveImage")));
            this.btnHlp.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseMoveImage")));
            this.btnHlp.Name = "btnHlp";
            this.btnHlp.Size = new System.Drawing.Size(37, 37);
            this.btnHlp.TabIndex = 4;
            this.btnHlp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHlp.UseVisualStyleBackColor = false;
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
            this.btnEnd.Location = new System.Drawing.Point(933, 1);
            this.btnEnd.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseDownImage")));
            this.btnEnd.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseLeaveImage")));
            this.btnEnd.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseMoveImage")));
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(37, 37);
            this.btnEnd.TabIndex = 5;
            this.btnEnd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // lblKensu
            // 
            this.lblKensu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKensu.AutoSize = true;
            this.lblKensu.Location = new System.Drawing.Point(732, 652);
            this.lblKensu.Name = "lblKensu";
            this.lblKensu.Size = new System.Drawing.Size(23, 12);
            this.lblKensu.TabIndex = 28;
            this.lblKensu.Text = "0件";
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
            // medMain
            // 
            this.medMain.AccessibleDescription = "medMain, Sheet1, Row 0, Column 0, ";
            this.medMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.medMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.medMain.EnableCustomSorting = false;
            this.medMain.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.medMain.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.medMain.Location = new System.Drawing.Point(5, 44);
            this.medMain.Name = "medMain";
            this.medMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.medMain.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.medMain_Sheet1});
            this.medMain.Size = new System.Drawing.Size(963, 599);
            this.medMain.TabIndex = 29;
            this.medMain.TabStop = false;
            this.medMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // medMain_Sheet1
            // 
            this.medMain_Sheet1.Reset();
            this.medMain_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.medMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.medMain_Sheet1.ColumnCount = 26;
            this.medMain_Sheet1.ColumnHeader.RowCount = 2;
            this.medMain_Sheet1.RowCount = 0;
            this.medMain_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.medMain_Sheet1.ColumnHeader.AutoFilterIndex = 1;
            this.medMain_Sheet1.ColumnHeader.AutoSortIndex = 1;
            this.medMain_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.medMain_Sheet1.ColumnHeader.AutoTextIndex = 0;
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = " ";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "更新時間";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "履歴種別";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "履歴種別コード";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "更新タイプ";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "更新タイプコード";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "店舗コード";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "店舗名";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "テリトリー";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "テリトリーコード";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "店舗区分";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "店舗区分コード";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "勘定科目";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "郵便番号";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "住所１";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "住所２";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "電話番号";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "明細行フラグ";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "明細行フラグコード";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "ライセンシー社名";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "代表者名";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "取引先コード";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "ステータス";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "初期G.OPEN年月日";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "G.OPEN年月日";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "G.CLOSE年月日";
            this.medMain_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.medMain_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.medMain_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.medMain_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.medMain_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.medMain_Sheet1.Columns.Get(0).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(0).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.medMain_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(0).Label = " ";
            this.medMain_Sheet1.Columns.Get(0).Locked = false;
            this.medMain_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(0).Width = 40F;
            this.medMain_Sheet1.Columns.Get(1).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(1).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(1).Label = "更新時間";
            this.medMain_Sheet1.Columns.Get(1).Locked = true;
            this.medMain_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(1).Width = 150F;
            this.medMain_Sheet1.Columns.Get(2).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(2).Label = "履歴種別";
            this.medMain_Sheet1.Columns.Get(2).Locked = true;
            this.medMain_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(3).Label = "履歴種別コード";
            this.medMain_Sheet1.Columns.Get(3).Visible = false;
            this.medMain_Sheet1.Columns.Get(4).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(4).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(4).Label = "更新タイプ";
            this.medMain_Sheet1.Columns.Get(4).Locked = true;
            this.medMain_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(5).Label = "更新タイプコード";
            this.medMain_Sheet1.Columns.Get(5).Visible = false;
            this.medMain_Sheet1.Columns.Get(6).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(6).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(6).Label = "店舗コード";
            this.medMain_Sheet1.Columns.Get(6).Locked = true;
            this.medMain_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(6).Width = 80F;
            this.medMain_Sheet1.Columns.Get(7).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(7).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(7).Label = "店舗名";
            this.medMain_Sheet1.Columns.Get(7).Locked = true;
            this.medMain_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(7).Width = 140F;
            this.medMain_Sheet1.Columns.Get(8).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(8).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(8).Label = "テリトリー";
            this.medMain_Sheet1.Columns.Get(8).Locked = true;
            this.medMain_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(9).Label = "テリトリーコード";
            this.medMain_Sheet1.Columns.Get(9).Visible = false;
            this.medMain_Sheet1.Columns.Get(10).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(10).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(10).Label = "店舗区分";
            this.medMain_Sheet1.Columns.Get(10).Locked = true;
            this.medMain_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(10).Width = 80F;
            this.medMain_Sheet1.Columns.Get(11).Label = "店舗区分コード";
            this.medMain_Sheet1.Columns.Get(11).Visible = false;
            this.medMain_Sheet1.Columns.Get(12).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(12).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(12).Label = "勘定科目";
            this.medMain_Sheet1.Columns.Get(12).Locked = true;
            this.medMain_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(12).Width = 80F;
            this.medMain_Sheet1.Columns.Get(13).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(13).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(13).Label = "郵便番号";
            this.medMain_Sheet1.Columns.Get(13).Locked = true;
            this.medMain_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(14).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(14).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(14).Label = "住所１";
            this.medMain_Sheet1.Columns.Get(14).Locked = true;
            this.medMain_Sheet1.Columns.Get(14).Width = 200F;
            this.medMain_Sheet1.Columns.Get(15).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(15).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(15).Label = "住所２";
            this.medMain_Sheet1.Columns.Get(15).Locked = true;
            this.medMain_Sheet1.Columns.Get(15).Width = 100F;
            this.medMain_Sheet1.Columns.Get(16).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(16).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(16).Label = "電話番号";
            this.medMain_Sheet1.Columns.Get(16).Locked = true;
            this.medMain_Sheet1.Columns.Get(16).Width = 100F;
            this.medMain_Sheet1.Columns.Get(17).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(17).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(17).Label = "明細行フラグ";
            this.medMain_Sheet1.Columns.Get(17).Locked = true;
            this.medMain_Sheet1.Columns.Get(17).Width = 80F;
            this.medMain_Sheet1.Columns.Get(18).Label = "明細行フラグコード";
            this.medMain_Sheet1.Columns.Get(18).Visible = false;
            this.medMain_Sheet1.Columns.Get(19).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(19).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(19).Label = "ライセンシー社名";
            this.medMain_Sheet1.Columns.Get(19).Locked = true;
            this.medMain_Sheet1.Columns.Get(19).Width = 120F;
            this.medMain_Sheet1.Columns.Get(20).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(20).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(20).Label = "代表者名";
            this.medMain_Sheet1.Columns.Get(20).Locked = true;
            this.medMain_Sheet1.Columns.Get(20).Width = 100F;
            this.medMain_Sheet1.Columns.Get(21).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(21).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(21).Label = "取引先コード";
            this.medMain_Sheet1.Columns.Get(21).Locked = true;
            this.medMain_Sheet1.Columns.Get(21).Width = 80F;
            this.medMain_Sheet1.Columns.Get(22).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(22).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(22).Label = "ステータス";
            this.medMain_Sheet1.Columns.Get(22).Locked = true;
            this.medMain_Sheet1.Columns.Get(23).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(23).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(23).Label = "初期G.OPEN年月日";
            this.medMain_Sheet1.Columns.Get(23).Locked = true;
            this.medMain_Sheet1.Columns.Get(23).Width = 120F;
            this.medMain_Sheet1.Columns.Get(24).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(24).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(24).Label = "G.OPEN年月日";
            this.medMain_Sheet1.Columns.Get(24).Locked = true;
            this.medMain_Sheet1.Columns.Get(24).Width = 120F;
            this.medMain_Sheet1.Columns.Get(25).AllowAutoFilter = true;
            this.medMain_Sheet1.Columns.Get(25).AllowAutoSort = true;
            this.medMain_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(25).Label = "G.CLOSE年月日";
            this.medMain_Sheet1.Columns.Get(25).Locked = true;
            this.medMain_Sheet1.Columns.Get(25).Width = 120F;
            this.medMain_Sheet1.DataAutoCellTypes = false;
            this.medMain_Sheet1.DataAutoHeadings = false;
            this.medMain_Sheet1.DataAutoSizeColumns = false;
            this.medMain_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.medMain_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.medMain_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.medMain_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.medMain_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.medMain_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.medMain_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.medMain_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.medMain_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.medMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.medMain.SetActiveViewport(0, 1, 0);
            // 
            // btnUpd
            // 
            this.btnUpd.BackColor = System.Drawing.Color.Transparent;
            this.btnUpd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpd.FlatAppearance.BorderSize = 0;
            this.btnUpd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUpd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUpd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpd.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpd.Image = ((System.Drawing.Image)(resources.GetObject("btnUpd.Image")));
            this.btnUpd.Location = new System.Drawing.Point(22, 12);
            this.btnUpd.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnUpd.MouseDownImage")));
            this.btnUpd.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnUpd.MouseLeaveImage")));
            this.btnUpd.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnUpd.MouseMoveImage")));
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(113, 22);
            this.btnUpd.TabIndex = 34;
            this.btnUpd.TabStop = false;
            this.btnUpd.Text = "   反映";
            this.btnUpd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpd.UseVisualStyleBackColor = false;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // frmMastTnpRrk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 668);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.medMain);
            this.Controls.Add(this.lblKensu);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.btnEnd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 300);
            this.Name = "frmMastTnpRrk";
            this.Text = "店舗マスター更新履歴";
            this.Shown += new System.EventHandler(this.frmMastTnpRrk_Shown);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.frmMastTnpRrk_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.lblKensu, 0);
            this.Controls.SetChildIndex(this.medMain, 0);
            this.Controls.SetChildIndex(this.btnUpd, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medMain_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHlp;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnEnd;
        protected Isid.NJ.View.Widget.NJLabel lblKensu;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread medMain;
        private FarPoint.Win.Spread.SheetView medMain_Sheet1;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnUpd;
    }
}


//namespace Isid.KKH.Ash.View.Report
//{
//    partial class ReportAshByMedium
//    {
//        /// <summary>
//        /// 必要なデザイナ変数です。
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// 使用中のリソースをすべてクリーンアップします。
//        /// </summary>
//        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows フォーム デザイナで生成されたコード

//        /// <summary>
//        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
//        /// コード エディタで変更しないでください。
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.label1 = new Isid.NJ.View.Widget.NJLabel();
//            this.njLabel1 = new Isid.NJ.View.Widget.NJLabel();
//            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
//            this.btnEnd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
//            this.btnXls = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
//            this.btnSrc = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
//            this.lblKensu = new Isid.NJ.View.Widget.NJLabel();
//            this.txtYyyy = new System.Windows.Forms.NumericUpDown();
//            this.txtMm = new System.Windows.Forms.NumericUpDown();
//            this.dataSet1 = new System.Data.DataSet();
//            this.dataTable1 = new System.Data.DataTable();
//            this.medMain = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
//            this.medMain_Sheet1 = new FarPoint.Win.Spread.SheetView();
//            this.mediaCmb = new Isid.NJ.View.Widget.NJComboBox();
//            this.njLabel2 = new Isid.NJ.View.Widget.NJLabel();
//            ((System.ComponentModel.ISupportInitialize)(this.txtYyyy)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.txtMm)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.medMain)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.medMain_Sheet1)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Location = new System.Drawing.Point(86, 31);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(17, 12);
//            this.label1.TabIndex = 10;
//            this.label1.Text = "年";
//            // 
//            // njLabel1
//            // 
//            this.njLabel1.AutoSize = true;
//            this.njLabel1.Location = new System.Drawing.Point(156, 31);
//            this.njLabel1.Name = "njLabel1";
//            this.njLabel1.Size = new System.Drawing.Size(17, 12);
//            this.njLabel1.TabIndex = 12;
//            this.njLabel1.Text = "月";
//            // 
//            // btnHlp
//            // 
//            this.btnHlp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.btnHlp.Location = new System.Drawing.Point(733, 15);
//            this.btnHlp.Name = "btnHlp";
//            this.btnHlp.Size = new System.Drawing.Size(68, 56);
//            this.btnHlp.TabIndex = 9;
//            this.btnHlp.Text = "ヘルプ";
//            this.btnHlp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
//            this.btnHlp.UseVisualStyleBackColor = true;
//            // 
//            // btnEnd
//            // 
//            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.btnEnd.Location = new System.Drawing.Point(807, 15);
//            this.btnEnd.Name = "btnEnd";
//            this.btnEnd.Size = new System.Drawing.Size(68, 56);
//            this.btnEnd.TabIndex = 10;
//            this.btnEnd.Text = "戻る";
//            this.btnEnd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
//            this.btnEnd.UseVisualStyleBackColor = true;
//            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
//            // 
//            // btnXls
//            // 
//            this.btnXls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.btnXls.Enabled = false;
//            this.btnXls.Location = new System.Drawing.Point(659, 15);
//            this.btnXls.Name = "btnXls";
//            this.btnXls.Size = new System.Drawing.Size(68, 56);
//            this.btnXls.TabIndex = 8;
//            this.btnXls.Text = "Excel";
//            this.btnXls.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
//            this.btnXls.UseVisualStyleBackColor = true;
//            this.btnXls.Click += new System.EventHandler(this.btnXls_Click);
//            // 
//            // btnSrc
//            // 
//            this.btnSrc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.btnSrc.Location = new System.Drawing.Point(585, 15);
//            this.btnSrc.Name = "btnSrc";
//            this.btnSrc.Size = new System.Drawing.Size(68, 56);
//            this.btnSrc.TabIndex = 6;
//            this.btnSrc.Text = "表示";
//            this.btnSrc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
//            this.btnSrc.UseVisualStyleBackColor = true;
//            this.btnSrc.Click += new System.EventHandler(this.btnSrc_Click);
//            // 
//            // lblKensu
//            // 
//            this.lblKensu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
//            this.lblKensu.AutoSize = true;
//            this.lblKensu.Location = new System.Drawing.Point(644, 533);
//            this.lblKensu.Name = "lblKensu";
//            this.lblKensu.Size = new System.Drawing.Size(23, 12);
//            this.lblKensu.TabIndex = 28;
//            this.lblKensu.Text = "0件";
//            // 
//            // txtYyyy
//            // 
//            this.txtYyyy.Location = new System.Drawing.Point(22, 25);
//            this.txtYyyy.Maximum = new decimal(new int[] {
//            9999,
//            0,
//            0,
//            0});
//            this.txtYyyy.Minimum = new decimal(new int[] {
//            1950,
//            0,
//            0,
//            0});
//            this.txtYyyy.Name = "txtYyyy";
//            this.txtYyyy.Size = new System.Drawing.Size(62, 21);
//            this.txtYyyy.TabIndex = 0;
//            this.txtYyyy.Value = new decimal(new int[] {
//            1950,
//            0,
//            0,
//            0});
//            // 
//            // txtMm
//            // 
//            this.txtMm.Location = new System.Drawing.Point(112, 25);
//            this.txtMm.Maximum = new decimal(new int[] {
//            12,
//            0,
//            0,
//            0});
//            this.txtMm.Minimum = new decimal(new int[] {
//            1,
//            0,
//            0,
//            0});
//            this.txtMm.Name = "txtMm";
//            this.txtMm.Size = new System.Drawing.Size(41, 21);
//            this.txtMm.TabIndex = 1;
//            this.txtMm.Value = new decimal(new int[] {
//            1,
//            0,
//            0,
//            0});
//            // 
//            // dataSet1
//            // 
//            this.dataSet1.DataSetName = "NewDataSet";
//            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
//            this.dataTable1});
//            // 
//            // dataTable1
//            // 
//            this.dataTable1.TableName = "Table1";
//            // 
//            // medMain
//            // 
//            this.medMain.AccessibleDescription = "medMain, Sheet1";
//            this.medMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//                        | System.Windows.Forms.AnchorStyles.Left)
//                        | System.Windows.Forms.AnchorStyles.Right)));
//            this.medMain.BackColor = System.Drawing.SystemColors.Control;
//            this.medMain.Location = new System.Drawing.Point(12, 77);
//            this.medMain.Name = "medMain";
//            this.medMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
//            this.medMain.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
//            this.medMain_Sheet1});
//            this.medMain.Size = new System.Drawing.Size(864, 436);
//            this.medMain.TabIndex = 29;
//            this.medMain.UseExcelDump = false;
//            // 
//            // medMain_Sheet1
//            // 
//            this.medMain_Sheet1.Reset();
//            this.medMain_Sheet1.SheetName = "Sheet1";
//            // Formulas and custom names must be loaded with R1C1 reference style
//            this.medMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
//            this.medMain_Sheet1.ColumnCount = 34;
//            this.medMain_Sheet1.RowCount = 0;
//            this.medMain_Sheet1.DataAutoCellTypes = false;
//            this.medMain_Sheet1.DataAutoHeadings = false;
//            this.medMain_Sheet1.DataAutoSizeColumns = false;
//            this.medMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
//            this.medMain.SetActiveViewport(0, 1, 0);
//            // 
//            // mediaCmb
//            // 
//            this.mediaCmb.FormattingEnabled = true;
//            this.mediaCmb.Location = new System.Drawing.Point(349, 31);
//            this.mediaCmb.Name = "mediaCmb";
//            this.mediaCmb.Size = new System.Drawing.Size(214, 20);
//            this.mediaCmb.TabIndex = 30;
//            // 
//            // njLabel2
//            // 
//            this.njLabel2.AutoSize = true;
//            this.njLabel2.Location = new System.Drawing.Point(266, 34);
//            this.njLabel2.Name = "njLabel2";
//            this.njLabel2.Size = new System.Drawing.Size(77, 12);
//            this.njLabel2.TabIndex = 31;
//            this.njLabel2.Text = "出力媒体選択";
//            // 
//            // ReportAshByMedium
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(886, 549);
//            this.Controls.Add(this.njLabel2);
//            this.Controls.Add(this.mediaCmb);
//            this.Controls.Add(this.medMain);
//            this.Controls.Add(this.txtMm);
//            this.Controls.Add(this.txtYyyy);
//            this.Controls.Add(this.lblKensu);
//            this.Controls.Add(this.btnSrc);
//            this.Controls.Add(this.btnXls);
//            this.Controls.Add(this.btnHlp);
//            this.Controls.Add(this.btnEnd);
//            this.Controls.Add(this.njLabel1);
//            this.Controls.Add(this.label1);
//            this.Name = "ReportAshByMedium";
//            this.Text = "帳票出力";
//            this.Load += new System.EventHandler(this.ReportAshByMedium_Load);
//            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.ReportAshByMedium_ProcessAffterNavigating);
//            this.Controls.SetChildIndex(this.label1, 0);
//            this.Controls.SetChildIndex(this.njLabel1, 0);
//            this.Controls.SetChildIndex(this.btnEnd, 0);
//            this.Controls.SetChildIndex(this.btnHlp, 0);
//            this.Controls.SetChildIndex(this.btnXls, 0);
//            this.Controls.SetChildIndex(this.btnSrc, 0);
//            this.Controls.SetChildIndex(this.lblKensu, 0);
//            this.Controls.SetChildIndex(this.txtYyyy, 0);
//            this.Controls.SetChildIndex(this.txtMm, 0);
//            this.Controls.SetChildIndex(this.medMain, 0);
//            this.Controls.SetChildIndex(this.mediaCmb, 0);
//            this.Controls.SetChildIndex(this.njLabel2, 0);
//            ((System.ComponentModel.ISupportInitialize)(this.txtYyyy)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.txtMm)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.medMain)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.medMain_Sheet1)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        protected Isid.NJ.View.Widget.NJLabel label1;
//        protected Isid.NJ.View.Widget.NJLabel njLabel1;
//        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHlp;
//        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnEnd;
//        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnXls;
//        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnSrc;
//        protected Isid.NJ.View.Widget.NJLabel lblKensu;
//        private System.Windows.Forms.NumericUpDown txtYyyy;
//        private System.Windows.Forms.NumericUpDown txtMm;
//        private System.Data.DataSet dataSet1;
//        private System.Data.DataTable dataTable1;
//        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread medMain;
//        private FarPoint.Win.Spread.SheetView medMain_Sheet1;
//        private Isid.NJ.View.Widget.NJComboBox mediaCmb;
//        private Isid.NJ.View.Widget.NJLabel njLabel2;
//    }
//}
