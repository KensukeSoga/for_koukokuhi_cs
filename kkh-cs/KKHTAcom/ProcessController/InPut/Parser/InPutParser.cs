using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Acom.Schema;

namespace Isid.KKH.Acom.ProcessController.InPut.Parser
{
    /// <summary>
    /// 登録サービスパーサー 
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
    ///       <description>2011/11/10</description>
    ///       <description>HLC K.Fujisaki</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class InPutParser
    {
        #region メソッド
        /// <summary>
        /// 検索パース結果を取得します。 
        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static FindHikByCondParseResult ParseForFindHikByCond(hikSearchResult result)
        {
            InPutHik dsHik = new InPutHik();

            // アコム発注取込情報データテーブル 
            hikVO[] hikVOList = result.hikVOList;
            if (hikVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsHik.InPutHikData.TableName, hikVOList) };
                InPutHik dsAddMaster = DataSetConverter.Convert<InPutHik>(defs);
                dsHik.InPutHikData.Merge(dsAddMaster.InPutHikData);

                DataTableDef[] defs_Snbn = new DataTableDef[] { new DataTableDef(dsHik.InPutHikData_Snbn.TableName, hikVOList) };
                InPutHik dsAddMaster_Snbn = DataSetConverter.Convert<InPutHik>(defs_Snbn);
                dsHik.InPutHikData_Snbn.Merge(dsAddMaster_Snbn.InPutHikData_Snbn);
            }

            FindHikByCondParseResult parseResult = new FindHikByCondParseResult();
            parseResult.HikDataSet = dsHik;

            return parseResult;
        }

        /// <summary>
        /// 検索パース結果(日付検索件数)を取得します。 
        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static FindHikByCondParseResult ParseForFindHikDateCntByCond(hikSearchResult result)
        {
            InPutHik dsHik = new InPutHik();

            // アコム発注取込情報データテーブル
            hikSearchDateCntVO[] hikSearchDateCntVOList = result.hikSearchDateCntVOList;
            if (hikSearchDateCntVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsHik.DateCntData.TableName, hikSearchDateCntVOList) };
                InPutHik dsAddMaster = DataSetConverter.Convert<InPutHik>(defs);
                dsHik.DateCntData.Merge(dsAddMaster.DateCntData);
            }

            FindHikByCondParseResult parseResult = new FindHikByCondParseResult();
            parseResult.HikDataSet = dsHik;

            return parseResult;
        }

        /// <summary>
        /// 検索パース結果(比較用)を取得します。 
        /// </summary>
        /// <param name="result">マスタ検索結果</param>
        /// <returns>マスタ検索パース結果</returns>
        internal static FindHikByCondParseResult ParseForFindHikCheckDataByCond(hikSearchResult result)
        {
            InPutHik dsHik = new InPutHik();

            // アコム発注取込情報データテーブル 
            hikVO[] hikVOList = result.hikVOList;
            if (hikVOList != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsHik.FileImp.TableName, hikVOList) };
                InPutHik dsAddMaster = DataSetConverter.Convert<InPutHik>(defs);
                dsHik.FileImp.Merge(dsAddMaster.FileImp);
            }

            FindHikByCondParseResult parseResult = new FindHikByCondParseResult();
            parseResult.HikDataSet = dsHik;

            return parseResult;
        }

        #endregion
    }
}
