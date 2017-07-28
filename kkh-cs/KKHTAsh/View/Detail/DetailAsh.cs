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
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Ash.Schema;
using Isid.KKH.Ash.ProcessController.Detail;
using Isid.KKH.Ash.Utility;
using dsDetail = Isid.KKH.Common.KKHSchema.Detail;
using drJyutyuData = Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow;
using drDetailData = Isid.KKH.Ash.Schema.DetailDSAsh.DetailDataAshRow;
using drKkhDetail = Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailRow;
using dtTHB1DOWN = Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable;
using drTHB1DOWN = Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow;
using dtTHB2KMEI = Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable;
using drTHB2KMEI = Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow;

namespace Isid.KKH.Ash.View.Detail
{
    /// <summary>
    /// �L����דo�^���.
    /// </summary>
    public partial class DetailAsh : DetailForm
    {
        #region �萔.
        #region ���׈ꗗ�J�����C���f�b�N�X.
        /// <summary>
        /// �������ԍ���C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_SEINO = 0;
        /// <summary>
        /// ������C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_KENMEI = 1;
        /// <summary>
        /// �ǃR�[�h��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_KYOKUCD = 2;
        /// <summary>
        /// �i��R�[�h��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_HINSYUCD = 3;
        /// <summary>
        /// ��ږ��̗�C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_HIMOKUNM = 4;
        /// <summary>
        /// ���ϋ��z��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_HNMAEGAK = 5;
        /// <summary>
        /// �l������C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_HNNERT = 6;
        /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD Start */
        /// <summary>
        /// �l���z��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_NEBIKIGAKU = 7;
        /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD End */
        /// <summary>
        /// �������z��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_SEIGAK = 8;
        /// <summary>
        /// ����ŗ���C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_ZEIRITSU = 9;
        /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD Start */
        /// <summary>
        /// ����Ŋz��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_ZEIGAKU = 10;
        /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD End */
        /// <summary>
        /// ���ԗ�C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_KIKAN = 11;
        /// <summary>
        /// �}�̃R�[�h��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_BAITAICD = 12;
        /// <summary>
        /// �}�̃R�[�h��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_TOKUIBAITAICD = 13;
        /// <summary>
        /// �㗝�X�R�[�h��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_DAIRITENCD = 14;
        /// <summary>
        /// �ԑg�R�[�h��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_BANGUMICD = 15;
        /// <summary>
        /// ���㖾��NO��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_URIMEINO = 16;
        /// <summary>
        /// �b����C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_BYOUSU = 17;
        /// <summary>
        /// �{����C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_HONSU = 18;
        /// <summary>
        /// �\������C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_HYOUJIJYUN = 19;
        /// <summary>
        /// �f�ځE��������C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_KEISAIDT = 20;
        /// <summary>
        /// ���[�敪��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_TYOUSEKIKBN = 21;
        /// <summary>
        /// �L�G�敪��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_KIZATSUKBN = 22;
        /// <summary>
        /// �f�ڔŗ�C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_KEISAIBAN = 23;
        /// <summary>
        /// �[�������敪��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_HASUSYORIKBN = 24;
        /// <summary>
        /// ���͔䗦��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_NYURYOKUHIRITU = 25;
        /// <summary>
        /// �X�y�[�X��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_SPACE = 26;
        /// <summary>
        /// �������ԗ�C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_HOSOUJIKAN = 27;
        /// <summary>
        /// �j����C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_YOUBI = 28;
        /// <summary>
        /// �ǃl�b�g����C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_KYOKUNETSU = 29;
        /// <summary>
        /// �L�[�ǃR�[�h��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_KEYKYOKUCD = 30;
        /// <summary>
        /// FD���ח�C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_FDDETAILOUTPUT = 31;
        #endregion ����(�ꗗ)�J�����C���f�b�N�X.

        /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD Start */
        #region ���׈ꗗ�J��������.
        /// <summary>
        /// �������ԍ�.
        /// </summary>
        public const string COL_NAME_SEINO = "�������ԍ�";
        /// <summary>
        /// ����.
        /// </summary>
        public const string COL_NAME_KENMEI = "����";
        /// <summary>
        /// �ǃR�[�h.
        /// </summary>
        public const string COL_NAME_KYOKUCD = "�ǃR�[�h";
        /// <summary>
        /// �i��R�[�h.
        /// </summary>
        public const string COL_NAME_HINSYUCD = "�i��R�[�h";
        /// <summary>
        /// ��ږ���.
        /// </summary>
        public const string COL_NAME_HIMOKUNM = "��ږ���";
        /// <summary>
        /// ���ϋ��z.
        /// </summary>
        public const string COL_NAME_HNMAEGAK = "���ϋ��z";
        /// <summary>
        /// �l����.
        /// </summary>
        public const string COL_NAME_HNNERT = "�l����";
        /// <summary>
        /// �l���z.
        /// </summary>
        public const string COL_NAME_NEBIKIGAKU = "�l���z";
        /// <summary>
        /// �������z.
        /// </summary>
        public const string COL_NAME_SEIGAK = "�������z";
        /// <summary>
        /// ����ŗ�.
        /// </summary>
        public const string COL_NAME_ZEIRITSU = "����ŗ�";
        /// <summary>
        /// ����Ŋz.
        /// </summary>
        public const string COL_NAME_ZEIGAKU = "����Ŋz";
        /// <summary>
        /// ����.
        /// </summary>
        public const string COL_NAME_KIKAN = "����";
        /// <summary>
        /// �}�̃R�[�h.
        /// </summary>
        public const string COL_NAME_BAITAICD = "�}�̃R�[�h";
        /// <summary>
        /// ���Ӑ�}�̃R�[�h.
        /// </summary>
        public const string COL_NAME_TOKUIBAITAICD = "�}�̃R�[�h";
        /// <summary>
        /// �㗝�X�R�[�h.
        /// </summary>
        public const string COL_NAME_DAIRITENCD = "�㗝�X�R�[�h";
        /// <summary>
        /// �ԑg�R�[�h.
        /// </summary>
        public const string COL_NAME_BANGUMICD = "�ԑg�R�[�h";
        /// <summary>
        /// ���㖾��NO.
        /// </summary>
        public const string COL_NAME_URIMEINO = "���㖾��No";
        /// <summary>
        /// �f�ړ�.
        /// </summary>
        public const string COL_NAME_KEISAIDT = "�f�ړ�";
        #endregion ���׈ꗗ�J��������.
        /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD End */
        #endregion �萔.

        #region �����o�ϐ�.
        /// <summary>
        /// �i�r�p�����[�^�[.
        /// </summary>
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();
        /// <summary>
        /// �^�[�Q�b�g�}�̃R�[�h.
        /// </summary>
        private string _targetBaitaiCd = "";
        #endregion �����o�ϐ�.

        #region �R���X�g���N�^.
        /// <summary>
        /// �R���X�g���N�^.
        /// </summary>
        public DetailAsh()
        {
            InitializeComponent();
        }
        #endregion �R���X�g���N�^.

        #region �I�[�o�[���C�h.
        #region �X�v���b�h�S�̂ɑ΂��鏉���\���̐ݒ���s��.
        /// <summary>
        /// �X�v���b�h�S�̂ɑ΂��鏉���\���̐ݒ���s��.
        /// </summary>
        protected override void InitDesignForSpdJyutyuListSpread()
        {
            //�󒍓o�^���e(�ꗗ)�X�v���b�h�̃X�v���b�h�E�V�[�g�̐ݒ���s��.
            base.InitDesignForSpdJyutyuListSpread();
        }
        #endregion �X�v���b�h�S�̂ɑ΂��鏉���\���̐ݒ���s��.

        #region �X�v���b�h�̗�ɑ΂��鏉���\���̐ݒ���s��.
        /// <summary>
        /// �X�v���b�h�̗�ɑ΂��鏉���\���̐ݒ���s��.
        /// </summary>
        /// <param name="col"></param>
        protected override void InitDesignForSpdJyutyuListColumns(Column col)
        {
            //�󒍓o�^���e(�ꗗ)�X�v���b�h�̗�P�ʂ̐ݒ���s��.
            base.InitDesignForSpdJyutyuListColumns(col);
        }
        #endregion �X�v���b�h�̗�ɑ΂��鏉���\���̐ݒ���s��.

        #region ���Ӑ�ʂɕ\���ΏۊO��̔�\���������s��.
        /// <summary>
        /// ���Ӑ�ʂɕ\���ΏۊO��̔�\���������s��.
        /// </summary>
        protected override void VisibleColumns()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s.
            base.VisibleColumns();

            //�󒍃J���������[�v����.
            foreach (Column col in base._spdJyutyuList_Sheet1.Columns)
            {
                if (col.Index == COLIDX_JLIST_TOROKU) { col.Visible = true; }           //�o�^.
                if (col.Index == COLIDX_JLIST_TOGO) { col.Visible = false; }            //����. 
                if (col.Index == COLIDX_JLIST_DAIUKE){ col.Visible = true; }            //���.
                if (col.Index == COLIDX_JLIST_SEIKYU) { col.Visible = false; }          //����.
                if (col.Index == COLIDX_JLIST_URIMEINO) { col.Visible = true; }         //���㖾��NO.
                if (col.Index == COLIDX_JLIST_GPYNO) { col.Visible = false; }           //�������[NO.
                if (col.Index == COLIDX_JLIST_SEIYYMM){ col.Visible = true; }           //�����N��.
                if (col.Index == COLIDX_JLIST_GYOMKBN){ col.Visible = true; }           //�Ɩ��敪.
                if (col.Index == COLIDX_JLIST_KENMEI){ col.Visible = true; }            //����.
                if (col.Index == COLIDX_JLIST_BAITAINM) { col.Visible = false; }        //�}�̖�.
                if (col.Index == COLIDX_JLIST_HIMOKUNM){ col.Visible = true; }          //��ږ�.
                if (col.Index == COLIDX_JLIST_KYOKUSHICD){ col.Visible = false; }       //�ǎ�CD.
                if (col.Index == COLIDX_JLIST_SEIKINGAKU){ col.Visible = true; }        //�������z.
                if (col.Index == COLIDX_JLIST_KIKAN){ col.Visible = false; }            //����.
                if (col.Index == COLIDX_JLIST_DANTANKA) { col.Visible = false; }        //�i�P��.
                if (col.Index == COLIDX_JLIST_DANSU) { col.Visible = false; }           //�i��.
                if (col.Index == COLIDX_JLIST_TORIRYOKIN){ col.Visible = true; }        //�旿��.
                if (col.Index == COLIDX_JLIST_NEBIKIRITSU){ col.Visible = true; }       //�l����.
                if (col.Index == COLIDX_JLIST_NEBIKIGAKU){ col.Visible = true; }        //�l���z.
                if (col.Index == COLIDX_JLIST_ZEIRITSU){ col.Visible = true; }          //����ŗ�.
                if (col.Index == COLIDX_JLIST_ZEIGAKU){ col.Visible = true; }           //����Ŋz.
                if (col.Index == COLIDX_JLIST_GOUKEIKINGAKU){ col.Visible = false; }    //�󒍐������z.
                if (col.Index == COLIDX_JLIST_OLDSEIYYMM){ col.Visible = true; }        //�ύX�O�����N��.
            }
        }
        #endregion ���Ӑ�ʂɕ\���ΏۊO��̔�\���������s��.

