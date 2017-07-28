namespace Isid.KKH.Uni.View.Top
{
    partial class frmTopMenuUni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTopMenuUni));
            this.btnChohyo = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.grpInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDetails
            // 
            this.btnDetails.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDetails.FlatAppearance.BorderSize = 0;
            this.btnDetails.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDetails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.njToolTip1.SetToolTip(this.btnDetails, "明細画面を表示します");
            // 
            // btnAccount
            // 
            this.njToolTip1.SetToolTip(this.btnAccount, "帳票画面を表示します");
            this.btnAccount.Visible = false;
            // 
            // grpInformation
            // 
            this.grpInformation.Location = new System.Drawing.Point(8, 486);
            this.grpInformation.Size = new System.Drawing.Size(574, 188);
            // 
            // txtInformation
            // 
            this.txtInformation.Location = new System.Drawing.Point(10, 18);
            this.txtInformation.Size = new System.Drawing.Size(555, 162);
            // 
            // btnHistoryDownLoad
            // 
            this.btnHistoryDownLoad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHistoryDownLoad.FlatAppearance.BorderSize = 0;
            this.btnHistoryDownLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHistoryDownLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.njToolTip1.SetToolTip(this.btnHistoryDownLoad, "請求原票取込履歴画面を表示します");
            this.btnHistoryDownLoad.Visible = false;
            // 
            // btnHlp
            // 
            this.btnHlp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHlp.FlatAppearance.BorderSize = 0;
            this.btnHlp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.njToolTip1.SetToolTip(this.btnHlp, "ヘルプを表示します");
            // 
            // btnEnd
            // 
            this.btnEnd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEnd.FlatAppearance.BorderSize = 0;
            this.btnEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.njToolTip1.SetToolTip(this.btnEnd, "広告費明細システムを終了します");
            // 
            // btnMasterMaintenance
            // 
            this.btnMasterMaintenance.ButtonCount = 2;
            this.btnMasterMaintenance.ButtonValue = new string[] {
        "TVタイム　月額番組料金",
        "部署マスター"};
            this.btnMasterMaintenance.ChildButtonText = new string[] {
        "TVタイム月額番組料金",
        "部署マスター"};
            this.btnMasterMaintenance.ColumnCount = 2;
            this.btnMasterMaintenance.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.njToolTip1.SetToolTip(this.btnMasterMaintenance, "マスタメンテナンス画面を表示します");
            this.btnMasterMaintenance.Visible = false;
            this.btnMasterMaintenance.PopupButtonClick += new Isid.KKH.Common.KKHView.Common.Control.MenuButton.PopupButtonClickEventHandler(this.btnMasterMaintenance_PopupButtonClick);
            // 
            // btnChohyo
            // 
            this.btnChohyo.BackColor = System.Drawing.Color.Transparent;
            this.btnChohyo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnChohyo.FlatAppearance.BorderSize = 0;
            this.btnChohyo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnChohyo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnChohyo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChohyo.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnChohyo.Image = ((System.Drawing.Image)(resources.GetObject("btnChohyo.Image")));
            this.btnChohyo.Location = new System.Drawing.Point(211, 147);
            this.btnChohyo.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnChohyo.MouseDownImage")));
            this.btnChohyo.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnChohyo.MouseLeaveImage")));
            this.btnChohyo.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnChohyo.MouseMoveImage")));
            this.btnChohyo.Name = "btnChohyo";
            this.btnChohyo.Size = new System.Drawing.Size(182, 52);
            this.btnChohyo.TabIndex = 48;
            this.btnChohyo.TabStop = false;
            this.btnChohyo.Text = "  帳票";
            this.njToolTip1.SetToolTip(this.btnChohyo, "帳票画面を表示します");
            this.btnChohyo.UseVisualStyleBackColor = false;
            this.btnChohyo.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnChohyo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnChohyo.Click += new System.EventHandler(this.btnChohyo_Click);
            // 
            // frmTopMenuUni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.btnAccountVisble = true;
            this.btnDetailsVisble = true;
            this.btnMasterMaintenanceVisble = true;
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.Controls.Add(this.btnChohyo);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 12.5F);
            this.grpInformationVisble = true;
            this.Name = "frmTopMenuUni";
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.frmTopMenuUni_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.btnDetails, 0);
            this.Controls.SetChildIndex(this.btnAccount, 0);
            this.Controls.SetChildIndex(this.grpInformation, 0);
            this.Controls.SetChildIndex(this.btnHistoryDownLoad, 0);
            this.Controls.SetChildIndex(this.btnMasterMaintenance, 0);
            this.Controls.SetChildIndex(this.btnChohyo, 0);
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnChohyo;


    }
}

