package jp.co.isid.ham.login.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

@XmlRootElement(namespace = "http://model.login.cnp.isid.co.jp/")
@XmlType(namespace = "http://model.login.cnp.isid.co.jp/")
public class AccountSecurityRoleCondition implements Serializable {

    private static final long serialVersionUID = 3384456393860012717L;

    /** アプリID */
    private String _aplId = null;

    /** ログイン担当者ESQID */
    private String _esqId = null;

    /** パスワード */
    private String _password = null;

    /** セキュリティ情報 */
    private byte[] _securityInfo = null;

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
}
