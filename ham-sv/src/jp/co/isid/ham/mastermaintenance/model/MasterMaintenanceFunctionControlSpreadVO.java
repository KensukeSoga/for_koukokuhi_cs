package jp.co.isid.ham.mastermaintenance.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

import jp.co.isid.ham.integ.tbl.Mbj33FunctionControl;
import jp.co.isid.ham.integ.tbl.Mbj34FunctionControlItem;

/**
 * <P>
 * �@�\����X�v���b�h�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/11 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class MasterMaintenanceFunctionControlSpreadVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public MasterMaintenanceFunctionControlSpreadVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new MasterMaintenanceFunctionControlSpreadVO();
    }

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHAMID()
    {
        return (String) get(Mbj33FunctionControl.HAMID);
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param val �S����ID
     */
    public void setHAMID(String val)
    {
        set(Mbj33FunctionControl.HAMID, val);
    }

    /**
     * �@�\�R�[�h���擾����
     *
     * @return �@�\�R�[�h
     */
    public String getFUNCCD()
    {
        return (String) get(Mbj33FunctionControl.FUNCCD);
    }

    /**
     * �@�\�R�[�h��ݒ肷��
     *
     * @param val �@�\�R�[�h
     */
    public void setFUNCCD(String val)
    {
        set(Mbj33FunctionControl.FUNCCD, val);
    }

    /**
     * �@�\�����擾����
     *
     * @return �@�\��
     */
    public String getFUNCNM()
    {
        return (String) get(Mbj34FunctionControlItem.FUNCNM);
    }

    /**
     * �@�\����ݒ肷��
     *
     * @param val �@�\��
     */
    public void setFUNCNM(String val)
    {
        set(Mbj34FunctionControlItem.FUNCNM, val);
    }

    /**
     * �@�\��ʂ��擾����
     *
     * @return ���
     */
    public String getFUNCTYPE()
    {
        return (String) get(Mbj34FunctionControlItem.FUNCTYPE);
    }

    /**
     * �@�\��ʂ�ݒ肷��
     *
     * @param val ���
     */
    public void setFUNCTYPE(String val)
    {
        set(Mbj34FunctionControlItem.FUNCTYPE, val);
    }

    /**
     * ������擾����
     *
     * @return ����
     */
    public String getCONTROL()
    {
        return (String) get(Mbj33FunctionControl.CONTROL);
    }

    /**
     * �����ݒ肷��
     *
     * @param val ����
     */
    public void setCONTROL(String val)
    {
        set(Mbj33FunctionControl.CONTROL, val);
    }

    /**
     * �f�t�H���g������擾����
     *
     * @return �f�t�H���g����
     */
    public String getDEFAULTCONTROL()
    {
        return (String) get(Mbj34FunctionControlItem.DEFAULTCONTROL);
    }

    /**
     * �f�t�H���g�����ݒ肷��
     *
     * @param val �f�t�H���g����
     */
    public void setDEFAULTCONTROL(String val)
    {
        set(Mbj34FunctionControlItem.DEFAULTCONTROL, val);
    }

    /**
     * ��ʂ��擾����
     *
     * @return ���
     */
    public String getITEMTYPE()
    {
        return (String) get(Mbj34FunctionControlItem.ITEMTYPE);
    }

    /**
     * ��ʂ�ݒ肷��
     *
     * @param val ���
     */
    public void setITEMTYPE(String val)
    {
        set(Mbj34FunctionControlItem.ITEMTYPE, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(nillable=true)
    public Date getUPDDATE()
    {
        return (Date) get(Mbj33FunctionControl.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val)
    {
        set(Mbj33FunctionControl.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM()
    {
        return (String) get(Mbj33FunctionControl.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val)
    {
        set(Mbj33FunctionControl.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL()
    {
        return (String) get(Mbj33FunctionControl.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val)
    {
        set(Mbj33FunctionControl.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID()
    {
        return (String) get(Mbj33FunctionControl.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val)
    {
        set(Mbj33FunctionControl.UPDID, val);
    }

}
