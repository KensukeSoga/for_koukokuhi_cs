package jp.co.isid.ham.common.controller;

import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoResult;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �@�\������擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/06/11 �X)<BR>
 * </P>
 * @author �X
 */
public class FindFunctionControlInfoCmd extends Command
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FunctionControlInfoCondition _condition;

    /**
     * execute
     */
    @Override
    public void execute() throws UserException
    {
        FunctionControlInfoManager manager = FunctionControlInfoManager.getInstance();

        FunctionControlInfoResult result = manager.getFunctionControlInfo(_condition);

        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setFindCondition(FunctionControlInfoCondition condition)
    {
        _condition = condition;
    }

    /**
     * ���ʂ�Ԃ��܂�
     *
     * @return ����
     */
    public FunctionControlInfoResult getFindResult()
    {
        return (FunctionControlInfoResult) super.getResult().get(RESULT_KEY);
    }

}
