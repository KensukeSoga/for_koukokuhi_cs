package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.ham.media.model.*;

/**
 * <P>
 * �c�ƍ�Ƒ䒠�ꗗ�f�[�^�����R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/14 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
public class AccountBookRegisterCmd extends Command{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private AccountBookRegisterVO _vo;

    /**
     * �����������g�p���A �L�����y�[���ꗗ�f�[�^�������������s���܂�
     *
     * @throws HAMException
     *             �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws HAMException {
        AccountBookRegisterManager manager = AccountBookRegisterManager.getInstance();
        manager.AccountBookIUD(_vo);
        getResult().set(RESULT_KEY, new AccountBookRegisterResult());
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition
     *            CampaignList ��������
     */
    public void setAccountBookegisterResult(AccountBookRegisterVO vo) {
        _vo = vo;
    }

    /**
     * �L�����y�[���ꗗ�������ʂ�Ԃ��܂�
     *
     * @return FindCampaignListResult ������������
     */
    public AccountBookRegisterResult getAccountBookRegisterResult() {
        return (AccountBookRegisterResult) super.getResult().get(RESULT_KEY);
    }

}
