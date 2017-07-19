package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;

public class FindDiscountFlgCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 取引先コード */
    private String _thskgycd;

    /** SEQNO */
    private String _seqNo;

    /** 取引担当SEQNO */
    private String _trtntSeqNo;

    /** 期間開始 */
    private BigDecimal _kikanFrom;

    /** 期間終了 */
    private BigDecimal _kikanTo;

    /** 新雑媒体コード */
    private String _mediaCd;

    /** 県版コード */
    private String _kbanCd;

    /** 業務区分 */
    private String _workFlg;

    /** 営業作業台帳No */
    private String _daichoNo;

    /** 費目 */
    private String _items;

    /**
     * 取引先コード取得
     * @return 取引先コード
     */
    public String getThskgycd() {
       return _thskgycd;
    }

    /**
     * 取引先コード設定
     * @param thskgycd
     */
    public void setThskgycd(String thskgycd) {
        this._thskgycd = thskgycd;
    }

    /**
     * SEQNO取得
     * @return SEQNO設定
     */
    public String getSeqNo() {
        return _seqNo;
    }

    /**
     * SEQNO設定
     * @param seqNo
     */
    public void setSeqNo(String seqNo) {
        this._seqNo = seqNo;
    }

    /**
     * 取引担当SEQNO取得
     * @return
     */
    public String getTrtntSeqNo() {
        return _trtntSeqNo;
    }

    /**
     * 取引担当SEQNO設定
     * @param trtntSeqNo
     */
    public void setTrtntSeqNo(String trtntSeqNo) {
        this._trtntSeqNo = trtntSeqNo;
    }

    /**
     * 期間開始取得
     * @return
     */
    @XmlElement(required = true)
    public BigDecimal getKikanFrom() {
        return _kikanFrom;
    }

    /**
     * 期間開始設定
     * @param kikanFrom
     */
    public void setKikanFrom(BigDecimal kikanFrom) {
        this._kikanFrom = kikanFrom;
    }

    /**
     * 期間終了取得
     * @return
     */
    @XmlElement(required = true)
    public BigDecimal getKikanTo() {
        return _kikanTo;
    }

    /**
     * 期間終了設定
     * @param kikanTo
     */
    public void setKikanTo(BigDecimal kikanTo) {
        this._kikanTo = kikanTo;
    }

    /**
     * 新雑媒体コード取得
     * @return
     */
    public String getMediaCd() {
        return _mediaCd;
    }

    /**
     * 新雑媒体コード設定
     * @param mediaCd
     */
    public void setMediaCd(String mediaCd) {
        this._mediaCd = mediaCd;
    }

    /**
     * 県版コード取得
     * @return
     */
    public String getKbanCd() {
        return _kbanCd;
    }

    /**
     * 県版コード設定
     * @param kbanCd
     */
    public void setKbanCd(String kbanCd) {
        this._kbanCd = kbanCd;
    }

    /**
     * 業務区分取得
     * @return
     */
    public String getWorkFlg() {
        return _workFlg;
    }

    /**
     * 業務区分設定
     * @param workFlg
     */
    public void setWorkFlg(String workFlg) {
        this._workFlg = workFlg;
    }

    /**
     * 営業台帳Noを取得
     * @return
     */
    public String getDaichoNo() {
        return _daichoNo;
    }

    /**
     * 営業台帳Noを設定
     * @param daichoNo
     */
    public void setDaichoNo(String daichoNo) {
        this._daichoNo = daichoNo;
    }

    /**
     * 費目を取得
     * @return
     */
    public String getItems() {
        return _items;
    }

    /**
     * 費目を設定
     * @param items
     */
    public void setItem(String items) {
        this._items = items;
    }
}
