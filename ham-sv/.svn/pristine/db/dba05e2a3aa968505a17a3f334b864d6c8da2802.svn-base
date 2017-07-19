package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HM請求書(見積案件)(制作)検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMBillItemCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** コードタイプ */
    private String _codeType = null;
    /** フェイズ */
    private BigDecimal _phase = BigDecimal.valueOf(0);
    /** 年月 */
    private String _yearMonth = null;
    /** 種別判断フラグ */
    private String _estimateClass = null;
    /** 見積案件管理NO */
    private BigDecimal _estSeqNo = null;

    /**
     * コードタイプを取得する
     * @return String コードタイプ
     */
    public String getCodeType() {
        return _codeType;
    }

    /**
     * コードタイプを設定する
     * @param val String コードタイプ
     */
    public void setCodeType(String val) {
        _codeType = val;
    }

    /**
     * フェイズを取得する
     * @return BigDecimal フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     * @param val BigDecimal フェイズ
     */
    public void setPhase(BigDecimal val) {
        _phase = val;
    }

    /**
     * 年月を取得する
     * @return String 年月
     */
    public String getYearMonth() {
        return _yearMonth;
    }

    /**
     * 年月を設定する
     * @param val String 年月
     */
    public void setYearMonth(String val) {
        _yearMonth = val;
    }

    /**
     * 見積種別を取得する
     * @return String 見積種別フラグ
     */
    public String getEstimateClass() {
        return _estimateClass;
    }

    /**
     * 見積種別フラグを設定する
     * @param val String 見積種別フラグ
     */
    public void setEstimateClass(String val) {
        _estimateClass = val;
    }

    /**
     * 見積案件管理NOを取得する
     * @return BigDecimal 見積案件管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstSeqNo() {
        return _estSeqNo;
    }

    /**
     * 見積案件管理NOを設定する
     * @param val BigDecimal 見積案件管理NO
     */
    public void setEstSeqNo(BigDecimal val) {
        _estSeqNo = val;
    }

}
