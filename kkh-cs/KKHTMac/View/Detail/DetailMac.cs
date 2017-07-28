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
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Log;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHView.Common;

using Isid.KKH.Mac.Schema;
using Isid.KKH.Mac.Utility;

namespace Isid.KKH.Mac.View.Detail
{
    public partial class DetailMac : Isid.KKH.Common.KKHView.Detail.DetailForm
    {

        #region �萔.

        /// <summary>
        /// �A�v��ID
        /// </summary>
        private const String APLID = "DtlMac";

        //����(�ꗗ)�J�����C���f�b�N�X TODO �����߂ł��B�K���ύX���Ă��������B.
        // ����őΉ� 2013/10/21 update HLC H.Watabe start
        /// <summary>
        /// ������C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_KENMEI = 0;
        /// <summary>
        /// ���z�C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_KINGAKU = 1;
        /// <summary>
        /// �X�ܖ��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_TENPOMEI = 2;
        /// <summary>
        /// �n��{����C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_TIKUHONBU = 3;
        /// <summary>
        /// �P����C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_TANKA = 4;
        /// <summary>
        /// ����ŗ�C���f�b�N�X.
        /// </summary>
        public const int COLIDC_MLIST_SHOHIZEIRITU = 5;
        /// <summary>
        /// ���ʗ�C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_SURYO = 5;
        public const int COLIDX_MLIST_SURYO = 6;
        /// <summary>
        /// ����Ȗڗ�C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_KANJYOKMK = 6;
        public const int COLIDX_MLIST_KANJYOKMK = 7;
        /// <summary>
        /// �X�܃R�[�h��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_TENPOCD = 7;
        public const int COLIDX_MLIST_TENPOCD = 8;
        /// <summary>
        /// �n��{���R�[�h��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_TIKUHONBUCD = 8;
        public const int COLIDX_MLIST_TIKUHONBUCD = 9;
        /// <summary>
        /// ���Ӑ�S���҃R�[�h��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_TOKUISAKITANCD = 9;
        public const int COLIDX_MLIST_TOKUISAKITANCD = 10;
        /// <summary>
        /// ���Ӑ�S���Җ���C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_TOKUISAKITANMEI = 10;
        public const int COLIDX_MLIST_TOKUISAKITANMEI = 11;
        ///// <summary>
        ///// �w���`�[���\����C���f�b�N�X.
        ///// </summary>
        //public const int COLIDX_MLIST_KOMYUDENPYO = 11;
        /// <summary>
        /// ���������s����C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_SEIKYUSYOHAKKODAY = 11;
        public const int COLIDX_MLIST_SEIKYUSYOHAKKODAY = 12;
        /// <summary>
        /// �X�܋敪��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_TENPOKUBUNRETU = 12;
        public const int COLIDX_MLIST_TENPOKUBUNRETU = 13;
        /// <summary>
        /// ���������s�t���O��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_SEIKYUSYOFLG = 13;
        public const int COLIDX_MLIST_SEIKYUSYOFLG = 14;
        /// <summary>
        /// �����P��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_KENMEI1 = 14;
        public const int COLIDX_MLIST_KENMEI1 = 15;
        /// <summary>
        /// �����Q��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_KENMEI2 = 15;
        public const int COLIDX_MLIST_KENMEI2 = 16;
        /// <summary>
        /// �`�[�ԍ���C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_DENPYOBANGO = 16;
        public const int COLIDX_MLIST_DENPYOBANGO = 17;
        /// <summary>
        /// �����ύXFLG��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_KENMEICHGFLG = 17;
        public const int COLIDX_MLIST_KENMEICHGFLG = 18;
        /// <summary>
        /// ����FLG��C���f�b�N�X.
        /// </summary>
        //public const int COLIDX_MLIST_BUNKATUFLG = 18;
        public const int COLIDX_MLIST_BUNKATUFLG = 19;
        // ����őΉ� 2013/10/21 update HLC H.Watabe start.

        #endregion �萔.

        #region �����o�ϐ�.

        KKHNaviParameter _naviParam = new KKHNaviParameter();
        //�f�[�^�e�[�u��.
        private FindMasterMaintenanceByCondServiceResult plDtTenpoMast;
        private FindMasterMaintenanceByCondServiceResult plDtTenpoPtnMast;
        private FindMasterMaintenanceByCondServiceResult plDtTenpoPtn2Mast;

        #endregion �����o�ϐ�.

        #region �R���X�g���N�^.

        public DetailMac()
        {
            InitializeComponent();
        }

        #endregion �R���X�g���N�^.

        #region �I�[�o�[���C�h.

        /// <summary>
        /// ���Ӑ�ʂɕ\���ΏۊO��̔�\���������s��.
        /// </summary>
        protected override void VisibleColumns()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s.
            base.VisibleColumns();

