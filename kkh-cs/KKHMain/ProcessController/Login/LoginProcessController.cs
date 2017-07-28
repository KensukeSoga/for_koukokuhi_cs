using System;
using System.Collections.Generic;
using System.Text;
using Isid.Soa.Framework.Client.Proxy;
using Isid.NJSecurity.Core;
using Isid.NJ.ProcessController;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Detail.Converter;
using Isid.KKH.Common.KKHProcessController.Detail.Parser;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Ash.ProcessController.Detail.Parser;
using Isid.KKH.Main.ProcessController.Login.Parser;

namespace Isid.KKH.Main.ProcessController.Login
{
    /// <summary>
    /// ���O�C���v���Z�X�R���g���[��
    /// </summary>
    /// <remarks>
    ///   �C���Ǘ� 
    ///   <list type="table">
    ///     <listheader>
    ///       <description>���t</description>
    ///       <description>�C����</description>
    ///       <description>���e</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/02/24</description>
    ///       <description>JSE H.Abe</description>
    ///       <description>�V�K�쐬</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class LoginProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region �p�����[�^�\���̒�`

        /// <summary>
        /// �Ɩ���v�Z�L�����e�B���[���擾�p�����[�^�\����
        /// </summary>
        public struct GetAccountSecurityRoleParam
        {
            /// <summary>
            /// �A�v��ID
            /// </summary>
            public String aplId;
            /// <summary>
            /// ���O�C���S����ESQID 
            /// </summary>
            public String esqId;
            /// <summary>
            /// �p�X���[�h
            /// </summary>
            public String password;
            /// <summary>
            /// �Z�L�����e�B��� 
            /// </summary>
            public byte[] securityInfo;
        }
        /// <summary>
        /// ���O�C���������擾�����p�����[�^�\����
        /// </summary>
        public struct GetLoginInitInfoParam
        {
            /// <summary>
            /// ���O�C���S����ESQID 
            /// </summary>
            public String esqId;
            /// <summary>
            /// �^�pNo. 
            /// </summary>
            public String operationNo;
        }
        /// <summary>
        /// ���Ӑ���擾�����p�����[�^�\����
        /// </summary>
        public struct GetCustomerInfoParam
        {
            /// <summary>
            /// ���O�C���S����ESQID 
            /// </summary>
            public String esqId;
            /// <summary>
            /// ���Ӑ�R�[�h 
            /// </summary>
            public String customerCode;
        }
        /// <summary>
        /// ���O�C���p�����[�^�\����
        /// </summary>
        public struct LoginParam
        {
            /// <summary>
            /// ���O�C���S����ESQID
            /// </summary>
            public String esqId;
            /// <summary>
            /// �^�pNo.
            /// </summary>
            public String operationNo;
            /// <summary>
            /// ���[�U�[ID
            /// </summary>
            public String userId;
            /// <summary>
            /// �p�X���[�h
            /// </summary>
            public String password;
            /// <summary>
            /// ���Ӑ�R�[�h
            /// </summary>
            public String customerCode;
            /// <summary>
            /// �ʏ탆�[�U�[�t���O
            /// </summary>
            public String normalUserFlag;
            /// <summary>
            /// ���Ό���
            /// </summary>
            public String relativeAuthority;
            /// <summary>
            /// �S���ҏ����g�D�R�[�h
            /// </summary>
            public String organizationCode;
            /// <summary>
            /// �z�X�g�c�Ɠ�
            /// </summary>
            public String eigyoBi;
        }
        /// <summary>
        /// �J�����Ӑ�擾�����p�����[�^�\����
        /// </summary>
        public struct GetOpenCustomerInfoParam
        {
            /// <summary>
            /// ���O�C���S����ESQID 
            /// </summary>
            public String esqId;
            /// <summary>
            /// �c�Ə��i��j�R�[�h
            /// </summary>
            public String egCd;
            /// <summary>
            /// ���Ӑ��ƃR�[�h
            /// </summary>
            public String tksKgyCd;
            /// <summary>
            /// ���Ӑ敔��SEQNO
            /// </summary>
            public String tksBmnSeqNo;
            /// <summary>
            /// ���Ӑ�S��SEQNO
            /// </summary>
            public String tksTntSeqNo;
        }

