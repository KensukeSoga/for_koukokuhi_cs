package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.HCEstimateCreationManager;
import jp.co.isid.ham.billing.model.RegisterHCEstimateCreationResult;
import jp.co.isid.ham.billing.model.RegisterHCEstimateCreationVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HCŒ©Ïì¬“o˜^ƒRƒ}ƒ“ƒh
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2013/3/1 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class RegisterHCEstimateCreationCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ŒŸõŒ‹‰ÊƒL[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    private RegisterHCEstimateCreationVO _vo;

    /**
     * HCŒ©Ïì¬“o˜^ˆ—Às
     */
    @Override
    public void execute() throws UserException {
        HCEstimateCreationManager manager = HCEstimateCreationManager.getInstance();
        RegisterHCEstimateCreationResult result = manager.registerHCEstimateCreation(_vo);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * “o˜^ƒf[ƒ^‚ğİ’è‚µ‚Ü‚·
     *
     * @param vo “o˜^ƒf[ƒ^
     */
    public void setRegisterHCEstimateCreationVO(RegisterHCEstimateCreationVO vo) {
        _vo = vo;
    }

    /**
     * “o˜^Œ‹‰Ê‚ğæ“¾‚µ‚Ü‚·
     *
     * @return “o˜^Œ‹‰Ê
     */
    public RegisterHCEstimateCreationResult getRegisterHCEstimateCreationResult() {
        return (RegisterHCEstimateCreationResult) super.getResult().get(RESULT_KEY);
    }

}
