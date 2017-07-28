using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;

namespace Isid.KKH.Acom.Utility
{
    class KKHHelpAcom : KKHHelpUtility
    {
        # region コンストラクタ
        # endregion コンストラクタ

        # region メソッド

        /// <summary>
        /// ヘルプファイルを判別する 
        /// </summary>
        /// <param name="pForm">フォーム</param>
        /// <param name="pGamenName">画面名</param>
        public static void ShowHelpAcom(KKHForm pForm, string pGamenName)
        {

            string gamen = "";
            switch (pGamenName)
            { 
                case "DetailAcom":
                    gamen = "UM_アコム8-0";
                    break;
                case "ClaimForm":
                    gamen = "UM_アコム10";
                    break;
                case "frmMastAcom":
                    gamen = "UM_アコム11";
                    break;
                case "HikForm":
                    gamen = "UM_アコム6";
                    break;
                case "ReportAcom":
                    gamen = "UM_アコム9";
                    break;
                case "frmTopMenuAcom":
                    gamen = "UM_アコム5";
                    break;
            }
            ShowHelp(pForm, "KKH_Help_Acom.chm", gamen);

        }

        # endregion メソッド
    }
}
