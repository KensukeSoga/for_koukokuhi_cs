using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Control.YmMaskedTextBox;
using Isid.KKH.Common.KKHView.Common.Form;

using Isid.KKH.Lion.Schema;
using Isid.KKH.Lion.Utility;
using Isid.KKH.Lion.ProcessController.Report;
using Isid.KKH.Lion.Properties;

namespace Isid.KKH.Lion.View.Report
{
    /// <summary>
    /// ���Ӑ惉�C�I���󒍔�r�ꗗ���[�o��.
    /// </summary>
    /// <remarks>
    ///   �C���Ǘ�.
    ///   <list type="table">
    ///     <listheader>
    ///       <description>���t</description>
    ///       <description>�C����</description>
    ///       <description>���e</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2014/11/10</description>
    ///       <description>HLC S.Fujimoto</description>
    ///       <description>�V�K�쐬</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class ReportOrderDiffLion : KKHForm
    {
        #region �萔.

        /// <summary>
        /// �A�v��ID
        /// </summary>
        private const String APLID = "OrdDif";

        /// <summary>
        /// �󒍔�r�ꗗ���[Excel�}�N���t�@�C����.
        /// </summary>
        private static readonly string REP_ORDER_DIFF_MACRO_FILENAME = "Lion_OrderDiff_Mcr.xlsm";
        /// <summary>
        /// �󒍔�r�ꗗ���[Excel�e���v���[�g�t�@�C����.
        /// </summary>
        private static readonly string REP_ORDER_DIFF_TEMPLATE_FILENAME = "Lion_OrderDiff_Template.xlsx";
        /// <summary>
        /// �󒍔�r�ꗗ���[�f�[�^XML�t�@�C����.
        /// </summary>
        private static readonly string REP_ORDER_DIFF_DATA_XML_FILENAME = "Lion_OrderDiff_Data.xml";
        /// <summary>
        /// �󒍔�r�ꗗ���[�v���p�e�BXML�t�@�C����.
        /// </summary>
        private static readonly string REP_ORDER_DIFF_PROP_XML_FILENAME = "Lion_OrderDiff_Prop.xml";

        /// <summary>
        /// �󒍔�r�ꗗ���[�F006(���[�o�͏�񒊏o�p)
        /// </summary>
        private const string REP_KEY_SYBT = "006";

        #region �o�͒��[��.

        /// <summary>
        /// �P�����쎺���X�g.
        /// </summary>
        private const String ORDER_DIFF = "�󒍔�r�ꗗ";

        #endregion �o�͒��[��.

        #endregion �萔.

        #region �����o�ϐ�.

        /// <summary>
        /// Navi�p�����[�^.
        /// </summary>
        private KKHNaviParameter _naviParam = new KKHNaviParameter();
        /// <summary>
        /// �}�X�^�p�f�[�^�Z�b�g.
        /// </summary>
        private MastLion MastLionDs = new MastLion();
        /// <summary>
        /// ���[�o�̓��X�g�p�f�[�^�Z�b�g.
        /// </summary>
        private OrderDiffLion orderDiffDsLion = new OrderDiffLion();
        /// <summary>
        /// Excel�}�N���t�@�C����.
        /// </summary>
        private string _mStrMacroFileNm;
        /// <summary>
        /// Excel�e���v���[�g�t�@�C����.
        /// </summary>
        private string _mStrTemplateFileNm;

        /// <summary>
        /// ���[�o�͖�.
        /// </summary>
        private string _mStrOutReportNm;
        /// <summary>
        /// �ۑ���p(�e���v���[�g)�ϐ�.
        /// </summary>
        private string _mStrRepTempAdrs = string.Empty;
        /// <summary>
        /// �ۑ���p�ϐ�.
        /// </summary>
        private string _mStrRepAdrs = string.Empty;
        /// <summary>
        /// �󒍔�r���[���ϐ�.
        /// </summary>
        private string _mStrRepFileNm = string.Empty;

        #endregion �����o�ϐ�.

        #region �R���X�g���N�^.

        /// <summary>
        /// �R���X�g���N�^.
        /// </summary>
        public ReportOrderDiffLion()
        {
            InitializeComponent();
        }

        #endregion �R���X�g���N�^.

        #region �C�x���g.

        /// <summary>
        /// ��ʕ\�����C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ReportOrderDiffLion_ProcessAffterNavigating(object sender, Isid.NJ.View.Base.NavigationEventArgs arg)
        {
            //�p�����[�^�擾.
            if (arg.NaviParameter is KKHNaviParameter)
            {
                _naviParam = (KKHNaviParameter)arg.NaviParameter;
            }
        }

        /// <summary>
        /// ��ʃ��[�h���C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportOrderDiffLion_Shown(object sender, EventArgs e)
        {
            base.ShowLoadingDialog();

            //�����N���擾.
            string hostdate = getHostDate();
            txtYm.Value = hostdate.Substring(0, 6);

            //�����N���R���{�{�b�N�X�ݒ�.
            txtYm.cmbYM_SetDate();

            //�X�e�[�^�X�ݒ�.
            tslName.Text = _naviParam.strName;
            tslDate.Text = _naviParam.strDate;

            //����Ŏ擾�i�}�X�^����j.
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            KKHSystemConst.TempDir.MainType,
                                                                                            "ED-I0001");

            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {

                //�e���v���[�g�A�h���X.
                _mStrRepTempAdrs = comResult.CommonDataSet.SystemCommon[0].field2.ToString();
            }

            //�ۑ����{���[��.
            CommonProcessController commonProcessController2 = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult2 = commonProcessController2.FindCommonByCond(
                                                                                            _naviParam.strEsqId,
                                                                                            _naviParam.strEgcd,
                                                                                            _naviParam.strTksKgyCd,
                                                                                            _naviParam.strTksBmnSeqNo,
                                                                                            _naviParam.strTksTntSeqNo,
                                                                                            KKHSystemConst.TempDir.ReportType,
                                                                                            REP_KEY_SYBT);

            if (comResult2.CommonDataSet.SystemCommon.Count != 0)
            {
                //�ۑ���Z�b�g.
                _mStrRepAdrs = comResult2.CommonDataSet.SystemCommon[0].field2.ToString();
                //�󒍔�r�ꗗ���[��.
                _mStrRepFileNm = comResult2.CommonDataSet.SystemCommon[0].field3.ToString();
            }

            //*************************
            //���C�I���}�X�^�̎擾.
            //*************************
            KKHLionReadMastFile mast = new KKHLionReadMastFile();
            MastLionDs = mast.GetLionMast(_naviParam);

            if (MastLionDs.TvBnLion.Count == 0 &&
                MastLionDs.RdBnLion.Count == 0 &&
                MastLionDs.TvKLion.Count == 0 &&
                MastLionDs.RdKLion.Count == 0)
            {
                base.CloseLoadingDialog();
                Navigator.Backward(this, null, _naviParam, true);
                return;
            }

            base.CloseLoadingDialog();
        }

