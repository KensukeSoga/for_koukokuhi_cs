package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj28WorkLog;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �ғ����OVO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj28WorkLogVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj28WorkLogVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Tbj28WorkLogVO();
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj28WorkLog.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param val �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj28WorkLog.CRTDATE, val);
    }

    /**
     * �S����ID(ESQID)���擾����
     *
     * @return �S����ID(ESQID)
     */
    public String getHAMID() {
        return (String) get(Tbj28WorkLog.HAMID);
    }

    /**
     * �S����ID(ESQID)��ݒ肷��
     *
     * @param val �S����ID(ESQID)
     */
    public void setHAMID(String val) {
        set(Tbj28WorkLog.HAMID, val);
    }

    /**
     * �S���Җ����擾����
     *
     * @return �S���Җ�
     */
    public String getHAMNM() {
        return (String) get(Tbj28WorkLog.HAMNM);
    }

    /**
     * �S���Җ���ݒ肷��
     *
     * @param val �S���Җ�
     */
    public void setHAMNM(String val) {
        set(Tbj28WorkLog.HAMNM, val);
    }

    /**
     * �g�D�R�[�h�i�{���j���擾����
     *
     * @return �g�D�R�[�h�i�{���j
     */
    public String getSIKCDHONB() {
        return (String) get(Tbj28WorkLog.SIKCDHONB);
    }

    /**
     * �g�D�R�[�h�i�{���j��ݒ肷��
     *
     * @param val �g�D�R�[�h�i�{���j
     */
    public void setSIKCDHONB(String val) {
        set(Tbj28WorkLog.SIKCDHONB, val);
    }

    /**
     * �{���\�����i�����j���擾����
     *
     * @return �{���\�����i�����j
     */
    public String getSIKNMHONB() {
        return (String) get(Tbj28WorkLog.SIKNMHONB);
    }

    /**
     * �{���\�����i�����j��ݒ肷��
     *
     * @param val �{���\�����i�����j
     */
    public void setSIKNMHONB(String val) {
        set(Tbj28WorkLog.SIKNMHONB, val);
    }

    /**
     * �g�D�R�[�h�i�ǁj���擾����
     *
     * @return �g�D�R�[�h�i�ǁj
     */
    public String getSIKCDKYK() {
        return (String) get(Tbj28WorkLog.SIKCDKYK);
    }

    /**
     * �g�D�R�[�h�i�ǁj��ݒ肷��
     *
     * @param val �g�D�R�[�h�i�ǁj
     */
    public void setSIKCDKYK(String val) {
        set(Tbj28WorkLog.SIKCDKYK, val);
    }

    /**
     * �Ǖ\�����i�����j���擾����
     *
     * @return �Ǖ\�����i�����j
     */
    public String getSIKNMKYK() {
        return (String) get(Tbj28WorkLog.SIKNMKYK);
    }

    /**
     * �Ǖ\�����i�����j��ݒ肷��
     *
     * @param val �Ǖ\�����i�����j
     */
    public void setSIKNMKYK(String val) {
        set(Tbj28WorkLog.SIKNMKYK, val);
    }

    /**
     * �g�D�R�[�h�i���j���擾����
     *
     * @return �g�D�R�[�h�i���j
     */
    public String getSIKCDSITU() {
        return (String) get(Tbj28WorkLog.SIKCDSITU);
    }

    /**
     * �g�D�R�[�h�i���j��ݒ肷��
     *
     * @param val �g�D�R�[�h�i���j
     */
    public void setSIKCDSITU(String val) {
        set(Tbj28WorkLog.SIKCDSITU, val);
    }

    /**
     * ���\�����i�����j���擾����
     *
     * @return ���\�����i�����j
     */
    public String getSIKNMSITU() {
        return (String) get(Tbj28WorkLog.SIKNMSITU);
    }

    /**
     * ���\�����i�����j��ݒ肷��
     *
     * @param val ���\�����i�����j
     */
    public void setSIKNMSITU(String val) {
        set(Tbj28WorkLog.SIKNMSITU, val);
    }

    /**
     * �g�D�R�[�h�i���j���擾����
     *
     * @return �g�D�R�[�h�i���j
     */
    public String getSIKCDBU() {
        return (String) get(Tbj28WorkLog.SIKCDBU);
    }

    /**
     * �g�D�R�[�h�i���j��ݒ肷��
     *
     * @param val �g�D�R�[�h�i���j
     */
    public void setSIKCDBU(String val) {
        set(Tbj28WorkLog.SIKCDBU, val);
    }

    /**
     * ���\�����i�����j���擾����
     *
     * @return ���\�����i�����j
     */
    public String getSIKNMBU() {
        return (String) get(Tbj28WorkLog.SIKNMBU);
    }

    /**
     * ���\�����i�����j��ݒ肷��
     *
     * @param val ���\�����i�����j
     */
    public void setSIKNMBU(String val) {
        set(Tbj28WorkLog.SIKNMBU, val);
    }

    /**
     * �g�D�R�[�h�i�ہj���擾����
     *
     * @return �g�D�R�[�h�i�ہj
     */
    public String getSIKCDKA() {
        return (String) get(Tbj28WorkLog.SIKCDKA);
    }

    /**
     * �g�D�R�[�h�i�ہj��ݒ肷��
     *
     * @param val �g�D�R�[�h�i�ہj
     */
    public void setSIKCDKA(String val) {
        set(Tbj28WorkLog.SIKCDKA, val);
    }

    /**
     * �ە\�����i�����j���擾����
     *
     * @return �ە\�����i�����j
     */
    public String getSIKNMKA() {
        return (String) get(Tbj28WorkLog.SIKNMKA);
    }

    /**
     * �ە\�����i�����j��ݒ肷��
     *
     * @param val �ە\�����i�����j
     */
    public void setSIKNMKA(String val) {
        set(Tbj28WorkLog.SIKNMKA, val);
    }

    /**
     * ���ID���擾����
     *
     * @return ���ID
     */
    public String getFORMID() {
        return (String) get(Tbj28WorkLog.FORMID);
    }

    /**
     * ���ID��ݒ肷��
     *
     * @param val ���ID
     */
    public void setFORMID(String val) {
        set(Tbj28WorkLog.FORMID, val);
    }

    /**
     * ��ʖ����擾����
     *
     * @return ��ʖ�
     */
    public String getFORMNM() {
        return (String) get(Tbj28WorkLog.FORMNM);
    }

    /**
     * ��ʖ���ݒ肷��
     *
     * @param val ��ʖ�
     */
    public void setFORMNM(String val) {
        set(Tbj28WorkLog.FORMNM, val);
    }

    /**
     * �@�\ID���擾����
     *
     * @return �@�\ID
     */
    public String getKNOID() {
        return (String) get(Tbj28WorkLog.KNOID);
    }

    /**
     * �@�\ID��ݒ肷��
     *
     * @param val �@�\ID
     */
    public void setKNOID(String val) {
        set(Tbj28WorkLog.KNOID, val);
    }

    /**
     * �@�\�����擾����
     *
     * @return �@�\��
     */
    public String getKNONM() {
        return (String) get(Tbj28WorkLog.KNONM);
    }

    /**
     * �@�\����ݒ肷��
     *
     * @param val �@�\��
     */
    public void setKNONM(String val) {
        set(Tbj28WorkLog.KNONM, val);
    }

    /**
     * ����ID���擾����
     *
     * @return ����ID
     */
    public String getDSMID() {
        return (String) get(Tbj28WorkLog.DSMID);
    }

    /**
     * ����ID��ݒ肷��
     *
     * @param val ����ID
     */
    public void setDSMID(String val) {
        set(Tbj28WorkLog.DSMID, val);
    }

    /**
     * ���얼���擾����
     *
     * @return ���얼
     */
    public String getDSMNM() {
        return (String) get(Tbj28WorkLog.DSMNM);
    }

    /**
     * ���얼��ݒ肷��
     *
     * @param val ���얼
     */
    public void setDSMNM(String val) {
        set(Tbj28WorkLog.DSMNM, val);
    }

}
