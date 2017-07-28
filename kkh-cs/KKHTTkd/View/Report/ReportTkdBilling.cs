using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using Isid.NJSecurity.Core;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;

using Isid.KKH.Tkd.ProcessController.Report;
using Isid.KKH.Tkd.Schema;
using Isid.KKH.Tkd.Utility;
using Isid.KKH.UserManual;

namespace Isid.KKH.Tkd.View.Report
{
    public partial class ReportTkdBilling : Isid.KKH.Common.KKHView.Common.Form.KKHForm
    {
        #region �萔

        /// <summary>
        /// XML�t�@�C����1.
        /// </summary>
        private const String REPORT_DATA_XML_FILENAME = "Tkd_Data.xml";

        /// <summary>
        /// XML�t�@�C����2.
        /// </summary>
        private const String REPORT_PROPERTY_XML_FILENAME = "Tkd_Prop.xml";

        /// <summary>
        /// �������ׁi�����ޕʁj���[�o�̓e���v���[�gExcel�t�@�C����.
        /// </summary>
        private const String REPORT_BY_MIDDLE_CLASSIFICATION_TEMPLATE_FILENAME = "TkdReportByMiddleClassification_Template.xlsx";

        /// <summary>
        /// �������ׁi�����ޕʁj���[�o�̓}�N������Excel�t�@�C����.
        /// </summary>
        private const String REPORT_BY_MIDDLE_CLASSIFICATION_MACRO_FILENAME = "TkdReportByMiddleClassification_Mcr.xlsm";

        /// <summary>
        /// �������ׁi�i�ڕʁj���[�o�̓e���v���[�gExcel�t�@�C����.
        /// </summary>
        private const String REPORT_BY_ITEM_TEMPLATE_FILENAME = "TkdReportByItem_Template.xlsx";

        /// <summary>
        /// �������ׁi�i�ڕʁj���[�o�̓}�N������Excel�t�@�C����.
        /// </summary>
        private const String REPORT_BY_ITEM_MACRO_FILENAME = "TkdReportByItem_Mcr.xlsm";

        /// <summary>
        /// �������ׁi����j���[�o�̓e���v���[�gExcel�t�@�C����.
        /// </summary>
        private const String REPORT_FOR_PLANNING_COST_TEMPLATE_FILENAME = "TkdReportForPlanningCost_Template.xlsx";

        /// <summary>
        /// �������ׁi����j���[�o�̓}�N������Excel�t�@�C����.
        /// </summary>
        private const String REPORT_FOR_PLANNING_COST_MACRO_FILENAME = "TkdReportForPlanningCost_Mcr.xlsm";

        /// <summary>
        /// �T�C�g120 or �T�C�g30
        /// </summary>
        private const int SITE_TYPE_120_OR_30 = 0;

        /// <summary>
        /// �T�C�g���̑�
        /// </summary>
        private const int SITE_TYPE_OTHER = 1;

        /// <summary>
        /// �e���r�ԑg�}�̃t�B�[
        /// </summary>
        private const String gstrTVFee = "FEE01";

        /// <summary>
        /// �e���r�X�|�b�g�}�̃t�B�[
        /// </summary>
        private const String gstrTVSpotFee = "FEE02";

        /// <summary>
        /// ����v���W�F�N�g�t�B�[
        /// </summary>
        private const String gstrSeisakuFee = "FEE16";

        /// <summary>
        /// Web����v���W�F�N�g�t�B�[
        /// </summary>
        private const String gstrWebFee = "FEE18";

        /// <summary>
        /// ���e�[�i�t�B�[
        /// </summary>
        private const String gstrRTFee = "FEE19";

        /// <summary>
        /// �v���W�F�N�g�t�B�[�v
        /// </summary>
        private const String gstrPJFee = "PJFEE";

        /// <summary>
        /// ����
        /// </summary>
        private const String gstrGenka = "1";

        /// <summary>
        /// �t�B�[
        /// </summary>
        private const String gstrFee = "2";

        /// <summary>
        /// �T�C�gNo120
        /// </summary>
        private const String gstrSite120 = "120";

        /// <summary>
        /// �T�C�gNo30
        /// </summary>
        private const String gstrSite30 = "30";

        /// <summary>
        /// ���v�^�C�g��
        /// </summary>
        private const String gstrOutSyoukei = "�� �v";

        /// <summary>
        /// ����ō��^�C�g��
        /// </summary>
        private const String gstrOutZeikomi = "(����ō���)";

        /// <summary>
        /// ���v�^�C�g��
        /// </summary>
        private const String gstrOutGoukei = "�� �v";

        /// <summary>
        /// ����Ń^�C�g��
        /// </summary>
        private const String gstrOutSyohizei = "�� �� ��";

        #endregion �萔

        #region �\����

        /// <summary>
        /// �����ޕʗp�N���X
        /// </summary>
        private class MiddleClassificationWorkData
        {
            public List<MiddleClassificationWorkSiteData> siteArray;

            public MiddleClassificationWorkData()
            {
                siteArray = new List<MiddleClassificationWorkSiteData>();
            }

            public int getHierarchicalCount()
            {
                int retval = 0;

                foreach (MiddleClassificationWorkSiteData i in siteArray )
                {
                    retval += i.getHierarchicalCount();
                }

                return retval;
            }
        };

        /// <summary>
        /// �����ޕʁ|�T�C�g�N���X
        /// </summary>
        private class MiddleClassificationWorkSiteData
        {
            /// <summary>
            /// �㗝�X�R�[�h
            /// </summary>
            public String strDairitenCD;

            /// <summary>
            /// ���{�N��
            /// </summary>
            public String strYM;

            /// <summary>
            /// �T�C�g
            /// </summary>
            public String strSite;

            /// <summary>
            /// �����ޏڍ׃f�[�^�N���X
            /// </summary>
            public List<MiddleClassificationWorkCYBNData> CYBNArray;

            public MiddleClassificationWorkSiteData()
            {
                CYBNArray = new List<MiddleClassificationWorkCYBNData>();
            }

            public int getHierarchicalCount()
            {
                int retval = 0;

                foreach (MiddleClassificationWorkCYBNData i in CYBNArray)
                {
                    retval += i.getHierarchicalCount();
                }

                return retval;
            }
        };

        /// <summary>
        /// �����ޕʁ|�����ރN���X
        /// </summary>
        private class MiddleClassificationWorkCYBNData
        {
            /// <summary>
            /// �}�̒����ރR�[�h
            /// </summary>
            public String strCYBNCD;

            /// <summary>
            /// �}�̒����ޖ�
            /// </summary>
            public String strCYBNNM;

            /// <summary>
            /// �����ތʔ}�̃f�[�^�N���X
            /// </summary>
            public List<MiddleClassificationWorkKBTData> KBTArray;

            public MiddleClassificationWorkCYBNData()
            {
                KBTArray = new List<MiddleClassificationWorkKBTData>();
            }

            public int getHierarchicalCount()
            {
                int retval = 0;

                foreach (MiddleClassificationWorkKBTData i in KBTArray)
                {
                    retval += i.getHierarchicalCount();
                }

                return retval;
            }
        };

        /// <summary>
        /// �����ޕʁ|�ʔ}�̃N���X
        /// </summary>
        private class MiddleClassificationWorkKBTData
        {
            /// <summary>
            /// �ʔ}�̖�
            /// </summary>
            public String strKBTNM;

            /// <summary>
            /// �ʔ}�̃R�[�h
            /// </summary>
            public String strKBTCD;

            /// <summary>
            /// ��A�ԍ�
            /// </summary>
            public String strRenNo;

            /// <summary>
            /// �ʔ}�̕i�ڃf�[�^�N���X
            /// </summary>
            public List<MiddleClassificationWorkHinmokuData> hinmokuArray;

            public MiddleClassificationWorkKBTData()
            {
                hinmokuArray = new List<MiddleClassificationWorkHinmokuData>();
            }

            public int getHierarchicalCount()
            {
                return hinmokuArray.Count;
            }
        };

        /// <summary>
        /// �����ޕʁ|�i�ڃN���X
        /// </summary>
        private class MiddleClassificationWorkHinmokuData
        {
            /// <summary>
            /// �i�ږ�
            /// </summary>
            public String strHinmokuNM;

            /// <summary>
            /// �i�ڃR�[�h
            /// </summary>
            public String strHinmokuCD;

            /// <summary>
            /// �Ǘ��敪
            /// </summary>
            public String strKanriKBN;

            /// <summary>
            /// �z���䗦
            /// </summary>
            public int intHaibunHiritsu;

            /// <summary>
            /// �z�t�z
            /// </summary>
            public Decimal curHaifugaku;

            /// <summary>
            /// �T�C�g
            /// </summary>
            public String strSite;

            /// <summary>
            /// ���l
            /// </summary>
            public String strBiko;
        };

        /// <summary>
        /// �i�ڕʗp�N���X
        /// </summary>
        private class ItemWorkData
        {
            public List<ItemWorkSiteData> siteArray;

            public ItemWorkData()
            {
                siteArray = new List<ItemWorkSiteData>();
            }

            public int getHierarchicalCount()
            {
                int retval = 0;

                foreach (ItemWorkSiteData i in siteArray)
                {
                    retval += i.getHierarchicalCount();
                }

                return retval;
            }
        };

        /// <summary>
        /// �i�ڕʁ|�T�C�g�N���X
        /// </summary>
        private class ItemWorkSiteData
        {
            /// <summary>
            /// �㗝�X�R�[�h
            /// </summary>
            public String strDairitenCD;

            /// <summary>
            /// ���{�N��
            /// </summary>
            public String strYM;

            /// <summary>
            /// �T�C�g
            /// </summary>
            public String strSite;

            /// <summary>
            /// �����ޏڍ׃f�[�^�N���X
            /// </summary>
            public List<ItemWorkCYBNData> CYBNArray;

            public ItemWorkSiteData()
            {
                CYBNArray = new List<ItemWorkCYBNData>();
            }

            public int getHierarchicalCount()
            {
                int retval = 0;

                foreach (ItemWorkCYBNData i in CYBNArray)
                {
                    retval += i.getHierarchicalCount();
                }

                return retval;
            }
        };

        /// <summary>
        /// �i�ڕʁ|�����ރN���X
        /// </summary>
        private class ItemWorkCYBNData
        {
            /// <summary>
            /// �}�̒����ރR�[�h
            /// </summary>
            public String strCYBNCD;

            /// <summary>
            /// �}�̒����ޖ�
            /// </summary>
            public String strCYBNNM;

            /// <summary>
            /// �ʔ}�̕i�ڃf�[�^�\����
            /// </summary>
            public List<ItemWorkHinmokuData> hinmokuArray;

            public ItemWorkCYBNData()
            {
                hinmokuArray = new List<ItemWorkHinmokuData>();
            }

            public int getHierarchicalCount()
            {
                return hinmokuArray.Count;
            }
        };

        /// <summary>
        /// �i�ڕʁ|�i�ڃN���X
        /// </summary>
        private class ItemWorkHinmokuData
        {
            /// <summary>
            /// �i�ږ�
            /// </summary>
            public String strHinmokuNM;

            /// <summary>
            /// �i�ڃR�[�h
            /// </summary>
            public String strHinmokuCD;

            /// <summary>
            /// �Ǘ��敪
            /// </summary>
            public String strKanriKBN;

