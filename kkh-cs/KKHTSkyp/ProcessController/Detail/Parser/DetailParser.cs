using System;

using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHServiceProxy;

namespace Isid.KKH.Skyp.ProcessController.Detail.Parser
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
    ///       <description>2011/12/21</description>
    ///       <description>JSE Y.Sato</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class DetailParser
    {
        /// <summary>
        /// 並び順情報を取得。 
        /// </summary>
        /// <param name="result">並び順情報の検索結果</param>
        /// <returns>並び順情報の検索パース結果</returns>
        internal static FindOrderByCondParseResult ParseForFindOrderDataByCond(findOrderByCondResult result)
        {
            Isid.KKH.Skyp.Schema.DetailDSSkyp dsSkyp = new Isid.KKH.Skyp.Schema.DetailDSSkyp();

            findOrderCondVO[] orderDataVOList = result.orderList;
            if (orderDataVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsSkyp.OrderData.TableName, orderDataVOList) };
                Isid.KKH.Skyp.Schema.DetailDSSkyp dsData = new Isid.KKH.Skyp.Schema.DetailDSSkyp();
                dsData = DataSetConverter.Convert<Isid.KKH.Skyp.Schema.DetailDSSkyp>(defs);
                dsSkyp.OrderData.Merge(dsData.OrderData);
            }

            FindOrderByCondParseResult parseResult = new FindOrderByCondParseResult();
            parseResult.DetailDataSet = dsSkyp;

            return parseResult;
        }
    }
}
