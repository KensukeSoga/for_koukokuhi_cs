package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * ���ʃR�[�h�}�X�^��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu29CcCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �R�[�h��� */
    private String _kycdknd = null;

    /** �R�[�h */
    private String _kycd = null;

    /** ���s�N���� */
    private String _hkymd = null;

    /** �p�~�N���� */
    private String _haisymd = null;

    /** ���e�i�J�i�j */
    private String _naiykn = null;

    /** ���e�i�����j */
    private String _naiyj = null;

    /** �\���i�P�j */
    private String _yobi1 = null;

    /** �⑫ */
    private String _hosok = null;

    /** �\���i�Q�j */
    private String _yobi2 = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu29CcCondition() {
    }

    /**
     * �R�[�h��ʂ��擾����
     *
     * @return �R�[�h���
     */
    public String getKycdknd() {
        return _kycdknd;
    }

    /**
     * �R�[�h��ʂ�ݒ肷��
     *
     * @param kycdknd �R�[�h���
     */
    public void setKycdknd(String kycdknd) {
        this._kycdknd = kycdknd;
    }

    /**
     * �R�[�h���擾����
     *
     * @return �R�[�h
     */
    public String getKycd() {
        return _kycd;
    }

    /**
     * �R�[�h��ݒ肷��
     *
     * @param kycd �R�[�h
     */
    public void setKycd(String kycd) {
        this._kycd = kycd;
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
     * �\���i�P�j���擾����
     *
     * @return �\���i�P�j
     */
    public String getYobi1() {
        return _yobi1;
    }

    /**
     * �\���i�P�j��ݒ肷��
     *
     * @param yobi1 �\���i�P�j
     */
    public void setYobi1(String yobi1) {
        this._yobi1 = yobi1;
    }

    /**
     * �⑫���擾����
     *
     * @return �⑫
     */
    public String getHosok() {
        return _hosok;
    }

    /**
     * �⑫��ݒ肷��
     *
     * @param hosok �⑫
     */
    public void setHosok(String hosok) {
        this._hosok = hosok;
    }

    /**
     * �\���i�Q�j���擾����
     *
     * @return �\���i�Q�j
     */
    public String getYobi2() {
        return _yobi2;
    }

    /**
     * �\���i�Q�j��ݒ肷��
     *
     * @param yobi2 �\���i�Q�j
     */
    public void setYobi2(String yobi2) {
        this._yobi2 = yobi2;
    }

}
