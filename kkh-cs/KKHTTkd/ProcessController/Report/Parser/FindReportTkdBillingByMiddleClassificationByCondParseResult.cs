using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Tkd.ProcessController.Report.Parser
{
    /// <summary>
    /// 武田請求明細（中分類別）検索サービスパーサ
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
    class FindReportTkdBillingByMiddleClassificationByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// 広告費明細入力データセット
        /// </summary>
        private Isid.KKH.Tkd.Schema.ReportDSTkdBilling _dsReportTkdBilling;

        /// <summary>
        /// 広告費明細入力データセットを取得または設定する
        /// </summary>
        public Isid.KKH.Tkd.Schema.ReportDSTkdBilling ReportTkdBillingDataSet
        {
            get { return _dsReportTkdBilling; }
            set { _dsReportTkdBilling = value; }
        }

        #endregion プロパティ
    }

}
