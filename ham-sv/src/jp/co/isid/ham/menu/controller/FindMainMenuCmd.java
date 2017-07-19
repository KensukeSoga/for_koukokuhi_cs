package jp.co.isid.ham.menu.controller;

import jp.co.isid.ham.menu.model.FindMainMenuCondition;
import jp.co.isid.ham.menu.model.MainMenuManager;
import jp.co.isid.ham.menu.model.FindMainMenuResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * ���C�����j���[�����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/6 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindMainMenuCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMainMenuCondition _condition;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws UserException {
        MainMenuManager manager = MainMenuManager.getInstance();
        FindMainMenuResult result = manager.findMainMenu(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setMainMenuCondition(FindMainMenuCondition condition) {
        _condition = condition;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return FindMainMenuResult ������������
     */
    public FindMainMenuResult getMainMenuResult() {
        return (FindMainMenuResult)super.getResult().get(RESULT_KEY);
    }

}
