using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Tkd.ProcessController.Report
{
    /// <summary>
    /// 武田請求明細（中分類別）検索サービス結果
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
    ///       <description>2012/01/23</description>
    ///       <description>JSE H.Sasaki</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class FindReportTkdBillingByMiddleClassificationByCondServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 汎用データセット
        /// </summary>
        private Isid.KKH.Tkd.Schema.ReportDSTkdBilling _dsReportTkdBilling;

        /// <summary>
        /// 汎用データセットを取得または設定する
        /// </summary>
        public Isid.KKH.Tkd.Schema.ReportDSTkdBilling dsReportTkdBillingDataSet
        {
            get { return _dsReportTkdBilling; }
            set { _dsReportTkdBilling = value; }
        }

        #endregion プロパティ
    }
}
