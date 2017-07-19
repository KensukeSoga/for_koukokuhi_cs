package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.T_SecurityGroup;
import jp.co.isid.ham.integ.tbl.T_TransactionSecurity;
import jp.co.isid.ham.integ.tbl.T_UserInfo;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �Z�L�����e�B�O���[�v���[�U�[(HC/HM)�X�v���b�h�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2016/02/17 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")


public class MasterMaintenanceHCHMSecGrpUserSpreadVO extends AbstractModel
{
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public MasterMaintenanceHCHMSecGrpUserSpreadVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new MasterMaintenanceHCHMSecGrpUserSpreadVO();
    }

    /**
     * ���[�U�[ID���擾����
     *
     * @return ���[�U�[ID
     */
    public String getUSERID()
    {
        return (String) get(T_TransactionSecurity.USERID);
    }

    /**
     * ���[�U�[ID��ݒ肷��
     *
     * @param val ���[�U�[ID
     */
    public void setUSERID(String val)
    {
        set(T_TransactionSecurity.USERID, val);
    }

    /**
     * �g�����U�N�V�����ԍ����擾����
     *
     * @return �g�����U�N�V�����ԍ�
     */
    public String getTRANSACTIONNO()
    {
        return (String) get(T_TransactionSecurity.TRANSACTIONNO);
    }

    /**
     * �g�����U�N�V�����ԍ���ݒ肷��
     *
     * @param val �g�����U�N�V�����ԍ�
     */
    public void setTRANSACTIONNO(String val)
    {
        set(T_TransactionSecurity.TRANSACTIONNO, val);
    }

    /**
     * ���[�U�[��(����)���擾����
     *
     * @return ���[�U�[��(����)
     */
    public String getUSERNAME()
    {
        return (String) get(T_UserInfo.USERNAME);
    }

    /**
     * ���[�U�[��(����)��ݒ肷��
     *
     * @param val ���[�U�[��(����)
     */
    public void setUSERNAME(String val)
    {
        set(T_UserInfo.USERNAME, val);
    }

    /**
     * �Z�L�����e�B�O���[�v�R�[�h���擾����
     *
     * @return �Z�L�����e�B�O���[�v�R�[�h
     */
    public String getSECURITYGROUPCODE()
    {
        return (String) get(T_SecurityGroup.SECURITYGROUPCODE);
    }

    /**
     * �Z�L�����e�B�O���[�v�R�[�h��ݒ肷��
     *
     * @param val �Z�L�����e�B�O���[�v�R�[�h
     */
    public void setSECURITYGROUPCODE(String val)
    {
        set(T_SecurityGroup.SECURITYGROUPCODE, val);
    }

    /**
     * �O���[�v���̂��擾����
     *
     * @return �O���[�v����
     */
    public String getSECURITYGROUPNAME()
    {
        return (String) get(T_SecurityGroup.SECURITYGROUPNAME);
    }

    /**
     * �O���[�v���̂�ݒ肷��
     *
     * @param val �O���[�v����
     */
    public void setSECURITYGROUPNAME(String val)
    {
        set(T_SecurityGroup.SECURITYGROUPNAME, val);
    }

}
