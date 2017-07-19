package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;

import jp.co.isid.ham.integ.tbl.Mbj08HcProduct;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HC���i�I���擾VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/2/26 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCItemSelectionVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindHCItemSelectionVO() {
    }


    /**
     * �}�̕��ރR�[�h���擾����
     *
     * @return �}�̕��ރR�[�h
     */
    public String getMEDIACLASSCD() {
        return (String) get(Mbj08HcProduct.MEDIACLASSCD);
    }

    /**
     * �}�̕��ރR�[�h��ݒ肷��
     *
     * @param val �}�̕��ރR�[�h
     */
    public void setMEDIACLASSCD(String val) {
        set(Mbj08HcProduct.MEDIACLASSCD, val);
    }

    /**
     * �}�̕��ޖ����擾����
     *
     * @return �}�̕��ޖ�
     */
    public String getMEDIACLASSNM() {
        return (String) get(Mbj08HcProduct.MEDIACLASSNM);
    }

    /**
     * �}�̕��ޖ���ݒ肷��
     *
     * @param val �}�̕��ޖ�
     */
    public void setMEDIACLASSNM(String val) {
        set(Mbj08HcProduct.MEDIACLASSNM, val);
    }

    /**
     * �}�̃R�[�h���擾����
     *
     * @return �}�̃R�[�h
     */
    public String getMEDIACD() {
        return (String) get(Mbj08HcProduct.MEDIACD);
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     *
     * @param val �}�̃R�[�h
     */
    public void setMEDIACD(String val) {
        set(Mbj08HcProduct.MEDIACD, val);
    }

    /**
     * �}�̖����擾����
     *
     * @return �}�̖�
     */
    public String getMEDIANM() {
        return (String) get(Mbj08HcProduct.MEDIANM);
    }

    /**
     * �}�̖���ݒ肷��
     *
     * @param val �}�̖�
     */
    public void setMEDIANM(String val) {
        set(Mbj08HcProduct.MEDIANM, val);
    }

    /**
     * �Ɩ����ރR�[�h���擾����
     *
     * @return �Ɩ����ރR�[�h
     */
    public String getBUSINESSCLASSCD() {
        return (String) get(Mbj08HcProduct.BUSINESSCLASSCD);
    }

    /**
     * �Ɩ����ރR�[�h��ݒ肷��
     *
     * @param val �Ɩ����ރR�[�h
     */
    public void setBUSINESSCLASSCD(String val) {
        set(Mbj08HcProduct.BUSINESSCLASSCD, val);
    }

    /**
     * �Ɩ����ޖ����擾����
     *
     * @return �Ɩ����ޖ�
     */
    public String getBUSINESSCLASSNM() {
        return (String) get(Mbj08HcProduct.BUSINESSCLASSNM);
    }

    /**
     * �Ɩ����ޖ���ݒ肷��
     *
     * @param val �Ɩ����ޖ�
     */
    public void setBUSINESSCLASSNM(String val) {
        set(Mbj08HcProduct.BUSINESSCLASSNM, val);
    }

    /**
     * �Ɩ��R�[�h���擾����
     *
     * @return �Ɩ��R�[�h
     */
    public String getBUSINESSCD() {
        return (String) get(Mbj08HcProduct.BUSINESSCD);
    }

    /**
     * �Ɩ��R�[�h��ݒ肷��
     *
     * @param val �Ɩ��R�[�h
     */
    public void setBUSINESSCD(String val) {
        set(Mbj08HcProduct.BUSINESSCD, val);
    }

    /**
     * �Ɩ������擾����
     *
     * @return �Ɩ���
     */
    public String getBUSINESSNM() {
        return (String) get(Mbj08HcProduct.BUSINESSNM);
    }

    /**
     * �Ɩ�����ݒ肷��
     *
     * @param val �Ɩ���
     */
    public void setBUSINESSNM(String val) {
        set(Mbj08HcProduct.BUSINESSNM, val);
    }

    /**
     * ���i�R�[�h���擾����
     *
     * @return ���i�R�[�h
     */
    public String getPRODUCTCD() {
        return (String) get(Mbj08HcProduct.PRODUCTCD);
    }

    /**
     * ���i�R�[�h��ݒ肷��
     *
     * @param val ���i�R�[�h
     */
    public void setPRODUCTCD(String val) {
        set(Mbj08HcProduct.PRODUCTCD, val);
    }

    /**
     * ���i�����擾����
     *
     * @return ���i��
     */
    public String getMstrPRODUCTNM() {
        return (String) get(Mbj08HcProduct.PRODUCTNM);
    }

    /**
     * ���i����ݒ肷��
     *
     * @param val ���i��
     */
    public void setMstrPRODUCTNM(String val) {
        set(Mbj08HcProduct.PRODUCTNM, val);
    }

    /**
     * ���i�����擾����
     *
     * @return ���i��
     */
    public String getPRODUCTNM() {
        return (String) get(Tbj06EstimateDetail.PRODUCTNM);
    }

    /**
     * ���i����ݒ肷��
     *
     * @param val ���i��
     */
    public void setPRODUCTNM(String val) {
        set(Tbj06EstimateDetail.PRODUCTNM, val);
    }

    /**
     * ���i��(�T�u�j���擾����
     *
     * @return ���i��(�T�u�j
     */
    public String getPRODUCTNMSUB() {
        return (String) get(Tbj06EstimateDetail.PRODUCTNMSUB);
    }

    /**
     * ���i��(�T�u�j��ݒ肷��
     *
     * @param val ���i��(�T�u�j
     */
    public void setPRODUCTNMSUB(String val) {
        set(Tbj06EstimateDetail.PRODUCTNMSUB, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj06EstimateDetail.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj06EstimateDetail.UPDID, val);
    }

    /**
     * �A�Ԃ��擾����
     *
     * @return �A��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getNUM() {
        return (BigDecimal) get("NUM");
    }

    /**
     * �A�Ԃ�ݒ肷��
     *
     * @param val �A��
     */
    public void setNum(BigDecimal val) {
        set("NUM", val);
    }

    /**
     * �ڍא����擾����
     *
     * @return �ڍא�
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDETAILCNT() {
        return (BigDecimal) get("DETAILCNT");
    }

    /**
     * �ڍא���ݒ肷��
     *
     * @param val �ڍא�
     */
    public void setDETAILCNT(BigDecimal val) {
        set("DETAILCNT",val);
    }
}
