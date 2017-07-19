package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarUserSpreadVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarUserDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarUserDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �Ԏ�S���\�����擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * </P>
 * @author �X
 */
public class FindMasterMaintenanceCarUserCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMasterMaintenanceCarUserDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();
        FindMasterMaintenanceCarUserDispResult result = new FindMasterMaintenanceCarUserDispResult();

        //�Ԏ�S���}�X�^
        FindMasterMaintenanceCarUserSpreadVO carUserSpreadVO = manager.getCarUserSpread(_condition.getConditionCarUserSpread());
        result.setCarUserSpreadVO(carUserSpreadVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindCondition(FindMasterMaintenanceCarUserDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public FindMasterMaintenanceCarUserDispResult getFindResult()
    {
        return (FindMasterMaintenanceCarUserDispResult) super.getResult().get(RESULT_KEY);
    }

}
