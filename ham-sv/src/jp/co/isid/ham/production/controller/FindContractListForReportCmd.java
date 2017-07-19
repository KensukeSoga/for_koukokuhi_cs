package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.Contract4ReportCondition;
import jp.co.isid.ham.production.model.Contract4ReportManager;
import jp.co.isid.ham.production.model.Contract4ReportResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.controller.command.CommandResult;
import jp.co.isid.nj.exp.UserException;

/**
 * タレント・ナレーター・楽曲契約表コマンドクラス
 *
 * @author Takahiro Hadate
 *
 */
public class FindContractListForReportCmd extends Command {

    /**
     *
     */
    private static final long serialVersionUID = 2627251746837787184L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private Contract4ReportCondition _condition;


    /**
     * {@inheritDoc}
     */
    @Override
    public void execute() throws UserException {
        Contract4ReportManager manager = Contract4ReportManager.getInstance();
        Contract4ReportResult result = manager.findReport(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定する.
     * @param condition 検索条件
     */
    public void setCondition(Contract4ReportCondition condition) {
        this._condition = condition;
    }

    /**
     * 結果を取得する.
     *
     * @return 検索結果
     */
    public Contract4ReportResult getReportResult() {
        CommandResult result = super.getResult();
        return (result != null) ? (Contract4ReportResult) result.get(RESULT_KEY) : null;
    }

}
