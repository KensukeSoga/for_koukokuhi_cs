package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.ContractSearchManager;
import jp.co.isid.ham.production.model.ContractSearchResult;
import jp.co.isid.ham.production.model.ContractSearchCondition;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 *
 * @author HAMチーム
 *
 */
public class FindContractSearchCmd extends Command  {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private ContractSearchCondition _condition;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    public void execute() throws UserException {
        ContractSearchManager manager = ContractSearchManager.getInstance();
        ContractSearchResult result = manager.getContractListByCondition(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     * @param condition ContractSearchCondition 検索条件
     */
    public void setContractSearchCondition(ContractSearchCondition condition) {
        _condition = condition;
    }

    /**
     * 結果を取得します
     * @return ContractSearchResult 結果
     */
    public ContractSearchResult getContractSearchResult() {
        return (ContractSearchResult)super.getResult().get(RESULT_KEY);
    }

}
