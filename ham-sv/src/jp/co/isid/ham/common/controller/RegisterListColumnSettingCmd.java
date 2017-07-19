package jp.co.isid.ham.common.controller;

import jp.co.isid.ham.common.model.RegisterListColumnSettingManager;
import jp.co.isid.ham.common.model.RegisterListColumnSettingResult;
import jp.co.isid.ham.common.model.RegisterListColumnSettingVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

public class RegisterListColumnSettingCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ŒŸõŒ‹‰ÊƒL[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** “o˜^ƒf[ƒ^ */
    private RegisterListColumnSettingVO _vo;

    /**
     * —ñİ’è“o˜^
     */
    @Override
    public void execute() throws UserException {
        RegisterListColumnSettingManager manager = RegisterListColumnSettingManager.getInstance();
        manager.registerListColumnSetting(_vo);
        getResult().set(RESULT_KEY, new RegisterListColumnSettingResult());
    }

    /**
     * “o˜^ƒf[ƒ^‚ğİ’è‚µ‚Ü‚·
     * @param vo “o˜^ƒf[ƒ^
     */
    public void setRegisterListColumnSettingVO(RegisterListColumnSettingVO vo) {
        _vo = vo;
    }

    /**
     * “o˜^Œ‹‰Ê‚ğ•Ô‚µ‚Ü‚·
     * @return “o˜^Œ‹‰Ê
     */
    public RegisterListColumnSettingResult getRegisterListColumnSettingResult() {
        return (RegisterListColumnSettingResult) super.getResult().get(RESULT_KEY);
    }
}
