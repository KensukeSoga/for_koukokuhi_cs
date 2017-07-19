package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMEU07SIKKRSPRDVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMEU07SIKKRSPRDDispLikeCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMEU07SIKKRSPRDDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 経理組織展開テーブル表示情報取得コマンド（含む検索）
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/05/02 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceMEU07SIKKRSPRDLikeCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceMEU07SIKKRSPRDDispLikeCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceMEU07SIKKRSPRDDispResult result = new FindMasterMaintenanceMEU07SIKKRSPRDDispResult();

        FindMasterMaintenanceMEU07SIKKRSPRDVO mEU07SIKKRSPRDVO = manager.getMasterMaintenanceMEU07SIKKRSPRDLike(_condition.getLikeConditionMEU07SIKKRSPRD());

        result.setMEU07SIKKRSPRDVO(mEU07SIKKRSPRDVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceMEU07SIKKRSPRDDispLikeCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceMEU07SIKKRSPRDDispResult getFindResult()
    {
        return (FindMasterMaintenanceMEU07SIKKRSPRDDispResult) super.getResult().get(RESULT_KEY);
    }

}
