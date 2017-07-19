package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ���[�����M���N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/07/01 )<BR>
 * </P>
 * @author
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class SendMailInfoVO implements Serializable {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** ����iTo�j�A�h���X */
    private List<String> _toAddress = null;

    /** ����iTo�j���� */
    private List<String> _toName = null;

    /** ����iCc�j�A�h���X */
    private List<String> _ccAddress = null;

    /** ����iCc�j���� */
    private List<String> _ccName = null;

    /** ����iBcc�j�A�h���X */
    private List<String> _bccAddress = null;

    /** ����iBcc�j���� */
    private List<String> _bccName = null;

    /** ���� */
    private String _subject = null;

    /** �{�� */
    private String _body = null;

    /**
     * ����iTo�j�A�h���X���擾����
     * @return ����iTo�j�A�h���X
     */
    public List<String> getToAddress() {
        return _toAddress;
    }

    /**
     * ����iTo�j�A�h���X��ݒ肷��
     * @param toAddress ����iTo�j�A�h���X
     */
    public void setToAddress(List<String> toAddress) {
        this._toAddress = toAddress;
    }

    /**
     * ����iTo�j���̂��擾����
     * @return ����iTo�j����
     */
    public List<String> getToName() {
        return _toName;
    }

    /**
     * ����iTo�j���̂�ݒ肷��
     * @param toName ����iTo�j����
     */
    public void setToName(List<String> toName) {
        this._toName = toName;
    }

    /**
     * ����iCc�j�A�h���X���擾����
     * @return ����iCc�j�A�h���X
     */
    public List<String> getCcAddress() {
        return _ccAddress;
    }

    /**
     * ����iCc�j�A�h���X��ݒ肷��
     * @param ccAddress ����iCc�j�A�h���X
     */
    public void setCcAddress(List<String> ccAddress) {
        this._ccAddress = ccAddress;
    }

    /**
     * ����iCc�j���̂��擾����
     * @return ����iCc�j����
     */
    public List<String> getCcName() {
        return _ccName;
    }

    /**
     * ����iCc�j���̂�ݒ肷��
     * @param ccName ����iCc�j����
     */
    public void setCcName(List<String> ccName) {
        this._ccName = ccName;
    }

    /**
     * ����iBcc�j�A�h���X���擾����
     * @return ����iBcc�j�A�h���X
     */
    public List<String> getBccAddress() {
        return _bccAddress;
    }

    /**
     * ����iBcc�j�A�h���X��ݒ肷��
     * @param bccAddress ����iBcc�j�A�h���X
     */
    public void setBccAddress(List<String> bccAddress) {
        this._bccAddress = bccAddress;
    }

    /**
     * ����iBcc�j���̂��擾����
     * @return ����iBcc�j����
     */
    public List<String> getBccName() {
        return _bccName;
    }

    /**
     * ����iBcc�j���̂�ݒ肷��
     * @param bccName ����iBcc�j����
     */
    public void setBccName(List<String> bccName) {
        this._bccName = bccName;
    }

    /**
     * �������擾����
     * @return ����
     */
    public String getSubject() {
        return _subject;
    }

    /**
     * ������ݒ肷��
     * @param subject ����
     */
    public void setSubject(String subject) {
        this._subject = subject;
    }

    /**
     * �{�����擾����
     * @return �{��
     */
    public String getBody() {
        return _body;
    }

    /**
     * �{����ݒ肷��
     * @param body �{��
     */
    public void setBody(String body) {
        this._body = body;
    }
}
