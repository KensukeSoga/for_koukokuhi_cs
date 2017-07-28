using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Skyp.Schema;
using Isid.KKH.Skyp.ProcessController.Detail;
using Isid.KKH.Skyp.Utility;

namespace Isid.KKH.Skyp.View.Detail
{
    /// <summary>
    /// �L����ד��͉�ʁi�X�J�p�[�j 
    /// </summary>
    public partial class DetailSkyp : DetailForm
    {
        #region �萔 

        /// <summary>
        /// �A�v��ID
        /// </summary>
        private const String APLID = "DtlSkyp";
        /// <summary>
        /// �Ɩ��敪��C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_GYOMUKBN = 0;
        /// <summary>
        /// �^�C���X�|�b�g�敪��C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_TIMESPOTKBN = 1;
        /// <summary>
        /// ������C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_KENMEI = 2;
        /// <summary>
        /// �d�ʁE�}�̖��̗�C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_DMEISYO = 3;
        /// <summary>
        /// �d�ʁE���ԗ�C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_DKIKAN = 4;
        /// <summary>
        /// �d�ʁE���e��C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_DNAIYO = 5;
        /// <summary>
        /// �旿����C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_TORIGAK = 6;
        /// <summary>
        /// �l������C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_NEBIRITU = 7;
        /// <summary>
        /// �l���z��C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_NEBIGAK = 8;
        /// <summary>
        /// �������z��C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_KINGAK = 9;
        /// <summary>
        /// ����ŗ���C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_SYOHIRITU = 10;
        /// <summary>
        /// ����Ŋz��C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_SYOHI = 11;
        /// <summary>
        /// �}�̋敪��C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_BAITAIKBN = 12;
        /// <summary>
        /// �}�̖��̗�C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_BAITAIMEI = 13;
        /// <summary>
        /// ���ڃR�[�h��C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_KOMOKUCODE = 14;
        /// <summary>
        /// ���ږ��̗�C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_KOMOKUMEI = 15;
        /// <summary>
        /// ���я��i�}�̋敪�j��C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_SEQ2 = 16;
        /// <summary>
        /// ���я���C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_SEQ1 = 17;
        /// <summary>
        /// ��NO��C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_JYUTNO = 18;
        /// <summary>
        /// �󒍖���NO��C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_JYMEINO = 19;
        /// <summary>
        /// ���㖾��NO��C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_URMEINO = 20;
        /// <summary>
        /// �������[NO��C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_GPYNO = 21;
        /// <summary>
        /// �}�̋敪��C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_BAITAIKBN2 = 22;
        /// <summary>
        /// �^�C���X�^���v��C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_TIMESTMP = 23;
        /// <summary>
        /// �e���v���[�g�R�[�h��C���f�b�N�X 
        /// </summary>
        internal const int COLIDX_MLIST_TEMPCODE = 24;

        #endregion �萔

        #region �����o�ϐ� 

        /// <summary>
        /// Rg�i�r�p�����[�^ 
        /// </summary>
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();

        #endregion �����o�ϐ� 

        #region �R���X�g���N�^ 

        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        public DetailSkyp()
        {
            InitializeComponent();
        }

        #endregion �R���X�g���N�^ 

        #region �I�[�o�[���C�h 

        /// <summary>
        /// �X�v���b�h�S�̂ɑ΂��鏉���\���̐ݒ���s�� 
        /// </summary>
        protected override void InitDesignForSpdJyutyuListSpread()
        {
            base.InitDesignForSpdJyutyuListSpread();

            // �Œ��̐ݒ� 
            base._spdJyutyuList_Sheet1.FrozenColumnCount = 6;
        }

        /// <summary>
        /// �X�v���b�h�̗�ɑ΂��鏉���\���̐ݒ���s�� 
        /// </summary>
        /// <param name="col"></param>
        protected override void InitDesignForSpdJyutyuListColumns(Column col)
        {
            base.InitDesignForSpdJyutyuListColumns(col);

            // �l�����̏ꍇ 
            if (col.Index == COLIDX_JLIST_NEBIKIRITSU)
            {
                NumberCellType cellType = (NumberCellType)col.CellType;
                cellType.DecimalPlaces = 0;
            }
            // ����ŗ��̏ꍇ 
            else if (col.Index == COLIDX_JLIST_ZEIRITSU)
            {
                NumberCellType cellType = (NumberCellType)col.CellType;
                cellType.DecimalPlaces = 0;
            }
        }

