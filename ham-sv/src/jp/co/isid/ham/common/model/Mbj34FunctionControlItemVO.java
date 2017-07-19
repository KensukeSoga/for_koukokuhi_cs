package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj34FunctionControlItem;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �@�\���䍀�ڃ}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj34FunctionControlItemVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj34FunctionControlItemVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Mbj34FunctionControlItemVO();
    }

    /**
     * �@�\�R�[�h���擾����
     *
     * @return �@�\�R�[�h
     */
    public String getFUNCCD() {
        return (String) get(Mbj34FunctionControlItem.FUNCCD);
    }

    /**
     * �@�\�R�[�h��ݒ肷��
     *
     * @param val �@�\�R�[�h
     */
    public void setFUNCCD(String val) {
        set(Mbj34FunctionControlItem.FUNCCD, val);
    }

    /**
     * �@�\��ʂ��擾����
     *
     * @return ���
     */
    public String getFUNCTYPE() {
        return (String) get(Mbj34FunctionControlItem.FUNCTYPE);
    }

    /**
     * �@�\��ʂ�ݒ肷��
     *
     * @param val ���
     */
    public void setFUNCTYPE(String val) {
        set(Mbj34FunctionControlItem.FUNCTYPE, val);
    }

    /**
     * �@�\�����擾����
     *
     * @return �@�\��
     */
    public String getFUNCNM() {
        return (String) get(Mbj34FunctionControlItem.FUNCNM);
    }

    /**
     * �@�\����ݒ肷��
     *
     * @param val �@�\��
     */
    public void setFUNCNM(String val) {
        set(Mbj34FunctionControlItem.FUNCNM, val);
    }

    /**
     * ��ʂ��擾����
     *
     * @return ���
     */
    public String getITEMTYPE() {
        return (String) get(Mbj34FunctionControlItem.ITEMTYPE);
    }

    /**
     * ��ʂ�ݒ肷��
     *
     * @param val ���
     */
    public void setITEMTYPE(String val) {
        set(Mbj34FunctionControlItem.ITEMTYPE, val);
    }

    /**
     * �f�t�H���g������擾����
     *
     * @return �f�t�H���g����
     */
    public String getDEFAULTCONTROL() {
        return (String) get(Mbj34FunctionControlItem.DEFAULTCONTROL);
    }

    /**
     * �f�t�H���g�����ݒ肷��
     *
     * @param val �f�t�H���g����
     */
    public void setDEFAULTCONTROL(String val) {
        set(Mbj34FunctionControlItem.DEFAULTCONTROL, val);
    }

    /**
     * �t�H�[���t�@�C��ID���擾����
     *
     * @return �t�H�[���t�@�C��ID
     */
    public String getFORMID() {
        return (String) get(Mbj34FunctionControlItem.FORMID);
    }

    /**
     * �t�H�[���t�@�C��ID��ݒ肷��
     *
     * @param val �t�H�[���t�@�C��ID
     */
    public void setFORMID(String val) {
        set(Mbj34FunctionControlItem.FORMID, val);
    }

    /**
     * �I�u�W�F�N�g�����擾����
     *
     * @return �I�u�W�F�N�g��
     */
    public String getOBJNAME() {
        return (String) get(Mbj34FunctionControlItem.OBJNAME);
    }

    /**
     * �I�u�W�F�N�g����ݒ肷��
     *
     * @param val �I�u�W�F�N�g��
     */
    public void setOBJNAME(String val) {
        set(Mbj34FunctionControlItem.OBJNAME, val);
    }

    /**
     * �\�[�gNo���擾����
     *
     * @return �\�[�gNo
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj34FunctionControlItem.SORTNO);
    }

    /**
     * �\�[�gNo��ݒ肷��
     *
     * @param val �\�[�gNo
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj34FunctionControlItem.SORTNO, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj34FunctionControlItem.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Mbj34FunctionControlItem.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Mbj34FunctionControlItem.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Mbj34FunctionControlItem.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Mbj34FunctionControlItem.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Mbj34FunctionControlItem.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Mbj34FunctionControlItem.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Mbj34FunctionControlItem.UPDID, val);
    }

}
