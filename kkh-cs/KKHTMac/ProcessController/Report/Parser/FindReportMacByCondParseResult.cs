using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Mac.Schema;

namespace Isid.KKH.Mac.ProcessController.Report.Parser
{
    class FindReportMacByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// 広告費明細入力データセットです。 
        /// </summary>
        private RepDsMac _dsDetail;

        /// <summary>
        /// 広告費明細入力データセットを取得または設定します。 
        /// </summary>
        public RepDsMac ReoMacDataSet
        {
            get { return _dsDetail; }
            set { _dsDetail = value; }
        }

        #endregion プロパティ
    }
}
