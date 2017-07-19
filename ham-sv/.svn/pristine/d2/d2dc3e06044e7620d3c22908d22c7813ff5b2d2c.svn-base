package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj29SetteiKykVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceEstablishmentOfficeDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceEstablishmentOfficeDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 設定局表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceEstablishmentOfficeCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceEstablishmentOfficeDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceEstablishmentOfficeDispResult result = new FindMasterMaintenanceEstablishmentOfficeDispResult();

        FindMbj29SetteiKykVO establishmentOfficeVO = manager.getMasterMaintenanceEstablishmentOffice(_condition.getConditionEstablishmentOffice());

        result.setEstablishmentOfficeVO(establishmentOfficeVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceEstablishmentOfficeDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceEstablishmentOfficeDispResult getFindResult()
    {
        return (FindMasterMaintenanceEstablishmentOfficeDispResult) super.getResult().get(RESULT_KEY);
    }

}
