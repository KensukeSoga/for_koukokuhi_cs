using System;
using System.Collections.Generic;
using System.Text;

namespace Isid.KKH.Common.KKHUtility
{
    /// <summary>
    /// ������L����ׂ̋��ʃN���X�ł��B
    /// </summary>
    public class KKHUtility
    {
        private static Encoding encoding = Encoding.GetEncoding("Shift_JIS");

        /// <summary>
        /// ������ s ���u�����N���ǂ����𔻒肵�܂��B
        /// </summary>
        /// <param name="s">������</param>
        /// <returns>�u�����N�Ȃ�� true</returns>
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
        /// �I�u�W�F�N�g o ��Null���ǂ����𔻒肵�܂��B
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
        /// object�����S��String�ɕϊ�����
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
        /// �������DateTime�ɕϊ�����
        /// </summary>
        /// <param name="value">YYYY/MM/DD�`��</param>
        /// <returns>���^���ꂽ���t�i�������A�������Ȃ��������n�����ꍇ�A���t��MinValue��Ԃ��j</returns>
        public static DateTime StringCnvDateTime(string value)
        {
            //�X���b�V���̏���
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
        /// �������DateTime�ɕϊ�����
        /// </summary>
        /// <param name="value">YYYY/M/D�`��</param>
        /// <returns>���^���ꂽ���t�i�������A�������Ȃ��������n�����ꍇ�A���t��MinValue��Ԃ��j</returns>
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
        /// ���t�f�[�^�̃t�H�[�}�b�g�ύX(�u/�v ����)
        /// </summary>
        /// <param name="chgString">������</param>
        /// <returns>" / " ��t��</returns>
        public static String DateToStr(string chgString)
        {
            chgString = chgString.Trim().Replace("/", "");
            chgString = chgString.Trim().Replace(" ", "");

            return chgString;
        }

        /// <summary>
        /// intTryParse��out�����Ȃ��ōs���iparse�Ɏ��s�����ꍇ�ɂ�0��Ԃ��B�l��0�ł�0��Ԃ��j
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
        /// longTryParse��out�����Ȃ��ōs���iparse�Ɏ��s�����ꍇ�ɂ�0��Ԃ��B�l��0�ł�0��Ԃ��j
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
        /// decimalTryParse��out�����Ȃ��ōs���iparse�Ɏ��s�����ꍇ�ɂ�0��Ԃ��B�l��0�ł�0��Ԃ��j 
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
        /// doubleTryParse��out�����Ȃ��ōs���iparse�Ɏ��s�����ꍇ�ɂ�0��Ԃ��B�l��0�ł�0��Ԃ��j 
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
        /// ���l�`�F�b�N 
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
        /// �w�肵��������̃o�C�g�����擾���܂� 
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
        /// �֑������폜 
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
        /// ���s�A�^�u�ŋ�؂����l���擾 
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
                // �P��̋󕶎����R�s�[�����ꍇ�͈Ӑ}���Ȃ���������邽�ߋ�̃A�C�e����ǉ�

                pastDic.Add("0,0", String.Empty);
            }

            return pastDic;
        }

        //add sta 2016/05/31 takahashi
        /// <summary>
        /// �t�H���_�����݂��Ȃ��ꍇ�Ɏw�肳�ꂽ�t�H���_���쐬����B
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void SafeCreateDirectory(string path)
        {
            //��̏ꍇ�̓X���[
            if (path != string.Empty)
            {
                //�p�X�����݂��Ȃ��ꍇ�̂ݍ쐬����.
                if (!System.IO.Directory.Exists(path))
                {
                    //�f�B���N�g���쐬.
                    System.IO.Directory.CreateDirectory(path);
                }
            }

        }
        //add end
    }
}