        #endregion �p�����[�^�\���̒�`

        #region �C���X�^���X�ϐ�

        /// <summary>
        /// ���O�C���v���Z�X�R���g���[��
        /// </summary>
        private static LoginProcessController _processController;

        /// <summary>
        /// ���O�C���T�[�r�X�A�_�v�^�[
        /// </summary>
        private loginServiceAdapter _adapter;

        #endregion �C���X�^���X�ϐ�

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^�ł��B 
        /// </summary>
        private LoginProcessController()
        {
            _adapter = CreateAdapter<loginServiceAdapter>();
        }

        #endregion �R���X�g���N�^

        #region ���\�b�h

        /// <summary>
        /// ���O�C���v���Z�X�R���g���[���̃C���X�^���X���擾���܂��B 
        /// </summary>
        /// <returns>���O�C���v���Z�X�R���g���[���̃C���X�^���X</returns>
        public static LoginProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new LoginProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// �Ɩ���v�Z�L�����e�B���[���擾
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public accountSecurityRoleResult GetAccountSecurityRole(GetAccountSecurityRoleParam param)
        {
            accountSecurityRoleCondition condition = new accountSecurityRoleCondition();
            condition.aplId = param.aplId;
            condition.esqId = param.esqId;
            condition.password = param.password;
            condition.securityInfo = param.securityInfo;

            //�T�[�r�X�̌Ăяo�� 
            return _adapter.getAccountSecurityRole(condition);
        }

        /// <summary>
        /// ���O�C���������擾
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public loginInitInfoResult GetLoginInitInfo(GetLoginInitInfoParam param)
        {
            loginInitInfoCondition condition = new loginInitInfoCondition();
            condition.esqId = param.esqId;
            condition.operationNo = param.operationNo;

            //�T�[�r�X�̌Ăяo�� 
            return _adapter.getLoginInitInfo(condition);
        }

        /// <summary>
        /// ���Ӑ���擾
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public customerInfoResult GetCustomerInfo(GetCustomerInfoParam param)
        {
            customerInfoCondition condition = new customerInfoCondition();
            condition.esqId = param.esqId;
            condition.customerCode = param.customerCode;

            //�T�[�r�X�̌Ăяo�� 
            return _adapter.getCustomerInfo(condition);
        }

        /// <summary>
        /// ���O�C��
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public LoginServiceResult Login(LoginParam param)
        {
            //�T�[�r�X���� 
            LoginServiceResult serviceResult = new LoginServiceResult();

            loginCondition condition = new loginCondition();
            condition.esqId = param.esqId;
            condition.operationNo = param.operationNo;
            condition.userId = param.userId;
            condition.password = param.password;
            condition.customerCode = param.customerCode;
            condition.normalUserFlag = param.normalUserFlag;
            condition.relativeAuthority = param.relativeAuthority;
            condition.organizationCode = param.organizationCode;
            condition.eigyoBi = param.eigyoBi;

            //�T�[�r�X�̌Ăяo�� 
            ; loginResult result = _adapter.login(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // �T�[�r�X�̌Ăяo���G���[ 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;
                return serviceResult;
            }

            // �p�[�X 
            LoginParseResult parseResult = LoginParser.ParseForLogin(result);
            // �T�[�r�X���ʂ̐��� 
            serviceResult.EgCd = result.egCd;
            serviceResult.UserName = result.userName;
            serviceResult.LoginCustomerDataSet = parseResult.LoginCustomerDataSet;
            serviceResult.SystemAdministerFlg = result._SystemAdministerFlg;



            return serviceResult;
        }

        /// <summary>
        /// �J�����Ӑ���擾
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public openCustomerInfoResult GetOpenCustomerInfo(GetOpenCustomerInfoParam param)
        {
            openCustomerInfoCondition condition = new openCustomerInfoCondition();
            condition.esqId = param.esqId;
            condition.egCd = param.egCd;
            condition.tksKgyCd = param.tksKgyCd;
            condition.tksBmnSeqNo = param.tksBmnSeqNo;
            condition.tksTntSeqNo = param.tksTntSeqNo;

            //�T�[�r�X�̌Ăяo�� 
            return _adapter.getOpenCustomerInfo(condition);
        }

       #endregion ���\�b�h
    }
}