package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj04KeiretsuVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceSeriesDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceSeriesDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 系列表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/06 神山)<BR>
 * </P>
 * @author 神山
 */
public class FindMasterMaintenanceSeriesCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceSeriesDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceSeriesDispResult result = new FindMasterMaintenanceSeriesDispResult();

        FindMbj04KeiretsuVO SeriesVO = manager.getMasterMaintenanceSeries(_condition.getConditionSeries());

        result.setSeriesVO(SeriesVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceSeriesDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceSeriesDispResult getFindResult()
    {
        return (FindMasterMaintenanceSeriesDispResult) super.getResult().get(RESULT_KEY);
    }

}
