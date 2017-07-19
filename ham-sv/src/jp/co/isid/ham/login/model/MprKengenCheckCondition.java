package jp.co.isid.ham.login.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

@XmlRootElement(namespace = "http://model.login.cnp.isid.co.jp/")
@XmlType(namespace = "http://model.login.cnp.isid.co.jp/")
public class MprKengenCheckCondition implements Serializable {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** �A�v��ID */
    private String _aplId = null;

    /** ���O�C���S����ESQID */
    private String _esqId = null;

    /** �p�X���[�h */
    private String _password = null;

    /** �Z�L�����e�B��� */
    private byte[] _securityInfo = null;

    /** �c�Ɠ� */
    private String _eigyobi = null;

    /** �S���҃R�[�h */
    private String _tantoCd = null;

    /** ���O�C���ǃR�[�h */
    private String _kyokuCd = null;

    /** �^�pNo */
    private String _operationNo = null;

    /**
     * �A�v��ID���擾����
     * @return �A�v��ID
     */
    public String getAplId() {
        return _aplId;
    }

    /**
     * �A�v��ID��ݒ肷��
     * @param aplId �A�v��ID
     */
    public void setAplId(String aplId) {
        this._aplId = aplId;
    }

    /**
     * ���O�C���S����ESQID���擾����
     * @return ���O�C���S����ESQID
     */
    public String getEsqId() {
        return _esqId;
    }

    /**
     * ���O�C���S����ESQID��ݒ肷��
     * @param esqId ���O�C���S����ESQID
     */
    public void setEsqId(String esqId) {
        this._esqId = esqId;
    }

    /**
     * �p�X���[�h���擾����
     * @return �p�X���[�h
     */
    public String getPassword() {
        return _password;
    }

    /**
     * �p�X���[�h��ݒ肷��
     * @param password �p�X���[�h
     */
    public void setPassword(String password) {
        this._password = password;
    }

    /**
     * �Z�L�����e�B�����擾����
     * @return �Z�L�����e�B���
     */
    public byte[] getSecurityInfo() {
        return _securityInfo;
    }

    /**
     * �Z�L�����e�B����ݒ肷��
     * @param securityInfo �Z�L�����e�B���
     */
    public void setSecurityInfo(byte[] securityInfo) {
        this._securityInfo = securityInfo;
    }

    /**
     * �c�Ɠ����擾����
     * @return �c�Ɠ�
     */
    public String getEigyobi() {
        return _eigyobi;
    }

    /**
     * �c�Ɠ���ݒ肷��
     * @param �c�Ɠ�
     */
    public void setEigyobi(String eigyobi) {
        this._eigyobi = eigyobi;
    }

    /**
     * �S���҃R�[�h���擾����
     * @return �S���҃R�[�h
     */
    public String getTantoCd() {
        return _tantoCd;
    }

    /**
     * �S���҃R�[�h��ݒ肷��
     * @param �S���҃R�[�h
     */
    public void setTantoCd(String tantoCd) {
        this._tantoCd = tantoCd;
    }

    /**
     * ���O�C���ǃR�[�h���擾����
     * @return ���O�C���ǃR�[�h
     */
    public String getKyokuCd() {
        return _kyokuCd;
    }

    /**
     * ���O�C���ǃR�[�h��ݒ肷��
     * @param ���O�C���ǃR�[�h
     */
    public void setKyokuCd(String kyokuCd) {
        this._kyokuCd = kyokuCd;
    }

    /**
     * �^�pNo���擾����
     * @return �^�pNo
     */
    public String getOperationNo() {
        return _operationNo;
    }

    /**
     * �^�pNo��ݒ肷��
     * @param �^�pNo
     */
    public void setOperationNo(String operationNo) {
        this._operationNo = operationNo;
    }
}
