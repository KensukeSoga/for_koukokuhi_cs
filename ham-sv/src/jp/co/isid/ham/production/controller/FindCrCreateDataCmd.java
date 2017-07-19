package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CostManager;
import jp.co.isid.ham.production.model.FindCrCreateDataCondition;
import jp.co.isid.ham.production.model.FindCrCreateDataResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * CR�����@�������s���̃f�[�^�擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/06)<BR>
 * </P>
 * @author
 */
public class FindCrCreateDataCmd extends Command {


    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindCrCreateDataCondition _condition;

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    @Override
    public void execute() throws UserException {

        FindCrCreateDataResult result = new FindCrCreateDataResult();
        CostManager manager = CostManager.getInstance();
        result = manager.findCrCreateData(_condition);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition FindCrCreateDataCondition ��������
     */
    public void setFindCrCreateDataCondition(FindCrCreateDataCondition condition) {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return FindCrCreateDataResult ����
     */
    public FindCrCreateDataResult  getFindCrCreateDataResult() {
        return (FindCrCreateDataResult) super.getResult().get(RESULT_KEY);
    }

}
