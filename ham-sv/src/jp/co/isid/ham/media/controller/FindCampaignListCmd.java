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
public class FindCampaignListCmd extends Command {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindCampaignListCondition _condition;

    /**
     * �����������g�p���A �L�����y�[���ꗗ�f�[�^�������������s���܂�
     *
     * @throws HAMException
     *             �����Ɏ��s�����ꍇ
     */
    public void execute() throws HAMException {
        FindCampaignListManager manager = FindCampaignListManager.getInstance();
        FindCampaignListResult result = manager.findCampgaingList(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition
     *            CampaignList ��������
     */
    public void setCampaignListCondition(FindCampaignListCondition condition) {
        _condition = condition;
    }

    /**
     * �L�����y�[���ꗗ�������ʂ�Ԃ��܂�
     *
     * @return FindCampaignListResult ������������
     */
    public FindCampaignListResult getCampaignListResult() {
        return (FindCampaignListResult) super.getResult().get(RESULT_KEY);
    }
}
