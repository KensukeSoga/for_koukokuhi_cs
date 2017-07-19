package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �}�̃R�X�g�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/2 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindMediaCostVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindMediaCostVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new FindMediaCostVO();
    }

    /**
     * �O���X�����̍��v���擾���܂�
     * @param val
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSUMGROSS() {
        return (BigDecimal) get("SUMGROSS");
    }

    /**
     * �O���X�����̍��v��ݒ肵�܂�
     */
    public void setSUMGROSS(BigDecimal val) {
        set("SUMGROSS", val);
    }

    /**
     * �V�����iHM�R�X�g�j�̍��v���擾���܂�
     * @param val
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSUMHMCOST() {
        return (BigDecimal) get("SUMHMCOST");
    }

    /**
     * �V�����iHM�R�X�g�j�̍��v��ݒ肵�܂�
     */
    public void setSUMHMCOST(BigDecimal val) {
        set("SUMHMCOST", val);
    }

    /**
     * �����N�����擾����
     *
     * @return �����N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getSEIKYUYM() {
        return (Date) get(Tbj02EigyoDaicho.SEIKYUYM);
    }

    /**
     * �����N����ݒ肷��
     *
     * @param val �����N��
     */
    public void setSEIKYUYM(Date val) {
        set(Tbj02EigyoDaicho.SEIKYUYM, val);
    }

    /**
     * �}�̃R�[�h���擾����
     *
     * @return �}�̃R�[�h
     */
    public String getMEDIACD() {
        return (String) get(Tbj02EigyoDaicho.MEDIACD);
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     *
     * @param val �}�̃R�[�h
     */
    public void setMEDIACD(String val) {
        set(Tbj02EigyoDaicho.MEDIACD, val);
    }

    /**
     * �Ԏ�R�[�h���擾����
     *
     * @return �Ԏ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj02EigyoDaicho.DCARCD);
    }

    /**
     * �Ԏ�R�[�h��ݒ肷��
     *
     * @param val �Ԏ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj02EigyoDaicho.DCARCD, val);
    }

    /**
     * �}�̖����擾����
     *
     * @return �}�̖�
     */
    public String getMEDIANM() {
        return (String) get(Mbj03Media.MEDIANM);
    }

    /**
     * �}�̖���ݒ肷��
     *
     * @param val �}�̖�
     */
    public void setMEDIANM(String val) {
        set(Mbj03Media.MEDIANM, val);
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
