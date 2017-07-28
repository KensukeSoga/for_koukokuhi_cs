using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Epson.ProcessController.Report
{
    /// <summary>
    /// 帳票（エプソン_請求予定一覧）データ検索サービス結果 
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
    ///       <description>2012/3/13</description>
    ///       <description>IP J.Kamiyama</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class FindReportEpsonSeikyuPlanByCondServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 帳票（エプソン）データセットです。 
        /// </summary>
        private Isid.KKH.Epson.Schema.RepDsEpson _dsReport;

        /// <summary>
        /// 帳票（エプソン）データセットを取得または設定します。 
        /// </summary>
        internal Isid.KKH.Epson.Schema.RepDsEpson ReportDataSet
        {
            get { return _dsReport; }
            set { _dsReport = value; }
        }

        #endregion プロパティ 
    }
}
