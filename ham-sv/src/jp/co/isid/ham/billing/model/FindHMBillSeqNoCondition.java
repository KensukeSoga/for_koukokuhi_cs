package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HM請求書(見積明細出力順SEQNO)取得検索条件
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
public class FindHMBillSeqNoCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェイズ */
    private BigDecimal _phase = BigDecimal.valueOf(0);
    /** 年月 */
    private String _yearMonth = null;

    /* 2016/02/02 請求業務変更対応 HLC K.Soga ADD Start */
    /** グループコード */
    private BigDecimal _groupCd = null;

    /** 請求先部門コード */
    private String _hcbumoncdbill = null;

    /** 見積案件管理NO */
    private BigDecimal _estSeqNo = BigDecimal.valueOf(0);
    /* 2016/02/02 請求業務変更対応 HLC K.Soga ADD End */

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
     * @param phase int フェイズ
     */
    public void setPhase(BigDecimal phase) {
        _phase = phase;
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
     * @param yearMonth String 年月
     */
    public void setYearMonth(String yearMonth) {
        _yearMonth = yearMonth;
    }

    /* 2016/02/02 請求業務変更対応 HLC K.Soga ADD Start */
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
     * 請求先グループを取得する
     *
     * @return 請求先グループ
     */
    public String getHcbumoncdbill() {
        return _hcbumoncdbill;
    }

    /**
     * 請求先グループを設定する
     *
     * @param hcbumoncdbill 請求先グループ
     */
    public void setHcbumoncdbill(String hcbumoncdbill) {
        this._hcbumoncdbill = hcbumoncdbill;
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
     * @param estSeqNo BigDecimal 見積案件管理NO
     */
    public void setEstSeqNo(BigDecimal estSeqNo) {
        _estSeqNo = estSeqNo;
    }
    /* 2016/02/02 請求業務変更対応 HLC K.Soga ADD End */
}