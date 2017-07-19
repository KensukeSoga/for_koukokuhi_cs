package jp.co.isid.ham.util;



/**
 * <p>
 * 文字列に関するユーティリティクラス
 * </p>
 * <p>
 * <b>修正履歴</b><br />
 * ・新規作成(2006/09/22 WT H.Ikeda)<br />
 * </p>
 *
 * @author WT H.Ikeda
 */
public final class StringUtil {

    /**
     * ユーティリティクラスのためインスタンス化を禁止します
     */
    private StringUtil() {
    }

    /**
     * 文字列 s がブランクかどうかを判定します
     * ブランクの定義は下記の通りです
     * (1) s が null である
     * (2) s を trim した文字列の長さが 0 である
     *
     * @param s 文字列
     * @return ブランクならば true
     */
    public static boolean isBlank(String s) {
        if (s == null) {
            return true;
        } else {
            return s.trim().length() == 0;
        }
    }

    /**
     * 文字列をトリムします
     * ・nullの場合は空文字を返却します
     *
     * @param s 文字列
     * @return トリムした文字列
     */
    public static String trim(String s) {
        if (s == null) {
            return "";
        } else {
            return s.trim();
        }
    }

    /**
     * 文字列を結合します
     * @param separator 結合文字列
     * @param value 文字配列
     * @return 結合した文字列
     */
    public static String join(String separator, String[] value) {
        StringBuffer ret = new StringBuffer();

        for (String s : value) {
            if (ret.length() > 0) {
                ret.append(separator);
            }
            ret.append(s);
        }

        return ret.toString();
    }

    /**
     * 値がNullでもエラーにならないようにObject型のtoString()を実行します
     * @param obj
     * @return
     */
    public static String toString(Object obj) {
        if (obj == null) {
            return null;
        } else {
            return obj.toString();
        }
    }

//    /**
//     * サニタイジング処理
//     *
//     * @param str 変換する文字列
//     * @return エスケープした形で文字列を返します
//     * （例）
//     * IN    A_'%DDD
//     * OUT   'A#_''#%DDD'
//     */
//    public static String sanitizing(String str) {
//
//        List<String> lst = KKHParameter.getInstance().getNGStringList();
//
//        String result = new String();
//        char c = "'".charAt(0);
//        char escape = "#".charAt(0);
//        char chrChk;
//        for (int j = 0 ; j < str.length(); j++) {
//            String sani = "";
//            char chr = str.charAt(j);
//            for (int i = 0; i < lst.size(); i++) {
//                chrChk = lst.get(i).charAt(0);
//               if (chr == chrChk ) {
//                   if (chr == c) {
//                       sani = c + "";
//                       break;
//                   } else {
//                       sani = escape+ "";
//                       break;
//                   }
//               } else if (chr == escape) {
//                   sani = escape + "";
//                   break;
//               }
//            }
//            result = result + sani + chr;
//        }
//        return  result;
//    }
//
//    /**
//     * サニタイジング処理
//     *
//     * @param str 変換する文字列
//     * @return エスケープした形で文字列を返します
//     * （例）
//     * IN    A_'%DDD
//     * OUT   '%A#_''#%DDD%' ESCAPE '#'
//     */
//    public static String sanitizingEx(String str) {
//        return  "'%" + StringUtil.sanitizing(str) + "%' ESCAPE '#'";
//    }


}
