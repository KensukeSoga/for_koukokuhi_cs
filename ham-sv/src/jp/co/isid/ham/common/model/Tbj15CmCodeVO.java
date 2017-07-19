package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj15CmCode;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 自動採番VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj15CmCodeVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj15CmCodeVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Tbj15CmCodeVO();
    }

    /**
     * 系統を取得する
     *
     * @return 系統
     */
    public String getNOKBN() {
        return (String) get(Tbj15CmCode.NOKBN);
    }

    /**
     * 系統を設定する
     *
     * @param val 系統
     */
    public void setNOKBN(String val) {
        set(Tbj15CmCode.NOKBN, val);
    }

    /**
     * 発番系統を取得する
     *
     * @return 発番系統
     */
    public String getCNTKBN() {
        return (String) get(Tbj15CmCode.CNTKBN);
    }

    /**
     * 発番系統を設定する
     *
     * @param val 発番系統
     */
    public void setCNTKBN(String val) {
        set(Tbj15CmCode.CNTKBN, val);
    }

    /**
     * 開始番号を取得する
     *
     * @return 開始番号
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSTARTNO() {
        return (BigDecimal) get(Tbj15CmCode.STARTNO);
    }

    /**
     * 開始番号を設定する
     *
     * @param val 開始番号
     */
    public void setSTARTNO(BigDecimal val) {
        set(Tbj15CmCode.STARTNO, val);
    }

    /**
     * 発番済み番号を取得する
     *
     * @return 発番済み番号
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEXISTNO() {
        return (BigDecimal) get(Tbj15CmCode.EXISTNO);
    }

    /**
     * 発番済み番号を設定する
     *
     * @param val 発番済み番号
     */
    public void setEXISTNO(BigDecimal val) {
        set(Tbj15CmCode.EXISTNO, val);
    }

    /**
     * 備考を取得する
     *
     * @return 備考
     */
    public String getBIKO() {
        return (String) get(Tbj15CmCode.BIKO);
    }

    /**
     * 備考を設定する
     *
     * @param val 備考
     */
    public void setBIKO(String val) {
        set(Tbj15CmCode.BIKO, val);
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj15CmCode.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj15CmCode.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj15CmCode.CRTNM);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj15CmCode.CRTNM, val);
    }

    /**
     * 作成プログラムを取得する
     *
     * @return 作成プログラム
     */
    public String getCRTAPL() {
        return (String) get(Tbj15CmCode.CRTAPL);
    }

    /**
     * 作成プログラムを設定する
     *
     * @param val 作成プログラム
     */
    public void setCRTAPL(String val) {
        set(Tbj15CmCode.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj15CmCode.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj15CmCode.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj15CmCode.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj15CmCode.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj15CmCode.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj15CmCode.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj15CmCode.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj15CmCode.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj15CmCode.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj15CmCode.UPDID, val);
    }

}
