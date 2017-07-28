namespace Isid.KKH.Toh.View.Top
{
    partial class frmTopMenuToh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTopMenuToh));
            this.btnMast = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.grpInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDetails
            // 
            this.btnDetails.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDetails.FlatAppearance.BorderSize = 0;
            this.btnDetails.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDetails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.njToolTip1.SetToolTip(this.btnDetails, "明細画面を表示します");
            // 
            // btnAccount
            // 
            this.btnAccount.ButtonCount = 2;
            this.btnAccount.ButtonValue = new string[] {
        "1",
        "2"};
            this.btnAccount.ChildButtonText = new string[] {
        "請求明細一覧",
        "年月別媒体別集計"};
            this.btnAccount.ColumnCount = 3;
            this.njToolTip1.SetToolTip(this.btnAccount, "帳票画面を表示します");
            this.btnAccount.PopupButtonClick += new Isid.KKH.Common.KKHView.Common.Control.MenuButton.PopupButtonClickEventHandler(this.btnAccount_PopupButtonClick);
            // 
            // grpInformation
            // 
            this.grpInformation.Location = new System.Drawing.Point(13, 486);
            this.grpInformation.Size = new System.Drawing.Size(579, 188);
            // 
            // txtInformation
            // 
            this.txtInformation.Location = new System.Drawing.Point(12, 18);
            this.txtInformation.Size = new System.Drawing.Size(555, 162);
            // 
            // btnHistoryDownLoad
            // 
            this.btnHistoryDownLoad.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHistoryDownLoad.FlatAppearance.BorderSize = 0;
            this.btnHistoryDownLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHistoryDownLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHistoryDownLoad.Location = new System.Drawing.Point(22, 226);
            this.njToolTip1.SetToolTip(this.btnHistoryDownLoad, "請求原票取込履歴画面を表示します");
            // 
            // btnHlp
            // 
            this.btnHlp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHlp.FlatAppearance.BorderSize = 0;
            this.btnHlp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.njToolTip1.SetToolTip(this.btnHlp, "ヘルプを表示します");
            // 
            // btnEnd
            // 
            this.btnEnd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEnd.FlatAppearance.BorderSize = 0;
            this.btnEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.njToolTip1.SetToolTip(this.btnEnd, "広告費明細システムを終了します");
            // 
            // btnMasterMaintenance
            // 
            this.btnMasterMaintenance.ButtonCount = 2;
            this.btnMasterMaintenance.ButtonValue = new string[] {
        "スペース2一覧",
        "媒体コードサマリ"};
            this.btnMasterMaintenance.ChildButtonText = new string[] {
        "スペース2一覧",
        "媒体コードサマリ"};
            this.btnMasterMaintenance.ColumnCount = 2;
            this.njToolTip1.SetToolTip(this.btnMasterMaintenance, "マスタメンテナンス画面を表示します");
            this.btnMasterMaintenance.PopupButtonClick += new Isid.KKH.Common.KKHView.Common.Control.MenuButton.PopupButtonClickEventHandler(this.btnMasterMaintenance_PopupButtonClick);
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
            this.btnMast.Location = new System.Drawing.Point(400, 205);
            this.btnMast.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnMast.MouseDownImage")));
            this.btnMast.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnMast.MouseLeaveImage")));
            this.btnMast.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnMast.MouseMoveImage")));
            this.btnMast.Name = "btnMast";
            this.btnMast.Size = new System.Drawing.Size(182, 52);
            this.btnMast.TabIndex = 49;
            this.btnMast.TabStop = false;
            this.btnMast.Text = "  マスター";
            this.njToolTip1.SetToolTip(this.btnMast, "マスター画面を表示します");
            this.btnMast.UseVisualStyleBackColor = false;
            this.btnMast.Visible = false;
            this.btnMast.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnMast.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnMast.Click += new System.EventHandler(this.btnMast_Click);
            // 
            // frmTopMenuToh
            // 
            this.btnAccountVisble = true;
            this.btnDetailsVisble = true;
            this.btnMasterMaintenanceVisble = true;
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.Controls.Add(this.btnMast);
            this.grpInformationVisble = true;
            this.Name = "frmTopMenuToh";
            this.Load += new System.EventHandler(this.frmTopMenuToh_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.frmTopMenuToh_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.btnDetails, 0);
            this.Controls.SetChildIndex(this.btnAccount, 0);
            this.Controls.SetChildIndex(this.grpInformation, 0);
            this.Controls.SetChildIndex(this.btnHistoryDownLoad, 0);
            this.Controls.SetChildIndex(this.btnMasterMaintenance, 0);
            this.Controls.SetChildIndex(this.btnMast, 0);
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnMast;




    }
}
