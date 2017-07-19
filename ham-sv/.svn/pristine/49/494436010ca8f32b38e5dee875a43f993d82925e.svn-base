package jp.co.isid.ham.production.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.ham.production.model.RegisterMaterialListVO;
import jp.co.isid.ham.production.model.MaterialListManager;
import jp.co.isid.ham.production.model.MaterialListResult;

/**
 * <P>
 * ‘fŞˆê——@“o˜^Às‚ÌƒRƒ}ƒ“ƒh
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2012/12/06)<BR>
 * </P>
 * @author
 */
public class RegisterMaterialListCmd extends Command {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** ŒŸõŒ‹‰ÊƒL[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    private RegisterMaterialListVO _vo = null;

    @Override
    public void execute() throws UserException {
        MaterialListResult result = new MaterialListResult();
        result = MaterialListManager.getInstance().executeMaterialListInfo(_vo);

        super.getResult().set(RESULT_KEY, result);
    }

    /**
     * ‘fŞ“o˜^—pVO‚ğİ’è‚µ‚Ü‚·
     * @param vo
     */
    public void setRegisterMaterialListVO(RegisterMaterialListVO vo) {
        _vo = vo;
    }

    /**
     * ‘fŞ“o˜^Œ‹‰ÊƒNƒ‰ƒX‚ğæ“¾‚µ‚Ü‚·
     * @return
     */
    public MaterialListResult getMaterialListResult() {
        return (MaterialListResult) super.getResult().get(RESULT_KEY);
    }

}
