package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj06HcBumonVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceHCSectionDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceHCSectionDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HC部門表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceHCSectionCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceHCSectionDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceHCSectionDispResult result = new FindMasterMaintenanceHCSectionDispResult();

        FindMbj06HcBumonVO hCSectionVO = manager.getMasterMaintenanceHCSection(_condition.getConditionHCSection());

        result.setHCSectionVO(hCSectionVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceHCSectionDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceHCSectionDispResult getFindResult()
    {
        return (FindMasterMaintenanceHCSectionDispResult) super.getResult().get(RESULT_KEY);
    }

}