            foreach (Column col in base._spdJyutyuList_Sheet1.Columns)
            {
                //�\��
                if (col.Index == COLIDX_JLIST_TOROKU) { col.Visible = true; }                  //�o�^.
                if (col.Index == COLIDX_JLIST_TOGO) { col.Visible = false; }                   //����.
                if (col.Index == COLIDX_JLIST_DAIUKE){ col.Visible = true; }                   //���.
                if (col.Index == COLIDX_JLIST_SEIKYU) { col.Visible = false; }                 //����.
                if (col.Index == COLIDX_JLIST_URIMEINO) { col.Visible = true; }                //���㖾��NO.
                if (col.Index == COLIDX_JLIST_GPYNO) { col.Visible = false; }                  //�������[NO.
                if (col.Index == COLIDX_JLIST_SEIYYMM){ col.Visible = true; }                  //�����N��.
                if (col.Index == COLIDX_JLIST_GYOMKBN){ col.Visible = true; }                  //�Ɩ��敪.
                if (col.Index == COLIDX_JLIST_KENMEI){ col.Visible = true; }                   //����.
                if (col.Index == COLIDX_JLIST_HIMOKUNM){ col.Visible = true; }                 //��ږ�.
                if (col.Index == COLIDX_JLIST_SEIKINGAKU){ col.Visible = true; }               //�������z.
                if (col.Index == COLIDX_JLIST_TORIRYOKIN){ col.Visible = true; }               //�旿��.
                if (col.Index == COLIDX_JLIST_NEBIKIRITSU){ col.Visible = true; }              //�l����.
                if (col.Index == COLIDX_JLIST_NEBIKIGAKU){ col.Visible = true; }               //�l���z.
                if (col.Index == COLIDX_JLIST_ZEIRITSU){ col.Visible = true; }                 //����ŗ�.
                if (col.Index == COLIDX_JLIST_ZEIGAKU){ col.Visible = true; }                  //����Ŋz.
                if (col.Index == COLIDX_JLIST_OLDSEIYYMM){ col.Visible = true; }               //�ύX�O�����N��.

                //��\��.
                if (col.Index == COLIDX_JLIST_BAITAINM) { col.Visible = false; }               //�}�̖�.
                if (col.Index == COLIDX_JLIST_DANTANKA) { col.Visible = false; }               //�i�P��.
                if (col.Index == COLIDX_JLIST_DANSU) { col.Visible = false; }                  //�i��.
                if (col.Index == COLIDX_JLIST_KYOKUSHICD) { col.Visible = false; }             //�ǎ�CD.
                if (col.Index == COLIDX_JLIST_KIKAN) { col.Visible = false; }                  //����.                
            }
        }

        /// <summary>
        /// �Z���̐F�t���������s��.
        /// </summary>
        protected override void ChangeColor()
        {
            string sonota2 = "0";
            for (int i = 0; i < _spdJyutyuList_Sheet1.Rows.Count; i++)
            {
                int rowNum = 0;
                if (!int.TryParse(_spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_ROWNUM].Text, out rowNum))
                {
                    continue;
                }

                Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow1 = _dsDetail.JyutyuData.FindByrowNum(rowNum);
                if (!string.IsNullOrEmpty(dataRow1.hb1TrkTntNm.Trim()))
                {
                    //�����׃`�F�b�N.
                    DetailProcessController.FindDetailDataByCondParam param = CreateServiceParamForFindDetailDataByCond(i);
                    DetailProcessController processController = DetailProcessController.GetInstance();
                    FindDetailDataByCondServiceResult result = processController.FindDetailDataByCond(param);

                    if (result.HasError == true)
                    {
                        return;
                    }

                    ////���ׂO�̏ꍇ.
                    if (result.DetailDataSet.THB2KMEI.Rows.Count == 0)
                    {
                        _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(255, 255, 255);
                    }
                    //���ׂP�̏ꍇ.
                    else if (result.DetailDataSet.THB2KMEI.Rows.Count == 1)
                    {
                        foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow row in result.DetailDataSet.THB2KMEI.Rows)
                        {
                            sonota2 = row.hb2Sonota2;
                        }
                        if (sonota2 == "2")
                        {
                            _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(157, 255, 255);
                        }
                        else
                        {
                            _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(255, 157, 157);
                        }
                    }
                    //���ׂQ�ȏ�̏ꍇ.
                    else
                    {
                        _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(157, 255, 255);
                    }
                }

