namespace Isid.KKH.Lion.View.Top
{
    partial class frmTopMenuLion
    {
        /// <summary>
        /// 必要なデザイナ変数です。.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。.
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

        #region Windows フォーム デザイナで生成されたコード.

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を.
        /// コード エディタで変更しないでください。.

        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTopMenuLion));
            this.btnCmTv = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnCmRd = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
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
            this.btnDetails.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnDetails.Image")));
            this.btnDetails.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnDetails.MouseDownImage")));
            this.btnDetails.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnDetails.MouseLeaveImage")));
            this.btnDetails.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnDetails.MouseMoveImage")));
            this.njToolTip1.SetToolTip(this.btnDetails, "明細画面を表示します");
            // 
            // btnAccount
            // 
            this.btnAccount.ButtonCount = 7;
            this.btnAccount.ButtonText = "     帳票     ▼";
            this.btnAccount.ButtonValue = new string[] {
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7"};
            this.btnAccount.ChildButtonText = new string[] {
        "見積書",
        "プルーフリスト",
        "請求データ出力",
        "明細一覧帳票",
        "     制作室リスト       追加変更リスト",
        "請求予定表",
        "受注比較一覧帳票"};
            this.btnAccount.ColumnCount = 3;
            this.btnAccount.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnAccount.Location = new System.Drawing.Point(212, 147);
            this.njToolTip1.SetToolTip(this.btnAccount, "帳票画面を表示します");
            this.btnAccount.PopupButtonClick += new Isid.KKH.Common.KKHView.Common.Control.MenuButton.PopupButtonClickEventHandler(this.btnAccount_PopupButtonClick);
            // 
            // btnHistoryDownLoad
            // 
            this.btnHistoryDownLoad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHistoryDownLoad.FlatAppearance.BorderSize = 0;
            this.btnHistoryDownLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHistoryDownLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHistoryDownLoad.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnHistoryDownLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnHistoryDownLoad.Image")));
            this.btnHistoryDownLoad.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHistoryDownLoad.MouseDownImage")));
            this.btnHistoryDownLoad.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHistoryDownLoad.MouseLeaveImage")));
            this.btnHistoryDownLoad.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHistoryDownLoad.MouseMoveImage")));
            this.njToolTip1.SetToolTip(this.btnHistoryDownLoad, "請求原票取込履歴画面を表示します");
            this.btnHistoryDownLoad.Click += new System.EventHandler(this.btnHistoryDownLoad_Click_1);
            // 
            // btnHlp
            // 
            this.btnHlp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHlp.FlatAppearance.BorderSize = 0;
            this.btnHlp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.Image = ((System.Drawing.Image)(resources.GetObject("btnHlp.Image")));
            this.btnHlp.Location = new System.Drawing.Point(495, 13);
            this.btnHlp.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseDownImage")));
            this.btnHlp.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseLeaveImage")));
            this.btnHlp.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseMoveImage")));
            this.njToolTip1.SetToolTip(this.btnHlp, "ヘルプを表示します");
            // 
            // btnEnd
            // 
            this.btnEnd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEnd.FlatAppearance.BorderSize = 0;
            this.btnEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEnd.Image")));
            this.btnEnd.Location = new System.Drawing.Point(540, 13);
            this.btnEnd.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseDownImage")));
            this.btnEnd.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseLeaveImage")));
            this.btnEnd.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseMoveImage")));
            this.njToolTip1.SetToolTip(this.btnEnd, "広告費明細システムを終了します");
            // 
            // btnMasterMaintenance
            // 
            this.btnMasterMaintenance.ButtonCount = 6;
            this.btnMasterMaintenance.ButtonMouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnMasterMaintenance.ButtonMouseLeaveImage")));
            this.btnMasterMaintenance.ButtonMouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnMasterMaintenance.ButtonMouseMoveImage")));
            this.btnMasterMaintenance.ButtonText = "マスター  ▼";
            this.btnMasterMaintenance.ButtonValue = new string[] {
        "ＡＤブランドマスター",
        "新聞マスター",
        "新聞コード変換マスター",
        "雑誌マスター",
        "雑誌コード変換マスター",
        "雑誌ｽﾍﾟｰｽマスター"};
            this.btnMasterMaintenance.ChildButtonText = new string[] {
        "ＡＤブランドマスター",
        "新聞マスター",
        "新聞コード変換マスター",
        "雑誌マスター",
        "雑誌コード変換マスター",
        "雑誌ｽﾍﾟｰｽマスター"};
            this.btnMasterMaintenance.ColumnCount = 3;
            this.btnMasterMaintenance.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMasterMaintenance.Location = new System.Drawing.Point(401, 147);
            this.njToolTip1.SetToolTip(this.btnMasterMaintenance, "マスターメンテナンス画面を表示します");
            this.btnMasterMaintenance.ToolTipText = "マスターメンテナンス画面を表示します";
            this.btnMasterMaintenance.PopupButtonClick += new Isid.KKH.Common.KKHView.Common.Control.MenuButton.PopupButtonClickEventHandler(this.btnMasterMaintenance_PopupButtonClick);
            // 
            // btnCmTv
            // 
            this.btnCmTv.BackColor = System.Drawing.Color.Transparent;
            this.btnCmTv.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCmTv.FlatAppearance.BorderSize = 0;
            this.btnCmTv.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCmTv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCmTv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCmTv.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCmTv.Image = ((System.Drawing.Image)(resources.GetObject("btnCmTv.Image")));
            this.btnCmTv.Location = new System.Drawing.Point(212, 235);
            this.btnCmTv.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCmTv.MouseDownImage")));
            this.btnCmTv.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnCmTv.MouseLeaveImage")));
            this.btnCmTv.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCmTv.MouseMoveImage")));
            this.btnCmTv.Name = "btnCmTv";
            this.btnCmTv.Size = new System.Drawing.Size(182, 52);
            this.btnCmTv.TabIndex = 52;
            this.btnCmTv.TabStop = false;
            this.btnCmTv.Text = " CM秒数\r\n テレビ";
            this.njToolTip1.SetToolTip(this.btnCmTv, "ＣＭ秒数の作成・更新画面です");
            this.btnCmTv.UseVisualStyleBackColor = false;
            this.btnCmTv.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnCmTv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnCmTv.Click += new System.EventHandler(this.btnCmTv_Click);
            // 
            // btnCmRd
            // 
            this.btnCmRd.BackColor = System.Drawing.Color.Transparent;
            this.btnCmRd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCmRd.FlatAppearance.BorderSize = 0;
            this.btnCmRd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCmRd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCmRd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCmRd.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCmRd.Image = ((System.Drawing.Image)(resources.GetObject("btnCmRd.Image")));
            this.btnCmRd.Location = new System.Drawing.Point(401, 235);
            this.btnCmRd.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnCmRd.MouseDownImage")));
            this.btnCmRd.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnCmRd.MouseLeaveImage")));
            this.btnCmRd.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnCmRd.MouseMoveImage")));
            this.btnCmRd.Name = "btnCmRd";
            this.btnCmRd.Size = new System.Drawing.Size(182, 52);
            this.btnCmRd.TabIndex = 53;
            this.btnCmRd.TabStop = false;
            this.btnCmRd.Text = " CM秒数\r\n ラジオ";
            this.njToolTip1.SetToolTip(this.btnCmRd, "ＣＭ秒数の作成・更新画面です");
            this.btnCmRd.UseVisualStyleBackColor = false;
            this.btnCmRd.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnCmRd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnCmRd.Click += new System.EventHandler(this.btnCmRd_Click);
            // 
            // frmTopMenuLion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAccountVisble = true;
            this.btnDetailsVisble = true;
            this.btnMasterMaintenanceVisble = true;
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.Controls.Add(this.btnCmRd);
            this.Controls.Add(this.btnCmTv);
            this.grpInformationVisble = true;
            this.Name = "frmTopMenuLion";
            this.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.frmTopMenuLion_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.btnHistoryDownLoad, 0);
            this.Controls.SetChildIndex(this.btnAccount, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.btnDetails, 0);
            this.Controls.SetChildIndex(this.btnMasterMaintenance, 0);
            this.Controls.SetChildIndex(this.grpInformation, 0);
            this.Controls.SetChildIndex(this.btnCmTv, 0);
            this.Controls.SetChildIndex(this.btnCmRd, 0);
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnCmTv;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnCmRd;

    }
}

