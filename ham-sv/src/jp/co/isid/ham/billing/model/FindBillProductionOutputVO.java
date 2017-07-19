/**
 *
 */
package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;
import jp.co.isid.ham.integ.tbl.Tbj22SeisakuhiSs;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���쐿���\VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/18 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindBillProductionOutputVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindBillProductionOutputVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    @Override
    public Object newInstance() {
        return new FindBillProductionOutputVO();
    }

    /**
     * �N�����擾����
     *
     * @return �N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRDATE() {
        return (Date) get(Tbj22SeisakuhiSs.CRDATE);
    }

    /**
     * �N����ݒ肷��
     *
     * @param val �N��
     */
    public void setCRDATE(Date val) {
        set(Tbj22SeisakuhiSs.CRDATE, val);
    }

    /**
     * �Ԏ햼���擾����
     *
     * @return �Ԏ햼
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * �Ԏ햼��ݒ肷��
     *
     * @param val �Ԏ햼
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * ��ڂ��擾����
     *
     * @return ���
     */
    public String getEXPENSE() {
        return (String) get(Tbj22SeisakuhiSs.EXPENSE);
    }

    /**
     * ��ڂ�ݒ肷��
     *
     * @param val ���
     */
    public void setEXPENSE(String val) {
        set(Tbj22SeisakuhiSs.EXPENSE, val);
    }

    /**
     * �ڍׂ��擾����
     *
     * @return �ڍ�
     */
    public String getDETAIL() {
        return (String) get(Tbj22SeisakuhiSs.DETAIL);
    }

    /**
     * �ڍׂ�ݒ肷��
     *
     * @param val �ڍ�
     */
    public void setDETAIL(String val) {
        set(Tbj22SeisakuhiSs.DETAIL, val);
    }

    /**
     * ���ԊJ�n���擾����
     *
     * @return ���ԊJ�n
     */
    @XmlElement(required = true, nillable = true)
    public Date getKIKANS() {
        return (Date) get(Tbj22SeisakuhiSs.KIKANS);
    }

    /**
     * ���ԊJ�n��ݒ肷��
     *
     * @param val ���ԊJ�n
     */
    public void setKIKANS(Date val) {
        set(Tbj22SeisakuhiSs.KIKANS, val);
    }

    /**
     * ���ԏI�����擾����
     *
     * @return ���ԏI��
     */
    @XmlElement(required = true, nillable = true)
    public Date getKIKANE() {
        return (Date) get(Tbj22SeisakuhiSs.KIKANE);
    }

    /**
     * ���ԏI����ݒ肷��
     *
     * @param val ���ԏI��
     */
    public void setKIKANE(Date val) {
        set(Tbj22SeisakuhiSs.KIKANE, val);
    }

    /**
     * �_�����(����)���擾����
     *
     * @return �_�����(����)
     */
    public String getCONTRACTTERM() {
        return (String) get(Tbj22SeisakuhiSs.CONTRACTTERM);
    }

    /**
     * �_�����(����)��ݒ肷��
     *
     * @param val �_�����(����)
     */
    public void setCONTRACTTERM(String val) {
        set(Tbj22SeisakuhiSs.CONTRACTTERM, val);
    }

    /**
     * ���ϋ��z���擾����
     *
     * @return ���ϋ��z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTMONEY() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.ESTMONEY);
    }

    /**
     * ���ϋ��z��ݒ肷��
     *
     * @param val ���ϋ��z
     */
    public void setESTMONEY(BigDecimal val) {
        set(Tbj22SeisakuhiSs.ESTMONEY, val);
    }

    /**
     * �敪�����擾����
     *
     * @return �敪��
     */
    public String getDIVNM() {
        return (String) get(Mbj17CrDivision.DIVNM);
    }

    /**
     * �敪����ݒ肷��
     *
     * @param val �敪��
     */
    public void setDIVNM(String val) {
        set(Mbj17CrDivision.DIVNM, val);
    }

    /**
     * �O���[�v�R�[�h���擾����
     *
     * @return �O���[�v�R�[�h
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGROUPCD() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.GROUPCD);
    }

    /**
     * �O���[�v�R�[�h��ݒ肷��
     *
     * @param val �O���[�v�R�[�h
     */
    public void setGROUPCD(BigDecimal val) {
        set(Tbj22SeisakuhiSs.GROUPCD, val);
    }

    /**
     * �O���[�v�����擾����
     *
     * @return �O���[�v��
     */
    public String getGROUPNM() {
        return (String) get(Mbj26BillGroup.GROUPNM);
    }

    /**
     * �O���[�v����ݒ肷��
     *
     * @param val �O���[�v��
     */
    public void setGROUPNM(String val) {
        set(Mbj26BillGroup.GROUPNM, val);
    }

    /**
     * �O���[�v��(���[)���擾����
     *
     * @return �O���[�v��(���[)
     */
    public String getGROUPNMRPT() {
        return (String) get(Mbj26BillGroup.GROUPNMRPT);
    }

    /**
     * �O���[�v��(���[)��ݒ肷��
     *
     * @param val �O���[�v��(���[)
     */
    public void setGROUPNMRPT(String val) {
        set(Mbj26BillGroup.GROUPNMRPT, val);
    }

    /**
     * �x����[�i�����擾����
     *
     * @return �x����[�i��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDELIVERDAY() {
        return (Date) get(Tbj22SeisakuhiSs.DELIVERDAY);
    }

    /**
     * �x����[�i����ݒ肷��
     *
     * @param val �x����[�i��
     */
    public void setDELIVERDAY(Date val) {
        set(Tbj22SeisakuhiSs.DELIVERDAY, val);
    }

    /**
     * �\�[�g�����擾����
     *
     * @return �\�[�g��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.SORTNO);
    }

    /**
     * �\�[�g����ݒ肷��
     *
     * @param val �\�[�g��
     */
    public void setSORTNO(BigDecimal val) {
        set(Tbj06EstimateDetail.SORTNO, val);
    }

    /**
     * �����Ǘ�NO���擾����
     *
     * @return �����Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSEQUENCENO() {
        return (BigDecimal) get(Tbj07EstimateCreate.SEQUENCENO);
    }

    /**
     * �����Ǘ�NO��ݒ肷��
     *
     * @param val �����Ǘ�NO
     */
    public void setSEQUENCENO(BigDecimal val) {
        set(Tbj07EstimateCreate.SEQUENCENO, val);
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
     * ���ϋ��z���擾����
     *
     * @return ���ϋ��z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMITUMORI() {
        return (BigDecimal) get(Tbj06EstimateDetail.MITUMORI);
    }

    /**
     * ���ϋ��z��ݒ肷��
     *
     * @param val ���ϋ��z
     */
    public void setMITUMORI(BigDecimal val) {
        set(Tbj06EstimateDetail.MITUMORI, val);
    }

    //�����\�s��Ή� 2013/11/13 HLC H.Watabe add start
    /**
     * ���׃V�[�N�G���XNO���擾����
     *
     * @return ���׃V�[�N�G���XNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTDETAILSEQNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.ESTDETAILSEQNO);
    }

    /**
     * ���׃V�[�N�G���XNO��ݒ肷��
     *
     * @param val ���׃V�[�N�G���XNO
     */
    public void setESTDETAILSEQNO(BigDecimal val) {
        set(Tbj06EstimateDetail.ESTDETAILSEQNO, val);
    }
    //�����\�s��Ή� 2013/11/13 HLC H.Watabe add end
}
