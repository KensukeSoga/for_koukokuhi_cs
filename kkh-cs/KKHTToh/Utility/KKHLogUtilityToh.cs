using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHUtility;
namespace Isid.KKH.Toh.Utility
{
    public class KKHLogUtilityToh : KKHLogUtility
    {
        #region "定数"

        #region "機能ID"
        /// <summary>
        /// 機能ID （オペレーションログ－請求明細一覧） 
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_Report = "001";
        /// <summary>
        /// 機能ID （オペレーションログ－年月別媒体別集計） 
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_Total = "002";
        /// <summary>
        /// 機能ID （オペレーションログ－受注チェック） 
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_UpdCheck= "003";
        #endregion "機能ID"

        #region "内容"
        /// <summary>
        /// 内容（オペレーションログ－請求明細一覧） 
        /// </summary>
        public const String DESC_OPERATION_LOG_Report = "請求明細一覧";
        /// <summary>
        /// 内容（オペレーションログ－年月別媒体別集計）
        /// </summary>
        public const String DESC_OPERATION_LOG_Total = "年月別媒体別集計";
        /// <summary>
        /// 内容（オペレーションログ－受注チェック）

        /// </summary>
        public const String DESC_OPERATION_LOG_UpdCheck = "受注チェック";
        #endregion "内容"

        #endregion "定数"
    }
}
