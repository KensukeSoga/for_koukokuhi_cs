package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj03MediaMng;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �}�̔�Ǘ�VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj03MediaMngVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj03MediaMngVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Tbj03MediaMngVO();
    }

    /**
     * �}�̔�Ǘ�No���擾����
     *
     * @return �}�̔�Ǘ�No
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMEDIAMNGNO() {
        return (BigDecimal) get(Tbj03MediaMng.MEDIAMNGNO);
    }

    /**
     * �}�̔�Ǘ�No��ݒ肷��
     *
     * @param val �}�̔�Ǘ�No
     */
    public void setMEDIAMNGNO(BigDecimal val) {
        set(Tbj03MediaMng.MEDIAMNGNO, val);
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj03MediaMng.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param val �t�F�C�Y
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj03MediaMng.PHASE, val);
    }

    /**
     * �N���擾����
     *
     * @return �N
     */
    public String getMDYEAR() {
        return (String) get(Tbj03MediaMng.MDYEAR);
    }

    /**
     * �N��ݒ肷��
     *
     * @param val �N
     */
    public void setMDYEAR(String val) {
        set(Tbj03MediaMng.MDYEAR, val);
    }

    /**
     * �����擾����
     *
     * @return ��
     */
    public String getMDMONTH() {
        return (String) get(Tbj03MediaMng.MDMONTH);
    }

    /**
     * ����ݒ肷��
     *
     * @param val ��
     */
    public void setMDMONTH(String val) {
        set(Tbj03MediaMng.MDMONTH, val);
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     *
     * @return �d�ʎԎ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj03MediaMng.DCARCD);
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     *
     * @param val �d�ʎԎ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj03MediaMng.DCARCD, val);
    }

    /**
     * �}�̃R�[�h���擾����
     *
     * @return �}�̃R�[�h
     */
    public String getMEDIACD() {
        return (String) get(Tbj03MediaMng.MEDIACD);
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     *
     * @param val �}�̃R�[�h
     */
    public void setMEDIACD(String val) {
        set(Tbj03MediaMng.MEDIACD, val);
    }

    /**
     * �������z���v���擾����
     *
     * @return �������z���v
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHMCOSTTOTAL() {
        return (BigDecimal) get(Tbj03MediaMng.HMCOSTTOTAL);
    }

    /**
     * �������z���v��ݒ肷��
     *
     * @param val �������z���v
     */
    public void setHMCOSTTOTAL(BigDecimal val) {
        set(Tbj03MediaMng.HMCOSTTOTAL, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj03MediaMng.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param val �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj03MediaMng.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj03MediaMng.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param val �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj03MediaMng.CRTNM, val);
    }


    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj03MediaMng.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param val �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj03MediaMng.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj03MediaMng.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param val �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj03MediaMng.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj03MediaMng.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj03MediaMng.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj03MediaMng.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj03MediaMng.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj03MediaMng.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj03MediaMng.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj03MediaMng.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj03MediaMng.UPDID, val);
    }

}
