using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHProcessController.History;
namespace Isid.KKH.Common.KKHProcessController.History.Parser
{
    /// <summary>
    /// 履歴（Lion)サービスパーサー 
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
    ///       <description>2012/2/1</description>
    ///       <description>Fourm H.Izawa</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
   public class HistoryParser
    {
        #region "メソッド"

        internal static FindHisByCondServiceResult ParseForFindHisJyutDown(historyJyutDownResult result)
        {
            HisDs ds = new HisDs();

            historyJyutDownVO[] hisVoList = result.reportAsh;
            if (hisVoList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(ds.jyutyuDownLoad.TableName, hisVoList) };
                HisDs dsAddHistory = DataSetConverter.Convert<HisDs>(defs);
                ds.jyutyuDownLoad.Merge(dsAddHistory.jyutyuDownLoad);
            }
            FindHisByCondServiceResult parseResult = new FindHisByCondServiceResult();
            parseResult.dsDataSet = ds;

            return parseResult;
        }

        #endregion "メソッド"
    }
}
