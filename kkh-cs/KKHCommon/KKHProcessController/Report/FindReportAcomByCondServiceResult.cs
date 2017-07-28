using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Common.KKHProcessController.Report
{
    /// <summary>
    /// レポート(Acom)検索サービス結果.
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
    ///       <description>2012/01/11</description>
    ///       <description>作成者</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class FindReportAcomByCondServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 汎用データセット.
        /// </summary>
        private Isid.KKH.Common.KKHSchema.RepDsAcom _dsRepAcom;

        /// <summary>
        /// 汎用データセットを取得または設定.
        /// </summary>
        public Isid.KKH.Common.KKHSchema.RepDsAcom dsRepAcomDataSet
        {
            get { return _dsRepAcom; }
            set { _dsRepAcom = value; }
        }

        #endregion プロパティ
    }
}
