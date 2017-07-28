using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Common.KKHUtility.Constants
{

    /// <summary>
    /// 機能定数 
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
    ///       <description>2011/01/21</description>
    ///       <description>ISID-IT Y.Sanuki</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class Function
    {
        #region インスタンス変数

        /// <summary>
        /// Top
        /// </summary>
        public static readonly Function TOP = new Function("01", "Top");

        /// <summary>
        /// Planning
        /// </summary>
        public static readonly Function MENU = new Function("02", "Menu");

        /// <summary>
        /// Planning Result
        /// </summary>
        public static readonly Function PLANNING_RESULT = new Function("03", "Planning");

        /// <summary>
        /// Plan Data Read
        /// </summary>
        public static readonly Function PLAN_DATA_READ = new Function("04", "Data Read");

        /// <summary>
        /// Plan Data Save
        /// </summary>
        public static readonly Function PLAN_DATA_SAVE = new Function("05", "Data Save");

        /// <summary>
        /// Review
        /// </summary>
        public static readonly Function REVIEW = new Function("06", "Review");

        /// <summary>
        /// Review Result
        /// </summary>
        public static readonly Function REVIEW_RESULT = new Function("07", "Review");

        /// <summary>
        /// Product Awareness × Trial
        /// </summary>
        public static readonly Function PRODUCT_AWARENESS_TRIAL = new Function("08", "Product Awareness × Trial");

        /// <summary>
        /// コード値
        /// </summary>
        private string _value;

        /// <summary>
        /// 表示名 
        /// </summary>
        private string _name;

        #endregion インスタンス変数

        #region コンストラクタ

        /// <summary>
        /// privateコンストラクタです。 
        /// </summary>
        /// <param name="value">コード値</param>
        /// <param name="name">表示名</param>
        private Function(string value, string name)
        {
            _value = value;
            _name = name;
        }

        #endregion

        #region パブリックメソッド

        /// <summary>
        /// コード値を取得します。 
        /// </summary>
        /// <returns>コード値</returns>
        public string Value()
        {
            return _value;
        }

        /// <summary>
        /// 表示名を取得します。 
        /// </summary>
        /// <returns>表示名</returns>
        public override string ToString()
        {
            return _name;
        }

        #endregion パブリックメソッド
    }
}
