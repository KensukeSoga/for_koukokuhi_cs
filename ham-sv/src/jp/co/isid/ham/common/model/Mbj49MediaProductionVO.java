package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj49MediaProduction;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �}�̃}�X�^(����)VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj49MediaProductionVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj49MediaProductionVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Mbj49MediaProductionVO();
    }

    /**
     * �}�̃R�[�h���擾����
     *
     * @return �}�̃R�[�h
     */
    public String getMEDIACD() {
        return (String) get(Mbj49MediaProduction.MEDIACD);
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     *
     * @param val �}�̃R�[�h
     */
    public void setMEDIACD(String val) {
        set(Mbj49MediaProduction.MEDIACD, val);
    }

    /**
     * �}�̖����擾����
     *
     * @return �}�̖�
     */
    public String getMEDIANM() {
        return (String) get(Mbj49MediaProduction.MEDIANM);
    }

    /**
     * �}�̖���ݒ肷��
     *
     * @param val �}�̖�
     */
    public void setMEDIANM(String val) {
        set(Mbj49MediaProduction.MEDIANM, val);
    }

    /**
     * �\�[�gNo���擾����
     *
     * @return �\�[�gNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj49MediaProduction.SORTNO);
    }

    /**
     * �\�[�gNo��ݒ肷��
     *
     * @param val �\�[�gNo
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj49MediaProduction.SORTNO, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj49MediaProduction.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Mbj49MediaProduction.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Mbj49MediaProduction.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Mbj49MediaProduction.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Mbj49MediaProduction.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Mbj49MediaProduction.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Mbj49MediaProduction.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Mbj49MediaProduction.UPDID, val);
    }

}