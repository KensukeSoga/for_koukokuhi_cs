package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.ContractRegisterManager;
import jp.co.isid.ham.production.model.FindLogContractInfoCondition;
import jp.co.isid.ham.production.model.FindLogContractInfoResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;
/**
 * <P>
 * 契約情報登録　更新履歴実行時のデータ取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/02/15)<BR>
 * </P>
 * @author
 */
public class FindLogContractInfoCmd extends Command {


    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindLogContractInfoCondition _condition;

	/**
	 *
	 */
	private static final long serialVersionUID = 1L;

	@Override
	public void execute() throws UserException {

		FindLogContractInfoResult result = new FindLogContractInfoResult();
		ContractRegisterManager manager = ContractRegisterManager.getInstance();
		result = manager.findLogContractInfo(_condition);

        getResult().set(RESULT_KEY, result);
	}

    /**
     * 検索条件を設定します
     *
     * @param condition FindLogContractInfoCondition 検索条件
     */
	public void setFindLogContractInfoCondition(FindLogContractInfoCondition condition) {
        _condition = condition;
	}

    /**
     * 結果を返します
     *
     * @return FindLogContractInfoResult 結果
     */
	public FindLogContractInfoResult  getFindLogContractInfoResult() {
        return (FindLogContractInfoResult) super.getResult().get(RESULT_KEY);
	}

}
