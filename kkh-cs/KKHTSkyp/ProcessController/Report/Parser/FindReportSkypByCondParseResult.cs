using System;

namespace Isid.KKH.Skyp.ProcessController.Report.Parser
{
    internal class FindReportSkypByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// 帳票データセットです。 
        /// </summary>
        private Isid.KKH.Skyp.Schema.RepDSSkyp _dsSkyp;

        /// <summary>
        /// 帳票データセットを取得または設定します。 
        /// </summary>
        internal Isid.KKH.Skyp.Schema.RepDSSkyp ReportDataSet
        {
            get { return _dsSkyp; }
            set { _dsSkyp = value; }
        }

        #endregion プロパティ 
    }
}
