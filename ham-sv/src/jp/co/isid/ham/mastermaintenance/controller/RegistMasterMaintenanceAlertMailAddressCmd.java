package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.RegistMasterMaintenanceAlertMailAddressDispVO;
import jp.co.isid.ham.mastermaintenance.model.RegistMasterMaintenanceDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * ���[���z�M��\�����o�^�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/07/05 �X)<BR>
 * </P>
 * @author �X
 */
public class RegistMasterMaintenanceAlertMailAddressCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �o�^�f�[�^ */
    private RegistMasterMaintenanceAlertMailAddressDispVO _vo;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();
        RegistMasterMaintenanceDispResult result = new RegistMasterMaintenanceDispResult();
        manager.registMasterMaintenanceAlertMailAddress(_vo.getAlertMailAddressVO());
        getResult().set(RESULT_KEY, result);
    }

    /**
     * �o�^�f�[�^��ݒ肵�܂�
     *
     * @param vo �o�^�f�[�^
     */
    public void setRegistVO(RegistMasterMaintenanceAlertMailAddressDispVO vo) {
        _vo = vo;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public RegistMasterMaintenanceDispResult getRegistResult() {
        return (RegistMasterMaintenanceDispResult) super.getResult().get(RESULT_KEY);
    }

}
