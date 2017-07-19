package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.HCMediaCreationManager;
import jp.co.isid.ham.billing.model.RegisterHCMediaCreationResult;
import jp.co.isid.ham.billing.model.RegisterHCMediaCreationVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HC”}‘Ì”ïì¬“o˜^ƒRƒ}ƒ“ƒh
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2013/3/1 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class RegisterHCMediaCreationCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ŒŸõŒ‹‰ÊƒL[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    private RegisterHCMediaCreationVO _vo;

    /**
     * HC”}‘Ì”ïì¬“o˜^ˆ—Às
     */
    @Override
    public void execute() throws UserException {
        HCMediaCreationManager manager = HCMediaCreationManager.getInstance();
        RegisterHCMediaCreationResult result = manager.registerHCMediaCreation(_vo);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * “o˜^ƒf[ƒ^‚ğİ’è‚µ‚Ü‚·
     *
     * @param vo “o˜^ƒf[ƒ^
     */
    public void setRegisterHCMediaCreationVO(RegisterHCMediaCreationVO vo) {
        _vo = vo;
    }

    /**
     * “o˜^Œ‹‰Ê‚ğæ“¾‚µ‚Ü‚·
     *
     * @return “o˜^Œ‹‰Ê
     */
    public RegisterHCMediaCreationResult getRegisterHCMediaCreationResult() {
        return (RegisterHCMediaCreationResult) super.getResult().get(RESULT_KEY);
    }
}
