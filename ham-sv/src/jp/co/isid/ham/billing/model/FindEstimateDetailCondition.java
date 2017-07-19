package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 見積明細取得検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/14 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindEstimateDetailCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェイズ */
    private BigDecimal _phase = BigDecimal.valueOf(0);

    /** 年月 */
    private String _yearMonth = null;

    /** HC部門コード */
    private String _hcBumonCd = null;

    /** 見積案件管理NO */
    private BigDecimal _estSeqNo = null;


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
     * 見積案件管理NOを取得する
     *
     * @return 見積案件管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstSeqNo() {
        return _estSeqNo;
    }

    /**
     * 見積案件管理NOを設定する
     *
     * @param estSeqNo 見積案件管理NO
     */
    public void setEstSeqNo(BigDecimal estSeqNo) {
        this._estSeqNo = estSeqNo;
    }

    /**
     * HC部門コードを取得する
     *
     * @return HC部門コード
     */
    public String getHcBumonCd() {
        return _hcBumonCd;
    }

    /**
     * HC部門コードを設定する
     *
     * @param hcBumonCd HC部門コード
     */
    public void setHcBumonCd(String hcBumonCd) {
        _hcBumonCd = hcBumonCd;
    }
}
