namespace Isid.KKH.Mac.View.Mast
{
    partial class frmMastMacNarrowDown
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMastMacNarrowDown));
            this.tnCdPanel = new Isid.KKH.Common.KKHView.Common.Control.KkhPanel();
            this.betweenLabel = new Isid.NJ.View.Widget.NJLabel();
            this.tenCd2Txt = new Isid.NJ.View.Widget.NJTextBox();
            this.tenCdTxt = new Isid.NJ.View.Widget.NJTextBox();
            this.cmbCd = new Isid.NJ.View.Widget.NJComboBox();
            this.territoryPanel = new Isid.KKH.Common.KKHView.Common.Control.KkhPanel();
            this.chkTerSonota = new Isid.NJ.View.Widget.NJCheckBox();
            this.chkTyuo = new Isid.NJ.View.Widget.NJCheckBox();
            this.chkKansai = new Isid.NJ.View.Widget.NJCheckBox();
            this.chkKanto = new Isid.NJ.View.Widget.NJCheckBox();
            this.tenNamePanel = new Isid.KKH.Common.KKHView.Common.Control.KkhPanel();
            this.njLabel7 = new Isid.NJ.View.Widget.NJLabel();
            this.tenNmTxt = new Isid.NJ.View.Widget.NJTextBox();
            this.tenCbnPanel = new Isid.KKH.Common.KKHView.Common.Control.KkhPanel();
            this.chkKbnSonota = new Isid.NJ.View.Widget.NJCheckBox();
            this.chkLicensee = new Isid.NJ.View.Widget.NJCheckBox();
            this.chkMc = new Isid.NJ.View.Widget.NJCheckBox();
            this.chkTikuhonbu = new Isid.NJ.View.Widget.NJCheckBox();
            this.Okbtn = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.Cancelbtn = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.label2 = new Isid.NJ.View.Widget.NJLabel();
            this.njLabel1 = new Isid.NJ.View.Widget.NJLabel();
            this.njLabel2 = new Isid.NJ.View.Widget.NJLabel();
            this.njLabel3 = new Isid.NJ.View.Widget.NJLabel();
            this.tnCdPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tenCd2Txt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tenCdTxt)).BeginInit();
            this.territoryPanel.SuspendLayout();
            this.tenNamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tenNmTxt)).BeginInit();
            this.tenCbnPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tnCdPanel
            // 
            this.tnCdPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tnCdPanel.Controls.Add(this.betweenLabel);
            this.tnCdPanel.Controls.Add(this.tenCd2Txt);
            this.tnCdPanel.Controls.Add(this.tenCdTxt);
            this.tnCdPanel.Controls.Add(this.cmbCd);
            this.tnCdPanel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tnCdPanel.Location = new System.Drawing.Point(12, 12);
            this.tnCdPanel.Name = "tnCdPanel";
            this.tnCdPanel.Size = new System.Drawing.Size(203, 110);
            this.tnCdPanel.TabIndex = 0;
            // 
            // betweenLabel
            // 
            this.betweenLabel.AutoSize = true;
            this.betweenLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.betweenLabel.Location = new System.Drawing.Point(99, 71);
            this.betweenLabel.Name = "betweenLabel";
            this.betweenLabel.Size = new System.Drawing.Size(29, 12);
            this.betweenLabel.TabIndex = 23;
            this.betweenLabel.Text = "の間";
            this.betweenLabel.Visible = false;
            // 
            // tenCd2Txt
            // 
            this.tenCd2Txt.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.tenCd2Txt.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.tenCd2Txt.Location = new System.Drawing.Point(5, 65);
            this.tenCd2Txt.MaxLength = 6;
            this.tenCd2Txt.Name = "tenCd2Txt";
            this.tenCd2Txt.Size = new System.Drawing.Size(84, 19);
            this.tenCd2Txt.TabIndex = 4;
            this.tenCd2Txt.Visible = false;
            // 
            // tenCdTxt
            // 
            this.tenCdTxt.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.tenCdTxt.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.tenCdTxt.Location = new System.Drawing.Point(5, 33);
            this.tenCdTxt.MaxLength = 6;
            this.tenCdTxt.Name = "tenCdTxt";
            this.tenCdTxt.Size = new System.Drawing.Size(84, 19);
            this.tenCdTxt.TabIndex = 3;
            // 
            // cmbCd
            // 
            this.cmbCd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbCd.FormattingEnabled = true;
            this.cmbCd.Items.AddRange(new object[] {
            "",
            "と完全に一致",
            "以上",
            "以下",
            "～"});
            this.cmbCd.Location = new System.Drawing.Point(95, 33);
            this.cmbCd.Name = "cmbCd";
            this.cmbCd.Size = new System.Drawing.Size(96, 20);
            this.cmbCd.TabIndex = 2;
            this.cmbCd.SelectedIndexChanged += new System.EventHandler(this.cmbCd_SelectedIndexChanged);
            // 
            // territoryPanel
            // 
            this.territoryPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.territoryPanel.Controls.Add(this.chkTerSonota);
            this.territoryPanel.Controls.Add(this.chkTyuo);
            this.territoryPanel.Controls.Add(this.chkKansai);
            this.territoryPanel.Controls.Add(this.chkKanto);
            this.territoryPanel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.territoryPanel.Location = new System.Drawing.Point(221, 12);
            this.territoryPanel.Name = "territoryPanel";
            this.territoryPanel.Size = new System.Drawing.Size(143, 110);
            this.territoryPanel.TabIndex = 1;
            // 
            // chkTerSonota
            // 
            this.chkTerSonota.Checked = true;
            this.chkTerSonota.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTerSonota.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTerSonota.Location = new System.Drawing.Point(10, 83);
            this.chkTerSonota.Name = "chkTerSonota";
            this.chkTerSonota.Size = new System.Drawing.Size(60, 20);
            this.chkTerSonota.TabIndex = 26;
            this.chkTerSonota.Text = "その他";
            this.chkTerSonota.UseVisualStyleBackColor = true;
            this.chkTerSonota.CheckedChanged += new System.EventHandler(this.chkteri_CheckedChanged);
            // 
            // chkTyuo
            // 
            this.chkTyuo.Checked = true;
            this.chkTyuo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTyuo.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTyuo.Location = new System.Drawing.Point(10, 59);
            this.chkTyuo.Name = "chkTyuo";
            this.chkTyuo.Size = new System.Drawing.Size(60, 20);
            this.chkTyuo.TabIndex = 25;
            this.chkTyuo.Text = "中央";
            this.chkTyuo.UseVisualStyleBackColor = true;
            this.chkTyuo.CheckedChanged += new System.EventHandler(this.chkteri_CheckedChanged);
            // 
            // chkKansai
            // 
            this.chkKansai.Checked = true;
            this.chkKansai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKansai.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKansai.Location = new System.Drawing.Point(10, 36);
            this.chkKansai.Name = "chkKansai";
            this.chkKansai.Size = new System.Drawing.Size(60, 20);
            this.chkKansai.TabIndex = 24;
            this.chkKansai.Text = "関西";
            this.chkKansai.UseVisualStyleBackColor = true;
            this.chkKansai.CheckedChanged += new System.EventHandler(this.chkteri_CheckedChanged);
            // 
            // chkKanto
            // 
            this.chkKanto.Checked = true;
            this.chkKanto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKanto.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKanto.Location = new System.Drawing.Point(10, 13);
            this.chkKanto.Name = "chkKanto";
            this.chkKanto.Size = new System.Drawing.Size(60, 20);
            this.chkKanto.TabIndex = 23;
            this.chkKanto.Text = "関東";
            this.chkKanto.UseVisualStyleBackColor = true;
            this.chkKanto.CheckedChanged += new System.EventHandler(this.chkteri_CheckedChanged);
            // 
            // tenNamePanel
            // 
            this.tenNamePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tenNamePanel.Controls.Add(this.njLabel7);
            this.tenNamePanel.Controls.Add(this.tenNmTxt);
            this.tenNamePanel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tenNamePanel.Location = new System.Drawing.Point(12, 134);
            this.tenNamePanel.Name = "tenNamePanel";
            this.tenNamePanel.Size = new System.Drawing.Size(203, 110);
            this.tenNamePanel.TabIndex = 2;
            // 
            // njLabel7
            // 
            this.njLabel7.AutoSize = true;
            this.njLabel7.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.njLabel7.Location = new System.Drawing.Point(145, 57);
            this.njLabel7.Name = "njLabel7";
            this.njLabel7.Size = new System.Drawing.Size(36, 12);
            this.njLabel7.TabIndex = 37;
            this.njLabel7.Text = "を含む";
            // 
            // tenNmTxt
            // 
            this.tenNmTxt.BeforeBackColor = System.Drawing.SystemColors.Window;
            this.tenNmTxt.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.tenNmTxt.Location = new System.Drawing.Point(5, 30);
            this.tenNmTxt.MaxLength = 6;
            this.tenNmTxt.Name = "tenNmTxt";
            this.tenNmTxt.Size = new System.Drawing.Size(186, 19);
            this.tenNmTxt.TabIndex = 2;
            // 
            // tenCbnPanel
            // 
            this.tenCbnPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tenCbnPanel.Controls.Add(this.chkKbnSonota);
            this.tenCbnPanel.Controls.Add(this.chkLicensee);
            this.tenCbnPanel.Controls.Add(this.chkMc);
            this.tenCbnPanel.Controls.Add(this.chkTikuhonbu);
            this.tenCbnPanel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tenCbnPanel.Location = new System.Drawing.Point(221, 134);
            this.tenCbnPanel.Name = "tenCbnPanel";
            this.tenCbnPanel.Size = new System.Drawing.Size(143, 110);
            this.tenCbnPanel.TabIndex = 3;
            // 
            // chkKbnSonota
            // 
            this.chkKbnSonota.Checked = true;
            this.chkKbnSonota.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKbnSonota.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKbnSonota.Location = new System.Drawing.Point(10, 83);
            this.chkKbnSonota.Name = "chkKbnSonota";
            this.chkKbnSonota.Size = new System.Drawing.Size(77, 20);
            this.chkKbnSonota.TabIndex = 30;
            this.chkKbnSonota.Text = "その他";
            this.chkKbnSonota.UseVisualStyleBackColor = true;
            this.chkKbnSonota.CheckedChanged += new System.EventHandler(this.chkTenKbn_CheckedChanged);
            // 
            // chkLicensee
            // 
            this.chkLicensee.Checked = true;
            this.chkLicensee.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLicensee.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLicensee.Location = new System.Drawing.Point(10, 59);
            this.chkLicensee.Name = "chkLicensee";
            this.chkLicensee.Size = new System.Drawing.Size(107, 20);
            this.chkLicensee.TabIndex = 29;
            this.chkLicensee.Text = "ライセンシー";
            this.chkLicensee.UseVisualStyleBackColor = true;
            this.chkLicensee.CheckedChanged += new System.EventHandler(this.chkTenKbn_CheckedChanged);
            // 
            // chkMc
            // 
            this.chkMc.Checked = true;
            this.chkMc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMc.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMc.Location = new System.Drawing.Point(10, 36);
            this.chkMc.Name = "chkMc";
            this.chkMc.Size = new System.Drawing.Size(77, 20);
            this.chkMc.TabIndex = 28;
            this.chkMc.Text = "MC直営店";
            this.chkMc.UseVisualStyleBackColor = true;
            this.chkMc.CheckedChanged += new System.EventHandler(this.chkTenKbn_CheckedChanged);
            // 
            // chkTikuhonbu
            // 
            this.chkTikuhonbu.Checked = true;
            this.chkTikuhonbu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTikuhonbu.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTikuhonbu.Location = new System.Drawing.Point(10, 13);
            this.chkTikuhonbu.Name = "chkTikuhonbu";
            this.chkTikuhonbu.Size = new System.Drawing.Size(77, 20);
            this.chkTikuhonbu.TabIndex = 27;
            this.chkTikuhonbu.Text = "地区本部";
            this.chkTikuhonbu.UseVisualStyleBackColor = true;
            this.chkTikuhonbu.CheckedChanged += new System.EventHandler(this.chkTenKbn_CheckedChanged);
            // 
            // Okbtn
            // 
            this.Okbtn.BackColor = System.Drawing.Color.Transparent;
            this.Okbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Okbtn.FlatAppearance.BorderSize = 0;
            this.Okbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Okbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Okbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Okbtn.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Okbtn.Image = ((System.Drawing.Image)(resources.GetObject("Okbtn.Image")));
            this.Okbtn.Location = new System.Drawing.Point(72, 259);
            this.Okbtn.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("Okbtn.MouseDownImage")));
            this.Okbtn.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("Okbtn.MouseLeaveImage")));
            this.Okbtn.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("Okbtn.MouseMoveImage")));
            this.Okbtn.Name = "Okbtn";
            this.Okbtn.Size = new System.Drawing.Size(113, 22);
            this.Okbtn.TabIndex = 4;
            this.Okbtn.Text = "OK";
            this.Okbtn.UseVisualStyleBackColor = false;
            this.Okbtn.Click += new System.EventHandler(this.Okbtn_Click);
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.BackColor = System.Drawing.Color.Transparent;
            this.Cancelbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Cancelbtn.FlatAppearance.BorderSize = 0;
            this.Cancelbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Cancelbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancelbtn.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancelbtn.Image = ((System.Drawing.Image)(resources.GetObject("Cancelbtn.Image")));
            this.Cancelbtn.Location = new System.Drawing.Point(197, 259);
            this.Cancelbtn.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("Cancelbtn.MouseDownImage")));
            this.Cancelbtn.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("Cancelbtn.MouseLeaveImage")));
            this.Cancelbtn.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("Cancelbtn.MouseMoveImage")));
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(113, 22);
            this.Cancelbtn.TabIndex = 5;
            this.Cancelbtn.Text = "   キャンセル";
            this.Cancelbtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Cancelbtn.UseVisualStyleBackColor = false;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(17, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "店舗コード";
            // 
            // njLabel1
            // 
            this.njLabel1.AutoSize = true;
            this.njLabel1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.njLabel1.Location = new System.Drawing.Point(19, 129);
            this.njLabel1.Name = "njLabel1";
            this.njLabel1.Size = new System.Drawing.Size(41, 12);
            this.njLabel1.TabIndex = 20;
            this.njLabel1.Text = "店舗名";
            // 
            // njLabel2
            // 
            this.njLabel2.AutoSize = true;
            this.njLabel2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.njLabel2.Location = new System.Drawing.Point(224, 7);
            this.njLabel2.Name = "njLabel2";
            this.njLabel2.Size = new System.Drawing.Size(46, 12);
            this.njLabel2.TabIndex = 21;
            this.njLabel2.Text = "テリトリー";
            // 
            // njLabel3
            // 
            this.njLabel3.AutoSize = true;
            this.njLabel3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njLabel3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.njLabel3.Location = new System.Drawing.Point(224, 129);
            this.njLabel3.Name = "njLabel3";
            this.njLabel3.Size = new System.Drawing.Size(53, 12);
            this.njLabel3.TabIndex = 22;
            this.njLabel3.Text = "店舗区分";
            // 
            // frmMastMacNarrowDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.ClientSize = new System.Drawing.Size(374, 294);
            this.Controls.Add(this.njLabel3);
            this.Controls.Add(this.njLabel2);
            this.Controls.Add(this.njLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.Okbtn);
            this.Controls.Add(this.tenCbnPanel);
            this.Controls.Add(this.tenNamePanel);
            this.Controls.Add(this.territoryPanel);
            this.Controls.Add(this.tnCdPanel);
            this.Name = "frmMastMacNarrowDown";
            this.Text = "店舗絞込";
            this.Load += new System.EventHandler(this.frmMastMacNarrowDown_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.frmMastMacNarrowDown_ProcessAffterNavigating);
            this.tnCdPanel.ResumeLayout(false);
            this.tnCdPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tenCd2Txt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tenCdTxt)).EndInit();
            this.territoryPanel.ResumeLayout(false);
            this.tenNamePanel.ResumeLayout(false);
            this.tenNamePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tenNmTxt)).EndInit();
            this.tenCbnPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.KKH.Common.KKHView.Common.Control.KkhPanel tnCdPanel;
        private Isid.KKH.Common.KKHView.Common.Control.KkhPanel territoryPanel;
        private Isid.KKH.Common.KKHView.Common.Control.KkhPanel tenNamePanel;
        private Isid.KKH.Common.KKHView.Common.Control.KkhPanel tenCbnPanel;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton Okbtn;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton Cancelbtn;
        protected Isid.NJ.View.Widget.NJComboBox cmbCd;
        protected Isid.NJ.View.Widget.NJLabel label2;
        protected Isid.NJ.View.Widget.NJLabel njLabel1;
        protected Isid.NJ.View.Widget.NJLabel njLabel2;
        protected Isid.NJ.View.Widget.NJLabel njLabel3;
        private Isid.NJ.View.Widget.NJCheckBox chkKanto;
        private Isid.NJ.View.Widget.NJCheckBox chkTerSonota;
        private Isid.NJ.View.Widget.NJCheckBox chkTyuo;
        private Isid.NJ.View.Widget.NJCheckBox chkKansai;
        private Isid.NJ.View.Widget.NJCheckBox chkMc;
        private Isid.NJ.View.Widget.NJCheckBox chkTikuhonbu;
        private Isid.NJ.View.Widget.NJCheckBox chkKbnSonota;
        private Isid.NJ.View.Widget.NJCheckBox chkLicensee;
        private Isid.NJ.View.Widget.NJTextBox tenCdTxt;
        private Isid.NJ.View.Widget.NJTextBox tenNmTxt;
        protected Isid.NJ.View.Widget.NJLabel njLabel7;
        protected Isid.NJ.View.Widget.NJLabel betweenLabel;
        private Isid.NJ.View.Widget.NJTextBox tenCd2Txt;
    }
}
