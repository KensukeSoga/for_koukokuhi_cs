package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.FindMstrHCProductManager;
import jp.co.isid.ham.billing.model.FindMstrHCProductResult;
import jp.co.isid.ham.common.model.Mbj08HcProductCondition;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * HC商品マスタ検索コマンド(商品コード手入力時)
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/25 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindMstrHCProductCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    Mbj08HcProductCondition _cond;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {
        FindMstrHCProductManager manager = FindMstrHCProductManager.getInstance();
        FindMstrHCProductResult result = manager.findMstrHCProduct(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param cond 検索条件
     */
    public void setMbj08HcProductCondition(Mbj08HcProductCondition cond) {
        _cond = cond;
    }

    /**
     * 検索結果を返します
     *
     * @return 検索結果
     */
    public FindMstrHCProductResult getFindMstrHCProductResult() {
        return (FindMstrHCProductResult)super.getResult().get(RESULT_KEY);
    }

}
