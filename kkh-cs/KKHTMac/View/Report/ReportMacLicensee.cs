using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Data;
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
using Isid.KKH.Common.KKHProcessController.Report;
using Isid.KKH.Mac.ProcessController.Report;
using Isid.KKH.Mac.Schema;
using Isid.KKH.Mac.Utility;

namespace Isid.KKH.Mac.View.Report
{
    public partial class ReportMacLicensee : KKHForm
    {
        #region �萔.

        /// <summary>
        /// �A�v��ID
        /// </summary>
        private static readonly string APLID = "Licensee";
        /// <summary>
        /// Excel(���[�o�̓}�N������)�t�@�C����.
        /// </summary>
        private static readonly string REP_MACRO_FILENAME ="Mac_Licensee.xlsm";
        /// <summary>
        /// Excel(���[�o�̓}�N���e���v���[�g)�t�@�C����.
        /// </summary>
        private static readonly string REP_TEMPLATE_FILENAME = "Mac_Licensee_Template.xlsx";
        /// <summary>
        /// XML�t�@�C����1
        /// </summary>
        private static readonly string REP_XML_FILENAME = "Mac_Licensee_Data.xml";
        /// <summary>
        /// XML�t�@�C����2
        /// </summary>
        private static readonly string REP_XML2_FILENAME = "Mac_Licensee_Prop.xml";

        #endregion �萔.

        #region �����o�ϐ�.

        /// <summary>
        /// �ۑ���p(�e���v���[�g)�ϐ�.
        /// </summary>
        private string pStrRepTempAdrs = "";
        /// <summary>
        /// �ۑ���p�ϐ�.
        /// </summary>
        private string pStrRepAdrs = "";
        /// <summary>
        /// ���[���i�ۑ��Ŏg�p�j�p�ϐ�.
        /// </summary>
        private string pStrRepFilNam = "";
        /// <summary>
        /// �i�r�p�����[�^�[.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// XML�쐬�p�f�[�^�Z�b�g.
        /// </summary>
        private DataSet MacLicenseeDs = new DataSet();
        /// <summary>
        /// �R�s�[�}�N���폜�pstring
        /// </summary>
        private string _strmacrodel;
        /// <summary>
        /// �����.
        /// </summary>
        private double _dbSyohizei;

        #endregion �����o�ϐ�.

        #region �R���X�g���N�^.

        public ReportMacLicensee()
        {
            InitializeComponent();
        }

        #endregion �R���X�g���N�^.

        #region �C�x���g.

        /// <summary>
        /// ��ʑJ�ڎ�.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportMacLicensee_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
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
        /// ��ʂ����߂ĕ\�����ꂽ�Ƃ��ɔ������܂�.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportMacLicensee_Shown(object sender, EventArgs e)
        {
            //���[�f�B���O�\���J�n.
            base.ShowLoadingDialog();

            //�e�R���g���[��������.
            InitializeControl();

            //�e�R���g���[���̕ҏW.
            EditControl();

            //****************************
            //����Ŏ擾.
            //****************************
            //����Ŏ擾�i�}�X�^����j
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
                                                                                            "005");

            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //�ۑ���Z�b�g.
                pStrRepAdrs = comResult2.CommonDataSet.SystemCommon[0].field2.ToString();
                //���̃Z�b�g.
                pStrRepFilNam = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
            }

