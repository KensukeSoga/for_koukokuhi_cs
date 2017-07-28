using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;

namespace Isid.KKH.Lion.ProcessController.Report.Parser
{
    /// <summary>
    /// 明細一覧帳票（Lion)サービスパーサー.
    /// </summary>
    /// <remarks>
    ///   修正管理.
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付.</description>
    ///       <description>修正者.</description>
    ///       <description>内容.</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2013/02/01.</description>
    ///       <description>作成者.</description>
    ///       <description>新規作成.</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class DetailListLionParser
    {
        #region メソッド
        /// <summary>
        /// 検索パース結果を取得します.
        /// </summary>
        /// <param name="result">マスタ検索結果.</param>
        /// <returns>マスタ検索パース結果.</returns>
        internal static FindDetailListLionByCondParseResult ParseForFindDetailListLionByCond(detailListLionResult result)
        {
            Isid.KKH.Lion.Schema.RepDsLion dsDetailList = new Isid.KKH.Lion.Schema.RepDsLion();

            detailListLionVO[] detailListLionVOList = result.detailListLion;
            if (detailListLionVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetailList.DetailListLion.TableName, detailListLionVOList) };
                Isid.KKH.Lion.Schema.RepDsLion dsAddMaster = DataSetConverter.Convert<Isid.KKH.Lion.Schema.RepDsLion>(defs);
                dsDetailList.DetailListLion.Merge(dsAddMaster.DetailListLion);
            }

            detailListLionVO[] detailListLionSyohiZeiVOList = result.detailListLionSyohiZei;
            if (detailListLionSyohiZeiVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetailList.RepLionSyohiZei.TableName, detailListLionSyohiZeiVOList) };
                Isid.KKH.Lion.Schema.RepDsLion dsAddMaster = DataSetConverter.Convert<Isid.KKH.Lion.Schema.RepDsLion>(defs);
                dsDetailList.RepLionSyohiZei.Merge(dsAddMaster.RepLionSyohiZei);
            }
            detailListLionVO[] detailListLionBaitaiVOList = result.baitaiCdName;
            if (detailListLionBaitaiVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetailList.BaitaiCdName.TableName, detailListLionBaitaiVOList) };
                Isid.KKH.Lion.Schema.RepDsLion dsAddMaster = DataSetConverter.Convert<Isid.KKH.Lion.Schema.RepDsLion>(defs);
                dsDetailList.BaitaiCdName.Merge(dsAddMaster.BaitaiCdName);
            }

            FindDetailListLionByCondParseResult parseResult = new FindDetailListLionByCondParseResult();
            parseResult.DetailListLionDataSet = dsDetailList;

            return parseResult;
        }

        #endregion

    }
}
