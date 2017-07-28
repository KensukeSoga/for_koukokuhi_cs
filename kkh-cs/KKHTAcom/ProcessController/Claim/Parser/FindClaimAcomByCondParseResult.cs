using System;

namespace Isid.KKH.Acom.ProcessController.Claim.Parser
{
    class FindClaimAcomByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// 請求データセット.
        /// </summary>
        private Isid.KKH.Acom.Schema.ClaimDSAcom _ds;

        /// <summary>
        /// 請求データセットを取得または設定します.
        /// </summary>
        public Isid.KKH.Acom.Schema.ClaimDSAcom ClaimAcomDataSet
        {
            get { return _ds; }
            set { _ds = value; }
        }

        #endregion プロパティ 
    }
}
