namespace Isid.KKH.Acom.View.Top
{ 
    partial class frmTopMenuAcom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTopMenuAcom));
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType9 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType11 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType12 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType13 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType14 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.spdLogCaption = new Isid.KKH.Common.KKHView.Common.Control.KkhSpread();
            this.spdLogCaption_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnFileImport = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnClaim = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnChohyo = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.grpHchuSkyuRrk = new System.Windows.Forms.GroupBox();
            this.grpInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLogCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLogCaption_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDetails
            // 
            this.btnDetails.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDetails.FlatAppearance.BorderSize = 0;
            this.btnDetails.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDetails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnDetails.Image")));
            this.btnDetails.Location = new System.Drawing.Point(14, 149);
            this.btnDetails.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnDetails.MouseDownImage")));
            this.btnDetails.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnDetails.MouseLeaveImage")));
            this.btnDetails.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnDetails.MouseMoveImage")));
            this.btnDetails.TabIndex = 2;
            this.njToolTip1.SetToolTip(this.btnDetails, "明細画面を表示します");
            // 
            // btnAccount
            // 
            this.btnAccount.ButtonMouseLeaveImage = null;
            this.btnAccount.ButtonMouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnAccount.ButtonMouseMoveImage")));
            this.btnAccount.ButtonText = "帳票";
            this.btnAccount.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAccount.Location = new System.Drawing.Point(207, 149);
            this.btnAccount.TabIndex = 4;
            this.njToolTip1.SetToolTip(this.btnAccount, "帳票画面を表示します");
            this.btnAccount.Visible = false;
            // 
            // grpInformation
            // 
            this.grpInformation.Location = new System.Drawing.Point(14, 503);
            this.grpInformation.Size = new System.Drawing.Size(571, 171);
            this.grpInformation.TabIndex = 8;
            // 
            // txtInformation
            // 
            this.txtInformation.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtInformation.Location = new System.Drawing.Point(9, 24);
            this.txtInformation.Size = new System.Drawing.Size(555, 139);
            this.txtInformation.TabIndex = 1;
            // 
            // btnHistoryDownLoad
            // 
            this.btnHistoryDownLoad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHistoryDownLoad.FlatAppearance.BorderSize = 0;
            this.btnHistoryDownLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHistoryDownLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHistoryDownLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnHistoryDownLoad.Image")));
            this.btnHistoryDownLoad.Location = new System.Drawing.Point(14, 234);
            this.btnHistoryDownLoad.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHistoryDownLoad.MouseDownImage")));
            this.btnHistoryDownLoad.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHistoryDownLoad.MouseLeaveImage")));
            this.btnHistoryDownLoad.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHistoryDownLoad.MouseMoveImage")));
            this.btnHistoryDownLoad.TabIndex = 5;
            this.njToolTip1.SetToolTip(this.btnHistoryDownLoad, "請求原票取込履歴画面を表示します");
            // 
            // btnHlp
            // 
            this.btnHlp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHlp.FlatAppearance.BorderSize = 0;
            this.btnHlp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.Image = ((System.Drawing.Image)(resources.GetObject("btnHlp.Image")));
            this.btnHlp.Location = new System.Drawing.Point(488, 13);
            this.btnHlp.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseDownImage")));
            this.btnHlp.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseLeaveImage")));
            this.btnHlp.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnHlp.MouseMoveImage")));
            this.btnHlp.TabIndex = 8;
            this.njToolTip1.SetToolTip(this.btnHlp, "ヘルプを表示します");
            // 
            // btnEnd
            // 
            this.btnEnd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEnd.FlatAppearance.BorderSize = 0;
            this.btnEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEnd.Image")));
            this.btnEnd.Location = new System.Drawing.Point(533, 13);
            this.btnEnd.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseDownImage")));
            this.btnEnd.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseLeaveImage")));
            this.btnEnd.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnEnd.MouseMoveImage")));
            this.btnEnd.TabIndex = 9;
            this.njToolTip1.SetToolTip(this.btnEnd, "広告費明細システムを終了します");
            // 
            // btnMasterMaintenance
            // 
            this.btnMasterMaintenance.ButtonCount = 7;
            this.btnMasterMaintenance.ButtonMouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnMasterMaintenance.ButtonMouseLeaveImage")));
            this.btnMasterMaintenance.ButtonMouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnMasterMaintenance.ButtonMouseMoveImage")));
            this.btnMasterMaintenance.ButtonValue = new string[] {
        "媒体種別マスター",
        "掲載場所変換マスター",
        "サイズコード変換マスター",
        "記雑コード変換マスター",
        "朝夕コード変換マスター",
        "メディアコード変換マスター",
        "色刷変換マスター"};
            this.btnMasterMaintenance.ChildButtonText = new string[] {
        "媒体種別マスター",
        "掲載場所変換マスター",
        "サイズコード変換マスター",
        "記雑コード変換マスター",
        "朝夕コード変換マスター",
        "メディアコード変換マスター",
        "色刷変換マスター"};
            this.btnMasterMaintenance.ColumnCount = 3;
            this.btnMasterMaintenance.Location = new System.Drawing.Point(397, 149);
            this.njToolTip1.SetToolTip(this.btnMasterMaintenance, "マスターメンテナンス画面を表示します");
            this.btnMasterMaintenance.ToolTipText = "マスターメンテナンス画面を表示します";
            this.btnMasterMaintenance.PopupButtonClick += new Isid.KKH.Common.KKHView.Common.Control.MenuButton.PopupButtonClickEventHandler(this.btnMasterMaintenance_PopupButtonClick);
            // 
            // spdLogCaption
            // 
            this.spdLogCaption.AccessibleDescription = "spdLogCaption, Sheet1";
            this.spdLogCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spdLogCaption.EnableCustomSorting = false;
            this.spdLogCaption.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.spdLogCaption.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdLogCaption.Location = new System.Drawing.Point(25, 313);
            this.spdLogCaption.Name = "spdLogCaption";
            this.spdLogCaption.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdLogCaption.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdLogCaption_Sheet1});
            this.spdLogCaption.Size = new System.Drawing.Size(553, 177);
            this.spdLogCaption.TabIndex = 0;
            this.spdLogCaption.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // spdLogCaption_Sheet1
            // 
            this.spdLogCaption_Sheet1.Reset();
            this.spdLogCaption_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdLogCaption_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdLogCaption_Sheet1.ColumnCount = 7;
            this.spdLogCaption_Sheet1.RowCount = 0;
            this.spdLogCaption_Sheet1.ActiveSkin = new FarPoint.Win.Spread.SheetSkin("CustomSkin5", System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.LightGray, FarPoint.Win.Spread.GridLines.Both, System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224))))), System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, System.Drawing.Color.Empty, false, false, false, true, true);
            this.spdLogCaption_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "区分";
            this.spdLogCaption_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "内容";
            this.spdLogCaption_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "送信完了日時";
            this.spdLogCaption_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "受信完了日時";
            this.spdLogCaption_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "担当者";
            this.spdLogCaption_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "送受信種類";
            this.spdLogCaption_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "ステータス";
            this.spdLogCaption_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLogCaption_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spdLogCaption_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.spdLogCaption_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdLogCaption_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLogCaption_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLogCaption_Sheet1.Columns.Get(0).CellType = textCellType8;
            this.spdLogCaption_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLogCaption_Sheet1.Columns.Get(0).Label = "区分";
            this.spdLogCaption_Sheet1.Columns.Get(0).Locked = true;
            this.spdLogCaption_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLogCaption_Sheet1.Columns.Get(0).Width = 40F;
            this.spdLogCaption_Sheet1.Columns.Get(1).CellType = textCellType9;
            this.spdLogCaption_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLogCaption_Sheet1.Columns.Get(1).Label = "内容";
            this.spdLogCaption_Sheet1.Columns.Get(1).Locked = true;
            this.spdLogCaption_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLogCaption_Sheet1.Columns.Get(1).Width = 97F;
            this.spdLogCaption_Sheet1.Columns.Get(2).CellType = textCellType10;
            this.spdLogCaption_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLogCaption_Sheet1.Columns.Get(2).Label = "送信完了日時";
            this.spdLogCaption_Sheet1.Columns.Get(2).Locked = true;
            this.spdLogCaption_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLogCaption_Sheet1.Columns.Get(2).Width = 130F;
            this.spdLogCaption_Sheet1.Columns.Get(3).CellType = textCellType11;
            this.spdLogCaption_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLogCaption_Sheet1.Columns.Get(3).Label = "受信完了日時";
            this.spdLogCaption_Sheet1.Columns.Get(3).Locked = true;
            this.spdLogCaption_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLogCaption_Sheet1.Columns.Get(3).Width = 130F;
            this.spdLogCaption_Sheet1.Columns.Get(4).CellType = textCellType12;
            this.spdLogCaption_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLogCaption_Sheet1.Columns.Get(4).Label = "担当者";
            this.spdLogCaption_Sheet1.Columns.Get(4).Locked = true;
            this.spdLogCaption_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLogCaption_Sheet1.Columns.Get(4).Width = 100F;
            this.spdLogCaption_Sheet1.Columns.Get(5).CellType = textCellType13;
            this.spdLogCaption_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLogCaption_Sheet1.Columns.Get(5).Label = "送受信種類";
            this.spdLogCaption_Sheet1.Columns.Get(5).Locked = true;
            this.spdLogCaption_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLogCaption_Sheet1.Columns.Get(5).Width = 100F;
            this.spdLogCaption_Sheet1.Columns.Get(6).CellType = textCellType14;
            this.spdLogCaption_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLogCaption_Sheet1.Columns.Get(6).Label = "ステータス";
            this.spdLogCaption_Sheet1.Columns.Get(6).Locked = true;
            this.spdLogCaption_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLogCaption_Sheet1.Columns.Get(6).Width = 100F;
            this.spdLogCaption_Sheet1.DataAutoCellTypes = false;
            this.spdLogCaption_Sheet1.DataAutoHeadings = false;
            this.spdLogCaption_Sheet1.DataAutoSizeColumns = false;
            this.spdLogCaption_Sheet1.FrozenColumnCount = 2;
            this.spdLogCaption_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdLogCaption_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLogCaption_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spdLogCaption_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdLogCaption_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLogCaption_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLogCaption_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdLogCaption_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.spdLogCaption_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdLogCaption_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLogCaption_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.spdLogCaption.SetViewportLeftColumn(0, 0, 2);
            this.spdLogCaption.SetActiveViewport(0, 1, -1);
            // 
            // btnFileImport
            // 
            this.btnFileImport.BackColor = System.Drawing.Color.Transparent;
            this.btnFileImport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFileImport.FlatAppearance.BorderSize = 0;
            this.btnFileImport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFileImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFileImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileImport.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnFileImport.Image = ((System.Drawing.Image)(resources.GetObject("btnFileImport.Image")));
            this.btnFileImport.Location = new System.Drawing.Point(207, 234);
            this.btnFileImport.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnFileImport.MouseDownImage")));
            this.btnFileImport.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnFileImport.MouseLeaveImage")));
            this.btnFileImport.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnFileImport.MouseMoveImage")));
            this.btnFileImport.Name = "btnFileImport";
            this.btnFileImport.Size = new System.Drawing.Size(182, 52);
            this.btnFileImport.TabIndex = 6;
            this.btnFileImport.Text = "       発注データ取込";
            this.njToolTip1.SetToolTip(this.btnFileImport, "得意先より送付された発注データの取込を行ないます");
            this.btnFileImport.UseVisualStyleBackColor = false;
            this.btnFileImport.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnFileImport.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnFileImport.Click += new System.EventHandler(this.btnFileImport_Click);
            // 
            // btnClaim
            // 
            this.btnClaim.BackColor = System.Drawing.Color.Transparent;
            this.btnClaim.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClaim.FlatAppearance.BorderSize = 0;
            this.btnClaim.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClaim.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClaim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClaim.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClaim.Image = ((System.Drawing.Image)(resources.GetObject("btnClaim.Image")));
            this.btnClaim.Location = new System.Drawing.Point(397, 234);
            this.btnClaim.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnClaim.MouseDownImage")));
            this.btnClaim.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnClaim.MouseLeaveImage")));
            this.btnClaim.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnClaim.MouseMoveImage")));
            this.btnClaim.Name = "btnClaim";
            this.btnClaim.Size = new System.Drawing.Size(182, 52);
            this.btnClaim.TabIndex = 7;
            this.btnClaim.Text = "       請求データ送信";
            this.njToolTip1.SetToolTip(this.btnClaim, "得意先に送信するデータを作成します");
            this.btnClaim.UseVisualStyleBackColor = false;
            this.btnClaim.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnClaim.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnClaim.Click += new System.EventHandler(this.btnClaim_Click);
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
            this.btnChohyo.Location = new System.Drawing.Point(207, 149);
            this.btnChohyo.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnChohyo.MouseDownImage")));
            this.btnChohyo.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnChohyo.MouseLeaveImage")));
            this.btnChohyo.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnChohyo.MouseMoveImage")));
            this.btnChohyo.Name = "btnChohyo";
            this.btnChohyo.Size = new System.Drawing.Size(182, 52);
            this.btnChohyo.TabIndex = 47;
            this.btnChohyo.Text = "　   請求書\r\n     作成指示書";
            this.njToolTip1.SetToolTip(this.btnChohyo, "請求書作成作業の請求書作成指示書を出力します");
            this.btnChohyo.UseVisualStyleBackColor = false;
            this.btnChohyo.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnChohyo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnChohyo.Click += new System.EventHandler(this.btnChohyo_Click);
            // 
            // grpHchuSkyuRrk
            // 
            this.grpHchuSkyuRrk.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grpHchuSkyuRrk.Location = new System.Drawing.Point(14, 295);
            this.grpHchuSkyuRrk.Name = "grpHchuSkyuRrk";
            this.grpHchuSkyuRrk.Size = new System.Drawing.Size(571, 201);
            this.grpHchuSkyuRrk.TabIndex = 48;
            this.grpHchuSkyuRrk.TabStop = false;
            this.grpHchuSkyuRrk.Text = "発注/請求データ送受信関連履歴";
            // 
            // frmTopMenuAcom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.btnAccountVisble = true;
            this.btnDetailsVisble = true;
            this.btnMasterMaintenanceVisble = true;
            this.ClientSize = new System.Drawing.Size(600, 700);
            this.Controls.Add(this.btnChohyo);
            this.Controls.Add(this.btnClaim);
            this.Controls.Add(this.spdLogCaption);
            this.Controls.Add(this.btnFileImport);
            this.Controls.Add(this.grpHchuSkyuRrk);
            this.grpInformationVisble = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTopMenuAcom";
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.frmTopMenuAcom_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.btnHistoryDownLoad, 0);
            this.Controls.SetChildIndex(this.btnDetails, 0);
            this.Controls.SetChildIndex(this.btnMasterMaintenance, 0);
            this.Controls.SetChildIndex(this.btnAccount, 0);
            this.Controls.SetChildIndex(this.grpHchuSkyuRrk, 0);
            this.Controls.SetChildIndex(this.btnFileImport, 0);
            this.Controls.SetChildIndex(this.spdLogCaption, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.grpInformation, 0);
            this.Controls.SetChildIndex(this.btnClaim, 0);
            this.Controls.SetChildIndex(this.btnChohyo, 0);
            this.grpInformation.ResumeLayout(false);
            this.grpInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLogCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLogCaption_Sheet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Isid.KKH.Common.KKHView.Common.Control.KkhSpread spdLogCaption;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnFileImport;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnClaim;
        private FarPoint.Win.Spread.SheetView spdLogCaption_Sheet1;
        private Isid.KKH.Common.KKHView.Common.Control.KkhButton btnChohyo;
        private System.Windows.Forms.GroupBox grpHchuSkyuRrk;
    }
}

