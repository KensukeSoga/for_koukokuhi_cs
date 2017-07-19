package jp.co.isid.ham.common.controller;

import jp.co.isid.ham.common.model.ShutDownManager;
import jp.co.isid.ham.common.model.ShutDownResult;
import jp.co.isid.ham.common.model.Tbj29LoginUserVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �I�������R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/13 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class ShutDownCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** ���O�C�����[�U�[�폜 */
    private Tbj29LoginUserVO _tbj29vo;


    /**
     * �I�����������s
     */
    @Override
    public void execute() throws UserException {
        ShutDownManager manager = ShutDownManager.getInstance();
        ShutDownResult result = manager.shutDown(_tbj29vo);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * �p�����[�^��ݒ�
     * @param tbj29vo
     */
    public void setParameter(Tbj29LoginUserVO tbj29vo) {
        _tbj29vo = tbj29vo;
    }

    /**
     * ���s���ʂ�Ԃ�
     * @return ���s����
     */
    public ShutDownResult getShutDownResult() {
        return (ShutDownResult)super.getResult().get(RESULT_KEY);
    }

}
