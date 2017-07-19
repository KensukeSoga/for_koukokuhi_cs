package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.media.model.*;

/**
 * <P>
 * �L�����y�[���ꗗ�f�[�^�����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/30 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
public class FindInputRejectionCmd extends Command {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindInputRejectionCondition _condition;

    /**
     * �����������g�p���A ���͋��ۃf�[�^�������������s���܂�
     *
     * @throws HAMException
     *             �����Ɏ��s�����ꍇ
     */
    public void execute() throws HAMException {
        FindInputRejectionManager manager = FindInputRejectionManager.getInstance();
        FindInputRejectionResult result = manager.findInputRejection(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition
     *            CampaignList ��������
     */
    public void setInputRejectionCondition(FindInputRejectionCondition condition) {
        _condition = condition;
    }

    /**
     * �L�����y�[���ꗗ�������ʂ�Ԃ��܂�
     *
     * @return FindCampaignListResult ������������
     */
    public FindInputRejectionResult getFindInputRejectionResult() {
        return (FindInputRejectionResult) super.getResult().get(RESULT_KEY);
    }
}
