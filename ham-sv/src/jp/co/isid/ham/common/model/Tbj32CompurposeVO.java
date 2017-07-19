package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj32Compurpose;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �ėp�R�����gVO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj32CompurposeVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj32CompurposeVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Tbj32CompurposeVO();
    }

    /**
     * �R�[�h��ʂ��擾����
     *
     * @return �R�[�h���
     */
    public String getCODETYPE() {
        return (String) get(Tbj32Compurpose.CODETYPE);
    }

    /**
     * �R�[�h��ʂ�ݒ肷��
     *
     * @param val �R�[�h���
     */
    public void setCODETYPE(String val) {
        set(Tbj32Compurpose.CODETYPE, val);
    }

    /**
     * ���ID���擾����
     *
     * @return ���ID
     */
    public String getFORMID() {
        return (String) get(Tbj32Compurpose.FORMID);
    }

    /**
     * ���ID��ݒ肷��
     *
     * @param val ���ID
     */
    public void setFORMID(String val) {
        set(Tbj32Compurpose.FORMID, val);
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj32Compurpose.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param val �t�F�C�Y
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj32Compurpose.PHASE, val);
    }

    /**
     * �L�[�R�[�h1���擾����
     *
     * @return �L�[�R�[�h1
     */
    public String getKEYCODE1() {
        return (String) get(Tbj32Compurpose.KEYCODE1);
    }

    /**
     * �L�[�R�[�h1��ݒ肷��
     *
     * @param val �L�[�R�[�h1
     */
    public void setKEYCODE1(String val) {
        set(Tbj32Compurpose.KEYCODE1, val);
    }

    /**
     * �L�[�R�[�h2���擾����
     *
     * @return �L�[�R�[�h2
     */
    public String getKEYCODE2() {
        return (String) get(Tbj32Compurpose.KEYCODE2);
    }

    /**
     * �L�[�R�[�h2��ݒ肷��
     *
     * @param val �L�[�R�[�h2
     */
    public void setKEYCODE2(String val) {
        set(Tbj32Compurpose.KEYCODE2, val);
    }

    /**
     * �L�[�R�[�h3���擾����
     *
     * @return �L�[�R�[�h3
     */
    public String getKEYCODE3() {
        return (String) get(Tbj32Compurpose.KEYCODE3);
    }

    /**
     * �L�[�R�[�h3��ݒ肷��
     *
     * @param val �L�[�R�[�h3
     */
    public void setKEYCODE3(String val) {
        set(Tbj32Compurpose.KEYCODE3, val);
    }

    /**
     * �R�����g�t�B�[���hS1���擾����
     *
     * @return �R�����g�t�B�[���hS1
     */
    public String getCONTENTS1() {
        return (String) get(Tbj32Compurpose.CONTENTS1);
    }

    /**
     * �R�����g�t�B�[���hS1��ݒ肷��
     *
     * @param val �R�����g�t�B�[���hS1
     */
    public void setCONTENTS1(String val) {
        set(Tbj32Compurpose.CONTENTS1, val);
    }

    /**
     * �R�����g�t�B�[���hS2���擾����
     *
     * @return �R�����g�t�B�[���hS2
     */
    public String getCONTENTS2() {
        return (String) get(Tbj32Compurpose.CONTENTS2);
    }

    /**
     * �R�����g�t�B�[���hS2��ݒ肷��
     *
     * @param val �R�����g�t�B�[���hS2
     */
    public void setCONTENTS2(String val) {
        set(Tbj32Compurpose.CONTENTS2, val);
    }

    /**
     * �R�����g�t�B�[���hM1���擾����
     *
     * @return �R�����g�t�B�[���hM1
     */
    public String getCONTENTM1() {
        return (String) get(Tbj32Compurpose.CONTENTM1);
    }

    /**
     * �R�����g�t�B�[���hM1��ݒ肷��
     *
     * @param val �R�����g�t�B�[���hM1
     */
    public void setCONTENTM1(String val) {
        set(Tbj32Compurpose.CONTENTM1, val);
    }

    /**
     * �R�����g�t�B�[���hM2���擾����
     *
     * @return �R�����g�t�B�[���hM2
     */
    public String getCONTENTM2() {
        return (String) get(Tbj32Compurpose.CONTENTM2);
    }

    /**
     * �R�����g�t�B�[���hM2��ݒ肷��
     *
     * @param val �R�����g�t�B�[���hM2
     */
    public void setCONTENTM2(String val) {
        set(Tbj32Compurpose.CONTENTM2, val);
    }

    /**
     * �R�����g�t�B�[���hL1���擾����
     *
     * @return �R�����g�t�B�[���hL1
     */
    public String getCONTENTL1() {
        return (String) get(Tbj32Compurpose.CONTENTL1);
    }

    /**
     * �R�����g�t�B�[���hL1��ݒ肷��
     *
     * @param val �R�����g�t�B�[���hL1
     */
    public void setCONTENTL1(String val) {
        set(Tbj32Compurpose.CONTENTL1, val);
    }

    /**
     * �R�����g�t�B�[���hL2���擾����
     *
     * @return �R�����g�t�B�[���hL2
     */
    public String getCONTENTL2() {
        return (String) get(Tbj32Compurpose.CONTENTL2);
    }

    /**
     * �R�����g�t�B�[���hL2��ݒ肷��
     *
     * @param val �R�����g�t�B�[���hL2
     */
    public void setCONTENTL2(String val) {
        set(Tbj32Compurpose.CONTENTL2, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj32Compurpose.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param val �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj32Compurpose.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj32Compurpose.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param val �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj32Compurpose.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj32Compurpose.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param val �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj32Compurpose.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj32Compurpose.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param val �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj32Compurpose.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj32Compurpose.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj32Compurpose.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj32Compurpose.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj32Compurpose.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj32Compurpose.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj32Compurpose.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj32Compurpose.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj32Compurpose.UPDID, val);
    }

}
