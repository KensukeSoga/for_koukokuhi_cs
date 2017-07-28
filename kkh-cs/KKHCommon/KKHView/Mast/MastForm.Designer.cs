namespace Isid.KKH.Common.KKHView.Mast
{
    partial class MastForm
    {
        /// <summary>
        /// 必要なデザイナ変数です。        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。        /// </summary>
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
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を        /// コード エディタで変更しないでください。        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MastForm));
            this.btnCrt = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnDel = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnEnd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.cmbMasterName1 = new Isid.NJ.View.Widget.NJComboBox();
            this.label2 = new Isid.NJ.View.Widget.NJLabel();
            this.cmdMasterName2 = new Isid.NJ.View.Widget.NJComboBox();
            this.label1 = new Isid.NJ.View.Widget.NJLabel();
            this.btnRev = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnUpd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.spdMasMainte_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spdMasMainte = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.panel1 = new Isid.KKH.Common.KKHView.Common.Control.KkhPanel();
            this.Itemcmb = new Isid.KKH.Common.KKHView.Common.Control.KkhComboBox();
            this.RowUpBtn = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.RowDownBtn = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            ((System.ComponentModel.ISupportInitialize)(this.spdMasMainte_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMasMainte)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCrt
            // 
            this.btnCrt.BackColor = System.Drawing.Color.Transparent;
            this.btnCrt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCrt.FlatAppearance.BorderSize = 0;
            this.btnCrt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCrt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCrt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrt.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCrt.Image = ((System.Drawing.Image)(resources.GetObject("btnCrt.Image")));
            this.btnCrt.Location = new System.Drawing.Point(418, 7);
            this.btnCrt.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCrt.MouseDownImage")));
            this.btnCrt.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnCrt.MouseLeaveImage")));
            this.btnCrt.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCrt.MouseMoveImage")));
            this.btnCrt.Name = "btnCrt";
            this.btnCrt.Size = new System.Drawing.Size(113, 22);
            this.btnCrt.TabIndex = 4;
            this.btnCrt.TabStop = false;
            this.btnCrt.Text = "新規";
            this.btnCrt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCrt.UseVisualStyleBackColor = false;
            this.btnCrt.Click += new System.EventHandler(this.btnCrt_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.Transparent;
            this.btnDel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDel.FlatAppearance.BorderSize = 0;
            this.btnDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.Location = new System.Drawing.Point(537, 7);
            this.btnDel.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnDel.MouseDownImage")));
            this.btnDel.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnDel.MouseLeaveImage")));
            this.btnDel.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnDel.MouseMoveImage")));
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(113, 22);
            this.btnDel.TabIndex = 5;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "削除";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
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
            this.btnEnd.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEnd.Image")));
            this.btnEnd.Location = new System.Drawing.Point(950, 6);
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
            // btnHlp
            // 
            this.btnHlp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHlp.BackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHlp.FlatAppearance.BorderSize = 0;
            this.btnHlp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHlp.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnHlp.Image = ((System.Drawing.Image)(resources.GetObject("btnHlp.Image")));
            this.btnHlp.Location = new System.Drawing.Point(907, 6);
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
            // cmbMasterName1
            // 
            this.cmbMasterName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMasterName1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbMasterName1.FormattingEnabled = true;
            this.cmbMasterName1.Location = new System.Drawing.Point(98, 7);
            this.cmbMasterName1.Name = "cmbMasterName1";
            this.cmbMasterName1.Size = new System.Drawing.Size(188, 20);
            this.cmbMasterName1.TabIndex = 1;
            this.cmbMasterName1.SelectedIndexChanged += new System.EventHandler(this.cmbMasterName1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(5, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "マスター名";
            // 
            // cmdMasterName2
            // 
            this.cmdMasterName2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdMasterName2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdMasterName2.FormattingEnabled = true;
            this.cmdMasterName2.Location = new System.Drawing.Point(98, 38);
            this.cmdMasterName2.Name = "cmdMasterName2";
            this.cmdMasterName2.Size = new System.Drawing.Size(187, 20);
            this.cmdMasterName2.TabIndex = 9;
            this.cmdMasterName2.SelectedIndexChanged += new System.EventHandler(this.cmdMasterName2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(5, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "フィルタリング項目";
            // 
            // btnRev
            // 
            this.btnRev.BackColor = System.Drawing.Color.Transparent;
            this.btnRev.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRev.FlatAppearance.BorderSize = 0;
            this.btnRev.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRev.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRev.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnRev.Image = ((System.Drawing.Image)(resources.GetObject("btnRev.Image")));
            this.btnRev.Location = new System.Drawing.Point(299, 7);
            this.btnRev.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnRev.MouseDownImage")));
            this.btnRev.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnRev.MouseLeaveImage")));
            this.btnRev.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnRev.MouseMoveImage")));
            this.btnRev.Name = "btnRev";
            this.btnRev.Size = new System.Drawing.Size(113, 22);
            this.btnRev.TabIndex = 3;
            this.btnRev.TabStop = false;
            this.btnRev.Text = "再検索";
            this.btnRev.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRev.UseVisualStyleBackColor = false;
            this.btnRev.Click += new System.EventHandler(this.btnRev_Click);
            // 
            // btnUpd
            // 
            this.btnUpd.BackColor = System.Drawing.Color.Transparent;
            this.btnUpd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpd.FlatAppearance.BorderSize = 0;
            this.btnUpd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUpd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUpd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpd.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnUpd.Image = ((System.Drawing.Image)(resources.GetObject("btnUpd.Image")));
            this.btnUpd.Location = new System.Drawing.Point(656, 7);
            this.btnUpd.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnUpd.MouseDownImage")));
            this.btnUpd.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnUpd.MouseLeaveImage")));
            this.btnUpd.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnUpd.MouseMoveImage")));
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(113, 22);
            this.btnUpd.TabIndex = 6;
            this.btnUpd.TabStop = false;
            this.btnUpd.Text = "更新";
            this.btnUpd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpd.UseVisualStyleBackColor = false;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // spdMasMainte_Sheet1
            // 
            this.spdMasMainte_Sheet1.Reset();
            this.spdMasMainte_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdMasMainte_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdMasMainte_Sheet1.ColumnHeader.RowCount = 2;
            this.spdMasMainte_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.spdMasMainte_Sheet1.ColumnHeader.AutoFilterIndex = 1;
            this.spdMasMainte_Sheet1.ColumnHeader.AutoSortIndex = 1;
            this.spdMasMainte_Sheet1.ColumnHeader.AutoTextIndex = 0;
            this.spdMasMainte_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.spdMasMainte_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdMasMainte_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spdMasMainte_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdMasMainte_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdMasMainte_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdMasMainte_Sheet1.ColumnHeader.Rows.Get(0).Height = 24F;
            this.spdMasMainte_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.spdMasMainte_Sheet1.Columns.Get(0).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(0).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(1).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(1).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(2).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(3).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(3).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(4).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(4).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(5).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(5).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(6).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(6).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(7).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(7).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(8).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(8).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(9).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(9).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(10).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(10).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(11).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(11).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(12).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(12).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(13).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(13).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(14).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(14).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(15).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(15).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(16).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(16).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(17).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(17).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(18).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(18).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(19).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(19).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(20).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(20).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(21).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(21).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(22).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(22).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(23).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(23).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(24).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(24).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(25).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(25).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(26).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(26).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(27).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(27).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(28).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(28).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(29).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(29).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(30).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(30).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(31).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(31).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(32).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(32).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(33).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(33).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(34).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(34).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(35).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(35).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(36).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(36).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(37).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(37).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(38).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(38).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(39).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(39).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(40).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(40).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(41).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(41).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(42).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(42).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(43).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(43).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(44).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(44).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(45).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(45).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(46).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(46).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(47).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(47).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(48).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(48).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(49).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(49).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(50).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(50).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(51).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(51).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(52).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(52).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(53).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(53).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(54).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(54).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(55).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(55).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(56).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(56).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(57).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(57).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(58).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(58).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(59).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(59).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(60).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(60).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(61).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(61).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(62).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(62).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(63).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(63).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(64).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(64).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(65).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(65).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(66).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(66).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(67).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(67).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(68).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(68).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(69).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(69).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(70).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(70).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(71).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(71).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(72).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(72).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(73).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(73).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(74).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(74).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(75).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(75).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(76).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(76).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(77).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(77).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(78).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(78).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(79).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(79).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.Columns.Get(80).AllowAutoFilter = true;
            this.spdMasMainte_Sheet1.Columns.Get(80).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.DataAutoSizeColumns = false;
            this.spdMasMainte_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMasMainte_Sheet1.Protect = false;
            this.spdMasMainte_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdMasMainte_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdMasMainte_Sheet1.RowHeader.Columns.Get(0).AllowAutoSort = true;
            this.spdMasMainte_Sheet1.RowHeader.Columns.Get(0).Width = 51F;
            this.spdMasMainte_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spdMasMainte_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdMasMainte_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdMasMainte_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdMasMainte_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spdMasMainte_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdMasMainte_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdMasMainte_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spdMasMainte
            // 
            this.spdMasMainte.AccessibleDescription = "spdMasMainte, Sheet1, Row 0, Column 0, ";
            this.spdMasMainte.AllowCellOverflow = true;
            this.spdMasMainte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spdMasMainte.BackColor = System.Drawing.SystemColors.Control;
            this.spdMasMainte.EnableCustomSorting = true;
            this.spdMasMainte.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.spdMasMainte.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdMasMainte.Location = new System.Drawing.Point(5, 3);
            this.spdMasMainte.Name = "spdMasMainte";
            this.spdMasMainte.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdMasMainte.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdMasMainte_Sheet1});
            this.spdMasMainte.Size = new System.Drawing.Size(943, 570);
            this.spdMasMainte.TabIndex = 10;
            this.spdMasMainte.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdMasMainte.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdMasMainte_EditChange);
            this.spdMasMainte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spdMasMainte_KeyDown);
            this.spdMasMainte.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.spdMasMainte_Change);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.spdMasMainte);
            this.panel1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel1.Location = new System.Drawing.Point(7, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 576);
            this.panel1.TabIndex = 31;
            // 
            // Itemcmb
            // 
            this.Itemcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Itemcmb.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Itemcmb.FormattingEnabled = true;
            this.Itemcmb.Location = new System.Drawing.Point(98, 38);
            this.Itemcmb.Name = "Itemcmb";
            this.Itemcmb.Size = new System.Drawing.Size(188, 20);
            this.Itemcmb.TabIndex = 2;
            this.Itemcmb.Visible = false;
            this.Itemcmb.SelectedIndexChanged += new System.EventHandler(this.Itemcmb_SelectedIndexChanged);
            // 
            // RowUpBtn
            // 
            this.RowUpBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RowUpBtn.Location = new System.Drawing.Point(961, 165);
            this.RowUpBtn.MouseDownImage = null;
            this.RowUpBtn.MouseLeaveImage = null;
            this.RowUpBtn.MouseMoveImage = null;
            this.RowUpBtn.Name = "RowUpBtn";
            this.RowUpBtn.Size = new System.Drawing.Size(26, 94);
            this.RowUpBtn.TabIndex = 9;
            this.RowUpBtn.Text = "▲";
            this.RowUpBtn.UseVisualStyleBackColor = true;
            this.RowUpBtn.Click += new System.EventHandler(this.RowUpBtn_Click);
            // 
            // RowDownBtn
            // 
            this.RowDownBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RowDownBtn.Location = new System.Drawing.Point(961, 412);
            this.RowDownBtn.MouseDownImage = null;
            this.RowDownBtn.MouseLeaveImage = null;
            this.RowDownBtn.MouseMoveImage = null;
            this.RowDownBtn.Name = "RowDownBtn";
            this.RowDownBtn.Size = new System.Drawing.Size(26, 94);
            this.RowDownBtn.TabIndex = 10;
            this.RowDownBtn.Text = "▼";
            this.RowDownBtn.UseVisualStyleBackColor = true;
            this.RowDownBtn.Click += new System.EventHandler(this.RowDownBtn_Click);
            // 
            // MastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 666);
            this.Controls.Add(this.RowDownBtn);
            this.Controls.Add(this.RowUpBtn);
            this.Controls.Add(this.Itemcmb);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmdMasterName2);
            this.Controls.Add(this.btnCrt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMasterName1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnHlp);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnRev);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "MastForm";
            this.Text = "マスターメンテナンス";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.MastForm_Shown);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.MastForm_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.btnRev, 0);
            this.Controls.SetChildIndex(this.btnDel, 0);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cmbMasterName1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnCrt, 0);
            this.Controls.SetChildIndex(this.cmdMasterName2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnUpd, 0);
            this.Controls.SetChildIndex(this.Itemcmb, 0);
            this.Controls.SetChildIndex(this.RowUpBtn, 0);
            this.Controls.SetChildIndex(this.RowDownBtn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.spdMasMainte_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMasMainte)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnUpd;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnCrt;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnDel;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHlp;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnRev;
        protected Isid.NJ.View.Widget.NJComboBox cmbMasterName1;
        protected Isid.NJ.View.Widget.NJComboBox cmdMasterName2;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhSpread spdMasMainte;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhPanel panel1;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnEnd;
        protected Isid.NJ.View.Widget.NJLabel label2;
        protected Isid.NJ.View.Widget.NJLabel label1;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhComboBox Itemcmb;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton RowUpBtn;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton RowDownBtn;
        protected FarPoint.Win.Spread.SheetView spdMasMainte_Sheet1;

    }
}