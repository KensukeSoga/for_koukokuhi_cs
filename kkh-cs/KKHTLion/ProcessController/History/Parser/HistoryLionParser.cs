using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Lion.Schema;
using Isid.KKH.Lion.ProcessController.History;
namespace Isid.KKH.Lion.ProcessController.History.Parser
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
    class HistoryLionParser
    {
        #region "メソッド"

        internal static FindHisLionByCondServiceResult ParseForFindHisJyutDown(historyJyutDownResult result)
        {
            HisDsLion dsLion = new HisDsLion();

            historyJyutDownVO[] hisLionVoList = result.reportAsh;
            if (hisLionVoList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsLion.jyutyuDownLoad.TableName, hisLionVoList) };
                HisDsLion dsAddHistory = DataSetConverter.Convert<HisDsLion>(defs);
                dsLion.jyutyuDownLoad.Merge(dsAddHistory.jyutyuDownLoad);
            }
            FindHisLionByCondServiceResult parseResult = new FindHisLionByCondServiceResult();
            parseResult.dsLionDataSet = dsLion;

            return parseResult;
        }

        #endregion "メソッド"
    }
}
