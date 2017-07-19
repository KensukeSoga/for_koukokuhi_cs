package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HM見積書、請求明細書、請求書作成(媒体)取得検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMEstimateBillMediaReportCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 見積書、請求明細書検索条件 */
    private FindHMEstimateMediaReportCondition _estimateCondition = null;
    /** 請求書検索条件 */
    private FindHMBillMediaReportCondition _billCondition = null;
    /** 見積書出力フラグ */
    private BigDecimal _estimateOutput = BigDecimal.valueOf(0);
    /** 請求明細書出力フラグ */
    private BigDecimal _billDetailOutput = BigDecimal.valueOf(0);
    /** 請求書出力フラグ */
    private BigDecimal _billOutput = BigDecimal.valueOf(0);

    /**
     * 見積書、請求明細書検索条件を取得する
     * @return FindHMEstimateMediaReportCondition 見積書、請求明細書検索条件
     */
    public FindHMEstimateMediaReportCondition getEstimateCondition() {
        return _estimateCondition;
    }

    /**
     * 見積書、請求明細書検索条件を設定する
     * @param val FindHMEstimateMediaReportCondition 見積書、請求明細書検索条件
     */
    public void setEstimateCondition(FindHMEstimateMediaReportCondition val) {
        _estimateCondition = val;
    }

    /**
     * 請求書検索条件を取得する
     * @return FindHMBillMediaReportCondition 請求書検索条件
     */
    public FindHMBillMediaReportCondition getBillCondition() {
        return _billCondition;
    }

    /**
     * 請求書検索条件を設定する
     * @param val FindHMBillMediaReportCondition 請求書検索条件
     */
    public void setBillCondition(FindHMBillMediaReportCondition val) {
        _billCondition = val;
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
     * 請求明細書出力フラグを取得する
     * @return BigDecimal 請求明細書出力フラグ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getBillDetailOutput() {
        return _billDetailOutput;
    }

    /**
     * 請求明細書出力フラグを設定する
     * @param val BigDecimal 請求明細書出力フラグ
     */
    public void setBillDetailOutput(BigDecimal val) {
        _billDetailOutput = val;
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
