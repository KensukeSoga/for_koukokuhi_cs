using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Common.KKHProcessController.SystemCommon
{

    /// <summary>
    /// 汎用コードマスタ検索サービス結果 
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
    ///       <description>2011/02/03</description>
    ///       <description>HLC K.Honma</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class FindCommonCodeMasterByCondServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 汎用データセットです。 
        /// </summary>
        private Isid.KKH.Common.KKHSchema.Common _dsCommon;

        /// <summary>
        /// 汎用データセットを取得または設定します。 
        /// </summary>
        public Isid.KKH.Common.KKHSchema.Common CommonDataSet
        {
            get { return _dsCommon; }
            set { _dsCommon = value; }
        }

        #endregion プロパティ
    }
}
