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
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHProcessController.MasterMaintenance;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Detail;
using Isid.KKH.Tkd.Schema;
using Isid.KKH.Tkd.ProcessController.Detail;
using Isid.KKH.Tkd.Utility;
using System.Text.RegularExpressions;
using System.Collections;

namespace Isid.KKH.Tkd.View.Detail
{
    /// <summary>
    /// �L����ד��͉�ʁi���c��i�j 
    /// </summary>
    public partial class DetailTkd : DetailForm
    {
        #region �萔

        /// <summary>
        /// �A�v��ID
        /// </summary>
        private const String APLID = "DtlTkd";

        /// <summary>
        /// �N����C���f�b�N�X 
        /// </summary>
        private const int COLIDX_MLIST_NENGETSU = 0;
        /// <summary>
        /// �����ޗ�C���f�b�N�X 
        /// </summary>
        private const int COLIDX_MLIST_TYUBUNRUI = 1;
        /// <summary>
        /// �}�̖���C���f�b�N�X 
        /// </summary>
        private const int COLIDX_MLIST_BAITAINM = 2;
        /// <summary>
        /// ���{No��C���f�b�N�X 
        /// </summary>
        private const int COLIDX_MLIST_JISHINO = 3;
        /// <summary>
        /// �z������C���f�b�N�X 
        /// </summary>
        private const int COLIDX_MLIST_HAIBUNRITSU = 4;
        /// <summary>
        /// ���z��C���f�b�N�X 
        /// </summary>
        private const int COLIDX_MLIST_KINGAKU = 5;
        /// <summary>
        /// ���i����C���f�b�N�X 
        /// </summary>
        private const int COLIDX_MLIST_SHOHINNM = 6;
        /// <summary>
        /// �Ǘ��敪��C���f�b�N�X 
        /// </summary>
        private const int COLIDX_MLIST_KANRIKBN = 7;
        /// <summary>
        /// �x�����T�C�g��C���f�b�N�X 
        /// </summary>
        private const int COLIDX_MLIST_SHIHARAISITE = 8;
        /// <summary>
        /// �E�v��C���f�b�N�X 
        /// </summary>
        private const int COLIDX_MLIST_TEKIYOU = 9;
        /// <summary>
        /// �X�e�[�^�X��C���f�b�N�X 
        /// </summary>
        private const int COLIDX_MLIST_STATUS = 10;
        /// <summary>
        /// �敪��C���f�b�N�X 
        /// </summary>
        private const int COLIDX_MLIST_KBN = 11;
        /// <summary>
        /// �l������C���f�b�N�X 
        /// </summary>
        private const int COLIDX_MLIST_NRITU = 12;
        /// <summary>
        /// �l���z��C���f�b�N�X 
        /// </summary>
        private const int COLIDX_MLIST_NGAK = 13;
        /// <summary>
        /// �l����z��C���f�b�N�X 
        /// </summary>
        private const int COLIDX_MLIST_NKGAK = 14;

        /// <summary>
        /// �}�̃}�X�^�擾�L�[�F0001 
        /// </summary>
        private const string MST_BAITAI = "0001";
        /// <summary>
        /// ���i�}�X�^�擾�L�[�F0002 
        /// </summary>
        private const string MST_SHOHIN = "0002";
        /// <summary>
        /// �����ރ}�X�^�擾�L�[�F0004 
        /// </summary>
        private const string MST_TYUBUNRUI = "0004";
        /// <summary>
        /// �����ޕR�t���}�X�^�擾�L�[�F0005 
        /// </summary>
        private const string MST_TYUBUNRUI_HIMOZUKE = "0005";

        /// <summary>
        /// �Ǘ��敪�R���{�{�b�N�X�̍��ځi�R�[�h�j1�F���� 
        /// </summary>
        private const int COMBO_CODE_KBN_GEN = 1;
        /// <summary>
        /// �Ǘ��敪�R���{�{�b�N�X�̍��ځi�R�[�h�j2�F�t�B�[ 
        /// </summary>
        private const int COMBO_CODE_KBN_FEE = 2;
        /// <summary>
        /// �Ǘ��敪�R���{�{�b�N�X�̍��ځi���́j1�F���� 
        /// </summary>
        private const string COMBO_NAME_KBN_GEN = "����";
        /// <summary>
        /// �Ǘ��敪�R���{�{�b�N�X�̍��ځi���́j2�F�t�B�[ 
        /// </summary>
        private const string COMBO_NAME_KBN_FEE = "�t�B�[";
        /// <summary>
        /// �Ǘ��敪�R���{�{�b�N�X�̍��ځi�C���f�b�N�X�j0�F���� 
        /// </summary>
        private const int COMBO_IDX_KBN_GEN = 0;
        /// <summary>
        /// �Ǘ��敪�R���{�{�b�N�X�̍��ځi�C���f�b�N�X�j1�F�t�B�[ 
        /// </summary>
        private const int COMBO_IDX_KBN_FEE = 1;

        /// <summary>
        /// �X�e�[�^�X�R���{�{�b�N�X�̍��ځi�R�[�h�j1�FSP 
        /// </summary>
        private const int COMBO_CODE_STS_SP = 1;
        /// <summary>
        /// �X�e�[�^�X�R���{�{�b�N�X�̍��ځi�R�[�h�j2�FMASS 
        /// </summary>
        private const int COMBO_CODE_STS_MASS = 2;
        /// <summary>
        /// �X�e�[�^�X�R���{�{�b�N�X�̍��ځi���́j1�FSP 
        /// </summary>
        private const string COMBO_NAME_STS_SP = "SP";
        /// <summary>
        /// �X�e�[�^�X�R���{�{�b�N�X�̍��ځi���́j2�FMASS 
        /// </summary>
        private const string COMBO_NAME_STS_MASS = "MASS";
        /// <summary>
        /// �X�e�[�^�X�R���{�{�b�N�X�̍��ځi�C���f�b�N�X�j0�FSP 
        /// </summary>
        private const int COMBO_IDX_STS_SP = 0;
        /// <summary>
        /// �X�e�[�^�X�R���{�{�b�N�X�̍��ځi�C���f�b�N�X�j1�FMASS 
        /// </summary>
        private const int COMBO_IDX_STS_MASS = 1;

        /// <summary>
        /// ���׃X�v���b�h�Q���{No�̍ő�l 
        /// </summary>
        private const double MAX_VALUE_JISHINO = 999D;
        /// <summary>
        /// ���׃X�v���b�h�Q���{No�̍ŏ��l 
        /// </summary>
        private const double MIN_VALUE_JISHINO = 0D;
        /// <summary>
        /// ���׃X�v���b�h�Q���{No�̃f�t�H���g�l 
        /// </summary>
        private const string DEF_VALUE_JISHINO = "0";

        /// <summary>
        /// ���׃X�v���b�h�Q�z�����̍ő�l 
        /// </summary>
        private const double MAX_VALUE_HAIBUNRITSU = 999.99D;
        /// <summary>
        /// ���׃X�v���b�h�Q�z�����̍ŏ��l 
        /// </summary>
        private const double MIN_VALUE_HAIBUNRITSU = -999.99D;
        /// <summary>
        /// ���׃X�v���b�h�Q�z�����̃f�t�H���g�l 
        /// </summary>
        private const string DEF_VALUE_HAIBUNRITSU = "0.00";

        /// <summary>
        /// ���׃X�v���b�h�Q���z�̍ő�l 
        /// </summary>
        private const double MAX_VALUE_KINGAKU = 99999999999D;
        /// <summary>
        /// ���׃X�v���b�h�Q���z�̍ŏ��l 
        /// </summary>
        private const double MIN_VALUE_KINGAKU = -99999999999D;
        /// <summary>
        /// ���׃X�v���b�h�Q���z�̃f�t�H���g�l 
        /// </summary>
        private const string DEF_VALUE_KINGAKU = "0";

        /// <summary>
        /// ���׃X�v���b�h�Q�x�����T�C�g�̃f�t�H���g�l 
        /// </summary>
        private const string DEF_VALUE_SHIHARAISITE = "120";

        /// <summary>
        /// �c�Ə��R�[�h�F�֐� 
        /// </summary>
        private const string EGYSHOCD_20 = "20";

        /// <summary>
        /// �������[�h�񋓑� 
        /// </summary>
        private enum Mode
        {
            /// <summary>
            /// ���ד���:0 
            /// </summary>
            DetailInput = 0,
            /// <summary>
            /// ����:1 
            /// </summary>
            Divide = 1,
        }

        #endregion �萔

        #region �����o�ϐ�

        /// <summary>
        /// Rg�i�r�p�����[�^ 
        /// </summary>
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();

        /// <summary>
        /// �����ރ}�X�^���i�L�[�j 
        /// </summary>
        private string[] _itemTyubunruiCd = null;

        /// <summary>
        /// �����ރ}�X�^���i���́j 
        /// </summary>
        private string[] _itemTyubunruiNm = null;

        /// <summary>
        /// �}�̃}�X�^���(�S�f�[�^) 
        /// �������ރ}�X�^�̃R�[�h�P�ʂŊi�[ 
        /// </summary>  
        private Dictionary<string, Dictionary<string[], string[]>> _dictBaitai = null;

        /// <summary>
        /// �}�̃}�X�^���i�L�[�j 
        /// </summary>
        private string[] _itemBaitaiCd = null;

        /// <summary>
        /// �}�̃}�X�^���i���́j 
        /// </summary>
        private string[] _itemBaitaiNm = null;

        /// <summary>
        /// ���i�����i�L�[�j 
        /// </summary>
        private string[] _itemShohinCd = null;

        /// <summary>
        /// ���i�����i���́j 
        /// </summary>
        private string[] _itemShohinNm = null;

        /// <summary>
        /// �����ރ}�X�^���f�[�^�Z�b�g 
        /// </summary>
        private MasterMaintenance _dsTyubunrui = null;

        /// <summary>
        /// �����ޕR�t���}�X�^���f�[�^�Z�b�g 
        /// </summary>
        private MasterMaintenance _dsTyubunruiHimo = null;

        /// <summary>
        /// �����G���R�[�f�B���O 
        /// </summary>
        private Encoding _enc = Encoding.GetEncoding("shift-jis");

        /// <summary>
        /// �f�[�^���f�� 
        /// </summary>
        private DefaultSheetDataModel _dataModel;

        /// <summary>
        /// �I��� 
        /// </summary>
        private int _col = 0;

        /// <summary>
        /// �I���s 
        /// </summary>
        private int _row = 0;

        /// <summary>
        /// ���{No
        /// </summary>
        private int jissiNoCnt = 0;

        #endregion �����o�ϐ�

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        public DetailTkd()
        {
            InitializeComponent();
            _dataModel = (DefaultSheetDataModel)_spdKkhDetail_Sheet1.Models.Data;
        }

        #endregion �R���X�g���N�^

        #region �I�[�o�[���C�h

        /// <summary>
        /// �X�v���b�h�S�̂ɑ΂��鏉���\���̐ݒ���s�� 
        /// </summary>
        protected override void InitDesignForSpdJyutyuListSpread()
        {
            base.InitDesignForSpdJyutyuListSpread();
        }

