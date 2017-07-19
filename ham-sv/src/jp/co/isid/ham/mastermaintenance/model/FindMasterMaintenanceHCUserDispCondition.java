package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj07HcUserCondition;
import jp.co.isid.ham.common.model.Mbj06HcBumonCondition;

/**
 * <P>
 * HC�S���ҕ\�����Condition
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceHCUserDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** HC�S���҃}�X�^�������� */
    private Mbj07HcUserCondition _conditionHCUser;

    /** HC����}�X�^�������� */
    private Mbj06HcBumonCondition _conditionHCSection;

    /**
     * HC�S���҃}�X�^����������ݒ肵�܂�
     * @param data �Z�b�g���� _conditionHCUser
     */
    public void setConditionHCUser(Mbj07HcUserCondition data)
    {
        _conditionHCUser = data;
    }

    /**
     * HC�S���҃}�X�^�����������擾���܂�
     * @return _conditionHCUser
     */
    public Mbj07HcUserCondition getConditionHCUser()
    {
        return _conditionHCUser;
    }

    /**
     * HC����}�X�^����������ݒ肵�܂�
     * @param data �Z�b�g���� _conditionHCSection
     */
    public void setConditionHCSection(Mbj06HcBumonCondition data)
    {
        _conditionHCSection = data;
    }

    /**
     * HC����}�X�^�����������擾���܂�
     * @return _conditionHCSection
     */
    public Mbj06HcBumonCondition getConditionHCSection()
    {
        return _conditionHCSection;
    }

}
