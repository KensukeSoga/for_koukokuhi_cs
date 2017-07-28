namespace Isid.KKH.Lion.View.Report
{
    partial class FDLion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDLion));
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType1 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType2 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType3 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType4 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType5 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType6 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType7 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType8 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType9 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType10 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            this.txtYm = new Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl();
            this.cmbBaitai = new Isid.NJ.View.Widget.NJComboBox();
            this.btnSrc = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnXls = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnEnd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.dgvMain = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.dgvMain_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fDDSLion = new Isid.KKH.Lion.Schema.FDDSLion();
            this.dgvMain_Sheet2 = new FarPoint.Win.Spread.SheetView();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.njToolTip1 = new Isid.NJ.View.Widget.NJToolTip();
            this.lblYyyyMm = new Isid.NJ.View.Widget.NJLabel();
            this.lblBaitaiMei = new Isid.NJ.View.Widget.NJLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fDDSLion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain_Sheet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
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
            this.txtYm.TabIndex = 2;
            this.txtYm.ValidateDisableOnce = false;
            this.txtYm.Enter += new System.EventHandler(this.condChg);
            // 
            // cmbBaitai
            // 
            this.cmbBaitai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaitai.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBaitai.FormattingEnabled = true;
            this.cmbBaitai.Items.AddRange(new object[] {
            "制作",
            "媒体"});
            this.cmbBaitai.Location = new System.Drawing.Point(196, 12);
            this.cmbBaitai.Name = "cmbBaitai";
            this.cmbBaitai.Size = new System.Drawing.Size(79, 20);
            this.cmbBaitai.TabIndex = 4;
            this.cmbBaitai.SelectedIndexChanged += new System.EventHandler(this.cmbBaitai_SelectedIndexChanged);
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
            this.btnSrc.Location = new System.Drawing.Point(293, 10);
            this.btnSrc.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseDownImage")));
            this.btnSrc.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseLeaveImage")));
            this.btnSrc.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseMoveImage")));
            this.btnSrc.Name = "btnSrc";
            this.btnSrc.Size = new System.Drawing.Size(113, 22);
            this.btnSrc.TabIndex = 5;
            this.btnSrc.TabStop = false;
            this.btnSrc.Text = "検索";
            this.btnSrc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSrc.UseVisualStyleBackColor = false;
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
            this.btnXls.Location = new System.Drawing.Point(424, 10);
            this.btnXls.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseDownImage")));
            this.btnXls.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseLeaveImage")));
            this.btnXls.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseMoveImage")));
            this.btnXls.Name = "btnXls";
            this.btnXls.Size = new System.Drawing.Size(113, 22);
            this.btnXls.TabIndex = 6;
            this.btnXls.TabStop = false;
            this.btnXls.Text = "   csv出力";
            this.btnXls.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXls.UseVisualStyleBackColor = false;
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
            this.btnHlp.Location = new System.Drawing.Point(887, 3);
            this.btnHlp.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseDownImage")));
            this.btnHlp.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseLeaveImage")));
            this.btnHlp.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseMoveImage")));
            this.btnHlp.Name = "btnHlp";
            this.btnHlp.Size = new System.Drawing.Size(37, 37);
            this.btnHlp.TabIndex = 7;
            this.btnHlp.TabStop = false;
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
            this.btnEnd.Location = new System.Drawing.Point(930, 3);
            this.btnEnd.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseDownImage")));
            this.btnEnd.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseLeaveImage")));
            this.btnEnd.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseMoveImage")));
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(37, 37);
            this.btnEnd.TabIndex = 8;
            this.btnEnd.TabStop = false;
            this.btnEnd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.AccessibleDescription = "dgvMain, Sheet2, Row 0, Column 0, ";
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.BackColor = System.Drawing.SystemColors.Control;
            this.dgvMain.EnableCustomSorting = false;
            this.dgvMain.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMain.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.dgvMain.Location = new System.Drawing.Point(4, 48);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvMain.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;
            this.dgvMain.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.dgvMain_Sheet1,
            this.dgvMain_Sheet2});
            this.dgvMain.Size = new System.Drawing.Size(963, 591);
            this.dgvMain.TabIndex = 9;
            this.dgvMain.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.dgvMain.TabStripRatio = 0.75;
            this.dgvMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.dgvMain.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.dgvMain_CellClick);
            // 
            // dgvMain_Sheet1
            // 
            this.dgvMain_Sheet1.Reset();
            this.dgvMain_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.dgvMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.dgvMain_Sheet1.ColumnCount = 23;
            this.dgvMain_Sheet1.ColumnHeader.RowCount = 2;
            this.dgvMain_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.dgvMain_Sheet1.ColumnHeader.AutoFilterIndex = 1;
            this.dgvMain_Sheet1.ColumnHeader.AutoSortIndex = 1;
            this.dgvMain_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.dgvMain_Sheet1.ColumnHeader.AutoTextIndex = 0;
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "ｽﾃｰﾀｽ";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "ｶｰﾄﾞNo";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "年月";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "代理店CD";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "媒体区分";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "番組CD";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "ﾌﾞﾗﾝﾄﾞCD";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "ﾌﾞﾗﾝﾄﾞ名称";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "局誌CD";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "局誌名称";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "ﾈｯﾄFC";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "府県CD";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "電波料";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "ﾈｯﾄ料・掲載料";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "制作費";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "金額";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "合計";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "総秒数";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "秒数・源泉税区分";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "源泉税";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "雑広告消費税額";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "ｵﾝｴｱ回数";
            this.dgvMain_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "ﾃﾞｰﾀ処理CD";
            this.dgvMain_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.dgvMain_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.Columns.Get(0).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(0).DataField = "cKStatus";
            this.dgvMain_Sheet1.Columns.Get(0).Label = "ｽﾃｰﾀｽ";
            this.dgvMain_Sheet1.Columns.Get(0).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(1).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(1).DataField = "cKKdNo";
            this.dgvMain_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(1).Label = "ｶｰﾄﾞNo";
            this.dgvMain_Sheet1.Columns.Get(1).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(2).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(2).DataField = "cKYYMM";
            this.dgvMain_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(2).Label = "年月";
            this.dgvMain_Sheet1.Columns.Get(2).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(3).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(3).DataField = "cKDairitencd";
            this.dgvMain_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(3).Label = "代理店CD";
            this.dgvMain_Sheet1.Columns.Get(3).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(4).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(4).DataField = "cKBaitaicd";
            this.dgvMain_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(4).Label = "媒体区分";
            this.dgvMain_Sheet1.Columns.Get(4).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(5).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(5).DataField = "cKBangumicd";
            this.dgvMain_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(5).Label = "番組CD";
            this.dgvMain_Sheet1.Columns.Get(5).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(5).Visible = false;
            this.dgvMain_Sheet1.Columns.Get(6).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(6).DataField = "cKBrandcd";
            this.dgvMain_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(6).Label = "ﾌﾞﾗﾝﾄﾞCD";
            this.dgvMain_Sheet1.Columns.Get(6).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(7).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(7).DataField = "cKBrandName";
            this.dgvMain_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.dgvMain_Sheet1.Columns.Get(7).Label = "ﾌﾞﾗﾝﾄﾞ名称";
            this.dgvMain_Sheet1.Columns.Get(7).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(7).Width = 70F;
            this.dgvMain_Sheet1.Columns.Get(8).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(8).DataField = "cKKyokusicd";
            this.dgvMain_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(8).Label = "局誌CD";
            this.dgvMain_Sheet1.Columns.Get(8).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(8).Visible = false;
            this.dgvMain_Sheet1.Columns.Get(9).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(9).DataField = "cKKyokusiName";
            this.dgvMain_Sheet1.Columns.Get(9).Label = "局誌名称";
            this.dgvMain_Sheet1.Columns.Get(9).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(9).Visible = false;
            this.dgvMain_Sheet1.Columns.Get(10).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(10).DataField = "cKNetfc";
            this.dgvMain_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(10).Label = "ﾈｯﾄFC";
            this.dgvMain_Sheet1.Columns.Get(10).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(10).Visible = false;
            this.dgvMain_Sheet1.Columns.Get(11).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(11).DataField = "cKfukencd";
            this.dgvMain_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(11).Label = "府県CD";
            this.dgvMain_Sheet1.Columns.Get(11).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(11).Visible = false;
            this.dgvMain_Sheet1.Columns.Get(12).AllowAutoFilter = true;
            currencyCellType1.DecimalPlaces = 0;
            currencyCellType1.MaximumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            131072});
            currencyCellType1.MinimumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            -2147352576});
            currencyCellType1.Separator = ",";
            currencyCellType1.ShowCurrencySymbol = false;
            currencyCellType1.ShowSeparator = true;
            this.dgvMain_Sheet1.Columns.Get(12).CellType = currencyCellType1;
            this.dgvMain_Sheet1.Columns.Get(12).DataField = "cKDenpa";
            this.dgvMain_Sheet1.Columns.Get(12).Label = "電波料";
            this.dgvMain_Sheet1.Columns.Get(12).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(12).Visible = false;
            this.dgvMain_Sheet1.Columns.Get(13).AllowAutoFilter = true;
            currencyCellType2.DecimalPlaces = 0;
            currencyCellType2.MaximumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            131072});
            currencyCellType2.MinimumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            -2147352576});
            currencyCellType2.Separator = ",";
            currencyCellType2.ShowCurrencySymbol = false;
            currencyCellType2.ShowSeparator = true;
            this.dgvMain_Sheet1.Columns.Get(13).CellType = currencyCellType2;
            this.dgvMain_Sheet1.Columns.Get(13).DataField = "cKNet";
            this.dgvMain_Sheet1.Columns.Get(13).Label = "ﾈｯﾄ料・掲載料";
            this.dgvMain_Sheet1.Columns.Get(13).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(13).Visible = false;
            this.dgvMain_Sheet1.Columns.Get(13).Width = 90F;
            this.dgvMain_Sheet1.Columns.Get(14).AllowAutoFilter = true;
            currencyCellType3.DecimalPlaces = 0;
            currencyCellType3.MaximumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            131072});
            currencyCellType3.MinimumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            -2147352576});
            currencyCellType3.Separator = ",";
            currencyCellType3.ShowCurrencySymbol = false;
            currencyCellType3.ShowSeparator = true;
            this.dgvMain_Sheet1.Columns.Get(14).CellType = currencyCellType3;
            this.dgvMain_Sheet1.Columns.Get(14).DataField = "cKSeisaku";
            this.dgvMain_Sheet1.Columns.Get(14).Label = "制作費";
            this.dgvMain_Sheet1.Columns.Get(14).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(14).Visible = false;
            this.dgvMain_Sheet1.Columns.Get(15).AllowAutoFilter = true;
            currencyCellType4.DecimalPlaces = 0;
            currencyCellType4.MaximumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            131072});
            currencyCellType4.MinimumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            -2147352576});
            currencyCellType4.Separator = ",";
            currencyCellType4.ShowCurrencySymbol = false;
            currencyCellType4.ShowSeparator = true;
            this.dgvMain_Sheet1.Columns.Get(15).CellType = currencyCellType4;
            this.dgvMain_Sheet1.Columns.Get(15).DataField = "cKSeikyu";
            this.dgvMain_Sheet1.Columns.Get(15).Label = "金額";
            this.dgvMain_Sheet1.Columns.Get(15).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(16).AllowAutoFilter = true;
            currencyCellType5.DecimalPlaces = 0;
            currencyCellType5.MaximumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            131072});
            currencyCellType5.MinimumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            -2147352576});
            currencyCellType5.Separator = ",";
            currencyCellType5.ShowCurrencySymbol = false;
            currencyCellType5.ShowSeparator = true;
            this.dgvMain_Sheet1.Columns.Get(16).CellType = currencyCellType5;
            this.dgvMain_Sheet1.Columns.Get(16).DataField = "cKGoukei";
            this.dgvMain_Sheet1.Columns.Get(16).Label = "合計";
            this.dgvMain_Sheet1.Columns.Get(16).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(16).Visible = false;
            this.dgvMain_Sheet1.Columns.Get(17).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(17).DataField = "cKSoubyousu";
            this.dgvMain_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(17).Label = "総秒数";
            this.dgvMain_Sheet1.Columns.Get(17).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(17).Visible = false;
            this.dgvMain_Sheet1.Columns.Get(18).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(18).DataField = "cKByousu_Gensen";
            this.dgvMain_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(18).Label = "秒数・源泉税区分";
            this.dgvMain_Sheet1.Columns.Get(18).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(18).Width = 110F;
            this.dgvMain_Sheet1.Columns.Get(19).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(19).DataField = "cKGensenzeien";
            this.dgvMain_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.dgvMain_Sheet1.Columns.Get(19).Label = "源泉税";
            this.dgvMain_Sheet1.Columns.Get(19).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(20).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(20).DataField = "cKZatukoukoku";
            this.dgvMain_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(20).Label = "雑広告消費税額";
            this.dgvMain_Sheet1.Columns.Get(20).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(20).Visible = false;
            this.dgvMain_Sheet1.Columns.Get(20).Width = 100F;
            this.dgvMain_Sheet1.Columns.Get(21).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(21).DataField = "cKOnea";
            this.dgvMain_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(21).Label = "ｵﾝｴｱ回数";
            this.dgvMain_Sheet1.Columns.Get(21).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(21).Visible = false;
            this.dgvMain_Sheet1.Columns.Get(21).Width = 70F;
            this.dgvMain_Sheet1.Columns.Get(22).AllowAutoFilter = true;
            this.dgvMain_Sheet1.Columns.Get(22).DataField = "cKDetacd";
            this.dgvMain_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(22).Label = "ﾃﾞｰﾀ処理CD";
            this.dgvMain_Sheet1.Columns.Get(22).Locked = true;
            this.dgvMain_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.Columns.Get(22).Width = 80F;
            this.dgvMain_Sheet1.DataAutoCellTypes = false;
            this.dgvMain_Sheet1.DataAutoHeadings = false;
            this.dgvMain_Sheet1.DataAutoSizeColumns = false;
            this.dgvMain_Sheet1.DataSource = this.bindingSource1;
            this.dgvMain_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.dgvMain_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.dgvMain_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.dgvMain_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.dgvMain.SetActiveViewport(0, 1, 0);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "FDLionView";
            this.bindingSource1.DataSource = this.fDDSLion;
            // 
            // fDDSLion
            // 
            this.fDDSLion.DataSetName = "FDDSLion";
            this.fDDSLion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvMain_Sheet2
            // 
            this.dgvMain_Sheet2.Reset();
            this.dgvMain_Sheet2.SheetName = "Sheet2";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.dgvMain_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.dgvMain_Sheet2.ColumnCount = 23;
            this.dgvMain_Sheet2.ColumnHeader.RowCount = 2;
            this.dgvMain_Sheet2.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.dgvMain_Sheet2.ColumnHeader.AutoFilterIndex = 1;
            this.dgvMain_Sheet2.ColumnHeader.AutoSortIndex = 1;
            this.dgvMain_Sheet2.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.dgvMain_Sheet2.ColumnHeader.AutoTextIndex = 0;
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 0).Value = "ｽﾃｰﾀｽ";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 1).Value = "ｶｰﾄﾞNo";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 2).Value = "年月";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 3).Value = "代理店CD";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 4).Value = "媒体区分";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 5).Value = "番組CD";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 6).Value = "ﾌﾞﾗﾝﾄﾞCD";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 7).Value = "ﾌﾞﾗﾝﾄﾞ名称";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 8).Value = "局誌CD";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 9).Value = "局誌名称";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 10).Value = "ﾈｯﾄFC";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 11).Value = "府県CD";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 12).Value = "電波料";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 13).Value = "ﾈｯﾄ料・掲載料";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 14).Value = "制作費";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 15).Value = "金額";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 16).Value = "合計";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 17).Value = "総秒数";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 18).Value = "秒数・源泉税区分";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 19).Value = "源泉税";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 20).Value = "雑広告消費税額";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 21).Value = "ｵﾝｴｱ回数";
            this.dgvMain_Sheet2.ColumnHeader.Cells.Get(0, 22).Value = "ﾃﾞｰﾀ処理CD";
            this.dgvMain_Sheet2.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet2.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain_Sheet2.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.dgvMain_Sheet2.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet2.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet2.Columns.Get(0).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(0).DataField = "cKStatus";
            this.dgvMain_Sheet2.Columns.Get(0).Label = "ｽﾃｰﾀｽ";
            this.dgvMain_Sheet2.Columns.Get(0).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(1).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(1).DataField = "cKKdNo";
            this.dgvMain_Sheet2.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(1).Label = "ｶｰﾄﾞNo";
            this.dgvMain_Sheet2.Columns.Get(1).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(2).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(2).DataField = "cKYYMM";
            this.dgvMain_Sheet2.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(2).Label = "年月";
            this.dgvMain_Sheet2.Columns.Get(2).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(3).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(3).DataField = "cKDairitencd";
            this.dgvMain_Sheet2.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(3).Label = "代理店CD";
            this.dgvMain_Sheet2.Columns.Get(3).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(4).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(4).DataField = "cKBaitaicd";
            this.dgvMain_Sheet2.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(4).Label = "媒体区分";
            this.dgvMain_Sheet2.Columns.Get(4).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(5).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(5).DataField = "cKBangumicd";
            this.dgvMain_Sheet2.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(5).Label = "番組CD";
            this.dgvMain_Sheet2.Columns.Get(5).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(6).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(6).DataField = "cKBrandcd";
            this.dgvMain_Sheet2.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(6).Label = "ﾌﾞﾗﾝﾄﾞCD";
            this.dgvMain_Sheet2.Columns.Get(6).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(7).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(7).DataField = "cKBrandName";
            this.dgvMain_Sheet2.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.dgvMain_Sheet2.Columns.Get(7).Label = "ﾌﾞﾗﾝﾄﾞ名称";
            this.dgvMain_Sheet2.Columns.Get(7).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(7).Width = 70F;
            this.dgvMain_Sheet2.Columns.Get(8).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(8).DataField = "cKKyokusicd";
            this.dgvMain_Sheet2.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(8).Label = "局誌CD";
            this.dgvMain_Sheet2.Columns.Get(8).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(9).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(9).DataField = "cKKyokusiName";
            this.dgvMain_Sheet2.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.dgvMain_Sheet2.Columns.Get(9).Label = "局誌名称";
            this.dgvMain_Sheet2.Columns.Get(9).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(10).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(10).DataField = "cKNetfc";
            this.dgvMain_Sheet2.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(10).Label = "ﾈｯﾄFC";
            this.dgvMain_Sheet2.Columns.Get(10).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(11).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(11).DataField = "cKfukencd";
            this.dgvMain_Sheet2.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(11).Label = "府県CD";
            this.dgvMain_Sheet2.Columns.Get(11).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(12).AllowAutoFilter = true;
            currencyCellType6.DecimalPlaces = 0;
            currencyCellType6.MaximumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            131072});
            currencyCellType6.MinimumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            -2147352576});
            currencyCellType6.Separator = ",";
            currencyCellType6.ShowCurrencySymbol = false;
            currencyCellType6.ShowSeparator = true;
            this.dgvMain_Sheet2.Columns.Get(12).CellType = currencyCellType6;
            this.dgvMain_Sheet2.Columns.Get(12).DataField = "cKDenpa";
            this.dgvMain_Sheet2.Columns.Get(12).Label = "電波料";
            this.dgvMain_Sheet2.Columns.Get(12).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(13).AllowAutoFilter = true;
            currencyCellType7.DecimalPlaces = 0;
            currencyCellType7.MaximumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            131072});
            currencyCellType7.MinimumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            -2147352576});
            currencyCellType7.Separator = ",";
            currencyCellType7.ShowCurrencySymbol = false;
            currencyCellType7.ShowSeparator = true;
            this.dgvMain_Sheet2.Columns.Get(13).CellType = currencyCellType7;
            this.dgvMain_Sheet2.Columns.Get(13).DataField = "cKNet";
            this.dgvMain_Sheet2.Columns.Get(13).Label = "ﾈｯﾄ料・掲載料";
            this.dgvMain_Sheet2.Columns.Get(13).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(13).Width = 90F;
            this.dgvMain_Sheet2.Columns.Get(14).AllowAutoFilter = true;
            currencyCellType8.DecimalPlaces = 0;
            currencyCellType8.MaximumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            131072});
            currencyCellType8.MinimumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            -2147352576});
            currencyCellType8.Separator = ",";
            currencyCellType8.ShowCurrencySymbol = false;
            currencyCellType8.ShowSeparator = true;
            this.dgvMain_Sheet2.Columns.Get(14).CellType = currencyCellType8;
            this.dgvMain_Sheet2.Columns.Get(14).DataField = "cKSeisaku";
            this.dgvMain_Sheet2.Columns.Get(14).Label = "制作費";
            this.dgvMain_Sheet2.Columns.Get(14).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(15).AllowAutoFilter = true;
            currencyCellType9.DecimalPlaces = 0;
            currencyCellType9.MaximumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            131072});
            currencyCellType9.MinimumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            -2147352576});
            currencyCellType9.Separator = ",";
            currencyCellType9.ShowCurrencySymbol = false;
            currencyCellType9.ShowSeparator = true;
            this.dgvMain_Sheet2.Columns.Get(15).CellType = currencyCellType9;
            this.dgvMain_Sheet2.Columns.Get(15).DataField = "cKSeikyu";
            this.dgvMain_Sheet2.Columns.Get(15).Label = "金額";
            this.dgvMain_Sheet2.Columns.Get(15).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(16).AllowAutoFilter = true;
            currencyCellType10.DecimalPlaces = 0;
            currencyCellType10.MaximumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            131072});
            currencyCellType10.MinimumValue = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            -2147352576});
            currencyCellType10.Separator = ",";
            currencyCellType10.ShowCurrencySymbol = false;
            currencyCellType10.ShowSeparator = true;
            this.dgvMain_Sheet2.Columns.Get(16).CellType = currencyCellType10;
            this.dgvMain_Sheet2.Columns.Get(16).DataField = "cKGoukei";
            this.dgvMain_Sheet2.Columns.Get(16).Label = "合計";
            this.dgvMain_Sheet2.Columns.Get(16).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(16).Visible = false;
            this.dgvMain_Sheet2.Columns.Get(17).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(17).DataField = "cKSoubyousu";
            this.dgvMain_Sheet2.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(17).Label = "総秒数";
            this.dgvMain_Sheet2.Columns.Get(17).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(18).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(18).DataField = "cKByousu_Gensen";
            this.dgvMain_Sheet2.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(18).Label = "秒数・源泉税区分";
            this.dgvMain_Sheet2.Columns.Get(18).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(18).Width = 110F;
            this.dgvMain_Sheet2.Columns.Get(19).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(19).DataField = "cKGensenzeien";
            this.dgvMain_Sheet2.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.dgvMain_Sheet2.Columns.Get(19).Label = "源泉税";
            this.dgvMain_Sheet2.Columns.Get(19).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(20).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(20).DataField = "cKZatukoukoku";
            this.dgvMain_Sheet2.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(20).Label = "雑広告消費税額";
            this.dgvMain_Sheet2.Columns.Get(20).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(20).Width = 100F;
            this.dgvMain_Sheet2.Columns.Get(21).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(21).DataField = "cKOnea";
            this.dgvMain_Sheet2.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(21).Label = "ｵﾝｴｱ回数";
            this.dgvMain_Sheet2.Columns.Get(21).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(21).Width = 70F;
            this.dgvMain_Sheet2.Columns.Get(22).AllowAutoFilter = true;
            this.dgvMain_Sheet2.Columns.Get(22).DataField = "cKDetacd";
            this.dgvMain_Sheet2.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.dgvMain_Sheet2.Columns.Get(22).Label = "ﾃﾞｰﾀ処理CD";
            this.dgvMain_Sheet2.Columns.Get(22).Locked = true;
            this.dgvMain_Sheet2.Columns.Get(22).Width = 80F;
            this.dgvMain_Sheet2.DataAutoCellTypes = false;
            this.dgvMain_Sheet2.DataAutoHeadings = false;
            this.dgvMain_Sheet2.DataAutoSizeColumns = false;
            this.dgvMain_Sheet2.DataSource = this.bindingSource2;
            this.dgvMain_Sheet2.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.dgvMain_Sheet2.RowHeader.Columns.Default.Resizable = true;
            this.dgvMain_Sheet2.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet2.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain_Sheet2.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.dgvMain_Sheet2.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet2.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet2.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMain_Sheet2.SheetCornerStyle.Parent = "CornerDefault";
            this.dgvMain_Sheet2.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.dgvMain_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.dgvMain.SetActiveViewport(1, 1, 0);
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataMember = "FDLionView";
            this.bindingSource2.DataSource = this.fDDSLion;
            // 
            // lblYyyyMm
            // 
            this.lblYyyyMm.AutoSize = true;
            this.lblYyyyMm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYyyyMm.Location = new System.Drawing.Point(12, 15);
            this.lblYyyyMm.Name = "lblYyyyMm";
            this.lblYyyyMm.Size = new System.Drawing.Size(29, 12);
            this.lblYyyyMm.TabIndex = 30;
            this.lblYyyyMm.Text = "年月";
            // 
            // lblBaitaiMei
            // 
            this.lblBaitaiMei.AutoSize = true;
            this.lblBaitaiMei.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaitaiMei.Location = new System.Drawing.Point(149, 15);
            this.lblBaitaiMei.Name = "lblBaitaiMei";
            this.lblBaitaiMei.Size = new System.Drawing.Size(41, 12);
            this.lblBaitaiMei.TabIndex = 31;
            this.lblBaitaiMei.Text = "媒体名";
            // 
            // FDLion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(972, 666);
            this.Controls.Add(this.lblBaitaiMei);
            this.Controls.Add(this.lblYyyyMm);
            this.Controls.Add(this.txtYm);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.btnSrc);
            this.Controls.Add(this.cmbBaitai);
            this.Controls.Add(this.btnXls);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.btnEnd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 300);
            this.Name = "FDLion";
            this.Text = "請求データ出力";
            this.Shown += new System.EventHandler(this.FDLion_Lion_Shown);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.FDLion_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.btnXls, 0);
            this.Controls.SetChildIndex(this.cmbBaitai, 0);
            this.Controls.SetChildIndex(this.btnSrc, 0);
            this.Controls.SetChildIndex(this.dgvMain, 0);
            this.Controls.SetChildIndex(this.txtYm, 0);
            this.Controls.SetChildIndex(this.lblYyyyMm, 0);
            this.Controls.SetChildIndex(this.lblBaitaiMei, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fDDSLion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain_Sheet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl txtYm;
        protected Isid.NJ.View.Widget.NJComboBox cmbBaitai;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnSrc;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnXls;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHlp;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnEnd;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhSpread dgvMain;
        protected FarPoint.Win.Spread.SheetView dgvMain_Sheet1;
        protected FarPoint.Win.Spread.SheetView dgvMain_Sheet2;
        protected Isid.KKH.Lion.Schema.FDDSLion fDDSLion;
        protected System.Windows.Forms.BindingSource bindingSource1;
        protected System.Windows.Forms.BindingSource bindingSource2;
        private Isid.NJ.View.Widget.NJToolTip njToolTip1;
        private Isid.NJ.View.Widget.NJLabel lblYyyyMm;
        private Isid.NJ.View.Widget.NJLabel lblBaitaiMei;
    }
}
