package jp.co.isid.ham.common.controller;

import jp.co.isid.ham.common.model.FindExcelOutSettingCondition;
import jp.co.isid.ham.common.model.FindExcelOutSettingManager;
import jp.co.isid.ham.common.model.FindExcelOutSettingResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * ���[�o�͐ݒ茟���R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/01/09 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindExcelOutSettingCmd extends Command{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private FindExcelOutSettingCondition _cond;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws HAMException {
        FindExcelOutSettingManager manager = FindExcelOutSettingManager.getInstance();
        FindExcelOutSettingResult result = manager.findExcelOutSetting(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param cond ��������
     */
    public void setExcelOutSettingCondition(FindExcelOutSettingCondition cond) {
        _cond = cond;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return FindExcelOutSettingResult ������������
     */
    public FindExcelOutSettingResult getExcelOutSettingResult() {
        return (FindExcelOutSettingResult) super.getResult().get(RESULT_KEY);
    }

}
