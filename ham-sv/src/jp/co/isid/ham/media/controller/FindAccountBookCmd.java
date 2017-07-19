package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindAccountBookCondition;
import jp.co.isid.ham.media.model.FindAccountBookResult;
import jp.co.isid.ham.media.model.FindMediaPlanManager;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
*
* <P>
* �c�ƍ�Ƒ䒠�擾�R�}���h
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2013/07/16 T.Fujiyoshi)<BR>
* </P>
* @author T.Fujiyoshi
*/
public class FindAccountBookCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindAccountBookCondition _condition = null;

    /**
     * �c�ƍ�Ƒ䒠�̌���
     */
    @Override
    public void execute() throws HAMException {
        FindMediaPlanManager manager = FindMediaPlanManager.getInstance();
        FindAccountBookResult result = manager.findAccountBook(_condition);
        getResult().set(RESULT_KEY, result);
    }


    /**
     * �c�ƍ�Ƒ䒠���������̐ݒ�
     *
     * @param condition ��������
     */
    public void setFindAccountBookCondition(FindAccountBookCondition condition)
    {
        _condition = condition;
    }

    /**
     * �c�ƍ�Ƒ䒠�������ʂ̎擾
     *
     * @return �c�ƍ�Ƒ䒠
     */
    public FindAccountBookResult getFindAccountBookResult()
    {
        return (FindAccountBookResult) super.getResult().get(RESULT_KEY);
    }
}
