using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Lion.Schema;
namespace Isid.KKH.Lion.ProcessController.History
{
    /// <summary>
    /// 履歴（LION)検索サービス結果
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
    ///       <description>2012/2/1</description>
    ///       <description>Fourm H.Izawa</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class FindHisLionByCondServiceResult : KKHServiceResult
    {
        #region "プロパティ"

        /// <summary>
        /// 汎用データセットです
        /// </summary>
        private HisDsLion _dsHisLion;

        /// <summary>
        /// 汎用データセットの取得と設定です
        /// </summary>
        public HisDsLion dsLionDataSet
        {
            get { return _dsHisLion; }
            set { _dsHisLion = value; }
        }

        #endregion "プロパティ"

    }
}
