package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CostManager;
import jp.co.isid.ham.production.model.FindMailInfoCondition;
import jp.co.isid.ham.production.model.FindMailInfoResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 検索実行時のデータ取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/06)<BR>
 * </P>
 * @author
 */
public class FindMailInfoCmd extends Command {


    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMailInfoCondition _condition;

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    @Override
    public void execute() throws UserException {

        FindMailInfoResult result = new FindMailInfoResult();
        CostManager manager = CostManager.getInstance();
        result = manager.findMailInfo(_condition);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition FindMailInfoCondition 検索条件
     */
    public void setFindMailInfoCondition(FindMailInfoCondition condition) {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return FindMailInfoResult 結果
     */
    public FindMailInfoResult  getFindMailInfoResult() {
        return (FindMailInfoResult) super.getResult().get(RESULT_KEY);
    }

}
