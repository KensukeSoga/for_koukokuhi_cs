using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Lion.ProcessController.Report.Parser
{
    class FindReportLionByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// 広告費明細入力データセット.
        /// </summary>
        private Isid.KKH.Lion.Schema.RepDsLion _dsDetail;

        /// <summary>
        /// 広告費明細入力データセットを取得または設定します.
        /// </summary>
        public Isid.KKH.Lion.Schema.RepDsLion RepLionDataSet
        {
            get { return _dsDetail; }
            set { _dsDetail = value; }
        }

        #endregion プロパティ

    }
}
