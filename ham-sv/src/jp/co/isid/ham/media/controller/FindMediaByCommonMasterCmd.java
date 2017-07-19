package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindMediaByCommonMasterCondition;
import jp.co.isid.ham.media.model.FindMediaByCommonMasterManager;
import jp.co.isid.ham.media.model.FindMediaByCommonMasterResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 媒体検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/12 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindMediaByCommonMasterCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindMediaByCommonMasterCondition _condition;

    /**
     * 検索処理を実行
     */
    @Override
    public void execute() throws UserException {
        FindMediaByCommonMasterManager manager = FindMediaByCommonMasterManager.getInstance();
        FindMediaByCommonMasterResult result = manager.findMediaByCommonMaster(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定
     * @param cond
     */
    public void setFindMediaByCommonMasterCondition(FindMediaByCommonMasterCondition cond) {
        _condition = cond;
    }

    /**
     * 検索結果を取得
     * @return 検索結果
     */
    public FindMediaByCommonMasterResult getFindMediaByCommonMasterResult() {
        return (FindMediaByCommonMasterResult) super.getResult().get(RESULT_KEY);
    }
}
