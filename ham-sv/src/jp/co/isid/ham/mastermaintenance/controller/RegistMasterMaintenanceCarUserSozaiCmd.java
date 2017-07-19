package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.ham.mastermaintenance.model.RegistMasterMaintenanceCarUserSozaiDispVO;
import jp.co.isid.ham.mastermaintenance.model.RegistMasterMaintenanceDispResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * Ôí’S“–(‘fŞ)“o˜^ƒRƒ}ƒ“ƒh
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2016/02/17 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */

public class RegistMasterMaintenanceCarUserSozaiCmd extends Command
{
    private static final long serialVersionUID = 1L;

    /** ŒŸõŒ‹‰ÊƒL[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** “o˜^ƒf[ƒ^ */
    private RegistMasterMaintenanceCarUserSozaiDispVO _vo;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();
        RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
        manager.registMasterMaintenanceCarUserSozai(_vo.getCarUserSozaiVO());
        getResult().set(RESULT_KEY, result);
    }

    /**
     * “o˜^ƒf[ƒ^‚ğİ’è‚µ‚Ü‚·
     *
     * @param vo “o˜^ƒf[ƒ^
     */
    public void setRegistVO(RegistMasterMaintenanceCarUserSozaiDispVO vo) {
        _vo = vo;
    }

    /**
     * Œ‹‰Ê‚ğ•Ô‚µ‚Ü‚·
     *
     * @return Œ‹‰Ê
     */
    public RegistMasterMaintenanceDispResult getRegistResult() {
        return (RegistMasterMaintenanceDispResult) super.getResult().get(RESULT_KEY);
    }
}
