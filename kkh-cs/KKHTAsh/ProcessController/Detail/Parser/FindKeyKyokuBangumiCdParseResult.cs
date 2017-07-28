using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Ash.ProcessController.Detail.Parser
{
    /// <summary>
    /// キー局の番組コードの取得のためのParseResult
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
    ///       <description>HLC S.Jang</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class FindKeyKyokuBangumiCdParseResult
    {
        #region プロパティ

        /// <summary>
        /// キー局の番組コードをセットします
        /// </summary>
        private Isid.KKH.Ash.Schema.DetailDSAsh _dsDetailAsh;

        /// <summary>
        /// キー局の番組コードを取得または設定します。.
        /// </summary>
        public Isid.KKH.Ash.Schema.DetailDSAsh DetailAshDataSet
        {
            get { return _dsDetailAsh; }
            set { _dsDetailAsh = value; }
        }

        #endregion プロパティ
    }
}
