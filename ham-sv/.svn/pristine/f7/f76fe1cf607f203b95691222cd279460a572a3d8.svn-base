package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.CostManagementSettingManager;
import jp.co.isid.ham.billing.model.RegisterCostManagementSettingResult;
import jp.co.isid.ham.billing.model.RegisterCostManagementSettingVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * §ì”ïİ’è“o˜^ƒRƒ}ƒ“ƒh
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2013/1/31 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class RegisterCostManagementSettingCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ŒŸõŒ‹‰ÊƒL[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    RegisterCostManagementSettingVO _vo;

    /**
     * §ì”ï“o˜^ˆ—Às
     */
    @Override
    public void execute() throws UserException {
        CostManagementSettingManager manager = CostManagementSettingManager.getInstance();
        RegisterCostManagementSettingResult result = manager.registerCostManagementSetting(_vo);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * “o˜^ƒf[ƒ^‚ğİ’è‚µ‚Ü‚·
     *
     * @param vo “o˜^ƒf[ƒ^
     */
    public void setRegisterCostManagementSettingVO(RegisterCostManagementSettingVO vo) {
        _vo = vo;
    }

    /**
     * “o˜^Œ‹‰Ê‚ğæ“¾‚µ‚Ü‚·
     *
     * @return “o˜^Œ‹‰Ê
     */
    public RegisterCostManagementSettingResult getRegisterCostManagementSettingResult() {
        return (RegisterCostManagementSettingResult) super.getResult().get(RESULT_KEY);
    }
}
