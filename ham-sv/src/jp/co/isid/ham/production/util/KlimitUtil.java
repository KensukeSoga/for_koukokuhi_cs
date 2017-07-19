package jp.co.isid.ham.production.util;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.util.DateUtil;

/**
 * <P>
 * 権利使用期限を判定、生成する為のクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/04/18 HAMチーム)<BR>
 * </P>
 *
 * @author
 */
public class KlimitUtil {

    private static final int MAX_LENGTH = 200;

    /** キー毎に期間のリストを格納する変数 */
    private Map<String, List<Period>> _allPeriodMap = new HashMap<String, List<Period>>();

    /** 権利使用期限 */
    private String _klimit = null;
    /** 最小日付 */
    private Date _minDate = null;
    /** 期間の数 */
    private int _termCount = 0;

    /**
     * コンストラクタ
     */
    public KlimitUtil() {
    }

    /**
     * 権利使用期限クリアする
     */
    public void clear() {
        _allPeriodMap = new HashMap<String, List<Period>>();
        _klimit = null;
        _minDate = null;
        _termCount = 0;
    }

    /**
     * 指定した値から集計キーを取得する
     *
     * @return
     */
    public String getKey(String ctrtKbn, String names, String music) {
        String key = "";

        key = ctrtKbn + "|" + names + "|" + music;

        return key;
    }

    /**
     * 権利使用期限を判定する際に条件となる日付を追加する
     *
     * @param key
     * @param from
     * @param to
     */
    public void addSpan(String key, Date from, Date to) {
        if (key == null) {
            return;
        }
        if (from == null && to == null) {
            return;
        }
        if (from == null) {
            from = to;
        }
        if (to == null) {
            to = null;
        }
        if (from.compareTo(to) > 0) {
            return;
        }

        List<Period> period = null;
        if (_allPeriodMap.containsKey(key)) {
            period = _allPeriodMap.get(key);
        }
        else {
            period = new ArrayList<Period>();
        }
        period.add(new Period(key, from, to));
        _allPeriodMap.put(key, period);

    }

    /**
     * 生成した権利使用期限を取得する ただし、期間が１つしかない場合は終了日を返す
     *
     * @return
     */
    public String limit() {
        String str = "";
        if (_termCount == 1) {
            str = _klimit.substring(13, _klimit.length());
        }
        else {
            str = resultSpan();
        }
        return str;
    }

    /**
     * 生成した権利使用期限を取得する
     *
     * @return
     */
    public String resultSpan() {
        String str = "";
        if (_klimit.length() > MAX_LENGTH) {
            str = this._klimit.substring(0, MAX_LENGTH);
        }
        else {
            str = this._klimit;
        }
        return str;
    }

    /**
     * 権利使用期限の内、一番最小の日付を取得する
     *
     * @return
     */
    public Date minDate() {
        return this._minDate;
    }

    /**
     * 生成した権利期限に含まれている期間の数
     *
     * @return
     */
    public int termCount() {
        return this._termCount;
    }

