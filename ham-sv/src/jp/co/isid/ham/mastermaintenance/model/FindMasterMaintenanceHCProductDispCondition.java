package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj06HcBumonCondition;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;

/**
 * <P>
 * HC���i�\�����Condition
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceHCProductDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** HC���i�X�v���b�hCondition */
    private MasterMaintenanceHCProductSpreadCondition _conditionHCProductSpread;

    /** HC����}�X�^�������� */
    private Mbj06HcBumonCondition _conditionHCSection;

    /** �R�[�h�}�X�^�������� */
    private Mbj12CodeCondition _conditionCode = null;

    /**
     * HC���i�X�v���b�hCondition��ݒ肵�܂�
     * @param data �Z�b�g���� _conditionHCProductSpread
     */
    public void setConditionHCProductSpread(MasterMaintenanceHCProductSpreadCondition data)
    {
        _conditionHCProductSpread = data;
    }

    /**
     * HC���i�X�v���b�hCondition���擾���܂�
     * @return _conditionHCProductSpread
     */
    public MasterMaintenanceHCProductSpreadCondition getConditionHCProductSpread()
    {
        return _conditionHCProductSpread;
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

    /**
     * �R�[�h�}�X�^����������ݒ肵�܂�
     * @param data �Z�b�g���� _conditionLock
     */
    public void setConditionCode(Mbj12CodeCondition data)
    {
        _conditionCode = data;
    }

    /**
     * �R�[�h�}�X�^�����������擾���܂�
     * @return _conditionLock
     */
    public Mbj12CodeCondition getConditionCode()
    {
        return _conditionCode;
    }

}
