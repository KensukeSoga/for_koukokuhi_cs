package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindEstMediaReportCondition;
import jp.co.isid.ham.billing.model.FindEstMediaReportResult;
import jp.co.isid.ham.billing.model.HCMediaCreationManager;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HC見積書、見積CSVファイル作成(媒体)検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/5/8 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindEstMediaReportCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    FindEstMediaReportCondition _cond = null;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {
        HCMediaCreationManager _manager = HCMediaCreationManager.getInstance();
        FindEstMediaReportResult result = _manager.findEstMediaReport(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定する
     * @param cond FindEstMediaReportCondition 検索条件
     */
    public  void setFindEstMediaReportCondition(FindEstMediaReportCondition cond) {
        _cond = cond;
    }

    /**
     * 検索結果を取得する
     * @return FindEstMediaReportResult 検索結果
     */
    public FindEstMediaReportResult getFindEstMediaReportResult() {
        return (FindEstMediaReportResult)super.getResult().get(RESULT_KEY);
    }

}
