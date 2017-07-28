using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHSchema;


namespace Isid.KKH.Main.ProcessController.Login.Parser
{
    /// <summary>
    /// ログインサービスパース結果
    /// </summary>
    /// <remarks>
    ///   修正管理
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/02/24</description>
    ///       <description>JSE H.Abe</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class LoginParseResult
    {
        #region プロパティ

        /// <summary>
        /// ログイン得意先データセットです。 
        /// </summary>
        private Schema.Login _dsLogin;

        /// <summary>
        /// ログイン得意先データセットを取得または設定します。 
        /// </summary>
        public Schema.Login LoginCustomerDataSet
        {
            get { return _dsLogin; }
            set { _dsLogin = value; }
        }

        #endregion プロパティ
    }
}
