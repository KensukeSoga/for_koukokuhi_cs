using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;

namespace Isid.KKH.Lion.ProcessController.Report.Parser
{
    /// <summary>
    /// 得意先ライオン制作室リスト・追加変更リストサービスパーサー.
    /// </summary>
    /// <remarks>
    ///   修正管理.
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2014/07/31</description>
    ///       <description>HLC S.Fujimoto</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class AddChangeReportParser
    {
        #region メソッド.

        /// <summary>
        /// 制作室リスト検索パース結果を取得します.
        /// </summary>
        /// <param name="result">制作室リストデータ検索結果</param>
        /// <param name="type">検索種別</param>
        /// <returns>制作室リスト検索パース結果</returns>
        internal static FindAddChangeReportByCondParserResult ParseForFindAddChangeReportSeisakuByCond(addChangeReportLionSeisakuResult result, String type)
        {
            Isid.KKH.Lion.Schema.AddChgDsLion dsAddChgList = new Isid.KKH.Lion.Schema.AddChgDsLion();

            //履歴タイムスタンプ.
            if (type.Equals(Isid.KKH.Lion.View.Report.ReportAddChangeLion.RRKTIMSTMP))
            {
                addChangeReportLionSeisakuVO[] addChangeReportVOList = result.rrkTimStmpInfo;
                if (addChangeReportVOList != null)
                {
                    DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsAddChgList.RrkTimStmp.TableName, addChangeReportVOList) };
                    Isid.KKH.Lion.Schema.AddChgDsLion dsAddChg = DataSetConverter.Convert<Isid.KKH.Lion.Schema.AddChgDsLion>(defs);
                    dsAddChgList.RrkTimStmp.Merge(dsAddChg.RrkTimStmp);
                }
            }
            //制作室リスト(AD1).
            else if (type.Equals(Isid.KKH.Lion.View.Report.ReportAddChangeLion.SEISAKUAD1))
            {
                addChangeReportLionSeisakuVO[] addChangeReportVOList = result.seisakuAD1Info;
                if (addChangeReportVOList != null)
                {
                    DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsAddChgList.SeisakuAD1.TableName, addChangeReportVOList) };
                    Isid.KKH.Lion.Schema.AddChgDsLion dsAddChg = DataSetConverter.Convert<Isid.KKH.Lion.Schema.AddChgDsLion>(defs);
                    dsAddChgList.SeisakuAD1.Merge(dsAddChg.SeisakuAD1);
                }
            }
            //制作室リスト(AD2).
            else if (type.Equals(Isid.KKH.Lion.View.Report.ReportAddChangeLion.SEISAKUAD2))
            {
                //AD1
                addChangeReportLionSeisakuVO[] addChangeReportAD1VOList = result.seisakuAD1Info;
                if (addChangeReportAD1VOList != null)
                {
                    DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsAddChgList.SeisakuAD1.TableName, addChangeReportAD1VOList) };
                    Isid.KKH.Lion.Schema.AddChgDsLion dsAddChg = DataSetConverter.Convert<Isid.KKH.Lion.Schema.AddChgDsLion>(defs);
                    dsAddChgList.SeisakuAD1.Merge(dsAddChg.SeisakuAD1);
                }
                //AD2
                addChangeReportLionSeisakuVO[] addChangeReportAD2VOList = result.seisakuAD2Info;
                if (addChangeReportAD2VOList != null)
                {
                    DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsAddChgList.SeisakuAD2.TableName, addChangeReportAD2VOList) };
                    Isid.KKH.Lion.Schema.AddChgDsLion dsAddChg = DataSetConverter.Convert<Isid.KKH.Lion.Schema.AddChgDsLion>(defs);
                    dsAddChgList.SeisakuAD2.Merge(dsAddChg.SeisakuAD2);
                }
                //差分.
                addChangeReportLionSeisakuVO[] addChangeReportDiffVOList = result.seisakuDiffInfo;
                if (addChangeReportDiffVOList != null)
                {
                    DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsAddChgList.SeisakuDiff.TableName, addChangeReportDiffVOList) };
                    Isid.KKH.Lion.Schema.AddChgDsLion dsAddChg = DataSetConverter.Convert<Isid.KKH.Lion.Schema.AddChgDsLion>(defs);
                    dsAddChgList.SeisakuDiff.Merge(dsAddChg.SeisakuDiff);
                }
            }

            FindAddChangeReportByCondParserResult parseResult = new FindAddChangeReportByCondParserResult();
            parseResult.AddChgLionDataSet = dsAddChgList;

            return parseResult;
        }

        /// <summary>
        /// 追加変更リスト検索パース結果を取得します.
        /// </summary>
        /// <param name="result">追加変更リストデータ検索結果</param>
        /// <param name="type">検索種別</param>
        /// <returns>追加変更リスト検索パース結果</returns>
        internal static FindAddChangeReportByCondParserResult ParseForFindAddChangeReportBaitaiByCond(addChangeReportLionBaitaiResult result, String type)
        {
            Isid.KKH.Lion.Schema.AddChgDsLion dsAddChgList = new Isid.KKH.Lion.Schema.AddChgDsLion();

            //履歴タイムスタンプ.
            if (type.Equals(Isid.KKH.Lion.View.Report.ReportAddChangeLion.RRKTIMSTMP))
            {
                addChangeReportLionBaitaiVO[] addChangeReportVOList = result.rrkTimStmpInfo;
                if (addChangeReportVOList != null)
                {
                    DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsAddChgList.RrkTimStmp.TableName, addChangeReportVOList) };
                    Isid.KKH.Lion.Schema.AddChgDsLion dsAddChg = DataSetConverter.Convert<Isid.KKH.Lion.Schema.AddChgDsLion>(defs);
                    dsAddChgList.RrkTimStmp.Merge(dsAddChg.RrkTimStmp);
                }
            }
            //追加変更リスト.
            else if (type.Equals(Isid.KKH.Lion.View.Report.ReportAddChangeLion.BAITAI))
            {
                //AD1
                addChangeReportLionBaitaiVO[] addChangeReportAD1VOList = result.baitaiAD1Info;
                if (addChangeReportAD1VOList != null)
                {
                    DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsAddChgList.BaitaiAD1.TableName, addChangeReportAD1VOList) };
                    Isid.KKH.Lion.Schema.AddChgDsLion dsAddChg = DataSetConverter.Convert<Isid.KKH.Lion.Schema.AddChgDsLion>(defs);
                    dsAddChgList.BaitaiAD1.Merge(dsAddChg.BaitaiAD1);
                }
                //AD2
                addChangeReportLionBaitaiVO[] addChangeReportAD2VOList = result.baitaiAD2Info;
                if (addChangeReportAD2VOList != null)
                {
                    DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsAddChgList.BaitaiAD2.TableName, addChangeReportAD2VOList) };
                    Isid.KKH.Lion.Schema.AddChgDsLion dsAddChg = DataSetConverter.Convert<Isid.KKH.Lion.Schema.AddChgDsLion>(defs);
                    dsAddChgList.BaitaiAD2.Merge(dsAddChg.BaitaiAD2);
                }
                //差分(内部資料).
                addChangeReportLionBaitaiVO[] addChangeReportDiffVOList = result.baitaiDiffInfoInternal;
                if (addChangeReportDiffVOList != null)
                {
                    DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsAddChgList.BaitaiDiff.TableName, addChangeReportDiffVOList) };
                    Isid.KKH.Lion.Schema.AddChgDsLion dsAddChg = DataSetConverter.Convert<Isid.KKH.Lion.Schema.AddChgDsLion>(defs);
                    dsAddChgList.BaitaiDiff.Merge(dsAddChg.BaitaiDiff);
                }
                //差分.
                addChangeReportLionBaitaiVO[] addChangeReportDiffExternalVOList = result.baitaiDiffInfoExternal;
                if (addChangeReportDiffExternalVOList != null)
                {
                    DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsAddChgList.BaitaiDiffExternal.TableName, addChangeReportDiffExternalVOList) };
                    Isid.KKH.Lion.Schema.AddChgDsLion dsAddChg = DataSetConverter.Convert<Isid.KKH.Lion.Schema.AddChgDsLion>(defs);
                    dsAddChgList.BaitaiDiffExternal.Merge(dsAddChg.BaitaiDiffExternal);
                }
            }

            FindAddChangeReportByCondParserResult parseResult = new FindAddChangeReportByCondParserResult();
            parseResult.AddChgLionDataSet = dsAddChgList;

            return parseResult;
        }

        #endregion
    }
}
