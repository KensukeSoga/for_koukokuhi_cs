package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HC���ψꗗ(�����)�擾VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/2/12 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHCEstimateListTotalVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindHCEstimateListTotalVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    @Override
    public Object newInstance() {
        return new FindHCEstimateListTotalVO();
    }

    /**
     * �d�ʎԎ�R�[�h���擾���܂�
     *
     * @return �d�ʎԎ�R�[�h
     */
    public String getDCarCd() {
        return (String) get(Tbj11CrCreateData.DCARCD);
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肵�܂�
     *
     * @param val �d�ʎԎ�R�[�h
     */
    public void setDCarCd(String val) {
        set(Tbj11CrCreateData.DCARCD, val);
    }

    /**
     * �敪�R�[�h���擾���܂�
     *
     * @return �敪�R�[�h
     */
    public String getDivCd() {
        return (String) get(Tbj11CrCreateData.DIVCD);
    }

    /**
     * �敪�R�[�h��ݒ肵�܂�
     *
     * @param val �敪�R�[�h
     */
    public void setDivCd(String val) {
        set(Tbj11CrCreateData.DIVCD, val);
    }

    /**
     * �O���[�v�R�[�h���擾���܂�
     *
     * @return �O���[�v�R�[�h
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGroupCd() {
        return (BigDecimal) get(Tbj11CrCreateData.GROUPCD);
    }

    /**
     * �O���[�v�R�[�h��ݒ肵�܂�
     *
     * @param val �O���[�v�R�[�h
     */
    public void setGroupCd(BigDecimal val) {
        set(Tbj11CrCreateData.GROUPCD, val);
    }

    /**
     * �����z���z���擾���܂�
     *
     * @return �����z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGetMoney() {
        return (BigDecimal) get(Tbj11CrCreateData.GETMONEY);
    }

    /**
     * �����z���z��ݒ肵�܂�
     *
     * @param val �����z���z
     */
    public void setGetMonty(BigDecimal val) {
        set(Tbj11CrCreateData.GETMONEY, val);
    }

    /**
     * �������z���擾���܂�
     *
     * @return �������z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPayMoney() {
        return (BigDecimal) get(Tbj11CrCreateData.PAYMONEY);
    }

    /**
     * �������z���擾���܂�
     *
     * @param val �������z
     */
    public void setPayMoney(BigDecimal val) {
        set(Tbj11CrCreateData.PAYMONEY, val);
    }

    /**
     * �Ԏ햼���擾���܂�
     *
     * @return �Ԏ햼
     */
    public String getCarNm() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * �Ԏ햼��ݒ肵�܂�
     *
     * @param val �Ԏ햼
     */
    public void setCarNm(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * �敪�����擾���܂�
     *
     * @return �敪��
     */
    public String getDivNm() {
        return (String) get(Mbj17CrDivision.DIVNM);
    }

    /**
     * �敪����ݒ肵�܂�
     *
     * @param val �敪��
     */
    public void setDivNm(String val) {
        set(Mbj17CrDivision.DIVNM, val);
    }

    /**
     * �O���[�v�����擾���܂�
     *
     * @return �O���[�v��
     */
    public String getGroupNm() {
        return (String) get(Mbj26BillGroup.GROUPNM);
    }

    /**
     * �O���[�v����ݒ肵�܂�
     *
     * @param val �O���[�v��
     */
    public void setGroupNm(String val) {
        set(Mbj26BillGroup.GROUPNM, val);
    }
}
