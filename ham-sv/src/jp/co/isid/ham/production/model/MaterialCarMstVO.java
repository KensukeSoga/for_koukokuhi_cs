package jp.co.isid.ham.production.model;


import java.math.BigDecimal;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj22CategoryContent;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �f�ވꗗ�p�Ԏ�R�[�h�}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MaterialCarMstVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �R���X�g���N�^
     */
    public MaterialCarMstVO() {

    }
    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new MaterialCarMstVO();
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     *
     * @return �d�ʎԎ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Mbj05Car.DCARCD);
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     *
     * @param val �d�ʎԎ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Mbj05Car.DCARCD, val);
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
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Mbj22CategoryContent.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param val �t�F�C�Y
     */
    public void setPHASE(BigDecimal val) {
        set(Mbj22CategoryContent.PHASE, val);
    }

    /**
     * �J�e�S���i���o�[���擾����
     *
     * @return �J�e�S���i���o�[
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCATEGORYNO() {
        return (BigDecimal) get(Mbj22CategoryContent.CATEGORYNO);
    }

    /**
     * �J�e�S���i���o�[��ݒ肷��
     *
     * @param val �J�e�S���i���o�[
     */
    public void setCATEGORYNO(BigDecimal val) {
        set(Mbj22CategoryContent.CATEGORYNO, val);
    }

}
