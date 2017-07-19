package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CheckListManager;
import jp.co.isid.ham.production.model.FindCheckListTantoCondition;
import jp.co.isid.ham.production.model.FindCheckListTantoResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �Ԏ�ʗ\�Z��ʁ@�\���f�[�^�擾���s���̃f�[�^�擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/06)<BR>
 * </P>
 * @author
 */
public class FindCheckListTantoCmd extends Command {


    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindCheckListTantoCondition _condition;

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    @Override
    public void execute() throws UserException {

        FindCheckListTantoResult result = new FindCheckListTantoResult();
        CheckListManager manager = CheckListManager.getInstance();
        result = manager.findCheckListTanto(_condition);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition FindCheckListTantoCondition ��������
     */
    public void setFindCheckListTantoCondition(FindCheckListTantoCondition condition) {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return FindCheckListTantoResult ����
     */
    public FindCheckListTantoResult  getFindCheckListTantoResult() {
        return (FindCheckListTantoResult) super.getResult().get(RESULT_KEY);
    }

}
