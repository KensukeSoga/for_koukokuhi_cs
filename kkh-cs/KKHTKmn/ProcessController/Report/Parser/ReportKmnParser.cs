using System;

using Isid.Soa.Framework.Client.DataSetConverter;
using Isid.KKH.Common.KKHServiceProxy;
using Isid.KKH.Kmn.Schema;

namespace Isid.KKH.Kmn.ProcessController.Report.Parser
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
    ///       <description>2013/1/31</description>
    ///       <description>JSE M.Naito</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class ReportKmnParser
    {
        /// <summary>
        /// 帳票（公文_伝票）データを取得。 
        /// </summary>
        /// <param name="result">帳票（公文_伝票）データの検索結果</param>
        /// <returns>帳票（公文_伝票）データの検索パース結果</returns>
        internal static FindReportKmnByCondParseResult ParseForFindReportKmnByCond(reportKmnResult result)
        {
            RepDSKmn dsKmn = new RepDSKmn();

            // 伝票用明細データ
            reportKmnMeisaiVO[] report = result.meisai;
            if (report != null)
            {
                DataTableDef[] defs = new DataTableDef[] { new DataTableDef(dsKmn.RepKmnMeisai.TableName, report) };
                RepDSKmn dsData = DataSetConverter.Convert<RepDSKmn>(defs);
                dsKmn.RepKmnMeisai.Merge(dsData.RepKmnMeisai);
            }



            //foreach (System.Data.DataRow row in result.meisai)
            //{
            //    dsKmn.RepKmnMeisai.AddRepKmnMeisaiRow(row);
            //}

            //for (int i = 0; i < report.Length; i++)
            //{
            //    RepDSKmn.RepKmnMeisaiDataTable dt = new RepDSKmn.RepKmnMeisaiDataTable();
            //    RepDSKmn.RepKmnMeisaiDataTable dt1 = new RepDSKmn.RepKmnMeisaiDataTable();
            //    dt1.NewRepKmnMeisaiRow();
            //    dt = dt1.NewRepKmnMeisaiRow();



                //RepDSKmn.RepKmnMeisaiDataTable addrow1 = new RepDSKmn.RepKmnMeisaiDataTable();

                //addrow1.jyutyuNoColumn = report[i].JYUTNO;

                //addrow.RepKmnMeisai.jyutyuNoColumn = report[i].JYUTNO;
                //addrow.RepKmnMeisai.jyuMeiNoColumn = report[i].JYMEINO;
                //addrow.RepKmnMeisai.uriMeiNoColumn = report[i].URMEINO;
                //addrow.RepKmnMeisai.hinmoku1Column = report[i].NAME3;
                //addrow.RepKmnMeisai.hinmoku2Column = report[i].NAME4;
                //addrow.RepKmnMeisai.hinmoku3Column = report[i].NAME5;
                //addrow.RepKmnMeisai.bumonCdColumn = report[i].CODE1;
                //addrow.RepKmnMeisai.bumonNmColumn = report[i].NAME6;
                //addrow.RepKmnMeisai.kingakuColumn = report[i].KNGK1;

                //dsKmn.RepKmnMeisai.AddRepKmnMeisaiRow(addrow);
            //}


            FindReportKmnByCondParseResult parseResult = new FindReportKmnByCondParseResult();
            parseResult.ReportDataSet = dsKmn;

            return parseResult;
        }
    }
}
