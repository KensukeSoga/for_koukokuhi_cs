package jp.co.isid.ham.common.model;

import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Mbj39FunctionControlBase;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �@�\����x�[�X�}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj39FunctionControlBaseVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj39FunctionControlBaseVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Mbj39FunctionControlBaseVO();
    }

    /**
     * �ǃR�[�h���擾����
     *
     * @return �ǃR�[�h
     */
    public String getKKSIKOGNZUNTCD() {
        return (String) get(Mbj39FunctionControlBase.KKSIKOGNZUNTCD);
    }

    /**
     * �ǃR�[�h��ݒ肷��
     *
     * @param val �ǃR�[�h
     */
    public void setKKSIKOGNZUNTCD(String val) {
        set(Mbj39FunctionControlBase.KKSIKOGNZUNTCD, val);
    }

    /**
     * ���[�U��ʂ��擾����
     *
     * @return ���[�U���
     */
    public String getUSERTYPE() {
        return (String) get(Mbj39FunctionControlBase.USERTYPE);
    }

    /**
     * ���[�U��ʂ�ݒ肷��
     *
     * @param val ���[�U���
     */
    public void setUSERTYPE(String val) {
        set(Mbj39FunctionControlBase.USERTYPE, val);
    }

    /**
     * �@�\�R�[�h���擾����
     *
     * @return �@�\�R�[�h
     */
    public String getFUNCCD() {
        return (String) get(Mbj39FunctionControlBase.FUNCCD);
    }

    /**
     * �@�\�R�[�h��ݒ肷��
     *
     * @param val �@�\�R�[�h
     */
    public void setFUNCCD(String val) {
        set(Mbj39FunctionControlBase.FUNCCD, val);
    }

    /**
     * �@�\��ʂ��擾����
     *
     * @return �@�\���
     */
    public String getFUNCTYPE() {
        return (String) get(Mbj39FunctionControlBase.FUNCTYPE);
    }

    /**
     * �@�\��ʂ�ݒ肷��
     *
     * @param val �@�\���
     */
    public void setFUNCTYPE(String val) {
        set(Mbj39FunctionControlBase.FUNCTYPE, val);
    }

    /**
     * ������擾����
     *
     * @return ����
     */
    public String getCONTROL() {
        return (String) get(Mbj39FunctionControlBase.CONTROL);
    }

    /**
     * �����ݒ肷��
     *
     * @param val ����
     */
    public void setCONTROL(String val) {
        set(Mbj39FunctionControlBase.CONTROL, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj39FunctionControlBase.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Mbj39FunctionControlBase.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Mbj39FunctionControlBase.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Mbj39FunctionControlBase.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Mbj39FunctionControlBase.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Mbj39FunctionControlBase.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Mbj39FunctionControlBase.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Mbj39FunctionControlBase.UPDID, val);
    }

}
