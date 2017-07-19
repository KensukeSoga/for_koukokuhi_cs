package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj36TempSozaiKanriData;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���f�ޓo�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj36TempSozaiKanriDataVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj36TempSozaiKanriDataVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Tbj36TempSozaiKanriDataVO();
    }

    /**
     * �n�����擾����
     *
     * @return �n��
     */
    public String getNOKBN() {
        return (String) get(Tbj36TempSozaiKanriData.NOKBN);
    }

    /**
     * �n����ݒ肷��
     *
     * @param val �n��
     */
    public void setNOKBN(String val) {
        set(Tbj36TempSozaiKanriData.NOKBN, val);
    }

    /**
     * ��10��CM���ނ��擾����
     *
     * @return ��10��CM����
     */
    public String getTEMPCMCD() {
        return (String) get(Tbj36TempSozaiKanriData.TEMPCMCD);
    }

    /**
     * ��10��CM���ނ�ݒ肷��
     *
     * @param val ��10��CM����
     */
    public void setTEMPCMCD(String val) {
        set(Tbj36TempSozaiKanriData.TEMPCMCD, val);
    }

    /**
     * 10��CM���ނ��擾����
     *
     * @return 10��CM����
     */
    public String getCMCD() {
        return (String) get(Tbj36TempSozaiKanriData.CMCD);
    }

    /**
     * 10��CM���ނ�ݒ肷��
     *
     * @param val 10��CM����
     */
    public void setCMCD(String val) {
        set(Tbj36TempSozaiKanriData.CMCD, val);
    }

    /**
     * �X�e�[�^�X���擾����
     *
     * @return �X�e�[�^�X
     */
    public String getSTATUS() {
        return (String) get(Tbj36TempSozaiKanriData.STATUS);
    }

    /**
     * �X�e�[�^�X��ݒ肷��
     *
     * @param val �X�e�[�^�X
     */
    public void setSTATUS(String val) {
        set(Tbj36TempSozaiKanriData.STATUS, val);
    }

    /**
     * �Ԏ�R�[�h���擾����
     *
     * @return �Ԏ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj36TempSozaiKanriData.DCARCD);
    }

    /**
     * �Ԏ�R�[�h��ݒ肷��
     *
     * @param val �Ԏ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj36TempSozaiKanriData.DCARCD, val);
    }

    /**
     * �J�e�S�����擾����
     *
     * @return �J�e�S��
     */
    public String getCATEGORY() {
        return (String) get(Tbj36TempSozaiKanriData.CATEGORY);
    }

    /**
     * �J�e�S����ݒ肷��
     *
     * @param val �J�e�S��
     */
    public void setCATEGORY(String val) {
        set(Tbj36TempSozaiKanriData.CATEGORY, val);
    }

    /**
     * �^�C�g�����擾����
     *
     * @return �^�C�g��
     */
    public String getTITLE() {
        return (String) get(Tbj36TempSozaiKanriData.TITLE);
    }

    /**
     * �^�C�g����ݒ肷��
     *
     * @param val �^�C�g��
     */
    public void setTITLE(String val) {
        set(Tbj36TempSozaiKanriData.TITLE, val);
    }

    /**
     * �ʏ̃^�C�g�����擾����
     *
     * @return �ʏ̃^�C�g��
     */
    public String getALIASTITLE() {
        return (String) get(Tbj36TempSozaiKanriData.ALIASTITLE);
    }

    /**
     * �ʏ̃^�C�g����ݒ肷��
     *
     * @param val �ʏ̃^�C�g��
     */
    public void setALIASTITLE(String val) {
        set(Tbj36TempSozaiKanriData.ALIASTITLE, val);
    }

    /**
     * �Ԃ牺������擾����
     *
     * @return �Ԃ牺����
     */
    public String getENDTITLE() {
        return (String) get(Tbj36TempSozaiKanriData.ENDTITLE);
    }

    /**
     * �Ԃ牺�����ݒ肷��
     *
     * @param val �Ԃ牺����
     */
    public void setENDTITLE(String val) {
        set(Tbj36TempSozaiKanriData.ENDTITLE, val);
    }

    /**
     * �b�����擾����
     *
     * @return �b��
     */
    public String getSECOND() {
        return (String) get(Tbj36TempSozaiKanriData.SECOND);
    }

    /**
     * �b����ݒ肷��
     *
     * @param val �b��
     */
    public void setSECOND(String val) {
        set(Tbj36TempSozaiKanriData.SECOND, val);
    }

    /**
     * �Ԏ�S��(�d��)���擾����
     *
     * @return �Ԏ�S��(�d��)
     */
    public String getSYATAN() {
        return (String) get(Tbj36TempSozaiKanriData.SYATAN);
    }

    /**
     * �Ԏ�S��(�d��)��ݒ肷��
     *
     * @param val �Ԏ�S��(�d��)
     */
    public void setSYATAN(String val) {
        set(Tbj36TempSozaiKanriData.SYATAN, val);
    }

    /**
     * �[�i�����擾����
     *
     * @return �[�i��
     */
    public String getNOHIN() {
        return (String) get(Tbj36TempSozaiKanriData.NOHIN);
    }

    /**
     * �[�i����ݒ肷��
     *
     * @param val �[�i��
     */
    public void setNOHIN(String val) {
        set(Tbj36TempSozaiKanriData.NOHIN, val);
    }

    /**
     * ��������޸��݂��擾����
     *
     * @return ��������޸���
     */
    public String getPRODUCT() {
        return (String) get(Tbj36TempSozaiKanriData.PRODUCT);
    }

    /**
     * ��������޸��݂�ݒ肷��
     *
     * @param val ��������޸���
     */
    public void setPRODUCT(String val) {
        set(Tbj36TempSozaiKanriData.PRODUCT, val);
    }

    /**
     * �����J�n�����擾����
     *
     * @return �����J�n��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj36TempSozaiKanriData.DATEFROM);
    }

    /**
     * �����J�n����ݒ肷��
     *
     * @param val �����J�n��
     */
    public void setDATEFROM(Date val) {
        set(Tbj36TempSozaiKanriData.DATEFROM, val);
    }

    /**
     * �����J�n��(����)���擾����
     *
     * @return �����J�n��(����)
     */
    public String getDATEFROM_ATTR() {
        return (String) get(Tbj36TempSozaiKanriData.DATEFROM_ATTR);
    }

    /**
     * �����J�n��(����)��ݒ肷��
     *
     * @param val �����J�n��(����)
     */
    public void setDATEFROM_ATTR(String val) {
        set(Tbj36TempSozaiKanriData.DATEFROM_ATTR, val);
    }

    /**
     * �����I�������擾����
     *
     * @return �����I����
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj36TempSozaiKanriData.DATETO);
    }

    /**
     * �����I������ݒ肷��
     *
     * @param val �����I����
     */
    public void setDATETO(Date val) {
        set(Tbj36TempSozaiKanriData.DATETO, val);
    }

    /**
     * �����I����(����)���擾����
     *
     * @return �����I����(����)
     */
    public String getDATETO_ATTR() {
        return (String) get(Tbj36TempSozaiKanriData.DATETO_ATTR);
    }

    /**
     * �����I����(����)��ݒ肷��
     *
     * @param val �����I����(����)
     */
    public void setDATETO_ATTR(String val) {
        set(Tbj36TempSozaiKanriData.DATETO_ATTR, val);
    }

    /**
     * ��ި��g�p�������擾����
     *
     * @return ��ި��g�p����
     */
    @XmlElement(required = true, nillable = true)
    public Date getMLIMIT() {
        return (Date) get(Tbj36TempSozaiKanriData.MLIMIT);
    }

    /**
     * ��ި��g�p������ݒ肷��
     *
     * @param val ��ި��g�p����
     */
    public void setMLIMIT(Date val) {
        set(Tbj36TempSozaiKanriData.MLIMIT, val);
    }

    /**
     * �����g�p�������擾����
     *
     * @return �����g�p����
     */
    public String getKLIMIT() {
        return (String) get(Tbj36TempSozaiKanriData.KLIMIT);
    }

    /**
     * �����g�p������ݒ肷��
     *
     * @param val �����g�p����
     */
    public void setKLIMIT(String val) {
        set(Tbj36TempSozaiKanriData.KLIMIT, val);
    }

    /**
     * �������F�����擾����
     *
     * @return �������F��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATERECOG() {
        return (Date) get(Tbj36TempSozaiKanriData.DATERECOG);
    }

    /**
     * �������F����ݒ肷��
     *
     * @param val �������F��
     */
    public void setDATERECOG(Date val) {
        set(Tbj36TempSozaiKanriData.DATERECOG, val);
    }

    /**
     * ���s�����擾����
     *
     * @return ���s��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEPRT() {
        return (Date) get(Tbj36TempSozaiKanriData.DATEPRT);
    }

    /**
     * ���s����ݒ肷��
     *
     * @param val ���s��
     */
    public void setDATEPRT(Date val) {
        set(Tbj36TempSozaiKanriData.DATEPRT, val);
    }

    /**
     * ���l���擾����
     *
     * @return ���l
     */
    public String getBIKO() {
        return (String) get(Tbj36TempSozaiKanriData.BIKO);
    }

    /**
     * ���l��ݒ肷��
     *
     * @param val ���l
     */
    public void setBIKO(String val) {
        set(Tbj36TempSozaiKanriData.BIKO, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj36TempSozaiKanriData.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param val �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj36TempSozaiKanriData.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj36TempSozaiKanriData.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param val �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj36TempSozaiKanriData.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj36TempSozaiKanriData.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param val �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj36TempSozaiKanriData.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj36TempSozaiKanriData.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param val �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj36TempSozaiKanriData.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj36TempSozaiKanriData.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj36TempSozaiKanriData.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj36TempSozaiKanriData.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj36TempSozaiKanriData.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj36TempSozaiKanriData.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj36TempSozaiKanriData.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj36TempSozaiKanriData.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj36TempSozaiKanriData.UPDID, val);
    }

}
