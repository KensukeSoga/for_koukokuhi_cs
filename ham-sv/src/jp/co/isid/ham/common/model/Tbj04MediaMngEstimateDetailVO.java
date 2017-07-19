package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj04MediaMngEstimateDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 媒体費見積明細管理VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj04MediaMngEstimateDetailVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj04MediaMngEstimateDetailVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Tbj04MediaMngEstimateDetailVO();
    }

    /**
     * 媒体費管理Noを取得する
     *
     * @return 媒体費管理No
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMEDIAMNGNO() {
        return (BigDecimal) get(Tbj04MediaMngEstimateDetail.MEDIAMNGNO);
    }

    /**
     * 媒体費管理Noを設定する
     *
     * @param val 媒体費管理No
     */
    public void setMEDIAMNGNO(BigDecimal val) {
        set(Tbj04MediaMngEstimateDetail.MEDIAMNGNO, val);
    }

    /**
     * 見積明細管理NOを取得する
     *
     * @return 見積明細管理NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTDETAILSEQNO() {
        return (BigDecimal) get(Tbj04MediaMngEstimateDetail.ESTDETAILSEQNO);
    }

    /**
     * 見積明細管理NOを設定する
     *
     * @param val 見積明細管理NO
     */
    public void setESTDETAILSEQNO(BigDecimal val) {
        set(Tbj04MediaMngEstimateDetail.ESTDETAILSEQNO, val);
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj04MediaMngEstimateDetail.PHASE);
    }

    /**
     * フェイズを設定する
     *
     * @param val フェイズ
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj04MediaMngEstimateDetail.PHASE, val);
    }

    /**
     * 年を取得する
     *
     * @return 年
     */
    public String getMDYEAR() {
        return (String) get(Tbj04MediaMngEstimateDetail.MDYEAR);
    }

    /**
     * 年を設定する
     *
     * @param val 年
     */
    public void setMDYEAR(String val) {
        set(Tbj04MediaMngEstimateDetail.MDYEAR, val);
    }

    /**
     * 月を取得する
     *
     * @return 月
     */
    public String getMDMONTH() {
        return (String) get(Tbj04MediaMngEstimateDetail.MDMONTH);
    }

    /**
     * 月を設定する
     *
     * @param val 月
     */
    public void setMDMONTH(String val) {
        set(Tbj04MediaMngEstimateDetail.MDMONTH, val);
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj04MediaMngEstimateDetail.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj04MediaMngEstimateDetail.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj04MediaMngEstimateDetail.CRTNM);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj04MediaMngEstimateDetail.CRTNM, val);
    }

    /**
     * 作成プログラムを取得する
     *
     * @return 作成プログラム
     */
    public String getCRTAPL() {
        return (String) get(Tbj04MediaMngEstimateDetail.CRTAPL);
    }

    /**
     * 作成プログラムを設定する
     *
     * @param val 作成プログラム
     */
    public void setCRTAPL(String val) {
        set(Tbj04MediaMngEstimateDetail.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj04MediaMngEstimateDetail.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj04MediaMngEstimateDetail.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj04MediaMngEstimateDetail.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj04MediaMngEstimateDetail.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj04MediaMngEstimateDetail.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj04MediaMngEstimateDetail.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj04MediaMngEstimateDetail.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj04MediaMngEstimateDetail.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj04MediaMngEstimateDetail.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj04MediaMngEstimateDetail.UPDID, val);
    }

}
