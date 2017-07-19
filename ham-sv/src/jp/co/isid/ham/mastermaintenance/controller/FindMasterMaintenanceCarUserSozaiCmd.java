package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarUserSozaiDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarUserSozaiDispResult;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarUserSozaiSpreadVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceHCHMSecGrpUserSpreadVO;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �Ԏ�S��(�f��)�\�����擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2016/02/17 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */
public class FindMasterMaintenanceCarUserSozaiCmd extends Command{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMasterMaintenanceCarUserSozaiDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();
        FindMasterMaintenanceCarUserSozaiDispResult result = new FindMasterMaintenanceCarUserSozaiDispResult();

        //�Ԏ�S��(�f��)�}�X�^
        FindMasterMaintenanceCarUserSozaiSpreadVO carUserSozaiSpreadVO = manager.getCarUserSozaiSpread(_condition.getConditionCarUserSozaiSpread());
        result.setCarUserSozaiSpreadVO(carUserSozaiSpreadVO);

       //�Ԏ�}�X�^
        result.setCarVO(manager.getMasterMaintenanceCar(_condition.getConditionCar()));

        //�Z�L�����e�B�O���[�v���[�U�[(HC/HM)
        FindMasterMaintenanceHCHMSecGrpUserSpreadVO HCHMSecGrpUserSpreadVO = manager.getHCHMSecGrpUserSpread(_condition.getConditionHCHMSecGrpUserSpread());
        result.setHCHMSecGrpUserSpreadVO(HCHMSecGrpUserSpreadVO);

        getResult().set(RESULT_KEY, result);
    }


    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindCondition(FindMasterMaintenanceCarUserSozaiDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public FindMasterMaintenanceCarUserSozaiDispResult getFindResult()
    {
        return (FindMasterMaintenanceCarUserSozaiDispResult) super.getResult().get(RESULT_KEY);
    }

}
