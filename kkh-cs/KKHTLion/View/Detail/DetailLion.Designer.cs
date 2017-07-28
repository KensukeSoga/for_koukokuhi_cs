namespace Isid.KKH.Lion.View.Detail
{
    partial class DetailLion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailLion));
            this.btnDetailInput = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.lblSagaku = new Isid.NJ.View.Widget.NJLabel();
            this.lblGoukei = new Isid.NJ.View.Widget.NJLabel();
            this.lblSagakuValue = new Isid.NJ.View.Widget.NJLabel();
            this.lblGoukeiValue = new Isid.NJ.View.Widget.NJLabel();
            this._dsDetailLion = new Isid.KKH.Lion.Schema.DetailDSLion();
            this.btnDetailDel = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnDetailRegister = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnBulkRegister = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnSubjectUpdate = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnMergeByJyutyuNo = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.btnTVTimeMergeByJyutyuNo = new Isid.KKH.Common.KKHView.Common.Control.KkhButton();
            this.lblByosuValue = new Isid.NJ.View.Widget.NJLabel();
            this.lblSeikyuValue = new Isid.NJ.View.Widget.NJLabel();
            this.ｌｂｌSeikyu = new Isid.NJ.View.Widget.NJLabel();
            this.lblHonsuValue = new Isid.NJ.View.Widget.NJLabel();
            this.ｌｂｌHonsu = new Isid.NJ.View.Widget.NJLabel();
            this.lblDenpaValue = new Isid.NJ.View.Widget.NJLabel();
            this.ｌｂｌByosu = new Isid.NJ.View.Widget.NJLabel();
            this.ｌｂｌDenpa = new Isid.NJ.View.Widget.NJLabel();
            this.lblToriRyokinValue = new Isid.NJ.View.Widget.NJLabel();
            this.ｌｂｌToriRyokin = new Isid.NJ.View.Widget.NJLabel();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdJyutyuDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdJyutyuDetail_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJyuNo)).BeginInit();
            this.pnlOrder.SuspendLayout();
            this.pnlTmSp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dsDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsJyutyuList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsJyutyuDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsKkhDetail)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.@__spdJyutyuList_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdKkhDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdKkhDetail_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsJyutyuRireki)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdJyutyuRireki)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdJyutyuRireki_Sheet1)).BeginInit();
            this.tabHed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._spdJyutyuList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKenMei)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dsDetailLion)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Size = new System.Drawing.Size(1165, 290);
            // 
            // tabPage1
            // 
            this.tabPage1.Size = new System.Drawing.Size(1165, 290);
            // 
            // spdJyutyuDetail
            // 
            this.spdJyutyuDetail.Size = new System.Drawing.Size(355, 253);
            // 
            // _spdJyutyuDetail_Sheet1
            // 
            this._spdJyutyuDetail_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this._spdJyutyuDetail_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this._spdJyutyuDetail_Sheet1.ColumnCount = 1;
            this._spdJyutyuDetail_Sheet1.RowCount = 1;
            this._spdJyutyuDetail_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this._spdJyutyuDetail_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdJyutyuDetail_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdJyutyuDetail_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this._spdJyutyuDetail_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdJyutyuDetail_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdJyutyuDetail_Sheet1.ColumnHeader.Visible = false;
            this._spdJyutyuDetail_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this._spdJyutyuDetail_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdJyutyuDetail_Sheet1.RowHeader.Columns.Get(0).Width = 100F;
            this._spdJyutyuDetail_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdJyutyuDetail_Sheet1.RowHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this._spdJyutyuDetail_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this._spdJyutyuDetail_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdJyutyuDetail_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdJyutyuDetail_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdJyutyuDetail_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this._spdJyutyuDetail_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdJyutyuDetail_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnEnd
            // 
            this.btnEnd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEnd.FlatAppearance.BorderSize = 0;
            this.btnEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEnd.Location = new System.Drawing.Point(1152, 8);
            this.btnEnd.TabIndex = 19;
            this.njToolTip1.SetToolTip(this.btnEnd, "明細登録を終了してメニューに戻ります");
            // 
            // btnSch
            // 
            this.btnSch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSch.FlatAppearance.BorderSize = 0;
            this.btnSch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSch.Image = ((System.Drawing.Image)(resources.GetObject("btnSch.Image")));
            this.btnSch.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnSch.MouseDownImage")));
            this.btnSch.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnSch.MouseLeaveImage")));
            this.btnSch.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnSch.MouseMoveImage")));
            this.njToolTip1.SetToolTip(this.btnSch, "データの検索をおこないます");
            // 
            // btnHlp
            // 
            this.btnHlp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHlp.FlatAppearance.BorderSize = 0;
            this.btnHlp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.Location = new System.Drawing.Point(1109, 8);
            this.btnHlp.TabIndex = 18;
            this.njToolTip1.SetToolTip(this.btnHlp, "ヘルプを表示します");
            this.btnHlp.Click += new System.EventHandler(this.btnHlp_Click);
            // 
            // btnYmChange
            // 
            this.btnYmChange.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnYmChange.FlatAppearance.BorderSize = 0;
            this.btnYmChange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnYmChange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnYmChange.Image = ((System.Drawing.Image)(resources.GetObject("btnYmChange.Image")));
            this.btnYmChange.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnYmChange.MouseDownImage")));
            this.btnYmChange.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnYmChange.MouseLeaveImage")));
            this.btnYmChange.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnYmChange.MouseMoveImage")));
            this.njToolTip1.SetToolTip(this.btnYmChange, "請求年月を変更します");
            // 
            // pnlOrder
            // 
            this.pnlOrder.Visible = false;
            // 
            // btnDelJyutyu
            // 
            this.btnDelJyutyu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDelJyutyu.FlatAppearance.BorderSize = 0;
            this.btnDelJyutyu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDelJyutyu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDelJyutyu.Image = ((System.Drawing.Image)(resources.GetObject("btnDelJyutyu.Image")));
            this.btnDelJyutyu.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnDelJyutyu.MouseDownImage")));
            this.btnDelJyutyu.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnDelJyutyu.MouseLeaveImage")));
            this.btnDelJyutyu.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnDelJyutyu.MouseMoveImage")));
            this.njToolTip1.SetToolTip(this.btnDelJyutyu, "不要な受注データを削除します");
            // 
            // lblJyutyuListCnt
            // 
            this.lblJyutyuListCnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblJyutyuListCnt.Location = new System.Drawing.Point(1066, 122);
            // 
            // _bsKkhDetail
            // 
            this._bsKkhDetail.DataMember = "KkhDetail";
            this._bsKkhDetail.DataSource = this._dsDetailLion;
            // 
            // btnMerge
            // 
            this.btnMerge.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMerge.FlatAppearance.BorderSize = 0;
            this.btnMerge.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMerge.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMerge.Image = ((System.Drawing.Image)(resources.GetObject("btnMerge.Image")));
            this.btnMerge.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnMerge.MouseDownImage")));
            this.btnMerge.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnMerge.MouseLeaveImage")));
            this.btnMerge.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnMerge.MouseMoveImage")));
            this.btnMerge.Text = "選択統合";
            this.njToolTip1.SetToolTip(this.btnMerge, "複数の受注データをひとつに統合します");
            // 
            // btnMergeCancel
            // 
            this.btnMergeCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMergeCancel.FlatAppearance.BorderSize = 0;
            this.btnMergeCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMergeCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMergeCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnMergeCancel.Image")));
            this.btnMergeCancel.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnMergeCancel.MouseDownImage")));
            this.btnMergeCancel.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnMergeCancel.MouseLeaveImage")));
            this.btnMergeCancel.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnMergeCancel.MouseMoveImage")));
            this.njToolTip1.SetToolTip(this.btnMergeCancel, "統合された受注データをもとに戻します");
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblToriRyokinValue);
            this.splitContainer1.Panel2.Controls.Add(this.ｌｂｌToriRyokin);
            this.splitContainer1.Panel2.Controls.Add(this.ｌｂｌByosu);
            this.splitContainer1.Panel2.Controls.Add(this.ｌｂｌDenpa);
            this.splitContainer1.Panel2.Controls.Add(this.lblDenpaValue);
            this.splitContainer1.Panel2.Controls.Add(this.lblSeikyuValue);
            this.splitContainer1.Panel2.Controls.Add(this.ｌｂｌSeikyu);
            this.splitContainer1.Panel2.Controls.Add(this.ｌｂｌHonsu);
            this.splitContainer1.Panel2.Controls.Add(this.btnDetailInput);
            this.splitContainer1.Panel2.Controls.Add(this.lblHonsuValue);
            this.splitContainer1.Panel2.Controls.Add(this.lblGoukeiValue);
            this.splitContainer1.Panel2.Controls.Add(this.lblByosuValue);
            this.splitContainer1.Panel2.Controls.Add(this.btnDetailDel);
            this.splitContainer1.Panel2.Controls.Add(this.lblSagaku);
            this.splitContainer1.Panel2.Controls.Add(this.btnDetailRegister);
            this.splitContainer1.Panel2.Controls.Add(this.lblSagakuValue);
            this.splitContainer1.Panel2.Controls.Add(this.lblGoukei);
            this.splitContainer1.Panel2.Controls.Add(this.btnBulkRegister);
            this.splitContainer1.Size = new System.Drawing.Size(1180, 662);
            this.splitContainer1.SplitterDistance = 321;
            // 
            // btnRegJyutyu
            // 
            this.btnRegJyutyu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRegJyutyu.FlatAppearance.BorderSize = 0;
            this.btnRegJyutyu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRegJyutyu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRegJyutyu.Image = ((System.Drawing.Image)(resources.GetObject("btnRegJyutyu.Image")));
            this.btnRegJyutyu.Location = new System.Drawing.Point(599, 87);
            this.btnRegJyutyu.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnRegJyutyu.MouseDownImage")));
            this.btnRegJyutyu.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnRegJyutyu.MouseLeaveImage")));
            this.btnRegJyutyu.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnRegJyutyu.MouseMoveImage")));
            this.btnRegJyutyu.TabIndex = 14;
            this.njToolTip1.SetToolTip(this.btnRegJyutyu, "受注データを新規作成します");
            // 
            // __spdJyutyuList_Sheet1
            // 
            this.@__spdJyutyuList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.@__spdJyutyuList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.@__spdJyutyuList_Sheet1.ColumnCount = 27;
            this.@__spdJyutyuList_Sheet1.ColumnHeader.RowCount = 2;
            this.@__spdJyutyuList_Sheet1.ColumnHeader.AutoFilterIndex = 1;
            this.@__spdJyutyuList_Sheet1.ColumnHeader.AutoSortIndex = 1;
            this.@__spdJyutyuList_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.@__spdJyutyuList_Sheet1.ColumnHeader.AutoTextIndex = 0;
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "受変";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "登録";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "統合";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "代受";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "請求";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "売上明細NO";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "請求原票No";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "請求年月";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "業務区分";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "件名";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "費目名";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "媒体名";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "局誌CD";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "請求金額";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "期間";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "段単価";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "段数";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "取料金";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "値引率";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "値引額";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "消費税率";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "消費税額";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "受注請求金額";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "変更前請求年月";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "登録者";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "更新者";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "取得行番号";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.@__spdJyutyuList_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.@__spdJyutyuList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Rows.Get(0).Height = 30F;
            this.@__spdJyutyuList_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.@__spdJyutyuList_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.@__spdJyutyuList_Sheet1.RowHeader.Columns.Get(0).AllowAutoSort = true;
            this.@__spdJyutyuList_Sheet1.RowHeader.Columns.Get(0).Width = 48F;
            this.@__spdJyutyuList_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.@__spdJyutyuList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.@__spdJyutyuList_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.@__spdJyutyuList_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.@__spdJyutyuList_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.@__spdJyutyuList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.@__spdJyutyuList_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.@__spdJyutyuList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this._spdJyutyuList.SetViewportLeftColumn(0, 0, 7);
            this._spdJyutyuList.SetActiveViewport(0, 1, -1);
            // 
            // spdKkhDetail
            // 
            this.spdKkhDetail.Location = new System.Drawing.Point(4, 65);
            this.spdKkhDetail.Size = new System.Drawing.Size(1173, 272);
            this.spdKkhDetail.TabIndex = 26;
            // 
            // _spdKkhDetail_Sheet1
            // 
            this._spdKkhDetail_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this._spdKkhDetail_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this._spdKkhDetail_Sheet1.ColumnCount = 0;
            this._spdKkhDetail_Sheet1.ColumnHeader.RowCount = 2;
            this._spdKkhDetail_Sheet1.RowCount = 0;
            this._spdKkhDetail_Sheet1.ColumnHeader.AutoFilterIndex = 1;
            this._spdKkhDetail_Sheet1.ColumnHeader.AutoSortIndex = 1;
            this._spdKkhDetail_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this._spdKkhDetail_Sheet1.ColumnHeader.AutoTextIndex = 0;
            this._spdKkhDetail_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdKkhDetail_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdKkhDetail_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this._spdKkhDetail_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdKkhDetail_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdKkhDetail_Sheet1.DataAutoCellTypes = false;
            this._spdKkhDetail_Sheet1.DataAutoHeadings = false;
            this._spdKkhDetail_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this._spdKkhDetail_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this._spdKkhDetail_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this._spdKkhDetail_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdKkhDetail_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdKkhDetail_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this._spdKkhDetail_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdKkhDetail_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdKkhDetail_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this._spdKkhDetail_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this._spdKkhDetail_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdKkhDetail_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this._spdKkhDetail_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdKkhDetail_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.spdKkhDetail.SetActiveViewport(0, 1, 1);
            // 
            // _spdJyutyuRireki
            // 
            this._spdJyutyuRireki.AccessibleDescription = "_spdJyutyuRireki, Sheet1";
            // 
            // txtYmd
            // 
            this.txtYmd.DisplayMode = Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox.DisplayMode.COMBO;
            // 
            // btnUpdateCheck
            // 
            this.btnUpdateCheck.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUpdateCheck.FlatAppearance.BorderSize = 0;
            this.btnUpdateCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUpdateCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUpdateCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateCheck.Image")));
            this.btnUpdateCheck.Location = new System.Drawing.Point(752, 25);
            this.btnUpdateCheck.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnUpdateCheck.MouseDownImage")));
            this.btnUpdateCheck.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnUpdateCheck.MouseLeaveImage")));
            this.btnUpdateCheck.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnUpdateCheck.MouseMoveImage")));
            this.btnUpdateCheck.TabIndex = 17;
            // 
            // _spdJyutyuRireki_Sheet1
            // 
            this._spdJyutyuRireki_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this._spdJyutyuRireki_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this._spdJyutyuRireki_Sheet1.ColumnCount = 20;
            this._spdJyutyuRireki_Sheet1.ColumnHeader.RowCount = 2;
            this._spdJyutyuRireki_Sheet1.ColumnHeader.AutoFilterIndex = 1;
            this._spdJyutyuRireki_Sheet1.ColumnHeader.AutoSortIndex = 1;
            this._spdJyutyuRireki_Sheet1.ColumnHeader.AutoTextIndex = 0;
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "明作";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "ダウンロードタイミング";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "売上明細No";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "請求年月";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "業務区分";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "件名";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "媒体名";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "費目名";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "局誌CD";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "請求金額";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "期間";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "段単価";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "段数";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "取料金";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "値引率";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "値引額";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "消費税率";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "消費税額";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "受注請求金額";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "変更前請求年月";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdJyutyuRireki_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdJyutyuRireki_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Rows.Get(0).Height = 30F;
            this._spdJyutyuRireki_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this._spdJyutyuRireki_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdJyutyuRireki_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdJyutyuRireki_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this._spdJyutyuRireki_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdJyutyuRireki_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdJyutyuRireki_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._spdJyutyuRireki_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this._spdJyutyuRireki_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this._spdJyutyuRireki_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this._spdJyutyuRireki.SetActiveViewport(0, 1, 0);
            // 
            // tabHed
            // 
            this.tabHed.Size = new System.Drawing.Size(1173, 316);
            this.tabHed.TabIndex = 24;
            // 
            // _spdJyutyuList
            // 
            this._spdJyutyuList.AccessibleDescription = "_spdJyutyuList, Sheet1";
            this._spdJyutyuList.Size = new System.Drawing.Size(1159, 287);
            this._spdJyutyuList.TabIndex = 25;
            // 
            // lblMask
            // 
            this.lblMask.Size = new System.Drawing.Size(972, 18);
            // 
            // lblKenMei
            // 
            this.lblKenMei.Visible = true;
            // 
            // txtKenMei
            // 
            this.txtKenMei.Visible = true;
            // 
            // lblKikan
            // 
            this.lblKikan.Visible = false;
            // 
            // txtYmdTo
            // 
            this.txtYmdTo.Visible = false;
            // 
            // btnDetailInput
            // 
            this.btnDetailInput.BackColor = System.Drawing.Color.Transparent;
            this.btnDetailInput.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDetailInput.FlatAppearance.BorderSize = 0;
            this.btnDetailInput.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDetailInput.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDetailInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailInput.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetailInput.Image = ((System.Drawing.Image)(resources.GetObject("btnDetailInput.Image")));
            this.btnDetailInput.Location = new System.Drawing.Point(3, 6);
            this.btnDetailInput.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnDetailInput.MouseDownImage")));
            this.btnDetailInput.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnDetailInput.MouseLeaveImage")));
            this.btnDetailInput.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnDetailInput.MouseMoveImage")));
            this.btnDetailInput.Name = "btnDetailInput";
            this.btnDetailInput.Size = new System.Drawing.Size(113, 22);
            this.btnDetailInput.TabIndex = 20;
            this.btnDetailInput.TabStop = false;
            this.btnDetailInput.Text = "明細入力";
            this.btnDetailInput.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnDetailInput, "受注登録内容で選択されたデータについて広告費明細を入力します");
            this.btnDetailInput.UseVisualStyleBackColor = false;
            this.btnDetailInput.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnDetailInput.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnDetailInput.Click += new System.EventHandler(this.btnDetailInput_Click);
            // 
            // lblSagaku
            // 
            this.lblSagaku.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSagaku.AutoSize = true;
            this.lblSagaku.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSagaku.Location = new System.Drawing.Point(1001, 40);
            this.lblSagaku.Name = "lblSagaku";
            this.lblSagaku.Size = new System.Drawing.Size(29, 12);
            this.lblSagaku.TabIndex = 22;
            this.lblSagaku.Text = "差額";
            // 
            // lblGoukei
            // 
            this.lblGoukei.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGoukei.AutoSize = true;
            this.lblGoukei.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblGoukei.Location = new System.Drawing.Point(504, 40);
            this.lblGoukei.Name = "lblGoukei";
            this.lblGoukei.Size = new System.Drawing.Size(17, 12);
            this.lblGoukei.TabIndex = 23;
            this.lblGoukei.Text = "計";
            this.lblGoukei.Visible = false;
            // 
            // lblSagakuValue
            // 
            this.lblSagakuValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSagakuValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSagakuValue.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSagakuValue.Location = new System.Drawing.Point(1070, 39);
            this.lblSagakuValue.Name = "lblSagakuValue";
            this.lblSagakuValue.Size = new System.Drawing.Size(100, 14);
            this.lblSagakuValue.TabIndex = 23;
            this.lblSagakuValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblGoukeiValue
            // 
            this.lblGoukeiValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGoukeiValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGoukeiValue.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblGoukeiValue.Location = new System.Drawing.Point(527, 39);
            this.lblGoukeiValue.Name = "lblGoukeiValue";
            this.lblGoukeiValue.Size = new System.Drawing.Size(100, 14);
            this.lblGoukeiValue.TabIndex = 24;
            this.lblGoukeiValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblGoukeiValue.Visible = false;
            // 
            // _dsDetailLion
            // 
            this._dsDetailLion.DataSetName = "DetailDataSet";
            this._dsDetailLion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnDetailDel
            // 
            this.btnDetailDel.BackColor = System.Drawing.Color.Transparent;
            this.btnDetailDel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDetailDel.FlatAppearance.BorderSize = 0;
            this.btnDetailDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDetailDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDetailDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailDel.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetailDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDetailDel.Image")));
            this.btnDetailDel.Location = new System.Drawing.Point(122, 6);
            this.btnDetailDel.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnDetailDel.MouseDownImage")));
            this.btnDetailDel.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnDetailDel.MouseLeaveImage")));
            this.btnDetailDel.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnDetailDel.MouseMoveImage")));
            this.btnDetailDel.Name = "btnDetailDel";
            this.btnDetailDel.Size = new System.Drawing.Size(113, 22);
            this.btnDetailDel.TabIndex = 21;
            this.btnDetailDel.TabStop = false;
            this.btnDetailDel.Text = "明細削除";
            this.btnDetailDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnDetailDel, "選択されている広告費明細を削除します");
            this.btnDetailDel.UseVisualStyleBackColor = false;
            this.btnDetailDel.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnDetailDel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnDetailDel.Click += new System.EventHandler(this.btnDetailDel_Click);
            // 
            // btnDetailRegister
            // 
            this.btnDetailRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnDetailRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDetailRegister.FlatAppearance.BorderSize = 0;
            this.btnDetailRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDetailRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDetailRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailRegister.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetailRegister.Image = ((System.Drawing.Image)(resources.GetObject("btnDetailRegister.Image")));
            this.btnDetailRegister.Location = new System.Drawing.Point(241, 6);
            this.btnDetailRegister.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnDetailRegister.MouseDownImage")));
            this.btnDetailRegister.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnDetailRegister.MouseLeaveImage")));
            this.btnDetailRegister.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnDetailRegister.MouseMoveImage")));
            this.btnDetailRegister.Name = "btnDetailRegister";
            this.btnDetailRegister.Size = new System.Drawing.Size(113, 22);
            this.btnDetailRegister.TabIndex = 22;
            this.btnDetailRegister.TabStop = false;
            this.btnDetailRegister.Text = "明細登録";
            this.btnDetailRegister.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnDetailRegister, "表示されている内容で広告費明細を登録します");
            this.btnDetailRegister.UseVisualStyleBackColor = false;
            this.btnDetailRegister.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnDetailRegister.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnDetailRegister.Click += new System.EventHandler(this.btnDetailRegister_Click);
            // 
            // btnBulkRegister
            // 
            this.btnBulkRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnBulkRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBulkRegister.FlatAppearance.BorderSize = 0;
            this.btnBulkRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBulkRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBulkRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBulkRegister.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBulkRegister.Image = ((System.Drawing.Image)(resources.GetObject("btnBulkRegister.Image")));
            this.btnBulkRegister.Location = new System.Drawing.Point(360, 6);
            this.btnBulkRegister.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnBulkRegister.MouseDownImage")));
            this.btnBulkRegister.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnBulkRegister.MouseLeaveImage")));
            this.btnBulkRegister.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnBulkRegister.MouseMoveImage")));
            this.btnBulkRegister.Name = "btnBulkRegister";
            this.btnBulkRegister.Size = new System.Drawing.Size(113, 22);
            this.btnBulkRegister.TabIndex = 23;
            this.btnBulkRegister.TabStop = false;
            this.btnBulkRegister.Text = "     一括登録";
            this.btnBulkRegister.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnBulkRegister, "選択された受注に明細を自動的に登録します");
            this.btnBulkRegister.UseVisualStyleBackColor = false;
            this.btnBulkRegister.Visible = false;
            this.btnBulkRegister.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnBulkRegister.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnBulkRegister.Click += new System.EventHandler(this.btnBulkRegister_Click);
            // 
            // btnSubjectUpdate
            // 
            this.btnSubjectUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnSubjectUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSubjectUpdate.FlatAppearance.BorderSize = 0;
            this.btnSubjectUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSubjectUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSubjectUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubjectUpdate.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSubjectUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnSubjectUpdate.Image")));
            this.btnSubjectUpdate.Location = new System.Drawing.Point(480, 87);
            this.btnSubjectUpdate.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnSubjectUpdate.MouseDownImage")));
            this.btnSubjectUpdate.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnSubjectUpdate.MouseLeaveImage")));
            this.btnSubjectUpdate.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnSubjectUpdate.MouseMoveImage")));
            this.btnSubjectUpdate.Name = "btnSubjectUpdate";
            this.btnSubjectUpdate.Size = new System.Drawing.Size(113, 22);
            this.btnSubjectUpdate.TabIndex = 13;
            this.btnSubjectUpdate.TabStop = false;
            this.btnSubjectUpdate.Text = "件名変更";
            this.btnSubjectUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnSubjectUpdate, "選択された受注に明細を自動的に登録します");
            this.btnSubjectUpdate.UseVisualStyleBackColor = false;
            this.btnSubjectUpdate.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnSubjectUpdate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnSubjectUpdate.Click += new System.EventHandler(this.btnSubjectUpdate_Click);
            // 
            // btnMergeByJyutyuNo
            // 
            this.btnMergeByJyutyuNo.BackColor = System.Drawing.Color.Transparent;
            this.btnMergeByJyutyuNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMergeByJyutyuNo.FlatAppearance.BorderSize = 0;
            this.btnMergeByJyutyuNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMergeByJyutyuNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMergeByJyutyuNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMergeByJyutyuNo.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMergeByJyutyuNo.Image = ((System.Drawing.Image)(resources.GetObject("btnMergeByJyutyuNo.Image")));
            this.btnMergeByJyutyuNo.Location = new System.Drawing.Point(718, 87);
            this.btnMergeByJyutyuNo.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnMergeByJyutyuNo.MouseDownImage")));
            this.btnMergeByJyutyuNo.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnMergeByJyutyuNo.MouseLeaveImage")));
            this.btnMergeByJyutyuNo.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnMergeByJyutyuNo.MouseMoveImage")));
            this.btnMergeByJyutyuNo.Name = "btnMergeByJyutyuNo";
            this.btnMergeByJyutyuNo.Size = new System.Drawing.Size(113, 22);
            this.btnMergeByJyutyuNo.TabIndex = 15;
            this.btnMergeByJyutyuNo.TabStop = false;
            this.btnMergeByJyutyuNo.Text = "    明細No統合";
            this.btnMergeByJyutyuNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnMergeByJyutyuNo, "複数の受注データをひとつに統合します");
            this.btnMergeByJyutyuNo.UseVisualStyleBackColor = false;
            this.btnMergeByJyutyuNo.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnMergeByJyutyuNo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnMergeByJyutyuNo.Click += new System.EventHandler(this.btnMergeByJyutyuNo_Click);
            // 
            // btnTVTimeMergeByJyutyuNo
            // 
            this.btnTVTimeMergeByJyutyuNo.BackColor = System.Drawing.Color.Transparent;
            this.btnTVTimeMergeByJyutyuNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnTVTimeMergeByJyutyuNo.FlatAppearance.BorderSize = 0;
            this.btnTVTimeMergeByJyutyuNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTVTimeMergeByJyutyuNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTVTimeMergeByJyutyuNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTVTimeMergeByJyutyuNo.Image = ((System.Drawing.Image)(resources.GetObject("btnTVTimeMergeByJyutyuNo.Image")));
            this.btnTVTimeMergeByJyutyuNo.Location = new System.Drawing.Point(837, 87);
            this.btnTVTimeMergeByJyutyuNo.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnTVTimeMergeByJyutyuNo.MouseDownImage")));
            this.btnTVTimeMergeByJyutyuNo.MouseLeaveImage = ((System.Drawing.Image)(resources.GetObject("btnTVTimeMergeByJyutyuNo.MouseLeaveImage")));
            this.btnTVTimeMergeByJyutyuNo.MouseMoveImage = ((System.Drawing.Image)(resources.GetObject("btnTVTimeMergeByJyutyuNo.MouseMoveImage")));
            this.btnTVTimeMergeByJyutyuNo.Name = "btnTVTimeMergeByJyutyuNo";
            this.btnTVTimeMergeByJyutyuNo.Size = new System.Drawing.Size(113, 22);
            this.btnTVTimeMergeByJyutyuNo.TabIndex = 16;
            this.btnTVTimeMergeByJyutyuNo.TabStop = false;
            this.btnTVTimeMergeByJyutyuNo.Text = "  TVタイム統合";
            this.btnTVTimeMergeByJyutyuNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnTVTimeMergeByJyutyuNo, "テレビタイムの受注データを受注明細No毎に統合します");
            this.btnTVTimeMergeByJyutyuNo.UseVisualStyleBackColor = false;
            this.btnTVTimeMergeByJyutyuNo.MouseLeave += new System.EventHandler(this.MouseLeaveCommon);
            this.btnTVTimeMergeByJyutyuNo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveCommon);
            this.btnTVTimeMergeByJyutyuNo.Click += new System.EventHandler(this.btnTVTimeMergeByJyutyuNo_Click);
            // 
            // lblByosuValue
            // 
            this.lblByosuValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblByosuValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblByosuValue.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblByosuValue.Location = new System.Drawing.Point(706, 12);
            this.lblByosuValue.Name = "lblByosuValue";
            this.lblByosuValue.Size = new System.Drawing.Size(31, 14);
            this.lblByosuValue.TabIndex = 28;
            this.lblByosuValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSeikyuValue
            // 
            this.lblSeikyuValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeikyuValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeikyuValue.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSeikyuValue.Location = new System.Drawing.Point(562, 12);
            this.lblSeikyuValue.Name = "lblSeikyuValue";
            this.lblSeikyuValue.Size = new System.Drawing.Size(100, 14);
            this.lblSeikyuValue.TabIndex = 29;
            this.lblSeikyuValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ｌｂｌSeikyu
            // 
            this.ｌｂｌSeikyu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ｌｂｌSeikyu.AutoSize = true;
            this.ｌｂｌSeikyu.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ｌｂｌSeikyu.Location = new System.Drawing.Point(481, 13);
            this.ｌｂｌSeikyu.Name = "ｌｂｌSeikyu";
            this.ｌｂｌSeikyu.Size = new System.Drawing.Size(77, 12);
            this.ｌｂｌSeikyu.TabIndex = 30;
            this.ｌｂｌSeikyu.Text = "請求金額合計";
            // 
            // lblHonsuValue
            // 
            this.lblHonsuValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHonsuValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHonsuValue.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHonsuValue.Location = new System.Drawing.Point(779, 12);
            this.lblHonsuValue.Name = "lblHonsuValue";
            this.lblHonsuValue.Size = new System.Drawing.Size(31, 14);
            this.lblHonsuValue.TabIndex = 31;
            this.lblHonsuValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ｌｂｌHonsu
            // 
            this.ｌｂｌHonsu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ｌｂｌHonsu.AutoSize = true;
            this.ｌｂｌHonsu.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ｌｂｌHonsu.Location = new System.Drawing.Point(746, 13);
            this.ｌｂｌHonsu.Name = "ｌｂｌHonsu";
            this.ｌｂｌHonsu.Size = new System.Drawing.Size(29, 12);
            this.ｌｂｌHonsu.TabIndex = 32;
            this.ｌｂｌHonsu.Text = "本数";
            // 
            // lblDenpaValue
            // 
            this.lblDenpaValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDenpaValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDenpaValue.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDenpaValue.Location = new System.Drawing.Point(1070, 12);
            this.lblDenpaValue.Name = "lblDenpaValue";
            this.lblDenpaValue.Size = new System.Drawing.Size(100, 14);
            this.lblDenpaValue.TabIndex = 33;
            this.lblDenpaValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ｌｂｌByosu
            // 
            this.ｌｂｌByosu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ｌｂｌByosu.AutoSize = true;
            this.ｌｂｌByosu.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ｌｂｌByosu.Location = new System.Drawing.Point(673, 13);
            this.ｌｂｌByosu.Name = "ｌｂｌByosu";
            this.ｌｂｌByosu.Size = new System.Drawing.Size(29, 12);
            this.ｌｂｌByosu.TabIndex = 34;
            this.ｌｂｌByosu.Text = "秒数";
            // 
            // ｌｂｌDenpa
            // 
            this.ｌｂｌDenpa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ｌｂｌDenpa.AutoSize = true;
            this.ｌｂｌDenpa.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ｌｂｌDenpa.Location = new System.Drawing.Point(1001, 13);
            this.ｌｂｌDenpa.Name = "ｌｂｌDenpa";
            this.ｌｂｌDenpa.Size = new System.Drawing.Size(65, 12);
            this.ｌｂｌDenpa.TabIndex = 35;
            this.ｌｂｌDenpa.Text = "電波料合計";
            // 
            // lblToriRyokinValue
            // 
            this.lblToriRyokinValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToriRyokinValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblToriRyokinValue.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblToriRyokinValue.Location = new System.Drawing.Point(890, 12);
            this.lblToriRyokinValue.Name = "lblToriRyokinValue";
            this.lblToriRyokinValue.Size = new System.Drawing.Size(100, 14);
            this.lblToriRyokinValue.TabIndex = 36;
            this.lblToriRyokinValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ｌｂｌToriRyokin
            // 
            this.ｌｂｌToriRyokin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ｌｂｌToriRyokin.AutoSize = true;
            this.ｌｂｌToriRyokin.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ｌｂｌToriRyokin.Location = new System.Drawing.Point(821, 13);
            this.ｌｂｌToriRyokin.Name = "ｌｂｌToriRyokin";
            this.ｌｂｌToriRyokin.Size = new System.Drawing.Size(65, 12);
            this.ｌｂｌToriRyokin.TabIndex = 37;
            this.ｌｂｌToriRyokin.Text = "取料金合計";
            // 
            // DetailLion
            // 
            this.AplId = "DTL_Lion";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1192, 808);
            this.Controls.Add(this.btnSubjectUpdate);
            this.Controls.Add(this.btnMergeByJyutyuNo);
            this.Controls.Add(this.btnTVTimeMergeByJyutyuNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1200, 842);
            this.Name = "DetailLion";
            this.Shown += new System.EventHandler(this.DetailLion_Shown);
            this.ProcessAffterNavigating += new Isid.NJ.View.Base.BaseForm.PrcessAffterNavigatingEventHandler(this.DetailLion_ProcessAffterNavigating);
            this.Controls.SetChildIndex(this.btnTVTimeMergeByJyutyuNo, 0);
            this.Controls.SetChildIndex(this.btnMergeByJyutyuNo, 0);
            this.Controls.SetChildIndex(this.btnSubjectUpdate, 0);
            this.Controls.SetChildIndex(this.btnUpdateCheck, 0);
            this.Controls.SetChildIndex(this.btnRegJyutyu, 0);
            this.Controls.SetChildIndex(this.btnMerge, 0);
            this.Controls.SetChildIndex(this.btnMergeCancel, 0);
            this.Controls.SetChildIndex(this.btnYmChange, 0);
            this.Controls.SetChildIndex(this.btnDelJyutyu, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnEnd, 0);
            this.Controls.SetChildIndex(this.btnHlp, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.lblMask, 0);
            this.Controls.SetChildIndex(this.lblJyutyuListCnt, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdJyutyuDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdJyutyuDetail_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtJyuNo)).EndInit();
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            this.pnlTmSp.ResumeLayout(false);
            this.pnlTmSp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dsDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsJyutyuList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsJyutyuDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsKkhDetail)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.@__spdJyutyuList_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdKkhDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdKkhDetail_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bsJyutyuRireki)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdJyutyuRireki)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._spdJyutyuRireki_Sheet1)).EndInit();
            this.tabHed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._spdJyutyuList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKenMei)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dsDetailLion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Isid.NJ.View.Widget.NJLabel lblSagaku;
        protected Isid.NJ.View.Widget.NJLabel lblGoukei;
        internal Isid.NJ.View.Widget.NJLabel lblSagakuValue;
        internal Isid.NJ.View.Widget.NJLabel lblGoukeiValue;
        private Isid.KKH.Lion.Schema.DetailDSLion _dsDetailLion;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnSubjectUpdate;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnMergeByJyutyuNo;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnDetailInput;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnDetailDel;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnDetailRegister;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnBulkRegister;
        protected Isid.KKH.Common.KKHView.Common.Control.KkhButton btnTVTimeMergeByJyutyuNo;
        internal Isid.NJ.View.Widget.NJLabel lblByosuValue;
        protected Isid.NJ.View.Widget.NJLabel ｌｂｌHonsu;
        internal Isid.NJ.View.Widget.NJLabel lblHonsuValue;
        protected Isid.NJ.View.Widget.NJLabel ｌｂｌSeikyu;
        internal Isid.NJ.View.Widget.NJLabel lblSeikyuValue;
        internal Isid.NJ.View.Widget.NJLabel lblDenpaValue;
        internal Isid.NJ.View.Widget.NJLabel lblToriRyokinValue;
        protected Isid.NJ.View.Widget.NJLabel ｌｂｌDenpa;
        protected Isid.NJ.View.Widget.NJLabel ｌｂｌByosu;
        protected Isid.NJ.View.Widget.NJLabel ｌｂｌToriRyokin;
    }
}
