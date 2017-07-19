package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindExcelInputErrorCondition;
import jp.co.isid.ham.media.model.FindExcelInputErrorManager;
import jp.co.isid.ham.media.model.FindExcelInputErrorResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * Excel�捞�݃G���[��ʌ����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/01/28 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindExcelInputErrorCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindExcelInputErrorCondition _condition;

    /**
     * �����������g�p���A�������������s���܂�
     *
     * @throws HAMException
     *             �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws HAMException {
        FindExcelInputErrorManager manager = FindExcelInputErrorManager.getInstance();
        FindExcelInputErrorResult result = manager.findExcelInputError(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindExcelInputErrorCondition(FindExcelInputErrorCondition condition) {
        _condition = condition;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return FindExcelInputErrorResult ������������
     */
    public FindExcelInputErrorResult getFindExcelInputErrorResult() {
        return (FindExcelInputErrorResult) super.getResult().get(RESULT_KEY);
    }
}
