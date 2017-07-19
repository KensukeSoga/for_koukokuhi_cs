package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �����O���[�v�}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj26BillGroupCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �O���[�v�R�[�h */
    private BigDecimal _groupcd = null;

    /** �O���[�v�� */
    private String _groupnm = null;

    /** �O���[�v��(���[) */
    private String _groupnmrpt = null;

    /** �\�[�gNO */
    private BigDecimal _sortno = null;

    /** HC����R�[�h */
    private String _hcbumoncd = null;

    /** HC����R�[�h(Fee�Č������p) */
    private String _hcbumoncdbill = null;

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
    public Mbj26BillGroupCondition() {
    }

    /**
     * �O���[�v�R�[�h���擾����
     *
     * @return �O���[�v�R�[�h
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGroupcd() {
        return _groupcd;
    }

    /**
     * �O���[�v�R�[�h��ݒ肷��
     *
     * @param groupcd �O���[�v�R�[�h
     */
    public void setGroupcd(BigDecimal groupcd) {
        this._groupcd = groupcd;
    }

    /**
     * �O���[�v�����擾����
     *
     * @return �O���[�v��
     */
    public String getGroupnm() {
        return _groupnm;
    }

    /**
     * �O���[�v����ݒ肷��
     *
     * @param groupnm �O���[�v��
     */
    public void setGroupnm(String groupnm) {
        this._groupnm = groupnm;
    }

    /**
     * �O���[�v��(���[)���擾����
     *
     * @return �O���[�v��(���[)
     */
    public String getGroupnmrpt() {
        return _groupnmrpt;
    }

    /**
     * �O���[�v��(���[)��ݒ肷��
     *
     * @param groupnmrpt �O���[�v��(���[)
     */
    public void setGroupnmrpt(String groupnmrpt) {
        this._groupnmrpt = groupnmrpt;
    }

    /**
     * �\�[�gNO���擾����
     *
     * @return �\�[�gNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSortno() {
        return _sortno;
    }

    /**
     * �\�[�gNO��ݒ肷��
     *
     * @param sortno �\�[�gNO
     */
    public void setSortno(BigDecimal sortno) {
        this._sortno = sortno;
    }

    /**
     * HC����R�[�h���擾����
     *
     * @return HC����R�[�h
     */
    public String getHcbumoncd() {
        return _hcbumoncd;
    }

    /**
     * HC����R�[�h��ݒ肷��
     *
     * @param hcbumoncd HC����R�[�h
     */
    public void setHcbumoncd(String hcbumoncd) {
        this._hcbumoncd = hcbumoncd;
    }

    /**
     * HC����R�[�h(Fee�Č������p)���擾����
     *
     * @return HC����R�[�h(Fee�Č������p)
     */
    public String getHcbumoncdbill() {
        return _hcbumoncdbill;
    }

    /**
     * HC����R�[�h(Fee�Č������p)��ݒ肷��
     *
     * @param hcbumoncdbill HC����R�[�h(Fee�Č������p)
     */
    public void setHcbumoncdbill(String hcbumoncdbill) {
        this._hcbumoncdbill = hcbumoncdbill;
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
