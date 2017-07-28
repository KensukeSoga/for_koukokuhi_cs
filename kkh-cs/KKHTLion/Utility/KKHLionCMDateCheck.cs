using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Lion.Schema;

namespace Isid.KKH.Lion.Utility
{
    class KKHLionCMDateCheck
    {
        /// <summary>
        /// テレビCM秒数データの年月チェック
        /// </summary>
        /// <param name="strYYYYMM"></param>
        /// <param name="resultTvCM"></param>
        /// <returns>OK->false : NG->true</returns>
        public static Boolean checkTVCMDate(String strYYYYMM, MastLion.TvCmLionDataTable resultTvCM)
        {
            Boolean retval = false;

            // テレビCM秒数の年月チェック

            MastLion.TvCmLionRow[] resultRows = (MastLion.TvCmLionRow[])resultTvCM.Select("", "");

            foreach (MastLion.TvCmLionRow resultRow in resultRows)
            {
                if (String.Equals(resultRow.YearMonth, strYYYYMM))
                {
                    continue;
                }

                retval = true;

                break;
            }

            return retval;
        }

        /// <summary>
        /// ラジオCM秒数データの年月チェック
        /// </summary>
        /// <param name="strYYYYMM"></param>
        /// <param name="resultRdCM"></param>
        /// <returns>OK->false : NG->true</returns>
        public static Boolean checkRDCMDate(String strYYYYMM, MastLion.RdCmLionDataTable resultRdCM)
        {
            Boolean retval = false;

            // ラジオCM秒数の年月チェック

            MastLion.RdCmLionRow[] resultRows = (MastLion.RdCmLionRow[])resultRdCM.Select("", "");

            foreach (MastLion.RdCmLionRow resultRow in resultRows)
            {
                if (String.Equals(resultRow.YearMonth, strYYYYMM))
                {
                    continue;
                }

                retval = true;

                break;
            }

            return retval;
        }
    }
}
