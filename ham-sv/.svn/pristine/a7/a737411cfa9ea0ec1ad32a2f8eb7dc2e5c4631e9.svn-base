package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceHMUserDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceHMUserDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HM担当者表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindMasterMaintenanceHMUserCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceHMUserDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException {

        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();
        FindMasterMaintenanceHMUserDispResult result = new FindMasterMaintenanceHMUserDispResult();
        result.setHMUserVO( manager.getMasterMaintenanceHMUser(_condition.getConditionHMUser()));
        result.setCodeVO(manager.getMasterMaintenanceCode(_condition.getConditionCode()));
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceHMUserDispCondition condition) {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceHMUserDispResult getFindResult() {
        return (FindMasterMaintenanceHMUserDispResult) super.getResult().get(RESULT_KEY);
    }

}
