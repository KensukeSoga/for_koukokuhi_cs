package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.CostManagementSettingManager;
import jp.co.isid.ham.billing.model.FindCostManagementSettingCondition;
import jp.co.isid.ham.billing.model.FindCostManagementSettingResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 制作費設定検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/1/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindCostManagementSettingCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    FindCostManagementSettingCondition _cond;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {
        CostManagementSettingManager manager = CostManagementSettingManager.getInstance();
        FindCostManagementSettingResult result = manager.findCostManagementSetting(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param cond 検索条件
     */
    public void setCostManagementSettingCondition(FindCostManagementSettingCondition cond) {
        _cond = cond;
    }

    /**
     * 検索結果を返します
     *
     * @return 検索結果
     */
    public FindCostManagementSettingResult getCostManagementSettingResult() {
        return (FindCostManagementSettingResult)super.getResult().get(RESULT_KEY);
    }

}
