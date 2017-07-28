using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Lion.Schema;

namespace Isid.KKH.Lion.ProcessController.MastGet.Parser
{
    /// <summary>
    /// サービスパーサー 
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
    internal class FindLionMastParser
    {
        #region メソッド

        /// <summary>
        /// テレビ番組検索パース結果を取得します。 
        /// </summary>
        /// <param name="result">テレビ番組マスタ検索結果</param>
        /// <returns>テレビ番組マスタ検索パース結果</returns>
        internal static FindLionMastParseResult ParseForFindReportMacByCond(findTvMastResult result)
        {
            MastLion dsrep = new MastLion();

            findTvMastVO[] FindTvMastVOList = result.findTvMast;
            if (FindTvMastVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.TvBnLion.TableName, FindTvMastVOList) };
                MastLion dsAddMaster = DataSetConverter.Convert<MastLion>(defs);
                dsrep.TvBnLion.Merge(dsAddMaster.TvBnLion);
            }

            FindLionMastParseResult parseResult = new FindLionMastParseResult();
            parseResult.MastLionDataSet = dsrep;

            return parseResult;
        }

        /// <summary>
        /// ラジオ番組検索パース結果を取得します。 
        /// </summary>
        /// <param name="result">ラジオ番組マスタ検索結果</param>
        /// <returns>ラジオ番組マスタ検索パース結果</returns>
        internal static FindLionMastParseResult ParseForFindReportRdMacByCond(findRdMastResult result)
        {
            MastLion dsrep = new MastLion();

            findRdMastVO[] FindRdMastVOList = result.findRdMast;
            if (FindRdMastVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.RdBnLion.TableName, FindRdMastVOList) };
                MastLion dsAddMaster = DataSetConverter.Convert<MastLion>(defs);
                dsrep.RdBnLion.Merge(dsAddMaster.RdBnLion);
            }

            FindLionMastParseResult parseResult = new FindLionMastParseResult();
            parseResult.MastLionDataSet = dsrep;

            return parseResult;
        }

        /// <summary>
        /// テレビ局検索パース結果を取得します。 
        /// </summary>
        /// <param name="result">テレビ局マスタ検索結果</param>
        /// <returns>テレビ局マスタ検索パース結果</returns>
        internal static FindLionMastParseResult ParseForFindReportTvKMacByCond(findTvKMastResult result)
        {
            MastLion dsrep = new MastLion();

            findTvKMastVO[] FindTvKMastVOList = result.findTvKMast;
            if (FindTvKMastVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.TvKLion.TableName, FindTvKMastVOList) };
                MastLion dsAddMaster = DataSetConverter.Convert<MastLion>(defs);
                dsrep.TvKLion.Merge(dsAddMaster.TvKLion);
            }

            FindLionMastParseResult parseResult = new FindLionMastParseResult();
            parseResult.MastLionDataSet = dsrep;

            return parseResult;
        }

        /// <summary>
        /// ラジオ局検索パース結果を取得します。 
        /// </summary>
        /// <param name="result">ラジオ局マスタ検索結果</param>
        /// <returns>ラジオ局マスタ検索パース結果</returns>
        internal static FindLionMastParseResult ParseForFindReportRdKMacByCond(findRdKMastResult result)
        {
            MastLion dsrep = new MastLion();

            findRdKMastVO[] FindRdKMastVOList = result.findRdKMast;
            if (FindRdKMastVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsrep.RdKLion.TableName, FindRdKMastVOList) };
                MastLion dsAddMaster = DataSetConverter.Convert<MastLion>(defs);
                dsrep.RdKLion.Merge(dsAddMaster.RdKLion);
            }

            FindLionMastParseResult parseResult = new FindLionMastParseResult();
            parseResult.MastLionDataSet = dsrep;

            return parseResult;
        }


        internal static FindLionMastParseResult ParseForFindMasterByCond(masterResult result)
        {
            //Isid.KKH.Common.KKHSchema.MasterMaintenance dsMasterMaintenance = new Isid.KKH.Common.KKHSchema.MasterMaintenance();
            Isid.KKH.Lion.Schema.MastLion mastLion = new Isid.KKH.Lion.Schema.MastLion();


            masterDataVO[] masterDataVOList = result.masterData;
            if (masterDataVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(mastLion.BrandLion.TableName, masterDataVOList) };
                Isid.KKH.Lion.Schema.MastLion dsMaster = DataSetConverter.Convert<Isid.KKH.Lion.Schema.MastLion>(defs);
                mastLion.BrandLion.Merge(dsMaster.BrandLion);
            }

            FindLionMastParseResult parseResult = new FindLionMastParseResult();
            parseResult.MastLionDataSet = mastLion;

            return parseResult;
        }

        #endregion
    }
}
