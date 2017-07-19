package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj19Jasrac;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * JASRACVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj19JasracVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj19JasracVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Tbj19JasracVO();
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj19Jasrac.PHASE);
    }

    /**
     * フェイズを設定する
     *
     * @param val フェイズ
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj19Jasrac.PHASE, val);
    }

    /**
     * 四半期区分を取得する
     *
     * @return 四半期区分
     */
    public String getQUOTEKBN() {
        return (String) get(Tbj19Jasrac.QUOTEKBN);
    }

    /**
     * 四半期区分を設定する
     *
     * @param val 四半期区分
     */
    public void setQUOTEKBN(String val) {
        set(Tbj19Jasrac.QUOTEKBN, val);
    }

    /**
     * 年月を取得する
     *
     * @return 年月
     */
    @XmlElement(required = true, nillable = true)
    public Date getSEIKYUYM() {
        return (Date) get(Tbj19Jasrac.SEIKYUYM);
    }

    /**
     * 年月を設定する
     *
     * @param val 年月
     */
    public void setSEIKYUYM(Date val) {
        set(Tbj19Jasrac.SEIKYUYM, val);
    }

    /**
     * 契約種類を取得する
     *
     * @return 契約種類
     */
    public String getCTRTKBN() {
        return (String) get(Tbj19Jasrac.CTRTKBN);
    }

    /**
     * 契約種類を設定する
     *
     * @param val 契約種類
     */
    public void setCTRTKBN(String val) {
        set(Tbj19Jasrac.CTRTKBN, val);
    }

    /**
     * 契約コードを取得する
     *
     * @return 契約コード
     */
    public String getCTRTNO() {
        return (String) get(Tbj19Jasrac.CTRTNO);
    }

    /**
     * 契約コードを設定する
     *
     * @param val 契約コード
     */
    public void setCTRTNO(String val) {
        set(Tbj19Jasrac.CTRTNO, val);
    }

    /**
     * 削除フラグを取得する
     *
     * @return 削除フラグ
     */
    public String getDELFLG() {
        return (String) get(Tbj19Jasrac.DELFLG);
    }

    /**
     * 削除フラグを設定する
     *
     * @param val 削除フラグ
     */
    public void setDELFLG(String val) {
        set(Tbj19Jasrac.DELFLG, val);
    }

    /**
     * 使用期間(From)を取得する
     *
     * @return 使用期間(From)
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj19Jasrac.DATEFROM);
    }

    /**
     * 使用期間(From)を設定する
     *
     * @param val 使用期間(From)
     */
    public void setDATEFROM(Date val) {
        set(Tbj19Jasrac.DATEFROM, val);
    }

    /**
     * 使用期間(To)を取得する
     *
     * @return 使用期間(To)
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj19Jasrac.DATETO);
    }

    /**
     * 使用期間(To)を設定する
     *
     * @param val 使用期間(To)
     */
    public void setDATETO(Date val) {
        set(Tbj19Jasrac.DATETO, val);
    }

    /**
     * 営業申込番号1を取得する
     *
     * @return 営業申込番号1
     */
    public String getEIGYNO1() {
        return (String) get(Tbj19Jasrac.EIGYNO1);
    }

    /**
     * 営業申込番号1を設定する
     *
     * @param val 営業申込番号1
     */
    public void setEIGYNO1(String val) {
        set(Tbj19Jasrac.EIGYNO1, val);
    }

    /**
     * 営業申込番号2を取得する
     *
     * @return 営業申込番号2
     */
    public String getEIGYNO2() {
        return (String) get(Tbj19Jasrac.EIGYNO2);
    }

    /**
     * 営業申込番号2を設定する
     *
     * @param val 営業申込番号2
     */
    public void setEIGYNO2(String val) {
        set(Tbj19Jasrac.EIGYNO2, val);
    }

    /**
     * 備考を取得する
     *
     * @return 備考
     */
    public String getBIKO() {
        return (String) get(Tbj19Jasrac.BIKO);
    }

    /**
     * 備考を設定する
     *
     * @param val 備考
     */
    public void setBIKO(String val) {
        set(Tbj19Jasrac.BIKO, val);
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj19Jasrac.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj19Jasrac.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj19Jasrac.CRTNM);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj19Jasrac.CRTNM, val);
    }

    /**
     * 作成プログラムを取得する
     *
     * @return 作成プログラム
     */
    public String getCRTAPL() {
        return (String) get(Tbj19Jasrac.CRTAPL);
    }

    /**
     * 作成プログラムを設定する
     *
     * @param val 作成プログラム
     */
    public void setCRTAPL(String val) {
        set(Tbj19Jasrac.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj19Jasrac.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj19Jasrac.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj19Jasrac.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj19Jasrac.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj19Jasrac.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj19Jasrac.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj19Jasrac.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj19Jasrac.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj19Jasrac.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj19Jasrac.UPDID, val);
    }

}
