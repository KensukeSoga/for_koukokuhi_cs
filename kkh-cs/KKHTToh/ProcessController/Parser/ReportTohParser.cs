using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Toh.Schema;

namespace Isid.KKH.Toh.ProcessController.Parser
{
    /// <summary>
    /// レポート（TOH)サービスパーサー
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
    internal class ReportTohParser
    {
        #region メソッド
        /// <summary>
        /// 検索パース結果を取得します。 
        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static FindReportTohByCondParseResult ParseForFindReportTohByCond(reportTohResult result)
        {
            Isid.KKH.Toh.Schema.RepDsToh dsrep = new Isid.KKH.Toh.Schema.RepDsToh();

            reportTohVO[] reportTohVOList = result.reportToh;
            if (reportTohVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.Reptoh.TableName, reportTohVOList) };
                Isid.KKH.Toh.Schema.RepDsToh dsAddMaster = DataSetConverter.Convert<Isid.KKH.Toh.Schema.RepDsToh>(defs);
                dsrep.Reptoh.Merge(dsAddMaster.Reptoh);
            }

            FindReportTohByCondParseResult parseResult = new FindReportTohByCondParseResult();
            parseResult.ReoTohDataSet = dsrep;

            return parseResult;
        }

        /// <summary>
        /// 検索パース結果を取得します。 
        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static FindReportTohByCondParseResult ParseForFindReportTohTotalByCond(reportTohTotalResult result)
        {
            Isid.KKH.Toh.Schema.RepDsToh dsrep = new Isid.KKH.Toh.Schema.RepDsToh();
            
            reportTohTotalVO[] reportTohTotalVOList = result.reportTohTotal;
            if (reportTohTotalVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.ReptohTotal.TableName, reportTohTotalVOList) };
                Isid.KKH.Toh.Schema.RepDsToh dsAddMaster = DataSetConverter.Convert<Isid.KKH.Toh.Schema.RepDsToh>(defs);
                dsrep.ReptohTotal.Merge(dsAddMaster.ReptohTotal);
            }

            FindReportTohByCondParseResult parseResult = new FindReportTohByCondParseResult();
            parseResult.ReoTohDataSet = dsrep;

            return parseResult;
        }

        #endregion
    }
}
