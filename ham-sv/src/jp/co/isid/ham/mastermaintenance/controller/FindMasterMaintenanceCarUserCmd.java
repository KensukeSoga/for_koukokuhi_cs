package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarUserSpreadVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarUserDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceCarUserDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 車種担当表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceCarUserCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceCarUserDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();
        FindMasterMaintenanceCarUserDispResult result = new FindMasterMaintenanceCarUserDispResult();

        //車種担当マスタ
        FindMasterMaintenanceCarUserSpreadVO carUserSpreadVO = manager.getCarUserSpread(_condition.getConditionCarUserSpread());
        result.setCarUserSpreadVO(carUserSpreadVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceCarUserDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceCarUserDispResult getFindResult()
    {
        return (FindMasterMaintenanceCarUserDispResult) super.getResult().get(RESULT_KEY);
    }

}
