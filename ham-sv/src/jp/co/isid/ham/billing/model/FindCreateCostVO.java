package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj21Seisakuhi;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �����f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/2 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindCreateCostVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindCreateCostVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new FindCreateCostVO();
    }

    /**
     * �����̍��v���擾���܂�
     * @param val
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSUMSEISAKUHIS() {
        return (BigDecimal) get("SUMSEISAKUHIS");
    }

    /**
     * �����̍��v��ݒ肵�܂�
     */
    public void setSUMSEISAKUHIS(BigDecimal val) {
        set("SUMSEISAKUHIS", val);
    }

    /**
     * ���������擾����
     *
     * @return ������
     */
    @XmlElement(required = true, nillable = true)
    public Date getSEIKYUYM() {
        return (Date) get(Tbj21Seisakuhi.SEIKYUYM);
    }

    /**
     * ��������ݒ肷��
     *
     * @param val ������
     */
    public void setSEIKYUYM(Date val) {
        set(Tbj21Seisakuhi.SEIKYUYM, val);
    }

    /**
     * �Ԏ�R�[�h���擾����
     *
     * @return �Ԏ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj21Seisakuhi.DCARCD);
    }

    /**
     * �Ԏ�R�[�h��ݒ肷��
     *
     * @param val �Ԏ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj21Seisakuhi.DCARCD, val);
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
}
