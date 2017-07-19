package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindHMEstimateBillReportCondition;
import jp.co.isid.ham.billing.model.FindHMEstimateBillReportResult;
import jp.co.isid.ham.billing.model.HCEstimateCreationManager;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HM���Ϗ��E�������쐬�����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMEstimateBillReportCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindHMEstimateBillReportCondition _cond;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws UserException {

        FindHMEstimateBillReportResult result = new FindHMEstimateBillReportResult();
        HCEstimateCreationManager manager = HCEstimateCreationManager.getInstance();

        //���Ϗ�
        if (_cond.getEstimateOutput().equals(HAMConstants.REPORT_OUTPUT)) {
            result.setHMEstimateProduction(manager.findHMEstimateReport(_cond.getHMEstimateCondition()));
        }
        //������
        if (_cond.getBillOutput().equals(HAMConstants.REPORT_OUTPUT)) {
            result.setHMBillProduction(manager.findHMBillReport(_cond.getHMBillCondition()));
        }

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param cond ��������
     */
    public void setFindHMEstimateBillReportCondition(FindHMEstimateBillReportCondition cond) {
        _cond = cond;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return ��������
     */
    public FindHMEstimateBillReportResult getFindHMEstimateBillReportResult() {
        return (FindHMEstimateBillReportResult)super.getResult().get(RESULT_KEY);
    }

}
