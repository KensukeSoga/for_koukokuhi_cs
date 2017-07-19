package jp.co.isid.ham.util;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.model.DummyNull;

/**
 * <P>
 * 日付に関するユーティリティクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2011/01/07 ISID-IT K.Nukita)<BR>
 * ・追加(2012//06/07 JSE K.Tamura) formatのパターンの汎用化<BR>
 * ・請求業務変更対応(2015/08/31 HLC S.Fujimoto)<BR>
 * ・請求業務変更不具合対応(2016/03/16 HLC K.Soga)<BR>
 * </P>
 * @author ISID-IT K.Nukita
 */
public class DateUtil {

    /**
     * String→Date型変換処理
     *
     * @param strDate ８桁の日付文字列(YYYYMMDD)
     * @return Date 日付
     */
    public static Date toDate(String dateString) {
        try {
            SimpleDateFormat format = new SimpleDateFormat("yyyyMMdd");
            return format.parse(dateString);
        } catch (ParseException e) {
            return null;
        }
    }

    /**
     * String→Date型変換処理(汎用化)
     *
     * @param strDate 時間文字列
     * @param pattern 形式
     * @return Date
     * @author K.Tamura
     */
    public static Date toDateGeneral(String dateString, String pattern) {
        try {
            SimpleDateFormat format = new SimpleDateFormat(pattern);
            return format.parse(dateString);
        } catch (ParseException e) {
            return null;
        }
    }

    /**
     * Date→String型変換処理
     *
     * @param date 日付
     * @return String ８桁の日付文字列(YYYYMMDD)
     */
    public static String toString(Date date) {
        SimpleDateFormat format = new SimpleDateFormat("yyyyMMdd");
        return format.format(date);
    }

    /**
     * Date→String型変換処理(汎用化)
     *
     * @param date 時間
     * @param pattern 形式
     * @return String 時間文字列
     * @author K.Tamura
     */
    public static String toStringGeneral(Date date, String pattern) {
        SimpleDateFormat format = new SimpleDateFormat(pattern);
        return format.format(date);
    }


    /**
     * 日付に指定された日数を加算します
     *
     * @param dateString 日付
     * @param count 加算する日数
     * @return
     */
    public static String addDate(String dateString ,int count) {

        Date date = toDate(dateString);

        Calendar cal = Calendar.getInstance();
        cal.setTime(date);
        cal.add(Calendar.DATE, count);

        return toString(cal.getTime());
    }

    /** 2016/04/12 HDX対応 HLC K.Soga ADD Start */
    /**
     * 年に指定された年数を加算します
     *
     * @param yearString 年
     * @param count 加算する年数
     * @return
     */
    public static String addYear(String yearString ,int count) {

        Date date = toDate(yearString);

        Calendar cal = Calendar.getInstance();
        cal.setTime(date);
        cal.add(Calendar.YEAR, count);

        return toString(cal.getTime());
    }
    /** 2016/04/12 HDX対応 HLC K.Soga ADD End */

    /**
     * システム日付を指定のフォーマットで戻す<br>
     * 【凡例】<br>
     *   yyyy：西暦4桁<br>
     *   MM：月2桁<br>
     *   dd：日2桁<br>
     *   HH：時(24時間表記)<br>
     *   hh：時(12時間表記)<br>
     *   mm：分2桁<br>
     *   ss：秒2桁<br>
     *   SSS：ミリ秒3桁<br>
     *
     * @param dateString String 日付
     * @param targetFormat String 出力フォーマット (例．例１："yyyy/MM/dd"、例２："HH:mm"、例３："yyyy/MM/dd HH:mm:ss.SSS")
     * @return String 変換後文字列 (例１："2007/08/05"、例２："15:30"、例３："2008/03/22 15:24:10.876")
     */
    public static String getFormatStringDate(String dateString, String targetFormat) {
        Date date = toDate(dateString);
        return new SimpleDateFormat(targetFormat).format(date);
    }

