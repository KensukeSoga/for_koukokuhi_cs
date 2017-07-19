package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.RegistMasterMaintenanceUserDispVO;
import jp.co.isid.ham.mastermaintenance.model.RegistMasterMaintenanceDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * ’S“–Ò•\¦î•ñ“o˜^ƒRƒ}ƒ“ƒh
 * </P>
 * <P>
 * <B>C³—š—ğ</B><BR>
 * EV‹Kì¬(2012/12/12 X)<BR>
 * EHDX‘Î‰(2016/03/02 ‘åé)<BR>
 * </P>
 * @author X
 */
public class RegistMasterMaintenanceUserCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** ŒŸõŒ‹‰ÊƒL[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** “o˜^ƒf[ƒ^ */
    private RegistMasterMaintenanceUserDispVO _vo;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();
        RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
        manager.registMasterMaintenanceUser(_vo.getUserVO());
        manager.registMasterMaintenanceCarAuthority(_vo.getCarAuthorityVO());
        manager.registMasterMaintenanceMediaAuthority(_vo.getMediaAuthorityVO());
        manager.registMasterMaintenanceFunctionControl(_vo.getFunctionControlVO());
        manager.registMasterMaintenanceSecurity(_vo.getSecurityVO());
        manager.registMasterMaintenanceAlertDispControl(_vo.getAlertDispControlVO());
        /* 2016/02/29 HDX‘Î‰ HLC K.Oki ADD Start */
        manager.registMasterMaintenanceCarUserSozaiUserID(_vo.getSzTntUserVO());
        /* 2016/02/29 HDX‘Î‰ HLC K.Oki ADD End */
        getResult().set(RESULT_KEY, result);
    }

    /**
     * “o˜^ƒf[ƒ^‚ğİ’è‚µ‚Ü‚·
     *
     * @param vo “o˜^ƒf[ƒ^
     */
    public void setRegistVO(RegistMasterMaintenanceUserDispVO vo) {
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
