using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHSchema;


namespace Isid.KKH.Main.ProcessController.Login.Parser
{
    /// <summary>
    /// ���O�C���T�[�r�X�p�[�X����
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
    class LoginParseResult
    {
        #region �v���p�e�B

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

        #endregion �v���p�e�B
    }
}
