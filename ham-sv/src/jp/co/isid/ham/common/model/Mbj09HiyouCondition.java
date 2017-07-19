package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ��p���No�}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj09HiyouCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �}�̃R�[�h */
    private String _mediacd = null;

    /** �d�ʎԎ�R�[�h */
    private String _dcarcd = null;

    /** ��p�v��No */
    private String _hiyouno = null;

    /** ���No */
    private String _kikakuno = null;

    /** �t�F�C�Y */
    private BigDecimal _phase = null;

    /** �� */
    private String _term = null;

    /** ��p���No�׸� */
    private String _hiyouflg = null;

    /** HM����R�[�h */
    private String _hmdivcd = null;

    /** HM�S���҃R�[�h */
    private String _hmusercd = null;

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
    public Mbj09HiyouCondition() {
    }

    /**
     * �}�̃R�[�h���擾����
     *
     * @return �}�̃R�[�h
     */
    public String getMediacd() {
        return _mediacd;
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     *
     * @param mediacd �}�̃R�[�h
     */
    public void setMediacd(String mediacd) {
        this._mediacd = mediacd;
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     *
     * @return �d�ʎԎ�R�[�h
     */
    public String getDcarcd() {
        return _dcarcd;
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     *
     * @param dcarcd �d�ʎԎ�R�[�h
     */
    public void setDcarcd(String dcarcd) {
        this._dcarcd = dcarcd;
    }

    /**
     * ��p�v��No���擾����
     *
     * @return ��p�v��No
     */
    public String getHiyouno() {
        return _hiyouno;
    }

    /**
     * ��p�v��No��ݒ肷��
     *
     * @param hiyouno ��p�v��No
     */
    public void setHiyouno(String hiyouno) {
        this._hiyouno = hiyouno;
    }

    /**
     * ���No���擾����
     *
     * @return ���No
     */
    public String getKikakuno() {
        return _kikakuno;
    }

    /**
     * ���No��ݒ肷��
     *
     * @param kikakuno ���No
     */
    public void setKikakuno(String kikakuno) {
        this._kikakuno = kikakuno;
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
     * �����擾����
     *
     * @return ��
     */
    public String getTerm() {
        return _term;
    }

    /**
     * ����ݒ肷��
     *
     * @param term ��
     */
    public void setTerm(String term) {
        this._term = term;
    }

    /**
     * ��p���No�׸ނ��擾����
     *
     * @return ��p���No�׸�
     */
    public String getHiyouflg() {
        return _hiyouflg;
    }

    /**
     * ��p���No�׸ނ�ݒ肷��
     *
     * @param hiyouflg ��p���No�׸�
     */
    public void setHiyouflg(String hiyouflg) {
        this._hiyouflg = hiyouflg;
    }

    /**
     * HM����R�[�h���擾����
     *
     * @return HM����R�[�h
     */
    public String getHmdivcd() {
        return _hmdivcd;
    }

    /**
     * HM����R�[�h��ݒ肷��
     *
     * @param hmdivcd HM����R�[�h
     */
    public void setHmdivcd(String hmdivcd) {
        this._hmdivcd = hmdivcd;
    }

    /**
     * HM�S���҃R�[�h���擾����
     *
     * @return HM�S���҃R�[�h
     */
    public String getHmusercd() {
        return _hmusercd;
    }

    /**
     * HM�S���҃R�[�h��ݒ肷��
     *
     * @param hmusercd HM�S���҃R�[�h
     */
    public void setHmusercd(String hmusercd) {
        this._hmusercd = hmusercd;
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