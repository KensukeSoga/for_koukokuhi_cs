package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindRdStationSelectCondition;
import jp.co.isid.ham.media.model.FindRdStationSelectManager;
import jp.co.isid.ham.media.model.FindRdStationSelectResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * ���W�I�ǑI��I����ʌ����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdStationSelectCmd extends Command {

    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindRdStationSelectCondition _condition = null;

    /**
     * �����������g�p���A�������������s���܂�
     *
     * @throws HAMException
     *             �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws HAMException {
        FindRdStationSelectManager manager = FindRdStationSelectManager.getInstance();
        FindRdStationSelectResult result = manager.findMediaPlanSelect(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * �����������擾����
     * @param condition FindRdStationSelectCondition ��������
     */
    public void setFindRdStationSelectCondition(FindRdStationSelectCondition condition) {
        _condition = condition;
    }

    /**
     * �������ʂ�ݒ肷��
     * @return FindRdStationSelectResult ��������
     */
    public FindRdStationSelectResult getFindRdStationSelectResult() {
        return (FindRdStationSelectResult) super.getResult().get(RESULT_KEY);
    }

}
