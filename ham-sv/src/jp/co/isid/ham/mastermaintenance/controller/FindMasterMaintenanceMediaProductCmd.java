package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj27MediaProductVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj05CarVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj03MediaVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj06HcBumonVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj08HcProductVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMediaProductDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMediaProductDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �}�́E���i�R�t�\�����擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 �X)<BR>
 * </P>
 * @author �X
 */
public class FindMasterMaintenanceMediaProductCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMasterMaintenanceMediaProductDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceMediaProductDispResult result = new FindMasterMaintenanceMediaProductDispResult();

        FindMbj27MediaProductVO mediaProductVO = manager.getMasterMaintenanceMediaProduct(_condition.getConditionMediaProduct());

        FindMbj05CarVO carVO = manager.getMasterMaintenanceCar(_condition.getConditionCar());

        FindMbj03MediaVO mediaVO = manager.getMasterMaintenanceMedia(_condition.getConditionMedia());

        FindMbj06HcBumonVO hCSectionVO = manager.getMasterMaintenanceHCSection(_condition.getConditionHCSection());

        FindMbj08HcProductVO hCProductVO = manager.getMasterMaintenanceHCProduct(_condition.getConditionHCProduct());

        result.setMediaProductVO(mediaProductVO);

        result.setCarVO(carVO);

        result.setMediaVO(mediaVO);

        result.setHCSectionVO(hCSectionVO);

        result.setHCProductVO(hCProductVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindCondition(FindMasterMaintenanceMediaProductDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public FindMasterMaintenanceMediaProductDispResult getFindResult()
    {
        return (FindMasterMaintenanceMediaProductDispResult) super.getResult().get(RESULT_KEY);
    }

}
