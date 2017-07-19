package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceUserSpreadVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj03MediaVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj05CarVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj12CodeVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj34FunctionControlItemVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj39FunctionControlBaseVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj43SecurityItemVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj44SecurityBaseVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceUserDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceUserDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �S���ҕ\�����擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * </P>
 * @author �X
 */
public class FindMasterMaintenanceUserCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMasterMaintenanceUserDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceUserDispResult result = new FindMasterMaintenanceUserDispResult();

        FindMasterMaintenanceUserSpreadVO userSpreadVO = manager.getUserSpread(_condition.getConditionUserSpread());

        FindMbj05CarVO carVO = manager.getMasterMaintenanceCar(_condition.getConditionCar());

        FindMbj03MediaVO mediaVO = manager.getMasterMaintenanceMedia(_condition.getConditionMedia());

        FindMbj34FunctionControlItemVO functionControlItemVO = manager.getMasterMaintenanceFunctionControlItem(_condition.getConditionFunctionControlItem());

        FindMbj39FunctionControlBaseVO functionControlBaseVO = manager.getMasterMaintenanceFunctionControlBase(_condition.getConditionFunctionControlBase());

        FindMbj43SecurityItemVO securityItemVO = manager.getMasterMaintenanceSecurityItem(_condition.getConditionSecurityItem());

        FindMbj44SecurityBaseVO securityBaseVO = manager.getMasterMaintenanceSecurityBase(_condition.getConditionSecurityBase());

        FindMbj12CodeVO codeVO = manager.getMasterMaintenanceCode(_condition.getConditionCode());

        result.setUserSpreadVO(userSpreadVO);

        result.setCarVO(carVO);

        result.setMediaVO(mediaVO);

        result.setFunctionControlItemVO(functionControlItemVO);

        result.setFunctionControlBaseVO(functionControlBaseVO);

        result.setSecurityItemVO(securityItemVO);

        result.setSecurityBaseVO(securityBaseVO);

        result.setCodeVO(codeVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindCondition(FindMasterMaintenanceUserDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public FindMasterMaintenanceUserDispResult getFindResult()
    {
        return (FindMasterMaintenanceUserDispResult) super.getResult().get(RESULT_KEY);
    }

}
