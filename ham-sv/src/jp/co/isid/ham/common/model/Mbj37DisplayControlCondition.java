package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ��ʍ��ڕ\���񐧌�}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj37DisplayControlCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���ID */
    private String _formid = null;

    /** �ꗗID */
    private String _viewid = null;

    /** �� */
    private BigDecimal _colcnt = null;

    /** �� */
    private String _colnm = null;

    /** �� */
    private String _colwidth = null;

    /** �\���敪 */
    private String _displaykbn = null;

    /** ����敪 */
    private String _controlkbn = null;

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
    public Mbj37DisplayControlCondition() {
    }

    /**
     * ���ID���擾����
     *
     * @return ���ID
     */
    public String getFormid() {
        return _formid;
    }

    /**
     * ���ID��ݒ肷��
     *
     * @param formid ���ID
     */
    public void setFormid(String formid) {
        this._formid = formid;
    }

    /**
     * �ꗗID���擾����
     *
     * @return �ꗗID
     */
    public String getViewid() {
        return _viewid;
    }

    /**
     * �ꗗID��ݒ肷��
     *
     * @param viewid �ꗗID
     */
    public void setViewid(String viewid) {
        this._viewid = viewid;
    }

    /**
     * �񐔂��擾����
     *
     * @return ��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getColcnt() {
        return _colcnt;
    }

    /**
     * �񐔂�ݒ肷��
     *
     * @param colcnt ��
     */
    public void setColcnt(BigDecimal colcnt) {
        this._colcnt = colcnt;
    }

    /**
     * �񖼂��擾����
     *
     * @return ��
     */
    public String getColnm() {
        return _colnm;
    }

    /**
     * �񖼂�ݒ肷��
     *
     * @param colnm ��
     */
    public void setColnm(String colnm) {
        this._colnm = colnm;
    }

    /**
     * �񕝂��擾����
     *
     * @return ��
     */
    public String getColwidth() {
        return _colwidth;
    }

    /**
     * �񕝂�ݒ肷��
     *
     * @param colwidth ��
     */
    public void setColwidth(String colwidth) {
        this._colwidth = colwidth;
    }

    /**
     * �\���敪���擾����
     *
     * @return �\���敪
     */
    public String getDisplaykbn() {
        return _displaykbn;
    }

    /**
     * �\���敪��ݒ肷��
     *
     * @param displaykbn �\���敪
     */
    public void setDisplaykbn(String displaykbn) {
        this._displaykbn = displaykbn;
    }

    /**
     * ����敪���擾����
     *
     * @return ����敪
     */
    public String getControlkbn() {
        return _controlkbn;
    }

    /**
     * ����敪��ݒ肷��
     *
     * @param controlkbn ����敪
     */
    public void setControlkbn(String controlkbn) {
        this._controlkbn = controlkbn;
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
