package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.ContractRegisterManager;
import jp.co.isid.ham.production.model.MaterialSearchCondition;
import jp.co.isid.ham.production.model.MaterialSearchResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 *
 * @author HAMチーム
 *
 */
public class GetIniDataForMaterialSearchCmd extends Command  {

    /**
	 *
	 */
	private static final long serialVersionUID = 1L;

	/** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private MaterialSearchCondition _condition;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
	public void execute() throws UserException {
		ContractRegisterManager manager = ContractRegisterManager.getInstance();
		MaterialSearchResult result = manager.getIniDataForMaterialSearch(_condition);
        getResult().set(RESULT_KEY, result);
	}

	/**
	 * 検索条件を設定します
	 * @param condition ContractRegisterCondition 検索条件
	 */
	public void setMaterialSearchCondition(MaterialSearchCondition condition) {
		_condition = condition;
	}

	/**
	 * 結果を取得します
	 * @return ContractRegisterResult 結果
	 */
	public MaterialSearchResult getMaterialSearchResult() {
		return (MaterialSearchResult)super.getResult().get(RESULT_KEY);
	}

}
