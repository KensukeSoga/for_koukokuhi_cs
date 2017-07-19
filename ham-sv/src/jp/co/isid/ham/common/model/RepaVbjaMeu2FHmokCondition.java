package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ��ڃ}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu2FHmokCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ��ڃR�[�h */
    private String _hmokcd = null;

    /** ���s�N���� */
    private String _hkymd = null;

    /** �p�~�N���� */
    private String _haisymd = null;

    /** ���e�i�J�i�j */
    private String _naiykn = null;

    /** ���e�i�����j */
    private String _naiyj = null;

    /** �o����ڕ\���敪 */
    private String _krihmokshowkbn = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu2FHmokCondition() {
    }

    /**
     * ��ڃR�[�h���擾����
     *
     * @return ��ڃR�[�h
     */
    public String getHmokcd() {
        return _hmokcd;
    }

    /**
     * ��ڃR�[�h��ݒ肷��
     *
     * @param hmokcd ��ڃR�[�h
     */
    public void setHmokcd(String hmokcd) {
        this._hmokcd = hmokcd;
    }

    /**
     * ���s�N�������擾����
     *
     * @return ���s�N����
     */
    public String getHkymd() {
        return _hkymd;
    }

    /**
     * ���s�N������ݒ肷��
     *
     * @param hkymd ���s�N����
     */
    public void setHkymd(String hkymd) {
        this._hkymd = hkymd;
    }

    /**
     * �p�~�N�������擾����
     *
     * @return �p�~�N����
     */
    public String getHaisymd() {
        return _haisymd;
    }

    /**
     * �p�~�N������ݒ肷��
     *
     * @param haisymd �p�~�N����
     */
    public void setHaisymd(String haisymd) {
        this._haisymd = haisymd;
    }

    /**
     * ���e�i�J�i�j���擾����
     *
     * @return ���e�i�J�i�j
     */
    public String getNaiykn() {
        return _naiykn;
    }

    /**
     * ���e�i�J�i�j��ݒ肷��
     *
     * @param naiykn ���e�i�J�i�j
     */
    public void setNaiykn(String naiykn) {
        this._naiykn = naiykn;
    }

    /**
     * ���e�i�����j���擾����
     *
     * @return ���e�i�����j
     */
    public String getNaiyj() {
        return _naiyj;
    }

    /**
     * ���e�i�����j��ݒ肷��
     *
     * @param naiyj ���e�i�����j
     */
    public void setNaiyj(String naiyj) {
        this._naiyj = naiyj;
    }

    /**
     * �o����ڕ\���敪���擾����
     *
     * @return �o����ڕ\���敪
     */
    public String getKrihmokshowkbn() {
        return _krihmokshowkbn;
    }

    /**
     * �o����ڕ\���敪��ݒ肷��
     *
     * @param krihmokshowkbn �o����ڕ\���敪
     */
    public void setKrihmokshowkbn(String krihmokshowkbn) {
        this._krihmokshowkbn = krihmokshowkbn;
    }

}
