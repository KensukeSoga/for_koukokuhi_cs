package jp.co.isid.ham.common.controller;

import jp.co.isid.ham.common.model.Tbj30DisplayPatternCondition;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternManager;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 一覧表示パターンPK検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/11 K.Fukuda)<BR>
 * </P>
 * @author K.Fukuda
 */
public class FindTbj30DisplayPatternCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private Tbj30DisplayPatternCondition _condition;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {
        Tbj30DisplayPatternManager manager = Tbj30DisplayPatternManager.getInstance();
        Tbj30DisplayPatternResult result = manager.findTbj30DisplayPattern(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition 検索条件
     */
    public void setTbj30DisplayPatternCondition(Tbj30DisplayPatternCondition condition) {
        _condition = condition;
    }

    /**
     * 検索結果を返します
     *
     * @return Tbj30DisplayPatternResult 条件検索結果
     */
    public Tbj30DisplayPatternResult getTbj30DisplayPatternResult() {
        return (Tbj30DisplayPatternResult) super.getResult().get(RESULT_KEY);
    }

}
