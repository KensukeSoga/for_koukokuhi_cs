package jp.co.isid.ham.operationLog.model;

import java.math.BigDecimal;
import java.text.ParseException;
import java.text.SimpleDateFormat;
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
 * ・新規作成(2013/05/15 T.Kobayashi)<BR>
 * </P>
 *
 * @author T.Kobayashi
 */
@XmlRootElement(namespace = "http://model.operationLog.ham.isid.co.jp/")
@XmlType(namespace = "http://model.operationLog.ham.isid.co.jp/")
public class FindOperationLogVO extends AbstractModel{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** フォーマット */
    private static final String DATE_PATTERN = "yyyy/MM/dd";

    /**
     * デフォルトコンストラクタ
     */
    public FindOperationLogVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindOperationLogVO();
    }

    /**
     * データ作成日時を取得します
     * @param val
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {

    	Date dtTmp = new Date();
    	String strTmp = "";

    	if (get(Tbj28WorkLog.CRTDATE) == null) {
    		// nullの場合
            return null;
    	}

    	strTmp = get(Tbj28WorkLog.CRTDATE).toString();

    	if (strTmp.length() == 10) {
    		// yyyy/MM/dd型の場合(集計にチェックありパターン)
    		// 適切な日付型に変換する
    	    try {
    	    	dtTmp = (new SimpleDateFormat(DATE_PATTERN)).parse(strTmp);

  		  	} catch (ParseException e) {
  		  		return null;
    		}
    	} else {
    		// 上記以外(集計にチェックなしパターン)
    		dtTmp = (Date) get(Tbj28WorkLog.CRTDATE);
    	}

        return dtTmp;
    }

    /**
     * データ作成日時を設定します
     */
    public void setCRTDATE(Date val) {
        set(Tbj28WorkLog.CRTDATE, val);
    }

    /**
     * 担当者ID(ESQID)を取得します
     * @param val
     */
    public String getHAMID() {
        return (String) get(Tbj28WorkLog.HAMID);
    }

    /**
     * 担当者ID(ESQID)を設定します
     */
    public void setHAMID(String val) {
        set(Tbj28WorkLog.HAMID, val);
    }

    /**
     * 担当者名を取得します
     * @param val
     */
    public String getHAMNM() {
        return (String) get(Tbj28WorkLog.HAMNM);
    }

    /**
     * 担当者名を設定します
     */
    public void setHAMNM(String val) {
        set(Tbj28WorkLog.HAMNM, val);
    }

    /**
     * 組織コード（本部）を取得します
     * @param val
     */
    public String getSIKCDHONB() {
        return (String) get(Tbj28WorkLog.SIKCDHONB);
    }

    /**
     * 組織コード（本部）を設定します
     */
    public void setSIKCDHONB(String val) {
        set(Tbj28WorkLog.SIKCDHONB, val);
    }

    /**
     * 本部表示名（漢字）を取得します
     * @param val
     */
    public String getSIKNMHONB() {
        return (String) get(Tbj28WorkLog.SIKNMHONB);
    }

    /**
     * 本部表示名（漢字）を設定します
     */
    public void setSIKNMHONB(String val) {
        set(Tbj28WorkLog.SIKNMHONB, val);
    }

    /**
     * 組織コード（局）を取得します
     * @param val
     */
    public String getSIKCDKYK() {
        return (String) get(Tbj28WorkLog.SIKCDKYK);
    }

    /**
     * 組織コード（局）を設定します
     */
    public void setSIKCDKYK(String val) {
        set(Tbj28WorkLog.SIKCDKYK, val);
    }

    /**
     * 局表示名（漢字）を取得します
     * @param val
     */
    public String getSIKNMKYK() {
        return (String) get(Tbj28WorkLog.SIKNMKYK);
    }

    /**
     * 局表示名（漢字）を設定します
     */
    public void setSIKNMKYK(String val) {
        set(Tbj28WorkLog.SIKNMKYK, val);
    }

    /**
     * 組織コード（室）を取得します
     * @param val
     */
    public String getSIKCDSITU() {
        return (String) get(Tbj28WorkLog.SIKCDSITU);
    }

    /**
     * 組織コード（室）を設定します
     */
    public void setSIKCDSITU(String val) {
        set(Tbj28WorkLog.SIKCDSITU, val);
    }

    /**
     * 室表示名（漢字）を取得します
     * @param val
     */
    public String getSIKNMSITU() {
        return (String) get(Tbj28WorkLog.SIKNMSITU);
    }

    /**
     * 室表示名（漢字）を設定します
     */
    public void setSIKNMSITU(String val) {
        set(Tbj28WorkLog.SIKNMSITU, val);
    }

    /**
     * 組織コード（部）を取得します
     * @param val
     */
    public String getSIKCDBU() {
        return (String) get(Tbj28WorkLog.SIKCDBU);
    }

    /**
     * 組織コード（部）を設定します
     */
    public void setSIKCDBU(String val) {
        set(Tbj28WorkLog.SIKCDBU, val);
    }

    /**
     * 部表示名（漢字）を取得します
     * @param val
     */
    public String getSIKNMBU() {
        return (String) get(Tbj28WorkLog.SIKNMBU);
    }

    /**
     * 部表示名（漢字）を設定します
     */
    public void setSIKNMBU(String val) {
        set(Tbj28WorkLog.SIKNMBU, val);
    }

    /**
     * 組織コード（課）を取得します
     * @param val
     */
    public String getSIKCDKA() {
        return (String) get(Tbj28WorkLog.SIKCDKA);
    }

    /**
     * 組織コード（課）を設定します
     */
    public void setSIKCDKA(String val) {
        set(Tbj28WorkLog.SIKCDKA, val);
    }

    /**
     * 課表示名（漢字）を取得します
     * @param val
     */
    public String getSIKNMKA() {
        return (String) get(Tbj28WorkLog.SIKNMKA);
    }

    /**
     * 課表示名（漢字）を設定します
     */
    public void setSIKNMKA(String val) {
        set(Tbj28WorkLog.SIKNMKA, val);
    }

    /**
     * 画面IDを取得します
     * @param val
     */
    public String getFORMID() {
        return (String) get(Tbj28WorkLog.FORMID);
    }

    /**
     * 画面IDを設定します
     */
    public void setFORMID(String val) {
        set(Tbj28WorkLog.FORMID, val);
    }

    /**
     * 画面名を取得します
     * @param val
     */
    public String getFORMNM() {
        return (String) get(Tbj28WorkLog.FORMNM);
    }

    /**
     * 画面名を設定します
     */
    public void setFORMNM(String val) {
        set(Tbj28WorkLog.FORMNM, val);
    }

    /**
     * 機能IDを取得します
     * @param val
     */
    public String getKNOID() {
        return (String) get(Tbj28WorkLog.KNOID);
    }

    /**
     * 機能IDを設定します
     */
    public void setKNOID(String val) {
        set(Tbj28WorkLog.KNOID, val);
    }

    /**
     * 機能名を取得します
     * @param val
     */
    public String getKNONM() {
        return (String) get(Tbj28WorkLog.KNONM);
    }

    /**
     * 機能名を設定します
     */
    public void setKNONM(String val) {
        set(Tbj28WorkLog.KNONM, val);
    }

    /**
     * 操作IDを取得します
     * @param val
     */
    public String getDSMID() {
        return (String) get(Tbj28WorkLog.DSMID);
    }

    /**
     * 操作IDを設定します
     */
    public void setDSMID(String val) {
        set(Tbj28WorkLog.DSMID, val);
    }

    /**
     * 操作名を取得します
     * @param val
     */
    public String getDSMNM() {
        return (String) get(Tbj28WorkLog.DSMNM);
    }

    /**
     * 操作名を設定します
     */
    public void setDSMNM(String val) {
        set(Tbj28WorkLog.DSMNM, val);
    }

    /**
     * 組織名(局＋室＋部＋課)を取得します
     * @param val
     */
    public String getSOSHIKIFULLNM() {
        return (String) get("SOSHIKI_FULLNM");
    }

    /**
     * 組織名(局＋室＋部＋課)を設定します
     */
    public void setSOSHIKIFULLNM(String val) {
        set("SOSHIKI_FULLNM", val);
    }

    /**
     * 件数を取得します
     * @param val
     */
    public BigDecimal getCOUNT() {
        return (BigDecimal) get("LOG_COUNT");
    }

    /**
     * 件数を設定します
     */
    public void setCOUNT(BigDecimal val) {
        set("LOG_COUNT", val);
    }
}
