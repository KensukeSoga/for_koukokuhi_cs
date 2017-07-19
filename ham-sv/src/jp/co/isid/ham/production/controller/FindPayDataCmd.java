package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CostManager;
import jp.co.isid.ham.production.model.FindPayDataCondition;
import jp.co.isid.ham.production.model.FindPayDataResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 支払先一覧検索実行時のデータ取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/06)<BR>
 * </P>
 * @author
 */
public class FindPayDataCmd extends Command {


    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindPayDataCondition _condition;

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    @Override
    public void execute() throws UserException {

        FindPayDataResult result = new FindPayDataResult();
        CostManager manager = CostManager.getInstance();
        result = manager.findPayData(_condition);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition FindPayDataCondition 検索条件
     */
    public void setFindPayDataCondition(FindPayDataCondition condition) {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return FindPayDataResult 結果
     */
    public FindPayDataResult  getFindPayDataResult() {
        return (FindPayDataResult) super.getResult().get(RESULT_KEY);
    }

}
