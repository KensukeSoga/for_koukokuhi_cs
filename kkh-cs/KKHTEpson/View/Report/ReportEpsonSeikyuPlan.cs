using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using FarPoint.Win.Spread;

using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Epson.ProcessController.Report;
using Isid.KKH.Epson.Properties;
using Isid.KKH.Epson.Utility;

namespace Isid.KKH.Epson.View.Report
{
    /// <summary>
    /// �����\��ꗗ�o�͉�ʁi�G�v�\���j 
    /// </summary>
    public partial class ReportEpsonSeikyuPlan : KKHForm
    {
        #region �萔 

        /// <summary>
        /// �A�v��ID
        /// </summary>
        private const String APLID = "RepSPEps";

        /// <summary>
        /// ���[�o�́Q�t�@�C���g���q 
        /// </summary>
        private const string SFD_EXT = ".xls";
        /// <summary>
        /// ���[�o�́Q�N���f�B���N�g�� 
        /// </summary>
        private const string SFD_INITDIR = @"C:\";
        /// <summary>
        /// ���[�o�́Q�N���f�B���N�g��(�e���v���[�g�j
        /// </summary>
        private const string SFD_INITDIRTMP = @"C:\Temp\";
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
        private const string REP_XML_FILENAME = "Epson_SeikyuPlan_Data.xml";
        /// <summary>
        /// XML�t�@�C�����i�v���p�e�B�p�j 
        /// </summary>
        private const string REP_XML2_FILENAME = "Epson_SeikyuPlan_Prop.xml";
        /// <summary>
        /// Excel(���[�o�̓}�N������)�t�@�C���� 
        /// </summary>
        private const string REP_TEMPLATE_FILENAME = "Epson_SeikyuPlanTemplate.xlsx";
        /// <summary>
        /// Excel(���[�o�̓}�N������)�t�@�C���� 
        /// </summary>
        private const string REP_MACRO_FILENAME = "Epson_SeikyuPlanMcr.xlsm";

        /// <summary>
        /// ���[�ݒ���擾�L�[�F�ۑ��ꏊ�F002 
        /// </summary>
        private const string KV7_SYBT = "002";
        /// <summary>
        /// ���[�ݒ���擾�L�[�F�ۑ��ꏊ�FED-I0001 
        /// </summary>
        private const string KV7_SYBTFIELD1_ED = "ED-I0001";

        /// <summary>
        /// ���[�ݒ���擾�L�[�F�o�͒��[���F003 
        /// </summary>
        private const string KV7_SYBTSUB = "003";
        /// <summary>
        /// ���[�ݒ���擾�L�[�F�o�͒��[���F002 
        /// </summary>
        private const string KV7_SYBTFIELD1_002= "002";

        #endregion �萔 
      
        #region �����o�ϐ� 

        /// <summary>
        /// �i�r�p�����[�^ 
        /// </summary>
        private KKHNaviParameter _naviParameter = new KKHNaviParameter();

        /// <summary>
        /// �R�s�[�}�N���폜�p 
        /// </summary>
        private string _strmacrodel;

        #endregion �����o�ϐ� 

        #region �R���X�g���N�^ 

        /// <summary>
        /// �R���X�g���N�^ 
        /// </summary>
        public ReportEpsonSeikyuPlan()
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
        private void ReportEpsonSeikyuPlan_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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
        /// �t�H�[�����[�h�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportEpsonSeikyuPlan_Load(object sender, EventArgs e)
        {
            this.InitializeControl();
        }

        /// <summary>
        /// �{�^��MouseMove�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_MouseMove(object sender, MouseEventArgs e)
        {
            tslCnt.Text = njToolTip1.GetToolTip((Control)sender);
        }

        /// <summary>
        /// �{�^��MouseLeave�C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_MouseLeave(object sender, EventArgs e)
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
            Common.KKHSchema.Common.SystemCommonRow repInfo = this.GetReportInfo(KV7_SYBT, KV7_SYBTFIELD1_ED);
            // ���[�ݒ���擾�i�t�@�C�������ۑ��ꏊ�j
            Common.KKHSchema.Common.SystemCommonRow repInfoSub = this.GetReportInfo(KV7_SYBTSUB, KV7_SYBTFIELD1_002);

            // SaveFileDialog�N���X�̃C���X�^���X���쐬 
            SaveFileDialog sfd = new SaveFileDialog();

            // �͂��߂̃t�@�C�������w�肷�� 
            sfd.FileName = repInfoSub.field3 + DateTime.Now.ToString("yyyyMMdd") + SFD_EXT;

            // �͂��߂ɕ\�������t�H���_���w�肷�� 
            sfd.InitialDirectory = repInfoSub.field2;

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
                catch (IOException)
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
                this.ExcelOut(sfd.FileName, repInfo);
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
            //���Ӑ�R�[�h 
            string tkskgy = _naviParameter.strTksKgyCd + _naviParameter.strTksBmnSeqNo + _naviParameter.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //���s 
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Report, this, HelpNavigator.KeywordIndex);
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
        private void txtYm_Enter(object sender, EventArgs e)
        {
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
            txtYm.Value = yyyymm.Substring(0, 6);
            txtYm.cmbYM_SetDate();

            // �X�e�[�^�X�ݒ� 
            tslName.Text = _naviParameter.strName;
            tslDate.Text = _naviParameter.strDate;
        }

