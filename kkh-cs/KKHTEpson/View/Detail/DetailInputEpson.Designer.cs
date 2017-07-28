namespace Isid.KKH.Epson.View.Detail
{
    partial class DetailInputEpson
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailInputEpson));
            this.btnCancel = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.cmbTriTnt = new Isid.NJ.View.Widget.NJComboBox();
            this.txtSeikyuNo1 = new Isid.NJ.View.Widget.NJTextBox();
            this.lblSeikyuNo = new Isid.NJ.View.Widget.NJLabel();
            this._bsDetailInput = new System.Windows.Forms.BindingSource(this.components);
            this._dsDetailEpson = new Isid.KKH.Epson.Schema.DetailDSEpson();
            this.txtSeikyuNo2 = new Isid.NJ.View.Widget.NJTextBox();
            this.btnOk = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.lblUriMeiNo = new Isid.NJ.View.Widget.NJLabel();
            this.txtUriMeiNo = new Isid.NJ.View.Widget.NJTextBox();
            this.lblKoukokuKenmei = new Isid.NJ.View.Widget.NJLabel();
            this.txtKoukokuKenmei = new Isid.NJ.View.Widget.NJTextBox();
            this.lblKenmei = new Isid.NJ.View.Widget.NJLabel();
            this.txtKenmei = new Isid.NJ.View.Widget.NJTextBox();
            this.lblBfKngk = new Isid.NJ.View.Widget.NJLabel();
            this.lblAfKngk = new Isid.NJ.View.Widget.NJLabel();
            this.lblSyouhizei = new Isid.NJ.View.Widget.NJLabel();
            this.cmbTriSiki = new Isid.NJ.View.Widget.NJComboBox();
            this.lblTriTnt = new Isid.NJ.View.Widget.NJLabel();
            this.lblTriSiki = new Isid.NJ.View.Widget.NJLabel();
            this.lblSeikyuNoHyphen = new Isid.NJ.View.Widget.NJLabel();
            this.lblKeizyouBi = new Isid.NJ.View.Widget.NJLabel();
            this.lblSeikyuFlg = new Isid.NJ.View.Widget.NJLabel();
            this.txtBfKngk = new Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox();
            this.txtAfKngk = new Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox();
            this.txtSyouhizei = new Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox();
            this.dtpKeizyouBi = new Isid.NJ.View.Widget.NJDateTimePicker();
            this.txtSeiKingaku = new Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox();
            this.lblSeiKingaku = new Isid.NJ.View.Widget.NJLabel();
            this.txtZeiNKingaku = new Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox();
            this.lblZeiNKingaku = new Isid.NJ.View.Widget.NJLabel();
            this.lblSeiKenmei = new Isid.NJ.View.Widget.NJLabel();
            this.txtSeiKenmei = new Isid.NJ.View.Widget.NJTextBox();
            this.lblKihyouBmnCd = new Isid.NJ.View.Widget.NJLabel();
            this.cmbKihyouBmnCd = new Isid.NJ.View.Widget.NJComboBox();
            this.cmbGenkaCenter = new Isid.NJ.View.Widget.NJComboBox();
            this.lblGenkaCenter = new Isid.NJ.View.Widget.NJLabel();
            this.chkSeikyuFlg = new Isid.NJ.View.Widget.NJCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeikyuNo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsDetailInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dsDetailEpson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeikyuNo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUriMeiNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKoukokuKenmei)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKenmei)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBfKngk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAfKngk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSyouhizei)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeiKingaku)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZeiNKingaku)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeiKenmei)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(226, 409);
            this.btnCancel.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseDownImage")));
            this.btnCancel.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseLeaveImage")));
            this.btnCancel.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.MouseMoveImage")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 22);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbTriTnt
            // 
            this.cmbTriTnt.BackColor = System.Drawing.SystemColors.Window;
            this.cmbTriTnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTriTnt.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbTriTnt.FormattingEnabled = true;
            this.cmbTriTnt.Location = new System.Drawing.Point(87, 81);
            this.cmbTriTnt.Name = "cmbTriTnt";
            this.cmbTriTnt.Size = new System.Drawing.Size(146, 20);
            this.cmbTriTnt.TabIndex = 1;
            this.cmbTriTnt.SelectedIndexChanged += new System.EventHandler(this.cmbTriTnt_SelectedIndexChanged);
            // 
            // txtSeikyuNo1
            // 
            this.txtSeikyuNo1.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtSeikyuNo1.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSeikyuNo1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSeikyuNo1.Location = new System.Drawing.Point(87, 6);
            this.txtSeikyuNo1.MaxLength = 15;
            this.txtSeikyuNo1.Name = "txtSeikyuNo1";
            this.txtSeikyuNo1.ReadOnly = true;
            this.txtSeikyuNo1.Size = new System.Drawing.Size(146, 19);
            this.txtSeikyuNo1.TabIndex = 33;
            this.txtSeikyuNo1.TabStop = false;
            // 
            // lblSeikyuNo
            // 
            this.lblSeikyuNo.AutoSize = true;
            this.lblSeikyuNo.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSeikyuNo.Location = new System.Drawing.Point(12, 9);
            this.lblSeikyuNo.Name = "lblSeikyuNo";
            this.lblSeikyuNo.Size = new System.Drawing.Size(53, 12);
            this.lblSeikyuNo.TabIndex = 35;
            this.lblSeikyuNo.Text = "請求番号";
            // 
            // _bsDetailInput
            // 
            this._bsDetailInput.DataMember = "KkhDetailInput";
            this._bsDetailInput.DataSource = this._dsDetailEpson;
            // 
            // _dsDetailEpson
            // 
            this._dsDetailEpson.DataSetName = "DetailDSAsh";
            this._dsDetailEpson.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtSeikyuNo2
            // 
            this.txtSeikyuNo2.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtSeikyuNo2.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSeikyuNo2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSeikyuNo2.Location = new System.Drawing.Point(256, 6);
            this.txtSeikyuNo2.MaxLength = 13;
            this.txtSeikyuNo2.Name = "txtSeikyuNo2";
            this.txtSeikyuNo2.ReadOnly = true;
            this.txtSeikyuNo2.Size = new System.Drawing.Size(83, 19);
            this.txtSeikyuNo2.TabIndex = 44;
            this.txtSeikyuNo2.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(105, 409);
            this.btnOk.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseDownImage")));
            this.btnOk.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseLeaveImage")));
            this.btnOk.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnOk.MouseMoveImage")));
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(113, 22);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblUriMeiNo
            // 
            this.lblUriMeiNo.AutoSize = true;
            this.lblUriMeiNo.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUriMeiNo.Location = new System.Drawing.Point(12, 34);
            this.lblUriMeiNo.Name = "lblUriMeiNo";
            this.lblUriMeiNo.Size = new System.Drawing.Size(69, 12);
            this.lblUriMeiNo.TabIndex = 47;
            this.lblUriMeiNo.Text = "売上明細NO";
            // 
            // txtUriMeiNo
            // 
            this.txtUriMeiNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtUriMeiNo.BeforeBackColor = System.Drawing.SystemColors.Control;
            this.txtUriMeiNo.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUriMeiNo.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtUriMeiNo.Location = new System.Drawing.Point(87, 31);
            this.txtUriMeiNo.MaxLength = 18;
            this.txtUriMeiNo.Name = "txtUriMeiNo";
            this.txtUriMeiNo.ReadOnly = true;
            this.txtUriMeiNo.Size = new System.Drawing.Size(180, 19);
            this.txtUriMeiNo.TabIndex = 46;
            this.txtUriMeiNo.TabStop = false;
            // 
            // lblKoukokuKenmei
            // 
            this.lblKoukokuKenmei.AutoSize = true;
            this.lblKoukokuKenmei.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblKoukokuKenmei.Location = new System.Drawing.Point(12, 59);
            this.lblKoukokuKenmei.Name = "lblKoukokuKenmei";
            this.lblKoukokuKenmei.Size = new System.Drawing.Size(53, 12);
            this.lblKoukokuKenmei.TabIndex = 49;
            this.lblKoukokuKenmei.Text = "広告件名";
            // 
            // txtKoukokuKenmei
            // 
            this.txtKoukokuKenmei.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtKoukokuKenmei.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtKoukokuKenmei.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtKoukokuKenmei.Location = new System.Drawing.Point(87, 56);
            this.txtKoukokuKenmei.MaxLength = 60;
            this.txtKoukokuKenmei.Name = "txtKoukokuKenmei";
            this.txtKoukokuKenmei.Size = new System.Drawing.Size(237, 19);
            this.txtKoukokuKenmei.TabIndex = 0;
            this.txtKoukokuKenmei.TextChanged += new System.EventHandler(this.txtKoukokuKenmei_TextChanged);
            // 
            // lblKenmei
            // 
            this.lblKenmei.AutoSize = true;
            this.lblKenmei.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblKenmei.Location = new System.Drawing.Point(12, 110);
            this.lblKenmei.Name = "lblKenmei";
            this.lblKenmei.Size = new System.Drawing.Size(29, 12);
            this.lblKenmei.TabIndex = 51;
            this.lblKenmei.Text = "件名";
            // 
            // txtKenmei
            // 
            this.txtKenmei.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtKenmei.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtKenmei.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtKenmei.Location = new System.Drawing.Point(87, 107);
            this.txtKenmei.MaxLength = 120;
            this.txtKenmei.Name = "txtKenmei";
            this.txtKenmei.Size = new System.Drawing.Size(237, 19);
            this.txtKenmei.TabIndex = 2;
            this.txtKenmei.TextChanged += new System.EventHandler(this.txtKenmei_TextChanged);
            // 
            // lblBfKngk
            // 
            this.lblBfKngk.AutoSize = true;
            this.lblBfKngk.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblBfKngk.Location = new System.Drawing.Point(12, 238);
            this.lblBfKngk.Name = "lblBfKngk";
            this.lblBfKngk.Size = new System.Drawing.Size(53, 12);
            this.lblBfKngk.TabIndex = 53;
            this.lblBfKngk.Text = "事前金額";
            // 
            // lblAfKngk
            // 
            this.lblAfKngk.AutoSize = true;
            this.lblAfKngk.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblAfKngk.Location = new System.Drawing.Point(12, 263);
            this.lblAfKngk.Name = "lblAfKngk";
            this.lblAfKngk.Size = new System.Drawing.Size(53, 12);
            this.lblAfKngk.TabIndex = 55;
            this.lblAfKngk.Text = "事後金額";
            // 
            // lblSyouhizei
            // 
            this.lblSyouhizei.AutoSize = true;
            this.lblSyouhizei.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSyouhizei.Location = new System.Drawing.Point(12, 313);
            this.lblSyouhizei.Name = "lblSyouhizei";
            this.lblSyouhizei.Size = new System.Drawing.Size(29, 12);
            this.lblSyouhizei.TabIndex = 57;
            this.lblSyouhizei.Text = "税額";
            // 
            // cmbTriSiki
            // 
            this.cmbTriSiki.BackColor = System.Drawing.SystemColors.Window;
            this.cmbTriSiki.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTriSiki.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbTriSiki.FormattingEnabled = true;
            this.cmbTriSiki.Location = new System.Drawing.Point(87, 157);
            this.cmbTriSiki.Name = "cmbTriSiki";
            this.cmbTriSiki.Size = new System.Drawing.Size(237, 20);
            this.cmbTriSiki.TabIndex = 3;
            this.cmbTriSiki.SelectedIndexChanged += new System.EventHandler(this.cmbTriSiki_SelectedIndexChanged);
            // 
            // lblTriTnt
            // 
            this.lblTriTnt.AutoSize = true;
            this.lblTriTnt.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTriTnt.Location = new System.Drawing.Point(12, 84);
            this.lblTriTnt.Name = "lblTriTnt";
            this.lblTriTnt.Size = new System.Drawing.Size(38, 12);
            this.lblTriTnt.TabIndex = 59;
            this.lblTriTnt.Text = "ご担当";
            // 
            // lblTriSiki
            // 
            this.lblTriSiki.AutoSize = true;
            this.lblTriSiki.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTriSiki.Location = new System.Drawing.Point(12, 160);
            this.lblTriSiki.Name = "lblTriSiki";
            this.lblTriSiki.Size = new System.Drawing.Size(65, 12);
            this.lblTriSiki.TabIndex = 60;
            this.lblTriSiki.Text = "取引識別名";
            // 
            // lblSeikyuNoHyphen
            // 
            this.lblSeikyuNoHyphen.AutoSize = true;
            this.lblSeikyuNoHyphen.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSeikyuNoHyphen.Location = new System.Drawing.Point(239, 9);
            this.lblSeikyuNoHyphen.Name = "lblSeikyuNoHyphen";
            this.lblSeikyuNoHyphen.Size = new System.Drawing.Size(11, 12);
            this.lblSeikyuNoHyphen.TabIndex = 61;
            this.lblSeikyuNoHyphen.Text = "-";
            // 
            // lblKeizyouBi
            // 
            this.lblKeizyouBi.AutoSize = true;
            this.lblKeizyouBi.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblKeizyouBi.Location = new System.Drawing.Point(12, 361);
            this.lblKeizyouBi.Name = "lblKeizyouBi";
            this.lblKeizyouBi.Size = new System.Drawing.Size(41, 12);
            this.lblKeizyouBi.TabIndex = 63;
            this.lblKeizyouBi.Text = "計上日";
            // 
            // lblSeikyuFlg
            // 
            this.lblSeikyuFlg.AutoSize = true;
            this.lblSeikyuFlg.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSeikyuFlg.Location = new System.Drawing.Point(12, 383);
            this.lblSeikyuFlg.Name = "lblSeikyuFlg";
            this.lblSeikyuFlg.Size = new System.Drawing.Size(65, 12);
            this.lblSeikyuFlg.TabIndex = 64;
            this.lblSeikyuFlg.Text = "請求対象外";
            // 
            // txtBfKngk
            // 
            this.txtBfKngk.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtBfKngk.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBfKngk.DecimalPlaces = 0;
            this.txtBfKngk.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtBfKngk.Location = new System.Drawing.Point(87, 235);
            this.txtBfKngk.Mask = "###,###,###,##0";
            this.txtBfKngk.Name = "txtBfKngk";
            this.txtBfKngk.SignificantFigure = 11;
            this.txtBfKngk.Size = new System.Drawing.Size(146, 19);
            this.txtBfKngk.TabIndex = 4;
            this.txtBfKngk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAfKngk
            // 
            this.txtAfKngk.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtAfKngk.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAfKngk.DecimalPlaces = 0;
            this.txtAfKngk.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtAfKngk.Location = new System.Drawing.Point(87, 260);
            this.txtAfKngk.Mask = "###,###,###,##0";
            this.txtAfKngk.Name = "txtAfKngk";
            this.txtAfKngk.SignificantFigure = 11;
            this.txtAfKngk.Size = new System.Drawing.Size(146, 19);
            this.txtAfKngk.TabIndex = 5;
            this.txtAfKngk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSyouhizei
            // 
            this.txtSyouhizei.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtSyouhizei.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSyouhizei.DecimalPlaces = 0;
            this.txtSyouhizei.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSyouhizei.Location = new System.Drawing.Point(87, 310);
            this.txtSyouhizei.Mask = "###,###,###,##0";
            this.txtSyouhizei.Name = "txtSyouhizei";
            this.txtSyouhizei.SignificantFigure = 11;
            this.txtSyouhizei.Size = new System.Drawing.Size(146, 19);
            this.txtSyouhizei.TabIndex = 6;
            this.txtSyouhizei.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSyouhizei.TextChanged += new System.EventHandler(this.txtSyouhizei_TextChanged);
            // 
            // dtpKeizyouBi
            // 
            this.dtpKeizyouBi.CustomFormat = "";
            this.dtpKeizyouBi.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpKeizyouBi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpKeizyouBi.Location = new System.Drawing.Point(87, 356);
            this.dtpKeizyouBi.Name = "dtpKeizyouBi";
            this.dtpKeizyouBi.Size = new System.Drawing.Size(93, 19);
            this.dtpKeizyouBi.TabIndex = 7;
            // 
            // txtSeiKingaku
            // 
            this.txtSeiKingaku.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtSeiKingaku.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSeiKingaku.DecimalPlaces = 0;
            this.txtSeiKingaku.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSeiKingaku.Location = new System.Drawing.Point(87, 285);
            this.txtSeiKingaku.Mask = "###,###,###,##0";
            this.txtSeiKingaku.Name = "txtSeiKingaku";
            this.txtSeiKingaku.SignificantFigure = 11;
            this.txtSeiKingaku.Size = new System.Drawing.Size(146, 19);
            this.txtSeiKingaku.TabIndex = 65;
            this.txtSeiKingaku.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSeiKingaku.TextChanged += new System.EventHandler(this.txtSeiKingaku_TextChanged);
            // 
            // lblSeiKingaku
            // 
            this.lblSeiKingaku.AutoSize = true;
            this.lblSeiKingaku.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSeiKingaku.Location = new System.Drawing.Point(12, 288);
            this.lblSeiKingaku.Name = "lblSeiKingaku";
            this.lblSeiKingaku.Size = new System.Drawing.Size(76, 12);
            this.lblSeiKingaku.TabIndex = 66;
            this.lblSeiKingaku.Text = "金額（税込み）";
            // 
            // txtZeiNKingaku
            // 
            this.txtZeiNKingaku.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtZeiNKingaku.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtZeiNKingaku.DecimalPlaces = 0;
            this.txtZeiNKingaku.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtZeiNKingaku.Location = new System.Drawing.Point(87, 335);
            this.txtZeiNKingaku.Mask = "###,###,###,##0";
            this.txtZeiNKingaku.Name = "txtZeiNKingaku";
            this.txtZeiNKingaku.SignificantFigure = 11;
            this.txtZeiNKingaku.Size = new System.Drawing.Size(146, 19);
            this.txtZeiNKingaku.TabIndex = 67;
            this.txtZeiNKingaku.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblZeiNKingaku
            // 
            this.lblZeiNKingaku.AutoSize = true;
            this.lblZeiNKingaku.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblZeiNKingaku.Location = new System.Drawing.Point(12, 338);
            this.lblZeiNKingaku.Name = "lblZeiNKingaku";
            this.lblZeiNKingaku.Size = new System.Drawing.Size(62, 12);
            this.lblZeiNKingaku.TabIndex = 68;
            this.lblZeiNKingaku.Text = "税抜き金額";
            // 
            // lblSeiKenmei
            // 
            this.lblSeiKenmei.AutoSize = true;
            this.lblSeiKenmei.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSeiKenmei.Location = new System.Drawing.Point(12, 135);
            this.lblSeiKenmei.Name = "lblSeiKenmei";
            this.lblSeiKenmei.Size = new System.Drawing.Size(53, 12);
            this.lblSeiKenmei.TabIndex = 70;
            this.lblSeiKenmei.Text = "請求件名";
            // 
            // txtSeiKenmei
            // 
            this.txtSeiKenmei.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.txtSeiKenmei.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSeiKenmei.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSeiKenmei.Location = new System.Drawing.Point(87, 132);
            this.txtSeiKenmei.MaxLength = 120;
            this.txtSeiKenmei.Name = "txtSeiKenmei";
            this.txtSeiKenmei.Size = new System.Drawing.Size(237, 19);
            this.txtSeiKenmei.TabIndex = 69;
            // 
            // lblKihyouBmnCd
            // 
            this.lblKihyouBmnCd.AutoSize = true;
            this.lblKihyouBmnCd.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblKihyouBmnCd.Location = new System.Drawing.Point(12, 186);
            this.lblKihyouBmnCd.Name = "lblKihyouBmnCd";
            this.lblKihyouBmnCd.Size = new System.Drawing.Size(69, 12);
            this.lblKihyouBmnCd.TabIndex = 73;
            this.lblKihyouBmnCd.Text = "起票部門CD";
            // 
            // cmbKihyouBmnCd
            // 
            this.cmbKihyouBmnCd.BackColor = System.Drawing.SystemColors.Window;
            this.cmbKihyouBmnCd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKihyouBmnCd.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbKihyouBmnCd.FormattingEnabled = true;
            this.cmbKihyouBmnCd.Location = new System.Drawing.Point(87, 183);
            this.cmbKihyouBmnCd.Name = "cmbKihyouBmnCd";
            this.cmbKihyouBmnCd.Size = new System.Drawing.Size(237, 20);
            this.cmbKihyouBmnCd.TabIndex = 74;
            // 
            // cmbGenkaCenter
            // 
            this.cmbGenkaCenter.BackColor = System.Drawing.SystemColors.Window;
            this.cmbGenkaCenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenkaCenter.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbGenkaCenter.FormattingEnabled = true;
            this.cmbGenkaCenter.Location = new System.Drawing.Point(87, 209);
            this.cmbGenkaCenter.Name = "cmbGenkaCenter";
            this.cmbGenkaCenter.Size = new System.Drawing.Size(237, 20);
            this.cmbGenkaCenter.TabIndex = 74;
            // 
            // lblGenkaCenter
            // 
            this.lblGenkaCenter.AutoSize = true;
            this.lblGenkaCenter.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblGenkaCenter.Location = new System.Drawing.Point(12, 212);
            this.lblGenkaCenter.Name = "lblGenkaCenter";
            this.lblGenkaCenter.Size = new System.Drawing.Size(56, 12);
            this.lblGenkaCenter.TabIndex = 75;
            this.lblGenkaCenter.Text = "原価センタ";
            // 
            // chkSeikyuFlg
            // 
            this.chkSeikyuFlg.AutoSize = true;
            this.chkSeikyuFlg.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkSeikyuFlg.Location = new System.Drawing.Point(87, 383);
            this.chkSeikyuFlg.Name = "chkSeikyuFlg";
            this.chkSeikyuFlg.Size = new System.Drawing.Size(15, 14);
            this.chkSeikyuFlg.TabIndex = 76;
            this.chkSeikyuFlg.UseVisualStyleBackColor = true;
            // 
            // DetailInputEpson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 443);
            this.Controls.Add(this.chkSeikyuFlg);
            this.Controls.Add(this.lblGenkaCenter);
            this.Controls.Add(this.cmbGenkaCenter);
            this.Controls.Add(this.cmbKihyouBmnCd);
            this.Controls.Add(this.lblKihyouBmnCd);
            this.Controls.Add(this.lblSeiKenmei);
            this.Controls.Add(this.txtSeiKenmei);
            this.Controls.Add(this.txtZeiNKingaku);
            this.Controls.Add(this.lblZeiNKingaku);
            this.Controls.Add(this.txtSeiKingaku);
            this.Controls.Add(this.lblSeiKingaku);
            this.Controls.Add(this.dtpKeizyouBi);
            this.Controls.Add(this.txtSyouhizei);
            this.Controls.Add(this.txtAfKngk);
            this.Controls.Add(this.txtBfKngk);
            this.Controls.Add(this.lblSeikyuFlg);
            this.Controls.Add(this.lblKeizyouBi);
            this.Controls.Add(this.lblSeikyuNoHyphen);
            this.Controls.Add(this.lblTriSiki);
            this.Controls.Add(this.lblTriTnt);
            this.Controls.Add(this.cmbTriSiki);
            this.Controls.Add(this.lblSyouhizei);
            this.Controls.Add(this.lblAfKngk);
            this.Controls.Add(this.lblBfKngk);
            this.Controls.Add(this.lblKenmei);
            this.Controls.Add(this.txtKenmei);
            this.Controls.Add(this.lblKoukokuKenmei);
            this.Controls.Add(this.txtKoukokuKenmei);
            this.Controls.Add(this.lblUriMeiNo);
            this.Controls.Add(this.txtUriMeiNo);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtSeikyuNo2);
            this.Controls.Add(this.lblSeikyuNo);
            this.Controls.Add(this.txtSeikyuNo1);
            this.Controls.Add(this.cmbTriTnt);
            this.Controls.Add(this.btnCancel);
            this.Name = "DetailInputEpson";
            this.Text = "明細入力";
            this.Load += new System.EventHandler(this.DetailInputEpson_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.DetailInputEpson_ProcessAffterNavigating);
            ((System.ComponentModel.ISupportInitialize)(this.txtSeikyuNo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsDetailInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dsDetailEpson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeikyuNo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUriMeiNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKoukokuKenmei)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKenmei)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBfKngk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAfKngk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSyouhizei)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeiKingaku)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZeiNKingaku)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeiKenmei)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnCancel;
        protected Isid.NJ.View.Widget.NJComboBox cmbTriTnt;
        protected Isid.NJ.View.Widget.NJTextBox txtSeikyuNo1;
        protected Isid.NJ.View.Widget.NJLabel lblSeikyuNo;
        private Isid.KKH.Epson.Schema.DetailDSEpson _dsDetailEpson;
        private System.Windows.Forms.BindingSource _bsDetailInput;
        protected Isid.NJ.View.Widget.NJTextBox txtSeikyuNo2;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnOk;
        protected Isid.NJ.View.Widget.NJLabel lblUriMeiNo;
        protected Isid.NJ.View.Widget.NJTextBox txtUriMeiNo;
        protected Isid.NJ.View.Widget.NJLabel lblKoukokuKenmei;
        protected Isid.NJ.View.Widget.NJTextBox txtKoukokuKenmei;
        protected Isid.NJ.View.Widget.NJLabel lblKenmei;
        protected Isid.NJ.View.Widget.NJTextBox txtKenmei;
        protected Isid.NJ.View.Widget.NJLabel lblBfKngk;
        protected Isid.NJ.View.Widget.NJLabel lblAfKngk;
        protected Isid.NJ.View.Widget.NJLabel lblSyouhizei;
        protected Isid.NJ.View.Widget.NJComboBox cmbTriSiki;
        protected Isid.NJ.View.Widget.NJLabel lblTriTnt;
        protected Isid.NJ.View.Widget.NJLabel lblTriSiki;
        protected Isid.NJ.View.Widget.NJLabel lblSeikyuNoHyphen;
        protected Isid.NJ.View.Widget.NJLabel lblKeizyouBi;
        protected Isid.NJ.View.Widget.NJLabel lblSeikyuFlg;
        private Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox txtBfKngk;
        private Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox txtAfKngk;
        private Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox txtSyouhizei;
        private Isid.NJ.View.Widget.NJDateTimePicker dtpKeizyouBi;
        private Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox txtSeiKingaku;
        protected Isid.NJ.View.Widget.NJLabel lblSeiKingaku;
        private Isid.KKH.Common.KKHView.Common.Control.KkhNumericTextBox txtZeiNKingaku;
        protected Isid.NJ.View.Widget.NJLabel lblZeiNKingaku;
        protected Isid.NJ.View.Widget.NJLabel lblSeiKenmei;
        protected Isid.NJ.View.Widget.NJTextBox txtSeiKenmei;
        protected Isid.NJ.View.Widget.NJLabel lblKihyouBmnCd;
        protected Isid.NJ.View.Widget.NJComboBox cmbKihyouBmnCd;
        protected Isid.NJ.View.Widget.NJComboBox cmbGenkaCenter;
        protected Isid.NJ.View.Widget.NJLabel lblGenkaCenter;
        protected Isid.NJ.View.Widget.NJCheckBox chkSeikyuFlg;
    }
}