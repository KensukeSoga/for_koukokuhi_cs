using System;
using System.Collections.Generic;
using System.Text;

using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;

namespace Isid.KKH.Lion.ProcessController.Detail.Parser
{
    internal class FindLionCardNoGetParser
    {
        #region メソッド
        internal static FindDetailDataLionByCondParseResult ParseForFindLionCardNoGetByCond(findLionCardNoGetResult result)
        {
            Isid.KKH.Lion.Schema.DetailDSLion dsDetailLion = new Isid.KKH.Lion.Schema.DetailDSLion();

            findLionCardNoGetVO[] findLionCardNoGetVOList = result.findLionCardNoGet;
            if (findLionCardNoGetVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetailLion.KkhCardNo.TableName, findLionCardNoGetVOList) };
                Isid.KKH.Lion.Schema.DetailDSLion dsData = DataSetConverter.Convert<Isid.KKH.Lion.Schema.DetailDSLion>(defs);
                dsDetailLion.KkhCardNo.Merge(dsData.KkhCardNo);
            }

            FindDetailDataLionByCondParseResult parseResult = new FindDetailDataLionByCondParseResult();
            parseResult.DetailLionDataSet = dsDetailLion;

            return parseResult;
        }
        #endregion メソッド
    }
}
