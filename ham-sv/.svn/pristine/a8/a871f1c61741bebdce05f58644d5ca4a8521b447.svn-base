package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CostManager;
import jp.co.isid.ham.production.model.FindBudgetCondition;
import jp.co.isid.ham.production.model.FindBudgetResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 車種別予算画面　表示データ取得実行時のデータ取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/06)<BR>
 * </P>
 * @author
 */
public class FindBudgetCmd extends Command {


    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindBudgetCondition _condition;

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    @Override
    public void execute() throws UserException {

        FindBudgetResult result = new FindBudgetResult();
        CostManager manager = CostManager.getInstance();
        result = manager.findBudget(_condition);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition FindBudgetCondition 検索条件
     */
    public void setFindBudgetCondition(FindBudgetCondition condition) {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return FindBudgetResult 結果
     */
    public FindBudgetResult  getFindBudgetResult() {
        return (FindBudgetResult) super.getResult().get(RESULT_KEY);
    }

}
