package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindHCEstimateCreationCondition;
import jp.co.isid.ham.billing.model.FindHCEstimateCreationResult;
import jp.co.isid.ham.billing.model.HCEstimateCreationManager;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HC���ύ쐬�����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/2/14 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCEstimateCreationCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    FindHCEstimateCreationCondition _cond;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws UserException {
        HCEstimateCreationManager manager = HCEstimateCreationManager.getInstance();
        FindHCEstimateCreationResult result = manager.findHCEstimateCreation(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param cond ��������
     */
    public void setFindHCEstimateCreationCondition(FindHCEstimateCreationCondition cond) {
        _cond = cond;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return ��������
     */
    public FindHCEstimateCreationResult getFindHCEstimateCreationResult() {
        return (FindHCEstimateCreationResult) super.getResult().get(RESULT_KEY);
    }

}
