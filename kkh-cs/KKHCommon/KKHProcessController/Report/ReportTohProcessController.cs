using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common;
using Isid.KKH.Common.KKHProcessController.Report.Parser;

namespace Isid.KKH.Common.KKHProcessController.Report
{
    /// <summary>
    /// 帳票（TOH）プロセスコントローラ
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
    public class ReportTohProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region インスタンス変数

        /// <summary>
        /// マスタプロセスコントローラ
        /// </summary>
        private static ReportTohProcessController _processController;

        /// <summary>
        /// マスタサービスアダプター
        /// </summary>
        private reportServiceAdapter _adapter;

        /// <summary>
        /// データセット
        /// </summary>
        private static Isid.KKH.Common.KKHSchema.RepDsToh _dsRep;

        #endregion インスタンス変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタです。
        /// </summary>
        private ReportTohProcessController()
        {
            _adapter = CreateAdapter<reportServiceAdapter>();
        }

        #endregion コンストラクタ

        #region メソッド

        /// <summary>
        /// コードマスタプロセスコントローラのインスタンスを取得します。

        /// </summary>
        /// <returns>コードマスタプロセスコントローラのインスタンス</returns>
        public static ReportTohProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new ReportTohProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 帳票データ検索
        /// </summary>
        /// <returns>検索サービス結果</returns>
        /// 
        public FindReportTohByCondServiceResult FindRepTohByCond(String esqId, String egCd, String tksKgyCd, String bmn, String tnt, String ymd, String kbn, String kenbaikbn)
        {
            // サービス結果
            FindReportTohByCondServiceResult serviceResult = new FindReportTohByCondServiceResult();

            reportTohCondition condition = new reportTohCondition();
            condition.esqId = esqId;
            condition.egCd = egCd;
            condition.tksKgyCd = tksKgyCd;
            condition.bmncd = bmn;
            condition.tntcd = tnt;
            condition.kbn = kbn;
            condition.ymd = ymd;
            condition.kenbaikbn = kenbaikbn;

            // サービスの呼び出し
            reportTohResult result = _adapter.findReportTohByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース
            FindReportTohByCondParseResult parseResult = ReportTohParser.ParseForFindReportTohByCond(result);
            _dsRep = parseResult.ReoTohDataSet;

            // サービス結果の生成
            serviceResult.dsRepTohDataSet = parseResult.ReoTohDataSet;

            return serviceResult;
        }

      

        #endregion
    }
}
