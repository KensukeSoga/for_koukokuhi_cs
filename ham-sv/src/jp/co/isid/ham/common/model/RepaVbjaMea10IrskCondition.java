package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 発注先マスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMea10IrskCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** IRSKCD */
    private String _irskcd = null;

    /** IRSKSUBCD */
    private String _irsksubcd = null;

    /** IRSKALASHYOJIKN */
    private String _irskalashyojikn = null;

    /** IRSKALASHYOJIKJ */
    private String _irskalashyojikj = null;

    /** TKALASHYOJIKN */
    private String _tkalashyojikn = null;

    /** TKALASHYOJIKJ */
    private String _tkalashyojikj = null;

    /** ATSHONBCD */
    private String _atshonbcd = null;

    /** ALASUSEFLG */
    private String _alasuseflg = null;

    /** TKALASUSEFLG */
    private String _tkalasuseflg = null;

    /** HOSOK */
    private String _hosok = null;

    /** HKYMD */
    private String _hkymd = null;

    /** HAISYMD */
    private String _haisymd = null;

    /** INSDATE */
    private Date _insdate = null;

    /** INSTNTCD */
    private String _instntcd = null;

    /** INSAPLID */
    private String _insaplid = null;

    /** UPDAPLDATE */
    private Date _updapldate = null;

    /** UPDTNTCD */
    private String _updtntcd = null;

    /** UPDONLAPLID */
    private String _updonlaplid = null;

    /** UPDBATAPLID */
    private String _updbataplid = null;

    /**
     * デフォルトコンストラクタ
     */
    public RepaVbjaMea10IrskCondition() {
    }

    /**
     * IRSKCDを取得する
     *
     * @return IRSKCD
     */
    public String getIrskcd() {
        return _irskcd;
    }

    /**
     * IRSKCDを設定する
     *
     * @param irskcd IRSKCD
     */
    public void setIrskcd(String irskcd) {
        this._irskcd = irskcd;
    }

    /**
     * IRSKSUBCDを取得する
     *
     * @return IRSKSUBCD
     */
    public String getIrsksubcd() {
        return _irsksubcd;
    }

    /**
     * IRSKSUBCDを設定する
     *
     * @param irsksubcd IRSKSUBCD
     */
    public void setIrsksubcd(String irsksubcd) {
        this._irsksubcd = irsksubcd;
    }

    /**
     * IRSKALASHYOJIKNを取得する
     *
     * @return IRSKALASHYOJIKN
     */
    public String getIrskalashyojikn() {
        return _irskalashyojikn;
    }

    /**
     * IRSKALASHYOJIKNを設定する
     *
     * @param irskalashyojikn IRSKALASHYOJIKN
     */
    public void setIrskalashyojikn(String irskalashyojikn) {
        this._irskalashyojikn = irskalashyojikn;
    }

    /**
     * IRSKALASHYOJIKJを取得する
     *
     * @return IRSKALASHYOJIKJ
     */
    public String getIrskalashyojikj() {
        return _irskalashyojikj;
    }

    /**
     * IRSKALASHYOJIKJを設定する
     *
     * @param irskalashyojikj IRSKALASHYOJIKJ
     */
    public void setIrskalashyojikj(String irskalashyojikj) {
        this._irskalashyojikj = irskalashyojikj;
    }

    /**
     * TKALASHYOJIKNを取得する
     *
     * @return TKALASHYOJIKN
     */
    public String getTkalashyojikn() {
        return _tkalashyojikn;
    }

    /**
     * TKALASHYOJIKNを設定する
     *
     * @param tkalashyojikn TKALASHYOJIKN
     */
    public void setTkalashyojikn(String tkalashyojikn) {
        this._tkalashyojikn = tkalashyojikn;
    }

    /**
     * TKALASHYOJIKJを取得する
     *
     * @return TKALASHYOJIKJ
     */
    public String getTkalashyojikj() {
        return _tkalashyojikj;
    }

    /**
     * TKALASHYOJIKJを設定する
     *
     * @param tkalashyojikj TKALASHYOJIKJ
     */
    public void setTkalashyojikj(String tkalashyojikj) {
        this._tkalashyojikj = tkalashyojikj;
    }

    /**
     * ATSHONBCDを取得する
     *
     * @return ATSHONBCD
     */
    public String getAtshonbcd() {
        return _atshonbcd;
    }

    /**
     * ATSHONBCDを設定する
     *
     * @param atshonbcd ATSHONBCD
     */
    public void setAtshonbcd(String atshonbcd) {
        this._atshonbcd = atshonbcd;
    }

    /**
     * ALASUSEFLGを取得する
     *
     * @return ALASUSEFLG
     */
    public String getAlasuseflg() {
        return _alasuseflg;
    }

    /**
     * ALASUSEFLGを設定する
     *
     * @param alasuseflg ALASUSEFLG
     */
    public void setAlasuseflg(String alasuseflg) {
        this._alasuseflg = alasuseflg;
    }

    /**
     * TKALASUSEFLGを取得する
     *
     * @return TKALASUSEFLG
     */
    public String getTkalasuseflg() {
        return _tkalasuseflg;
    }

    /**
     * TKALASUSEFLGを設定する
     *
     * @param tkalasuseflg TKALASUSEFLG
     */
    public void setTkalasuseflg(String tkalasuseflg) {
        this._tkalasuseflg = tkalasuseflg;
    }

    /**
     * HOSOKを取得する
     *
     * @return HOSOK
     */
    public String getHosok() {
        return _hosok;
    }

    /**
     * HOSOKを設定する
     *
     * @param hosok HOSOK
     */
    public void setHosok(String hosok) {
        this._hosok = hosok;
    }

    /**
     * HKYMDを取得する
     *
     * @return HKYMD
     */
    public String getHkymd() {
        return _hkymd;
    }

    /**
     * HKYMDを設定する
     *
     * @param hkymd HKYMD
     */
    public void setHkymd(String hkymd) {
        this._hkymd = hkymd;
    }

    /**
     * HAISYMDを取得する
     *
     * @return HAISYMD
     */
    public String getHaisymd() {
        return _haisymd;
    }

    /**
     * HAISYMDを設定する
     *
     * @param haisymd HAISYMD
     */
    public void setHaisymd(String haisymd) {
        this._haisymd = haisymd;
    }

    /**
     * INSDATEを取得する
     *
     * @return INSDATE
     */
    @XmlElement(required = true, nillable = true)
    public Date getInsdate() {
        return _insdate;
    }

    /**
     * INSDATEを設定する
     *
     * @param insdate INSDATE
     */
    public void setInsdate(Date insdate) {
        this._insdate = insdate;
    }

    /**
     * INSTNTCDを取得する
     *
     * @return INSTNTCD
     */
    public String getInstntcd() {
        return _instntcd;
    }

    /**
     * INSTNTCDを設定する
     *
     * @param instntcd INSTNTCD
     */
    public void setInstntcd(String instntcd) {
        this._instntcd = instntcd;
    }

    /**
     * INSAPLIDを取得する
     *
     * @return INSAPLID
     */
    public String getInsaplid() {
        return _insaplid;
    }

    /**
     * INSAPLIDを設定する
     *
     * @param insaplid INSAPLID
     */
    public void setInsaplid(String insaplid) {
        this._insaplid = insaplid;
    }

    /**
     * UPDAPLDATEを取得する
     *
     * @return UPDAPLDATE
     */
    @XmlElement(required = true, nillable = true)
    public Date getUpdapldate() {
        return _updapldate;
    }

    /**
     * UPDAPLDATEを設定する
     *
     * @param updapldate UPDAPLDATE
     */
    public void setUpdapldate(Date updapldate) {
        this._updapldate = updapldate;
    }

    /**
     * UPDTNTCDを取得する
     *
     * @return UPDTNTCD
     */
    public String getUpdtntcd() {
        return _updtntcd;
    }

    /**
     * UPDTNTCDを設定する
     *
     * @param updtntcd UPDTNTCD
     */
    public void setUpdtntcd(String updtntcd) {
        this._updtntcd = updtntcd;
    }

    /**
     * UPDONLAPLIDを取得する
     *
     * @return UPDONLAPLID
     */
    public String getUpdonlaplid() {
        return _updonlaplid;
    }

    /**
     * UPDONLAPLIDを設定する
     *
     * @param updonlaplid UPDONLAPLID
     */
    public void setUpdonlaplid(String updonlaplid) {
        this._updonlaplid = updonlaplid;
    }

    /**
     * UPDBATAPLIDを取得する
     *
     * @return UPDBATAPLID
     */
    public String getUpdbataplid() {
        return _updbataplid;
    }

    /**
     * UPDBATAPLIDを設定する
     *
     * @param updbataplid UPDBATAPLID
     */
    public void setUpdbataplid(String updbataplid) {
        this._updbataplid = updbataplid;
    }

}
