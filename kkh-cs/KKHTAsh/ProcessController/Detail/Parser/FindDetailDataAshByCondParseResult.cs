using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Ash.ProcessController.Detail.Parser
{
    class FindDetailDataAshByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// 広告費明細入力データセットです。.
        /// </summary>
        private Isid.KKH.Ash.Schema.DetailDSAsh _dsDetailAsh;

        /// <summary>
        /// 広告費明細入力データセットを取得または設定します。.
        /// </summary>
        public Isid.KKH.Ash.Schema.DetailDSAsh DetailAshDataSet
        {
            get { return _dsDetailAsh; }
            set { _dsDetailAsh = value; }
        }

        #endregion プロパティ
    }
}
