package jp.co.isid.ham.common.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �}�́E���i�R�t���}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj27MediaProductCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �t�F�C�Y */
    private BigDecimal _phase = null;

    /** �d�ʎԎ�R�[�h */
    private String _dcarcd = null;

    /** �}�̃R�[�h */
    private String _mediacd = null;

    /** HC����R�[�h */
    private String _hcbumoncd = null;

    /** ���i�R�[�h */
    private String _productcd = null;

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
    public Mbj27MediaProductCondition() {
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
     * ���i�R�[�h���擾����
     *
     * @return ���i�R�[�h
     */
    public String getProductcd() {
        return _productcd;
    }

    /**
     * ���i�R�[�h��ݒ肷��
     *
     * @param productcd ���i�R�[�h
     */
    public void setProductcd(String productcd) {
        this._productcd = productcd;
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
