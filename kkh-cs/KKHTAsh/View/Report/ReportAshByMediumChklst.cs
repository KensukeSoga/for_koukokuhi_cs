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
namespace Isid.KKH.Ash.View.Report
{
    /// <summary>
    /// �L����A�b�v���[�h�V�[�g.
    /// </summary>
    public partial class ReportAshByMediumChklst : Isid.KKH.Common.KKHView.Common.Form.KKHForm
    {
        #region �萔.
        #region �Œ蕶��.
        /// <summary>
        /// �Ώۃf�[�^�Ȃ��̏ꍇ�̕���.
        /// </summary>
        private const string MSG_NOTHING = "�Ώۂ�����܂���";
        /// <summary>
        /// �A�v��ID.
        /// </summary>
        private const string APLID = "Chklst";
        /// <summary>
        /// �e���r���Q�����ϊ��p.
        /// </summary>
        private const string EHIMEBefor = "���Q����";
        /// <summary>
        /// �e���r���Q�����ϊ��p.
        /// </summary>
        private const string EHIMEAfter = "�e���r���Q";
        /// <summary>
        /// 0.
        /// </summary>
        private const string ZERO = "0";
        #endregion �Œ蕶��.

        #region ���[.
        /// <summary>
        /// Excel(���[�o�̓}�N������)�t�@�C����.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME = "Ash_MediumChklst.xlsm";
        /// <summary>
        /// Excel(���[�o�̓}�N���e���v���[�g)�t�@�C����.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "Ash_MediumChklst_Template.xls";
        /// <summary>
        /// XML�t�@�C����1.
        /// </summary>
        private static readonly string REP_XML_FILENAME = "Ash_MediumChklst_Data.xml";
        /// <summary>
        /// XML�t�@�C����2.
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "Ash_MediumChklst_Prop.xml";
        #endregion ���[.
        #endregion �萔.

        #region �����o�ϐ�.
        /// <summary>
        /// �i�r�p�����[�^�[.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// �N��.
        /// </summary>
        string yearmon = string.Empty;
        /// <summary>
        /// �o�͗p�f�[�^�Z�b�g.
        /// </summary>
        private RepDsAsh repDsMedia = null;
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
        /// �R�s�[�}�N���폜�pstring
        /// </summary>
        private string _strmacrodel;
        /* 2015/03/13 �A�T�q�Ή�(�A�b�v���[�h�V�[�g�ŐV��) Fukuda ADD Start */
        /// <summary>
        /// ����.
        /// </summary>
        private string _busyo;
        /// <summary>
        /// �x����.
        /// </summary>
        private string _shiharaisaki;
        /// <summary>
        /// �����.
        /// </summary>
        private string _aitesaki;
        /* 2015/03/13 �A�T�q�Ή�(�A�b�v���[�h�V�[�g�ŐV��) Fukuda ADD End */
        #endregion �����o�ϐ�.

        #region �R���X�g���N�^.

        /// <summary>
        /// �R���X�g���N�^.
        /// </summary>
        public ReportAshByMediumChklst()
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

        #region �t�H�[�����[�h.
        /// <summary>
        /// �t�H�[�����[�h.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportAshByMediumChklst_Shown(object sender, EventArgs e)
        {
            //���[�f�B���O�\��.
            base.ShowLoadingDialog();

            //�ҏW.
            EditControl();

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

            //�ۑ����{���[��.
            CommonProcessController commonProcessController2 = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult2 = commonProcessController2.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                                            "002");

            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //�ۑ���Z�b�g.
                pStrRepAdrs = comResult2.CommonDataSet.SystemCommon[0].field2.ToString();
                //���̃Z�b�g.
                pStrRepFilNam = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
                /* 2015/03/13 �A�T�q�Ή�(�A�b�v���[�h�V�[�g�ŐV��) fukuda ADD start */
                _busyo = comResult2.CommonDataSet.SystemCommon[0].field5.ToString();
                _shiharaisaki = comResult2.CommonDataSet.SystemCommon[0].field6.ToString();
                _aitesaki = comResult2.CommonDataSet.SystemCommon[0].field7.ToString();
                /* 2015/03/13 �A�T�q�Ή�(�A�b�v���[�h�V�[�g�ŐV��) fukuda ADD end   */
            }

