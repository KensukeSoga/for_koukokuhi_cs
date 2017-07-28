using System;
using System.Collections.Generic;
using System.Text;

using Isid.KKH.Common.KKHView.Common;

namespace Isid.KKH.Main.View.Login
{
    /// <summary>
    /// ログインパラメータクラス
    /// </summary>
    public class LoginNaviParameter : KKHNaviParameter
    {

        /// <summary>
        /// ログイン得意先情報INDEX
        /// </summary>
        private int _loginCustomerDataIndex;

        /// <summary>
        /// ログイン得意先情報INDEXを取得または設定します。
        /// </summary>
        public int loginCustomerDataIndex
        {
            get { return _loginCustomerDataIndex; }
            set { _loginCustomerDataIndex = value; }
        }

        /// <summary>
        /// ログイン得意先情報データセット
        /// </summary>
        private Schema.Login.LoginCustomerDataDataTable _loginCustomerDataDataTable;

        /// <summary>
        /// ログイン得意先情報データセットを取得または設定します。
        /// </summary>
        public Schema.Login.LoginCustomerDataDataTable loginCustomerDataDataTable
        {
            get { return _loginCustomerDataDataTable; }
            set { _loginCustomerDataDataTable = value; }
        }

    }
}
