package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj34CutManagement;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �팸�z�Ǘ�VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj34CutManagementVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj34CutManagementVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Tbj34CutManagementVO();
    }

    /**
     * ��ʃR�[�h���擾����
     *
     * @return ��ʃR�[�h
     */
    public String getCLASSCD() {
        return (String) get(Tbj34CutManagement.CLASSCD);
    }

    /**
     * ��ʃR�[�h��ݒ肷��
     *
     * @param val ��ʃR�[�h
     */
    public void setCLASSCD(String val) {
        set(Tbj34CutManagement.CLASSCD, val);
    }

    /**
     * �J�n�N�������擾����
     *
     * @return �J�n�N����
     */
    public String getDATEFROM() {
        return (String) get(Tbj34CutManagement.DATEFROM);
    }

    /**
     * �J�n�N������ݒ肷��
     *
     * @param val �J�n�N����
     */
    public void setDATEFROM(String val) {
        set(Tbj34CutManagement.DATEFROM, val);
    }

    /**
     * �I���N�������擾����
     *
     * @return �I���N����
     */
    public String getDATETO() {
        return (String) get(Tbj34CutManagement.DATETO);
    }

    /**
     * �I���N������ݒ肷��
     *
     * @param val �I���N����
     */
    public void setDATETO(String val) {
        set(Tbj34CutManagement.DATETO, val);
    }

    /**
     * �팸���ъz���擾����
     *
     * @return �팸���ъz
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCUTMONEY() {
        return (BigDecimal) get(Tbj34CutManagement.CUTMONEY);
    }

    /**
     * �팸���ъz��ݒ肷��
     *
     * @param val �팸���ъz
     */
    public void setCUTMONEY(BigDecimal val) {
        set(Tbj34CutManagement.CUTMONEY, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj34CutManagement.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param val �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj34CutManagement.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj34CutManagement.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param val �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj34CutManagement.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj34CutManagement.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param val �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj34CutManagement.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj34CutManagement.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param val �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj34CutManagement.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj34CutManagement.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj34CutManagement.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj34CutManagement.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj34CutManagement.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj34CutManagement.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj34CutManagement.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj34CutManagement.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj34CutManagement.UPDID, val);
    }

}
