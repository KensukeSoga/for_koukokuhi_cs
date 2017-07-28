using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using Isid.KKH.Skyp.Schema;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Skyp.ProcessController.Report;
using Isid.KKH.Skyp.Properties;
using Isid.KKH.Skyp.Utility;

namespace Isid.KKH.Skyp.View.Report
{
    /// <summary>
    /// ���[�o�͉�ʁi�X�J�p�[�j
    /// </summary>
    public partial class ReportSkyp : KKHForm
    {
        #region �萔 

        /// <summary>
        /// �A�v��ID
        /// </summary>
        private const String APLID = "RepSkyp";

        /// <summary>
        /// ���[�o�́Q�t�@�C���g���q 
        /// </summary>
        private const string SFD_EXT = ".xls";
        /// <summary>
        /// ���[�o�́Q�N���f�B���N�g�� 
        /// </summary>
        private const string SFD_INITDIR = @"C:TMP\";
        /// <summary>
        /// ���[�o�́Q�N���f�B���N�g��(�e���v���[�g�j
        /// </summary>
        private const string SFD_INIT_NET_DIR = @"R:\E19-SKYPER\";
        /// <summary>
        /// ���[�o�́Q�N���f�B���N�g��(�e���v���[�g�j
        /// </summary>
        private const string SFD_INIT_DIR = @"C:\WORK\";
        /// <summary>
        /// ���[�o�́Q�N���f�B���N�g��(�e���v���[�g�j
        /// </summary>
        private const string SFD_INIT_FILENAME = @"�[�i�^������";
        /// <summary>
        /// ���[�o�́Q�t�B���^ 
        /// </summary>
        private const string SFD_FILTER = "XLS�t�@�C��(*.xls)|*.xls";
        /// <summary>
        /// ���[�o�́Q�^�C�g�� 
        /// </summary>
        private const string SFD_TITLE = "�ۑ���̃t�@�C����ݒ肵�ĉ������B";

        /// <summary>
        /// XML�t�@�C�����i�f�[�^�p�j 
        /// </summary>
        private const string REP_XML_FILENAME = "Skyp_Data.xml";
        /// <summary>
        /// XML�t�@�C�����i�v���p�e�B�p�j 
        /// </summary>
        private const string REP_XML2_FILENAME = "Skyp_Prop.xml";
        /// <summary>
        /// Excel(���[�o�̓}�N������)�t�@�C���� 
        /// </summary>
        private const string REP_TEMPLATE_FILENAME = "Skyp_Template.xlsx";
        /// <summary>
        /// Excel(���[�o�̓}�N������)�t�@�C���� 
        /// </summary>
        private const string REP_MACRO_FILENAME = "Skyp_Mcr.xlsm";

        /// <summary>
        /// ���[�ݒ���擾�L�[�F002 
        /// </summary>
        private const string KV7_SYBT = "002";
        /// <summary>
        /// ���[�ݒ���擾�L�[�F003 
        /// </summary>
        private const string KV7_SYBTSUB = "003";

        /// <summary>
        /// �ۑ��t�@�C�����i�t���p�X�j 
        /// </summary>
        private const string PARAM_SAVEDIR = "SAVEDIR";
        /// <summary>
        /// �N�� 
        /// </summary>
        private const string PARAM_YYYYMM = "YYYYMM";
        /// <summary>
        /// �V�[�g�ی�p�p�X���[�h 
        /// </summary>
        private const string PARAM_PASSWORD = "PASSWORD";
        /// <summary>
        /// ���Ӑ於 
        /// </summary>
        private const string PARAM_TKS_NAME = "TKS_NAME";
        /// <summary>
        /// ����於 
        /// </summary>
        private const string PARAM_THS_NAME = "THS_NAME";
        /// <summary>
        /// �����R�[�h 
        /// </summary>
        private const string PARAM_THS_CD = "THS_CD";
        /// <summary>
        /// �x�����i���ԁj 
        /// </summary>
        private const string PARAM_PAYDAY = "PAYDAY";

