package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj35MediaPatternCondition;
import jp.co.isid.ham.common.model.Mbj36MediaPatternItemCondition;

/**
 * <P>
 * �}�̃p�^�[���\�����Condition
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceMediaPatternDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �}�̃p�^�[���}�X�^�������� */
    private Mbj35MediaPatternCondition _conditionMediaPattern;

    /** �}�̃p�^�[�����e�}�X�^�������� */
    private Mbj36MediaPatternItemCondition _conditionMediaPatternItem;

    /** �G�}�̃}�X�^Condition */
    private MasterMaintenanceMEU20MSMZBTCondition _conditionMEU20MSMZBT;

    /**
     * �}�̃p�^�[���}�X�^����������ݒ肵�܂�
     * @param data �Z�b�g���� _conditionMediaPattern
     */
    public void setConditionMediaPattern(Mbj35MediaPatternCondition data)
    {
        _conditionMediaPattern = data;
    }

    /**
     * �}�̃p�^�[���}�X�^�����������擾���܂�
     * @return _conditionMediaPattern
     */
    public Mbj35MediaPatternCondition getConditionMediaPattern()
    {
        return _conditionMediaPattern;
    }

    /**
     * �}�̃p�^�[�����e�}�X�^����������ݒ肵�܂�
     * @param data �Z�b�g���� _conditionMediaPatternItem
     */
    public void setConditionMediaPatternItem(Mbj36MediaPatternItemCondition data)
    {
        _conditionMediaPatternItem = data;
    }

    /**
     * �}�̃p�^�[�����e�}�X�^�����������擾���܂�
     * @return _conditionMediaPatternItem
     */
    public Mbj36MediaPatternItemCondition getConditionMediaPatternItem()
    {
        return _conditionMediaPatternItem;
    }

    /**
     * �G�}�̃}�X�^Condition��ݒ肵�܂�
     * @param data �Z�b�g���� _conditionMEU20MSMZBT
     */
    public void setConditionMEU20MSMZBT(MasterMaintenanceMEU20MSMZBTCondition data)
    {
        _conditionMEU20MSMZBT = data;
    }

    /**
     * �G�}�̃}�X�^Condition���擾���܂�
     * @return _conditionMEU20MSMZBT
     */
    public MasterMaintenanceMEU20MSMZBTCondition getConditionMEU20MSMZBT()
    {
        return _conditionMEU20MSMZBT;
    }

}
