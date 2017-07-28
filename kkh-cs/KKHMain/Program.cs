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
    /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ƂȂ�N���X�ł��B
    /// </summary>
    static class Program
    {
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // NJC#�t���[�����[�N�̏��������s���܂��B
                // �V�X�e���R�[�h�̓v���W�F�N�g���ɐݒ肵�����̂��g�p���Ă��������B
                // �����Ŏw�肷��V�X�e���R�[�h�́ARuntime\XXSystemParameter.xml�����Ŏg�p����V�X�e���R�[�h�Ɠ��ꂵ�Ă��������B
                NJMainEntry mainEntry = new KKHMainEntry();
                //IUINavigator navigator = mainEntry.Initialize("HB000000", null, string.Empty);

                //�ݒ�t�@�C�������\�[�X�Ƃ��Ė��ߍ��ޏꍇ�A��L�̑���Ɉȉ��̃R�[�h���g�p���܂��B
                //string assemblyName = typeof(RgEntryPoint).Assembly.GetName().Name;
                //IUINavigator navigator = mainEntry.Initialize("HB000000", null, assemblyName);
                IUINavigator navigator = new NJMainEntry().Initialize("HB000000",new ApliConfigureFileInfo() ,"KKHMain");
                // �F�؏������s���܂��B
                Initializer.InitSecurityFrameWrok(typeof(ConcreteInitializeFactory).FullName);
                SsoLauncher ssoLauncher = new SsoLauncher();
                ssoLauncher.ProccessStart();

                // �F�؏����I����AISecurityInfo�̎擾
                KKHSecurityInfo.GetInstance().SecurityInfo = AbstractInitializeFactory.GetInstance().SecurityInfo;

                /*
                 * �Ɩ���v�Z�L�����e�B���擾�p�̈����ݒ�
                 */
                LoginProcessController.GetAccountSecurityRoleParam param = new LoginProcessController.GetAccountSecurityRoleParam();
                // �A�v��ID
                param.aplId = KKHParameter.GetInstance().AccountSecurityAppId;
                // ESQID
                KKHSecurityInfo kKHSecurityInfo = KKHSecurityInfo.GetInstance();
                param.esqId = kKHSecurityInfo.UserEsqId;
                // �N�������擾
                string[] initParam = System.Environment.GetCommandLineArgs();



                //SoaClientFrameWork

                //�A�Z���u���ǂݍ���
                System.Reflection.Assembly.Load("KKHMain");
                ClientFrameworkConfig.SetParameterXmlEmbeddedAssemblyName("KKHMain");
                ClientFrameworkConfig.SetParameterXmlPath("Isid.KKH.Main.Runtime.SoaClientParameter.xml");


                // EXE���ڋN���̏ꍇ
                if (initParam.Length == 1)
                {
                    // ���Ό�����ݒ�
                    kKHSecurityInfo.RelativeAuthority = null;
                    // �Z�L�����e�B���[���擾�ΏۊO�t���O��ݒ�
                    kKHSecurityInfo.NotSecurityRoleFlag = true;
                }
                // �ʏ�N���̏ꍇ
                else
                {
                    string stCsvData = initParam[1];
                    string[] stArrayData = stCsvData.Split(',');
                    param.password = stArrayData[5].Trim();
                    // �Z�L�����e�B���
                    ISecurityInfo iSecurityInfo = kKHSecurityInfo.SecurityInfo;
                    param.securityInfo = iSecurityInfo.GetSecurityInfoToken();


                    /*
                     * �Ɩ���v�Z�L�����e�B���擾
                     */
                    LoginProcessController processController = LoginProcessController.GetInstance();
                    accountSecurityRoleResult result = processController.GetAccountSecurityRole(param);
                    // �G���[�̏ꍇ
                    if (result.errorInfo != null && result.errorInfo.error)
                    {
                        MessageUtility.ShowMessageBox(result.errorInfo.errorCode, null, "���O�C��", MessageBoxButtons.OK);
                        return;
                    }
                    // ���Ό�����ݒ�
                    kKHSecurityInfo.RelativeAuthority = result.relativeAuthority;
                    // �Z�L�����e�B���[���擾�ΏۊO�t���O��ݒ�
                    kKHSecurityInfo.NotSecurityRoleFlag = result.notSecurityRoleFlag;
                }
                // �����\����ʂɑJ�ڂ��܂��B
                // ���炩���ߏ����\�����Form���܂܂��DLL�����[�h���Ă����K�v������܂��B
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
                log.Error("�t���[�����[�N�̏����������Ɏ��s���܂����B", e);
                return;
            }
        }
    }
}