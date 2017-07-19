package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj02UserCondition;
import jp.co.isid.ham.common.model.Mbj44SecurityBaseCondition;

/**
 * <P>
 * �����\�����Condition
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/10 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceAuthorityDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �����X�v���b�hCondition�i�Ԏ�j */
    private MasterMaintenanceAuthoritySpreadCondition _conditionCarAuthoritySpread = null;

    /** �����X�v���b�hCondition�i�}�́j */
    private MasterMaintenanceAuthoritySpreadCondition _conditionMediaAuthoritySpread = null;

    /** �Z�L�����e�B�X�v���b�hCondition */
    private MasterMaintenanceSecuritySpreadCondition _conditionSecuritySpread = null;

    /** �Z�L�����e�B�x�[�XCondition */
    private Mbj44SecurityBaseCondition _conditionSecurityBase = null;

    /** �S���҃}�X�^�������� */
    private Mbj02UserCondition _conditionUser;

    /**
     * �����X�v���b�hCondition�i�Ԏ�j��ݒ肵�܂�
     * @param data �Z�b�g���� _conditionCarAuthoritySpread
     */
    public void setConditionCarAuthoritySpread(MasterMaintenanceAuthoritySpreadCondition data)
    {
        _conditionCarAuthoritySpread = data;
    }

    /**
     * �����X�v���b�hCondition�i�Ԏ�j���擾���܂�
     * @return _conditionCarAuthoritySpread
     */
    public MasterMaintenanceAuthoritySpreadCondition getConditionCarAuthoritySpread()
    {
        return _conditionCarAuthoritySpread;
    }

    /**
     * �����X�v���b�hCondition�i�}�́j��ݒ肵�܂�
     * @param data �Z�b�g���� _conditionMediaAuthoritySpread
     */
    public void setConditionMediaAuthoritySpread(MasterMaintenanceAuthoritySpreadCondition data)
    {
        _conditionMediaAuthoritySpread = data;
    }

    /**
     * �����X�v���b�hCondition�i�}�́j���擾���܂�
     * @return _conditionMediaAuthoritySpread
     */
    public MasterMaintenanceAuthoritySpreadCondition getConditionMediaAuthoritySpread()
    {
        return _conditionMediaAuthoritySpread;
    }

    /**
     * �Z�L�����e�B�X�v���b�hCondition��ݒ肵�܂�
     * @param data �Z�b�g���� _conditionSecuritySpread
     */
    public void setConditionSecuritySpread(MasterMaintenanceSecuritySpreadCondition data)
    {
        _conditionSecuritySpread = data;
    }

    /**
     * �Z�L�����e�B�X�v���b�hCondition���擾���܂�
     * @return _conditionSecuritySpread
     */
    public MasterMaintenanceSecuritySpreadCondition getConditionSecuritySpread()
    {
        return _conditionSecuritySpread;
    }

    /**
     * �Z�L�����e�B�x�[�XCondition��ݒ肵�܂�
     * @param data �Z�b�g���� _conditionSecurityBase
     */
    public void setConditionSecurityBase(Mbj44SecurityBaseCondition data)
    {
        _conditionSecurityBase = data;
    }

    /**
     * �Z�L�����e�B�x�[�XCondition���擾���܂�
     * @return _conditionSecurityBase
     */
    public Mbj44SecurityBaseCondition getConditionSecurityBase()
    {
        return _conditionSecurityBase;
    }

    /**
     * �S���҃}�X�^����������ݒ肵�܂�
     * @param data �Z�b�g���� _conditionUser
     */
    public void setConditionUser(Mbj02UserCondition data)
    {
        _conditionUser = data;
    }

    /**
     * �S���҃}�X�^�����������擾���܂�
     * @return _conditionUser
     */
    public Mbj02UserCondition getConditionUser()
    {
        return _conditionUser;
    }

}
