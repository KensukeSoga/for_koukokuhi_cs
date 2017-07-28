using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;


namespace Isid.KKH.Lion.ProcessController.Detail
{
    /// <summary>
    /// 件名変更（LION)サービス結果
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
    ///       <description>2012/2/10</description>
    ///       <description>Fourm A.Naito</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class UpdateSubjectDataServiceResult : KKHServiceResult
    {
        #region "プロパティ"
        /// <summary>
        /// 汎用データセットです 
        /// </summary>
        private Isid.KKH.Common.KKHServiceProxy.thb1DownVO[] _thb1Down;

        /// <summary>
        /// 汎用データセットの取得と設定です 
        /// </summary>
        public Isid.KKH.Common.KKHServiceProxy.thb1DownVO[] DetailDataSet
        {
            get { return _thb1Down; }
            set { _thb1Down = value; }
        }
        #endregion "プロパティ"
    }
}
