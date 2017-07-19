package jp.co.isid.ham.common.controller;

import jp.co.isid.ham.common.model.ExcelOutSettingRegisterManager;
import jp.co.isid.ham.common.model.ExcelOutSettingRegisterResult;
import jp.co.isid.ham.common.model.ExcelOutSettingRegisterVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * ���[�o�͐ݒ�X�V�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/01/10 HLC H.Watabe)<BR>
 * </P>
 *
 * @author HLC H.Watabe
 */
public class ExcelOutSettingRegisterCmd extends Command{

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private ExcelOutSettingRegisterVO _vo;

    /**
     * �����������g�p���A �L�����y�[���ꗗ�f�[�^�������������s���܂�
     *
     * @throws HAMException
     *             �����Ɏ��s�����ꍇ
     */
    public void execute() throws HAMException {
        ExcelOutSettingRegisterManager manager = ExcelOutSettingRegisterManager.getInstance();
        manager.excelOutSettingRegister(_vo);
        getResult().set(RESULT_KEY, new ExcelOutSettingRegisterResult());
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition
     *            CampaignList ��������
     */
    public void setExcelOutSettingRegisterResult(ExcelOutSettingRegisterVO vo) {
        _vo = vo;
    }

    /**
     * �L�����y�[���ꗗ�������ʂ�Ԃ��܂�
     *
     * @return FindCampaignListResult ������������
     */
    public ExcelOutSettingRegisterResult getExcelOutSettingRegisterResultt() {
        return (ExcelOutSettingRegisterResult) super.getResult().get(RESULT_KEY);
    }

}
