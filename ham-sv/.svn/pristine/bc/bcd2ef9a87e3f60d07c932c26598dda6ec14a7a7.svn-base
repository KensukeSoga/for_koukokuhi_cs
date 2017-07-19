package jp.co.isid.ham.billing.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HM請求書(制作)作成検索条件
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
public class FindHMBillReportCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フェイズ */
    private BigDecimal _phase = BigDecimal.valueOf(0);
    /** 年月 */
    private String _yearMonth = null;
    /** 見積種別 */
    private String _estimateClass = null;
    /** 見積案件管理NO */
    private BigDecimal _estSeqNo = BigDecimal.valueOf(0);
    /** 開始日 */
    private Date _startDate = null;
    /** 終了日 */
    private Date _endDate = null;
    /** 電通車種コード */
    private String _dcarCd = null;
    /** 区分コード */
    private String _divCd = null;
    /** グループコード */
    private BigDecimal _groupCd = null;
    /** データ更新者 */
    private String _updNm = null;
    /** 更新プログラム */
    private String _updApl = null;
    /** 更新担当者ID */
    private String _updId = null;

    /* 2016/02/02 請求業務変更対応 HLC K.Soga ADD Start */
    /** 請求先グループ */
    private String _hcbumoncdbill = null;
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

    /**
     * 見積種別を取得する
     * @return String 見積種別
     */
    public String getEstimateClass() {
        return _estimateClass;
    }

    /**
     * 見積種別を設定する
     * @param estimateClass String 見積種別
     */
    public void setEstimateClass(String estimateClass) {
        _estimateClass = estimateClass;
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

    /**
     * 開始日を取得する
     * @return Date 開始日
     */
    @XmlElement(required = true, nillable = true)
    public Date getStartDate() {
        return _startDate;
    }

    /**
     * 開始日を設定する
     * @param startDate Date 終了日
     */
    public void setStartDate(Date startDate) {
        _startDate = startDate;
    }

    /**
     * 終了日を取得する
     * @return Date 終了日
     */
    @XmlElement(required = true, nillable = true)
    public Date getEndDate() {
        return _endDate;
    }

    /**
     * 終了日を設定する
     * @param endDate Date 終了日
     */
    public void setEndDate(Date endDate) {
        _endDate = endDate;
    }

    /**
     * 電通車種コードを取得する
     * @return String 電通車種コード
     */
    public String getDCarCd() {
        return _dcarCd;
    }

    /**
     * 電通車種コードを設定する
     * @param dcarCd String 電通車種コード
     */
    public void setDCarCd(String dcarCd) {
        _dcarCd = dcarCd;
    }

    /**
     * 区分コードを取得する
     * @return String 区分コード
     */
    public String getDivCd() {
        return _divCd;
    }

    /**
     * 区分コードを設定する
     * @param divCd String 区分コード
     */
    public void setDivCd(String divCd) {
        _divCd = divCd;
    }

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

    /* 2016/02/02 請求業務変更対応 HLC K.Soga ADD Start */
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
    /* 2016/02/02 請求業務変更対応 HLC K.Soga ADD End */

}
