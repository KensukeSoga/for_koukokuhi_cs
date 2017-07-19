package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindCostManagementReportManager;
import jp.co.isid.ham.billing.model.FindDispCostManagementReportCondition;
import jp.co.isid.ham.billing.model.FindDispCostManagementReportResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * コスト管理表機能制御取得データ検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/11 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindDispCostManagementReportCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    FindDispCostManagementReportCondition _cond;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {
        FindCostManagementReportManager manager = FindCostManagementReportManager.getInstance();
        FindDispCostManagementReportResult result = manager.ｆindDispCostManagementReport(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param cond 検索条件
     */
    public void setCostManagementReportCondition(FindDispCostManagementReportCondition cond) {
        _cond = cond;
    }

    /**
     * 検索結果を返します
     *
     * @return 検索結果
     */
    public FindDispCostManagementReportResult getCostManagementReportResult() {
        return (FindDispCostManagementReportResult)super.getResult().get(RESULT_KEY);
    }
}