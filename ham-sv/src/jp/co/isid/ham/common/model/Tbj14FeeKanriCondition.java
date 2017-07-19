package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �t�B�[�Ǘ���������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj14FeeKanriCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �t�F�C�Y */
    private BigDecimal _phase = null;

    /** ������ */
    private Date _seikyuym = null;

    /** �l���� */
    private BigDecimal _jinkenhi = null;

    /** �̑��� */
    private BigDecimal _hansokuhi = null;

    /** �o���� */
    private BigDecimal _syuttyouhi = null;

    /** ���� */
    private BigDecimal _jippi = null;

    /** �b�茎�z���� */
    private BigDecimal _monthadjust = null;

    /** �f�[�^�쐬���� */
    private Date _crtdate = null;

    /** �f�[�^�쐬�� */
    private String _crtnm = null;

    /** �쐬�v���O���� */
    private String _crtapl = null;

    /** �쐬�S����ID */
    private String _crtid = null;

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
    public Tbj14FeeKanriCondition() {
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPhase() {
        return _phase;
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param phase �t�F�C�Y
     */
    public void setPhase(BigDecimal phase) {
        this._phase = phase;
    }

    /**
     * ���������擾����
     *
     * @return ������
     */
    @XmlElement(required = true, nillable = true)
    public Date getSeikyuym() {
        return _seikyuym;
    }

    /**
     * ��������ݒ肷��
     *
     * @param seikyuym ������
     */
    public void setSeikyuym(Date seikyuym) {
        this._seikyuym = seikyuym;
    }

    /**
     * �l������擾����
     *
     * @return �l����
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getJinkenhi() {
        return _jinkenhi;
    }

    /**
     * �l�����ݒ肷��
     *
     * @param jinkenhi �l����
     */
    public void setJinkenhi(BigDecimal jinkenhi) {
        this._jinkenhi = jinkenhi;
    }

    /**
     * �̑�����擾����
     *
     * @return �̑���
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHansokuhi() {
        return _hansokuhi;
    }

    /**
     * �̑����ݒ肷��
     *
     * @param hansokuhi �̑���
     */
    public void setHansokuhi(BigDecimal hansokuhi) {
        this._hansokuhi = hansokuhi;
    }

    /**
     * �o������擾����
     *
     * @return �o����
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSyuttyouhi() {
        return _syuttyouhi;
    }

    /**
     * �o�����ݒ肷��
     *
     * @param syuttyouhi �o����
     */
    public void setSyuttyouhi(BigDecimal syuttyouhi) {
        this._syuttyouhi = syuttyouhi;
    }

    /**
     * ������擾����
     *
     * @return ����
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getJippi() {
        return _jippi;
    }

    /**
     * �����ݒ肷��
     *
     * @param jippi ����
     */
    public void setJippi(BigDecimal jippi) {
        this._jippi = jippi;
    }

    /**
     * �b�茎�z�������擾����
     *
     * @return �b�茎�z����
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMonthadjust() {
        return _monthadjust;
    }

    /**
     * �b�茎�z������ݒ肷��
     *
     * @param monthadjust �b�茎�z����
     */
    public void setMonthadjust(BigDecimal monthadjust) {
        this._monthadjust = monthadjust;
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrtdate() {
        return _crtdate;
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param crtdate �f�[�^�쐬����
     */
    public void setCrtdate(Date crtdate) {
        this._crtdate = crtdate;
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCrtnm() {
        return _crtnm;
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param crtnm �f�[�^�쐬��
     */
    public void setCrtnm(String crtnm) {
        this._crtnm = crtnm;
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCrtapl() {
        return _crtapl;
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param crtapl �쐬�v���O����
     */
    public void setCrtapl(String crtapl) {
        this._crtapl = crtapl;
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCrtid() {
        return _crtid;
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param crtid �쐬�S����ID
     */
    public void setCrtid(String crtid) {
        this._crtid = crtid;
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
