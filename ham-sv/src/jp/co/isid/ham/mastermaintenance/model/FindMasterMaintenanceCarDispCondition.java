package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj05CarCondition;
import jp.co.isid.ham.common.model.Mbj04KeiretsuCondition;
import jp.co.isid.ham.common.model.Mbj02UserCondition;
import jp.co.isid.ham.common.model.Mbj13CarOutCtrlCondition;

/**
 * <P>
 * �Ԏ�\�����Condition
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCarDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �Ԏ�}�X�^�������� */
    private Mbj05CarCondition _conditionCar;

    /** �n��}�X�^�������� */
    private Mbj04KeiretsuCondition _conditionSeries;

    /** �S���҃}�X�^�������� */
    private Mbj02UserCondition _conditionUser;

    /** �Ԏ�o�͐ݒ�}�X�^�������� */
    private Mbj13CarOutCtrlCondition _conditionCarOutControl;

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

    /**
     * �n��}�X�^����������ݒ肵�܂�
     * @param data �Z�b�g���� _conditionSeries
     */
    public void setConditionSeries(Mbj04KeiretsuCondition data)
    {
        _conditionSeries = data;
    }

    /**
     * �n��}�X�^�����������擾���܂�
     * @return _conditionSeries
     */
    public Mbj04KeiretsuCondition getConditionSeries()
    {
        return _conditionSeries;
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

    /**
     * �Ԏ�o�͐ݒ�}�X�^����������ݒ肵�܂�
     * @param data �Z�b�g���� _conditionCarOutControl
     */
    public void setConditionCarOutControl(Mbj13CarOutCtrlCondition data)
    {
        _conditionCarOutControl = data;
    }

    /**
     * �Ԏ�o�͐ݒ�}�X�^�����������擾���܂�
     * @return _conditionCarOutControl
     */
    public Mbj13CarOutCtrlCondition getConditionCarOutControl()
    {
        return _conditionCarOutControl;
    }

}
