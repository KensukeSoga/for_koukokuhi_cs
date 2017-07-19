package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Vbj01AccUser;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 新HAM向けVIEW(個人情報)VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Vbj01AccUserVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public Vbj01AccUserVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new Vbj01AccUserVO();
    }

    /**
     * ESQIDを取得する
     *
     * @return ESQID
     */
    public String getESQID() {
        return (String) get(Vbj01AccUser.ESQID);
    }

    /**
     * ESQIDを設定する
     *
     * @param val ESQID
     */
    public void setESQID(String val) {
        set(Vbj01AccUser.ESQID, val);
    }

    /**
     * 主務/兼務/アプリ所属を取得する
     *
     * @return 主務/兼務/アプリ所属
     */
    public String getPOSTSTATE() {
        return (String) get(Vbj01AccUser.POSTSTATE);
    }

    /**
     * 主務/兼務/アプリ所属を設定する
     *
     * @param val 主務/兼務/アプリ所属
     */
    public void setPOSTSTATE(String val) {
        set(Vbj01AccUser.POSTSTATE, val);
    }

    /**
     * 姓名を取得する
     *
     * @return 姓名
     */
    public String getCN() {
        return (String) get(Vbj01AccUser.CN);
    }

    /**
     * 姓名を設定する
     *
     * @param val 姓名
     */
    public void setCN(String val) {
        set(Vbj01AccUser.CN, val);
    }

    /**
     * 組織コード（意味なし組織ｺｰﾄﾞ）を取得する
     *
     * @return 組織コード（意味なし組織ｺｰﾄﾞ）
     */
    public String getSIKOGNZUNTCD() {
        return (String) get(Vbj01AccUser.SIKOGNZUNTCD);
    }

    /**
     * 組織コード（意味なし組織ｺｰﾄﾞ）を設定する
     *
     * @param val 組織コード（意味なし組織ｺｰﾄﾞ）
     */
    public void setSIKOGNZUNTCD(String val) {
        set(Vbj01AccUser.SIKOGNZUNTCD, val);
    }

    /**
     * メールアドレスを取得する
     *
     * @return メールアドレス
     */
    public String getMAIL() {
        return (String) get(Vbj01AccUser.MAIL);
    }

    /**
     * メールアドレスを設定する
     *
     * @param val メールアドレス
     */
    public void setMAIL(String val) {
        set(Vbj01AccUser.MAIL, val);
    }

    /**
     * 本部コードを取得する
     *
     * @return 本部コード
     */
    public String getHBSIKOGNZUNTCD() {
        return (String) get(Vbj01AccUser.HBSIKOGNZUNTCD);
    }

    /**
     * 本部コードを設定する
     *
     * @param val 本部コード
     */
    public void setHBSIKOGNZUNTCD(String val) {
        set(Vbj01AccUser.HBSIKOGNZUNTCD, val);
    }

    /**
     * 本部名称を取得する
     *
     * @return 本部名称
     */
    public String getHBOU() {
        return (String) get(Vbj01AccUser.HBOU);
    }

    /**
     * 本部名称を設定する
     *
     * @param val 本部名称
     */
    public void setHBOU(String val) {
        set(Vbj01AccUser.HBOU, val);
    }

    /**
     * 局コードを取得する
     *
     * @return 局コード
     */
    public String getKKSIKOGNZUNTCD() {
        return (String) get(Vbj01AccUser.KKSIKOGNZUNTCD);
    }

    /**
     * 局コードを設定する
     *
     * @param val 局コード
     */
    public void setKKSIKOGNZUNTCD(String val) {
        set(Vbj01AccUser.KKSIKOGNZUNTCD, val);
    }

    /**
     * 局名称を取得する
     *
     * @return 局名称
     */
    public String getKKOU() {
        return (String) get(Vbj01AccUser.KKOU);
    }

    /**
     * 局名称を設定する
     *
     * @param val 局名称
     */
    public void setKKOU(String val) {
        set(Vbj01AccUser.KKOU, val);
    }

    /**
     * 室コードを取得する
     *
     * @return 室コード
     */
    public String getHTSIKOGNZUNTCD() {
        return (String) get(Vbj01AccUser.HTSIKOGNZUNTCD);
    }

    /**
     * 室コードを設定する
     *
     * @param val 室コード
     */
    public void setHTSIKOGNZUNTCD(String val) {
        set(Vbj01AccUser.HTSIKOGNZUNTCD, val);
    }

    /**
     * 室名称を取得する
     *
     * @return 室名称
     */
    public String getHTOU() {
        return (String) get(Vbj01AccUser.HTOU);
    }

    /**
     * 室名称を設定する
     *
     * @param val 室名称
     */
    public void setHTOU(String val) {
        set(Vbj01AccUser.HTOU, val);
    }

    /**
     * 部コードを取得する
     *
     * @return 部コード
     */
    public String getBUSIKOGNZUNTCD() {
        return (String) get(Vbj01AccUser.BUSIKOGNZUNTCD);
    }

    /**
     * 部コードを設定する
     *
     * @param val 部コード
     */
    public void setBUSIKOGNZUNTCD(String val) {
        set(Vbj01AccUser.BUSIKOGNZUNTCD, val);
    }

    /**
     * 部名称を取得する
     *
     * @return 部名称
     */
    public String getBUOU() {
        return (String) get(Vbj01AccUser.BUOU);
    }

    /**
     * 部名称を設定する
     *
     * @param val 部名称
     */
    public void setBUOU(String val) {
        set(Vbj01AccUser.BUOU, val);
    }

    /**
     * 課コードを取得する
     *
     * @return 課コード
     */
    public String getKASIKOGNZUNTCD() {
        return (String) get(Vbj01AccUser.KASIKOGNZUNTCD);
    }

    /**
     * 課コードを設定する
     *
     * @param val 課コード
     */
    public void setKASIKOGNZUNTCD(String val) {
        set(Vbj01AccUser.KASIKOGNZUNTCD, val);
    }

    /**
     * 課名称を取得する
     *
     * @return 課名称
     */
    public String getKAOU() {
        return (String) get(Vbj01AccUser.KAOU);
    }

    /**
     * 課名称を設定する
     *
     * @param val 課名称
     */
    public void setKAOU(String val) {
        set(Vbj01AccUser.KAOU, val);
    }

}
