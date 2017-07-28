using System;
using System.Collections.Generic;
using System.Text;

using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Common.KKHSchema;

namespace Isid.KKH.Common.KKHProcessController.Detail
{

    /// <summary>
    /// 表示データ登録サービス結果 
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
    ///       <description></description>
    ///       <description></description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class UpdateDisplayDataServiceResult : KKHServiceResult
    {
        #region メンバ変数
        private Isid.KKH.Common.KKHSchema.Detail _dsDetail = new Isid.KKH.Common.KKHSchema.Detail();
        #endregion メンバ変数

        #region プロパティ
        /// <summary>
        /// 表示データ登録処理後のデータを取得、または設定します 
        /// </summary>
        public Isid.KKH.Common.KKHSchema.Detail DsDetail
        {
            get { return _dsDetail; }
            set { _dsDetail = value; }
        }
        #endregion プロパティ
    }
}
