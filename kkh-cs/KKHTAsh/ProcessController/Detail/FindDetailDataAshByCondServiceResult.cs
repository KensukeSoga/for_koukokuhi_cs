using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHProcessController.Common;

namespace Isid.KKH.Ash.ProcessController.Detail
{

    /// <summary>
    /// 検索サービス結果.
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
    ///       <description>2012/01/04</description>
    ///       <description>JSE K.Fukuda</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class FindDetailDataAshByCondServiceResult : KKHServiceResult
    {
        #region プロパティ

        /// <summary>
        /// 汎用データセットです。.
        /// </summary>
        private Isid.KKH.Ash.Schema.DetailDSAsh _dsDetailAsh;

        /// <summary>
        /// 汎用データセットを取得または設定します。.
        /// </summary>
        public Isid.KKH.Ash.Schema.DetailDSAsh DetailAshDataSet
        {
            get { return _dsDetailAsh; }
            set { _dsDetailAsh = value; }
        }

        private String _targetBaitaiCd;

        /// <summary>
        ///
        /// </summary>
        public String TargetBaitaiCd
        {
            get { return _targetBaitaiCd; }
            set { _targetBaitaiCd = value; }
        }

        #endregion プロパティ
    }
}
