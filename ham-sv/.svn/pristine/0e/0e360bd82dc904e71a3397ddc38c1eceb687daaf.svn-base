package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceFunctionControlSpreadVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj02UserVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj39FunctionControlBaseVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceFunctionControlDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceFunctionControlDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 機能制御表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceFunctionControlCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceFunctionControlDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceFunctionControlDispResult result = new FindMasterMaintenanceFunctionControlDispResult();

        FindMasterMaintenanceFunctionControlSpreadVO functionControlSpreadVO = manager.getFunctionControlSpread(_condition.getConditionFunctionControlSpread());

        FindMbj02UserVO userVO = manager.getMasterMaintenanceUser(_condition.getConditionUser());

        FindMbj39FunctionControlBaseVO functionControlBaseVO = manager.getMasterMaintenanceFunctionControlBase(_condition.getConditionFunctionControlBase());

        result.setFunctionControlSpreadVO(functionControlSpreadVO);

        result.setUserVO(userVO);

        result.setFunctionControlBaseVO(functionControlBaseVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceFunctionControlDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceFunctionControlDispResult getFindResult()
    {
        return (FindMasterMaintenanceFunctionControlDispResult) super.getResult().get(RESULT_KEY);
    }

}
