package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.media.model.*;

public class FindAccountBookLogCmd extends Command{


    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindAccountBookLogCondition _condition;

    /**
     * �����������g�p���A �c�ƍ�Ƒ䒠�f�[�^�������������s���܂�
     *
     * @throws HAMException
     *             �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws HAMException {
        FindAccountBookLogManager manager = FindAccountBookLogManager.getInstance();
        FindAccountBookLogResult result = manager.findAccountBookLog(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition
     *            AccountBook ��������
     */
    public void setAccountBookLogCondition(FindAccountBookLogCondition condition) {
        _condition = condition;
    }

    /**
     * �c�ƍ�Ƒ䒠�������ʂ�Ԃ��܂�
     *
     * @return FindAuthorityAccountBookResult ������������
     */
    public FindAccountBookLogResult getAccountBookLogResult() {
        return (FindAccountBookLogResult) super.getResult().get(RESULT_KEY);
    }
}
