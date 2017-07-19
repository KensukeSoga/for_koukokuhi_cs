package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.common.model.Tbj02EigyoDaichoCondition;
import jp.co.isid.ham.media.model.FindGrossSumManager;
import jp.co.isid.ham.media.model.FindGrossSumResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * Excel取込みエラー画面検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/02/05 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindGrossSumCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private Tbj02EigyoDaichoCondition _condition;

    /**
     * 検索条件で検索を実施
     */
    @Override
    public void execute() throws HAMException {
        FindGrossSumManager manager = FindGrossSumManager.getInstance();
        FindGrossSumResult result = manager.findGrossSum(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setTbj02EigyoDaichoCondition(Tbj02EigyoDaichoCondition condition) {
        _condition = condition;
    }

    /**
     * 検索結果を返します
     *
     * @return FindGrossSumResult 条件検索結果
     */
    public FindGrossSumResult getFindGrossSumResult() {
        return (FindGrossSumResult) super.getResult().get(RESULT_KEY);
    }


}
