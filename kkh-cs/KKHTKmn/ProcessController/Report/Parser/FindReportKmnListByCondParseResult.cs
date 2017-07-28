using System;

namespace Isid.KKH.Kmn.ProcessController.Report.Parser
{
    internal class FindReportKmnListByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// 帳票データセットです。 
        /// </summary>
        private Isid.KKH.Kmn.Schema.RepDSKmn _dsKmn;

        /// <summary>
        /// 帳票データセットを取得または設定します。 
        /// </summary>
        internal Isid.KKH.Kmn.Schema.RepDSKmn ReportDataSet
        {
            get { return _dsKmn; }
            set { _dsKmn = value; }
        }

        #endregion プロパティ 
    }
}
