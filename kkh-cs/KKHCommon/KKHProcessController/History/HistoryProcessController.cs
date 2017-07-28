using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHProcessController.History.Parser;
namespace Isid.KKH.Common.KKHProcessController.History
{

    /// <summary>
    /// 履歴（Lion）プロセスコントローラ 
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
    ///       <description>2012/2/19</description>
    ///       <description>Fourm H.Izawa</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
   public class HistoryProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {

        #region "構造体"

       /// <summary>
       /// 
       /// </summary>
        public struct findHisJyutDownparam
        {
            /// <summary>
            /// ESQID
            /// </summary>
            public String esqId;
            /// <summary>
            /// 営業所（取）コード 
            /// </summary>
            public String egCd;
            /// <summary>
            /// 得意先企業コード 
            /// </summary>
            public String tksKgyCd;
            /// <summary>
            /// 得意先部門SEQNO 
            /// </summary>
            public String tksBmnSeqNo;
            /// <summary>
            /// 得意先担当SEQNO 
            /// </summary>
            public String tksTntSeqNo;
            /// <summary>
            /// 年月 
            /// </summary>
            public String yymm;
        }

        #endregion "構造体"

        #region "インスタンス変数"
        /// <summary>
        /// LIONプロセスコントローラー
        /// </summary>
        public static HistoryProcessController _processController;

        /// <summary>
        /// Lionサービスアダプター
        /// </summary>
        public historyServiceAdapter _adapter;

       /// <summary>
       /// 
       /// </summary>
        public static HisDs _dsHis;
        #endregion "インスタンス変数"

        #region "コンストラクタ"

       /// <summary>
       /// 
       /// </summary>
        public HistoryProcessController()
        {
            _adapter = CreateAdapter<historyServiceAdapter>();
        }

        #endregion "コンストラクタ"

        #region "メソッド"

        /// <summary>
        /// Lionプロセスコントローラーのインスタンスを返します 
        /// </summary>
        /// <returns></returns>
        public static HistoryProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new HistoryProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 受注ダウンロード履歴
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public FindHisByCondServiceResult findHisJyutDown(findHisJyutDownparam param)
        {
            FindHisByCondServiceResult serviceResult = new FindHisByCondServiceResult();
            historyJyutDownCondition cond = new historyJyutDownCondition();

            cond.esqId = param.esqId;
            cond.egCd = param.egCd;
            cond.tksKgyCd = param.tksKgyCd;
            cond._tksBmnSeqNo = param.tksBmnSeqNo;
            cond._tksTntSeqNo = param.tksTntSeqNo;
            cond._yymm = param.yymm;

            historyJyutDownResult result = _adapter.findHistoryByCond(cond);
            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            FindHisByCondServiceResult parseResult = HistoryParser.ParseForFindHisJyutDown(result);
            _dsHis = parseResult.dsDataSet;

            serviceResult.dsDataSet = parseResult.dsDataSet;

            return serviceResult;
        }
       

        #endregion "メソッド"

    }
}
