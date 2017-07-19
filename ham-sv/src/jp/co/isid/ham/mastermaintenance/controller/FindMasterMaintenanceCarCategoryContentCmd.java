package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj22CategoryContentVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj20CarCategoryVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj05CarVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarCategoryContentDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarCategoryContentDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 車種カテゴリ紐付表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceCarCategoryContentCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceCarCategoryContentDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceCarCategoryContentDispResult result = new FindMasterMaintenanceCarCategoryContentDispResult();

        FindMbj22CategoryContentVO carCategoryContentVO = manager.getMasterMaintenanceCarCategoryContent(_condition.getConditionCarCategoryContent());

        FindMbj20CarCategoryVO carCategoryVO = manager.getMasterMaintenanceCarCategory(_condition.getConditionCarCategory());

        FindMbj05CarVO carVO = manager.getMasterMaintenanceCar(_condition.getConditionCar());

        result.setCarCategoryContentVO(carCategoryContentVO);

        result.setCarCategoryVO(carCategoryVO);

        result.setCarVO(carVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceCarCategoryContentDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceCarCategoryContentDispResult getFindResult()
    {
        return (FindMasterMaintenanceCarCategoryContentDispResult) super.getResult().get(RESULT_KEY);
    }

}
