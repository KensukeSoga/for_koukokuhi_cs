package jp.co.isid.ham.operationLog.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.operationLog.model.OperationLogManager;
import jp.co.isid.ham.operationLog.model.RegisterOperationLogResult;
import jp.co.isid.ham.operationLog.model.RegisterOperationLogVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �ғ����O�o�^�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/06/06 �VHAM�`�[��)<BR>
 * </P>
 * @author T.Kobayashi
 */
public class RegisterOperationLogCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    RegisterOperationLogVO _vo;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws UserException {
        OperationLogManager manager = OperationLogManager.getInstance();
        RegisterOperationLogResult result = manager.registerOperationLog(_vo);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * �o�^����ݒ肵�܂�
     *
     * @param vo �o�^���
     */
    public void setRegisterOperationLogVO(RegisterOperationLogVO vo) {
        _vo = vo;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return ��������
     */
    public RegisterOperationLogResult getRegisterOperationLogResult() {
        return (RegisterOperationLogResult)super.getResult().get(RESULT_KEY);
    }
}
