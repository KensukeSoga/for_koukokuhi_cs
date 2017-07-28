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
using Isid.KKH.Epson.Schema;
using Isid.KKH.Epson.ProcessController.Detail;
using Isid.KKH.Epson.Utility;
using drMasterData = Isid.KKH.Common.KKHSchema.MasterMaintenance.MasterDataVORow;

namespace Isid.KKH.Epson.View.Detail
{
    /// <summary>
    /// ���דo�^���(�G�v�\��).
    /// </summary>
    public partial class DetailEpson : DetailForm
    {
        #region �萔.
        /* 2017/04/18 �G�v�\���d����ύX�Ή� ITCOM A.Nakamura ADD Start */
        #region �Œ蕶��.
        /// <summary>
        /// �N�[����R�[�h(DataField).
        /// </summary>
        public const string DFKIHYOUBMNCD = "kihyouBmnCd";
        /// <summary>
        /// �N�[����CD(label).
        /// </summary>
        public const string LKIHYOUBMNCD = "�N�[����CD";
        /// <summary>
        /// �����Z���^(DataField).
        /// </summary>
        public const string DFGENKACENTER = "genkaCenter";
        /// <summary>
        /// �����Z���^(label).
        /// </summary>
        public const string LGENKACENTER = "�����Z���^";
        /// <summary>
        /// ��̕�����.
        /// </summary>
        public const string BLANK = "";
        #endregion �Œ蕶��.
        /* 2017/04/18 �G�v�\���d����ύX�Ή� ITCOM A.Nakamura ADD End */
        #region ���׈ꗗ�J�����C���f�b�N�X.
        /// <summary>
        /// �������ΏۊO��t���O�C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_SEIFLG = 0;
        /// <summary>
        /// �������ԍ���C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_SEINO = 1;
        /// <summary>
        /// ���㖾��NO��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_URIMEINO = 2;
        /// <summary>
        /// �L��������C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_KOUKOKUKENMEI = 3;
        /// <summary>
        /// ����S���҃R�[�h��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_TRITNTCD = 4;
        /// <summary>
        /// ������C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_KENMEI = 5;
        /// <summary>
        /// ����������C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_SEI_KENMEI = 6;
        /// <summary>
        /// ������ʖ���C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_TRISIKIKEYCD = 7;
        /* 2017/04/14 �G�v�\���d����ύX�Ή� A.Nakamura ADD Start */ 
        /// <summary>
        /// �N�[����CD��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_KIHYOUBMNCD = 8;
        /// <summary>
        /// �����Z���^��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_GENKACENTER = 9;
        /* 2017/04/14 �G�v�\���d����ύX�Ή� A.Nakamura ADD End */
        /// ���O���z��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_BFKNGK = 10;
        /// <summary>
        /// ������z��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_AFKNGK = 11;
        /// <summary>
        /// �Ɩ��敪��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_GYMKBN = 12;
        /// <summary>
        /// �����敪��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_SEIKBN = 13;
        /// <summary>
        /// ����S���Җ��̗�C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_TRITNTNM = 14;
        /// <summary>
        /// ������ʏ��R�[�h��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_TRISIKICD = 15;
        /// <summary>
        /// ������ʏ��L�[�R�[�h��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_TRISIKINM = 16;
        /// <summary>
        /// �w�}NO��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_SSNO = 17;
        /// <summary>
        /// �Z�O�����gNO��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_SEGNO = 18;
        /// <summary>
        /// �\�[�g�L�[��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_SORT_KEY = 19;
        /// <summary>
        /// ���z(�ō���)��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_SEI_KINGAKU = 20;
        /// <summary>
        /// ����ŗ�C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_ZEI_GAKU = 21;
        /// <summary>
        /// �Ŕ������z��C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_ZEI_NKINGAKU = 22;
        /// <summary>
        /// �v�����C���f�b�N�X.
        /// </summary>
        public const int COLIDX_MLIST_KEIZYOUBI = 23;
        #endregion ���׈ꗗ�J�����C���f�b�N�X.

        #region �󒍈ꗗ�w�b�_�J�����C���f�b�N�X.
        /// <summary>
        /// ���f.
        /// </summary>
        public const int COLIDX_SHLIST_HANNEI = 0;
        /// <summary>
        /// �����ԍ�.
        /// </summary>
        public const int COLIDX_SHLIST_SEIKYUNO = 1;
        /// <summary>
        /// ����.
        /// </summary>
        public const int COLIDX_SHLIST_KENMEI = 2;
        /// <summary>
        /// �������z(�ō���)���v.
        /// </summary>
        public const int COLIDX_SHLIST_SEIKINGAKUGK = 3;
        /// <summary>
        /// ����Ŋz���v.
        /// </summary>
        public const int COLIDX_SHLIST_ZEIGAKUGK = 4;
        /// <summary>
        /// �������z(�Ŕ���)���v.
        /// </summary>
        public const int COLIDX_SHLIST_ZEINKINGAKUGK = 5;
        /// <summary>
        /// �v���.
        /// </summary>
        public const int COLIDX_SHLIST_KEIYYMM = 6;
        /// <summary>
        /// �����X�e�[�^�X.
        /// </summary>
        public const int COLIDX_SHLIST_SEISTATUS = 7;
        #endregion �󒍈ꗗ�w�b�_�J�����C���f�b�N�X.

        #region �󒍈ꗗ�J�����C���f�b�N�X.
        /// <summary>
        /// ���f.
        /// </summary>
        public const int COLIDX_SCLIST_HANNEI = 0;
        /// <summary>
        /// �����ԍ�.
        /// </summary>
        public const int COLIDX_SCLIST_SEIKYUNO = 1;
        /// <summary>
        /// �������הԍ�.
        /// </summary>
        public const int COLIDX_SCLIST_SEIKYUMEINO = 2;
        /// <summary>
        /// ���㖾�הԍ�.
        /// </summary>
        public const int COLIDX_SCLIST_URIMEINO = 3;
        /// <summary>
        /// ����.
        /// </summary>
        public const int COLIDX_SCLIST_KENMEI = 4;
        /// <summary>
        /// �������z(�ō���)���v.
        /// </summary>
        public const int COLIDX_SCLIST_SEIKINGAKUGK = 5;
        /// <summary>
        /// ����Ŋz���v.
        /// </summary>
        public const int COLIDX_SCLIST_ZEIGAKUGK = 6;
        /// <summary>
        /// �������z(�Ŕ���)���v.
        /// </summary>
        public const int COLIDX_SCLIST_ZEINKINGAKUGK = 7;
        /////<summary>
        /// �������z(�ō���).
        /// </summary>
        public const int COLIDX_SCLIST_SEIKINGAKU = 8;
        /// <summary>
        /// ����Ŋz.
        /// </summary>
        public const int COLIDX_SCLIST_ZEIGAKU = 9;
        /// <summary>
        /// �������z(�Ŕ���).
        /// </summary>
        public const int COLIDX_SCLIST_ZEINKINGAKU = 10;
        /// <summary>
        /// �v���.
        /// </summary>
        public const int COLIDX_SCLIST_KEIYYMM = 11;
        /// <summary>
        /// �����X�e�[�^�X.
        /// </summary>
        public const int COLIDX_SCLIST_SEISTATUS = 12;
        #endregion �󒍈ꗗ�J�����C���f�b�N�X.

        #region ���z�l.
        /// <summary>
        /// ���׃X�v���b�h_���z�̍ő�l.
        /// </summary>
        private const double MAX_VALUE_KINGAKU = 99999999999D;
        /// <summary>
        /// ���׃X�v���b�h_���z�̍ŏ��l.
        /// </summary>
        private const double MIN_VALUE_KINGAKU = -99999999999D;
        /// <summary>
        /// ���׃X�v���b�h_���z�̃f�t�H���g�l.
        /// </summary>
        private const string DEF_VALUE_KINGAKU = "0";
        #endregion ���z�l.
        #endregion �萔.

        #region �����o�ϐ�.
        /// <summary>
        /// ��ʌďo����.
        /// </summary>
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();
        /// <summary>
        /// ������ʏ��R���{�{�b�N�X�L�[.
        /// </summary>
        private string[] _triSikiKey = null;
        /// <summary>
        /// ������ʏ��R���{�{�b�N�X�l.
        /// </summary>
        private string[] _triSikiValue = null;
        /// <summary>
        /// ����S���҃R���{�{�b�N�X���L�[.
        /// </summary>
        private string[] _triTntKey = null;
        /// <summary>
        /// ����S���҃R���{�{�b�N�X���l.
        /// </summary>
        private string[] _triTntValue = null;
        /* 2017/04/14 �G�v�\���d����ύX�Ή� ITCOM A.Nakamura ADD Start */ 
        /// <summary>
        /// �N�[����CD�R���{�{�b�N�X���L�[.
        /// </summary>
        private string[] _kihyouBmnCdKey = null;
        /// <summary>
        /// �N�[����CD�R���{�{�b�N�X���l.
        /// </summary>
        private string[] _kihyouBmnCdValue = null;
         /// <summary>
        /// �����Z���^�R���{�{�b�N�X���L�[.
        /// </summary>
        private string[] _genkaCenterKey = null;
        /// <summary>
        /// �����Z���^�R���{�{�b�N�X���l.
        /// </summary>
        private string[] _genkaCenterValue = null;
        /* 2017/04/14 �G�v�\���d����ύX�Ή� ITCOM A.Nakamura ADD End */
        /// <summary>
        /// �}�X�^���[�e�B���e�B.
        /// </summary>
        KkhMasterUtilityEpson _master;
        /// <summary>
        /// �����G���R�[�f�B���O.
        /// </summary>
        private Encoding _enc = Encoding.GetEncoding("shift-jis");
        /// <summary>
        /// �ύX�O�̃^�u�C���f�b�N�X.
        /// </summary>
        private int _previousTabIndex = 0;
        /// <summary>
        /// �^�u�ύX���̌����������X�e�[�^�X.
        /// </summary>
        private Boolean _notSearchState = false;
        /// <summary>
        /// ��������f�[�^�������s���̐ݒ������ێ�.
        /// </summary>
        private DetailEpsonProcessController.FindSeikyuKaisyuDataByCondParam findSeikyuKaisyuDataCond = new DetailEpsonProcessController.FindSeikyuKaisyuDataByCondParam();
        /// <summary>
        // ����̐�������f�[�^�̐����ԍ��i�[�p.
        /// </summary>
        private List<string> seiNoList = new List<string>();
        #endregion �����o�ϐ�.

        #region �R���X�g���N�^.
        /// <summary>
        /// �R���X�g���N�^.
        /// </summary>
        public DetailEpson()
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
            //�󒍓o�^���e(�ꗗ)�X�v���b�h�̃X�v���b�h�A�V�[�g�̐ݒ���s��.
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

            //�󒍈ꗗ�J�����������[�v����.
            foreach (Column col in base._spdJyutyuList_Sheet1.Columns)
            {
                if (col.Index == COLIDX_JLIST_TOROKU        ) { col.Visible = true;  }  //�o�^.
                if (col.Index == COLIDX_JLIST_TOGO          ) { col.Visible = false; }  //����.  
                if (col.Index == COLIDX_JLIST_DAIUKE        ) { col.Visible = true;  }  //���.
                if (col.Index == COLIDX_JLIST_SEIKYU        ) { col.Visible = false; }  //����.
                if (col.Index == COLIDX_JLIST_URIMEINO      ) { col.Visible = true;  }  //���㖾��NO.
                if (col.Index == COLIDX_JLIST_GPYNO         ) { col.Visible = false; }  //�������[NO.
                if (col.Index == COLIDX_JLIST_SEIYYMM       ) { col.Visible = true;  }  //�����N��.
                if (col.Index == COLIDX_JLIST_GYOMKBN       ) { col.Visible = true;  }  //�Ɩ��敪.
                if (col.Index == COLIDX_JLIST_KENMEI        ) { col.Visible = true;  }  //����.
                if (col.Index == COLIDX_JLIST_BAITAINM      ) { col.Visible = false; }  //�}�̖�.
                if (col.Index == COLIDX_JLIST_HIMOKUNM      ) { col.Visible = true;  }  //��ږ�.
                if (col.Index == COLIDX_JLIST_KYOKUSHICD    ) { col.Visible = false; }  //�ǎ�CD.
                if (col.Index == COLIDX_JLIST_SEIKINGAKU    ) { col.Visible = true;  }  //�������z.
                if (col.Index == COLIDX_JLIST_KIKAN         ) { col.Visible = false; }  //����.
                if (col.Index == COLIDX_JLIST_DANTANKA      ) { col.Visible = false; }  //�i�P��.
                if (col.Index == COLIDX_JLIST_DANSU         ) { col.Visible = false; }  //�i��.
                if (col.Index == COLIDX_JLIST_TORIRYOKIN    ) { col.Visible = true;  }  //�旿��.
                if (col.Index == COLIDX_JLIST_NEBIKIRITSU   ) { col.Visible = true;  }  //�l����.
                if (col.Index == COLIDX_JLIST_NEBIKIGAKU    ) { col.Visible = true;  }  //�l���z.
                if (col.Index == COLIDX_JLIST_ZEIRITSU      ) { col.Visible = true;  }  //����ŗ�.
                if (col.Index == COLIDX_JLIST_ZEIGAKU       ) { col.Visible = true;  }  //����Ŋz.
                if (col.Index == COLIDX_JLIST_GOUKEIKINGAKU ) { col.Visible = false; }  //�󒍐������z.
                if (col.Index == COLIDX_JLIST_OLDSEIYYMM    ) { col.Visible = true;  }  //�ύX�O�����N��.
            }
        }
        #endregion ���Ӑ�ʂɕ\���ΏۊO��̔�\���������s��.

        #region �Z���̐F�t���������s��.
        /// <summary>
        /// �Z���̐F�t���������s��.
        /// </summary>
        protected override void ChangeColor()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s.
            base.ChangeColor();

            //�󒍃f�[�^���������[�v����.
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
        #endregion �Z���̐F�t���������s��.

        #region �L����׃f�[�^�̌����E�\��.
        /// <summary>
        /// �L����׃f�[�^�̌����E�\��. 
        /// </summary>
        /// <param name="rowIdx"></param>
        protected override void DisplayKkhDetail(int rowIdx)
        {
        }
        #endregion �L����׃f�[�^�̌����E�\��.

        #region �󒍓o�^���e(�ꗗ)�X�v���b�h�̃Z���ړ�.
        /// <summary>
        /// �󒍓o�^���e(�ꗗ)�X�v���b�h�̃Z���ړ�.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void _spdJyutyuList_LeaveCell(object sender, LeaveCellEventArgs e)
        {
        }
        #endregion �󒍓o�^���e(�ꗗ)�X�v���b�h�̃Z���ړ�.

        #region �󒍓o�^���e�����O�`�F�b�N����.
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
        #endregion �󒍓o�^���e�����O�`�F�b�N����.

        #region �󒍓o�^���e�����O�N���A����.
        /// <summary>
        /// �󒍓o�^���e�����O�N���A����.
        /// </summary>
        protected override void InitializeBeforeSearch()
        {
            // �e�̏����Ń^�u���ύX����邽�ߖ��וύX�t���O���N���A.
            kkhDetailUpdFlag = false;

            // �^�u���u�ꗗ�v�ɕύX����邽�߁A���̍ۂ̌��������𖳌���.
            _notSearchState = true;

            //�e�N���X�̍s���Ă��鋤�ʏ��������s. 
            base.InitializeBeforeSearch();

            // �^�u�ύX���̌�����L����.
            _notSearchState = false;

            //���z�E�v���x��.
            lblJyutyuDownValue.Text = "";
            lblJyutyuDownValue2.Text = "";
            lblJyutyuMeisaiValue.Text = "";
            lblSeikyuDownValue.Text = "";
            lblSeikyuDownValue2.Text = "";
            lblSeikyuMeisaiValue.Text = "";

            //***************************************
            //�{�^���ނ̎g�p�E�s�ݒ�. 
            //***************************************
            btnRegister.Enabled = false;
            btnRegBulk.Enabled = false;
            btnReqBind.Enabled = false;
            btnBulkMerge.Enabled = false;
            btnMerge.Enabled = false;
            btnMergeCancel.Enabled = false;
            btnDetailInput.Enabled = false;
            btnDetailDel.Enabled = false;
            btnDetailRegister.Enabled = false;
        }
        #endregion �󒍓o�^���e�����O�N���A����.

        #region �󒍓o�^���e������`�F�b�N����.
        /// <summary>
        /// �󒍓o�^���e������`�F�b�N����.
        /// </summary>
        /// <returns></returns>
        protected override Boolean CheckAfterSearch()
        {
            return true;
        }
        #endregion �󒍓o�^���e������`�F�b�N����.

        #region �󒍓o�^���e�����㏉���\������.
        /// <summary>
        /// �󒍓o�^���e�����㏉���\������.
        /// </summary>
        protected override void InitializeAfterSearch()
        {
            //�e�N���X�̍s���Ă��鋤�ʏ��������s.
            base.InitializeAfterSearch();
        }
        #endregion �󒍓o�^���e�����㏉���\������.

        #region �󒍍폜�������s�O�`�F�b�N.
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
        #endregion �󒍍폜�������s�O�`�F�b�N.

        #region �󒍍폜��̏���������.
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
                //�{�^���̎g�p�s�� 
                btnDetailInput.Enabled = false;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = false;

