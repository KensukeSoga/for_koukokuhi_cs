package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �l���View�\����񌟍�Condition
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/08 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceAccUserDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �l���View�������� */
    private MasterMaintenanceAccUserCondition _conditionAccUser = null;

    /**
     * �l���View����������ݒ肵�܂�
     * @param data �Z�b�g���� _conditionListAccUser
     */
    public void setConditionAccUser(MasterMaintenanceAccUserCondition data)
    {
        _conditionAccUser = data;
    }

    /**
     * �l���View�����������擾���܂�
     * @return _conditionListAccUser
     */
    public MasterMaintenanceAccUserCondition getConditionAccUser()
    {
        return _conditionAccUser;
    }

}
