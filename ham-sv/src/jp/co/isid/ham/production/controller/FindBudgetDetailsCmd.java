package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CostManager;
import jp.co.isid.ham.production.model.FindBudgetDetailsCondition;
import jp.co.isid.ham.production.model.FindBudgetDetailsResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;
/**
 * <P>
 * �Ԏ�ʗ\�Z(�ڍ�)��ʁ@�\���f�[�^�擾���s���̃f�[�^�擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/06)<BR>
 * </P>
 * @author
 */
public class FindBudgetDetailsCmd extends Command {


    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindBudgetDetailsCondition _condition;

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

	@Override
	public void execute() throws UserException {

	    FindBudgetDetailsResult result = new FindBudgetDetailsResult();
		CostManager manager = CostManager.getInstance();
		result = manager.findBudgetDetails(_condition);

        getResult().set(RESULT_KEY, result);
	}

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition FindBudgetDetailsCondition ��������
     */
	public void setFindBudgetDetailsCondition(FindBudgetDetailsCondition condition) {
        _condition = condition;
	}

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return FindBudgetDetailsResult ����
     */
	public FindBudgetDetailsResult  getFindBudgetDetailsResult() {
        return (FindBudgetDetailsResult) super.getResult().get(RESULT_KEY);
	}

}
