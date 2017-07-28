using System;

using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHServiceProxy;

namespace Isid.KKH.Uni.ProcessController.Report.Parser
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
    ///       <description>2012/1/24</description>
    ///       <description>JSE Y.Sato</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class ReportParser
    {
        /// <summary>
        /// 帳票（ユニチャーム_広告費明細表）データを取得。 
        /// </summary>
        /// <param name="result">帳票（ユニチャーム_広告費明細表）データの検索結果</param>
        /// <returns>帳票（ユニチャーム_広告費明細表）データの検索パース結果</returns>
        internal static FindReportUniByCondParseResult ParseForFindReportUniByCond(reportUniResult result)
        {
            Isid.KKH.Uni.Schema.RepDsUni dsUni = new Isid.KKH.Uni.Schema.RepDsUni();

            // 広告費明細表データ 
            reportUniResultVO[] report = result.meisai;
            if (report != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsUni.ReportData.TableName, report) };
                Isid.KKH.Uni.Schema.RepDsUni dsData = new Isid.KKH.Uni.Schema.RepDsUni();
                dsData = DataSetConverter.Convert<Isid.KKH.Uni.Schema.RepDsUni>(defs);
                dsUni.ReportData.Merge(dsData.ReportData);
            }

            // プルーフリスト用データ 
            reportUniResultVO[] proofs = result.proofs;
            if (proofs != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsUni.ProofData.TableName, proofs) };
                Isid.KKH.Uni.Schema.RepDsUni dsData = new Isid.KKH.Uni.Schema.RepDsUni();
                dsData = DataSetConverter.Convert<Isid.KKH.Uni.Schema.RepDsUni>(defs);
                dsUni.ProofData.Merge(dsData.ProofData);
            }

            FindReportUniByCondParseResult parseResult = new FindReportUniByCondParseResult();
            parseResult.ReportDataSet = dsUni;

            return parseResult;
        }
    }
}
