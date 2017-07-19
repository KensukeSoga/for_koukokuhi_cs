package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;

import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;

public class TVTImportRegisterVO implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 登録用VO */
    private List<Tbj02EigyoDaichoVO> _insVo;

    /** データカウント*/
    private int _dataCount;

    /** 全レコード内の更新時刻の最新値*/
    private Date _latestDate;

    /** 全レコード内の最新更新者*/
    private String _latestID;

    /** 期間開始 */
    private String _kikanFrom;

    /** 期間終了 */
    private String _kikanTo;

    /** 担当者ID */
    private String _hamid = null;

    /** ダミープロパティ */
    private String _dummy;

    /**
     * @return insVo
     */
    public List<Tbj02EigyoDaichoVO> getInsVo() {
        return _insVo;
    }
    /**
     * @param insVo セットする insVo
     */
    public void setInsVo(List<Tbj02EigyoDaichoVO> insVo) {
        this._insVo = insVo;
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
