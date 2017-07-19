package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;

public class FindDocTransReportCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �S����ID */
    private String _hamId = null;

    /** �}�̃R�[�h */
    private String _mediaCd = null;

    /** ���ԊJ�n */
    private Date _termStart;

    /** ���ԏI�� */
    private Date _termEnd;

    /** �R�[�h�^�C�v(���[) */
    private String _codeTypeNp = null;

    /** �R�[�h�^�C�v(�����}�X�^) */
    private String _codeTypeDep = null;

    /** �L�[�R�[�h(���e�\) */
    private String _keyCodeDt = null;

    /** �d�ʎԎ�R�[�h */
    private List<String> _dcarCd = null;

    /** �L�����y�[��(�c�ƍ�Ƒ䒠) */
    private List<String> _campaign = null;

    /** �_�~�[�v���p�e�B */
    private String _dummy;


    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHamId() {
        return _hamId;
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param hamid �S����ID
     */
    public void setHamId(String hamId) {
        this._hamId = hamId;
    }

    /**
     * �}�̃R�[�h���擾����
     *
     * @return �}�̃R�[�h
     */
    public String getMediaCd() {
        return _mediaCd;
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     *
     * @param mediaCd �}�̃R�[�h
     */
    public void setMediaCd(String mediaCd) {
        _mediaCd = mediaCd;
    }

    /**
     * ���ԊJ�n���擾����
     *
     * @return ���ԊJ�n
     */
    @XmlElement(required = true, nillable = true)
    public Date getTermStart() {
        return _termStart;
    }

    /**
     * ���ԊJ�n��ݒ肷��
     *
     * @param termStart ���ԊJ�n
     */
    public void setTermStart(Date termStart) {
        _termStart = termStart;
    }

    /**
     * ���ԏI�����擾����
     *
     * @return ���ԏI��
     */
    @XmlElement(required = true, nillable = true)
    public Date getTermEnd() {
        return _termEnd;
    }

    /**
     * ���ԏI����ݒ肷��
     *
     * @param termEnd ���ԏI��
     */
    public void setTermEnd(Date termEnd) {
        _termEnd = termEnd;
    }

    /**
     * �R�[�h�^�C�v(���[)
     *
     * @return �R�[�h�^�C�v(���[)
     */
    public String getCodeTypeNp() {
        return _codeTypeNp;
    }

    /**
     * �R�[�h�^�C�v(���[)
     *
     * @param codeType �R�[�h�^�C�v(���[)
     */
    public void setCodeTypeNp(String codeTypeNp) {
        _codeTypeNp = codeTypeNp;
    }

    /**
     * �R�[�h�^�C�v(�����}�X�^)
     *
     * @return �R�[�h�^�C�v(�����}�X�^)
     */
    public String getCodeTypeDep() {
        return _codeTypeDep;
    }

    /**
     * �R�[�h�^�C�v(�����}�X�^)
     *
     * @param codeTypeDep �R�[�h�^�C�v(�����}�X�^)
     */
    public void setCodeTypeDep(String codeTypeDep) {
        _codeTypeDep = codeTypeDep;
    }

    /**
     * �L�[�R�[�h(���e�\)
     *
     * @return �L�[�R�[�h(���e�\)
     */
    public String getKeyCodeDt() {
        return _keyCodeDt;
    }

    /**
     * �L�[�R�[�h(���e�\)
     *
     * @param keyCodeDt �L�[�R�[�h(���e�\)
     */
    public void setKeyCodeDt(String keyCodeDt) {
        _keyCodeDt = keyCodeDt;
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     * @return �d�ʎԎ�R�[�h
     */
    public List<String> getDcarcd() {
        return _dcarCd;
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     * @param dcarCd �d�ʎԎ�R�[�h
     */
    public void setDcarcd(List<String>  dcarCd) {
        _dcarCd = dcarCd;
    }

    /**
     * �L�����y�[�����擾����
     * @return �L�����y�[��
     */
    public List<String> getCampaign() {
        return _campaign;
    }

    /**
     * �L�����y�[����ݒ肷��
     * @param campaign �L�����y�[��
     */
    public void setCampaign(List<String> campaign) {
        _campaign = campaign;
    }


    /**
     * �_�~�[�v���p�e�B��Ԃ��܂�
     * @return
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * �_�~�[�v���p�e�B��ݒ肷��
     * @param
     */
    public void setDummy(String dummy) {
        _dummy = dummy;
    }
}
