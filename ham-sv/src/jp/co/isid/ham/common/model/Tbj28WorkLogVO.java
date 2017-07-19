package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj28WorkLog;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 稼働ログVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj28WorkLogVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj28WorkLogVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Tbj28WorkLogVO();
    }

    /**
     * データ作成日時を取得する
     *
     * @return データ作成日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj28WorkLog.CRTDATE);
    }

    /**
     * データ作成日時を設定する
     *
     * @param val データ作成日時
     */
    public void setCRTDATE(Date val) {
        set(Tbj28WorkLog.CRTDATE, val);
    }

    /**
     * 担当者ID(ESQID)を取得する
     *
     * @return 担当者ID(ESQID)
     */
    public String getHAMID() {
        return (String) get(Tbj28WorkLog.HAMID);
    }

    /**
     * 担当者ID(ESQID)を設定する
     *
     * @param val 担当者ID(ESQID)
     */
    public void setHAMID(String val) {
        set(Tbj28WorkLog.HAMID, val);
    }

    /**
     * 担当者名を取得する
     *
     * @return 担当者名
     */
    public String getHAMNM() {
        return (String) get(Tbj28WorkLog.HAMNM);
    }

    /**
     * 担当者名を設定する
     *
     * @param val 担当者名
     */
    public void setHAMNM(String val) {
        set(Tbj28WorkLog.HAMNM, val);
    }

    /**
     * 組織コード（本部）を取得する
     *
     * @return 組織コード（本部）
     */
    public String getSIKCDHONB() {
        return (String) get(Tbj28WorkLog.SIKCDHONB);
    }

    /**
     * 組織コード（本部）を設定する
     *
     * @param val 組織コード（本部）
     */
    public void setSIKCDHONB(String val) {
        set(Tbj28WorkLog.SIKCDHONB, val);
    }

    /**
     * 本部表示名（漢字）を取得する
     *
     * @return 本部表示名（漢字）
     */
    public String getSIKNMHONB() {
        return (String) get(Tbj28WorkLog.SIKNMHONB);
    }

    /**
     * 本部表示名（漢字）を設定する
     *
     * @param val 本部表示名（漢字）
     */
    public void setSIKNMHONB(String val) {
        set(Tbj28WorkLog.SIKNMHONB, val);
    }

    /**
     * 組織コード（局）を取得する
     *
     * @return 組織コード（局）
     */
    public String getSIKCDKYK() {
        return (String) get(Tbj28WorkLog.SIKCDKYK);
    }

    /**
     * 組織コード（局）を設定する
     *
     * @param val 組織コード（局）
     */
    public void setSIKCDKYK(String val) {
        set(Tbj28WorkLog.SIKCDKYK, val);
    }

    /**
     * 局表示名（漢字）を取得する
     *
     * @return 局表示名（漢字）
     */
    public String getSIKNMKYK() {
        return (String) get(Tbj28WorkLog.SIKNMKYK);
    }

    /**
     * 局表示名（漢字）を設定する
     *
     * @param val 局表示名（漢字）
     */
    public void setSIKNMKYK(String val) {
        set(Tbj28WorkLog.SIKNMKYK, val);
    }

    /**
     * 組織コード（室）を取得する
     *
     * @return 組織コード（室）
     */
    public String getSIKCDSITU() {
        return (String) get(Tbj28WorkLog.SIKCDSITU);
    }

    /**
     * 組織コード（室）を設定する
     *
     * @param val 組織コード（室）
     */
    public void setSIKCDSITU(String val) {
        set(Tbj28WorkLog.SIKCDSITU, val);
    }

    /**
     * 室表示名（漢字）を取得する
     *
     * @return 室表示名（漢字）
     */
    public String getSIKNMSITU() {
        return (String) get(Tbj28WorkLog.SIKNMSITU);
    }

    /**
     * 室表示名（漢字）を設定する
     *
     * @param val 室表示名（漢字）
     */
    public void setSIKNMSITU(String val) {
        set(Tbj28WorkLog.SIKNMSITU, val);
    }

    /**
     * 組織コード（部）を取得する
     *
     * @return 組織コード（部）
     */
    public String getSIKCDBU() {
        return (String) get(Tbj28WorkLog.SIKCDBU);
    }

    /**
     * 組織コード（部）を設定する
     *
     * @param val 組織コード（部）
     */
    public void setSIKCDBU(String val) {
        set(Tbj28WorkLog.SIKCDBU, val);
    }

    /**
     * 部表示名（漢字）を取得する
     *
     * @return 部表示名（漢字）
     */
    public String getSIKNMBU() {
        return (String) get(Tbj28WorkLog.SIKNMBU);
    }

    /**
     * 部表示名（漢字）を設定する
     *
     * @param val 部表示名（漢字）
     */
    public void setSIKNMBU(String val) {
        set(Tbj28WorkLog.SIKNMBU, val);
    }

    /**
     * 組織コード（課）を取得する
     *
     * @return 組織コード（課）
     */
    public String getSIKCDKA() {
        return (String) get(Tbj28WorkLog.SIKCDKA);
    }

    /**
     * 組織コード（課）を設定する
     *
     * @param val 組織コード（課）
     */
    public void setSIKCDKA(String val) {
        set(Tbj28WorkLog.SIKCDKA, val);
    }

    /**
     * 課表示名（漢字）を取得する
     *
     * @return 課表示名（漢字）
     */
    public String getSIKNMKA() {
        return (String) get(Tbj28WorkLog.SIKNMKA);
    }

    /**
     * 課表示名（漢字）を設定する
     *
     * @param val 課表示名（漢字）
     */
    public void setSIKNMKA(String val) {
        set(Tbj28WorkLog.SIKNMKA, val);
    }

    /**
     * 画面IDを取得する
     *
     * @return 画面ID
     */
    public String getFORMID() {
        return (String) get(Tbj28WorkLog.FORMID);
    }

    /**
     * 画面IDを設定する
     *
     * @param val 画面ID
     */
    public void setFORMID(String val) {
        set(Tbj28WorkLog.FORMID, val);
    }

    /**
     * 画面名を取得する
     *
     * @return 画面名
     */
    public String getFORMNM() {
        return (String) get(Tbj28WorkLog.FORMNM);
    }

    /**
     * 画面名を設定する
     *
     * @param val 画面名
     */
    public void setFORMNM(String val) {
        set(Tbj28WorkLog.FORMNM, val);
    }

    /**
     * 機能IDを取得する
     *
     * @return 機能ID
     */
    public String getKNOID() {
        return (String) get(Tbj28WorkLog.KNOID);
    }

    /**
     * 機能IDを設定する
     *
     * @param val 機能ID
     */
    public void setKNOID(String val) {
        set(Tbj28WorkLog.KNOID, val);
    }

    /**
     * 機能名を取得する
     *
     * @return 機能名
     */
    public String getKNONM() {
        return (String) get(Tbj28WorkLog.KNONM);
    }

    /**
     * 機能名を設定する
     *
     * @param val 機能名
     */
    public void setKNONM(String val) {
        set(Tbj28WorkLog.KNONM, val);
    }

    /**
     * 操作IDを取得する
     *
     * @return 操作ID
     */
    public String getDSMID() {
        return (String) get(Tbj28WorkLog.DSMID);
    }

    /**
     * 操作IDを設定する
     *
     * @param val 操作ID
     */
    public void setDSMID(String val) {
        set(Tbj28WorkLog.DSMID, val);
    }

    /**
     * 操作名を取得する
     *
     * @return 操作名
     */
    public String getDSMNM() {
        return (String) get(Tbj28WorkLog.DSMNM);
    }

    /**
     * 操作名を設定する
     *
     * @param val 操作名
     */
    public void setDSMNM(String val) {
        set(Tbj28WorkLog.DSMNM, val);
    }

}
