using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Isid.NJ;
using Isid.NJ.View.Navigator;
using Isid.NJ.Logging;
using Isid.NJSecurity.Core;
using Isid.NJSecurity.Sso;
using Isid.KKH.Common.KKHUtility.Security;
using Isid.KKH.Main.ProcessController.Login;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHUtility;
using Isid.Soa.Framework.Client.Core;
namespace Isid.KKH.Main
{
    /// <summary>
    /// アプリケーションのメイン エントリ ポイントとなるクラスです。
    /// </summary>
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // NJC#フレームワークの初期化を行います。
                // システムコードはプロジェクト毎に設定したものを使用してください。
                // ここで指定するシステムコードは、Runtime\XXSystemParameter.xml内部で使用するシステムコードと統一してください。
                NJMainEntry mainEntry = new KKHMainEntry();
                //IUINavigator navigator = mainEntry.Initialize("HB000000", null, string.Empty);

                //設定ファイルをリソースとして埋め込む場合、上記の代わりに以下のコードを使用します。
                //string assemblyName = typeof(RgEntryPoint).Assembly.GetName().Name;
                //IUINavigator navigator = mainEntry.Initialize("HB000000", null, assemblyName);
                IUINavigator navigator = new NJMainEntry().Initialize("HB000000",new ApliConfigureFileInfo() ,"KKHMain");
                // 認証処理を行います。
                Initializer.InitSecurityFrameWrok(typeof(ConcreteInitializeFactory).FullName);
                SsoLauncher ssoLauncher = new SsoLauncher();
                ssoLauncher.ProccessStart();

                // 認証処理終了後、ISecurityInfoの取得
                KKHSecurityInfo.GetInstance().SecurityInfo = AbstractInitializeFactory.GetInstance().SecurityInfo;

                /*
                 * 業務会計セキュリティ情報取得用の引数設定
                 */
                LoginProcessController.GetAccountSecurityRoleParam param = new LoginProcessController.GetAccountSecurityRoleParam();
                // アプリID
                param.aplId = KKHParameter.GetInstance().AccountSecurityAppId;
                // ESQID
                KKHSecurityInfo kKHSecurityInfo = KKHSecurityInfo.GetInstance();
                param.esqId = kKHSecurityInfo.UserEsqId;
                // 起動引数取得
                string[] initParam = System.Environment.GetCommandLineArgs();



                //SoaClientFrameWork

                //アセンブリ読み込み
                System.Reflection.Assembly.Load("KKHMain");
                ClientFrameworkConfig.SetParameterXmlEmbeddedAssemblyName("KKHMain");
                ClientFrameworkConfig.SetParameterXmlPath("Isid.KKH.Main.Runtime.SoaClientParameter.xml");


                // EXE直接起動の場合
                if (initParam.Length == 1)
                {
                    // 相対権限を設定
                    kKHSecurityInfo.RelativeAuthority = null;
                    // セキュリティロール取得対象外フラグを設定
                    kKHSecurityInfo.NotSecurityRoleFlag = true;
                }
                // 通常起動の場合
                else
                {
                    string stCsvData = initParam[1];
                    string[] stArrayData = stCsvData.Split(',');
                    param.password = stArrayData[5].Trim();
                    // セキュリティ情報
                    ISecurityInfo iSecurityInfo = kKHSecurityInfo.SecurityInfo;
                    param.securityInfo = iSecurityInfo.GetSecurityInfoToken();


                    /*
                     * 業務会計セキュリティ情報取得
                     */
                    LoginProcessController processController = LoginProcessController.GetInstance();
                    accountSecurityRoleResult result = processController.GetAccountSecurityRole(param);
                    // エラーの場合
                    if (result.errorInfo != null && result.errorInfo.error)
                    {
                        MessageUtility.ShowMessageBox(result.errorInfo.errorCode, null, "ログイン", MessageBoxButtons.OK);
                        return;
                    }
                    // 相対権限を設定
                    kKHSecurityInfo.RelativeAuthority = result.relativeAuthority;
                    // セキュリティロール取得対象外フラグを設定
                    kKHSecurityInfo.NotSecurityRoleFlag = result.notSecurityRoleFlag;
                }
                // 初期表示画面に遷移します。
                // あらかじめ初期表示画面Formが含まれるDLLをロードしておく必要があります。
                System.Reflection.Assembly.Load("KKHCommon");
                System.Reflection.Assembly.Load("KKHTAcom");
                System.Reflection.Assembly.Load("KKHTAsh");
                System.Reflection.Assembly.Load("KKHTLion");
                System.Reflection.Assembly.Load("KKHTMac");
                System.Reflection.Assembly.Load("KKHTSkyp");
                System.Reflection.Assembly.Load("KKHTTkd");
                System.Reflection.Assembly.Load("KKHTToh");
                System.Reflection.Assembly.Load("KKHTUni");
                System.Reflection.Assembly.Load("KKHTEpson");
                System.Reflection.Assembly.Load("KKHTKmn");
                System.Reflection.Assembly.Load("KKHUserManual");

                navigator.Start();
            }
            catch (NJMainEntryInitializeException e)
            {
                INJLog log = NJLogFactory.GetLog(typeof(Program));
                log.Error("フレームワークの初期化処理に失敗しました。", e);
                return;
            }
        }
    }
}