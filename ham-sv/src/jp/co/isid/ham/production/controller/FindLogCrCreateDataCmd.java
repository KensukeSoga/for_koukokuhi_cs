package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CostManager;
import jp.co.isid.ham.production.model.FindLogCrCreateDataCondition;
import jp.co.isid.ham.production.model.FindLogCrCreateDataResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * CR制作費　更新履歴実行時のデータ取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/06)<BR>
 * </P>
 * @author
 */
public class FindLogCrCreateDataCmd extends Command {


    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindLogCrCreateDataCondition _condition;

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    @Override
    public void execute() throws UserException {

        FindLogCrCreateDataResult result = new FindLogCrCreateDataResult();
        CostManager manager = CostManager.getInstance();
        result = manager.findLogCrCreateData(_condition);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition FindLogCrCreateDataCondition 検索条件
     */
    public void setFindLogCrCreateDataCondition(FindLogCrCreateDataCondition condition) {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return FindLogCrCreateDataResult 結果
     */
    public FindLogCrCreateDataResult  getFindLogCrCreateDataResult() {
        return (FindLogCrCreateDataResult) super.getResult().get(RESULT_KEY);
    }

}
