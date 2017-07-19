package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.FunctionControlInfoResult;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.SecurityInfoResult;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMasterFormDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMasterFormDispResult;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMasterFormVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * MasterForm表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/04 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceMasterFormCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceMasterFormDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        FunctionControlInfoManager managerFunctionControlInfo = FunctionControlInfoManager.getInstance();

        SecurityInfoManager managerSecurityInfo = SecurityInfoManager.getInstance();

        FindMasterMaintenanceMasterFormDispResult result = new FindMasterMaintenanceMasterFormDispResult();

        FindMasterMaintenanceMasterFormVO masterFormVO = new FindMasterMaintenanceMasterFormVO();

        FunctionControlInfoResult functionControlInfoResult = managerFunctionControlInfo.getFunctionControlInfo(_condition.getConditionFunctionControlInfo());

        SecurityInfoResult securityInfoResult = managerSecurityInfo.getSecurityInfo(_condition.getConditionSecurityInfo());

        masterFormVO.setFindFunctionControlInfoList(functionControlInfoResult.getFunctionControlInfo());

        masterFormVO.setFindSecurityInfoList(securityInfoResult.getSecurityInfo());

        result.setMasterFormVO(masterFormVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceMasterFormDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceMasterFormDispResult getFindResult()
    {
        return (FindMasterMaintenanceMasterFormDispResult) super.getResult().get(RESULT_KEY);
    }

}
