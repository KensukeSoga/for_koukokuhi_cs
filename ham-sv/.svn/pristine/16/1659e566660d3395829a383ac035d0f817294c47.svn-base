package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceAccUserVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceAccUserDispLikeCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceAccUserDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 個人情報View表示情報取得コマンド（含む検索）
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/02/08 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceAccUserLikeCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceAccUserDispLikeCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceAccUserDispResult result = new FindMasterMaintenanceAccUserDispResult();

        FindMasterMaintenanceAccUserVO accUserVO = manager.getMasterMaintenanceAccUserLike(_condition.getLikeConditionAccUser());

        result.setAccUserVO(accUserVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceAccUserDispLikeCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceAccUserDispResult getFindResult()
    {
        return (FindMasterMaintenanceAccUserDispResult) super.getResult().get(RESULT_KEY);
    }

}
