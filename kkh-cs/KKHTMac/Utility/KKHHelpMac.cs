using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;

namespace Isid.KKH.Mac.Utility
{
    class KKHHelpMac : KKHHelpUtility
    {
        # region コンストラクタ
        # endregion コンストラクタ

        # region メソッド

        /// <summary>
        /// ヘルプファイルを判別する 
        /// </summary>
        /// <param name="pForm">フォーム</param>
        /// <param name="pGamenName">画面名</param>
        public static void ShowHelpMac(KKHForm pForm, string pGamenName)
        {

            string gamen = "";
            switch (pGamenName)
            {
                case "frmTopMenuMac":
                    gamen = "メインメニュー_1";
                    break;
                case "DetailMac":
                    gamen = "広告費明細登録画面_広告費明細登録";
                    break;
                case "frmMastMac":
                    gamen = "マスタメンテナンス_1";
                    break;
                case "frmMastMergeMac":
                    gamen = "マスタメンテナンス_1";
                    break;
                case "ReportMac":
                    gamen = "帳票_1";
                    break;
                case "ReportMacLicensee":
                    gamen = "帳票_1";
                    break;
                case "ReportMacPurchase":
                    gamen = "帳票_1";
                    break;
                case "ReportMacRequest":
                    gamen = "帳票_1";
                    break;
                case "ReportMacSchklst":
                    gamen = "帳票_1";
                    break;
            }
            ShowHelp(pForm, "KKH_Help_Mac.chm", gamen);

        }

        # endregion メソッド

    }
}
