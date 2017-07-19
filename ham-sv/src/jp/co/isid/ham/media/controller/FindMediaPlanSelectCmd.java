package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindMediaPlanSelectCondition;
import jp.co.isid.ham.media.model.FindMediaPlanSelectManager;
import jp.co.isid.ham.media.model.FindMediaPlanSelectResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * �}�̏󋵊Ǘ��f�[�^�I����ʌ����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/01/28 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindMediaPlanSelectCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMediaPlanSelectCondition _condition;

    /**
     * �����������g�p���A�������������s���܂�
     *
     * @throws HAMException
     *             �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws HAMException {
        FindMediaPlanSelectManager manager = FindMediaPlanSelectManager.getInstance();
        FindMediaPlanSelectResult result = manager.findMediaPlanSelect(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindMediaPlanSelectCondition(FindMediaPlanSelectCondition condition) {
        _condition = condition;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return FindExcelInputErrorResult ������������
     */
    public FindMediaPlanSelectResult getFindMediaPlanSelectResult() {
        return (FindMediaPlanSelectResult) super.getResult().get(RESULT_KEY);
    }
}
