using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Isid.KKH.Common.KKHSchema
{
    /// <summary>
    /// DataSetUtility
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
    ///       <description>2011/01/14</description>
    ///       <description>ISID-IT T.Kamidai</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class DataSetUtility
    {
        /// <summary>
        /// 引数のDataTableに引数のDataRowをコピー追加します。 
        /// インスタンスが異なるDataTableのDataRowをコピーしたい場合に 
        /// ご利用ください。 
        /// </summary>
        public static void AddCopiedRow(DataTable dt, DataRow dr)
        {
            DataRow row = dt.NewRow();
            for (int i = 0; i <= dt.Columns.Count - 1; i++)
            {
                for (int j = 0; j <= dr.Table.Columns.Count - 1; j++)
                {
                    if (dt.Columns[i].ColumnName == dr.Table.Columns[j].ColumnName)
                    {
                        row[i] = dr[j];
                        break;
                    }
                }
            }
            dt.Rows.Add(row);
        }

        /// <summary>
        /// 引数の文字列をSelect用にエスケープします。 
        /// </summary>
        public static string EscapeSelectKey(string str)
        {
            return str.Replace("'", "''");
        }
    }
}
