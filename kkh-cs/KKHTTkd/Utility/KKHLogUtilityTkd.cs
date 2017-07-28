using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHUtility;

namespace Isid.KKH.Tkd.Utility
{
    class KKHLogUtilityTkd : KKHLogUtility
    {
        #region 定数

        #region 機能ID

        /// <summary>
        /// 機能ID（オペレーションログ－請求明細（中分類別））
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_REPORT_MIDDLECLASSIFICATION = "001";

        /// <summary>
        /// 機能ID（オペレーションログ－請求明細（品目別））
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_REPORT_ITEM = "002";

        /// <summary>
        /// 機能ID（オペレーションログ－請求明細（企画費））
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_REPORT_PLANNINGCOST = "003";

        /// <summary>
        /// 機能ID（オペレーションログ－受注チェック）
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_UPDCHECK = "004";

        /// <summary>
        /// 機能ID（オペレーションログ－実施No自動付与）
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_AUTONO = "005";

        /// <summary>
        /// 機能ID（オペレーションログ－実施NoUP/DOWN）
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_AUTOUPDOWN = "006";

        #endregion

        #region 内容

        /// <summary>
        /// 内容（オペレーションログ－請求明細（中分類別））
        /// </summary>
        public const String DESC_OPERATION_LOG_REPORT_MIDDLECLASSIFICATION = "請求明細（中分類別）";

        /// <summary>
        /// 内容（オペレーションログ－請求明細（品目別））
        /// </summary>
        public const String DESC_OPERATION_LOG_REPORT_ITEM = "請求明細（品目別）";

        /// <summary>
        /// 内容（オペレーションログ－請求明細（企画費））
        /// </summary>
        public const String DESC_OPERATION_LOG_REPORT_SUB_PLANNINGCOST = "請求明細（企画費）";

        /// <summary>
        /// 内容（オペレーションログ－受注チェック）
        /// </summary>
        public const String DESC_OPERATION_LOG_UPDCHECK = "受注チェック";

        /// <summary>
        /// 内容（オペレーションログ－実施No自動付与）
        /// </summary>
        public const String DESC_OPERATION_LOG_AUTONO = "実施No自動付与";

        /// <summary>
        /// 内容（オペレーションログ－実施NoUP/DOWN）
        /// </summary>
        public const String DESC_OPERATION_LOG_AUTOUPDOWN = "実施NoUP/DOWN";
        #endregion

        #endregion
    }
}
