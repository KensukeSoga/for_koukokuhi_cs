using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Skyp.ProcessController.Report
{
    /// <summary>
    /// 帳票（スカパー_納品／請求書）データ検索サービス結果 
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
    ///       <description>2012/1/16</description>
    ///       <description>JSE Y.Sato</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class FindReportSkypByCondServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 帳票（スカパー）データセットです。 
        /// </summary>
        private Isid.KKH.Skyp.Schema.RepDSSkyp _dsReport;

        /// <summary>
        /// 帳票（スカパー）データセットを取得または設定します。 
        /// </summary>
        internal Isid.KKH.Skyp.Schema.RepDSSkyp ReportDataSet
        {
            get { return _dsReport; }
            set { _dsReport = value; }
        }

        #endregion プロパティ 
    }
}
