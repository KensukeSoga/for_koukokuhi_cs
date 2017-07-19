package jp.co.isid.ham.production.controller;

import jp.co.isid.ham.production.model.FindCarListCondition;
import jp.co.isid.ham.production.model.FindCarListManager;
import jp.co.isid.ham.production.model.FindCarListResult;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.controller.command.CommandResult;
import jp.co.isid.nj.exp.UserException;

/**
 * 車種一覧検索コマンドクラス
 *
 * @author Takahiro Hadate
 *
 */
public class FindCarListCmd extends Command {

    /**
     *
     */
    private static final long serialVersionUID = 3846716604877886404L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** 検索条件 */
    private FindCarListCondition _condition;

    /**
     * {@inheritDoc}
     */
    @Override
    public void execute() throws UserException {
        FindCarListManager manager = FindCarListManager.getInstance();
        FindCarListResult result = manager.findCarList(_condition);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定する.
     * @param condition 検索条件
     */
    public void setCondition(FindCarListCondition condition) {
        this._condition = condition;
    }

    public FindCarListResult getCarResult() {
        CommandResult result = super.getResult();
        return (result != null) ? (FindCarListResult) result.get(RESULT_KEY) : null;
    }

}
