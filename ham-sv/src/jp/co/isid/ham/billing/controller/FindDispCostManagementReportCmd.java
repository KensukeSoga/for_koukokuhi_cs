package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindCostManagementReportManager;
import jp.co.isid.ham.billing.model.FindDispCostManagementReportCondition;
import jp.co.isid.ham.billing.model.FindDispCostManagementReportResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �R�X�g�Ǘ��\�@�\����擾�f�[�^�����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/3/11 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindDispCostManagementReportCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    FindDispCostManagementReportCondition _cond;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws UserException {
        FindCostManagementReportManager manager = FindCostManagementReportManager.getInstance();
        FindDispCostManagementReportResult result = manager.��indDispCostManagementReport(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param cond ��������
     */
    public void setCostManagementReportCondition(FindDispCostManagementReportCondition cond) {
        _cond = cond;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return ��������
     */
    public FindDispCostManagementReportResult getCostManagementReportResult() {
        return (FindDispCostManagementReportResult)super.getResult().get(RESULT_KEY);
    }
}