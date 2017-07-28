using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHSchema;
using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Common.KKHProcessController.Log
{
    /// <summary>
    /// ログ登録結果 
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
    ///       <description>2011/11/15</description>
    ///       <description>IP H.Shimizu</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class RegistLogServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// ログデータセットです。 
        /// </summary>
        private KKHSchema.Log _dsLog;

        /// <summary>
        /// ログデータセットを取得または設定します。 
        /// </summary>
        public KKHSchema.Log LogDataSet
        {
            get { return _dsLog; }
            set { _dsLog = value; }
        }

        #endregion プロパティ
    }
}
