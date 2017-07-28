using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;

namespace Isid.KKH.Lion.Utility
{
    class KKHHelpLion : KKHHelpUtility
    {
        # region コンストラクタ
        # endregion コンストラクタ

        # region メソッド

        /// <summary>
        /// ヘルプファイルを判別する 
        /// </summary>
        /// <param name="pForm">フォーム</param>
        /// <param name="pGamenName">画面名</param>
        public static void ShowHelpLion(KKHForm pForm, string pGamenName)
        {

            string gamen = "";
            switch (pGamenName)
            { 
                case "DetailLion":
                    gamen = "広告費明細登録画面_広告費明細登録";
                    break;
                case "frmMastLionZashiRyoSpc":
                    gamen = "広告費明細登録画面_選択統合";
                    break;
                case "frmMastLion":
                    gamen = "マスタメンテナンス_1";
                    break;
                case "FDLion":
                    gamen = "帳票_1";
                    break;
                case "NewReportLion":
                    gamen = "帳票_1";
                    break;
                case "ReportProofLion":
                    gamen = "帳票_1";
                    break;
                case "frmTopMenuLion":
                    //gamen = @"_RESOURCE\メインメニュー_1.htm";
                    gamen = "メインメニュー_1";
                    break;
            }
            ShowHelp(pForm, "KKH_Help_Lion.chm", gamen);

        }

        # endregion メソッド
    }
}
