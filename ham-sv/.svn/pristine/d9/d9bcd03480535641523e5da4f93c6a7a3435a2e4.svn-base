package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CheckListManager;
import jp.co.isid.ham.production.model.FindCheckListTantoCondition;
import jp.co.isid.ham.production.model.FindCheckListTantoResult;
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
public class FindCheckListTantoCmd extends Command {


    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindCheckListTantoCondition _condition;

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    @Override
    public void execute() throws UserException {

        FindCheckListTantoResult result = new FindCheckListTantoResult();
        CheckListManager manager = CheckListManager.getInstance();
        result = manager.findCheckListTanto(_condition);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition FindCheckListTantoCondition 検索条件
     */
    public void setFindCheckListTantoCondition(FindCheckListTantoCondition condition) {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return FindCheckListTantoResult 結果
     */
    public FindCheckListTantoResult  getFindCheckListTantoResult() {
        return (FindCheckListTantoResult) super.getResult().get(RESULT_KEY);
    }

}
