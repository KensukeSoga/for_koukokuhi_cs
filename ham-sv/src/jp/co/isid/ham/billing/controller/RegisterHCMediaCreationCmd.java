package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.HCMediaCreationManager;
import jp.co.isid.ham.billing.model.RegisterHCMediaCreationResult;
import jp.co.isid.ham.billing.model.RegisterHCMediaCreationVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HC�}�̔�쐬�o�^�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/3/1 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class RegisterHCMediaCreationCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    private RegisterHCMediaCreationVO _vo;

    /**
     * HC�}�̔�쐬�o�^�������s
     */
    @Override
    public void execute() throws UserException {
        HCMediaCreationManager manager = HCMediaCreationManager.getInstance();
        RegisterHCMediaCreationResult result = manager.registerHCMediaCreation(_vo);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * �o�^�f�[�^��ݒ肵�܂�
     *
     * @param vo �o�^�f�[�^
     */
    public void setRegisterHCMediaCreationVO(RegisterHCMediaCreationVO vo) {
        _vo = vo;
    }

    /**
     * �o�^���ʂ��擾���܂�
     *
     * @return �o�^����
     */
    public RegisterHCMediaCreationResult getRegisterHCMediaCreationResult() {
        return (RegisterHCMediaCreationResult) super.getResult().get(RESULT_KEY);
    }
}
