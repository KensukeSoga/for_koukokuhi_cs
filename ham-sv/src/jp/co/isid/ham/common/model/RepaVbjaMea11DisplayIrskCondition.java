package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 画面－発注先マスタ検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMea11DisplayIrskCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ATSEGSYOCD */
    private String _atsegsyocd = null;

    /** JYUCTYPE */
    private String _jyuctype = null;

    /** IRSKCD */
    private String _irskcd = null;

    /** IRSKSUBCD */
    private String _irsksubcd = null;

    /** IRIKYKSHOWNO */
    private String _irikykshowno = null;

    /** IRSKSHOWNO */
    private String _irskshowno = null;

    /** KISEKBN */
    private String _kisekbn = null;

    /** DSIKKBNCD */
    private String _dsikkbncd = null;

    /** JYUCFLG */
    private String _jyucflg = null;

    /** TKFLG */
    private String _tkflg = null;

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
    public RepaVbjaMea11DisplayIrskCondition() {
    }

    /**
     * ATSEGSYOCDを取得する
     *
     * @return ATSEGSYOCD
     */
    public String getAtsegsyocd() {
        return _atsegsyocd;
    }

    /**
     * ATSEGSYOCDを設定する
     *
     * @param atsegsyocd ATSEGSYOCD
     */
    public void setAtsegsyocd(String atsegsyocd) {
        this._atsegsyocd = atsegsyocd;
    }

    /**
     * JYUCTYPEを取得する
     *
     * @return JYUCTYPE
     */
    public String getJyuctype() {
        return _jyuctype;
    }

    /**
     * JYUCTYPEを設定する
     *
     * @param jyuctype JYUCTYPE
     */
    public void setJyuctype(String jyuctype) {
        this._jyuctype = jyuctype;
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
     * IRIKYKSHOWNOを取得する
     *
     * @return IRIKYKSHOWNO
     */
    public String getIrikykshowno() {
        return _irikykshowno;
    }

    /**
     * IRIKYKSHOWNOを設定する
     *
     * @param irikykshowno IRIKYKSHOWNO
     */
    public void setIrikykshowno(String irikykshowno) {
        this._irikykshowno = irikykshowno;
    }

    /**
     * IRSKSHOWNOを取得する
     *
     * @return IRSKSHOWNO
     */
    public String getIrskshowno() {
        return _irskshowno;
    }

    /**
     * IRSKSHOWNOを設定する
     *
     * @param irskshowno IRSKSHOWNO
     */
    public void setIrskshowno(String irskshowno) {
        this._irskshowno = irskshowno;
    }

    /**
     * KISEKBNを取得する
     *
     * @return KISEKBN
     */
    public String getKisekbn() {
        return _kisekbn;
    }

    /**
     * KISEKBNを設定する
     *
     * @param kisekbn KISEKBN
     */
    public void setKisekbn(String kisekbn) {
        this._kisekbn = kisekbn;
    }

    /**
     * DSIKKBNCDを取得する
     *
     * @return DSIKKBNCD
     */
    public String getDsikkbncd() {
        return _dsikkbncd;
    }

    /**
     * DSIKKBNCDを設定する
     *
     * @param dsikkbncd DSIKKBNCD
     */
    public void setDsikkbncd(String dsikkbncd) {
        this._dsikkbncd = dsikkbncd;
    }

    /**
     * JYUCFLGを取得する
     *
     * @return JYUCFLG
     */
    public String getJyucflg() {
        return _jyucflg;
    }

    /**
     * JYUCFLGを設定する
     *
     * @param jyucflg JYUCFLG
     */
    public void setJyucflg(String jyucflg) {
        this._jyucflg = jyucflg;
    }

    /**
     * TKFLGを取得する
     *
     * @return TKFLG
     */
    public String getTkflg() {
        return _tkflg;
    }

    /**
     * TKFLGを設定する
     *
     * @param tkflg TKFLG
     */
    public void setTkflg(String tkflg) {
        this._tkflg = tkflg;
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
