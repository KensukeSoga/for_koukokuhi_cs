package jp.co.isid.ham.mastermaintenance.model;

import java.io.Serializable;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj03MediaCondition;
import jp.co.isid.ham.common.model.Mbj05CarCondition;
import jp.co.isid.ham.common.model.Mbj09HiyouCondition;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj48HmUserCondition;
import jp.co.isid.ham.common.model.Mbj49MediaProductionCondition;

/**
 * <P>
 * ��p���No�\����񌟍�����
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * �E�����Ɩ��ύX�Ή�(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCostPlanDispCondition implements Serializable
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ��p���No�������� */
    private Mbj09HiyouCondition _conditionCostPlan = null;
    /** �Ԏ�}�X�^�������� */
    private Mbj05CarCondition _conditionCar = null;
    /** �}�̃}�X�^�������� */
    private Mbj03MediaCondition _conditionMedia = null;
    /** �R�[�h�}�X�^�����������X�g */
    private List<Mbj12CodeCondition> _conditionListCode = null;

    /* 2015/08/31 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD Start */
    /** HM�S���҃}�X�^�������� */
    private Mbj48HmUserCondition _conditionHmUser = null;
    /** �}��(����)�}�X�^�������� */
    private Mbj49MediaProductionCondition _conditionMediaProduction = null;
    /* 2015/08/31 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD End */

    /**
     * ��p���No����������ݒ肵�܂�
     * @param val �Z�b�g���� _conditionCostPlan
     */
    public void setConditionCostPlan(Mbj09HiyouCondition val) {
        _conditionCostPlan = val;
    }

    /**
     * ��p���No�����������擾���܂�
     * @return _conditionCostPlan
     */
    public Mbj09HiyouCondition getConditionCostPlan() {
        return _conditionCostPlan;
    }

    /**
     * �Ԏ�}�X�^����������ݒ肵�܂�
     * @param data �Z�b�g���� _conditionCar
     */
    public void setConditionCar(Mbj05CarCondition val) {
        _conditionCar = val;
    }

    /**
     * �Ԏ�}�X�^�����������擾���܂�
     * @return _conditionCar
     */
    public Mbj05CarCondition getConditionCar() {
        return _conditionCar;
    }

    /**
     * �}�̃}�X�^����������ݒ肵�܂�
     * @param data �Z�b�g���� _conditionMedia
     */
    public void setConditionMedia(Mbj03MediaCondition val) {
        _conditionMedia = val;
    }

    /**
     * �}�̃}�X�^�����������擾���܂�
     * @return _conditionMedia
     */
    public Mbj03MediaCondition getConditionMedia() {
        return _conditionMedia;
    }

    /**
     * �R�[�h�}�X�^�����������X�g��ݒ肵�܂�
     * @param data �Z�b�g���� _conditionListCode
     */
    public void setConditionListCode(List<Mbj12CodeCondition> val) {
        _conditionListCode = val;
    }

    /**
     * �R�[�h�}�X�^�����������X�g���擾���܂�
     * @return _conditionListCode
     */
    public List<Mbj12CodeCondition> getConditionListCode() {
        return _conditionListCode;
    }

    /* 2015/08/31 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD Start */
    /**
     * HM�S���҃}�X�^�����������擾����
     * @return Mbj48HmUserCondition HM�S���҃}�X�^��������
     */
    public Mbj48HmUserCondition getConditionHmUser() {
        return _conditionHmUser;
    }

    /**
     * HM�S���҃}�X�^����������ݒ肷��
     * @param val Mbj48HmUserCondition HM�S���҃}�X�^��������
     */
    public void setConditionHmUser(Mbj48HmUserCondition val) {
        _conditionHmUser = val;
    }

    /**
     * �}��(����)�}�X�^�����������擾����
     * @return Mbj49MediaProductionCondition �}��(����)�}�X�^��������
     */
    public Mbj49MediaProductionCondition getConditionMediaProduction() {
        return _conditionMediaProduction;
    }

    /**
     * �}��(����)�}�X�^����������ݒ肷��
     * @param val Mbj49MediaProductionCondition �}��(����)�}�X�^��������
     */
    public void setConditionMediaProduction(Mbj49MediaProductionCondition val) {
        _conditionMediaProduction = val;
    }
    /* 2015/08/31 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD End */

}
