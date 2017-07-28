using System;
using System.Collections.Generic;
using System.Text;
using Isid.NJSecurity.Core;
using Isid.NJSecurity.Sso;
using System.Windows.Forms;
using Isid.NJSecurity.Connection;
using Isid.NJSecurity.Sso.Impl;
using Isid.NJSecurity.Connection.WebService;
using Isid.NJSecurity.Core.Impl;
using Isid.Rg.Main;
using Isid.NJSecurity.Core.Dummy;

namespace Isid.Rg.Main.Security
{
    /// <summary>
    /// NJSecurityの初期化ファクトリ実装クラス。
    /// </summary>
    public class ConcreteInitializeFactory : AbstractInitializeFactory
    {

        #region NJSecurity認証画面（GetSsoLoginForm, GetProgressBarForm, GetSsoFilterList）


        /// <summary>
        /// SSOログインフォームです。
        /// </summary>
        private BaseSsoLoginForm _ssoLoginForm = new BaseSsoLoginForm();

        /// <summary>
        /// プログレスバーフォームです。
        /// </summary>
        private ProgressBarForm _progressBarForm = new ProgressBarForm();

        /// <summary>
        /// SSOログインフォームのインスタンスを取得します。
        /// </summary>
        /// <returns></returns>
        public override SsoLoginForm GetSsoLoginForm()
        {
            return _ssoLoginForm;
        }

        /// <summary>
        /// プログレスバーフォームのインスタンスを取得します。
        /// </summary>
        /// <returns></returns>
        public override Form GetProgressBarForm()
        {
            return _progressBarForm;
        }

        /// <summary>
        /// ISsoFilterのリストを取得します。
        /// 通常は要素０のリストを返しますが、
        /// 所属選択ダイアログを表示する場合はOrganizationSelectFilterを追加して返してください。
        /// </summary>
        /// <returns></returns>
        public override IList<ISsoFilter> GetSsoFilterList()
        {
            IList<ISsoFilter> filters = new List<ISsoFilter>();

            // 所属選択ダイアログを表示する場合は以下のコードを追加
            //filters.Add(new OrganizationSelectFilter());

            return filters;
        }

        #endregion

        #region 認証サーバへの接続（GetConnection, GetConnectionInfo）


        /// <summary>
        /// セキュリティコンテキストファクトリを取得します。

        /// ダミーセキュリティの利用有無に合わせ、戻り値の実装クラスを切り替えてください。

        /// </summary>
        /// <returns></returns>
        public override SecurityContextFactory GetSecContextFactory()
        {
            ConcreteSecurityContextFactory factory = new ConcreteSecurityContextFactory();
            return (SecurityContextFactory)factory;
        }

        /// <summary>
        /// ダミーセキュリティ用XMLファイルの場所を取得します。

        /// XMLファイルには、開発に使用するログイン情報の一覧を記述してください。

        /// </summary>
        /// <returns></returns>
        public override string GetDummySecurityXmlFilePath()
        {
            return RgParameter.GetInstance().DummySecurityXmlFilePath;
        }

        /// <summary>
        /// HTTPによる認証を行うための接続オブジェクトです。
        /// WebServiceによる認証を行う場合は、代わりにWebServiceConnectionを使用してください。
        /// </summary>
        //private WebServiceConnection _connection = new WebServiceConnection();
        private WebServiceStatelessConnection _connection = new WebServiceStatelessConnection();

        /// <summary>
        /// HTTPによる認証を行うための接続情報オブジェクトです。
        /// WebServiceによる認証を行う場合は、代わりにWebServiceConnectionInfoを使用してください。
        /// </summary>
        private WebServiceConnectionInfo _connectionInfo = null;

        /// <summary>
        /// GetConnectionをオーバーライドします。
        /// </summary>
        /// <returns></returns>
        public override IConnection GetConnection()
        {
            return _connection;
        }

        /// <summary>
        /// GetConnectionInfoをオーバーライドします。
        /// </summary>
        /// <returns></returns>
        public override IConnectionInfo GetConnectionInfo()
        {
            if (_connectionInfo == null)
            {
                _connectionInfo = new WebServiceConnectionInfo();
                _connectionInfo.Url = RgParameter.GetInstance().NjSecurityServiceUrl;
                _connectionInfo.TimeOut = RgParameter.GetInstance().NjSecurityServiceTimeout;
            }
            return _connectionInfo;
        }

        /// <summary>
        /// サーバー接続失敗時のリトライ回数です。

        /// 通常は１を設定します。

        /// </summary>
        /// <returns></returns>
        public override int GetRequestSendCount()
        {
            return 1;
        }

        #endregion

    }
}
