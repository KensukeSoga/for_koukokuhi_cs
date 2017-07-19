package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindRdProgramRegisterCondition;
import jp.co.isid.ham.media.model.FindRdProgramRegisterManager;
import jp.co.isid.ham.media.model.FindRdProgramRegisterResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * ラジオ番組登録画面検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdProgramRegisterCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索条件 */
    private FindRdProgramRegisterCondition _condition = null;
    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /**
     * 検索条件を使用し検索処理を実行します
     * throws HAMException 検索失敗時
     */
    @Override
    public void execute() throws HAMException {
        FindRdProgramRegisterManager manager = FindRdProgramRegisterManager.getInstance();
        FindRdProgramRegisterResult result = manager.findRdProgramRegister(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     * @param condition FindRdProgramRegisterCondition 検索条件
     */
    public void setFindRdProgramRegisterCondition(FindRdProgramRegisterCondition condition) {
        _condition = condition;
    }

    /**
     * 検索結果を返します
     * @return FindRdProgramRegisterResult 条件検索結果
     */
    public FindRdProgramRegisterResult getFindRdProgramResult() {
        return (FindRdProgramRegisterResult) super.getResult().get(RESULT_KEY);
    }

}
