package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj37RdProgram;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���W�I�ԑgVO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj37RdProgramVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj37RdProgramVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Tbj37RdProgramVO();
    }

    /**
     * ���W�I�ԑgSEQNO���擾����
     *
     * @return ���W�I�ԑgSEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getRDSEQNO() {
        return (BigDecimal) get(Tbj37RdProgram.RDSEQNO);
    }

    /**
     * ���W�I�ԑgSEQNO��ݒ肷��
     *
     * @param val ���W�I�ԑgSEQNO
     */
    public void setRDSEQNO(BigDecimal val) {
        set(Tbj37RdProgram.RDSEQNO, val);
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj37RdProgram.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param val �t�F�C�Y
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj37RdProgram.PHASE, val);
    }

    /**
     * �ԑg�����擾����
     *
     * @return �ԑg��
     */
    public String getPROGRAMNM() {
        return (String) get(Tbj37RdProgram.PROGRAMNM);
    }

    /**
     * �ԑg����ݒ肷��
     *
     * @param val �ԑg��
     */
    public void setPROGRAMNM(String val) {
        set(Tbj37RdProgram.PROGRAMNM, val);
    }

    /**
     * ���P�敪���擾����
     *
     * @return ���P�敪
     */
    public String getRSDIV() {
        return (String) get(Tbj37RdProgram.RSDIV);
    }

    /**
     * ���P�敪��ݒ肷��
     *
     * @param val ���P�敪
     */
    public void setRSDIV(String val) {
        set(Tbj37RdProgram.RSDIV, val);
    }

    /**
     * �l�b�g���[�J���敪���擾����
     *
     * @return �l�b�g���[�J���敪
     */
    public String getNLDIV() {
        return (String) get(Tbj37RdProgram.NLDIV);
    }

    /**
     * �l�b�g���[�J���敪��ݒ肷��
     *
     * @param val �l�b�g���[�J���敪
     */
    public void setNLDIV(String val) {
        set(Tbj37RdProgram.NLDIV, val);
    }

    /**
     * �b�����擾����
     *
     * @return �b��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSECOND() {
        return (BigDecimal) get(Tbj37RdProgram.SECOND);
    }

    /**
     * �b����ݒ肷��
     *
     * @param val �b��
     */
    public void setSECOND(BigDecimal val) {
        set(Tbj37RdProgram.SECOND, val);
    }

    /**
     * �g���擾����
     *
     * @return �g
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getTIMES() {
        return (BigDecimal) get(Tbj37RdProgram.TIMES);
    }

    /**
     * �g��ݒ肷��
     *
     * @param val �g
     */
    public void setTIMES(BigDecimal val) {
        set(Tbj37RdProgram.TIMES, val);
    }

    /**
     * ���b�����擾����
     *
     * @return ���b��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getTOTALSECOND() {
        return (BigDecimal) get(Tbj37RdProgram.TOTALSECOND);
    }

    /**
     * ���b����ݒ肷��
     *
     * @param val ���b��
     */
    public void setTOTALSECOND(BigDecimal val) {
        set(Tbj37RdProgram.TOTALSECOND, val);
    }

    /**
     * �����J�n�����擾����
     *
     * @return �����J�n��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj37RdProgram.DATEFROM);
    }

    /**
     * �����J�n����ݒ肷��
     *
     * @param val �����J�n��
     */
    public void setDATEFROM(Date val) {
        set(Tbj37RdProgram.DATEFROM, val);
    }

    /**
     * �����I�������擾����
     *
     * @return �����I����
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj37RdProgram.DATETO);
    }

    /**
     * �����I������ݒ肷��
     *
     * @param val �����I����
     */
    public void setDATETO(Date val) {
        set(Tbj37RdProgram.DATETO, val);
    }

    /**
     * �L�[�ǃR�[�h���擾����
     *
     * @return �L�[�ǃR�[�h
     */
    public String getKEYSTATIONCD() {
        return (String) get(Tbj37RdProgram.KEYSTATIONCD);
    }

    /**
     * �L�[�ǃR�[�h��ݒ肷��
     *
     * @param val �L�[�ǃR�[�h
     */
    public void setKEYSTATIONCD(String val) {
        set(Tbj37RdProgram.KEYSTATIONCD, val);
    }

    /**
     * �����J�n���Ԃ��擾����
     *
     * @return �����J�n����
     */
    public String getSTARTTIME() {
        return (String) get(Tbj37RdProgram.STARTTIME);
    }

    /**
     * �����J�n���Ԃ�ݒ肷��
     *
     * @param val �����J�n����
     */
    public void setSTARTTIME(String val) {
        set(Tbj37RdProgram.STARTTIME, val);
    }

    /**
     * �����I�����Ԃ��擾����
     *
     * @return �����I������
     */
    public String getENDTIME() {
        return (String) get(Tbj37RdProgram.ENDTIME);
    }

    /**
     * �����I�����Ԃ�ݒ肷��
     *
     * @param val �����I������
     */
    public void setENDTIME(String val) {
        set(Tbj37RdProgram.ENDTIME, val);
    }

    /**
     * ���㗿���ݒ�敪���擾����
     *
     * @return ���㗿���ݒ�敪
     */
    public String getSALESPRICEDIV() {
        return (String) get(Tbj37RdProgram.SALESPRICEDIV);
    }

    /**
     * ���㗿���ݒ�敪��ݒ肷��
     *
     * @param val ���㗿���ݒ�敪
     */
    public void setSALESPRICEDIV(String val) {
        set(Tbj37RdProgram.SALESPRICEDIV, val);
    }

    /**
     * ���㗿���ݒ���擾����
     *
     * @return ���㗿���ݒ�
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSALESPRICE() {
        return (BigDecimal) get(Tbj37RdProgram.SALESPRICE);
    }

    /**
     * ���㗿���ݒ��ݒ肷��
     *
     * @param val ���㗿���ݒ�
     */
    public void setSALESPRICE(BigDecimal val) {
        set(Tbj37RdProgram.SALESPRICE, val);
    }

    /**
     * �ݒ�z�����ݒ�敪���擾����
     *
     * @return �ݒ�z�����ݒ�敪
     */
    public String getCONFIGPRICEDIV() {
        return (String) get(Tbj37RdProgram.CONFIGPRICEDIV);
    }

    /**
     * �ݒ�z�����ݒ�敪��ݒ肷��
     *
     * @param val �ݒ�z�����ݒ�敪
     */
    public void setCONFIGPRICEDIV(String val) {
        set(Tbj37RdProgram.CONFIGPRICEDIV, val);
    }

    /**
     * �ݒ�z�����ݒ���擾����
     *
     * @return �ݒ�z�����ݒ�
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCONFIGPRICE() {
        return (BigDecimal) get(Tbj37RdProgram.CONFIGPRICE);
    }

    /**
     * �ݒ�z�����ݒ��ݒ肷��
     *
     * @param val �ݒ�z�����ݒ�
     */
    public void setCONFIGPRICE(BigDecimal val) {
        set(Tbj37RdProgram.CONFIGPRICE, val);
    }

    /**
     * ���j���������擾����
     *
     * @return ���j������
     */
    public String getONAIRMON() {
        return (String) get(Tbj37RdProgram.ONAIRMON);
    }

    /**
     * ���j��������ݒ肷��
     *
     * @param val ���j������
     */
    public void setONAIRMON(String val) {
        set(Tbj37RdProgram.ONAIRMON, val);
    }

    /**
     * �Ηj���������擾����
     *
     * @return �Ηj������
     */
    public String getONAIRTUE() {
        return (String) get(Tbj37RdProgram.ONAIRTUE);
    }

    /**
     * �Ηj��������ݒ肷��
     *
     * @param val �Ηj������
     */
    public void setONAIRTUE(String val) {
        set(Tbj37RdProgram.ONAIRTUE, val);
    }

    /**
     * ���j���������擾����
     *
     * @return ���j������
     */
    public String getONAIRWED() {
        return (String) get(Tbj37RdProgram.ONAIRWED);
    }

    /**
     * ���j��������ݒ肷��
     *
     * @param val ���j������
     */
    public void setONAIRWED(String val) {
        set(Tbj37RdProgram.ONAIRWED, val);
    }

    /**
     * �ؗj���������擾����
     *
     * @return �ؗj������
     */
    public String getONAIRTHU() {
        return (String) get(Tbj37RdProgram.ONAIRTHU);
    }

    /**
     * �ؗj��������ݒ肷��
     *
     * @param val �ؗj������
     */
    public void setONAIRTHU(String val) {
        set(Tbj37RdProgram.ONAIRTHU, val);
    }

    /**
     * ���j���������擾����
     *
     * @return ���j������
     */
    public String getONAIRFRI() {
        return (String) get(Tbj37RdProgram.ONAIRFRI);
    }

    /**
     * ���j��������ݒ肷��
     *
     * @param val ���j������
     */
    public void setONAIRFRI(String val) {
        set(Tbj37RdProgram.ONAIRFRI, val);
    }

    /**
     * �y�j���������擾����
     *
     * @return �y�j������
     */
    public String getONAIRSAT() {
        return (String) get(Tbj37RdProgram.ONAIRSAT);
    }

    /**
     * �y�j��������ݒ肷��
     *
     * @param val �y�j������
     */
    public void setONAIRSAT(String val) {
        set(Tbj37RdProgram.ONAIRSAT, val);
    }

    /**
     * ���j���������擾����
     *
     * @return ���j������
     */
    public String getONAIRSUN() {
        return (String) get(Tbj37RdProgram.ONAIRSUN);
    }

    /**
     * ���j��������ݒ肷��
     *
     * @param val ���j������
     */
    public void setONAIRSUN(String val) {
        set(Tbj37RdProgram.ONAIRSUN, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj37RdProgram.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param val �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj37RdProgram.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj37RdProgram.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param val �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj37RdProgram.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj37RdProgram.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param val �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj37RdProgram.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj37RdProgram.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param val �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj37RdProgram.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj37RdProgram.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj37RdProgram.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj37RdProgram.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj37RdProgram.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj37RdProgram.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj37RdProgram.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj37RdProgram.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj37RdProgram.UPDID, val);
    }

}
