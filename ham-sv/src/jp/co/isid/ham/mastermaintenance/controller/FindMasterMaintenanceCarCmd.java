package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj05CarVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj04KeiretsuVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj02UserVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj13CarOutCtrlVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �Ԏ�\�����擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * </P>
 * @author �X
 */
public class FindMasterMaintenanceCarCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMasterMaintenanceCarDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceCarDispResult result = new FindMasterMaintenanceCarDispResult();

        FindMbj05CarVO carVO = manager.getMasterMaintenanceCar(_condition.getConditionCar());

        FindMbj04KeiretsuVO seriesVO = manager.getMasterMaintenanceSeries(_condition.getConditionSeries());

        FindMbj02UserVO userVO = manager.getMasterMaintenanceUser(_condition.getConditionUser());

        FindMbj13CarOutCtrlVO carOutControlVO = manager.getMasterMaintenanceCarOutControl(_condition.getConditionCarOutControl());

        result.setCarVO(carVO);

        result.setSeriesVO(seriesVO);

        result.setUserVO(userVO);

        result.setCarOutControlVO(carOutControlVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindCondition(FindMasterMaintenanceCarDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public FindMasterMaintenanceCarDispResult getFindResult()
    {
        return (FindMasterMaintenanceCarDispResult) super.getResult().get(RESULT_KEY);
    }

}
