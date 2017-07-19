package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ������f�[�^���i�[����VO�N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/03/26 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class SeikyuDataVO extends AbstractModel {

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public SeikyuDataVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new SeikyuDataVO();
    }

    /**
     * ������ƃR�[�h���擾����
     *
     * @return ������ƃR�[�h
     */
    public String getTHSKGYCD() {
        return (String) get("THSKGYCD");
    }

    /**
     * ������ƃR�[�h��ݒ肷��
     *
     * @param val ������ƃR�[�h
     */
    public void setTHSKGYCD(String val) {
        set("THSKGYCD", val);
    }

    /**
     * �r�d�p�m�n���擾����
     *
     * @return �r�d�p�m�n
     */
    public String getSEQNO() {
        return (String) get("SEQNO");
    }

    /**
     * �r�d�p�m�n��ݒ肷��
     *
     * @param val �r�d�p�m�n
     */
    public void setSEQNO(String val) {
        set("SEQNO", val);
    }

    /**
     * �S���r�d�p�m�n���擾����
     *
     * @return �S���r�d�p�m�n
     */
    public String getTNTSEQNO() {
        return (String) get("TNTSEQNO");
    }

    /**
     * �S���r�d�p�m�n��ݒ肷��
     *
     * @param val �S���r�d�p�m�n
     */
    public void setTNTSEQNO(String val) {
        set("TNTSEQNO", val);
    }

    /**
     * ������Ɩ��i�\���p�����j���擾����
     *
     * @return ������Ɩ��i�\���p�����j
     */
    public String getTHSKGYDISPKJ() {
        return (String) get("THSKGYDISPKJ");
    }

    /**
     * ������Ɩ��i�\���p�����j��ݒ肷��
     *
     * @param val ������Ɩ��i�\���p�����j
     */
    public void setTHSKGYDISPKJ(String val) {
        set("THSKGYDISPKJ", val);
    }

    /**
     * ������Ɩ��i���������j���擾����
     *
     * @return ������Ɩ��i���������j
     */
    public String getTHSKGYLNGKJ() {
        return (String) get("THSKGYLNGKJ");
    }

    /**
     * ������Ɩ��i���������j��ݒ肷��
     *
     * @param val ������Ɩ��i���������j
     */
    public void setTHSKGYLNGKJ(String val) {
        set("THSKGYLNGKJ", val);
    }

    /**
     * �T�u�����擾����
     *
     * @return �T�u��
     */
    public String getSUBMEI() {
        return (String) get("SUBMEI");
    }

    /**
     * �T�u����ݒ肷��
     *
     * @param val �T�u��
     */
    public void setSUBMEI(String val) {
        set("SUBMEI", val);
    }

    /**
     * �g�D�R�[�h���擾����
     *
     * @return �g�D�R�[�h
     */
    public String getSIKCD() {
        return (String) get("SIKCD");
    }

    /**
     * �g�D�R�[�h��ݒ肷��
     *
     * @param val �g�D�R�[�h
     */
    public void setSIKCD(String val) {
        set("SIKCD", val);
    }

    /**
     * [�g�D]�\�����i�����j���擾����
     *
     * @return [�g�D]�\�����i�����j
     */
    public String getHYOJIKJ() {
        return (String) get("HYOJIKJ");
    }

    /**
     * [�g�D]�\�����i�����j��ݒ肷��
     *
     * @param val [�g�D]�\�����i�����j
     */
    public void setHYOJIKJ(String val) {
        set("HYOJIKJ", val);
    }

    /**
     * ��ʔ��f�t���O���擾����
     *
     * @return ��ʔ��f�t���O
     */
    public String getCLASSDIV() {
        return (String) get("CLASSDIV");
    }

    /**
     * ��ʔ��f�t���O��ݒ肷��
     *
     * @param val ��ʔ��f�t���O
     */
    public void setCLASSDIV(String val) {
        set("CLASSDIV", val);
    }

}
