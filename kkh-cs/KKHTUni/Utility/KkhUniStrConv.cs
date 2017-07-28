using System;
using System.Collections.Generic;
using System.Text;
using Isid.KKH.Common.KKHUtility;

namespace Isid.KKH.Uni.Utility
{
    /// <summary>
    /// ユニチャーム文字列変換クラス
    /// </summary>
    class KkhUniStrConv
    {
        ///// <summary>
        ///// 文字列を半角に変換する。        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static String toNarrow(String value)
        //{
        //    // ****** マッピング表定義 ******

        //    // ※indexは必ず合わせる事。
        //    // 全角文字列定義
        //    String[] zen = new String[]{"ア","イ","ウ","エ","オ",
        //                                "カ","キ","ク","ケ","コ",
        //                                "サ","シ","ス","セ","ソ",
        //                                "タ","チ","ツ","テ","ト",
        //                                "ナ","ニ","ヌ","ネ","ノ",
        //                                "ハ","ヒ","フ","ヘ","ホ",
        //                                "マ","ミ","ム","メ","モ",
        //                                "ラ","リ","ル","レ","ロ",
        //                                "ヤ","ユ","ヨ",
        //                                "ワ","ヲ","ン",
        //                                "ガ","ギ","グ","ゲ","ゴ",
        //                                "ザ","ジ","ズ","ゼ","ゾ",
        //                                "ダ","ヂ","ヅ","デ","ド",
        //                                "バ","ビ","ブ","ベ","ボ",
        //                                "パ","ピ","プ","ペ","ポ",
        //                                "ッ",
        //                                "ァ","ィ","ゥ","ェ","ォ",
        //                                "ャ","ュ","ョ",
        //                                "Ａ","Ｂ","Ｃ","Ｄ","Ｅ",
        //                                "Ｆ","Ｇ","Ｈ","Ｉ","Ｊ",
        //                                "Ｋ","Ｌ","Ｍ","Ｎ","Ｏ",
        //                                "Ｐ","Ｑ","Ｒ","Ｓ","Ｔ",
        //                                "Ｕ","Ｖ","Ｗ","Ｘ","Ｙ",
        //                                "Ｚ",
        //                                "ａ","ｂ","ｃ","ｄ","ｅ",
        //                                "ｆ","ｇ","ｈ","ｉ","ｊ",
        //                                "ｋ","ｌ","ｍ","ｎ","ｏ",
        //                                "ｐ","ｑ","ｒ","ｓ","ｔ",
        //                                "ｕ","ｖ","ｗ","ｘ","ｙ",
        //                                "ｚ",
        //                                "ー","＃","＄","％","＆",
        //                                "’","！","？","；","，",
        //                                "：","＜","＞","／","＊",
        //                                "（","）","＝","～","＠",
        //                                "－","＋","｛","｝",
        //                                "１","２","３","４","５",
        //                                "６","７","８","９","０"};

