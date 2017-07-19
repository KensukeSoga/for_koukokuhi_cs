package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj05CarVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj04KeiretsuVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj02UserVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj13CarOutCtrlVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 車種表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceCarCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceCarDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceCarDispResult result = new FindMasterMaintenanceCarDispResult();

        FindMbj05CarVO carVO = manager.getMasterMaintenanceCar(_condition.getConditionCar());

        FindMbj04KeiretsuVO seriesVO = manager.getMasterMaintenanceSeries(_condition.getConditionSeries());

        FindMbj02UserVO userVO = manager.getMasterMaintenanceUser(_condition.getConditionUser());

        FindMbj13CarOutCtrlVO carOutControlVO = manager.getMasterMaintenanceCarOutControl(_condition.getConditionCarOutControl());

        result.setCarVO(carVO);

        result.setSeriesVO(seriesVO);

        result.setUserVO(userVO);

        result.setCarOutControlVO(carOutControlVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceCarDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceCarDispResult getFindResult()
    {
        return (FindMasterMaintenanceCarDispResult) super.getResult().get(RESULT_KEY);
    }

}
