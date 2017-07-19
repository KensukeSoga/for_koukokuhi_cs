package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �Z�L�����e�B�x�[�X�}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj44SecurityBaseCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �ǃR�[�h */
    private String _kksikognzuntcd = null;

    /** ���[�U��� */
    private String _usertype = null;

    /** �Z�L�����e�B�R�[�h */
    private String _securitycd = null;

    /** �Z�L�����e�B��� */
    private String _securitytype = null;

    /** �o�^�E�X�V */
    private String _update = null;

    /** �m�F */
    private String _check = null;

    /** �Q�� */
    private String _reference = null;

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
    public Mbj44SecurityBaseCondition() {
    }

    /**
     * �ǃR�[�h���擾����
     *
     * @return �ǃR�[�h
     */
    public String getKksikognzuntcd() {
        return _kksikognzuntcd;
    }

    /**
     * �ǃR�[�h��ݒ肷��
     *
     * @param kksikognzuntcd �ǃR�[�h
     */
    public void setKksikognzuntcd(String kksikognzuntcd) {
        this._kksikognzuntcd = kksikognzuntcd;
    }

    /**
     * ���[�U��ʂ��擾����
     *
     * @return ���[�U���
     */
    public String getUsertype() {
        return _usertype;
    }

    /**
     * ���[�U��ʂ�ݒ肷��
     *
     * @param usertype ���[�U���
     */
    public void setUsertype(String usertype) {
        this._usertype = usertype;
    }

    /**
     * �Z�L�����e�B�R�[�h���擾����
     *
     * @return �Z�L�����e�B�R�[�h
     */
    public String getSecuritycd() {
        return _securitycd;
    }

    /**
     * �Z�L�����e�B�R�[�h��ݒ肷��
     *
     * @param securitycd �Z�L�����e�B�R�[�h
     */
    public void setSecuritycd(String securitycd) {
        this._securitycd = securitycd;
    }

    /**
     * �Z�L�����e�B��ʂ��擾����
     *
     * @return �Z�L�����e�B���
     */
    public String getSecuritytype() {
        return _securitytype;
    }

    /**
     * �Z�L�����e�B��ʂ�ݒ肷��
     *
     * @param securitytype �Z�L�����e�B���
     */
    public void setSecuritytype(String securitytype) {
        this._securitytype = securitytype;
    }

    /**
     * �o�^�E�X�V���擾����
     *
     * @return �o�^�E�X�V
     */
    public String getUpdate() {
        return _update;
    }

    /**
     * �o�^�E�X�V��ݒ肷��
     *
     * @param update �o�^�E�X�V
     */
    public void setUpdate(String update) {
        this._update = update;
    }

    /**
     * �m�F���擾����
     *
     * @return �m�F
     */
    public String getCheck() {
        return _check;
    }

    /**
     * �m�F��ݒ肷��
     *
     * @param check �m�F
     */
    public void setCheck(String check) {
        this._check = check;
    }

    /**
     * �Q�Ƃ��擾����
     *
     * @return �Q��
     */
    public String getReference() {
        return _reference;
    }

    /**
     * �Q�Ƃ�ݒ肷��
     *
     * @param reference �Q��
     */
    public void setReference(String reference) {
        this._reference = reference;
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
