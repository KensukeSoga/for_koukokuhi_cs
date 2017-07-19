package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.CostManagementSettingManager;
import jp.co.isid.ham.billing.model.CheckBillProductionOutputCondition;
import jp.co.isid.ham.billing.model.CheckBillProductionOutputResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * ���쐿���\�o�̓f�[�^���݃`�F�b�N�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/1 J.Kamiyama)<BR>
 * </P>
 * @author J.Kamiyama
 */
public class CheckBillProductionOutputCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    CheckBillProductionOutputCondition _cond;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws UserException {
        CostManagementSettingManager manager = CostManagementSettingManager.getInstance();

        CheckBillProductionOutputResult result = new CheckBillProductionOutputResult();

        manager.checkBillProductionOutput(_cond);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param cond ��������
     */
    public void setCheckBillProductionOutputCondition(CheckBillProductionOutputCondition cond) {
        _cond = cond;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return ��������
     */
    public CheckBillProductionOutputResult getCheckBillProductionOutputResult() {
        return (CheckBillProductionOutputResult)super.getResult().get(RESULT_KEY);
    }

}
