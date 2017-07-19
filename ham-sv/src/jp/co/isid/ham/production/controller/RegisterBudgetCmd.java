package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CostManager;
import jp.co.isid.ham.production.model.RegisterBudgetResult;
import jp.co.isid.ham.production.model.RegisterBudgetVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;
/**
 * <P>
 * Ôí•Ê—\Z(Ú×)@“o˜^Às‚ÌƒRƒ}ƒ“ƒh
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2012/12/06)<BR>
 * </P>
 * @author
 */
public class RegisterBudgetCmd extends Command {


    /** ŒŸõŒ‹‰ÊƒL[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** ŒŸõğŒ */
    private RegisterBudgetVO _vo;

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

	@Override
	public void execute() throws UserException {

	    RegisterBudgetResult result = new RegisterBudgetResult();
		CostManager manager = CostManager.getInstance();
		result = manager.registerBudget(_vo);

        getResult().set(RESULT_KEY, result);
	}

    /**
     * ŒŸõğŒ‚ğİ’è‚µ‚Ü‚·
     *
     * @param condition RegisterBudgetVo ŒŸõğŒ
     */
	public void setRegisterBudgetVO(RegisterBudgetVO vo) {
        _vo = vo;
	}

    /**
     * Œ‹‰Ê‚ğ•Ô‚µ‚Ü‚·
     *
     * @return RegisterBudgetResult Œ‹‰Ê
     */
	public RegisterBudgetResult  getRegisterBudgetResult() {
        return (RegisterBudgetResult) super.getResult().get(RESULT_KEY);
	}

}
