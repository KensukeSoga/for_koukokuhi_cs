package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindExcelInputErrorCondition;
import jp.co.isid.ham.media.model.FindExcelInputErrorManager;
import jp.co.isid.ham.media.model.FindExcelInputErrorResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * Excel取込みエラー画面検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/28 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindExcelInputErrorCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindExcelInputErrorCondition _condition;

    /**
     * 検索条件を使用し、検索処理を実行します
     *
     * @throws HAMException
     *             検索に失敗した場合
     */
    @Override
    public void execute() throws HAMException {
        FindExcelInputErrorManager manager = FindExcelInputErrorManager.getInstance();
        FindExcelInputErrorResult result = manager.findExcelInputError(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setFindExcelInputErrorCondition(FindExcelInputErrorCondition condition) {
        _condition = condition;
    }

    /**
     * 検索結果を返します
     *
     * @return FindExcelInputErrorResult 条件検索結果
     */
    public FindExcelInputErrorResult getFindExcelInputErrorResult() {
        return (FindExcelInputErrorResult) super.getResult().get(RESULT_KEY);
    }
}
