using System;

namespace Isid.KKH.Uni.ProcessController.Report.Parser
{
    internal class FindReportUniByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// 帳票データセットです。 
        /// </summary>
        private Isid.KKH.Uni.Schema.RepDsUni _dsUni;

        /// <summary>
        /// 帳票データセットを取得または設定します。 
        /// </summary>
        internal Isid.KKH.Uni.Schema.RepDsUni ReportDataSet
        {
            get { return _dsUni; }
            set { _dsUni = value; }
        }

        #endregion プロパティ 
    }
}
