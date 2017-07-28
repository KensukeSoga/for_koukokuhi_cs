namespace Isid.KKH.Uni.View.Detail
{
    partial class DetailHosoBiUni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailHosoBiUni));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpHosoBi = new System.Windows.Forms.GroupBox();
            this.lblHosoBi = new Isid.NJ.View.Widget.NJLabel();
            this.btnClear = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnCancel = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.grpHosoBi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpHosoBi
            // 
            this.grpHosoBi.Controls.Add(this.lblHosoBi);
            this.grpHosoBi.Controls.Add(this.btnClear);
            this.grpHosoBi.Controls.Add(this.dataGridView1);
            this.grpHosoBi.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpHosoBi.Location = new System.Drawing.Point(12, 12);
            this.grpHosoBi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpHosoBi.Name = "grpHosoBi";
            this.grpHosoBi.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpHosoBi.Size = new System.Drawing.Size(261, 233);
            this.grpHosoBi.TabIndex = 0;
            this.grpHosoBi.TabStop = false;
            this.grpHosoBi.Text = "放送日";
            // 
            // lblHosoBi
            // 
            this.lblHosoBi.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHosoBi.Location = new System.Drawing.Point(9, 17);
            this.lblHosoBi.Name = "lblHosoBi";
            this.lblHosoBi.Size = new System.Drawing.Size(247, 24);
            this.lblHosoBi.TabIndex = 4;
            this.lblHosoBi.Text = "9999/99";
            this.lblHosoBi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(141, 202);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnClear.MouseDownImage")));
            this.btnClear.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnClear.MouseLeaveImage")));
            this.btnClear.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnClear.MouseMoveImage")));
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(113, 22);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataGridView1.Location = new System.Drawing.Point(6, 44);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(248, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseMove);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // Column1
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column1.HeaderText = "1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 35;
            // 
            // Column2
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column2.HeaderText = "2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 35;
            // 
            // Column3
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column3.HeaderText = "3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.Width = 35;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 35;
            // 
            // Column5
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column5.HeaderText = "5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.Width = 35;
            // 
            // Column6
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle11;
            this.Column6.HeaderText = "6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column6.Width = 35;
            // 
            // Column7
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle12;
            this.Column7.HeaderText = "7";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column7.Width = 35;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(36, 253);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseDownImage")));
            this.btnOK.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseLeaveImage")));
            this.btnOK.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnOK.MouseMoveImage")));
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 22);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(155, 253);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseDownImage")));
            this.btnCancel.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseLeaveImage")));
            this.btnCancel.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseMoveImage")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 22);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "   キャンセル";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DetailHosoBiUni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 289);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpHosoBi);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DetailHosoBiUni";
            this.Text = "放送日選択";
            this.Load += new System.EventHandler(this.DetailHosoBiUni_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.DetailHosoBiUni_ProcessAffterNavigating);
            this.grpHosoBi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpHosoBi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnOK;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnCancel;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnClear;
        private Isid.NJ.View.Widget.NJLabel lblHosoBi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}