using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Common.KKHProcessController.Report.Parser
{
    class FindReportMacByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// 広告費明細入力データセットです。 
        /// </summary>
        private Isid.KKH.Common.KKHSchema.RepDsMac _dsDetail;

        /// <summary>
        /// 広告費明細入力データセットを取得または設定します。 
        /// </summary>
        public Isid.KKH.Common.KKHSchema.RepDsMac ReoMacDataSet
        {
            get { return _dsDetail; }
            set { _dsDetail = value; }
        }

        #endregion プロパティ
    }
}