        #region ���[�o�̓{�^��.

        /// <summary>
        /// ���[�o��.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXls_Click(object sender, EventArgs e)
        {
            //���b�Z�[�W�^�C�g��.
            String strMsgCaption = String.Empty;

            //SaveFileDialog�N���X�̃C���X�^���X����.
            SaveFileDialog sfd = new SaveFileDialog();

            //�{�����t.
            DateTime now = DateTime.Now;

            //�o�͗p�N��.
            string strOutYymm = string.Empty;
            string strTmpYymm = txtYm.Value;
            int intTmpMm = int.Parse(strTmpYymm.Substring(4, 2));
            strOutYymm = strTmpYymm.Substring(0, 4) + "." + intTmpMm.ToString();

            //�o�̓t�@�C����.
            sfd.FileName = _mStrRepFileNm.Replace("@@@", strOutYymm) + "�@" + now.ToString("yyyy.MM.dd") + ".xls";
            //���b�Z�[�W�^�C�g��.
            strMsgCaption = ORDER_DIFF;

            //�f�t�H���g�\������t�H���_���w��.
            sfd.InitialDirectory = _mStrRepAdrs;

            //[�t�@�C���̎��]�ɕ\�������t�@�C����ʎw��.
            sfd.Filter = "XLS�t�@�C��(*.xls)|*.xls";

            //[�t�@�C���̎��]�ł͂��߂Ɂu���ׂẴt�@�C���v���I������Ă���悤�ɂ���.
            sfd.FilterIndex = 0;

            //�^�C�g���ݒ�.
            sfd.Title = "�ۑ���̃t�@�C����ݒ肵�ĉ������B";

            //�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���.
            sfd.RestoreDirectory = true;

            //�_�C�A���O�\��.
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //�o�͐�ɓ�����Excel�t�@�C�����J���Ă��邩�`�F�b�N.
                try
                {
                    //�����t�@�C�����폜.
                    File.Delete(sfd.FileName);
                }
                catch (IOException)
                {
                    //�o�͐�ɓ�����Excel�t�@�C�����J���Ă��܂��B���Ă���ēx�o�͂��Ă��������B.
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0137, null, strMsgCaption, MessageBoxButtons.OK);
                    return;
                }

