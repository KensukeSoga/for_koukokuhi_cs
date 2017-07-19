package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ���[���z�M�}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/07/05 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj40AlertMailAddressCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �A���[�g���[����� */
    private String _mailtype = null;

    /** �S����ID */
    private String _hamid = null;

    /** ���� */
    private String _cn = null;

    /** ���[���A�h���X */
    private String _mail = null;

    /** ����t���O */
    private String _sendtype = null;

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
    public Mbj40AlertMailAddressCondition() {
    }

    /**
     * �A���[�g���[����ʂ��擾����
     *
     * @return �A���[�g���[�����
     */
    public String getMailtype() {
        return _mailtype;
    }

    /**
     * �A���[�g���[����ʂ�ݒ肷��
     *
     * @param mailtype �A���[�g���[�����
     */
    public void setMailtype(String mailtype) {
        this._mailtype = mailtype;
    }

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param hamid �S����ID
     */
    public void setHamid(String hamid) {
        this._hamid = hamid;
    }

    /**
     * �������擾����
     *
     * @return ����
     */
    public String getCn() {
        return _cn;
    }

    /**
     * ������ݒ肷��
     *
     * @param cn ����
     */
    public void setCn(String cn) {
        this._cn = cn;
    }

    /**
     * ���[���A�h���X���擾����
     *
     * @return ���[���A�h���X
     */
    public String getMail() {
        return _mail;
    }

    /**
     * ���[���A�h���X��ݒ肷��
     *
     * @param mail ���[���A�h���X
     */
    public void setMail(String mail) {
        this._mail = mail;
    }

    /**
     * ����t���O���擾����
     *
     * @return ����t���O
     */
    public String getSendtype() {
        return _sendtype;
    }

    /**
     * ����t���O��ݒ肷��
     *
     * @param sendtype ����t���O
     */
    public void setSendtype(String sendtype) {
        this._sendtype = sendtype;
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
