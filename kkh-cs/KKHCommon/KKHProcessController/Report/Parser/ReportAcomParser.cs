using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHSchema;

namespace Isid.KKH.Common.KKHProcessController.Report.Parser
{
    /// <summary>
    /// レポート（Acom)サービスパーサー.
    /// </summary>
    /// <remarks>
    ///   修正管理.
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付.</description>
    ///       <description>修正者.</description>
    ///       <description>内容.</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/01/11.</description>
    ///       <description>作成者.</description>
    ///       <description>新規作成.</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class ReportAcomParser
    {
        #region メソッド
        /// <summary>
        /// 検索パース結果を取得します.
        /// </summary>
        /// <param name="result">マスタ検索結果.</param>
        /// <returns>マスタ検索パース結果.</returns>
        internal static FindReportAcomByCondParseResult ParseForFindReportAcomByCond(reportAcomResult result)
        {
            Isid.KKH.Common.KKHSchema.RepDsAcom dsrep = new Isid.KKH.Common.KKHSchema.RepDsAcom();

            reportAcomVO[] reportAcomVOList = result.reportAcom;
            if (reportAcomVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.RepAcom.TableName , reportAcomVOList) };
                Isid.KKH.Common.KKHSchema.RepDsAcom dsAddMaster = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.RepDsAcom>(defs);
                dsrep.RepAcom.Merge(dsAddMaster.RepAcom);
            }

            FindReportAcomByCondParseResult parseResult = new FindReportAcomByCondParseResult();
            parseResult.RepAcomDataSet = dsrep;

            return parseResult;
        }

        #endregion

    }
}
