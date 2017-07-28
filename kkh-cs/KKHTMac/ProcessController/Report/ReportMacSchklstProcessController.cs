using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common;
using Isid.KKH.Mac.ProcessController.Report.Parser;

namespace Isid.KKH.Mac.ProcessController.Report
{
    /// <summary>
    /// 帳票（Mac）プロセスコントローラ
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
    ///       <description>2011/12/15</description>
    ///       <description>JSE KT</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class ReportMacSchklstProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region インスタンス変数

        /// <summary>
        /// マスタプロセスコントローラ
        /// </summary>
        private static ReportMacSchklstProcessController _processController;

        /// <summary>
        /// マスタサービスアダプター
        /// </summary>
        private macReportServiceAdapter _adapter;

        /// <summary>
        /// データセット
        /// </summary>
        private static Isid.KKH.Mac.Schema.RepDsMac _dsRep;

        #endregion インスタンス変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        private ReportMacSchklstProcessController()
        {
            _adapter = CreateAdapter<macReportServiceAdapter>();
        }

        #endregion コンストラクタ

        #region メソッド

        /// <summary>
        /// コードマスタプロセスコントローラのインスタンスを取得します。

        /// </summary>
        /// <returns>コードマスタプロセスコントローラのインスタンス</returns>
        public static ReportMacSchklstProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new ReportMacSchklstProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 帳票データ検索
        /// </summary>
        /// <returns>検索サービス結果</returns>
        /// 
        public FindReportMacSchklstByCondServiceResult FindRepMacSchklstByCond(String esqId, String egCd, String tksKgyCd, String bmn, String tnt, String ymd, String tmp, String mod)
        {
            // サービス結果
            FindReportMacSchklstByCondServiceResult serviceResult = new FindReportMacSchklstByCondServiceResult();

            reportMacSchklstCondition condition = new reportMacSchklstCondition();
            condition.esqId = esqId;
            condition.egCd = egCd;
            condition.tksKgyCd = tksKgyCd;
            condition.tksBmnSeqNo = bmn;
            condition.tksTntSeqNo = tnt;
            condition.ym = ymd;
            condition.code1 = tmp;
            condition.tordflg = mod;

            // サービスの呼び出し
            reportMacSchklstResult result = _adapter.findReportMacSchklstByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース
            FindReportMacSchklstByCondParseResult parseResult = ReportMacSchklstParser.ParseForFindReportMacSchklstByCond(result);
            _dsRep = parseResult.ReoMacSchklstDataSet;

            // サービス結果の生成
            serviceResult.dsRepMacSchklstDataSet = parseResult.ReoMacSchklstDataSet;

            return serviceResult;
        }

      

        #endregion
    }
}
