using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Ash.ProcessController.Report;
using Isid.KKH.Ash.Schema;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Ash.Utility;
using Isid.KKH.Common.KKHUtility;
namespace Isid.KKH.Ash.View.Report
{
    /// <summary>
    /// �}�̕ʒ��[���.
    /// </summary>
    public partial class ReportAshByMedium : Isid.KKH.Common.KKHView.Common.Form.KKHForm
    {
        #region �萔.
        #region �ǃR�[�h.
        /// <summary>
        /// �V��.
        /// </summary>
        public const string KYKCD_SHINBN = "202";
        /// <summary>
        /// �G��.
        /// </summary>
        public const string KYKCD_ZASHI = "203";
        /// <summary>
        /// �e���r�^�C���A�X�|�b�g.
        /// </summary>
        public const string KYKCD_TV = "204";
        /// <summary>
        /// ���W�I�^�C���A�X�|�b�g.
        /// </summary>
        public const string KYKCD_RADIO = "205";
        /// <summary>
        /// ���O�L���A�C�x���g.
        /// </summary>
        public const string KYKCD_KOEVE = "217";
        /// <summary>
        /// ����.
        /// </summary>
        public const string KYKCD_SEISAK = "216";
        /* 2013/02/22 PR�}�̒ǉ��Ή� JSE Okazaki ADD Start */
        /// <summary>
        /// PR.
        /// </summary>
        public const string KYKCD_PR = "221";
        /* 2013/02/22 PR�}�̒ǉ��Ή� JSE Okazaki ADD End */
        /// <summary>
        /// ���̑���j���[���f�B�A��C���^�[�l�b�g�BS�CS.
        /// </summary>
        public const string KYKCD_SONOTA = "218";
        /// <summary>
        /// ���.
        /// </summary>
        public const string KYKCD_OOH = "206";
        /// <summary>
        /// ���f�B�A�t�B�[.
        /// </summary>
        public const string KYKCD_MEDIAFEE = "219";
        /// <summary>
        /// �u�����h�Ǘ��t�B�[.
        /// </summary>
        public const string KYKCD_BLAND = "220";
        #endregion �ǃR�[�h.

        #region ���[.
        /// <summary>
        /// Excel(���[�o�̓}�N������)�t�@�C����.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME = "Ash_Medium.xlsm";
        private static readonly string REP_MACRO_FILENAME_BEER = "AshBeer_Medium.xlsm";
        /// <summary>
        /// Excel(���[�o�̓}�N���e���v���[�g)�t�@�C����.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "Ash_Medium_Template.xlsx";
        private static readonly string REP_TEMPLATE_FILENAME_BEER = "AshBeer_Medium_Template.xlsx";
        /// <summary>
        /// XML�t�@�C����1.
        /// </summary>
        private static readonly string REP_XML_FILENAME = "Ash_Medium_Data.xml";
        /// <summary>
        /// XML�t�@�C����2.
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "Ash_Medium_Prop.xml";
        #endregion ���[.

        /* 2016/12/05 �A�T�q����őΉ� HLC K.Soga ADD Start */
        #region �Œ蕶��.
        /// <summary>
        /// ���Ӑ�R�[�h(�A�T�q����).
        /// </summary>
        public const string TOKUISAKI_CODE_INRYOU = "285147";
        /// <summary>
        /// ���Ӑ�R�[�h(�A�T�q�r�[��).
        /// </summary>
        public const string TOKUISAKI_CODE_BEER = "016802";
        #endregion �Œ蕶��.
        /* 2016/12/05 �A�T�q����őΉ� HLC K.Soga ADD End */
        #endregion �萔.

        #region �����o�ϐ�.
        /// <summary>
        /// �i�r�p�����[�^�[.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// �}�̋敪�p�f�[�^�e�[�u��.
        /// </summary>
        private RepDsAsh.BaiCdDataTable bct = new RepDsAsh.BaiCdDataTable();
        /// <summary>
        /// ���i�}�X�^�f�[�^�e�[�u��.
        /// </summary>
        private RepDsAsh.SyohinDataTable sdt = new RepDsAsh.SyohinDataTable();
        /// <summary>
        /// �N��.
        /// </summary>
        string _yearMonth = string.Empty;
        /// <summary>
        /// �}�̔��f�p.
        /// </summary>
        int baikbn = 0;
        /// <summary>
        /// �R���{�I��}�̖��i�[.
        /// </summary>
        string baitaiName = string.Empty;
        /// <summary>
        /// �ۊǗp�f�[�^�Z�b�g.
        /// </summary>
        private RepDsAsh repds = new RepDsAsh();
        /// <summary>
        /// �폜�p�f�[�^�Z�b�g.
        /// </summary>
        private RepDsAsh tableToDel = new RepDsAsh();
        /// <summary>
        /// �ۑ���p�ϐ�.
        /// </summary>
        private string pStrRepAdrs = "";
        /// <summary>
        /// ���[���i�ۑ��Ŏg�p�j�p�ϐ�.
        /// </summary>
        private string pStrRepFilNam = "";
        /// <summary>
        /// �ۑ���p(�e���v���[�g)�ϐ�.
        /// </summary>
        private string pStrRepTempAdrs = "";
        /// <summary>
        /// �����.
        /// </summary>
        private double _dbSyohizei;
        /// <summary>
        /// �R�s�[�}�N���폜�pstring.
        /// </summary>
        private string _strmacrodel;
        /// <summary>
        /// �}�̊m�F�p.
        /// </summary>
        Dictionary<string, int> _dicBaitai;
        #endregion �����o�ϐ�.

        #region �R���X�g���N�^.
        /// <summary>
        /// �R���X�g���N�^.
        /// </summary>
        public ReportAshByMedium()
        {
            InitializeComponent();
        }
        #endregion �R���X�g���N�^.

        #region �C�x���g.
        #region ��ʑJ�ڎ��ɔ���.
        /// <summary>
        /// ��ʑJ�ڎ��ɔ���.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportAshByMedium_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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
        #endregion ��ʑJ�ڎ��ɔ���.

        #region �t�H�[�����[�h��.
        /// <summary>
        /// �t�H�[�����[�h��.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportAshByMedium_Shown(object sender, EventArgs e)
        {
            //���[�f�B���O�\��.
            base.ShowLoadingDialog();

            //�ҏW.
            EditControl();

            //�f�[�^�擾.
            MediaCdGet();

            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.MainType,
                                                                                            "ED-I0001");
            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                //����ŃZ�b�g.
                _dbSyohizei = double.Parse(comResult.CommonDataSet.SystemCommon[0].field4.ToString());
                //�e���v���[�g�A�h���X.
                pStrRepTempAdrs = comResult.CommonDataSet.SystemCommon[0].field2.ToString();
            }


