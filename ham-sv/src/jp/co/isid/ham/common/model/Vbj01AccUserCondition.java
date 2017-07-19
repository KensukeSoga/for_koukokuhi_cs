package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 新HAM向けVIEW(個人情報)検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Vbj01AccUserCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ESQID */
    private String _esqid = null;

    /** 主務/兼務/アプリ所属 */
    private String _poststate = null;

    /** 姓名 */
    private String _cn = null;

    /** 組織コード（意味なし組織ｺｰﾄﾞ） */
    private String _sikognzuntcd = null;

    /** メールアドレス */
    private String _mail = null;

    /** 本部コード */
    private String _hbsikognzuntcd = null;

    /** 本部名称 */
    private String _hbou = null;

    /** 局コード */
    private String _kksikognzuntcd = null;

    /** 局名称 */
    private String _kkou = null;

    /** 室コード */
    private String _htsikognzuntcd = null;

    /** 室名称 */
    private String _htou = null;

    /** 部コード */
    private String _busikognzuntcd = null;

    /** 部名称 */
    private String _buou = null;

    /** 課コード */
    private String _kasikognzuntcd = null;

    /** 課名称 */
    private String _kaou = null;

    /**
     * デフォルトコンストラクタ
     */
    public Vbj01AccUserCondition() {
    }

    /**
     * ESQIDを取得する
     *
     * @return ESQID
     */
    public String getEsqid() {
        return _esqid;
    }

    /**
     * ESQIDを設定する
     *
     * @param esqid ESQID
     */
    public void setEsqid(String esqid) {
        this._esqid = esqid;
    }

    /**
     * 主務/兼務/アプリ所属を取得する
     *
     * @return 主務/兼務/アプリ所属
     */
    public String getPoststate() {
        return _poststate;
    }

    /**
     * 主務/兼務/アプリ所属を設定する
     *
     * @param poststate 主務/兼務/アプリ所属
     */
    public void setPoststate(String poststate) {
        this._poststate = poststate;
    }

    /**
     * 姓名を取得する
     *
     * @return 姓名
     */
    public String getCn() {
        return _cn;
    }

    /**
     * 姓名を設定する
     *
     * @param cn 姓名
     */
    public void setCn(String cn) {
        this._cn = cn;
    }

    /**
     * 組織コード（意味なし組織ｺｰﾄﾞ）を取得する
     *
     * @return 組織コード（意味なし組織ｺｰﾄﾞ）
     */
    public String getSikognzuntcd() {
        return _sikognzuntcd;
    }

    /**
     * 組織コード（意味なし組織ｺｰﾄﾞ）を設定する
     *
     * @param sikognzuntcd 組織コード（意味なし組織ｺｰﾄﾞ）
     */
    public void setSikognzuntcd(String sikognzuntcd) {
        this._sikognzuntcd = sikognzuntcd;
    }

    /**
     * メールアドレスを取得する
     *
     * @return メールアドレス
     */
    public String getMail() {
        return _mail;
    }

    /**
     * メールアドレスを設定する
     *
     * @param mail メールアドレス
     */
    public void setMail(String mail) {
        this._mail = mail;
    }

    /**
     * 本部コードを取得する
     *
     * @return 本部コード
     */
    public String getHbsikognzuntcd() {
        return _hbsikognzuntcd;
    }

    /**
     * 本部コードを設定する
     *
     * @param hbsikognzuntcd 本部コード
     */
    public void setHbsikognzuntcd(String hbsikognzuntcd) {
        this._hbsikognzuntcd = hbsikognzuntcd;
    }

    /**
     * 本部名称を取得する
     *
     * @return 本部名称
     */
    public String getHbou() {
        return _hbou;
    }

    /**
     * 本部名称を設定する
     *
     * @param hbou 本部名称
     */
    public void setHbou(String hbou) {
        this._hbou = hbou;
    }

    /**
     * 局コードを取得する
     *
     * @return 局コード
     */
    public String getKksikognzuntcd() {
        return _kksikognzuntcd;
    }

    /**
     * 局コードを設定する
     *
     * @param kksikognzuntcd 局コード
     */
    public void setKksikognzuntcd(String kksikognzuntcd) {
        this._kksikognzuntcd = kksikognzuntcd;
    }

    /**
     * 局名称を取得する
     *
     * @return 局名称
     */
    public String getKkou() {
        return _kkou;
    }

    /**
     * 局名称を設定する
     *
     * @param kkou 局名称
     */
    public void setKkou(String kkou) {
        this._kkou = kkou;
    }

    /**
     * 室コードを取得する
     *
     * @return 室コード
     */
    public String getHtsikognzuntcd() {
        return _htsikognzuntcd;
    }

    /**
     * 室コードを設定する
     *
     * @param htsikognzuntcd 室コード
     */
    public void setHtsikognzuntcd(String htsikognzuntcd) {
        this._htsikognzuntcd = htsikognzuntcd;
    }

    /**
     * 室名称を取得する
     *
     * @return 室名称
     */
    public String getHtou() {
        return _htou;
    }

    /**
     * 室名称を設定する
     *
     * @param htou 室名称
     */
    public void setHtou(String htou) {
        this._htou = htou;
    }

    /**
     * 部コードを取得する
     *
     * @return 部コード
     */
    public String getBusikognzuntcd() {
        return _busikognzuntcd;
    }

    /**
     * 部コードを設定する
     *
     * @param busikognzuntcd 部コード
     */
    public void setBusikognzuntcd(String busikognzuntcd) {
        this._busikognzuntcd = busikognzuntcd;
    }

    /**
     * 部名称を取得する
     *
     * @return 部名称
     */
    public String getBuou() {
        return _buou;
    }

    /**
     * 部名称を設定する
     *
     * @param buou 部名称
     */
    public void setBuou(String buou) {
        this._buou = buou;
    }

    /**
     * 課コードを取得する
     *
     * @return 課コード
     */
    public String getKasikognzuntcd() {
        return _kasikognzuntcd;
    }

    /**
     * 課コードを設定する
     *
     * @param kasikognzuntcd 課コード
     */
    public void setKasikognzuntcd(String kasikognzuntcd) {
        this._kasikognzuntcd = kasikognzuntcd;
    }

    /**
     * 課名称を取得する
     *
     * @return 課名称
     */
    public String getKaou() {
        return _kaou;
    }

    /**
     * 課名称を設定する
     *
     * @param kaou 課名称
     */
    public void setKaou(String kaou) {
        this._kaou = kaou;
    }

}
