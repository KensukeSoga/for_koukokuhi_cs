package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CostManager;
import jp.co.isid.ham.production.model.GetRepDataForCostMngCondition;
import jp.co.isid.ham.production.model.GetRepDataForCostMngResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;
/**
 * <P>
 * 制作原価表／制作費表　出力データ取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/03)<BR>
 * </P>
 * @author
 */
public class GetRepDataForCostMngCmd extends Command {


    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private GetRepDataForCostMngCondition _condition;

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

	@Override
	public void execute() throws UserException {

		GetRepDataForCostMngResult result = new GetRepDataForCostMngResult();
		CostManager manager = CostManager.getInstance();
		result = manager.getRepDataForCostMng(_condition);

        getResult().set(RESULT_KEY, result);
	}

    /**
     * 検索条件を設定します
     *
     * @param condition GetRepDataForCostMngCondition 検索条件
     */
	public void setGetRepDataForCostMngCondition(GetRepDataForCostMngCondition condition) {
        _condition = condition;
	}

    /**
     * 結果を返します
     *
     * @return GetRepDataForCostMngResult 結果
     */
	public GetRepDataForCostMngResult  getGetRepDataForCostMngResult() {
        return (GetRepDataForCostMngResult) super.getResult().get(RESULT_KEY);
	}

}
