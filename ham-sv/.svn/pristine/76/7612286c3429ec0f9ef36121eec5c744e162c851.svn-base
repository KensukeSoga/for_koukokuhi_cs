package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 媒体検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/10 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class MediaListCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 媒体コード */
    private String _mediacd = null;

    /** 媒体名 */
    private String _medianm = null;

    /** 媒体名（媒体費作成用） */
    private String _hcmedianm = null;

    /** 電通値引率 */
    private BigDecimal _dnebiki = null;

    /** ソートNo */
    private BigDecimal _sortno = null;

    /** 権限 */
    private String _authority = null;

    /** 担当者ID */
    private String _hamid = null;

    /**
     * デフォルトコンストラクタ
     */
    public MediaListCondition() {
    }


    /**
     * 媒体コードを取得する
     *
     * @return 媒体コード
     */
    public String getMediacd() {
        return _mediacd;
    }

    /**
     * 媒体コードを設定する
     *
     * @param mediacd 媒体コード
     */
    public void setMediacd(String mediacd) {
        this._mediacd = mediacd;
    }

    /**
     * 媒体名を取得する
     *
     * @return 媒体名
     */
    public String getMedianm() {
        return _medianm;
    }

    /**
     * 媒体名を設定する
     *
     * @param medianm 媒体名
     */
    public void setMedianm(String medianm) {
        this._medianm = medianm;
    }

    /**
     * 媒体名（媒体費作成用）を取得する
     *
     * @return 媒体名（媒体費作成用）
     */
    public String getHcmedianm() {
        return _hcmedianm;
    }

    /**
     * 媒体名（媒体費作成用）を設定する
     *
     * @param hcmedianm 媒体名（媒体費作成用）
     */
    public void setHcmedianm(String hcmedianm) {
        this._hcmedianm = hcmedianm;
    }

    /**
     * 電通値引率を取得する
     *
     * @return 電通値引率
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDnebiki() {
        return _dnebiki;
    }

    /**
     * 電通値引率を設定する
     *
     * @param dnebiki 電通値引率
     */
    public void setDnebiki(BigDecimal dnebiki) {
        this._dnebiki = dnebiki;
    }

    /**
     * ソートNoを取得する
     *
     * @return ソートNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSortno() {
        return _sortno;
    }

    /**
     * ソートNoを設定する
     *
     * @param sortno ソートNo
     */
    public void setSortno(BigDecimal sortno) {
        this._sortno = sortno;
    }

    /**
     * 権限を取得する
     *
     * @return 権限
     */
    public String getAuthority() {
        return _authority;
    }

    /**
     * 権限を設定する
     *
     * @param authority 権限
     */
    public void setAuthority(String authority) {
        this._authority = authority;
    }

    /**
     * 担当者IDを取得する
     *
     * @return 担当者ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * 担当者IDを設定する
     *
     * @param hamid 担当者ID
     */
    public void setHamid(String hamid) {
        this._hamid = hamid;
    }
}
