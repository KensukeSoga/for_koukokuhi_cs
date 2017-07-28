using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Common.KKHProcessController.Detail.Parser
{
    class FindDetailDataByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// 広告費明細入力データセットです。 
        /// </summary>
        private Isid.KKH.Common.KKHSchema.Detail _dsDetail;

        /// <summary>
        /// 広告費明細入力データセットを取得または設定します。 
        /// </summary>
        public Isid.KKH.Common.KKHSchema.Detail DetailDataSet
        {
            get { return _dsDetail; }
            set { _dsDetail = value; }
        }

        #endregion プロパティ
    }
}
