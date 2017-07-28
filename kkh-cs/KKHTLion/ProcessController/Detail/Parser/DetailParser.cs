using System.Data;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Common.KKHProcessController.Detail;

namespace Isid.KKH.Lion.ProcessController.Detail.Parser
{
    /// <summary>
    /// 件名変更サービスパーサー 
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
    ///       <description>2012/02/09</description>
    ///       <description>JSE A.Naito</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class DetailLionCardNoGetParser
    {
        #region "メソッド"

        internal static UpdateSubjectDataServiceResult ParseForupdateSubjectData(updateSubjectResult result)
        {
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

            thb1DownVO[] thb1DownVOList = result._thb1DownList;
            if (thb1DownVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetail.THB1DOWN.TableName, thb1DownVOList) };
                Isid.KKH.Common.KKHSchema.Detail dsData = new Isid.KKH.Common.KKHSchema.Detail();
                dsData = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.Detail>(defs);
                dsDetail.THB1DOWN.Merge(dsData.THB1DOWN);
            }
        
            UpdateSubjectDataServiceResult parseResult = new UpdateSubjectDataServiceResult();
            return parseResult;
        }
        #endregion "メソッド"
    }
}
