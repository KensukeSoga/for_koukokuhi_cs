package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ���W�I�ԑg�l�b�g�ǌ�������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj39RdProgramStationCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���W�I�ԑgSEQNO */
    private BigDecimal _rdseqno = null;

    /** �l�b�g�ǃR�[�h */
    private String _stationcd = null;

    /** �f�[�^�쐬���� */
    private Date _crtdate = null;

    /** �f�[�^�쐬�� */
    private String _crtnm = null;

    /** �쐬�v���O���� */
    private String _crtapl = null;

    /** �쐬�S����ID */
    private String _crtid = null;

    /** �f�[�^�X�V���� */
    private Date _upddate = null;

    /** �f�[�^�X�V�� */
    private String _updnm = null;

    /** �X�V�v���O���� */
    private String _updapl = null;

    /** �X�V�S����ID */
    private String _updid = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj39RdProgramStationCondition() {
    }

    /**
     * ���W�I�ԑgSEQNO���擾����
     *
     * @return ���W�I�ԑgSEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getRdseqno() {
        return _rdseqno;
    }

    /**
     * ���W�I�ԑgSEQNO��ݒ肷��
     *
     * @param rdseqno ���W�I�ԑgSEQNO
     */
    public void setRdseqno(BigDecimal rdseqno) {
        this._rdseqno = rdseqno;
    }

    /**
     * �l�b�g�ǃR�[�h���擾����
     *
     * @return �l�b�g�ǃR�[�h
     */
    public String getStationcd() {
        return _stationcd;
    }

    /**
     * �l�b�g�ǃR�[�h��ݒ肷��
     *
     * @param stationcd �l�b�g�ǃR�[�h
     */
    public void setStationcd(String stationcd) {
        this._stationcd = stationcd;
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrtdate() {
        return _crtdate;
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param crtdate �f�[�^�쐬����
     */
    public void setCrtdate(Date crtdate) {
        this._crtdate = crtdate;
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCrtnm() {
        return _crtnm;
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param crtnm �f�[�^�쐬��
     */
    public void setCrtnm(String crtnm) {
        this._crtnm = crtnm;
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCrtapl() {
        return _crtapl;
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param crtapl �쐬�v���O����
     */
    public void setCrtapl(String crtapl) {
        this._crtapl = crtapl;
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCrtid() {
        return _crtid;
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param crtid �쐬�S����ID
     */
    public void setCrtid(String crtid) {
        this._crtid = crtid;
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUpddate() {
        return _upddate;
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param upddate �f�[�^�X�V����
     */
    public void setUpddate(Date upddate) {
        this._upddate = upddate;
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUpdnm() {
        return _updnm;
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param updnm �f�[�^�X�V��
     */
    public void setUpdnm(String updnm) {
        this._updnm = updnm;
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUpdapl() {
        return _updapl;
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param updapl �X�V�v���O����
     */
    public void setUpdapl(String updapl) {
        this._updapl = updapl;
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUpdid() {
        return _updid;
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param updid �X�V�S����ID
     */
    public void setUpdid(String updid) {
        this._updid = updid;
    }

}
