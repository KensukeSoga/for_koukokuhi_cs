package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindBillGroupManager;
import jp.co.isid.ham.billing.model.FindBillGroupResult;
import jp.co.isid.ham.common.model.Mbj26BillGroupCondition;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * ������O���[�v�����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/3/11 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindBillGroupCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    Mbj26BillGroupCondition _cond;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws UserException {
        FindBillGroupManager manager = FindBillGroupManager.getInstance();
        FindBillGroupResult result = manager.findBillGroup(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param cond ��������
     */
    public void setBillGroupCondition(Mbj26BillGroupCondition cond) {
        _cond = cond;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return ��������
     */
    public FindBillGroupResult getBillGroupResult() {
        return (FindBillGroupResult)super.getResult().get(RESULT_KEY);
    }

}
