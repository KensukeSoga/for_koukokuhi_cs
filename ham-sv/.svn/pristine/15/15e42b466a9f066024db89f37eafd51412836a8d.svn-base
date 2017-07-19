package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindAccountBookCondition;
import jp.co.isid.ham.media.model.FindAccountBookResult;
import jp.co.isid.ham.media.model.FindMediaPlanManager;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
*
* <P>
* ‰c‹Æì‹Æ‘ä’ æ“¾ƒRƒ}ƒ“ƒh
* </P>
* <P>
* <B>C³—š—ğ</B><BR>
* EV‹Kì¬(2013/07/16 T.Fujiyoshi)<BR>
* </P>
* @author T.Fujiyoshi
*/
public class FindAccountBookCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ŒŸõŒ‹‰ÊƒL[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** ŒŸõğŒ */
    private FindAccountBookCondition _condition = null;

    /**
     * ‰c‹Æì‹Æ‘ä’ ‚ÌŒŸõ
     */
    @Override
    public void execute() throws HAMException {
        FindMediaPlanManager manager = FindMediaPlanManager.getInstance();
        FindAccountBookResult result = manager.findAccountBook(_condition);
        getResult().set(RESULT_KEY, result);
    }


    /**
     * ‰c‹Æì‹Æ‘ä’ ŒŸõğŒ‚Ìİ’è
     *
     * @param condition ŒŸõğŒ
     */
    public void setFindAccountBookCondition(FindAccountBookCondition condition)
    {
        _condition = condition;
    }

    /**
     * ‰c‹Æì‹Æ‘ä’ ŒŸõŒ‹‰Ê‚Ìæ“¾
     *
     * @return ‰c‹Æì‹Æ‘ä’ 
     */
    public FindAccountBookResult getFindAccountBookResult()
    {
        return (FindAccountBookResult) super.getResult().get(RESULT_KEY);
    }
}