                //�f�[�^�擾.
                if (!GetRecord())
                {
                    //�����I��.
                    return;
                }

                //*************************************
                // �o�͎��s.
                //*************************************
                this.ExcelOut(sfd.FileName, now);
            }

            sfd.Dispose();

            //�R���g���[���𖢑I����Ԃɂ���.
            this.ActiveControl = null;
        }

        #endregion ���[�o�̓{�^��.

        #region �߂�{�^��.

        /// <summary>
        /// �߂�{�^��������.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetrun_Click(object sender, EventArgs e)
        {
            if (_mStrMacroFileNm != null)
            {
                System.IO.FileInfo cFileInfo = new System.IO.FileInfo(_mStrMacroFileNm);

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

        #endregion �߂�{�^��.

        #region �w���v�{�^��.

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

        #endregion �w���v�{�^��.

        #endregion �C�x���g.

        #region ���\�b�h.

        #region �c�Ɠ��擾.

        /// <summary>
        /// �c�Ɠ����擾.
        /// </summary>
        /// <returns></returns>
        private string getHostDate()
        {
            String _hostDate = String.Empty;

            CommonProcessController processController = CommonProcessController.GetInstance();
            _hostDate = processController.GetEigyoBi(KKHSecurityInfo.GetInstance().UserEsqId);

            return _hostDate;
        }

        #endregion �c�Ɠ��擾.

        #region ���R�[�h�擾.

        /// <summary>
        /// ���R�[�h�擾.
        /// </summary>
        private bool GetRecord()
        {
            //���[�f�B���O�\���J�n.
            base.ShowLoadingDialog();

            //�N���̎擾.
            string yyyyMm = txtYm.Value;

            //*******************
            //�f�[�^�擾.
            //*******************
            //�󒍔�r�ꗗ�擾.
            orderDiffDsLion = FindOrderDiffList(yyyyMm);

            if (orderDiffDsLion.OrderDiffList.Rows.Count == 0 &&
                orderDiffDsLion.OrderNewList.Rows.Count == 0 &&
                orderDiffDsLion.OrderAmountDiffList.Rows.Count == 0)
            {
                 //���b�Z�[�W�FHB-W0023 �Y������f�[�^������܂���B.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0023, null, this.Text, MessageBoxButtons.OK);
                return false;
            }

            //���[�f�B���O�\���I��.
            base.CloseLoadingDialog();
            return true;
        }

        #endregion ���R�[�h�擾.

        #region Excel�o��.

        /// <summary>
        /// Excel�o�̓��\�b�h.
        /// </summary>
        /// <param name="strFileNm">�o�̓t�@�C����</param>
        private void ExcelOut(string strFileNm, DateTime dt)
        {
            DataRow dtRow;

            //�}�N���t�@�C�����ݒ�.
            _mStrMacroFileNm = _mStrRepTempAdrs + REP_ORDER_DIFF_MACRO_FILENAME;
            //�e���v���[�g�t�@�C�����ݒ�.
            _mStrTemplateFileNm = _mStrRepTempAdrs + REP_ORDER_DIFF_TEMPLATE_FILENAME;

            try
            {
                //Excel�J�n����.
                //���\�[�X����Excel�t�@�C�����쐬.
                //�}�N���t�@�C��.
                File.WriteAllBytes(_mStrMacroFileNm, Resources.Lion_OrderDiff_Mcr);
                //�e���v���[�g�t�@�C��.
                File.WriteAllBytes(_mStrTemplateFileNm, Resources.Lion_OrderDiff_Template);

                //�}�N���t�@�C���E�e���v���[�g�t�@�C�����݊m�F(�o�̓t�H���_��).
                if (!System.IO.File.Exists(_mStrMacroFileNm))
                {
                    throw new Exception("�}�N��Excel�t�@�C��������܂���B");
                }
                if (!System.IO.File.Exists(_mStrTemplateFileNm))
                {
                    throw new Exception("�e���v���[�gExcel�t�@�C��������܂���B");
                }

                // �f�[�^�Z�b�gXML�o��.
                orderDiffDsLion.WriteXml(Path.Combine(_mStrRepTempAdrs, REP_ORDER_DIFF_DATA_XML_FILENAME));

                // �p�����[�^XML�쐬.
                // �ϐ��̐錾.
                DataSet dtSet = new DataSet("PRODUCTS");
                DataTable dtTable;

                // �f�[�^�Z�b�g�Ƀe�[�u����ǉ�.
                // PRODUCTS�e�[�u�����쐬.
                dtTable = dtSet.Tables.Add("PRODUCTS");
                dtTable.Columns.Add("USERNAME", Type.GetType("System.String")); //���[�U�[��.
                dtTable.Columns.Add("YYMM", Type.GetType("System.String"));     //�����N��.
                dtTable.Columns.Add("SAVEDIR", Type.GetType("System.String"));  //�ۑ��ꏊ.

                //�e�[�u���Ƀf�[�^��ǉ�.
                dtRow = dtTable.NewRow();
                dtRow["USERNAME"] = tslName.Text;
                dtRow["YYMM"] = txtYm.Value;
                dtRow["SAVEDIR"] = strFileNm;
                dtTable.Rows.Add(dtRow);

                //�p�����[�^��XML�o��.
                dtSet.WriteXml(Path.Combine(_mStrRepTempAdrs, REP_ORDER_DIFF_PROP_XML_FILENAME));

                //�G�N�Z���N��.
                System.Diagnostics.Process.Start("excel", _mStrRepTempAdrs + REP_ORDER_DIFF_MACRO_FILENAME);

                //�I�y���[�V�������O�̏o��.
                //�ǉ��ύX���X�g�̏ꍇ.
                KKHLogUtility.WriteOperationLogToDB(_naviParam,
                                                    APLID,
                                                    KKHLogUtilityLion.KIND_ID_OPERATION_LOG_ORDERDIFFLIST,
                                                    KKHLogUtilityLion.DESC_OPERATION_LOG_ORDERDIFFLIST);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Excel�o��.

        #region �󒍔�r�ꗗ�擾.

        /// <summary>
        /// �󒍔�r�ꗗ�擾.
        /// </summary>
        /// <param name="yymm">�N��</param>
        /// <returns>�󒍔�r�ꗗDataSet</returns>
        private OrderDiffLion FindOrderDiffList(String yymm)
        {
            //�󒍔�r�ꗗ�擾.
            ReportLionProcessController controller = ReportLionProcessController.GetInstance();

            ReportLionProcessController.FindOrderDiffListParam param = new ReportLionProcessController.FindOrderDiffListParam();
            param.esqId = _naviParam.strEsqId;              //ESQ-ID.
            param.egCd = _naviParam.strEgcd;                //�c�Ə��R�[�h.
            param.tksKgyCd = _naviParam.strTksKgyCd;        //���Ӑ��ƃR�[�h.
            param.tksBmnSeqNo = _naviParam.strTksBmnSeqNo;  //���Ӑ敔��SEQNO.
            param.tksTntSeqNo = _naviParam.strTksTntSeqNo;  //���Ӑ�S��SEQNO.
            param.yymm = yymm;                              //�N��.

            FindOrderDiffListByCondServiceResult result = controller.findOrderDiffList(param);

            return result.dsOrdDiffListLionDataSet;
        }

        #endregion �󒍔�r�ꗗ�擾.

        #endregion ���\�b�h.
    }
}

