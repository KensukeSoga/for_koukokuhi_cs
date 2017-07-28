using System;
using System.Collections.Generic;
using System.Text;

using Isid.Soa.Framework.Client.Proxy;
using Isid.NJSecurity.Core;
using Isid.NJ.ProcessController;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHProcessController.Detail.Converter;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Common.KKHProcessController.Detail;
using Isid.KKH.Tkd.ProcessController.Report.Parser;

namespace Isid.KKH.Tkd.ProcessController.Report
{
    /// <summary>
    /// 広告費明細入力プロセスコントローラ(武田薬品) 
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
    ///       <description>2012/01/23</description>
    ///       <description>JSE H.Sasaki</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class ReportTkdBillingProcessController : Isid.KKH.Common.KKHProcessController.Common.KKHProcessController
    {
        #region インスタンス変数

        /// <summary>
        /// マスタプロセスコントローラ
        /// </summary>
        private static ReportTkdBillingProcessController _processController;

        /// <summary>
        /// マスタサービスアダプター
        /// </summary>
        private reportTkdBillingServiceAdapter _adapter;

        /// <summary>
        /// データセット
        /// </summary>
        private static Isid.KKH.Tkd.Schema.ReportDSTkdBilling _dsReportTkdBillingDataSet;

        #endregion インスタンス変数

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private ReportTkdBillingProcessController()
        {
            _adapter = CreateAdapter<reportTkdBillingServiceAdapter>();
        }

        #endregion コンストラクタ

        #region メソッド

        /// <summary>
        /// コードマスタプロセスコントローラのインスタンスを取得します。
        /// </summary>
        /// <returns>コードマスタプロセスコントローラのインスタンス</returns>
        public static ReportTkdBillingProcessController GetInstance()
        {
            if (_processController == null)
            {
                _processController = new ReportTkdBillingProcessController();
            }
            return _processController;
        }

        /// <summary>
        /// 帳票データ検索
        /// </summary>
        /// <returns>検索サービス結果</returns>
        /// 
        public FindReportTkdBillingByMiddleClassificationByCondServiceResult FindReportTkdBillingByCond(String esqId, String egCd, String tksKgyCd, String bmn, String tnt, String ym, String kbn )
        {
            // サービス結果
            FindReportTkdBillingByMiddleClassificationByCondServiceResult serviceResult = new FindReportTkdBillingByMiddleClassificationByCondServiceResult();

            reportTkdBillingByMiddleClassificationCondition condition = new reportTkdBillingByMiddleClassificationCondition();
            condition.esqId = esqId;
            condition.egCd = egCd;
            condition.tksKgyCd = tksKgyCd;
            condition.tksBmnSeqNo = bmn;
            condition.tksTntSeqNo = tnt;
            condition.ym = ym;
            condition.kbn = kbn;

            // サービスの呼び出し
            reportTkdBillingByMiddleClassificationResult result = _adapter.findReportTkdBillingByMiddleClassificationByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース
            FindReportTkdBillingByMiddleClassificationByCondParseResult parseResult = ReportTkdBillingParser.ParseForFindReportByMiddleClassificationByCond(result);
            _dsReportTkdBillingDataSet = parseResult.ReportTkdBillingDataSet;

            // サービス結果の生成
            serviceResult.dsReportTkdBillingDataSet = parseResult.ReportTkdBillingDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 帳票データ検索
        /// </summary>
        /// <returns>検索サービス結果</returns>
        /// 
        public FindReportTkdBillingByItemByCondServiceResult FindReportTkdBillingByItemByCond(String esqId, String egCd, String tksKgyCd, String bmn, String tnt, String ym, String kbn)
        {
            // サービス結果
            FindReportTkdBillingByItemByCondServiceResult serviceResult = new FindReportTkdBillingByItemByCondServiceResult();

            reportTkdBillingByItemCondition condition = new reportTkdBillingByItemCondition();
            condition.esqId = esqId;
            condition.egCd = egCd;
            condition.tksKgyCd = tksKgyCd;
            condition.tksBmnSeqNo = bmn;
            condition.tksTntSeqNo = tnt;
            condition.ym = ym;
            condition.kbn = kbn;

            // サービスの呼び出し
            reportTkdBillingByItemResult result = _adapter.findReportTkdBillingByItemByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース
            FindReportTkdBillingByItemByCondParseResult parseResult = ReportTkdBillingParser.ParseForFindReportByItemByCond(result);
            _dsReportTkdBillingDataSet = parseResult.ReportTkdBillingDataSet;

            // サービス結果の生成
            serviceResult.dsReportTkdBillingDataSet = parseResult.ReportTkdBillingDataSet;

            return serviceResult;
        }

        /// <summary>
        /// 帳票データ検索
        /// </summary>
        /// <returns>検索サービス結果</returns>
        /// 
        public FindReportTkdBillingForPlanningCostByCondServiceResult FindReportTkdBillingForPlanningCostByCond(String esqId, String egCd, String tksKgyCd, String bmn, String tnt, String ym)
        {
            // サービス結果
            FindReportTkdBillingForPlanningCostByCondServiceResult serviceResult = new FindReportTkdBillingForPlanningCostByCondServiceResult();

            reportTkdBillingForPlanningCostCondition condition = new reportTkdBillingForPlanningCostCondition();
            condition.esqId = esqId;
            condition.egCd = egCd;
            condition.tksKgyCd = tksKgyCd;
            condition.tksBmnSeqNo = bmn;
            condition.tksTntSeqNo = tnt;
            condition.ym = ym;

            // サービスの呼び出し
            reportTkdBillingForPlanningCostResult result = _adapter.findReportTkdBillingForPlanningCostByCond(condition);

            errorInfo info = result.errorInfo;
            if (info != null && info.error)
            {
                // サービスの呼び出しエラー
                serviceResult.MessageCode = info.errorCode;
                serviceResult.Note = info.note;

                return serviceResult;
            }

            // パース
            FindReportTkdBillingForPlanningCostByCondParseResult parseResult = ReportTkdBillingParser.ParseForFindReportForPlanningCostByCond(result);
            _dsReportTkdBillingDataSet = parseResult.ReportTkdBillingDataSet;

            // サービス結果の生成
            serviceResult.dsReportTkdBillingDataSet = parseResult.ReportTkdBillingDataSet;

            return serviceResult;
        }

        #endregion
    }
}
