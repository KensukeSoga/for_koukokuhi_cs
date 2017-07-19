package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindRdAllocationPictureCondition;
import jp.co.isid.ham.media.model.FindRdAllocationPictureManager;
import jp.co.isid.ham.media.model.FindRdAllocationPictureResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * ���W�I��AllocationPicture�o�͏�񌟍��R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/11/20 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdAllocationPictureCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������� */
    private FindRdAllocationPictureCondition _condition = null;
    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /**
     * �����������g�p���������������s���܂�
     * throws HAMException �������s��
     */
    @Override
    public void execute() throws HAMException {
        FindRdAllocationPictureManager manager = FindRdAllocationPictureManager.getInstance();
        FindRdAllocationPictureResult result = manager.findRdAllocationPicture(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     * @param condition FindRdAllocationPictureCondition ��������
     */
    public void setFindRdAllocationPictureCondition(FindRdAllocationPictureCondition condition) {
        _condition = condition;
    }

    /**
     * �������ʂ�Ԃ��܂�
     * @return FindRdAllocationPictureResult ������������
     */
    public FindRdAllocationPictureResult getFindRdAllocationPictureResult() {
        return (FindRdAllocationPictureResult) super.getResult().get(RESULT_KEY);
    }

}