        #region �Z���̐F�t���������s��.
        /// <summary>
        /// �Z���̐F�t���������s��.
        /// </summary>
        protected override void ChangeColor()
        {
            //�Z���̐F�t������.
            base.ChangeColor();

            //�󒍃f�[�^�����[�v����.
            for (int i = 0; i < _spdJyutyuList_Sheet1.Rows.Count; i++)
            {
                //�w�肵���󒍓o�^���e(�ꗗ)�̍s�ɕR�Â������󒍓o�^���e�f�[�^���擾����.
                drJyutyuData dataRow = getSelectJyutyuData(i);

                //�����t���O="1"�̍s�͔w�i�F��ύX.
                if (dataRow.hb1TouFlg == KKHSystemConst.Tougou.TOUGOU_FLG)
                {
                    _spdJyutyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(255, 255, 208);
                }
                //�ύX�O�����N�����ݒ肳��Ă���(�N���ύX���s���Ă���)�ꍇ�͐����N����ԕ����ɂ���.
                if (dataRow.hb1YymmOld != "")
                {
                    _spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_SEIYYMM].ForeColor = Color.Red;
                }
            }
        }
        #endregion �Z���̐F�t���������s��.

        #region �L����׃f�[�^�̌����E�\��.
        /// <summary>
        /// �L����׃f�[�^�̌����E�\��.
        /// </summary>
        /// <param name="rowIdx"></param>
        protected override void DisplayKkhDetail(int rowIdx)
        {
            //�L����ׂ̏�����.
            _dsDetailAsh.DetailDataAsh.Clear();

            //�ύX���t���O��߂�.
            kkhDetailUpdFlag = false;

            //�L����׃f�[�^�̎擾.
            DetailAshProcessController.FindDetailDataAshByCondParam param = new DetailAshProcessController.FindDetailDataAshByCondParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;

            //�w�肵���󒍓o�^���e�ꗗ�̍s�ɕR�Â������󒍓o�^���e�f�[�^���擾����.
            drJyutyuData dataRow = getSelectJyutyuData(rowIdx);

            //�󒍓o�^���e�ꗗ�̃A�N�e�B�u�ȃV�[�g���擾����.
            SheetView activeSheet = GetActiveSheetViewBySpdJyutyuList();

            //���������Ă���V�[�g���󒍓o�^�ꗗ�̏ꍇ.
            if (activeSheet == _spdJyutyuList_Sheet1)
            {
                //�c�Ə�(��)�R�[�h.
                param.egCd = dataRow.hb1EgCd;
                //���Ӑ��ƃR�[�h.
                param.tksKgyCd = dataRow.hb1TksKgyCd;
                //���Ӑ敔��SEQNO.
                param.tksBmnSeqNo = dataRow.hb1TksBmnSeqNo;
                //���Ӑ�S��SEQNO.
                param.tksTntSeqNo = dataRow.hb1TksTntSeqNo;
                //�N��.
                param.yymm = dataRow.hb1Yymm;
                //��No.
                param.jyutNo = dataRow.hb1JyutNo;
                //�󒍖���No.
                param.jyMeiNo = dataRow.hb1JyMeiNo;
                //���㖾��No.
                param.urMeiNo = dataRow.hb1UrMeiNo;
                //�Ɩ��敪.
                param.gyomKbn = dataRow.hb1GyomKbn;
                //�^�C���X�|�b�g�敪.
                param.tmSpKbn = dataRow.hb1TmspKbn;
                //���ۋ敪.
                param.kokKbn = dataRow.hb1KokKbn;
                //�����敪.
                param.seiKbn = dataRow.hb1SeiKbn;

                //�L����׃f�[�^�̌���.
                DetailAshProcessController processController = DetailAshProcessController.GetInstance();
                FindDetailDataAshByCondServiceResult result = processController.FindDetailDataAshByCond(param);
                //�G���[�̏ꍇ�A�������Ȃ�.
                if (result.HasError == true)
                {
                    return;
                }

                //�L����׃f�[�^�Z�b�g.
                _dsDetailAsh.DetailDataAsh.Merge(result.DetailAshDataSet.DetailDataAsh);
                _dsDetailAsh.DetailDataAsh.AcceptChanges();
                _targetBaitaiCd = result.TargetBaitaiCd;
            }

            //�\���p�L����׃f�[�^�̕ҏW�E�\��.
            _dsDetailAsh.KkhDetail.Clear();
            /* 2015/03/09 �A�T�q�Ή� JSE K.Miyanoue ADD Start */
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParameter.strEsqId, _naviParameter.strEgcd, _naviParameter.strTksKgyCd, _naviParameter.strTksBmnSeqNo, _naviParameter.strTksTntSeqNo);
            /* 2015/03/09 �A�T�q�Ή� JSE K.Miyanoue ADD End */

            //�L����׃f�[�^�������A���[�v����.
            foreach (drDetailData row in _dsDetailAsh.DetailDataAsh.Rows)
            {
                //�����ݒ�.
                drKkhDetail addRow = _dsDetailAsh.KkhDetail.NewKkhDetailRow();

                //�����ԍ�.
                addRow.seiNo = row.hb2Name4;
                /* 2013/01/17 JSE M.Naito MOD Start */
                //addRow.kenmei = row.hb2Name8;
                //����.
                addRow.kenmei = row.hb2Name10;
                /* 2013/01/17 JSE M.Naito MOD End */
                //�}�̃R�[�h��[�G��]�̏ꍇ.
                if (_targetBaitaiCd == KkhConstAsh.BaitaiCd.ZASHI)
                {
                    //�ǃR�[�h.
                    addRow.kyokuCd = row.hb2Code2 + KKHSystemConst.Kigou.SPACE + row.kyokuField2 + KKHSystemConst.Kigou.SPACE + row.hb2Code6;
                }
                //�}�̃R�[�h��[�e���r�^�C���A�e���r�X�|�b�g�A���W�I�^�C���A���W�I�X�|�b�g�A�e���r�l�b�g�X�|�b�g]�̏ꍇ.
                else if (_targetBaitaiCd == KkhConstAsh.BaitaiCd.TV_TIME
                    || _targetBaitaiCd == KkhConstAsh.BaitaiCd.TV_SPOT
                    || _targetBaitaiCd == KkhConstAsh.BaitaiCd.RADIO_TIME
                    || _targetBaitaiCd == KkhConstAsh.BaitaiCd.RADIO_SPOT
                    /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki ADD Start */
                    || _targetBaitaiCd == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                    /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki ADD End */
                {
                    //�ǃR�[�h.
                    addRow.kyokuCd = row.hb2Code2 + KKHSystemConst.Kigou.SPACE + row.kyokuField4 + KKHSystemConst.Kigou.SPACE + row.kyokuField2;
                }
                else
                {
                    //�ǃR�[�h.
                    addRow.kyokuCd = row.hb2Code2 + KKHSystemConst.Kigou.SPACE + row.kyokuField2;
                }
                //�i��R�[�h.
                addRow.hinsyuCd = row.hb2Code3 + KKHSystemConst.Kigou.SPACE + row.shouhinField2;//T
                //��ږ���.
                addRow.himokuNm = row.hb2Name2;
                //�l�����ύX�O���z.
                addRow.hnmaeGak = row.hb2HnmaeGak;
                //�l����.
                addRow.hnNeRt = row.hb2Hnnert;
                /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD Start */
                //�l���z.
                addRow.nebikiGaku = row.hb2NebiGak;
                /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD End */
                //�������z.
                addRow.seiGak = row.hb2SeiGak;
                //����ŗ�.
                addRow.zeiRitsu = row.hb2Ritu1;
                /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD Start */
                //����Ŋz.
                addRow.zeiGaku = row.hb2Kngk1;
                /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD End */
                //����.
                if (string.IsNullOrEmpty(row.hb2Name11)) 
                {
                    addRow.kikan = String.Empty;
                }
                else
                {
                    addRow.kikan = row.hb2Name11.ToString();
                }
                //�}�̃R�[�h.
                addRow.baitaiCd = row.hb2Code1;
                //�㗝�X�R�[�h.
                addRow.dairitenCd = row.hb2Code4;
                //�ԑg�R�[�h.
                addRow.bangumiCd = row.hb2Code5;
                //���㖾��No.
                addRow.uriMeiNo = row.hb2Name3;
                //�b��.
                addRow.byouSuu = row.hb2Sonota1;
                //�{��.
                addRow.honSuu = row.hb2Sonota2;
                //�\����.
                addRow.hyouziJun = String.Empty;
                /* 2013/04/08 HLC T.Sonobe MOD Start */
                //addRow.keisaiHatsubaiBi = FormatPeriod(row.hb2Name5);
                //�f�ڔ�����.
                //�}�̃R�[�h���G���A�V���̏ꍇ.
                if (_targetBaitaiCd == KkhConstAsh.BaitaiCd.ZASHI || _targetBaitaiCd == KkhConstAsh.BaitaiCd.SHINBUN)
                {
                    addRow.keisaiHatsubaiBi = FormatPeriod(row.hb2Name5);
                }
                else
                {
                    addRow.keisaiHatsubaiBi = row.hb2Name5;
                }
                /* 2013/04/08 HLC T.Sonobe MOD End */
                //���[�敪.
                addRow.asaYuuKbn = row.hb2Sonota3;
                //�L�G�敪.
                addRow.kizatsuKbn = row.hb2Sonota5;
                //�f�ڔԍ�.
                addRow.keisaiBan = row.hb2Sonota6;
                //�[�������敪.
                addRow.hasuuSyoriKbn = row.hb2Kbn1;
                //���͔䗦.
                addRow.nyuuryokuHiritsu = row.hb2Ritu2.ToString();
                //�X�y�[�X.
                addRow.space = row.hb2Name1;
                //��������.
                addRow.housouZikan = row.hb2Name6;
                //�j��.
                addRow.youbi = row.hb2Name9;
                //�ǃl�b�g��.
                addRow.kyokuNetSuu = row.hb2Sonota7;
                //�L�[�ǃR�[�h.
                addRow.keyKyokuCd = row.hb2Sonota8;
                //FD����.
                addRow.fd = row.hb2Sonota9;

                /* 2015/03/09 �A�T�q�Ή� JSE K.Miyanoue ADD Start */
                //�}�̃R�[�h��ϊ�����.
                AshBaitaiUtility.BaitaiResult res = ashBaitaiUtility.ConvertOldCdToNewCd(addRow.baitaiCd);
                addRow.tokuiBaitaiCd = res.baitaiCd;
                /* 2015/03/09 �A�T�q�Ή� JSE K.Miyanoue ADD End */
                _dsDetailAsh.KkhDetail.AddKkhDetailRow(addRow);
            }
            _dsDetailAsh.KkhDetail.AcceptChanges();

            //�L����׃f�[�^��1���ȏ㑶�݂���ꍇ.
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                //�I��͈͂̐ݒ�.
                _spdKkhDetail_Sheet1.AddSelection(0, 0, 1, 1);
            }

            /*
             * �{�^���ނ̎g�p�E�s�ݒ�.
             */
            //���ד���.
            btnDetailInput.Enabled = true;
            //���דo�^.
            btnDetailRegister.Enabled = true;

            //�L����׃f�[�^��1���ȏ㑶�݂���ꍇ�A�����E�폜�͉�.
            if (_dsDetailAsh.KkhDetail.Rows.Count > 0)
            {
                btnDetailDel.Enabled = true;
            }
            //�L����׃f�[�^��1�������݂��Ȃ��ꍇ�A�����E�폜�͕s��.
            else
            {
                btnDetailDel.Enabled = false;
            }

            //�Ɩ��敪��[�V��][�G��]�̏ꍇ.
            if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Shinbun || dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Zashi)
            {
                //[����]���\��.
                _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KIKAN].Visible = false;
                //[�f�ړ�]��\��.
                _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KEISAIDT].Visible = true;
                //�Ɩ��敪��[�V��]�̏ꍇ.
                if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Shinbun)
                {
                    //�V��������.
                    _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KEISAIDT].Label = KKHSystemConst.KoteiMongon.KEISAI_DATE_SHINBUN;
                }
                else
                {
                    //�G���f�ړ�.
                    _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KEISAIDT].Label = KKHSystemConst.KoteiMongon.KEISAI_DATE_ZASSI;
                }
            }
            else
            {
                //[����]��\��.
                _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KIKAN].Visible = true;
                //[�f�ړ�]���\��.
                _spdKkhDetail_Sheet1.Columns[COLIDX_MLIST_KEISAIDT].Visible = false;
            }

            //���z�v�Z 
            CalculateSagaku(dataRow);
        }
        #endregion �L����׃f�[�^�̌����E�\��.

        #region �󒍓o�^���e�����O�`�F�b�N����.
        /// <summary>
        /// �󒍓o�^���e�����O�`�F�b�N����.
        /// </summary>
        /// <returns></returns>
        protected override Boolean CheckBeforeSearch()
        {
            //�󒍓o�^���e�����O�`�F�b�N����.
            if (base.CheckBeforeSearch() == false)
            {
                return false;
            }

            return true;
        }
        #endregion �󒍓o�^���e�����O�`�F�b�N����.

        #region �󒍓o�^���e�����O�N���A����.
        /// <summary>
        /// �󒍓o�^���e�����O�N���A����.
        /// </summary>
        protected override void InitializeBeforeSearch()
        {
            //�󒍓o�^���e�����O�N���A����.
            base.InitializeBeforeSearch();

            /*
             * ���x��������.
             */
            //�v.
            lblGoukeiValue.Text = String.Empty;
            //���z.
            lblSagakuValue.Text = String.Empty;
            /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD Start */
            //����ō��z.
            lblZeiSagakuValue.Text = String.Empty;
            /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD End */

            /*
             * �{�^���ނ̎g�p�E�s�ݒ�.
             */
            //�ꊇ����.
            btnBulkMerge.Enabled = false;
            //���ד���.
            btnDetailInput.Enabled = false;
            //���׍폜.
            btnDetailDel.Enabled = false;
            //���דo�^.
            btnDetailRegister.Enabled = false;
            //�I�𓝍�.
            btnMergeAsh.Enabled = false;
        }
        #endregion �󒍓o�^���e�����O�N���A����.

        #region �󒍓o�^���e������`�F�b�N����.
        /// <summary>
        /// �󒍓o�^���e������`�F�b�N���� 
        /// </summary>
        /// <returns></returns>
        protected override Boolean CheckAfterSearch()
        {
            //�󒍓o�^���e������`�F�b�N����.
            if (!base.CheckAfterSearch())
            {
                return false;
            }

            return true;
        }
        #endregion �󒍓o�^���e������`�F�b�N����.

        #region �󒍓o�^���e�����㏉���\������.
        /// <summary>
        /// �󒍓o�^���e�����㏉���\������.
        /// </summary>
        protected override void InitializeAfterSearch()
        {
            //�󒍓o�^���e�����㏉���\������.
            base.InitializeAfterSearch();

            //�{�^���ނ̎g�p�E�s�ݒ�.
            EnableChangeForAfterSearch();
        }
        #endregion �󒍓o�^���e�����㏉���\������.

        #region �󒍍폜�������s�O�`�F�b�N.
        /// <summary>
        /// �󒍍폜�������s�O�`�F�b�N.
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeDelJyutyu()
        {
            //�󒍍폜���s�O�̃`�F�b�N����.
            if (!base.CheckBeforeDelJyutyu())
            {
                return false;
            }

            return true;
        }
        #endregion �󒍍폜�������s�O�`�F�b�N.

        #region �󒍍폜��̏���������.
        /// <summary>
        /// �󒍍폜��̏���������.
        /// </summary>
        protected override void InitAfterDelJyutyu()
        {
            //�󒍍폜��̏���������.
            base.InitAfterDelJyutyu();

            //�폜��A�\������f�[�^��1�������݂��Ȃ��ꍇ.
            if (_spdJyutyuList_Sheet1.Rows.Count == 0)
            {
                /*
                 * �{�^���ނ̎g�p�E�s�ݒ�.
                 */
                //�ꊇ����.
                btnBulkMerge.Enabled = false;
                //���ד���.
                btnDetailInput.Enabled = false;
                //���׍폜.
                btnDetailDel.Enabled = false;
                //���דo�^.
                btnDetailRegister.Enabled = false;
                //�I�𓝍�.
                btnMergeAsh.Enabled = false;
                return;
            }
        }
        #endregion �󒍍폜��̏���������.

        #region �N���ύX�������s�O�`�F�b�N.
        /// <summary>
        /// �N���ύX�������s�O�`�F�b�N.
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeYmChange()
        {
            //�N���ύX�_�C�A���O�\���O�`�F�b�N.
            if (!base.CheckBeforeYmChange())
            {
                return false;
            }

            return true;
        }
        #endregion �N���ύX�������s�O�`�F�b�N.

        #region �V�K�쐬�_�C�A���O�\���O�`�F�b�N.
        /// <summary>
        /// �V�K�쐬�_�C�A���O�\���O�`�F�b�N.
        /// </summary>
        /// <returns></returns>
        protected override bool CheckBeforeRegJyutyu()
        {
            //�V�K�쐬�_�C�A���O�\���O�`�F�b�N.
            return base.CheckBeforeRegJyutyu();
        }
        #endregion �V�K�쐬�_�C�A���O�\���O�`�F�b�N.

        #region MouseMove�C�x���g.
        /// <summary>
        /// MouseMove�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseMoveCommon(object sender, MouseEventArgs e)
        {
            //MouseMove�C�x���g.
            base.MouseMoveCommon(sender, e);
        }
        #endregion MouseMove�C�x���g.

        #region MouseLeave�C�x���g.
        /// <summary>
        /// MouseLeave�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseLeaveCommon(object sender, EventArgs e)
        {
            //MouseLeave�C�x���g.
            base.MouseLeaveCommon(sender, e);
        }
        #endregion MouseLeave�C�x���g.

        #region �󒍓o�^���e(�ꗗ)�Ńt�H�[�J�X������r���[�ɂ���ăR���g���[���̐�����s��.
        /// <summary>
        /// �󒍓o�^���e(�ꗗ)�Ńt�H�[�J�X������r���[�ɂ���ăR���g���[���̐�����s��.
        /// </summary>
        /// <param name="activeSheet">�A�N�e�B�u�̃V�[�g</param>
        /// <param name="activeRow">�A�N�e�B�u�sIndex</param>
        protected override void EnableChangeForSelectJyutyuListRow(SheetView activeSheet, int activeRow)
        {
            //�󒍓o�^���e(�ꗗ)�̑I��͈͕ύX��̊e�R���g���[���̊����^�񊈐��ݒ�.
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
                btnBulkMerge.Enabled = false;

                //���׊֌W�̃{�^���g�p�s��.
                btnDetailInput.Enabled = false;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = false;
                btnMergeAsh.Enabled = false;
            }
        }
        #endregion �󒍓o�^���e(�ꗗ)�Ńt�H�[�J�X������r���[�ɂ���ăR���g���[���̐�����s��.

        #region �󒍓���API���s�p�����[�^�ҏW.
        /// <summary>
        /// �󒍓���API���s�p�����[�^�ҏW.
        /// </summary>
        /// <param name="dtJyutyuData"></param>
        /// <param name="tousakiRownum"></param>
        /// <returns></returns>
        protected override DetailProcessController.MergeJyutyuDataParam CreateServiceParamForMergeJyutyuData(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable dtJyutyuData, int tousakiRownum)
        {
            //�e�̃��\�b�h�����s���ċ��ʕ����̃p�����[�^��ݒ肷��.
            DetailProcessController.MergeJyutyuDataParam param = base.CreateServiceParamForMergeJyutyuData(dtJyutyuData, tousakiRownum);

            //���Ԃ̕ҏW.
            drJyutyuData touSakiRow = dtJyutyuData.FindByrowNum(tousakiRownum);
            string kikanFrom = string.Empty;
            string kikanTo = string.Empty;

            //�Ɩ��敪���e���r�X�|�b�g�A�܂��̓��W�I�A�X�|�b�g�̏ꍇ.
            if (touSakiRow.hb1GyomKbn == KKHSystemConst.GyomKbn.TVSpot || (touSakiRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio && touSakiRow.hb1TmspKbn == KKHSystemConst.TimeSpotKbn.Spot))
            {
                if (touSakiRow.hb1Field4.Length >= 16)
                {
                    kikanFrom = touSakiRow.hb1Field4.Substring(0, 8);
                    kikanTo = touSakiRow.hb1Field4.Substring(8, 8);

                    foreach (drJyutyuData row in dtJyutyuData.Rows)
                    {
                        if (row.hb1Field4.Length >= 16)
                        {
                            string hikakuKikanFrom = row.hb1Field4.Substring(0, 8);
                            string hikakuKikanTo = row.hb1Field4.Substring(8, 8);
                            if (DateTime.Parse(kikanTo.Insert(6, "/").Insert(4, "/")).AddDays(1).CompareTo(DateTime.Parse(hikakuKikanFrom.Insert(6, "/").Insert(4, "/"))) == 0)
                            {
                                kikanTo = hikakuKikanFrom;
                            }
                            else if (DateTime.Parse(kikanFrom.Insert(6, "/").Insert(4, "/")).AddDays(-1).CompareTo(DateTime.Parse(hikakuKikanTo.Insert(6, "/").Insert(4, "/"))) == 0)
                            {
                                kikanFrom = hikakuKikanTo;
                            }
                        }
                    }
                }
            }
            if (kikanFrom.Length > 0 && kikanTo.Length > 0)
            {
                param.dsTougouSaki.THB1DOWN[0].hb1Field4 = kikanFrom + kikanTo;
            }

            return param;
        }
        #endregion �󒍓���API���s�p�����[�^�ҏW.

        #region �󒍓���API�̎��s.
        /// <summary>
        /// �󒍓���API�̎��s.
        /// </summary>
        /// <param name="dtJyutyuData">�����ΏۂƂȂ�󒍃f�[�^(JyutyuData)</param>
        /// <param name="tousakiRownum">������ƂȂ�󒍃f�[�^(JyutyuData)��RowNum</param>
        /// <returns></returns>
        private bool MergeData(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable dtJyutyuData, int tousakiRownum)
        {
            //�����ݒ�.
            DetailProcessController.MergeJyutyuDataParam param = CreateServiceParamForMergeJyutyuData(dtJyutyuData, tousakiRownum);
            DetailAshProcessController.MergeDataParam pParam;
            pParam.esqId = param.esqId;
            pParam.dsTougouMoto = param.dsTougouMoto;
            pParam.dsTougouSaki = param.dsTougouSaki;
            pParam.maxUpdDate = param.maxUpdDate;
            pParam.baitaiCd = GetBaitaiCdByJyutyuData();            

            DetailAshProcessController processController = DetailAshProcessController.GetInstance();
            MergeDataServiceResult result = processController.MergeData(pParam);
            if (result.HasError)
            {
                if (MessageCode.HB_E0020.Equals(result.MessageCode))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0020, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                }
                else
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0006, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                }
                return false;
            }

            return true;
        }
        #endregion �󒍓���API�̎��s.

        #region �󒍃`�F�b�N.
        /// <summary>
        /// �󒍃`�F�b�N.
        /// </summary>
        /// <returns></returns>
        protected override bool UpdateCheckClick()
        {
            //�󒍃`�F�b�N.
            if (!base.UpdateCheckClick())
            {
                return false;
            }

            // �I�y���[�V�������O�̏o��.
            KKHLogUtilityAsh.WriteOperationLogToDB(_naviParameter, KKHSystemConst.ApplicationID.APLID_DTL_ASH, KKHLogUtilityAsh.KINO_ID_OPERATION_LOG_UpdCheck, KKHLogUtilityAsh.DESC_OPERATION_LOG_UpdCheck);

            return true;
        }
        #endregion �󒍃`�F�b�N.
        #endregion �I�[�o�[���C�h.

        #region �C�x���g.
        #region ��ʑJ�ڂ��邽�тɔ������܂�.
        /// <summary>
        /// ��ʑJ�ڂ��邽�тɔ������܂�.
        /// </summary>
        /// <param name="sender">�J�ڌ��t�H�[��</param>
        /// <param name="arg">�C�x���g�f�[�^</param>
        private void DetailAsh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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
        #endregion ��ʑJ�ڂ��邽�тɔ������܂�.

        #region �t�H�[�����[�h�C�x���g.
        /// <summary>
        /// �t�H�[�����[�h�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailAsh_Shown(object sender, EventArgs e)
        {
            //�e�R���g���[���̏����ݒ�.
            InitializeControlAsh();

            //�L����׃X�v���b�h�̃f�U�C�����������s��.
            InitializeDesignForSpdKkhDetail();
        }
        #endregion �t�H�[�����[�h�C�x���g.

        #region ���ד��̓{�^���N���b�N.
        /// <summary>
        /// ���ד��̓{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailInput_Click(object sender, EventArgs e)
        {
            //�Ώۂ̎󒍃f�[�^�A���׃f�[�^�擾.
            drJyutyuData dataRow = getSelectJyutyuData(-1);
            int rowDetailIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

            //���ד��͉�ʕ\��.
            KKHNaviParameter naviParam = _naviParameter;
            naviParam.DataRow = dataRow;
            naviParam.DataTable2 = _dsDetail.JyutyuData;
            naviParam.StrValue1 = GetBaitaiCdByJyutyuData();
            naviParam.DataTable1 = _dsDetailAsh.KkhDetail;
            naviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1;
            object result = Navigator.ShowModalForm(this, "toDetailInputAsh", naviParam);
            if (result == null)
            {
                this.ActiveControl = null;
                return;
            }
            //�L����וύX�t���O���X�V.
            base.kkhDetailUpdFlag = true; 
            KKHNaviParameter naviParamOut = (KKHNaviParameter)result;
            Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailDataTable dtKkhDetailNew = (Isid.KKH.Ash.Schema.DetailDSAsh.KkhDetailDataTable)naviParamOut.DataTable1;
            _dsDetailAsh.KkhDetail.Clear();
            _dsDetailAsh.KkhDetail.Merge(dtKkhDetailNew);

            //���z�v�Z.
            CalculateSagaku(dataRow);
            //�{�^����������.
            if (_dsDetailAsh.KkhDetail.Rows.Count > 0)
            {
                btnDetailDel.Enabled = true;
            }
            else
            {
                btnDetailDel.Enabled = false;
            }
            this.ActiveControl = null;
        }
        #endregion ���ד��̓{�^���N���b�N.

        #region ���דo�^�{�^���N���b�N�C�x���g.
        /// <summary>
        /// ���דo�^�{�^���N���b�N�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailRegister_Click(object sender, EventArgs e)
        {
            /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga MOD Start */
            //decimal sagaku = 0M;
            //if (decimal.TryParse(lblSagakuValue.Text, out sagaku) == false || sagaku == 0M)
            //{
            //    if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_C0002, null, "���דo�^", MessageBoxButtons.YesNo))
            //    {
            //        this.ActiveControl = null;
            //        return;
            //    }
            //}
            //else
            //{
            //    if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_W0089, null, "���דo�^", MessageBoxButtons.YesNo))
            //    {
            //        this.ActiveControl = null;
            //        return;
            //    }
            //}
            //RegistDetailData();
            //ActiveControl = null;

            /*
             * ���דo�^�m�F����.
             */
            //�o�^�m�F���b�Z�[�W�Łm�͂��n��I�������ꍇ.
            if (RegistSagakuCheck())
            {
                //���דo�^����.
                RegistDetailData();
            }
            //�o�^�m�F���b�Z�[�W�Łm�������n��I�������ꍇ�A�������Ȃ�.
            else
            {
                return;
            }
            /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga MOD End */
        }
        #endregion ���דo�^�{�^���N���b�N�C�x���g.

        #region �ꊇ�����{�^���N���b�N�C�x���g.
        /// <summary>
        /// �ꊇ�����{�^���N���b�N�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBulkMerge_Click(object sender, EventArgs e)
        {
            //�ꊇ��������.
            BulkMergeClick();
            this.ActiveControl = null;
        }
        #endregion �ꊇ�����{�^���N���b�N�C�x���g.

        #region ���׍폜�{�^���N���b�N.
        /// <summary>
        /// ���׍폜�{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailDel_Click(object sender, EventArgs e)
        {
            //�m�F���b�Z�[�W.
            if (MessageUtility.ShowMessageBox(MessageCode.HB_C0009, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.YesNo) != DialogResult.Yes) 
            {
                return;
            }                  

            int rowIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

            _spdKkhDetail_Sheet1.RemoveRows(rowIndex, 1);

            //�s�̍폜���f�[�^�ɔ��f.
            _dsDetailAsh.KkhDetail.AcceptChanges();

            //�L����וύX�t���O���X�V.
            base.kkhDetailUpdFlag = true;

            /*
             * �{�^���ނ̎g�p�E�s�ݒ� 
            */
            //�L����׃f�[�^�����ɂ���ꍇ�͍폜�͉�.
            if (_spdKkhDetail_Sheet1.Rows.Count > 0)
            {
                btnDetailDel.Enabled = true;
            }
            //�L����׃f�[�^���Ȃ��ꍇ�͍폜�͕s��.
            else
            {
                btnDetailDel.Enabled = false;
            }

            /*
             * ���z�E�v���x��.
            */
            //�󒍓o�^���e�̑I���s���̎擾.
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);

            //���z�v�Z.
            CalculateSagaku(dataRow);

            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(_spdKkhDetail_Sheet1.ActiveRowIndex, -1, 1, -1);
            }

            this.ActiveControl = null;
        }
        #endregion ���׍폜�{�^���N���b�N.

        #region �I�𓝍��{�^���N���b�N�C�x���g.
        /// <summary>
        /// �I�𓝍��{�^���N���b�N�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMergeAsh_Click(object sender, EventArgs e)
        {
            //�I�𓝍�����.
            MergeClick();
            this.ActiveControl = null;
        }
        #endregion �I�𓝍��{�^���N���b�N�C�x���g.

        #region �ꊇ��������.
        /// <summary>
        /// �ꊇ��������.
        /// </summary>
        private void BulkMergeClick()
        {
            /*
             * �������s�O�`�F�b�N�E�Ώۃf�[�^�擾.
             * �L����ׂ̕ҏW�󋵊m�F.
            */
            if (ConfirmEditStatus() == false)
            {
                this.ActiveControl = null;
                return;
            }

            dsDetail dsDetail = new dsDetail();
            //�A�N�e�B�u�s�̎擾.
            int activeRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            //�w�肵���󒍓o�^���e(�ꗗ)�̍s�ɕR�Â������󒍓o�^���e�f�[�^���擾����.
            drJyutyuData activeRow = getSelectJyutyuData(activeRowIdx);
            {
                //�t�B���^�ŉB��Ă��郌�R�[�h�������ΏۂɂȂ��Ă���ꍇ�̓G���[�\��.
                String jyutnoKey = _spdJyutyuList_Sheet1.Cells[activeRowIdx, COLIDX_JLIST_URIMEINO].Text.Substring(0, 10);

                for (int i = 0; i < _spdJyutyuList_Sheet1.Rows.Count; i++)
                {
                    String jyutno = _spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_URIMEINO].Text.Substring(0, 10);

                    if (!jyutnoKey.Equals(jyutno))
                    {
                        continue;
                    }

                    if (_spdJyutyuList_Sheet1.RowFilter.IsRowFilteredOut(i))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0146, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                        return;
                    }
                }
            }

            //�����Ώۍs�f�[�^�̎擾.
            string filterEx = dsDetail.THB1DOWN.hb1JyutNoColumn.ColumnName + "='" + activeRow.hb1JyutNo + "'";
            filterEx = filterEx + " AND " + dsDetail.THB1DOWN.hb1TJyutNoColumn.ColumnName + "=''";
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] targetRows = (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[])_dsDetail.JyutyuData.Select(filterEx);

            foreach (drJyutyuData targetRow in targetRows)
            {
                //�I������Ă���󒍓o�^���e�̍s�����̏������J��Ԃ�.
                if (targetRow.hb1TouFlg == "1")
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0015, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                    return;
                }

                drJyutyuData addRow = dsDetail.JyutyuData.NewJyutyuDataRow();
                addRow.ItemArray = (object[])targetRow.ItemArray;
                dsDetail.JyutyuData.AddJyutyuDataRow(addRow);
            }

            //�����������s.
            if (!MergeJyutyuData(dsDetail.JyutyuData, activeRow.rowNum))
            {
                this.ActiveControl = null;
                return;
            }

            /*
             * �Č����E�\�� 
            */
            //���s���ʂ�����ȏꍇ�A�󒍓���������̍ĕ\���������s��.
            ReSearchJyutyuData();
            if (_spdJyutyuList_Sheet1.RowCount >= activeRowIdx + 1)
            {
                _spdJyutyuList_Sheet1.SetActiveCell(activeRowIdx, 0, true);
                _spdJyutyuList_Sheet1.AddSelection(activeRowIdx, -1, 1, -1);
                spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);
            }

            //�I���s�𖾍ׂɕ\������.
            DisplayKkhDetail(_spdJyutyuList_Sheet1.ActiveRowIndex);
            MessageUtility.ShowMessageBox(MessageCode.HB_I0009, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
            this.ActiveControl = null;
        }
        #endregion �ꊇ��������.

        #region �I�𓝍�����.
        /// <summary>
        /// �I�𓝍�����.
        /// </summary>
        private void MergeClick()
        {
            /*
             * ������I���_�C�A���O�\���O�`�F�b�N�E�Ώۃf�[�^�擾.
             * �L����ׂ̕ҏW�󋵊m�F 
            */
            if (ConfirmEditStatus() == false)
            {
                this.ActiveControl = null;
                return;
            }

            dsDetail dsDetail = new dsDetail();

            //�I���s�̎擾.
            CellRange[] cellRanges = SortCellRangesByRowIdx(_spdJyutyuList_Sheet1.GetSelections());

            if (cellRanges.Length < 1 || (cellRanges.Length == 1 && cellRanges[0].RowCount < 2))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0084, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                this.ActiveControl = null;
                return;
            }
            foreach (CellRange cellRange in cellRanges)
            {
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    //�I������Ă���󒍓o�^���e�̍s�����̏������J��Ԃ�.
                    int rowIndex = cellRange.Row + i;

                    //�t�B���^�����O�Ō����Ȃ��Ȃ��Ă���ꍇ�̓G���[��\������.
                    if (_spdJyutyuList_Sheet1.RowFilter.IsRowFilteredOut(rowIndex))
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0146, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                        return;
                    }

                    drJyutyuData dataRow = getSelectJyutyuData(rowIndex);
                    if (dataRow.hb1TouFlg == "1")
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0015, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                        return;
                    }

                    drJyutyuData addRow = dsDetail.JyutyuData.NewJyutyuDataRow();
                    addRow.ItemArray = (object[])dataRow.ItemArray;
                    dsDetail.JyutyuData.AddJyutyuDataRow(addRow);
                }
            }

            /*
             * ������I����ʂ̕\�� 
            */
            _naviParameter.DsDetail = dsDetail;
            _naviParameter.AplId = AplId;
            object obj = Navigator.ShowModalForm(this, "toJyutyuMerge", _naviParameter);

            if (obj == null)
            {
                this.ActiveControl = null;
                return;
            }

            //�����������s 
            KKHNaviParameter naviParameterOut = (KKHNaviParameter)obj;
            if (MergeData(dsDetail.JyutyuData, naviParameterOut.IntValue1) == false)
            {
                this.ActiveControl = null;
                return;
            }

            /*
             * �Č����E�\�� 
            */
            //���s���ʂ�����ȏꍇ�A�󒍓���������̍ĕ\���������s��.
            ReSearchJyutyuData();

            if (_spdJyutyuList_Sheet1.RowCount >= cellRanges[0].Row + 1)
            {
                _spdJyutyuList_Sheet1.SetActiveCell(cellRanges[0].Row, 0, true);
                _spdJyutyuList_Sheet1.AddSelection(cellRanges[0].Row, -1, 1, -1);
                spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);
            }

            /*
             * �L����� 
            */
            //�I���s�𖾍ׂɕ\������.
            DisplayKkhDetail(_spdJyutyuList_Sheet1.ActiveRowIndex);
            MessageUtility.ShowMessageBox(MessageCode.HB_I0009, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
            this.ActiveControl = null;
        }
        #endregion �I�𓝍�����.
        #endregion �C�x���g.

        #region ���\�b�h.
        #region ���z�v�Z.
        /// <summary>
        /// ���z�v�Z.
        /// </summary>
        private void CalculateSagaku(Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            //�����ݒ�.
            decimal delRyoukinGoukei = 0M;
            decimal delSagaku = 0M;
            String strRyoukin = String.Empty;
            /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD Start */
            decimal delZeiGoukei = 0M;
            decimal delZeiSagaku = 0M;
            String strZei = string.Empty;
            /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD End */

            //���ׂ̌��������[�v����.
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                //���ׂ̗������擾.
                strRyoukin = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIGAK].Text.Trim();

                /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD Start */
                //���ׂ̏���ł��擾.
                strZei = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_ZEIGAKU].Text.Trim();
                /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD End */

                //���ׂ̗��������͂���Ă���ꍇ�A�������v�ɉ��Z.
                if (KKHUtility.IsNumeric(strRyoukin))
                {
                    delRyoukinGoukei = delRyoukinGoukei + decimal.Parse(strRyoukin);
                }

                /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD Start */
                //���ׂ̏���ł����͂���Ă���ꍇ�A����ō��v�ɉ��Z.
                if (KKHUtility.IsNumeric(strZei))
                {
                    delZeiGoukei = delZeiGoukei + decimal.Parse(strZei);
                }
                /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD End */
            }

            /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD Start */
            //�����.
            delZeiSagaku = dataRow.hb1SzeiGak - delZeiGoukei;
            lblZeiSagakuValue.Text = delZeiSagaku.ToString(KKHSystemConst.Format.GAKU_FORMAT);
            /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD End */

            //���z.
            delSagaku = dataRow.hb1SeiGak - delRyoukinGoukei;
            lblSagakuValue.Text = delSagaku.ToString(KKHSystemConst.Format.GAKU_FORMAT);

            //���v.
            lblGoukeiValue.Text = delRyoukinGoukei.ToString(KKHSystemConst.Format.GAKU_FORMAT);
        }
        #endregion ���z�v�Z.

        #region �L����ׂ̃f�[�^�\�[�X�X�V.
        /// <summary>
        /// �L����ׂ̃f�[�^�\�[�X�X�V.
        /// </summary>
        /// <param name="dsDetailAsh"></param>
        private void UpdateDataSourceByDetailDataSetAsh(DetailDSAsh dsDetailAsh)
        {
            //�L����ׂ̃f�[�^�\�[�X�X�V.
            _dsDetailAsh.Clear();
            _dsDetailAsh.Merge(_dsDetailAsh);
            _dsDetailAsh.AcceptChanges();
        }
        #endregion �L����ׂ̃f�[�^�\�[�X�X�V.

        #region �e�R���g���[���̏����ݒ�.
        /// <summary>
        /// �e�R���g���[���̏����ݒ�.
        /// </summary>
        private void InitializeControlAsh()
        {
            //����������.
            lblKenMei.Visible = false;
            txtKenMei.Visible = false;
            lblKikan.Visible = false;
            txtYmdTo.Visible = false;

            //�{�^����.
            btnBulkMerge.Enabled = false;
            btnDetailInput.Enabled = false;
            btnDetailDel.Enabled = false;
            btnDetailRegister.Enabled = false;
            btnMergeAsh.Enabled = false;
        }
        #endregion �e�R���g���[���̏����ݒ�.

        #region �L����׃X�v���b�h�̃f�U�C�����������s��.
        /// <summary>
        /// �L����׃X�v���b�h�̃f�U�C�����������s��.
        /// </summary>
        private void InitializeDesignForSpdKkhDetail()
        {
            //�񖈂̐ݒ�.
            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                //�Z���̕ҏW�s��.
                col.Locked = true;

                //�t�B���^�@�\��L��.
                col.AllowAutoFilter = true;

                //�\�[�g�@�\��L��.
                col.AllowAutoSort = true;

                //�������ԍ�.
                if (col.Index == COLIDX_MLIST_SEINO)
                {
                    col.Label = COL_NAME_SEINO;
                    col.Width = 100;
                }
                //����.
                else if (col.Index == COLIDX_MLIST_KENMEI)
                {
                    col.Label = COL_NAME_KENMEI;
                    col.Width = 200;
                }
                //�ǃR�[�h.
                else if (col.Index == COLIDX_MLIST_KYOKUCD)
                {
                    col.Label = COL_NAME_KYOKUCD;
                    col.Width = 150;
                }
                //�i��R�[�h.
                else if (col.Index == COLIDX_MLIST_HINSYUCD)
                {
                    col.Label = COL_NAME_HINSYUCD;
                    col.Width = 100;
                }
                //��ږ���.
                else if (col.Index == COLIDX_MLIST_HIMOKUNM)
                {
                    col.Label = COL_NAME_HIMOKUNM;
                    col.Width = 80;
                }
                //���ϋ��z.
                else if (col.Index == COLIDX_MLIST_HNMAEGAK)
                {
                    col.Label = COL_NAME_HNMAEGAK;
                    col.Width = 150;

                    //�Z���̏����ݒ�.
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                //�l����.
                else if (col.Index == COLIDX_MLIST_HNNERT)
                {
                    col.Label = COL_NAME_HNNERT;
                    col.Width = 80;

                    //�Z���̏����ݒ�.
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 1;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD Start */
                //�l���z.
                else if (col.Index == COLIDX_MLIST_NEBIKIGAKU)
                {
                    col.Label = COL_NAME_NEBIKIGAKU;
                    col.Width = 150;

                    //�Z���̏����ݒ�.
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD End */
                //�������z.
                else if (col.Index == COLIDX_MLIST_SEIGAK)
                {
                    col.Label = COL_NAME_SEIGAK;
                    col.Width = 150;

                    //�Z���̏����ݒ�.
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                //����ŗ�.
                else if (col.Index == COLIDX_MLIST_ZEIRITSU)
                {
                    col.Label = COL_NAME_ZEIRITSU;
                    col.Width = 80;

                    //�Z���̏����ݒ�.
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 1;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD Start */
                //����Ŋz.
                else if (col.Index == COLIDX_MLIST_ZEIGAKU)
                {
                    col.Label = COL_NAME_ZEIGAKU;
                    col.Width = 150;

                    //�Z���̏����ݒ�.
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    col.CellType = cellType;
                }
                /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD End */
                //����.
                else if (col.Index == COLIDX_MLIST_KIKAN)
                {
                    col.Label = COL_NAME_KIKAN;
                    col.Width = 220;
                }
                /* 2015/03/11 �A�T�q�Ή� Miyanoue ADD Start */
                //�}�̃R�[�h.
                else if (col.Index == COLIDX_MLIST_BAITAICD)
                {
                    col.Label = COL_NAME_BAITAICD;
                    col.Width = 0;
                }
                //���Ӑ�}�̃R�[�h.
                else if (col.Index == COLIDX_MLIST_TOKUIBAITAICD)
                {
                    col.Label = COL_NAME_TOKUIBAITAICD;
                    col.Width = 100;
                }
                /* 2015/03/11 �A�T�q�Ή� Miyanoue ADD End */
                //�㗝�X�R�[�h.
                else if (col.Index == COLIDX_MLIST_DAIRITENCD)
                {
                    col.Label = COL_NAME_DAIRITENCD;
                    col.Width = 100;
                }
                //�ԑg�R�[�h.
                else if (col.Index == COLIDX_MLIST_BANGUMICD)
                {
                    col.Label = COL_NAME_BANGUMICD;
                    col.Width = 100;
                }
                //���㖾��NO.
                else if (col.Index == COLIDX_MLIST_URIMEINO)
                {
                    col.Label = COL_NAME_URIMEINO;
                    col.Width = 130;
                }
                //�f�ړ�.
                else if (col.Index == COLIDX_MLIST_KEISAIDT)
                {
                    col.Label = COL_NAME_KEISAIDT;
                    col.Width = 150;
                }
                else
                {
                    col.Visible = false;
                }
            }

            //���׃f�[�^��1���ȏ�A���݂���ꍇ.
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                //�I��͈͂̐ݒ�.
                _spdKkhDetail_Sheet1.AddSelection(0, 0, 1, 1);
            }
        }
        #endregion �L����׃X�v���b�h�̃f�U�C�����������s��.

        #region �󒍓o�^���e������̊e�R���g���[���̊���/�񊈐��ݒ�.
        /// <summary>
        /// �󒍓o�^���e������̊e�R���g���[���̊���/�񊈐��ݒ� 
        /// </summary>
        private void EnableChangeForAfterSearch()
        {
            //�ꊇ����.
            btnBulkMerge.Enabled = true;

            //�I�𓝍�.
            btnMergeAsh.Enabled = true;
        }
        #endregion �󒍓o�^���e������̊e�R���g���[���̊���/�񊈐��ݒ�.

        #region ���דo�^����.
        /// <summary>
        /// ���דo�^����.
        /// </summary>
        private void RegistDetailData()
        {
            //���[�f�B���O�\���J�n.
            base.ShowLoadingDialog();

            //�T�[�r�X�p�����[�^�p�ϐ�.
            dsDetail dsDetail = new dsDetail();
            dsDetail TouKoudsDetail = new dsDetail();
            string esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            DateTime maxUpdDate = new DateTime();
            int activeRow = (int)base._spdJyutyuList_Sheet1.ActiveRowIndex;

            //�󒍓o�^�f�[�^�ҏW.
            drJyutyuData dataRow = getSelectJyutyuData(-1);
            dtTHB1DOWN dtThb1Down = new dtTHB1DOWN();
            drTHB1DOWN thb1DownRow = dtThb1Down.NewTHB1DOWNRow();
            //�X�V�v���O����.
            thb1DownRow.hb1UpdApl = AplId;
            //�X�V�S����.
            thb1DownRow.hb1UpdTnt = _naviParameter.strEsqId;
            //�c�Ə�(��)�R�[�h.
            thb1DownRow.hb1EgCd = dataRow.hb1EgCd;
            //���Ӑ��ƃR�[�h.
            thb1DownRow.hb1TksKgyCd = dataRow.hb1TksKgyCd;
            //���Ӑ敔��SEQNO.
            thb1DownRow.hb1TksBmnSeqNo = dataRow.hb1TksBmnSeqNo;
            //���Ӑ�S��SEQNO.
            thb1DownRow.hb1TksTntSeqNo = dataRow.hb1TksTntSeqNo;
            //�N��.
            thb1DownRow.hb1Yymm = dataRow.hb1Yymm;
            //�����t���O.
            thb1DownRow.hb1TouFlg = dataRow.hb1TouFlg;
            //��No.
            thb1DownRow.hb1JyutNo = dataRow.hb1JyutNo;
            //�󒍖���No.
            thb1DownRow.hb1JyMeiNo = dataRow.hb1JyMeiNo;
            //���㖾��No.
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
            //�o�^�ҁA�X�V�҂̓o�^.
            thb1DownRow.hb1TrkTnt = string.Empty;
            thb1DownRow.hb1TrkTntNm = string.Empty;
            thb1DownRow.hb1KsnTnt = string.Empty;
            thb1DownRow.hb1KsnTntNm = string.Empty;

            //���ׂ��Ȃ��ꍇ.
            if (thb1DownRow.hb1MeisaiFlg.Equals("0"))
            {
                //�o�^�ҁA�X�V�҂����݂��Ȃ��ꍇ�A�������Ȃ�.
                if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) && string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                }
                //�o�^�҂���ŁA�X�V�҂����݂���ꍇ�A�������Ȃ�.
                else if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) && !string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                }else
                {
                    /*
                     * �X�V�҂�o�^.
                     */
                    //�X�V��.
                    thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                    //�X�V�S���Җ�.
                    thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                }
            }
            //���ׂ�����ꍇ.
            else
            {
                //�o�^�S���҂��󂩂X�V�҂���łȂ��ꍇ.
                if (string.IsNullOrEmpty(dataRow.hb1TrkTntNm.Trim()) && !string.IsNullOrEmpty(dataRow.hb1KsnTntNm.Trim()))
                {
                    /*
                     * �o�^�ҁA�X�V�җ��������.
                     */
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
                    /*
                     * �o�^�҂݂̂�����.
                     */
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
                    /*
                     * �X�V�҂݂̂�����.
                     */
                    //�X�V��.
                    thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                    //�X�V�S���Җ�.
                    thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                }
            }

            //�f�[�^����������Ă���ꍇ�A�q�̌��ƂȂ����f�[�^�ɓo�^�S���ҁA�X�V�҂�o�^����.
            if (dataRow.hb1TouFlg.Equals("1"))
            {
                drTHB1DOWN tokoaddrow = TouKoudsDetail.THB1DOWN.NewTHB1DOWNRow();
                //�X�V�v���O����.
                tokoaddrow.hb1UpdApl = base.AplId;
                //�X�V�S����.
                tokoaddrow.hb1UpdTnt = _naviParameter.strEsqId;
                //�c�Ə��i��j�R�[�h.
                tokoaddrow.hb1EgCd = _naviParameter.strEgcd;
                //���Ӑ��ƃR�[�h.
                tokoaddrow.hb1TksKgyCd = _naviParameter.strTksKgyCd;
                //���Ӑ敔��SEQNO.
                tokoaddrow.hb1TksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
                //���Ӑ�S��SEQNO.
                tokoaddrow.hb1TksTntSeqNo = _naviParameter.strTksTntSeqNo;
                //�N��.
                tokoaddrow.hb1Yymm = dataRow.hb1Yymm;
                //�����t���O.
                tokoaddrow.hb1TouFlg = dataRow.hb1TouFlg;
                //��No.
                tokoaddrow.hb1JyutNo = dataRow.hb1JyutNo;
                //�󒍖���No.
                tokoaddrow.hb1JyMeiNo = dataRow.hb1JyMeiNo;
                //���㖾��No.
                tokoaddrow.hb1UrMeiNo = dataRow.hb1UrMeiNo;
                //�������t���O.
                tokoaddrow.hb1MeisaiFlg = thb1DownRow.hb1MeisaiFlg;

                //�o�^�S���Җ������݂��Ȃ��ꍇ.
                if (!string.IsNullOrEmpty(thb1DownRow.hb1TrkTntNm))
                {
                    //�o�^�S����ID.
                    tokoaddrow.hb1TrkTnt = thb1DownRow.hb1TrkTnt;
                    //�o�^�S���Җ�.
                    tokoaddrow.hb1TrkTntNm = thb1DownRow.hb1TrkTntNm;
                }
                //�o�^�S���Җ������݂���ꍇ.
                else
                {
                    //�o�^�S����ID.
                    tokoaddrow.hb1TrkTnt = null;
                    //�o�^�S���Җ�.
                    tokoaddrow.hb1TrkTntNm = null;
                }

                //���׍X�V�Җ������݂���ꍇ.
                if (!string.IsNullOrEmpty(thb1DownRow.hb1KsnTntNm))
                {
                    //���׍X�V��ID.
                    tokoaddrow.hb1KsnTnt = thb1DownRow.hb1KsnTnt;
                    //���׍X�V�Җ�.
                    tokoaddrow.hb1KsnTntNm = thb1DownRow.hb1KsnTntNm;
                }
                //���׍X�V�Җ������݂��Ȃ��ꍇ.
                else
                {
                    //���׍X�V��ID.
                    tokoaddrow.hb1KsnTnt = null;
                    //���׍X�V�Җ�.
                    tokoaddrow.hb1KsnTntNm = null;
                }

                TouKoudsDetail.THB1DOWN.AddTHB1DOWNRow(tokoaddrow);
            }
            dtThb1Down.AddTHB1DOWNRow(thb1DownRow);
            dsDetail.THB1DOWN.Merge(dtThb1Down);

            //�L����דo�^�f�[�^�ҏW.
            dtTHB2KMEI dtThb2Kmei = new dtTHB2KMEI();

            //���׌��������[�v����.
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                //�����ݒ�.
                object cellValue = null;
                object ksaibi = null;
                object kikan = null;

                //�}�̃R�[�h.
                object baiCd = KKHUtility.ToString(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value);

                //�L����׃f�[�^�ݒ�.
                drTHB2KMEI addRow = dtThb2Kmei.NewTHB2KMEIRow();
                //�^�C���X�^���v.
                addRow.hb2TimStmp = new DateTime();
                //�X�V�v���O����.
                addRow.hb2UpdApl = AplId;
                //�X�V�S����.
                addRow.hb2UpdTnt = _naviParameter.strEsqId;
                //�c�Ə��R�[�h.
                addRow.hb2EgCd = dataRow.hb1EgCd;
                //���Ӑ��ƃR�[�h.
                addRow.hb2TksKgyCd = dataRow.hb1TksKgyCd;
                //���Ӑ敔��SEQNO.
                addRow.hb2TksBmnSeqNo = dataRow.hb1TksBmnSeqNo;
                //���Ӑ�S��SEQNO.
                addRow.hb2TksTntSeqNo = dataRow.hb1TksTntSeqNo;
                //�N��.
                addRow.hb2Yymm = dataRow.hb1Yymm;
                //��No.
                addRow.hb2JyutNo = dataRow.hb1JyutNo;
                //�󒍖���No.
                addRow.hb2JyMeiNo = dataRow.hb1JyMeiNo;
                //���㖾��No.
                addRow.hb2UrMeiNo = dataRow.hb1UrMeiNo;
                //��ڃR�[�h.
                addRow.hb2HimkCd = dataRow.hb1HimkCd;
                /* 2013/05/09 HLC T.Sonobe MOD Start */
                //�A�Ԃ�999�𒴂����ꍇ�A�����𒆎~����.
                //if (i + 1 > 999)
                //{
                //    //���[�f�B���O�\���I�� 
                //    base.CloseLoadingDialog();
                //    //�G���[���b�Z�[�W���o�� 
                //    MessageUtility.ShowMessageBox(MessageCode.HB_W0155, 
                //        null, "���דo�^�G���[", MessageBoxButtons.OK);
                //    return;
                //}
                //addRow.hb2Renbn = (i + 1).ToString("000");

                //�A�Ԃ�9999�𒴂����ꍇ�A�����𒆎~����.
                if (i + 1 > 9999)
                {
                    //���[�f�B���O�\���I��.
                    base.CloseLoadingDialog();

                    //�G���[���b�Z�[�W���o��.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0155, null, KKHSystemConst.KoteiMongon.ERR_DETAIL_REGIST, MessageBoxButtons.OK);
                    return;
                }
                //�A��.
                addRow.hb2Renbn = (i + 1).ToString("0000");
                /* 2013/05/09 HLC T.Sonobe MOD End */
                //�N����From.
                addRow.hb2DateFrom = KKHSystemConst.Kigou.SPACE;
                //�N����To.
                addRow.hb2DateTo = KKHSystemConst.Kigou.SPACE;
                //�����z.
                addRow.hb2SeiGak = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEIGAK].Value;
                //���ϗ�.
                addRow.hb2Hnnert = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HNNERT].Value;
                //���ϊz.
                addRow.hb2HnmaeGak = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HNMAEGAK].Value;
                /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga MOD Start */
                //�l���z.
                //addRow.hb2NebiGak = 0M;
                addRow.hb2NebiGak = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NEBIKIGAKU].Value;
                /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga MOD End */
                addRow.hb2Date1 = KKHSystemConst.Kigou.SPACE;
                addRow.hb2Date2 = KKHSystemConst.Kigou.SPACE;
                addRow.hb2Date3 = KKHSystemConst.Kigou.SPACE;
                addRow.hb2Date4 = KKHSystemConst.Kigou.SPACE;
                addRow.hb2Date5 = KKHSystemConst.Kigou.SPACE;
                addRow.hb2Date6 = KKHSystemConst.Kigou.SPACE;
                //�[�������敪.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HASUSYORIKBN].Value;
                //�[�������敪�����݂��Ă���A�܂���[0]�ȊO�̏ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "" && Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "0")
                {
                    addRow.hb2Kbn1 = cellValue.ToString();
                }
                //�[�������敪�����݂��Ȃ��A�܂���[0]�̏ꍇ.
                else
                {
                    addRow.hb2Kbn1 = KKHSystemConst.Kigou.SPACE;
                }
                //�敪2.
                addRow.hb2Kbn2 = KKHSystemConst.Kigou.SPACE;
                //�敪3.
                addRow.hb2Kbn3 = KKHSystemConst.Kigou.SPACE;
                //�}�̃R�[�h.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value;
                //�}�̃R�[�h�����݂���ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Code1 = cellValue.ToString();
                }
                //�}�̃R�[�h�����݂��Ȃ��ꍇ.
                else
                {
                    addRow.hb2Code1 = KKHSystemConst.Kigou.SPACE;
                }
                //�ǃR�[�h.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KYOKUCD].Value;
                //�ǃR�[�h�����݂���ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Code2 = cellValue.ToString().Split(' ')[0];
                }
                //�ǃR�[�h�����݂��Ȃ��ꍇ.
                else
                {
                    addRow.hb2Code2 = KKHSystemConst.Kigou.SPACE;
                }
                //�i��R�[�h.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HINSYUCD].Value;
                //�i��R�[�h�����݂���ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Code3 = cellValue.ToString().Split(' ')[0];
                }
                //�i��R�[�h�����݂��Ȃ��ꍇ.
                else
                {
                    addRow.hb2Code3 = KKHSystemConst.Kigou.SPACE;
                }
                //�㗝�X�R�[�h.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_DAIRITENCD].Value;
                //�㗝�X�R�[�h�����݂���ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Code4 = cellValue.ToString();
                }
                //�㗝�X�R�[�h�����݂��Ȃ��ꍇ.
                else
                {
                    addRow.hb2Code4 = KKHSystemConst.Kigou.SPACE;
                }
                //�ԑg�R�[�h.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BANGUMICD].Value;
                //�ԑg�R�[�h�����݂���ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() != "")
                {
                    addRow.hb2Code5 = cellValue.ToString();
                }
                //�ԑg�R�[�h�����݂��Ȃ��ꍇ.
                else
                {
                    addRow.hb2Code5 = KKHSystemConst.Kigou.SPACE;
                }
                //�G���R�[�h.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KYOKUCD].Value;
                //�G���R�[�h�����݂���ꍇ.
                if (KKHUtility.ToString(cellValue).Trim() != "")
                {
                    //�����ݒ�.
                    addRow.hb2Code6 = KKHSystemConst.Kigou.SPACE;
                    
                    //4�񃋁[�v����.
                    for (int j = 4; j > 0; j--)
                    {
                        //�����ݒ�.
                        string zashiCd = cellValue.ToString();
                        
                        //�G���R�[�h������̒��������[�v�񐔈ȏ�̏ꍇ.
                        if (zashiCd.Length >= j)
                        {
                            //�G���R�[�h��擪���炊�����擾.
                            zashiCd = zashiCd.Substring(zashiCd.Length - j, j).Trim();

                            //���l�ϊ����\�̏ꍇ.
                            if (KKHUtility.IsNumeric(zashiCd))
                            {
                                addRow.hb2Code6 = zashiCd;
                                break;
                            }
                        }
                    }
                }
                //�G���R�[�h�����݂��Ȃ��ꍇ.
                else
                {
                    addRow.hb2Code6 =  KKHSystemConst.Kigou.SPACE;
                }
                //�X�y�[�X.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value;
                //�X�y�[�X���V���A�܂��͎G���̏ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.SHINBUN || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.ZASHI)
                {
                    //�����ݒ�.
                    object cellValue2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SPACE].Value;

                    //�X�y�[�X�����݂���ꍇ.
                    if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue2).Trim() != "")
                    {
                        addRow.hb2Name1 = cellValue2.ToString();
                    }
                    //�X�y�[�X�����݂��Ȃ��ꍇ.
                    else
                    {
                        addRow.hb2Name1 =  KKHSystemConst.Kigou.SPACE;
                    }
                }
                //�X�y�[�X���V���A�G���ȊO�̏ꍇ.
                else
                {
                    addRow.hb2Name1 =  KKHSystemConst.Kigou.SPACE;
                }
                //��ږ�.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HIMOKUNM].Value;
                //��ږ������݂���ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name2 = cellValue.ToString();
                }
                //��ږ������݂��Ȃ��ꍇ.
                else
                {
                    addRow.hb2Name2 =  KKHSystemConst.Kigou.SPACE;
                }
                //���㖾��No.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_URIMEINO].Value;
                //���㖾��No�����݂���ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name3 = cellValue.ToString();
                }
                //���㖾��No�����݂��Ȃ��ꍇ.
                else
                {
                    addRow.hb2Name3 =  KKHSystemConst.Kigou.SPACE;
                }
                //�������ԍ�.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEINO].Value;
                //�������ԍ������݂���ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Name4 = cellValue.ToString();
                }
                //�������ԍ������݂��Ȃ��ꍇ.
                else
                {
                    addRow.hb2Name4 =  KKHSystemConst.Kigou.SPACE;
                }
                /*
                 * �f�ړ�.
                 */
                //�}�̃R�[�h���V���A�܂��͎G���̏ꍇ.
                if (baiCd.ToString() == KkhConstAsh.BaitaiCd.SHINBUN || baiCd.ToString() == KkhConstAsh.BaitaiCd.ZASHI)
                {
                    //�����ݒ�.
                    ksaibi = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEISAIDT].Value;

                    //�f�ځE�����������݂���ꍇ.
                    if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(ksaibi) != "")
                    {
                        string _keisaiBi = ksaibi.ToString();
                        _keisaiBi = _keisaiBi.Replace(KKHSystemConst.Date.YEAR, "");
                        _keisaiBi = _keisaiBi.Replace(KKHSystemConst.Date.MONTH, "");
                        _keisaiBi = _keisaiBi.Replace(KKHSystemConst.Date.DAY, "");
                        addRow.hb2Name5 = _keisaiBi;
                    }
                    //�f�ځE�����������݂��Ȃ��ꍇ.
                    else
                    {
                        addRow.hb2Name5 =  KKHSystemConst.Kigou.SPACE;
                    }
                }
                //��������.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value;
                //�}�̃R�[�h��TV�^�C���A���W�I�^�C���A��ʁA���f�B�A�t�B�[�A�u�����h�Ǘ��t�B�[�e���r�l�b�g�X�|�b�g�̏ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.TV_TIME
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.RADIO_TIME
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.KOUTSU
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.MEDIA_FEE
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.BRAND_FEE
                    /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki ADD Start */
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                    /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki ADD End */
                {
                    //�����ݒ�.
                    object cellValue2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HOSOUJIKAN].Value;

                    //�������Ԃ����݂���ꍇ.
                    if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue2).Trim() != "")
                    {
                        addRow.hb2Name6 = cellValue2.ToString();
                    }
                    //�������Ԃ����݂��Ȃ��ꍇ.
                    else
                    {
                        addRow.hb2Name6 =  KKHSystemConst.Kigou.SPACE;
                    }
                }
                //�}�̃R�[�h��TV�^�C���A���W�I�^�C���A��ʁA���f�B�A�t�B�[�A�u�����h�Ǘ��t�B�[�e���r�l�b�g�X�|�b�g�ȊO�̏ꍇ.
                else
                {
                    addRow.hb2Name6 =  KKHSystemConst.Kigou.SPACE;
                }
                //����7.
                addRow.hb2Name7 =  KKHSystemConst.Kigou.SPACE;
                //����.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KENMEI].Value;
                //���������݂���ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    /* 2013/01/17 JSE M.Naito MOD Start */
                    //addRow.hb2Name8 = cellValue.ToString();
                    addRow.hb2Name10 = cellValue.ToString();
                    /* 2013/01/17 JSE M.Naito MOD End */
                }
                //���������݂��Ȃ��ꍇ.
                else
                {
                    /* 2013/01/17 JSE M.Naito MOD Start */
                    //addRow.hb2Name8 = " ";
                    addRow.hb2Name10 = " ";
                    /* 2013/01/17 JSE M.Naito MOD End */
                }
                //�j��.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value;
                //�}�̃R�[�h���e���r�^�C���A���W�I�^�C���A�e���r�l�b�g�X�|�b�g�̏ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.TV_TIME
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.RADIO_TIME
                    /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki ADD Start */
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                    /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki ADD End */
                {
                    //�����ݒ�.
                    object cellValue2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_YOUBI].Value;

                    //�j�������݂���ꍇ.
                    if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue2).Trim() != "")
                    {
                        addRow.hb2Name9 = cellValue2.ToString();
                    }
                    //�j�������݂��Ȃ��ꍇ.
                    else
                    {
                        addRow.hb2Name9 =  KKHSystemConst.Kigou.SPACE;
                    }
                }
                //�}�̃R�[�h���e���r�^�C���A���W�I�^�C���A�e���r�l�b�g�X�|�b�g�ȊO�̏ꍇ.
                else
                {
                    addRow.hb2Name9 =  KKHSystemConst.Kigou.SPACE;
                }
                /* 2013/01/17 JSE M.Naito MOD Start */
                //addRow.hb2Name10 = " ";
                addRow.hb2Name8 =  KKHSystemConst.Kigou.SPACE;
                /* 2013/01/17 JSE M.Naito MOD End */

                //���� 
                //�}�̃R�[�h���V���A�G���̏ꍇ.
                if (baiCd.ToString() != KkhConstAsh.BaitaiCd.SHINBUN && baiCd.ToString() != KkhConstAsh.BaitaiCd.ZASHI)
                {
                    //�����ݒ�.
                    kikan = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KIKAN].Value;

                    //���Ԃ����݂���ꍇ.
                    if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(kikan) != "")
                    {
                        addRow.hb2Name11 = kikan.ToString();

                        //�f�ړ�.
                        string _kikan = kikan.ToString();
                        _kikan = _kikan.Replace(KKHSystemConst.Date.YEAR, "");
                        _kikan = _kikan.Replace(KKHSystemConst.Date.MONTH, "");
                        _kikan = _kikan.Replace(KKHSystemConst.Date.DAY, "");
                        _kikan = _kikan.Replace(KKHSystemConst.Kigou.HYPHEN, "");
                        addRow.hb2Name5 = _kikan;
                    }
                    //���Ԃ����݂��Ȃ��ꍇ.
                    else
                    {
                        addRow.hb2Name11 =  KKHSystemConst.Kigou.SPACE;
                        //[�f�ړ�]���󔒂ɐݒ�.
                        addRow.hb2Name5 =  KKHSystemConst.Kigou.SPACE;
                    }
                }
                addRow.hb2Name12 = "";
                addRow.hb2Name13 = "";
                addRow.hb2Name14 = "";
                addRow.hb2Name15 = "";
                addRow.hb2Name16 = "";
                addRow.hb2Name17 = "";
                addRow.hb2Name18 = "";
                addRow.hb2Name19 = "";
                addRow.hb2Name20 = "";
                addRow.hb2Name21 = "";
                addRow.hb2Name22 = "";
                addRow.hb2Name23 = "";
                addRow.hb2Name24 = "";
                addRow.hb2Name25 = "";
                addRow.hb2Name26 = "";
                addRow.hb2Name27 = "";
                addRow.hb2Name28 = "";
                addRow.hb2Name29 = "";
                addRow.hb2Name30 = "";
                /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga MOD Start */
                //����Ŋz.
                //addRow.hb2Kngk1 = 0M;
                addRow.hb2Kngk1 = (Decimal)_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_ZEIGAKU].Value;
                /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga MOD End */
                addRow.hb2Kngk2 = 0M;
                addRow.hb2Kngk3 = 0M;
                //����ŗ�.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_ZEIRITSU].Value;
                addRow.hb2Ritu1 = KKHUtility.DecParse(cellValue.ToString());
                //���͔䗦.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NYURYOKUHIRITU].Value;
                addRow.hb2Ritu2 = KKHUtility.DecParse(KKHUtility.ToString(cellValue));
                //�b��.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BYOUSU].Value;
                //�b�������݂���ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota1 = cellValue.ToString();
                }
                //�b�������݂��Ȃ��ꍇ.
                else
                {
                    addRow.hb2Sonota1 =  KKHSystemConst.Kigou.SPACE;
                }
                //�{��.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HONSU].Value;
                //�{�������݂���ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota2 = cellValue.ToString();
                }
                //�{�������݂��Ȃ��ꍇ.
                else
                {
                    addRow.hb2Sonota2 =  KKHSystemConst.Kigou.SPACE;
                }
                //���[�敪.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TYOUSEKIKBN].Text;
                //���[�敪�����݂���ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota3 = cellValue.ToString();
                }
                //���[�敪�����݂��Ȃ��ꍇ.
                else
                {
                    addRow.hb2Sonota3 =  KKHSystemConst.Kigou.SPACE;
                }
                addRow.hb2Sonota4 =  KKHSystemConst.Kigou.SPACE;
                //�L�G�敪.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KIZATSUKBN].Value;
                //�L�G�敪�����݂���ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota5 = cellValue.ToString();                   
                }
                //�L�G�敪�����݂��Ȃ��ꍇ.
                else
                {
                    addRow.hb2Sonota5 =  KKHSystemConst.Kigou.SPACE;
                }
                //�f�ڋ敪.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEISAIBAN].Value;
                //�f�ڋ敪�����݂���ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota6 = cellValue.ToString();
                }
                //�f�ڋ敪�����݂��Ȃ��ꍇ.
                else
                {
                    addRow.hb2Sonota6 = " ";
                }
                //�ǁE�l�b�g��.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value;
                //�}�̃R�[�h���e���r�^�C���A���W�I�^�C���A���f�B�A�t�B�[�A�u�����h�t�B�[�A�e���r�l�b�g�X�|�b�g�̏ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.TV_TIME
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.RADIO_TIME
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.MEDIA_FEE
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.BRAND_FEE
                    /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki ADD Start */
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                    /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki ADD End */
                {
                    //�����ݒ�.
                    object cellValue2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KYOKUNETSU].Value;

                    //�ǃl�b�g�����݂���ꍇ.
                    if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue2).Trim() != "")
                    {
                        addRow.hb2Sonota7 = cellValue2.ToString();
                    }
                    //�ǃl�b�g�����݂��Ȃ��ꍇ.
                    else
                    {
                        addRow.hb2Sonota7 =  KKHSystemConst.Kigou.SPACE;
                    }
                }
                //�}�̃R�[�h���e���r�^�C���A���W�I�^�C���A���f�B�A�t�B�[�A�u�����h�t�B�[�A�e���r�l�b�g�X�|�b�g�ȊO�̏ꍇ.
                else
                {
                    addRow.hb2Sonota7 =  KKHSystemConst.Kigou.SPACE;
                }
                //�L�[�ǃR�[�h.
                //�}�̃R�[�h���e���r�^�C���A���W�I�^�C���A�e���r�l�b�g�X�|�b�g�̏ꍇ.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value;
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.TV_TIME
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.RADIO_TIME
                    /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki ADD Start */
                    || Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue).Trim() == KkhConstAsh.BaitaiCd.TV_NETSPOT)
                    /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki ADD End */
                {
                    //�����ݒ�.
                    object cellValue2 = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEYKYOKUCD].Value;

                    //�L�[�ǃR�[�h�����݂���ꍇ.
                    if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue2).Trim() != "")
                    {
                        addRow.hb2Sonota8 = cellValue2.ToString();
                    }
                    //�L�[�ǃR�[�h�����݂��Ȃ��ꍇ.
                    else
                    {
                        addRow.hb2Sonota8 =  KKHSystemConst.Kigou.SPACE;
                    }
                }
                //�}�̃R�[�h���e���r�^�C���A���W�I�^�C���A�e���r�l�b�g�X�|�b�g�ȊO�̏ꍇ.
                else
                {
                    addRow.hb2Sonota8 =  KKHSystemConst.Kigou.SPACE;
                }
                //FD����.
                addRow.hb2Sonota9 =  KKHSystemConst.Kigou.SPACE;
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_FDDETAILOUTPUT].Value;
                //FD���ׂ����݂���ꍇ.
                if (Isid.KKH.Common.KKHUtility.KKHUtility.ToString(cellValue) != "")
                {
                    addRow.hb2Sonota9 = cellValue.ToString();
                }
                //FD���ׂ����݂��Ȃ��ꍇ.
                else
                {
                    addRow.hb2Sonota9 =  KKHSystemConst.Kigou.SPACE;
                }
                //�����t���O.
                cellValue = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAICD].Value;
                addRow.hb2Sonota10 = CnvBaitaiCdToSortNo(cellValue.ToString());
                //���ׂ�2���ȏ㑶�݂���ꍇ.
                if (_spdKkhDetail_Sheet1.RowCount >= 2)
                {
                    addRow.hb2BunFlg = "1";
                }
                //���ׂ�1�������̏ꍇ.
                else
                {
                    addRow.hb2BunFlg =  KKHSystemConst.Kigou.SPACE;
                }
                addRow.hb2MeihnFlg =  KKHSystemConst.Kigou.SPACE;
                addRow.hb2NebhnFlg =  KKHSystemConst.Kigou.SPACE;

                dtThb2Kmei.AddTHB2KMEIRow(addRow);
            }
            dsDetail.THB2KMEI.Merge(dtThb2Kmei);

            /*
             * �X�V���t�ő�l�̔���.
             */
            //��������Ă���ꍇ.
            if (dataRow.hb1TouFlg == "1")
            {
                //��������Ă���󒍓o�^���e�̃f�[�^����X�V���t�̍ő�l���擾����.
                Isid.KKH.Common.KKHUtility.KKHGetMaxUpdDateByTogo getMaxUpdDateByTogo = new KKHGetMaxUpdDateByTogo();
                maxUpdDate = getMaxUpdDateByTogo.GetMaxUpdDateByTogo(_spdJyutyuList_Sheet1, dataRow.hb1TimStmp, _dsDetail);
            }
            //��������Ă��Ȃ��ꍇ.
            else
            {
                //�ő�X�V���������݂��Ȃ��ꍇ.
                if (maxUpdDate == null || maxUpdDate.CompareTo(dataRow.hb1TimStmp) < 0)
                {
                    maxUpdDate = dataRow.hb1TimStmp;
                }
            }

            //���׌��������[�v����.
            foreach (drDetailData detailDataAshRow in _dsDetailAsh.DetailDataAsh.Rows)
            {
                //�ő�X�V���������݂��Ȃ��ꍇ.
                if (maxUpdDate == null || maxUpdDate.CompareTo(detailDataAshRow.hb2TimStmp) < 0)
                {
                    maxUpdDate = detailDataAshRow.hb2TimStmp;
                }
            }

            //�o�^����.
            DetailProcessController processController = DetailProcessController.GetInstance();
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
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0148, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                }
                else
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_E0003, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                }
                return;
            }

            //�L����וύX�t���O���X�V.
            base.kkhDetailUpdFlag = false; 
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                //���דo�^"��"��ݒ�.
                _spdJyutyuList_Sheet1.Cells[_spdJyutyuList_Sheet1.ActiveRowIndex, COLIDX_JLIST_TOROKU].Value = "��";
            }
            else
            {
                //���דo�^"��"������.
                _spdJyutyuList_Sheet1.Cells[_spdJyutyuList_Sheet1.ActiveRowIndex, COLIDX_JLIST_TOROKU].Value = "";
            }

            //�ێ����Ă���󒍓o�^���e�f�[�^��������̃f�[�^�ōX�V����.
            foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow updRow in result.DsDetail.THB1DOWN.Rows)
            {
                _dsDetail.JyutyuData.UpdateRowDataByTGADOWNRow(updRow);
                _dsDetail.THB1DOWN.UpdateRowData(updRow);
            }
            _dsDetail.JyutyuData.AcceptChanges();
            _dsDetail.THB1DOWN.AcceptChanges();
            DisplayKkhDetail(_spdJyutyuList_Sheet1.ActiveRowIndex);

            //�f�[�^�Č���.
            SearchJyutyuData(true);
            if (_spdJyutyuList_Sheet1.RowCount != 0)
            {
                //���̈ʒu�ɖ߂�.
                _spdJyutyuList_Sheet1.SetActiveCell(activeRow, 0, true);
                _spdJyutyuList_Sheet1.AddSelection(activeRow, -1, 1, -1);
                spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);
                //�e�̏������Ă�(�e��LeaveCell�C�x���g���������Ȃ��̂�).
                base.DisplayKkhDetail(activeRow);
                //�q�̏������Ă�(�e�����Ă�ł���Ȃ��̂�).
                DisplayKkhDetail(activeRow);
            }

            //���[�f�B���O�\���I��.
            base.CloseLoadingDialog();
            MessageUtility.ShowMessageBox(MessageCode.HB_I0012, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
        }
        #endregion ���דo�^����.

        #region �}�̃R�[�h����\�[�g�ԍ������肷��.
        /// <summary>
        /// �}�̃R�[�h����\�[�g�ԍ������肷��.
        /// </summary>
        /// <param name="baitaiCd"></param>
        /// <returns></returns>
        private string CnvBaitaiCdToSortNo(string baitaiCd)
        {
            string sortNo = "";
            if (baitaiCd == KkhConstAsh.BaitaiCd.TV_TIME) { sortNo = "01"; }
            // 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki ADD Start.
            // TV_TIME�̎��ɕ\���̂���015�Ƃ���.
            else if (baitaiCd == KkhConstAsh.BaitaiCd.TV_SPOT) { sortNo = "015"; }
            // 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki ADD End.
            else if (baitaiCd == KkhConstAsh.BaitaiCd.TV_SPOT) { sortNo = "02"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.RADIO_TIME) { sortNo = "03"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.RADIO_SPOT) { sortNo = "04"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.SHINBUN) { sortNo = "05"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.ZASHI) { sortNo = "06"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.KOUTSU) { sortNo = "07"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.SEISAKU) { sortNo = "08"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.NEW_MEDIA) { sortNo = "09"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.INTERNET) { sortNo = "10"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.BS) { sortNo = "11"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.CS) { sortNo = "12"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.OKUGAI) { sortNo = "13"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.EVENT) { sortNo = "14"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.TYOUSA) { sortNo = "15"; }
            /* 2013/02/22 hlc PR�}�̒ǉ��Ή� HLC T.Sonobe MOD Start */
            //else if (baitaiCd == KkhConstAsh.BaitaiCd.SONOTA) { sortNo = "16"; }
            //else if (baitaiCd == KkhConstAsh.BaitaiCd.MEDIA_FEE) { sortNo = "17"; }
            //else if (baitaiCd == KkhConstAsh.BaitaiCd.BRAND_FEE) { sortNo = "18"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.PR) { sortNo = "16"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.SONOTA) { sortNo = "17"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.MEDIA_FEE) { sortNo = "18"; }
            else if (baitaiCd == KkhConstAsh.BaitaiCd.BRAND_FEE) { sortNo = "19"; }
            /* 2013/02/22 hlc PR�}�̒ǉ��Ή� HLC T.Sonobe MOD End */
            else { sortNo = "99"; }
            return sortNo;
        }
        #endregion �}�̃R�[�h����\�[�g�ԍ������肷��.

        #region [����]��\���p�̃t�H�[�}�b�g�ɕϊ����܂�.
        /// <summary>
        /// [����]��\���p�̃t�H�[�}�b�g�ɕϊ����܂�.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string FormatPeriod(string str)
        {
            string ret = string.Empty;
            if (str.Length >= 16)
            {
                ret = str.Substring(0, 4) + "�N" + str.Substring(4, 2) + "��" + str.Substring(6, 2) + "��" + " - " + str.Substring(8, 4) + "�N" + str.Substring(12, 2) + "��" + str.Substring(14, 2) + "��";
            }
            else if (str.Length == 8)
            {
                ret = str.Substring(0, 4) + "�N" + str.Substring(4, 2) + "��" + str.Substring(6, 2) + "��";
            }
            else
            {
                return str;
            }

            return ret;
        }
        #endregion [����]��\���p�̃t�H�[�}�b�g�ɕϊ����܂�.

        #region �Ώ۔}�̃R�[�h���菈��.
        /// <summary>
        /// �Ώ۔}�̃R�[�h���菈��.
        /// </summary>
        /// <returns></returns>
        private string GetBaitaiCdByJyutyuData()
        {
            string targetBaitaiCd = string.Empty;

            //�󒍃_�E�����[�h�f�[�^�A�}�X�^�f�[�^����Ώ۔}�̃R�[�h�����肷��.
            drJyutyuData dataRow = getSelectJyutyuData(-1);

            //���}�̃R�[�h�̎擾.
            string kariBaitaiCd = string.Empty;
            if (dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Works)
            {
                kariBaitaiCd = string.Empty;
            }
            else if (dataRow.hb1SeiKbn == KKHSystemConst.SeiKbn.KWorks)
            {
                kariBaitaiCd = dataRow.hb1Field2;
            }
            else
            {
                kariBaitaiCd = dataRow.hb1Field1;
            }

            //�}�̃R�[�h�ϊ��}�X�^�̃��R�[�h���擾.
            MasterMaintenance.MasterDataVODataTable dtBaitaiCnvMaster = FindMasterData(KkhConstAsh.MasterKey.BAITAI_HENNKAN);

            //�}�̃R�[�h�ϊ��}�X�^�̃��R�[�h������.
            foreach (MasterMaintenance.MasterDataVORow row in dtBaitaiCnvMaster.Rows)
            {
                //�}�̂ƍ��ۋ敪�̔���.
                if (dataRow.hb1GyomKbn == row.Column1 && dataRow.hb1KokKbn == row.Column2)
                {
                    //�Ɩ��敪�����W�I�A�q�����f�B�A�̏ꍇ.
                    if (dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.Radio || dataRow.hb1GyomKbn == KKHSystemConst.GyomKbn.EiseiM)
                    {
                        if (dataRow.hb1TmspKbn == row.Column3 || row.Column2 == "1")
                        {
                            if (row.Column4 == "")
                            {
                                targetBaitaiCd = row.Column5;
                            }
                            if (kariBaitaiCd == row.Column4)
                            {
                                targetBaitaiCd = row.Column5;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (row.Column4 == "")
                        {
                            targetBaitaiCd = row.Column5;
                        }
                        if (kariBaitaiCd == row.Column4)
                        {
                            targetBaitaiCd = row.Column5;
                            break;
                        }
                    }
                }
            }

            //�}�̂��ݒ肳��Ȃ������ꍇ.
            if (targetBaitaiCd == "")
            {
                //���̑�.
                targetBaitaiCd = "190";
            }

            return targetBaitaiCd;
        }
        #endregion �Ώ۔}�̃R�[�h���菈��.

        #region �}�X�^�f�[�^�Ǘ�.
        /*
         * �����f�[�^�ێ��pHashtable.
         * �ė��p����f�[�^(�}�X�^�f�[�^��)��ێ�.
        */
        //�}�X�^�f�[�^.
        Hashtable htMasterData = new Hashtable();

        #region �ėp�}�X�^�̌������s��(��x�擾�����f�[�^�͕ێ�����A�����ς݂̃}�X�^�f�[�^�͕ێ������f�[�^��ԋp����.).
        /// <summary>
        /// �ėp�}�X�^�̌������s��.
        /// ��x�擾�����f�[�^�͕ێ�����A�����ς݂̃}�X�^�f�[�^�͕ێ������f�[�^��ԋp����.
        /// </summary>
        /// <param name="masterKey">�擾����}�X�^�̃}�X�^�L�[</param>
        /// <returns></returns>
        private Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable FindMasterData(string masterKey)
        {
            return FindMasterData(masterKey, false);
        }
        #endregion �ėp�}�X�^�̌������s��.

        #region �ėp�}�X�^�̌������s��.
        /// <summary>
        /// �ėp�}�X�^�̌������s��.
        /// </summary>
        /// <param name="masterKey">�擾����}�X�^�̃}�X�^�L�[</param>
        /// <param name="reLoad">True:���DB�������s���AFalse:�����ς݂̃}�X�^�͕ێ����Ă���f�[�^���g�p����</param>
        /// <returns></returns>
        private Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable FindMasterData(string masterKey, bool reLoad)
        {
            Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable rv;

            if (htMasterData[masterKey] == null || reLoad == true)
            {

                MasterMaintenanceProcessController proccessController = MasterMaintenanceProcessController.GetInstance();
                FindMasterMaintenanceByCondServiceResult result = proccessController.FindMasterByCond(
                                                                        _naviParameter.strEsqId
                                                                        , _naviParameter.strEgcd
                                                                        , _naviParameter.strTksKgyCd
                                                                        , _naviParameter.strTksBmnSeqNo
                                                                        , _naviParameter.strTksTntSeqNo
                                                                        , masterKey
                                                                        , ""
                                                                    );
                rv = result.MasterDataSet.MasterDataVO;
                htMasterData[masterKey] = result.MasterDataSet.MasterDataVO;
            }
            else
            {
                rv = (Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVODataTable)htMasterData[masterKey];
            }

            return rv;
        }
        #endregion �ėp�}�X�^�̌������s��.
        #endregion �}�X�^�f�[�^�Ǘ�.

        /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD Start */
        #region ���דo�^�m�F����.
        /// <summary>
        /// ���דo�^�m�F����.
        /// </summary>
        /// <returns></returns>
        private bool RegistSagakuCheck()
        {
            //�����ݒ�.
            decimal delSagaku = 0M;
            decimal delZeiSagaku = 0M;
            Boolean flg = false;

            //��ʂŕ\������Ă������ō��z��[0]�ȊO�̏ꍇ.
            if (!decimal.TryParse(lblZeiSagakuValue.Text, out delZeiSagaku) || delZeiSagaku != 0M)
            {
                //�m�F���b�Z�[�W��[�͂�]��I�������ꍇ.
                if (DialogResult.Yes == MessageUtility.ShowMessageBox(MessageCode.HB_W0166, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.YesNo))
                {
                    flg = true;
                }
                //�m�F���b�Z�[�W��[������]��I�������ꍇ.
                else
                {
                    return flg;
                }
            }

            //��ʂŕ\������Ă��鍷�z��[0]�ȊO�̏ꍇ.
            if (!decimal.TryParse(lblSagakuValue.Text, out delSagaku) || delSagaku != 0M)
            {
                //�m�F���b�Z�[�W��[�͂�]��I�������ꍇ.
                if (DialogResult.Yes == MessageUtility.ShowMessageBox(MessageCode.HB_W0089, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.YesNo))
                {
                    flg = true;
                }
                //�m�F���b�Z�[�W��[������]��I�������ꍇ.
                else
                {
                    return flg = false;
                }
            }

            //��ʂŕ\������Ă������ō��z�A���z��[0]�̏ꍇ.
            if (!decimal.TryParse(lblSagakuValue.Text, out delSagaku) || (delZeiSagaku == 0M && delSagaku == 0M))
            {
                //��ʂŕ\������Ă��鍷�z��[0]�̏ꍇ.
                if (DialogResult.Yes == MessageUtility.ShowMessageBox(MessageCode.HB_C0002, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.YesNo))
                {
                    flg = true;
                }
            }

            return flg;
        }
        #endregion ���דo�^�m�F����.
        /* 2016/11/18 �A�T�q����őΉ� HLC K.Soga ADD End */
        #endregion ���\�b�h.
    }
}