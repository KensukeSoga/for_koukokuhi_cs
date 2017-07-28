using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Kmn.ProcessController.Report
{
    /// <summary>
    /// 帳票（伝票）データ検索サービス結果 （公文）
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
    internal class FindReportKmnByCondServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 帳票（公文_伝票）データセットです。 
        /// </summary>
        private Isid.KKH.Kmn.Schema.RepDSKmn _dsReport;

        /// <summary>
        /// 帳票（公文_伝票）データセットを取得または設定します。 
        /// </summary>
        internal Isid.KKH.Kmn.Schema.RepDSKmn ReportDataSet
        {
            get { return _dsReport; }
            set { _dsReport = value; }
        }

        #endregion プロパティ 
    }
}
