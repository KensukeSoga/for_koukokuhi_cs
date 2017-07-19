package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HM見積書(制作)作成検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMEstimateBillReportCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 見積書検索条件 */
    private FindHMEstimateReportCondition _hmEstimateCondition = null;
    /** 請求書検索条件 */
    private FindHMBillReportCondition _hmBillCondition = null;
    /** 見積書出力フラグ */
    private BigDecimal _estimateOutput = BigDecimal.valueOf(0);
    /** 請求書出力フラグ */
    private BigDecimal _billOutput = BigDecimal.valueOf(0);

    /**
     * 見積書検索条件を取得する
     * @return FindHMEstimateReportCondition 見積書検索条件
     */
    public FindHMEstimateReportCondition getHMEstimateCondition() {
        return _hmEstimateCondition;
    }

    /**
     * 見積書検索条件を設定する
     * @param val FindHMEstimateReportCondition 見積書検索条件
     */
    public void setHMEstimateCondition(FindHMEstimateReportCondition val) {
        _hmEstimateCondition = val;
    }

    /**
     * 請求書検索条件を取得する
     * @return FindHMBillReportCondition 請求書検索条件
     */
    public FindHMBillReportCondition getHMBillCondition() {
        return _hmBillCondition;
    }

    /**
     * 請求書検索条件を設定する
     * @param val FindHMBillReportCondition 請求書検索条件
     */
    public void setHMBillCondition(FindHMBillReportCondition val) {
        _hmBillCondition = val;
    }

    /**
     * 見積書出力フラグを取得する
     * @return BigDecimal 見積書出力フラグ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstimateOutput() {
        return _estimateOutput;
    }

    /**
     * 見積書出力フラグを設定する
     * @param val BigDecimal 見積書出力フラグ
     */
    public void setEstimateOutput(BigDecimal val) {
        _estimateOutput = val;
    }

    /**
     * 請求書出力フラグを取得する
     * @return BigDecimal 請求書出力フラグ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getBillOutput() {
        return _billOutput;
    }

    /**
     * 請求書出力フラグを設定する
     * @param val BigDecimal 請求書出力フラグ
     */
    public void setBillOutput(BigDecimal val) {
        _billOutput = val;
    }

}
