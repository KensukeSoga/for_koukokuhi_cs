namespace Isid.KKH.Common.KKHView.Top
{
    partial class TopMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopMenuForm));
            this.btnHlp = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnEnd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.label3 = new Isid.NJ.View.Widget.NJLabel();
            this.lblTksNm = new Isid.NJ.View.Widget.NJLabel();
            this.btnDetails = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnAccount = new Isid.KKH.Common.KKHView.Common.Control.MenuButton.KkhMenuButton();
            this.grpInformation = new System.Windows.Forms.GroupBox();
            this.txtInformation = new Isid.NJ.View.Widget.NJTextBox();
            this.btnHistoryDownLoad = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.njToolTip1 = new Isid.NJ.View.Widget.NJToolTip();
            this.btnMasterMaintenance = new Isid.KKH.Common.KKHView.Common.Control.MenuButton.KkhMenuButton();
            this.grpInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHlp
            // 
            this.btnHlp.BackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHlp.FlatAppearance.BorderSize = 0;
            this.btnHlp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHlp.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnHlp.Image = ((System.Drawing.Image)(resources.GetObject("btnHlp.Image")));
            this.btnHlp.Location = new System.Drawing.Point(499, 4);
            this.btnHlp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHlp.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseDownImage")));
            this.btnHlp.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseLeaveImage")));
            this.btnHlp.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseMoveImage")));
            this.btnHlp.Name = "btnHlp";
            this.btnHlp.Size = new System.Drawing.Size(37, 37);
            this.btnHlp.TabIndex = 4;
            this.btnHlp.TabStop = false;
            this.btnHlp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnHlp, "ヘルプを表示します");
            this.btnHlp.UseVisualStyleBackColor = false;
            this.btnHlp.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnHlp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnHlp.Click += new System.EventHandler(this.btnHlp_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEnd.FlatAppearance.BorderSize = 0;
            this.btnEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnd.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEnd.Image")));
            this.btnEnd.Location = new System.Drawing.Point(544, 4);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnd.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseDownImage")));
            this.btnEnd.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseLeaveImage")));
            this.btnEnd.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseMoveImage")));
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(37, 37);
            this.btnEnd.TabIndex = 5;
            this.btnEnd.TabStop = false;
            this.btnEnd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnEnd, "広告費明細システムを終了します");
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnEnd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(17, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "新広告費明細システム";
            // 
            // lblTksNm
            // 
            this.lblTksNm.AutoSize = true;
            this.lblTksNm.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTksNm.ForeColor = System.Drawing.Color.Blue;
            this.lblTksNm.Location = new System.Drawing.Point(20, 80);
            this.lblTksNm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTksNm.Name = "lblTksNm";
            this.lblTksNm.Size = new System.Drawing.Size(93, 16);
            this.lblTksNm.TabIndex = 36;
            this.lblTksNm.Text = "得意先名称";
            // 
            // btnDetails
            // 
            this.btnDetails.BackColor = System.Drawing.Color.Transparent;
            this.btnDetails.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDetails.FlatAppearance.BorderSize = 0;
            this.btnDetails.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDetails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnDetails.Image")));
            this.btnDetails.Location = new System.Drawing.Point(23, 147);
            this.btnDetails.Margin = new System.Windows.Forms.Padding(4);
            this.btnDetails.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnDetails.MouseDownImage")));
            this.btnDetails.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnDetails.MouseLeaveImage")));
            this.btnDetails.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnDetails.MouseMoveImage")));
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(182, 52);
            this.btnDetails.TabIndex = 1;
            this.btnDetails.TabStop = false;
            this.btnDetails.Text = "  明細";
            this.njToolTip1.SetToolTip(this.btnDetails, "明細画面を表示します");
            this.btnDetails.UseVisualStyleBackColor = false;
            this.btnDetails.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnDetails.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnAccount.ButtonBackColor = System.Drawing.Color.Transparent;
            this.btnAccount.ButtonCount = 0;
            this.btnAccount.ButtonMouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnAccount.ButtonMouseDownImage")));
            this.btnAccount.ButtonMouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnAccount.ButtonMouseLeaveImage")));
            this.btnAccount.ButtonMouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnAccount.ButtonMouseMoveImage")));
            this.btnAccount.ButtonText = "帳票       ▼";
            this.btnAccount.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccount.ButtonValue = null;
            this.btnAccount.ChildButtonText = null;
            this.btnAccount.ColumnCount = 0;
            this.btnAccount.DropDownAlign = Isid.KKH.Common.KKHView.Common.Control.MenuButton.KkhMenuButton.DropDownAlignValue.Center;
            this.btnAccount.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnAccount.Location = new System.Drawing.Point(211, 147);
            this.btnAccount.Margin = new System.Windows.Forms.Padding(4);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(182, 52);
            this.btnAccount.TabIndex = 2;
            this.btnAccount.TabStop = false;
            this.njToolTip1.SetToolTip(this.btnAccount, "帳票画面を表示します");
            this.btnAccount.ToolTipText = "帳票画面を表示します";
            this.btnAccount.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            this.btnAccount.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            // 
            // grpInformation
            // 
            this.grpInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInformation.Controls.Add(this.txtInformation);
            this.grpInformation.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grpInformation.Location = new System.Drawing.Point(20, 477);
            this.grpInformation.Margin = new System.Windows.Forms.Padding(4);
            this.grpInformation.Name = "grpInformation";
            this.grpInformation.Padding = new System.Windows.Forms.Padding(4);
            this.grpInformation.Size = new System.Drawing.Size(565, 188);
            this.grpInformation.TabIndex = 44;
            this.grpInformation.TabStop = false;
            this.grpInformation.Text = "< お知らせ >";
            // 
            // txtInformation
            // 
            this.txtInformation.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtInformation.BackColor = System.Drawing.Color.White;
            this.txtInformation.BeforeForeColor = System.Drawing.SystemColors.WindowText;
            this.txtInformation.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInformation.Location = new System.Drawing.Point(11, 18);
            this.txtInformation.Margin = new System.Windows.Forms.Padding(4);
            this.txtInformation.Multiline = true;
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.ReadOnly = true;
            this.txtInformation.Size = new System.Drawing.Size(547, 162);
            this.txtInformation.TabIndex = 0;
            this.txtInformation.TabStop = false;
            // 
            // btnHistoryDownLoad
            // 
            this.btnHistoryDownLoad.BackColor = System.Drawing.Color.Transparent;
            this.btnHistoryDownLoad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHistoryDownLoad.FlatAppearance.BorderSize = 0;
            this.btnHistoryDownLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHistoryDownLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHistoryDownLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistoryDownLoad.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnHistoryDownLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnHistoryDownLoad.Image")));
            this.btnHistoryDownLoad.Location = new System.Drawing.Point(23, 235);
            this.btnHistoryDownLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnHistoryDownLoad.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHistoryDownLoad.MouseDownImage")));
            this.btnHistoryDownLoad.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHistoryDownLoad.MouseLeaveImage")));
            this.btnHistoryDownLoad.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHistoryDownLoad.MouseMoveImage")));
            this.btnHistoryDownLoad.Name = "btnHistoryDownLoad";
            this.btnHistoryDownLoad.Size = new System.Drawing.Size(182, 52);
            this.btnHistoryDownLoad.TabIndex = 45;
            this.btnHistoryDownLoad.TabStop = false;
            this.btnHistoryDownLoad.Text = "  請求原票\r\n  取込履歴";
            this.njToolTip1.SetToolTip(this.btnHistoryDownLoad, "請求原票取込履歴画面を表示します");
            this.btnHistoryDownLoad.UseVisualStyleBackColor = false;
            this.btnHistoryDownLoad.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnHistoryDownLoad.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnHistoryDownLoad.Click += new System.EventHandler(this.btnHistoryDownLoad_Click);
            // 
            // njToolTip1
            // 
            this.njToolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // btnMasterMaintenance
            // 
            this.btnMasterMaintenance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMasterMaintenance.ButtonBackColor = System.Drawing.Color.Transparent;
            this.btnMasterMaintenance.ButtonCount = 0;
            this.btnMasterMaintenance.ButtonMouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnMasterMaintenance.ButtonMouseDownImage")));
            this.btnMasterMaintenance.ButtonMouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnMasterMaintenance.ButtonMouseLeaveImage")));
            this.btnMasterMaintenance.ButtonMouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnMasterMaintenance.ButtonMouseMoveImage")));
            this.btnMasterMaintenance.ButtonText = "マスター     ▼";
            this.btnMasterMaintenance.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMasterMaintenance.ButtonValue = new string[0];
            this.btnMasterMaintenance.ChildButtonText = null;
            this.btnMasterMaintenance.ColumnCount = 0;
            this.btnMasterMaintenance.DropDownAlign = Isid.KKH.Common.KKHView.Common.Control.MenuButton.KkhMenuButton.DropDownAlignValue.Right;
            this.btnMasterMaintenance.Location = new System.Drawing.Point(400, 147);
            this.btnMasterMaintenance.Name = "btnMasterMaintenance";
            this.btnMasterMaintenance.Size = new System.Drawing.Size(182, 52);
            this.btnMasterMaintenance.TabIndex = 46;
            this.btnMasterMaintenance.TabStop = false;
            this.btnMasterMaintenance.ToolTipText = "マスタメンテナンス画面を表示します";
            this.btnMasterMaintenance.Click += new System.EventHandler(this.btnMasterMaintenance_Click);
            // 
            // TopMenuForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.Controls.Add(this.btnMasterMaintenance);
            this.Controls.Add(this.btnHistoryDownLoad);
            this.Controls.Add(this.grpInformation);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.lblTksNm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnHlp);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 700);
            this.Name = "TopMenuForm";
            this.Text = "トップメニュー";
            this.Load += new System.EventHandler(this.TopMenuForm_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.TopMenuForm_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblTksNm, 0);
            this.Controls.SetChildIndex(this.btnDetails, 0);
            this.Controls.SetChildIndex(this.btnAccount, 0);
            this.Controls.SetChildIndex(this.grpInformation, 0);
            this.Controls.SetChildIndex(this.btnHistoryDownLoad, 0);
            this.Controls.SetChildIndex(this.btnMasterMaintenance, 0);
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.NJ.View.Widget.NJLabel label3;
        private Isid.NJ.View.Widget.NJLabel lblTksNm;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnDetails;
        protected Isid.KKH.Common.KKHView.Common.Control.MenuButton.KkhMenuButton btnAccount;
        protected internal System.Windows.Forms.GroupBox grpInformation;
        protected Isid.NJ.View.Widget.NJTextBox txtInformation;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHistoryDownLoad;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnHlp;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnEnd;
        protected Isid.NJ.View.Widget.NJToolTip njToolTip1;
        protected Isid.KKH.Common.KKHView.Common.Control.MenuButton.KkhMenuButton btnMasterMaintenance;
    }
}