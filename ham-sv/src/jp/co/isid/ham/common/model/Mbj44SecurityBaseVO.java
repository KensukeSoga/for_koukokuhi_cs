package jp.co.isid.ham.common.model;

import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Mbj44SecurityBase;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * セキュリティベースマスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj44SecurityBaseVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj44SecurityBaseVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Mbj44SecurityBaseVO();
    }

    /**
     * 局コードを取得する
     *
     * @return 局コード
     */
    public String getKKSIKOGNZUNTCD() {
        return (String) get(Mbj44SecurityBase.KKSIKOGNZUNTCD);
    }

    /**
     * 局コードを設定する
     *
     * @param val 局コード
     */
    public void setKKSIKOGNZUNTCD(String val) {
        set(Mbj44SecurityBase.KKSIKOGNZUNTCD, val);
    }

    /**
     * ユーザ種別を取得する
     *
     * @return ユーザ種別
     */
    public String getUSERTYPE() {
        return (String) get(Mbj44SecurityBase.USERTYPE);
    }

    /**
     * ユーザ種別を設定する
     *
     * @param val ユーザ種別
     */
    public void setUSERTYPE(String val) {
        set(Mbj44SecurityBase.USERTYPE, val);
    }

    /**
     * セキュリティコードを取得する
     *
     * @return セキュリティコード
     */
    public String getSECURITYCD() {
        return (String) get(Mbj44SecurityBase.SECURITYCD);
    }

    /**
     * セキュリティコードを設定する
     *
     * @param val セキュリティコード
     */
    public void setSECURITYCD(String val) {
        set(Mbj44SecurityBase.SECURITYCD, val);
    }

    /**
     * セキュリティ種別を取得する
     *
     * @return セキュリティ種別
     */
    public String getSECURITYTYPE() {
        return (String) get(Mbj44SecurityBase.SECURITYTYPE);
    }

    /**
     * セキュリティ種別を設定する
     *
     * @param val セキュリティ種別
     */
    public void setSECURITYTYPE(String val) {
        set(Mbj44SecurityBase.SECURITYTYPE, val);
    }

    /**
     * 登録・更新を取得する
     *
     * @return 登録・更新
     */
    public String getUPDATE() {
        return (String) get(Mbj44SecurityBase.UPDATE);
    }

    /**
     * 登録・更新を設定する
     *
     * @param val 登録・更新
     */
    public void setUPDATE(String val) {
        set(Mbj44SecurityBase.UPDATE, val);
    }

    /**
     * 確認を取得する
     *
     * @return 確認
     */
    public String getCHECK() {
        return (String) get(Mbj44SecurityBase.CHECK);
    }

    /**
     * 確認を設定する
     *
     * @param val 確認
     */
    public void setCHECK(String val) {
        set(Mbj44SecurityBase.CHECK, val);
    }

    /**
     * 参照を取得する
     *
     * @return 参照
     */
    public String getREFERENCE() {
        return (String) get(Mbj44SecurityBase.REFERENCE);
    }

    /**
     * 参照を設定する
     *
     * @param val 参照
     */
    public void setREFERENCE(String val) {
        set(Mbj44SecurityBase.REFERENCE, val);
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj44SecurityBase.UPDDATE);
    }

    /**
     * データ更新日時を設定する
     *
     * @param val データ更新日時
     */
    public void setUPDDATE(Date val) {
        set(Mbj44SecurityBase.UPDDATE, val);
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUPDNM() {
        return (String) get(Mbj44SecurityBase.UPDNM);
    }

    /**
     * データ更新者を設定する
     *
     * @param val データ更新者
     */
    public void setUPDNM(String val) {
        set(Mbj44SecurityBase.UPDNM, val);
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUPDAPL() {
        return (String) get(Mbj44SecurityBase.UPDAPL);
    }

    /**
     * 更新プログラムを設定する
     *
     * @param val 更新プログラム
     */
    public void setUPDAPL(String val) {
        set(Mbj44SecurityBase.UPDAPL, val);
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUPDID() {
        return (String) get(Mbj44SecurityBase.UPDID);
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param val 更新担当者ID
     */
    public void setUPDID(String val) {
        set(Mbj44SecurityBase.UPDID, val);
    }

}
