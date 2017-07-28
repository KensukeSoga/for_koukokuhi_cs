using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;
using Isid.KKH.Lion.Schema;

namespace Isid.KKH.Lion.ProcessController.Detail
{

    /// <summary>
    /// 検索サービス結果 
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
    ///       <description>2012/02/22</description>
    ///       <description>JSE A.Naito</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class FindLionCardNoItrServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 汎用データセットです。 
        /// </summary>
        private DetailDSLion _cniLion;

        /// <summary>
        /// 汎用データセットを取得または設定します。 
        /// </summary>
        public DetailDSLion CNILionDataSet
        {
            get { return _cniLion; }
            set { _cniLion = value; }
        }

        #endregion プロパティ
    }
}
