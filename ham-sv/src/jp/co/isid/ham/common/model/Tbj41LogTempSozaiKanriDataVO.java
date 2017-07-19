package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj41LogTempSozaiKanriData;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���f�ޓo�^�ύX���OVO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj41LogTempSozaiKanriDataVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj41LogTempSozaiKanriDataVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Tbj41LogTempSozaiKanriDataVO();
    }

    /**
     * �n�����擾����
     *
     * @return �n��
     */
    public String getNOKBN() {
        return (String) get(Tbj41LogTempSozaiKanriData.NOKBN);
    }

    /**
     * �n����ݒ肷��
     *
     * @param val �n��
     */
    public void setNOKBN(String val) {
        set(Tbj41LogTempSozaiKanriData.NOKBN, val);
    }

    /**
     * ��10��CM���ނ��擾����
     *
     * @return ��10��CM����
     */
    public String getTEMPCMCD() {
        return (String) get(Tbj41LogTempSozaiKanriData.TEMPCMCD);
    }

    /**
     * ��10��CM���ނ�ݒ肷��
     *
     * @param val ��10��CM����
     */
    public void setTEMPCMCD(String val) {
        set(Tbj41LogTempSozaiKanriData.TEMPCMCD, val);
    }

    /**
     * ����NO���擾����
     *
     * @return ����NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHISTORYNO() {
        return (BigDecimal) get(Tbj41LogTempSozaiKanriData.HISTORYNO);
    }

    /**
     * ����NO��ݒ肷��
     *
     * @param val ����NO
     */
    public void setHISTORYNO(BigDecimal val) {
        set(Tbj41LogTempSozaiKanriData.HISTORYNO, val);
    }

    /**
     * 10��CM���ނ��擾����
     *
     * @return 10��CM����
     */
    public String getCMCD() {
        return (String) get(Tbj41LogTempSozaiKanriData.CMCD);
    }

    /**
     * 10��CM���ނ�ݒ肷��
     *
     * @param val 10��CM����
     */
    public void setCMCD(String val) {
        set(Tbj41LogTempSozaiKanriData.CMCD, val);
    }

    /**
     * �����敪���擾����
     *
     * @return �����敪
     */
    public String getHISTORYKBN() {
        return (String) get(Tbj41LogTempSozaiKanriData.HISTORYKBN);
    }

    /**
     * �����敪��ݒ肷��
     *
     * @param val �����敪
     */
    public void setHISTORYKBN(String val) {
        set(Tbj41LogTempSozaiKanriData.HISTORYKBN, val);
    }

    /**
     * �폜�t���O���擾����
     *
     * @return �폜�t���O
     */
    public String getDELFLG() {
        return (String) get(Tbj41LogTempSozaiKanriData.DELFLG);
    }

    /**
     * �폜�t���O��ݒ肷��
     *
     * @param val �폜�t���O
     */
    public void setDELFLG(String val) {
        set(Tbj41LogTempSozaiKanriData.DELFLG, val);
    }

    /**
     * �Ԏ�R�[�h���擾����
     *
     * @return �Ԏ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj41LogTempSozaiKanriData.DCARCD);
    }

    /**
     * �Ԏ�R�[�h��ݒ肷��
     *
     * @param val �Ԏ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj41LogTempSozaiKanriData.DCARCD, val);
    }

    /**
     * �J�e�S�����擾����
     *
     * @return �J�e�S��
     */
    public String getCATEGORY() {
        return (String) get(Tbj41LogTempSozaiKanriData.CATEGORY);
    }

    /**
     * �J�e�S����ݒ肷��
     *
     * @param val �J�e�S��
     */
    public void setCATEGORY(String val) {
        set(Tbj41LogTempSozaiKanriData.CATEGORY, val);
    }

    /**
     * �^�C�g�����擾����
     *
     * @return �^�C�g��
     */
    public String getTITLE() {
        return (String) get(Tbj41LogTempSozaiKanriData.TITLE);
    }

    /**
     * �^�C�g����ݒ肷��
     *
     * @param val �^�C�g��
     */
    public void setTITLE(String val) {
        set(Tbj41LogTempSozaiKanriData.TITLE, val);
    }

    /**
     * �ʏ̃^�C�g�����擾����
     *
     * @return �ʏ̃^�C�g��
     */
    public String getALIASTITLE() {
        return (String) get(Tbj41LogTempSozaiKanriData.ALIASTITLE);
    }

    /**
     * �ʏ̃^�C�g����ݒ肷��
     *
     * @param val �ʏ̃^�C�g��
     */
    public void setALIASTITLE(String val) {
        set(Tbj41LogTempSozaiKanriData.ALIASTITLE, val);
    }

    /**
     * �Ԃ牺������擾����
     *
     * @return �Ԃ牺����
     */
    public String getENDTITLE() {
        return (String) get(Tbj41LogTempSozaiKanriData.ENDTITLE);
    }

    /**
     * �Ԃ牺�����ݒ肷��
     *
     * @param val �Ԃ牺����
     */
    public void setENDTITLE(String val) {
        set(Tbj41LogTempSozaiKanriData.ENDTITLE, val);
    }

    /**
     * �b�����擾����
     *
     * @return �b��
     */
    public String getSECOND() {
        return (String) get(Tbj41LogTempSozaiKanriData.SECOND);
    }

    /**
     * �b����ݒ肷��
     *
     * @param val �b��
     */
    public void setSECOND(String val) {
        set(Tbj41LogTempSozaiKanriData.SECOND, val);
    }

    /**
     * �Ԏ�S�����擾����
     *
     * @return �Ԏ�S��
     */
    public String getSYATAN() {
        return (String) get(Tbj41LogTempSozaiKanriData.SYATAN);
    }

    /**
     * �Ԏ�S����ݒ肷��
     *
     * @param val �Ԏ�S��
     */
    public void setSYATAN(String val) {
        set(Tbj41LogTempSozaiKanriData.SYATAN, val);
    }

    /**
     * �[�i�����擾����
     *
     * @return �[�i��
     */
    public String getNOHIN() {
        return (String) get(Tbj41LogTempSozaiKanriData.NOHIN);
    }

    /**
     * �[�i����ݒ肷��
     *
     * @param val �[�i��
     */
    public void setNOHIN(String val) {
        set(Tbj41LogTempSozaiKanriData.NOHIN, val);
    }

    /**
     * ��������޸��݂��擾����
     *
     * @return ��������޸���
     */
    public String getPRODUCT() {
        return (String) get(Tbj41LogTempSozaiKanriData.PRODUCT);
    }

    /**
     * ��������޸��݂�ݒ肷��
     *
     * @param val ��������޸���
     */
    public void setPRODUCT(String val) {
        set(Tbj41LogTempSozaiKanriData.PRODUCT, val);
    }

    /**
     * �����J�n�����擾����
     *
     * @return �����J�n��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj41LogTempSozaiKanriData.DATEFROM);
    }

    /**
     * �����J�n����ݒ肷��
     *
     * @param val �����J�n��
     */
    public void setDATEFROM(Date val) {
        set(Tbj41LogTempSozaiKanriData.DATEFROM, val);
    }

    /**
     * �����J�n��(����)���擾����
     *
     * @return �����J�n��(����)
     */
    public String getDATEFROM_ATTR() {
        return (String) get(Tbj41LogTempSozaiKanriData.DATEFROM_ATTR);
    }

    /**
     * �����J�n��(����)��ݒ肷��
     *
     * @param val �����J�n��(����)
     */
    public void setDATEFROM_ATTR(String val) {
        set(Tbj41LogTempSozaiKanriData.DATEFROM_ATTR, val);
    }

    /**
     * �����I�������擾����
     *
     * @return �����I����
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj41LogTempSozaiKanriData.DATETO);
    }

    /**
     * �����I������ݒ肷��
     *
     * @param val �����I����
     */
    public void setDATETO(Date val) {
        set(Tbj41LogTempSozaiKanriData.DATETO, val);
    }

    /**
     * �����I����(����)���擾����
     *
     * @return �����I����(����)
     */
    public String getDATETO_ATTR() {
        return (String) get(Tbj41LogTempSozaiKanriData.DATETO_ATTR);
    }

    /**
     * �����I����(����)��ݒ肷��
     *
     * @param val �����I����(����)
     */
    public void setDATETO_ATTR(String val) {
        set(Tbj41LogTempSozaiKanriData.DATETO_ATTR, val);
    }

    /**
     * ��ި��g�p�������擾����
     *
     * @return ��ި��g�p����
     */
    @XmlElement(required = true, nillable = true)
    public Date getMLIMIT() {
        return (Date) get(Tbj41LogTempSozaiKanriData.MLIMIT);
    }

    /**
     * ��ި��g�p������ݒ肷��
     *
     * @param val ��ި��g�p����
     */
    public void setMLIMIT(Date val) {
        set(Tbj41LogTempSozaiKanriData.MLIMIT, val);
    }

    /**
     * �����g�p�������擾����
     *
     * @return �����g�p����
     */
    public String getKLIMIT() {
        return (String) get(Tbj41LogTempSozaiKanriData.KLIMIT);
    }

    /**
     * �����g�p������ݒ肷��
     *
     * @param val �����g�p����
     */
    public void setKLIMIT(String val) {
        set(Tbj41LogTempSozaiKanriData.KLIMIT, val);
    }

    /**
     * �������F�����擾����
     *
     * @return �������F��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATERECOG() {
        return (Date) get(Tbj41LogTempSozaiKanriData.DATERECOG);
    }

    /**
     * �������F����ݒ肷��
     *
     * @param val �������F��
     */
    public void setDATERECOG(Date val) {
        set(Tbj41LogTempSozaiKanriData.DATERECOG, val);
    }

    /**
     * ���s�����擾����
     *
     * @return ���s��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEPRT() {
        return (Date) get(Tbj41LogTempSozaiKanriData.DATEPRT);
    }

    /**
     * ���s����ݒ肷��
     *
     * @param val ���s��
     */
    public void setDATEPRT(Date val) {
        set(Tbj41LogTempSozaiKanriData.DATEPRT, val);
    }

    /**
     * ���l���擾����
     *
     * @return ���l
     */
    public String getBIKO() {
        return (String) get(Tbj41LogTempSozaiKanriData.BIKO);
    }

    /**
     * ���l��ݒ肷��
     *
     * @param val ���l
     */
    public void setBIKO(String val) {
        set(Tbj41LogTempSozaiKanriData.BIKO, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj41LogTempSozaiKanriData.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param val �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj41LogTempSozaiKanriData.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj41LogTempSozaiKanriData.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param val �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj41LogTempSozaiKanriData.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj41LogTempSozaiKanriData.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param val �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj41LogTempSozaiKanriData.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj41LogTempSozaiKanriData.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param val �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj41LogTempSozaiKanriData.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj41LogTempSozaiKanriData.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj41LogTempSozaiKanriData.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj41LogTempSozaiKanriData.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj41LogTempSozaiKanriData.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj41LogTempSozaiKanriData.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj41LogTempSozaiKanriData.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj41LogTempSozaiKanriData.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj41LogTempSozaiKanriData.UPDID, val);
    }

}
