package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindJasracRadioTimeCondition;
import jp.co.isid.ham.billing.model.FindJasracRadioTimeManager;
import jp.co.isid.ham.billing.model.FindJasracRadioTimeResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * JASRAC申請書(ラジオタイム)検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/11/18 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindJasracRadioTimeCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindJasracRadioTimeCondition _cond = null;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {

        FindJasracRadioTimeManager manager = FindJasracRadioTimeManager.getInstance();
        FindJasracRadioTimeResult result = manager.findJasracRadioTimeOutputInfo(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param cond 検索条件
     */
    public void setFindJasracRadioTimeCondition(FindJasracRadioTimeCondition cond) {
        _cond = cond;
    }

    /**
     * 検索結果を返します
     *
     * @return 検索結果
     */
    public FindJasracRadioTimeResult getFindJasracRadioTimeResult() {
        return (FindJasracRadioTimeResult)super.getResult().get(RESULT_KEY);
    }

}
