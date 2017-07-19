package jp.co.isid.ham.menu.controller;

import jp.co.isid.ham.menu.model.FindMainMenuCondition;
import jp.co.isid.ham.menu.model.MainMenuManager;
import jp.co.isid.ham.menu.model.FindMainMenuResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * メインメニュー検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/6 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindMainMenuCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMainMenuCondition _condition;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {
        MainMenuManager manager = MainMenuManager.getInstance();
        FindMainMenuResult result = manager.findMainMenu(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setMainMenuCondition(FindMainMenuCondition condition) {
        _condition = condition;
    }

    /**
     * 検索結果を返します
     *
     * @return FindMainMenuResult 条件検索結果
     */
    public FindMainMenuResult getMainMenuResult() {
        return (FindMainMenuResult)super.getResult().get(RESULT_KEY);
    }

}
