package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.HCEstimateListManager;
import jp.co.isid.ham.billing.model.RegisterHCEstimateListResult;
import jp.co.isid.ham.billing.model.RegisterHCEstimateListVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HCŒ©Ïˆê——“o˜^ƒRƒ}ƒ“ƒh
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2013/2/13 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class RegisterHCEstimateListCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ŒŸõŒ‹‰ÊƒL[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    RegisterHCEstimateListVO _vo;

    /**
     * HCŒ©Ï“o˜^ˆ—Às
     */
    @Override
    public void execute() throws UserException {
        HCEstimateListManager manager = HCEstimateListManager.getInstance();
        RegisterHCEstimateListResult result = manager.registerHCEstimateList(_vo);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * “o˜^ƒf[ƒ^‚ğİ’è‚µ‚Ü‚·
     *
     * @param vo “o˜^ƒf[ƒ^
     */
    public void setRegisterHCEstimateListVO(RegisterHCEstimateListVO vo) {
        _vo = vo;
    }

    /**
     * “o˜^Œ‹‰Ê‚ğæ“¾‚µ‚Ü‚·
     *
     * @return “o˜^Œ‹‰Ê
     */
    public RegisterHCEstimateListResult getRegisterHCEstimateListResult() {
        return (RegisterHCEstimateListResult) super.getResult().get(RESULT_KEY);
    }

}
