using System;
using System.Collections.Generic;
using System.Text;
using Isid.NJ.Config;

namespace Isid.KKH.Common.KKHUtility
{
    /// <summary>
    /// アプリケーションのパラメータクラスです。 
    /// </summary>
    public class KKHParameter : Parameter
    {
        /// <summary>
        /// アプリID
        /// </summary>
        public static readonly string APP_ID = "HB000000";

        /// <summary>
        /// インスタンス 
        /// </summary>
        private static KKHParameter instance = (KKHParameter) ParameterFactory.GetParameter(APP_ID);

        /// <summary>
        /// デフォルトコンストラクタ。 
        /// </summary>
        public KKHParameter()
        {
        }

        /// <summary>
        /// インスタンスを返します。 
        /// </summary>
        /// <returns>インスタンス</returns>
        public static KKHParameter GetInstance()
        {
            if (instance == null)
            {
                instance = (KKHParameter)ParameterFactory.GetParameter(APP_ID);
            }
            return instance;
        }

        /// <summary>
        /// SecurityContextFactoryClassName
        /// </summary>
        public string SecurityContextFactoryClassName
        {
            get
            {
                return (string)instance.GetValue("SecurityContextFactoryClassName");
            }
        }

        /// <summary>
        /// NJSecurityServiceの接続先URL
        /// </summary>
        public string NjSecurityServiceUrl
        {
            get
            {
                return (string)instance.GetValue("NjSecurityServiceUrl");
            }
        }

        /// <summary>
        /// NJSecurityServiceの接続タイムアウト時間 
        /// </summary>
        public int NjSecurityServiceTimeout
        {
            get
            {
                return int.Parse(instance.GetValue("NjSecurityServiceTimeout").ToString());
            }
        }

        /// <summary>
        /// NJSecurityにてDummySecurityを使用する場合のファイルパス 
        /// </summary>
        public string DummySecurityXmlFilePath
        {
            get
            {
                return (string)instance.GetValue("DummySecurityXmlFilePath");
            }
        }

        /// <summary>
        /// EDSに登録されているAppId
        /// </summary>
        public string SecurityAppId
        {
            get
            {
                return (string)instance.GetValue("SecurityAppId");
            }
        }

        /// <summary>
        /// EDSに登録されているAppId（業務会計） 
        /// </summary>
        public string AccountSecurityAppId
        {
            get
            {
                return (string)instance.GetValue("AccountSecurityAppId");
            }
        }

        /// <summary>
        /// 帳票ファイルのWorkフォルダ 
        /// </summary>
        public string ReportWorkFolderPath
        {
            get
            {
                return (string)instance.GetValue("ReportWorkFolderPath");
            }
        }

        /// <summary>
        /// Excel起動のリトライ回数 
        /// </summary>
        public int ExcelStartRetryCount
        {
            get
            {
                return int.Parse(instance.GetValue("ExcelStartRetryCount").ToString());
            }
        }

    }
}
