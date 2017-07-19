package jp.co.isid.ham.production.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.ham.production.model.MaterialRegisterManager;
import jp.co.isid.ham.production.model.RegisterRealMaterialFromTempMaterialResult;
import jp.co.isid.ham.production.model.RegisterRealMaterialFromTempMaterialVO;

/**
 * <P>
 * –{‘fŞ“o˜^ƒRƒ}ƒ“ƒh
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2015/11/10 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class RegisterRealMaterialFromTempMaterialCmd extends Command {

    private static final long serialVersionUID = 1L;

    /** ŒŸõŒ‹‰ÊƒL[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** –{‘fŞ“o˜^VO */
    private RegisterRealMaterialFromTempMaterialVO _vo = null;

    @Override
    public void execute() throws UserException {
        RegisterRealMaterialFromTempMaterialResult result = new RegisterRealMaterialFromTempMaterialResult();
        result = MaterialRegisterManager.getInstance().registerRealMaterialFromTempMaterial(_vo);

        super.getResult().set(RESULT_KEY, result);
    }

    /**
     * ‘fŞ“o˜^—pVO‚ğİ’è‚µ‚Ü‚·
     * @param vo
     */
    public void setRegisterRealMaterialFromTempMaterialVO(RegisterRealMaterialFromTempMaterialVO vo) {
        _vo = vo;
    }

    /**
     * ‘fŞ“o˜^Œ‹‰ÊƒNƒ‰ƒX‚ğæ“¾‚µ‚Ü‚·
     * @return
     */
    public RegisterRealMaterialFromTempMaterialResult getRegisterRealMaterialFromTempMaterialResult() {
        return (RegisterRealMaterialFromTempMaterialResult) super.getResult().get(RESULT_KEY);
    }

}