            /// <summary>
            /// ���z
            /// </summary>
            public Decimal curKingaku;

            /// <summary>
            /// �ō��݋��z
            /// </summary>
            public Decimal curZeikomi;


            public String strFEECD;
        };

        /// <summary>
        /// ����|�W�v�p�N���X
        /// </summary>
        private class mtypHinmoku
        {
            public String Cd;
            public String Name;
            public Decimal Kingaku;
        };

        #endregion �\����

        #region �����o�ϐ�

        /// <summary>
        /// �Ăяo���p�����[�^(���)
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();

        /// <summary>
        /// ����ŗ�
        /// </summary>
        private Decimal _taxRate;

        /// <summary>
        /// �������ׁi�����ޕʁj�R�s�[�}�N���폜�pstring
        /// </summary>
        private String _strReportByMiddleClassificationMacroPath = null;

        /// <summary>
        /// �������ׁi�i�ڕʁj�R�s�[�}�N���폜�pstring
        /// </summary>
        private String _strReportByItemMacroPath = null;

        /// <summary>
        /// �������ׁi����j�R�s�[�}�N���폜�pstring
        /// </summary>
        private String _strReportForPlanningCostMacroPath = null;

        /// <summary>
        /// �ۑ���p(�e���v���[�g)�ϐ�
        /// </summary>
        private string strReportTempPath = "";

        /// <summary>
        /// �ۑ���p�ϐ�
        /// </summary>
        private string strReportDefaultPath = "";

        /// <summary>
        /// �������ׁi�����ޕʁj���[���i�ۑ��Ŏg�p�j�p�ϐ�
        /// </summary>
        private string strReportByMiddleClassificationFilename = "";

        /// <summary>
        /// �������ׁi�i�ځj���[���i�ۑ��Ŏg�p�j�p�ϐ�
        /// </summary>
        private string strReportByItemFilename = "";

        /// <summary>
        /// �������ׁi����j���[���i�ۑ��Ŏg�p�j�p�ϐ�
        /// </summary>
        private string strReportForPlanningCostFilename = "";

        /// <summary>
        /// �ێ��p�f�[�^�Z�b�g
        /// </summary>
        private DataSet putDataSet = null;

        /// <summary>
        /// �ێ��p����ŗ�
        /// </summary>
        private String putTaxRate = null;

        /// <summary>
        /// �ێ��p�c�ƓX�R�[�h
        /// </summary>
        private String putEGCD = null;

        /// <summary>
        /// �A�v��ID
        /// </summary>
        private string APLID = string.Empty;

        #endregion �����o�ϐ�

        # region �C�x���g
        /// <summary>
        /// �w���v�{�^���N���b�N���� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //���Ӑ�R�[�h 
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();

            //���s 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Report, this, HelpNavigator.KeywordIndex);

            this.ActiveControl = null;

        }

