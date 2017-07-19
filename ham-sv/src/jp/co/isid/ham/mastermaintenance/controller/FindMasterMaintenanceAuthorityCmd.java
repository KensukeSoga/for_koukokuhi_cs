package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarAuthoritySpreadVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMediaAuthoritySpreadVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceSecuritySpreadVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj44SecurityBaseVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj02UserVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceAuthorityDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceAuthorityDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �����\�����擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/04 �X)<BR>
 * </P>
 * @author �X
 */
public class FindMasterMaintenanceAuthorityCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMasterMaintenanceAuthorityDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceAuthorityDispResult result = new FindMasterMaintenanceAuthorityDispResult();

        FindMasterMaintenanceCarAuthoritySpreadVO carAuthoritySpreadVO = manager.getCarAuthoritySpread(_condition.getConditionCarAuthoritySpread());

        FindMasterMaintenanceMediaAuthoritySpreadVO mediaAuthoritySpreadVO = manager.getMediaAuthoritySpread(_condition.getConditionMediaAuthoritySpread());

        FindMasterMaintenanceSecuritySpreadVO securitySpreadVO = manager.getSecuritySpread(_condition.getConditionSecuritySpread());

        FindMbj44SecurityBaseVO securityBaseVO = manager.getMasterMaintenanceSecurityBase(_condition.getConditionSecurityBase());

        FindMbj02UserVO userVO = manager.getMasterMaintenanceUser(_condition.getConditionUser());

        result.setCarAuthoritySpreadVO(carAuthoritySpreadVO);

        result.setMediaAuthoritySpreadVO(mediaAuthoritySpreadVO);

        result.setSecuritySpreadVO(securitySpreadVO);

        result.setSecurityBaseVO(securityBaseVO);

        result.setUserVO(userVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindCondition(FindMasterMaintenanceAuthorityDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public FindMasterMaintenanceAuthorityDispResult getFindResult()
    {
        return (FindMasterMaintenanceAuthorityDispResult) super.getResult().get(RESULT_KEY);
    }

}
