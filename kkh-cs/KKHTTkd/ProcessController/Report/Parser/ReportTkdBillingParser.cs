using System.Data;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Common.KKHProcessController.Report;

namespace Isid.KKH.Tkd.ProcessController.Report.Parser
{
    /// <summary>
    /// 広告費請求明細（武田薬品）サービスパーサー 
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
    internal class ReportTkdBillingParser
    {
        #region メソッド

        /// <summary>
        /// 検索パース結果を取得します。
        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static FindReportTkdBillingByMiddleClassificationByCondParseResult ParseForFindReportByMiddleClassificationByCond(reportTkdBillingByMiddleClassificationResult result)
        {
            Isid.KKH.Tkd.Schema.ReportDSTkdBilling dsrep = new Isid.KKH.Tkd.Schema.ReportDSTkdBilling();

            reportTkdBillingByMiddleClassificationVO[] reportTkdBillingVOList = result.reportTkdBilling;
            if (reportTkdBillingVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.ReportByMiddleClassificationResult.TableName, reportTkdBillingVOList) };
                Isid.KKH.Tkd.Schema.ReportDSTkdBilling dsAddMaster = DataSetConverter.Convert<Isid.KKH.Tkd.Schema.ReportDSTkdBilling>(defs);
                dsrep.ReportByMiddleClassificationResult.Merge(dsAddMaster.ReportByMiddleClassificationResult);
            }

            FindReportTkdBillingByMiddleClassificationByCondParseResult parseResult = new FindReportTkdBillingByMiddleClassificationByCondParseResult();
            parseResult.ReportTkdBillingDataSet = dsrep;

            return parseResult;
        }

        /// <summary>
        /// 検索パース結果を取得します。
        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static FindReportTkdBillingByItemByCondParseResult ParseForFindReportByItemByCond(reportTkdBillingByItemResult result)
        {
            Isid.KKH.Tkd.Schema.ReportDSTkdBilling dsrep = new Isid.KKH.Tkd.Schema.ReportDSTkdBilling();

            reportTkdBillingByItemVO[] reportTkdBillingVOList = result.reportTkdBilling;
            if (reportTkdBillingVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.ReportByItemResult.TableName, reportTkdBillingVOList) };
                Isid.KKH.Tkd.Schema.ReportDSTkdBilling dsAddMaster = DataSetConverter.Convert<Isid.KKH.Tkd.Schema.ReportDSTkdBilling>(defs);
                dsrep.ReportByItemResult.Merge(dsAddMaster.ReportByItemResult);
            }

            FindReportTkdBillingByItemByCondParseResult parseResult = new FindReportTkdBillingByItemByCondParseResult();
            parseResult.ReportTkdBillingDataSet = dsrep;

            return parseResult;
        }

        /// <summary>
        /// 検索パース結果を取得します。
        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static FindReportTkdBillingForPlanningCostByCondParseResult ParseForFindReportForPlanningCostByCond(reportTkdBillingForPlanningCostResult result)
        {
            Isid.KKH.Tkd.Schema.ReportDSTkdBilling dsrep = new Isid.KKH.Tkd.Schema.ReportDSTkdBilling();

            reportTkdBillingForPlanningCostVO[] reportTkdBillingVOList = result.reportTkdBilling;
            if (reportTkdBillingVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.ReportForPlanningCostResult.TableName, reportTkdBillingVOList) };
                Isid.KKH.Tkd.Schema.ReportDSTkdBilling dsAddMaster = DataSetConverter.Convert<Isid.KKH.Tkd.Schema.ReportDSTkdBilling>(defs);
                dsrep.ReportForPlanningCostResult.Merge(dsAddMaster.ReportForPlanningCostResult);
            }

            FindReportTkdBillingForPlanningCostByCondParseResult parseResult = new FindReportTkdBillingForPlanningCostByCondParseResult();
            parseResult.ReportTkdBillingDataSet = dsrep;

            return parseResult;
        }

        #endregion
    }
}