        /// <summary>
        /// ��ʂ��Ăяo���ꂽ���̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportTkdBilling_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            // �����ݒ�
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }

            // �V�[�g�\���E��\���ݒ� 
            dgvMain_Sheet1.Visible = true;
            dgvMain_Sheet2.Visible = false;
            dgvMain_Sheet3.Visible = false;

            // ���W�I�{�^���̏�����
            groupBox2.Enabled = true;
            radioButton3.Checked = true;
            radioButton1.Checked = true;

            // �X�e�[�^�X�̏�����
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            // ���{�N���̏�����
            initializeYYYYMM();

            // ����ŗ��̏�����
            initializeTaxRate();

            // �e���v���[�g�p�X�̏�����
            initializeTempPath();

            // ���[�o�͐�̏�����
            initializeOutputPath();
        }

        /// <summary>
        /// �\���{�^���������ꂽ���̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked && radioButton3.Checked)
            {
                loadReportByMiddleClassificationData();
            }
            else if (radioButton1.Checked && radioButton4.Checked)
            {
                loadReportByItemData();
            }
            else if (radioButton2.Checked)
            {
                loadReportForPlanningCostData();
            }

            //�I����Ԃ����� 
            this.ActiveControl = null;

        }

        /// <summary>
        /// �G�N�Z���{�^���������ꂽ���̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            APLID = string.Empty;
 
            if (radioButton1.Checked && radioButton3.Checked)
            {
                APLID = "RepMid";
                putReportByMiddleClassificationData();
            }
            else if (radioButton1.Checked && radioButton4.Checked)
            {
                APLID = "RepItm";
                putReportByItemData();
            }
            else if (radioButton2.Checked)
            {
                APLID = "RepPln";
                putReportForPlanningCostData();
            }

            //�I����Ԃ����� 
            this.ActiveControl = null;

        }

        /// <summary>
        /// �I���{�^���������ꂽ���̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            String[] stringArray = new String[]
            {
                _strReportByMiddleClassificationMacroPath,
                _strReportByItemMacroPath,
                _strReportForPlanningCostMacroPath
            };

            foreach (String i in stringArray)
            {
                // �������ׁi�����ޕʁj�R�s�[�}�N���̍폜
                if (i != null)
                {
                    System.IO.FileInfo cFileInfo = new System.IO.FileInfo(i);

                    // �}�N���t�@�C���̍폜�iVBA���ł͍폜�ł��Ȃ��ׁj

                    // �t�@�C�������݂��Ă��邩���f����
                    if (cFileInfo.Exists)
                    {
                        // �ǂݎ���p����������ꍇ�́A�ǂݎ���p��������������
                        if ((cFileInfo.Attributes & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly)
                        {
                            cFileInfo.Attributes = System.IO.FileAttributes.Normal;
                        }

                        // �t�@�C�����폜����
                        cFileInfo.Delete();
                    }
                }
            }

            Navigator.Backward(this, null, _naviParam, true);
        }

        /// <summary>
        /// �������ׂ̃��W�I�{�^���������ꂽ���̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            //[���[�o��]�{�^����񊈐��Ƃ��� 
            btnXls.Enabled = false;

            if (radioButton3.Checked == true)
            {
                activateReportByMiddleClassificationSheet();
            }
            else
            {
                activateReportByItemSheet();
            }
        }

        /// <summary>
        /// �������ׁi����j�̃��W�I�{�^���������ꂽ���̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            //[���[�o��]�{�^����񊈐��Ƃ��� 
            btnXls.Enabled = false;

            activateReportForPlanningCostSheet();
        }

        /// <summary>
        /// �����ޕʂ̃��W�I�{�^���������ꂽ���̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //[���[�o��]�{�^����񊈐��Ƃ��� 
            btnXls.Enabled = false;

            activateReportByMiddleClassificationSheet();
        }

        /// <summary>
        /// �i�ڕʕʂ̃��W�I�{�^���������ꂽ���̏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //[���[�o��]�{�^����񊈐��Ƃ��� 
            btnXls.Enabled = false;

            activateReportByItemSheet();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void condChg(object sender, EventArgs e)
        {
            //[���[�o��]�{�^����񊈐��Ƃ��� 
            btnXls.Enabled = false;
        }

        # endregion

        #region ���\�b�h

        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        public ReportTkdBilling()
        {
            InitializeComponent();
        }


        /// <summary>
        /// ���{�N��������������
        /// </summary>
        private void initializeYYYYMM()
        {
            CommonProcessController controller = CommonProcessController.GetInstance();

            String strDate = controller.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            //txtYm.Value = strDate.Substring(0, 6);
            if (strDate != "")
            {
                strDate = strDate.Trim().Replace("/", "");
                if (strDate.Trim().Length >= 6)
                {
                    txtYm.Value = strDate.Substring(0, 6);
                }
                else
                {
                    txtYm.Value = strDate;
                }
                txtYm.cmbYM_SetDate();
            }

        }

        /// <summary>
        /// ����ŗ�������������
        /// </summary>
        private void initializeTaxRate()
        {
            String taxString = KKHTkdUtility.GetTax(
                                                _naviParam.strEsqId,
                                                _naviParam.strEgcd,
                                                _naviParam.strTksKgyCd,
                                                _naviParam.strTksBmnSeqNo,
                                                _naviParam.strTksTntSeqNo
                                                );

            _taxRate = Decimal.Parse(taxString) / 100m;
        }

        /// <summary>
        /// �e���v���[�g�A�h���X������������
        /// </summary>
        private void initializeTempPath()
        {
            CommonProcessController controller = CommonProcessController.GetInstance();

            FindCommonByCondServiceResult result = controller.FindCommonByCond(
                                                                            _naviParam.strEsqId,
                                                                            _naviParam.strEgcd,
                                                                            _naviParam.strTksKgyCd,
                                                                            _naviParam.strTksBmnSeqNo,
                                                                            _naviParam.strTksTntSeqNo,
                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.MainType,
                                                                            "ED-I0001"
                                                                            );
            if (result.CommonDataSet.SystemCommon.Count != 0)
            {
                // �e���v���[�g�A�h���X
                strReportTempPath = result.CommonDataSet.SystemCommon[0].field2;
            }
        }

        /// <summary>
        /// ���[�ۑ��������������
        /// </summary>
        private void initializeOutputPath()
        {
            CommonProcessController controller = CommonProcessController.GetInstance();

            FindCommonByCondServiceResult result = controller.FindCommonByCond(
                                                                            _naviParam.strEsqId,
                                                                            _naviParam.strEgcd,
                                                                            _naviParam.strTksKgyCd,
                                                                            _naviParam.strTksBmnSeqNo,
                                                                            _naviParam.strTksTntSeqNo,
                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                            "001"
                                                                            );
            if (result.CommonDataSet.SystemCommon.Count != 0)
            {
                // �ۑ���
                strReportDefaultPath = result.CommonDataSet.SystemCommon[0].field2;

                // �������ׁi�����ޕʁj���̃Z�b�g
                strReportByMiddleClassificationFilename = result.CommonDataSet.SystemCommon[0].field3;

                // �������ׁi�i�ڕʁj���̃Z�b�g
                strReportByItemFilename = result.CommonDataSet.SystemCommon[0].field4;

                // �������ׁi����j���̃Z�b�g
                strReportForPlanningCostFilename = result.CommonDataSet.SystemCommon[0].field5;
            }
        }

        /// <summary>
        /// �������ׁi�����ޕʁj�̃X�v���b�h�V�[�g���A�N�e�B�u�ɂ���
        /// </summary>
        private void activateReportByMiddleClassificationSheet()
        {
            btnXls.Enabled = false;

            dgvMain_Sheet1.Visible = true;
            dgvMain_Sheet1.RowCount = 0;

            dgvMain_Sheet2.Visible = false;
            dgvMain_Sheet2.RowCount = 0;

            dgvMain_Sheet3.Visible = false;
            dgvMain_Sheet3.RowCount = 0;

            statusStrip1.Items["tslval1"].Text = "0��";
        }

        /// <summary>
        /// �������ׁi�i�ڕʁj�̃X�v���b�h�V�[�g���A�N�e�B�u�ɂ���
        /// </summary>
        private void activateReportByItemSheet()
        {
            btnXls.Enabled = false;

            dgvMain_Sheet1.Visible = false;
            dgvMain_Sheet1.RowCount = 0;

            dgvMain_Sheet2.Visible = true;
            dgvMain_Sheet2.RowCount = 0;

            dgvMain_Sheet3.Visible = false;
            dgvMain_Sheet3.RowCount = 0;

            statusStrip1.Items["tslval1"].Text = "0��";
        }

        /// <summary>
        /// �������ׁi����j�̃X�v���b�h�V�[�g���A�N�e�B�u�ɂ���
        /// </summary>
        private void activateReportForPlanningCostSheet()
        {
            btnXls.Enabled = false;

            dgvMain_Sheet1.Visible = false;
            dgvMain_Sheet1.RowCount = 0;

            dgvMain_Sheet2.Visible = false;
            dgvMain_Sheet2.RowCount = 0;

            dgvMain_Sheet3.Visible = true;
            dgvMain_Sheet3.RowCount = 0;

            statusStrip1.Items["tslval1"].Text = "0��";
        }


        /// <summary>
        /// �������ׁi�����ޕʁj�f�[�^�̓ǂݍ��ݏ��� 
        /// </summary>
        private void loadReportByMiddleClassificationData()
        {
            //���[�f�B���O�\���J�n 
            base.ShowLoadingDialog();

            // �N���̎擾 
            string strYYYYMM = txtYm.Value;

            // �v���Z�X�R���g���[���̎擾 
            ReportTkdBillingProcessController controller = ReportTkdBillingProcessController.GetInstance();

            // �{�f�[�^�̎擾 
            FindReportTkdBillingByMiddleClassificationByCondServiceResult resultMain = controller.FindReportTkdBillingByCond(
                                                                                      _naviParam.strEsqId,
                                                                                      _naviParam.strEgcd,
                                                                                      _naviParam.strTksKgyCd,
                                                                                      _naviParam.strTksBmnSeqNo,
                                                                                      _naviParam.strTksTntSeqNo,
                                                                                      strYYYYMM,
                                                                                      SITE_TYPE_120_OR_30.ToString()
                                                                                      );

            // ���̑��f�[�^�̎擾 
            FindReportTkdBillingByMiddleClassificationByCondServiceResult resultOther = controller.FindReportTkdBillingByCond(
                                                                                      _naviParam.strEsqId,
                                                                                      _naviParam.strEgcd,
                                                                                      _naviParam.strTksKgyCd,
                                                                                      _naviParam.strTksBmnSeqNo,
                                                                                      _naviParam.strTksTntSeqNo,
                                                                                      strYYYYMM,
                                                                                      SITE_TYPE_OTHER.ToString()
                                                                                      );

            // �f�[�^�����݂��Ȃ���ΏI�� 
            if ((resultMain.dsReportTkdBillingDataSet.ReportByMiddleClassificationResult.Rows.Count == 0) && (resultOther.dsReportTkdBillingDataSet.ReportByMiddleClassificationResult.Rows.Count == 0))
            {
                //���[�f�B���O�\���I�� 
                base.CloseLoadingDialog();

                btnXls.Enabled = false;

                dgvMain_Sheet1.RowCount = 0;

                statusStrip1.Items["tslval1"].Text = "0��";

                //MessageBox.Show("�Y���̃f�[�^�͑��݂��܂���B", "���[", MessageBoxButtons.OK);
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "���[", MessageBoxButtons.OK);

                return;
            }

            // ���[�N�p�f�[�^�̐��� 
            MiddleClassificationWorkData work = new MiddleClassificationWorkData();

            // �{�f�[�^�̕ҏW 
            putReportByMiddleClassificationWorkData(resultMain, work, SITE_TYPE_120_OR_30);

            // ���̑��f�[�^�̕ҏW 
            putReportByMiddleClassificationWorkData(resultOther, work, SITE_TYPE_OTHER);

            // ��ʂւ̏o�� 
            putReportByMiddleClassificationView(work);

            // ���[�f�[�^�Z�b�g�ւ̏o�� 
            putReportByMiddleClassificationMacroData(work);

            //���[�f�B���O�\���I�� 
            base.CloseLoadingDialog();

        }

        /// <summary>
        /// �������ׁi�����ޕʁj�W�v�p�f�[�^�̕ҏW
        /// </summary>
        /// <param name="resultMain"></param>
        /// <param name="work">�������ׁi�����ޕʁj�W�v�Ώۃ��[�N</param>
        /// <param name="siteType">�W�v����T�C�g�̃p�^�[��</param>
        private static void putReportByMiddleClassificationWorkData(FindReportTkdBillingByMiddleClassificationByCondServiceResult resultMain, MiddleClassificationWorkData work, int siteType )
        {
            String strWorkSite;     // �O���R�[�h��r:�p�T�C�g
            Boolean blnKYTFlg;      // ���ʏ��t���O
            String strWorkCYBNCD;   // �O���R�[�h��r:�p�}�̒����ރR�[�h
            String strWorkKBTCD;    // �O���R�[�h��r:�p�ʔ}�̃R�[�h
            String strWorkJSSNO;    // �O���R�[�h��r:���{No

            // �J�E���^�̏�����
            strWorkSite = null;
            blnKYTFlg = false;
            strWorkCYBNCD = null;
            strWorkKBTCD = null;
            strWorkJSSNO = null;

            MiddleClassificationWorkSiteData siteItem = null;
            MiddleClassificationWorkCYBNData CYBNItem = null;
            MiddleClassificationWorkKBTData KBTItem = null;
            MiddleClassificationWorkHinmokuData hinmokuItem = null;

            ReportDSTkdBilling.ReportByMiddleClassificationResultRow[] resultRows = (ReportDSTkdBilling.ReportByMiddleClassificationResultRow[])resultMain.dsReportTkdBillingDataSet.ReportByMiddleClassificationResult.Select("", "");

            foreach (ReportDSTkdBilling.ReportByMiddleClassificationResultRow resultRow in resultRows)
            {
                // �o�͒����ރf�[�^�\���̏�����& �f�[�^�̊i�[
                if (siteType == SITE_TYPE_120_OR_30)
                {
                    // �T�C�g��120��30�̏ꍇ
                    if (!String.Equals(strWorkSite, resultRow.strSite.Trim()))
                    {
                        siteItem = new MiddleClassificationWorkSiteData();
                        work.siteArray.Add(siteItem);

                        // �㗝�X�R�[�h
                        siteItem.strDairitenCD = "";

                        if (resultRow.IsstrDairitenCDNull() == false)
                        {
                            siteItem.strDairitenCD = resultRow.strDairitenCD.Trim();
                        }

                        // ���{�N��
                        siteItem.strYM = "";

                        if (resultRow.IsstrYMNull() == false)
                        {
                            siteItem.strYM = resultRow.strYM.Trim();
                        }

                        // �T�C�g
                        siteItem.strSite = "";

                        if (resultRow.IsstrSiteNull() == false)
                        {
                            siteItem.strSite = resultRow.strSite.Trim();
                        }

                        // �J�E���^���Z�b�g
                        strWorkSite = siteItem.strSite;
                        strWorkCYBNCD = null;
                        strWorkKBTCD = null;
                        strWorkJSSNO = null;
                    }
                }
                else
                {
                    // �T�C�g��120�ł�30�ł��Ȃ��ꍇ
                    if (blnKYTFlg == false)
                    {
                        siteItem = new MiddleClassificationWorkSiteData();
                        work.siteArray.Add(siteItem);

                        // �㗝�X�R�[�h
                        siteItem.strDairitenCD = "";

                        if (resultRow.IsstrDairitenCDNull() == false)
                        {
                            siteItem.strDairitenCD = resultRow.strDairitenCD.Trim();
                        }

                        // ���{�N��
                        siteItem.strYM = "";

                        if (resultRow.IsstrYMNull() == false)
                        {
                            siteItem.strYM = resultRow.strYM.Trim();
                        }

                        // �T�C�g
                        siteItem.strSite = "���̑�";

                        // �J�E���^���Z�b�g
                        blnKYTFlg = true;
                        strWorkCYBNCD = null;
                        strWorkKBTCD = null;
                        strWorkJSSNO = null;
                    }
                }

                // �o�͒����ޏڍ׃f�[�^�\���̏�����& �f�[�^�̊i�[
                if (!String.Equals(strWorkCYBNCD, resultRow.strCYBNCD.Trim()))
                {
                    CYBNItem = new MiddleClassificationWorkCYBNData();
                    siteItem.CYBNArray.Add(CYBNItem);

                    // �}�̒����ރR�[�h
                    CYBNItem.strCYBNCD = "";

                    if (resultRow.IsstrCYBNCDNull() == false)
                    {
                        CYBNItem.strCYBNCD = resultRow.strCYBNCD.Trim();
                    }

                    // �}�̒����ޖ�
                    CYBNItem.strCYBNNM = "";

                    if (resultRow.IsstrCYBNNMNull() == false)
                    {
                        CYBNItem.strCYBNNM = resultRow.strCYBNNM.Trim();
                    }

                    strWorkCYBNCD = CYBNItem.strCYBNCD;
                    strWorkKBTCD = null;
                    strWorkJSSNO = null;
                }

                // �ʔ}�̃f�[�^�\���̏�����& �f�[�^�̊i�[
                if ((!String.Equals(strWorkKBTCD, resultRow.strKBTCD.Trim())) || (!String.Equals(strWorkJSSNO, resultRow.RENNO.Trim())))
                {
                    // �}�̃��R�[�h���A����v���W�F�N�g�t�B�[/Web����v���W�F�N�g�t�B�[�̏ꍇ
                    KBTItem = new MiddleClassificationWorkKBTData();
                    CYBNItem.KBTArray.Add(KBTItem);

                    // �ʔ}�̖�
                    KBTItem.strKBTNM = "";

                    if (resultRow.IsstrKBTNMNull() == false)
                    {
                        KBTItem.strKBTNM = resultRow.strKBTNM.Trim();
                    }

                    // �ʔ}�̃R�[�h
                    KBTItem.strKBTCD = "";

                    if (resultRow.IsstrKBTCDNull() == false)
                    {
                        KBTItem.strKBTCD = resultRow.strKBTCD.Trim();
                    }

                    // ��A�ԍ�
                    KBTItem.strRenNo = "";

                    if (resultRow.IsRENNONull() == false)
                    {
                        KBTItem.strRenNo = resultRow.RENNO.Trim();
                    }

                    strWorkKBTCD = KBTItem.strKBTCD;
                    strWorkJSSNO = KBTItem.strRenNo;
                }

                // �i�ڃf�[�^�\���̏�����& �f�[�^�̊i�[
                hinmokuItem = new MiddleClassificationWorkHinmokuData();
                KBTItem.hinmokuArray.Add(hinmokuItem);

                // �i�ږ�
                hinmokuItem.strHinmokuNM = "";

                if (resultRow.IsstrHinmokuNMNull() == false)
                {
                    hinmokuItem.strHinmokuNM = resultRow.strHinmokuNM.Trim();
                }

                // �i�ڃR�[�h
                hinmokuItem.strHinmokuCD = "";

                if (resultRow.IsstrHinmokuCDNull() == false)
                {
                    hinmokuItem.strHinmokuCD = resultRow.strHinmokuCD.Trim();
                }

                // �Ǘ��敪
                hinmokuItem.strKanriKBN = "";

                if (resultRow.IsstrKanriKBNNull() == false)
                {
                    hinmokuItem.strKanriKBN = resultRow.strKanriKBN.Trim();
                }

                // �z���䗦
                hinmokuItem.intHaibunHiritsu = 0;

                if (resultRow.IsintHaibunHiritsuNull() == false)
                {
                    hinmokuItem.intHaibunHiritsu = (int)( Decimal.Parse(resultRow.intHaibunHiritsu.Trim()) * 10m );
                }

                // �z�t�z
                hinmokuItem.curHaifugaku = 0.0m;

                if (resultRow.IscurHaifugakuNull() == false)
                {
                    hinmokuItem.curHaifugaku = Decimal.Parse(resultRow.curHaifugaku.Trim());
                }

                // �T�C�g
                hinmokuItem.strSite = "";

                if (resultRow.IsstrSiteNull() == false)
                {
                    hinmokuItem.strSite = String.Format("{0:00}", resultRow.strSite.Trim());
                }

                // ���l
                hinmokuItem.strBiko = "";

                if (resultRow.IsstrBikoNull() == false)
                {
                    hinmokuItem.strBiko = resultRow.strBiko.Trim();
                }
            }
        }

        /// <summary>
        /// �������ׁi�����ޕʁj��ʏo�͗p�f�[�^�̕ҏW
        /// </summary>
        /// <param name="work">�������ׁi�����ޕʁj�W�v�ς݃��[�N</param>
        private void putReportByMiddleClassificationView(MiddleClassificationWorkData work)
        {
            // ��ʏo�͗p�f�[�^�X�L�[�}�̐��� 
            ReportDSTkdBilling view = new ReportDSTkdBilling();

            Decimal lcurSougaku;    // ���z 
            Decimal lcurSyoukei;    // ���v 
            Decimal lcurGoukei;     // ���v 
            Decimal lcurPrjFee;     // �v���W�F�N�g�t�B�[ 
            Boolean blnWEBSSFlg;    // Web����/����o�̓t���O 

            lcurSougaku = 0;
            lcurSyoukei = 0;
            lcurGoukei = 0;
            lcurPrjFee = 0;

            // ���׍s�o�͗p 
            ReportDSTkdBilling.ReportByMiddleClassificationViewRow viewRow = view.ReportByMiddleClassificationView.NewReportByMiddleClassificationViewRow();

            foreach (MiddleClassificationWorkSiteData siteItem in work.siteArray)
            {
                //  �T�C�g
                viewRow.cCHSite = siteItem.strSite;
                //  �㗝�X��
                viewRow.cCDairinm = "�d��";
                //  �㗝�X�R�[�h
                viewRow.cCDairicd = siteItem.strDairitenCD;
                //  ���{�N��
                viewRow.cCym = siteItem.strYM;

                foreach (MiddleClassificationWorkCYBNData CYBNItem in siteItem.CYBNArray)
                {
                    //  ���o�͒����ޏڍ׃f�[�^
                    //  �}�̒����ރR�[�h
                    viewRow.cCBtccd = CYBNItem.strCYBNCD;
                    //  �}�̒����ޖ�
                    viewRow.cCBtcnm = CYBNItem.strCYBNNM;

                    //  �o�̓t���O�̏�����
                    lcurPrjFee = 0;
                    blnWEBSSFlg = false;

                    foreach (MiddleClassificationWorkKBTData KBTItem in CYBNItem.KBTArray)
                    {
                        // ���z�p
                        ReportDSTkdBilling.ReportByMiddleClassificationViewRow itemTotalRow = viewRow;

                        //  ���ʔ}�̃f�[�^
                        if (!String.Equals(KBTItem.strKBTCD, gstrRTFee))
                        {
                            //  �����e�[�i�t�B�[�́A�ʔ}�̖��A�ʔ}�̃R�[�h�A��A�ԍ��͏o�͂��Ȃ���
                            //  �ʔ}�̖�
                            viewRow.cCBtkbtnm = KBTItem.strKBTNM;
                            //  �e�}�̃A�N�V����
                            if (String.Equals(KBTItem.strKBTCD, gstrSeisakuFee) || String.Equals(KBTItem.strKBTCD, gstrWebFee))
                            {
                                //  ������/Web����̃t�B�[�̏ꍇ
                                //  ��A�ԍ�
                                viewRow.cCIchirenno = KBTItem.strRenNo;
                            }
                            else if ((!String.Equals(KBTItem.strKBTCD, gstrTVFee)) && (!String.Equals(KBTItem.strKBTCD, gstrTVSpotFee)))
                            {
                                //  ���e���r�n�t�B�[�ȊO�̏ꍇ
                                //  �ʔ}�̃R�[�h
                                viewRow.cCBtkbtcd = KBTItem.strKBTCD;
                                //  ��A�ԍ�
                                viewRow.cCIchirenno = KBTItem.strRenNo;
                            }
                        }

                        foreach (MiddleClassificationWorkHinmokuData hinmokuItem in KBTItem.hinmokuArray)
                        {
                            //  ���ʔ}�̕i�ڃf�[�^�\����
                            if ((!String.Equals(hinmokuItem.strKanriKBN, gstrFee)))
                            {
                                //  ���Ǘ��敪��1(����)�̏ꍇ��
                                //  �i�ږ�
                                viewRow.cCHinmokunm = hinmokuItem.strHinmokuNM;
                                //  �i�ڃR�[�h
                                viewRow.cCHinmokucd = hinmokuItem.strHinmokuCD;
                                //  �Ǘ��敪
                                viewRow.cCKanrikbn = hinmokuItem.strKanriKBN;

                                if ((KBTItem.hinmokuArray.Count > 1) && (hinmokuItem.intHaibunHiritsu < 1000))
                                {
                                    //  �i�ڂ�1��񂵂��Ȃ��Ȃ�A�z���䗦�A�z�t�z�͕\�����Ȃ�
                                    //  �z���䗦
                                    viewRow.cCHaibun = (hinmokuItem.intHaibunHiritsu).ToString();
                                    //  �z�t�z
                                    viewRow.cCHaifugaku = (hinmokuItem.curHaifugaku).ToString();
                                }

                                //  �T�C�g
                                viewRow.cCSite = hinmokuItem.strSite;
                                //  ���l
                                viewRow.cCBiko = hinmokuItem.strBiko;
                                //  �����z�v�Z��
                                lcurSougaku = lcurSougaku + hinmokuItem.curHaifugaku;
                            }
                            else
                            {
                                //  ���Ǘ��敪��2(�t�B�[)�̏ꍇ��
                                if (String.Equals(KBTItem.strKBTCD, gstrSeisakuFee) || String.Equals(KBTItem.strKBTCD, gstrWebFee))
                                {
                                    //  �����ނ�����/Web����̏ꍇ�́A�t�B�[��񏈗�

                                    //  �Ǘ��敪
                                    viewRow.cCKanrikbn = hinmokuItem.strKanriKBN;
                                    //  �i�ږ�
                                    viewRow.cCHinmokunm = hinmokuItem.strHinmokuNM;
                                    //  �i�ڃR�[�h
                                    viewRow.cCHinmokucd = hinmokuItem.strHinmokuCD;
                                    //  �t�B�[�R�[�h
                                    viewRow.cCFee = KBTItem.strKBTCD;
                                    //  ���v���W�F�N�g�t�B�[�̑��z�v�Z
                                    lcurPrjFee = lcurPrjFee + hinmokuItem.curHaifugaku;
                                    //  Web����/����̏o�̓t���O
                                    blnWEBSSFlg = true;
                                }
                                else if (((String.Equals(KBTItem.strKBTCD, gstrTVFee))) || ((String.Equals(KBTItem.strKBTCD, gstrTVSpotFee))))
                                {
                                    //  �����ނ��e���r�ԑg/�e���r�X�|�b�g�̏ꍇ�́A�t�B�[��񏈗�

                                    //  �Ǘ��敪
                                    viewRow.cCKanrikbn = hinmokuItem.strKanriKBN;
                                    //  �t�B�[�R�[�h
                                    viewRow.cCFee = KBTItem.strKBTCD;
                                }
                                else if (String.Equals(KBTItem.strKBTCD, gstrRTFee))
                                {
                                    //  ���z 
                                    viewRow.cCSougaku = (hinmokuItem.curHaifugaku).ToString();
                                    //  �i�ږ� 
                                    viewRow.cCHinmokunm = hinmokuItem.strHinmokuNM;
                                    //  �i�ڃR�[�h 
                                    viewRow.cCHinmokucd = hinmokuItem.strHinmokuCD;
                                    //  �Ǘ��敪 
                                    viewRow.cCKanrikbn = hinmokuItem.strKanriKBN;
                                    //  ���l 
                                    viewRow.cCBiko = hinmokuItem.strBiko;
                                    //  �t�B�[�R�[�h 
                                    viewRow.cCFee = KBTItem.strKBTCD;
                                }

                                //  �����z�v�Z�� 
                                lcurSougaku = lcurSougaku + hinmokuItem.curHaifugaku;
                            }

                            // ���׍s�̒ǉ� 
                            view.ReportByMiddleClassificationView.AddReportByMiddleClassificationViewRow(viewRow);
                            viewRow = view.ReportByMiddleClassificationView.NewReportByMiddleClassificationViewRow();
                        }

                        if (!String.Equals(KBTItem.strKBTCD, gstrRTFee))
                        {
                            // �ʃ��R�[�h�����ɕi�ڕʂ̍��v���o�͂���C���M�����[�ȏ����̂��߂��̏ꏊ�ɋL�ڂ���
                            itemTotalRow.cCSougaku = (lcurSougaku).ToString();
                        }

                        //  �����v�v�Z�� 
                        lcurSyoukei = lcurSyoukei + lcurSougaku;

                        //  ���z������ 
                        lcurSougaku = 0;
                    }

                    if ((lcurPrjFee != 0) && (blnWEBSSFlg == true))
                    {
                        //  ������/Web����̃v���W�F�N�g�t�B�[�v
                        viewRow.cCBtkbtnm = "�v���W�F�N�g�t�B�[�v";
                        viewRow.cCSougaku = (lcurPrjFee).ToString();
                        viewRow.cCFee = gstrPJFee;

                        // ���׍s�̒ǉ� 
                        view.ReportByMiddleClassificationView.AddReportByMiddleClassificationViewRow(viewRow);
                        viewRow = view.ReportByMiddleClassificationView.NewReportByMiddleClassificationViewRow();
                    }

                    //  ���v 
                    viewRow.cCBtcnm = gstrOutSyoukei;
                    viewRow.cCSougaku = (lcurSyoukei).ToString();

                    //  ���v�s�̒ǉ� 
                    view.ReportByMiddleClassificationView.AddReportByMiddleClassificationViewRow(viewRow);
                    viewRow = view.ReportByMiddleClassificationView.NewReportByMiddleClassificationViewRow();

                    //  ���v(����ō���)
                    viewRow.cCBtcnm = gstrOutZeikomi;
                    viewRow.cCSougaku = (lcurSyoukei + (lcurSyoukei * _taxRate)).ToString();

                    //  ���v(����ō���)�s�̒ǉ�
                    view.ReportByMiddleClassificationView.AddReportByMiddleClassificationViewRow(viewRow);
                    viewRow = view.ReportByMiddleClassificationView.NewReportByMiddleClassificationViewRow();

                    //  �����v�v�Z��
                    lcurGoukei = lcurGoukei + lcurSyoukei;

                    //  ���v������
                    lcurSyoukei = 0;
                }

                //  ���v 
                viewRow.cCBtccd = gstrOutGoukei;
                viewRow.cCSougaku = (lcurGoukei).ToString();

                //  ���v�s�̒ǉ� 
                view.ReportByMiddleClassificationView.AddReportByMiddleClassificationViewRow(viewRow);
                viewRow = view.ReportByMiddleClassificationView.NewReportByMiddleClassificationViewRow();

                //  ���v(����ō���) 
                viewRow.cCBtccd = gstrOutZeikomi;
                viewRow.cCSougaku = (lcurGoukei + (lcurGoukei * _taxRate)).ToString();

                //  ���v(����ō���)�s�̒ǉ� 
                view.ReportByMiddleClassificationView.AddReportByMiddleClassificationViewRow(viewRow);
                viewRow = view.ReportByMiddleClassificationView.NewReportByMiddleClassificationViewRow();

                lcurGoukei = 0;

                // �󔒍s�̒ǉ� 
                view.ReportByMiddleClassificationView.AddReportByMiddleClassificationViewRow(viewRow);
                viewRow = view.ReportByMiddleClassificationView.NewReportByMiddleClassificationViewRow();
            }

            dgvMain_Sheet1.RowCount = 0;

            dgvMain_Sheet1.DataSource = view.ReportByMiddleClassificationView;

            statusStrip1.Items["tslval1"].Text = work.getHierarchicalCount().ToString() + "��";
        }

        /// <summary>
        /// �������ׁi�����ޕʁj���[�o�͗p�f�[�^�̕ҏW 
        /// </summary>
        /// <param name="work">�������ׁi�����ޕʁj�W�v�ς݃��[�N</param>
        private void putReportByMiddleClassificationMacroData(MiddleClassificationWorkData work)
        {
            // ���[�o�͗p�f�[�^�X�L�[�}�̐��� 
            ReportDSTkdBilling macro = new ReportDSTkdBilling();

            foreach (MiddleClassificationWorkSiteData siteItem in work.siteArray)
            {
                foreach (MiddleClassificationWorkCYBNData CYBNItem in siteItem.CYBNArray)
                {
                    foreach (MiddleClassificationWorkKBTData KBTItem in CYBNItem.KBTArray)
                    {
                        foreach (MiddleClassificationWorkHinmokuData hinmokuItem in KBTItem.hinmokuArray)
                        {
                            ReportDSTkdBilling.ReportByMiddleClassificationMacroRow macroRow = macro.ReportByMiddleClassificationMacro.NewReportByMiddleClassificationMacroRow();

                            // �T�C�g�ʃf�[�^
                            macroRow.strDairitenCD = siteItem.strDairitenCD;                        // �㗝�X�R�[�h
                            macroRow.strYM = siteItem.strYM;			                            // ���{�N��
                            macroRow.strSite = siteItem.strSite;			                        // �T�C�g

                            // �����ޕʃf�[�^
                            macroRow.strCYBNCD = CYBNItem.strCYBNCD;			                    // �}�̒����ރR�[�h
                            macroRow.strCYBNNM = CYBNItem.strCYBNNM;			                    // �}�̒����ޖ�

                            // �ʔ}�̕ʃf�[�^
                            macroRow.strKBTNM = KBTItem.strKBTNM;			                        // �ʔ}�̖�
                            macroRow.strKBTCD = KBTItem.strKBTCD;			                        // �ʔ}�̃R�[�h
                            macroRow.strRenNo = KBTItem.strRenNo;			                        // ��A�ԍ�

                            // �i�ڕʃf�[�^
                            macroRow.strHinmokuNM = hinmokuItem.strHinmokuNM;		            	// �i�ږ�
                            macroRow.strHinmokuCD = hinmokuItem.strHinmokuCD;		            	// �i�ڃR�[�h
                            macroRow.strKanriKBN = hinmokuItem.strKanriKBN;		            	    // �Ǘ��敪
                            macroRow.intHaibunHiritsu = hinmokuItem.intHaibunHiritsu.ToString();    // �z���䗦
                            macroRow.curHaifugaku = hinmokuItem.curHaifugaku.ToString();			// �z�t�z
                            macroRow.strSite = hinmokuItem.strSite;			                        // �T�C�g
                            macroRow.strBiko = hinmokuItem.strBiko;			                        // ���l

                            // �T�C�g�ʃL�[����
                            if (work.siteArray.IndexOf(siteItem) == 0)
                            {
                                macroRow.keyCountSite = work.siteArray.Count.ToString();
                            }

                            // �����ޕʃL�[����
                            if (siteItem.CYBNArray.IndexOf(CYBNItem) == 0)
                            {
                                macroRow.keyCountCYBN = siteItem.CYBNArray.Count.ToString();
                            }

                            // �ʔ}�̕ʃL�[����
                            if (CYBNItem.KBTArray.IndexOf(KBTItem) == 0)
                            {
                                macroRow.keyCountKBT = CYBNItem.KBTArray.Count.ToString();
                            }

                            // �i�ڕʃL�[����
                            if (KBTItem.hinmokuArray.IndexOf(hinmokuItem) == 0)
                            {
                                macroRow.keyCountHinmoku = KBTItem.hinmokuArray.Count.ToString();
                            }

                            macro.ReportByMiddleClassificationMacro.AddReportByMiddleClassificationMacroRow(macroRow);
                        }
                    }
                }
            }

            putDataSet = macro;
            putTaxRate = _taxRate.ToString();
            btnXls.Enabled = true;
        }

        /// <summary>
        /// �������ׁi�i�ڕʁj�f�[�^�̓ǂݍ��ݏ��� 
        /// </summary>
        private void loadReportByItemData()
        {
            //���[�f�B���O�\���J�n 
            base.ShowLoadingDialog();

            // �N���̎擾 
            string strYYYYMM = txtYm.Value;

            // �v���Z�X�R���g���[���̎擾 
            ReportTkdBillingProcessController controller = ReportTkdBillingProcessController.GetInstance();

            // �{�f�[�^�̎擾 
            FindReportTkdBillingByItemByCondServiceResult resultMain = controller.FindReportTkdBillingByItemByCond(
                                                                                      _naviParam.strEsqId,
                                                                                      _naviParam.strEgcd,
                                                                                      _naviParam.strTksKgyCd,
                                                                                      _naviParam.strTksBmnSeqNo,
                                                                                      _naviParam.strTksTntSeqNo,
                                                                                      strYYYYMM,
                                                                                      SITE_TYPE_120_OR_30.ToString()
                                                                                      );

            // ���̑��f�[�^�̎擾 
            FindReportTkdBillingByItemByCondServiceResult resultOther = controller.FindReportTkdBillingByItemByCond(
                                                                                      _naviParam.strEsqId,
                                                                                      _naviParam.strEgcd,
                                                                                      _naviParam.strTksKgyCd,
                                                                                      _naviParam.strTksBmnSeqNo,
                                                                                      _naviParam.strTksTntSeqNo,
                                                                                      strYYYYMM,
                                                                                      SITE_TYPE_OTHER.ToString()
                                                                                      );

            // �f�[�^�����݂��Ȃ���ΏI�� 
            if ((resultMain.dsReportTkdBillingDataSet.ReportByItemResult.Rows.Count == 0) && (resultOther.dsReportTkdBillingDataSet.ReportByItemResult.Rows.Count == 0))
            {
                //���[�f�B���O�\���I�� 
                base.CloseLoadingDialog();

                btnXls.Enabled = false;

                dgvMain_Sheet2.RowCount = 0;

                statusStrip1.Items["tslval1"].Text = "0��";

                //MessageBox.Show("�Y���̃f�[�^�͑��݂��܂���B", "���[", MessageBoxButtons.OK);
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "���[", MessageBoxButtons.OK);

                return;
            }

            // ���[�N�p�f�[�^�̐��� 
            ItemWorkData work = new ItemWorkData();

            // �{�f�[�^�̃}�b�s���O 
            putReportByItemWorkData(resultMain, work, SITE_TYPE_120_OR_30);

            // ���̑��f�[�^�̃}�b�s���O 
            putReportByItemWorkData(resultOther, work, SITE_TYPE_OTHER);

            // ��ʂւ̏o�� 
            putReportByItemView(work);

            // ���[�o�͗p�f�[�^�̕ҏW 
            putReportByItemMacroData(work);

            //���[�f�B���O�\���I�� 
            base.CloseLoadingDialog();

        }

        /// <summary>
        /// �������ׁi�i�ڕʁj�W�v�p�f�[�^�̕ҏW 
        /// </summary>
        /// <param name="resultMain"></param>
        /// <param name="work">�������ׁi�i�ڕʁj�W�v�Ώۃ��[�N</param>
        /// <param name="siteType">�W�v����T�C�g�̃p�^�[��</param>
        private void putReportByItemWorkData(FindReportTkdBillingByItemByCondServiceResult resultMain, ItemWorkData work, int siteType)
        {
            String strWorkSite;     // �T�C�g�ޔ� 
            Boolean blnKYTFlg;      // ���ʏ��t���O 
            String strWorkCYBNCD;   // �����ރR�[�h�ޔ� 

            // �J�E���^������ 
            strWorkSite = null;
            blnKYTFlg = false;
            strWorkCYBNCD = null;

            ItemWorkSiteData siteItem = null;
            ItemWorkCYBNData CYBNItem = null;
            ItemWorkHinmokuData hinmokuItem = null;

            ReportDSTkdBilling.ReportByItemResultRow[] resultRows = (ReportDSTkdBilling.ReportByItemResultRow[])resultMain.dsReportTkdBillingDataSet.ReportByItemResult.Select("", "");

            foreach (ReportDSTkdBilling.ReportByItemResultRow resultRow in resultRows)
            {
                // �T�C�g�f�[�^�\���̏�����& �f�[�^�̊i�[ 
                if (siteType == SITE_TYPE_120_OR_30)
                {
                    // �T�C�g��120��30�̏ꍇ 
                    if (!String.Equals(strWorkSite, resultRow.SITE.Trim()))
                    {
                        // �o�͒����ރf�[�^�\���̏�����& �f�[�^�̊i�[ 
                        siteItem = new ItemWorkSiteData();
                        work.siteArray.Add(siteItem);

                        // �T�C�g 
                        siteItem.strSite = "";

                        if (resultRow.IsSITENull() == false)
                        {
                            siteItem.strSite = resultRow.SITE.Trim();
                        }

                        // �㗝�X�R�[�h 
                        siteItem.strDairitenCD = "";

                        if (resultRow.IsstrDairitenCDNull() == false)
                        {
                            siteItem.strDairitenCD = resultRow.strDairitenCD.Trim();
                        }

                        // ���{�N�� 
                        siteItem.strYM = "";

                        if (resultRow.IsstrYMNull() == false)
                        {
                            siteItem.strYM = resultRow.strYM.Trim();
                        }

                        strWorkSite = siteItem.strSite;
                        strWorkCYBNCD = null;
                    }
                }
                else
                {
                    // �T�C�g��120�ł�30�ł��Ȃ��ꍇ
                    if (blnKYTFlg == false)
                    {
                        // �o�͒����ރf�[�^�\���̏�����& �f�[�^�̊i�[
                        siteItem = new ItemWorkSiteData();
                        work.siteArray.Add(siteItem);

                        // �T�C�g
                        siteItem.strSite = "���̑�";

                        // �㗝�X�R�[�h
                        siteItem.strDairitenCD = "";

                        if (resultRow.IsstrDairitenCDNull() == false)
                        {
                            siteItem.strDairitenCD = resultRow.strDairitenCD.Trim();
                        }

                        // ���{�N��
                        siteItem.strYM = "";

                        if (resultRow.IsstrYMNull() == false)
                        {
                            siteItem.strYM = resultRow.strYM.Trim();
                        }

                        blnKYTFlg = true;
                        strWorkCYBNCD = null;
                    }
                }

                // �����ޏڍ׃f�[�^�\���̏�����& �f�[�^�̊i�[
                if (!String.Equals(strWorkCYBNCD, resultRow.strCYBNCD.Trim()))
                {
                    CYBNItem = new ItemWorkCYBNData();
                    siteItem.CYBNArray.Add(CYBNItem);

                    // �}�̒����ރR�[�h
                    CYBNItem.strCYBNCD = "";

                    if (resultRow.IsstrCYBNCDNull() == false)
                    {
                        CYBNItem.strCYBNCD = resultRow.strCYBNCD.Trim();
                    }

                    // �}�̒����ޖ�
                    CYBNItem.strCYBNNM = "";

                    if (resultRow.IsstrCYBNNMNull() == false)
                    {
                        CYBNItem.strCYBNNM = resultRow.strCYBNNM.Trim();
                    }

                    strWorkCYBNCD = CYBNItem.strCYBNCD;
                }

                // �i�ڃf�[�^�\���̏�����& �f�[�^�̊i�[
                hinmokuItem = new ItemWorkHinmokuData();
                CYBNItem.hinmokuArray.Add(hinmokuItem);

                // �i�ږ�
                hinmokuItem.strHinmokuNM = "";

                if (resultRow.IsstrHinmokuNMNull() == false)
                {
                    hinmokuItem.strHinmokuNM = resultRow.strHinmokuNM.Trim();
                }

                // �i�ڃR�[�h
                hinmokuItem.strHinmokuCD = "";

                if (resultRow.IsstrHinmokuCDNull() == false)
                {
                    hinmokuItem.strHinmokuCD = resultRow.strHinmokuCD.Trim();
                }

                // �Ǘ��敪
                hinmokuItem.strKanriKBN = "";

                if (resultRow.IsKNRKBNNull() == false)
                {
                    hinmokuItem.strKanriKBN = resultRow.KNRKBN.Trim();
                }

                // ���z
                hinmokuItem.curKingaku = 0.0m;

                if (resultRow.IscurKingakuNull() == false)
                {
                    hinmokuItem.curKingaku = Decimal.Parse(resultRow.curKingaku.Trim());
                }

                // �ō��݋��z
                hinmokuItem.curZeikomi = 0.0m;

                if (resultRow.IscurKingakuNull() == false)
                {
                    hinmokuItem.curZeikomi = Decimal.Parse(resultRow.curKingaku.Trim()) + ( Decimal.Parse(resultRow.curKingaku.Trim()) * _taxRate );
                }

                // �t�B�[CD
                hinmokuItem.strFEECD = "";

                if (resultRow.IsFEECDNull() == false)
                {
                    hinmokuItem.strFEECD = resultRow.FEECD.Trim();
                }
            }
        }

        /// <summary>
        /// �������ׁi�i�ڕʁj��ʏo�͗p�f�[�^�̕ҏW 
        /// </summary>
        /// <param name="work">�������ׁi�i�ڕʁj�W�v�ς݃��[�N</param>
        private void putReportByItemView(ItemWorkData work )
        {
            // ��ʏo�͗p�f�[�^�X�L�[�}�̐��� 
            ReportDSTkdBilling view = new ReportDSTkdBilling();

            Decimal cruZei;     // ����Ŋz 
            Decimal cruGoukei;  // ���v 

            cruGoukei = 0;
            cruZei = 0;

            // �ʍs�p 
            ReportDSTkdBilling.ReportByItemViewRow viewRow = view.ReportByItemView.NewReportByItemViewRow();

            foreach (ItemWorkSiteData siteItem in work.siteArray)
            {
                // �T�C�g 
                viewRow.cHHSite = siteItem.strSite;

                // �㗝�X�� 
                viewRow.cHDairinm = "�d��";

                // �㗝�X�R�[�h
                viewRow.cHDairicd = siteItem.strDairitenCD;

                // ���{�N�� 
                viewRow.cHym = siteItem.strYM;

                foreach (ItemWorkCYBNData CYBNItem in siteItem.CYBNArray)
                {
                    // �}�̒����ރR�[�h 
                    viewRow.cHBtccd = CYBNItem.strCYBNCD;

                    // �}�̒����ޖ� 
                    viewRow.cHBtcnm = CYBNItem.strCYBNNM;

                    foreach (ItemWorkHinmokuData hinmokuItem in CYBNItem.hinmokuArray)
                    {
                        // �i�ږ� 
                        viewRow.cHHinmoku = hinmokuItem.strHinmokuNM;

                        // �i�ڃR�[�h 
                        if (!String.Equals(hinmokuItem.strHinmokuCD, ""))
                        {
                            viewRow.cHHinmokucd = hinmokuItem.strHinmokuCD;
                        }

                        // �Ǘ��敪
                        viewRow.cHKanricbn = hinmokuItem.strKanriKBN;

                        // ���z
                        viewRow.cHKingaku = (hinmokuItem.curKingaku).ToString();

                        // ���v���z�̎擾
                        cruGoukei = cruGoukei + hinmokuItem.curKingaku;

                        // ���z(����ō���)
                        viewRow.cHZeikomi = (hinmokuItem.curZeikomi).ToString();

                        // �t�B�[�R�[�h�ޔ��
                        viewRow.cHFeeCd = hinmokuItem.strFEECD;

                        // �s�̃J�E���g�A�b�v 
                        view.ReportByItemView.AddReportByItemViewRow(viewRow);
                        viewRow = view.ReportByItemView.NewReportByItemViewRow();
                    }
                }

                // ����Ŋz�̕\��
                cruZei = cruGoukei * _taxRate;
                viewRow.cHHinmoku = gstrOutSyohizei;
                viewRow.cHKingaku = (cruZei).ToString();

                // �s�̃J�E���g�A�b�v
                view.ReportByItemView.AddReportByItemViewRow(viewRow);
                viewRow = view.ReportByItemView.NewReportByItemViewRow();

                // ���v�̕\��
                cruGoukei = cruZei + cruGoukei;
                viewRow.cHHinmoku = gstrOutGoukei;
                viewRow.cHKingaku = (cruGoukei).ToString();

                // �s�̃J�E���g�A�b�v
                view.ReportByItemView.AddReportByItemViewRow(viewRow);
                viewRow = view.ReportByItemView.NewReportByItemViewRow();

                cruZei = 0;
                cruGoukei = 0;

                // �󔒍s�̒ǉ� 
                view.ReportByItemView.AddReportByItemViewRow(viewRow);
                viewRow = view.ReportByItemView.NewReportByItemViewRow();
            }

            dgvMain_Sheet2.RowCount = 0;
            dgvMain_Sheet2.DataSource = view.ReportByItemView;
            statusStrip1.Items["tslval1"].Text = work.getHierarchicalCount().ToString() + "��";
        }

        /// <summary>
        /// �������ׁi�i�ڕʁj���[�o�͗p�f�[�^�̕ҏW
        /// </summary>
        /// <param name="work">�������ׁi�i�ڕʁj�W�v�ς݃��[�N</param>
        private void putReportByItemMacroData(ItemWorkData work)
        {
            // ���[�o�͗p�f�[�^�X�L�[�}�̐���
            ReportDSTkdBilling macro = new ReportDSTkdBilling();

            foreach (ItemWorkSiteData siteItem in work.siteArray)
            {
                foreach (ItemWorkCYBNData CYBNItem in siteItem.CYBNArray)
                {
                    foreach (ItemWorkHinmokuData hinmokuItem in CYBNItem.hinmokuArray)
                    {
                        ReportDSTkdBilling.ReportByItemMacroRow macroRow = macro.ReportByItemMacro.NewReportByItemMacroRow();

                        // �T�C�g�ʃf�[�^
                        macroRow.strDairitenCD = siteItem.strDairitenCD;            // �㗝�X�R�[�h
                        macroRow.strYM = siteItem.strYM;                            // ���{�N��
                        macroRow.strSite = siteItem.strSite;                        // �T�C�g

                        // �����ޕʃf�[�^
                        macroRow.strCYBNCD = CYBNItem.strCYBNCD;                    // �}�̒����ރR�[�h
                        macroRow.strCYBNNM = CYBNItem.strCYBNNM;                    // �}�̒����ޖ�

                        // �i�ڕʃf�[�^
                        macroRow.strHinmokuNM = hinmokuItem.strHinmokuNM;           // �i�ږ�
                        macroRow.strHinmokuCD = hinmokuItem.strHinmokuCD;           // �i�ڃR�[�h
                        macroRow.strKanriKBN = hinmokuItem.strKanriKBN;             // �Ǘ��敪
                        macroRow.curKingaku = hinmokuItem.curKingaku.ToString();    // ���z
                        macroRow.curZeikomi = hinmokuItem.curZeikomi.ToString();    // �ō��݋��z
                        macroRow.strFEECD = hinmokuItem.strFEECD;

                        // �T�C�g�ʃL�[����
                        if (work.siteArray.IndexOf(siteItem) == 0)
                        {
                            macroRow.keyCountSite = work.siteArray.Count.ToString();
                        }

                        // �����ޕʃL�[����
                        if (siteItem.CYBNArray.IndexOf(CYBNItem) == 0)
                        {
                            macroRow.keyCountCYBN = siteItem.CYBNArray.Count.ToString();
                        }

                        // �i�ڕʃL�[����
                        if (CYBNItem.hinmokuArray.IndexOf(hinmokuItem) == 0)
                        {
                            macroRow.keyCountHinmoku = CYBNItem.hinmokuArray.Count.ToString();
                        }

                        macro.ReportByItemMacro.AddReportByItemMacroRow(macroRow);
                    }
                }
            }

            putDataSet = macro;
            putTaxRate = _taxRate.ToString();
            btnXls.Enabled = true;
        }

        /// <summary>
        /// �������ׁi����j�f�[�^�̓ǂݍ��ݏ��� 
        /// </summary>
        private void loadReportForPlanningCostData()
        {
            //���[�f�B���O�\���J�n 
            base.ShowLoadingDialog();

            // �N���̎擾 
            string strYYYYMM = txtYm.Value;

            // �v���Z�X�R���g���[���̎擾 
            ReportTkdBillingProcessController controller = ReportTkdBillingProcessController.GetInstance();

            // �f�[�^�̎擾 
            FindReportTkdBillingForPlanningCostByCondServiceResult result = controller.FindReportTkdBillingForPlanningCostByCond(
                                                                                      _naviParam.strEsqId,
                                                                                      _naviParam.strEgcd,
                                                                                      _naviParam.strTksKgyCd,
                                                                                      _naviParam.strTksBmnSeqNo,
                                                                                      _naviParam.strTksTntSeqNo,
                                                                                      strYYYYMM
                                                                                      );
            // �f�[�^�����݂��Ȃ���ΏI�� 
            if (result.dsReportTkdBillingDataSet.ReportForPlanningCostResult.Rows.Count == 0)
            {
                //���[�f�B���O�\���I�� 
                base.CloseLoadingDialog();

                btnXls.Enabled = false;

                dgvMain_Sheet3.RowCount = 0;

                statusStrip1.Items["tslval1"].Text = "0��";

                //MessageBox.Show("�Y���̃f�[�^�͑��݂��܂���B", "���[", MessageBoxButtons.OK);
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "���[", MessageBoxButtons.OK);

                return;
            }

            // ��ʂւ̏o�� 
            putReportForPlanningCostView(result);

            // ���[�p�f�[�^�Z�b�g�ւ̏o�� 
            putReportForPlanningCostMacroData(result);

            //���[�f�B���O�\���I�� 
            base.CloseLoadingDialog();

        }

        /// <summary>
        /// �������ׁi����j��ʏo�͗p�f�[�^�̕ҏW 
        /// </summary>
        /// <param name="result">SQL�擾����</param>
        private void putReportForPlanningCostView(FindReportTkdBillingForPlanningCostByCondServiceResult result)
        {
            // ��ʏo�͗p�f�[�^�X�L�[�}�̐���
            ReportDSTkdBilling view = new ReportDSTkdBilling();

            String lstrSvNo;        // �O�s�̓��e��ۑ� 
            String lstrSvTekiyo;    // �O�s�̓��e��ۑ� 
            Decimal lcurKingaku;
            Boolean lbolFnd;
            Decimal lcurTotal;
            Boolean putState;
            List<mtypHinmoku> usrHinmokuArray = new List<mtypHinmoku>();
            lstrSvNo = null;
            lstrSvTekiyo = null;
            lcurTotal = 0;
            putState = false;

            ReportDSTkdBilling.ReportForPlanningCostViewRow viewRow = view.ReportForPlanningCostView.NewReportForPlanningCostViewRow();
            ReportDSTkdBilling.ReportForPlanningCostResultRow[] resultRows = (ReportDSTkdBilling.ReportForPlanningCostResultRow[])result.dsReportTkdBillingDataSet.ReportForPlanningCostResult.Select("", "");

            foreach (ReportDSTkdBilling.ReportForPlanningCostResultRow resultRow in resultRows)
            {
                // ���͂��ꂽ���������̉��� 
                // SQL�𔭍s���A�������ʂ�Spread�ɓ\����� 
                //�X�v���b�h���N���A 
                if (putState == false)
                {
                    usrHinmokuArray.Clear();
                    mtypHinmoku usrHinmoku = new mtypHinmoku();
                    usrHinmokuArray.Add(usrHinmoku);

                    //�L�[�Z�[�u
                    usrHinmoku.Cd = resultRow.SCD;
                    usrHinmoku.Name = resultRow.SNM;
                }
                else
                {
                    if (!String.Equals(resultRow.JYUTNO + resultRow.JYMEINO + resultRow.URMEINO, lstrSvNo))
                    {
                        //���׍ŏI�s�Ƀt���O�Z�b�g 
                        viewRow.cKKLineFlg = "1";

                        //�i�ږ����v 
                        {
                            foreach (mtypHinmoku usrHinmoku in usrHinmokuArray)
                            {
                                viewRow.cKKTekiyo = usrHinmoku.Name;
                                viewRow.cKKSuryo = "���v";
                                viewRow.cKKKingaku = (usrHinmoku.Kingaku).ToString();

                                view.ReportForPlanningCostView.AddReportForPlanningCostViewRow(viewRow);
                                viewRow = view.ReportForPlanningCostView.NewReportForPlanningCostViewRow();
                            }
                        }

                        {
                            //�L�����y�[���ŏI�s�Ƀt���O�Z�b�g 
                            viewRow.cKKLineFlg = "2";

                            usrHinmokuArray.Clear();
                            mtypHinmoku usrHinmoku = new mtypHinmoku();
                            usrHinmokuArray.Add(usrHinmoku);
                            usrHinmoku.Cd = resultRow.SCD;
                            usrHinmoku.Name = resultRow.SNM;
                        }
                    }
                }

                //�i�ږ� 
                viewRow.cKKHinmoku = resultRow.SNM;

                //�c�[�����e 
                //���� 
                if ((!String.Equals(resultRow.JYUTNO + resultRow.JYMEINO + resultRow.URMEINO, lstrSvNo)) || (!String.Equals(resultRow.TEKIYO, lstrSvTekiyo)))
                {
                    viewRow.cKKTekiyo = resultRow.TEKIYO;
                    viewRow.cKKSuryo = "�P��";
                }
                else
                {
                    viewRow.cKKTekiyo = "�@�V";
                }

                // �{�̊z 
                viewRow.cKKHongaku = (resultRow.SEIGAK).ToString();

                // ����Ŋz 
                viewRow.cKKZeigaku = (Decimal.Floor(Decimal.Parse(resultRow.SEIGAK) * (Decimal.Parse(resultRow.SZEIRITU) / 100m))).ToString();

                // �������z 
                lcurKingaku = Decimal.Floor(Decimal.Parse(resultRow.SEIGAK) * ((Decimal.Parse(resultRow.SZEIRITU) / 100m) + 1));

                // ���v���z�̉��Z 
                lbolFnd = false;

                foreach (mtypHinmoku usrHinmoku in usrHinmokuArray)
                {
                    if (String.Equals(usrHinmoku.Cd, resultRow.SCD))
                    {
                        usrHinmoku.Kingaku = usrHinmoku.Kingaku + lcurKingaku;
                        lbolFnd = true;
                        break;
                    }
                }

                if (lbolFnd == false)
                {
                    mtypHinmoku usrHinmoku = new mtypHinmoku();
                    usrHinmokuArray.Add(usrHinmoku);

                    usrHinmoku.Cd = resultRow.SCD;
                    usrHinmoku.Name = resultRow.SNM;
                    usrHinmoku.Kingaku = lcurKingaku;
                }

                viewRow.cKKKingaku = (lcurKingaku).ToString();

                lcurTotal = lcurTotal + lcurKingaku;

                //�敪 
                viewRow.cKKKbn = resultRow.KBN;

                //�L�[�Z�[�u 
                lstrSvNo = resultRow.JYUTNO + resultRow.JYMEINO + resultRow.URMEINO;

                lstrSvTekiyo = "";

                if (resultRow.IsTEKIYONull() == false)
                {
                    lstrSvTekiyo = resultRow.TEKIYO;
                }

                view.ReportForPlanningCostView.AddReportForPlanningCostViewRow(viewRow);
                viewRow = view.ReportForPlanningCostView.NewReportForPlanningCostViewRow();

                putState = true;
            }

            if (putState == true)
            {
                //���׍ŏI�s�Ƀt���O�Z�b�g 
                viewRow.cKKLineFlg = "1";

                //�i�ږ����v 
                foreach (mtypHinmoku usrHinmoku in usrHinmokuArray)
                {
                    viewRow.cKKTekiyo = usrHinmoku.Name;
                    viewRow.cKKSuryo = "���v";
                    viewRow.cKKKingaku = (usrHinmoku.Kingaku).ToString();

                    view.ReportForPlanningCostView.AddReportForPlanningCostViewRow(viewRow);
                    viewRow = view.ReportForPlanningCostView.NewReportForPlanningCostViewRow();
                }

                //�L�����y�[���ŏI�s�Ƀt���O�Z�b�g 
                viewRow.cKKLineFlg = "2";

                //�����v 
                viewRow.cKKTekiyo = "�����v";
                viewRow.cKKKingaku = (lcurTotal).ToString();
                viewRow.cKKLineFlg = "9"; //�����v�s�Ƀt���O�Z�b�g 

                view.ReportForPlanningCostView.AddReportForPlanningCostViewRow(viewRow);
                viewRow = view.ReportForPlanningCostView.NewReportForPlanningCostViewRow();

                // �󔒍s�̒ǉ� 
                view.ReportForPlanningCostView.AddReportForPlanningCostViewRow(viewRow);
                viewRow = view.ReportForPlanningCostView.NewReportForPlanningCostViewRow();
            }

            dgvMain_Sheet3.RowCount = 0;

            dgvMain_Sheet3.DataSource = view.ReportForPlanningCostView;

            statusStrip1.Items["tslval1"].Text = result.dsReportTkdBillingDataSet.ReportForPlanningCostResult.Rows.Count.ToString() + "��";
        }

        /// <summary>
        /// �������ׁi����j���[�o�͗p�f�[�^�̕ҏW 
        /// </summary>
        /// <param name="result">SQL�擾����</param>
        private void putReportForPlanningCostMacroData(FindReportTkdBillingForPlanningCostByCondServiceResult result)
        {
            // ���[�o�͗p�f�[�^�X�L�[�}�̐��� 
            ReportDSTkdBilling macro = new ReportDSTkdBilling();

            ReportDSTkdBilling.ReportForPlanningCostResultRow[] resultRows = (ReportDSTkdBilling.ReportForPlanningCostResultRow[])result.dsReportTkdBillingDataSet.ReportForPlanningCostResult.Select("", "");

            foreach (ReportDSTkdBilling.ReportForPlanningCostResultRow resultRow in resultRows)
            {
                ReportDSTkdBilling.ReportForPlanningCostMacroRow macroRow = macro.ReportForPlanningCostMacro.NewReportForPlanningCostMacroRow();

                macroRow.JYUTNO = resultRow.JYUTNO;
                macroRow.JYMEINO = resultRow.JYMEINO;
                macroRow.URMEINO = resultRow.URMEINO;
                macroRow.KNGK1 = resultRow.KNGK1;
                macroRow.SCD = resultRow.SCD;
                macroRow.SNM = resultRow.SNM;
                macroRow.TEKIYO = resultRow.TEKIYO;
                macroRow.KBN = resultRow.KBN;
                macroRow.SEIGAK = resultRow.SEIGAK;
                macroRow.SZEIRITU = resultRow.SZEIRITU;

                macro.ReportForPlanningCostMacro.AddReportForPlanningCostMacroRow(macroRow);
            }

            putDataSet = macro;
            putEGCD = _naviParam.strEgcd;
            btnXls.Enabled = true;
        }

        /// <summary>
        /// �������ׁi�����ޕʁj���[���o�͂��� 
        /// </summary>
        private void putReportByMiddleClassificationData()
        {
            // SaveFileDialog�N���X�̃C���X�^���X���쐬 
            SaveFileDialog sfd = new SaveFileDialog();

            // ���t�Ƃ� 
            DateTime now = DateTime.Now;

            // �͂��߂̃t�@�C�������w�肷�� 
            //sfd.FileName = now.ToString("yyyyMMdd") + strReportByMiddleClassificationFilename + ".xlsx";
            sfd.FileName = strReportByMiddleClassificationFilename + now.ToString("yyyyMMdd") + ".xlsx";

            // �͂��߂ɕ\�������t�H���_���w�肷�� 
            sfd.InitialDirectory = strReportDefaultPath;

            // [�t�@�C���̎��]�ɕ\�������I�������w�肷�� 
            sfd.Filter = "XLSX�t�@�C��(*.xlsx)|*.xlsx";

            // [�t�@�C���̎��]�ł͂��߂Ɂu���ׂẴt�@�C���v���I������Ă���悤�ɂ��� 
            sfd.FilterIndex = 0;

            // �^�C�g����ݒ肷�� 
            sfd.Title = "�ۑ���̃t�@�C����ݒ肵�ĉ������B";

            // �_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ��� 
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filnm = sfd.FileName;
                string workFolderPath = strReportTempPath;
                string excelFile = string.Empty;
                string macroFile = workFolderPath + REPORT_BY_MIDDLE_CLASSIFICATION_MACRO_FILENAME;
                string templFile = workFolderPath + REPORT_BY_MIDDLE_CLASSIFICATION_TEMPLATE_FILENAME;
                DataRow dtRow;

                try
                {
                    // Excel�J�n����.
                    // ���\�[�X����Excel�t�@�C�����쐬(�e���v���[�g�ƃ}�N��).
                    File.WriteAllBytes(macroFile, Properties.Resources.TkdReportByMiddleClassification_Mcr);
                    File.WriteAllBytes(templFile, Properties.Resources.TkdReportByMiddleClassification_Template);

                    if (System.IO.File.Exists(templFile) == false)
                    {
                        throw new Exception("�e���v���[�gExcel�t�@�C��������܂���B");
                    }

                    if (System.IO.File.Exists(macroFile) == false)
                    {
                        throw new Exception("�}�N��Excel�t�@�C��������܂���B");
                    }

                    // �f�[�^�Z�b�gXML�o�� 
                    putDataSet.WriteXml(Path.Combine(workFolderPath, REPORT_DATA_XML_FILENAME));

                    // �p�����[�^XML�쐬�A�o�� 
                    // �ϐ��̐錾
                    DataSet dtSet = new DataSet("PRODUCTS");
                    DataTable dtTable;

                    // �f�[�^�Z�b�g�Ƀe�[�u����ǉ����� 
                    // PRODUCTS�Ƃ����e�[�u�����쐬���܂� 
                    dtTable = dtSet.Tables.Add("PRODUCTS");
                    dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                    dtTable.Columns.Add("taxRate", Type.GetType("System.String"));

                    //�e�[�u���Ƀf�[�^��ǉ�����
                    dtRow = dtTable.NewRow();
                    dtRow["SAVEDIR"] = filnm;
                    dtRow["taxRate"] = putTaxRate;
                    dtTable.Rows.Add(dtRow);
                    dtSet.WriteXml(Path.Combine(workFolderPath, REPORT_PROPERTY_XML_FILENAME));

                    //�G�N�Z���N��.
                    System.Diagnostics.Process.Start("excel", workFolderPath + REPORT_BY_MIDDLE_CLASSIFICATION_MACRO_FILENAME);

                    //�폜�p�ɕێ��i�߂�{�^���������ɍ폜����ׁj
                    _strReportByMiddleClassificationMacroPath = workFolderPath + REPORT_BY_MIDDLE_CLASSIFICATION_MACRO_FILENAME;

                    // �I�y���[�V�������O�̏o�� 
                    KKHLogUtilityTkd.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityTkd.KINO_ID_OPERATION_LOG_REPORT_MIDDLECLASSIFICATION, KKHLogUtilityTkd.DESC_OPERATION_LOG_REPORT_MIDDLECLASSIFICATION);
                
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            sfd.Dispose();
        }

        /// <summary>
        /// �������ׁi�i�ڕʁj���[���o�͂���
        /// </summary>
        private void putReportByItemData()
        {
            // SaveFileDialog�N���X�̃C���X�^���X���쐬
            SaveFileDialog sfd = new SaveFileDialog();

            // ���t�Ƃ�
            DateTime now = DateTime.Now;

            // �͂��߂̃t�@�C�������w�肷��
            //sfd.FileName = now.ToString("yyyyMMdd") + strReportByItemFilename + ".xlsx";
            sfd.FileName = strReportByItemFilename + now.ToString("yyyyMMdd") + ".xlsx";

            // �͂��߂ɕ\�������t�H���_���w�肷��
            sfd.InitialDirectory = strReportDefaultPath;

            // [�t�@�C���̎��]�ɕ\�������I�������w�肷��
            sfd.Filter = "XLSX�t�@�C��(*.xlsx)|*.xlsx";

            // [�t�@�C���̎��]�ł͂��߂Ɂu���ׂẴt�@�C���v���I������Ă���悤�ɂ���
            sfd.FilterIndex = 0;

            // �^�C�g����ݒ肷��
            sfd.Title = "�ۑ���̃t�@�C����ݒ肵�ĉ������B";

            // �_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filnm = sfd.FileName;
                string workFolderPath = strReportTempPath;
                string excelFile = string.Empty;
                string macroFile = workFolderPath + REPORT_BY_ITEM_MACRO_FILENAME;
                string templFile = workFolderPath + REPORT_BY_ITEM_TEMPLATE_FILENAME;
                DataRow dtRow;

                try
                {
                    // Excel�J�n����.
                    // ���\�[�X����Excel�t�@�C�����쐬(�e���v���[�g�ƃ}�N��).
                    File.WriteAllBytes(macroFile, Properties.Resources.TkdReportByItem_Mcr);
                    File.WriteAllBytes(templFile, Properties.Resources.TkdReportByItem_Template);

                    if (System.IO.File.Exists(templFile) == false)
                    {
                        throw new Exception("�e���v���[�gExcel�t�@�C��������܂���B");
                    }
                    if (System.IO.File.Exists(macroFile) == false)
                    {
                        throw new Exception("�}�N��Excel�t�@�C��������܂���B");
                    }

                    // �f�[�^�Z�b�gXML�o��
                    putDataSet.WriteXml(Path.Combine(workFolderPath, REPORT_DATA_XML_FILENAME));

                    // �p�����[�^XML�쐬�A�o��

                    // �ϐ��̐錾
                    DataSet dtSet = new DataSet("PRODUCTS");
                    DataTable dtTable;

                    // �f�[�^�Z�b�g�Ƀe�[�u����ǉ����� 
                    // PRODUCTS�Ƃ����e�[�u�����쐬���܂� 
                    dtTable = dtSet.Tables.Add("PRODUCTS");
                    dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                    dtTable.Columns.Add("taxRate", Type.GetType("System.String"));

                    //�e�[�u���Ƀf�[�^��ǉ����� 
                    dtRow = dtTable.NewRow();
                    dtRow["SAVEDIR"] = filnm;
                    dtRow["taxRate"] = putTaxRate;
                    dtTable.Rows.Add(dtRow);
                    dtSet.WriteXml(Path.Combine(workFolderPath, REPORT_PROPERTY_XML_FILENAME));

                    //�G�N�Z���N��.
                    System.Diagnostics.Process.Start("excel", workFolderPath + REPORT_BY_ITEM_MACRO_FILENAME);

                    //�폜�p�ɕێ��i�߂�{�^���������ɍ폜����ׁj
                    _strReportByItemMacroPath = workFolderPath + REPORT_BY_ITEM_MACRO_FILENAME;

                    // �I�y���[�V�������O�̏o�� 
                    KKHLogUtilityTkd.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityTkd.KINO_ID_OPERATION_LOG_REPORT_ITEM, KKHLogUtilityTkd.DESC_OPERATION_LOG_REPORT_ITEM);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            sfd.Dispose();
        }

        /// <summary>
        /// �������ׁi����j���[���o�͂��� 
        /// </summary>
        private void putReportForPlanningCostData()
        {
            // SaveFileDialog�N���X�̃C���X�^���X���쐬 
            SaveFileDialog sfd = new SaveFileDialog();

            // ���t�Ƃ� 
            DateTime now = DateTime.Now;

            // �͂��߂̃t�@�C�������w�肷�� 
            //sfd.FileName = now.ToString("yyyyMMdd") + strReportForPlanningCostFilename + ".xlsx";
            sfd.FileName = strReportForPlanningCostFilename + now.ToString("yyyyMMdd") + ".xlsx";

            // �͂��߂ɕ\�������t�H���_���w�肷�� 
            sfd.InitialDirectory = strReportDefaultPath;

            // [�t�@�C���̎��]�ɕ\�������I�������w�肷�� 
            sfd.Filter = "XLSX�t�@�C��(*.xlsx)|*.xlsx";

            // [�t�@�C���̎��]�ł͂��߂Ɂu���ׂẴt�@�C���v���I������Ă���悤�ɂ��� 
            sfd.FilterIndex = 0;

            // �^�C�g����ݒ肷�� 
            sfd.Title = "�ۑ���̃t�@�C����ݒ肵�ĉ������B";

            // �_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ��� 
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filnm = sfd.FileName;
                string workFolderPath = strReportTempPath;
                string excelFile = string.Empty;
                string macroFile = workFolderPath + REPORT_FOR_PLANNING_COST_MACRO_FILENAME;
                string templFile = workFolderPath + REPORT_FOR_PLANNING_COST_TEMPLATE_FILENAME;
                DataRow dtRow;

                try
                {
                    // Excel�J�n����.
                    // ���\�[�X����Excel�t�@�C�����쐬(�e���v���[�g�ƃ}�N��).
                    File.WriteAllBytes(macroFile, Properties.Resources.TkdReportForPlanningCost_Mcr);
                    File.WriteAllBytes(templFile, Properties.Resources.TkdReportForPlanningCost_Template);

                    if (System.IO.File.Exists(templFile) == false)
                    {
                        throw new Exception("�e���v���[�gExcel�t�@�C��������܂���B");
                    }

                    if (System.IO.File.Exists(macroFile) == false)
                    {
                        throw new Exception("�}�N��Excel�t�@�C��������܂���B");
                    }

                    // �f�[�^�Z�b�gXML�o�� 
                    putDataSet.WriteXml(Path.Combine(workFolderPath, REPORT_DATA_XML_FILENAME));

                    // �p�����[�^XML�쐬�A�o�� 
                    // �ϐ��̐錾 
                    DataSet dtSet = new DataSet("PRODUCTS");
                    DataTable dtTable;

                    // �f�[�^�Z�b�g�Ƀe�[�u����ǉ����� 
                    // PRODUCTS�Ƃ����e�[�u�����쐬���܂� 
                    dtTable = dtSet.Tables.Add("PRODUCTS");
                    dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                    dtTable.Columns.Add("YYYYMM", Type.GetType("System.String"));
                    dtTable.Columns.Add("EGCD", Type.GetType("System.String"));

                    //�e�[�u���Ƀf�[�^��ǉ����� 
                    dtRow = dtTable.NewRow();
                    dtRow["SAVEDIR"] = filnm;
                    dtRow["YYYYMM"] = txtYm.Value;
                    dtRow["EGCD"] = putEGCD;
                    dtTable.Rows.Add(dtRow);
                    dtSet.WriteXml(Path.Combine(workFolderPath, REPORT_PROPERTY_XML_FILENAME));

                    //�G�N�Z���N��.
                    System.Diagnostics.Process.Start("excel", workFolderPath + REPORT_FOR_PLANNING_COST_MACRO_FILENAME);

                    //�폜�p�ɕێ��i�߂�{�^���������ɍ폜����ׁj
                    _strReportForPlanningCostMacroPath = workFolderPath + REPORT_FOR_PLANNING_COST_MACRO_FILENAME;

                    // �I�y���[�V�������O�̏o�� 
                    KKHLogUtilityTkd.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityTkd.KINO_ID_OPERATION_LOG_REPORT_PLANNINGCOST, KKHLogUtilityTkd.DESC_OPERATION_LOG_REPORT_SUB_PLANNINGCOST);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            sfd.Dispose();
        }

        #endregion ���\�b�h
    }
}

