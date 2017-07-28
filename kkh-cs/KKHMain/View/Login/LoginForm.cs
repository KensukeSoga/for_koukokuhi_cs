using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.NJSecurity.Core;
using Isid.KKH.Common.KKHProcessController.SystemCommon;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHView.Top;
using Isid.NJ.View.Navigator;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.NJSecurity.Connection.WebService.Proxy.Stateful;
using Isid.KKH.Main.ProcessController.Login;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Main.ProcessController.Login.Parser;
using Isid.KKH.Main.Utility;
using System.Drawing.Drawing2D;

namespace Isid.KKH.Main.View.Login
{
    /// <summary>
    /// ���O�C���ʖ�.
    /// </summary>
    public partial class LoginForm : KKHDialogBase, INaviParameter
    {
        #region �萔.
        #region �Œ蕶��.
        /// <summary>
        /// ���O�C��.
        /// </summary>
        private const string LOGIN = "���O�C��";
        /// <summary>
        /// �Ǘ��҃��[�U�[.
        /// </summary>
        private const string ADMIN_TANTOU = "@@@";
        #endregion �Œ蕶��.
        #endregion �萔.

        #region �����o�[�ϐ�.
        /// <summary>
        /// �������O�C�����.
        /// </summary>
        private loginInitInfoResult _loginInitInfoResult = null;
        /// <summary>
        /// ���O�C�����.
        /// </summary>
        private LoginServiceResult _loginServiceResult = null;
        /// <summary>
        /// ���O�C�����Ӑ���.
        /// </summary>
        private Isid.KKH.Main.Schema.Login.LoginCustomerDataRow _loginCustomerDataRow = null;
        /// <summary>
        /// ��ʓǍ����������܂�.
        /// </summary>
        private KKHNaviParameter inNaviParameter = new KKHNaviParameter();
        #endregion �����o�[�ϐ�.

        #region �R���X�g���N�^.
        /// <summary>
        /// �R���X�g���N�^.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }
        #endregion �R���X�g���N�^.

        #region �C�x���g.
        #region ��ʓǍ��ݎ��C�x���g.
        /// <summary>
        /// ��ʓǍ��ݎ��C�x���g.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            //�����ݒ�.
            LoginProcessController.GetLoginInitInfoParam param = new LoginProcessController.GetLoginInitInfoParam();
            // ESQID.
            KKHSecurityInfo kKHSecurityInfo = KKHSecurityInfo.GetInstance();
            param.esqId = kKHSecurityInfo.UserEsqId;
            //�^�pNo.
            ISecurityInfo iSecurityInfo = kKHSecurityInfo.SecurityInfo;
            IUserInfo iUserInfo = iSecurityInfo.GetUserInfo();
            IUserProfile iUserProfile = iUserInfo.UserProfile;
            param.operationNo = iUserProfile.OrganizationCode;
            //���O�C���������擾.
            LoginProcessController processController = LoginProcessController.GetInstance();
            loginInitInfoResult result = processController.GetLoginInitInfo(param);
            //�G���[�̏ꍇ.
            if (result.errorInfo != null && result.errorInfo.error)
            {
                MessageUtility.ShowMessageBox(result.errorInfo.errorCode, null, LOGIN, MessageBoxButtons.OK);
                this.Close();
                return;
            }
            //�Ɩ���v����~���̏ꍇ.
            if (result.accountOperationStatus == false)
            {
                MessageUtility.ShowMessageBox(MessageCode.HB_W0097, null, LOGIN, MessageBoxButtons.OK);
            }
            _loginInitInfoResult = result;

            //�Ǘ��҂�ESQID�̏ꍇ.
            if (kKHSecurityInfo.NotSecurityRoleFlag == true)
            {
                txtTan.Text = iUserInfo.TantoCode;
                txtTan.Enabled = true;
                txtTan.BackColor = Color.FromKnownColor(KnownColor.Window);
                txtTan.SelectAll();
                txtTan.Focus();
                txtPass.Enabled = true;
                txtPass.BackColor = Color.FromKnownColor(KnownColor.Window);
                txtTkicd.Text = "";
            }
            //���̑���ESQID�̏ꍇ.
            else
            {
                txtTan.Text = iUserInfo.TantoCode;
                txtTkicd.Focus();
            }

