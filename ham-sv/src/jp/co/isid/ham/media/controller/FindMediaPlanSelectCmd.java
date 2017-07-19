package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindMediaPlanSelectCondition;
import jp.co.isid.ham.media.model.FindMediaPlanSelectManager;
import jp.co.isid.ham.media.model.FindMediaPlanSelectResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * 媒体状況管理データ選択画面検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/28 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindMediaPlanSelectCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMediaPlanSelectCondition _condition;

    /**
     * 検索条件を使用し、検索処理を実行します
     *
     * @throws HAMException
     *             検索に失敗した場合
     */
    @Override
    public void execute() throws HAMException {
        FindMediaPlanSelectManager manager = FindMediaPlanSelectManager.getInstance();
        FindMediaPlanSelectResult result = manager.findMediaPlanSelect(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindMediaPlanSelectCondition(FindMediaPlanSelectCondition condition) {
        _condition = condition;
    }

    /**
     * 検索結果を返します
     *
     * @return FindExcelInputErrorResult 条件検索結果
     */
    public FindMediaPlanSelectResult getFindMediaPlanSelectResult() {
        return (FindMediaPlanSelectResult) super.getResult().get(RESULT_KEY);
    }
}
