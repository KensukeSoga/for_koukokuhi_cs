package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindRdProgramCondition;
import jp.co.isid.ham.media.model.FindRdProgramManager;
import jp.co.isid.ham.media.model.FindRdProgramResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * ラジオ番組画面検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdProgramCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索条件 */
    private FindRdProgramCondition _condition = null;
    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /**
     * 検索条件を使用し検索処理を実行します
     * throws HAMException 検索失敗時
     */
    @Override
    public void execute() throws HAMException {
        FindRdProgramManager manager = FindRdProgramManager.getInstance();
        FindRdProgramResult result = manager.findRdProgram(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     * @param condition FindRdProgramCondition 検索条件
     */
    public void setFindRdProgramCondition(FindRdProgramCondition condition) {
        _condition = condition;
    }

    /**
     * 検索結果を返します
     * @return FindRdProgramResult 条件検索結果
     */
    public FindRdProgramResult getFindRdProgramResult() {
        return (FindRdProgramResult) super.getResult().get(RESULT_KEY);
    }

}
