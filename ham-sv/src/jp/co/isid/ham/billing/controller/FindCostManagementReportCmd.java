package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindCostManagementReportCondition;
import jp.co.isid.ham.billing.model.FindCostManagementReportManager;
import jp.co.isid.ham.billing.model.FindCostManagementReportResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * コスト管理表出力データ検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/11 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindCostManagementReportCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    FindCostManagementReportCondition _cond;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {
        FindCostManagementReportManager manager = FindCostManagementReportManager.getInstance();
        FindCostManagementReportResult result = manager.ｆindCostManagementReport(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param cond 検索条件
     */
    public void setCostManagementReportCondition(FindCostManagementReportCondition cond) {
        _cond = cond;
    }

    /**
     * 検索結果を返します
     *
     * @return 検索結果
     */
    public FindCostManagementReportResult getCostManagementReportResult() {
        return (FindCostManagementReportResult)super.getResult().get(RESULT_KEY);
    }

}
