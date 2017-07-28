using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Log;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Common.KKHProcessController.Log.Parser;
using Isid.KKH.Common.KKHSchema;


namespace Isid.KKH.Common.KKHProcessController.Log
{
    /// <summary>
    /// ログプロセスコントローラ 
    /// </summary>
    /// <remarks>
    ///   修正管理 
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2011/11/15</description>
    ///       <description>IP H.Shimizu</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class LogProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region インスタンス変数

        /// <summary>
        /// マスタプロセスコントローラ 
        /// </summary>
        private static LogProcessController _processController;

        /// <summary>
        /// マスタサービスアダプター 
        /// </summary>
        private logServiceAdapter _adapter;

        /// <summary>
        /// データセット 
        /// </summary>
        private static KKHSchema.Log _dsLog;

        #endregion インスタンス変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタです。 
        /// </summary>
        private LogProcessController()
        {
            _adapter = CreateAdapter<logServiceAdapter>();
        }

        #endregion コンストラクタ

        #region メソッド

        /// <summary>
        /// コードマスタプロセスコントローラのインスタンスを取得します。 
        /// </summary>
        /// <returns>コードマスタプロセスコントローラのインスタンス</returns>
        public static LogProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new LogProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// ログ情報検索 
        /// </summary>
        /// <returns>検索サービス結果</returns>
        /// 
        public FindLogByCondServiceResult FindLogByCond(String esqId, String egCd, String tksKgyCd, String tksBmnSeqNo, String tksTntSeqNo, String sybt)
        {
            // サービス結果 
            FindLogByCondServiceResult serviceResult = new FindLogByCondServiceResult();

            logCondition condition = new logCondition();
            condition.esqId = esqId;
            condition.egCd = egCd;
            condition.tksKgyCd = tksKgyCd;
            condition.tksBmnSeqNo = tksBmnSeqNo;
            condition.tksTntSeqNo = tksTntSeqNo;
            condition.sybt = sybt;

            // サービスの呼び出し 
            logResult result = _adapter.findLogByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース 
            FindLogByCondParseResult parseResult = LogParser.ParseForFindLogByCond(result);
            _dsLog = parseResult.LogDataSet;

            // サービス結果の生成 
            serviceResult.LogDataSet = parseResult.LogDataSet;

            return serviceResult;
        }

        /// <summary>
        /// ログ情報登録 
        /// </summary>
        public RegistLogServiceResult registLog(String trkPl,
                                String esqId,
                                String egCd,
                                String tksKgyCd,
                                String tksBmnSeqNo,
                                String tksTntSeqNo,
                                String sybt,
                                String kinoId,
                                String kbn,
                                String Desc,
                                String errDesc,
                                String tanName,
                                String Reception,
                                String Status)
        {
            // サービス結果 
            RegistLogServiceResult serviceResult = new RegistLogServiceResult();

            logVO Vo = new logVO();
            Vo.trkPl = trkPl;
            Vo.trkTnt = esqId;
            Vo.updPl = trkPl;
            Vo.updTnt = esqId;
            Vo.egCd = egCd;
            Vo.tksKgyCd = tksKgyCd;
            Vo.tksBmnSeqNo = tksBmnSeqNo;
            Vo.tksTntSeqNo = tksTntSeqNo;
            Vo.sybt = sybt;
            Vo.kinoId = kinoId;
            Vo.kbn = kbn;
            Vo.desc = Desc;
            Vo.errDesc = errDesc;
            Vo.tanName = tanName;
            Vo.receptionKind = Reception;
            Vo.status = Status;

            // サービスの呼び出し 
            logResult result = _adapter.registLog(Vo);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー 
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            return serviceResult;
        }

        #endregion
    }
}
