using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Toh.ProcessController.Parser
{
    class FindReportTohByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// 広告費明細入力データセットです。 
        /// </summary>
        private Isid.KKH.Toh.Schema.RepDsToh _dsDetail;

        /// <summary>
        /// 広告費明細入力データセットを取得または設定します。 
        /// </summary>
        public Isid.KKH.Toh.Schema.RepDsToh ReoTohDataSet
        {
            get { return _dsDetail; }
            set { _dsDetail = value; }
        }

        #endregion プロパティ
    }
}
