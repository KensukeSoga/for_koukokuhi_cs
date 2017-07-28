using System.Data;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Common.KKHProcessController.Report;
using Isid.KKH.Lion.Schema;

namespace Isid.KKH.Lion.ProcessController.Report.Parser
{
    //TODO FD出力の名称は廃止となるため、名称が確定し次第修正する事 
    /// <summary>
    /// ライオンFD出力サービスパーサー 
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
    ///       <description>2012/02/13</description>
    ///       <description>JSE H.Sasaki</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class FDLionParser
    {
        #region メソッド

        /// <summary>
        /// 媒体データパース結果を取得します。 
        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static FindFDLionByCondParseResult ParseForFindFDLionByCond(fdLionResult result)
        {
            FDDSLion dsfd = new FDDSLion();

            fdLionVO[] resultVOList = result.FDLion;

            if (resultVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsfd.FDLionResult.TableName, resultVOList) };

                FDDSLion dsData = DataSetConverter.Convert<FDDSLion>(defs);

                dsfd.FDLionResult.Merge(dsData.FDLionResult);
            }

            FindFDLionByCondParseResult parseResult = new FindFDLionByCondParseResult();

            parseResult.dsFDLion = dsfd;

            return parseResult;
        }

        #endregion
    }
}
