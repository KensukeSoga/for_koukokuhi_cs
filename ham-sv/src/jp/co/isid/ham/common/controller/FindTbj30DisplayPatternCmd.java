package jp.co.isid.ham.common.controller;

import jp.co.isid.ham.common.model.Tbj30DisplayPatternCondition;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternManager;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �ꗗ�\���p�^�[��PK�����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/11 K.Fukuda)<BR>
 * </P>
 * @author K.Fukuda
 */
public class FindTbj30DisplayPatternCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private Tbj30DisplayPatternCondition _condition;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws UserException {
        Tbj30DisplayPatternManager manager = Tbj30DisplayPatternManager.getInstance();
        Tbj30DisplayPatternResult result = manager.findTbj30DisplayPattern(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setTbj30DisplayPatternCondition(Tbj30DisplayPatternCondition condition) {
        _condition = condition;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return Tbj30DisplayPatternResult ������������
     */
    public Tbj30DisplayPatternResult getTbj30DisplayPatternResult() {
        return (Tbj30DisplayPatternResult) super.getResult().get(RESULT_KEY);
    }

}
