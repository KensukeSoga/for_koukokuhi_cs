using System;
using System.Collections.Generic;
using System.Text;

using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;

namespace Isid.KKH.Lion.ProcessController.Detail.Parser
{
    internal class FindDetailLionParser
    {
        #region メソッド
        internal static FindDetailDataLionByCondParseResult ParseForFindDetailLionNoGetByCond(findLionDetailResult result)
        {
            Isid.KKH.Lion.Schema.DetailDSLion dsDetailLion = new Isid.KKH.Lion.Schema.DetailDSLion();

            findLionDetailVO[] findLionDetailVOList = result.findLionDetail;
            if (findLionDetailVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetailLion.KkhMeisai.TableName, findLionDetailVOList) };
                Isid.KKH.Lion.Schema.DetailDSLion dsData = DataSetConverter.Convert<Isid.KKH.Lion.Schema.DetailDSLion>(defs);
                dsDetailLion.KkhMeisai.Merge(dsData.KkhMeisai);
            }

            FindDetailDataLionByCondParseResult parseResult = new FindDetailDataLionByCondParseResult();
            parseResult.DetailLionDataSet = dsDetailLion;

            return parseResult;
        }
        #endregion メソッド
    }
}
