package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindHCProductCondition;
import jp.co.isid.ham.billing.model.FindHCProductResult;
import jp.co.isid.ham.billing.model.FindMstrHCProductManager;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HC���i�}�X�^�����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/2/25 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCProductCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    FindHCProductCondition _cond;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws UserException {
        FindMstrHCProductManager manager = FindMstrHCProductManager.getInstance();
        FindHCProductResult result = manager.findHCProduct(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param cond ��������
     */
    public void setFindHCProductCondition(FindHCProductCondition cond) {
        _cond = cond;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return ��������
     */
    public FindHCProductResult getFindHCProductResult() {
        return (FindHCProductResult)super.getResult().get(RESULT_KEY);
    }
}
