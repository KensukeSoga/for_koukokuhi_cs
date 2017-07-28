using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;

namespace Isid.KKH.Lion.ProcessController.Report.Parser
{
    /// <summary>
    /// 得意先ライオン請求予定表サービスパーサー.
    /// </summary>
    /// <remarks>
    ///   修正管理.
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2014/07/31</description>
    ///       <description>HLC S.Fujimoto</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class InvoicePlanParser
    {
        #region メソッド.

        /// <summary>
        /// 検索パース結果を取得します.
        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static FindInvoicePlanByCondParserResult ParseForFindInvoicePlanByCond(invoicePlanLionResult result)
        {
            Isid.KKH.Lion.Schema.InvoicePlanLion dsInvPlnList = new Isid.KKH.Lion.Schema.InvoicePlanLion();

            invoicePlanLionVO[] invoicePlanVOList = result.invoicePlanInfo;
            if (invoicePlanVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsInvPlnList.InvoicePlan.TableName, invoicePlanVOList) };
                Isid.KKH.Lion.Schema.InvoicePlanLion dsInvPln = DataSetConverter.Convert<Isid.KKH.Lion.Schema.InvoicePlanLion>(defs);
                dsInvPlnList.InvoicePlan.Merge(dsInvPln.InvoicePlan);
            }

            FindInvoicePlanByCondParserResult parseResult = new FindInvoicePlanByCondParserResult();
            parseResult.InvPlnLionDataSet = dsInvPlnList;

            return parseResult;
        }

        #endregion
    }
}
