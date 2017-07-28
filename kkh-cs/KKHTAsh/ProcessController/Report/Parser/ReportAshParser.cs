using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Ash.Schema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
namespace Isid.KKH.Ash.ProcessController.Report.Parser
{
    /// <summary>
    /// レポート（Ash)サービスパーサー 
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
    ///       <description>2012/1/20</description>
    ///       <description>Fourm H.Izawa</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class ReportAshParser
    {
        #region メソッド
        internal static FindReportAshMediaByCondServiceResult ParseForFindReportAshMediaByCond(reportAshMediaResult result)
        {
            RepDsAsh dsrep = new RepDsAsh();

            reportAshMediaVO[] reportAshVOList = result.reportAsh;
            if (reportAshVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.RepAshMedia.TableName, reportAshVOList) };
                RepDsAsh dsAddReport = DataSetConverter.Convert<RepDsAsh>(defs);
                dsrep.RepAshMedia.Merge(dsAddReport.RepAshMedia);
            }
            
            //消費税対応 2013/11/26 HLC H.Watabe add start
            reportAshMediaVO[] reportAshALLVOList = result.reportAshALL;
            if (reportAshVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.RepAshMediaTemp.TableName, reportAshALLVOList) };
                RepDsAsh dsAddReport = DataSetConverter.Convert<RepDsAsh>(defs);
                dsrep.RepAshMediaTemp.Merge(dsAddReport.RepAshMediaTemp);
            }
            //消費税対応 2013/11/26 HLC H.Watabe add end
          
            FindReportAshMediaByCondServiceResult parseResult = new FindReportAshMediaByCondServiceResult();
            parseResult.dsAshDataSet = dsrep;

            return parseResult;
        }


        internal static FindReportAshMediaByCondServiceResult ParseForFindReportAshMediaCodeByCond(reportAshMediaCodeResult result)
        {
            RepDsAsh dsrep = new RepDsAsh();

            reportAshMediaCodeVO[] reportAshVOList = result.reportAshCode;
            if (reportAshVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.BaiCd.TableName, reportAshVOList) };
                RepDsAsh dsAddReport = DataSetConverter.Convert<RepDsAsh>(defs);
                dsrep.BaiCd.Merge(dsAddReport.BaiCd);
            }

            reportAshMediaCodeVO[] SyohinVOList = result.syohinCode;
            if (SyohinVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.Syohin.TableName, SyohinVOList) };
                RepDsAsh dsAddReport = DataSetConverter.Convert<RepDsAsh>(defs);
                dsrep.Syohin.Merge(dsAddReport.Syohin);
            }

            reportAshOldKyokuVO[] OldKyokuVoList = result.reportAshOldKyoku;
            if (OldKyokuVoList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.OldKyokuCd.TableName, OldKyokuVoList) };
                RepDsAsh dsAddReport = DataSetConverter.Convert<RepDsAsh>(defs);
                dsrep.OldKyokuCd.Merge(dsAddReport.OldKyokuCd);
            }

            reportAshBangumiDataVO[] BangumiVoList = result.reportAshBangumiData;
            if (BangumiVoList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.BangumiData.TableName, BangumiVoList) };
                RepDsAsh dsAddReport = DataSetConverter.Convert<RepDsAsh>(defs);
                dsrep.BangumiData.Merge(dsAddReport.BangumiData);
            }

            

            FindReportAshMediaByCondServiceResult parseResult = new FindReportAshMediaByCondServiceResult();
            parseResult.dsAshDataSet = dsrep;

            return parseResult;
        }

        internal static FindReportAshMediaByCondServiceResult ParseForFindReportAshMediaChklstByCond(reportAshMediaChklstResult result)
        {
            RepDsAsh dsrep = new RepDsAsh();

            reportAshMediaChklstVO[] reportAshVOList = result.reportAshChklst;
            if (reportAshVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.RepAshMediaChklst.TableName, reportAshVOList) };
                RepDsAsh dsAddReport = DataSetConverter.Convert<RepDsAsh>(defs);
                dsrep.RepAshMediaChklst.Merge(dsAddReport.RepAshMediaChklst);
            }


            FindReportAshMediaByCondServiceResult parseResult = new FindReportAshMediaByCondServiceResult();
            parseResult.dsAshDataSet = dsrep;

            return parseResult;
        }

        internal static FindReportAshMediaByCondServiceResult ParseForFindReportAshKoukokuHiByCond(reportAshKoukokuHiResult result)
        {
            RepDsAsh dsrep = new RepDsAsh();

            reportAshKoukokuHiVO[] reportAshVOList = result.reportAsh;
            if (reportAshVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.RepAshKoukokuHi.TableName, reportAshVOList) };
                RepDsAsh dsAddReport = DataSetConverter.Convert<RepDsAsh>(defs);
                dsrep.RepAshKoukokuHi.Merge(dsAddReport.RepAshKoukokuHi);
            }
            reportAshTvAndRadioKingakVO[] TimeVoList = result.reportAshTvAndRadio;
            if (TimeVoList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.TvRadioTimeKingak.TableName, TimeVoList) };
                RepDsAsh dsAddReport = DataSetConverter.Convert<RepDsAsh>(defs);
                dsrep.TvRadioTimeKingak.Merge(dsAddReport.TvRadioTimeKingak);
            }

            FindReportAshMediaByCondServiceResult parseResult = new FindReportAshMediaByCondServiceResult();
            parseResult.dsAshDataSet = dsrep;

            return parseResult;
        }

        internal static FindReportAshMediaByCondServiceResult ParseForFindFDByCond(fdAshResult result)
        {
            RepDsAsh dsrep = new RepDsAsh();

            fdAshVO[] FDAshVOList = result.FDAsh;
            if (FDAshVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.FDAsh.TableName, FDAshVOList) };
                RepDsAsh dsAddReport = DataSetConverter.Convert<RepDsAsh>(defs);
                dsrep.FDAsh.Merge(dsAddReport.FDAsh);
            }

            FindReportAshMediaByCondServiceResult parseResult = new FindReportAshMediaByCondServiceResult();
            parseResult.dsAshDataSet = dsrep;

            return parseResult;
        }


        #endregion メソッド
    }
}
