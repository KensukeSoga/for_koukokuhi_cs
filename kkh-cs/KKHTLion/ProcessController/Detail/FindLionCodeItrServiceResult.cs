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
    ///       <description>2012/02/27</description>
    ///       <description>JSE A.Naito</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class FindLionCodeItrServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 汎用データセットです。 
        /// </summary>
        private DetailDSLion _ciLion;

        /// <summary>
        /// 汎用データセットを取得または設定します。 
        /// </summary>
        public DetailDSLion CILionDataSet
        {
            get { return _ciLion; }
            set { _ciLion = value; }
        }

        #endregion プロパティ
    }
}
