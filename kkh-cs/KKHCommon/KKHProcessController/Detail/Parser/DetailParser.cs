using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using System.Data;

namespace Isid.KKH.Common.KKHProcessController.Detail.Parser
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
    ///       <description>2011/11/14</description>
    ///       <description>JSE K.Fukuda</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class DetailParser
    {
        #region メソッド

        /// <summary>
        /// 受注データ検索パース結果を取得します。 
        /// </summary>
        /// <param name="result">受注データ検索結果</param>
        /// <returns>受注データ検索パース結果</returns>
        internal static FindJyutyuDataByCondParseResult ParseForFindJutyuDataByCond(jyutyuDataCondResult result)
        {
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

            jyutyuDataVO[] jyutyuDataVOList = result.jutyuData;
            if (jyutyuDataVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetail.JyutyuData.TableName, jyutyuDataVOList) };
                Isid.KKH.Common.KKHSchema.Detail dsData = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.Detail>(defs);
                dsDetail.JyutyuData.Merge(dsData.JyutyuData);
            }
            if (jyutyuDataVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetail.THB1DOWN.TableName, jyutyuDataVOList) };
                Isid.KKH.Common.KKHSchema.Detail dsData = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.Detail>(defs);
                dsDetail.THB1DOWN.Merge(dsData.THB1DOWN);
            }

            FindJyutyuDataByCondParseResult parseResult = new FindJyutyuDataByCondParseResult();
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

//            jyutyuDataVO[] jyutyuDataVOList = result.jutyuData;
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
        internal static FindDetailDataByCondParseResult ParseForFindDetailDataByCond(detailDataResult result)
        {
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

            thb2KmeiVO[] thb2KmeiVOList = result.thb2KmeiList;
            if (thb2KmeiVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetail.THB2KMEI.TableName, thb2KmeiVOList) };
                Isid.KKH.Common.KKHSchema.Detail dsData = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.Detail>(defs);
                dsDetail.THB2KMEI.Merge(dsData.THB2KMEI);
            }

            //tga7MshoVO[] tga7MshoVOList = result.tga7MshoList;
            //if (tga7MshoVOList != null)
            //{
            //    DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetail.TGA7MSHO.TableName, tga7MshoVOList) };
            //    Isid.KKH.Common.KKHSchema.Detail dsData = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.Detail>(defs);
            //    dsDetail.TGA7MSHO.Merge(dsData.TGA7MSHO);
            //}

            FindDetailDataByCondParseResult parseResult = new FindDetailDataByCondParseResult();
            parseResult.DetailDataSet = dsDetail;

            return parseResult;
        }

        ///// <summary>
        ///// 受注明細のデータを取得。 
        ///// </summary>
        ///// <param name="result">受注明細の検索結果</param>
        ///// <returns>受注明細の検索パース結果</returns>
        //internal static FindJyutyuDataByCondServiceResult ParseForFindThb2KmeiDataByCond(findThb2KmeiBycondResult result)
        //{
        //    Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

        //    thb2KmeiVO[] jyutyuDataVOList = result._thb2KmeiList;
        //    if (jyutyuDataVOList != null)
        //    {
        //        DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetail.THB2KMEI.TableName, jyutyuDataVOList) };
        //        Isid.KKH.Common.KKHSchema.Detail dsData = new Isid.KKH.Common.KKHSchema.Detail();
        //        dsData = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.Detail>(defs);
        //        dsDetail.THB2KMEI.Merge(dsData.THB2KMEI);
        //    }

        //    FindJyutyuDataByCondServiceResult parseResult = new FindJyutyuDataByCondServiceResult();
        //    parseResult.DetailDataSet = dsDetail;

        //    return parseResult;
        //}

        /// <summary>
        /// 受注ダウンロード履歴データ検索パース結果を取得します。 
        /// </summary>
        /// <param name="result">受注ダウンロード履歴データ検索結果</param>
        /// <returns>受注ダウンロード履歴データ検索パース結果</returns>
        internal static FindJyutyuRirekiDataByCondParseResult ParseForFindJutyuRirekiDataByCond(thb8DownRResult result)
        {
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

            thb8DownRVO[] thb8DownRVOList = result.thb8DownRList;
            if (thb8DownRVOList != null)
            {
                dsDetail.THB8DOWNR.Merge(ParseForTHB8DOWNR(thb8DownRVOList));
            }

            FindJyutyuRirekiDataByCondParseResult parseResult = new FindJyutyuRirekiDataByCondParseResult();
            parseResult.DetailDataSet = dsDetail;

            return parseResult;
        }

        public static Isid.KKH.Common.KKHSchema.Detail.THB1DOWNDataTable ParseForTHB1DOWN(thb1DownVO[] thb1DownVo)
        {
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

            if (thb1DownVo != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetail.THB1DOWN.TableName, thb1DownVo) };
                dsDetail = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.Detail>(defs);
            }

            return dsDetail.THB1DOWN;
        }

        public static Isid.KKH.Common.KKHSchema.Detail.THB2KMEIDataTable ParseForTHB2KMEI(thb2KmeiVO[] thb2KmeiVo)
        {
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

            if (thb2KmeiVo != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetail.THB2KMEI.TableName, thb2KmeiVo) };
                dsDetail = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.Detail>(defs);
            }

            return dsDetail.THB2KMEI;
        }

        public static Isid.KKH.Common.KKHSchema.Detail.THB8DOWNRDataTable ParseForTHB8DOWNR(thb8DownRVO[] thb8DownRVo)
        {
            Isid.KKH.Common.KKHSchema.Detail dsDetail = new Isid.KKH.Common.KKHSchema.Detail();

            if (thb8DownRVo != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsDetail.THB8DOWNR.TableName, thb8DownRVo) };
                dsDetail = DataSetConverter.Convert<Isid.KKH.Common.KKHSchema.Detail>(defs);
            }

            return dsDetail.THB8DOWNR;
        }
        #endregion メソッド
    }
}
