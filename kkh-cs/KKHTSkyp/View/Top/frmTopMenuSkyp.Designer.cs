namespace Isid.KKH.Skyp.View.Top
{
    partial class frmTopMenuSkyp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTopMenuSkyp));
            this.btnChohyo = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnMast = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
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
            this.btnAccount.ButtonText = "　　　納品／請求書▼";
            this.njToolTip1.SetToolTip(this.btnAccount, "帳票を作成します");
            this.btnAccount.ToolTipText = "";
            this.btnAccount.Visible = false;
            // 
            // grpInformation
            // 
            this.grpInformation.Location = new System.Drawing.Point(13, 486);
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
            this.btnHistoryDownLoad.Location = new System.Drawing.Point(23, 226);
            this.njToolTip1.SetToolTip(this.btnHistoryDownLoad, "請求原票取込履歴画面を表示します");
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
            this.njToolTip1.SetToolTip(this.btnMasterMaintenance, "各マスターの登録・更新画面です");
            this.btnMasterMaintenance.ToolTipText = "";
            this.btnMasterMaintenance.Visible = false;
            // 
            // btnChohyo
            // 
            this.btnChohyo.BackColor = System.Drawing.Color.Transparent;
            this.btnChohyo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnChohyo.FlatAppearance.BorderSize = 0;
            this.btnChohyo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnChohyo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnChohyo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChohyo.Image = ((System.Drawing.Image)(resources.GetObject("btnChohyo.Image")));
            this.btnChohyo.Location = new System.Drawing.Point(211, 147);
            this.btnChohyo.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnChohyo.MouseDownImage")));
            this.btnChohyo.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnChohyo.MouseLeaveImage")));
            this.btnChohyo.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnChohyo.MouseMoveImage")));
            this.btnChohyo.Name = "btnChohyo";
            this.btnChohyo.Size = new System.Drawing.Size(182, 52);
            this.btnChohyo.TabIndex = 47;
            this.btnChohyo.TabStop = false;
            this.btnChohyo.Text = "　　　納品／請求書";
            this.njToolTip1.SetToolTip(this.btnChohyo, "帳票を作成します");
            this.btnChohyo.UseVisualStyleBackColor = false;
            this.btnChohyo.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnChohyo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnChohyo.Click += new System.EventHandler(this.btnChohyo_Click);
            // 
            // btnMast
            // 
            this.btnMast.BackColor = System.Drawing.Color.Transparent;
            this.btnMast.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMast.FlatAppearance.BorderSize = 0;
            this.btnMast.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMast.Image = ((System.Drawing.Image)(resources.GetObject("btnMast.Image")));
            this.btnMast.Location = new System.Drawing.Point(399, 147);
            this.btnMast.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnMast.MouseDownImage")));
            this.btnMast.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnMast.MouseLeaveImage")));
            this.btnMast.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnMast.MouseMoveImage")));
            this.btnMast.Name = "btnMast";
            this.btnMast.Size = new System.Drawing.Size(182, 52);
            this.btnMast.TabIndex = 48;
            this.btnMast.TabStop = false;
            this.btnMast.Text = "  マスター";
            this.njToolTip1.SetToolTip(this.btnMast, "各マスターの登録・更新画面です");
            this.btnMast.UseVisualStyleBackColor = false;
            this.btnMast.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnMast.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnMast.Click += new System.EventHandler(this.btnMast_Click);
            // 
            // frmTopMenuSkyp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.btnAccountVisble = true;
            this.btnDetailsVisble = true;
            this.btnMasterMaintenanceVisble = true;
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.Controls.Add(this.btnMast);
            this.Controls.Add(this.btnChohyo);
            this.grpInformationVisble = true;
            this.Name = "frmTopMenuSkyp";
            this.Load += new System.EventHandler(this.frmTopMenuSkyp_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.frmTopMenuSkyp_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.btnAccount, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.btnDetails, 0);
            this.Controls.SetChildIndex(this.grpInformation, 0);
            this.Controls.SetChildIndex(this.btnHistoryDownLoad, 0);
            this.Controls.SetChildIndex(this.btnMasterMaintenance, 0);
            this.Controls.SetChildIndex(this.btnChohyo, 0);
            this.Controls.SetChildIndex(this.btnMast, 0);
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnChohyo;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnMast;


    }
}

