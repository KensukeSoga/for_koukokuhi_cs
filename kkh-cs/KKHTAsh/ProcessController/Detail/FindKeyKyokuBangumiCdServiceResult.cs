using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Ash.ProcessController.Detail
{
    /// <summary>
    /// 検索サービス結果.
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
    ///       <description>2014/08/15</description>
    ///       <description>HLC 張(Jang)</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class FindKeyKyokuBangumiCdServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 汎用データセットです。.
        /// </summary>
        private Isid.KKH.Ash.Schema.DetailDSAsh _dsDetailAsh;

        /// <summary>
        /// 汎用データセットを取得または設定します。.
        /// </summary>
        public Isid.KKH.Ash.Schema.DetailDSAsh DetailAshDataSet
        {
            get { return _dsDetailAsh; }
            set { _dsDetailAsh = value; }
        }
        #endregion プロパティ
    }
}

