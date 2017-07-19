package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.production.model.FindTVCMMaterialListCondition;
import jp.co.isid.ham.production.model.FindTVCMMaterialListManager;
import jp.co.isid.ham.production.model.FindTVCMMaterialListResult;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * TVCM素材一覧検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2016/03/09 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */
public class FindTVCMMaterialListCmd extends Command {

    private static final long serialVersionUID = 1L;
    /** 検索条件 */
    private FindTVCMMaterialListCondition _condition = null;
    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /**
     * 検索条件を使用し検索処理を実行します
     * throws HAMException 検索失敗時
     */
    @Override
    public void execute() throws HAMException {
        FindTVCMMaterialListManager TVCMmanager = FindTVCMMaterialListManager.getInstance();
        FindTVCMMaterialListResult result = TVCMmanager.findTVCMMaterialList(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     * @param condition FindTVCMMaterialListCondition 検索条件
     */
    public void setFindTVCMMaterialListCondition(FindTVCMMaterialListCondition condition) {
        _condition = condition;
    }

    /**
     * 検索結果を返します
     * @return FindTVCMMaterialListResult 条件検索結果
     */
    public FindTVCMMaterialListResult getFindTVCMMaterialListResult() {
        return (FindTVCMMaterialListResult) super.getResult().get(RESULT_KEY);
    }

}
