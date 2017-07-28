using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Common.KKHProcessController.Detail
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
    ///       <description>2011/11/24</description>
    ///       <description>JSE K.Fukuda</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class FindDetailDataByCondServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 汎用データセットです。 
        /// </summary>
        private Isid.KKH.Common.KKHSchema.Detail _dsDetail;

        /// <summary>
        /// 汎用データセットを取得または設定します。 
        /// </summary>
        public Isid.KKH.Common.KKHSchema.Detail DetailDataSet
        {
            get { return _dsDetail; }
            set { _dsDetail = value; }
        }

        #endregion プロパティ
    }
}
