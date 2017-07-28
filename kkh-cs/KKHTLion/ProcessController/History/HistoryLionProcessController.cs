using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Lion.Schema;
using Isid.KKH.Lion.ProcessController.History.Parser;
namespace Isid.KKH.Lion.ProcessController.History
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
    ///       <description>2012/2/19/description>
    ///       <description>Fourm H.Izawa</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class HistoryLionProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {

    //    #region "構造体"

    //    public struct findHisJyutDownparam
    //    {
    //        /// <summary>
    //        /// ESQID
    //        /// </summary>
    //        public String esqId;
    //        /// <summary>
    //        /// 営業所（取）コード 
    //        /// </summary>
    //        public String egCd;
    //        /// <summary>
    //        /// 得意先企業コード 
    //        /// </summary>
    //        public String tksKgyCd;
    //        /// <summary>
    //        /// 得意先部門SEQNO 
    //        /// </summary>
    //        public String tksBmnSeqNo;
    //        /// <summary>
    //        /// 得意先担当SEQNO 
    //        /// </summary>
    //        public String tksTntSeqNo;
    //        /// <summary>
    //        /// 年月 
    //        /// </summary>
    //        public String yymm;
    //    }

    //    #endregion "構造体"

    //    #region "インスタンス変数"
    //    /// <summary>
    //    /// LIONプロセスコントローラー
    //    /// </summary>
    //    public static HistoryLionProcessController _processController;

    //    /// <summary>
    //    /// Lionサービスアダプター
    //    /// </summary>
    //    public lionHistoryServiceAdapter _adapter;

    //    public static HisDsLion _dsHis;
    //    #endregion "インスタンス変数"

    //    #region "コンストラクタ"

    //    public HistoryLionProcessController()
    //    {
    //        _adapter = CreateAdapter<lionHistoryServiceAdapter>();
    //    }

    //    #endregion "コンストラクタ"

    //    #region "メソッド"

    //    /// <summary>
    //    /// Lionプロセスコントローラーのインスタンスを返します
    //    /// </summary>
    //    /// <returns></returns>
    //    public static HistoryLionProcessController GetInstance()
    //    {
    //        if (_processController == null)
    //        {
    //            _processController = new HistoryLionProcessController();
    //        }
    //        return _processController;
    //    }

    //    /// <summary>
    //    /// 受注ダウンロード履歴
    //    /// </summary>
    //    /// <param name="param"></param>
    //    /// <returns></returns>
    //    public FindHisLionByCondServiceResult findHisJyutDown(findHisJyutDownparam param)
    //    {
    //        FindHisLionByCondServiceResult serviceResult = new FindHisLionByCondServiceResult();
    //        historyLionJyutDownCondition cond = new historyLionJyutDownCondition();

    //        cond.esqId = param.esqId;
    //        cond.egCd = param.egCd;
    //        cond.tksKgyCd = param.tksKgyCd;
    //        cond._tksBmnSeqNo = param.tksBmnSeqNo;
    //        cond._tksTntSeqNo = param.tksTntSeqNo;
    //        cond._yymm = param.yymm;

    //        historyLionJyutDownResult result = _adapter.findHistoryByCond(cond);
    //        errorInfo info = result.errorInfo;
    //        if (info != null && info.error)
    //        {
    //            // サービスの呼び出しエラー
    //            serviceResult.MessageCode = info.errorCode;
    //            serviceResult.Note = info.note;

    //            return serviceResult;
    //        }

    //        FindHisLionByCondServiceResult parseResult = HistoryLionParser.ParseForFindHisJyutDown(result);
    //        _dsHis = parseResult.dsLionDataSet;

    //        serviceResult.dsLionDataSet = parseResult.dsLionDataSet;

    //        return serviceResult;
    //    }
       

    //    #endregion "メソッド"

    }
}
