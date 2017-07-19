package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceHCProductSpreadVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj06HcBumonVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj12CodeVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceHCProductDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceHCProductDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HC商品表示情報取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/13 森)<BR>
 * </P>
 * @author 森
 */
public class FindMasterMaintenanceHCProductCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMasterMaintenanceHCProductDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceHCProductDispResult result = new FindMasterMaintenanceHCProductDispResult();

        FindMasterMaintenanceHCProductSpreadVO hCProductSpreadVO = manager.getHCProductSpread(_condition.getConditionHCProductSpread());

        FindMbj06HcBumonVO hCSectionVO = manager.getMasterMaintenanceHCSection(_condition.getConditionHCSection());

        FindMbj12CodeVO codeVO = manager.getMasterMaintenanceCode(_condition.getConditionCode());

        result.setHCProductSpreadVO(hCProductSpreadVO);

        result.setHCSectionVO(hCSectionVO);

        result.setCodeVO(codeVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindCondition(FindMasterMaintenanceHCProductDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return 結果
     */
    public FindMasterMaintenanceHCProductDispResult getFindResult()
    {
        return (FindMasterMaintenanceHCProductDispResult) super.getResult().get(RESULT_KEY);
    }

}
