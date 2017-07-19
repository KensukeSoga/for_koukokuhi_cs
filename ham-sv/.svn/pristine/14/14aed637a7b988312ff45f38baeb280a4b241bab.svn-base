package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj20CarCategoryVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarCategoryDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarCategoryDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 車種カテゴリ表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceCarCategoryCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceCarCategoryDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceCarCategoryDispResult result = new FindMasterMaintenanceCarCategoryDispResult();

        FindMbj20CarCategoryVO carCategoryVO = manager.getMasterMaintenanceCarCategory(_condition.getConditionCarCategory());

        result.setCarCategoryVO(carCategoryVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceCarCategoryDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceCarCategoryDispResult getFindResult()
    {
        return (FindMasterMaintenanceCarCategoryDispResult) super.getResult().get(RESULT_KEY);
    }

}
