package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu29Cc;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���ʃR�[�h�}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu29CcVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu29CcVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new RepaVbjaMeu29CcVO();
    }

    /**
     * �R�[�h��ʂ��擾����
     *
     * @return �R�[�h���
     */
    public String getKYCDKND() {
        return (String) get(RepaVbjaMeu29Cc.KYCDKND);
    }

    /**
     * �R�[�h��ʂ�ݒ肷��
     *
     * @param val �R�[�h���
     */
    public void setKYCDKND(String val) {
        set(RepaVbjaMeu29Cc.KYCDKND, val);
    }

    /**
     * �R�[�h���擾����
     *
     * @return �R�[�h
     */
    public String getKYCD() {
        return (String) get(RepaVbjaMeu29Cc.KYCD);
    }

    /**
     * �R�[�h��ݒ肷��
     *
     * @param val �R�[�h
     */
    public void setKYCD(String val) {
        set(RepaVbjaMeu29Cc.KYCD, val);
    }

    /**
     * ���s�N�������擾����
     *
     * @return ���s�N����
     */
    public String getHKYMD() {
        return (String) get(RepaVbjaMeu29Cc.HKYMD);
    }

    /**
     * ���s�N������ݒ肷��
     *
     * @param val ���s�N����
     */
    public void setHKYMD(String val) {
        set(RepaVbjaMeu29Cc.HKYMD, val);
    }

    /**
     * �p�~�N�������擾����
     *
     * @return �p�~�N����
     */
    public String getHAISYMD() {
        return (String) get(RepaVbjaMeu29Cc.HAISYMD);
    }

    /**
     * �p�~�N������ݒ肷��
     *
     * @param val �p�~�N����
     */
    public void setHAISYMD(String val) {
        set(RepaVbjaMeu29Cc.HAISYMD, val);
    }

    /**
     * ���e�i�J�i�j���擾����
     *
     * @return ���e�i�J�i�j
     */
    public String getNAIYKN() {
        return (String) get(RepaVbjaMeu29Cc.NAIYKN);
    }

    /**
     * ���e�i�J�i�j��ݒ肷��
     *
     * @param val ���e�i�J�i�j
     */
    public void setNAIYKN(String val) {
        set(RepaVbjaMeu29Cc.NAIYKN, val);
    }

    /**
     * ���e�i�����j���擾����
     *
     * @return ���e�i�����j
     */
    public String getNAIYJ() {
        return (String) get(RepaVbjaMeu29Cc.NAIYJ);
    }

    /**
     * ���e�i�����j��ݒ肷��
     *
     * @param val ���e�i�����j
     */
    public void setNAIYJ(String val) {
        set(RepaVbjaMeu29Cc.NAIYJ, val);
    }

    /**
     * �\���i�P�j���擾����
     *
     * @return �\���i�P�j
     */
    public String getYOBI1() {
        return (String) get(RepaVbjaMeu29Cc.YOBI1);
    }

    /**
     * �\���i�P�j��ݒ肷��
     *
     * @param val �\���i�P�j
     */
    public void setYOBI1(String val) {
        set(RepaVbjaMeu29Cc.YOBI1, val);
    }

    /**
     * �⑫���擾����
     *
     * @return �⑫
     */
    public String getHOSOK() {
        return (String) get(RepaVbjaMeu29Cc.HOSOK);
    }

    /**
     * �⑫��ݒ肷��
     *
     * @param val �⑫
     */
    public void setHOSOK(String val) {
        set(RepaVbjaMeu29Cc.HOSOK, val);
    }

    /**
     * �\���i�Q�j���擾����
     *
     * @return �\���i�Q�j
     */
    public String getYOBI2() {
        return (String) get(RepaVbjaMeu29Cc.YOBI2);
    }

    /**
     * �\���i�Q�j��ݒ肷��
     *
     * @param val �\���i�Q�j
     */
    public void setYOBI2(String val) {
        set(RepaVbjaMeu29Cc.YOBI2, val);
    }

}
