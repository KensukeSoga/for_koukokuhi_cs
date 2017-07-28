using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace KKHUserManual.Helper
{   
    /// <summary>
    /// ユーザーマニュアルヘルプクラス
    /// </summary>
    public class UserManualHelper
    {

        /// <summary>
        /// ページネーム 
        /// </summary>
        string _pGamenNum = string.Empty;

        /// <summary>
        /// 得意先コード 
        /// </summary>
        string _tkskgycd = string.Empty;

        /// <summary>
        /// ユーザーマニュアルファイル名 
        /// </summary>
        private string _userManualFile = string.Empty;

        string workpath = @"C:\TMP";

        /// <summary>
        /// ファイルオープンプロトコル
        /// </summary>
        private const string FILE_OPEN_PROTOCOL = @"file://";

        #region 得意先コード

        public struct TksKgyCode
        {
            /// <summary>
            /// アコム
            /// </summary>
            public const string TksKgyCode_Acom = "0088260101";
            /// <summary>
            /// アサヒ
            /// </summary>
            public const string TksKgyCode_Ash = "2851470301";
            /// <summary>
            /// アサヒビール
            /// </summary>
            public const string TksKgyCode_AshBear = "0168020101";
            /// <summary>
            /// スカパー
            /// </summary>
            public const string TksKgyCode_Skyp = "6954651301";
            /// <summary>
            /// 得意先　ユニチャーム 
            /// </summary>
            public const string TksKgyCode_Uni = "0310540201";

            /// <summary>
            /// 得意先　ライオン 
            /// </summary>
            public const string TksKgyCode_Lion = "1809830201";

            /// <summary>
            /// 得意先　武田製薬 
            /// </summary>
            public const string TksKgyCode_Tkd = "3855040303";

            /// <summary>
            /// 得意先　マクドナルド 
            /// </summary>
            public const string TksKgyCode_Mac = "2711430101";

            /// <summary>
            /// 得意先　東宝 
            /// </summary>
            public const string TksKgyCode_Toh = "4007020601";

            // 2015/06/11 東宝アド対応 Soga ADD Start
            /// <summary>
            /// 得意先　東宝アド. 
            /// </summary>
            public const string TksKgyCode_TohAd = "4006480301";
            // 2015/06/11 東宝アド対応 Soga ADD End

            /// <summary>
            /// 得意先　EPSON 
            /// </summary>
            public const string TksKgyCode_Epson = "0040170101";

            /// <summary>
            /// 得意先　公文 
            /// </summary>
            public const string TksKgyCode_Kmn = "0470200101";

            // 2015/04/01 公文得意先変更対応 Fujisaki ADD Start 
            /// <summary>
            /// 得意先　公文 
            /// </summary>
            public const string TksKgyCode_Kmn_2015 = "1709810401";
            // 2015/04/01 公文得意先変更対応 Fujisaki ADD End 
        }

        #endregion



        #region コンストラクタ

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public UserManualHelper()
        {

        }

        #endregion コンストラクタ

        /// <summary>
        /// ユーザーマニュアルオープンプロセススタート 
        /// </summary>
        /// <param name="tkskgycd">得意先コード</param>
        /// <param name="pGamenNum">キーワード</param>
        /// <param name="form">Form</param>
        /// <param name="command">ヘルプファイルの要素</param>
        public void ProcessStart(string tkskgycd ,string pGamenNum, Form form , HelpNavigator command)
        {
            _tkskgycd = tkskgycd;
            _pGamenNum = pGamenNum;

            // Chmファイルを出力する 
            if (!createUserManualFile())
            {
                // Chmファイル出力エラー 
                return;
            }

            try
            {
                //起動
                string pdfProc = getUserManualFileUri();
                //System.Diagnostics.Process hProcess = System.Diagnostics.Process.Start(pdfProc);
                //_pGamenNum = @"_RESOURCE\" + _pGamenNum + ".htm";
                //Help.ShowHelp(form, pdfProc,
                //HelpNavigator.Topic,
                //_pGamenNum);

                //_pGamenNum = @"_RESOURCE\" + _pGamenNum + ".htm";
                //Help.ShowHelp(form, pdfProc,
                //HelpNavigator.KeywordIndex,
                //_pGamenNum);

                if (command.ToString().Equals(HelpNavigator.Topic.ToString()))
                {
                    _pGamenNum = @"_RESOURCE\" + _pGamenNum + ".htm";
                }

                //実行
                Help.ShowHelp(form, pdfProc,command,_pGamenNum);
                //Help.ShowHelp(form, pdfProc, _pGamenNum);


            }
            catch(Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// ユーザーマニュアル生成 
        /// </summary>
        /// <returns></returns>
        private bool createUserManualFile()
        {
            try
            {
                //// ユーザーマニュアルファイルパス 
                //this._userManualFile = Path.Combine(workpath,)

                switch (_tkskgycd)
                {
                    case TksKgyCode.TksKgyCode_Acom:
                        _userManualFile = workpath + "\\AcomHelp.chm";
                        File.WriteAllBytes(this._userManualFile, Isid.KKH.UserManual.Properties.Resources.KKH_Help_Acom);
                        break;
                    case TksKgyCode.TksKgyCode_Ash:
                        _userManualFile = workpath+"\\AshHelp.chm";
                        File.WriteAllBytes(_userManualFile, Isid.KKH.UserManual.Properties.Resources.KKH_Help_Ash);
                        break;
                    case TksKgyCode.TksKgyCode_AshBear:
                        _userManualFile = workpath + "\\AshBearHelp.chm";
                        File.WriteAllBytes(_userManualFile, Isid.KKH.UserManual.Properties.Resources.KKH_Help_AshBear);
                        break;
                    case TksKgyCode.TksKgyCode_Skyp:
                        _userManualFile = workpath + "\\SkypHelp.chm";
                        File.WriteAllBytes(this._userManualFile, Isid.KKH.UserManual.Properties.Resources.KKH_Help_Skyp);
                        break;
                    case TksKgyCode.TksKgyCode_Uni:
                        _userManualFile = workpath + "\\UniHelp.chm";
                        File.WriteAllBytes(this._userManualFile, Isid.KKH.UserManual.Properties.Resources.KKH_Help_Uni);
                        break;
                    case TksKgyCode.TksKgyCode_Lion:
                        _userManualFile = workpath + "\\LionHelp.chm";
                        File.WriteAllBytes(this._userManualFile, Isid.KKH.UserManual.Properties.Resources.KKH_Help_Lion4);
                        break;
                    case TksKgyCode.TksKgyCode_Tkd:
                        _userManualFile = workpath + "\\TkdHelp.chm";
                        File.WriteAllBytes(this._userManualFile, Isid.KKH.UserManual.Properties.Resources.KKH_Help_Tkd);
                        break;
                    case TksKgyCode.TksKgyCode_Mac:
                        _userManualFile = workpath + "\\MacHelp.chm";
                        File.WriteAllBytes(this._userManualFile, Isid.KKH.UserManual.Properties.Resources.KKH_Help_Mac);
                        break;
                    case TksKgyCode.TksKgyCode_Epson:
                        _userManualFile = workpath + "\\EpsonHelp.chm";
                        File.WriteAllBytes(this._userManualFile, Isid.KKH.UserManual.Properties.Resources.KKH_Help_Epson);
                        break;
                    case TksKgyCode.TksKgyCode_Toh:
                    case TksKgyCode.TksKgyCode_TohAd:   // 2015/06/11 東宝アド対応 Soga ADD
                        _userManualFile = workpath + "\\TohHelp.chm";
                        File.WriteAllBytes(this._userManualFile, Isid.KKH.UserManual.Properties.Resources.KKH_Help_Toh);
                        break;
                    case TksKgyCode.TksKgyCode_Kmn:
                    case TksKgyCode.TksKgyCode_Kmn_2015:    // 2015/04/01 公文得意先変更対応 Fujisaki ADD 
                        _userManualFile = workpath + "\\KmnHelp.chm";
                        File.WriteAllBytes(this._userManualFile, Isid.KKH.UserManual.Properties.Resources.KKH_Help_Kmn);
                        break;
                }


            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// ユーザーマニュアルファイルURI 
        /// </summary>
        /// <returns></returns>
        private string getUserManualFileUri()
        {
            //string uri = string.Format("{0}{1}#page={2}",
            string uri = string.Format("{0}{1}",
                                        FILE_OPEN_PROTOCOL,
                                        this._userManualFile,
                                        _pGamenNum);

            return uri;
        }

    }
}
