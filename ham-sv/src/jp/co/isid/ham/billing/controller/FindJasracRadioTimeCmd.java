package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindJasracRadioTimeCondition;
import jp.co.isid.ham.billing.model.FindJasracRadioTimeManager;
import jp.co.isid.ham.billing.model.FindJasracRadioTimeResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * JASRAC�\����(���W�I�^�C��)�����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/11/18 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindJasracRadioTimeCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindJasracRadioTimeCondition _cond = null;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws UserException {

        FindJasracRadioTimeManager manager = FindJasracRadioTimeManager.getInstance();
        FindJasracRadioTimeResult result = manager.findJasracRadioTimeOutputInfo(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param cond ��������
     */
    public void setFindJasracRadioTimeCondition(FindJasracRadioTimeCondition cond) {
        _cond = cond;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return ��������
     */
    public FindJasracRadioTimeResult getFindJasracRadioTimeResult() {
        return (FindJasracRadioTimeResult)super.getResult().get(RESULT_KEY);
    }

}
