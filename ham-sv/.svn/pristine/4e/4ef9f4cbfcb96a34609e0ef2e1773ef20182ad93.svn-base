package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CheckListManager;
import jp.co.isid.ham.production.model.GetRepDataForChkListCondition;
import jp.co.isid.ham.production.model.GetRepDataForChkListResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;
/**
 * <P>
 * チェックリスト　帳票出力データ取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/03)<BR>
 * </P>
 * @author
 */
public class GetRepDataForChkListCmd extends Command {


    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private GetRepDataForChkListCondition _condition;

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

	@Override
	public void execute() throws UserException {

		GetRepDataForChkListResult result = new GetRepDataForChkListResult();
		CheckListManager manager = CheckListManager.getInstance();
		result = manager.GetRepDataForChkList(_condition);

        getResult().set(RESULT_KEY, result);
	}

    /**
     * 検索条件を設定します
     *
     * @param condition GetRepDataForChkListCondition 検索条件
     */
	public void setGetRepDataForChkListCondition(GetRepDataForChkListCondition condition) {
        _condition = condition;
	}

    /**
     * 結果を返します
     *
     * @return GetRepDataForChkListResult 結果
     */
	public GetRepDataForChkListResult  getGetRepDataForChkListResult() {
        return (GetRepDataForChkListResult) super.getResult().get(RESULT_KEY);
	}

}
