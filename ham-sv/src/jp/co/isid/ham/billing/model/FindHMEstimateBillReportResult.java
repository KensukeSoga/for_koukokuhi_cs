package jp.co.isid.ham.billing.model;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * HM���Ϗ��E�������쐬��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMEstimateBillReportResult extends AbstractServiceResult {

    /** HM���Ϗ��o�͏�� */
    private FindHMEstimateReportResult _hmEstimateProduction = null;
    /** HM�������o�͏�� */
    private FindHMBillReportResult _hmBillProduction = null;

    /**
     * HM���Ϗ��o�͏����擾����
     * @return FindHMEstimateReportResult HM���Ϗ��o�͏��
     */
    public FindHMEstimateReportResult getHMEstimateProduction() {
        return _hmEstimateProduction;
    }

    /**
     * HM���Ϗ��o�͏���ݒ肷��
     * @param result FindHMEstimateReportResult HM���Ϗ��o�͏��
     */
    public void setHMEstimateProduction(FindHMEstimateReportResult result) {
        _hmEstimateProduction = result;
    }

    /**
     * HM�������o�͏����擾����
     * @return FindHMBillReportResult HM�������o�͏��
     */
    public FindHMBillReportResult getHMBillProduction() {
        return _hmBillProduction;
    }

    /**
     * HM���Ϗ�(���ϖ���)��ݒ肷��
     * @param result FindHMBillReportResult HM�������o�͏��
     */
    public void setHMBillProduction(FindHMBillReportResult result) {
        _hmBillProduction = result;
    }

}
