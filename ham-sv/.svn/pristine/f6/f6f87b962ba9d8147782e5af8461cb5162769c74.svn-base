package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.CostManagementSettingManager;
import jp.co.isid.ham.billing.model.FindCrCreateDataForCmsCondition;
import jp.co.isid.ham.billing.model.FindCrCreateDataForCmsResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * CR制作費管理(制作費設定用)検索コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/1/22 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindCrCreateDataForCmsCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    FindCrCreateDataForCmsCondition _cond;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {
        CostManagementSettingManager manager = CostManagementSettingManager.getInstance();
        FindCrCreateDataForCmsResult result = manager.findCrCreateDataForCms(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param cond 検索条件
     */
    public void setFindCrCreateDataForCmsCondition(FindCrCreateDataForCmsCondition cond) {
        _cond = cond;
    }

    /**
     * 検索結果を返します
     *
     * @return 検索結果
     */
    public FindCrCreateDataForCmsResult getFindCrCreateDataForCmsResult() {
        return (FindCrCreateDataForCmsResult)super.getResult().get(RESULT_KEY);
    }
}
