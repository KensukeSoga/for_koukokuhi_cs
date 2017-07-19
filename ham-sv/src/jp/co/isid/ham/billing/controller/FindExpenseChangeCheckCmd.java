package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindExpenseChangeCheckCondition;
import jp.co.isid.ham.billing.model.FindExpenseChangeCheckManager;
import jp.co.isid.ham.billing.model.FindExpenseChangeCheckResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

public class FindExpenseChangeCheckCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    FindExpenseChangeCheckCondition _cond;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {
        FindExpenseChangeCheckManager manager = FindExpenseChangeCheckManager.getInstance();
        FindExpenseChangeCheckResult result = manager.findProductionChangeCheck(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param cond 検索条件
     */
    public void setEsxpenseChangeCheckCondition(FindExpenseChangeCheckCondition cond) {
        _cond = cond;
    }

    /**
     * 検索結果を返します
     *
     * @return 検索結果
     */
    public FindExpenseChangeCheckResult getExpenseChangeCheckResult() {
        return (FindExpenseChangeCheckResult)super.getResult().get(RESULT_KEY);
    }

}
