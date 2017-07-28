using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using System.Data;

namespace Isid.KKH.Common.KKHProcessController.MasterMaintenance.Parser
{

    /// <summary>
    /// 履歴サービスパーサー
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
    ///       <description>2011/02/03</description>
    ///       <description>HLC K.Honma</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class MasterMaintenanceParser
    {
        #region メソッド

        ///// <summary>
        ///// マスタ検索パース結果を取得します。 
        ///// </summary>
        ///// <param name="result">マスタ検索結果</param>
        ///// <returns>マスタ検索パース結果</returns>
        //internal static FindMasterMaintenanceByCondParseResult ParseForFindMasterMaintenanceByCond(masterResult result)
        //{
        //    Isid.KKH.Schema.MasterMaintenance dsMasterMaintenance = new Isid.KKH.Schema.MasterMaintenance();

        //    masterDataVO[] masterDataVOList = result.masterData;
        //    masterVO[] masterItemVOList = result.masterItem;
        //    masterVO[] masterKindVOList = result.masterKind;
        //    Isid.KKH.Schema.MasterMaintenance dsMasterStroage = new Isid.KKH.Schema.MasterMaintenance();
        //    if (masterKindVOList != null)
        //    {
        //        DataTableDef[] mstDatadefs = new DataTableDef[] { new DataTableDef(dsMasterMaintenance.MasterDataVO.TableName, masterDataVOList) };
        //        DataTableDef[] mstItemdefs = new DataTableDef[] { new DataTableDef(dsMasterMaintenance.MasterItemVO.TableName, masterItemVOList) };
        //        DataTableDef[] mstKinddefs = new DataTableDef[] { new DataTableDef(dsMasterMaintenance.MasterKindVO.TableName, masterKindVOList) };
        //        Isid.KKH.Schema.MasterMaintenance dsMaster = DataSetConverter.Convert<Isid.KKH.Schema.MasterMaintenance>(mstDatadefs);
        //        dsMasterStroage.MasterDataVO.Merge(dsMaster.MasterDataVO);
        //        dsMaster = DataSetConverter.Convert<Isid.KKH.Schema.MasterMaintenance>(mstItemdefs);
        //        dsMasterStroage.MasterItemVO.Merge(dsMaster.MasterItemVO);
        //        dsMaster = DataSetConverter.Convert<Isid.KKH.Schema.MasterMaintenance>(mstKinddefs);
        //        dsMasterStroage.MasterKindVO.Merge(dsMaster.MasterKindVO);
        //        int i = 0;
        //        int j = 0;
        //        int y = 0;
        //        string strMsSybt = string.Empty;
        //        string strDtSybt = string.Empty;
        //        string strDtId = string.Empty;
        //        foreach (DataRow drKind in dsMasterStroage.MasterKindVO.Rows)
        //        {
        //            foreach (DataRow drData in dsMasterStroage.MasterDataVO.Select("sybt = " + drKind["field2"].ToString()))
        //            {
        //                int x = 0;
        //                dsMasterStroage.MasterDataInput.AddMasterDataInputRow
        //                   (dsMasterStroage.MasterDataInput.NewMasterDataInputRow());
        //                dsMasterStroage.MasterDataInput[i].CodeNo = drKind["tksKgyCd"].ToString();
        //                dsMasterStroage.MasterDataInput[i].Classification = drKind["sybt"].ToString();
        //                dsMasterStroage.MasterDataInput[i].OldTableName = drKind["field1"].ToString();
        //                while (x < dsMasterStroage.MasterItemVO.Rows.Count)
        //                {
        //                    if (strDtId == dsMasterStroage.MasterItemVO[j]["field2"].ToString())
        //                    {
        //                        strDtId = string.Empty;
        //                        if (drKind["field3"].ToString() != strDtSybt)
        //                        {
        //                            strDtSybt = string.Empty;
        //                            y = y + x;
        //                        }
        //                        else
        //                        {
        //                            j = j - j + y;
        //                        }
        //                        break;
        //                    }
        //                    if (strDtSybt == string.Empty) strDtSybt = dsMasterStroage.MasterItemVO[j]["field1"].ToString();
        //                    if (strDtId == string.Empty) strDtId = dsMasterStroage.MasterItemVO[j]["field2"].ToString();
        //                        dsMasterStroage.MasterDataInput[i]["column" + int.Parse(dsMasterStroage.MasterItemVO[j]["field2"].ToString()).ToString()]
        //                                = drData[dsMasterStroage.MasterItemVO[j]["field4"].ToString().ToString()].ToString();
        //                        x = x + 1;
        //                    j = j + 1;
        //                }
        //                i = i + 1;
                     
        //            }
        //        }
        //    }

        //    FindMasterMaintenanceByCondParseResult parseResult = new FindMasterMaintenanceByCondParseResult();
        //    parseResult.MasterDataSet = dsMasterStroage;

        //    return parseResult;
        //}


        /// <summary>
        /// マスタ検索結果の置換 
        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ置換結果</returns>
        //internal static FindMasterMaintenanceForReplaceResult FindMasterMaintenanceForReplace(FindMasterByCondParseResult result)
        //{

        //        int i = 0;
        //        int j = 0;
        //        int y = 0;
        //        string strMsSybt = string.Empty;
        //        string strDtSybt = string.Empty;
        //        string strDtId = string.Empty;
        //        foreach (DataRow drKind in result.MasterDataSet.MasterKindVO.Rows)
        //        {
        //            foreach (DataRow drData in result.MasterDataSet.MasterDataVO.Select("sybt = " + drKind["field2"].ToString()))
        //            {
        //                int x = 0;
        //                result.MasterDataSet.MasterDataInput.AddMasterDataInputRow
        //                   (result.MasterDataSet.MasterDataInput.NewMasterDataInputRow());
        //                result.MasterDataSet.MasterDataInput[i].CodeNo = drKind["tksKgyCd"].ToString();
        //                result.MasterDataSet.MasterDataInput[i].Classification = drKind["sybt"].ToString();
        //                result.MasterDataSet.MasterDataInput[i].OldTableName = drKind["field1"].ToString();
        //                while (x < result.MasterDataSet.MasterItemVO.Rows.Count)
        //                {
        //                    if (strDtId == result.MasterDataSet.MasterItemVO[j]["field2"].ToString())
        //                    {
        //                        strDtId = string.Empty;
        //                        if (drKind["field3"].ToString() != strDtSybt)
        //                        {
        //                            strDtSybt = string.Empty;
        //                            y = y + x;
        //                        }
        //                        else
        //                        {
        //                            j = j - j + y;
        //                        }
        //                        break;
        //                    }
        //                    if (strDtSybt == string.Empty) strDtSybt = result.MasterDataSet.MasterItemVO[j]["field1"].ToString();
        //                    if (strDtId == string.Empty) strDtId = result.MasterDataSet.MasterItemVO[j]["field2"].ToString();
        //                    result.MasterDataSet.MasterDataInput[i]["column" + int.Parse(result.MasterDataSet.MasterItemVO[j]["field2"].ToString()).ToString()]
        //                            = drData[result.MasterDataSet.MasterItemVO[j]["field4"].ToString().ToString()].ToString();
        //                    x = x + 1;
        //                    j = j + 1;
        //                }
        //                i = i + 1;

        //            }
        //        }


        //        FindMasterMaintenanceForReplaceResult replaceResult = new FindMasterMaintenanceForReplaceResult();
        //    replaceResult.MasterDataSet = result.MasterDataSet;

        //    return replaceResult;
        //}

        //internal static FindMasterMaintenanceByCondParseResult ParseForFindMasterMaintenanceByCond(historySearchResult result)
        //{
        //    Isid.KKH.Schema.MasterMaintenance dsMasterMaintenance = new Isid.KKH.Schema.MasterMaintenance();
             
        //    historyVO[] historyVOList = result.historyVOList;
        //    if (historyVOList != null)
        //    {
        //        DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsMasterMaintenance.History.TableName, historyVOList) };
        //        Isid.KKH.Schema.MasterMaintenance dsMaster = DataSetConverter.Convert<Isid.KKH.Schema.MasterMaintenance>(defs);
        //        dsMasterMaintenance.History.Merge(dsMaster.History);
        //    }

        //    FindMasterMaintenanceByCondParseResult parseResult = new FindMasterMaintenanceByCondParseResult();
        //    parseResult.MasterDataSet = dsMasterMaintenance;

        //    return parseResult;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        internal static FindMasterByCondParseResult ParseForFindMasterDefineByCond(masterResult result)
        {
            Isid.KKH.Common.KKHSchema.MasterMaintenance dsMasterMaintenance = new Isid.KKH.Common.KKHSchema.MasterMaintenance();

            masterVO[] masterKindVOList = result.masterKind;
            if (masterKindVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsMasterMaintenance.MasterKindVO.TableName, masterKindVOList) };
                Isid.KKH.Common.KKHSchema.MasterMaintenance dsMaster = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.MasterMaintenance>(defs);
                dsMasterMaintenance.MasterKindVO.Merge(dsMaster.MasterKindVO);
            }

