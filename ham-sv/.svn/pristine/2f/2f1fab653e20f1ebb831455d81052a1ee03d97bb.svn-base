package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindHCMediaCreationCondition;
import jp.co.isid.ham.billing.model.FindHCMediaCreationResult;
import jp.co.isid.ham.billing.model.HCMediaCreationManager;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HC媒体費作成検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/11 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCMediaCreationCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    FindHCMediaCreationCondition _cond;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {
        HCMediaCreationManager manager = HCMediaCreationManager.getInstance();
        FindHCMediaCreationResult result = manager.findHCMediaCreation(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param cond 検索条件
     */
    public void setFindHCMediaCreationCondition(FindHCMediaCreationCondition cond) {
        _cond = cond;
    }

    /**
     * 検索結果を返します
     *
     * @return 検索結果
     */
    public FindHCMediaCreationResult getFindHCMediaCreationResult() {
        return (FindHCMediaCreationResult)super.getResult().get(RESULT_KEY);
    }
}
