namespace Isid.KKH.Ash.View.Report
{
    partial class FDAsh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDAsh));
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnEnd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnSrc = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.lblKensu = new Isid.NJ.View.Widget.NJLabel();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.medMain = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.medMain_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txtYm = new Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl();
            this.lblYyyyMm = new Isid.NJ.View.Widget.NJLabel();
            this.btnXls = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnUpload = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
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
            this.btnSrc.Location = new System.Drawing.Point(142, 9);
            this.btnSrc.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseDownImage")));
            this.btnSrc.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseLeaveImage")));
            this.btnSrc.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnSrc.MouseMoveImage")));
            this.btnSrc.Name = "btnSrc";
            this.btnSrc.Size = new System.Drawing.Size(113, 22);
            this.btnSrc.TabIndex = 2;
            this.btnSrc.Text = "検索";
            this.btnSrc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSrc.UseVisualStyleBackColor = false;
            this.btnSrc.Click += new System.EventHandler(this.btnSrc_Click);
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
            this.medMain.AccessibleDescription = "medMain, Sheet1";
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
            this.medMain_Sheet1.ColumnCount = 11;
            this.medMain_Sheet1.RowCount = 0;
            this.medMain_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "番号";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "請求書番号";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "媒体コード（システム用）";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "媒体コード";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "請求金額";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "局コード";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "品種コード";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "代理店コード";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "番組コード";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "件名";
            this.medMain_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "請求日";
            this.medMain_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.medMain_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.medMain_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.medMain_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.medMain_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.medMain_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(0).Label = "番号";
            this.medMain_Sheet1.Columns.Get(0).Locked = true;
            this.medMain_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(0).Width = 40F;
            this.medMain_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(1).Label = "請求書番号";
            this.medMain_Sheet1.Columns.Get(1).Locked = true;
            this.medMain_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(1).Width = 96F;
            this.medMain_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(2).Label = "媒体コード（システム用）";
            this.medMain_Sheet1.Columns.Get(2).Locked = true;
            this.medMain_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(2).Visible = false;
            this.medMain_Sheet1.Columns.Get(2).Width = 64F;
            this.medMain_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(3).Label = "媒体コード";
            this.medMain_Sheet1.Columns.Get(3).Locked = true;
            this.medMain_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(3).Width = 64F;
            this.medMain_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.medMain_Sheet1.Columns.Get(4).Label = "請求金額";
            this.medMain_Sheet1.Columns.Get(4).Locked = true;
            this.medMain_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(4).Width = 100F;
            this.medMain_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(5).Label = "局コード";
            this.medMain_Sheet1.Columns.Get(5).Locked = true;
            this.medMain_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(6).Label = "品種コード";
            this.medMain_Sheet1.Columns.Get(6).Locked = true;
            this.medMain_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(6).Width = 65F;
            this.medMain_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(7).Label = "代理店コード";
            this.medMain_Sheet1.Columns.Get(7).Locked = true;
            this.medMain_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(7).Width = 75F;
            this.medMain_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(8).Label = "番組コード";
            this.medMain_Sheet1.Columns.Get(8).Locked = true;
            this.medMain_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(8).Width = 65F;
            this.medMain_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(9).Label = "件名";
            this.medMain_Sheet1.Columns.Get(9).Locked = true;
            this.medMain_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(9).Width = 250F;
            this.medMain_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.medMain_Sheet1.Columns.Get(10).Label = "請求日";
            this.medMain_Sheet1.Columns.Get(10).Locked = true;
            this.medMain_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.medMain_Sheet1.Columns.Get(10).Width = 90F;
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
            // txtYm
            // 
            this.txtYm.DisplayMode = Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.DisplayMode.COMBO;
            this.txtYm.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtYm.Location = new System.Drawing.Point(45, 11);
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
            this.lblYyyyMm.TabIndex = 32;
            this.lblYyyyMm.Text = "年月";
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
            this.btnXls.Location = new System.Drawing.Point(270, 9);
            this.btnXls.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseDownImage")));
            this.btnXls.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseLeaveImage")));
            this.btnXls.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnXls.MouseMoveImage")));
            this.btnXls.Name = "btnXls";
            this.btnXls.Size = new System.Drawing.Size(113, 22);
            this.btnXls.TabIndex = 33;
            this.btnXls.TabStop = false;
            this.btnXls.Text = "   csv出力";
            this.btnXls.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnXls.UseVisualStyleBackColor = false;
            this.btnXls.Click += new System.EventHandler(this.btnXls_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.Transparent;
            this.btnUpload.Enabled = false;
            this.btnUpload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload.Image")));
            this.btnUpload.Location = new System.Drawing.Point(398, 9);
            this.btnUpload.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnUpload.MouseDownImage")));
            this.btnUpload.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnUpload.MouseLeaveImage")));
            this.btnUpload.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnUpload.MouseMoveImage")));
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(113, 22);
            this.btnUpload.TabIndex = 35;
            this.btnUpload.Text = "    帳票出力";
            this.btnUpload.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // FDAsh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 668);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnXls);
            this.Controls.Add(this.lblYyyyMm);
            this.Controls.Add(this.txtYm);
            this.Controls.Add(this.medMain);
            this.Controls.Add(this.lblKensu);
            this.Controls.Add(this.btnSrc);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.btnEnd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 300);
            this.Name = "FDAsh";
            this.Text = "請求データ作成";
            this.Shown += new System.EventHandler(this.FDAsh_Shown);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.FDAsh_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.btnSrc, 0);
            this.Controls.SetChildIndex(this.lblKensu, 0);
            this.Controls.SetChildIndex(this.medMain, 0);
            this.Controls.SetChildIndex(this.txtYm, 0);
            this.Controls.SetChildIndex(this.lblYyyyMm, 0);
            this.Controls.SetChildIndex(this.btnXls, 0);
            this.Controls.SetChildIndex(this.btnUpload, 0);
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
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnSrc;
        protected Isid.NJ.View.Widget.NJLabel lblKensu;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread medMain;
        private FarPoint.Win.Spread.SheetView medMain_Sheet1;
        private Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.YmControl txtYm;
        private Isid.NJ.View.Widget.NJLabel lblYyyyMm;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnXls;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnUpload;
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
