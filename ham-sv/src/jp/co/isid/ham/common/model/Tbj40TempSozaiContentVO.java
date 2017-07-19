package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj40TempSozaiContent;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 契約仮素材紐付けVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj40TempSozaiContentVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj40TempSozaiContentVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Tbj40TempSozaiContentVO();
    }

    /**
     * 仮10桁CMｺｰﾄﾞを取得する
     *
     * @return 仮10桁CMｺｰﾄﾞ
     */
    public String getTEMPCMCD() {
        return (String) get(Tbj40TempSozaiContent.TEMPCMCD);
    }

    /**
     * 仮10桁CMｺｰﾄﾞを設定する
     *
     * @param val 仮10桁CMｺｰﾄﾞ
     */
    public void setTEMPCMCD(String val) {
        set(Tbj40TempSozaiContent.TEMPCMCD, val);
    }

    /**
     * 契約種類を取得する
     *
     * @return 契約種類
     */
    public String getCTRTKBN() {
        return (String) get(Tbj40TempSozaiContent.CTRTKBN);
    }

    /**
     * 契約種類を設定する
     *
     * @param val 契約種類
     */
    public void setCTRTKBN(String val) {
        set(Tbj40TempSozaiContent.CTRTKBN, val);
    }

    /**
     * 契約コードを取得する
     *
     * @return 契約コード
     */
    public String getCTRTNO() {
        return (String) get(Tbj40TempSozaiContent.CTRTNO);
    }

    /**
     * 契約コードを設定する
     *
     * @param val 契約コード
     */
    public void setCTRTNO(String val) {
        set(Tbj40TempSozaiContent.CTRTNO, val);
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj40TempSozaiContent.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj40TempSozaiContent.CRTDATE, val);
    }

    /**
     * データ作成者を取得する
     *
     * @return データ作成者
     */
    public String getCRTNM() {
        return (String) get(Tbj40TempSozaiContent.CRTNM);
    }

    /**
     * データ作成者を設定する
     *
     * @param val データ作成者
     */
    public void setCRTNM(String val) {
        set(Tbj40TempSozaiContent.CRTNM, val);
    }

    /**
     * 作成プログラムを取得する
     *
     * @return 作成プログラム
     */
    public String getCRTAPL() {
        return (String) get(Tbj40TempSozaiContent.CRTAPL);
    }

    /**
     * 作成プログラムを設定する
     *
     * @param val 作成プログラム
     */
    public void setCRTAPL(String val) {
        set(Tbj40TempSozaiContent.CRTAPL, val);
    }

    /**
     * 作成担当者IDを取得する
     *
     * @return 作成担当者ID
     */
    public String getCRTID() {
        return (String) get(Tbj40TempSozaiContent.CRTID);
    }

    /**
     * 作成担当者IDを設定する
     *
     * @param val 作成担当者ID
     */
    public void setCRTID(String val) {
        set(Tbj40TempSozaiContent.CRTID, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj40TempSozaiContent.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Tbj40TempSozaiContent.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Tbj40TempSozaiContent.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Tbj40TempSozaiContent.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Tbj40TempSozaiContent.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Tbj40TempSozaiContent.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Tbj40TempSozaiContent.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Tbj40TempSozaiContent.UPDID, val);
    }

}
