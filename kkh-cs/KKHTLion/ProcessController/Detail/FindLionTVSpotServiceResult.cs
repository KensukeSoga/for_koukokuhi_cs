using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Lion.Schema;

namespace Isid.KKH.Lion.ProcessController.Detail
{
    /// <summary>
    /// ライオンTVSpotデータ検索サービス結果 
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
    ///       <description>2012/03/05</description>
    ///       <description>JSE H.Sasaki</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class FindLionTVSpotServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 汎用データセット 
        /// </summary>
        private DetailDSLion _dsDetailLion;

        /// <summary>
        /// 汎用データセットを取得または設定する 
        /// </summary>
        public DetailDSLion dsDetailLion
        {
            get { return _dsDetailLion; }
            set { _dsDetailLion = value; }
        }

        #endregion プロパティ
    }
}
