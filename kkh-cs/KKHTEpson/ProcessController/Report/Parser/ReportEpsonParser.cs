using System;

using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHServiceProxy;

namespace Isid.KKH.Epson.ProcessController.Report.Parser
{
    /// <summary>
    /// レポート（エプソン）サービスパーサー 
    /// </summary>
    /// <remarks>
    ///   修正管理 
    ///   <list type="table">
    ///     <listheader>
    ///       <description>2012/3/13</description>
    ///       <description>IP J.Kamiyama</description>
    ///       <description>修正</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/3/5</description>
    ///       <description>JSE Y.Sato</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class ReportEpsonParser
    {
        /// <summary>
        /// 帳票（エプソン_提出帳票）データを取得。 
        /// </summary>
        /// <param name="result">帳票（エプソン_提出帳票）データの検索結果</param>
        /// <returns>帳票帳票（エプソン_提出帳票）データの検索パース結果</returns>
        internal static FindReportEpsonSubMissionByCondParseResult ParseForFindReportEpsonSubMissionByCond(reportEpsonSubMissionResult result)
        {
            Isid.KKH.Epson.Schema.RepDsEpson dsEpson = new Isid.KKH.Epson.Schema.RepDsEpson();

            reportEpsonSubMissionVO[] report = result.reportEpsonSubMission;
            if (report != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsEpson.ReportSubMission.TableName, report) };
                Isid.KKH.Epson.Schema.RepDsEpson dsData = new Isid.KKH.Epson.Schema.RepDsEpson();
                dsData = DataSetConverter.Convert<Isid.KKH.Epson.Schema.RepDsEpson>(defs);
                dsEpson.ReportSubMission.Merge(dsData.ReportSubMission);
            }

            FindReportEpsonSubMissionByCondParseResult parseResult = new FindReportEpsonSubMissionByCondParseResult();
            parseResult.ReportDataSet = dsEpson;

            return parseResult;
        }

        /// <summary>
        /** 2012/03/13 UPDATE START */
        /// 帳票（エプソン_請求予定一覧）データを取得。 
        /// </summary>
        /// <param name="result">帳票（エプソン_請求予定一覧）データの検索結果</param>
        /// <returns>帳票（エプソン_請求予定一覧）データの検索パース結果</returns>
        internal static FindReportEpsonSeikyuPlanByCondParseResult ParseForFindReportEpsonSeikyuPlanByCond(reportEpsonSeikyuPlanResult result)
        {
            Isid.KKH.Epson.Schema.RepDsEpson dsEpson = new Isid.KKH.Epson.Schema.RepDsEpson();

            reportEpsonSeikyuPlanVO[] report = result.reportEpsonSeikyuPlan;
            if (report != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsEpson.ReportSeikyuPlan.TableName, report) };
                Isid.KKH.Epson.Schema.RepDsEpson dsData = new Isid.KKH.Epson.Schema.RepDsEpson();
                dsData = DataSetConverter.Convert<Isid.KKH.Epson.Schema.RepDsEpson>(defs);
                dsEpson.ReportSeikyuPlan.Merge(dsData.ReportSeikyuPlan);
            }

            FindReportEpsonSeikyuPlanByCondParseResult parseResult = new FindReportEpsonSeikyuPlanByCondParseResult();
            parseResult.ReportDataSet = dsEpson;

            return parseResult;
        }
        /** 2012/03/13 UPDATE END */

    }
}
