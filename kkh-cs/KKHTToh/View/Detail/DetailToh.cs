using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;

using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Toh.Schema;
using Isid.KKH.Toh.Utility;


namespace Isid.KKH.Toh.View.Detail
{
    public partial class DetailToh : DetailForm
    {

        #region �萔.

        /// <summary>
        /// �A�v��ID
        /// </summary>
        private const String APLID = "DtlToh";
        /// <summary>
        /// ������C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_KENMEI = 0;
        /// <summary>
        /// �}�̖���C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_BAITAINM = 1;
        /// <summary>
        /// ������C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_RYOUKIN = 2;
        // ����őΉ� 2013/10/08 update HLC H.Watabe start
        /// <summary>
        /// ����ŗ���C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_SHOHIZEI = 3;
        /// <summary>
        /// �X�y�[�X��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_SPACE = 3;
        public const int COLIDX_MLIST_SPACE = 4;
        /// <summary>
        /// �X�y�[�X�Q��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_SPACE2 = 4;
        public const int COLIDX_MLIST_SPACE2 = 5;
        /// <summary>
        /// �P����C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_TANKA = 5;
        public const int COLIDX_MLIST_TANKA = 6;
        /// <summary>
        /// �敪��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_KBN = 6;
        public const int COLIDX_MLIST_KBN = 7;
        /// <summary>
        /// �f�ړ���C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_KEISAIDT = 7;
        public const int COLIDX_MLIST_KEISAIDT = 8;
        /// <summary>
        /// �}�̃R�[�h��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_BAITAICD = 8;
        public const int COLIDX_MLIST_BAITAICD = 9;
        /// <summary>
        /// ��NO��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_JYUTNO = 9;
        public const int COLIDX_MLIST_JYUTNO = 10;
        /// <summary>
        /// �󒍖���NO��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_JYMEINO = 10;
        public const int COLIDX_MLIST_JYMEINO = 11;
        /// <summary>
        /// ���㖾��NO��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_URMEINO = 11;
        public const int COLIDX_MLIST_URMEINO = 12;
        /// <summary>
        /// �����ύXFLG��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_KENMEICHGFLG = 12;
        public const int COLIDX_MLIST_KENMEICHGFLG = 13;
        /// <summary>
        /// �[�i�敪��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_NOUHINKBN = 13;
        public const int COLIDX_MLIST_NOUHINKBN = 14;
        /// <summary>
        /// �g�t���O�C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_WAKFLG = 14;
        public const int COLIDX_MLIST_WAKFLG = 15;
        // ����őΉ� 2013/10/08 update HLC H.Watabe end

        #endregion �萔.

        #region �����o�ϐ�.

        private KKHNaviParameter _naviParameter = new KKHNaviParameter();

        #endregion �����o�ϐ�.

        #region �R���X�g���N�^.

        /// <summary>
        /// �R���X�g���N�^.
        /// </summary>
        public DetailToh()
        {
            InitializeComponent();
        }

        #endregion �R���X�g���N�^.

        #region �I�[�o�[���C�h.

        /// <summary>
        /// �X�v���b�h�S�̂ɑ΂��鏉���\���̐ݒ���s��.
        /// </summary>
        protected override void InitDesignForSpdJyutyuListSpread()
        {
            base.InitDesignForSpdJyutyuListSpread();
        }

        /// <summary>
        /// �X�v���b�h�̗�ɑ΂��鏉���\���̐ݒ���s��.
        /// </summary>
        /// <param name="col"></param>
        protected override void InitDesignForSpdJyutyuListColumns(Column col)
        {
            base.InitDesignForSpdJyutyuListColumns(col);

        }

        /// <summary>
        /// ���Ӑ�ʂɕ\���ΏۊO��̔�\���������s��.
        /// </summary>
        protected override void VisibleColumns()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s.
            base.VisibleColumns();

            foreach (Column col in base._spdJyutyuList_Sheet1.Columns)
            {
                if (col.Index == COLIDX_JLIST_TOROKU) { col.Visible = true; }                  //�o�^.
                if (col.Index == COLIDX_JLIST_TOGO) { col.Visible = false; }                   //����.
                if (col.Index == COLIDX_JLIST_DAIUKE){ col.Visible = true; }                   //���.
                if (col.Index == COLIDX_JLIST_SEIKYU) { col.Visible = false; }                 //����.
                if (col.Index == COLIDX_JLIST_URIMEINO) { col.Visible = true; }                //���㖾��NO.
                if (col.Index == COLIDX_JLIST_GPYNO) { col.Visible = false; }                  //�������[NO.
                if (col.Index == COLIDX_JLIST_SEIYYMM){ col.Visible = true; }                  //�����N��.
                if (col.Index == COLIDX_JLIST_GYOMKBN){ col.Visible = true; }                  //�Ɩ��敪.
                if (col.Index == COLIDX_JLIST_KENMEI){ col.Visible = true; }                   //����.
                if (col.Index == COLIDX_JLIST_BAITAINM) { col.Visible = true;}                 //�}�̖�.
                if (col.Index == COLIDX_JLIST_HIMOKUNM){ col.Visible = true; }                 //��ږ�.
                if (col.Index == COLIDX_JLIST_KYOKUSHICD){ col.Visible = false; }              //�ǎ�CD.
                if (col.Index == COLIDX_JLIST_SEIKINGAKU){ col.Visible = true; }               //�������z.
                if (col.Index == COLIDX_JLIST_KIKAN){ col.Visible = false; }                   //����.
                if (col.Index == COLIDX_JLIST_DANTANKA){ col.Visible = true; }                 //�i�P��.
                if (col.Index == COLIDX_JLIST_DANSU){ col.Visible = true; }                    //�i��.
                if (col.Index == COLIDX_JLIST_TORIRYOKIN){ col.Visible = true; }               //�旿��.
                if (col.Index == COLIDX_JLIST_NEBIKIRITSU){ col.Visible = true; }              //�l����.
                if (col.Index == COLIDX_JLIST_NEBIKIGAKU){ col.Visible = true; }               //�l���z.
                if (col.Index == COLIDX_JLIST_ZEIRITSU){ col.Visible = true; }                 //����ŗ�.
                if (col.Index == COLIDX_JLIST_ZEIGAKU){ col.Visible = true; }                  //����Ŋz.
                if (col.Index == COLIDX_JLIST_GOUKEIKINGAKU){ col.Visible = false; }           //�󒍐������z.
                if (col.Index == COLIDX_JLIST_OLDSEIYYMM){ col.Visible = true; }               //�ύX�O�����N��.
            }
        }

        /// <summary>
        /// �Z���̐F�t���������s��.
        /// </summary>
        protected override void ChangeColor()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s.
            base.ChangeColor();

