package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj10CrCarInfo;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR�Ԏ���w�b�_VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj10CrCarInfoVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj10CrCarInfoVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Tbj10CrCarInfoVO();
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     *
     * @return �d�ʎԎ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj10CrCarInfo.DCARCD);
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     *
     * @param val �d�ʎԎ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj10CrCarInfo.DCARCD, val);
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj10CrCarInfo.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param val �t�F�C�Y
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj10CrCarInfo.PHASE, val);
    }

    /**
     * �N�����擾����
     *
     * @return �N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRDATE() {
        return (Date) get(Tbj10CrCarInfo.CRDATE);
    }

    /**
     * �N����ݒ肷��
     *
     * @param val �N��
     */
    public void setCRDATE(Date val) {
        set(Tbj10CrCarInfo.CRDATE, val);
    }

    /**
     * RAP���擾����
     *
     * @return RAP
     */
    public String getRAP() {
        return (String) get(Tbj10CrCarInfo.RAP);
    }

    /**
     * RAP��ݒ肷��
     *
     * @param val RAP
     */
    public void setRAP(String val) {
        set(Tbj10CrCarInfo.RAP, val);
    }

    /**
     * CP�S���҂��擾����
     *
     * @return CP�S����
     */
    public String getCPUSER() {
        return (String) get(Tbj10CrCarInfo.CPUSER);
    }

    /**
     * CP�S���҂�ݒ肷��
     *
     * @param val CP�S����
     */
    public void setCPUSER(String val) {
        set(Tbj10CrCarInfo.CPUSER, val);
    }

    /**
     * CD/�X�^�b�t���擾����
     *
     * @return CD/�X�^�b�t
     */
    public String getCDSTAFF() {
        return (String) get(Tbj10CrCarInfo.CDSTAFF);
    }

    /**
     * CD/�X�^�b�t��ݒ肷��
     *
     * @param val CD/�X�^�b�t
     */
    public void setCDSTAFF(String val) {
        set(Tbj10CrCarInfo.CDSTAFF, val);
    }

    /**
     * �����Ђ��擾����
     *
     * @return ������
     */
    public String getCRCOMPANY() {
        return (String) get(Tbj10CrCarInfo.CRCOMPANY);
    }

    /**
     * �����Ђ�ݒ肷��
     *
     * @param val ������
     */
    public void setCRCOMPANY(String val) {
        set(Tbj10CrCarInfo.CRCOMPANY, val);
    }

    /**
     * �X�P�W���[���P���擾����
     *
     * @return �X�P�W���[���P
     */
    public String getSCHEDULE1() {
        return (String) get(Tbj10CrCarInfo.SCHEDULE1);
    }

    /**
     * �X�P�W���[���P��ݒ肷��
     *
     * @param val �X�P�W���[���P
     */
    public void setSCHEDULE1(String val) {
        set(Tbj10CrCarInfo.SCHEDULE1, val);
    }

    /**
     * �X�P�W���[���Q���擾����
     *
     * @return �X�P�W���[���Q
     */
    public String getSCHEDULE2() {
        return (String) get(Tbj10CrCarInfo.SCHEDULE2);
    }

    /**
     * �X�P�W���[���Q��ݒ肷��
     *
     * @param val �X�P�W���[���Q
     */
    public void setSCHEDULE2(String val) {
        set(Tbj10CrCarInfo.SCHEDULE2, val);
    }

    /**
     * �X�P�W���[���R���擾����
     *
     * @return �X�P�W���[���R
     */
    public String getSCHEDULE3() {
        return (String) get(Tbj10CrCarInfo.SCHEDULE3);
    }

    /**
     * �X�P�W���[���R��ݒ肷��
     *
     * @param val �X�P�W���[���R
     */
    public void setSCHEDULE3(String val) {
        set(Tbj10CrCarInfo.SCHEDULE3, val);
    }

    /**
     * ���l���擾����
     *
     * @return ���l
     */
    public String getNOTE() {
        return (String) get(Tbj10CrCarInfo.NOTE);
    }

    /**
     * ���l��ݒ肷��
     *
     * @param val ���l
     */
    public void setNOTE(String val) {
        set(Tbj10CrCarInfo.NOTE, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj10CrCarInfo.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param val �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj10CrCarInfo.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj10CrCarInfo.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param val �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj10CrCarInfo.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj10CrCarInfo.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param val �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj10CrCarInfo.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj10CrCarInfo.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param val �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj10CrCarInfo.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj10CrCarInfo.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj10CrCarInfo.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj10CrCarInfo.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj10CrCarInfo.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj10CrCarInfo.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj10CrCarInfo.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj10CrCarInfo.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj10CrCarInfo.UPDID, val);
    }

}