        /// <summary>
        /// �V�[�g�ی�p�p�X���[�h�̃f�t�H���g�l 
        /// </summary>
        private const string DEF_PASSWORD = "";

        /// <summary>
        /// �x�����i���ԁF���j�̃f�t�H���g�l 
        /// </summary>
        private const string DEF_PAYDAY = "3";

        #endregion �萔 

        #region �����o�ϐ� 

        /// <summary>
        /// Rg�i�r�p�����[�^ 
        /// </summary>
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();

        /// <summary>
        /// �R�s�[�}�N���폜�p 
        /// </summary>
        private string _strmacrodel;

        /// <summary>
        /// �ۑ���p�ϐ��i�l�b�g���[�N�h���C�u�j.
        /// </summary>
        private string pStrRepNetAdrs = "";
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
        /// �����
        /// </summary>
        private double _dbSyohizei;
        /// <summary>
        /// �V�[�g�ی�p�p�X���[�h.
        /// </summary>
        private string sheetPw = "";
        /// <summary>
        /// ���Ӑ於.
        /// </summary>
        private string tkskNm = "";
        /// <summary>
        /// ����於.
        /// </summary>
        private string trskNm = "";
        /// <summary>
        /// �����R�[�h.
        /// </summary>
        private string trskCd = "";
        /// <summary>
        /// �x�����i���ԁj.
        /// </summary>
        private string payDay = "";

        #endregion �����o�ϐ� 

        #region �R���X�g���N�^ 

        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        public ReportSkyp()
        {
            InitializeComponent();
        }

        #endregion �R���X�g���N�^ 

        #region �C�x���g 

        /// <summary>
        /// ��ʑJ�ڂ��邽�тɔ������܂��B 
        /// </summary>
        /// <param name="sender">�J�ڌ��t�H�[��</param>
        /// <param name="arg">�C�x���g�f�[�^</param>
        private void ReportSkyp_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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
        /// ��ʕ\���� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportSkyp_Shown(object sender, EventArgs e)
        {
            //���[�f�B���O�\���J�n 
            base.ShowLoadingDialog();

            this.InitializeControl();

            //���[���̏����l�Z�b�g 
            GetReportDataInit();

            //���[�f�B���O�\���I�� 
            base.CloseLoadingDialog();
        }

        /// <summary>
        /// �{�^��MouseMove�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            tslCnt.Text = njToolTip1.GetToolTip((Control)sender);
        }

