package jp.co.isid.ham.mastermaintenance.controller;

import java.util.ArrayList;
import java.util.List;

import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCostPlanDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCostPlanDispResult;
import jp.co.isid.ham.mastermaintenance.model.FindMbj12CodeVO;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * ��p���No�\�����擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * �E�����Ɩ��ύX�Ή�(2015/08/31 HLC S,Fujimoto)<BR>
 * </P>
 * @author �X
 */
public class FindMasterMaintenanceCostPlanCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMasterMaintenanceCostPlanDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();
        FindMasterMaintenanceCostPlanDispResult result = new FindMasterMaintenanceCostPlanDispResult();

        //��p���No�}�X�^
        result.setCostPlanVO(manager.getMasterMaintenanceCostPlan(_condition.getConditionCostPlan()));
        //�Ԏ�}�X�^
        result.setCarVO(manager.getMasterMaintenanceCar(_condition.getConditionCar()));
        //�}�̃}�X�^
        result.setMediaVO(manager.getMasterMaintenanceMedia(_condition.getConditionMedia()));

        /* 2015/08/31 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD Start */
        //�}�̃}�X�^(����)
        result.setMediaProduction(manager.getMasterMaintenanceMediaProduction(_condition.getConditionMediaProduction()));
        //HM�S���҃}�X�^
        result.setHmUserVO(manager.getMasterMaintenanceHMUser(_condition.getConditionHmUser()));
        /* 2015/08/31 �����Ɩ��ύX�Ή� HLC S.Fujimoto ADD End */

        //�R�[�h�}�X�^
        FindMbj12CodeVO codeVo = new FindMbj12CodeVO();
        List<Mbj12CodeVO> workList = new ArrayList<Mbj12CodeVO>();
        for (int i = 0 ; (_condition.getConditionListCode() != null) && (i < _condition.getConditionListCode().size()) ; i++)
        {
            FindMbj12CodeVO workCodeVO = manager.getMasterMaintenanceCode(_condition.getConditionListCode().get(i));

            workList.addAll(workCodeVO.getFindList());
        }
        codeVo.setFindList(workList);
        result.setCodeVO(codeVo);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindCondition(FindMasterMaintenanceCostPlanDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public FindMasterMaintenanceCostPlanDispResult getFindResult()
    {
        return (FindMasterMaintenanceCostPlanDispResult) super.getResult().get(RESULT_KEY);
    }
}
