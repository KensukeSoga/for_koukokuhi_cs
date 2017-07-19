package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.common.model.Tbj02EigyoDaichoCondition;
import jp.co.isid.ham.media.model.FindGrossSumManager;
import jp.co.isid.ham.media.model.FindGrossSumResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * Excel�捞�݃G���[��ʌ����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/05 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindGrossSumCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private Tbj02EigyoDaichoCondition _condition;

    /**
     * ���������Ō��������{
     */
    @Override
    public void execute() throws HAMException {
        FindGrossSumManager manager = FindGrossSumManager.getInstance();
        FindGrossSumResult result = manager.findGrossSum(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setTbj02EigyoDaichoCondition(Tbj02EigyoDaichoCondition condition) {
        _condition = condition;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return FindGrossSumResult ������������
     */
    public FindGrossSumResult getFindGrossSumResult() {
        return (FindGrossSumResult) super.getResult().get(RESULT_KEY);
    }


}
