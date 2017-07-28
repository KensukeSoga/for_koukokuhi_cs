using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Ash.Schema;
namespace Isid.KKH.Ash.ProcessController.Report.Parser
{
    class ReportAshParseResult
    {
        #region プロパティ

        /// <summary>
        /// 汎用パーサーデータセットです。 
        /// </summary>
        private RepDsAsh _dsRepAsh;

        /// <summary>
        /// 汎用パーサーデータセットを取得または設定します。 
        /// </summary>
        public RepDsAsh RepAshDataSet
        {
            get { return _dsRepAsh; }
            set { _dsRepAsh = value; }
        }

        #endregion プロパティ
    }
}
