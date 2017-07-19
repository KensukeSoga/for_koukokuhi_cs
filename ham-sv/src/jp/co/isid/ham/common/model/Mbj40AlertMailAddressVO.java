package jp.co.isid.ham.common.model;

import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Mbj40AlertMailAddress;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * メール配信マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/07/05 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj40AlertMailAddressVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj40AlertMailAddressVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mbj40AlertMailAddressVO();
    }

    /**
     * アラートメール種別を取得する
     *
     * @return アラートメール種別
     */
    public String getMAILTYPE() {
        return (String) get(Mbj40AlertMailAddress.MAILTYPE);
    }

    /**
     * アラートメール種別を設定する
     *
     * @param val アラートメール種別
     */
    public void setMAILTYPE(String val) {
        set(Mbj40AlertMailAddress.MAILTYPE, val);
    }

    /**
     * 担当者IDを取得する
     *
     * @return 担当者ID
     */
    public String getHAMID() {
        return (String) get(Mbj40AlertMailAddress.HAMID);
    }

    /**
     * 担当者IDを設定する
     *
     * @param val 担当者ID
     */
    public void setHAMID(String val) {
        set(Mbj40AlertMailAddress.HAMID, val);
    }

    /**
     * 姓名を取得する
     *
     * @return 姓名
     */
    public String getCN() {
        return (String) get(Mbj40AlertMailAddress.CN);
    }

    /**
     * 姓名を設定する
     *
     * @param val 姓名
     */
    public void setCN(String val) {
        set(Mbj40AlertMailAddress.CN, val);
    }

    /**
     * メールアドレスを取得する
     *
     * @return メールアドレス
     */
    public String getMAIL() {
        return (String) get(Mbj40AlertMailAddress.MAIL);
    }

    /**
     * メールアドレスを設定する
     *
     * @param val メールアドレス
     */
    public void setMAIL(String val) {
        set(Mbj40AlertMailAddress.MAIL, val);
    }

    /**
     * 宛先フラグを取得する
     *
     * @return 宛先フラグ
     */
    public String getSENDTYPE() {
        return (String) get(Mbj40AlertMailAddress.SENDTYPE);
    }

    /**
     * 宛先フラグを設定する
     *
     * @param val 宛先フラグ
     */
    public void setSENDTYPE(String val) {
        set(Mbj40AlertMailAddress.SENDTYPE, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj40AlertMailAddress.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Mbj40AlertMailAddress.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Mbj40AlertMailAddress.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Mbj40AlertMailAddress.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Mbj40AlertMailAddress.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Mbj40AlertMailAddress.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Mbj40AlertMailAddress.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Mbj40AlertMailAddress.UPDID, val);
    }

}
