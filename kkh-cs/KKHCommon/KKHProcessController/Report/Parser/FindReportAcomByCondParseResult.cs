using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Common.KKHProcessController.Report.Parser
{
    class FindReportAcomByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// 広告費明細入力データセット.
        /// </summary>
        private Isid.KKH.Common.KKHSchema.RepDsAcom _dsDetail;

        /// <summary>
        /// 広告費明細入力データセットを取得または設定します.
        /// </summary>
        public Isid.KKH.Common.KKHSchema.RepDsAcom RepAcomDataSet
        {
            get { return _dsDetail; }
            set { _dsDetail = value; }
        }

        #endregion プロパティ

    }
}
