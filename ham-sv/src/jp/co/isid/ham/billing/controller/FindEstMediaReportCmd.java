package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindEstMediaReportCondition;
import jp.co.isid.ham.billing.model.FindEstMediaReportResult;
import jp.co.isid.ham.billing.model.HCMediaCreationManager;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HC���Ϗ��A����CSV�t�@�C���쐬(�}��)�����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/5/8 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindEstMediaReportCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    FindEstMediaReportCondition _cond = null;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws UserException {
        HCMediaCreationManager _manager = HCMediaCreationManager.getInstance();
        FindEstMediaReportResult result = _manager.findEstMediaReport(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肷��
     * @param cond FindEstMediaReportCondition ��������
     */
    public  void setFindEstMediaReportCondition(FindEstMediaReportCondition cond) {
        _cond = cond;
    }

    /**
     * �������ʂ��擾����
     * @return FindEstMediaReportResult ��������
     */
    public FindEstMediaReportResult getFindEstMediaReportResult() {
        return (FindEstMediaReportResult)super.getResult().get(RESULT_KEY);
    }

}
