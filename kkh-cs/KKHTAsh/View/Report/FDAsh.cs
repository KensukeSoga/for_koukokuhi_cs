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
    /// �����f�[�^�쐬���.
    /// </summary>
    public partial class FDAsh : Isid.KKH.Common.KKHView.Common.Form.KKHForm
    {
        #region �萔.
        #region �X�v���b�h���ڔԍ�.
        /// <summary>
        /// �X�v���b�h���ڔԍ�:�ԍ�.
        /// </summary>
        private const int cKNo = 0;
        /// <summary>
        /// �X�v���b�h���ڔԍ�:�������ԍ�.
        /// </summary>
        private const int cKSeikyuNo = 1;
        /// <summary>
        /// �X�v���b�h���ڔԍ�:�}�̃R�[�h(�V�X�e���p).
        /// </summary>
        private const int cKBaitaiCd = 2;
        /* 2015/02/24 �\���p�}�̃R�[�h��ǉ� A.Hisada ADD Start */
        /// <summary>
        /// �X�v���b�h���ڔԍ�:�}�̃R�[�h.
        /// </summary>
        private const int cKNewBaitaiCd = 3;
        /* 2015/02/24 �\���p�}�̃R�[�h��ǉ� A.Hisada ADD End */
        /// <summary>
        /// �X�v���b�h���ڔԍ�:�������z.
        /// </summary>
        private const int cKSeikyuKin = 4;
        /// <summary>
        /// �X�v���b�h���ڔԍ�:�ǃR�[�h.
        /// </summary>
        private const int cKKyokuCd = 5;
        /// <summary>
        /// �X�v���b�h���ڔԍ�:�i��R�[�h.
        /// </summary>
        private const int cKHinshuCd = 6;
        /// <summary>
        /// �X�v���b�h���ڔԍ�:�㗝�X�R�[�h.
        /// </summary>
        private const int cKDairitenCd = 7;
        /// <summary>
        /// �X�v���b�h���ڔԍ�:�ԑg�R�[�h.
        /// </summary>
        private const int cKBangumiCd = 8;
        /// <summary>
        /// �X�v���b�h���ڔԍ�:����.
        /// </summary>
        private const int cKKenmei = 9;
        /// <summary>
        /// �X�v���b�h���ڔԍ�:������.
        /// </summary>
        private const int cKSeikyuBi = 10;
        #endregion �X�v���b�h���ڔԍ�.

        #region ���[.
        /* 2015/02/17 �A�T�q�Ή�(�A�b�v���[�h�t�@�C���V�X�e����) Fukuda ADD Start */
        /// <summary>
        /// Excel(���[�o�̓}�N������)�t�@�C����.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME = "Ash_Fd.xlsm";
        /// <summary>
        /// Excel(���[�o�̓}�N���e���v���[�g)�t�@�C����.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "Ash_Fd_Template.xls";
        /// <summary>
        /// XML�t�@�C����1.
        /// </summary>
        private static readonly string REP_XML_FILENAME = "Ash_Fd_Data.xml";
        /// <summary>
        /// XML�t�@�C����2.
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "Ash_Fd_Prop.xml";
        /* 2015/02/17 �A�T�q�Ή�(�A�b�v���[�h�t�@�C���V�X�e����) Fukuda ADD End */
        #endregion ���[.
        #endregion �萔.

        #region �����o�ϐ�.
        /// <summary>
        /// �i�r�p�����[�^�[.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// �ۑ���.
        /// </summary>
        private string pStrRepAdrs = "";
        /// <summary>
        /// ���[���p.
        /// </summary>
        private string pStrRepFilNam = "";
        /// <summary>
        /// ����ŗ�.
        /// </summary>
        private double pSyohizeiritu;
        /* 2015/02/17 �A�T�q�Ή�(�A�b�v���[�h�t�@�C���V�X�e����) Fukuda ADD Start */
        /// <summary>
        /// �ۑ���(�A�b�v���[�h�o��).
        /// </summary>
        private string pStrRepAdrs2 = "";
        /// <summary>
        /// ���[���p(�A�b�v���[�h�o��).
        /// </summary>
        private string pStrRepFilNam2 = "";
        /// <summary>
        /// �ۑ���p(�e���v���[�g)�ϐ�.
        /// </summary>
        private string pStrRepTempAdrs = "";
        /// <summary>
        /// �R�s�[�}�N���폜�pstring
        /// </summary>
        private string _strmacrodel;
        /* 2015/02/17 �A�T�q�Ή�(�A�b�v���[�h�t�@�C���V�X�e����) Fukuda ADD End */
        /* 2015/02/24 A.Hisada ADD Start */
        /// <summary>
        /// �}�̃R�[�h-���Ӑ�}�̃R�[�h�ϊ��N���X.
        /// </summary>      
        private AshBaitaiUtility baitaiHenkanUtil;
        /* 2015/02/24 A.Hisada ADD End */
        #endregion �����o�ϐ�.

        #region �R���X�g���N�^.
        /// <summary>
        /// �R���X�g���N�^.
        /// </summary>
        public FDAsh()
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
        private void FDAsh_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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
        private void FDAsh_Shown(object sender, EventArgs e)
        {
            //���[�f�B���O�\��.
            base.ShowLoadingDialog();

            //�ҏW.
            EditControl();

            //�����.
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
                //����ŗ��Z�b�g.
                pSyohizeiritu = 1 + KKHUtility.DouParse(comResult.CommonDataSet.SystemCommon[0].field4.ToString());

                //�e���v���[�g�A�h���X.
                pStrRepTempAdrs = comResult.CommonDataSet.SystemCommon[0].field2.ToString();
            }
            else
            {
                pSyohizeiritu = 1;
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
                                                                                            "004");
            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //�ۑ���Z�b�g.
                pStrRepAdrs = comResult2.CommonDataSet.SystemCommon[0].field2.ToString();

                //���̃Z�b�g.
                pStrRepFilNam = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
            }

            //�ۑ���� + ���[��.
            FindCommonByCondServiceResult comResult3 = commonProcessController2.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                                            "005");
            if (comResult3.CommonDataSet.SystemCommon.Count != 0)
            {
                //�ۑ���Z�b�g.
                pStrRepAdrs2 = comResult3.CommonDataSet.SystemCommon[0].field2.ToString();

                //���̃Z�b�g.
                pStrRepFilNam2 = comResult3.CommonDataSet.SystemCommon[0].field3.ToString();
            }

            /* 2015/02/19 ���Ӑ�}�̃R�[�h�ւ̕ϊ������Ή� Fukuda ADD Start */
            ////�}�̃R�[�h-���Ӑ�}�̃R�[�h�ϊ��N���X�̃C���X�^���X����.
            baitaiHenkanUtil = new AshBaitaiUtility(_naviParam.strEsqId
                                                                      , _naviParam.strEgcd
                                                                      , _naviParam.strTksKgyCd
                                                                      , _naviParam.strTksBmnSeqNo
                                                                      , _naviParam.strTksTntSeqNo);
            /* 2015/02/19 ���Ӑ�}�̃R�[�h�ւ̕ϊ������Ή� Fukuda ADD End */

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

                //�}�N���t�@�C���̍폜(VBA���ł͍폜�ł��Ȃ���)
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

        #region �\���{�^���N���b�N.
        /// <summary>
        /// �\���{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            //���[�f�B���O�\���J�n.
            base.ShowLoadingDialog();

            //�\��.
            DisplayView();

            //�R���g���[���𖢑I����Ԃɂ���.
            this.ActiveControl = null;

            //���[�f�B���O�\���I��.
            base.CloseLoadingDialog();
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
            FileOut(medMain_Sheet1);
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

        #region �N���R���{�{�b�N�X�A�N�e�B�u����.
        /// <summary>
        /// �N���R���{�{�b�N�X�A�N�e�B�u����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtYm_Enter(object sender, EventArgs e)
        {
            btnXls.Enabled = false;
            btnUpload.Enabled = false;
        }
        #endregion �N���R���{�{�b�N�X�A�N�e�B�u����.

        /* 2015/02/17 �A�T�q�Ή�(�A�b�v���[�h�t�@�C���V�X�e����) JSE K.Fukuda ADD Start */
        #region �A�b�v���[�h�o�̓{�^���N���b�N����.
        /// <summary>
        /// �A�b�v���[�h�o�̓{�^���N���b�N����.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            //Excel�o�͂̃t�@�C���ݒ�.
            excelFileSet();
            this.ActiveControl = null;
        }
        #endregion �A�b�v���[�h�o�̓{�^���N���b�N����.
        /* 2015/02/17 �A�T�q�Ή�(�A�b�v���[�h�t�@�C���V�X�e����) JSE K.Fukuda ADD End */
        #endregion �C�x���g.

        #region ���\�b�h.
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
            
            //�}�̃R�[�h�p.
            string strBaiCd = string.Empty;      
            //�ԍ�.
            int intDispNo = 0;
            //���z(����ł���).
            double dblKingakuZeiAri = 0;
            //���z(����łȂ�).
            double dblKingakuZeiNashi = 0;
            //��ېŋ��z.
            double dblKingakuHikazei = 0;
            //����ŗ�.
            double dblShohizeiRitu = 0;
            /* 2016/11/24 �A�T�q����őΉ� HLC H.Soga DEL Start */
            ////���z.
            //double dblSagaku = 0;
            ////�[�������p���z.
            //double choseikin = 0;
            /* 2016/11/24 �A�T�q����őΉ� HLC H.Soga DEL End */
            //�����v.
            double dblSogoukei = 0;
            /* 2013/12/05 ����őΉ� HLC H.Watabe Add Start */
            List<double> listTaxRate = new List<double>();
            List<double> listAmount = new List<double>();
            /* 2013/12/05 ����őΉ� HLC H.Watabe Add End */

            /*
             * �p�����[�^�[�̃Z�b�g.
             */
            ReportAshProcessController.FindReportAshByMedium param = new ReportAshProcessController.FindReportAshByMedium();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = txtYm.Value;

            /*
             * ����.
             */
            ReportAshProcessController processController = ReportAshProcessController.GetInstance();
            FindReportAshMediaByCondServiceResult result = processController.findFD(param);
            //�G���[�̏ꍇ.
            if (result.HasError)
            {
                //���[�f�B���O�\���I��.
                base.CloseLoadingDialog();
                medMain_Sheet1.Rows.Count = 0;
                return;
            }
            //�����������ʂ�0���̏ꍇ.
            RepDsAsh.FDAshRow[] resultRow = (RepDsAsh.FDAshRow[])result.dsAshDataSet.FDAsh.Select("", "");
            if (resultRow.Length == 0)
            {
                //���[�f�B���O�\���I��.
                base.CloseLoadingDialog();
                medMain_Sheet1.Rows.Count = 0;
                lblKensu.Text = resultRow.Length.ToString() + "��";
                btnXls.Enabled = false;
                btnUpload.Enabled = false;
                MessageUtility.ShowMessageBox(MessageCode.HB_W0031, null, "�����f�[�^�쐬", MessageBoxButtons.OK);
                return;
            }

            /*
             * �f�[�^�Z�b�g�̃C���X�^���X����.
             */
            RepDsAsh dsash = new RepDsAsh();
            RepDsAsh.displayFDRow addSyokeiout = dsash.displayFD.NewdisplayFDRow();
            addSyokeiout = syokirowSet(addSyokeiout);
            int count = 0;

            //�����f�[�^���������[�v����.
            foreach (RepDsAsh.FDAshRow row in resultRow)
            {
                //�\���p�f�[�^Row
                RepDsAsh.displayFDRow addrow = dsash.displayFD.NewdisplayFDRow();
                //�\���p(���v�p)�f�[�^Row
                RepDsAsh.displayFDRow addSyokei = dsash.displayFD.NewdisplayFDRow();

                //�\���p�f�[�^Row������.
                addrow = syokirowSet(addrow);

                //�}�̃R�[�h�ێ�.
                if (count == 0)
                {
                    strBaiCd = row.baitaicd;
                }

                //���z��0�łȂ���Δԍ��J�E���g�A�b�v.
                if (!row.seikyukin.Equals("0"))
                {
                    intDispNo++;
                }

                //�O��̔}�̃R�[�h�ƈႤ�ꍇ�͏��v���o��.
                if (strBaiCd != row.baitaicd.Trim())
                {
                    //�\���p�f�[�^Row������.
                    addrow = syokirowSet(addrow);
                    //�\���p(�}�̍��v�p)�f�[�^Row������.
                    addSyokei = syokirowSet(addSyokei);

                    /* 2013/12/05 ����őΉ� HLC H.Watabe MOD Start */
                    //���z�v�Z.
                    //dblSagaku = ((dblKingakuZeiNashi - dblKingakuHikazei) * 1.05) + dblKingakuHikazei - dblKingakuZeiAri;
                    //dblSagaku = ToHalfAdjust(((dblKingakuZeiNashi - dblKingakuHikazei) * pSyohizeiritu) + dblKingakuHikazei, 0) - dblKingakuZeiAri;
                    //�}�̂̍ŏI�f�[�^�Œ[������.
                    //choseikin = KKHUtility.DouParse(dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin) + dblSagaku;
                    //dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin = choseikin.ToString();

                    //�}�̍��v.
                    double baitaigokei = 0;

                    /* 2016/11/24 �A�T�q����őΉ� HLC H.Soga MOD Start */
                    //for (int index = 0; index < listTaxRate.Count; index++)
                    //{
                    //    // 2015/06/08 K.F Cng Start �V�L����ׁ@�A�T�q����őΉ�.
                    //    //baitaigokei += Math.Truncate((1 + (listTaxRate[index] * 0.01)) * listAmount[index]);
                    //    baitaigokei += Math.Round((1 + (listTaxRate[index] * 0.01)) * listAmount[index]);
                    //    // 2015/06/08 K.F Cng End �V�L����ׁ@�A�T�q����őΉ�.
                    //}
                    //dblSagaku = double.Parse(dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin) + baitaigokei - dblKingakuZeiAri;
                    //if (listAmount.Count == 1 && listTaxRate[0] == 0)
                    //{
                    //    dblSagaku = double.Parse(dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin);
                    //    baitaigokei = dblSagaku;
                    //}
                    //dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin = dblSagaku.ToString();

                    //�e�}�̖̂��׌��������[�v����.
                    for (int index = 0; index < listAmount.Count; index++)
                    {
                        //�e�}�̂̍��v���擾.
                        baitaigokei += listAmount[index];
                    }
                    /* 2016/11/24 �A�T�q����őΉ� HLC H.Soga MOD End */

                    //�}�̍��v.
                    addSyokei.newbaitaicd = KKHSystemConst.KoteiMongon.BAITAI_GOUKEI;

                    //�}�̍��v���z.
                    //double baitaigokei = dblKingakuZeiAri + dblSagaku;
                    addSyokei.seikyukin = baitaigokei.ToString();
                    /* 2013/12/05 ����őΉ� HLC H.Watabe MOD End */

                    //�ǉ�.
                    dsash.displayFD.AdddisplayFDRow(addSyokei);

                    //�����v�v�Z.
                    dblSogoukei = dblSogoukei + baitaigokei;

                    //�}�̕ύX�̂��߁A�ϐ�������.
                    dblKingakuZeiAri = 0;
                    dblKingakuZeiNashi = 0;
                    dblKingakuHikazei = 0;

                    /* 2013/12/05 ����őΉ� HLC H.Watabe ADD Start */
                    listAmount.Clear();
                    listTaxRate.Clear();
                    /* 2013/12/05 ����őΉ� HLC H.Watabe ADD End */
                }

                //�}�̍��v���z�p�ɋ��z���Z�b�g.
                dblKingakuZeiAri = dblKingakuZeiAri + KKHUtility.DouParse(row.seikyukinzeiari);
                dblKingakuZeiNashi = dblKingakuZeiNashi + KKHUtility.DouParse(row.seikyukinzeinashi);
                
                //��ېŋ��z.
                if(row.shohizeiritu.Equals("0"))
                {
                    dblKingakuHikazei = dblKingakuHikazei + KKHUtility.DouParse(row.seikyukin); 
                }

                //����ŗ�.
                if (!row.shohizeiritu.Equals("0"))
                {
                    dblShohizeiRitu = 1 + (KKHUtility.DouParse(row.shohizeiritu) * 0.01);
                }
                else
                {
                    dblShohizeiRitu = 1;
                }

                /* 2013/12/05 ����őΉ� HLC H.Watabe ADD Start */
                if (listTaxRate.Count != 0)
                {
                    bool taxGetFlg = false;
                    for (int index = 0; index < listTaxRate.Count; index++)
                    {
                        if (listTaxRate[index] == double.Parse(row.shohizeiritu.Trim()))
                        {
                            /* 2016/11/24 �A�T�q����őΉ� HLC H.Soga MOD Start */
                            //listAmount[index] += double.Parse(row.seikyukinzeinashi.Trim());
                            //�}�̍��v.
                            listAmount[index] += double.Parse(row.seikyukinzeiari);
                            /* 2016/11/24 �A�T�q����őΉ� HLC H.Soga MOD End */
                            taxGetFlg = true;
                            break;
                        }
                    }
                    if (!taxGetFlg)
                    {
                        listTaxRate.Add(double.Parse(row.shohizeiritu.Trim()));
                        /* 2016/11/24 �A�T�q����őΉ� HLC H.Soga MOD Start */
                        //listAmount.Add(double.Parse(row.seikyukinzeinashi.Trim()));
                        //�}�̍��v.
                        listAmount.Add(double.Parse(row.seikyukinzeiari));
                        /* 2016/11/24 �A�T�q����őΉ� HLC H.Soga MOD End */
                    }
                }
                else
                {
                    listTaxRate.Add(double.Parse(row.shohizeiritu.Trim()));
                    /* 2016/11/24 �A�T�q����őΉ� HLC H.Soga MOD Start */
                    //listAmount.Add(double.Parse(row.seikyukinzeinashi.Trim()));
                    //�}�̍��v.
                    listAmount.Add(double.Parse(row.seikyukinzeiari));
                    /* 2016/11/24 �A�T�q����őΉ� HLC H.Soga MOD End */
                }
                /* 2013/12/05 ����őΉ� HLC H.Watabe ADD End */

                //�f�[�^�ԍ�.
                addrow.no = intDispNo.ToString();

                //�������ԍ�.
                addrow.seikyuno = row.seikyuno;

                /* 2014/09/11 �A�T�q�r�[�����W�I�X�|�b�g�Ή� HLC fujimoto MOD start */
                //�}�̃R�[�h.
                //addrow.baitaicd = row.baitaicd;
                //�}�̃R�[�h�����W�I�X�|�b�g�̏ꍇ.
                if (row.baitaicd.ToString().Equals(KkhConstAsh.BaitaiCd.RADIO_SPOT))
                {
                    //���Ӑ悪�A�T�q�r�[���̏ꍇ.
                    if (KKHSystemConst.TksKgyCode.TksKgyCode_AshBear.Equals(_naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo))
                    {
                        addrow.baitaicd = KkhConstAsh.BaitaiCd.RADIO_TIME;
                    }
                    else
                    {
                        addrow.baitaicd = row.baitaicd;
                    }
                }
                else
                {
                    addrow.baitaicd = row.baitaicd;
                }
                /* 2014/09/11 �A�T�q�r�[�����W�I�X�|�b�g�Ή� HLC fujimoto MOD end */

                ///* 2015/02/19 ���Ӑ�}�̃R�[�h�ւ̕ϊ������Ή� fukuda ADD start */
                AshBaitaiUtility.BaitaiResult cnvBaitaiRes = baitaiHenkanUtil.ConvertOldCdToNewCd(addrow.baitaicd);
                addrow.newbaitaicd = cnvBaitaiRes.baitaiCd;
                ///* 2015/02/19 ���Ӑ�}�̃R�[�h�ւ̕ϊ������Ή� fukuda ADD end */

                //�������z.
                addrow.seikyukin = row.seikyukinzeiari;

                //�ǃR�[�h.
                addrow.kyokucd = row.kyokucd;

                //�i��R�[�h.
                addrow.hinsyucd = row.hinsyucd;

                //�㗝�X�R�[�h.
                addrow.dairitencd = row.dairitencd;

                //�ԑg�R�[�h.
                addrow.bangumicd = row.bangumicd;

                //����.
                addrow.kenmei = row.kenmei;

                //������.
                //�\�����̍ŏI��.
                string lastday = DateTime.DaysInMonth(KKHUtility.IntParse(txtYm.Year), KKHUtility.IntParse(txtYm.Month)).ToString();
                if (lastday.Equals(String.Empty))
                {
                    addrow.seikyubi = String.Empty;
                }
                else
                {
                    addrow.seikyubi = txtYm.Year + "/" + txtYm.Month + "/" + lastday;   
                }

                //�ǉ�.
                dsash.displayFD.AdddisplayFDRow(addrow);

                //���p�ɔ}�̃R�[�h�Z�b�g.
                strBaiCd = row.baitaicd.Trim();

                count++;
            }

            //�\���p(�}�̍��v�p)�f�[�^Row������.
            addSyokeiout = syokirowSet(addSyokeiout);

            /* 2013/12/05 ����őΉ� HLC H.Watabe MOD Start */
            //���z�v�Z.
            //dblSagaku = ((dblKingakuZeiNashi - dblKingakuHikazei) * 1.05) + dblKingakuHikazei - dblKingakuZeiAri;
            //dblSagaku = ToHalfAdjust(((dblKingakuZeiNashi - dblKingakuHikazei) * pSyohizeiritu) + dblKingakuHikazei, 0) - dblKingakuZeiAri;

            /* 2016/11/24 �A�T�q����őΉ� HLC H.Soga MOD Start */
            ////�}�̂̍ŏI�f�[�^�Œ[������.            
            //double baitaigokeiout = 0;
            //for (int index = 0; index < listTaxRate.Count; index++)
            //{
            //    // 2015/06/08 K.F Cng Start �V�L����ׁ@�A�T�q����őΉ�.
            //    //baitaigokeiout += Math.Truncate((1 + (listTaxRate[index] * 0.01)) * listAmount[index]);
            //    baitaigokeiout += Math.Round((1 + (listTaxRate[index] * 0.01)) * listAmount[index]);
            //    // 2015/06/08 K.F Cng End �V�L����ׁ@�A�T�q����őΉ�.
            //}
            //dblSagaku = double.Parse(dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin) + baitaigokeiout - dblKingakuZeiAri;
            //dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin = dblSagaku.ToString();

            //�}�̍��v.         
            double baitaigokeiout = 0;

            //�e�}�̖̂��׌��������[�v����.
            for (int index = 0; index < listAmount.Count; index++)
            {
                //�e�}�̂̍��v���擾.
                baitaigokeiout += listAmount[index];
            }
            /* 2016/11/24 �A�T�q����őΉ� HLC H.Soga MOD End */

            //�}�̍��v.
            addSyokeiout.newbaitaicd = KKHSystemConst.KoteiMongon.BAITAI_GOUKEI;

            //�}�̍��v���z.
            //double baitaigokei = dblKingakuZeiAri + dblSagaku;
            addSyokeiout.seikyukin = baitaigokeiout.ToString();

            //���z�v�Z.
            //dblSagaku = ((dblKingakuZeiNashi - dblKingakuHikazei) * 1.05) + dblKingakuHikazei - dblKingakuZeiAri;
            //dblSagaku = ToHalfAdjust(((dblKingakuZeiNashi - dblKingakuHikazei) * pSyohizeiritu) + dblKingakuHikazei, 0) - dblKingakuZeiAri;
            //�}�̂̍ŏI�f�[�^�Œ[������.
            //choseikin = KKHUtility.DouParse(dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin) + dblSagaku;
            //dsash.displayFD[dsash.displayFD.Rows.Count - 1].seikyukin = choseikin.ToString();
            //�}�̍��v.
            //addSyokeiout.baitaicd = "�}�̍��v";
            //�}�̍��v���z.
            //double baitaigokeiout = dblKingakuZeiAri + dblSagaku;
            //addSyokeiout.seikyukin = baitaigokeiout.ToString();
            /* 2013/12/05 ����őΉ� HLC H.Watabe MOD End */

            //�ǉ�.
            dsash.displayFD.AdddisplayFDRow(addSyokeiout);

            //�����v�v�Z.
            dblSogoukei = dblSogoukei + baitaigokeiout;

            //�\���p(�����v�p)�f�[�^Row������.
            addSyokeiout = dsash.displayFD.NewdisplayFDRow();
            addSyokeiout = syokirowSet(addSyokeiout);

            //�����v.
            addSyokeiout.newbaitaicd = KKHSystemConst.KoteiMongon.SOUGOUKEI;

            //�����v���z.
            addSyokeiout.seikyukin = dblSogoukei.ToString();

            //�ǉ�.
            dsash.displayFD.AdddisplayFDRow(addSyokeiout);

            //�J���}��t����.
            for (int i = 0; i < dsash.displayFD.Rows.Count; i++)
            {
                double kanma = 0;
                //�������z.
                if (!string.IsNullOrEmpty(dsash.displayFD[i].seikyukin))
                {
                    kanma = double.Parse(dsash.displayFD[i].seikyukin);
                    dsash.displayFD[i].seikyukin = kanma.ToString("#,0");
                }
            }

            //�X�v���b�h�f�[�^�\�[�X�֓����.
            medMain_Sheet1.DataSource = dsash.displayFD;

            //�G�N�Z���{�^��.
            btnXls.Enabled = true;
            btnUpload.Enabled = true;

            //�����̕\��.
            lblKensu.Text = dsash.displayFD.Rows.Count.ToString() + "��";

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
        private RepDsAsh.displayFDRow syokirowSet(RepDsAsh.displayFDRow addrow)
        {
            addrow.no = string.Empty;
            addrow.seikyuno = string.Empty;
            addrow.baitaicd = string.Empty;
            addrow.seikyukin = string.Empty;
            addrow.kyokucd = string.Empty;
            addrow.hinsyucd = string.Empty;
            addrow.dairitencd = string.Empty;
            addrow.bangumicd = string.Empty;
            addrow.kenmei = string.Empty;
            addrow.seikyubi = string.Empty;
            /* 2015/02/24 �V�}�̃R�[�h�ǉ� A.Hisada ADD Start */
            addrow.newbaitaicd = string.Empty;
            return addrow;
        }
        #endregion �f�[�^Row�����Z�b�g.

        #region �����_���w��̈ʒu�Ŏl�̌ܓ�����.
        /// <summary>
        /// �����_���w��̈ʒu�Ŏl�̌ܓ�����.
        /// </summary>
        /// <param name="dValue">�l�̌ܓ�����l</param>
        /// <param name="iDigits">�����_�ȉ��̌���</param>
        /// <returns></returns>
        public static double ToHalfAdjust(double dValue, int iDigits)
        {
            double dv = dValue % 1.0;
            if (dv.ToString().Length <= 1) 
            { 
                return dValue; 
            }

            double dCoef = System.Math.Pow(10, iDigits);

            return dValue > 0 ? System.Math.Floor((dValue * dCoef) + 0.5) / dCoef :
                                System.Math.Ceiling((dValue * dCoef) - 0.5) / dCoef;
        }
        #endregion �����_���w��̈ʒu�Ŏl�̌ܓ�����.

        #region �t�@�C���o��.
        /// <summary>
        /// �t�@�C���o��.
        /// </summary>
        /// <param name="view"></param>
        private void FileOut(FarPoint.Win.Spread.SheetView view)
        {
            //SaveFileDialog�N���X�̃C���X�^���X���쐬.
            SaveFileDialog sfd = new SaveFileDialog();

            //���t.
            DateTime now = DateTime.Now;

            //�͂��߂̃t�@�C�������w�肷��.
            if (pStrRepFilNam.Equals(String.Empty))
            {
                sfd.FileName = "ASAHICM" + ".csv";
            }
            else
            {
                sfd.FileName = pStrRepFilNam + ".csv";
            }

            //�͂��߂ɕ\�������t�H���_���w�肷��.
            if (pStrRepAdrs.Equals(String.Empty))
            {
                sfd.InitialDirectory = "C:\\TMP\\";
            }
            else
            {
                sfd.InitialDirectory = pStrRepAdrs;
            }

            //[�t�@�C���̎��]�ɕ\�������I�������w�肷��.
            sfd.Filter = "CSV(��ϋ�؂�)(*.csv)|*.csv|���ׂẴt�@�C��|*.*";

            //[�t�@�C���̎��]�ł͂��߂Ɂu���ׂẴt�@�C���v���I������Ă���悤�ɂ���.
            sfd.FilterIndex = 1;

            //�^�C�g����ݒ肷��.
            sfd.Title = "�t�@�C���w��";

            //�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���.
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filnm = sfd.FileName;

                WriteFile(filnm, view);

                MessageUtility.ShowMessageBox(MessageCode.HB_I0013, new string[] { "�������܂���" } , "�t�@�C���o��", MessageBoxButtons.OK);
            }

            sfd.Dispose();
        }
        #endregion �t�@�C���o��.

        #region FD����������.
        /// <summary>
        /// FD����������.
        /// </summary>
        /// <param name="P_FileName"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        private int WriteFile(String P_FileName, FarPoint.Win.Spread.SheetView view)
        {
            //�t�@�C���o�͂���f�[�^.
            String L_Str;
            //�X�v���b�h�f�[�^.
            String L_Buf;

            System.Text.Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");

            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(P_FileName, false, enc);

            for (int i = 0; i < view.Rows.Count; i++)
            {
                if (!view.Cells[i, cKNo].Value.ToString().Equals(String.Empty))
                {
                    L_Str = "";

                    //�ԍ�.
                    L_Buf = view.Cells[i, cKNo].Value.ToString();
                    if (L_Buf.Length < 4)
                    {
                        L_Str = L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Buf.Substring(0, 4) + ",";
                    }

                    //�������ԍ�.
                    L_Buf = view.Cells[i, cKSeikyuNo].Value.ToString();
                    if (L_Buf.Length < 20)
                    {
                        L_Str = L_Str + L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 20) + ",";
                    }

                    /* 2015/02/24 �V�}�̃R�[�h��\�� A.Hisada ADD Start */
                    //�}�̃R�[�h.
                    L_Buf = view.Cells[i, cKNewBaitaiCd].Value.ToString();
                    if (L_Buf.Length < 3)
                    {
                        L_Str = L_Str + L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 3) + ",";
                    }
                    /* 2015/02/24 �V�}�̃R�[�h��\�� A.Hisada ADD End */

                    //�ǃR�[�h.
                    L_Buf = view.Cells[i, cKKyokuCd].Value.ToString();
                    if (L_Buf.Length < 3)
                    {
                        L_Str = L_Str + L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 3) + ",";
                    }

                    //�i��R�[�h.
                    L_Buf = view.Cells[i, cKHinshuCd].Value.ToString();
                    if (L_Buf.Length < 3)
                    {
                        L_Str = L_Str + L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 3) + ",";
                    }

                    //�㗝�X�R�[�h.
                    L_Buf = view.Cells[i, cKDairitenCd].Value.ToString();
                    if (L_Buf.Length < 2)
                    {
                        L_Str = L_Str + L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 2) + ",";
                    }

                    //�ԑg�R�[�h.
                    L_Buf = view.Cells[i, cKBangumiCd].Value.ToString();
                    if (L_Buf.Length < 2)
                    {
                        L_Str = L_Str + L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 2) + ",";
                    }

                    //�������z.
                    L_Buf = view.Cells[i, cKSeikyuKin].Value.ToString().Replace(",","") ;
                    if (L_Buf.Length < 13)
                    {
                        L_Str = L_Str + L_Buf.Trim() + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 13) + ",";
                    }

                    //������.
                    L_Buf = view.Cells[i, cKSeikyuBi].Value.ToString();
                    if (L_Buf.Length < 10)
                    {
                        L_Str = L_Str + L_Buf.Trim().PadRight(10)  + ",";
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 10) + ",";
                    }

                    //����.
                    L_Buf = view.Cells[i, cKKenmei].Value.ToString();
                    if (L_Buf.Length < 40)
                    {
                        L_Str = L_Str + L_Buf.Trim();
                    }
                    else
                    {
                        L_Str = L_Str + L_Buf.Substring(0, 40);
                    }

                    //�t�B�[���h����������.
                    streamWriter.WriteLine(L_Str);
                }
            }

            //����.
            streamWriter.Close();

            // �I�y���[�V�������O�̏o��.
            KKHLogUtilityAsh.WriteOperationLogToDB(_naviParam, KKHSystemConst.ApplicationID.APLID_FD_ASH, KKHLogUtilityAsh.KINO_ID_OPERATION_LOG_FD, KKHLogUtilityAsh.DESC_OPERATION_LOG_FD);
            return 0;
        }
        #endregion FD����������.

        /* 2015/02/17 �A�T�q�Ή�(�A�b�v���[�h�t�@�C���V�X�e����) Fukuda ADD Start */
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
            sfd.FileName = pStrRepFilNam2 + "_" + nowdate.ToString("yyyyMMddHHmmss") + ".xls";
            //�����t�@�C���ۑ���.
            sfd.InitialDirectory = pStrRepAdrs2;
            //�t�@�C����ނ̑I������ݒ�.
            sfd.Filter = "XLS�t�@�C��(*.xls)|*.xls";
            //�����t�@�C����ނ̐ݒ�.
            //[���ׂẴt�@�C��]��ݒ�.
            sfd.FilterIndex = 0;
            //�^�C�g���̐ݒ�.
            sfd.Title = "�ۑ���̃t�@�C����ݒ肵�ĉ������B";
            //�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���.
            sfd.RestoreDirectory = true;
            //�_�C�A���O��\�����AOk�{�^�����������ꂽ��.

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

                /*
                 * �o�͎��s.
                 */
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
            //��Ɨp�t�H���_�p�X.
            string workFolderPath = pStrRepTempAdrs;
            string macrofile = workFolderPath + REP_MACRO_FILENAME;
            string tempfile = workFolderPath + REP_TEMPLATE_FILENAME;
            //�e�[�u���ǉ��p�f�[�^Row
            DataRow dtRow;

            try
            {
                /*
                 * Excel�J�n����.
                 */
                //���\�[�X����Excel�t�@�C�����쐬(�e���v���[�g�ƃ}�N��).
                File.WriteAllBytes(macrofile, Isid.KKH.Ash.Properties.Resources.Ash_Fd);
                File.WriteAllBytes(tempfile, Isid.KKH.Ash.Properties.Resources.Ash_Fd_Template);

                if (System.IO.File.Exists(tempfile) == false) { throw new Exception("�e���v���[�gExcel�t�@�C��������܂���B"); }
                if (System.IO.File.Exists(macrofile) == false) { throw new Exception("�}�N��Excel�t�@�C��������܂���B"); }

                //�f�[�^�Z�b�gXML�o��.
                RepDsAsh dtRepDsAsh = new RepDsAsh();
                dtRepDsAsh.displayFD.Merge((RepDsAsh.displayFDDataTable)medMain_Sheet1.DataSource);
                for (int i = dtRepDsAsh.displayFD.Count - 1; i >= 0 ; i--)
                {
                    //No�������Ă��Ȃ����R�[�h�͏��v�A���v�s�Ȃ̂ō폜.
                    if (dtRepDsAsh.displayFD[i].no == null || dtRepDsAsh.displayFD[i].no.Trim() == "")
                    {
                        dtRepDsAsh.displayFD.Rows.RemoveAt(i);
                    }
                }
                dtRepDsAsh.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));

                // �p�����[�^XML�쐬�A�o��.
                // �ϐ��̐錾.
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // �f�[�^�Z�b�g�Ƀe�[�u����ǉ�����.
                // PRODUCTS�Ƃ����e�[�u�����쐬����.
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("USERNAME", Type.GetType("System.String"));
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));

                //�e�[�u���Ƀf�[�^��ǉ�����.
                dtRow = dtTable.NewRow();

                dtRow["USERNAME"] = tslName.Text;
                dtRow["SAVEDIR"] = filenm;

                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //�G�N�Z���N��.
                System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME);

                //�폜�p�ɕێ�(�߂�{�^���������ɍ폜�����).
                _strmacrodel = workFolderPath + REP_MACRO_FILENAME;

                // �I�y���[�V�������O�̏o�� .
                KKHLogUtilityAsh.WriteOperationLogToDB(_naviParam, KKHSystemConst.ApplicationID.APLID_FD_ASH, KKHLogUtilityAsh.KINO_ID_OPERATION_LOG_FD, KKHLogUtilityAsh.DESC_OPERATION_LOG_FD);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion �G�N�Z���o��.
        /* 2015/02/17 �A�T�q�Ή�(�A�b�v���[�h�t�@�C���V�X�e����) Fukuda ADD End */
        #endregion ���\�b�h.
    }
}