using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Mac.Schema;

namespace Isid.KKH.Mac.ProcessController.Report.Parser
{
    /// <summary>
    /// レポート（Mac)サービスパーサー
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
    internal class ReportMacParser
    {
        #region メソッド
        /// <summary>
        /// 検索パース結果を取得します。        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static FindReportMacByCondParseResult ParseForFindReportMacByCond(reportMacResult result)
        {
            RepDsMac dsrep = new RepDsMac();

            reportMacVO[] reportMacVOList = result.reportMac;
            if (reportMacVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.Repmac.TableName, reportMacVOList) };
                RepDsMac dsAddMaster = DataSetConverter.Convert<RepDsMac>(defs);
                dsrep.Repmac.Merge(dsAddMaster.Repmac);
            }

            FindReportMacByCondParseResult parseResult = new FindReportMacByCondParseResult();
            parseResult.ReoMacDataSet = dsrep;

            return parseResult;
        }

        /// <summary>
        /// ライセンシー向け帳票データの検索用パース
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        internal static FindReportMacPurchaseByCondParseResult ParseForFindReportMacLicenseeByCond(reportMacLicenseeResult result)
        {
            RepDsMac dsrep = new RepDsMac();

            //reportMacPurchaseVO[] reportMacVOList = result.reportMacPurchase;
            reportMacLicenseeVO[] reportMacVOList = result.reportMac;
            if (reportMacVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.RepLicensee.TableName, reportMacVOList) };
                RepDsMac dsAddMaster = DataSetConverter.Convert<RepDsMac>(defs);
                dsrep.RepLicensee.Merge(dsAddMaster.RepLicensee);
            }

            FindReportMacPurchaseByCondParseResult parseResult = new FindReportMacPurchaseByCondParseResult();
            parseResult.ReoMacDataSet = dsrep;

            return parseResult;
        }

        /// <summary>
        /// 検索パース結果を取得します。
        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static FindReportMacPurchaseByCondParseResult ParseForFindReportMacPurchaseByCond(reportMacPurchaseResult result)
        {
            RepDsMac dsrep = new RepDsMac();

            reportMacPurchaseVO[] reportMacVOList = result.reportMacPurchase;
            if (reportMacVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.RepmacPurchase.TableName, reportMacVOList) };
                RepDsMac dsAddMaster = DataSetConverter.Convert<RepDsMac>(defs);
                dsrep.RepmacPurchase.Merge(dsAddMaster.RepmacPurchase);
            }

            FindReportMacPurchaseByCondParseResult parseResult = new FindReportMacPurchaseByCondParseResult();
            parseResult.ReoMacDataSet = dsrep;

            return parseResult;
        }

        /// <summary>
        /// 検索パース結果を取得します。
        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static FindReportMacGetDenNumByCondParseResult ParseForFindReportMacGetDenNumByCond(reportMacGetDenNumResult result)
        {
            RepDsMac dsrep = new RepDsMac();

            reportMacGetDenNumVO[] reportMacVOList = result.reportMacGetDenNum;
            if (reportMacVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.RepmacGetDenNum.TableName, reportMacVOList) };
                RepDsMac dsAddMaster = DataSetConverter.Convert<RepDsMac>(defs);
                dsrep.RepmacGetDenNum.Merge(dsAddMaster.RepmacGetDenNum);
            }

            FindReportMacGetDenNumByCondParseResult parseResult = new FindReportMacGetDenNumByCondParseResult();
            parseResult.ReoMacDataSet = dsrep;

            return parseResult;
        }

        /// <summary>
        /// 検索パース結果を取得します。
        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static FindReportMacRequestByCondParseResult ParseForFindReportMacRequestByCond(reportMacRequestResult result)
        {
            RepDsMac dsrep = new RepDsMac();

            reportMacRequestVO[] reportMacVOList = result.reportMacRequest;
            if (reportMacVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.RepmacRequest.TableName, reportMacVOList) };
                RepDsMac dsAddMaster = DataSetConverter.Convert<RepDsMac>(defs);
                dsrep.RepmacRequest.Merge(dsAddMaster.RepmacRequest);
            }

            FindReportMacRequestByCondParseResult parseResult = new FindReportMacRequestByCondParseResult();
            parseResult.ReoMacDataSet = dsrep;

            return parseResult;
        }

        #endregion
    }
}
