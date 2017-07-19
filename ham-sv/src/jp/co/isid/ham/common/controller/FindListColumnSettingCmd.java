package jp.co.isid.ham.common.controller;

import jp.co.isid.ham.common.model.FindListColumnSettingCondition;
import jp.co.isid.ham.common.model.FindListColumnSettingManager;
import jp.co.isid.ham.common.model.FindListColumnSettingResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

public class FindListColumnSettingCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    private FindListColumnSettingCondition _cond;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws HAMException {
        FindListColumnSettingManager manager = FindListColumnSettingManager.getInstance();
        FindListColumnSettingResult result = manager.findListColumnSetting(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param cond 検索条件
     */
    public void setListColumnSettingCondition(FindListColumnSettingCondition cond) {
        _cond = cond;
    }

    /**
     * 検索結果を返します
     *
     * @return 検索結果
     */
    public FindListColumnSettingResult getListColumnSettingResult() {
        return (FindListColumnSettingResult) super.getResult().get(RESULT_KEY);
    }

}
