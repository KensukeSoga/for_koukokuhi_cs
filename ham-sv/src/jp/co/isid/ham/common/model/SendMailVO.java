package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <P>
 * メール送信データクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/07/01 )<BR>
 * </P>
 * @author
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class SendMailVO implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public SendMailVO() {
    }

    /** ログインID */
    private String _esqId = null;

    /** ログインパスワード */
    private String _password = null;

    /** 送信者アドレス */
    private String _fromAddress = null;

    /** 送信者名称 */
    private String _fromName = null;

    private List<SendMailInfoVO> _sendMailInfoList = null;


    /**
     * ログインIDを取得する
     * @return ログインID
     */
    public String getEsqId() {
        return _esqId;
    }

    /**
     * ログインIDを設定する
     * @param esqId ログインID
     */
    public void setEsqId(String esqId) {
        this._esqId = esqId;
    }

    /**
     * ログインパスワードを取得する
     * @return ログインパスワード
     */
    public String getPassword() {
        return _password;
    }

    /**
     * ログインパスワードを設定する
     * @param password ログインパスワード
     */
    public void setPassword(String password) {
        this._password = password;
    }

    /**
     * 送信者アドレスを取得する
     * @return 送信者アドレス
     */
    public String getFromAddress() {
        return _fromAddress;
    }

    /**
     * 送信者アドレスを設定する
     * @param fromAddress 送信者アドレス
     */
    public void setFromAddress(String fromAddress) {
        this._fromAddress = fromAddress;
    }

    /**
     * 送信者名称を取得する
     * @return 送信者名称
     */
    public String getFromName() {
        return _fromName;
    }

    /**
     * 送信者名称を設定する
     * @param fromName 送信者名称
     */
    public void setFromName(String fromName) {
        this._fromName = fromName;
    }

    /**
     * 送信するメールの情報を取得する
     *
     * @return 送信するメールの情報
     */
    public List<SendMailInfoVO> getSendMailInfo() {
        return _sendMailInfoList;
    }

    /**
     * 送信するメールの情報を設定する
     *
     * @param val 送信するメールの情報
     */
    public void setSendMailInfo(List<SendMailInfoVO> sendMailInfoList) {
        _sendMailInfoList = sendMailInfoList;
    }
}
