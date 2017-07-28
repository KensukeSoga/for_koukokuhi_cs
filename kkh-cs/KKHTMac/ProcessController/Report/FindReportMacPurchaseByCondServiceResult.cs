using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Mac.Schema;

namespace Isid.KKH.Mac.ProcessController.Report
{

    /// <summary>
    /// レポート（Mac購入伝票)検索サービス結果
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
    ///       <description>2012/01/18</description>
    ///       <description>IP H.shimizu</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class FindReportMacPurchaseByCondServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 汎用データセットです。

        /// </summary>
        private RepDsMac _dsRepMac;

        /// <summary>
        /// 汎用データセットを取得または設定します。

        /// </summary>
        public RepDsMac dsRepMacDataSet
        {
            get { return _dsRepMac; }
            set { _dsRepMac = value; }
        }

        #endregion プロパティ
    }
}
