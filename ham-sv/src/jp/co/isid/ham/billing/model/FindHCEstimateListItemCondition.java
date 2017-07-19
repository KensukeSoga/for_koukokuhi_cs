package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HC見積一覧(見積案件)検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/1/31 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHCEstimateListItemCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * コードタイプ
     */
    private String _codeType = null;

    /**
     * フェイズ
     */
    private BigDecimal _phase = BigDecimal.valueOf(0);

    /**
     * 年月
     */
    private String _yearMonth = null;

    /**
     * 種別判断フラグ
     */
    private String _estimateClass = null;

    /**
     * 見積案件管理NO
     */
    private BigDecimal _estSeqNo = null;

    /**
     * HAM ID
     */
    private String _hamId = null;


    /**
     * コードタイプを取得します
     *
     * @return コードタイプ
     */
    public String getCodeType() {
        return _codeType;
    }

    /**
     * コードタイプを設定します
     *
     * @param codeType コードタイプ
     */
    public void setCodeType(String codeType) {
        _codeType = codeType;
    }

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
     * @return 見積種別フラグ
     */
    public String getEstimateClass() {
        return _estimateClass;
    }

    /**
     * 見積種別フラグを設定する
     *
     * @param estimateClass 見積種別フラグ
     */
    public void setEstimateClass(String estimateClass) {
        _estimateClass = estimateClass;
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
     * HAM IDを取得する
     *
     * @return HAM ID
     */
    public String getHamId() {
        return _hamId;
    }

    /**
     * HAM IDを設定する
     *
     * @param hamId HAM ID
     */
    public void setHamId(String hamId) {
        _hamId = hamId;
    }
}
