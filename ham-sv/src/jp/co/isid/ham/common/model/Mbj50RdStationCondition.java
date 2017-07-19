package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ���W�I�ǃ}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj50RdStationCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���W�I�ǃR�[�h */
    private String _rdcd = null;

    /** ���W�I�ǖ��� */
    private String _rdnm = null;

    /** ���̗��� */
    private String _abbreviation = null;

    /** JASRAC���[�o�͖��� */
    private String _jasracreportnm = null;

    /** JFN�n��t���O */
    private String _jfngrpflg = null;

    /** JRN�n��t���O */
    private String _jrngrpflg = null;

    /** NRN�n��t���O */
    private String _nrngrpflg = null;

    /** �\���� */
    private BigDecimal _sortno = null;

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
    public Mbj50RdStationCondition() {
    }

    /**
     * ���W�I�ǃR�[�h���擾����
     *
     * @return ���W�I�ǃR�[�h
     */
    public String getRdcd() {
        return _rdcd;
    }

    /**
     * ���W�I�ǃR�[�h��ݒ肷��
     *
     * @param rdcd ���W�I�ǃR�[�h
     */
    public void setRdcd(String rdcd) {
        this._rdcd = rdcd;
    }

    /**
     * ���W�I�ǖ��̂��擾����
     *
     * @return ���W�I�ǖ���
     */
    public String getRdnm() {
        return _rdnm;
    }

    /**
     * ���W�I�ǖ��̂�ݒ肷��
     *
     * @param rdnm ���W�I�ǖ���
     */
    public void setRdnm(String rdnm) {
        this._rdnm = rdnm;
    }

    /**
     * ���̗��̂��擾����
     *
     * @return ���̗���
     */
    public String getAbbreviation() {
        return _abbreviation;
    }

    /**
     * ���̗��̂�ݒ肷��
     *
     * @param abbreviation ���̗���
     */
    public void setAbbreviation(String abbreviation) {
        this._abbreviation = abbreviation;
    }

    /**
     * JASRAC���[�o�͖��̂��擾����
     *
     * @return JASRAC���[�o�͖���
     */
    public String getJasracreportnm() {
        return _jasracreportnm;
    }

    /**
     * JASRAC���[�o�͖��̂�ݒ肷��
     *
     * @param jasracreportnm JASRAC���[�o�͖���
     */
    public void setJasracreportnm(String jasracreportnm) {
        this._jasracreportnm = jasracreportnm;
    }

    /**
     * JFN�n��t���O���擾����
     *
     * @return JFN�n��t���O
     */
    public String getJfngrpflg() {
        return _jfngrpflg;
    }

    /**
     * JFN�n��t���O��ݒ肷��
     *
     * @param jfngrpflg JFN�n��t���O
     */
    public void setJfngrpflg(String jfngrpflg) {
        this._jfngrpflg = jfngrpflg;
    }

    /**
     * JRN�n��t���O���擾����
     *
     * @return JRN�n��t���O
     */
    public String getJrngrpflg() {
        return _jrngrpflg;
    }

    /**
     * JRN�n��t���O��ݒ肷��
     *
     * @param jrngrpflg JRN�n��t���O
     */
    public void setJrngrpflg(String jrngrpflg) {
        this._jrngrpflg = jrngrpflg;
    }

    /**
     * NRN�n��t���O���擾����
     *
     * @return NRN�n��t���O
     */
    public String getNrngrpflg() {
        return _nrngrpflg;
    }

    /**
     * NRN�n��t���O��ݒ肷��
     *
     * @param nrngrpflg NRN�n��t���O
     */
    public void setNrngrpflg(String nrngrpflg) {
        this._nrngrpflg = nrngrpflg;
    }

    /**
     * �\�������擾����
     *
     * @return �\����
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSortno() {
        return _sortno;
    }

    /**
     * �\������ݒ肷��
     *
     * @param sortno �\����
     */
    public void setSortno(BigDecimal sortno) {
        this._sortno = sortno;
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
