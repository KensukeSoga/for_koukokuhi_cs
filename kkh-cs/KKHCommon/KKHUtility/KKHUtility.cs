using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Common.KKHUtility
{
    /// <summary>
    /// 次世代広告費明細の共通クラスです。
    /// </summary>
    public class KKHUtility
    {
        private static Encoding encoding = Encoding.GetEncoding("Shift_JIS");

        /// <summary>
        /// 文字列 s がブランクかどうかを判定します。
        /// </summary>
        /// <param name="s">文字列</param>
        /// <returns>ブランクならば true</returns>
        public static bool IsBlank(string s)
        {
            if (s == null)
            {
                return true;
            }
            else
            {
                return s.Trim().Length == 0;
            }
        }

        /// <summary>
        /// オブジェクト o がNullかどうかを判定します。
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool IsNull(object o)
        {
            if (o == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// objectを安全にStringに変換する
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToString(object obj)
        {
            string result = string.Empty;
            if (obj != null)
            {
                result = obj.ToString();
            }
            return result;
        }

        /// <summary>
        /// 文字列をDateTimeに変換する
        /// </summary>
        /// <param name="value">YYYY/MM/DD形式</param>
        /// <returns>成型された日付（ただし、正しくない文字列を渡した場合、日付のMinValueを返す）</returns>
        public static DateTime StringCnvDateTime(string value)
        {
            //スラッシュの除去
            string wk = DateToStr(value);

            if (string.IsNullOrEmpty(wk))
            {
                return DateTime.MinValue;
            }
            if (wk.Length < 8)
            {
                return DateTime.MinValue;
            }

            int year = IntParse(wk.Substring(0, 4));
            int month = IntParse(wk.Substring(4, 2));
            int day = IntParse(wk.Substring(6, 2));

            return new DateTime(year, month, day);

        }

        /// <summary>
        /// 文字列をDateTimeに変換する
        /// </summary>
        /// <param name="value">YYYY/M/D形式</param>
        /// <returns>成型された日付（ただし、正しくない文字列を渡した場合、日付のMinValueを返す）</returns>
        public static DateTime StringCnvDateTime2(string value)
        {
            try
            {
                return DateTime.Parse(value);
            }
            catch
            {
                return DateTime.MinValue;
            }

        }



        /// <summary>
        /// 日付データのフォーマット変更(「/」 除去)
        /// </summary>
        /// <param name="chgString">文字列</param>
        /// <returns>" / " を付加</returns>
        public static String DateToStr(string chgString)
        {
            chgString = chgString.Trim().Replace("/", "");
            chgString = chgString.Trim().Replace(" ", "");

            return chgString;
        }

        /// <summary>
        /// intTryParseをout引数なしで行う（parseに失敗した場合には0を返す。値が0でも0を返す）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int IntParse(string value)
        {
            int resultValue;
            int.TryParse(value, out resultValue);
            return resultValue;
        }

        /// <summary>
        /// longTryParseをout引数なしで行う（parseに失敗した場合には0を返す。値が0でも0を返す）
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long LongParse(string value)
        {
            long resultValue;
            long.TryParse(value, out resultValue);
            return resultValue;
        }

        /// <summary>
        /// decimalTryParseをout引数なしで行う（parseに失敗した場合には0を返す。値が0でも0を返す） 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal DecParse(string value)
        {
            decimal resultValue;
            decimal.TryParse(value, out resultValue);
            return resultValue;
        }

        /// <summary>
        /// doubleTryParseをout引数なしで行う（parseに失敗した場合には0を返す。値が0でも0を返す） 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double DouParse(string value)
        {
            double resultValue;
            double.TryParse(value, out resultValue);
            return resultValue;
        }


        /// <summary>
        /// 数値チェック 
        /// </summary>
        /// <param name="stTarget"></param>
        /// <returns></returns>
        public static bool IsNumeric(string stTarget)
        {
            double dNullable;

            return double.TryParse(
                stTarget,
                System.Globalization.NumberStyles.Any,
                null,
                out dNullable
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strDate"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool IsDate(string strDate, string format)
        {
            DateTime date;
            return DateTime.TryParseExact(strDate, format, System.Globalization.DateTimeFormatInfo.InvariantInfo,System.Globalization.DateTimeStyles.None,out date);
        }

        /// <summary>
        /// 指定した文字列のバイト数を取得します 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetByteCount(string str)
        {
            return encoding.GetByteCount(str);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="str"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string GetByteString(string str, int count)
        {
            //return encoding.GetString(encoding.GetBytes(str), 0, count);
            string s = str;
            while (GetByteCount(s) > count)
            {
                s = s.Remove(s.Length - 1);
            }
            return s;
        }


        /// <summary>
        /// 禁則文字削除 
        /// </summary>
        /// <param name="oldStr"></param>
        /// <returns></returns>
        public static string RemoveProhibitionChar(string oldStr)
        {
            string newStr = oldStr;

            string[] wrappChar = new string[] { "'" };
            foreach (string repStr in wrappChar)
            {
                newStr = newStr.Replace(repStr, "");
            }

            return newStr;
        }

        /// <summary>
        /// 改行、タブで区切った値を取得 
        /// </summary>
        /// <param name="val"></param>
        /// <returns>pastDic</returns>
        public static Dictionary<string, string> getPastValueDic(string val)
        {
            Dictionary<string, string> pastDic = new Dictionary<string, string>();

            string[] rowPastArr = val.Split('\n');

            for (int rowCnt = 0; rowCnt < rowPastArr.Length; rowCnt++)
            {
                string rowVal = rowPastArr[rowCnt].Replace("\r", string.Empty);

                if (string.IsNullOrEmpty(rowVal))
                {
                    continue;
                }

                string[] colPastArr = rowVal.Split('\t');
                for (int colCnt = 0; colCnt < colPastArr.Length; colCnt++)
                {
                    string key = string.Join(",", new string[] { colCnt.ToString(), rowCnt.ToString() });
                    pastDic.Add(key, colPastArr[colCnt]);
                }
            }

            if (pastDic.Count == 0)
            {
                // 単一の空文字をコピーした場合は意図しない動作をするため空のアイテムを追加

                pastDic.Add("0,0", String.Empty);
            }

            return pastDic;
        }

        //add sta 2016/05/31 takahashi
        /// <summary>
        /// フォルダが存在しない場合に指定されたフォルダを作成する。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void SafeCreateDirectory(string path)
        {
            //空の場合はスルー
            if (path != string.Empty)
            {
                //パスが存在しない場合のみ作成する.
                if (!System.IO.Directory.Exists(path))
                {
                    //ディレクトリ作成.
                    System.IO.Directory.CreateDirectory(path);
                }
            }

        }
        //add end
    }
}
