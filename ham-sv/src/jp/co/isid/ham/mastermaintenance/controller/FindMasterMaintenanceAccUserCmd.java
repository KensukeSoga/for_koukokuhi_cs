package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceAccUserVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceAccUserDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceAccUserDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �l���View�\�����擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/08 �X)<BR>
 * </P>
 * @author �X
 */
public class FindMasterMaintenanceAccUserCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMasterMaintenanceAccUserDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceAccUserDispResult result = new FindMasterMaintenanceAccUserDispResult();

        FindMasterMaintenanceAccUserVO accUserVO = manager.getMasterMaintenanceAccUser(_condition.getConditionAccUser());

        result.setAccUserVO(accUserVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindCondition(FindMasterMaintenanceAccUserDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public FindMasterMaintenanceAccUserDispResult getFindResult()
    {
        return (FindMasterMaintenanceAccUserDispResult) super.getResult().get(RESULT_KEY);
    }

}
