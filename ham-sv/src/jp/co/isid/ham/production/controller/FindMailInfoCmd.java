package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CostManager;
import jp.co.isid.ham.production.model.FindMailInfoCondition;
import jp.co.isid.ham.production.model.FindMailInfoResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �������s���̃f�[�^�擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/06)<BR>
 * </P>
 * @author
 */
public class FindMailInfoCmd extends Command {


    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindMailInfoCondition _condition;

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    @Override
    public void execute() throws UserException {

        FindMailInfoResult result = new FindMailInfoResult();
        CostManager manager = CostManager.getInstance();
        result = manager.findMailInfo(_condition);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition FindMailInfoCondition ��������
     */
    public void setFindMailInfoCondition(FindMailInfoCondition condition) {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return FindMailInfoResult ����
     */
    public FindMailInfoResult  getFindMailInfoResult() {
        return (FindMailInfoResult) super.getResult().get(RESULT_KEY);
    }

}
