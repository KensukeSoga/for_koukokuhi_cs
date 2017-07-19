package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �@�\���䍀�ڃ}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj34FunctionControlItemCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �@�\�R�[�h */
    private String _funccd = null;

    /** �@�\��� */
    private String _functype = null;

    /** �@�\�� */
    private String _funcnm = null;

    /** ��� */
    private String _itemtype = null;

    /** �f�t�H���g���� */
    private String _defaultcontrol = null;

    /** �t�H�[���t�@�C��ID */
    private String _formid = null;

    /** �I�u�W�F�N�g�� */
    private String _objname = null;

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
    public Mbj34FunctionControlItemCondition() {
    }

    /**
     * �@�\�R�[�h���擾����
     *
     * @return �@�\�R�[�h
     */
    public String getFunccd() {
        return _funccd;
    }

    /**
     * �@�\�R�[�h��ݒ肷��
     *
     * @param funccd �@�\�R�[�h
     */
    public void setFunccd(String funccd) {
        this._funccd = funccd;
    }

    /**
     * �@�\��ʂ��擾����
     *
     * @return ���
     */
    public String getFunctype() {
        return _functype;
    }

    /**
     * �@�\��ʂ�ݒ肷��
     *
     * @param functype ���
     */
    public void setFunctype(String functype) {
        this._functype = functype;
    }

    /**
     * �@�\�����擾����
     *
     * @return �@�\��
     */
    public String getFuncnm() {
        return _funcnm;
    }

    /**
     * �@�\����ݒ肷��
     *
     * @param funcnm �@�\��
     */
    public void setFuncnm(String funcnm) {
        this._funcnm = funcnm;
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
     * �f�t�H���g������擾����
     *
     * @return �f�t�H���g����
     */
    public String getDefaultcontrol() {
        return _defaultcontrol;
    }

    /**
     * �f�t�H���g�����ݒ肷��
     *
     * @param defaultcontrol �f�t�H���g����
     */
    public void setDefaultcontrol(String defaultcontrol) {
        this._defaultcontrol = defaultcontrol;
    }

    /**
     * �t�H�[���t�@�C��ID���擾����
     *
     * @return �t�H�[���t�@�C��ID
     */
    public String getFormid() {
        return _formid;
    }

    /**
     * �t�H�[���t�@�C��ID��ݒ肷��
     *
     * @param formid �t�H�[���t�@�C��ID
     */
    public void setFormid(String formid) {
        this._formid = formid;
    }

    /**
     * �I�u�W�F�N�g�����擾����
     *
     * @return �I�u�W�F�N�g��
     */
    public String getObjname() {
        return _objname;
    }

    /**
     * �I�u�W�F�N�g����ݒ肷��
     *
     * @param objname �I�u�W�F�N�g��
     */
    public void setObjname(String objname) {
        this._objname = objname;
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
