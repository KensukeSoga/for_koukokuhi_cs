package jp.co.isid.ham.media.controller;

import jp.co.isid.ham.media.model.FindRdAllocationPictureCondition;
import jp.co.isid.ham.media.model.FindRdAllocationPictureManager;
import jp.co.isid.ham.media.model.FindRdAllocationPictureResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * ラジオ版AllocationPicture出力情報検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/11/20 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdAllocationPictureCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索条件 */
    private FindRdAllocationPictureCondition _condition = null;
    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /**
     * 検索条件を使用し検索処理を実行します
     * throws HAMException 検索失敗時
     */
    @Override
    public void execute() throws HAMException {
        FindRdAllocationPictureManager manager = FindRdAllocationPictureManager.getInstance();
        FindRdAllocationPictureResult result = manager.findRdAllocationPicture(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     * @param condition FindRdAllocationPictureCondition 検索条件
     */
    public void setFindRdAllocationPictureCondition(FindRdAllocationPictureCondition condition) {
        _condition = condition;
    }

    /**
     * 検索結果を返します
     * @return FindRdAllocationPictureResult 条件検索結果
     */
    public FindRdAllocationPictureResult getFindRdAllocationPictureResult() {
        return (FindRdAllocationPictureResult) super.getResult().get(RESULT_KEY);
    }

}
