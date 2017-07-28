using System;
using Isid.KKH.Mac.Schema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using System.Data;

namespace Isid.KKH.Mac.ProcessController.MasterMaintenance.Parser
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

        /// <summary>
        /// マスタ検索パース結果を取得します。 
        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static String[] ParseForFindUpdMstKeyByCond(findMasterMacTnpRKeyByCondResult result)
        {
            int count = 0;
            String[] parseResult = new String[0];

            if (result._thb17RmtnpList != null)
            {
                parseResult = new String[result._thb17RmtnpList.Length];

                foreach (findMasterMacTnpRKeyByCondVO list in result._thb17RmtnpList)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(list.updRrkTimstmp);
                    sb.Append(list.torikomiFlg);
                    parseResult[count] = sb.ToString(); 
                    count++;
                }
            }

            return parseResult;

        }
        
        /// <summary>
        /// マスタ検索パース結果を取得します。 
        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static FindMasterTenpoRirekiByCondServiceResult ParseForFindMasterByCond(findMasterMacTnpRByCondResult result)
        {
            Isid.KKH.Mac.Schema.MastDSMac dsMasterMaintenance = new Isid.KKH.Mac.Schema.MastDSMac();

            findMasterMacTnpRByCondVO[] masterDataVOList = result._thb17RmtnpList;
            if (masterDataVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsMasterMaintenance.TenpoRrk.TableName, masterDataVOList) };
                Isid.KKH.Mac.Schema.MastDSMac dsMaster = DataSetConverter.Convert<Isid.KKH.Mac.Schema.MastDSMac>(defs);
                dsMasterMaintenance.TenpoRrk.Merge(dsMaster.TenpoRrk);
            }

            FindMasterTenpoRirekiByCondServiceResult parseResult = new FindMasterTenpoRirekiByCondServiceResult();
            parseResult.TenpoRrkMasterDataSet = dsMasterMaintenance;

            return parseResult;

        }

        #endregion メソッド
    }
}
