package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindWorkDetailCondition;
import jp.co.isid.ham.billing.model.FindWorkDetailResult;
import jp.co.isid.ham.billing.model.WorkDetailManager;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;


/**
 * <P>
 * �����׏��o�͌����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/4 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
public class FindWorkDetailCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    FindWorkDetailCondition _cond;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws UserException {
    	WorkDetailManager manager = WorkDetailManager.getInstance();
        FindWorkDetailResult result = manager.findWorkDetail(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param cond ��������
     */
    public void setFindWorkDetailCondition(FindWorkDetailCondition cond) {
        _cond = cond;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return ��������
     */
    public FindWorkDetailResult getFindWorkDetailResult() {
        return (FindWorkDetailResult)super.getResult().get(RESULT_KEY);
    }
}