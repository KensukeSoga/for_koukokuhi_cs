package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.ContractRegisterManager;
import jp.co.isid.ham.production.model.FindLogContractInfoCondition;
import jp.co.isid.ham.production.model.FindLogContractInfoResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;
/**
 * <P>
 * �_����o�^�@�X�V�������s���̃f�[�^�擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/15)<BR>
 * </P>
 * @author
 */
public class FindLogContractInfoCmd extends Command {


    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindLogContractInfoCondition _condition;

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

	@Override
	public void execute() throws UserException {

		FindLogContractInfoResult result = new FindLogContractInfoResult();
		ContractRegisterManager manager = ContractRegisterManager.getInstance();
		result = manager.findLogContractInfo(_condition);

        getResult().set(RESULT_KEY, result);
	}

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition FindLogContractInfoCondition ��������
     */
	public void setFindLogContractInfoCondition(FindLogContractInfoCondition condition) {
        _condition = condition;
	}

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return FindLogContractInfoResult ����
     */
	public FindLogContractInfoResult  getFindLogContractInfoResult() {
        return (FindLogContractInfoResult) super.getResult().get(RESULT_KEY);
	}

}
