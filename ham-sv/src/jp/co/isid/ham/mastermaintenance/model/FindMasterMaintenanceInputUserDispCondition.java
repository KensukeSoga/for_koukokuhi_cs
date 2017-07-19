package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj30InputTntCondition;
import jp.co.isid.ham.common.model.Mbj05CarCondition;

/**
 * <P>
 * ���͒S���\�����Condition
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceInputUserDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ���͒S���}�X�^�������� */
    private Mbj30InputTntCondition _conditionInputUser;

    /** �Ԏ�}�X�^�������� */
    private Mbj05CarCondition _conditionCar;

    /**
     * ���͒S���}�X�^����������ݒ肵�܂�
     * @param data �Z�b�g���� _conditionInputUser
     */
    public void setConditionInputUser(Mbj30InputTntCondition data)
    {
        _conditionInputUser = data;
    }

    /**
     * ���͒S���}�X�^�����������擾���܂�
     * @return _conditionInputUser
     */
    public Mbj30InputTntCondition getConditionInputUser()
    {
        return _conditionInputUser;
    }

    /**
     * �Ԏ�}�X�^����������ݒ肵�܂�
     * @param data �Z�b�g���� _conditionCar
     */
    public void setConditionCar(Mbj05CarCondition data)
    {
        _conditionCar = data;
    }

    /**
     * �Ԏ�}�X�^�����������擾���܂�
     * @return _conditionCar
     */
    public Mbj05CarCondition getConditionCar()
    {
        return _conditionCar;
    }

}
