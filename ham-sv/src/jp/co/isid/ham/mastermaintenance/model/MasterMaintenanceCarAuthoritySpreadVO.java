package jp.co.isid.ham.mastermaintenance.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;

/**
 * <P>
 * �Ԏ팠���X�v���b�h�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/10 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class MasterMaintenanceCarAuthoritySpreadVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public MasterMaintenanceCarAuthoritySpreadVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new MasterMaintenanceCarAuthoritySpreadVO();
    }

    /**
     * ��ʂ��擾����
     *
     * @return ���
     */
    public String getSECTYPE()
    {
        return (String) get(Mbj11CarSec.SECTYPE);
    }

    /**
     * ��ʂ�ݒ肷��
     *
     * @param val ���
     */
    public void setSECTYPE(String val)
    {
        set(Mbj11CarSec.SECTYPE, val);
    }

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHAMID()
    {
        return (String) get(Mbj11CarSec.HAMID);
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param val �S����ID
     */
    public void setHAMID(String val)
    {
        set(Mbj11CarSec.HAMID, val);
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     *
     * @return �d�ʎԎ�R�[�h
     */
    public String getDCARCD()
    {
        return (String) get(Mbj11CarSec.DCARCD);
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     *
     * @param val �d�ʎԎ�R�[�h
     */
    public void setDCARCD(String val)
    {
        set(Mbj11CarSec.DCARCD, val);
    }

    /**
     * �Ԏ햼���擾����
     *
     * @return �Ԏ햼
     */
    public String getCARNM()
    {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * �Ԏ햼��ݒ肷��
     *
     * @param val �Ԏ햼
     */
    public void setCARNM(String val)
    {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * �������擾����
     *
     * @return ����
     */
    public String getAUTHORITY()
    {
        return (String) get(Mbj11CarSec.AUTHORITY);
    }

    /**
     * ������ݒ肷��
     *
     * @param val ����
     */
    public void setAUTHORITY(String val)
    {
        set(Mbj11CarSec.AUTHORITY, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(nillable=true)
    public Date getUPDDATE()
    {
        return (Date) get(Mbj11CarSec.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val)
    {
        set(Mbj11CarSec.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM()
    {
        return (String) get(Mbj11CarSec.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val)
    {
        set(Mbj11CarSec.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL()
    {
        return (String) get(Mbj11CarSec.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val)
    {
        set(Mbj11CarSec.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID()
    {
        return (String) get(Mbj11CarSec.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val)
    {
        set(Mbj11CarSec.UPDID, val);
    }

}
