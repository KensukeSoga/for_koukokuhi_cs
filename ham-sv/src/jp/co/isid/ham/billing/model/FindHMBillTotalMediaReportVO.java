package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HM���v�������쐬(�}��)�擾VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMBillTotalMediaReportVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindHMBillTotalMediaReportVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    @Override
    public Object newInstance() {
        return new FindHMBillTotalMediaReportVO();
    }

    /**
     * �t�F�C�Y���擾����
     * @return BigDecimal �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj05EstimateItem.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     * @param val BigDecimal �t�F�C�Y
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj05EstimateItem.PHASE, val);
    }

    /**
     * �N�����擾����
     * @return Date �N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRDATE() {
        return (Date) get(Tbj05EstimateItem.CRDATE);
    }

    /**
     * �N����ݒ肷��
     * @param val �N��
     */
    public void setCRDATE(Date val) {
        set(Tbj05EstimateItem.CRDATE, val);
    }

    /**
     * ������擾����
     * @return String ����
     */
    public String getADDRESS() {
        return (String) get(Tbj05EstimateItem.ADDRESS);
    }

    /**
     * �����ݒ肷��
     * @param val String ����
     */
    public void setADDRESS(String val) {
        set(Tbj05EstimateItem.ADDRESS, val);
    }

    /**
     * �[�i�������擾����
     * @return Date �[�i����
     */
    @XmlElement(required = true, nillable = true)
    public Date getDLVDATE() {
        return (Date) get(Tbj05EstimateItem.DLVDATE);
    }

    /**
     * �[�i������ݒ肷��
     * @param val Date �[�i����
     */
    public void setDLVDATE(Date val) {
        set(Tbj05EstimateItem.DLVDATE, val);
    }

    /**
     * HC���喼���擾����
     * @return String HC���喼
     */
    public String getHCBUMONNM() {
        return (String) get(Mbj06HcBumon.HCBUMONNM);
    }

    /**
     * HC���喼��ݒ肷��
     * @param val String HC���喼
     */
    public void setHCBUMONNM(String val) {
        set(Mbj06HcBumon.HCBUMONNM, val);
    }

    /**
     * �X�֔ԍ����擾����
     * @return String �X�֔ԍ�
     */
    public String getPOSTNO() {
        return (String) get(Mbj06HcBumon.POSTNO);
    }

    /**
     * �X�֔ԍ���ݒ肷��
     * @param val String �X�֔ԍ�
     */
    public void setPOSTNO(String val) {
        set(Mbj06HcBumon.POSTNO, val);
    }

    /**
     * �Z���P���擾����
     * @return String �Z���P
     */
    public String getADDRESS1() {
        return (String) get(Mbj06HcBumon.ADDRESS1);
    }

    /**
     * �Z���P��ݒ肷��
     * @param val String �Z���P
     */
    public void setADDRESS1(String val) {
        set(Mbj06HcBumon.ADDRESS1, val);
    }

    /**
     * �Z���Q���擾����
     * @return String �Z���Q
     */
    public String getADDRESS2() {
        return (String) get(Mbj06HcBumon.ADDRESS2);
    }

    /**
     * �Z���Q��ݒ肷��
     * @param val String �Z���Q
     */
    public void setADDRESS2(String val) {
        set(Mbj06HcBumon.ADDRESS2, val);
    }

    /**
     * �����Ж����擾����
     * @return String �����Ж�
     */
    public String getBUMONCORPNM() {
        return (String) get(Mbj06HcBumon.BUMONCORPNM);
    }

    /**
     * �����Ж���ݒ肷��
     * @param val String �����Ж�
     */
    public void setBUMONCORPNM(String val) {
        set(Mbj06HcBumon.BUMONCORPNM, val);
    }

    /**
     * ���ϋ��z���擾����
     * @return BigDecimal ���ϋ��z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMITUMORI() {
        return (BigDecimal) get(Tbj06EstimateDetail.MITUMORI);
    }

    /**
     * ���ϋ��z��ݒ肷��
     * @param val BigDecimal ���ϋ��z
     */
    public void setMITUMORI(BigDecimal val) {
        set(Tbj06EstimateDetail.MITUMORI, val);
    }

}
