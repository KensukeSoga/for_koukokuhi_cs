package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj23CarTanto;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �Ԏ�S���҃}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj23CarTantoVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj23CarTantoVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Mbj23CarTantoVO();
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     *
     * @return �d�ʎԎ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Mbj23CarTanto.DCARCD);
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     *
     * @param val �d�ʎԎ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Mbj23CarTanto.DCARCD, val);
    }

    /**
     * �}�̒S���҂��擾����
     *
     * @return �}�̒S����
     */
    public String getMEDIATANTO() {
        return (String) get(Mbj23CarTanto.MEDIATANTO);
    }

    /**
     * �}�̒S���҂�ݒ肷��
     *
     * @param val �}�̒S����
     */
    public void setMEDIATANTO(String val) {
        set(Mbj23CarTanto.MEDIATANTO, val);
    }

    /**
     * ����S���҂��擾����
     *
     * @return ����S����
     */
    public String getCRTANTO() {
        return (String) get(Mbj23CarTanto.CRTANTO);
    }

    /**
     * ����S���҂�ݒ肷��
     *
     * @param val ����S����
     */
    public void setCRTANTO(String val) {
        set(Mbj23CarTanto.CRTANTO, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj23CarTanto.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Mbj23CarTanto.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Mbj23CarTanto.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Mbj23CarTanto.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Mbj23CarTanto.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Mbj23CarTanto.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Mbj23CarTanto.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Mbj23CarTanto.UPDID, val);
    }

}