            //�ۑ���� + ���[��.
            CommonProcessController commonProcessController2 = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult2 = commonProcessController2.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                                            "001");
            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //�ۑ���Z�b�g.
                pStrRepAdrs = comResult2.CommonDataSet.SystemCommon[0].field2.ToString();
                //���̃Z�b�g.
                pStrRepFilNam = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
            }

            //���[�f�B���O��\��.
            base.CloseLoadingDialog();
        }
        #endregion �t�H�[�����[�h��.

        #region �߂�{�^���N���b�N.
        /// <summary>
        /// �߂�{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (_strmacrodel != null)
            {
                System.IO.FileInfo cFileInfo = new System.IO.FileInfo(_strmacrodel);

                //�}�N���t�@�C���̍폜(VBA���ł͍폜�ł��Ȃ���).
                //�t�@�C�������݂��Ă��邩���f����.
                if (cFileInfo.Exists)
                {
                    //�ǂݎ���p����������ꍇ�́A�ǂݎ���p��������������.
                    if ((cFileInfo.Attributes & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly)
                    {
                        cFileInfo.Attributes = System.IO.FileAttributes.Normal;
                    }

                    //�t�@�C�����폜����.
                    cFileInfo.Delete();
                }
            }

            Navigator.Backward(this, null, _naviParam, true);
        }
        #endregion �߂�{�^���N���b�N.

        #region �����{�^���N���b�N.
        /// <summary>
        /// �����{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            //XML�f�[�^�Z�b�g�N���A.
            repds.Clear();

            //�\��.
            DisplayView();
            this.ActiveControl = null;
        }
        #endregion �\���{�^���N���b�N.

        #region Excel�{�^���N���b�N.
        /// <summary>
        /// Excel�{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            //Excel�쐬�p�f�[�^�i�[.
            excelDataSet();
            this.ActiveControl = null;
        }
        #endregion Excel�{�^���N���b�N.

        #region �w���v�{�^���N���b�N����.
        /// <summary>
        /// �w���v�{�^���N���b�N����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //���Ӑ�R�[�h.
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();

            //���s.
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Report, this, HelpNavigator.KeywordIndex);
            this.ActiveControl = null;
        }
        #endregion �w���v�{�^���N���b�N����.

        #region �N���R���{�{�b�N�X�A�N�e�B�u.
        /// <summary>
        /// �N���R���{�{�b�N�X�A�N�e�B�u.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtYm_Enter(object sender, EventArgs e)
        {
            btnXls.Enabled = false;
        }
        #endregion �N���R���{�{�b�N�X�A�N�e�B�u.
        #endregion �C�x���g.

        #region ���\�b�h.
        #region �R���{�{�b�N�X�̐ݒ�.
        /// <summary>
        /// �R���{�{�b�N�X�̐ݒ�.
        /// </summary>
        private void cmbSet()
        {
            /* 2013/02/22 PR�}�̒ǉ��Ή� JSE Okazaki DEL Start */
            //string[] item ={KkhConstAsh.BaitaiNm.TV_TIME,
            //        KkhConstAsh.BaitaiNm.RADIO_TIME,
            //        KkhConstAsh.BaitaiNm.RADIO_SPOT,
            //        KkhConstAsh.BaitaiNm.TV_SPOT,
            //        KkhConstAsh.BaitaiNm.SHINBUN,
            //        KkhConstAsh.BaitaiNm.ZASHI,
            //        KkhConstAsh.BaitaiNm.KOUTSU,
            //        KkhConstAsh.BaitaiNm.SEISAKU,
            //        KkhConstAsh.BaitaiNm.SONOTA,
            //        KkhConstAsh.BaitaiNm.NEW_MEDIA,
            //        KkhConstAsh.BaitaiNm.INTERNET,
            //        KkhConstAsh.BaitaiNm.BS,
            //        KkhConstAsh.BaitaiNm.CS,
            //        KkhConstAsh.BaitaiNm.OKUGAIKOUKOKU,
            //        KkhConstAsh.BaitaiNm.EVENT,
            //        KkhConstAsh.BaitaiNm.TYOUSA,
            //        KkhConstAsh.BaitaiNm.MEDIA_FEE,
            //        KkhConstAsh.BaitaiNm.BRAND_FEE,
            //        KkhConstAsh.BaitaiNm.SUM_BAITAI,
            //        KkhConstAsh.BaitaiNm.ALL_BAITAI};
            //string[] item = null;
            ////���Ӑ悪�A�T�q�r�[���̏ꍇ 
            //if (KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Equals(_naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo))
            //{
            //    //�}�̃}�X�^���疼�̂��擾(�Ō��SUM_BAITAI,ALL_BAITAI�ǉ�).
            //    item = new string[]
            //    {KkhConstAsh.BaitaiNm.TV_TIME,
            //        KkhConstAsh.BaitaiNm.RADIO_TIME,
            //        KkhConstAsh.BaitaiNm.RADIO_SPOT,
            //        KkhConstAsh.BaitaiNm.TV_SPOT,
            //        KkhConstAsh.BaitaiNm.SHINBUN,
            //        KkhConstAsh.BaitaiNm.ZASHI,
            //        KkhConstAsh.BaitaiNm.KOUTSU,
            //        KkhConstAsh.BaitaiNm.SEISAKU,
            //        KkhConstAsh.BaitaiNm.PR,
            //        KkhConstAsh.BaitaiNm.SONOTA,
            //        KkhConstAsh.BaitaiNm.NEW_MEDIA,
            //        KkhConstAsh.BaitaiNm.INTERNET,
            //        KkhConstAsh.BaitaiNm.BS,
            //        KkhConstAsh.BaitaiNm.CS,
            //        KkhConstAsh.BaitaiNm.OKUGAIKOUKOKU,
            //        KkhConstAsh.BaitaiNm.EVENT,
            //        KkhConstAsh.BaitaiNm.TYOUSA,
            //        KkhConstAsh.BaitaiNm.MEDIA_FEE,
            //        KkhConstAsh.BaitaiNm.BRAND_FEE,
            //        KkhConstAsh.BaitaiNm.SUM_BAITAI,
            //        KkhConstAsh.BaitaiNm.ALL_BAITAI};
            //}
            //else
            //{
            //    //�}�̃}�X�^���疼�̂��擾(�Ō��SUM_BAITAI,ALL_BAITAI�ǉ�).
            //    item = new string[]
            //    {KkhConstAsh.BaitaiNm.TV_TIME,
            //        KkhConstAsh.BaitaiNm.RADIO_TIME,
            //        KkhConstAsh.BaitaiNm.RADIO_SPOT,
            //        KkhConstAsh.BaitaiNm.TV_SPOT,
            //        KkhConstAsh.BaitaiNm.SHINBUN,
            //        KkhConstAsh.BaitaiNm.ZASHI,
            //        KkhConstAsh.BaitaiNm.KOUTSU,
            //        KkhConstAsh.BaitaiNm.SEISAKU,
            //        KkhConstAsh.BaitaiNm.SONOTA,
            //        KkhConstAsh.BaitaiNm.NEW_MEDIA,
            //        KkhConstAsh.BaitaiNm.INTERNET,
            //        KkhConstAsh.BaitaiNm.BS,
            //        KkhConstAsh.BaitaiNm.CS,
            //        KkhConstAsh.BaitaiNm.OKUGAIKOUKOKU,
            //        KkhConstAsh.BaitaiNm.EVENT,
            //        KkhConstAsh.BaitaiNm.TYOUSA,
            //        KkhConstAsh.BaitaiNm.MEDIA_FEE,
            //        KkhConstAsh.BaitaiNm.BRAND_FEE,
            //        KkhConstAsh.BaitaiNm.SUM_BAITAI,
            //        KkhConstAsh.BaitaiNm.ALL_BAITAI};
            //}
            /* 2013/02/22 PR�}�̒ǉ��Ή� JSE Okazaki DEL End */

            /* 2013/02/22 �A�T�q�Ή� Miyanoue ADD Start */
            //�R���{�{�b�N�X�̐���.
            DataTable SybtNameTable = new DataTable("SybtNameTable");
            SybtNameTable.Columns.Add("Display", typeof(string));
            SybtNameTable.Columns.Add("Value", typeof(string));
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);

            List<AshBaitaiUtility.BaitaiResult> resultList = ashBaitaiUtility.GetNewBaitaiList();

            for (int i = 0; i < resultList.Count; i++)
            {
                SybtNameTable.Rows.Add(resultList[i].baitaiNm, resultList[i].baitaiCd);
            }
            SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.SUM_BAITAI, KkhConstAsh.BaitaiCd.GOKEI);
            SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.ALL_BAITAI, KkhConstAsh.BaitaiCd.ALL_BAITAI);

            cmbMedia.DataSource = SybtNameTable;
            cmbMedia.DisplayMember = "Display";
            cmbMedia.ValueMember = "Value";
            cmbMedia.SelectedValue = KkhConstAsh.BaitaiCd.ALL_BAITAI;
            /* 2013/02/22 �A�T�q�Ή� Miyanoue ADD End */
            /* 2013/02/22 PR�}�̒ǉ��Ή� JSE Okazaki DEL Start */
            //�����l�͑S�}��.
            ////cmbMedia.SelectedIndex = 19;
            //�����l�͑S�}��.
            //cmbMedia.SelectedIndex = cmbMedia.Items.Count - 1;
            /* 2013/02/22 PR�}�̒ǉ��Ή� JSE Okazaki DEL Start */
        }
        #endregion �R���{�{�b�N�X�̐ݒ�.

        #region �e�R���g���[���ҏW.
        /// <summary>
        /// �e�R���g���[���ҏW.
        /// </summary>
        private void EditControl()
        {
            //�N���̎擾.
            String hostDate = "";
            hostDate = getHostDate();
            if (hostDate != "")
            {
                hostDate = hostDate.Trim().Replace("/", "");
                if (hostDate.Trim().Length >= 6)
                {
                    txtYm.Value = hostDate.Substring(0, 6);
                }
                else
                {
                    txtYm.Value = hostDate;
                }
                txtYm.cmbYM_SetDate();
            }

            //�X�e�[�^�X�̐ݒ�.
            txtYm.Value = hostDate.Substring(0, 6);
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            //�R���{�ݒ�.
            cmbSet();
        }
        #endregion �e�R���g���[���ҏW.

        #region �c�Ɠ��擾.
        /// <summary>
        /// �c�Ɠ��擾.
        /// </summary>
        /// <returns></returns>
        private string getHostDate()
        {
            string hostDate = string.Empty;

            CommonProcessController processController = CommonProcessController.GetInstance();
            hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return hostDate;
        }
        #endregion �c�Ɠ��擾.

        #region �f�[�^�\��.
        /// <summary>
        /// �f�[�^�\��.
        /// </summary>
        /// <returns></returns>
        private void DisplayView()
        {
            //���[�f�B���O�\���J�n.
            base.ShowLoadingDialog();

            //�}�̃R�[�h.
            RepDsAsh.BaiCdRow[] drBaitaiCode = (RepDsAsh.BaiCdRow[])bct.Select("", "");
            //���i.
            RepDsAsh.SyohinRow[] drSyohin = (RepDsAsh.SyohinRow[])sdt.Select("", "");

            /*
             * �����ݒ�.
             */
            //�}�̃R�[�h�p.
            string strBaitaiCd = string.Empty;
            //�󒍖���No(�ێ��p).
            string strJyuchuMeisaiNoHoji = string.Empty;
            //���v�p.
            double dblSyoukei = 0;
            //��ې�. 
            double dblHikazei = 0;
            //���z���v.
            double dblGoukei = 0;
            //���v(�ێ��p).
            double dblSupposeSyoukei = 0;
            //�N���̃Z�b�g.
            _yearMonth = txtYm.Value;
            int intCnt = 0;
            //����.
            int intKensu = 0;
            //�}�̌���.
            int intBaitaiKensu = 0;
            /* 2017/01/31 �A�T�q����ŕs��Ή� HLC K.Soga MOD Start */
            //���v���z.
            double dblAmount = 0;
            ///* 2013/12/04 ����őΉ� HLC H.Watabe ADD Start */
            //�����(�ێ��p).
            //double dblSupposeSyohizei = 0;
            //List<double> lstZeiRate = new List<double>();
            //List<double> lstAmount = new List<double>();
            //double dblMediaTaxSumFromRows = 0;
            //int intListIndex = 0;
            ///* 2013/12/04 ����őΉ� HLC H.Watabe ADD End */
            /* 2017/01/31 �A�T�q����ŕs��Ή� HLC K.Soga MOD End */
            /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga DEL Start */
            ////�[�������z�i�[�p.
            //double dblTyousei = 0;
            /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga DEL End */

            /*
             * �p�����[�^�̃Z�b�g.
             */
            ReportAshProcessController.FindReportAshByMedium param = new ReportAshProcessController.FindReportAshByMedium();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = _yearMonth;

            /*
             * ����.
             */
            ReportAshProcessController processController = ReportAshProcessController.GetInstance();
            FindReportAshMediaByCondServiceResult result = processController.findReportMedia(param);
            //�G���[�̏ꍇ.
            if (result.HasError)
            {
                //���[�f�B���O�\���I��.
                base.CloseLoadingDialog();
                medMain_Sheet1.Rows.Count = 0;
                return;
            }
            RepDsAsh.RepAshMediaRow[] resultRow = (RepDsAsh.RepAshMediaRow[])result.dsAshDataSet.RepAshMedia.Select("", "");
            //�������ʂ�0���̏ꍇ.
            if (resultRow.Length == 0)
            {
                //���[�f�B���O�\���I��.
                base.CloseLoadingDialog();
                medMain_Sheet1.Rows.Count = 0;
                lblKensu.Text = resultRow.Length.ToString() + "��";
                btnXls.Enabled = false;
                cmbMedia.Enabled = false;
                MessageUtility.ShowMessageBox(MessageCode.HB_W0031, null, "���[", MessageBoxButtons.OK);
                return;
            }

            /*
             * �f�[�^�Z�b�g�̃C���X�^���X����.
             */
            RepDsAsh dsash = new RepDsAsh();
            RepDsAsh.displayMediaRow drNewDispMedia = dsash.displayMedia.NewdisplayMediaRow();
            drNewDispMedia = syokirowSet(drNewDispMedia);
            //�}�̊m�F�p.
            _dicBaitai = new Dictionary<string, int>();
            /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki ADD Start */
            // �}�̃}�X�^����擾.
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki ADD End */

            //�擾�����}�̕ʒ��[��񕪃��[�v����.
            foreach (RepDsAsh.RepAshMediaRow row in resultRow)
            {
                //�����ݒ�.
                string strClcResult1 = string.Empty;
                string strClcResult2 = string.Empty;
                //�\���p�f�[�^Row.
                RepDsAsh.displayMediaRow drDispMedia = dsash.displayMedia.NewdisplayMediaRow();
                //�\���p(���v�p)�f�[�^Row.
                RepDsAsh.displayMediaRow drDispMediaGoukei = dsash.displayMedia.NewdisplayMediaRow();
                //�\���p(���v�p)�f�[�^Row.
                RepDsAsh.displayMediaRow drDispMediaSyoukei = dsash.displayMedia.NewdisplayMediaRow();

                //�f�[�^Row�����Z�b�g.
                drDispMedia = syokirowSet(drDispMedia);

                //1��ڂ̃��[�v���̏ꍇ.
                if (intCnt == 0)
                {
                    //�}�̃R�[�h�ێ�.
                    strBaitaiCd = row.code1;
                }
                //�}�̃R�[�h�Ɣ}�̌�����ێ�.
                if (!_dicBaitai.ContainsKey(strBaitaiCd))
                {
                    intBaitaiKensu++;
                    _dicBaitai.Add(strBaitaiCd, intBaitaiKensu);
                }

                /*
                 * ���v(�O��̔}�̃R�[�h�ƈႤ�ꍇ).
                 */
                if (strBaitaiCd != row.code1.Trim())
                {
                    //�\���p�f�[�^Row.
                    drDispMedia = syokirowSet(drDispMedia);
                    //�\���p�i���v�p�j�f�[�^Row.
                    drDispMediaGoukei = syokirowSet(drDispMediaGoukei);
                    //�\���p(���v�p)�f�[�^Row.
                    drDispMediaSyoukei = syokirowSet(drDispMediaSyoukei);
                    //�󒍖���No�ێ��p��������.  
                    strJyuchuMeisaiNoHoji = string.Empty;
                    /* 2017/01/31 �A�T�q����ŕs��Ή� HLC K.Soga DEL Start */
                    //double dblSumTax = 0;
                    //double dblSumTax2 = 0;
                    /* 2017/01/31 �A�T�q����ŕs��Ή� HLC K.Soga DEL End */

                    /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga MOD Start */
                    #region �[�������z����(�폜).
                    ///* 2013/12/04 ����őΉ� HLC H.Watabe MOD Start */
                    ////RepDsAsh.allbaitaiRow drAllBaitai = repds.allbaitai.NewallbaitaiRow();
                    ////dblTyousei = dblSyoukei - dblHikazei;
                    ////dblTyousei = dblTyousei * 1.05;
                    ////dblTyousei = dblTyousei * dblSupposeSyohizei;
                    ////dblTyousei = dblTyousei + dblHikazei - dblSupposeSyoukei;
                    ////dblTyousei = ToHalfAdjust(dblTyousei, 0);
                    ////double dblSumTax2 = ToHalfAdjust(dblTyousei, 0) + dblSupposeSyoukei;
                    //RepDsAsh.allbaitaiRow drAllBaitai = repds.allbaitai.NewallbaitaiRow();
                    //double dblSumTax = 0;
                    //for (int index = 0; index < lstZeiRate.Count; index++)
                    //{
                    //    /* 2015/06/08 �A�T�q����őΉ� HLC K.Fujisaki MOD Start */
                    //    dblSumTax += Math.Truncate((1 + (lstZeiRate[index] * 0.01)) * lstAmount[index]);
                    //    //�A�T�q�����̏ꍇ.
                    //    if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                    //    {
                    //        dblSumTax += Math.Truncate((1 + (lstZeiRate[index] * 0.01)) * lstAmount[index]);
                    //    }
                    //    //�A�T�q�r�[���̏ꍇ.
                    //    else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                    //    {
                    //        dblSumTax += Math.Round((1 + (lstZeiRate[index] * 0.01)) * lstAmount[index]);
                    //    }
                    //    /* 2015/06/08 �A�T�q����őΉ� HLC K.Fujisaki MOD End */
                    //}
                    ////dblTyousei = dblSyoukei - dblHikazei;
                    ////dblTyousei = dblTyousei * 1.05;
                    ////dblTyousei = dblTyousei * dblSupposeSyohizei;
                    ////dblTyousei = dblTyousei + dblHikazei - dblSupposeSyoukei;
                    ////dblTyousei = ToHalfAdjust(dblTyousei, 0);
                    //dblTyousei = dblSumTax - dblMediaTaxSumFromRows;
                    //double dblSumTax2 = dblSumTax;
                    ////int goukeikingak = (int)ToHalfAdjust(dblSumTax2, 1);
                    ///* 2013/12/04 ����őΉ� HLC H.Watabe MOD End */
                    #endregion �[�������z����(�폜).

                    //�}�̏��(�ێ��p)�̎擾.
                    RepDsAsh.allbaitaiRow drAllBaitai = repds.allbaitai.NewallbaitaiRow();

                    /* 2017/01/31 �A�T�q����ŕs��Ή� HLC K.Soga DEL Start */
                    ////�e�}�̖̂��׌��������[�v����.
                    //for (int index = 0; index < lstZeiRate.Count; index++)
                    //{
                    //    //���v���z.
                    //    dblSumTax += lstAmount[index];
                    //}
                    //dblSumTax2 = dblSumTax;
                    /* 2017/01/31 �A�T�q����ŕs��Ή� HLC K.Soga DEL End */
                    /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga MOD End */

                    //�ǃR�[�h.
                    drDispMediaSyoukei.kyoku = KKHSystemConst.KoteiMongon.SYOKEI;
                    //�}�̃R�[�h.
                    drDispMediaSyoukei.baitaiCd = strBaitaiCd + "3";
                    /* 2017/01/31 �A�T�q����ŕs��Ή� HLC K.Soga MOD Start */
                    //���v���z.
                    //drDispMediaSyoukei.kingak = dblSumTax2.ToString();
                    drDispMediaSyoukei.kingak = dblAmount.ToString();
                    /* 2017/01/31 �A�T�q����ŕs��Ή� HLC K.Soga MOD End */

                    /*
                     * XML�p.
                     */
                    //�}�̃R�[�h.
                    drAllBaitai.baitaicd = strBaitaiCd;
                    //�łȂ����z.
                    drAllBaitai.zeinasi = dblSyoukei.ToString();
                    /* 2017/01/31 �A�T�q����ŕs��Ή� HLC K.Soga MOD Start */
                    //���v���z.
                    //drAllBaitai.goukei = dblSumTax2.ToString();
                    drAllBaitai.goukei = dblAmount.ToString();
                    /* 2017/01/31 �A�T�q����ŕs��Ή� HLC K.Soga MOD End */

                    //�}��.
                    repds.allbaitai.AddallbaitaiRow(drAllBaitai);

                    /*
                     * ������.
                     */
                    //���v������.
                    dblSyoukei = 0;
                    //��ېŏ�����.
                    dblHikazei = 0;
                    //���v(�ێ��p)������.
                    dblSupposeSyoukei = 0;
                    /* 2013/12/04 ����őΉ� HLC H.Watabe ADD Start */
                    dsash.displayMedia.AdddisplayMediaRow(drDispMediaSyoukei);
                    /* 2017/01/31 �A�T�q����ŕs��Ή� HLC K.Soga MOD Start */
                    //���v���z�p���X�g������.
                    dblAmount = 0;
                    //�}�̍��v������.
                    //dblMediaTaxSumFromRows = 0;
                    //����ŗp���X�g������.
                    //lstZeiRate.Clear();
                    //lstAmount.Clear();
                    /* 2017/01/31 �A�T�q����ŕs��Ή� HLC K.Soga MOD End */
                    /* 2013/12/04 ����őΉ� HLC H.Watabe ADD End */
                    /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga DEL Start */
                    ////�[��������ŋ��A���v���z�ɔ��f������.
                    //double num = dblTyousei + double.Parse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 3].syouhiZei.ToString());
                    //num = dblTyousei + double.Parse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kingak.ToString());
                    //dsash.displayMedia[dsash.displayMedia.Rows.Count - 3].syouhiZei = num.ToString();
                    //dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kingak = num.ToString();
                    /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga DEL End */
                }

                /*
                 * ���ʏ���.
                 */
                //���� .
                drDispMedia.kenName = row.kkNameKj;

                //�l��.
                drDispMedia.nebiki = row.seiGak;

                /* 2013/12/04 ����őΉ� HLC H.Watabe ADD Start */
                //���v�i�[���X�g�̍쐬.
                switch (row.code1.Trim())
                {
                    //�e���r�^�C���A���W�I�^�C���ABS�ACS�A���f�B�A�t�B�[�A�u�����h�t�B�[�A�e���r�l�b�g�X�|�b�g�̏ꍇ.
                    case KkhConstAsh.BaitaiCd.TV_TIME:
                    case KkhConstAsh.BaitaiCd.RADIO_TIME:
                    case KkhConstAsh.BaitaiCd.BS:
                    case KkhConstAsh.BaitaiCd.CS:
                    case KkhConstAsh.BaitaiCd.MEDIA_FEE:
                    case KkhConstAsh.BaitaiCd.BRAND_FEE:
                    /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki ADD Start */
                    case KkhConstAsh.BaitaiCd.TV_NETSPOT:
                    /* 2015/06/08 �A�T�q�Ή� HLC H.Fujisaki ADD End */
                        //NAME33�Ńt�B���^���s��.
                        string filter = "NAME33 = '" + row.name33 + "'";
                        RepDsAsh.RepAshMediaTempRow[] resultRow2 = (RepDsAsh.RepAshMediaTempRow[])result.dsAshDataSet.RepAshMediaTemp.Select(filter);
                        foreach (RepDsAsh.RepAshMediaTempRow rows in resultRow2)
                        {
                            //���v���z.
                            dblAmount += double.Parse(rows.seiGak) + double.Parse(rows.kngk1);
                            #region ���v���z(�폜).
                            //if (lstZeiRate.Count != 0)
                            //{
                            //    bool rateGetFlg = false;
                            //    //����Ń��X�g�Ɣ�r.
                            //    for (intListIndex = 0; intListIndex < lstZeiRate.Count; intListIndex++)
                            //    {
                            //        if (lstZeiRate[intListIndex] == double.Parse(rows.ritu1.Trim()))
                            //        {
                            //            rateGetFlg = true;
                            //            /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga MOD Start */
                            //            //���v���z(�������z + �����).
                            //            //lstAmount[intListIndex] += double.Parse(rows.seiGak);
                            //            lstAmount[intListIndex] += double.Parse(rows.seiGak) + double.Parse(rows.kngk1);
                            //            /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga MOD End */
                            //            break;
                            //        }
                            //    }
                            //    //�����ꍇ�͒ǉ�.
                            //    if (rateGetFlg == false)
                            //    {
                            //        lstZeiRate.Add(double.Parse(rows.ritu1.Trim()));
                            //        /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga MOD Start */
                            //        //lstAmount.Add(double.Parse((row.seiGak.Trim()));
                            //        //���v���z(�������z + �����).
                            //        lstAmount.Add(double.Parse((row.seiGak) + double.Parse((row.kngk1))));
                            //        /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga MOD End */
                            //        intListIndex = lstZeiRate.Count - 1;
                            //    }
                            //}
                            //else
                            //{
                            //    lstZeiRate.Add(double.Parse(rows.ritu1.Trim()));
                            //    /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga MOD Start */
                            //    //lstAmount.Add(double.Parse(rows.seiGak.Trim()));
                            //    //���v���z(�������z + �����).
                            //    lstAmount.Add(double.Parse(rows.seiGak) + double.Parse(rows.kngk1));
                            //    /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga MOD End */
                            //    intListIndex = lstZeiRate.Count - 1;
                            //}
                            #endregion ���v���z(�폜).
                        }
                        break;
                    //�e���r�^�C���A���W�I�^�C���ABS�ACS�A���f�B�A�t�B�[�A�u�����h�t�B�[�A�e���r�l�b�g�X�|�b�g�ȊO�̏ꍇ.
                    default:
                        //���v���z.
                        dblAmount += double.Parse(row.seiGak) + double.Parse(row.kngk1);
                        #region ���v���z(�폜).
                        //if (lstZeiRate.Count != 0)
                        //{
                        //    bool rateGetFlg = false;
                        //    //����Ń��X�g�Ɣ�r.
                        //    for (intListIndex = 0; intListIndex < lstZeiRate.Count; intListIndex++)
                        //    {
                        //        if (lstZeiRate[intListIndex] == double.Parse(row.ritu1.Trim()))
                        //        {
                        //            rateGetFlg = true;
                        //            /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga MOD Start */
                        //            //���v���z(�������z + �����).
                        //            //lstAmount[intListIndex] += double.Parse(row.seiGak.Trim());
                        //            lstAmount[intListIndex] += double.Parse(row.seiGak) + double.Parse(row.kngk1);
                        //            /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga MOD End */
                        //            break;
                        //        }
                        //    }
                        //    //�����ꍇ�͒ǉ�.
                        //    if (rateGetFlg == false)
                        //    {
                        //        lstZeiRate.Add(double.Parse(row.ritu1.Trim()));
                        //        /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga MOD Start */
                        //        //lstAmount.Add(double.Parse((row.seiGak.Trim()));
                        //        //���v���z(�������z + �����).
                        //        lstAmount.Add(double.Parse((row.seiGak) + double.Parse((row.kngk1))));
                        //        /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga MOD End */
                        //        intListIndex = lstZeiRate.Count - 1;
                        //    }
                        //}
                        //else
                        //{
                        //    lstZeiRate.Add(double.Parse(row.ritu1.Trim()));
                        //    /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga MOD Start */
                        //    //lstAmount.Add(double.Parse((row.seiGak.Trim()));
                        //    //���v���z(�������z + �����).
                        //    lstAmount.Add(double.Parse(row.seiGak) + double.Parse(row.kngk1));
                        //    /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga MOD End */
                        //    intListIndex = lstZeiRate.Count - 1;
                        //}
                        #endregion ���v���z(�폜).
                        break;
                }
                /* 2013/12/04 ����őΉ� HLC H.Watabe ADD End */

                //����ŗ�.
                drDispMedia.syouhiRitu = row.ritu1;
                /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga MOD Start */
                //�����.
                drDispMedia.syouhiZei = row.kngk1;
                #region �����(�폜).
                //if (row.ritu1.Trim() == "0")
                //{
                //    drDispMedia.syouhiZei = "0";
                //}
                //else
                //{
                //    /* 2013/11/26 ����őΉ� HLC H.Watabe MOD Start */
                //    double syouhi = 0;
                //    double syohizei = 0;
                //    switch (row.code1.Trim())
                //    {
                //        case KkhConstAsh.BaitaiCd.TV_TIME:
                //        case KkhConstAsh.BaitaiCd.RADIO_TIME:
                //        case KkhConstAsh.BaitaiCd.BS:
                //        case KkhConstAsh.BaitaiCd.CS:
                //        case KkhConstAsh.BaitaiCd.MEDIA_FEE:
                //        case KkhConstAsh.BaitaiCd.BRAND_FEE:
                //        /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki ADD Start */
                //        case KkhConstAsh.BaitaiCd.TV_NETSPOT:
                //        /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki ADD End */
                //            string filter = "NAME33 = '" + row.name33 + "'";
                //            RepDsAsh.RepAshMediaTempRow[] resultRow2 = (RepDsAsh.RepAshMediaTempRow[])result.dsAshDataSet.RepAshMediaTemp.Select(filter);
                //            foreach (RepDsAsh.RepAshMediaTempRow rows in resultRow2)
                //            {
                //                dblSupposeSyohizei = 1 + (double.Parse(rows.ritu1.Trim()) * 0.01);
                //                syouhi = (double.Parse(rows.ritu1.Trim()) * 0.01) * double.Parse(rows.seiGak.Trim());
                //                /* 2015/06/08 �A�T�q����őΉ� HLC K.Fujisaki MOD Start */
                //                //syohizei = syohizei + (long)Math.Truncate(syouhi);
                //                if (_naviParam.strTksKgyCd == "285147")
                //                {
                //                    syohizei = syohizei + (long)Math.Truncate(syouhi);
                //                }
                //                else if (_naviParam.strTksKgyCd == "016802")
                //                {
                //                    syohizei = syohizei + (long)Math.Round(syouhi);
                //                }
                //                /* 2015/06/08 �A�T�q����őΉ� HLC K.Fujisaki MOD End */
                //            }
                //            drDispMedia.syouhiZei = syohizei.ToString();
                //            break;
                //        default:
                //            dblSupposeSyohizei = 1 + (double.Parse(row.ritu1.Trim()) * 0.01);
                //            syouhi = (double.Parse(row.ritu1.Trim()) * 0.01) * double.Parse(drDispMedia.nebiki.Trim());
                //            /* 2015/06/08 �A�T�q����őΉ� HLC K.Fujisaki MOD Start */
                //            //syohizei = (long)Math.Truncate(syouhi);
                //            if (_naviParam.strTksKgyCd == "285147")
                //            {
                //                syohizei = (long)Math.Truncate(syouhi);
                //            }
                //            else if (_naviParam.strTksKgyCd == "016802")
                //            {
                //                syohizei = (long)Math.Round(syouhi);
                //            }
                //            /* 2015/06/08 �A�T�q����őΉ� HLC K.Fujisaki MOD End */
                //            drDispMedia.syouhiZei = syohizei.ToString();
                //            break;
                //    }
                //    //����ł̊i�[�ϐ�.
                //    //dblSupposeSyohizei = 1 + (double.Parse(row.ritu1.Trim()) * 0.01);
                //    //double syouhi = (double.Parse(row.ritu1.Trim()) * 0.01) * double.Parse(drDispMedia.nebiki.Trim());
                //    //double syohizei = (long)Math.Truncate(syouhi);
                //    //int syohizei = (int)Math.Truncate(syouhi);
                //    /* 2013/11/26 ����őΉ� HLC H.Watabe MOD End */
                //}
                #endregion �����(�폜).
                /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga MOD End */

                #region �}�̖��Œl�̐ݒ���s��.
                switch (row.code1.Trim())
                {
                    #region �e���r�^�C���A���W�I�^�C���A�e���r�l�b�g�X�|�b�g.
                    case KkhConstAsh.BaitaiCd.TV_TIME:
                    case KkhConstAsh.BaitaiCd.RADIO_TIME:
                    /* 2015/06/08 �A�T�q�Ή� K.Fujisaki ADD Start */
                    case KkhConstAsh.BaitaiCd.TV_NETSPOT:
                        /* 2015/06/08 �A�T�q�Ή� K.Fujisaki ADD End */
                        //���p�ɔ}�̃R�[�h�Z�b�g.
                        strBaitaiCd = row.code1.Trim();
                        //���z.
                        drDispMedia.kingak = row.hnmeGak;
                        //�ǃl�b�g.
                        drDispMedia.kyokuNet = row.sonota7.ToString() + "�ǃl�b�g";
                        /* 2015/06/08 �A�T�q�Ή� K.Fujisaki MOD Start */
                        //if (row.code1.Equals(KkhConstAsh.BaitaiCd.TV_TIME))
                        if (row.code1.Equals(KkhConstAsh.BaitaiCd.TV_TIME) || row.code1.Equals(KkhConstAsh.BaitaiCd.TV_NETSPOT))
                        /* 2015/06/08 �A�T�q�Ή� K.Fujisaki MOD end */
                        {
                            //�}�̖�.
                            drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.TV_TIME;
                            //�����j��.
                            drDispMedia.housouWeek = weekDayGet(row.name5, row.name9);
                            //��.
                            if (string.IsNullOrEmpty(row.sonota8.Trim()))
                            {
                                drDispMedia.kyoku = getBaiName2(row.code2.Trim(), drBaitaiCode, KYKCD_TV);
                            }
                            else
                            {
                                drDispMedia.kyoku = getBaiName1(row.sonota8.ToString(), drBaitaiCode, KYKCD_TV);
                            }
                        }
                        else
                        {
                            /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue MOD Start */
                            //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.RADIO_TIME;
                            //�}�̖�.
                            if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                            {
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.RADIO_TIME;
                            }
                            else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                            {
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.RADIO;
                            }
                            /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue MOD End */
                            //��.
                            if (string.IsNullOrEmpty(row.sonota8.Trim()))
                            {
                                drDispMedia.kyoku = getBaiName2(row.code2.Trim(), drBaitaiCode, KYKCD_RADIO);
                            }
                            else
                            {
                                drDispMedia.kyoku = getBaiName1(row.sonota8.ToString(), drBaitaiCode, KYKCD_RADIO);
                            }
                        }
                        //����.
                        drDispMedia.jikan = timeFormatSet(row.name6.ToString());
                        //����.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        //�l����.
                        drDispMedia.nebiRitu = row.hnnert;
                        //����.
                        drDispMedia.kenName = row.kkNameKj.Trim();
                        //����.
                        intKensu++;
                        break;
                    #endregion �e���r�^�C���A���W�I�^�C���A�e���r�l�b�g�X�|�b�g.

                    #region ���f�B�A�t�B�[�A�u�����h�Ǘ��t�B�[.
                    case KkhConstAsh.BaitaiCd.MEDIA_FEE:
                    case KkhConstAsh.BaitaiCd.BRAND_FEE:
                        //���p�ɔ}�̃R�[�h�Z�b�g.
                        strBaitaiCd = row.code1.Trim();
                        //���z.
                        drDispMedia.kingak = row.hnmeGak;
                        //�l����.
                        drDispMedia.nebiRitu = row.hnnert;
                        //����.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        //����.
                        drDispMedia.jikan = timeFormatSet(row.name6.Trim());
                        //�l�b�g�ǐ�.
                        if (!string.IsNullOrEmpty(row.sonota7.Trim()))
                        {
                            drDispMedia.kyokuNet = row.sonota7.Trim();
                        }
                        switch (row.code1.Trim())
                        {
                            case KkhConstAsh.BaitaiCd.MEDIA_FEE:
                                //��.
                                drDispMedia.kyoku = getBaiName2(row.code2, drBaitaiCode, KYKCD_MEDIAFEE);
                                //�}�̖�.
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.MEDIA_FEE;
                                break;
                            case KkhConstAsh.BaitaiCd.BRAND_FEE:
                                //��.
                                drDispMedia.kyoku = getBaiName2(row.code2, drBaitaiCode, KYKCD_BLAND);
                                //�}�̖�.
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.BRAND_FEE;
                                break;
                        }
                        //����.
                        intKensu++;
                        break;
                    #endregion ���f�B�A�t�B�[�A�u�����h�Ǘ��t�B�[.

                    #region ���W�I�X�|�b�g.
                    case KkhConstAsh.BaitaiCd.RADIO_SPOT:
                        //���p�ɔ}�̃R�[�h�Z�b�g.
                        strBaitaiCd = row.code1.Trim();
                        //���z.
                        drDispMedia.kingak = row.hnmeGak;
                        //�l����.
                        drDispMedia.nebiRitu = row.hnnert;
                        //����.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        //�l����.
                        drDispMedia.nebiRitu = row.hnnert;
                        //�{��.
                        if (string.IsNullOrEmpty(row.sonota2))
                        {
                            drDispMedia.honSu = String.Empty;
                        }
                        else
                        {
                            drDispMedia.honSu = KKHUtility.LongParse(row.sonota2.Trim()) + "�{";
                        }
                        //��.
                        drDispMedia.kyoku = getBaiName2(row.code2.ToString(), drBaitaiCode, KYKCD_RADIO);
                        /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue MOD Start */
                        //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.RADIO_SPOT;
                        //�}�̖�.
                        if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                        {
                            drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.RADIO_SPOT;
                        }
                        else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                        {
                            drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.RADIO;
                        }
                        /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue MOD End */
                        //����.
                        drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                        //����.
                        intKensu++;
                        break;
                    #endregion ���W�I�X�|�b�g.

                    #region �e���r�X�|�b�g.
                    case KkhConstAsh.BaitaiCd.TV_SPOT:
                        //���p�ɔ}�̃R�[�h�Z�b�g.
                        strBaitaiCd = row.code1.Trim();
                        //���z.
                        drDispMedia.kingak = row.hnmeGak;
                        //�l����.
                        drDispMedia.nebiRitu = row.hnnert;
                        //����.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        //�{��.
                        if (string.IsNullOrEmpty(row.sonota2.Trim()))
                        {
                            drDispMedia.honSu = "0�{";
                        }
                        else
                        {
                            drDispMedia.honSu = KKHUtility.LongParse(row.sonota2.Trim()) + "�{";
                        }
                        //�}�̖�.
                        drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.TV_SPOT;
                        //��.
                        drDispMedia.kyoku = getBaiName2(row.code2.ToString(), drBaitaiCode, KYKCD_TV);
                        //����.
                        drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                        //����.
                        intKensu++;
                        break;
                    #endregion �e���r�X�|�b�g.

                    #region �V��.
                    case KkhConstAsh.BaitaiCd.SHINBUN:
                        if (strJyuchuMeisaiNoHoji == row.name33.Substring(0, 14))
                        {
                            //����ł̊i�[�ϐ�.
                            double wk = 0;
                            /* 2017/02/01 �A�T�q����ŕs��Ή� HLC K.Soga DEL Start */
                            ///* 2013/03/27 HLC T.Sonobe MOD Start */
                            ////dblSupposeSyohizei = 1 + (double.Parse(row.ritu1.Trim()) * 0.01);
                            //if (row.ritu1.Trim() != "0")
                            //{
                            //    dblSupposeSyohizei = 1 + (double.Parse(row.ritu1.Trim()) * 0.01);
                            //}
                            ///* 2013/03/27 HLC T.Sonobe MOD End */
                            //double syouhi = (double.Parse(row.ritu1.Trim()) * 0.01) * double.Parse(row.seiGak.Trim());
                            ///* 2015/06/08 �A�T�q�Ή� K.Fujisaki MOD Start */
                            ////int syohizei = (int)Math.Truncate(syouhi);
                            //int syohizei = 0;
                            //if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                            //{
                            //    syohizei = (int)Math.Truncate(syouhi);
                            //}
                            //else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                            //{
                            //    syohizei = (int)Math.Round(syouhi);
                            //}
                            ///* 2015/06/08 �A�T�q�Ή� K.Fujisaki MOD End */
                            /* 2017/02/01 �A�T�q����ŕs��Ή� HLC K.Soga DEL End */

                            //�O��̎󒍖��׏���Ŋz�����݂���ꍇ(�����󒍖��ׂ����݂���ꍇ).
                            if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei))
                            {
                                //�O��̎󒍖��׏���Ŋz���擾.
                                wk = double.Parse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei);
                            }
                            /* 2017/02/01 �A�T�q����ŕs��Ή� HLC K.Soga MOD Start */
                            //double wk2 = wk + syohizei;
                            //���Z��������ŋ��z���擾.
                            double wk2 = wk + double.Parse(row.kngk1);
                            /* 2017/02/01 �A�T�q����ŕs��Ή� HLC K.Soga MOD End */

                            //�}�̏��1��
                            if (dsash.displayMedia.Rows.Count > 1)
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei = wk2.ToString();
                            }
                            /* 2017/02/01 �A�T�q����ŕs��Ή� HLC K.Soga MOD Start */
                            //���v.
                            //dblSupposeSyoukei += double.Parse(syohizei.ToString()) + double.Parse(row.seiGak.Trim());
                            dblSupposeSyoukei += double.Parse(row.kngk1) + double.Parse(row.seiGak);
                            /* 2017/02/01 �A�T�q����ŕs��Ή� HLC K.Soga MOD End */

                            /*
                             * �l��.
                             */
                            //���Z.
                            strClcResult1 = clcRyokin(row.seiGak, dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].nebiki);
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].nebiki = strClcResult1;

                            //��ږ��ɂ��}������f�[�^�̃J�������w�肷��.
                            switch (row.name2)
                            {
                                case "�f�ڗ�":
                                    string ksaiRyo = "0";
                                    string ksaiNebi = "0";

                                    //���Z. 
                                    //�f�ڗ�. 
                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo))
                                    {
                                        ksaiRyo = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo;
                                    }
                                    strClcResult1 = clcRyokin(row.hnmeGak, ksaiRyo);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo = strClcResult1;

                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter))
                                    {
                                        ksaiNebi = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter;
                                    }
                                    strClcResult2 = clcRyokin(row.seiGak, ksaiNebi);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter = strClcResult2;

                                    //�f�ڗ��l����.
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyoNebiRitu = row.hnnert.Trim();
                                    break;
                                case "�w�藿":
                                case "�g�֗�":
                                case "��A�ŗ�":

                                    string siteRyo = "0";
                                    string siteNebi = "0";

                                    //���Z.
                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiRyo))
                                    {
                                        siteRyo = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiRyo;
                                    }
                                    strClcResult1 = clcRyokin(row.hnmeGak, siteRyo);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiRyo = strClcResult1;


                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiNebiAfter))
                                    {
                                        siteNebi = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiNebiAfter;
                                    }
                                    strClcResult2 = clcRyokin(row.seiGak, siteNebi);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiNebiAfter = strClcResult2;

                                    //�w�藿�l����.
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiRyoNebiRitu = row.hnnert.Trim();
                                    break;
                                case "�F����":

                                    string sikiRyo = "0";
                                    string sikiNebi = "0";

                                    //���Z.
                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuRyo))
                                    {
                                        sikiRyo = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuRyo;
                                    }
                                    strClcResult1 = clcRyokin(row.hnmeGak, sikiRyo);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuRyo = strClcResult1;

                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuNebiAfter))
                                    {
                                        sikiNebi = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuNebiAfter;
                                    }
                                    strClcResult2 = clcRyokin(row.seiGak, sikiNebi);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuNebiAfter = strClcResult2;

                                    //�F�����l����.
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuRyoNebiRitu = row.hnnert.Trim();
                                    break;
                                default:

                                    ksaiRyo = "0";
                                    ksaiNebi = "0";

                                    /*
                                     * ���Z.
                                     */
                                    //�f�ڗ�. 
                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo))
                                    {
                                        ksaiRyo = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo;
                                    }

                                    strClcResult1 = clcRyokin(row.hnmeGak, ksaiRyo);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo = strClcResult1;

                                    //�l����.
                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter))
                                    {
                                        ksaiNebi = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter;
                                    }
                                    strClcResult2 = clcRyokin(row.seiGak, ksaiNebi);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter = strClcResult2;

                                    //��ʖ�����ږ�.
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName = row.name2.Trim();
                                    break;
                            }

                            //�}�̃R�[�h.
                            strBaitaiCd = row.code1.Trim();
                            //�l����.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].nebiRitu = "-";
                            //��.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kyoku = getBaiName2(row.code2.ToString(), drBaitaiCode, KYKCD_SHINBN);
                            /* 2015/03/31 �A�T�q�Ή� Miyanoue MOD Start */
                            //�}�̖�.
                            //dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].baitaiName = KkhConstAsh.BaitaiNm.SHINBUN;
                            if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].baitaiName = KkhConstAsh.BaitaiNm.SHINBUN_KOUKOKU;
                            }
                            else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].baitaiName = KkhConstAsh.BaitaiNm.SHINBUN;
                            }
                            /* 2015/03/31 �A�T�q�Ή� Miyanoue MOD End */
                            //�f�ڔN����.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiYyMmDd = YyMmDd(row.name5.Trim());
                            //����.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kenName = row.kkNameKj.Trim();
                            //��ږ��ɂ��}������f�[�^�̃J�������w�肷��.
                            switch (row.name2)
                            {
                                case "�f�ڗ�":
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName = row.name2.Trim();
                                    break;
                                case "�w�藿":
                                case "�g�֗�":
                                case "��A�ŗ�":
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName2 = row.name2.Trim();
                                    break;
                                case "�F����":
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName3 = row.name2.Trim();
                                    break;
                                default:
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName = row.name2.Trim();
                                    break;
                            }
                            //�L�G�敪.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kizatuKbn = kizatuGet(row.sonota5.Trim());
                            //�f�ڔ�.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiBan = keisaiGet(row.sonota6.Trim());
                            //�X�y�[�X.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].space = row.name1;
                            //���[�敪.
                            if (row.sonota3.Trim() == "1")
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].asayuKbn = "��";
                            }
                            else if (row.sonota3.Trim() == "2")
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].asayuKbn = "�[";
                            }
                            else
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].asayuKbn = string.Empty;
                            }
                        }
                        else
                        {
                            //�}�̃R�[�h.
                            strBaitaiCd = row.code1.Trim();
                            //�l����.
                            drDispMedia.nebiRitu = "-";
                            //��.
                            drDispMedia.kyoku = getBaiName2(row.code2.ToString(), drBaitaiCode, KYKCD_SHINBN);
                            /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue MOD Start */
                            //�}�̖�.
                            //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.SHINBUN;
                            if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                            {
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.SHINBUN_KOUKOKU;
                            }
                            else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                            {
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.SHINBUN;
                            }
                            /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue MOD Start */
                            //�f�ڔN����.
                            drDispMedia.keisaiYyMmDd = YyMmDd(row.name5.Trim());
                            //����.
                            drDispMedia.kenName = row.kkNameKj.Trim();
                            //��ږ��ɂ��}������f�[�^�̃J�������w�肷��.
                            switch (row.name2)
                            {
                                case "�f�ڗ�":
                                    drDispMedia.keisaiRyo = row.hnmeGak;
                                    drDispMedia.keisaiNebiAfter = row.seiGak;
                                    drDispMedia.keisaiRyoNebiRitu = row.hnnert;
                                    drDispMedia.syuAndHiName = row.name2.Trim();
                                    break;
                                case "�w�藿":
                                case "�g�֗�":
                                case "��A�ŗ�":
                                    drDispMedia.siteiRyo = row.hnmeGak;
                                    drDispMedia.siteiNebiAfter = row.seiGak;
                                    drDispMedia.siteiRyoNebiRitu = row.hnnert;
                                    drDispMedia.syuAndHiName2 = row.name2.Trim();
                                    break;
                                case "�F����":
                                    drDispMedia.sikisatuRyo = row.hnmeGak;
                                    drDispMedia.sikisatuNebiAfter = row.seiGak;
                                    drDispMedia.sikisatuRyoNebiRitu = row.hnnert;
                                    drDispMedia.syuAndHiName3 = row.name2.Trim();
                                    break;
                                default:
                                    drDispMedia.keisaiRyo = row.hnmeGak;
                                    drDispMedia.keisaiNebiAfter = row.seiGak;
                                    drDispMedia.keisaiRyoNebiRitu = row.hnnert;
                                    drDispMedia.syuAndHiName = row.name2.Trim();
                                    break;
                            }
                            //�L�G�敪.
                            drDispMedia.kizatuKbn = kizatuGet(row.sonota5.Trim());
                            //�f�ڔ�.
                            drDispMedia.keisaiBan = keisaiGet(row.sonota6.Trim());
                            //�X�y�[�X.
                            drDispMedia.space = row.name1;
                            //���[�敪.
                            if (row.sonota3.Trim() == "1")
                            {
                                drDispMedia.asayuKbn = "��";
                            }
                            else if (row.sonota3.Trim() == "2")
                            {
                                drDispMedia.asayuKbn = "�[";
                            }
                            else
                            {
                                drDispMedia.asayuKbn = string.Empty;
                            }

                            //���v .
                            dblGoukei = 0;

                            //����.
                            intKensu++;
                        }
                        break;
                    #endregion �V��.

                    #region �G��.
                    case KkhConstAsh.BaitaiCd.ZASHI:
                        //�󒍖���No������̏ꍇ.
                        if (strJyuchuMeisaiNoHoji == row.name33.Substring(0, 14))
                        {
                            //����ł̊i�[�ϐ�.
                            double wk = 0;

                            /* 2017/02/01 �A�T�q����ŕs��Ή� HLC K.Soga DEL Start */
                            ///* 2013/03/27 HLC T.Sonobe MOD Start */
                            ////dblSupposeSyohizei = 1 + (double.Parse(row.ritu1.Trim()) * 0.01);
                            //if (row.ritu1.Trim() != "0")
                            //{
                            //    dblSupposeSyohizei = 1 + (double.Parse(row.ritu1.Trim()) * 0.01);
                            //}
                            ///* 2013/03/27 HLC T.Sonobe MOD End */
                            //double syouhi = (double.Parse(row.ritu1.Trim()) * 0.01) * double.Parse(row.seiGak.Trim());

                            ///* 2015/06/08 �A�T�q�Ή� K.Fujisaki MOD Start */
                            ////int syohizei = (int)Math.Truncate(syouhi);
                            //int syohizei = 0;
                            //if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                            //{
                            //    syohizei = (int)Math.Truncate(syouhi);
                            //}
                            //else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                            //{
                            //    syohizei = (int)Math.Round(syouhi);
                            //}
                            ///* 2015/06/08 �A�T�q�Ή� K.Fujisaki MOD End */
                            /* 2017/02/01 �A�T�q����ŕs��Ή� HLC K.Soga DEL End */

                            //�O��̎󒍖��׏���Ŋz�����݂���ꍇ(�����󒍖��ׂ����݂���ꍇ).
                            if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei))
                            {
                                //�O��̎󒍖��׏���Ŋz���擾.
                                wk = double.Parse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei);
                            }

                            /* 2017/02/01 �A�T�q����ŕs��Ή� HLC K.Soga MOD Start */
                            //double wk2 = wk + syohizei;
                            //���Z��������ŋ��z���擾.
                            double wk2 = wk + double.Parse(row.kngk1);
                            /* 2017/02/01 �A�T�q����ŕs��Ή� HLC K.Soga MOD End */

                            //�}�̏��1��
                            if (dsash.displayMedia.Rows.Count > 1)
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei = wk2.ToString();
                            }

                            /* 2017/02/01 �A�T�q����ŕs��Ή� HLC K.Soga MOD Start */
                            //���v.
                            //dblSupposeSyoukei += double.Parse(syohizei.ToString()) + double.Parse(row.seiGak.Trim());
                            dblSupposeSyoukei += double.Parse(row.kngk1) + double.Parse(row.seiGak);
                            /* 2017/02/01 �A�T�q����ŕs��Ή� HLC K.Soga MOD End */

                            /*
                             * �l��.
                             */
                            //���Z.
                            strClcResult1 = clcRyokin(row.seiGak, dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].nebiki);
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].nebiki = strClcResult1;

                            //��ږ��ɂ��}������f�[�^�̃J�������w�肷��.
                            switch (row.name2.Trim())
                            {
                                case "�f�ڗ�":
                                    drDispMedia.syuAndHiName = row.name2.Trim();
                                    string ksaiRyo = "0";
                                    string ksaiNebi = "0";

                                    //���Z.
                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo))
                                    {
                                        ksaiRyo = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo;
                                    }
                                    strClcResult1 = clcRyokin(row.hnmeGak, ksaiRyo);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo = strClcResult1;

                                    if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter))
                                    {
                                        ksaiNebi = dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter;
                                    }

                                    strClcResult2 = clcRyokin(row.seiGak, ksaiNebi);
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter = strClcResult2;

                                    //�f�ڗ��l����.
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyoNebiRitu = row.hnnert.Trim();
                                    break;
                                default:
                                    if (string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName2) || dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName2.Trim().Equals(row.name2.Trim()))
                                    {
                                        drDispMedia.syuAndHiName2 = row.name2.Trim();
                                        drDispMedia.siteiRyo = "0";

                                        //���Z.
                                        strClcResult1 = clcRyokin(row.hnmeGak, dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiRyo);
                                        dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiRyo = strClcResult1;

                                        strClcResult2 = clcRyokin(row.seiGak, dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiNebiAfter);
                                        dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiNebiAfter = strClcResult2;
                                    }
                                    else
                                    {
                                        drDispMedia.syuAndHiName3 = row.name2.Trim();
                                        drDispMedia.sikisatuRyo = "0";

                                        //���Z.
                                        strClcResult1 = clcRyokin(row.hnmeGak, dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuRyo);
                                        dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuRyo = strClcResult1;

                                        strClcResult2 = clcRyokin(row.seiGak, dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuNebiAfter);
                                        dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuNebiAfter = strClcResult2;

                                    }
                                    break;
                            }

                            //�}�̃R�[�h.
                            strBaitaiCd = row.code1.Trim();
                            //�l����.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].nebiRitu = row.hnnert;
                            //��.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kyoku = getBaiName2(row.code6.Trim(), drBaitaiCode, KYKCD_ZASHI);
                            /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue MOD�@Start */
                            //dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].baitaiName = KkhConstAsh.BaitaiNm.ZASHI;
                            //�}�̖�.
                            if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].baitaiName = KkhConstAsh.BaitaiNm.ZASSHI_KOUKOKU;
                            }
                            else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                            {
                                dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].baitaiName = KkhConstAsh.BaitaiNm.ZASHI;
                            }
                            /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue MOD�@End */
                            //����.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kikan = YyMmDd(row.name5.Trim());
                            //�X�y�[�X.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].space = row.name1.Trim();
                            //����.
                            dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;

                            //��ږ��ɂ��}������f�[�^�̃J�������w�肷��.
                            switch (row.name2.Trim())
                            {
                                case "�f�ڗ�":
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName = row.name2.Trim();
                                    dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiRyo = "0";
                                    break;
                                default:
                                    if (string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName2.Trim()) || dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName2.Trim().Equals(row.name2.Trim()))
                                    {
                                        dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName2 = row.name2.Trim();
                                    }
                                    else
                                    {
                                        dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syuAndHiName3 = row.name2.Trim();
                                    }
                                    break;
                            }
                        }
                        //�󒍖���No���قȂ�ꍇ.
                        else
                        {
                            //�}�̃R�[�h.
                            strBaitaiCd = row.code1.Trim();
                            //�l����.
                            drDispMedia.nebiRitu = row.hnnert;
                            //��.
                            drDispMedia.kyoku = getBaiName2(row.code6.Trim(), drBaitaiCode, KYKCD_ZASHI);
                            /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue ADD Start */
                            //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.ZASHI;
                            //�}�̖�.
                            if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                            {
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.ZASSHI_KOUKOKU;
                            }
                            else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                            {
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.ZASHI;
                            }
                            /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue ADD End */
                            //����.
                            drDispMedia.kikan = YyMmDd(row.name5.Trim());
                            //drDispMedia.kikan = YyMmDd(row.name5.Trim());
                            //�X�y�[�X.
                            drDispMedia.space = row.name1.Trim();
                            //��ʖ�����ږ�.
                            //drDispMedia.syuAndHiName = row.name2.Trim();
                            //����.
                            drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;

                            //��ږ��ɂ��}������f�[�^�̃J�������w�肷��.
                            switch (row.name2.Trim())
                            {
                                case "�f�ڗ�":
                                    drDispMedia.syuAndHiName = row.name2.Trim();
                                    drDispMedia.keisaiRyo = "0";
                                    if (!string.IsNullOrEmpty(row.hnmeGak.Trim()))
                                    {
                                        drDispMedia.keisaiRyo = row.hnmeGak.Trim();
                                    }
                                    drDispMedia.keisaiNebiAfter = row.seiGak.Trim();
                                    break;
                                default:
                                    if (string.IsNullOrEmpty(drDispMedia.syuAndHiName2.Trim()))
                                    {
                                        drDispMedia.syuAndHiName2 = row.name2.Trim();
                                        drDispMedia.siteiRyo = "0";

                                        if (!string.IsNullOrEmpty(row.hnmeGak.Trim()))
                                        {
                                            drDispMedia.siteiRyo = row.hnmeGak.Trim();
                                        }
                                        drDispMedia.siteiNebiAfter = row.seiGak.Trim();
                                    }
                                    else
                                    {
                                        drDispMedia.syuAndHiName3 = row.name2.Trim();
                                        drDispMedia.sikisatuRyo = "0";

                                        if (!string.IsNullOrEmpty(row.hnmeGak.Trim()))
                                        {
                                            drDispMedia.sikisatuRyo = row.hnmeGak.Trim();
                                        }
                                        drDispMedia.sikisatuNebiAfter = row.seiGak.Trim();
                                    }
                                    break;
                            }

                            //���v.
                            dblGoukei = 0;

                            //����.
                            intKensu++;
                        }
                        break;
                    #endregion �G��.

                    #region ���.
                    case KkhConstAsh.BaitaiCd.KOUTSU:
                        //���p�ɔ}�̃R�[�h�Z�b�g.
                        strBaitaiCd = row.code1.Trim();
                        //�l����.
                        drDispMedia.nebiRitu = row.hnnert;
                        //���z.
                        drDispMedia.kingak = row.hnmeGak;
                        //��.
                        drDispMedia.kyoku = getBaiName2(row.code2.Trim(), drBaitaiCode, KYKCD_OOH);
                        /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue MOD Start */
                        //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.KOUTSU;
                        //�}�̖�.
                        if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                        {
                            drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.KOUTSUU_KOUKOKU;
                        }
                        else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                        {
                            drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.KOUTSU;
                        }
                        /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue MOD End */
                        //����.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        //��ʖ�����ږ�.
                        drDispMedia.syuAndHiName = row.name6.Trim() + " " + row.himknmKj.Trim();
                        //����.
                        drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                        //����.
                        intKensu++;
                        break;
                    #endregion ���.

                    #region ���O�L���A�C�x���g.
                    case KkhConstAsh.BaitaiCd.OKUGAI:
                    case KkhConstAsh.BaitaiCd.EVENT:
                        //���p�ɔ}�̃R�[�h�Z�b�g.
                        strBaitaiCd = row.code1.Trim();
                        //�l����.
                        drDispMedia.nebiRitu = row.hnnert;
                        //���z.
                        drDispMedia.kingak = row.hnmeGak;
                        //����.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        //��.
                        drDispMedia.kyoku = getBaiName2(row.code2.Trim(), drBaitaiCode, KYKCD_KOEVE);
                        switch (row.code1.Trim())
                        {
                            //�}�̖�.
                            case KkhConstAsh.BaitaiCd.OKUGAI:
                                /* 2015/03/31 �A�T�q�Ή� Miyanoue Start */
                                //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.OKUGAIBAITAI;
                                if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                                {
                                    drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.KOUKOKURYOU_OKUGAI;
                                }
                                else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                                {
                                    drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.OKUGAIBAITAI;
                                }
                                /* 2015/03/31 �A�T�q�Ή� Miyanoue End */
                                break;
                            case KkhConstAsh.BaitaiCd.EVENT:
                                /* 2015/03/31 �A�T�q�Ή� Miyanoue Start */
                                //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.EVENT;
                                if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                                {
                                    drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.EVENT_KOUKOU;
                                }
                                else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                                {
                                    drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.EVENT;
                                }
                                /* 2015/03/31 �A�T�q�Ή� Miyanoue End */
                                break;
                        }

                        //����.
                        drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;

                        //����.
                        intKensu++;
                        break;
                    #endregion ���O�L���A�C�x���g.

                    #region ����.
                    case KkhConstAsh.BaitaiCd.SEISAKU:
                        //���p�ɔ}�̃R�[�h�Z�b�g.
                        strBaitaiCd = row.code1.Trim();
                        //�l����.
                        drDispMedia.nebiRitu = row.hnnert;
                        //���z.
                        drDispMedia.kingak = row.hnmeGak;
                        //����.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        //��.
                        drDispMedia.kyoku = getBaiName2(row.code2.Trim(), drBaitaiCode, KYKCD_SEISAK);
                        //�}�̖�.
                        drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.SEISAKU;
                        //����.
                        drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                        //����.
                        intKensu++;
                        break;
                    #endregion ����.

                    /* 2013/02/22 PR�}�̒ǉ��Ή� JSE Okazaki ADD Start */
                    #region PR.
                    case KkhConstAsh.BaitaiCd.PR:
                        //���p�ɔ}�̃R�[�h�Z�b�g.
                        strBaitaiCd = row.code1.Trim();
                        //�l����.
                        drDispMedia.nebiRitu = row.hnnert;
                        //���z.
                        drDispMedia.kingak = row.hnmeGak;
                        //����.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        //��.
                        drDispMedia.kyoku = getBaiName2(row.code2.Trim(), drBaitaiCode, KYKCD_SEISAK);
                        //�}�̖�.
                        drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.PR;
                        //����.
                        drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                        //����.
                        intKensu++;
                        break;
                    #endregion PR.
                    /* 2013/02/22 PR�}�̒ǉ��Ή� JSE Okazaki ADD End */

                    #region ���̑�.
                    default:
                        //���p�ɔ}�̃R�[�h�Z�b�g.
                        strBaitaiCd = row.code1.Trim();
                        //�l����.
                        drDispMedia.nebiRitu = row.hnnert;
                        //���z.
                        drDispMedia.kingak = row.hnmeGak;
                        /* 2015/07/08 HLC K.Soga �A�T�q�Ή� MOD Start */
                        //��.
                        //drDispMedia.kyoku = getBaiName2(row.code2.Trim(), drBaitaiCode, KYKCD_SONOTA);
                        drDispMedia.kyoku = getBaiNameSonota(row.code2.Trim(), drBaitaiCode, KYKCD_SONOTA, strBaitaiCd);
                        /* 2015/07/08 HLC K.Soga �A�T�q�Ή� MOD End */
                        //����.
                        drDispMedia.kikan = kikanFormatSet(row.name5.Trim());
                        switch (row.code1.Trim())
                        {//�}�̖�.
                            case KkhConstAsh.BaitaiCd.NEW_MEDIA:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.NEW_MEDIA;
                                //����.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.INTERNET:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.INTERNET;
                                //����.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.BS:
                                /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue MOD Start */
                                //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.BS;
                                //�}�̖�.
                                if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                                {
                                    drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.BS_INRYOU;
                                }
                                else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                                {
                                    drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.BS;
                                }
                                /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue MOD End */
                                break;
                            case KkhConstAsh.BaitaiCd.CS:
                                /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue MOD Start */
                                //drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.CS;
                                //�}�̖�.
                                if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                                {
                                    drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.CS_INRYOU;
                                }
                                else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                                {
                                    drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.CS;
                                }
                                /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue MOD End */
                                break;
                            case KkhConstAsh.BaitaiCd.TYOUSA:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.TYOUSA;
                                //����.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.SONOTA:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.SONOTA;
                                //����.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue ADD Start */
                            case KkhConstAsh.BaitaiCd.IMAGEGIRL:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.IMAGEGIRL;
                                //����.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.JIMOTO:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.JIMOTO;
                                //����.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.NIKKA:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.NIKKA;
                                //����.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.PR_INRYOU:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.PR_INRYOU;
                                //����.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.AMEFUT:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.AMEFUT;
                                //����.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.TALENT:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.TALENT;
                                //����.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.COPYRIGHT:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.COPYRIGHT;
                                //����.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.SOZAI:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.SOZAI;
                                //����.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.CF:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.CF;
                                //����.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.SEISAKU_FEE:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.SEISAKU_FEE;
                                //����.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.JASRAC:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.JASRAC;
                                //����.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.SYANAISHIRYOU:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.SYANAISHIRYOU;
                                //����.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            case KkhConstAsh.BaitaiCd.KOUKOKURYO:
                                drDispMedia.baitaiName = KkhConstAsh.BaitaiNm.KOUKOKURYO;
                                //����.
                                drDispMedia.kenName = mastNameGet(row.code3.Trim(), drSyohin, KKHSystemConst.SyouhinMaster.MAST_SYBT) + "   " + row.kkNameKj;
                                break;
                            /* 2015/03/31 �A�T�q�Ή� JSE Miyanoue ADD End */
                        }

                        //����.
                        intKensu++;
                        break;
                    #endregion ���̑�.
                }
                #endregion �}�̖��Œl�̐ݒ���s��.

                /* 2015/06/02 �A�T�q�Ή� HLC K.Fujisaki ADD Start */
                // ���}�̃R�[�h����V�}�̖��́A�V�}�̃R�[�h���擾����.
                AshBaitaiUtility.BaitaiResult res = ashBaitaiUtility.ConvertOldCdToNewCd(row.code1.Trim());
                drDispMedia.baitaiName = res.baitaiNm;
                /* 2015/06/02 �A�T�q�Ή� HLC K.Fujisaki ADD End */
                /* 2017/01/31 �A�T�q����őΉ� HLC K.Soga DEL Start */
                /* 2013/12/04 ����őΉ� HLC H.Watabe ADD Start */
                //�����p�ɒl��ێ�.
                //dblMediaTaxSumFromRows += double.Parse(drDispMedia.nebiki) + double.Parse(drDispMedia.syouhiZei);
                /* 2013/12/04 ����őΉ� HLC H.Watabe ADD End */
                /* 2017/01/31 �A�T�q����őΉ� HLC K.Soga DEL End */

                /*
                 * ���v���Z�o����.
                 */
                //�󒍖���No������̏ꍇ.
                if (strJyuchuMeisaiNoHoji == row.name33.Substring(0, 14))
                {
                    //�}�̃R�[�h���V���A�G��.
                    if (row.code1.Trim() == KkhConstAsh.BaitaiCd.SHINBUN || row.code1.Trim() == KkhConstAsh.BaitaiCd.ZASHI)
                    {
                        //�l����f�ڗ�.
                        double nebiKsai = 0;
                        if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter))
                        {
                            nebiKsai = KKHUtility.DouParse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].keisaiNebiAfter);
                        }

                        //�l����w�藿.
                        double nebiSitei = 0;
                        if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiNebiAfter))
                        {
                            nebiSitei = KKHUtility.DouParse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].siteiNebiAfter);
                        }

                        //�l����F����.
                        double dblNebikiIro = 0;
                        if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuNebiAfter))
                        {
                            dblNebikiIro = KKHUtility.DouParse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].sikisatuNebiAfter);
                        }

                        //�����.
                        double dblShohiZei = 0;
                        if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei))
                        {
                            dblShohiZei = KKHUtility.DouParse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei);
                        }

                        dblGoukei = nebiKsai + nebiSitei + dblNebikiIro + dblShohiZei;

                        dsash.displayMedia[dsash.displayMedia.Rows.Count - 1].kingak = dblGoukei.ToString();

                        //���v�p�ɋ��z�i�[(�l���̑����Z).
                        dblSyoukei = dblSyoukei + double.Parse(drDispMedia.nebiki.Trim());
                    }
                    //�}�̃R�[�h���V���A�G���ȊO.
                    else
                    {
                        //�l���z.
                        double dblNebikiGaku = 0;
                        if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].nebiki))
                        {
                            dblNebikiGaku = KKHUtility.DouParse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].nebiki);
                        }

                        //�����.
                        double dblShohiZei = 0;
                        if (!string.IsNullOrEmpty(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei))
                        {
                            dblShohiZei = KKHUtility.DouParse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].syouhiZei);
                        }

                        dblGoukei = dblNebikiGaku + dblShohiZei;

                        //�}�̃R�[�h.
                        drDispMedia.baitaiCd = row.code1 + "1";

                        //Row�̒ǉ�.
                        dsash.displayMedia.AdddisplayMediaRow(drDispMedia);

                        //XML�p�Ƀf�[�^������.
                        repds.displayMedia.ImportRow(drDispMedia);

                        //�\���p���v�̃Z�b�g.
                        drDispMediaGoukei.kyoku = "���v";
                        //���v���Z�o����.
                        dblGoukei = double.Parse(drDispMedia.nebiki) + double.Parse(drDispMedia.syouhiZei);
                        /* 2013/12/04 ����őΉ� HLC H.Watabe ADD Start */
                        //dblMediaTaxSumFromRows += dblGoukei;
                        /* 2013/12/04 ����őΉ� HLC H.Watabe ADD End */
                        drDispMediaGoukei.kingak = dblGoukei.ToString();
                        drDispMediaGoukei.baitaiCd = row.code1 + "2";

                        //���v�p�ɋ��z�i�[(�l���̑����Z).
                        dblSyoukei = dblSyoukei + double.Parse(drDispMedia.nebiki.Trim());

                        /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki MOD Start */
                        //���v�p.
                        //dblSupposeSyoukei += Math.Truncate(dblGoukei);
                        //�A�T�q�����̏ꍇ.
                        if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                        {
                            dblSupposeSyoukei += Math.Truncate(dblGoukei);
                        }
                        //�A�T�q�r�[���̏ꍇ.
                        else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                        {
                            dblSupposeSyoukei += Math.Round(dblGoukei);
                        }
                        /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki MOD End */
                        /* 2013/03/28 HLC T.Sonobe DEL Start */
                        //if (row.ritu1.Trim() == "0")
                        //{
                        //    //����ŗ���0�̏ꍇ�������z�𑫂��Ă���.
                        //    dblHikazei += double.Parse(row.seiGak.Trim());
                        //}
                        /* 2013/03/28 HLC T.Sonobe DEL End */

                        dblGoukei = 0;
                        dsash.displayMedia.AdddisplayMediaRow(drDispMediaGoukei);
                    }

                    if (row.ritu1.Trim() == "0")
                    {
                        //����ŗ���0�̏ꍇ�������z�𑫂��Ă���.
                        dblHikazei += double.Parse(row.seiGak.Trim());
                    }
                }
                //�󒍖���No���قȂ�ꍇ.
                else
                {
                    //�}�̃R�[�h.
                    drDispMedia.baitaiCd = row.code1 + "1";

                    //Row�̒ǉ�.
                    dsash.displayMedia.AdddisplayMediaRow(drDispMedia);

                    //XML�p�Ƀf�[�^������.
                    repds.displayMedia.ImportRow(drDispMedia);

                    //�\���p���v�̃Z�b�g.
                    drDispMediaGoukei.kyoku = "���v";
                    //���v���Z�o����.
                    dblGoukei = double.Parse(drDispMedia.nebiki) + double.Parse(drDispMedia.syouhiZei);
                    /* 2013/12/04 ����őΉ� HLC H.Watabe ADD Start */
                    //dblMediaTaxSumFromRows += dblGoukei;
                    /* 2013/12/04 ����őΉ� HLC H.Watabe ADD End */
                    drDispMediaGoukei.kingak = dblGoukei.ToString();
                    drDispMediaGoukei.baitaiCd = row.code1 + "2";

                    //���v�p�ɋ��z�i�[(�l���̑����Z).
                    dblSyoukei = dblSyoukei + double.Parse(drDispMedia.nebiki.Trim());

                    /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki MOD Start */
                    //���v�p.
                    //dblSupposeSyoukei += Math.Truncate(dblGoukei);
                    //�A�T�q�����̏ꍇ.
                    if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                    {
                        dblSupposeSyoukei += Math.Truncate(dblGoukei);
                    }
                    //�A�T�q�r�[���̏ꍇ.
                    else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                    {
                        dblSupposeSyoukei += Math.Round(dblGoukei);
                    }
                    /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki MOD End */

                    if (row.ritu1.Trim() == "0")
                    {
                        //����ŗ���0�̏ꍇ�������z�𑫂��Ă���.
                        dblHikazei += double.Parse(row.seiGak.Trim());
                    }

                    dblGoukei = 0;
                    dsash.displayMedia.AdddisplayMediaRow(drDispMediaGoukei);
                }

                //�󒍖���No�ێ�.
                strJyuchuMeisaiNoHoji = row.name33.Substring(0, 14);

                intCnt++;
            }

            /* 2017/01/31 �A�T�q����ŕs��Ή� HLC K.Soga DEL Start */
            ///* 2013/12/06 ����őΉ� HLC H.Watabe MOD Start */
            //double sum = 0;
            //for (int index = 0; index < lstZeiRate.Count; index++)
            //{
            //    /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki MOD Start */
            //    //sum += Math.Truncate((1 + (lstZeiRate[index] * 0.01)) * lstAmount[index]);
            //    //�����̏ꍇ.
            //    if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
            //    {
            //        sum += Math.Truncate((1 + (lstZeiRate[index] * 0.01)) * lstAmount[index]);
            //    }
            //    else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
            //    {
            //        sum += Math.Round((1 + (lstZeiRate[index] * 0.01)) * lstAmount[index]);
            //    }
            //    /* 2015/06/08 �A�T�q�Ή� HLC K.Fujisaki MOD End */
            //}
            /* 2017/01/31 �A�T�q����ŕs��Ή� HLC K.Soga DEL End */
            //dblTyousei = (dblSyoukei - dblHikazei) * 1.05; //+ dblHikazei) - dblSupposeSyoukei;
            //dblTyousei = (dblSyoukei - dblHikazei) * dblSupposeSyohizei;
            //dblTyousei = dblTyousei + dblHikazei - dblSupposeSyoukei;
            //dblTyousei = ToHalfAdjust(dblTyousei, 0);
            /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga DEL Start */
            //dblTyousei = sum - dblMediaTaxSumFromRows;
            /* 2013/12/06 ����őΉ� HLC H.Watabe MOD End */
            //double dbdb = ToHalfAdjust(dblTyousei, 0) + dblSupposeSyoukei;
            /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga DEL End */
            //���v.
            drNewDispMedia.kyoku = KKHSystemConst.KoteiMongon.SYOKEI;
            //���v���z.
            drNewDispMedia.kingak = dblSupposeSyoukei.ToString();
            //�}�̃R�[�h.
            drNewDispMedia.baitaiCd = strBaitaiCd + "3";

            RepDsAsh.allbaitaiRow allbaitairow1 = repds.allbaitai.NewallbaitaiRow();

            /*
             * XML�p.
             */
            allbaitairow1.baitaicd = strBaitaiCd;
            allbaitairow1.zeinasi = dblSyoukei.ToString();
            allbaitairow1.goukei = dblSupposeSyoukei.ToString();

            //�}��.
            repds.allbaitai.AddallbaitaiRow(allbaitairow1);
            dsash.displayMedia.AdddisplayMediaRow(drNewDispMedia);

            /*
             * ������.
             */
            //���v.
            dblSyoukei = 0;
            //��ې�.
            dblHikazei = 0;
            //���v.
            dblSupposeSyoukei = 0;

            /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga DEL Start */
            #region �[������(�폜).
            /* 2013/04/09 HLC T.Sonobe ADD Start */
            //�[��������ŋ��A���v���z�ɔ��f������.
            //double dnum = dblTyousei + double.Parse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 3].syouhiZei.ToString());
            //�����.
            //dsash.displayMedia[dsash.displayMedia.Rows.Count - 3].syouhiZei = dnum.ToString();
            //dnum = dblTyousei + double.Parse(dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kingak.ToString());
            //dsash.displayMedia[dsash.displayMedia.Rows.Count - 2].kingak = dnum.ToString();
            /* 2013/04/09 HLC T.Sonobe ADD End */
            #endregion �[������(�폜).
            /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga DEL End */

            //�J���}�ݒ�.
            SetComma(dsash);

            repds.displayMedia.Clear();
            repds.displayMedia.Merge(dsash.displayMedia);
            RepDsAsh.displayMediaRow[] delrow = (RepDsAsh.displayMediaRow[])repds.displayMedia.Select("kyoku IN ('" + "���v" + "','" + "���v" + "')");
            foreach (RepDsAsh.displayMediaRow row in delrow)
            {
                repds.displayMedia.Rows.Remove(row);
            }

            /* 2015/02/23 �A�T�q�Ή� JSE Miyanoue MOD Start */
            //AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            //���}�̃R�[�h����V�}�̖��́A�V�}�̃R�[�h���擾����.
            for (int i = 0; i < dsash.displayMedia.Rows.Count; i++)
            {
                String baitaiCd = dsash.displayMedia[i].baitaiCd;
                String baitaiNm = dsash.displayMedia[i].baitaiName;
                //�}�̃R�[�h��.
                int totalLen = baitaiCd.Length;
                //��1�����������}�̃R�[�h����.
                int len = totalLen - 1;
                //�}�̃R�[�h��ϊ�����.
                String bCd = baitaiCd.Substring(0, len);
                String bCd1keta = baitaiCd.Substring(len, 1);
                AshBaitaiUtility.BaitaiResult res = ashBaitaiUtility.ConvertOldCdToNewCd(bCd);
                String resultBaitaiCd = res.baitaiCd + bCd1keta;

                dsash.displayMedia[i].tokuisakiBaitaiCd = resultBaitaiCd;
                dsash.displayMedia[i].tokuisakiBaitaiName = res.baitaiNm;
            }
            /* 2015/02/23 �A�T�q�Ή� JSE Miyanoue MOD End */

            //�X�v���b�h�f�[�^�\�[�X�֓����.
            medMain_Sheet1.DataSource = dsash.displayMedia;
            //�G�N�Z���{�^��.
            btnXls.Enabled = true;
            //�o�͔}��.
            cmbMedia.Enabled = true;

            //�����̕\��.
            lblKensu.Text = intKensu.ToString() + "��";

            //���[�f�B���O�\���I��.
            base.CloseLoadingDialog();
        }
        #endregion �f�[�^�\��.

        #region �f�[�^Row�����Z�b�g.
        /// <summary>
        /// �f�[�^Row�����Z�b�g.
        /// </summary>
        /// <param name="addrow"></param>
        /// <returns></returns>
        private RepDsAsh.displayMediaRow syokirowSet(RepDsAsh.displayMediaRow addrow)
        {
            addrow.asayuKbn = string.Empty;
            addrow.baitaiCd = string.Empty;
            addrow.tokuisakiBaitaiCd = string.Empty;
            addrow.baitaiName = string.Empty;
            addrow.tokuisakiBaitaiName = string.Empty;
            addrow.hinSyu = string.Empty;
            addrow.honSu = string.Empty;
            addrow.housouWeek = string.Empty;
            addrow.jikan = string.Empty;
            addrow.keisaiBan = string.Empty;
            addrow.keisaiNebiAfter = string.Empty;
            addrow.keisaiRyo = string.Empty;
            addrow.keisaiRyoNebiRitu = string.Empty;
            addrow.keisaiSyubetu = string.Empty;
            addrow.keisaiYyMmDd = string.Empty;
            addrow.kenName = string.Empty;
            addrow.kikan = string.Empty;
            addrow.kingak = string.Empty;
            addrow.kizatuKbn = string.Empty;
            addrow.kyoku = string.Empty;
            addrow.kyokuNet = string.Empty;
            addrow.nebiki = string.Empty;
            addrow.nebiRitu = string.Empty;
            addrow.seisakuhi = string.Empty;
            addrow.sikisatuNebiAfter = string.Empty;
            addrow.sikisatuRyo = string.Empty;
            addrow.sikisatuRyoNebiRitu = string.Empty;
            addrow.siteiNebiAfter = string.Empty;
            addrow.siteiRyo = string.Empty;
            addrow.siteiRyoNebiRitu = string.Empty;
            addrow.space = string.Empty;
            addrow.syouhiRitu = string.Empty;
            addrow.syouhiZei = string.Empty;
            addrow.syuAndHiName = string.Empty;
            addrow.syuAndHiName2 = string.Empty;
            addrow.syuAndHiName3 = string.Empty;
            return addrow;
        }
        #endregion �f�[�^Row�����Z�b�g.

        #region ���Ԃ̌`���Z�b�g.
        /// <summary>
        /// ���Ԃ̌`���Z�b�g.
        /// </summary>
        /// <param name="oldTime"></param>
        /// <returns></returns>
        private string timeFormatSet(string oldTime)
        {
            //������11�ȊO�͏������Ȃ�.
            if (oldTime.Trim().Length != 11) 
            {
                return string.Empty; 
            }

            string newTime = oldTime.Replace(":", "��");
            string leftTime = newTime.Substring(0, 5) + "��";
            string rightTime = newTime.Substring(5, 6) + "��";
            newTime = leftTime + rightTime;

            return newTime;
        }
        #endregion ���Ԃ̌`���Z�b�g.

        #region ���Ԃ̌`���Z�b�g.
        /// <summary>
        /// ���Ԃ̌`���Z�b�g.
        /// </summary>
        /// <param name="oldKikan"></param>
        /// <returns></returns>
        private string kikanFormatSet(string oldKikan)
        {

            if (oldKikan.Trim().Length == 25) 
            {
                return oldKikan; 
            }

            //������16�ȊO�͏������Ȃ�.
            if (oldKikan.Trim().Length != 16)
            {
                //�������W�̏ꍇ�͊J�n�N�������擾.
                if (oldKikan.Trim().Length == 8)
                {
                    string tankikan = oldKikan.Substring(0, 4) + "�N" +
                                      oldKikan.Substring(4, 2) + "��" +
                                      oldKikan.Substring(6, 2) + "���|" + "�N�@���@��";
                    return tankikan;
                }
                return string.Empty;
            }


            string newKikan = oldKikan.Substring(0, 4) + "�N" +
                              oldKikan.Substring(4, 2) + "��" +
                              oldKikan.Substring(6, 2) + "���|" +
                              oldKikan.Substring(8, 4) + "�N" +
                              oldKikan.Substring(12, 2) + "��" +
                              oldKikan.Substring(14, 2) + "��";

            return newKikan;
        }
        #endregion ���Ԃ̌`���Z�b�g.

        #region �����j���̎擾.
        /// <summary>
        /// �����j���̎擾.
        /// </summary>
        /// <param name="oldYymm"></param>
        /// <param name="week"></param>
        /// <returns></returns>
        private string weekDayGet(string oldYymm, string week)
        {
            //������16�ȊO�͏������Ȃ�.
            if (oldYymm.Length != 16) 
            {
                return string.Empty; 
            }

            if (string.IsNullOrEmpty(week)) 
            {
                return string.Empty; 
            }

            //�j���Z�b�g.
            string Youbi = string.Empty;
            //���t�擾.
            int day = 0;
            //���t(string).
            string strDay = string.Empty;
            //�N���̎擾.
            string newYymm = oldYymm.Substring(0, 4) + "/" + oldYymm.Substring(4, 2);
            //�j���d���`�F�b�N.
            string tfFlag = string.Empty;

            //�j���擾���J��Ԃ�.
            for (int i = 0; i < week.Replace("0", string.Empty).Length; i++)
            {
                day = week.IndexOf("1", day) + 1;
                if (day.ToString().Length == 1)
                {
                    strDay = "0" + day.ToString();
                }
                else
                {
                    strDay = day.ToString();
                }
                DateTime dt = DateTime.Parse(newYymm + "/" + strDay);

                //�j���̃Z�b�g.
                switch (dt.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        if (tfFlag.Contains("1")) { break; }
                        Youbi = Youbi + "���A";
                        tfFlag = tfFlag + "1";
                        break;
                    case DayOfWeek.Tuesday:
                        if (tfFlag.Contains("2")) { break; }
                        Youbi = Youbi + "�΁A";
                        tfFlag = tfFlag + "2";
                        break;
                    case DayOfWeek.Wednesday:
                        if (tfFlag.Contains("3")) { break; }
                        Youbi = Youbi + "���A";
                        tfFlag = tfFlag + "3";
                        break;
                    case DayOfWeek.Thursday:
                        if (tfFlag.Contains("4")) { break; }
                        Youbi = Youbi + "�؁A";
                        tfFlag = tfFlag + "4";
                        break;
                    case DayOfWeek.Friday:
                        if (tfFlag.Contains("5")) { break; }
                        Youbi = Youbi + "���A";
                        tfFlag = tfFlag + "5";
                        break;
                    case DayOfWeek.Saturday:
                        if (tfFlag.Contains("6")) { break; }
                        Youbi = Youbi + "�y�A";
                        tfFlag = tfFlag + "6";
                        break;
                    case DayOfWeek.Sunday:
                        if (tfFlag.Contains("7")) { break; }
                        Youbi = Youbi + "���A";
                        tfFlag = tfFlag + "7";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(Youbi))
            {
                //�Ō��","����菜��.
                if (Youbi.Substring(Youbi.Length - 1, 1).Equals("�A")) { Youbi = Youbi.Substring(0, Youbi.Length - 1); }
                return Youbi;
            }

            return string.Empty;
        }
        #endregion �����j���̎擾.

        #region �}�̖��擾.
        /// <summary>
        /// �}�̖��擾.
        /// </summary>
        private void MediaCdGet()
        {
            //�p�����[�^�[�̃Z�b�g.
            ReportAshProcessController.FindReportAshByMedium param = new ReportAshProcessController.FindReportAshByMedium();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = string.Empty;

            //����.
            ReportAshProcessController processController = ReportAshProcessController.GetInstance();
            FindReportAshMediaByCondServiceResult result = processController.findReportMediaCode(param);
            bct = result.dsAshDataSet.BaiCd;
            sdt = result.dsAshDataSet.Syohin;
        }
        #endregion �}�̖��擾.

        #region �}�X�^����̋ǖ��擾�P�p�^�[����.
        /// <summary>
        /// �}�X�^����̋ǖ��擾�P�p�^�[����.
        /// </summary>
        /// <param name="kyokuryakusyo"></param>
        /// <param name="bcrow"></param>
        /// <param name="baitaiCd"></param>
        /// <returns></returns>
        private string getBaiName1(string kyokuryakusyo, RepDsAsh.BaiCdRow[] bcrow, string baitaiCd)
        {
            if (string.IsNullOrEmpty(kyokuryakusyo)) 
            {
                return string.Empty; 
            }

            //�ǖ�.
            string kyoku = string.Empty;
            foreach (RepDsAsh.BaiCdRow row in bcrow)
            {
                //���͂��ꂽ�l�̏ꍇ.
                if (row.field4.Equals(kyokuryakusyo.Trim()))
                {
                    //�}�X�^�Ɠ�����ʂ̏ꍇ.
                    if (row.sybt.Equals(baitaiCd))
                    {
                        kyoku = row.field2.ToString();
                        return kyoku;
                    }
                }
            }

            return kyoku;
        }
        #endregion �}�X�^����̋ǖ��擾�P�p�^�[����.

        #region �}�X�^����ǎ擾2�p�^�[����.
        /// <summary>
        /// �}�X�^����ǎ擾2�p�^�[����.
        /// </summary>
        /// <param name="kyokuryakusyo"></param>
        /// <param name="bcrow"></param>
        /// <param name="baitaiCd"></param>
        /// <returns></returns>
        private string getBaiName2(string kyokuryakusyo, RepDsAsh.BaiCdRow[] bcrow, string baitaiCd)
        {
            if (string.IsNullOrEmpty(kyokuryakusyo)) 
            {
                return string.Empty; 
            }

            //�ǖ�.
            foreach (RepDsAsh.BaiCdRow row in bcrow)
            {
                //���͂��ꂽ�l�̏ꍇ.
                if (row.field1.Equals(kyokuryakusyo.Trim()))
                {
                    //�}�X�^�Ɠ�����ʂ̏ꍇ.
                    if (row.sybt.Equals(baitaiCd))
                    {
                        return row.field2.ToString();
                    }
                }
            }

            return string.Empty;
        }
        #endregion �}�X�^����ǎ擾2�p�^�[����.

        /* 2015/07/08 �A�T�q�Ή� HLC K.Soga ADD Start */
        #region �}�X�^����ǎ擾���̑��}�X�^�[�p.
        /// <summary>
        /// �}�X�^����ǎ擾���̑��}�X�^�[�p.
        /// </summary>
        /// <param name="kyokuryakusyo"></param>
        /// <param name="bcrow"></param>
        /// <param name="baitaiCd"></param>
        /// <param name="baiCd"></param>
        /// <returns></returns>
        private string getBaiNameSonota(string kyokuryakusyo, RepDsAsh.BaiCdRow[] bcrow, string baitaiCd, string baicd)
        {
            //�ǃR�[�h����̏ꍇ.
            if (string.IsNullOrEmpty(kyokuryakusyo)) 
            { 
                return string.Empty; 
            }

            //�ǖ��̎擾.
            RepDsAsh.BaiCdRow[] row = (RepDsAsh.BaiCdRow[])bct.Select("sybt = '" + baitaiCd + "' AND Field1 = '" + kyokuryakusyo + "' AND Field9 = '" + baicd + "' ");

            //�擾����������0���̏ꍇ.
            if (row.Length == 0)
            {
                return string.Empty;
            }
            else
            {   
                return row[0].field2.ToString();
            }
        }
        #endregion �}�X�^����ǎ擾���̑��}�X�^�[�p.
        /* 2015/07/08 �A�T�q�Ή� HLC K.Soga ADD End */

        #region �f�ڔŎ擾.
        /// <summary>
        /// �f�ڔŎ擾.
        /// </summary>
        /// <param name="sonota6"></param>
        /// <returns></returns>
        private string keisaiGet(string sonota6)
        {
            if (string.IsNullOrEmpty(sonota6)) 
            {
                return string.Empty; 
            }
            string keisaiban = string.Empty;
            switch (sonota6)
            {
                case KkhConstAsh.KeisaiKbn.KEIKBN_ZENBAN:
                    keisaiban = "�S�Œʂ�";
                    break;
                case KkhConstAsh.KeisaiKbn.KEIKBN_TOUGOU:
                    keisaiban = "������";
                    break;
                case KkhConstAsh.KeisaiKbn.KEIKBN_TOUGOUNUKI:
                    keisaiban = "��������";
                    break;
                case KkhConstAsh.KeisaiKbn.KEIKBN_YUKAN:
                    keisaiban = "�[���{������";
                    break;
                case KkhConstAsh.KeisaiKbn.KEIKBN_TIIKIKOUKOKU:
                    keisaiban = "�n��L��";
                    break;
            }

            return keisaiban;
        }
        #endregion �f�ڔŎ擾.

        #region �L�G�敪�擾.
        /// <summary>
        /// �L�G�敪�擾.
        /// </summary>
        /// <param name="sonota5"></param>
        /// <returns></returns>
        private string kizatuGet(string sonota5)
        {
            if (string.IsNullOrEmpty(sonota5)) 
            {
                return string.Empty; 
            }

            string kizatu = string.Empty;

            switch (sonota5)
            {
                case KKHSystemConst.KizatsuKbn.KIZKN_KIJISITA:
                    kizatu = "�L����";
                    break;
                case KKHSystemConst.KizatsuKbn.KIZKN_KIJINAKA:
                    kizatu = "�L����";
                    break;
                case KKHSystemConst.KizatsuKbn.KIZKN_TOSYUTU:
                    kizatu = "�ˁ@�o";
                    break;
                case KKHSystemConst.KizatsuKbn.KIZKN_DAIJI:
                    kizatu = "��@��";
                    break;
                case KKHSystemConst.KizatsuKbn.KIZKN_HASAKOMI:
                    kizatu = "���@��";
                    break;
                case KKHSystemConst.KizatsuKbn.KIZKN_TOKUSYU:
                    kizatu = "����G��";
                    break;
                case KKHSystemConst.KizatsuKbn.KIZKN_ANNAI:
                    kizatu = "�ā@��";
                    break;
            }

            return kizatu;
        }
        #endregion �L�G�敪�擾.

        #region �N�����擾.
        /// <summary>
        /// �N�����擾.
        /// </summary>
        /// <param name="oldYymmdd"></param>
        /// <returns></returns>
        private string YyMmDd(string oldYymmdd)
        {
            if (oldYymmdd.Length != 8) 
            {
                return string.Empty; 
            }

            string newYymmdd = oldYymmdd.Substring(0, 4) + "�N" + oldYymmdd.Substring(4, 2) + "��" + oldYymmdd.Substring(6, 2) + "��";

            return newYymmdd;
        }
        #endregion �N�����擾.

        #region ���i�l�[���擾.
        /// <summary>
        /// ���i�l�[���擾.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="srow"></param>
        /// <param name="sybt"></param>
        /// <returns></returns>
        private string mastNameGet(string key, RepDsAsh.SyohinRow[] srow, string sybt)
        {
            if (string.IsNullOrEmpty(key)) 
            {
                return string.Empty; 
            }

            foreach (RepDsAsh.SyohinRow row in srow)
            {
                if (row.field1.Equals(key) && row.sybt.Equals(sybt))
                {
                    if (row.field2.Length > 20)
                    {
                        return row.field2.Substring(0, 20);
                    }
                    else
                    {
                        return row.field2;
                    }
                }
            }

            return string.Empty;
        }
        #endregion ���i�l�[���擾.

        #region Excel�쐬�p�f�[�^�i�[.
        /// <summary>
        /// Excel�쐬�p�f�[�^�i�[.
        /// </summary>
        private void excelDataSet()
        {
            //�p�����[�^�[�̃Z�b�g.
            ReportAshProcessController.FindReportAshByMedium param = new ReportAshProcessController.FindReportAshByMedium();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = _yearMonth;

            //����.
            ReportAshProcessController processController = ReportAshProcessController.GetInstance();
            FindReportAshMediaByCondServiceResult result = processController.findReportMedia(param);

            if (result.HasError)
            {
                return;
            }

            RepDsAsh.RepAshMediaRow[] resultRow = (RepDsAsh.RepAshMediaRow[])result.dsAshDataSet.RepAshMedia.Select("", "");

            baikbn = cmbMedia.SelectedIndex;
            /* 2013/03/04 �A�T�q�Ή� JSE Miyanoue MOD Strat */
            //baitaiName = cmbMedia.SelectedItem.ToString();
            baitaiName = cmbMedia.Text.ToString();
            /* 2013/03/04 �A�T�q�Ή� JSE Miyanoue MOD End */
            /* 2015/06/29 �A�T�q�r�[���₢���킹�Ή� K.Fujisaki DEL Start */
            ////�u���O�L���v�̏ꍇ�́u���O�v�ɒu��������.
            //if (baitaiName.Equals(KkhConstAsh.BaitaiNm.OKUGAIKOUKOKU))
            //{
            //    baitaiName = KkhConstAsh.BaitaiNm.OKUGAIBAITAI;
            //}
            /* 2015/06/29 �A�T�q�r�[���₢���킹�Ή� K.Fujisaki DEL End */

            tableToDel.Clear();
            tableToDel.displayMedia.Merge(repds.displayMedia);
            tableToDel.allbaitai.Merge(repds.allbaitai);
            /* 2013/02/22 PR�}�̒ǉ��Ή� JSE Okazaki MOD Start */
            //if (cmbMedia.SelectedIndex == 18 || cmbMedia.SelectedIndex == 19)
            if (cmbMedia.SelectedIndex == cmbMedia.Items.Count - 2 || cmbMedia.SelectedIndex == cmbMedia.Items.Count - 1)
            /* 2013/02/22 PR�}�̒ǉ��Ή� JSE Okazaki MOD End */
            {
                //�������Ȃ�.
            }
            else
            {
                RepDsAsh.displayMediaRow[] Checkrow = (RepDsAsh.displayMediaRow[])repds.displayMedia.Select("", "");

                //�I�����ꂽ�}�̂̃f�[�^�����݂��邩�̃t���O.
                bool chflg = false;
                foreach (RepDsAsh.displayMediaRow chrow in Checkrow)
                {
                    //�X�v���b�h��[baitaiName]��null�ȊO��ΏۂƂ���.
                    if (!string.IsNullOrEmpty(chrow.baitaiName))
                    {
                        //[�o�͔}�̑I��]�Ŏw�肵���}�̂̏ꍇ�A�t���O��true�ɂ���.
                        if (chrow.baitaiName.Equals(baitaiName))
                        {
                            chflg = true; 
                        }
                    }
                }
                //�t���O��false�̏ꍇ.
                if (!chflg)
                {
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0038, null, "���[", MessageBoxButtons.OK);
                    return;
                }

                //�K�v�̂Ȃ��}�̃f�[�^�̍폜.
                RepDsAsh.displayMediaRow[] delrow1 = (RepDsAsh.displayMediaRow[])tableToDel.displayMedia.Select("baitaiName NOT IN ('" + baitaiName + "')");
                foreach (RepDsAsh.displayMediaRow row1 in delrow1)
                {
                    tableToDel.displayMedia.Rows.Remove(row1);
                }

                string MerelyBaitai = string.Empty;
                RepDsAsh.allbaitaiRow[] delrow2 = (RepDsAsh.allbaitaiRow[])tableToDel.allbaitai.Select("baitaicd NOT IN ('" + baitaiCdOfIndex(baikbn) + "')");
                foreach (RepDsAsh.allbaitaiRow row2 in delrow2)
                {
                    tableToDel.allbaitai.Rows.Remove(row2);
                }
                RepDsAsh.displayMediaRow[] delrow3 = (RepDsAsh.displayMediaRow[])tableToDel.displayMedia.Select("baitaiName is null");
                foreach (RepDsAsh.displayMediaRow row3 in delrow3)
                {
                    tableToDel.displayMedia.Rows.Remove(row3);
                }
            }
            /* 2015/02/23 �A�T�q�Ή� JSE Miyanoue ADD Start */
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            //���}�̃R�[�h����V�}�̖��́A�V�}�̃R�[�h���擾����.
            for (int i = 0; i < tableToDel.displayMedia.Rows.Count; i++)
            {
                String baitaiCd = tableToDel.displayMedia[i].baitaiCd;
                String baitaiNm = tableToDel.displayMedia[i].baitaiName;

                //�}�̃R�[�h��.
                int totalLen = baitaiCd.Length;
                //��1�����������}�̃R�[�h����.
                int len = totalLen - 1;

                //�}�̃R�[�h��ϊ�����.
                String bCd = baitaiCd.Substring(0, len);
                String bCd1keta = baitaiCd.Substring(len, 1);

                AshBaitaiUtility.BaitaiResult res = ashBaitaiUtility.ConvertOldCdToNewCd(bCd);

                String resultBaitaiCd = res.baitaiCd + bCd1keta;
                tableToDel.displayMedia[i].tokuisakiBaitaiCd = resultBaitaiCd;
                tableToDel.displayMedia[i].tokuisakiBaitaiName = res.baitaiNm;
            }
            /* 2015/02/23 �A�T�q�Ή� JSE Miyanoue ADD End */

            //�G�N�Z���o�̓t�@�C���̐ݒ�.
            excelFileSet();
        }
        #endregion Excel�쐬�p�f�[�^�i�[.

        #region �G�N�Z���o�͂̃t�@�C���ݒ�.
        /// <summary>
        /// �G�N�Z���o�͂̃t�@�C���ݒ�.
        /// </summary>
        private void excelFileSet()
        {
            //�t�@�C���ۑ��ꏊ�ݒ�N���X�̃C���X�^���X��.
            SaveFileDialog sfd = new SaveFileDialog();
            //���ݓ���.
            DateTime nowdate = DateTime.Now;

            //�����t�@�C����.
            if (cmbMedia.Text.Trim() != KkhConstAsh.BaitaiNm.ALL_BAITAI)
            {
                sfd.FileName = pStrRepFilNam + "_" + cmbMedia.Text.Trim() + nowdate.ToString("yyyyMMddHHmmss") + ".xlsx";
            }
            else
            {
                sfd.FileName = pStrRepFilNam + "_" + nowdate.ToString("yyyyMMddHHmmss") + ".xlsx";
            }
            //�����t�@�C���ۑ���.
            sfd.InitialDirectory = pStrRepAdrs;
            //�t�@�C����ނ̑I������ݒ�.
            sfd.Filter = "XLSX�t�@�C��(*.xlsx)|*.xlsx";
            //�����t�@�C����ނ̐ݒ�.
            //[���ׂẴt�@�C��]��ݒ�.
            sfd.FilterIndex = 0;
            //�^�C�g���̐ݒ�.
            sfd.Title = "�ۑ���̃t�@�C����ݒ肵�ĉ������B";
            //�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���.
            sfd.RestoreDirectory = true;

            //�_�C�A���O��\�����AOk�{�^�����������ꂽ�ꍇ.
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //�o�͐�ɓ�����Excel�t�@�C�����J���Ă��邩�`�F�b�N.
                try
                {
                    //�����Ńt�@�C�����폜����.
                    File.Delete(sfd.FileName);
                }
                catch (IOException)
                {
                    //�o�͐�ɓ�����Excel�t�@�C�����J���Ă��܂��B���Ă���ēx�o�͂��Ă�������.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "���[", MessageBoxButtons.OK);
                    return;
                }

                //�o�͎��s.
                this.ExcelOut(sfd.FileName);
            }
        }
        #endregion �G�N�Z���o�͂̃t�@�C���ݒ�.

        #region �G�N�Z���o��.
        /// <summary>
        /// �G�N�Z���o��.
        /// </summary>
        /// <param name="filenm"></param>
        private void ExcelOut(string filenm)
        {
            /* 2015/03/17 �A�T�q�Ή� JSE Miyanoue ADD Start */
            string macrofile = "";
            string tempfile = "";

            //��Ɨp�t�H���_�p�X.
            string workFolderPath = pStrRepTempAdrs;
            if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
            {
                macrofile = workFolderPath + REP_MACRO_FILENAME;
                tempfile = workFolderPath + REP_TEMPLATE_FILENAME;
            }
            else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
            {
                macrofile = workFolderPath + REP_MACRO_FILENAME_BEER;
                tempfile = workFolderPath + REP_TEMPLATE_FILENAME_BEER;
            }
            /* 2015/03/17 �A�T�q�Ή� JSE Miyanoue ADD End */

            //�e�[�u���ǉ��p�f�[�^Row.
            DataRow dtRow;

            try
            {
                /* 2015/03/17 �A�T�q�Ή� JSE Miyanoue MOD Start */
                // Excel�J�n����.
                // ���\�[�X����Excel�t�@�C�����쐬(�e���v���[�g�ƃ}�N��).
                //File.WriteAllBytes(macrofile, Isid.KKH.Ash.Properties.Resources.Ash_Medium);
                //File.WriteAllBytes(tempfile, Isid.KKH.Ash.Properties.Resources.Ash_Medium_Template);

                //�����̏ꍇ.
                if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                {
                    File.WriteAllBytes(macrofile, Isid.KKH.Ash.Properties.Resources.Ash_Medium);
                    File.WriteAllBytes(tempfile, Isid.KKH.Ash.Properties.Resources.Ash_Medium_Template);
                }
                //�r�[���̏ꍇ.
                else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                {
                    File.WriteAllBytes(macrofile, Isid.KKH.Ash.Properties.Resources.AshBeer_Medium);
                    File.WriteAllBytes(tempfile, Isid.KKH.Ash.Properties.Resources.AshBeer_Medium_Template);
                }
                /* 2015/03/17 �A�T�q�Ή� JSE Miyanoue MOD End */

                if (System.IO.File.Exists(tempfile) == false) 
                {
                    throw new Exception("�e���v���[�gExcel�t�@�C��������܂���B"); 
                }

                if (System.IO.File.Exists(macrofile) == false) 
                {
                    throw new Exception("�}�N��Excel�t�@�C��������܂���B"); 
                }

                //�f�[�^�Z�b�gXML�o��.
                tableToDel.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));

                /*
                 * �p�����[�^XML�쐬�A�o��.
                 */
                //�ϐ��̐錾.
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                //�f�[�^�Z�b�g�Ƀe�[�u����ǉ�����.
                //PRODUCTS�Ƃ����e�[�u�����쐬����. 
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("USERNAME", Type.GetType("System.String"));
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                dtTable.Columns.Add("SYOHIZEI", Type.GetType("System.String"));
                dtTable.Columns.Add("BAITAINAME", Type.GetType("System.String"));
                dtTable.Columns.Add("HEADERNAME", Type.GetType("System.String"));
                dtTable.Columns.Add("BAITAICOUNT", Type.GetType("System.String"));

                //�e�[�u���Ƀf�[�^��ǉ�����.
                dtRow = dtTable.NewRow();

                dtRow["SAVEDIR"] = filenm;
                dtRow["SYOHIZEI"] = _dbSyohizei.ToString();
                dtRow["USERNAME"] = tslName.Text;
                dtRow["BAITAINAME"] = baitaiName;

                string headerName = string.Empty;
                string Code = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
                if (Code.Equals(KKHSystemConst.TksKgyCode.TksKgyCode_Ash))
                {
                    headerName = KKHSystemConst.TksKgyName.TksKgyName_Ash;
                }
                else if (Code.Equals(KKHSystemConst.TksKgyCode.TksKgyCode_AshBear))
                {
                    headerName = KKHSystemConst.TksKgyName.TksKgyName_AshBear;
                }
                if (string.IsNullOrEmpty(headerName))
                {
                    throw new Exception();
                }
                dtRow["HEADERNAME"] = headerName;

                //�Y���}�̃J�E���g�擾.
                string baitaicount = "";
                if (_dicBaitai.ContainsKey(baitaiCdOfIndex(baikbn)))
                {
                    baitaicount = _dicBaitai[baitaiCdOfIndex(baikbn)].ToString();
                }
                dtRow["BAITAICOUNT"] = baitaicount;

                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                /* 2015/03/17 �A�T�q�Ή� JSE Miyanoue ADD Start */
                /*
                 * �G�N�Z���N��.
                 */
                //�����̏ꍇ.
                if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_INRYOU)
                {
                    System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME);

                    //�폜�p�ɕێ�(�߂�{�^���������ɍ폜�����).
                    _strmacrodel = workFolderPath + REP_MACRO_FILENAME;
                }
                //�r�[���̏ꍇ.
                else if (_naviParam.strTksKgyCd == TOKUISAKI_CODE_BEER)
                {
                    System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME_BEER);

                    //�폜�p�ɕێ�(�߂�{�^���������ɍ폜�����).
                    _strmacrodel = workFolderPath + REP_MACRO_FILENAME_BEER;
                }
                /* 2015/03/17 �A�T�q�Ή� JSE Miyanoue ADD End */

                // �I�y���[�V�������O�̏o��.
                KKHLogUtilityAsh.WriteOperationLogToDB(_naviParam, KKHSystemConst.ApplicationID.APLID_MEDIUM, KKHLogUtilityAsh.KINO_ID_OPERATION_LOG_Medium, KKHLogUtilityAsh.DESC_OPERATION_LOG_Medium);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion �G�N�Z���o��.

        #region �C���f�b�N�X����}�̃R�[�h�擾.
        /// <summary>
        /// �C���f�b�N�X����}�̃R�[�h�擾.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private string baitaiCdOfIndex(int index)
        {
            switch (index)
            {
                case 0://�e���r�^�C��.
                    return KkhConstAsh.BaitaiCd.TV_TIME;
                case 1://���W�I�^�C��.
                    return KkhConstAsh.BaitaiCd.RADIO_TIME;
                case 2://���W�I�X�|�b�g.
                    return KkhConstAsh.BaitaiCd.RADIO_SPOT;
                case 3://�e���r�X�|�b�g.
                    return KkhConstAsh.BaitaiCd.TV_SPOT;
                case 4://�V��.
                    return KkhConstAsh.BaitaiCd.SHINBUN;
                case 5://�G��.
                    return KkhConstAsh.BaitaiCd.ZASHI;
                case 6://���.
                    return KkhConstAsh.BaitaiCd.KOUTSU;
                case 7://����.
                    return KkhConstAsh.BaitaiCd.SEISAKU;
                /* 2013/02/22 PR�}�̒ǉ��Ή� JSE Okazaki MOD Start */
                //case 8://���̑�.
                //    return KkhConstAsh.BaitaiCd.SONOTA;
                //case 9://ƭ���ި�.
                //    return KkhConstAsh.BaitaiCd.NEW_MEDIA;
                //case 10://����ȯ�.
                //    return KkhConstAsh.BaitaiCd.INTERNET;
                //case 11://BS.
                //    return KkhConstAsh.BaitaiCd.BS;
                //case 12://CS.
                //    return KkhConstAsh.BaitaiCd.CS;
                //case 13://���O�L��.
                //    return KkhConstAsh.BaitaiCd.OKUGAI;
                //case 14://�����.
                //    return KkhConstAsh.BaitaiCd.EVENT;
                //case 15://����.
                //    return KkhConstAsh.BaitaiCd.TYOUSA;
                //case 16://���f�B�A�t�B�[.
                //    return KkhConstAsh.BaitaiCd.MEDIA_FEE;
                //case 17://�u�����h�Ǘ��t�B�[.
                //    return KkhConstAsh.BaitaiCd.BRAND_FEE;
                case 8://PR.
                    return KkhConstAsh.BaitaiCd.PR;
                case 9://���̑�.
                    return KkhConstAsh.BaitaiCd.SONOTA;
                case 10://ƭ���ި�.
                    return KkhConstAsh.BaitaiCd.NEW_MEDIA;
                case 11://����ȯ�.
                    return KkhConstAsh.BaitaiCd.INTERNET;
                case 12://BS.
                    return KkhConstAsh.BaitaiCd.BS;
                case 13://CS.
                    return KkhConstAsh.BaitaiCd.CS;
                case 14://���O�L��.
                    return KkhConstAsh.BaitaiCd.OKUGAI;
                case 15://�����.
                    return KkhConstAsh.BaitaiCd.EVENT;
                case 16://����.
                    return KkhConstAsh.BaitaiCd.TYOUSA;
                case 17://���f�B�A�t�B�[.
                    return KkhConstAsh.BaitaiCd.MEDIA_FEE;
                case 18://�u�����h�Ǘ��t�B�[.
                    return KkhConstAsh.BaitaiCd.BRAND_FEE;
                /* 2013/02/22 PR�}�̒ǉ��Ή� JSE Okazaki MOD End */
            }

            return string.Empty;
        }
        #endregion �C���f�b�N�X����}�̃R�[�h�擾.

        /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga DEL Start */
        #region �����_���w��̈ʒu�Ŏl�̌ܓ�����.
        ///// <summary>
        ///// �����_���w��̈ʒu�Ŏl�̌ܓ�����.
        ///// </summary>
        ///// <param name="dValue">�l�̌ܓ�����l</param>
        ///// <param name="iDigits">�����_�ȉ��̌���</param>
        ///// <returns></returns>
        //public static double ToHalfAdjust(double dValue, int iDigits)
        //{
        //    double dv = dValue % 1.0;
        //    if (dv.ToString().Length <= 1) { return dValue; }

        //    double dCoef = System.Math.Pow(10, iDigits);

        //    return dValue > 0 ? System.Math.Floor((dValue * dCoef) + 0.5) / dCoef :
        //                        System.Math.Ceiling((dValue * dCoef) - 0.5) / dCoef;
        //}
        #endregion �����_���w��̈ʒu�Ŏl�̌ܓ�����.
        /* 2016/11/22 �A�T�q����őΉ� HLC K.Soga DEL End */

        #region ���Z����.
        /// <summary>
        /// ���Z����.
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        private string clcRyokin(string val1, string val2)
        {
            if (string.IsNullOrEmpty(val1))
            {
                val1 = "0";
            }
            if (string.IsNullOrEmpty(val2))
            {
                val2 = "0";
            }
            double dbl1 = double.Parse(val1);
            double dbl2 = double.Parse(val2);
            double dbl3 = dbl1 + dbl2;

            return dbl3.ToString();
        }
        #endregion ���Z����.

        #region �J���}�ݒ�.
        /// <summary>
        /// �J���}�ݒ�.
        /// </summary>
        private void SetComma(RepDsAsh dsash)
        {
            for (int i = 0; i < dsash.displayMedia.Rows.Count; i++)
            {
                double kanma = 0;
                //���z.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].kingak))
                {
                    kanma = double.Parse(dsash.displayMedia[i].kingak);
                    dsash.displayMedia[i].kingak = kanma.ToString("#,0");
                }
                //�l���z.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].nebiki))
                {
                    kanma = double.Parse(dsash.displayMedia[i].nebiki);
                    dsash.displayMedia[i].nebiki = kanma.ToString("#,0");
                }
                //�����.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].syouhiZei))
                {
                    kanma = double.Parse(dsash.displayMedia[i].syouhiZei);
                    dsash.displayMedia[i].syouhiZei = kanma.ToString("#,0");
                }
                //�f�ڗ�.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].keisaiRyo))
                {
                    kanma = double.Parse(dsash.displayMedia[i].keisaiRyo);
                    dsash.displayMedia[i].keisaiRyo = kanma.ToString("#,0");
                }
                //�w�藿.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].siteiRyo))
                {
                    kanma = double.Parse(dsash.displayMedia[i].siteiRyo);
                    dsash.displayMedia[i].siteiRyo = kanma.ToString("#,0");
                }
                //�F����.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].sikisatuRyo))
                {
                    kanma = double.Parse(dsash.displayMedia[i].sikisatuRyo);
                    dsash.displayMedia[i].sikisatuRyo = kanma.ToString("#,0");
                }
                //�����.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].seisakuhi))
                {
                    kanma = double.Parse(dsash.displayMedia[i].seisakuhi);
                    dsash.displayMedia[i].seisakuhi = kanma.ToString("#,0");
                }
                //�f�ڗ��l����.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].keisaiNebiAfter))
                {
                    kanma = double.Parse(dsash.displayMedia[i].keisaiNebiAfter);
                    dsash.displayMedia[i].keisaiNebiAfter = kanma.ToString("#,0");
                }
                //�w�藿�l����.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].siteiNebiAfter))
                {
                    kanma = double.Parse(dsash.displayMedia[i].siteiNebiAfter);
                    dsash.displayMedia[i].siteiNebiAfter = kanma.ToString("#,0");
                }
                //�F�����l����.
                if (!string.IsNullOrEmpty(dsash.displayMedia[i].sikisatuNebiAfter))
                {
                    kanma = double.Parse(dsash.displayMedia[i].sikisatuNebiAfter);
                    dsash.displayMedia[i].sikisatuNebiAfter = kanma.ToString("#,0");
                }
            }
        }
        #endregion �J���}�ݒ�.
        #endregion  ���\�b�h.
    }
}