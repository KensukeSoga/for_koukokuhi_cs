using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Acom.Schema;

namespace Isid.KKH.Acom.ProcessController.InPut.Parser
{
    /// <summary>
    /// アコム発注取込情報検索パース結果
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
    ///       <description>2011/11/10</description>
    ///       <description>HLC K.Fujisaki</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class FindHikByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// アコム発注取込情報データセットです。 
        /// </summary>
        private InPutHik _dsHik;

        /// <summary>
        /// アコム発注取込情報データセットを取得または設定します。 
        /// </summary>
        public InPutHik HikDataSet
        {
            get { return _dsHik; }
            set { _dsHik = value; }
        }

        #endregion プロパティ
    }
}