        /// <summary>
        /// �f�[�^�����E�\�����\�b�h 
        /// </summary>
        /// <returns>�������ʌ���</returns> 
        private int FindReportData()
        {
            ReportEpsonProcessController.FindReportEpsonSeikyuPlanByCondParam param =
                new ReportEpsonProcessController.FindReportEpsonSeikyuPlanByCondParam();

            // �p�����[�^�ݒ� 
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParameter.strEgcd;
            param.tksKgyCd = _naviParameter.strTksKgyCd;
            param.tksBmnSeqNo = _naviParameter.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParameter.strTksTntSeqNo;
            param.yymm = txtYm.Value;

            // ���[�i�G�v�\��_�����\��ꗗ�j�f�[�^���� 
            ReportEpsonProcessController processController = ReportEpsonProcessController.GetInstance();
            FindReportEpsonSeikyuPlanByCondServiceResult result = processController.FindReportEpsonSeikyuPlanByCond(param);

            if (result.HasError == true)
            {
                return 0;
            }

            _dsReport.ReportSeikyuPlan.Clear();
            _dsReport.ReportSeikyuPlan.Merge(result.ReportDataSet.ReportSeikyuPlan);
            _dsReport.ReportSeikyuPlan.AcceptChanges();

            if (result.ReportDataSet.ReportSeikyuPlan.Rows.Count == 0)
            {
                // �f�[�^�����݂��Ȃ��ꍇ��0��Ԃ� 
                return 0;
            }

            return result.ReportDataSet.ReportSeikyuPlan.Rows.Count;
        }

        /// <summary>
        /// Excel�o�̓��\�b�h 
        /// </summary>
        /// <param name="filnm">�t�@�C��</param>
        /// <param name="repInfo">���[�o�͐ݒ���</param>
        private void ExcelOut(string filnm, Common.KKHSchema.Common.SystemCommonRow repInfo)
        {
            string workFolderPath = repInfo.field2;
            string excelFile = string.Empty;
            string macroFile = workFolderPath + REP_MACRO_FILENAME;
            string templFile = workFolderPath + REP_TEMPLATE_FILENAME;
            DataRow dtRow;

            try
            {
                // Excel�J�n���� 
                // ���\�[�X����Excel�t�@�C�����쐬(�e���v���[�g�ƃ}�N��) 
                File.WriteAllBytes(templFile, Resources.Epson_SeikyuPlanTemplate);
                File.WriteAllBytes(macroFile, Resources.Epson_SeikyuPlanMcr);

                if (File.Exists(templFile) == false)
                {
                    throw new Exception("�e���v���[�gExcel�t�@�C��������܂���B");
                }
                if (File.Exists(macroFile) == false)
                {
                    throw new Exception("�}�N��Excel�t�@�C��������܂���B");
                }

                // �f�[�^�Z�b�gXML�o�� 
                _dsReport.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));

                // �p�����[�^XML�쐬�A�o�� 
                // �ϐ��̐錾
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // �f�[�^�Z�b�g�Ƀe�[�u����ǉ����� 
                // PRODUCTS�Ƃ����e�[�u�����쐬���܂� 
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                dtTable.Columns.Add("YYYYMM", Type.GetType("System.String"));

                //�e�[�u���Ƀf�[�^��ǉ����� 
                dtRow = dtTable.NewRow();

                dtRow["SAVEDIR"] = filnm;       // �ۑ��t�@�C�����i�t���p�X�j 
                dtRow["YYYYMM"] = txtYm.Value;      // �N�� 

                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //�G�N�Z���N�� 
                System.Diagnostics.Process.Start("excel", macroFile);

                //�폜�p�ɕێ��i�߂�{�^���������ɍ폜����ׁj 
                _strmacrodel = macroFile;

                // �I�y���[�V�������O�̏o��.
                KKHLogUtilityEpson.WriteOperationLogToDB(_naviParameter, APLID, KKHLogUtilityEpson.KINO_ID_OPERATION_LOG_REPORT_SEIKYU_PLAN, KKHLogUtilityEpson.DESC_OPERATION_LOG_REPORT_SEIKYU_PLAN);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ���[�o�͐ݒ���擾���\�b�h 
        /// </summary>
        /// <returns>���[�o�͐ݒ���</returns>
        private Common.KKHSchema.Common.SystemCommonRow GetReportInfo(string sybt, string field1)
        {
            string strsybt = sybt;//���:"002"or"003"
            string strfield1 = field1;//���:"ED-I0001"or"002"
            Common.KKHSchema.Common.SystemCommonRow ret;
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult;

            // ���[�ݒ���擾 
            comResult = commonProcessController.FindCommonByCond(_naviParameter.strEsqId,
                                                                _naviParameter.strEgcd,
                                                                _naviParameter.strTksKgyCd,
                                                                _naviParameter.strTksBmnSeqNo,
                                                                _naviParameter.strTksTntSeqNo,
                                                                strsybt,
                                                                strfield1);

            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                ret = comResult.CommonDataSet.SystemCommon[0];
            }
            else
            {
                // �擾�ł��Ȃ������ꍇ�̓f�t�H���g�l��ݒ� 
                Common.KKHSchema.Common.SystemCommonDataTable dt =
                    new Common.KKHSchema.Common.SystemCommonDataTable();
                ret = (Common.KKHSchema.Common.SystemCommonRow)dt.NewRow();

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ret[i] = string.Empty;
                }
            }

            return ret;
        }

        #endregion ���\�b�h 

    }
}