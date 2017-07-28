using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Common.KKHView.Common
{
    /// <summary>
    /// 文字列チェック
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
    ///       <description>2011/03/03</description>
    ///       <description>HLC K.Honma</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public class StringChecker
    {
        /// <summary>
        /// 
        /// </summary>
        static Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
        //文字列全角チェック 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ZenkakuCheck(string str)
        {
            int num = sjisEnc.GetByteCount(str);
            return num != str.Length;
        }

    }

}
