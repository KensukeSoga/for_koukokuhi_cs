using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;

namespace Isid.KKH.Lion.ProcessController.Report.Parser
{
    /// <summary>
    /// 得意先ライオン受注比較一覧サービスパーサー.
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
    ///       <description>2014/11/10</description>
    ///       <description>HLC S.Fujimoto</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class OrderDiffListParser
    {
        #region メソッド.

        /// <summary>
        /// 検索パース結果を取得します.
        /// </summary>
        /// <param name="result">受注比較一覧検索結果</param>
        /// <returns>受注比較一覧検索パース結果</returns>
        internal static FindOrderDiffListByCondParserResult ParseForFindOrderDiffListByCond(orderDiffListLionResult result)
        {
            Isid.KKH.Lion.Schema.OrderDiffLion dsOrdDiffList = new Isid.KKH.Lion.Schema.OrderDiffLion();

            orderDiffListLionVO[] orderDiffListVOList = result.orderDiffListInfo;
            if (orderDiffListVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsOrdDiffList.OrderDiffList.TableName, orderDiffListVOList) };
                Isid.KKH.Lion.Schema.OrderDiffLion dsOrderDiff = DataSetConverter.Convert<Isid.KKH.Lion.Schema.OrderDiffLion>(defs);
                dsOrdDiffList.OrderDiffList.Merge(dsOrderDiff.OrderDiffList);
            }

            orderDiffListLionVO[] orderNewListVOList = result.newOrderListInfo;
            if (orderNewListVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsOrdDiffList.OrderNewList.TableName, orderNewListVOList) };
                Isid.KKH.Lion.Schema.OrderDiffLion dsOrderDiff = DataSetConverter.Convert<Isid.KKH.Lion.Schema.OrderDiffLion>(defs);
                dsOrdDiffList.OrderNewList.Merge(dsOrderDiff.OrderNewList);
            }

            orderDiffListLionVO[] orderAmountDiffListVOList = result.orderAmountDiffListInfo;
            if (orderAmountDiffListVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsOrdDiffList.OrderAmountDiffList.TableName, orderAmountDiffListVOList) };
                Isid.KKH.Lion.Schema.OrderDiffLion dsOrderDiff = DataSetConverter.Convert<Isid.KKH.Lion.Schema.OrderDiffLion>(defs);
                dsOrdDiffList.OrderAmountDiffList.Merge(dsOrderDiff.OrderAmountDiffList);
            }
                
            FindOrderDiffListByCondParserResult parseResult = new FindOrderDiffListByCondParserResult();
            parseResult.OrdDiffListLionDataSet = dsOrdDiffList;

            return parseResult;
        }

        #endregion
    }
}
