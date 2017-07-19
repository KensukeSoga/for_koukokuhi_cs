package jp.co.isid.ham.media.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;

/**
 * <P>
 * ���W�I�ԑg�o�^�\����񌟍�����
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdProgramRegisterCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���W�I�ԑgSEQNO */
    private BigDecimal _rdProgramSeqNo = BigDecimal.valueOf(0);
    /** �t�F�C�Y�J�n�� */
    private String _phaseStart = null;
    /** �t�F�C�Y�I���� */
    private String _phaseEnd = null;
    /** �S����ID */
    private String _hamid = null;
    /** ���[�U��� */
    private String _userType = null;
    /** ���ID */
    private String _formId = null;
    /** �@�\��� */
    private String _functionType = null;
    /** �ꗗID */
    private String _viewId = null;
    /** �ǃR�[�h */
    private String _kksikognzuntcd = null;
    /** �Z�L�����e�B�R�[�h */
    private String _securitycd = null;
    /** �R�[�h���X�g */
    private List<String> _codeList = null;

    /**
     * ���W�I�ԑgSEQNO���擾����
     * @return BigDecimal ���W�I�ԑgSEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getRdProgramSeqNo() {
        return _rdProgramSeqNo;
    }

    /**
     * ���W�I�ԑgSEQNO��ݒ肷��
     * @param val BigDecimal ���W�I�ԑgSEQNO
     */
    public void setRdProgramSeqNo(BigDecimal val) {
        _rdProgramSeqNo = val;
    }

    /**
     * �t�F�C�Y�J�n�����擾����
     * @return Date �t�F�C�Y�J�n��
     */
    public String getPhaseStart() {
        return _phaseStart;
    }

    /**
     * �t�F�C�Y�J�n����ݒ肷��
     * @param val Date �t�F�C�Y�J�n��
     */
    public void setPhaseStart(String val) {
        _phaseStart = val;
    }

    /**
     * �t�F�C�Y�I�������擾����
     * @return Date �t�F�C�Y�I����
     */
    public String getPhaseEnd() {
        return _phaseEnd;
    }

    /**
     * �t�F�C�Y�I������ݒ肷��
     * @param val Date �t�F�C�Y�I����
     */
    public void setPhaseEnd(String val) {
        _phaseEnd = val;
    }

    /**
     * �S����ID���擾����
     * @return String �S����ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * �S����ID��ݒ肷��
     * @param val String �S����ID
     */
    public void setHamid(String val) {
        _hamid = val;
    }

    /**
     * ���[�U��ʂ��擾����
     * @return String ���[�U���
     */
    public String getUserType() {
        return _userType;
    }

    /**
     * ���[�U��ʂ�ݒ肷��
     * @param val String ���[�U���
     */
    public void setUserType(String val) {
        _userType = val;
    }

    /**
     * ���ID���擾����
     * @return String ���ID
     */
    public String getFormID() {
        return _formId;
    }

    /**
     * ���ID��ݒ肷��
     * @param val String ���ID
     */
    public void setFormID(String val) {
        _formId = val;
    }

    /**
     * �@�\��ʂ��擾����
     * @return String �@�\���
     */
    public String getFunctionType() {
        return _functionType;
    }

    /**
     * �@�\��ʂ�ݒ肷��
     * @param val String �@�\���
     */
    public void setFunctionType(String val) {
        _functionType = val;
    }

    /**
     * �ꗗID���擾����
     * @return String �ꗗID
     */
    public String getViewID() {
        return _viewId;
    }

    /**
     * �ꗗID��ݒ肷��
     * @param val String �ꗗID
     */
    public void setViewID(String val) {
        _viewId = val;
    }

    /**
     * �ǃR�[�h���擾����
     * @return String �ǃR�[�h
     */
    public String getKksikognzuntcd() {
        return _kksikognzuntcd;
    }

    /**
     * �ǃR�[�h��ݒ肷��
     * @param val String �ǃR�[�h
     */
    public void setKksikognzuntcd(String val) {
        _kksikognzuntcd = val;
    }

    /**
     * �Z�L�����e�B�R�[�h���擾����
     * @return String �Z�L�����e�B�R�[�h
     */
    public String getSecuritycd() {
        return _securitycd;
    }

    /**
     * �Z�L�����e�B�R�[�h��ݒ肷��
     * @param val String �Z�L�����e�B�R�[�h
     */
    public void setSecuritycd(String val) {
        _securitycd = val;
    }

    /**
     * �R�[�h���X�g���擾����
     * @return List<String> �R�[�h���X�g
     */
    public List<String> getCodeList() {
        return _codeList;
    }

    /**
     * �R�[�h���X�g��ݒ肷��
     * @param val List<String> �R�[�h���X�g
     */
    public void setCodeList(List<String> val) {
        _codeList = val;
    }

}