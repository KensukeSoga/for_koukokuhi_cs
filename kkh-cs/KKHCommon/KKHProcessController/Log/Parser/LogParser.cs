using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHSchema;

namespace Isid.KKH.Common.KKHProcessController.Log.Parser
{
    /// <summary>
    /// 登録サービスパーサー 
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
    ///       <description>2011/11/15</description>
    ///       <description>IP H.Shimizu</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class LogParser
    {
        #region メソッド
        /// <summary>
        /// 検索パース結果を取得します。 
        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static FindLogByCondParseResult ParseForFindLogByCond(logResult result)
        {
            KKHSchema.Log dsLog = new KKHSchema.Log();

            logVO[] logVOList = result.log;
            if (logVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsLog.LogData.TableName, logVOList) };
                KKHSchema.Log dsAddMaster = DataSetConverter.Convert<KKHSchema.Log>(defs);
                dsLog.LogData.Merge(dsAddMaster.LogData);
            }

            FindLogByCondParseResult parseResult = new FindLogByCondParseResult();
            parseResult.LogDataSet = dsLog;

            return parseResult;
        }

        #endregion
    }
}
