package jp.co.isid.ham.billing.controller;

import jp.co.isid.ham.billing.model.HCEstimateListManager;
import jp.co.isid.ham.billing.model.RegisterBillDaysResult;
import jp.co.isid.ham.common.model.Mbj28BillDaysVO;
import jp.co.isid.nj.controller.command.Command;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 請求書出力年月マスタ登録コマンド
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/3/7 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class RegisterBillDaysCmd extends Command {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 検索結果キー */
    private static final String RESULT_KEY = "RESULT_KEY";

    Mbj28BillDaysVO _vo;

    /**
     * 請求書出力年月マスタ登録実行
     */
    @Override
    public void execute() throws UserException {
        HCEstimateListManager manager = HCEstimateListManager.getInstance();
        RegisterBillDaysResult result = manager.registerBillDays(_vo);
        getResult().set(RESULT_KEY, result);
    }

    /**
     * 登録データを設定します
     *
     * @param vo 登録データ
     */
    public void setMbj28BillDaysVO(Mbj28BillDaysVO vo) {
        _vo = vo;
    }

    /**
     * 登録結果を取得します
     *
     * @return 登録結果
     */
    public RegisterBillDaysResult getRegisterBillDaysResult() {
        return (RegisterBillDaysResult) super.getResult().get(RESULT_KEY);
    }

}
