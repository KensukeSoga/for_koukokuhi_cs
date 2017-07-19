package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceHCProductSpreadVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj06HcBumonVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj12CodeVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceHCProductDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceHCProductDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HC���i�\�����擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 �X)<BR>
 * </P>
 * @author �X
 */
public class FindMasterMaintenanceHCProductCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMasterMaintenanceHCProductDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceHCProductDispResult result = new FindMasterMaintenanceHCProductDispResult();

        FindMasterMaintenanceHCProductSpreadVO hCProductSpreadVO = manager.getHCProductSpread(_condition.getConditionHCProductSpread());

        FindMbj06HcBumonVO hCSectionVO = manager.getMasterMaintenanceHCSection(_condition.getConditionHCSection());

        FindMbj12CodeVO codeVO = manager.getMasterMaintenanceCode(_condition.getConditionCode());

        result.setHCProductSpreadVO(hCProductSpreadVO);

        result.setHCSectionVO(hCSectionVO);

        result.setCodeVO(codeVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindCondition(FindMasterMaintenanceHCProductDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public FindMasterMaintenanceHCProductDispResult getFindResult()
    {
        return (FindMasterMaintenanceHCProductDispResult) super.getResult().get(RESULT_KEY);
    }

}
