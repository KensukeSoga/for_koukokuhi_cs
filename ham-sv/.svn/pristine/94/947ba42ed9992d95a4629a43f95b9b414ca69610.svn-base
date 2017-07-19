package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindMediaPatternCondition;
import jp.co.isid.ham.media.model.FindMediaPatternManager;
import jp.co.isid.ham.media.model.FindMediaPatternResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 媒体パターン検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/03 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindMediaPatternCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMediaPatternCondition _condition;


    /**
     * 検索実行
     */
    @Override
    public void execute() throws UserException {
        FindMediaPatternManager manager = FindMediaPatternManager.getInstance();
        FindMediaPatternResult result = manager.findMediaPattern(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定
     * @param cond
     */
    public void setFindMediaPatternCondition(FindMediaPatternCondition cond) {
        _condition = cond;
    }

    /**
     * 検索結果を返します
     *
     * @return FindMediaPatternResult 条件検索結果
     */
    public FindMediaPatternResult getMediaPatternResult() {
        return (FindMediaPatternResult) super.getResult().get(RESULT_KEY);
    }

}