            //���[�f�B���O��\��.
            base.CloseLoadingDialog();
        }
        #endregion �t�H�[�����[�h.

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

                    // �t�@�C�����폜����.
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
            //�\��.
            DisplayView();

            //�R���g���[���𖢑I����Ԃɂ���.
            this.ActiveControl = null;
        }
        #endregion �\���{�^���N���b�N.

        #region �}�̑I���R���{�`�F���W�C�x���g.
        /// <summary>
        /// �}�̑I���R���{�`�F���W�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mediaCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (repDsMedia == null)
            {
                return;
            }
            else
            {
                //[���v]�̏ꍇ.
                if (mediaCmb.SelectedValue.ToString() == KkhConstAsh.BaitaiCd.GOKEI)
                {
                    MakeSum();
                    ////�����{�^����񊈐�.
                    //btnSrc.Enabled = false;
                    btnSrc.Enabled = true;
                }
                else
                {
                    BindingSource(mediaCmb.SelectedValue.ToString());
                    //�����{�^��������.
                    btnSrc.Enabled = true;
                }
            }
        }
        #endregion �}�̑I���R���{�`�F���W�C�x���g.

        #region Excel�{�^���N���b�N.
        /// <summary>
        /// Excel�{�^���N���b�N.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            // �t�@�C������.
            excelFileSet();

            //�R���g���[���𖢑I����Ԃɂ���.
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
            /* 2015/02/23 �A�T�q�Ή� JSE Miyanoue ADD Start */
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
            SybtNameTable.Rows.Add(KkhConstAsh.BaitaiNm.GOKEI, KkhConstAsh.BaitaiCd.GOKEI);

            mediaCmb.DataSource = SybtNameTable;
            mediaCmb.DisplayMember = "Display";
            mediaCmb.ValueMember = "Value";
            mediaCmb.SelectedValue = KkhConstAsh.BaitaiCd.TV_TIME;
            /* 2015/02/23 �A�T�q�Ή� JSE Miyanoue ADD End */
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

            //�����ݒ�.
            txtSeiGak.Text = ZERO;
            btnXls.Enabled = false;
            mediaCmb.Enabled = false;
            //���v�p.
            double syoukei = 0;
            double syoukeiKomi = 0;
            double tyouseiGaku = 0;
            //��ې�.
            double hikazei = 0;
            //�}�̋敪�i�[.
            string baitaiKbn = string.Empty;
            //�}�̃R�[�h.
            string baitaiCd = string.Empty;
            /* 2015/02/23 �A�T�q�Ή� JSE Miyanoue MOD Start */
            //�}�̃R�[�h���疼�̂��擾.
            //baitaiCd = baitaiNmOfCode(mediaCmb.SelectedItem.ToString());
            baitaiCd = mediaCmb.SelectedValue.ToString();
            //�\����
            double order = 0;
            /* 2015/02/23 �A�T�q�Ή� JSE Miyanoue MOD End */
            //����ŗ�.
            double lngComTax = 0;
            //����ŗ��ێ��p.
            double lngComTaxSave = 0;
            repDsMedia = new RepDsAsh();
            //�}�̕ʍ��v���z.
            double baitaigokei = 0;

            /* 2013/12/04 ����őΉ� HLC H.Watabe ADD Start */
            List<double> listTaxRate = new List<double>();
            List<double> listAmount = new List<double>();
            int listIndex = 0;
            double mediaTaxSumFromRows = 0;
            /* 2013/12/04 ����őΉ� HLC H.Watabe ADD End */

            //�N���̃Z�b�g.
            yearmon = txtYm.Value;

            //�p�����[�^�[�̃Z�b�g.
            ReportAshProcessController.FindReportAshByMedium param = new ReportAshProcessController.FindReportAshByMedium();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = yearmon;

            //����.
            ReportAshProcessController processController = ReportAshProcessController.GetInstance();
            FindReportAshMediaByCondServiceResult result = processController.findReportMediaChklst(param);
            //�G���[�̏ꍇ.
            if (result.HasError)
            {
                //���[�f�B���O�\���I��.
                base.CloseLoadingDialog();
                medMain_Sheet1.Rows.Count = 0;
                return;
            }

            RepDsAsh.RepAshMediaChklstRow[] resultRow = (RepDsAsh.RepAshMediaChklstRow[])result.dsAshDataSet.RepAshMediaChklst.Select("", "");

            if (resultRow.Length == 0)
            {
                //���[�f�B���O�\���I��.
                base.CloseLoadingDialog();

                txtSeiGak.Text = "0";
                medMain_Sheet1.Rows.Count = 0;
                lblKensu.Text = "0��";
                MessageUtility.ShowMessageBox(MessageCode.HB_W0031, null, "���[", MessageBoxButtons.OK);
                return;
            }

            RepDsAsh.SeigakByMediaRow mediaRow = repDsMedia.SeigakByMedia.NewSeigakByMediaRow();
            mediaRow = seigakSyokirowSet(mediaRow);
            
            /* 2015/03/13 �A�T�q�Ή�(�A�b�v���[�h�V�[�g�ŐV��) Fukuda ADD Start */
            AshBaitaiUtility baitaiUtil = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            /* 2015/03/13 �A�T�q�Ή�(�A�b�v���[�h�V�[�g�ŐV��) Fukuda ADD End */

            //�s���J�E���g.
            int count = 0;
            foreach (RepDsAsh.RepAshMediaChklstRow hrow in resultRow)
            {
                //�����.
                if (hrow.ritu1.Trim().Equals("0"))
                {
                    lngComTax = 1;
                }
                else
                {
                    lngComTax = 1 + (double.Parse(hrow.ritu1.Trim()) * 0.01);
                }
                
                //����������0���̏ꍇ.
                if (count == 0)
                {
                    //�}�̖��̒����l���i�[����.
                    syoukei = double.Parse(hrow.seikyukin);
                    syoukeiKomi = double.Parse(hrow.seikyukinkomi);
                    tyouseiGaku = ToHalfAdjust(syoukei * lngComTax, 0) - syoukeiKomi;
                }
                else
                {
                    //1�O�̔}�̃R�[�h�ƈقȂ�ꍇ.
                    if (baitaiKbn == hrow.baitaicd)
                    {
                        syoukei += double.Parse(hrow.seikyukin);
                        syoukeiKomi += double.Parse(hrow.seikyukinkomi);
                        tyouseiGaku += ToHalfAdjust(double.Parse(hrow.seikyukin) * lngComTax, 0)
                            - double.Parse(hrow.seikyukinkomi);
                        if (double.Parse(hrow.ritu1.ToString()) == 0)
                        {
                            hikazei = hikazei + double.Parse(hrow.seikyukin.ToString());
                        }
                    }
                    else
                    {
                        if (baitaiKbn == repDsMedia.displayMediaChklst[count - 1].baitaicd)
                        {
                            /* 2016/11/24 �A�T�q����őΉ� HLC K.Soga DEL Start */
                            ///* 2013/12/04 ����őΉ� HLC H.Watabe MOD Start */
                            ////�}�̍��v.
                            ////baitaigokei -= double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi);
                            ////��r�O�̔}�̃f�[�^�̍ŏI��ɁA���z���𑫂����ō��݋��z������.
                            ////���V�[�g���ɍ��z�C�����Ă������Ƃ̏�����.
                            ////repDsMedia.displayMediaChklst[count - 1].seikyukinkomi = string.Format("{0:N0}", double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi) + (((syoukei - hikazei) * lngComTax) + hikazei) - syoukeiKomi);
                            ////repDsMedia.displayMediaChklst[count - 1].seikyukinkomi = string.Format("{0:N0}", double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi) + (((syoukei - hikazei) * lngComTaxSave) + hikazei) - syoukeiKomi);
                            ////�}�̍��v.
                            ////baitaigokei += double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi);

                            //double sumTax = 0;
                            //for (int index = 0; index < listTaxRate.Count; index++)
                            //{
                            //    sumTax += Math.Truncate((1 + (listTaxRate[index] * 0.01)) * listAmount[index]);  
                            //}
                            //double newTaxAmount = double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi) + sumTax - baitaigokei;
                            //repDsMedia.displayMediaChklst[count - 1].seikyukinkomi = string.Format("{0:N0}", newTaxAmount);
                            //baitaigokei = sumTax;
                            ///* 2013/12/04 ����őΉ� HLC H.Watabe MOD End */
                            /* 2016/11/24 �A�T�q����őΉ� HLC K.Soga DEL End */

                            //���z�ݒ�.
                            seigakRowSet(baitaiKbn, String.Format("{0}", baitaigokei), ref mediaRow);
                            baitaigokei = 0;

                            /* 2013/12/04 ����őΉ� HLC H.Watabe ADD Start */
                            listAmount.Clear();
                            listTaxRate.Clear();
                            /* ����őΉ� 2013/12/04 HLC H.Watabe ADD End */
                        }

                        syoukei += double.Parse(hrow.seikyukin);
                        syoukeiKomi += double.Parse(hrow.seikyukinkomi);
                        tyouseiGaku += ToHalfAdjust(double.Parse(hrow.seikyukin) * lngComTax, 0) - double.Parse(hrow.seikyukinkomi);
                        if (double.Parse(hrow.ritu1.ToString()) == 0)
                        {
                            hikazei = hikazei + double.Parse(hrow.seikyukin.ToString());
                        }

                        //������.
                        syoukei = 0;
                        syoukeiKomi = 0;
                        tyouseiGaku = 0;
                        hikazei = 0;
                    }

                    /* 2015/03/19 �A�T�q�Ή� Miyanoue ADD Start */
                    //�\�����̐ݒ�.
                    String newBaitaiCd = baitaiUtil.ConvertOldCdToNewCd(hrow.baitaicd).baitaiCd;
                    List<AshBaitaiUtility.BaitaiOrderResult> resOrderList = baitaiUtil.GetBaitaiOrderList();
                    for (int i = 0; i < resOrderList.Count; i++)
                    {
                        if (newBaitaiCd == resOrderList[i].baitaiCord)
                        {
                            order = resOrderList[i].baitaiOrder;
                            break;
                        }
                        else
                        {
                            order = 999;
                        }
                    }
                    /* 2015/03/19 �A�T�q�Ή� Miyanoue ADD Start */
                }

                //�}�̍��v.
                baitaigokei += double.Parse(hrow.seikyukinkomi);

                RepDsAsh.displayMediaChklstRow addrow = repDsMedia.displayMediaChklst.NewdisplayMediaChklstRow();
                addrow = dispSyokirowSet(addrow);
                addrow.seikyuno = string.Empty;
                addrow.baitaikbn = hrow.baitaikbn;
                addrow.baitaicd = hrow.baitaicd;
                /* 2015/03/13 �A�T�q�Ή�(�A�b�v���[�h�V�[�g�ŐV��) Fukuda ADD Start */
                addrow.tokuisakibaitaicd = baitaiUtil.ConvertOldCdToNewCd(addrow.baitaicd).baitaiCd;
                /* 2015/03/13 �A�T�q�Ή�(�A�b�v���[�h�V�[�g�ŐV��) Fukuda ADD End   */
                addrow.seikyukinkomi = string.Format("{0:N0}", Math.Truncate(double.Parse(hrow.seikyukinkomi)));
                addrow.seikyukin = string.Format("{0:N0}", double.Parse(hrow.seikyukin));
                addrow.kyokucd = hrow.kyokucd;
                addrow.kyokubaitaicd = hrow.kyokubaitaicd;
                addrow.hinsyunm = hrow.hinsyunm;
                addrow.hinsyucd = hrow.hinsyucd;
                addrow.hinsyubaitaicd = hrow.hinsyubaitaicd;
                addrow.kenmei = hrow.kenmei;
                /* 2015/03/19 �A�T�q�Ή� Miyanoue ADD Start */
                addrow.order = order;
                /* 2015/03/19 �A�T�q�Ή� Miyanoue ADD End */
                
                //���Q�����Ή�.
                if (!string.IsNullOrEmpty(hrow.Field6.Trim()))
                {
                    addrow.kyokunm = hrow.Field6.Trim();
                }
                else
                {
                    addrow.kyokunm = hrow.kyokunm;
                }

                if (string.IsNullOrEmpty(addrow.kyokubaitaicd.Trim()))
                {
                    addrow.baitaikbn = "";
                    addrow.kyokubaitaicd = MSG_NOTHING;
                }

                //�u�i��CD�v���󔒂̏ꍇ�́u�i��CD�v�ɑΏۖ����\��.
                if (string.IsNullOrEmpty(addrow.hinsyubaitaicd.Trim()))
                {
                    addrow.hinsyubaitaicd = MSG_NOTHING;
                }
                /* 2015/03/13 �A�T�q�Ή�(�A�b�v���[�h�V�[�g�ŐV��) Fukuda ADD Start */
                addrow.busyo = _busyo;
                addrow.shiharaisaki = _shiharaisaki;
                addrow.aitesaki = _aitesaki;
                /* 2015/03/13 �A�T�q�Ή�(�A�b�v���[�h�V�[�g�ŐV��) Fukuda ADD End   */
                repDsMedia.displayMediaChklst.AdddisplayMediaChklstRow(addrow);

                //�}�̃R�[�h��ێ�����.
                baitaiKbn = hrow.baitaicd;

                //����ŗ���ێ�����.
                if (string.Format("{0:N0}", double.Parse(hrow.seikyukin)) != ("0"))
                {
                    if (lngComTax != 1.0)
                    {
                        lngComTaxSave = lngComTax;
                    }
                }

                //���Z����.
                count++;
                /* 2013/12/04 ����őΉ� HLC H.Watabe ADD Start */
                if (listTaxRate.Count != 0)
                {
                    bool taxGetFlg = false;
                    for (int index = 0; index < listTaxRate.Count; index++)
                    {
                        if (listTaxRate[index] == double.Parse(hrow.ritu1.Trim()))
                        {
                            listAmount[index] += double.Parse(hrow.seikyukin.Trim());
                            taxGetFlg = true;
                            break;
                        }
                    }

                    if (!taxGetFlg)
                    {
                        listTaxRate.Add(double.Parse(hrow.ritu1.Trim()));
                        listAmount.Add(double.Parse(hrow.seikyukin.Trim()));
                    }
                }
                else
                {
                    listTaxRate.Add(double.Parse(hrow.ritu1.Trim()));
                    listAmount.Add(double.Parse(hrow.seikyukin.Trim()));
                }
                /* 2013/12/04 ����őΉ� HLC H.Watabe ADD End */
            }

            /* 2016/11/24 �A�T�q����őΉ� HLC K.Soga DEL Start */
            ///* 2013/12/04 ����őΉ� HLC H.Watabe MOD Start */
            ////�ŏI�s�̒����z���č���.
            //double sum = 0;
            ////�}�̍��v.
            //double temp = baitaigokei;
            //baitaigokei -= double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi);
            //for (int index = 0; index < listTaxRate.Count; index++)
            //{
            //    sum += Math.Truncate((1 + (listTaxRate[index] * 0.01)) * listAmount[index]);
            //}
            //double newAmount = double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi) + sum - temp;
            ////repDsMedia.displayMediaChklst[count - 1].seikyukinkomi = string.Format("{0:N0}", double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi) + tyouseiGaku);
            //repDsMedia.displayMediaChklst[count - 1].seikyukinkomi = string.Format("{0:N0}", newAmount);
            ///* 2013/12/04 ����őΉ� HLC H.Watabe ADD End */
            /* 2016/11/24 �A�T�q����őΉ� HLC K.Soga DEL End */

            //�}�̍��v.
            baitaigokei += double.Parse(repDsMedia.displayMediaChklst[count - 1].seikyukinkomi);

            //���z�ݒ�.
            seigakRowSet(baitaiKbn, String.Format("{0}", baitaigokei), ref mediaRow);

            //���v���z�ݒ�.
            totalRowSet(ref mediaRow);
            repDsMedia.SeigakByMedia.AddSeigakByMediaRow(mediaRow);

            //[���v]�̏ꍇ.
            if (baitaiCd == KkhConstAsh.BaitaiCd.GOKEI)
            {
                MakeSum();
            }
            else
            {
                //�X�v���b�h�Ƀf�[�^���o�C���h����.
                BindingSource(baitaiCd);
            }

            //�G�N�Z���{�^��.
            btnXls.Enabled = true;

            //�R���{�{�b�N�X.
            mediaCmb.Enabled = true;

            //���[�f�B���O�\���I��.
            base.CloseLoadingDialog();
        }
        #endregion �f�[�^�\��.

        #region �}�̖��ɍ��v�l���i�[����.
        /// <summary>
        /// �}�̖��ɍ��v�l���i�[����.
        /// </summary>
        /// <param name="baitaiCd"></param>
        /// <param name="kingaku"></param>
        /// <param name="drow"></param>
        private void seigakRowSet(string baitaiCd, string kingaku, ref RepDsAsh.SeigakByMediaRow drow)
        {
            switch (baitaiCd)
            {
                //�e���r�^�C��.
                case KkhConstAsh.BaitaiCd.TV_TIME:
                    drow.TVTIME = kingaku;
                    break;
                //���W�I�^�C��.
                case KkhConstAsh.BaitaiCd.RADIO_TIME:
                    drow.RADIOTIME = kingaku;
                    break;
                //���W�I�X�|�b�g.
                case KkhConstAsh.BaitaiCd.RADIO_SPOT:
                    drow.RADIOSPOT = kingaku;
                    break;
                //�e���r�X�|�b�g.
                case KkhConstAsh.BaitaiCd.TV_SPOT:
                    drow.TVSPOT = kingaku;
                    break;
                //�V��.
                case KkhConstAsh.BaitaiCd.SHINBUN:
                    drow.SHINBUN = kingaku;
                    break;
                //�G��.
                case KkhConstAsh.BaitaiCd.ZASHI:
                    drow.ZASSHI = kingaku;
                    break;
                //���.
                case KkhConstAsh.BaitaiCd.KOUTSU:
                    drow.OOH = kingaku;
                    break;
                //����.
                case KkhConstAsh.BaitaiCd.SEISAKU:
                    drow.SEISAKU = kingaku;
                    break;
                //���̑�.
                case KkhConstAsh.BaitaiCd.SONOTA:
                    drow.SONOTA = kingaku;
                    break;
                //�j���[���f�B�A.
                case KkhConstAsh.BaitaiCd.NEW_MEDIA:
                    drow.NEWMEDIA = kingaku;
                    break;
                //�C���^�[�l�b�g.
                case KkhConstAsh.BaitaiCd.INTERNET:
                    drow.INTERNET = kingaku;
                    break;
                //BS.
                case KkhConstAsh.BaitaiCd.BS:
                    drow.BS = kingaku;
                    break;
                //CS.
                case KkhConstAsh.BaitaiCd.CS:
                    drow.CS = kingaku;
                    break;
                //���O�L��.
                case KkhConstAsh.BaitaiCd.OKUGAI:
                    drow.YAGAIKOKOKU = kingaku;
                    break;
                //�����.
                case KkhConstAsh.BaitaiCd.EVENT:
                    drow.EVENT = kingaku;
                    break;
                //����.
                case KkhConstAsh.BaitaiCd.TYOUSA:
                    drow.TYOUSA = kingaku;
                    break;
                //���f�B�A�t�B�[.
                case KkhConstAsh.BaitaiCd.MEDIA_FEE:
                    drow.MEDIAFEE = kingaku;
                    break;
                //�u�����h�Ǘ��t�B�[.
                case KkhConstAsh.BaitaiCd.BRAND_FEE:
                    drow.BLANDFEE = kingaku;
                    break;
            }
        }
        #endregion �}�̖��ɍ��v�l���i�[����.

        #region �S�}�̂̍��v�l���i�[����.
        /// <summary>
        /// �S�}�̂̍��v�l���i�[����.
        /// </summary>
        /// <param name="baitaiCd"></param>
        /// <param name="kingaku"></param>
        /// <param name="drow"></param>
        private void totalRowSet(ref RepDsAsh.SeigakByMediaRow drow)
        {
            double total = 0;
            if (drow.TVTIME != "0") { total = total + double.Parse(drow.TVTIME); }
            if (drow.RADIOTIME != "0") { total = total + double.Parse(drow.RADIOTIME); }
            if (drow.RADIOSPOT != "0") { total = total + double.Parse(drow.RADIOSPOT); }
            if (drow.TVSPOT != "0") { total = total + double.Parse(drow.TVSPOT); }
            if (drow.SHINBUN != "0") { total = total + double.Parse(drow.SHINBUN); }
            if (drow.ZASSHI != "0") { total = total + double.Parse(drow.ZASSHI); }
            if (drow.OOH != "0") { total = total + double.Parse(drow.OOH); }
            if (drow.SEISAKU != "0") { total = total + double.Parse(drow.SEISAKU); }
            if (drow.SONOTA != "0") { total = total + double.Parse(drow.SONOTA); }
            if (drow.NEWMEDIA != "0") { total = total + double.Parse(drow.NEWMEDIA); }
            if (drow.INTERNET != "0") { total = total + double.Parse(drow.INTERNET); }
            if (drow.BS != "0") { total = total + double.Parse(drow.BS); }
            if (drow.CS != "0") { total = total + double.Parse(drow.CS); }
            if (drow.YAGAIKOKOKU != "0") { total = total + double.Parse(drow.YAGAIKOKOKU); }
            if (drow.EVENT != "0") { total = total + double.Parse(drow.EVENT); }
            if (drow.TYOUSA != "0") { total = total + double.Parse(drow.TYOUSA); }
            if (drow.MEDIAFEE != "0") { total = total + double.Parse(drow.MEDIAFEE); }
            if (drow.BLANDFEE != "0") { total = total + double.Parse(drow.BLANDFEE); }
            drow.TOTAL = String.Format("{0}", total);
        }
        #endregion �S�}�̂̍��v�l���i�[����.

        #region �f�[�^Row�����Z�b�g.
        /// <summary>
        /// �f�[�^Row�����Z�b�g.
        /// </summary>
        /// <param name="addrow"></param>
        /// <returns></returns>
        private RepDsAsh.displayMediaChklstRow dispSyokirowSet(RepDsAsh.displayMediaChklstRow addrow)
        {
            addrow.seikyuno = string.Empty;
            addrow.baitaikbn = string.Empty;
            addrow.baitaicd = string.Empty;
            addrow.seikyukinkomi = string.Empty;
            addrow.seikyukin = string.Empty;
            addrow.kyokunm = string.Empty;
            addrow.kyokucd = string.Empty;
            addrow.kyokubaitaicd = string.Empty;
            addrow.hinsyunm = string.Empty;
            addrow.hinsyucd = string.Empty;
            addrow.hinsyubaitaicd = string.Empty;
            addrow.kenmei = string.Empty;
            addrow.kenmei2 = "";
            return addrow;
        }
        #endregion �f�[�^Row�����Z�b�g.

        #region ���v�f�[�^Row�����Z�b�g.
        /// <summary>
        /// ���v�f�[�^Row�����Z�b�g.
        /// </summary>
        /// <param name="addrow"></param>
        /// <returns></returns>
        private RepDsAsh.SeigakByMediaRow seigakSyokirowSet(RepDsAsh.SeigakByMediaRow addrow)
        {
            addrow.TVTIME = "0";
            addrow.TVSPOT = "0";
            addrow.RADIOTIME = "0";
            addrow.RADIOSPOT = "0";
            addrow.SHINBUN = "0";
            addrow.ZASSHI = "0";
            addrow.OOH = "0";
            addrow.YAGAIKOKOKU = "0";
            addrow.SEISAKU = "0";
            addrow.EVENT = "0";
            addrow.SONOTA = "0";
            addrow.NEWMEDIA = "0";
            addrow.INTERNET = "0";
            addrow.BS = "0";
            addrow.CS = "0";
            addrow.TYOUSA = "0";
            addrow.MEDIAFEE = "0";
            addrow.BLANDFEE = "0";
            return addrow;
        }
        #endregion ���v�f�[�^Row�����Z�b�g.

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
            sfd.FileName = pStrRepFilNam + txtYm.Year + "�N" + txtYm.Month + "��";
            //�����t�@�C���ۑ���.
            sfd.InitialDirectory = pStrRepAdrs;
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
                    //�o�͐�ɓ�����Excel�t�@�C�����J���Ă��܂��B���Ă���ēx�o�͂��Ă��������B.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "���[", MessageBoxButtons.OK);
                    return;
                }

                // �o�͎��s.
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

            //�e�[�u���ǉ��p�f�[�^Row.
            DataRow dtRow;

            try
            {
                // Excel�J�n����.
                // ���\�[�X����Excel�t�@�C�����쐬(�e���v���[�g�ƃ}�N��).
                File.WriteAllBytes(macrofile, Isid.KKH.Ash.Properties.Resources.Ash_MediumChklst);
                File.WriteAllBytes(tempfile, Isid.KKH.Ash.Properties.Resources.Ash_MediumChklst_Template);

                if (!System.IO.File.Exists(tempfile)) 
                { 
                    throw new Exception("�e���v���[�gExcel�t�@�C��������܂���B"); 
                }
                if (!System.IO.File.Exists(macrofile)) 
                { 
                    throw new Exception("�}�N��Excel�t�@�C��������܂���B"); 
                }

                //�f�[�^�Z�b�gXML�o��.
                //2015/03/19 miyanoue �A�T�q�Ή� Start
                //DataSet ds = new DataSet();
                RepDsAsh ds = new RepDsAsh();
                //ds = repDsMedia;
                DataRow[] row = repDsMedia.displayMediaChklst.Select("", "order, tokuisakibaitaicd");
                for (int i = 0; i < row.Length; i++)
                {
                    ds.displayMediaChklst.ImportRow(row[i]);
                }
                ds.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));
                //2015/03/19 miyanoue �A�T�q�Ή� End

                // �p�����[�^XML�쐬�A�o��.
                // �ϐ��̐錾.
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // �f�[�^�Z�b�g�Ƀe�[�u����ǉ�����.
                // PRODUCTS�Ƃ����e�[�u�����쐬���܂�.
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("USERNAME", Type.GetType("System.String"));
                //dtTable.Columns.Add("SELHDK", Type.GetType("System.String"));
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                dtTable.Columns.Add("SYOHIZEI", Type.GetType("System.String"));

                //�e�[�u���Ƀf�[�^��ǉ�����.
                dtRow = dtTable.NewRow();

                dtRow["SAVEDIR"] = filenm;
                dtRow["SYOHIZEI"] = _dbSyohizei.ToString();
                dtRow["USERNAME"] = tslName.Text;
                //dtRow["SELHDK"] = txtYm.Year + "�N" + txtYm.Month + "��";

                dtTable.Rows.Add(dtRow);

                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //�G�N�Z���N��.
                System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME);

                //�폜�p�ɕێ��i�߂�{�^���������ɍ폜����ׁj.
                _strmacrodel = workFolderPath + REP_MACRO_FILENAME;

                // �I�y���[�V�������O�̏o��.
                KKHLogUtilityAsh.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityAsh.KINO_ID_OPERATION_LOG_MediumChklst, KKHLogUtilityAsh.DESC_OPERATION_LOG_MediumChklst);
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
        /// <param name="baitaiNm"></param>
        /// <returns></returns>
        private string baitaiNmOfCode(string baitaiNm)
        {
            switch (baitaiNm)
            {
                //�e���r�^�C��.
                case KkhConstAsh.BaitaiNm.TV_TIME:
                    return KkhConstAsh.BaitaiCd.TV_TIME;
                //���W�I�^�C��.
                case KkhConstAsh.BaitaiNm.RADIO_TIME:
                    return KkhConstAsh.BaitaiCd.RADIO_TIME;
                //���W�I�X�|�b�g.
                case KkhConstAsh.BaitaiNm.RADIO_SPOT:
                    return KkhConstAsh.BaitaiCd.RADIO_SPOT;
                //�e���r�X�|�b�g.
                case KkhConstAsh.BaitaiNm.TV_SPOT:
                    return KkhConstAsh.BaitaiCd.TV_SPOT;
                //�V��.
                case KkhConstAsh.BaitaiNm.SHINBUN:
                    return KkhConstAsh.BaitaiCd.SHINBUN;
                //�G��.
                case KkhConstAsh.BaitaiNm.ZASHI:
                    return KkhConstAsh.BaitaiCd.ZASHI;
                //���.
                case KkhConstAsh.BaitaiNm.KOUTSU:
                    return KkhConstAsh.BaitaiCd.KOUTSU;
                //����.
                case KkhConstAsh.BaitaiNm.SEISAKU:
                    return KkhConstAsh.BaitaiCd.SEISAKU;
                //���̑�.
                case KkhConstAsh.BaitaiNm.SONOTA:
                    return KkhConstAsh.BaitaiCd.SONOTA;
                //�j���[���f�B�A.
                case KkhConstAsh.BaitaiNm.NEW_MEDIA:
                    return KkhConstAsh.BaitaiCd.NEW_MEDIA;
                //�C���^�[�l�b�g.
                case KkhConstAsh.BaitaiNm.INTERNET:
                    return KkhConstAsh.BaitaiCd.INTERNET;
                //BS.
                case KkhConstAsh.BaitaiNm.BS:
                    return KkhConstAsh.BaitaiCd.BS;
                //CS.
                case KkhConstAsh.BaitaiNm.CS:
                    return KkhConstAsh.BaitaiCd.CS;
                //���O�L��.
                case KkhConstAsh.BaitaiNm.OKUGAI:
                    return KkhConstAsh.BaitaiCd.OKUGAI;
                //�����.
                case KkhConstAsh.BaitaiNm.EVENT:
                    return KkhConstAsh.BaitaiCd.EVENT;
                //����.
                case KkhConstAsh.BaitaiNm.TYOUSA:
                    return KkhConstAsh.BaitaiCd.TYOUSA;
                //���f�B�A�t�B�[.
                case KkhConstAsh.BaitaiNm.MEDIA_FEE:
                    return KkhConstAsh.BaitaiCd.MEDIA_FEE;
                //�u�����h�Ǘ��t�B�[.
                case KkhConstAsh.BaitaiNm.BRAND_FEE:
                    return KkhConstAsh.BaitaiCd.BRAND_FEE;
                //���v.
                case KkhConstAsh.BaitaiNm.GOKEI:
                    return KkhConstAsh.BaitaiCd.GOKEI;
            }

            return string.Empty;
        }
        #endregion �C���f�b�N�X����}�̃R�[�h�擾.

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

        #region �f�[�^�o�C���h.
        /// <summary>
        /// �f�[�^�o�C���h.
        /// </summary>
        /// <param name="baitaiCd"></param>
        private void BindingSource(string baitaiCd)
        {
            //�����z�v�Z�p.
            double syoukeiKomi = 0;
            RepDsAsh.displayMediaChklstRow[] rows = (RepDsAsh.displayMediaChklstRow[])repDsMedia.displayMediaChklst.Select("Baitaicd =" + baitaiCd);

            //�Y���}�̂̃f�[�^���Ȃ�.
            if (rows.Length == 0)
            {
                txtSeiGak.Text = "0";
                medMain_Sheet1.Rows.Count = 0;
                lblKensu.Text = "0��";
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "���[", MessageBoxButtons.OK);
                return;
            }

            //�\���p�e�[�u��.
            RepDsAsh.displayMediaChklstDataTable dispTable = new RepDsAsh.displayMediaChklstDataTable();
            foreach (RepDsAsh.displayMediaChklstRow dispDr in rows)
            {
                //�����z�v�Z.
                syoukeiKomi += double.Parse(dispDr.seikyukinkomi);
                dispTable.ImportRow(dispDr);
            }

            //�����z�\��.
            txtSeiGak.Text = string.Format("{0:N0}", syoukeiKomi);

            //[������]���\��.
            medMain_Sheet1.Columns[9].Visible = true;

            //����.
            lblKensu.Text = rows.Length.ToString() + "��";

            //�X�v���b�h�f�[�^�\�[�X�֓����.
            medMain_Sheet1.DataSource = dispTable;
        }
        #endregion �f�[�^�o�C���h.

        #region ���v�쐬.
        /// <summary>
        /// ���v�쐬.
        /// </summary>
        private void MakeSum()
        {
            /* 2015/02/23 �A�T�q�Ή� JSE Miyanoue ADD Start */
            //�}�̃R�[�h�A�}�̖���.
            AshBaitaiUtility ashBaitaiUtility = new AshBaitaiUtility(_naviParam.strEsqId, _naviParam.strEgcd, _naviParam.strTksKgyCd, _naviParam.strTksBmnSeqNo, _naviParam.strTksTntSeqNo);
            List<AshBaitaiUtility.BaitaiResult> resultList = ashBaitaiUtility.GetNewBaitaiList();
            /* 2015/02/23 �A�T�q�Ή� JSE Miyanoue ADD End */

            int count = 0;
            decimal gokei = 0M;

            //�\���p�e�[�u��.
            RepDsAsh.displayMediaChklstDataTable dispTable = new RepDsAsh.displayMediaChklstDataTable();

            /* 2015/02/23 �A�T�q�Ή� JSE Miyanoue MOD Start */
            //for (int i = 0; i < baitaiCdArr.Length; i++)
            for (int i = 0; i < resultList.Count; i++)
            {
                double syoukeiKomi = 0;
                //RepDsAsh.displayMediaChklstRow[] rows = (RepDsAsh.displayMediaChklstRow[])repDsMedia.displayMediaChklst.Select("Baitaicd =" + baitaiCdArr[i]);
                RepDsAsh.displayMediaChklstRow[] rows = (RepDsAsh.displayMediaChklstRow[])repDsMedia.displayMediaChklst.Select("Baitaicd =" + resultList[i].baitaiCd);

                RepDsAsh.displayMediaChklstRow rows2 = (RepDsAsh.displayMediaChklstRow)dispTable.NewRow();

                //DataSet������.
                rows2 = dispSyokirowSet(rows2);
                //�}�̖�.
                //rows2.kenmei = baitaiNameArr[i];
                rows2.kenmei = resultList[i].baitaiNm;
                /* 2015/02/23 �A�T�q�Ή� JSE Miyanoue MOD End */

                //�ō�.
                rows2.seikyukinkomi = "0";

                //���R�[�h������}�̂͐ō��̍��v���Z�o.
                if (rows.Length > 0)
                {
                    // �����z�v�Z.
                    foreach (RepDsAsh.displayMediaChklstRow dispDr in rows)
                    {
                        syoukeiKomi += double.Parse(dispDr.seikyukinkomi);
                        //dispTable.ImportRow(dispDr);
                    }

                    //�������z�ō����Z�b�g.
                    rows2.seikyukinkomi = string.Format("{0:N0}", syoukeiKomi);
                    //���v.
                    gokei += decimal.Parse(rows2.seikyukinkomi);
                }

                //DataTable�ɒǉ�.
                dispTable.Rows.Add(rows2);
                count++;
            }

            //���v���z.
            txtSeiGak.Text = string.Format("{0:N0}", gokei);

            //����.
            lblKensu.Text = count + "��";

            //[������]���\��.
            medMain_Sheet1.Columns[9].Visible = false;

            //�X�v���b�h�f�[�^�\�[�X�֓����.
            medMain_Sheet1.DataSource = dispTable;
        }
        #endregion ���v�쐬.
        #endregion ���\�b�h.
    }
}