using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHUtility;
using Isid.KKH.Common.KKHView.Common;
using Isid.KKH.Common.KKHProcessController.Log;

namespace Isid.KKH.Acom.Utility
{
    public class KKHLogUtilityAcom : KKHLogUtility
    {
        #region 定数

        #region 機能ID

        /// <summary>
        /// 機能ID（送受信ログ－受信）
        /// </summary>
        public const String KINO_ID_SEND_AND_RECEIVE_LOG_RECEIVE = "001";

        /// <summary>
        /// 機能ID（送受信ログ－送信）
        /// </summary>
        public const String KINO_ID_SEND_AND_RECEIVE_LOG_SEND = "002";

        /// <summary>
        /// 機能ID（オペレーションログ－請求データ送信）
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_CLAME = "001";

        /// <summary>
        /// 機能ID（オペレーションログ－請求書作成指示書）
        /// </summary>
        public const String KINO_ID_OPERATION_LOG_REPORT = "002";

        /// <summary>
        /// 機能ID（オペレーションログ－受注チェック）

        /// </summary>
        public const String KINO_ID_OPERATION_LOG_UPDCHECK = "003";

        #endregion

        #region 区分

        /// <summary>
        /// 区分（受信ログ）
        /// </summary>
        private const String KBN_SEND_AND_RECEIVE_LOG_RECEIVE = "受信";

        /// <summary>
        /// 区分（送信ログ）
        /// </summary>
        private const String KBN_SEND_AND_RECEIVE_LOG_SEND = "送信";

        #endregion

        #region 内容

        /// <summary>
        /// 内容（オペレーションログ－請求データ送信）
        /// </summary>
        public const String DESC_OPERATION_LOG_CLAIM = "請求データ送信";

        /// <summary>
        /// 内容（オペレーションログ－請求書作成指示書）
        /// </summary>
        public const String DESC_OPERATION_LOG_REPORT = "請求書作成指示書";

        /// <summary>
        /// 内容（オペレーションログ－受注チェック）

        /// </summary>
        public const String DESC_OPERATION_LOG_UPDCHECK = "受注チェック";

        #endregion

        #endregion

        #region スタティックメソッド

        /// <summary>
        /// 受信ログの書き込み
        /// </summary>
        /// <param name="naviParam"></param>
        /// <param name="updApl"></param>
        /// <param name="desc"></param>
        /// <param name="errdesc"></param>
        /// <param name="receptionKind"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static RegistLogServiceResult WriteReceiveLogToDB(KKHNaviParameter naviParam, String updApl, String desc, String errdesc, String receptionKind, String status)
        {
            return WriteLogToDB
            (
                naviParam,
                updApl,
                SYBT_LOG_SHOW,
                KINO_ID_SEND_AND_RECEIVE_LOG_RECEIVE,
                KBN_SEND_AND_RECEIVE_LOG_RECEIVE,
                desc,
                errdesc,
                receptionKind,
                status
            );
        }

        /// <summary>
        /// マスタログの書き込み
        /// </summary>
        /// <param name="naviParam"></param>
        /// <param name="updApl"></param>
        /// <param name="desc"></param>
        /// <param name="errdesc"></param>
        /// <param name="receptionKind"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static RegistLogServiceResult WriteMasterLogToDB(KKHNaviParameter naviParam, String updApl, String desc, String errdesc, String receptionKind, String status)
        {
            return WriteLogToDB
            (
                naviParam,
                updApl,
                SYBT_LOG_NOT_SHOW,
                KINO_ID_SEND_AND_RECEIVE_LOG_RECEIVE,
                KBN_SEND_AND_RECEIVE_LOG_RECEIVE,
                desc,
                errdesc,
                receptionKind,
                status
            );
        }

        /// <summary>
        /// 送信ログの書き込み
        /// </summary>
        /// <param name="naviParam"></param>
        /// <param name="updApl"></param>
        /// <param name="desc"></param>
        /// <param name="errdesc"></param>
        /// <param name="receptionKind"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static RegistLogServiceResult WriteSendLogToDB(KKHNaviParameter naviParam, String updApl, String desc, String errdesc, String receptionKind, String status)
        {
            return WriteLogToDB
            (
                naviParam,
                updApl,
                SYBT_LOG_SHOW,
                KINO_ID_SEND_AND_RECEIVE_LOG_SEND,
                KBN_SEND_AND_RECEIVE_LOG_SEND,
                desc,
                errdesc,
                receptionKind,
                status
            );
        }

        #endregion
    }
}
