using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHSchema;

namespace Isid.KKH.Main.ProcessController.Login.Parser
{
    /// <summary>
    /// ログインサービスパーサー
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
    internal class LoginParser
    {
        #region メソッド
        /// <summary>
        /// ログイン情報を取得します。
        /// </summary>
        /// <param name="result">ログイン結果</param>
        /// <returns>ログインパース結果</returns>
        internal static LoginParseResult ParseForLogin(loginResult result)
        {
            Schema.Login dsLogin = new Schema.Login();

            loginCustomerInfoVO[] loginCustomerInfoVOArray = result.loginCustomerInfoVOList;
            if (loginCustomerInfoVOArray != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsLogin.LoginCustomerData.TableName, loginCustomerInfoVOArray) };
                Schema.Login dsAddLogin = DataSetConverter.Convert<Schema.Login>(defs);
                dsLogin.LoginCustomerData.Merge(dsAddLogin.LoginCustomerData);
            }

            LoginParseResult parseResult = new LoginParseResult();
            parseResult.LoginCustomerDataSet = dsLogin;

            return parseResult;
        }

        #endregion
    }
}
