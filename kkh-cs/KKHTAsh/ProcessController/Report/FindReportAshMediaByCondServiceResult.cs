using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Ash.Schema;
namespace Isid.KKH.Ash.ProcessController.Report
{
    /// <summary>
    /// レポート（Ash)検索サービス結果 
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
    ///       <description>2012/01/19</description>
    ///       <description>Fourm H.Izawa</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class FindReportAshMediaByCondServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 汎用データセットです 
        /// </summary>
        private RepDsAsh _dsRepAsh;

        /// <summary>
        /// 汎用データセットの取得と設定です 
        /// </summary>
        public RepDsAsh dsAshDataSet
        {
            get { return _dsRepAsh; }
            set { _dsRepAsh = value; }
        }

        #endregion プロパティ
    }
}
