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
    ///       <description>2012/02/27</description>
    ///       <description>JSE A.Naito</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class FindLionCodeItrParser
    {

        #region "メソッド"

        internal static FindLionCodeItrServiceResult ParseForFindLionCodeItr(findLionCodeItrResult result)
        {
            DetailDSLion dslion = new DetailDSLion();

            findLionCodeItrVO[] FindLionCodeItrVOList = result.findLionCodeItr;
            if (FindLionCodeItrVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dslion.KkhCodeItr.TableName, FindLionCodeItrVOList) };
                DetailDSLion dsAddMaster = DataSetConverter.Convert<DetailDSLion>(defs);
                dslion.KkhCodeItr.Merge(dsAddMaster.KkhCodeItr);
            }

            FindLionCodeItrServiceResult parseResult = new FindLionCodeItrServiceResult();
            parseResult.CILionDataSet = dslion;

            return parseResult;

        }
            #endregion "メソッド"
    }
}
