package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj22CategoryContentVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj20CarCategoryVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj05CarVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarCategoryContentDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarCategoryContentDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �Ԏ�J�e�S���R�t�\�����擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * </P>
 * @author �X
 */
public class FindMasterMaintenanceCarCategoryContentCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMasterMaintenanceCarCategoryContentDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceCarCategoryContentDispResult result = new FindMasterMaintenanceCarCategoryContentDispResult();

        FindMbj22CategoryContentVO carCategoryContentVO = manager.getMasterMaintenanceCarCategoryContent(_condition.getConditionCarCategoryContent());

        FindMbj20CarCategoryVO carCategoryVO = manager.getMasterMaintenanceCarCategory(_condition.getConditionCarCategory());

        FindMbj05CarVO carVO = manager.getMasterMaintenanceCar(_condition.getConditionCar());

        result.setCarCategoryContentVO(carCategoryContentVO);

        result.setCarCategoryVO(carCategoryVO);

        result.setCarVO(carVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindCondition(FindMasterMaintenanceCarCategoryContentDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public FindMasterMaintenanceCarCategoryContentDispResult getFindResult()
    {
        return (FindMasterMaintenanceCarCategoryContentDispResult) super.getResult().get(RESULT_KEY);
    }

}
