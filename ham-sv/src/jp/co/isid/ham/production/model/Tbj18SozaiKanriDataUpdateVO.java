package jp.co.isid.ham.production.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �f�ޓo�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/25 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class Tbj18SozaiKanriDataUpdateVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj18SozaiKanriDataUpdateVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Tbj18SozaiKanriDataUpdateVO();
    }

    /**
     * �n�����擾����
     *
     * @return �n��
     */
    public String getNOKBN() {
        return (String) get(Tbj18SozaiKanriData.NOKBN);
    }

    /**
     * �n����ݒ肷��
     *
     * @param val �n��
     */
    public void setNOKBN(String val) {
        set(Tbj18SozaiKanriData.NOKBN, val);
    }

    /**
     * 10��CM���ނ��擾����
     *
     * @return 10��CM����
     */
    public String getCMCD() {
        return (String) get(Tbj18SozaiKanriData.CMCD);
    }

    /**
     * 10��CM���ނ�ݒ肷��
     *
     * @param val 10��CM����
     */
    public void setCMCD(String val) {
        set(Tbj18SozaiKanriData.CMCD, val);
    }

    /**
     * �폜�t���O���擾����
     *
     * @return �폜�t���O
     */
    public String getSTATUS() {
        return (String) get(Tbj18SozaiKanriData.STATUS);
    }

    /**
     * �폜�t���O��ݒ肷��
     *
     * @param val �폜�t���O
     */
    public void setSTATUS(String val) {
        set(Tbj18SozaiKanriData.STATUS, val);
    }

    /**
     * �Ԏ�R�[�h���擾����
     *
     * @return �Ԏ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj18SozaiKanriData.DCARCD);
    }

    /**
     * �Ԏ�R�[�h��ݒ肷��
     *
     * @param val �Ԏ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj18SozaiKanriData.DCARCD, val);
    }

    /**
     * �J�e�S�����擾����
     *
     * @return �J�e�S��
     */
    public String getCATEGORY() {
        return (String) get(Tbj18SozaiKanriData.CATEGORY);
    }

    /**
     * �J�e�S����ݒ肷��
     *
     * @param val �J�e�S��
     */
    public void setCATEGORY(String val) {
        set(Tbj18SozaiKanriData.CATEGORY, val);
    }

    /**
     * �^�C�g�����擾����
     *
     * @return �^�C�g��
     */
    public String getTITLE() {
        return (String) get(Tbj18SozaiKanriData.TITLE);
    }

    /**
     * �^�C�g����ݒ肷��
     *
     * @param val �^�C�g��
     */
    public void setTITLE(String val) {
        set(Tbj18SozaiKanriData.TITLE, val);
    }

    /**
     * �b�����擾����
     *
     * @return �b��
     */
    public String getSECOND() {
        return (String) get(Tbj18SozaiKanriData.SECOND);
    }

    /**
     * �b����ݒ肷��
     *
     * @param val �b��
     */
    public void setSECOND(String val) {
        set(Tbj18SozaiKanriData.SECOND, val);
    }

    /**
     * �Ԏ�S�����擾����
     *
     * @return �Ԏ�S��
     */
    public String getSYATAN() {
        return (String) get(Tbj18SozaiKanriData.SYATAN);
    }

    /**
     * �Ԏ�S����ݒ肷��
     *
     * @param val �Ԏ�S��
     */
    public void setSYATAN(String val) {
        set(Tbj18SozaiKanriData.SYATAN, val);
    }

    /**
     * �[�i�����擾����
     *
     * @return �[�i��
     */
    public String getNOHIN() {
        return (String) get(Tbj18SozaiKanriData.NOHIN);
    }

    /**
     * �[�i����ݒ肷��
     *
     * @param val �[�i��
     */
    public void setNOHIN(String val) {
        set(Tbj18SozaiKanriData.NOHIN, val);
    }

    /**
     * ��������޸��݂��擾����
     *
     * @return ��������޸���
     */
    public String getPRODUCT() {
        return (String) get(Tbj18SozaiKanriData.PRODUCT);
    }

    /**
     * ��������޸��݂�ݒ肷��
     *
     * @param val ��������޸���
     */
    public void setPRODUCT(String val) {
        set(Tbj18SozaiKanriData.PRODUCT, val);
    }

    /**
     * �����J�n�����擾����
     *
     * @return �����J�n��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj18SozaiKanriData.DATEFROM);
    }

    /**
     * �����J�n����ݒ肷��
     *
     * @param val �����J�n��
     */
    public void setDATEFROM(Date val) {
        set(Tbj18SozaiKanriData.DATEFROM, val);
    }

    /**
     * �����I�������擾����
     *
     * @return �����I����
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj18SozaiKanriData.DATETO);
    }

    /**
     * �����I������ݒ肷��
     *
     * @param val �����I����
     */
    public void setDATETO(Date val) {
        set(Tbj18SozaiKanriData.DATETO, val);
    }

    /**
     * ��ި��g�p�������擾����
     *
     * @return ��ި��g�p����
     */
    @XmlElement(required = true, nillable = true)
    public Date getMLIMIT() {
        return (Date) get(Tbj18SozaiKanriData.MLIMIT);
    }

    /**
     * ��ި��g�p������ݒ肷��
     *
     * @param val ��ި��g�p����
     */
    public void setMLIMIT(Date val) {
        set(Tbj18SozaiKanriData.MLIMIT, val);
    }

    /**
     * �����g�p�������擾����
     *
     * @return �����g�p����
     */
    public String getKLIMIT() {
        return (String) get(Tbj18SozaiKanriData.KLIMIT);
    }

    /**
     * �����g�p������ݒ肷��
     *
     * @param val �����g�p����
     */
    public void setKLIMIT(String val) {
        set(Tbj18SozaiKanriData.KLIMIT, val);
    }

    /**
     * �������F�����擾����
     *
     * @return �������F��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATERECOG() {
        return (Date) get(Tbj18SozaiKanriData.DATERECOG);
    }

    /**
     * �������F����ݒ肷��
     *
     * @param val �������F��
     */
    public void setDATERECOG(Date val) {
        set(Tbj18SozaiKanriData.DATERECOG, val);
    }

    /**
     * ���s�����擾����
     *
     * @return ���s��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEPRT() {
        return (Date) get(Tbj18SozaiKanriData.DATEPRT);
    }

    /**
     * ���s����ݒ肷��
     *
     * @param val ���s��
     */
    public void setDATEPRT(Date val) {
        set(Tbj18SozaiKanriData.DATEPRT, val);
    }

    /**
     * ���l���擾����
     *
     * @return ���l
     */
    public String getBIKO() {
        return (String) get(Tbj18SozaiKanriData.BIKO);
    }

    /**
     * ���l��ݒ肷��
     *
     * @param val ���l
     */
    public void setBIKO(String val) {
        set(Tbj18SozaiKanriData.BIKO, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj18SozaiKanriData.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param val �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj18SozaiKanriData.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj18SozaiKanriData.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param val �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj18SozaiKanriData.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj18SozaiKanriData.CRTAPL);
    }

    /**
     * �쐬�v���O�����҂�ݒ肷��
     *
     * @param val �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj18SozaiKanriData.CRTAPL, val);
    }

    /**
     * �쐬��ID���擾����
     *
     * @return �쐬��ID
     */
    public String getCRTID() {
        return (String) get(Tbj18SozaiKanriData.CRTID);
    }

    /**
     * �쐬��ID��ݒ肷��
     *
     * @param val �쐬��ID
     */
    public void setCRTID(String val) {
        set(Tbj18SozaiKanriData.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj18SozaiKanriData.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj18SozaiKanriData.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj18SozaiKanriData.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj18SozaiKanriData.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj18SozaiKanriData.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj18SozaiKanriData.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj18SozaiKanriData.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj18SozaiKanriData.UPDID, val);
    }
    /**
     * �_���ނ��擾����
     *
     * @return �_����
     */
    public String getCTRTKBN() {
        return (String) get(Tbj16ContractInfo.CTRTKBN);
    }

    /**
     * �_���ނ�ݒ肷��
     *
     * @param val �_����
     */
    public void setCTRTKBN(String val) {
        set(Tbj16ContractInfo.CTRTKBN, val);
    }

    /**
     * �_��R�[�h���擾����
     *
     * @return �_��R�[�h
     */
    public String getCTRTNO() {
        return (String) get(Tbj16ContractInfo.CTRTNO);
    }

    /**
     * �_��R�[�h��ݒ肷��
     *
     * @param val �_��R�[�h
     */
    public void setCTRTNO(String val) {
        set(Tbj16ContractInfo.CTRTNO, val);
    }

}