using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Skyp.ProcessController.Detail
{
    /// <summary>
    /// 並び順データ検索サービス結果 
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
    ///       <description>2011/12/21</description>
    ///       <description>JSE Y.Sato</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class FindOrderByCondServiceResult : KKHServiceResult
    {
        #region プロパティ 

        /// <summary>
        /// 広告費明細入力（スカパー）データセットです。 
        /// </summary>
        private Isid.KKH.Skyp.Schema.DetailDSSkyp _dsDetail;

        /// <summary>
        /// 広告費明細入力（スカパー）データセットを取得または設定します。 
        /// </summary>
        internal Isid.KKH.Skyp.Schema.DetailDSSkyp DetailDataSet
        {
            get { return _dsDetail; }
            set { _dsDetail = value; }
        }

        #endregion プロパティ 
    }
}
