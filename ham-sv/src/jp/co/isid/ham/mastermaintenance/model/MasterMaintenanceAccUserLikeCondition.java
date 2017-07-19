package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �l���View�܂ތ���Condition
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/07 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class MasterMaintenanceAccUserLikeCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �S����ID */
    private String _HAMID = null;

    /** �S���Җ� */
    private String _CN = null;

    /** �����g�D�� */
    private String _SOSHIKI = null;

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHAMID()
    {
        return _HAMID;
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param val �S����ID
     */
    public void setHAMID(String val)
    {
        _HAMID = val;
    }

    /**
     * �S���Җ����擾����
     *
     * @return �S���Җ�
     */
    public String getCN()
    {
        return _CN;
    }

    /**
     * �S���Җ���ݒ肷��
     *
     * @param val �S���Җ�
     */
    public void setCN(String val)
    {
        _CN = val;
    }

    /**
     * �����g�D�����擾����
     *
     * @return �����g�D��
     */
    public String getSOSHIKI()
    {
        return _SOSHIKI;
    }

    /**
     * �����g�D����ݒ肷��
     *
     * @param val �����g�D��
     */
    public void setSOSHIKI(String val)
    {
        _SOSHIKI = val;
    }

}
