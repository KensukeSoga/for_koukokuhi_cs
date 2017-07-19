package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj29SetteiKykVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceEstablishmentOfficeDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceEstablishmentOfficeDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �ݒ�Ǖ\�����擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 �X)<BR>
 * </P>
 * @author �X
 */
public class FindMasterMaintenanceEstablishmentOfficeCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMasterMaintenanceEstablishmentOfficeDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceEstablishmentOfficeDispResult result = new FindMasterMaintenanceEstablishmentOfficeDispResult();

        FindMbj29SetteiKykVO establishmentOfficeVO = manager.getMasterMaintenanceEstablishmentOffice(_condition.getConditionEstablishmentOffice());

        result.setEstablishmentOfficeVO(establishmentOfficeVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindCondition(FindMasterMaintenanceEstablishmentOfficeDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public FindMasterMaintenanceEstablishmentOfficeDispResult getFindResult()
    {
        return (FindMasterMaintenanceEstablishmentOfficeDispResult) super.getResult().get(RESULT_KEY);
    }

}
