using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Common.KKHProcessController.SystemCommon.Parser
{
    /// <summary>
    /// 
    /// </summary>
    class FindCommonByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// 汎用データセットです。 
        /// </summary>
        private Isid.KKH.Common.KKHSchema.Common _dsMaster;

        /// <summary>
        /// 汎用データセットを取得または設定します。 
        /// </summary>
        public Isid.KKH.Common.KKHSchema.Common CommonDataSet
        {
            get { return _dsMaster; }
            set { _dsMaster = value; }
        }

        #endregion プロパティ
    }
}
