package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj03MediaVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj02UserVO;
import jp.co.isid.ham.mastermaintenance.model.FindMbj14MediaOutCtrlVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMediaDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMediaDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * ”}‘Ì•\¦î•ñæ“¾ƒRƒ}ƒ“ƒh
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2012/12/12 X)<BR>
 * </P>
 * @author X
 */
public class FindMasterMaintenanceMediaCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ŒŸõŒ‹‰ÊƒL[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** ŒŸõğŒ */
    private FindMasterMaintenanceMediaDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceMediaDispResult result = new FindMasterMaintenanceMediaDispResult();

        FindMbj03MediaVO mediaVO = manager.getMasterMaintenanceMedia(_condition.getConditionMedia());

        FindMbj02UserVO userVO = manager.getMasterMaintenanceUser(_condition.getConditionUser());

        FindMbj14MediaOutCtrlVO mediaOutControlVO = manager.getMasterMaintenanceMediaOutControl(_condition.getConditionMediaOutControl());

        result.setMediaVO(mediaVO);

        result.setUserVO(userVO);

        result.setMediaOutControlVO(mediaOutControlVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ŒŸõğŒ‚ğİ’è‚µ‚Ü‚·
     *
     * @param condition ŒŸõğŒ
     */
    public void setFindCondition(FindMasterMaintenanceMediaDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * Œ‹‰Ê‚ğ•Ô‚µ‚Ü‚·
     *
     * @return Œ‹‰Ê
     */
    public FindMasterMaintenanceMediaDispResult getFindResult()
    {
        return (FindMasterMaintenanceMediaDispResult) super.getResult().get(RESULT_KEY);
    }

}
