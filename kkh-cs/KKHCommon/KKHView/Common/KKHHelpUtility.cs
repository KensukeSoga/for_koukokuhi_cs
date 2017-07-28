using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Isid.KKH.Common.KKHView.Common.Form;

namespace Isid.KKH.Common.KKHView.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class KKHHelpUtility
    {
        # region 変数


        # endregion 変数

        # region コンストラクタ
        /// <summary>
        /// privateコンストラクタです。
        /// </summary>
        public KKHHelpUtility()
        {
        }

        # endregion コンストラクタ

        # region メソッド

        /// <summary>
        /// ヘルプ画面を表示する 
        /// </summary>
        /// <param name="pForm">フォーム</param>
        /// <param name="pTksk">得意先</param>
        /// <param name="pGamen">画面</param>
        public static void ShowHelp(KKHForm pForm,string pTksk, string pGamen)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string gamen = @"_RESOURCE\" + pGamen + ".htm";

            Help.ShowHelp(pForm, Path.Combine(path, pTksk),
                HelpNavigator.Topic,
                gamen);
        }

        # endregion メソッド

    }
}
