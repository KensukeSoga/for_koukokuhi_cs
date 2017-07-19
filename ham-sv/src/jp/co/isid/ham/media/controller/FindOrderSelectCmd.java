package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindOrderSelectCondition;
import jp.co.isid.ham.media.model.FindOrderSelectManager;
import jp.co.isid.ham.media.model.FindOrderSelectResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

public class FindOrderSelectCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindOrderSelectCondition _condition;

    /**
     * 検索条件を使用し、 営業作業台帳データ検索処理を実行します
     *
     * @throws HAMException
     *             検索に失敗した場合
     */
    @Override
    public void execute() throws HAMException {
        FindOrderSelectManager manager = FindOrderSelectManager.getInstance();
        FindOrderSelectResult result = manager.findOrderSelect(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition
     *            AccountBook 検索条件
     */
    public void setFindOrderSelectCondition(FindOrderSelectCondition condition) {
        _condition = condition;
    }

    /**
     * 営業作業台帳検索結果を返します
     *
     * @return FindAuthorityAccountBookResult 条件検索結果
     */
    public FindOrderSelectResult getOrderSelectResult() {
        return (FindOrderSelectResult) super.getResult().get(RESULT_KEY);
    }

}