                //���v.
                lblJyutyuMeisaiValue.Text = "0";
                lblJyutyuDownValue.Text = "0";
                lblSeikyuMeisaiValue.Text = "0";

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
            if (base.CheckBeforeYmChange() == false)
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
            base.MouseMoveCommon(sender, e);
        }
        #endregion MouseMove�C�x���g.

        #region MouseLeave�C�x���g.
        /// <summary>
        /// MouseLeave�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MouseLeaveCommon(object sender, EventArgs e)
        {
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
            base.EnableChangeForSelectJyutyuListRow(activeSheet, activeRow);

            //�󒍓o�^����(�e)�V�[�g�ȊO���A�N�e�B�u�̏ꍇ. 
            if (activeSheet != _spdJyutyuList_Sheet1)
            {
                //���׊֌W�̃{�^���g�p�s�� 
                btnDetailInput.Enabled = false;
                btnDetailDel.Enabled = false;
                btnDetailRegister.Enabled = false;
            }
        }
        #endregion �󒍓o�^���e(�ꗗ)�Ńt�H�[�J�X������r���[�ɂ���ăR���g���[���̐�����s��.

        #region �󒍓o�^���e�����E�\������.
        /// <summary>
        /// �󒍓o�^���e�����E�\������.
        /// </summary>
        /// <param name="reLoadFlag">�Č����t���O(True�F�Č����AFalse�F�ʏ팟��)</param>
        protected override Boolean SearchJyutyuData(bool reLoadFlag)
        {
            // �p�����ŏ����𒆒f�����ꍇ�͓��l�ɒ��f����.
            if (base.SearchJyutyuData(reLoadFlag))
            {
                return true;
            }

            // �G�v�\���͑S�󒍂̖��ׂ���ɕ\�����邽�ߖ��ׂ̌��������s.
            this.DisplayDetail();

            return false;
        }
        #endregion �󒍓o�^���e�����E�\������.

        #region �ύX�E�폜�`�F�b�N.
        /// <summary>
        /// �ύX�E�폜�`�F�b�N.
        /// </summary>
        protected override Boolean CheckUpdate()
        {
            // �p�����ŏ����𒆒f�����ꍇ�͓��l�ɒ��f����.
            if (base.CheckUpdate())
            {
                return true;
            }

            // �G�v�\���͑S�󒍂̖��ׂ���ɕ\�����邽�ߖ��ׂ̌��������s.
            this.DisplayDetail();

            return false;
        }
        #endregion �ύX�E�폜�`�F�b�N.

        #region �󒍓����{�^���N���b�N����.
        /// <summary>
        ///  �󒍓����{�^���N���b�N����.
        /// </summary>
        protected override void MergeClick()
        {
            //�I���s�̎擾 .
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
        #endregion �󒍓����{�^���N���b�N����.

        #region �󒍃`�F�b�N.
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

            // �I�y���[�V�������O�̏o�� 
            KKHLogUtilityEpson.WriteOperationLogToDB(_naviParameter, KKHSystemConst.ApplicationID.APLID_DTL_EPSON, KKHLogUtilityEpson.KINO_ID_OPERATION_LOG_UPDCHECK, KKHLogUtilityEpson.DESC_OPERATION_LOG_UPDCHECK);

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
        private void DetailEpson_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            if (arg.NaviParameter == null)
            {
                return;
            }
            // �i�r�p�����.
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
        private void DetailEpson_Shown(object sender, EventArgs e)
        {
            ShowLoadingDialog();

            InitializeCommonProperty();
            InitializeDataSourceEpson();
            InitializeControlEpson();
            InitializeDesignForSpdKkhDetail();

            _previousTabIndex = tabHed.SelectedIndex;

            CloseLoadingDialog();
        }
        #endregion �t�H�[�����[�h�C�x���g.

        #region �����{�^������.
        /// <summary>
        /// �����{�^������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSch_Click(object sender, EventArgs e)
        {
            if (ConfirmEditState)
            {
                // ��������f�[�^�̌���.
                SearchSeikyuKaisyuData();

                // �I����Ԃ����� 
                this.ActiveControl = null;

                // �{�^���̗L��������ύX.
                SetButtonEnable();

                // �f�[�^���N���A�������ߖ��וύX�t���O���I�t�ɂ���.
                kkhDetailUpdFlag = false;

                // �G���[�`�F�b�N.
                if (( _dsDetail.JyutyuList.Count == 0 ) && ( _dsSeikyuEpson.SeikyuHeader.Count == 0 ))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "���̓G���[", MessageBoxButtons.OK);
                    txtYmd.Focus();
                    return;
                }

                if (_dsSeikyuEpson.SeikyuHeader.Rows.Count != 0)
                {
                    // �^�u�ύX���̌����𖳌���.
                    _notSearchState = true;

                    // ��������f�[�^������ꍇ�͎����ł�������J��.
                    tabHed.SelectedIndex = 2;

                    // ��������̖��ׂ̕����F�ύX.
                    for (int i = 0; i < _spdKkhDetail_Sheet1.Rows.Count; i++)
                    {
                        // ����ɂȂ��Ă��鐿������f�[�^�̖��ׂ̏ꍇ�͔w�i�F�ύX.
                        if (seiNoList.Contains(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_SEINO].Text))
                        {
                            // �����X�e�[�^�X��3(���)�̖��ׂ̏ꍇ�͔w�i�F��ύX. 
                            _spdKkhDetail_Sheet1.Rows[i].BackColor = Color.FromArgb(165, 165, 165);
                        }
                    }

                    // �^�u�ύX���̌�����L����.
                    _notSearchState = false;
                }
            }
        }
        #endregion �����{�^������.

        #region �ʓo�^.
        /// <summary>
        /// �ʓo�^.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            String mode = String.Empty;

            if (isActivatedJyutyuList())
            {
                // �L����p����.
                if (!SetDetailData(_spdJyutyuList_Sheet1.ActiveRowIndex))
                {
                    // ���b�Z�[�W�{�b�N�X.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0090, null, "���דo�^", MessageBoxButtons.OK);
                }
            }
            else if (isActivatedSeikyuList())
            {
                if (!SetSeikyuDetailData(_spdSeikyuList_Sheet1.ActiveRowIndex, out mode))
                {
                    if(mode.Equals("FIN"))
                    {
                        // ���b�Z�[�W�{�b�N�X.
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new String[] { "�����������ԍ��������ׂ����ɑ��݂��Ă��܂��B" }, "���דo�^", MessageBoxButtons.OK);
                    }
                    else if (mode.Equals("DEL"))
                    {
                        // ���b�Z�[�W�{�b�N�X.
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new String[] { "������ꂽ��������f�[�^�ł��B" }, "���דo�^", MessageBoxButtons.OK);
                    }
                }
            }

            // �{�^���̗L��������ύX.
            SetButtonEnable();

            //�I����Ԃ�����. 
            this.ActiveControl = null;
        }
        #endregion �ʓo�^.

        #region �ꊇ�o�^�{�^���N���b�N.
        /// <summary>
        /// �ꊇ�o�^�{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBulkRegister_Click(object sender, EventArgs e)
        {
            int detailAdditionCount = 0;

            for (int i = 0; i < _spdJyutyuList_Sheet1.RowCount; i++)
            {
                if (SetDetailData(i))
                {
                    // ���גǉ��������J�E���g�A�b�v.
                    detailAdditionCount++;
                }
            }

            if (detailAdditionCount == 0)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "���דo�^", MessageBoxButtons.OK);

                //�I����Ԃ�����. 
                this.ActiveControl = null;

                return;
            }

            //******************************
            // ���v���x��. 
            //******************************
            CalculateGoukei();

            //***************************************
            // �{�^���ނ̎g�p�E�s�ݒ�. 
            //***************************************
            SetButtonEnable();

            //�I����Ԃ�����. 
            this.ActiveControl = null;
        }
        #endregion �ꊇ�o�^�{�^���N���b�N.

        #region ��������f�[�^���f����.
        /// <summary>
        /// ��������f�[�^���f����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReqBind_Click(object sender, EventArgs e)
        {
            int detailAdditionCount = 0;
            String mode = String.Empty;

            for (int i = 0; i < _spdSeikyuList_Sheet1.RowCount; i++)
            {
                if (SetSeikyuDetailData(i,out mode))
                {
                    // ���גǉ��������J�E���g�A�b�v.
                    detailAdditionCount++;
                }
            }

            if (detailAdditionCount == 0)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "���דo�^", MessageBoxButtons.OK);

                //�I����Ԃ�����. 
                this.ActiveControl = null;

                return;
            }

            //******************************
            // ���v���x��. 
            //******************************
            CalculateGoukei();

            //***************************************
            // �{�^���ނ̎g�p�E�s�ݒ� .
            //***************************************
            SetButtonEnable();

            //�I����Ԃ�����. 
            this.ActiveControl = null;
        }
        #endregion ��������f�[�^���f����.

        #region �ꊇ�����{�^���N���b�N.
        /// <summary>
        /// �ꊇ�����{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBulkMerge_Click(object sender, EventArgs e)
        {
            //***********************************************************
            //�������s�O�`�F�b�N�E�Ώۃf�[�^�擾 .
            //***********************************************************
            //*************************
            //�L����ׂ̕ҏW�󋵊m�F. 
            //*************************
            if (ConfirmEditStatus() == false)
            {

                //�I����Ԃ�����. 
                this.ActiveControl = null;

                return;
            }

            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();
            List<Isid.KKH.Common.KKHProcessController.Detail.DetailProcessController.MergeJyutyuDataParam> mergeJyutyuDataParamList
                = new List<Isid.KKH.Common.KKHProcessController.Detail.DetailProcessController.MergeJyutyuDataParam>();

            //�A�N�e�B�u�s�̎擾. 
            int activeRowIdx = _spdJyutyuList_Sheet1.ActiveRowIndex;

            DataTable dtJyutNo = _dsDetail.JyutyuData.DefaultView.ToTable(true, dsDetail.THB1DOWN.hb1JyutNoColumn.ColumnName);
            for (int i = 0; i < dtJyutNo.Rows.Count; i++)
            {
                //�����Ώۍs�f�[�^�̎擾. 
                string filterEx = dsDetail.THB1DOWN.hb1JyutNoColumn.ColumnName + "='" + dtJyutNo.Rows[i].ItemArray[0].ToString() + "'";
                filterEx = filterEx + " AND " + dsDetail.THB1DOWN.hb1TJyutNoColumn.ColumnName + "=''";
                string sortKey = dsDetail.THB1DOWN.hb1JyutNoColumn.ColumnName + "," + dsDetail.THB1DOWN.hb1JyMeiNoColumn.ColumnName + "," + dsDetail.THB1DOWN.hb1UrMeiNoColumn.ColumnName;
                Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] targetRows = (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[])_dsDetail.JyutyuData.Select(filterEx, sortKey);

                Isid.KKH.Common.KKHSchema.Detail targetDsDetail = new Isid.KKH.Common.KKHSchema.Detail();
                Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable targetDt = targetDsDetail.JyutyuData;

                foreach (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow targetRow in targetRows)
                {
                    targetDt.ImportRow(targetRow);

                    //�I������Ă���󒍓o�^���e�̍s�����̏������J��Ԃ�. 
                    if (targetRow.hb1TouFlg == "1")
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0015, null, "���דo�^", MessageBoxButtons.OK);

                        //�I����Ԃ�����. 
                        this.ActiveControl = null;

                        return;
                    }

                    Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow addRow = dsDetail.JyutyuData.NewJyutyuDataRow();
                    addRow.ItemArray = (object[])targetRow.ItemArray;

                    dsDetail.JyutyuData.AddJyutyuDataRow(addRow);
                }
                //�󒍓����f�[�^�̒ǉ�.
                AddJyutyuDataMergeVO(mergeJyutyuDataParamList, targetDt, targetRows[0].rowNum);
            }

            //***********************************************************
            //�����������s.
            //***********************************************************
            if (MergeBulkJyutyuDataEpson(mergeJyutyuDataParamList) == false)
            {
                //�I����Ԃ�����. 
                this.ActiveControl = null;

                return;
            }

            //*************************************
            //�Č����E�\��.
            //*************************************
            //���s���ʂ�����ȏꍇ�A�󒍓���������̍ĕ\���������s��. 
            ReSearchJyutyuData();
            if (_spdJyutyuList_Sheet1.RowCount >= activeRowIdx + 1)
            {
                _spdJyutyuList_Sheet1.SetActiveCell(activeRowIdx, 0, true);
                _spdJyutyuList_Sheet1.AddSelection(activeRowIdx, -1, 1, -1);
            }

            MessageUtility.ShowMessageBox(MessageCode.HB_I0009, null, "���דo�^", MessageBoxButtons.OK);

            //�I����Ԃ����� 
            this.ActiveControl = null;

        }
        #endregion �ꊇ�����{�^���N���b�N.

        #region �󒍓����f�[�^�̒ǉ�.
        /// <summary>
        /// �󒍓����f�[�^�̒ǉ�.
        /// </summary>
        /// <param name="dtJyutyuData">�����ΏۂƂȂ�󒍃f�[�^(JyutyuData)</param>
        /// <param name="tousakiRownum">������ƂȂ�󒍃f�[�^(JyutyuData)��RowNum</param>
        /// <returns></returns>
        protected void AddJyutyuDataMergeVO(List<Isid.KKH.Common.KKHProcessController.Detail.DetailProcessController.MergeJyutyuDataParam> mergeJyutyuDataParamList,Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable dtJyutyuData, int tousakiRownum)
        {
            DetailProcessController.MergeJyutyuDataParam param = CreateServiceParamForMergeJyutyuData(dtJyutyuData, tousakiRownum);
            mergeJyutyuDataParamList.Add(param);
        }
        #endregion �󒍓����f�[�^�̒ǉ�.

        #region �ꊇ����API�̎��s.
        /// <summary>
        /// �ꊇ����API�̎��s.
        /// </summary>
        /// <param name="mergeJyutyuDataParamList">�󒍓����p�����[�^���X�g</param>
        /// <returns></returns>
        protected bool MergeBulkJyutyuDataEpson(List<Isid.KKH.Common.KKHProcessController.Detail.DetailProcessController.MergeJyutyuDataParam> mergeJyutyuDataParamList)
        {
            DetailEpsonProcessController.MergeBulkJyutyuDataEpsonParam param = new Isid.KKH.Epson.ProcessController.Detail.DetailEpsonProcessController.MergeBulkJyutyuDataEpsonParam();
            param.mergeJyutyuDataParamList = mergeJyutyuDataParamList;
            DetailEpsonProcessController processController = DetailEpsonProcessController.GetInstance();
            MergeBulkJyutyuDataEpsonServiceResult result = processController.MergeBulkJyutyuDataEpson(param);
            if (result.HasError == true)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_E0006, null, "���דo�^", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
        #endregion �ꊇ����API�̎��s.

        #region ���ד��̓{�^���N���b�N.
        /// <summary>
        /// ���ד��̓{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailInput_Click(object sender, EventArgs e)
        {
            // ���ד��͉�ʕ\�� 
            //�p�����[�^�Z�b�g.
            DetailInputEpsonNaviParameter naviParam = new DetailInputEpsonNaviParameter();

            //��{���.
            naviParam.AplId = _naviParameter.AplId;
            naviParam.strEsqId = _naviParameter.strEsqId;
            naviParam.strEgcd = _naviParameter.strEgcd;
            naviParam.strTksKgyCd = _naviParameter.strTksKgyCd;
            naviParam.strTksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            naviParam.strTksTntSeqNo = _naviParameter.strTksTntSeqNo;

            if(isActivatedJyutyuList())
            {
                naviParam.Kbn = "1";
            }
            else if(isActivatedSeikyuList())
            {
                naviParam.Kbn = "2";
            }
            naviParam.RowDetailIndex = _spdKkhDetail_Sheet1.ActiveRowIndex;

            //naviParam.RowDetailIndex = rowDetailIndex;
            naviParam.SpdKkhDetail_Sheet1 = _spdKkhDetail_Sheet1;

            object result = Navigator.ShowModalForm(this, "toDetailInputEpson", naviParam);
            if (result == null)
            {
                this.ActiveControl = null;
                return;
            }
            base.kkhDetailUpdFlag = true; //�L����וύX�t���O���X�V 

            DetailInputEpsonNaviParameter naviParamOut = (DetailInputEpsonNaviParameter)result;
            _spdKkhDetail_Sheet1 = naviParamOut.SpdKkhDetail_Sheet1;

            // ���v�v�Z 
            CalculateGoukei();
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
            //�o�^�m�F�_�C�A���O��[������]��I�������ꍇ.
            if (DialogResult.Yes != MessageUtility.ShowMessageBox(MessageCode.HB_C0002, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.YesNo))
            {
                //�I����Ԃ�����.
                this.ActiveControl = null;
                return;
            }

            //��������p���ׂ̏ꍇ�̂݃`�F�b�N����.
            if (isActivatedSeikyuList())
            {
                /* 2015/04/06 �G�v�\�������g���Ή� HLC K.Fujisaki ADD Start */
                {
                    //�����̌����`�F�b�N.
                    if (!CheckByteLength(COLIDX_MLIST_SEI_KENMEI))
                    {
                        return;
                    }
                }
                /* 2015/04/06 �G�v�\�������g���Ή� HLC K.Fujisaki ADD End */
                {
                    //�v����x���t�H�[�}�b�g�`�F�b�N.
                    Boolean state = false;

                    //���׌��������[�v�������s��.
                    for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
                    {
                        //�v����̎擾.
                        String keizyoBi = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEIZYOUBI].Text;

                        //�v�������łȂ��ꍇ.
                        if (String.IsNullOrEmpty(keizyoBi))
                        {
                            //�x�����o�͂��邽�߁A�ʓr�`�F�b�N.
                            continue;
                        }

                        //�v����̌`���ϊ�.
                        if (KKHUtility.IsDate(keizyoBi, KKHSystemConst.Format.YEAR_MONTH_DAY_FORMAT))
                        {
                            //�������`�ł���Ζ��Ȃ�.
                            continue;
                        }

                        //�N���`������Ȃ��̂ŃG���[.
                        state = true;
                        break;
                    }

                    //�v����x���t�H�[�}�b�g�`�F�b�N�Ŗ�肠��̏ꍇ.
                    if (state)
                    {
                        //�x�����b�Z�[�W���o��.
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0169, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                        return;
                    }
                }
                {
                    //������ʌx��.
                    Boolean state = false;

                    //���׌��������[�v����.
                    for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
                    {
                        /* 2017/04/24 �G�v�\���d������ύX�Ή� HLC K.Soga MOD Start */
                        ////������ʃL�[�R�[�h�̎擾.
                        //String strTriSikiKeyCd = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TRISIKIKEYCD].Text;
                        //if (!String.IsNullOrEmpty(strTriSikiKeyCd))
                        //{
                        //    //���Ȃ�.
                        //    continue;
                        //}

                        //������ʃL�[�R�[�h�A�N�[����CD�A����ь����Z���^����łȂ��ꍇ.
                        if (!String.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_TRISIKIKEYCD].Text)
                            && !String.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KIHYOUBMNCD].Text) 
                            && !String.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_GENKACENTER].Text))
                        {
                            //���Ȃ�.
                            continue;
                        }
                        /* 2017/04/24 �G�v�\���d������ύX�Ή� HLC K.Soga MOD End */

                        //��̏ꍇ�͂܂Ƃ߂Čx����\������.
                        state = true;
                    }

                    //������ʃL�[�R�[�h�A�N�[����CD�A�܂��͌����Z���^����̏ꍇ.
                    if (state)
                    {
                        /* 2017/04/24 �G�v�\���d������ύX�Ή� HLC K.Soga MOD Start */
                        //DialogResult result = MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new String[] { "������ʏ�񂪓��͂���Ă��܂���B\n���̂܂ܓo�^���s���܂����H" }, "���דo�^", MessageBoxButtons.YesNo);
                        //�x�����b�Z�[�W���o��.
                        DialogResult result = MessageUtility.ShowMessageBox(MessageCode.HB_W0170, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.YesNo);
                        /* 2017/04/24 �G�v�\���d������ύX�Ή� HLC K.Soga MOD End */

                        //�x�����b�Z�[�W��[������]��I�������ꍇ.
                        if (result == DialogResult.No)
                        {
                            //�������~.
                            return;
                        }
                    }
                }

                {
                    //�v����x��.
                    Boolean state = false;

                    //���׌��������[�v����.
                    for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
                    {
                        //�v������擾.
                        String keizyoBi = _spdKkhDetail_Sheet1.Cells[i, COLIDX_MLIST_KEIZYOUBI].Text;

                        //�v�������łȂ��ꍇ.
                        if (!String.IsNullOrEmpty(keizyoBi))
                        {
                            //���Ȃ�.
                            continue;
                        }

                        //��̏ꍇ�͂܂Ƃ߂Čx����\������.
                        state = true;
                    }

                    //�v����x���ɖ�肠��̏ꍇ.
                    if (state)
                    {
                        //�x�����b�Z�[�W���o��.
                        DialogResult result = MessageUtility.ShowMessageBox(MessageCode.HB_W0171, null, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.YesNo);

                        //�x�����b�Z�[�W��[������]��I�������ꍇ.
                        if (result == DialogResult.No)
                        {
                            //�������~.
                            return;
                        }
                    }
                }
            }
            /* 2015/04/06 �G�v�\�������g���Ή� HLC K.Fujisaki ADD Start */
            // �󒍃��X�g�̏ꍇ�̂݃`�F�b�N���� 
            else if (isActivatedJyutyuList())
            {
                // �����̌����`�F�b�N.
                if (!CheckByteLength(COLIDX_MLIST_SEI_KENMEI))
                {
                    return;
                }
            }
            /* 2015/04/06 �G�v�\�������g���Ή� HLC K.Fujisaki ADD End */

            //���דo�^����.
            RegistDetailData();

            //�I����Ԃ����� 
            this.ActiveControl = null;
        }
        #endregion ���דo�^�{�^���N���b�N�C�x���g.

        #region ���׍폜�{�^���N���b�N.
        /// <summary>
        /// ���׍폜�{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailDel_Click(object sender, EventArgs e)
        {
            if (MessageUtility.ShowMessageBox(MessageCode.HB_C0009, null, "���דo�^", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                //�I����Ԃ����� 
                this.ActiveControl = null;

                return;
            }

            //�t�B���^�ɂ���ĕ\������Ă��Ȃ��s�����݂���ꍇ�͍폜�s��.
            ArrayList filteroutlist = _spdKkhDetail_Sheet1.RowFilter.GetFilteredOutRowList();

            if (!filteroutlist.Count.Equals(0))
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0158, null, "���דo�^", MessageBoxButtons.OK);
                return;
            }
          

            ArrayList rowNum = new ArrayList();

            //�I���s�̎擾 
            CellRange[] cellRanges = SortCellRangesByRowIdx(_spdKkhDetail_Sheet1.GetSelections());
            foreach (CellRange cellRange in cellRanges)
            {
                for (int i = 0; i < cellRange.RowCount; i++)
                {
                    //�I������Ă��閾�ׂ̍s�����̏������J��Ԃ� 
                    int rowIndex = cellRange.Row + i;

                    //�s��Arraylist�ɐݒ�.
                    if (isActivatedJyutyuList())
                    {
                        rowNum.Add(_spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_URIMEINO].Text);
                    }
                    else if (isActivatedSeikyuList())
                    {
                        rowNum.Add(_spdKkhDetail_Sheet1.Cells[rowIndex, COLIDX_MLIST_SEINO].Text);
                    }
                }
            }
            
            //�s�̍폜���f�[�^�ɔ��f.
            if (isActivatedJyutyuList())
            {
                for (int i = 0; i < rowNum.Count; i++)
                {
                    DetailDSEpson.KkhDetailRow[] rows = (DetailDSEpson.KkhDetailRow[])_dsDetailEpson.KkhDetail.Select("uriMeiNo = '" + rowNum[i].ToString() + "'", "");

                    if (rows.Length != 0)
                    {
                        _dsDetailEpson.KkhDetail.RemoveKkhDetailRow(rows[0]);
                        _dsDetailEpson.KkhDetail.AcceptChanges();

                        _bsKkhDetail.DataSource = _dsDetailEpson;
                        _bsKkhDetail.DataMember = _dsDetailEpson.KkhDetail.TableName;
                        _bsKkhDetail.EndEdit();

                        _dsDetailEpson.KkhDetail.AcceptChanges();
                    }
                }
            }
            else if (isActivatedSeikyuList())
            {
                for (int i = 0; i < rowNum.Count; i++)
                {
                    DetailDSEpson.KkhDetailRow[] rows = (DetailDSEpson.KkhDetailRow[])_dsSeikyuDetailEpson.KkhDetail.Select("seiNo = '" + rowNum[i].ToString() + "'", "");

                    if (rows.Length != 0)
                    {
                        _dsSeikyuDetailEpson.KkhDetail.RemoveKkhDetailRow(rows[0]);
                        _dsSeikyuDetailEpson.KkhDetail.AcceptChanges();

                        _bsKkhDetail.DataSource = _dsSeikyuDetailEpson;
                        _bsKkhDetail.DataMember = _dsSeikyuDetailEpson.KkhDetail.TableName;
                        _bsKkhDetail.EndEdit();

                        _dsSeikyuDetailEpson.KkhDetail.AcceptChanges();
                    }
                }
            }


            // �{�^���̗L���������X�V.
            SetButtonEnable();

            //�L����וύX�t���O���X�V.
            base.kkhDetailUpdFlag = true;

            //******************************
            //���z�E�v���x�� 
            //******************************

            //���v�v�Z 
            CalculateGoukei();

            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(_spdKkhDetail_Sheet1.ActiveRowIndex, -1, 1, -1);
            }

            //�I����Ԃ����� 
            this.ActiveControl = null;
        }
        #endregion ���׍폜�{�^���N���b�N.

        #region ���׃X�v���b�h���̃Z���Ńe�L�X�g��ύX����Ƃ��ɔ������܂�.
        /// <summary>
        /// ���׃X�v���b�h���̃Z���Ńe�L�X�g��ύX����Ƃ��ɔ������܂�.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_EditChange(object sender, EditorNotifyEventArgs e)
        {
            FarPoint.Win.FpCombo editCombo = new FarPoint.Win.FpCombo();

            ComboBoxCellType celltype = new ComboBoxCellType();

            switch (e.Column)
            {
                // �L������.
                case COLIDX_MLIST_KOUKOKUKENMEI:
                case COLIDX_MLIST_KENMEI:
                case COLIDX_MLIST_SEI_KENMEI:
                    // TextCellType�̏ꍇ�͍ő�o�C�g���̕ҏW�������s�� 
                    if (_spdKkhDetail_Sheet1.Columns[e.Column].CellType is TextCellType)
                    {
                        TextCellType tc = (TextCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;
                        string s = e.EditingControl.Text;
                        if (_enc.GetByteCount(s) > tc.MaxLength)
                        {
                            e.EditingControl.Text = _enc.GetString(_enc.GetBytes(s), 0, tc.MaxLength);
                            ( (GeneralEditor)e.EditingControl ).SelectionStart = e.EditingControl.Text.Length;
                        }
                    }
                    break;

                // ������ʖ��́i�L�[�R�[�h�j.
                case COLIDX_MLIST_TRISIKIKEYCD:

                    editCombo = (FarPoint.Win.FpCombo)e.EditingControl;

                    celltype = (ComboBoxCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;

                    {
                        if (editCombo.SelectedIndex >= 0)
                        {
                            String key = celltype.ItemData[editCombo.SelectedIndex].ToString();

                            KkhMasterUtilityEpson.TRISIKI_DATA t = _master.GetTRISIKI(key);

                            if (t != null)
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKICD].Text  = t.code;
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKINM].Text  = t.name;
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SSNO     ].Text  = t.ssNo;
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEGNO    ].Text  = t.segNo;
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SORT_KEY ].Text  = t.sortKey;
                            }
                            else
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKICD].Text  = "";
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKINM].Text  = "";
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SSNO     ].Text  = "";
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEGNO    ].Text  = "";
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SORT_KEY ].Text  = "";
                            }
                        }
                        else
                        {
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKICD].Text  = "";
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKINM].Text  = "";
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SSNO     ].Text  = "";
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEGNO    ].Text  = "";
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SORT_KEY ].Text  = "";
                        }
                    }

                    break;

                // ����S���Җ��́i�L�[�R�[�h�j.
                case COLIDX_MLIST_TRITNTCD:

                    editCombo = (FarPoint.Win.FpCombo)e.EditingControl;

                    celltype = (ComboBoxCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;

                    {
                        if (editCombo.SelectedIndex >= 0)
                        {
                            String key = celltype.ItemData[editCombo.SelectedIndex].ToString();

                            KkhMasterUtilityEpson.TRITNT_DATA t = _master.GetTRITNT(key);

                            if (t != null)
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRITNTNM].Text = t.name;
                            }
                            else
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRITNTNM].Text = "";
                            }
                        }
                        else
                        {
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRITNTNM].Text = "";
                        }
                    }

                    break;

                case COLIDX_MLIST_SEI_KINGAKU:
                case COLIDX_MLIST_ZEI_GAKU:
                    {
                        Decimal seiKingaku = 0M;

                        Decimal zeiGaku = 0M;

                        // ���z�i�ō��݁j.
                        if (!String.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEI_KINGAKU].Text))
                        {
                            seiKingaku = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEI_KINGAKU].Text);
                        }

                        // �����.
                        if (!String.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_ZEI_GAKU].Text))
                        {
                            zeiGaku = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_ZEI_GAKU].Text);
                        }

                        // ���z�i�ō��݁j.
                        _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_ZEI_NKINGAKU].Text = ( seiKingaku - zeiGaku ).ToString("###,###,###,##0");
                    }

                    break;

                default:
                    if (_spdKkhDetail_Sheet1.Columns[e.Column].CellType is TextCellType)
                    {
                        TextCellType tc = (TextCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;
                        string s = e.EditingControl.Text;
                        if (_enc.GetByteCount(s) > tc.MaxLength)
                        {
                            e.EditingControl.Text = _enc.GetString(_enc.GetBytes(s), 0, tc.MaxLength);
                            ( (GeneralEditor)e.EditingControl ).SelectionStart = e.EditingControl.Text.Length;
                        }
                    }
                    break;
            }

            // �L����וύX�t���O���X�V 
            base.kkhDetailUpdFlag = true;
        }
        #endregion ���׃X�v���b�h���̃Z���Ńe�L�X�g��ύX����Ƃ��ɔ������܂�.

        #region ���׃X�v���b�h�̃L�[�_�E���C�x���g.
        /// <summary>
        /// ���׃X�v���b�h�̃L�[�_�E���C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Control)
            {
                //Ctrl+V���������ꂽ�ꍇ�A�N���b�v�{�[�h�̓��e��\��t��.
                FpSpread fpSpread = sender as FpSpread;
                CellRange[] range = fpSpread.ActiveSheet.GetSelections();

                // �N���b�v�{�[�h�̒l���Z���ɓ��Ă͂߂�.
                string clipVal = Clipboard.GetText();

                // �I�������Z���͈͏��𑖍�����.
                foreach (CellRange rn in range)
                {
                    // �� 
                    int col = rn.Column;
                    // �s 
                    int row = rn.Row;
                    // �I��͈͏I����.
                    int colEnd = ( rn.Column + rn.ColumnCount - 1 );
                    // �I��͈͏I���s 
                    int rowEnd = ( rn.Row + rn.RowCount - 1 );
                    for (int colCnt = col; colCnt <= colEnd; colCnt++)
                    {
                        bool multiCopyFlg = false;
                        // �s�����[�v 
                        for (int rowCnt = row; rowCnt < rowEnd + 1; rowCnt++)
                        {
                            multiCopyFlg = isSetContinuePast(spdKkhDetail.GetRootWorkbook(), clipVal, rowCnt, colCnt);

                            if (multiCopyFlg)
                            {
                                // �����R�s�[�ׁ̈A�\��t���I�� 
                                break;
                            }
                        }
                        if (multiCopyFlg)
                        {
                            // �����R�s�[�ׁ̈A�\��t���I�� 
                            break;
                        }
                    }
                }
            }
        }
        #endregion ���׃X�v���b�h�̃L�[�_�E���C�x���g.

        #region �y�[�X�g����.
        /// <summary>
        /// �y�[�X�g���� 
        /// </summary>
        /// <param name="spView"></param>
        /// <param name="val"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>
        /// true = �\��t���p�� 
        /// false = �\��t���I�� 
        /// </returns>
        private bool isSetContinuePast(FarPoint.Win.Spread.SpreadView spView, string val, int row, int col)
        {
            SheetView shView = spView.GetSheetView(); ;

            bool multiCopyFlg = true;
            // �R�s�[��O������Try�`Catch�ŋz������ 

            // �L�[=�u��,�s�v�l=�u�\��t���l�v 
            Dictionary<string, string> pastDic = KKHUtility.getPastValueDic(val);

            if (pastDic.Count == 1)
            {
                // �����R�s�[�łȂ��ꍇ 
                multiCopyFlg = false;
            }

            // �R�s�[���̃Z������.
            foreach (string pastKey in pastDic.Keys)
            {
                // �L�[�u��,�s�v�𕪊�.
                string[] keySplitArr = pastKey.Split(KKHSystemConst.SPLIT_VAL.ToCharArray());

                // �� 
                int addCol = int.Parse(keySplitArr[0]);
                // �s 
                int addRow = int.Parse(keySplitArr[1]);
                try
                {
                    // �y�[�X�g�Ώۗ� 
                    int colNum = col + addCol;
                    // �y�[�X�g�Ώۍs 
                    int rowNum = row + addRow;

                    // �R�s�[�\�ȗ񂩊m�F���� 
                    if (!isCopyOKColumn(shView, colNum, rowNum))
                    {
                        continue;
                    }

                    // �y�[�X�g 
                    shView.Cells[rowNum, colNum].Text = pastDic[pastKey];

                    // �R�s�[��̃J�����ύX�ɂ�錟�؏��� 
                    ChangeEventArgs changeEvent = new ChangeEventArgs(spView, rowNum, colNum);

                    // �Z���ύX�������s 
                    spdKkhDetail_Change(spdKkhDetail, changeEvent);
                }
                // �Z���^�C�v�̈Ⴂ���ł̃G���[���p.
                catch { }
            }

            return multiCopyFlg;
        }
        #endregion �y�[�X�g����.

        #region �R�s�[�\��m�F.
        /// <summary>
        /// �R�s�[�\��m�F.
        /// </summary>
        /// <param name="shView"></param>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool isCopyOKColumn(SheetView shView, int col, int row)
        {
            Column actColumn = shView.Columns[col];
            if (actColumn.Locked)
            {
                // ���b�N����Ă���ꍇ 
                return false;
            }

            //��\����ւ͓\��t���s�Ƃ���.
            if (actColumn.Visible.Equals(false))
            {
                return false;
            }

            if (actColumn.CellType is TextCellType     ||
                actColumn.CellType is NumberCellType   ||
                actColumn.CellType is ComboBoxCellType )
            {
                // �Z���^�C�v���e�L�X�g�̏ꍇ 
                if (shView.Cells[row, col].Locked)
                {
                    return false;
                }

                return true;
            }

            return false;
        }
        #endregion �R�s�[�\��m�F.

        #region �X�v���b�h�`�F���W.
        /// <summary>
        /// �X�v���b�h�`�F���W.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdKkhDetail_Change(object sender, ChangeEventArgs e)
        {
            switch (e.Column)
            {
                // �L������.
                case COLIDX_MLIST_KOUKOKUKENMEI:
                case COLIDX_MLIST_KENMEI:
                case COLIDX_MLIST_SEI_KENMEI:
                    {
                        // TextCellType�̏ꍇ�͍ő�o�C�g���̕ҏW�������s�� 
                        if (_spdKkhDetail_Sheet1.Columns[e.Column].CellType is TextCellType)
                        {
                            TextCellType tc = (TextCellType)_spdKkhDetail_Sheet1.Columns[e.Column].CellType;

                            string s = _spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Text;

                            if (_enc.GetByteCount(s) > tc.MaxLength)
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Text = _enc.GetString(_enc.GetBytes(s), 0, tc.MaxLength);
                            }
                        }
                    }

                    break;

                // ������ʖ��́i�L�[�R�[�h�j.
                case COLIDX_MLIST_TRISIKIKEYCD:
                    {
                        if (_spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Value != null)
                        {
                            String key = _spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Value.ToString();

                            KkhMasterUtilityEpson.TRISIKI_DATA t = _master.GetTRISIKI(key);

                            if (t != null)
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKICD].Text = t.code;
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKINM].Text = t.name;
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SSNO     ].Text = t.ssNo;
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEGNO    ].Text = t.segNo;
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SORT_KEY ].Text = t.sortKey;
                            }
                            else
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKICD].Text = "";
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKINM].Text = "";
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SSNO     ].Text = "";
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEGNO    ].Text = "";
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SORT_KEY ].Text = "";
                            }
                        }
                        else
                        {
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKICD].Text = "";
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRISIKINM].Text = "";
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SSNO     ].Text = "";
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEGNO    ].Text = "";
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SORT_KEY ].Text = "";
                        }
                    }

                    break;

                // ����S���Җ��́i�L�[�R�[�h�j.
                case COLIDX_MLIST_TRITNTCD:
                    {
                        if (_spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Value != null)
                        {
                            String key = _spdKkhDetail_Sheet1.Cells[e.Row, e.Column].Value.ToString();

                            KkhMasterUtilityEpson.TRITNT_DATA t = _master.GetTRITNT(key);

                            if (t != null)
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRITNTNM].Text = t.name;
                            }
                            else
                            {
                                _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRITNTNM].Text = "";
                            }
                        }
                        else
                        {
                            _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_TRITNTNM].Text = "";
                        }
                    }

                    break;

                case COLIDX_MLIST_SEI_KINGAKU:
                case COLIDX_MLIST_ZEI_GAKU:
                    {
                        Decimal seiKingaku = 0M;

                        Decimal zeiGaku = 0M;

                        // ���z�i�ō��݁j.
                        if (!String.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEI_KINGAKU].Text))
                        {
                            seiKingaku = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_SEI_KINGAKU].Text);
                        }

                        // �����.
                        if (!String.IsNullOrEmpty(_spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_ZEI_GAKU].Text))
                        {
                            zeiGaku = KKHUtility.DecParse(_spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_ZEI_GAKU].Text);
                        }

                        // ���z�i�ō��݁j.
                        _spdKkhDetail_Sheet1.Cells[e.Row, COLIDX_MLIST_ZEI_NKINGAKU].Text = ( seiKingaku - zeiGaku ).ToString("###,###,###,##0");
                    }

                    break;
            }

            CalculateGoukei();

            // �L����וύX�t���O���X�V 
            base.kkhDetailUpdFlag = true;
        }
        #endregion �X�v���b�h�`�F���W.

        #region �^�u�C���f�b�N�X�`�F���W.
        /// <summary>
        /// �^�u�C���f�b�N�X�`�F���W.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabHed_SelectedIndexChangedEpson(object sender, EventArgs e)
        {
            if (isActivatedJyutyuList() && ( ( _previousTabIndex == 0 ) || ( _previousTabIndex == 1 ) ))
            {
                _previousTabIndex = tabHed.SelectedIndex;

                return;
            }

            // ���׃J�����̕\���ؑ�.
            if (isActivatedJyutyuList() )
            {
                ControlDetailSpreadColmunVisible();
            }
            else if (isActivatedSeikyuList())
            {
                ControlSeikyuDetailSpreadColmunVisible();
            }

            if (_notSearchState == false)
            {
                // ���ׂ̍Ď擾.
                if (( _dsDetail.JyutyuList.Rows.Count != 0 ) || ( _dsSeikyuEpson.SeikyuHeader.Rows.Count != 0 ))
                {
                    ShowLoadingDialog();

                    DisplayDetail();

                    CloseLoadingDialog();
                }
            }
            else
            {
                // �X�v���b�h�Ƀ^�u�ɑΉ��������׃f�[�^��ݒ肷��.
                if (isActivatedJyutyuList())
                {
                    _bsKkhDetail.DataSource = _dsDetailEpson;
                    _bsKkhDetail.DataMember = _dsDetailEpson.KkhDetail.TableName;
                    _bsKkhDetail.EndEdit();

                    _dsDetailEpson.AcceptChanges();
                }
                else if (isActivatedSeikyuList())
                {
                    _bsKkhDetail.DataSource = _dsSeikyuDetailEpson;
                    _bsKkhDetail.DataMember = _dsSeikyuDetailEpson.KkhDetail.TableName;
                    _bsKkhDetail.EndEdit();

                    _dsSeikyuDetailEpson.AcceptChanges();
                }
            }

            // �󒍃��X�g.
            if (isActivatedJyutyuList())
            {
                // �����̕\��.
                lblJyutyuListCnt.Text = _bsJyutyuList.Count + "��";

                lblJyutyuDown.Visible = true;
                lblJyutyuDownValue.Visible = true;

                lblJyutyuDown2.Visible = true;
                lblJyutyuDownValue2.Visible = true;

                lblJyutyuMeisai.Visible = true;
                lblJyutyuMeisaiValue.Visible = true;

                lblSeikyuDown.Visible = false;
                lblSeikyuDownValue.Visible = false;

                lblSeikyuDown2.Visible = false;
                lblSeikyuDownValue2.Visible = false;

                lblSeikyuMeisai.Visible = false;
                lblSeikyuMeisaiValue.Visible = false;
            }
            // �������.
            else if (isActivatedSeikyuList())
            {
                // �����̕\��.
                lblJyutyuListCnt.Visible = true;
                lblJyutyuListCnt.Text = _bsSeikyuList.Count + "��";

                lblSeikyuDown.Visible = true;
                lblSeikyuDownValue.Visible = true;

                lblSeikyuDown2.Visible = true;
                lblSeikyuDownValue2.Visible = true;

                lblSeikyuMeisai.Visible = true;
                lblSeikyuMeisaiValue.Visible = true;

                lblJyutyuDown.Visible = false;
                lblJyutyuDownValue.Visible = false;

                lblJyutyuDown2.Visible = false;
                lblJyutyuDownValue2.Visible = false;

                lblJyutyuMeisai.Visible = false;
                lblJyutyuMeisaiValue.Visible = false;
            }

            // �{�^������.
            SetButtonEnable();

            // �C���f�b�N�X�̕ۑ�.
            _previousTabIndex = tabHed.SelectedIndex;

            // �f�[�^���N���A�������ߖ��וύX�t���O���I�t�ɂ���.
            kkhDetailUpdFlag = false;
        }
        #endregion �^�u�C���f�b�N�X�`�F���W.

        #region �^�u���ύX����悤�Ƃ��Ă���.
        /// <summary>
        /// �^�u���ύX����悤�Ƃ��Ă���.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabHed_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // �󒍃^�u�Ɛ�������^�u�����ւ��鎞.
            if (!( isActivatedJyutyuList() && ( ( _previousTabIndex == 0 ) || ( _previousTabIndex == 1 ) ) ))
            {
                if (ConfirmEditStatus() == false)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
        #endregion �^�u���ύX����悤�Ƃ��Ă���.

        #region �w���v�{�^������.
        /// <summary>
        /// �w���v�{�^������ 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //���Ӑ�R�[�h 
            string tkskgy = _naviParameter.strTksKgyCd + _naviParameter.strTksBmnSeqNo + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //���s 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Detail, this, HelpNavigator.KeywordIndex);
            //HlpClick();
            this.ActiveControl = null;
        }
        #endregion �w���v�{�^������.
        #endregion �C�x���g.

        #region ���\�b�h.
        #region ���׃f�[�^�\��.
        /// <summary>
        /// ���׃f�[�^�\��.
        /// </summary>
        private void DisplayDetail()
        {
            //�f�[�^�擾�����͓Ǝ��Ŏ���.
            ////�e�N���X�̍s���Ă��鋤�ʏ��������s 
            //base.DisplayKkhDetail(rowIdx);

            //�L����ׂ̏����� 
            _dsDetailEpson.DetailDataEpson.Clear();

            //�ύX���t���O��߂� 
            kkhDetailUpdFlag = false;

            {
                // �L����p���ׂ̌���.
                DetailDSEpson dt = new DetailDSEpson();

                SearchDetailEpson(dt, "1");

                _dsDetailEpson.Clear();
                _dsDetailEpson.Merge(dt);
                _dsDetailEpson.AcceptChanges();
            }

            {
                // ��������p���ׂ̌���.
                DetailDSEpson dt = new DetailDSEpson();

                SearchDetailEpson(dt, "2");

                _dsSeikyuDetailEpson.Clear();
                _dsSeikyuDetailEpson.Merge(dt);
                _dsSeikyuDetailEpson.AcceptChanges();
            }

            if (isActivatedJyutyuList())
            {
                _bsKkhDetail.DataSource = _dsDetailEpson;
                _bsKkhDetail.DataMember = _dsDetailEpson.KkhDetail.TableName;
                _bsKkhDetail.EndEdit();

                _dsDetailEpson.AcceptChanges();
            }
            else if (isActivatedSeikyuList())
            {
                _bsKkhDetail.DataSource = _dsSeikyuDetailEpson;
                _bsKkhDetail.DataMember = _dsSeikyuDetailEpson.KkhDetail.TableName;
                _bsKkhDetail.EndEdit();

                _dsSeikyuDetailEpson.AcceptChanges();
            }

            //***************************************
            //�{�^���ނ̎g�p�E�s�ݒ� 
            //***************************************
            SetButtonEnable();

            //******************************
            //���v���x�� 
            //******************************
            CalculateGoukei();

            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(0, 0, 1, 1);
            }
        }
        #endregion ���׃f�[�^�\��.

        #region ���׃f�[�^�̌���.
        /// <summary>
        /// ���׃f�[�^�̌���.
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="kbn"></param>
        private void SearchDetailEpson(DetailDSEpson ds, String kbn)
        {
            DetailEpsonProcessController.FindDetailDataEpsonByCondParam param = new DetailEpsonProcessController.FindDetailDataEpsonByCondParam();

            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = txtYmd.Value;
            param.kbn = kbn;

            DetailEpsonProcessController controller = DetailEpsonProcessController.GetInstance();

            FindDetailDataEpsonByCondServiceResult result = controller.FindDetailDataEpsonByCond(param);

            if (result.HasError == true)
            {
                return;
            }

            ds.DetailDataEpson.Clear();
            ds.DetailDataEpson.Merge(result.DetailEpsonDataSet.DetailDataEpson);
            ds.DetailDataEpson.AcceptChanges();

            // �X�v���b�h�\���p�f�[�^�̐ݒ�.
            ds.KkhDetail.Clear();

            foreach (Isid.KKH.Epson.Schema.DetailDSEpson.DetailDataEpsonRow row in ds.DetailDataEpson.Rows)
            {
                Isid.KKH.Epson.Schema.DetailDSEpson.KkhDetailRow addRow = ds.KkhDetail.NewKkhDetailRow();

                // �L����p����.
                if (String.Equals(kbn, "1"))
                {
                    if (row.hb2Kbn1 == "1")
                    {
                        addRow.seiFlg = "True";
                    }
                    else
                    {
                        addRow.seiFlg = "False";
                    }

                    if (row.hb2Sonota1.Length == 12)
                    {
                        addRow.seiNo = row.hb2Sonota1.Substring(0, 8) + "-" + row.hb2Sonota1.Substring(8, 4);
                    }
                    else
                    {
                        addRow.seiNo = row.hb2Sonota1;
                    }

                    addRow.uriMeiNo         = row.hb2JyutNo + "-" + row.hb2JyMeiNo + "-" + row.hb2UrMeiNo;
                    // 2015/04/06 �G�v�\�������g���Ή� Fujisaki Cng Start 
                    //addRow.koukokuKenmei    = row.hb2Name8;
                    addRow.koukokuKenmei = row.hb2Name11;
                    // 2015/04/06 �G�v�\�������g���Ή� Fujisaki Cng End 
                    addRow.kenmei           = row.hb2Name10;
                    addRow.seiKenmei        = String.Empty;
                    addRow.triTntCd         = row.hb2Code3;
                    addRow.triSikiKeyCd     = row.hb2Code5;
                    addRow.baitaiCd = row.hb2Code1;
                    addRow.seiKbn = row.hb2Code2;
                    addRow.triTntNm         = row.hb2Name3;
                    addRow.triSikiCd        = row.hb2Code4;
                    addRow.triSikiNm        = row.hb2Name4;
                    addRow.ssNo             = row.hb2Name5;
                    addRow.segNo            = row.hb2Name6;
                    addRow.sortKey          = row.hb2Name7;
                    addRow.afKngk           = row.hb2SeiGak;
                    addRow.bfKngk           = row.hb2Kngk2;
                    addRow.seiKingaku       = 0M;
                    addRow.zeiGaku          = row.hb2Kngk1;
                    addRow.zeiNKingaku      = 0M;

                    if (row.hb2Date1.Length == 8)
                    {
                        addRow.keizyoBi = row.hb2Date1.Substring(0, 4) + "/" + row.hb2Date1.Substring(4, 2) + "/" + row.hb2Date1.Substring(6, 2);
                    }
                    else
                    {
                        addRow.keizyoBi = row.hb2Date1;
                    }
                }
                // ��������p����.
                else if (String.Equals(kbn, "2"))
                {
                    if (row.hb2Kbn1 == "1")
                    {
                        addRow.seiFlg = "True";
                    }
                    else
                    {
                        addRow.seiFlg = "False";
                    }

                    if (row.hb2Sonota1.Length == 12)
                    {
                        addRow.seiNo = row.hb2Sonota1.Substring(0, 8) + "-" + row.hb2Sonota1.Substring(8, 4);
                    }
                    else
                    {
                        addRow.seiNo = row.hb2Sonota1;
                    }

                    addRow.uriMeiNo         = row.hb2JyutNo + "-" + row.hb2JyMeiNo + "-" + row.hb2UrMeiNo;
                    addRow.koukokuKenmei    = String.Empty;
                    addRow.kenmei           = String.Empty;
                    // 2015/04/06 �G�v�\�������g���Ή� Fujisaki Cng Start 
                    //addRow.seiKenmei        = row.hb2Name8;
                    addRow.seiKenmei = row.hb2Name11;
                    // 2015/04/06 �G�v�\�������g���Ή� Fujisaki Cng End 
                    addRow.triTntCd         = row.hb2Code3;
                    addRow.triSikiKeyCd     = row.hb2Code5;
                    /* 2017/04/04 �G�v�\���d����ύX�Ή� ITCOM A.Nakamura  ADD Start */
                    addRow.kihyouBmnCd      = row.hb2Sonota2;
                    addRow.genkaCenter      = row.hb2Sonota3;
                    /* 2017/04/04 �G�v�\���d����ύX�Ή� ITCOM A.Nakamura  ADD End */
                    addRow.afKngk           = 0M;
                    addRow.bfKngk           = 0M;
                    addRow.baitaiCd = row.hb2Code1;
                    addRow.seiKbn = row.hb2Code2;
                    addRow.triTntNm = row.hb2Name3;
                    addRow.triSikiCd        = row.hb2Code4;
                    addRow.triSikiNm        = row.hb2Name4;
                    addRow.ssNo             = row.hb2Name5;
                    addRow.segNo            = row.hb2Name6;
                    addRow.sortKey          = row.hb2Name7;
                    addRow.seiKingaku       = row.hb2SeiGak + row.hb2Kngk1;
                    addRow.zeiGaku          = row.hb2Kngk1;
                    addRow.zeiNKingaku      = row.hb2SeiGak;

                    if (row.hb2Date1.Length == 8)
                    {
                        addRow.keizyoBi = row.hb2Date1.Substring(0, 4) + "/" + row.hb2Date1.Substring(4, 2) + "/" + row.hb2Date1.Substring(6, 2);
                    }
                    else
                    {
                        addRow.keizyoBi = row.hb2Date1;
                    }
                }

                ds.KkhDetail.AddKkhDetailRow(addRow);
            }

            ds.KkhDetail.AcceptChanges();

            ds.AcceptChanges();
        }
        #endregion ���׃f�[�^�̌���.

        #region ���v�v�Z.
        /// <summary>
        /// ���v�v�Z.
        /// </summary>
        private void CalculateGoukei()
        {
            // �������v 
            Decimal jyutyuDownGoukei = 0;
            Decimal jyutyuDownGoukei2 = 0;
            Decimal jyutyuMeisaiGoukei = 0;
            Decimal seikyuDownGoukei = 0;
            Decimal seikyuDownGoukei2 = 0;
            Decimal seikyuMeisaiGoukei = 0;

            // �󒍃f�[�^�̌������A�J��Ԃ�.
            for (int i = 0; i < _spdJyutyuList_Sheet1.RowCount; i++)
            {
                String ryoukinStr = _spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_SEIKINGAKU].Text.Trim();

                // ���������͂���Ă���ꍇ 
                if (KKHUtility.IsNumeric(ryoukinStr))
                {
                    // �������v�ɉ��Z 
                    jyutyuDownGoukei = jyutyuDownGoukei + KKHUtility.DecParse(ryoukinStr.Trim());
                }
            }

            // �󒍃f�[�^�̌������A�J��Ԃ�.
            for (int i = 0; i < _spdJyutyuList_Sheet1.RowCount; i++)
            {
                if (String.IsNullOrEmpty(_spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_TOROKU].Text.Trim()))
                {
                    continue;
                }

                String ryoukinStr = _spdJyutyuList_Sheet1.Cells[i, COLIDX_JLIST_SEIKINGAKU].Text.Trim();

                // ���������͂���Ă���ꍇ 
                if (KKHUtility.IsNumeric(ryoukinStr))
                {
                    // �������v�ɉ��Z 
                    jyutyuDownGoukei2 = jyutyuDownGoukei2 + KKHUtility.DecParse(ryoukinStr.Trim());
                }
            }

            // �󒍖��׃f�[�^�̌������A�J��Ԃ� 
            foreach (DetailDSEpson.KkhDetailRow row in _dsDetailEpson.KkhDetail.Rows)
            {
                // �������v�ɉ��Z 
                jyutyuMeisaiGoukei = jyutyuMeisaiGoukei + row.afKngk;
            }

            // �����f�[�^�̌������A�J��Ԃ�.
            for (int i = 0; i < _spdSeikyuList_Sheet1.RowCount; i++)
            {
                String ryoukinStr = _spdSeikyuList_Sheet1.Cells[i, COLIDX_SHLIST_ZEINKINGAKUGK].Text.Trim();

                // ���������͂���Ă���ꍇ 
                if (KKHUtility.IsNumeric(ryoukinStr))
                {
                    // �������v�ɉ��Z 
                    seikyuDownGoukei = seikyuDownGoukei + KKHUtility.DecParse(ryoukinStr.Trim());
                }
            }

            // �����f�[�^�̌������A�J��Ԃ�.
            for (int i = 0; i < _spdSeikyuList_Sheet1.RowCount; i++)
            {
                if (String.IsNullOrEmpty(_spdSeikyuList_Sheet1.Cells[i, COLIDX_SHLIST_HANNEI].Text.Trim()))
                {
                    continue;
                }

                String ryoukinStr = _spdSeikyuList_Sheet1.Cells[i, COLIDX_SHLIST_ZEINKINGAKUGK].Text.Trim();

                // ���������͂���Ă���ꍇ 
                if (KKHUtility.IsNumeric(ryoukinStr))
                {
                    // �������v�ɉ��Z 
                    seikyuDownGoukei2 = seikyuDownGoukei2 + KKHUtility.DecParse(ryoukinStr.Trim());
                }
            }

            // �������׃f�[�^�̌������A�J��Ԃ�.
            foreach (DetailDSEpson.KkhDetailRow row in _dsSeikyuDetailEpson.KkhDetail.Rows)
            {
                // �������v�ɉ��Z 
                seikyuMeisaiGoukei = seikyuMeisaiGoukei + row.zeiNKingaku;
            }

            // �󒍍��v.
            lblJyutyuDownValue.Text = jyutyuDownGoukei.ToString("###,###,###,##0");

            // �󒍍��v�i�o�^�ρj.
            lblJyutyuDownValue2.Text = jyutyuDownGoukei2.ToString("###,###,###,##0");

            // �󒍖��׍��v.
            lblJyutyuMeisaiValue.Text = jyutyuMeisaiGoukei.ToString("###,###,###,##0");

            // �������v.
            lblSeikyuDownValue.Text = seikyuDownGoukei.ToString("###,###,###,##0");

            // �������v�i�o�^�ρj.
            lblSeikyuDownValue2.Text = seikyuDownGoukei2.ToString("###,###,###,##0");

            // �������׍��v 
            lblSeikyuMeisaiValue.Text = seikyuMeisaiGoukei.ToString("###,###,###,##0");
        }
        #endregion ���v�v�Z.

        #region �L����ׂ̃f�[�^�\�[�X�X�V.
        /// <summary>
        /// �L����ׂ̃f�[�^�\�[�X�X�V.
        /// </summary>
        /// <param name="dsDetailEpson"></param>
        private void UpdateDataSourceByDetailDataSetEpson(DetailDSEpson dsDetailEpson)
        {
            _dsDetailEpson.Clear();
            _dsDetailEpson.Merge(_dsDetailEpson);
            _dsDetailEpson.AcceptChanges();
        }
        #endregion �L����ׂ̃f�[�^�\�[�X�X�V.

        #region �f�[�^�\�[�X�̃o�C���h.
        /// <summary>
        /// �f�[�^�\�[�X�̃o�C���h 
        /// </summary>
        private void InitializeDataSourceEpson()
        {
            //_bsJyutyuList
            _bsKkhDetail.DataSource = _dsDetailEpson;
            _bsKkhDetail.DataMember = _dsDetailEpson.KkhDetail.TableName;
            _bsKkhDetail.EndEdit();
        }
        #endregion �f�[�^�\�[�X�̃o�C���h.

        #region �p�����t�H�[���Ŏg�p���Ă���v���p�e�B���̏����l�ݒ�.
        /// <summary>
        /// �p�����t�H�[���Ŏg�p���Ă���v���p�e�B���̏����l�ݒ�.
        /// </summary>
        private void InitializeCommonProperty()
        {
        }
        #endregion �p�����t�H�[���Ŏg�p���Ă���v���p�e�B���̏����l�ݒ�.

        #region �e�R���g���[���̏����ݒ�.
        /// <summary>
        /// �e�R���g���[���̏����ݒ�.
        /// </summary>
        private void InitializeControlEpson()
        {
            //********************
            //�}�X�^�����擾���� 
            //********************
            GetMasterData();

            _master = new KkhMasterUtilityEpson();

            _master.GetMasterData(_naviParameter);

            //******************
            //���������� 
            //******************
            lblKenMei.Visible = false;
            txtKenMei.Visible = false;
            lblKikan.Visible = false;
            txtYmdTo.Visible = false;

            //*******************
            //�{�^����.
            //*******************
            btnRegister.Enabled = false;
            btnRegBulk.Enabled = false;
            btnReqBind.Enabled = false;
            btnBulkMerge.Enabled = false;
            btnMerge.Enabled = false;
            btnMergeCancel.Enabled = false;
            btnDetailInput.Enabled = false;
            btnDetailDel.Enabled = false;
            btnDetailRegister.Enabled = false;
        }
        #endregion �e�R���g���[���̏����ݒ�.

        #region �L����׃X�v���b�h�̃f�U�C�����������s��.
        /// <summary>
        /// �L����׃X�v���b�h�̃f�U�C�����������s��.
        /// </summary>
        private void InitializeDesignForSpdKkhDetail()
        {
            //********************************
            //�񖈂̐ݒ� ���f�U�C�i�����ɑ΂���ݒ���s���ƕύX�����f����Ȃ����Ƃ�����悤�Ȃ̂Ŏb��I�ɂ����ōs�� 
            //********************************

            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                //���ʐݒ� 
                col.AllowAutoFilter = true;//�t�B���^�@�\��L�� 
                col.AllowAutoSort = true;  //�\�[�g�@�\��L�� 

                //�񖈂ɈقȂ�ݒ� 
                if (col.Index == COLIDX_MLIST_SEIFLG)
                {
                    CheckBoxCellType cellType = new CheckBoxCellType();

                    //

                    col.CellType            = cellType;
                    col.DataField           = "seiFlg";
                    col.Label               = "�����ΏۊO";
                    col.Width               = 80;
                    col.HorizontalAlignment = CellHorizontalAlignment.Center;
                }
                else if (col.Index == COLIDX_MLIST_SEINO)
                {
                    TextCellType cellType = new TextCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    cellType.MaxLength = 15;
                    cellType.CharacterSet = CharacterSet.AlphaNumeric;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "seiNo";
                    col.Label       = "�������ԍ�";
                    col.Locked      = true;
                    col.Width       = 120;
                }
                else if (col.Index == COLIDX_MLIST_URIMEINO)
                {
                    TextCellType cellType = new TextCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    cellType.MaxLength = 18;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "uriMeiNo";
                    col.Label       = "���㖾�ׂm�n";
                    col.Locked      = true;
                    col.Width       = 130;
                }
                else if (col.Index == COLIDX_MLIST_KOUKOKUKENMEI)
                {
                    TextCellType cellType = new TextCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    cellType.MaxLength = 60;
                    cellType.CharacterSet = CharacterSet.AllIME;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "koukokuKenmei";
                    col.Label       = "�L������";
                    col.Width       = 200;
                }
                else if (col.Index == COLIDX_MLIST_TRITNTCD)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData = _triTntKey;
                    type.Items = _triTntValue;
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;

                    //

                    col.CellType    = type;
                    col.DataField   = "triTntCd";
                    col.Label       = "���S��";
                    col.Width       = 80;
                }
                else if (col.Index == COLIDX_MLIST_KENMEI)
                {
                    TextCellType cellType = new TextCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    cellType.MaxLength = 120;
                    cellType.CharacterSet = CharacterSet.AllIME;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "kenmei";
                    col.Label       = "����";
                    col.Width       = 200;
                }
                else if (col.Index == COLIDX_MLIST_SEI_KENMEI)
                {
                    TextCellType cellType = new TextCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    cellType.MaxLength = 120;
                    cellType.CharacterSet = CharacterSet.AllIME;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "seiKenmei";
                    col.Label       = "��������";
                    col.Width       = 300;
                }
                else if (col.Index == COLIDX_MLIST_TRISIKIKEYCD)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData = _triSikiKey;
                    type.Items = _triSikiValue;
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;

                    //

                    col.CellType    = type;
                    col.DataField   = "triSikiKeyCd";
                    col.Label       = "������ʖ�";
                    col.Width       = 200;
                }
                /* 2017/04/14 �G�v�\���d����ύX�Ή��@ITCOM A.Nakamura ADD Start */
                 else if (col.Index == COLIDX_MLIST_KIHYOUBMNCD)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData = _kihyouBmnCdKey;
                    type.Items = _kihyouBmnCdValue;
                    type.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable = false;

                    //

                    col.CellType    = type;
                    col.DataField   = DFKIHYOUBMNCD;
                    col.Label       = LKIHYOUBMNCD;
                    col.Width       = 100;
                }
                 else if (col.Index == COLIDX_MLIST_GENKACENTER)
                {
                    ComboBoxCellType type = new ComboBoxCellType();
                    type.ItemData         = _genkaCenterKey;
                    type.Items            = _genkaCenterValue;
                    type.EditorValue      = FarPoint.Win.Spread.CellType.EditorValue.ItemData;
                    type.Editable         = false;

                    //

                    col.CellType    = type;
                    col.DataField   = DFGENKACENTER;
                    col.Label       = LGENKACENTER;
                    col.Width       = 100;
                }
                /* 2017/04/14 �G�v�\���d����ύX�Ή��@ITCOM A.Nakamura  ADD End */
                else if (col.Index == COLIDX_MLIST_GYMKBN)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "baitaiCd";
                    col.Label       = "�Ɩ��敪";
                    col.Locked      = true;
                }
                else if (col.Index == COLIDX_MLIST_SEIKBN)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "seiKbn";
                    col.Label       = "�����敪";
                    col.Locked      = true;
                }
                else if (col.Index == COLIDX_MLIST_TRITNTNM)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "triTntNm";
                    col.Label       = "����S���Җ�";
                    col.Locked      = true;
                }
                else if (col.Index == COLIDX_MLIST_TRISIKICD)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "triSikiCd";
                    col.Label       = "������ʃR�[�h";
                    col.Locked      = true;
                }
                else if (col.Index == COLIDX_MLIST_TRISIKINM)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "triSikiNm";
                    col.Label       = "������ʖ�";
                    col.Locked      = true;
                }
                else if (col.Index == COLIDX_MLIST_SEGNO)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "ssNo";
                    col.Label       = "�w�}�m�n";
                    col.Locked      = true;
                }
                /* 2017/04/04 �G�v�\���d����ύX�Ή��@ITCOM A.Nakamura  ADD Start */
                else if (col.Index == COLIDX_MLIST_KIHYOUBMNCD)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType = cellType;
                    col.DataField = DFKIHYOUBMNCD;
                    col.Label = LKIHYOUBMNCD;
                    col.Locked = true;
                    col.Width = 100;
                }
                else if (col.Index == COLIDX_MLIST_GENKACENTER)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType = cellType;
                    col.DataField = DFGENKACENTER;
                    col.Label = LGENKACENTER;
                    col.Locked = true;
                    col.Width = 100;
                }
                /* 2017/04/04 �G�v�\���d����ύX�Ή��@ITCOM A.Nakamura  ADD End */
                else if (col.Index == COLIDX_MLIST_SSNO)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "segNo";
                    col.Label       = "�Z�O�����g�m�n";
                    col.Locked      = true;
                }
                else if (col.Index == COLIDX_MLIST_SORT_KEY)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "sortKey";
                    col.Label       = "�\�[�g�L�[";
                    col.Locked      = true;
                }
                else if (col.Index == COLIDX_MLIST_BFKNGK)
                {
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAKU;
                    cellType.MinimumValue = MIN_VALUE_KINGAKU;
                    cellType.NullDisplay = DEF_VALUE_KINGAKU;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "bfKngk";
                    col.Label       = "���O���z";
                    col.Width       = 100;
                }
                else if (col.Index == COLIDX_MLIST_AFKNGK)
                {
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAKU;
                    cellType.MinimumValue = MIN_VALUE_KINGAKU;
                    cellType.NullDisplay = DEF_VALUE_KINGAKU;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "afKngk";
                    col.Label       = "������z";
                    col.Width       = 100;
                }
                else if (col.Index == COLIDX_MLIST_SEI_KINGAKU)
                {
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAKU;
                    cellType.MinimumValue = MIN_VALUE_KINGAKU;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "seiKingaku";
                    col.Label       = "���z�i�ō��݁j";
                    col.Width       = 120;
                }
                else if (col.Index == COLIDX_MLIST_ZEI_GAKU)
                {
                    NumberCellType cellType = new NumberCellType();
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAKU;
                    cellType.MinimumValue = MIN_VALUE_KINGAKU;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "zeiGaku";
                    col.Label       = "�Ŋz";
                    col.Width       = 120;
                }
                else if (col.Index == COLIDX_MLIST_ZEI_NKINGAKU)
                {
                    NumberCellType cellType = new NumberCellType();
                    cellType.ReadOnly = false;
                    cellType.Static = false;
                    cellType.DecimalPlaces = 0;
                    cellType.ShowSeparator = true;
                    cellType.MaximumValue = MAX_VALUE_KINGAKU;
                    cellType.MinimumValue = MIN_VALUE_KINGAKU;

                    //

                    col.CellType    = cellType;
                    col.DataField   = "zeiNKingaku";
                    col.Label       = "�Ŕ������z";
                    col.Locked      = true;
                    col.Width       = 120;
                }
                else if( col.Index ==COLIDX_MLIST_KEIZYOUBI)
                {
                    TextCellType cellType = new TextCellType();

                    //

                    col.CellType    = cellType;
                    col.DataField   = "keizyoBi";
                    col.Label       = "�v���";
                    col.Width       = 120;
                }
            }

            if (isActivatedJyutyuList())
            {
                ControlDetailSpreadColmunVisible();
            }
            else if (isActivatedSeikyuList())
            {
                ControlSeikyuDetailSpreadColmunVisible();
            }

            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                _spdKkhDetail_Sheet1.AddSelection(0, 0, 1, 1);
            }
        }
        #endregion �L����׃X�v���b�h�̃f�U�C�����������s��.

        #region �L����p���ׂ̃J�����\���ؑ�.
        /// <summary>
        /// �L����p���ׂ̃J�����\���ؑ�.
        /// </summary>
        private void ControlDetailSpreadColmunVisible()
        {
            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                if (col.Index == COLIDX_MLIST_SEIFLG        ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_SEINO         ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_URIMEINO      ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_KOUKOKUKENMEI ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_TRITNTCD      ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_KENMEI        ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_SEI_KENMEI    ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_TRISIKIKEYCD  ) { col.Visible = true;  }
                /* 2017/04/14 �G�v�\���d����ύX�Ή��@ITCOM A.Nakamura  ADD Start */
                if (col.Index == COLIDX_MLIST_KIHYOUBMNCD   ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_GENKACENTER   ) { col.Visible = false; }
                /* 2017/04/14 �G�v�\���d����ύX�Ή��@ITCOM A.Nakamura  ADD End */
                if (col.Index == COLIDX_MLIST_BFKNGK        ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_AFKNGK        ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_GYMKBN        ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SEIKBN        ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_TRITNTNM      ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_TRISIKICD     ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_TRISIKINM     ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SSNO          ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SEGNO         ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SORT_KEY      ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SEI_KINGAKU   ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_ZEI_GAKU      ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_ZEI_NKINGAKU  ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_KEIZYOUBI     ) { col.Visible = false; }
            }
        }
        #endregion �L����p���ׂ̃J�����\���ؑ�.

        #region ��������p���ׂ̃J�����\���ؑ�.
        /// <summary>
        /// ��������p���ׂ̃J�����\���ؑ�.
        /// </summary>
        private void ControlSeikyuDetailSpreadColmunVisible()
        {
            foreach (Column col in _spdKkhDetail_Sheet1.Columns)
            {
                if (col.Index == COLIDX_MLIST_SEIFLG        ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_SEINO         ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_URIMEINO      ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_KOUKOKUKENMEI ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_TRITNTCD      ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_KENMEI        ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SEI_KENMEI    ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_TRISIKIKEYCD  ) { col.Visible = true;  }
                /* 2017/04/14 �G�v�\���d����ύX�Ή��@ITCOM A.Nakamura  ADD Start */
                if (col.Index == COLIDX_MLIST_KIHYOUBMNCD   ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_GENKACENTER   ) { col.Visible = true;  }
                /* 2017/04/14 �G�v�\���d����ύX�Ή��@ITCOM A.Nakamura  ADD End */
                if (col.Index == COLIDX_MLIST_BFKNGK        ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_AFKNGK        ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_GYMKBN        ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SEIKBN        ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_TRITNTNM      ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_TRISIKICD     ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_TRISIKINM     ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SSNO          ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SEGNO         ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SORT_KEY      ) { col.Visible = false; }
                if (col.Index == COLIDX_MLIST_SEI_KINGAKU   ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_ZEI_GAKU      ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_ZEI_NKINGAKU  ) { col.Visible = true;  }
                if (col.Index == COLIDX_MLIST_KEIZYOUBI     ) { col.Visible = true;  }
            }
        }
        #endregion ��������p���ׂ̃J�����\���ؑ�.

        #region ���דo�^����.
        /// <summary>
        /// ���דo�^����.
        /// </summary>
        private void RegistDetailData()
        {
            // �_�C�A���O�̕\��.
            base.ShowLoadingDialog();

            // �X�V�p�f�[�^�Z�b�g.
            List<Isid.KKH.Common.KKHSchema.Detail> dsDetailList = new List<Isid.KKH.Common.KKHSchema.Detail>();

            // �N��.
            String Yymm = txtYmd.Value;

            // �ő�X�V����.
            DateTime maxUpdDate = DateTime.MinValue;

            // �󒍃��X�g�����p.
            Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable jyutyuList = new Isid.KKH.Common.KKHSchema.Detail.JyutyuDataDataTable();

            // �󒍃f�[�^�X�V�p���[�N.
            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable dtTHB1DOWNWork = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();

            // ���׃f�[�^�X�V�p���[�N.
            Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable dtTHB2KMEIWork = new Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable();

            {
                // �󒍃��X�g�����p 
                for (int i = 0; i < _spdJyutyuList_Sheet1.RowCount; i++)
                {
                    Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow jyutyuRow = getSelectJyutyuData(i);

                    jyutyuList.ImportRow(jyutyuRow);
                }
            }

            {
                // �󒍃f�[�^�X�V 
                for (int i = 0; i < _spdJyutyuList_Sheet1.RowCount; i++)
                {
                    Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow jyutyuRow = getSelectJyutyuData(i);

                    Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow addRow = dtTHB1DOWNWork.NewTHB1DOWNRow();

                    //�X�V�������� 
                    addRow.hb1EgCd          = _naviParameter.strEgcd;        //�c�Ə��i��j�R�[�h 
                    addRow.hb1TksKgyCd      = _naviParameter.strTksKgyCd;    //���Ӑ��ƃR�[�h 
                    addRow.hb1TksBmnSeqNo   = _naviParameter.strTksBmnSeqNo; //���Ӑ敔��SEQNO 
                    addRow.hb1TksTntSeqNo   = _naviParameter.strTksTntSeqNo; //���Ӑ�S��SEQNO
                    addRow.hb1Yymm          = Yymm;                          //�N�� 
                    addRow.hb1JyutNo        = jyutyuRow.hb1JyutNo;           //��No 
                    addRow.hb1JyMeiNo       = jyutyuRow.hb1JyMeiNo;          //�󒍖���No 
                    addRow.hb1UrMeiNo       = jyutyuRow.hb1UrMeiNo;          //���㖾��No 
                    addRow.hb1TouFlg        = jyutyuRow.hb1TouFlg;
                    addRow.hb1UpdApl        = AplId;                         //�X�V�v���O���� 
                    addRow.hb1UpdTnt        = _naviParameter.strEsqId;       //�X�V�S����.

                    dtTHB1DOWNWork.AddTHB1DOWNRow(addRow);
                }
            }

            {
                // �L����p���׍X�V 
                for (int i = 0; i < _dsDetailEpson.KkhDetail.Rows.Count; i++)
                {
                    DetailDSEpson.KkhDetailRow tempRow = _dsDetailEpson.KkhDetail.NewKkhDetailRow();

                    DBNullToEmptyOrZero(tempRow, (DetailDSEpson.KkhDetailRow)_dsDetailEpson.KkhDetail.Rows[i]);

                    String JyutNo = String.Empty;
                    String JyMeiNo = String.Empty;
                    String UrMeiNo = String.Empty;

                    {
                        // �L�[�̕��� 
                        string[] keys = new string[] { "0", "0", "0" };

                        keys = tempRow.uriMeiNo.Split('-');

                        // �󒍔ԍ� 
                        JyutNo = keys[0];

                        // �󒍖��הԍ� 
                        JyMeiNo = keys[1];

                        // ���㖾�הԍ� 
                        UrMeiNo = keys[2];
                    }

                    Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] jyutyuRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[])jyutyuList.Select("hb1JyutNo = '" + JyutNo + "' and hb1JyMeiNo = '" + JyMeiNo + "' and hb1UrMeiNo = '" + UrMeiNo + "'");

                    Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow addRow = dtTHB2KMEIWork.NewTHB2KMEIRow();

                    addRow.hb2TimStmp       = new DateTime();                   //�^�C���X�^���v 
                    addRow.hb2UpdApl        = AplId;                            //�X�V�v���O���� 
                    addRow.hb2UpdTnt        = _naviParameter.strEsqId;          //�X�V�S���� 
                    addRow.hb2EgCd          = _naviParameter.strEgcd;           //�c�Ə��R�[�h 
                    addRow.hb2TksKgyCd      = _naviParameter.strTksKgyCd;       //���Ӑ��ƃR�[�h 
                    addRow.hb2TksBmnSeqNo   = _naviParameter.strTksBmnSeqNo;    //���Ӑ敔��SEQNO 
                    addRow.hb2TksTntSeqNo   = _naviParameter.strTksTntSeqNo;    //���Ӑ�S��SEQNO 
                    addRow.hb2Yymm          = Yymm;                             //�N�� 
                    addRow.hb2JyutNo        = jyutyuRow[0].hb1JyutNo;           //��No 
                    addRow.hb2JyMeiNo       = jyutyuRow[0].hb1JyMeiNo;          //�󒍖���No 
                    addRow.hb2UrMeiNo       = jyutyuRow[0].hb1UrMeiNo;          //���㖾��No 
                    addRow.hb2HimkCd        = jyutyuRow[0].hb1HimkCd;           //��ڃR�[�h 
                    //addRow.hb2Renbn         = "001";                            //�A�� ���דo�^�����g���Ή�.
                    addRow.hb2Renbn = "0001";                                   //�A��.
                    addRow.hb2DateFrom      = " ";                              //�N����From 
                    addRow.hb2DateTo        = " ";                              //�N����To 
                    addRow.hb2SeiGak        = (Decimal)tempRow.afKngk;          //�������z(=������z) 
                    addRow.hb2Hnnert        = 0M;                               //�ύX�l���� 
                    addRow.hb2HnmaeGak      = 0M;                               //�l�����ύX�O���z 
                    addRow.hb2NebiGak       = 0M;                               //�l���z 

                    //���t1(�v���)
                    if (string.IsNullOrEmpty(tempRow.keizyoBi))
                    {
                        addRow.hb2Date1 = " ";
                    }
                    else
                    {
                        // /���폜����.
                        addRow.hb2Date1 = tempRow.keizyoBi.Replace("/", "");
                    }

                    addRow.hb2Date2 = " ";  //���t2 
                    addRow.hb2Date3 = " ";  //���t3 
                    addRow.hb2Date4 = " ";  //���t4 
                    addRow.hb2Date5 = " ";  //���t5 
                    addRow.hb2Date6 = " ";  //���t6 

                    //�敪1(=�����ΏۊO�t���O)
                    if (bool.Parse(tempRow.seiFlg))
                    {
                        addRow.hb2Kbn1 = "1";
                    }
                    else
                    {
                        addRow.hb2Kbn1 = "0";
                    }

                    addRow.hb2Kbn2 = " ";   //�敪2 
                    addRow.hb2Kbn3 = " ";   //�敪3 

                    //�R�[�h1(=�Ɩ��敪) 
                    if (string.IsNullOrEmpty(tempRow.baitaiCd))
                    {
                        addRow.hb2Code1 = " ";
                    }
                    else
                    {
                        addRow.hb2Code1 = tempRow.baitaiCd;
                    }

                    //�R�[�h2(=�����敪) 
                    if (string.IsNullOrEmpty(tempRow.seiKbn))
                    {
                        addRow.hb2Code2 = " ";
                    }
                    else
                    {
                        addRow.hb2Code2 = tempRow.seiKbn;
                    }

                    //�R�[�h3(=����S���҃R�[�h) 
                    if (string.IsNullOrEmpty(tempRow.triTntCd))
                    {
                        addRow.hb2Code3 = " ";
                    }
                    else
                    {
                        addRow.hb2Code3 = tempRow.triTntCd;
                    }

                    //�R�[�h4(=������ʃR�[�h) 
                    if (string.IsNullOrEmpty(tempRow.triSikiCd))
                    {
                        addRow.hb2Code4 = " ";
                    }
                    else
                    {
                        addRow.hb2Code4 = tempRow.triSikiCd;
                    }

                    //�R�[�h5�i=������ʃL�[�R�[�h�j.
                    if (string.IsNullOrEmpty(tempRow.triSikiKeyCd))
                    {
                        addRow.hb2Code5 = " ";
                    }
                    else
                    {
                        addRow.hb2Code5 = tempRow.triSikiKeyCd;
                    }

                    addRow.hb2Code6 = " ";  //�R�[�h6
                    addRow.hb2Name1 = " ";  //����1(����)
                    addRow.hb2Name2 = " ";  //����2(����) 

                    //����3(����)(=����S���Җ���) 
                    if (string.IsNullOrEmpty(tempRow.triTntNm))
                    {
                        addRow.hb2Name3 = " ";
                    }
                    else
                    {
                        addRow.hb2Name3 = tempRow.triTntNm;
                    }

                    //����4(����)(=������ʖ���) 
                    if (string.IsNullOrEmpty(tempRow.triSikiNm.Trim()))
                    {
                        addRow.hb2Name4 = " ";
                    }
                    else
                    {
                        addRow.hb2Name4 = tempRow.triSikiNm;
                    }

                    //����5(����)(=�w�}�m�n)  
                    if (string.IsNullOrEmpty(tempRow.ssNo))
                    {
                        addRow.hb2Name5 = " ";
                    }
                    else
                    {
                        addRow.hb2Name5 = tempRow.ssNo;
                    }

                    //����6(����)(=�Z�O�����g�m�n) 
                    if (string.IsNullOrEmpty(tempRow.segNo))
                    {
                        addRow.hb2Name6 = " ";
                    }
                    else
                    {
                        addRow.hb2Name6 = tempRow.segNo;
                    }

                    //����7(����)(=�\�[�g�L�[) 
                    if (string.IsNullOrEmpty(tempRow.sortKey))
                    {
                        addRow.hb2Name7 = " ";
                    }
                    else
                    {
                        addRow.hb2Name7 = tempRow.sortKey;
                    }

                    // 2015/04/06 �G�v�\�������g���Ή� Fujisaki Cng Start 
                    //����8(����)(=�L������)
                    //if (string.IsNullOrEmpty(tempRow.koukokuKenmei))
                    //{
                    //    addRow.hb2Name8 = " ";
                    //}
                    //else
                    //{
                    //    addRow.hb2Name8 = tempRow.koukokuKenmei;
                    //}
                    if (string.IsNullOrEmpty(tempRow.koukokuKenmei))
                    {
                        addRow.hb2Name11 = " ";
                    }
                    else
                    {
                        addRow.hb2Name11 = tempRow.koukokuKenmei;
                    }
                    // 2015/04/06 �G�v�\�������g���Ή� Fujisaki Cng End 

                    //����9(����) 
                    addRow.hb2Name9 = " ";

                    //����10(����)(=����)
                    if (string.IsNullOrEmpty(tempRow.kenmei))
                    {
                        addRow.hb2Name10 = " ";
                    }
                    else
                    {
                        addRow.hb2Name10 = tempRow.kenmei;
                    }

                    // ���g�p����.
                    // 2015/04/06 �G�v�\�������g���Ή� Fujisaki Cng Start 
                    //addRow.hb2Name11 = " "; //����11(����) 
                    addRow.hb2Name8 = " "; //����8(����) 
                    // 2015/04/06 �G�v�\�������g���Ή� Fujisaki Cng End 
                    addRow.hb2Name12 = " "; //����12(����) 
                    addRow.hb2Name13 = " "; //����13(����) 
                    addRow.hb2Name14 = " "; //����14(����) 
                    addRow.hb2Name15 = " "; //����15(����) 
                    addRow.hb2Name16 = " "; //����16(����) 
                    addRow.hb2Name17 = " "; //����17(����) 
                    addRow.hb2Name18 = " "; //����18(����) 
                    addRow.hb2Name19 = " "; //����19(����) 
                    addRow.hb2Name20 = " "; //����20(����) 

                    //����21(����) 
                    addRow.hb2Name21 = "1";

                    addRow.hb2Name22 = " "; //����22(����) 
                    addRow.hb2Name23 = " "; //����23(����) 
                    addRow.hb2Name24 = " "; //����24(����) 
                    addRow.hb2Name25 = " "; //����25(����) 
                    addRow.hb2Name26 = " "; //����26(����) 
                    addRow.hb2Name27 = " "; //����27(����) 
                    addRow.hb2Name28 = " "; //����28(����) 
                    addRow.hb2Name29 = " "; //����29(����) 
                    addRow.hb2Name30 = " "; //����30(����) 

                    //���z1(�����) 
                    addRow.hb2Kngk1 = (Decimal)tempRow.zeiGaku;

                    //���z2(���O���z) 
                    addRow.hb2Kngk2 = (Decimal)tempRow.bfKngk;

                    //���z3
                    addRow.hb2Kngk3 = 0M;

                    //�䗦1 
                    addRow.hb2Ritu1 = 0M;

                    //�䗦2 
                    addRow.hb2Ritu2 = 0M;

                    //���̑�1(�����ԍ�)
                    if (string.IsNullOrEmpty(tempRow.seiNo))
                    {
                        addRow.hb2Sonota1 = " ";
                    }
                    else
                    {
                        // �n�C�t�����폜����.
                        addRow.hb2Sonota1 = tempRow.seiNo.Replace("-", "");
                    }
                    /* 2017/04/14 �G�v�\���d����ύX�Ή� ITCOM A.Nakamura  MOD Start */
                    //���̑�2(�N�[����CD)
                    //addRow.hb2Sonota2   = " ";  //���̑�2 
                    if (string.IsNullOrEmpty(tempRow.kihyouBmnCd))
                    {
                        addRow.hb2Sonota2 = BLANK;
                    }
                    else
                    {
                        addRow.hb2Sonota2 = tempRow.kihyouBmnCd;
                    }

                    //���̑�3(�����Z���^)
                    //addRow.hb2Sonota3   = " ";  //���̑�3
                    if (string.IsNullOrEmpty(tempRow.genkaCenter))
                    {
                        addRow.hb2Sonota3 = BLANK;
                    }
                    else
                    {
                        addRow.hb2Sonota3 = tempRow.genkaCenter;
                    }
                    /* 2017/04/14 �G�v�\���d����ύX�Ή� ITCOM A.Nakamura  MOD End */
                    addRow.hb2Sonota4   = " ";  //���̑�4 
                    addRow.hb2Sonota5   = " ";  //���̑�5 
                    addRow.hb2Sonota6   = " ";  //���̑�6 
                    addRow.hb2Sonota7   = " ";  //���̑�7
                    addRow.hb2Sonota8   = " ";  //���̑�8 
                    addRow.hb2Sonota9   = " ";  //���̑�9
                    addRow.hb2Sonota10  = " ";  //���̑�10
                    addRow.hb2BunFlg    = " ";  //�����t���O 
                    addRow.hb2MeihnFlg  = " ";  //�����ύX�t���O 
                    addRow.hb2NebhnFlg  = " ";  //�l�����ύX�t���O 

                    dtTHB2KMEIWork.AddTHB2KMEIRow(addRow);
                }
            }

            {
                // ��������p���׍X�V 
                for (int i = 0; i < _dsSeikyuDetailEpson.KkhDetail.Rows.Count; i++)
                {
                    DetailDSEpson.KkhDetailRow tempRow = _dsSeikyuDetailEpson.KkhDetail.NewKkhDetailRow();

                    DBNullToEmptyOrZero(tempRow, (DetailDSEpson.KkhDetailRow)_dsSeikyuDetailEpson.KkhDetail.Rows[i]);

                    String JyutNo = String.Empty;
                    String JyMeiNo = String.Empty;
                    String UrMeiNo = String.Empty;

                    {
                        // �L�[�̕��� 
                        string[] keys = new string[] { "0", "0", "0" };

                        keys = tempRow.uriMeiNo.Split('-');

                        // �󒍔ԍ� 
                        JyutNo = keys[0];

                        // �󒍖��הԍ� 
                        JyMeiNo = keys[1];

                        // ���㖾�הԍ� 
                        UrMeiNo = keys[2];
                    }

                    Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[] jyutyuRow = (Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[])jyutyuList.Select("hb1JyutNo = '" + JyutNo + "' and hb1JyMeiNo = '" + JyMeiNo + "' and hb1UrMeiNo = '" + UrMeiNo + "'");

                    Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow addRow = dtTHB2KMEIWork.NewTHB2KMEIRow();

                    addRow.hb2TimStmp       = new DateTime();                   //�^�C���X�^���v 
                    addRow.hb2UpdApl        = AplId;                            //�X�V�v���O���� 
                    addRow.hb2UpdTnt        = _naviParameter.strEsqId;          //�X�V�S���� 
                    addRow.hb2EgCd          = _naviParameter.strEgcd;           //�c�Ə��R�[�h 
                    addRow.hb2TksKgyCd      = _naviParameter.strTksKgyCd;       //���Ӑ��ƃR�[�h 
                    addRow.hb2TksBmnSeqNo   = _naviParameter.strTksBmnSeqNo;    //���Ӑ敔��SEQNO 
                    addRow.hb2TksTntSeqNo   = _naviParameter.strTksTntSeqNo;    //���Ӑ�S��SEQNO 
                    addRow.hb2Yymm          = Yymm;                             //�N�� 
                    addRow.hb2JyutNo        = JyutNo;                           //��No 
                    addRow.hb2JyMeiNo       = JyMeiNo;                          //�󒍖���No 
                    addRow.hb2UrMeiNo       = UrMeiNo;                          //���㖾��No 
                    addRow.hb2HimkCd        = " ";                              //��ڃR�[�h 
                    //addRow.hb2Renbn = "002";                                    //�A�� ���דo�^�����g���Ή�.
                    addRow.hb2Renbn = "0002";                                   //�A��.
                    addRow.hb2DateFrom      = " ";                              //�N����From 
                    addRow.hb2DateTo        = " ";                              //�N����To 
                    addRow.hb2SeiGak        = (Decimal)tempRow.zeiNKingaku;     //�������z(�Ŕ������z)
                    addRow.hb2Hnnert        = 0M;                               //�ύX�l����.
                    addRow.hb2HnmaeGak      = 0M;                               //�l�����ύX�O���z 
                    addRow.hb2NebiGak       = 0M;                               //�l���z 

                    //���t1(�v���)
                    if (string.IsNullOrEmpty(tempRow.keizyoBi))
                    {
                        addRow.hb2Date1 = " ";
                    }
                    else
                    {
                        // /���폜����.
                        addRow.hb2Date1 = tempRow.keizyoBi.Replace("/", "");
                    }

                    addRow.hb2Date2 = " ";  //���t2 
                    addRow.hb2Date3 = " ";  //���t3 
                    addRow.hb2Date4 = " ";  //���t4 
                    addRow.hb2Date5 = " ";  //���t5 
                    addRow.hb2Date6 = " ";  //���t6 

                    //�敪1(=�����ΏۊO�t���O)
                    if (bool.Parse(tempRow.seiFlg))
                    {
                        addRow.hb2Kbn1 = "1";
                    }
                    else
                    {
                        addRow.hb2Kbn1 = "0";
                    }

                    addRow.hb2Kbn2 = " ";   //�敪2 
                    addRow.hb2Kbn3 = " ";   //�敪3 

                    //�R�[�h1(=�Ɩ��敪) 
                    if (string.IsNullOrEmpty(tempRow.baitaiCd))
                    {
                        addRow.hb2Code1 = " ";
                    }
                    else
                    {
                        addRow.hb2Code1 = tempRow.baitaiCd;
                    }

                    //�R�[�h2(=�����敪) 
                    if (string.IsNullOrEmpty(tempRow.seiKbn))
                    {
                        addRow.hb2Code2 = " ";
                    }
                    else
                    {
                        addRow.hb2Code2 = tempRow.seiKbn;
                    }

                    //�R�[�h3(=����S���҃R�[�h) 
                    if (string.IsNullOrEmpty(tempRow.triTntCd))
                    {
                        addRow.hb2Code3 = " ";
                    }
                    else
                    {
                        addRow.hb2Code3 = tempRow.triTntCd;
                    }

                    //�R�[�h4(=������ʃR�[�h) 
                    if (string.IsNullOrEmpty(tempRow.triSikiCd))
                    {
                        addRow.hb2Code4 = " ";
                    }
                    else
                    {
                        addRow.hb2Code4 = tempRow.triSikiCd;
                    }

                    //�R�[�h5�i=������ʃL�[�R�[�h�j.
                    if (string.IsNullOrEmpty(tempRow.triSikiKeyCd))
                    {
                        addRow.hb2Code5 = " ";
                    }
                    else
                    {
                        addRow.hb2Code5 = tempRow.triSikiKeyCd;
                    }

                    addRow.hb2Code6 = " ";  //�R�[�h6
                    addRow.hb2Name1 = " ";  //����1(����)
                    addRow.hb2Name2 = " ";  //����2(����) 

                    //����3(����)(=����S���Җ���) 
                    if (string.IsNullOrEmpty(tempRow.triTntNm))
                    {
                        addRow.hb2Name3 = " ";
                    }
                    else
                    {
                        addRow.hb2Name3 = tempRow.triTntNm;
                    }

                    //����4(����)(=������ʖ���) 
                    if (string.IsNullOrEmpty(tempRow.triSikiNm.Trim()))
                    {
                        addRow.hb2Name4 = " ";
                    }
                    else
                    {
                        addRow.hb2Name4 = tempRow.triSikiNm;
                    }

                    //����5(����)(=�w�}�m�n)  
                    if (string.IsNullOrEmpty(tempRow.ssNo))
                    {
                        addRow.hb2Name5 = " ";
                    }
                    else
                    {
                        addRow.hb2Name5 = tempRow.ssNo;
                    }

                    //����6(����)(=�Z�O�����g�m�n) 
                    if (string.IsNullOrEmpty(tempRow.segNo))
                    {
                        addRow.hb2Name6 = " ";
                    }
                    else
                    {
                        addRow.hb2Name6 = tempRow.segNo;
                    }

                    //����7(����)(=�\�[�g�L�[) 
                    if (string.IsNullOrEmpty(tempRow.sortKey))
                    {
                        addRow.hb2Name7 = " ";
                    }
                    else
                    {
                        addRow.hb2Name7 = tempRow.sortKey;
                    }

                    // 2015/04/06 �G�v�\�������g���Ή� Fujisaki Cng Start 
                    //����8(����)(=��������)
                    //if (string.IsNullOrEmpty(tempRow.seiKenmei))
                    //{
                    //    addRow.hb2Name8 = " ";
                    //}
                    //else
                    //{
                    //    addRow.hb2Name8 = tempRow.seiKenmei;
                    //}
                    if (string.IsNullOrEmpty(tempRow.seiKenmei))
                    {
                        addRow.hb2Name11 = " ";
                    }
                    else
                    {
                        addRow.hb2Name11 = tempRow.seiKenmei;
                    }
                    // 2015/04/06 �G�v�\�������g���Ή� Fujisaki Cng End 

                    // ���g�p����.
                    addRow.hb2Name9  = " "; //����9 (����) 
                    addRow.hb2Name10 = " "; //����10(����)
                    // 2015/04/06 �G�v�\�������g���Ή� Fujisaki Cng Start 
                    //addRow.hb2Name11 = " "; //����11(����) 
                    addRow.hb2Name8 = " "; //����8(����) 
                    // 2015/04/06 �G�v�\�������g���Ή� Fujisaki Cng End 
                    addRow.hb2Name12 = " "; //����12(����) 
                    addRow.hb2Name13 = " "; //����13(����) 
                    addRow.hb2Name14 = " "; //����14(����) 
                    addRow.hb2Name15 = " "; //����15(����) 
                    addRow.hb2Name16 = " "; //����16(����) 
                    addRow.hb2Name17 = " "; //����17(����) 
                    addRow.hb2Name18 = " "; //����18(����) 
                    addRow.hb2Name19 = " "; //����19(����) 
                    addRow.hb2Name20 = " "; //����20(����) 

                    //����21(����) 
                    addRow.hb2Name21 = "2";

                    addRow.hb2Name22 = " "; //����22(����) 
                    addRow.hb2Name23 = " "; //����23(����) 
                    addRow.hb2Name24 = " "; //����24(����) 
                    addRow.hb2Name25 = " "; //����25(����) 
                    addRow.hb2Name26 = " "; //����26(����) 
                    addRow.hb2Name27 = " "; //����27(����) 
                    addRow.hb2Name28 = " "; //����28(����) 
                    addRow.hb2Name29 = " "; //����29(����) 
                    addRow.hb2Name30 = " "; //����30(����) 

                    //���z1(�����) 
                    addRow.hb2Kngk1 = (Decimal)tempRow.zeiGaku;

                    //���z2
                    addRow.hb2Kngk2 = 0M;

                    //���z3
                    addRow.hb2Kngk3 = 0M;

                    //�䗦1 
                    addRow.hb2Ritu1 = 0M;

                    //�䗦2 
                    addRow.hb2Ritu2 = 0M;

                    //���̑�1(�����ԍ�)
                    if (string.IsNullOrEmpty(tempRow.seiNo))
                    {
                        addRow.hb2Sonota1 = " ";
                    }
                    else
                    {
                        // �n�C�t�����폜����.
                        addRow.hb2Sonota1 = tempRow.seiNo.Replace("-", "");
                    }

                    /* 2017/04/14 �G�v�\���d����ύX�Ή� ITCOM A.Nakamura MOD Start */
                    //��������ꗗ�ւ̕\��.
                    //���̑�2(�N�[����CD)
                    //addRow.hb2Sonota2   = " ";  //���̑�2 
                    if (string.IsNullOrEmpty(tempRow.kihyouBmnCd))
                    {
                        addRow.hb2Sonota2 = BLANK;
                    }
                    else
                    {
                        addRow.hb2Sonota2 = tempRow.kihyouBmnCd;
                    }

                    //���̑�3(�����Z���^)
                    //addRow.hb2Sonota3   = " ";  //���̑�3 
                    if (string.IsNullOrEmpty(tempRow.genkaCenter))
                    {
                        addRow.hb2Sonota3 = BLANK;
                    }
                    else
                    {
                        addRow.hb2Sonota3 = tempRow.genkaCenter;
                    }
                    /* 2017/04/14 �G�v�\���d����ύX�Ή� ITCOM A.Nakamura MOD End */

                    addRow.hb2Sonota4   = " ";  //���̑�4 
                    addRow.hb2Sonota5   = " ";  //���̑�5 
                    addRow.hb2Sonota6   = " ";  //���̑�6 
                    addRow.hb2Sonota7   = " ";  //���̑�7
                    addRow.hb2Sonota8   = " ";  //���̑�8 
                    addRow.hb2Sonota9   = " ";  //���̑�9
                    addRow.hb2Sonota10  = " ";  //���̑�10 
                    addRow.hb2BunFlg    = " ";  //�����t���O 
                    addRow.hb2MeihnFlg  = " ";  //�����ύX�t���O 
                    addRow.hb2NebhnFlg  = " ";  //�l�����ύX�t���O 

                    dtTHB2KMEIWork.AddTHB2KMEIRow(addRow);
                }
            }

            {
                // �������t���O�Ɩ��׃t���O���Z�o����.
                foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow in dtTHB1DOWNWork.Rows)
                {
                    Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow jyutyuRow = ((Isid.KKH.Common.KKHSchema.Detail.JyutyuDataRow[])jyutyuList.Select("hb1JyutNo = '" + thb1DownRow.hb1JyutNo + "' and hb1JyMeiNo = '" + thb1DownRow.hb1JyMeiNo + "' and hb1UrMeiNo = '" + thb1DownRow.hb1UrMeiNo + "'"))[0];

                    Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow[] thb2KmeiRows = (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow[])dtTHB2KMEIWork.Select("hb2Name21 = '1' and hb2JyutNo = '" + thb1DownRow.hb1JyutNo + "' and hb2JyMeiNo = '" + thb1DownRow.hb1JyMeiNo + "' and hb2UrMeiNo = '" + thb1DownRow.hb1UrMeiNo + "'", "");
                    {
                        // �������t���O�̎Z�o.
                        Decimal seiGak = 0M;

                        foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow thb2KmeiRow in thb2KmeiRows)
                        {
                            seiGak += thb2KmeiRow.hb2SeiGak;
                        }

                        if (jyutyuRow.hb1SeiGak == seiGak)
                        {
                            thb1DownRow.hb1MSeiFlg = "0";
                        }
                        else
                        {
                            thb1DownRow.hb1MSeiFlg = "1";
                        }
                    }

                    {
                        // ���׃t���O�̎Z�o.
                        if (thb2KmeiRows.Length == 0)
                        {
                            thb1DownRow.hb1MeisaiFlg = "0";
                        }
                        else
                        {
                            thb1DownRow.hb1MeisaiFlg = "1";
                        }
                    }

                    //
                    //���ׂ��Ȃ��ꍇ.
                    if (thb1DownRow.hb1MeisaiFlg.Equals("0"))
                    {
                        //�o�^�ҁA�X�V�҂���̏ꍇ.
                        if (string.IsNullOrEmpty(jyutyuRow.hb1TrkTntNm.Trim()) && string.IsNullOrEmpty(jyutyuRow.hb1KsnTntNm.Trim()))
                        {
                        }
                        //�o�^�҂�����ŁA�X�V�҂������Ă���ꍇ.
                        else if (string.IsNullOrEmpty(jyutyuRow.hb1TrkTntNm.Trim()) && !string.IsNullOrEmpty(jyutyuRow.hb1KsnTntNm.Trim()))
                        {
                        }
                        else
                        {
                            //�X�V�҂�o�^.
                            //�X�V��.
                            thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                            //�X�V�S���Җ�.
                            thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                        }
                    }
                    //���ׂ�����ꍇ 
                    else
                    {
                        //�o�^�S���҂��󂩂X�V�҂���łȂ��ꍇ 
                        if (string.IsNullOrEmpty(jyutyuRow.hb1TrkTntNm.Trim()) && !string.IsNullOrEmpty(jyutyuRow.hb1KsnTntNm.Trim()))
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
                        else if (string.IsNullOrEmpty(jyutyuRow.hb1TrkTntNm.Trim()))
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
                            //�o�^�� 
                            thb1DownRow.hb1TrkTnt = _naviParameter.strEsqId.Trim();
                            //�o�^�Җ� 
                            thb1DownRow.hb1TrkTntNm = _naviParameter.strName.Trim();

                            //�X�V�҂݂̂�����.
                            //�X�V��.
                            thb1DownRow.hb1KsnTnt = _naviParameter.strEsqId.Trim();
                            //�X�V�S���Җ�.
                            thb1DownRow.hb1KsnTntNm = _naviParameter.strName.Trim();
                        }
                    }
                }
            }

            {
                // �X�V�p�̃f�[�^�Z�b�g���쐬���� 
                String MeisaiSybtKey = null;
                String JyutNoKey = null;
                String JyMeiNoKey = null;
                String UrMeiNoKey = null;
                String SeikyuNoKey = null;

                foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow thb2KmeiRow in dtTHB2KMEIWork.Select("", "hb2Name21, hb2JyutNo, hb2JyMeiNo, hb2UrMeiNo, hb2Renbn, hb2Sonota1"))
                {
                    String MeisaiSybt = thb2KmeiRow.hb2Name21;

                    if (String.Equals(MeisaiSybt, "1"))
                    {
                        // �L����p����.
                        String JyutNo = thb2KmeiRow.hb2JyutNo;

                        String JyMeiNo = thb2KmeiRow.hb2JyMeiNo;

                        String UrMeiNo = thb2KmeiRow.hb2UrMeiNo;

                        if
                        (
                            ( String.Equals(MeisaiSybt, MeisaiSybtKey) ) &&
                            ( String.Equals(JyutNo, JyutNoKey) ) &&
                            ( String.Equals(JyMeiNo, JyMeiNoKey) ) &&
                            ( String.Equals(UrMeiNo, UrMeiNoKey) )
                        )
                        {
                            // �󒍔ԍ����ɂ܂Ƃ߂ď������邽�߃L�[�������ꍇ�͎��̃��R�[�h��.
                            continue;
                        }

                        // �X�V�p�f�[�^�Z�b�g.
                        Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

                        {
                            // �󒍃f�[�^�̍쐬.
                            Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable thb1Down = new Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable();

                            foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow thb1DownRow in dtTHB1DOWNWork.Select("hb1JyutNo = '" + JyutNo + "' and hb1JyMeiNo = '" + JyMeiNo + "' and hb1UrMeiNo = '" + UrMeiNo + "'", ""))
                            {
                                thb1Down.ImportRow(thb1DownRow);
                            }

                            dsDetail.THB1DOWN.Merge(thb1Down);
                        }

                        {
                            // ���׃f�[�^�̍쐬.
                            Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable thb2Kmei = new Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable();

                            foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow thb2KmeiRow2 in dtTHB2KMEIWork.Select("hb2Name21 = '1' and hb2JyutNo = '" + JyutNo + "' and hb2JyMeiNo = '" + JyMeiNo + "' and hb2UrMeiNo = '" + UrMeiNo + "'", "hb2JyutNo, hb2JyMeiNo, hb2UrMeiNo, hb2Renbn"))
                            {
                                thb2Kmei.ImportRow(thb2KmeiRow2);
                            }

                            dsDetail.THB2KMEI.Merge(thb2Kmei);
                        }

                        // ���X�g�ɒǉ�.
                        dsDetailList.Add(dsDetail);

                        // �L�[���X�V.
                        MeisaiSybtKey = MeisaiSybt;
                        JyutNoKey = JyutNo;
                        JyMeiNoKey = JyMeiNo;
                        UrMeiNoKey = UrMeiNo;
                        SeikyuNoKey = null;
                    }
                    else if (String.Equals(MeisaiSybt, "2"))
                    {
                        // ��������p���� 
                        String SeikyuNo = thb2KmeiRow.hb2Sonota1;

                        if
                        (
                            ( String.Equals(MeisaiSybt, MeisaiSybtKey) ) &&
                            ( String.Equals(SeikyuNo, SeikyuNoKey) )
                        )
                        {
                            // �󒍔ԍ����ɂ܂Ƃ߂ď������邽�߃L�[�������ꍇ�͎��̃��R�[�h��.
                            continue;
                        }

                        // �X�V�p�f�[�^�Z�b�g.
                        Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

                        {
                            // ���׃f�[�^�̍쐬.
                            Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable thb2Kmei = new Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable();

                            foreach (Isid.KKH.Common.KKHSchema.Detail.THB2KMEIRow thb2KmeiRow2 in dtTHB2KMEIWork.Select("hb2Name21 = '2' and hb2Sonota1 = '" + SeikyuNo + "'", "hb2Sonota1"))
                            {
                                thb2Kmei.ImportRow(thb2KmeiRow2);
                            }

                            dsDetail.THB2KMEI.Merge(thb2Kmei);
                        }

                        // ���X�g�ɒǉ�.
                        dsDetailList.Add(dsDetail);

                        // �L�[���X�V.
                        MeisaiSybtKey = MeisaiSybt;
                        JyutNoKey = null;
                        JyMeiNoKey = null;
                        UrMeiNoKey = null;
                        SeikyuNoKey = SeikyuNo;
                    }
                }
            }

            {
                // �ő�X�V���Ԃ̐ݒ� 
                // �G�v�\���͑S�󒍁E�S���ׂ��ꊇ�ōX�V����d�l�̂��ߓƎ������Ƃ��� 
                // �S�� 
                foreach (Isid.KKH.Common.KKHSchema.Detail.THB1DOWNRow row in _dsDetail.THB1DOWN.Rows)
                {
                    if (maxUpdDate == null || maxUpdDate.CompareTo(row.hb1TimStmp) < 0)
                    {
                        maxUpdDate = row.hb1TimStmp;
                    }
                }

                // �L����p����.
                foreach (DetailDSEpson.DetailDataEpsonRow row in _dsDetailEpson.DetailDataEpson.Rows)
                {
                    if (maxUpdDate == null || maxUpdDate.CompareTo(row.hb2TimStmp) < 0)
                    {
                        maxUpdDate = row.hb2TimStmp;
                    }
                }

                // ��������p����.
                foreach (DetailDSEpson.DetailDataEpsonRow row in _dsSeikyuDetailEpson.DetailDataEpson.Rows)
                {
                    if (maxUpdDate == null || maxUpdDate.CompareTo(row.hb2TimStmp) < 0)
                    {
                        maxUpdDate = row.hb2TimStmp;
                    }
                }
            }

            //**********************************************
            //���דo�^API���s 
            //**********************************************
            {
                DetailEpsonProcessController.BulkUpdateDetailDataEpsonParam param = new DetailEpsonProcessController.BulkUpdateDetailDataEpsonParam();
                param.egCd = _naviParameter.strEgcd;
                param.esqId = _naviParameter.strEsqId;
                param.tksKgyCd = _naviParameter.strTksKgyCd;
                param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
                param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
                param.yymm = Yymm;
                param.dsDetailList = dsDetailList;
                param.maxUpdDate = maxUpdDate;
                param.TourokuList = new Isid.KKH.Common.KKHSchema.Detail();
                param.TourokuList.THB1DOWN.Merge(dtTHB1DOWNWork);
                if (dsDetailList.Count == 0)
                {
                    //param.inputFlg = "0";
                }
                else
                {
                    param.inputFlg = "1";
                }

                DetailEpsonProcessController controller = DetailEpsonProcessController.GetInstance();

                BulkUpdateDetailDataEpsonServiceResult result = controller.BulkUpdateDetailDataEpson(param);

                if (result.HasError)
                {
                    base.CloseLoadingDialog();

                    if (result.MessageCode == "LOCK-E0001")
                    {
                        //�r���G���[ 
                        MessageUtility.ShowMessageBox(MessageCode.HB_W0148, null, "���דo�^", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageUtility.ShowMessageBox(MessageCode.HB_E0003, null, "���דo�^", MessageBoxButtons.OK);
                    }

                    return;
                }
            }

            _spdJyutyuList_Sheet1.SetActiveCell(0, 0, true);
            _spdJyutyuList_Sheet1.AddSelection(0, -1, 1, -1);
            spdJyutyuList.ShowActiveCell(VerticalPosition.Nearest, HorizontalPosition.Nearest);
            {
                Boolean state = isActivatedSeikyuList();

                // �󒍃f�[�^�̌���.
                ReSearchJyutyuData();

                // ��������f�[�^�̌���.
                SearchSeikyuKaisyuData();

                // �I����Ԃ����� 
                this.ActiveControl = null;

                // �{�^���̗L��������ύX.
                SetButtonEnable();

                // �f�[�^���N���A�������ߖ��וύX�t���O���I�t�ɂ���.
                kkhDetailUpdFlag = false;

                // �G���[�`�F�b�N.
                if (( _dsDetail.JyutyuList.Count == 0 ) && ( _dsSeikyuEpson.SeikyuHeader.Count == 0 ))
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "���̓G���[", MessageBoxButtons.OK);
                    txtYmd.Focus();
                    return;
                }

                if (state)
                {
                    // �^�u�ύX���̌����𖳌���.
                    _notSearchState = true;

                    // ��������f�[�^������ꍇ�͎����ł�������J��.
                    tabHed.SelectedIndex = 2;

                    // �^�u�ύX���̌�����L����.
                    _notSearchState = false;
                }
            }

            base.CloseLoadingDialog();
            MessageUtility.ShowMessageBox(MessageCode.HB_I0012, null, "���דo�^", MessageBoxButtons.OK);
        }
        #endregion ���דo�^����.

        #region �u���ԁv��\���p�̃t�H�[�}�b�g�ɕϊ����܂�.
        /// <summary>
        /// �u���ԁv��\���p�̃t�H�[�}�b�g�ɕϊ����܂�.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string FormatPeriod(string str)
        {
            string ret = "";

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
        #endregion �u���ԁv��\���p�̃t�H�[�}�b�g�ɕϊ����܂�.

        #region �}�X�^�����擾����.
        /// <summary>
        /// �}�X�^�����擾����.
        /// </summary>
        private void GetMasterData()
        {
            #region ������ʏ��̎擾.
            {
                // ������ʏ��}�X�^���擾.
                MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = process.FindMasterByCond
                (
                    _naviParameter.strEsqId,
                    _naviParameter.strEgcd,
                    _naviParameter.strTksKgyCd,
                    _naviParameter.strTksBmnSeqNo,
                    _naviParameter.strTksTntSeqNo,
                    KkhConstEpson.MasterKey.TRISIKI,
                    null
                );

                MasterMaintenance ds = result.MasterDataSet;
                MasterMaintenance.MasterDataVORow[] rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();

                List<string> lstKeys = new List<string>();
                List<string> lstValues = new List<string>();
                // ���I���ł���悤�ɂ���.
                lstKeys.Add(String.Empty);
                lstValues.Add(String.Empty);

                foreach (MasterMaintenance.MasterDataVORow row in rows)
                {
                    lstKeys.Add(row.Column1);
                    lstValues.Add(row.Column2 + " " + row.Column3);
                }

                _triSikiKey = lstKeys.ToArray();
                _triSikiValue = lstValues.ToArray();
            }
            #endregion ������ʏ��̎擾.

            #region ����S���ҏ��̎擾.
            {
                // ����S���҃}�X�^���擾.
                MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = process.FindMasterByCond
                (
                    _naviParameter.strEsqId,
                    _naviParameter.strEgcd,
                    _naviParameter.strTksKgyCd,
                    _naviParameter.strTksBmnSeqNo,
                    _naviParameter.strTksTntSeqNo,
                    KkhConstEpson.MasterKey.TRITNT,
                    null
                );

                MasterMaintenance ds = result.MasterDataSet;
                MasterMaintenance.MasterDataVORow[] rows = (MasterMaintenance.MasterDataVORow[])ds.MasterDataVO.Select();

                List<string> lstKeys = new List<string>();
                List<string> lstValues = new List<string>();
                // ���I���ł���悤�ɂ��� 
                lstKeys.Add(String.Empty);
                lstValues.Add(String.Empty);

                foreach (MasterMaintenance.MasterDataVORow row in rows)
                {
                    lstKeys.Add(row.Column1);

                    lstValues.Add(row.Column2);
                }

                _triTntKey = lstKeys.ToArray();
                _triTntValue = lstValues.ToArray();
            }
            #endregion ����S���ҏ��̎擾.

            /* 2017/04/17 �G�v�\���d����ύX�Ή� ITCOM A.Nakamura ADD Start */
            #region �N�[����R�[�h���̎擾.
            {
                // �N�[����R�[�h�}�X�^���擾.
                MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = process.FindMasterByCond
                (
                    _naviParameter.strEsqId,
                    _naviParameter.strEgcd,
                    _naviParameter.strTksKgyCd,
                    _naviParameter.strTksBmnSeqNo,
                    _naviParameter.strTksTntSeqNo,
                    KkhConstEpson.MasterKey.MST_KIHYOUBMNCD,
                    null
                );

                MasterMaintenance ds = result.MasterDataSet;
                drMasterData[] rows = (drMasterData[])ds.MasterDataVO.Select();

                List<string> lstKeys = new List<string>();
                List<string> lstValues = new List<string>();
                // ���I���ł���悤�ɂ��� 
                lstKeys.Add(String.Empty);
                lstValues.Add(String.Empty);

                foreach (drMasterData row in rows)
                {
                    lstKeys.Add(row.Column2);

                    lstValues.Add(row.Column2);
                }

                _kihyouBmnCdKey = lstKeys.ToArray();
                _kihyouBmnCdValue = lstValues.ToArray();
            }
            #endregion �N�[����R�[�h���̎擾.

            #region �����Z���^���̎擾.
            {
                // �����Z���^�}�X�^���擾.
                MasterMaintenanceProcessController process = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = process.FindMasterByCond
                (
                    _naviParameter.strEsqId,
                    _naviParameter.strEgcd,
                    _naviParameter.strTksKgyCd,
                    _naviParameter.strTksBmnSeqNo,
                    _naviParameter.strTksTntSeqNo,
                    KkhConstEpson.MasterKey.MST_GENKACENTER,
                    null
                );

                MasterMaintenance ds = result.MasterDataSet;
                drMasterData[] rows = (drMasterData[])ds.MasterDataVO.Select();

                List<string> lstKeys = new List<string>();
                List<string> lstValues = new List<string>();
                // ���I���ł���悤�ɂ��� 
                lstKeys.Add(String.Empty);
                lstValues.Add(String.Empty);

                foreach (drMasterData row in rows)
                {
                    lstKeys.Add(row.Column2);

                    lstValues.Add(row.Column2);
                }

                _genkaCenterKey = lstKeys.ToArray();
                _genkaCenterValue = lstValues.ToArray();
            }
            #endregion �����Z���^���̎擾.
            /* 2017/04/17 �G�v�\���d����ύX�Ή� ITCOM A.Nakamura ADD End */
        }
        #endregion �}�X�^�����擾����.
        
        #region �}�X�^�f�[�^�Ǘ�.
        #region �}�X�^�f�[�^.
        //***************************************************
        //�����f�[�^�ێ��pHashtable 
        //�@�ė��p����f�[�^(�}�X�^�f�[�^��)��ێ� 
        //***************************************************
        //�}�X�^�f�[�^ 
        Hashtable htMasterData = new Hashtable();
        #endregion �}�X�^�f�[�^.

        #region �ėp�}�X�^�̌������s��.
        /// <summary>
        /// �ėp�}�X�^�̌������s�� 
        /// ��x�擾�����f�[�^�͕ێ�����A�����ς݂̃}�X�^�f�[�^�͕ێ������f�[�^��ԋp���� 
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
                MasterMaintenanceProcessController controller = MasterMaintenanceProcessController.GetInstance();

                FindMasterMaintenanceByCondServiceResult result = controller.FindMasterByCond
                (
                    _naviParameter.strEsqId,
                    _naviParameter.strEgcd,
                    _naviParameter.strTksKgyCd,
                    _naviParameter.strTksBmnSeqNo,
                    _naviParameter.strTksTntSeqNo,
                    masterKey,
                    ""
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

        #region �L����p���דo�^.
        /// <summary>
        /// �L����p���דo�^.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean SetDetailData(int index)
        {
            Boolean retval = false;
            Boolean state = false;
            Common.KKHSchema.Detail.JyutyuDataRow jyutyuRow = getSelectJyutyuData(index);
            String meisaiNoKey = jyutyuRow.hb1JyutNo + "-" + jyutyuRow.hb1JyMeiNo + "-" + jyutyuRow.hb1UrMeiNo;

            foreach (DetailDSEpson.KkhDetailRow detailRow in _dsDetailEpson.KkhDetail.Rows)
            {
                if (!String.Equals(detailRow.uriMeiNo.Trim(), meisaiNoKey))
                {
                    continue;
                }

                // ���ɖ��ׂ��o�^����Ă���.
                state = true;

                // �������I��.
                break;
            }

            // �o�^�ς݂̖��ׂ��݂���Ȃ����ꍇ�͓o�^���s��.
            if (state == false)
            {
                // ���ׂɃf�[�^���Z�b�g���� 
                SetDetailDataSub(jyutyuRow);

                retval = true;
            }

            return retval;
        }
        #endregion �L����p���דo�^.

        #region ��������p���דo�^.
        /// <summary>
        /// ��������p���דo�^.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Boolean SetSeikyuDetailData(int index, out String errtype)
        {
            // �߂�ϐ�������.
            // ���o�^����:FIN
            // ��������f�[�^:DEL
            errtype = String.Empty;

            Boolean retval = false;
            Boolean state = false;
            String seikyuNoKey = null;
            SeikyuDsEpson.SeikyuListDataTable dtSeikyuList = new SeikyuDsEpson.SeikyuListDataTable();

            // �������ԍ�������o��.
            SeikyuDsEpson.SeikyuHeaderRow seikyuHeaderRow = getSelectSeikyuHeaderData(index);
            seikyuNoKey = seikyuHeaderRow.seikyuNo.Trim();

            // �������Ă��鐿���f�[�^�͑ΏۊO.
            if (seikyuHeaderRow.seiStatus.Equals("3"))
            {
                errtype = "DEL";
                return retval;
            }
            
            // �������ԍ��ɕR�t���������X�g������o��.
            SeikyuDsEpson.SeikyuListRow[] seikyuListRows = (SeikyuDsEpson.SeikyuListRow[])_dsSeikyuEpson.SeikyuList.Select("seikyuNo = '" + seikyuNoKey + "'", "seikyuNo, seikyuMeiNo");

            foreach (SeikyuDsEpson.SeikyuListRow seikyuListRow in seikyuListRows)
            {
                dtSeikyuList.ImportRow(seikyuListRow);
            }

            foreach (DetailDSEpson.KkhDetailRow detailRow in _dsSeikyuDetailEpson.KkhDetail.Rows)
            {
                if (!String.Equals(detailRow.seiNo.Trim(), seikyuNoKey))
                {
                    continue;
                }

                // ���ɖ��ׂ��o�^����Ă���.
                state = true;
                errtype = "FIN";

                // �������I��.
                break;
            }

            // �o�^�ς݂̖��ׂ��݂���Ȃ����ꍇ�͓o�^���s��.
            if (state == false)
            {
                // �����w�b�_���擾.
                SeikyuDsEpson.THB14SKDOWNRow[] thb14SkdownRows = (SeikyuDsEpson.THB14SKDOWNRow[])_dsSeikyuEpson.THB14SKDOWN.Select("hb14SeiNo = '" + seikyuNoKey.Replace("-", "") + "'", "hb14SeiNo, hb14SeiMeiNo");

                SeikyuDsEpson.THB14SKDOWNRow thb14SkdownRow = thb14SkdownRows[0];

                // �L����p���׊i�[�p.
                DetailDSEpson.KkhDetailDataTable dtDetail = new DetailDSEpson.KkhDetailDataTable();

                foreach (SeikyuDsEpson.SeikyuListRow seikyuListRow in dtSeikyuList.Rows)
                {
                    String meisaiNoKey = seikyuListRow.uriMeiNo;

                    foreach (DetailDSEpson.KkhDetailRow detailRow in _dsDetailEpson.KkhDetail.Rows)
                    {
                        // �L�[���Ⴄ�ꍇ�͏����ΏۊO.
                        if (!String.Equals(detailRow.uriMeiNo.Trim(), meisaiNoKey))
                        {
                            continue;
                        }

                        // ���R�[�h�������Ώۂɒǉ�.
                        dtDetail.ImportRow(detailRow);
                    }
                }

                // ���ׂɃf�[�^���Z�b�g���� 
                SetSeikyuDetailDataSub(thb14SkdownRow, dtDetail);
                retval = true;
            }

            return retval;
        }
        #endregion ��������p���דo�^.

        #region ���׃f�[�^�ݒ菈��.
        /// <summary>
        /// ���׃f�[�^�ݒ菈��.
        /// </summary>
        /// <param name="jyutyuRow"></param>
        private void SetDetailDataSub(Common.KKHSchema.Detail.JyutyuDataRow jyutyuRow)
        {
            // �L����וύX�t���O���X�V 
            base.kkhDetailUpdFlag = true;

            // �L����p����.
            DetailDSEpson.KkhDetailRow row = _dsDetailEpson.KkhDetail.NewKkhDetailRow();

            // ���׃X�v���b�h�ɒl��ݒ� 

            //�����ΏۊO�t���O.
            row.seiFlg = false.ToString();

            //�����ԍ�.
            row.seiNo = "";

            //���㖾�ׂm�n.
            row.uriMeiNo = jyutyuRow.hb1JyutNo + "-" + jyutyuRow.hb1JyMeiNo + "-" + jyutyuRow.hb1UrMeiNo;

            //�L������.
            row.koukokuKenmei = jyutyuRow.hb1KKNameKJ;

            // ����S���҃R�[�h.
            row.triTntCd = "";

            //����(�����敪�ɂĕ���)
            if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.NewsPaper)
            {
                //�V���f�[�^ 
                string MEKbn = string.Empty;

                if (jyutyuRow.hb1Field4.Trim().Equals("1"))
                {
                    MEKbn = "����";
                }
                else if (jyutyuRow.hb1Field4.Trim().Equals("2"))
                {
                    MEKbn = "�[��";
                }

                row.kenmei = jyutyuRow.hb1Field2 + " " + MEKbn + " " + jyutyuRow.hb1Field11;
            }
            else if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Magazine)
            {
                //�G���f�[�^ 
                row.kenmei = jyutyuRow.hb1Field2 + " " + jyutyuRow.hb1Field3;
            }
            else if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Time)
            {
                //�^�C���f�[�^ 
                row.kenmei = jyutyuRow.hb1Field2 + " " + jyutyuRow.hb1Field3;
            }
            else if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Spot)
            {
                //�X�|�b�g�f�[�^ 
                row.kenmei = jyutyuRow.hb1Field2 + " " + jyutyuRow.hb1Field3;
            }
            else if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Works)
            {
                //����ƃf�[�^  
                String hosoku;

                if (!String.IsNullOrEmpty(jyutyuRow.hb1Field4))
                {
                    // �⑫���e�i�����j���g��.
                    hosoku = jyutyuRow.hb1Field4;
                }
                else if (!String.IsNullOrEmpty(jyutyuRow.hb1Field3))
                {
                    // ��ڕ⑫���g��.
                    hosoku = jyutyuRow.hb1Field3;
                }
                else
                {
                    // �󕶎��ɂ���.
                    hosoku = String.Empty;
                }

                row.kenmei = hosoku;
            }
            else if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.Ooh)
            {
                //��ʍL���f�[�^ 
                row.kenmei = jyutyuRow.hb1Field4;
            }
            else if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.KMas)
            {
                //����/�}�X�f�[�^ 
                row.kenmei = jyutyuRow.hb1Field11;
            }
            else if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.KWorks)
            {
                //����/����ƃf�[�^ 
                row.kenmei = jyutyuRow.hb1Field12;
            }
            else if (jyutyuRow.hb1SeiKbn == KKHSystemConst.SeiKbn.IC)
            {
                //IC(�C���^���N�e�B�u���f�B�A) 
                row.kenmei = jyutyuRow.hb1Field2 + " " + jyutyuRow.hb1Field4;
            }
            else
            {
                //��L�ȊO�̓f�t�H���g��\�L.
                row.kenmei = "";
            }

            // ������ʖ���.
            row.triSikiKeyCd = "";

            /* 2017/04/17 �G�v�\���d����ύX�Ή� ITCOM A.Nakamura ADD Start */
            // �N�[����CD.
            row.kihyouBmnCd = BLANK;

            // �����Z���^.
            row.genkaCenter = BLANK;
            /* 2017/04/17 �G�v�\���d����ύX�Ή� ITCOM A.Nakamura ADD End */

            // ���O���z.
            row.bfKngk = jyutyuRow.hb1SeiGak;

            // ������z.
            row.afKngk = 0M;

            // �Ɩ��敪.
            row.baitaiCd = jyutyuRow.hb1GyomKbn;

            // �����敪.
            row.seiKbn = jyutyuRow.hb1SeiKbn;

            // ����S���Җ�.
            row.triTntNm = "";

            // ������ʃR�[�h.
            row.triSikiCd = "";

            // ������ʖ���.
            row.triSikiNm = "";

            // �w�}�m�n.
            row.ssNo = "";

            // �Z�O�����g�m�n.
            row.segNo = "";

            // �\�[�g�L�[.
            row.sortKey = "";

            // ���z�i�ō��݁j.
            row.seiKingaku = 0M;

            // �����.
            row.zeiGaku = jyutyuRow.hb1SzeiGak;

            // �Ŕ������z.
            row.zeiNKingaku = 0M;

            // �v���.
            row.keizyoBi = "";

            // ���R�[�h��ǉ�.
            _dsDetailEpson.KkhDetail.AddKkhDetailRow(row);
        }
        #endregion ���׃f�[�^�ݒ菈��.

        #region ��������p���׃f�[�^�ݒ菈��.
        /// <summary>
        /// ��������p���׃f�[�^�ݒ菈��.
        /// </summary>
        /// <param name="thb14SkdownRow"></param>
        /// <param name="dt"></param>
        private void SetSeikyuDetailDataSub(SeikyuDsEpson.THB14SKDOWNRow thb14SkdownRow, DetailDSEpson.KkhDetailDataTable dt)
        {
            // �L����וύX�t���O���X�V 
            base.kkhDetailUpdFlag = true;

            // ��������p����.
            DetailDSEpson.KkhDetailRow row = _dsSeikyuDetailEpson.KkhDetail.NewKkhDetailRow();

            // ���׃X�v���b�h�ɒl��ݒ�.

            // �����ΏۊO�t���O.
            row.seiFlg = false.ToString();

            // �����ԍ�.
            if (thb14SkdownRow.hb14SeiNo.Length == 12)
            {
                row.seiNo = thb14SkdownRow.hb14SeiNo.Substring(0, 8) + "-" + thb14SkdownRow.hb14SeiNo.Substring(8, 4);
            }
            else
            {
                row.seiNo = thb14SkdownRow.hb14SeiNo;
            }

            // ���㖾�ׂm�n.
            row.uriMeiNo = thb14SkdownRow.hb14JyutNo + "-" + thb14SkdownRow.hb14JyMeiNo + "-" + thb14SkdownRow.hb14UrMeiNo;

            // �L������.
            row.koukokuKenmei = thb14SkdownRow.hb14KouNameUp;

            // ����S���҃R�[�h.
            row.triTntCd = "";

            // ����.
            row.kenmei = "";

            // ��������.
            row.seiKenmei = thb14SkdownRow.hb14KouNameUp + thb14SkdownRow.hb14KouNameDown;

            // ������ʖ���.
            row.triSikiKeyCd = "";

            /* 2017/04/17 �G�v�\���d����ύX�Ή� ITCOM A.Nakamura ADD Start */
            // �N�[����CD.
            row.kihyouBmnCd = BLANK;

            // �����Z���^.
            row.genkaCenter = BLANK;
            /* 2017/04/17 �G�v�\���d����ύX�Ή� ITCOM A.Nakamura ADD End */

            // ���O���z.
            row.bfKngk = 0M;

            // ������z.
            row.afKngk = 0M;

            // �Ɩ��敪.
            row.baitaiCd = "";

            // �����敪.
            row.seiKbn = "";

            // ����S���Җ�.
            row.triTntNm = "";

            // ������ʃR�[�h.
            row.triSikiCd = "";

            // ������ʖ���.
            row.triSikiNm = "";

            // �w�}�m�n.
            row.ssNo = "";

            // �Z�O�����g�m�n.
            row.segNo = "";

            // �\�[�g�L�[.
            row.sortKey = "";

            // ���z�i�ō��݁j.
            row.seiKingaku = thb14SkdownRow.hb14SeigakGk;

            // �����.
            row.zeiGaku = thb14SkdownRow.hb14SzeigakGk;

            // �Ŕ������z.
            row.zeiNKingaku = thb14SkdownRow.hb14TorigakGk - thb14SkdownRow.hb14NebigakGk;

            // �v���.
            if (thb14SkdownRow.hb14SeiHakDate.Length == 8)
            {
                row.keizyoBi = thb14SkdownRow.hb14SeiHakDate.Substring(0, 4) + "/" + thb14SkdownRow.hb14SeiHakDate.Substring(4, 2) + "/" + thb14SkdownRow.hb14SeiHakDate.Substring(6, 2);
            }
            else
            {
                row.keizyoBi = thb14SkdownRow.hb14SeiHakDate;
            }

            // �L����p���ׂ̋��z�����Z���ĎZ�o.
            foreach (DetailDSEpson.KkhDetailRow detailRow in dt.Rows)
            {
                DetailDSEpson.KkhDetailRow tempRow = _dsSeikyuDetailEpson.KkhDetail.NewKkhDetailRow();

                DBNullToEmptyOrZero(tempRow, detailRow);

                if (( String.IsNullOrEmpty(row.triTntCd) ) && ( !String.IsNullOrEmpty(tempRow.triTntCd) ))
                {
                    // ����S���҃R�[�h.
                    row.triTntCd = tempRow.triTntCd;

                    // ����S���Җ�.
                    row.triTntNm = tempRow.triTntNm;
                }

                if (( String.IsNullOrEmpty(row.triSikiKeyCd) ) && ( !String.IsNullOrEmpty(tempRow.triSikiKeyCd) ))
                {
                    // ������ʖ��́i�L�[�R�[�h�j.
                    row.triSikiKeyCd = tempRow.triSikiKeyCd;

                    // ������ʃR�[�h.
                    row.triSikiCd = tempRow.triSikiCd;

                    // ������ʖ���.
                    row.triSikiNm = tempRow.triSikiNm;

                    // �w�}�m�n.
                    row.ssNo = tempRow.ssNo;

                    // �Z�O�����g�m�n.
                    row.segNo = tempRow.segNo;

                    // �\�[�g�L�[.
                    row.sortKey = tempRow.sortKey;
                }
            }

            // ���R�[�h��ǉ�.
            _dsSeikyuDetailEpson.KkhDetail.AddKkhDetailRow(row);
        }
        #endregion ��������p���׃f�[�^�ݒ菈��.

        #region �e�{�^���̎g�p�E�s�ݒ�𐧌䂷��.
        /// <summary>
        /// �e�{�^���̎g�p�E�s�ݒ�𐧌䂷��.
        /// </summary>
        private void SetButtonEnable()
        {
            // �����Ώۂ��L����f�[�^�̏ꍇ.
            if (isActivatedJyutyuList())
            {
                if (_dsDetail.JyutyuList.Rows.Count != 0)
                {
                    btnYmChange.Enabled = true;
                    btnRegJyutyu.Enabled = true;
                    btnDelJyutyu.Enabled = true;
                    btnUpdateCheck.Enabled = true;
                    btnRegister.Enabled = true;
                    btnRegBulk.Enabled = true;
                    btnReqBind.Enabled = false;
                    btnDetailRegister.Enabled = true;
                    btnMerge.Enabled = true;
                    btnMergeCancel.Enabled = true; 
                }
                else
                {
                    btnYmChange.Enabled = false;
                    btnRegJyutyu.Enabled = false;
                    btnDelJyutyu.Enabled = false;
                    btnUpdateCheck.Enabled = false;
                    btnRegister.Enabled = false;
                    btnRegBulk.Enabled = false;
                    btnReqBind.Enabled = false;
                    btnDetailRegister.Enabled = false;
                    btnMerge.Enabled = false;
                    btnMergeCancel.Enabled = false; 
                }
            }
            // �����Ώۂ�����������f�[�^�̏ꍇ.
            else if (isActivatedSeikyuList())
            {
                if (_dsSeikyuEpson.SeikyuHeader.Rows.Count != 0)
                {
                    btnYmChange.Enabled = false;
                    btnRegJyutyu.Enabled = false;
                    btnDelJyutyu.Enabled = false;
                    btnUpdateCheck.Enabled = false;
                    btnRegister.Enabled = true;
                    btnRegBulk.Enabled = false;
                    btnReqBind.Enabled = true;
                    btnDetailRegister.Enabled = true;
                    btnMerge.Enabled = false;
                    btnMergeCancel.Enabled = false;
                }
                else
                {
                    btnYmChange.Enabled = false;
                    btnRegJyutyu.Enabled = false;
                    btnDelJyutyu.Enabled = false;
                    btnUpdateCheck.Enabled = false;
                    btnRegister.Enabled = false;
                    btnRegBulk.Enabled = false;
                    btnReqBind.Enabled = false;
                    btnDetailRegister.Enabled = false;
                    btnMerge.Enabled = false;
                    btnMergeCancel.Enabled = false;
                }
            }

            // �L����׃f�[�^������ꍇ 
            if (_spdKkhDetail_Sheet1.RowCount > 0)
            {
                btnDetailInput.Enabled = true;
                btnDetailDel.Enabled = true;
            }
            //�L����׃f�[�^���Ȃ��ꍇ 
            else
            {
                btnDetailInput.Enabled = false;
                btnDetailDel.Enabled = false;
            }
        }
        #endregion �e�{�^���̎g�p�E�s�ݒ�𐧌䂷��.

        #region �f�[�^�\�[�X���X�V���܂�.
        /// <summary>
        /// �f�[�^�\�[�X���X�V���܂�.
        /// </summary>
        /// <param name="dsDetail">�L����ד��̓f�[�^�Z�b�g</param>
        private void UpdateDataSourceByDetail(Isid.KKH.Common.KKHSchema.Detail dsDetail)
        {
            _dsDetail.Clear();
            _dsDetail.Merge(dsDetail);
            _dsDetail.AcceptChanges();
        }
        #endregion �f�[�^�\�[�X���X�V���܂�.

        #region ��������f�[�^�����E�\������.
        /// <summary>
        /// ��������f�[�^�����E�\������.
        /// </summary>
        ///// <param name="reLoadFlag">�Č����t���O(True�F�Č����AFalse�F�ʏ팟��)</param>
        protected void SearchSeikyuKaisyuData()
        {
            //���������̎擾.
            findSeikyuKaisyuDataCond = CreateServiceParamForFindSeikyuKaisyuDataByCond();

            DetailEpsonProcessController controller = DetailEpsonProcessController.GetInstance();
            findSeikyuKaisyuDataCond.updateCheckFlag = false;
            FindSeikyuDataEpsonByCondServiceResult result = controller.FindSeikyuKaisyuDataByCond(findSeikyuKaisyuDataCond);
            Isid.KKH.Epson.Schema.SeikyuDsEpson dsSeikyu = result.SeikyuEpsonDataSet;
            dsSeikyu.UpdateSpdDataBySeikyuData();

            {
                // �������X�g���w�b�_���ɂ܂Ƃ߂� 
                String seikyuNoKey = null;
                SeikyuDsEpson ds = new SeikyuDsEpson();
                SeikyuDsEpson.SeikyuHeaderRow seikyuHeaderRow = null;

                foreach (SeikyuDsEpson.SeikyuListRow seikyuListRow in dsSeikyu.SeikyuList)
                {
                    if (String.Equals(seikyuListRow.seikyuNo, seikyuNoKey))
                    {
                        continue;
                    }

                    if (seikyuNoKey != null)
                    {
                        ds.SeikyuHeader.AddSeikyuHeaderRow(seikyuHeaderRow);
                    }

                    // �V�K���R�[�h�̍쐬.
                    seikyuHeaderRow = ds.SeikyuHeader.NewSeikyuHeaderRow();

                    // �������ԍ�.
                    seikyuHeaderRow.seikyuNo = seikyuListRow.seikyuNo;

                    // ����.
                    seikyuHeaderRow.kenmei = seikyuListRow.kenmei;

                    // ���z�i�ō��݁j.
                    seikyuHeaderRow.seiKingakuGk = seikyuListRow.seiKingakuGk;

                    // ����Ŋz.
                    seikyuHeaderRow.zeiGakuGk = seikyuListRow.zeiGakuGk;

                    // ���z�i�Ŕ����j.
                    seikyuHeaderRow.zeiNKingakuGk = seikyuListRow.zeiNKingakuGk;

                    // �v���.
                    seikyuHeaderRow.keiYymm = seikyuListRow.keiYymm;

                    // �����X�e�[�^�X.
                    seikyuHeaderRow.seiStatus = seikyuListRow.seiStatus;

                    // �L�[�̍X�V.
                    seikyuNoKey = seikyuListRow.seikyuNo;

                    // ���f�}�[�N.
                    {
                        if( _dsSeikyuDetailEpson.KkhDetail.Select("seiNo = '" + seikyuListRow.seikyuNo + "'", "").Length != 0 )
                        {
                            seikyuHeaderRow.hannei = "��";
                        }
                        else
                        {
                            seikyuHeaderRow.hannei = "";
                        }
                    }
                }

                if (seikyuNoKey != null)
                {
                    ds.SeikyuHeader.AddSeikyuHeaderRow(seikyuHeaderRow);
                }

                dsSeikyu.SeikyuHeader.Merge(ds.SeikyuHeader);
            }

            //�f�[�^�\�[�X�X�V .
            UpdateDataSourceBySeikyuDataSetEpson(dsSeikyu);

            //�\�[�g�C���W�P�[�^�̃��Z�b�g.
            ResetSortIndicator(_spdSeikyuList_Sheet1);

            InitDesignForSpdSeikyuListChild();

            // ���X�g������.
            seiNoList = new List<string>();

            // �F�ύX.
            for (int i = 0; i < _spdSeikyuList_Sheet1.Rows.Count; i++)
            {
                if (_spdSeikyuList_Sheet1.Cells[i, 7].Text.Equals("3"))
                {
                    // �����X�e�[�^�X��3(���)�̏ꍇ�͔w�i�F��ύX .
                    _spdSeikyuList_Sheet1.Rows[i].BackColor = Color.FromArgb(165, 165, 165);
                    // �������ԍ������X�g�ɒǉ�.
                    seiNoList.Add(_spdSeikyuList_Sheet1.Cells[i, COLIDX_SHLIST_SEIKYUNO].Text);
                }

                FarPoint.Win.Spread.SheetView s;
                //�e�e�s�Ɋ֘A����q�r���[���擾���܂� .
                s = _spdSeikyuList_Sheet1.GetChildView(i, 0);
                for (int j = 0; j < s.Rows.Count; j++)
                {
                    if (s.Cells[j, 12].Text.Equals("3"))
                    {
                        // �����X�e�[�^�X��3(���)�̏ꍇ�͔w�i�F��ύX .
                        s.Rows[j].BackColor = Color.FromArgb(165, 165, 165);
                        // �������ԍ������X�g�ɒǉ�.
                        seiNoList.Add(_spdSeikyuList_Sheet1.Cells[i, COLIDX_SHLIST_SEIKYUNO].Text);
                    }
                }
            }
        }
        #endregion ��������f�[�^�����E�\������.

        #region �������X�g�q�r���[�̃X�v���b�h���.
        /// <summary>
        /// �������X�g�q�r���[�̃X�v���b�h���.
        /// </summary>
        private void InitDesignForSpdSeikyuListChild()
        {
            for (int i = 0; i < _spdSeikyuList_Sheet1.RowCount; i++)
            {
                FarPoint.Win.Spread.SheetView sheet = _spdSeikyuList_Sheet1.GetChildView(i, 0);

                sheet.DataAutoSizeColumns = _spdSeikyuList_Sheet1.DataAutoSizeColumns;
                sheet.DataAutoCellTypes = _spdSeikyuList_Sheet1.DataAutoCellTypes;
                sheet.ActiveSkin = _spdSeikyuList_Sheet1.ActiveSkin;

                sheet.ColumnHeader.Rows[0].Height = 30F;

                sheet.Columns[COLIDX_SCLIST_HANNEI].DataField = "hannei";
                sheet.Columns[COLIDX_SCLIST_HANNEI].Label = "���f";
                sheet.Columns[COLIDX_SCLIST_HANNEI].Width = 20F;
                sheet.Columns[COLIDX_SCLIST_HANNEI].Locked = true;
                sheet.Columns[COLIDX_SCLIST_HANNEI].Visible = false;
                sheet.Columns[COLIDX_SCLIST_HANNEI].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                sheet.Columns[COLIDX_SCLIST_HANNEI].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_SEIKYUNO].DataField = "seikyuNo";
                sheet.Columns[COLIDX_SCLIST_SEIKYUNO].Label = "�������ԍ�";
                sheet.Columns[COLIDX_SCLIST_SEIKYUNO].Locked = true;
                sheet.Columns[COLIDX_SCLIST_SEIKYUNO].Visible = false;
                sheet.Columns[COLIDX_SCLIST_SEIKYUNO].Width = 120F;
                sheet.Columns[COLIDX_SCLIST_SEIKYUNO].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_SEIKYUMEINO].DataField = "seikyuMeiNo";
                sheet.Columns[COLIDX_SCLIST_SEIKYUMEINO].Label = "������\n���הԍ�";
                sheet.Columns[COLIDX_SCLIST_SEIKYUMEINO].Locked = true;
                sheet.Columns[COLIDX_SCLIST_SEIKYUMEINO].Width = 90F;
                sheet.Columns[COLIDX_SCLIST_SEIKYUMEINO].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_URIMEINO].DataField = "uriMeiNo";
                sheet.Columns[COLIDX_SCLIST_URIMEINO].Label = "���㖾��NO";
                sheet.Columns[COLIDX_SCLIST_URIMEINO].Locked = true;
                sheet.Columns[COLIDX_SCLIST_URIMEINO].Width = 150F;
                sheet.Columns[COLIDX_SCLIST_URIMEINO].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_KENMEI].DataField = "kenmei";
                sheet.Columns[COLIDX_SCLIST_KENMEI].Label = "����";
                sheet.Columns[COLIDX_SCLIST_KENMEI].Locked = true;
                sheet.Columns[COLIDX_SCLIST_KENMEI].Visible = false;
                sheet.Columns[COLIDX_SCLIST_KENMEI].Width = 200F;
                sheet.Columns[COLIDX_SCLIST_KENMEI].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_SEIKINGAKUGK].DataField = "seiKingakuGk";
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKUGK].Label = "���z���v�i�ō��݁j";
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKUGK].Locked = true;
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKUGK].Visible = false;
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKUGK].Width = 120F;
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKUGK].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_ZEIGAKUGK].DataField = "zeiGakuGk";
                sheet.Columns[COLIDX_SCLIST_ZEIGAKUGK].Label = "�Ŋz���v";
                sheet.Columns[COLIDX_SCLIST_ZEIGAKUGK].Locked = true;
                sheet.Columns[COLIDX_SCLIST_ZEIGAKUGK].Visible = false;
                sheet.Columns[COLIDX_SCLIST_ZEIGAKUGK].Width = 100F;
                sheet.Columns[COLIDX_SCLIST_ZEIGAKUGK].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKUGK].DataField = "zeiNKingakuGk";
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKUGK].Label = "�Ŕ������z���v";
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKUGK].Locked = true;
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKUGK].Visible = false;
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKUGK].Width = 100F;
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKUGK].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_SEIKINGAKU].DataField = "seiKingaku";
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKU].Label = "���z�i�ō��݁j";
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKU].Locked = true;
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKU].Width = 100F;
                sheet.Columns[COLIDX_SCLIST_SEIKINGAKU].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_ZEIGAKU].DataField = "zeiGaku";
                sheet.Columns[COLIDX_SCLIST_ZEIGAKU].Label = "�Ŋz";
                sheet.Columns[COLIDX_SCLIST_ZEIGAKU].Locked = true;
                sheet.Columns[COLIDX_SCLIST_ZEIGAKU].Width = 100F;
                sheet.Columns[COLIDX_SCLIST_ZEIGAKU].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKU].DataField = "zeiNKingaku";
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKU].Label = "�Ŕ������z";
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKU].Locked = true;
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKU].Width = 100F;
                sheet.Columns[COLIDX_SCLIST_ZEINKINGAKU].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_KEIYYMM].DataField = "keiYymm";
                sheet.Columns[COLIDX_SCLIST_KEIYYMM].Label = "�v���";
                sheet.Columns[COLIDX_SCLIST_KEIYYMM].Locked = true;
                sheet.Columns[COLIDX_SCLIST_KEIYYMM].Width = 100F;
                sheet.Columns[COLIDX_SCLIST_KEIYYMM].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                sheet.Columns[COLIDX_SCLIST_SEISTATUS].DataField = "seistatus";
                sheet.Columns[COLIDX_SCLIST_SEISTATUS].Label = "�����X�e�[�^�X";
                sheet.Columns[COLIDX_SCLIST_SEISTATUS].Locked = true;
                sheet.Columns[COLIDX_SCLIST_SEISTATUS].Visible = false;
                sheet.Columns[COLIDX_SCLIST_SEISTATUS].Width = 100F;
                sheet.Columns[COLIDX_SCLIST_SEISTATUS].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                foreach( FarPoint.Win.Spread.Row row in sheet.Rows )
                {
                    FarPoint.Win.Spread.CellType.NumberCellType cellTypeNumber = new FarPoint.Win.Spread.CellType.NumberCellType();

                    cellTypeNumber.DecimalPlaces = 0;
                    cellTypeNumber.Separator = ",";
                    cellTypeNumber.ShowSeparator = true;

                    sheet.Cells[ row.Index, COLIDX_SCLIST_SEIKINGAKUGK ].CellType = cellTypeNumber;
                    sheet.Cells[ row.Index, COLIDX_SCLIST_ZEIGAKUGK    ].CellType = cellTypeNumber;
                    sheet.Cells[ row.Index, COLIDX_SCLIST_ZEINKINGAKUGK].CellType = cellTypeNumber;
                    sheet.Cells[ row.Index, COLIDX_SCLIST_SEIKINGAKU   ].CellType = cellTypeNumber;
                    sheet.Cells[ row.Index, COLIDX_SCLIST_ZEIGAKU      ].CellType = cellTypeNumber;
                    sheet.Cells[ row.Index, COLIDX_SCLIST_ZEINKINGAKUGK].CellType = cellTypeNumber;
                }
            }
        }
        #endregion �������X�g�q�r���[�̃X�v���b�h���.

        #region ��������f�[�^����API���s�p�����[�^����.
        /// <summary>
        /// ��������f�[�^����API���s�p�����[�^����.
        /// </summary>
        /// <returns></returns>
        protected virtual DetailEpsonProcessController.FindSeikyuKaisyuDataByCondParam CreateServiceParamForFindSeikyuKaisyuDataByCond()
        {
            DetailEpsonProcessController.FindSeikyuKaisyuDataByCondParam param = new DetailEpsonProcessController.FindSeikyuKaisyuDataByCondParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = txtYmd.Value;

            return param;
        }
        #endregion ��������f�[�^����API���s�p�����[�^����.

        #region ��������̃f�[�^�\�[�X�X�V.
        /// <summary>
        /// ��������̃f�[�^�\�[�X�X�V.
        /// </summary>
        /// <param name="dsDetailEpson"></param>
        private void UpdateDataSourceBySeikyuDataSetEpson(SeikyuDsEpson dsSeikyuEpson)
        {
            _dsSeikyuEpson.Clear();
            _dsSeikyuEpson.Merge(dsSeikyuEpson);
            _dsSeikyuEpson.AcceptChanges();
        }
        #endregion ��������̃f�[�^�\�[�X�X�V.

        #region �w�肵���󒍓o�^���e(�ꗗ)�̍s�ɕR�Â������󒍓o�^���e�f�[�^���擾����.
        /// <summary>
        /// �w�肵���󒍓o�^���e(�ꗗ)�̍s�ɕR�Â������󒍓o�^���e�f�[�^���擾����.
        /// </summary>
        /// <param name="rowIndex">�󒍓o�^���e(�ꗗ)�̍s�C���f�b�N�X</param>
        /// <returns></returns>
        protected SeikyuDsEpson.SeikyuHeaderRow getSelectSeikyuHeaderData(int rowIndex)
        {
            if (rowIndex < 0)
            {
                rowIndex = _spdSeikyuList_Sheet1.ActiveRowIndex;
            }

            String seikyuNo = _spdSeikyuList_Sheet1.Cells[rowIndex, COLIDX_SHLIST_SEIKYUNO].Text;

            return (SeikyuDsEpson.SeikyuHeaderRow)( _dsSeikyuEpson.SeikyuHeader.Select("seikyuNo = '" + seikyuNo + "'")[0] );
        }
        #endregion �w�肵���󒍓o�^���e(�ꗗ)�̍s�ɕR�Â������󒍓o�^���e�f�[�^���擾����.

        #region �󒍃��X�g���A�N�e�B�u����Ԃ�.
        /// <summary>
        /// �󒍃��X�g���A�N�e�B�u����Ԃ�.
        /// </summary>
        /// <returns></returns>
        private Boolean isActivatedJyutyuList()
        {
            return
            (
                ( tabHed.SelectedIndex == 0 ) ||
                ( tabHed.SelectedIndex == 1 )
            );
        }
        #endregion �󒍃��X�g���A�N�e�B�u����Ԃ�.

        #region ����������X�g���A�N�e�B�u����Ԃ�.
        /// <summary>
        /// ����������X�g���A�N�e�B�u����Ԃ�.
        /// </summary>
        /// <returns></returns>
        private Boolean isActivatedSeikyuList()
        {
            return
            (
                ( tabHed.SelectedIndex == 2 )
            );
        }
        #endregion ����������X�g���A�N�e�B�u����Ԃ�.

        #region �f�[�^�s����DBNull���󕶎���0�ɕϊ�����.
        /// <summary>
        /// �f�[�^�s����DBNull���󕶎���0�ɕϊ�����.
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        private void DBNullToEmptyOrZero(DetailDSEpson.KkhDetailRow to, DetailDSEpson.KkhDetailRow from)
        {
            object[] values = new object[from.ItemArray.Length];

            for (int i = 0; i < from.ItemArray.Length; i++)
            {
                if (from.ItemArray[i] == DBNull.Value)
                {
                    if (from.Table.Columns[i].DataType.FullName == typeof(String).FullName)
                    {
                        values[i] = String.Empty;
                    }
                    else if (from.Table.Columns[i].DataType.FullName == typeof(Decimal).FullName)
                    {
                        values[i] = 0M;
                    }
                }
                else
                {
                    values[i] = from.ItemArray[i];
                }
            }

            to.ItemArray = values;
        }
        #endregion �f�[�^�s����DBNull���󕶎���0�ɕϊ�����.

        #region �\�[�g�C���W�P�[�^�̃��Z�b�g.
        /// <summary>
        /// �\�[�g�C���W�P�[�^�̃��Z�b�g.
        /// </summary>
        /// <param name="view"></param>
        private void ResetSortIndicator(SheetView view)
        {
            view.Models.ResetViewRowIndexes();

            foreach (FarPoint.Win.Spread.Column column in view.Columns)
            {
                column.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            }
        }
        #endregion �\�[�g�C���W�P�[�^�̃��Z�b�g.

        /* 2015/04/06 �G�v�\�������g���Ή� HLC K.Fujisaki ADD Start */
        #region �����`�F�b�N(�o�C�g).
        /// <summary>
        /// �����`�F�b�N(�o�C�g).
        /// </summary>
        /// <param name="colIdx">�J����(����)</param>
        /// <returns>true:����@false:�G���[</returns>
        private bool CheckByteLength(int colIdx)
        {
            //�����ݒ�.
            string errMsg = string.Empty;
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            //�V�[�g�̍s�������[�v.
            for (int i = 0; i < _spdKkhDetail_Sheet1.RowCount; i++)
            {
                String checkData = _spdKkhDetail_Sheet1.Cells[i, colIdx].Text;

                //�����`�F�b�N(100�o�C�g�ȉ��Ȃ��薳��).
                if (sjisEnc.GetByteCount(checkData) > 100)
                {
                    int rowCount = i + 1;

                    //�G���[���b�Z�[�W��\�����āAfalse��Ԃ�.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0095, new String[] { errMsg }, KKHSystemConst.KoteiMongon.DETAIL_REGIST, MessageBoxButtons.OK);
                    return false;
                }
            }

            //����I������true��Ԃ�.
            return true;
        }
        #endregion �����`�F�b�N(�o�C�g).
        /* 2015/04/06 �G�v�\�������g���Ή� HLC K.Fujisaki ADD End */
        #endregion ���\�b�h.
    }
}