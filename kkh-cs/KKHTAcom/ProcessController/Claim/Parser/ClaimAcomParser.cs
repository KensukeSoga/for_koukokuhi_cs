using System;

using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Acom.Schema;

namespace Isid.KKH.Acom.ProcessController.Claim.Parser
{
    /// <summary>
    /// 請求データサービスパーサー 
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
    ///       <description>2012/2/09</description>
    ///       <description>JSE Y.Sato</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class ClaimAcomParser
    {
        /// <summary>
        /// 請求データを取得。 
        /// </summary>
        /// <param name="result">請求データの検索結果</param>
        /// <returns>請求データの検索パース結果</returns>
        internal static FindClaimAcomByCondParseResult ParseForFindClaimAcomByCond(findClaimByCondResult result)
        {
            ClaimDSAcom ds = new ClaimDSAcom();

            // 発注/請求番号データ 
            findClaimNoCondResultVO[] claimNoList = result.claimNoDataList;
            if (claimNoList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(ds.ClaimNoData.TableName, claimNoList) };
                ClaimDSAcom dsData = new ClaimDSAcom();
                dsData = DataSetConverter.Convert<ClaimDSAcom>(defs);
                ds.ClaimNoData.Merge(dsData.ClaimNoData);
            }

            // 請求データ 
            findClaimCondResultVO[] claimList = result.claimDataList;
            if (claimList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(ds.ClaimData.TableName, claimList) };
                ClaimDSAcom dsData = new ClaimDSAcom();
                dsData = DataSetConverter.Convert<ClaimDSAcom>(defs);
                ds.ClaimData.Merge(dsData.ClaimData);
            }

            // 発注/請求差異データ 
            findClaimDiffCondResultVO[] claimDiffList = result.claimDiffDataList;
            if (claimDiffList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(ds.ClaimDiffData.TableName, claimDiffList) };
                ClaimDSAcom dsData = new ClaimDSAcom();
                dsData = DataSetConverter.Convert<ClaimDSAcom>(defs);
                ds.ClaimDiffData.Merge(dsData.ClaimDiffData);
            }

            FindClaimAcomByCondParseResult parseResult = new FindClaimAcomByCondParseResult();
            parseResult.ClaimAcomDataSet = ds;

            return parseResult;
        }
    }
}
