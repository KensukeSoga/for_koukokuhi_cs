using System;
using System.Collections.Generic;
using System.Text;

using Isid.KKH.Common.KKHView.Common;

namespace Isid.KKH.Main.View.Login
{
    /// <summary>
    /// ���O�C���p�����[�^�N���X
    /// </summary>
    public class LoginNaviParameter : KKHNaviParameter
    {

        /// <summary>
        /// ���O�C�����Ӑ���INDEX
        /// </summary>
        private int _loginCustomerDataIndex;

        /// <summary>
        /// ���O�C�����Ӑ���INDEX���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public int loginCustomerDataIndex
        {
            get { return _loginCustomerDataIndex; }
            set { _loginCustomerDataIndex = value; }
        }

        /// <summary>
        /// ���O�C�����Ӑ���f�[�^�Z�b�g
        /// </summary>
        private Schema.Login.LoginCustomerDataDataTable _loginCustomerDataDataTable;

        /// <summary>
        /// ���O�C�����Ӑ���f�[�^�Z�b�g���擾�܂��͐ݒ肵�܂��B
        /// </summary>
        public Schema.Login.LoginCustomerDataDataTable loginCustomerDataDataTable
        {
            get { return _loginCustomerDataDataTable; }
            set { _loginCustomerDataDataTable = value; }
        }

    }
}
