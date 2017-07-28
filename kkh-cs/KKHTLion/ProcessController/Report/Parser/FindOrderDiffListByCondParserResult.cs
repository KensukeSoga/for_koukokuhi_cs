using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Lion.ProcessController.Report.Parser
{
    /// <summary>
    /// 得意先ライオン受注比較一覧検索パース結果.
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
    ///       <description>2014/11/10</description>
    ///       <description>HLC S.Fujimoto</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class FindOrderDiffListByCondParserResult
    {
        #region プロパティ.

        /// <summary>
        /// ライオン受注比較一覧データセット.
        /// </summary>
        private Isid.KKH.Lion.Schema.OrderDiffLion _dsOrdDiffListLion;

        /// <summary>
        /// ライオン履歴データセットを取得または設定.
        /// </summary>
        public Isid.KKH.Lion.Schema.OrderDiffLion OrdDiffListLionDataSet
        {
            get { return _dsOrdDiffListLion; }
            set { _dsOrdDiffListLion = value; }
        }

        #endregion プロパティ.
    }

}
