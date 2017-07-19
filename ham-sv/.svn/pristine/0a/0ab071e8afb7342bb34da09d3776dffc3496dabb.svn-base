package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.MaterialListManager;
import jp.co.isid.ham.production.model.MaterialListResult;
import jp.co.isid.ham.production.model.MaterialListCondition;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 *
 * @author HAMチーム
 *
 */
public class GetInitMaterialListCmd extends Command  {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private MaterialListCondition _condition;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    public void execute() throws UserException {
        MaterialListManager manager = MaterialListManager.getInstance();
        MaterialListResult result = manager.getInitMaterialList(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     * @param condition MaterialListCondition 検索条件
     */
    public void setMaterialListCondition(MaterialListCondition condition) {
        _condition = condition;
    }

    /**
     * 結果を取得します
     * @return MaterialListResult 結果
     */
    public MaterialListResult getMaterialListResult() {
        return (MaterialListResult)super.getResult().get(RESULT_KEY);
    }

}
