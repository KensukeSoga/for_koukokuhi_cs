package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �Z�L�����e�B���ڃ}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj43SecurityItemCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �Z�L�����e�B�R�[�h */
    private String _securitycd = null;

    /** �Z�L�����e�B��� */
    private String _securitytype = null;

    /** �Z�L�����e�B�� */
    private String _securitynm = null;

    /** ��� */
    private String _itemtype = null;

    /** �\�[�gNo */
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
    public Mbj43SecurityItemCondition() {
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
     * �Z�L�����e�B�����擾����
     *
     * @return �Z�L�����e�B��
     */
    public String getSecuritynm() {
        return _securitynm;
    }

    /**
     * �Z�L�����e�B����ݒ肷��
     *
     * @param securitynm �Z�L�����e�B��
     */
    public void setSecuritynm(String securitynm) {
        this._securitynm = securitynm;
    }

    /**
     * ��ʂ��擾����
     *
     * @return ���
     */
    public String getItemtype() {
        return _itemtype;
    }

    /**
     * ��ʂ�ݒ肷��
     *
     * @param itemtype ���
     */
    public void setItemtype(String itemtype) {
        this._itemtype = itemtype;
    }

    /**
     * �\�[�gNo���擾����
     *
     * @return �\�[�gNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSortno() {
        return _sortno;
    }

    /**
     * �\�[�gNo��ݒ肷��
     *
     * @param sortno �\�[�gNo
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
