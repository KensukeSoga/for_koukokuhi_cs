package jp.co.isid.ham.common.controller;

import jp.co.isid.ham.common.model.FindListColumnSettingCondition;
import jp.co.isid.ham.common.model.FindListColumnSettingManager;
import jp.co.isid.ham.common.model.FindListColumnSettingResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

public class FindListColumnSettingCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    private FindListColumnSettingCondition _cond;

    /**
     * �����������g�p���A�������������s���܂�
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    @Override
    public void execute() throws HAMException {
        FindListColumnSettingManager manager = FindListColumnSettingManager.getInstance();
        FindListColumnSettingResult result = manager.findListColumnSetting(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param cond ��������
     */
    public void setListColumnSettingCondition(FindListColumnSettingCondition cond) {
        _cond = cond;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return ��������
     */
    public FindListColumnSettingResult getListColumnSettingResult() {
        return (FindListColumnSettingResult) super.getResult().get(RESULT_KEY);
    }

}
