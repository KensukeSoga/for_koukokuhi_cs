package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �}�̃}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj03MediaCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �}�̃R�[�h */
    private String _mediacd = null;

    /** �}�̖� */
    private String _medianm = null;

    /** �}�̖��i�}�̔�쐬�p�j */
    private String _hcmedianm = null;

    /** �d�ʒl���� */
    private BigDecimal _dnebiki = null;

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
    public Mbj03MediaCondition() {
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
     * �}�̖����擾����
     *
     * @return �}�̖�
     */
    public String getMedianm() {
        return _medianm;
    }

    /**
     * �}�̖���ݒ肷��
     *
     * @param medianm �}�̖�
     */
    public void setMedianm(String medianm) {
        this._medianm = medianm;
    }

    /**
     * �}�̖��i�}�̔�쐬�p�j���擾����
     *
     * @return �}�̖��i�}�̔�쐬�p�j
     */
    public String getHcmedianm() {
        return _hcmedianm;
    }

    /**
     * �}�̖��i�}�̔�쐬�p�j��ݒ肷��
     *
     * @param hcmedianm �}�̖��i�}�̔�쐬�p�j
     */
    public void setHcmedianm(String hcmedianm) {
        this._hcmedianm = hcmedianm;
    }

    /**
     * �d�ʒl�������擾����
     *
     * @return �d�ʒl����
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDnebiki() {
        return _dnebiki;
    }

    /**
     * �d�ʒl������ݒ肷��
     *
     * @param dnebiki �d�ʒl����
     */
    public void setDnebiki(BigDecimal dnebiki) {
        this._dnebiki = dnebiki;
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
