using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;

namespace Isid.KKH.Ash.Utility
{
    class KKHHelpAsh : KKHHelpUtility
    {
        # region コンストラクタ
        # endregion コンストラクタ

        # region メソッド

        /// <summary>
        /// ヘルプファイルを判別する 
        /// </summary>
        /// <param name="pForm">フォーム</param>
        /// <param name="pGamenName">画面名</param>
        public static void ShowHelpAsh(KKHForm pForm, string pGamenName)
        {

            string gamen = "";
            switch (pGamenName)
            {
                case "frmTopMenuAsh":
                    gamen = "メインメニュー_1";
                    break;
                case "DetailAsh":
                    gamen = "広告費明細登録画面_広告費明細登録";
                    break;
                case "frmMastAsh":
                    gamen = "マスタメンテナンス_1";
                    break;
                case "ReportAshByMedium":
                    gamen = "帳票_1";
                    break;
                case "ReportAshByMediumChklst":
                    gamen = "帳票_1";
                    break;
                case "ReportAshKoukokuHi":
                    gamen = "帳票_1";
                    break;
            }
            ShowHelp(pForm, "KKH_Help_Ash.chm", gamen);

        }

        # endregion メソッド
    }
    
}
