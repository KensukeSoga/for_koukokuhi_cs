package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CostManager;
import jp.co.isid.ham.production.model.FindChangeNoticeCondition;
import jp.co.isid.ham.production.model.FindChangeNoticeResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * CR制作費　変更通知データ取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/06/24)<BR>
 * </P>
 * @author
 */
public class FindChangeNoticeDataCmd extends Command {


    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindChangeNoticeCondition _condition;

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    @Override
    public void execute() throws UserException {

        FindChangeNoticeResult result = new FindChangeNoticeResult();
        CostManager manager = CostManager.getInstance();
        result = manager.findFindChangeNoticeData(_condition);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition FindChangeNoticeCondition 検索条件
     */
    public void setFindChangeNoticeCondition(FindChangeNoticeCondition condition) {
        _condition = condition;
    }

    /**
     * 結果を返します
     *
     * @return FindChangeNoticeResult 結果
     */
    public FindChangeNoticeResult  getFindChangeNoticeResult() {
        return (FindChangeNoticeResult) super.getResult().get(RESULT_KEY);
    }

}
