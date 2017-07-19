package jp.co.isid.ham.common.controller;

import jp.co.isid.ham.common.model.FindExcelOutSettingCondition;
import jp.co.isid.ham.common.model.FindExcelOutSettingManager;
import jp.co.isid.ham.common.model.FindExcelOutSettingResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * 帳票出力設定検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/09 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindExcelOutSettingCmd extends Command{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindExcelOutSettingCondition _cond;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws HAMException {
        FindExcelOutSettingManager manager = FindExcelOutSettingManager.getInstance();
        FindExcelOutSettingResult result = manager.findExcelOutSetting(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param cond 検索条件
     */
    public void setExcelOutSettingCondition(FindExcelOutSettingCondition cond) {
        _cond = cond;
    }

    /**
     * 検索結果を返します
     *
     * @return FindExcelOutSettingResult 条件検索結果
     */
    public FindExcelOutSettingResult getExcelOutSettingResult() {
        return (FindExcelOutSettingResult) super.getResult().get(RESULT_KEY);
    }

}
