using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHProcessController.Common;


namespace Isid.KKH.Main.ProcessController.Login.Parser
{
    /// <summary>
    /// ���O�C���T�[�r�X����
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
    public class LoginServiceResult : KKHServiceResult
    {
        #region �v���p�e�B

        /// <summary>
        /// �c�Ə��i��j�R�[�h�ł��B 
        /// </summary>
        private string _egCd;

        /// <summary>
        /// �c�Ə��i��j�R�[�h���擾�܂��͐ݒ肵�܂��B 
        /// </summary>
        public string EgCd
        {
            get { return _egCd; }
            set { _egCd = value; }
        }

        /// <summary>
        /// ���[�U�[���ł��B 
        /// </summary>
        private string _userName;

        /// <summary>
        /// ���[�U�[�����擾�܂��͐ݒ肵�܂��B 
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// ���O�C�����Ӑ�f�[�^�Z�b�g�ł��B 
        /// </summary>
        private Schema.Login _dsLogin;

        /// <summary>
        /// ���O�C�����Ӑ�f�[�^�Z�b�g���擾�܂��͐ݒ肵�܂��B 
        /// </summary>
        public Schema.Login LoginCustomerDataSet
        {
            get { return _dsLogin; }
            set { _dsLogin = value; }
        }

        /// <summary>
        /// ���[�U�[�^�C�v�ł��B
        /// </summary>
        private string _SystemAdministerFlg;

        /// <summary>
        /// ���[�U�[�^�C�v�̎擾�܂��͐ݒ�����܂��B
        /// </summary>
        public string SystemAdministerFlg
        {
            get { return _SystemAdministerFlg; }
            set { _SystemAdministerFlg = value; }
        }


        #endregion �v���p�e�B
    }
}
