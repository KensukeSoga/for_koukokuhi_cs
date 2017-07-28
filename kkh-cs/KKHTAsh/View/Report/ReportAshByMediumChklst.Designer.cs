namespace Isid.KKH.Ash.View.Report
{
    partial class ReportAshByMediumChklst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportAshByMediumChklst));
            this.btnEnd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnXls = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnSrc = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.lblKensu = new Isid.NJ.View.Widget.NJLabel();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.mediaCmb = new Isid.NJ.View.Widget.NJComboBox();
            this.njLabel2 = new Isid.NJ.View.Widget.NJLabel();
            this.txtSeiGak = new Isid.NJ.View.Widget.NJTextBox();
            this.njLabel3 = new Isid.NJ.View.Widget.NJLabel();
            this.medMain = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.medMain_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.txtYm = new Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl();
            this.lblYyyyMm = new Isid.NJ.View.Widget.NJLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeiGak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medMain_Sheet1)).BeginInit();
            this.SuspendLayout();
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
            this.btnEnd.Location = new System.Drawing.Point(928, 1);
            this.btnEnd.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseDownImage")));
            this.btnEnd.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseLeaveImage")));
            this.btnEnd.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseMoveImage")));
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(37, 37);
            this.btnEnd.TabIndex = 6;
            this.btnEnd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
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
            this.btnXls.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnXls.Image = ((System.Drawing.Image)(resources.GetObject("btnXls.Image")));
            this.btnXls.Location = new System.Drawing.Point(668, 10);
            this.btnXls.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseDownImage")));
            this.btnXls.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseLeaveImage")));
            this.btnXls.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseMoveImage")));
            this.btnXls.Name = "btnXls";
            this.btnXls.Size = new System.Drawing.Size(113, 22);
            this.btnXls.TabIndex = 4;
            this.btnXls.Text = "    帳票出力";
            this.btnXls.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXls.UseVisualStyleBackColor = false;
            this.btnXls.Click += new System.EventHandler(this.btnXls_Click);
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
            this.btnSrc.Location = new System.Drawing.Point(144, 8);
            this.btnSrc.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseDownImage")));
            this.btnSrc.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseLeaveImage")));
            this.btnSrc.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseMoveImage")));
            this.btnSrc.Name = "btnSrc";
            this.btnSrc.Size = new System.Drawing.Size(113, 22);
            this.btnSrc.TabIndex = 3;
            this.btnSrc.Text = "検索";
            this.btnSrc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSrc.UseVisualStyleBackColor = false;
            this.btnSrc.Click += new System.EventHandler(this.btnSrc_Click);
            // 
            // lblKensu
            // 
            this.lblKensu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKensu.AutoSize = true;
            this.lblKensu.Location = new System.Drawing.Point(730, 650);
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
            // mediaCmb
            // 
            this.mediaCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mediaCmb.Enabled = false;
            this.mediaCmb.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.mediaCmb.FormattingEnabled = true;
            this.mediaCmb.Location = new System.Drawing.Point(325, 10);
            this.mediaCmb.Name = "mediaCmb";
            this.mediaCmb.Size = new System.Drawing.Size(130, 20);
            this.mediaCmb.TabIndex = 2;
            this.mediaCmb.SelectedIndexChanged += new System.EventHandler(this.mediaCmb_SelectedIndexChanged);
            // 
            // njLabel2
            // 
            this.njLabel2.AutoSize = true;
            this.njLabel2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel2.Location = new System.Drawing.Point(470, 15);
            this.njLabel2.Name = "njLabel2";
            this.njLabel2.Size = new System.Drawing.Size(85, 12);
            this.njLabel2.TabIndex = 31;
            this.njLabel2.Text = "請求金額(税込)\r\n";
            // 
            // txtSeiGak
            // 
            this.txtSeiGak.BackColor = System.Drawing.Color.White;
            this.txtSeiGak.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSeiGak.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSeiGak.Location = new System.Drawing.Point(561, 12);
            this.txtSeiGak.Name = "txtSeiGak";
            this.txtSeiGak.ReadOnly = true;
            this.txtSeiGak.Size = new System.Drawing.Size(101, 19);
            this.txtSeiGak.TabIndex = 1;
            this.txtSeiGak.TabStop = false;
            this.txtSeiGak.Text = "0";
            this.txtSeiGak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // njLabel3
            // 
            this.njLabel3.AutoSize = true;
            this.njLabel3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel3.Location = new System.Drawing.Point(266, 14);
            this.njLabel3.Name = "njLabel3";
            this.njLabel3.Size = new System.Drawing.Size(53, 12);
            this.njLabel3.TabIndex = 33;
            this.njLabel3.Text = "表示媒体";
            // 
            // medMain
            // 
            this.medMain.AccessibleDescription = "medMain, Sheet1";
            this.medMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.medMain.BackColor = System.Drawing.SystemColors.Control;
            this.medMain.EnableCustomSorting = false;
            this.medMain.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.medMain.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.medMain.Location = new System.Drawing.Point(5, 44);
            this.medMain.Name = "medMain";
            this.medMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.medMain.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.medMain_Sheet1});
            this.medMain.Size = new System.Drawing.Size(961, 597);
            this.medMain.TabIndex = 7;
            this.medMain.TabStop = false;
            this.medMain.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // medMain_Sheet1
            // 
            this.medMain_Sheet1.Reset();
            this.medMain_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.medMain_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.medMain_Sheet1.ColumnCount = 18;
            this.medMain_Sheet1.RowCount = 0;
            this.medMain_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "相手先コード";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "枝番区分";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "枝番区分コード";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "媒体コード(内部)";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "媒体コード";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "媒体CD（媒体局別）";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "媒体名称";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "ブランドコード";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "ブランド（品種）";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "ブランド名称";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "金額";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "税込み金額";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "適用1";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "適用2";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "表示順";
            this.medMain_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.medMain_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.medMain_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.medMain_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.medMain_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.medMain_Sheet1.Columns.Get(0).Label = "相手先コード";
            this.medMain_Sheet1.Columns.Get(0).Locked = true;
            this.medMain_Sheet1.Columns.Get(0).Width = 130F;
            this.medMain_Sheet1.Columns.Get(1).Label = "枝番区分";
            this.medMain_Sheet1.Columns.Get(1).Locked = true;
            this.medMain_Sheet1.Columns.Get(1).Width = 130F;
            this.medMain_Sheet1.Columns.Get(2).Label = "枝番区分コード";
            this.medMain_Sheet1.Columns.Get(2).Locked = true;
            this.medMain_Sheet1.Columns.Get(2).Visible = false;
            this.medMain_Sheet1.Columns.Get(2).Width = 130F;
            this.medMain_Sheet1.Columns.Get(3).Label = "媒体コード(内部)";
            this.medMain_Sheet1.Columns.Get(3).Locked = true;
            this.medMain_Sheet1.Columns.Get(3).Visible = false;
            this.medMain_Sheet1.Columns.Get(3).Width = 130F;
            this.medMain_Sheet1.Columns.Get(4).Label = "媒体コード";
            this.medMain_Sheet1.Columns.Get(4).Locked = true;
            this.medMain_Sheet1.Columns.Get(4).Visible = false;
            this.medMain_Sheet1.Columns.Get(4).Width = 130F;
            this.medMain_Sheet1.Columns.Get(5).Label = "媒体CD（媒体局別）";
            this.medMain_Sheet1.Columns.Get(5).Locked = true;
            this.medMain_Sheet1.Columns.Get(5).Width = 130F;
            this.medMain_Sheet1.Columns.Get(6).Label = "媒体名称";
            this.medMain_Sheet1.Columns.Get(6).Locked = true;
            this.medMain_Sheet1.Columns.Get(6).Width = 130F;
            this.medMain_Sheet1.Columns.Get(7).Label = "ブランドコード";
            this.medMain_Sheet1.Columns.Get(7).Locked = true;
            this.medMain_Sheet1.Columns.Get(7).Visible = false;
            this.medMain_Sheet1.Columns.Get(7).Width = 130F;
            this.medMain_Sheet1.Columns.Get(8).Label = "ブランド（品種）";
            this.medMain_Sheet1.Columns.Get(8).Locked = true;
            this.medMain_Sheet1.Columns.Get(8).Width = 130F;
            this.medMain_Sheet1.Columns.Get(9).Label = "ブランド名称";
            this.medMain_Sheet1.Columns.Get(9).Locked = true;
            this.medMain_Sheet1.Columns.Get(9).Width = 130F;
            this.medMain_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.medMain_Sheet1.Columns.Get(10).Label = "金額";
            this.medMain_Sheet1.Columns.Get(10).Locked = true;
            this.medMain_Sheet1.Columns.Get(10).Width = 150F;
            this.medMain_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.medMain_Sheet1.Columns.Get(11).Label = "税込み金額";
            this.medMain_Sheet1.Columns.Get(11).Locked = true;
            this.medMain_Sheet1.Columns.Get(11).Width = 150F;
            this.medMain_Sheet1.Columns.Get(12).Label = "適用1";
            this.medMain_Sheet1.Columns.Get(12).Locked = true;
            this.medMain_Sheet1.Columns.Get(12).Width = 250F;
            this.medMain_Sheet1.Columns.Get(13).Label = "適用2";
            this.medMain_Sheet1.Columns.Get(13).Locked = true;
            this.medMain_Sheet1.Columns.Get(13).Width = 250F;
            this.medMain_Sheet1.Columns.Get(14).Locked = true;
            this.medMain_Sheet1.Columns.Get(14).Visible = false;
            this.medMain_Sheet1.Columns.Get(15).Locked = true;
            this.medMain_Sheet1.Columns.Get(15).Visible = false;
            this.medMain_Sheet1.Columns.Get(16).Locked = true;
            this.medMain_Sheet1.Columns.Get(16).Visible = false;
            this.medMain_Sheet1.Columns.Get(17).Label = "表示順";
            this.medMain_Sheet1.Columns.Get(17).Locked = true;
            this.medMain_Sheet1.Columns.Get(17).Visible = false;
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
            this.medMain.SetViewportLeftColumn(0, 0, 9);
            this.medMain.SetActiveViewport(0, 1, 0);
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
            this.btnHlp.Location = new System.Drawing.Point(885, 1);
            this.btnHlp.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseDownImage")));
            this.btnHlp.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseLeaveImage")));
            this.btnHlp.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseMoveImage")));
            this.btnHlp.Name = "btnHlp";
            this.btnHlp.Size = new System.Drawing.Size(37, 37);
            this.btnHlp.TabIndex = 5;
            this.btnHlp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHlp.UseVisualStyleBackColor = false;
            this.btnHlp.Click += new System.EventHandler(this.btnHlp_Click);
            // 
            // txtYm
            // 
            this.txtYm.DisplayMode = Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.DisplayMode.COMBO;
            this.txtYm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtYm.Location = new System.Drawing.Point(49, 9);
            this.txtYm.MinimumSize = new System.Drawing.Size(82, 21);
            this.txtYm.Name = "txtYm";
            this.txtYm.Size = new System.Drawing.Size(82, 21);
            this.txtYm.TabIndex = 0;
            this.txtYm.ValidateDisableOnce = false;
            this.txtYm.Enter += new System.EventHandler(this.txtYm_Enter);
            // 
            // lblYyyyMm
            // 
            this.lblYyyyMm.AutoSize = true;
            this.lblYyyyMm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblYyyyMm.Location = new System.Drawing.Point(10, 15);
            this.lblYyyyMm.Name = "lblYyyyMm";
            this.lblYyyyMm.Size = new System.Drawing.Size(29, 12);
            this.lblYyyyMm.TabIndex = 34;
            this.lblYyyyMm.Text = "年月";
            // 
            // ReportAshByMediumChklst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 666);
            this.Controls.Add(this.lblYyyyMm);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.medMain);
            this.Controls.Add(this.njLabel3);
            this.Controls.Add(this.mediaCmb);
            this.Controls.Add(this.txtSeiGak);
            this.Controls.Add(this.lblKensu);
            this.Controls.Add(this.njLabel2);
            this.Controls.Add(this.btnSrc);
            this.Controls.Add(this.btnXls);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.txtYm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 300);
            this.Name = "ReportAshByMediumChklst";
            this.Text = "広告費アップロードシート";
            this.Shown += new System.EventHandler(this.ReportAshByMediumChklst_Shown);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.ReportAshByMedium_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.txtYm, 0);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.btnXls, 0);
            this.Controls.SetChildIndex(this.btnSrc, 0);
            this.Controls.SetChildIndex(this.njLabel2, 0);
            this.Controls.SetChildIndex(this.lblKensu, 0);
            this.Controls.SetChildIndex(this.txtSeiGak, 0);
            this.Controls.SetChildIndex(this.mediaCmb, 0);
            this.Controls.SetChildIndex(this.njLabel3, 0);
            this.Controls.SetChildIndex(this.medMain, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.lblYyyyMm, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeiGak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medMain_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnEnd;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnXls;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnSrc;
        protected Isid.NJ.View.Widget.NJLabel lblKensu;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private Isid.NJ.View.Widget.NJComboBox mediaCmb;
        private Isid.NJ.View.Widget.NJLabel njLabel2;
        private Isid.NJ.View.Widget.NJTextBox txtSeiGak;
        private Isid.NJ.View.Widget.NJLabel njLabel3;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread medMain;
        private FarPoint.Win.Spread.SheetView medMain_Sheet1;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHlp;
        private Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl txtYm;
        private Isid.NJ.View.Widget.NJLabel lblYyyyMm;
    }
}
