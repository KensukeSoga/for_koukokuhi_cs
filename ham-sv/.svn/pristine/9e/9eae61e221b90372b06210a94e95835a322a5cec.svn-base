package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindRdStationSelectCondition;
import jp.co.isid.ham.media.model.FindRdStationSelectManager;
import jp.co.isid.ham.media.model.FindRdStationSelectResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * ラジオ局選択選択画面検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdStationSelectCmd extends Command {

    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindRdStationSelectCondition _condition = null;

    /**
     * 検索条件を使用し、検索処理を実行します
     *
     * @throws HAMException
     *             検索に失敗した場合
     */
    @Override
    public void execute() throws HAMException {
        FindRdStationSelectManager manager = FindRdStationSelectManager.getInstance();
        FindRdStationSelectResult result = manager.findMediaPlanSelect(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を取得する
     * @param condition FindRdStationSelectCondition 検索条件
     */
    public void setFindRdStationSelectCondition(FindRdStationSelectCondition condition) {
        _condition = condition;
    }

    /**
     * 検索結果を設定する
     * @return FindRdStationSelectResult 検索結果
     */
    public FindRdStationSelectResult getFindRdStationSelectResult() {
        return (FindRdStationSelectResult) super.getResult().get(RESULT_KEY);
    }

}
