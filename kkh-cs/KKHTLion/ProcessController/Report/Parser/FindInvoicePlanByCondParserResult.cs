using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Lion.ProcessController.Report.Parser
{
    /// <summary>
    /// 得意先ライオン請求予定表検索パース結果.
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
    ///       <description>2014/07/31</description>
    ///       <description>HLC S.Fujimoto</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class FindInvoicePlanByCondParserResult
    {
        #region プロパティ.

        /// <summary>
        /// ライオン履歴データセット.
        /// </summary>
        private Isid.KKH.Lion.Schema.InvoicePlanLion _dsInvPlnLion;

        /// <summary>
        /// ライオン履歴データセットを取得または設定.
        /// </summary>
        public Isid.KKH.Lion.Schema.InvoicePlanLion InvPlnLionDataSet
        {
            get { return _dsInvPlnLion; }
            set { _dsInvPlnLion = value; }
        }

        #endregion プロパティ.
    }

}