    /**
     * 追加した条件を基に権利使用期限を生成、取得する
     *
     * @return
     */
    public void generateKlimit() {
        //********************************************************************************************
        //キー毎に期間のマージ
        //********************************************************************************************
        //キー毎にマージした期間を格納する変数.
        Map<String, List<Period>> mergePeriodMap = new HashMap<String, List<Period>>();
        //キーの数分Loop
        for (List<Period> value : _allPeriodMap.values()) {
            //From順にソートしておく
            Period[] periodArray = value.toArray(new Period[value.size()]);
            Arrays.sort(periodArray, new PeriodCompare());
            List<Period> mergePeriodList = new ArrayList<Period>();
            Period mergePeriod = null;
            //キー毎の期間の数分Loop
            for (int i = 0; i < periodArray.length; i++) {
                if (mergePeriod == null) {
                    //初回はそのままの値を使用(ベースとする)
                    mergePeriod = new Period(periodArray[i]._key, periodArray[i]._from, periodArray[i]._to);
                }
                else {
                    //２回目以降は期間が繋がっていればマージ、繋がっていなければ保持して次の期間のベースとして使用
                    if ((mergePeriod._from.compareTo(periodArray[i]._from) <= 0 && mergePeriod._to.compareTo(periodArray[i]._from) >= 0)
                            || (mergePeriod._from.compareTo(periodArray[i]._to) <= 0 && mergePeriod._to.compareTo(periodArray[i]._to) >= 0)
                            || (periodArray[i]._from.compareTo(mergePeriod._from) <= 0 && periodArray[i]._to.compareTo(mergePeriod._from) >= 0)
                            || (periodArray[i]._from.compareTo(mergePeriod._to) <= 0 && periodArray[i]._to.compareTo(mergePeriod._to) >= 0)) {
                        //期間が重なっている場合
                        if (mergePeriod._from.compareTo(periodArray[i]._from) <= 0) {
                            mergePeriod._from = mergePeriod._from;
                        }
                        else {
                            //現在のFromより比較対象のFromの方が前の場合はそっちを採用
                            mergePeriod._from = periodArray[i]._from;
                        }
                        if (mergePeriod._to.compareTo(periodArray[i]._to) >= 0) {
                            mergePeriod._to = mergePeriod._to;
                        }
                        else {
                            //現在のToより比較対象のToの方が後の場合はそっちを採用
                            mergePeriod._to = periodArray[i]._to;
                        }
                    }
                    else if (mergePeriod._to.compareTo(periodArray[i]._from) < 0 && DateUtil.getTermDays(mergePeriod._to, periodArray[i]._from) == 1) {
                        //期間が重なっていないが連続している場合(現在のToと比較対象のFromが連続する場合)
                        mergePeriod._to = periodArray[i]._to;
                    }
                    else if (mergePeriod._from.compareTo(periodArray[i]._to) > 0 && DateUtil.getTermDays(mergePeriod._to, periodArray[i]._from) == 1) {
                        //期間が重なっていないが連続している場合(現在のFromと比較対象のToが連続する場合)
                        mergePeriod._from = periodArray[i]._from;
                    }
                    else {
                        //期間が繋がっていない場合
                        //マージ後の期間をリストに格納
                        mergePeriodList.add(mergePeriod);
                        mergePeriod = new Period(periodArray[i]._key, periodArray[i]._from, periodArray[i]._to);
                    }
                }
            }
            //マージ後の期間をリストに格納
            mergePeriodList.add(mergePeriod);
            //マージ後の期間リストをキー毎に格納
            mergePeriodMap.put(mergePeriod._key, mergePeriodList);
        }

        //********************************************************************************************
        //別キー間の期間で重複している期間だけを抽出する
        //********************************************************************************************
        List<Period> resPeriodList = null;
        for (List<Period> value : mergePeriodMap.values()) {
            if (resPeriodList == null) {
                resPeriodList = value;
            }
            else {
                if (resPeriodList.size() == 0) {
                    //リストがない場合は重複する期間がなくなったということなので終了する.
                    this._klimit = "";
                    this._minDate = null;
                    this._termCount = 0;
                    return;
                }
                List<Period> newPeriodList = new ArrayList<Period>();
                //現時点の重複期間抽出済みの期間リストをベースにLoopして比較
                for (Period retPeriod : resPeriodList) {
                    for (Period period : value) {
                        if ((retPeriod._from.compareTo(period._from) <= 0 && retPeriod._to.compareTo(period._from) >= 0)
                                || (retPeriod._from.compareTo(period._to) <= 0 && retPeriod._to.compareTo(period._to) >= 0)
                                || (period._from.compareTo(retPeriod._from) <= 0 && period._to.compareTo(retPeriod._from) >= 0)
                                || (period._from.compareTo(retPeriod._to) <= 0 && period._to.compareTo(retPeriod._to) >= 0)) {
                            Date newFrom = null;
                            Date newTo = null;
                            if (retPeriod._from.compareTo(period._from) <= 0) {
                                newFrom = period._from;
                            }
                            else {
                                newFrom = retPeriod._from;
                            }
                            if (retPeriod._to.compareTo(period._to) >= 0) {
                                newTo = period._to;
                            }
                            else {
                                newTo = retPeriod._to;
                            }
                            newPeriodList.add(new Period(null, newFrom, newTo));
                        }
                    }
                }
                //重複期間抽出済み期間リストを更新
                resPeriodList = newPeriodList;
            }
        }
        if (resPeriodList == null || resPeriodList.size() == 0) {
            //リストがない場合は重複する期間がなくなったということなので終了する.
            this._klimit = "";
            this._minDate = null;
            this._termCount = 0;
            return;
        }

        //********************************************************************************************
        //期間を文字列として整形する
        //********************************************************************************************
        StringBuffer klimit = new StringBuffer();
        int termCount = 0;
        Date minDate = null;
        for (Period retPeriod : resPeriodList) {
            if (klimit.length() > 0) {
                klimit.append(", ");
            }
            else {
                minDate = retPeriod._from;
            }
            klimit.append(DateUtil.toStringGeneral(retPeriod._from, "yyyy/MM/dd") + " - " + DateUtil.toStringGeneral(retPeriod._to, "yyyy/MM/dd"));
            termCount++;
        }

        this._klimit = klimit.toString();
        this._minDate = minDate;
        this._termCount = termCount;
    }

    //=========================================================================================================
    /**
     * 期間管理用のクラス(構造体の様に使用)
     *
     * @author
     */
    private class Period {
        public String _key = null;
        public Date _from = null;
        public Date _to = null;

        public Period(String key, Date from, Date to) {
            _key = key;
            if (from == null && to != null) {
                _from = (Date) to.clone();
            }
            else {
                _from = from;
                _to = to;
            }
        }
    }

    /**
     * Periodクラスオブジェクト同士のソート用
     *
     * @author
     */
    private class PeriodCompare implements Comparator<Period> {
        public int compare(Period o1, Period o2) {
            return (o1._from).compareTo(o2._from);
        }

    }
}
