using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHUtility;

namespace Isid.KKH.Kmn.Utility
{
    public class KKHLogUtilityKmn : KKHLogUtility
    {
        #region "定数"

        #region "機能ID"
        /// <summary>
        /// 請求一覧
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_ReportSEI = "001";
        /// <summary>
        /// 伝票
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_ReportDEN = "002";
        /// <summary>
        /// 受注チェック 
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_UpdCheck = "003";
        //--一括登録機能追加対応 2013/07/29 HLC H.Watabe start 
        /// <summary>
        /// 一括登録 
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_BulkRegister = "004";
        //--一括登録機能追加対応 2013/07/29 HLC H.Watabe end 
        #endregion "機能ID"

        #region "内容"
        /// <summary>
        /// 請求一覧
        /// </summary>
        public const String DESC_OPERATION_LOG_ReportSEI = "請求一覧";
        /// <summary>
        /// 伝票
        /// </summary>
        public const String DESC_OPERATION_LOG_ReportDEN = "納品書";
        /// <summary>
        /// 受注チェック 
        /// </summary>
        public const String DESC_OPERATION_LOG_UpdCheck = "受注チェック";
        //--一括登録機能追加対応 2013/07/29 HLC H.Watabe start 
        /// <summary>
        /// 一括登録 
        /// </summary>
        public const String DESC_OPERATION_LOG_BulkRegister = "一括登録";
        //--一括登録機能追加対応 2013/07/29 HLC H.Watabe end 
        #endregion "内容"

        #endregion "定数"
    }
}
