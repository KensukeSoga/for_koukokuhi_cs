package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj07HcUserVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj06HcBumonVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceHCUserDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceHCUserDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HC�S���ҕ\�����擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 �X)<BR>
 * </P>
 * @author �X
 */
public class FindMasterMaintenanceHCUserCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMasterMaintenanceHCUserDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceHCUserDispResult result = new FindMasterMaintenanceHCUserDispResult();

        FindMbj07HcUserVO hCUserVO = manager.getMasterMaintenanceHCUser(_condition.getConditionHCUser());

        FindMbj06HcBumonVO hCSectionVO = manager.getMasterMaintenanceHCSection(_condition.getConditionHCSection());

        result.setHCUserVO(hCUserVO);

        result.setHCSectionVO(hCSectionVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindCondition(FindMasterMaintenanceHCUserDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public FindMasterMaintenanceHCUserDispResult getFindResult()
    {
        return (FindMasterMaintenanceHCUserDispResult) super.getResult().get(RESULT_KEY);
    }

}
