package jp.co.isid.ham.billing.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 変更確認検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/13 HLC H.Watabe)<BR>
 * </P>
 * @author H.watabe
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindAfterUptakeCheckCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * フェイズ
     */
    private int _phase = 0;

    /**
     * 年月
     */
    private String _yearMonth = null;

    /**
     * 種別判断フラグ
     */
    private String _classdiv = null;

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    public int getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     *
     * @param phase フェイズ
     */
    public void setPhase(int phase) {
        _phase = phase;
    }

    /**
     * 年月を取得する
     *
     * @return 年月
     */
    public String getYearMonth() {
        return _yearMonth;
    }

    /**
     * 年月を設定する
     *
     * @param yearMonth 年月
     */
    public void setYearMonth(String yearMonth) {
        _yearMonth = yearMonth;
    }

    /**
     * 種別判断フラグを取得する
     *
     * @return 種別判断フラグ
     */
    public String getClassDiv() {
        return _classdiv;
    }

    /**
     * 種別判断フラグを設定する
     *
     * @param classdiv 種別判断フラグ
     */
    public void setClassDiv(String classdiv) {
        _classdiv = classdiv;
    }
}
