package jp.co.isid.ham.common.model;

import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Mbj33FunctionControl;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �@�\����}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj33FunctionControlVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj33FunctionControlVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Mbj33FunctionControlVO();
    }

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHAMID() {
        return (String) get(Mbj33FunctionControl.HAMID);
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param val �S����ID
     */
    public void setHAMID(String val) {
        set(Mbj33FunctionControl.HAMID, val);
    }

    /**
     * �@�\�R�[�h���擾����
     *
     * @return �@�\�R�[�h
     */
    public String getFUNCCD() {
        return (String) get(Mbj33FunctionControl.FUNCCD);
    }

    /**
     * �@�\�R�[�h��ݒ肷��
     *
     * @param val �@�\�R�[�h
     */
    public void setFUNCCD(String val) {
        set(Mbj33FunctionControl.FUNCCD, val);
    }

    /**
     * �@�\��ʂ��擾����
     *
     * @return ���
     */
    public String getFUNCTYPE() {
        return (String) get(Mbj33FunctionControl.FUNCTYPE);
    }

    /**
     * �@�\��ʂ�ݒ肷��
     *
     * @param val ���
     */
    public void setFUNCTYPE(String val) {
        set(Mbj33FunctionControl.FUNCTYPE, val);
    }

    /**
     * ������擾����
     *
     * @return ����
     */
    public String getCONTROL() {
        return (String) get(Mbj33FunctionControl.CONTROL);
    }

    /**
     * �����ݒ肷��
     *
     * @param val ����
     */
    public void setCONTROL(String val) {
        set(Mbj33FunctionControl.CONTROL, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj33FunctionControl.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Mbj33FunctionControl.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Mbj33FunctionControl.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Mbj33FunctionControl.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Mbj33FunctionControl.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Mbj33FunctionControl.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Mbj33FunctionControl.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Mbj33FunctionControl.UPDID, val);
    }

}
