package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj34CutManagement;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 削減額管理VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj34CutManagementVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj34CutManagementVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Tbj34CutManagementVO();
    }

    /**
     * 種別コードを取得する
     *
     * @return 種別コード
     */
    public String getCLASSCD() {
        return (String) get(Tbj34CutManagement.CLASSCD);
    }

    /**
     * 種別コードを設定する
     *
     * @param val 種別コード
     */
    public void setCLASSCD(String val) {
        set(Tbj34CutManagement.CLASSCD, val);
    }

    /**
     * 開始年月日を取得する
     *
     * @return 開始年月日
     */
    public String getDATEFROM() {
        return (String) get(Tbj34CutManagement.DATEFROM);
    }

    /**
     * 開始年月日を設定する
     *
     * @param val 開始年月日
     */
    public void setDATEFROM(String val) {
        set(Tbj34CutManagement.DATEFROM, val);
    }

    /**
     * 終了年月日を取得する
     *
     * @return 終了年月日
     */
    public String getDATETO() {
        return (String) get(Tbj34CutManagement.DATETO);
    }

    /**
     * 終了年月日を設定する
     *
     * @param val 終了年月日
     */
    public void setDATETO(String val) {
        set(Tbj34CutManagement.DATETO, val);
    }

    /**
     * 削減実績額を取得する
     *
     * @return 削減実績額
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCUTMONEY() {
        return (BigDecimal) get(Tbj34CutManagement.CUTMONEY);
    }

    /**
     * 削減実績額を設定する
     *
     * @param val 削減実績額
     */
    public void setCUTMONEY(BigDecimal val) {
        set(Tbj34CutManagement.CUTMONEY, val);
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj34CutManagement.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj34CutManagement.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj34CutManagement.CRTNM);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj34CutManagement.CRTNM, val);
    }

    /**
     * 作成プログラムを取得する
     *
     * @return 作成プログラム
     */
    public String getCRTAPL() {
        return (String) get(Tbj34CutManagement.CRTAPL);
    }

    /**
     * 作成プログラムを設定する
     *
     * @param val 作成プログラム
     */
    public void setCRTAPL(String val) {
        set(Tbj34CutManagement.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj34CutManagement.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj34CutManagement.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj34CutManagement.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj34CutManagement.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj34CutManagement.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj34CutManagement.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj34CutManagement.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj34CutManagement.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj34CutManagement.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj34CutManagement.UPDID, val);
    }

}