        //    // 半角文字列定義
        //    String[] han = new String[]{"ｱ","ｲ","ｳ","ｴ","ｵ",
        //                                "ｶ","ｷ","ｸ","ｹ","ｺ",
        //                                "ｻ","ｼ","ｽ","ｾ","ｿ",
        //                                "ﾀ","ﾁ","ﾂ","ﾃ","ﾄ",
        //                                "ﾅ","ﾆ","ﾇ","ﾈ","ﾉ",
        //                                "ﾊ","ﾋ","ﾌ","ﾍ","ﾎ",
        //                                "ﾏ","ﾐ","ﾑ","ﾒ","ﾓ",
        //                                "ﾗ","ﾘ","ﾙ","ﾚ","ﾛ",
        //                                "ﾔ","ﾕ","ﾖ","ﾜ","ｦ",
        //                                "ﾝ",
        //                                "ｶﾞ","ｷﾞ","ｸﾞ","ｹﾞ","ｺﾞ",
        //                                "ｻﾞ","ｼﾞ","ｽﾞ","ｾﾞ","ｿﾞ",
        //                                "ﾀﾞ","ﾁﾞ","ﾂﾞ","ﾃﾞ","ﾄﾞ",
        //                                "ﾊﾞ","ﾋﾞ","ﾌﾞ","ﾍﾞ","ﾎﾞ",
        //                                "ﾊﾟ","ﾋﾟ","ﾌﾟ","ﾍﾟ","ﾎﾟ",
        //                                "ｯ",
        //                                "ｧ","ｨ","ｩ","ｪ","ｫ",
        //                                "ｬ","ｭ","ｮ",
        //                                "A","B","C","D","E",
        //                                "F","G","H","I","J",
        //                                "K","L","M","N","O",
        //                                "P","Q","R","S","T",
        //                                "U","V","W","X","Y",
        //                                "Z",
        //                                "a","b","c","d","e",
        //                                "f","g","h","i","j",
        //                                "k","l","m","n","o",
        //                                "p","q","r","s","t",
        //                                "u","v","w","x","y",
        //                                "z",
        //                                "ｰ","#","$","%","&",
        //                                "'","!","?",";",",",
        //                                ":","<",">","/","*",
        //                                "(",")","=","~","@",
        //                                "-","+","{","}",
        //                                "1","2","3","4","5",
        //                                "6","7","8","9","0"};
        //    // ****** **************** ******

        //    // 置換
        //    for(int i = 0; i < zen.Length; i++)
        //    {
        //        value = value.Replace(zen[i], han[i]);
        //    }

        //    // 返却
       
        //    return value;

        //}

        /// <summary>
        /// 放送日「00000･･･00000」形式(31桁)を「X日、XX日･･･」形式に変換を行う.
        /// ex)0100100の場合、2個目と5個目が"1"なので2日、5日となる。 
        /// </summary>
        public static String GetHosoBi(String hosoBiArray)
        {
            string hosoBi = String.Empty;

            //空なら処理しない.
            if (string.IsNullOrEmpty(hosoBiArray))
            {
                return hosoBi;
            }

            //長さが31ではない場合、処理しない。.
            if (hosoBiArray.Length != 31)
            {
                return hosoBi;
            }

            //日にち用カウンター 
            int dayCnt = 1;

            //31回(日)分.
            for (int i = 0; i < hosoBiArray.Length; i++)
            {
                //一文字ずつ取得する。 
                string _hosoBi = hosoBiArray.Substring(i, 1);

                //0か1か判定する。 
                if (_hosoBi == "1")
                {
                    //1の場合、末尾に"日"を付ける。
                    if( String.IsNullOrEmpty(hosoBi))
                    {
                        hosoBi += dayCnt.ToString() + "日";
                    }
                    else
                    {
                        // 複数の日付を設定する場合は前に「、」を付ける
                        hosoBi += "、" + dayCnt.ToString() + "日";
                    }
                }
                //翌日
                dayCnt++;
            }

            //戻り値.
            return hosoBi;
        }

        /// <summary>
        /// 放送日「X日、XX日･･･」を「00000･･･00000」形式(31桁)形式に変換を行う.
        /// </summary>
        public static String GetHosoBiArray(String hosoBi)
        {
            String hosoBiArray = String.Empty;

            // 空の場合は全て"0"
            if (String.Equals(hosoBi, ""))
            {
                //31日分まわす.
                for (int i = 0; i < 31; i++)
                {
                    hosoBiArray += "0";
                }
            }
            else
            {
                // 「日」を削除後に区切り文字「、」で分割する
                String[] _hosoBiArray = hosoBi.Replace( "日", "" ).Split('、');

                int index = 0;

                for (int i = 0; i < 31; i++)
                {
                    // 分割した文字を最後まで設定していない
                    if( index < _hosoBiArray.Length )
                    {
                        if (( KKHUtility.IntParse(_hosoBiArray[index]) - 1 ) == i)
                        {
                            hosoBiArray += "1";
                            index++;
                        }
                        else
                        {
                            hosoBiArray += "0";
                        }
                    }
                    else
                    {
                        hosoBiArray += "0";
                    }
                }
            }

            //戻り値.
            return hosoBiArray;
        }
    }
}
