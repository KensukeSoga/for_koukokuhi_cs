package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.RegistMasterMaintenanceAuthorityDispVO;
import jp.co.isid.ham.mastermaintenance.model.RegistMasterMaintenanceDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * Œ ŒÀ•\¦î•ñ“o˜^ƒRƒ}ƒ“ƒh
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2012/12/10 X)<BR>
 * </P>
 * @author X
 */
public class RegistMasterMaintenanceAuthorityCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ŒŸõŒ‹‰ÊƒL[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** “o˜^ƒf[ƒ^ */
    private RegistMasterMaintenanceAuthorityDispVO _vo;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();
        RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
        manager.registMasterMaintenanceCarAuthority(_vo.getCarAuthorityVO());
        manager.registMasterMaintenanceMediaAuthority(_vo.getMediaAuthorityVO());
        manager.registMasterMaintenanceSecurity(_vo.getSecurityVO());
        getResult().set(RESULT_KEY, result);
    }

    /**
     * “o˜^ƒf[ƒ^‚ğİ’è‚µ‚Ü‚·
     *
     * @param vo “o˜^ƒf[ƒ^
     */
    public void setRegistVO(RegistMasterMaintenanceAuthorityDispVO vo) {
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
