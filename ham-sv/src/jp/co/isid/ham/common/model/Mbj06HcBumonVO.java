package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HC����}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj06HcBumonVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj06HcBumonVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Mbj06HcBumonVO();
    }

    /**
     * HC����R�[�h���擾����
     *
     * @return HC����R�[�h
     */
    public String getHCBUMONCD() {
        return (String) get(Mbj06HcBumon.HCBUMONCD);
    }

    /**
     * HC����R�[�h��ݒ肷��
     *
     * @param val HC����R�[�h
     */
    public void setHCBUMONCD(String val) {
        set(Mbj06HcBumon.HCBUMONCD, val);
    }

    /**
     * �g�p����R�[�h���擾����
     *
     * @return �g�p����R�[�h
     */
    public String getUSEBUMONCD() {
        return (String) get(Mbj06HcBumon.USEBUMONCD);
    }

    /**
     * �g�p����R�[�h��ݒ肷��
     *
     * @param val �g�p����R�[�h
     */
    public void setUSEBUMONCD(String val) {
        set(Mbj06HcBumon.USEBUMONCD, val);
    }

    /**
     * HC���喼���擾����
     *
     * @return HC���喼
     */
    public String getHCBUMONNM() {
        return (String) get(Mbj06HcBumon.HCBUMONNM);
    }

    /**
     * HC���喼��ݒ肷��
     *
     * @param val HC���喼
     */
    public void setHCBUMONNM(String val) {
        set(Mbj06HcBumon.HCBUMONNM, val);
    }

    /**
     * �X�֔ԍ����擾����
     *
     * @return �X�֔ԍ�
     */
    public String getPOSTNO() {
        return (String) get(Mbj06HcBumon.POSTNO);
    }

    /**
     * �X�֔ԍ���ݒ肷��
     *
     * @param val �X�֔ԍ�
     */
    public void setPOSTNO(String val) {
        set(Mbj06HcBumon.POSTNO, val);
    }

    /**
     * �Z���P���擾����
     *
     * @return �Z���P
     */
    public String getADDRESS1() {
        return (String) get(Mbj06HcBumon.ADDRESS1);
    }

    /**
     * �Z���P��ݒ肷��
     *
     * @param val �Z���P
     */
    public void setADDRESS1(String val) {
        set(Mbj06HcBumon.ADDRESS1, val);
    }

    /**
     * �Z���Q���擾����
     *
     * @return �Z���Q
     */
    public String getADDRESS2() {
        return (String) get(Mbj06HcBumon.ADDRESS2);
    }

    /**
     * �Z���Q��ݒ肷��
     *
     * @param val �Z���Q
     */
    public void setADDRESS2(String val) {
        set(Mbj06HcBumon.ADDRESS2, val);
    }

    /**
     * �����Ж����擾����
     *
     * @return �����Ж�
     */
    public String getBUMONCORPNM() {
        return (String) get(Mbj06HcBumon.BUMONCORPNM);
    }

    /**
     * �����Ж���ݒ肷��
     *
     * @param val �����Ж�
     */
    public void setBUMONCORPNM(String val) {
        set(Mbj06HcBumon.BUMONCORPNM, val);
    }

    /**
     * �\�[�gNO���擾����
     *
     * @return �\�[�gNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj06HcBumon.SORTNO);
    }

    /**
     * �\�[�gNO��ݒ肷��
     *
     * @param val �\�[�gNO
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj06HcBumon.SORTNO, val);
    }

    /**
     * �}�̔�f�[�^�ݒ�t���O���擾����
     *
     * @return �}�̔�f�[�^�ݒ�t���O
     */
    public String getMEDIAFLG() {
        return (String) get(Mbj06HcBumon.MEDIAFLG);
    }

    /**
     * �}�̔�f�[�^�ݒ�t���O��ݒ肷��
     *
     * @param val �}�̔�f�[�^�ݒ�t���O
     */
    public void setMEDIAFLG(String val) {
        set(Mbj06HcBumon.MEDIAFLG, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj06HcBumon.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Mbj06HcBumon.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Mbj06HcBumon.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Mbj06HcBumon.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Mbj06HcBumon.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Mbj06HcBumon.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Mbj06HcBumon.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Mbj06HcBumon.UPDID, val);
    }

}
