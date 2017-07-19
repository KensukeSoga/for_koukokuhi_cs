package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindHCEstimateListCondition;
import jp.co.isid.ham.billing.model.FindHCEstimateListResult;
import jp.co.isid.ham.billing.model.HCEstimateListManager;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HC見積一覧検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/4 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCEstimateListCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    FindHCEstimateListCondition _cond;

    /**
     * HC見積一覧検索
     */
    @Override
    public void execute() throws UserException {
        HCEstimateListManager manager = HCEstimateListManager.getInstance();
        FindHCEstimateListResult result = manager.findHCEstimateList(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param cond 検索条件
     */
    public void setFindHCEstimateListCondition(FindHCEstimateListCondition cond) {
        _cond = cond;
    }

    /**
     * 検索結果を返します
     *
     * @return 検索結果
     */
    public FindHCEstimateListResult getFindHCEstimateListResult() {
        return (FindHCEstimateListResult)super.getResult().get(RESULT_KEY);
    }
}
