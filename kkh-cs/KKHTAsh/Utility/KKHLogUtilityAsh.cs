using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHUtility;

namespace Isid.KKH.Ash.Utility
{
    public class KKHLogUtilityAsh : KKHLogUtility
    {
        #region "定数"

        #region "機能ID"

        /// <summary>
        /// 機能ID （オペレーションログ－媒体別帳票） 
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_Medium = "001";
        /// <summary>
        /// 機能ID （オペレーションログ－広告費帳票） 
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_Koukokuhi = "002";
        /// <summary>
        /// 機能ID （オペレーションログ－広告費アップロードシート） 
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_MediumChklst = "003";
        /// <summary>
        /// 機能ID （オペレーションログ－受注チェック） 
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_UpdCheck = "004";
        /// <summary>
        /// 機能ID （オペレーションログ－請求データ作成） 
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_FD = "005";


        #endregion "機能ID"

        #region "内容" 

        /// <summary>
        /// 内容（オペレーションログ－媒体別帳票） 
        /// </summary>
        public const String DESC_OPERATION_LOG_Medium = "媒体別帳票";
        /// <summary>
        /// 内容（オペレーションログ－広告費帳票） 
        /// </summary>
        public const String DESC_OPERATION_LOG_Koukokuhi = "広告費帳票";
        /// <summary>
        /// 内容（オペレーションログ－広告費アップロードシート） 
        /// </summary>
        public const String DESC_OPERATION_LOG_MediumChklst = "広告費アップロードシート";
        /// <summary>
        /// 内容（オペレーションログ－受注チェック） 
        /// </summary>
        public const String DESC_OPERATION_LOG_UpdCheck = "受注チェック";
        /// <summary>
        /// 内容（オペレーションログ－請求データ作成） 
        /// </summary>
        public const String DESC_OPERATION_LOG_FD = "請求データ作成";


        #endregion "内容" 


        #endregion "定数"
    }
}
