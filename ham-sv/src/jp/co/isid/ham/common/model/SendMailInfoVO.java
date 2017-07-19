package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * メール送信情報クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/07/01 )<BR>
 * </P>
 * @author
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class SendMailInfoVO implements Serializable {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** 宛先（To）アドレス */
    private List<String> _toAddress = null;

    /** 宛先（To）名称 */
    private List<String> _toName = null;

    /** 宛先（Cc）アドレス */
    private List<String> _ccAddress = null;

    /** 宛先（Cc）名称 */
    private List<String> _ccName = null;

    /** 宛先（Bcc）アドレス */
    private List<String> _bccAddress = null;

    /** 宛先（Bcc）名称 */
    private List<String> _bccName = null;

    /** 件名 */
    private String _subject = null;

    /** 本文 */
    private String _body = null;

    /**
     * 宛先（To）アドレスを取得する
     * @return 宛先（To）アドレス
     */
    public List<String> getToAddress() {
        return _toAddress;
    }

    /**
     * 宛先（To）アドレスを設定する
     * @param toAddress 宛先（To）アドレス
     */
    public void setToAddress(List<String> toAddress) {
        this._toAddress = toAddress;
    }

    /**
     * 宛先（To）名称を取得する
     * @return 宛先（To）名称
     */
    public List<String> getToName() {
        return _toName;
    }

    /**
     * 宛先（To）名称を設定する
     * @param toName 宛先（To）名称
     */
    public void setToName(List<String> toName) {
        this._toName = toName;
    }

    /**
     * 宛先（Cc）アドレスを取得する
     * @return 宛先（Cc）アドレス
     */
    public List<String> getCcAddress() {
        return _ccAddress;
    }

    /**
     * 宛先（Cc）アドレスを設定する
     * @param ccAddress 宛先（Cc）アドレス
     */
    public void setCcAddress(List<String> ccAddress) {
        this._ccAddress = ccAddress;
    }

    /**
     * 宛先（Cc）名称を取得する
     * @return 宛先（Cc）名称
     */
    public List<String> getCcName() {
        return _ccName;
    }

    /**
     * 宛先（Cc）名称を設定する
     * @param ccName 宛先（Cc）名称
     */
    public void setCcName(List<String> ccName) {
        this._ccName = ccName;
    }

    /**
     * 宛先（Bcc）アドレスを取得する
     * @return 宛先（Bcc）アドレス
     */
    public List<String> getBccAddress() {
        return _bccAddress;
    }

    /**
     * 宛先（Bcc）アドレスを設定する
     * @param bccAddress 宛先（Bcc）アドレス
     */
    public void setBccAddress(List<String> bccAddress) {
        this._bccAddress = bccAddress;
    }

    /**
     * 宛先（Bcc）名称を取得する
     * @return 宛先（Bcc）名称
     */
    public List<String> getBccName() {
        return _bccName;
    }

    /**
     * 宛先（Bcc）名称を設定する
     * @param bccName 宛先（Bcc）名称
     */
    public void setBccName(List<String> bccName) {
        this._bccName = bccName;
    }

    /**
     * 件名を取得する
     * @return 件名
     */
    public String getSubject() {
        return _subject;
    }

    /**
     * 件名を設定する
     * @param subject 件名
     */
    public void setSubject(String subject) {
        this._subject = subject;
    }

    /**
     * 本文を取得する
     * @return 本文
     */
    public String getBody() {
        return _body;
    }

    /**
     * 本文を設定する
     * @param body 本文
     */
    public void setBody(String body) {
        this._body = body;
    }
}
