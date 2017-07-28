using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHView.Common.Form;
using Isid.KKH.Common.KKHUtility;

namespace Isid.KKH.Common.KKHUtility
{
    class KKHHelpHis : KKHHelpUtility
    {
        # region コンストラクタ
        # endregion コンストラクタ

        # region メソッド

        /// <summary>
        /// ヘルプファイルを判別する 
        /// </summary>
        /// <param name="pForm">フォーム</param>
        /// <param name="pGamenName">画面名</param>
        /// <param name="pTkskgyCd">得意先業務コード</param>
        public static void ShowHelpHis(KKHForm pForm, string pGamenName, string pTkskgyCd)
        {
            string file = "";
            string gamen = "";
            switch (pTkskgyCd)
            { 
                //アコム 
                case "008826":
                //case Constants.KKHSystemConst.TksKgyCode.TksKgyCode_Acom:
                    file = Constants.KKHSystemConst.HelpFile.Acom;
                    gamen = "UM_アコム7";
                    break;
                //ライオン
                case "180983":
                //case Constants.KKHSystemConst.TksKgyCode.TksKgyCode_Lion:
                    file = "KKH_Help_Rireki.chm";
                    gamen = "請求原票取込履歴閲覧機能.htm";
                    //TODO
                    //file = Constants.KKHSystemConst.HelpFile.Lion;
                    //gamen = "";
                    break;
                //スカパー  
                case "695465":
                //case Constants.KKHSystemConst.TksKgyCode.TksKgyCode_Skyp:
                    file = "KKH_Help_Rireki.chm";
                    gamen = "請求原票取込履歴閲覧機能.htm";
                    //TODO
                    //file = Constants.KKHSystemConst.HelpFile.Skyp;
                    //gamen = "";
                    break;
            }

            ShowHelp(pForm, file, gamen);

        }

        # endregion メソッド
    }
}
