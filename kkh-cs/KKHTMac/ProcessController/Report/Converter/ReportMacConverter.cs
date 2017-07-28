using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Mac.Schema;



namespace Isid.KKH.Common.KKHProcessController.Report.Converter
{
    /// <summary>
    /// レポートデータコンバーター
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
    ///       <description>2012/01/18</description>
    ///       <description>IP H.Shimizu</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class ReportMacConverter 
    {
        /// <summary>
        /// 購入伝票更新時
        /// </summary>
        /// <param name="datatbvo"></param>
        /// <returns></returns>
        internal static updateReportMacPurVO[] ConvertForPurchaseUpd(RepDsMac.RepmacUpdPurchaseDataTable datatbvo)
        {
            List<updateReportMacPurVO> listTemp = new List<updateReportMacPurVO>();
            updateReportMacPurVO vo;
  

            foreach (DataRow row in datatbvo.Rows)
            {
                vo = VoConverter.Convert<updateReportMacPurVO>(datatbvo.DataSet, new RowToVoDef(row, null));
                listTemp.Add(vo);
            }



            updateReportMacPurVO[] result = listTemp.ToArray();
            return result;


        }

        /// <summary>
        /// 請求書更新時
        /// </summary>
        /// <param name="datatbvo"></param>
        /// <returns></returns>
        internal static updateReportMacReqVO[] ConvertForRequestUpd(RepDsMac.RepmacUpdRequestDataTable datatbvo)
        {
            List<updateReportMacReqVO> listTemp = new List<updateReportMacReqVO>();
            updateReportMacReqVO vo;

            foreach (DataRow row in datatbvo.Rows)
            {
                vo = VoConverter.Convert<updateReportMacReqVO>(datatbvo.DataSet, new RowToVoDef(row, null));
                listTemp.Add(vo);
            }



            updateReportMacReqVO[] result = listTemp.ToArray();
            return result;


        }

    }
}
