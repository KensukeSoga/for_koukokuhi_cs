package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindEstimateReportCondition;
import jp.co.isid.ham.billing.model.FindEstimateReportResult;
import jp.co.isid.ham.billing.model.HCEstimateCreationManager;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 見積書、見積CSVファイル作成検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/25 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindEstimateReportCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    FindEstimateReportCondition _cond;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {
        HCEstimateCreationManager manager = HCEstimateCreationManager.getInstance();
        FindEstimateReportResult result = manager.findEstimateReport(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param cond 検索条件
     */
    public void setFindEstimateReportCondition(FindEstimateReportCondition cond) {
        _cond = cond;
    }

    /**
     * 検索結果を返します
     *
     * @return 検索結果
     */
    public FindEstimateReportResult getFindEstimateReportResult() {
        return (FindEstimateReportResult)super.getResult().get(RESULT_KEY);
    }

}
