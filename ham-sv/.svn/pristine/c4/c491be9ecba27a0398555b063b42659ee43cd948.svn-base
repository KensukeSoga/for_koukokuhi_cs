package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 見積案件/見積明細取得検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/11 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindEstItemDtlCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェイズ */
    private BigDecimal _phase = BigDecimal.valueOf(0);

    /** 年月 */
    private String _yearMonth = null;

    /** 見積種別 */
    private String _estimateClass = null;


    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     *
     * @param phase フェイズ
     */
    public void setPhase(BigDecimal phase) {
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
     * 見積種別を取得する
     *
     * @return 見積種別
     */
    public String getEstimateClass() {
        return _estimateClass;
    }

    /**
     * 見積種別を設定する
     *
     * @param estimateClass 見積種別
     */
    public void setEstimateClass(String estimateClass) {
        _estimateClass = estimateClass;
    }
}
