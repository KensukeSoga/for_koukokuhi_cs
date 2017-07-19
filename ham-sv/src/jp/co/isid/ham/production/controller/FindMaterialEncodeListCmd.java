package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.MaterialRegisterManager;
import jp.co.isid.ham.production.model.MaterialRegisterResult;
import jp.co.isid.ham.production.model.MaterialEncodeListCondition;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 *
 * @author HAMチーム
 *
 */
public class FindMaterialEncodeListCmd extends Command  {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private MaterialEncodeListCondition _condition;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    public void execute() throws UserException {
        MaterialRegisterManager manager = MaterialRegisterManager.getInstance();
        MaterialRegisterResult result = manager.findMaterialEncodeList(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     * @param condition MaterialEncodeCondition 検索条件
     */
    public void setMaterialEncodeCondition(MaterialEncodeListCondition condition) {
        _condition = condition;
    }

    /**
     * 結果を取得します
     * @return MaterialRegisterResult 結果
     */
    public MaterialRegisterResult getMaterialRegisterResult() {
        return (MaterialRegisterResult)super.getResult().get(RESULT_KEY);
    }

}
