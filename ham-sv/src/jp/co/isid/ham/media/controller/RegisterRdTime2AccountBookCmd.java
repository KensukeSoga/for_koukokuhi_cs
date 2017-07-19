package jp.co.isid.ham.media.controller;

import java.util.List;

import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.media.model.FindRdTime2AccountBookCondition;
import jp.co.isid.ham.media.model.FindRdTime2AccountBookManager;
import jp.co.isid.ham.media.model.RdTime2AccountBookRegisterManager;
import jp.co.isid.ham.media.model.RdTime2AccountBookRegisterResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * �c�ƍ�Ƒ䒠���W�I�^�C���C���|�[�g���o�^�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/12/12 HLC S.Fujimoto)<BR>
 * </P>
 *
 * @author S.Fujimoto
 */
public class RegisterRdTime2AccountBookCmd extends Command {

    private static final long serialVersionUID = 1L;

    /** �X�V���ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** ���W�I�ԑg�o�^��ʓo�^���VO */
    private FindRdTime2AccountBookCondition _cond = null;

    /**
     * ���W�I�ԑg�o�^��ʓo�^����o�^����
     * @throws HAMException
     */
    @Override
    public void execute() throws HAMException {

        //���W�I�^�C���C���|�[�g���쐬
        List<Tbj02EigyoDaichoVO> tbj02VoList = FindRdTime2AccountBookManager.getInstance().FindRdTime2AccountBook(_cond);
        if (tbj02VoList.size() == 0) {
            getResult().set(RESULT_KEY, new RdTime2AccountBookRegisterResult());
            return;
        }

        //�o�^����
        RdTime2AccountBookRegisterManager.getInstance().registerRdTimeInfo2AccountBook(tbj02VoList, _cond);
        getResult().set(RESULT_KEY, new RdTime2AccountBookRegisterResult());
    }

    /**
     * ���W�I�ԑg�o�^��ʓo�^VO��ݒ肷��
     * @param vo RegisterRdProgramInfoVO ���W�I�ԑg�o�^��ʓo�^VO
     */
    public void setFindRdTime2AccountBookCondition(FindRdTime2AccountBookCondition cond) {
        _cond = cond;
    }

    /**
     * ���W�I�ԑg�o�^��ʓo�^���ʂ��擾����
     * @return RegisterRdProgramInfoResult �o�^����
     */
    public RdTime2AccountBookRegisterResult getRdTimeImportRegisterResult() {
        return (RdTime2AccountBookRegisterResult) super.getResult().get(RESULT_KEY);
    }

}