        /// <summary>
        /// ���Ӑ�ʂɕ\���ΏۊO��̔�\���������s�� 
        /// </summary>
        protected override void VisibleColumns()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s 
            base.VisibleColumns();

            foreach (Column col in base._spdJyutyuList_Sheet1.Columns)
            {
                if (col.Index == COLIDX_JLIST_TOROKU) { col.Visible = true; }                   //�o�^ 
                if (col.Index == COLIDX_JLIST_TOGO) { col.Visible = false; }                    //����  
                if (col.Index == COLIDX_JLIST_DAIUKE) { col.Visible = true; }                   //���
                if (col.Index == COLIDX_JLIST_SEIKYU) { col.Visible = false; }                  //����
                if (col.Index == COLIDX_JLIST_URIMEINO) { col.Visible = true; }                 //���㖾��NO
                if (col.Index == COLIDX_JLIST_GPYNO) { col.Visible = false; }                   //�������[NO  
                if (col.Index == COLIDX_JLIST_SEIYYMM) { col.Visible = true; }                  //�����N�� 
                if (col.Index == COLIDX_JLIST_GYOMKBN) { col.Visible = true; }                  //�Ɩ��敪 
                if (col.Index == COLIDX_JLIST_KENMEI) { col.Visible = true; }                   //���� 
                if (col.Index == COLIDX_JLIST_BAITAINM) { col.Visible = true; }                 //�}�̖� 
                if (col.Index == COLIDX_JLIST_HIMOKUNM) { col.Visible = true; }                 //��ږ� 
                if (col.Index == COLIDX_JLIST_KYOKUSHICD) { col.Visible = false; }              //�ǎ�CD(��\��) 
                if (col.Index == COLIDX_JLIST_SEIKINGAKU) { col.Visible = true; }               //�������z 
                if (col.Index == COLIDX_JLIST_KIKAN) { col.Visible = true; }                    //���� 
                if (col.Index == COLIDX_JLIST_DANTANKA) { col.Visible = false; }                //�i�P��(��\��) 
                if (col.Index == COLIDX_JLIST_DANSU) { col.Visible = false; }                   //�i��(��\��) 
                if (col.Index == COLIDX_JLIST_TORIRYOKIN) { col.Visible = true; }               //�旿�� 
                if (col.Index == COLIDX_JLIST_NEBIKIRITSU) { col.Visible = true; }              //�l���� 
                if (col.Index == COLIDX_JLIST_NEBIKIGAKU) { col.Visible = true; }               //�l���z 
                if (col.Index == COLIDX_JLIST_ZEIRITSU) { col.Visible = true; }                 //����ŗ� 
                if (col.Index == COLIDX_JLIST_ZEIGAKU) { col.Visible = true; }                  //����Ŋz 
                if (col.Index == COLIDX_JLIST_GOUKEIKINGAKU) { col.Visible = true; }            //�󒍐������z 
                if (col.Index == COLIDX_JLIST_OLDSEIYYMM) { col.Visible = true; }               //�ύX�O�����N�� 
            }
        }

        /// <summary>
        /// �Z���̐F�t���������s�� 
        /// </summary>
        protected override void ChangeColor()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s 
            base.ChangeColor();

