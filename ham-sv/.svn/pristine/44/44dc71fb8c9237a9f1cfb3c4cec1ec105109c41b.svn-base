package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;

public class ExcelOutSettingRegisterVO implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 出力車種用VO */
    private List<Mbj13CarOutCtrlVO> _carVO;

    /** 出力媒体用VO */
    private List<Mbj14MediaOutCtrlVO> _mediaVO;

    /** 登録対象の帳票コード */
    private String _reportCd;

    /** 登録対象のフェイズ */
    private BigDecimal _phase;

    /**全レコード内の更新時刻の最新値*/
    private Date _latestDate;

    /**全レコード内の最新更新者*/
    private String _latestID;

    /**全レコード数*/
    private String _dataCnt;

    /** ダミープロパティ */
    private String _dummy;

    /**
     * 車種出力を取得します
     * @return 車種出力項目
     */
    public List<Mbj13CarOutCtrlVO> getMbj13CarOutCtrlVO() {
        return _carVO;
    }

    /**
     * 車種出力を設定します
     * @param carVO
     */
    public void setMbj13CarOutCtrlVO(List<Mbj13CarOutCtrlVO> carVO) {
        _carVO = carVO;
    }

    /**
     * 媒体出力を取得します
     * @return
     */
    public List<Mbj14MediaOutCtrlVO> getMbj14MediaOutCtrlVO() {
        return _mediaVO;
    }

    /**
     * 媒体出力を設定します
     * @param mediaVO
     */
    public void setMbj14MediaOutCtrlVO(List<Mbj14MediaOutCtrlVO> mediaVO) {
        _mediaVO = mediaVO;
    }

    /**
     * 帳票コードを取得します
     * @return
     */
    public String getReportCd() {
        return _reportCd;
    }

    /**
     * 帳票コードを設定します
     * @param reportCd
     */
    public void setReportCd(String reportCd) {
        _reportCd = reportCd;
    }

    /**
     * フェイズを取得します
     * @return
     */
    @XmlElement(required = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定します
     * @param phase
     */
    public void setPhase(BigDecimal phase) {
        _phase = phase;
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
     * @return _latestID
     */
    public String getLatestID() {
        return _latestID;
    }
    /**
     * @param _latestID セットする _latestID
     */
    public void setLatestID(String latestID) {
        this._latestID = latestID;
    }

    /**
     * @return _dataCnt
     */
    public String getDataCnt() {
        return _dataCnt;
    }
    /**
     * @param _dataCnt セットする _dataCnt
     */
    public void setDataCnt(String dataCnt) {
        this._dataCnt = dataCnt;
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
