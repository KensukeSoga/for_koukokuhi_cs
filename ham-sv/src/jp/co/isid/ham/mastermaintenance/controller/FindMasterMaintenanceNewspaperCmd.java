package jp.co.isid.ham.mastermaintenance.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.mastermaintenance.model.FindMbj47NewspaperVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceMEU20MSMZBTVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceFindContactRequestVO;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceNewspaperDispCondition;
import jp.co.isid.ham.mastermaintenance.model.FindMasterMaintenanceNewspaperDispResult;
import jp.co.isid.ham.mastermaintenance.model.MasterMaintenanceManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �V���}�X�^�\�����擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/09/17 �X)<BR>
 * </P>
 * @author �X
 */
public class FindMasterMaintenanceNewspaperCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMasterMaintenanceNewspaperDispCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        MasterMaintenanceManager manager = MasterMaintenanceManager.getInstance();

        FindMasterMaintenanceNewspaperDispResult result = new FindMasterMaintenanceNewspaperDispResult();

        FindMbj47NewspaperVO newspaperVO = manager.getMasterMaintenanceNewspaper(_condition.getConditionNewspaper());

        FindMasterMaintenanceMEU20MSMZBTVO mEU20MSMZBTVO = manager.getMEU20MSMZBT(_condition.getConditionMEU20MSMZBT());

        FindMasterMaintenanceFindContactRequestVO findContactRequestVO = manager.getMasterMaintenanceFindContactRequest(_condition.getConditionFindContactRequest());

        result.setNewspaperVO(newspaperVO);

        result.setMEU20MSMZBTVO(mEU20MSMZBTVO);

        result.setFindContactRequestVO(findContactRequestVO);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindCondition(FindMasterMaintenanceNewspaperDispCondition condition)
    {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public FindMasterMaintenanceNewspaperDispResult getFindResult()
    {
        return (FindMasterMaintenanceNewspaperDispResult) super.getResult().get(RESULT_KEY);
    }

}
