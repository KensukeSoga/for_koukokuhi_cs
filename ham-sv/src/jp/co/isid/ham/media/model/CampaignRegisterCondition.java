package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;

import jp.co.isid.ham.common.model.Tbj12CampaignVO;

public class CampaignRegisterCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 削除用VO */
    private List<Tbj12CampaignVO> _delVo;

    /** 更新用VO */
    private List<Tbj12CampaignVO> _updVo;

    /**登録用VO */
    private List<Tbj12CampaignVO> _insVo;

    /**データカウント*/
    private int _dataCount;

    /**全レコード内の更新時刻の最新値*/
    private Date _latestDate;

    /**全レコード内の最新更新者*/
    private String _latestPel;

    /** ダミープロパティ */
    private String _dummy;


    /**
     * @return delVo
     */
    public List<Tbj12CampaignVO> getDelVo() {
        return _delVo;
    }
    /**
     * @param delVo セットする delVo
     */
    public void setDelVo(List<Tbj12CampaignVO> delVo) {
        this._delVo = delVo;
    }

    /**
     * @return updVo
     */
    public List<Tbj12CampaignVO> getUpdVo() {
        return _updVo;
    }
    /**
     * @param updVo セットする updVo
     */
    public void setUpdVo(List<Tbj12CampaignVO> updVo) {
        this._updVo = updVo;
    }

    /**
     * @return insVo
     */
    public List<Tbj12CampaignVO> getInsVo() {
        return _insVo;
    }
    /**
     * @param insVo セットする insVo
     */
    public void setInsVo(List<Tbj12CampaignVO> insVo) {
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
     * @return latestPel
     */
    public String getLatestPel() {
        return _latestPel;
    }
    /**
     * @param latestPel セットする latestPel
     */
    public void setLatestPel(String latestPel) {
        this._latestPel = latestPel;
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