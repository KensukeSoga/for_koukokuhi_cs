package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj26BillGroupVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj06HcBumonVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceDemandGroupDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceDemandGroupDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * ������O���[�v�\�����擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * </P>
 * @author �X
 */
public class FindMasterMaintenanceDemandGroupCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMasterMaintenanceDemandGroupDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceDemandGroupDispResult result = new FindMasterMaintenanceDemandGroupDispResult();

        FindMbj26BillGroupVO demandGroupVO = manager.getMasterMaintenanceDemandGroup(_condition.getConditionDemandGroup());

        FindMbj06HcBumonVO hCSectionVO = manager.getMasterMaintenanceHCSection(_condition.getConditionHCSection());

        result.setDemandGroupVO(demandGroupVO);

        result.setHCSectionVO(hCSectionVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindCondition(FindMasterMaintenanceDemandGroupDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public FindMasterMaintenanceDemandGroupDispResult getFindResult()
    {
        return (FindMasterMaintenanceDemandGroupDispResult) super.getResult().get(RESULT_KEY);
    }

}
