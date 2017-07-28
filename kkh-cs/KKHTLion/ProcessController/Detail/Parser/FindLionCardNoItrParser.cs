using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Lion.Schema;
using Isid.Soa.Framework.Client.DataSetConverter;

namespace Isid.KKH.Lion.ProcessController.Detail.Parser
{
    /// <summary>
    /// カードNO一覧サービスパーサー 
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
    ///       <description>2012/02/22</description>
    ///       <description>JSE A.Naito</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class FindLionCardNoItrParser
    {

        #region "メソッド"

        internal static FindLionCardNoItrServiceResult ParseForFindLionCardNoItr(findLionCardNoItrResult result)
        {
           DetailDSLion dslion = new DetailDSLion();

            findLionCardNoItrVO[] FindLionCardNoItrVOList = result.findLionCardNoItr;
            if (FindLionCardNoItrVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dslion.KkhCardNoItr.TableName, FindLionCardNoItrVOList) };
                DetailDSLion dsAddMaster = DataSetConverter.Convert<DetailDSLion>(defs);
                dslion.KkhCardNoItr.Merge(dsAddMaster.KkhCardNoItr);
            }

            FindLionCardNoItrServiceResult parseResult = new FindLionCardNoItrServiceResult();
            parseResult.CNILionDataSet = dslion;

            return parseResult;

        }
            #endregion "メソッド"
    }
}
