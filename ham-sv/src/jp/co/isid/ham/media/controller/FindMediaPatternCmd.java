package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindMediaPatternCondition;
import jp.co.isid.ham.media.model.FindMediaPatternManager;
import jp.co.isid.ham.media.model.FindMediaPatternResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �}�̃p�^�[�������R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/03 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindMediaPatternCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMediaPatternCondition _condition;


    /**
     * �������s
     */
    @Override
    public void execute() throws UserException {
        FindMediaPatternManager manager = FindMediaPatternManager.getInstance();
        FindMediaPatternResult result = manager.findMediaPattern(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ�
     * @param cond
     */
    public void setFindMediaPatternCondition(FindMediaPatternCondition cond) {
        _condition = cond;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return FindMediaPatternResult ������������
     */
    public FindMediaPatternResult getMediaPatternResult() {
        return (FindMediaPatternResult) super.getResult().get(RESULT_KEY);
    }

}
