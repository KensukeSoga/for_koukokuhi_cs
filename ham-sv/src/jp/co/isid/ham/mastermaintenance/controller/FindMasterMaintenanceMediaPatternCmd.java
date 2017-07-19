package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj35MediaPatternVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj36MediaPatternItemVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMEU20MSMZBTVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMediaPatternDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMediaPatternDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �}�̃p�^�[���\�����擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 �X)<BR>
 * </P>
 * @author �X
 */
public class FindMasterMaintenanceMediaPatternCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMasterMaintenanceMediaPatternDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceMediaPatternDispResult result = new FindMasterMaintenanceMediaPatternDispResult();

        FindMbj35MediaPatternVO mediaPatternVO = manager.getMasterMaintenanceMediaPattern(_condition.getConditionMediaPattern());

        FindMbj36MediaPatternItemVO mediaPatternItemVO = manager.getMasterMaintenanceMediaPatternItem(_condition.getConditionMediaPatternItem());

        FindMasterMaintenanceMEU20MSMZBTVO mEU20MSMZBTVO = manager.getMEU20MSMZBT(_condition.getConditionMEU20MSMZBT());

        result.setMediaPatternVO(mediaPatternVO);

        result.setMediaPatternItemVO(mediaPatternItemVO);

        result.setMEU20MSMZBTVO(mEU20MSMZBTVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindCondition(FindMasterMaintenanceMediaPatternDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public FindMasterMaintenanceMediaPatternDispResult getFindResult()
    {
        return (FindMasterMaintenanceMediaPatternDispResult) super.getResult().get(RESULT_KEY);
    }

}
