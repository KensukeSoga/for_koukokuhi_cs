using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Lion.ProcessController.Report.Parser
{
    class FindDetailListLionByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// ライオン帳票データセット.
        /// </summary>
        private Isid.KKH.Lion.Schema.RepDsLion _dsDetailListLion;

        /// <summary>
        /// ライオン帳票データセットを取得または設定します.
        /// </summary>
        public Isid.KKH.Lion.Schema.RepDsLion DetailListLionDataSet
        {
            get { return _dsDetailListLion; }
            set { _dsDetailListLion = value; }
        }

        #endregion プロパティ

    }
}
