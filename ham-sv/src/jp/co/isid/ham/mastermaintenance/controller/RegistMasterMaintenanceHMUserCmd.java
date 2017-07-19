package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.RegistMasterMaintenanceDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.ham.mastermaintenance.model.RegistMasterMaintenanceHMUserDispVO;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HM’S“–Ò•\¦î•ñ“o˜^ƒRƒ}ƒ“ƒh
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class RegistMasterMaintenanceHMUserCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ŒŸõŒ‹‰ÊƒL[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** HM’S“–Ò•\¦“o˜^ƒf[ƒ^VO */
    private RegistMasterMaintenanceHMUserDispVO _vo;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException {

        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();
        RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
        manager.registMasterMaintenanceHMUser(_vo.getHMUserVO());
        getResult().set(RESULT_KEY, result);
    }

    /**
     * HM’S“–Ò•\¦“o˜^ƒf[ƒ^VO‚ğİ’è‚·‚é
     * @param vo HM’S“–Ò•\¦“o˜^ƒf[ƒ^VO
     */
    public void setRegistVO(RegistMasterMaintenanceHMUserDispVO vo) {
        _vo = vo;
    }

    /**
     * “o˜^Œ‹‰Ê‚ğ•Ô‚·
     * @return Œ‹‰Ê
     */
    public RegistMasterMaintenanceDispResult getRegistResult() {
        return (RegistMasterMaintenanceDispResult) super.getResult().get(RESULT_KEY);
    }

}
