using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using System.Data;

namespace Isid.KKH.Common.KKHProcessController.SystemCommon.Parser
{

    /// <summary>
    /// 履歴サービスパーサー 
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
    ///       <description>2011/02/03</description>
    ///       <description>HLC K.Honma</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class CommonParser
    {
        #region メソッド

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        internal static FindCommonByCondParseResult ParseForFindCommonByCond(commonResult result)
        {
            Isid.KKH.Common.KKHSchema.Common dsCommon = new Isid.KKH.Common.KKHSchema.Common();

            commonVO[] commonVOList = result.common;
            if (commonVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsCommon.SystemCommon.TableName, commonVOList) };
                Isid.KKH.Common.KKHSchema.Common dsMaster = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.Common>(defs);
                dsCommon.SystemCommon.Merge(dsMaster.SystemCommon);
            }

            FindCommonByCondParseResult parseResult = new FindCommonByCondParseResult();
            parseResult.CommonDataSet = dsCommon;

            return parseResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        internal static FindCommonCodeMasterByCondParseResult ParseForFindCommonCodeMasterByCond(commonCodeMasterResult result)
        {
            Isid.KKH.Common.KKHSchema.Common dsCommon = new Isid.KKH.Common.KKHSchema.Common();

            commonCodeMasterVO[] commonCodeMasterVOList = result.commonCodeMaster;
            if (commonCodeMasterVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsCommon.RcmnMeu29CC.TableName, commonCodeMasterVOList) };
                Isid.KKH.Common.KKHSchema.Common dsCommonCode = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.Common>(defs);
                dsCommon.RcmnMeu29CC.Merge(dsCommonCode.RcmnMeu29CC);
            }

            FindCommonCodeMasterByCondParseResult parseResult = new FindCommonCodeMasterByCondParseResult();
            parseResult.CommonDataSet = dsCommon;

            return parseResult;
        }

        #endregion メソッド
    }
}
