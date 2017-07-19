package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj03MediaCondition;
import jp.co.isid.ham.common.model.Mbj02UserCondition;
import jp.co.isid.ham.common.model.Mbj14MediaOutCtrlCondition;

/**
 * <P>
 * �}�̕\�����Condition
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceMediaDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �}�̃}�X�^�������� */
    private Mbj03MediaCondition _conditionMedia;

    /** �S���҃}�X�^�������� */
    private Mbj02UserCondition _conditionUser;

    /** �}�̏o�͐ݒ�}�X�^�������� */
    private Mbj14MediaOutCtrlCondition _conditionMediaOutControl;

    /**
     * �}�̃}�X�^����������ݒ肵�܂�
     * @param data �Z�b�g���� _conditionMedia
     */
    public void setConditionMedia(Mbj03MediaCondition data)
    {
        _conditionMedia = data;
    }

    /**
     * �}�̃}�X�^�����������擾���܂�
     * @return _conditionMedia
     */
    public Mbj03MediaCondition getConditionMedia()
    {
        return _conditionMedia;
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
     * �}�̏o�͐ݒ�}�X�^����������ݒ肵�܂�
     * @param data �Z�b�g���� _conditionMediaOutControl
     */
    public void setConditionMediaOutControl(Mbj14MediaOutCtrlCondition data)
    {
        _conditionMediaOutControl = data;
    }

    /**
     * �}�̏o�͐ݒ�}�X�^�����������擾���܂�
     * @return _conditionMediaOutControl
     */
    public Mbj14MediaOutCtrlCondition getConditionMediaOutControl()
    {
        return _conditionMediaOutControl;
    }

}
