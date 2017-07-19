package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.media.model.*;

/**
 * <P>
 * �L�����y�[���ڍ׃f�[�^�����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/05 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
public class FindCampaignDetailsHomeLoadCmd extends Command {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindCampaignDetailsCondition _condition;

    /**
     * �����������g�p���A �L�����y�[���ꗗ�f�[�^�������������s���܂�
     *
     * @throws HAMException
     *             �����Ɏ��s�����ꍇ
     */
    public void execute() throws HAMException {
        FindCampaignDetailsHomeLoadManager manager = FindCampaignDetailsHomeLoadManager.getInstance();
        FindCampaignDetailsResult result = manager.findCampgaingDetail(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition
     *            FindCampaignDetailsCondition ��������
     */
    public void setCampaignDetailsCondition(FindCampaignDetailsCondition condition) {
        _condition = condition;
    }

    /**
     * �L�����y�[���ڍ׌������ʂ�Ԃ��܂�
     *
     * @return FindCampaignDetailsResult ������������
     */
    public FindCampaignDetailsResult getCampaignDetailsResult() {
        return (FindCampaignDetailsResult) super.getResult().get(RESULT_KEY);
    }
}
