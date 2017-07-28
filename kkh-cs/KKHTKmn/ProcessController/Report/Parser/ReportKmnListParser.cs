using System;

using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHServiceProxy;

namespace Isid.KKH.Kmn.ProcessController.Report.Parser
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
    ///       <description>2013/1/31</description>
    ///       <description>JSE A.Naito</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class ReportParser
    {
        /// <summary>
        /// 帳票（公文_請求一覧）データを取得。 
        /// </summary>
        /// <param name="result">帳票（公文_請求一覧）データの検索結果</param>
        /// <returns>帳票（公文_請求一覧）データの検索パース結果</returns>
        internal static FindReportKmnListByCondParseResult ParseForFindReportKmnListByCond(reportKmnListResult result)
        {
            Isid.KKH.Kmn.Schema.RepDSKmn dsKmn = new Isid.KKH.Kmn.Schema.RepDSKmn();

            // 請求一覧用明細データ 
            reportKmnListVO[] report = result.rptList;
            if (report != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsKmn.RepKmnList.TableName, report) };
                Isid.KKH.Kmn.Schema.RepDSKmn dsData = new Isid.KKH.Kmn.Schema.RepDSKmn();
                dsData = DataSetConverter.Convert<Isid.KKH.Kmn.Schema.RepDSKmn>(defs);
                dsKmn.RepKmnList.Merge(dsData.RepKmnList);
            }

            FindReportKmnListByCondParseResult parseResult = new FindReportKmnListByCondParseResult();
            parseResult.ReportDataSet = dsKmn;

            return parseResult;
        }

        /// <summary>
        /// シークエンスNo最大値を取得。 
        /// </summary>
        /// <param name="result">帳票（公文_請求一覧）データの検索結果</param>
        /// <returns>帳票（公文_請求一覧）データの検索パース結果</returns>
        internal static FindReportKmnListByCondParseResult ParseForGetMaxSeqNoByCond(maxSeqNoResult result)
        {
            Isid.KKH.Kmn.Schema.RepDSKmn dsKmn = new Isid.KKH.Kmn.Schema.RepDSKmn();

            // 請求一覧用明細データ 
            maxSeqNoVO[] report = result.maxSeqNo;
            if (report != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsKmn.MaxSeqNo.TableName, report) };
                Isid.KKH.Kmn.Schema.RepDSKmn dsData = new Isid.KKH.Kmn.Schema.RepDSKmn();
                dsData = DataSetConverter.Convert<Isid.KKH.Kmn.Schema.RepDSKmn>(defs);
                dsKmn.MaxSeqNo.Merge(dsData.MaxSeqNo);
            }

            FindReportKmnListByCondParseResult parseResult = new FindReportKmnListByCondParseResult();
            parseResult.ReportDataSet = dsKmn;

            return parseResult;
        }
    }
}
