using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Log;
using Isid.KKH.Common.KKHView.Common;

namespace Isid.KKH.Common.KKHUtility
{
    public class KKHLogUtility
    {
        #region 定数

        #region 種別

        /// <summary>
        /// 種別（起動ログ）
        /// </summary>
        public const String SYBT_STARTING_LOG = "001";

        /// <summary>
        /// LOG表示(002)
        /// </summary>
        public const String SYBT_LOG_SHOW = "002";

        /// <summary>
        ///  LOG非表示(003)
        /// </summary>
        public const String SYBT_LOG_NOT_SHOW = "003";

        /// <summary>
        /// 種別（オペレーションログ）
        /// </summary>
        public const String SYBT_OPERATION_LOG = "004";

        /// <summary>
        /// 種別（終了ログ）

        /// </summary>
        public const String SYBT_ENDING_LOG = "005";

        #endregion

        #region 機能ID

        /// <summary>
        /// 機能ID（デフォルト値）
        /// </summary>
        private const String KINO_ID_DEFAULT = " ";

        #endregion

        #region 区分

        /// <summary>
        /// 区分（起動ログ）
        /// </summary>
        protected const String KBN_STARTING_LOG = "起動";

        /// <summary>
        /// 区分（オペレーションログ）
        /// </summary>
        protected const String KBN_OPERATION_LOG = "操作";

        /// <summary>
        /// 区分（終了ログ）

        /// </summary>
        protected const String KBN_ENDING_LOG = "終了";

        #endregion

        /// <summary>
        /// エラー内容（デフォルト値）
        /// </summary>
        protected const String ERRDESC_DEFAULT = " ";

        /// <summary>
        /// 送受信方法（デフォルト値）
        /// </summary>
        protected const String RECEPTION_KIND_DEFAULT = " ";

        /// <summary>
        /// ステータス（デフォルト値）
        /// </summary>
        protected const String STATUS_DEFAULT = "0";

        #endregion

        #region スタティックメソッド

        /// <summary>
        /// ログの書き込み
        /// </summary>
        /// <param name="naviParam"></param>
        /// <param name="updApl"></param>
        /// <param name="sybt"></param>
        /// <param name="kinoId"></param>
        /// <param name="kbn"></param>
        /// <param name="desc"></param>
        /// <param name="errdesc"></param>
        /// <param name="receptionKind"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static RegistLogServiceResult WriteLogToDB(KKHNaviParameter naviParam, String updApl, String sybt, String kinoId, String kbn, String desc, String errdesc, String receptionKind, String status)
        {
            LogProcessController controller = LogProcessController.GetInstance();

            RegistLogServiceResult result = controller.registLog
            (
                updApl,
                naviParam.strEsqId,
                naviParam.strEgcd,
                naviParam.strTksKgyCd,
                naviParam.strTksBmnSeqNo,
                naviParam.strTksTntSeqNo,
                sybt,
                kinoId,
                kbn,
                desc,
                errdesc,
                naviParam.strName,
                receptionKind,
                status
            );

            return result;
        }

        /// <summary>
        /// ログの読み込み
        /// </summary>
        /// <param name="naviParam"></param>
        /// <param name="sybt"></param>
        /// <returns></returns>
        public static FindLogByCondServiceResult ReadLogFromDB(KKHNaviParameter naviParam, String sybt)
        {
            LogProcessController controller = LogProcessController.GetInstance();

            FindLogByCondServiceResult result = controller.FindLogByCond
            (
                naviParam.strEsqId,
                naviParam.strEgcd,
                naviParam.strTksKgyCd,
                naviParam.strTksBmnSeqNo,
                naviParam.strTksTntSeqNo,
                sybt
            );

            return result;
        }

        /// <summary>
        /// 起動ログの書き込み
        /// </summary>
        /// <param name="naviParam"></param>
        /// <param name="updApl"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public static RegistLogServiceResult WriteStartingLogToDB(KKHNaviParameter naviParam, String updApl, String desc)
        {
            return WriteLogToDB
            (
                naviParam,
                updApl,
                SYBT_STARTING_LOG,
                KINO_ID_DEFAULT,
                KBN_STARTING_LOG,
                desc,
                ERRDESC_DEFAULT,
                RECEPTION_KIND_DEFAULT,
                STATUS_DEFAULT
            );
        }

        /// <summary>
        /// 終了ログの書き込み
        /// </summary>
        /// <param name="naviParam"></param>
        /// <param name="updApl"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public static RegistLogServiceResult WriteEndingLogToDB(KKHNaviParameter naviParam, String updApl, String desc)
        {
            return WriteLogToDB
            (
                naviParam,
                updApl,
                SYBT_ENDING_LOG,
                KINO_ID_DEFAULT,
                KBN_ENDING_LOG,
                desc,
                ERRDESC_DEFAULT,
                RECEPTION_KIND_DEFAULT,
                STATUS_DEFAULT
            );
        }

        /// <summary>
        /// オペレーションログの書き込み
        /// </summary>
        /// <param name="naviParam"></param>
        /// <param name="updApl"></param>
        /// <param name="kinoId"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public static RegistLogServiceResult WriteOperationLogToDB(KKHNaviParameter naviParam, String updApl, String kinoId, String desc)
        {
            return WriteLogToDB
            (
                naviParam,
                updApl,
                SYBT_OPERATION_LOG,
                //KINO_ID_DEFAULT,
                kinoId,
                KBN_OPERATION_LOG,
                desc,
                ERRDESC_DEFAULT,
                RECEPTION_KIND_DEFAULT,
                STATUS_DEFAULT
            );
        }

        #endregion
    }
}
