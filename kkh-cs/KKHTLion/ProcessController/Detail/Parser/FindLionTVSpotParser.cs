using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Lion.Schema;
using Isid.Soa.Framework.Client.DataSetConverter;

namespace Isid.KKH.Lion.ProcessController.Detail.Parser
{
    /// <summary>
    /// ライオンTVSpotデータ読み込みサービスパーサー 
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
    ///       <description>2012/03/05</description>
    ///       <description>JSE H.Sasaki</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class FindLionTVSpotParser
    {
        #region メソッド

        /// <summary>
        /// TVSpotデータパース結果を取得する。 
        /// </summary>
        /// <param name="result">データ検索結果</param>
        /// <returns>データパース結果</returns>
        internal static FindLionTVSpotServiceResult ParseForFindLionTVSpot(findLionTVSpotResult result)
        {
            DetailDSLion dsDetail = new DetailDSLion();

            findLionTVSpotVO[] resultVOList = result.findLionTVSpot;

            if (resultVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetail.KkhTVSpotResult.TableName, resultVOList) };

                DetailDSLion dsData = DataSetConverter.Convert<DetailDSLion>(defs);

                dsDetail.KkhTVSpotResult.Merge(dsData.KkhTVSpotResult);
            }

            FindLionTVSpotServiceResult parseResult = new FindLionTVSpotServiceResult();

            parseResult.dsDetailLion = dsDetail;

            return parseResult;
        }

        #endregion
    }
}
