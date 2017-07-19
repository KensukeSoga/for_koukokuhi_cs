package jp.co.isid.ham.media.model;

import java.io.Serializable;


public class FindAuthorityAccountBookCondition implements Serializable {

    /** serialVersionUID */
   private static final long serialVersionUID = 1L;

    /** 媒体コード */
    private String _mediaCd;

    /** 車種コード */
    private String _dCarCd;

    /** 期間開始 */
    private String _kikanFrom;

    /** 期間終了 */
    private String _kikanTo;

    /** 媒体種別 */
    private String _mediasNm;

    /** キャンペーン名 */
    private String _campNm;

    /** 担当者ID */
    private String _hamid = null;

    /** 画面ID */
    private String _formID;

    /** シートID */
    private String _viewID;

    /** 種別 */
    private String _functype;

    /** ユーザ種別 */
    private String _usertype = null;

    /** 局コード */
    private String _kksikognzuntcd = null;

    /** セキュリティコード */
    private String _securitycd = null;

    /** 営業所コード */
    private String _egsyocd = null;

    /** コードタイプ(営業所コード) */
    private String _codeTypeEgsyoCd = null;


    /**
     * @return mediaCd
     */
    public String getMediaCd() {
        return _mediaCd;
    }
    /**
     * @param mediaCd セットする mediaCd
     */
    public void setMediaCd(String mediaCd) {
        this._mediaCd = mediaCd;
    }

    /**
     * @return dCarCd
     */
    public String getDCarCd() {
        return _dCarCd;
    }
    /**
     * @param dCarCd セットする dCarCd
     */
    public void setDCarCd(String dCarCd) {
        this._dCarCd = dCarCd;
    }

    /**
     * @return kikanFrom
     */
    public String getKikanFrom() {
        return _kikanFrom;
    }
    /**
     * @param kikanFrom セットする kikanFrom
     */
    public void setKikanFrom(String kikanFrom) {
        this._kikanFrom = kikanFrom;
    }

    /**
     * @return kikanTo
     */
    public String getKikanTo() {
        return _kikanTo;
    }
    /**
     * @param kikanTo セットする kikanTo
     */
    public void setKikanTo(String kikanTo) {
        this._kikanTo = kikanTo;
    }

    /**
     * @return mediasNm
     */
    public String getMediasNm() {
        return _mediasNm;
    }
    /**
     * @param mediasNm セットする mediasNm
     */
    public void setMediasNm(String mediasNm) {
        this._mediasNm = mediasNm;
    }

    /**
     * @return campNm
     */
    public String getCampNm() {
        return _campNm;
    }
    /**
     * @param campNm セットする campNm
     */
    public void setCampNm(String campNm) {
        this._campNm = campNm;
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

    /**
     * @return 画面ID
     */
    public String getFormID() {
        return _formID;
    }

    /**
     * @param formID 画面ID
     */
    public void setFormID(String formID) {
        _formID = formID;
    }

    /**
     * @return シートID
     */
    public String getViewID() {
        return _viewID;
    }

    /**
     * @param formID シートID
     */
    public void setViewID(String viewID) {
        _viewID = viewID;
    }

    /**
     * 種別を取得する
     *
     * @return 種別
     */
    public String getFuncType() {
        return _functype;
    }

    /**
     * 種別を設定する
     *
     * @param funcid 種別
     */
    public void setFuncType(String functype) {
        _functype = functype;
    }

    /**
     * ユーザ種別を取得する
     *
     * @return ユーザ種別
     */
    public String getUsertype() {
        return _usertype;
    }

    /**
     * ユーザ種別を設定する
     *
     * @param usertype ユーザ種別
     */
    public void setUsertype(String usertype) {
        this._usertype = usertype;
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

    /**
     * セキュリティコードを取得する
     *
     * @return セキュリティコード
     */
    public String getSecuritycd()
    {
        return _securitycd;
    }

    /**
     * セキュリティコードを設定する
     *
     * @param securitycd セキュリティコード
     */
    public void setSecuritycd(String securitycd)
    {
        this._securitycd = securitycd;
    }

    /**
     * 営業所コードを取得する
     *
     * @return 営業所コード
     */
    public String getEgsyocd()
    {
        return this._egsyocd;
    }

    /**
     * 営業所コードを設定する
     *
     * @param egsyocd 営業所コード
     */
    public void setEgsyocd(String egsyocd)
    {
        this._egsyocd = egsyocd;
    }

    /**
     * コードタイプ(営業所コード)を取得する
     *
     * @return コードタイプ(営業所コード)
     */
    public String getCodetypeegsyocd() {
        return _codeTypeEgsyoCd;
    }

    /**
     * コードタイプ(営業所コード)を設定する
     *
     * @param codeTypeEgsyoCd コードタイプ(営業所コード)
     */
    public void setCodetypeegsyocd(String codeTypeEgsyoCd) {
        _codeTypeEgsyoCd = codeTypeEgsyoCd;
    }

}
