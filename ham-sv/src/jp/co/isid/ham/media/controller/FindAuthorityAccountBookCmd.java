package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.media.model.*;

/**
 * <P>
 * �c�ƍ�Ƒ䒠�f�[�^�����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/03 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindAuthorityAccountBookCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindAuthorityAccountBookCondition _condition;

    /**
     * �����������g�p���A �c�ƍ�Ƒ䒠�f�[�^�������������s���܂�
     *
     * @throws HAMException
     *             �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws HAMException {
        FindAuthorityAccountBookManager manager = FindAuthorityAccountBookManager.getInstance();
        FindAuthorityAccountBookResult result = manager.findAuthorityAccountBook(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition
     *            AccountBook ��������
     */
    public void setAuthorityAccountBookCondition(FindAuthorityAccountBookCondition condition) {
        _condition = condition;
    }

    /**
     * �c�ƍ�Ƒ䒠�������ʂ�Ԃ��܂�
     *
     * @return FindAuthorityAccountBookResult ������������
     */
    public FindAuthorityAccountBookResult getAuthorityAccountBookResult() {
        return (FindAuthorityAccountBookResult) super.getResult().get(RESULT_KEY);
    }
}
