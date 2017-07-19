package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.CheckListManager;
import jp.co.isid.ham.production.model.GetIniDataForCheckListCondition;
import jp.co.isid.ham.production.model.GetIniDataForCheckListResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;
/**
 * <P>
 * チェックリスト出力画面　起動時データ取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/03)<BR>
 * </P>
 * @author
 */
public class GetIniDataForCheckListCmd extends Command {


    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private GetIniDataForCheckListCondition _condition;

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

	@Override
	public void execute() throws UserException {

		GetIniDataForCheckListResult result = new GetIniDataForCheckListResult();
		CheckListManager manager = CheckListManager.getInstance();
		result = manager.getIniDataForCheckList(_condition);

        getResult().set(RESULT_KEY, result);
	}

    /**
     * 検索条件を設定します
     *
     * @param condition GetIniDataForCheckListCondition 検索条件
     */
	public void setGetIniDataForCheckListCondition(GetIniDataForCheckListCondition condition) {
        _condition = condition;
	}

    /**
     * 結果を返します
     *
     * @return GetIniDataForCheckListResult 結果
     */
	public GetIniDataForCheckListResult  getGetIniDataForCheckListResult() {
        return (GetIniDataForCheckListResult) super.getResult().get(RESULT_KEY);
	}

}