    /**
     * 期間From(yyyyMMdd)～期間To(yyyyMMdd)までの年のリストを取得します
     *
     * @param termFrom String 期間From
     * @param termTo String 期間To
     * @return List<String> 年のリスト
     */
    public static List<String> getYearList(String termFrom, String termTo) {

        Date dateFrom = toDate(termFrom);
        Date dateTo = toDate(termTo);
        Calendar calFrom = Calendar.getInstance();
        Calendar calTo = Calendar.getInstance();

        calFrom.setTime(dateFrom);
        calTo.setTime(dateTo);

        List<String> yearList = new ArrayList<String>();

        while (calFrom.get(Calendar.YEAR) <= calTo.get(Calendar.YEAR)) {
            yearList.add(String.valueOf(calFrom.get(Calendar.YEAR)));
            calFrom.add(Calendar.YEAR, 1);
        }

        return yearList;
    }

    /**
     * 期首取得
     *
     * @param eigyoBi ホスト営業日
     * @return 期首
     */
    public static String getTermBegin(String eigyoBi) {

        int year = Integer.parseInt(eigyoBi.substring(0, 4));
        int month = Integer.parseInt(eigyoBi.substring(4, 6));

        if (month >= 1 && month <= 3) {
            year = year - 1;
        }
        return Integer.toString(year) + "04";
    }

    /**
     * 期末取得
     *
     * @param eigyoBi ホスト営業日
     * @return 期末
     */
    public static String getTermEnd(String eigyoBi) {

        int year = Integer.parseInt(eigyoBi.substring(0, 4));
        int month = Integer.parseInt(eigyoBi.substring(4, 6));

        if (month >= 4 && month <= 12) {
            year = year + 1;
        }
        return Integer.toString(year) + "03";
    }

    /**
     * 指定したパラメータを日付型に変換します
     * @param val 対象オブジェクト
     * @return 日時、またはnull
     */
    public static Date toDateForNull(Object val) {

        Date dt = null;

        try {
            if (!(val instanceof DummyNull)) {
                dt = (Date)val;
            }
        } catch(Exception ex) {
            dt = null;
        }

        return dt;
    }

    /**
     * 指定した2つの日付の差日数を取得します
     * @param from
     * @param to
     * @return
     */
    public static long getTermDays(Date from, Date to) {

        long days = 0;
        long difference = 0;

        if (from.compareTo(to) <= 0) {
            difference = to.getTime() - from.getTime();
        } else {
            difference = from.getTime() - to.getTime();
        }
        days = difference / 1000 / 60 / 60 / 24;

        return days;
    }

    /** 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD Start */
    /**
     * 期取得処理
     * @param yearMonth 年月(YYYY/MM)
     * @return 期
     */
    public static String getTerm(String yearMonth) {

        //年月の月を取得
        int month = Integer.valueOf(yearMonth.substring(5, 7));

        if ((4 <= month) && (month <= 9)) {
            // 上期
            return HAMConstants.TERM_FIRST;
        } else {
            // 下期
            return HAMConstants.TERM_SECOND;
        }
    }
    /** 2015/08/31 請求業務変更対応 HLC S.Fujimoto ADD End */

    /** 2016/03/15 請求業務変更不具合対応 HLC K.Soga ADD Start */
    /**
     * 前月算出
     * @param yearMonth 年月(YYYY/MM)
     * @return 期
     */
    public static String getPrevMonth(String yearMonth) {
        String year = yearMonth.substring(0, 4);
        String month = yearMonth.substring(5, 7);

        //1月の場合.
        if (Integer.parseInt(month) == 1) {
            //前年12月にセット
            return yearMonth = String.format("%04d", Integer.parseInt(year) - 1) + String.format("%02d", 12);
        } else {
            //前月にセット.
            return yearMonth = year + String.format("%02d", Integer.parseInt(month) - 1);
        }
    }
    /** 2016/03/15 請求業務変更不具合対応 HLC K.Soga ADD End */
}