package jp.co.isid.ham.mastermaintenance.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

import jp.co.isid.ham.integ.tbl.Mbj42Security;
import jp.co.isid.ham.integ.tbl.Mbj43SecurityItem;

/**
 * <P>
 * �Z�L�����e�B�X�v���b�h�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/19 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class MasterMaintenanceSecuritySpreadVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public MasterMaintenanceSecuritySpreadVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new MasterMaintenanceSecuritySpreadVO();
    }

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHAMID()
    {
        return (String) get(Mbj42Security.HAMID);
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param val �S����ID
     */
    public void setHAMID(String val)
    {
        set(Mbj42Security.HAMID, val);
    }

    /**
     * �Z�L�����e�B�R�[�h���擾����
     *
     * @return �Z�L�����e�B�R�[�h
     */
    public String getSECURITYCD()
    {
        return (String) get(Mbj42Security.SECURITYCD);
    }

    /**
     * �Z�L�����e�B�R�[�h��ݒ肷��
     *
     * @param val �Z�L�����e�B�R�[�h
     */
    public void setSECURITYCD(String val)
    {
        set(Mbj42Security.SECURITYCD, val);
    }

    /**
     * �Z�L�����e�B��ʂ��擾����
     *
     * @return �Z�L�����e�B���
     */
    public String getSECURITYTYPE()
    {
        return (String) get(Mbj42Security.SECURITYTYPE);
    }

    /**
     * �Z�L�����e�B��ʂ�ݒ肷��
     *
     * @param val �Z�L�����e�B���
     */
    public void setSECURITYTYPE(String val)
    {
        set(Mbj42Security.SECURITYTYPE, val);
    }

    /**
     * �Z�L�����e�B�����擾����
     *
     * @return �Z�L�����e�B��
     */
    public String getSECURITYNM()
    {
        return (String) get(Mbj43SecurityItem.SECURITYNM);
    }

    /**
     * �Z�L�����e�B����ݒ肷��
     *
     * @param val �Z�L�����e�B��
     */
    public void setSECURITYNM(String val)
    {
        set(Mbj43SecurityItem.SECURITYNM, val);
    }

    /**
     * �o�^�E�X�V���擾����
     *
     * @return �o�^�E�X�V
     */
    public String getUPDATE()
    {
        return (String) get(Mbj42Security.UPDATE);
    }

    /**
     * �o�^�E�X�V��ݒ肷��
     *
     * @param val �o�^�E�X�V
     */
    public void setUPDATE(String val)
    {
        set(Mbj42Security.UPDATE, val);
    }

    /**
     * �m�F���擾����
     *
     * @return �m�F
     */
    public String getCHECK()
    {
        return (String) get(Mbj42Security.CHECK);
    }

    /**
     * �m�F��ݒ肷��
     *
     * @param val �m�F
     */
    public void setCHECK(String val)
    {
        set(Mbj42Security.CHECK, val);
    }

    /**
     * �Q�Ƃ��擾����
     *
     * @return �Q��
     */
    public String getREFERENCE()
    {
        return (String) get(Mbj42Security.REFERENCE);
    }

    /**
     * �Q�Ƃ�ݒ肷��
     *
     * @param val �Q��
     */
    public void setREFERENCE(String val)
    {
        set(Mbj42Security.REFERENCE, val);
    }

    /**
     * ��ʂ��擾����
     *
     * @return ���
     */
    public String getITEMTYPE()
    {
        return (String) get(Mbj43SecurityItem.ITEMTYPE);
    }

    /**
     * ��ʂ�ݒ肷��
     *
     * @param val ���
     */
    public void setITEMTYPE(String val)
    {
        set(Mbj43SecurityItem.ITEMTYPE, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(nillable=true)
    public Date getUPDDATE()
    {
        return (Date) get(Mbj42Security.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val)
    {
        set(Mbj42Security.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM()
    {
        return (String) get(Mbj42Security.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val)
    {
        set(Mbj42Security.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL()
    {
        return (String) get(Mbj42Security.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val)
    {
        set(Mbj42Security.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID()
    {
        return (String) get(Mbj42Security.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val)
    {
        set(Mbj42Security.UPDID, val);
    }

}
