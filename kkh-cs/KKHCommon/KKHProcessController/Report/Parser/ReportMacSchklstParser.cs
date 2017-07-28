using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHSchema;

namespace Isid.KKH.Common.KKHProcessController.Report.Parser
{
    /// <summary>
    /// レポート（Mac)サービスパーサー
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
    internal class ReportMacSchklstParser
    {
        #region メソッド
        /// <summary>
        /// 検索パース結果を取得します。        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static FindReportMacSchklstByCondParseResult ParseForFindReportMacSchklstByCond(reportMacSchklstResult result)
        {
            Isid.KKH.Common.KKHSchema.RepDsMac dsrep = new Isid.KKH.Common.KKHSchema.RepDsMac();

            reportMacSchklstVO[] reportMacSchklstVOList = result.reportMacSchklst;
            if (reportMacSchklstVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.RepmacSchklst.TableName, reportMacSchklstVOList) };
                Isid.KKH.Common.KKHSchema.RepDsMac dsAddMaster = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.RepDsMac>(defs);
                dsrep.RepmacSchklst.Merge(dsAddMaster.RepmacSchklst);
            }

            FindReportMacSchklstByCondParseResult parseResult = new FindReportMacSchklstByCondParseResult();
            parseResult.ReoMacSchklstDataSet = dsrep;

            return parseResult;
        }

        #endregion
    }
}
