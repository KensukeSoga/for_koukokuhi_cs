using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Lion.Schema;

namespace Isid.KKH.Lion.ProcessController.MastGet.Parser
{
    class FindLionMastParseResult
    {
        #region プロパティ

        /// <summary>
        /// 広告費明細入力データセットです。 
        /// </summary>
        private MastLion _dsDetail;

        /// <summary>
        /// 広告費明細入力データセットを取得または設定します。 
        /// </summary>
        public MastLion MastLionDataSet
        {
            get { return _dsDetail; }
            set { _dsDetail = value; }
        }

        #endregion プロパティ
    }
}
