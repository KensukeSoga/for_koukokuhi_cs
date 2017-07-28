using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Lion.Schema;

namespace Isid.KKH.Lion.ProcessController.Report.Parser
{
    //TODO FD出力の名称は廃止となるため、名称が確定し次第修正する事 
    /// <summary>
    /// ライオンFD出力データ検索サービスパーサ 
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
    ///       <description>2012/02/13</description>
    ///       <description>JSE H.Sasaki</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    class FindFDLionByCondParseResult
    {
        #region プロパティ

        /// <summary>
        /// 広告費明細入力データセット 
        /// </summary>
        private FDDSLion _dsFDLion;

        /// <summary>
        /// 広告費明細入力データセットを取得または設定する 
        /// </summary>
        public FDDSLion dsFDLion
        {
            get { return _dsFDLion; }
            set { _dsFDLion = value; }
        }

        #endregion プロパティ
    }

}
