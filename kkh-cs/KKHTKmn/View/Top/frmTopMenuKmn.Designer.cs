namespace Isid.KKH.Kmn.View.Top
{
    partial class frmTopMenuKmn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTopMenuKmn));
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
        "納品書"};
            this.btnAccount.ColumnCount = 3;
            this.njToolTip1.SetToolTip(this.btnAccount, "帳票画面を表示します");
            this.btnAccount.Visible = false;
            this.btnAccount.PopupButtonClick += new Isid.KKH.Common.KKHView.Common.Control.MenuButton.PopupButtonClickEventHandler(this.btnAccount_PopupButtonClick);
            // 
            // grpInformation
            // 
            this.grpInformation.Location = new System.Drawing.Point(13, 486);
            this.grpInformation.Size = new System.Drawing.Size(574, 188);
            // 
            // txtInformation
            // 
            this.txtInformation.Location = new System.Drawing.Point(20, 18);
            // 
            // btnHistoryDownLoad
            // 
            this.btnHistoryDownLoad.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHistoryDownLoad.FlatAppearance.BorderSize = 0;
            this.btnHistoryDownLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHistoryDownLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.njToolTip1.SetToolTip(this.btnHistoryDownLoad, "請求原票取込履歴画面を表示します");
            this.btnHistoryDownLoad.Visible = false;
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
            this.btnMasterMaintenance.ButtonCount = 1;
            this.btnMasterMaintenance.ButtonValue = new string[] {
        "宛先マスター"};
            this.btnMasterMaintenance.ChildButtonText = new string[] {
        "宛先マスター"};
            this.btnMasterMaintenance.ColumnCount = 1;
            this.btnMasterMaintenance.DropDownAlign = Isid.KKH.Common.KKHView.Common.Control.MenuButton.KkhMenuButton.DropDownAlignValue.Center;
            this.njToolTip1.SetToolTip(this.btnMasterMaintenance, "マスタメンテナンス画面を表示します");
            this.btnMasterMaintenance.PopupButtonClick += new Isid.KKH.Common.KKHView.Common.Control.MenuButton.PopupButtonClickEventHandler(this.btnMasterMaintenance_PopupButtonClick);
            // 
            // frmTopMenuKmn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.btnAccountVisble = true;
            this.btnDetailsVisble = true;
            this.btnMasterMaintenanceVisble = true;
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.grpInformationVisble = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTopMenuKmn";
            this.Load += new System.EventHandler(this.frmTopMenuKmn_Load);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.frmTopMenuKmn_ProcessAffterNavigating);
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


    }
}

