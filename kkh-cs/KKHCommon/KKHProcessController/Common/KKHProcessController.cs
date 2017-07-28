using System;
using System.Collections.Generic;
using System.Text;
using Isid.NJ.ProcessController;
using Isid.Soa.Framework.Client.Proxy;
using Isid.NJSecurity.Core;

namespace Isid.KKH.Common.KKHProcessController.Common
{

    /// <summary>
    /// プロセスコントローラ基底クラス
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
    ///       <description>2011/11/06</description>
    ///       <description>HLC sonobe</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class KKHProcessController : AbstractProcessController
    {
        #region プロテクトメソッド

        /// <summary>
        /// サービスアダプターを生成します。 
        /// </summary>
        /// <typeparam name="T">サービスアダプター</typeparam>
        /// <returns>サービスアダプター</returns>
        protected T CreateAdapter<T>() where T : IServiceProxyAdapter
        {
            AbstractInitializeFactory abstractInitializeFactory = AbstractInitializeFactory.GetInstance();
            ISecurityInfo securityInfo = abstractInitializeFactory.SecurityInfo;
            IUserInfo userInfo = securityInfo.GetUserInfo();
            string userId = userInfo.ID;

            return ClientProxyFactory.GetInstance().Create<T>(userId);
        }

        #endregion プロテクトメソッド
    }
}
