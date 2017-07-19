package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.media.model.*;

/**
 * <P>
 * キャンペーン一覧データ検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/30 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
public class FindInputRejectionCmd extends Command {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindInputRejectionCondition _condition;

    /**
     * 検索条件を使用し、 入力拒否データ検索処理を実行します
     *
     * @throws HAMException
     *             検索に失敗した場合
     */
    public void execute() throws HAMException {
        FindInputRejectionManager manager = FindInputRejectionManager.getInstance();
        FindInputRejectionResult result = manager.findInputRejection(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition
     *            CampaignList 検索条件
     */
    public void setInputRejectionCondition(FindInputRejectionCondition condition) {
        _condition = condition;
    }

    /**
     * キャンペーン一覧検索結果を返します
     *
     * @return FindCampaignListResult 条件検索結果
     */
    public FindInputRejectionResult getFindInputRejectionResult() {
        return (FindInputRejectionResult) super.getResult().get(RESULT_KEY);
    }
}
