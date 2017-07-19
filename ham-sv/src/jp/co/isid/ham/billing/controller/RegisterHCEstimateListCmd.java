package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.HCEstimateListManager;
import jp.co.isid.ham.billing.model.RegisterHCEstimateListResult;
import jp.co.isid.ham.billing.model.RegisterHCEstimateListVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HC���ψꗗ�o�^�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/2/13 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class RegisterHCEstimateListCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    RegisterHCEstimateListVO _vo;

    /**
     * HC���ϓo�^�������s
     */
    @Override
    public void execute() throws UserException {
        HCEstimateListManager manager = HCEstimateListManager.getInstance();
        RegisterHCEstimateListResult result = manager.registerHCEstimateList(_vo);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * �o�^�f�[�^��ݒ肵�܂�
     *
     * @param vo �o�^�f�[�^
     */
    public void setRegisterHCEstimateListVO(RegisterHCEstimateListVO vo) {
        _vo = vo;
    }

    /**
     * �o�^���ʂ��擾���܂�
     *
     * @return �o�^����
     */
    public RegisterHCEstimateListResult getRegisterHCEstimateListResult() {
        return (RegisterHCEstimateListResult) super.getResult().get(RESULT_KEY);
    }

}
