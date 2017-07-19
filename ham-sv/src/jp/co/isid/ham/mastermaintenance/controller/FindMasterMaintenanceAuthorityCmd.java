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
 * 権限表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/04 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceAuthorityCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
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
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceAuthorityDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceAuthorityDispResult getFindResult()
    {
        return (FindMasterMaintenanceAuthorityDispResult) super.getResult().get(RESULT_KEY);
    }

}
