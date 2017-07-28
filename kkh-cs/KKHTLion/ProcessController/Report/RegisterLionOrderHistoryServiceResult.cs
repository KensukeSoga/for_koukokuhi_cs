using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Lion.Schema;

namespace Isid.KKH.Lion.ProcessController.Report
{
    /// <summary>
    /// ライオン受注履歴作成サービス結果.
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
    public class RegisterLionOrderHistoryServiceResult : KKHServiceResult
    {
        #region プロパティ.

        /// <summary>
        /// 汎用データセット.
        /// </summary>
        private Isid.KKH.Common.KKHSchema.MasterMaintenance _dsMaster;

        /// <summary>
        /// 汎用データセットを取得または設定します.
        /// </summary>
        public Isid.KKH.Common.KKHSchema.MasterMaintenance MasterDataSet
        {
            get { return _dsMaster; }
            set { _dsMaster = value; }
        }

        #endregion プロパティ.
    }

}
