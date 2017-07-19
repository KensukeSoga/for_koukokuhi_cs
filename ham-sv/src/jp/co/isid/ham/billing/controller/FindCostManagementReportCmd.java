package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindCostManagementReportCondition;
import jp.co.isid.ham.billing.model.FindCostManagementReportManager;
import jp.co.isid.ham.billing.model.FindCostManagementReportResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �R�X�g�Ǘ��\�o�̓f�[�^�����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/3/11 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindCostManagementReportCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    FindCostManagementReportCondition _cond;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws UserException {
        FindCostManagementReportManager manager = FindCostManagementReportManager.getInstance();
        FindCostManagementReportResult result = manager.��indCostManagementReport(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param cond ��������
     */
    public void setCostManagementReportCondition(FindCostManagementReportCondition cond) {
        _cond = cond;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return ��������
     */
    public FindCostManagementReportResult getCostManagementReportResult() {
        return (FindCostManagementReportResult)super.getResult().get(RESULT_KEY);
    }

}
