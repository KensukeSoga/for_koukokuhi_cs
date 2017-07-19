package jp.co.isid.ham.common.model;

import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Mbj40AlertMailAddress;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���[���z�M�}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/07/05 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj40AlertMailAddressVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj40AlertMailAddressVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Mbj40AlertMailAddressVO();
    }

    /**
     * �A���[�g���[����ʂ��擾����
     *
     * @return �A���[�g���[�����
     */
    public String getMAILTYPE() {
        return (String) get(Mbj40AlertMailAddress.MAILTYPE);
    }

    /**
     * �A���[�g���[����ʂ�ݒ肷��
     *
     * @param val �A���[�g���[�����
     */
    public void setMAILTYPE(String val) {
        set(Mbj40AlertMailAddress.MAILTYPE, val);
    }

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHAMID() {
        return (String) get(Mbj40AlertMailAddress.HAMID);
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param val �S����ID
     */
    public void setHAMID(String val) {
        set(Mbj40AlertMailAddress.HAMID, val);
    }

    /**
     * �������擾����
     *
     * @return ����
     */
    public String getCN() {
        return (String) get(Mbj40AlertMailAddress.CN);
    }

    /**
     * ������ݒ肷��
     *
     * @param val ����
     */
    public void setCN(String val) {
        set(Mbj40AlertMailAddress.CN, val);
    }

    /**
     * ���[���A�h���X���擾����
     *
     * @return ���[���A�h���X
     */
    public String getMAIL() {
        return (String) get(Mbj40AlertMailAddress.MAIL);
    }

    /**
     * ���[���A�h���X��ݒ肷��
     *
     * @param val ���[���A�h���X
     */
    public void setMAIL(String val) {
        set(Mbj40AlertMailAddress.MAIL, val);
    }

    /**
     * ����t���O���擾����
     *
     * @return ����t���O
     */
    public String getSENDTYPE() {
        return (String) get(Mbj40AlertMailAddress.SENDTYPE);
    }

    /**
     * ����t���O��ݒ肷��
     *
     * @param val ����t���O
     */
    public void setSENDTYPE(String val) {
        set(Mbj40AlertMailAddress.SENDTYPE, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj40AlertMailAddress.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Mbj40AlertMailAddress.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Mbj40AlertMailAddress.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Mbj40AlertMailAddress.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Mbj40AlertMailAddress.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Mbj40AlertMailAddress.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Mbj40AlertMailAddress.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Mbj40AlertMailAddress.UPDID, val);
    }

}
