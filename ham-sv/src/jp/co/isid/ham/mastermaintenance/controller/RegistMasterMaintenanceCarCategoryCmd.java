package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.RegistMasterMaintenanceCarCategoryDispVO;
import jp.co.isid.ham.mastermaintenance.model.RegistMasterMaintenanceDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * ÔíƒJƒeƒSƒŠ•\¦î•ñ“o˜^ƒRƒ}ƒ“ƒh
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2012/12/12 X)<BR>
 * </P>
 * @author X
 */
public class RegistMasterMaintenanceCarCategoryCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ŒŸõŒ‹‰ÊƒL[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** “o˜^ƒf[ƒ^ */
    private RegistMasterMaintenanceCarCategoryDispVO _vo;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();
        RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
        manager.registMasterMaintenanceCarCategory(_vo.getCarCategoryVO());
        manager.registMasterMaintenanceCarCategoryContent(_vo.getCarCategoryContentVO());
        getResult().set(RESULT_KEY, result);
    }

    /**
     * “o˜^ƒf[ƒ^‚ğİ’è‚µ‚Ü‚·
     *
     * @param vo “o˜^ƒf[ƒ^
     */
    public void setRegistVO(RegistMasterMaintenanceCarCategoryDispVO vo) {
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
