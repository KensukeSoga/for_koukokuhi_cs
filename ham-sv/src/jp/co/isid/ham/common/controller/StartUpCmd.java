package jp.co.isid.ham.common.controller;

import jp.co.isid.ham.common.model.StartUpCondition;
import jp.co.isid.ham.common.model.StartUpManager;
import jp.co.isid.ham.common.model.StartUpResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �N�������R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/6 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class StartUpCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private StartUpCondition _startupcond = null;


    /**
     * �J�n���������s
     */
    @Override
    public void execute() throws UserException {
        StartUpManager manager = StartUpManager.getInstance();
        StartUpResult result = manager.startUp(_startupcond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * �p�����[�^��ݒ�
     * @param startupcond
     */
    public void setParameter(StartUpCondition startupcond) {
        _startupcond = startupcond;
    }

    /**
     * ���s���ʂ�Ԃ�
     * @return ���s����
     */
    public StartUpResult getStartUpResult() {
        return (StartUpResult)super.getResult().get(RESULT_KEY);
    }

}
