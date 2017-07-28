using System;
using System.Collections.Generic;
using System.Text;

using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;

namespace Isid.KKH.Epson.ProcessController.Detail.Parser
{
    /// <summary>
    /// パース機能
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
    ///       <description>2012/04/25</description>
    ///       <description>JSE Tamura</description>
    ///       <description>請求回収機能実装</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    
    internal class DetailEpsonParser
    {
        #region メソッド
        internal static FindDetailDataEpsonByCondParseResult ParseForFindDetailDataEpsonByCond(detailDataEpsonResult result)
        {
            Isid.KKH.Epson.Schema.DetailDSEpson dsDetailEpson = new Isid.KKH.Epson.Schema.DetailDSEpson();

            detailDataFindEpsonVO[] detailDataEpsonVOList = result.detailData;
            if (detailDataEpsonVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetailEpson.DetailDataEpson.TableName, detailDataEpsonVOList) };
                Isid.KKH.Epson.Schema.DetailDSEpson dsData = DataSetConverter.Convert<Isid.KKH.Epson.Schema.DetailDSEpson>(defs);
                dsDetailEpson.DetailDataEpson.Merge(dsData.DetailDataEpson);
            }

            FindDetailDataEpsonByCondParseResult parseResult = new FindDetailDataEpsonByCondParseResult();
            parseResult.DetailEpsonDataSet = dsDetailEpson;

            return parseResult;
        }

        /// <summary>
        /// 請求回収データ検索パース結果を取得します。 
        /// </summary>
        /// <param name="result">請求回収データ検索結果</param>
        /// <returns>請求回収データ検索パース結果</returns>
        internal static FindSeikyuDataEpsonByCondParseResult ParseForFindSeikyuDataEpsonByCond(seikyuDataEpsonResult result)
        {
            Isid.KKH.Epson.Schema.SeikyuDsEpson dsSeikyuEpson = new Isid.KKH.Epson.Schema.SeikyuDsEpson();

            thb14SkdownVO[] thb14skdownVOList = result.seikyuData;
            if (thb14skdownVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsSeikyuEpson.THB14SKDOWN.TableName, thb14skdownVOList) };
                Isid.KKH.Epson.Schema.SeikyuDsEpson dsData = DataSetConverter.Convert<Isid.KKH.Epson.Schema.SeikyuDsEpson>(defs);
                dsSeikyuEpson.THB14SKDOWN.Merge(dsData.THB14SKDOWN);
            }

            FindSeikyuDataEpsonByCondParseResult parseResult = new FindSeikyuDataEpsonByCondParseResult();
            parseResult.SeikyuEpsonDataSet = dsSeikyuEpson;

            return parseResult;
        }
        #endregion メソッド
    }
}
