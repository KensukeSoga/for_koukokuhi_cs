using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Kmn.ProcessController.Report
{
    /// <summary>
    /// 帳票（公文_広告費明細表）データ検索サービス結果 
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
    ///       <description>JSE A.Naito</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class FindReportKmnListByCondServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 帳票（公文_請求一覧）データセットです。 
        /// </summary>
        private Isid.KKH.Kmn.Schema.RepDSKmn _dsReport;

        /// <summary>
        /// 帳票（公文_請求一覧）データセットを取得または設定します。 
        /// </summary>
        internal Isid.KKH.Kmn.Schema.RepDSKmn ReportDataSet
        {
            get { return _dsReport; }
            set { _dsReport = value; }
        }

        #endregion プロパティ 
    }
}
