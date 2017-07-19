package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.ContractRegisterCondition;
import jp.co.isid.ham.production.model.ContractRegisterManager;
import jp.co.isid.ham.production.model.ContractRegisterResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 契約情報登録起動時データ取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/03 JSE A.Naito)<BR>
 * </P>
 * @author
 */
public class GetInitContractRegisterCmd extends Command {

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private ContractRegisterCondition _condition;

	/**
	 *
	 */
	private static final long serialVersionUID = 8L;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
	public void execute() throws UserException {
	    ContractRegisterResult result = new ContractRegisterResult();
		ContractRegisterManager manager = ContractRegisterManager.getInstance();
		result = manager.findByCondition(_condition);
        getResult().set(RESULT_KEY, result);
	}

    /**
     * 検索条件を設定します
     *
     * @param condition CommonCodeMasterSearchCondition 検索条件
     */
	public void setContractRegisterCondition(ContractRegisterCondition condition) {
        _condition = condition;
	}

    /**
     * 条件検索結果を返します
     *
     * @return ContractRegisterResult 条件検索結果
     */
	public ContractRegisterResult getContractRegisterResult() {
        return (ContractRegisterResult) super.getResult().get(RESULT_KEY);
	}

}
