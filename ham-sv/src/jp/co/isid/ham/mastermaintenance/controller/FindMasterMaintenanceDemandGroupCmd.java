package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj26BillGroupVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj06HcBumonVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceDemandGroupDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceDemandGroupDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 請求先グループ表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceDemandGroupCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceDemandGroupDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceDemandGroupDispResult result = new FindMasterMaintenanceDemandGroupDispResult();

        FindMbj26BillGroupVO demandGroupVO = manager.getMasterMaintenanceDemandGroup(_condition.getConditionDemandGroup());

        FindMbj06HcBumonVO hCSectionVO = manager.getMasterMaintenanceHCSection(_condition.getConditionHCSection());

        result.setDemandGroupVO(demandGroupVO);

        result.setHCSectionVO(hCSectionVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceDemandGroupDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceDemandGroupDispResult getFindResult()
    {
        return (FindMasterMaintenanceDemandGroupDispResult) super.getResult().get(RESULT_KEY);
    }

}
