package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;

public class FindDocTransReportCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 担当者ID */
    private String _hamId = null;

    /** 媒体コード */
    private String _mediaCd = null;

    /** 期間開始 */
    private Date _termStart;

    /** 期間終了 */
    private Date _termEnd;

    /** コードタイプ(朝夕) */
    private String _codeTypeNp = null;

    /** コードタイプ(部署マスタ) */
    private String _codeTypeDep = null;

    /** キーコード(送稿表) */
    private String _keyCodeDt = null;

    /** 電通車種コード */
    private List<String> _dcarCd = null;

    /** キャンペーン(営業作業台帳) */
    private List<String> _campaign = null;

    /** ダミープロパティ */
    private String _dummy;


    /**
     * 担当者IDを取得する
     *
     * @return 担当者ID
     */
    public String getHamId() {
        return _hamId;
    }

    /**
     * 担当者IDを設定する
     *
     * @param hamid 担当者ID
     */
    public void setHamId(String hamId) {
        this._hamId = hamId;
    }

    /**
     * 媒体コードを取得する
     *
     * @return 媒体コード
     */
    public String getMediaCd() {
        return _mediaCd;
    }

    /**
     * 媒体コードを設定する
     *
     * @param mediaCd 媒体コード
     */
    public void setMediaCd(String mediaCd) {
        _mediaCd = mediaCd;
    }

    /**
     * 期間開始を取得する
     *
     * @return 期間開始
     */
    @XmlElement(required = true, nillable = true)
    public Date getTermStart() {
        return _termStart;
    }

    /**
     * 期間開始を設定する
     *
     * @param termStart 期間開始
     */
    public void setTermStart(Date termStart) {
        _termStart = termStart;
    }

    /**
     * 期間終了を取得する
     *
     * @return 期間終了
     */
    @XmlElement(required = true, nillable = true)
    public Date getTermEnd() {
        return _termEnd;
    }

    /**
     * 期間終了を設定する
     *
     * @param termEnd 期間終了
     */
    public void setTermEnd(Date termEnd) {
        _termEnd = termEnd;
    }

    /**
     * コードタイプ(朝夕)
     *
     * @return コードタイプ(朝夕)
     */
    public String getCodeTypeNp() {
        return _codeTypeNp;
    }

    /**
     * コードタイプ(朝夕)
     *
     * @param codeType コードタイプ(朝夕)
     */
    public void setCodeTypeNp(String codeTypeNp) {
        _codeTypeNp = codeTypeNp;
    }

    /**
     * コードタイプ(部署マスタ)
     *
     * @return コードタイプ(部署マスタ)
     */
    public String getCodeTypeDep() {
        return _codeTypeDep;
    }

    /**
     * コードタイプ(部署マスタ)
     *
     * @param codeTypeDep コードタイプ(部署マスタ)
     */
    public void setCodeTypeDep(String codeTypeDep) {
        _codeTypeDep = codeTypeDep;
    }

    /**
     * キーコード(送稿表)
     *
     * @return キーコード(送稿表)
     */
    public String getKeyCodeDt() {
        return _keyCodeDt;
    }

    /**
     * キーコード(送稿表)
     *
     * @param keyCodeDt キーコード(送稿表)
     */
    public void setKeyCodeDt(String keyCodeDt) {
        _keyCodeDt = keyCodeDt;
    }

    /**
     * 電通車種コードを取得する
     * @return 電通車種コード
     */
    public List<String> getDcarcd() {
        return _dcarCd;
    }

    /**
     * 電通車種コードを設定する
     * @param dcarCd 電通車種コード
     */
    public void setDcarcd(List<String>  dcarCd) {
        _dcarCd = dcarCd;
    }

    /**
     * キャンペーンを取得する
     * @return キャンペーン
     */
    public List<String> getCampaign() {
        return _campaign;
    }

    /**
     * キャンペーンを設定する
     * @param campaign キャンペーン
     */
    public void setCampaign(List<String> campaign) {
        _campaign = campaign;
    }


    /**
     * ダミープロパティを返します
     * @return
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ダミープロパティを設定する
     * @param
     */
    public void setDummy(String dummy) {
        _dummy = dummy;
    }
}