            for (int iRow = 0; iRow < _spdJyutyuList_Sheet1.Rows.Count; iRow++)
            {
                Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(iRow);
                if (dataRow.hb1TouFlg == "1")
                {
                    //�����t���O="1"�̍s�͔w�i�F��ύX 
                    _spdJyutyuList_Sheet1.Rows[iRow].BackColor = Color.FromArgb(255, 255, 208);
                }
                if (dataRow.hb1YymmOld != "")
                {
                    //�ύX�O�����N�����ݒ肳��Ă���(�N���ύX���s���Ă���)�ꍇ�͐����N����ԕ����ɂ��� 
                    _spdJyutyuList_Sheet1.Cells[iRow, COLIDX_JLIST_SEIYYMM].ForeColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// �L����׃f�[�^�̌����E�\�� 
        /// </summary>
        /// <param name="rowIdx"></param>
        protected override void DisplayKkhDetail(int rowIdx)
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s 
            base.DisplayKkhDetail(rowIdx);

            //***************************************
            // �\���p�L����׃f�[�^�̕ҏW�E�\�� 
            //***************************************
            _dsDetailSkyp.KkhDetail.Clear();
            foreach (Common.KKHSchema.Detail.THB2KMEIRow row in _dsDetail.THB2KMEI.Rows)
            {
                DetailDSSkyp.KkhDetailRow addrow = _dsDetailSkyp.KkhDetail.NewKkhDetailRow();

                addrow.gyomukbn = row.hb2Code2;         // �Ɩ��敪 
                addrow.timespotkbn = row.hb2Kbn1;       // �^�C���X�|�b�g�敪 
                addrow.kenmei = row.hb2Name11;          // ���� 
                addrow.dmeisyo = row.hb2Name12;         // �d�ʁE�}�̖��� 
                addrow.dkikan = row.hb2Name1;           // �d�ʁE���� 
                addrow.dnaiyo = row.hb2Name10;          // �d�ʁE���e 
                addrow.torigak = row.hb2Kngk2;          // �旿�� 
                addrow.nebiritu = row.hb2Ritu1;         // �l���� 
                addrow.nebigak = row.hb2NebiGak;        // �l���z 
                addrow.kingak = row.hb2SeiGak;          // �������z 
                addrow.syohiritu = row.hb2Ritu2;        // ����ŗ� 
                addrow.syohi = row.hb2Kngk1;            // ����Ŋz 
                addrow.baitaikbn = row.hb2Name13;       // �}�̋敪 
                addrow.baitaimei = row.hb2Name7;        // �}�̖��� 
                addrow.komokucode = row.hb2Code1;       // ���ڃR�[�h 
                addrow.komokumei = row.hb2Name8;        // ���ږ��� 
                addrow.seq2 = row.hb2Sonota1;           // ���я��i�}�̋敪�j 
                addrow.seq1 = row.hb2Sonota2;           // ���я� 
                addrow.jyutno = row.hb2Name3;           // ��NO 
                addrow.jymeino = row.hb2Name4;          // �󒍖���NO 
                addrow.urmeino = row.hb2Name5;          // ���㖾��NO 
                addrow.gpyno = row.hb2Name6;            // �������[NO 
                addrow.baitaikbn2 = row.hb2Name13;      // �}�̋敪(�ۑ�) 
                addrow.timeStmp = row.hb2TimStmp;       // �^�C���X�^���v 
                addrow.templateCode = row.hb2Code3;     // �e���v���[�g�R�[�h 

                _dsDetailSkyp.KkhDetail.AddKkhDetailRow(addrow);
            }
            _dsDetailSkyp.KkhDetail.AcceptChanges();

            _spdKkhDetail_Sheet1.SetActiveCell(0, 0, true);
            _spdKkhDetail_Sheet1.AddSelection(0, -1, 1, -1);

            // �󒍓o�^���e�̑I���s���̎擾 
            Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(rowIdx);
            //***************************************
            //�{�^���ނ̎g�p�E�s�ݒ� 
            //***************************************
            btnDetailInput.Enabled = true;


            //******************************
            // ���z�E�v���x�� 
            //******************************
            // ���z�v�Z 
            CalculateSagaku(dataRow);
        }

        /// <summary>
        /// �󒍓o�^���e�����O�`�F�b�N���� 
        /// </summary>
        /// <returns></returns>
        protected override Boolean CheckBeforeSearch()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s 
            if (base.CheckBeforeSearch() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// �󒍓o�^���e�����O�N���A���� 
        /// </summary>
        protected override void InitializeBeforeSearch()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s 
            base.InitializeBeforeSearch();

            //���z�E�v���x�� 
            lblGoukeiValue.Text = "";
            lblSagakuValue.Text = "";

            //�{�^�� 
            InitializeButtonEnable(false);
        }

        /// <summary>
        /// �󒍓o�^���e������`�F�b�N���� 
        /// </summary>
        /// <returns></returns>
        protected override Boolean CheckAfterSearch()
        {
            // �e�N���X�̍s���Ă��鋤�ʏ��������s 
            if (base.CheckAfterSearch() == false)
            {
                return false;
            }
            else
            {
                //�{�^�� 
                InitializeButtonEnable(true);
                return true;
            }
        }

        /// <summary>
        /// �󒍓o�^���e�����㏉���\������ 
        /// </summary>
        protected override void InitializeAfterSearch()
        {
            // �e�N���X�̍s���Ă��鋤�ʏ��������s 
            base.InitializeAfterSearch();

            _naviParameter.StrYymm = FindJyutyuDataCond.yymm;
        }

        /// <summary>
        /// �󒍍폜���s�O�`�F�b�N���� 
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeDelJyutyu()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s 
            if (base.CheckBeforeDelJyutyu() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// �󒍍폜��̏��������� 
        /// </summary>
        protected override void InitAfterDelJyutyu()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s 
            base.InitAfterDelJyutyu();

            //�폜�̌��ʁA�\������f�[�^���Ȃ��Ȃ����ꍇ 
            if (_spdJyutyuList_Sheet1.Rows.Count == 0)
            {
                //�{�^�� 
                InitializeButtonEnable(false);

                //���z�E�v 
                lblSagakuValue.Text = "0";
                lblGoukeiValue.Text = "0";
            }
        }

        /// <summary>
        /// �N���ύX�_�C�A���O�\���O�`�F�b�N 
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeYmChange()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s 
            if (base.CheckBeforeYmChange() == false)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// �V�K�쐬�_�C�A���O�\���O�`�F�b�N 
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeRegJyutyu()
        {
            return base.CheckBeforeRegJyutyu();
        }

        /// <summary>
        /// MouseMove�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseMoveCommon(object sender, MouseEventArgs e)
        {
            base.MouseMoveCommon(sender, e);
        }

        /// <summary>
        /// MouseLeave�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseLeaveCommon(object sender, EventArgs e)
        {
            base.MouseLeaveCommon(sender, e);
        }

        /// <summary>
        /// �󒍓o�^���e(�ꗗ)�Ńt�H�[�J�X������r���[�ɂ���ăR���g���[���̐�����s�� 
        /// </summary>
        /// <param name="activeSheet">�A�N�e�B�u�̃V�[�g</param>
        /// <param name="activeRow">�A�N�e�B�u�sIndex</param>
        protected override void EnableChangeForSelectJyutyuListRow(SheetView activeSheet, int activeRow)
        {
            base.EnableChangeForSelectJyutyuListRow(activeSheet, activeRow);

            //�󒍓o�^����(�e)�V�[�g���A�N�e�B�u�̏ꍇ 
            if (activeSheet == _spdJyutyuList_Sheet1)
            {
                //���׊֌W�̃{�^���͖��׌�����̏����ɔC���� 
            }
            else
            {
                //�q�r���[�Ƀt�H�[�J�X������ꍇ�̓f�[�^������s���{�^���͎g�p�����Ȃ� 

                //���׊֌W�̃{�^���g�p�s�� 
                btnDetailInput.Enabled = false;
            }
        }

        /// <summary>
        ///  �󒍓����{�^���N���b�N���� 
        /// </summary>
        protected override void MergeClick()
        {
            //�I���s�̎擾 
            CellRange[] cellRanges = base.SortCellRangesByRowIdx(_spdJyutyuList_Sheet1.GetSelections());
            foreach (CellRange cellRange in cellRanges)
            {
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    int rowIndex = cellRange.Row + i;

                    if (_spdJyutyuList_Sheet1.RowFilter.IsRowFilteredOut(rowIndex))
                    {
                        // �t�B���^�����O�Ō����Ȃ��Ȃ��Ă���ꍇ�̓G���[��\������.
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0146, null, "���דo�^", MessageBoxButtons.OK);
                        return;
                    }

                    if (_spdJyutyuList_Sheet1.Cells[rowIndex, COLIDX_JLIST_TOROKU].Text.Equals("��"))
                    {
                        //���łɖ��דo�^���ꂽ�󒍓��e������܂�.
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0152, null, "���דo�^", MessageBoxButtons.OK);
                        return;
                    }
                }

            }
            base.MergeClick();
        }

        /// <summary>
        /// �󒍃`�F�b�N 
        /// </summary>
        /// <returns></returns>
        protected override bool UpdateCheckClick()
        {
            if (base.UpdateCheckClick() == false)
            {
                return false;
            }

            // �I�y���[�V�������O�̏o�� 
            KKHLogUtilitySkyp.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilitySkyp.KINO_ID_OPERATION_LOG_UPDCHECK, KKHLogUtilitySkyp.DESC_OPERATION_LOG_UPDCHECK);

            return true;
        }

        #endregion �I�[�o�[���C�h 

        #region �C�x���g 

        /// <summary>
        /// ��ʑJ�ڂ��邽�тɔ������܂��B 
        /// </summary>
        /// <param name="sender">�J�ڌ��t�H�[��</param>
        /// <param name="arg">�C�x���g�f�[�^</param>
        private void DetailSkyp_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParameter = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// �t�H�[��Shown�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailSkyp_Shown(object sender, EventArgs e)
        {
            InitializeButtonEnable(false);
            InitializeControlSkyp();
            InitializeDesignForSpdKkhDetail();
        }

        /// <summary>
        /// ���я��{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOrder_Click(object sender, EventArgs e)
        {
            // ���я��f�[�^���݃`�F�b�N 
            if (!CheckOrderData())
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023
                                ,null
                                , "���דo�^"
                                , MessageBoxButtons.OK);

                //�I����Ԃ����� 
                this.ActiveControl = null;

                return;
            }

            DetailOrderSkypNaviParameter naviParam = new DetailOrderSkypNaviParameter();
            naviParam.strEsqId = _naviParameter.strEsqId;
            naviParam.strEgcd = _naviParameter.strEgcd;
            naviParam.strTksKgyCd = _naviParameter.strTksKgyCd;
            naviParam.strTksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            naviParam.strTksTntSeqNo = _naviParameter.strTksTntSeqNo;
            naviParam.StrYymm = _naviParameter.StrYymm;
            naviParam.strName  = _naviParameter.strName;

            object ret = Navigator.ShowModalForm(this, "toDetailOrderSkyp", naviParam);

            if (ret != null)
            {
                // �Č���.
                DisplayUpdate();
            }

            //�I����Ԃ����� 
            this.ActiveControl = null;
        }

        /// <summary>
        /// ���ד��̓{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailInput_Click(object sender, EventArgs e)
        {
            // �Ώۂ̎󒍃f�[�^�A���׃f�[�^�擾 
            Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);
            // �󒍃_�E�����[�h�f�[�^�i��������Ă���󒍂��܂ރf�[�^�j�擾 
            string filter = "hb1TJyutNo = \'" + dataRow.hb1JyutNo + "\' AND " +
                            "hb1TJyMeiNo = \'" + dataRow.hb1JyMeiNo + "\' AND " +
                            "hb1TUrMeiNo = \'" + dataRow.hb1UrMeiNo + "\'";
            Common.KKHSchema.Detail.JyutyuDataRow[] jyutyuDataRow =
                (Common.KKHSchema.Detail.JyutyuDataRow[])_dsDetail.JyutyuData.Select(filter);

            SheetView activeSheetView = GetActiveSheetViewBySpdJyutyuList();
            int rowIndex = activeSheetView.ActiveRowIndex;

            // ���ד��͉�ʕ\�� 
            DetailInputSkypNaviParameter naviParam = new DetailInputSkypNaviParameter();
            //naviParam = (DetailInputSkypNaviParameter)_naviParameter;
            naviParam.strEsqId = _naviParameter.strEsqId;
            naviParam.strName = _naviParameter.strName;
            naviParam.strEgcd = _naviParameter.strEgcd;
            naviParam.strTksKgyCd = _naviParameter.strTksKgyCd;
            naviParam.strTksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            naviParam.strTksTntSeqNo = _naviParameter.strTksTntSeqNo;
            naviParam.DataRow = dataRow;
            naviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1;
            naviParam.AplId = AplId;
            naviParam.SeigakSum = KKHUtility.DecParse(lblGoukeiValue.Text);

            if (jyutyuDataRow != null)
            {
                if (0 < jyutyuDataRow.Length)
                {
                    // ��������Ă���󒍂����݂���ꍇ�A 
                    // �󒍃_�E�����[�h�f�[�^�i��������Ă���󒍂��܂ރf�[�^�j��ݒ肷�� 
                    naviParam.MergeDataRow = jyutyuDataRow;
                }
                else
                {
                    // ��������Ă���󒍂����݂���ꍇ�A 
                    // �󒍃_�E�����[�h�f�[�^�i��������Ă���󒍂��܂ރf�[�^�j��null 
                    naviParam.MergeDataRow = null;
                }
            }
            else
            {
                // ��������Ă���󒍂����݂���ꍇ�A 
                // �󒍃_�E�����[�h�f�[�^�i��������Ă���󒍂��܂ރf�[�^�j��null 
                naviParam.MergeDataRow = null;
            }

            object ret = Navigator.ShowModalForm(this, "toDetailInputSkyp", naviParam);

            if (ret != null)
            {
                // �Č���.
                DisplayUpdate();
            }

            //�I����Ԃ����� 
            this.ActiveControl = null;

        }

        /// <summary>
        /// �w���v�{�^���N���b�N���� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = _naviParameter.strTksKgyCd + _naviParameter.strTksBmnSeqNo + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //���s 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Detail, this, HelpNavigator.KeywordIndex);
        }
        #endregion �C�x���g 

        #region ���\�b�h 

        /// <summary>
        /// ���z�v�Z 
        /// </summary>
        /// <param name="dataRow">�󒍃_�E�����[�h�f�[�^</param>
        private void CalculateSagaku(Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            // �������v 
            decimal ryoukinGoukei = 0;

            // ���ׂ̌������A�J��Ԃ� 
            for (int iRow = 0; iRow < _spdKkhDetail_Sheet1.RowCount; iRow++)
            {
                string ryoukinStr = _spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_KINGAK].Text.Trim();
                // ���ׂ̗��������͂���Ă���ꍇ 
                if (KKHUtility.IsNumeric(ryoukinStr))
                {
                    // �������v�ɉ��Z 
                    ryoukinGoukei = ryoukinGoukei + KKHUtility.DecParse(ryoukinStr.Trim());
                }
            }
            // ���z 
            decimal sagaku = dataRow.hb1SeiGak - ryoukinGoukei;
            lblSagakuValue.Text = sagaku.ToString("###,###,###,##0");
            // ���v 
            lblGoukeiValue.Text = ryoukinGoukei.ToString("###,###,###,##0");
        }

        /// <summary>
        /// �L����׃X�v���b�h�̃f�U�C�����������s�� 
        /// </summary>
        private void InitializeDesignForSpdKkhDetail()
        {
            //********************************
            //�X�v���b�h�S�̂̐ݒ� 
            //********************************

            //********************************
            //�񖈂̐ݒ� ���f�U�C�i�����ɑ΂���ݒ���s���ƕύX�����f����Ȃ����Ƃ�����悤�Ȃ̂Ŏb��I�ɂ����ōs�� 
            //********************************
            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                //���ʐݒ� 
                col.Locked = true;//�Z���̕ҏW�s�� 
                col.AllowAutoFilter = true;//�t�B���^�@�\��L�� 
                col.AllowAutoSort = true;  //�\�[�g�@�\��L�� 

                //�񖈂ɈقȂ�ݒ� 
                if (col.Index == COLIDX_MLIST_GYOMUKBN)
                {
                    col.Label = "�Ɩ��敪";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_TIMESPOTKBN)
                {
                    col.Label = "�^�C���X�|�b�g�敪";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_KENMEI)
                {
                    col.Label = "����";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_DMEISYO)
                {
                    col.Label = "�d�ʁE�}�̖���";
                    col.Width = 200;
                }
                else if (col.Index == COLIDX_MLIST_DKIKAN)
                {
                    col.Label = "�d�ʁE����";
                    col.Width = 120;
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_DNAIYO)
                {
                    col.Label = "�d�ʁE���e";
                    col.Width = 150;
                }
                else if (col.Index == COLIDX_MLIST_TORIGAK)
                {
                    col.Label = "�旿��";
                    col.Width = 100;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                else if (col.Index == COLIDX_MLIST_NEBIRITU)
                {
                    col.Label = "�l����";
                    col.Width = 60;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                else if (col.Index == COLIDX_MLIST_NEBIGAK)
                {
                    col.Label = "�l���z";
                    col.Width = 100;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                else if (col.Index == COLIDX_MLIST_KINGAK)
                {
                    col.Label = "�������z";
                    col.Width = 120;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                else if (col.Index == COLIDX_MLIST_SYOHIRITU)
                {
                    col.Label = "����ŗ�";
                    col.Width = 60;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                else if (col.Index == COLIDX_MLIST_SYOHI)
                {
                    col.Label = "����Ŋz";
                    col.Width = 120;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                else if (col.Index == COLIDX_MLIST_BAITAIKBN)
                {
                    col.Label = "�}�̋敪";
                    col.Width = 250;
                }
                else if (col.Index == COLIDX_MLIST_BAITAIMEI)
                {
                    col.Label = "�}�̖���";
                    col.Width = 200;
                }
                else if (col.Index == COLIDX_MLIST_KOMOKUCODE)
                {
                    col.Label = "���ڃR�[�h";
                    col.Width = 80;
                }
                else if (col.Index == COLIDX_MLIST_KOMOKUMEI)
                {
                    col.Label = "���ږ���";
                    col.Width = 250;
                }
                else if (col.Index == COLIDX_MLIST_SEQ2)
                {
                    col.Label = "���я��Q";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_SEQ1)
                {
                    col.Label = "���я�";
                    col.Width = 60;
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    col.CellType = cellType;
                }
                else if (col.Index == COLIDX_MLIST_JYUTNO)
                {
                    col.Label = "��NO";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_JYMEINO)
                {
                    col.Label = "�󒍖���NO";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_URMEINO)
                {
                    col.Label = "���㖾��NO";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_GPYNO)
                {
                    col.Label = "�������[NO";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_BAITAIKBN2)
                {
                    col.Label = "�}�̋敪";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_TIMESTMP)
                {
                    col.Label = "�^�C���X�^���v";
                    col.Width = 0;
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_TEMPCODE)
                {
                    col.Label = "�e���v���[�g�R�[�h";
                    col.Width = 0;
                    col.Visible = false;
                }
            }

            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(0, 0, 1, 1);
            }
        }

        /// <summary>
        /// �{�^���̎g�p�E�s�ݒ�̏��������s�� 
        /// </summary>
        /// <param name="flg">True:�g�p��/false:�g�p�s��</param>
        private void InitializeButtonEnable(bool flg)
        {
            // ���я��{�^�� 
            btnOrder.Enabled = flg;

            // ���ד��̓{�^�� 
            btnDetailInput.Enabled = flg;
        }

        /// <summary>
        /// �e�R���g���[���̏����ݒ� 
        /// </summary>
        private void InitializeControlSkyp()
        {
            //******************
            //���������� 
            //******************
            lblKenMei.Visible = false;
            txtKenMei.Visible = false;
            lblKikan.Visible = false;
            txtYmdTo.Visible = false;

            //*******************
            //�{�^���� 
            //*******************
        }

        /// <summary>
        /// ���я��f�[�^���݃`�F�b�N 
        /// </summary>
        /// <returns>���茋��</returns>
        private bool CheckOrderData()
        {
            DetailSkypProcessController.FindOrderDataByCondParam param =
                new DetailSkypProcessController.FindOrderDataByCondParam();

            // �p�����[�^�ݒ� 
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = _naviParameter.StrYymm;
            param.baitaikbn = string.Empty;
            // ���я��f�[�^���� 
            DetailSkypProcessController processController = DetailSkypProcessController.GetInstance();
            FindOrderByCondServiceResult result = processController.FindOrderDataByCond(param);

            if (result.HasError == true)
            {
                return false;
            }

            if (result.DetailDataSet.OrderData.Rows.Count == 0)
            {
                return false;
            }

            return true;
        }

        #endregion ���\�b�h 

    }
}