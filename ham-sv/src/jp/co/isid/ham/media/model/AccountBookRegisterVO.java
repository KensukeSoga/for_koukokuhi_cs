package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;
import javax.xml.bind.annotation.XmlElement;

public class AccountBookRegisterVO implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 削除用VO */
    private List<FindAuthorityAccountBookVO> _delVo;

    /** 更新用VO */
    private List<FindAuthorityAccountBookVO> _updVo;

    /** 登録用VO */
    private List<FindAuthorityAccountBookVO> _insVo;

    /** 更新対象の媒体状況管理NO */
    private List<String> _mediaPlanNO;

    /**データカウント*/
    private int _dataCount;

    /**全レコード内の更新時刻の最新値*/
    private Date _latestDate;

    /**全レコード内の最新更新者*/
    private String _latestID;

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

    /** ソート順付番開始期間 */
    private Date _sortFrom;

    /** ソート順付番終了期間 */
    private Date _sortTo;

    /** ダミープロパティ */
    private String _dummy;


    /**
     * @return delVo
     */
    public List<FindAuthorityAccountBookVO> getDelVo() {
        return _delVo;
    }
    /**
     * @param delVo セットする delVo
     */
    public void setDelVo(List<FindAuthorityAccountBookVO> delVo) {
        this._delVo = delVo;
    }

    /**
     * @return updVo
     */
    public List<FindAuthorityAccountBookVO> getUpdVo() {
        return _updVo;
    }
    /**
     * @param updVo セットする updVo
     */
    public void setUpdVo(List<FindAuthorityAccountBookVO> updVo) {
        this._updVo = updVo;
    }

    /**
     * @return insVo
     */
    public List<FindAuthorityAccountBookVO> getInsVo() {
        return _insVo;
    }
    /**
     * @param insVo セットする insVo
     */
    public void setInsVo(List<FindAuthorityAccountBookVO> insVo) {
        this._insVo = insVo;
    }

    /**
     * 媒体状況管理NOリストを取得
     * @return
     */
    public List<String> getMediaPlanNO() {
        return _mediaPlanNO;
    }

    /**
     * 媒体状況管理NOリストを設定
     * @param mediaPlanNO
     */
    public void setMediaPlanNO(List<String> mediaPlanNO) {
        this._mediaPlanNO = mediaPlanNO;
    }

    /**
     * @return dataCount
     */
    public int getDataCount() {
        return _dataCount;
    }
    /**
     * @param dataCount セットする dataCount
     */
    public void setDataCount(int dataCount) {
        this._dataCount = dataCount;
    }

    /**
     * _latestDate
     *
     * @return _latestDate
     */
    @XmlElement(required = true)
    public Date getLatestDate() {
        return _latestDate;
    }

    /**
     * _latestDate
     *
     * @param _latestDate データ更新日時
     */
    public void setLatestDate(Date latestDate) {
        this._latestDate = latestDate;
    }


    /**
     * @return latestID
     */
    public String getLatestID() {
        return _latestID;
    }
    /**
     * @param latestID セットする latestID
     */
    public void setLatestID(String latestID) {
        this._latestID = latestID;
    }

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
     * ソート順付番開始期間を取得する
     * @return ソート順
     */
    @XmlElement(required = true, nillable = true)
    public Date getSortFrom() {
        return _sortFrom;
    }

    /**
     * ソート順付番開始期間を設定する
     * @param sortFrom ソート順
     */
    public void setSortFrom(Date sortFrom) {
        _sortFrom = sortFrom;
    }

    /**
     * ソート順付番終了期間を取得する
     * @return ソート順
     */
    @XmlElement(required = true, nillable = true)
    public Date getSortTo() {
        return _sortTo;
    }

    /**
     * ソート順付番終了期間を設定する
     * @param sortTo ソート順
     */
    public void setSortTo(Date sortTo) {
        _sortTo = sortTo;
    }

    /**
     * ダミープロパティを返します
     * @return
     */
    public String get_dummy() {
        return _dummy;
    }

    /**
     * ダミープロパティを設定する
     * @param
     */
    public void set_dummy(String dummy) {
        _dummy = dummy;
    }

}
