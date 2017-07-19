package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HM請求書作成(媒体)取得検索条件
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
public class FindHMBillMediaReportCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェイズ */
    private BigDecimal _phase = BigDecimal.valueOf(0);
    /** 年月 */
    private String _yearMonth = null;
    /** 見積種別 */
    private String _estimateClass = null;
    /** データ更新者 */
    private String _updNm = null;
    /** 更新プログラム */
    private String _updApl = null;
    /** 更新担当者ID */
    private String _updId = null;

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

    /**
     * データ更新者を取得する
     * @return String データ更新者
     */
    public String getUpdNm() {
        return _updNm;
    }

    /**
     * データ更新者を設定する
     * @param val String データ更新者
     */
    public void setUpdNm(String val) {
        _updNm = val;
    }

    /**
     * 更新プログラムを取得する
     * @return String 更新プログラム
     */
    public String getUpdApl() {
        return _updApl;
    }

    /**
     * 更新プログラムを設定する
     * @param val String 更新プログラム
     */
    public void setUpdApl(String val) {
        _updApl = val;
    }

    /**
     * 更新担当者IDを取得する
     * @return String 更新担当者ID
     */
    public String getUpdId() {
        return _updId;
    }

    /**
     * 更新担当者IDを設定する
     * @param val String 更新担当者ID
     */
    public void setUpdId(String val) {
        _updId = val;
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
