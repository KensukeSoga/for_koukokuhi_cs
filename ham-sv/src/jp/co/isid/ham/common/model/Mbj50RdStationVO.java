package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj50RdStation;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���W�I�ǃ}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj50RdStationVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj50RdStationVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Mbj50RdStationVO();
    }

    /**
     * ���W�I�ǃR�[�h���擾����
     *
     * @return ���W�I�ǃR�[�h
     */
    public String getRDCD() {
        return (String) get(Mbj50RdStation.RDCD);
    }

    /**
     * ���W�I�ǃR�[�h��ݒ肷��
     *
     * @param val ���W�I�ǃR�[�h
     */
    public void setRDCD(String val) {
        set(Mbj50RdStation.RDCD, val);
    }

    /**
     * ���W�I�ǖ��̂��擾����
     *
     * @return ���W�I�ǖ���
     */
    public String getRDNM() {
        return (String) get(Mbj50RdStation.RDNM);
    }

    /**
     * ���W�I�ǖ��̂�ݒ肷��
     *
     * @param val ���W�I�ǖ���
     */
    public void setRDNM(String val) {
        set(Mbj50RdStation.RDNM, val);
    }

    /**
     * ���̗��̂��擾����
     *
     * @return ���̗���
     */
    public String getABBREVIATION() {
        return (String) get(Mbj50RdStation.ABBREVIATION);
    }

    /**
     * ���̗��̂�ݒ肷��
     *
     * @param val ���̗���
     */
    public void setABBREVIATION(String val) {
        set(Mbj50RdStation.ABBREVIATION, val);
    }

    /**
     * JASRAC���[�o�͖��̂��擾����
     *
     * @return JASRAC���[�o�͖���
     */
    public String getJASRACREPORTNM() {
        return (String) get(Mbj50RdStation.JASRACREPORTNM);
    }

    /**
     * JASRAC���[�o�͖��̂�ݒ肷��
     *
     * @param val JASRAC���[�o�͖���
     */
    public void setJASRACREPORTNM(String val) {
        set(Mbj50RdStation.JASRACREPORTNM, val);
    }

    /**
     * JFN�n��t���O���擾����
     *
     * @return JFN�n��t���O
     */
    public String getJFNGRPFLG() {
        return (String) get(Mbj50RdStation.JFNGRPFLG);
    }

    /**
     * JFN�n��t���O��ݒ肷��
     *
     * @param val JFN�n��t���O
     */
    public void setJFNGRPFLG(String val) {
        set(Mbj50RdStation.JFNGRPFLG, val);
    }

    /**
     * JRN�n��t���O���擾����
     *
     * @return JRN�n��t���O
     */
    public String getJRNGRPFLG() {
        return (String) get(Mbj50RdStation.JRNGRPFLG);
    }

    /**
     * JRN�n��t���O��ݒ肷��
     *
     * @param val JRN�n��t���O
     */
    public void setJRNGRPFLG(String val) {
        set(Mbj50RdStation.JRNGRPFLG, val);
    }

    /**
     * NRN�n��t���O���擾����
     *
     * @return NRN�n��t���O
     */
    public String getNRNGRPFLG() {
        return (String) get(Mbj50RdStation.NRNGRPFLG);
    }

    /**
     * NRN�n��t���O��ݒ肷��
     *
     * @param val NRN�n��t���O
     */
    public void setNRNGRPFLG(String val) {
        set(Mbj50RdStation.NRNGRPFLG, val);
    }

    /**
     * �\�������擾����
     *
     * @return �\����
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj50RdStation.SORTNO);
    }

    /**
     * �\������ݒ肷��
     *
     * @param val �\����
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj50RdStation.SORTNO, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj50RdStation.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Mbj50RdStation.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Mbj50RdStation.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Mbj50RdStation.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Mbj50RdStation.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Mbj50RdStation.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Mbj50RdStation.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Mbj50RdStation.UPDID, val);
    }

}
