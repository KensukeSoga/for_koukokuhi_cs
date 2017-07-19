package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindHMBillDataCondition;
import jp.co.isid.ham.billing.model.FindHMBillDataResult;
import jp.co.isid.ham.billing.model.HCEstimateCreationManager;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HM�����f�[�^�쐬�����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindHMBillDataCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindHMBillDataCondition _cond;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws UserException {

        HCEstimateCreationManager manager = HCEstimateCreationManager.getInstance();
        FindHMBillDataResult result = manager.findHMBillData(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param cond ��������
     */
    public void setFindHMBillDataCondition(FindHMBillDataCondition cond) {
        _cond = cond;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return ��������
     */
    public FindHMBillDataResult getFindHMBillDataResult() {
        return (FindHMBillDataResult)super.getResult().get(RESULT_KEY);
    }

}
