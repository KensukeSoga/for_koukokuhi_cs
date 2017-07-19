package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.CostManagementSettingManager;
import jp.co.isid.ham.billing.model.FindCrCreateDataForCmsCondition;
import jp.co.isid.ham.billing.model.FindCrCreateDataForCmsResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * CR�����Ǘ�(�����ݒ�p)�����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/1/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindCrCreateDataForCmsCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    FindCrCreateDataForCmsCondition _cond;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws UserException {
        CostManagementSettingManager manager = CostManagementSettingManager.getInstance();
        FindCrCreateDataForCmsResult result = manager.findCrCreateDataForCms(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param cond ��������
     */
    public void setFindCrCreateDataForCmsCondition(FindCrCreateDataForCmsCondition cond) {
        _cond = cond;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return ��������
     */
    public FindCrCreateDataForCmsResult getFindCrCreateDataForCmsResult() {
        return (FindCrCreateDataForCmsResult)super.getResult().get(RESULT_KEY);
    }
}
