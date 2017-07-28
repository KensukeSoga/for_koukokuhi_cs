namespace Isid.KKH.Lion.View.Detail
{
    partial class FindLionTVSpot
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindLionTVSpot));
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType1 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.labelYYYYMM = new Isid.NJ.View.Widget.NJLabel();
            this.textYYYYMM = new Isid.NJ.View.Widget.NJTextBox();
            this.labelJobNo = new Isid.NJ.View.Widget.NJLabel();
            this.textJobNo = new Isid.NJ.View.Widget.NJTextBox();
            this.textContractName = new Isid.NJ.View.Widget.NJTextBox();
            this.labelPeriod = new Isid.NJ.View.Widget.NJLabel();
            this.labelHyphen = new Isid.NJ.View.Widget.NJLabel();
            this.textPeriodFrom = new Isid.NJ.View.Widget.NJTextBox();
            this.textPeriodTo = new Isid.NJ.View.Widget.NJTextBox();
            this.btnSearch = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnCancel = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnDecision = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnAllSelect = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvMain1 = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.dgvMain1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.detailDSLion = new Isid.KKH.Lion.Schema.DetailDSLion();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvMain2 = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.dgvMain2_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.textYYYYMM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textJobNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textContractName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPeriodFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPeriodTo)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain1_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailDSLion)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain2_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelYYYYMM
            // 
            this.labelYYYYMM.AutoSize = true;
            this.labelYYYYMM.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelYYYYMM.Location = new System.Drawing.Point(346, 39);
            this.labelYYYYMM.Name = "labelYYYYMM";
            this.labelYYYYMM.Size = new System.Drawing.Size(53, 12);
            this.labelYYYYMM.TabIndex = 43;
            this.labelYYYYMM.Text = "請求年月";
            // 
            // textYYYYMM
            // 
            this.textYYYYMM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textYYYYMM.BeforeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textYYYYMM.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.textYYYYMM.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textYYYYMM.Location = new System.Drawing.Point(405, 35);
            this.textYYYYMM.Name = "textYYYYMM";
            this.textYYYYMM.ReadOnly = true;
            this.textYYYYMM.Size = new System.Drawing.Size(116, 19);
            this.textYYYYMM.TabIndex = 35;
            // 
            // labelJobNo
            // 
            this.labelJobNo.AutoSize = true;
            this.labelJobNo.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelJobNo.Location = new System.Drawing.Point(10, 13);
            this.labelJobNo.Name = "labelJobNo";
            this.labelJobNo.Size = new System.Drawing.Size(44, 12);
            this.labelJobNo.TabIndex = 39;
            this.labelJobNo.Text = "ジョブNo";
            // 
            // textJobNo
            // 
            this.textJobNo.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.textJobNo.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.textJobNo.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textJobNo.Location = new System.Drawing.Point(60, 9);
            this.textJobNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textJobNo.Name = "textJobNo";
            this.textJobNo.Size = new System.Drawing.Size(116, 19);
            this.textJobNo.TabIndex = 36;
            // 
            // textContractName
            // 
            this.textContractName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textContractName.BeforeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textContractName.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.textContractName.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textContractName.Location = new System.Drawing.Point(182, 9);
            this.textContractName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textContractName.Name = "textContractName";
            this.textContractName.ReadOnly = true;
            this.textContractName.Size = new System.Drawing.Size(116, 19);
            this.textContractName.TabIndex = 37;
            // 
            // labelPeriod
            // 
            this.labelPeriod.AutoSize = true;
            this.labelPeriod.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPeriod.Location = new System.Drawing.Point(9, 39);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(53, 12);
            this.labelPeriod.TabIndex = 33;
            this.labelPeriod.Text = "引合期間";
            // 
            // labelHyphen
            // 
            this.labelHyphen.AutoSize = true;
            this.labelHyphen.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelHyphen.Location = new System.Drawing.Point(190, 39);
            this.labelHyphen.Name = "labelHyphen";
            this.labelHyphen.Size = new System.Drawing.Size(17, 12);
            this.labelHyphen.TabIndex = 40;
            this.labelHyphen.Text = "～";
            // 
            // textPeriodFrom
            // 
            this.textPeriodFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textPeriodFrom.BeforeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textPeriodFrom.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.textPeriodFrom.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textPeriodFrom.Location = new System.Drawing.Point(68, 35);
            this.textPeriodFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textPeriodFrom.Name = "textPeriodFrom";
            this.textPeriodFrom.ReadOnly = true;
            this.textPeriodFrom.Size = new System.Drawing.Size(116, 19);
            this.textPeriodFrom.TabIndex = 38;
            // 
            // textPeriodTo
            // 
            this.textPeriodTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textPeriodTo.BeforeBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textPeriodTo.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.textPeriodTo.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textPeriodTo.Location = new System.Drawing.Point(213, 35);
            this.textPeriodTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textPeriodTo.Name = "textPeriodTo";
            this.textPeriodTo.ReadOnly = true;
            this.textPeriodTo.Size = new System.Drawing.Size(116, 19);
            this.textPeriodTo.TabIndex = 44;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(304, 6);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.MouseDownImage")));
            this.btnSearch.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.MouseLeaveImage")));
            this.btnSearch.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.MouseMoveImage")));
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(113, 22);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(725, 659);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseDownImage")));
            this.btnCancel.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseLeaveImage")));
            this.btnCancel.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseMoveImage")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 22);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "  キャンセル";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDecision
            // 
            this.btnDecision.BackColor = System.Drawing.Color.Transparent;
            this.btnDecision.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDecision.FlatAppearance.BorderSize = 0;
            this.btnDecision.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDecision.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDecision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecision.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDecision.Image = ((System.Drawing.Image)(resources.GetObject("btnDecision.Image")));
            this.btnDecision.Location = new System.Drawing.Point(606, 659);
            this.btnDecision.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDecision.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnDecision.MouseDownImage")));
            this.btnDecision.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnDecision.MouseLeaveImage")));
            this.btnDecision.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnDecision.MouseMoveImage")));
            this.btnDecision.Name = "btnDecision";
            this.btnDecision.Size = new System.Drawing.Size(113, 22);
            this.btnDecision.TabIndex = 25;
            this.btnDecision.TabStop = false;
            this.btnDecision.Text = "OK";
            this.btnDecision.UseVisualStyleBackColor = false;
            this.btnDecision.Click += new System.EventHandler(this.btnDecision_Click);
            // 
            // btnAllSelect
            // 
            this.btnAllSelect.BackColor = System.Drawing.Color.Transparent;
            this.btnAllSelect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAllSelect.FlatAppearance.BorderSize = 0;
            this.btnAllSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAllSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAllSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllSelect.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnAllSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnAllSelect.Image")));
            this.btnAllSelect.Location = new System.Drawing.Point(6, 63);
            this.btnAllSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAllSelect.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnAllSelect.MouseDownImage")));
            this.btnAllSelect.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnAllSelect.MouseLeaveImage")));
            this.btnAllSelect.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnAllSelect.MouseMoveImage")));
            this.btnAllSelect.Name = "btnAllSelect";
            this.btnAllSelect.Size = new System.Drawing.Size(113, 22);
            this.btnAllSelect.TabIndex = 41;
            this.btnAllSelect.TabStop = false;
            this.btnAllSelect.Text = "  全選択";
            this.btnAllSelect.UseVisualStyleBackColor = false;
            this.btnAllSelect.Click += new System.EventHandler(this.btnAllSelect_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabControl1.Location = new System.Drawing.Point(2, 92);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(840, 560);
            this.tabControl1.TabIndex = 42;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvMain1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(832, 535);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "一覧";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvMain1
            // 
            this.dgvMain1.AccessibleDescription = "dgvMain1, Sheet1";
            this.dgvMain1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dgvMain1.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.dgvMain1.Location = new System.Drawing.Point(6, 7);
            this.dgvMain1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvMain1.Name = "dgvMain1";
            this.dgvMain1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvMain1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.dgvMain1_Sheet1});
            this.dgvMain1.Size = new System.Drawing.Size(824, 521);
            this.dgvMain1.TabIndex = 32;
            this.dgvMain1.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // dgvMain1_Sheet1
            // 
            this.dgvMain1_Sheet1.Reset();
            this.dgvMain1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.dgvMain1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.dgvMain1_Sheet1.ColumnCount = 11;
            this.dgvMain1_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.dgvMain1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "SHK_NO";
            this.dgvMain1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "KYK_CD";
            this.dgvMain1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "KYKAN_NO";
            this.dgvMain1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "局誌CD";
            this.dgvMain1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "局誌名称";
            this.dgvMain1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "実施電波料";
            this.dgvMain1_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "本数";
            this.dgvMain1_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "秒数";
            this.dgvMain1_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "総秒数";
            this.dgvMain1_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "対象";
            this.dgvMain1_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain1_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.dgvMain1_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain1_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain1_Sheet1.Columns.Get(0).DataField = "SHK_NO";
            this.dgvMain1_Sheet1.Columns.Get(0).Visible = false;
            this.dgvMain1_Sheet1.Columns.Get(1).DataField = "KYK_CD";
            this.dgvMain1_Sheet1.Columns.Get(1).Visible = false;
            this.dgvMain1_Sheet1.Columns.Get(2).DataField = "KYKAN_NO";
            this.dgvMain1_Sheet1.Columns.Get(2).Visible = false;
            this.dgvMain1_Sheet1.Columns.Get(3).DataField = "TIKU";
            this.dgvMain1_Sheet1.Columns.Get(3).Visible = false;
            this.dgvMain1_Sheet1.Columns.Get(4).DataField = "KYOKUCD";
            this.dgvMain1_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain1_Sheet1.Columns.Get(4).Label = "局誌CD";
            this.dgvMain1_Sheet1.Columns.Get(4).Locked = true;
            this.dgvMain1_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain1_Sheet1.Columns.Get(5).DataField = "KYOKUNAME";
            this.dgvMain1_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.dgvMain1_Sheet1.Columns.Get(5).Label = "局誌名称";
            this.dgvMain1_Sheet1.Columns.Get(5).Locked = true;
            this.dgvMain1_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain1_Sheet1.Columns.Get(5).Width = 160F;
            currencyCellType1.MaximumValue = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            262144});
            currencyCellType1.MinimumValue = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            -2147221504});
            currencyCellType1.Separator = ",";
            currencyCellType1.ShowCurrencySymbol = false;
            currencyCellType1.ShowSeparator = true;
            this.dgvMain1_Sheet1.Columns.Get(6).CellType = currencyCellType1;
            this.dgvMain1_Sheet1.Columns.Get(6).DataField = "K_HKGAK_HAT";
            this.dgvMain1_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.dgvMain1_Sheet1.Columns.Get(6).Label = "実施電波料";
            this.dgvMain1_Sheet1.Columns.Get(6).Locked = true;
            this.dgvMain1_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain1_Sheet1.Columns.Get(6).Width = 160F;
            numberCellType1.DecimalPlaces = 0;
            this.dgvMain1_Sheet1.Columns.Get(7).CellType = numberCellType1;
            this.dgvMain1_Sheet1.Columns.Get(7).DataField = "COUNT";
            this.dgvMain1_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.dgvMain1_Sheet1.Columns.Get(7).Label = "本数";
            this.dgvMain1_Sheet1.Columns.Get(7).Locked = true;
            this.dgvMain1_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            numberCellType2.DecimalPlaces = 0;
            this.dgvMain1_Sheet1.Columns.Get(8).CellType = numberCellType2;
            this.dgvMain1_Sheet1.Columns.Get(8).DataField = "CM_SEC";
            this.dgvMain1_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.dgvMain1_Sheet1.Columns.Get(8).Label = "秒数";
            this.dgvMain1_Sheet1.Columns.Get(8).Locked = true;
            this.dgvMain1_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            numberCellType3.DecimalPlaces = 0;
            this.dgvMain1_Sheet1.Columns.Get(9).CellType = numberCellType3;
            this.dgvMain1_Sheet1.Columns.Get(9).DataField = "TOTAL_CM_SEC";
            this.dgvMain1_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.dgvMain1_Sheet1.Columns.Get(9).Label = "総秒数";
            this.dgvMain1_Sheet1.Columns.Get(9).Locked = true;
            this.dgvMain1_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain1_Sheet1.Columns.Get(10).CellType = checkBoxCellType1;
            this.dgvMain1_Sheet1.Columns.Get(10).DataField = "CHECK";
            this.dgvMain1_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain1_Sheet1.Columns.Get(10).Label = "対象";
            this.dgvMain1_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain1_Sheet1.DataAutoCellTypes = false;
            this.dgvMain1_Sheet1.DataAutoSizeColumns = false;
            this.dgvMain1_Sheet1.DataSource = this.bindingSource1;
            this.dgvMain1_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.dgvMain1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.dgvMain1_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain1_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain1_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.dgvMain1_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain1_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain1_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.dgvMain1_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.dgvMain1_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain1_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.dgvMain1_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.dgvMain1.SetActiveViewport(0, 1, 0);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "KkhTVSpotDetailListView";
            this.bindingSource1.DataSource = this.detailDSLion;
            // 
            // detailDSLion
            // 
            this.detailDSLion.DataSetName = "DetailDSLion";
            this.detailDSLion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvMain2);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(832, 535);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "素材";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvMain2
            // 
            this.dgvMain2.AccessibleDescription = "dgvMain2, Sheet1, Row 0, Column 0, ";
            this.dgvMain2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dgvMain2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.dgvMain2.Location = new System.Drawing.Point(6, 7);
            this.dgvMain2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvMain2.Name = "dgvMain2";
            this.dgvMain2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvMain2.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.dgvMain2_Sheet1});
            this.dgvMain2.Size = new System.Drawing.Size(820, 526);
            this.dgvMain2.TabIndex = 33;
            this.dgvMain2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // dgvMain2_Sheet1
            // 
            this.dgvMain2_Sheet1.Reset();
            this.dgvMain2_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.dgvMain2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.dgvMain2_Sheet1.ColumnCount = 6;
            this.dgvMain2_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.dgvMain2_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "JOB_NO";
            this.dgvMain2_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "KYK_CD";
            this.dgvMain2_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "KYKAN_NO";
            this.dgvMain2_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "素材コード";
            this.dgvMain2_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "略号";
            this.dgvMain2_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "秒数";
            this.dgvMain2_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain2_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain2_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.dgvMain2_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain2_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain2_Sheet1.Columns.Get(0).DataField = "SHK_NO";
            this.dgvMain2_Sheet1.Columns.Get(0).Label = "JOB_NO";
            this.dgvMain2_Sheet1.Columns.Get(0).Visible = false;
            this.dgvMain2_Sheet1.Columns.Get(1).DataField = "KYK_CD";
            this.dgvMain2_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.dgvMain2_Sheet1.Columns.Get(1).Visible = false;
            this.dgvMain2_Sheet1.Columns.Get(2).DataField = "KYKAN_NO";
            this.dgvMain2_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.dgvMain2_Sheet1.Columns.Get(2).Visible = false;
            this.dgvMain2_Sheet1.Columns.Get(3).DataField = "SZIKYTU";
            this.dgvMain2_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.dgvMain2_Sheet1.Columns.Get(3).Label = "素材コード";
            this.dgvMain2_Sheet1.Columns.Get(3).Locked = true;
            this.dgvMain2_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain2_Sheet1.Columns.Get(3).Width = 80F;
            this.dgvMain2_Sheet1.Columns.Get(4).DataField = "K_SZI_RYKG";
            this.dgvMain2_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain2_Sheet1.Columns.Get(4).Label = "略号";
            this.dgvMain2_Sheet1.Columns.Get(4).Locked = true;
            this.dgvMain2_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            numberCellType4.DecimalPlaces = 0;
            this.dgvMain2_Sheet1.Columns.Get(5).CellType = numberCellType4;
            this.dgvMain2_Sheet1.Columns.Get(5).DataField = "CM_SEC";
            this.dgvMain2_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.dgvMain2_Sheet1.Columns.Get(5).Label = "秒数";
            this.dgvMain2_Sheet1.Columns.Get(5).Locked = true;
            this.dgvMain2_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain2_Sheet1.DataAutoCellTypes = false;
            this.dgvMain2_Sheet1.DataAutoSizeColumns = false;
            this.dgvMain2_Sheet1.DataSource = this.bindingSource2;
            this.dgvMain2_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.dgvMain2_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain2_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain2_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.dgvMain2_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain2_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain2_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain2_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.dgvMain2_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain2_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.dgvMain2.SetActiveViewport(0, 1, 0);
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataMember = "KkhTVSpotMaterialListView";
            this.bindingSource2.DataSource = this.detailDSLion;
            // 
            // FindLionTVSpot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.ClientSize = new System.Drawing.Size(848, 689);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.textYYYYMM);
            this.Controls.Add(this.btnDecision);
            this.Controls.Add(this.labelYYYYMM);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnAllSelect);
            this.Controls.Add(this.labelHyphen);
            this.Controls.Add(this.labelJobNo);
            this.Controls.Add(this.textContractName);
            this.Controls.Add(this.textPeriodTo);
            this.Controls.Add(this.textJobNo);
            this.Controls.Add(this.textPeriodFrom);
            this.Controls.Add(this.labelPeriod);
            this.Controls.Add(this.btnSearch);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FindLionTVSpot";
            this.Text = "TVSpot検索";
            this.Load += new System.EventHandler(this.FindLionTVSpot_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.FindLionTVSpot_ProcessAffterNavigating);
            ((System.ComponentModel.ISupportInitialize)(this.textYYYYMM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textJobNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textContractName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPeriodFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPeriodTo)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain1_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailDSLion)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain2_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Isid.NJ.View.Widget.NJLabel labelYYYYMM;
        protected Isid.NJ.View.Widget.NJTextBox textYYYYMM;
        protected Isid.NJ.View.Widget.NJLabel labelJobNo;
        protected Isid.NJ.View.Widget.NJTextBox textJobNo;
        protected Isid.NJ.View.Widget.NJTextBox textContractName;
        protected Isid.NJ.View.Widget.NJLabel labelPeriod;
        protected Isid.NJ.View.Widget.NJLabel labelHyphen;
        protected Isid.NJ.View.Widget.NJTextBox textPeriodFrom;
        protected Isid.NJ.View.Widget.NJTextBox textPeriodTo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread dgvMain1;
        private FarPoint.Win.Spread.SheetView dgvMain1_Sheet1;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread dgvMain2;
        private FarPoint.Win.Spread.SheetView dgvMain2_Sheet1;
        private Isid.KKH.Lion.Schema.DetailDSLion detailDSLion;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnSearch;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnCancel;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnDecision;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnAllSelect;
    }
}
