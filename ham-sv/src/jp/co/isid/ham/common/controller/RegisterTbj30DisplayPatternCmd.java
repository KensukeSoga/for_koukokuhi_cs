package jp.co.isid.ham.common.controller;

import java.util.List;

import jp.co.isid.ham.common.model.Tbj30DisplayPatternManager;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternResult;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �ꗗ�\���p�^�[���R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/11 K.Fukuda)<BR>
 * </P>
 * @author K.Fukuda
 */
public class RegisterTbj30DisplayPatternCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private List<Tbj30DisplayPatternVO> _voList;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws UserException {
        Tbj30DisplayPatternManager manager = Tbj30DisplayPatternManager.getInstance();
        manager.registerTbj30DisplayPattern(_voList);
        getResult().set(RESULT_KEY, new Tbj30DisplayPatternResult());
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setTbj30DisplayPatternVoList(List<Tbj30DisplayPatternVO> voList) {
        _voList = voList;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return Tbj30DisplayPatternResult ������������
     */
    public Tbj30DisplayPatternResult getTbj30DisplayPatternResult() {
        return (Tbj30DisplayPatternResult) super.getResult().get(RESULT_KEY);
    }

}
