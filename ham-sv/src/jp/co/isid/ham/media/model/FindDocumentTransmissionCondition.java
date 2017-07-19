package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;

public class FindDocumentTransmissionCondition implements Serializable {

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

    /** ���ID */
    private String _formId;

    /** ��� */
    private String _funcType;

    /** ���[�U�[��� */
    private String _userType = null;

    /** �ǃR�[�h */
    private String _kksikognzuntcd = null;


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
     * ���ID���擾����
     *
     * @return ���ID
     */
    public String getFormId() {
        return _formId;
    }

    /**
     * ���ID��ݒ肷��
     *
     * @param formID ���ID
     */
    public void setFormId(String formId) {
        _formId = formId;
    }

    /**
     * ��ʂ��擾����
     *
     * @return ���
     */
    public String getFuncType() {
        return _funcType;
    }

    /**
     * ��ʂ�ݒ肷��
     *
     * @param funcid ���
     */
    public void setFuncType(String functype) {
        _funcType = functype;
    }

    /**
     * ���[�U��ʂ��擾����
     *
     * @return ���[�U�[���
     */
    public String getUserType() {
        return _userType;
    }

    /**
     * ���[�U��ʂ�ݒ肷��
     *
     * @param userType ���[�U�[���
     */
    public void setUserType(String userType) {
        _userType = userType;
    }

    /**
     * �ǃR�[�h���擾����
     *
     * @return �ǃR�[�h
     */
    public String getKksikognzuntcd()
    {
        return _kksikognzuntcd;
    }

    /**
     * �ǃR�[�h��ݒ肷��
     *
     * @param kksikognzuntcd �ǃR�[�h
     */
    public void setKksikognzuntcd(String kksikognzuntcd)
    {
        this._kksikognzuntcd = kksikognzuntcd;
    }

}