            for (int i = 0; i < _spdJyutyuList_Sheet1.Rows.Count; i++)
            {
                Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(i);
                if (dataRow.hb1TouFlg == "1")
                {
                    //�����t���O="1"�̍s�͔w�i�F��ύX.
                    _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(255, 255, 208);
                }
                if (dataRow.hb1YymmOld != "")
                {
                    //�ύX�O�����N�����ݒ肳��Ă���(�N���ύX���s���Ă���)�ꍇ�͐����N����ԕ����ɂ���.
                    _spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_SEIYYMM].ForeColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// �L����׃f�[�^�̌����E�\��.
        /// </summary>
        /// <param name="rowIdx"></param>
        protected override void DisplayKkhDetail(int rowIdx)
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s.
            base.DisplayKkhDetail(rowIdx);

            //***************************************
            //�\���p�L����׃f�[�^�̕ҏW�E�\��.
            //***************************************
            _dsDetailToh.KkhDetail.Clear();
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow row in _dsDetail.THB2KMEI.Rows)
            {
                DetailDSToh.KkhDetailRow addRow = _dsDetailToh.KkhDetail.NewKkhDetailRow();

                addRow.kenmei = row.hb2Name8;
                addRow.baitaiNm = row.hb2Name2;
                addRow.ryoukin = row.hb2SeiGak;
                // ����őΉ� 2013/10/08 add HLC H.Watabe start
                addRow.shohizei = row.hb2Ritu1;
                // ����őΉ� 2013/10/08 add HLC H.Watabe end
                addRow.space = row.hb2Code1;
                addRow.space2 = row.hb2Name11;
                addRow.tanka = row.hb2Kngk1;
                addRow.kbn = row.hb2Kbn1;
                if (row.hb2Date1.Trim().Length == 8)
                {
                    addRow.keisaiDt = row.hb2Date1.Insert(6, "/").Insert(4, "/");
                }
                else
                {
                    addRow.keisaiDt = row.hb2Date1;
                }
                addRow.baitaiCd = row.hb2Code2;
                addRow.jyutNo = row.hb2JyutNo;
                addRow.jyMeiNo = row.hb2JyMeiNo;
                addRow.urMeiNo = row.hb2UrMeiNo;
                addRow.kenmeiChgFlg = row.hb2MeihnFlg;
                addRow.nouhinKbn = row.hb2Kbn2;
                addRow.wakFlg = row.hb2Name12;

                _dsDetailToh.KkhDetail.AddKkhDetailRow(addRow);
            }
            _dsDetailToh.KkhDetail.AcceptChanges();

