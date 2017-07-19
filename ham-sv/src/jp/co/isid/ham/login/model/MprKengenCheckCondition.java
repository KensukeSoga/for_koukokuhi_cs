package jp.co.isid.ham.login.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

@XmlRootElement(namespace = "http://model.login.cnp.isid.co.jp/")
@XmlType(namespace = "http://model.login.cnp.isid.co.jp/")
public class MprKengenCheckCondition implements Serializable {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** アプリID */
    private String _aplId = null;

    /** ログイン担当者ESQID */
    private String _esqId = null;

    /** パスワード */
    private String _password = null;

    /** セキュリティ情報 */
    private byte[] _securityInfo = null;

    /** 営業日 */
    private String _eigyobi = null;

    /** 担当者コード */
    private String _tantoCd = null;

    /** ログイン局コード */
    private String _kyokuCd = null;

    /** 運用No */
    private String _operationNo = null;

    /**
     * アプリIDを取得する
     * @return アプリID
     */
    public String getAplId() {
        return _aplId;
    }

    /**
     * アプリIDを設定する
     * @param aplId アプリID
     */
    public void setAplId(String aplId) {
        this._aplId = aplId;
    }

    /**
     * ログイン担当者ESQIDを取得する
     * @return ログイン担当者ESQID
     */
    public String getEsqId() {
        return _esqId;
    }

    /**
     * ログイン担当者ESQIDを設定する
     * @param esqId ログイン担当者ESQID
     */
    public void setEsqId(String esqId) {
        this._esqId = esqId;
    }

    /**
     * パスワードを取得する
     * @return パスワード
     */
    public String getPassword() {
        return _password;
    }

    /**
     * パスワードを設定する
     * @param password パスワード
     */
    public void setPassword(String password) {
        this._password = password;
    }

    /**
     * セキュリティ情報を取得する
     * @return セキュリティ情報
     */
    public byte[] getSecurityInfo() {
        return _securityInfo;
    }

    /**
     * セキュリティ情報を設定する
     * @param securityInfo セキュリティ情報
     */
    public void setSecurityInfo(byte[] securityInfo) {
        this._securityInfo = securityInfo;
    }

    /**
     * 営業日を取得する
     * @return 営業日
     */
    public String getEigyobi() {
        return _eigyobi;
    }

    /**
     * 営業日を設定する
     * @param 営業日
     */
    public void setEigyobi(String eigyobi) {
        this._eigyobi = eigyobi;
    }

    /**
     * 担当者コードを取得する
     * @return 担当者コード
     */
    public String getTantoCd() {
        return _tantoCd;
    }

    /**
     * 担当者コードを設定する
     * @param 担当者コード
     */
    public void setTantoCd(String tantoCd) {
        this._tantoCd = tantoCd;
    }

    /**
     * ログイン局コードを取得する
     * @return ログイン局コード
     */
    public String getKyokuCd() {
        return _kyokuCd;
    }

    /**
     * ログイン局コードを設定する
     * @param ログイン局コード
     */
    public void setKyokuCd(String kyokuCd) {
        this._kyokuCd = kyokuCd;
    }

    /**
     * 運用Noを取得する
     * @return 運用No
     */
    public String getOperationNo() {
        return _operationNo;
    }

    /**
     * 運用Noを設定する
     * @param 運用No
     */
    public void setOperationNo(String operationNo) {
        this._operationNo = operationNo;
    }
}
