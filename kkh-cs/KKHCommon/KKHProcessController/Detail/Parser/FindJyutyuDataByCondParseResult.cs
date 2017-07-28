using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Common.KKHProcessController.Detail.Parser
{
    class FindJyutyuDataByCondParseResult
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
