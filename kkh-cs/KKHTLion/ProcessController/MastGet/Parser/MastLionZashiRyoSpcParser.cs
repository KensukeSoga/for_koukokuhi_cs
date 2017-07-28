using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Lion.Schema;
using Isid.Soa.Framework.Client.DataSetConverter;

namespace Isid.KKH.Lion.ProcessController.MastGet.Parser
{
    /// <summary>
    /// 雑誌スペース料金マスタパーサー 
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
    ///       <description>2012/03/02</description>
    ///       <description>JSE A.Naito</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class MastLionZashiRyoSpcParser
    {
        #region "メソッド"

        internal static MastLionZashiRyoSpcServiceResult ParseForMastLionZashiRyoSpc(lionZashiRyoSpcMastResult result)
        {
            MastLion mastlion = new MastLion();

            lionZashiRyoSpcMastVO[] LionZashiRyoSpcMastVOList = result.lionZashiRyoSpcMast;
            if (LionZashiRyoSpcMastVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(mastlion.MastZashi.TableName, LionZashiRyoSpcMastVOList) };
                MastLion dsAddMaster = DataSetConverter.Convert<MastLion>(defs);
                mastlion.MastZashi.Merge(dsAddMaster.MastZashi);
            }

            MastLionZashiRyoSpcServiceResult parseResult = new MastLionZashiRyoSpcServiceResult();
            parseResult.MZLionDataSet = mastlion;

            return parseResult;

        }
            #endregion "メソッド"
    }
}
