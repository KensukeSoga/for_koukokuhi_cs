package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj13CampDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �L�����y�[������VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj13CampDetailVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj13CampDetailVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Tbj13CampDetailVO();
    }

    /**
     * �L�����y�[���R�[�h���擾����
     *
     * @return �L�����y�[���R�[�h
     */
    public String getCAMPCD() {
        return (String) get(Tbj13CampDetail.CAMPCD);
    }

    /**
     * �L�����y�[���R�[�h��ݒ肷��
     *
     * @param val �L�����y�[���R�[�h
     */
    public void setCAMPCD(String val) {
        set(Tbj13CampDetail.CAMPCD, val);
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     *
     * @return �d�ʎԎ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj13CampDetail.DCARCD);
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     *
     * @param val �d�ʎԎ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj13CampDetail.DCARCD, val);
    }

    /**
     * �}�̃R�[�h���擾����
     *
     * @return �}�̃R�[�h
     */
    public String getMEDIACD() {
        return (String) get(Tbj13CampDetail.MEDIACD);
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     *
     * @param val �}�̃R�[�h
     */
    public void setMEDIACD(String val) {
        set(Tbj13CampDetail.MEDIACD, val);
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj13CampDetail.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param val �t�F�C�Y
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj13CampDetail.PHASE, val);
    }

    /**
     * �o�e�\��N�����擾����
     *
     * @return �o�e�\��N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getYOTEIYM() {
        return (Date) get(Tbj13CampDetail.YOTEIYM);
    }

    /**
     * �o�e�\��N����ݒ肷��
     *
     * @param val �o�e�\��N��
     */
    public void setYOTEIYM(Date val) {
        set(Tbj13CampDetail.YOTEIYM, val);
    }

    /**
     * �\����ԊJ�n���擾����
     *
     * @return �\����ԊJ�n
     */
    @XmlElement(required = true, nillable = true)
    public Date getKIKANFROM() {
        return (Date) get(Tbj13CampDetail.KIKANFROM);
    }

    /**
     * �\����ԊJ�n��ݒ肷��
     *
     * @param val �\����ԊJ�n
     */
    public void setKIKANFROM(Date val) {
        set(Tbj13CampDetail.KIKANFROM, val);
    }

    /**
     * �\����ԏI�����擾����
     *
     * @return �\����ԏI��
     */
    @XmlElement(required = true, nillable = true)
    public Date getKIKANTO() {
        return (Date) get(Tbj13CampDetail.KIKANTO);
    }

    /**
     * �\����ԏI����ݒ肷��
     *
     * @param val �\����ԏI��
     */
    public void setKIKANTO(Date val) {
        set(Tbj13CampDetail.KIKANTO, val);
    }

    /**
     * �\�Z���z���擾����
     *
     * @return �\�Z���z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getBUDGET() {
        return (BigDecimal) get(Tbj13CampDetail.BUDGET);
    }

    /**
     * �\�Z���z��ݒ肷��
     *
     * @param val �\�Z���z
     */
    public void setBUDGET(BigDecimal val) {
        set(Tbj13CampDetail.BUDGET, val);
    }

    /**
     * �\�Z���z(�V)���擾����
     *
     * @return �\�Z���z(�V)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getBUDGETHM() {
        return (BigDecimal) get(Tbj13CampDetail.BUDGETHM);
    }

    /**
     * �\�Z���z(�V)��ݒ肷��
     *
     * @param val �\�Z���z(�V)
     */
    public void setBUDGETHM(BigDecimal val) {
        set(Tbj13CampDetail.BUDGETHM, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj13CampDetail.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param val �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj13CampDetail.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj13CampDetail.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param val �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj13CampDetail.CRTNM, val);
    }

    /**
     * �f�[�^�쐬�A�v�����擾����
     *
     * @return �f�[�^�쐬�A�v��
     */
    public String getCRTAPL() {
        return (String) get(Tbj13CampDetail.CRTAPL);
    }

    /**
     * �f�[�^�쐬�A�v����ݒ肷��
     *
     * @param val �f�[�^�쐬�A�v��
     */
    public void setCRTAPL(String val) {
        set(Tbj13CampDetail.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj13CampDetail.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param val �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj13CampDetail.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj13CampDetail.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj13CampDetail.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj13CampDetail.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj13CampDetail.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj13CampDetail.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj13CampDetail.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj13CampDetail.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj13CampDetail.UPDID, val);
    }

}
