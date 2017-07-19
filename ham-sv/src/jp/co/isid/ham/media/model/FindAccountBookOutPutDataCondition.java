package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;

public class FindAccountBookOutPutDataCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 媒体コード */
    private String _mediacd = null;

    /** 車種コード */
//    private String _dcarcd = null;

    /** フェイズ */
    private BigDecimal _phase = null;

    /** 期間開始 */
    private String _kikanfrom = null;

    /** 期間終了 */
    private String _kikanto = null;

    /** 請求対象フラグ */
    private boolean _seikyuflg;

    /** 期またぎフラグ */
    private boolean _kimatagiflg;

    /** 車種リスト */
    private List<String> _carList = null;

    /** 担当者ID */
    private String _hamid = null;

    /**
     * 媒体コードを取得する
     * @return 媒体コード
     */
    public String getMediacd() {
        return _mediacd;
    }

    /**
     * 媒体コードを設定する
     * @param kikanfrom
     */
    public void setMediacd(String mediacd) {
        this._mediacd = mediacd;
    }

    /**
     * フェイズを取得する
     *
     * @return フェイズ
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * フェイズを設定する
     *
     * @param phase フェイズ
     */
    public void setPhase(BigDecimal phase) {
        this._phase = phase;
    }

    /**
     * 期間開始を取得する
     * @return 期間開始
     */
    public String getKikanfrom() {
        return _kikanfrom;
    }

    /**
     * 期間開始を設定する
     * @param kikanfrom
     */
    public void setKikanfrom(String kikanfrom) {
        this._kikanfrom = kikanfrom;
    }

    /**
     * 期間終了を取得する
     * @return 期間終了
     */
    public String getKikanto() {
        return _kikanto;
    }

    /**
     * 期間終了を設定する
     * @param kikanfrom
     */
    public void setKikanto(String kikanto) {
        this._kikanto = kikanto;
    }

    /**
     * 請求対象フラグを取得する
     * @return 請求対象フラグ
     */
    public boolean getSeikyuflg() {
        return _seikyuflg;
    }

    /**
     * 請求対象フラグを設定する
     * @param seikyuflg
     */
    public void setSeikyuflg(boolean seikyuflg) {
        this._seikyuflg = seikyuflg;
    }

    /**
     * 期またぎフラグを取得する
     * @return 期またぎフラグ
     */
    public boolean getKimatagiflg() {
        return _kimatagiflg;
    }

    /**
     * 期またぎフラグを設定する
     * @param seikyuflg
     */
    public void setKimatagiflg(boolean kimatagiflg) {
        this._kimatagiflg = kimatagiflg;
    }

    /**
     * 車種リストを取得する
     *
     * @return carList
     */
    public List<String> getCarList() {
        return _carList;
    }

    /**
     * 車種リストを設定する
     * @param carList 車種リスト
     */
    public void setCarList(List<String> carList) {
        this._carList = carList;
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
