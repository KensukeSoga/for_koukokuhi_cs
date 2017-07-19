package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindRdProgramRegisterCondition;
import jp.co.isid.ham.media.model.FindRdProgramRegisterManager;
import jp.co.isid.ham.media.model.FindRdProgramRegisterResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * ���W�I�ԑg�o�^��ʌ����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdProgramRegisterCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������� */
    private FindRdProgramRegisterCondition _condition = null;
    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /**
     * �����������g�p���������������s���܂�
     * throws HAMException �������s��
     */
    @Override
    public void execute() throws HAMException {
        FindRdProgramRegisterManager manager = FindRdProgramRegisterManager.getInstance();
        FindRdProgramRegisterResult result = manager.findRdProgramRegister(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     * @param condition FindRdProgramRegisterCondition ��������
     */
    public void setFindRdProgramRegisterCondition(FindRdProgramRegisterCondition condition) {
        _condition = condition;
    }

    /**
     * �������ʂ�Ԃ��܂�
     * @return FindRdProgramRegisterResult ������������
     */
    public FindRdProgramRegisterResult getFindRdProgramResult() {
        return (FindRdProgramRegisterResult) super.getResult().get(RESULT_KEY);
    }

}
