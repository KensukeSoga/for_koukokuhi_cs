package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;

public class FindDocumentTransmissionCondition implements Serializable {

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

    /** 画面ID */
    private String _formId;

    /** 種別 */
    private String _funcType;

    /** ユーザー種別 */
    private String _userType = null;

    /** 局コード */
    private String _kksikognzuntcd = null;


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
     * 画面IDを取得する
     *
     * @return 画面ID
     */
    public String getFormId() {
        return _formId;
    }

    /**
     * 画面IDを設定する
     *
     * @param formID 画面ID
     */
    public void setFormId(String formId) {
        _formId = formId;
    }

    /**
     * 種別を取得する
     *
     * @return 種別
     */
    public String getFuncType() {
        return _funcType;
    }

    /**
     * 種別を設定する
     *
     * @param funcid 種別
     */
    public void setFuncType(String functype) {
        _funcType = functype;
    }

    /**
     * ユーザ種別を取得する
     *
     * @return ユーザー種別
     */
    public String getUserType() {
        return _userType;
    }

    /**
     * ユーザ種別を設定する
     *
     * @param userType ユーザー種別
     */
    public void setUserType(String userType) {
        _userType = userType;
    }

    /**
     * 局コードを取得する
     *
     * @return 局コード
     */
    public String getKksikognzuntcd()
    {
        return _kksikognzuntcd;
    }

    /**
     * 局コードを設定する
     *
     * @param kksikognzuntcd 局コード
     */
    public void setKksikognzuntcd(String kksikognzuntcd)
    {
        this._kksikognzuntcd = kksikognzuntcd;
    }

}
