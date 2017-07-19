package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CostManager;
import jp.co.isid.ham.production.model.RegisterThsResult;
import jp.co.isid.ham.production.model.RegisterThsVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;
/**
 * <P>
 * �����挟���@�o�^���s���̃R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/06)<BR>
 * </P>
 * @author
 */
public class RegisterThsCmd extends Command {


    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private RegisterThsVO _vo;

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

	@Override
	public void execute() throws UserException {

	    RegisterThsResult result = new RegisterThsResult();
		CostManager manager = CostManager.getInstance();
		result = manager.RegisterThs(_vo);

        getResult().set(RESULT_KEY, result);
	}

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition RegisterThsVo ��������
     */
	public void setRegisterThsVO(RegisterThsVO vo) {
        _vo = vo;
	}

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return RegisterThsResult ����
     */
	public RegisterThsResult  getRegisterThsResult() {
        return (RegisterThsResult) super.getResult().get(RESULT_KEY);
	}

}