            //���[�f�B���O�\���I��.
            base.CloseLoadingDialog();
        }

        /// <summary>
        /// �����{�^��Click�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSrc_Click(object sender, System.EventArgs e)
        {
            btnXls.Enabled = false;
            GetRecord();
        }

        /// <summary>
        /// Excel�{�^���N���b�N��.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, System.EventArgs e)
        {
            XlsFileSet();
        }

        /// <summary>
        /// �߂�{�^���N���b�N��.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, System.EventArgs e)
        {
            if (_strmacrodel != null)
            {
                System.IO.FileInfo cFileInfo = new System.IO.FileInfo(_strmacrodel);

                // �}�N���t�@�C���̍폜�iVBA���ł͍폜�ł��Ȃ��ׁj.
                // �t�@�C�������݂��Ă��邩���f����.
                if (cFileInfo.Exists)
                {
                    // �ǂݎ���p����������ꍇ�́A�ǂݎ���p��������������.
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

        /// <summary>
        /// �w���v�{�^���N���b�N�C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHlp_Click(object sender, EventArgs e)
        {
            //KKHHelpMac.ShowHelpMac(this, this.Name);
            string tkskgy = _naviParam.strTksKgyCd + _naviParam.strTksBmnSeqNo + _naviParam.strTksTntSeqNo;
            KKHUserManual.Helper.UserManualHelper help = new KKHUserManual.Helper.UserManualHelper();
            //���s.
            help.ProcessStart(tkskgy, KKHSystemConst.HelpLocation.Report, this, HelpNavigator.KeywordIndex);
            this.ActiveControl = null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtYm_Enter(object sender, EventArgs e)
        {
            //���[�o�͂�񊈐����ɂ���,
            btnXls.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDnpFr_TextChanged(object sender, EventArgs e)
        {
            //���[�o�͂�񊈐����ɂ���,
            btnXls.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDnpTo_TextChanged(object sender, EventArgs e)
        {
            //���[�o�͂�񊈐����ɂ���,
            btnXls.Enabled = false;
        }

        #endregion �C�x���g.

        #region ���\�b�h.

        /// <summary>
        /// �c�Ɠ����擾.
        /// </summary>
        /// <returns></returns>
        private string getHostDate()
        {
            string hostDate = "";

            CommonProcessController processController = CommonProcessController.GetInstance();
            hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return hostDate;
        }

        /// <summary>
        /// �e�R���g���[��������
        /// </summary>
        private void InitializeControl()
        {
            txtYm.Value = string.Empty;  //�N��.
            btnXls.Enabled = false;       //�G�N�Z���{�^��.
            txtDnpFr.Text = string.Empty; //�`�[�ԍ�From
            txtDnpTo.Text = string.Empty; //�`�[�ԍ�To
            statusStrip1.Items["tslval1"].Text = "0" + "��";          //�\������.
            dgvMain_Sheet1.Columns[12].Visible = false; //�����R�[�h�̔�\��.
            dgvMain_Sheet1.Columns[13].Visible = false;//�Z���Q�̔�\��.
        }

        /// <summary>
        /// �e�R���g���[���̕ҏW.
        /// </summary>
        private void EditControl()
        {
            //�N���̎擾.
            string strDate = getHostDate();
            //�X�e�[�^�X�̐ݒ�.
            //txtYm.Value = strDate.Substring(0, 6);
            //tslName.Text = KKHSecurityInfo.GetInstance().UserName;
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;
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
        /// �f�[�^����.
        /// </summary>
        private void GetRecord()
        {
            //���[�f�B���O�\���J�n.
            base.ShowLoadingDialog();

            //�N��.
            string yearmon = string.Empty;

            //�`�[�ԍ�From
            string dnpfr = txtDnpFr.Text;

            //�`�[�ԍ�To
            string dnpTo = txtDnpTo.Text;

            //�N���̃Z�b�g.
            yearmon = txtYm.Value;

            //�p�����[�^�[�̃Z�b�g.
            ReportMacProcessController.FindReportMacLicenseeByCondParam param = new ReportMacProcessController.FindReportMacLicenseeByCondParam();
            param.esqId = KKHSecurityInfo.GetInstance().UserEsqId;
            param.egCd = _naviParam.strEgcd;
            param.tksKgyCd = _naviParam.strTksKgyCd;
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;
            param.yymm = yearmon;
            param.denFr = dnpfr;
            param.denTo = dnpTo;

            ReportMacProcessController processController = ReportMacProcessController.GetInstance();
            FindReportMacLicenseeByCondServiceResult result = processController.FindRepMacLicenseeByCond(param);

            //�G���[�̏ꍇ.
            if (result.HasError)
            {
                //�I����Ԃ�����.
                this.ActiveControl = null;

                //���[�f�B���O�\���I��.
                base.CloseLoadingDialog();

                return;
            }
            //MacLicenseeDs = result.dsRepMacDataSet;
            Isid.KKH.Mac.Schema.RepDsMac.RepLicenseeRow[] datarow = (Isid.KKH.Mac.Schema.RepDsMac.RepLicenseeRow[])result.dsRepMacDataSet.RepLicensee.Select("", "");

            if (datarow.Length == 0)
            {
                //���[�f�B���O�\���I��.
                base.CloseLoadingDialog();
                MessageUtility.ShowMessageBox(MessageCode.HB_W0030, null, "���[", MessageBoxButtons.OK);
                //�\������
                statusStrip1.Items["tslval1"].Text = datarow.Length.ToString() + "��";
                dgvMain_Sheet1.DataSource = null;
                dgvMain_Sheet1.Rows.Count = 0;

                //�I����Ԃ�����.
                this.ActiveControl = null;

                return;
            }

            //dgvMain�f�[�^�X�V.
            UpdateDgvMainData(datarow);

            // 2014/02/05 add JSE K.Tamura start
            // �f�[�^�\�[�X�̂����ŁA����ŗ����\������Ă��܂��̂ŁA��\���ɂ���.
            dgvMain_Sheet1.Columns[14].Visible = false;
            // 2014/02/05 add JSE K.Tamura end

            //�\������.
            statusStrip1.Items["tslval1"].Text = datarow.Length.ToString() + "��";

            //���[�o�̓{�^��������.
            btnXls.Enabled = true;

            //�I����Ԃ�����.
            this.ActiveControl = null;

            //���[�f�B���O�\���I��.
            base.CloseLoadingDialog();
        }

        /// <summary>
        /// dgvMain�f�[�^�X�V.
        /// </summary>
        /// <param name="datarow"></param>
        private void UpdateDgvMainData(Isid.KKH.Mac.Schema.RepDsMac.RepLicenseeRow[] datarow)
        {
           //�\���p�f�[�^�e�[�u��.
           //Isid.KKH.Common.KKHSchema.RepDsMac.dgvLicenseeDataTable  rldt = new Isid.KKH.Common.KKHSchema.RepDsMac.dgvLicenseeDataTable();
            RepDsMac rldt = new RepDsMac();

            foreach (RepDsMac.RepLicenseeRow row in datarow)
            {
                //�\���p�f�[�^Row
                //Isid.KKH.Common.KKHSchema.RepDsMac.dgvLicenseeRow addrow = rldt.NewdgvLicenseeRow();
                RepDsMac.dgvLicenseeRow addrow = rldt.dgvLicensee.NewdgvLicenseeRow();
                //�����R�[�h.
                addrow.toriCd = row.field12;
                //���C�Z���V�[�Ж�.
                addrow.licenseeSyaName = row.field10;
                //�X�܃R�[�h.
                addrow.tenCd = row.code1;
                //�X�ܖ�.
                addrow.tenName = row.name3;
                //���㖾��No.
                addrow.uriMeiNo = row.jyutNo + "-" + row.jymeiNo + "-" + row.urMeiNo;
                //�Z��.
                addrow.adress = row.field4 + " " + row.field20;
                //addrow.adress = row.field4 + " " + row.field5;
                //�Z���Q.
                addrow.adress2 = row.field6;
                //�����P + �����Q.
                addrow.kenName = row.name1 + row.name2;
                //����.
                //addrow.kenName = row.name1;
                //��\�Җ�.
                addrow.representName = row.field11;
                //����.
                addrow.suRyo = double.Parse(row.kngk2).ToString("###,###,###,##0");
                //addrow.suRyo = row.kngk2;

                //�����[�R�[�h���P�̏ꍇ.
                if (row.sonota2 == "1")
                {
                    //�P����\�����Ȃ�.
                    addrow.tanka = "";
                }
                else
                {
                    //100���ȏ�̏ꍇ.
                    if (Isid.KKH.Common.KKHUtility.KKHUtility.IntParse(row.kngk1) >= 1000000)
                    {
                        //�P����\�����Ȃ�.
                        addrow.tanka = "";
                    }
                    else
                    {
                        //�P��.
                        addrow.tanka = row.kngk1;
                    }
                }
                //���z(������1�ʂŎl�̌ܓ�).
                addrow.kngk = Math.Round(decimal.Parse(row.seiGak),0,MidpointRounding.AwayFromZero).ToString("###,###,###,##0");
                //addrow.kngk = row.seiGak;
                //�`�[�ԍ�.
                addrow.denpyoNum = row.sonota1;
                //�����R�[�h.
                addrow.bunCd = row.sonota2;
                //�����Q.
                //rldt.AdddgvLicenseeRow(addrow);
                rldt.dgvLicensee.AdddgvLicenseeRow(addrow);

                //����őΉ� 2013/10/29 add HLC H.Watabe start
                addrow.Ritu1 = row.Ritu1;
                //����őΉ� 2013/10/29 add HLC H.Watabe end
            }

            MacLicenseeDs = rldt;
            dgvMain_Sheet1.DataSource = rldt.dgvLicensee;
        }

        /// <summary>
        /// �G�N�Z���o�͂̃t�@�C���ݒ�.
        /// </summary>
        private void XlsFileSet()
        {
            //�t�@�C���ۑ��ꏊ�ݒ�N���X�̃C���X�^���X��.
            SaveFileDialog sfd = new SaveFileDialog();
            //���ݓ���.
            DateTime nowdate = DateTime.Now;
            //�����t�@�C����.
            sfd.FileName =  pStrRepFilNam + "_" + nowdate.ToString("yyyyMMdd") + ".xlsx";
            //sfd.FileName = nowdate.ToString("yyyyMMdd") + pStrRepFilNam + ".xlsx";
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

            //�_�C�A���O��\�����AOk�{�^�����������ꂽ��.
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                //�o�͐�ɓ�����Excel�t�@�C�����J���Ă��邩�`�F�b�N.
                try
                {
                    //�����Ńt�@�C�����폜����B.
                    File.Delete(sfd.FileName);
                }
                catch (IOException)
                {
                    //�I����Ԃ�����.
                    this.ActiveControl = null;

                    //�o�͐�ɓ�����Excel�t�@�C�����J���Ă��܂��B���Ă���ēx�o�͂��Ă��������B.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, "���[", MessageBoxButtons.OK);
                    return;
                }

                //*************************************
                // �o�͎��s.
                //*************************************
                this.ExcelOut(sfd.FileName);
            }

            //�I����Ԃ�����.
            this.ActiveControl = null;

            //���\�[�X�̉��.
            sfd.Dispose();
        }

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
                // Excel�J�n����.
                // ���\�[�X����Excel�t�@�C�����쐬(�e���v���[�g�ƃ}�N��).
                File.WriteAllBytes(macrofile, Isid.KKH.Mac.Properties.Resources.Mac_Licensee);
                File.WriteAllBytes(tempfile, Isid.KKH.Mac.Properties.Resources.Mac_Licensee_Template);

                if (System.IO.File.Exists(tempfile) == false) { throw new Exception("�e���v���[�gExcel�t�@�C��������܂���B"); }
                if (System.IO.File.Exists(macrofile) == false) { throw new Exception("�}�N��Excel�t�@�C��������܂���B"); }

                //�f�[�^�Z�b�gXML�o��.
                MacLicenseeDs.WriteXml(Path.Combine(workFolderPath, REP_XML_FILENAME));

                // �p�����[�^XML�쐬�A�o��.
                // �ϐ��̐錾.
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // �f�[�^�Z�b�g�Ƀe�[�u����ǉ�����.
                // PRODUCTS�Ƃ����e�[�u�����쐬���܂�.
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("USERNAME", Type.GetType("System.String"));
                dtTable.Columns.Add("SELHDK", Type.GetType("System.String"));
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));
                dtTable.Columns.Add("SYOHIZEI", Type.GetType("System.String"));

                //�e�[�u���Ƀf�[�^��ǉ�����.
                dtRow = dtTable.NewRow();

                dtRow["SAVEDIR"] = filenm;
                dtRow["SYOHIZEI"] = _dbSyohizei.ToString();
                dtRow["USERNAME"] = tslName.Text;
                dtRow["SELHDK"] = txtYm.Year + "�N" + txtYm.Month + "��";
                dtTable.Rows.Add(dtRow);
                dtSet.WriteXml(Path.Combine(workFolderPath, REP_XML2_FILENAME));

                //�G�N�Z���N��.
                System.Diagnostics.Process.Start("excel", workFolderPath + REP_MACRO_FILENAME);

                //�폜�p�ɕێ��i�߂�{�^���������ɍ폜����ׁj.
                _strmacrodel = workFolderPath + REP_MACRO_FILENAME;

                //���O�̏o��.
                KKHLogUtilityMac.WriteOperationLogToDB(_naviParam, APLID, KKHLogUtilityMac.KINO_ID_OPERATION_LOG_Licensee, KKHLogUtilityMac.DESC_OPERATION_LOG_Licensee);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion ���\�b�h
    }
}

