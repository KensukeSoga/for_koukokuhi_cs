using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHUtility;
namespace Isid.KKH.Mac.Utility
{
    public class KKHLogUtilityMac : KKHLogUtility
    {
        #region "定数"

        #region "機能ID"

        /// <summary>
        /// 機能ID （オペレーションログ－購入伝票） 
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_Purchase = "001";
        /// <summary>
        /// 機能ID （オペレーションログ－購入伝票一覧）
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_Report = "002";
        /// <summary>
        /// 機能ID （オペレーションログ－請求書） 
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_Request = "003";
        /// <summary>
        /// 機能ID （オペレーションログ－請求チェックリスト） 
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_Schklst = "004";
        /// <summary>
        /// 機能ID （オペレーションログ－ライセンシー）
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_Licensee = "005";
        /// <summary>
        /// 機能ID （オペレーションログ－受注チェック）
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_UpdCheck = "006";
        /// <summary>
        /// 機能ID （オペレーションログ－店舗データ取込）
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_MastMerge = "007";


        #endregion "機能ID"

        #region "内容"
        /// <summary>
        /// 内容（オペレーションログ－購入伝票） 
        /// </summary>
        public const String DESC_OPERATION_LOG_Purchase = "購入伝票";
        /// <summary>
        /// 内容（オペレーションログ－購入伝票一覧）
        /// </summary>
        public const String DESC_OPERATION_LOG_Report = "購入伝票一覧";
        /// <summary>
        /// 内容（オペレーションログ－請求書）
        /// </summary>
        public const String DESC_OPERATION_LOG_Request = "請求書";
        /// <summary>
        /// 内容（オペレーションログ－請求チェックリスト）
        /// </summary>
        public const String DESC_OPERATION_LOG_Schklst = "請求チェックリスト";
        /// <summary>
        /// 内容（オペレーションログ－ライセンシー）
        /// </summary>
        public const String DESC_OPERATION_LOG_Licensee = "ライセンシー";
        /// <summary>
        /// 内容（オペレーションログ－受注チェック）
        /// </summary>
        public const String DESC_OPERATION_LOG_UpdCheck = "受注チェック";
        /// <summary>
        /// 内容（オペレーションログ－店舗データ取込）

        /// </summary>
        public const String DESC_OPERATION_LOG_MastMerge = "店舗データ取込";


        #endregion "内容"

        #endregion "定数"
    }
}
