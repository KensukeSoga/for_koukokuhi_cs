namespace Isid.KKH.Lion.View.Detail
{
    partial class DetailLion
    {
        /// <summary>
        /// �K�v�ȃf�U�C�i�ϐ��ł��B
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// �g�p���̃��\�[�X�����ׂăN���[���A�b�v���܂��B
        /// </summary>
        /// <param name="disposing">�}�l�[�W ���\�[�X���j�������ꍇ true�A�j������Ȃ��ꍇ�� false �ł��B</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h

        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
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
            this.������Seikyu = new Isid.NJ.View.Widget.NJLabel();
            this.lblHonsuValue = new Isid.NJ.View.Widget.NJLabel();
            this.������Honsu = new Isid.NJ.View.Widget.NJLabel();
            this.lblDenpaValue = new Isid.NJ.View.Widget.NJLabel();
            this.������Byosu = new Isid.NJ.View.Widget.NJLabel();
            this.������Denpa = new Isid.NJ.View.Widget.NJLabel();
            this.lblToriRyokinValue = new Isid.NJ.View.Widget.NJLabel();
            this.������ToriRyokin = new Isid.NJ.View.Widget.NJLabel();
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
            this.njToolTip1.SetToolTip(this.btnEnd, "���דo�^���I�����ă��j���[�ɖ߂�܂�");
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
            this.njToolTip1.SetToolTip(this.btnSch, "�f�[�^�̌����������Ȃ��܂�");
            // 
            // btnHlp
            // 
            this.btnHlp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHlp.FlatAppearance.BorderSize = 0;
            this.btnHlp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHlp.Location = new System.Drawing.Point(1109, 8);
            this.btnHlp.TabIndex = 18;
            this.njToolTip1.SetToolTip(this.btnHlp, "�w���v��\�����܂�");
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
            this.njToolTip1.SetToolTip(this.btnYmChange, "�����N����ύX���܂�");
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
            this.njToolTip1.SetToolTip(this.btnDelJyutyu, "�s�v�Ȏ󒍃f�[�^���폜���܂�");
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
            this.btnMerge.Text = "�I�𓝍�";
            this.njToolTip1.SetToolTip(this.btnMerge, "�����̎󒍃f�[�^���ЂƂɓ������܂�");
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
            this.njToolTip1.SetToolTip(this.btnMergeCancel, "�������ꂽ�󒍃f�[�^�����Ƃɖ߂��܂�");
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblToriRyokinValue);
            this.splitContainer1.Panel2.Controls.Add(this.������ToriRyokin);
            this.splitContainer1.Panel2.Controls.Add(this.������Byosu);
            this.splitContainer1.Panel2.Controls.Add(this.������Denpa);
            this.splitContainer1.Panel2.Controls.Add(this.lblDenpaValue);
            this.splitContainer1.Panel2.Controls.Add(this.lblSeikyuValue);
            this.splitContainer1.Panel2.Controls.Add(this.������Seikyu);
            this.splitContainer1.Panel2.Controls.Add(this.������Honsu);
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
            this.njToolTip1.SetToolTip(this.btnRegJyutyu, "�󒍃f�[�^��V�K�쐬���܂�");
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
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "���";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "�o�^";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "����";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "���";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "����";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "���㖾��NO";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "�������[No";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "�����N��";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "�Ɩ��敪";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "����";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "��ږ�";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "�}�̖�";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "�ǎ�CD";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "�������z";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "����";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "�i�P��";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "�i��";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "�旿��";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "�l����";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "�l���z";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "����ŗ�";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "����Ŋz";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "�󒍐������z";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "�ύX�O�����N��";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "�o�^��";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "�X�V��";
            this.@__spdJyutyuList_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "�擾�s�ԍ�";
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
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "����";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "�_�E�����[�h�^�C�~���O";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "���㖾��No";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "�����N��";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "�Ɩ��敪";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "����";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "�}�̖�";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "��ږ�";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "�ǎ�CD";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "�������z";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "����";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "�i�P��";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "�i��";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "�旿��";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "�l����";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "�l���z";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "����ŗ�";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "����Ŋz";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "�󒍐������z";
            this._spdJyutyuRireki_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "�ύX�O�����N��";
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
            this.btnDetailInput.Text = "���ד���";
            this.btnDetailInput.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnDetailInput, "�󒍓o�^���e�őI�����ꂽ�f�[�^�ɂ��čL����ׂ���͂��܂�");
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
            this.lblSagaku.Text = "���z";
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
            this.lblGoukei.Text = "�v";
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
            this.btnDetailDel.Text = "���׍폜";
            this.btnDetailDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnDetailDel, "�I������Ă���L����ׂ��폜���܂�");
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
            this.btnDetailRegister.Text = "���דo�^";
            this.btnDetailRegister.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnDetailRegister, "�\������Ă�����e�ōL����ׂ�o�^���܂�");
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
            this.btnBulkRegister.Text = "     �ꊇ�o�^";
            this.btnBulkRegister.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnBulkRegister, "�I�����ꂽ�󒍂ɖ��ׂ������I�ɓo�^���܂�");
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
            this.btnSubjectUpdate.Text = "�����ύX";
            this.btnSubjectUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnSubjectUpdate, "�I�����ꂽ�󒍂ɖ��ׂ������I�ɓo�^���܂�");
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
            this.btnMergeByJyutyuNo.Text = "    ����No����";
            this.btnMergeByJyutyuNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnMergeByJyutyuNo, "�����̎󒍃f�[�^���ЂƂɓ������܂�");
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
            this.btnTVTimeMergeByJyutyuNo.Text = "  TV�^�C������";
            this.btnTVTimeMergeByJyutyuNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.njToolTip1.SetToolTip(this.btnTVTimeMergeByJyutyuNo, "�e���r�^�C���̎󒍃f�[�^���󒍖���No���ɓ������܂�");
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
            // ������Seikyu
            // 
            this.������Seikyu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.������Seikyu.AutoSize = true;
            this.������Seikyu.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.������Seikyu.Location = new System.Drawing.Point(481, 13);
            this.������Seikyu.Name = "������Seikyu";
            this.������Seikyu.Size = new System.Drawing.Size(77, 12);
            this.������Seikyu.TabIndex = 30;
            this.������Seikyu.Text = "�������z���v";
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
            // ������Honsu
            // 
            this.������Honsu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.������Honsu.AutoSize = true;
            this.������Honsu.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.������Honsu.Location = new System.Drawing.Point(746, 13);
            this.������Honsu.Name = "������Honsu";
            this.������Honsu.Size = new System.Drawing.Size(29, 12);
            this.������Honsu.TabIndex = 32;
            this.������Honsu.Text = "�{��";
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
            // ������Byosu
            // 
            this.������Byosu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.������Byosu.AutoSize = true;
            this.������Byosu.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.������Byosu.Location = new System.Drawing.Point(673, 13);
            this.������Byosu.Name = "������Byosu";
            this.������Byosu.Size = new System.Drawing.Size(29, 12);
            this.������Byosu.TabIndex = 34;
            this.������Byosu.Text = "�b��";
            // 
            // ������Denpa
            // 
            this.������Denpa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.������Denpa.AutoSize = true;
            this.������Denpa.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.������Denpa.Location = new System.Drawing.Point(1001, 13);
            this.������Denpa.Name = "������Denpa";
            this.������Denpa.Size = new System.Drawing.Size(65, 12);
            this.������Denpa.TabIndex = 35;
            this.������Denpa.Text = "�d�g�����v";
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
            // ������ToriRyokin
            // 
            this.������ToriRyokin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.������ToriRyokin.AutoSize = true;
            this.������ToriRyokin.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.������ToriRyokin.Location = new System.Drawing.Point(821, 13);
            this.������ToriRyokin.Name = "������ToriRyokin";
            this.������ToriRyokin.Size = new System.Drawing.Size(65, 12);
            this.������ToriRyokin.TabIndex = 37;
            this.������ToriRyokin.Text = "�旿�����v";
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
        protected Isid.NJ.View.Widget.NJLabel ������Honsu;
        internal Isid.NJ.View.Widget.NJLabel lblHonsuValue;
        protected Isid.NJ.View.Widget.NJLabel ������Seikyu;
        internal Isid.NJ.View.Widget.NJLabel lblSeikyuValue;
        internal Isid.NJ.View.Widget.NJLabel lblDenpaValue;
        internal Isid.NJ.View.Widget.NJLabel lblToriRyokinValue;
        protected Isid.NJ.View.Widget.NJLabel ������Denpa;
        protected Isid.NJ.View.Widget.NJLabel ������Byosu;
        protected Isid.NJ.View.Widget.NJLabel ������ToriRyokin;
    }
}
