package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj02User;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �S���҃}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj02UserVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj02UserVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Mbj02UserVO();
    }

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHAMID() {
        return (String) get(Mbj02User.HAMID);
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param val �S����ID
     */
    public void setHAMID(String val) {
        set(Mbj02User.HAMID, val);
    }

    /**
     * �S���Ґ����擾����
     *
     * @return �S���Ґ�
     */
    public String getUSERNAME1() {
        return (String) get(Mbj02User.USERNAME1);
    }

    /**
     * �S���Ґ���ݒ肷��
     *
     * @param val �S���Ґ�
     */
    public void setUSERNAME1(String val) {
        set(Mbj02User.USERNAME1, val);
    }

    /**
     * �S���Җ����擾����
     *
     * @return �S���Җ�
     */
    public String getUSERNAME2() {
        return (String) get(Mbj02User.USERNAME2);
    }

    /**
     * �S���Җ���ݒ肷��
     *
     * @param val �S���Җ�
     */
    public void setUSERNAME2(String val) {
        set(Mbj02User.USERNAME2, val);
    }

    /**
     * ���[�U��ʂ��擾����
     *
     * @return ���[�U���
     */
    public String getUSERTYPE() {
        return (String) get(Mbj02User.USERTYPE);
    }

    /**
     * ���[�U��ʂ�ݒ肷��
     *
     * @param val ���[�U���
     */
    public void setUSERTYPE(String val) {
        set(Mbj02User.USERTYPE, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj02User.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Mbj02User.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Mbj02User.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Mbj02User.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Mbj02User.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Mbj02User.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Mbj02User.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Mbj02User.UPDID, val);
    }

}