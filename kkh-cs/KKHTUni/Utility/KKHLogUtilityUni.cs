using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHUtility;

namespace Isid.KKH.Uni.Utility
{
    public class KKHLogUtilityUni : KKHLogUtility
    {
        #region "定数"

        #region "機能ID"
        /// <summary>
        /// 広告費明細表(暫定)  
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_ReportZAN = "001";
        /// <summary>
        /// 広告費明細表(確定)  
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_ReportKAK = "002";
        /// <summary>
        /// 受注チェック 
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_UpdCheck = "003";
        #endregion "機能ID"

        #region "内容"
        /// <summary>
        /// 広告費明細表(暫定)  
        /// </summary>
        public const String DESC_OPERATION_LOG_ReportZAN = "広告費明細表(暫定)";
        /// <summary>
        /// 広告費明細表(確定)  
        /// </summary>
        public const String DESC_OPERATION_LOG_ReportKAK = "広告費明細表(確定)";
        /// <summary>
        /// 受注チェック 
        /// </summary>
        public const String DESC_OPERATION_LOG_UpdCheck = "受注チェック";
        #endregion "内容"

        #endregion "定数"
    }
}
