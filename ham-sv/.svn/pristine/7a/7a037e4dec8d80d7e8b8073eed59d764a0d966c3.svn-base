package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindHMEstimateBillMediaReportCondition;
import jp.co.isid.ham.billing.model.FindHMEstimateBillMediaReportResult;
import jp.co.isid.ham.billing.model.HCMediaCreationManager;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HM見積書、請求明細書、請求書作成(媒体)検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * ・請求業務変更対応(2016/02/04 HLC K.Oki)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMEstimateBillMediaReportCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    FindHMEstimateBillMediaReportCondition _cond = null;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {

        FindHMEstimateBillMediaReportResult result = new FindHMEstimateBillMediaReportResult();
        HCMediaCreationManager _manager = HCMediaCreationManager.getInstance();

        //見積書・請求明細書
        if (_cond.getEstimateOutput().equals(HAMConstants.REPORT_OUTPUT) ||
                _cond.getBillDetailOutput().equals(HAMConstants.REPORT_OUTPUT)) {
            /* 2016/02/04 請求業務変更対応 HLC K.Oki MOD Start */
            //result.setHMEstimateMedia(_manager.findHMEstimateMediaReport(_cond.getEstimateCondition()));

            result.setHMEstimateMedia(_manager.findHMEstimateMediaReport(_cond.getEstimateCondition(), _cond.getBillDetailOutput()));
            /* 2016/02/04 請求業務変更対応 HLC K.Oki MOD End */

        }
        //請求書
        if (_cond.getBillOutput().equals(HAMConstants.REPORT_OUTPUT)) {
            result.setHMBillMedia(_manager.findHMBillMediaReport(_cond.getBillCondition()));
        }

        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定する
     * @param cond setFindHMEstimateBillMediaReportCondition 検索条件
     */
    public void setFindHMEstimateBillMediaReportCondition(FindHMEstimateBillMediaReportCondition cond) {
        _cond = cond;
    }

    /**
     * 検索結果を取得する
     * @return FindHMEstimateBillMediaReportResult 検索結果
     */
    public FindHMEstimateBillMediaReportResult getFindHMEstimateBillMediaReportResult() {
        return (FindHMEstimateBillMediaReportResult)super.getResult().get(RESULT_KEY);
    }

}
