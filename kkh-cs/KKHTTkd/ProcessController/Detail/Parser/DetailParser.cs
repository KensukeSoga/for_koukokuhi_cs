using System.Data;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Common.KKHProcessController.Detail;

namespace Isid.KKH.Tkd.ProcessController.Detail.Parser
{
    /// <summary>
    /// 広告費明細入力サービスパーサー 
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
    ///       <description>2012/01/05</description>
    ///       <description>JSE Y.Sato</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class DetailParser
    {
        #region メソッド

        /// <summary>
        /// 受注明細のデータを取得。 
        /// </summary>
        /// <param name="result">受注明細の検索結果</param>
        /// <returns>受注明細の検索パース結果</returns>
        internal static FindJyutyuDataByCondServiceResult ParseForFindThb2KmeiDataByCond(findThb2KmeiBycondResult result)
        {
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

            thb2KmeiVO[] jyutyuDataVOList = result._thb2KmeiList;
            if (jyutyuDataVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetail.THB2KMEI.TableName, jyutyuDataVOList) };
                Isid.KKH.Common.KKHSchema.Detail dsData = new Isid.KKH.Common.KKHSchema.Detail();
                dsData = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.Detail>(defs);
                dsDetail.THB2KMEI.Merge(dsData.THB2KMEI);
            }

            FindJyutyuDataByCondServiceResult parseResult = new FindJyutyuDataByCondServiceResult();
            parseResult.DetailDataSet = dsDetail;

            return parseResult;
        }
      
        #endregion メソッド
    }
}
