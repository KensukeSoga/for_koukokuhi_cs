using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;

namespace Isid.KKH.Lion.ProcessController.Report.Parser
{
    /// <summary>
    /// レポート（Lion)サービスパーサー.
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
    internal class ReportLionParser
    {
        #region メソッド
        /// <summary>
        /// 検索パース結果を取得します.
        /// </summary>
        /// <param name="result">マスタ検索結果.</param>
        /// <returns>マスタ検索パース結果.</returns>
        internal static FindReportLionByCondParseResult ParseForFindReportLionByCond(reportLionResult result)
        {
            Isid.KKH.Lion.Schema.RepDsLion dsrep = new Isid.KKH.Lion.Schema.RepDsLion();

            reportLionVO[] reportLionVOList = result.reportLion;
            if (reportLionVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.RepLion.TableName , reportLionVOList) };
                Isid.KKH.Lion.Schema.RepDsLion dsAddMaster = DataSetConverter.Convert<Isid.KKH.Lion.Schema.RepDsLion>(defs);
                dsrep.RepLion.Merge(dsAddMaster.RepLion);
            }

            reportLionVO[] reportLionSyohiZeiVOList = result.reportLionSyohiZei;
            if (reportLionSyohiZeiVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.RepLionSyohiZei.TableName, reportLionSyohiZeiVOList) };
                Isid.KKH.Lion.Schema.RepDsLion dsAddMaster = DataSetConverter.Convert<Isid.KKH.Lion.Schema.RepDsLion>(defs);
                dsrep.RepLionSyohiZei.Merge(dsAddMaster.RepLionSyohiZei);
            }
            reportLionVO[] reportLionBaitaiVOList = result.baitaiCdName;
            if (reportLionBaitaiVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.BaitaiCdName.TableName, reportLionBaitaiVOList) };
                Isid.KKH.Lion.Schema.RepDsLion dsAddMaster = DataSetConverter.Convert<Isid.KKH.Lion.Schema.RepDsLion>(defs);
                dsrep.BaitaiCdName.Merge(dsAddMaster.BaitaiCdName);
            }

            FindReportLionByCondParseResult parseResult = new FindReportLionByCondParseResult();
            parseResult.RepLionDataSet = dsrep;

            return parseResult;
        }
        internal static FindReportLionByCondParseResult ParseForFindNewReportLionByCond(newReportLionResult result)
        {
            Isid.KKH.Lion.Schema.RepDsLion dsrep = new Isid.KKH.Lion.Schema.RepDsLion();
            newReportLionVO[] newReportLionList = result.reportLion;
            if (newReportLionList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.NewRepLion.TableName, newReportLionList) };
                Isid.KKH.Lion.Schema.RepDsLion dsAddMaster = DataSetConverter.Convert<Isid.KKH.Lion.Schema.RepDsLion>(defs);
                dsrep.NewRepLion.Merge(dsAddMaster.NewRepLion);
            }

            FindReportLionByCondParseResult parseResult = new FindReportLionByCondParseResult();
            parseResult.RepLionDataSet = dsrep;

            return parseResult;
        }
        #endregion

    }
}
