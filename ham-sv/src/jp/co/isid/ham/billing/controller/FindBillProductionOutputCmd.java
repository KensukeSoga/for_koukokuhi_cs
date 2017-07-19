package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.CheckBillProductionOutputCondition;
import jp.co.isid.ham.billing.model.CostManagementSettingManager;
import jp.co.isid.ham.billing.model.FindBillProductionOutputResult;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 制作請求表取得コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/18 T.Kobayashi)<BR>
 * </P>
 * @author T.Kobayashi
 */
public class FindBillProductionOutputCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    CheckBillProductionOutputCondition _cond;

    /**
     * 検索条件を使用し、検索処理を実行します
     * @throws HAMException 検索に失敗した場合
     */
    @Override
    public void execute() throws UserException {
        CostManagementSettingManager manager = CostManagementSettingManager.getInstance();
        FindBillProductionOutputResult result = manager.findBillProductionOutput(_cond);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 検索条件を設定します
     *
     * @param cond 検索条件
     */
    public void setCheckBillProductionOutputCondition(CheckBillProductionOutputCondition cond) {
        _cond = cond;
    }

    /**
     * 検索結果を返します
     *
     * @return 検索結果
     */
    public FindBillProductionOutputResult getFindBillProductionOutputResult() {
        return (FindBillProductionOutputResult)super.getResult().get(RESULT_KEY);
    }
}