            //�t�H�[���̌`��ύX.
            UpdateFormFormat();
        }
        #endregion ��ʓǍ��ݎ��C�x���g.

        #region OK�{�^���N���b�N�C�x���g.
        /// <summary>
        /// OK�{�^���N���b�N�C�x���g.
        /// </summary>
        /// <param name="sender">�{�^���R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            //���̓`�F�b�N.
            if (!chekInputItem())
            {
                return;
            }

            //���O�C������.
            if (!login())
            {
                return;
            }

            //���j���[��ʕ\��.
            displayMenu();
        }
        #endregion OK�{�^���N���b�N�C�x���g.

        #region CANCEL�{�^���N���b�N�C�x���g.
        /// <summary>
        /// CANCEL�{�^���N���b�N�C�x���g.
        /// </summary>
        /// <param name="sender">�{�^���R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        private void btnCan_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion CANCEL�{�^���N���b�N�C�x���g.

        #region �S���҃R�[�h�ύX���C�x���g.
        /// <summary>
        /// �S���҃R�[�h�ύX���C�x���g.
        /// </summary>
        /// <param name="sender">�{�^���R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        private void txtTan_TextChanged(object sender, EventArgs e)
        {
            txtTan.Text = KKHUtility.RemoveProhibitionChar(txtTan.Text);
            int len = txtTan.MaxLength;
            txtTan.SelectionStart = len;
        }
        #endregion �S���҃R�[�h�ύX���C�x���g.

        #region ���Ӑ�R�[�h�ύX���C�x���g.
        /// <summary>
        /// ���Ӑ�R�[�h�ύX���C�x���g.
        /// </summary>
        /// <param name="sender">�{�^���R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        private void txtTkicd_TextChanged(object sender, EventArgs e)
        {
            //�����ݒ�.
            txtTkicd.Text = KKHUtility.RemoveProhibitionChar(txtTkicd.Text);
            int len = txtTkicd.MaxLength;
            txtTkicd.SelectionStart = len;

            //���Ӑ�R�[�h��[@@@@@@@@]�̏ꍇ.
            if (txtTkicd.Text == "@@@@@@@@")
            {
                txtTan.Enabled = true;
                txtTan.BackColor = Color.FromKnownColor(KnownColor.Window);
                txtTan.SelectAll();
                txtTan.Focus();
                txtPass.Enabled = true;
                txtPass.BackColor = Color.FromKnownColor(KnownColor.Window);
                txtTkicd.Text = "";
            }

            //���Ӑ�R�[�h��8���̏ꍇ.
            if (txtTkicd.Text.Length == 8)
            {
                LoginProcessController.GetCustomerInfoParam param = new LoginProcessController.GetCustomerInfoParam();
                KKHSecurityInfo kKHSecurityInfo = KKHSecurityInfo.GetInstance();
                param.esqId = kKHSecurityInfo.UserEsqId;
                param.customerCode = txtTkicd.Text;
                //���Ӑ���擾.
                LoginProcessController processController = LoginProcessController.GetInstance();
                customerInfoResult result = processController.GetCustomerInfo(param);

                //�G���[�̏ꍇ.
                if (result.errorInfo != null && result.errorInfo.error)
                {
                    MessageUtility.ShowMessageBox(result.errorInfo.errorCode, null, LOGIN, MessageBoxButtons.OK);
                    txtTkicd.SelectAll();
                    lblTkinm.Text = "";
                }
                //�G���[�łȂ��ꍇ.
                else
                {
                    lblTkinm.Text = result.customerName;
                }
            }
            else
            {
                lblTkinm.Text = "";
            }
        }
        #endregion ���Ӑ�R�[�h�ύX���C�x���g.
        #endregion �C�x���g

        #region ���\�b�h.
        #region ���͍��ڃ`�F�b�N.
        /// <summary>
        /// ���͍��ڃ`�F�b�N.
        /// </summary>
        private bool chekInputItem()
        {
            //�S���҃R�[�h�������͂̏ꍇ.
            if (string.IsNullOrEmpty(txtTan.Text))
            {
                //�x�����b�Z�[�W��\��.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0098, null, LOGIN, MessageBoxButtons.OK);
                txtTan.Focus();
                return false;
            }
            //���Ӑ於�̂��\������Ă��Ȃ��ꍇ.
            if (string.IsNullOrEmpty(lblTkinm.Text))
            {
                //�x�����b�Z�[�W��\��.
                MessageUtility.ShowMessageBox(MessageCode.HB_W0099, null, LOGIN, MessageBoxButtons.OK);
                txtTkicd.SelectAll();
                txtTkicd.Focus();
                return false;
            }

            return true;
        }
        #endregion ���͍��ڃ`�F�b�N.

        #region ���O�C������.
        /// <summary>
        /// ���O�C������.
        /// </summary>
        private bool login()
        {
            //�����ݒ�.
            LoginProcessController.LoginParam loginParam = new LoginProcessController.LoginParam();
            KKHSecurityInfo kKHSecurityInfo = KKHSecurityInfo.GetInstance();
            loginParam.esqId = kKHSecurityInfo.UserEsqId;
            ISecurityInfo iSecurityInfo = kKHSecurityInfo.SecurityInfo;
            IUserInfo iUserInfo = iSecurityInfo.GetUserInfo();
            IUserProfile iUserProfile = iUserInfo.UserProfile;
            loginParam.operationNo = iUserProfile.OrganizationCode;
            loginParam.userId = txtTan.Text;
            loginParam.password = txtPass.Text;
            loginParam.customerCode = txtTkicd.Text;

            //�X�[�p�[���[�U�[�A���ʃ��O�C�����[�U�[�̏ꍇ.
            if (txtTan.Enabled)
            {
                loginParam.normalUserFlag = KkhConstMain.Flag.OFF;
            }
            //�ʏ탆�[�U�[�̏ꍇ.
            else
            {
                loginParam.normalUserFlag = KkhConstMain.Flag.ON;
            }
            loginParam.relativeAuthority = kKHSecurityInfo.RelativeAuthority;
            loginParam.organizationCode = _loginInitInfoResult.organizationCode;
            loginParam.eigyoBi = _loginInitInfoResult.eigyoBi;

            //���O�C������.
            LoginProcessController processController = LoginProcessController.GetInstance();
            _loginServiceResult = processController.Login(loginParam);

            //�G���[�̏ꍇ.
            if (_loginServiceResult.HasError)
            {
                //�x�����b�Z�[�W��\��.
                MessageUtility.ShowMessageBox(_loginServiceResult.MessageCode, null, LOGIN, MessageBoxButtons.OK);

                //���b�Z�[�W���x�����G���[�ȊO�̏ꍇ.
                if (_loginServiceResult.MessageCode.Substring(3, 1) != KKHSystemConst.MessageLevel.Error)
                {
                    txtTkicd.SelectAll();
                    txtTkicd.Focus();
                }

                return false;
            }

            //���[�U�[�^�C�v�̐ݒ�.
            inNaviParameter.StrSystemAdministerFlg = _loginServiceResult.SystemAdministerFlg;

            //���Ӑ悪1���̏ꍇ.
            if (_loginServiceResult.LoginCustomerDataSet.LoginCustomerData.Count == 1)
            {
                _loginCustomerDataRow = _loginServiceResult.LoginCustomerDataSet.LoginCustomerData[0];
            }
            //���Ӑ悪�������̏ꍇ.
            else
            {
                //�����ݒ�.
                LoginNaviParameter naviParam = new LoginNaviParameter();
                naviParam.strEsqId = kKHSecurityInfo.UserEsqId;
                naviParam.strEgcd = _loginServiceResult.EgCd;
                naviParam.loginCustomerDataDataTable = _loginServiceResult.LoginCustomerDataSet.LoginCustomerData;

                //���Ӑ�I����ʕ\��.
                object customerSelectResult = Navigator.ShowModalFormByName(this, "LoginCustomerSelect", naviParam);
                _loginCustomerDataRow = _loginServiceResult.LoginCustomerDataSet.LoginCustomerData[0];
                LoginProcessController.GetOpenCustomerInfoParam openCustomerInfoParam = new LoginProcessController.GetOpenCustomerInfoParam();
                openCustomerInfoParam.esqId = kKHSecurityInfo.UserEsqId;
                openCustomerInfoParam.egCd = _loginServiceResult.EgCd;
                int rowIndex = naviParam.loginCustomerDataIndex;
                _loginCustomerDataRow = _loginServiceResult.LoginCustomerDataSet.LoginCustomerData[rowIndex];
                openCustomerInfoParam.tksKgyCd = _loginCustomerDataRow.tksKgyCd;
                openCustomerInfoParam.tksBmnSeqNo = _loginCustomerDataRow.tksBmnSeqNo;
                openCustomerInfoParam.tksTntSeqNo = _loginCustomerDataRow.tksTntSeqNo;

                //�J�����Ӑ���擾.
                openCustomerInfoResult result = processController.GetOpenCustomerInfo(openCustomerInfoParam);

                //�G���[�̏ꍇ.
                if (result.errorInfo != null && result.errorInfo.error)
                {
                    MessageUtility.ShowMessageBox(result.errorInfo.errorCode, null, LOGIN, MessageBoxButtons.OK);
                    txtTkicd.SelectAll();
                    txtTkicd.Focus();
                    return false;
                }
            }

            //�J���m�F.
            KKHNaviParameter release_naviParam = new KKHNaviParameter();
            release_naviParam.strEsqId = kKHSecurityInfo.UserEsqId;
            release_naviParam.strEgcd = _loginServiceResult.EgCd;
            release_naviParam.strTksKgyCd = _loginCustomerDataRow.tksKgyCd; 
            release_naviParam.strTksBmnSeqNo = _loginCustomerDataRow.tksBmnSeqNo ;
            release_naviParam.strTksTntSeqNo = _loginCustomerDataRow.tksTntSeqNo;

            //�擾.
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult comResult = commonProcessController.FindCommonByCond(
                                                                                            release_naviParam.strEsqId,
                                                                                            release_naviParam.strEgcd,
                                                                                            release_naviParam.strTksKgyCd,
                                                                                            release_naviParam.strTksBmnSeqNo,
                                                                                            release_naviParam.strTksTntSeqNo,
                                                                                            KkhConstMain.RELEASE_SYBT,
                                                                                            KkhConstMain.TF_FLD1);
            
            // �f�[�^�����݂���ꍇ�̓��b�Z�[�W�\��.
            if (comResult.CommonDataSet.SystemCommon.Count != 0)
            {
                //�x�����b�Z�[�W��\��.
                MessageBox.Show(comResult.CommonDataSet.SystemCommon[0].field2.ToString(), LOGIN, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //�Ǘ��҃��[�U�[�͑���\.
                if (!txtTan.Text.Substring(0, 3).Equals(ADMIN_TANTOU))
                {
                    txtTkicd.SelectAll();
                    txtTkicd.Focus();
                    return false; 
                }
            }

            return true;
        }
        #endregion ���O�C������.

        #region ���j���[��ʕ\��.
        /// <summary>
        /// ���j���[��ʕ\��.
        /// </summary>
        private void displayMenu()
        {
            //�����ݒ�.
            CommonProcessController commonProcessController = CommonProcessController.GetInstance();
            inNaviParameter.Function = Function.TOP;
            KKHSecurityInfo kKHSecurityInfo = KKHSecurityInfo.GetInstance();

            //�X�[�p�[���[�U�[�A���ʃ��O�C�����[�U�[�̏ꍇ.
            if (txtTan.Enabled)
            {
                inNaviParameter.strEsqId = txtTan.Text;
                inNaviParameter.strName = _loginServiceResult.UserName;
            }
            //�ʏ탆�[�U�[�̏ꍇ.
            else
            {
                inNaviParameter.strEsqId = kKHSecurityInfo.UserEsqId;
                inNaviParameter.strName = KKHSecurityInfo.GetInstance().UserName;
            }

            /* 2016/05/31 JSE K.Takahasi ADD Start */
            //�f�[�^�擾(�J���m�F).
            string workFolderPath = string.Empty;
            CommonProcessController controller = CommonProcessController.GetInstance();
            FindCommonByCondServiceResult result = controller.FindCommonByCond(
                                                                            inNaviParameter.strEsqId,
                                                                            _loginServiceResult.EgCd,
                                                                            _loginCustomerDataRow.tksKgyCd,
                                                                            _loginCustomerDataRow.tksBmnSeqNo,
                                                                            _loginCustomerDataRow.tksTntSeqNo,
                                                                            Isid.KKH.Common.KKHUtility.Constants.KKHSystemConst.TempDir.MainType,
                                                                            "ED-I0001");
            //0���̏ꍇ.
            if (result.CommonDataSet.SystemCommon.Count != 0)
            {
                //�e���v���[�g�o�̓p�X.
                workFolderPath = result.CommonDataSet.SystemCommon[0].field2.ToString();
            }
            //�t�H���_�����݂��Ȃ��ꍇ�A�w�肳�ꂽ�t�H���_���쐬����.
            KKHUtility.SafeCreateDirectory(workFolderPath);
            /* 2016/05/31 JSE K.Takahasi ADD End */

            inNaviParameter.strEgcd = _loginServiceResult.EgCd;
            inNaviParameter.strTksKgyCd = _loginCustomerDataRow.tksKgyCd;
            inNaviParameter.strTksBmnSeqNo = _loginCustomerDataRow.tksBmnSeqNo;
            inNaviParameter.strTksTntSeqNo = _loginCustomerDataRow.tksTntSeqNo;
            inNaviParameter.strDate = KKHUtility.StringCnvDateTime(_loginInitInfoResult.eigyoBi).ToString("yyyy/MM/dd");
            inNaviParameter.strTksKgyName = _loginCustomerDataRow.dispTksName;

            switch (_loginCustomerDataRow.tksKgyCd + _loginCustomerDataRow.tksBmnSeqNo + _loginCustomerDataRow.tksTntSeqNo)
            {
                //�A�R��.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Acom:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuAcom";
                    inNaviParameter.strFrmMastNm = "tofrmMastAcom";
                    inNaviParameter.strFrmInputNm = "toReportAcom";
                    inNaviParameter.strFrmDetailNm = "toDetailAcom";
                    break;
                //�A�T�q����.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Ash:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuAsh";
                    inNaviParameter.strFrmMastNm = "tofrmMastAsh";
                    inNaviParameter.strFrmInputNm = "";
                    inNaviParameter.strFrmDetailNm = "toDetailAsh";
                    break;
                //�A�T�q�r�[��.
                case KKHSystemConst.TksKgyCode.TksKgyCode_AshBear:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuAsh";
                    inNaviParameter.strFrmMastNm = "tofrmMastAsh";
                    inNaviParameter.strFrmInputNm = "";
                    inNaviParameter.strFrmDetailNm = "toDetailAsh";
                    break;
                //�X�J�p�[.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Skyp:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuSkyp";
                    inNaviParameter.strFrmMastNm = "tofrmMastSkyp";
                    inNaviParameter.strFrmInputNm = "toReportSkyp";
                    inNaviParameter.strFrmDetailNm = "toDetailSkyp";
                    break;
                //���j�`���[��.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Uni:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuUni";
                    inNaviParameter.strFrmMastNm = "tofrmMastUni";
                    inNaviParameter.strFrmInputNm = "toReportUni";
                    inNaviParameter.strFrmDetailNm = "toDetailUni";
                    break;
                //���C�I��.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Lion:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuLion";
                    inNaviParameter.strFrmMastNm = "tofrmMastLion";
                    inNaviParameter.strFrmInputNm = "toReportLion";
                    inNaviParameter.strFrmDetailNm = "toDetailLion";
                    break;
                //���c��i.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Tkd:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuTkd";
                    inNaviParameter.strFrmMastNm = "tofrmMastTkd";
                    inNaviParameter.strFrmInputNm = "toReportTkd";
                    inNaviParameter.strFrmDetailNm = "toDetailTkd";
                    break;
                //�}�N�h�i���h.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Mac:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuMac";
                    inNaviParameter.strFrmMastNm = "tofrmMastMac";
                    inNaviParameter.strFrmInputNm = "toReportMac";
                    inNaviParameter.strFrmDetailNm = "toDetailMac";
                    break;
                //����A����A�h.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Toh:
                /* 2015/06/11 ����A�h�ǉ��Ή� HLC K.Soga ADD Start */
                case KKHSystemConst.TksKgyCode.TksKgyCode_TohAd:
                /* 2015/06/11 ����A�h�ǉ��Ή� HLC K.Soga ADD End */
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuToh";
                    inNaviParameter.strFrmMastNm = "tofrmMastToh";
                    inNaviParameter.strFrmInputNm = "toReportToh";
                    inNaviParameter.strFrmDetailNm = "toDetailToh";
                    break;
                //EPSON.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Epson:
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuEpson";
                    inNaviParameter.strFrmMastNm = "tofrmMastEpson";
                    inNaviParameter.strFrmInputNm = "";
                    inNaviParameter.strFrmDetailNm = "toDetailEpson";
                    break;
                //����.
                case KKHSystemConst.TksKgyCode.TksKgyCode_Kmn:
                /* 2015/04/01 �������Ӑ�ύX�Ή� HLC K.Fujisaki ADD Start */
                case KKHSystemConst.TksKgyCode.TksKgyCode_Kmn_2015:
                /* 2015/04/01 �������Ӑ�ύX�Ή� HLC K.Fujisaki ADD End */
                    inNaviParameter.strFrmTopMenuNM = "tofrmTopMenuKmn";
                    inNaviParameter.strFrmMastNm = "tofrmMastKmn";
                    inNaviParameter.strFrmInputNm = "toReportKmn";
                    inNaviParameter.strFrmDetailNm = "toDetailKmn";
                    break;
                //�ΏۊO�̓��Ӑ�.
                default:
                    MessageUtility.ShowMessageBox(MessageCode.HB_W0108, null, LOGIN, MessageBoxButtons.OK);
                    txtTkicd.SelectAll();
                    txtTkicd.Focus();
                    return;
            }

            Navigator.Forward(this, inNaviParameter.strFrmTopMenuNM, inNaviParameter);
        }
        #endregion ���j���[��ʕ\��.

        #region �p���ۂ�����Ή��֘A
        #region �p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̕��A�l��傫������قǊp�����ۂ��Ȃ�܂�.
        private int arcWidth = 25;
        /// <summary>
        /// �p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̕��A�l��傫������قǊp�����ۂ��Ȃ�܂�.
        /// </summary>
        //�v���p�e�B�E�B���h�E�\��.
        [Browsable(true)]                              
        [Description("�p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̕��A�l��傫������قǊp�����ۂ��Ȃ�܂��B")]
        [DefaultValue(25)]
        public int ArcWidth
        {
            get { return arcWidth; }
            set { arcWidth = value; }
        }
        #endregion �p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̕��A�l��傫������قǊp�����ۂ��Ȃ�܂�.

        #region �p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̍����A�l��傫������قǊp�����ۂ��Ȃ�܂�.
        private int arcHeight = 25;
        /// <summary>
        /// �p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̍����A�l��傫������قǊp�����ۂ��Ȃ�܂�.
        /// </summary>
        //�v���p�e�B�E�B���h�E�\��.
        [Browsable(true)]
        [Description("�p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̍����A�l��傫������قǊp�����ۂ��Ȃ�܂��B")]
        [DefaultValue(25)]
        public int ArcHeight
        {
            get { return arcHeight; }
            set { arcHeight = value; }
        }
        #endregion �p�̉~�ʂ̕`�挳�ƂȂ�ȉ~�̍����A�l��傫������قǊp�����ۂ��Ȃ�܂�.

        #region �t�H�[���̌`��ύX����.
        /// <summary>
        /// �t�H�[���̌`��ύX����.
        /// </summary>
        private void UpdateFormFormat()
        {
            if (arcWidth > 0 && arcHeight > 0)
            {
                using (GraphicsPath gp = new GraphicsPath())
                {
                    Rectangle r = this.ClientRectangle;
                    gp.StartFigure();
                    //�E��.
                    gp.AddArc(r.Right - arcWidth, r.Top, arcWidth, arcHeight, 270, 90);
                    //�E��.
                    gp.AddArc(r.Right - arcWidth, r.Bottom - arcHeight, arcWidth, arcHeight, 0, 90);
                    //����.
                    gp.AddArc(r.Left, r.Bottom - arcHeight, arcWidth, arcHeight, 90, 90);
                    //����.
                    gp.AddArc(r.Left, r.Top, arcWidth, arcHeight, 180, 90);
                    gp.CloseFigure();

                    //�`��ύX.
                    this.Region = new Region(gp);
                }
            }
        }
        #endregion �t�H�[���̌`��ύX����.
        #endregion �p���ۂ�����Ή��֘A.
        #endregion ���\�b�h.
    }
}