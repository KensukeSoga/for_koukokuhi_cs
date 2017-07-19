package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HM見積書、請求書作成(媒体)取得検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * ・請求業務変更対応(2016/02/04 HLC K.Soga)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMEstimateMediaReportCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェイズ */
    private BigDecimal _phase = BigDecimal.valueOf(0);
    /** 年月 */
    private String _yearMonth = null;
    /** 見積種別 */
    private String _estimateClass = null;

    /* 2016/02/04 請求業務変更対応 HLC K.Soga ADD Start */
    /** グループコード */
    private BigDecimal _groupCd = null;

    /** 請求SEQNO */
    private BigDecimal _estSeqNo = BigDecimal.valueOf(0);
    /* 2016/02/04 請求業務変更対応 HLC K.Soga ADD End */

    /**
     * フェイズを取得する
     * @return int フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     * @param val int フェイズ
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
     * @return String 見積種別
     */
    public String getEstimateClass() {
        return _estimateClass;
    }

    /**
     * 見積種別を設定する
     * @param val String 見積種別
     */
    public void setEstimateClass(String val) {
        _estimateClass = val;
    }

    /* 2016/02/04 請求業務変更対応 HLC K.Soga ADD Start */
    /**
     * グループコードを取得する
     * @return BigDecimal グループコード
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGroupCd() {
        return _groupCd;
    }

    /**
     * グループコードを設定する
     * @param groupCd BigDecimal グループコード
     */
    public void setGroupCd(BigDecimal groupCd) {
        _groupCd = groupCd;
    }

    /**
     * 請求SEQNOを取得する
     * @return BigDecimal
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstSeqNo() {
        return _estSeqNo;
    }

    /**
     * 請求SEQNOを設定する
     * @param estSeqNo BigDecimal 請求SEQNO
     */
    public void setEstSeqNo(BigDecimal estSeqNo) {
        _estSeqNo = estSeqNo;
    }
    /* 2016/02/04 請求業務変更対応 HLC K.Soga ADD End */
}
