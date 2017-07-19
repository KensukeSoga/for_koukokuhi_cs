package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj16CrExpence;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR�\�Z��ڃ}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj16CrExpenceVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj16CrExpenceVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Mbj16CrExpenceVO();
    }

    /**
     * ��ڃR�[�h���擾����
     *
     * @return ��ڃR�[�h
     */
    public String getEXPCD() {
        return (String) get(Mbj16CrExpence.EXPCD);
    }

    /**
     * ��ڃR�[�h��ݒ肷��
     *
     * @param val ��ڃR�[�h
     */
    public void setEXPCD(String val) {
        set(Mbj16CrExpence.EXPCD, val);
    }

    /**
     * ��ʔ��f�t���O���擾����
     *
     * @return ��ʔ��f�t���O
     */
    public String getCLASSDIV() {
        return (String) get(Mbj16CrExpence.CLASSDIV);
    }

    /**
     * ��ʔ��f�t���O��ݒ肷��
     *
     * @param val ��ʔ��f�t���O
     */
    public void setCLASSDIV(String val) {
        set(Mbj16CrExpence.CLASSDIV, val);
    }

    /**
     * �J�n�N�������擾����
     *
     * @return �J�n�N����
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Mbj16CrExpence.DATEFROM);
    }

    /**
     * �J�n�N������ݒ肷��
     *
     * @param val �J�n�N����
     */
    public void setDATEFROM(Date val) {
        set(Mbj16CrExpence.DATEFROM, val);
    }

    /**
     * �I���N�������擾����
     *
     * @return �I���N����
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Mbj16CrExpence.DATETO);
    }

    /**
     * �I���N������ݒ肷��
     *
     * @param val �I���N����
     */
    public void setDATETO(Date val) {
        set(Mbj16CrExpence.DATETO, val);
    }

    /**
     * ��ږ����擾����
     *
     * @return ��ږ�
     */
    public String getEXPNM() {
        return (String) get(Mbj16CrExpence.EXPNM);
    }

    /**
     * ��ږ���ݒ肷��
     *
     * @param val ��ږ�
     */
    public void setEXPNM(String val) {
        set(Mbj16CrExpence.EXPNM, val);
    }

    /**
     * �\�[�gNo���擾����
     *
     * @return �\�[�gNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj16CrExpence.SORTNO);
    }

    /**
     * �\�[�gNo��ݒ肷��
     *
     * @param val �\�[�gNo
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj16CrExpence.SORTNO, val);
    }

    /**
     * �t���O�P���擾����
     *
     * @return �t���O�P
     */
    public String getFLG1() {
        return (String) get(Mbj16CrExpence.FLG1);
    }

    /**
     * �t���O�P��ݒ肷��
     *
     * @param val �t���O�P
     */
    public void setFLG1(String val) {
        set(Mbj16CrExpence.FLG1, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj16CrExpence.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Mbj16CrExpence.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Mbj16CrExpence.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Mbj16CrExpence.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Mbj16CrExpence.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Mbj16CrExpence.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Mbj16CrExpence.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Mbj16CrExpence.UPDID, val);
    }

}
