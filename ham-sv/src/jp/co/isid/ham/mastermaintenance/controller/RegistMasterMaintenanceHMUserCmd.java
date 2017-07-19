package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.RegistMasterMaintenanceDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.ham.mastermaintenance.model.RegistMasterMaintenanceHMUserDispVO;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HM�S���ҕ\�����o�^�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class RegistMasterMaintenanceHMUserCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** HM�S���ҕ\���o�^�f�[�^VO */
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
     * HM�S���ҕ\���o�^�f�[�^VO��ݒ肷��
     * @param vo HM�S���ҕ\���o�^�f�[�^VO
     */
    public void setRegistVO(RegistMasterMaintenanceHMUserDispVO vo) {
        _vo = vo;
    }

    /**
     * �o�^���ʂ�Ԃ�
     * @return ����
     */
    public RegistMasterMaintenanceDispResult getRegistResult() {
        return (RegistMasterMaintenanceDispResult) super.getResult().get(RESULT_KEY);
    }

}
