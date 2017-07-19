package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj09Hiyou;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ��p���No�}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj09HiyouVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj09HiyouVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Mbj09HiyouVO();
    }

    /**
     * �}�̃R�[�h���擾����
     *
     * @return �}�̃R�[�h
     */
    public String getMEDIACD() {
        return (String) get(Mbj09Hiyou.MEDIACD);
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     *
     * @param val �}�̃R�[�h
     */
    public void setMEDIACD(String val) {
        set(Mbj09Hiyou.MEDIACD, val);
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     *
     * @return �d�ʎԎ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Mbj09Hiyou.DCARCD);
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     *
     * @param val �d�ʎԎ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Mbj09Hiyou.DCARCD, val);
    }

    /**
     * ��p�v��No���擾����
     *
     * @return ��p�v��No
     */
    public String getHIYOUNO() {
        return (String) get(Mbj09Hiyou.HIYOUNO);
    }

    /**
     * ��p�v��No��ݒ肷��
     *
     * @param val ��p�v��No
     */
    public void setHIYOUNO(String val) {
        set(Mbj09Hiyou.HIYOUNO, val);
    }

    /**
     * ���No���擾����
     *
     * @return ���No
     */
    public String getKIKAKUNO() {
        return (String) get(Mbj09Hiyou.KIKAKUNO);
    }

    /**
     * ���No��ݒ肷��
     *
     * @param val ���No
     */
    public void setKIKAKUNO(String val) {
        set(Mbj09Hiyou.KIKAKUNO, val);
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Mbj09Hiyou.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param val �t�F�C�Y
     */
    public void setPHASE(BigDecimal val) {
        set(Mbj09Hiyou.PHASE, val);
    }

    /**
     * �����擾����
     *
     * @return ��
     */
    public String getTERM() {
        return (String) get(Mbj09Hiyou.TERM);
    }

    /**
     * ����ݒ肷��
     *
     * @param val ��
     */
    public void setTERM(String val) {
        set(Mbj09Hiyou.TERM, val);
    }

    /**
     * ��p���No�׸ނ��擾����
     *
     * @return ��p���No�׸�
     */
    public String getHIYOUFLG() {
        return (String) get(Mbj09Hiyou.HIYOUFLG);
    }

    /**
     * ��p���No�׸ނ�ݒ肷��
     *
     * @param val ��p���No�׸�
     */
    public void setHIYOUFLG(String val) {
        set(Mbj09Hiyou.HIYOUFLG, val);
    }

    /**
     * HM����R�[�h���擾����
     *
     * @return HM����R�[�h
     */
    public String getHMDIVCD() {
        return (String) get(Mbj09Hiyou.HMDIVCD);
    }

    /**
     * HM����R�[�h��ݒ肷��
     *
     * @param val HM����R�[�h
     */
    public void setHMDIVCD(String val) {
        set(Mbj09Hiyou.HMDIVCD, val);
    }

    /**
     * HM�S���҃R�[�h���擾����
     *
     * @return HM�S���҃R�[�h
     */
    public String getHMUSERCD() {
        return (String) get(Mbj09Hiyou.HMUSERCD);
    }

    /**
     * HM�S���҃R�[�h��ݒ肷��
     *
     * @param val HM�S���҃R�[�h
     */
    public void setHMUSERCD(String val) {
        set(Mbj09Hiyou.HMUSERCD, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj09Hiyou.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Mbj09Hiyou.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Mbj09Hiyou.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Mbj09Hiyou.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Mbj09Hiyou.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Mbj09Hiyou.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Mbj09Hiyou.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Mbj09Hiyou.UPDID, val);
    }

}
