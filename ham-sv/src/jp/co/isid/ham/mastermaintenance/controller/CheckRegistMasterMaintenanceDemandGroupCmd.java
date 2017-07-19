package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.RegistMbj26BillGroupVO;
import jp.co.isid.ham.mastermaintenance.model.CheckRegistMasterMaintenanceResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * ������O���[�v�`�F�b�N�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * </P>
 * @author �X
 */
public class CheckRegistMasterMaintenanceDemandGroupCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �`�F�b�N�f�[�^ */
    private RegistMbj26BillGroupVO _vo;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();
        CheckRegistMasterMaintenanceResult result = new CheckRegistMasterMaintenanceResult();
        manager.checkRegistMasterMaintenanceDemandGroup(_vo);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * �`�F�b�N�f�[�^��ݒ肵�܂�
     *
     * @param vo �`�F�b�N�f�[�^
     */
    public void setCheckRegistVO(RegistMbj26BillGroupVO vo) {
        _vo = vo;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public CheckRegistMasterMaintenanceResult getCheckRegistResult() {
        return (CheckRegistMasterMaintenanceResult) super.getResult().get(RESULT_KEY);
    }

}
