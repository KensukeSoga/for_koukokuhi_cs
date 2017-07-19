package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.media.model.*;

/**
 * <P>
 * �}�̏󋵊Ǘ��X�V�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/17 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
public class MepiaPlanRegisterByCampDetailsCmd extends Command {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private MediaPlanRegisterCondition _condition;

    /**
     * �����������g�p���A �L�����y�[���ꗗ�f�[�^�������������s���܂�
     *
     * @throws HAMException
     *             �����Ɏ��s�����ꍇ
     */
    public void execute() throws HAMException {
        MediaPlanRegisterByCampDetailsManager manager = MediaPlanRegisterByCampDetailsManager.getInstance();
        manager.MediaPlanRegister(_condition);
        getResult().set(RESULT_KEY, new MediaPlanRegisterResult());
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition
     *            CampaignRegisterDetailsCondition ��������
     */
    public void setMepiaPlanRegisterResult(MediaPlanRegisterCondition condition) {
        _condition = condition;
    }

    /**
     * �}�̏󋵊Ǘ����ʂ�Ԃ��܂�
     *
     * @return CampaignRegisterResult ������������
     */
    public MediaPlanRegisterResult getMepiaPlanRegisterResult() {
        return (MediaPlanRegisterResult) super.getResult().get(RESULT_KEY);
    }
}
