package jp.co.isid.ham.billing.model;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HM見積書・請求書作成検索結果
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMEstimateBillReportResult extends AbstractServiceResult {

    /** HM見積書出力情報 */
    private FindHMEstimateReportResult _hmEstimateProduction = null;
    /** HM請求書出力情報 */
    private FindHMBillReportResult _hmBillProduction = null;

    /**
     * HM見積書出力情報を取得する
     * @return FindHMEstimateReportResult HM見積書出力情報
     */
    public FindHMEstimateReportResult getHMEstimateProduction() {
        return _hmEstimateProduction;
    }

    /**
     * HM見積書出力情報を設定する
     * @param result FindHMEstimateReportResult HM見積書出力情報
     */
    public void setHMEstimateProduction(FindHMEstimateReportResult result) {
        _hmEstimateProduction = result;
    }

    /**
     * HM請求書出力情報を取得する
     * @return FindHMBillReportResult HM請求書出力情報
     */
    public FindHMBillReportResult getHMBillProduction() {
        return _hmBillProduction;
    }

    /**
     * HM見積書(見積明細)を設定する
     * @param result FindHMBillReportResult HM請求書出力情報
     */
    public void setHMBillProduction(FindHMBillReportResult result) {
        _hmBillProduction = result;
    }

}
