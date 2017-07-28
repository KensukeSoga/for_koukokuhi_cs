using System;

using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Acom.ProcessController.Claim
{
    /// <summary>
    /// 請求データ検索サービス結果 
    /// </summary>
    /// <remarks>
    ///   修正管理 
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/2/09</description>
    ///       <description>JSE Y.Sato</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class FindClaimAcomByCondServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 請求データセットです。 
        /// </summary>
        private Isid.KKH.Acom.Schema.ClaimDSAcom _claimDataSet;

        /// <summary>
        /// 請求データセットを取得または設定します。 
        /// </summary>
        internal Isid.KKH.Acom.Schema.ClaimDSAcom ClaimDataSet
        {
            get { return _claimDataSet; }
            set { _claimDataSet = value; }
        }

        #endregion プロパティ
    }

    /// <summary>
    /// 送信フラグ更新サービス結果 
    /// </summary>
    /// <remarks>
    ///   修正管理 
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2012/2/20</description>
    ///       <description>JSE Y.Sato</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    internal class UpdateOutFlgServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 請求データセットです。 
        /// </summary>
        private Isid.KKH.Acom.Schema.ClaimDSAcom _claimDataSet;

        /// <summary>
        /// 請求データセットを取得または設定します。 
        /// </summary>
        internal Isid.KKH.Acom.Schema.ClaimDSAcom ClaimDataSet
        {
            get { return _claimDataSet; }
            set { _claimDataSet = value; }
        }

        #endregion プロパティ
    }
}
