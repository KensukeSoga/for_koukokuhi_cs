package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.common.model.Tbj01MediaPlanCondition;
import jp.co.isid.ham.media.model.FindSumCarManager;
import jp.co.isid.ham.media.model.FindSumCarResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * 車種合計金額データ検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/18 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
public class FindSumCarCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private Tbj01MediaPlanCondition _condition;

    /**
     * 検索条件を使用し、 キャンペーン一覧データ検索処理を実行します
     *
     * @throws HAMException
     *             検索に失敗した場合
     */
    public void execute() throws HAMException {
        FindSumCarManager manager = FindSumCarManager.getInstance();
        FindSumCarResult result = manager.findSumCar(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition
     *            CampaignList 検索条件
     */
    public void setTbj01MediaPlanCondition(Tbj01MediaPlanCondition condition) {
        _condition = condition;
    }

    /**
     * 車種の合計金額結果を返します
     *
     * @return FindCampaignListResult 条件検索結果
     */
    public FindSumCarResult getFindSumCarResult() {
        return (FindSumCarResult) super.getResult().get(RESULT_KEY);
    }
}