            ////�X�v���b�h�f�U�C���̍ď�����.
            //InitializeDesignForSpdKkhDetail();
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(0, 0, 1, 1);
            }

            //�󒍓o�^���e�̑I���s���̎擾.
            SheetView activeSheet = GetActiveSheetViewBySpdJyutyuList();
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(rowIdx);

            //***************************************
            //�{�^���ނ̎g�p�E�s�ݒ�.
            //***************************************
            if (dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.NewsPaper)
            {
                //�����敪���u�V���v�͖��׊֌W�̃{�^���g�p��.
                btnDetailInput.Enabled = true;
                btnDetailDel.Enabled = true;
                btnDetailRegister.Enabled = true;
                btnDivide.Enabled = true;
            }
            else
            {
                //�����敪���u�V���v�ȊO�͖��׊֌W�̃{�^���g�p�s��.
                btnDetailInput.Enabled = false;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = false;
                btnDivide.Enabled = false;
            }

            if (_dsDetailToh.KkhDetail.Rows.Count > 0)
            {
                //�L����׃f�[�^�����ɂ���ꍇ�͕����E�폜�͉�.
                btnDetailDel.Enabled = true;
                btnDivide.Enabled = true;
            }
            else
            {
                //�L����׃f�[�^���Ȃ��ꍇ�͕����E�폜�͕s��.
                btnDetailDel.Enabled = false;
                btnDivide.Enabled = false;
            }

            //******************************
            //���z�E�v���x��.
            //******************************
            //���z�v�Z.
            CalculateSagaku(dataRow);
        }

        /// <summary>
        /// �󒍓o�^���e�����O�`�F�b�N����.
        /// </summary>
        /// <returns></returns>
        protected override Boolean CheckBeforeSearch()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s.
            if (base.CheckBeforeSearch() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// �󒍓o�^���e�����O�N���A����.
        /// </summary>
        protected override void InitializeBeforeSearch()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s.
            base.InitializeBeforeSearch();

            //���z�E�v���x��.
            lblGoukeiValue.Text = "";
            lblSagakuValue.Text = "";

            //***************************************
            //�{�^���ނ̎g�p�E�s�ݒ�.
            //***************************************
            btnBulkRegister.Enabled = false;
            btnDetailInput.Enabled = false;
            btnDivide.Enabled = false;
            btnDetailDel.Enabled = false;
            btnDetailRegister.Enabled = false;
        }

        /// <summary>
        /// �󒍓o�^���e������`�F�b�N����.
        /// </summary>
        /// <returns></returns>
        protected override Boolean CheckAfterSearch()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s.
            if (base.CheckAfterSearch() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// �󒍓o�^���e�����㏉���\������.
        /// </summary>
        protected override void InitializeAfterSearch()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s.
            base.InitializeAfterSearch();

            //***************************************
            //�{�^���ނ̎g�p�E�s�ݒ�.
            //***************************************
            EnableChangeForAfterSearch();
        }

        /// <summary>
        /// �󒍍폜�������s�O�`�F�b�N.
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeDelJyutyu()
        {
            if (base.CheckBeforeDelJyutyu() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// �󒍍폜��̏���������.
        /// </summary>
        protected override void InitAfterDelJyutyu()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s.
            base.InitAfterDelJyutyu();

            //�폜�̌��ʁA�\������f�[�^���Ȃ��Ȃ����ꍇ.
            if (_spdJyutyuList_Sheet1.Rows.Count == 0)
            {
                //�{�^���̎g�p�s��.
                btnBulkRegister.Enabled = false;
                btnDetailInput.Enabled = false;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = false;
                btnDivide.Enabled = false;
                btnUpdateCheck.Enabled = false;
                //���z�E�v.
                lblSagakuValue.Text = "";
                lblGoukeiValue.Text = "";

                return;
            }
        }

        /// <summary>
        /// �N���ύX�������s�O�`�F�b�N.
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeYmChange()
        {
            if (base.CheckBeforeYmChange() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// �V�K�쐬�_�C�A���O�\���O�`�F�b�N.
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeRegJyutyu()
        {
            return base.CheckBeforeRegJyutyu();
        }

        /// <summary>
        /// MouseMove�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseMoveCommon(object sender, MouseEventArgs e)
        {
            base.MouseMoveCommon(sender, e);
        }

        /// <summary>
        /// MouseLeave�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseLeaveCommon(object sender, EventArgs e)
        {
            base.MouseLeaveCommon(sender, e);
        }

        /// <summary>
        /// �󒍓o�^���e(�ꗗ)�Ńt�H�[�J�X������r���[�ɂ���ăR���g���[���̐�����s��.
        /// </summary>
        /// <param name="activeSheet">�A�N�e�B�u�̃V�[�g</param>
        /// <param name="activeRow">�A�N�e�B�u�sIndex</param>
        protected override void EnableChangeForSelectJyutyuListRow(SheetView activeSheet, int activeRow)
        {
            base.EnableChangeForSelectJyutyuListRow(activeSheet, activeRow);

            //�󒍓o�^����(�e)�V�[�g���A�N�e�B�u�̏ꍇ.
            if (activeSheet == _spdJyutyuList_Sheet1)
            {
                //�󒍓o�^���e������̏�Ԃɂ���.
                EnableChangeForAfterSearch();
            }
            else
            {
                //�q�r���[�Ƀt�H�[�J�X������ꍇ�̓f�[�^������s���{�^���͎g�p�����Ȃ�.
                btnBulkRegister.Enabled = false;
                //�A�N�e�B�u�Ȃ̂��q�r���[�̏ꍇ�͖��׊֌W�̃{�^���g�p�s��.
                btnDetailInput.Enabled = false;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = false;
                btnDivide.Enabled = false;
                btnUpdateCheck.Enabled = false;
            }
        }

        /// <summary>
        /// �󒍃X�v���b�h�^�u��ύX�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void tabHed_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.tabHed_SelectedIndexChanged(sender, e);

            //[�ڍׁ^����]�^�u���I�����ꂽ�ꍇ.
            if (tabHed.SelectedIndex == 1)
            {
                ////[���׍쐬]���\���Ƃ���.
                //_spdJyutyuRireki_Sheet1.Columns[COLIDX_JRIREKI_DTLTOROKU].Visible = false;

                //�󒍗����X�v���b�h�̌�������������.
                int rowCnt = _spdJyutyuRireki_Sheet1.RowCount - 1;
                if (rowCnt > -1)
                {
                    for (int i = rowCnt; i > -1; i--)
                    {
                        //[���׍쐬]�����ȊO�̏ꍇ.
                        if (!_spdJyutyuRireki_Sheet1.Cells[i, COLIDX_JRIREKI_DTLTOROKU].Value.Equals("��"))
                        {
                            //�s���폜����.
                            _spdJyutyuRireki_Sheet1.Rows[i].Remove();
                        }
                    }
                }
                //[���׍쐬]���\���Ƃ���.
                _spdJyutyuRireki_Sheet1.Columns[COLIDX_JRIREKI_DTLTOROKU].Visible = false;
            }

        }

        /// <summary>
        /// �󒍃`�F�b�N.
        /// </summary>
        /// <returns></returns>
        protected override bool UpdateCheckClick()
        {
            if (base.UpdateCheckClick() == false)
            {
                return false;
            }

            // �I�y���[�V�������O�̏o��.
            KKHLogUtilityToh.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityToh.KINO_ID_OPERATION_LOG_UpdCheck, KKHLogUtilityToh.DESC_OPERATION_LOG_UpdCheck);

            return true;
        }

        #endregion �I�[�o�[���C�h.

        #region �C�x���g.

        /// <summary>
        /// ��ʑJ�ڂ��邽�тɔ������܂��B.
        /// </summary>
        /// <param name="sender">�J�ڌ��t�H�[��</param>
        /// <param name="arg">�C�x���g�f�[�^</param>
        private void DetailToh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParameter = (KKHNaviParameter)arg.NaviParameter;
            }

            //�I����Ԃ�����.
            this.ActiveControl = null;
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailToh_Shown(object sender, EventArgs e)
        {
            InitializeControlToh();
            InitializeDesignForSpdKkhDetail();
        }

        /// <summary>
        /// ���ד��̓{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailInput_Click(object sender, EventArgs e)
        {
            // �Ώۂ̎󒍃f�[�^�A���׃f�[�^�擾.
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);
            int rowDetailIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;
            // ���ד��͉�ʕ\��.
            KKHNaviParameter naviParam = new KKHNaviParameter();
            naviParam = _naviParameter;
            naviParam.DataRow = dataRow;
            naviParam.RowDetailIndex = rowDetailIndex;
            naviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1;
            object result = Navigator.ShowModalForm(this, "toDetailInputToh", naviParam);
            if (result == null)
            {
                this.ActiveControl = null;
                return;
            }
            base.kkhDetailUpdFlag = true; //�L����וύX�t���O���X�V.

            // ���z�v�Z.
            CalculateSagaku(dataRow);
            // �{�^����������.
            btnDivide.Enabled = true;
            btnDetailDel.Enabled = true;
            this.ActiveControl = null;
        }

        /// <summary>
        /// �����{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDivide_Click(object sender, EventArgs e)
        {
            // �Ώۂ̎󒍃f�[�^�A���׃f�[�^�擾.
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);
            int rowDetailIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

            // �s�̒ǉ��i�I���s�̏�ɒǉ��j.
            _spdKkhDetail_Sheet1.AddRows(rowDetailIndex,1);

            // �I���s�̓��e��ǉ��s�ɐݒ�.
            for (int i = 0; i < _spdKkhDetail_Sheet1.ColumnCount; i++)
            {
                _spdKkhDetail_Sheet1.Cells[rowDetailIndex, i].Value = _spdKkhDetail_Sheet1.Cells[rowDetailIndex +1, i].Text;
            }
            _spdKkhDetail_Sheet1.ActiveRowIndex = rowDetailIndex + 1;
            _spdKkhDetail_Sheet1.AddSelection(_spdKkhDetail_Sheet1.ActiveRowIndex, -1, 1, -1);

            // ���ד��͉�ʕ\��.
            KKHNaviParameter naviParam = new KKHNaviParameter();
            naviParam.DataRow = dataRow;
            naviParam.RowDetailIndex = rowDetailIndex + 1;
            naviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1;
            object result = Navigator.ShowModalForm(this, "toDetailInputToh", naviParam);

            if (result == null)
            {
                _spdKkhDetail_Sheet1.RemoveRows(rowDetailIndex, 1);
                _spdKkhDetail_Sheet1.ActiveRowIndex = rowDetailIndex;
                _spdKkhDetail_Sheet1.AddSelection(_spdKkhDetail_Sheet1.ActiveRowIndex, -1, 1, -1);

                //�I����Ԃ�����.
                this.ActiveControl = null;

                return;
            }
            base.kkhDetailUpdFlag = true; //�L����וύX�t���O���X�V.

            // ���z�v�Z.
            CalculateSagaku(dataRow);

            //�I����Ԃ�����.
            this.ActiveControl = null;
        }

        /// <summary>
        /// ���דo�^�{�^���N���b�N�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailRegister_Click(object sender, EventArgs e)
        {
            //string message = "";
            decimal sagaku = 0M;

            if (decimal.TryParse(lblSagakuValue.Text, out sagaku) == false || sagaku == 0M)
            {
                if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_C0002, null, "���דo�^", MessageBoxButtons.YesNo))
                {
                    //�I����Ԃ�����.
                    this.ActiveControl = null;
                    return;
                }
            }
            else
            {
                if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_W0089, null, "���דo�^", MessageBoxButtons.YesNo))
                {
                    //�I����Ԃ�����.
                    this.ActiveControl = null;
                    return;
                }
            }

            RegistDetailData();

            //�I����Ԃ�����.
            this.ActiveControl = null;
        }

        /// <summary>
        /// �ꊇ�{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBulkRegister_Click(object sender, EventArgs e)
        {
            //���s�m�F.
            if (DialogResult.OK != MessageUtility.ShowMessageBox(MessageCode.HB_C0021,
                null, "�ꊇ�o�^", MessageBoxButtons.OKCancel))
            {
                this.ActiveControl = null;
                return;
            }

            // ���ʍ��ڂ̐ݒ�.
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();
            String esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            String aplId = "DtlToh";//TODO
            String egCd = _naviParameter.strEgcd;
            String tksKgyCd = _naviParameter.strTksKgyCd;
            String tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            String tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            Isid.KKH.Common.KKHSchema.Detail TouKoudsDetail = new Isid.KKH.Common.KKHSchema.Detail();

            // �I������Ă���s���擾.
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();
            CellRange[] cellRangeArray = _spdJyutyuList_Sheet1.GetSelections();

            // �Ώی���.
            int subjectCount = 0;
            // �ΏۃX�v���b�h��INDEX���X�g.
            ArrayList subjectIndexList = new ArrayList();

            // �I������Ă���s�̌������A�J��Ԃ�.
            foreach (CellRange cellRange in cellRangeArray)
            {
                for (int rowIndex = cellRange.Row; rowIndex < cellRange.Row + cellRange.RowCount; rowIndex++)
                {
                    // �Ώۍs�̃f�[�^���擾.
                    Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(rowIndex);
                    Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();
                    Isid.KKH.Toh.View.Detail.DetailInputToh detailInputToh = new DetailInputToh();
                    Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow TouKoudsDetailaddrow = TouKoudsDetail.THB1DOWN.NewTHB1DOWNRow();

                    // �����敪���u�V���v�ȊO�̏ꍇ�A���̍s��.
                    if (dataRow.hb1SeiKbn != KKHSystemConst.SeiKbn.NewsPaper)
                    {
                        continue;
                    }

                    // ���ז��o�^���A�}�̃R�[�h������ꍇ.
                    if (string.IsNullOrEmpty(_spdJyutyuList_Sheet1.Cells[rowIndex, COLIDX_JLIST_TOROKU].Value.ToString().Trim())
                        && !string.IsNullOrEmpty(dataRow.hb1Field1.ToString().Trim()))
                    {
                        //THB1DOWN�̓o�^�f�[�^�ҏW.
                        thb1DownRow.hb1TimStmp = dataRow.hb1TimStmp;
                        thb1DownRow.hb1UpdApl = dataRow.hb1UpdApl;
                        thb1DownRow.hb1UpdTnt = dataRow.hb1UpdTnt;
                        thb1DownRow.hb1AtuEgCd = dataRow.hb1AtuEgCd;
                        thb1DownRow.hb1EgCd = dataRow.hb1EgCd;
                        thb1DownRow.hb1TksKgyCd = dataRow.hb1TksKgyCd;
                        thb1DownRow.hb1TksBmnSeqNo = dataRow.hb1TksBmnSeqNo;
                        thb1DownRow.hb1TksTntSeqNo = dataRow.hb1TksTntSeqNo;
                        thb1DownRow.hb1JyutNo = dataRow.hb1JyutNo;
                        thb1DownRow.hb1JyMeiNo = dataRow.hb1JyMeiNo;
                        thb1DownRow.hb1UrMeiNo = dataRow.hb1UrMeiNo;
                        thb1DownRow.hb1GpyNo = dataRow.hb1GpyNo;
                        thb1DownRow.hb1GpyoPag = dataRow.hb1GpyoPag;
                        thb1DownRow.hb1SeiNo = dataRow.hb1SeiNo;
                        thb1DownRow.hb1HimkCd = dataRow.hb1HimkCd;
                        thb1DownRow.hb1TouFlg = dataRow.hb1TouFlg;
                        thb1DownRow.hb1Yymm = dataRow.hb1Yymm;
                        thb1DownRow.hb1GyomKbn = dataRow.hb1GyomKbn;
                        thb1DownRow.hb1MsKbn = dataRow.hb1MsKbn;
                        thb1DownRow.hb1TmspKbn = dataRow.hb1TmspKbn;
                        thb1DownRow.hb1KokKbn = dataRow.hb1KokKbn;
                        thb1DownRow.hb1SeiKbn = dataRow.hb1SeiKbn;
                        thb1DownRow.hb1SyoNo = dataRow.hb1SyoNo;
                        thb1DownRow.hb1KKNameKJ = dataRow.hb1KKNameKJ;
                        thb1DownRow.hb1EgGamenType = dataRow.hb1EgGamenType;
                        thb1DownRow.hb1KkakShanKbn = dataRow.hb1KkakShanKbn;
                        thb1DownRow.hb1ToriGak = dataRow.hb1ToriGak;
                        thb1DownRow.hb1SeiTnka = dataRow.hb1SeiTnka;
                        thb1DownRow.hb1SeiGak = dataRow.hb1SeiGak;
                        thb1DownRow.hb1NeviRitu = dataRow.hb1NeviRitu;
                        thb1DownRow.hb1NeviGak = dataRow.hb1NeviGak;
                        thb1DownRow.hb1SzeiKbn = dataRow.hb1SzeiKbn;
                        thb1DownRow.hb1SzeiRitu = dataRow.hb1SzeiRitu;
                        thb1DownRow.hb1SzeiGak = dataRow.hb1SzeiGak;
                        thb1DownRow.hb1HimkNmKJ = dataRow.hb1HimkNmKJ;
                        thb1DownRow.hb1HimkNmKN = dataRow.hb1HimkNmKN;
                        thb1DownRow.hb1TJyutNo = dataRow.hb1TJyutNo;
                        thb1DownRow.hb1TJyMeiNo = dataRow.hb1TJyMeiNo;
                        thb1DownRow.hb1TUrMeiNo = dataRow.hb1TUrMeiNo;
                        thb1DownRow.hb1MSeiFlg = dataRow.hb1MSeiFlg;
                        thb1DownRow.hb1YymmOld = dataRow.hb1YymmOld;
                        thb1DownRow.hb1Field1 = dataRow.hb1Field1;
                        thb1DownRow.hb1Field2 = dataRow.hb1Field2;
                        thb1DownRow.hb1Field3 = dataRow.hb1Field3;
                        thb1DownRow.hb1Field4 = dataRow.hb1Field4;
                        thb1DownRow.hb1Field5 = dataRow.hb1Field5;
                        thb1DownRow.hb1Field6 = dataRow.hb1Field6;
                        thb1DownRow.hb1Field7 = dataRow.hb1Field7;
                        thb1DownRow.hb1Field8 = dataRow.hb1Field8;
                        thb1DownRow.hb1Field9 = dataRow.hb1Field9;
                        thb1DownRow.hb1Field10 = dataRow.hb1Field10;
                        thb1DownRow.hb1Field11 = dataRow.hb1Field11;
                        thb1DownRow.hb1Field12 = dataRow.hb1Field12;

                        //���ׂ��쐬����̂�"1"��ݒ�.
                        thb1DownRow.hb1MeisaiFlg = "1";

                        //�o�^�S���҂��󂩂X�V�҂���łȂ��ꍇ.
                        if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim())
                            && !string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                        {
                            //�o�^�ҁA�X�V�җ��������.
                            //�o�^��.
                            thb1DownRow.hb1TrkTnt = _naviParameter.strEsqId.Trim();
                            //�o�^�Җ�.
                            thb1DownRow.hb1TrkTntNm = _naviParameter.strName.Trim();
                            //�X�V��.
                            thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                            //�X�V�S���Җ�.
                            thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                        }
                        //�o�^�҂���̏ꍇ.
                        else if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()))
                        {
                            //�o�^�҂݂̂�����.
                            //�o�^��.
                            thb1DownRow.hb1TrkTnt = _naviParameter.strEsqId.Trim();
                            //�o�^�Җ�.
                            thb1DownRow.hb1TrkTntNm = _naviParameter.strName.Trim();
                            //�X�V��.
                            thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                            //�X�V�S���Җ�.
                            thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                        }
                        else
                        {
                            //�X�V�҂݂̂�����.
                            //�X�V��.
                            thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                            //�X�V�S���Җ�.
                            thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                        }

                        //�X�y�[�X�Q.
                        thb1DownRow.space2 = detailInputToh.space2ConversionMethod(dataRow.hb1Field11);

                        dtThb1Down.AddTHB1DOWNRow(thb1DownRow);
                        subjectCount++;
                        subjectIndexList.Add(rowIndex);

                        //�f�[�^����������Ă���ꍇ�A�q�̌��ƂȂ����f�[�^�ɓo�^�S���ҁA�X�V�҂�o�^����B.
                        if (dataRow.hb1TouFlg.Equals("1"))
                        {
                            TouKoudsDetailaddrow.hb1UpdApl = base.AplId;
                            TouKoudsDetailaddrow.hb1UpdTnt = _naviParameter.strEsqId;
                            TouKoudsDetailaddrow.hb1EgCd = _naviParameter.strEgcd;
                            TouKoudsDetailaddrow.hb1TksKgyCd = _naviParameter.strTksKgyCd;
                            TouKoudsDetailaddrow.hb1TksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
                            TouKoudsDetailaddrow.hb1TksTntSeqNo = _naviParameter.strTksTntSeqNo;
                            TouKoudsDetailaddrow.hb1Yymm = dataRow.hb1Yymm;
                            TouKoudsDetailaddrow.hb1TouFlg = dataRow.hb1TouFlg;
                            TouKoudsDetailaddrow.hb1JyutNo = dataRow.hb1JyutNo;
                            TouKoudsDetailaddrow.hb1JyMeiNo = dataRow.hb1JyMeiNo;
                            TouKoudsDetailaddrow.hb1UrMeiNo = dataRow.hb1UrMeiNo;
                            TouKoudsDetailaddrow.hb1MeisaiFlg = "1";
                            if (!string.IsNullOrEmpty(thb1DownRow.hb1TrkTntNm))
                            {
                                TouKoudsDetailaddrow.hb1TrkTnt = thb1DownRow.hb1TrkTnt;
                                TouKoudsDetailaddrow.hb1TrkTntNm = thb1DownRow.hb1TrkTntNm;
                            }
                            else
                            {
                                TouKoudsDetailaddrow.hb1TrkTnt = null;
                                TouKoudsDetailaddrow.hb1TrkTntNm = null;
                            }
                            if (!string.IsNullOrEmpty(thb1DownRow.hb1KsnTntNm))
                            {
                                TouKoudsDetailaddrow.hb1KsnTnt = thb1DownRow.hb1KsnTnt;
                                TouKoudsDetailaddrow.hb1KsnTntNm = thb1DownRow.hb1KsnTntNm;
                            }
                            else
                            {
                                TouKoudsDetailaddrow.hb1KsnTnt = null;
                                TouKoudsDetailaddrow.hb1KsnTntNm = null;
                            }
                            TouKoudsDetail.THB1DOWN.AddTHB1DOWNRow(TouKoudsDetailaddrow);
                        }
                    }
                }
            }

            // �Ώۃf�[�^�����݂��Ȃ��ꍇ.
            if (subjectCount == 0)
            {
                //�I����Ԃ�����.
                this.ActiveControl = null;
                return;
            }

            dsDetail.THB1DOWN.Merge(dtThb1Down);

            // �ꊇ�o�^�T�[�r�X.
            DetailProcessController processController = DetailProcessController.GetInstance();
            RegisterBulkDataServiceResult result = processController.RegisterBulkData(
                esqId, aplId, egCd, tksKgyCd, tksBmnSeqNo, tksTntSeqNo, dsDetail, TouKoudsDetail);

            // �G���[�̏ꍇ.
            if (result.HasError)
            {
                String[] message = result.Note;
                //MessageBox.Show(message[0], "���דo�^", MessageBoxButtons.OK); //TODO
                MessageUtility.ShowMessageBox(MessageCode.HB_W0148, message, "���דo�^", MessageBoxButtons.OK);
                //MessageUtility.ShowMessageBox(MessageCode.HB_W0095, message, "���דo�^", MessageBoxButtons.OK);

                //�I����Ԃ�����.
                this.ActiveControl = null;
                return;
            }

            foreach (Object obj in subjectIndexList)
            {
                DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow((int)obj)];
                Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
                listRow.toroku = "��";
            }

            //MessageBox.Show("�o�^���������܂����B", "���דo�^", MessageBoxButtons.OK);
            MessageUtility.ShowMessageBox(MessageCode.HB_I0001, null, "���דo�^", MessageBoxButtons.OK);

            //���݈ʒu�̎擾.
            int _spdJyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            //�󒍓��e�Č�������.
            base.ReSearchJyutyuData();

            //�w��s�����̈ʒu�ɖ߂�.
            _spdJyutyuList_Sheet1.SetActiveCell(_spdJyutyuListRowIdx, 0, true);
            _spdJyutyuList_Sheet1.AddSelection(_spdJyutyuListRowIdx, -1, 1, -1);
            spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

            //�e�̏������Ă�(�e��LeaveCell�C�x���g���������Ȃ��̂�).
            base.DisplayKkhDetail(_spdJyutyuListRowIdx);
            //�q�̏������Ă�(�e�����Ă�ł���Ȃ��̂�).
            DisplayKkhDetail(_spdJyutyuListRowIdx);

            //�I����Ԃ�����.
            this.ActiveControl = null;
        }

        /// <summary>
        /// ���׍폜�{�^��������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailDel_Click(object sender, EventArgs e)
        {
            int rowIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

            _spdKkhDetail_Sheet1.RemoveRows(rowIndex, 1);
            base.kkhDetailUpdFlag = true; //�L����וύX�t���O���X�V.

            //***************************************
            //�{�^���ނ̎g�p�E�s�ݒ�.
            //***************************************
            if (_spdKkhDetail_Sheet1.Rows.Count > 0)
            {
                //�L����׃f�[�^�����ɂ���ꍇ�͕����E�폜�͉�.
                btnDetailDel.Enabled = true;
                btnDivide.Enabled = true;
            }
            else
            {
                //�L����׃f�[�^���Ȃ��ꍇ�͕����E�폜�͕s��.
                btnDetailDel.Enabled = false;
                btnDivide.Enabled = false;
            }

            //******************************
            //���z�E�v���x��.
            //******************************
            //�󒍓o�^���e�̑I���s���̎擾.
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);
            //���z�v�Z.
            CalculateSagaku(dataRow);

            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(_spdKkhDetail_Sheet1.ActiveRowIndex, -1, 1, -1);
            }

            //�I����Ԃ�����.
            this.ActiveControl = null;
        }

        /// <summary>
        /// �w���v�{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //���Ӑ�R�[�h.
            string tkskgy = _naviParameter.strTksKgyCd + _naviParameter.strTksBmnSeqNo + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //���s.
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Detail, this, HelpNavigator.KeywordIndex);
            //HlpClick();
            this.ActiveControl = null;
        }

        #endregion �C�x���g.

        #region ���\�b�h.

        /// <summary>
        /// ���z�v�Z.
        /// </summary>
        /// <param name="dataRow"></param>
        private void CalculateSagaku(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            // �������v.
            decimal ryoukinGoukei = 0;

            // ���ׂ̌������A�J��Ԃ�.
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                String ryoukinStr = _spdKkhDetail_Sheet1.Cells[i, 2].Text.Trim();
                // ���ׂ̗��������͂���Ă���ꍇ.
                if (KKHUtility.IsNumeric(ryoukinStr))
                {
                    // �������v�ɉ��Z.
                    ryoukinGoukei = ryoukinGoukei + decimal.Parse(ryoukinStr.Trim());
                }
            }
            // ���z.
            decimal sagaku = dataRow.hb1SeiGak - ryoukinGoukei;
            lblSagakuValue.Text = sagaku.ToString("###,###,###,##0");
            // ���v.
            lblGoukeiValue.Text = ryoukinGoukei.ToString("###,###,###,##0");
        }

        /// <summary>
        /// �L����ׂ̃f�[�^�\�[�X�X�V.
        /// </summary>
        /// <param name="dsDetailToh"></param>
        private void UpdateDataSourceByDetailDataSetToh(DetailDSToh dsDetailToh)
        {
            _dsDetailToh.Clear();
            _dsDetailToh.Merge(_dsDetailToh);
            _dsDetailToh.AcceptChanges();
        }

        /// <summary>
        /// �e�R���g���[���̏����ݒ�.
        /// </summary>
        private void InitializeControlToh()
        {
            //******************
            //����������.
            //******************
            lblKenMei.Visible = false;
            txtKenMei.Visible = false;
            lblKikan.Visible = false;
            txtYmdTo.Visible = false;

            //��̏��Ԃ�ύX����.
            //[�}�̖�]��[��ږ�]�����ւ���.
            _spdJyutyuList_Sheet1.MoveColumn(COLIDX_JLIST_BAITAINM, COLIDX_JLIST_HIMOKUNM, true);

            //*******************
            //�{�^����.
            // �ύX�E�폜�`�F�b�N�{�^�����\��.
            //*******************
            btnBulkRegister.Enabled = false;
            btnDetailInput.Enabled = false;
            btnDetailDel.Enabled = false;
            btnDivide.Enabled = false;
            btnDetailRegister.Enabled = false;
        }

        /// <summary>
        /// �L����׃X�v���b�h�̃f�U�C�����������s��.
        /// </summary>
        private void InitializeDesignForSpdKkhDetail()
        {
            //********************************
            //�X�v���b�h�S�̂̐ݒ�.
            //********************************
            _spdKkhDetail_Sheet1.ColumnHeader.Rows[0].Height = 30;

            //********************************
            //�񖈂̐ݒ� ���f�U�C�i�����ɑ΂���ݒ���s���ƕύX�����f����Ȃ����Ƃ�����悤�Ȃ̂Ŏb��I�ɂ����ōs��.
            //********************************
            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                //���ʐݒ�.
                col.Locked = true;//�Z���̕ҏW�s��.
                col.AllowAutoFilter = true;//�t�B���^�@�\��L��.
                col.AllowAutoSort = true;  //�\�[�g�@�\��L��.

                //�񖈂ɈقȂ�ݒ�.
                if (col.Index == COLIDX_MLIST_KENMEI)
                {
                    col.Label = "����";
                    col.Width = 200;
                }
                else if (col.Index == COLIDX_MLIST_BAITAINM)
                {
                    col.Label = "�}�̖�";
                    col.Width = 150;
                }
                else if (col.Index == COLIDX_MLIST_RYOUKIN)
                {
                    col.Label = "����";
                    //col.Width = 100;
                    col.Width = 90;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                // ����őΉ� 2013/10/08 add HLC H.Watabe start
                else if (col.Index == COLIDX_MLIST_SHOHIZEI)
                {
                    col.Label = "����ŗ�";
                    col.Width = 70;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = false;
                    col.CellType = cellType;
                }
                // ����őΉ� 2013/10/08 add HLC H.Watabe end
                else if (col.Index == COLIDX_MLIST_SPACE)
                {
                    col.Label = "�X�y�[�X";
                    col.Width = 70;
                }
                else if (col.Index == COLIDX_MLIST_SPACE2)
                {
                    col.Label = "�X�y�[�X2";
                    col.Width = 70;
                }
                else if (col.Index == COLIDX_MLIST_TANKA)
                {
                    col.Label = "�P��";
                    //col.Width = 100;
                    col.Width = 90;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                else if (col.Index == COLIDX_MLIST_KBN)
                {
                    col.Label = "�敪";
                    //col.Width = 50;
                    col.Width = 40;
                }
                else if (col.Index == COLIDX_MLIST_KEISAIDT)
                {
                    col.Label = "�f�ړ�";
                    col.Width = 80;
                }
                else if (col.Index == COLIDX_MLIST_BAITAICD)
                {
                    col.Label = "�}�̃R�[�h";
                    col.Width = 80;
                }
                else if (col.Index == COLIDX_MLIST_JYUTNO)
                {
                    col.Label = "��NO";
                    col.Width = 80;
                }
                else if (col.Index == COLIDX_MLIST_JYMEINO)
                {
                    col.Label = "�󒍖���NO";
                    col.Width = 60;
                }
                else if (col.Index == COLIDX_MLIST_URMEINO)
                {
                    col.Label = "���㖾��NO";
                    col.Width = 60;
                }
                else if (col.Index == COLIDX_MLIST_KENMEICHGFLG)
                {
                    col.Label = "�����ύXFLG";
                    col.Width = 60;
                }
                else if (col.Index == COLIDX_MLIST_NOUHINKBN)
                {
                    col.Label = "�[�i�敪";
                    col.Width = 40;
                }
                else if (col.Index == COLIDX_MLIST_WAKFLG)
                {
                    col.Label = "�gFLG";
                    col.Width = 30;
                }
            }

            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(0, 0, 1, 1);
            }
        }

        /// <summary>
        /// �󒍓o�^���e������̊e�R���g���[���̊����^�񊈐��ݒ�.
        /// </summary>
        private void EnableChangeForAfterSearch()
        {
            btnBulkRegister.Enabled = true;
        }

        /// <summary>
        /// ���דo�^����.
        /// </summary>
        private void RegistDetailData()
        {
            //���[�f�B���O�\���J�n.
            base.ShowLoadingDialog();

            //�T�[�r�X�p�����[�^�p�ϐ�.
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();
            string esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            //DateTime maxUpdDate = new DateTime(2100,1,1);
            DateTime maxUpdDate = new DateTime();

            //*********************************************
            //THB1DOWN�̓o�^�f�[�^�ҏW.
            //*********************************************
            //DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(_spdJyutyuList_Sheet1.ActiveRowIndex)];
            //Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            //Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);

            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();

            //thb1DownRow.hb1TimStmp = new DateTime();
            thb1DownRow.hb1UpdApl = AplId;
            thb1DownRow.hb1UpdTnt = _naviParameter.strEsqId;
            thb1DownRow.hb1EgCd = _naviParameter.strEgcd;
            thb1DownRow.hb1TksKgyCd = _naviParameter.strTksKgyCd;
            thb1DownRow.hb1TksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            thb1DownRow.hb1TksTntSeqNo = _naviParameter.strTksTntSeqNo;
            thb1DownRow.hb1Yymm = dataRow.hb1Yymm;
            thb1DownRow.hb1TouFlg = dataRow.hb1TouFlg;
            thb1DownRow.hb1JyutNo = dataRow.hb1JyutNo;
            thb1DownRow.hb1JyMeiNo = dataRow.hb1JyMeiNo;
            thb1DownRow.hb1UrMeiNo = dataRow.hb1UrMeiNo;

            //�������t���O.
            if (Isid.KKH.Common.KKHUtility.KKHUtility.DecParse(lblSagakuValue.Text) == 0)
            {
                thb1DownRow.hb1MSeiFlg = "0";
            }
            else
            {
                thb1DownRow.hb1MSeiFlg = "1";
            }

            //���׍s�����݂���ꍇ.
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                thb1DownRow.hb1MeisaiFlg = "1";
            }
            else
            {
                thb1DownRow.hb1MeisaiFlg = "0";
            }
            //***************************************
            //�o�^�ҁA�X�V�҂̓o�^
            //***************************************
            thb1DownRow.hb1TrkTnt = string.Empty;
            thb1DownRow.hb1TrkTntNm = string.Empty;
            thb1DownRow.hb1KsnTnt = string.Empty;
            thb1DownRow.hb1KsnTntNm = string.Empty;
            //���ׂ��Ȃ��ꍇ
            if (thb1DownRow.hb1MeisaiFlg.Equals("0"))
            {
                //�o�^�ҁA�X�V�҂���̏ꍇ
                if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) && string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                    //�������Ȃ�
                }
                //�o�^�҂�����ŁA�X�V�҂������Ă���ꍇ
                else if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) && !string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                    //�������Ȃ�
                }
                else
                {
                    //�X�V�҂�o�^
                    //�X�V��
                    thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                    //�X�V�S���Җ�
                    thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                }
            }
            //���ׂ�����ꍇ
            else
            {
                //�o�^�S���҂��󂩂X�V�҂���łȂ��ꍇ
                if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) && !string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                    //�o�^�ҁA�X�V�җ��������
                    //�o�^��
                    thb1DownRow.hb1TrkTnt = _naviParameter.strEsqId.Trim();
                    //�o�^�Җ�
                    thb1DownRow.hb1TrkTntNm = _naviParameter.strName.Trim();
                    //�X�V��
                    thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                    //�X�V�S���Җ�
                    thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                }
                //�o�^�҂���̏ꍇ
                else if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()))
                {
                    //�o�^�҂݂̂�����
                    //�o�^��
                    thb1DownRow.hb1TrkTnt = _naviParameter.strEsqId.Trim();
                    //�o�^�Җ�
                    thb1DownRow.hb1TrkTntNm = _naviParameter.strName.Trim();
                    //�X�V��
                    thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                    //�X�V�S���Җ�
                    thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                }
                else
                {
                    //�X�V�҂݂̂�����
                    //�X�V��
                    thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                    //�X�V�S���Җ�
                    thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                }
            }

            dtThb1Down.AddTHB1DOWNRow(thb1DownRow);

            dsDetail.THB1DOWN.Merge(dtThb1Down);

            Isid.KKH.Common.KKHSchema.Detail TouKoudsDetail = new Isid.KKH.Common.KKHSchema.Detail();
            //�f�[�^����������Ă���ꍇ�A�q�̌��ƂȂ����f�[�^�ɓo�^�S���ҁA�X�V�҂�o�^����B
            if (dataRow.hb1TouFlg.Equals("1"))
            {
                Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow tokoaddrow = TouKoudsDetail.THB1DOWN.NewTHB1DOWNRow();
                tokoaddrow.hb1UpdApl = base.AplId;
                tokoaddrow.hb1UpdTnt = _naviParameter.strEsqId;
                tokoaddrow.hb1EgCd = _naviParameter.strEgcd;
                tokoaddrow.hb1TksKgyCd = _naviParameter.strTksKgyCd;
                tokoaddrow.hb1TksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
                tokoaddrow.hb1TksTntSeqNo = _naviParameter.strTksTntSeqNo;
                tokoaddrow.hb1Yymm = dataRow.hb1Yymm;
                tokoaddrow.hb1TouFlg = dataRow.hb1TouFlg;
                tokoaddrow.hb1JyutNo = dataRow.hb1JyutNo;
                tokoaddrow.hb1JyMeiNo = dataRow.hb1JyMeiNo;
                tokoaddrow.hb1UrMeiNo = dataRow.hb1UrMeiNo;
                tokoaddrow.hb1MeisaiFlg = thb1DownRow.hb1MeisaiFlg;
                if (!string.IsNullOrEmpty(thb1DownRow.hb1TrkTntNm))
                {
                    tokoaddrow.hb1TrkTnt = thb1DownRow.hb1TrkTnt;
                    tokoaddrow.hb1TrkTntNm = thb1DownRow.hb1TrkTntNm;
                }
                else
                {
                    tokoaddrow.hb1TrkTnt = null;
                    tokoaddrow.hb1TrkTntNm = null;
                }
                if (!string.IsNullOrEmpty(thb1DownRow.hb1KsnTntNm))
                {
                    tokoaddrow.hb1KsnTnt = thb1DownRow.hb1KsnTnt;
                    tokoaddrow.hb1KsnTntNm = thb1DownRow.hb1KsnTntNm;
                }
                else
                {
                    tokoaddrow.hb1KsnTnt = null;
                    tokoaddrow.hb1KsnTntNm = null;
                }
                TouKoudsDetail.THB1DOWN.AddTHB1DOWNRow(tokoaddrow);
            }

            //*********************************************
            //THB2KMEI�̓o�^�f�[�^�ҏW.
            //*********************************************
            int jyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;
            Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable dtThb2Kmei = new Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable();
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                object cellValue = null;

                Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow addRow = dtThb2Kmei.NewTHB2KMEIRow();

                addRow.hb2TimStmp = new DateTime();
                addRow.hb2UpdApl = AplId;
                addRow.hb2UpdTnt = _naviParameter.strEsqId;
                addRow.hb2EgCd = _naviParameter.strEgcd;
                addRow.hb2TksKgyCd = _naviParameter.strTksKgyCd;
                addRow.hb2TksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
                addRow.hb2TksTntSeqNo = _naviParameter.strTksTntSeqNo;
                addRow.hb2Yymm = dataRow.hb1Yymm;
                addRow.hb2JyutNo = dataRow.hb1JyutNo;
                addRow.hb2JyMeiNo = dataRow.hb1JyMeiNo;
                addRow.hb2UrMeiNo = dataRow.hb1UrMeiNo;
                addRow.hb2HimkCd = dataRow.hb1HimkCd;
                //addRow.hb2Renbn = (i + 1).ToString("000"); ���דo�^�����g���Ή�.
                addRow.hb2Renbn = (i + 1).ToString("0000");
                addRow.hb2DateFrom = " ";
                addRow.hb2DateTo = " ";
                addRow.hb2SeiGak = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_RYOUKIN].Value;
                addRow.hb2Hnnert = 0M;
                addRow.hb2HnmaeGak = 0M;
                addRow.hb2NebiGak = 0M;
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEISAIDT].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Date1 = cellValue.ToString().Replace("/", "");
                }
                else
                {
                    addRow.hb2Date1 = " ";
                }
                addRow.hb2Date2 = " ";
                addRow.hb2Date3 = " ";
                addRow.hb2Date4 = " ";
                addRow.hb2Date5 = " ";
                addRow.hb2Date6 = " ";
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KBN].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Kbn1 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Kbn1 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NOUHINKBN].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Kbn2 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Kbn2 = " ";
                }
                addRow.hb2Kbn3 = " ";
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SPACE].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Code1 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Code1 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Code2 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Code2 = " ";
                }
                addRow.hb2Code3 = " ";
                addRow.hb2Code4 = " ";
                addRow.hb2Code5 = " ";
                addRow.hb2Code6 = " ";
                addRow.hb2Name1 = " ";
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAINM].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name2 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name2 = " ";
                }
                addRow.hb2Name3 = " ";
                addRow.hb2Name4 = " ";
                addRow.hb2Name5 = " ";
                addRow.hb2Name6 = " ";
                addRow.hb2Name7 = " ";
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name8 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name8 = " ";
                }
                addRow.hb2Name9 = " ";
                addRow.hb2Name10 = " ";
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SPACE2].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name11 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name11 = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_WAKFLG].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name12 = cellValue.ToString();
                }
                else
                {
                    addRow.hb2Name12 = " ";
                }

                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TANKA].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Kngk1 = (Decimal)cellValue;
                }
                else
                {
                    addRow.hb2Kngk1 = 0M;
                }
                addRow.hb2Kngk2 = 0M;
                addRow.hb2Kngk3 = 0M;
                // ����őΉ� 2013/10/08 update HLC H.Watabe start
                addRow.hb2Ritu1 = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHOHIZEI].Value;
                //addRow.hb2Ritu1 = 0M;
                // ����őΉ� 2013/10/08 update HLC H.Watabe end
                addRow.hb2Ritu2 = 0M;
                addRow.hb2Sonota1 = " ";
                addRow.hb2Sonota2 = " ";
                addRow.hb2Sonota3 = " ";
                addRow.hb2Sonota4 = " ";
                addRow.hb2Sonota5 = " ";
                addRow.hb2Sonota6 = " ";
                addRow.hb2Sonota7 = " ";
                addRow.hb2Sonota8 = " ";
                addRow.hb2Sonota9 = " ";
                addRow.hb2Sonota10 = " ";
                if (_spdKkhDetail_Sheet1.RowCount >= 2)
                {
                    addRow.hb2BunFlg = "1";
                }
                else
                {
                    addRow.hb2BunFlg = " ";
                }
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEICHGFLG].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2MeihnFlg = cellValue.ToString();
                }
                else
                {
                    addRow.hb2MeihnFlg = " ";
                }
                addRow.hb2NebhnFlg = " ";

                dtThb2Kmei.AddTHB2KMEIRow(addRow);
            }
            dsDetail.THB2KMEI.Merge(dtThb2Kmei);
            //dsDetail.AcceptChanges();

            //�X�V���t�ő�l�̔���.
            //��������Ă���ꍇ.
            if (dataRow.hb1TouFlg == "1")
            {
                //��������Ă���󒍓o�^���e�̃f�[�^����X�V���t�̍ő�l���擾����B.
                Isid.KKH.Common.KKHUtility.KKHGetMaxUpdDateByTogo getMaxUpdDateByTogo = new KKHGetMaxUpdDateByTogo();
                maxUpdDate = getMaxUpdDateByTogo.GetMaxUpdDateByTogo(
                            _spdJyutyuList_Sheet1,
                            dataRow.hb1TimStmp,
                            _dsDetail);
            }
            else
            {
                if (maxUpdDate == null || maxUpdDate.CompareTo(dataRow.hb1TimStmp) < 0)
                {
                    maxUpdDate = dataRow.hb1TimStmp;
                }
            }

            foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow thb2KmeiRow in _dsDetail.THB2KMEI.Rows)
            {
                if (maxUpdDate == null || maxUpdDate.CompareTo(thb2KmeiRow.hb2TimStmp) < 0)
                {
                    maxUpdDate = thb2KmeiRow.hb2TimStmp;
                }
            }
            //foreach (Isid.KKH.Common.KKHSchema.Detail.TGA7MSHORow tga7MshoRow in _dsDetail.TGA7MSHO.Rows)
            //{
            //    if (maxUpdDate == null || maxUpdDate.CompareTo(tga7MshoRow.ga7TimStmp) < 0)
            //    {
            //        maxUpdDate = tga7MshoRow.ga7TimStmp;
            //    }
            //}

            DetailProcessController processController = DetailProcessController.GetInstance();
            //UpdateDisplayDataServiceResult result = processController.UpdateDisplayData(esqId, dsDetail, maxUpdDate);
            DetailProcessController.UpdateDisplayDataParam param = new DetailProcessController.UpdateDisplayDataParam();
            param.esqId = esqId;
            param.dsDetail = dsDetail;
            param.maxUpdDate = maxUpdDate;
            param.TouKoudsDetail = TouKoudsDetail;
            UpdateDisplayDataServiceResult result = processController.UpdateDisplayData(param);

            //�G���[�̏ꍇ.
            if (result.HasError)
            {

                //���[�f�B���O�\���I��.
                base.CloseLoadingDialog();

                if (result.MessageCode == "LOCK-E0001")
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0148, null, "���דo�^", MessageBoxButtons.OK);
                }
                else
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0003, null, "���דo�^", MessageBoxButtons.OK);
                }
                return;
            }

            base.kkhDetailUpdFlag = false; //�L����וύX�t���O���X�V.
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                //���דo�^"��"��ݒ�.
                //listRow.toroku = "��";
                _spdJyutyuList_Sheet1.Cells[_spdJyutyuList_Sheet1.ActiveRowIndex, COLIDX_JLIST_TOROKU].Value = "��";
            }
            else
            {
                //���דo�^"��"������.
                //listRow.toroku = "";
                _spdJyutyuList_Sheet1.Cells[_spdJyutyuList_Sheet1.ActiveRowIndex, COLIDX_JLIST_TOROKU].Value = "";
            }

            //TODO
            //******************************************************************************************
            //�ێ����Ă���󒍓o�^���e�f�[�^��������̃f�[�^�ōX�V����.
            //******************************************************************************************
            //foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow updRow in result.DsDetail.THB1DOWN.Rows)
            //{
            //    _dsDetail.JyutyuData.UpdateRowDataByTGADOWNRow(updRow);
            //    _dsDetail.THB1DOWN.UpdateRowData(updRow);
            //}
            //_dsDetail.JyutyuData.AcceptChanges();
            //_dsDetail.THB1DOWN.AcceptChanges();
            //_dsDetail.THB2KMEI.Clear();
            //_dsDetail.THB2KMEI.Merge(result.DsDetail.THB2KMEI);
            //_dsDetail.THB2KMEI.AcceptChanges();
            ////���݈ʒu�̎擾.
            //int _spdJyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            //base.SearchJyutyuData();

            ////�w��s�����̈ʒu�ɖ߂�.
            //_spdJyutyuList_Sheet1.SetActiveCell(_spdJyutyuListRowIdx, 0, true);
            //_spdJyutyuList_Sheet1.AddSelection(_spdJyutyuListRowIdx, -1, 1, -1);
            //spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

            ////�e�̏������Ă�(�e��LeaveCell�C�x���g���������Ȃ��̂�).
            //base.DisplayKkhDetail(_spdJyutyuListRowIdx);
            ////�q�̏������Ă�(�e�����Ă�ł���Ȃ��̂�).
            //DisplayKkhDetail(_spdJyutyuListRowIdx);

            DisplayUpdate();

            //���[�f�B���O�\���I��.
            base.CloseLoadingDialog();

            //MessageBox.Show("�L����ׂ̓o�^���������܂����B", "���דo�^", MessageBoxButtons.OK);
            MessageUtility.ShowMessageBox(MessageCode.HB_I0012, null, "���דo�^", MessageBoxButtons.OK);
        }

        /// <summary>
        /// ��������Ă���󒍓o�^���e�̃f�[�^����X�V���t�̍ő�l���擾����B.
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="parentMaxUpdDate"></param>
        /// <returns></returns>
        private DateTime GetMaxUpdDateByTogo(int rowIndex, DateTime parentMaxUpdDate)
        {
            DateTime maxUpdDate = new DateTime();

            FarPoint.Win.Spread.SheetView childSheet = _spdJyutyuList_Sheet1.GetChildView(rowIndex, 0);

            for (int i = 0; i < childSheet.Rows.Count; i++)
            {
                Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow childRow = _dsDetail.JyutyuData.FindByrowNum((int)childSheet.Cells[i, COLIDX_JLIST_ROWNUM].Value);

                //�q�^�C���X�^���v���e���傫���ꍇ.
                if (parentMaxUpdDate < childRow.hb1TimStmp)
                {
                    //�q�^�C���X�^���v���ϐ����傫���ꍇ.
                    if (maxUpdDate < childRow.hb1TimStmp)
                    {
                        maxUpdDate = childRow.hb1TimStmp;
                    }
                }
            }

            return maxUpdDate;
        }

        #endregion ���\�b�h.
    }
}
