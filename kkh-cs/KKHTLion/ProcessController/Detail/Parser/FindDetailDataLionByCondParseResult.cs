using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Lion.ProcessController.Detail.Parser
{
    class FindDetailDataLionByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// 広告費明細入力データセットです。 
        /// </summary>
        private Isid.KKH.Lion.Schema.DetailDSLion _dsDetailLion;

        /// <summary>
        /// 広告費明細入力データセットを取得または設定します。 
        /// </summary>
        public Isid.KKH.Lion.Schema.DetailDSLion DetailLionDataSet
        {
            get { return _dsDetailLion; }
            set { _dsDetailLion = value; }
        }

        #endregion プロパティ
    }
}
