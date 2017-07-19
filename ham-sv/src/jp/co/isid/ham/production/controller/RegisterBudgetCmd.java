package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CostManager;
import jp.co.isid.ham.production.model.RegisterBudgetResult;
import jp.co.isid.ham.production.model.RegisterBudgetVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;
/**
 * <P>
 * �Ԏ�ʗ\�Z(�ڍ�)�@�o�^���s���̃R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/06)<BR>
 * </P>
 * @author
 */
public class RegisterBudgetCmd extends Command {


    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private RegisterBudgetVO _vo;

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

	@Override
	public void execute() throws UserException {

	    RegisterBudgetResult result = new RegisterBudgetResult();
		CostManager manager = CostManager.getInstance();
		result = manager.registerBudget(_vo);

        getResult().set(RESULT_KEY, result);
	}

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition RegisterBudgetVo ��������
     */
	public void setRegisterBudgetVO(RegisterBudgetVO vo) {
        _vo = vo;
	}

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return RegisterBudgetResult ����
     */
	public RegisterBudgetResult  getRegisterBudgetResult() {
        return (RegisterBudgetResult) super.getResult().get(RESULT_KEY);
	}

}
