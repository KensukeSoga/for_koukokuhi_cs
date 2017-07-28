using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHUtility;

namespace Isid.KKH.Skyp.Utility
{
    class KKHLogUtilitySkyp : KKHLogUtility
    {
        #region 定数

        #region 機能ID

        /// <summary>
        /// 機能ID（オペレーションログ－納品／請求書）
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_REPORT = "001";

        /// <summary>
        /// 機能ID（オペレーションログ－受注チェック）
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_UPDCHECK = "002";

        /// <summary>
        /// 機能ID（オペレーションログ－並び順）
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_ORDER = "003";

        #endregion

        #region 内容

        /// <summary>
        /// 内容（オペレーションログ－納品／請求書）
        /// </summary>
        public const String DESC_OPERATION_LOG_REPORT = "納品／請求書";

        /// <summary>
        /// 内容（オペレーションログ－受注チェック）
        /// </summary>
        public const String DESC_OPERATION_LOG_UPDCHECK = "受注チェック";

        /// <summary>
        /// 内容（オペレーションログ－並び順）
        /// </summary>
        public const String DESC_OPERATION_LOG_ORDER = "並び順";

        #endregion

        #endregion
    }}
