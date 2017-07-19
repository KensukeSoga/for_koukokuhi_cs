package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj19Jasrac;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * JASRACVO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj19JasracVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj19JasracVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Tbj19JasracVO();
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj19Jasrac.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param val �t�F�C�Y
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj19Jasrac.PHASE, val);
    }

    /**
     * �l�����敪���擾����
     *
     * @return �l�����敪
     */
    public String getQUOTEKBN() {
        return (String) get(Tbj19Jasrac.QUOTEKBN);
    }

    /**
     * �l�����敪��ݒ肷��
     *
     * @param val �l�����敪
     */
    public void setQUOTEKBN(String val) {
        set(Tbj19Jasrac.QUOTEKBN, val);
    }

    /**
     * �N�����擾����
     *
     * @return �N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getSEIKYUYM() {
        return (Date) get(Tbj19Jasrac.SEIKYUYM);
    }

    /**
     * �N����ݒ肷��
     *
     * @param val �N��
     */
    public void setSEIKYUYM(Date val) {
        set(Tbj19Jasrac.SEIKYUYM, val);
    }

    /**
     * �_���ނ��擾����
     *
     * @return �_����
     */
    public String getCTRTKBN() {
        return (String) get(Tbj19Jasrac.CTRTKBN);
    }

    /**
     * �_���ނ�ݒ肷��
     *
     * @param val �_����
     */
    public void setCTRTKBN(String val) {
        set(Tbj19Jasrac.CTRTKBN, val);
    }

    /**
     * �_��R�[�h���擾����
     *
     * @return �_��R�[�h
     */
    public String getCTRTNO() {
        return (String) get(Tbj19Jasrac.CTRTNO);
    }

    /**
     * �_��R�[�h��ݒ肷��
     *
     * @param val �_��R�[�h
     */
    public void setCTRTNO(String val) {
        set(Tbj19Jasrac.CTRTNO, val);
    }

    /**
     * �폜�t���O���擾����
     *
     * @return �폜�t���O
     */
    public String getDELFLG() {
        return (String) get(Tbj19Jasrac.DELFLG);
    }

    /**
     * �폜�t���O��ݒ肷��
     *
     * @param val �폜�t���O
     */
    public void setDELFLG(String val) {
        set(Tbj19Jasrac.DELFLG, val);
    }

    /**
     * �g�p����(From)���擾����
     *
     * @return �g�p����(From)
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj19Jasrac.DATEFROM);
    }

    /**
     * �g�p����(From)��ݒ肷��
     *
     * @param val �g�p����(From)
     */
    public void setDATEFROM(Date val) {
        set(Tbj19Jasrac.DATEFROM, val);
    }

    /**
     * �g�p����(To)���擾����
     *
     * @return �g�p����(To)
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj19Jasrac.DATETO);
    }

    /**
     * �g�p����(To)��ݒ肷��
     *
     * @param val �g�p����(To)
     */
    public void setDATETO(Date val) {
        set(Tbj19Jasrac.DATETO, val);
    }

    /**
     * �c�Ɛ\���ԍ�1���擾����
     *
     * @return �c�Ɛ\���ԍ�1
     */
    public String getEIGYNO1() {
        return (String) get(Tbj19Jasrac.EIGYNO1);
    }

    /**
     * �c�Ɛ\���ԍ�1��ݒ肷��
     *
     * @param val �c�Ɛ\���ԍ�1
     */
    public void setEIGYNO1(String val) {
        set(Tbj19Jasrac.EIGYNO1, val);
    }

    /**
     * �c�Ɛ\���ԍ�2���擾����
     *
     * @return �c�Ɛ\���ԍ�2
     */
    public String getEIGYNO2() {
        return (String) get(Tbj19Jasrac.EIGYNO2);
    }

    /**
     * �c�Ɛ\���ԍ�2��ݒ肷��
     *
     * @param val �c�Ɛ\���ԍ�2
     */
    public void setEIGYNO2(String val) {
        set(Tbj19Jasrac.EIGYNO2, val);
    }

    /**
     * ���l���擾����
     *
     * @return ���l
     */
    public String getBIKO() {
        return (String) get(Tbj19Jasrac.BIKO);
    }

    /**
     * ���l��ݒ肷��
     *
     * @param val ���l
     */
    public void setBIKO(String val) {
        set(Tbj19Jasrac.BIKO, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj19Jasrac.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param val �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj19Jasrac.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj19Jasrac.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param val �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj19Jasrac.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj19Jasrac.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param val �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj19Jasrac.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj19Jasrac.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param val �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj19Jasrac.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj19Jasrac.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj19Jasrac.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj19Jasrac.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj19Jasrac.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj19Jasrac.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj19Jasrac.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj19Jasrac.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj19Jasrac.UPDID, val);
    }

}
