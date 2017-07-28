using System;

namespace Isid.KKH.Skyp.ProcessController.Detail.Parser
{
    internal class FindOrderByCondParseResult
    {
        #region プロパティ 

        /// <summary>
        /// 広告費明細入力データセットです。 
        /// </summary>
        private Isid.KKH.Skyp.Schema.DetailDSSkyp _dsSkyp;

        /// <summary>
        /// 広告費明細入力データセットを取得または設定します。 
        /// </summary>
        internal Isid.KKH.Skyp.Schema.DetailDSSkyp DetailDataSet
        {
            get { return _dsSkyp; }
            set { _dsSkyp = value; }
        }

        #endregion プロパティ 
    }
}
