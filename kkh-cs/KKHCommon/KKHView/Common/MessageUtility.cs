using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Isid.KKH.Common.KKHUtility.Constants;
using Isid.NJ.Util.Message;

namespace Isid.KKH.Common.KKHView.Common
{

    /// <summary>
    /// ���b�Z�[�W���[�e�B���e�B
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
    ///       <description>2012/02/01</description>
    ///       <description>JSE H.Abe</description>
    ///       <description>�V�K�쐬</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class MessageUtility
    {

        #region �C���X�^���X�ϐ�

        /// <summary>
        /// �V�X�e���R�[�h
        /// </summary>
        private const string SYSTEM_CODE = "HB000000";

        /// <summary>
        /// �G���[���x���F���
        /// </summary>
        private const string ERR_LEVEL_INFORMASION = "I";

        /// <summary>
        /// �G���[���x���F�m�F
        /// </summary>
        private const string ERR_LEVEL_CONFIRM = "C";

        /// <summary>
        /// �G���[���x���F�x��
        /// </summary>
        private const string ERR_LEVEL_WARNING = "W";

        /// <summary>
        /// �G���[���x���F�G���[
        /// </summary>
        private const string ERR_LEVEL_ERROR = "E";

        /// <summary>
        /// �ϊ��O���s�R�[�h
        /// </summary>
        private const string CONVERT_FROM_CARRIAGE_RETURN = "\\r";

        /// <summary>
        /// �ϊ�����s�R�[�h
        /// </summary>
        private const string CONVERT_TO_CARRIAGE_RETURN = "\r";

        /// <summary>
        /// �ϊ��O���A�R�[�h
        /// </summary>
        private const string CONVERT_FROM_LINE_FEED = "\\n";

        /// <summary>
        /// �ϊ��㕜�A�R�[�h
        /// </summary>
        private const string CONVERT_TO_LINE_FEED = "\n";


        #endregion �C���X�^���X�ϐ�

        #region �R���X�g���N�^

        /// <summary>
        /// private�R���X�g���N�^�ł��B
        /// </summary>
        private MessageUtility()
        {
        }

        #endregion �R���X�g���N�^

        #region �p�u���b�N���\�b�h

        /// <summary>
        /// ���b�Z�[�W�{�b�N�X��\�����܂��B�i�����I���{�^���w�肠��j
        /// </summary>
        /// <param name="messageCode">���b�Z�[�W�R�[�h</param>
        /// <param name="messageParam">���b�Z�[�W�p�����[�^</param>
        /// <param name="caption">�L���v�V����</param>
        /// <param name="buttonType">�{�^�����</param>
        /// <param name="defaultButton">�����I���{�^��</param>
        /// <returns>�_�C�A���O�{�b�N�X�̖߂�l���������ʎq</returns>
        public static DialogResult ShowMessageBox(string messageCode, string[] messageParam, string caption, MessageBoxButtons buttonType,
            MessageBoxDefaultButton defaultButton)
        {
            MessageCatalog messageCatalog = MessageCatalogLoader.GetErrorMessage(messageCode, SYSTEM_CODE, messageParam);
            string message = messageCatalog.GetMessage();
            message = ConvertEndOfLine(message);
            MessageBoxIcon icon = SelectIcon(messageCatalog.GetMsgType());
            return MessageBox.Show(message, caption, buttonType, icon, defaultButton);
        }

        /// <summary>
        /// ���b�Z�[�W�{�b�N�X��\�����܂��B�i�����I���{�^���w��Ȃ��j
        /// </summary>
        /// <param name="messageCode">���b�Z�[�W�R�[�h</param>
        /// <param name="messageParam">���b�Z�[�W�p�����[�^</param>
        /// <param name="caption">�L���v�V����</param>
        /// <param name="buttonType">�{�^�����</param>
        /// <returns>�_�C�A���O�{�b�N�X�̖߂�l���������ʎq</returns>
        public static DialogResult ShowMessageBox(string messageCode, string[] messageParam, string caption, MessageBoxButtons buttonType)
        {
            return ShowMessageBox(messageCode, messageParam, caption, buttonType, MessageBoxDefaultButton.Button1);
        }

        #endregion �p�u���b�N���\�b�h

        #region �v���C�x�[�g���\�b�h

        /// <summary>
        /// �A�C�R���I��
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <returns>�A�C�R��</returns>
        private static MessageBoxIcon SelectIcon(string errLevel)
        {
            if (ERR_LEVEL_INFORMASION.Equals(errLevel))
            {
                return MessageBoxIcon.Information;
            }
            else if (ERR_LEVEL_CONFIRM.Equals(errLevel))
            {
                return MessageBoxIcon.Question;
            }
            else if (ERR_LEVEL_WARNING.Equals(errLevel))
            {
                return MessageBoxIcon.Warning;
            }
            else
            {
                return MessageBoxIcon.Error;
            }
        }

        /// <summary>
        /// �s�I�[�����ϊ�
        /// </summary>
        /// <param name="message">�ϊ��O������</param>
        /// <returns>�ϊ��㕶����</returns>
        private static String ConvertEndOfLine(string message)
        {
            // �����^�u���ɂ��Ή�����̂ł���΁A���\�b�h����ConvertEscapeSequence���ɕύX���ĉ������B

            // ���s�R�[�h�̕ϊ�
            message = message.Replace(CONVERT_FROM_CARRIAGE_RETURN, CONVERT_TO_CARRIAGE_RETURN);

            // ���A�R�[�h�̕ϊ�
            message = message.Replace(CONVERT_FROM_LINE_FEED, CONVERT_TO_LINE_FEED);

            return message;
        }

        #endregion �v���C�x�[�g���\�b�h
    }
}