        /// <summary>
        /// �X�v���b�h�̗�ɑ΂��鏉���\���̐ݒ���s�� 
        /// </summary>
        /// <param name="col"></param>
        protected override void InitDesignForSpdJyutyuListColumns(Column col)
        {
            base.InitDesignForSpdJyutyuListColumns(col);

            // ����ŗ��̏ꍇ 
            if (col.Index == COLIDX_JLIST_ZEIRITSU)
            {
                NumberCellType cellType = (NumberCellType)col.CellType;
                cellType.DecimalPlaces = 2;
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
                if (col.Index == COLIDX_JLIST_BAITAINM) { col.Visible = false; }                //�}�̖�(��\��) 
                if (col.Index == COLIDX_JLIST_HIMOKUNM) { col.Visible = true; }                 //��ږ� 
                if (col.Index == COLIDX_JLIST_KYOKUSHICD) { col.Visible = false; }              //�ǎ�CD(��\��) 
                if (col.Index == COLIDX_JLIST_SEIKINGAKU) { col.Visible = true; }               //�������z 
                if (col.Index == COLIDX_JLIST_KIKAN) { col.Visible = false; }                   //����(��\��) 
                if (col.Index == COLIDX_JLIST_DANTANKA) { col.Visible = false; }                //�i�P��(��\��) 
                if (col.Index == COLIDX_JLIST_DANSU) { col.Visible = false; }                   //�i��(��\��) 
                if (col.Index == COLIDX_JLIST_TORIRYOKIN) { col.Visible = true; }               //�旿�� 
                if (col.Index == COLIDX_JLIST_NEBIKIRITSU) { col.Visible = true; }              //�l���� 
                if (col.Index == COLIDX_JLIST_NEBIKIGAKU) { col.Visible = true; }               //�l���z 
                if (col.Index == COLIDX_JLIST_ZEIRITSU) { col.Visible = true; }                 //����ŗ� 
                if (col.Index == COLIDX_JLIST_ZEIGAKU) { col.Visible = true; }                  //����Ŋz 
                if (col.Index == COLIDX_JLIST_GOUKEIKINGAKU) { col.Visible = false; }           //�󒍐������z(��\��) 
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
            _dsDetailTkd.KkhDetail.Clear();

            int rowCnt = 0;
            foreach (Common.KKHSchema.Detail.THB2KMEIRow row in _dsDetail.THB2KMEI.Rows)
            {
                rowCnt = _dsDetailTkd.KkhDetail.Rows.Count;

                DetailDSTkd.KkhDetailRow addrow = _dsDetailTkd.KkhDetail.NewKkhDetailRow();

                addrow.nengetsu = row.hb2Date1;         // �N�� 
                addrow.chubunrui = row.hb2Code5;        // ������ 

                // �}�̖� 
                if (!string.IsNullOrEmpty(row.hb2Code5))
                {
                    addrow.baitaiNm = row.hb2Code2;
                }
                else
                {
                    addrow.baitaiNm = string.Empty;
                }

                addrow.jishiNo = row.hb2Kngk1;          // ���{NO 
                addrow.haibunRitsu = row.hb2Ritu1;      // �z���� 
                addrow.kingaku = row.hb2SeiGak;         // ���z 
                addrow.shohinNm = row.hb2Code3;         // ���i�� 

                // �Ǘ��敪 
                if (!string.IsNullOrEmpty(row.hb2Kbn2))
                {
                    addrow.kanriKbn = row.hb2Kbn2;
                }
                else
                {
                    addrow.kanriKbn = COMBO_CODE_KBN_GEN.ToString();
                }

                addrow.shiharaiSite = row.hb2Code4;     // �x�����T�C�g 
                addrow.tekiyou = row.hb2Name8;          // �E�v 
                addrow.status = row.hb2Kbn1;            // �X�e�[�^�X 
                addrow.kbn = row.hb2Sonota1;            // �敪 
                addrow.nritu = row.hb2Hnnert;           // �l���� 
                addrow.ngak = row.hb2NebiGak;           // �l���z 
                addrow.nkgak = row.hb2HnmaeGak;         // �l����z 

                _dsDetailTkd.KkhDetail.AddKkhDetailRow(addrow);
            }

            _dsDetailTkd.KkhDetail.AcceptChanges();

            // �󒍓o�^���e�̑I���s���̎擾 
            SheetView activeSheet = GetActiveSheetViewBySpdJyutyuList();
            Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(rowIdx);

            //***************************************
            // �{�^���ނ̎g�p�E�s�ݒ� 
            //***************************************
            SetButtonEnable();

            //******************************
            // ���z�E�v���x�� 
            //******************************
            // ���z�v�Z 
            CalculateSagaku(dataRow);

            //SetDetailDataBaitai���\�b�h�����s���邽�߂ɁA�t�H�[�J�X���ړ����Ă���
            //(���S�ɂ͂�������@������΂����) 
            _spdKkhDetail_Sheet1.SetActiveCell(-1,-1);

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
            InitializeButtonEnable();
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
        /// �󒍍폜�������s�O�`�F�b�N 
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
                InitializeButtonEnable();

                //���z�E�v 
                lblSagakuValue.Text = "0";
                lblGoukeiValue.Text = "0";
            }
        }

