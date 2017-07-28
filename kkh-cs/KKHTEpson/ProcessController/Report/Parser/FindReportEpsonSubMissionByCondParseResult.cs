using System;

namespace Isid.KKH.Epson.ProcessController.Report.Parser
{
    internal class FindReportEpsonSubMissionByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// 帳票データセットです。 
        /// </summary>
        private Isid.KKH.Epson.Schema.RepDsEpson _ds;

        /// <summary>
        /// 帳票データセットを取得または設定します。 
        /// </summary>
        internal Isid.KKH.Epson.Schema.RepDsEpson ReportDataSet
        {
            get { return _ds; }
            set { _ds = value; }
        }

        #endregion プロパティ 
    }
}
