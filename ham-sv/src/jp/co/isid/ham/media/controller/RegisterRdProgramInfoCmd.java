package jp.co.isid.ham.media.controller;

import java.math.BigDecimal;

import jp.co.isid.ham.media.model.RegisterRdProgramInfoManager;
import jp.co.isid.ham.media.model.RegisterRdProgramInfoResult;
import jp.co.isid.ham.media.model.RegisterRdProgramInfoVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * ƒ‰ƒWƒI”Ô‘g“o˜^‰æ–Ê“o˜^ƒRƒ}ƒ“ƒh
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 *
 * @author S.Fujimoto
 */
public class RegisterRdProgramInfoCmd extends Command {

    private static final long serialVersionUID = 1L;

    /** XVŒ‹‰ÊƒL[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** ƒ‰ƒWƒI”Ô‘g“o˜^‰æ–Ê“o˜^î•ñVO */
    private RegisterRdProgramInfoVO _vo = null;

    /**
     * ƒ‰ƒWƒI”Ô‘g“o˜^‰æ–Ê“o˜^î•ñ‚ğ“o˜^‚·‚é
     * @throws HAMException
     */
    @Override
    public void execute() throws HAMException {
        BigDecimal rdSeqNo = RegisterRdProgramInfoManager.getInstance().registerRdProgramInfo(_vo);
        RegisterRdProgramInfoResult result = new RegisterRdProgramInfoResult();
        getResult().set(RESULT_KEY, result);
        result.setRdSeqNo(rdSeqNo);
    }

    /**
     * ƒ‰ƒWƒI”Ô‘g“o˜^‰æ–Ê“o˜^VO‚ğİ’è‚·‚é
     * @param vo RegisterRdProgramInfoVO ƒ‰ƒWƒI”Ô‘g“o˜^‰æ–Ê“o˜^VO
     */
    public void setRegisterRdProgramInfoVO(RegisterRdProgramInfoVO vo) {
        _vo = vo;
    }

    /**
     * ƒ‰ƒWƒI”Ô‘g“o˜^‰æ–Ê“o˜^Œ‹‰Ê‚ğæ“¾‚·‚é
     * @return RegisterRdProgramInfoResult “o˜^Œ‹‰Ê
     */
    public RegisterRdProgramInfoResult getRegisterRdProgramInfoResult() {
        return (RegisterRdProgramInfoResult) super.getResult().get(RESULT_KEY);
    }

}
