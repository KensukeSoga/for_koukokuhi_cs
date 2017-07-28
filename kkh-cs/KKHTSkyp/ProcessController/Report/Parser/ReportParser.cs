using System;

using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHServiceProxy;

namespace Isid.KKH.Skyp.ProcessController.Report.Parser
{
    /// <summary>
    /// 広告費明細入力サービスパーサー 
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
    ///       <description>2012/1/16</description>
    ///       <description>JSE Y.Sato</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class ReportParser
    {
        /// <summary>
        /// 帳票（スカパー_納品／請求書）データを取得。 
        /// </summary>
        /// <param name="result">帳票（スカパー_納品／請求書）データの検索結果</param>
        /// <returns>帳票（スカパー_納品／請求書）データの検索パース結果</returns>
        internal static FindReportSkypByCondParseResult ParseForFindReportSkypByCond(reportSkypResult result)
        {
            Isid.KKH.Skyp.Schema.RepDSSkyp dsSkyp = new Isid.KKH.Skyp.Schema.RepDSSkyp();

            reportSkypVO[] report = result.reportSkyp;
            if (report != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsSkyp.ReportData.TableName, report) };
                Isid.KKH.Skyp.Schema.RepDSSkyp dsData = new Isid.KKH.Skyp.Schema.RepDSSkyp();
                dsData = DataSetConverter.Convert<Isid.KKH.Skyp.Schema.RepDSSkyp>(defs);
                dsSkyp.ReportData.Merge(dsData.ReportData);
            }
            
            FindReportSkypByCondParseResult parseResult = new FindReportSkypByCondParseResult();
            parseResult.ReportDataSet = dsSkyp;

            return parseResult;
        }
    }
}