        /// <summary>
        /// �{�^��MouseLeave�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            tslCnt.Text = String.Empty;
        }

        /// <summary>
        /// �\���{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, EventArgs e)
        {
            //���[�f�B���O�\���J�n 
            base.ShowLoadingDialog();

            // �f�[�^���� 
            if (0 < this.FindReportData())
            {
                btnXls.Enabled = true;
                statusStrip1.Items["tslval1"].Text = _spdReport_Sheet1.Rows.Count.ToString() + "��";
            }
            else
            {
                //���[�f�B���O�\���I�� 
                base.CloseLoadingDialog();

                btnXls.Enabled = false;
                statusStrip1.Items["tslval1"].Text = "0��";
                //MessageBox.Show("�Y���̃f�[�^�͑��݂��܂���B", "���[", MessageBoxButtons.OK);
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, "���[", MessageBoxButtons.OK);
            }

            //�I����Ԃ����� 
            this.ActiveControl = null;

            //���[�f�B���O�\���I�� 
            base.CloseLoadingDialog();

        }

        /// <summary>
        /// Excel�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            // ���[�ݒ���擾 (�e���v���[�g�ۑ��ꏊ�A�p�X���[�h���j
            //Common.KKHSchema.Common.SystemCommonRow repInfo = this.GetReportInfo(KV7_SYBT);
            // ���[�ݒ���擾�i�t�@�C�������ۑ��ꏊ�j
            //Common.KKHSchema.Common.SystemCommonRow repInfoSub = this.GetReportInfo(KV7_SYBTSUB);

            // SaveFileDialog�N���X�̃C���X�^���X���쐬 
            SaveFileDialog sfd = new SaveFileDialog();

            DateTime now = DateTime.Now;

            // �͂��߂̃t�@�C�������w�肷�� 
            //sfd.FileName = DateTime.Now.ToString("yyyyMMdd") + repInfoSub.field3 + SFD_EXT;
            //sfd.FileName = "�[�i�^������-" + saveSrcYm + SFD_EXT;
            sfd.FileName = pStrRepFilNam + "-" + txtYm.Value + SFD_EXT;
            // �͂��߂ɕ\�������t�H���_���w�肷�� 
            //sfd.InitialDirectory = pStrRepAdrs;
            //sfd.InitialDirectory = repInfoSub.field2;

            {
                // �o�͐�p�X�̐ݒ�
                //�i�l�b�g���[�N�h���C�u�ɕۑ��A�p�X���J���Ȃ��ꍇ�̓��[�J���ɕۑ��j

                String path = pStrRepNetAdrs;

                if (!Directory.Exists(path))
                {
                    path = pStrRepAdrs;
                }

                sfd.InitialDirectory = path;
            }

            // [�t�@�C���̎��]�ɕ\�������I�������w�肷�� 
            sfd.Filter = SFD_FILTER;

            // [�t�@�C���̎��]�ł͂��߂� 
            // �u���ׂẴt�@�C���v���I������Ă���悤�ɂ��� 
            sfd.FilterIndex = 0;

            // �^�C�g����ݒ肷�� 
            sfd.Title = SFD_TITLE; 

            // �_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ��� 
            sfd.RestoreDirectory = true;

            // �_�C�A���O��\������ 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //�o�͐�ɓ�����Excel�t�@�C�����J���Ă��邩�`�F�b�N 
                try
                {
                    //�����Ńt�@�C�����폜����B 
                    File.Delete(sfd.FileName);
                }
                catch(IOException)
                {
                    //�o�͐�ɓ�����Excel�t�@�C�����J���Ă��܂��B���Ă���ēx�o�͂��Ă��������B 
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "���[", MessageBoxButtons.OK);

                    //�I����Ԃ����� 
                    this.ActiveControl = null;

                    return;
                }

                //*************************************
                // �o�͎��s 
                //*************************************
                this.ExcelOut(sfd.FileName);
                //this.ExcelOut(sfd.FileName, repInfo);
            }

            //�I����Ԃ����� 
            this.ActiveControl = null;

            sfd.Dispose();
        }

        /// <summary>
        /// �w���v�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            string tkskgy = _naviParameter.strTksKgyCd + _naviParameter.strTksBmnSeqNo + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //���s 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.ReportSkp, this, HelpNavigator.KeywordIndex);

            this.ActiveControl = null;
        }

        /// <summary>
        /// �߂�{�^���N���b�N�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (_strmacrodel != null)
            {
                FileInfo cFileInfo = new FileInfo(_strmacrodel);

                // �}�N���t�@�C���̍폜�iVBA���ł͍폜�ł��Ȃ��ׁj 
                // �t�@�C�������݂��Ă��邩���f���� 
                if (cFileInfo.Exists)
                {
                    // �ǂݎ���p����������ꍇ�́A�ǂݎ���p�������������� 
                    if ((cFileInfo.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        cFileInfo.Attributes = FileAttributes.Normal;
                    }

                    // �t�@�C�����폜���� 
                    cFileInfo.Delete();
                }
            }
            
            Navigator.Backward(this, null, _naviParameter, true);
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

        #endregion �C�x���g 

        #region ���\�b�h 

        /// <summary>
        /// �e�R���g���[���̏����ݒ� 
        /// </summary>
        private void InitializeControl()
        {
            string yyyymm = _naviParameter.strDate.Replace("/", string.Empty);

            // �N���e�L�X�g�{�b�N�X 
            //txtYm.Value = yyyymm.Substring(0, 6);

            // �X�e�[�^�X�ݒ� 
            tslName.Text = _naviParameter.strName;
            tslDate.Text = _naviParameter.strDate;

            if (yyyymm != "")
            {
                yyyymm = yyyymm.Trim().Replace("/", "");
                if (yyyymm.Trim().Length >= 6)
                {
                    txtYm.Value = yyyymm.Substring(0, 6);
                }
                else
                {
                    txtYm.Value = yyyymm;
                }
                txtYm.cmbYM_SetDate();
            }

        }

        /// <summary>
        /// �f�[�^�����E�\�����\�b�h 
        /// </summary>
        /// <returns>�������ʌ���</returns> 
        private int FindReportData()
        {
            ReportSkypProcessController.FindReportSkypByCondParam param =
                new ReportSkypProcessController.FindReportSkypByCondParam();

            // �p�����[�^�ݒ� 
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;            
            // �N�� 
            param.yymm = txtYm.Value;

            // ���[�i�X�J�p�[_�[�i�^�������j�f�[�^���� 
            ReportSkypProcessController processController = ReportSkypProcessController.GetInstance();
            FindReportSkypByCondServiceResult result = processController.FindReportSkypByCond(param);

            if (result.HasError == true)
            {
                return 0;
            }
            _dsReportSkyp.ReportData.Clear();
            _dsReportSkyp.ReportData.Merge(result.ReportDataSet.ReportData);
            _dsReportSkyp.ReportData.AcceptChanges();

            if (result.ReportDataSet.ReportData.Rows.Count == 0)
            {
                // �f�[�^�����݂��Ȃ��ꍇ��0��Ԃ� 
                return 0;
            }

            return result.ReportDataSet.ReportData.Rows.Count;
        }

        /// <summary>
        /// Excel�o�̓��\�b�h 
        /// </summary>
        /// <param name="filnm">�t�@�C��</param>
        /// <param name="repInfo">���[�o�͐ݒ���</param>
        private void ExcelOut(string filnm)
        //private void ExcelOut(string filnm, Common.KKHSchema.Common.SystemCommonRow repInfo)
        {
            string workFolderPath = pStrRepTempAdrs; //repInfo.field2;
            string excelFile = string.Empty;            
            string macroFile = workFolderPath + REP_MACRO_FILENAME;
            string templFile = workFolderPath + REP_TEMPLATE_FILENAME;
            DataRow dtRow;

            try
            {
                // Excel�J�n���� 
                // ���\�[�X����Excel�t�@�C�����쐬(�e���v���[�g�ƃ}�N��) 
                File.WriteAllBytes(templFile, Resources.Skyp_Template); 
                File.WriteAllBytes(macroFile, Resources.Skyp_Mcr);                

                if (File.Exists(templFile) == false)
                {
                    throw new Exception("�e���v���[�gExcel�t�@�C��������܂���B");
                }
                if (File.Exists(macroFile) == false)
                {
                    throw new Exception("�}�N��Excel�t�@�C��������܂���B");
                }

                // �f�[�^�Z�b�gXML�o�� 
                _dsReportSkyp.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));

                // �p�����[�^XML�쐬�A�o�� 
                // �ϐ��̐錾
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // �f�[�^�Z�b�g�Ƀe�[�u����ǉ����� 
                // PRODUCTS�Ƃ����e�[�u�����쐬���܂� 
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add(PARAM_SAVEDIR, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_YYYYMM, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_PASSWORD, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_TKS_NAME, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_THS_NAME, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_THS_CD, Type.GetType("System.String"));
                dtTable.Columns.Add(PARAM_PAYDAY, Type.GetType("System.String"));

                //�e�[�u���Ƀf�[�^��ǉ����� 
                dtRow = dtTable.NewRow();

                dtRow[PARAM_SAVEDIR] = filnm;               // �ۑ��t�@�C�����i�t���p�X�j 
                dtRow[PARAM_YYYYMM] = txtYm.Year + txtYm.Month;
                dtRow[PARAM_PASSWORD] = sheetPw;    // �V�[�g�ی�p�p�X���[�h 
                dtRow[PARAM_TKS_NAME] = tkskNm;     // ���Ӑ於 
                dtRow[PARAM_THS_NAME] = trskNm;     // ����於 
                dtRow[PARAM_THS_CD] = trskCd;       // �����R�[�h 
                dtRow[PARAM_PAYDAY] = payDay;       // �x�����i���ԁj 

                //dtRow[PARAM_YYYYMM] = _yyyyMM;              // �N�� 
                //dtRow[PARAM_PASSWORD] = repInfo.field3;    // �V�[�g�ی�p�p�X���[�h 
                //dtRow[PARAM_TKS_NAME] = repInfo.field8;     // ���Ӑ於 
                //dtRow[PARAM_THS_NAME] = repInfo.field5;     // ����於 
                //dtRow[PARAM_THS_CD] = repInfo.field6;       // �����R�[�h 
                //dtRow[PARAM_PAYDAY] = repInfo.field7;       // �x�����i���ԁj 
                
                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //�G�N�Z���N�� 
                System.Diagnostics.Process.Start("excel", macroFile);

                //�폜�p�ɕێ��i�߂�{�^���������ɍ폜����ׁj 
                _strmacrodel = macroFile;

                // �I�y���[�V�������O�̏o��.
                KKHLogUtilitySkyp.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilitySkyp.KINO_ID_OPERATION_LOG_REPORT, KKHLogUtilitySkyp.DESC_OPERATION_LOG_REPORT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///// <summary>
        ///// ���[�o�͐ݒ���擾���\�b�h 
        ///// </summary>
        ///// <returns>���[�o�͐ݒ���</returns>
        //private Common.KKHSchema.Common.SystemCommonRow GetReportInfo(string sybt)
        //{
        //    string strsybt = sybt;//���:"002"or"003"
        //    Common.KKHSchema.Common.SystemCommonRow ret;
        //    CommonProcessController commonProcessController = CommonProcessController.GetInstance();
        //    FindCommonByCondServiceResult comResult;
        //
        //    // ���[�ݒ���擾 
        //    comResult = commonProcessController.FindCommonByCond(_naviParameter.strEsqId,
        //                                                        _naviParameter.strEgcd,
        //                                                        _naviParameter.strTksKgyCd,
        //                                                        _naviParameter.strTksBmnSeqNo,
        //                                                        _naviParameter.strTksTntSeqNo,
        //                                                        strsybt,
        //                                                        string.Empty);
        //
        //    if (comResult.CommonDataSet.SystemCommon.Count != 0)
        //    {
        //        ret = comResult.CommonDataSet.SystemCommon[0];
        //    }
        //    else
        //    {
        //        // �擾�ł��Ȃ������ꍇ�̓f�t�H���g�l��ݒ� 
        //        Common.KKHSchema.Common.SystemCommonDataTable dt =
        //            new Common.KKHSchema.Common.SystemCommonDataTable();
        //        ret = (Common.KKHSchema.Common.SystemCommonRow)dt.NewRow();
        //
        //        for (int i = 0; i < dt.Columns.Count; i++)
        //        {
        //            ret[i] = string.Empty;
        //        }
        //
        //        if (sybt.Equals(KV7_SYBT))
        //        {
        //            // �ȉ��A�󕶎��ȊO���f�t�H���g�l�Ƃ��Đݒ� 
        //            ret.field2 = SFD_INITDIRTMP;       // �ۑ���p�X(�e���v���[�g�j 
        //            ret.field3 = DEF_PASSWORD;      // �V�[�g�ی�p�p�X���[�h 
        //            ret.field7 = DEF_PAYDAY;        // �x�����i���ԁj 
        //        }
        //        else
        //        {
        //            // �ȉ��A�󕶎��ȊO���f�t�H���g�l�Ƃ��Đݒ� 
        //            ret.field2 = SFD_INITDIR;       // �ۑ���p�X�i�G�N�Z���t�@�C���j
        //        }
        //    }
        //
        //    return ret;
        //}

        /// <summary>
        /// ���[�����ݒ�l���擾 
        /// </summary>
        private void GetReportDataInit()
        {
            //���[�f�B���O�\��  
            base.ShowLoadingDialog();

            {
                CommonProcessController controller = CommonProcessController.GetInstance();

                FindCommonByCondServiceResult result = controller.FindCommonByCond(
                                                                                _naviParameter.strEsqId,
                                                                                _naviParameter.strEgcd,
                                                                                _naviParameter.strTksKgyCd,
                                                                                _naviParameter.strTksBmnSeqNo,
                                                                                _naviParameter.strTksTntSeqNo,
                                                                                Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.MainType,
                                                                                "ED-I0001");

                if (result.CommonDataSet.SystemCommon.Count != 0)
                {
                    //����ŃZ�b�g
                    _dbSyohizei = double.Parse(result.CommonDataSet.SystemCommon[0].field4.ToString());
                    //�e���v���[�g�A�h���X
                    pStrRepTempAdrs = result.CommonDataSet.SystemCommon[0].field2.ToString();
                    // �V�[�g�ی�p�p�X���[�h 
                    sheetPw = result.CommonDataSet.SystemCommon[0].field3.ToString();
                    // ����於 
                    trskNm = result.CommonDataSet.SystemCommon[0].field5.ToString();
                    // �����R�[�h 
                    trskCd = result.CommonDataSet.SystemCommon[0].field6.ToString();
                    // �x�����i���ԁj
                    payDay = result.CommonDataSet.SystemCommon[0].field7.ToString();
                    // ���Ӑ於 
                    tkskNm = result.CommonDataSet.SystemCommon[0].field8.ToString();
                }
            }

            {
                //�ۑ����{���[��
                CommonProcessController controller = CommonProcessController.GetInstance();

                FindCommonByCondServiceResult result = controller.FindCommonByCond(
                                                                                _naviParameter.strEsqId,
                                                                                _naviParameter.strEgcd,
                                                                                _naviParameter.strTksKgyCd,
                                                                                _naviParameter.strTksBmnSeqNo,
                                                                                _naviParameter.strTksTntSeqNo,
                                                                                Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.ReportType,
                                                                                "001");

                if (result.CommonDataSet.SystemCommon.Count != 0)
                {
                    //�ۑ���i�l�b�g���[�N�h���C�u�j�Z�b�g
                    pStrRepNetAdrs = result.CommonDataSet.SystemCommon[0].field2.ToString();
                    //�ۑ���Z�b�g
                    pStrRepAdrs = result.CommonDataSet.SystemCommon[0].field3.ToString();
                    //���̃Z�b�g
                    pStrRepFilNam = result.CommonDataSet.SystemCommon[0].field4.ToString();
                }
                else
                {
                    //�ۑ���i�l�b�g���[�N�h���C�u�j�Z�b�g
                    pStrRepNetAdrs = SFD_INIT_NET_DIR;
                    //�ۑ���Z�b�g
                    pStrRepAdrs = SFD_INIT_DIR;
                    //���̃Z�b�g
                    pStrRepFilNam = SFD_INIT_FILENAME;
                }
            }

            //���[�f�B���O��\�� 
            base.CloseLoadingDialog();
        }

        #endregion ���\�b�h 

    }
}