package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * HC部門マスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj06HcBumonCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** HC部門コード */
    private String _hcbumoncd = null;

    /** 使用部門コード */
    private String _usebumoncd = null;

    /** HC部門名 */
    private String _hcbumonnm = null;

    /** 郵便番号 */
    private String _postno = null;

    /** 住所１ */
    private String _address1 = null;

    /** 住所２ */
    private String _address2 = null;

    /** 部門会社名 */
    private String _bumoncorpnm = null;

    /** ソートNO */
    private BigDecimal _sortno = null;

    /** 媒体費データ設定フラグ */
    private String _mediaflg = null;

    /** データ更新日時 */
    private Date _upddate = null;

    /** データ更新者 */
    private String _updnm = null;

    /** 更新プログラム */
    private String _updapl = null;

    /** 更新担当者ID */
    private String _updid = null;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj06HcBumonCondition() {
    }

    /**
     * HC部門コードを取得する
     *
     * @return HC部門コード
     */
    public String getHcbumoncd() {
        return _hcbumoncd;
    }

    /**
     * HC部門コードを設定する
     *
     * @param hcbumoncd HC部門コード
     */
    public void setHcbumoncd(String hcbumoncd) {
        this._hcbumoncd = hcbumoncd;
    }

    /**
     * 使用部門コードを取得する
     *
     * @return 使用部門コード
     */
    public String getUsebumoncd() {
        return _usebumoncd;
    }

    /**
     * 使用部門コードを設定する
     *
     * @param usebumoncd 使用部門コード
     */
    public void setUsebumoncd(String usebumoncd) {
        this._usebumoncd = usebumoncd;
    }

    /**
     * HC部門名を取得する
     *
     * @return HC部門名
     */
    public String getHcbumonnm() {
        return _hcbumonnm;
    }

    /**
     * HC部門名を設定する
     *
     * @param hcbumonnm HC部門名
     */
    public void setHcbumonnm(String hcbumonnm) {
        this._hcbumonnm = hcbumonnm;
    }

    /**
     * 郵便番号を取得する
     *
     * @return 郵便番号
     */
    public String getPostno() {
        return _postno;
    }

    /**
     * 郵便番号を設定する
     *
     * @param postno 郵便番号
     */
    public void setPostno(String postno) {
        this._postno = postno;
    }

    /**
     * 住所１を取得する
     *
     * @return 住所１
     */
    public String getAddress1() {
        return _address1;
    }

    /**
     * 住所１を設定する
     *
     * @param address1 住所１
     */
    public void setAddress1(String address1) {
        this._address1 = address1;
    }

    /**
     * 住所２を取得する
     *
     * @return 住所２
     */
    public String getAddress2() {
        return _address2;
    }

    /**
     * 住所２を設定する
     *
     * @param address2 住所２
     */
    public void setAddress2(String address2) {
        this._address2 = address2;
    }

    /**
     * 部門会社名を取得する
     *
     * @return 部門会社名
     */
    public String getBumoncorpnm() {
        return _bumoncorpnm;
    }

    /**
     * 部門会社名を設定する
     *
     * @param bumoncorpnm 部門会社名
     */
    public void setBumoncorpnm(String bumoncorpnm) {
        this._bumoncorpnm = bumoncorpnm;
    }

    /**
     * ソートNOを取得する
     *
     * @return ソートNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSortno() {
        return _sortno;
    }

    /**
     * ソートNOを設定する
     *
     * @param sortno ソートNO
     */
    public void setSortno(BigDecimal sortno) {
        this._sortno = sortno;
    }

    /**
     * 媒体費データ設定フラグを取得する
     *
     * @return 媒体費データ設定フラグ
     */
    public String getMediaflg() {
        return _mediaflg;
    }

    /**
     * 媒体費データ設定フラグを設定する
     *
     * @param mediaflg 媒体費データ設定フラグ
     */
    public void setMediaflg(String mediaflg) {
        this._mediaflg = mediaflg;
    }

    /**
     * データ更新日時を取得する
     *
     * @return データ更新日時
     */
    @XmlElement(required = true, nillable = true)
    public Date getUpddate() {
        return _upddate;
    }

    /**
     * データ更新日時を設定する
     *
     * @param upddate データ更新日時
     */
    public void setUpddate(Date upddate) {
        this._upddate = upddate;
    }

    /**
     * データ更新者を取得する
     *
     * @return データ更新者
     */
    public String getUpdnm() {
        return _updnm;
    }

    /**
     * データ更新者を設定する
     *
     * @param updnm データ更新者
     */
    public void setUpdnm(String updnm) {
        this._updnm = updnm;
    }

    /**
     * 更新プログラムを取得する
     *
     * @return 更新プログラム
     */
    public String getUpdapl() {
        return _updapl;
    }

    /**
     * 更新プログラムを設定する
     *
     * @param updapl 更新プログラム
     */
    public void setUpdapl(String updapl) {
        this._updapl = updapl;
    }

    /**
     * 更新担当者IDを取得する
     *
     * @return 更新担当者ID
     */
    public String getUpdid() {
        return _updid;
    }

    /**
     * 更新担当者IDを設定する
     *
     * @param updid 更新担当者ID
     */
    public void setUpdid(String updid) {
        this._updid = updid;
    }

}
