using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHUtility;

namespace Isid.KKH.Epson.Utility
{
    class KKHLogUtilityEpson : KKHLogUtility
    {
        #region 定数

        #region 機能ID

        /// <summary>
        /// 機能ID（オペレーションログ－請求予定一覧）
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_REPORT_SEIKYU_PLAN = "001";

        /// <summary>
        /// 機能ID（オペレーションログ－提出帳票）
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_REPORT_SUB_MISSION = "002";

        /// <summary>
        /// 機能ID（オペレーションログ－受注チェック）

        /// </summary>
        public const String KINO_ID_OPERATION_LOG_UPDCHECK = "003";


        #endregion

        #region 内容

        /// <summary>
        /// 内容（オペレーションログ－請求予定一覧）
        /// </summary>
        public const String DESC_OPERATION_LOG_REPORT_SEIKYU_PLAN = "請求予定一覧";

        /// <summary>
        /// 内容（オペレーションログ－提出帳票）
        /// </summary>
        public const String DESC_OPERATION_LOG_REPORT_SUB_MISSION = "請求データ出力";

        /// <summary>
        /// 内容（オペレーションログ－受注チェック）

        /// </summary>
        public const String DESC_OPERATION_LOG_UPDCHECK = "受注チェック";

        #endregion

        #endregion
    }
}
