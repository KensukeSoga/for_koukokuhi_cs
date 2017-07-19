package jp.co.isid.ham.common.controller;

import jp.co.isid.ham.common.model.FindMbj02UserManager;
import jp.co.isid.ham.common.model.FindMbj02UserResult;
import jp.co.isid.ham.common.model.Mbj02UserCondition;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 担当者マスタ検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/07/25 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindMbj02UserCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    Mbj02UserCondition _condition = null;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {
        FindMbj02UserManager manager = FindMbj02UserManager.getInstance();
        FindMbj02UserResult result = manager.findMbj02User(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setMbj02UserCondition(Mbj02UserCondition condition) {
        _condition = condition;
    }

    /**
     * 検索結果を返します
     *
     * @return FindMbj02UserResult 条件検索結果
     */
    public FindMbj02UserResult getFindMbj02UserResult() {
        return (FindMbj02UserResult) super.getResult().get(RESULT_KEY);
    }
}