            masterVO[] masterItemVOList = result.masterItem;
            if (masterItemVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsMasterMaintenance.MasterItemVO.TableName, masterItemVOList) };
                Isid.KKH.Common.KKHSchema.MasterMaintenance dsMaster = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.MasterMaintenance>(defs);
                dsMasterMaintenance.MasterItemVO.Merge(dsMaster.MasterItemVO);
            }

            FindMasterByCondParseResult parseResult = new FindMasterByCondParseResult();
            parseResult.MasterDataSet = dsMasterMaintenance;

            return parseResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        internal static FindMasterByCondParseResult ParseForFindMasterItemByCond(masterItemResult result)
        {
            Isid.KKH.Common.KKHSchema.MasterMaintenance dsMasterMaintenance = new Isid.KKH.Common.KKHSchema.MasterMaintenance();

            masterVO[] masterItemVOList = result.masterItem;
            if (masterItemVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsMasterMaintenance.MasterItemVO.TableName, masterItemVOList) };
                Isid.KKH.Common.KKHSchema.MasterMaintenance dsMaster = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.MasterMaintenance>(defs);
                dsMasterMaintenance.MasterItemVO.Merge(dsMaster.MasterItemVO);
            }

            FindMasterByCondParseResult parseResult = new FindMasterByCondParseResult();
            parseResult.MasterDataSet = dsMasterMaintenance;

            return parseResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        internal static FindMasterByCondParseResult ParseForFindMasterByCond(masterResult result)
        {
            Isid.KKH.Common.KKHSchema.MasterMaintenance dsMasterMaintenance = new Isid.KKH.Common.KKHSchema.MasterMaintenance();

            masterDataVO[] masterDataVOList = result.masterData;
            if (masterDataVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsMasterMaintenance.MasterDataVO.TableName, masterDataVOList) };
                Isid.KKH.Common.KKHSchema.MasterMaintenance dsMaster = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.MasterMaintenance>(defs);
                dsMasterMaintenance.MasterDataVO.Merge(dsMaster.MasterDataVO);
            }

            FindMasterByCondParseResult parseResult = new FindMasterByCondParseResult();
            parseResult.MasterDataSet = dsMasterMaintenance;

            return parseResult;
        }

        #endregion メソッド
    }
}
