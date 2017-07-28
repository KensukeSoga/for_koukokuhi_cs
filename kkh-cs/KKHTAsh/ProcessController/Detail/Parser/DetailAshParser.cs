using System;
using System.Collections.Generic;
using System.Text;

using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;

namespace Isid.KKH.Ash.ProcessController.Detail.Parser
{
    internal class DetailAshParser
    {
        #region メソッド
        internal static FindDetailDataAshByCondParseResult ParseForFindDetailDataAshByCond(detailDataAshResult result)
        {
            Isid.KKH.Ash.Schema.DetailDSAsh dsDetailAsh = new Isid.KKH.Ash.Schema.DetailDSAsh();

            detailDataAshVO[] detailDataAshVOList = result.detailData;
            if (detailDataAshVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetailAsh.DetailDataAsh.TableName, detailDataAshVOList) };
                Isid.KKH.Ash.Schema.DetailDSAsh dsData = DataSetConverter.Convert<Isid.KKH.Ash.Schema.DetailDSAsh>(defs);
                dsDetailAsh.DetailDataAsh.Merge(dsData.DetailDataAsh);
            }

            FindDetailDataAshByCondParseResult parseResult = new FindDetailDataAshByCondParseResult();
            parseResult.DetailAshDataSet = dsDetailAsh;

            return parseResult;
        }

        // 張(Jang) ADD START 2014/08/15
        internal static FindKeyKyokuBangumiCdParseResult ParseForFindKeyKyokuBangumiCd(findKeyKyokuBangumiCdResult result)
        {
            Isid.KKH.Ash.Schema.DetailDSAsh dsDetailAsh = new Isid.KKH.Ash.Schema.DetailDSAsh();

            findKeyKyokuBangumiCdVO[] findKeyKyokuBangumiCdVOList = result.bangumiCdList;
            if (findKeyKyokuBangumiCdVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetailAsh.KeyKyokuBangumiCd.TableName, findKeyKyokuBangumiCdVOList) };
                Isid.KKH.Ash.Schema.DetailDSAsh dsData = DataSetConverter.Convert<Isid.KKH.Ash.Schema.DetailDSAsh>(defs);
                dsDetailAsh.KeyKyokuBangumiCd.Merge(dsData.KeyKyokuBangumiCd);
            }

            FindKeyKyokuBangumiCdParseResult parseResult = new FindKeyKyokuBangumiCdParseResult();
            parseResult.DetailAshDataSet = dsDetailAsh;

            return parseResult;
        }
        // 張(Jang) ADD END 2014/08/15
        #endregion メソッド
    }
}
