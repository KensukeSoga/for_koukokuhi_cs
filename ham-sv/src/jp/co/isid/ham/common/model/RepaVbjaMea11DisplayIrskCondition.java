package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ��ʁ|������}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
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
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMea11DisplayIrskCondition() {
    }

    /**
     * ATSEGSYOCD���擾����
     *
     * @return ATSEGSYOCD
     */
    public String getAtsegsyocd() {
        return _atsegsyocd;
    }

    /**
     * ATSEGSYOCD��ݒ肷��
     *
     * @param atsegsyocd ATSEGSYOCD
     */
    public void setAtsegsyocd(String atsegsyocd) {
        this._atsegsyocd = atsegsyocd;
    }

    /**
     * JYUCTYPE���擾����
     *
     * @return JYUCTYPE
     */
    public String getJyuctype() {
        return _jyuctype;
    }

    /**
     * JYUCTYPE��ݒ肷��
     *
     * @param jyuctype JYUCTYPE
     */
    public void setJyuctype(String jyuctype) {
        this._jyuctype = jyuctype;
    }

    /**
     * IRSKCD���擾����
     *
     * @return IRSKCD
     */
    public String getIrskcd() {
        return _irskcd;
    }

    /**
     * IRSKCD��ݒ肷��
     *
     * @param irskcd IRSKCD
     */
    public void setIrskcd(String irskcd) {
        this._irskcd = irskcd;
    }

    /**
     * IRSKSUBCD���擾����
     *
     * @return IRSKSUBCD
     */
    public String getIrsksubcd() {
        return _irsksubcd;
    }

    /**
     * IRSKSUBCD��ݒ肷��
     *
     * @param irsksubcd IRSKSUBCD
     */
    public void setIrsksubcd(String irsksubcd) {
        this._irsksubcd = irsksubcd;
    }

    /**
     * IRIKYKSHOWNO���擾����
     *
     * @return IRIKYKSHOWNO
     */
    public String getIrikykshowno() {
        return _irikykshowno;
    }

    /**
     * IRIKYKSHOWNO��ݒ肷��
     *
     * @param irikykshowno IRIKYKSHOWNO
     */
    public void setIrikykshowno(String irikykshowno) {
        this._irikykshowno = irikykshowno;
    }

    /**
     * IRSKSHOWNO���擾����
     *
     * @return IRSKSHOWNO
     */
    public String getIrskshowno() {
        return _irskshowno;
    }

    /**
     * IRSKSHOWNO��ݒ肷��
     *
     * @param irskshowno IRSKSHOWNO
     */
    public void setIrskshowno(String irskshowno) {
        this._irskshowno = irskshowno;
    }

    /**
     * KISEKBN���擾����
     *
     * @return KISEKBN
     */
    public String getKisekbn() {
        return _kisekbn;
    }

    /**
     * KISEKBN��ݒ肷��
     *
     * @param kisekbn KISEKBN
     */
    public void setKisekbn(String kisekbn) {
        this._kisekbn = kisekbn;
    }

    /**
     * DSIKKBNCD���擾����
     *
     * @return DSIKKBNCD
     */
    public String getDsikkbncd() {
        return _dsikkbncd;
    }

    /**
     * DSIKKBNCD��ݒ肷��
     *
     * @param dsikkbncd DSIKKBNCD
     */
    public void setDsikkbncd(String dsikkbncd) {
        this._dsikkbncd = dsikkbncd;
    }

    /**
     * JYUCFLG���擾����
     *
     * @return JYUCFLG
     */
    public String getJyucflg() {
        return _jyucflg;
    }

    /**
     * JYUCFLG��ݒ肷��
     *
     * @param jyucflg JYUCFLG
     */
    public void setJyucflg(String jyucflg) {
        this._jyucflg = jyucflg;
    }

    /**
     * TKFLG���擾����
     *
     * @return TKFLG
     */
    public String getTkflg() {
        return _tkflg;
    }

    /**
     * TKFLG��ݒ肷��
     *
     * @param tkflg TKFLG
     */
    public void setTkflg(String tkflg) {
        this._tkflg = tkflg;
    }

    /**
     * HKYMD���擾����
     *
     * @return HKYMD
     */
    public String getHkymd() {
        return _hkymd;
    }

    /**
     * HKYMD��ݒ肷��
     *
     * @param hkymd HKYMD
     */
    public void setHkymd(String hkymd) {
        this._hkymd = hkymd;
    }

    /**
     * HAISYMD���擾����
     *
     * @return HAISYMD
     */
    public String getHaisymd() {
        return _haisymd;
    }

    /**
     * HAISYMD��ݒ肷��
     *
     * @param haisymd HAISYMD
     */
    public void setHaisymd(String haisymd) {
        this._haisymd = haisymd;
    }

    /**
     * INSDATE���擾����
     *
     * @return INSDATE
     */
    @XmlElement(required = true, nillable = true)
    public Date getInsdate() {
        return _insdate;
    }

    /**
     * INSDATE��ݒ肷��
     *
     * @param insdate INSDATE
     */
    public void setInsdate(Date insdate) {
        this._insdate = insdate;
    }

    /**
     * INSTNTCD���擾����
     *
     * @return INSTNTCD
     */
    public String getInstntcd() {
        return _instntcd;
    }

    /**
     * INSTNTCD��ݒ肷��
     *
     * @param instntcd INSTNTCD
     */
    public void setInstntcd(String instntcd) {
        this._instntcd = instntcd;
    }

    /**
     * INSAPLID���擾����
     *
     * @return INSAPLID
     */
    public String getInsaplid() {
        return _insaplid;
    }

    /**
     * INSAPLID��ݒ肷��
     *
     * @param insaplid INSAPLID
     */
    public void setInsaplid(String insaplid) {
        this._insaplid = insaplid;
    }

    /**
     * UPDAPLDATE���擾����
     *
     * @return UPDAPLDATE
     */
    @XmlElement(required = true, nillable = true)
    public Date getUpdapldate() {
        return _updapldate;
    }

    /**
     * UPDAPLDATE��ݒ肷��
     *
     * @param updapldate UPDAPLDATE
     */
    public void setUpdapldate(Date updapldate) {
        this._updapldate = updapldate;
    }

    /**
     * UPDTNTCD���擾����
     *
     * @return UPDTNTCD
     */
    public String getUpdtntcd() {
        return _updtntcd;
    }

    /**
     * UPDTNTCD��ݒ肷��
     *
     * @param updtntcd UPDTNTCD
     */
    public void setUpdtntcd(String updtntcd) {
        this._updtntcd = updtntcd;
    }

    /**
     * UPDONLAPLID���擾����
     *
     * @return UPDONLAPLID
     */
    public String getUpdonlaplid() {
        return _updonlaplid;
    }

    /**
     * UPDONLAPLID��ݒ肷��
     *
     * @param updonlaplid UPDONLAPLID
     */
    public void setUpdonlaplid(String updonlaplid) {
        this._updonlaplid = updonlaplid;
    }

    /**
     * UPDBATAPLID���擾����
     *
     * @return UPDBATAPLID
     */
    public String getUpdbataplid() {
        return _updbataplid;
    }

    /**
     * UPDBATAPLID��ݒ肷��
     *
     * @param updbataplid UPDBATAPLID
     */
    public void setUpdbataplid(String updbataplid) {
        this._updbataplid = updbataplid;
    }

}
