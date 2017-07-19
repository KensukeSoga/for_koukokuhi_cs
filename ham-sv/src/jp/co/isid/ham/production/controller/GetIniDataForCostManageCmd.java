package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CostManager;
import jp.co.isid.ham.production.model.GetIniDataForCostManageCondition;
import jp.co.isid.ham.production.model.GetIniDataForCostManageResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;
/**
 * <P>
 * CR制作費　起動時データ取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/03)<BR>
 * </P>
 * @author
 */
public class GetIniDataForCostManageCmd extends Command {


    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private GetIniDataForCostManageCondition _condition;

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

	@Override
	public void execute() throws UserException {

		GetIniDataForCostManageResult result = new GetIniDataForCostManageResult();
		CostManager manager = CostManager.getInstance();
		result = manager.getIniDataForCostManage(_condition);

        getResult().set(RESULT_KEY, result);
	}

    /**
     * 検索条件を設定します
     *
     * @param condition GetIniDataForCostManageCondition 検索条件
     */
	public void setGetIniDataForCostManageCondition(GetIniDataForCostManageCondition condition) {
        _condition = condition;
	}

    /**
     * 結果を返します
     *
     * @return GetIniDataForCostManageResult 結果
     */
	public GetIniDataForCostManageResult  getGetIniDataForCostManageResult() {
        return (GetIniDataForCostManageResult) super.getResult().get(RESULT_KEY);
	}

}