                //�������t���O�`�F�b�N.
                if (dataRow1.hb1TouFlg == "1")
                {
                    //�����t���O="1"�̍s�͔w�i�F��ύX.
                    _spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_TOROKU].Text = "����";
                }

                //���ύX�O�����N���`�F�b�N.
                if (dataRow1.hb1YymmOld != "")
                {
                    //�ύX�O�����N�����ݒ肳��Ă���(�N���ύX���s���Ă���)�ꍇ�͐����N����ԕ����ɂ���.
                    _spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_SEIYYMM].ForeColor = Color.Red;
                }
            }

            //�e�N���X�̍s���Ă��鋤�ʏ��������s.
            base.ChangeColor();
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
            _dsDetailMac.KkhDetail.Clear();
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow row in _dsDetail.THB2KMEI.Rows)
            {
                DetailDSMac.KkhDetailRow addRow = _dsDetailMac.KkhDetail.NewKkhDetailRow();

                //����.
                addRow.kenmei = row.hb2Name1.Trim() + row.hb2Name2.Trim();
                //���z.
                addRow.kingaku = row.hb2SeiGak;
                //�X�ܖ�.
                addRow.tenpomei = row.hb2Name3;
                //�n��{��.
                addRow.tikuhonbu = row.hb2Name4;
                //�P��.
                addRow.tanka = row.hb2Kngk1;
                // ����őΉ� 2013/10/21 HLC H.Watabe start
                //����ŗ�.
                addRow.shohizeiritu = row.hb2Ritu1;
                // ����őΉ� 2013/10/21 HLC H.Watabe end
                //����.
                addRow.suryo = row.hb2Kngk2;
                //����Ȗ�.
                addRow.kanjyokmk = row.hb2Code4;
                //�X�܃R�[�h.
                addRow.tenpocd = row.hb2Code1;
                //�n��{���R�[�h.
                addRow.tikuhonbucd = row.hb2Code2;
                //���Ӑ�S���҃R�[�h.
                addRow.tokuisakitantocd = row.hb2Code3;
                //���Ӑ�S���Җ�.
                addRow.tokusakitantonm = row.hb2Name5;
                //���������s��.
                addRow.seikyuhakoday = row.hb2Date2;
                //�X�܋敪.
                addRow.tenpokbn = row.hb2Kbn1;
                //���������s�t���O.
                addRow.seikyusyohako = row.hb2Kbn2;
                //�����P.
                addRow.kenmei1 = row.hb2Name1;
                //�����Q.
                addRow.kenmei2 = row.hb2Name2;
                //�`�[�ԍ�.
                addRow.denpyobango = row.hb2Sonota1;
                //�����`�F���W�t���O.
                addRow.kenmeiChgFlg = row.hb2MeihnFlg;
                //�����t���O.
                addRow.bunkatu = row.hb2Sonota2;

                _dsDetailMac.KkhDetail.AddKkhDetailRow(addRow);
            }

            _dsDetailMac.KkhDetail.AcceptChanges();

            //�X�v���b�h�f�U�C���̍ď�����.
            InitializeDesignForSpdKkhDetail();

            //�󒍓o�^���e�̑I���s���̎擾.
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(rowIdx)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);

            //***************************************
            //�{�^���ނ̎g�p�E�s�ݒ�.
            //***************************************
            btnDetailInput.Enabled = true;
            btnDetailDel.Enabled = true;
            btnDetailRegister.Enabled = true;
            btnDivide.Enabled = true;
            btnUpdateCheck.Enabled = true;

            //���׃f�[�^����.
            if (_dsDetailMac.KkhDetail.Rows.Count > 0)
            {
                //�����f�[�^�̏ꍇ.
                if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    //�\���̕ҏW.
                    for (int i = 1; i < _spdKkhDetail_Sheet1.RowCount; i++)
                    {
                        //����.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI].Value = "";
                        //�n��{��.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TIKUHONBU].Value = "";
                        //�P��.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TANKA].Value = null;
                        //�n��{���R�[�h.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TIKUHONBUCD].Value = "";
                        //���Ӑ�S���҃R�[�h.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TOKUISAKITANCD].Value = "";
                        //���Ӑ�S���Җ�.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TOKUISAKITANMEI].Value = "";
                        //���������s��.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSYOHAKKODAY].Value = "";
                        //���������s�t���O.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSYOFLG].Value = "";
                        //�����P.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI1].Value = "";
                        //�����Q.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI2].Value = "";
                        //�����ύX�t���O.
                        _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEICHGFLG].Value = "";

                        //����őΉ� 2013/10/21 add HLC H.Watabe start
                        _spdKkhDetail_Sheet1.Cells[i, COLIDC_MLIST_SHOHIZEIRITU].Value = null;
                        //����őΉ� 2013/10/21 add HLC H.Watabe end
                    }

                    //���ד��̓{�^��.
                    btnDetailInput.Enabled = false;
                }
                else
                {
                    btnDetailInput.Enabled = true;
                }
                btnDetailDel.Enabled = true;
                btnDetailRegister.Enabled = true;
                btnDivide.Enabled = true;
            }
            //���׃f�[�^�Ȃ�.
            else
            {
                //�L����׃f�[�^���Ȃ��ꍇ�͕����E�폜�͕s��.
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = true;
                btnDivide.Enabled = true;
                btnDetailInput.Enabled = true;
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
            //btnBulkRegister.Enabled = false;
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
            //btnBulkRegister.Enabled = true;
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
                //���׊֌W�̃{�^���͖��׌�����̏����ɔC����.
            }
            else
            {
                //�q�r���[�Ƀt�H�[�J�X������ꍇ�̓f�[�^������s���{�^���͎g�p�����Ȃ�.

                //���׊֌W�̃{�^���g�p�s��.
                btnDetailInput.Enabled = false;
                btnDivide.Enabled = false;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = false;
            }
        }

        #region �󒍍폜��̏���������.

        /// <summary>
        /// �󒍍폜��̏���������.
        /// </summary>
        protected override void InitAfterDelJyutyu()
        {
            // ���݂̃A�N�e�B�u�s�C���f�b�N�X��ێ�.
            int rowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            // �Č���.
            ReSearchJyutyuData();

            // �󒍏�񂪑��݂��Ȃ��ꍇ.
            if (_spdJyutyuList_Sheet1.Rows.Count == 0)
            {
                return;
            }

            // �A�N�e�B�u�s��ݒ�.
            _spdJyutyuList_Sheet1.SetActiveCell(rowIdx, 0, true);
            _spdJyutyuList_Sheet1.AddSelection(rowIdx, 0, 1, 1);
            spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

            // �L����׃f�[�^�̌����E�\��.
            DisplayKkhDetail(rowIdx);

            // �󒍓o�^���e�̑I���s���̎擾.
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(rowIdx)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);

            // ���z�v�Z.
            CalculateSagaku(dataRow);

            return;
        }

        #endregion


        protected override void UpdateSpdDataByJyutyuData(Isid.KKH.Common.KKHSchema.Detail dsDetail)
        {
            dsDetail.MacUpdateSpdDataByJyutyuData();
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
            KKHLogUtilityMac.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityMac.KINO_ID_OPERATION_LOG_UpdCheck, KKHLogUtilityMac.DESC_OPERATION_LOG_UpdCheck);

            return true;
        }

        #endregion �I�[�o�[���C�h.

        #region �C�x���g.

        /// <summary>
        /// ��ʑJ�ڂ��邽�тɔ������܂��B.
        /// </summary>
        /// <param name="sender">�J�ڌ��t�H�[��</param>
        /// <param name="arg">�C�x���g�f�[�^</param>
        private void DetailMac_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailMac_Load(object sender, EventArgs e)
        {
            InitializeDataSourceMac();
            InitializeControlMac();
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
            int rowIndex = _spdJyutyuList_Sheet1.ActiveRowIndex;
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(rowIndex)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);
            int rowDetailIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

            // ���ד��͉�ʕ\��.
            //�p�����[�^�Z�b�g.
            DetailInputMacNaviParameter naviParam = new DetailInputMacNaviParameter();
            //��{���.
            naviParam.pEsqId = _naviParam.strEsqId;
            naviParam.pEgcd = _naviParam.strEgcd;
            naviParam.pTksKgyCd = _naviParam.strTksKgyCd;
            naviParam.pTksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            naviParam.pTksTntSeqNo = _naviParam.strTksTntSeqNo;
            //��.
            naviParam.DataRow = dataRow;
            naviParam.RowDetailIndex = rowDetailIndex;
            naviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1;
            naviParam.InpTenpoMastrslt = plDtTenpoMast;

            object result = Navigator.ShowModalForm(this, "toDetailInputMac", naviParam);

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
            int rowIndex = _spdJyutyuList_Sheet1.ActiveRowIndex;
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(rowIndex)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);
            int rowDetailIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

            // ���ד��͉�ʕ\��.
            DetailDivideMacNaviParameter naviParam = new DetailDivideMacNaviParameter();
            //��{���.
            naviParam.pEsqId = _naviParam.strEsqId;
            naviParam.pEgcd = _naviParam.strEgcd;
            naviParam.pTksKgyCd = _naviParam.strTksKgyCd;
            naviParam.pTksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            naviParam.pTksTntSeqNo = _naviParam.strTksTntSeqNo;
            //��.
            naviParam.DataRow = dataRow;
            naviParam.RowDetailIndex = rowDetailIndex;
            naviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1;
            naviParam.DivTenpoMastrslt = plDtTenpoMast;
            naviParam.DivTenpoPtnMastrslt = plDtTenpoPtnMast;
            naviParam.DivTenpoPtn2Mastrslt = plDtTenpoPtn2Mast;

            object result = Navigator.ShowModalForm(this, "toDetailDivideMac", naviParam);

            if (result == null)
            {
                //�I����Ԃ�����.
                this.ActiveControl = null;

                return;
            }
            base.kkhDetailUpdFlag = true; //�L����וύX�t���O���X�V.

            // ���z�v�Z.
            CalculateSagaku(dataRow);

            // �{�^����������.
            if (_spdKkhDetail_Sheet1.RowCount == 0)
            {
                btnDivide.Enabled = false;
                btnDetailDel.Enabled = false;
            }
            else
            {
                btnDivide.Enabled = true;
                btnDetailDel.Enabled = true;
            }

            //�����{�^���͗L��.
            btnDivide.Enabled = true;

            //���ד��̓{�^���͖���.
            btnDetailInput.Enabled = false;

            //�I����Ԃ����� .
            this.ActiveControl = null;
        }

        /// <summary>
        /// ���דo�^�{�^���N���b�N�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailRegister_Click(object sender, EventArgs e)
        {
            if (lblSagakuValue.Text.ToString().Trim().Equals("0"))
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
        /// 
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
                //btnDivide.Enabled = false;
                btnDivide.Enabled = true;
                btnDetailInput.Enabled = true;
            }

            //******************************
            //���z�E�v���x��.
            //******************************
            //�󒍓o�^���e�̑I���s���̎擾.
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(_spdJyutyuList_Sheet1.ActiveRowIndex)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);
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
        /// �}�X�^�f�[�^�ۑ�.
        /// </summary>
        private void DetailMac_Shown(object sender, EventArgs e)
        {
            // ���[�f�B���O�\���J�n.
            ShowLoadingDialog();

            {
                //�X�܃f�[�^�ǂݍ���.
                MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = controller.FindMasterByCond
                (
                    _naviParam.strEsqId,
                    _naviParam.strEgcd,
                    _naviParam.strTksKgyCd,
                    _naviParam.strTksBmnSeqNo,
                    _naviParam.strTksTntSeqNo,
                    "0001",
                    null
                );

                //���U���g�ɕێ�.
                plDtTenpoMast = result;
            }

            {
                //�X�܃p�^�[���i�e�j�ǂݍ���.
                MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = controller.FindMasterByCond
                (
                    _naviParam.strEsqId,
                    _naviParam.strEgcd,
                    _naviParam.strTksKgyCd,
                    _naviParam.strTksBmnSeqNo,
                    _naviParam.strTksTntSeqNo,
                    "0004",
                    null
                );

                //���U���g�ɕێ�.
                plDtTenpoPtnMast = result;
            }

            {
                //�X�܃p�^�[���i�q�j�ǂݍ���.
                MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = controller.FindMasterByCond
                (
                    _naviParam.strEsqId,
                    _naviParam.strEgcd,
                    _naviParam.strTksKgyCd,
                    _naviParam.strTksBmnSeqNo,
                    _naviParam.strTksTntSeqNo,
                    "0005",
                    null
                );

                //���U���g�ɕێ�.
                plDtTenpoPtn2Mast = result;
            }

            // ���[�f�B���O�\���I��.
            CloseLoadingDialog();
        }

        /// <summary>
        /// �w���v�{�^���N���b�N����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //KKHHelpMac.ShowHelpMac(this, this.Name);
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //���s.
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Detail, this, HelpNavigator.KeywordIndex);
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
                String ryoukinStr = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KINGAKU].Text.Trim();

                // ���ׂ̗��������͂���Ă���ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.IsNumeric(ryoukinStr))
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
        /// <param name="dsDetailMac"></param>
        private void UpdateDataSourceByDetailDataSetMac(DetailDSMac dsDetailMac)
        {
            _dsDetailMac.Clear();
            _dsDetailMac.Merge(_dsDetailMac);
            _dsDetailMac.AcceptChanges();
        }

        /// <summary>
        /// �f�[�^�\�[�X�̃o�C���h.
        /// </summary>
        private void InitializeDataSourceMac()
        {
            //_bsJyutyuList
            _bsKkhDetail.DataSource = _dsDetailMac;
            _bsKkhDetail.DataMember = _dsDetailMac.KkhDetail.TableName;
        }

        /// <summary>
        /// �e�R���g���[���̏����ݒ�.
        /// </summary>
        private void InitializeControlMac()
        {
            //******************
            //����������.
            //******************
            lblKenMei.Visible = false;
            txtKenMei.Visible = false;
            lblKikan.Visible = false;
            txtYmdTo.Visible = false;

            //*******************
            //�{�^����.
            //*******************
            btnRegJyutyu.Enabled = false;
            btnDetailInput.Enabled = false;
            btnDetailDel.Enabled = false;
            btnDivide.Enabled = false;
            btnDetailRegister.Enabled = false;

            // �V�K�o�^�{�^�����\��.
            btnRegJyutyu.Visible = false;

            // �ύX�E�폜�`�F�b�N�{�^�����\��.
            btnUpdateCheck.Enabled = false;
        }

        /// <summary>
        /// �󒍓o�^���e(�ꗗ)�X�v���b�h�̗�P�ʂ̐ݒ���s��.
        /// </summary>
        protected override void InitDesignForSpdJyutyuListColumns(Column col)
        {
            base.InitDesignForSpdJyutyuListColumns(col);

            if (col.Index == COLIDX_JLIST_TOROKU)
            {
                col.Width = 33;
            }
        }

        /// <summary>
        /// �L����׃X�v���b�h�̃f�U�C�����������s��.
        /// </summary>
        private void InitializeDesignForSpdKkhDetail()
        {
            //********************************
            //�X�v���b�h�S�̂̐ݒ�.
            //********************************
            spdKkhDetail.DataSource = _bsKkhDetail;
            _spdKkhDetail_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;//�P��I��.
            _spdKkhDetail_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;       //�s�P�ʑI��.
            _spdKkhDetail_Sheet1.OperationMode = OperationMode.SingleSelect;                        //
            _spdKkhDetail_Sheet1.RowHeaderVisible = true;                                           //�s�w�b�_�\��.
            _spdKkhDetail_Sheet1.RowHeaderAutoText = HeaderAutoText.Numbers;                        //�s�w�b�_�ɍs�ԍ���\��.
            _spdKkhDetail_Sheet1.ColumnHeader.Rows[0].Height = 30;

            //********************************
            //�񖈂̐ݒ�.
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
                    col.Width = 180;
                }
                else if (col.Index == COLIDX_MLIST_KINGAKU)
                {
                    col.Width = 100;
                    col.Label = "���z";
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 2;
                    cellType.ShowSeparator = true;
                }
                else if (col.Index == COLIDX_MLIST_TENPOMEI)
                {
                    col.Width = 180;
                    col.Label = "�X�ܖ�";
                }
                else if (col.Index == COLIDX_MLIST_TIKUHONBU)
                {
                    col.Width = 100;
                    col.Label = "�n��{��";
                }
                else if (col.Index == COLIDX_MLIST_TANKA)
                {
                    col.Width = 100;
                    col.Label = "�P��";
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 3;
                    cellType.ShowSeparator = true;
                }
                // ����őΉ� 2013/10/21 add HLC H.Watabe start
                else if (col.Index == COLIDC_MLIST_SHOHIZEIRITU)
                {
                    col.Width = 70;
                    col.Label = "����ŗ�";
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = false;
                }
                // ����őΉ� 2013/10/21 add HLC H.Watabe end
                else if (col.Index == COLIDX_MLIST_SURYO)
                {
                    col.Width = 60;
                    col.Label = "����";
                    NumberCellType cellType = (NumberCellType)col.CellType;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                }
                else if (col.Index == COLIDX_MLIST_KANJYOKMK)
                {
                    col.Width = 80;
                    col.Label = "����Ȗ�";
                }
                else if (col.Index == COLIDX_MLIST_TENPOCD)
                {
                    col.Width = 80;
                    col.Label = "�X�܃R�[�h";
                }
                else if (col.Index == COLIDX_MLIST_TIKUHONBUCD)
                {
                    col.Width = 100;
                    col.Label = "�n��{���R�[�h";
                }
                else if (col.Index == COLIDX_MLIST_TOKUISAKITANCD)
                {
                    col.Label = "���Ӑ�S���҃R�[�h";
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_TOKUISAKITANMEI)
                {
                    col.Label = "���Ӑ�S���Җ�";
                    col.Visible = false;
                }
                else if (col.Index == COLIDX_MLIST_SEIKYUSYOHAKKODAY)
                {
                    col.Width = 90;
                    col.Label = "���������s��";
                }
                else if (col.Index == COLIDX_MLIST_TENPOKUBUNRETU)
                {
                    col.Width = 80;
                    col.Label = "�X�܋敪";
                }
                else if (col.Index == COLIDX_MLIST_SEIKYUSYOFLG)
                {
                    col.Width = 70;
                    col.Label = "���������s�t���O";
                }
                else if (col.Index == COLIDX_MLIST_KENMEI1)
                {
                    col.Width = 150;
                    col.Label = "�����P";
                }
                else if (col.Index == COLIDX_MLIST_KENMEI2)
                {
                    col.Width = 150;
                    col.Label = "�����Q";
                }
                else if (col.Index == COLIDX_MLIST_DENPYOBANGO)
                {
                    col.Width = 100;
                    col.Label = "�`�[�ԍ�";
                }
                else if (col.Index == COLIDX_MLIST_KENMEICHGFLG)
                {
                    col.Width = 70;
                    col.Label = "�����`�F���W�t���O";
                }
                else if (col.Index == COLIDX_MLIST_BUNKATUFLG)
                {
                    col.Width = 70;
                    col.Label = "�����t���O";
                }
            }
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
            DateTime maxUpdDate = new DateTime();
            //DateTime maxUpdDate = new DateTime(2100, 1, 1);//TODO

            //*********************************************
            //THB1DOWN�̓o�^�f�[�^�ҏW.
            //*********************************************
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(_spdJyutyuList_Sheet1.ActiveRowIndex)];
            Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow listRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            //Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);

            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();

            //thb1DownRow.hb1TimStmp = new DateTime();
            thb1DownRow.hb1UpdApl = base.AplId;
            thb1DownRow.hb1UpdTnt = _naviParam.strEsqId;
            thb1DownRow.hb1EgCd = _naviParam.strEgcd;
            thb1DownRow.hb1TksKgyCd = _naviParam.strTksKgyCd;
            thb1DownRow.hb1TksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            thb1DownRow.hb1TksTntSeqNo = _naviParam.strTksTntSeqNo;
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
            //�o�^�ҁA�X�V�҂̓o�^.
            //***************************************
            thb1DownRow.hb1TrkTnt = string.Empty;
            thb1DownRow.hb1TrkTntNm = string.Empty;
            thb1DownRow.hb1KsnTnt = string.Empty;
            thb1DownRow.hb1KsnTntNm = string.Empty;

            //���ׂ��Ȃ��ꍇ.
            if (thb1DownRow.hb1MeisaiFlg.Equals("0"))
            {
                //�o�^�ҁA���X�V�҂���̏ꍇ.
                if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim())
                    && string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                    //�������Ȃ�.
                }
                //�o�^�҂���ŁA�X�V�҂������Ă���ꍇ
                else if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) 
                    && !string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                    //�������Ȃ�.
                }
                else
                {
                    //�X�V�҂�o�^.
                    //�X�V��.
                    thb1DownRow.hb1KsnTnt = _naviParam.strEsqId.Trim();
                    //�X�V�S���Җ�.
                    thb1DownRow.hb1KsnTntNm = _naviParam.strName.Trim();
                }
            }
            //���ׂ�����ꍇ.
            else
            {
                //�o�^�҂���̏ꍇ.
                if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()))
                {
                    //�o�^�҂݂̂�����.
                    //�o�^��.
                    thb1DownRow.hb1TrkTnt = _naviParam.strEsqId.Trim();
                    //�o�^�Җ�.
                    thb1DownRow.hb1TrkTntNm = _naviParam.strName.Trim();
                    //�X�V��.
                    thb1DownRow.hb1KsnTnt = _naviParam.strEsqId.Trim();
                    //�X�V�S���Җ�.
                    thb1DownRow.hb1KsnTntNm = _naviParam.strName.Trim();
                }else
                {
                    //�X�V�҂݂̂�����.
                    //�X�V��.
                    thb1DownRow.hb1KsnTnt = _naviParam.strEsqId.Trim();
                    //�X�V�S���Җ�.
                    thb1DownRow.hb1KsnTntNm = _naviParam.strName.Trim();
                }
            }

            dtThb1Down.AddTHB1DOWNRow(thb1DownRow);

            dsDetail.THB1DOWN.Merge(dtThb1Down);

            Isid.KKH.Common.KKHSchema.Detail TouKoudsDetail = new Isid.KKH.Common.KKHSchema.Detail();

            //�f�[�^����������Ă���ꍇ�A�q�̌��ƂȂ����f�[�^�ɓo�^�S���ҁA�X�V�҂�o�^����B.
            if (dataRow.hb1TouFlg.Equals("1"))
            {
                Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow tokoaddrow = TouKoudsDetail.THB1DOWN.NewTHB1DOWNRow();
                tokoaddrow.hb1UpdApl = base.AplId;
                tokoaddrow.hb1UpdTnt = _naviParam.strEsqId;
                tokoaddrow.hb1EgCd = _naviParam.strEgcd;
                tokoaddrow.hb1TksKgyCd = _naviParam.strTksKgyCd;
                tokoaddrow.hb1TksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                tokoaddrow.hb1TksTntSeqNo = _naviParam.strTksTntSeqNo;
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
                addRow.hb2UpdApl = base.AplId;
                addRow.hb2UpdTnt = _naviParam.strEsqId;
                addRow.hb2EgCd = _naviParam.strEgcd;
                addRow.hb2TksKgyCd = _naviParam.strTksKgyCd;
                addRow.hb2TksBmnSeqNo = _naviParam.strTksBmnSeqNo;
                addRow.hb2TksTntSeqNo = _naviParam.strTksTntSeqNo;
                addRow.hb2Yymm = dataRow.hb1Yymm;
                addRow.hb2JyutNo = dataRow.hb1JyutNo;
                addRow.hb2JyMeiNo = dataRow.hb1JyMeiNo;
                addRow.hb2UrMeiNo = dataRow.hb1UrMeiNo;
                addRow.hb2HimkCd = dataRow.hb1HimkCd;
                //addRow.hb2Renbn = (i + 1).ToString("000");�@���דo�^�����g���Ή�.
                addRow.hb2Renbn = (i + 1).ToString("0000");
                addRow.hb2DateFrom = " ";
                addRow.hb2DateTo = " ";
                //�}�N�h�i���h�p.

                //����.
                //�����̏ꍇ.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_KENMEI].Value != null)
                    {
                        addRow.hb2Name1 = _spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_KENMEI].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Name1 = " ";
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI].Value != null)
                    {
                        addRow.hb2Name1 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Name1 = " ";
                    }
                }

                //���z.
                addRow.hb2SeiGak = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KINGAKU].Value;

                //�X�ܖ�.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TENPOMEI].Value != null)
                {
                    addRow.hb2Name3 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TENPOMEI].Value.ToString();
                }
                else
                {
                    addRow.hb2Name3 = " ";
                }

                //�n��{��,
                //�����̏ꍇ.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_TIKUHONBU].Value != null)
                    {
                        addRow.hb2Name4 = _spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_TIKUHONBU].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Name4 = " ";
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TIKUHONBU].Value != null)
                    {
                        addRow.hb2Name4 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TIKUHONBU].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Name4 = " ";
                    }
                }

                //�P��.
                //�����̏ꍇ.
                if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_TANKA].Value != null)
                    {
                        addRow.hb2Kngk1 = Isid.KKH.Common.KKHUtility.KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_TANKA].Value.ToString());
                    }
                    else
                    {
                        addRow.hb2Kngk1 = 0M;
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TANKA].Value != null)
                    {
                        addRow.hb2Kngk1 = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TANKA].Value;
                    }
                    else
                    {
                        addRow.hb2Kngk1 = 0M;
                    }
                }

                //����.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SURYO].Value != null)
                {
                    addRow.hb2Kngk2 = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SURYO].Value;
                }
                else
                {
                    addRow.hb2Kngk2 = 0M;
                }

                //����Ȗ�.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KANJYOKMK].Value != null)
                {
                    addRow.hb2Code4 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KANJYOKMK].Value.ToString();
                }
                else
                {
                    addRow.hb2Code4 = " ";
                }

                //�X�܃R�[�h.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TENPOCD].Value != null)
                {
                    addRow.hb2Code1 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TENPOCD].Value.ToString();
                }
                else
                {
                    addRow.hb2Code1 = " ";
                }

                //�n��{���R�[�h.
                //�����̏ꍇ.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_TIKUHONBUCD].Value != null)
                    {
                        addRow.hb2Code2 = _spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_TIKUHONBUCD].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Code2 = " ";
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TIKUHONBUCD].Value != null)
                    {
                        addRow.hb2Code2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TIKUHONBUCD].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Code2 = " ";
                    }
                }

                //���Ӑ�CD,NM
                addRow.hb2Code3 = " ";
                addRow.hb2Name5 = " ";

                //���������s��.
                //�����̏ꍇ.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_SEIKYUSYOHAKKODAY].Value != null)
                    {
                        addRow.hb2Date2 = _spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_SEIKYUSYOHAKKODAY].Value.ToString().Replace("/", "");
                    }
                    else
                    {
                        addRow.hb2Date2 = " ";
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSYOHAKKODAY].Value != null)
                    {
                        addRow.hb2Date2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSYOHAKKODAY].Value.ToString().Replace("/", "");
                    }
                    else
                    {
                        addRow.hb2Date2 = " ";
                    }
                }

                //�X�܋敪.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TENPOKUBUNRETU].Value != null)
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TENPOKUBUNRETU].Value.ToString().Equals(""))
                    {
                        addRow.hb2Kbn1 = " ";
                    }
                    else
                    {
                        addRow.hb2Kbn1 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TENPOKUBUNRETU].Value.ToString();
                    }
                }
                else
                {
                    addRow.hb2Kbn1 = " ";
                }

                //���������s�t���O.
                //�����̏ꍇ.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    //���������s�t���O
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_SEIKYUSYOFLG].Value != null)
                    {
                        addRow.hb2Kbn2 = _spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_SEIKYUSYOFLG].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Kbn2 = " ";
                    }
                }
                else
                {
                    //���������s�t���O
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSYOFLG].Value != null)
                    {
                        addRow.hb2Kbn2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSYOFLG].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Kbn2 = " ";
                    }
                }

                //���������s�t���O.
                //�����̏ꍇ.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_SEIKYUSYOFLG].Value != null)
                    {
                        addRow.hb2Kbn2 = _spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_SEIKYUSYOFLG].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Kbn2 = " ";
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSYOFLG].Value != null)
                    {
                        addRow.hb2Kbn2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIKYUSYOFLG].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Kbn2 = " ";
                    }
                }

                //�����P.
                //�����̏ꍇ.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_KENMEI1].Value != null)
                    {
                        addRow.hb2Name1 = _spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_KENMEI1].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Name1 = " ";
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI1].Value != null)
                    {
                        addRow.hb2Name1 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI1].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Name1 = " ";
                    }
                }

                //�����Q.
                //�����̏ꍇ.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_KENMEI2].Value != null)
                    {
                        addRow.hb2Name2 = _spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_KENMEI2].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Name2 = " ";
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI2].Value != null)
                    {
                        addRow.hb2Name2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI2].Value.ToString();
                    }
                    else
                    {
                        addRow.hb2Name2 = " ";
                    }
                }

                //�`�[.
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_DENPYOBANGO].Value != null)
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_DENPYOBANGO].Value.ToString().Equals(""))
                    {
                        addRow.hb2Sonota1 = " ";
                    }
                    else
                    {
                        addRow.hb2Sonota1 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_DENPYOBANGO].Value.ToString();
                    }
                }
                else
                {
                    addRow.hb2Sonota1 = " ";
                }

                //����őΉ� 2013/10/21 add HLC H.Watabe start 
                //addRow.hb2Ritu1 = Isid.KKH.Common.KKHUtility.KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[i, COLIDC_MLIST_SHOHIZEIRITU].Value.ToString());
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    if (_spdKkhDetail_Sheet1.Cells[0, COLIDC_MLIST_SHOHIZEIRITU].Value != null)
                    {
                        addRow.hb2Ritu1 = Isid.KKH.Common.KKHUtility.KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[0, COLIDC_MLIST_SHOHIZEIRITU].Value.ToString());
                    }
                    else
                    {
                        addRow.hb2Ritu1 = 0M;
                    }
                }
                else
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDC_MLIST_SHOHIZEIRITU].Value != null)
                    {
                        addRow.hb2Ritu1 = Isid.KKH.Common.KKHUtility.KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[i, COLIDC_MLIST_SHOHIZEIRITU].Value.ToString());
                    }
                    else
                    {

                        addRow.hb2Ritu1 = 0M;
                    }
                }
                //����őΉ� 2013/10/21 add HLC H.Watabe end

                addRow.hb2Hnnert = 0M;
                addRow.hb2HnmaeGak = 0M;
                addRow.hb2NebiGak = 0M;
                addRow.hb2Date1 = " ";
                addRow.hb2Date3 = " ";
                addRow.hb2Date4 = " ";
                addRow.hb2Date5 = " ";
                addRow.hb2Date6 = " ";
                addRow.hb2Kbn3 = " ";
                addRow.hb2Code3 = " ";
                addRow.hb2Code5 = " ";
                addRow.hb2Code6 = " ";
                addRow.hb2Name5 = " ";
                addRow.hb2Name6 = " ";
                addRow.hb2Name7 = " ";
                addRow.hb2Name8 = " ";
                addRow.hb2Name9 = " ";
                addRow.hb2Name10 = " ";
                addRow.hb2Kngk3 = 0M;
                //����őΉ� 2013/10/21 delete HLC H.Watabe start
                //addRow.hb2Ritu1 = 0M;
                //����őΉ� 2013/10/21 delete HLC H.Watabe end
                addRow.hb2Ritu2 = 0M;
                addRow.hb2Sonota2 = " ";
                addRow.hb2Sonota3 = " ";
                addRow.hb2Sonota4 = " ";
                addRow.hb2Sonota5 = " ";
                addRow.hb2Sonota6 = " ";
                addRow.hb2Sonota7 = " ";
                addRow.hb2Sonota8 = " ";
                addRow.hb2Sonota9 = " ";
                addRow.hb2Sonota10 = " ";

                //�����t���O.
                if (_spdKkhDetail_Sheet1.RowCount >= 2)
                {
                    addRow.hb2BunFlg = "1";
                }
                else
                {
                    addRow.hb2BunFlg = " ";
                }
                //�����t���O.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEICHGFLG].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2MeihnFlg = "1";
                }
                else
                {
                    addRow.hb2MeihnFlg = " ";
                }
                addRow.hb2NebhnFlg = " ";
                //���̂��t���O(SONOTA2).
                if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value != null)
                {
                    if (_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString().Equals(""))
                    {
                        addRow.hb2Sonota2 = " ";
                    }
                    else
                    {
                        addRow.hb2Sonota2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BUNKATUFLG].Value.ToString();
                    }
                }
                else
                {
                    addRow.hb2Sonota2 = " ";
                }

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

            DetailProcessController processController = DetailProcessController.GetInstance();
            //UpdateDisplayDataServiceResult result = processController.UpdateDisplayData(esqId, dsDetail, maxUpdDate);
            DetailProcessController.UpdateDisplayDataParam param = new DetailProcessController.UpdateDisplayDataParam();
            param.esqId = esqId;
            param.dsDetail = dsDetail;
            param.maxUpdDate = maxUpdDate;
            param.TouKoudsDetail = TouKoudsDetail;
            UpdateDisplayDataServiceResult result = processController.UpdateDisplayData(param);

            if (result.HasError)
            {
                if (result.MessageCode == "LOCK-E0001")
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0148, null, "���דo�^", MessageBoxButtons.OK);
                }
                //���[�f�B���O�\���I��.
                base.CloseLoadingDialog();

                return;
            }

            base.kkhDetailUpdFlag = false; //�L����וύX�t���O���X�V.
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {

                // �����t���O�̒l�ɂ���Ď󒍈ꗗ�̍s�̐F��ύX.
                if (_spdKkhDetail_Sheet1.Cells[0, COLIDX_MLIST_BUNKATUFLG].Value.ToString() == "2")
                {
                    _spdJyutyuList_Sheet1.Rows[_spdJyutyuList_Sheet1.ActiveRowIndex].BackColor = Color.FromArgb(157, 255, 255);
                    //���ד��̓{�^���𖳌��ɂ���.
                    btnDetailInput.Enabled = false;
                }
                else
                {
                    _spdJyutyuList_Sheet1.Rows[_spdJyutyuList_Sheet1.ActiveRowIndex].BackColor = Color.FromArgb(255, 157, 157);
                    //���ד��̓{�^����L���ɂ���.
                    btnDetailInput.Enabled = true;
                }
            }
            else
            {
                //���ד��̓{�^����L���ɂ���.
                btnDetailInput.Enabled = true;

                //�����{�^����L���ɂ���.
                btnDivide.Enabled = true;

                //�폜�{�^���𖳌��ɂ���.
                btnDetailDel.Enabled = false;

                // �󒍈ꗗ�̍s�̐F��ύX.
                _spdJyutyuList_Sheet1.Rows[_spdJyutyuList_Sheet1.ActiveRowIndex].BackColor = Color.FromArgb(255, 255, 255);
            }

            ////���݈ʒu�̎擾.
            //int _spdJyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            //base.SearchJyutyuData();

            ////���̈ʒu�ɖ߂�.
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

            // �������b�Z�[�W�\��.
            MessageUtility.ShowMessageBox(MessageCode.HB_I0012, null, "���דo�^", MessageBoxButtons.OK);

        }

        #endregion ���\�b�h.
    }
}
