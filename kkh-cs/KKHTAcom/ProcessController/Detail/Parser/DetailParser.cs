using System;

using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHServiceProxy;

namespace Isid.KKH.Acom.ProcessController.Detail.Parser
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
    ///       <description></description>
    ///       <description></description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class DetailParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        internal static FindHatyuNumServiceResult ParseForFindHatyuNum(findHatyuNumBycondResult result)
        {
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

            hikVO1[] hatyuDataVOList = result._thb5HikList;
            if (hatyuDataVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetail.THB5HIK.TableName, hatyuDataVOList) };
                Isid.KKH.Common.KKHSchema.Detail dsData = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.Detail>(defs);
                dsDetail.THB5HIK.Merge(dsData.THB5HIK);
            }

            FindHatyuNumServiceResult parseResult = new FindHatyuNumServiceResult();
            parseResult.DetailDataSet = dsDetail;

            return parseResult;
        }

        /// <summary>
        ///発注データ取得 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        internal static FindDetailDataByCondParseResult ParseForFindHatyuDataByCond(findThb5HikResult result)
        {
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

            hikVO1[] hikDataVoList = result._thb5HikList;
            if (hikDataVoList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetail.THB5HIK.TableName, hikDataVoList) };
                Isid.KKH.Common.KKHSchema.Detail dsData = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.Detail>(defs);
                dsDetail.THB5HIK.Merge(dsData.THB5HIK);
            }

            FindDetailDataByCondParseResult parseResult = new FindDetailDataByCondParseResult();
            parseResult.DetailDataSet = dsDetail;

            return parseResult;
        }

        /// <summary>
        /// 広告費明細データ検索パース結果を取得します。 
        /// </summary>
        /// <param name="result">広告費明細データ検索結果</param>
        /// <returns>広告費明細データ検索パース結果</returns>
        internal static FindDetailDataByCondParseResult ParseForFindDetailDataByCond(findMeisaiDataResult result)
        {
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

            thb2KmeiVO[] thb2KmeiVOList = result.thb2KmeiList;
            if (thb2KmeiVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetail.THB2KMEI.TableName, thb2KmeiVOList) };
                Isid.KKH.Common.KKHSchema.Detail dsData = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.Detail>(defs);
                dsDetail.THB2KMEI.Merge(dsData.THB2KMEI);
            }

            FindDetailDataByCondParseResult parseResult = new FindDetailDataByCondParseResult();
            parseResult.DetailDataSet = dsDetail;

            return parseResult;
        }



        /// <summary>
        /// 発注データ確認 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        internal static FindDetailDataByCondParseResult ParseForFindHatyuConfirm(findHatyuConfirmResult result)
        {
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

            hikVO1[] hikDataVoList = result._thb5HikList;
            if (hikDataVoList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetail.THB5HIK.TableName, hikDataVoList) };
                Isid.KKH.Common.KKHSchema.Detail dsData = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.Detail>(defs);
                dsDetail.THB5HIK.Merge(dsData.THB5HIK);
            }

            FindDetailDataByCondParseResult parseResult = new FindDetailDataByCondParseResult();
            parseResult.DetailDataSet = dsDetail;

            return parseResult;
        }



    }
}