        /// <summary>
        /// �N���ύX�������s�O�`�F�b�N 
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
                //�󒍓o�^���e������̏�Ԃɂ��� 
                SetButtonEnable();
            }
            else
            {
                //�q�r���[�Ƀt�H�[�J�X������ꍇ�̓f�[�^������s���{�^���͎g�p�����Ȃ� 
                InitializeButtonEnable();
            }
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
            KKHLogUtilityTkd.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityTkd.KINO_ID_OPERATION_LOG_UPDCHECK, KKHLogUtilityTkd.DESC_OPERATION_LOG_UPDCHECK);

            return true;
        }

        #endregion �I�[�o�[���C�h

        #region �C�x���g

        /// <summary>
        /// ��ʑJ�ڂ��邽�тɔ������܂��B 
        /// </summary>
        /// <param name="sender">�J�ڌ��t�H�[��</param>
        /// <param name="arg">�C�x���g�f�[�^</param>
        private void DetailTkd_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }

            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParameter = (KKHNaviParameter)arg.NaviParameter;
            }

            //�I����Ԃ����� 
            this.ActiveControl = null;

        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailTkd_Load(object sender, EventArgs e)
        {
            InitializeControl();
        }

        /// <summary>
        /// �t�H�[��Shown�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailTkd_Shown(object sender, EventArgs e)
        {
            InitializeDesignForSpdKkhDetail();
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

            // ���ׂɃf�[�^���Z�b�g���� 
            SetDetailData(dataRow, _spdKkhDetail_Sheet1.ActiveRowIndex, Mode.DetailInput);

            // �L����וύX�t���O���X�V 
            base.kkhDetailUpdFlag = true;

            //******************************
            // ���z�E�v���x�� 
            //******************************
            // ���z�v�Z 
            CalculateSagaku(dataRow);

            //***************************************
            // �{�^���ނ̎g�p�E�s�ݒ� 
            //***************************************
            SetButtonEnable();
        }

        /// <summary>
        /// �����{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDivide_Click(object sender, EventArgs e)
        {
            // �Ώۂ̎󒍃f�[�^�A���׃f�[�^�擾 
            Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);

            // ���ׂɃf�[�^���Z�b�g���� 
            SetDetailData(dataRow, _spdKkhDetail_Sheet1.RowCount, Mode.Divide);

            // �L����וύX�t���O���X�V 
            base.kkhDetailUpdFlag = true;

            //******************************
            // ���z�E�v���x�� 
            //******************************
            // ���z�v�Z 
            CalculateSagaku(dataRow);

            //�I����Ԃ����� 
            this.ActiveControl = null;

        }

        /// <summary>
        /// ���׍폜�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailDel_Click(object sender, EventArgs e)
        {
            // �I���s�̎擾 
            CellRange[] cellRanges = _spdKkhDetail_Sheet1.GetSelections();

            if (cellRanges.Length == 0)
            {
                // ����(�ꗗ)����擪�s���폜����
                _spdKkhDetail_Sheet1.RemoveRows(0, 1);
            }
            else
            {
                int delCnt = 0;
                // �폜�����s�𖾍�(�ꗗ)����폜 
                foreach (CellRange cellRange in cellRanges)
                {
                    //�I������Ă��閾�ד��e�̍s�����̏������J��Ԃ� 
                    _spdKkhDetail_Sheet1.RemoveRows(cellRange.Row - delCnt, cellRange.RowCount);
                    delCnt = delCnt + cellRange.RowCount;
                }
            }

            //***************************************
            // �{�^���ނ̎g�p�E�s�ݒ� 
            //***************************************
            SetButtonEnable();

            // �Ώۂ̎󒍃f�[�^�A���׃f�[�^�擾 
            Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);

            //******************************
            // ���z�E�v���x�� 
            //******************************
            // ���z�v�Z 
            CalculateSagaku(dataRow);

            // �L����וύX�t���O���X�V 
            base.kkhDetailUpdFlag = true;

            //�I����Ԃ����� 
            this.ActiveControl = null;

        }

        /// <summary>
        /// ���דo�^�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailRegister_Click(object sender, EventArgs e)
        {
            // �`�F�b�N���� 
            if (!CheckDetailData())
            {
                //�I����Ԃ����� 
                this.ActiveControl = null;

                return;
            }

            decimal sagaku = 0M;

            if (decimal.TryParse(lblSagakuValue.Text, out sagaku) == false || sagaku == 0M)
            {
                if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_C0002, null, 
                    "���דo�^", MessageBoxButtons.YesNo))
                {
                    //�I����Ԃ����� 
                    this.ActiveControl = null;

                    return;
                }
            }
            else
            {
                if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_W0089, null, 
                    "���דo�^", MessageBoxButtons.YesNo))
                {
                    //�I����Ԃ����� 
                    this.ActiveControl = null;

                    return;
                }
            }

            //�o�^�ς݂��T�[�o�[�Ń`�F�b�N 
            if (!CheckJissiNoComp())
            {
                if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_W0041, null, 
                    "���דo�^", MessageBoxButtons.YesNo))
                {
                    //�I����Ԃ����� 
                    this.ActiveControl = null;

                    return;
                }
            }

            // ���דo�^���� 
            RegistDetailData();


            //�I����Ԃ����� 
            this.ActiveControl = null;

        }

        /// <summary>
        /// ���{NO�����t�^�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoNo_Click(object sender, EventArgs e)
        {
            // �����������ݒ肳��Ă���ꍇ�͏������I������ 
            if (!string.IsNullOrEmpty(FindJyutyuDataCond.gyomKbn) ||
                !string.IsNullOrEmpty(FindJyutyuDataCond.jyutNo) ||
                !string.IsNullOrEmpty(FindJyutyuDataCond.kokKbn) ||
                !string.IsNullOrEmpty(FindJyutyuDataCond.tmspKbn))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0046,
                                null,
                                "�G���[",
                                MessageBoxButtons.OK);

                //�I����Ԃ����� 
                this.ActiveControl = null;

                return;
            }

            //�ҏW���̏ꍇ 
            if (base.kkhDetailUpdFlag == true)
            {
                DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0087,
                                    null,
                                    "�G���[",
                                    MessageBoxButtons.YesNo);
                //�t�^���L�����Z��
                if (check == DialogResult.No)
                {
                    //�I����Ԃ����� 
                    this.ActiveControl = null;

                    return;
                }
            }

            //�m�F���b�Z�[�W 
            if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_C0024, null,
            "���{No�t�^", MessageBoxButtons.YesNo))
            {
                //�I����Ԃ����� 
                this.ActiveControl = null;

                return;
            }

            base.ShowLoadingDialog();

            //THB2KMEI�̎擾 
            KKH.Common.KKHSchema.Detail jyuListdt = new Common.KKHSchema.Detail();
            DetailTkdProcessController processController = DetailTkdProcessController.GetInstance();

            //�N���G�[�e�B�u�ȊO 
            FindJyutyuDataByCondServiceResult resultThb2 = processController.FindThb2Kmei(
                                                                                      _naviParameter.strEsqId,
                                                                                      "00",
                                                                                      _naviParameter.strEgcd,
                                                                                      _naviParameter.strTksKgyCd,
                                                                                      _naviParameter.strTksBmnSeqNo,
                                                                                      _naviParameter.strTksTntSeqNo,
                                                                                      _naviParameter.StrYymm,
                                                                                      "0");
            //FindJyutyuDataByCondServiceResult resultThb2 = processController.FindThb2Kmei(
                                                                                      //_naviParameter.strEsqId,
                                                                                      //"00",
                                                                                      //_naviParameter.strEgcd,
                                                                                      //_naviParameter.strTksKgyCd,
                                                                                      //_naviParameter.strTksBmnSeqNo,
                                                                                      //_naviParameter.strTksTntSeqNo,
                                                                                      //_naviParameter.StrYymm);


            if (resultThb2.HasError)
            {
                base.CloseLoadingDialog();

                DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_E0025,
                                   null,
                                   "�G���[",
                                   MessageBoxButtons.OK);

                //�I����Ԃ����� 
                this.ActiveControl = null;

                return;
            }


            //���{No�������� 
            jissiNoCnt = 0;

            //�Ɩ��敪���N���G�[�e�B�u�ȊO�̌�����0���ȏ�̏ꍇ 
            if (resultThb2.DetailDataSet.THB2KMEI.Rows.Count > 0)
            {
                jyuListdt.Clear();
                jyuListdt.THB2KMEI.Merge(resultThb2.DetailDataSet.THB2KMEI);
                jyuListdt.THB2KMEI.AcceptChanges();

                //�z�����`�F�b�N 
                string urimeino = "";
                string kenNm = "";
                string msgCd = "";
                if (HaibunCheck(jyuListdt, out urimeino, out kenNm, out msgCd))
                //if (HaibunCheck(jyuListdt, out urimeino) == true)
                {
                    base.CloseLoadingDialog();

                    DialogResult check = MessageUtility.ShowMessageBox(msgCd,
                                       new string[] { urimeino, kenNm },
                                       "�G���[",
                                       MessageBoxButtons.OK);
                    //DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0073,
                    //                   new string[] { urimeino },
                    //                   "�G���[",
                    //                   MessageBoxButtons.OK);
                    //�I����Ԃ����� 
                    this.ActiveControl = null;

                    return;
                }

                //[�Ǘ��敪]�`�F�b�N 
                if (ChkKnrKbn(jyuListdt))
                {

                    DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0138,
                                        null,
                                       "���[�j���O",
                                       MessageBoxButtons.YesNo);
                    //No�̏ꍇ 
                    if (check.Equals(DialogResult.No))
                    {
                        base.CloseLoadingDialog();

                        //�I����Ԃ����� 
                        this.ActiveControl = null;

                        return;
                    }
                }

                //���{No�t�^ 
                SetJissiNo(jyuListdt, false);
            }

            //THB2KMEI�̎擾 
            KKH.Common.KKHSchema.Detail jyuListdtCreative = new Common.KKHSchema.Detail();
            //�N���G�[�e�B�u 
            FindJyutyuDataByCondServiceResult resultThb2Creative = processController.FindThb2Kmei(
                                                                                      _naviParameter.strEsqId,
                                                                                      "00",
                                                                                      _naviParameter.strEgcd,
                                                                                      _naviParameter.strTksKgyCd,
                                                                                      _naviParameter.strTksBmnSeqNo,
                                                                                      _naviParameter.strTksTntSeqNo,
                                                                                      _naviParameter.StrYymm,
                                                                                      "1");

            if (resultThb2Creative.HasError)
            {
                base.CloseLoadingDialog();

                DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_E0025,
                                   null,
                                   "�G���[",
                                   MessageBoxButtons.OK);

                //�I����Ԃ����� 
                this.ActiveControl = null;

                return;

            }

            //�Ɩ��敪���N���G�[�e�B�u�ȊO�̌�����0���ȏ�̏ꍇ 
            if (resultThb2Creative.DetailDataSet.THB2KMEI.Rows.Count > 0)
            {

                jyuListdtCreative.Clear();
                jyuListdtCreative.THB2KMEI.Merge(resultThb2Creative.DetailDataSet.THB2KMEI);
                jyuListdtCreative.THB2KMEI.AcceptChanges();

                //�z�����`�F�b�N 
                string urimeino = "";
                string kenNm = "";
                string msgCd = "";
                if (HaibunCheck(jyuListdtCreative, out urimeino, out kenNm, out msgCd))
                {
                    base.CloseLoadingDialog();

                    DialogResult check = MessageUtility.ShowMessageBox(msgCd,
                                       new string[] { urimeino, kenNm },
                                       "�G���[",
                                       MessageBoxButtons.OK);
                    //�I����Ԃ����� 
                    this.ActiveControl = null;

                    return;
                }

                //[�Ǘ��敪]�`�F�b�N 
                if (ChkKnrKbn(jyuListdtCreative))
                {
                    DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0138,
                                        null,
                                       "���[�j���O",
                                       MessageBoxButtons.YesNo);
                    //No�̏ꍇ 
                    if (check.Equals(DialogResult.No))
                    {
                        base.CloseLoadingDialog();

                        //�I����Ԃ����� 
                        this.ActiveControl = null;

                        return;
                    }
                }

                //���{No��t�^(�N���G�[�e�B�u) 
                SetJissiNo(jyuListdtCreative, true);
            }

            // �I�y���[�V�������O�̏o�� 
            KKHLogUtilityTkd.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityTkd.KINO_ID_OPERATION_LOG_AUTONO, KKHLogUtilityTkd.DESC_OPERATION_LOG_AUTONO);

            //���ҏW�ɐݒ�
            base.kkhDetailUpdFlag = false;

            //���݈ʒu�̎擾 
            int _spdJyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            //�e�̎󒍃f�[�^�擾���� 
            base.SearchJyutyuData();

            //���̈ʒu�ɖ߂� 
            _spdJyutyuList_Sheet1.SetActiveCell(_spdJyutyuListRowIdx, 0, true);
            _spdJyutyuList_Sheet1.AddSelection(_spdJyutyuListRowIdx, -1, 1, -1);
            spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

            //�e�̏������Ă�(�e��LeaveCell�C�x���g���������Ȃ��̂�) 
            base.DisplayKkhDetail(_spdJyutyuListRowIdx);
            //�q�̏������Ă�(�e�����Ă�ł���Ȃ��̂�) 
            DisplayKkhDetail(_spdJyutyuListRowIdx);

            //�󒍓��e����
            //base.SearchJyutyuData();
            DisplayKkhDetail(_spdJyutyuList_Sheet1.ActiveRowIndex);

            base.CloseLoadingDialog();

            MessageUtility.ShowMessageBox(MessageCode.HB_I0004, null, "����", MessageBoxButtons.OK);

            //�I����Ԃ����� 
            this.ActiveControl = null;

        }

        /// <summary>
        /// ���{NO����UP/DOWN�N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoUpDown_Click(object sender, EventArgs e)
        {
            // �����������ݒ肳��Ă���ꍇ�͏������I������ 
            if (!string.IsNullOrEmpty(FindJyutyuDataCond.gyomKbn) ||
                !string.IsNullOrEmpty(FindJyutyuDataCond.jyutNo) ||
                !string.IsNullOrEmpty(FindJyutyuDataCond.kokKbn) ||
                !string.IsNullOrEmpty(FindJyutyuDataCond.tmspKbn))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0046,
                                null,
                                "�G���[",
                                MessageBoxButtons.OK);
                //�I����Ԃ����� 
                this.ActiveControl = null;

                return;
            }

            if (base.kkhDetailUpdFlag == true)
            {
                //�ҏW���̏ꍇ 
                DialogResult check = MessageUtility.ShowMessageBox(MessageCode.HB_W0134,
                                    null,
                                    "�G���[",
                                    MessageBoxButtons.YesNo);

                if (check == DialogResult.No)
                {
                    //�I����Ԃ����� 
                    this.ActiveControl = null;

                    //�t�^���L�����Z�� 
                    return;
                }
            }

            //DatailAutoUpDown�� 
            DatailAutoUpDownNaviParameter naviParam = new DatailAutoUpDownNaviParameter();
            naviParam.strEsqId = _naviParameter.strEsqId;
            naviParam.strEgcd = _naviParameter.strEgcd;
            naviParam.strTksKgyCd = _naviParameter.strTksKgyCd;
            naviParam.strTksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            naviParam.strTksTntSeqNo = _naviParameter.strTksTntSeqNo;
            naviParam.StrYymm = _naviParameter.StrYymm;
            naviParam.strName = _naviParameter.strName;

            object ret = Navigator.ShowModalForm(this, "toDatailAutoUpDown", naviParam);
            if (ret != null)
            {

                base.ShowLoadingDialog();

                //���ҏW�ɐݒ�
                base.kkhDetailUpdFlag = false;

                //�󒍓��e���� 
                //base.SearchJyutyuData();
                this.Refresh();

                //���݈ʒu�̎擾 
                int _spdJyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

                base.SearchJyutyuData();

                //���̈ʒu�ɖ߂� 
                _spdJyutyuList_Sheet1.SetActiveCell(_spdJyutyuListRowIdx, 0, true);
                _spdJyutyuList_Sheet1.AddSelection(_spdJyutyuListRowIdx, -1, 1, -1);
                spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

                //�e�̏������Ă�(�e��LeaveCell�C�x���g���������Ȃ��̂�) 
                base.DisplayKkhDetail(_spdJyutyuListRowIdx);
                //�q�̏������Ă�(�e�����Ă�ł���Ȃ��̂�) 
                DisplayKkhDetail(_spdJyutyuListRowIdx);

                //���[�f�B���O�\���I�� 
                base.CloseLoadingDialog();

                MessageUtility.ShowMessageBox(MessageCode.HB_I0004, null, "����", MessageBoxButtons.OK);
            }

            //�I����Ԃ����� 
            this.ActiveControl = null;

        }

        /// <summary>
        /// ���׃X�v���b�h���̃Z���Ńe�L�X�g��ύX����Ƃ��ɔ������܂� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_EditChange(object sender, EditorNotifyEventArgs e)
        {
            switch (e.Column)
            {
                case COLIDX_MLIST_TYUBUNRUI:    // ������ 
                    SetDetailDataBaitai(e.Row, true);
                    break;

                case COLIDX_MLIST_KANRIKBN:     // �Ǘ��敪 
                    SetDetailDataJissiNo(e.Row);
                    break;

                case COLIDX_MLIST_STATUS:       // �X�e�[�^�X 
                    SetDetailDataKbn(e.Row);
                    break;

                case COLIDX_MLIST_TEKIYOU:      // �E�v 
                    // TextCellType�̏ꍇ�͍ő�o�C�g���̕ҏW�������s�� 
                    if (_spdKkhDetail_Sheet1.Columns[e.Column].CellType is TextCellType)
                    {
                        TextCellType tc = (TextCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;
                        string s = e.EditingControl.Text;
                        if (_enc.GetByteCount(s) > tc.MaxLength)
                        {
                            e.EditingControl.Text = _enc.GetString(_enc.GetBytes(s), 0, tc.MaxLength);
                            ((GeneralEditor)e.EditingControl).SelectionStart = e.EditingControl.Text.Length;
                        }
                    }
                    break;

                default:
                    break;
            }

            // �L����וύX�t���O���X�V 
            base.kkhDetailUpdFlag = true;
        }

        /// <summary>
        /// ���׃X�v���b�h���̃Z���Ńt�H�[�J�X���ړ�����Ƃ��ɔ������܂� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_EnterCell(object sender, EnterCellEventArgs e)
        {
            _col = e.Column;
            _row = e.Row;

            switch (e.Column)
            {
                case COLIDX_MLIST_BAITAINM:     // �}�̖� 
                    SetDetailDataBaitai(e.Row, false);
                    break;

                case COLIDX_MLIST_TEKIYOU:      // �E�v 
                    _dataModel.Changed += new SheetDataModelEventHandler(dataModel_Changed);
                    break;

                default:
                    break;
            }

        }

        /// <summary>
        /// ���׃X�v���b�h�̕ҏW���[�h���I������Ƃ��ɔ������܂� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_EditModeOff(object sender, EventArgs e)
        {
            _col = _spdKkhDetail_Sheet1.ActiveColumnIndex;
            _row = _spdKkhDetail_Sheet1.ActiveRowIndex;

            Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);

            switch (_col)
            {
                case COLIDX_MLIST_JISHINO:      // ���{No 

                    // �l���󕶎��ANull�̏ꍇ�A�f�t�H���g�l��ݒ肷�� 
                    if (_spdKkhDetail_Sheet1.Cells[_row, _col].Value == null ||
                        string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[_row, _col].Text))
                    {
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Value = DEF_VALUE_JISHINO;
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Text = DEF_VALUE_JISHINO.ToString();
                    }
                    break;

                case COLIDX_MLIST_HAIBUNRITSU:  // �z���� 

                    // �l���󕶎��ANull�̏ꍇ�A�f�t�H���g�l��ݒ肷�� 
                    if (_spdKkhDetail_Sheet1.Cells[_row, _col].Value == null ||
                        string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[_row, _col].Text))
                    {
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Value = DEF_VALUE_HAIBUNRITSU;
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Text = DEF_VALUE_HAIBUNRITSU.ToString();
                    }

                    // �l����z�Čv�Z 
                    CalculateNebikiSogak(dataRow);

                    // ���z�v�Z 
                    CalculateSagaku(dataRow);
                    break;

                case COLIDX_MLIST_KINGAKU:      // ���z 

                    // �l���󕶎��ANull�̏ꍇ�A�f�t�H���g�l��ݒ肷�� 
                    if (_spdKkhDetail_Sheet1.Cells[_row, _col].Value == null ||
                        string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[_row, _col].Text))
                    {
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Value = DEF_VALUE_KINGAKU;
                        _spdKkhDetail_Sheet1.Cells[_row, _col].Text = DEF_VALUE_KINGAKU.ToString();
                    }

                    // �l����z�Čv�Z 
                    CalculateNebikiSogak(dataRow);

                    // ���z�v�Z 
                    CalculateSagaku(dataRow);
                    break;

                case COLIDX_MLIST_TEKIYOU:      // �E�v 
                    _dataModel.Changed -= new SheetDataModelEventHandler(dataModel_Changed);
                    break;

                default:
                    break;
            }

        }

        /// <summary>
        /// �f�[�^���f��Changed�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataModel_Changed(object sender, SheetDataModelEventArgs e)
        {
            //��ҏW��ԂŃN���b�v�{�[�h����\��t�������ꍇ 
            if (e.Type == SheetDataModelEventType.CellsUpdated)
            {
                try
                {
                    // TextCellType�̏ꍇ�̂ݏ������s�� 
                    if (_spdKkhDetail_Sheet1.Columns[e.Column].CellType is TextCellType)
                    {
                        TextCellType tc = (TextCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;
                        string s = _dataModel.GetValue(e.Row, e.Column).ToString();
                        if (_enc.GetByteCount(s) > tc.MaxLength)
                        {
                            s = KKHUtility.GetByteString(s, tc.MaxLength);
                            _dataModel.SetValue(e.Row, e.Column, s);
                        }
                    }
                }
                catch
                {
                    // �������Ȃ� 
                }
            }
        }


        /// <summary>
        /// �w���v�{�^���N���b�N���� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //HlpClick();
            //���Ӑ�R�[�h 
            string tkskgy = _naviParameter.strTksKgyCd
                + _naviParameter.strTksBmnSeqNo
                + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();

            //���s 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Detail, this, HelpNavigator.KeywordIndex);
        }

        #endregion �C�x���g

        #region ���\�b�h

        /// <summary>
        /// ���z�v�Z 
        /// </summary>
        /// <param name="dataRow">�󒍃f�[�^</param>
        private void CalculateSagaku(Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            // �������v 
            decimal ryoukinGoukei = 0;

            // ���ׂ̌������A�J��Ԃ� 
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                String ryoukinStr = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KINGAKU].Text.Trim();
                // ���ׂ̗��������͂���Ă���ꍇ 
                if (KKHUtility.IsNumeric(ryoukinStr))
                {
                    // �������v�ɉ��Z 
                    ryoukinGoukei = ryoukinGoukei + decimal.Parse(ryoukinStr.Trim());
                }
            }
            // ���z 
            decimal sagaku = dataRow.hb1SeiGak - ryoukinGoukei;
            lblSagakuValue.Text = sagaku.ToString("###,###,###,##0");
            // ���v 
            lblGoukeiValue.Text = ryoukinGoukei.ToString("###,###,###,##0");
        }

        /// <summary>
        /// �l����z�̍Čv�Z 
        /// </summary>
        /// <param name="dataRow">�󒍃f�[�^</param>
        private void CalculateNebikiSogak(Common.KKHSchema.Detail.JyutyuDataRow dataRow)
        {
            // �l����z�Čv�Z�i�������z - �l���z�j 
            decimal sogak = dataRow.hb1SeiGak;
            decimal nebikiGak = (decimal)_spdKkhDetail_Sheet1.Cells[_row, COLIDX_MLIST_NGAK].Value;
            decimal nebikiSogak = sogak - nebikiGak;
            _spdKkhDetail_Sheet1.Cells[_row, COLIDX_MLIST_NKGAK].Value = nebikiSogak;
        }

        /// <summary>
        /// �e�R���g���[���̏����ݒ� 
        /// </summary>
        private void InitializeControl()
        {
            //******************
            //���������� 
            //******************
            lblKenMei.Visible = false;
            txtKenMei.Visible = false;
            lblKikan.Visible = false;
            txtYmdTo.Visible = false;


            //�{�^�� 
            InitializeButtonEnable();

            //�}�X�^�����擾���� 
            GetMasterData();

            //�X�v���b�h�̓��̓}�b�v�ݒ� 
            InputMap im = new InputMap();

            //��ҏW�Z���ł�[F2]�L�[�𖳌� 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);

            //�ҏW���Z���ł�[F2]�L�[�𖳌� 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.F2, Keys.None), SpreadActions.None);

            //��ҏW�Z���ł�[Enter]�L�[���u���s�ֈړ��v 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow);

            //�ҏW���Z���ł�[Enter]�L�[���u���s�ֈړ��v 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Enter, Keys.None), SpreadActions.MoveToNextRow);

            // ��ҏW�Z���ł�[Z]�L�[+[Control]�L�[�𖳌� 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenFocused);
            im.Put(new Keystroke(Keys.Z, Keys.Control), SpreadActions.None);

            // �ҏW���Z���ł�[Z]�L�[+[Control]�L�[�𖳌� 
            im = spdKkhDetail.GetInputMap(InputMapMode.WhenAncestorOfFocused);
            im.Put(new Keystroke(Keys.Z, Keys.Control), SpreadActions.None);
        }

        /// <summary>
        /// �e�{�^����񊈐��ɂ��� 
        /// </summary>
        private void InitializeButtonEnable()
        {
            btnDetailInput.Enabled = false;
            btnDivide.Enabled = false;
            btnDetailDel.Enabled = false;
            btnDetailRegister.Enabled = false;
            btnAutoNo.Enabled = false;
            btnAutoUpDown.Enabled = false;
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
            //�񖈂̐ݒ� 
            //********************************
            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                //���ʐݒ� 
                col.AllowAutoFilter = true;//�t�B���^�@�\��L�� 
                col.AllowAutoSort = true;  //�\�[�g�@�\��L��

                //�񖈂ɈقȂ�ݒ� 
                if (col.Index == COLIDX_MLIST_NENGETSU)
                {
                    TextCellType type = new TextCellType();
                    type.ReadOnly = true;
                    type.Static = true;

                    col.Label = "�N��";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 60;
                }
                else if (col.Index == COLIDX_MLIST_TYUBUNRUI)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData = _itemTyubunruiCd;
                    type.Items = _itemTyubunruiNm;
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;

                    col.Label = "������";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 200;
                }
                else if (col.Index == COLIDX_MLIST_BAITAINM)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData = _itemBaitaiCd;
                    type.Items = _itemBaitaiNm;
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;

                    col.Label = "�}�̖�";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 200;
                }
                else if (col.Index == COLIDX_MLIST_JISHINO)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.MaximumValue = MAX_VALUE_JISHINO;
                    type.MinimumValue = MIN_VALUE_JISHINO;
                    type.NullDisplay = DEF_VALUE_JISHINO;
                    type.ShowSeparator = false;

                    col.Label = "���{No";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 100;
                }
                else if (col.Index == COLIDX_MLIST_HAIBUNRITSU)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 2;
                    type.MaximumValue = MAX_VALUE_HAIBUNRITSU;
                    type.MinimumValue = MIN_VALUE_HAIBUNRITSU;
                    type.NullDisplay = DEF_VALUE_HAIBUNRITSU;
                    type.ShowSeparator = false;

                    col.Label = "�z����";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 60;
                }
                else if (col.Index == COLIDX_MLIST_KINGAKU)
                {
                    NumberCellType type = new NumberCellType();
                    type.DecimalPlaces = 0;
                    type.MaximumValue = MAX_VALUE_KINGAKU;
                    type.MinimumValue = MIN_VALUE_KINGAKU;
                    type.NullDisplay = DEF_VALUE_KINGAKU;
                    type.ShowSeparator = true;

                    col.Label = "���z";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 100;
                }
                else if (col.Index == COLIDX_MLIST_SHOHINNM)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData = _itemShohinCd;
                    type.Items = _itemShohinNm;
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;

                    col.Label = "���i��";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 200;
                }
                else if (col.Index == COLIDX_MLIST_KANRIKBN)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData = new string[] { COMBO_CODE_KBN_GEN.ToString()
                                                 , COMBO_CODE_KBN_FEE.ToString() };
                    type.Items = new string[] { COMBO_NAME_KBN_GEN
                                              , COMBO_NAME_KBN_FEE };
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;

                    col.Label = "�Ǘ��敪";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 60;
                }
                else if (col.Index == COLIDX_MLIST_SHIHARAISITE)
                {
                    TextCellType type = new TextCellType();
                    type.ReadOnly = false;
                    type.Static = false;
                    type.MaxLength = 3;
                    type.CharacterSet = CharacterSet.AlphaNumeric;

                    col.Label = "�x���T�C�g";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 70;
                }
                else if (col.Index == COLIDX_MLIST_TEKIYOU)
                {
                    TextCellType type = new TextCellType();
                    type.ReadOnly = false;
                    type.Static = false;
                    type.MaxLength = 60;
                    type.CharacterSet = CharacterSet.AllIME;

                    col.Label = "�E�v";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 400;
                }
                else if (col.Index == COLIDX_MLIST_STATUS)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData = new string[] { COMBO_CODE_STS_SP.ToString() 
                                                 , COMBO_CODE_STS_MASS.ToString() };
                    type.Items = new string[] { COMBO_NAME_STS_SP
                                              , COMBO_NAME_STS_MASS };
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;

                    col.Label = "�X�e�[�^�X";
                    col.CellType = type;
                    col.Locked = false;
                    col.Width = 70;
                }
                else if (col.Index == COLIDX_MLIST_KBN)
                {
                    TextCellType type = new TextCellType();
                    type.ReadOnly = false;
                    type.Static = false;
                    type.MaxLength = 3;
                    type.CharacterSet = CharacterSet.AlphaNumeric;

                    col.Label = "�敪";
                    col.CellType = type;
                    col.Locked = true;
                    col.Width = 60;
                }
                else if (col.Index == COLIDX_MLIST_NRITU)
                {
                    col.Label = "�l����";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == COLIDX_MLIST_NGAK)
                {
                    col.Label = "�l���z";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
                else if (col.Index == COLIDX_MLIST_NKGAK)
                {
                    col.Label = "�l����z";
                    col.Width = 0;
                    col.Visible = false;
                    col.Locked = true;
                }
            }
        }

        /// <summary>
        /// �e�{�^���̎g�p�E�s�ݒ�𐧌䂷�� 
        /// </summary>
        private void SetButtonEnable()
        {
            // �L����׃f�[�^������ꍇ 
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                // �����E���׍폜�E���דo�^�͉� 
                btnDivide.Enabled = true;
                btnDetailDel.Enabled = true;
                btnDetailRegister.Enabled = true;

                // ���ד��͕͂s�� 
                btnDetailInput.Enabled = false;
            }
            //�L����׃f�[�^���Ȃ��ꍇ 
            else
            {
                // �����E���׍폜�͕s�� 
                btnDivide.Enabled = false;
                btnDetailDel.Enabled = false;

                // ���ד��́E���דo�^�͉� 
                btnDetailInput.Enabled = true;
                btnDetailRegister.Enabled = true;
            }

            bool torokuFlg = false;
            for (int iRow = 0; iRow < _spdJyutyuList_Sheet1.Rows.Count; iRow++)
            {
                // ���דo�^�ς̎󒍃f�[�^�����݂���ꍇ 
                if (_spdJyutyuList_Sheet1.Cells[iRow, COLIDX_JLIST_TOROKU].Text != "")
                {
                    torokuFlg = true;
                    break;
                }
            }

            // ���{No�����t�^�A���{NoUP/DOWN�{�^�����g�p�ɂ��� 
            if (torokuFlg)
            {
                btnAutoNo.Enabled = true;
                btnAutoUpDown.Enabled = true;
            }
            else
            {
                btnAutoNo.Enabled = false;
                btnAutoUpDown.Enabled = false;
            }
        }

        /// <summary>
        /// �}�X�^�����擾���� 
        /// </summary>
        private void GetMasterData()
        {
            MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();
            FindMasterMaintenanceByCondServiceResult result;
            MasterMaintenance ds;
            MasterMaintenance.MasterDataVORow[] rows;

            List<string> lstKeys;
            List<string> lstValues;

            #region �����ރR���{�{�b�N�X�̒l�擾.

            // �����ރ}�X�^���擾.
            result = process.FindMasterByCond(_naviParameter.strEsqId,
                                            _naviParameter.strEgcd,
                                            _naviParameter.strTksKgyCd,
                                            _naviParameter.strTksBmnSeqNo,
                                            _naviParameter.strTksTntSeqNo,
                                            MST_TYUBUNRUI,
                                            null);
            _dsTyubunrui = result.MasterDataSet;
            rows = (MasterMaintenance.MasterDataVORow[])_dsTyubunrui.MasterDataVO.Select();

            lstKeys = new List<string>();
            lstValues = new List<string>();
            lstKeys.Add(string.Empty);
            lstValues.Add(string.Empty);

            _dictBaitai = new Dictionary<string, Dictionary<string[], string[]>>();

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                lstKeys.Add(row.Column1);
                lstValues.Add(row.Column2);

                _dictBaitai.Add(row.Column1, null);
            }

            // �����ރ}�X�^���ݒ�.
            _itemTyubunruiCd = lstKeys.ToArray();
            _itemTyubunruiNm = lstValues.ToArray();

            #endregion �����ރR���{�{�b�N�X�̒l�擾.

            #region �}�̖��R���{�{�b�N�X�̒l�擾.

            // �}�̖��擾.
            result = process.FindMasterByCond(_naviParameter.strEsqId,
                                            _naviParameter.strEgcd,
                                            _naviParameter.strTksKgyCd,
                                            _naviParameter.strTksBmnSeqNo,
                                            _naviParameter.strTksTntSeqNo,
                                            MST_BAITAI,
                                            null);
            ds = result.MasterDataSet;
            rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();

            if (0 < rows.Length)
            {
                List<string> lstKeysAll;
                List<string> lstValuesAll;
                Dictionary<string[], string[]> dict;

                lstKeys = new List<string>();
                lstValues = new List<string>();
                lstKeysAll = new List<string>();
                lstValuesAll = new List<string>();

                string key = rows[0].Column1;

                foreach (MasterMaintenance.MasterDataVORow row in rows)
                {
                    if (!key.Equals(row.Column1))
                    {
                        dict = new Dictionary<string[], string[]>();
                        dict.Add(lstKeys.ToArray(), lstValues.ToArray());

                        _dictBaitai[key] = dict;

                        lstKeys = new List<string>();
                        lstValues = new List<string>();
                    }

                    lstKeys.Add(row.Column2);
                    lstValues.Add(row.Column3);
                    lstKeysAll.Add(row.Column2);
                    lstValuesAll.Add(row.Column3);

                    key = row.Column1;
                }

                dict = new Dictionary<string[], string[]>();
                dict.Add(lstKeys.ToArray(), lstValues.ToArray());

                // �}�̖����𒆕��ރ}�X�^�̃R�[�h�P�ʂŊi�[.
                _dictBaitai[key] = dict;

                // �}�̖����ݒ�.
                _itemBaitaiCd = lstKeysAll.ToArray();
                _itemBaitaiNm = lstValuesAll.ToArray();
            }

            #endregion �}�̖��R���{�{�b�N�X�̒l�擾.

            #region ���i���R���{�{�b�N�X�̒l�擾.

            // ���i���擾.
            result = process.FindMasterByCond(_naviParameter.strEsqId,
                                            _naviParameter.strEgcd,
                                            _naviParameter.strTksKgyCd,
                                            _naviParameter.strTksBmnSeqNo,
                                            _naviParameter.strTksTntSeqNo,
                                            MST_SHOHIN,
                                            null);
            ds = result.MasterDataSet;
            rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();

            lstKeys = new List<string>();
            lstValues = new List<string>();

            foreach (MasterMaintenance.MasterDataVORow row in rows)
            {
                lstKeys.Add(row.Column1);
                lstValues.Add(row.Column2);
            }

            // ���i�����ݒ�.
            _itemShohinCd = lstKeys.ToArray();
            _itemShohinNm = lstValues.ToArray();

            #endregion ���i���R���{�{�b�N�X�̒l�擾.

            #region �����ޕR�t���}�X�^���擾.

            // �����ޕR�t���}�X�^���擾.
            result = process.FindMasterByCond(_naviParameter.strEsqId,
                                            _naviParameter.strEgcd,
                                            _naviParameter.strTksKgyCd,
                                            _naviParameter.strTksBmnSeqNo,
                                            _naviParameter.strTksTntSeqNo,
                                            MST_TYUBUNRUI_HIMOZUKE,
                                            null);

            _dsTyubunruiHimo = result.MasterDataSet;

            #endregion �����ޕR�t���}�X�^���擾.
        }

        /// <summary>
        /// ���׃X�v���b�h�̔}�̖��R���{�{�b�N�X�ɒl��ݒ肷�� 
        /// </summary>
        /// <param name="row">�s�C���f�b�N�X</param>
        /// <param name="defaultFlg">�����l�t���O</param>
        private void SetDetailDataBaitai(int row, bool defaultFlg)
        {
            bool existsFlg = true;

            // �����ނ�Null�A�󕶎��ȊO�̏ꍇ 
            if (_spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_TYUBUNRUI].Value != null &&
                !string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_TYUBUNRUI].Text))
            {
                string key = _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_TYUBUNRUI].Value.ToString();

                // �I�����ꂽ�L�[�i�����ށj�����݂���A���L�[�̒l���擾�ł����ꍇ 
                if (_dictBaitai.ContainsKey(key) && _dictBaitai[key] != null)
                {
                    string[] keys;
                    string[] values;

                    // �I�����ꂽ�����ނɍ��v����}�̖����擾�� 
                    // �X�v���b�h�̃R���{�{�b�N�X�ɒl��ݒ肷�� 
                    foreach (KeyValuePair<string[], string[]> kvp in _dictBaitai[key])
                    {
                        keys = kvp.Key;
                        values = kvp.Value;

                        object beforeValue = _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].Value;
                        string beforeText = _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].Text;

                        ComboBoxCellType comboType = new ComboBoxCellType();
                        comboType.ItemData = keys;
                        comboType.Items = values;
                        comboType.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                        comboType.Editable = false;

                        _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].CellType = comboType;

                        // �����l�t���O��true�̏ꍇ�A�擪���ڂ�\������
                        if (defaultFlg)
                        {
                            _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].Value = keys[0].ToString();
                            _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].Text = values[0].ToString();
                        }
                        else
                        {
                            _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].Value = beforeValue;
                            _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].Text = beforeText;
                        }
                        break;
                    }
                }
                else
                {
                    existsFlg = false;
                }
            }
            else
            {
                existsFlg = false;
            }

            if (!existsFlg)
            {
                ComboBoxCellType comboType = new ComboBoxCellType();
                comboType.ItemData = new string[] { string.Empty };
                comboType.Items = new string[] { string.Empty };
                comboType.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                comboType.Editable = false;

                _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].CellType = comboType;
                _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].Value = string.Empty;
                _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_BAITAINM].Text = string.Empty;
            }
        }

        /// <summary>
        /// ���׃X�v���b�h�̎��{No�ɒl��ݒ肷�� 
        /// </summary>
        /// <param name="row">�s�C���f�b�N�X</param>
        private void SetDetailDataJissiNo(int row)
        {
            // �I��l���t�B�[�̏ꍇ 
            if (COMBO_NAME_KBN_FEE.Equals(_spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_KANRIKBN].Text))
            {
                // ���{No��0��ݒ肷�� 
                _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_JISHINO].Value = 0;
            }
        }

        /// <summary>
        /// ���׃X�v���b�h�̋敪�ɒl��ݒ肷�� 
        /// </summary>
        /// <param name="row">�s�C���f�b�N�X</param>
        private void SetDetailDataKbn(int row)
        {
            if (_spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_STATUS].Value != null &&
                !string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_STATUS].Text))
            {
                // �I��l��SP�̏ꍇ 
                if (COMBO_CODE_STS_SP.ToString().Equals(_spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_STATUS].Value.ToString()))
                {
                    // �敪�����b�N���������� 
                    _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_KBN].Locked = false;
                }
                // �I��l��MASS�̏ꍇ 
                else if (COMBO_CODE_STS_MASS.ToString().Equals(_spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_STATUS].Value.ToString()))
                {
                    // �敪�����b�N���� 
                    _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_KBN].Locked = true;
                    _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_KBN].Value = null;
                    _spdKkhDetail_Sheet1.Cells[row, COLIDX_MLIST_KBN].Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// ���׃f�[�^�ݒ菈�� 
        /// </summary>
        /// <param name="dataRow">�󒍃f�[�^</param>
        /// <param name="rowIndex">���׍s�C���f�b�N�X</param>
        /// <param name="mode">�������[�h</param>
        private void SetDetailData(Common.KKHSchema.Detail.JyutyuDataRow dataRow
                                , int rowIndex
                                , Mode mode)
        {
            // �P�s�ǉ� 
            _spdKkhDetail_Sheet1.AddRows(rowIndex, 1);
            _spdKkhDetail_Sheet1.AddSelection(rowIndex, -1, 1, -1);

            // �t�B���^�[�̍쐬 
            string filter = "Column2 = \'" + dataRow["hb1GyomKbn"] + "\'";
            if (!string.IsNullOrEmpty(dataRow["hb1TmspKbn"].ToString()))
            {
                // �Ɩ��敪�����W�I�A�q�����f�B�A�̏ꍇ 
                if (KKHSystemConst.GyomKbn.Radio == dataRow.hb1GyomKbn ||
                    KKHSystemConst.GyomKbn.EiseiM == dataRow.hb1GyomKbn)
                //if (KKHSystemConst.GyomKbn.Radio.Equals(cmbGymKbn.SelectedValue) ||
                //    KKHSystemConst.GyomKbn.EiseiM.Equals(cmbGymKbn.SelectedValue))
                {
                    filter += " AND Column3 = \'" + dataRow["hb1TmspKbn"] + "\'";
                }
            }

            // �����ޕR�t���}�X�^�����A�I�����ꂽ�󒍃f�[�^�ɍ��v���钆���ނ��擾 
            MasterMaintenance.MasterDataVORow[] rows;
            rows = (MasterMaintenance.MasterDataVORow[])_dsTyubunruiHimo.MasterDataVO.Select(filter);

            string tyubunrui = string.Empty;
            string[] baitai = new string[] { string.Empty };

            if (0 < rows.Length)
            {
                StringBuilder sb = new StringBuilder();
                foreach (MasterMaintenance.MasterDataVORow row in rows)
                {
                    sb.Append("\'" + row.Column1 + "\',");
                }

                // �����ރ}�X�^��񂩂璆���ރR�[�h���擾 
                filter = " Column1 IN (" + sb.ToString().TrimEnd(new char[] { ',' }) + ")";
                rows = (MasterMaintenance.MasterDataVORow[])_dsTyubunrui.MasterDataVO.Select(filter);

                foreach (MasterMaintenance.MasterDataVORow row in rows)
                {
                    tyubunrui = row.Column1;
                    break;
                }

                if (_dictBaitai.ContainsKey(tyubunrui))
                {
                    foreach (KeyValuePair<string[], string[]> kvp in _dictBaitai[tyubunrui])
                    {
                        baitai = kvp.Key;
                        break;
                    }
                }
            }

            // �������[�h�ɂ�蕪�� 
            // ���ד��͂̏ꍇ 
            if (mode == Mode.DetailInput)
            {
                decimal kingaku = decimal.Parse(dataRow["hb1SeiGak"].ToString());

                // ���׃X�v���b�h�ɒl��ݒ� 
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_NENGETSU].Value = dataRow.hb1Yymm;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_TYUBUNRUI].Value = tyubunrui;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_BAITAINM].Value = baitai[0];
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_JISHINO].Value = GetMaxJissiNo();
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_HAIBUNRITSU].Value = 100.ToString("##0.00");
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_KINGAKU].Value = kingaku.ToString("###,###,###,##0");
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_SHOHINNM].Value = _itemShohinCd[0];
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_KANRIKBN].Value = COMBO_CODE_KBN_GEN;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_SHIHARAISITE].Value = DEF_VALUE_SHIHARAISITE;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_TEKIYOU].Value = string.Empty;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_STATUS].Value = COMBO_CODE_STS_MASS;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_KBN].Value = string.Empty;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_NRITU].Value = 0;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_NGAK].Value = 0;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_NKGAK].Value = dataRow.hb1SeiGak;
            }
            // �����̏ꍇ 
            else if (mode == Mode.Divide)
            {
                int activeRowIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

                // ���׃X�v���b�h�ɒl��ݒ� 
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_NENGETSU].Value = dataRow.hb1Yymm;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_TYUBUNRUI].Value = tyubunrui;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_BAITAINM].Value = baitai[0];
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_JISHINO].Value = GetMaxJissiNo();
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_HAIBUNRITSU].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_HAIBUNRITSU].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_KINGAKU].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_KINGAKU].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_SHOHINNM].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_SHOHINNM].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_KANRIKBN].Value = COMBO_CODE_KBN_GEN;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_SHIHARAISITE].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_SHIHARAISITE].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_TEKIYOU].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_TEKIYOU].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_STATUS].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_STATUS].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_KBN].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_KBN].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_NRITU].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_NRITU].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_NGAK].Value =
                    _spdKkhDetail_Sheet1.Cells[activeRowIndex, COLIDX_MLIST_NGAK].Value;
                _spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_NKGAK].Value = dataRow.hb1SeiGak;

                SetDetailDataKbn(rowIndex);
            }

            // �擪��Ƀt�H�[�J�X�ړ� 
            _spdKkhDetail_Sheet1.SetActiveCell(rowIndex, COLIDX_MLIST_NENGETSU);
            spdKkhDetail.ShowCell(0, 0, rowIndex, COLIDX_MLIST_NENGETSU, VerticalPosition.Nearest, HorizontalPosition.Nearest);
            _spdKkhDetail_Sheet1.ClearSelection();
            spdKkhDetail.Focus();
        }

        /// <summary>
        /// ���׃`�F�b�N���� 
        /// </summary>
        /// <returns>���茋��</returns>
        private bool CheckDetailData()
        {
            for (int iRow = 0; iRow < _spdKkhDetail_Sheet1.RowCount; iRow++)
            {
                // ������ 
                if (_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_TYUBUNRUI].Value == null ||
                    string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_TYUBUNRUI].Text))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0060, null, "���דo�^", MessageBoxButtons.OK);

                    _spdKkhDetail_Sheet1.SetActiveCell(iRow, COLIDX_MLIST_TYUBUNRUI);
                    spdKkhDetail.ShowCell(0, 0, iRow, COLIDX_MLIST_TYUBUNRUI, VerticalPosition.Nearest, HorizontalPosition.Nearest);
                    spdKkhDetail.Focus();
                    return false;
                }

                // �}�� 
                if (_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_BAITAINM].Value == null ||
                    string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_BAITAINM].Text))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0077, null, "���דo�^", MessageBoxButtons.OK);
                    _spdKkhDetail_Sheet1.SetActiveCell(iRow, COLIDX_MLIST_BAITAINM);
                    spdKkhDetail.ShowCell(0, 0, iRow, COLIDX_MLIST_BAITAINM, VerticalPosition.Nearest, HorizontalPosition.Nearest);
                    spdKkhDetail.Focus();
                    return false;
                }

                // �z�����i�l����łȂ��ꍇ�̂݁j 
                if (_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_HAIBUNRITSU].Value != null &&
                    !string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_HAIBUNRITSU].Text))
                {
                    string ritsuStr = _spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_HAIBUNRITSU].Value.ToString();

                    if (KKHUtility.IsNumeric(ritsuStr))
                    {
                        double ritsu = double.Parse(ritsuStr.Trim());

                        if (ritsu > MAX_VALUE_HAIBUNRITSU || ritsu < MIN_VALUE_HAIBUNRITSU)
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0075, null, "���דo�^", MessageBoxButtons.OK);
                            _spdKkhDetail_Sheet1.SetActiveCell(iRow, COLIDX_MLIST_HAIBUNRITSU);
                            spdKkhDetail.ShowCell(0, 0, iRow, COLIDX_MLIST_HAIBUNRITSU, VerticalPosition.Nearest, HorizontalPosition.Nearest);
                            spdKkhDetail.Focus();
                            return false;
                        }
                    }
                }

                // ���z�i�l����łȂ��ꍇ�̂݁j
                if (_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_KINGAKU].Value != null &&
                    !string.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_KINGAKU].Text))
                {
                    string kingkStr = _spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_KINGAKU].Value.ToString();

                    if (KKHUtility.IsNumeric(kingkStr))
                    {
                        double kingk = double.Parse(kingkStr.Trim());

                        if (kingk > MAX_VALUE_KINGAKU || kingk < MIN_VALUE_KINGAKU)
                        {
                            MessageUtility.ShowMessageBox(MessageCode.HB_W0027, null, "���דo�^", MessageBoxButtons.OK);
                            _spdKkhDetail_Sheet1.SetActiveCell(iRow, COLIDX_MLIST_KINGAKU);
                            spdKkhDetail.ShowCell(0, 0, iRow, COLIDX_MLIST_KINGAKU, VerticalPosition.Nearest, HorizontalPosition.Nearest);
                            spdKkhDetail.Focus();
                            return false;
                        }
                    }
                }
            }

            // ���{No 
            // ����`�F�b�N���s�� 
            string baitaiCd = string.Empty;
            string jishiNo = string.Empty;
            decimal jisNo = 0;
            for (int iRow = 0; iRow < _spdKkhDetail_Sheet1.RowCount; iRow++)
            {
                baitaiCd = _spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_BAITAINM].Value.ToString().Trim();
                jisNo = decimal.Parse(_spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_JISHINO].Value.ToString().Trim());
                //jishiNo = _spdKkhDetail_Sheet1.Cells[iRow, COLIDX_MLIST_JISHINO].Value.ToString().Trim();
                //�����l�̂ݎ擾 
                jishiNo = jisNo.ToString("#");

                for (int iRow2 = 0; iRow2 < _spdKkhDetail_Sheet1.RowCount; iRow2++)
                {
                    // ����̍s�f�[�^���r���Ȃ��悤�Ƀ`�F�b�N 
                    if (iRow != iRow2)
                    {
                        // �}�̃R�[�h���r 
                        if (!baitaiCd.Equals(_spdKkhDetail_Sheet1.Cells[iRow2, COLIDX_MLIST_BAITAINM].Value.ToString().Trim()))
                        {
                            // ���{No���r 
                            if (jishiNo.Equals(_spdKkhDetail_Sheet1.Cells[iRow2, COLIDX_MLIST_JISHINO].Value.ToString().Trim()))
                            {
                                // ���b�Z�[�W�\�� 
                                MessageUtility.ShowMessageBox(MessageCode.HB_W0055, null, "���דo�^", MessageBoxButtons.OK);
                                _spdKkhDetail_Sheet1.SetActiveCell(iRow2, COLIDX_MLIST_JISHINO);
                                spdKkhDetail.ShowCell(0, 0, iRow, COLIDX_MLIST_JISHINO, VerticalPosition.Nearest, HorizontalPosition.Nearest);
                                spdKkhDetail.Focus();
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// ���דo�^���� 
        /// </summary>
        private void RegistDetailData()
        {
            //���[�f�B���O�\���J�n 
            base.ShowLoadingDialog();

            //�T�[�r�X�p�����[�^�p�ϐ� 
            Common.KKHSchema.Detail dsDetail = new Common.KKHSchema.Detail();
            string esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            DateTime maxUpdDate = new DateTime();

            Common.KKHSchema.Detail.JyutyuDataRow dataRow = getSelectJyutyuData(-1);

            //*********************************************
            //THB2KMEI�̓o�^�f�[�^�ҏW 
            //*********************************************
            int jyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;
            Common.KKHSchema.Detail.THB2KMEIDataTable dtThb2Kmei = new Common.KKHSchema.Detail.THB2KMEIDataTable();
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                Common.KKHSchema.Detail.THB2KMEIRow addRow = dtThb2Kmei.NewTHB2KMEIRow();

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
                //addRow.hb2HimkCd = " ";
                //addRow.hb2Renbn = (i + 1).ToString("000"); ���דo�^�����g���Ή�
                addRow.hb2Renbn = (i + 1).ToString("0000");
                addRow.hb2DateFrom = " ";
                addRow.hb2DateTo = " ";
                addRow.hb2SeiGak = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KINGAKU].Value);
                addRow.hb2Hnnert = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NRITU].Value);
                addRow.hb2HnmaeGak = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NKGAK].Value);
                addRow.hb2NebiGak = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NGAK].Value);

                addRow.hb2Date1 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_NENGETSU].Value);
                addRow.hb2Date2 = " ";
                addRow.hb2Date3 = " ";
                addRow.hb2Date4 = " ";
                addRow.hb2Date5 = " ";
                addRow.hb2Date6 = " ";

                addRow.hb2Kbn1 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_STATUS].Value);
                addRow.hb2Kbn2 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KANRIKBN].Value);
                addRow.hb2Kbn3 = " ";

                if (EGYSHOCD_20.Equals(_naviParameter.strEgcd))
                {
                    addRow.hb2Code1 = "101";
                }
                else
                {
                    addRow.hb2Code1 = "100";
                }
                addRow.hb2Code2 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAINM].Value);
                addRow.hb2Code3 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHOHINNM].Value);
                addRow.hb2Code4 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHIHARAISITE].Value);
                addRow.hb2Code5 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TYUBUNRUI].Value);
                addRow.hb2Code6 = " ";

                addRow.hb2Name1 = " ";
                addRow.hb2Name2 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SHOHINNM].Text);
                addRow.hb2Name3 = " ";
                addRow.hb2Name4 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TYUBUNRUI].Text);
                addRow.hb2Name5 = " ";
                addRow.hb2Name6 = " ";
                addRow.hb2Name7 = " ";
                addRow.hb2Name8 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TEKIYOU].Value);
                addRow.hb2Name9 = " ";
                addRow.hb2Name10 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_BAITAINM].Text);

                addRow.hb2Kngk1 = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_JISHINO].Value);
                addRow.hb2Kngk2 = 0M;
                addRow.hb2Kngk3 = 0M;

                addRow.hb2Ritu1 = GetDecimalValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_HAIBUNRITSU].Value);
                addRow.hb2Ritu2 = 0M;

                addRow.hb2Sonota1 = GetStringValue(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KBN].Value);
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
                addRow.hb2MeihnFlg = " ";
                addRow.hb2NebhnFlg = " ";

                dtThb2Kmei.AddTHB2KMEIRow(addRow);
            }
            dsDetail.THB2KMEI.Merge(dtThb2Kmei);
            //dsDetail.AcceptChanges();

            //*********************************************
            //THB1DOWN�̓o�^�f�[�^�ҏW 
            //*********************************************
            Common.KKHSchema.Detail.THB1DOWNDataTable dtThb1Down = new Common.KKHSchema.Detail.THB1DOWNDataTable();
            Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow = dtThb1Down.NewTHB1DOWNRow();

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
            //�������t���O 
            if (Isid.KKH.Common.KKHUtility.KKHUtility.DecParse(lblSagakuValue.Text) == 0)
            {
                thb1DownRow.hb1MSeiFlg = "0";
            }
            else
            {
                thb1DownRow.hb1MSeiFlg = "1";
            }

            //���׍s�����݂���ꍇ 
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

            //�X�V���t�ő�l�̔���             
            //��������Ă���ꍇ 
            if (dataRow.hb1TouFlg == "1")
            {
                //��������Ă���󒍓o�^���e�̃f�[�^����X�V���t�̍ő�l���擾����B 
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

            foreach (Common.KKHSchema.Detail.THB2KMEIRow thb2KmeiRow in _dsDetail.THB2KMEI.Rows)
            {
                if (maxUpdDate == null || maxUpdDate.CompareTo(thb2KmeiRow.hb2TimStmp) < 0)
                {
                    maxUpdDate = thb2KmeiRow.hb2TimStmp;
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

            //�G���[�̏ꍇ 
            if (result.HasError)
            {
                //���[�f�B���O�\���I�� 
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

            base.kkhDetailUpdFlag = false; //�L����וύX�t���O���X�V 
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                //���דo�^"��"��ݒ� 
                _spdJyutyuList_Sheet1.Cells[_spdJyutyuList_Sheet1.ActiveRowIndex, COLIDX_JLIST_TOROKU].Value = "��";
            }
            else
            {
                //���דo�^"��"������ 
                _spdJyutyuList_Sheet1.Cells[_spdJyutyuList_Sheet1.ActiveRowIndex, COLIDX_JLIST_TOROKU].Value = "";
            }

            //******************************************************************************************
            //�ێ����Ă���󒍓o�^���e�f�[�^��������̃f�[�^�ōX�V���� 
            //******************************************************************************************
            //foreach (Common.KKHSchema.Detail.THB1DOWNRow updRow in result.DsDetail.THB1DOWN.Rows)
            //{
            //    _dsDetail.JyutyuData.UpdateRowDataByTGADOWNRow(updRow);
            //    _dsDetail.THB1DOWN.UpdateRowData(updRow);
            //}
            //_dsDetail.THB2KMEI.Clear();
            //_dsDetail.THB2KMEI.Merge(result.DsDetail.THB2KMEI);
            //_dsDetail.AcceptChanges();


            ////���݈ʒu�̎擾 
            //int _spdJyutyuListRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            //base.SearchJyutyuData();

            ////���̈ʒu�ɖ߂� 
            //_spdJyutyuList_Sheet1.SetActiveCell(_spdJyutyuListRowIdx, 0, true);
            //_spdJyutyuList_Sheet1.AddSelection(_spdJyutyuListRowIdx, -1, 1, -1);
            //spdJyutyuList.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Left);

            ////�e�̏������Ă�(�e��LeaveCell�C�x���g���������Ȃ��̂�) 
            //base.DisplayKkhDetail(_spdJyutyuListRowIdx);
            ////�q�̏������Ă�(�e�����Ă�ł���Ȃ��̂�) 
            //DisplayKkhDetail(_spdJyutyuListRowIdx);

            DisplayUpdate();

            //���[�f�B���O�\���I�� 
            base.CloseLoadingDialog();

            //MessageBox.Show("�L����ׂ̓o�^���������܂����B", "���דo�^", MessageBoxButtons.OK);
            MessageUtility.ShowMessageBox(MessageCode.HB_I0012, null, "���דo�^", MessageBoxButtons.OK);
            btnAutoNo.Enabled = true;
            btnAutoUpDown.Enabled = true;
        }

        /// <summary>
        /// �����̒l�𕶎���ɕϊ����ԋp���� 
        /// </summary>
        /// <param name="obj">�ϊ��Ώۂ̃I�u�W�F�N�g</param>
        /// <returns>�ϊ���̒l</returns>
        private string GetStringValue(object obj)
        {
            string ret;
            if (!string.IsNullOrEmpty(KKHUtility.ToString(obj)))
            {
                ret = obj.ToString();
            }
            else
            {
                ret = " ";
            }
            return ret;
        }

        /// <summary>
        /// �����̒l�𐔒l�ɕϊ����ԋp���� 
        /// </summary>
        /// <param name="obj">�ϊ��Ώۂ̃I�u�W�F�N�g</param>
        /// <returns>�ϊ���̒l</returns>
        private decimal GetDecimalValue(object obj)
        {
            decimal ret;
            if (!string.IsNullOrEmpty(KKHUtility.ToString(obj)))
            {
                ret = KKHUtility.DecParse(obj.ToString());
            }
            else
            {
                ret = 0M;
            }
            return ret;
        }

        /// <summary>
        /// ���{No�̍ő�l�擾 
        /// </summary>
        /// <returns>���{No�̍ő�l</returns>
        private decimal GetMaxJissiNo()
        {
            //*******************************************************************
            // ���{No�̍ő�l�擾 
            //*******************************************************************
            DetailTkdProcessController.FindMaxJissiNoByCondParam param =
                new DetailTkdProcessController.FindMaxJissiNoByCondParam();

            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = txtYmd.Text.Replace("/", "");

            string messageCode;
            string[] note;

            DetailTkdProcessController processController = DetailTkdProcessController.GetInstance();
            decimal result = processController.FindMaxJissiNoByCond(param, out messageCode, out note);

            return result += 1;
        }


        /// <summary>
        /// ���{No�̐������`�F�b�NSV 
        /// </summary>
        /// <returns>True:���g�p/False:�g�p��</returns>
        private bool CheckJissiNoComp()
        {
            //*******************************************************************
            // �g�p�ώ��{No�̌����擾 
            //*******************************************************************
            DataRowView rowView = (DataRowView)_bsJyutyuList[_spdJyutyuList_Sheet1.GetModelRowFromViewRow(_spdJyutyuList_Sheet1.ActiveRowIndex)];
            Common.KKHSchema.Detail.JyutyuListRow listRow = (Common.KKHSchema.Detail.JyutyuListRow)rowView.Row;
            Common.KKHSchema.Detail.JyutyuDataRow dataRow = _dsDetail.JyutyuData.FindByrowNum(listRow.rowNo);

            // ���{No�̐��� 
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                sb.Append("\'" + _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_JISHINO].Value.ToString() + "\', ");
            }
            string jissiNo = sb.ToString().TrimEnd(new char[] { ',', ' ' });

            // �p�����[�^�Z�b�g 
            DetailTkdProcessController.FindJissiNoCntByCondParam param =
                new DetailTkdProcessController.FindJissiNoCntByCondParam();

            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = txtYmd.Text.Replace("/", "");
            param.jyutNo = dataRow.hb1JyutNo;
            param.jyMeiNo = dataRow.hb1JyMeiNo;
            param.urMeiNo = dataRow.hb1UrMeiNo;
            param.jissiNo = jissiNo;

            string messageCode;
            string[] note;

            DetailTkdProcessController processController = DetailTkdProcessController.GetInstance();
            decimal result = processController.FindJissiNoCntByCond(param, out messageCode, out note);

            if (0 < result)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// ���{No�t�^�{�^���������̔z�����`�F�b�N 
        /// </summary>
        /// <param name="jyuListdt">���׃f�[�^</param>
        /// <param name="urimeino">���㖾��No</param>
        /// <param name="kenNm">����</param>
        /// <param name="msgCd">���b�Z�[�W�R�[�h</param>
        /// <returns>���茋��</returns>
        private bool HaibunCheck(Common.KKHSchema.Detail jyuListdt, 
            out string urimeino, out string kenNm, out string msgCd)
        {
            //���� true:�G���[
            bool result = false;
            urimeino = string.Empty;
            kenNm = "";
            msgCd = "";
            int j = 0;
            string code = null;
            //string urimeino = String.Empty;
            double haibunSum = 0;
            double kngk1;
            string sort = "hb2JyutNo, hb2JyMeiNo, hb2UrMeiNo, hb2Code2, hb2Ritu1";
            foreach (KKH.Common.KKHSchema.Detail.THB2KMEIRow row in jyuListdt.THB2KMEI.Select(string.Empty, sort))
            {
                //1��ڂ̃��[�v 
                if (j == 0)
                {
                    urimeino = row.hb2JyutNo + "-" + row.hb2JyMeiNo + "-" + row.hb2UrMeiNo;
                    code = row.hb2Code2;
                    haibunSum = (double)row.hb2Ritu1;
                    //j++;
                    kngk1 = (double)row.hb2Kngk1;
                }
                //2��ڈȍ~�̃��[�v 
                else
                {
                    //���㖾��No������ 
                    if (urimeino.Equals(row.hb2JyutNo + "-" + row.hb2JyMeiNo + "-" + row.hb2UrMeiNo))
                    {
                        //�}�̃R�[�h������ 
                        if (code.Equals(row.hb2Code2))
                        {
                            //����̔z������100%�̏ꍇ 
                            if (row.hb2Ritu1 == 100)
                            {
                                //�z�������v��100%�ł͂Ȃ��ꍇerror
                                if (haibunSum != 100)
                                {
                                    msgCd = MessageCode.HB_W0073;
                                    kenNm = GetKenNm(urimeino);
                                    return result = true;
                                }
                                haibunSum = (double)row.hb2Ritu1;
                            }
                            //����̔z������100%�ł͂Ȃ��ꍇ 
                            //�z�����𑫂��Ă��� 
                            else
                            {
                                haibunSum += (double)row.hb2Ritu1;
                            }
                        }
                        //�}�̃R�[�h���Ⴄ�ꍇ 
                        else
                        {
                            //�z�����̍��v��100%�ł͂Ȃ��ꍇerror 
                            if (haibunSum != 100)
                            {
                                msgCd = MessageCode.HB_W0153;
                                kenNm = GetKenNm(urimeino);
                                return result = true;
                            }
                            //�V�����z����������B 
                            code = row.hb2Code2;
                            haibunSum = (double)row.hb2Ritu1;
                        }
                    }
                    //���㖾��No���Ⴄ�ꍇ 
                    else
                    {
                        //�z�����̍��v��100%�ł͂Ȃ��ꍇerror 
                        if (haibunSum != 100)
                        {
                            msgCd = MessageCode.HB_W0153;
                            kenNm = GetKenNm(urimeino);
                            return result = true;
                        }
                        urimeino = row.hb2JyutNo + "-" + row.hb2JyMeiNo + "-" + row.hb2UrMeiNo;
                        code = row.hb2Code2;
                        haibunSum = (double)row.hb2Ritu1;
                    }
                }

                //�ŏI�̃f�[�^�̂Ƃ��ɔz�����̍��v��100%�łȂ��ꍇ 
                if (j == jyuListdt.THB2KMEI.Count - 1)
                {
                    //�z�����̍��v��100%�ł͂Ȃ��ꍇerror 
                    if (haibunSum != 100)
                    {
                        msgCd = MessageCode.HB_W0153;
                        kenNm = GetKenNm(urimeino);
                        return result = true;
                    }
                }

                j++;
            }

            return result;
        }

        /// <summary>
        /// ���{No�t�^�{�^����������[�Ǘ��敪]�`�F�b�N 
        /// </summary>
        /// <param name="jyuListdt">���׃f�[�^</param>
        /// <returns>[�t�B�[]:true</returns>
        private bool ChkKnrKbn(Common.KKHSchema.Detail jyuListdt)
        {
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            { 
                //[�Ǘ��敪]���擾 
                string knrKbn = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KANRIKBN].Value.ToString();

                //[�t�B�[]�̏ꍇ 
                if (knrKbn.Equals("2"))
                { 
                    //[���{No]���擾 
                    string jisiNo = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_JISHINO].Value.ToString();
                    
                    //���{No��0�ȊO�Ȃ烏�[�j���O���o�� 
                    if (!jisiNo.Equals("0"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// ���{No�̍̔Ԃ��s�� 
        /// </summary>
        /// <param name="jyuListdt">���׃f�[�^</param>
        /// <returns>���{No�z��</returns>
        private string[] CreateJissiNo(Common.KKHSchema.Detail jyuListdt)
        {
            string[] result = new string[jyuListdt.THB2KMEI.Count];
            int count1 = 0;
            int count2 = 0;
            //int jissiNoCnt = 0;

            foreach (KKH.Common.KKHSchema.Detail.THB2KMEIRow row in jyuListdt.THB2KMEI)
            {
                if (result[count1] == null)
                {
                    //if (row.hb2Ritu1 != 100)
                    {// �z�����P�O�O�łȂ��ꍇ 

                        //�z����100�̏ꍇ  
                        if (row.hb2Ritu1 == 100)
                        {
                            // ���{No�J�E���g�A�b�v 
                            jissiNoCnt++;

                            // ���{No��ݒ� 
                            result[count1] = jissiNoCnt.ToString();
                        }
                        // �z������100�����̏ꍇ 
                        else if (row.hb2Ritu1 < 100)
                        {
                            // ���{No�J�E���g�A�b�v 
                            jissiNoCnt++;

                            count2 = count1;
                            // ���ꔄ�㖾��No�A����}�́A�z������100�����̖��ׂ̂ݎ擾 
                            string filter = "hb2JyutNo = \'" + row.hb2JyutNo + "\' "
                                          + "AND hb2JyMeiNo = \'" + row.hb2JyMeiNo + "\' "
                                          + "AND hb2UrMeiNo = \'" + row.hb2UrMeiNo + "\' "
                                          + "AND hb2Code2 = \'" + row.hb2Code2 + "\' "
                                          + "AND hb2Ritu1 < 100";
                            foreach (KKH.Common.KKHSchema.Detail.THB2KMEIRow row2 in jyuListdt.THB2KMEI.Select(filter))
                            {
                                // ���{No��ݒ� 
                                result[count2] = jissiNoCnt.ToString();
                                count2++;
                            }
                        }
                    }
                }
                count1++;
            }

            return result;
        }

        /// <summary>
        /// ���{No�̍̔Ԃ��s��(�N���G�[�e�B�u) 
        /// </summary>
        /// <param name="jyuListdt">���׃f�[�^</param>
        /// <param name="jyutNo">��No</param>
        /// <param name="jyMeiNo">�󒍖���No</param>
        /// <param name="urMeiNo">���㖾��No</param>
        /// <param name="haibun">�z����</param>
        /// <param name="renban">�A��</param>
        /// <param name="baitaiCd">�}�̃R�[�h</param>
        /// <returns>���{No�z��</returns>
        private string[] CreateJissiNoCreative(Common.KKHSchema.Detail jyuListdt,
            out String[] jyutNo, 
            out String[] jyMeiNo, 
            out String[] urMeiNo, 
            out String[] haibun, 
            out String[] renban, 
            out String[] baitaiCd)
        {
            //���{No
            string[] result = new string[jyuListdt.THB2KMEI.Count];
            //��No 
            jyutNo = new String[jyuListdt.THB2KMEI.Rows.Count];
            //�󒍖���No 
            jyMeiNo = new String[jyuListdt.THB2KMEI.Rows.Count];
            //���㖾��No 
            urMeiNo = new String[jyuListdt.THB2KMEI.Rows.Count];
            //�z���� 
            haibun = new String[jyuListdt.THB2KMEI.Rows.Count];
            //�A�� 
            renban = new String[jyuListdt.THB2KMEI.Rows.Count];
            //�}�̃R�[�h 
            baitaiCd = new String[jyuListdt.THB2KMEI.Rows.Count];
            int count1 = 0;
            int count2 = 0;
            ArrayList list = new ArrayList();
            ArrayList list2 = new ArrayList();

            //���ׂ̌������������� 
            foreach (KKH.Common.KKHSchema.Detail.THB2KMEIRow row in jyuListdt.THB2KMEI)
            {
                //�o�^�ς݂̔��㖾��No������ꍇ 
                if (list.Count > 0)
                {
                    //����̔��㖾��No�͏������Ȃ� 
                    if (list.Contains(row.hb2JyutNo + row.hb2JyMeiNo + row.hb2UrMeiNo))
                    {
                        continue;
                    }
                }
                // ���ꔄ�㖾��No���擾 
                string filter = @"hb2JyutNo = '" + row.hb2JyutNo + "' "
                              + @"AND hb2JyMeiNo = '" + row.hb2JyMeiNo + "' "
                              + @"AND hb2UrMeiNo = '" + row.hb2UrMeiNo + "' ";

                string sort =  "hb2JyutNo, "
                              + "hb2JyMeiNo, "
                              + "hb2UrMeiNo, "
                              + "hb2Code3";

                //���㖾��No�ŕ��ѕς��� 
                foreach (KKH.Common.KKHSchema.Detail.THB2KMEIRow row2 in jyuListdt.THB2KMEI.Select(filter, sort))
                {
                    //����̔��㖾��No�A�Ԃ͏������Ȃ� 
                    if (list2.Count > 0)
                    {
                        if (list2.Contains(row2.hb2JyutNo + row2.hb2JyMeiNo + row2.hb2UrMeiNo + row2.hb2Renbn))
                        {
                            continue;
                        }
                    }

                    // ���{No�J�E���g�A�b�v 
                    jissiNoCnt++;

                    //�z����100�̏ꍇ  
                    if (row2.hb2Ritu1 == 100)
                    {
                        // ���{No��ݒ� 
                        result[count1] = jissiNoCnt.ToString();
                        //��No
                        jyutNo[count1] = row2.hb2JyutNo;
                        //�󒍖���No 
                        jyMeiNo[count1] = row2.hb2JyMeiNo;
                        //���㖾��No 
                        urMeiNo[count1] = row2.hb2UrMeiNo;
                        //�z���� 
                        haibun[count1] = row2.hb2Ritu1.ToString();
                        //�A�� 
                        renban[count1] = row2.hb2Renbn;
                        //�}�̃R�[�h 
                        baitaiCd[count1] = row2.hb2Code2;
                        //���㖾��No�A�Ԃ�o�^���� 
                        list2.Add(row2.hb2JyutNo + row2.hb2JyMeiNo + row2.hb2UrMeiNo + row2.hb2Renbn);
                        count1++;
                    }
                    // �z������100�����̏ꍇ 
                    else if (row2.hb2Ritu1 < 100)
                    {
                        count2 = count1;
                        // ���ꔄ�㖾��No�A����}�́A�z������100�����̖��ׂ̂ݎ擾 
                        string filter2 = "hb2JyutNo = \'" + row2.hb2JyutNo + "\' "
                                      + "AND hb2JyMeiNo = \'" + row2.hb2JyMeiNo + "\' "
                                      + "AND hb2UrMeiNo = \'" + row2.hb2UrMeiNo + "\' "
                                      + "AND hb2Code2 = \'" + row2.hb2Code2 + "\' "
                                      + "AND hb2Ritu1 < 100";
                        foreach (KKH.Common.KKHSchema.Detail.THB2KMEIRow row3 in jyuListdt.THB2KMEI.Select(filter2))
                        {
                            // ���{No��ݒ� 
                            result[count2] = jissiNoCnt.ToString();
                            //��No
                            jyutNo[count2] = row3.hb2JyutNo;
                            //�󒍖���No 
                            jyMeiNo[count2] = row3.hb2JyMeiNo;
                            //���㖾��No 
                            urMeiNo[count2] = row3.hb2UrMeiNo;
                            //�z���� 
                            haibun[count2] = row3.hb2Ritu1.ToString();
                            //�A�� 
                            renban[count2] = row3.hb2Renbn;
                            //�}�̃R�[�h 
                            baitaiCd[count2] = row3.hb2Code2;
                            count2++;
                            //���㖾��No�A�Ԃ�o�^���� 
                            list2.Add(row3.hb2JyutNo + row3.hb2JyMeiNo + row3.hb2UrMeiNo + row3.hb2Renbn);
                        }
                        count1 = count2;
                    }
                }
                //���㖾��No��o�^���� 
                list.Add(row.hb2JyutNo + row.hb2JyMeiNo + row.hb2UrMeiNo);
            }

            return result;
        }

        /// <summary>
        /// ���{No���X�V���� 
        /// </summary>
        /// <param name="jyuListdt">�󒍃f�[�^</param>
        /// <param name="creativeFlg">�N���G�[�e�B�u�t���O</param>
        private void SetJissiNo(KKH.Common.KKHSchema.Detail jyuListdt , bool creativeFlg)
        {
            //��No 
            String[] jyutNo = new String[jyuListdt.THB2KMEI.Rows.Count];
            //�󒍖���No 
            String[] jyMeiNo = new String[jyuListdt.THB2KMEI.Rows.Count];
            //���㖾��No 
            String[] urMeiNo = new String[jyuListdt.THB2KMEI.Rows.Count];
            //�z���� 
            String[] haibun = new String[jyuListdt.THB2KMEI.Rows.Count];
            //�A�� 
            String[] renban = new String[jyuListdt.THB2KMEI.Rows.Count];
            //�}�̃R�[�h 
            String[] baitaiCd = new String[jyuListdt.THB2KMEI.Rows.Count];
            //���{No 
            String[] jissiNo = new String[jyuListdt.THB2KMEI.Rows.Count];
            
            //�Ɩ��敪���N���G�[�e�B�u�̏ꍇ 
            if (creativeFlg)
            {
                jissiNo = CreateJissiNoCreative(jyuListdt,
                    out jyutNo, out jyMeiNo, out urMeiNo, out haibun, out renban, out baitaiCd);
            }
            //�Ɩ��敪���N���G�[�e�B�u�ȊO�̏ꍇ 
            else
            {
                jissiNo = CreateJissiNo(jyuListdt);
                int i = 0;
                foreach (KKH.Common.KKHSchema.Detail.THB2KMEIRow row in jyuListdt.THB2KMEI)
                {
                    //��No������B 
                    jyutNo[i] = row.hb2JyutNo;
                    jyMeiNo[i] = row.hb2JyMeiNo;
                    urMeiNo[i] = row.hb2UrMeiNo;
                    haibun[i] = row.hb2Ritu1.ToString();
                    renban[i] = row.hb2Renbn;
                    baitaiCd[i] = row.hb2Code2;
                    i++;
                }
            }

            //���{No�t�^�̎��s 
            DetailTkdProcessController processController = DetailTkdProcessController.GetInstance();
            UpdateJissiNoFuyoServiceResult resultUp = processController.UpdateJissiNo(
                                                                                        _naviParameter.strEsqId,
                                                                                        "00",
                                                                                         _naviParameter.strEgcd,
                                                                                         _naviParameter.strTksKgyCd,
                                                                                         _naviParameter.strTksBmnSeqNo,
                                                                                         _naviParameter.strTksTntSeqNo,
                                                                                         _naviParameter.StrYymm,
                                                                                         jyutNo,
                                                                                         jyMeiNo,
                                                                                         urMeiNo,
                                                                                         haibun,
                                                                                         renban,
                                                                                         "0",
                                                                                         baitaiCd,
                                                                                         jissiNo);
        }

        /// <summary>
        /// ���㖾��No���X�v���b�h�̌������擾����(���ɂ������@�����肻��) 
        /// </summary>
        /// <param name="urimeino"></param>
        /// <returns></returns>
        private string GetKenNm(string urimeino)
        {
            int uriCol = 0;
            int kenCol = 0;
            string kenNm = "";

            //[���㖾��No]�̗�Index���擾 
            for (int i = 0; i < _spdJyutyuList_Sheet1.ColumnCount; i++)
            {
                if (_spdJyutyuList_Sheet1.ColumnHeader.Columns[i].Label == "���㖾��NO")
                {
                    uriCol = i;
                    break;
                }
            }

            //[����]�̗�Index���擾 
            for (int i = 0; i < _spdJyutyuList_Sheet1.ColumnCount; i++)
            {
                if (_spdJyutyuList_Sheet1.ColumnHeader.Columns[i].Label == "����")
                {
                    kenCol = i;
                    break;
                }
            }

            //�������擾 
            for (int i = 0; i < _spdJyutyuList_Sheet1.RowCount; i++)
            {
                if (_spdJyutyuList_Sheet1.Cells[i, uriCol].Text == urimeino)
                {
                    kenNm = _spdJyutyuList_Sheet1.Cells[i, kenCol].Text;
                }
            }

            return kenNm;
        }

        #endregion ���\�b�h
    }
}