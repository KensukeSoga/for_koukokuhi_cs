using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Common.KKHProcessController.SystemCommon.Parser
{
    /// <summary>
    /// 
    /// </summary>
    class FindCommonCodeMasterByCondParseResult
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
