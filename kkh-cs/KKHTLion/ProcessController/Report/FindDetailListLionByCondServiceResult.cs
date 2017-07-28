using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Lion.ProcessController.Report
{
    /// <summary>
    /// 明細一覧帳票(Lion)検索サービス結果.
    /// </summary>
    /// <remarks>
    ///   修正管理.
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2013/02/01</description>
    ///       <description>作成者</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class FindDetailListLionByCondServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// ライオン帳票データセット.
        /// </summary>
        private Isid.KKH.Lion.Schema.RepDsLion _dsDetailListLion;

        /// <summary>
        /// ライオン帳票データセットを取得または設定.
        /// </summary>
        public Isid.KKH.Lion.Schema.RepDsLion dsDetailListLionDataSet
        {
            get { return _dsDetailListLion; }
            set { _dsDetailListLion = value; }
        }

        #endregion プロパティ
    }
}
