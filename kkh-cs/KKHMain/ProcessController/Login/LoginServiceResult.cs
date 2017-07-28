using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHProcessController.Common;


namespace Isid.KKH.Main.ProcessController.Login.Parser
{
    /// <summary>
    /// ログインサービス結果
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
    public class LoginServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 営業所（取）コードです。 
        /// </summary>
        private string _egCd;

        /// <summary>
        /// 営業所（取）コードを取得または設定します。 
        /// </summary>
        public string EgCd
        {
            get { return _egCd; }
            set { _egCd = value; }
        }

        /// <summary>
        /// ユーザー名です。 
        /// </summary>
        private string _userName;

        /// <summary>
        /// ユーザー名を取得または設定します。 
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

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

        /// <summary>
        /// ユーザータイプです。
        /// </summary>
        private string _SystemAdministerFlg;

        /// <summary>
        /// ユーザータイプの取得または設定をします。
        /// </summary>
        public string SystemAdministerFlg
        {
            get { return _SystemAdministerFlg; }
            set { _SystemAdministerFlg = value; }
        }


        #endregion プロパティ
    }
}
