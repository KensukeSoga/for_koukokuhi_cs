package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.production.model.FindJasracCondition;
import jp.co.isid.ham.production.model.FindJasracResult;
import jp.co.isid.ham.production.model.JasracManager;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

public class FindJasracCmd extends Command
{
    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindJasracCondition _condition;

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    public void execute() throws UserException
    {
        FindJasracResult result = new FindJasracResult();
        JasracManager manager = JasracManager.getInstance();
        result = manager.findJasrac(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param condition FindContractCondition 検索条件
     */
    public void setFindContractCondition(FindJasracCondition condition)
    {
        _condition = condition;
    }

    /**
     * 条件検索結果を返します
     *
     * @return FindContractResult 条件検索結果
     */
    public FindJasracResult getFindContractResult()
    {
        return (FindJasracResult) super.getResult().get(RESULT_KEY);
    }

}
