package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �}�̃}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj03MediaVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj03MediaVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Mbj03MediaVO();
    }

    /**
     * �}�̃R�[�h���擾����
     *
     * @return �}�̃R�[�h
     */
    public String getMEDIACD() {
        return (String) get(Mbj03Media.MEDIACD);
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     *
     * @param val �}�̃R�[�h
     */
    public void setMEDIACD(String val) {
        set(Mbj03Media.MEDIACD, val);
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
     * �}�̖��i�}�̔�쐬�p�j���擾����
     *
     * @return �}�̖��i�}�̔�쐬�p�j
     */
    public String getHCMEDIANM() {
        return (String) get(Mbj03Media.HCMEDIANM);
    }

    /**
     * �}�̖��i�}�̔�쐬�p�j��ݒ肷��
     *
     * @param val �}�̖��i�}�̔�쐬�p�j
     */
    public void setHCMEDIANM(String val) {
        set(Mbj03Media.HCMEDIANM, val);
    }

    /**
     * �d�ʒl�������擾����
     *
     * @return �d�ʒl����
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDNEBIKI() {
        return (BigDecimal) get(Mbj03Media.DNEBIKI);
    }

    /**
     * �d�ʒl������ݒ肷��
     *
     * @param val �d�ʒl����
     */
    public void setDNEBIKI(BigDecimal val) {
        set(Mbj03Media.DNEBIKI, val);
    }

    /**
     * �\�[�gNo���擾����
     *
     * @return �\�[�gNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj03Media.SORTNO);
    }

    /**
     * �\�[�gNo��ݒ肷��
     *
     * @param val �\�[�gNo
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj03Media.SORTNO, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj03Media.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Mbj03Media.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Mbj03Media.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Mbj03Media.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Mbj03Media.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Mbj03Media.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Mbj03Media.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Mbj03Media.UPDID, val);
    }

}
