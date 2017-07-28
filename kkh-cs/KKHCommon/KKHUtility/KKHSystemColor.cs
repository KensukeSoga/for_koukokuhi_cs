using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Isid.KKH.Common.KKHUtility
{
    /// <summary>
    /// システムカラー設定    /// <para>
    /// システム上でのカラーを設定します    /// </para>
    /// </summary>
    /// <remarks>
    /// 修正管理    /// <list type="table">
    /// <listheader>
    ///     <description>内容</description>
    ///     <description>日付</description>
    ///     <description>修正者</description>
    /// </listheader>
    /// <item>
    ///    <description>新規作成</description>
    ///    <description>2011/11/14</description>
    ///    <description>ISID Fujisaki</description>
    /// </item>
    /// </list>
    /// </remarks>
    public struct KKHSystemColor
    {
        /// <summary>
        /// Excelアウトプット用のスプレットに設定するセルの色
        /// </summary>
        public struct AcomExcelOutPutSpreadColor
        {
            /// <summary>
            /// ヘッダー背景色
            /// </summary>
            public static Color Header = Color.LightGray;

            /// <summary>
            /// 罫線職
            /// </summary>
            public static Color Border = Color.Black;
        }

        /// <summary>
        /// アコムのフォームの色
        /// </summary>
        public struct AcomFormColor
        {
            /// <summary>
            /// 
            /// </summary>
            public static Color RirekiCngBackColor = Color.Orange;
        }
    }
}
